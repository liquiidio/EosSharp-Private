﻿  

  

// Auto Generated, do not edit.
using EosSharp.Core.DataAttributes;
using System;
using System.Collections.Generic;

namespace EosSharp.Core.Api.v1
{
	#region generate api types
	[Serializable]
	public class Symbol
    {
		//! Name of the Symbol
		public string name;
		//! Precision of the Symbol
		public byte precision;
    }
	[Serializable]
	public class Resource
    {
		//! Amount used	
		public Int64 used;
		//! Amount available
		public Int64 available;
		//! Max Amount
		public Int64 max;
    }
	[Serializable]
	public class AuthorityKey
    {
		//! Public Key of the Authority
		public string key;
		//! Weight of the Key
		public Int32 weight;
    }
	[Serializable]
	public class AuthorityAccount
    {
		//! Permission Level of an Authority
		public PermissionLevel permission;
		//! Weight of the Permission
		public Int32 weight;
    }
	[Serializable]
	public class AuthorityWait
    {
		//! Delay in Seconds
		public string wait_sec;
		//! Weight of the AuthorityWait
		public Int32 weight;
    }
	[Serializable]
	public class Authority
    {
		//! Threshold of the Authority
		public UInt32 threshold;
		//! Keys assigned to the Authority
		public List<AuthorityKey> keys;
		//! Accounts assigned to the Authority	
		public List<AuthorityAccount> accounts;
		//! Waits assigned to the Authority
		public List<AuthorityWait> waits;
    }
	[Serializable]
	public class Permission
    {
		//! Name of the Permission
		public string perm_name;
		//! Parent-Permission of the Permission
		public string parent;
		//! Authority Required
		public Authority required_auth;
    }
	[Serializable]
	public class AbiType
    {
		//! New Type-Name
		public string new_type_name;
		//! Initial/Original Type-Name
		public string type;
    }
	[Serializable]
	public class AbiField
    {
		//! Name of the AbiField
		public string name;
		//! Type of the AbiField
		public string type;
    }
	[Serializable]
	public class AbiStruct
    {
		//! Name of the AbiStruct
		public string name;
		//! base-struct of the AbiStruct
		public string @base;
		//! List fo Fields of the AbiStruct
		public List<AbiField> fields;
    }
	[Serializable]
	public class AbiAction
    {
		[AbiFieldType("name")]
		//! Name of the Action
		public string name;
		//! Type of the Action	
		public string type;
		//! Ricardian-Contract of the Action
		public string ricardian_contract;
    }
	[Serializable]
	public class AbiTable
    {
		[AbiFieldType("name")]
		//! Name of the Table
		public string name;
		//! index-type of the primary index
		public string index_type;
		//! Key-Names of the Table
		public List<string> key_names;
		//! Key-Types of the Table
		public List<string> key_types;
		//! Type of the Table-Rows
		public string type;
    }
	[Serializable]
	public class Abi
    {
		//! ABI-Version used for the ABI
		public string version;
		//! List of Types contained in the ABI
		public List<AbiType> types;
		//! List of Structs contained in the ABI
		public List<AbiStruct> structs;
		//! List of Actions contained in the ABI
		public List<AbiAction> actions;
		//! List of Tables contained in the ABI
		public List<AbiTable> tables;
		//! List of Ricardian Clauses contained in the ABI
		public List<AbiRicardianClause> ricardian_clauses;
		//! List of Error Messages contained in the ABI
		public List<string> error_messages;
		//! List of Ricardian Clauses contained in the ABI
		public List<Extension> abi_extensions;
		//! List of Variants contained in the ABI
		public List<Variant> variants;
    }
	[Serializable]
	public class AbiRicardianClause
    {
		//! Identifier of the Ricardian Clause
		public string id;
		//! Body/Content of the Ricardian Clause
		public string body;
    }
	[Serializable]
	public class CurrencyStat
    {
		//! Current Supply of the Currency
		public string supply;
		//! Maximum Supply of the Currency
		public string max_supply;
		//! Issuer of the Currency
		public string issuer;
    }
	[Serializable]
	public class Producer
    {
		[AbiFieldType("name")]
		//! name of the Owner of the Producer
		public string owner;
		[AbiFieldType("float64")]
		//! Total votes this producer received
		public double total_votes;
		[AbiFieldType("public_key")]
		//! Public Key of the Producer
		public string producer_key;
		//! true if Producer is active, false if not
		public bool is_active;
		//! Url pointing to the website of the producer
		public string url;
		//! Number of unpaid Blocks
		public UInt32 unpaid_blocks;
		//! Time the Producer last claimed 
		public UInt64 last_claim_time;
		//! Location of the Producer (ISO-Code)
		public UInt16 location;
    }
	[Serializable]
	public class ScheduleProducers
    {
		//! Name of the Producer Account
		public string producer_name;
		//! Key used to sign transactions
		public string block_signing_key;
    }
	[Serializable]
	public class Schedule
    {
		//! Schedule Version
		public UInt32? version;
		//! List of ctive Producers
		public List<ScheduleProducers> producers;
    }
	[Serializable]
	public class PermissionLevel
    {
		//! Name of the Account
		public string actor;
		//! Name of the Permission
		public string permission;
    }
	[Serializable]
	public class Extension
    {
		
