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
namespace GeneXus.Programs.apis {
   public class validaracceso : GXProcedure
   {
      public validaracceso( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public validaracceso( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_UsuariosId ,
                           string aP1_profesionalesId ,
                           string aP2_TokenId ,
                           out bool aP3_EsValido ,
                           out string aP4_TokenDesencriptado )
      {
         this.AV8UsuariosId = aP0_UsuariosId;
         this.AV21profesionalesId = aP1_profesionalesId;
         this.AV9TokenId = aP2_TokenId;
         this.AV10EsValido = false ;
         this.AV11TokenDesencriptado = "" ;
         initialize();
         ExecutePrivate();
         aP3_EsValido=this.AV10EsValido;
         aP4_TokenDesencriptado=this.AV11TokenDesencriptado;
      }

      public string executeUdp( string aP0_UsuariosId ,
                                string aP1_profesionalesId ,
                                string aP2_TokenId ,
                                out bool aP3_EsValido )
      {
         execute(aP0_UsuariosId, aP1_profesionalesId, aP2_TokenId, out aP3_EsValido, out aP4_TokenDesencriptado);
         return AV11TokenDesencriptado ;
      }

      public void executeSubmit( string aP0_UsuariosId ,
                                 string aP1_profesionalesId ,
                                 string aP2_TokenId ,
                                 out bool aP3_EsValido ,
                                 out string aP4_TokenDesencriptado )
      {
         this.AV8UsuariosId = aP0_UsuariosId;
         this.AV21profesionalesId = aP1_profesionalesId;
         this.AV9TokenId = aP2_TokenId;
         this.AV10EsValido = false ;
         this.AV11TokenDesencriptado = "" ;
         SubmitImpl();
         aP3_EsValido=this.AV10EsValido;
         aP4_TokenDesencriptado=this.AV11TokenDesencriptado;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV21profesionalesId)) || String.IsNullOrEmpty(StringUtil.RTrim( AV8UsuariosId)) || String.IsNullOrEmpty(StringUtil.RTrim( AV9TokenId)) )
         {
            AV10EsValido = false;
            cleanup();
            if (true) return;
         }
         AV10EsValido = false;
         AV18TokenIdAux = StringUtil.Trim( AV9TokenId);
         GXt_char1 = AV11TokenDesencriptado;
         new pdesencripta(context ).execute( ref  AV18TokenIdAux, ref  GXt_char1) ;
         AV11TokenDesencriptado = GXt_char1;
         AV12PosSeparador = (short)(StringUtil.StringSearch( AV11TokenDesencriptado, "|", 1));
         if ( AV12PosSeparador > 0 )
         {
            AV13UsuarioEnToken = StringUtil.Substring( AV11TokenDesencriptado, 1, AV12PosSeparador-1);
            if ( StringUtil.StrCmp(StringUtil.Trim( AV13UsuarioEnToken), StringUtil.Trim( AV8UsuariosId)) == 0 )
            {
               new GeneXus.Programs.apis.oprofesionalid(context ).execute(  AV13UsuarioEnToken, out  AV22ProfIdEnBD) ;
               if ( StringUtil.StrCmp(StringUtil.Trim( AV22ProfIdEnBD), StringUtil.Trim( AV21profesionalesId)) == 0 )
               {
                  AV14TipoUS = "U";
                  AV15SecUserName = "";
                  new oexisteuser(context ).execute(  AV13UsuarioEnToken,  AV15SecUserName,  AV14TipoUS, out  AV16ok) ;
                  if ( StringUtil.StrCmp(AV16ok, context.GetMessage( "S", "")) == 0 )
                  {
                     new GeneXus.Programs.apis.validartoken(context ).execute(  AV9TokenId, out  AV17TokenValido) ;
                     if ( AV17TokenValido )
                     {
                        AV10EsValido = true;
                     }
                  }
               }
            }
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
         AV11TokenDesencriptado = "";
         AV18TokenIdAux = "";
         GXt_char1 = "";
         AV13UsuarioEnToken = "";
         AV22ProfIdEnBD = "";
         AV14TipoUS = "";
         AV15SecUserName = "";
         AV16ok = "";
         /* GeneXus formulas. */
      }

      private short AV12PosSeparador ;
      private string AV8UsuariosId ;
      private string AV21profesionalesId ;
      private string AV9TokenId ;
      private string AV18TokenIdAux ;
      private string GXt_char1 ;
      private string AV13UsuarioEnToken ;
      private string AV22ProfIdEnBD ;
      private string AV14TipoUS ;
      private string AV16ok ;
      private bool AV10EsValido ;
      private bool AV17TokenValido ;
      private string AV11TokenDesencriptado ;
      private string AV15SecUserName ;
      private bool aP3_EsValido ;
      private string aP4_TokenDesencriptado ;
   }

}
