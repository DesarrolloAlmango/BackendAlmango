/*
				   File: type_SdtSDTRubro
			Description: SDTRubro
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
	[XmlRoot(ElementName="SDTRubro")]
	[XmlType(TypeName="SDTRubro" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTRubro : GxUserType
	{
		public SdtSDTRubro( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTRubro_Rubronombre = "";

		}

		public SdtSDTRubro(IGxContext context)
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
			AddObjectProperty("RubroId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Rubroid, 18, 0)), false);


			AddObjectProperty("RubroNombre", gxTpr_Rubronombre, false);

			if (gxTv_SdtSDTRubro_Categorias != null)
			{
				AddObjectProperty("Categorias", gxTv_SdtSDTRubro_Categorias, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="RubroId")]
		[XmlElement(ElementName="RubroId")]
		public long gxTpr_Rubroid
		{
			get {
				return gxTv_SdtSDTRubro_Rubroid; 
			}
			set {
				gxTv_SdtSDTRubro_Rubroid = value;
				SetDirty("Rubroid");
			}
		}




		[SoapElement(ElementName="RubroNombre")]
		[XmlElement(ElementName="RubroNombre")]
		public string gxTpr_Rubronombre
		{
			get {
				return gxTv_SdtSDTRubro_Rubronombre; 
			}
			set {
				gxTv_SdtSDTRubro_Rubronombre = value;
				SetDirty("Rubronombre");
			}
		}




		[SoapElement(ElementName="Categorias" )]
		[XmlArray(ElementName="Categorias"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtSDTCategoria> gxTpr_Categorias_GXBaseCollection
		{
			get {
				if ( gxTv_SdtSDTRubro_Categorias == null )
				{
					gxTv_SdtSDTRubro_Categorias = new GXBaseCollection<GeneXus.Programs.SdtSDTCategoria>( context, "SDTCategoria", "");
				}
				return gxTv_SdtSDTRubro_Categorias;
			}
			set {
				gxTv_SdtSDTRubro_Categorias_N = false;
				gxTv_SdtSDTRubro_Categorias = value;
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtSDTCategoria> gxTpr_Categorias
		{
			get {
				if ( gxTv_SdtSDTRubro_Categorias == null )
				{
					gxTv_SdtSDTRubro_Categorias = new GXBaseCollection<GeneXus.Programs.SdtSDTCategoria>( context, "SDTCategoria", "");
				}
				gxTv_SdtSDTRubro_Categorias_N = false;
				SetDirty("Categorias");
				return gxTv_SdtSDTRubro_Categorias ;
			}
			set {
				gxTv_SdtSDTRubro_Categorias_N = false;
				gxTv_SdtSDTRubro_Categorias = value;
				SetDirty("Categorias");
			}
		}

		public void gxTv_SdtSDTRubro_Categorias_SetNull()
		{
			gxTv_SdtSDTRubro_Categorias_N = true;
			gxTv_SdtSDTRubro_Categorias = null;
		}

		public bool gxTv_SdtSDTRubro_Categorias_IsNull()
		{
			return gxTv_SdtSDTRubro_Categorias == null;
		}
		public bool ShouldSerializegxTpr_Categorias_GXBaseCollection_Json()
		{
			return gxTv_SdtSDTRubro_Categorias != null && gxTv_SdtSDTRubro_Categorias.Count > 0;

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
			gxTv_SdtSDTRubro_Rubronombre = "";

			gxTv_SdtSDTRubro_Categorias_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTRubro_Rubroid;
		 

		protected string gxTv_SdtSDTRubro_Rubronombre;
		 
		protected bool gxTv_SdtSDTRubro_Categorias_N;
		protected GXBaseCollection<GeneXus.Programs.SdtSDTCategoria> gxTv_SdtSDTRubro_Categorias = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTRubro", Namespace="AlmangoX")]
	public class SdtSDTRubro_RESTInterface : GxGenericCollectionItem<SdtSDTRubro>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTRubro_RESTInterface( ) : base()
		{	
		}

		public SdtSDTRubro_RESTInterface( SdtSDTRubro psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="RubroId", Order=0)]
		public  string gxTpr_Rubroid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Rubroid, 18, 0));

			}
			set { 
				sdt.gxTpr_Rubroid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="RubroNombre", Order=1)]
		public  string gxTpr_Rubronombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Rubronombre);

			}
			set { 
				 sdt.gxTpr_Rubronombre = value;
			}
		}

		[DataMember(Name="Categorias", Order=2, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtSDTCategoria_RESTInterface> gxTpr_Categorias
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Categorias_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtSDTCategoria_RESTInterface>(sdt.gxTpr_Categorias);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Categorias);
			}
		}


		#endregion
		public SdtSDTRubro sdt
		{
			get { 
				return (SdtSDTRubro)Sdt;
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
				sdt = new SdtSDTRubro() ;
			}
		}
	}
	#endregion
}