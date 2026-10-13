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
      }

      public apimudanza( IGxContext context )
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

      public void gxep_obtenerdirecciones( string aP0_SearchTxt ,
                                           string aP1_Coordenadas ,
                                           out string aP2_Result )
      {
         this.AV5SearchTxt = aP0_SearchTxt;
         this.AV6Coordenadas = aP1_Coordenadas;
         initialize();
         /* ObtenerDirecciones Constructor */
         new obtenerdirecciones(context ).execute(  AV5SearchTxt,  AV6Coordenadas, out  AV7Result) ;
         aP2_Result=this.AV7Result;
      }

      public void gxep_obtenercoordenadas( string aP0_MapBox_id ,
                                           out string aP1_Result )
      {
         this.AV8MapBox_id = aP0_MapBox_id;
         initialize();
         /* ObtenerCoordenadas Constructor */
         new obtenercoordenadas(context ).execute(  AV8MapBox_id, out  AV7Result) ;
         aP1_Result=this.AV7Result;
      }

      public void gxep_obtenerurlmapa( string aP0_OrigenCoordenadas ,
                                       string aP1_DestinoCoordenadas ,
                                       out string aP2_URL )
      {
         this.AV11OrigenCoordenadas = aP0_OrigenCoordenadas;
         this.AV10DestinoCoordenadas = aP1_DestinoCoordenadas;
         initialize();
         /* ObtenerURLMapa Constructor */
         new obtenerurlmapa(context ).execute(  AV11OrigenCoordenadas,  AV10DestinoCoordenadas, out  AV9URL) ;
         aP2_URL=this.AV9URL;
      }

      public void gxep_requestgoogleplace( string aP0_TextSearch ,
                                           out string aP1_Result )
      {
         this.AV13TextSearch = aP0_TextSearch;
         initialize();
         /* RequestGooglePlace Constructor */
         new requestgoogleplace(context ).execute(  AV13TextSearch, out  AV7Result) ;
         aP1_Result=this.AV7Result;
      }

      public void gxep_obteneridbycoordenadas( string aP0_Latitud ,
                                               string aP1_Longitud ,
                                               out string aP2_Result )
      {
         this.AV15Latitud = aP0_Latitud;
         this.AV14Longitud = aP1_Longitud;
         initialize();
         /* ObtenerIdByCoordenadas Constructor */
         new obteneridbycoordenadas(context ).execute(  AV15Latitud,  AV14Longitud, out  AV7Result) ;
         aP2_Result=this.AV7Result;
      }

      public void gxep_obtenerparametrosmudanza( out GXBaseCollection<SdtSDTCarga_SDTCargaItem> aP0_SDTCarga )
      {
         initialize();
         /* ObtenerParametrosMudanza Constructor */
         new obtenerparametrosmudanza(context ).execute( out  AV16SDTCarga) ;
         aP0_SDTCarga=this.AV16SDTCarga;
      }

      public void gxep_altamudanzaweb( string aP0_SDTMudanzaJson ,
                                       string aP1_SDTCargaJson ,
                                       out long aP2_MudanzaId ,
                                       out long aP3_SolicitudId ,
                                       out string aP4_Mensaje )
      {
         this.AV18SDTMudanzaJson = aP0_SDTMudanzaJson;
         this.AV19SDTCargaJson = aP1_SDTCargaJson;
         initialize();
         /* AltaMudanzaWeb Constructor */
         new altamudanzaweb(context ).execute(  AV18SDTMudanzaJson,  AV19SDTCargaJson, out  AV20MudanzaId, out  AV21SolicitudId, out  AV17Mensaje) ;
         aP2_MudanzaId=this.AV20MudanzaId;
         aP3_SolicitudId=this.AV21SolicitudId;
         aP4_Mensaje=this.AV17Mensaje;
      }

      public void gxep_updatemudanzaweb( long aP0_MudanzaId ,
                                         string aP1_SDTMudanzaJson ,
                                         string aP2_SDTCargaJson ,
                                         out string aP3_Mensaje )
      {
         this.AV20MudanzaId = aP0_MudanzaId;
         this.AV18SDTMudanzaJson = aP1_SDTMudanzaJson;
         this.AV19SDTCargaJson = aP2_SDTCargaJson;
         initialize();
         /* UpdateMudanzaWeb Constructor */
         new updatemudanzaweb(context ).execute(  AV20MudanzaId,  AV18SDTMudanzaJson,  AV19SDTCargaJson, out  AV17Mensaje) ;
         aP3_Mensaje=this.AV17Mensaje;
      }

      public void gxep_obtenerurlmp( long aP0_MudanzaId ,
                                     out string aP1_URL )
      {
         this.AV20MudanzaId = aP0_MudanzaId;
         initialize();
         /* ObtenerURLMP Constructor */
         new obtenerurlpagomudanza(context ).execute(  AV20MudanzaId, out  AV9URL) ;
         aP1_URL=this.AV9URL;
      }

      public void gxep_consultarpago( long aP0_MudanzaId ,
                                      out long aP1_SolicitudesId ,
                                      out string aP2_Pagado )
      {
         this.AV20MudanzaId = aP0_MudanzaId;
         initialize();
         /* ConsultarPago Constructor */
         new consultarpagopendientemudanza(context ).execute(  AV20MudanzaId, out  AV23SolicitudesId, out  AV22Pagado) ;
         aP1_SolicitudesId=this.AV23SolicitudesId;
         aP2_Pagado=this.AV22Pagado;
      }

      public void gxep_obtenerdatostoupdate( long aP0_SolicitudesId ,
                                             out SdtSDTMudanza aP1_SolicitudesJson )
      {
         this.AV23SolicitudesId = aP0_SolicitudesId;
         initialize();
         /* ObtenerDatosToUpdate Constructor */
         new obtenerdatostoupdatemudanza(context ).execute(  AV23SolicitudesId, out  AV24SolicitudesJson) ;
         aP1_SolicitudesJson=this.AV24SolicitudesJson;
      }

      public void gxep_obtenerpermisosolicitud( long aP0_SolicitudesId ,
                                                out bool aP1_Permiso )
      {
         this.AV23SolicitudesId = aP0_SolicitudesId;
         initialize();
         /* ObtenerPermisoSolicitud Constructor */
         new obtenerpermisosolicitud(context ).execute(  AV23SolicitudesId, out  AV26Permiso) ;
         aP1_Permiso=this.AV26Permiso;
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         AV7Result = "";
         AV9URL = "";
         AV16SDTCarga = new GXBaseCollection<SdtSDTCarga_SDTCargaItem>( context, "SDTCargaItem", "AlmangoX");
         AV17Mensaje = "";
         AV22Pagado = "";
         AV24SolicitudesJson = new SdtSDTMudanza(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apimudanza__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      protected long AV20MudanzaId ;
      protected long AV21SolicitudId ;
      protected long AV23SolicitudesId ;
      protected string Gx_restmethod ;
      protected string AV22Pagado ;
      protected bool AV26Permiso ;
      protected string AV7Result ;
      protected string AV18SDTMudanzaJson ;
      protected string AV19SDTCargaJson ;
      protected string AV5SearchTxt ;
      protected string AV6Coordenadas ;
      protected string AV8MapBox_id ;
      protected string AV11OrigenCoordenadas ;
      protected string AV10DestinoCoordenadas ;
      protected string AV9URL ;
      protected string AV13TextSearch ;
      protected string AV15Latitud ;
      protected string AV14Longitud ;
      protected string AV17Mensaje ;
      protected IGxDataStore dsDataStore1 ;
      protected IGxDataStore dsDefault ;
      protected string aP2_Result ;
      protected string aP1_Result ;
      protected string aP2_URL ;
      protected GXBaseCollection<SdtSDTCarga_SDTCargaItem> AV16SDTCarga ;
      protected GXBaseCollection<SdtSDTCarga_SDTCargaItem> aP0_SDTCarga ;
      protected long aP2_MudanzaId ;
      protected long aP3_SolicitudId ;
      protected string aP4_Mensaje ;
      protected string aP3_Mensaje ;
      protected string aP1_URL ;
      protected long aP1_SolicitudesId ;
      protected string aP2_Pagado ;
      protected SdtSDTMudanza AV24SolicitudesJson ;
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

 [ServiceContract(Namespace = "GeneXus.Programs.apimudanza_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class apimudanza_services : GxRestService
 {
    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public string gxep_obtenerdirecciones( string SearchTxt ,
                                           string Coordenadas )
    {
       string sResult = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apimudanza") )
          {
             return null ;
          }
          apimudanza worker = new apimudanza(context);
          worker.IsMain = RunAsMain ;
          worker.gxep_obtenerdirecciones(SearchTxt,Coordenadas,out sResult );
          worker.cleanup( );
          return sResult ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public string gxep_obtenercoordenadas( string MapBox_id )
    {
       string sResult = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apimudanza") )
          {
             return null ;
          }
          apimudanza worker = new apimudanza(context);
          worker.IsMain = RunAsMain ;
          worker.gxep_obtenercoordenadas(MapBox_id,out sResult );
          worker.cleanup( );
          return sResult ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public string gxep_obtenerurlmapa( string OrigenCoordenadas ,
                                       string DestinoCoordenadas )
    {
       string sURL = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apimudanza") )
          {
             return null ;
          }
          apimudanza worker = new apimudanza(context);
          worker.IsMain = RunAsMain ;
          worker.gxep_obtenerurlmapa(OrigenCoordenadas,DestinoCoordenadas,out sURL );
          worker.cleanup( );
          return sURL ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public string gxep_requestgoogleplace( string TextSearch )
    {
       string sResult = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apimudanza") )
          {
             return null ;
          }
          apimudanza worker = new apimudanza(context);
          worker.IsMain = RunAsMain ;
          worker.gxep_requestgoogleplace(TextSearch,out sResult );
          worker.cleanup( );
          return sResult ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public string gxep_obteneridbycoordenadas( string Latitud ,
                                               string Longitud )
    {
       string sResult = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apimudanza") )
          {
             return null ;
          }
          apimudanza worker = new apimudanza(context);
          worker.IsMain = RunAsMain ;
          worker.gxep_obteneridbycoordenadas(Latitud,Longitud,out sResult );
          worker.cleanup( );
          return sResult ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public GxGenericCollection<SdtSDTCarga_SDTCargaItem_RESTInterface> gxep_obtenerparametrosmudanza( )
    {
       GxGenericCollection<SdtSDTCarga_SDTCargaItem_RESTInterface> SDTCarga = new GxGenericCollection<SdtSDTCarga_SDTCargaItem_RESTInterface>();
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apimudanza") )
          {
             return null ;
          }
          apimudanza worker = new apimudanza(context);
          worker.IsMain = RunAsMain ;
          GXBaseCollection<SdtSDTCarga_SDTCargaItem> gxrSDTCarga = new GXBaseCollection<SdtSDTCarga_SDTCargaItem>();
          worker.gxep_obtenerparametrosmudanza(out gxrSDTCarga );
          worker.cleanup( );
          GxGenericCollection<SdtSDTCarga_SDTCargaItem_RESTInterface> AV16SDTCarga = new GxGenericCollection<SdtSDTCarga_SDTCargaItem_RESTInterface>(gxrSDTCarga) ;
          return AV16SDTCarga ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public string gxep_altamudanzaweb( string SDTMudanzaJson ,
                                       string SDTCargaJson ,
                                       out string sSolicitudId ,
                                       out string sMensaje )
    {
       sSolicitudId = "" ;
       sMensaje = "" ;
       string sMudanzaId = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apimudanza") )
          {
             return null ;
          }
          apimudanza worker = new apimudanza(context);
          worker.IsMain = RunAsMain ;
          long gxrMudanzaId = 0;
          gxrMudanzaId = (long)(Math.Round(NumberUtil.Val( sMudanzaId, "."), 18, MidpointRounding.ToEven));
          long gxrSolicitudId = 0;
          gxrSolicitudId = (long)(Math.Round(NumberUtil.Val( (string)(sSolicitudId), "."), 18, MidpointRounding.ToEven));
          worker.gxep_altamudanzaweb(SDTMudanzaJson,SDTCargaJson,out gxrMudanzaId,out gxrSolicitudId,out sMensaje );
          worker.cleanup( );
          sMudanzaId = StringUtil.LTrim( StringUtil.Str( (decimal)(gxrMudanzaId), 18, 0)) ;
          sSolicitudId = StringUtil.LTrim( StringUtil.Str( (decimal)(gxrSolicitudId), 18, 0)) ;
          return sMudanzaId ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public string gxep_updatemudanzaweb( string MudanzaId ,
                                         string SDTMudanzaJson ,
                                         string SDTCargaJson )
    {
       string sMensaje = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apimudanza") )
          {
             return null ;
          }
          apimudanza worker = new apimudanza(context);
          worker.IsMain = RunAsMain ;
          long gxrMudanzaId = 0;
          gxrMudanzaId = (long)(Math.Round(NumberUtil.Val( (string)(MudanzaId), "."), 18, MidpointRounding.ToEven));
          worker.gxep_updatemudanzaweb(gxrMudanzaId,SDTMudanzaJson,SDTCargaJson,out sMensaje );
          worker.cleanup( );
          return sMensaje ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public string gxep_obtenerurlmp( string MudanzaId )
    {
       string sURL = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apimudanza") )
          {
             return null ;
          }
          apimudanza worker = new apimudanza(context);
          worker.IsMain = RunAsMain ;
          long gxrMudanzaId = 0;
          gxrMudanzaId = (long)(Math.Round(NumberUtil.Val( (string)(MudanzaId), "."), 18, MidpointRounding.ToEven));
          worker.gxep_obtenerurlmp(gxrMudanzaId,out sURL );
          worker.cleanup( );
          return sURL ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public string gxep_consultarpago( string MudanzaId ,
                                      out string sPagado )
    {
       sPagado = "" ;
       string sSolicitudesId = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apimudanza") )
          {
             return null ;
          }
          apimudanza worker = new apimudanza(context);
          worker.IsMain = RunAsMain ;
          long gxrMudanzaId = 0;
          gxrMudanzaId = (long)(Math.Round(NumberUtil.Val( (string)(MudanzaId), "."), 18, MidpointRounding.ToEven));
          long gxrSolicitudesId = 0;
          gxrSolicitudesId = (long)(Math.Round(NumberUtil.Val( sSolicitudesId, "."), 18, MidpointRounding.ToEven));
          worker.gxep_consultarpago(gxrMudanzaId,out gxrSolicitudesId,out sPagado );
          worker.cleanup( );
          sSolicitudesId = StringUtil.LTrim( StringUtil.Str( (decimal)(gxrSolicitudesId), 18, 0)) ;
          return sSolicitudesId ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public SdtSDTMudanza_RESTInterface gxep_obtenerdatostoupdate( string SolicitudesId )
    {
       SdtSDTMudanza_RESTInterface SolicitudesJson = new SdtSDTMudanza_RESTInterface();
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apimudanza") )
          {
             return null ;
          }
          apimudanza worker = new apimudanza(context);
          worker.IsMain = RunAsMain ;
          long gxrSolicitudesId = 0;
          gxrSolicitudesId = (long)(Math.Round(NumberUtil.Val( (string)(SolicitudesId), "."), 18, MidpointRounding.ToEven));
          SdtSDTMudanza gxrSolicitudesJson = SolicitudesJson.sdt;
          worker.gxep_obtenerdatostoupdate(gxrSolicitudesId,out gxrSolicitudesJson );
          worker.cleanup( );
          SdtSDTMudanza_RESTInterface AV24SolicitudesJson = new SdtSDTMudanza_RESTInterface(gxrSolicitudesJson) ;
          return AV24SolicitudesJson ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public bool gxep_obtenerpermisosolicitud( string SolicitudesId )
    {
       bool sPermiso = false;
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return false ;
          }
          if ( ! ProcessHeaders("apimudanza") )
          {
             return false ;
          }
          apimudanza worker = new apimudanza(context);
          worker.IsMain = RunAsMain ;
          long gxrSolicitudesId = 0;
          gxrSolicitudesId = (long)(Math.Round(NumberUtil.Val( (string)(SolicitudesId), "."), 18, MidpointRounding.ToEven));
          worker.gxep_obtenerpermisosolicitud(gxrSolicitudesId,out sPermiso );
          worker.cleanup( );
          return sPermiso ;
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
