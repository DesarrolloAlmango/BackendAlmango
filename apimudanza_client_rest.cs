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
namespace GeneXus.Programs {
   public class apimudanza : GXProcedure
   {
      public apimudanza( )
      {
         context = new GxContext(  );
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         IsApiObject = true;
         initialize();
      }

      public apimudanza( IGxContext context )
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
         restLocation.BaseUrl = "AlmangoXV1NETFramework/APIMudanza";
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

      public void gxep_obtenerdirecciones( string aP0_SearchTxt ,
                                           string aP1_Coordenadas ,
                                           out string aP2_Result )
      {
         restCliObtenerDirecciones = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerDirecciones";
         restCliObtenerDirecciones.Location = restLocation;
         restCliObtenerDirecciones.HttpMethod = "GET";
         restCliObtenerDirecciones.AddQueryVar("Searchtxt", (string)(aP0_SearchTxt));
         restCliObtenerDirecciones.AddQueryVar("Coordenadas", (string)(aP1_Coordenadas));
         restCliObtenerDirecciones.RestExecute();
         gxProperties.ErrorCode = restCliObtenerDirecciones.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerDirecciones.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerDirecciones.StatusCode;
         gxProperties.StatusMessage = restCliObtenerDirecciones.StatusMessage;
         if ( restCliObtenerDirecciones.ErrorCode != 0 )
         {
            aP2_Result = "";
         }
         else
         {
            aP2_Result = restCliObtenerDirecciones.GetBodyString("Result");
         }
         /* ObtenerDirecciones Constructor */
      }

      public void gxep_obtenercoordenadas( string aP0_MapBox_id ,
                                           out string aP1_Result )
      {
         restCliObtenerCoordenadas = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerCoordenadas";
         restCliObtenerCoordenadas.Location = restLocation;
         restCliObtenerCoordenadas.HttpMethod = "GET";
         restCliObtenerCoordenadas.AddQueryVar("Mapbox_id", (string)(aP0_MapBox_id));
         restCliObtenerCoordenadas.RestExecute();
         gxProperties.ErrorCode = restCliObtenerCoordenadas.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerCoordenadas.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerCoordenadas.StatusCode;
         gxProperties.StatusMessage = restCliObtenerCoordenadas.StatusMessage;
         if ( restCliObtenerCoordenadas.ErrorCode != 0 )
         {
            aP1_Result = "";
         }
         else
         {
            aP1_Result = restCliObtenerCoordenadas.GetBodyString("Result");
         }
         /* ObtenerCoordenadas Constructor */
      }

      public void gxep_obtenerurlmapa( string aP0_OrigenCoordenadas ,
                                       string aP1_DestinoCoordenadas ,
                                       out string aP2_URL )
      {
         restCliObtenerURLMapa = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerURLMapa";
         restCliObtenerURLMapa.Location = restLocation;
         restCliObtenerURLMapa.HttpMethod = "GET";
         restCliObtenerURLMapa.AddQueryVar("Origencoordenadas", (string)(aP0_OrigenCoordenadas));
         restCliObtenerURLMapa.AddQueryVar("Destinocoordenadas", (string)(aP1_DestinoCoordenadas));
         restCliObtenerURLMapa.RestExecute();
         gxProperties.ErrorCode = restCliObtenerURLMapa.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerURLMapa.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerURLMapa.StatusCode;
         gxProperties.StatusMessage = restCliObtenerURLMapa.StatusMessage;
         if ( restCliObtenerURLMapa.ErrorCode != 0 )
         {
            aP2_URL = "";
         }
         else
         {
            aP2_URL = restCliObtenerURLMapa.GetBodyString("URL");
         }
         /* ObtenerURLMapa Constructor */
      }

      public void gxep_requestgoogleplace( string aP0_TextSearch ,
                                           out string aP1_Result )
      {
         restCliRequestGooglePlace = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "RequestGooglePlace";
         restCliRequestGooglePlace.Location = restLocation;
         restCliRequestGooglePlace.HttpMethod = "GET";
         restCliRequestGooglePlace.AddQueryVar("Textsearch", (string)(aP0_TextSearch));
         restCliRequestGooglePlace.RestExecute();
         gxProperties.ErrorCode = restCliRequestGooglePlace.ErrorCode;
         gxProperties.ErrorMessage = restCliRequestGooglePlace.ErrorMessage;
         gxProperties.StatusCode = restCliRequestGooglePlace.StatusCode;
         gxProperties.StatusMessage = restCliRequestGooglePlace.StatusMessage;
         if ( restCliRequestGooglePlace.ErrorCode != 0 )
         {
            aP1_Result = "";
         }
         else
         {
            aP1_Result = restCliRequestGooglePlace.GetBodyString("Result");
         }
         /* RequestGooglePlace Constructor */
      }

