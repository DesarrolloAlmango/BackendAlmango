/*
				   File: type_SdtSDTRetrieveMapBox_retrieves
			Description: SDTRetrieveMapBox
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
	[XmlRoot(ElementName="retrieves")]
	[XmlType(TypeName="retrieves" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTRetrieveMapBox_retrieves : GxUserType
	{
		public SdtSDTRetrieveMapBox_retrieves( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTRetrieveMapBox_retrieves_Type = "";

		}

		public SdtSDTRetrieveMapBox_retrieves(IGxContext context)
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
			AddObjectProperty("type", gxTpr_Type, false);

			if (gxTv_SdtSDTRetrieveMapBox_retrieves_Geometry != null)
			{
				AddObjectProperty("geometry", gxTv_SdtSDTRetrieveMapBox_retrieves_Geometry, false);
			}
			if (gxTv_SdtSDTRetrieveMapBox_retrieves_Properties != null)
			{
				AddObjectProperty("properties", gxTv_SdtSDTRetrieveMapBox_retrieves_Properties, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="type")]
		[XmlElement(ElementName="type")]
		public string gxTpr_Type
		{
			get {
				return gxTv_SdtSDTRetrieveMapBox_retrieves_Type; 
			}
			set {
				gxTv_SdtSDTRetrieveMapBox_retrieves_Type = value;
				SetDirty("Type");
			}
		}



		[SoapElement(ElementName="geometry" )]
		[XmlElement(ElementName="geometry" )]
		public SdtSDTRetrieveMapBox_retrieves_geometry gxTpr_Geometry
		{
			get {
				if ( gxTv_SdtSDTRetrieveMapBox_retrieves_Geometry == null )
				{
					gxTv_SdtSDTRetrieveMapBox_retrieves_Geometry = new SdtSDTRetrieveMapBox_retrieves_geometry(context);
				}
				gxTv_SdtSDTRetrieveMapBox_retrieves_Geometry_N = false;
				SetDirty("Geometry");
				return gxTv_SdtSDTRetrieveMapBox_retrieves_Geometry;
			}
			set {
				gxTv_SdtSDTRetrieveMapBox_retrieves_Geometry_N = false;
				gxTv_SdtSDTRetrieveMapBox_retrieves_Geometry = value;
				SetDirty("Geometry");
			}

		}

		public void gxTv_SdtSDTRetrieveMapBox_retrieves_Geometry_SetNull()
		{
			gxTv_SdtSDTRetrieveMapBox_retrieves_Geometry_N = true;
			gxTv_SdtSDTRetrieveMapBox_retrieves_Geometry = null;
		}

		public bool gxTv_SdtSDTRetrieveMapBox_retrieves_Geometry_IsNull()
		{
			return gxTv_SdtSDTRetrieveMapBox_retrieves_Geometry == null;
		}
		public bool ShouldSerializegxTpr_Geometry_Json()
		{
				return (gxTv_SdtSDTRetrieveMapBox_retrieves_Geometry != null && gxTv_SdtSDTRetrieveMapBox_retrieves_Geometry.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="properties" )]
		[XmlElement(ElementName="properties" )]
		public SdtSDTRetrieveMapBox_retrieves_properties gxTpr_Properties
		{
			get {
				if ( gxTv_SdtSDTRetrieveMapBox_retrieves_Properties == null )
				{
					gxTv_SdtSDTRetrieveMapBox_retrieves_Properties = new SdtSDTRetrieveMapBox_retrieves_properties(context);
				}
				gxTv_SdtSDTRetrieveMapBox_retrieves_Properties_N = false;
				SetDirty("Properties");
				return gxTv_SdtSDTRetrieveMapBox_retrieves_Properties;
			}
			set {
				gxTv_SdtSDTRetrieveMapBox_retrieves_Properties_N = false;
				gxTv_SdtSDTRetrieveMapBox_retrieves_Properties = value;
				SetDirty("Properties");
			}

		}

		public void gxTv_SdtSDTRetrieveMapBox_retrieves_Properties_SetNull()
		{
			gxTv_SdtSDTRetrieveMapBox_retrieves_Properties_N = true;
			gxTv_SdtSDTRetrieveMapBox_retrieves_Properties = null;
		}

		public bool gxTv_SdtSDTRetrieveMapBox_retrieves_Properties_IsNull()
		{
			return gxTv_SdtSDTRetrieveMapBox_retrieves_Properties == null;
		}
		public bool ShouldSerializegxTpr_Properties_Json()
		{
				return (gxTv_SdtSDTRetrieveMapBox_retrieves_Properties != null && gxTv_SdtSDTRetrieveMapBox_retrieves_Properties.ShouldSerializeSdtJson());

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
			gxTv_SdtSDTRetrieveMapBox_retrieves_Type = "";

			gxTv_SdtSDTRetrieveMapBox_retrieves_Geometry_N = true;


			gxTv_SdtSDTRetrieveMapBox_retrieves_Properties_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTRetrieveMapBox_retrieves_Type;
		 
		protected bool gxTv_SdtSDTRetrieveMapBox_retrieves_Geometry_N;
		protected SdtSDTRetrieveMapBox_retrieves_geometry gxTv_SdtSDTRetrieveMapBox_retrieves_Geometry = null; 

		protected bool gxTv_SdtSDTRetrieveMapBox_retrieves_Properties_N;
		protected SdtSDTRetrieveMapBox_retrieves_properties gxTv_SdtSDTRetrieveMapBox_retrieves_Properties = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"retrieves", Namespace="AlmangoX")]
	public class SdtSDTRetrieveMapBox_retrieves_RESTInterface : GxGenericCollectionItem<SdtSDTRetrieveMapBox_retrieves>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTRetrieveMapBox_retrieves_RESTInterface( ) : base()
		{	
		}

		public SdtSDTRetrieveMapBox_retrieves_RESTInterface( SdtSDTRetrieveMapBox_retrieves psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="type", Order=0)]
		public  string gxTpr_Type
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Type);

			}
			set { 
				 sdt.gxTpr_Type = value;
			}
		}

		[DataMember(Name="geometry", Order=1, EmitDefaultValue=false)]
		public SdtSDTRetrieveMapBox_retrieves_geometry_RESTInterface gxTpr_Geometry
		{
			get {
				if (sdt.ShouldSerializegxTpr_Geometry_Json())
					return new SdtSDTRetrieveMapBox_retrieves_geometry_RESTInterface(sdt.gxTpr_Geometry);
				else
					return null;

			}

			set {
				sdt.gxTpr_Geometry = value.sdt;
			}

		}

		[DataMember(Name="properties", Order=2, EmitDefaultValue=false)]
		public SdtSDTRetrieveMapBox_retrieves_properties_RESTInterface gxTpr_Properties
		{
			get {
				if (sdt.ShouldSerializegxTpr_Properties_Json())
					return new SdtSDTRetrieveMapBox_retrieves_properties_RESTInterface(sdt.gxTpr_Properties);
				else
					return null;

			}

			set {
				sdt.gxTpr_Properties = value.sdt;
			}

		}


		#endregion
		public SdtSDTRetrieveMapBox_retrieves sdt
		{
			get { 
				return (SdtSDTRetrieveMapBox_retrieves)Sdt;
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
				sdt = new SdtSDTRetrieveMapBox_retrieves() ;
			}
		}
	}
	#endregion
}