/*
				   File: type_SdtSDTPostulaciones
			Description: SDTPostulaciones
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
	[XmlRoot(ElementName="SDTPostulaciones")]
	[XmlType(TypeName="SDTPostulaciones" , Namespace="AlmangoX" )]
	[Serializable]
	public class SdtSDTPostulaciones : GxUserType
	{
		public SdtSDTPostulaciones( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTPostulaciones_Serviciosnombre = "";

			gxTv_SdtSDTPostulaciones_Postulacionesprovnombreaux = "";

			gxTv_SdtSDTPostulaciones_Postulacionesdescripcion = "";

			gxTv_SdtSDTPostulaciones_Postulacionessuministrosdescripcion = "";

			gxTv_SdtSDTPostulaciones_Postulacioneshoracierre = "";

			gxTv_SdtSDTPostulaciones_Postulacionestipofecha = "";

			gxTv_SdtSDTPostulaciones_Postulacionesrgohoraservicio = "";

			gxTv_SdtSDTPostulaciones_Postulacionesapellidonombre = "";

			gxTv_SdtSDTPostulaciones_Postulacionesmail = "";

			gxTv_SdtSDTPostulaciones_Postulacionestelefono = "";

			gxTv_SdtSDTPostulaciones_Postulacionesdireccion = "";

			gxTv_SdtSDTPostulaciones_Postulacionesfechaalta = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDTPostulaciones_Postulacionesestado = "";


		}

		public SdtSDTPostulaciones(IGxContext context)
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
			AddObjectProperty("PostulacionesId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Postulacionesid, 18, 0)), false);


			AddObjectProperty("ServiciosId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Serviciosid, 18, 0)), false);


			AddObjectProperty("ServiciosNombre", gxTpr_Serviciosnombre, false);


			AddObjectProperty("PostulacionesProveedorId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Postulacionesproveedorid, 18, 0)), false);


			AddObjectProperty("PostulacionesProvNombreAux", gxTpr_Postulacionesprovnombreaux, false);


			AddObjectProperty("PostulacionesPrecio", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Postulacionesprecio, 18, 2)), false);

			if (gxTv_SdtSDTPostulaciones_Categorias != null)
			{
				AddObjectProperty("Categorias", gxTv_SdtSDTPostulaciones_Categorias, false);
			}
			if (gxTv_SdtSDTPostulaciones_Multimedia != null)
			{
				AddObjectProperty("Multimedia", gxTv_SdtSDTPostulaciones_Multimedia, false);
			}

			AddObjectProperty("PostulacionesDescripcion", gxTpr_Postulacionesdescripcion, false);


			AddObjectProperty("PostulacionesReqSuministros", gxTpr_Postulacionesreqsuministros, false);


			AddObjectProperty("PostulacionesSuministrosDescripcion", gxTpr_Postulacionessuministrosdescripcion, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Postulacionesfechatrabajo)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Postulacionesfechatrabajo)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Postulacionesfechatrabajo)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("PostulacionesFechaTrabajo", sDateCnv, false);



			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Postulacionesfechacierre)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Postulacionesfechacierre)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Postulacionesfechacierre)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("PostulacionesFechaCierre", sDateCnv, false);



			AddObjectProperty("PostulacionesHoraCierre", gxTpr_Postulacioneshoracierre, false);


			AddObjectProperty("PostulacionesTipoFecha", gxTpr_Postulacionestipofecha, false);


			AddObjectProperty("PostulacionesRgoHoraservicio", gxTpr_Postulacionesrgohoraservicio, false);


			AddObjectProperty("PostulacionesApellidoNombre", gxTpr_Postulacionesapellidonombre, false);


			AddObjectProperty("PostulacionesMail", gxTpr_Postulacionesmail, false);


			AddObjectProperty("PostulacionesTelefono", gxTpr_Postulacionestelefono, false);


			AddObjectProperty("PostulacionesDepartamentoId", gxTpr_Postulacionesdepartamentoid, false);


			AddObjectProperty("PostulacionesDepartamentoMunicipioId", gxTpr_Postulacionesdepartamentomunicipioid, false);


			AddObjectProperty("PostulacionesZonasID", gxTpr_Postulacioneszonasid, false);


			AddObjectProperty("PostulacionesDireccion", gxTpr_Postulacionesdireccion, false);

			if (gxTv_SdtSDTPostulaciones_Profesionales != null)
			{
				AddObjectProperty("Profesionales", gxTv_SdtSDTPostulaciones_Profesionales, false);
			}

			datetime_STZ = gxTpr_Postulacionesfechaalta;
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
			AddObjectProperty("PostulacionesFechaAlta", sDateCnv, false);



			AddObjectProperty("PostulacionesEstado", gxTpr_Postulacionesestado, false);


			AddObjectProperty("PostulacionesSecUserId", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Postulacionessecuserid, 18, 0)), false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PostulacionesId")]
		[XmlElement(ElementName="PostulacionesId")]
		public long gxTpr_Postulacionesid
		{
			get {
				return gxTv_SdtSDTPostulaciones_Postulacionesid; 
			}
			set {
				gxTv_SdtSDTPostulaciones_Postulacionesid = value;
				SetDirty("Postulacionesid");
			}
		}




		[SoapElement(ElementName="ServiciosId")]
		[XmlElement(ElementName="ServiciosId")]
		public long gxTpr_Serviciosid
		{
			get {
				return gxTv_SdtSDTPostulaciones_Serviciosid; 
			}
			set {
				gxTv_SdtSDTPostulaciones_Serviciosid = value;
				SetDirty("Serviciosid");
			}
		}




		[SoapElement(ElementName="ServiciosNombre")]
		[XmlElement(ElementName="ServiciosNombre")]
		public string gxTpr_Serviciosnombre
		{
			get {
				return gxTv_SdtSDTPostulaciones_Serviciosnombre; 
			}
			set {
				gxTv_SdtSDTPostulaciones_Serviciosnombre = value;
				SetDirty("Serviciosnombre");
			}
		}




		[SoapElement(ElementName="PostulacionesProveedorId")]
		[XmlElement(ElementName="PostulacionesProveedorId")]
		public long gxTpr_Postulacionesproveedorid
		{
			get {
				return gxTv_SdtSDTPostulaciones_Postulacionesproveedorid; 
			}
			set {
				gxTv_SdtSDTPostulaciones_Postulacionesproveedorid = value;
				SetDirty("Postulacionesproveedorid");
			}
		}




		[SoapElement(ElementName="PostulacionesProvNombreAux")]
		[XmlElement(ElementName="PostulacionesProvNombreAux")]
		public string gxTpr_Postulacionesprovnombreaux
		{
			get {
				return gxTv_SdtSDTPostulaciones_Postulacionesprovnombreaux; 
			}
			set {
				gxTv_SdtSDTPostulaciones_Postulacionesprovnombreaux = value;
				SetDirty("Postulacionesprovnombreaux");
			}
		}



		[SoapElement(ElementName="PostulacionesPrecio")]
		[XmlElement(ElementName="PostulacionesPrecio")]
		public string gxTpr_Postulacionesprecio_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDTPostulaciones_Postulacionesprecio, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDTPostulaciones_Postulacionesprecio = NumberUtil.Val(value);
			}
		}
		[SoapIgnore]
		[XmlIgnore]
		public decimal gxTpr_Postulacionesprecio
		{
			get {
				return gxTv_SdtSDTPostulaciones_Postulacionesprecio; 
			}
			set {
				gxTv_SdtSDTPostulaciones_Postulacionesprecio = value;
				SetDirty("Postulacionesprecio");
			}
		}




		[SoapElement(ElementName="Categorias" )]
		[XmlArray(ElementName="Categorias"  )]
		[XmlArrayItemAttribute(ElementName="CategoriasItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTPostulaciones_CategoriasItem> gxTpr_Categorias
		{
			get {
				if ( gxTv_SdtSDTPostulaciones_Categorias == null )
				{
					gxTv_SdtSDTPostulaciones_Categorias = new GXBaseCollection<SdtSDTPostulaciones_CategoriasItem>( context, "SDTPostulaciones.CategoriasItem", "");
				}
				SetDirty("Categorias");
				return gxTv_SdtSDTPostulaciones_Categorias;
			}
			set {
				gxTv_SdtSDTPostulaciones_Categorias_N = false;
				gxTv_SdtSDTPostulaciones_Categorias = value;
				SetDirty("Categorias");
			}
		}

		public void gxTv_SdtSDTPostulaciones_Categorias_SetNull()
		{
			gxTv_SdtSDTPostulaciones_Categorias_N = true;
			gxTv_SdtSDTPostulaciones_Categorias = null;
		}

		public bool gxTv_SdtSDTPostulaciones_Categorias_IsNull()
		{
			return gxTv_SdtSDTPostulaciones_Categorias == null;
		}
		public bool ShouldSerializegxTpr_Categorias_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTPostulaciones_Categorias != null && gxTv_SdtSDTPostulaciones_Categorias.Count > 0;

		}



		[SoapElement(ElementName="Multimedia" )]
		[XmlArray(ElementName="Multimedia"  )]
		[XmlArrayItemAttribute(ElementName="MultimediaItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTPostulaciones_MultimediaItem> gxTpr_Multimedia
		{
			get {
				if ( gxTv_SdtSDTPostulaciones_Multimedia == null )
				{
					gxTv_SdtSDTPostulaciones_Multimedia = new GXBaseCollection<SdtSDTPostulaciones_MultimediaItem>( context, "SDTPostulaciones.MultimediaItem", "");
				}
				SetDirty("Multimedia");
				return gxTv_SdtSDTPostulaciones_Multimedia;
			}
			set {
				gxTv_SdtSDTPostulaciones_Multimedia_N = false;
				gxTv_SdtSDTPostulaciones_Multimedia = value;
				SetDirty("Multimedia");
			}
		}

		public void gxTv_SdtSDTPostulaciones_Multimedia_SetNull()
		{
			gxTv_SdtSDTPostulaciones_Multimedia_N = true;
			gxTv_SdtSDTPostulaciones_Multimedia = null;
		}

		public bool gxTv_SdtSDTPostulaciones_Multimedia_IsNull()
		{
			return gxTv_SdtSDTPostulaciones_Multimedia == null;
		}
		public bool ShouldSerializegxTpr_Multimedia_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTPostulaciones_Multimedia != null && gxTv_SdtSDTPostulaciones_Multimedia.Count > 0;

		}



		[SoapElement(ElementName="PostulacionesDescripcion")]
		[XmlElement(ElementName="PostulacionesDescripcion")]
		public string gxTpr_Postulacionesdescripcion
		{
			get {
				return gxTv_SdtSDTPostulaciones_Postulacionesdescripcion; 
			}
			set {
				gxTv_SdtSDTPostulaciones_Postulacionesdescripcion = value;
				SetDirty("Postulacionesdescripcion");
			}
		}




		[SoapElement(ElementName="PostulacionesReqSuministros")]
		[XmlElement(ElementName="PostulacionesReqSuministros")]
		public bool gxTpr_Postulacionesreqsuministros
		{
			get {
				return gxTv_SdtSDTPostulaciones_Postulacionesreqsuministros; 
			}
			set {
				gxTv_SdtSDTPostulaciones_Postulacionesreqsuministros = value;
				SetDirty("Postulacionesreqsuministros");
			}
		}




		[SoapElement(ElementName="PostulacionesSuministrosDescripcion")]
		[XmlElement(ElementName="PostulacionesSuministrosDescripcion")]
		public string gxTpr_Postulacionessuministrosdescripcion
		{
			get {
				return gxTv_SdtSDTPostulaciones_Postulacionessuministrosdescripcion; 
			}
			set {
				gxTv_SdtSDTPostulaciones_Postulacionessuministrosdescripcion = value;
				SetDirty("Postulacionessuministrosdescripcion");
			}
		}



		[SoapElement(ElementName="PostulacionesFechaTrabajo")]
		[XmlElement(ElementName="PostulacionesFechaTrabajo" , IsNullable=true)]
		public string gxTpr_Postulacionesfechatrabajo_Nullable
		{
			get {
				if ( gxTv_SdtSDTPostulaciones_Postulacionesfechatrabajo == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTPostulaciones_Postulacionesfechatrabajo).value ;
			}
			set {
				gxTv_SdtSDTPostulaciones_Postulacionesfechatrabajo = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Postulacionesfechatrabajo
		{
			get {
				return gxTv_SdtSDTPostulaciones_Postulacionesfechatrabajo; 
			}
			set {
				gxTv_SdtSDTPostulaciones_Postulacionesfechatrabajo = value;
				SetDirty("Postulacionesfechatrabajo");
			}
		}


		[SoapElement(ElementName="PostulacionesFechaCierre")]
		[XmlElement(ElementName="PostulacionesFechaCierre" , IsNullable=true)]
		public string gxTpr_Postulacionesfechacierre_Nullable
		{
			get {
				if ( gxTv_SdtSDTPostulaciones_Postulacionesfechacierre == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSDTPostulaciones_Postulacionesfechacierre).value ;
			}
			set {
				gxTv_SdtSDTPostulaciones_Postulacionesfechacierre = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Postulacionesfechacierre
		{
			get {
				return gxTv_SdtSDTPostulaciones_Postulacionesfechacierre; 
			}
			set {
				gxTv_SdtSDTPostulaciones_Postulacionesfechacierre = value;
				SetDirty("Postulacionesfechacierre");
			}
		}



		[SoapElement(ElementName="PostulacionesHoraCierre")]
		[XmlElement(ElementName="PostulacionesHoraCierre")]
		public string gxTpr_Postulacioneshoracierre
		{
			get {
				return gxTv_SdtSDTPostulaciones_Postulacioneshoracierre; 
			}
			set {
				gxTv_SdtSDTPostulaciones_Postulacioneshoracierre = value;
				SetDirty("Postulacioneshoracierre");
			}
		}




		[SoapElement(ElementName="PostulacionesTipoFecha")]
		[XmlElement(ElementName="PostulacionesTipoFecha")]
		public string gxTpr_Postulacionestipofecha
		{
			get {
				return gxTv_SdtSDTPostulaciones_Postulacionestipofecha; 
			}
			set {
				gxTv_SdtSDTPostulaciones_Postulacionestipofecha = value;
				SetDirty("Postulacionestipofecha");
			}
		}




		[SoapElement(ElementName="PostulacionesRgoHoraservicio")]
		[XmlElement(ElementName="PostulacionesRgoHoraservicio")]
		public string gxTpr_Postulacionesrgohoraservicio
		{
			get {
				return gxTv_SdtSDTPostulaciones_Postulacionesrgohoraservicio; 
			}
			set {
				gxTv_SdtSDTPostulaciones_Postulacionesrgohoraservicio = value;
				SetDirty("Postulacionesrgohoraservicio");
			}
		}




		[SoapElement(ElementName="PostulacionesApellidoNombre")]
		[XmlElement(ElementName="PostulacionesApellidoNombre")]
		public string gxTpr_Postulacionesapellidonombre
		{
			get {
				return gxTv_SdtSDTPostulaciones_Postulacionesapellidonombre; 
			}
			set {
				gxTv_SdtSDTPostulaciones_Postulacionesapellidonombre = value;
				SetDirty("Postulacionesapellidonombre");
			}
		}




		[SoapElement(ElementName="PostulacionesMail")]
		[XmlElement(ElementName="PostulacionesMail")]
		public string gxTpr_Postulacionesmail
		{
			get {
				return gxTv_SdtSDTPostulaciones_Postulacionesmail; 
			}
			set {
				gxTv_SdtSDTPostulaciones_Postulacionesmail = value;
				SetDirty("Postulacionesmail");
			}
		}




		[SoapElement(ElementName="PostulacionesTelefono")]
		[XmlElement(ElementName="PostulacionesTelefono")]
		public string gxTpr_Postulacionestelefono
		{
			get {
				return gxTv_SdtSDTPostulaciones_Postulacionestelefono; 
			}
			set {
				gxTv_SdtSDTPostulaciones_Postulacionestelefono = value;
				SetDirty("Postulacionestelefono");
			}
		}




		[SoapElement(ElementName="PostulacionesDepartamentoId")]
		[XmlElement(ElementName="PostulacionesDepartamentoId")]
		public short gxTpr_Postulacionesdepartamentoid
		{
			get {
				return gxTv_SdtSDTPostulaciones_Postulacionesdepartamentoid; 
			}
			set {
				gxTv_SdtSDTPostulaciones_Postulacionesdepartamentoid = value;
				SetDirty("Postulacionesdepartamentoid");
			}
		}




		[SoapElement(ElementName="PostulacionesDepartamentoMunicipioId")]
		[XmlElement(ElementName="PostulacionesDepartamentoMunicipioId")]
		public short gxTpr_Postulacionesdepartamentomunicipioid
		{
			get {
				return gxTv_SdtSDTPostulaciones_Postulacionesdepartamentomunicipioid; 
			}
			set {
				gxTv_SdtSDTPostulaciones_Postulacionesdepartamentomunicipioid = value;
				SetDirty("Postulacionesdepartamentomunicipioid");
			}
		}




		[SoapElement(ElementName="PostulacionesZonasID")]
		[XmlElement(ElementName="PostulacionesZonasID")]
		public short gxTpr_Postulacioneszonasid
		{
			get {
				return gxTv_SdtSDTPostulaciones_Postulacioneszonasid; 
			}
			set {
				gxTv_SdtSDTPostulaciones_Postulacioneszonasid = value;
				SetDirty("Postulacioneszonasid");
			}
		}




		[SoapElement(ElementName="PostulacionesDireccion")]
		[XmlElement(ElementName="PostulacionesDireccion")]
		public string gxTpr_Postulacionesdireccion
		{
			get {
				return gxTv_SdtSDTPostulaciones_Postulacionesdireccion; 
			}
			set {
				gxTv_SdtSDTPostulaciones_Postulacionesdireccion = value;
				SetDirty("Postulacionesdireccion");
			}
		}




		[SoapElement(ElementName="Profesionales" )]
		[XmlArray(ElementName="Profesionales"  )]
		[XmlArrayItemAttribute(ElementName="ProfesionalesItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDTPostulaciones_ProfesionalesItem> gxTpr_Profesionales
		{
			get {
				if ( gxTv_SdtSDTPostulaciones_Profesionales == null )
				{
					gxTv_SdtSDTPostulaciones_Profesionales = new GXBaseCollection<SdtSDTPostulaciones_ProfesionalesItem>( context, "SDTPostulaciones.ProfesionalesItem", "");
				}
				SetDirty("Profesionales");
				return gxTv_SdtSDTPostulaciones_Profesionales;
			}
			set {
				gxTv_SdtSDTPostulaciones_Profesionales_N = false;
				gxTv_SdtSDTPostulaciones_Profesionales = value;
				SetDirty("Profesionales");
			}
		}

		public void gxTv_SdtSDTPostulaciones_Profesionales_SetNull()
		{
			gxTv_SdtSDTPostulaciones_Profesionales_N = true;
			gxTv_SdtSDTPostulaciones_Profesionales = null;
		}

		public bool gxTv_SdtSDTPostulaciones_Profesionales_IsNull()
		{
			return gxTv_SdtSDTPostulaciones_Profesionales == null;
		}
		public bool ShouldSerializegxTpr_Profesionales_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDTPostulaciones_Profesionales != null && gxTv_SdtSDTPostulaciones_Profesionales.Count > 0;

		}


		[SoapElement(ElementName="PostulacionesFechaAlta")]
		[XmlElement(ElementName="PostulacionesFechaAlta" , IsNullable=true)]
		public string gxTpr_Postulacionesfechaalta_Nullable
		{
			get {
				if ( gxTv_SdtSDTPostulaciones_Postulacionesfechaalta == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDTPostulaciones_Postulacionesfechaalta).value ;
			}
			set {
				gxTv_SdtSDTPostulaciones_Postulacionesfechaalta = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Postulacionesfechaalta
		{
			get {
				return gxTv_SdtSDTPostulaciones_Postulacionesfechaalta; 
			}
			set {
				gxTv_SdtSDTPostulaciones_Postulacionesfechaalta = value;
				SetDirty("Postulacionesfechaalta");
			}
		}



		[SoapElement(ElementName="PostulacionesEstado")]
		[XmlElement(ElementName="PostulacionesEstado")]
		public string gxTpr_Postulacionesestado
		{
			get {
				return gxTv_SdtSDTPostulaciones_Postulacionesestado; 
			}
			set {
				gxTv_SdtSDTPostulaciones_Postulacionesestado = value;
				SetDirty("Postulacionesestado");
			}
		}




		[SoapElement(ElementName="PostulacionesSecUserId")]
		[XmlElement(ElementName="PostulacionesSecUserId")]
		public long gxTpr_Postulacionessecuserid
		{
			get {
				return gxTv_SdtSDTPostulaciones_Postulacionessecuserid; 
			}
			set {
				gxTv_SdtSDTPostulaciones_Postulacionessecuserid = value;
				SetDirty("Postulacionessecuserid");
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
			gxTv_SdtSDTPostulaciones_Serviciosnombre = "";

			gxTv_SdtSDTPostulaciones_Postulacionesprovnombreaux = "";


			gxTv_SdtSDTPostulaciones_Categorias_N = true;


			gxTv_SdtSDTPostulaciones_Multimedia_N = true;

			gxTv_SdtSDTPostulaciones_Postulacionesdescripcion = "";

			gxTv_SdtSDTPostulaciones_Postulacionessuministrosdescripcion = "";


			gxTv_SdtSDTPostulaciones_Postulacioneshoracierre = "";
			gxTv_SdtSDTPostulaciones_Postulacionestipofecha = "";
			gxTv_SdtSDTPostulaciones_Postulacionesrgohoraservicio = "";
			gxTv_SdtSDTPostulaciones_Postulacionesapellidonombre = "";
			gxTv_SdtSDTPostulaciones_Postulacionesmail = "";
			gxTv_SdtSDTPostulaciones_Postulacionestelefono = "";



			gxTv_SdtSDTPostulaciones_Postulacionesdireccion = "";

			gxTv_SdtSDTPostulaciones_Profesionales_N = true;

			gxTv_SdtSDTPostulaciones_Postulacionesfechaalta = (DateTime)(DateTime.MinValue);
			gxTv_SdtSDTPostulaciones_Postulacionesestado = "";

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

		protected long gxTv_SdtSDTPostulaciones_Postulacionesid;
		 

		protected long gxTv_SdtSDTPostulaciones_Serviciosid;
		 

		protected string gxTv_SdtSDTPostulaciones_Serviciosnombre;
		 

		protected long gxTv_SdtSDTPostulaciones_Postulacionesproveedorid;
		 

		protected string gxTv_SdtSDTPostulaciones_Postulacionesprovnombreaux;
		 

		protected decimal gxTv_SdtSDTPostulaciones_Postulacionesprecio;
		 
		protected bool gxTv_SdtSDTPostulaciones_Categorias_N;
		protected GXBaseCollection<SdtSDTPostulaciones_CategoriasItem> gxTv_SdtSDTPostulaciones_Categorias = null; 

		protected bool gxTv_SdtSDTPostulaciones_Multimedia_N;
		protected GXBaseCollection<SdtSDTPostulaciones_MultimediaItem> gxTv_SdtSDTPostulaciones_Multimedia = null; 


		protected string gxTv_SdtSDTPostulaciones_Postulacionesdescripcion;
		 

		protected bool gxTv_SdtSDTPostulaciones_Postulacionesreqsuministros;
		 

		protected string gxTv_SdtSDTPostulaciones_Postulacionessuministrosdescripcion;
		 

		protected DateTime gxTv_SdtSDTPostulaciones_Postulacionesfechatrabajo;
		 

		protected DateTime gxTv_SdtSDTPostulaciones_Postulacionesfechacierre;
		 

		protected string gxTv_SdtSDTPostulaciones_Postulacioneshoracierre;
		 

		protected string gxTv_SdtSDTPostulaciones_Postulacionestipofecha;
		 

		protected string gxTv_SdtSDTPostulaciones_Postulacionesrgohoraservicio;
		 

		protected string gxTv_SdtSDTPostulaciones_Postulacionesapellidonombre;
		 

		protected string gxTv_SdtSDTPostulaciones_Postulacionesmail;
		 

		protected string gxTv_SdtSDTPostulaciones_Postulacionestelefono;
		 

		protected short gxTv_SdtSDTPostulaciones_Postulacionesdepartamentoid;
		 

		protected short gxTv_SdtSDTPostulaciones_Postulacionesdepartamentomunicipioid;
		 

		protected short gxTv_SdtSDTPostulaciones_Postulacioneszonasid;
		 

		protected string gxTv_SdtSDTPostulaciones_Postulacionesdireccion;
		 
		protected bool gxTv_SdtSDTPostulaciones_Profesionales_N;
		protected GXBaseCollection<SdtSDTPostulaciones_ProfesionalesItem> gxTv_SdtSDTPostulaciones_Profesionales = null; 


		protected DateTime gxTv_SdtSDTPostulaciones_Postulacionesfechaalta;
		 

		protected string gxTv_SdtSDTPostulaciones_Postulacionesestado;
		 

		protected long gxTv_SdtSDTPostulaciones_Postulacionessecuserid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTPostulaciones", Namespace="AlmangoX")]
	public class SdtSDTPostulaciones_RESTInterface : GxGenericCollectionItem<SdtSDTPostulaciones>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTPostulaciones_RESTInterface( ) : base()
		{	
		}

		public SdtSDTPostulaciones_RESTInterface( SdtSDTPostulaciones psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="PostulacionesId", Order=0)]
		public  string gxTpr_Postulacionesid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Postulacionesid, 18, 0));

			}
			set { 
				sdt.gxTpr_Postulacionesid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ServiciosId", Order=1)]
		public  string gxTpr_Serviciosid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Serviciosid, 18, 0));

			}
			set { 
				sdt.gxTpr_Serviciosid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ServiciosNombre", Order=2)]
		public  string gxTpr_Serviciosnombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Serviciosnombre);

			}
			set { 
				 sdt.gxTpr_Serviciosnombre = value;
			}
		}

		[DataMember(Name="PostulacionesProveedorId", Order=3)]
		public  string gxTpr_Postulacionesproveedorid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Postulacionesproveedorid, 18, 0));

			}
			set { 
				sdt.gxTpr_Postulacionesproveedorid = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="PostulacionesProvNombreAux", Order=4)]
		public  string gxTpr_Postulacionesprovnombreaux
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Postulacionesprovnombreaux);

			}
			set { 
				 sdt.gxTpr_Postulacionesprovnombreaux = value;
			}
		}

		[DataMember(Name="PostulacionesPrecio", Order=5)]
		public  string gxTpr_Postulacionesprecio
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Postulacionesprecio, 18, 2));

			}
			set { 
				sdt.gxTpr_Postulacionesprecio =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Categorias", Order=6, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTPostulaciones_CategoriasItem_RESTInterface> gxTpr_Categorias
		{
			get {
				if (sdt.ShouldSerializegxTpr_Categorias_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTPostulaciones_CategoriasItem_RESTInterface>(sdt.gxTpr_Categorias);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Categorias);
			}
		}

		[DataMember(Name="Multimedia", Order=7, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTPostulaciones_MultimediaItem_RESTInterface> gxTpr_Multimedia
		{
			get {
				if (sdt.ShouldSerializegxTpr_Multimedia_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTPostulaciones_MultimediaItem_RESTInterface>(sdt.gxTpr_Multimedia);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Multimedia);
			}
		}

		[DataMember(Name="PostulacionesDescripcion", Order=8)]
		public  string gxTpr_Postulacionesdescripcion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Postulacionesdescripcion);

			}
			set { 
				 sdt.gxTpr_Postulacionesdescripcion = value;
			}
		}

		[DataMember(Name="PostulacionesReqSuministros", Order=9)]
		public bool gxTpr_Postulacionesreqsuministros
		{
			get { 
				return sdt.gxTpr_Postulacionesreqsuministros;

			}
			set { 
				sdt.gxTpr_Postulacionesreqsuministros = value;
			}
		}

		[DataMember(Name="PostulacionesSuministrosDescripcion", Order=10)]
		public  string gxTpr_Postulacionessuministrosdescripcion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Postulacionessuministrosdescripcion);

			}
			set { 
				 sdt.gxTpr_Postulacionessuministrosdescripcion = value;
			}
		}

		[DataMember(Name="PostulacionesFechaTrabajo", Order=11)]
		public  string gxTpr_Postulacionesfechatrabajo
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Postulacionesfechatrabajo);

			}
			set { 
				sdt.gxTpr_Postulacionesfechatrabajo = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="PostulacionesFechaCierre", Order=12)]
		public  string gxTpr_Postulacionesfechacierre
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Postulacionesfechacierre);

			}
			set { 
				sdt.gxTpr_Postulacionesfechacierre = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="PostulacionesHoraCierre", Order=13)]
		public  string gxTpr_Postulacioneshoracierre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Postulacioneshoracierre);

			}
			set { 
				 sdt.gxTpr_Postulacioneshoracierre = value;
			}
		}

		[DataMember(Name="PostulacionesTipoFecha", Order=14)]
		public  string gxTpr_Postulacionestipofecha
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Postulacionestipofecha);

			}
			set { 
				 sdt.gxTpr_Postulacionestipofecha = value;
			}
		}

		[DataMember(Name="PostulacionesRgoHoraservicio", Order=15)]
		public  string gxTpr_Postulacionesrgohoraservicio
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Postulacionesrgohoraservicio);

			}
			set { 
				 sdt.gxTpr_Postulacionesrgohoraservicio = value;
			}
		}

		[DataMember(Name="PostulacionesApellidoNombre", Order=16)]
		public  string gxTpr_Postulacionesapellidonombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Postulacionesapellidonombre);

			}
			set { 
				 sdt.gxTpr_Postulacionesapellidonombre = value;
			}
		}

		[DataMember(Name="PostulacionesMail", Order=17)]
		public  string gxTpr_Postulacionesmail
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Postulacionesmail);

			}
			set { 
				 sdt.gxTpr_Postulacionesmail = value;
			}
		}

		[DataMember(Name="PostulacionesTelefono", Order=18)]
		public  string gxTpr_Postulacionestelefono
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Postulacionestelefono);

			}
			set { 
				 sdt.gxTpr_Postulacionestelefono = value;
			}
		}

		[DataMember(Name="PostulacionesDepartamentoId", Order=19)]
		public short gxTpr_Postulacionesdepartamentoid
		{
			get { 
				return sdt.gxTpr_Postulacionesdepartamentoid;

			}
			set { 
				sdt.gxTpr_Postulacionesdepartamentoid = value;
			}
		}

		[DataMember(Name="PostulacionesDepartamentoMunicipioId", Order=20)]
		public short gxTpr_Postulacionesdepartamentomunicipioid
		{
			get { 
				return sdt.gxTpr_Postulacionesdepartamentomunicipioid;

			}
			set { 
				sdt.gxTpr_Postulacionesdepartamentomunicipioid = value;
			}
		}

		[DataMember(Name="PostulacionesZonasID", Order=21)]
		public short gxTpr_Postulacioneszonasid
		{
			get { 
				return sdt.gxTpr_Postulacioneszonasid;

			}
			set { 
				sdt.gxTpr_Postulacioneszonasid = value;
			}
		}

		[DataMember(Name="PostulacionesDireccion", Order=22)]
		public  string gxTpr_Postulacionesdireccion
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Postulacionesdireccion);

			}
			set { 
				 sdt.gxTpr_Postulacionesdireccion = value;
			}
		}

		[DataMember(Name="Profesionales", Order=23, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDTPostulaciones_ProfesionalesItem_RESTInterface> gxTpr_Profesionales
		{
			get {
				if (sdt.ShouldSerializegxTpr_Profesionales_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDTPostulaciones_ProfesionalesItem_RESTInterface>(sdt.gxTpr_Profesionales);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Profesionales);
			}
		}

		[DataMember(Name="PostulacionesFechaAlta", Order=24)]
		public  string gxTpr_Postulacionesfechaalta
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Postulacionesfechaalta,context);

			}
			set { 
				sdt.gxTpr_Postulacionesfechaalta = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="PostulacionesEstado", Order=25)]
		public  string gxTpr_Postulacionesestado
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Postulacionesestado);

			}
			set { 
				 sdt.gxTpr_Postulacionesestado = value;
			}
		}

		[DataMember(Name="PostulacionesSecUserId", Order=26)]
		public  string gxTpr_Postulacionessecuserid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Postulacionessecuserid, 18, 0));

			}
			set { 
				sdt.gxTpr_Postulacionessecuserid = (long) NumberUtil.Val( value, ".");
			}
		}


		#endregion
		public SdtSDTPostulaciones sdt
		{
			get { 
				return (SdtSDTPostulaciones)Sdt;
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
				sdt = new SdtSDTPostulaciones() ;
			}
		}
	}
	#endregion
}