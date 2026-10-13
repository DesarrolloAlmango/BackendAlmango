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
         initialize();
      }

      public apicomercio( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         IsApiObject = true;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         initialize();
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

      public void InitLocation( )
      {
         restLocation = new GxLocation();
         restLocation.Host = "localhost";
         restLocation.Port = 80;
         restLocation.BaseUrl = "AlmangoXV1NETFramework/v1/comercios";
         if ( gxProperties == null )
         {
            gxProperties = new GxObjectProperties();
         }
      }

      public GxObjectProperties ObjProperties
      {
         get {
            return gxProperties ;
         }

         set {
            gxProperties = value ;
         }

      }

      public void SetObjectProperties( GxObjectProperties gxobjppt )
      {
         gxProperties = gxobjppt ;
         restLocation = gxobjppt.Location ;
      }

      public void gxep_recibircompra( GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_NuevaSolicitudExterna aP0_EntradaSDT ,
                                      out bool aP1_Error ,
                                      out string aP2_Msj ,
                                      out long aP3_TrackingId )
      {
         restCliRecibirCompra = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/compras";
         restCliRecibirCompra.Location = restLocation;
         restCliRecibirCompra.HttpMethod = "POST";
         restCliRecibirCompra.AddBodyVar("EntradaSDT", aP0_EntradaSDT);
         restCliRecibirCompra.RestExecute();
         gxProperties.ErrorCode = restCliRecibirCompra.ErrorCode;
         gxProperties.ErrorMessage = restCliRecibirCompra.ErrorMessage;
         gxProperties.StatusCode = restCliRecibirCompra.StatusCode;
         gxProperties.StatusMessage = restCliRecibirCompra.StatusMessage;
         if ( restCliRecibirCompra.ErrorCode != 0 )
         {
            aP1_Error = (bool)(false);
            aP2_Msj = "";
            aP3_TrackingId = 0;
         }
         else
         {
            aP1_Error = (bool)(restCliRecibirCompra.GetBodyBool("Error"));
            aP2_Msj = restCliRecibirCompra.GetBodyString("Msj");
            aP3_TrackingId = (long)(restCliRecibirCompra.GetBodyNum("TrackingId"));
         }
         /* RecibirCompra Constructor */
      }

      public void gxep_obtenertodosservicios( out bool aP0_Error ,
                                              out string aP1_Msj ,
                                              out GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio> aP2_ListaServicios )
      {
         restCliObtenerTodosServicios = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/servicios";
         restCliObtenerTodosServicios.Location = restLocation;
         restCliObtenerTodosServicios.HttpMethod = "GET";
         restCliObtenerTodosServicios.RestExecute();
         gxProperties.ErrorCode = restCliObtenerTodosServicios.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerTodosServicios.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerTodosServicios.StatusCode;
         gxProperties.StatusMessage = restCliObtenerTodosServicios.StatusMessage;
         if ( restCliObtenerTodosServicios.ErrorCode != 0 )
         {
            aP0_Error = (bool)(false);
            aP1_Msj = "";
            aP2_ListaServicios = new GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio>();
         }
         else
         {
            aP0_Error = (bool)(restCliObtenerTodosServicios.GetBodyBool("Error"));
            aP1_Msj = restCliObtenerTodosServicios.GetBodyString("Msj");
            aP2_ListaServicios = restCliObtenerTodosServicios.GetBodySdtCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio>("ListaServicios");
         }
         /* ObtenerTodosServicios Constructor */
      }

      public void gxep_obtenerservicio( string aP0_SKU ,
                                        out bool aP1_Error ,
                                        out string aP2_Msj ,
                                        out GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio aP3_Servicio )
      {
         restCliObtenerServicio = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "servicios/"+GXUtil.UrlEncode(StringUtil.RTrim(aP0_SKU));
         restCliObtenerServicio.Location = restLocation;
         restCliObtenerServicio.HttpMethod = "GET";
         restCliObtenerServicio.RestExecute();
         gxProperties.ErrorCode = restCliObtenerServicio.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerServicio.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerServicio.StatusCode;
         gxProperties.StatusMessage = restCliObtenerServicio.StatusMessage;
         if ( restCliObtenerServicio.ErrorCode != 0 )
         {
            aP1_Error = (bool)(false);
            aP2_Msj = "";
            aP3_Servicio = new GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio();
         }
         else
         {
            aP1_Error = (bool)(restCliObtenerServicio.GetBodyBool("Error"));
            aP2_Msj = restCliObtenerServicio.GetBodyString("Msj");
            aP3_Servicio = restCliObtenerServicio.GetBodySdt<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio>("Servicio");
         }
         /* ObtenerServicio Constructor */
      }

      public void gxep_pobtenerzonas( out bool aP0_Error ,
                                      out string aP1_Msj ,
                                      out GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_ApiZonas_DepartamentosItem> aP2_Departamentos )
      {
         restCliPObtenerZonas = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/zonas";
         restCliPObtenerZonas.Location = restLocation;
         restCliPObtenerZonas.HttpMethod = "GET";
         restCliPObtenerZonas.RestExecute();
         gxProperties.ErrorCode = restCliPObtenerZonas.ErrorCode;
         gxProperties.ErrorMessage = restCliPObtenerZonas.ErrorMessage;
         gxProperties.StatusCode = restCliPObtenerZonas.StatusCode;
         gxProperties.StatusMessage = restCliPObtenerZonas.StatusMessage;
         if ( restCliPObtenerZonas.ErrorCode != 0 )
         {
            aP0_Error = (bool)(false);
            aP1_Msj = "";
            aP2_Departamentos = new GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_ApiZonas_DepartamentosItem>();
         }
         else
         {
            aP0_Error = (bool)(restCliPObtenerZonas.GetBodyBool("Error"));
            aP1_Msj = restCliPObtenerZonas.GetBodyString("Msj");
            aP2_Departamentos = restCliPObtenerZonas.GetBodySdtCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_ApiZonas_DepartamentosItem>("Departamentos");
         }
         /* PObtenerZonas Constructor */
      }

      public void gxep_pobtenerpresupuesto( long aP0_SolicitudId ,
                                            string aP1_Email ,
                                            out bool aP2_Error ,
                                            out string aP3_Msj ,
                                            out GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_PresupuestoRespuesta aP4_Presupuesto )
      {
         restCliPObtenerPresupuesto = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/presupuesto";
         restCliPObtenerPresupuesto.Location = restLocation;
         restCliPObtenerPresupuesto.HttpMethod = "GET";
         restCliPObtenerPresupuesto.AddQueryVar("Solicitudid", (long)(aP0_SolicitudId));
         restCliPObtenerPresupuesto.AddQueryVar("Email", (string)(aP1_Email));
         restCliPObtenerPresupuesto.RestExecute();
         gxProperties.ErrorCode = restCliPObtenerPresupuesto.ErrorCode;
         gxProperties.ErrorMessage = restCliPObtenerPresupuesto.ErrorMessage;
         gxProperties.StatusCode = restCliPObtenerPresupuesto.StatusCode;
         gxProperties.StatusMessage = restCliPObtenerPresupuesto.StatusMessage;
         if ( restCliPObtenerPresupuesto.ErrorCode != 0 )
         {
            aP2_Error = (bool)(false);
            aP3_Msj = "";
            aP4_Presupuesto = new GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_PresupuestoRespuesta();
         }
         else
         {
            aP2_Error = (bool)(restCliPObtenerPresupuesto.GetBodyBool("Error"));
            aP3_Msj = restCliPObtenerPresupuesto.GetBodyString("Msj");
            aP4_Presupuesto = restCliPObtenerPresupuesto.GetBodySdt<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_PresupuestoRespuesta>("Presupuesto");
         }
         /* PObtenerPresupuesto Constructor */
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         restCliRecibirCompra = new GXRestAPIClient();
         aP1_Error = new bool();
         aP2_Msj = "";
         aP3_TrackingId = new long();
         restCliObtenerTodosServicios = new GXRestAPIClient();
         aP0_Error = new bool();
         aP1_Msj = "";
         aP2_ListaServicios = new GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio>();
         restCliObtenerServicio = new GXRestAPIClient();
         aP3_Servicio = new GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio();
         restCliPObtenerZonas = new GXRestAPIClient();
         aP2_Departamentos = new GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_ApiZonas_DepartamentosItem>();
         restCliPObtenerPresupuesto = new GXRestAPIClient();
         aP2_Error = new bool();
         aP3_Msj = "";
         aP4_Presupuesto = new GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_PresupuestoRespuesta();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.comerciosapi.v1.apicomercio__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      protected string Gx_restmethod ;
      protected GXRestAPIClient restCliRecibirCompra ;
      protected GXRestAPIClient restCliObtenerTodosServicios ;
      protected GXRestAPIClient restCliObtenerServicio ;
      protected GXRestAPIClient restCliPObtenerZonas ;
      protected GXRestAPIClient restCliPObtenerPresupuesto ;
      protected GxLocation restLocation ;
      protected GxObjectProperties gxProperties ;
      protected IGxDataStore dsDataStore1 ;
      protected IGxDataStore dsDefault ;
      protected bool aP1_Error ;
      protected string aP2_Msj ;
      protected long aP3_TrackingId ;
      protected bool aP0_Error ;
      protected string aP1_Msj ;
      protected GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio> aP2_ListaServicios ;
      protected GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio aP3_Servicio ;
      protected GXBaseCollection<GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_ApiZonas_DepartamentosItem> aP2_Departamentos ;
      protected bool aP2_Error ;
      protected string aP3_Msj ;
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

}
