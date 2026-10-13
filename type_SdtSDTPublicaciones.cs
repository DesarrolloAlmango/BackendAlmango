/*
				   File: type_SdtSDTPublicaciones
			Description: SDTPublicaciones
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
	[XmlRoot(ElementName="SDTPublicaciones")]
	[XmlType(TypeName="SDTPublicaciones" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTPublicaciones : GxUserType
	{
		public SdtSDTPublicaciones( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTPublicaciones_Publicacionestitulo = "";

			gxTv_SdtSDTPublicaciones_Publicacionesdescripcion = "";

			gxTv_SdtSDTPublicaciones_Publicacionesdetallemateriales = "";

			gxTv_SdtSDTPublicaciones_Publicacioneshoravisita = "";

			gxTv_SdtSDTPublicaciones_Publicacionesdirvisita = "";

			gxTv_SdtSDTPublicaciones_Publicacionescondiciones = "";

			gxTv_SdtSDTPublicaciones_Publicacionestipodesembolso = "";

			gxTv_SdtSDTPublicaciones_Publicacionesotrotipodes = "";

			gxTv_SdtSDTPublicaciones_Publicacionesmodalidad = "";

			gxTv_SdtSDTPublicaciones_Monedaisosimbolo = "";

			gxTv_SdtSDTPublicaciones_Publicacionesdocreq = "";

			gxTv_SdtSDTPublicaciones_Publicacionesdocdescripcion = "";

			gxTv_SdtSDTPublicaciones_Publicacionestipoempresa = "";

			gxTv_SdtSDTPublicaciones_Publicacionescontratoid = "";

			gxTv_SdtSDTPublicaciones_Publicacionesterminoobra = "";

			gxTv_SdtSDTPublicaciones_Publicacionesestado = "";


		}

		public SdtSDTPublicaciones(IGxContext context)
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
			AddObjectProperty("PublicacionesId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Publicacionesid, 18, 0)), false);


			AddObjectProperty("PublicacionesTitulo", gxTpr_Publicacionestitulo, false);


			AddObjectProperty("PublicacionesDescripcion", gxTpr_Publicacionesdescripcion, false);


			AddObjectProperty("DepartamentoId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Departamentoid, 18, 0)), false);


			AddObjectProperty("DepartamentoMunicipioId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Departamentomunicipioid, 18, 0)), false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Publicacionesfectentinicio)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Publicacionesfectentinicio)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Publicacionesfectentinicio)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("PublicacionesFecTentInicio", sDateCnv, false);



			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Publicacionesfecrealinicio)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Publicacionesfecrealinicio)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Publicacionesfecrealinicio)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("PublicacionesFecRealInicio", sDateCnv, false);



			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Publicacionesfecfinpostulacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Publicacionesfecfinpostulacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Publicacionesfecfinpostulacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("PublicacionesFecFinPostulacion", sDateCnv, false);



			AddObjectProperty("PublicacionesDetalleMateriales", gxTpr_Publicacionesdetallemateriales, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Publicacionesfecvisita)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Publicacionesfecvisita)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Publicacionesfecvisita)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("PublicacionesFecVisita", sDateCnv, false);



			AddObjectProperty("PublicacionesHoraVisita", gxTpr_Publicacioneshoravisita, false);


			AddObjectProperty("PublicacionesDirVisita", gxTpr_Publicacionesdirvisita, false);


			AddObjectProperty("PublicacionesCondiciones", gxTpr_Publicacionescondiciones, false);


			AddObjectProperty("PublicacionesTipoDesembolso", gxTpr_Publicacionestipodesembolso, false);


			AddObjectProperty("PublicacionesOtroTipoDes", gxTpr_Publicacionesotrotipodes, false);


			AddObjectProperty("PublicacionesModalidad", gxTpr_Publicacionesmodalidad, false);


			AddObjectProperty("PublicacionesPrecio", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Publicacionesprecio, 18, 2)), false);


			AddObjectProperty("MonedaId", gxTpr_Monedaid, false);


			AddObjectProperty("MonedaISOSimbolo", gxTpr_Monedaisosimbolo, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Publicacionesfeccierre)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Publicacionesfeccierre)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Publicacionesfeccierre)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("PublicacionesFecCierre", sDateCnv, false);



			AddObjectProperty("PublicacionesDocReq", gxTpr_Publicacionesdocreq, false);


			AddObjectProperty("PublicacionesDocDescripcion", gxTpr_Publicacionesdocdescripcion, false);


			AddObjectProperty("PublicacionesTipoEmpresa", gxTpr_Publicacionestipoempresa, false);


			AddObjectProperty("PublicacionesContratoId", gxTpr_Publicacionescontratoid, false);


			AddObjectProperty("PublicacionesTerminoObra", gxTpr_Publicacionesterminoobra, false);


			AddObjectProperty("PublicacionesEstado", gxTpr_Publicacionesestado, false);


			AddObjectProperty("PublicacionesSerialIma", gxTpr_Publicacionesserialima, false);


			AddObjectProperty("PublicacionesSerialRem", gxTpr_Publicacionesserialrem, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PublicacionesId")]
		[XmlElement(ElementName="PublicacionesId")]
		public long gxTpr_Publicacionesid
		{
			get {
				return gxTv_SdtSDTPublicaciones_Publicacionesid; 
			}
			set {
				gxTv_SdtSDTPublicaciones_Publicacionesid = value;
				SetDirty("Publicacionesid");
			}
		}




		[SoapElement(ElementName="PublicacionesTitulo")]
		[XmlElement(ElementName="PublicacionesTitulo")]
		public string gxTpr_Publicacionestitulo
		{
			get {
				return gxTv_SdtSDTPublicaciones_Publicacionestitulo; 
			}
			set {
				gxTv_SdtSDTPublicaciones_Publicacionestitulo = value;
				SetDirty("Publicacionestitulo");
			}
		}




		[SoapElement(ElementName="PublicacionesDescripcion")]
		[XmlElement(ElementName="PublicacionesDescripcion")]
		public string gxTpr_Publicacionesdescripcion
		{
			get {
				return gxTv_SdtSDTPublicaciones_Publicacionesdescripcion; 
			}
			set {
				gxTv_SdtSDTPublicaciones_Publicacionesdescripcion = value;
				SetDirty("Publicacionesdescripcion");
			}
		}




		[SoapElement(ElementName="DepartamentoId")]
		[XmlElement(ElementName="DepartamentoId")]
		public long gxTpr_Departamentoid
		{
			get {
				return gxTv_SdtSDTPublicaciones_Departamentoid; 
			}
			set {
				gxTv_SdtSDTPublicaciones_Departamentoid = value;
				SetDirty("Departamentoid");
			}
		}




		[SoapElement(ElementName="DepartamentoMunicipioId")]
		[XmlElement(ElementName="DepartamentoMunicipioId")]
		public long gxTpr_Departamentomunicipioid
		{
			get {
				return gxTv_SdtSDTPublicaciones_Departamentomunicipioid; 
			}
			set {
				gxTv_SdtSDTPublicaciones_Departamentomunicipioid = value;
				SetDirty("Departamentomunicipioid");
			}
		}



		[SoapElement(ElementName="PublicacionesFecTentInicio")]
		[XmlElement(ElementName="PublicacionesFecTentInicio" , IsNullable=true)]
		public string gxTpr_Publicacionesfectentinicio_Nullable
		{
			get {
				if ( gxTv_SdtSDTPublicaciones_Publicacionesfectentinicio == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTPublicaciones_Publicacionesfectentinicio).value ;
			}
			set {
				gxTv_SdtSDTPublicaciones_Publicacionesfectentinicio = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Publicacionesfectentinicio
		{
			get {
				return gxTv_SdtSDTPublicaciones_Publicacionesfectentinicio; 
			}
			set {
				gxTv_SdtSDTPublicaciones_Publicacionesfectentinicio = value;
				SetDirty("Publicacionesfectentinicio");
			}
		}


		[SoapElement(ElementName="PublicacionesFecRealInicio")]
		[XmlElement(ElementName="PublicacionesFecRealInicio" , IsNullable=true)]
		public string gxTpr_Publicacionesfecrealinicio_Nullable
		{
			get {
				if ( gxTv_SdtSDTPublicaciones_Publicacionesfecrealinicio == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTPublicaciones_Publicacionesfecrealinicio).value ;
			}
			set {
				gxTv_SdtSDTPublicaciones_Publicacionesfecrealinicio = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Publicacionesfecrealinicio
		{
			get {
				return gxTv_SdtSDTPublicaciones_Publicacionesfecrealinicio; 
			}
			set {
				gxTv_SdtSDTPublicaciones_Publicacionesfecrealinicio = value;
				SetDirty("Publicacionesfecrealinicio");
			}
		}


		[SoapElement(ElementName="PublicacionesFecFinPostulacion")]
		[XmlElement(ElementName="PublicacionesFecFinPostulacion" , IsNullable=true)]
		public string gxTpr_Publicacionesfecfinpostulacion_Nullable
		{
			get {
				if ( gxTv_SdtSDTPublicaciones_Publicacionesfecfinpostulacion == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTPublicaciones_Publicacionesfecfinpostulacion).value ;
			}
			set {
				gxTv_SdtSDTPublicaciones_Publicacionesfecfinpostulacion = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Publicacionesfecfinpostulacion
		{
			get {
				return gxTv_SdtSDTPublicaciones_Publicacionesfecfinpostulacion; 
			}
			set {
				gxTv_SdtSDTPublicaciones_Publicacionesfecfinpostulacion = value;
				SetDirty("Publicacionesfecfinpostulacion");
			}
		}



		[SoapElement(ElementName="PublicacionesDetalleMateriales")]
		[XmlElement(ElementName="PublicacionesDetalleMateriales")]
		public string gxTpr_Publicacionesdetallemateriales
		{
			get {
				return gxTv_SdtSDTPublicaciones_Publicacionesdetallemateriales; 
			}
			set {
				gxTv_SdtSDTPublicaciones_Publicacionesdetallemateriales = value;
				SetDirty("Publicacionesdetallemateriales");
			}
		}



		[SoapElement(ElementName="PublicacionesFecVisita")]
		[XmlElement(ElementName="PublicacionesFecVisita" , IsNullable=true)]
		public string gxTpr_Publicacionesfecvisita_Nullable
		{
			get {
				if ( gxTv_SdtSDTPublicaciones_Publicacionesfecvisita == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTPublicaciones_Publicacionesfecvisita).value ;
			}
			set {
				gxTv_SdtSDTPublicaciones_Publicacionesfecvisita = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Publicacionesfecvisita
		{
			get {
				return gxTv_SdtSDTPublicaciones_Publicacionesfecvisita; 
			}
			set {
				gxTv_SdtSDTPublicaciones_Publicacionesfecvisita = value;
				SetDirty("Publicacionesfecvisita");
			}
		}



		[SoapElement(ElementName="PublicacionesHoraVisita")]
		[XmlElement(ElementName="PublicacionesHoraVisita")]
		public string gxTpr_Publicacioneshoravisita
		{
			get {
				return gxTv_SdtSDTPublicaciones_Publicacioneshoravisita; 
			}
			set {
				gxTv_SdtSDTPublicaciones_Publicacioneshoravisita = value;
				SetDirty("Publicacioneshoravisita");
			}
		}




		[SoapElement(ElementName="PublicacionesDirVisita")]
		[XmlElement(ElementName="PublicacionesDirVisita")]
		public string gxTpr_Publicacionesdirvisita
		{
			get {
				return gxTv_SdtSDTPublicaciones_Publicacionesdirvisita; 
			}
			set {
				gxTv_SdtSDTPublicaciones_Publicacionesdirvisita = value;
				SetDirty("Publicacionesdirvisita");
			}
		}




		[SoapElement(ElementName="PublicacionesCondiciones")]
		[XmlElement(ElementName="PublicacionesCondiciones")]
		public string gxTpr_Publicacionescondiciones
		{
			get {
				return gxTv_SdtSDTPublicaciones_Publicacionescondiciones; 
			}
			set {
				gxTv_SdtSDTPublicaciones_Publicacionescondiciones = value;
				SetDirty("Publicacionescondiciones");
			}
		}




		[SoapElement(ElementName="PublicacionesTipoDesembolso")]
		[XmlElement(ElementName="PublicacionesTipoDesembolso")]
		public string gxTpr_Publicacionestipodesembolso
		{
			get {
				return gxTv_SdtSDTPublicaciones_Publicacionestipodesembolso; 
			}
			set {
				gxTv_SdtSDTPublicaciones_Publicacionestipodesembolso = value;
				SetDirty("Publicacionestipodesembolso");
			}
		}




		[SoapElement(ElementName="PublicacionesOtroTipoDes")]
		[XmlElement(ElementName="PublicacionesOtroTipoDes")]
		public string gxTpr_Publicacionesotrotipodes
		{
			get {
				return gxTv_SdtSDTPublicaciones_Publicacionesotrotipodes; 
			}
			set {
				gxTv_SdtSDTPublicaciones_Publicacionesotrotipodes = value;
				SetDirty("Publicacionesotrotipodes");
			}
		}




		[SoapElement(ElementName="PublicacionesModalidad")]
		[XmlElement(ElementName="PublicacionesModalidad")]
		public string gxTpr_Publicacionesmodalidad
		{
			get {
				return gxTv_SdtSDTPublicaciones_Publicacionesmodalidad; 
			}
			set {
				gxTv_SdtSDTPublicaciones_Publicacionesmodalidad = value;
				SetDirty("Publicacionesmodalidad");
			}
		}



		[SoapElement(ElementName="PublicacionesPrecio")]
		[XmlElement(ElementName="PublicacionesPrecio")]
		public string gxTpr_Publicacionesprecio_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTPublicaciones_Publicacionesprecio, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTPublicaciones_Publicacionesprecio = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Publicacionesprecio
		{
			get {
				return gxTv_SdtSDTPublicaciones_Publicacionesprecio; 
			}
			set {
				gxTv_SdtSDTPublicaciones_Publicacionesprecio = value;
				SetDirty("Publicacionesprecio");
			}
		}




		[SoapElement(ElementName="MonedaId")]
		[XmlElement(ElementName="MonedaId")]
		public short gxTpr_Monedaid
		{
			get {
				return gxTv_SdtSDTPublicaciones_Monedaid; 
			}
			set {
				gxTv_SdtSDTPublicaciones_Monedaid = value;
				SetDirty("Monedaid");
			}
		}




		[SoapElement(ElementName="MonedaISOSimbolo")]
		[XmlElement(ElementName="MonedaISOSimbolo")]
		public string gxTpr_Monedaisosimbolo
		{
			get {
				return gxTv_SdtSDTPublicaciones_Monedaisosimbolo; 
			}
			set {
				gxTv_SdtSDTPublicaciones_Monedaisosimbolo = value;
				SetDirty("Monedaisosimbolo");
			}
		}



		[SoapElement(ElementName="PublicacionesFecCierre")]
		[XmlElement(ElementName="PublicacionesFecCierre" , IsNullable=true)]
		public string gxTpr_Publicacionesfeccierre_Nullable
		{
			get {
				if ( gxTv_SdtSDTPublicaciones_Publicacionesfeccierre == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTPublicaciones_Publicacionesfeccierre).value ;
			}
			set {
				gxTv_SdtSDTPublicaciones_Publicacionesfeccierre = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Publicacionesfeccierre
		{
			get {
				return gxTv_SdtSDTPublicaciones_Publicacionesfeccierre; 
			}
			set {
				gxTv_SdtSDTPublicaciones_Publicacionesfeccierre = value;
				SetDirty("Publicacionesfeccierre");
			}
		}



		[SoapElement(ElementName="PublicacionesDocReq")]
		[XmlElement(ElementName="PublicacionesDocReq")]
		public string gxTpr_Publicacionesdocreq
		{
			get {
				return gxTv_SdtSDTPublicaciones_Publicacionesdocreq; 
			}
			set {
				gxTv_SdtSDTPublicaciones_Publicacionesdocreq = value;
				SetDirty("Publicacionesdocreq");
			}
		}




		[SoapElement(ElementName="PublicacionesDocDescripcion")]
		[XmlElement(ElementName="PublicacionesDocDescripcion")]
		public string gxTpr_Publicacionesdocdescripcion
		{
			get {
				return gxTv_SdtSDTPublicaciones_Publicacionesdocdescripcion; 
			}
			set {
				gxTv_SdtSDTPublicaciones_Publicacionesdocdescripcion = value;
				SetDirty("Publicacionesdocdescripcion");
			}
		}




		[SoapElement(ElementName="PublicacionesTipoEmpresa")]
		[XmlElement(ElementName="PublicacionesTipoEmpresa")]
		public string gxTpr_Publicacionestipoempresa
		{
			get {
				return gxTv_SdtSDTPublicaciones_Publicacionestipoempresa; 
			}
			set {
				gxTv_SdtSDTPublicaciones_Publicacionestipoempresa = value;
				SetDirty("Publicacionestipoempresa");
			}
		}




		[SoapElement(ElementName="PublicacionesContratoId")]
		[XmlElement(ElementName="PublicacionesContratoId")]
		public string gxTpr_Publicacionescontratoid
		{
			get {
				return gxTv_SdtSDTPublicaciones_Publicacionescontratoid; 
			}
			set {
				gxTv_SdtSDTPublicaciones_Publicacionescontratoid = value;
				SetDirty("Publicacionescontratoid");
			}
		}




		[SoapElement(ElementName="PublicacionesTerminoObra")]
		[XmlElement(ElementName="PublicacionesTerminoObra")]
		public string gxTpr_Publicacionesterminoobra
		{
			get {
				return gxTv_SdtSDTPublicaciones_Publicacionesterminoobra; 
			}
			set {
				gxTv_SdtSDTPublicaciones_Publicacionesterminoobra = value;
				SetDirty("Publicacionesterminoobra");
			}
		}




		[SoapElement(ElementName="PublicacionesEstado")]
		[XmlElement(ElementName="PublicacionesEstado")]
		public string gxTpr_Publicacionesestado
		{
			get {
				return gxTv_SdtSDTPublicaciones_Publicacionesestado; 
			}
			set {
				gxTv_SdtSDTPublicaciones_Publicacionesestado = value;
				SetDirty("Publicacionesestado");
			}
		}




		[SoapElement(ElementName="PublicacionesSerialIma")]
		[XmlElement(ElementName="PublicacionesSerialIma")]
		public short gxTpr_Publicacionesserialima
		{
			get {
				return gxTv_SdtSDTPublicaciones_Publicacionesserialima; 
			}
			set {
				gxTv_SdtSDTPublicaciones_Publicacionesserialima = value;
				SetDirty("Publicacionesserialima");
			}
		}




		[SoapElement(ElementName="PublicacionesSerialRem")]
		[XmlElement(ElementName="PublicacionesSerialRem")]
		public short gxTpr_Publicacionesserialrem
		{
			get {
				return gxTv_SdtSDTPublicaciones_Publicacionesserialrem; 
			}
			set {
				gxTv_SdtSDTPublicaciones_Publicacionesserialrem = value;
				SetDirty("Publicacionesserialrem");
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
			gxTv_SdtSDTPublicaciones_Publicacionestitulo = "";
			gxTv_SdtSDTPublicaciones_Publicacionesdescripcion = "";





			gxTv_SdtSDTPublicaciones_Publicacionesdetallemateriales = "";

			gxTv_SdtSDTPublicaciones_Publicacioneshoravisita = "";
			gxTv_SdtSDTPublicaciones_Publicacionesdirvisita = "";
			gxTv_SdtSDTPublicaciones_Publicacionescondiciones = "";
			gxTv_SdtSDTPublicaciones_Publicacionestipodesembolso = "";
			gxTv_SdtSDTPublicaciones_Publicacionesotrotipodes = "";
			gxTv_SdtSDTPublicaciones_Publicacionesmodalidad = "";


			gxTv_SdtSDTPublicaciones_Monedaisosimbolo = "";

			gxTv_SdtSDTPublicaciones_Publicacionesdocreq = "";
			gxTv_SdtSDTPublicaciones_Publicacionesdocdescripcion = "";
			gxTv_SdtSDTPublicaciones_Publicacionestipoempresa = "";
			gxTv_SdtSDTPublicaciones_Publicacionescontratoid = "";
			gxTv_SdtSDTPublicaciones_Publicacionesterminoobra = "";
			gxTv_SdtSDTPublicaciones_Publicacionesestado = "";


			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected long gxTv_SdtSDTPublicaciones_Publicacionesid;
		 

		protected string gxTv_SdtSDTPublicaciones_Publicacionestitulo;
		 

		protected string gxTv_SdtSDTPublicaciones_Publicacionesdescripcion;
		 

		protected long gxTv_SdtSDTPublicaciones_Departamentoid;
		 

		protected long gxTv_SdtSDTPublicaciones_Departamentomunicipioid;
		 

		protected DateTime gxTv_SdtSDTPublicaciones_Publicacionesfectentinicio;
		 

		protected DateTime gxTv_SdtSDTPublicaciones_Publicacionesfecrealinicio;
		 

		protected DateTime gxTv_SdtSDTPublicaciones_Publicacionesfecfinpostulacion;
		 

		protected string gxTv_SdtSDTPublicaciones_Publicacionesdetallemateriales;
		 

		protected DateTime gxTv_SdtSDTPublicaciones_Publicacionesfecvisita;
		 

		protected string gxTv_SdtSDTPublicaciones_Publicacioneshoravisita;
		 

		protected string gxTv_SdtSDTPublicaciones_Publicacionesdirvisita;
		 

		protected string gxTv_SdtSDTPublicaciones_Publicacionescondiciones;
		 

		protected string gxTv_SdtSDTPublicaciones_Publicacionestipodesembolso;
		 

		protected string gxTv_SdtSDTPublicaciones_Publicacionesotrotipodes;
		 

		protected string gxTv_SdtSDTPublicaciones_Publicacionesmodalidad;
		 

		protected decimal gxTv_SdtSDTPublicaciones_Publicacionesprecio;
		 

		protected short gxTv_SdtSDTPublicaciones_Monedaid;
		 

		protected string gxTv_SdtSDTPublicaciones_Monedaisosimbolo;
		 

		protected DateTime gxTv_SdtSDTPublicaciones_Publicacionesfeccierre;
		 

		protected string gxTv_SdtSDTPublicaciones_Publicacionesdocreq;
		 

		protected string gxTv_SdtSDTPublicaciones_Publicacionesdocdescripcion;
		 

		protected string gxTv_SdtSDTPublicaciones_Publicacionestipoempresa;
		 

		protected string gxTv_SdtSDTPublicaciones_Publicacionescontratoid;
		 

		protected string gxTv_SdtSDTPublicaciones_Publicacionesterminoobra;
		 

		protected string gxTv_SdtSDTPublicaciones_Publicacionesestado;
		 

		protected short gxTv_SdtSDTPublicaciones_Publicacionesserialima;
		 

		protected short gxTv_SdtSDTPublicaciones_Publicacionesserialrem;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTPublicaciones", Namespace="AlmangoX")]
	public class SdtSDTPublicaciones_RESTInterface : GxGenericCollectionItem<SdtSDTPublicaciones>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTPublicaciones_RESTInterface( ) : base()
		{	
		}

		public SdtSDTPublicaciones_RESTInterface( SdtSDTPublicaciones psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="PublicacionesId", Order=0)]
		public  string gxTpr_Publicacionesid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Publicacionesid, 18, 0));

			}
			set { 
				sdt.gxTpr_Publicacionesid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="PublicacionesTitulo", Order=1)]
		public  string gxTpr_Publicacionestitulo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Publicacionestitulo);

			}
			set { 
				 sdt.gxTpr_Publicacionestitulo = value;
			}
		}

		[DataMember(Name="PublicacionesDescripcion", Order=2)]
		public  string gxTpr_Publicacionesdescripcion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Publicacionesdescripcion);

			}
			set { 
				 sdt.gxTpr_Publicacionesdescripcion = value;
			}
		}

		[DataMember(Name="DepartamentoId", Order=3)]
		public  string gxTpr_Departamentoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Departamentoid, 18, 0));

			}
			set { 
				sdt.gxTpr_Departamentoid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="DepartamentoMunicipioId", Order=4)]
		public  string gxTpr_Departamentomunicipioid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Departamentomunicipioid, 18, 0));

			}
			set { 
				sdt.gxTpr_Departamentomunicipioid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="PublicacionesFecTentInicio", Order=5)]
		public  string gxTpr_Publicacionesfectentinicio
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Publicacionesfectentinicio);

			}
			set { 
				sdt.gxTpr_Publicacionesfectentinicio = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="PublicacionesFecRealInicio", Order=6)]
		public  string gxTpr_Publicacionesfecrealinicio
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Publicacionesfecrealinicio);

			}
			set { 
				sdt.gxTpr_Publicacionesfecrealinicio = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="PublicacionesFecFinPostulacion", Order=7)]
		public  string gxTpr_Publicacionesfecfinpostulacion
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Publicacionesfecfinpostulacion);

			}
			set { 
				sdt.gxTpr_Publicacionesfecfinpostulacion = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="PublicacionesDetalleMateriales", Order=8)]
		public  string gxTpr_Publicacionesdetallemateriales
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Publicacionesdetallemateriales);

			}
			set { 
				 sdt.gxTpr_Publicacionesdetallemateriales = value;
			}
		}

		[DataMember(Name="PublicacionesFecVisita", Order=9)]
		public  string gxTpr_Publicacionesfecvisita
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Publicacionesfecvisita);

			}
			set { 
				sdt.gxTpr_Publicacionesfecvisita = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="PublicacionesHoraVisita", Order=10)]
		public  string gxTpr_Publicacioneshoravisita
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Publicacioneshoravisita);

			}
			set { 
				 sdt.gxTpr_Publicacioneshoravisita = value;
			}
		}

		[DataMember(Name="PublicacionesDirVisita", Order=11)]
		public  string gxTpr_Publicacionesdirvisita
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Publicacionesdirvisita);

			}
			set { 
				 sdt.gxTpr_Publicacionesdirvisita = value;
			}
		}

		[DataMember(Name="PublicacionesCondiciones", Order=12)]
		public  string gxTpr_Publicacionescondiciones
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Publicacionescondiciones);

			}
			set { 
				 sdt.gxTpr_Publicacionescondiciones = value;
			}
		}

		[DataMember(Name="PublicacionesTipoDesembolso", Order=13)]
		public  string gxTpr_Publicacionestipodesembolso
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Publicacionestipodesembolso);

			}
			set { 
				 sdt.gxTpr_Publicacionestipodesembolso = value;
			}
		}

		[DataMember(Name="PublicacionesOtroTipoDes", Order=14)]
		public  string gxTpr_Publicacionesotrotipodes
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Publicacionesotrotipodes);

			}
			set { 
				 sdt.gxTpr_Publicacionesotrotipodes = value;
			}
		}

		[DataMember(Name="PublicacionesModalidad", Order=15)]
		public  string gxTpr_Publicacionesmodalidad
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Publicacionesmodalidad);

			}
			set { 
				 sdt.gxTpr_Publicacionesmodalidad = value;
			}
		}

		[DataMember(Name="PublicacionesPrecio", Order=16)]
		public  string gxTpr_Publicacionesprecio
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Publicacionesprecio, 18, 2));

			}
			set { 
				sdt.gxTpr_Publicacionesprecio =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MonedaId", Order=17)]
		public short gxTpr_Monedaid
		{
			get { 
				return sdt.gxTpr_Monedaid;

			}
			set { 
				sdt.gxTpr_Monedaid = value;
			}
		}

		[DataMember(Name="MonedaISOSimbolo", Order=18)]
		public  string gxTpr_Monedaisosimbolo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Monedaisosimbolo);

			}
			set { 
				 sdt.gxTpr_Monedaisosimbolo = value;
			}
		}

		[DataMember(Name="PublicacionesFecCierre", Order=19)]
		public  string gxTpr_Publicacionesfeccierre
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Publicacionesfeccierre);

			}
			set { 
				sdt.gxTpr_Publicacionesfeccierre = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="PublicacionesDocReq", Order=20)]
		public  string gxTpr_Publicacionesdocreq
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Publicacionesdocreq);

			}
			set { 
				 sdt.gxTpr_Publicacionesdocreq = value;
			}
		}

		[DataMember(Name="PublicacionesDocDescripcion", Order=21)]
		public  string gxTpr_Publicacionesdocdescripcion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Publicacionesdocdescripcion);

			}
			set { 
				 sdt.gxTpr_Publicacionesdocdescripcion = value;
			}
		}

		[DataMember(Name="PublicacionesTipoEmpresa", Order=22)]
		public  string gxTpr_Publicacionestipoempresa
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Publicacionestipoempresa);

			}
			set { 
				 sdt.gxTpr_Publicacionestipoempresa = value;
			}
		}

		[DataMember(Name="PublicacionesContratoId", Order=23)]
		public  string gxTpr_Publicacionescontratoid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Publicacionescontratoid);

			}
			set { 
				 sdt.gxTpr_Publicacionescontratoid = value;
			}
		}

		[DataMember(Name="PublicacionesTerminoObra", Order=24)]
		public  string gxTpr_Publicacionesterminoobra
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Publicacionesterminoobra);

			}
			set { 
				 sdt.gxTpr_Publicacionesterminoobra = value;
			}
		}

		[DataMember(Name="PublicacionesEstado", Order=25)]
		public  string gxTpr_Publicacionesestado
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Publicacionesestado);

			}
			set { 
				 sdt.gxTpr_Publicacionesestado = value;
			}
		}

		[DataMember(Name="PublicacionesSerialIma", Order=26)]
		public short gxTpr_Publicacionesserialima
		{
			get { 
				return sdt.gxTpr_Publicacionesserialima;

			}
			set { 
				sdt.gxTpr_Publicacionesserialima = value;
			}
		}

		[DataMember(Name="PublicacionesSerialRem", Order=27)]
		public short gxTpr_Publicacionesserialrem
		{
			get { 
				return sdt.gxTpr_Publicacionesserialrem;

			}
			set { 
				sdt.gxTpr_Publicacionesserialrem = value;
			}
		}


		#endregion
		public SdtSDTPublicaciones sdt
		{
			get { 
				return (SdtSDTPublicaciones)Sdt;
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
				sdt = new SdtSDTPublicaciones() ;
			}
		}
	}
	#endregion
}