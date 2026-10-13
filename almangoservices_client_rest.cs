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
         initialize();
      }

      public almangoservices( IGxContext context )
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
         restLocation.BaseUrl = "AlmangoXV1NETFramework/AlmangoServices";
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

      public void gxep_getcantsol( string aP0_UserConect ,
                                   string aP1_Key ,
                                   out string aP2_RestMessage )
      {
         restCliGetCantSol = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "GetCantSol";
         restCliGetCantSol.Location = restLocation;
         restCliGetCantSol.HttpMethod = "GET";
         restCliGetCantSol.AddQueryVar("Userconect", (string)(aP0_UserConect));
         restCliGetCantSol.AddQueryVar("Key", (string)(aP1_Key));
         restCliGetCantSol.RestExecute();
         gxProperties.ErrorCode = restCliGetCantSol.ErrorCode;
         gxProperties.ErrorMessage = restCliGetCantSol.ErrorMessage;
         gxProperties.StatusCode = restCliGetCantSol.StatusCode;
         gxProperties.StatusMessage = restCliGetCantSol.StatusMessage;
         if ( restCliGetCantSol.ErrorCode != 0 )
         {
            aP2_RestMessage = "";
         }
         else
         {
            aP2_RestMessage = restCliGetCantSol.GetBodyString("RestMessage");
         }
         /* GetCantSol Constructor */
      }

      public void gxep_getallservices( string aP0_UserConect ,
                                       string aP1_Key ,
                                       long aP2_ProveedorID ,
                                       out string aP3_RestMessage ,
                                       out string aP4_Inventario )
      {
         restCliGetAllServices = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "GetAllServices";
         restCliGetAllServices.Location = restLocation;
         restCliGetAllServices.HttpMethod = "GET";
         restCliGetAllServices.AddQueryVar("Userconect", (string)(aP0_UserConect));
         restCliGetAllServices.AddQueryVar("Key", (string)(aP1_Key));
         restCliGetAllServices.AddQueryVar("Proveedorid", (long)(aP2_ProveedorID));
         restCliGetAllServices.RestExecute();
         gxProperties.ErrorCode = restCliGetAllServices.ErrorCode;
         gxProperties.ErrorMessage = restCliGetAllServices.ErrorMessage;
         gxProperties.StatusCode = restCliGetAllServices.StatusCode;
         gxProperties.StatusMessage = restCliGetAllServices.StatusMessage;
         if ( restCliGetAllServices.ErrorCode != 0 )
         {
            aP3_RestMessage = "";
            aP4_Inventario = "";
         }
         else
         {
            aP3_RestMessage = restCliGetAllServices.GetBodyString("RestMessage");
            aP4_Inventario = restCliGetAllServices.GetBodyString("Inventario");
         }
         /* GetAllServices Constructor */
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         restCliGetCantSol = new GXRestAPIClient();
         aP2_RestMessage = "";
         restCliGetAllServices = new GXRestAPIClient();
         aP3_RestMessage = "";
         aP4_Inventario = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almangoservices__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      protected string Gx_restmethod ;
      protected GXRestAPIClient restCliGetCantSol ;
      protected GXRestAPIClient restCliGetAllServices ;
      protected GxLocation restLocation ;
      protected GxObjectProperties gxProperties ;
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

}