      public void gxep_obteneridbycoordenadas( string aP0_Latitud ,
                                               string aP1_Longitud ,
                                               out string aP2_Result )
      {
         restCliObtenerIdByCoordenadas = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerIdByCoordenadas";
         restCliObtenerIdByCoordenadas.Location = restLocation;
         restCliObtenerIdByCoordenadas.HttpMethod = "GET";
         restCliObtenerIdByCoordenadas.AddQueryVar("Latitud", (string)(aP0_Latitud));
         restCliObtenerIdByCoordenadas.AddQueryVar("Longitud", (string)(aP1_Longitud));
         restCliObtenerIdByCoordenadas.RestExecute();
         gxProperties.ErrorCode = restCliObtenerIdByCoordenadas.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerIdByCoordenadas.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerIdByCoordenadas.StatusCode;
         gxProperties.StatusMessage = restCliObtenerIdByCoordenadas.StatusMessage;
         if ( restCliObtenerIdByCoordenadas.ErrorCode != 0 )
         {
            aP2_Result = "";
         }
         else
         {
            aP2_Result = restCliObtenerIdByCoordenadas.GetBodyString("Result");
         }
         /* ObtenerIdByCoordenadas Constructor */
      }

      public void gxep_obtenerparametrosmudanza( out GXBaseCollection<SdtSDTCarga_SDTCargaItem> aP0_SDTCarga )
      {
         restCliObtenerParametrosMudanza = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerParametrosMudanza";
         restCliObtenerParametrosMudanza.Location = restLocation;
         restCliObtenerParametrosMudanza.HttpMethod = "GET";
         restCliObtenerParametrosMudanza.RestExecute();
         gxProperties.ErrorCode = restCliObtenerParametrosMudanza.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerParametrosMudanza.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerParametrosMudanza.StatusCode;
         gxProperties.StatusMessage = restCliObtenerParametrosMudanza.StatusMessage;
         if ( restCliObtenerParametrosMudanza.ErrorCode != 0 )
         {
            aP0_SDTCarga = new GXBaseCollection<SdtSDTCarga_SDTCargaItem>();
         }
         else
         {
            aP0_SDTCarga = restCliObtenerParametrosMudanza.GetBodySdtCollection<SdtSDTCarga_SDTCargaItem>("SDTCarga");
         }
         /* ObtenerParametrosMudanza Constructor */
      }

      public void gxep_altamudanzaweb( string aP0_SDTMudanzaJson ,
                                       string aP1_SDTCargaJson ,
                                       out long aP2_MudanzaId ,
                                       out long aP3_SolicitudId ,
                                       out string aP4_Mensaje )
      {
         restCliAltaMudanzaWeb = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "AltaMudanzaWeb";
         restCliAltaMudanzaWeb.Location = restLocation;
         restCliAltaMudanzaWeb.HttpMethod = "GET";
         restCliAltaMudanzaWeb.AddQueryVar("Sdtmudanzajson", (string)(aP0_SDTMudanzaJson));
         restCliAltaMudanzaWeb.AddQueryVar("Sdtcargajson", (string)(aP1_SDTCargaJson));
         restCliAltaMudanzaWeb.RestExecute();
         gxProperties.ErrorCode = restCliAltaMudanzaWeb.ErrorCode;
         gxProperties.ErrorMessage = restCliAltaMudanzaWeb.ErrorMessage;
         gxProperties.StatusCode = restCliAltaMudanzaWeb.StatusCode;
         gxProperties.StatusMessage = restCliAltaMudanzaWeb.StatusMessage;
         if ( restCliAltaMudanzaWeb.ErrorCode != 0 )
         {
            aP2_MudanzaId = 0;
            aP3_SolicitudId = 0;
            aP4_Mensaje = "";
         }
         else
         {
            aP2_MudanzaId = (long)(restCliAltaMudanzaWeb.GetBodyNum("MudanzaId"));
            aP3_SolicitudId = (long)(restCliAltaMudanzaWeb.GetBodyNum("SolicitudId"));
            aP4_Mensaje = restCliAltaMudanzaWeb.GetBodyString("Mensaje");
         }
         /* AltaMudanzaWeb Constructor */
      }