		public UInt16 type;
		
		public byte[] data;
    }
	[Serializable]
	public class Variant
    {
		
		public string name;
		
		public List<string> types;
    }
	[Serializable]
	public class Action
    {
		
		public string account;
		
		public string name;
		
		public List<PermissionLevel> authorization;
		
		public object data;
		
		public string hex_data;
    }
	[Serializable]
	public class Transaction
    {
		
		public DateTime expiration;
		
		public UInt16 ref_block_num;
		
		public UInt32 ref_block_prefix;
		
		public UInt32 max_net_usage_words;
		
		public byte max_cpu_usage_ms;
		
		public UInt32 delay_sec;
		
		public List<Action> context_free_actions = new List<Action>();
		
		public List<Action> actions = new List<Action>();
		
		public List<Extension> transaction_extensions = new List<Extension>();
    }
	[Serializable]
	public class ScheduledTransaction
    {
		
		public string trx_id;
		
		public string sender;
		
		public string sender_id;
		
		public string payer;
		
		public DateTime? delay_until;
		
		public DateTime? expiration;
		
		public DateTime? published;
		
		public Object transaction;
    }
	[Serializable]
	public class Receipt
    {
		
		public string receiver;
		
		public string act_digest;
		
		public UInt64? global_sequence;
		
		public UInt64? recv_sequence;
		
		public List<List<object>> auth_sequence;
		
		public UInt64? code_sequence;
		
		public UInt64? abi_sequence;
    }
	[Serializable]
	public class ActionTrace
    {
		
		public Receipt receipt;
		
		public Action act;
		
		public UInt32? elapsed;
		
		public UInt32? cpu_usage;
		
		public string console;
		
		public UInt32? total_cpu_usage;
		
		public string trx_id;
		
		public List<ActionTrace> inline_traces;
    }
	[Serializable]
	public class GlobalAction
    {
		
		public UInt64? global_action_seq;
		
		public UInt64? account_action_seq;
		
		public UInt32? block_num;
		
		public DateTime? block_time;
		
		public ActionTrace action_trace;
    }
	[Serializable]
	public class TransactionReceipt
    {
		
		public string status;
		
		public UInt32? cpu_usage_us;
		
		public UInt32? net_usage_words;
		
		public object trx;
    }
	[Serializable]
	public class ProcessedTransaction
    {
		
		public string id;
		
		public TransactionReceipt receipt;
		
		public UInt32 elapsed;
		
		public UInt32 net_usage;
		
		public bool scheduled;
		
		public string except;
		
		public List<ActionTrace> action_traces;
    }
	[Serializable]
	public class DetailedTransaction
    {
		
		public TransactionReceipt receipt;
		
		public Transaction trx;
    }
	[Serializable]
	public class PackedTransaction
    {
		
		public string compression;
		
		public List<object> context_free_data;
		
		public string id;
		
		public string packed_context_free_data;
		
		public string packed_trx;
		
		public List<string> signatures;
		
		public Transaction transaction;
    }
	[Serializable]
	public class RefundRequest
    {
		
		public string cpu_amount;
		
		public string net_amount;
    }
	[Serializable]
	public class SelfDelegatedBandwidth
    {
		
		public string cpu_weight;
		
		public string from;
		
		public string net_weight;
		
		public string to;
    }
	[Serializable]
	public class TotalResources
    {
		
		public string cpu_weight;
		
		public string net_weight;
		
		public string owner;
		
		public UInt64? ram_bytes;
    }
	[Serializable]
	public class VoterInfo
    {
		
		public bool? is_proxy;
		
		public double? last_vote_weight;
		
		public string owner;
		
		public List<string> producers;
		
		public double? proxied_vote_weight;
		
		public string proxy;
		
		public UInt64? staked;
    }
	[Serializable]
	public class ExtendedAsset
    {
		
		public string quantity;
		
		public string contract;
    }
	[Serializable]
	public class TableByScopeResultRow
    {
		
		public string code;
		
		public string scope;
		
		public string table;
		
		public string payer;
		
		public UInt32? count;
    }
	[Serializable]
	public class BlockHeader
    {
		
		public DateTime timestamp;
		
		public string producer;
		
