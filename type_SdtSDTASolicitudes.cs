/*
				   File: type_SdtSDTASolicitudes
			Description: SDTASolicitudes
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
	[XmlRoot(ElementName="SDTASolicitudes")]
	[XmlType(TypeName="SDTASolicitudes" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTASolicitudes : GxUserType
	{
		public SdtSDTASolicitudes( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTASolicitudes_Nombre = "";

			gxTv_SdtSDTASolicitudes_Telefono = "";

			gxTv_SdtSDTASolicitudes_Mail = "";

			gxTv_SdtSDTASolicitudes_Paisiso = "";

			gxTv_SdtSDTASolicitudes_Direccion = "";

			gxTv_SdtSDTASolicitudes_Solicitudpagada = "";

			gxTv_SdtSDTASolicitudes_Solicitacotizacion = "";

			gxTv_SdtSDTASolicitudes_Solicitaotroservicio = "";

			gxTv_SdtSDTASolicitudes_Otroserviciodetalle = "";

			gxTv_SdtSDTASolicitudes_Comentario = "";

			gxTv_SdtSDTASolicitudes_Confirmarcondicionesuso = "";

			gxTv_SdtSDTASolicitudes_Proveedorauxiliar = "";

			gxTv_SdtSDTASolicitudes_Paginaone = "";

			gxTv_SdtSDTASolicitudes_Urlorigen = "";

		}

		public SdtSDTASolicitudes(IGxContext context)
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
			AddObjectProperty("Nombre", gxTpr_Nombre, false);


			AddObjectProperty("Telefono", gxTpr_Telefono, false);


			AddObjectProperty("Mail", gxTpr_Mail, false);


			AddObjectProperty("PaisISO", gxTpr_Paisiso, false);


			AddObjectProperty("DepartamentoId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Departamentoid, 18, 0)), false);


			AddObjectProperty("MunicipioId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Municipioid, 18, 0)), false);


			AddObjectProperty("ZonasID", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Zonasid, 18, 0)), false);


			AddObjectProperty("Direccion", gxTpr_Direccion, false);


			AddObjectProperty("MetodoPagosID", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Metodopagosid, 18, 0)), false);


			AddObjectProperty("SolicitudPagada", gxTpr_Solicitudpagada, false);


			AddObjectProperty("SolicitaCotizacion", gxTpr_Solicitacotizacion, false);


			AddObjectProperty("SolicitaOtroServicio", gxTpr_Solicitaotroservicio, false);


			AddObjectProperty("OtroServicioDetalle", gxTpr_Otroserviciodetalle, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Fechainstalacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Fechainstalacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Fechainstalacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("FechaInstalacion", sDateCnv, false);



			AddObjectProperty("TurnoInstalacion", gxTpr_Turnoinstalacion, false);


			AddObjectProperty("Comentario", gxTpr_Comentario, false);


			AddObjectProperty("ConfirmarCondicionesUso", gxTpr_Confirmarcondicionesuso, false);


			AddObjectProperty("ProveedorAuxiliar", gxTpr_Proveedorauxiliar, false);


			AddObjectProperty("CostoXZona", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Costoxzona, 18, 2)), false);


			AddObjectProperty("Descuento", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Descuento, 18, 2)), false);


			AddObjectProperty("DescuentoCupon", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Descuentocupon, 18, 2)), false);


			AddObjectProperty("CuponId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Cuponid, 18, 0)), false);


			AddObjectProperty("PaginaOne", gxTpr_Paginaone, false);


			AddObjectProperty("SolicitudIdCancelar", gxTpr_Solicitudidcancelar, false);


			AddObjectProperty("SolicitudesCotizacion", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Solicitudescotizacion, 18, 2)), false);


			AddObjectProperty("UrlOrigen", gxTpr_Urlorigen, false);

			if (gxTv_SdtSDTASolicitudes_Level1 != null)
			{
				AddObjectProperty("Level1", gxTv_SdtSDTASolicitudes_Level1, false);
			}
			if (gxTv_SdtSDTASolicitudes_Archivo != null)
			{
				AddObjectProperty("Archivo", gxTv_SdtSDTASolicitudes_Archivo, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Nombre")]
		[XmlElement(ElementName="Nombre")]
		public string gxTpr_Nombre
		{
			get {
				return gxTv_SdtSDTASolicitudes_Nombre; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Nombre = value;
				SetDirty("Nombre");
			}
		}




		[SoapElement(ElementName="Telefono")]
		[XmlElement(ElementName="Telefono")]
		public string gxTpr_Telefono
		{
			get {
				return gxTv_SdtSDTASolicitudes_Telefono; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Telefono = value;
				SetDirty("Telefono");
			}
		}




		[SoapElement(ElementName="Mail")]
		[XmlElement(ElementName="Mail")]
		public string gxTpr_Mail
		{
			get {
				return gxTv_SdtSDTASolicitudes_Mail; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Mail = value;
				SetDirty("Mail");
			}
		}




		[SoapElement(ElementName="PaisISO")]
		[XmlElement(ElementName="PaisISO")]
		public string gxTpr_Paisiso
		{
			get {
				return gxTv_SdtSDTASolicitudes_Paisiso; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Paisiso = value;
				SetDirty("Paisiso");
			}
		}




		[SoapElement(ElementName="DepartamentoId")]
		[XmlElement(ElementName="DepartamentoId")]
		public long gxTpr_Departamentoid
		{
			get {
				return gxTv_SdtSDTASolicitudes_Departamentoid; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Departamentoid = value;
				SetDirty("Departamentoid");
			}
		}




		[SoapElement(ElementName="MunicipioId")]
		[XmlElement(ElementName="MunicipioId")]
		public long gxTpr_Municipioid
		{
			get {
				return gxTv_SdtSDTASolicitudes_Municipioid; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Municipioid = value;
				SetDirty("Municipioid");
			}
		}




		[SoapElement(ElementName="ZonasID")]
		[XmlElement(ElementName="ZonasID")]
		public long gxTpr_Zonasid
		{
			get {
				return gxTv_SdtSDTASolicitudes_Zonasid; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Zonasid = value;
				SetDirty("Zonasid");
			}
		}




		[SoapElement(ElementName="Direccion")]
		[XmlElement(ElementName="Direccion")]
		public string gxTpr_Direccion
		{
			get {
				return gxTv_SdtSDTASolicitudes_Direccion; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Direccion = value;
				SetDirty("Direccion");
			}
		}




		[SoapElement(ElementName="MetodoPagosID")]
		[XmlElement(ElementName="MetodoPagosID")]
		public long gxTpr_Metodopagosid
		{
			get {
				return gxTv_SdtSDTASolicitudes_Metodopagosid; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Metodopagosid = value;
				SetDirty("Metodopagosid");
			}
		}




		[SoapElement(ElementName="SolicitudPagada")]
		[XmlElement(ElementName="SolicitudPagada")]
		public string gxTpr_Solicitudpagada
		{
			get {
				return gxTv_SdtSDTASolicitudes_Solicitudpagada; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Solicitudpagada = value;
				SetDirty("Solicitudpagada");
			}
		}




		[SoapElement(ElementName="SolicitaCotizacion")]
		[XmlElement(ElementName="SolicitaCotizacion")]
		public string gxTpr_Solicitacotizacion
		{
			get {
				return gxTv_SdtSDTASolicitudes_Solicitacotizacion; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Solicitacotizacion = value;
				SetDirty("Solicitacotizacion");
			}
		}




		[SoapElement(ElementName="SolicitaOtroServicio")]
		[XmlElement(ElementName="SolicitaOtroServicio")]
		public string gxTpr_Solicitaotroservicio
		{
			get {
				return gxTv_SdtSDTASolicitudes_Solicitaotroservicio; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Solicitaotroservicio = value;
				SetDirty("Solicitaotroservicio");
			}
		}




		[SoapElement(ElementName="OtroServicioDetalle")]
		[XmlElement(ElementName="OtroServicioDetalle")]
		public string gxTpr_Otroserviciodetalle
		{
			get {
				return gxTv_SdtSDTASolicitudes_Otroserviciodetalle; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Otroserviciodetalle = value;
				SetDirty("Otroserviciodetalle");
			}
		}



		[SoapElement(ElementName="FechaInstalacion")]
		[XmlElement(ElementName="FechaInstalacion" , IsNullable=true)]
		public string gxTpr_Fechainstalacion_Nullable
		{
			get {
				if ( gxTv_SdtSDTASolicitudes_Fechainstalacion == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTASolicitudes_Fechainstalacion).value ;
			}
			set {
				gxTv_SdtSDTASolicitudes_Fechainstalacion = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Fechainstalacion
		{
			get {
				return gxTv_SdtSDTASolicitudes_Fechainstalacion; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Fechainstalacion = value;
				SetDirty("Fechainstalacion");
			}
		}



		[SoapElement(ElementName="TurnoInstalacion")]
		[XmlElement(ElementName="TurnoInstalacion")]
		public short gxTpr_Turnoinstalacion
		{
			get {
				return gxTv_SdtSDTASolicitudes_Turnoinstalacion; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Turnoinstalacion = value;
				SetDirty("Turnoinstalacion");
			}
		}




		[SoapElement(ElementName="Comentario")]
		[XmlElement(ElementName="Comentario")]
		public string gxTpr_Comentario
		{
			get {
				return gxTv_SdtSDTASolicitudes_Comentario; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Comentario = value;
				SetDirty("Comentario");
			}
		}




		[SoapElement(ElementName="ConfirmarCondicionesUso")]
		[XmlElement(ElementName="ConfirmarCondicionesUso")]
		public string gxTpr_Confirmarcondicionesuso
		{
			get {
				return gxTv_SdtSDTASolicitudes_Confirmarcondicionesuso; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Confirmarcondicionesuso = value;
				SetDirty("Confirmarcondicionesuso");
			}
		}




		[SoapElement(ElementName="ProveedorAuxiliar")]
		[XmlElement(ElementName="ProveedorAuxiliar")]
		public string gxTpr_Proveedorauxiliar
		{
			get {
				return gxTv_SdtSDTASolicitudes_Proveedorauxiliar; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Proveedorauxiliar = value;
				SetDirty("Proveedorauxiliar");
			}
		}



		[SoapElement(ElementName="CostoXZona")]
		[XmlElement(ElementName="CostoXZona")]
		public string gxTpr_Costoxzona_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTASolicitudes_Costoxzona, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTASolicitudes_Costoxzona = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Costoxzona
		{
			get {
				return gxTv_SdtSDTASolicitudes_Costoxzona; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Costoxzona = value;
				SetDirty("Costoxzona");
			}
		}



		[SoapElement(ElementName="Descuento")]
		[XmlElement(ElementName="Descuento")]
		public string gxTpr_Descuento_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTASolicitudes_Descuento, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTASolicitudes_Descuento = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Descuento
		{
			get {
				return gxTv_SdtSDTASolicitudes_Descuento; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Descuento = value;
				SetDirty("Descuento");
			}
		}



		[SoapElement(ElementName="DescuentoCupon")]
		[XmlElement(ElementName="DescuentoCupon")]
		public string gxTpr_Descuentocupon_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTASolicitudes_Descuentocupon, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTASolicitudes_Descuentocupon = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Descuentocupon
		{
			get {
				return gxTv_SdtSDTASolicitudes_Descuentocupon; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Descuentocupon = value;
				SetDirty("Descuentocupon");
			}
		}




		[SoapElement(ElementName="CuponId")]
		[XmlElement(ElementName="CuponId")]
		public long gxTpr_Cuponid
		{
			get {
				return gxTv_SdtSDTASolicitudes_Cuponid; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Cuponid = value;
				SetDirty("Cuponid");
			}
		}




		[SoapElement(ElementName="PaginaOne")]
		[XmlElement(ElementName="PaginaOne")]
		public string gxTpr_Paginaone
		{
			get {
				return gxTv_SdtSDTASolicitudes_Paginaone; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Paginaone = value;
				SetDirty("Paginaone");
			}
		}




		[SoapElement(ElementName="SolicitudIdCancelar")]
		[XmlElement(ElementName="SolicitudIdCancelar")]
		public long gxTpr_Solicitudidcancelar
		{
			get {
				return gxTv_SdtSDTASolicitudes_Solicitudidcancelar; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Solicitudidcancelar = value;
				SetDirty("Solicitudidcancelar");
			}
		}



		[SoapElement(ElementName="SolicitudesCotizacion")]
		[XmlElement(ElementName="SolicitudesCotizacion")]
		public string gxTpr_Solicitudescotizacion_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTASolicitudes_Solicitudescotizacion, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTASolicitudes_Solicitudescotizacion = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Solicitudescotizacion
		{
			get {
				return gxTv_SdtSDTASolicitudes_Solicitudescotizacion; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Solicitudescotizacion = value;
				SetDirty("Solicitudescotizacion");
			}
		}




		[SoapElement(ElementName="UrlOrigen")]
		[XmlElement(ElementName="UrlOrigen")]
		public string gxTpr_Urlorigen
		{
			get {
				return gxTv_SdtSDTASolicitudes_Urlorigen; 
			}
			set {
				gxTv_SdtSDTASolicitudes_Urlorigen = value;
				SetDirty("Urlorigen");
			}
		}




		[SoapElement(ElementName="Level1" )]
		[XmlArray(ElementName="Level1"  )]
		[XmlArrayItemAttribute(ElementName="Items" , IsNullable=false )]
		public GXBaseCollection<SdtSDTASolicitudes_Items> gxTpr_Level1
		{
			get {
				if ( gxTv_SdtSDTASolicitudes_Level1 == null )
				{
					gxTv_SdtSDTASolicitudes_Level1 = new GXBaseCollection<SdtSDTASolicitudes_Items>( context, "SDTASolicitudes.Items", "");
				}
				SetDirty("Level1");
				return gxTv_SdtSDTASolicitudes_Level1;
			}
			set {
				gxTv_SdtSDTASolicitudes_Level1_N = false;
				gxTv_SdtSDTASolicitudes_Level1 = value;
				SetDirty("Level1");
			}
		}

		public void gxTv_SdtSDTASolicitudes_Level1_SetNull()
		{
			gxTv_SdtSDTASolicitudes_Level1_N = true;
			gxTv_SdtSDTASolicitudes_Level1 = null;
		}

		public bool gxTv_SdtSDTASolicitudes_Level1_IsNull()
		{
			return gxTv_SdtSDTASolicitudes_Level1 == null;
		}
		public bool ShouldSerializegxTpr_Level1_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTASolicitudes_Level1 != null && gxTv_SdtSDTASolicitudes_Level1.Count > 0;

		}



		[SoapElement(ElementName="Archivo" )]
		[XmlArray(ElementName="Archivo"  )]
		[XmlArrayItemAttribute(ElementName="ArchivoItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTASolicitudes_ArchivoItem> gxTpr_Archivo
		{
			get {
				if ( gxTv_SdtSDTASolicitudes_Archivo == null )
				{
					gxTv_SdtSDTASolicitudes_Archivo = new GXBaseCollection<SdtSDTASolicitudes_ArchivoItem>( context, "SDTASolicitudes.ArchivoItem", "");
				}
				SetDirty("Archivo");
				return gxTv_SdtSDTASolicitudes_Archivo;
			}
			set {
				gxTv_SdtSDTASolicitudes_Archivo_N = false;
				gxTv_SdtSDTASolicitudes_Archivo = value;
				SetDirty("Archivo");
			}
		}

		public void gxTv_SdtSDTASolicitudes_Archivo_SetNull()
		{
			gxTv_SdtSDTASolicitudes_Archivo_N = true;
			gxTv_SdtSDTASolicitudes_Archivo = null;
		}

		public bool gxTv_SdtSDTASolicitudes_Archivo_IsNull()
		{
			return gxTv_SdtSDTASolicitudes_Archivo == null;
		}
		public bool ShouldSerializegxTpr_Archivo_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTASolicitudes_Archivo != null && gxTv_SdtSDTASolicitudes_Archivo.Count > 0;

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
			gxTv_SdtSDTASolicitudes_Nombre = "";
			gxTv_SdtSDTASolicitudes_Telefono = "";
			gxTv_SdtSDTASolicitudes_Mail = "";
			gxTv_SdtSDTASolicitudes_Paisiso = "";



			gxTv_SdtSDTASolicitudes_Direccion = "";

			gxTv_SdtSDTASolicitudes_Solicitudpagada = "";
			gxTv_SdtSDTASolicitudes_Solicitacotizacion = "";
			gxTv_SdtSDTASolicitudes_Solicitaotroservicio = "";
			gxTv_SdtSDTASolicitudes_Otroserviciodetalle = "";


			gxTv_SdtSDTASolicitudes_Comentario = "";
			gxTv_SdtSDTASolicitudes_Confirmarcondicionesuso = "";
			gxTv_SdtSDTASolicitudes_Proveedorauxiliar = "";



			gxTv_SdtSDTASolicitudes_Cuponid = 1234;
			gxTv_SdtSDTASolicitudes_Paginaone = "";


			gxTv_SdtSDTASolicitudes_Urlorigen = "";

			gxTv_SdtSDTASolicitudes_Level1_N = true;


			gxTv_SdtSDTASolicitudes_Archivo_N = true;

			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected string gxTv_SdtSDTASolicitudes_Nombre;
		 

		protected string gxTv_SdtSDTASolicitudes_Telefono;
		 

		protected string gxTv_SdtSDTASolicitudes_Mail;
		 

		protected string gxTv_SdtSDTASolicitudes_Paisiso;
		 

		protected long gxTv_SdtSDTASolicitudes_Departamentoid;
		 

		protected long gxTv_SdtSDTASolicitudes_Municipioid;
		 

		protected long gxTv_SdtSDTASolicitudes_Zonasid;
		 

		protected string gxTv_SdtSDTASolicitudes_Direccion;
		 

		protected long gxTv_SdtSDTASolicitudes_Metodopagosid;
		 

		protected string gxTv_SdtSDTASolicitudes_Solicitudpagada;
		 

		protected string gxTv_SdtSDTASolicitudes_Solicitacotizacion;
		 

		protected string gxTv_SdtSDTASolicitudes_Solicitaotroservicio;
		 

		protected string gxTv_SdtSDTASolicitudes_Otroserviciodetalle;
		 

		protected DateTime gxTv_SdtSDTASolicitudes_Fechainstalacion;
		 

		protected short gxTv_SdtSDTASolicitudes_Turnoinstalacion;
		 

		protected string gxTv_SdtSDTASolicitudes_Comentario;
		 

		protected string gxTv_SdtSDTASolicitudes_Confirmarcondicionesuso;
		 

		protected string gxTv_SdtSDTASolicitudes_Proveedorauxiliar;
		 

		protected decimal gxTv_SdtSDTASolicitudes_Costoxzona;
		 

		protected decimal gxTv_SdtSDTASolicitudes_Descuento;
		 

		protected decimal gxTv_SdtSDTASolicitudes_Descuentocupon;
		 

		protected long gxTv_SdtSDTASolicitudes_Cuponid;
		 

		protected string gxTv_SdtSDTASolicitudes_Paginaone;
		 

		protected long gxTv_SdtSDTASolicitudes_Solicitudidcancelar;
		 

		protected decimal gxTv_SdtSDTASolicitudes_Solicitudescotizacion;
		 

		protected string gxTv_SdtSDTASolicitudes_Urlorigen;
		 
		protected bool gxTv_SdtSDTASolicitudes_Level1_N;
		protected GXBaseCollection<SdtSDTASolicitudes_Items> gxTv_SdtSDTASolicitudes_Level1 = null; 

		protected bool gxTv_SdtSDTASolicitudes_Archivo_N;
		protected GXBaseCollection<SdtSDTASolicitudes_ArchivoItem> gxTv_SdtSDTASolicitudes_Archivo = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTASolicitudes", Namespace="AlmangoX")]
	public class SdtSDTASolicitudes_RESTInterface : GxGenericCollectionItem<SdtSDTASolicitudes>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTASolicitudes_RESTInterface( ) : base()
		{	
		}

		public SdtSDTASolicitudes_RESTInterface( SdtSDTASolicitudes psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Nombre", Order=0)]
		public  string gxTpr_Nombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Nombre);

			}
			set { 
				 sdt.gxTpr_Nombre = value;
			}
		}

		[DataMember(Name="Telefono", Order=1)]
		public  string gxTpr_Telefono
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Telefono);

			}
			set { 
				 sdt.gxTpr_Telefono = value;
			}
		}

		[DataMember(Name="Mail", Order=2)]
		public  string gxTpr_Mail
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mail);

			}
			set { 
				 sdt.gxTpr_Mail = value;
			}
		}

		[DataMember(Name="PaisISO", Order=3)]
		public  string gxTpr_Paisiso
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Paisiso);

			}
			set { 
				 sdt.gxTpr_Paisiso = value;
			}
		}

		[DataMember(Name="DepartamentoId", Order=4)]
		public  string gxTpr_Departamentoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Departamentoid, 18, 0));

			}
			set { 
				sdt.gxTpr_Departamentoid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MunicipioId", Order=5)]
		public  string gxTpr_Municipioid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Municipioid, 18, 0));

			}
			set { 
				sdt.gxTpr_Municipioid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ZonasID", Order=6)]
		public  string gxTpr_Zonasid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Zonasid, 18, 0));

			}
			set { 
				sdt.gxTpr_Zonasid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Direccion", Order=7)]
		public  string gxTpr_Direccion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Direccion);

			}
			set { 
				 sdt.gxTpr_Direccion = value;
			}
		}

		[DataMember(Name="MetodoPagosID", Order=8)]
		public  string gxTpr_Metodopagosid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Metodopagosid, 18, 0));

			}
			set { 
				sdt.gxTpr_Metodopagosid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="SolicitudPagada", Order=9)]
		public  string gxTpr_Solicitudpagada
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Solicitudpagada);

			}
			set { 
				 sdt.gxTpr_Solicitudpagada = value;
			}
		}

		[DataMember(Name="SolicitaCotizacion", Order=10)]
		public  string gxTpr_Solicitacotizacion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Solicitacotizacion);

			}
			set { 
				 sdt.gxTpr_Solicitacotizacion = value;
			}
		}

		[DataMember(Name="SolicitaOtroServicio", Order=11)]
		public  string gxTpr_Solicitaotroservicio
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Solicitaotroservicio);

			}
			set { 
				 sdt.gxTpr_Solicitaotroservicio = value;
			}
		}

		[DataMember(Name="OtroServicioDetalle", Order=12)]
		public  string gxTpr_Otroserviciodetalle
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Otroserviciodetalle);

			}
			set { 
				 sdt.gxTpr_Otroserviciodetalle = value;
			}
		}

		[DataMember(Name="FechaInstalacion", Order=13)]
		public  string gxTpr_Fechainstalacion
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Fechainstalacion);

			}
			set { 
				sdt.gxTpr_Fechainstalacion = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="TurnoInstalacion", Order=14)]
		public short gxTpr_Turnoinstalacion
		{
			get { 
				return sdt.gxTpr_Turnoinstalacion;

			}
			set { 
				sdt.gxTpr_Turnoinstalacion = value;
			}
		}

		[DataMember(Name="Comentario", Order=15)]
		public  string gxTpr_Comentario
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Comentario);

			}
			set { 
				 sdt.gxTpr_Comentario = value;
			}
		}

		[DataMember(Name="ConfirmarCondicionesUso", Order=16)]
		public  string gxTpr_Confirmarcondicionesuso
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Confirmarcondicionesuso);

			}
			set { 
				 sdt.gxTpr_Confirmarcondicionesuso = value;
			}
		}

		[DataMember(Name="ProveedorAuxiliar", Order=17)]
		public  string gxTpr_Proveedorauxiliar
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Proveedorauxiliar);

			}
			set { 
				 sdt.gxTpr_Proveedorauxiliar = value;
			}
		}

		[DataMember(Name="CostoXZona", Order=18)]
		public  string gxTpr_Costoxzona
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Costoxzona, 18, 2));

			}
			set { 
				sdt.gxTpr_Costoxzona =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Descuento", Order=19)]
		public  string gxTpr_Descuento
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Descuento, 18, 2));

			}
			set { 
				sdt.gxTpr_Descuento =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="DescuentoCupon", Order=20)]
		public  string gxTpr_Descuentocupon
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Descuentocupon, 18, 2));

			}
			set { 
				sdt.gxTpr_Descuentocupon =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="CuponId", Order=21)]
		public  string gxTpr_Cuponid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Cuponid, 18, 0));

			}
			set { 
				sdt.gxTpr_Cuponid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="PaginaOne", Order=22)]
		public  string gxTpr_Paginaone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Paginaone);

			}
			set { 
				 sdt.gxTpr_Paginaone = value;
			}
		}

		[DataMember(Name="SolicitudIdCancelar", Order=23)]
		public  string gxTpr_Solicitudidcancelar
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Solicitudidcancelar, 10, 0));

			}
			set { 
				sdt.gxTpr_Solicitudidcancelar = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="SolicitudesCotizacion", Order=24)]
		public  string gxTpr_Solicitudescotizacion
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Solicitudescotizacion, 18, 2));

			}
			set { 
				sdt.gxTpr_Solicitudescotizacion =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="UrlOrigen", Order=25)]
		public  string gxTpr_Urlorigen
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Urlorigen);

			}
			set { 
				 sdt.gxTpr_Urlorigen = value;
			}
		}

		[DataMember(Name="Level1", Order=26, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTASolicitudes_Items_RESTInterface> gxTpr_Level1
		{
			get {
				if (sdt.ShouldSerializegxTpr_Level1_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTASolicitudes_Items_RESTInterface>(sdt.gxTpr_Level1);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Level1);
			}
		}

		[DataMember(Name="Archivo", Order=27, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTASolicitudes_ArchivoItem_RESTInterface> gxTpr_Archivo
		{
			get {
				if (sdt.ShouldSerializegxTpr_Archivo_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTASolicitudes_ArchivoItem_RESTInterface>(sdt.gxTpr_Archivo);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Archivo);
			}
		}


		#endregion
		public SdtSDTASolicitudes sdt
		{
			get { 
				return (SdtSDTASolicitudes)Sdt;
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
				sdt = new SdtSDTASolicitudes() ;
			}
		}
	}
	#endregion
}