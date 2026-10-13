using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Web.Services.Protocols;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlSerializerFormat]
   [XmlRoot(ElementName = "Postulaciones" )]
   [XmlType(TypeName =  "Postulaciones" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtPostulaciones : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtPostulaciones( )
      {
      }

      public SdtPostulaciones( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetCallingAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( long AV422PostulacionesId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV422PostulacionesId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PostulacionesId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Postulaciones");
         metadata.Set("BT", "Postulaciones");
         metadata.Set("PK", "[ \"PostulacionesId\" ]");
         metadata.Set("PKAssigned", "[ \"PostulacionesId\" ]");
         metadata.Set("Levels", "[ \"Categorias\",\"Multimedia\",\"Profesionales\" ]");
         metadata.Set("Serial", "[ [ \"Same\",\"Postulaciones\",\"PostulacionesMultimediaSerial\",\"MultimediaId\",\"PostulacionesId\",\"PostulacionesId\" ] ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ProveedorID\" ],\"FKMap\":[ \"PostulacionesProveedorId-ProveedorID\" ] },{ \"FK\":[ \"ServiciosId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Postulacionesid_Z");
         state.Add("gxTpr_Serviciosid_Z");
         state.Add("gxTpr_Serviciosnombre_Z");
         state.Add("gxTpr_Postulacionesproveedorid_Z");
         state.Add("gxTpr_Postulacionesprovnombreaux_Z");
         state.Add("gxTpr_Postulacionesproveedornombre_Z");
         state.Add("gxTpr_Postulacionesprecio_Z");
         state.Add("gxTpr_Postulacionesmultimediaserial_Z");
         state.Add("gxTpr_Postulacionessolicitudesid_Z");
         state.Add("gxTpr_Postulacionesdescripcion_Z");
         state.Add("gxTpr_Postulacionesreqsuministros_Z");
         state.Add("gxTpr_Postulacionessuministrosdescripcion_Z");
         state.Add("gxTpr_Postulacionesfechatrabajo_Z_Nullable");
         state.Add("gxTpr_Postulacionesfechacierre_Z_Nullable");
         state.Add("gxTpr_Postulacioneshoracierre_Z");
         state.Add("gxTpr_Postulacionestipofecha_Z");
         state.Add("gxTpr_Postulacionesrgohoraservicio_Z");
         state.Add("gxTpr_Postulacionesapellidonombre_Z");
         state.Add("gxTpr_Postulacionesmail_Z");
         state.Add("gxTpr_Postulacionestelefono_Z");
         state.Add("gxTpr_Postulacionesdepartamentoid_Z");
         state.Add("gxTpr_Postulacionesdepartamentomunicipioid_Z");
         state.Add("gxTpr_Postulacioneszonasid_Z");
         state.Add("gxTpr_Postulacionesdireccion_Z");
         state.Add("gxTpr_Postulacionesfechaalta_Z_Nullable");
         state.Add("gxTpr_Postulacionesestado_Z");
         state.Add("gxTpr_Postulacionessecuserid_Z");
         state.Add("gxTpr_Postulacionesid_N");
         state.Add("gxTpr_Serviciosid_N");
         state.Add("gxTpr_Postulacionessolicitudesid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtPostulaciones sdt;
         sdt = (SdtPostulaciones)(source);
         gxTv_SdtPostulaciones_Postulacionesid = sdt.gxTv_SdtPostulaciones_Postulacionesid ;
         gxTv_SdtPostulaciones_Serviciosid = sdt.gxTv_SdtPostulaciones_Serviciosid ;
         gxTv_SdtPostulaciones_Serviciosnombre = sdt.gxTv_SdtPostulaciones_Serviciosnombre ;
         gxTv_SdtPostulaciones_Postulacionesproveedorid = sdt.gxTv_SdtPostulaciones_Postulacionesproveedorid ;
         gxTv_SdtPostulaciones_Postulacionesprovnombreaux = sdt.gxTv_SdtPostulaciones_Postulacionesprovnombreaux ;
         gxTv_SdtPostulaciones_Postulacionesproveedornombre = sdt.gxTv_SdtPostulaciones_Postulacionesproveedornombre ;
         gxTv_SdtPostulaciones_Postulacionesprecio = sdt.gxTv_SdtPostulaciones_Postulacionesprecio ;
         gxTv_SdtPostulaciones_Postulacionesmultimediaserial = sdt.gxTv_SdtPostulaciones_Postulacionesmultimediaserial ;
         gxTv_SdtPostulaciones_Postulacionessolicitudesid = sdt.gxTv_SdtPostulaciones_Postulacionessolicitudesid ;
         gxTv_SdtPostulaciones_Categorias = sdt.gxTv_SdtPostulaciones_Categorias ;
         gxTv_SdtPostulaciones_Multimedia = sdt.gxTv_SdtPostulaciones_Multimedia ;
         gxTv_SdtPostulaciones_Postulacionesdescripcion = sdt.gxTv_SdtPostulaciones_Postulacionesdescripcion ;
         gxTv_SdtPostulaciones_Postulacionesreqsuministros = sdt.gxTv_SdtPostulaciones_Postulacionesreqsuministros ;
         gxTv_SdtPostulaciones_Postulacionessuministrosdescripcion = sdt.gxTv_SdtPostulaciones_Postulacionessuministrosdescripcion ;
         gxTv_SdtPostulaciones_Postulacionesfechatrabajo = sdt.gxTv_SdtPostulaciones_Postulacionesfechatrabajo ;
         gxTv_SdtPostulaciones_Postulacionesfechacierre = sdt.gxTv_SdtPostulaciones_Postulacionesfechacierre ;
         gxTv_SdtPostulaciones_Postulacioneshoracierre = sdt.gxTv_SdtPostulaciones_Postulacioneshoracierre ;
         gxTv_SdtPostulaciones_Postulacionestipofecha = sdt.gxTv_SdtPostulaciones_Postulacionestipofecha ;
         gxTv_SdtPostulaciones_Postulacionesrgohoraservicio = sdt.gxTv_SdtPostulaciones_Postulacionesrgohoraservicio ;
         gxTv_SdtPostulaciones_Postulacionesapellidonombre = sdt.gxTv_SdtPostulaciones_Postulacionesapellidonombre ;
         gxTv_SdtPostulaciones_Postulacionesmail = sdt.gxTv_SdtPostulaciones_Postulacionesmail ;
         gxTv_SdtPostulaciones_Postulacionestelefono = sdt.gxTv_SdtPostulaciones_Postulacionestelefono ;
         gxTv_SdtPostulaciones_Postulacionesdepartamentoid = sdt.gxTv_SdtPostulaciones_Postulacionesdepartamentoid ;
         gxTv_SdtPostulaciones_Postulacionesdepartamentomunicipioid = sdt.gxTv_SdtPostulaciones_Postulacionesdepartamentomunicipioid ;
         gxTv_SdtPostulaciones_Postulacioneszonasid = sdt.gxTv_SdtPostulaciones_Postulacioneszonasid ;
         gxTv_SdtPostulaciones_Postulacionesdireccion = sdt.gxTv_SdtPostulaciones_Postulacionesdireccion ;
         gxTv_SdtPostulaciones_Profesionales = sdt.gxTv_SdtPostulaciones_Profesionales ;
         gxTv_SdtPostulaciones_Postulacionesfechaalta = sdt.gxTv_SdtPostulaciones_Postulacionesfechaalta ;
         gxTv_SdtPostulaciones_Postulacionesestado = sdt.gxTv_SdtPostulaciones_Postulacionesestado ;
         gxTv_SdtPostulaciones_Postulacionessecuserid = sdt.gxTv_SdtPostulaciones_Postulacionessecuserid ;
         gxTv_SdtPostulaciones_Mode = sdt.gxTv_SdtPostulaciones_Mode ;
         gxTv_SdtPostulaciones_Initialized = sdt.gxTv_SdtPostulaciones_Initialized ;
         gxTv_SdtPostulaciones_Postulacionesid_Z = sdt.gxTv_SdtPostulaciones_Postulacionesid_Z ;
         gxTv_SdtPostulaciones_Serviciosid_Z = sdt.gxTv_SdtPostulaciones_Serviciosid_Z ;
         gxTv_SdtPostulaciones_Serviciosnombre_Z = sdt.gxTv_SdtPostulaciones_Serviciosnombre_Z ;
         gxTv_SdtPostulaciones_Postulacionesproveedorid_Z = sdt.gxTv_SdtPostulaciones_Postulacionesproveedorid_Z ;
         gxTv_SdtPostulaciones_Postulacionesprovnombreaux_Z = sdt.gxTv_SdtPostulaciones_Postulacionesprovnombreaux_Z ;
         gxTv_SdtPostulaciones_Postulacionesproveedornombre_Z = sdt.gxTv_SdtPostulaciones_Postulacionesproveedornombre_Z ;
         gxTv_SdtPostulaciones_Postulacionesprecio_Z = sdt.gxTv_SdtPostulaciones_Postulacionesprecio_Z ;
         gxTv_SdtPostulaciones_Postulacionesmultimediaserial_Z = sdt.gxTv_SdtPostulaciones_Postulacionesmultimediaserial_Z ;
         gxTv_SdtPostulaciones_Postulacionessolicitudesid_Z = sdt.gxTv_SdtPostulaciones_Postulacionessolicitudesid_Z ;
         gxTv_SdtPostulaciones_Postulacionesdescripcion_Z = sdt.gxTv_SdtPostulaciones_Postulacionesdescripcion_Z ;
         gxTv_SdtPostulaciones_Postulacionesreqsuministros_Z = sdt.gxTv_SdtPostulaciones_Postulacionesreqsuministros_Z ;
         gxTv_SdtPostulaciones_Postulacionessuministrosdescripcion_Z = sdt.gxTv_SdtPostulaciones_Postulacionessuministrosdescripcion_Z ;
         gxTv_SdtPostulaciones_Postulacionesfechatrabajo_Z = sdt.gxTv_SdtPostulaciones_Postulacionesfechatrabajo_Z ;
         gxTv_SdtPostulaciones_Postulacionesfechacierre_Z = sdt.gxTv_SdtPostulaciones_Postulacionesfechacierre_Z ;
         gxTv_SdtPostulaciones_Postulacioneshoracierre_Z = sdt.gxTv_SdtPostulaciones_Postulacioneshoracierre_Z ;
         gxTv_SdtPostulaciones_Postulacionestipofecha_Z = sdt.gxTv_SdtPostulaciones_Postulacionestipofecha_Z ;
         gxTv_SdtPostulaciones_Postulacionesrgohoraservicio_Z = sdt.gxTv_SdtPostulaciones_Postulacionesrgohoraservicio_Z ;
         gxTv_SdtPostulaciones_Postulacionesapellidonombre_Z = sdt.gxTv_SdtPostulaciones_Postulacionesapellidonombre_Z ;
         gxTv_SdtPostulaciones_Postulacionesmail_Z = sdt.gxTv_SdtPostulaciones_Postulacionesmail_Z ;
         gxTv_SdtPostulaciones_Postulacionestelefono_Z = sdt.gxTv_SdtPostulaciones_Postulacionestelefono_Z ;
         gxTv_SdtPostulaciones_Postulacionesdepartamentoid_Z = sdt.gxTv_SdtPostulaciones_Postulacionesdepartamentoid_Z ;
         gxTv_SdtPostulaciones_Postulacionesdepartamentomunicipioid_Z = sdt.gxTv_SdtPostulaciones_Postulacionesdepartamentomunicipioid_Z ;
         gxTv_SdtPostulaciones_Postulacioneszonasid_Z = sdt.gxTv_SdtPostulaciones_Postulacioneszonasid_Z ;
         gxTv_SdtPostulaciones_Postulacionesdireccion_Z = sdt.gxTv_SdtPostulaciones_Postulacionesdireccion_Z ;
         gxTv_SdtPostulaciones_Postulacionesfechaalta_Z = sdt.gxTv_SdtPostulaciones_Postulacionesfechaalta_Z ;
         gxTv_SdtPostulaciones_Postulacionesestado_Z = sdt.gxTv_SdtPostulaciones_Postulacionesestado_Z ;
         gxTv_SdtPostulaciones_Postulacionessecuserid_Z = sdt.gxTv_SdtPostulaciones_Postulacionessecuserid_Z ;
         gxTv_SdtPostulaciones_Postulacionesid_N = sdt.gxTv_SdtPostulaciones_Postulacionesid_N ;
         gxTv_SdtPostulaciones_Serviciosid_N = sdt.gxTv_SdtPostulaciones_Serviciosid_N ;
         gxTv_SdtPostulaciones_Postulacionessolicitudesid_N = sdt.gxTv_SdtPostulaciones_Postulacionessolicitudesid_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("PostulacionesId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtPostulaciones_Postulacionesid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("PostulacionesId_N", gxTv_SdtPostulaciones_Postulacionesid_N, false, includeNonInitialized);
         AddObjectProperty("ServiciosId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtPostulaciones_Serviciosid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("ServiciosId_N", gxTv_SdtPostulaciones_Serviciosid_N, false, includeNonInitialized);
         AddObjectProperty("ServiciosNombre", gxTv_SdtPostulaciones_Serviciosnombre, false, includeNonInitialized);
         AddObjectProperty("PostulacionesProveedorId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtPostulaciones_Postulacionesproveedorid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("PostulacionesProvNombreAux", gxTv_SdtPostulaciones_Postulacionesprovnombreaux, false, includeNonInitialized);
         AddObjectProperty("PostulacionesProveedorNombre", gxTv_SdtPostulaciones_Postulacionesproveedornombre, false, includeNonInitialized);
         AddObjectProperty("PostulacionesPrecio", StringUtil.LTrim( StringUtil.Str( gxTv_SdtPostulaciones_Postulacionesprecio, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("PostulacionesMultimediaSerial", gxTv_SdtPostulaciones_Postulacionesmultimediaserial, false, includeNonInitialized);
         AddObjectProperty("PostulacionesSolicitudesId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtPostulaciones_Postulacionessolicitudesid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("PostulacionesSolicitudesId_N", gxTv_SdtPostulaciones_Postulacionessolicitudesid_N, false, includeNonInitialized);
         if ( gxTv_SdtPostulaciones_Categorias != null )
         {
            AddObjectProperty("Categorias", gxTv_SdtPostulaciones_Categorias, includeState, includeNonInitialized);
         }
         if ( gxTv_SdtPostulaciones_Multimedia != null )
         {
            AddObjectProperty("Multimedia", gxTv_SdtPostulaciones_Multimedia, includeState, includeNonInitialized);
         }
         AddObjectProperty("PostulacionesDescripcion", gxTv_SdtPostulaciones_Postulacionesdescripcion, false, includeNonInitialized);
         AddObjectProperty("PostulacionesReqSuministros", gxTv_SdtPostulaciones_Postulacionesreqsuministros, false, includeNonInitialized);
         AddObjectProperty("PostulacionesSuministrosDescripcion", gxTv_SdtPostulaciones_Postulacionessuministrosdescripcion, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPostulaciones_Postulacionesfechatrabajo)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPostulaciones_Postulacionesfechatrabajo)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPostulaciones_Postulacionesfechatrabajo)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("PostulacionesFechaTrabajo", sDateCnv, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPostulaciones_Postulacionesfechacierre)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPostulaciones_Postulacionesfechacierre)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPostulaciones_Postulacionesfechacierre)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("PostulacionesFechaCierre", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PostulacionesHoraCierre", gxTv_SdtPostulaciones_Postulacioneshoracierre, false, includeNonInitialized);
         AddObjectProperty("PostulacionesTipoFecha", gxTv_SdtPostulaciones_Postulacionestipofecha, false, includeNonInitialized);
         AddObjectProperty("PostulacionesRgoHoraservicio", gxTv_SdtPostulaciones_Postulacionesrgohoraservicio, false, includeNonInitialized);
         AddObjectProperty("PostulacionesApellidoNombre", gxTv_SdtPostulaciones_Postulacionesapellidonombre, false, includeNonInitialized);
         AddObjectProperty("PostulacionesMail", gxTv_SdtPostulaciones_Postulacionesmail, false, includeNonInitialized);
         AddObjectProperty("PostulacionesTelefono", gxTv_SdtPostulaciones_Postulacionestelefono, false, includeNonInitialized);
         AddObjectProperty("PostulacionesDepartamentoId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtPostulaciones_Postulacionesdepartamentoid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("PostulacionesDepartamentoMunicipioId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtPostulaciones_Postulacionesdepartamentomunicipioid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("PostulacionesZonasID", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtPostulaciones_Postulacioneszonasid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("PostulacionesDireccion", gxTv_SdtPostulaciones_Postulacionesdireccion, false, includeNonInitialized);
         if ( gxTv_SdtPostulaciones_Profesionales != null )
         {
            AddObjectProperty("Profesionales", gxTv_SdtPostulaciones_Profesionales, includeState, includeNonInitialized);
         }
         datetime_STZ = gxTv_SdtPostulaciones_Postulacionesfechaalta;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("PostulacionesFechaAlta", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PostulacionesEstado", gxTv_SdtPostulaciones_Postulacionesestado, false, includeNonInitialized);
         AddObjectProperty("PostulacionesSecUserId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtPostulaciones_Postulacionessecuserid), 18, 0)), false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtPostulaciones_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtPostulaciones_Initialized, false, includeNonInitialized);
            AddObjectProperty("PostulacionesId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtPostulaciones_Postulacionesid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("ServiciosId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtPostulaciones_Serviciosid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("ServiciosNombre_Z", gxTv_SdtPostulaciones_Serviciosnombre_Z, false, includeNonInitialized);
            AddObjectProperty("PostulacionesProveedorId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtPostulaciones_Postulacionesproveedorid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("PostulacionesProvNombreAux_Z", gxTv_SdtPostulaciones_Postulacionesprovnombreaux_Z, false, includeNonInitialized);
            AddObjectProperty("PostulacionesProveedorNombre_Z", gxTv_SdtPostulaciones_Postulacionesproveedornombre_Z, false, includeNonInitialized);
            AddObjectProperty("PostulacionesPrecio_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtPostulaciones_Postulacionesprecio_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("PostulacionesMultimediaSerial_Z", gxTv_SdtPostulaciones_Postulacionesmultimediaserial_Z, false, includeNonInitialized);
            AddObjectProperty("PostulacionesSolicitudesId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtPostulaciones_Postulacionessolicitudesid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("PostulacionesDescripcion_Z", gxTv_SdtPostulaciones_Postulacionesdescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("PostulacionesReqSuministros_Z", gxTv_SdtPostulaciones_Postulacionesreqsuministros_Z, false, includeNonInitialized);
            AddObjectProperty("PostulacionesSuministrosDescripcion_Z", gxTv_SdtPostulaciones_Postulacionessuministrosdescripcion_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPostulaciones_Postulacionesfechatrabajo_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPostulaciones_Postulacionesfechatrabajo_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPostulaciones_Postulacionesfechatrabajo_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("PostulacionesFechaTrabajo_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPostulaciones_Postulacionesfechacierre_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPostulaciones_Postulacionesfechacierre_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPostulaciones_Postulacionesfechacierre_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("PostulacionesFechaCierre_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("PostulacionesHoraCierre_Z", gxTv_SdtPostulaciones_Postulacioneshoracierre_Z, false, includeNonInitialized);
            AddObjectProperty("PostulacionesTipoFecha_Z", gxTv_SdtPostulaciones_Postulacionestipofecha_Z, false, includeNonInitialized);
            AddObjectProperty("PostulacionesRgoHoraservicio_Z", gxTv_SdtPostulaciones_Postulacionesrgohoraservicio_Z, false, includeNonInitialized);
            AddObjectProperty("PostulacionesApellidoNombre_Z", gxTv_SdtPostulaciones_Postulacionesapellidonombre_Z, false, includeNonInitialized);
            AddObjectProperty("PostulacionesMail_Z", gxTv_SdtPostulaciones_Postulacionesmail_Z, false, includeNonInitialized);
            AddObjectProperty("PostulacionesTelefono_Z", gxTv_SdtPostulaciones_Postulacionestelefono_Z, false, includeNonInitialized);
            AddObjectProperty("PostulacionesDepartamentoId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtPostulaciones_Postulacionesdepartamentoid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("PostulacionesDepartamentoMunicipioId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtPostulaciones_Postulacionesdepartamentomunicipioid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("PostulacionesZonasID_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtPostulaciones_Postulacioneszonasid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("PostulacionesDireccion_Z", gxTv_SdtPostulaciones_Postulacionesdireccion_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtPostulaciones_Postulacionesfechaalta_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("PostulacionesFechaAlta_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("PostulacionesEstado_Z", gxTv_SdtPostulaciones_Postulacionesestado_Z, false, includeNonInitialized);
            AddObjectProperty("PostulacionesSecUserId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtPostulaciones_Postulacionessecuserid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("PostulacionesId_N", gxTv_SdtPostulaciones_Postulacionesid_N, false, includeNonInitialized);
            AddObjectProperty("ServiciosId_N", gxTv_SdtPostulaciones_Serviciosid_N, false, includeNonInitialized);
            AddObjectProperty("PostulacionesSolicitudesId_N", gxTv_SdtPostulaciones_Postulacionessolicitudesid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtPostulaciones sdt )
      {
         if ( sdt.IsDirty("PostulacionesId") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesid = sdt.gxTv_SdtPostulaciones_Postulacionesid ;
         }
         if ( sdt.IsDirty("ServiciosId") )
         {
            gxTv_SdtPostulaciones_Serviciosid_N = (short)(sdt.gxTv_SdtPostulaciones_Serviciosid_N);
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Serviciosid = sdt.gxTv_SdtPostulaciones_Serviciosid ;
         }
         if ( sdt.IsDirty("ServiciosNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Serviciosnombre = sdt.gxTv_SdtPostulaciones_Serviciosnombre ;
         }
         if ( sdt.IsDirty("PostulacionesProveedorId") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesproveedorid = sdt.gxTv_SdtPostulaciones_Postulacionesproveedorid ;
         }
         if ( sdt.IsDirty("PostulacionesProvNombreAux") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesprovnombreaux = sdt.gxTv_SdtPostulaciones_Postulacionesprovnombreaux ;
         }
         if ( sdt.IsDirty("PostulacionesProveedorNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesproveedornombre = sdt.gxTv_SdtPostulaciones_Postulacionesproveedornombre ;
         }
         if ( sdt.IsDirty("PostulacionesPrecio") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesprecio = sdt.gxTv_SdtPostulaciones_Postulacionesprecio ;
         }
         if ( sdt.IsDirty("PostulacionesMultimediaSerial") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesmultimediaserial = sdt.gxTv_SdtPostulaciones_Postulacionesmultimediaserial ;
         }
         if ( sdt.IsDirty("PostulacionesSolicitudesId") )
         {
            gxTv_SdtPostulaciones_Postulacionessolicitudesid_N = (short)(sdt.gxTv_SdtPostulaciones_Postulacionessolicitudesid_N);
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionessolicitudesid = sdt.gxTv_SdtPostulaciones_Postulacionessolicitudesid ;
         }
         if ( gxTv_SdtPostulaciones_Categorias != null )
         {
            GXBCLevelCollection<SdtPostulaciones_Categorias> newCollectionCategorias = sdt.gxTpr_Categorias;
            SdtPostulaciones_Categorias currItemCategorias;
            SdtPostulaciones_Categorias newItemCategorias;
            short idx = 1;
            while ( idx <= newCollectionCategorias.Count )
            {
               newItemCategorias = ((SdtPostulaciones_Categorias)newCollectionCategorias.Item(idx));
               currItemCategorias = gxTv_SdtPostulaciones_Categorias.GetByKey(newItemCategorias.gxTpr_Categoriasid);
               if ( StringUtil.StrCmp(currItemCategorias.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemCategorias.UpdateDirties(newItemCategorias);
                  if ( StringUtil.StrCmp(newItemCategorias.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemCategorias.gxTpr_Mode = "DLT";
                  }
                  currItemCategorias.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtPostulaciones_Categorias.Add(newItemCategorias, 0);
               }
               idx = (short)(idx+1);
            }
         }
         if ( gxTv_SdtPostulaciones_Multimedia != null )
         {
            GXBCLevelCollection<SdtPostulaciones_Multimedia> newCollectionMultimedia = sdt.gxTpr_Multimedia;
            SdtPostulaciones_Multimedia currItemMultimedia;
            SdtPostulaciones_Multimedia newItemMultimedia;
            short idx = 1;
            while ( idx <= newCollectionMultimedia.Count )
            {
               newItemMultimedia = ((SdtPostulaciones_Multimedia)newCollectionMultimedia.Item(idx));
               currItemMultimedia = gxTv_SdtPostulaciones_Multimedia.GetByKey(newItemMultimedia.gxTpr_Multimediaid);
               if ( StringUtil.StrCmp(currItemMultimedia.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemMultimedia.UpdateDirties(newItemMultimedia);
                  if ( StringUtil.StrCmp(newItemMultimedia.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemMultimedia.gxTpr_Mode = "DLT";
                  }
                  currItemMultimedia.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtPostulaciones_Multimedia.Add(newItemMultimedia, 0);
               }
               idx = (short)(idx+1);
            }
         }
         if ( sdt.IsDirty("PostulacionesDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesdescripcion = sdt.gxTv_SdtPostulaciones_Postulacionesdescripcion ;
         }
         if ( sdt.IsDirty("PostulacionesReqSuministros") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesreqsuministros = sdt.gxTv_SdtPostulaciones_Postulacionesreqsuministros ;
         }
         if ( sdt.IsDirty("PostulacionesSuministrosDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionessuministrosdescripcion = sdt.gxTv_SdtPostulaciones_Postulacionessuministrosdescripcion ;
         }
         if ( sdt.IsDirty("PostulacionesFechaTrabajo") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesfechatrabajo = sdt.gxTv_SdtPostulaciones_Postulacionesfechatrabajo ;
         }
         if ( sdt.IsDirty("PostulacionesFechaCierre") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesfechacierre = sdt.gxTv_SdtPostulaciones_Postulacionesfechacierre ;
         }
         if ( sdt.IsDirty("PostulacionesHoraCierre") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacioneshoracierre = sdt.gxTv_SdtPostulaciones_Postulacioneshoracierre ;
         }
         if ( sdt.IsDirty("PostulacionesTipoFecha") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionestipofecha = sdt.gxTv_SdtPostulaciones_Postulacionestipofecha ;
         }
         if ( sdt.IsDirty("PostulacionesRgoHoraservicio") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesrgohoraservicio = sdt.gxTv_SdtPostulaciones_Postulacionesrgohoraservicio ;
         }
         if ( sdt.IsDirty("PostulacionesApellidoNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesapellidonombre = sdt.gxTv_SdtPostulaciones_Postulacionesapellidonombre ;
         }
         if ( sdt.IsDirty("PostulacionesMail") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesmail = sdt.gxTv_SdtPostulaciones_Postulacionesmail ;
         }
         if ( sdt.IsDirty("PostulacionesTelefono") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionestelefono = sdt.gxTv_SdtPostulaciones_Postulacionestelefono ;
         }
         if ( sdt.IsDirty("PostulacionesDepartamentoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesdepartamentoid = sdt.gxTv_SdtPostulaciones_Postulacionesdepartamentoid ;
         }
         if ( sdt.IsDirty("PostulacionesDepartamentoMunicipioId") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesdepartamentomunicipioid = sdt.gxTv_SdtPostulaciones_Postulacionesdepartamentomunicipioid ;
         }
         if ( sdt.IsDirty("PostulacionesZonasID") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacioneszonasid = sdt.gxTv_SdtPostulaciones_Postulacioneszonasid ;
         }
         if ( sdt.IsDirty("PostulacionesDireccion") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesdireccion = sdt.gxTv_SdtPostulaciones_Postulacionesdireccion ;
         }
         if ( gxTv_SdtPostulaciones_Profesionales != null )
         {
            GXBCLevelCollection<SdtPostulaciones_Profesionales> newCollectionProfesionales = sdt.gxTpr_Profesionales;
            SdtPostulaciones_Profesionales currItemProfesionales;
            SdtPostulaciones_Profesionales newItemProfesionales;
            short idx = 1;
            while ( idx <= newCollectionProfesionales.Count )
            {
               newItemProfesionales = ((SdtPostulaciones_Profesionales)newCollectionProfesionales.Item(idx));
               currItemProfesionales = gxTv_SdtPostulaciones_Profesionales.GetByKey(newItemProfesionales.gxTpr_Profesionalesid);
               if ( StringUtil.StrCmp(currItemProfesionales.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemProfesionales.UpdateDirties(newItemProfesionales);
                  if ( StringUtil.StrCmp(newItemProfesionales.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemProfesionales.gxTpr_Mode = "DLT";
                  }
                  currItemProfesionales.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtPostulaciones_Profesionales.Add(newItemProfesionales, 0);
               }
               idx = (short)(idx+1);
            }
         }
         if ( sdt.IsDirty("PostulacionesFechaAlta") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesfechaalta = sdt.gxTv_SdtPostulaciones_Postulacionesfechaalta ;
         }
         if ( sdt.IsDirty("PostulacionesEstado") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesestado = sdt.gxTv_SdtPostulaciones_Postulacionesestado ;
         }
         if ( sdt.IsDirty("PostulacionesSecUserId") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionessecuserid = sdt.gxTv_SdtPostulaciones_Postulacionessecuserid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PostulacionesId" )]
      [  XmlElement( ElementName = "PostulacionesId"   )]
      public long gxTpr_Postulacionesid
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtPostulaciones_Postulacionesid != value )
            {
               gxTv_SdtPostulaciones_Mode = "INS";
               this.gxTv_SdtPostulaciones_Postulacionesid_Z_SetNull( );
               this.gxTv_SdtPostulaciones_Serviciosid_Z_SetNull( );
               this.gxTv_SdtPostulaciones_Serviciosnombre_Z_SetNull( );
               this.gxTv_SdtPostulaciones_Postulacionesproveedorid_Z_SetNull( );
               this.gxTv_SdtPostulaciones_Postulacionesprovnombreaux_Z_SetNull( );
               this.gxTv_SdtPostulaciones_Postulacionesproveedornombre_Z_SetNull( );
               this.gxTv_SdtPostulaciones_Postulacionesprecio_Z_SetNull( );
               this.gxTv_SdtPostulaciones_Postulacionesmultimediaserial_Z_SetNull( );
               this.gxTv_SdtPostulaciones_Postulacionessolicitudesid_Z_SetNull( );
               this.gxTv_SdtPostulaciones_Postulacionesdescripcion_Z_SetNull( );
               this.gxTv_SdtPostulaciones_Postulacionesreqsuministros_Z_SetNull( );
               this.gxTv_SdtPostulaciones_Postulacionessuministrosdescripcion_Z_SetNull( );
               this.gxTv_SdtPostulaciones_Postulacionesfechatrabajo_Z_SetNull( );
               this.gxTv_SdtPostulaciones_Postulacionesfechacierre_Z_SetNull( );
               this.gxTv_SdtPostulaciones_Postulacioneshoracierre_Z_SetNull( );
               this.gxTv_SdtPostulaciones_Postulacionestipofecha_Z_SetNull( );
               this.gxTv_SdtPostulaciones_Postulacionesrgohoraservicio_Z_SetNull( );
               this.gxTv_SdtPostulaciones_Postulacionesapellidonombre_Z_SetNull( );
               this.gxTv_SdtPostulaciones_Postulacionesmail_Z_SetNull( );
               this.gxTv_SdtPostulaciones_Postulacionestelefono_Z_SetNull( );
               this.gxTv_SdtPostulaciones_Postulacionesdepartamentoid_Z_SetNull( );
               this.gxTv_SdtPostulaciones_Postulacionesdepartamentomunicipioid_Z_SetNull( );
               this.gxTv_SdtPostulaciones_Postulacioneszonasid_Z_SetNull( );
               this.gxTv_SdtPostulaciones_Postulacionesdireccion_Z_SetNull( );
               this.gxTv_SdtPostulaciones_Postulacionesfechaalta_Z_SetNull( );
               this.gxTv_SdtPostulaciones_Postulacionesestado_Z_SetNull( );
               this.gxTv_SdtPostulaciones_Postulacionessecuserid_Z_SetNull( );
               if ( gxTv_SdtPostulaciones_Categorias != null )
               {
                  GXBCLevelCollection<SdtPostulaciones_Categorias> collectionCategorias = gxTv_SdtPostulaciones_Categorias;
                  SdtPostulaciones_Categorias currItemCategorias;
                  short idx = 1;
                  while ( idx <= collectionCategorias.Count )
                  {
                     currItemCategorias = ((SdtPostulaciones_Categorias)collectionCategorias.Item(idx));
                     currItemCategorias.gxTpr_Mode = "INS";
                     currItemCategorias.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
               if ( gxTv_SdtPostulaciones_Multimedia != null )
               {
                  GXBCLevelCollection<SdtPostulaciones_Multimedia> collectionMultimedia = gxTv_SdtPostulaciones_Multimedia;
                  SdtPostulaciones_Multimedia currItemMultimedia;
                  short idx = 1;
                  while ( idx <= collectionMultimedia.Count )
                  {
                     currItemMultimedia = ((SdtPostulaciones_Multimedia)collectionMultimedia.Item(idx));
                     currItemMultimedia.gxTpr_Mode = "INS";
                     currItemMultimedia.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
               if ( gxTv_SdtPostulaciones_Profesionales != null )
               {
                  GXBCLevelCollection<SdtPostulaciones_Profesionales> collectionProfesionales = gxTv_SdtPostulaciones_Profesionales;
                  SdtPostulaciones_Profesionales currItemProfesionales;
                  short idx = 1;
                  while ( idx <= collectionProfesionales.Count )
                  {
                     currItemProfesionales = ((SdtPostulaciones_Profesionales)collectionProfesionales.Item(idx));
                     currItemProfesionales.gxTpr_Mode = "INS";
                     currItemProfesionales.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtPostulaciones_Postulacionesid = value;
            SetDirty("Postulacionesid");
         }

      }

      [  SoapElement( ElementName = "ServiciosId" )]
      [  XmlElement( ElementName = "ServiciosId"   )]
      public long gxTpr_Serviciosid
      {
         get {
            return gxTv_SdtPostulaciones_Serviciosid ;
         }

         set {
            gxTv_SdtPostulaciones_Serviciosid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Serviciosid = value;
            SetDirty("Serviciosid");
         }

      }

      public void gxTv_SdtPostulaciones_Serviciosid_SetNull( )
      {
         gxTv_SdtPostulaciones_Serviciosid_N = 1;
         gxTv_SdtPostulaciones_Serviciosid = 0;
         SetDirty("Serviciosid");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Serviciosid_IsNull( )
      {
         return (gxTv_SdtPostulaciones_Serviciosid_N==1) ;
      }

      [  SoapElement( ElementName = "ServiciosNombre" )]
      [  XmlElement( ElementName = "ServiciosNombre"   )]
      public string gxTpr_Serviciosnombre
      {
         get {
            return gxTv_SdtPostulaciones_Serviciosnombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Serviciosnombre = value;
            SetDirty("Serviciosnombre");
         }

      }

      [  SoapElement( ElementName = "PostulacionesProveedorId" )]
      [  XmlElement( ElementName = "PostulacionesProveedorId"   )]
      public long gxTpr_Postulacionesproveedorid
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesproveedorid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesproveedorid = value;
            SetDirty("Postulacionesproveedorid");
         }

      }

      [  SoapElement( ElementName = "PostulacionesProvNombreAux" )]
      [  XmlElement( ElementName = "PostulacionesProvNombreAux"   )]
      public string gxTpr_Postulacionesprovnombreaux
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesprovnombreaux ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesprovnombreaux = value;
            SetDirty("Postulacionesprovnombreaux");
         }

      }

      [  SoapElement( ElementName = "PostulacionesProveedorNombre" )]
      [  XmlElement( ElementName = "PostulacionesProveedorNombre"   )]
      public string gxTpr_Postulacionesproveedornombre
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesproveedornombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesproveedornombre = value;
            SetDirty("Postulacionesproveedornombre");
         }

      }

      [  SoapElement( ElementName = "PostulacionesPrecio" )]
      [  XmlElement( ElementName = "PostulacionesPrecio"   )]
      public decimal gxTpr_Postulacionesprecio
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesprecio ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesprecio = value;
            SetDirty("Postulacionesprecio");
         }

      }

      [  SoapElement( ElementName = "PostulacionesMultimediaSerial" )]
      [  XmlElement( ElementName = "PostulacionesMultimediaSerial"   )]
      public short gxTpr_Postulacionesmultimediaserial
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesmultimediaserial ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesmultimediaserial = value;
            SetDirty("Postulacionesmultimediaserial");
         }

      }

      [  SoapElement( ElementName = "PostulacionesSolicitudesId" )]
      [  XmlElement( ElementName = "PostulacionesSolicitudesId"   )]
      public long gxTpr_Postulacionessolicitudesid
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionessolicitudesid ;
         }

         set {
            gxTv_SdtPostulaciones_Postulacionessolicitudesid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionessolicitudesid = value;
            SetDirty("Postulacionessolicitudesid");
         }

      }

      public void gxTv_SdtPostulaciones_Postulacionessolicitudesid_SetNull( )
      {
         gxTv_SdtPostulaciones_Postulacionessolicitudesid_N = 1;
         gxTv_SdtPostulaciones_Postulacionessolicitudesid = 0;
         SetDirty("Postulacionessolicitudesid");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Postulacionessolicitudesid_IsNull( )
      {
         return (gxTv_SdtPostulaciones_Postulacionessolicitudesid_N==1) ;
      }

      [  SoapElement( ElementName = "Categorias" )]
      [  XmlArray( ElementName = "Categorias"  )]
      [  XmlArrayItemAttribute( ElementName= "Postulaciones.Categorias"  , IsNullable=false)]
      public GXBCLevelCollection<SdtPostulaciones_Categorias> gxTpr_Categorias_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtPostulaciones_Categorias == null )
            {
               gxTv_SdtPostulaciones_Categorias = new GXBCLevelCollection<SdtPostulaciones_Categorias>( context, "Postulaciones.Categorias", "AlmangoX");
            }
            return gxTv_SdtPostulaciones_Categorias ;
         }

         set {
            if ( gxTv_SdtPostulaciones_Categorias == null )
            {
               gxTv_SdtPostulaciones_Categorias = new GXBCLevelCollection<SdtPostulaciones_Categorias>( context, "Postulaciones.Categorias", "AlmangoX");
            }
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Categorias = value;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public GXBCLevelCollection<SdtPostulaciones_Categorias> gxTpr_Categorias
      {
         get {
            if ( gxTv_SdtPostulaciones_Categorias == null )
            {
               gxTv_SdtPostulaciones_Categorias = new GXBCLevelCollection<SdtPostulaciones_Categorias>( context, "Postulaciones.Categorias", "AlmangoX");
            }
            sdtIsNull = 0;
            return gxTv_SdtPostulaciones_Categorias ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Categorias = value;
            SetDirty("Categorias");
         }

      }

      public void gxTv_SdtPostulaciones_Categorias_SetNull( )
      {
         gxTv_SdtPostulaciones_Categorias = null;
         SetDirty("Categorias");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Categorias_IsNull( )
      {
         if ( gxTv_SdtPostulaciones_Categorias == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Multimedia" )]
      [  XmlArray( ElementName = "Multimedia"  )]
      [  XmlArrayItemAttribute( ElementName= "Postulaciones.Multimedia"  , IsNullable=false)]
      public GXBCLevelCollection<SdtPostulaciones_Multimedia> gxTpr_Multimedia_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtPostulaciones_Multimedia == null )
            {
               gxTv_SdtPostulaciones_Multimedia = new GXBCLevelCollection<SdtPostulaciones_Multimedia>( context, "Postulaciones.Multimedia", "AlmangoX");
            }
            return gxTv_SdtPostulaciones_Multimedia ;
         }

         set {
            if ( gxTv_SdtPostulaciones_Multimedia == null )
            {
               gxTv_SdtPostulaciones_Multimedia = new GXBCLevelCollection<SdtPostulaciones_Multimedia>( context, "Postulaciones.Multimedia", "AlmangoX");
            }
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Multimedia = value;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public GXBCLevelCollection<SdtPostulaciones_Multimedia> gxTpr_Multimedia
      {
         get {
            if ( gxTv_SdtPostulaciones_Multimedia == null )
            {
               gxTv_SdtPostulaciones_Multimedia = new GXBCLevelCollection<SdtPostulaciones_Multimedia>( context, "Postulaciones.Multimedia", "AlmangoX");
            }
            sdtIsNull = 0;
            return gxTv_SdtPostulaciones_Multimedia ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Multimedia = value;
            SetDirty("Multimedia");
         }

      }

      public void gxTv_SdtPostulaciones_Multimedia_SetNull( )
      {
         gxTv_SdtPostulaciones_Multimedia = null;
         SetDirty("Multimedia");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Multimedia_IsNull( )
      {
         if ( gxTv_SdtPostulaciones_Multimedia == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionesDescripcion" )]
      [  XmlElement( ElementName = "PostulacionesDescripcion"   )]
      public string gxTpr_Postulacionesdescripcion
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesdescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesdescripcion = value;
            SetDirty("Postulacionesdescripcion");
         }

      }

      [  SoapElement( ElementName = "PostulacionesReqSuministros" )]
      [  XmlElement( ElementName = "PostulacionesReqSuministros"   )]
      public bool gxTpr_Postulacionesreqsuministros
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesreqsuministros ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesreqsuministros = value;
            SetDirty("Postulacionesreqsuministros");
         }

      }

      [  SoapElement( ElementName = "PostulacionesSuministrosDescripcion" )]
      [  XmlElement( ElementName = "PostulacionesSuministrosDescripcion"   )]
      public string gxTpr_Postulacionessuministrosdescripcion
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionessuministrosdescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionessuministrosdescripcion = value;
            SetDirty("Postulacionessuministrosdescripcion");
         }

      }

      [  SoapElement( ElementName = "PostulacionesFechaTrabajo" )]
      [  XmlElement( ElementName = "PostulacionesFechaTrabajo"  , IsNullable=true )]
      public string gxTpr_Postulacionesfechatrabajo_Nullable
      {
         get {
            if ( gxTv_SdtPostulaciones_Postulacionesfechatrabajo == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPostulaciones_Postulacionesfechatrabajo).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPostulaciones_Postulacionesfechatrabajo = DateTime.MinValue;
            else
               gxTv_SdtPostulaciones_Postulacionesfechatrabajo = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Postulacionesfechatrabajo
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesfechatrabajo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesfechatrabajo = DateTimeUtil.ResetTime(value);
            SetDirty("Postulacionesfechatrabajo");
         }

      }

      [  SoapElement( ElementName = "PostulacionesFechaCierre" )]
      [  XmlElement( ElementName = "PostulacionesFechaCierre"  , IsNullable=true )]
      public string gxTpr_Postulacionesfechacierre_Nullable
      {
         get {
            if ( gxTv_SdtPostulaciones_Postulacionesfechacierre == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPostulaciones_Postulacionesfechacierre).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPostulaciones_Postulacionesfechacierre = DateTime.MinValue;
            else
               gxTv_SdtPostulaciones_Postulacionesfechacierre = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Postulacionesfechacierre
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesfechacierre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesfechacierre = DateTimeUtil.ResetTime(value);
            SetDirty("Postulacionesfechacierre");
         }

      }

      [  SoapElement( ElementName = "PostulacionesHoraCierre" )]
      [  XmlElement( ElementName = "PostulacionesHoraCierre"   )]
      public string gxTpr_Postulacioneshoracierre
      {
         get {
            return gxTv_SdtPostulaciones_Postulacioneshoracierre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacioneshoracierre = value;
            SetDirty("Postulacioneshoracierre");
         }

      }

      [  SoapElement( ElementName = "PostulacionesTipoFecha" )]
      [  XmlElement( ElementName = "PostulacionesTipoFecha"   )]
      public string gxTpr_Postulacionestipofecha
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionestipofecha ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionestipofecha = value;
            SetDirty("Postulacionestipofecha");
         }

      }

      [  SoapElement( ElementName = "PostulacionesRgoHoraservicio" )]
      [  XmlElement( ElementName = "PostulacionesRgoHoraservicio"   )]
      public string gxTpr_Postulacionesrgohoraservicio
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesrgohoraservicio ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesrgohoraservicio = value;
            SetDirty("Postulacionesrgohoraservicio");
         }

      }

      [  SoapElement( ElementName = "PostulacionesApellidoNombre" )]
      [  XmlElement( ElementName = "PostulacionesApellidoNombre"   )]
      public string gxTpr_Postulacionesapellidonombre
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesapellidonombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesapellidonombre = value;
            SetDirty("Postulacionesapellidonombre");
         }

      }

      [  SoapElement( ElementName = "PostulacionesMail" )]
      [  XmlElement( ElementName = "PostulacionesMail"   )]
      public string gxTpr_Postulacionesmail
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesmail ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesmail = value;
            SetDirty("Postulacionesmail");
         }

      }

      [  SoapElement( ElementName = "PostulacionesTelefono" )]
      [  XmlElement( ElementName = "PostulacionesTelefono"   )]
      public string gxTpr_Postulacionestelefono
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionestelefono ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionestelefono = value;
            SetDirty("Postulacionestelefono");
         }

      }

      [  SoapElement( ElementName = "PostulacionesDepartamentoId" )]
      [  XmlElement( ElementName = "PostulacionesDepartamentoId"   )]
      public long gxTpr_Postulacionesdepartamentoid
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesdepartamentoid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesdepartamentoid = value;
            SetDirty("Postulacionesdepartamentoid");
         }

      }

      [  SoapElement( ElementName = "PostulacionesDepartamentoMunicipioId" )]
      [  XmlElement( ElementName = "PostulacionesDepartamentoMunicipioId"   )]
      public long gxTpr_Postulacionesdepartamentomunicipioid
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesdepartamentomunicipioid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesdepartamentomunicipioid = value;
            SetDirty("Postulacionesdepartamentomunicipioid");
         }

      }

      [  SoapElement( ElementName = "PostulacionesZonasID" )]
      [  XmlElement( ElementName = "PostulacionesZonasID"   )]
      public long gxTpr_Postulacioneszonasid
      {
         get {
            return gxTv_SdtPostulaciones_Postulacioneszonasid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacioneszonasid = value;
            SetDirty("Postulacioneszonasid");
         }

      }

      [  SoapElement( ElementName = "PostulacionesDireccion" )]
      [  XmlElement( ElementName = "PostulacionesDireccion"   )]
      public string gxTpr_Postulacionesdireccion
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesdireccion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesdireccion = value;
            SetDirty("Postulacionesdireccion");
         }

      }

      [  SoapElement( ElementName = "Profesionales" )]
      [  XmlArray( ElementName = "Profesionales"  )]
      [  XmlArrayItemAttribute( ElementName= "Postulaciones.Profesionales"  , IsNullable=false)]
      public GXBCLevelCollection<SdtPostulaciones_Profesionales> gxTpr_Profesionales_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtPostulaciones_Profesionales == null )
            {
               gxTv_SdtPostulaciones_Profesionales = new GXBCLevelCollection<SdtPostulaciones_Profesionales>( context, "Postulaciones.Profesionales", "AlmangoX");
            }
            return gxTv_SdtPostulaciones_Profesionales ;
         }

         set {
            if ( gxTv_SdtPostulaciones_Profesionales == null )
            {
               gxTv_SdtPostulaciones_Profesionales = new GXBCLevelCollection<SdtPostulaciones_Profesionales>( context, "Postulaciones.Profesionales", "AlmangoX");
            }
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales = value;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public GXBCLevelCollection<SdtPostulaciones_Profesionales> gxTpr_Profesionales
      {
         get {
            if ( gxTv_SdtPostulaciones_Profesionales == null )
            {
               gxTv_SdtPostulaciones_Profesionales = new GXBCLevelCollection<SdtPostulaciones_Profesionales>( context, "Postulaciones.Profesionales", "AlmangoX");
            }
            sdtIsNull = 0;
            return gxTv_SdtPostulaciones_Profesionales ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales = value;
            SetDirty("Profesionales");
         }

      }

      public void gxTv_SdtPostulaciones_Profesionales_SetNull( )
      {
         gxTv_SdtPostulaciones_Profesionales = null;
         SetDirty("Profesionales");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Profesionales_IsNull( )
      {
         if ( gxTv_SdtPostulaciones_Profesionales == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionesFechaAlta" )]
      [  XmlElement( ElementName = "PostulacionesFechaAlta"  , IsNullable=true )]
      public string gxTpr_Postulacionesfechaalta_Nullable
      {
         get {
            if ( gxTv_SdtPostulaciones_Postulacionesfechaalta == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtPostulaciones_Postulacionesfechaalta).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtPostulaciones_Postulacionesfechaalta = DateTime.MinValue;
            else
               gxTv_SdtPostulaciones_Postulacionesfechaalta = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Postulacionesfechaalta
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesfechaalta ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesfechaalta = value;
            SetDirty("Postulacionesfechaalta");
         }

      }

      [  SoapElement( ElementName = "PostulacionesEstado" )]
      [  XmlElement( ElementName = "PostulacionesEstado"   )]
      public string gxTpr_Postulacionesestado
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesestado ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesestado = value;
            SetDirty("Postulacionesestado");
         }

      }

      [  SoapElement( ElementName = "PostulacionesSecUserId" )]
      [  XmlElement( ElementName = "PostulacionesSecUserId"   )]
      public long gxTpr_Postulacionessecuserid
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionessecuserid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionessecuserid = value;
            SetDirty("Postulacionessecuserid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtPostulaciones_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtPostulaciones_Mode_SetNull( )
      {
         gxTv_SdtPostulaciones_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtPostulaciones_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtPostulaciones_Initialized_SetNull( )
      {
         gxTv_SdtPostulaciones_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionesId_Z" )]
      [  XmlElement( ElementName = "PostulacionesId_Z"   )]
      public long gxTpr_Postulacionesid_Z
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesid_Z = value;
            SetDirty("Postulacionesid_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Postulacionesid_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Postulacionesid_Z = 0;
         SetDirty("Postulacionesid_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Postulacionesid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ServiciosId_Z" )]
      [  XmlElement( ElementName = "ServiciosId_Z"   )]
      public long gxTpr_Serviciosid_Z
      {
         get {
            return gxTv_SdtPostulaciones_Serviciosid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Serviciosid_Z = value;
            SetDirty("Serviciosid_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Serviciosid_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Serviciosid_Z = 0;
         SetDirty("Serviciosid_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Serviciosid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ServiciosNombre_Z" )]
      [  XmlElement( ElementName = "ServiciosNombre_Z"   )]
      public string gxTpr_Serviciosnombre_Z
      {
         get {
            return gxTv_SdtPostulaciones_Serviciosnombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Serviciosnombre_Z = value;
            SetDirty("Serviciosnombre_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Serviciosnombre_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Serviciosnombre_Z = "";
         SetDirty("Serviciosnombre_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Serviciosnombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionesProveedorId_Z" )]
      [  XmlElement( ElementName = "PostulacionesProveedorId_Z"   )]
      public long gxTpr_Postulacionesproveedorid_Z
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesproveedorid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesproveedorid_Z = value;
            SetDirty("Postulacionesproveedorid_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Postulacionesproveedorid_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Postulacionesproveedorid_Z = 0;
         SetDirty("Postulacionesproveedorid_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Postulacionesproveedorid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionesProvNombreAux_Z" )]
      [  XmlElement( ElementName = "PostulacionesProvNombreAux_Z"   )]
      public string gxTpr_Postulacionesprovnombreaux_Z
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesprovnombreaux_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesprovnombreaux_Z = value;
            SetDirty("Postulacionesprovnombreaux_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Postulacionesprovnombreaux_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Postulacionesprovnombreaux_Z = "";
         SetDirty("Postulacionesprovnombreaux_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Postulacionesprovnombreaux_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionesProveedorNombre_Z" )]
      [  XmlElement( ElementName = "PostulacionesProveedorNombre_Z"   )]
      public string gxTpr_Postulacionesproveedornombre_Z
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesproveedornombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesproveedornombre_Z = value;
            SetDirty("Postulacionesproveedornombre_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Postulacionesproveedornombre_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Postulacionesproveedornombre_Z = "";
         SetDirty("Postulacionesproveedornombre_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Postulacionesproveedornombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionesPrecio_Z" )]
      [  XmlElement( ElementName = "PostulacionesPrecio_Z"   )]
      public decimal gxTpr_Postulacionesprecio_Z
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesprecio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesprecio_Z = value;
            SetDirty("Postulacionesprecio_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Postulacionesprecio_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Postulacionesprecio_Z = 0;
         SetDirty("Postulacionesprecio_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Postulacionesprecio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionesMultimediaSerial_Z" )]
      [  XmlElement( ElementName = "PostulacionesMultimediaSerial_Z"   )]
      public short gxTpr_Postulacionesmultimediaserial_Z
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesmultimediaserial_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesmultimediaserial_Z = value;
            SetDirty("Postulacionesmultimediaserial_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Postulacionesmultimediaserial_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Postulacionesmultimediaserial_Z = 0;
         SetDirty("Postulacionesmultimediaserial_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Postulacionesmultimediaserial_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionesSolicitudesId_Z" )]
      [  XmlElement( ElementName = "PostulacionesSolicitudesId_Z"   )]
      public long gxTpr_Postulacionessolicitudesid_Z
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionessolicitudesid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionessolicitudesid_Z = value;
            SetDirty("Postulacionessolicitudesid_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Postulacionessolicitudesid_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Postulacionessolicitudesid_Z = 0;
         SetDirty("Postulacionessolicitudesid_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Postulacionessolicitudesid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionesDescripcion_Z" )]
      [  XmlElement( ElementName = "PostulacionesDescripcion_Z"   )]
      public string gxTpr_Postulacionesdescripcion_Z
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesdescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesdescripcion_Z = value;
            SetDirty("Postulacionesdescripcion_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Postulacionesdescripcion_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Postulacionesdescripcion_Z = "";
         SetDirty("Postulacionesdescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Postulacionesdescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionesReqSuministros_Z" )]
      [  XmlElement( ElementName = "PostulacionesReqSuministros_Z"   )]
      public bool gxTpr_Postulacionesreqsuministros_Z
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesreqsuministros_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesreqsuministros_Z = value;
            SetDirty("Postulacionesreqsuministros_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Postulacionesreqsuministros_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Postulacionesreqsuministros_Z = false;
         SetDirty("Postulacionesreqsuministros_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Postulacionesreqsuministros_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionesSuministrosDescripcion_Z" )]
      [  XmlElement( ElementName = "PostulacionesSuministrosDescripcion_Z"   )]
      public string gxTpr_Postulacionessuministrosdescripcion_Z
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionessuministrosdescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionessuministrosdescripcion_Z = value;
            SetDirty("Postulacionessuministrosdescripcion_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Postulacionessuministrosdescripcion_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Postulacionessuministrosdescripcion_Z = "";
         SetDirty("Postulacionessuministrosdescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Postulacionessuministrosdescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionesFechaTrabajo_Z" )]
      [  XmlElement( ElementName = "PostulacionesFechaTrabajo_Z"  , IsNullable=true )]
      public string gxTpr_Postulacionesfechatrabajo_Z_Nullable
      {
         get {
            if ( gxTv_SdtPostulaciones_Postulacionesfechatrabajo_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPostulaciones_Postulacionesfechatrabajo_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPostulaciones_Postulacionesfechatrabajo_Z = DateTime.MinValue;
            else
               gxTv_SdtPostulaciones_Postulacionesfechatrabajo_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Postulacionesfechatrabajo_Z
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesfechatrabajo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesfechatrabajo_Z = DateTimeUtil.ResetTime(value);
            SetDirty("Postulacionesfechatrabajo_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Postulacionesfechatrabajo_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Postulacionesfechatrabajo_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Postulacionesfechatrabajo_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Postulacionesfechatrabajo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionesFechaCierre_Z" )]
      [  XmlElement( ElementName = "PostulacionesFechaCierre_Z"  , IsNullable=true )]
      public string gxTpr_Postulacionesfechacierre_Z_Nullable
      {
         get {
            if ( gxTv_SdtPostulaciones_Postulacionesfechacierre_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPostulaciones_Postulacionesfechacierre_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPostulaciones_Postulacionesfechacierre_Z = DateTime.MinValue;
            else
               gxTv_SdtPostulaciones_Postulacionesfechacierre_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Postulacionesfechacierre_Z
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesfechacierre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesfechacierre_Z = DateTimeUtil.ResetTime(value);
            SetDirty("Postulacionesfechacierre_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Postulacionesfechacierre_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Postulacionesfechacierre_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Postulacionesfechacierre_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Postulacionesfechacierre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionesHoraCierre_Z" )]
      [  XmlElement( ElementName = "PostulacionesHoraCierre_Z"   )]
      public string gxTpr_Postulacioneshoracierre_Z
      {
         get {
            return gxTv_SdtPostulaciones_Postulacioneshoracierre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacioneshoracierre_Z = value;
            SetDirty("Postulacioneshoracierre_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Postulacioneshoracierre_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Postulacioneshoracierre_Z = "";
         SetDirty("Postulacioneshoracierre_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Postulacioneshoracierre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionesTipoFecha_Z" )]
      [  XmlElement( ElementName = "PostulacionesTipoFecha_Z"   )]
      public string gxTpr_Postulacionestipofecha_Z
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionestipofecha_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionestipofecha_Z = value;
            SetDirty("Postulacionestipofecha_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Postulacionestipofecha_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Postulacionestipofecha_Z = "";
         SetDirty("Postulacionestipofecha_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Postulacionestipofecha_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionesRgoHoraservicio_Z" )]
      [  XmlElement( ElementName = "PostulacionesRgoHoraservicio_Z"   )]
      public string gxTpr_Postulacionesrgohoraservicio_Z
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesrgohoraservicio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesrgohoraservicio_Z = value;
            SetDirty("Postulacionesrgohoraservicio_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Postulacionesrgohoraservicio_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Postulacionesrgohoraservicio_Z = "";
         SetDirty("Postulacionesrgohoraservicio_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Postulacionesrgohoraservicio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionesApellidoNombre_Z" )]
      [  XmlElement( ElementName = "PostulacionesApellidoNombre_Z"   )]
      public string gxTpr_Postulacionesapellidonombre_Z
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesapellidonombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesapellidonombre_Z = value;
            SetDirty("Postulacionesapellidonombre_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Postulacionesapellidonombre_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Postulacionesapellidonombre_Z = "";
         SetDirty("Postulacionesapellidonombre_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Postulacionesapellidonombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionesMail_Z" )]
      [  XmlElement( ElementName = "PostulacionesMail_Z"   )]
      public string gxTpr_Postulacionesmail_Z
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesmail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesmail_Z = value;
            SetDirty("Postulacionesmail_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Postulacionesmail_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Postulacionesmail_Z = "";
         SetDirty("Postulacionesmail_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Postulacionesmail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionesTelefono_Z" )]
      [  XmlElement( ElementName = "PostulacionesTelefono_Z"   )]
      public string gxTpr_Postulacionestelefono_Z
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionestelefono_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionestelefono_Z = value;
            SetDirty("Postulacionestelefono_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Postulacionestelefono_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Postulacionestelefono_Z = "";
         SetDirty("Postulacionestelefono_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Postulacionestelefono_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionesDepartamentoId_Z" )]
      [  XmlElement( ElementName = "PostulacionesDepartamentoId_Z"   )]
      public long gxTpr_Postulacionesdepartamentoid_Z
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesdepartamentoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesdepartamentoid_Z = value;
            SetDirty("Postulacionesdepartamentoid_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Postulacionesdepartamentoid_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Postulacionesdepartamentoid_Z = 0;
         SetDirty("Postulacionesdepartamentoid_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Postulacionesdepartamentoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionesDepartamentoMunicipioId_Z" )]
      [  XmlElement( ElementName = "PostulacionesDepartamentoMunicipioId_Z"   )]
      public long gxTpr_Postulacionesdepartamentomunicipioid_Z
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesdepartamentomunicipioid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesdepartamentomunicipioid_Z = value;
            SetDirty("Postulacionesdepartamentomunicipioid_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Postulacionesdepartamentomunicipioid_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Postulacionesdepartamentomunicipioid_Z = 0;
         SetDirty("Postulacionesdepartamentomunicipioid_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Postulacionesdepartamentomunicipioid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionesZonasID_Z" )]
      [  XmlElement( ElementName = "PostulacionesZonasID_Z"   )]
      public long gxTpr_Postulacioneszonasid_Z
      {
         get {
            return gxTv_SdtPostulaciones_Postulacioneszonasid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacioneszonasid_Z = value;
            SetDirty("Postulacioneszonasid_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Postulacioneszonasid_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Postulacioneszonasid_Z = 0;
         SetDirty("Postulacioneszonasid_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Postulacioneszonasid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionesDireccion_Z" )]
      [  XmlElement( ElementName = "PostulacionesDireccion_Z"   )]
      public string gxTpr_Postulacionesdireccion_Z
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesdireccion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesdireccion_Z = value;
            SetDirty("Postulacionesdireccion_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Postulacionesdireccion_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Postulacionesdireccion_Z = "";
         SetDirty("Postulacionesdireccion_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Postulacionesdireccion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionesFechaAlta_Z" )]
      [  XmlElement( ElementName = "PostulacionesFechaAlta_Z"  , IsNullable=true )]
      public string gxTpr_Postulacionesfechaalta_Z_Nullable
      {
         get {
            if ( gxTv_SdtPostulaciones_Postulacionesfechaalta_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtPostulaciones_Postulacionesfechaalta_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtPostulaciones_Postulacionesfechaalta_Z = DateTime.MinValue;
            else
               gxTv_SdtPostulaciones_Postulacionesfechaalta_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Postulacionesfechaalta_Z
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesfechaalta_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesfechaalta_Z = value;
            SetDirty("Postulacionesfechaalta_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Postulacionesfechaalta_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Postulacionesfechaalta_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Postulacionesfechaalta_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Postulacionesfechaalta_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionesEstado_Z" )]
      [  XmlElement( ElementName = "PostulacionesEstado_Z"   )]
      public string gxTpr_Postulacionesestado_Z
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesestado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesestado_Z = value;
            SetDirty("Postulacionesestado_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Postulacionesestado_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Postulacionesestado_Z = "";
         SetDirty("Postulacionesestado_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Postulacionesestado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionesSecUserId_Z" )]
      [  XmlElement( ElementName = "PostulacionesSecUserId_Z"   )]
      public long gxTpr_Postulacionessecuserid_Z
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionessecuserid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionessecuserid_Z = value;
            SetDirty("Postulacionessecuserid_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Postulacionessecuserid_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Postulacionessecuserid_Z = 0;
         SetDirty("Postulacionessecuserid_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Postulacionessecuserid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionesId_N" )]
      [  XmlElement( ElementName = "PostulacionesId_N"   )]
      public short gxTpr_Postulacionesid_N
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionesid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionesid_N = value;
            SetDirty("Postulacionesid_N");
         }

      }

      public void gxTv_SdtPostulaciones_Postulacionesid_N_SetNull( )
      {
         gxTv_SdtPostulaciones_Postulacionesid_N = 0;
         SetDirty("Postulacionesid_N");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Postulacionesid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ServiciosId_N" )]
      [  XmlElement( ElementName = "ServiciosId_N"   )]
      public short gxTpr_Serviciosid_N
      {
         get {
            return gxTv_SdtPostulaciones_Serviciosid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Serviciosid_N = value;
            SetDirty("Serviciosid_N");
         }

      }

      public void gxTv_SdtPostulaciones_Serviciosid_N_SetNull( )
      {
         gxTv_SdtPostulaciones_Serviciosid_N = 0;
         SetDirty("Serviciosid_N");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Serviciosid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionesSolicitudesId_N" )]
      [  XmlElement( ElementName = "PostulacionesSolicitudesId_N"   )]
      public short gxTpr_Postulacionessolicitudesid_N
      {
         get {
            return gxTv_SdtPostulaciones_Postulacionessolicitudesid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Postulacionessolicitudesid_N = value;
            SetDirty("Postulacionessolicitudesid_N");
         }

      }

      public void gxTv_SdtPostulaciones_Postulacionessolicitudesid_N_SetNull( )
      {
         gxTv_SdtPostulaciones_Postulacionessolicitudesid_N = 0;
         SetDirty("Postulacionessolicitudesid_N");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Postulacionessolicitudesid_N_IsNull( )
      {
         return false ;
      }

      [SoapIgnore]
      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtPostulaciones_Serviciosnombre = "";
         gxTv_SdtPostulaciones_Postulacionesprovnombreaux = "";
         gxTv_SdtPostulaciones_Postulacionesproveedornombre = "";
         gxTv_SdtPostulaciones_Postulacionesdescripcion = "";
         gxTv_SdtPostulaciones_Postulacionessuministrosdescripcion = "";
         gxTv_SdtPostulaciones_Postulacionesfechatrabajo = DateTime.MinValue;
         gxTv_SdtPostulaciones_Postulacionesfechacierre = DateTime.MinValue;
         gxTv_SdtPostulaciones_Postulacioneshoracierre = "";
         gxTv_SdtPostulaciones_Postulacionestipofecha = "";
         gxTv_SdtPostulaciones_Postulacionesrgohoraservicio = "";
         gxTv_SdtPostulaciones_Postulacionesapellidonombre = "";
         gxTv_SdtPostulaciones_Postulacionesmail = "";
         gxTv_SdtPostulaciones_Postulacionestelefono = "";
         gxTv_SdtPostulaciones_Postulacionesdireccion = "";
         gxTv_SdtPostulaciones_Postulacionesfechaalta = (DateTime)(DateTime.MinValue);
         gxTv_SdtPostulaciones_Postulacionesestado = "";
         gxTv_SdtPostulaciones_Mode = "";
         gxTv_SdtPostulaciones_Serviciosnombre_Z = "";
         gxTv_SdtPostulaciones_Postulacionesprovnombreaux_Z = "";
         gxTv_SdtPostulaciones_Postulacionesproveedornombre_Z = "";
         gxTv_SdtPostulaciones_Postulacionesdescripcion_Z = "";
         gxTv_SdtPostulaciones_Postulacionessuministrosdescripcion_Z = "";
         gxTv_SdtPostulaciones_Postulacionesfechatrabajo_Z = DateTime.MinValue;
         gxTv_SdtPostulaciones_Postulacionesfechacierre_Z = DateTime.MinValue;
         gxTv_SdtPostulaciones_Postulacioneshoracierre_Z = "";
         gxTv_SdtPostulaciones_Postulacionestipofecha_Z = "";
         gxTv_SdtPostulaciones_Postulacionesrgohoraservicio_Z = "";
         gxTv_SdtPostulaciones_Postulacionesapellidonombre_Z = "";
         gxTv_SdtPostulaciones_Postulacionesmail_Z = "";
         gxTv_SdtPostulaciones_Postulacionestelefono_Z = "";
         gxTv_SdtPostulaciones_Postulacionesdireccion_Z = "";
         gxTv_SdtPostulaciones_Postulacionesfechaalta_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtPostulaciones_Postulacionesestado_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "postulaciones", "GeneXus.Programs.postulaciones_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtPostulaciones_Postulacionesmultimediaserial ;
      private short gxTv_SdtPostulaciones_Initialized ;
      private short gxTv_SdtPostulaciones_Postulacionesmultimediaserial_Z ;
      private short gxTv_SdtPostulaciones_Postulacionesid_N ;
      private short gxTv_SdtPostulaciones_Serviciosid_N ;
      private short gxTv_SdtPostulaciones_Postulacionessolicitudesid_N ;
      private long gxTv_SdtPostulaciones_Postulacionesid ;
      private long gxTv_SdtPostulaciones_Serviciosid ;
      private long gxTv_SdtPostulaciones_Postulacionesproveedorid ;
      private long gxTv_SdtPostulaciones_Postulacionessolicitudesid ;
      private long gxTv_SdtPostulaciones_Postulacionesdepartamentoid ;
      private long gxTv_SdtPostulaciones_Postulacionesdepartamentomunicipioid ;
      private long gxTv_SdtPostulaciones_Postulacioneszonasid ;
      private long gxTv_SdtPostulaciones_Postulacionessecuserid ;
      private long gxTv_SdtPostulaciones_Postulacionesid_Z ;
      private long gxTv_SdtPostulaciones_Serviciosid_Z ;
      private long gxTv_SdtPostulaciones_Postulacionesproveedorid_Z ;
      private long gxTv_SdtPostulaciones_Postulacionessolicitudesid_Z ;
      private long gxTv_SdtPostulaciones_Postulacionesdepartamentoid_Z ;
      private long gxTv_SdtPostulaciones_Postulacionesdepartamentomunicipioid_Z ;
      private long gxTv_SdtPostulaciones_Postulacioneszonasid_Z ;
      private long gxTv_SdtPostulaciones_Postulacionessecuserid_Z ;
      private decimal gxTv_SdtPostulaciones_Postulacionesprecio ;
      private decimal gxTv_SdtPostulaciones_Postulacionesprecio_Z ;
      private string gxTv_SdtPostulaciones_Serviciosnombre ;
      private string gxTv_SdtPostulaciones_Postulacionesprovnombreaux ;
      private string gxTv_SdtPostulaciones_Postulacionesproveedornombre ;
      private string gxTv_SdtPostulaciones_Postulacionesdescripcion ;
      private string gxTv_SdtPostulaciones_Postulacionessuministrosdescripcion ;
      private string gxTv_SdtPostulaciones_Postulacionesrgohoraservicio ;
      private string gxTv_SdtPostulaciones_Postulacionesapellidonombre ;
      private string gxTv_SdtPostulaciones_Postulacionestelefono ;
      private string gxTv_SdtPostulaciones_Postulacionesdireccion ;
      private string gxTv_SdtPostulaciones_Postulacionesestado ;
      private string gxTv_SdtPostulaciones_Mode ;
      private string gxTv_SdtPostulaciones_Serviciosnombre_Z ;
      private string gxTv_SdtPostulaciones_Postulacionesprovnombreaux_Z ;
      private string gxTv_SdtPostulaciones_Postulacionesproveedornombre_Z ;
      private string gxTv_SdtPostulaciones_Postulacionesdescripcion_Z ;
      private string gxTv_SdtPostulaciones_Postulacionessuministrosdescripcion_Z ;
      private string gxTv_SdtPostulaciones_Postulacionesrgohoraservicio_Z ;
      private string gxTv_SdtPostulaciones_Postulacionesapellidonombre_Z ;
      private string gxTv_SdtPostulaciones_Postulacionestelefono_Z ;
      private string gxTv_SdtPostulaciones_Postulacionesdireccion_Z ;
      private string gxTv_SdtPostulaciones_Postulacionesestado_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtPostulaciones_Postulacionesfechaalta ;
      private DateTime gxTv_SdtPostulaciones_Postulacionesfechaalta_Z ;
      private DateTime datetime_STZ ;
      private DateTime gxTv_SdtPostulaciones_Postulacionesfechatrabajo ;
      private DateTime gxTv_SdtPostulaciones_Postulacionesfechacierre ;
      private DateTime gxTv_SdtPostulaciones_Postulacionesfechatrabajo_Z ;
      private DateTime gxTv_SdtPostulaciones_Postulacionesfechacierre_Z ;
      private bool gxTv_SdtPostulaciones_Postulacionesreqsuministros ;
      private bool gxTv_SdtPostulaciones_Postulacionesreqsuministros_Z ;
      private string gxTv_SdtPostulaciones_Postulacioneshoracierre ;
      private string gxTv_SdtPostulaciones_Postulacionestipofecha ;
      private string gxTv_SdtPostulaciones_Postulacionesmail ;
      private string gxTv_SdtPostulaciones_Postulacioneshoracierre_Z ;
      private string gxTv_SdtPostulaciones_Postulacionestipofecha_Z ;
      private string gxTv_SdtPostulaciones_Postulacionesmail_Z ;
      private GXBCLevelCollection<SdtPostulaciones_Categorias> gxTv_SdtPostulaciones_Categorias=null ;
      private GXBCLevelCollection<SdtPostulaciones_Multimedia> gxTv_SdtPostulaciones_Multimedia=null ;
      private GXBCLevelCollection<SdtPostulaciones_Profesionales> gxTv_SdtPostulaciones_Profesionales=null ;
   }

   [DataContract(Name = @"Postulaciones", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtPostulaciones_RESTInterface : GxGenericCollectionItem<SdtPostulaciones>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtPostulaciones_RESTInterface( ) : base()
      {
      }

      public SdtPostulaciones_RESTInterface( SdtPostulaciones psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PostulacionesId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Postulacionesid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Postulacionesid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Postulacionesid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ServiciosId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Serviciosid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Serviciosid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Serviciosid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ServiciosNombre" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Serviciosnombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Serviciosnombre) ;
         }

         set {
            sdt.gxTpr_Serviciosnombre = value;
         }

      }

      [DataMember( Name = "PostulacionesProveedorId" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Postulacionesproveedorid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Postulacionesproveedorid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Postulacionesproveedorid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PostulacionesProvNombreAux" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Postulacionesprovnombreaux
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Postulacionesprovnombreaux) ;
         }

         set {
            sdt.gxTpr_Postulacionesprovnombreaux = value;
         }

      }

      [DataMember( Name = "PostulacionesProveedorNombre" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Postulacionesproveedornombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Postulacionesproveedornombre) ;
         }

         set {
            sdt.gxTpr_Postulacionesproveedornombre = value;
         }

      }

      [DataMember( Name = "PostulacionesPrecio" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Postulacionesprecio
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Postulacionesprecio, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Postulacionesprecio = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "PostulacionesMultimediaSerial" , Order = 7 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Postulacionesmultimediaserial
      {
         get {
            return sdt.gxTpr_Postulacionesmultimediaserial ;
         }

         set {
            sdt.gxTpr_Postulacionesmultimediaserial = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PostulacionesSolicitudesId" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Postulacionessolicitudesid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Postulacionessolicitudesid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Postulacionessolicitudesid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "Categorias" , Order = 9 )]
      public GxGenericCollection<SdtPostulaciones_Categorias_RESTInterface> gxTpr_Categorias
      {
         get {
            return new GxGenericCollection<SdtPostulaciones_Categorias_RESTInterface>(sdt.gxTpr_Categorias) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Categorias);
         }

      }

      [DataMember( Name = "Multimedia" , Order = 10 )]
      public GxGenericCollection<SdtPostulaciones_Multimedia_RESTInterface> gxTpr_Multimedia
      {
         get {
            return new GxGenericCollection<SdtPostulaciones_Multimedia_RESTInterface>(sdt.gxTpr_Multimedia) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Multimedia);
         }

      }

      [DataMember( Name = "PostulacionesDescripcion" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Postulacionesdescripcion
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Postulacionesdescripcion) ;
         }

         set {
            sdt.gxTpr_Postulacionesdescripcion = value;
         }

      }

      [DataMember( Name = "PostulacionesReqSuministros" , Order = 12 )]
      [GxSeudo()]
      public bool gxTpr_Postulacionesreqsuministros
      {
         get {
            return sdt.gxTpr_Postulacionesreqsuministros ;
         }

         set {
            sdt.gxTpr_Postulacionesreqsuministros = value;
         }

      }

      [DataMember( Name = "PostulacionesSuministrosDescripcion" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Postulacionessuministrosdescripcion
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Postulacionessuministrosdescripcion) ;
         }

         set {
            sdt.gxTpr_Postulacionessuministrosdescripcion = value;
         }

      }

      [DataMember( Name = "PostulacionesFechaTrabajo" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Postulacionesfechatrabajo
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Postulacionesfechatrabajo) ;
         }

         set {
            sdt.gxTpr_Postulacionesfechatrabajo = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "PostulacionesFechaCierre" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Postulacionesfechacierre
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Postulacionesfechacierre) ;
         }

         set {
            sdt.gxTpr_Postulacionesfechacierre = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "PostulacionesHoraCierre" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Postulacioneshoracierre
      {
         get {
            return sdt.gxTpr_Postulacioneshoracierre ;
         }

         set {
            sdt.gxTpr_Postulacioneshoracierre = value;
         }

      }

      [DataMember( Name = "PostulacionesTipoFecha" , Order = 17 )]
      [GxSeudo()]
      public string gxTpr_Postulacionestipofecha
      {
         get {
            return sdt.gxTpr_Postulacionestipofecha ;
         }

         set {
            sdt.gxTpr_Postulacionestipofecha = value;
         }

      }

      [DataMember( Name = "PostulacionesRgoHoraservicio" , Order = 18 )]
      [GxSeudo()]
      public string gxTpr_Postulacionesrgohoraservicio
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Postulacionesrgohoraservicio) ;
         }

         set {
            sdt.gxTpr_Postulacionesrgohoraservicio = value;
         }

      }

      [DataMember( Name = "PostulacionesApellidoNombre" , Order = 19 )]
      [GxSeudo()]
      public string gxTpr_Postulacionesapellidonombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Postulacionesapellidonombre) ;
         }

         set {
            sdt.gxTpr_Postulacionesapellidonombre = value;
         }

      }

      [DataMember( Name = "PostulacionesMail" , Order = 20 )]
      [GxSeudo()]
      public string gxTpr_Postulacionesmail
      {
         get {
            return sdt.gxTpr_Postulacionesmail ;
         }

         set {
            sdt.gxTpr_Postulacionesmail = value;
         }

      }

      [DataMember( Name = "PostulacionesTelefono" , Order = 21 )]
      [GxSeudo()]
      public string gxTpr_Postulacionestelefono
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Postulacionestelefono) ;
         }

         set {
            sdt.gxTpr_Postulacionestelefono = value;
         }

      }

      [DataMember( Name = "PostulacionesDepartamentoId" , Order = 22 )]
      [GxSeudo()]
      public string gxTpr_Postulacionesdepartamentoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Postulacionesdepartamentoid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Postulacionesdepartamentoid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PostulacionesDepartamentoMunicipioId" , Order = 23 )]
      [GxSeudo()]
      public string gxTpr_Postulacionesdepartamentomunicipioid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Postulacionesdepartamentomunicipioid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Postulacionesdepartamentomunicipioid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PostulacionesZonasID" , Order = 24 )]
      [GxSeudo()]
      public string gxTpr_Postulacioneszonasid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Postulacioneszonasid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Postulacioneszonasid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PostulacionesDireccion" , Order = 25 )]
      [GxSeudo()]
      public string gxTpr_Postulacionesdireccion
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Postulacionesdireccion) ;
         }

         set {
            sdt.gxTpr_Postulacionesdireccion = value;
         }

      }

      [DataMember( Name = "Profesionales" , Order = 26 )]
      public GxGenericCollection<SdtPostulaciones_Profesionales_RESTInterface> gxTpr_Profesionales
      {
         get {
            return new GxGenericCollection<SdtPostulaciones_Profesionales_RESTInterface>(sdt.gxTpr_Profesionales) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Profesionales);
         }

      }

      [DataMember( Name = "PostulacionesFechaAlta" , Order = 27 )]
      [GxSeudo()]
      public string gxTpr_Postulacionesfechaalta
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Postulacionesfechaalta, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Postulacionesfechaalta = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "PostulacionesEstado" , Order = 28 )]
      [GxSeudo()]
      public string gxTpr_Postulacionesestado
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Postulacionesestado) ;
         }

         set {
            sdt.gxTpr_Postulacionesestado = value;
         }

      }

      [DataMember( Name = "PostulacionesSecUserId" , Order = 29 )]
      [GxSeudo()]
      public string gxTpr_Postulacionessecuserid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Postulacionessecuserid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Postulacionessecuserid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      public SdtPostulaciones sdt
      {
         get {
            return (SdtPostulaciones)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtPostulaciones() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 30 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"Postulaciones", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtPostulaciones_RESTLInterface : GxGenericCollectionItem<SdtPostulaciones>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtPostulaciones_RESTLInterface( ) : base()
      {
      }

      public SdtPostulaciones_RESTLInterface( SdtPostulaciones psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PostulacionesProvNombreAux" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Postulacionesprovnombreaux
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Postulacionesprovnombreaux) ;
         }

         set {
            sdt.gxTpr_Postulacionesprovnombreaux = value;
         }

      }

      [DataMember( Name = "uri" , Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtPostulaciones sdt
      {
         get {
            return (SdtPostulaciones)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtPostulaciones() ;
         }
      }

   }

}
