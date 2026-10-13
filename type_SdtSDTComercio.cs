/*
				   File: type_SdtSDTComercio
			Description: SDTComercio
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
	[XmlRoot(ElementName="SDTComercio")]
	[XmlType(TypeName="SDTComercio" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTComercio : GxUserType
	{
		public SdtSDTComercio( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTComercio_Nombre = "";

			gxTv_SdtSDTComercio_Razonsocial = "";

			gxTv_SdtSDTComercio_Contacto = "";

			gxTv_SdtSDTComercio_Telefonocontacto = "";

			gxTv_SdtSDTComercio_Imagenbase64 = "";

			gxTv_SdtSDTComercio_Docidentidad = "";

			gxTv_SdtSDTComercio_Telefono = "";

			gxTv_SdtSDTComercio_Sitioweb = "";

			gxTv_SdtSDTComercio_Direccion = "";

			gxTv_SdtSDTComercio_Email = "";

			gxTv_SdtSDTComercio_Cuentabancaria = "";

			gxTv_SdtSDTComercio_Paisiso2 = "";

			gxTv_SdtSDTComercio_Ciudad = "";


		}

		public SdtSDTComercio(IGxContext context)
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
			AddObjectProperty("ProveedorID", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Proveedorid, 18, 0)), false);


			AddObjectProperty("Nombre", gxTpr_Nombre, false);


			AddObjectProperty("RazonSocial", gxTpr_Razonsocial, false);


			AddObjectProperty("Contacto", gxTpr_Contacto, false);


			AddObjectProperty("TelefonoContacto", gxTpr_Telefonocontacto, false);


			AddObjectProperty("ImagenBase64", gxTpr_Imagenbase64, false);


			AddObjectProperty("DocIdentidad", gxTpr_Docidentidad, false);


			AddObjectProperty("Telefono", gxTpr_Telefono, false);


			AddObjectProperty("SitioWeb", gxTpr_Sitioweb, false);


			AddObjectProperty("Direccion", gxTpr_Direccion, false);


			AddObjectProperty("Email", gxTpr_Email, false);


			AddObjectProperty("AceptoTerminos", gxTpr_Aceptoterminos, false);


			AddObjectProperty("CuentaBancaria", gxTpr_Cuentabancaria, false);


			AddObjectProperty("PaisISO2", gxTpr_Paisiso2, false);


			AddObjectProperty("Ciudad", gxTpr_Ciudad, false);


			AddObjectProperty("BancoId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Bancoid, 18, 0)), false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ProveedorID")]
		[XmlElement(ElementName="ProveedorID")]
		public long gxTpr_Proveedorid
		{
			get {
				return gxTv_SdtSDTComercio_Proveedorid; 
			}
			set {
				gxTv_SdtSDTComercio_Proveedorid = value;
				SetDirty("Proveedorid");
			}
		}




		[SoapElement(ElementName="Nombre")]
		[XmlElement(ElementName="Nombre")]
		public string gxTpr_Nombre
		{
			get {
				return gxTv_SdtSDTComercio_Nombre; 
			}
			set {
				gxTv_SdtSDTComercio_Nombre = value;
				SetDirty("Nombre");
			}
		}




		[SoapElement(ElementName="RazonSocial")]
		[XmlElement(ElementName="RazonSocial")]
		public string gxTpr_Razonsocial
		{
			get {
				return gxTv_SdtSDTComercio_Razonsocial; 
			}
			set {
				gxTv_SdtSDTComercio_Razonsocial = value;
				SetDirty("Razonsocial");
			}
		}




		[SoapElement(ElementName="Contacto")]
		[XmlElement(ElementName="Contacto")]
		public string gxTpr_Contacto
		{
			get {
				return gxTv_SdtSDTComercio_Contacto; 
			}
			set {
				gxTv_SdtSDTComercio_Contacto = value;
				SetDirty("Contacto");
			}
		}




		[SoapElement(ElementName="TelefonoContacto")]
		[XmlElement(ElementName="TelefonoContacto")]
		public string gxTpr_Telefonocontacto
		{
			get {
				return gxTv_SdtSDTComercio_Telefonocontacto; 
			}
			set {
				gxTv_SdtSDTComercio_Telefonocontacto = value;
				SetDirty("Telefonocontacto");
			}
		}




		[SoapElement(ElementName="ImagenBase64")]
		[XmlElement(ElementName="ImagenBase64")]
		public string gxTpr_Imagenbase64
		{
			get {
				return gxTv_SdtSDTComercio_Imagenbase64; 
			}
			set {
				gxTv_SdtSDTComercio_Imagenbase64 = value;
				SetDirty("Imagenbase64");
			}
		}




		[SoapElement(ElementName="DocIdentidad")]
		[XmlElement(ElementName="DocIdentidad")]
		public string gxTpr_Docidentidad
		{
			get {
				return gxTv_SdtSDTComercio_Docidentidad; 
			}
			set {
				gxTv_SdtSDTComercio_Docidentidad = value;
				SetDirty("Docidentidad");
			}
		}




		[SoapElement(ElementName="Telefono")]
		[XmlElement(ElementName="Telefono")]
		public string gxTpr_Telefono
		{
			get {
				return gxTv_SdtSDTComercio_Telefono; 
			}
			set {
				gxTv_SdtSDTComercio_Telefono = value;
				SetDirty("Telefono");
			}
		}




		[SoapElement(ElementName="SitioWeb")]
		[XmlElement(ElementName="SitioWeb")]
		public string gxTpr_Sitioweb
		{
			get {
				return gxTv_SdtSDTComercio_Sitioweb; 
			}
			set {
				gxTv_SdtSDTComercio_Sitioweb = value;
				SetDirty("Sitioweb");
			}
		}




		[SoapElement(ElementName="Direccion")]
		[XmlElement(ElementName="Direccion")]
		public string gxTpr_Direccion
		{
			get {
				return gxTv_SdtSDTComercio_Direccion; 
			}
			set {
				gxTv_SdtSDTComercio_Direccion = value;
				SetDirty("Direccion");
			}
		}




		[SoapElement(ElementName="Email")]
		[XmlElement(ElementName="Email")]
		public string gxTpr_Email
		{
			get {
				return gxTv_SdtSDTComercio_Email; 
			}
			set {
				gxTv_SdtSDTComercio_Email = value;
				SetDirty("Email");
			}
		}




		[SoapElement(ElementName="AceptoTerminos")]
		[XmlElement(ElementName="AceptoTerminos")]
		public bool gxTpr_Aceptoterminos
		{
			get {
				return gxTv_SdtSDTComercio_Aceptoterminos; 
			}
			set {
				gxTv_SdtSDTComercio_Aceptoterminos = value;
				SetDirty("Aceptoterminos");
			}
		}




		[SoapElement(ElementName="CuentaBancaria")]
		[XmlElement(ElementName="CuentaBancaria")]
		public string gxTpr_Cuentabancaria
		{
			get {
				return gxTv_SdtSDTComercio_Cuentabancaria; 
			}
			set {
				gxTv_SdtSDTComercio_Cuentabancaria = value;
				SetDirty("Cuentabancaria");
			}
		}




		[SoapElement(ElementName="PaisISO2")]
		[XmlElement(ElementName="PaisISO2")]
		public string gxTpr_Paisiso2
		{
			get {
				return gxTv_SdtSDTComercio_Paisiso2; 
			}
			set {
				gxTv_SdtSDTComercio_Paisiso2 = value;
				SetDirty("Paisiso2");
			}
		}




		[SoapElement(ElementName="Ciudad")]
		[XmlElement(ElementName="Ciudad")]
		public string gxTpr_Ciudad
		{
			get {
				return gxTv_SdtSDTComercio_Ciudad; 
			}
			set {
				gxTv_SdtSDTComercio_Ciudad = value;
				SetDirty("Ciudad");
			}
		}




		[SoapElement(ElementName="BancoId")]
		[XmlElement(ElementName="BancoId")]
		public long gxTpr_Bancoid
		{
			get {
				return gxTv_SdtSDTComercio_Bancoid; 
			}
			set {
				gxTv_SdtSDTComercio_Bancoid = value;
				SetDirty("Bancoid");
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
			gxTv_SdtSDTComercio_Nombre = "";
			gxTv_SdtSDTComercio_Razonsocial = "";
			gxTv_SdtSDTComercio_Contacto = "";
			gxTv_SdtSDTComercio_Telefonocontacto = "";
			gxTv_SdtSDTComercio_Imagenbase64 = "";
			gxTv_SdtSDTComercio_Docidentidad = "";
			gxTv_SdtSDTComercio_Telefono = "";
			gxTv_SdtSDTComercio_Sitioweb = "";
			gxTv_SdtSDTComercio_Direccion = "";
			gxTv_SdtSDTComercio_Email = "";

			gxTv_SdtSDTComercio_Cuentabancaria = "";
			gxTv_SdtSDTComercio_Paisiso2 = "";
			gxTv_SdtSDTComercio_Ciudad = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTComercio_Proveedorid;
		 

		protected string gxTv_SdtSDTComercio_Nombre;
		 

		protected string gxTv_SdtSDTComercio_Razonsocial;
		 

		protected string gxTv_SdtSDTComercio_Contacto;
		 

		protected string gxTv_SdtSDTComercio_Telefonocontacto;
		 

		protected string gxTv_SdtSDTComercio_Imagenbase64;
		 

		protected string gxTv_SdtSDTComercio_Docidentidad;
		 

		protected string gxTv_SdtSDTComercio_Telefono;
		 

		protected string gxTv_SdtSDTComercio_Sitioweb;
		 

		protected string gxTv_SdtSDTComercio_Direccion;
		 

		protected string gxTv_SdtSDTComercio_Email;
		 

		protected bool gxTv_SdtSDTComercio_Aceptoterminos;
		 

		protected string gxTv_SdtSDTComercio_Cuentabancaria;
		 

		protected string gxTv_SdtSDTComercio_Paisiso2;
		 

		protected string gxTv_SdtSDTComercio_Ciudad;
		 

		protected long gxTv_SdtSDTComercio_Bancoid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTComercio", Namespace="AlmangoX")]
	public class SdtSDTComercio_RESTInterface : GxGenericCollectionItem<SdtSDTComercio>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTComercio_RESTInterface( ) : base()
		{	
		}

		public SdtSDTComercio_RESTInterface( SdtSDTComercio psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ProveedorID", Order=0)]
		public  string gxTpr_Proveedorid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Proveedorid, 18, 0));

			}
			set { 
				sdt.gxTpr_Proveedorid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Nombre", Order=1)]
		public  string gxTpr_Nombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Nombre);

			}
			set { 
				 sdt.gxTpr_Nombre = value;
			}
		}

		[DataMember(Name="RazonSocial", Order=2)]
		public  string gxTpr_Razonsocial
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Razonsocial);

			}
			set { 
				 sdt.gxTpr_Razonsocial = value;
			}
		}

		[DataMember(Name="Contacto", Order=3)]
		public  string gxTpr_Contacto
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Contacto);

			}
			set { 
				 sdt.gxTpr_Contacto = value;
			}
		}

		[DataMember(Name="TelefonoContacto", Order=4)]
		public  string gxTpr_Telefonocontacto
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Telefonocontacto);

			}
			set { 
				 sdt.gxTpr_Telefonocontacto = value;
			}
		}

		[DataMember(Name="ImagenBase64", Order=5)]
		public  string gxTpr_Imagenbase64
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Imagenbase64);

			}
			set { 
				 sdt.gxTpr_Imagenbase64 = value;
			}
		}

		[DataMember(Name="DocIdentidad", Order=6)]
		public  string gxTpr_Docidentidad
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Docidentidad);

			}
			set { 
				 sdt.gxTpr_Docidentidad = value;
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

		[DataMember(Name="SitioWeb", Order=8)]
		public  string gxTpr_Sitioweb
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Sitioweb);

			}
			set { 
				 sdt.gxTpr_Sitioweb = value;
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

		[DataMember(Name="Email", Order=10)]
		public  string gxTpr_Email
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Email);

			}
			set { 
				 sdt.gxTpr_Email = value;
			}
		}

		[DataMember(Name="AceptoTerminos", Order=11)]
		public bool gxTpr_Aceptoterminos
		{
			get { 
				return sdt.gxTpr_Aceptoterminos;

			}
			set { 
				sdt.gxTpr_Aceptoterminos = value;
			}
		}

		[DataMember(Name="CuentaBancaria", Order=12)]
		public  string gxTpr_Cuentabancaria
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Cuentabancaria);

			}
			set { 
				 sdt.gxTpr_Cuentabancaria = value;
			}
		}

		[DataMember(Name="PaisISO2", Order=13)]
		public  string gxTpr_Paisiso2
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Paisiso2);

			}
			set { 
				 sdt.gxTpr_Paisiso2 = value;
			}
		}

		[DataMember(Name="Ciudad", Order=14)]
		public  string gxTpr_Ciudad
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Ciudad);

			}
			set { 
				 sdt.gxTpr_Ciudad = value;
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


		#endregion
		public SdtSDTComercio sdt
		{
			get { 
				return (SdtSDTComercio)Sdt;
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
				sdt = new SdtSDTComercio() ;
			}
		}
	}
	#endregion
}