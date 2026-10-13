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
   public class almangoservices : GXProcedure
   {
      public almangoservices( )
      {
         context = new GxContext(  );
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         IsApiObject = true;
      }

      public almangoservices( IGxContext context )
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

      public void gxep_getcantsol( string aP0_UserConect ,
                                   string aP1_Key ,
                                   out string aP2_RestMessage )
      {
         this.AV6UserConect = aP0_UserConect;
         this.AV7Key = aP1_Key;
         initialize();
         /* GetCantSol Constructor */
         GXt_int1 = Gx_restcode;
         new cantsolicitudes(context ).execute(  AV6UserConect,  AV7Key, out  GXt_int1, out  AV8RestMessage) ;
         Gx_restcode = Convert.ToInt16(GXt_int1);
         aP2_RestMessage=this.AV8RestMessage;
      }

      public void gxep_getallservices( string aP0_UserConect ,
                                       string aP1_Key ,
                                       long aP2_ProveedorID ,
                                       out string aP3_RestMessage ,
                                       out string aP4_Inventario )
      {
         this.AV6UserConect = aP0_UserConect;
         this.AV7Key = aP1_Key;
         this.AV9ProveedorID = aP2_ProveedorID;
         initialize();
         /* GetAllServices Constructor */
         GXt_int2 = Gx_restcode;
         new wsoserviciosdetall(context ).execute(  AV6UserConect,  AV7Key,  AV9ProveedorID, out  GXt_int2, out  AV8RestMessage, out  AV11Inventario) ;
         Gx_restcode = Convert.ToInt16(GXt_int2);
         aP3_RestMessage=this.AV8RestMessage;
         aP4_Inventario=this.AV11Inventario;
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
         AV8RestMessage = "";
         AV11Inventario = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almangoservices__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      protected short Gx_restcode ;
      protected int GXt_int1 ;
      protected int GXt_int2 ;
      protected long AV9ProveedorID ;
      protected string Gx_restmethod ;
      protected string AV6UserConect ;
      protected string AV7Key ;
      protected string AV8RestMessage ;
      protected string AV11Inventario ;
      protected IGxDataStore dsDataStore1 ;
      protected IGxDataStore dsDefault ;
      protected string aP2_RestMessage ;
      protected string aP3_RestMessage ;
      protected string aP4_Inventario ;
      protected IDataStoreProvider pr_default ;
   }

   public class almangoservices__default : DataStoreHelperBase, IDataStoreHelper
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

 [ServiceContract(Namespace = "GeneXus.Programs.almangoservices_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class almangoservices_services : GxRestService
 {
    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public string gxep_getcantsol( string UserConect ,
                                   string Key )
    {
       string sRestMessage = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("almangoservices") )
          {
             return null ;
          }
          almangoservices worker = new almangoservices(context);
          worker.IsMain = RunAsMain ;
          worker.gxep_getcantsol(UserConect,Key,out sRestMessage );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          return sRestMessage ;
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
    public string gxep_getallservices( string UserConect ,
                                       string Key ,
                                       string ProveedorID ,
                                       out string sInventario )
    {
       sInventario = "" ;
       string sRestMessage = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("almangoservices") )
          {
             return null ;
          }
          almangoservices worker = new almangoservices(context);
          worker.IsMain = RunAsMain ;
          long gxrProveedorID = 0;
          gxrProveedorID = (long)(Math.Round(NumberUtil.Val( (string)(ProveedorID), "."), 18, MidpointRounding.ToEven));
          worker.gxep_getallservices(UserConect,Key,gxrProveedorID,out sRestMessage,out sInventario );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          return sRestMessage ;
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
