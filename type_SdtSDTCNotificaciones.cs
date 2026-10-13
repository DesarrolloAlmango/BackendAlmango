/*
				   File: type_SdtSDTCNotificaciones
			Description: SDTCNotificaciones
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
	[XmlRoot(ElementName="SDTCNotificaciones")]
	[XmlType(TypeName="SDTCNotificaciones" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTCNotificaciones : GxUserType
	{
		public SdtSDTCNotificaciones( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTCNotificaciones_Nuevoestado = "";

			gxTv_SdtSDTCNotificaciones_Mensajefijo = "";

			gxTv_SdtSDTCNotificaciones_Mensajedinamico = "";

			gxTv_SdtSDTCNotificaciones_Emailcliente = "";

			gxTv_SdtSDTCNotificaciones_Nombrecliente = "";

			gxTv_SdtSDTCNotificaciones_Emailprofesional = "";

			gxTv_SdtSDTCNotificaciones_Nombreprofesional = "";

			gxTv_SdtSDTCNotificaciones_Emailoperador = "";

			gxTv_SdtSDTCNotificaciones_Nombreoperador = "";

			gxTv_SdtSDTCNotificaciones_Nombrecomercio = "";

			gxTv_SdtSDTCNotificaciones_Emailcomercio = "";

			gxTv_SdtSDTCNotificaciones_Urladjunto1 = "";

			gxTv_SdtSDTCNotificaciones_Mensajeurl1 = "";

			gxTv_SdtSDTCNotificaciones_Urladjunto2 = "";

			gxTv_SdtSDTCNotificaciones_Mensajeurl2 = "";

			gxTv_SdtSDTCNotificaciones_Adjuntofile = "";

		}

		public SdtSDTCNotificaciones(IGxContext context)
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
			AddObjectProperty("SolicitudesID", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Solicitudesid, 18, 0)), false);


			AddObjectProperty("MailDesignId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Maildesignid, 18, 0)), false);


			AddObjectProperty("EstadosGenericosId", gxTpr_Estadosgenericosid, false);


			AddObjectProperty("NuevoEstado", gxTpr_Nuevoestado, false);


			AddObjectProperty("MensajeFijo", gxTpr_Mensajefijo, false);


			AddObjectProperty("MensajeDinamico", gxTpr_Mensajedinamico, false);


			AddObjectProperty("eMailCliente", gxTpr_Emailcliente, false);


			AddObjectProperty("NombreCliente", gxTpr_Nombrecliente, false);


			AddObjectProperty("eMailProfesional", gxTpr_Emailprofesional, false);


			AddObjectProperty("NombreProfesional", gxTpr_Nombreprofesional, false);


			AddObjectProperty("emailOperador", gxTpr_Emailoperador, false);


			AddObjectProperty("NombreOperador", gxTpr_Nombreoperador, false);


			AddObjectProperty("NombreComercio", gxTpr_Nombrecomercio, false);


			AddObjectProperty("emailComercio", gxTpr_Emailcomercio, false);


			AddObjectProperty("UrlAdjunto1", gxTpr_Urladjunto1, false);


			AddObjectProperty("MensajeURL1", gxTpr_Mensajeurl1, false);


			AddObjectProperty("UrlAdjunto2", gxTpr_Urladjunto2, false);


			AddObjectProperty("MensajeURL2", gxTpr_Mensajeurl2, false);


			AddObjectProperty("AdjuntoFile", gxTpr_Adjuntofile, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="SolicitudesID")]
		[XmlElement(ElementName="SolicitudesID")]
		public long gxTpr_Solicitudesid
		{
			get {
				return gxTv_SdtSDTCNotificaciones_Solicitudesid; 
			}
			set {
				gxTv_SdtSDTCNotificaciones_Solicitudesid = value;
				SetDirty("Solicitudesid");
			}
		}




		[SoapElement(ElementName="MailDesignId")]
		[XmlElement(ElementName="MailDesignId")]
		public long gxTpr_Maildesignid
		{
			get {
				return gxTv_SdtSDTCNotificaciones_Maildesignid; 
			}
			set {
				gxTv_SdtSDTCNotificaciones_Maildesignid = value;
				SetDirty("Maildesignid");
			}
		}




		[SoapElement(ElementName="EstadosGenericosId")]
		[XmlElement(ElementName="EstadosGenericosId")]
		public int gxTpr_Estadosgenericosid
		{
			get {
				return gxTv_SdtSDTCNotificaciones_Estadosgenericosid; 
			}
			set {
				gxTv_SdtSDTCNotificaciones_Estadosgenericosid = value;
				SetDirty("Estadosgenericosid");
			}
		}




		[SoapElement(ElementName="NuevoEstado")]
		[XmlElement(ElementName="NuevoEstado")]
		public string gxTpr_Nuevoestado
		{
			get {
				return gxTv_SdtSDTCNotificaciones_Nuevoestado; 
			}
			set {
				gxTv_SdtSDTCNotificaciones_Nuevoestado = value;
				SetDirty("Nuevoestado");
			}
		}




		[SoapElement(ElementName="MensajeFijo")]
		[XmlElement(ElementName="MensajeFijo")]
		public string gxTpr_Mensajefijo
		{
			get {
				return gxTv_SdtSDTCNotificaciones_Mensajefijo; 
			}
			set {
				gxTv_SdtSDTCNotificaciones_Mensajefijo = value;
				SetDirty("Mensajefijo");
			}
		}




		[SoapElement(ElementName="MensajeDinamico")]
		[XmlElement(ElementName="MensajeDinamico")]
		public string gxTpr_Mensajedinamico
		{
			get {
				return gxTv_SdtSDTCNotificaciones_Mensajedinamico; 
			}
			set {
				gxTv_SdtSDTCNotificaciones_Mensajedinamico = value;
				SetDirty("Mensajedinamico");
			}
		}




		[SoapElement(ElementName="eMailCliente")]
		[XmlElement(ElementName="eMailCliente")]
		public string gxTpr_Emailcliente
		{
			get {
				return gxTv_SdtSDTCNotificaciones_Emailcliente; 
			}
			set {
				gxTv_SdtSDTCNotificaciones_Emailcliente = value;
				SetDirty("Emailcliente");
			}
		}




		[SoapElement(ElementName="NombreCliente")]
		[XmlElement(ElementName="NombreCliente")]
		public string gxTpr_Nombrecliente
		{
			get {
				return gxTv_SdtSDTCNotificaciones_Nombrecliente; 
			}
			set {
				gxTv_SdtSDTCNotificaciones_Nombrecliente = value;
				SetDirty("Nombrecliente");
			}
		}




		[SoapElement(ElementName="eMailProfesional")]
		[XmlElement(ElementName="eMailProfesional")]
		public string gxTpr_Emailprofesional
		{
			get {
				return gxTv_SdtSDTCNotificaciones_Emailprofesional; 
			}
			set {
				gxTv_SdtSDTCNotificaciones_Emailprofesional = value;
				SetDirty("Emailprofesional");
			}
		}




		[SoapElement(ElementName="NombreProfesional")]
		[XmlElement(ElementName="NombreProfesional")]
		public string gxTpr_Nombreprofesional
		{
			get {
				return gxTv_SdtSDTCNotificaciones_Nombreprofesional; 
			}
			set {
				gxTv_SdtSDTCNotificaciones_Nombreprofesional = value;
				SetDirty("Nombreprofesional");
			}
		}




		[SoapElement(ElementName="emailOperador")]
		[XmlElement(ElementName="emailOperador")]
		public string gxTpr_Emailoperador
		{
			get {
				return gxTv_SdtSDTCNotificaciones_Emailoperador; 
			}
			set {
				gxTv_SdtSDTCNotificaciones_Emailoperador = value;
				SetDirty("Emailoperador");
			}
		}




		[SoapElement(ElementName="NombreOperador")]
		[XmlElement(ElementName="NombreOperador")]
		public string gxTpr_Nombreoperador
		{
			get {
				return gxTv_SdtSDTCNotificaciones_Nombreoperador; 
			}
			set {
				gxTv_SdtSDTCNotificaciones_Nombreoperador = value;
				SetDirty("Nombreoperador");
			}
		}




		[SoapElement(ElementName="NombreComercio")]
		[XmlElement(ElementName="NombreComercio")]
		public string gxTpr_Nombrecomercio
		{
			get {
				return gxTv_SdtSDTCNotificaciones_Nombrecomercio; 
			}
			set {
				gxTv_SdtSDTCNotificaciones_Nombrecomercio = value;
				SetDirty("Nombrecomercio");
			}
		}




		[SoapElement(ElementName="emailComercio")]
		[XmlElement(ElementName="emailComercio")]
		public string gxTpr_Emailcomercio
		{
			get {
				return gxTv_SdtSDTCNotificaciones_Emailcomercio; 
			}
			set {
				gxTv_SdtSDTCNotificaciones_Emailcomercio = value;
				SetDirty("Emailcomercio");
			}
		}




		[SoapElement(ElementName="UrlAdjunto1")]
		[XmlElement(ElementName="UrlAdjunto1")]
		public string gxTpr_Urladjunto1
		{
			get {
				return gxTv_SdtSDTCNotificaciones_Urladjunto1; 
			}
			set {
				gxTv_SdtSDTCNotificaciones_Urladjunto1 = value;
				SetDirty("Urladjunto1");
			}
		}




		[SoapElement(ElementName="MensajeURL1")]
		[XmlElement(ElementName="MensajeURL1")]
		public string gxTpr_Mensajeurl1
		{
			get {
				return gxTv_SdtSDTCNotificaciones_Mensajeurl1; 
			}
			set {
				gxTv_SdtSDTCNotificaciones_Mensajeurl1 = value;
				SetDirty("Mensajeurl1");
			}
		}




		[SoapElement(ElementName="UrlAdjunto2")]
		[XmlElement(ElementName="UrlAdjunto2")]
		public string gxTpr_Urladjunto2
		{
			get {
				return gxTv_SdtSDTCNotificaciones_Urladjunto2; 
			}
			set {
				gxTv_SdtSDTCNotificaciones_Urladjunto2 = value;
				SetDirty("Urladjunto2");
			}
		}




		[SoapElement(ElementName="MensajeURL2")]
		[XmlElement(ElementName="MensajeURL2")]
		public string gxTpr_Mensajeurl2
		{
			get {
				return gxTv_SdtSDTCNotificaciones_Mensajeurl2; 
			}
			set {
				gxTv_SdtSDTCNotificaciones_Mensajeurl2 = value;
				SetDirty("Mensajeurl2");
			}
		}



		[SoapElement(ElementName="AdjuntoFile")]
		[XmlElement(ElementName="AdjuntoFile")]
		[GxUpload()]
		public byte[] gxTpr_Adjuntofile_Blob
		{
			get{
				IGxContext context = this.context == null ? new GxContext() : this.context;
				return context.FileToByteArray(gxTv_SdtSDTCNotificaciones_Adjuntofile) ;
			}
			set {
				IGxContext context = this.context == null ? new GxContext() : this.context;
				gxTv_SdtSDTCNotificaciones_Adjuntofile=context.FileFromByteArray( value) ;
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public string gxTpr_Adjuntofile
		{
			get {
				return gxTv_SdtSDTCNotificaciones_Adjuntofile; 
			}
			set {
				gxTv_SdtSDTCNotificaciones_Adjuntofile = value;
				SetDirty("Adjuntofile");
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
			gxTv_SdtSDTCNotificaciones_Nuevoestado = "";
			gxTv_SdtSDTCNotificaciones_Mensajefijo = "";
			gxTv_SdtSDTCNotificaciones_Mensajedinamico = "";
			gxTv_SdtSDTCNotificaciones_Emailcliente = "";
			gxTv_SdtSDTCNotificaciones_Nombrecliente = "";
			gxTv_SdtSDTCNotificaciones_Emailprofesional = "";
			gxTv_SdtSDTCNotificaciones_Nombreprofesional = "";
			gxTv_SdtSDTCNotificaciones_Emailoperador = "";
			gxTv_SdtSDTCNotificaciones_Nombreoperador = "";
			gxTv_SdtSDTCNotificaciones_Nombrecomercio = "";
			gxTv_SdtSDTCNotificaciones_Emailcomercio = "";
			gxTv_SdtSDTCNotificaciones_Urladjunto1 = "";
			gxTv_SdtSDTCNotificaciones_Mensajeurl1 = "";
			gxTv_SdtSDTCNotificaciones_Urladjunto2 = "";
			gxTv_SdtSDTCNotificaciones_Mensajeurl2 = "";
			gxTv_SdtSDTCNotificaciones_Adjuntofile = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected long gxTv_SdtSDTCNotificaciones_Solicitudesid;
		 

		protected long gxTv_SdtSDTCNotificaciones_Maildesignid;
		 

		protected int gxTv_SdtSDTCNotificaciones_Estadosgenericosid;
		 

		protected string gxTv_SdtSDTCNotificaciones_Nuevoestado;
		 

		protected string gxTv_SdtSDTCNotificaciones_Mensajefijo;
		 

		protected string gxTv_SdtSDTCNotificaciones_Mensajedinamico;
		 

		protected string gxTv_SdtSDTCNotificaciones_Emailcliente;
		 

		protected string gxTv_SdtSDTCNotificaciones_Nombrecliente;
		 

		protected string gxTv_SdtSDTCNotificaciones_Emailprofesional;
		 

		protected string gxTv_SdtSDTCNotificaciones_Nombreprofesional;
		 

		protected string gxTv_SdtSDTCNotificaciones_Emailoperador;
		 

		protected string gxTv_SdtSDTCNotificaciones_Nombreoperador;
		 

		protected string gxTv_SdtSDTCNotificaciones_Nombrecomercio;
		 

		protected string gxTv_SdtSDTCNotificaciones_Emailcomercio;
		 

		protected string gxTv_SdtSDTCNotificaciones_Urladjunto1;
		 

		protected string gxTv_SdtSDTCNotificaciones_Mensajeurl1;
		 

		protected string gxTv_SdtSDTCNotificaciones_Urladjunto2;
		 

		protected string gxTv_SdtSDTCNotificaciones_Mensajeurl2;
		 

		protected string gxTv_SdtSDTCNotificaciones_Adjuntofile;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTCNotificaciones", Namespace="AlmangoX")]
	public class SdtSDTCNotificaciones_RESTInterface : GxGenericCollectionItem<SdtSDTCNotificaciones>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTCNotificaciones_RESTInterface( ) : base()
		{	
		}

		public SdtSDTCNotificaciones_RESTInterface( SdtSDTCNotificaciones psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="SolicitudesID", Order=0)]
		public  string gxTpr_Solicitudesid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Solicitudesid, 18, 0));

			}
			set { 
				sdt.gxTpr_Solicitudesid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MailDesignId", Order=1)]
		public  string gxTpr_Maildesignid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Maildesignid, 18, 0));

			}
			set { 
				sdt.gxTpr_Maildesignid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="EstadosGenericosId", Order=2)]
		public int gxTpr_Estadosgenericosid
		{
			get { 
				return sdt.gxTpr_Estadosgenericosid;

			}
			set { 
				sdt.gxTpr_Estadosgenericosid = value;
			}
		}

		[DataMember(Name="NuevoEstado", Order=3)]
		public  string gxTpr_Nuevoestado
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Nuevoestado);

			}
			set { 
				 sdt.gxTpr_Nuevoestado = value;
			}
		}

		[DataMember(Name="MensajeFijo", Order=4)]
		public  string gxTpr_Mensajefijo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mensajefijo);

			}
			set { 
				 sdt.gxTpr_Mensajefijo = value;
			}
		}

		[DataMember(Name="MensajeDinamico", Order=5)]
		public  string gxTpr_Mensajedinamico
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mensajedinamico);

			}
			set { 
				 sdt.gxTpr_Mensajedinamico = value;
			}
		}

		[DataMember(Name="eMailCliente", Order=6)]
		public  string gxTpr_Emailcliente
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Emailcliente);

			}
			set { 
				 sdt.gxTpr_Emailcliente = value;
			}
		}

		[DataMember(Name="NombreCliente", Order=7)]
		public  string gxTpr_Nombrecliente
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Nombrecliente);

			}
			set { 
				 sdt.gxTpr_Nombrecliente = value;
			}
		}

		[DataMember(Name="eMailProfesional", Order=8)]
		public  string gxTpr_Emailprofesional
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Emailprofesional);

			}
			set { 
				 sdt.gxTpr_Emailprofesional = value;
			}
		}

		[DataMember(Name="NombreProfesional", Order=9)]
		public  string gxTpr_Nombreprofesional
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Nombreprofesional);

			}
			set { 
				 sdt.gxTpr_Nombreprofesional = value;
			}
		}

		[DataMember(Name="emailOperador", Order=10)]
		public  string gxTpr_Emailoperador
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Emailoperador);

			}
			set { 
				 sdt.gxTpr_Emailoperador = value;
			}
		}

		[DataMember(Name="NombreOperador", Order=11)]
		public  string gxTpr_Nombreoperador
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Nombreoperador);

			}
			set { 
				 sdt.gxTpr_Nombreoperador = value;
			}
		}

		[DataMember(Name="NombreComercio", Order=12)]
		public  string gxTpr_Nombrecomercio
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Nombrecomercio);

			}
			set { 
				 sdt.gxTpr_Nombrecomercio = value;
			}
		}

		[DataMember(Name="emailComercio", Order=13)]
		public  string gxTpr_Emailcomercio
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Emailcomercio);

			}
			set { 
				 sdt.gxTpr_Emailcomercio = value;
			}
		}

		[DataMember(Name="UrlAdjunto1", Order=14)]
		public  string gxTpr_Urladjunto1
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Urladjunto1);

			}
			set { 
				 sdt.gxTpr_Urladjunto1 = value;
			}
		}

		[DataMember(Name="MensajeURL1", Order=15)]
		public  string gxTpr_Mensajeurl1
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mensajeurl1);

			}
			set { 
				 sdt.gxTpr_Mensajeurl1 = value;
			}
		}

		[DataMember(Name="UrlAdjunto2", Order=16)]
		public  string gxTpr_Urladjunto2
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Urladjunto2);

			}
			set { 
				 sdt.gxTpr_Urladjunto2 = value;
			}
		}

		[DataMember(Name="MensajeURL2", Order=17)]
		public  string gxTpr_Mensajeurl2
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mensajeurl2);

			}
			set { 
				 sdt.gxTpr_Mensajeurl2 = value;
			}
		}

		[DataMember(Name="AdjuntoFile", Order=18)]
		[GxUpload()]
		public  string gxTpr_Adjuntofile
		{
			get { 
				return PathUtil.RelativePath( sdt.gxTpr_Adjuntofile);

			}
			set { 
				 sdt.gxTpr_Adjuntofile = value;
			}
		}


		#endregion
		public SdtSDTCNotificaciones sdt
		{
			get { 
				return (SdtSDTCNotificaciones)Sdt;
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
				sdt = new SdtSDTCNotificaciones() ;
			}
		}
	}
	#endregion
}