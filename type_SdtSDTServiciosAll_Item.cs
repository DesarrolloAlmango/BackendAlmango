/*
				   File: type_SdtSDTServiciosAll_Item
			Description: SDTServiciosAll
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
	[XmlRoot(ElementName="Item")]
	[XmlType(TypeName="Item" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTServiciosAll_Item : GxUserType
	{
		public SdtSDTServiciosAll_Item( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTServiciosAll_Item_Serviciosnombre = "";

			gxTv_SdtSDTServiciosAll_Item_Imagen = "";
			gxTv_SdtSDTServiciosAll_Item_Imagen_gxi = "";

		}

		public SdtSDTServiciosAll_Item(IGxContext context)
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
			AddObjectProperty("ServiciosId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Serviciosid, 18, 0)), false);


			AddObjectProperty("ServiciosNombre", gxTpr_Serviciosnombre, false);


			AddObjectProperty("Imagen", gxTpr_Imagen, false);
			AddObjectProperty("Imagen_GXI", gxTpr_Imagen_gxi, false);


			if (gxTv_SdtSDTServiciosAll_Item_Producto != null)
			{
				AddObjectProperty("Producto", gxTv_SdtSDTServiciosAll_Item_Producto, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ServiciosId")]
		[XmlElement(ElementName="ServiciosId")]
		public long gxTpr_Serviciosid
		{
			get {
				return gxTv_SdtSDTServiciosAll_Item_Serviciosid; 
			}
			set {
				gxTv_SdtSDTServiciosAll_Item_Serviciosid = value;
				SetDirty("Serviciosid");
			}
		}




		[SoapElement(ElementName="ServiciosNombre")]
		[XmlElement(ElementName="ServiciosNombre")]
		public string gxTpr_Serviciosnombre
		{
			get {
				return gxTv_SdtSDTServiciosAll_Item_Serviciosnombre; 
			}
			set {
				gxTv_SdtSDTServiciosAll_Item_Serviciosnombre = value;
				SetDirty("Serviciosnombre");
			}
		}




		[SoapElement(ElementName="Imagen")]
		[XmlElement(ElementName="Imagen")]
		[GxUpload()]

		public string gxTpr_Imagen
		{
			get {
				return gxTv_SdtSDTServiciosAll_Item_Imagen; 
			}
			set {
				gxTv_SdtSDTServiciosAll_Item_Imagen = value;
				SetDirty("Imagen");
			}
		}


		[SoapElement(ElementName="Imagen_GXI" )]
		[XmlElement(ElementName="Imagen_GXI" )]
		public string gxTpr_Imagen_gxi
		{
			get {
				return gxTv_SdtSDTServiciosAll_Item_Imagen_gxi ;
			}
			set {
				gxTv_SdtSDTServiciosAll_Item_Imagen_gxi = value;
				SetDirty("Imagen_gxi");
			}
		}

		[SoapElement(ElementName="Producto" )]
		[XmlArray(ElementName="Producto"  )]
		[XmlArrayItemAttribute(ElementName="ProductoItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTServiciosAll_Item_ProductoItem> gxTpr_Producto
		{
			get {
				if ( gxTv_SdtSDTServiciosAll_Item_Producto == null )
				{
					gxTv_SdtSDTServiciosAll_Item_Producto = new GXBaseCollection<SdtSDTServiciosAll_Item_ProductoItem>( context, "SDTServiciosAll.Item.ProductoItem", "");
				}
				SetDirty("Producto");
				return gxTv_SdtSDTServiciosAll_Item_Producto;
			}
			set {
				gxTv_SdtSDTServiciosAll_Item_Producto_N = false;
				gxTv_SdtSDTServiciosAll_Item_Producto = value;
				SetDirty("Producto");
			}
		}

		public void gxTv_SdtSDTServiciosAll_Item_Producto_SetNull()
		{
			gxTv_SdtSDTServiciosAll_Item_Producto_N = true;
			gxTv_SdtSDTServiciosAll_Item_Producto = null;
		}

		public bool gxTv_SdtSDTServiciosAll_Item_Producto_IsNull()
		{
			return gxTv_SdtSDTServiciosAll_Item_Producto == null;
		}
		public bool ShouldSerializegxTpr_Producto_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTServiciosAll_Item_Producto != null && gxTv_SdtSDTServiciosAll_Item_Producto.Count > 0;

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
			gxTv_SdtSDTServiciosAll_Item_Serviciosnombre = "";
			gxTv_SdtSDTServiciosAll_Item_Imagen = "";gxTv_SdtSDTServiciosAll_Item_Imagen_gxi = "";

			gxTv_SdtSDTServiciosAll_Item_Producto_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTServiciosAll_Item_Serviciosid;
		 

		protected string gxTv_SdtSDTServiciosAll_Item_Serviciosnombre;
		 
		protected string gxTv_SdtSDTServiciosAll_Item_Imagen_gxi;
		protected string gxTv_SdtSDTServiciosAll_Item_Imagen;
		 
		protected bool gxTv_SdtSDTServiciosAll_Item_Producto_N;
		protected GXBaseCollection<SdtSDTServiciosAll_Item_ProductoItem> gxTv_SdtSDTServiciosAll_Item_Producto = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"Item", Namespace="AlmangoX")]
	public class SdtSDTServiciosAll_Item_RESTInterface : GxGenericCollectionItem<SdtSDTServiciosAll_Item>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTServiciosAll_Item_RESTInterface( ) : base()
		{	
		}

		public SdtSDTServiciosAll_Item_RESTInterface( SdtSDTServiciosAll_Item psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ServiciosId", Order=0)]
		public  string gxTpr_Serviciosid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Serviciosid, 18, 0));

			}
			set { 
				sdt.gxTpr_Serviciosid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ServiciosNombre", Order=1)]
		public  string gxTpr_Serviciosnombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Serviciosnombre);

			}
			set { 
				 sdt.gxTpr_Serviciosnombre = value;
			}
		}

		[DataMember(Name="Imagen", Order=2)]
		[GxUpload()]
		public  string gxTpr_Imagen
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Imagen)) ? PathUtil.RelativePath( sdt.gxTpr_Imagen) : StringUtil.RTrim( sdt.gxTpr_Imagen_gxi));

			}
			set { 
				 sdt.gxTpr_Imagen = value;
			}
		}

		[DataMember(Name="Producto", Order=3, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTServiciosAll_Item_ProductoItem_RESTInterface> gxTpr_Producto
		{
			get {
				if (sdt.ShouldSerializegxTpr_Producto_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTServiciosAll_Item_ProductoItem_RESTInterface>(sdt.gxTpr_Producto);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Producto);
			}
		}


		#endregion
		public SdtSDTServiciosAll_Item sdt
		{
			get { 
				return (SdtSDTServiciosAll_Item)Sdt;
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
				sdt = new SdtSDTServiciosAll_Item() ;
			}
		}
	}
	#endregion
}