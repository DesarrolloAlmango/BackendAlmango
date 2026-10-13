/*
				   File: type_SdtSDTSolicitudCobrar
			Description: SDTSolicitudCobrar
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
	[XmlRoot(ElementName="SDTSolicitudCobrar")]
	[XmlType(TypeName="SDTSolicitudCobrar" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTSolicitudCobrar : GxUserType
	{
		public SdtSDTSolicitudCobrar( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTSolicitudCobrar_Codreferencia = "";

			gxTv_SdtSDTSolicitudCobrar_Moneda = "";

			gxTv_SdtSDTSolicitudCobrar_Consumidorfinal = "";

			gxTv_SdtSDTSolicitudCobrar_Fuepago = "";

			gxTv_SdtSDTSolicitudCobrar_Anombre = "";

			gxTv_SdtSDTSolicitudCobrar_Pais = "";

			gxTv_SdtSDTSolicitudCobrar_Descripcion = "";

			gxTv_SdtSDTSolicitudCobrar_Facturanro = "";

			gxTv_SdtSDTSolicitudCobrar_Fechacobro = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDTSolicitudCobrar_Comprobantecobro = "";

			gxTv_SdtSDTSolicitudCobrar_Departamento = "";

			gxTv_SdtSDTSolicitudCobrar_Ciudad = "";

			gxTv_SdtSDTSolicitudCobrar_Direccion = "";

			gxTv_SdtSDTSolicitudCobrar_Telefono = "";

		}

		public SdtSDTSolicitudCobrar(IGxContext context)
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
			AddObjectProperty("SolicitudId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Solicitudid, 18, 0)), false);


			AddObjectProperty("CodReferencia", gxTpr_Codreferencia, false);


			AddObjectProperty("OrdenNro", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Ordennro, 18, 0)), false);


			AddObjectProperty("TotalCobrar", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Totalcobrar, 18, 2)), false);


			AddObjectProperty("Moneda", gxTpr_Moneda, false);


			AddObjectProperty("ConsumidorFinal", gxTpr_Consumidorfinal, false);


			AddObjectProperty("FuePago", gxTpr_Fuepago, false);


			AddObjectProperty("ANombre", gxTpr_Anombre, false);


			AddObjectProperty("Pais", gxTpr_Pais, false);


			AddObjectProperty("Descripcion", gxTpr_Descripcion, false);


			AddObjectProperty("FacturaNro", gxTpr_Facturanro, false);


			AddObjectProperty("IVA", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Iva, 18, 2)), false);


			datetime_STZ = gxTpr_Fechacobro;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("FechaCobro", sDateCnv, false);



			AddObjectProperty("ComprobanteCobro", gxTpr_Comprobantecobro, false);


			AddObjectProperty("Departamento", gxTpr_Departamento, false);


			AddObjectProperty("Ciudad", gxTpr_Ciudad, false);


			AddObjectProperty("Direccion", gxTpr_Direccion, false);


			AddObjectProperty("Telefono", gxTpr_Telefono, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="SolicitudId")]
		[XmlElement(ElementName="SolicitudId")]
		public long gxTpr_Solicitudid
		{
			get {
				return gxTv_SdtSDTSolicitudCobrar_Solicitudid; 
			}
			set {
				gxTv_SdtSDTSolicitudCobrar_Solicitudid = value;
				SetDirty("Solicitudid");
			}
		}




		[SoapElement(ElementName="CodReferencia")]
		[XmlElement(ElementName="CodReferencia")]
		public string gxTpr_Codreferencia
		{
			get {
				return gxTv_SdtSDTSolicitudCobrar_Codreferencia; 
			}
			set {
				gxTv_SdtSDTSolicitudCobrar_Codreferencia = value;
				SetDirty("Codreferencia");
			}
		}




		[SoapElement(ElementName="OrdenNro")]
		[XmlElement(ElementName="OrdenNro")]
		public long gxTpr_Ordennro
		{
			get {
				return gxTv_SdtSDTSolicitudCobrar_Ordennro; 
			}
			set {
				gxTv_SdtSDTSolicitudCobrar_Ordennro = value;
				SetDirty("Ordennro");
			}
		}



		[SoapElement(ElementName="TotalCobrar")]
		[XmlElement(ElementName="TotalCobrar")]
		public string gxTpr_Totalcobrar_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTSolicitudCobrar_Totalcobrar, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTSolicitudCobrar_Totalcobrar = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Totalcobrar
		{
			get {
				return gxTv_SdtSDTSolicitudCobrar_Totalcobrar; 
			}
			set {
				gxTv_SdtSDTSolicitudCobrar_Totalcobrar = value;
				SetDirty("Totalcobrar");
			}
		}




		[SoapElement(ElementName="Moneda")]
		[XmlElement(ElementName="Moneda")]
		public string gxTpr_Moneda
		{
			get {
				return gxTv_SdtSDTSolicitudCobrar_Moneda; 
			}
			set {
				gxTv_SdtSDTSolicitudCobrar_Moneda = value;
				SetDirty("Moneda");
			}
		}



		[SoapElement(ElementName="ConsumidorFinal")]
		[XmlElement(ElementName="ConsumidorFinal")]
		[GxUpload()]
		public byte[] gxTpr_Consumidorfinal_Blob
		{
			get{
				IGxContext context = this.context == null ? new GxContext() : this.context;
				return context.FileToByteArray(gxTv_SdtSDTSolicitudCobrar_Consumidorfinal) ;
			}
			set {
				IGxContext context = this.context == null ? new GxContext() : this.context;
				gxTv_SdtSDTSolicitudCobrar_Consumidorfinal=context.FileFromByteArray( value) ;
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public string gxTpr_Consumidorfinal
		{
			get {
				return gxTv_SdtSDTSolicitudCobrar_Consumidorfinal; 
			}
			set {
				gxTv_SdtSDTSolicitudCobrar_Consumidorfinal = value;
				SetDirty("Consumidorfinal");
			}
		}




		[SoapElement(ElementName="FuePago")]
		[XmlElement(ElementName="FuePago")]
		public string gxTpr_Fuepago
		{
			get {
				return gxTv_SdtSDTSolicitudCobrar_Fuepago; 
			}
			set {
				gxTv_SdtSDTSolicitudCobrar_Fuepago = value;
				SetDirty("Fuepago");
			}
		}




		[SoapElement(ElementName="ANombre")]
		[XmlElement(ElementName="ANombre")]
		public string gxTpr_Anombre
		{
			get {
				return gxTv_SdtSDTSolicitudCobrar_Anombre; 
			}
			set {
				gxTv_SdtSDTSolicitudCobrar_Anombre = value;
				SetDirty("Anombre");
			}
		}




		[SoapElement(ElementName="Pais")]
		[XmlElement(ElementName="Pais")]
		public string gxTpr_Pais
		{
			get {
				return gxTv_SdtSDTSolicitudCobrar_Pais; 
			}
			set {
				gxTv_SdtSDTSolicitudCobrar_Pais = value;
				SetDirty("Pais");
			}
		}




		[SoapElement(ElementName="Descripcion")]
		[XmlElement(ElementName="Descripcion")]
		public string gxTpr_Descripcion
		{
			get {
				return gxTv_SdtSDTSolicitudCobrar_Descripcion; 
			}
			set {
				gxTv_SdtSDTSolicitudCobrar_Descripcion = value;
				SetDirty("Descripcion");
			}
		}




		[SoapElement(ElementName="FacturaNro")]
		[XmlElement(ElementName="FacturaNro")]
		public string gxTpr_Facturanro
		{
			get {
				return gxTv_SdtSDTSolicitudCobrar_Facturanro; 
			}
			set {
				gxTv_SdtSDTSolicitudCobrar_Facturanro = value;
				SetDirty("Facturanro");
			}
		}



		[SoapElement(ElementName="IVA")]
		[XmlElement(ElementName="IVA")]
		public string gxTpr_Iva_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTSolicitudCobrar_Iva, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTSolicitudCobrar_Iva = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Iva
		{
			get {
				return gxTv_SdtSDTSolicitudCobrar_Iva; 
			}
			set {
				gxTv_SdtSDTSolicitudCobrar_Iva = value;
				SetDirty("Iva");
			}
		}



		[SoapElement(ElementName="FechaCobro")]
		[XmlElement(ElementName="FechaCobro" , IsNullable=true)]
		public string gxTpr_Fechacobro_Nullable
		{
			get {
				if ( gxTv_SdtSDTSolicitudCobrar_Fechacobro == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDTSolicitudCobrar_Fechacobro).value ;
			}
			set {
				gxTv_SdtSDTSolicitudCobrar_Fechacobro = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Fechacobro
		{
			get {
				return gxTv_SdtSDTSolicitudCobrar_Fechacobro; 
			}
			set {
				gxTv_SdtSDTSolicitudCobrar_Fechacobro = value;
				SetDirty("Fechacobro");
			}
		}



		[SoapElement(ElementName="ComprobanteCobro")]
		[XmlElement(ElementName="ComprobanteCobro")]
		public string gxTpr_Comprobantecobro
		{
			get {
				return gxTv_SdtSDTSolicitudCobrar_Comprobantecobro; 
			}
			set {
				gxTv_SdtSDTSolicitudCobrar_Comprobantecobro = value;
				SetDirty("Comprobantecobro");
			}
		}




		[SoapElement(ElementName="Departamento")]
		[XmlElement(ElementName="Departamento")]
		public string gxTpr_Departamento
		{
			get {
				return gxTv_SdtSDTSolicitudCobrar_Departamento; 
			}
			set {
				gxTv_SdtSDTSolicitudCobrar_Departamento = value;
				SetDirty("Departamento");
			}
		}




		[SoapElement(ElementName="Ciudad")]
		[XmlElement(ElementName="Ciudad")]
		public string gxTpr_Ciudad
		{
			get {
				return gxTv_SdtSDTSolicitudCobrar_Ciudad; 
			}
			set {
				gxTv_SdtSDTSolicitudCobrar_Ciudad = value;
				SetDirty("Ciudad");
			}
		}




		[SoapElement(ElementName="Direccion")]
		[XmlElement(ElementName="Direccion")]
		public string gxTpr_Direccion
		{
			get {
				return gxTv_SdtSDTSolicitudCobrar_Direccion; 
			}
			set {
				gxTv_SdtSDTSolicitudCobrar_Direccion = value;
				SetDirty("Direccion");
			}
		}




		[SoapElement(ElementName="Telefono")]
		[XmlElement(ElementName="Telefono")]
		public string gxTpr_Telefono
		{
			get {
				return gxTv_SdtSDTSolicitudCobrar_Telefono; 
			}
			set {
				gxTv_SdtSDTSolicitudCobrar_Telefono = value;
				SetDirty("Telefono");
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
			gxTv_SdtSDTSolicitudCobrar_Codreferencia = "";


			gxTv_SdtSDTSolicitudCobrar_Moneda = "";
			gxTv_SdtSDTSolicitudCobrar_Consumidorfinal = "";
			gxTv_SdtSDTSolicitudCobrar_Fuepago = "";
			gxTv_SdtSDTSolicitudCobrar_Anombre = "";
			gxTv_SdtSDTSolicitudCobrar_Pais = "";
			gxTv_SdtSDTSolicitudCobrar_Descripcion = "";
			gxTv_SdtSDTSolicitudCobrar_Facturanro = "";

			gxTv_SdtSDTSolicitudCobrar_Fechacobro = (DateTime)(DateTime.MinValue);
			gxTv_SdtSDTSolicitudCobrar_Comprobantecobro = "";
			gxTv_SdtSDTSolicitudCobrar_Departamento = "";
			gxTv_SdtSDTSolicitudCobrar_Ciudad = "";
			gxTv_SdtSDTSolicitudCobrar_Direccion = "";
			gxTv_SdtSDTSolicitudCobrar_Telefono = "";
			datetime_STZ = (DateTime)(DateTime.MinValue);
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected DateTime datetime_STZ ;

		protected long gxTv_SdtSDTSolicitudCobrar_Solicitudid;
		 

		protected string gxTv_SdtSDTSolicitudCobrar_Codreferencia;
		 

		protected long gxTv_SdtSDTSolicitudCobrar_Ordennro;
		 

		protected decimal gxTv_SdtSDTSolicitudCobrar_Totalcobrar;
		 

		protected string gxTv_SdtSDTSolicitudCobrar_Moneda;
		 

		protected string gxTv_SdtSDTSolicitudCobrar_Consumidorfinal;
		 

		protected string gxTv_SdtSDTSolicitudCobrar_Fuepago;
		 

		protected string gxTv_SdtSDTSolicitudCobrar_Anombre;
		 

		protected string gxTv_SdtSDTSolicitudCobrar_Pais;
		 

		protected string gxTv_SdtSDTSolicitudCobrar_Descripcion;
		 

		protected string gxTv_SdtSDTSolicitudCobrar_Facturanro;
		 

		protected decimal gxTv_SdtSDTSolicitudCobrar_Iva;
		 

		protected DateTime gxTv_SdtSDTSolicitudCobrar_Fechacobro;
		 

		protected string gxTv_SdtSDTSolicitudCobrar_Comprobantecobro;
		 

		protected string gxTv_SdtSDTSolicitudCobrar_Departamento;
		 

		protected string gxTv_SdtSDTSolicitudCobrar_Ciudad;
		 

		protected string gxTv_SdtSDTSolicitudCobrar_Direccion;
		 

		protected string gxTv_SdtSDTSolicitudCobrar_Telefono;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTSolicitudCobrar", Namespace="AlmangoX")]
	public class SdtSDTSolicitudCobrar_RESTInterface : GxGenericCollectionItem<SdtSDTSolicitudCobrar>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTSolicitudCobrar_RESTInterface( ) : base()
		{	
		}

		public SdtSDTSolicitudCobrar_RESTInterface( SdtSDTSolicitudCobrar psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="SolicitudId", Order=0)]
		public  string gxTpr_Solicitudid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Solicitudid, 18, 0));

			}
			set { 
				sdt.gxTpr_Solicitudid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="CodReferencia", Order=1)]
		public  string gxTpr_Codreferencia
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Codreferencia);

			}
			set { 
				 sdt.gxTpr_Codreferencia = value;
			}
		}

		[DataMember(Name="OrdenNro", Order=2)]
		public  string gxTpr_Ordennro
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Ordennro, 18, 0));

			}
			set { 
				sdt.gxTpr_Ordennro = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TotalCobrar", Order=3)]
		public  string gxTpr_Totalcobrar
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Totalcobrar, 18, 2));

			}
			set { 
				sdt.gxTpr_Totalcobrar =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Moneda", Order=4)]
		public  string gxTpr_Moneda
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Moneda);

			}
			set { 
				 sdt.gxTpr_Moneda = value;
			}
		}

		[DataMember(Name="ConsumidorFinal", Order=5)]
		[GxUpload()]
		public  string gxTpr_Consumidorfinal
		{
			get { 
				return PathUtil.RelativePath( sdt.gxTpr_Consumidorfinal);

			}
			set { 
				 sdt.gxTpr_Consumidorfinal = value;
			}
		}

		[DataMember(Name="FuePago", Order=6)]
		public  string gxTpr_Fuepago
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Fuepago);

			}
			set { 
				 sdt.gxTpr_Fuepago = value;
			}
		}

		[DataMember(Name="ANombre", Order=7)]
		public  string gxTpr_Anombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Anombre);

			}
			set { 
				 sdt.gxTpr_Anombre = value;
			}
		}

		[DataMember(Name="Pais", Order=8)]
		public  string gxTpr_Pais
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Pais);

			}
			set { 
				 sdt.gxTpr_Pais = value;
			}
		}

		[DataMember(Name="Descripcion", Order=9)]
		public  string gxTpr_Descripcion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Descripcion);

			}
			set { 
				 sdt.gxTpr_Descripcion = value;
			}
		}

		[DataMember(Name="FacturaNro", Order=10)]
		public  string gxTpr_Facturanro
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Facturanro);

			}
			set { 
				 sdt.gxTpr_Facturanro = value;
			}
		}

		[DataMember(Name="IVA", Order=11)]
		public  string gxTpr_Iva
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Iva, 18, 2));

			}
			set { 
				sdt.gxTpr_Iva =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="FechaCobro", Order=12)]
		public  string gxTpr_Fechacobro
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Fechacobro,context);

			}
			set { 
				sdt.gxTpr_Fechacobro = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="ComprobanteCobro", Order=13)]
		public  string gxTpr_Comprobantecobro
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Comprobantecobro);

			}
			set { 
				 sdt.gxTpr_Comprobantecobro = value;
			}
		}

		[DataMember(Name="Departamento", Order=14)]
		public  string gxTpr_Departamento
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Departamento);

			}
			set { 
				 sdt.gxTpr_Departamento = value;
			}
		}

		[DataMember(Name="Ciudad", Order=15)]
		public  string gxTpr_Ciudad
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Ciudad);

			}
			set { 
				 sdt.gxTpr_Ciudad = value;
			}
		}

		[DataMember(Name="Direccion", Order=16)]
		public  string gxTpr_Direccion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Direccion);

			}
			set { 
				 sdt.gxTpr_Direccion = value;
			}
		}

		[DataMember(Name="Telefono", Order=17)]
		public  string gxTpr_Telefono
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Telefono);

			}
			set { 
				 sdt.gxTpr_Telefono = value;
			}
		}


		#endregion
		public SdtSDTSolicitudCobrar sdt
		{
			get { 
				return (SdtSDTSolicitudCobrar)Sdt;
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
				sdt = new SdtSDTSolicitudCobrar() ;
			}
		}
	}
	#endregion
}