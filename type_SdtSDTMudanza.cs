/*
				   File: type_SdtSDTMudanza
			Description: SDTMudanza
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
	[XmlRoot(ElementName="SDTMudanza")]
	[XmlType(TypeName="SDTMudanza" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTMudanza : GxUserType
	{
		public SdtSDTMudanza( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTMudanza_Mudanzaasesor = "";

			gxTv_SdtSDTMudanza_Mudanzaapellidonombre = "";

			gxTv_SdtSDTMudanza_Mudanzamail = "";

			gxTv_SdtSDTMudanza_Mudanzaphone = "";

			gxTv_SdtSDTMudanza_Mudanzahoraservicio = "";

			gxTv_SdtSDTMudanza_Mudanzargohoraservicio = "";

			gxTv_SdtSDTMudanza_Mudanzadireccionorigen = "";

			gxTv_SdtSDTMudanza_Mudanzalocalidadorigen = "";

			gxTv_SdtSDTMudanza_Mudanzapisodptoorigen = "";

			gxTv_SdtSDTMudanza_Mudanzadirecciondestino = "";

			gxTv_SdtSDTMudanza_Mudanzalocalidaddestino = "";

			gxTv_SdtSDTMudanza_Mudanzapisodptodestino = "";

			gxTv_SdtSDTMudanza_Mudanzacoordenadasorigen = "";

			gxTv_SdtSDTMudanza_Mudanzacoordenadasdestino = "";

			gxTv_SdtSDTMudanza_Mudanzavehiculosugerido = "";

			gxTv_SdtSDTMudanza_Mudanzacomentario = "";

			gxTv_SdtSDTMudanza_Tipoinmuebleorigennombre = "";

			gxTv_SdtSDTMudanza_Mudanzaorigenmetodo = "";

			gxTv_SdtSDTMudanza_Tipoinmuebledestinonombre = "";

			gxTv_SdtSDTMudanza_Tipoestacionamorigennombre = "";

			gxTv_SdtSDTMudanza_Tipoestacionamdestinonombre = "";

			gxTv_SdtSDTMudanza_Mudanzadestinometodo = "";

			gxTv_SdtSDTMudanza_Mudanzaformapago = "";


		}

		public SdtSDTMudanza(IGxContext context)
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
			AddObjectProperty("MudanzaId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Mudanzaid, 18, 0)), false);


			AddObjectProperty("MudanzaAsesor", gxTpr_Mudanzaasesor, false);


			AddObjectProperty("MudanzaApellidoNombre", gxTpr_Mudanzaapellidonombre, false);


			AddObjectProperty("MudanzaMail", gxTpr_Mudanzamail, false);


			AddObjectProperty("MudanzaPhone", gxTpr_Mudanzaphone, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Mudanzafechaalta)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Mudanzafechaalta)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Mudanzafechaalta)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("MudanzaFechaAlta", sDateCnv, false);



			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Mudanzafechaupdate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Mudanzafechaupdate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Mudanzafechaupdate)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("MudanzaFechaUpdate", sDateCnv, false);



			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Mudanzafechaservicio)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Mudanzafechaservicio)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Mudanzafechaservicio)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("MudanzaFechaServicio", sDateCnv, false);



			AddObjectProperty("MudanzaHoraServicio", gxTpr_Mudanzahoraservicio, false);


			AddObjectProperty("MudanzaRgoHoraservicio", gxTpr_Mudanzargohoraservicio, false);


			AddObjectProperty("MudanzaDireccionOrigen", gxTpr_Mudanzadireccionorigen, false);


			AddObjectProperty("MudanzaLocalidadOrigen", gxTpr_Mudanzalocalidadorigen, false);


			AddObjectProperty("MudanzaPisoDptoOrigen", gxTpr_Mudanzapisodptoorigen, false);


			AddObjectProperty("MudanzaDireccionDestino", gxTpr_Mudanzadirecciondestino, false);


			AddObjectProperty("MudanzaLocalidadDestino", gxTpr_Mudanzalocalidaddestino, false);


			AddObjectProperty("MudanzaPisoDptoDestino", gxTpr_Mudanzapisodptodestino, false);


			AddObjectProperty("MudanzaCoordenadasOrigen", gxTpr_Mudanzacoordenadasorigen, false);


			AddObjectProperty("MudanzaCoordenadasDestino", gxTpr_Mudanzacoordenadasdestino, false);


			AddObjectProperty("MudanzaDistancia", gxTpr_Mudanzadistancia, false);


			AddObjectProperty("MudanzaVehiculoSugerido", gxTpr_Mudanzavehiculosugerido, false);


			AddObjectProperty("MudanzaPrecioBasexHora", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Mudanzapreciobasexhora, 18, 2)), false);


			AddObjectProperty("MudanzaPeajeCantidad", gxTpr_Mudanzapeajecantidad, false);


			AddObjectProperty("MudanzaComentario", gxTpr_Mudanzacomentario, false);


			AddObjectProperty("MudanzaPeajevalor", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Mudanzapeajevalor, 18, 2)), false);


			AddObjectProperty("TipoInmuebleOrigenId", gxTpr_Tipoinmuebleorigenid, false);


			AddObjectProperty("TipoInmuebleOrigenNombre", gxTpr_Tipoinmuebleorigennombre, false);


			AddObjectProperty("TipoInmuebleOrigenValor", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Tipoinmuebleorigenvalor, 18, 2)), false);


			AddObjectProperty("MudanzaOrigenMetodo", gxTpr_Mudanzaorigenmetodo, false);


			AddObjectProperty("TipoInmuebleDestinoId", gxTpr_Tipoinmuebledestinoid, false);


			AddObjectProperty("TipoInmuebleDestinoNombre", gxTpr_Tipoinmuebledestinonombre, false);


			AddObjectProperty("TipoInmuebleDestinoValor", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Tipoinmuebledestinovalor, 18, 2)), false);


			AddObjectProperty("TipoEstacionamOrigenId", gxTpr_Tipoestacionamorigenid, false);


			AddObjectProperty("TipoEstacionamOrigenNombre", gxTpr_Tipoestacionamorigennombre, false);


			AddObjectProperty("TipoEstacionamOrigenValor", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Tipoestacionamorigenvalor, 18, 2)), false);


			AddObjectProperty("TipoEstacionamDestinoId", gxTpr_Tipoestacionamdestinoid, false);


			AddObjectProperty("TipoEstacionamDestinoNombre", gxTpr_Tipoestacionamdestinonombre, false);


			AddObjectProperty("MudanzaDestinoMetodo", gxTpr_Mudanzadestinometodo, false);


			AddObjectProperty("TipoEstacionamDestinoValor", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Tipoestacionamdestinovalor, 18, 2)), false);


			AddObjectProperty("MudanzaTiempoMaximo", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Mudanzatiempomaximo, 18, 2)), false);


			AddObjectProperty("MudanzaCargaVolumenEstimado", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Mudanzacargavolumenestimado, 18, 2)), false);


			AddObjectProperty("MudanzaAdicionalPrecio", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Mudanzaadicionalprecio, 18, 2)), false);


			AddObjectProperty("MudanzaCantidadPeones", gxTpr_Mudanzacantidadpeones, false);


			AddObjectProperty("MudanzaElevacion", gxTpr_Mudanzaelevacion, false);


			AddObjectProperty("MudanzaDescenso", gxTpr_Mudanzadescenso, false);


			AddObjectProperty("MudanzaEmbalaje", gxTpr_Mudanzaembalaje, false);


			AddObjectProperty("MudanzaPrecioFinal", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Mudanzapreciofinal, 18, 2)), false);


			AddObjectProperty("MudanzaFormaPago", gxTpr_Mudanzaformapago, false);


			AddObjectProperty("MudanzaOperacionId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Mudanzaoperacionid, 18, 0)), false);


			AddObjectProperty("MudanzaProveedorId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Mudanzaproveedorid, 18, 0)), false);


			AddObjectProperty("MudanzaSecUserId", gxTpr_Mudanzasecuserid, false);

			if (gxTv_SdtSDTMudanza_Carga != null)
			{
				AddObjectProperty("Carga", gxTv_SdtSDTMudanza_Carga, false);
			}
			if (gxTv_SdtSDTMudanza_Adicional != null)
			{
				AddObjectProperty("Adicional", gxTv_SdtSDTMudanza_Adicional, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="MudanzaId")]
		[XmlElement(ElementName="MudanzaId")]
		public long gxTpr_Mudanzaid
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzaid; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzaid = value;
				SetDirty("Mudanzaid");
			}
		}




		[SoapElement(ElementName="MudanzaAsesor")]
		[XmlElement(ElementName="MudanzaAsesor")]
		public string gxTpr_Mudanzaasesor
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzaasesor; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzaasesor = value;
				SetDirty("Mudanzaasesor");
			}
		}




		[SoapElement(ElementName="MudanzaApellidoNombre")]
		[XmlElement(ElementName="MudanzaApellidoNombre")]
		public string gxTpr_Mudanzaapellidonombre
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzaapellidonombre; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzaapellidonombre = value;
				SetDirty("Mudanzaapellidonombre");
			}
		}




		[SoapElement(ElementName="MudanzaMail")]
		[XmlElement(ElementName="MudanzaMail")]
		public string gxTpr_Mudanzamail
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzamail; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzamail = value;
				SetDirty("Mudanzamail");
			}
		}




		[SoapElement(ElementName="MudanzaPhone")]
		[XmlElement(ElementName="MudanzaPhone")]
		public string gxTpr_Mudanzaphone
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzaphone; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzaphone = value;
				SetDirty("Mudanzaphone");
			}
		}



		[SoapElement(ElementName="MudanzaFechaAlta")]
		[XmlElement(ElementName="MudanzaFechaAlta" , IsNullable=true)]
		public string gxTpr_Mudanzafechaalta_Nullable
		{
			get {
				if ( gxTv_SdtSDTMudanza_Mudanzafechaalta == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTMudanza_Mudanzafechaalta).value ;
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzafechaalta = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Mudanzafechaalta
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzafechaalta; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzafechaalta = value;
				SetDirty("Mudanzafechaalta");
			}
		}


		[SoapElement(ElementName="MudanzaFechaUpdate")]
		[XmlElement(ElementName="MudanzaFechaUpdate" , IsNullable=true)]
		public string gxTpr_Mudanzafechaupdate_Nullable
		{
			get {
				if ( gxTv_SdtSDTMudanza_Mudanzafechaupdate == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTMudanza_Mudanzafechaupdate).value ;
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzafechaupdate = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Mudanzafechaupdate
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzafechaupdate; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzafechaupdate = value;
				SetDirty("Mudanzafechaupdate");
			}
		}


		[SoapElement(ElementName="MudanzaFechaServicio")]
		[XmlElement(ElementName="MudanzaFechaServicio" , IsNullable=true)]
		public string gxTpr_Mudanzafechaservicio_Nullable
		{
			get {
				if ( gxTv_SdtSDTMudanza_Mudanzafechaservicio == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTMudanza_Mudanzafechaservicio).value ;
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzafechaservicio = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Mudanzafechaservicio
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzafechaservicio; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzafechaservicio = value;
				SetDirty("Mudanzafechaservicio");
			}
		}



		[SoapElement(ElementName="MudanzaHoraServicio")]
		[XmlElement(ElementName="MudanzaHoraServicio")]
		public string gxTpr_Mudanzahoraservicio
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzahoraservicio; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzahoraservicio = value;
				SetDirty("Mudanzahoraservicio");
			}
		}




		[SoapElement(ElementName="MudanzaRgoHoraservicio")]
		[XmlElement(ElementName="MudanzaRgoHoraservicio")]
		public string gxTpr_Mudanzargohoraservicio
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzargohoraservicio; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzargohoraservicio = value;
				SetDirty("Mudanzargohoraservicio");
			}
		}




		[SoapElement(ElementName="MudanzaDireccionOrigen")]
		[XmlElement(ElementName="MudanzaDireccionOrigen")]
		public string gxTpr_Mudanzadireccionorigen
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzadireccionorigen; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzadireccionorigen = value;
				SetDirty("Mudanzadireccionorigen");
			}
		}




		[SoapElement(ElementName="MudanzaLocalidadOrigen")]
		[XmlElement(ElementName="MudanzaLocalidadOrigen")]
		public string gxTpr_Mudanzalocalidadorigen
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzalocalidadorigen; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzalocalidadorigen = value;
				SetDirty("Mudanzalocalidadorigen");
			}
		}




		[SoapElement(ElementName="MudanzaPisoDptoOrigen")]
		[XmlElement(ElementName="MudanzaPisoDptoOrigen")]
		public string gxTpr_Mudanzapisodptoorigen
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzapisodptoorigen; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzapisodptoorigen = value;
				SetDirty("Mudanzapisodptoorigen");
			}
		}




		[SoapElement(ElementName="MudanzaDireccionDestino")]
		[XmlElement(ElementName="MudanzaDireccionDestino")]
		public string gxTpr_Mudanzadirecciondestino
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzadirecciondestino; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzadirecciondestino = value;
				SetDirty("Mudanzadirecciondestino");
			}
		}




		[SoapElement(ElementName="MudanzaLocalidadDestino")]
		[XmlElement(ElementName="MudanzaLocalidadDestino")]
		public string gxTpr_Mudanzalocalidaddestino
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzalocalidaddestino; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzalocalidaddestino = value;
				SetDirty("Mudanzalocalidaddestino");
			}
		}




		[SoapElement(ElementName="MudanzaPisoDptoDestino")]
		[XmlElement(ElementName="MudanzaPisoDptoDestino")]
		public string gxTpr_Mudanzapisodptodestino
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzapisodptodestino; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzapisodptodestino = value;
				SetDirty("Mudanzapisodptodestino");
			}
		}




		[SoapElement(ElementName="MudanzaCoordenadasOrigen")]
		[XmlElement(ElementName="MudanzaCoordenadasOrigen")]
		public string gxTpr_Mudanzacoordenadasorigen
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzacoordenadasorigen; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzacoordenadasorigen = value;
				SetDirty("Mudanzacoordenadasorigen");
			}
		}




		[SoapElement(ElementName="MudanzaCoordenadasDestino")]
		[XmlElement(ElementName="MudanzaCoordenadasDestino")]
		public string gxTpr_Mudanzacoordenadasdestino
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzacoordenadasdestino; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzacoordenadasdestino = value;
				SetDirty("Mudanzacoordenadasdestino");
			}
		}



		[SoapElement(ElementName="MudanzaDistancia")]
		[XmlElement(ElementName="MudanzaDistancia")]
		public string gxTpr_Mudanzadistancia_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTMudanza_Mudanzadistancia, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzadistancia = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Mudanzadistancia
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzadistancia; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzadistancia = value;
				SetDirty("Mudanzadistancia");
			}
		}




		[SoapElement(ElementName="MudanzaVehiculoSugerido")]
		[XmlElement(ElementName="MudanzaVehiculoSugerido")]
		public string gxTpr_Mudanzavehiculosugerido
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzavehiculosugerido; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzavehiculosugerido = value;
				SetDirty("Mudanzavehiculosugerido");
			}
		}



		[SoapElement(ElementName="MudanzaPrecioBasexHora")]
		[XmlElement(ElementName="MudanzaPrecioBasexHora")]
		public string gxTpr_Mudanzapreciobasexhora_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTMudanza_Mudanzapreciobasexhora, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzapreciobasexhora = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Mudanzapreciobasexhora
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzapreciobasexhora; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzapreciobasexhora = value;
				SetDirty("Mudanzapreciobasexhora");
			}
		}




		[SoapElement(ElementName="MudanzaPeajeCantidad")]
		[XmlElement(ElementName="MudanzaPeajeCantidad")]
		public short gxTpr_Mudanzapeajecantidad
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzapeajecantidad; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzapeajecantidad = value;
				SetDirty("Mudanzapeajecantidad");
			}
		}




		[SoapElement(ElementName="MudanzaComentario")]
		[XmlElement(ElementName="MudanzaComentario")]
		public string gxTpr_Mudanzacomentario
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzacomentario; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzacomentario = value;
				SetDirty("Mudanzacomentario");
			}
		}



		[SoapElement(ElementName="MudanzaPeajevalor")]
		[XmlElement(ElementName="MudanzaPeajevalor")]
		public string gxTpr_Mudanzapeajevalor_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTMudanza_Mudanzapeajevalor, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzapeajevalor = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Mudanzapeajevalor
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzapeajevalor; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzapeajevalor = value;
				SetDirty("Mudanzapeajevalor");
			}
		}




		[SoapElement(ElementName="TipoInmuebleOrigenId")]
		[XmlElement(ElementName="TipoInmuebleOrigenId")]
		public short gxTpr_Tipoinmuebleorigenid
		{
			get {
				return gxTv_SdtSDTMudanza_Tipoinmuebleorigenid; 
			}
			set {
				gxTv_SdtSDTMudanza_Tipoinmuebleorigenid = value;
				SetDirty("Tipoinmuebleorigenid");
			}
		}




		[SoapElement(ElementName="TipoInmuebleOrigenNombre")]
		[XmlElement(ElementName="TipoInmuebleOrigenNombre")]
		public string gxTpr_Tipoinmuebleorigennombre
		{
			get {
				return gxTv_SdtSDTMudanza_Tipoinmuebleorigennombre; 
			}
			set {
				gxTv_SdtSDTMudanza_Tipoinmuebleorigennombre = value;
				SetDirty("Tipoinmuebleorigennombre");
			}
		}



		[SoapElement(ElementName="TipoInmuebleOrigenValor")]
		[XmlElement(ElementName="TipoInmuebleOrigenValor")]
		public string gxTpr_Tipoinmuebleorigenvalor_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTMudanza_Tipoinmuebleorigenvalor, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTMudanza_Tipoinmuebleorigenvalor = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Tipoinmuebleorigenvalor
		{
			get {
				return gxTv_SdtSDTMudanza_Tipoinmuebleorigenvalor; 
			}
			set {
				gxTv_SdtSDTMudanza_Tipoinmuebleorigenvalor = value;
				SetDirty("Tipoinmuebleorigenvalor");
			}
		}




		[SoapElement(ElementName="MudanzaOrigenMetodo")]
		[XmlElement(ElementName="MudanzaOrigenMetodo")]
		public string gxTpr_Mudanzaorigenmetodo
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzaorigenmetodo; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzaorigenmetodo = value;
				SetDirty("Mudanzaorigenmetodo");
			}
		}




		[SoapElement(ElementName="TipoInmuebleDestinoId")]
		[XmlElement(ElementName="TipoInmuebleDestinoId")]
		public short gxTpr_Tipoinmuebledestinoid
		{
			get {
				return gxTv_SdtSDTMudanza_Tipoinmuebledestinoid; 
			}
			set {
				gxTv_SdtSDTMudanza_Tipoinmuebledestinoid = value;
				SetDirty("Tipoinmuebledestinoid");
			}
		}




		[SoapElement(ElementName="TipoInmuebleDestinoNombre")]
		[XmlElement(ElementName="TipoInmuebleDestinoNombre")]
		public string gxTpr_Tipoinmuebledestinonombre
		{
			get {
				return gxTv_SdtSDTMudanza_Tipoinmuebledestinonombre; 
			}
			set {
				gxTv_SdtSDTMudanza_Tipoinmuebledestinonombre = value;
				SetDirty("Tipoinmuebledestinonombre");
			}
		}



		[SoapElement(ElementName="TipoInmuebleDestinoValor")]
		[XmlElement(ElementName="TipoInmuebleDestinoValor")]
		public string gxTpr_Tipoinmuebledestinovalor_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTMudanza_Tipoinmuebledestinovalor, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTMudanza_Tipoinmuebledestinovalor = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Tipoinmuebledestinovalor
		{
			get {
				return gxTv_SdtSDTMudanza_Tipoinmuebledestinovalor; 
			}
			set {
				gxTv_SdtSDTMudanza_Tipoinmuebledestinovalor = value;
				SetDirty("Tipoinmuebledestinovalor");
			}
		}




		[SoapElement(ElementName="TipoEstacionamOrigenId")]
		[XmlElement(ElementName="TipoEstacionamOrigenId")]
		public short gxTpr_Tipoestacionamorigenid
		{
			get {
				return gxTv_SdtSDTMudanza_Tipoestacionamorigenid; 
			}
			set {
				gxTv_SdtSDTMudanza_Tipoestacionamorigenid = value;
				SetDirty("Tipoestacionamorigenid");
			}
		}




		[SoapElement(ElementName="TipoEstacionamOrigenNombre")]
		[XmlElement(ElementName="TipoEstacionamOrigenNombre")]
		public string gxTpr_Tipoestacionamorigennombre
		{
			get {
				return gxTv_SdtSDTMudanza_Tipoestacionamorigennombre; 
			}
			set {
				gxTv_SdtSDTMudanza_Tipoestacionamorigennombre = value;
				SetDirty("Tipoestacionamorigennombre");
			}
		}



		[SoapElement(ElementName="TipoEstacionamOrigenValor")]
		[XmlElement(ElementName="TipoEstacionamOrigenValor")]
		public string gxTpr_Tipoestacionamorigenvalor_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTMudanza_Tipoestacionamorigenvalor, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTMudanza_Tipoestacionamorigenvalor = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Tipoestacionamorigenvalor
		{
			get {
				return gxTv_SdtSDTMudanza_Tipoestacionamorigenvalor; 
			}
			set {
				gxTv_SdtSDTMudanza_Tipoestacionamorigenvalor = value;
				SetDirty("Tipoestacionamorigenvalor");
			}
		}




		[SoapElement(ElementName="TipoEstacionamDestinoId")]
		[XmlElement(ElementName="TipoEstacionamDestinoId")]
		public short gxTpr_Tipoestacionamdestinoid
		{
			get {
				return gxTv_SdtSDTMudanza_Tipoestacionamdestinoid; 
			}
			set {
				gxTv_SdtSDTMudanza_Tipoestacionamdestinoid = value;
				SetDirty("Tipoestacionamdestinoid");
			}
		}




		[SoapElement(ElementName="TipoEstacionamDestinoNombre")]
		[XmlElement(ElementName="TipoEstacionamDestinoNombre")]
		public string gxTpr_Tipoestacionamdestinonombre
		{
			get {
				return gxTv_SdtSDTMudanza_Tipoestacionamdestinonombre; 
			}
			set {
				gxTv_SdtSDTMudanza_Tipoestacionamdestinonombre = value;
				SetDirty("Tipoestacionamdestinonombre");
			}
		}




		[SoapElement(ElementName="MudanzaDestinoMetodo")]
		[XmlElement(ElementName="MudanzaDestinoMetodo")]
		public string gxTpr_Mudanzadestinometodo
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzadestinometodo; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzadestinometodo = value;
				SetDirty("Mudanzadestinometodo");
			}
		}



		[SoapElement(ElementName="TipoEstacionamDestinoValor")]
		[XmlElement(ElementName="TipoEstacionamDestinoValor")]
		public string gxTpr_Tipoestacionamdestinovalor_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTMudanza_Tipoestacionamdestinovalor, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTMudanza_Tipoestacionamdestinovalor = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Tipoestacionamdestinovalor
		{
			get {
				return gxTv_SdtSDTMudanza_Tipoestacionamdestinovalor; 
			}
			set {
				gxTv_SdtSDTMudanza_Tipoestacionamdestinovalor = value;
				SetDirty("Tipoestacionamdestinovalor");
			}
		}



		[SoapElement(ElementName="MudanzaTiempoMaximo")]
		[XmlElement(ElementName="MudanzaTiempoMaximo")]
		public string gxTpr_Mudanzatiempomaximo_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTMudanza_Mudanzatiempomaximo, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzatiempomaximo = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Mudanzatiempomaximo
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzatiempomaximo; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzatiempomaximo = value;
				SetDirty("Mudanzatiempomaximo");
			}
		}



		[SoapElement(ElementName="MudanzaCargaVolumenEstimado")]
		[XmlElement(ElementName="MudanzaCargaVolumenEstimado")]
		public string gxTpr_Mudanzacargavolumenestimado_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTMudanza_Mudanzacargavolumenestimado, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzacargavolumenestimado = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Mudanzacargavolumenestimado
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzacargavolumenestimado; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzacargavolumenestimado = value;
				SetDirty("Mudanzacargavolumenestimado");
			}
		}



		[SoapElement(ElementName="MudanzaAdicionalPrecio")]
		[XmlElement(ElementName="MudanzaAdicionalPrecio")]
		public string gxTpr_Mudanzaadicionalprecio_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTMudanza_Mudanzaadicionalprecio, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzaadicionalprecio = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Mudanzaadicionalprecio
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzaadicionalprecio; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzaadicionalprecio = value;
				SetDirty("Mudanzaadicionalprecio");
			}
		}




		[SoapElement(ElementName="MudanzaCantidadPeones")]
		[XmlElement(ElementName="MudanzaCantidadPeones")]
		public short gxTpr_Mudanzacantidadpeones
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzacantidadpeones; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzacantidadpeones = value;
				SetDirty("Mudanzacantidadpeones");
			}
		}




		[SoapElement(ElementName="MudanzaElevacion")]
		[XmlElement(ElementName="MudanzaElevacion")]
		public short gxTpr_Mudanzaelevacion
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzaelevacion; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzaelevacion = value;
				SetDirty("Mudanzaelevacion");
			}
		}




		[SoapElement(ElementName="MudanzaDescenso")]
		[XmlElement(ElementName="MudanzaDescenso")]
		public short gxTpr_Mudanzadescenso
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzadescenso; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzadescenso = value;
				SetDirty("Mudanzadescenso");
			}
		}




		[SoapElement(ElementName="MudanzaEmbalaje")]
		[XmlElement(ElementName="MudanzaEmbalaje")]
		public short gxTpr_Mudanzaembalaje
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzaembalaje; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzaembalaje = value;
				SetDirty("Mudanzaembalaje");
			}
		}



		[SoapElement(ElementName="MudanzaPrecioFinal")]
		[XmlElement(ElementName="MudanzaPrecioFinal")]
		public string gxTpr_Mudanzapreciofinal_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTMudanza_Mudanzapreciofinal, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzapreciofinal = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Mudanzapreciofinal
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzapreciofinal; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzapreciofinal = value;
				SetDirty("Mudanzapreciofinal");
			}
		}




		[SoapElement(ElementName="MudanzaFormaPago")]
		[XmlElement(ElementName="MudanzaFormaPago")]
		public string gxTpr_Mudanzaformapago
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzaformapago; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzaformapago = value;
				SetDirty("Mudanzaformapago");
			}
		}




		[SoapElement(ElementName="MudanzaOperacionId")]
		[XmlElement(ElementName="MudanzaOperacionId")]
		public long gxTpr_Mudanzaoperacionid
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzaoperacionid; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzaoperacionid = value;
				SetDirty("Mudanzaoperacionid");
			}
		}




		[SoapElement(ElementName="MudanzaProveedorId")]
		[XmlElement(ElementName="MudanzaProveedorId")]
		public long gxTpr_Mudanzaproveedorid
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzaproveedorid; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzaproveedorid = value;
				SetDirty("Mudanzaproveedorid");
			}
		}




		[SoapElement(ElementName="MudanzaSecUserId")]
		[XmlElement(ElementName="MudanzaSecUserId")]
		public long gxTpr_Mudanzasecuserid
		{
			get {
				return gxTv_SdtSDTMudanza_Mudanzasecuserid; 
			}
			set {
				gxTv_SdtSDTMudanza_Mudanzasecuserid = value;
				SetDirty("Mudanzasecuserid");
			}
		}




		[SoapElement(ElementName="Carga" )]
		[XmlArray(ElementName="Carga"  )]
		[XmlArrayItemAttribute(ElementName="CargaItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTMudanza_CargaItem> gxTpr_Carga
		{
			get {
				if ( gxTv_SdtSDTMudanza_Carga == null )
				{
					gxTv_SdtSDTMudanza_Carga = new GXBaseCollection<SdtSDTMudanza_CargaItem>( context, "SDTMudanza.CargaItem", "");
				}
				SetDirty("Carga");
				return gxTv_SdtSDTMudanza_Carga;
			}
			set {
				gxTv_SdtSDTMudanza_Carga_N = false;
				gxTv_SdtSDTMudanza_Carga = value;
				SetDirty("Carga");
			}
		}

		public void gxTv_SdtSDTMudanza_Carga_SetNull()
		{
			gxTv_SdtSDTMudanza_Carga_N = true;
			gxTv_SdtSDTMudanza_Carga = null;
		}

		public bool gxTv_SdtSDTMudanza_Carga_IsNull()
		{
			return gxTv_SdtSDTMudanza_Carga == null;
		}
		public bool ShouldSerializegxTpr_Carga_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTMudanza_Carga != null && gxTv_SdtSDTMudanza_Carga.Count > 0;

		}



		[SoapElement(ElementName="Adicional" )]
		[XmlArray(ElementName="Adicional"  )]
		[XmlArrayItemAttribute(ElementName="AdicionalItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTMudanza_AdicionalItem> gxTpr_Adicional
		{
			get {
				if ( gxTv_SdtSDTMudanza_Adicional == null )
				{
					gxTv_SdtSDTMudanza_Adicional = new GXBaseCollection<SdtSDTMudanza_AdicionalItem>( context, "SDTMudanza.AdicionalItem", "");
				}
				SetDirty("Adicional");
				return gxTv_SdtSDTMudanza_Adicional;
			}
			set {
				gxTv_SdtSDTMudanza_Adicional_N = false;
				gxTv_SdtSDTMudanza_Adicional = value;
				SetDirty("Adicional");
			}
		}

		public void gxTv_SdtSDTMudanza_Adicional_SetNull()
		{
			gxTv_SdtSDTMudanza_Adicional_N = true;
			gxTv_SdtSDTMudanza_Adicional = null;
		}

		public bool gxTv_SdtSDTMudanza_Adicional_IsNull()
		{
			return gxTv_SdtSDTMudanza_Adicional == null;
		}
		public bool ShouldSerializegxTpr_Adicional_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTMudanza_Adicional != null && gxTv_SdtSDTMudanza_Adicional.Count > 0;

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
			gxTv_SdtSDTMudanza_Mudanzaasesor = "";
			gxTv_SdtSDTMudanza_Mudanzaapellidonombre = "";
			gxTv_SdtSDTMudanza_Mudanzamail = "";
			gxTv_SdtSDTMudanza_Mudanzaphone = "";



			gxTv_SdtSDTMudanza_Mudanzahoraservicio = "";
			gxTv_SdtSDTMudanza_Mudanzargohoraservicio = "";
			gxTv_SdtSDTMudanza_Mudanzadireccionorigen = "";
			gxTv_SdtSDTMudanza_Mudanzalocalidadorigen = "";
			gxTv_SdtSDTMudanza_Mudanzapisodptoorigen = "";
			gxTv_SdtSDTMudanza_Mudanzadirecciondestino = "";
			gxTv_SdtSDTMudanza_Mudanzalocalidaddestino = "";
			gxTv_SdtSDTMudanza_Mudanzapisodptodestino = "";
			gxTv_SdtSDTMudanza_Mudanzacoordenadasorigen = "";
			gxTv_SdtSDTMudanza_Mudanzacoordenadasdestino = "";

			gxTv_SdtSDTMudanza_Mudanzavehiculosugerido = "";


			gxTv_SdtSDTMudanza_Mudanzacomentario = "";


			gxTv_SdtSDTMudanza_Tipoinmuebleorigennombre = "";

			gxTv_SdtSDTMudanza_Mudanzaorigenmetodo = "";

			gxTv_SdtSDTMudanza_Tipoinmuebledestinonombre = "";


			gxTv_SdtSDTMudanza_Tipoestacionamorigennombre = "";


			gxTv_SdtSDTMudanza_Tipoestacionamdestinonombre = "";
			gxTv_SdtSDTMudanza_Mudanzadestinometodo = "";









			gxTv_SdtSDTMudanza_Mudanzaformapago = "";




			gxTv_SdtSDTMudanza_Carga_N = true;


			gxTv_SdtSDTMudanza_Adicional_N = true;

			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected long gxTv_SdtSDTMudanza_Mudanzaid;
		 

		protected string gxTv_SdtSDTMudanza_Mudanzaasesor;
		 

		protected string gxTv_SdtSDTMudanza_Mudanzaapellidonombre;
		 

		protected string gxTv_SdtSDTMudanza_Mudanzamail;
		 

		protected string gxTv_SdtSDTMudanza_Mudanzaphone;
		 

		protected DateTime gxTv_SdtSDTMudanza_Mudanzafechaalta;
		 

		protected DateTime gxTv_SdtSDTMudanza_Mudanzafechaupdate;
		 

		protected DateTime gxTv_SdtSDTMudanza_Mudanzafechaservicio;
		 

		protected string gxTv_SdtSDTMudanza_Mudanzahoraservicio;
		 

		protected string gxTv_SdtSDTMudanza_Mudanzargohoraservicio;
		 

		protected string gxTv_SdtSDTMudanza_Mudanzadireccionorigen;
		 

		protected string gxTv_SdtSDTMudanza_Mudanzalocalidadorigen;
		 

		protected string gxTv_SdtSDTMudanza_Mudanzapisodptoorigen;
		 

		protected string gxTv_SdtSDTMudanza_Mudanzadirecciondestino;
		 

		protected string gxTv_SdtSDTMudanza_Mudanzalocalidaddestino;
		 

		protected string gxTv_SdtSDTMudanza_Mudanzapisodptodestino;
		 

		protected string gxTv_SdtSDTMudanza_Mudanzacoordenadasorigen;
		 

		protected string gxTv_SdtSDTMudanza_Mudanzacoordenadasdestino;
		 

		protected decimal gxTv_SdtSDTMudanza_Mudanzadistancia;
		 

		protected string gxTv_SdtSDTMudanza_Mudanzavehiculosugerido;
		 

		protected decimal gxTv_SdtSDTMudanza_Mudanzapreciobasexhora;
		 

		protected short gxTv_SdtSDTMudanza_Mudanzapeajecantidad;
		 

		protected string gxTv_SdtSDTMudanza_Mudanzacomentario;
		 

		protected decimal gxTv_SdtSDTMudanza_Mudanzapeajevalor;
		 

		protected short gxTv_SdtSDTMudanza_Tipoinmuebleorigenid;
		 

		protected string gxTv_SdtSDTMudanza_Tipoinmuebleorigennombre;
		 

		protected decimal gxTv_SdtSDTMudanza_Tipoinmuebleorigenvalor;
		 

		protected string gxTv_SdtSDTMudanza_Mudanzaorigenmetodo;
		 

		protected short gxTv_SdtSDTMudanza_Tipoinmuebledestinoid;
		 

		protected string gxTv_SdtSDTMudanza_Tipoinmuebledestinonombre;
		 

		protected decimal gxTv_SdtSDTMudanza_Tipoinmuebledestinovalor;
		 

		protected short gxTv_SdtSDTMudanza_Tipoestacionamorigenid;
		 

		protected string gxTv_SdtSDTMudanza_Tipoestacionamorigennombre;
		 

		protected decimal gxTv_SdtSDTMudanza_Tipoestacionamorigenvalor;
		 

		protected short gxTv_SdtSDTMudanza_Tipoestacionamdestinoid;
		 

		protected string gxTv_SdtSDTMudanza_Tipoestacionamdestinonombre;
		 

		protected string gxTv_SdtSDTMudanza_Mudanzadestinometodo;
		 

		protected decimal gxTv_SdtSDTMudanza_Tipoestacionamdestinovalor;
		 

		protected decimal gxTv_SdtSDTMudanza_Mudanzatiempomaximo;
		 

		protected decimal gxTv_SdtSDTMudanza_Mudanzacargavolumenestimado;
		 

		protected decimal gxTv_SdtSDTMudanza_Mudanzaadicionalprecio;
		 

		protected short gxTv_SdtSDTMudanza_Mudanzacantidadpeones;
		 

		protected short gxTv_SdtSDTMudanza_Mudanzaelevacion;
		 

		protected short gxTv_SdtSDTMudanza_Mudanzadescenso;
		 

		protected short gxTv_SdtSDTMudanza_Mudanzaembalaje;
		 

		protected decimal gxTv_SdtSDTMudanza_Mudanzapreciofinal;
		 

		protected string gxTv_SdtSDTMudanza_Mudanzaformapago;
		 

		protected long gxTv_SdtSDTMudanza_Mudanzaoperacionid;
		 

		protected long gxTv_SdtSDTMudanza_Mudanzaproveedorid;
		 

		protected long gxTv_SdtSDTMudanza_Mudanzasecuserid;
		 
		protected bool gxTv_SdtSDTMudanza_Carga_N;
		protected GXBaseCollection<SdtSDTMudanza_CargaItem> gxTv_SdtSDTMudanza_Carga = null; 

		protected bool gxTv_SdtSDTMudanza_Adicional_N;
		protected GXBaseCollection<SdtSDTMudanza_AdicionalItem> gxTv_SdtSDTMudanza_Adicional = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTMudanza", Namespace="AlmangoX")]
	public class SdtSDTMudanza_RESTInterface : GxGenericCollectionItem<SdtSDTMudanza>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTMudanza_RESTInterface( ) : base()
		{	
		}

		public SdtSDTMudanza_RESTInterface( SdtSDTMudanza psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="MudanzaId", Order=0)]
		public  string gxTpr_Mudanzaid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Mudanzaid, 18, 0));

			}
			set { 
				sdt.gxTpr_Mudanzaid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MudanzaAsesor", Order=1)]
		public  string gxTpr_Mudanzaasesor
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mudanzaasesor);

			}
			set { 
				 sdt.gxTpr_Mudanzaasesor = value;
			}
		}

		[DataMember(Name="MudanzaApellidoNombre", Order=2)]
		public  string gxTpr_Mudanzaapellidonombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mudanzaapellidonombre);

			}
			set { 
				 sdt.gxTpr_Mudanzaapellidonombre = value;
			}
		}

		[DataMember(Name="MudanzaMail", Order=3)]
		public  string gxTpr_Mudanzamail
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mudanzamail);

			}
			set { 
				 sdt.gxTpr_Mudanzamail = value;
			}
		}

		[DataMember(Name="MudanzaPhone", Order=4)]
		public  string gxTpr_Mudanzaphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mudanzaphone);

			}
			set { 
				 sdt.gxTpr_Mudanzaphone = value;
			}
		}

		[DataMember(Name="MudanzaFechaAlta", Order=5)]
		public  string gxTpr_Mudanzafechaalta
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Mudanzafechaalta);

			}
			set { 
				sdt.gxTpr_Mudanzafechaalta = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="MudanzaFechaUpdate", Order=6)]
		public  string gxTpr_Mudanzafechaupdate
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Mudanzafechaupdate);

			}
			set { 
				sdt.gxTpr_Mudanzafechaupdate = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="MudanzaFechaServicio", Order=7)]
		public  string gxTpr_Mudanzafechaservicio
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Mudanzafechaservicio);

			}
			set { 
				sdt.gxTpr_Mudanzafechaservicio = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="MudanzaHoraServicio", Order=8)]
		public  string gxTpr_Mudanzahoraservicio
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mudanzahoraservicio);

			}
			set { 
				 sdt.gxTpr_Mudanzahoraservicio = value;
			}
		}

		[DataMember(Name="MudanzaRgoHoraservicio", Order=9)]
		public  string gxTpr_Mudanzargohoraservicio
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mudanzargohoraservicio);

			}
			set { 
				 sdt.gxTpr_Mudanzargohoraservicio = value;
			}
		}

		[DataMember(Name="MudanzaDireccionOrigen", Order=10)]
		public  string gxTpr_Mudanzadireccionorigen
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mudanzadireccionorigen);

			}
			set { 
				 sdt.gxTpr_Mudanzadireccionorigen = value;
			}
		}

		[DataMember(Name="MudanzaLocalidadOrigen", Order=11)]
		public  string gxTpr_Mudanzalocalidadorigen
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mudanzalocalidadorigen);

			}
			set { 
				 sdt.gxTpr_Mudanzalocalidadorigen = value;
			}
		}

		[DataMember(Name="MudanzaPisoDptoOrigen", Order=12)]
		public  string gxTpr_Mudanzapisodptoorigen
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mudanzapisodptoorigen);

			}
			set { 
				 sdt.gxTpr_Mudanzapisodptoorigen = value;
			}
		}

		[DataMember(Name="MudanzaDireccionDestino", Order=13)]
		public  string gxTpr_Mudanzadirecciondestino
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mudanzadirecciondestino);

			}
			set { 
				 sdt.gxTpr_Mudanzadirecciondestino = value;
			}
		}

		[DataMember(Name="MudanzaLocalidadDestino", Order=14)]
		public  string gxTpr_Mudanzalocalidaddestino
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mudanzalocalidaddestino);

			}
			set { 
				 sdt.gxTpr_Mudanzalocalidaddestino = value;
			}
		}

		[DataMember(Name="MudanzaPisoDptoDestino", Order=15)]
		public  string gxTpr_Mudanzapisodptodestino
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mudanzapisodptodestino);

			}
			set { 
				 sdt.gxTpr_Mudanzapisodptodestino = value;
			}
		}

		[DataMember(Name="MudanzaCoordenadasOrigen", Order=16)]
		public  string gxTpr_Mudanzacoordenadasorigen
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mudanzacoordenadasorigen);

			}
			set { 
				 sdt.gxTpr_Mudanzacoordenadasorigen = value;
			}
		}

		[DataMember(Name="MudanzaCoordenadasDestino", Order=17)]
		public  string gxTpr_Mudanzacoordenadasdestino
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mudanzacoordenadasdestino);

			}
			set { 
				 sdt.gxTpr_Mudanzacoordenadasdestino = value;
			}
		}

		[DataMember(Name="MudanzaDistancia", Order=18)]
		public  string gxTpr_Mudanzadistancia
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Mudanzadistancia, 10, 2));

			}
			set { 
				sdt.gxTpr_Mudanzadistancia =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MudanzaVehiculoSugerido", Order=19)]
		public  string gxTpr_Mudanzavehiculosugerido
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mudanzavehiculosugerido);

			}
			set { 
				 sdt.gxTpr_Mudanzavehiculosugerido = value;
			}
		}

		[DataMember(Name="MudanzaPrecioBasexHora", Order=20)]
		public  string gxTpr_Mudanzapreciobasexhora
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Mudanzapreciobasexhora, 18, 2));

			}
			set { 
				sdt.gxTpr_Mudanzapreciobasexhora =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MudanzaPeajeCantidad", Order=21)]
		public short gxTpr_Mudanzapeajecantidad
		{
			get { 
				return sdt.gxTpr_Mudanzapeajecantidad;

			}
			set { 
				sdt.gxTpr_Mudanzapeajecantidad = value;
			}
		}

		[DataMember(Name="MudanzaComentario", Order=22)]
		public  string gxTpr_Mudanzacomentario
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mudanzacomentario);

			}
			set { 
				 sdt.gxTpr_Mudanzacomentario = value;
			}
		}

		[DataMember(Name="MudanzaPeajevalor", Order=23)]
		public  string gxTpr_Mudanzapeajevalor
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Mudanzapeajevalor, 18, 2));

			}
			set { 
				sdt.gxTpr_Mudanzapeajevalor =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TipoInmuebleOrigenId", Order=24)]
		public short gxTpr_Tipoinmuebleorigenid
		{
			get { 
				return sdt.gxTpr_Tipoinmuebleorigenid;

			}
			set { 
				sdt.gxTpr_Tipoinmuebleorigenid = value;
			}
		}

		[DataMember(Name="TipoInmuebleOrigenNombre", Order=25)]
		public  string gxTpr_Tipoinmuebleorigennombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tipoinmuebleorigennombre);

			}
			set { 
				 sdt.gxTpr_Tipoinmuebleorigennombre = value;
			}
		}

		[DataMember(Name="TipoInmuebleOrigenValor", Order=26)]
		public  string gxTpr_Tipoinmuebleorigenvalor
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tipoinmuebleorigenvalor, 18, 2));

			}
			set { 
				sdt.gxTpr_Tipoinmuebleorigenvalor =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MudanzaOrigenMetodo", Order=27)]
		public  string gxTpr_Mudanzaorigenmetodo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mudanzaorigenmetodo);

			}
			set { 
				 sdt.gxTpr_Mudanzaorigenmetodo = value;
			}
		}

		[DataMember(Name="TipoInmuebleDestinoId", Order=28)]
		public short gxTpr_Tipoinmuebledestinoid
		{
			get { 
				return sdt.gxTpr_Tipoinmuebledestinoid;

			}
			set { 
				sdt.gxTpr_Tipoinmuebledestinoid = value;
			}
		}

		[DataMember(Name="TipoInmuebleDestinoNombre", Order=29)]
		public  string gxTpr_Tipoinmuebledestinonombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tipoinmuebledestinonombre);

			}
			set { 
				 sdt.gxTpr_Tipoinmuebledestinonombre = value;
			}
		}

		[DataMember(Name="TipoInmuebleDestinoValor", Order=30)]
		public  string gxTpr_Tipoinmuebledestinovalor
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tipoinmuebledestinovalor, 18, 2));

			}
			set { 
				sdt.gxTpr_Tipoinmuebledestinovalor =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TipoEstacionamOrigenId", Order=31)]
		public short gxTpr_Tipoestacionamorigenid
		{
			get { 
				return sdt.gxTpr_Tipoestacionamorigenid;

			}
			set { 
				sdt.gxTpr_Tipoestacionamorigenid = value;
			}
		}

		[DataMember(Name="TipoEstacionamOrigenNombre", Order=32)]
		public  string gxTpr_Tipoestacionamorigennombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tipoestacionamorigennombre);

			}
			set { 
				 sdt.gxTpr_Tipoestacionamorigennombre = value;
			}
		}

		[DataMember(Name="TipoEstacionamOrigenValor", Order=33)]
		public  string gxTpr_Tipoestacionamorigenvalor
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tipoestacionamorigenvalor, 18, 2));

			}
			set { 
				sdt.gxTpr_Tipoestacionamorigenvalor =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TipoEstacionamDestinoId", Order=34)]
		public short gxTpr_Tipoestacionamdestinoid
		{
			get { 
				return sdt.gxTpr_Tipoestacionamdestinoid;

			}
			set { 
				sdt.gxTpr_Tipoestacionamdestinoid = value;
			}
		}

		[DataMember(Name="TipoEstacionamDestinoNombre", Order=35)]
		public  string gxTpr_Tipoestacionamdestinonombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tipoestacionamdestinonombre);

			}
			set { 
				 sdt.gxTpr_Tipoestacionamdestinonombre = value;
			}
		}

		[DataMember(Name="MudanzaDestinoMetodo", Order=36)]
		public  string gxTpr_Mudanzadestinometodo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mudanzadestinometodo);

			}
			set { 
				 sdt.gxTpr_Mudanzadestinometodo = value;
			}
		}

		[DataMember(Name="TipoEstacionamDestinoValor", Order=37)]
		public  string gxTpr_Tipoestacionamdestinovalor
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tipoestacionamdestinovalor, 18, 2));

			}
			set { 
				sdt.gxTpr_Tipoestacionamdestinovalor =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MudanzaTiempoMaximo", Order=38)]
		public  string gxTpr_Mudanzatiempomaximo
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Mudanzatiempomaximo, 18, 2));

			}
			set { 
				sdt.gxTpr_Mudanzatiempomaximo =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MudanzaCargaVolumenEstimado", Order=39)]
		public  string gxTpr_Mudanzacargavolumenestimado
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Mudanzacargavolumenestimado, 18, 2));

			}
			set { 
				sdt.gxTpr_Mudanzacargavolumenestimado =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MudanzaAdicionalPrecio", Order=40)]
		public  string gxTpr_Mudanzaadicionalprecio
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Mudanzaadicionalprecio, 18, 2));

			}
			set { 
				sdt.gxTpr_Mudanzaadicionalprecio =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MudanzaCantidadPeones", Order=41)]
		public short gxTpr_Mudanzacantidadpeones
		{
			get { 
				return sdt.gxTpr_Mudanzacantidadpeones;

			}
			set { 
				sdt.gxTpr_Mudanzacantidadpeones = value;
			}
		}

		[DataMember(Name="MudanzaElevacion", Order=42)]
		public short gxTpr_Mudanzaelevacion
		{
			get { 
				return sdt.gxTpr_Mudanzaelevacion;

			}
			set { 
				sdt.gxTpr_Mudanzaelevacion = value;
			}
		}

		[DataMember(Name="MudanzaDescenso", Order=43)]
		public short gxTpr_Mudanzadescenso
		{
			get { 
				return sdt.gxTpr_Mudanzadescenso;

			}
			set { 
				sdt.gxTpr_Mudanzadescenso = value;
			}
		}

		[DataMember(Name="MudanzaEmbalaje", Order=44)]
		public short gxTpr_Mudanzaembalaje
		{
			get { 
				return sdt.gxTpr_Mudanzaembalaje;

			}
			set { 
				sdt.gxTpr_Mudanzaembalaje = value;
			}
		}

		[DataMember(Name="MudanzaPrecioFinal", Order=45)]
		public  string gxTpr_Mudanzapreciofinal
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Mudanzapreciofinal, 18, 2));

			}
			set { 
				sdt.gxTpr_Mudanzapreciofinal =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MudanzaFormaPago", Order=46)]
		public  string gxTpr_Mudanzaformapago
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mudanzaformapago);

			}
			set { 
				 sdt.gxTpr_Mudanzaformapago = value;
			}
		}

		[DataMember(Name="MudanzaOperacionId", Order=47)]
		public  string gxTpr_Mudanzaoperacionid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Mudanzaoperacionid, 18, 0));

			}
			set { 
				sdt.gxTpr_Mudanzaoperacionid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MudanzaProveedorId", Order=48)]
		public  string gxTpr_Mudanzaproveedorid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Mudanzaproveedorid, 18, 0));

			}
			set { 
				sdt.gxTpr_Mudanzaproveedorid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MudanzaSecUserId", Order=49)]
		public  string gxTpr_Mudanzasecuserid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Mudanzasecuserid, 10, 0));

			}
			set { 
				sdt.gxTpr_Mudanzasecuserid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Carga", Order=50, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTMudanza_CargaItem_RESTInterface> gxTpr_Carga
		{
			get {
				if (sdt.ShouldSerializegxTpr_Carga_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTMudanza_CargaItem_RESTInterface>(sdt.gxTpr_Carga);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Carga);
			}
		}

		[DataMember(Name="Adicional", Order=51, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTMudanza_AdicionalItem_RESTInterface> gxTpr_Adicional
		{
			get {
				if (sdt.ShouldSerializegxTpr_Adicional_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTMudanza_AdicionalItem_RESTInterface>(sdt.gxTpr_Adicional);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Adicional);
			}
		}


		#endregion
		public SdtSDTMudanza sdt
		{
			get { 
				return (SdtSDTMudanza)Sdt;
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
				sdt = new SdtSDTMudanza() ;
			}
		}
	}
	#endregion
}