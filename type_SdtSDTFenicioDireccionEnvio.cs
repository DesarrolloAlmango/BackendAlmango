/*
				   File: type_SdtSDTFenicioDireccionEnvio
			Description: SDTFenicioDireccionEnvio
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
	[XmlRoot(ElementName="SDTFenicioDireccionEnvio")]
	[XmlType(TypeName="SDTFenicioDireccionEnvio" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTFenicioDireccionEnvio : GxUserType
	{
		public SdtSDTFenicioDireccionEnvio( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTFenicioDireccionEnvio_Pais = "";

			gxTv_SdtSDTFenicioDireccionEnvio_Estado = "";

			gxTv_SdtSDTFenicioDireccionEnvio_Localidad = "";

			gxTv_SdtSDTFenicioDireccionEnvio_Calle = "";

			gxTv_SdtSDTFenicioDireccionEnvio_Numeropuerta = "";

			gxTv_SdtSDTFenicioDireccionEnvio_Numeroapto = "";

			gxTv_SdtSDTFenicioDireccionEnvio_Codigopostal = "";

			gxTv_SdtSDTFenicioDireccionEnvio_Observaciones = "";

		}

		public SdtSDTFenicioDireccionEnvio(IGxContext context)
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
			AddObjectProperty("latitud", gxTpr_Latitud, false);


			AddObjectProperty("longitud", gxTpr_Longitud, false);


			AddObjectProperty("pais", gxTpr_Pais, false);


			AddObjectProperty("estado", gxTpr_Estado, false);


			AddObjectProperty("localidad", gxTpr_Localidad, false);


			AddObjectProperty("calle", gxTpr_Calle, false);


			AddObjectProperty("numeroPuerta", gxTpr_Numeropuerta, false);


			AddObjectProperty("numeroApto", gxTpr_Numeroapto, false);


			AddObjectProperty("codigoPostal", gxTpr_Codigopostal, false);


			AddObjectProperty("observaciones", gxTpr_Observaciones, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="latitud")]
		[XmlElement(ElementName="latitud")]
		public string gxTpr_Latitud_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTFenicioDireccionEnvio_Latitud, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTFenicioDireccionEnvio_Latitud = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Latitud
		{
			get {
				return gxTv_SdtSDTFenicioDireccionEnvio_Latitud; 
			}
			set {
				gxTv_SdtSDTFenicioDireccionEnvio_Latitud = value;
				SetDirty("Latitud");
			}
		}



		[SoapElement(ElementName="longitud")]
		[XmlElement(ElementName="longitud")]
		public string gxTpr_Longitud_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTFenicioDireccionEnvio_Longitud, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTFenicioDireccionEnvio_Longitud = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Longitud
		{
			get {
				return gxTv_SdtSDTFenicioDireccionEnvio_Longitud; 
			}
			set {
				gxTv_SdtSDTFenicioDireccionEnvio_Longitud = value;
				SetDirty("Longitud");
			}
		}




		[SoapElement(ElementName="pais")]
		[XmlElement(ElementName="pais")]
		public string gxTpr_Pais
		{
			get {
				return gxTv_SdtSDTFenicioDireccionEnvio_Pais; 
			}
			set {
				gxTv_SdtSDTFenicioDireccionEnvio_Pais = value;
				SetDirty("Pais");
			}
		}




		[SoapElement(ElementName="estado")]
		[XmlElement(ElementName="estado")]
		public string gxTpr_Estado
		{
			get {
				return gxTv_SdtSDTFenicioDireccionEnvio_Estado; 
			}
			set {
				gxTv_SdtSDTFenicioDireccionEnvio_Estado = value;
				SetDirty("Estado");
			}
		}




		[SoapElement(ElementName="localidad")]
		[XmlElement(ElementName="localidad")]
		public string gxTpr_Localidad
		{
			get {
				return gxTv_SdtSDTFenicioDireccionEnvio_Localidad; 
			}
			set {
				gxTv_SdtSDTFenicioDireccionEnvio_Localidad = value;
				SetDirty("Localidad");
			}
		}




		[SoapElement(ElementName="calle")]
		[XmlElement(ElementName="calle")]
		public string gxTpr_Calle
		{
			get {
				return gxTv_SdtSDTFenicioDireccionEnvio_Calle; 
			}
			set {
				gxTv_SdtSDTFenicioDireccionEnvio_Calle = value;
				SetDirty("Calle");
			}
		}




		[SoapElement(ElementName="numeroPuerta")]
		[XmlElement(ElementName="numeroPuerta")]
		public string gxTpr_Numeropuerta
		{
			get {
				return gxTv_SdtSDTFenicioDireccionEnvio_Numeropuerta; 
			}
			set {
				gxTv_SdtSDTFenicioDireccionEnvio_Numeropuerta = value;
				SetDirty("Numeropuerta");
			}
		}




		[SoapElement(ElementName="numeroApto")]
		[XmlElement(ElementName="numeroApto")]
		public string gxTpr_Numeroapto
		{
			get {
				return gxTv_SdtSDTFenicioDireccionEnvio_Numeroapto; 
			}
			set {
				gxTv_SdtSDTFenicioDireccionEnvio_Numeroapto = value;
				SetDirty("Numeroapto");
			}
		}




		[SoapElement(ElementName="codigoPostal")]
		[XmlElement(ElementName="codigoPostal")]
		public string gxTpr_Codigopostal
		{
			get {
				return gxTv_SdtSDTFenicioDireccionEnvio_Codigopostal; 
			}
			set {
				gxTv_SdtSDTFenicioDireccionEnvio_Codigopostal = value;
				SetDirty("Codigopostal");
			}
		}




		[SoapElement(ElementName="observaciones")]
		[XmlElement(ElementName="observaciones")]
		public string gxTpr_Observaciones
		{
			get {
				return gxTv_SdtSDTFenicioDireccionEnvio_Observaciones; 
			}
			set {
				gxTv_SdtSDTFenicioDireccionEnvio_Observaciones = value;
				SetDirty("Observaciones");
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
			gxTv_SdtSDTFenicioDireccionEnvio_Pais = "";
			gxTv_SdtSDTFenicioDireccionEnvio_Estado = "";
			gxTv_SdtSDTFenicioDireccionEnvio_Localidad = "";
			gxTv_SdtSDTFenicioDireccionEnvio_Calle = "";
			gxTv_SdtSDTFenicioDireccionEnvio_Numeropuerta = "";
			gxTv_SdtSDTFenicioDireccionEnvio_Numeroapto = "";
			gxTv_SdtSDTFenicioDireccionEnvio_Codigopostal = "";
			gxTv_SdtSDTFenicioDireccionEnvio_Observaciones = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected decimal gxTv_SdtSDTFenicioDireccionEnvio_Latitud;
		 

		protected decimal gxTv_SdtSDTFenicioDireccionEnvio_Longitud;
		 

		protected string gxTv_SdtSDTFenicioDireccionEnvio_Pais;
		 

		protected string gxTv_SdtSDTFenicioDireccionEnvio_Estado;
		 

		protected string gxTv_SdtSDTFenicioDireccionEnvio_Localidad;
		 

		protected string gxTv_SdtSDTFenicioDireccionEnvio_Calle;
		 

		protected string gxTv_SdtSDTFenicioDireccionEnvio_Numeropuerta;
		 

		protected string gxTv_SdtSDTFenicioDireccionEnvio_Numeroapto;
		 

		protected string gxTv_SdtSDTFenicioDireccionEnvio_Codigopostal;
		 

		protected string gxTv_SdtSDTFenicioDireccionEnvio_Observaciones;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTFenicioDireccionEnvio", Namespace="AlmangoX")]
	public class SdtSDTFenicioDireccionEnvio_RESTInterface : GxGenericCollectionItem<SdtSDTFenicioDireccionEnvio>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTFenicioDireccionEnvio_RESTInterface( ) : base()
		{	
		}

		public SdtSDTFenicioDireccionEnvio_RESTInterface( SdtSDTFenicioDireccionEnvio psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="latitud", Order=0)]
		public  string gxTpr_Latitud
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Latitud, 10, 5));

			}
			set { 
				sdt.gxTpr_Latitud =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="longitud", Order=1)]
		public  string gxTpr_Longitud
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Longitud, 10, 5));

			}
			set { 
				sdt.gxTpr_Longitud =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="pais", Order=2)]
		public  string gxTpr_Pais
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Pais);

			}
			set { 
				 sdt.gxTpr_Pais = value;
			}
		}

		[DataMember(Name="estado", Order=3)]
		public  string gxTpr_Estado
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Estado);

			}
			set { 
				 sdt.gxTpr_Estado = value;
			}
		}

		[DataMember(Name="localidad", Order=4)]
		public  string gxTpr_Localidad
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Localidad);

			}
			set { 
				 sdt.gxTpr_Localidad = value;
			}
		}

		[DataMember(Name="calle", Order=5)]
		public  string gxTpr_Calle
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Calle);

			}
			set { 
				 sdt.gxTpr_Calle = value;
			}
		}

		[DataMember(Name="numeroPuerta", Order=6)]
		public  string gxTpr_Numeropuerta
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Numeropuerta);

			}
			set { 
				 sdt.gxTpr_Numeropuerta = value;
			}
		}

		[DataMember(Name="numeroApto", Order=7)]
		public  string gxTpr_Numeroapto
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Numeroapto);

			}
			set { 
				 sdt.gxTpr_Numeroapto = value;
			}
		}

		[DataMember(Name="codigoPostal", Order=8)]
		public  string gxTpr_Codigopostal
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Codigopostal);

			}
			set { 
				 sdt.gxTpr_Codigopostal = value;
			}
		}

		[DataMember(Name="observaciones", Order=9)]
		public  string gxTpr_Observaciones
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Observaciones);

			}
			set { 
				 sdt.gxTpr_Observaciones = value;
			}
		}


		#endregion
		public SdtSDTFenicioDireccionEnvio sdt
		{
			get { 
				return (SdtSDTFenicioDireccionEnvio)Sdt;
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
				sdt = new SdtSDTFenicioDireccionEnvio() ;
			}
		}
	}
	#endregion
}