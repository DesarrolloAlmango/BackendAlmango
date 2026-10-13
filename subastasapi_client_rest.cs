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
         initialize();
      }

      public subastasapi( IGxContext context )
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
         restLocation.BaseUrl = "AlmangoXV1NETFramework/SubastasAPI";
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

      public void gxep_altapublicaciones( string aP0_JsonPublicaciones ,
                                          out string aP1_JsonMessages )
      {
         restCliAltaPublicaciones = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "AltaPublicaciones";
         restCliAltaPublicaciones.Location = restLocation;
         restCliAltaPublicaciones.HttpMethod = "GET";
         restCliAltaPublicaciones.AddQueryVar("Jsonpublicaciones", (string)(aP0_JsonPublicaciones));
         restCliAltaPublicaciones.RestExecute();
         gxProperties.ErrorCode = restCliAltaPublicaciones.ErrorCode;
         gxProperties.ErrorMessage = restCliAltaPublicaciones.ErrorMessage;
         gxProperties.StatusCode = restCliAltaPublicaciones.StatusCode;
         gxProperties.StatusMessage = restCliAltaPublicaciones.StatusMessage;
         if ( restCliAltaPublicaciones.ErrorCode != 0 )
         {
            aP1_JsonMessages = "";
         }
         else
         {
            aP1_JsonMessages = restCliAltaPublicaciones.GetBodyString("JsonMessages");
         }
         /* AltaPublicaciones Constructor */
      }

      public void gxep_obtenerpaismoneda( out GXBaseCollection<SdtSDTPaisMoneda_SDTPaisMonedaItem> aP0_SDTPaisMoneda )
      {
         restCliObtenerPaisMoneda = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerPaisMoneda";
         restCliObtenerPaisMoneda.Location = restLocation;
         restCliObtenerPaisMoneda.HttpMethod = "GET";
         restCliObtenerPaisMoneda.RestExecute();
         gxProperties.ErrorCode = restCliObtenerPaisMoneda.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerPaisMoneda.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerPaisMoneda.StatusCode;
         gxProperties.StatusMessage = restCliObtenerPaisMoneda.StatusMessage;
         if ( restCliObtenerPaisMoneda.ErrorCode != 0 )
         {
            aP0_SDTPaisMoneda = new GXBaseCollection<SdtSDTPaisMoneda_SDTPaisMonedaItem>();
         }
         else
         {
            aP0_SDTPaisMoneda = restCliObtenerPaisMoneda.GetBodySdtCollection<SdtSDTPaisMoneda_SDTPaisMonedaItem>("SDTPaisMoneda");
         }
         /* ObtenerPaisMoneda Constructor */
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         restCliAltaPublicaciones = new GXRestAPIClient();
         aP1_JsonMessages = "";
         restCliObtenerPaisMoneda = new GXRestAPIClient();
         aP0_SDTPaisMoneda = new GXBaseCollection<SdtSDTPaisMoneda_SDTPaisMonedaItem>();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.subastasapi__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      protected string Gx_restmethod ;
      protected GXRestAPIClient restCliAltaPublicaciones ;
      protected GXRestAPIClient restCliObtenerPaisMoneda ;
      protected GxLocation restLocation ;
      protected GxObjectProperties gxProperties ;
      protected IGxDataStore dsDataStore1 ;
      protected IGxDataStore dsDefault ;
      protected string aP1_JsonMessages ;
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

}
