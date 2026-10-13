/*
				   File: type_SdtSDTGoogleDriveApiResponse
			Description: SDTGoogleDriveApiResponse
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
	[XmlRoot(ElementName="SDTGoogleDriveApiResponse")]
	[XmlType(TypeName="SDTGoogleDriveApiResponse" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTGoogleDriveApiResponse : GxUserType
	{
		public SdtSDTGoogleDriveApiResponse( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTGoogleDriveApiResponse_Client_email = "";

			gxTv_SdtSDTGoogleDriveApiResponse_Private_key = "";

			gxTv_SdtSDTGoogleDriveApiResponse_Scope = "";

			gxTv_SdtSDTGoogleDriveApiResponse_Aud = "";

		}

		public SdtSDTGoogleDriveApiResponse(IGxContext context)
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


			AddObjectProperty("scope", gxTpr_Scope, false);


			AddObjectProperty("aud", gxTpr_Aud, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="client_email")]
		[XmlElement(ElementName="client_email")]
		public string gxTpr_Client_email
		{
			get {
				return gxTv_SdtSDTGoogleDriveApiResponse_Client_email; 
			}
			set {
				gxTv_SdtSDTGoogleDriveApiResponse_Client_email = value;
				SetDirty("Client_email");
			}
		}




		[SoapElement(ElementName="private_key")]
		[XmlElement(ElementName="private_key")]
		public string gxTpr_Private_key
		{
			get {
				return gxTv_SdtSDTGoogleDriveApiResponse_Private_key; 
			}
			set {
				gxTv_SdtSDTGoogleDriveApiResponse_Private_key = value;
				SetDirty("Private_key");
			}
		}




		[SoapElement(ElementName="scope")]
		[XmlElement(ElementName="scope")]
		public string gxTpr_Scope
		{
			get {
				return gxTv_SdtSDTGoogleDriveApiResponse_Scope; 
			}
			set {
				gxTv_SdtSDTGoogleDriveApiResponse_Scope = value;
				SetDirty("Scope");
			}
		}




		[SoapElement(ElementName="aud")]
		[XmlElement(ElementName="aud")]
		public string gxTpr_Aud
		{
			get {
				return gxTv_SdtSDTGoogleDriveApiResponse_Aud; 
			}
			set {
				gxTv_SdtSDTGoogleDriveApiResponse_Aud = value;
				SetDirty("Aud");
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
			gxTv_SdtSDTGoogleDriveApiResponse_Client_email = "";
			gxTv_SdtSDTGoogleDriveApiResponse_Private_key = "";
			gxTv_SdtSDTGoogleDriveApiResponse_Scope = "";
			gxTv_SdtSDTGoogleDriveApiResponse_Aud = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTGoogleDriveApiResponse_Client_email;
		 

		protected string gxTv_SdtSDTGoogleDriveApiResponse_Private_key;
		 

		protected string gxTv_SdtSDTGoogleDriveApiResponse_Scope;
		 

		protected string gxTv_SdtSDTGoogleDriveApiResponse_Aud;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTGoogleDriveApiResponse", Namespace="AlmangoX")]
	public class SdtSDTGoogleDriveApiResponse_RESTInterface : GxGenericCollectionItem<SdtSDTGoogleDriveApiResponse>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTGoogleDriveApiResponse_RESTInterface( ) : base()
		{	
		}

		public SdtSDTGoogleDriveApiResponse_RESTInterface( SdtSDTGoogleDriveApiResponse psdt ) : base(psdt)
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

		[DataMember(Name="scope", Order=2)]
		public  string gxTpr_Scope
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Scope);

			}
			set { 
				 sdt.gxTpr_Scope = value;
			}
		}

		[DataMember(Name="aud", Order=3)]
		public  string gxTpr_Aud
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Aud);

			}
			set { 
				 sdt.gxTpr_Aud = value;
			}
		}


		#endregion
		public SdtSDTGoogleDriveApiResponse sdt
		{
			get { 
				return (SdtSDTGoogleDriveApiResponse)Sdt;
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
				sdt = new SdtSDTGoogleDriveApiResponse() ;
			}
		}
	}
	#endregion
}