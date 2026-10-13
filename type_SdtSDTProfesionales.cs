/*
				   File: type_SdtSDTProfesionales
			Description: SDTProfesionales
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
	[XmlRoot(ElementName="SDTProfesionales")]
	[XmlType(TypeName="SDTProfesionales" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTProfesionales : GxUserType
	{
		public SdtSDTProfesionales( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTProfesionales_Docidentidad = "";

			gxTv_SdtSDTProfesionales_Primernombre = "";

			gxTv_SdtSDTProfesionales_Segundonombre = "";

			gxTv_SdtSDTProfesionales_Apellidoprimero = "";

			gxTv_SdtSDTProfesionales_Apellidosegundo = "";

			gxTv_SdtSDTProfesionales_Imagenbase64 = "";

			gxTv_SdtSDTProfesionales_Telefono = "";

			gxTv_SdtSDTProfesionales_Email = "";

			gxTv_SdtSDTProfesionales_Direccion = "";

			gxTv_SdtSDTProfesionales_Paisiso2 = "";

			gxTv_SdtSDTProfesionales_Ciudad = "";

			gxTv_SdtSDTProfesionales_Cuentabancaria = "";

			gxTv_SdtSDTProfesionales_Experiencia = "";

			gxTv_SdtSDTProfesionales_Rutempresa = "";


		}

		public SdtSDTProfesionales(IGxContext context)
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
			AddObjectProperty("DocIdentidad", gxTpr_Docidentidad, false);


			AddObjectProperty("EsRUT", gxTpr_Esrut, false);


			AddObjectProperty("PrimerNombre", gxTpr_Primernombre, false);


			AddObjectProperty("SegundoNombre", gxTpr_Segundonombre, false);


			AddObjectProperty("ApellidoPrimero", gxTpr_Apellidoprimero, false);


			AddObjectProperty("ApellidoSegundo", gxTpr_Apellidosegundo, false);


			AddObjectProperty("ImagenBase64", gxTpr_Imagenbase64, false);


			AddObjectProperty("Telefono", gxTpr_Telefono, false);


			AddObjectProperty("Email", gxTpr_Email, false);


			AddObjectProperty("Direccion", gxTpr_Direccion, false);


			AddObjectProperty("PaisISO2", gxTpr_Paisiso2, false);


			AddObjectProperty("Ciudad", gxTpr_Ciudad, false);


			AddObjectProperty("AceptoTerminos", gxTpr_Aceptoterminos, false);


			AddObjectProperty("DeclaroDatosV", gxTpr_Declarodatosv, false);


			AddObjectProperty("CuentaBancaria", gxTpr_Cuentabancaria, false);


			AddObjectProperty("BancoId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Bancoid, 18, 0)), false);


			AddObjectProperty("Experiencia", gxTpr_Experiencia, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Fechanacimiento)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Fechanacimiento)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Fechanacimiento)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("FechaNacimiento", sDateCnv, false);



			AddObjectProperty("RUTEmpresa", gxTpr_Rutempresa, false);


			AddObjectProperty("TipoEmpresa", gxTpr_Tipoempresa, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="DocIdentidad")]
		[XmlElement(ElementName="DocIdentidad")]
		public string gxTpr_Docidentidad
		{
			get {
				return gxTv_SdtSDTProfesionales_Docidentidad; 
			}
			set {
				gxTv_SdtSDTProfesionales_Docidentidad = value;
				SetDirty("Docidentidad");
			}
		}




		[SoapElement(ElementName="EsRUT")]
		[XmlElement(ElementName="EsRUT")]
		public bool gxTpr_Esrut
		{
			get {
				return gxTv_SdtSDTProfesionales_Esrut; 
			}
			set {
				gxTv_SdtSDTProfesionales_Esrut = value;
				SetDirty("Esrut");
			}
		}




		[SoapElement(ElementName="PrimerNombre")]
		[XmlElement(ElementName="PrimerNombre")]
		public string gxTpr_Primernombre
		{
			get {
				return gxTv_SdtSDTProfesionales_Primernombre; 
			}
			set {
				gxTv_SdtSDTProfesionales_Primernombre = value;
				SetDirty("Primernombre");
			}
		}




		[SoapElement(ElementName="SegundoNombre")]
		[XmlElement(ElementName="SegundoNombre")]
		public string gxTpr_Segundonombre
		{
			get {
				return gxTv_SdtSDTProfesionales_Segundonombre; 
			}
			set {
				gxTv_SdtSDTProfesionales_Segundonombre = value;
				SetDirty("Segundonombre");
			}
		}




		[SoapElement(ElementName="ApellidoPrimero")]
		[XmlElement(ElementName="ApellidoPrimero")]
		public string gxTpr_Apellidoprimero
		{
			get {
				return gxTv_SdtSDTProfesionales_Apellidoprimero; 
			}
			set {
				gxTv_SdtSDTProfesionales_Apellidoprimero = value;
				SetDirty("Apellidoprimero");
			}
		}




		[SoapElement(ElementName="ApellidoSegundo")]
		[XmlElement(ElementName="ApellidoSegundo")]
		public string gxTpr_Apellidosegundo
		{
			get {
				return gxTv_SdtSDTProfesionales_Apellidosegundo; 
			}
			set {
				gxTv_SdtSDTProfesionales_Apellidosegundo = value;
				SetDirty("Apellidosegundo");
			}
		}




		[SoapElement(ElementName="ImagenBase64")]
		[XmlElement(ElementName="ImagenBase64")]
		public string gxTpr_Imagenbase64
		{
			get {
				return gxTv_SdtSDTProfesionales_Imagenbase64; 
			}
			set {
				gxTv_SdtSDTProfesionales_Imagenbase64 = value;
				SetDirty("Imagenbase64");
			}
		}




		[SoapElement(ElementName="Telefono")]
		[XmlElement(ElementName="Telefono")]
		public string gxTpr_Telefono
		{
			get {
				return gxTv_SdtSDTProfesionales_Telefono; 
			}
			set {
				gxTv_SdtSDTProfesionales_Telefono = value;
				SetDirty("Telefono");
			}
		}




		[SoapElement(ElementName="Email")]
		[XmlElement(ElementName="Email")]
		public string gxTpr_Email
		{
			get {
				return gxTv_SdtSDTProfesionales_Email; 
			}
			set {
				gxTv_SdtSDTProfesionales_Email = value;
				SetDirty("Email");
			}
		}




		[SoapElement(ElementName="Direccion")]
		[XmlElement(ElementName="Direccion")]
		public string gxTpr_Direccion
		{
			get {
				return gxTv_SdtSDTProfesionales_Direccion; 
			}
			set {
				gxTv_SdtSDTProfesionales_Direccion = value;
				SetDirty("Direccion");
			}
		}




		[SoapElement(ElementName="PaisISO2")]
		[XmlElement(ElementName="PaisISO2")]
		public string gxTpr_Paisiso2
		{
			get {
				return gxTv_SdtSDTProfesionales_Paisiso2; 
			}
			set {
				gxTv_SdtSDTProfesionales_Paisiso2 = value;
				SetDirty("Paisiso2");
			}
		}




		[SoapElement(ElementName="Ciudad")]
		[XmlElement(ElementName="Ciudad")]
		public string gxTpr_Ciudad
		{
			get {
				return gxTv_SdtSDTProfesionales_Ciudad; 
			}
			set {
				gxTv_SdtSDTProfesionales_Ciudad = value;
				SetDirty("Ciudad");
			}
		}




		[SoapElement(ElementName="AceptoTerminos")]
		[XmlElement(ElementName="AceptoTerminos")]
		public bool gxTpr_Aceptoterminos
		{
			get {
				return gxTv_SdtSDTProfesionales_Aceptoterminos; 
			}
			set {
				gxTv_SdtSDTProfesionales_Aceptoterminos = value;
				SetDirty("Aceptoterminos");
			}
		}




		[SoapElement(ElementName="DeclaroDatosV")]
		[XmlElement(ElementName="DeclaroDatosV")]
		public bool gxTpr_Declarodatosv
		{
			get {
				return gxTv_SdtSDTProfesionales_Declarodatosv; 
			}
			set {
				gxTv_SdtSDTProfesionales_Declarodatosv = value;
				SetDirty("Declarodatosv");
			}
		}




		[SoapElement(ElementName="CuentaBancaria")]
		[XmlElement(ElementName="CuentaBancaria")]
		public string gxTpr_Cuentabancaria
		{
			get {
				return gxTv_SdtSDTProfesionales_Cuentabancaria; 
			}
			set {
				gxTv_SdtSDTProfesionales_Cuentabancaria = value;
				SetDirty("Cuentabancaria");
			}
		}




		[SoapElement(ElementName="BancoId")]
		[XmlElement(ElementName="BancoId")]
		public long gxTpr_Bancoid
		{
			get {
				return gxTv_SdtSDTProfesionales_Bancoid; 
			}
			set {
				gxTv_SdtSDTProfesionales_Bancoid = value;
				SetDirty("Bancoid");
			}
		}




		[SoapElement(ElementName="Experiencia")]
		[XmlElement(ElementName="Experiencia")]
		public string gxTpr_Experiencia
		{
			get {
				return gxTv_SdtSDTProfesionales_Experiencia; 
			}
			set {
				gxTv_SdtSDTProfesionales_Experiencia = value;
				SetDirty("Experiencia");
			}
		}



		[SoapElement(ElementName="FechaNacimiento")]
		[XmlElement(ElementName="FechaNacimiento" , IsNullable=true)]
		public string gxTpr_Fechanacimiento_Nullable
		{
			get {
				if ( gxTv_SdtSDTProfesionales_Fechanacimiento == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTProfesionales_Fechanacimiento).value ;
			}
			set {
				gxTv_SdtSDTProfesionales_Fechanacimiento = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Fechanacimiento
		{
			get {
				return gxTv_SdtSDTProfesionales_Fechanacimiento; 
			}
			set {
				gxTv_SdtSDTProfesionales_Fechanacimiento = value;
				SetDirty("Fechanacimiento");
			}
		}



		[SoapElement(ElementName="RUTEmpresa")]
		[XmlElement(ElementName="RUTEmpresa")]
		public string gxTpr_Rutempresa
		{
			get {
				return gxTv_SdtSDTProfesionales_Rutempresa; 
			}
			set {
				gxTv_SdtSDTProfesionales_Rutempresa = value;
				SetDirty("Rutempresa");
			}
		}




		[SoapElement(ElementName="TipoEmpresa")]
		[XmlElement(ElementName="TipoEmpresa")]
		public short gxTpr_Tipoempresa
		{
			get {
				return gxTv_SdtSDTProfesionales_Tipoempresa; 
			}
			set {
				gxTv_SdtSDTProfesionales_Tipoempresa = value;
				SetDirty("Tipoempresa");
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
			gxTv_SdtSDTProfesionales_Docidentidad = "";

			gxTv_SdtSDTProfesionales_Primernombre = "";
			gxTv_SdtSDTProfesionales_Segundonombre = "";
			gxTv_SdtSDTProfesionales_Apellidoprimero = "";
			gxTv_SdtSDTProfesionales_Apellidosegundo = "";
			gxTv_SdtSDTProfesionales_Imagenbase64 = "";
			gxTv_SdtSDTProfesionales_Telefono = "";
			gxTv_SdtSDTProfesionales_Email = "";
			gxTv_SdtSDTProfesionales_Direccion = "";
			gxTv_SdtSDTProfesionales_Paisiso2 = "";
			gxTv_SdtSDTProfesionales_Ciudad = "";


			gxTv_SdtSDTProfesionales_Cuentabancaria = "";

			gxTv_SdtSDTProfesionales_Experiencia = "";

			gxTv_SdtSDTProfesionales_Rutempresa = "";

			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected string gxTv_SdtSDTProfesionales_Docidentidad;
		 

		protected bool gxTv_SdtSDTProfesionales_Esrut;
		 

		protected string gxTv_SdtSDTProfesionales_Primernombre;
		 

		protected string gxTv_SdtSDTProfesionales_Segundonombre;
		 

		protected string gxTv_SdtSDTProfesionales_Apellidoprimero;
		 

		protected string gxTv_SdtSDTProfesionales_Apellidosegundo;
		 

		protected string gxTv_SdtSDTProfesionales_Imagenbase64;
		 

		protected string gxTv_SdtSDTProfesionales_Telefono;
		 

		protected string gxTv_SdtSDTProfesionales_Email;
		 

		protected string gxTv_SdtSDTProfesionales_Direccion;
		 

		protected string gxTv_SdtSDTProfesionales_Paisiso2;
		 

		protected string gxTv_SdtSDTProfesionales_Ciudad;
		 

		protected bool gxTv_SdtSDTProfesionales_Aceptoterminos;
		 

		protected bool gxTv_SdtSDTProfesionales_Declarodatosv;
		 

		protected string gxTv_SdtSDTProfesionales_Cuentabancaria;
		 

		protected long gxTv_SdtSDTProfesionales_Bancoid;
		 

		protected string gxTv_SdtSDTProfesionales_Experiencia;
		 

		protected DateTime gxTv_SdtSDTProfesionales_Fechanacimiento;
		 

		protected string gxTv_SdtSDTProfesionales_Rutempresa;
		 

		protected short gxTv_SdtSDTProfesionales_Tipoempresa;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTProfesionales", Namespace="AlmangoX")]
	public class SdtSDTProfesionales_RESTInterface : GxGenericCollectionItem<SdtSDTProfesionales>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTProfesionales_RESTInterface( ) : base()
		{	
		}

		public SdtSDTProfesionales_RESTInterface( SdtSDTProfesionales psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="DocIdentidad", Order=0)]
		public  string gxTpr_Docidentidad
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Docidentidad);

			}
			set { 
				 sdt.gxTpr_Docidentidad = value;
			}
		}

		[DataMember(Name="EsRUT", Order=1)]
		public bool gxTpr_Esrut
		{
			get { 
				return sdt.gxTpr_Esrut;

			}
			set { 
				sdt.gxTpr_Esrut = value;
			}
		}

		[DataMember(Name="PrimerNombre", Order=2)]
		public  string gxTpr_Primernombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Primernombre);

			}
			set { 
				 sdt.gxTpr_Primernombre = value;
			}
		}

		[DataMember(Name="SegundoNombre", Order=3)]
		public  string gxTpr_Segundonombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Segundonombre);

			}
			set { 
				 sdt.gxTpr_Segundonombre = value;
			}
		}

		[DataMember(Name="ApellidoPrimero", Order=4)]
		public  string gxTpr_Apellidoprimero
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Apellidoprimero);

			}
			set { 
				 sdt.gxTpr_Apellidoprimero = value;
			}
		}

		[DataMember(Name="ApellidoSegundo", Order=5)]
		public  string gxTpr_Apellidosegundo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Apellidosegundo);

			}
			set { 
				 sdt.gxTpr_Apellidosegundo = value;
			}
		}

		[DataMember(Name="ImagenBase64", Order=6)]
		public  string gxTpr_Imagenbase64
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Imagenbase64);

			}
			set { 
				 sdt.gxTpr_Imagenbase64 = value;
			}
		}

		[DataMember(Name="Telefono", Order=7)]
		public  string gxTpr_Telefono
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Telefono);

			}
			set { 
				 sdt.gxTpr_Telefono = value;
			}
		}

		[DataMember(Name="Email", Order=8)]
		public  string gxTpr_Email
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Email);

			}
			set { 
				 sdt.gxTpr_Email = value;
			}
		}

		[DataMember(Name="Direccion", Order=9)]
		public  string gxTpr_Direccion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Direccion);

			}
			set { 
				 sdt.gxTpr_Direccion = value;
			}
		}

		[DataMember(Name="PaisISO2", Order=10)]
		public  string gxTpr_Paisiso2
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Paisiso2);

			}
			set { 
				 sdt.gxTpr_Paisiso2 = value;
			}
		}

		[DataMember(Name="Ciudad", Order=11)]
		public  string gxTpr_Ciudad
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Ciudad);

			}
			set { 
				 sdt.gxTpr_Ciudad = value;
			}
		}

		[DataMember(Name="AceptoTerminos", Order=12)]
		public bool gxTpr_Aceptoterminos
		{
			get { 
				return sdt.gxTpr_Aceptoterminos;

			}
			set { 
				sdt.gxTpr_Aceptoterminos = value;
			}
		}

		[DataMember(Name="DeclaroDatosV", Order=13)]
		public bool gxTpr_Declarodatosv
		{
			get { 
				return sdt.gxTpr_Declarodatosv;

			}
			set { 
				sdt.gxTpr_Declarodatosv = value;
			}
		}

		[DataMember(Name="CuentaBancaria", Order=14)]
		public  string gxTpr_Cuentabancaria
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Cuentabancaria);

			}
			set { 
				 sdt.gxTpr_Cuentabancaria = value;
			}
		}

		[DataMember(Name="BancoId", Order=15)]
		public  string gxTpr_Bancoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Bancoid, 18, 0));

			}
			set { 
				sdt.gxTpr_Bancoid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Experiencia", Order=16)]
		public  string gxTpr_Experiencia
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Experiencia);

			}
			set { 
				 sdt.gxTpr_Experiencia = value;
			}
		}

		[DataMember(Name="FechaNacimiento", Order=17)]
		public  string gxTpr_Fechanacimiento
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Fechanacimiento);

			}
			set { 
				sdt.gxTpr_Fechanacimiento = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="RUTEmpresa", Order=18)]
		public  string gxTpr_Rutempresa
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Rutempresa);

			}
			set { 
				 sdt.gxTpr_Rutempresa = value;
			}
		}

		[DataMember(Name="TipoEmpresa", Order=19)]
		public short gxTpr_Tipoempresa
		{
			get { 
				return sdt.gxTpr_Tipoempresa;

			}
			set { 
				sdt.gxTpr_Tipoempresa = value;
			}
		}


		#endregion
		public SdtSDTProfesionales sdt
		{
			get { 
				return (SdtSDTProfesionales)Sdt;
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
				sdt = new SdtSDTProfesionales() ;
			}
		}
	}
	#endregion
}