		public UInt32 confirmed;
		
		public string previous;
		
		public string transaction_mroot;
		
		public string action_mroot;
		
		public UInt32 schedule_version;
		
		public object new_producers;
		
		public object header_extensions;
    }
	[Serializable]
	public class SignedBlockHeader
    {
		
		public DateTime timestamp;
		
		public string producer;
		
		public UInt32 confirmed;
		
		public string previous;
		
		public string transaction_mroot;
		
		public string action_mroot;
		
		public UInt32 schedule_version;
		
		public object new_producers;
		
		public object header_extensions;
		
		public string producer_signature;
    }
	[Serializable]
	public class Merkle
    {
		
		public List<string> _active_nodes;
		
		public UInt32 _node_count;
    }
	[Serializable]
	public class ActivedProtocolFeatures
    {
		
		public List<string> protocol_features;
    }
	#endregion

	#region generate api method types
	[Serializable]
    public class GetInfoResponse
    {
 
		public string server_version;
 
		public string chain_id;
 
		public UInt32 head_block_num;
 
		public UInt32 last_irreversible_block_num;
 
		public string last_irreversible_block_id;
 
		public string head_block_id;
 
		public DateTime head_block_time;
 
		public string head_block_producer;
 
		public string virtual_block_cpu_limit;
 
		public string virtual_block_net_limit;
 
		public string block_cpu_limit;
 
		public string block_net_limit;
    }
	[Serializable]
    public class GetAccountRequest
    {
		public string account_name;
    }
	[Serializable]
    public class GetAccountResponse
    {
 
		public string account_name;
 
		public UInt32 head_block_num;
 
		public DateTime head_block_time;
 
		public bool privileged;
 
		public DateTime last_code_update;
 
		public DateTime created;
 
		public Int64 ram_quota;
 
		public Int64 net_weight;
 
		public Int64 cpu_weight;
 
		public Resource net_limit;
 
		public Resource cpu_limit;
 
		public UInt64 ram_usage;
 
		public List<Permission> permissions;
 
		public RefundRequest refund_request;
 
		public SelfDelegatedBandwidth self_delegated_bandwidth;
 
		public TotalResources total_resources;
 
		public VoterInfo voter_info;
    }
	[Serializable]
    public class GetCodeRequest
    {
		public string account_name;
		public bool code_as_wasm;
    }
	[Serializable]
    public class GetCodeResponse
    {
 
		public string account_name;
 
		public string wast;
 
		public string wasm;
 
		public string code_hash;
 
		public Abi abi;
    }
	[Serializable]
    public class GetAbiRequest
    {
		public string account_name;
    }
	[Serializable]
    public class GetAbiResponse
    {
 
		public string account_name;
 
		public Abi abi;
    }
	[Serializable]
    public class GetRawCodeAndAbiRequest
    {
		public string account_name;
    }
	[Serializable]
    public class GetRawCodeAndAbiResponse
    {
 
		public string account_name;
 
		public string wasm;
 
		public string abi;
    }
	[Serializable]
    public class GetRawAbiRequest
    {
		public string account_name;
		public string abi_hash;
    }
	[Serializable]
    public class GetRawAbiResponse
    {
 
		public string account_name;
 
		public string code_hash;
 
		public string abi_hash;
 
		public string abi;
    }
	[Serializable]
    public class AbiJsonToBinRequest
    {
		public string code;
		public string action;
		public object args;
    }
	[Serializable]
    public class AbiJsonToBinResponse
    {
 
		public string binargs;
    }
	[Serializable]
    public class AbiBinToJsonRequest
    {
		public string code;
		public string action;
		public string binargs;
    }
	[Serializable]
    public class AbiBinToJsonResponse
    {
 
		public object args;
    }
	[Serializable]
    public class GetRequiredKeysRequest
    {
		public Transaction transaction;
		public List<string> available_keys;
    }
	[Serializable]
    public class GetRequiredKeysResponse
    {
 
		public List<string> required_keys;
    }
	[Serializable]
    public class GetBlockRequest
    {
		public string block_num_or_id;
    }
    [Serializable]
	public class GetBlockInfoRequest
    {
        public int block_num;
    }
    [Serializable]
    public class GetBlockResponse : GetBlockInfoResponse
	{
        public Schedule new_producers;
 
		public List<Extension> block_extensions;
 
		public List<Extension> header_extensions;
        
		public List<TransactionReceipt> transactions;
    }
    [Serializable]
    public class GetBlockInfoResponse
    {

        public DateTime timestamp;

        public string producer;

        public UInt32 confirmed;

        public string previous;

        public string transaction_mroot;

        public string action_mroot;

        public UInt32 schedule_version;

        public string producer_signature;

        public string id;

