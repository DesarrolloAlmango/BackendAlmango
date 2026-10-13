/*
				   File: type_SdtSDTGoogleDrive
			Description: SDTGoogleDrive
				 Author: Nemo 🐠 for C# version 18.0.15.188745
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web.Services.Protocols;

using GeneXus.Programs;

namespace GeneXus.Programs.apis
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="SDTGoogleDrive")]
	[XmlType(TypeName="SDTGoogleDrive" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTGoogleDrive : GxUserType
	{
		public SdtSDTGoogleDrive( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTGoogleDrive_Client_email = "";

			gxTv_SdtSDTGoogleDrive_Private_key = "";

			gxTv_SdtSDTGoogleDrive_Token_uri = "";

			gxTv_SdtSDTGoogleDrive_Type = "";

			gxTv_SdtSDTGoogleDrive_Project_id = "";

			gxTv_SdtSDTGoogleDrive_Private_key_id = "";

			gxTv_SdtSDTGoogleDrive_Client_id = "";

			gxTv_SdtSDTGoogleDrive_Auth_uri = "";

			gxTv_SdtSDTGoogleDrive_Auth_provider_x509_cert_url = "";

			gxTv_SdtSDTGoogleDrive_Client_x509_cert_url = "";

			gxTv_SdtSDTGoogleDrive_Universe_domain = "";

		}

		public SdtSDTGoogleDrive(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("client_email", gxTpr_Client_email, false);


			AddObjectProperty("private_key", gxTpr_Private_key, false);


			AddObjectProperty("token_uri", gxTpr_Token_uri, false);


			AddObjectProperty("type", gxTpr_Type, false);


			AddObjectProperty("project_id", gxTpr_Project_id, false);


			AddObjectProperty("private_key_id", gxTpr_Private_key_id, false);


			AddObjectProperty("client_id", gxTpr_Client_id, false);


			AddObjectProperty("auth_uri", gxTpr_Auth_uri, false);


			AddObjectProperty("auth_provider_x509_cert_url", gxTpr_Auth_provider_x509_cert_url, false);


			AddObjectProperty("client_x509_cert_url", gxTpr_Client_x509_cert_url, false);


			AddObjectProperty("universe_domain", gxTpr_Universe_domain, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="client_email")]
		[XmlElement(ElementName="client_email")]
		public string gxTpr_Client_email
		{
			get {
				return gxTv_SdtSDTGoogleDrive_Client_email; 
			}
			set {
				gxTv_SdtSDTGoogleDrive_Client_email = value;
				SetDirty("Client_email");
			}
		}




		[SoapElement(ElementName="private_key")]
		[XmlElement(ElementName="private_key")]
		public string gxTpr_Private_key
		{
			get {
				return gxTv_SdtSDTGoogleDrive_Private_key; 
			}
			set {
				gxTv_SdtSDTGoogleDrive_Private_key = value;
				SetDirty("Private_key");
			}
		}




		[SoapElement(ElementName="token_uri")]
		[XmlElement(ElementName="token_uri")]
		public string gxTpr_Token_uri
		{
			get {
				return gxTv_SdtSDTGoogleDrive_Token_uri; 
			}
			set {
				gxTv_SdtSDTGoogleDrive_Token_uri = value;
				SetDirty("Token_uri");
			}
		}




		[SoapElement(ElementName="type")]
		[XmlElement(ElementName="type")]
		public string gxTpr_Type
		{
			get {
				return gxTv_SdtSDTGoogleDrive_Type; 
			}
			set {
				gxTv_SdtSDTGoogleDrive_Type = value;
				SetDirty("Type");
			}
		}




		[SoapElement(ElementName="project_id")]
		[XmlElement(ElementName="project_id")]
		public string gxTpr_Project_id
		{
			get {
				return gxTv_SdtSDTGoogleDrive_Project_id; 
			}
			set {
				gxTv_SdtSDTGoogleDrive_Project_id = value;
				SetDirty("Project_id");
			}
		}




		[SoapElement(ElementName="private_key_id")]
		[XmlElement(ElementName="private_key_id")]
		public string gxTpr_Private_key_id
		{
			get {
				return gxTv_SdtSDTGoogleDrive_Private_key_id; 
			}
			set {
				gxTv_SdtSDTGoogleDrive_Private_key_id = value;
				SetDirty("Private_key_id");
			}
		}




		[SoapElement(ElementName="client_id")]
		[XmlElement(ElementName="client_id")]
		public string gxTpr_Client_id
		{
			get {
				return gxTv_SdtSDTGoogleDrive_Client_id; 
			}
			set {
				gxTv_SdtSDTGoogleDrive_Client_id = value;
				SetDirty("Client_id");
			}
		}




		[SoapElement(ElementName="auth_uri")]
		[XmlElement(ElementName="auth_uri")]
		public string gxTpr_Auth_uri
		{
			get {
				return gxTv_SdtSDTGoogleDrive_Auth_uri; 
			}
			set {
				gxTv_SdtSDTGoogleDrive_Auth_uri = value;
				SetDirty("Auth_uri");
			}
		}




		[SoapElement(ElementName="auth_provider_x509_cert_url")]
		[XmlElement(ElementName="auth_provider_x509_cert_url")]
		public string gxTpr_Auth_provider_x509_cert_url
		{
			get {
				return gxTv_SdtSDTGoogleDrive_Auth_provider_x509_cert_url; 
			}
			set {
				gxTv_SdtSDTGoogleDrive_Auth_provider_x509_cert_url = value;
				SetDirty("Auth_provider_x509_cert_url");
			}
		}




		[SoapElement(ElementName="client_x509_cert_url")]
		[XmlElement(ElementName="client_x509_cert_url")]
		public string gxTpr_Client_x509_cert_url
		{
			get {
				return gxTv_SdtSDTGoogleDrive_Client_x509_cert_url; 
			}
			set {
				gxTv_SdtSDTGoogleDrive_Client_x509_cert_url = value;
				SetDirty("Client_x509_cert_url");
			}
		}




		[SoapElement(ElementName="universe_domain")]
		[XmlElement(ElementName="universe_domain")]
		public string gxTpr_Universe_domain
		{
			get {
				return gxTv_SdtSDTGoogleDrive_Universe_domain; 
			}
			set {
				gxTv_SdtSDTGoogleDrive_Universe_domain = value;
				SetDirty("Universe_domain");
			}
		}



		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Static Type Properties

		[SoapIgnore]
		[XmlIgnore]
		private static GXTypeInfo _typeProps;
		protected override GXTypeInfo TypeInfo { get { return _typeProps; } set { _typeProps = value; } }

		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSDTGoogleDrive_Client_email = "";
			gxTv_SdtSDTGoogleDrive_Private_key = "";
			gxTv_SdtSDTGoogleDrive_Token_uri = "";
			gxTv_SdtSDTGoogleDrive_Type = "";
			gxTv_SdtSDTGoogleDrive_Project_id = "";
			gxTv_SdtSDTGoogleDrive_Private_key_id = "";
			gxTv_SdtSDTGoogleDrive_Client_id = "";
			gxTv_SdtSDTGoogleDrive_Auth_uri = "";
			gxTv_SdtSDTGoogleDrive_Auth_provider_x509_cert_url = "";
			gxTv_SdtSDTGoogleDrive_Client_x509_cert_url = "";
			gxTv_SdtSDTGoogleDrive_Universe_domain = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTGoogleDrive_Client_email;
		 

		protected string gxTv_SdtSDTGoogleDrive_Private_key;
		 

		protected string gxTv_SdtSDTGoogleDrive_Token_uri;
		 

		protected string gxTv_SdtSDTGoogleDrive_Type;
		 

		protected string gxTv_SdtSDTGoogleDrive_Project_id;
		 

		protected string gxTv_SdtSDTGoogleDrive_Private_key_id;
		 

		protected string gxTv_SdtSDTGoogleDrive_Client_id;
		 

		protected string gxTv_SdtSDTGoogleDrive_Auth_uri;
		 

		protected string gxTv_SdtSDTGoogleDrive_Auth_provider_x509_cert_url;
		 

		protected string gxTv_SdtSDTGoogleDrive_Client_x509_cert_url;
		 

		protected string gxTv_SdtSDTGoogleDrive_Universe_domain;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTGoogleDrive", Namespace="AlmangoX")]
	public class SdtSDTGoogleDrive_RESTInterface : GxGenericCollectionItem<SdtSDTGoogleDrive>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTGoogleDrive_RESTInterface( ) : base()
		{	
		}

		public SdtSDTGoogleDrive_RESTInterface( SdtSDTGoogleDrive psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="client_email", Order=0)]
		public  string gxTpr_Client_email
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Client_email);

			}
			set { 
				 sdt.gxTpr_Client_email = value;
			}
		}

		[DataMember(Name="private_key", Order=1)]
		public  string gxTpr_Private_key
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Private_key);

			}
			set { 
				 sdt.gxTpr_Private_key = value;
			}
		}

		[DataMember(Name="token_uri", Order=2)]
		public  string gxTpr_Token_uri
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Token_uri);

			}
			set { 
				 sdt.gxTpr_Token_uri = value;
			}
		}

		[DataMember(Name="type", Order=3)]
		public  string gxTpr_Type
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Type);

			}
			set { 
				 sdt.gxTpr_Type = value;
			}
		}

		[DataMember(Name="project_id", Order=4)]
		public  string gxTpr_Project_id
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Project_id);

			}
			set { 
				 sdt.gxTpr_Project_id = value;
			}
		}

		[DataMember(Name="private_key_id", Order=5)]
		public  string gxTpr_Private_key_id
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Private_key_id);

			}
			set { 
				 sdt.gxTpr_Private_key_id = value;
			}
		}

		[DataMember(Name="client_id", Order=6)]
		public  string gxTpr_Client_id
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Client_id);

			}
			set { 
				 sdt.gxTpr_Client_id = value;
			}
		}

		[DataMember(Name="auth_uri", Order=7)]
		public  string gxTpr_Auth_uri
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Auth_uri);

			}
			set { 
				 sdt.gxTpr_Auth_uri = value;
			}
		}

		[DataMember(Name="auth_provider_x509_cert_url", Order=8)]
		public  string gxTpr_Auth_provider_x509_cert_url
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Auth_provider_x509_cert_url);

			}
			set { 
				 sdt.gxTpr_Auth_provider_x509_cert_url = value;
			}
		}

		[DataMember(Name="client_x509_cert_url", Order=9)]
		public  string gxTpr_Client_x509_cert_url
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Client_x509_cert_url);

			}
			set { 
				 sdt.gxTpr_Client_x509_cert_url = value;
			}
		}

		[DataMember(Name="universe_domain", Order=10)]
		public  string gxTpr_Universe_domain
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Universe_domain);

			}
			set { 
				 sdt.gxTpr_Universe_domain = value;
			}
		}


		#endregion
		public SdtSDTGoogleDrive sdt
		{
			get { 
				return (SdtSDTGoogleDrive)Sdt;
			}
			set {
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtSDTGoogleDrive() ;
			}
		}
	}
	#endregion
}