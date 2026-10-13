/*
				   File: type_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem
			Description: Detalles
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
	[XmlRoot(ElementName="SDTServiciosAll.Item.ProductoItem.DetallesItem")]
	[XmlType(TypeName="SDTServiciosAll.Item.ProductoItem.DetallesItem" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTServiciosAll_Item_ProductoItem_DetallesItem : GxUserType
	{
		public SdtSDTServiciosAll_Item_ProductoItem_DetallesItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Detallenombre = "";

			gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Imagen = "";
			gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Imagen_gxi = "";

			gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Monedaiso = "";

			gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Sr = "";

			gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Tipocomision = "";


		}

		public SdtSDTServiciosAll_Item_ProductoItem_DetallesItem(IGxContext context)
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
			AddObjectProperty("DetalleID", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Detalleid, 18, 0)), false);


			AddObjectProperty("DetalleNombre", gxTpr_Detallenombre, false);


			AddObjectProperty("Imagen", gxTpr_Imagen, false);
			AddObjectProperty("Imagen_GXI", gxTpr_Imagen_gxi, false);



			AddObjectProperty("MonedaId", gxTpr_Monedaid, false);


			AddObjectProperty("MonedaISO", gxTpr_Monedaiso, false);


			AddObjectProperty("Precio", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Precio, 18, 2)), false);


			AddObjectProperty("Comision", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Comision, 18, 2)), false);


			AddObjectProperty("SR", gxTpr_Sr, false);


			AddObjectProperty("TipoComision", gxTpr_Tipocomision, false);


			AddObjectProperty("PrecioFinal", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Preciofinal, 18, 2)), false);


			AddObjectProperty("TerminosId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Terminosid, 18, 0)), false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="DetalleID")]
		[XmlElement(ElementName="DetalleID")]
		public long gxTpr_Detalleid
		{
			get {
				return gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Detalleid; 
			}
			set {
				gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Detalleid = value;
				SetDirty("Detalleid");
			}
		}




		[SoapElement(ElementName="DetalleNombre")]
		[XmlElement(ElementName="DetalleNombre")]
		public string gxTpr_Detallenombre
		{
			get {
				return gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Detallenombre; 
			}
			set {
				gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Detallenombre = value;
				SetDirty("Detallenombre");
			}
		}




		[SoapElement(ElementName="Imagen")]
		[XmlElement(ElementName="Imagen")]
		[GxUpload()]

		public string gxTpr_Imagen
		{
			get {
				return gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Imagen; 
			}
			set {
				gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Imagen = value;
				SetDirty("Imagen");
			}
		}


		[SoapElement(ElementName="Imagen_GXI" )]
		[XmlElement(ElementName="Imagen_GXI" )]
		public string gxTpr_Imagen_gxi
		{
			get {
				return gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Imagen_gxi ;
			}
			set {
				gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Imagen_gxi = value;
				SetDirty("Imagen_gxi");
			}
		}

		[SoapElement(ElementName="MonedaId")]
		[XmlElement(ElementName="MonedaId")]
		public short gxTpr_Monedaid
		{
			get {
				return gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Monedaid; 
			}
			set {
				gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Monedaid = value;
				SetDirty("Monedaid");
			}
		}




		[SoapElement(ElementName="MonedaISO")]
		[XmlElement(ElementName="MonedaISO")]
		public string gxTpr_Monedaiso
		{
			get {
				return gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Monedaiso; 
			}
			set {
				gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Monedaiso = value;
				SetDirty("Monedaiso");
			}
		}



		[SoapElement(ElementName="Precio")]
		[XmlElement(ElementName="Precio")]
		public string gxTpr_Precio_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Precio, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Precio = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Precio
		{
			get {
				return gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Precio; 
			}
			set {
				gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Precio = value;
				SetDirty("Precio");
			}
		}



		[SoapElement(ElementName="Comision")]
		[XmlElement(ElementName="Comision")]
		public string gxTpr_Comision_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Comision, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Comision = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Comision
		{
			get {
				return gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Comision; 
			}
			set {
				gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Comision = value;
				SetDirty("Comision");
			}
		}




		[SoapElement(ElementName="SR")]
		[XmlElement(ElementName="SR")]
		public string gxTpr_Sr
		{
			get {
				return gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Sr; 
			}
			set {
				gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Sr = value;
				SetDirty("Sr");
			}
		}




		[SoapElement(ElementName="TipoComision")]
		[XmlElement(ElementName="TipoComision")]
		public string gxTpr_Tipocomision
		{
			get {
				return gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Tipocomision; 
			}
			set {
				gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Tipocomision = value;
				SetDirty("Tipocomision");
			}
		}



		[SoapElement(ElementName="PrecioFinal")]
		[XmlElement(ElementName="PrecioFinal")]
		public string gxTpr_Preciofinal_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Preciofinal, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Preciofinal = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Preciofinal
		{
			get {
				return gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Preciofinal; 
			}
			set {
				gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Preciofinal = value;
				SetDirty("Preciofinal");
			}
		}




		[SoapElement(ElementName="TerminosId")]
		[XmlElement(ElementName="TerminosId")]
		public long gxTpr_Terminosid
		{
			get {
				return gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Terminosid; 
			}
			set {
				gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Terminosid = value;
				SetDirty("Terminosid");
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
			gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Detallenombre = "";
			gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Imagen = "";gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Imagen_gxi = "";

			gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Monedaiso = "";


			gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Sr = "";
			gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Tipocomision = "";


			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Detalleid;
		 

		protected string gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Detallenombre;
		 
		protected string gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Imagen_gxi;
		protected string gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Imagen;
		 

		protected short gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Monedaid;
		 

		protected string gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Monedaiso;
		 

		protected decimal gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Precio;
		 

		protected decimal gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Comision;
		 

		protected string gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Sr;
		 

		protected string gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Tipocomision;
		 

		protected decimal gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Preciofinal;
		 

		protected long gxTv_SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_Terminosid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDTServiciosAll.Item.ProductoItem.DetallesItem", Namespace="AlmangoX")]
	public class SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_RESTInterface : GxGenericCollectionItem<SdtSDTServiciosAll_Item_ProductoItem_DetallesItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDTServiciosAll_Item_ProductoItem_DetallesItem_RESTInterface( SdtSDTServiciosAll_Item_ProductoItem_DetallesItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="DetalleID", Order=0)]
		public  string gxTpr_Detalleid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Detalleid, 18, 0));

			}
			set { 
				sdt.gxTpr_Detalleid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="DetalleNombre", Order=1)]
		public  string gxTpr_Detallenombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Detallenombre);

			}
			set { 
				 sdt.gxTpr_Detallenombre = value;
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

		[DataMember(Name="MonedaId", Order=3)]
		public short gxTpr_Monedaid
		{
			get { 
				return sdt.gxTpr_Monedaid;

			}
			set { 
				sdt.gxTpr_Monedaid = value;
			}
		}

		[DataMember(Name="MonedaISO", Order=4)]
		public  string gxTpr_Monedaiso
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Monedaiso);

			}
			set { 
				 sdt.gxTpr_Monedaiso = value;
			}
		}

		[DataMember(Name="Precio", Order=5)]
		public  string gxTpr_Precio
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Precio, 18, 2));

			}
			set { 
				sdt.gxTpr_Precio =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Comision", Order=6)]
		public  string gxTpr_Comision
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Comision, 18, 2));

			}
			set { 
				sdt.gxTpr_Comision =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="SR", Order=7)]
		public  string gxTpr_Sr
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Sr);

			}
			set { 
				 sdt.gxTpr_Sr = value;
			}
		}

		[DataMember(Name="TipoComision", Order=8)]
		public  string gxTpr_Tipocomision
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tipocomision);

			}
			set { 
				 sdt.gxTpr_Tipocomision = value;
			}
		}

		[DataMember(Name="PrecioFinal", Order=9)]
		public  string gxTpr_Preciofinal
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Preciofinal, 18, 2));

			}
			set { 
				sdt.gxTpr_Preciofinal =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TerminosId", Order=10)]
		public  string gxTpr_Terminosid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Terminosid, 18, 0));

			}
			set { 
				sdt.gxTpr_Terminosid = (long) NumberUtil.Val( value, ".");
			}
		}


		#endregion
		public SdtSDTServiciosAll_Item_ProductoItem_DetallesItem sdt
		{
			get { 
				return (SdtSDTServiciosAll_Item_ProductoItem_DetallesItem)Sdt;
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
				sdt = new SdtSDTServiciosAll_Item_ProductoItem_DetallesItem() ;
			}
		}
	}
	#endregion
}