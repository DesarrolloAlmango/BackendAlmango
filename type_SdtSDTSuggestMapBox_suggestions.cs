/*
				   File: type_SdtSDTSuggestMapBox_suggestions
			Description: SDTSuggestMapBox
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
	[XmlRoot(ElementName="suggestions")]
	[XmlType(TypeName="suggestions" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTSuggestMapBox_suggestions : GxUserType
	{
		public SdtSDTSuggestMapBox_suggestions( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTSuggestMapBox_suggestions_Name = "";

			gxTv_SdtSDTSuggestMapBox_suggestions_Mapbox_id = "";

			gxTv_SdtSDTSuggestMapBox_suggestions_Feature_type = "";

			gxTv_SdtSDTSuggestMapBox_suggestions_Address = "";

			gxTv_SdtSDTSuggestMapBox_suggestions_Full_address = "";

			gxTv_SdtSDTSuggestMapBox_suggestions_Place_formatted = "";

			gxTv_SdtSDTSuggestMapBox_suggestions_Language = "";

			gxTv_SdtSDTSuggestMapBox_suggestions_Maki = "";

			gxTv_SdtSDTSuggestMapBox_suggestions_Distance = "";

		}

		public SdtSDTSuggestMapBox_suggestions(IGxContext context)
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


			AddObjectProperty("address", gxTpr_Address, false);


			AddObjectProperty("full_address", gxTpr_Full_address, false);


			AddObjectProperty("place_formatted", gxTpr_Place_formatted, false);

			if (gxTv_SdtSDTSuggestMapBox_suggestions_Context != null)
			{
				AddObjectProperty("context", gxTv_SdtSDTSuggestMapBox_suggestions_Context, false);
			}

			AddObjectProperty("language", gxTpr_Language, false);


			AddObjectProperty("maki", gxTpr_Maki, false);

			if (gxTv_SdtSDTSuggestMapBox_suggestions_Metadata != null)
			{
				AddObjectProperty("metadata", gxTv_SdtSDTSuggestMapBox_suggestions_Metadata, false);
			}

			AddObjectProperty("distance", gxTpr_Distance, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="name")]
		[XmlElement(ElementName="name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtSDTSuggestMapBox_suggestions_Name; 
			}
			set {
				gxTv_SdtSDTSuggestMapBox_suggestions_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="mapbox_id")]
		[XmlElement(ElementName="mapbox_id")]
		public string gxTpr_Mapbox_id
		{
			get {
				return gxTv_SdtSDTSuggestMapBox_suggestions_Mapbox_id; 
			}
			set {
				gxTv_SdtSDTSuggestMapBox_suggestions_Mapbox_id = value;
				SetDirty("Mapbox_id");
			}
		}




		[SoapElement(ElementName="feature_type")]
		[XmlElement(ElementName="feature_type")]
		public string gxTpr_Feature_type
		{
			get {
				return gxTv_SdtSDTSuggestMapBox_suggestions_Feature_type; 
			}
			set {
				gxTv_SdtSDTSuggestMapBox_suggestions_Feature_type = value;
				SetDirty("Feature_type");
			}
		}




		[SoapElement(ElementName="address")]
		[XmlElement(ElementName="address")]
		public string gxTpr_Address
		{
			get {
				return gxTv_SdtSDTSuggestMapBox_suggestions_Address; 
			}
			set {
				gxTv_SdtSDTSuggestMapBox_suggestions_Address = value;
				SetDirty("Address");
			}
		}




		[SoapElement(ElementName="full_address")]
		[XmlElement(ElementName="full_address")]
		public string gxTpr_Full_address
		{
			get {
				return gxTv_SdtSDTSuggestMapBox_suggestions_Full_address; 
			}
			set {
				gxTv_SdtSDTSuggestMapBox_suggestions_Full_address = value;
				SetDirty("Full_address");
			}
		}




		[SoapElement(ElementName="place_formatted")]
		[XmlElement(ElementName="place_formatted")]
		public string gxTpr_Place_formatted
		{
			get {
				return gxTv_SdtSDTSuggestMapBox_suggestions_Place_formatted; 
			}
			set {
				gxTv_SdtSDTSuggestMapBox_suggestions_Place_formatted = value;
				SetDirty("Place_formatted");
			}
		}



		[SoapElement(ElementName="context" )]
		[XmlElement(ElementName="context" )]
		public SdtSDTSuggestMapBox_suggestions_context gxTpr_Context
		{
			get {
				if ( gxTv_SdtSDTSuggestMapBox_suggestions_Context == null )
				{
					gxTv_SdtSDTSuggestMapBox_suggestions_Context = new SdtSDTSuggestMapBox_suggestions_context(context);
				}
				gxTv_SdtSDTSuggestMapBox_suggestions_Context_N = false;
				SetDirty("Context");
				return gxTv_SdtSDTSuggestMapBox_suggestions_Context;
			}
			set {
				gxTv_SdtSDTSuggestMapBox_suggestions_Context_N = false;
				gxTv_SdtSDTSuggestMapBox_suggestions_Context = value;
				SetDirty("Context");
			}

		}

		public void gxTv_SdtSDTSuggestMapBox_suggestions_Context_SetNull()
		{
			gxTv_SdtSDTSuggestMapBox_suggestions_Context_N = true;
			gxTv_SdtSDTSuggestMapBox_suggestions_Context = null;
		}

		public bool gxTv_SdtSDTSuggestMapBox_suggestions_Context_IsNull()
		{
			return gxTv_SdtSDTSuggestMapBox_suggestions_Context == null;
		}
		public bool ShouldSerializegxTpr_Context_Json()
		{
				return (gxTv_SdtSDTSuggestMapBox_suggestions_Context != null && gxTv_SdtSDTSuggestMapBox_suggestions_Context.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="language")]
		[XmlElement(ElementName="language")]
		public string gxTpr_Language
		{
			get {
				return gxTv_SdtSDTSuggestMapBox_suggestions_Language; 
			}
			set {
				gxTv_SdtSDTSuggestMapBox_suggestions_Language = value;
				SetDirty("Language");
			}
		}




		[SoapElement(ElementName="maki")]
		[XmlElement(ElementName="maki")]
		public string gxTpr_Maki
		{
			get {
				return gxTv_SdtSDTSuggestMapBox_suggestions_Maki; 
			}
			set {
				gxTv_SdtSDTSuggestMapBox_suggestions_Maki = value;
				SetDirty("Maki");
			}
		}



		[SoapElement(ElementName="metadata" )]
		[XmlElement(ElementName="metadata" )]
		public SdtSDTSuggestMapBox_suggestions_metadata gxTpr_Metadata
		{
			get {
				if ( gxTv_SdtSDTSuggestMapBox_suggestions_Metadata == null )
				{
					gxTv_SdtSDTSuggestMapBox_suggestions_Metadata = new SdtSDTSuggestMapBox_suggestions_metadata(context);
				}
				gxTv_SdtSDTSuggestMapBox_suggestions_Metadata_N = false;
				SetDirty("Metadata");
				return gxTv_SdtSDTSuggestMapBox_suggestions_Metadata;
			}
			set {
				gxTv_SdtSDTSuggestMapBox_suggestions_Metadata_N = false;
				gxTv_SdtSDTSuggestMapBox_suggestions_Metadata = value;
				SetDirty("Metadata");
			}

		}

		public void gxTv_SdtSDTSuggestMapBox_suggestions_Metadata_SetNull()
		{
			gxTv_SdtSDTSuggestMapBox_suggestions_Metadata_N = true;
			gxTv_SdtSDTSuggestMapBox_suggestions_Metadata = null;
		}

		public bool gxTv_SdtSDTSuggestMapBox_suggestions_Metadata_IsNull()
		{
			return gxTv_SdtSDTSuggestMapBox_suggestions_Metadata == null;
		}
		public bool ShouldSerializegxTpr_Metadata_Json()
		{
				return (gxTv_SdtSDTSuggestMapBox_suggestions_Metadata != null && gxTv_SdtSDTSuggestMapBox_suggestions_Metadata.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="distance")]
		[XmlElement(ElementName="distance")]
		public string gxTpr_Distance
		{
			get {
				return gxTv_SdtSDTSuggestMapBox_suggestions_Distance; 
			}
			set {
				gxTv_SdtSDTSuggestMapBox_suggestions_Distance = value;
				SetDirty("Distance");
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
			gxTv_SdtSDTSuggestMapBox_suggestions_Name = "";
			gxTv_SdtSDTSuggestMapBox_suggestions_Mapbox_id = "";
			gxTv_SdtSDTSuggestMapBox_suggestions_Feature_type = "";
			gxTv_SdtSDTSuggestMapBox_suggestions_Address = "";
			gxTv_SdtSDTSuggestMapBox_suggestions_Full_address = "";
			gxTv_SdtSDTSuggestMapBox_suggestions_Place_formatted = "";

			gxTv_SdtSDTSuggestMapBox_suggestions_Context_N = true;

			gxTv_SdtSDTSuggestMapBox_suggestions_Language = "";
			gxTv_SdtSDTSuggestMapBox_suggestions_Maki = "";

			gxTv_SdtSDTSuggestMapBox_suggestions_Metadata_N = true;

			gxTv_SdtSDTSuggestMapBox_suggestions_Distance = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTSuggestMapBox_suggestions_Name;
		 

		protected string gxTv_SdtSDTSuggestMapBox_suggestions_Mapbox_id;
		 

		protected string gxTv_SdtSDTSuggestMapBox_suggestions_Feature_type;
		 

		protected string gxTv_SdtSDTSuggestMapBox_suggestions_Address;
		 

		protected string gxTv_SdtSDTSuggestMapBox_suggestions_Full_address;
		 

		protected string gxTv_SdtSDTSuggestMapBox_suggestions_Place_formatted;
		 
		protected bool gxTv_SdtSDTSuggestMapBox_suggestions_Context_N;
		protected SdtSDTSuggestMapBox_suggestions_context gxTv_SdtSDTSuggestMapBox_suggestions_Context = null; 


		protected string gxTv_SdtSDTSuggestMapBox_suggestions_Language;
		 

		protected string gxTv_SdtSDTSuggestMapBox_suggestions_Maki;
		 
		protected bool gxTv_SdtSDTSuggestMapBox_suggestions_Metadata_N;
		protected SdtSDTSuggestMapBox_suggestions_metadata gxTv_SdtSDTSuggestMapBox_suggestions_Metadata = null; 


		protected string gxTv_SdtSDTSuggestMapBox_suggestions_Distance;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"suggestions", Namespace="AlmangoX")]
	public class SdtSDTSuggestMapBox_suggestions_RESTInterface : GxGenericCollectionItem<SdtSDTSuggestMapBox_suggestions>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTSuggestMapBox_suggestions_RESTInterface( ) : base()
		{	
		}

		public SdtSDTSuggestMapBox_suggestions_RESTInterface( SdtSDTSuggestMapBox_suggestions psdt ) : base(psdt)
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

		[DataMember(Name="address", Order=3)]
		public  string gxTpr_Address
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Address);

			}
			set { 
				 sdt.gxTpr_Address = value;
			}
		}

		[DataMember(Name="full_address", Order=4)]
		public  string gxTpr_Full_address
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Full_address);

			}
			set { 
				 sdt.gxTpr_Full_address = value;
			}
		}

		[DataMember(Name="place_formatted", Order=5)]
		public  string gxTpr_Place_formatted
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Place_formatted);

			}
			set { 
				 sdt.gxTpr_Place_formatted = value;
			}
		}

		[DataMember(Name="context", Order=6, EmitDefaultValue=false)]
		public SdtSDTSuggestMapBox_suggestions_context_RESTInterface gxTpr_Context
		{
			get {
				if (sdt.ShouldSerializegxTpr_Context_Json())
					return new SdtSDTSuggestMapBox_suggestions_context_RESTInterface(sdt.gxTpr_Context);
				else
					return null;

			}

			set {
				sdt.gxTpr_Context = value.sdt;
			}

		}

		[DataMember(Name="language", Order=7)]
		public  string gxTpr_Language
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Language);

			}
			set { 
				 sdt.gxTpr_Language = value;
			}
		}

		[DataMember(Name="maki", Order=8)]
		public  string gxTpr_Maki
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Maki);

			}
			set { 
				 sdt.gxTpr_Maki = value;
			}
		}

		[DataMember(Name="metadata", Order=9, EmitDefaultValue=false)]
		public SdtSDTSuggestMapBox_suggestions_metadata_RESTInterface gxTpr_Metadata
		{
			get {
				if (sdt.ShouldSerializegxTpr_Metadata_Json())
					return new SdtSDTSuggestMapBox_suggestions_metadata_RESTInterface(sdt.gxTpr_Metadata);
				else
					return null;

			}

			set {
				sdt.gxTpr_Metadata = value.sdt;
			}

		}

		[DataMember(Name="distance", Order=10)]
		public  string gxTpr_Distance
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Distance);

			}
			set { 
				 sdt.gxTpr_Distance = value;
			}
		}


		#endregion
		public SdtSDTSuggestMapBox_suggestions sdt
		{
			get { 
				return (SdtSDTSuggestMapBox_suggestions)Sdt;
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
				sdt = new SdtSDTSuggestMapBox_suggestions() ;
			}
		}
	}
	#endregion
}