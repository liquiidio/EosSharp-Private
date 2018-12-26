﻿using Cryptography.ECDSA;
using EosSharp.Core.Exceptions;
using EosSharp.Core.Helpers;
using EosSharp.Core.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace EosSharp.Unity3D
{
    public class HttpHelper : IHttpHelper
    {
        private static readonly HttpClient client = new HttpClient();
        private static Dictionary<string, object> ResponseCache { get; set; } = new Dictionary<string, object>();
        private static readonly DefaultContractResolver SnakeCaseContractResolver = new DefaultContractResolver()
        {
            NamingStrategy = new PascalToSnakeCaseNamingStrategy()
        };
        private static readonly JsonSerializerSettings defaultJsonSettings = new JsonSerializerSettings()
        {
            ContractResolver = SnakeCaseContractResolver
        };

        public void ClearResponseCache()
        {
            ResponseCache.Clear();
        }

        public async Task<TResponseData> PostJsonAsync<TResponseData>(string url, object data)
        {
            UnityWebRequest uwr = BuildUnityWebRequest(url, "POST", data);

            await uwr.SendWebRequest();

            if (uwr.isNetworkError)
            {
                Console.WriteLine("Error While Sending: " + uwr.error);
            }
            else
            {
                Console.WriteLine("Received: " + uwr.downloadHandler.text);
            }

            using (var stream = new MemoryStream(uwr.downloadHandler.data))
            {
                return DeserializeJsonFromStream<TResponseData>(stream);
            }
        }

        public Task<TResponseData> PostJsonAsync<TResponseData>(string url, object data, CancellationToken cancellationToken)
        {
            return PostJsonAsync<TResponseData>(url, data);
        }

        public async Task<TResponseData> PostJsonWithCacheAsync<TResponseData>(string url, object data, bool reload = false)
        {
            string hashKey = GetRequestHashKey(url, data);

            if (!reload)
            {
                object value;
                if (ResponseCache.TryGetValue(hashKey, out value))
                    return (TResponseData)value;
            }

            UnityWebRequest uwr = BuildUnityWebRequest(url, "POST", data);

            await uwr.SendWebRequest();

            if (uwr.isNetworkError)
            {
                Console.WriteLine("Error While Sending: " + uwr.error);
            }
            else
            {
                Console.WriteLine("Received: " + uwr.downloadHandler.text);
            }

            using (var stream = new MemoryStream(uwr.downloadHandler.data))
            {
                var responseData = DeserializeJsonFromStream<TResponseData>(stream);
                UpdateResponseDataCache(hashKey, responseData);
                return responseData;
            }
        }

        public Task<TResponseData> PostJsonWithCacheAsync<TResponseData>(string url, object data, CancellationToken cancellationToken, bool reload = false)
        {
            return PostJsonWithCacheAsync<TResponseData>(url, data, reload);
        }

        public async Task<TResponseData> GetJsonAsync<TResponseData>(string url)
        {
            UnityWebRequest uwr = UnityWebRequest.Get(url);

            await uwr.SendWebRequest();

            if (uwr.isNetworkError)
            {
                Console.WriteLine("Error While Sending: " + uwr.error);
            }
            else
            {
                Console.WriteLine("Received: " + uwr.downloadHandler.text);
            }

            using (var stream = new MemoryStream(uwr.downloadHandler.data))
            {
                return DeserializeJsonFromStream<TResponseData>(stream);
            }
        }

        public Task<TResponseData> GetJsonAsync<TResponseData>(string url, CancellationToken cancellationToken)
        {
            return GetJsonAsync<TResponseData>(url);
        }

        public async Task<Stream> SendAsync(HttpRequestMessage request)
        {
            var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            return await BuildSendResponse(response);
        }

        public async Task<Stream> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
            return await BuildSendResponse(response);
        }

        public TData DeserializeJsonFromStream<TData>(Stream stream)
        {
            if (stream == null || stream.CanRead == false)
                return default(TData);

            using (var sr = new StreamReader(stream))
            using (var jtr = new JsonTextReader(sr))
            {
                return JsonSerializer.Create(defaultJsonSettings).Deserialize<TData>(jtr);
            }
        }

        public HttpRequestMessage BuildJsonRequestMessage(string url, object data)
        {
            return new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(JsonConvert.SerializeObject(data, defaultJsonSettings), Encoding.UTF8, "application/json")
            };
        }

        public void UpdateResponseDataCache<TResponseData>(string hashKey, TResponseData responseData)
        {
            if (ResponseCache.ContainsKey(hashKey))
            {
                ResponseCache[hashKey] = responseData;
            }
            else
            {
                ResponseCache.Add(hashKey, responseData);
            }
        }

        public string GetRequestHashKey(string url, object data)
        {
            var keyBytes = new List<byte[]>()
            {
                Encoding.UTF8.GetBytes(url),
                SerializationHelper.ObjectToByteArray(data)
            };
            return Encoding.Default.GetString(Sha256Manager.GetHash(SerializationHelper.Combine(keyBytes)));
        }

        public async Task<Stream> BuildSendResponse(HttpResponseMessage response)
        {
            var stream = await response.Content.ReadAsStreamAsync();

            if (response.IsSuccessStatusCode)
                return stream;

            var content = await StreamToStringAsync(stream);

            ApiErrorException apiError = null;
            try
            {
                apiError = JsonConvert.DeserializeObject<ApiErrorException>(content, defaultJsonSettings);
            }
            catch(Exception)
            {
                throw new ApiException
                {
                    StatusCode = (int)response.StatusCode,
                    Content = content
                };
            }

            throw apiError;
        }

        public async Task<string> StreamToStringAsync(Stream stream)
        {
            string content = null;

            if (stream != null)
                using (var sr = new StreamReader(stream))
                    content = await sr.ReadToEndAsync();

            return content;
        }

        private static UnityWebRequest BuildUnityWebRequest(string url, string verb, object data)
        {
            var uwr = new UnityWebRequest(url, verb);
            byte[] jsonToSend = new UTF8Encoding().GetBytes(JsonConvert.SerializeObject(data, defaultJsonSettings));
            uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            uwr.SetRequestHeader("Content-Type", "application/json");
            return uwr;
        }
    }
}
