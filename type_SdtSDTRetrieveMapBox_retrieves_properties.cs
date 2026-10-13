/*
				   File: type_SdtSDTRetrieveMapBox_retrieves_properties
			Description: properties
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
	[XmlRoot(ElementName="SDTRetrieveMapBox.retrieves.properties")]
	[XmlType(TypeName="SDTRetrieveMapBox.retrieves.properties" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTRetrieveMapBox_retrieves_properties : GxUserType
	{
		public SdtSDTRetrieveMapBox_retrieves_properties( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Name = "";

			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Mapbox_id = "";

			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Feature_type = "";

		}

		public SdtSDTRetrieveMapBox_retrieves_properties(IGxContext context)
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
			AddObjectProperty("name", gxTpr_Name, false);


			AddObjectProperty("mapbox_id", gxTpr_Mapbox_id, false);


			AddObjectProperty("feature_type", gxTpr_Feature_type, false);

			if (gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Context != null)
			{
				AddObjectProperty("context", gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Context, false);
			}
			if (gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Coordinates != null)
			{
				AddObjectProperty("coordinates", gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Coordinates, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="name")]
		[XmlElement(ElementName="name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Name; 
			}
			set {
				gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="mapbox_id")]
		[XmlElement(ElementName="mapbox_id")]
		public string gxTpr_Mapbox_id
		{
			get {
				return gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Mapbox_id; 
			}
			set {
				gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Mapbox_id = value;
				SetDirty("Mapbox_id");
			}
		}




		[SoapElement(ElementName="feature_type")]
		[XmlElement(ElementName="feature_type")]
		public string gxTpr_Feature_type
		{
			get {
				return gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Feature_type; 
			}
			set {
				gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Feature_type = value;
				SetDirty("Feature_type");
			}
		}



		[SoapElement(ElementName="context" )]
		[XmlElement(ElementName="context" )]
		public SdtSDTRetrieveMapBox_retrieves_properties_context gxTpr_Context
		{
			get {
				if ( gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Context == null )
				{
					gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Context = new SdtSDTRetrieveMapBox_retrieves_properties_context(context);
				}
				gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Context_N = false;
				SetDirty("Context");
				return gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Context;
			}
			set {
				gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Context_N = false;
				gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Context = value;
				SetDirty("Context");
			}

		}

		public void gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Context_SetNull()
		{
			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Context_N = true;
			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Context = null;
		}

		public bool gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Context_IsNull()
		{
			return gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Context == null;
		}
		public bool ShouldSerializegxTpr_Context_Json()
		{
				return (gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Context != null && gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Context.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="coordinates" )]
		[XmlElement(ElementName="coordinates" )]
		public SdtSDTRetrieveMapBox_retrieves_properties_coordinates gxTpr_Coordinates
		{
			get {
				if ( gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Coordinates == null )
				{
					gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Coordinates = new SdtSDTRetrieveMapBox_retrieves_properties_coordinates(context);
				}
				gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Coordinates_N = false;
				SetDirty("Coordinates");
				return gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Coordinates;
			}
			set {
				gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Coordinates_N = false;
				gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Coordinates = value;
				SetDirty("Coordinates");
			}

		}

		public void gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Coordinates_SetNull()
		{
			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Coordinates_N = true;
			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Coordinates = null;
		}

		public bool gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Coordinates_IsNull()
		{
			return gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Coordinates == null;
		}
		public bool ShouldSerializegxTpr_Coordinates_Json()
		{
				return (gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Coordinates != null && gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Coordinates.ShouldSerializeSdtJson());

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
			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Name = "";
			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Mapbox_id = "";
			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Feature_type = "";

			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Context_N = true;


			gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Coordinates_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Name;
		 

		protected string gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Mapbox_id;
		 

		protected string gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Feature_type;
		 
		protected bool gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Context_N;
		protected SdtSDTRetrieveMapBox_retrieves_properties_context gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Context = null; 

		protected bool gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Coordinates_N;
		protected SdtSDTRetrieveMapBox_retrieves_properties_coordinates gxTv_SdtSDTRetrieveMapBox_retrieves_properties_Coordinates = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTRetrieveMapBox.retrieves.properties", Namespace="AlmangoX")]
	public class SdtSDTRetrieveMapBox_retrieves_properties_RESTInterface : GxGenericCollectionItem<SdtSDTRetrieveMapBox_retrieves_properties>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTRetrieveMapBox_retrieves_properties_RESTInterface( ) : base()
		{	
		}

		public SdtSDTRetrieveMapBox_retrieves_properties_RESTInterface( SdtSDTRetrieveMapBox_retrieves_properties psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="name", Order=0)]
		public  string gxTpr_Name
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Name);

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="mapbox_id", Order=1)]
		public  string gxTpr_Mapbox_id
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mapbox_id);

			}
			set { 
				 sdt.gxTpr_Mapbox_id = value;
			}
		}

		[DataMember(Name="feature_type", Order=2)]
		public  string gxTpr_Feature_type
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Feature_type);

			}
			set { 
				 sdt.gxTpr_Feature_type = value;
			}
		}

		[DataMember(Name="context", Order=3, EmitDefaultValue=false)]
		public SdtSDTRetrieveMapBox_retrieves_properties_context_RESTInterface gxTpr_Context
		{
			get {
				if (sdt.ShouldSerializegxTpr_Context_Json())
					return new SdtSDTRetrieveMapBox_retrieves_properties_context_RESTInterface(sdt.gxTpr_Context);
				else
					return null;

			}

			set {
				sdt.gxTpr_Context = value.sdt;
			}

		}

		[DataMember(Name="coordinates", Order=4, EmitDefaultValue=false)]
		public SdtSDTRetrieveMapBox_retrieves_properties_coordinates_RESTInterface gxTpr_Coordinates
		{
			get {
				if (sdt.ShouldSerializegxTpr_Coordinates_Json())
					return new SdtSDTRetrieveMapBox_retrieves_properties_coordinates_RESTInterface(sdt.gxTpr_Coordinates);
				else
					return null;

			}

			set {
				sdt.gxTpr_Coordinates = value.sdt;
			}

		}


		#endregion
		public SdtSDTRetrieveMapBox_retrieves_properties sdt
		{
			get { 
				return (SdtSDTRetrieveMapBox_retrieves_properties)Sdt;
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
				sdt = new SdtSDTRetrieveMapBox_retrieves_properties() ;
			}
		}
	}
	#endregion
}