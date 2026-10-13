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
   [XmlRoot(ElementName = "Solicitudes" )]
   [XmlType(TypeName =  "Solicitudes" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtSolicitudes : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtSolicitudes( )
      {
      }

      public SdtSolicitudes( IGxContext context )
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

      public void Load( long AV127SolicitudesID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV127SolicitudesID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"SolicitudesID", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Solicitudes");
         metadata.Set("BT", "Solicitudes");
         metadata.Set("PK", "[ \"SolicitudesID\" ]");
         metadata.Set("PKAssigned", "[ \"SolicitudesID\" ]");
         metadata.Set("Levels", "[ \"Archivo\",\"Items\" ]");
         metadata.Set("Serial", "[ [ \"Same\",\"Solicitudes\",\"SolicitudesAutoEnumerar\",\"SolicitudesItemsID\",\"SolicitudesID\",\"SolicitudesID\" ],[ \"Same\",\"Solicitudes\",\"SolicitudesSerialArchivo\",\"ArchivoId\",\"SolicitudesID\",\"SolicitudesID\" ] ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"CancelacionTipificacionId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"CuponId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"DepartamentoId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"DepartamentoId\",\"DepartamentoMunicipioId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"EstadosTipo\",\"EstadosGenericosId\" ],\"FKMap\":[ \"EstadosSolTipo-EstadosTipo\",\"EstadosSolId-EstadosGenericosId\" ] },{ \"FK\":[ \"MetodoPagosID\" ],\"FKMap\":[  ] },{ \"FK\":[ \"MonedaId\" ],\"FKMap\":[ \"STMonedasId-MonedaId\" ] },{ \"FK\":[ \"MudanzaId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"PostulacionesId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ProveedorID\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ProveedorID\" ],\"FKMap\":[ \"STComerciosID-ProveedorID\" ] },{ \"FK\":[ \"TicketId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ZonasID\",\"DepartamentoId\",\"DepartamentoMunicipioId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Solicitudesid_Z");
         state.Add("gxTpr_Solicitudesnombre_Z");
         state.Add("gxTpr_Solicitudestelefono_Z");
         state.Add("gxTpr_Solicitudesmail_Z");
         state.Add("gxTpr_Paisid_Z");
         state.Add("gxTpr_Departamentoid_Z");
         state.Add("gxTpr_Departamentomunicipioid_Z");
         state.Add("gxTpr_Zonasid_Z");
         state.Add("gxTpr_Solicitudesdireccion_Z");
         state.Add("gxTpr_Solicitudesautoenumerar_Z");
         state.Add("gxTpr_Stmonedasid_Z");
         state.Add("gxTpr_Stmonedasiso_Z");
         state.Add("gxTpr_Solicitudesliqprof_Z");
         state.Add("gxTpr_Solicitudesliqprov_Z");
         state.Add("gxTpr_Solicitudescotizacion_Z");
         state.Add("gxTpr_Solicitudestotal_Z");
         state.Add("gxTpr_Solicitudserviciosolcoti_Z");
         state.Add("gxTpr_Solicitudserviciopfinal_Z");
         state.Add("gxTpr_Solicitudesdescuento_Z");
         state.Add("gxTpr_Cuponid_Z");
         state.Add("gxTpr_Cuponpercent_Z");
         state.Add("gxTpr_Solicitudesdescuentocupon_Z");
         state.Add("gxTpr_Solicitudescomisionmetodopago_Z");
         state.Add("gxTpr_Estadossoltipo_Z");
         state.Add("gxTpr_Estadossolid_Z");
         state.Add("gxTpr_Estadossolnombre_Z");
         state.Add("gxTpr_Solicitudesotros1_Z");
         state.Add("gxTpr_Solicitudesotros2_Z");
         state.Add("gxTpr_Solicitudesotros3_Z");
         state.Add("gxTpr_Solicitudesusralta_Z");
         state.Add("gxTpr_Solicitudesusractualizacion_Z");
         state.Add("gxTpr_Solicitudesfechaalta_Z_Nullable");
         state.Add("gxTpr_Solicitudesfechaactualizacion_Z_Nullable");
         state.Add("gxTpr_Solicitudesfechainstalacion_Z_Nullable");
         state.Add("gxTpr_Solicitudeshorainstalacion_Z");
         state.Add("gxTpr_Metodopagosid_Z");
         state.Add("gxTpr_Metodopagosnombre_Z");
         state.Add("gxTpr_Solicitudesnota_Z");
         state.Add("gxTpr_Solicitudesnotificacion_Z");
         state.Add("gxTpr_Proveedorid_Z");
         state.Add("gxTpr_Proveedornombre_Z");
         state.Add("gxTpr_Proveedorpagodefault_Z");
         state.Add("gxTpr_Stcomerciosid_Z");
         state.Add("gxTpr_Stcomerciosnombre_Z");
         state.Add("gxTpr_Stcomerciosestado_Z");
         state.Add("gxTpr_Solicitudservicioorigenpago_Z");
         state.Add("gxTpr_Solicitudespagado_Z");
         state.Add("gxTpr_Solicitudserviciocomprov_Z");
         state.Add("gxTpr_Solicitudserviciocomprovp_Z");
         state.Add("gxTpr_Solicitudserviciocomalm_Z");
         state.Add("gxTpr_Solicitudserviciocomalmp_Z");
         state.Add("gxTpr_Solicitudserviciocompro_Z");
         state.Add("gxTpr_Solicitudserviciocomprop_Z");
         state.Add("gxTpr_Solicitudescalcomi_Z");
         state.Add("gxTpr_Proveedornombreaux_Z");
         state.Add("gxTpr_Solicitudessubtipo_Z");
         state.Add("gxTpr_Solicitudescostoxzona_Z");
         state.Add("gxTpr_Solicitudescostoxzcomalm_Z");
         state.Add("gxTpr_Solicitudescostoxzcomalmp_Z");
         state.Add("gxTpr_Solicitudescostoxzcomprof_Z");
         state.Add("gxTpr_Solicitudescostoxzcomprofp_Z");
         state.Add("gxTpr_Mudanzaid_Z");
         state.Add("gxTpr_Mudanzafechaservicio_Z_Nullable");
         state.Add("gxTpr_Mudanzadireccionorigen_Z");
         state.Add("gxTpr_Mudanzadirecciondestino_Z");
         state.Add("gxTpr_Postulacionesid_Z");
         state.Add("gxTpr_Solicitudesduplicado_Z");
         state.Add("gxTpr_Solicitudesserialarchivo_Z");
         state.Add("gxTpr_Cancelaciontipificacionid_Z");
         state.Add("gxTpr_Cancelaciontipificaciondescripcion_Z");
         state.Add("gxTpr_Solicitudescostopresupuesto_Z");
         state.Add("gxTpr_Solicitudesurlorigen_Z");
         state.Add("gxTpr_Ticketid_Z");
         state.Add("gxTpr_Ticketmotivoid_Z");
         state.Add("gxTpr_Ticketmotivodescripcion_Z");
         state.Add("gxTpr_Ticketcomentario_Z");
         state.Add("gxTpr_Ticketadjunto_Z");
         state.Add("gxTpr_Ticketestado_Z");
         state.Add("gxTpr_Ticketsolicitudid_Z");
         state.Add("gxTpr_Solicitudesmail_N");
         state.Add("gxTpr_Departamentoid_N");
         state.Add("gxTpr_Departamentomunicipioid_N");
         state.Add("gxTpr_Zonasid_N");
         state.Add("gxTpr_Stmonedasid_N");
         state.Add("gxTpr_Solicitudesliqprof_N");
         state.Add("gxTpr_Solicitudesliqprov_N");
         state.Add("gxTpr_Solicitudesdescuento_N");
         state.Add("gxTpr_Cuponid_N");
         state.Add("gxTpr_Solicitudesusralta_N");
         state.Add("gxTpr_Solicitudesusractualizacion_N");
         state.Add("gxTpr_Solicitudesfechaalta_N");
         state.Add("gxTpr_Solicitudesfechaactualizacion_N");
         state.Add("gxTpr_Stcomerciosid_N");
         state.Add("gxTpr_Solicitudservicioorigenpago_N");
         state.Add("gxTpr_Solicitudespagado_N");
         state.Add("gxTpr_Solicitudserviciocomprov_N");
         state.Add("gxTpr_Solicitudserviciocomprovp_N");
         state.Add("gxTpr_Solicitudserviciocomalm_N");
         state.Add("gxTpr_Solicitudserviciocomalmp_N");
         state.Add("gxTpr_Proveedornombreaux_N");
         state.Add("gxTpr_Solicitudessubtipo_N");
         state.Add("gxTpr_Solicitudescostoxzcomalm_N");
         state.Add("gxTpr_Solicitudescostoxzcomalmp_N");
         state.Add("gxTpr_Mudanzaid_N");
         state.Add("gxTpr_Postulacionesid_N");
         state.Add("gxTpr_Solicitudesduplicado_N");
         state.Add("gxTpr_Solicitudescostopresupuesto_N");
         state.Add("gxTpr_Solicitudesurlorigen_N");
         state.Add("gxTpr_Ticketid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtSolicitudes sdt;
         sdt = (SdtSolicitudes)(source);
         gxTv_SdtSolicitudes_Solicitudesid = sdt.gxTv_SdtSolicitudes_Solicitudesid ;
         gxTv_SdtSolicitudes_Solicitudesnombre = sdt.gxTv_SdtSolicitudes_Solicitudesnombre ;
         gxTv_SdtSolicitudes_Solicitudestelefono = sdt.gxTv_SdtSolicitudes_Solicitudestelefono ;
         gxTv_SdtSolicitudes_Solicitudesmail = sdt.gxTv_SdtSolicitudes_Solicitudesmail ;
         gxTv_SdtSolicitudes_Paisid = sdt.gxTv_SdtSolicitudes_Paisid ;
         gxTv_SdtSolicitudes_Departamentoid = sdt.gxTv_SdtSolicitudes_Departamentoid ;
         gxTv_SdtSolicitudes_Departamentomunicipioid = sdt.gxTv_SdtSolicitudes_Departamentomunicipioid ;
         gxTv_SdtSolicitudes_Zonasid = sdt.gxTv_SdtSolicitudes_Zonasid ;
         gxTv_SdtSolicitudes_Solicitudesdireccion = sdt.gxTv_SdtSolicitudes_Solicitudesdireccion ;
         gxTv_SdtSolicitudes_Solicitudesautoenumerar = sdt.gxTv_SdtSolicitudes_Solicitudesautoenumerar ;
         gxTv_SdtSolicitudes_Stmonedasid = sdt.gxTv_SdtSolicitudes_Stmonedasid ;
         gxTv_SdtSolicitudes_Stmonedasiso = sdt.gxTv_SdtSolicitudes_Stmonedasiso ;
         gxTv_SdtSolicitudes_Solicitudesliqprof = sdt.gxTv_SdtSolicitudes_Solicitudesliqprof ;
         gxTv_SdtSolicitudes_Solicitudesliqprov = sdt.gxTv_SdtSolicitudes_Solicitudesliqprov ;
         gxTv_SdtSolicitudes_Items = sdt.gxTv_SdtSolicitudes_Items ;
         gxTv_SdtSolicitudes_Solicitudescotizacion = sdt.gxTv_SdtSolicitudes_Solicitudescotizacion ;
         gxTv_SdtSolicitudes_Solicitudestotal = sdt.gxTv_SdtSolicitudes_Solicitudestotal ;
         gxTv_SdtSolicitudes_Solicitudserviciosolcoti = sdt.gxTv_SdtSolicitudes_Solicitudserviciosolcoti ;
         gxTv_SdtSolicitudes_Solicitudserviciopfinal = sdt.gxTv_SdtSolicitudes_Solicitudserviciopfinal ;
         gxTv_SdtSolicitudes_Solicitudesdescuento = sdt.gxTv_SdtSolicitudes_Solicitudesdescuento ;
         gxTv_SdtSolicitudes_Cuponid = sdt.gxTv_SdtSolicitudes_Cuponid ;
         gxTv_SdtSolicitudes_Cuponpercent = sdt.gxTv_SdtSolicitudes_Cuponpercent ;
         gxTv_SdtSolicitudes_Solicitudesdescuentocupon = sdt.gxTv_SdtSolicitudes_Solicitudesdescuentocupon ;
         gxTv_SdtSolicitudes_Solicitudescomisionmetodopago = sdt.gxTv_SdtSolicitudes_Solicitudescomisionmetodopago ;
         gxTv_SdtSolicitudes_Estadossoltipo = sdt.gxTv_SdtSolicitudes_Estadossoltipo ;
         gxTv_SdtSolicitudes_Estadossolid = sdt.gxTv_SdtSolicitudes_Estadossolid ;
         gxTv_SdtSolicitudes_Estadossolnombre = sdt.gxTv_SdtSolicitudes_Estadossolnombre ;
         gxTv_SdtSolicitudes_Solicitudesotros1 = sdt.gxTv_SdtSolicitudes_Solicitudesotros1 ;
         gxTv_SdtSolicitudes_Solicitudesotros2 = sdt.gxTv_SdtSolicitudes_Solicitudesotros2 ;
         gxTv_SdtSolicitudes_Solicitudesotros3 = sdt.gxTv_SdtSolicitudes_Solicitudesotros3 ;
         gxTv_SdtSolicitudes_Solicitudesusralta = sdt.gxTv_SdtSolicitudes_Solicitudesusralta ;
         gxTv_SdtSolicitudes_Solicitudesusractualizacion = sdt.gxTv_SdtSolicitudes_Solicitudesusractualizacion ;
         gxTv_SdtSolicitudes_Solicitudesfechaalta = sdt.gxTv_SdtSolicitudes_Solicitudesfechaalta ;
         gxTv_SdtSolicitudes_Solicitudesfechaactualizacion = sdt.gxTv_SdtSolicitudes_Solicitudesfechaactualizacion ;
         gxTv_SdtSolicitudes_Solicitudesfechainstalacion = sdt.gxTv_SdtSolicitudes_Solicitudesfechainstalacion ;
         gxTv_SdtSolicitudes_Solicitudeshorainstalacion = sdt.gxTv_SdtSolicitudes_Solicitudeshorainstalacion ;
         gxTv_SdtSolicitudes_Solicitudescomentario = sdt.gxTv_SdtSolicitudes_Solicitudescomentario ;
         gxTv_SdtSolicitudes_Metodopagosid = sdt.gxTv_SdtSolicitudes_Metodopagosid ;
         gxTv_SdtSolicitudes_Metodopagosnombre = sdt.gxTv_SdtSolicitudes_Metodopagosnombre ;
         gxTv_SdtSolicitudes_Solicitudesnota = sdt.gxTv_SdtSolicitudes_Solicitudesnota ;
         gxTv_SdtSolicitudes_Solicitudesnotificacion = sdt.gxTv_SdtSolicitudes_Solicitudesnotificacion ;
         gxTv_SdtSolicitudes_Proveedorid = sdt.gxTv_SdtSolicitudes_Proveedorid ;
         gxTv_SdtSolicitudes_Proveedornombre = sdt.gxTv_SdtSolicitudes_Proveedornombre ;
         gxTv_SdtSolicitudes_Proveedorpagodefault = sdt.gxTv_SdtSolicitudes_Proveedorpagodefault ;
         gxTv_SdtSolicitudes_Stcomerciosid = sdt.gxTv_SdtSolicitudes_Stcomerciosid ;
         gxTv_SdtSolicitudes_Stcomerciosnombre = sdt.gxTv_SdtSolicitudes_Stcomerciosnombre ;
         gxTv_SdtSolicitudes_Stcomerciosestado = sdt.gxTv_SdtSolicitudes_Stcomerciosestado ;
         gxTv_SdtSolicitudes_Solicitudservicioorigenpago = sdt.gxTv_SdtSolicitudes_Solicitudservicioorigenpago ;
         gxTv_SdtSolicitudes_Solicitudespagado = sdt.gxTv_SdtSolicitudes_Solicitudespagado ;
         gxTv_SdtSolicitudes_Solicitudserviciocomprov = sdt.gxTv_SdtSolicitudes_Solicitudserviciocomprov ;
         gxTv_SdtSolicitudes_Solicitudserviciocomprovp = sdt.gxTv_SdtSolicitudes_Solicitudserviciocomprovp ;
         gxTv_SdtSolicitudes_Solicitudserviciocomalm = sdt.gxTv_SdtSolicitudes_Solicitudserviciocomalm ;
         gxTv_SdtSolicitudes_Solicitudserviciocomalmp = sdt.gxTv_SdtSolicitudes_Solicitudserviciocomalmp ;
         gxTv_SdtSolicitudes_Solicitudserviciocompro = sdt.gxTv_SdtSolicitudes_Solicitudserviciocompro ;
         gxTv_SdtSolicitudes_Solicitudserviciocomprop = sdt.gxTv_SdtSolicitudes_Solicitudserviciocomprop ;
         gxTv_SdtSolicitudes_Solicitudescalcomi = sdt.gxTv_SdtSolicitudes_Solicitudescalcomi ;
         gxTv_SdtSolicitudes_Proveedornombreaux = sdt.gxTv_SdtSolicitudes_Proveedornombreaux ;
         gxTv_SdtSolicitudes_Solicitudessubtipo = sdt.gxTv_SdtSolicitudes_Solicitudessubtipo ;
         gxTv_SdtSolicitudes_Solicitudescostoxzona = sdt.gxTv_SdtSolicitudes_Solicitudescostoxzona ;
         gxTv_SdtSolicitudes_Solicitudescostoxzcomalm = sdt.gxTv_SdtSolicitudes_Solicitudescostoxzcomalm ;
         gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp = sdt.gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp ;
         gxTv_SdtSolicitudes_Solicitudescostoxzcomprof = sdt.gxTv_SdtSolicitudes_Solicitudescostoxzcomprof ;
         gxTv_SdtSolicitudes_Solicitudescostoxzcomprofp = sdt.gxTv_SdtSolicitudes_Solicitudescostoxzcomprofp ;
         gxTv_SdtSolicitudes_Mudanzaid = sdt.gxTv_SdtSolicitudes_Mudanzaid ;
         gxTv_SdtSolicitudes_Mudanzafechaservicio = sdt.gxTv_SdtSolicitudes_Mudanzafechaservicio ;
         gxTv_SdtSolicitudes_Mudanzadireccionorigen = sdt.gxTv_SdtSolicitudes_Mudanzadireccionorigen ;
         gxTv_SdtSolicitudes_Mudanzadirecciondestino = sdt.gxTv_SdtSolicitudes_Mudanzadirecciondestino ;
         gxTv_SdtSolicitudes_Postulacionesid = sdt.gxTv_SdtSolicitudes_Postulacionesid ;
         gxTv_SdtSolicitudes_Solicitudesduplicado = sdt.gxTv_SdtSolicitudes_Solicitudesduplicado ;
         gxTv_SdtSolicitudes_Solicitudesserialarchivo = sdt.gxTv_SdtSolicitudes_Solicitudesserialarchivo ;
         gxTv_SdtSolicitudes_Cancelaciontipificacionid = sdt.gxTv_SdtSolicitudes_Cancelaciontipificacionid ;
         gxTv_SdtSolicitudes_Cancelaciontipificaciondescripcion = sdt.gxTv_SdtSolicitudes_Cancelaciontipificaciondescripcion ;
         gxTv_SdtSolicitudes_Solicitudescostopresupuesto = sdt.gxTv_SdtSolicitudes_Solicitudescostopresupuesto ;
         gxTv_SdtSolicitudes_Solicitudesurlorigen = sdt.gxTv_SdtSolicitudes_Solicitudesurlorigen ;
         gxTv_SdtSolicitudes_Ticketid = sdt.gxTv_SdtSolicitudes_Ticketid ;
         gxTv_SdtSolicitudes_Ticketmotivoid = sdt.gxTv_SdtSolicitudes_Ticketmotivoid ;
         gxTv_SdtSolicitudes_Ticketmotivodescripcion = sdt.gxTv_SdtSolicitudes_Ticketmotivodescripcion ;
         gxTv_SdtSolicitudes_Ticketcomentario = sdt.gxTv_SdtSolicitudes_Ticketcomentario ;
         gxTv_SdtSolicitudes_Ticketadjunto = sdt.gxTv_SdtSolicitudes_Ticketadjunto ;
         gxTv_SdtSolicitudes_Ticketestado = sdt.gxTv_SdtSolicitudes_Ticketestado ;
         gxTv_SdtSolicitudes_Ticketsolicitudid = sdt.gxTv_SdtSolicitudes_Ticketsolicitudid ;
         gxTv_SdtSolicitudes_Archivo = sdt.gxTv_SdtSolicitudes_Archivo ;
         gxTv_SdtSolicitudes_Mode = sdt.gxTv_SdtSolicitudes_Mode ;
         gxTv_SdtSolicitudes_Initialized = sdt.gxTv_SdtSolicitudes_Initialized ;
         gxTv_SdtSolicitudes_Solicitudesid_Z = sdt.gxTv_SdtSolicitudes_Solicitudesid_Z ;
         gxTv_SdtSolicitudes_Solicitudesnombre_Z = sdt.gxTv_SdtSolicitudes_Solicitudesnombre_Z ;
         gxTv_SdtSolicitudes_Solicitudestelefono_Z = sdt.gxTv_SdtSolicitudes_Solicitudestelefono_Z ;
         gxTv_SdtSolicitudes_Solicitudesmail_Z = sdt.gxTv_SdtSolicitudes_Solicitudesmail_Z ;
         gxTv_SdtSolicitudes_Paisid_Z = sdt.gxTv_SdtSolicitudes_Paisid_Z ;
         gxTv_SdtSolicitudes_Departamentoid_Z = sdt.gxTv_SdtSolicitudes_Departamentoid_Z ;
         gxTv_SdtSolicitudes_Departamentomunicipioid_Z = sdt.gxTv_SdtSolicitudes_Departamentomunicipioid_Z ;
         gxTv_SdtSolicitudes_Zonasid_Z = sdt.gxTv_SdtSolicitudes_Zonasid_Z ;
         gxTv_SdtSolicitudes_Solicitudesdireccion_Z = sdt.gxTv_SdtSolicitudes_Solicitudesdireccion_Z ;
         gxTv_SdtSolicitudes_Solicitudesautoenumerar_Z = sdt.gxTv_SdtSolicitudes_Solicitudesautoenumerar_Z ;
         gxTv_SdtSolicitudes_Stmonedasid_Z = sdt.gxTv_SdtSolicitudes_Stmonedasid_Z ;
         gxTv_SdtSolicitudes_Stmonedasiso_Z = sdt.gxTv_SdtSolicitudes_Stmonedasiso_Z ;
         gxTv_SdtSolicitudes_Solicitudesliqprof_Z = sdt.gxTv_SdtSolicitudes_Solicitudesliqprof_Z ;
         gxTv_SdtSolicitudes_Solicitudesliqprov_Z = sdt.gxTv_SdtSolicitudes_Solicitudesliqprov_Z ;
         gxTv_SdtSolicitudes_Solicitudescotizacion_Z = sdt.gxTv_SdtSolicitudes_Solicitudescotizacion_Z ;
         gxTv_SdtSolicitudes_Solicitudestotal_Z = sdt.gxTv_SdtSolicitudes_Solicitudestotal_Z ;
         gxTv_SdtSolicitudes_Solicitudserviciosolcoti_Z = sdt.gxTv_SdtSolicitudes_Solicitudserviciosolcoti_Z ;
         gxTv_SdtSolicitudes_Solicitudserviciopfinal_Z = sdt.gxTv_SdtSolicitudes_Solicitudserviciopfinal_Z ;
         gxTv_SdtSolicitudes_Solicitudesdescuento_Z = sdt.gxTv_SdtSolicitudes_Solicitudesdescuento_Z ;
         gxTv_SdtSolicitudes_Cuponid_Z = sdt.gxTv_SdtSolicitudes_Cuponid_Z ;
         gxTv_SdtSolicitudes_Cuponpercent_Z = sdt.gxTv_SdtSolicitudes_Cuponpercent_Z ;
         gxTv_SdtSolicitudes_Solicitudesdescuentocupon_Z = sdt.gxTv_SdtSolicitudes_Solicitudesdescuentocupon_Z ;
         gxTv_SdtSolicitudes_Solicitudescomisionmetodopago_Z = sdt.gxTv_SdtSolicitudes_Solicitudescomisionmetodopago_Z ;
         gxTv_SdtSolicitudes_Estadossoltipo_Z = sdt.gxTv_SdtSolicitudes_Estadossoltipo_Z ;
         gxTv_SdtSolicitudes_Estadossolid_Z = sdt.gxTv_SdtSolicitudes_Estadossolid_Z ;
         gxTv_SdtSolicitudes_Estadossolnombre_Z = sdt.gxTv_SdtSolicitudes_Estadossolnombre_Z ;
         gxTv_SdtSolicitudes_Solicitudesotros1_Z = sdt.gxTv_SdtSolicitudes_Solicitudesotros1_Z ;
         gxTv_SdtSolicitudes_Solicitudesotros2_Z = sdt.gxTv_SdtSolicitudes_Solicitudesotros2_Z ;
         gxTv_SdtSolicitudes_Solicitudesotros3_Z = sdt.gxTv_SdtSolicitudes_Solicitudesotros3_Z ;
         gxTv_SdtSolicitudes_Solicitudesusralta_Z = sdt.gxTv_SdtSolicitudes_Solicitudesusralta_Z ;
         gxTv_SdtSolicitudes_Solicitudesusractualizacion_Z = sdt.gxTv_SdtSolicitudes_Solicitudesusractualizacion_Z ;
         gxTv_SdtSolicitudes_Solicitudesfechaalta_Z = sdt.gxTv_SdtSolicitudes_Solicitudesfechaalta_Z ;
         gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_Z = sdt.gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_Z ;
         gxTv_SdtSolicitudes_Solicitudesfechainstalacion_Z = sdt.gxTv_SdtSolicitudes_Solicitudesfechainstalacion_Z ;
         gxTv_SdtSolicitudes_Solicitudeshorainstalacion_Z = sdt.gxTv_SdtSolicitudes_Solicitudeshorainstalacion_Z ;
         gxTv_SdtSolicitudes_Metodopagosid_Z = sdt.gxTv_SdtSolicitudes_Metodopagosid_Z ;
         gxTv_SdtSolicitudes_Metodopagosnombre_Z = sdt.gxTv_SdtSolicitudes_Metodopagosnombre_Z ;
         gxTv_SdtSolicitudes_Solicitudesnota_Z = sdt.gxTv_SdtSolicitudes_Solicitudesnota_Z ;
         gxTv_SdtSolicitudes_Solicitudesnotificacion_Z = sdt.gxTv_SdtSolicitudes_Solicitudesnotificacion_Z ;
         gxTv_SdtSolicitudes_Proveedorid_Z = sdt.gxTv_SdtSolicitudes_Proveedorid_Z ;
         gxTv_SdtSolicitudes_Proveedornombre_Z = sdt.gxTv_SdtSolicitudes_Proveedornombre_Z ;
         gxTv_SdtSolicitudes_Proveedorpagodefault_Z = sdt.gxTv_SdtSolicitudes_Proveedorpagodefault_Z ;
         gxTv_SdtSolicitudes_Stcomerciosid_Z = sdt.gxTv_SdtSolicitudes_Stcomerciosid_Z ;
         gxTv_SdtSolicitudes_Stcomerciosnombre_Z = sdt.gxTv_SdtSolicitudes_Stcomerciosnombre_Z ;
         gxTv_SdtSolicitudes_Stcomerciosestado_Z = sdt.gxTv_SdtSolicitudes_Stcomerciosestado_Z ;
         gxTv_SdtSolicitudes_Solicitudservicioorigenpago_Z = sdt.gxTv_SdtSolicitudes_Solicitudservicioorigenpago_Z ;
         gxTv_SdtSolicitudes_Solicitudespagado_Z = sdt.gxTv_SdtSolicitudes_Solicitudespagado_Z ;
         gxTv_SdtSolicitudes_Solicitudserviciocomprov_Z = sdt.gxTv_SdtSolicitudes_Solicitudserviciocomprov_Z ;
         gxTv_SdtSolicitudes_Solicitudserviciocomprovp_Z = sdt.gxTv_SdtSolicitudes_Solicitudserviciocomprovp_Z ;
         gxTv_SdtSolicitudes_Solicitudserviciocomalm_Z = sdt.gxTv_SdtSolicitudes_Solicitudserviciocomalm_Z ;
         gxTv_SdtSolicitudes_Solicitudserviciocomalmp_Z = sdt.gxTv_SdtSolicitudes_Solicitudserviciocomalmp_Z ;
         gxTv_SdtSolicitudes_Solicitudserviciocompro_Z = sdt.gxTv_SdtSolicitudes_Solicitudserviciocompro_Z ;
         gxTv_SdtSolicitudes_Solicitudserviciocomprop_Z = sdt.gxTv_SdtSolicitudes_Solicitudserviciocomprop_Z ;
         gxTv_SdtSolicitudes_Solicitudescalcomi_Z = sdt.gxTv_SdtSolicitudes_Solicitudescalcomi_Z ;
         gxTv_SdtSolicitudes_Proveedornombreaux_Z = sdt.gxTv_SdtSolicitudes_Proveedornombreaux_Z ;
         gxTv_SdtSolicitudes_Solicitudessubtipo_Z = sdt.gxTv_SdtSolicitudes_Solicitudessubtipo_Z ;
         gxTv_SdtSolicitudes_Solicitudescostoxzona_Z = sdt.gxTv_SdtSolicitudes_Solicitudescostoxzona_Z ;
         gxTv_SdtSolicitudes_Solicitudescostoxzcomalm_Z = sdt.gxTv_SdtSolicitudes_Solicitudescostoxzcomalm_Z ;
         gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp_Z = sdt.gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp_Z ;
         gxTv_SdtSolicitudes_Solicitudescostoxzcomprof_Z = sdt.gxTv_SdtSolicitudes_Solicitudescostoxzcomprof_Z ;
         gxTv_SdtSolicitudes_Solicitudescostoxzcomprofp_Z = sdt.gxTv_SdtSolicitudes_Solicitudescostoxzcomprofp_Z ;
         gxTv_SdtSolicitudes_Mudanzaid_Z = sdt.gxTv_SdtSolicitudes_Mudanzaid_Z ;
         gxTv_SdtSolicitudes_Mudanzafechaservicio_Z = sdt.gxTv_SdtSolicitudes_Mudanzafechaservicio_Z ;
         gxTv_SdtSolicitudes_Mudanzadireccionorigen_Z = sdt.gxTv_SdtSolicitudes_Mudanzadireccionorigen_Z ;
         gxTv_SdtSolicitudes_Mudanzadirecciondestino_Z = sdt.gxTv_SdtSolicitudes_Mudanzadirecciondestino_Z ;
         gxTv_SdtSolicitudes_Postulacionesid_Z = sdt.gxTv_SdtSolicitudes_Postulacionesid_Z ;
         gxTv_SdtSolicitudes_Solicitudesduplicado_Z = sdt.gxTv_SdtSolicitudes_Solicitudesduplicado_Z ;
         gxTv_SdtSolicitudes_Solicitudesserialarchivo_Z = sdt.gxTv_SdtSolicitudes_Solicitudesserialarchivo_Z ;
         gxTv_SdtSolicitudes_Cancelaciontipificacionid_Z = sdt.gxTv_SdtSolicitudes_Cancelaciontipificacionid_Z ;
         gxTv_SdtSolicitudes_Cancelaciontipificaciondescripcion_Z = sdt.gxTv_SdtSolicitudes_Cancelaciontipificaciondescripcion_Z ;
         gxTv_SdtSolicitudes_Solicitudescostopresupuesto_Z = sdt.gxTv_SdtSolicitudes_Solicitudescostopresupuesto_Z ;
         gxTv_SdtSolicitudes_Solicitudesurlorigen_Z = sdt.gxTv_SdtSolicitudes_Solicitudesurlorigen_Z ;
         gxTv_SdtSolicitudes_Ticketid_Z = sdt.gxTv_SdtSolicitudes_Ticketid_Z ;
         gxTv_SdtSolicitudes_Ticketmotivoid_Z = sdt.gxTv_SdtSolicitudes_Ticketmotivoid_Z ;
         gxTv_SdtSolicitudes_Ticketmotivodescripcion_Z = sdt.gxTv_SdtSolicitudes_Ticketmotivodescripcion_Z ;
         gxTv_SdtSolicitudes_Ticketcomentario_Z = sdt.gxTv_SdtSolicitudes_Ticketcomentario_Z ;
         gxTv_SdtSolicitudes_Ticketadjunto_Z = sdt.gxTv_SdtSolicitudes_Ticketadjunto_Z ;
         gxTv_SdtSolicitudes_Ticketestado_Z = sdt.gxTv_SdtSolicitudes_Ticketestado_Z ;
         gxTv_SdtSolicitudes_Ticketsolicitudid_Z = sdt.gxTv_SdtSolicitudes_Ticketsolicitudid_Z ;
         gxTv_SdtSolicitudes_Solicitudesmail_N = sdt.gxTv_SdtSolicitudes_Solicitudesmail_N ;
         gxTv_SdtSolicitudes_Departamentoid_N = sdt.gxTv_SdtSolicitudes_Departamentoid_N ;
         gxTv_SdtSolicitudes_Departamentomunicipioid_N = sdt.gxTv_SdtSolicitudes_Departamentomunicipioid_N ;
         gxTv_SdtSolicitudes_Zonasid_N = sdt.gxTv_SdtSolicitudes_Zonasid_N ;
         gxTv_SdtSolicitudes_Stmonedasid_N = sdt.gxTv_SdtSolicitudes_Stmonedasid_N ;
         gxTv_SdtSolicitudes_Solicitudesliqprof_N = sdt.gxTv_SdtSolicitudes_Solicitudesliqprof_N ;
         gxTv_SdtSolicitudes_Solicitudesliqprov_N = sdt.gxTv_SdtSolicitudes_Solicitudesliqprov_N ;
         gxTv_SdtSolicitudes_Solicitudesdescuento_N = sdt.gxTv_SdtSolicitudes_Solicitudesdescuento_N ;
         gxTv_SdtSolicitudes_Cuponid_N = sdt.gxTv_SdtSolicitudes_Cuponid_N ;
         gxTv_SdtSolicitudes_Solicitudesusralta_N = sdt.gxTv_SdtSolicitudes_Solicitudesusralta_N ;
         gxTv_SdtSolicitudes_Solicitudesusractualizacion_N = sdt.gxTv_SdtSolicitudes_Solicitudesusractualizacion_N ;
         gxTv_SdtSolicitudes_Solicitudesfechaalta_N = sdt.gxTv_SdtSolicitudes_Solicitudesfechaalta_N ;
         gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_N = sdt.gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_N ;
         gxTv_SdtSolicitudes_Stcomerciosid_N = sdt.gxTv_SdtSolicitudes_Stcomerciosid_N ;
         gxTv_SdtSolicitudes_Solicitudservicioorigenpago_N = sdt.gxTv_SdtSolicitudes_Solicitudservicioorigenpago_N ;
         gxTv_SdtSolicitudes_Solicitudespagado_N = sdt.gxTv_SdtSolicitudes_Solicitudespagado_N ;
         gxTv_SdtSolicitudes_Solicitudserviciocomprov_N = sdt.gxTv_SdtSolicitudes_Solicitudserviciocomprov_N ;
         gxTv_SdtSolicitudes_Solicitudserviciocomprovp_N = sdt.gxTv_SdtSolicitudes_Solicitudserviciocomprovp_N ;
         gxTv_SdtSolicitudes_Solicitudserviciocomalm_N = sdt.gxTv_SdtSolicitudes_Solicitudserviciocomalm_N ;
         gxTv_SdtSolicitudes_Solicitudserviciocomalmp_N = sdt.gxTv_SdtSolicitudes_Solicitudserviciocomalmp_N ;
         gxTv_SdtSolicitudes_Proveedornombreaux_N = sdt.gxTv_SdtSolicitudes_Proveedornombreaux_N ;
         gxTv_SdtSolicitudes_Solicitudessubtipo_N = sdt.gxTv_SdtSolicitudes_Solicitudessubtipo_N ;
         gxTv_SdtSolicitudes_Solicitudescostoxzcomalm_N = sdt.gxTv_SdtSolicitudes_Solicitudescostoxzcomalm_N ;
         gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp_N = sdt.gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp_N ;
         gxTv_SdtSolicitudes_Mudanzaid_N = sdt.gxTv_SdtSolicitudes_Mudanzaid_N ;
         gxTv_SdtSolicitudes_Postulacionesid_N = sdt.gxTv_SdtSolicitudes_Postulacionesid_N ;
         gxTv_SdtSolicitudes_Solicitudesduplicado_N = sdt.gxTv_SdtSolicitudes_Solicitudesduplicado_N ;
         gxTv_SdtSolicitudes_Solicitudescostopresupuesto_N = sdt.gxTv_SdtSolicitudes_Solicitudescostopresupuesto_N ;
         gxTv_SdtSolicitudes_Solicitudesurlorigen_N = sdt.gxTv_SdtSolicitudes_Solicitudesurlorigen_N ;
         gxTv_SdtSolicitudes_Ticketid_N = sdt.gxTv_SdtSolicitudes_Ticketid_N ;
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
         AddObjectProperty("SolicitudesID", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Solicitudesid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("SolicitudesNombre", gxTv_SdtSolicitudes_Solicitudesnombre, false, includeNonInitialized);
         AddObjectProperty("SolicitudesTelefono", gxTv_SdtSolicitudes_Solicitudestelefono, false, includeNonInitialized);
         AddObjectProperty("SolicitudesMail", gxTv_SdtSolicitudes_Solicitudesmail, false, includeNonInitialized);
         AddObjectProperty("SolicitudesMail_N", gxTv_SdtSolicitudes_Solicitudesmail_N, false, includeNonInitialized);
         AddObjectProperty("PaisID", gxTv_SdtSolicitudes_Paisid, false, includeNonInitialized);
         AddObjectProperty("DepartamentoId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Departamentoid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("DepartamentoId_N", gxTv_SdtSolicitudes_Departamentoid_N, false, includeNonInitialized);
         AddObjectProperty("DepartamentoMunicipioId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Departamentomunicipioid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("DepartamentoMunicipioId_N", gxTv_SdtSolicitudes_Departamentomunicipioid_N, false, includeNonInitialized);
         AddObjectProperty("ZonasID", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Zonasid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("ZonasID_N", gxTv_SdtSolicitudes_Zonasid_N, false, includeNonInitialized);
         AddObjectProperty("SolicitudesDireccion", gxTv_SdtSolicitudes_Solicitudesdireccion, false, includeNonInitialized);
         AddObjectProperty("SolicitudesAutoEnumerar", gxTv_SdtSolicitudes_Solicitudesautoenumerar, false, includeNonInitialized);
         AddObjectProperty("STMonedasId", gxTv_SdtSolicitudes_Stmonedasid, false, includeNonInitialized);
         AddObjectProperty("STMonedasId_N", gxTv_SdtSolicitudes_Stmonedasid_N, false, includeNonInitialized);
         AddObjectProperty("STMonedasISO", gxTv_SdtSolicitudes_Stmonedasiso, false, includeNonInitialized);
         AddObjectProperty("SolicitudesLiqProf", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Solicitudesliqprof), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("SolicitudesLiqProf_N", gxTv_SdtSolicitudes_Solicitudesliqprof_N, false, includeNonInitialized);
         AddObjectProperty("SolicitudesLiqProv", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Solicitudesliqprov), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("SolicitudesLiqProv_N", gxTv_SdtSolicitudes_Solicitudesliqprov_N, false, includeNonInitialized);
         if ( gxTv_SdtSolicitudes_Items != null )
         {
            AddObjectProperty("Items", gxTv_SdtSolicitudes_Items, includeState, includeNonInitialized);
         }
         AddObjectProperty("SolicitudesCotizacion", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Solicitudescotizacion, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("SolicitudesTotal", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Solicitudestotal, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("SolicitudServicioSolCoti", gxTv_SdtSolicitudes_Solicitudserviciosolcoti, false, includeNonInitialized);
         AddObjectProperty("SolicitudServicioPFinal", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Solicitudserviciopfinal, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("SolicitudesDescuento", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Solicitudesdescuento, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("SolicitudesDescuento_N", gxTv_SdtSolicitudes_Solicitudesdescuento_N, false, includeNonInitialized);
         AddObjectProperty("CuponId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Cuponid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("CuponId_N", gxTv_SdtSolicitudes_Cuponid_N, false, includeNonInitialized);
         AddObjectProperty("CuponPercent", gxTv_SdtSolicitudes_Cuponpercent, false, includeNonInitialized);
         AddObjectProperty("SolicitudesDescuentoCupon", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Solicitudesdescuentocupon, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("SolicitudesComisionMetodoPago", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Solicitudescomisionmetodopago, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("EstadosSolTipo", gxTv_SdtSolicitudes_Estadossoltipo, false, includeNonInitialized);
         AddObjectProperty("EstadosSolId", gxTv_SdtSolicitudes_Estadossolid, false, includeNonInitialized);
         AddObjectProperty("EstadosSolNombre", gxTv_SdtSolicitudes_Estadossolnombre, false, includeNonInitialized);
         AddObjectProperty("SolicitudesOtros1", gxTv_SdtSolicitudes_Solicitudesotros1, false, includeNonInitialized);
         AddObjectProperty("SolicitudesOtros2", gxTv_SdtSolicitudes_Solicitudesotros2, false, includeNonInitialized);
         AddObjectProperty("SolicitudesOtros3", gxTv_SdtSolicitudes_Solicitudesotros3, false, includeNonInitialized);
         AddObjectProperty("SolicitudesUsrAlta", gxTv_SdtSolicitudes_Solicitudesusralta, false, includeNonInitialized);
         AddObjectProperty("SolicitudesUsrAlta_N", gxTv_SdtSolicitudes_Solicitudesusralta_N, false, includeNonInitialized);
         AddObjectProperty("SolicitudesUsrActualizacion", gxTv_SdtSolicitudes_Solicitudesusractualizacion, false, includeNonInitialized);
         AddObjectProperty("SolicitudesUsrActualizacion_N", gxTv_SdtSolicitudes_Solicitudesusractualizacion_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtSolicitudes_Solicitudesfechaalta)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtSolicitudes_Solicitudesfechaalta)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtSolicitudes_Solicitudesfechaalta)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("SolicitudesFechaAlta", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("SolicitudesFechaAlta_N", gxTv_SdtSolicitudes_Solicitudesfechaalta_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtSolicitudes_Solicitudesfechaactualizacion;
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
         AddObjectProperty("SolicitudesFechaActualizacion", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("SolicitudesFechaActualizacion_N", gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtSolicitudes_Solicitudesfechainstalacion)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtSolicitudes_Solicitudesfechainstalacion)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtSolicitudes_Solicitudesfechainstalacion)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("SolicitudesFechaInstalacion", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("SolicitudesHoraInstalacion", gxTv_SdtSolicitudes_Solicitudeshorainstalacion, false, includeNonInitialized);
         AddObjectProperty("SolicitudesComentario", gxTv_SdtSolicitudes_Solicitudescomentario, false, includeNonInitialized);
         AddObjectProperty("MetodoPagosID", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Metodopagosid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("MetodoPagosNombre", gxTv_SdtSolicitudes_Metodopagosnombre, false, includeNonInitialized);
         AddObjectProperty("SolicitudesNota", gxTv_SdtSolicitudes_Solicitudesnota, false, includeNonInitialized);
         AddObjectProperty("SolicitudesNotificacion", gxTv_SdtSolicitudes_Solicitudesnotificacion, false, includeNonInitialized);
         AddObjectProperty("ProveedorID", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Proveedorid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("ProveedorNombre", gxTv_SdtSolicitudes_Proveedornombre, false, includeNonInitialized);
         AddObjectProperty("ProveedorPagoDefault", gxTv_SdtSolicitudes_Proveedorpagodefault, false, includeNonInitialized);
         AddObjectProperty("STComerciosID", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Stcomerciosid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("STComerciosID_N", gxTv_SdtSolicitudes_Stcomerciosid_N, false, includeNonInitialized);
         AddObjectProperty("STComerciosNombre", gxTv_SdtSolicitudes_Stcomerciosnombre, false, includeNonInitialized);
         AddObjectProperty("STComerciosEstado", gxTv_SdtSolicitudes_Stcomerciosestado, false, includeNonInitialized);
         AddObjectProperty("SolicitudServicioOrigenPago", gxTv_SdtSolicitudes_Solicitudservicioorigenpago, false, includeNonInitialized);
         AddObjectProperty("SolicitudServicioOrigenPago_N", gxTv_SdtSolicitudes_Solicitudservicioorigenpago_N, false, includeNonInitialized);
         AddObjectProperty("SolicitudesPagado", gxTv_SdtSolicitudes_Solicitudespagado, false, includeNonInitialized);
         AddObjectProperty("SolicitudesPagado_N", gxTv_SdtSolicitudes_Solicitudespagado_N, false, includeNonInitialized);
         AddObjectProperty("SolicitudServicioComProv", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Solicitudserviciocomprov, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("SolicitudServicioComProv_N", gxTv_SdtSolicitudes_Solicitudserviciocomprov_N, false, includeNonInitialized);
         AddObjectProperty("SolicitudServicioComProvP", gxTv_SdtSolicitudes_Solicitudserviciocomprovp, false, includeNonInitialized);
         AddObjectProperty("SolicitudServicioComProvP_N", gxTv_SdtSolicitudes_Solicitudserviciocomprovp_N, false, includeNonInitialized);
         AddObjectProperty("SolicitudServicioComALM", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Solicitudserviciocomalm, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("SolicitudServicioComALM_N", gxTv_SdtSolicitudes_Solicitudserviciocomalm_N, false, includeNonInitialized);
         AddObjectProperty("SolicitudServicioComALMP", gxTv_SdtSolicitudes_Solicitudserviciocomalmp, false, includeNonInitialized);
         AddObjectProperty("SolicitudServicioComALMP_N", gxTv_SdtSolicitudes_Solicitudserviciocomalmp_N, false, includeNonInitialized);
         AddObjectProperty("SolicitudServicioComPro", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Solicitudserviciocompro, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("SolicitudServicioComProP", gxTv_SdtSolicitudes_Solicitudserviciocomprop, false, includeNonInitialized);
         AddObjectProperty("SolicitudesCalComi", gxTv_SdtSolicitudes_Solicitudescalcomi, false, includeNonInitialized);
         AddObjectProperty("ProveedorNombreAux", gxTv_SdtSolicitudes_Proveedornombreaux, false, includeNonInitialized);
         AddObjectProperty("ProveedorNombreAux_N", gxTv_SdtSolicitudes_Proveedornombreaux_N, false, includeNonInitialized);
         AddObjectProperty("SolicitudesSubTipo", gxTv_SdtSolicitudes_Solicitudessubtipo, false, includeNonInitialized);
         AddObjectProperty("SolicitudesSubTipo_N", gxTv_SdtSolicitudes_Solicitudessubtipo_N, false, includeNonInitialized);
         AddObjectProperty("SolicitudesCostoXZona", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Solicitudescostoxzona, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("SolicitudesCostoXZComAlm", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Solicitudescostoxzcomalm, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("SolicitudesCostoXZComAlm_N", gxTv_SdtSolicitudes_Solicitudescostoxzcomalm_N, false, includeNonInitialized);
         AddObjectProperty("SolicitudesCostoXZComAlmP", gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp, false, includeNonInitialized);
         AddObjectProperty("SolicitudesCostoXZComAlmP_N", gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp_N, false, includeNonInitialized);
         AddObjectProperty("SolicitudesCostoXZComProf", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Solicitudescostoxzcomprof, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("SolicitudesCostoXZComProfP", gxTv_SdtSolicitudes_Solicitudescostoxzcomprofp, false, includeNonInitialized);
         AddObjectProperty("MudanzaId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Mudanzaid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("MudanzaId_N", gxTv_SdtSolicitudes_Mudanzaid_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtSolicitudes_Mudanzafechaservicio)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtSolicitudes_Mudanzafechaservicio)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtSolicitudes_Mudanzafechaservicio)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("MudanzaFechaServicio", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("MudanzaDireccionOrigen", gxTv_SdtSolicitudes_Mudanzadireccionorigen, false, includeNonInitialized);
         AddObjectProperty("MudanzaDireccionDestino", gxTv_SdtSolicitudes_Mudanzadirecciondestino, false, includeNonInitialized);
         AddObjectProperty("PostulacionesId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Postulacionesid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("PostulacionesId_N", gxTv_SdtSolicitudes_Postulacionesid_N, false, includeNonInitialized);
         AddObjectProperty("SolicitudesDuplicado", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Solicitudesduplicado), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("SolicitudesDuplicado_N", gxTv_SdtSolicitudes_Solicitudesduplicado_N, false, includeNonInitialized);
         AddObjectProperty("SolicitudesSerialArchivo", gxTv_SdtSolicitudes_Solicitudesserialarchivo, false, includeNonInitialized);
         AddObjectProperty("CancelacionTipificacionId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Cancelaciontipificacionid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("CancelacionTipificacionDescripcion", gxTv_SdtSolicitudes_Cancelaciontipificaciondescripcion, false, includeNonInitialized);
         AddObjectProperty("SolicitudesCostoPresupuesto", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Solicitudescostopresupuesto, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("SolicitudesCostoPresupuesto_N", gxTv_SdtSolicitudes_Solicitudescostopresupuesto_N, false, includeNonInitialized);
         AddObjectProperty("SolicitudesURLOrigen", gxTv_SdtSolicitudes_Solicitudesurlorigen, false, includeNonInitialized);
         AddObjectProperty("SolicitudesURLOrigen_N", gxTv_SdtSolicitudes_Solicitudesurlorigen_N, false, includeNonInitialized);
         AddObjectProperty("TicketId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Ticketid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("TicketId_N", gxTv_SdtSolicitudes_Ticketid_N, false, includeNonInitialized);
         AddObjectProperty("TicketMotivoId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Ticketmotivoid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("TicketMotivoDescripcion", gxTv_SdtSolicitudes_Ticketmotivodescripcion, false, includeNonInitialized);
         AddObjectProperty("TicketComentario", gxTv_SdtSolicitudes_Ticketcomentario, false, includeNonInitialized);
         AddObjectProperty("TicketAdjunto", gxTv_SdtSolicitudes_Ticketadjunto, false, includeNonInitialized);
         AddObjectProperty("TicketEstado", gxTv_SdtSolicitudes_Ticketestado, false, includeNonInitialized);
         AddObjectProperty("TicketSolicitudId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Ticketsolicitudid), 18, 0)), false, includeNonInitialized);
         if ( gxTv_SdtSolicitudes_Archivo != null )
         {
            AddObjectProperty("Archivo", gxTv_SdtSolicitudes_Archivo, includeState, includeNonInitialized);
         }
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtSolicitudes_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtSolicitudes_Initialized, false, includeNonInitialized);
            AddObjectProperty("SolicitudesID_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Solicitudesid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("SolicitudesNombre_Z", gxTv_SdtSolicitudes_Solicitudesnombre_Z, false, includeNonInitialized);
            AddObjectProperty("SolicitudesTelefono_Z", gxTv_SdtSolicitudes_Solicitudestelefono_Z, false, includeNonInitialized);
            AddObjectProperty("SolicitudesMail_Z", gxTv_SdtSolicitudes_Solicitudesmail_Z, false, includeNonInitialized);
            AddObjectProperty("PaisID_Z", gxTv_SdtSolicitudes_Paisid_Z, false, includeNonInitialized);
            AddObjectProperty("DepartamentoId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Departamentoid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("DepartamentoMunicipioId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Departamentomunicipioid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("ZonasID_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Zonasid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("SolicitudesDireccion_Z", gxTv_SdtSolicitudes_Solicitudesdireccion_Z, false, includeNonInitialized);
            AddObjectProperty("SolicitudesAutoEnumerar_Z", gxTv_SdtSolicitudes_Solicitudesautoenumerar_Z, false, includeNonInitialized);
            AddObjectProperty("STMonedasId_Z", gxTv_SdtSolicitudes_Stmonedasid_Z, false, includeNonInitialized);
            AddObjectProperty("STMonedasISO_Z", gxTv_SdtSolicitudes_Stmonedasiso_Z, false, includeNonInitialized);
            AddObjectProperty("SolicitudesLiqProf_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Solicitudesliqprof_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("SolicitudesLiqProv_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Solicitudesliqprov_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("SolicitudesCotizacion_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Solicitudescotizacion_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("SolicitudesTotal_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Solicitudestotal_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("SolicitudServicioSolCoti_Z", gxTv_SdtSolicitudes_Solicitudserviciosolcoti_Z, false, includeNonInitialized);
            AddObjectProperty("SolicitudServicioPFinal_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Solicitudserviciopfinal_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("SolicitudesDescuento_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Solicitudesdescuento_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("CuponId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Cuponid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("CuponPercent_Z", gxTv_SdtSolicitudes_Cuponpercent_Z, false, includeNonInitialized);
            AddObjectProperty("SolicitudesDescuentoCupon_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Solicitudesdescuentocupon_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("SolicitudesComisionMetodoPago_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Solicitudescomisionmetodopago_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("EstadosSolTipo_Z", gxTv_SdtSolicitudes_Estadossoltipo_Z, false, includeNonInitialized);
            AddObjectProperty("EstadosSolId_Z", gxTv_SdtSolicitudes_Estadossolid_Z, false, includeNonInitialized);
            AddObjectProperty("EstadosSolNombre_Z", gxTv_SdtSolicitudes_Estadossolnombre_Z, false, includeNonInitialized);
            AddObjectProperty("SolicitudesOtros1_Z", gxTv_SdtSolicitudes_Solicitudesotros1_Z, false, includeNonInitialized);
            AddObjectProperty("SolicitudesOtros2_Z", gxTv_SdtSolicitudes_Solicitudesotros2_Z, false, includeNonInitialized);
            AddObjectProperty("SolicitudesOtros3_Z", gxTv_SdtSolicitudes_Solicitudesotros3_Z, false, includeNonInitialized);
            AddObjectProperty("SolicitudesUsrAlta_Z", gxTv_SdtSolicitudes_Solicitudesusralta_Z, false, includeNonInitialized);
            AddObjectProperty("SolicitudesUsrActualizacion_Z", gxTv_SdtSolicitudes_Solicitudesusractualizacion_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtSolicitudes_Solicitudesfechaalta_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtSolicitudes_Solicitudesfechaalta_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtSolicitudes_Solicitudesfechaalta_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("SolicitudesFechaAlta_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_Z;
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
            AddObjectProperty("SolicitudesFechaActualizacion_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtSolicitudes_Solicitudesfechainstalacion_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtSolicitudes_Solicitudesfechainstalacion_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtSolicitudes_Solicitudesfechainstalacion_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("SolicitudesFechaInstalacion_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("SolicitudesHoraInstalacion_Z", gxTv_SdtSolicitudes_Solicitudeshorainstalacion_Z, false, includeNonInitialized);
            AddObjectProperty("MetodoPagosID_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Metodopagosid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("MetodoPagosNombre_Z", gxTv_SdtSolicitudes_Metodopagosnombre_Z, false, includeNonInitialized);
            AddObjectProperty("SolicitudesNota_Z", gxTv_SdtSolicitudes_Solicitudesnota_Z, false, includeNonInitialized);
            AddObjectProperty("SolicitudesNotificacion_Z", gxTv_SdtSolicitudes_Solicitudesnotificacion_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorID_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Proveedorid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("ProveedorNombre_Z", gxTv_SdtSolicitudes_Proveedornombre_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorPagoDefault_Z", gxTv_SdtSolicitudes_Proveedorpagodefault_Z, false, includeNonInitialized);
            AddObjectProperty("STComerciosID_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Stcomerciosid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("STComerciosNombre_Z", gxTv_SdtSolicitudes_Stcomerciosnombre_Z, false, includeNonInitialized);
            AddObjectProperty("STComerciosEstado_Z", gxTv_SdtSolicitudes_Stcomerciosestado_Z, false, includeNonInitialized);
            AddObjectProperty("SolicitudServicioOrigenPago_Z", gxTv_SdtSolicitudes_Solicitudservicioorigenpago_Z, false, includeNonInitialized);
            AddObjectProperty("SolicitudesPagado_Z", gxTv_SdtSolicitudes_Solicitudespagado_Z, false, includeNonInitialized);
            AddObjectProperty("SolicitudServicioComProv_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Solicitudserviciocomprov_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("SolicitudServicioComProvP_Z", gxTv_SdtSolicitudes_Solicitudserviciocomprovp_Z, false, includeNonInitialized);
            AddObjectProperty("SolicitudServicioComALM_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Solicitudserviciocomalm_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("SolicitudServicioComALMP_Z", gxTv_SdtSolicitudes_Solicitudserviciocomalmp_Z, false, includeNonInitialized);
            AddObjectProperty("SolicitudServicioComPro_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Solicitudserviciocompro_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("SolicitudServicioComProP_Z", gxTv_SdtSolicitudes_Solicitudserviciocomprop_Z, false, includeNonInitialized);
            AddObjectProperty("SolicitudesCalComi_Z", gxTv_SdtSolicitudes_Solicitudescalcomi_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorNombreAux_Z", gxTv_SdtSolicitudes_Proveedornombreaux_Z, false, includeNonInitialized);
            AddObjectProperty("SolicitudesSubTipo_Z", gxTv_SdtSolicitudes_Solicitudessubtipo_Z, false, includeNonInitialized);
            AddObjectProperty("SolicitudesCostoXZona_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Solicitudescostoxzona_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("SolicitudesCostoXZComAlm_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Solicitudescostoxzcomalm_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("SolicitudesCostoXZComAlmP_Z", gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp_Z, false, includeNonInitialized);
            AddObjectProperty("SolicitudesCostoXZComProf_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Solicitudescostoxzcomprof_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("SolicitudesCostoXZComProfP_Z", gxTv_SdtSolicitudes_Solicitudescostoxzcomprofp_Z, false, includeNonInitialized);
            AddObjectProperty("MudanzaId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Mudanzaid_Z), 18, 0)), false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtSolicitudes_Mudanzafechaservicio_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtSolicitudes_Mudanzafechaservicio_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtSolicitudes_Mudanzafechaservicio_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("MudanzaFechaServicio_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("MudanzaDireccionOrigen_Z", gxTv_SdtSolicitudes_Mudanzadireccionorigen_Z, false, includeNonInitialized);
            AddObjectProperty("MudanzaDireccionDestino_Z", gxTv_SdtSolicitudes_Mudanzadirecciondestino_Z, false, includeNonInitialized);
            AddObjectProperty("PostulacionesId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Postulacionesid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("SolicitudesDuplicado_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Solicitudesduplicado_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("SolicitudesSerialArchivo_Z", gxTv_SdtSolicitudes_Solicitudesserialarchivo_Z, false, includeNonInitialized);
            AddObjectProperty("CancelacionTipificacionId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Cancelaciontipificacionid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("CancelacionTipificacionDescripcion_Z", gxTv_SdtSolicitudes_Cancelaciontipificaciondescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("SolicitudesCostoPresupuesto_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Solicitudescostopresupuesto_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("SolicitudesURLOrigen_Z", gxTv_SdtSolicitudes_Solicitudesurlorigen_Z, false, includeNonInitialized);
            AddObjectProperty("TicketId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Ticketid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("TicketMotivoId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Ticketmotivoid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("TicketMotivoDescripcion_Z", gxTv_SdtSolicitudes_Ticketmotivodescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("TicketComentario_Z", gxTv_SdtSolicitudes_Ticketcomentario_Z, false, includeNonInitialized);
            AddObjectProperty("TicketAdjunto_Z", gxTv_SdtSolicitudes_Ticketadjunto_Z, false, includeNonInitialized);
            AddObjectProperty("TicketEstado_Z", gxTv_SdtSolicitudes_Ticketestado_Z, false, includeNonInitialized);
            AddObjectProperty("TicketSolicitudId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Ticketsolicitudid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("SolicitudesMail_N", gxTv_SdtSolicitudes_Solicitudesmail_N, false, includeNonInitialized);
            AddObjectProperty("DepartamentoId_N", gxTv_SdtSolicitudes_Departamentoid_N, false, includeNonInitialized);
            AddObjectProperty("DepartamentoMunicipioId_N", gxTv_SdtSolicitudes_Departamentomunicipioid_N, false, includeNonInitialized);
            AddObjectProperty("ZonasID_N", gxTv_SdtSolicitudes_Zonasid_N, false, includeNonInitialized);
            AddObjectProperty("STMonedasId_N", gxTv_SdtSolicitudes_Stmonedasid_N, false, includeNonInitialized);
            AddObjectProperty("SolicitudesLiqProf_N", gxTv_SdtSolicitudes_Solicitudesliqprof_N, false, includeNonInitialized);
            AddObjectProperty("SolicitudesLiqProv_N", gxTv_SdtSolicitudes_Solicitudesliqprov_N, false, includeNonInitialized);
            AddObjectProperty("SolicitudesDescuento_N", gxTv_SdtSolicitudes_Solicitudesdescuento_N, false, includeNonInitialized);
            AddObjectProperty("CuponId_N", gxTv_SdtSolicitudes_Cuponid_N, false, includeNonInitialized);
            AddObjectProperty("SolicitudesUsrAlta_N", gxTv_SdtSolicitudes_Solicitudesusralta_N, false, includeNonInitialized);
            AddObjectProperty("SolicitudesUsrActualizacion_N", gxTv_SdtSolicitudes_Solicitudesusractualizacion_N, false, includeNonInitialized);
            AddObjectProperty("SolicitudesFechaAlta_N", gxTv_SdtSolicitudes_Solicitudesfechaalta_N, false, includeNonInitialized);
            AddObjectProperty("SolicitudesFechaActualizacion_N", gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_N, false, includeNonInitialized);
            AddObjectProperty("STComerciosID_N", gxTv_SdtSolicitudes_Stcomerciosid_N, false, includeNonInitialized);
            AddObjectProperty("SolicitudServicioOrigenPago_N", gxTv_SdtSolicitudes_Solicitudservicioorigenpago_N, false, includeNonInitialized);
            AddObjectProperty("SolicitudesPagado_N", gxTv_SdtSolicitudes_Solicitudespagado_N, false, includeNonInitialized);
            AddObjectProperty("SolicitudServicioComProv_N", gxTv_SdtSolicitudes_Solicitudserviciocomprov_N, false, includeNonInitialized);
            AddObjectProperty("SolicitudServicioComProvP_N", gxTv_SdtSolicitudes_Solicitudserviciocomprovp_N, false, includeNonInitialized);
            AddObjectProperty("SolicitudServicioComALM_N", gxTv_SdtSolicitudes_Solicitudserviciocomalm_N, false, includeNonInitialized);
            AddObjectProperty("SolicitudServicioComALMP_N", gxTv_SdtSolicitudes_Solicitudserviciocomalmp_N, false, includeNonInitialized);
            AddObjectProperty("ProveedorNombreAux_N", gxTv_SdtSolicitudes_Proveedornombreaux_N, false, includeNonInitialized);
            AddObjectProperty("SolicitudesSubTipo_N", gxTv_SdtSolicitudes_Solicitudessubtipo_N, false, includeNonInitialized);
            AddObjectProperty("SolicitudesCostoXZComAlm_N", gxTv_SdtSolicitudes_Solicitudescostoxzcomalm_N, false, includeNonInitialized);
            AddObjectProperty("SolicitudesCostoXZComAlmP_N", gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp_N, false, includeNonInitialized);
            AddObjectProperty("MudanzaId_N", gxTv_SdtSolicitudes_Mudanzaid_N, false, includeNonInitialized);
            AddObjectProperty("PostulacionesId_N", gxTv_SdtSolicitudes_Postulacionesid_N, false, includeNonInitialized);
            AddObjectProperty("SolicitudesDuplicado_N", gxTv_SdtSolicitudes_Solicitudesduplicado_N, false, includeNonInitialized);
            AddObjectProperty("SolicitudesCostoPresupuesto_N", gxTv_SdtSolicitudes_Solicitudescostopresupuesto_N, false, includeNonInitialized);
            AddObjectProperty("SolicitudesURLOrigen_N", gxTv_SdtSolicitudes_Solicitudesurlorigen_N, false, includeNonInitialized);
            AddObjectProperty("TicketId_N", gxTv_SdtSolicitudes_Ticketid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtSolicitudes sdt )
      {
         if ( sdt.IsDirty("SolicitudesID") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesid = sdt.gxTv_SdtSolicitudes_Solicitudesid ;
         }
         if ( sdt.IsDirty("SolicitudesNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesnombre = sdt.gxTv_SdtSolicitudes_Solicitudesnombre ;
         }
         if ( sdt.IsDirty("SolicitudesTelefono") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudestelefono = sdt.gxTv_SdtSolicitudes_Solicitudestelefono ;
         }
         if ( sdt.IsDirty("SolicitudesMail") )
         {
            gxTv_SdtSolicitudes_Solicitudesmail_N = (short)(sdt.gxTv_SdtSolicitudes_Solicitudesmail_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesmail = sdt.gxTv_SdtSolicitudes_Solicitudesmail ;
         }
         if ( sdt.IsDirty("PaisID") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Paisid = sdt.gxTv_SdtSolicitudes_Paisid ;
         }
         if ( sdt.IsDirty("DepartamentoId") )
         {
            gxTv_SdtSolicitudes_Departamentoid_N = (short)(sdt.gxTv_SdtSolicitudes_Departamentoid_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Departamentoid = sdt.gxTv_SdtSolicitudes_Departamentoid ;
         }
         if ( sdt.IsDirty("DepartamentoMunicipioId") )
         {
            gxTv_SdtSolicitudes_Departamentomunicipioid_N = (short)(sdt.gxTv_SdtSolicitudes_Departamentomunicipioid_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Departamentomunicipioid = sdt.gxTv_SdtSolicitudes_Departamentomunicipioid ;
         }
         if ( sdt.IsDirty("ZonasID") )
         {
            gxTv_SdtSolicitudes_Zonasid_N = (short)(sdt.gxTv_SdtSolicitudes_Zonasid_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Zonasid = sdt.gxTv_SdtSolicitudes_Zonasid ;
         }
         if ( sdt.IsDirty("SolicitudesDireccion") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesdireccion = sdt.gxTv_SdtSolicitudes_Solicitudesdireccion ;
         }
         if ( sdt.IsDirty("SolicitudesAutoEnumerar") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesautoenumerar = sdt.gxTv_SdtSolicitudes_Solicitudesautoenumerar ;
         }
         if ( sdt.IsDirty("STMonedasId") )
         {
            gxTv_SdtSolicitudes_Stmonedasid_N = (short)(sdt.gxTv_SdtSolicitudes_Stmonedasid_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Stmonedasid = sdt.gxTv_SdtSolicitudes_Stmonedasid ;
         }
         if ( sdt.IsDirty("STMonedasISO") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Stmonedasiso = sdt.gxTv_SdtSolicitudes_Stmonedasiso ;
         }
         if ( sdt.IsDirty("SolicitudesLiqProf") )
         {
            gxTv_SdtSolicitudes_Solicitudesliqprof_N = (short)(sdt.gxTv_SdtSolicitudes_Solicitudesliqprof_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesliqprof = sdt.gxTv_SdtSolicitudes_Solicitudesliqprof ;
         }
         if ( sdt.IsDirty("SolicitudesLiqProv") )
         {
            gxTv_SdtSolicitudes_Solicitudesliqprov_N = (short)(sdt.gxTv_SdtSolicitudes_Solicitudesliqprov_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesliqprov = sdt.gxTv_SdtSolicitudes_Solicitudesliqprov ;
         }
         if ( gxTv_SdtSolicitudes_Items != null )
         {
            GXBCLevelCollection<SdtSolicitudes_Items> newCollectionItems = sdt.gxTpr_Items;
            SdtSolicitudes_Items currItemItems;
            SdtSolicitudes_Items newItemItems;
            short idx = 1;
            while ( idx <= newCollectionItems.Count )
            {
               newItemItems = ((SdtSolicitudes_Items)newCollectionItems.Item(idx));
               currItemItems = gxTv_SdtSolicitudes_Items.GetByKey(newItemItems.gxTpr_Solicitudesitemsid);
               if ( StringUtil.StrCmp(currItemItems.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemItems.UpdateDirties(newItemItems);
                  if ( StringUtil.StrCmp(newItemItems.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemItems.gxTpr_Mode = "DLT";
                  }
                  currItemItems.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtSolicitudes_Items.Add(newItemItems, 0);
               }
               idx = (short)(idx+1);
            }
         }
         if ( sdt.IsDirty("SolicitudesCotizacion") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudescotizacion = sdt.gxTv_SdtSolicitudes_Solicitudescotizacion ;
         }
         if ( sdt.IsDirty("SolicitudesTotal") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudestotal = sdt.gxTv_SdtSolicitudes_Solicitudestotal ;
         }
         if ( sdt.IsDirty("SolicitudServicioSolCoti") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudserviciosolcoti = sdt.gxTv_SdtSolicitudes_Solicitudserviciosolcoti ;
         }
         if ( sdt.IsDirty("SolicitudServicioPFinal") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudserviciopfinal = sdt.gxTv_SdtSolicitudes_Solicitudserviciopfinal ;
         }
         if ( sdt.IsDirty("SolicitudesDescuento") )
         {
            gxTv_SdtSolicitudes_Solicitudesdescuento_N = (short)(sdt.gxTv_SdtSolicitudes_Solicitudesdescuento_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesdescuento = sdt.gxTv_SdtSolicitudes_Solicitudesdescuento ;
         }
         if ( sdt.IsDirty("CuponId") )
         {
            gxTv_SdtSolicitudes_Cuponid_N = (short)(sdt.gxTv_SdtSolicitudes_Cuponid_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Cuponid = sdt.gxTv_SdtSolicitudes_Cuponid ;
         }
         if ( sdt.IsDirty("CuponPercent") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Cuponpercent = sdt.gxTv_SdtSolicitudes_Cuponpercent ;
         }
         if ( sdt.IsDirty("SolicitudesDescuentoCupon") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesdescuentocupon = sdt.gxTv_SdtSolicitudes_Solicitudesdescuentocupon ;
         }
         if ( sdt.IsDirty("SolicitudesComisionMetodoPago") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudescomisionmetodopago = sdt.gxTv_SdtSolicitudes_Solicitudescomisionmetodopago ;
         }
         if ( sdt.IsDirty("EstadosSolTipo") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Estadossoltipo = sdt.gxTv_SdtSolicitudes_Estadossoltipo ;
         }
         if ( sdt.IsDirty("EstadosSolId") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Estadossolid = sdt.gxTv_SdtSolicitudes_Estadossolid ;
         }
         if ( sdt.IsDirty("EstadosSolNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Estadossolnombre = sdt.gxTv_SdtSolicitudes_Estadossolnombre ;
         }
         if ( sdt.IsDirty("SolicitudesOtros1") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesotros1 = sdt.gxTv_SdtSolicitudes_Solicitudesotros1 ;
         }
         if ( sdt.IsDirty("SolicitudesOtros2") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesotros2 = sdt.gxTv_SdtSolicitudes_Solicitudesotros2 ;
         }
         if ( sdt.IsDirty("SolicitudesOtros3") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesotros3 = sdt.gxTv_SdtSolicitudes_Solicitudesotros3 ;
         }
         if ( sdt.IsDirty("SolicitudesUsrAlta") )
         {
            gxTv_SdtSolicitudes_Solicitudesusralta_N = (short)(sdt.gxTv_SdtSolicitudes_Solicitudesusralta_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesusralta = sdt.gxTv_SdtSolicitudes_Solicitudesusralta ;
         }
         if ( sdt.IsDirty("SolicitudesUsrActualizacion") )
         {
            gxTv_SdtSolicitudes_Solicitudesusractualizacion_N = (short)(sdt.gxTv_SdtSolicitudes_Solicitudesusractualizacion_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesusractualizacion = sdt.gxTv_SdtSolicitudes_Solicitudesusractualizacion ;
         }
         if ( sdt.IsDirty("SolicitudesFechaAlta") )
         {
            gxTv_SdtSolicitudes_Solicitudesfechaalta_N = (short)(sdt.gxTv_SdtSolicitudes_Solicitudesfechaalta_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesfechaalta = sdt.gxTv_SdtSolicitudes_Solicitudesfechaalta ;
         }
         if ( sdt.IsDirty("SolicitudesFechaActualizacion") )
         {
            gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_N = (short)(sdt.gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesfechaactualizacion = sdt.gxTv_SdtSolicitudes_Solicitudesfechaactualizacion ;
         }
         if ( sdt.IsDirty("SolicitudesFechaInstalacion") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesfechainstalacion = sdt.gxTv_SdtSolicitudes_Solicitudesfechainstalacion ;
         }
         if ( sdt.IsDirty("SolicitudesHoraInstalacion") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudeshorainstalacion = sdt.gxTv_SdtSolicitudes_Solicitudeshorainstalacion ;
         }
         if ( sdt.IsDirty("SolicitudesComentario") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudescomentario = sdt.gxTv_SdtSolicitudes_Solicitudescomentario ;
         }
         if ( sdt.IsDirty("MetodoPagosID") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Metodopagosid = sdt.gxTv_SdtSolicitudes_Metodopagosid ;
         }
         if ( sdt.IsDirty("MetodoPagosNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Metodopagosnombre = sdt.gxTv_SdtSolicitudes_Metodopagosnombre ;
         }
         if ( sdt.IsDirty("SolicitudesNota") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesnota = sdt.gxTv_SdtSolicitudes_Solicitudesnota ;
         }
         if ( sdt.IsDirty("SolicitudesNotificacion") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesnotificacion = sdt.gxTv_SdtSolicitudes_Solicitudesnotificacion ;
         }
         if ( sdt.IsDirty("ProveedorID") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Proveedorid = sdt.gxTv_SdtSolicitudes_Proveedorid ;
         }
         if ( sdt.IsDirty("ProveedorNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Proveedornombre = sdt.gxTv_SdtSolicitudes_Proveedornombre ;
         }
         if ( sdt.IsDirty("ProveedorPagoDefault") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Proveedorpagodefault = sdt.gxTv_SdtSolicitudes_Proveedorpagodefault ;
         }
         if ( sdt.IsDirty("STComerciosID") )
         {
            gxTv_SdtSolicitudes_Stcomerciosid_N = (short)(sdt.gxTv_SdtSolicitudes_Stcomerciosid_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Stcomerciosid = sdt.gxTv_SdtSolicitudes_Stcomerciosid ;
         }
         if ( sdt.IsDirty("STComerciosNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Stcomerciosnombre = sdt.gxTv_SdtSolicitudes_Stcomerciosnombre ;
         }
         if ( sdt.IsDirty("STComerciosEstado") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Stcomerciosestado = sdt.gxTv_SdtSolicitudes_Stcomerciosestado ;
         }
         if ( sdt.IsDirty("SolicitudServicioOrigenPago") )
         {
            gxTv_SdtSolicitudes_Solicitudservicioorigenpago_N = (short)(sdt.gxTv_SdtSolicitudes_Solicitudservicioorigenpago_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudservicioorigenpago = sdt.gxTv_SdtSolicitudes_Solicitudservicioorigenpago ;
         }
         if ( sdt.IsDirty("SolicitudesPagado") )
         {
            gxTv_SdtSolicitudes_Solicitudespagado_N = (short)(sdt.gxTv_SdtSolicitudes_Solicitudespagado_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudespagado = sdt.gxTv_SdtSolicitudes_Solicitudespagado ;
         }
         if ( sdt.IsDirty("SolicitudServicioComProv") )
         {
            gxTv_SdtSolicitudes_Solicitudserviciocomprov_N = (short)(sdt.gxTv_SdtSolicitudes_Solicitudserviciocomprov_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudserviciocomprov = sdt.gxTv_SdtSolicitudes_Solicitudserviciocomprov ;
         }
         if ( sdt.IsDirty("SolicitudServicioComProvP") )
         {
            gxTv_SdtSolicitudes_Solicitudserviciocomprovp_N = (short)(sdt.gxTv_SdtSolicitudes_Solicitudserviciocomprovp_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudserviciocomprovp = sdt.gxTv_SdtSolicitudes_Solicitudserviciocomprovp ;
         }
         if ( sdt.IsDirty("SolicitudServicioComALM") )
         {
            gxTv_SdtSolicitudes_Solicitudserviciocomalm_N = (short)(sdt.gxTv_SdtSolicitudes_Solicitudserviciocomalm_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudserviciocomalm = sdt.gxTv_SdtSolicitudes_Solicitudserviciocomalm ;
         }
         if ( sdt.IsDirty("SolicitudServicioComALMP") )
         {
            gxTv_SdtSolicitudes_Solicitudserviciocomalmp_N = (short)(sdt.gxTv_SdtSolicitudes_Solicitudserviciocomalmp_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudserviciocomalmp = sdt.gxTv_SdtSolicitudes_Solicitudserviciocomalmp ;
         }
         if ( sdt.IsDirty("SolicitudServicioComPro") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudserviciocompro = sdt.gxTv_SdtSolicitudes_Solicitudserviciocompro ;
         }
         if ( sdt.IsDirty("SolicitudServicioComProP") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudserviciocomprop = sdt.gxTv_SdtSolicitudes_Solicitudserviciocomprop ;
         }
         if ( sdt.IsDirty("SolicitudesCalComi") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudescalcomi = sdt.gxTv_SdtSolicitudes_Solicitudescalcomi ;
         }
         if ( sdt.IsDirty("ProveedorNombreAux") )
         {
            gxTv_SdtSolicitudes_Proveedornombreaux_N = (short)(sdt.gxTv_SdtSolicitudes_Proveedornombreaux_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Proveedornombreaux = sdt.gxTv_SdtSolicitudes_Proveedornombreaux ;
         }
         if ( sdt.IsDirty("SolicitudesSubTipo") )
         {
            gxTv_SdtSolicitudes_Solicitudessubtipo_N = (short)(sdt.gxTv_SdtSolicitudes_Solicitudessubtipo_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudessubtipo = sdt.gxTv_SdtSolicitudes_Solicitudessubtipo ;
         }
         if ( sdt.IsDirty("SolicitudesCostoXZona") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudescostoxzona = sdt.gxTv_SdtSolicitudes_Solicitudescostoxzona ;
         }
         if ( sdt.IsDirty("SolicitudesCostoXZComAlm") )
         {
            gxTv_SdtSolicitudes_Solicitudescostoxzcomalm_N = (short)(sdt.gxTv_SdtSolicitudes_Solicitudescostoxzcomalm_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudescostoxzcomalm = sdt.gxTv_SdtSolicitudes_Solicitudescostoxzcomalm ;
         }
         if ( sdt.IsDirty("SolicitudesCostoXZComAlmP") )
         {
            gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp_N = (short)(sdt.gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp = sdt.gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp ;
         }
         if ( sdt.IsDirty("SolicitudesCostoXZComProf") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudescostoxzcomprof = sdt.gxTv_SdtSolicitudes_Solicitudescostoxzcomprof ;
         }
         if ( sdt.IsDirty("SolicitudesCostoXZComProfP") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudescostoxzcomprofp = sdt.gxTv_SdtSolicitudes_Solicitudescostoxzcomprofp ;
         }
         if ( sdt.IsDirty("MudanzaId") )
         {
            gxTv_SdtSolicitudes_Mudanzaid_N = (short)(sdt.gxTv_SdtSolicitudes_Mudanzaid_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Mudanzaid = sdt.gxTv_SdtSolicitudes_Mudanzaid ;
         }
         if ( sdt.IsDirty("MudanzaFechaServicio") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Mudanzafechaservicio = sdt.gxTv_SdtSolicitudes_Mudanzafechaservicio ;
         }
         if ( sdt.IsDirty("MudanzaDireccionOrigen") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Mudanzadireccionorigen = sdt.gxTv_SdtSolicitudes_Mudanzadireccionorigen ;
         }
         if ( sdt.IsDirty("MudanzaDireccionDestino") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Mudanzadirecciondestino = sdt.gxTv_SdtSolicitudes_Mudanzadirecciondestino ;
         }
         if ( sdt.IsDirty("PostulacionesId") )
         {
            gxTv_SdtSolicitudes_Postulacionesid_N = (short)(sdt.gxTv_SdtSolicitudes_Postulacionesid_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Postulacionesid = sdt.gxTv_SdtSolicitudes_Postulacionesid ;
         }
         if ( sdt.IsDirty("SolicitudesDuplicado") )
         {
            gxTv_SdtSolicitudes_Solicitudesduplicado_N = (short)(sdt.gxTv_SdtSolicitudes_Solicitudesduplicado_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesduplicado = sdt.gxTv_SdtSolicitudes_Solicitudesduplicado ;
         }
         if ( sdt.IsDirty("SolicitudesSerialArchivo") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesserialarchivo = sdt.gxTv_SdtSolicitudes_Solicitudesserialarchivo ;
         }
         if ( sdt.IsDirty("CancelacionTipificacionId") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Cancelaciontipificacionid = sdt.gxTv_SdtSolicitudes_Cancelaciontipificacionid ;
         }
         if ( sdt.IsDirty("CancelacionTipificacionDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Cancelaciontipificaciondescripcion = sdt.gxTv_SdtSolicitudes_Cancelaciontipificaciondescripcion ;
         }
         if ( sdt.IsDirty("SolicitudesCostoPresupuesto") )
         {
            gxTv_SdtSolicitudes_Solicitudescostopresupuesto_N = (short)(sdt.gxTv_SdtSolicitudes_Solicitudescostopresupuesto_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudescostopresupuesto = sdt.gxTv_SdtSolicitudes_Solicitudescostopresupuesto ;
         }
         if ( sdt.IsDirty("SolicitudesURLOrigen") )
         {
            gxTv_SdtSolicitudes_Solicitudesurlorigen_N = (short)(sdt.gxTv_SdtSolicitudes_Solicitudesurlorigen_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesurlorigen = sdt.gxTv_SdtSolicitudes_Solicitudesurlorigen ;
         }
         if ( sdt.IsDirty("TicketId") )
         {
            gxTv_SdtSolicitudes_Ticketid_N = (short)(sdt.gxTv_SdtSolicitudes_Ticketid_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Ticketid = sdt.gxTv_SdtSolicitudes_Ticketid ;
         }
         if ( sdt.IsDirty("TicketMotivoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Ticketmotivoid = sdt.gxTv_SdtSolicitudes_Ticketmotivoid ;
         }
         if ( sdt.IsDirty("TicketMotivoDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Ticketmotivodescripcion = sdt.gxTv_SdtSolicitudes_Ticketmotivodescripcion ;
         }
         if ( sdt.IsDirty("TicketComentario") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Ticketcomentario = sdt.gxTv_SdtSolicitudes_Ticketcomentario ;
         }
         if ( sdt.IsDirty("TicketAdjunto") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Ticketadjunto = sdt.gxTv_SdtSolicitudes_Ticketadjunto ;
         }
         if ( sdt.IsDirty("TicketEstado") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Ticketestado = sdt.gxTv_SdtSolicitudes_Ticketestado ;
         }
         if ( sdt.IsDirty("TicketSolicitudId") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Ticketsolicitudid = sdt.gxTv_SdtSolicitudes_Ticketsolicitudid ;
         }
         if ( gxTv_SdtSolicitudes_Archivo != null )
         {
            GXBCLevelCollection<SdtSolicitudes_Archivo> newCollectionArchivo = sdt.gxTpr_Archivo;
            SdtSolicitudes_Archivo currItemArchivo;
            SdtSolicitudes_Archivo newItemArchivo;
            short idx = 1;
            while ( idx <= newCollectionArchivo.Count )
            {
               newItemArchivo = ((SdtSolicitudes_Archivo)newCollectionArchivo.Item(idx));
               currItemArchivo = gxTv_SdtSolicitudes_Archivo.GetByKey(newItemArchivo.gxTpr_Archivoid);
               if ( StringUtil.StrCmp(currItemArchivo.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemArchivo.UpdateDirties(newItemArchivo);
                  if ( StringUtil.StrCmp(newItemArchivo.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemArchivo.gxTpr_Mode = "DLT";
                  }
                  currItemArchivo.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtSolicitudes_Archivo.Add(newItemArchivo, 0);
               }
               idx = (short)(idx+1);
            }
         }
         return  ;
      }

      [  SoapElement( ElementName = "SolicitudesID" )]
      [  XmlElement( ElementName = "SolicitudesID"   )]
      public long gxTpr_Solicitudesid
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtSolicitudes_Solicitudesid != value )
            {
               gxTv_SdtSolicitudes_Mode = "INS";
               this.gxTv_SdtSolicitudes_Solicitudesid_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudesnombre_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudestelefono_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudesmail_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Paisid_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Departamentoid_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Departamentomunicipioid_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Zonasid_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudesdireccion_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudesautoenumerar_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Stmonedasid_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Stmonedasiso_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudesliqprof_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudesliqprov_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudescotizacion_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudestotal_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudserviciosolcoti_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudserviciopfinal_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudesdescuento_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Cuponid_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Cuponpercent_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudesdescuentocupon_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudescomisionmetodopago_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Estadossoltipo_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Estadossolid_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Estadossolnombre_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudesotros1_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudesotros2_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudesotros3_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudesusralta_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudesusractualizacion_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudesfechaalta_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudesfechainstalacion_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudeshorainstalacion_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Metodopagosid_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Metodopagosnombre_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudesnota_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudesnotificacion_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Proveedorid_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Proveedornombre_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Proveedorpagodefault_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Stcomerciosid_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Stcomerciosnombre_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Stcomerciosestado_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudservicioorigenpago_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudespagado_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudserviciocomprov_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudserviciocomprovp_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudserviciocomalm_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudserviciocomalmp_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudserviciocompro_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudserviciocomprop_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudescalcomi_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Proveedornombreaux_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudessubtipo_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudescostoxzona_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudescostoxzcomalm_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudescostoxzcomprof_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudescostoxzcomprofp_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Mudanzaid_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Mudanzafechaservicio_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Mudanzadireccionorigen_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Mudanzadirecciondestino_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Postulacionesid_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudesduplicado_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudesserialarchivo_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Cancelaciontipificacionid_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Cancelaciontipificaciondescripcion_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudescostopresupuesto_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Solicitudesurlorigen_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Ticketid_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Ticketmotivoid_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Ticketmotivodescripcion_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Ticketcomentario_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Ticketadjunto_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Ticketestado_Z_SetNull( );
               this.gxTv_SdtSolicitudes_Ticketsolicitudid_Z_SetNull( );
               if ( gxTv_SdtSolicitudes_Items != null )
               {
                  GXBCLevelCollection<SdtSolicitudes_Items> collectionItems = gxTv_SdtSolicitudes_Items;
                  SdtSolicitudes_Items currItemItems;
                  short idx = 1;
                  while ( idx <= collectionItems.Count )
                  {
                     currItemItems = ((SdtSolicitudes_Items)collectionItems.Item(idx));
                     currItemItems.gxTpr_Mode = "INS";
                     currItemItems.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
               if ( gxTv_SdtSolicitudes_Archivo != null )
               {
                  GXBCLevelCollection<SdtSolicitudes_Archivo> collectionArchivo = gxTv_SdtSolicitudes_Archivo;
                  SdtSolicitudes_Archivo currItemArchivo;
                  short idx = 1;
                  while ( idx <= collectionArchivo.Count )
                  {
                     currItemArchivo = ((SdtSolicitudes_Archivo)collectionArchivo.Item(idx));
                     currItemArchivo.gxTpr_Mode = "INS";
                     currItemArchivo.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtSolicitudes_Solicitudesid = value;
            SetDirty("Solicitudesid");
         }

      }

      [  SoapElement( ElementName = "SolicitudesNombre" )]
      [  XmlElement( ElementName = "SolicitudesNombre"   )]
      public string gxTpr_Solicitudesnombre
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesnombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesnombre = value;
            SetDirty("Solicitudesnombre");
         }

      }

      [  SoapElement( ElementName = "SolicitudesTelefono" )]
      [  XmlElement( ElementName = "SolicitudesTelefono"   )]
      public string gxTpr_Solicitudestelefono
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudestelefono ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudestelefono = value;
            SetDirty("Solicitudestelefono");
         }

      }

      [  SoapElement( ElementName = "SolicitudesMail" )]
      [  XmlElement( ElementName = "SolicitudesMail"   )]
      public string gxTpr_Solicitudesmail
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesmail ;
         }

         set {
            gxTv_SdtSolicitudes_Solicitudesmail_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesmail = value;
            SetDirty("Solicitudesmail");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesmail_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesmail_N = 1;
         gxTv_SdtSolicitudes_Solicitudesmail = "";
         SetDirty("Solicitudesmail");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesmail_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Solicitudesmail_N==1) ;
      }

      [  SoapElement( ElementName = "PaisID" )]
      [  XmlElement( ElementName = "PaisID"   )]
      public string gxTpr_Paisid
      {
         get {
            return gxTv_SdtSolicitudes_Paisid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Paisid = value;
            SetDirty("Paisid");
         }

      }

      [  SoapElement( ElementName = "DepartamentoId" )]
      [  XmlElement( ElementName = "DepartamentoId"   )]
      public long gxTpr_Departamentoid
      {
         get {
            return gxTv_SdtSolicitudes_Departamentoid ;
         }

         set {
            gxTv_SdtSolicitudes_Departamentoid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Departamentoid = value;
            SetDirty("Departamentoid");
         }

      }

      public void gxTv_SdtSolicitudes_Departamentoid_SetNull( )
      {
         gxTv_SdtSolicitudes_Departamentoid_N = 1;
         gxTv_SdtSolicitudes_Departamentoid = 0;
         SetDirty("Departamentoid");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Departamentoid_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Departamentoid_N==1) ;
      }

      [  SoapElement( ElementName = "DepartamentoMunicipioId" )]
      [  XmlElement( ElementName = "DepartamentoMunicipioId"   )]
      public long gxTpr_Departamentomunicipioid
      {
         get {
            return gxTv_SdtSolicitudes_Departamentomunicipioid ;
         }

         set {
            gxTv_SdtSolicitudes_Departamentomunicipioid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Departamentomunicipioid = value;
            SetDirty("Departamentomunicipioid");
         }

      }

      public void gxTv_SdtSolicitudes_Departamentomunicipioid_SetNull( )
      {
         gxTv_SdtSolicitudes_Departamentomunicipioid_N = 1;
         gxTv_SdtSolicitudes_Departamentomunicipioid = 0;
         SetDirty("Departamentomunicipioid");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Departamentomunicipioid_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Departamentomunicipioid_N==1) ;
      }

      [  SoapElement( ElementName = "ZonasID" )]
      [  XmlElement( ElementName = "ZonasID"   )]
      public long gxTpr_Zonasid
      {
         get {
            return gxTv_SdtSolicitudes_Zonasid ;
         }

         set {
            gxTv_SdtSolicitudes_Zonasid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Zonasid = value;
            SetDirty("Zonasid");
         }

      }

      public void gxTv_SdtSolicitudes_Zonasid_SetNull( )
      {
         gxTv_SdtSolicitudes_Zonasid_N = 1;
         gxTv_SdtSolicitudes_Zonasid = 0;
         SetDirty("Zonasid");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Zonasid_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Zonasid_N==1) ;
      }

      [  SoapElement( ElementName = "SolicitudesDireccion" )]
      [  XmlElement( ElementName = "SolicitudesDireccion"   )]
      public string gxTpr_Solicitudesdireccion
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesdireccion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesdireccion = value;
            SetDirty("Solicitudesdireccion");
         }

      }

      [  SoapElement( ElementName = "SolicitudesAutoEnumerar" )]
      [  XmlElement( ElementName = "SolicitudesAutoEnumerar"   )]
      public short gxTpr_Solicitudesautoenumerar
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesautoenumerar ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesautoenumerar = value;
            SetDirty("Solicitudesautoenumerar");
         }

      }

      [  SoapElement( ElementName = "STMonedasId" )]
      [  XmlElement( ElementName = "STMonedasId"   )]
      public short gxTpr_Stmonedasid
      {
         get {
            return gxTv_SdtSolicitudes_Stmonedasid ;
         }

         set {
            gxTv_SdtSolicitudes_Stmonedasid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Stmonedasid = value;
            SetDirty("Stmonedasid");
         }

      }

      public void gxTv_SdtSolicitudes_Stmonedasid_SetNull( )
      {
         gxTv_SdtSolicitudes_Stmonedasid_N = 1;
         gxTv_SdtSolicitudes_Stmonedasid = 0;
         SetDirty("Stmonedasid");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Stmonedasid_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Stmonedasid_N==1) ;
      }

      [  SoapElement( ElementName = "STMonedasISO" )]
      [  XmlElement( ElementName = "STMonedasISO"   )]
      public string gxTpr_Stmonedasiso
      {
         get {
            return gxTv_SdtSolicitudes_Stmonedasiso ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Stmonedasiso = value;
            SetDirty("Stmonedasiso");
         }

      }

      [  SoapElement( ElementName = "SolicitudesLiqProf" )]
      [  XmlElement( ElementName = "SolicitudesLiqProf"   )]
      public long gxTpr_Solicitudesliqprof
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesliqprof ;
         }

         set {
            gxTv_SdtSolicitudes_Solicitudesliqprof_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesliqprof = value;
            SetDirty("Solicitudesliqprof");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesliqprof_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesliqprof_N = 1;
         gxTv_SdtSolicitudes_Solicitudesliqprof = 0;
         SetDirty("Solicitudesliqprof");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesliqprof_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Solicitudesliqprof_N==1) ;
      }

      [  SoapElement( ElementName = "SolicitudesLiqProv" )]
      [  XmlElement( ElementName = "SolicitudesLiqProv"   )]
      public long gxTpr_Solicitudesliqprov
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesliqprov ;
         }

         set {
            gxTv_SdtSolicitudes_Solicitudesliqprov_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesliqprov = value;
            SetDirty("Solicitudesliqprov");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesliqprov_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesliqprov_N = 1;
         gxTv_SdtSolicitudes_Solicitudesliqprov = 0;
         SetDirty("Solicitudesliqprov");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesliqprov_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Solicitudesliqprov_N==1) ;
      }

      [  SoapElement( ElementName = "Items" )]
      [  XmlArray( ElementName = "Items"  )]
      [  XmlArrayItemAttribute( ElementName= "Solicitudes.Items"  , IsNullable=false)]
      public GXBCLevelCollection<SdtSolicitudes_Items> gxTpr_Items_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtSolicitudes_Items == null )
            {
               gxTv_SdtSolicitudes_Items = new GXBCLevelCollection<SdtSolicitudes_Items>( context, "Solicitudes.Items", "AlmangoX");
            }
            return gxTv_SdtSolicitudes_Items ;
         }

         set {
            if ( gxTv_SdtSolicitudes_Items == null )
            {
               gxTv_SdtSolicitudes_Items = new GXBCLevelCollection<SdtSolicitudes_Items>( context, "Solicitudes.Items", "AlmangoX");
            }
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items = value;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public GXBCLevelCollection<SdtSolicitudes_Items> gxTpr_Items
      {
         get {
            if ( gxTv_SdtSolicitudes_Items == null )
            {
               gxTv_SdtSolicitudes_Items = new GXBCLevelCollection<SdtSolicitudes_Items>( context, "Solicitudes.Items", "AlmangoX");
            }
            sdtIsNull = 0;
            return gxTv_SdtSolicitudes_Items ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items = value;
            SetDirty("Items");
         }

      }

      public void gxTv_SdtSolicitudes_Items_SetNull( )
      {
         gxTv_SdtSolicitudes_Items = null;
         SetDirty("Items");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_IsNull( )
      {
         if ( gxTv_SdtSolicitudes_Items == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesCotizacion" )]
      [  XmlElement( ElementName = "SolicitudesCotizacion"   )]
      public decimal gxTpr_Solicitudescotizacion
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudescotizacion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudescotizacion = value;
            SetDirty("Solicitudescotizacion");
         }

      }

      [  SoapElement( ElementName = "SolicitudesTotal" )]
      [  XmlElement( ElementName = "SolicitudesTotal"   )]
      public decimal gxTpr_Solicitudestotal
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudestotal ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudestotal = value;
            SetDirty("Solicitudestotal");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudestotal_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudestotal = 0;
         SetDirty("Solicitudestotal");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudestotal_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudServicioSolCoti" )]
      [  XmlElement( ElementName = "SolicitudServicioSolCoti"   )]
      public string gxTpr_Solicitudserviciosolcoti
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudserviciosolcoti ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudserviciosolcoti = value;
            SetDirty("Solicitudserviciosolcoti");
         }

      }

      [  SoapElement( ElementName = "SolicitudServicioPFinal" )]
      [  XmlElement( ElementName = "SolicitudServicioPFinal"   )]
      public decimal gxTpr_Solicitudserviciopfinal
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudserviciopfinal ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudserviciopfinal = value;
            SetDirty("Solicitudserviciopfinal");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudserviciopfinal_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudserviciopfinal = 0;
         SetDirty("Solicitudserviciopfinal");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudserviciopfinal_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesDescuento" )]
      [  XmlElement( ElementName = "SolicitudesDescuento"   )]
      public decimal gxTpr_Solicitudesdescuento
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesdescuento ;
         }

         set {
            gxTv_SdtSolicitudes_Solicitudesdescuento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesdescuento = value;
            SetDirty("Solicitudesdescuento");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesdescuento_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesdescuento_N = 1;
         gxTv_SdtSolicitudes_Solicitudesdescuento = 0;
         SetDirty("Solicitudesdescuento");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesdescuento_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Solicitudesdescuento_N==1) ;
      }

      [  SoapElement( ElementName = "CuponId" )]
      [  XmlElement( ElementName = "CuponId"   )]
      public long gxTpr_Cuponid
      {
         get {
            return gxTv_SdtSolicitudes_Cuponid ;
         }

         set {
            gxTv_SdtSolicitudes_Cuponid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Cuponid = value;
            SetDirty("Cuponid");
         }

      }

      public void gxTv_SdtSolicitudes_Cuponid_SetNull( )
      {
         gxTv_SdtSolicitudes_Cuponid_N = 1;
         gxTv_SdtSolicitudes_Cuponid = 0;
         SetDirty("Cuponid");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Cuponid_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Cuponid_N==1) ;
      }

      [  SoapElement( ElementName = "CuponPercent" )]
      [  XmlElement( ElementName = "CuponPercent"   )]
      public short gxTpr_Cuponpercent
      {
         get {
            return gxTv_SdtSolicitudes_Cuponpercent ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Cuponpercent = value;
            SetDirty("Cuponpercent");
         }

      }

      [  SoapElement( ElementName = "SolicitudesDescuentoCupon" )]
      [  XmlElement( ElementName = "SolicitudesDescuentoCupon"   )]
      public decimal gxTpr_Solicitudesdescuentocupon
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesdescuentocupon ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesdescuentocupon = value;
            SetDirty("Solicitudesdescuentocupon");
         }

      }

      [  SoapElement( ElementName = "SolicitudesComisionMetodoPago" )]
      [  XmlElement( ElementName = "SolicitudesComisionMetodoPago"   )]
      public decimal gxTpr_Solicitudescomisionmetodopago
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudescomisionmetodopago ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudescomisionmetodopago = value;
            SetDirty("Solicitudescomisionmetodopago");
         }

      }

      [  SoapElement( ElementName = "EstadosSolTipo" )]
      [  XmlElement( ElementName = "EstadosSolTipo"   )]
      public string gxTpr_Estadossoltipo
      {
         get {
            return gxTv_SdtSolicitudes_Estadossoltipo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Estadossoltipo = value;
            SetDirty("Estadossoltipo");
         }

      }

      [  SoapElement( ElementName = "EstadosSolId" )]
      [  XmlElement( ElementName = "EstadosSolId"   )]
      public int gxTpr_Estadossolid
      {
         get {
            return gxTv_SdtSolicitudes_Estadossolid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Estadossolid = value;
            SetDirty("Estadossolid");
         }

      }

      [  SoapElement( ElementName = "EstadosSolNombre" )]
      [  XmlElement( ElementName = "EstadosSolNombre"   )]
      public string gxTpr_Estadossolnombre
      {
         get {
            return gxTv_SdtSolicitudes_Estadossolnombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Estadossolnombre = value;
            SetDirty("Estadossolnombre");
         }

      }

      [  SoapElement( ElementName = "SolicitudesOtros1" )]
      [  XmlElement( ElementName = "SolicitudesOtros1"   )]
      public string gxTpr_Solicitudesotros1
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesotros1 ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesotros1 = value;
            SetDirty("Solicitudesotros1");
         }

      }

      [  SoapElement( ElementName = "SolicitudesOtros2" )]
      [  XmlElement( ElementName = "SolicitudesOtros2"   )]
      public string gxTpr_Solicitudesotros2
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesotros2 ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesotros2 = value;
            SetDirty("Solicitudesotros2");
         }

      }

      [  SoapElement( ElementName = "SolicitudesOtros3" )]
      [  XmlElement( ElementName = "SolicitudesOtros3"   )]
      public string gxTpr_Solicitudesotros3
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesotros3 ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesotros3 = value;
            SetDirty("Solicitudesotros3");
         }

      }

      [  SoapElement( ElementName = "SolicitudesUsrAlta" )]
      [  XmlElement( ElementName = "SolicitudesUsrAlta"   )]
      public long gxTpr_Solicitudesusralta
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesusralta ;
         }

         set {
            gxTv_SdtSolicitudes_Solicitudesusralta_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesusralta = value;
            SetDirty("Solicitudesusralta");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesusralta_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesusralta_N = 1;
         gxTv_SdtSolicitudes_Solicitudesusralta = 0;
         SetDirty("Solicitudesusralta");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesusralta_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Solicitudesusralta_N==1) ;
      }

      [  SoapElement( ElementName = "SolicitudesUsrActualizacion" )]
      [  XmlElement( ElementName = "SolicitudesUsrActualizacion"   )]
      public long gxTpr_Solicitudesusractualizacion
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesusractualizacion ;
         }

         set {
            gxTv_SdtSolicitudes_Solicitudesusractualizacion_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesusractualizacion = value;
            SetDirty("Solicitudesusractualizacion");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesusractualizacion_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesusractualizacion_N = 1;
         gxTv_SdtSolicitudes_Solicitudesusractualizacion = 0;
         SetDirty("Solicitudesusractualizacion");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesusractualizacion_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Solicitudesusractualizacion_N==1) ;
      }

      [  SoapElement( ElementName = "SolicitudesFechaAlta" )]
      [  XmlElement( ElementName = "SolicitudesFechaAlta"  , IsNullable=true )]
      public string gxTpr_Solicitudesfechaalta_Nullable
      {
         get {
            if ( gxTv_SdtSolicitudes_Solicitudesfechaalta == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtSolicitudes_Solicitudesfechaalta).value ;
         }

         set {
            gxTv_SdtSolicitudes_Solicitudesfechaalta_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtSolicitudes_Solicitudesfechaalta = DateTime.MinValue;
            else
               gxTv_SdtSolicitudes_Solicitudesfechaalta = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Solicitudesfechaalta
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesfechaalta ;
         }

         set {
            gxTv_SdtSolicitudes_Solicitudesfechaalta_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesfechaalta = DateTimeUtil.ResetTime(value);
            SetDirty("Solicitudesfechaalta");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesfechaalta_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesfechaalta_N = 1;
         gxTv_SdtSolicitudes_Solicitudesfechaalta = (DateTime)(DateTime.MinValue);
         SetDirty("Solicitudesfechaalta");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesfechaalta_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Solicitudesfechaalta_N==1) ;
      }

      [  SoapElement( ElementName = "SolicitudesFechaActualizacion" )]
      [  XmlElement( ElementName = "SolicitudesFechaActualizacion"  , IsNullable=true )]
      public string gxTpr_Solicitudesfechaactualizacion_Nullable
      {
         get {
            if ( gxTv_SdtSolicitudes_Solicitudesfechaactualizacion == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtSolicitudes_Solicitudesfechaactualizacion).value ;
         }

         set {
            gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtSolicitudes_Solicitudesfechaactualizacion = DateTime.MinValue;
            else
               gxTv_SdtSolicitudes_Solicitudesfechaactualizacion = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Solicitudesfechaactualizacion
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesfechaactualizacion ;
         }

         set {
            gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesfechaactualizacion = value;
            SetDirty("Solicitudesfechaactualizacion");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_N = 1;
         gxTv_SdtSolicitudes_Solicitudesfechaactualizacion = (DateTime)(DateTime.MinValue);
         SetDirty("Solicitudesfechaactualizacion");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_N==1) ;
      }

      [  SoapElement( ElementName = "SolicitudesFechaInstalacion" )]
      [  XmlElement( ElementName = "SolicitudesFechaInstalacion"  , IsNullable=true )]
      public string gxTpr_Solicitudesfechainstalacion_Nullable
      {
         get {
            if ( gxTv_SdtSolicitudes_Solicitudesfechainstalacion == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtSolicitudes_Solicitudesfechainstalacion).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtSolicitudes_Solicitudesfechainstalacion = DateTime.MinValue;
            else
               gxTv_SdtSolicitudes_Solicitudesfechainstalacion = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Solicitudesfechainstalacion
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesfechainstalacion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesfechainstalacion = DateTimeUtil.ResetTime(value);
            SetDirty("Solicitudesfechainstalacion");
         }

      }

      [  SoapElement( ElementName = "SolicitudesHoraInstalacion" )]
      [  XmlElement( ElementName = "SolicitudesHoraInstalacion"   )]
      public string gxTpr_Solicitudeshorainstalacion
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudeshorainstalacion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudeshorainstalacion = value;
            SetDirty("Solicitudeshorainstalacion");
         }

      }

      [  SoapElement( ElementName = "SolicitudesComentario" )]
      [  XmlElement( ElementName = "SolicitudesComentario"   )]
      public string gxTpr_Solicitudescomentario
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudescomentario ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudescomentario = value;
            SetDirty("Solicitudescomentario");
         }

      }

      [  SoapElement( ElementName = "MetodoPagosID" )]
      [  XmlElement( ElementName = "MetodoPagosID"   )]
      public long gxTpr_Metodopagosid
      {
         get {
            return gxTv_SdtSolicitudes_Metodopagosid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Metodopagosid = value;
            SetDirty("Metodopagosid");
         }

      }

      [  SoapElement( ElementName = "MetodoPagosNombre" )]
      [  XmlElement( ElementName = "MetodoPagosNombre"   )]
      public string gxTpr_Metodopagosnombre
      {
         get {
            return gxTv_SdtSolicitudes_Metodopagosnombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Metodopagosnombre = value;
            SetDirty("Metodopagosnombre");
         }

      }

      [  SoapElement( ElementName = "SolicitudesNota" )]
      [  XmlElement( ElementName = "SolicitudesNota"   )]
      public string gxTpr_Solicitudesnota
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesnota ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesnota = value;
            SetDirty("Solicitudesnota");
         }

      }

      [  SoapElement( ElementName = "SolicitudesNotificacion" )]
      [  XmlElement( ElementName = "SolicitudesNotificacion"   )]
      public string gxTpr_Solicitudesnotificacion
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesnotificacion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesnotificacion = value;
            SetDirty("Solicitudesnotificacion");
         }

      }

      [  SoapElement( ElementName = "ProveedorID" )]
      [  XmlElement( ElementName = "ProveedorID"   )]
      public long gxTpr_Proveedorid
      {
         get {
            return gxTv_SdtSolicitudes_Proveedorid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Proveedorid = value;
            SetDirty("Proveedorid");
         }

      }

      [  SoapElement( ElementName = "ProveedorNombre" )]
      [  XmlElement( ElementName = "ProveedorNombre"   )]
      public string gxTpr_Proveedornombre
      {
         get {
            return gxTv_SdtSolicitudes_Proveedornombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Proveedornombre = value;
            SetDirty("Proveedornombre");
         }

      }

      [  SoapElement( ElementName = "ProveedorPagoDefault" )]
      [  XmlElement( ElementName = "ProveedorPagoDefault"   )]
      public string gxTpr_Proveedorpagodefault
      {
         get {
            return gxTv_SdtSolicitudes_Proveedorpagodefault ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Proveedorpagodefault = value;
            SetDirty("Proveedorpagodefault");
         }

      }

      [  SoapElement( ElementName = "STComerciosID" )]
      [  XmlElement( ElementName = "STComerciosID"   )]
      public long gxTpr_Stcomerciosid
      {
         get {
            return gxTv_SdtSolicitudes_Stcomerciosid ;
         }

         set {
            gxTv_SdtSolicitudes_Stcomerciosid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Stcomerciosid = value;
            SetDirty("Stcomerciosid");
         }

      }

      public void gxTv_SdtSolicitudes_Stcomerciosid_SetNull( )
      {
         gxTv_SdtSolicitudes_Stcomerciosid_N = 1;
         gxTv_SdtSolicitudes_Stcomerciosid = 0;
         SetDirty("Stcomerciosid");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Stcomerciosid_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Stcomerciosid_N==1) ;
      }

      [  SoapElement( ElementName = "STComerciosNombre" )]
      [  XmlElement( ElementName = "STComerciosNombre"   )]
      public string gxTpr_Stcomerciosnombre
      {
         get {
            return gxTv_SdtSolicitudes_Stcomerciosnombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Stcomerciosnombre = value;
            SetDirty("Stcomerciosnombre");
         }

      }

      [  SoapElement( ElementName = "STComerciosEstado" )]
      [  XmlElement( ElementName = "STComerciosEstado"   )]
      public string gxTpr_Stcomerciosestado
      {
         get {
            return gxTv_SdtSolicitudes_Stcomerciosestado ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Stcomerciosestado = value;
            SetDirty("Stcomerciosestado");
         }

      }

      [  SoapElement( ElementName = "SolicitudServicioOrigenPago" )]
      [  XmlElement( ElementName = "SolicitudServicioOrigenPago"   )]
      public string gxTpr_Solicitudservicioorigenpago
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudservicioorigenpago ;
         }

         set {
            gxTv_SdtSolicitudes_Solicitudservicioorigenpago_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudservicioorigenpago = value;
            SetDirty("Solicitudservicioorigenpago");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudservicioorigenpago_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudservicioorigenpago_N = 1;
         gxTv_SdtSolicitudes_Solicitudservicioorigenpago = "";
         SetDirty("Solicitudservicioorigenpago");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudservicioorigenpago_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Solicitudservicioorigenpago_N==1) ;
      }

      [  SoapElement( ElementName = "SolicitudesPagado" )]
      [  XmlElement( ElementName = "SolicitudesPagado"   )]
      public string gxTpr_Solicitudespagado
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudespagado ;
         }

         set {
            gxTv_SdtSolicitudes_Solicitudespagado_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudespagado = value;
            SetDirty("Solicitudespagado");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudespagado_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudespagado_N = 1;
         gxTv_SdtSolicitudes_Solicitudespagado = "";
         SetDirty("Solicitudespagado");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudespagado_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Solicitudespagado_N==1) ;
      }

      [  SoapElement( ElementName = "SolicitudServicioComProv" )]
      [  XmlElement( ElementName = "SolicitudServicioComProv"   )]
      public decimal gxTpr_Solicitudserviciocomprov
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudserviciocomprov ;
         }

         set {
            gxTv_SdtSolicitudes_Solicitudserviciocomprov_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudserviciocomprov = value;
            SetDirty("Solicitudserviciocomprov");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudserviciocomprov_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudserviciocomprov_N = 1;
         gxTv_SdtSolicitudes_Solicitudserviciocomprov = 0;
         SetDirty("Solicitudserviciocomprov");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudserviciocomprov_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Solicitudserviciocomprov_N==1) ;
      }

      [  SoapElement( ElementName = "SolicitudServicioComProvP" )]
      [  XmlElement( ElementName = "SolicitudServicioComProvP"   )]
      public decimal gxTpr_Solicitudserviciocomprovp
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudserviciocomprovp ;
         }

         set {
            gxTv_SdtSolicitudes_Solicitudserviciocomprovp_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudserviciocomprovp = value;
            SetDirty("Solicitudserviciocomprovp");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudserviciocomprovp_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudserviciocomprovp_N = 1;
         gxTv_SdtSolicitudes_Solicitudserviciocomprovp = 0;
         SetDirty("Solicitudserviciocomprovp");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudserviciocomprovp_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Solicitudserviciocomprovp_N==1) ;
      }

      [  SoapElement( ElementName = "SolicitudServicioComALM" )]
      [  XmlElement( ElementName = "SolicitudServicioComALM"   )]
      public decimal gxTpr_Solicitudserviciocomalm
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudserviciocomalm ;
         }

         set {
            gxTv_SdtSolicitudes_Solicitudserviciocomalm_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudserviciocomalm = value;
            SetDirty("Solicitudserviciocomalm");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudserviciocomalm_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudserviciocomalm_N = 1;
         gxTv_SdtSolicitudes_Solicitudserviciocomalm = 0;
         SetDirty("Solicitudserviciocomalm");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudserviciocomalm_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Solicitudserviciocomalm_N==1) ;
      }

      [  SoapElement( ElementName = "SolicitudServicioComALMP" )]
      [  XmlElement( ElementName = "SolicitudServicioComALMP"   )]
      public decimal gxTpr_Solicitudserviciocomalmp
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudserviciocomalmp ;
         }

         set {
            gxTv_SdtSolicitudes_Solicitudserviciocomalmp_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudserviciocomalmp = value;
            SetDirty("Solicitudserviciocomalmp");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudserviciocomalmp_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudserviciocomalmp_N = 1;
         gxTv_SdtSolicitudes_Solicitudserviciocomalmp = 0;
         SetDirty("Solicitudserviciocomalmp");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudserviciocomalmp_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Solicitudserviciocomalmp_N==1) ;
      }

      [  SoapElement( ElementName = "SolicitudServicioComPro" )]
      [  XmlElement( ElementName = "SolicitudServicioComPro"   )]
      public decimal gxTpr_Solicitudserviciocompro
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudserviciocompro ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudserviciocompro = value;
            SetDirty("Solicitudserviciocompro");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudserviciocompro_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudserviciocompro = 0;
         SetDirty("Solicitudserviciocompro");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudserviciocompro_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudServicioComProP" )]
      [  XmlElement( ElementName = "SolicitudServicioComProP"   )]
      public decimal gxTpr_Solicitudserviciocomprop
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudserviciocomprop ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudserviciocomprop = value;
            SetDirty("Solicitudserviciocomprop");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudserviciocomprop_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudserviciocomprop = 0;
         SetDirty("Solicitudserviciocomprop");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudserviciocomprop_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesCalComi" )]
      [  XmlElement( ElementName = "SolicitudesCalComi"   )]
      public bool gxTpr_Solicitudescalcomi
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudescalcomi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudescalcomi = value;
            SetDirty("Solicitudescalcomi");
         }

      }

      [  SoapElement( ElementName = "ProveedorNombreAux" )]
      [  XmlElement( ElementName = "ProveedorNombreAux"   )]
      public string gxTpr_Proveedornombreaux
      {
         get {
            return gxTv_SdtSolicitudes_Proveedornombreaux ;
         }

         set {
            gxTv_SdtSolicitudes_Proveedornombreaux_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Proveedornombreaux = value;
            SetDirty("Proveedornombreaux");
         }

      }

      public void gxTv_SdtSolicitudes_Proveedornombreaux_SetNull( )
      {
         gxTv_SdtSolicitudes_Proveedornombreaux_N = 1;
         gxTv_SdtSolicitudes_Proveedornombreaux = "";
         SetDirty("Proveedornombreaux");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Proveedornombreaux_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Proveedornombreaux_N==1) ;
      }

      [  SoapElement( ElementName = "SolicitudesSubTipo" )]
      [  XmlElement( ElementName = "SolicitudesSubTipo"   )]
      public string gxTpr_Solicitudessubtipo
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudessubtipo ;
         }

         set {
            gxTv_SdtSolicitudes_Solicitudessubtipo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudessubtipo = value;
            SetDirty("Solicitudessubtipo");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudessubtipo_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudessubtipo_N = 1;
         gxTv_SdtSolicitudes_Solicitudessubtipo = "";
         SetDirty("Solicitudessubtipo");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudessubtipo_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Solicitudessubtipo_N==1) ;
      }

      [  SoapElement( ElementName = "SolicitudesCostoXZona" )]
      [  XmlElement( ElementName = "SolicitudesCostoXZona"   )]
      public decimal gxTpr_Solicitudescostoxzona
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudescostoxzona ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudescostoxzona = value;
            SetDirty("Solicitudescostoxzona");
         }

      }

      [  SoapElement( ElementName = "SolicitudesCostoXZComAlm" )]
      [  XmlElement( ElementName = "SolicitudesCostoXZComAlm"   )]
      public decimal gxTpr_Solicitudescostoxzcomalm
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudescostoxzcomalm ;
         }

         set {
            gxTv_SdtSolicitudes_Solicitudescostoxzcomalm_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudescostoxzcomalm = value;
            SetDirty("Solicitudescostoxzcomalm");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudescostoxzcomalm_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudescostoxzcomalm_N = 1;
         gxTv_SdtSolicitudes_Solicitudescostoxzcomalm = 0;
         SetDirty("Solicitudescostoxzcomalm");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudescostoxzcomalm_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Solicitudescostoxzcomalm_N==1) ;
      }

      [  SoapElement( ElementName = "SolicitudesCostoXZComAlmP" )]
      [  XmlElement( ElementName = "SolicitudesCostoXZComAlmP"   )]
      public decimal gxTpr_Solicitudescostoxzcomalmp
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp ;
         }

         set {
            gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp = value;
            SetDirty("Solicitudescostoxzcomalmp");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp_N = 1;
         gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp = 0;
         SetDirty("Solicitudescostoxzcomalmp");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp_N==1) ;
      }

      [  SoapElement( ElementName = "SolicitudesCostoXZComProf" )]
      [  XmlElement( ElementName = "SolicitudesCostoXZComProf"   )]
      public decimal gxTpr_Solicitudescostoxzcomprof
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudescostoxzcomprof ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudescostoxzcomprof = value;
            SetDirty("Solicitudescostoxzcomprof");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudescostoxzcomprof_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudescostoxzcomprof = 0;
         SetDirty("Solicitudescostoxzcomprof");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudescostoxzcomprof_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesCostoXZComProfP" )]
      [  XmlElement( ElementName = "SolicitudesCostoXZComProfP"   )]
      public decimal gxTpr_Solicitudescostoxzcomprofp
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudescostoxzcomprofp ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudescostoxzcomprofp = value;
            SetDirty("Solicitudescostoxzcomprofp");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudescostoxzcomprofp_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudescostoxzcomprofp = 0;
         SetDirty("Solicitudescostoxzcomprofp");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudescostoxzcomprofp_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaId" )]
      [  XmlElement( ElementName = "MudanzaId"   )]
      public long gxTpr_Mudanzaid
      {
         get {
            return gxTv_SdtSolicitudes_Mudanzaid ;
         }

         set {
            gxTv_SdtSolicitudes_Mudanzaid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Mudanzaid = value;
            SetDirty("Mudanzaid");
         }

      }

      public void gxTv_SdtSolicitudes_Mudanzaid_SetNull( )
      {
         gxTv_SdtSolicitudes_Mudanzaid_N = 1;
         gxTv_SdtSolicitudes_Mudanzaid = 0;
         SetDirty("Mudanzaid");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Mudanzaid_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Mudanzaid_N==1) ;
      }

      [  SoapElement( ElementName = "MudanzaFechaServicio" )]
      [  XmlElement( ElementName = "MudanzaFechaServicio"  , IsNullable=true )]
      public string gxTpr_Mudanzafechaservicio_Nullable
      {
         get {
            if ( gxTv_SdtSolicitudes_Mudanzafechaservicio == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtSolicitudes_Mudanzafechaservicio).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtSolicitudes_Mudanzafechaservicio = DateTime.MinValue;
            else
               gxTv_SdtSolicitudes_Mudanzafechaservicio = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Mudanzafechaservicio
      {
         get {
            return gxTv_SdtSolicitudes_Mudanzafechaservicio ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Mudanzafechaservicio = DateTimeUtil.ResetTime(value);
            SetDirty("Mudanzafechaservicio");
         }

      }

      [  SoapElement( ElementName = "MudanzaDireccionOrigen" )]
      [  XmlElement( ElementName = "MudanzaDireccionOrigen"   )]
      public string gxTpr_Mudanzadireccionorigen
      {
         get {
            return gxTv_SdtSolicitudes_Mudanzadireccionorigen ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Mudanzadireccionorigen = value;
            SetDirty("Mudanzadireccionorigen");
         }

      }

      [  SoapElement( ElementName = "MudanzaDireccionDestino" )]
      [  XmlElement( ElementName = "MudanzaDireccionDestino"   )]
      public string gxTpr_Mudanzadirecciondestino
      {
         get {
            return gxTv_SdtSolicitudes_Mudanzadirecciondestino ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Mudanzadirecciondestino = value;
            SetDirty("Mudanzadirecciondestino");
         }

      }

      [  SoapElement( ElementName = "PostulacionesId" )]
      [  XmlElement( ElementName = "PostulacionesId"   )]
      public long gxTpr_Postulacionesid
      {
         get {
            return gxTv_SdtSolicitudes_Postulacionesid ;
         }

         set {
            gxTv_SdtSolicitudes_Postulacionesid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Postulacionesid = value;
            SetDirty("Postulacionesid");
         }

      }

      public void gxTv_SdtSolicitudes_Postulacionesid_SetNull( )
      {
         gxTv_SdtSolicitudes_Postulacionesid_N = 1;
         gxTv_SdtSolicitudes_Postulacionesid = 0;
         SetDirty("Postulacionesid");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Postulacionesid_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Postulacionesid_N==1) ;
      }

      [  SoapElement( ElementName = "SolicitudesDuplicado" )]
      [  XmlElement( ElementName = "SolicitudesDuplicado"   )]
      public long gxTpr_Solicitudesduplicado
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesduplicado ;
         }

         set {
            gxTv_SdtSolicitudes_Solicitudesduplicado_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesduplicado = value;
            SetDirty("Solicitudesduplicado");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesduplicado_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesduplicado_N = 1;
         gxTv_SdtSolicitudes_Solicitudesduplicado = 0;
         SetDirty("Solicitudesduplicado");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesduplicado_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Solicitudesduplicado_N==1) ;
      }

      [  SoapElement( ElementName = "SolicitudesSerialArchivo" )]
      [  XmlElement( ElementName = "SolicitudesSerialArchivo"   )]
      public short gxTpr_Solicitudesserialarchivo
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesserialarchivo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesserialarchivo = value;
            SetDirty("Solicitudesserialarchivo");
         }

      }

      [  SoapElement( ElementName = "CancelacionTipificacionId" )]
      [  XmlElement( ElementName = "CancelacionTipificacionId"   )]
      public long gxTpr_Cancelaciontipificacionid
      {
         get {
            return gxTv_SdtSolicitudes_Cancelaciontipificacionid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Cancelaciontipificacionid = value;
            SetDirty("Cancelaciontipificacionid");
         }

      }

      [  SoapElement( ElementName = "CancelacionTipificacionDescripcion" )]
      [  XmlElement( ElementName = "CancelacionTipificacionDescripcion"   )]
      public string gxTpr_Cancelaciontipificaciondescripcion
      {
         get {
            return gxTv_SdtSolicitudes_Cancelaciontipificaciondescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Cancelaciontipificaciondescripcion = value;
            SetDirty("Cancelaciontipificaciondescripcion");
         }

      }

      [  SoapElement( ElementName = "SolicitudesCostoPresupuesto" )]
      [  XmlElement( ElementName = "SolicitudesCostoPresupuesto"   )]
      public decimal gxTpr_Solicitudescostopresupuesto
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudescostopresupuesto ;
         }

         set {
            gxTv_SdtSolicitudes_Solicitudescostopresupuesto_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudescostopresupuesto = value;
            SetDirty("Solicitudescostopresupuesto");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudescostopresupuesto_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudescostopresupuesto_N = 1;
         gxTv_SdtSolicitudes_Solicitudescostopresupuesto = 0;
         SetDirty("Solicitudescostopresupuesto");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudescostopresupuesto_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Solicitudescostopresupuesto_N==1) ;
      }

      [  SoapElement( ElementName = "SolicitudesURLOrigen" )]
      [  XmlElement( ElementName = "SolicitudesURLOrigen"   )]
      public string gxTpr_Solicitudesurlorigen
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesurlorigen ;
         }

         set {
            gxTv_SdtSolicitudes_Solicitudesurlorigen_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesurlorigen = value;
            SetDirty("Solicitudesurlorigen");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesurlorigen_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesurlorigen_N = 1;
         gxTv_SdtSolicitudes_Solicitudesurlorigen = "";
         SetDirty("Solicitudesurlorigen");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesurlorigen_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Solicitudesurlorigen_N==1) ;
      }

      [  SoapElement( ElementName = "TicketId" )]
      [  XmlElement( ElementName = "TicketId"   )]
      public long gxTpr_Ticketid
      {
         get {
            return gxTv_SdtSolicitudes_Ticketid ;
         }

         set {
            gxTv_SdtSolicitudes_Ticketid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Ticketid = value;
            SetDirty("Ticketid");
         }

      }

      public void gxTv_SdtSolicitudes_Ticketid_SetNull( )
      {
         gxTv_SdtSolicitudes_Ticketid_N = 1;
         gxTv_SdtSolicitudes_Ticketid = 0;
         SetDirty("Ticketid");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Ticketid_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Ticketid_N==1) ;
      }

      [  SoapElement( ElementName = "TicketMotivoId" )]
      [  XmlElement( ElementName = "TicketMotivoId"   )]
      public long gxTpr_Ticketmotivoid
      {
         get {
            return gxTv_SdtSolicitudes_Ticketmotivoid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Ticketmotivoid = value;
            SetDirty("Ticketmotivoid");
         }

      }

      [  SoapElement( ElementName = "TicketMotivoDescripcion" )]
      [  XmlElement( ElementName = "TicketMotivoDescripcion"   )]
      public string gxTpr_Ticketmotivodescripcion
      {
         get {
            return gxTv_SdtSolicitudes_Ticketmotivodescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Ticketmotivodescripcion = value;
            SetDirty("Ticketmotivodescripcion");
         }

      }

      [  SoapElement( ElementName = "TicketComentario" )]
      [  XmlElement( ElementName = "TicketComentario"   )]
      public string gxTpr_Ticketcomentario
      {
         get {
            return gxTv_SdtSolicitudes_Ticketcomentario ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Ticketcomentario = value;
            SetDirty("Ticketcomentario");
         }

      }

      [  SoapElement( ElementName = "TicketAdjunto" )]
      [  XmlElement( ElementName = "TicketAdjunto"   )]
      public string gxTpr_Ticketadjunto
      {
         get {
            return gxTv_SdtSolicitudes_Ticketadjunto ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Ticketadjunto = value;
            SetDirty("Ticketadjunto");
         }

      }

      [  SoapElement( ElementName = "TicketEstado" )]
      [  XmlElement( ElementName = "TicketEstado"   )]
      public bool gxTpr_Ticketestado
      {
         get {
            return gxTv_SdtSolicitudes_Ticketestado ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Ticketestado = value;
            SetDirty("Ticketestado");
         }

      }

      [  SoapElement( ElementName = "TicketSolicitudId" )]
      [  XmlElement( ElementName = "TicketSolicitudId"   )]
      public long gxTpr_Ticketsolicitudid
      {
         get {
            return gxTv_SdtSolicitudes_Ticketsolicitudid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Ticketsolicitudid = value;
            SetDirty("Ticketsolicitudid");
         }

      }

      [  SoapElement( ElementName = "Archivo" )]
      [  XmlArray( ElementName = "Archivo"  )]
      [  XmlArrayItemAttribute( ElementName= "Solicitudes.Archivo"  , IsNullable=false)]
      public GXBCLevelCollection<SdtSolicitudes_Archivo> gxTpr_Archivo_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtSolicitudes_Archivo == null )
            {
               gxTv_SdtSolicitudes_Archivo = new GXBCLevelCollection<SdtSolicitudes_Archivo>( context, "Solicitudes.Archivo", "AlmangoX");
            }
            return gxTv_SdtSolicitudes_Archivo ;
         }

         set {
            if ( gxTv_SdtSolicitudes_Archivo == null )
            {
               gxTv_SdtSolicitudes_Archivo = new GXBCLevelCollection<SdtSolicitudes_Archivo>( context, "Solicitudes.Archivo", "AlmangoX");
            }
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Archivo = value;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public GXBCLevelCollection<SdtSolicitudes_Archivo> gxTpr_Archivo
      {
         get {
            if ( gxTv_SdtSolicitudes_Archivo == null )
            {
               gxTv_SdtSolicitudes_Archivo = new GXBCLevelCollection<SdtSolicitudes_Archivo>( context, "Solicitudes.Archivo", "AlmangoX");
            }
            sdtIsNull = 0;
            return gxTv_SdtSolicitudes_Archivo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Archivo = value;
            SetDirty("Archivo");
         }

      }

      public void gxTv_SdtSolicitudes_Archivo_SetNull( )
      {
         gxTv_SdtSolicitudes_Archivo = null;
         SetDirty("Archivo");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Archivo_IsNull( )
      {
         if ( gxTv_SdtSolicitudes_Archivo == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtSolicitudes_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtSolicitudes_Mode_SetNull( )
      {
         gxTv_SdtSolicitudes_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtSolicitudes_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtSolicitudes_Initialized_SetNull( )
      {
         gxTv_SdtSolicitudes_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesID_Z" )]
      [  XmlElement( ElementName = "SolicitudesID_Z"   )]
      public long gxTpr_Solicitudesid_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesid_Z = value;
            SetDirty("Solicitudesid_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesid_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesid_Z = 0;
         SetDirty("Solicitudesid_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesNombre_Z" )]
      [  XmlElement( ElementName = "SolicitudesNombre_Z"   )]
      public string gxTpr_Solicitudesnombre_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesnombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesnombre_Z = value;
            SetDirty("Solicitudesnombre_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesnombre_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesnombre_Z = "";
         SetDirty("Solicitudesnombre_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesnombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesTelefono_Z" )]
      [  XmlElement( ElementName = "SolicitudesTelefono_Z"   )]
      public string gxTpr_Solicitudestelefono_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudestelefono_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudestelefono_Z = value;
            SetDirty("Solicitudestelefono_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudestelefono_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudestelefono_Z = "";
         SetDirty("Solicitudestelefono_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudestelefono_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesMail_Z" )]
      [  XmlElement( ElementName = "SolicitudesMail_Z"   )]
      public string gxTpr_Solicitudesmail_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesmail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesmail_Z = value;
            SetDirty("Solicitudesmail_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesmail_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesmail_Z = "";
         SetDirty("Solicitudesmail_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesmail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisID_Z" )]
      [  XmlElement( ElementName = "PaisID_Z"   )]
      public string gxTpr_Paisid_Z
      {
         get {
            return gxTv_SdtSolicitudes_Paisid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Paisid_Z = value;
            SetDirty("Paisid_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Paisid_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Paisid_Z = "";
         SetDirty("Paisid_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Paisid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DepartamentoId_Z" )]
      [  XmlElement( ElementName = "DepartamentoId_Z"   )]
      public long gxTpr_Departamentoid_Z
      {
         get {
            return gxTv_SdtSolicitudes_Departamentoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Departamentoid_Z = value;
            SetDirty("Departamentoid_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Departamentoid_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Departamentoid_Z = 0;
         SetDirty("Departamentoid_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Departamentoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DepartamentoMunicipioId_Z" )]
      [  XmlElement( ElementName = "DepartamentoMunicipioId_Z"   )]
      public long gxTpr_Departamentomunicipioid_Z
      {
         get {
            return gxTv_SdtSolicitudes_Departamentomunicipioid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Departamentomunicipioid_Z = value;
            SetDirty("Departamentomunicipioid_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Departamentomunicipioid_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Departamentomunicipioid_Z = 0;
         SetDirty("Departamentomunicipioid_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Departamentomunicipioid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ZonasID_Z" )]
      [  XmlElement( ElementName = "ZonasID_Z"   )]
      public long gxTpr_Zonasid_Z
      {
         get {
            return gxTv_SdtSolicitudes_Zonasid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Zonasid_Z = value;
            SetDirty("Zonasid_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Zonasid_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Zonasid_Z = 0;
         SetDirty("Zonasid_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Zonasid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesDireccion_Z" )]
      [  XmlElement( ElementName = "SolicitudesDireccion_Z"   )]
      public string gxTpr_Solicitudesdireccion_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesdireccion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesdireccion_Z = value;
            SetDirty("Solicitudesdireccion_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesdireccion_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesdireccion_Z = "";
         SetDirty("Solicitudesdireccion_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesdireccion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesAutoEnumerar_Z" )]
      [  XmlElement( ElementName = "SolicitudesAutoEnumerar_Z"   )]
      public short gxTpr_Solicitudesautoenumerar_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesautoenumerar_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesautoenumerar_Z = value;
            SetDirty("Solicitudesautoenumerar_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesautoenumerar_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesautoenumerar_Z = 0;
         SetDirty("Solicitudesautoenumerar_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesautoenumerar_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "STMonedasId_Z" )]
      [  XmlElement( ElementName = "STMonedasId_Z"   )]
      public short gxTpr_Stmonedasid_Z
      {
         get {
            return gxTv_SdtSolicitudes_Stmonedasid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Stmonedasid_Z = value;
            SetDirty("Stmonedasid_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Stmonedasid_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Stmonedasid_Z = 0;
         SetDirty("Stmonedasid_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Stmonedasid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "STMonedasISO_Z" )]
      [  XmlElement( ElementName = "STMonedasISO_Z"   )]
      public string gxTpr_Stmonedasiso_Z
      {
         get {
            return gxTv_SdtSolicitudes_Stmonedasiso_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Stmonedasiso_Z = value;
            SetDirty("Stmonedasiso_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Stmonedasiso_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Stmonedasiso_Z = "";
         SetDirty("Stmonedasiso_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Stmonedasiso_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesLiqProf_Z" )]
      [  XmlElement( ElementName = "SolicitudesLiqProf_Z"   )]
      public long gxTpr_Solicitudesliqprof_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesliqprof_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesliqprof_Z = value;
            SetDirty("Solicitudesliqprof_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesliqprof_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesliqprof_Z = 0;
         SetDirty("Solicitudesliqprof_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesliqprof_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesLiqProv_Z" )]
      [  XmlElement( ElementName = "SolicitudesLiqProv_Z"   )]
      public long gxTpr_Solicitudesliqprov_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesliqprov_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesliqprov_Z = value;
            SetDirty("Solicitudesliqprov_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesliqprov_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesliqprov_Z = 0;
         SetDirty("Solicitudesliqprov_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesliqprov_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesCotizacion_Z" )]
      [  XmlElement( ElementName = "SolicitudesCotizacion_Z"   )]
      public decimal gxTpr_Solicitudescotizacion_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudescotizacion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudescotizacion_Z = value;
            SetDirty("Solicitudescotizacion_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudescotizacion_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudescotizacion_Z = 0;
         SetDirty("Solicitudescotizacion_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudescotizacion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesTotal_Z" )]
      [  XmlElement( ElementName = "SolicitudesTotal_Z"   )]
      public decimal gxTpr_Solicitudestotal_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudestotal_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudestotal_Z = value;
            SetDirty("Solicitudestotal_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudestotal_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudestotal_Z = 0;
         SetDirty("Solicitudestotal_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudestotal_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudServicioSolCoti_Z" )]
      [  XmlElement( ElementName = "SolicitudServicioSolCoti_Z"   )]
      public string gxTpr_Solicitudserviciosolcoti_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudserviciosolcoti_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudserviciosolcoti_Z = value;
            SetDirty("Solicitudserviciosolcoti_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudserviciosolcoti_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudserviciosolcoti_Z = "";
         SetDirty("Solicitudserviciosolcoti_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudserviciosolcoti_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudServicioPFinal_Z" )]
      [  XmlElement( ElementName = "SolicitudServicioPFinal_Z"   )]
      public decimal gxTpr_Solicitudserviciopfinal_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudserviciopfinal_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudserviciopfinal_Z = value;
            SetDirty("Solicitudserviciopfinal_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudserviciopfinal_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudserviciopfinal_Z = 0;
         SetDirty("Solicitudserviciopfinal_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudserviciopfinal_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesDescuento_Z" )]
      [  XmlElement( ElementName = "SolicitudesDescuento_Z"   )]
      public decimal gxTpr_Solicitudesdescuento_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesdescuento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesdescuento_Z = value;
            SetDirty("Solicitudesdescuento_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesdescuento_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesdescuento_Z = 0;
         SetDirty("Solicitudesdescuento_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesdescuento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CuponId_Z" )]
      [  XmlElement( ElementName = "CuponId_Z"   )]
      public long gxTpr_Cuponid_Z
      {
         get {
            return gxTv_SdtSolicitudes_Cuponid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Cuponid_Z = value;
            SetDirty("Cuponid_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Cuponid_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Cuponid_Z = 0;
         SetDirty("Cuponid_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Cuponid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CuponPercent_Z" )]
      [  XmlElement( ElementName = "CuponPercent_Z"   )]
      public short gxTpr_Cuponpercent_Z
      {
         get {
            return gxTv_SdtSolicitudes_Cuponpercent_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Cuponpercent_Z = value;
            SetDirty("Cuponpercent_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Cuponpercent_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Cuponpercent_Z = 0;
         SetDirty("Cuponpercent_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Cuponpercent_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesDescuentoCupon_Z" )]
      [  XmlElement( ElementName = "SolicitudesDescuentoCupon_Z"   )]
      public decimal gxTpr_Solicitudesdescuentocupon_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesdescuentocupon_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesdescuentocupon_Z = value;
            SetDirty("Solicitudesdescuentocupon_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesdescuentocupon_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesdescuentocupon_Z = 0;
         SetDirty("Solicitudesdescuentocupon_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesdescuentocupon_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesComisionMetodoPago_Z" )]
      [  XmlElement( ElementName = "SolicitudesComisionMetodoPago_Z"   )]
      public decimal gxTpr_Solicitudescomisionmetodopago_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudescomisionmetodopago_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudescomisionmetodopago_Z = value;
            SetDirty("Solicitudescomisionmetodopago_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudescomisionmetodopago_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudescomisionmetodopago_Z = 0;
         SetDirty("Solicitudescomisionmetodopago_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudescomisionmetodopago_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EstadosSolTipo_Z" )]
      [  XmlElement( ElementName = "EstadosSolTipo_Z"   )]
      public string gxTpr_Estadossoltipo_Z
      {
         get {
            return gxTv_SdtSolicitudes_Estadossoltipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Estadossoltipo_Z = value;
            SetDirty("Estadossoltipo_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Estadossoltipo_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Estadossoltipo_Z = "";
         SetDirty("Estadossoltipo_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Estadossoltipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EstadosSolId_Z" )]
      [  XmlElement( ElementName = "EstadosSolId_Z"   )]
      public int gxTpr_Estadossolid_Z
      {
         get {
            return gxTv_SdtSolicitudes_Estadossolid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Estadossolid_Z = value;
            SetDirty("Estadossolid_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Estadossolid_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Estadossolid_Z = 0;
         SetDirty("Estadossolid_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Estadossolid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EstadosSolNombre_Z" )]
      [  XmlElement( ElementName = "EstadosSolNombre_Z"   )]
      public string gxTpr_Estadossolnombre_Z
      {
         get {
            return gxTv_SdtSolicitudes_Estadossolnombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Estadossolnombre_Z = value;
            SetDirty("Estadossolnombre_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Estadossolnombre_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Estadossolnombre_Z = "";
         SetDirty("Estadossolnombre_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Estadossolnombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesOtros1_Z" )]
      [  XmlElement( ElementName = "SolicitudesOtros1_Z"   )]
      public string gxTpr_Solicitudesotros1_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesotros1_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesotros1_Z = value;
            SetDirty("Solicitudesotros1_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesotros1_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesotros1_Z = "";
         SetDirty("Solicitudesotros1_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesotros1_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesOtros2_Z" )]
      [  XmlElement( ElementName = "SolicitudesOtros2_Z"   )]
      public string gxTpr_Solicitudesotros2_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesotros2_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesotros2_Z = value;
            SetDirty("Solicitudesotros2_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesotros2_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesotros2_Z = "";
         SetDirty("Solicitudesotros2_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesotros2_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesOtros3_Z" )]
      [  XmlElement( ElementName = "SolicitudesOtros3_Z"   )]
      public string gxTpr_Solicitudesotros3_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesotros3_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesotros3_Z = value;
            SetDirty("Solicitudesotros3_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesotros3_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesotros3_Z = "";
         SetDirty("Solicitudesotros3_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesotros3_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesUsrAlta_Z" )]
      [  XmlElement( ElementName = "SolicitudesUsrAlta_Z"   )]
      public long gxTpr_Solicitudesusralta_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesusralta_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesusralta_Z = value;
            SetDirty("Solicitudesusralta_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesusralta_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesusralta_Z = 0;
         SetDirty("Solicitudesusralta_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesusralta_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesUsrActualizacion_Z" )]
      [  XmlElement( ElementName = "SolicitudesUsrActualizacion_Z"   )]
      public long gxTpr_Solicitudesusractualizacion_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesusractualizacion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesusractualizacion_Z = value;
            SetDirty("Solicitudesusractualizacion_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesusractualizacion_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesusractualizacion_Z = 0;
         SetDirty("Solicitudesusractualizacion_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesusractualizacion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesFechaAlta_Z" )]
      [  XmlElement( ElementName = "SolicitudesFechaAlta_Z"  , IsNullable=true )]
      public string gxTpr_Solicitudesfechaalta_Z_Nullable
      {
         get {
            if ( gxTv_SdtSolicitudes_Solicitudesfechaalta_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtSolicitudes_Solicitudesfechaalta_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtSolicitudes_Solicitudesfechaalta_Z = DateTime.MinValue;
            else
               gxTv_SdtSolicitudes_Solicitudesfechaalta_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Solicitudesfechaalta_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesfechaalta_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesfechaalta_Z = DateTimeUtil.ResetTime(value);
            SetDirty("Solicitudesfechaalta_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesfechaalta_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesfechaalta_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Solicitudesfechaalta_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesfechaalta_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesFechaActualizacion_Z" )]
      [  XmlElement( ElementName = "SolicitudesFechaActualizacion_Z"  , IsNullable=true )]
      public string gxTpr_Solicitudesfechaactualizacion_Z_Nullable
      {
         get {
            if ( gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_Z = DateTime.MinValue;
            else
               gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Solicitudesfechaactualizacion_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_Z = value;
            SetDirty("Solicitudesfechaactualizacion_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Solicitudesfechaactualizacion_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesFechaInstalacion_Z" )]
      [  XmlElement( ElementName = "SolicitudesFechaInstalacion_Z"  , IsNullable=true )]
      public string gxTpr_Solicitudesfechainstalacion_Z_Nullable
      {
         get {
            if ( gxTv_SdtSolicitudes_Solicitudesfechainstalacion_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtSolicitudes_Solicitudesfechainstalacion_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtSolicitudes_Solicitudesfechainstalacion_Z = DateTime.MinValue;
            else
               gxTv_SdtSolicitudes_Solicitudesfechainstalacion_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Solicitudesfechainstalacion_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesfechainstalacion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesfechainstalacion_Z = DateTimeUtil.ResetTime(value);
            SetDirty("Solicitudesfechainstalacion_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesfechainstalacion_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesfechainstalacion_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Solicitudesfechainstalacion_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesfechainstalacion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesHoraInstalacion_Z" )]
      [  XmlElement( ElementName = "SolicitudesHoraInstalacion_Z"   )]
      public string gxTpr_Solicitudeshorainstalacion_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudeshorainstalacion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudeshorainstalacion_Z = value;
            SetDirty("Solicitudeshorainstalacion_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudeshorainstalacion_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudeshorainstalacion_Z = "";
         SetDirty("Solicitudeshorainstalacion_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudeshorainstalacion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MetodoPagosID_Z" )]
      [  XmlElement( ElementName = "MetodoPagosID_Z"   )]
      public long gxTpr_Metodopagosid_Z
      {
         get {
            return gxTv_SdtSolicitudes_Metodopagosid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Metodopagosid_Z = value;
            SetDirty("Metodopagosid_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Metodopagosid_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Metodopagosid_Z = 0;
         SetDirty("Metodopagosid_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Metodopagosid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MetodoPagosNombre_Z" )]
      [  XmlElement( ElementName = "MetodoPagosNombre_Z"   )]
      public string gxTpr_Metodopagosnombre_Z
      {
         get {
            return gxTv_SdtSolicitudes_Metodopagosnombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Metodopagosnombre_Z = value;
            SetDirty("Metodopagosnombre_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Metodopagosnombre_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Metodopagosnombre_Z = "";
         SetDirty("Metodopagosnombre_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Metodopagosnombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesNota_Z" )]
      [  XmlElement( ElementName = "SolicitudesNota_Z"   )]
      public string gxTpr_Solicitudesnota_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesnota_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesnota_Z = value;
            SetDirty("Solicitudesnota_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesnota_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesnota_Z = "";
         SetDirty("Solicitudesnota_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesnota_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesNotificacion_Z" )]
      [  XmlElement( ElementName = "SolicitudesNotificacion_Z"   )]
      public string gxTpr_Solicitudesnotificacion_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesnotificacion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesnotificacion_Z = value;
            SetDirty("Solicitudesnotificacion_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesnotificacion_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesnotificacion_Z = "";
         SetDirty("Solicitudesnotificacion_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesnotificacion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorID_Z" )]
      [  XmlElement( ElementName = "ProveedorID_Z"   )]
      public long gxTpr_Proveedorid_Z
      {
         get {
            return gxTv_SdtSolicitudes_Proveedorid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Proveedorid_Z = value;
            SetDirty("Proveedorid_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Proveedorid_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Proveedorid_Z = 0;
         SetDirty("Proveedorid_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Proveedorid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorNombre_Z" )]
      [  XmlElement( ElementName = "ProveedorNombre_Z"   )]
      public string gxTpr_Proveedornombre_Z
      {
         get {
            return gxTv_SdtSolicitudes_Proveedornombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Proveedornombre_Z = value;
            SetDirty("Proveedornombre_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Proveedornombre_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Proveedornombre_Z = "";
         SetDirty("Proveedornombre_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Proveedornombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorPagoDefault_Z" )]
      [  XmlElement( ElementName = "ProveedorPagoDefault_Z"   )]
      public string gxTpr_Proveedorpagodefault_Z
      {
         get {
            return gxTv_SdtSolicitudes_Proveedorpagodefault_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Proveedorpagodefault_Z = value;
            SetDirty("Proveedorpagodefault_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Proveedorpagodefault_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Proveedorpagodefault_Z = "";
         SetDirty("Proveedorpagodefault_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Proveedorpagodefault_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "STComerciosID_Z" )]
      [  XmlElement( ElementName = "STComerciosID_Z"   )]
      public long gxTpr_Stcomerciosid_Z
      {
         get {
            return gxTv_SdtSolicitudes_Stcomerciosid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Stcomerciosid_Z = value;
            SetDirty("Stcomerciosid_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Stcomerciosid_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Stcomerciosid_Z = 0;
         SetDirty("Stcomerciosid_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Stcomerciosid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "STComerciosNombre_Z" )]
      [  XmlElement( ElementName = "STComerciosNombre_Z"   )]
      public string gxTpr_Stcomerciosnombre_Z
      {
         get {
            return gxTv_SdtSolicitudes_Stcomerciosnombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Stcomerciosnombre_Z = value;
            SetDirty("Stcomerciosnombre_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Stcomerciosnombre_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Stcomerciosnombre_Z = "";
         SetDirty("Stcomerciosnombre_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Stcomerciosnombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "STComerciosEstado_Z" )]
      [  XmlElement( ElementName = "STComerciosEstado_Z"   )]
      public string gxTpr_Stcomerciosestado_Z
      {
         get {
            return gxTv_SdtSolicitudes_Stcomerciosestado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Stcomerciosestado_Z = value;
            SetDirty("Stcomerciosestado_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Stcomerciosestado_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Stcomerciosestado_Z = "";
         SetDirty("Stcomerciosestado_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Stcomerciosestado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudServicioOrigenPago_Z" )]
      [  XmlElement( ElementName = "SolicitudServicioOrigenPago_Z"   )]
      public string gxTpr_Solicitudservicioorigenpago_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudservicioorigenpago_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudservicioorigenpago_Z = value;
            SetDirty("Solicitudservicioorigenpago_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudservicioorigenpago_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudservicioorigenpago_Z = "";
         SetDirty("Solicitudservicioorigenpago_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudservicioorigenpago_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesPagado_Z" )]
      [  XmlElement( ElementName = "SolicitudesPagado_Z"   )]
      public string gxTpr_Solicitudespagado_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudespagado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudespagado_Z = value;
            SetDirty("Solicitudespagado_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudespagado_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudespagado_Z = "";
         SetDirty("Solicitudespagado_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudespagado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudServicioComProv_Z" )]
      [  XmlElement( ElementName = "SolicitudServicioComProv_Z"   )]
      public decimal gxTpr_Solicitudserviciocomprov_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudserviciocomprov_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudserviciocomprov_Z = value;
            SetDirty("Solicitudserviciocomprov_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudserviciocomprov_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudserviciocomprov_Z = 0;
         SetDirty("Solicitudserviciocomprov_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudserviciocomprov_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudServicioComProvP_Z" )]
      [  XmlElement( ElementName = "SolicitudServicioComProvP_Z"   )]
      public decimal gxTpr_Solicitudserviciocomprovp_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudserviciocomprovp_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudserviciocomprovp_Z = value;
            SetDirty("Solicitudserviciocomprovp_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudserviciocomprovp_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudserviciocomprovp_Z = 0;
         SetDirty("Solicitudserviciocomprovp_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudserviciocomprovp_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudServicioComALM_Z" )]
      [  XmlElement( ElementName = "SolicitudServicioComALM_Z"   )]
      public decimal gxTpr_Solicitudserviciocomalm_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudserviciocomalm_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudserviciocomalm_Z = value;
            SetDirty("Solicitudserviciocomalm_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudserviciocomalm_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudserviciocomalm_Z = 0;
         SetDirty("Solicitudserviciocomalm_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudserviciocomalm_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudServicioComALMP_Z" )]
      [  XmlElement( ElementName = "SolicitudServicioComALMP_Z"   )]
      public decimal gxTpr_Solicitudserviciocomalmp_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudserviciocomalmp_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudserviciocomalmp_Z = value;
            SetDirty("Solicitudserviciocomalmp_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudserviciocomalmp_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudserviciocomalmp_Z = 0;
         SetDirty("Solicitudserviciocomalmp_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudserviciocomalmp_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudServicioComPro_Z" )]
      [  XmlElement( ElementName = "SolicitudServicioComPro_Z"   )]
      public decimal gxTpr_Solicitudserviciocompro_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudserviciocompro_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudserviciocompro_Z = value;
            SetDirty("Solicitudserviciocompro_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudserviciocompro_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudserviciocompro_Z = 0;
         SetDirty("Solicitudserviciocompro_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudserviciocompro_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudServicioComProP_Z" )]
      [  XmlElement( ElementName = "SolicitudServicioComProP_Z"   )]
      public decimal gxTpr_Solicitudserviciocomprop_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudserviciocomprop_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudserviciocomprop_Z = value;
            SetDirty("Solicitudserviciocomprop_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudserviciocomprop_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudserviciocomprop_Z = 0;
         SetDirty("Solicitudserviciocomprop_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudserviciocomprop_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesCalComi_Z" )]
      [  XmlElement( ElementName = "SolicitudesCalComi_Z"   )]
      public bool gxTpr_Solicitudescalcomi_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudescalcomi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudescalcomi_Z = value;
            SetDirty("Solicitudescalcomi_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudescalcomi_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudescalcomi_Z = false;
         SetDirty("Solicitudescalcomi_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudescalcomi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorNombreAux_Z" )]
      [  XmlElement( ElementName = "ProveedorNombreAux_Z"   )]
      public string gxTpr_Proveedornombreaux_Z
      {
         get {
            return gxTv_SdtSolicitudes_Proveedornombreaux_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Proveedornombreaux_Z = value;
            SetDirty("Proveedornombreaux_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Proveedornombreaux_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Proveedornombreaux_Z = "";
         SetDirty("Proveedornombreaux_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Proveedornombreaux_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesSubTipo_Z" )]
      [  XmlElement( ElementName = "SolicitudesSubTipo_Z"   )]
      public string gxTpr_Solicitudessubtipo_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudessubtipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudessubtipo_Z = value;
            SetDirty("Solicitudessubtipo_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudessubtipo_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudessubtipo_Z = "";
         SetDirty("Solicitudessubtipo_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudessubtipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesCostoXZona_Z" )]
      [  XmlElement( ElementName = "SolicitudesCostoXZona_Z"   )]
      public decimal gxTpr_Solicitudescostoxzona_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudescostoxzona_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudescostoxzona_Z = value;
            SetDirty("Solicitudescostoxzona_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudescostoxzona_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudescostoxzona_Z = 0;
         SetDirty("Solicitudescostoxzona_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudescostoxzona_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesCostoXZComAlm_Z" )]
      [  XmlElement( ElementName = "SolicitudesCostoXZComAlm_Z"   )]
      public decimal gxTpr_Solicitudescostoxzcomalm_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudescostoxzcomalm_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudescostoxzcomalm_Z = value;
            SetDirty("Solicitudescostoxzcomalm_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudescostoxzcomalm_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudescostoxzcomalm_Z = 0;
         SetDirty("Solicitudescostoxzcomalm_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudescostoxzcomalm_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesCostoXZComAlmP_Z" )]
      [  XmlElement( ElementName = "SolicitudesCostoXZComAlmP_Z"   )]
      public decimal gxTpr_Solicitudescostoxzcomalmp_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp_Z = value;
            SetDirty("Solicitudescostoxzcomalmp_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp_Z = 0;
         SetDirty("Solicitudescostoxzcomalmp_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesCostoXZComProf_Z" )]
      [  XmlElement( ElementName = "SolicitudesCostoXZComProf_Z"   )]
      public decimal gxTpr_Solicitudescostoxzcomprof_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudescostoxzcomprof_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudescostoxzcomprof_Z = value;
            SetDirty("Solicitudescostoxzcomprof_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudescostoxzcomprof_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudescostoxzcomprof_Z = 0;
         SetDirty("Solicitudescostoxzcomprof_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudescostoxzcomprof_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesCostoXZComProfP_Z" )]
      [  XmlElement( ElementName = "SolicitudesCostoXZComProfP_Z"   )]
      public decimal gxTpr_Solicitudescostoxzcomprofp_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudescostoxzcomprofp_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudescostoxzcomprofp_Z = value;
            SetDirty("Solicitudescostoxzcomprofp_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudescostoxzcomprofp_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudescostoxzcomprofp_Z = 0;
         SetDirty("Solicitudescostoxzcomprofp_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudescostoxzcomprofp_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaId_Z" )]
      [  XmlElement( ElementName = "MudanzaId_Z"   )]
      public long gxTpr_Mudanzaid_Z
      {
         get {
            return gxTv_SdtSolicitudes_Mudanzaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Mudanzaid_Z = value;
            SetDirty("Mudanzaid_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Mudanzaid_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Mudanzaid_Z = 0;
         SetDirty("Mudanzaid_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Mudanzaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaFechaServicio_Z" )]
      [  XmlElement( ElementName = "MudanzaFechaServicio_Z"  , IsNullable=true )]
      public string gxTpr_Mudanzafechaservicio_Z_Nullable
      {
         get {
            if ( gxTv_SdtSolicitudes_Mudanzafechaservicio_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtSolicitudes_Mudanzafechaservicio_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtSolicitudes_Mudanzafechaservicio_Z = DateTime.MinValue;
            else
               gxTv_SdtSolicitudes_Mudanzafechaservicio_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Mudanzafechaservicio_Z
      {
         get {
            return gxTv_SdtSolicitudes_Mudanzafechaservicio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Mudanzafechaservicio_Z = DateTimeUtil.ResetTime(value);
            SetDirty("Mudanzafechaservicio_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Mudanzafechaservicio_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Mudanzafechaservicio_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Mudanzafechaservicio_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Mudanzafechaservicio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaDireccionOrigen_Z" )]
      [  XmlElement( ElementName = "MudanzaDireccionOrigen_Z"   )]
      public string gxTpr_Mudanzadireccionorigen_Z
      {
         get {
            return gxTv_SdtSolicitudes_Mudanzadireccionorigen_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Mudanzadireccionorigen_Z = value;
            SetDirty("Mudanzadireccionorigen_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Mudanzadireccionorigen_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Mudanzadireccionorigen_Z = "";
         SetDirty("Mudanzadireccionorigen_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Mudanzadireccionorigen_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaDireccionDestino_Z" )]
      [  XmlElement( ElementName = "MudanzaDireccionDestino_Z"   )]
      public string gxTpr_Mudanzadirecciondestino_Z
      {
         get {
            return gxTv_SdtSolicitudes_Mudanzadirecciondestino_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Mudanzadirecciondestino_Z = value;
            SetDirty("Mudanzadirecciondestino_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Mudanzadirecciondestino_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Mudanzadirecciondestino_Z = "";
         SetDirty("Mudanzadirecciondestino_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Mudanzadirecciondestino_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionesId_Z" )]
      [  XmlElement( ElementName = "PostulacionesId_Z"   )]
      public long gxTpr_Postulacionesid_Z
      {
         get {
            return gxTv_SdtSolicitudes_Postulacionesid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Postulacionesid_Z = value;
            SetDirty("Postulacionesid_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Postulacionesid_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Postulacionesid_Z = 0;
         SetDirty("Postulacionesid_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Postulacionesid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesDuplicado_Z" )]
      [  XmlElement( ElementName = "SolicitudesDuplicado_Z"   )]
      public long gxTpr_Solicitudesduplicado_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesduplicado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesduplicado_Z = value;
            SetDirty("Solicitudesduplicado_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesduplicado_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesduplicado_Z = 0;
         SetDirty("Solicitudesduplicado_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesduplicado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesSerialArchivo_Z" )]
      [  XmlElement( ElementName = "SolicitudesSerialArchivo_Z"   )]
      public short gxTpr_Solicitudesserialarchivo_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesserialarchivo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesserialarchivo_Z = value;
            SetDirty("Solicitudesserialarchivo_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesserialarchivo_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesserialarchivo_Z = 0;
         SetDirty("Solicitudesserialarchivo_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesserialarchivo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CancelacionTipificacionId_Z" )]
      [  XmlElement( ElementName = "CancelacionTipificacionId_Z"   )]
      public long gxTpr_Cancelaciontipificacionid_Z
      {
         get {
            return gxTv_SdtSolicitudes_Cancelaciontipificacionid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Cancelaciontipificacionid_Z = value;
            SetDirty("Cancelaciontipificacionid_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Cancelaciontipificacionid_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Cancelaciontipificacionid_Z = 0;
         SetDirty("Cancelaciontipificacionid_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Cancelaciontipificacionid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CancelacionTipificacionDescripcion_Z" )]
      [  XmlElement( ElementName = "CancelacionTipificacionDescripcion_Z"   )]
      public string gxTpr_Cancelaciontipificaciondescripcion_Z
      {
         get {
            return gxTv_SdtSolicitudes_Cancelaciontipificaciondescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Cancelaciontipificaciondescripcion_Z = value;
            SetDirty("Cancelaciontipificaciondescripcion_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Cancelaciontipificaciondescripcion_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Cancelaciontipificaciondescripcion_Z = "";
         SetDirty("Cancelaciontipificaciondescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Cancelaciontipificaciondescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesCostoPresupuesto_Z" )]
      [  XmlElement( ElementName = "SolicitudesCostoPresupuesto_Z"   )]
      public decimal gxTpr_Solicitudescostopresupuesto_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudescostopresupuesto_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudescostopresupuesto_Z = value;
            SetDirty("Solicitudescostopresupuesto_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudescostopresupuesto_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudescostopresupuesto_Z = 0;
         SetDirty("Solicitudescostopresupuesto_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudescostopresupuesto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesURLOrigen_Z" )]
      [  XmlElement( ElementName = "SolicitudesURLOrigen_Z"   )]
      public string gxTpr_Solicitudesurlorigen_Z
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesurlorigen_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesurlorigen_Z = value;
            SetDirty("Solicitudesurlorigen_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesurlorigen_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesurlorigen_Z = "";
         SetDirty("Solicitudesurlorigen_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesurlorigen_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TicketId_Z" )]
      [  XmlElement( ElementName = "TicketId_Z"   )]
      public long gxTpr_Ticketid_Z
      {
         get {
            return gxTv_SdtSolicitudes_Ticketid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Ticketid_Z = value;
            SetDirty("Ticketid_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Ticketid_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Ticketid_Z = 0;
         SetDirty("Ticketid_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Ticketid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TicketMotivoId_Z" )]
      [  XmlElement( ElementName = "TicketMotivoId_Z"   )]
      public long gxTpr_Ticketmotivoid_Z
      {
         get {
            return gxTv_SdtSolicitudes_Ticketmotivoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Ticketmotivoid_Z = value;
            SetDirty("Ticketmotivoid_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Ticketmotivoid_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Ticketmotivoid_Z = 0;
         SetDirty("Ticketmotivoid_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Ticketmotivoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TicketMotivoDescripcion_Z" )]
      [  XmlElement( ElementName = "TicketMotivoDescripcion_Z"   )]
      public string gxTpr_Ticketmotivodescripcion_Z
      {
         get {
            return gxTv_SdtSolicitudes_Ticketmotivodescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Ticketmotivodescripcion_Z = value;
            SetDirty("Ticketmotivodescripcion_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Ticketmotivodescripcion_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Ticketmotivodescripcion_Z = "";
         SetDirty("Ticketmotivodescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Ticketmotivodescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TicketComentario_Z" )]
      [  XmlElement( ElementName = "TicketComentario_Z"   )]
      public string gxTpr_Ticketcomentario_Z
      {
         get {
            return gxTv_SdtSolicitudes_Ticketcomentario_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Ticketcomentario_Z = value;
            SetDirty("Ticketcomentario_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Ticketcomentario_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Ticketcomentario_Z = "";
         SetDirty("Ticketcomentario_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Ticketcomentario_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TicketAdjunto_Z" )]
      [  XmlElement( ElementName = "TicketAdjunto_Z"   )]
      public string gxTpr_Ticketadjunto_Z
      {
         get {
            return gxTv_SdtSolicitudes_Ticketadjunto_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Ticketadjunto_Z = value;
            SetDirty("Ticketadjunto_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Ticketadjunto_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Ticketadjunto_Z = "";
         SetDirty("Ticketadjunto_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Ticketadjunto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TicketEstado_Z" )]
      [  XmlElement( ElementName = "TicketEstado_Z"   )]
      public bool gxTpr_Ticketestado_Z
      {
         get {
            return gxTv_SdtSolicitudes_Ticketestado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Ticketestado_Z = value;
            SetDirty("Ticketestado_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Ticketestado_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Ticketestado_Z = false;
         SetDirty("Ticketestado_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Ticketestado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TicketSolicitudId_Z" )]
      [  XmlElement( ElementName = "TicketSolicitudId_Z"   )]
      public long gxTpr_Ticketsolicitudid_Z
      {
         get {
            return gxTv_SdtSolicitudes_Ticketsolicitudid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Ticketsolicitudid_Z = value;
            SetDirty("Ticketsolicitudid_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Ticketsolicitudid_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Ticketsolicitudid_Z = 0;
         SetDirty("Ticketsolicitudid_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Ticketsolicitudid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesMail_N" )]
      [  XmlElement( ElementName = "SolicitudesMail_N"   )]
      public short gxTpr_Solicitudesmail_N
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesmail_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesmail_N = value;
            SetDirty("Solicitudesmail_N");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesmail_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesmail_N = 0;
         SetDirty("Solicitudesmail_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesmail_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DepartamentoId_N" )]
      [  XmlElement( ElementName = "DepartamentoId_N"   )]
      public short gxTpr_Departamentoid_N
      {
         get {
            return gxTv_SdtSolicitudes_Departamentoid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Departamentoid_N = value;
            SetDirty("Departamentoid_N");
         }

      }

      public void gxTv_SdtSolicitudes_Departamentoid_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Departamentoid_N = 0;
         SetDirty("Departamentoid_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Departamentoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DepartamentoMunicipioId_N" )]
      [  XmlElement( ElementName = "DepartamentoMunicipioId_N"   )]
      public short gxTpr_Departamentomunicipioid_N
      {
         get {
            return gxTv_SdtSolicitudes_Departamentomunicipioid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Departamentomunicipioid_N = value;
            SetDirty("Departamentomunicipioid_N");
         }

      }

      public void gxTv_SdtSolicitudes_Departamentomunicipioid_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Departamentomunicipioid_N = 0;
         SetDirty("Departamentomunicipioid_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Departamentomunicipioid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ZonasID_N" )]
      [  XmlElement( ElementName = "ZonasID_N"   )]
      public short gxTpr_Zonasid_N
      {
         get {
            return gxTv_SdtSolicitudes_Zonasid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Zonasid_N = value;
            SetDirty("Zonasid_N");
         }

      }

      public void gxTv_SdtSolicitudes_Zonasid_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Zonasid_N = 0;
         SetDirty("Zonasid_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Zonasid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "STMonedasId_N" )]
      [  XmlElement( ElementName = "STMonedasId_N"   )]
      public short gxTpr_Stmonedasid_N
      {
         get {
            return gxTv_SdtSolicitudes_Stmonedasid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Stmonedasid_N = value;
            SetDirty("Stmonedasid_N");
         }

      }

      public void gxTv_SdtSolicitudes_Stmonedasid_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Stmonedasid_N = 0;
         SetDirty("Stmonedasid_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Stmonedasid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesLiqProf_N" )]
      [  XmlElement( ElementName = "SolicitudesLiqProf_N"   )]
      public short gxTpr_Solicitudesliqprof_N
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesliqprof_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesliqprof_N = value;
            SetDirty("Solicitudesliqprof_N");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesliqprof_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesliqprof_N = 0;
         SetDirty("Solicitudesliqprof_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesliqprof_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesLiqProv_N" )]
      [  XmlElement( ElementName = "SolicitudesLiqProv_N"   )]
      public short gxTpr_Solicitudesliqprov_N
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesliqprov_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesliqprov_N = value;
            SetDirty("Solicitudesliqprov_N");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesliqprov_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesliqprov_N = 0;
         SetDirty("Solicitudesliqprov_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesliqprov_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesDescuento_N" )]
      [  XmlElement( ElementName = "SolicitudesDescuento_N"   )]
      public short gxTpr_Solicitudesdescuento_N
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesdescuento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesdescuento_N = value;
            SetDirty("Solicitudesdescuento_N");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesdescuento_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesdescuento_N = 0;
         SetDirty("Solicitudesdescuento_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesdescuento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CuponId_N" )]
      [  XmlElement( ElementName = "CuponId_N"   )]
      public short gxTpr_Cuponid_N
      {
         get {
            return gxTv_SdtSolicitudes_Cuponid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Cuponid_N = value;
            SetDirty("Cuponid_N");
         }

      }

      public void gxTv_SdtSolicitudes_Cuponid_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Cuponid_N = 0;
         SetDirty("Cuponid_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Cuponid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesUsrAlta_N" )]
      [  XmlElement( ElementName = "SolicitudesUsrAlta_N"   )]
      public short gxTpr_Solicitudesusralta_N
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesusralta_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesusralta_N = value;
            SetDirty("Solicitudesusralta_N");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesusralta_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesusralta_N = 0;
         SetDirty("Solicitudesusralta_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesusralta_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesUsrActualizacion_N" )]
      [  XmlElement( ElementName = "SolicitudesUsrActualizacion_N"   )]
      public short gxTpr_Solicitudesusractualizacion_N
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesusractualizacion_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesusractualizacion_N = value;
            SetDirty("Solicitudesusractualizacion_N");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesusractualizacion_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesusractualizacion_N = 0;
         SetDirty("Solicitudesusractualizacion_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesusractualizacion_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesFechaAlta_N" )]
      [  XmlElement( ElementName = "SolicitudesFechaAlta_N"   )]
      public short gxTpr_Solicitudesfechaalta_N
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesfechaalta_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesfechaalta_N = value;
            SetDirty("Solicitudesfechaalta_N");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesfechaalta_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesfechaalta_N = 0;
         SetDirty("Solicitudesfechaalta_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesfechaalta_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesFechaActualizacion_N" )]
      [  XmlElement( ElementName = "SolicitudesFechaActualizacion_N"   )]
      public short gxTpr_Solicitudesfechaactualizacion_N
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_N = value;
            SetDirty("Solicitudesfechaactualizacion_N");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_N = 0;
         SetDirty("Solicitudesfechaactualizacion_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "STComerciosID_N" )]
      [  XmlElement( ElementName = "STComerciosID_N"   )]
      public short gxTpr_Stcomerciosid_N
      {
         get {
            return gxTv_SdtSolicitudes_Stcomerciosid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Stcomerciosid_N = value;
            SetDirty("Stcomerciosid_N");
         }

      }

      public void gxTv_SdtSolicitudes_Stcomerciosid_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Stcomerciosid_N = 0;
         SetDirty("Stcomerciosid_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Stcomerciosid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudServicioOrigenPago_N" )]
      [  XmlElement( ElementName = "SolicitudServicioOrigenPago_N"   )]
      public short gxTpr_Solicitudservicioorigenpago_N
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudservicioorigenpago_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudservicioorigenpago_N = value;
            SetDirty("Solicitudservicioorigenpago_N");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudservicioorigenpago_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudservicioorigenpago_N = 0;
         SetDirty("Solicitudservicioorigenpago_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudservicioorigenpago_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesPagado_N" )]
      [  XmlElement( ElementName = "SolicitudesPagado_N"   )]
      public short gxTpr_Solicitudespagado_N
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudespagado_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudespagado_N = value;
            SetDirty("Solicitudespagado_N");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudespagado_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudespagado_N = 0;
         SetDirty("Solicitudespagado_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudespagado_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudServicioComProv_N" )]
      [  XmlElement( ElementName = "SolicitudServicioComProv_N"   )]
      public short gxTpr_Solicitudserviciocomprov_N
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudserviciocomprov_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudserviciocomprov_N = value;
            SetDirty("Solicitudserviciocomprov_N");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudserviciocomprov_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudserviciocomprov_N = 0;
         SetDirty("Solicitudserviciocomprov_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudserviciocomprov_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudServicioComProvP_N" )]
      [  XmlElement( ElementName = "SolicitudServicioComProvP_N"   )]
      public short gxTpr_Solicitudserviciocomprovp_N
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudserviciocomprovp_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudserviciocomprovp_N = value;
            SetDirty("Solicitudserviciocomprovp_N");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudserviciocomprovp_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudserviciocomprovp_N = 0;
         SetDirty("Solicitudserviciocomprovp_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudserviciocomprovp_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudServicioComALM_N" )]
      [  XmlElement( ElementName = "SolicitudServicioComALM_N"   )]
      public short gxTpr_Solicitudserviciocomalm_N
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudserviciocomalm_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudserviciocomalm_N = value;
            SetDirty("Solicitudserviciocomalm_N");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudserviciocomalm_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudserviciocomalm_N = 0;
         SetDirty("Solicitudserviciocomalm_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudserviciocomalm_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudServicioComALMP_N" )]
      [  XmlElement( ElementName = "SolicitudServicioComALMP_N"   )]
      public short gxTpr_Solicitudserviciocomalmp_N
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudserviciocomalmp_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudserviciocomalmp_N = value;
            SetDirty("Solicitudserviciocomalmp_N");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudserviciocomalmp_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudserviciocomalmp_N = 0;
         SetDirty("Solicitudserviciocomalmp_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudserviciocomalmp_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorNombreAux_N" )]
      [  XmlElement( ElementName = "ProveedorNombreAux_N"   )]
      public short gxTpr_Proveedornombreaux_N
      {
         get {
            return gxTv_SdtSolicitudes_Proveedornombreaux_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Proveedornombreaux_N = value;
            SetDirty("Proveedornombreaux_N");
         }

      }

      public void gxTv_SdtSolicitudes_Proveedornombreaux_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Proveedornombreaux_N = 0;
         SetDirty("Proveedornombreaux_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Proveedornombreaux_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesSubTipo_N" )]
      [  XmlElement( ElementName = "SolicitudesSubTipo_N"   )]
      public short gxTpr_Solicitudessubtipo_N
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudessubtipo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudessubtipo_N = value;
            SetDirty("Solicitudessubtipo_N");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudessubtipo_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudessubtipo_N = 0;
         SetDirty("Solicitudessubtipo_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudessubtipo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesCostoXZComAlm_N" )]
      [  XmlElement( ElementName = "SolicitudesCostoXZComAlm_N"   )]
      public short gxTpr_Solicitudescostoxzcomalm_N
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudescostoxzcomalm_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudescostoxzcomalm_N = value;
            SetDirty("Solicitudescostoxzcomalm_N");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudescostoxzcomalm_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudescostoxzcomalm_N = 0;
         SetDirty("Solicitudescostoxzcomalm_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudescostoxzcomalm_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesCostoXZComAlmP_N" )]
      [  XmlElement( ElementName = "SolicitudesCostoXZComAlmP_N"   )]
      public short gxTpr_Solicitudescostoxzcomalmp_N
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp_N = value;
            SetDirty("Solicitudescostoxzcomalmp_N");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp_N = 0;
         SetDirty("Solicitudescostoxzcomalmp_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaId_N" )]
      [  XmlElement( ElementName = "MudanzaId_N"   )]
      public short gxTpr_Mudanzaid_N
      {
         get {
            return gxTv_SdtSolicitudes_Mudanzaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Mudanzaid_N = value;
            SetDirty("Mudanzaid_N");
         }

      }

      public void gxTv_SdtSolicitudes_Mudanzaid_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Mudanzaid_N = 0;
         SetDirty("Mudanzaid_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Mudanzaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionesId_N" )]
      [  XmlElement( ElementName = "PostulacionesId_N"   )]
      public short gxTpr_Postulacionesid_N
      {
         get {
            return gxTv_SdtSolicitudes_Postulacionesid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Postulacionesid_N = value;
            SetDirty("Postulacionesid_N");
         }

      }

      public void gxTv_SdtSolicitudes_Postulacionesid_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Postulacionesid_N = 0;
         SetDirty("Postulacionesid_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Postulacionesid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesDuplicado_N" )]
      [  XmlElement( ElementName = "SolicitudesDuplicado_N"   )]
      public short gxTpr_Solicitudesduplicado_N
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesduplicado_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesduplicado_N = value;
            SetDirty("Solicitudesduplicado_N");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesduplicado_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesduplicado_N = 0;
         SetDirty("Solicitudesduplicado_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesduplicado_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesCostoPresupuesto_N" )]
      [  XmlElement( ElementName = "SolicitudesCostoPresupuesto_N"   )]
      public short gxTpr_Solicitudescostopresupuesto_N
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudescostopresupuesto_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudescostopresupuesto_N = value;
            SetDirty("Solicitudescostopresupuesto_N");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudescostopresupuesto_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudescostopresupuesto_N = 0;
         SetDirty("Solicitudescostopresupuesto_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudescostopresupuesto_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesURLOrigen_N" )]
      [  XmlElement( ElementName = "SolicitudesURLOrigen_N"   )]
      public short gxTpr_Solicitudesurlorigen_N
      {
         get {
            return gxTv_SdtSolicitudes_Solicitudesurlorigen_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Solicitudesurlorigen_N = value;
            SetDirty("Solicitudesurlorigen_N");
         }

      }

      public void gxTv_SdtSolicitudes_Solicitudesurlorigen_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Solicitudesurlorigen_N = 0;
         SetDirty("Solicitudesurlorigen_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Solicitudesurlorigen_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TicketId_N" )]
      [  XmlElement( ElementName = "TicketId_N"   )]
      public short gxTpr_Ticketid_N
      {
         get {
            return gxTv_SdtSolicitudes_Ticketid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Ticketid_N = value;
            SetDirty("Ticketid_N");
         }

      }

      public void gxTv_SdtSolicitudes_Ticketid_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Ticketid_N = 0;
         SetDirty("Ticketid_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Ticketid_N_IsNull( )
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
         gxTv_SdtSolicitudes_Solicitudesnombre = "";
         gxTv_SdtSolicitudes_Solicitudestelefono = "";
         gxTv_SdtSolicitudes_Solicitudesmail = "";
         gxTv_SdtSolicitudes_Paisid = "";
         gxTv_SdtSolicitudes_Solicitudesdireccion = "";
         gxTv_SdtSolicitudes_Stmonedasiso = "";
         gxTv_SdtSolicitudes_Solicitudserviciosolcoti = "";
         gxTv_SdtSolicitudes_Cuponid = 1234;
         gxTv_SdtSolicitudes_Estadossoltipo = "";
         gxTv_SdtSolicitudes_Estadossolnombre = "";
         gxTv_SdtSolicitudes_Solicitudesotros1 = "";
         gxTv_SdtSolicitudes_Solicitudesotros2 = "";
         gxTv_SdtSolicitudes_Solicitudesotros3 = "";
         gxTv_SdtSolicitudes_Solicitudesfechaalta = DateTime.MinValue;
         gxTv_SdtSolicitudes_Solicitudesfechaactualizacion = (DateTime)(DateTime.MinValue);
         gxTv_SdtSolicitudes_Solicitudesfechainstalacion = DateTime.MinValue;
         gxTv_SdtSolicitudes_Solicitudeshorainstalacion = "";
         gxTv_SdtSolicitudes_Solicitudescomentario = "";
         gxTv_SdtSolicitudes_Metodopagosnombre = "";
         gxTv_SdtSolicitudes_Solicitudesnota = "";
         gxTv_SdtSolicitudes_Solicitudesnotificacion = "";
         gxTv_SdtSolicitudes_Proveedornombre = "";
         gxTv_SdtSolicitudes_Proveedorpagodefault = "";
         gxTv_SdtSolicitudes_Stcomerciosnombre = "";
         gxTv_SdtSolicitudes_Stcomerciosestado = "";
         gxTv_SdtSolicitudes_Solicitudservicioorigenpago = "";
         gxTv_SdtSolicitudes_Solicitudespagado = "";
         gxTv_SdtSolicitudes_Proveedornombreaux = "";
         gxTv_SdtSolicitudes_Solicitudessubtipo = "";
         gxTv_SdtSolicitudes_Mudanzafechaservicio = DateTime.MinValue;
         gxTv_SdtSolicitudes_Mudanzadireccionorigen = "";
         gxTv_SdtSolicitudes_Mudanzadirecciondestino = "";
         gxTv_SdtSolicitudes_Cancelaciontipificacionid = 0;
         gxTv_SdtSolicitudes_Cancelaciontipificaciondescripcion = "";
         gxTv_SdtSolicitudes_Solicitudesurlorigen = "";
         gxTv_SdtSolicitudes_Ticketmotivodescripcion = "";
         gxTv_SdtSolicitudes_Ticketcomentario = "";
         gxTv_SdtSolicitudes_Ticketadjunto = "";
         gxTv_SdtSolicitudes_Mode = "";
         gxTv_SdtSolicitudes_Solicitudesnombre_Z = "";
         gxTv_SdtSolicitudes_Solicitudestelefono_Z = "";
         gxTv_SdtSolicitudes_Solicitudesmail_Z = "";
         gxTv_SdtSolicitudes_Paisid_Z = "";
         gxTv_SdtSolicitudes_Solicitudesdireccion_Z = "";
         gxTv_SdtSolicitudes_Stmonedasiso_Z = "";
         gxTv_SdtSolicitudes_Solicitudserviciosolcoti_Z = "";
         gxTv_SdtSolicitudes_Estadossoltipo_Z = "";
         gxTv_SdtSolicitudes_Estadossolnombre_Z = "";
         gxTv_SdtSolicitudes_Solicitudesotros1_Z = "";
         gxTv_SdtSolicitudes_Solicitudesotros2_Z = "";
         gxTv_SdtSolicitudes_Solicitudesotros3_Z = "";
         gxTv_SdtSolicitudes_Solicitudesfechaalta_Z = DateTime.MinValue;
         gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtSolicitudes_Solicitudesfechainstalacion_Z = DateTime.MinValue;
         gxTv_SdtSolicitudes_Solicitudeshorainstalacion_Z = "";
         gxTv_SdtSolicitudes_Metodopagosnombre_Z = "";
         gxTv_SdtSolicitudes_Solicitudesnota_Z = "";
         gxTv_SdtSolicitudes_Solicitudesnotificacion_Z = "";
         gxTv_SdtSolicitudes_Proveedornombre_Z = "";
         gxTv_SdtSolicitudes_Proveedorpagodefault_Z = "";
         gxTv_SdtSolicitudes_Stcomerciosnombre_Z = "";
         gxTv_SdtSolicitudes_Stcomerciosestado_Z = "";
         gxTv_SdtSolicitudes_Solicitudservicioorigenpago_Z = "";
         gxTv_SdtSolicitudes_Solicitudespagado_Z = "";
         gxTv_SdtSolicitudes_Proveedornombreaux_Z = "";
         gxTv_SdtSolicitudes_Solicitudessubtipo_Z = "";
         gxTv_SdtSolicitudes_Mudanzafechaservicio_Z = DateTime.MinValue;
         gxTv_SdtSolicitudes_Mudanzadireccionorigen_Z = "";
         gxTv_SdtSolicitudes_Mudanzadirecciondestino_Z = "";
         gxTv_SdtSolicitudes_Cancelaciontipificaciondescripcion_Z = "";
         gxTv_SdtSolicitudes_Solicitudesurlorigen_Z = "";
         gxTv_SdtSolicitudes_Ticketmotivodescripcion_Z = "";
         gxTv_SdtSolicitudes_Ticketcomentario_Z = "";
         gxTv_SdtSolicitudes_Ticketadjunto_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "solicitudes", "GeneXus.Programs.solicitudes_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtSolicitudes_Solicitudesautoenumerar ;
      private short gxTv_SdtSolicitudes_Stmonedasid ;
      private short gxTv_SdtSolicitudes_Cuponpercent ;
      private short gxTv_SdtSolicitudes_Solicitudesserialarchivo ;
      private short gxTv_SdtSolicitudes_Initialized ;
      private short gxTv_SdtSolicitudes_Solicitudesautoenumerar_Z ;
      private short gxTv_SdtSolicitudes_Stmonedasid_Z ;
      private short gxTv_SdtSolicitudes_Cuponpercent_Z ;
      private short gxTv_SdtSolicitudes_Solicitudesserialarchivo_Z ;
      private short gxTv_SdtSolicitudes_Solicitudesmail_N ;
      private short gxTv_SdtSolicitudes_Departamentoid_N ;
      private short gxTv_SdtSolicitudes_Departamentomunicipioid_N ;
      private short gxTv_SdtSolicitudes_Zonasid_N ;
      private short gxTv_SdtSolicitudes_Stmonedasid_N ;
      private short gxTv_SdtSolicitudes_Solicitudesliqprof_N ;
      private short gxTv_SdtSolicitudes_Solicitudesliqprov_N ;
      private short gxTv_SdtSolicitudes_Solicitudesdescuento_N ;
      private short gxTv_SdtSolicitudes_Cuponid_N ;
      private short gxTv_SdtSolicitudes_Solicitudesusralta_N ;
      private short gxTv_SdtSolicitudes_Solicitudesusractualizacion_N ;
      private short gxTv_SdtSolicitudes_Solicitudesfechaalta_N ;
      private short gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_N ;
      private short gxTv_SdtSolicitudes_Stcomerciosid_N ;
      private short gxTv_SdtSolicitudes_Solicitudservicioorigenpago_N ;
      private short gxTv_SdtSolicitudes_Solicitudespagado_N ;
      private short gxTv_SdtSolicitudes_Solicitudserviciocomprov_N ;
      private short gxTv_SdtSolicitudes_Solicitudserviciocomprovp_N ;
      private short gxTv_SdtSolicitudes_Solicitudserviciocomalm_N ;
      private short gxTv_SdtSolicitudes_Solicitudserviciocomalmp_N ;
      private short gxTv_SdtSolicitudes_Proveedornombreaux_N ;
      private short gxTv_SdtSolicitudes_Solicitudessubtipo_N ;
      private short gxTv_SdtSolicitudes_Solicitudescostoxzcomalm_N ;
      private short gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp_N ;
      private short gxTv_SdtSolicitudes_Mudanzaid_N ;
      private short gxTv_SdtSolicitudes_Postulacionesid_N ;
      private short gxTv_SdtSolicitudes_Solicitudesduplicado_N ;
      private short gxTv_SdtSolicitudes_Solicitudescostopresupuesto_N ;
      private short gxTv_SdtSolicitudes_Solicitudesurlorigen_N ;
      private short gxTv_SdtSolicitudes_Ticketid_N ;
      private int gxTv_SdtSolicitudes_Estadossolid ;
      private int gxTv_SdtSolicitudes_Estadossolid_Z ;
      private long gxTv_SdtSolicitudes_Solicitudesid ;
      private long gxTv_SdtSolicitudes_Departamentoid ;
      private long gxTv_SdtSolicitudes_Departamentomunicipioid ;
      private long gxTv_SdtSolicitudes_Zonasid ;
      private long gxTv_SdtSolicitudes_Solicitudesliqprof ;
      private long gxTv_SdtSolicitudes_Solicitudesliqprov ;
      private long gxTv_SdtSolicitudes_Cuponid ;
      private long gxTv_SdtSolicitudes_Solicitudesusralta ;
      private long gxTv_SdtSolicitudes_Solicitudesusractualizacion ;
      private long gxTv_SdtSolicitudes_Metodopagosid ;
      private long gxTv_SdtSolicitudes_Proveedorid ;
      private long gxTv_SdtSolicitudes_Stcomerciosid ;
      private long gxTv_SdtSolicitudes_Mudanzaid ;
      private long gxTv_SdtSolicitudes_Postulacionesid ;
      private long gxTv_SdtSolicitudes_Solicitudesduplicado ;
      private long gxTv_SdtSolicitudes_Cancelaciontipificacionid ;
      private long gxTv_SdtSolicitudes_Ticketid ;
      private long gxTv_SdtSolicitudes_Ticketmotivoid ;
      private long gxTv_SdtSolicitudes_Ticketsolicitudid ;
      private long gxTv_SdtSolicitudes_Solicitudesid_Z ;
      private long gxTv_SdtSolicitudes_Departamentoid_Z ;
      private long gxTv_SdtSolicitudes_Departamentomunicipioid_Z ;
      private long gxTv_SdtSolicitudes_Zonasid_Z ;
      private long gxTv_SdtSolicitudes_Solicitudesliqprof_Z ;
      private long gxTv_SdtSolicitudes_Solicitudesliqprov_Z ;
      private long gxTv_SdtSolicitudes_Cuponid_Z ;
      private long gxTv_SdtSolicitudes_Solicitudesusralta_Z ;
      private long gxTv_SdtSolicitudes_Solicitudesusractualizacion_Z ;
      private long gxTv_SdtSolicitudes_Metodopagosid_Z ;
      private long gxTv_SdtSolicitudes_Proveedorid_Z ;
      private long gxTv_SdtSolicitudes_Stcomerciosid_Z ;
      private long gxTv_SdtSolicitudes_Mudanzaid_Z ;
      private long gxTv_SdtSolicitudes_Postulacionesid_Z ;
      private long gxTv_SdtSolicitudes_Solicitudesduplicado_Z ;
      private long gxTv_SdtSolicitudes_Cancelaciontipificacionid_Z ;
      private long gxTv_SdtSolicitudes_Ticketid_Z ;
      private long gxTv_SdtSolicitudes_Ticketmotivoid_Z ;
      private long gxTv_SdtSolicitudes_Ticketsolicitudid_Z ;
      private decimal gxTv_SdtSolicitudes_Solicitudescotizacion ;
      private decimal gxTv_SdtSolicitudes_Solicitudestotal ;
      private decimal gxTv_SdtSolicitudes_Solicitudserviciopfinal ;
      private decimal gxTv_SdtSolicitudes_Solicitudesdescuento ;
      private decimal gxTv_SdtSolicitudes_Solicitudesdescuentocupon ;
      private decimal gxTv_SdtSolicitudes_Solicitudescomisionmetodopago ;
      private decimal gxTv_SdtSolicitudes_Solicitudserviciocomprov ;
      private decimal gxTv_SdtSolicitudes_Solicitudserviciocomprovp ;
      private decimal gxTv_SdtSolicitudes_Solicitudserviciocomalm ;
      private decimal gxTv_SdtSolicitudes_Solicitudserviciocomalmp ;
      private decimal gxTv_SdtSolicitudes_Solicitudserviciocompro ;
      private decimal gxTv_SdtSolicitudes_Solicitudserviciocomprop ;
      private decimal gxTv_SdtSolicitudes_Solicitudescostoxzona ;
      private decimal gxTv_SdtSolicitudes_Solicitudescostoxzcomalm ;
      private decimal gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp ;
      private decimal gxTv_SdtSolicitudes_Solicitudescostoxzcomprof ;
      private decimal gxTv_SdtSolicitudes_Solicitudescostoxzcomprofp ;
      private decimal gxTv_SdtSolicitudes_Solicitudescostopresupuesto ;
      private decimal gxTv_SdtSolicitudes_Solicitudescotizacion_Z ;
      private decimal gxTv_SdtSolicitudes_Solicitudestotal_Z ;
      private decimal gxTv_SdtSolicitudes_Solicitudserviciopfinal_Z ;
      private decimal gxTv_SdtSolicitudes_Solicitudesdescuento_Z ;
      private decimal gxTv_SdtSolicitudes_Solicitudesdescuentocupon_Z ;
      private decimal gxTv_SdtSolicitudes_Solicitudescomisionmetodopago_Z ;
      private decimal gxTv_SdtSolicitudes_Solicitudserviciocomprov_Z ;
      private decimal gxTv_SdtSolicitudes_Solicitudserviciocomprovp_Z ;
      private decimal gxTv_SdtSolicitudes_Solicitudserviciocomalm_Z ;
      private decimal gxTv_SdtSolicitudes_Solicitudserviciocomalmp_Z ;
      private decimal gxTv_SdtSolicitudes_Solicitudserviciocompro_Z ;
      private decimal gxTv_SdtSolicitudes_Solicitudserviciocomprop_Z ;
      private decimal gxTv_SdtSolicitudes_Solicitudescostoxzona_Z ;
      private decimal gxTv_SdtSolicitudes_Solicitudescostoxzcomalm_Z ;
      private decimal gxTv_SdtSolicitudes_Solicitudescostoxzcomalmp_Z ;
      private decimal gxTv_SdtSolicitudes_Solicitudescostoxzcomprof_Z ;
      private decimal gxTv_SdtSolicitudes_Solicitudescostoxzcomprofp_Z ;
      private decimal gxTv_SdtSolicitudes_Solicitudescostopresupuesto_Z ;
      private string gxTv_SdtSolicitudes_Solicitudesnombre ;
      private string gxTv_SdtSolicitudes_Solicitudestelefono ;
      private string gxTv_SdtSolicitudes_Paisid ;
      private string gxTv_SdtSolicitudes_Stmonedasiso ;
      private string gxTv_SdtSolicitudes_Solicitudserviciosolcoti ;
      private string gxTv_SdtSolicitudes_Estadossoltipo ;
      private string gxTv_SdtSolicitudes_Estadossolnombre ;
      private string gxTv_SdtSolicitudes_Solicitudesotros1 ;
      private string gxTv_SdtSolicitudes_Solicitudesotros2 ;
      private string gxTv_SdtSolicitudes_Solicitudesotros3 ;
      private string gxTv_SdtSolicitudes_Solicitudeshorainstalacion ;
      private string gxTv_SdtSolicitudes_Metodopagosnombre ;
      private string gxTv_SdtSolicitudes_Solicitudesnota ;
      private string gxTv_SdtSolicitudes_Solicitudesnotificacion ;
      private string gxTv_SdtSolicitudes_Proveedornombre ;
      private string gxTv_SdtSolicitudes_Proveedorpagodefault ;
      private string gxTv_SdtSolicitudes_Stcomerciosnombre ;
      private string gxTv_SdtSolicitudes_Stcomerciosestado ;
      private string gxTv_SdtSolicitudes_Solicitudservicioorigenpago ;
      private string gxTv_SdtSolicitudes_Solicitudespagado ;
      private string gxTv_SdtSolicitudes_Proveedornombreaux ;
      private string gxTv_SdtSolicitudes_Solicitudessubtipo ;
      private string gxTv_SdtSolicitudes_Cancelaciontipificaciondescripcion ;
      private string gxTv_SdtSolicitudes_Ticketmotivodescripcion ;
      private string gxTv_SdtSolicitudes_Ticketcomentario ;
      private string gxTv_SdtSolicitudes_Ticketadjunto ;
      private string gxTv_SdtSolicitudes_Mode ;
      private string gxTv_SdtSolicitudes_Solicitudesnombre_Z ;
      private string gxTv_SdtSolicitudes_Solicitudestelefono_Z ;
      private string gxTv_SdtSolicitudes_Paisid_Z ;
      private string gxTv_SdtSolicitudes_Stmonedasiso_Z ;
      private string gxTv_SdtSolicitudes_Solicitudserviciosolcoti_Z ;
      private string gxTv_SdtSolicitudes_Estadossoltipo_Z ;
      private string gxTv_SdtSolicitudes_Estadossolnombre_Z ;
      private string gxTv_SdtSolicitudes_Solicitudesotros1_Z ;
      private string gxTv_SdtSolicitudes_Solicitudesotros2_Z ;
      private string gxTv_SdtSolicitudes_Solicitudesotros3_Z ;
      private string gxTv_SdtSolicitudes_Solicitudeshorainstalacion_Z ;
      private string gxTv_SdtSolicitudes_Metodopagosnombre_Z ;
      private string gxTv_SdtSolicitudes_Solicitudesnota_Z ;
      private string gxTv_SdtSolicitudes_Solicitudesnotificacion_Z ;
      private string gxTv_SdtSolicitudes_Proveedornombre_Z ;
      private string gxTv_SdtSolicitudes_Proveedorpagodefault_Z ;
      private string gxTv_SdtSolicitudes_Stcomerciosnombre_Z ;
      private string gxTv_SdtSolicitudes_Stcomerciosestado_Z ;
      private string gxTv_SdtSolicitudes_Solicitudservicioorigenpago_Z ;
      private string gxTv_SdtSolicitudes_Solicitudespagado_Z ;
      private string gxTv_SdtSolicitudes_Proveedornombreaux_Z ;
      private string gxTv_SdtSolicitudes_Solicitudessubtipo_Z ;
      private string gxTv_SdtSolicitudes_Cancelaciontipificaciondescripcion_Z ;
      private string gxTv_SdtSolicitudes_Ticketmotivodescripcion_Z ;
      private string gxTv_SdtSolicitudes_Ticketcomentario_Z ;
      private string gxTv_SdtSolicitudes_Ticketadjunto_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtSolicitudes_Solicitudesfechaactualizacion ;
      private DateTime gxTv_SdtSolicitudes_Solicitudesfechaactualizacion_Z ;
      private DateTime datetime_STZ ;
      private DateTime gxTv_SdtSolicitudes_Solicitudesfechaalta ;
      private DateTime gxTv_SdtSolicitudes_Solicitudesfechainstalacion ;
      private DateTime gxTv_SdtSolicitudes_Mudanzafechaservicio ;
      private DateTime gxTv_SdtSolicitudes_Solicitudesfechaalta_Z ;
      private DateTime gxTv_SdtSolicitudes_Solicitudesfechainstalacion_Z ;
      private DateTime gxTv_SdtSolicitudes_Mudanzafechaservicio_Z ;
      private bool gxTv_SdtSolicitudes_Solicitudescalcomi ;
      private bool gxTv_SdtSolicitudes_Ticketestado ;
      private bool gxTv_SdtSolicitudes_Solicitudescalcomi_Z ;
      private bool gxTv_SdtSolicitudes_Ticketestado_Z ;
      private string gxTv_SdtSolicitudes_Solicitudescomentario ;
      private string gxTv_SdtSolicitudes_Solicitudesmail ;
      private string gxTv_SdtSolicitudes_Solicitudesdireccion ;
      private string gxTv_SdtSolicitudes_Mudanzadireccionorigen ;
      private string gxTv_SdtSolicitudes_Mudanzadirecciondestino ;
      private string gxTv_SdtSolicitudes_Solicitudesurlorigen ;
      private string gxTv_SdtSolicitudes_Solicitudesmail_Z ;
      private string gxTv_SdtSolicitudes_Solicitudesdireccion_Z ;
      private string gxTv_SdtSolicitudes_Mudanzadireccionorigen_Z ;
      private string gxTv_SdtSolicitudes_Mudanzadirecciondestino_Z ;
      private string gxTv_SdtSolicitudes_Solicitudesurlorigen_Z ;
      private GXBCLevelCollection<SdtSolicitudes_Items> gxTv_SdtSolicitudes_Items=null ;
      private GXBCLevelCollection<SdtSolicitudes_Archivo> gxTv_SdtSolicitudes_Archivo=null ;
   }

   [DataContract(Name = @"Solicitudes", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtSolicitudes_RESTInterface : GxGenericCollectionItem<SdtSolicitudes>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtSolicitudes_RESTInterface( ) : base()
      {
      }

      public SdtSolicitudes_RESTInterface( SdtSolicitudes psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SolicitudesID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Solicitudesid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Solicitudesid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Solicitudesid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "SolicitudesNombre" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Solicitudesnombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Solicitudesnombre) ;
         }

         set {
            sdt.gxTpr_Solicitudesnombre = value;
         }

      }

      [DataMember( Name = "SolicitudesTelefono" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Solicitudestelefono
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Solicitudestelefono) ;
         }

         set {
            sdt.gxTpr_Solicitudestelefono = value;
         }

      }

      [DataMember( Name = "SolicitudesMail" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Solicitudesmail
      {
         get {
            return sdt.gxTpr_Solicitudesmail ;
         }

         set {
            sdt.gxTpr_Solicitudesmail = value;
         }

      }

      [DataMember( Name = "PaisID" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Paisid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Paisid) ;
         }

         set {
            sdt.gxTpr_Paisid = value;
         }

      }

      [DataMember( Name = "DepartamentoId" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Departamentoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Departamentoid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Departamentoid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "DepartamentoMunicipioId" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Departamentomunicipioid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Departamentomunicipioid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Departamentomunicipioid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ZonasID" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Zonasid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Zonasid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Zonasid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "SolicitudesDireccion" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Solicitudesdireccion
      {
         get {
            return sdt.gxTpr_Solicitudesdireccion ;
         }

         set {
            sdt.gxTpr_Solicitudesdireccion = value;
         }

      }

      [DataMember( Name = "SolicitudesAutoEnumerar" , Order = 9 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Solicitudesautoenumerar
      {
         get {
            return sdt.gxTpr_Solicitudesautoenumerar ;
         }

         set {
            sdt.gxTpr_Solicitudesautoenumerar = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "STMonedasId" , Order = 10 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Stmonedasid
      {
         get {
            return sdt.gxTpr_Stmonedasid ;
         }

         set {
            sdt.gxTpr_Stmonedasid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "STMonedasISO" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Stmonedasiso
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Stmonedasiso) ;
         }

         set {
            sdt.gxTpr_Stmonedasiso = value;
         }

      }

      [DataMember( Name = "SolicitudesLiqProf" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Solicitudesliqprof
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Solicitudesliqprof), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Solicitudesliqprof = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "SolicitudesLiqProv" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Solicitudesliqprov
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Solicitudesliqprov), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Solicitudesliqprov = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "Items" , Order = 14 )]
      public GxGenericCollection<SdtSolicitudes_Items_RESTInterface> gxTpr_Items
      {
         get {
            return new GxGenericCollection<SdtSolicitudes_Items_RESTInterface>(sdt.gxTpr_Items) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Items);
         }

      }

      [DataMember( Name = "SolicitudesCotizacion" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Solicitudescotizacion
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Solicitudescotizacion, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Solicitudescotizacion = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "SolicitudesTotal" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Solicitudestotal
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Solicitudestotal, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Solicitudestotal = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "SolicitudServicioSolCoti" , Order = 17 )]
      [GxSeudo()]
      public string gxTpr_Solicitudserviciosolcoti
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Solicitudserviciosolcoti) ;
         }

         set {
            sdt.gxTpr_Solicitudserviciosolcoti = value;
         }

      }

      [DataMember( Name = "SolicitudServicioPFinal" , Order = 18 )]
      [GxSeudo()]
      public string gxTpr_Solicitudserviciopfinal
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Solicitudserviciopfinal, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Solicitudserviciopfinal = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "SolicitudesDescuento" , Order = 19 )]
      [GxSeudo()]
      public string gxTpr_Solicitudesdescuento
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Solicitudesdescuento, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Solicitudesdescuento = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "CuponId" , Order = 20 )]
      [GxSeudo()]
      public string gxTpr_Cuponid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Cuponid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Cuponid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "CuponPercent" , Order = 21 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Cuponpercent
      {
         get {
            return sdt.gxTpr_Cuponpercent ;
         }

         set {
            sdt.gxTpr_Cuponpercent = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SolicitudesDescuentoCupon" , Order = 22 )]
      [GxSeudo()]
      public string gxTpr_Solicitudesdescuentocupon
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Solicitudesdescuentocupon, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Solicitudesdescuentocupon = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "SolicitudesComisionMetodoPago" , Order = 23 )]
      [GxSeudo()]
      public string gxTpr_Solicitudescomisionmetodopago
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Solicitudescomisionmetodopago, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Solicitudescomisionmetodopago = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "EstadosSolTipo" , Order = 24 )]
      [GxSeudo()]
      public string gxTpr_Estadossoltipo
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Estadossoltipo) ;
         }

         set {
            sdt.gxTpr_Estadossoltipo = value;
         }

      }

      [DataMember( Name = "EstadosSolId" , Order = 25 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Estadossolid
      {
         get {
            return sdt.gxTpr_Estadossolid ;
         }

         set {
            sdt.gxTpr_Estadossolid = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "EstadosSolNombre" , Order = 26 )]
      [GxSeudo()]
      public string gxTpr_Estadossolnombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Estadossolnombre) ;
         }

         set {
            sdt.gxTpr_Estadossolnombre = value;
         }

      }

      [DataMember( Name = "SolicitudesOtros1" , Order = 27 )]
      [GxSeudo()]
      public string gxTpr_Solicitudesotros1
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Solicitudesotros1) ;
         }

         set {
            sdt.gxTpr_Solicitudesotros1 = value;
         }

      }

      [DataMember( Name = "SolicitudesOtros2" , Order = 28 )]
      [GxSeudo()]
      public string gxTpr_Solicitudesotros2
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Solicitudesotros2) ;
         }

         set {
            sdt.gxTpr_Solicitudesotros2 = value;
         }

      }

      [DataMember( Name = "SolicitudesOtros3" , Order = 29 )]
      [GxSeudo()]
      public string gxTpr_Solicitudesotros3
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Solicitudesotros3) ;
         }

         set {
            sdt.gxTpr_Solicitudesotros3 = value;
         }

      }

      [DataMember( Name = "SolicitudesUsrAlta" , Order = 30 )]
      [GxSeudo()]
      public string gxTpr_Solicitudesusralta
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Solicitudesusralta), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Solicitudesusralta = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "SolicitudesUsrActualizacion" , Order = 31 )]
      [GxSeudo()]
      public string gxTpr_Solicitudesusractualizacion
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Solicitudesusractualizacion), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Solicitudesusractualizacion = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "SolicitudesFechaAlta" , Order = 32 )]
      [GxSeudo()]
      public string gxTpr_Solicitudesfechaalta
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Solicitudesfechaalta) ;
         }

         set {
            sdt.gxTpr_Solicitudesfechaalta = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "SolicitudesFechaActualizacion" , Order = 33 )]
      [GxSeudo()]
      public string gxTpr_Solicitudesfechaactualizacion
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Solicitudesfechaactualizacion, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Solicitudesfechaactualizacion = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "SolicitudesFechaInstalacion" , Order = 34 )]
      [GxSeudo()]
      public string gxTpr_Solicitudesfechainstalacion
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Solicitudesfechainstalacion) ;
         }

         set {
            sdt.gxTpr_Solicitudesfechainstalacion = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "SolicitudesHoraInstalacion" , Order = 35 )]
      [GxSeudo()]
      public string gxTpr_Solicitudeshorainstalacion
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Solicitudeshorainstalacion) ;
         }

         set {
            sdt.gxTpr_Solicitudeshorainstalacion = value;
         }

      }

      [DataMember( Name = "SolicitudesComentario" , Order = 36 )]
      public string gxTpr_Solicitudescomentario
      {
         get {
            return sdt.gxTpr_Solicitudescomentario ;
         }

         set {
            sdt.gxTpr_Solicitudescomentario = value;
         }

      }

      [DataMember( Name = "MetodoPagosID" , Order = 37 )]
      [GxSeudo()]
      public string gxTpr_Metodopagosid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Metodopagosid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Metodopagosid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "MetodoPagosNombre" , Order = 38 )]
      [GxSeudo()]
      public string gxTpr_Metodopagosnombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Metodopagosnombre) ;
         }

         set {
            sdt.gxTpr_Metodopagosnombre = value;
         }

      }

      [DataMember( Name = "SolicitudesNota" , Order = 39 )]
      [GxSeudo()]
      public string gxTpr_Solicitudesnota
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Solicitudesnota) ;
         }

         set {
            sdt.gxTpr_Solicitudesnota = value;
         }

      }

      [DataMember( Name = "SolicitudesNotificacion" , Order = 40 )]
      [GxSeudo()]
      public string gxTpr_Solicitudesnotificacion
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Solicitudesnotificacion) ;
         }

         set {
            sdt.gxTpr_Solicitudesnotificacion = value;
         }

      }

      [DataMember( Name = "ProveedorID" , Order = 41 )]
      [GxSeudo()]
      public string gxTpr_Proveedorid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Proveedorid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Proveedorid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ProveedorNombre" , Order = 42 )]
      [GxSeudo()]
      public string gxTpr_Proveedornombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Proveedornombre) ;
         }

         set {
            sdt.gxTpr_Proveedornombre = value;
         }

      }

      [DataMember( Name = "ProveedorPagoDefault" , Order = 43 )]
      [GxSeudo()]
      public string gxTpr_Proveedorpagodefault
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Proveedorpagodefault) ;
         }

         set {
            sdt.gxTpr_Proveedorpagodefault = value;
         }

      }

      [DataMember( Name = "STComerciosID" , Order = 44 )]
      [GxSeudo()]
      public string gxTpr_Stcomerciosid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Stcomerciosid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Stcomerciosid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "STComerciosNombre" , Order = 45 )]
      [GxSeudo()]
      public string gxTpr_Stcomerciosnombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Stcomerciosnombre) ;
         }

         set {
            sdt.gxTpr_Stcomerciosnombre = value;
         }

      }

      [DataMember( Name = "STComerciosEstado" , Order = 46 )]
      [GxSeudo()]
      public string gxTpr_Stcomerciosestado
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Stcomerciosestado) ;
         }

         set {
            sdt.gxTpr_Stcomerciosestado = value;
         }

      }

      [DataMember( Name = "SolicitudServicioOrigenPago" , Order = 47 )]
      [GxSeudo()]
      public string gxTpr_Solicitudservicioorigenpago
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Solicitudservicioorigenpago) ;
         }

         set {
            sdt.gxTpr_Solicitudservicioorigenpago = value;
         }

      }

      [DataMember( Name = "SolicitudesPagado" , Order = 48 )]
      [GxSeudo()]
      public string gxTpr_Solicitudespagado
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Solicitudespagado) ;
         }

         set {
            sdt.gxTpr_Solicitudespagado = value;
         }

      }

      [DataMember( Name = "SolicitudServicioComProv" , Order = 49 )]
      [GxSeudo()]
      public string gxTpr_Solicitudserviciocomprov
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Solicitudserviciocomprov, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Solicitudserviciocomprov = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "SolicitudServicioComProvP" , Order = 50 )]
      [GxSeudo()]
      public Nullable<decimal> gxTpr_Solicitudserviciocomprovp
      {
         get {
            return sdt.gxTpr_Solicitudserviciocomprovp ;
         }

         set {
            sdt.gxTpr_Solicitudserviciocomprovp = (decimal)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SolicitudServicioComALM" , Order = 51 )]
      [GxSeudo()]
      public string gxTpr_Solicitudserviciocomalm
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Solicitudserviciocomalm, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Solicitudserviciocomalm = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "SolicitudServicioComALMP" , Order = 52 )]
      [GxSeudo()]
      public Nullable<decimal> gxTpr_Solicitudserviciocomalmp
      {
         get {
            return sdt.gxTpr_Solicitudserviciocomalmp ;
         }

         set {
            sdt.gxTpr_Solicitudserviciocomalmp = (decimal)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SolicitudServicioComPro" , Order = 53 )]
      [GxSeudo()]
      public string gxTpr_Solicitudserviciocompro
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Solicitudserviciocompro, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Solicitudserviciocompro = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "SolicitudServicioComProP" , Order = 54 )]
      [GxSeudo()]
      public Nullable<decimal> gxTpr_Solicitudserviciocomprop
      {
         get {
            return sdt.gxTpr_Solicitudserviciocomprop ;
         }

         set {
            sdt.gxTpr_Solicitudserviciocomprop = (decimal)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SolicitudesCalComi" , Order = 55 )]
      [GxSeudo()]
      public bool gxTpr_Solicitudescalcomi
      {
         get {
            return sdt.gxTpr_Solicitudescalcomi ;
         }

         set {
            sdt.gxTpr_Solicitudescalcomi = value;
         }

      }

      [DataMember( Name = "ProveedorNombreAux" , Order = 56 )]
      [GxSeudo()]
      public string gxTpr_Proveedornombreaux
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Proveedornombreaux) ;
         }

         set {
            sdt.gxTpr_Proveedornombreaux = value;
         }

      }

      [DataMember( Name = "SolicitudesSubTipo" , Order = 57 )]
      [GxSeudo()]
      public string gxTpr_Solicitudessubtipo
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Solicitudessubtipo) ;
         }

         set {
            sdt.gxTpr_Solicitudessubtipo = value;
         }

      }

      [DataMember( Name = "SolicitudesCostoXZona" , Order = 58 )]
      [GxSeudo()]
      public string gxTpr_Solicitudescostoxzona
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Solicitudescostoxzona, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Solicitudescostoxzona = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "SolicitudesCostoXZComAlm" , Order = 59 )]
      [GxSeudo()]
      public string gxTpr_Solicitudescostoxzcomalm
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Solicitudescostoxzcomalm, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Solicitudescostoxzcomalm = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "SolicitudesCostoXZComAlmP" , Order = 60 )]
      [GxSeudo()]
      public Nullable<decimal> gxTpr_Solicitudescostoxzcomalmp
      {
         get {
            return sdt.gxTpr_Solicitudescostoxzcomalmp ;
         }

         set {
            sdt.gxTpr_Solicitudescostoxzcomalmp = (decimal)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SolicitudesCostoXZComProf" , Order = 61 )]
      [GxSeudo()]
      public string gxTpr_Solicitudescostoxzcomprof
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Solicitudescostoxzcomprof, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Solicitudescostoxzcomprof = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "SolicitudesCostoXZComProfP" , Order = 62 )]
      [GxSeudo()]
      public Nullable<decimal> gxTpr_Solicitudescostoxzcomprofp
      {
         get {
            return sdt.gxTpr_Solicitudescostoxzcomprofp ;
         }

         set {
            sdt.gxTpr_Solicitudescostoxzcomprofp = (decimal)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "MudanzaId" , Order = 63 )]
      [GxSeudo()]
      public string gxTpr_Mudanzaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Mudanzaid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Mudanzaid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "MudanzaFechaServicio" , Order = 64 )]
      [GxSeudo()]
      public string gxTpr_Mudanzafechaservicio
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Mudanzafechaservicio) ;
         }

         set {
            sdt.gxTpr_Mudanzafechaservicio = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "MudanzaDireccionOrigen" , Order = 65 )]
      [GxSeudo()]
      public string gxTpr_Mudanzadireccionorigen
      {
         get {
            return sdt.gxTpr_Mudanzadireccionorigen ;
         }

         set {
            sdt.gxTpr_Mudanzadireccionorigen = value;
         }

      }

      [DataMember( Name = "MudanzaDireccionDestino" , Order = 66 )]
      [GxSeudo()]
      public string gxTpr_Mudanzadirecciondestino
      {
         get {
            return sdt.gxTpr_Mudanzadirecciondestino ;
         }

         set {
            sdt.gxTpr_Mudanzadirecciondestino = value;
         }

      }

      [DataMember( Name = "PostulacionesId" , Order = 67 )]
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

      [DataMember( Name = "SolicitudesDuplicado" , Order = 68 )]
      [GxSeudo()]
      public string gxTpr_Solicitudesduplicado
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Solicitudesduplicado), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Solicitudesduplicado = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "SolicitudesSerialArchivo" , Order = 69 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Solicitudesserialarchivo
      {
         get {
            return sdt.gxTpr_Solicitudesserialarchivo ;
         }

         set {
            sdt.gxTpr_Solicitudesserialarchivo = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "CancelacionTipificacionId" , Order = 70 )]
      [GxSeudo()]
      public string gxTpr_Cancelaciontipificacionid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Cancelaciontipificacionid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Cancelaciontipificacionid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "CancelacionTipificacionDescripcion" , Order = 71 )]
      [GxSeudo()]
      public string gxTpr_Cancelaciontipificaciondescripcion
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Cancelaciontipificaciondescripcion) ;
         }

         set {
            sdt.gxTpr_Cancelaciontipificaciondescripcion = value;
         }

      }

      [DataMember( Name = "SolicitudesCostoPresupuesto" , Order = 72 )]
      [GxSeudo()]
      public string gxTpr_Solicitudescostopresupuesto
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Solicitudescostopresupuesto, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Solicitudescostopresupuesto = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "SolicitudesURLOrigen" , Order = 73 )]
      [GxSeudo()]
      public string gxTpr_Solicitudesurlorigen
      {
         get {
            return sdt.gxTpr_Solicitudesurlorigen ;
         }

         set {
            sdt.gxTpr_Solicitudesurlorigen = value;
         }

      }

      [DataMember( Name = "TicketId" , Order = 74 )]
      [GxSeudo()]
      public string gxTpr_Ticketid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Ticketid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Ticketid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "TicketMotivoId" , Order = 75 )]
      [GxSeudo()]
      public string gxTpr_Ticketmotivoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Ticketmotivoid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Ticketmotivoid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "TicketMotivoDescripcion" , Order = 76 )]
      [GxSeudo()]
      public string gxTpr_Ticketmotivodescripcion
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Ticketmotivodescripcion) ;
         }

         set {
            sdt.gxTpr_Ticketmotivodescripcion = value;
         }

      }

      [DataMember( Name = "TicketComentario" , Order = 77 )]
      [GxSeudo()]
      public string gxTpr_Ticketcomentario
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Ticketcomentario) ;
         }

         set {
            sdt.gxTpr_Ticketcomentario = value;
         }

      }

      [DataMember( Name = "TicketAdjunto" , Order = 78 )]
      [GxSeudo()]
      public string gxTpr_Ticketadjunto
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Ticketadjunto) ;
         }

         set {
            sdt.gxTpr_Ticketadjunto = value;
         }

      }

      [DataMember( Name = "TicketEstado" , Order = 79 )]
      [GxSeudo()]
      public bool gxTpr_Ticketestado
      {
         get {
            return sdt.gxTpr_Ticketestado ;
         }

         set {
            sdt.gxTpr_Ticketestado = value;
         }

      }

      [DataMember( Name = "TicketSolicitudId" , Order = 80 )]
      [GxSeudo()]
      public string gxTpr_Ticketsolicitudid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Ticketsolicitudid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Ticketsolicitudid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "Archivo" , Order = 81 )]
      public GxGenericCollection<SdtSolicitudes_Archivo_RESTInterface> gxTpr_Archivo
      {
         get {
            return new GxGenericCollection<SdtSolicitudes_Archivo_RESTInterface>(sdt.gxTpr_Archivo) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Archivo);
         }

      }

      public SdtSolicitudes sdt
      {
         get {
            return (SdtSolicitudes)Sdt ;
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
            sdt = new SdtSolicitudes() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 82 )]
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

   [DataContract(Name = @"Solicitudes", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtSolicitudes_RESTLInterface : GxGenericCollectionItem<SdtSolicitudes>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtSolicitudes_RESTLInterface( ) : base()
      {
      }

      public SdtSolicitudes_RESTLInterface( SdtSolicitudes psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SolicitudesNombre" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Solicitudesnombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Solicitudesnombre) ;
         }

         set {
            sdt.gxTpr_Solicitudesnombre = value;
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

      public SdtSolicitudes sdt
      {
         get {
            return (SdtSolicitudes)Sdt ;
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
            sdt = new SdtSolicitudes() ;
         }
      }

   }

}
