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
         initialize();
      }

      public apipostulacionsubasta( IGxContext context )
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
         restLocation.BaseUrl = "AlmangoXV1NETFramework/APIPostulacionSubasta";
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

      public void gxep_altapostulacionsubasta( string aP0_SDTPostulacionesJson ,
                                               out long aP1_SolicitudesId ,
                                               out string aP2_Mensaje )
      {
         restCliAltaPostulacionSubasta = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "AltaPostulacionSubasta";
         restCliAltaPostulacionSubasta.Location = restLocation;
         restCliAltaPostulacionSubasta.HttpMethod = "POST";
         restCliAltaPostulacionSubasta.AddBodyVar("SDTPostulacionesJson", (string)(aP0_SDTPostulacionesJson));
         restCliAltaPostulacionSubasta.RestExecute();
         gxProperties.ErrorCode = restCliAltaPostulacionSubasta.ErrorCode;
         gxProperties.ErrorMessage = restCliAltaPostulacionSubasta.ErrorMessage;
         gxProperties.StatusCode = restCliAltaPostulacionSubasta.StatusCode;
         gxProperties.StatusMessage = restCliAltaPostulacionSubasta.StatusMessage;
         if ( restCliAltaPostulacionSubasta.ErrorCode != 0 )
         {
            aP1_SolicitudesId = 0;
            aP2_Mensaje = "";
         }
         else
         {
            aP1_SolicitudesId = (long)(restCliAltaPostulacionSubasta.GetBodyNum("SolicitudesId"));
            aP2_Mensaje = restCliAltaPostulacionSubasta.GetBodyString("Mensaje");
         }
         /* AltaPostulacionSubasta Constructor */
      }

      public void gxep_obtenerservicioscategorias( out string aP0_ServiciosSDTJson )
      {
         restCliObtenerServiciosCategorias = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerServiciosCategorias";
         restCliObtenerServiciosCategorias.Location = restLocation;
         restCliObtenerServiciosCategorias.HttpMethod = "GET";
         restCliObtenerServiciosCategorias.RestExecute();
         gxProperties.ErrorCode = restCliObtenerServiciosCategorias.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerServiciosCategorias.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerServiciosCategorias.StatusCode;
         gxProperties.StatusMessage = restCliObtenerServiciosCategorias.StatusMessage;
         if ( restCliObtenerServiciosCategorias.ErrorCode != 0 )
         {
            aP0_ServiciosSDTJson = "";
         }
         else
         {
            aP0_ServiciosSDTJson = restCliObtenerServiciosCategorias.GetBodyString("ServiciosSDTJson");
         }
         /* ObtenerServiciosCategorias Constructor */
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         restCliAltaPostulacionSubasta = new GXRestAPIClient();
         aP1_SolicitudesId = new long();
         aP2_Mensaje = "";
         restCliObtenerServiciosCategorias = new GXRestAPIClient();
         aP0_ServiciosSDTJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apipostulacionsubasta__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      protected string Gx_restmethod ;
      protected GXRestAPIClient restCliAltaPostulacionSubasta ;
      protected GXRestAPIClient restCliObtenerServiciosCategorias ;
      protected GxLocation restLocation ;
      protected GxObjectProperties gxProperties ;
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

}
