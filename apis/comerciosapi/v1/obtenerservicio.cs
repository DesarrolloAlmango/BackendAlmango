using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.apis.comerciosapi.v1 {
   public class obtenerservicio : GXProcedure
   {
      public obtenerservicio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenerservicio( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_SKU ,
                           out bool aP1_Error ,
                           out string aP2_Msj ,
                           out GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio aP3_Servicio ,
                           out short aP4_Gx_restcode )
      {
         this.AV22SKU = aP0_SKU;
         this.AV11Error = false ;
         this.AV16Msj = "" ;
         this.AV19Servicio = new GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio(context) ;
         this.Gx_restcode = 0 ;
         initialize();
         ExecutePrivate();
         aP1_Error=this.AV11Error;
         aP2_Msj=this.AV16Msj;
         aP3_Servicio=this.AV19Servicio;
         aP4_Gx_restcode=this.Gx_restcode;
      }

      public short executeUdp( string aP0_SKU ,
                               out bool aP1_Error ,
                               out string aP2_Msj ,
                               out GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio aP3_Servicio )
      {
         execute(aP0_SKU, out aP1_Error, out aP2_Msj, out aP3_Servicio, out aP4_Gx_restcode);
         return Gx_restcode ;
      }

      public void executeSubmit( string aP0_SKU ,
                                 out bool aP1_Error ,
                                 out string aP2_Msj ,
                                 out GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio aP3_Servicio ,
                                 out short aP4_Gx_restcode )
      {
         this.AV22SKU = aP0_SKU;
         this.AV11Error = false ;
         this.AV16Msj = "" ;
         this.AV19Servicio = new GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio(context) ;
         this.Gx_restcode = 0 ;
         SubmitImpl();
         aP1_Error=this.AV11Error;
         aP2_Msj=this.AV16Msj;
         aP3_Servicio=this.AV19Servicio;
         aP4_Gx_restcode=this.Gx_restcode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! GxRegex.IsMatch(StringUtil.Lower( StringUtil.Trim( AV22SKU)),context.GetMessage( "^amg\\d+-\\d+-\\d+$", "")) )
         {
            Gx_restcode = 400;
            AV11Error = true;
            AV16Msj = context.GetMessage( "El formato del SKU no es válido.", "");
            cleanup();
            if (true) return;
         }
         AV8ApiKeyHeader = AV13HttpRequest.GetHeader(context.GetMessage( "x-api-key", ""));
         new GeneXus.Programs.apis.comerciosapi.v1.pvalidarapikeycomercio(context ).execute(  AV8ApiKeyHeader, out  AV17ProveedorID, out  AV23STComerciosID, out  AV24TipoIntegracion, out  AV9ComercioAutenticado) ;
         if ( ! AV9ComercioAutenticado )
         {
            Gx_restcode = 401;
            AV11Error = true;
            AV16Msj = context.GetMessage( "No autorizado. Verifique su API Key.", "");
            cleanup();
            if (true) return;
         }
         new resolverproductodesdesku(context ).execute(  AV23STComerciosID,  AV17ProveedorID,  AV22SKU, out  AV18RubrosId, out  AV15MedidasId, out  AV14InventarioId, out  AV12ErrorLinea, ref  AV10DebugLog) ;
         if ( AV12ErrorLinea )
         {
            Gx_restcode = 400;
            AV11Error = true;
            AV16Msj = context.GetMessage( "No se pudo resolver el código del servicio.", "");
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.comerciosapi.v1.pevaluarhabilitacionservicio(context ).execute(  AV17ProveedorID,  AV18RubrosId,  AV15MedidasId,  AV14InventarioId, out  AV20ServicioBloqueado) ;
         if ( AV20ServicioBloqueado )
         {
            Gx_restcode = 403;
            AV11Error = true;
            AV16Msj = context.GetMessage( "Este servicio no está habilitado para tu comercio.", "");
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.comerciosapi.v1.pobtenerservicioyprecio(context ).execute(  AV17ProveedorID,  AV18RubrosId,  AV15MedidasId,  AV14InventarioId, out  AV19Servicio, out  AV21ServicioEncontrado) ;
         if ( AV21ServicioEncontrado )
         {
            AV19Servicio.gxTpr_Codigoservicio = AV22SKU;
            Gx_restcode = 200;
            AV11Error = false;
            AV16Msj = context.GetMessage( "Servicio encontrado.", "");
         }
         else
         {
            Gx_restcode = 404;
            AV11Error = true;
            AV16Msj = context.GetMessage( "Servicio no encontrado o no disponible.", "");
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV16Msj = "";
         AV19Servicio = new GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio(context);
         AV8ApiKeyHeader = "";
         AV13HttpRequest = new GxHttpRequest( context);
         AV10DebugLog = "";
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private short AV24TipoIntegracion ;
      private short AV18RubrosId ;
      private long AV17ProveedorID ;
      private long AV23STComerciosID ;
      private long AV15MedidasId ;
      private long AV14InventarioId ;
      private bool AV11Error ;
      private bool AV9ComercioAutenticado ;
      private bool AV12ErrorLinea ;
      private bool AV20ServicioBloqueado ;
      private bool AV21ServicioEncontrado ;
      private string AV22SKU ;
      private string AV16Msj ;
      private string AV8ApiKeyHeader ;
      private string AV10DebugLog ;
      private GxHttpRequest AV13HttpRequest ;
      private GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio AV19Servicio ;
      private bool aP1_Error ;
      private string aP2_Msj ;
      private GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio aP3_Servicio ;
      private short aP4_Gx_restcode ;
   }

}
