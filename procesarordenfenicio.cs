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
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class procesarordenfenicio : GXProcedure
   {
      public procesarordenfenicio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public procesarordenfenicio( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( SdtSDTFenicioOrdersResponse_ordenesItem aP0_Orden ,
                           long aP1_EcommerceId ,
                           long aP2_ComercioId ,
                           DateTime aP3_FechaDesde ,
                           DateTime aP4_FechaHasta ,
                           out bool aP5_ProcesadaOk ,
                           ref string aP6_DebugLog )
      {
         this.AV12Orden = aP0_Orden;
         this.AV20EcommerceId = aP1_EcommerceId;
         this.AV9ComercioId = aP2_ComercioId;
         this.AV21FechaDesde = aP3_FechaDesde;
         this.AV22FechaHasta = aP4_FechaHasta;
         this.AV14ProcesadaOk = false ;
         this.AV18DebugLog = aP6_DebugLog;
         initialize();
         ExecutePrivate();
         aP5_ProcesadaOk=this.AV14ProcesadaOk;
         aP6_DebugLog=this.AV18DebugLog;
      }

      public string executeUdp( SdtSDTFenicioOrdersResponse_ordenesItem aP0_Orden ,
                                long aP1_EcommerceId ,
                                long aP2_ComercioId ,
                                DateTime aP3_FechaDesde ,
                                DateTime aP4_FechaHasta ,
                                out bool aP5_ProcesadaOk )
      {
         execute(aP0_Orden, aP1_EcommerceId, aP2_ComercioId, aP3_FechaDesde, aP4_FechaHasta, out aP5_ProcesadaOk, ref aP6_DebugLog);
         return AV18DebugLog ;
      }

      public void executeSubmit( SdtSDTFenicioOrdersResponse_ordenesItem aP0_Orden ,
                                 long aP1_EcommerceId ,
                                 long aP2_ComercioId ,
                                 DateTime aP3_FechaDesde ,
                                 DateTime aP4_FechaHasta ,
                                 out bool aP5_ProcesadaOk ,
                                 ref string aP6_DebugLog )
      {
         this.AV12Orden = aP0_Orden;
         this.AV20EcommerceId = aP1_EcommerceId;
         this.AV9ComercioId = aP2_ComercioId;
         this.AV21FechaDesde = aP3_FechaDesde;
         this.AV22FechaHasta = aP4_FechaHasta;
         this.AV14ProcesadaOk = false ;
         this.AV18DebugLog = aP6_DebugLog;
         SubmitImpl();
         aP5_ProcesadaOk=this.AV14ProcesadaOk;
         aP6_DebugLog=this.AV18DebugLog;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV14ProcesadaOk = false;
         if ( (DateTime.MinValue==AV12Orden.gxTpr_Fechafin) )
         {
            cleanup();
            if (true) return;
         }
         new existeordenfenicioprocesada(context ).execute(  AV12Orden.gxTpr_Idorden, out  AV10Existe, ref  AV18DebugLog) ;
         AV18DebugLog += context.GetMessage( "Existe en sistema", "") + StringUtil.BoolToStr( AV10Existe) + " - ";
         if ( AV10Existe )
         {
            cleanup();
            if (true) return;
         }
         new ordentieneamg(context ).execute(  AV12Orden, out  AV17TieneAMG) ;
         AV18DebugLog += context.GetMessage( "Tiene amg: ", "") + StringUtil.BoolToStr( AV17TieneAMG) + " - ";
         if ( ! AV17TieneAMG )
         {
            cleanup();
            if (true) return;
         }
         new crearsolicituddesdefenicio(context ).execute(  AV20EcommerceId,  AV9ComercioId,  AV12Orden, out  AV11MensajeBC, out  AV16ResultadoSolicitudOK, ref  AV18DebugLog) ;
         AV18DebugLog += context.GetMessage( "Errores BC: ", "") + AV11MensajeBC + " - ";
         AV13OrdenJson = AV12Orden.ToJSonString(false, true);
         AV24EstadoOperacion = (AV16ResultadoSolicitudOK ? "PRO" : "PND");
         new registrarordenfenicioprocesada(context ).execute(  AV12Orden.gxTpr_Idorden,  AV20EcommerceId,  AV9ComercioId,  "FEN",  AV24EstadoOperacion,  AV13OrdenJson,  AV15ResponseJson,  AV11MensajeBC,  AV21FechaDesde,  AV22FechaHasta,  AV23MensajeError, out  AV8AuditOK) ;
         AV14ProcesadaOk = AV16ResultadoSolicitudOK;
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
         AV11MensajeBC = "";
         AV13OrdenJson = "";
         AV24EstadoOperacion = "";
         AV15ResponseJson = "";
         AV23MensajeError = "";
         /* GeneXus formulas. */
      }

      private long AV20EcommerceId ;
      private long AV9ComercioId ;
      private string AV24EstadoOperacion ;
      private DateTime AV21FechaDesde ;
      private DateTime AV22FechaHasta ;
      private bool AV14ProcesadaOk ;
      private bool AV10Existe ;
      private bool AV17TieneAMG ;
      private bool AV16ResultadoSolicitudOK ;
      private bool AV8AuditOK ;
      private string AV18DebugLog ;
      private string AV11MensajeBC ;
      private string AV13OrdenJson ;
      private string AV15ResponseJson ;
      private string AV23MensajeError ;
      private SdtSDTFenicioOrdersResponse_ordenesItem AV12Orden ;
      private string aP6_DebugLog ;
      private bool aP5_ProcesadaOk ;
   }

}
