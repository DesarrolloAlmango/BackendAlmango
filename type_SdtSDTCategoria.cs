/*
				   File: type_SdtSDTCategoria
			Description: SDTCategoria
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
	[XmlRoot(ElementName="SDTCategoria")]
	[XmlType(TypeName="SDTCategoria" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTCategoria : GxUserType
	{
		public SdtSDTCategoria( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTCategoria_Categorianombre = "";

		}

		public SdtSDTCategoria(IGxContext context)
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
			AddObjectProperty("CategoriaId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Categoriaid, 18, 0)), false);


			AddObjectProperty("CategoriaNombre", gxTpr_Categorianombre, false);

			if (gxTv_SdtSDTCategoria_Productos != null)
			{
				AddObjectProperty("Productos", gxTv_SdtSDTCategoria_Productos, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CategoriaId")]
		[XmlElement(ElementName="CategoriaId")]
		public long gxTpr_Categoriaid
		{
			get {
				return gxTv_SdtSDTCategoria_Categoriaid; 
			}
			set {
				gxTv_SdtSDTCategoria_Categoriaid = value;
				SetDirty("Categoriaid");
			}
		}




		[SoapElement(ElementName="CategoriaNombre")]
		[XmlElement(ElementName="CategoriaNombre")]
		public string gxTpr_Categorianombre
		{
			get {
				return gxTv_SdtSDTCategoria_Categorianombre; 
			}
			set {
				gxTv_SdtSDTCategoria_Categorianombre = value;
				SetDirty("Categorianombre");
			}
		}




		[SoapElement(ElementName="Productos" )]
		[XmlArray(ElementName="Productos"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtSDTProducto> gxTpr_Productos_GXBaseCollection
		{
			get {
				if ( gxTv_SdtSDTCategoria_Productos == null )
				{
					gxTv_SdtSDTCategoria_Productos = new GXBaseCollection<GeneXus.Programs.SdtSDTProducto>( context, "SDTProducto", "");
				}
				return gxTv_SdtSDTCategoria_Productos;
			}
			set {
				gxTv_SdtSDTCategoria_Productos_N = false;
				gxTv_SdtSDTCategoria_Productos = value;
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtSDTProducto> gxTpr_Productos
		{
			get {
				if ( gxTv_SdtSDTCategoria_Productos == null )
				{
					gxTv_SdtSDTCategoria_Productos = new GXBaseCollection<GeneXus.Programs.SdtSDTProducto>( context, "SDTProducto", "");
				}
				gxTv_SdtSDTCategoria_Productos_N = false;
				SetDirty("Productos");
				return gxTv_SdtSDTCategoria_Productos ;
			}
			set {
				gxTv_SdtSDTCategoria_Productos_N = false;
				gxTv_SdtSDTCategoria_Productos = value;
				SetDirty("Productos");
			}
		}

		public void gxTv_SdtSDTCategoria_Productos_SetNull()
		{
			gxTv_SdtSDTCategoria_Productos_N = true;
			gxTv_SdtSDTCategoria_Productos = null;
		}

		public bool gxTv_SdtSDTCategoria_Productos_IsNull()
		{
			return gxTv_SdtSDTCategoria_Productos == null;
		}
		public bool ShouldSerializegxTpr_Productos_GXBaseCollection_Json()
		{
			return gxTv_SdtSDTCategoria_Productos != null && gxTv_SdtSDTCategoria_Productos.Count > 0;

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
			gxTv_SdtSDTCategoria_Categorianombre = "";

			gxTv_SdtSDTCategoria_Productos_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTCategoria_Categoriaid;
		 

		protected string gxTv_SdtSDTCategoria_Categorianombre;
		 
		protected bool gxTv_SdtSDTCategoria_Productos_N;
		protected GXBaseCollection<GeneXus.Programs.SdtSDTProducto> gxTv_SdtSDTCategoria_Productos = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTCategoria", Namespace="AlmangoX")]
	public class SdtSDTCategoria_RESTInterface : GxGenericCollectionItem<SdtSDTCategoria>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTCategoria_RESTInterface( ) : base()
		{	
		}

		public SdtSDTCategoria_RESTInterface( SdtSDTCategoria psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="CategoriaId", Order=0)]
		public  string gxTpr_Categoriaid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Categoriaid, 18, 0));

			}
			set { 
				sdt.gxTpr_Categoriaid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="CategoriaNombre", Order=1)]
		public  string gxTpr_Categorianombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Categorianombre);

			}
			set { 
				 sdt.gxTpr_Categorianombre = value;
			}
		}

		[DataMember(Name="Productos", Order=2, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtSDTProducto_RESTInterface> gxTpr_Productos
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Productos_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtSDTProducto_RESTInterface>(sdt.gxTpr_Productos);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Productos);
			}
		}


		#endregion
		public SdtSDTCategoria sdt
		{
			get { 
				return (SdtSDTCategoria)Sdt;
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
				sdt = new SdtSDTCategoria() ;
			}
		}
	}
	#endregion
}