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
   [XmlRoot(ElementName = "Solicitudes.Items" )]
   [XmlType(TypeName =  "Solicitudes.Items" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtSolicitudes_Items : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtSolicitudes_Items( )
      {
      }

      public SdtSolicitudes_Items( IGxContext context )
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

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"SolicitudesItemsID", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Items");
         metadata.Set("BT", "SolicitudesItems");
         metadata.Set("PK", "[ \"SolicitudesItemsID\" ]");
         metadata.Set("PKAssigned", "[ \"SolicitudesItemsID\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"RubrosId\",\"MedidasID\",\"InventarioId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"SolicitudesID\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Rubrosimagen_gxi");
         state.Add("gxTpr_Inventarioimagen_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Modified");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Solicitudesitemsid_Z");
         state.Add("gxTpr_Rubrosid_Z");
         state.Add("gxTpr_Rubrosestado_Z");
         state.Add("gxTpr_Medidasid_Z");
         state.Add("gxTpr_Inventarioid_Z");
         state.Add("gxTpr_Inventarionombre_Z");
         state.Add("gxTpr_Inventariopreciofinal_Z");
         state.Add("gxTpr_Inventarioconsumoproductivo_Z");
         state.Add("gxTpr_Estadostipo_Z");
         state.Add("gxTpr_Estadosgenericosid_Z");
         state.Add("gxTpr_Solicitudesitemspreciofinal_Z");
         state.Add("gxTpr_Solicitudesprecioesfreezado_Z");
         state.Add("gxTpr_Solicitudesitemscantidad_Z");
         state.Add("gxTpr_Solicituditemscomision_Z");
         state.Add("gxTpr_Solicituditemssr_Z");
         state.Add("gxTpr_Solicituditemscomisiontipo_Z");
         state.Add("gxTpr_Solicitudesitemsprecioinstalacion_Z");
         state.Add("gxTpr_Monedaid_Z");
         state.Add("gxTpr_Monedaisosimbolo_Z");
         state.Add("gxTpr_Solicitudesitemscomiprov_Z");
         state.Add("gxTpr_Solicitudesitemscomiprovp_Z");
         state.Add("gxTpr_Solicitudesitemscomialm_Z");
         state.Add("gxTpr_Solicitudesitemscomialmp_Z");
         state.Add("gxTpr_Solicitudesitemscomiprof_Z");
         state.Add("gxTpr_Solicitudesitemscomiprofp_Z");
         state.Add("gxTpr_Rubrosimagen_gxi_Z");
         state.Add("gxTpr_Inventarioimagen_gxi_Z");
         state.Add("gxTpr_Rubrosestado_N");
         state.Add("gxTpr_Solicitudesitemspreciofinal_N");
         state.Add("gxTpr_Solicitudesitemscomiprov_N");
         state.Add("gxTpr_Solicitudesitemscomiprovp_N");
         state.Add("gxTpr_Solicitudesitemscomialm_N");
         state.Add("gxTpr_Solicitudesitemscomialmp_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtSolicitudes_Items sdt;
         sdt = (SdtSolicitudes_Items)(source);
         gxTv_SdtSolicitudes_Items_Solicitudesitemsid = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemsid ;
         gxTv_SdtSolicitudes_Items_Rubrosid = sdt.gxTv_SdtSolicitudes_Items_Rubrosid ;
         gxTv_SdtSolicitudes_Items_Rubrosimagen = sdt.gxTv_SdtSolicitudes_Items_Rubrosimagen ;
         gxTv_SdtSolicitudes_Items_Rubrosimagen_gxi = sdt.gxTv_SdtSolicitudes_Items_Rubrosimagen_gxi ;
         gxTv_SdtSolicitudes_Items_Rubrosestado = sdt.gxTv_SdtSolicitudes_Items_Rubrosestado ;
         gxTv_SdtSolicitudes_Items_Medidasid = sdt.gxTv_SdtSolicitudes_Items_Medidasid ;
         gxTv_SdtSolicitudes_Items_Inventarioid = sdt.gxTv_SdtSolicitudes_Items_Inventarioid ;
         gxTv_SdtSolicitudes_Items_Inventarionombre = sdt.gxTv_SdtSolicitudes_Items_Inventarionombre ;
         gxTv_SdtSolicitudes_Items_Inventarioimagen = sdt.gxTv_SdtSolicitudes_Items_Inventarioimagen ;
         gxTv_SdtSolicitudes_Items_Inventarioimagen_gxi = sdt.gxTv_SdtSolicitudes_Items_Inventarioimagen_gxi ;
         gxTv_SdtSolicitudes_Items_Inventariopreciofinal = sdt.gxTv_SdtSolicitudes_Items_Inventariopreciofinal ;
         gxTv_SdtSolicitudes_Items_Inventarioconsumoproductivo = sdt.gxTv_SdtSolicitudes_Items_Inventarioconsumoproductivo ;
         gxTv_SdtSolicitudes_Items_Estadostipo = sdt.gxTv_SdtSolicitudes_Items_Estadostipo ;
         gxTv_SdtSolicitudes_Items_Estadosgenericosid = sdt.gxTv_SdtSolicitudes_Items_Estadosgenericosid ;
         gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal ;
         gxTv_SdtSolicitudes_Items_Solicitudesprecioesfreezado = sdt.gxTv_SdtSolicitudes_Items_Solicitudesprecioesfreezado ;
         gxTv_SdtSolicitudes_Items_Solicitudesitemscantidad = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemscantidad ;
         gxTv_SdtSolicitudes_Items_Solicituditemscomision = sdt.gxTv_SdtSolicitudes_Items_Solicituditemscomision ;
         gxTv_SdtSolicitudes_Items_Solicituditemssr = sdt.gxTv_SdtSolicitudes_Items_Solicituditemssr ;
         gxTv_SdtSolicitudes_Items_Solicituditemscomisiontipo = sdt.gxTv_SdtSolicitudes_Items_Solicituditemscomisiontipo ;
         gxTv_SdtSolicitudes_Items_Solicitudesitemsprecioinstalacion = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemsprecioinstalacion ;
         gxTv_SdtSolicitudes_Items_Monedaid = sdt.gxTv_SdtSolicitudes_Items_Monedaid ;
         gxTv_SdtSolicitudes_Items_Monedaisosimbolo = sdt.gxTv_SdtSolicitudes_Items_Monedaisosimbolo ;
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov ;
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp ;
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm ;
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp ;
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprof = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprof ;
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprofp = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprofp ;
         gxTv_SdtSolicitudes_Items_Mode = sdt.gxTv_SdtSolicitudes_Items_Mode ;
         gxTv_SdtSolicitudes_Items_Modified = sdt.gxTv_SdtSolicitudes_Items_Modified ;
         gxTv_SdtSolicitudes_Items_Initialized = sdt.gxTv_SdtSolicitudes_Items_Initialized ;
         gxTv_SdtSolicitudes_Items_Solicitudesitemsid_Z = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemsid_Z ;
         gxTv_SdtSolicitudes_Items_Rubrosid_Z = sdt.gxTv_SdtSolicitudes_Items_Rubrosid_Z ;
         gxTv_SdtSolicitudes_Items_Rubrosestado_Z = sdt.gxTv_SdtSolicitudes_Items_Rubrosestado_Z ;
         gxTv_SdtSolicitudes_Items_Medidasid_Z = sdt.gxTv_SdtSolicitudes_Items_Medidasid_Z ;
         gxTv_SdtSolicitudes_Items_Inventarioid_Z = sdt.gxTv_SdtSolicitudes_Items_Inventarioid_Z ;
         gxTv_SdtSolicitudes_Items_Inventarionombre_Z = sdt.gxTv_SdtSolicitudes_Items_Inventarionombre_Z ;
         gxTv_SdtSolicitudes_Items_Inventariopreciofinal_Z = sdt.gxTv_SdtSolicitudes_Items_Inventariopreciofinal_Z ;
         gxTv_SdtSolicitudes_Items_Inventarioconsumoproductivo_Z = sdt.gxTv_SdtSolicitudes_Items_Inventarioconsumoproductivo_Z ;
         gxTv_SdtSolicitudes_Items_Estadostipo_Z = sdt.gxTv_SdtSolicitudes_Items_Estadostipo_Z ;
         gxTv_SdtSolicitudes_Items_Estadosgenericosid_Z = sdt.gxTv_SdtSolicitudes_Items_Estadosgenericosid_Z ;
         gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal_Z = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal_Z ;
         gxTv_SdtSolicitudes_Items_Solicitudesprecioesfreezado_Z = sdt.gxTv_SdtSolicitudes_Items_Solicitudesprecioesfreezado_Z ;
         gxTv_SdtSolicitudes_Items_Solicitudesitemscantidad_Z = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemscantidad_Z ;
         gxTv_SdtSolicitudes_Items_Solicituditemscomision_Z = sdt.gxTv_SdtSolicitudes_Items_Solicituditemscomision_Z ;
         gxTv_SdtSolicitudes_Items_Solicituditemssr_Z = sdt.gxTv_SdtSolicitudes_Items_Solicituditemssr_Z ;
         gxTv_SdtSolicitudes_Items_Solicituditemscomisiontipo_Z = sdt.gxTv_SdtSolicitudes_Items_Solicituditemscomisiontipo_Z ;
         gxTv_SdtSolicitudes_Items_Solicitudesitemsprecioinstalacion_Z = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemsprecioinstalacion_Z ;
         gxTv_SdtSolicitudes_Items_Monedaid_Z = sdt.gxTv_SdtSolicitudes_Items_Monedaid_Z ;
         gxTv_SdtSolicitudes_Items_Monedaisosimbolo_Z = sdt.gxTv_SdtSolicitudes_Items_Monedaisosimbolo_Z ;
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov_Z = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov_Z ;
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp_Z = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp_Z ;
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm_Z = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm_Z ;
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp_Z = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp_Z ;
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprof_Z = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprof_Z ;
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprofp_Z = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprofp_Z ;
         gxTv_SdtSolicitudes_Items_Rubrosimagen_gxi_Z = sdt.gxTv_SdtSolicitudes_Items_Rubrosimagen_gxi_Z ;
         gxTv_SdtSolicitudes_Items_Inventarioimagen_gxi_Z = sdt.gxTv_SdtSolicitudes_Items_Inventarioimagen_gxi_Z ;
         gxTv_SdtSolicitudes_Items_Rubrosestado_N = sdt.gxTv_SdtSolicitudes_Items_Rubrosestado_N ;
         gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal_N = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal_N ;
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov_N = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov_N ;
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp_N = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp_N ;
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm_N = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm_N ;
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp_N = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp_N ;
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
         AddObjectProperty("SolicitudesItemsID", gxTv_SdtSolicitudes_Items_Solicitudesitemsid, false, includeNonInitialized);
         AddObjectProperty("RubrosId", gxTv_SdtSolicitudes_Items_Rubrosid, false, includeNonInitialized);
         AddObjectProperty("RubrosImagen", gxTv_SdtSolicitudes_Items_Rubrosimagen, false, includeNonInitialized);
         AddObjectProperty("RubrosEstado", gxTv_SdtSolicitudes_Items_Rubrosestado, false, includeNonInitialized);
         AddObjectProperty("RubrosEstado_N", gxTv_SdtSolicitudes_Items_Rubrosestado_N, false, includeNonInitialized);
         AddObjectProperty("MedidasID", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Items_Medidasid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("InventarioId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Items_Inventarioid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("InventarioNombre", gxTv_SdtSolicitudes_Items_Inventarionombre, false, includeNonInitialized);
         AddObjectProperty("InventarioImagen", gxTv_SdtSolicitudes_Items_Inventarioimagen, false, includeNonInitialized);
         AddObjectProperty("InventarioPrecioFinal", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Items_Inventariopreciofinal, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("InventarioConsumoProductivo", gxTv_SdtSolicitudes_Items_Inventarioconsumoproductivo, false, includeNonInitialized);
         AddObjectProperty("EstadosTipo", gxTv_SdtSolicitudes_Items_Estadostipo, false, includeNonInitialized);
         AddObjectProperty("EstadosGenericosId", gxTv_SdtSolicitudes_Items_Estadosgenericosid, false, includeNonInitialized);
         AddObjectProperty("SolicitudesItemsPrecioFinal", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("SolicitudesItemsPrecioFinal_N", gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal_N, false, includeNonInitialized);
         AddObjectProperty("SolicitudesPrecioEsFreezado", gxTv_SdtSolicitudes_Items_Solicitudesprecioesfreezado, false, includeNonInitialized);
         AddObjectProperty("SolicitudesItemsCantidad", gxTv_SdtSolicitudes_Items_Solicitudesitemscantidad, false, includeNonInitialized);
         AddObjectProperty("SolicitudItemsComision", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Items_Solicituditemscomision, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("SolicitudItemsSR", gxTv_SdtSolicitudes_Items_Solicituditemssr, false, includeNonInitialized);
         AddObjectProperty("SolicitudItemsComisionTipo", gxTv_SdtSolicitudes_Items_Solicituditemscomisiontipo, false, includeNonInitialized);
         AddObjectProperty("SolicitudesItemsPrecioInstalacion", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Items_Solicitudesitemsprecioinstalacion, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("MonedaId", gxTv_SdtSolicitudes_Items_Monedaid, false, includeNonInitialized);
         AddObjectProperty("MonedaISOSimbolo", gxTv_SdtSolicitudes_Items_Monedaisosimbolo, false, includeNonInitialized);
         AddObjectProperty("SolicitudesItemsComiProv", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("SolicitudesItemsComiProv_N", gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov_N, false, includeNonInitialized);
         AddObjectProperty("SolicitudesItemsComiProvP", gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp, false, includeNonInitialized);
         AddObjectProperty("SolicitudesItemsComiProvP_N", gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp_N, false, includeNonInitialized);
         AddObjectProperty("SolicitudesItemsComiALM", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("SolicitudesItemsComiALM_N", gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm_N, false, includeNonInitialized);
         AddObjectProperty("SolicitudesItemsComiALMP", gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp, false, includeNonInitialized);
         AddObjectProperty("SolicitudesItemsComiALMP_N", gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp_N, false, includeNonInitialized);
         AddObjectProperty("SolicitudesItemsComiProf", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprof, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("SolicitudesItemsComiProfP", gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprofp, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("RubrosImagen_GXI", gxTv_SdtSolicitudes_Items_Rubrosimagen_gxi, false, includeNonInitialized);
            AddObjectProperty("InventarioImagen_GXI", gxTv_SdtSolicitudes_Items_Inventarioimagen_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtSolicitudes_Items_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtSolicitudes_Items_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtSolicitudes_Items_Initialized, false, includeNonInitialized);
            AddObjectProperty("SolicitudesItemsID_Z", gxTv_SdtSolicitudes_Items_Solicitudesitemsid_Z, false, includeNonInitialized);
            AddObjectProperty("RubrosId_Z", gxTv_SdtSolicitudes_Items_Rubrosid_Z, false, includeNonInitialized);
            AddObjectProperty("RubrosEstado_Z", gxTv_SdtSolicitudes_Items_Rubrosestado_Z, false, includeNonInitialized);
            AddObjectProperty("MedidasID_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Items_Medidasid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("InventarioId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Items_Inventarioid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("InventarioNombre_Z", gxTv_SdtSolicitudes_Items_Inventarionombre_Z, false, includeNonInitialized);
            AddObjectProperty("InventarioPrecioFinal_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Items_Inventariopreciofinal_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("InventarioConsumoProductivo_Z", gxTv_SdtSolicitudes_Items_Inventarioconsumoproductivo_Z, false, includeNonInitialized);
            AddObjectProperty("EstadosTipo_Z", gxTv_SdtSolicitudes_Items_Estadostipo_Z, false, includeNonInitialized);
            AddObjectProperty("EstadosGenericosId_Z", gxTv_SdtSolicitudes_Items_Estadosgenericosid_Z, false, includeNonInitialized);
            AddObjectProperty("SolicitudesItemsPrecioFinal_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("SolicitudesPrecioEsFreezado_Z", gxTv_SdtSolicitudes_Items_Solicitudesprecioesfreezado_Z, false, includeNonInitialized);
            AddObjectProperty("SolicitudesItemsCantidad_Z", gxTv_SdtSolicitudes_Items_Solicitudesitemscantidad_Z, false, includeNonInitialized);
            AddObjectProperty("SolicitudItemsComision_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Items_Solicituditemscomision_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("SolicitudItemsSR_Z", gxTv_SdtSolicitudes_Items_Solicituditemssr_Z, false, includeNonInitialized);
            AddObjectProperty("SolicitudItemsComisionTipo_Z", gxTv_SdtSolicitudes_Items_Solicituditemscomisiontipo_Z, false, includeNonInitialized);
            AddObjectProperty("SolicitudesItemsPrecioInstalacion_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Items_Solicitudesitemsprecioinstalacion_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("MonedaId_Z", gxTv_SdtSolicitudes_Items_Monedaid_Z, false, includeNonInitialized);
            AddObjectProperty("MonedaISOSimbolo_Z", gxTv_SdtSolicitudes_Items_Monedaisosimbolo_Z, false, includeNonInitialized);
            AddObjectProperty("SolicitudesItemsComiProv_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("SolicitudesItemsComiProvP_Z", gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp_Z, false, includeNonInitialized);
            AddObjectProperty("SolicitudesItemsComiALM_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("SolicitudesItemsComiALMP_Z", gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp_Z, false, includeNonInitialized);
            AddObjectProperty("SolicitudesItemsComiProf_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprof_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("SolicitudesItemsComiProfP_Z", gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprofp_Z, false, includeNonInitialized);
            AddObjectProperty("RubrosImagen_GXI_Z", gxTv_SdtSolicitudes_Items_Rubrosimagen_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("InventarioImagen_GXI_Z", gxTv_SdtSolicitudes_Items_Inventarioimagen_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("RubrosEstado_N", gxTv_SdtSolicitudes_Items_Rubrosestado_N, false, includeNonInitialized);
            AddObjectProperty("SolicitudesItemsPrecioFinal_N", gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal_N, false, includeNonInitialized);
            AddObjectProperty("SolicitudesItemsComiProv_N", gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov_N, false, includeNonInitialized);
            AddObjectProperty("SolicitudesItemsComiProvP_N", gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp_N, false, includeNonInitialized);
            AddObjectProperty("SolicitudesItemsComiALM_N", gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm_N, false, includeNonInitialized);
            AddObjectProperty("SolicitudesItemsComiALMP_N", gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtSolicitudes_Items sdt )
      {
         if ( sdt.IsDirty("SolicitudesItemsID") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemsid = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemsid ;
         }
         if ( sdt.IsDirty("RubrosId") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Rubrosid = sdt.gxTv_SdtSolicitudes_Items_Rubrosid ;
         }
         if ( sdt.IsDirty("RubrosImagen") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Rubrosimagen = sdt.gxTv_SdtSolicitudes_Items_Rubrosimagen ;
         }
         if ( sdt.IsDirty("RubrosImagen") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Rubrosimagen_gxi = sdt.gxTv_SdtSolicitudes_Items_Rubrosimagen_gxi ;
         }
         if ( sdt.IsDirty("RubrosEstado") )
         {
            gxTv_SdtSolicitudes_Items_Rubrosestado_N = (short)(sdt.gxTv_SdtSolicitudes_Items_Rubrosestado_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Rubrosestado = sdt.gxTv_SdtSolicitudes_Items_Rubrosestado ;
         }
         if ( sdt.IsDirty("MedidasID") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Medidasid = sdt.gxTv_SdtSolicitudes_Items_Medidasid ;
         }
         if ( sdt.IsDirty("InventarioId") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Inventarioid = sdt.gxTv_SdtSolicitudes_Items_Inventarioid ;
         }
         if ( sdt.IsDirty("InventarioNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Inventarionombre = sdt.gxTv_SdtSolicitudes_Items_Inventarionombre ;
         }
         if ( sdt.IsDirty("InventarioImagen") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Inventarioimagen = sdt.gxTv_SdtSolicitudes_Items_Inventarioimagen ;
         }
         if ( sdt.IsDirty("InventarioImagen") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Inventarioimagen_gxi = sdt.gxTv_SdtSolicitudes_Items_Inventarioimagen_gxi ;
         }
         if ( sdt.IsDirty("InventarioPrecioFinal") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Inventariopreciofinal = sdt.gxTv_SdtSolicitudes_Items_Inventariopreciofinal ;
         }
         if ( sdt.IsDirty("InventarioConsumoProductivo") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Inventarioconsumoproductivo = sdt.gxTv_SdtSolicitudes_Items_Inventarioconsumoproductivo ;
         }
         if ( sdt.IsDirty("EstadosTipo") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Estadostipo = sdt.gxTv_SdtSolicitudes_Items_Estadostipo ;
         }
         if ( sdt.IsDirty("EstadosGenericosId") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Estadosgenericosid = sdt.gxTv_SdtSolicitudes_Items_Estadosgenericosid ;
         }
         if ( sdt.IsDirty("SolicitudesItemsPrecioFinal") )
         {
            gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal_N = (short)(sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal ;
         }
         if ( sdt.IsDirty("SolicitudesPrecioEsFreezado") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesprecioesfreezado = sdt.gxTv_SdtSolicitudes_Items_Solicitudesprecioesfreezado ;
         }
         if ( sdt.IsDirty("SolicitudesItemsCantidad") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemscantidad = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemscantidad ;
         }
         if ( sdt.IsDirty("SolicitudItemsComision") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicituditemscomision = sdt.gxTv_SdtSolicitudes_Items_Solicituditemscomision ;
         }
         if ( sdt.IsDirty("SolicitudItemsSR") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicituditemssr = sdt.gxTv_SdtSolicitudes_Items_Solicituditemssr ;
         }
         if ( sdt.IsDirty("SolicitudItemsComisionTipo") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicituditemscomisiontipo = sdt.gxTv_SdtSolicitudes_Items_Solicituditemscomisiontipo ;
         }
         if ( sdt.IsDirty("SolicitudesItemsPrecioInstalacion") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemsprecioinstalacion = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemsprecioinstalacion ;
         }
         if ( sdt.IsDirty("MonedaId") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Monedaid = sdt.gxTv_SdtSolicitudes_Items_Monedaid ;
         }
         if ( sdt.IsDirty("MonedaISOSimbolo") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Monedaisosimbolo = sdt.gxTv_SdtSolicitudes_Items_Monedaisosimbolo ;
         }
         if ( sdt.IsDirty("SolicitudesItemsComiProv") )
         {
            gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov_N = (short)(sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov ;
         }
         if ( sdt.IsDirty("SolicitudesItemsComiProvP") )
         {
            gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp_N = (short)(sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp ;
         }
         if ( sdt.IsDirty("SolicitudesItemsComiALM") )
         {
            gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm_N = (short)(sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm ;
         }
         if ( sdt.IsDirty("SolicitudesItemsComiALMP") )
         {
            gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp_N = (short)(sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp_N);
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp ;
         }
         if ( sdt.IsDirty("SolicitudesItemsComiProf") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprof = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprof ;
         }
         if ( sdt.IsDirty("SolicitudesItemsComiProfP") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprofp = sdt.gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprofp ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "SolicitudesItemsID" )]
      [  XmlElement( ElementName = "SolicitudesItemsID"   )]
      public short gxTpr_Solicitudesitemsid
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicitudesitemsid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemsid = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicitudesitemsid");
         }

      }

      [  SoapElement( ElementName = "RubrosId" )]
      [  XmlElement( ElementName = "RubrosId"   )]
      public short gxTpr_Rubrosid
      {
         get {
            return gxTv_SdtSolicitudes_Items_Rubrosid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Rubrosid = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Rubrosid");
         }

      }

      [  SoapElement( ElementName = "RubrosImagen" )]
      [  XmlElement( ElementName = "RubrosImagen"   )]
      [GxUpload()]
      public string gxTpr_Rubrosimagen
      {
         get {
            return gxTv_SdtSolicitudes_Items_Rubrosimagen ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Rubrosimagen = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Rubrosimagen");
         }

      }

      [  SoapElement( ElementName = "RubrosImagen_GXI" )]
      [  XmlElement( ElementName = "RubrosImagen_GXI"   )]
      public string gxTpr_Rubrosimagen_gxi
      {
         get {
            return gxTv_SdtSolicitudes_Items_Rubrosimagen_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Rubrosimagen_gxi = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Rubrosimagen_gxi");
         }

      }

      [  SoapElement( ElementName = "RubrosEstado" )]
      [  XmlElement( ElementName = "RubrosEstado"   )]
      public string gxTpr_Rubrosestado
      {
         get {
            return gxTv_SdtSolicitudes_Items_Rubrosestado ;
         }

         set {
            gxTv_SdtSolicitudes_Items_Rubrosestado_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Rubrosestado = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Rubrosestado");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Rubrosestado_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Rubrosestado_N = 1;
         gxTv_SdtSolicitudes_Items_Rubrosestado = "";
         SetDirty("Rubrosestado");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Rubrosestado_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Items_Rubrosestado_N==1) ;
      }

      [  SoapElement( ElementName = "MedidasID" )]
      [  XmlElement( ElementName = "MedidasID"   )]
      public long gxTpr_Medidasid
      {
         get {
            return gxTv_SdtSolicitudes_Items_Medidasid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Medidasid = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Medidasid");
         }

      }

      [  SoapElement( ElementName = "InventarioId" )]
      [  XmlElement( ElementName = "InventarioId"   )]
      public long gxTpr_Inventarioid
      {
         get {
            return gxTv_SdtSolicitudes_Items_Inventarioid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Inventarioid = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Inventarioid");
         }

      }

      [  SoapElement( ElementName = "InventarioNombre" )]
      [  XmlElement( ElementName = "InventarioNombre"   )]
      public string gxTpr_Inventarionombre
      {
         get {
            return gxTv_SdtSolicitudes_Items_Inventarionombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Inventarionombre = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Inventarionombre");
         }

      }

      [  SoapElement( ElementName = "InventarioImagen" )]
      [  XmlElement( ElementName = "InventarioImagen"   )]
      [GxUpload()]
      public string gxTpr_Inventarioimagen
      {
         get {
            return gxTv_SdtSolicitudes_Items_Inventarioimagen ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Inventarioimagen = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Inventarioimagen");
         }

      }

      [  SoapElement( ElementName = "InventarioImagen_GXI" )]
      [  XmlElement( ElementName = "InventarioImagen_GXI"   )]
      public string gxTpr_Inventarioimagen_gxi
      {
         get {
            return gxTv_SdtSolicitudes_Items_Inventarioimagen_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Inventarioimagen_gxi = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Inventarioimagen_gxi");
         }

      }

      [  SoapElement( ElementName = "InventarioPrecioFinal" )]
      [  XmlElement( ElementName = "InventarioPrecioFinal"   )]
      public decimal gxTpr_Inventariopreciofinal
      {
         get {
            return gxTv_SdtSolicitudes_Items_Inventariopreciofinal ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Inventariopreciofinal = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Inventariopreciofinal");
         }

      }

      [  SoapElement( ElementName = "InventarioConsumoProductivo" )]
      [  XmlElement( ElementName = "InventarioConsumoProductivo"   )]
      public decimal gxTpr_Inventarioconsumoproductivo
      {
         get {
            return gxTv_SdtSolicitudes_Items_Inventarioconsumoproductivo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Inventarioconsumoproductivo = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Inventarioconsumoproductivo");
         }

      }

      [  SoapElement( ElementName = "EstadosTipo" )]
      [  XmlElement( ElementName = "EstadosTipo"   )]
      public string gxTpr_Estadostipo
      {
         get {
            return gxTv_SdtSolicitudes_Items_Estadostipo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Estadostipo = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Estadostipo");
         }

      }

      [  SoapElement( ElementName = "EstadosGenericosId" )]
      [  XmlElement( ElementName = "EstadosGenericosId"   )]
      public int gxTpr_Estadosgenericosid
      {
         get {
            return gxTv_SdtSolicitudes_Items_Estadosgenericosid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Estadosgenericosid = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Estadosgenericosid");
         }

      }

      [  SoapElement( ElementName = "SolicitudesItemsPrecioFinal" )]
      [  XmlElement( ElementName = "SolicitudesItemsPrecioFinal"   )]
      public decimal gxTpr_Solicitudesitemspreciofinal
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal ;
         }

         set {
            gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicitudesitemspreciofinal");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal_N = 1;
         gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal = 0;
         SetDirty("Solicitudesitemspreciofinal");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal_N==1) ;
      }

      [  SoapElement( ElementName = "SolicitudesPrecioEsFreezado" )]
      [  XmlElement( ElementName = "SolicitudesPrecioEsFreezado"   )]
      public bool gxTpr_Solicitudesprecioesfreezado
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicitudesprecioesfreezado ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesprecioesfreezado = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicitudesprecioesfreezado");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Solicitudesprecioesfreezado_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Solicitudesprecioesfreezado = false;
         SetDirty("Solicitudesprecioesfreezado");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Solicitudesprecioesfreezado_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesItemsCantidad" )]
      [  XmlElement( ElementName = "SolicitudesItemsCantidad"   )]
      public short gxTpr_Solicitudesitemscantidad
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicitudesitemscantidad ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemscantidad = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicitudesitemscantidad");
         }

      }

      [  SoapElement( ElementName = "SolicitudItemsComision" )]
      [  XmlElement( ElementName = "SolicitudItemsComision"   )]
      public decimal gxTpr_Solicituditemscomision
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicituditemscomision ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicituditemscomision = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicituditemscomision");
         }

      }

      [  SoapElement( ElementName = "SolicitudItemsSR" )]
      [  XmlElement( ElementName = "SolicitudItemsSR"   )]
      public string gxTpr_Solicituditemssr
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicituditemssr ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicituditemssr = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicituditemssr");
         }

      }

      [  SoapElement( ElementName = "SolicitudItemsComisionTipo" )]
      [  XmlElement( ElementName = "SolicitudItemsComisionTipo"   )]
      public string gxTpr_Solicituditemscomisiontipo
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicituditemscomisiontipo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicituditemscomisiontipo = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicituditemscomisiontipo");
         }

      }

      [  SoapElement( ElementName = "SolicitudesItemsPrecioInstalacion" )]
      [  XmlElement( ElementName = "SolicitudesItemsPrecioInstalacion"   )]
      public decimal gxTpr_Solicitudesitemsprecioinstalacion
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicitudesitemsprecioinstalacion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemsprecioinstalacion = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicitudesitemsprecioinstalacion");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Solicitudesitemsprecioinstalacion_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Solicitudesitemsprecioinstalacion = 0;
         SetDirty("Solicitudesitemsprecioinstalacion");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Solicitudesitemsprecioinstalacion_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MonedaId" )]
      [  XmlElement( ElementName = "MonedaId"   )]
      public short gxTpr_Monedaid
      {
         get {
            return gxTv_SdtSolicitudes_Items_Monedaid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Monedaid = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Monedaid");
         }

      }

      [  SoapElement( ElementName = "MonedaISOSimbolo" )]
      [  XmlElement( ElementName = "MonedaISOSimbolo"   )]
      public string gxTpr_Monedaisosimbolo
      {
         get {
            return gxTv_SdtSolicitudes_Items_Monedaisosimbolo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Monedaisosimbolo = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Monedaisosimbolo");
         }

      }

      [  SoapElement( ElementName = "SolicitudesItemsComiProv" )]
      [  XmlElement( ElementName = "SolicitudesItemsComiProv"   )]
      public decimal gxTpr_Solicitudesitemscomiprov
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov ;
         }

         set {
            gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicitudesitemscomiprov");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov_N = 1;
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov = 0;
         SetDirty("Solicitudesitemscomiprov");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov_N==1) ;
      }

      [  SoapElement( ElementName = "SolicitudesItemsComiProvP" )]
      [  XmlElement( ElementName = "SolicitudesItemsComiProvP"   )]
      public decimal gxTpr_Solicitudesitemscomiprovp
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp ;
         }

         set {
            gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicitudesitemscomiprovp");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp_N = 1;
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp = 0;
         SetDirty("Solicitudesitemscomiprovp");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp_N==1) ;
      }

      [  SoapElement( ElementName = "SolicitudesItemsComiALM" )]
      [  XmlElement( ElementName = "SolicitudesItemsComiALM"   )]
      public decimal gxTpr_Solicitudesitemscomialm
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm ;
         }

         set {
            gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicitudesitemscomialm");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm_N = 1;
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm = 0;
         SetDirty("Solicitudesitemscomialm");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm_N==1) ;
      }

      [  SoapElement( ElementName = "SolicitudesItemsComiALMP" )]
      [  XmlElement( ElementName = "SolicitudesItemsComiALMP"   )]
      public decimal gxTpr_Solicitudesitemscomialmp
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp ;
         }

         set {
            gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicitudesitemscomialmp");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp_N = 1;
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp = 0;
         SetDirty("Solicitudesitemscomialmp");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp_IsNull( )
      {
         return (gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp_N==1) ;
      }

      [  SoapElement( ElementName = "SolicitudesItemsComiProf" )]
      [  XmlElement( ElementName = "SolicitudesItemsComiProf"   )]
      public decimal gxTpr_Solicitudesitemscomiprof
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprof ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprof = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicitudesitemscomiprof");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprof_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprof = 0;
         SetDirty("Solicitudesitemscomiprof");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprof_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesItemsComiProfP" )]
      [  XmlElement( ElementName = "SolicitudesItemsComiProfP"   )]
      public decimal gxTpr_Solicitudesitemscomiprofp
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprofp ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprofp = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicitudesitemscomiprofp");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprofp_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprofp = 0;
         SetDirty("Solicitudesitemscomiprofp");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprofp_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtSolicitudes_Items_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Mode_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtSolicitudes_Items_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Modified_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtSolicitudes_Items_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Initialized = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Initialized_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesItemsID_Z" )]
      [  XmlElement( ElementName = "SolicitudesItemsID_Z"   )]
      public short gxTpr_Solicitudesitemsid_Z
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicitudesitemsid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemsid_Z = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicitudesitemsid_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Solicitudesitemsid_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Solicitudesitemsid_Z = 0;
         SetDirty("Solicitudesitemsid_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Solicitudesitemsid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RubrosId_Z" )]
      [  XmlElement( ElementName = "RubrosId_Z"   )]
      public short gxTpr_Rubrosid_Z
      {
         get {
            return gxTv_SdtSolicitudes_Items_Rubrosid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Rubrosid_Z = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Rubrosid_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Rubrosid_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Rubrosid_Z = 0;
         SetDirty("Rubrosid_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Rubrosid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RubrosEstado_Z" )]
      [  XmlElement( ElementName = "RubrosEstado_Z"   )]
      public string gxTpr_Rubrosestado_Z
      {
         get {
            return gxTv_SdtSolicitudes_Items_Rubrosestado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Rubrosestado_Z = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Rubrosestado_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Rubrosestado_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Rubrosestado_Z = "";
         SetDirty("Rubrosestado_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Rubrosestado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedidasID_Z" )]
      [  XmlElement( ElementName = "MedidasID_Z"   )]
      public long gxTpr_Medidasid_Z
      {
         get {
            return gxTv_SdtSolicitudes_Items_Medidasid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Medidasid_Z = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Medidasid_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Medidasid_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Medidasid_Z = 0;
         SetDirty("Medidasid_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Medidasid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InventarioId_Z" )]
      [  XmlElement( ElementName = "InventarioId_Z"   )]
      public long gxTpr_Inventarioid_Z
      {
         get {
            return gxTv_SdtSolicitudes_Items_Inventarioid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Inventarioid_Z = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Inventarioid_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Inventarioid_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Inventarioid_Z = 0;
         SetDirty("Inventarioid_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Inventarioid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InventarioNombre_Z" )]
      [  XmlElement( ElementName = "InventarioNombre_Z"   )]
      public string gxTpr_Inventarionombre_Z
      {
         get {
            return gxTv_SdtSolicitudes_Items_Inventarionombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Inventarionombre_Z = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Inventarionombre_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Inventarionombre_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Inventarionombre_Z = "";
         SetDirty("Inventarionombre_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Inventarionombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InventarioPrecioFinal_Z" )]
      [  XmlElement( ElementName = "InventarioPrecioFinal_Z"   )]
      public decimal gxTpr_Inventariopreciofinal_Z
      {
         get {
            return gxTv_SdtSolicitudes_Items_Inventariopreciofinal_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Inventariopreciofinal_Z = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Inventariopreciofinal_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Inventariopreciofinal_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Inventariopreciofinal_Z = 0;
         SetDirty("Inventariopreciofinal_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Inventariopreciofinal_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InventarioConsumoProductivo_Z" )]
      [  XmlElement( ElementName = "InventarioConsumoProductivo_Z"   )]
      public decimal gxTpr_Inventarioconsumoproductivo_Z
      {
         get {
            return gxTv_SdtSolicitudes_Items_Inventarioconsumoproductivo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Inventarioconsumoproductivo_Z = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Inventarioconsumoproductivo_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Inventarioconsumoproductivo_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Inventarioconsumoproductivo_Z = 0;
         SetDirty("Inventarioconsumoproductivo_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Inventarioconsumoproductivo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EstadosTipo_Z" )]
      [  XmlElement( ElementName = "EstadosTipo_Z"   )]
      public string gxTpr_Estadostipo_Z
      {
         get {
            return gxTv_SdtSolicitudes_Items_Estadostipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Estadostipo_Z = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Estadostipo_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Estadostipo_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Estadostipo_Z = "";
         SetDirty("Estadostipo_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Estadostipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EstadosGenericosId_Z" )]
      [  XmlElement( ElementName = "EstadosGenericosId_Z"   )]
      public int gxTpr_Estadosgenericosid_Z
      {
         get {
            return gxTv_SdtSolicitudes_Items_Estadosgenericosid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Estadosgenericosid_Z = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Estadosgenericosid_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Estadosgenericosid_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Estadosgenericosid_Z = 0;
         SetDirty("Estadosgenericosid_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Estadosgenericosid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesItemsPrecioFinal_Z" )]
      [  XmlElement( ElementName = "SolicitudesItemsPrecioFinal_Z"   )]
      public decimal gxTpr_Solicitudesitemspreciofinal_Z
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal_Z = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicitudesitemspreciofinal_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal_Z = 0;
         SetDirty("Solicitudesitemspreciofinal_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesPrecioEsFreezado_Z" )]
      [  XmlElement( ElementName = "SolicitudesPrecioEsFreezado_Z"   )]
      public bool gxTpr_Solicitudesprecioesfreezado_Z
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicitudesprecioesfreezado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesprecioesfreezado_Z = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicitudesprecioesfreezado_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Solicitudesprecioesfreezado_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Solicitudesprecioesfreezado_Z = false;
         SetDirty("Solicitudesprecioesfreezado_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Solicitudesprecioesfreezado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesItemsCantidad_Z" )]
      [  XmlElement( ElementName = "SolicitudesItemsCantidad_Z"   )]
      public short gxTpr_Solicitudesitemscantidad_Z
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicitudesitemscantidad_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemscantidad_Z = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicitudesitemscantidad_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Solicitudesitemscantidad_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Solicitudesitemscantidad_Z = 0;
         SetDirty("Solicitudesitemscantidad_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Solicitudesitemscantidad_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudItemsComision_Z" )]
      [  XmlElement( ElementName = "SolicitudItemsComision_Z"   )]
      public decimal gxTpr_Solicituditemscomision_Z
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicituditemscomision_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicituditemscomision_Z = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicituditemscomision_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Solicituditemscomision_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Solicituditemscomision_Z = 0;
         SetDirty("Solicituditemscomision_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Solicituditemscomision_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudItemsSR_Z" )]
      [  XmlElement( ElementName = "SolicitudItemsSR_Z"   )]
      public string gxTpr_Solicituditemssr_Z
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicituditemssr_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicituditemssr_Z = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicituditemssr_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Solicituditemssr_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Solicituditemssr_Z = "";
         SetDirty("Solicituditemssr_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Solicituditemssr_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudItemsComisionTipo_Z" )]
      [  XmlElement( ElementName = "SolicitudItemsComisionTipo_Z"   )]
      public string gxTpr_Solicituditemscomisiontipo_Z
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicituditemscomisiontipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicituditemscomisiontipo_Z = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicituditemscomisiontipo_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Solicituditemscomisiontipo_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Solicituditemscomisiontipo_Z = "";
         SetDirty("Solicituditemscomisiontipo_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Solicituditemscomisiontipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesItemsPrecioInstalacion_Z" )]
      [  XmlElement( ElementName = "SolicitudesItemsPrecioInstalacion_Z"   )]
      public decimal gxTpr_Solicitudesitemsprecioinstalacion_Z
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicitudesitemsprecioinstalacion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemsprecioinstalacion_Z = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicitudesitemsprecioinstalacion_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Solicitudesitemsprecioinstalacion_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Solicitudesitemsprecioinstalacion_Z = 0;
         SetDirty("Solicitudesitemsprecioinstalacion_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Solicitudesitemsprecioinstalacion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MonedaId_Z" )]
      [  XmlElement( ElementName = "MonedaId_Z"   )]
      public short gxTpr_Monedaid_Z
      {
         get {
            return gxTv_SdtSolicitudes_Items_Monedaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Monedaid_Z = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Monedaid_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Monedaid_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Monedaid_Z = 0;
         SetDirty("Monedaid_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Monedaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MonedaISOSimbolo_Z" )]
      [  XmlElement( ElementName = "MonedaISOSimbolo_Z"   )]
      public string gxTpr_Monedaisosimbolo_Z
      {
         get {
            return gxTv_SdtSolicitudes_Items_Monedaisosimbolo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Monedaisosimbolo_Z = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Monedaisosimbolo_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Monedaisosimbolo_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Monedaisosimbolo_Z = "";
         SetDirty("Monedaisosimbolo_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Monedaisosimbolo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesItemsComiProv_Z" )]
      [  XmlElement( ElementName = "SolicitudesItemsComiProv_Z"   )]
      public decimal gxTpr_Solicitudesitemscomiprov_Z
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov_Z = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicitudesitemscomiprov_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov_Z = 0;
         SetDirty("Solicitudesitemscomiprov_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesItemsComiProvP_Z" )]
      [  XmlElement( ElementName = "SolicitudesItemsComiProvP_Z"   )]
      public decimal gxTpr_Solicitudesitemscomiprovp_Z
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp_Z = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicitudesitemscomiprovp_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp_Z = 0;
         SetDirty("Solicitudesitemscomiprovp_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesItemsComiALM_Z" )]
      [  XmlElement( ElementName = "SolicitudesItemsComiALM_Z"   )]
      public decimal gxTpr_Solicitudesitemscomialm_Z
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm_Z = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicitudesitemscomialm_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm_Z = 0;
         SetDirty("Solicitudesitemscomialm_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesItemsComiALMP_Z" )]
      [  XmlElement( ElementName = "SolicitudesItemsComiALMP_Z"   )]
      public decimal gxTpr_Solicitudesitemscomialmp_Z
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp_Z = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicitudesitemscomialmp_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp_Z = 0;
         SetDirty("Solicitudesitemscomialmp_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesItemsComiProf_Z" )]
      [  XmlElement( ElementName = "SolicitudesItemsComiProf_Z"   )]
      public decimal gxTpr_Solicitudesitemscomiprof_Z
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprof_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprof_Z = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicitudesitemscomiprof_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprof_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprof_Z = 0;
         SetDirty("Solicitudesitemscomiprof_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprof_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesItemsComiProfP_Z" )]
      [  XmlElement( ElementName = "SolicitudesItemsComiProfP_Z"   )]
      public decimal gxTpr_Solicitudesitemscomiprofp_Z
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprofp_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprofp_Z = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicitudesitemscomiprofp_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprofp_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprofp_Z = 0;
         SetDirty("Solicitudesitemscomiprofp_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprofp_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RubrosImagen_GXI_Z" )]
      [  XmlElement( ElementName = "RubrosImagen_GXI_Z"   )]
      public string gxTpr_Rubrosimagen_gxi_Z
      {
         get {
            return gxTv_SdtSolicitudes_Items_Rubrosimagen_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Rubrosimagen_gxi_Z = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Rubrosimagen_gxi_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Rubrosimagen_gxi_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Rubrosimagen_gxi_Z = "";
         SetDirty("Rubrosimagen_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Rubrosimagen_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InventarioImagen_GXI_Z" )]
      [  XmlElement( ElementName = "InventarioImagen_GXI_Z"   )]
      public string gxTpr_Inventarioimagen_gxi_Z
      {
         get {
            return gxTv_SdtSolicitudes_Items_Inventarioimagen_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Inventarioimagen_gxi_Z = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Inventarioimagen_gxi_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Inventarioimagen_gxi_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Inventarioimagen_gxi_Z = "";
         SetDirty("Inventarioimagen_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Inventarioimagen_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RubrosEstado_N" )]
      [  XmlElement( ElementName = "RubrosEstado_N"   )]
      public short gxTpr_Rubrosestado_N
      {
         get {
            return gxTv_SdtSolicitudes_Items_Rubrosestado_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Rubrosestado_N = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Rubrosestado_N");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Rubrosestado_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Rubrosestado_N = 0;
         SetDirty("Rubrosestado_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Rubrosestado_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesItemsPrecioFinal_N" )]
      [  XmlElement( ElementName = "SolicitudesItemsPrecioFinal_N"   )]
      public short gxTpr_Solicitudesitemspreciofinal_N
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal_N = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicitudesitemspreciofinal_N");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal_N = 0;
         SetDirty("Solicitudesitemspreciofinal_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesItemsComiProv_N" )]
      [  XmlElement( ElementName = "SolicitudesItemsComiProv_N"   )]
      public short gxTpr_Solicitudesitemscomiprov_N
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov_N = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicitudesitemscomiprov_N");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov_N = 0;
         SetDirty("Solicitudesitemscomiprov_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesItemsComiProvP_N" )]
      [  XmlElement( ElementName = "SolicitudesItemsComiProvP_N"   )]
      public short gxTpr_Solicitudesitemscomiprovp_N
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp_N = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicitudesitemscomiprovp_N");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp_N = 0;
         SetDirty("Solicitudesitemscomiprovp_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesItemsComiALM_N" )]
      [  XmlElement( ElementName = "SolicitudesItemsComiALM_N"   )]
      public short gxTpr_Solicitudesitemscomialm_N
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm_N = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicitudesitemscomialm_N");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm_N = 0;
         SetDirty("Solicitudesitemscomialm_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SolicitudesItemsComiALMP_N" )]
      [  XmlElement( ElementName = "SolicitudesItemsComiALMP_N"   )]
      public short gxTpr_Solicitudesitemscomialmp_N
      {
         get {
            return gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp_N = value;
            gxTv_SdtSolicitudes_Items_Modified = 1;
            SetDirty("Solicitudesitemscomialmp_N");
         }

      }

      public void gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp_N_SetNull( )
      {
         gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp_N = 0;
         SetDirty("Solicitudesitemscomialmp_N");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp_N_IsNull( )
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
         gxTv_SdtSolicitudes_Items_Rubrosimagen = "";
         gxTv_SdtSolicitudes_Items_Rubrosimagen_gxi = "";
         gxTv_SdtSolicitudes_Items_Rubrosestado = "";
         gxTv_SdtSolicitudes_Items_Inventarionombre = "";
         gxTv_SdtSolicitudes_Items_Inventarioimagen = "";
         gxTv_SdtSolicitudes_Items_Inventarioimagen_gxi = "";
         gxTv_SdtSolicitudes_Items_Estadostipo = "";
         gxTv_SdtSolicitudes_Items_Solicituditemssr = "";
         gxTv_SdtSolicitudes_Items_Solicituditemscomisiontipo = "";
         gxTv_SdtSolicitudes_Items_Monedaisosimbolo = "";
         gxTv_SdtSolicitudes_Items_Mode = "";
         gxTv_SdtSolicitudes_Items_Rubrosestado_Z = "";
         gxTv_SdtSolicitudes_Items_Inventarionombre_Z = "";
         gxTv_SdtSolicitudes_Items_Estadostipo_Z = "";
         gxTv_SdtSolicitudes_Items_Solicituditemssr_Z = "";
         gxTv_SdtSolicitudes_Items_Solicituditemscomisiontipo_Z = "";
         gxTv_SdtSolicitudes_Items_Monedaisosimbolo_Z = "";
         gxTv_SdtSolicitudes_Items_Rubrosimagen_gxi_Z = "";
         gxTv_SdtSolicitudes_Items_Inventarioimagen_gxi_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short gxTv_SdtSolicitudes_Items_Solicitudesitemsid ;
      private short sdtIsNull ;
      private short gxTv_SdtSolicitudes_Items_Rubrosid ;
      private short gxTv_SdtSolicitudes_Items_Solicitudesitemscantidad ;
      private short gxTv_SdtSolicitudes_Items_Monedaid ;
      private short gxTv_SdtSolicitudes_Items_Modified ;
      private short gxTv_SdtSolicitudes_Items_Initialized ;
      private short gxTv_SdtSolicitudes_Items_Solicitudesitemsid_Z ;
      private short gxTv_SdtSolicitudes_Items_Rubrosid_Z ;
      private short gxTv_SdtSolicitudes_Items_Solicitudesitemscantidad_Z ;
      private short gxTv_SdtSolicitudes_Items_Monedaid_Z ;
      private short gxTv_SdtSolicitudes_Items_Rubrosestado_N ;
      private short gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal_N ;
      private short gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov_N ;
      private short gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp_N ;
      private short gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm_N ;
      private short gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp_N ;
      private int gxTv_SdtSolicitudes_Items_Estadosgenericosid ;
      private int gxTv_SdtSolicitudes_Items_Estadosgenericosid_Z ;
      private long gxTv_SdtSolicitudes_Items_Medidasid ;
      private long gxTv_SdtSolicitudes_Items_Inventarioid ;
      private long gxTv_SdtSolicitudes_Items_Medidasid_Z ;
      private long gxTv_SdtSolicitudes_Items_Inventarioid_Z ;
      private decimal gxTv_SdtSolicitudes_Items_Inventariopreciofinal ;
      private decimal gxTv_SdtSolicitudes_Items_Inventarioconsumoproductivo ;
      private decimal gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal ;
      private decimal gxTv_SdtSolicitudes_Items_Solicituditemscomision ;
      private decimal gxTv_SdtSolicitudes_Items_Solicitudesitemsprecioinstalacion ;
      private decimal gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov ;
      private decimal gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp ;
      private decimal gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm ;
      private decimal gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp ;
      private decimal gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprof ;
      private decimal gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprofp ;
      private decimal gxTv_SdtSolicitudes_Items_Inventariopreciofinal_Z ;
      private decimal gxTv_SdtSolicitudes_Items_Inventarioconsumoproductivo_Z ;
      private decimal gxTv_SdtSolicitudes_Items_Solicitudesitemspreciofinal_Z ;
      private decimal gxTv_SdtSolicitudes_Items_Solicituditemscomision_Z ;
      private decimal gxTv_SdtSolicitudes_Items_Solicitudesitemsprecioinstalacion_Z ;
      private decimal gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprov_Z ;
      private decimal gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprovp_Z ;
      private decimal gxTv_SdtSolicitudes_Items_Solicitudesitemscomialm_Z ;
      private decimal gxTv_SdtSolicitudes_Items_Solicitudesitemscomialmp_Z ;
      private decimal gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprof_Z ;
      private decimal gxTv_SdtSolicitudes_Items_Solicitudesitemscomiprofp_Z ;
      private string gxTv_SdtSolicitudes_Items_Rubrosestado ;
      private string gxTv_SdtSolicitudes_Items_Inventarionombre ;
      private string gxTv_SdtSolicitudes_Items_Estadostipo ;
      private string gxTv_SdtSolicitudes_Items_Solicituditemssr ;
      private string gxTv_SdtSolicitudes_Items_Solicituditemscomisiontipo ;
      private string gxTv_SdtSolicitudes_Items_Monedaisosimbolo ;
      private string gxTv_SdtSolicitudes_Items_Mode ;
      private string gxTv_SdtSolicitudes_Items_Rubrosestado_Z ;
      private string gxTv_SdtSolicitudes_Items_Inventarionombre_Z ;
      private string gxTv_SdtSolicitudes_Items_Estadostipo_Z ;
      private string gxTv_SdtSolicitudes_Items_Solicituditemssr_Z ;
      private string gxTv_SdtSolicitudes_Items_Solicituditemscomisiontipo_Z ;
      private string gxTv_SdtSolicitudes_Items_Monedaisosimbolo_Z ;
      private bool gxTv_SdtSolicitudes_Items_Solicitudesprecioesfreezado ;
      private bool gxTv_SdtSolicitudes_Items_Solicitudesprecioesfreezado_Z ;
      private string gxTv_SdtSolicitudes_Items_Rubrosimagen_gxi ;
      private string gxTv_SdtSolicitudes_Items_Inventarioimagen_gxi ;
      private string gxTv_SdtSolicitudes_Items_Rubrosimagen_gxi_Z ;
      private string gxTv_SdtSolicitudes_Items_Inventarioimagen_gxi_Z ;
      private string gxTv_SdtSolicitudes_Items_Rubrosimagen ;
      private string gxTv_SdtSolicitudes_Items_Inventarioimagen ;
   }

   [DataContract(Name = @"Solicitudes.Items", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtSolicitudes_Items_RESTInterface : GxGenericCollectionItem<SdtSolicitudes_Items>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtSolicitudes_Items_RESTInterface( ) : base()
      {
      }

      public SdtSolicitudes_Items_RESTInterface( SdtSolicitudes_Items psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SolicitudesItemsID" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Solicitudesitemsid
      {
         get {
            return sdt.gxTpr_Solicitudesitemsid ;
         }

         set {
            sdt.gxTpr_Solicitudesitemsid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "RubrosId" , Order = 1 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Rubrosid
      {
         get {
            return sdt.gxTpr_Rubrosid ;
         }

         set {
            sdt.gxTpr_Rubrosid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "RubrosImagen" , Order = 2 )]
      [GxUpload()]
      public string gxTpr_Rubrosimagen
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Rubrosimagen)) ? PathUtil.RelativeURL( sdt.gxTpr_Rubrosimagen) : StringUtil.RTrim( sdt.gxTpr_Rubrosimagen_gxi)) ;
         }

         set {
            sdt.gxTpr_Rubrosimagen = value;
         }

      }

      [DataMember( Name = "RubrosEstado" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Rubrosestado
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Rubrosestado) ;
         }

         set {
            sdt.gxTpr_Rubrosestado = value;
         }

      }

      [DataMember( Name = "MedidasID" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Medidasid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Medidasid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Medidasid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "InventarioId" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Inventarioid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Inventarioid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Inventarioid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "InventarioNombre" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Inventarionombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Inventarionombre) ;
         }

         set {
            sdt.gxTpr_Inventarionombre = value;
         }

      }

      [DataMember( Name = "InventarioImagen" , Order = 7 )]
      [GxUpload()]
      public string gxTpr_Inventarioimagen
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Inventarioimagen)) ? PathUtil.RelativeURL( sdt.gxTpr_Inventarioimagen) : StringUtil.RTrim( sdt.gxTpr_Inventarioimagen_gxi)) ;
         }

         set {
            sdt.gxTpr_Inventarioimagen = value;
         }

      }

      [DataMember( Name = "InventarioPrecioFinal" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Inventariopreciofinal
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Inventariopreciofinal, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Inventariopreciofinal = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "InventarioConsumoProductivo" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Inventarioconsumoproductivo
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Inventarioconsumoproductivo, 10, 2)) ;
         }

         set {
            sdt.gxTpr_Inventarioconsumoproductivo = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "EstadosTipo" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Estadostipo
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Estadostipo) ;
         }

         set {
            sdt.gxTpr_Estadostipo = value;
         }

      }

      [DataMember( Name = "EstadosGenericosId" , Order = 11 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Estadosgenericosid
      {
         get {
            return sdt.gxTpr_Estadosgenericosid ;
         }

         set {
            sdt.gxTpr_Estadosgenericosid = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SolicitudesItemsPrecioFinal" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Solicitudesitemspreciofinal
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Solicitudesitemspreciofinal, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Solicitudesitemspreciofinal = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "SolicitudesPrecioEsFreezado" , Order = 13 )]
      [GxSeudo()]
      public bool gxTpr_Solicitudesprecioesfreezado
      {
         get {
            return sdt.gxTpr_Solicitudesprecioesfreezado ;
         }

         set {
            sdt.gxTpr_Solicitudesprecioesfreezado = value;
         }

      }

      [DataMember( Name = "SolicitudesItemsCantidad" , Order = 14 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Solicitudesitemscantidad
      {
         get {
            return sdt.gxTpr_Solicitudesitemscantidad ;
         }

         set {
            sdt.gxTpr_Solicitudesitemscantidad = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SolicitudItemsComision" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Solicituditemscomision
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Solicituditemscomision, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Solicituditemscomision = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "SolicitudItemsSR" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Solicituditemssr
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Solicituditemssr) ;
         }

         set {
            sdt.gxTpr_Solicituditemssr = value;
         }

      }

      [DataMember( Name = "SolicitudItemsComisionTipo" , Order = 17 )]
      [GxSeudo()]
      public string gxTpr_Solicituditemscomisiontipo
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Solicituditemscomisiontipo) ;
         }

         set {
            sdt.gxTpr_Solicituditemscomisiontipo = value;
         }

      }

      [DataMember( Name = "SolicitudesItemsPrecioInstalacion" , Order = 18 )]
      [GxSeudo()]
      public string gxTpr_Solicitudesitemsprecioinstalacion
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Solicitudesitemsprecioinstalacion, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Solicitudesitemsprecioinstalacion = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "MonedaId" , Order = 19 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Monedaid
      {
         get {
            return sdt.gxTpr_Monedaid ;
         }

         set {
            sdt.gxTpr_Monedaid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "MonedaISOSimbolo" , Order = 20 )]
      [GxSeudo()]
      public string gxTpr_Monedaisosimbolo
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Monedaisosimbolo) ;
         }

         set {
            sdt.gxTpr_Monedaisosimbolo = value;
         }

      }

      [DataMember( Name = "SolicitudesItemsComiProv" , Order = 21 )]
      [GxSeudo()]
      public string gxTpr_Solicitudesitemscomiprov
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Solicitudesitemscomiprov, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Solicitudesitemscomiprov = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "SolicitudesItemsComiProvP" , Order = 22 )]
      [GxSeudo()]
      public Nullable<decimal> gxTpr_Solicitudesitemscomiprovp
      {
         get {
            return sdt.gxTpr_Solicitudesitemscomiprovp ;
         }

         set {
            sdt.gxTpr_Solicitudesitemscomiprovp = (decimal)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SolicitudesItemsComiALM" , Order = 23 )]
      [GxSeudo()]
      public string gxTpr_Solicitudesitemscomialm
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Solicitudesitemscomialm, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Solicitudesitemscomialm = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "SolicitudesItemsComiALMP" , Order = 24 )]
      [GxSeudo()]
      public Nullable<decimal> gxTpr_Solicitudesitemscomialmp
      {
         get {
            return sdt.gxTpr_Solicitudesitemscomialmp ;
         }

         set {
            sdt.gxTpr_Solicitudesitemscomialmp = (decimal)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SolicitudesItemsComiProf" , Order = 25 )]
      [GxSeudo()]
      public string gxTpr_Solicitudesitemscomiprof
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Solicitudesitemscomiprof, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Solicitudesitemscomiprof = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "SolicitudesItemsComiProfP" , Order = 26 )]
      [GxSeudo()]
      public Nullable<decimal> gxTpr_Solicitudesitemscomiprofp
      {
         get {
            return sdt.gxTpr_Solicitudesitemscomiprofp ;
         }

         set {
            sdt.gxTpr_Solicitudesitemscomiprofp = (decimal)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtSolicitudes_Items sdt
      {
         get {
            return (SdtSolicitudes_Items)Sdt ;
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
            sdt = new SdtSolicitudes_Items() ;
         }
      }

   }

   [DataContract(Name = @"Solicitudes.Items", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtSolicitudes_Items_RESTLInterface : GxGenericCollectionItem<SdtSolicitudes_Items>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtSolicitudes_Items_RESTLInterface( ) : base()
      {
      }

      public SdtSolicitudes_Items_RESTLInterface( SdtSolicitudes_Items psdt ) : base(psdt)
      {
      }

      public SdtSolicitudes_Items sdt
      {
         get {
            return (SdtSolicitudes_Items)Sdt ;
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
            sdt = new SdtSolicitudes_Items() ;
         }
      }

   }

}
