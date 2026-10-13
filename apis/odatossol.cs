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
namespace GeneXus.Programs.apis {
   public class odatossol : GXProcedure
   {
      public odatossol( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public odatossol( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( long aP0_SolicitudesID ,
                           out SdtSDTSolicitudes aP1_SDTOut ,
                           out short aP2_Gx_restcode ,
                           out string aP3_RestMessage )
      {
         this.AV11SolicitudesID = aP0_SolicitudesID;
         this.AV12SDTOut = new SdtSDTSolicitudes(context) ;
         this.Gx_restcode = 0 ;
         this.AV10RestMessage = "" ;
         initialize();
         ExecutePrivate();
         aP1_SDTOut=this.AV12SDTOut;
         aP2_Gx_restcode=this.Gx_restcode;
         aP3_RestMessage=this.AV10RestMessage;
      }

      public string executeUdp( long aP0_SolicitudesID ,
                                out SdtSDTSolicitudes aP1_SDTOut ,
                                out short aP2_Gx_restcode )
      {
         execute(aP0_SolicitudesID, out aP1_SDTOut, out aP2_Gx_restcode, out aP3_RestMessage);
         return AV10RestMessage ;
      }

      public void executeSubmit( long aP0_SolicitudesID ,
                                 out SdtSDTSolicitudes aP1_SDTOut ,
                                 out short aP2_Gx_restcode ,
                                 out string aP3_RestMessage )
      {
         this.AV11SolicitudesID = aP0_SolicitudesID;
         this.AV12SDTOut = new SdtSDTSolicitudes(context) ;
         this.Gx_restcode = 0 ;
         this.AV10RestMessage = "" ;
         SubmitImpl();
         aP1_SDTOut=this.AV12SDTOut;
         aP2_Gx_restcode=this.Gx_restcode;
         aP3_RestMessage=this.AV10RestMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! context.isAjaxRequest( ) )
         {
            AV13HttpResponse.AppendHeader(context.GetMessage( "Cache-Control", ""), context.GetMessage( "no-store, no-cache, must-revalidate, max-age=0", ""));
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV13HttpResponse.AppendHeader(context.GetMessage( "Pragma", ""), context.GetMessage( "no-cache", ""));
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV13HttpResponse.AppendHeader(context.GetMessage( "Expires", ""), "0");
         }
         if ( (0==AV11SolicitudesID) || ( AV11SolicitudesID == 0 ) )
         {
            Gx_restcode = 400;
            AV10RestMessage = context.GetMessage( "Error de parámetros obligatorios", "");
            cleanup();
            if (true) return;
         }
         AV8SDTBase = new SdtSDTSolicitudes(context);
         AV9Existe = false;
         new GeneXus.Programs.apis.odatossolcompleto(context ).execute(  AV11SolicitudesID,  "", out  AV8SDTBase, out  AV9Existe) ;
         if ( ! AV9Existe )
         {
            Gx_restcode = 404;
            AV10RestMessage = context.GetMessage( "No se encontró la solicitud", "");
            cleanup();
            if (true) return;
         }
         AV12SDTOut = new SdtSDTSolicitudes(context);
         AV12SDTOut.gxTpr_Solicitudesid = AV8SDTBase.gxTpr_Solicitudesid;
         AV12SDTOut.gxTpr_Estadossolid = AV8SDTBase.gxTpr_Estadossolid;
         AV12SDTOut.gxTpr_Departamentoid = AV8SDTBase.gxTpr_Departamentoid;
         AV12SDTOut.gxTpr_Departamentomunicipioid = AV8SDTBase.gxTpr_Departamentomunicipioid;
         AV12SDTOut.gxTpr_Solicitudesfechainstalacion = AV8SDTBase.gxTpr_Solicitudesfechainstalacion;
         AV12SDTOut.gxTpr_Solicitudeshorainstalacion = AV8SDTBase.gxTpr_Solicitudeshorainstalacion;
         AV12SDTOut.gxTpr_Solicitudesnombre = AV8SDTBase.gxTpr_Solicitudesnombre;
         AV12SDTOut.gxTpr_Estadossolnombre = AV8SDTBase.gxTpr_Estadossolnombre;
         AV12SDTOut.gxTpr_Solicitudesdireccion = AV8SDTBase.gxTpr_Solicitudesdireccion;
         AV12SDTOut.gxTpr_Stcomerciosnombre = AV8SDTBase.gxTpr_Stcomerciosnombre;
         AV12SDTOut.gxTpr_Proveedornombre = AV8SDTBase.gxTpr_Proveedornombre;
         AV12SDTOut.gxTpr_Solicitudescomisionmetodopago = AV8SDTBase.gxTpr_Solicitudescomisionmetodopago;
         AV12SDTOut.gxTpr_Solicitudestotal = AV8SDTBase.gxTpr_Solicitudestotal;
         AV12SDTOut.gxTpr_Solicitudservicioorigenpago = AV8SDTBase.gxTpr_Solicitudservicioorigenpago;
         Gx_restcode = 200;
         AV10RestMessage = context.GetMessage( "Solicitud procesada con éxito", "");
         cleanup();
         if (true) return;
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
         AV12SDTOut = new SdtSDTSolicitudes(context);
         AV10RestMessage = "";
         AV13HttpResponse = new GxHttpResponse( context);
         AV8SDTBase = new SdtSDTSolicitudes(context);
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private long AV11SolicitudesID ;
      private bool AV9Existe ;
      private string AV10RestMessage ;
      private GxHttpResponse AV13HttpResponse ;
      private SdtSDTSolicitudes AV12SDTOut ;
      private SdtSDTSolicitudes AV8SDTBase ;
      private SdtSDTSolicitudes aP1_SDTOut ;
      private short aP2_Gx_restcode ;
      private string aP3_RestMessage ;
   }

}
