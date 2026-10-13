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
   public class obtenerjwt : GXProcedure
   {
      public obtenerjwt( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenerjwt( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_User ,
                           string aP1_ProfesionalesId ,
                           out GeneXus.Programs.apis.SdtSDTGoogleDriveApiResponse aP2_SDTGoogleDriveApiResponse ,
                           out string aP3_RestMessage ,
                           out short aP4_Gx_restcode )
      {
         this.AV18User = aP0_User;
         this.AV12ProfesionalesId = aP1_ProfesionalesId;
         this.AV15SDTGoogleDriveApiResponse = new GeneXus.Programs.apis.SdtSDTGoogleDriveApiResponse(context) ;
         this.AV13RestMessage = "" ;
         this.Gx_restcode = 0 ;
         initialize();
         ExecutePrivate();
         aP2_SDTGoogleDriveApiResponse=this.AV15SDTGoogleDriveApiResponse;
         aP3_RestMessage=this.AV13RestMessage;
         aP4_Gx_restcode=this.Gx_restcode;
      }

      public short executeUdp( string aP0_User ,
                               string aP1_ProfesionalesId ,
                               out GeneXus.Programs.apis.SdtSDTGoogleDriveApiResponse aP2_SDTGoogleDriveApiResponse ,
                               out string aP3_RestMessage )
      {
         execute(aP0_User, aP1_ProfesionalesId, out aP2_SDTGoogleDriveApiResponse, out aP3_RestMessage, out aP4_Gx_restcode);
         return Gx_restcode ;
      }

      public void executeSubmit( string aP0_User ,
                                 string aP1_ProfesionalesId ,
                                 out GeneXus.Programs.apis.SdtSDTGoogleDriveApiResponse aP2_SDTGoogleDriveApiResponse ,
                                 out string aP3_RestMessage ,
                                 out short aP4_Gx_restcode )
      {
         this.AV18User = aP0_User;
         this.AV12ProfesionalesId = aP1_ProfesionalesId;
         this.AV15SDTGoogleDriveApiResponse = new GeneXus.Programs.apis.SdtSDTGoogleDriveApiResponse(context) ;
         this.AV13RestMessage = "" ;
         this.Gx_restcode = 0 ;
         SubmitImpl();
         aP2_SDTGoogleDriveApiResponse=this.AV15SDTGoogleDriveApiResponse;
         aP3_RestMessage=this.AV13RestMessage;
         aP4_Gx_restcode=this.Gx_restcode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12ProfesionalesId)) || String.IsNullOrEmpty(StringUtil.RTrim( AV18User)) )
         {
            AV13RestMessage = context.GetMessage( "Error al procesar la solicitud", "");
            Gx_restcode = 400;
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.otokenfromcookie(context ).execute(  AV10HttpRequest, out  AV17TokenId) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17TokenId)) )
         {
            Gx_restcode = 401;
            AV13RestMessage = "Token faltante";
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.validaracceso(context ).execute(  AV18User,  AV12ProfesionalesId,  AV17TokenId, out  AV8EsValido, out  AV16TokenDesencriptado) ;
         if ( ! AV8EsValido )
         {
            Gx_restcode = 401;
            AV13RestMessage = context.GetMessage( "No autorizado o token inválido.", "");
            cleanup();
            if (true) return;
         }
         AV9File = new GxFile(context.GetPhysicalPath());
         AV9File.Source = "C:\\certificados\\Certificate.json";
         if ( ! AV9File.Exists() )
         {
            AV11JsonText = "Archivo no encontrado";
         }
         else
         {
            AV11JsonText = AV9File.ReadAllText("");
            AV14SDTGoogleDrive.FromJSonString(AV11JsonText, null);
         }
         AV15SDTGoogleDriveApiResponse = new GeneXus.Programs.apis.SdtSDTGoogleDriveApiResponse(context);
         AV15SDTGoogleDriveApiResponse.gxTpr_Client_email = AV14SDTGoogleDrive.gxTpr_Client_email;
         AV15SDTGoogleDriveApiResponse.gxTpr_Private_key = AV14SDTGoogleDrive.gxTpr_Private_key;
         GXt_char1 = AV15SDTGoogleDriveApiResponse.gxTpr_Scope;
         new GeneXus.Programs.apis.oparametro(context ).execute(  context.GetMessage( "GDRIVESCOPE", ""), out  GXt_char1) ;
         AV15SDTGoogleDriveApiResponse.gxTpr_Scope = GXt_char1;
         GXt_char2 = AV15SDTGoogleDriveApiResponse.gxTpr_Aud;
         new GeneXus.Programs.apis.oparametro(context ).execute(  context.GetMessage( "GDRIVEAUD", ""), out  GXt_char2) ;
         AV15SDTGoogleDriveApiResponse.gxTpr_Aud = GXt_char2;
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
         AV15SDTGoogleDriveApiResponse = new GeneXus.Programs.apis.SdtSDTGoogleDriveApiResponse(context);
         AV13RestMessage = "";
         AV10HttpRequest = new GxHttpRequest( context);
         AV17TokenId = "";
         AV16TokenDesencriptado = "";
         AV9File = new GxFile(context.GetPhysicalPath());
         AV11JsonText = "";
         AV14SDTGoogleDrive = new GeneXus.Programs.apis.SdtSDTGoogleDrive(context);
         GXt_char1 = "";
         GXt_char2 = "";
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private string AV18User ;
      private string AV12ProfesionalesId ;
      private string AV17TokenId ;
      private string AV16TokenDesencriptado ;
      private string GXt_char1 ;
      private string GXt_char2 ;
      private bool AV8EsValido ;
      private string AV11JsonText ;
      private string AV13RestMessage ;
      private GxHttpRequest AV10HttpRequest ;
      private GxFile AV9File ;
      private GeneXus.Programs.apis.SdtSDTGoogleDriveApiResponse AV15SDTGoogleDriveApiResponse ;
      private GeneXus.Programs.apis.SdtSDTGoogleDrive AV14SDTGoogleDrive ;
      private GeneXus.Programs.apis.SdtSDTGoogleDriveApiResponse aP2_SDTGoogleDriveApiResponse ;
      private string aP3_RestMessage ;
      private short aP4_Gx_restcode ;
   }

}
