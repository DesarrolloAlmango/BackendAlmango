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
   public class subastasapi : GXProcedure
   {
      public subastasapi( )
      {
         context = new GxContext(  );
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         IsApiObject = true;
      }

      public subastasapi( IGxContext context )
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

      public void gxep_altapublicaciones( string aP0_JsonPublicaciones ,
                                          out string aP1_JsonMessages )
      {
         this.AV5JsonPublicaciones = aP0_JsonPublicaciones;
         initialize();
         /* AltaPublicaciones Constructor */
         new altapublicaciones(context ).execute(  AV5JsonPublicaciones, out  AV8JsonMessages) ;
         aP1_JsonMessages=this.AV8JsonMessages;
      }

      public void gxep_obtenerpaismoneda( out GXBaseCollection<SdtSDTPaisMoneda_SDTPaisMonedaItem> aP0_SDTPaisMoneda )
      {
         initialize();
         /* ObtenerPaisMoneda Constructor */
         new obtenerpaismoneda(context ).execute( out  AV6SDTPaisMoneda) ;
         aP0_SDTPaisMoneda=this.AV6SDTPaisMoneda;
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         AV8JsonMessages = "";
         AV6SDTPaisMoneda = new GXBaseCollection<SdtSDTPaisMoneda_SDTPaisMonedaItem>( context, "SDTPaisMonedaItem", "AlmangoX");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.subastasapi__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      protected string Gx_restmethod ;
      protected string AV5JsonPublicaciones ;
      protected string AV8JsonMessages ;
      protected IGxDataStore dsDataStore1 ;
      protected IGxDataStore dsDefault ;
      protected string aP1_JsonMessages ;
      protected GXBaseCollection<SdtSDTPaisMoneda_SDTPaisMonedaItem> AV6SDTPaisMoneda ;
      protected GXBaseCollection<SdtSDTPaisMoneda_SDTPaisMonedaItem> aP0_SDTPaisMoneda ;
      protected IDataStoreProvider pr_default ;
   }

   public class subastasapi__default : DataStoreHelperBase, IDataStoreHelper
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

 [ServiceContract(Namespace = "GeneXus.Programs.subastasapi_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class subastasapi_services : GxRestService
 {
    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public string gxep_altapublicaciones( string JsonPublicaciones )
    {
       string sJsonMessages = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("subastasapi") )
          {
             return null ;
          }
          subastasapi worker = new subastasapi(context);
          worker.IsMain = RunAsMain ;
          worker.gxep_altapublicaciones(JsonPublicaciones,out sJsonMessages );
          worker.cleanup( );
          return sJsonMessages ;
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
    public GxGenericCollection<SdtSDTPaisMoneda_SDTPaisMonedaItem_RESTInterface> gxep_obtenerpaismoneda( )
    {
       GxGenericCollection<SdtSDTPaisMoneda_SDTPaisMonedaItem_RESTInterface> SDTPaisMoneda = new GxGenericCollection<SdtSDTPaisMoneda_SDTPaisMonedaItem_RESTInterface>();
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("subastasapi") )
          {
             return null ;
          }
          subastasapi worker = new subastasapi(context);
          worker.IsMain = RunAsMain ;
          GXBaseCollection<SdtSDTPaisMoneda_SDTPaisMonedaItem> gxrSDTPaisMoneda = new GXBaseCollection<SdtSDTPaisMoneda_SDTPaisMonedaItem>();
          worker.gxep_obtenerpaismoneda(out gxrSDTPaisMoneda );
          worker.cleanup( );
          GxGenericCollection<SdtSDTPaisMoneda_SDTPaisMonedaItem_RESTInterface> AV6SDTPaisMoneda = new GxGenericCollection<SdtSDTPaisMoneda_SDTPaisMonedaItem_RESTInterface>(gxrSDTPaisMoneda) ;
          return AV6SDTPaisMoneda ;
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