      public void gxep_updatemudanzaweb( long aP0_MudanzaId ,
                                         string aP1_SDTMudanzaJson ,
                                         string aP2_SDTCargaJson ,
                                         out string aP3_Mensaje )
      {
         restCliUpdateMudanzaWeb = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "UpdateMudanzaWeb";
         restCliUpdateMudanzaWeb.Location = restLocation;
         restCliUpdateMudanzaWeb.HttpMethod = "GET";
         restCliUpdateMudanzaWeb.AddQueryVar("Mudanzaid", (long)(aP0_MudanzaId));
         restCliUpdateMudanzaWeb.AddQueryVar("Sdtmudanzajson", (string)(aP1_SDTMudanzaJson));
         restCliUpdateMudanzaWeb.AddQueryVar("Sdtcargajson", (string)(aP2_SDTCargaJson));
         restCliUpdateMudanzaWeb.RestExecute();
         gxProperties.ErrorCode = restCliUpdateMudanzaWeb.ErrorCode;
         gxProperties.ErrorMessage = restCliUpdateMudanzaWeb.ErrorMessage;
         gxProperties.StatusCode = restCliUpdateMudanzaWeb.StatusCode;
         gxProperties.StatusMessage = restCliUpdateMudanzaWeb.StatusMessage;
         if ( restCliUpdateMudanzaWeb.ErrorCode != 0 )
         {
            aP3_Mensaje = "";
         }
         else
         {
            aP3_Mensaje = restCliUpdateMudanzaWeb.GetBodyString("Mensaje");
         }
         /* UpdateMudanzaWeb Constructor */
      }

      public void gxep_obtenerurlmp( long aP0_MudanzaId ,
                                     out string aP1_URL )
      {
         restCliObtenerURLMP = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerURLMP";
         restCliObtenerURLMP.Location = restLocation;
         restCliObtenerURLMP.HttpMethod = "GET";
         restCliObtenerURLMP.AddQueryVar("Mudanzaid", (long)(aP0_MudanzaId));
         restCliObtenerURLMP.RestExecute();
         gxProperties.ErrorCode = restCliObtenerURLMP.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerURLMP.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerURLMP.StatusCode;
         gxProperties.StatusMessage = restCliObtenerURLMP.StatusMessage;
         if ( restCliObtenerURLMP.ErrorCode != 0 )
         {
            aP1_URL = "";
         }
         else
         {
            aP1_URL = restCliObtenerURLMP.GetBodyString("URL");
         }
         /* ObtenerURLMP Constructor */
      }

      public void gxep_consultarpago( long aP0_MudanzaId ,
                                      out long aP1_SolicitudesId ,
                                      out string aP2_Pagado )
      {
         restCliConsultarPago = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ConsultarPago";
         restCliConsultarPago.Location = restLocation;
         restCliConsultarPago.HttpMethod = "GET";
         restCliConsultarPago.AddQueryVar("Mudanzaid", (long)(aP0_MudanzaId));
         restCliConsultarPago.RestExecute();
         gxProperties.ErrorCode = restCliConsultarPago.ErrorCode;
         gxProperties.ErrorMessage = restCliConsultarPago.ErrorMessage;
         gxProperties.StatusCode = restCliConsultarPago.StatusCode;
         gxProperties.StatusMessage = restCliConsultarPago.StatusMessage;
         if ( restCliConsultarPago.ErrorCode != 0 )
         {
            aP1_SolicitudesId = 0;
            aP2_Pagado = "";
         }
         else
         {
            aP1_SolicitudesId = (long)(restCliConsultarPago.GetBodyNum("SolicitudesId"));
            aP2_Pagado = restCliConsultarPago.GetBodyString("Pagado");
         }
         /* ConsultarPago Constructor */
      }

      public void gxep_obtenerdatostoupdate( long aP0_SolicitudesId ,
                                             out SdtSDTMudanza aP1_SolicitudesJson )
      {
         restCliObtenerDatosToUpdate = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerDatosToUpdate";
         restCliObtenerDatosToUpdate.Location = restLocation;
         restCliObtenerDatosToUpdate.HttpMethod = "GET";
         restCliObtenerDatosToUpdate.AddQueryVar("Solicitudesid", (long)(aP0_SolicitudesId));
         restCliObtenerDatosToUpdate.RestExecute();
         gxProperties.ErrorCode = restCliObtenerDatosToUpdate.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerDatosToUpdate.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerDatosToUpdate.StatusCode;
         gxProperties.StatusMessage = restCliObtenerDatosToUpdate.StatusMessage;
         if ( restCliObtenerDatosToUpdate.ErrorCode != 0 )
         {
            aP1_SolicitudesJson = new SdtSDTMudanza();
         }
         else
         {
            aP1_SolicitudesJson = restCliObtenerDatosToUpdate.GetBodySdt<SdtSDTMudanza>("SolicitudesJson");
         }
         /* ObtenerDatosToUpdate Constructor */
      }

