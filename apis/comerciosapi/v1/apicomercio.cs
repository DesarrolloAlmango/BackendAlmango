using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
namespace GeneXus.Programs.apis.comerciosapi.v1 {
   public class apicomercio : GXProcedure
   {
      public apicomercio( )
      {
         context = new GxContext(  );
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         IsApiObject = true;
      }

      public apicomercio( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         IsApiObject = true;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         if ( context.HttpContext != null )
         {
            Gx_restmethod = (string)(context.HttpContext.Request.HttpMethod);
         }
      }

      public void execute( )
      {
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         cleanup();
      }

      public void gxep_recibircompra( GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_NuevaSolicitudExterna aP0_EntradaSDT ,
                                      out bool aP1_Error ,
                                      out string aP2_Msj ,
                                      out long aP3_TrackingId )
      {
         this.AV5EntradaSDT = aP0_EntradaSDT;
         initialize();
         /* RecibirCompra Constructor */
         new GeneXus.Programs.apis.comerciosapi.v1.pguardarsolicitudexterna(context ).execute(  AV5EntradaSDT, out  AV6Error, out  AV7Msj, out  AV12TrackingId, out  Gx_restcode) ;
         aP1_Error=this.AV6Error;
         aP2_Msj=this.AV7Msj;
         aP3_TrackingId=this.AV12TrackingId;
      }

      public void gxep_obtenertodosservicios( out bool aP0_Error ,
                                              out string aP1_Msj ,
                                              out GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio> aP2_ListaServicios )
      {
         initialize();
         /* ObtenerTodosServicios Constructor */
         new GeneXus.Programs.apis.comerciosapi.v1.obtenertodosservicios(context ).execute( out  AV6Error, out  AV7Msj, out  AV11ListaServicios, out  Gx_restcode) ;
         aP0_Error=this.AV6Error;
         aP1_Msj=this.AV7Msj;
         aP2_ListaServicios=this.AV11ListaServicios;
      }

      public void gxep_obtenerservicio( string aP0_SKU ,
                                        out bool aP1_Error ,
                                        out string aP2_Msj ,
                                        out GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio aP3_Servicio )
      {
         this.AV9SKU = aP0_SKU;
         initialize();
         /* ObtenerServicio Constructor */
         new GeneXus.Programs.apis.comerciosapi.v1.obtenerservicio(context ).execute(  AV9SKU, out  AV6Error, out  AV7Msj, out  AV10Servicio, out  Gx_restcode) ;
         aP1_Error=this.AV6Error;
         aP2_Msj=this.AV7Msj;
         aP3_Servicio=this.AV10Servicio;
      }

      public void gxep_pobtenerzonas( out bool aP0_Error ,
                                      out string aP1_Msj ,
                                      out GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_ApiZonas_DepartamentosItem> aP2_Departamentos )
      {
         initialize();
         /* PObtenerZonas Constructor */
         new GeneXus.Programs.apis.comerciosapi.v1.pobtenerzonas(context ).execute( out  AV6Error, out  AV7Msj, out  AV13Departamentos, out  Gx_restcode) ;
         aP0_Error=this.AV6Error;
         aP1_Msj=this.AV7Msj;
         aP2_Departamentos=this.AV13Departamentos;
      }

      public void gxep_pobtenerpresupuesto( long aP0_SolicitudId ,
                                            string aP1_Email ,
                                            out bool aP2_Error ,
                                            out string aP3_Msj ,
                                            out GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_PresupuestoRespuesta aP4_Presupuesto )
      {
         this.AV14SolicitudId = aP0_SolicitudId;
         this.AV15Email = aP1_Email;
         initialize();
         /* PObtenerPresupuesto Constructor */
         new GeneXus.Programs.apis.comerciosapi.v1.pobtenerpresupuesto(context ).execute(  AV14SolicitudId,  AV15Email, out  AV6Error, out  AV7Msj, out  AV16Presupuesto, out  Gx_restcode) ;
         aP2_Error=this.AV6Error;
         aP3_Msj=this.AV7Msj;
         aP4_Presupuesto=this.AV16Presupuesto;
      }

