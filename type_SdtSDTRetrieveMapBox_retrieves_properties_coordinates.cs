/*
				   File: type_SdtSDTRetrieveMapBox_retrieves_properties_coordinates
			Description: coordinates
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
	[XmlRoot(ElementName="SDTRetrieveMapBox.retrieves.properties.coordinates")]
	[XmlType(TypeName="SDTRetrieveMapBox.retrieves.properties.coordinates" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTRetrieveMapBox_retrieves_properties_coordinates : GxUserType
	{
		public SdtSDTRetrieveMapBox_retrieves_properties_coordinates( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_coordinates_Longitude = "";

			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_coordinates_Latitude = "";

		}

		public SdtSDTRetrieveMapBox_retrieves_properties_coordinates(IGxContext context)
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
			AddObjectProperty("longitude", gxTpr_Longitude, false);


			AddObjectProperty("latitude", gxTpr_Latitude, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="longitude")]
		[XmlElement(ElementName="longitude")]
		public string gxTpr_Longitude
		{
			get {
				return gxTv_SdtSDTRetrieveMapBox_retrieves_properties_coordinates_Longitude; 
			}
			set {
				gxTv_SdtSDTRetrieveMapBox_retrieves_properties_coordinates_Longitude = value;
				SetDirty("Longitude");
			}
		}




		[SoapElement(ElementName="latitude")]
		[XmlElement(ElementName="latitude")]
		public string gxTpr_Latitude
		{
			get {
				return gxTv_SdtSDTRetrieveMapBox_retrieves_properties_coordinates_Latitude; 
			}
			set {
				gxTv_SdtSDTRetrieveMapBox_retrieves_properties_coordinates_Latitude = value;
				SetDirty("Latitude");
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
			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_coordinates_Longitude = "";
			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_coordinates_Latitude = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTRetrieveMapBox_retrieves_properties_coordinates_Longitude;
		 

		protected string gxTv_SdtSDTRetrieveMapBox_retrieves_properties_coordinates_Latitude;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTRetrieveMapBox.retrieves.properties.coordinates", Namespace="AlmangoX")]
	public class SdtSDTRetrieveMapBox_retrieves_properties_coordinates_RESTInterface : GxGenericCollectionItem<SdtSDTRetrieveMapBox_retrieves_properties_coordinates>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTRetrieveMapBox_retrieves_properties_coordinates_RESTInterface( ) : base()
		{	
		}

		public SdtSDTRetrieveMapBox_retrieves_properties_coordinates_RESTInterface( SdtSDTRetrieveMapBox_retrieves_properties_coordinates psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="longitude", Order=0)]
		public  string gxTpr_Longitude
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Longitude);

			}
			set { 
				 sdt.gxTpr_Longitude = value;
			}
		}

		[DataMember(Name="latitude", Order=1)]
		public  string gxTpr_Latitude
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Latitude);

			}
			set { 
				 sdt.gxTpr_Latitude = value;
			}
		}


		#endregion
		public SdtSDTRetrieveMapBox_retrieves_properties_coordinates sdt
		{
			get { 
				return (SdtSDTRetrieveMapBox_retrieves_properties_coordinates)Sdt;
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
				sdt = new SdtSDTRetrieveMapBox_retrieves_properties_coordinates() ;
			}
		}
	}
	#endregion
}