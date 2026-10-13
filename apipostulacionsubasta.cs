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
   public class apipostulacionsubasta : GXProcedure
   {
      public apipostulacionsubasta( )
      {
         context = new GxContext(  );
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         IsApiObject = true;
      }

      public apipostulacionsubasta( IGxContext context )
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

      public void gxep_altapostulacionsubasta( string aP0_SDTPostulacionesJson ,
                                               out long aP1_SolicitudesId ,
                                               out string aP2_Mensaje )
      {
         this.AV6SDTPostulacionesJson = aP0_SDTPostulacionesJson;
         initialize();
         /* AltaPostulacionSubasta Constructor */
         new altasolicitudpostulacionsubastaweb(context ).execute(  AV6SDTPostulacionesJson, out  AV5SolicitudesId, out  AV7Mensaje) ;
         aP1_SolicitudesId=this.AV5SolicitudesId;
         aP2_Mensaje=this.AV7Mensaje;
      }

      public void gxep_obtenerservicioscategorias( out string aP0_ServiciosSDTJson )
      {
         initialize();
         /* ObtenerServiciosCategorias Constructor */
         new obtenerservicioscategorias(context ).execute( out  AV9ServiciosSDTJson) ;
         aP0_ServiciosSDTJson=this.AV9ServiciosSDTJson;
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         AV7Mensaje = "";
         AV9ServiciosSDTJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apipostulacionsubasta__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      protected long AV5SolicitudesId ;
      protected string Gx_restmethod ;
      protected string AV6SDTPostulacionesJson ;
      protected string AV9ServiciosSDTJson ;
      protected string AV7Mensaje ;
      protected IGxDataStore dsDataStore1 ;
      protected IGxDataStore dsDefault ;
      protected long aP1_SolicitudesId ;
      protected string aP2_Mensaje ;
      protected string aP0_ServiciosSDTJson ;
      protected IDataStoreProvider pr_default ;
   }

   public class apipostulacionsubasta__default : DataStoreHelperBase, IDataStoreHelper
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

 [ServiceContract(Namespace = "GeneXus.Programs.apipostulacionsubasta_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class apipostulacionsubasta_services : GxRestService
 {
    [OperationContract]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/APIPostulacionSubasta/AltaPostulacionSubasta")]
    public string gxep_altapostulacionsubasta( string SDTPostulacionesJson ,
                                               out string sMensaje )
    {
       sMensaje = "" ;
       string sSolicitudesId = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apipostulacionsubasta") )
          {
             return null ;
          }
          apipostulacionsubasta worker = new apipostulacionsubasta(context);
          worker.IsMain = RunAsMain ;
          long gxrSolicitudesId = 0;
          gxrSolicitudesId = (long)(Math.Round(NumberUtil.Val( sSolicitudesId, "."), 18, MidpointRounding.ToEven));
          worker.gxep_altapostulacionsubasta(SDTPostulacionesJson,out gxrSolicitudesId,out sMensaje );
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
    public string gxep_obtenerservicioscategorias( )
    {
       string sServiciosSDTJson = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apipostulacionsubasta") )
          {
             return null ;
          }
          apipostulacionsubasta worker = new apipostulacionsubasta(context);
          worker.IsMain = RunAsMain ;
          worker.gxep_obtenerservicioscategorias(out sServiciosSDTJson );
          worker.cleanup( );
          return sServiciosSDTJson ;
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

 }

}
