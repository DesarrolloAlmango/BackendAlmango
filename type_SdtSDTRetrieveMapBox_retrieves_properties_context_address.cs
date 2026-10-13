/*
				   File: type_SdtSDTRetrieveMapBox_retrieves_properties_context_address
			Description: address
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


namespace GeneXus.Programs
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="SDTRetrieveMapBox.retrieves.properties.context.address")]
	[XmlType(TypeName="SDTRetrieveMapBox.retrieves.properties.context.address" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTRetrieveMapBox_retrieves_properties_context_address : GxUserType
	{
		public SdtSDTRetrieveMapBox_retrieves_properties_context_address( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_address_Id = "";

			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_address_Address_number = "";

			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_address_Street_name = "";

		}

		public SdtSDTRetrieveMapBox_retrieves_properties_context_address(IGxContext context)
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
			AddObjectProperty("id", gxTpr_Id, false);


			AddObjectProperty("address_number", gxTpr_Address_number, false);


			AddObjectProperty("street_name", gxTpr_Street_name, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="id")]
		[XmlElement(ElementName="id")]
		public string gxTpr_Id
		{
			get {
				return gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_address_Id; 
			}
			set {
				gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_address_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="address_number")]
		[XmlElement(ElementName="address_number")]
		public string gxTpr_Address_number
		{
			get {
				return gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_address_Address_number; 
			}
			set {
				gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_address_Address_number = value;
				SetDirty("Address_number");
			}
		}




		[SoapElement(ElementName="street_name")]
		[XmlElement(ElementName="street_name")]
		public string gxTpr_Street_name
		{
			get {
				return gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_address_Street_name; 
			}
			set {
				gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_address_Street_name = value;
				SetDirty("Street_name");
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
			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_address_Id = "";
			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_address_Address_number = "";
			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_address_Street_name = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_address_Id;
		 

		protected string gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_address_Address_number;
		 

		protected string gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_address_Street_name;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTRetrieveMapBox.retrieves.properties.context.address", Namespace="AlmangoX")]
	public class SdtSDTRetrieveMapBox_retrieves_properties_context_address_RESTInterface : GxGenericCollectionItem<SdtSDTRetrieveMapBox_retrieves_properties_context_address>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTRetrieveMapBox_retrieves_properties_context_address_RESTInterface( ) : base()
		{	
		}

		public SdtSDTRetrieveMapBox_retrieves_properties_context_address_RESTInterface( SdtSDTRetrieveMapBox_retrieves_properties_context_address psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="id", Order=0)]
		public  string gxTpr_Id
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Id);

			}
			set { 
				 sdt.gxTpr_Id = value;
			}
		}

		[DataMember(Name="address_number", Order=1)]
		public  string gxTpr_Address_number
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Address_number);

			}
			set { 
				 sdt.gxTpr_Address_number = value;
			}
		}

		[DataMember(Name="street_name", Order=2)]
		public  string gxTpr_Street_name
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Street_name);

			}
			set { 
				 sdt.gxTpr_Street_name = value;
			}
		}


		#endregion
		public SdtSDTRetrieveMapBox_retrieves_properties_context_address sdt
		{
			get { 
				return (SdtSDTRetrieveMapBox_retrieves_properties_context_address)Sdt;
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
				sdt = new SdtSDTRetrieveMapBox_retrieves_properties_context_address() ;
			}
		}
	}
	#endregion
}