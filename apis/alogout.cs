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
   public class alogout : GXProcedure
   {
      public alogout( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public alogout( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_UsuariosId ,
                           string aP1_ProfesionalesId ,
                           out string aP2_RestMessage ,
                           out short aP3_Gx_restcode )
      {
         this.AV8UsuariosId = aP0_UsuariosId;
         this.AV9ProfesionalesId = aP1_ProfesionalesId;
         this.AV10RestMessage = "" ;
         this.Gx_restcode = 0 ;
         initialize();
         ExecutePrivate();
         aP2_RestMessage=this.AV10RestMessage;
         aP3_Gx_restcode=this.Gx_restcode;
      }

      public short executeUdp( string aP0_UsuariosId ,
                               string aP1_ProfesionalesId ,
                               out string aP2_RestMessage )
      {
         execute(aP0_UsuariosId, aP1_ProfesionalesId, out aP2_RestMessage, out aP3_Gx_restcode);
         return Gx_restcode ;
      }

      public void executeSubmit( string aP0_UsuariosId ,
                                 string aP1_ProfesionalesId ,
                                 out string aP2_RestMessage ,
                                 out short aP3_Gx_restcode )
      {
         this.AV8UsuariosId = aP0_UsuariosId;
         this.AV9ProfesionalesId = aP1_ProfesionalesId;
         this.AV10RestMessage = "" ;
         this.Gx_restcode = 0 ;
         SubmitImpl();
         aP2_RestMessage=this.AV10RestMessage;
         aP3_Gx_restcode=this.Gx_restcode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8UsuariosId)) || String.IsNullOrEmpty(StringUtil.RTrim( AV9ProfesionalesId)) )
         {
            Gx_restcode = 400;
            AV10RestMessage = context.GetMessage( "Error de parámetros al procesar la solicitud", "");
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.otokenfromcookie(context ).execute(  AV12HttpRequest, out  AV15TokenId) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15TokenId)) )
         {
            Gx_restcode = 401;
            AV10RestMessage = context.GetMessage( "No autorizado", "");
            cleanup();
            if (true) return;
         }
         AV18TokenIdAux = StringUtil.Trim( AV15TokenId);
         GXt_char1 = AV17TokenDesencriptado;
         new pdesencripta(context ).execute( ref  AV18TokenIdAux, ref  GXt_char1) ;
         AV17TokenDesencriptado = GXt_char1;
         AV16PosSeparador = (short)(StringUtil.StringSearch( AV17TokenDesencriptado, "|", 1));
         if ( AV16PosSeparador > 0 )
         {
            AV19UsuarioEnToken = StringUtil.Substring( AV17TokenDesencriptado, 1, AV16PosSeparador-1);
            if ( StringUtil.StrCmp(StringUtil.Trim( AV19UsuarioEnToken), StringUtil.Trim( AV8UsuariosId)) != 0 )
            {
               Gx_restcode = 401;
               AV10RestMessage = context.GetMessage( "No autorizado", "");
               cleanup();
               if (true) return;
            }
         }
         new GeneXus.Programs.apis.eusertoken(context ).execute(  StringUtil.Trim( AV19UsuarioEnToken), out  AV11ok) ;
         if ( AV11ok )
         {
            AV13CookieName = "TokenId";
            if ( ! context.isAjaxRequest( ) )
            {
               AV14HttpResponse.AppendHeader(context.GetMessage( "Set-Cookie", ""), AV13CookieName+context.GetMessage( "=; Max-Age=0; Path=/; HttpOnly; Secure; SameSite=None", ""));
            }
            AV10RestMessage = context.GetMessage( "Logout exitoso", "");
            Gx_restcode = 200;
         }
         else
         {
            AV10RestMessage = context.GetMessage( "Hubo un problema al procesar solicitud", "");
            Gx_restcode = 500;
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
         AV10RestMessage = "";
         AV12HttpRequest = new GxHttpRequest( context);
         AV15TokenId = "";
         AV18TokenIdAux = "";
         AV17TokenDesencriptado = "";
         GXt_char1 = "";
         AV19UsuarioEnToken = "";
         AV13CookieName = "";
         AV14HttpResponse = new GxHttpResponse( context);
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private short AV16PosSeparador ;
      private string AV8UsuariosId ;
      private string AV9ProfesionalesId ;
      private string AV15TokenId ;
      private string AV18TokenIdAux ;
      private string AV17TokenDesencriptado ;
      private string GXt_char1 ;
      private string AV19UsuarioEnToken ;
      private string AV13CookieName ;
      private bool AV11ok ;
      private string AV10RestMessage ;
      private GxHttpRequest AV12HttpRequest ;
      private GxHttpResponse AV14HttpResponse ;
      private string aP2_RestMessage ;
      private short aP3_Gx_restcode ;
   }

}
