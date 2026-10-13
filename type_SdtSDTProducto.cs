/*
				   File: type_SdtSDTProducto
			Description: SDTProducto
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
	[XmlRoot(ElementName="SDTProducto")]
	[XmlType(TypeName="SDTProducto" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTProducto : GxUserType
	{
		public SdtSDTProducto( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTProducto_Productonombre = "";

			gxTv_SdtSDTProducto_Activo = "";

		}

		public SdtSDTProducto(IGxContext context)
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
			AddObjectProperty("ProductoId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Productoid, 18, 0)), false);


			AddObjectProperty("ProductoNombre", gxTpr_Productonombre, false);


			AddObjectProperty("ProductoPrecio", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Productoprecio, 18, 2)), false);


			AddObjectProperty("MonedaId", gxTpr_Monedaid, false);


			AddObjectProperty("TextosId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Textosid, 18, 0)), false);


			AddObjectProperty("Activo", gxTpr_Activo, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ProductoId")]
		[XmlElement(ElementName="ProductoId")]
		public long gxTpr_Productoid
		{
			get {
				return gxTv_SdtSDTProducto_Productoid; 
			}
			set {
				gxTv_SdtSDTProducto_Productoid = value;
				SetDirty("Productoid");
			}
		}




		[SoapElement(ElementName="ProductoNombre")]
		[XmlElement(ElementName="ProductoNombre")]
		public string gxTpr_Productonombre
		{
			get {
				return gxTv_SdtSDTProducto_Productonombre; 
			}
			set {
				gxTv_SdtSDTProducto_Productonombre = value;
				SetDirty("Productonombre");
			}
		}



		[SoapElement(ElementName="ProductoPrecio")]
		[XmlElement(ElementName="ProductoPrecio")]
		public string gxTpr_Productoprecio_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTProducto_Productoprecio, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTProducto_Productoprecio = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Productoprecio
		{
			get {
				return gxTv_SdtSDTProducto_Productoprecio; 
			}
			set {
				gxTv_SdtSDTProducto_Productoprecio = value;
				SetDirty("Productoprecio");
			}
		}




		[SoapElement(ElementName="MonedaId")]
		[XmlElement(ElementName="MonedaId")]
		public short gxTpr_Monedaid
		{
			get {
				return gxTv_SdtSDTProducto_Monedaid; 
			}
			set {
				gxTv_SdtSDTProducto_Monedaid = value;
				SetDirty("Monedaid");
			}
		}




		[SoapElement(ElementName="TextosId")]
		[XmlElement(ElementName="TextosId")]
		public long gxTpr_Textosid
		{
			get {
				return gxTv_SdtSDTProducto_Textosid; 
			}
			set {
				gxTv_SdtSDTProducto_Textosid = value;
				SetDirty("Textosid");
			}
		}




		[SoapElement(ElementName="Activo")]
		[XmlElement(ElementName="Activo")]
		public string gxTpr_Activo
		{
			get {
				return gxTv_SdtSDTProducto_Activo; 
			}
			set {
				gxTv_SdtSDTProducto_Activo = value;
				SetDirty("Activo");
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
			gxTv_SdtSDTProducto_Productonombre = "";



			gxTv_SdtSDTProducto_Activo = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTProducto_Productoid;
		 

		protected string gxTv_SdtSDTProducto_Productonombre;
		 

		protected decimal gxTv_SdtSDTProducto_Productoprecio;
		 

		protected short gxTv_SdtSDTProducto_Monedaid;
		 

		protected long gxTv_SdtSDTProducto_Textosid;
		 

		protected string gxTv_SdtSDTProducto_Activo;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTProducto", Namespace="AlmangoX")]
	public class SdtSDTProducto_RESTInterface : GxGenericCollectionItem<SdtSDTProducto>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTProducto_RESTInterface( ) : base()
		{	
		}

		public SdtSDTProducto_RESTInterface( SdtSDTProducto psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ProductoId", Order=0)]
		public  string gxTpr_Productoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Productoid, 18, 0));

			}
			set { 
				sdt.gxTpr_Productoid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ProductoNombre", Order=1)]
		public  string gxTpr_Productonombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Productonombre);

			}
			set { 
				 sdt.gxTpr_Productonombre = value;
			}
		}

		[DataMember(Name="ProductoPrecio", Order=2)]
		public  string gxTpr_Productoprecio
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Productoprecio, 18, 2));

			}
			set { 
				sdt.gxTpr_Productoprecio =  NumberUtil.Val( value, ".");
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

		[DataMember(Name="TextosId", Order=4)]
		public  string gxTpr_Textosid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Textosid, 18, 0));

			}
			set { 
				sdt.gxTpr_Textosid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Activo", Order=5)]
		public  string gxTpr_Activo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Activo);

			}
			set { 
				 sdt.gxTpr_Activo = value;
			}
		}


		#endregion
		public SdtSDTProducto sdt
		{
			get { 
				return (SdtSDTProducto)Sdt;
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
				sdt = new SdtSDTProducto() ;
			}
		}
	}
	#endregion
}