      public void gxep_obtenerpermisosolicitud( long aP0_SolicitudesId ,
                                                out bool aP1_Permiso )
      {
         restCliObtenerPermisoSolicitud = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerPermisoSolicitud";
         restCliObtenerPermisoSolicitud.Location = restLocation;
         restCliObtenerPermisoSolicitud.HttpMethod = "GET";
         restCliObtenerPermisoSolicitud.AddQueryVar("Solicitudesid", (long)(aP0_SolicitudesId));
         restCliObtenerPermisoSolicitud.RestExecute();
         gxProperties.ErrorCode = restCliObtenerPermisoSolicitud.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerPermisoSolicitud.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerPermisoSolicitud.StatusCode;
         gxProperties.StatusMessage = restCliObtenerPermisoSolicitud.StatusMessage;
         if ( restCliObtenerPermisoSolicitud.ErrorCode != 0 )
         {
            aP1_Permiso = (bool)(false);
         }
         else
         {
            aP1_Permiso = (bool)(restCliObtenerPermisoSolicitud.GetBodyBool("Permiso"));
         }
         /* ObtenerPermisoSolicitud Constructor */
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         restCliObtenerDirecciones = new GXRestAPIClient();
         aP2_Result = "";
         restCliObtenerCoordenadas = new GXRestAPIClient();
         aP1_Result = "";
         restCliObtenerURLMapa = new GXRestAPIClient();
         aP2_URL = "";
         restCliRequestGooglePlace = new GXRestAPIClient();
         restCliObtenerIdByCoordenadas = new GXRestAPIClient();
         restCliObtenerParametrosMudanza = new GXRestAPIClient();
         aP0_SDTCarga = new GXBaseCollection<SdtSDTCarga_SDTCargaItem>();
         restCliAltaMudanzaWeb = new GXRestAPIClient();
         aP2_MudanzaId = new long();
         aP3_SolicitudId = new long();
         aP4_Mensaje = "";
         restCliUpdateMudanzaWeb = new GXRestAPIClient();
         aP3_Mensaje = "";
         restCliObtenerURLMP = new GXRestAPIClient();
         aP1_URL = "";
         restCliConsultarPago = new GXRestAPIClient();
         aP1_SolicitudesId = new long();
         aP2_Pagado = "";
         restCliObtenerDatosToUpdate = new GXRestAPIClient();
         aP1_SolicitudesJson = new SdtSDTMudanza();
         restCliObtenerPermisoSolicitud = new GXRestAPIClient();
         aP1_Permiso = new bool();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apimudanza__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      protected string Gx_restmethod ;
      protected GXRestAPIClient restCliObtenerDirecciones ;
      protected GXRestAPIClient restCliObtenerCoordenadas ;
      protected GXRestAPIClient restCliObtenerURLMapa ;
      protected GXRestAPIClient restCliRequestGooglePlace ;
      protected GXRestAPIClient restCliObtenerIdByCoordenadas ;
      protected GXRestAPIClient restCliObtenerParametrosMudanza ;
      protected GXRestAPIClient restCliAltaMudanzaWeb ;
      protected GXRestAPIClient restCliUpdateMudanzaWeb ;
      protected GXRestAPIClient restCliObtenerURLMP ;
      protected GXRestAPIClient restCliConsultarPago ;
      protected GXRestAPIClient restCliObtenerDatosToUpdate ;
      protected GXRestAPIClient restCliObtenerPermisoSolicitud ;
      protected GxLocation restLocation ;
      protected GxObjectProperties gxProperties ;
      protected IGxDataStore dsDataStore1 ;
      protected IGxDataStore dsDefault ;
      protected string aP2_Result ;
      protected string aP1_Result ;
      protected string aP2_URL ;
      protected GXBaseCollection<SdtSDTCarga_SDTCargaItem> aP0_SDTCarga ;
      protected long aP2_MudanzaId ;
      protected long aP3_SolicitudId ;
      protected string aP4_Mensaje ;
      protected string aP3_Mensaje ;
      protected string aP1_URL ;
      protected long aP1_SolicitudesId ;
      protected string aP2_Pagado ;
      protected SdtSDTMudanza aP1_SolicitudesJson ;
      protected bool aP1_Permiso ;
      protected IDataStoreProvider pr_default ;
   }

   public class apimudanza__default : DataStoreHelperBase, IDataStoreHelper
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
