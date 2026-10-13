/*
				   File: type_SdtSDTSolicitudes
			Description: SDTSolicitudes
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
	[XmlRoot(ElementName="SDTSolicitudes")]
	[XmlType(TypeName="SDTSolicitudes" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTSolicitudes : GxUserType
	{
		public SdtSDTSolicitudes( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTSolicitudes_Solicitudesnombre = "";

			gxTv_SdtSDTSolicitudes_Proveedornombre = "";

			gxTv_SdtSDTSolicitudes_Solicitudestelefono = "";

			gxTv_SdtSDTSolicitudes_Solicitudesmail = "";

			gxTv_SdtSDTSolicitudes_Paisid = "";

			gxTv_SdtSDTSolicitudes_Departamentonombre = "";

			gxTv_SdtSDTSolicitudes_Municipionombre = "";

			gxTv_SdtSDTSolicitudes_Solicitudesdireccion = "";

			gxTv_SdtSDTSolicitudes_Postulacionhoracierre = "";

			gxTv_SdtSDTSolicitudes_Postulaciontipofecha = "";

			gxTv_SdtSDTSolicitudes_Serviciosnombre = "";

			gxTv_SdtSDTSolicitudes_Solicitudesnotificacion = "";

			gxTv_SdtSDTSolicitudes_Solicitudesnota = "";

			gxTv_SdtSDTSolicitudes_Metodopagosnombre = "";

			gxTv_SdtSDTSolicitudes_Solicitudescomentario = "";

			gxTv_SdtSDTSolicitudes_Solicitudeshorainstalacion = "";

			gxTv_SdtSDTSolicitudes_Solicitudesfechaactualizacion = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDTSolicitudes_Solicitudesotros3 = "";

			gxTv_SdtSDTSolicitudes_Solicitudesotros2 = "";

			gxTv_SdtSDTSolicitudes_Solicitudesotros1 = "";

			gxTv_SdtSDTSolicitudes_Estadossolnombre = "";

			gxTv_SdtSDTSolicitudes_Estadossoltipo = "";

			gxTv_SdtSDTSolicitudes_Solicitudserviciosolcoti = "";

			gxTv_SdtSDTSolicitudes_Modopago = "";

			gxTv_SdtSDTSolicitudes_Ganancia = "";

			gxTv_SdtSDTSolicitudes_Deduccion = "";

			gxTv_SdtSDTSolicitudes_Feedbackcomentario = "";

			gxTv_SdtSDTSolicitudes_Solicitudessubtipo = "";

			gxTv_SdtSDTSolicitudes_Solicitudessubtipodesc = "";

			gxTv_SdtSDTSolicitudes_Solicitudservicioorigenpago = "";

			gxTv_SdtSDTSolicitudes_Stcomerciosnombre = "";


		}

		public SdtSDTSolicitudes(IGxContext context)
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


			AddObjectProperty("SolicitudesNombre", gxTpr_Solicitudesnombre, false);


			AddObjectProperty("ProveedorNombre", gxTpr_Proveedornombre, false);


			AddObjectProperty("SolicitudesTelefono", gxTpr_Solicitudestelefono, false);


			AddObjectProperty("SolicitudesMail", gxTpr_Solicitudesmail, false);


			AddObjectProperty("PaisID", gxTpr_Paisid, false);


			AddObjectProperty("DepartamentoId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Departamentoid, 18, 0)), false);


			AddObjectProperty("DepartamentoNombre", gxTpr_Departamentonombre, false);


			AddObjectProperty("DepartamentoMunicipioId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Departamentomunicipioid, 18, 0)), false);


			AddObjectProperty("MunicipioNombre", gxTpr_Municipionombre, false);


			AddObjectProperty("ZonasID", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Zonasid, 18, 0)), false);


			AddObjectProperty("SolicitudesDireccion", gxTpr_Solicitudesdireccion, false);


			AddObjectProperty("SolicitudesAutoEnumerar", gxTpr_Solicitudesautoenumerar, false);


			AddObjectProperty("ProfesionalPostulado", gxTpr_Profesionalpostulado, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Postulacionfechacierre)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Postulacionfechacierre)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Postulacionfechacierre)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("PostulacionFechaCierre", sDateCnv, false);



			AddObjectProperty("PostulacionHoraCierre", gxTpr_Postulacionhoracierre, false);


			AddObjectProperty("PostulacionTipoFecha", gxTpr_Postulaciontipofecha, false);


			AddObjectProperty("ServiciosNombre", gxTpr_Serviciosnombre, false);

			if (gxTv_SdtSDTSolicitudes_Items != null)
			{
				AddObjectProperty("Items", gxTv_SdtSDTSolicitudes_Items, false);
			}

			AddObjectProperty("SolicitudesNotificacion", gxTpr_Solicitudesnotificacion, false);


			AddObjectProperty("SolicitudesNota", gxTpr_Solicitudesnota, false);


			AddObjectProperty("MetodoPagosNombre", gxTpr_Metodopagosnombre, false);


			AddObjectProperty("MetodoPagosID", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Metodopagosid, 18, 0)), false);


			AddObjectProperty("SolicitudesComentario", gxTpr_Solicitudescomentario, false);


			AddObjectProperty("SolicitudesHoraInstalacion", gxTpr_Solicitudeshorainstalacion, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Solicitudesfechainstalacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Solicitudesfechainstalacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Solicitudesfechainstalacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("SolicitudesFechaInstalacion", sDateCnv, false);



			datetime_STZ = gxTpr_Solicitudesfechaactualizacion;
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
			AddObjectProperty("SolicitudesFechaActualizacion", sDateCnv, false);



			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Solicitudesfechaalta)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Solicitudesfechaalta)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Solicitudesfechaalta)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("SolicitudesFechaAlta", sDateCnv, false);



			AddObjectProperty("SolicitudesOtros3", gxTpr_Solicitudesotros3, false);


			AddObjectProperty("SolicitudesOtros2", gxTpr_Solicitudesotros2, false);


			AddObjectProperty("SolicitudesOtros1", gxTpr_Solicitudesotros1, false);


			AddObjectProperty("EstadosSolNombre", gxTpr_Estadossolnombre, false);


			AddObjectProperty("EstadosSolId", gxTpr_Estadossolid, false);


			AddObjectProperty("EstadosSolTipo", gxTpr_Estadossoltipo, false);


			AddObjectProperty("SolicitudServicioPFinal", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Solicitudserviciopfinal, 18, 2)), false);


			AddObjectProperty("SolicitudServicioSolCoti", gxTpr_Solicitudserviciosolcoti, false);


			AddObjectProperty("SolicitudesTotal", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Solicitudestotal, 18, 2)), false);


			AddObjectProperty("SolicitudesCotizacion", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Solicitudescotizacion, 18, 2)), false);


			AddObjectProperty("ModoPago", gxTpr_Modopago, false);


			AddObjectProperty("Ganancia", gxTpr_Ganancia, false);


			AddObjectProperty("Deduccion", gxTpr_Deduccion, false);


			AddObjectProperty("FeedBackId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Feedbackid, 18, 0)), false);


			AddObjectProperty("FeedBackNum", gxTpr_Feedbacknum, false);


			AddObjectProperty("FeedBackComentario", gxTpr_Feedbackcomentario, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Feedbackfechaalta)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Feedbackfechaalta)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Feedbackfechaalta)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("FeedBackFechaAlta", sDateCnv, false);



			AddObjectProperty("SolicitudesSubTipo", gxTpr_Solicitudessubtipo, false);


			AddObjectProperty("SolicitudesSubTipoDesc", gxTpr_Solicitudessubtipodesc, false);


			AddObjectProperty("MudanzaId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Mudanzaid, 18, 0)), false);


			AddObjectProperty("SolicitudServicioOrigenPago", gxTpr_Solicitudservicioorigenpago, false);


			AddObjectProperty("STComerciosNombre", gxTpr_Stcomerciosnombre, false);


			AddObjectProperty("SolicitudesComisionMetodoPago", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Solicitudescomisionmetodopago, 18, 2)), false);

			if (gxTv_SdtSDTSolicitudes_Archivo != null)
			{
				AddObjectProperty("Archivo", gxTv_SdtSDTSolicitudes_Archivo, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="SolicitudesID")]
		[XmlElement(ElementName="SolicitudesID")]
		public long gxTpr_Solicitudesid
		{
			get {
				return gxTv_SdtSDTSolicitudes_Solicitudesid; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Solicitudesid = value;
				SetDirty("Solicitudesid");
			}
		}




		[SoapElement(ElementName="SolicitudesNombre")]
		[XmlElement(ElementName="SolicitudesNombre")]
		public string gxTpr_Solicitudesnombre
		{
			get {
				return gxTv_SdtSDTSolicitudes_Solicitudesnombre; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Solicitudesnombre = value;
				SetDirty("Solicitudesnombre");
			}
		}




		[SoapElement(ElementName="ProveedorNombre")]
		[XmlElement(ElementName="ProveedorNombre")]
		public string gxTpr_Proveedornombre
		{
			get {
				return gxTv_SdtSDTSolicitudes_Proveedornombre; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Proveedornombre = value;
				SetDirty("Proveedornombre");
			}
		}




		[SoapElement(ElementName="SolicitudesTelefono")]
		[XmlElement(ElementName="SolicitudesTelefono")]
		public string gxTpr_Solicitudestelefono
		{
			get {
				return gxTv_SdtSDTSolicitudes_Solicitudestelefono; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Solicitudestelefono = value;
				SetDirty("Solicitudestelefono");
			}
		}




		[SoapElement(ElementName="SolicitudesMail")]
		[XmlElement(ElementName="SolicitudesMail")]
		public string gxTpr_Solicitudesmail
		{
			get {
				return gxTv_SdtSDTSolicitudes_Solicitudesmail; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Solicitudesmail = value;
				SetDirty("Solicitudesmail");
			}
		}




		[SoapElement(ElementName="PaisID")]
		[XmlElement(ElementName="PaisID")]
		public string gxTpr_Paisid
		{
			get {
				return gxTv_SdtSDTSolicitudes_Paisid; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Paisid = value;
				SetDirty("Paisid");
			}
		}




		[SoapElement(ElementName="DepartamentoId")]
		[XmlElement(ElementName="DepartamentoId")]
		public long gxTpr_Departamentoid
		{
			get {
				return gxTv_SdtSDTSolicitudes_Departamentoid; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Departamentoid = value;
				SetDirty("Departamentoid");
			}
		}




		[SoapElement(ElementName="DepartamentoNombre")]
		[XmlElement(ElementName="DepartamentoNombre")]
		public string gxTpr_Departamentonombre
		{
			get {
				return gxTv_SdtSDTSolicitudes_Departamentonombre; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Departamentonombre = value;
				SetDirty("Departamentonombre");
			}
		}




		[SoapElement(ElementName="DepartamentoMunicipioId")]
		[XmlElement(ElementName="DepartamentoMunicipioId")]
		public long gxTpr_Departamentomunicipioid
		{
			get {
				return gxTv_SdtSDTSolicitudes_Departamentomunicipioid; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Departamentomunicipioid = value;
				SetDirty("Departamentomunicipioid");
			}
		}




		[SoapElement(ElementName="MunicipioNombre")]
		[XmlElement(ElementName="MunicipioNombre")]
		public string gxTpr_Municipionombre
		{
			get {
				return gxTv_SdtSDTSolicitudes_Municipionombre; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Municipionombre = value;
				SetDirty("Municipionombre");
			}
		}




		[SoapElement(ElementName="ZonasID")]
		[XmlElement(ElementName="ZonasID")]
		public long gxTpr_Zonasid
		{
			get {
				return gxTv_SdtSDTSolicitudes_Zonasid; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Zonasid = value;
				SetDirty("Zonasid");
			}
		}




		[SoapElement(ElementName="SolicitudesDireccion")]
		[XmlElement(ElementName="SolicitudesDireccion")]
		public string gxTpr_Solicitudesdireccion
		{
			get {
				return gxTv_SdtSDTSolicitudes_Solicitudesdireccion; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Solicitudesdireccion = value;
				SetDirty("Solicitudesdireccion");
			}
		}




		[SoapElement(ElementName="SolicitudesAutoEnumerar")]
		[XmlElement(ElementName="SolicitudesAutoEnumerar")]
		public short gxTpr_Solicitudesautoenumerar
		{
			get {
				return gxTv_SdtSDTSolicitudes_Solicitudesautoenumerar; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Solicitudesautoenumerar = value;
				SetDirty("Solicitudesautoenumerar");
			}
		}




		[SoapElement(ElementName="ProfesionalPostulado")]
		[XmlElement(ElementName="ProfesionalPostulado")]
		public bool gxTpr_Profesionalpostulado
		{
			get {
				return gxTv_SdtSDTSolicitudes_Profesionalpostulado; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Profesionalpostulado = value;
				SetDirty("Profesionalpostulado");
			}
		}



		[SoapElement(ElementName="PostulacionFechaCierre")]
		[XmlElement(ElementName="PostulacionFechaCierre" , IsNullable=true)]
		public string gxTpr_Postulacionfechacierre_Nullable
		{
			get {
				if ( gxTv_SdtSDTSolicitudes_Postulacionfechacierre == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTSolicitudes_Postulacionfechacierre).value ;
			}
			set {
				gxTv_SdtSDTSolicitudes_Postulacionfechacierre = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Postulacionfechacierre
		{
			get {
				return gxTv_SdtSDTSolicitudes_Postulacionfechacierre; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Postulacionfechacierre = value;
				SetDirty("Postulacionfechacierre");
			}
		}



		[SoapElement(ElementName="PostulacionHoraCierre")]
		[XmlElement(ElementName="PostulacionHoraCierre")]
		public string gxTpr_Postulacionhoracierre
		{
			get {
				return gxTv_SdtSDTSolicitudes_Postulacionhoracierre; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Postulacionhoracierre = value;
				SetDirty("Postulacionhoracierre");
			}
		}




		[SoapElement(ElementName="PostulacionTipoFecha")]
		[XmlElement(ElementName="PostulacionTipoFecha")]
		public string gxTpr_Postulaciontipofecha
		{
			get {
				return gxTv_SdtSDTSolicitudes_Postulaciontipofecha; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Postulaciontipofecha = value;
				SetDirty("Postulaciontipofecha");
			}
		}




		[SoapElement(ElementName="ServiciosNombre")]
		[XmlElement(ElementName="ServiciosNombre")]
		public string gxTpr_Serviciosnombre
		{
			get {
				return gxTv_SdtSDTSolicitudes_Serviciosnombre; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Serviciosnombre = value;
				SetDirty("Serviciosnombre");
			}
		}




		[SoapElement(ElementName="Items" )]
		[XmlArray(ElementName="Items"  )]
		[XmlArrayItemAttribute(ElementName="Items" , IsNullable=false )]
		public GXBaseCollection<SdtSDTSolicitudes_Items> gxTpr_Items
		{
			get {
				if ( gxTv_SdtSDTSolicitudes_Items == null )
				{
					gxTv_SdtSDTSolicitudes_Items = new GXBaseCollection<SdtSDTSolicitudes_Items>( context, "SDTSolicitudes.Items", "");
				}
				SetDirty("Items");
				return gxTv_SdtSDTSolicitudes_Items;
			}
			set {
				gxTv_SdtSDTSolicitudes_Items_N = false;
				gxTv_SdtSDTSolicitudes_Items = value;
				SetDirty("Items");
			}
		}

		public void gxTv_SdtSDTSolicitudes_Items_SetNull()
		{
			gxTv_SdtSDTSolicitudes_Items_N = true;
			gxTv_SdtSDTSolicitudes_Items = null;
		}

		public bool gxTv_SdtSDTSolicitudes_Items_IsNull()
		{
			return gxTv_SdtSDTSolicitudes_Items == null;
		}
		public bool ShouldSerializegxTpr_Items_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTSolicitudes_Items != null && gxTv_SdtSDTSolicitudes_Items.Count > 0;

		}



		[SoapElement(ElementName="SolicitudesNotificacion")]
		[XmlElement(ElementName="SolicitudesNotificacion")]
		public string gxTpr_Solicitudesnotificacion
		{
			get {
				return gxTv_SdtSDTSolicitudes_Solicitudesnotificacion; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Solicitudesnotificacion = value;
				SetDirty("Solicitudesnotificacion");
			}
		}




		[SoapElement(ElementName="SolicitudesNota")]
		[XmlElement(ElementName="SolicitudesNota")]
		public string gxTpr_Solicitudesnota
		{
			get {
				return gxTv_SdtSDTSolicitudes_Solicitudesnota; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Solicitudesnota = value;
				SetDirty("Solicitudesnota");
			}
		}




		[SoapElement(ElementName="MetodoPagosNombre")]
		[XmlElement(ElementName="MetodoPagosNombre")]
		public string gxTpr_Metodopagosnombre
		{
			get {
				return gxTv_SdtSDTSolicitudes_Metodopagosnombre; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Metodopagosnombre = value;
				SetDirty("Metodopagosnombre");
			}
		}




		[SoapElement(ElementName="MetodoPagosID")]
		[XmlElement(ElementName="MetodoPagosID")]
		public long gxTpr_Metodopagosid
		{
			get {
				return gxTv_SdtSDTSolicitudes_Metodopagosid; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Metodopagosid = value;
				SetDirty("Metodopagosid");
			}
		}




		[SoapElement(ElementName="SolicitudesComentario")]
		[XmlElement(ElementName="SolicitudesComentario")]
		public string gxTpr_Solicitudescomentario
		{
			get {
				return gxTv_SdtSDTSolicitudes_Solicitudescomentario; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Solicitudescomentario = value;
				SetDirty("Solicitudescomentario");
			}
		}




		[SoapElement(ElementName="SolicitudesHoraInstalacion")]
		[XmlElement(ElementName="SolicitudesHoraInstalacion")]
		public string gxTpr_Solicitudeshorainstalacion
		{
			get {
				return gxTv_SdtSDTSolicitudes_Solicitudeshorainstalacion; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Solicitudeshorainstalacion = value;
				SetDirty("Solicitudeshorainstalacion");
			}
		}



		[SoapElement(ElementName="SolicitudesFechaInstalacion")]
		[XmlElement(ElementName="SolicitudesFechaInstalacion" , IsNullable=true)]
		public string gxTpr_Solicitudesfechainstalacion_Nullable
		{
			get {
				if ( gxTv_SdtSDTSolicitudes_Solicitudesfechainstalacion == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTSolicitudes_Solicitudesfechainstalacion).value ;
			}
			set {
				gxTv_SdtSDTSolicitudes_Solicitudesfechainstalacion = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Solicitudesfechainstalacion
		{
			get {
				return gxTv_SdtSDTSolicitudes_Solicitudesfechainstalacion; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Solicitudesfechainstalacion = value;
				SetDirty("Solicitudesfechainstalacion");
			}
		}


		[SoapElement(ElementName="SolicitudesFechaActualizacion")]
		[XmlElement(ElementName="SolicitudesFechaActualizacion" , IsNullable=true)]
		public string gxTpr_Solicitudesfechaactualizacion_Nullable
		{
			get {
				if ( gxTv_SdtSDTSolicitudes_Solicitudesfechaactualizacion == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDTSolicitudes_Solicitudesfechaactualizacion).value ;
			}
			set {
				gxTv_SdtSDTSolicitudes_Solicitudesfechaactualizacion = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Solicitudesfechaactualizacion
		{
			get {
				return gxTv_SdtSDTSolicitudes_Solicitudesfechaactualizacion; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Solicitudesfechaactualizacion = value;
				SetDirty("Solicitudesfechaactualizacion");
			}
		}


		[SoapElement(ElementName="SolicitudesFechaAlta")]
		[XmlElement(ElementName="SolicitudesFechaAlta" , IsNullable=true)]
		public string gxTpr_Solicitudesfechaalta_Nullable
		{
			get {
				if ( gxTv_SdtSDTSolicitudes_Solicitudesfechaalta == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTSolicitudes_Solicitudesfechaalta).value ;
			}
			set {
				gxTv_SdtSDTSolicitudes_Solicitudesfechaalta = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Solicitudesfechaalta
		{
			get {
				return gxTv_SdtSDTSolicitudes_Solicitudesfechaalta; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Solicitudesfechaalta = value;
				SetDirty("Solicitudesfechaalta");
			}
		}



		[SoapElement(ElementName="SolicitudesOtros3")]
		[XmlElement(ElementName="SolicitudesOtros3")]
		public string gxTpr_Solicitudesotros3
		{
			get {
				return gxTv_SdtSDTSolicitudes_Solicitudesotros3; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Solicitudesotros3 = value;
				SetDirty("Solicitudesotros3");
			}
		}




		[SoapElement(ElementName="SolicitudesOtros2")]
		[XmlElement(ElementName="SolicitudesOtros2")]
		public string gxTpr_Solicitudesotros2
		{
			get {
				return gxTv_SdtSDTSolicitudes_Solicitudesotros2; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Solicitudesotros2 = value;
				SetDirty("Solicitudesotros2");
			}
		}




		[SoapElement(ElementName="SolicitudesOtros1")]
		[XmlElement(ElementName="SolicitudesOtros1")]
		public string gxTpr_Solicitudesotros1
		{
			get {
				return gxTv_SdtSDTSolicitudes_Solicitudesotros1; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Solicitudesotros1 = value;
				SetDirty("Solicitudesotros1");
			}
		}




		[SoapElement(ElementName="EstadosSolNombre")]
		[XmlElement(ElementName="EstadosSolNombre")]
		public string gxTpr_Estadossolnombre
		{
			get {
				return gxTv_SdtSDTSolicitudes_Estadossolnombre; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Estadossolnombre = value;
				SetDirty("Estadossolnombre");
			}
		}




		[SoapElement(ElementName="EstadosSolId")]
		[XmlElement(ElementName="EstadosSolId")]
		public int gxTpr_Estadossolid
		{
			get {
				return gxTv_SdtSDTSolicitudes_Estadossolid; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Estadossolid = value;
				SetDirty("Estadossolid");
			}
		}




		[SoapElement(ElementName="EstadosSolTipo")]
		[XmlElement(ElementName="EstadosSolTipo")]
		public string gxTpr_Estadossoltipo
		{
			get {
				return gxTv_SdtSDTSolicitudes_Estadossoltipo; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Estadossoltipo = value;
				SetDirty("Estadossoltipo");
			}
		}



		[SoapElement(ElementName="SolicitudServicioPFinal")]
		[XmlElement(ElementName="SolicitudServicioPFinal")]
		public string gxTpr_Solicitudserviciopfinal_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTSolicitudes_Solicitudserviciopfinal, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTSolicitudes_Solicitudserviciopfinal = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Solicitudserviciopfinal
		{
			get {
				return gxTv_SdtSDTSolicitudes_Solicitudserviciopfinal; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Solicitudserviciopfinal = value;
				SetDirty("Solicitudserviciopfinal");
			}
		}




		[SoapElement(ElementName="SolicitudServicioSolCoti")]
		[XmlElement(ElementName="SolicitudServicioSolCoti")]
		public string gxTpr_Solicitudserviciosolcoti
		{
			get {
				return gxTv_SdtSDTSolicitudes_Solicitudserviciosolcoti; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Solicitudserviciosolcoti = value;
				SetDirty("Solicitudserviciosolcoti");
			}
		}



		[SoapElement(ElementName="SolicitudesTotal")]
		[XmlElement(ElementName="SolicitudesTotal")]
		public string gxTpr_Solicitudestotal_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTSolicitudes_Solicitudestotal, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTSolicitudes_Solicitudestotal = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Solicitudestotal
		{
			get {
				return gxTv_SdtSDTSolicitudes_Solicitudestotal; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Solicitudestotal = value;
				SetDirty("Solicitudestotal");
			}
		}



		[SoapElement(ElementName="SolicitudesCotizacion")]
		[XmlElement(ElementName="SolicitudesCotizacion")]
		public string gxTpr_Solicitudescotizacion_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTSolicitudes_Solicitudescotizacion, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTSolicitudes_Solicitudescotizacion = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Solicitudescotizacion
		{
			get {
				return gxTv_SdtSDTSolicitudes_Solicitudescotizacion; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Solicitudescotizacion = value;
				SetDirty("Solicitudescotizacion");
			}
		}




		[SoapElement(ElementName="ModoPago")]
		[XmlElement(ElementName="ModoPago")]
		public string gxTpr_Modopago
		{
			get {
				return gxTv_SdtSDTSolicitudes_Modopago; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Modopago = value;
				SetDirty("Modopago");
			}
		}




		[SoapElement(ElementName="Ganancia")]
		[XmlElement(ElementName="Ganancia")]
		public string gxTpr_Ganancia
		{
			get {
				return gxTv_SdtSDTSolicitudes_Ganancia; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Ganancia = value;
				SetDirty("Ganancia");
			}
		}




		[SoapElement(ElementName="Deduccion")]
		[XmlElement(ElementName="Deduccion")]
		public string gxTpr_Deduccion
		{
			get {
				return gxTv_SdtSDTSolicitudes_Deduccion; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Deduccion = value;
				SetDirty("Deduccion");
			}
		}




		[SoapElement(ElementName="FeedBackId")]
		[XmlElement(ElementName="FeedBackId")]
		public long gxTpr_Feedbackid
		{
			get {
				return gxTv_SdtSDTSolicitudes_Feedbackid; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Feedbackid = value;
				SetDirty("Feedbackid");
			}
		}




		[SoapElement(ElementName="FeedBackNum")]
		[XmlElement(ElementName="FeedBackNum")]
		public long gxTpr_Feedbacknum
		{
			get {
				return gxTv_SdtSDTSolicitudes_Feedbacknum; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Feedbacknum = value;
				SetDirty("Feedbacknum");
			}
		}




		[SoapElement(ElementName="FeedBackComentario")]
		[XmlElement(ElementName="FeedBackComentario")]
		public string gxTpr_Feedbackcomentario
		{
			get {
				return gxTv_SdtSDTSolicitudes_Feedbackcomentario; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Feedbackcomentario = value;
				SetDirty("Feedbackcomentario");
			}
		}



		[SoapElement(ElementName="FeedBackFechaAlta")]
		[XmlElement(ElementName="FeedBackFechaAlta" , IsNullable=true)]
		public string gxTpr_Feedbackfechaalta_Nullable
		{
			get {
				if ( gxTv_SdtSDTSolicitudes_Feedbackfechaalta == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTSolicitudes_Feedbackfechaalta).value ;
			}
			set {
				gxTv_SdtSDTSolicitudes_Feedbackfechaalta = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Feedbackfechaalta
		{
			get {
				return gxTv_SdtSDTSolicitudes_Feedbackfechaalta; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Feedbackfechaalta = value;
				SetDirty("Feedbackfechaalta");
			}
		}



		[SoapElement(ElementName="SolicitudesSubTipo")]
		[XmlElement(ElementName="SolicitudesSubTipo")]
		public string gxTpr_Solicitudessubtipo
		{
			get {
				return gxTv_SdtSDTSolicitudes_Solicitudessubtipo; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Solicitudessubtipo = value;
				SetDirty("Solicitudessubtipo");
			}
		}




		[SoapElement(ElementName="SolicitudesSubTipoDesc")]
		[XmlElement(ElementName="SolicitudesSubTipoDesc")]
		public string gxTpr_Solicitudessubtipodesc
		{
			get {
				return gxTv_SdtSDTSolicitudes_Solicitudessubtipodesc; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Solicitudessubtipodesc = value;
				SetDirty("Solicitudessubtipodesc");
			}
		}




		[SoapElement(ElementName="MudanzaId")]
		[XmlElement(ElementName="MudanzaId")]
		public long gxTpr_Mudanzaid
		{
			get {
				return gxTv_SdtSDTSolicitudes_Mudanzaid; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Mudanzaid = value;
				SetDirty("Mudanzaid");
			}
		}




		[SoapElement(ElementName="SolicitudServicioOrigenPago")]
		[XmlElement(ElementName="SolicitudServicioOrigenPago")]
		public string gxTpr_Solicitudservicioorigenpago
		{
			get {
				return gxTv_SdtSDTSolicitudes_Solicitudservicioorigenpago; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Solicitudservicioorigenpago = value;
				SetDirty("Solicitudservicioorigenpago");
			}
		}




		[SoapElement(ElementName="STComerciosNombre")]
		[XmlElement(ElementName="STComerciosNombre")]
		public string gxTpr_Stcomerciosnombre
		{
			get {
				return gxTv_SdtSDTSolicitudes_Stcomerciosnombre; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Stcomerciosnombre = value;
				SetDirty("Stcomerciosnombre");
			}
		}



		[SoapElement(ElementName="SolicitudesComisionMetodoPago")]
		[XmlElement(ElementName="SolicitudesComisionMetodoPago")]
		public string gxTpr_Solicitudescomisionmetodopago_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTSolicitudes_Solicitudescomisionmetodopago, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTSolicitudes_Solicitudescomisionmetodopago = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Solicitudescomisionmetodopago
		{
			get {
				return gxTv_SdtSDTSolicitudes_Solicitudescomisionmetodopago; 
			}
			set {
				gxTv_SdtSDTSolicitudes_Solicitudescomisionmetodopago = value;
				SetDirty("Solicitudescomisionmetodopago");
			}
		}




		[SoapElement(ElementName="Archivo" )]
		[XmlArray(ElementName="Archivo"  )]
		[XmlArrayItemAttribute(ElementName="ArchivoItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTSolicitudes_ArchivoItem> gxTpr_Archivo
		{
			get {
				if ( gxTv_SdtSDTSolicitudes_Archivo == null )
				{
					gxTv_SdtSDTSolicitudes_Archivo = new GXBaseCollection<SdtSDTSolicitudes_ArchivoItem>( context, "SDTSolicitudes.ArchivoItem", "");
				}
				SetDirty("Archivo");
				return gxTv_SdtSDTSolicitudes_Archivo;
			}
			set {
				gxTv_SdtSDTSolicitudes_Archivo_N = false;
				gxTv_SdtSDTSolicitudes_Archivo = value;
				SetDirty("Archivo");
			}
		}

		public void gxTv_SdtSDTSolicitudes_Archivo_SetNull()
		{
			gxTv_SdtSDTSolicitudes_Archivo_N = true;
			gxTv_SdtSDTSolicitudes_Archivo = null;
		}

		public bool gxTv_SdtSDTSolicitudes_Archivo_IsNull()
		{
			return gxTv_SdtSDTSolicitudes_Archivo == null;
		}
		public bool ShouldSerializegxTpr_Archivo_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTSolicitudes_Archivo != null && gxTv_SdtSDTSolicitudes_Archivo.Count > 0;

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
			gxTv_SdtSDTSolicitudes_Solicitudesnombre = "";
			gxTv_SdtSDTSolicitudes_Proveedornombre = "";
			gxTv_SdtSDTSolicitudes_Solicitudestelefono = "";
			gxTv_SdtSDTSolicitudes_Solicitudesmail = "";
			gxTv_SdtSDTSolicitudes_Paisid = "";

			gxTv_SdtSDTSolicitudes_Departamentonombre = "";

			gxTv_SdtSDTSolicitudes_Municipionombre = "";

			gxTv_SdtSDTSolicitudes_Solicitudesdireccion = "";



			gxTv_SdtSDTSolicitudes_Postulacionhoracierre = "";
			gxTv_SdtSDTSolicitudes_Postulaciontipofecha = "";
			gxTv_SdtSDTSolicitudes_Serviciosnombre = "";

			gxTv_SdtSDTSolicitudes_Items_N = true;

			gxTv_SdtSDTSolicitudes_Solicitudesnotificacion = "";
			gxTv_SdtSDTSolicitudes_Solicitudesnota = "";
			gxTv_SdtSDTSolicitudes_Metodopagosnombre = "";

			gxTv_SdtSDTSolicitudes_Solicitudescomentario = "";
			gxTv_SdtSDTSolicitudes_Solicitudeshorainstalacion = "";

			gxTv_SdtSDTSolicitudes_Solicitudesfechaactualizacion = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDTSolicitudes_Solicitudesotros3 = "";
			gxTv_SdtSDTSolicitudes_Solicitudesotros2 = "";
			gxTv_SdtSDTSolicitudes_Solicitudesotros1 = "";
			gxTv_SdtSDTSolicitudes_Estadossolnombre = "";

			gxTv_SdtSDTSolicitudes_Estadossoltipo = "";

			gxTv_SdtSDTSolicitudes_Solicitudserviciosolcoti = "";


			gxTv_SdtSDTSolicitudes_Modopago = "";
			gxTv_SdtSDTSolicitudes_Ganancia = "";
			gxTv_SdtSDTSolicitudes_Deduccion = "";


			gxTv_SdtSDTSolicitudes_Feedbackcomentario = "";

			gxTv_SdtSDTSolicitudes_Solicitudessubtipo = "";
			gxTv_SdtSDTSolicitudes_Solicitudessubtipodesc = "";

			gxTv_SdtSDTSolicitudes_Solicitudservicioorigenpago = "";
			gxTv_SdtSDTSolicitudes_Stcomerciosnombre = "";


			gxTv_SdtSDTSolicitudes_Archivo_N = true;

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

		protected long gxTv_SdtSDTSolicitudes_Solicitudesid;
		 

		protected string gxTv_SdtSDTSolicitudes_Solicitudesnombre;
		 

		protected string gxTv_SdtSDTSolicitudes_Proveedornombre;
		 

		protected string gxTv_SdtSDTSolicitudes_Solicitudestelefono;
		 

		protected string gxTv_SdtSDTSolicitudes_Solicitudesmail;
		 

		protected string gxTv_SdtSDTSolicitudes_Paisid;
		 

		protected long gxTv_SdtSDTSolicitudes_Departamentoid;
		 

		protected string gxTv_SdtSDTSolicitudes_Departamentonombre;
		 

		protected long gxTv_SdtSDTSolicitudes_Departamentomunicipioid;
		 

		protected string gxTv_SdtSDTSolicitudes_Municipionombre;
		 

		protected long gxTv_SdtSDTSolicitudes_Zonasid;
		 

		protected string gxTv_SdtSDTSolicitudes_Solicitudesdireccion;
		 

		protected short gxTv_SdtSDTSolicitudes_Solicitudesautoenumerar;
		 

		protected bool gxTv_SdtSDTSolicitudes_Profesionalpostulado;
		 

		protected DateTime gxTv_SdtSDTSolicitudes_Postulacionfechacierre;
		 

		protected string gxTv_SdtSDTSolicitudes_Postulacionhoracierre;
		 

		protected string gxTv_SdtSDTSolicitudes_Postulaciontipofecha;
		 

		protected string gxTv_SdtSDTSolicitudes_Serviciosnombre;
		 
		protected bool gxTv_SdtSDTSolicitudes_Items_N;
		protected GXBaseCollection<SdtSDTSolicitudes_Items> gxTv_SdtSDTSolicitudes_Items = null; 


		protected string gxTv_SdtSDTSolicitudes_Solicitudesnotificacion;
		 

		protected string gxTv_SdtSDTSolicitudes_Solicitudesnota;
		 

		protected string gxTv_SdtSDTSolicitudes_Metodopagosnombre;
		 

		protected long gxTv_SdtSDTSolicitudes_Metodopagosid;
		 

		protected string gxTv_SdtSDTSolicitudes_Solicitudescomentario;
		 

		protected string gxTv_SdtSDTSolicitudes_Solicitudeshorainstalacion;
		 

		protected DateTime gxTv_SdtSDTSolicitudes_Solicitudesfechainstalacion;
		 

		protected DateTime gxTv_SdtSDTSolicitudes_Solicitudesfechaactualizacion;
		 

		protected DateTime gxTv_SdtSDTSolicitudes_Solicitudesfechaalta;
		 

		protected string gxTv_SdtSDTSolicitudes_Solicitudesotros3;
		 

		protected string gxTv_SdtSDTSolicitudes_Solicitudesotros2;
		 

		protected string gxTv_SdtSDTSolicitudes_Solicitudesotros1;
		 

		protected string gxTv_SdtSDTSolicitudes_Estadossolnombre;
		 

		protected int gxTv_SdtSDTSolicitudes_Estadossolid;
		 

		protected string gxTv_SdtSDTSolicitudes_Estadossoltipo;
		 

		protected decimal gxTv_SdtSDTSolicitudes_Solicitudserviciopfinal;
		 

		protected string gxTv_SdtSDTSolicitudes_Solicitudserviciosolcoti;
		 

		protected decimal gxTv_SdtSDTSolicitudes_Solicitudestotal;
		 

		protected decimal gxTv_SdtSDTSolicitudes_Solicitudescotizacion;
		 

		protected string gxTv_SdtSDTSolicitudes_Modopago;
		 

		protected string gxTv_SdtSDTSolicitudes_Ganancia;
		 

		protected string gxTv_SdtSDTSolicitudes_Deduccion;
		 

		protected long gxTv_SdtSDTSolicitudes_Feedbackid;
		 

		protected long gxTv_SdtSDTSolicitudes_Feedbacknum;
		 

		protected string gxTv_SdtSDTSolicitudes_Feedbackcomentario;
		 

		protected DateTime gxTv_SdtSDTSolicitudes_Feedbackfechaalta;
		 

		protected string gxTv_SdtSDTSolicitudes_Solicitudessubtipo;
		 

		protected string gxTv_SdtSDTSolicitudes_Solicitudessubtipodesc;
		 

		protected long gxTv_SdtSDTSolicitudes_Mudanzaid;
		 

		protected string gxTv_SdtSDTSolicitudes_Solicitudservicioorigenpago;
		 

		protected string gxTv_SdtSDTSolicitudes_Stcomerciosnombre;
		 

		protected decimal gxTv_SdtSDTSolicitudes_Solicitudescomisionmetodopago;
		 
		protected bool gxTv_SdtSDTSolicitudes_Archivo_N;
		protected GXBaseCollection<SdtSDTSolicitudes_ArchivoItem> gxTv_SdtSDTSolicitudes_Archivo = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTSolicitudes", Namespace="AlmangoX")]
	public class SdtSDTSolicitudes_RESTInterface : GxGenericCollectionItem<SdtSDTSolicitudes>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTSolicitudes_RESTInterface( ) : base()
		{	
		}

		public SdtSDTSolicitudes_RESTInterface( SdtSDTSolicitudes psdt ) : base(psdt)
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

		[DataMember(Name="SolicitudesNombre", Order=1)]
		public  string gxTpr_Solicitudesnombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Solicitudesnombre);

			}
			set { 
				 sdt.gxTpr_Solicitudesnombre = value;
			}
		}

		[DataMember(Name="ProveedorNombre", Order=2)]
		public  string gxTpr_Proveedornombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Proveedornombre);

			}
			set { 
				 sdt.gxTpr_Proveedornombre = value;
			}
		}

		[DataMember(Name="SolicitudesTelefono", Order=3)]
		public  string gxTpr_Solicitudestelefono
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Solicitudestelefono);

			}
			set { 
				 sdt.gxTpr_Solicitudestelefono = value;
			}
		}

		[DataMember(Name="SolicitudesMail", Order=4)]
		public  string gxTpr_Solicitudesmail
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Solicitudesmail);

			}
			set { 
				 sdt.gxTpr_Solicitudesmail = value;
			}
		}

		[DataMember(Name="PaisID", Order=5)]
		public  string gxTpr_Paisid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Paisid);

			}
			set { 
				 sdt.gxTpr_Paisid = value;
			}
		}

		[DataMember(Name="DepartamentoId", Order=6)]
		public  string gxTpr_Departamentoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Departamentoid, 18, 0));

			}
			set { 
				sdt.gxTpr_Departamentoid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="DepartamentoNombre", Order=7)]
		public  string gxTpr_Departamentonombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Departamentonombre);

			}
			set { 
				 sdt.gxTpr_Departamentonombre = value;
			}
		}

		[DataMember(Name="DepartamentoMunicipioId", Order=8)]
		public  string gxTpr_Departamentomunicipioid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Departamentomunicipioid, 18, 0));

			}
			set { 
				sdt.gxTpr_Departamentomunicipioid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MunicipioNombre", Order=9)]
		public  string gxTpr_Municipionombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Municipionombre);

			}
			set { 
				 sdt.gxTpr_Municipionombre = value;
			}
		}

		[DataMember(Name="ZonasID", Order=10)]
		public  string gxTpr_Zonasid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Zonasid, 18, 0));

			}
			set { 
				sdt.gxTpr_Zonasid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="SolicitudesDireccion", Order=11)]
		public  string gxTpr_Solicitudesdireccion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Solicitudesdireccion);

			}
			set { 
				 sdt.gxTpr_Solicitudesdireccion = value;
			}
		}

		[DataMember(Name="SolicitudesAutoEnumerar", Order=12)]
		public short gxTpr_Solicitudesautoenumerar
		{
			get { 
				return sdt.gxTpr_Solicitudesautoenumerar;

			}
			set { 
				sdt.gxTpr_Solicitudesautoenumerar = value;
			}
		}

		[DataMember(Name="ProfesionalPostulado", Order=13)]
		public bool gxTpr_Profesionalpostulado
		{
			get { 
				return sdt.gxTpr_Profesionalpostulado;

			}
			set { 
				sdt.gxTpr_Profesionalpostulado = value;
			}
		}

		[DataMember(Name="PostulacionFechaCierre", Order=14)]
		public  string gxTpr_Postulacionfechacierre
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Postulacionfechacierre);

			}
			set { 
				sdt.gxTpr_Postulacionfechacierre = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="PostulacionHoraCierre", Order=15)]
		public  string gxTpr_Postulacionhoracierre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Postulacionhoracierre);

			}
			set { 
				 sdt.gxTpr_Postulacionhoracierre = value;
			}
		}

		[DataMember(Name="PostulacionTipoFecha", Order=16)]
		public  string gxTpr_Postulaciontipofecha
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Postulaciontipofecha);

			}
			set { 
				 sdt.gxTpr_Postulaciontipofecha = value;
			}
		}

		[DataMember(Name="ServiciosNombre", Order=17)]
		public  string gxTpr_Serviciosnombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Serviciosnombre);

			}
			set { 
				 sdt.gxTpr_Serviciosnombre = value;
			}
		}

		[DataMember(Name="Items", Order=18, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTSolicitudes_Items_RESTInterface> gxTpr_Items
		{
			get {
				if (sdt.ShouldSerializegxTpr_Items_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTSolicitudes_Items_RESTInterface>(sdt.gxTpr_Items);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Items);
			}
		}

		[DataMember(Name="SolicitudesNotificacion", Order=19)]
		public  string gxTpr_Solicitudesnotificacion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Solicitudesnotificacion);

			}
			set { 
				 sdt.gxTpr_Solicitudesnotificacion = value;
			}
		}

		[DataMember(Name="SolicitudesNota", Order=20)]
		public  string gxTpr_Solicitudesnota
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Solicitudesnota);

			}
			set { 
				 sdt.gxTpr_Solicitudesnota = value;
			}
		}

		[DataMember(Name="MetodoPagosNombre", Order=21)]
		public  string gxTpr_Metodopagosnombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Metodopagosnombre);

			}
			set { 
				 sdt.gxTpr_Metodopagosnombre = value;
			}
		}

		[DataMember(Name="MetodoPagosID", Order=22)]
		public  string gxTpr_Metodopagosid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Metodopagosid, 18, 0));

			}
			set { 
				sdt.gxTpr_Metodopagosid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="SolicitudesComentario", Order=23)]
		public  string gxTpr_Solicitudescomentario
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Solicitudescomentario);

			}
			set { 
				 sdt.gxTpr_Solicitudescomentario = value;
			}
		}

		[DataMember(Name="SolicitudesHoraInstalacion", Order=24)]
		public  string gxTpr_Solicitudeshorainstalacion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Solicitudeshorainstalacion);

			}
			set { 
				 sdt.gxTpr_Solicitudeshorainstalacion = value;
			}
		}

		[DataMember(Name="SolicitudesFechaInstalacion", Order=25)]
		public  string gxTpr_Solicitudesfechainstalacion
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Solicitudesfechainstalacion);

			}
			set { 
				sdt.gxTpr_Solicitudesfechainstalacion = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="SolicitudesFechaActualizacion", Order=26)]
		public  string gxTpr_Solicitudesfechaactualizacion
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Solicitudesfechaactualizacion,context);

			}
			set { 
				sdt.gxTpr_Solicitudesfechaactualizacion = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="SolicitudesFechaAlta", Order=27)]
		public  string gxTpr_Solicitudesfechaalta
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Solicitudesfechaalta);

			}
			set { 
				sdt.gxTpr_Solicitudesfechaalta = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="SolicitudesOtros3", Order=28)]
		public  string gxTpr_Solicitudesotros3
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Solicitudesotros3);

			}
			set { 
				 sdt.gxTpr_Solicitudesotros3 = value;
			}
		}

		[DataMember(Name="SolicitudesOtros2", Order=29)]
		public  string gxTpr_Solicitudesotros2
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Solicitudesotros2);

			}
			set { 
				 sdt.gxTpr_Solicitudesotros2 = value;
			}
		}

		[DataMember(Name="SolicitudesOtros1", Order=30)]
		public  string gxTpr_Solicitudesotros1
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Solicitudesotros1);

			}
			set { 
				 sdt.gxTpr_Solicitudesotros1 = value;
			}
		}

		[DataMember(Name="EstadosSolNombre", Order=31)]
		public  string gxTpr_Estadossolnombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Estadossolnombre);

			}
			set { 
				 sdt.gxTpr_Estadossolnombre = value;
			}
		}

		[DataMember(Name="EstadosSolId", Order=32)]
		public int gxTpr_Estadossolid
		{
			get { 
				return sdt.gxTpr_Estadossolid;

			}
			set { 
				sdt.gxTpr_Estadossolid = value;
			}
		}

		[DataMember(Name="EstadosSolTipo", Order=33)]
		public  string gxTpr_Estadossoltipo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Estadossoltipo);

			}
			set { 
				 sdt.gxTpr_Estadossoltipo = value;
			}
		}

		[DataMember(Name="SolicitudServicioPFinal", Order=34)]
		public  string gxTpr_Solicitudserviciopfinal
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Solicitudserviciopfinal, 18, 2));

			}
			set { 
				sdt.gxTpr_Solicitudserviciopfinal =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="SolicitudServicioSolCoti", Order=35)]
		public  string gxTpr_Solicitudserviciosolcoti
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Solicitudserviciosolcoti);

			}
			set { 
				 sdt.gxTpr_Solicitudserviciosolcoti = value;
			}
		}

		[DataMember(Name="SolicitudesTotal", Order=36)]
		public  string gxTpr_Solicitudestotal
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Solicitudestotal, 18, 2));

			}
			set { 
				sdt.gxTpr_Solicitudestotal =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="SolicitudesCotizacion", Order=37)]
		public  string gxTpr_Solicitudescotizacion
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Solicitudescotizacion, 18, 2));

			}
			set { 
				sdt.gxTpr_Solicitudescotizacion =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ModoPago", Order=38)]
		public  string gxTpr_Modopago
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Modopago);

			}
			set { 
				 sdt.gxTpr_Modopago = value;
			}
		}

		[DataMember(Name="Ganancia", Order=39)]
		public  string gxTpr_Ganancia
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Ganancia);

			}
			set { 
				 sdt.gxTpr_Ganancia = value;
			}
		}

		[DataMember(Name="Deduccion", Order=40)]
		public  string gxTpr_Deduccion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Deduccion);

			}
			set { 
				 sdt.gxTpr_Deduccion = value;
			}
		}

		[DataMember(Name="FeedBackId", Order=41)]
		public  string gxTpr_Feedbackid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Feedbackid, 18, 0));

			}
			set { 
				sdt.gxTpr_Feedbackid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="FeedBackNum", Order=42)]
		public  string gxTpr_Feedbacknum
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Feedbacknum, 10, 0));

			}
			set { 
				sdt.gxTpr_Feedbacknum = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="FeedBackComentario", Order=43)]
		public  string gxTpr_Feedbackcomentario
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Feedbackcomentario);

			}
			set { 
				 sdt.gxTpr_Feedbackcomentario = value;
			}
		}

		[DataMember(Name="FeedBackFechaAlta", Order=44)]
		public  string gxTpr_Feedbackfechaalta
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Feedbackfechaalta);

			}
			set { 
				sdt.gxTpr_Feedbackfechaalta = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="SolicitudesSubTipo", Order=45)]
		public  string gxTpr_Solicitudessubtipo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Solicitudessubtipo);

			}
			set { 
				 sdt.gxTpr_Solicitudessubtipo = value;
			}
		}

		[DataMember(Name="SolicitudesSubTipoDesc", Order=46)]
		public  string gxTpr_Solicitudessubtipodesc
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Solicitudessubtipodesc);

			}
			set { 
				 sdt.gxTpr_Solicitudessubtipodesc = value;
			}
		}

		[DataMember(Name="MudanzaId", Order=47)]
		public  string gxTpr_Mudanzaid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Mudanzaid, 18, 0));

			}
			set { 
				sdt.gxTpr_Mudanzaid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="SolicitudServicioOrigenPago", Order=48)]
		public  string gxTpr_Solicitudservicioorigenpago
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Solicitudservicioorigenpago);

			}
			set { 
				 sdt.gxTpr_Solicitudservicioorigenpago = value;
			}
		}

		[DataMember(Name="STComerciosNombre", Order=49)]
		public  string gxTpr_Stcomerciosnombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Stcomerciosnombre);

			}
			set { 
				 sdt.gxTpr_Stcomerciosnombre = value;
			}
		}

		[DataMember(Name="SolicitudesComisionMetodoPago", Order=50)]
		public  string gxTpr_Solicitudescomisionmetodopago
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Solicitudescomisionmetodopago, 18, 2));

			}
			set { 
				sdt.gxTpr_Solicitudescomisionmetodopago =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Archivo", Order=51, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTSolicitudes_ArchivoItem_RESTInterface> gxTpr_Archivo
		{
			get {
				if (sdt.ShouldSerializegxTpr_Archivo_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTSolicitudes_ArchivoItem_RESTInterface>(sdt.gxTpr_Archivo);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Archivo);
			}
		}


		#endregion
		public SdtSDTSolicitudes sdt
		{
			get { 
				return (SdtSDTSolicitudes)Sdt;
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
				sdt = new SdtSDTSolicitudes() ;
			}
		}
	}
	#endregion
}