      public short getrestcode( )
      {
         return Gx_restcode ;
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         AV7Msj = "";
         AV11ListaServicios = new GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio>( context, "SDT_Servicio", "AlmangoX");
         AV10Servicio = new GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio(context);
         AV13Departamentos = new GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_ApiZonas_DepartamentosItem>( context, "SDT_ApiZonas.DepartamentosItem", "AlmangoX");
         AV16Presupuesto = new GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_PresupuestoRespuesta(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.comerciosapi.v1.apicomercio__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      protected short Gx_restcode ;
      protected long AV12TrackingId ;
      protected long AV14SolicitudId ;
      protected string Gx_restmethod ;
      protected bool AV6Error ;
      protected string AV7Msj ;
      protected string AV9SKU ;
      protected string AV15Email ;
      protected IGxDataStore dsDataStore1 ;
      protected IGxDataStore dsDefault ;
      protected GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_NuevaSolicitudExterna AV5EntradaSDT ;
      protected bool aP1_Error ;
      protected string aP2_Msj ;
      protected long aP3_TrackingId ;
      protected bool aP0_Error ;
      protected string aP1_Msj ;
      protected GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio> AV11ListaServicios ;
      protected GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio> aP2_ListaServicios ;
      protected GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio AV10Servicio ;
      protected GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio aP3_Servicio ;
      protected GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_ApiZonas_DepartamentosItem> AV13Departamentos ;
      protected GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_ApiZonas_DepartamentosItem> aP2_Departamentos ;
      protected bool aP2_Error ;
      protected string aP3_Msj ;
      protected GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_PresupuestoRespuesta AV16Presupuesto ;
      protected GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_PresupuestoRespuesta aP4_Presupuesto ;
      protected IDataStoreProvider pr_default ;
   }

   public class apicomercio__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.apis.comerciosapi.v1.apicomercio_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class apicomercio_services : GxRestService
 {
    [OperationContract]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/v1/comercios/compras")]
    public bool gxep_recibircompra( GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_NuevaSolicitudExterna_RESTInterface EntradaSDT ,
                                    out string sMsj ,
                                    out string sTrackingId )
    {
       sMsj = "" ;
       sTrackingId = "" ;
       bool sError = false;
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return false ;
          }
          if ( ! ProcessHeaders("apis.comerciosapi.v1.apicomercio") )
          {
             return false ;
          }
          apicomercio worker = new apicomercio(context);
          worker.IsMain = RunAsMain ;
          GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_NuevaSolicitudExterna gxrEntradaSDT = EntradaSDT.sdt;
          long gxrTrackingId = 0;
          gxrTrackingId = (long)(Math.Round(NumberUtil.Val( (string)(sTrackingId), "."), 18, MidpointRounding.ToEven));
          worker.gxep_recibircompra(gxrEntradaSDT,out sError,out sMsj,out gxrTrackingId );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          sTrackingId = StringUtil.LTrim( StringUtil.Str( (decimal)(gxrTrackingId), 18, 0)) ;
          return sError ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return false ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public bool gxep_obtenertodosservicios( out string sMsj ,
                                            out GxGenericCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio_RESTInterface> ListaServicios )
    {
       sMsj = "" ;
       ListaServicios = new GxGenericCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio_RESTInterface>() ;
       bool sError = false;
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return false ;
          }
          if ( ! ProcessHeaders("apis.comerciosapi.v1.apicomercio") )
          {
             return false ;
          }
          apicomercio worker = new apicomercio(context);
          worker.IsMain = RunAsMain ;
          GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio> gxrListaServicios = new GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio>();
          worker.gxep_obtenertodosservicios(out sError,out sMsj,out gxrListaServicios );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          GxGenericCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio_RESTInterface> AV11ListaServicios = new GxGenericCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio_RESTInterface>(gxrListaServicios) ;
          return sError ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return false ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public bool gxep_obtenerservicio( string SKU ,
                                      out string sMsj ,
                                      out GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio_RESTInterface Servicio )
    {
       sMsj = "" ;
       Servicio = new GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio_RESTInterface() ;
       bool sError = false;
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return false ;
          }
          if ( ! ProcessHeaders("apis.comerciosapi.v1.apicomercio") )
          {
             return false ;
          }
          apicomercio worker = new apicomercio(context);
          worker.IsMain = RunAsMain ;
          GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio gxrServicio = Servicio.sdt;
          worker.gxep_obtenerservicio(SKU,out sError,out sMsj,out gxrServicio );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio_RESTInterface AV10Servicio = new GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio_RESTInterface(gxrServicio) ;
          return sError ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return false ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public bool gxep_pobtenerzonas( out string sMsj ,
                                    out GxGenericCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_ApiZonas_DepartamentosItem_RESTInterface> Departamentos )
    {
       sMsj = "" ;
       Departamentos = new GxGenericCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_ApiZonas_DepartamentosItem_RESTInterface>() ;
       bool sError = false;
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return false ;
          }
          if ( ! ProcessHeaders("apis.comerciosapi.v1.apicomercio") )
          {
             return false ;
          }
          apicomercio worker = new apicomercio(context);
          worker.IsMain = RunAsMain ;
          GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_ApiZonas_DepartamentosItem> gxrDepartamentos = new GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_ApiZonas_DepartamentosItem>();
          worker.gxep_pobtenerzonas(out sError,out sMsj,out gxrDepartamentos );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          GxGenericCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_ApiZonas_DepartamentosItem_RESTInterface> AV13Departamentos = new GxGenericCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_ApiZonas_DepartamentosItem_RESTInterface>(gxrDepartamentos) ;
          return sError ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return false ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public bool gxep_pobtenerpresupuesto( string SolicitudId ,
                                          string Email ,
                                          out string sMsj ,
                                          out GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_PresupuestoRespuesta_RESTInterface Presupuesto )
    {
       sMsj = "" ;
       Presupuesto = new GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_PresupuestoRespuesta_RESTInterface() ;
       bool sError = false;
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return false ;
          }
          if ( ! ProcessHeaders("apis.comerciosapi.v1.apicomercio") )
          {
             return false ;
          }
          apicomercio worker = new apicomercio(context);
          worker.IsMain = RunAsMain ;
          long gxrSolicitudId = 0;
          gxrSolicitudId = (long)(Math.Round(NumberUtil.Val( (string)(SolicitudId), "."), 18, MidpointRounding.ToEven));
          GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_PresupuestoRespuesta gxrPresupuesto = Presupuesto.sdt;
          worker.gxep_pobtenerpresupuesto(gxrSolicitudId,Email,out sError,out sMsj,out gxrPresupuesto );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_PresupuestoRespuesta_RESTInterface AV16Presupuesto = new GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_PresupuestoRespuesta_RESTInterface(gxrPresupuesto) ;
          return sError ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return false ;
    }

 }

}