        public UInt32 block_num;

        public UInt32 ref_block_prefix;
    }
	[Serializable]
    public class GetBlockHeaderStateRequest
    {
		public string block_num_or_id;
    }
	[Serializable]
    public class GetBlockHeaderStateResponse
    {
 
		public Schedule active_schedule;
 
		public UInt32 bft_irreversible_blocknum;
 
		public UInt32 block_num;
 
		public string block_signing_key;
 
		public Merkle blockroot_merkle;
 
		public List<UInt32> confirm_count;
 
		public object confirmations;
 
		public UInt32 dpos_irreversible_blocknum;
 
		public UInt32 dpos_proposed_irreversible_blocknum;
 
		public SignedBlockHeader header;
 
		public string id;
 
		public Schedule pending_schedule;
 
		public ActivedProtocolFeatures activated_protocol_features;
 
		public List<List<string>> producer_to_last_produced;
 
		public List<List<string>> producer_to_last_implied_irb;
    }
	[Serializable]
    public class GetTableRowsRequest
    {
		public bool json = false;
		public string code;
		public string scope;
		public string table;
		public string table_key;
		public string lower_bound = "0";
		public string upper_bound = "-1";
		public Int32 limit = 10;
		public string key_type;
		public string index_position;
		public string encode_type = "dec";
		public bool reverse;
		public bool show_payer;
    }
	[Serializable]
    public class GetTableRowsResponse
    {
 
		public List<object> rows;
 
		public bool more;
    }
	[Serializable]
    public class GetTableRowsResponse<TRowType>
    {
   
		public List<TRowType> rows;
   
		public bool more;
    }
	[Serializable]
    public class GetTableByScopeRequest
    {
		public string code;
		public string table;
		public string lower_bound;
		public string upper_bound;
		public Int32 limit = 10;
		public bool reverse;
    }
	[Serializable]
    public class GetTableByScopeResponse
    {
 
		public List<TableByScopeResultRow> rows;
 
		public string more;
    }
	[Serializable]
    public class GetCurrencyBalanceRequest
    {
		public string code;
		public string account;
		public string symbol;
    }
	[Serializable]
    public class GetCurrencyBalanceResponse
    {
 
		public List<string> assets;
    }
	[Serializable]
    public class GetCurrencyStatsRequest
    {
		public string code;
		public string symbol;
    }
	[Serializable]
    public class GetCurrencyStatsResponse
    {
 
		public Dictionary<string, CurrencyStat> stats;
    }
	[Serializable]
    public class GetProducersRequest
    {
		public bool json = false;
		public string lower_bound;
		public Int32 limit = 50;
    }
	[Serializable]
    public class GetProducersResponse
    {
 
		public List<object> rows;
 
		public double total_producer_vote_weight;
 
		public string more;
    }
	[Serializable]
    public class GetProducerScheduleResponse
    {
 
		public Schedule active;
 
		public Schedule pending;
 
		public Schedule proposed;
    }
	[Serializable]
    public class GetScheduledTransactionsRequest
    {
		public bool json = false;
		public string lower_bound;
		public Int32 limit = 50;
    }
	[Serializable]
    public class GetScheduledTransactionsResponse
    {
 
		public List<ScheduledTransaction> transactions;
 
		public string more;
    }
	[Serializable]
    public class PushTransactionRequest
    {
		public string[] signatures;
		public UInt32 compression;
		public string packed_context_free_data;
		public string packed_trx;
		public Transaction transaction;
    }
	[Serializable]
    public class PushTransactionResponse
    {
 
		public string transaction_id;
 
		public ProcessedTransaction processed;
    }
    [Serializable]
    public class GetActivatedProtocolFeaturesRequest
    {
        public string upper_bound = "-1";
        public string lower_bound = "0";
        public Int32 limit = 10;
        public bool search_by_block_num;
        public bool reverse;
    }
    [Serializable]
    public class GetActivatedProtocolFeaturesResponse
    {
		//! List of Activated Protocol Features
        public List<string> activated_protocol_features;
    }
    [Serializable]
    public class GetAccountsByAuthorizersRequest
    {
		//! List of Accounts assigned to the Authorizer
        public List<string> accounts;
		// List of Public Keys assigned to the Authorizer
        public List<string> keys;
    }
    [Serializable]
    public class GetAccountsByAuthorizersResponse
    {
		public class Account
		{
			//! Name of the Account
            public string account_name;
			//! Name of the Permission
			public string permission_name;
			//! Name of the Authorizer
			public string authorizer;
			//! Weight of the Authorizer
			public ushort weight;
			//! Threshold to sign
            public ushort threshold;
        }
		public List<GetAccountsByAuthorizersResponse.Account> accounts;
    }
	#endregion
}

