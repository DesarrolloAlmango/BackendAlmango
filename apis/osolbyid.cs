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
   public class osolbyid : GXProcedure
   {
      public osolbyid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public osolbyid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_User ,
                           long aP1_SolicitudesID ,
                           string aP2_ProfesionalId ,
                           out short aP3_Gx_restcode ,
                           out string aP4_RestMessage ,
                           out SdtSDTSolicitudes aP5_Solicitud )
      {
         this.AV28User = aP0_User;
         this.AV25SolicitudesID = aP1_SolicitudesID;
         this.AV22ProfesionalId = aP2_ProfesionalId;
         this.Gx_restcode = 0 ;
         this.AV23RestMessage = "" ;
         this.AV24Solicitud = new SdtSDTSolicitudes(context) ;
         initialize();
         ExecutePrivate();
         aP3_Gx_restcode=this.Gx_restcode;
         aP4_RestMessage=this.AV23RestMessage;
         aP5_Solicitud=this.AV24Solicitud;
      }

      public SdtSDTSolicitudes executeUdp( string aP0_User ,
                                           long aP1_SolicitudesID ,
                                           string aP2_ProfesionalId ,
                                           out short aP3_Gx_restcode ,
                                           out string aP4_RestMessage )
      {
         execute(aP0_User, aP1_SolicitudesID, aP2_ProfesionalId, out aP3_Gx_restcode, out aP4_RestMessage, out aP5_Solicitud);
         return AV24Solicitud ;
      }

      public void executeSubmit( string aP0_User ,
                                 long aP1_SolicitudesID ,
                                 string aP2_ProfesionalId ,
                                 out short aP3_Gx_restcode ,
                                 out string aP4_RestMessage ,
                                 out SdtSDTSolicitudes aP5_Solicitud )
      {
         this.AV28User = aP0_User;
         this.AV25SolicitudesID = aP1_SolicitudesID;
         this.AV22ProfesionalId = aP2_ProfesionalId;
         this.Gx_restcode = 0 ;
         this.AV23RestMessage = "" ;
         this.AV24Solicitud = new SdtSDTSolicitudes(context) ;
         SubmitImpl();
         aP3_Gx_restcode=this.Gx_restcode;
         aP4_RestMessage=this.AV23RestMessage;
         aP5_Solicitud=this.AV24Solicitud;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22ProfesionalId)) || String.IsNullOrEmpty(StringUtil.RTrim( AV28User)) || (0==AV25SolicitudesID) )
         {
            AV23RestMessage = context.GetMessage( "Error de parámetros", "");
            Gx_restcode = 400;
            cleanup();
            if (true) return;
         }
         AV27TokenId = "";
         AV17IsOkToken = true;
         AV23RestMessage = "";
         new GeneXus.Programs.apis.checkauthorization(context ).execute(  AV16HttpRequest,  AV28User,  AV22ProfesionalId, out  AV27TokenId, out  AV17IsOkToken, out  Gx_restcode, out  AV23RestMessage) ;
         if ( ! AV17IsOkToken )
         {
            Gx_restcode = 401;
            cleanup();
            if (true) return;
         }
         if ( ! (0==AV25SolicitudesID) && ! ( AV25SolicitudesID == 0 ) )
         {
            new GeneXus.Programs.apis.odatossolcompleto(context ).execute(  AV25SolicitudesID,  AV22ProfesionalId, out  AV24Solicitud, out  AV29Existe) ;
            if ( ! AV29Existe )
            {
               AV23RestMessage = context.GetMessage( "No se encontró la solicitud", "");
               Gx_restcode = 404;
            }
            if ( Gx_restcode != 404 )
            {
               Gx_restcode = 200;
               AV23RestMessage = context.GetMessage( "Solicitud procesada con éxito", "");
            }
         }
         else
         {
            Gx_restcode = 400;
            AV23RestMessage = context.GetMessage( "Error de parámetros obligatorios", "");
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
         AV23RestMessage = "";
         AV24Solicitud = new SdtSDTSolicitudes(context);
         AV27TokenId = "";
         AV16HttpRequest = new GxHttpRequest( context);
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private long AV25SolicitudesID ;
      private string AV28User ;
      private string AV22ProfesionalId ;
      private string AV27TokenId ;
      private bool AV17IsOkToken ;
      private bool AV29Existe ;
      private string AV23RestMessage ;
      private GxHttpRequest AV16HttpRequest ;
      private SdtSDTSolicitudes AV24Solicitud ;
      private short aP3_Gx_restcode ;
      private string aP4_RestMessage ;
      private SdtSDTSolicitudes aP5_Solicitud ;
   }

}
