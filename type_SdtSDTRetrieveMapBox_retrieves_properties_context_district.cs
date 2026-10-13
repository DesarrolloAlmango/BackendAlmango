/*
				   File: type_SdtSDTRetrieveMapBox_retrieves_properties_context_district
			Description: district
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
	[XmlRoot(ElementName="SDTRetrieveMapBox.retrieves.properties.context.district")]
	[XmlType(TypeName="SDTRetrieveMapBox.retrieves.properties.context.district" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTRetrieveMapBox_retrieves_properties_context_district : GxUserType
	{
		public SdtSDTRetrieveMapBox_retrieves_properties_context_district( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_district_Id = "";

			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_district_Name = "";

		}

		public SdtSDTRetrieveMapBox_retrieves_properties_context_district(IGxContext context)
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


			AddObjectProperty("name", gxTpr_Name, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="id")]
		[XmlElement(ElementName="id")]
		public string gxTpr_Id
		{
			get {
				return gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_district_Id; 
			}
			set {
				gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_district_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="name")]
		[XmlElement(ElementName="name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_district_Name; 
			}
			set {
				gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_district_Name = value;
				SetDirty("Name");
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
			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_district_Id = "";
			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_district_Name = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_district_Id;
		 

		protected string gxTv_SdtSDTRetrieveMapBox_retrieves_properties_context_district_Name;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTRetrieveMapBox.retrieves.properties.context.district", Namespace="AlmangoX")]
	public class SdtSDTRetrieveMapBox_retrieves_properties_context_district_RESTInterface : GxGenericCollectionItem<SdtSDTRetrieveMapBox_retrieves_properties_context_district>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTRetrieveMapBox_retrieves_properties_context_district_RESTInterface( ) : base()
		{	
		}

		public SdtSDTRetrieveMapBox_retrieves_properties_context_district_RESTInterface( SdtSDTRetrieveMapBox_retrieves_properties_context_district psdt ) : base(psdt)
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

		[DataMember(Name="name", Order=1)]
		public  string gxTpr_Name
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Name);

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}


		#endregion
		public SdtSDTRetrieveMapBox_retrieves_properties_context_district sdt
		{
			get { 
				return (SdtSDTRetrieveMapBox_retrieves_properties_context_district)Sdt;
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
				sdt = new SdtSDTRetrieveMapBox_retrieves_properties_context_district() ;
			}
		}
	}
	#endregion
}