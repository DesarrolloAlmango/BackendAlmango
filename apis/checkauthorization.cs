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
   public class checkauthorization : GXProcedure
   {
      public checkauthorization( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public checkauthorization( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GxHttpRequest aP0_HttpRequest ,
                           string aP1_usuariosId ,
                           string aP2_ProfesionalesId ,
                           out string aP3_TokenId ,
                           out bool aP4_IsOk ,
                           out short aP5_Gx_restcode ,
                           out string aP6_RestMessage )
      {
         this.AV9HttpRequest = aP0_HttpRequest;
         this.AV18usuariosId = aP1_usuariosId;
         this.AV19ProfesionalesId = aP2_ProfesionalesId;
         this.AV11TokenId = "" ;
         this.AV8IsOk = false ;
         this.Gx_restcode = 0 ;
         this.AV15RestMessage = "" ;
         initialize();
         ExecutePrivate();
         aP3_TokenId=this.AV11TokenId;
         aP4_IsOk=this.AV8IsOk;
         aP5_Gx_restcode=this.Gx_restcode;
         aP6_RestMessage=this.AV15RestMessage;
      }

      public string executeUdp( GxHttpRequest aP0_HttpRequest ,
                                string aP1_usuariosId ,
                                string aP2_ProfesionalesId ,
                                out string aP3_TokenId ,
                                out bool aP4_IsOk ,
                                out short aP5_Gx_restcode )
      {
         execute(aP0_HttpRequest, aP1_usuariosId, aP2_ProfesionalesId, out aP3_TokenId, out aP4_IsOk, out aP5_Gx_restcode, out aP6_RestMessage);
         return AV15RestMessage ;
      }

      public void executeSubmit( GxHttpRequest aP0_HttpRequest ,
                                 string aP1_usuariosId ,
                                 string aP2_ProfesionalesId ,
                                 out string aP3_TokenId ,
                                 out bool aP4_IsOk ,
                                 out short aP5_Gx_restcode ,
                                 out string aP6_RestMessage )
      {
         this.AV9HttpRequest = aP0_HttpRequest;
         this.AV18usuariosId = aP1_usuariosId;
         this.AV19ProfesionalesId = aP2_ProfesionalesId;
         this.AV11TokenId = "" ;
         this.AV8IsOk = false ;
         this.Gx_restcode = 0 ;
         this.AV15RestMessage = "" ;
         SubmitImpl();
         aP3_TokenId=this.AV11TokenId;
         aP4_IsOk=this.AV8IsOk;
         aP5_Gx_restcode=this.Gx_restcode;
         aP6_RestMessage=this.AV15RestMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8IsOk = true;
         AV11TokenId = "";
         Gx_restcode = 200;
         AV15RestMessage = "";
         AV12Prefix = context.GetMessage( "Bearer ", "");
         AV13Header = AV9HttpRequest.GetHeader(context.GetMessage( "Authorization", ""));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13Header)) )
         {
            AV8IsOk = false;
            Gx_restcode = 401;
            AV15RestMessage = context.GetMessage( "No se encontró el encabezado Authorization.", "");
            cleanup();
            if (true) return;
         }
         AV14Pos = (short)(StringUtil.StringSearch( AV13Header, AV12Prefix, 1));
         if ( AV14Pos > 0 )
         {
            AV11TokenId = StringUtil.Trim( StringUtil.Substring( AV13Header, AV14Pos+StringUtil.Len( AV12Prefix), StringUtil.Len( AV13Header)));
         }
         else
         {
            AV11TokenId = StringUtil.Trim( AV13Header);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11TokenId)) )
         {
            AV8IsOk = false;
            Gx_restcode = 401;
            AV15RestMessage = context.GetMessage( "Token vacío o inválido.", "");
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.validaracceso(context ).execute(  AV18usuariosId,  AV19ProfesionalesId,  AV11TokenId, out  AV17EsValido, out  AV16TokenDesencriptado) ;
         if ( ! AV17EsValido )
         {
            AV8IsOk = false;
            Gx_restcode = 401;
            AV15RestMessage = context.GetMessage( "No autorizado o token inválido.", "");
            cleanup();
            if (true) return;
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
         AV11TokenId = "";
         AV15RestMessage = "";
         AV12Prefix = "";
         AV13Header = "";
         AV16TokenDesencriptado = "";
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private short AV14Pos ;
      private string AV18usuariosId ;
      private string AV19ProfesionalesId ;
      private string AV11TokenId ;
      private string AV16TokenDesencriptado ;
      private bool AV8IsOk ;
      private bool AV17EsValido ;
      private string AV15RestMessage ;
      private string AV12Prefix ;
      private string AV13Header ;
      private GxHttpRequest AV9HttpRequest ;
      private string aP3_TokenId ;
      private bool aP4_IsOk ;
      private short aP5_Gx_restcode ;
      private string aP6_RestMessage ;
   }

}
