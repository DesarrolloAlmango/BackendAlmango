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
   public class obtenerlogin : GXProcedure
   {
      public obtenerlogin( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenerlogin( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_usuario ,
                           string aP1_password ,
                           out string aP2_mensaje ,
                           out bool aP3_LogInSuccessful ,
                           out SdtSDTUser aP4_SdtUser ,
                           out string aP5_Auth )
      {
         this.AV29usuario = aP0_usuario;
         this.AV30password = aP1_password;
         this.AV21mensaje = "" ;
         this.AV27LogInSuccessful = false ;
         this.AV28SdtUser = new SdtSDTUser(context) ;
         this.AV33Auth = "" ;
         initialize();
         ExecutePrivate();
         aP2_mensaje=this.AV21mensaje;
         aP3_LogInSuccessful=this.AV27LogInSuccessful;
         aP4_SdtUser=this.AV28SdtUser;
         aP5_Auth=this.AV33Auth;
      }

      public string executeUdp( string aP0_usuario ,
                                string aP1_password ,
                                out string aP2_mensaje ,
                                out bool aP3_LogInSuccessful ,
                                out SdtSDTUser aP4_SdtUser )
      {
         execute(aP0_usuario, aP1_password, out aP2_mensaje, out aP3_LogInSuccessful, out aP4_SdtUser, out aP5_Auth);
         return AV33Auth ;
      }

      public void executeSubmit( string aP0_usuario ,
                                 string aP1_password ,
                                 out string aP2_mensaje ,
                                 out bool aP3_LogInSuccessful ,
                                 out SdtSDTUser aP4_SdtUser ,
                                 out string aP5_Auth )
      {
         this.AV29usuario = aP0_usuario;
         this.AV30password = aP1_password;
         this.AV21mensaje = "" ;
         this.AV27LogInSuccessful = false ;
         this.AV28SdtUser = new SdtSDTUser(context) ;
         this.AV33Auth = "" ;
         SubmitImpl();
         aP2_mensaje=this.AV21mensaje;
         aP3_LogInSuccessful=this.AV27LogInSuccessful;
         aP4_SdtUser=this.AV28SdtUser;
         aP5_Auth=this.AV33Auth;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV22ok = context.GetMessage( "N", "");
         AV21mensaje = context.GetMessage( "Credenciales incorrectas", "");
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV29usuario)) ) )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30password)) )
            {
               new GeneXus.Programs.apis.loginverificarprofesional(context ).execute(  AV29usuario,  AV30password, out  AV31ErrorDes, out  AV22ok, out  AV18usuariosNombre, out  AV23paisid, out  AV25tipoUsuario, out  AV24ProfesionalesId, out  AV13usuariosCorreo, out  AV15usuariosDireccion, out  AV14UsuariosCPostal, out  AV19UsuariosTelefono, out  AV17usuariosImagen, out  AV20UsuarioURL, out  AV16usuariosEstado) ;
            }
         }
         if ( StringUtil.StrCmp(AV22ok, context.GetMessage( "S", "")) != 0 )
         {
            AV27LogInSuccessful = false;
         }
         else
         {
            AV27LogInSuccessful = true;
            AV21mensaje = context.GetMessage( "Login correcto", "");
            AV28SdtUser = new SdtSDTUser(context);
            AV28SdtUser.gxTpr_Usuariosid = AV29usuario;
            GXt_boolean1 = AV28SdtUser.gxTpr_Usuariotienerubro;
            new GeneXus.Programs.apis.oproftienerubros(context ).execute(  AV24ProfesionalesId, out  GXt_boolean1) ;
            AV28SdtUser.gxTpr_Usuariotienerubro = GXt_boolean1;
            AV28SdtUser.gxTpr_Paisid = AV23paisid;
            AV28SdtUser.gxTpr_Profesionalesid = AV24ProfesionalesId;
            AV28SdtUser.gxTpr_Usuariosnombre = AV18usuariosNombre;
            AV28SdtUser.gxTpr_Tipousuario = AV25tipoUsuario;
            AV28SdtUser.gxTpr_Usuarioscorreo = AV13usuariosCorreo;
            AV28SdtUser.gxTpr_Usuariosdireccion = AV15usuariosDireccion;
            AV28SdtUser.gxTpr_Usuarioscpostal = AV14UsuariosCPostal;
            AV28SdtUser.gxTpr_Usuariostelefono = AV19UsuariosTelefono;
            AV28SdtUser.gxTpr_Usuariosimagen = AV17usuariosImagen;
            AV28SdtUser.gxTpr_Usuariosimagen_gxi = AV40Usuariosimagen_GXI;
            AV28SdtUser.gxTpr_Usuariosurl = AV20UsuarioURL;
            AV28SdtUser.gxTpr_Usuariosestado = AV16usuariosEstado;
            AV38EstadoAsignada = 2;
            new GeneXus.Programs.apis.onotificarpostulacion(context ).execute(  AV24ProfesionalesId,  AV38EstadoAsignada, out  AV39RequiereNotificacion) ;
            AV28SdtUser.gxTpr_Notificarpostulacion = AV39RequiereNotificacion;
            new GeneXus.Programs.apis.atoken(context ).execute(  AV29usuario, out  AV32Token) ;
            AV33Auth = AV32Token;
            if ( ! context.isAjaxRequest( ) )
            {
               AV37HttpResponse.AppendHeader(context.GetMessage( "Set-Cookie", ""), "TokenId="+StringUtil.Trim( AV33Auth)+context.GetMessage( "; HttpOnly; Secure; SameSite=None; Path=/", ""));
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
         AV21mensaje = "";
         AV28SdtUser = new SdtSDTUser(context);
         AV33Auth = "";
         AV22ok = "";
         AV31ErrorDes = "";
         AV18usuariosNombre = "";
         AV23paisid = "";
         AV25tipoUsuario = "";
         AV24ProfesionalesId = "";
         AV13usuariosCorreo = "";
         AV15usuariosDireccion = "";
         AV19UsuariosTelefono = "";
         AV17usuariosImagen = "";
         AV20UsuarioURL = "";
         AV16usuariosEstado = "";
         AV40Usuariosimagen_GXI = "";
         AV32Token = "";
         AV37HttpResponse = new GxHttpResponse( context);
         /* GeneXus formulas. */
      }

      private int AV14UsuariosCPostal ;
      private int AV38EstadoAsignada ;
      private string AV29usuario ;
      private string AV30password ;
      private string AV21mensaje ;
      private string AV33Auth ;
      private string AV22ok ;
      private string AV18usuariosNombre ;
      private string AV23paisid ;
      private string AV25tipoUsuario ;
      private string AV24ProfesionalesId ;
      private string AV19UsuariosTelefono ;
      private string AV16usuariosEstado ;
      private string AV32Token ;
      private bool AV27LogInSuccessful ;
      private bool GXt_boolean1 ;
      private bool AV39RequiereNotificacion ;
      private string AV31ErrorDes ;
      private string AV13usuariosCorreo ;
      private string AV15usuariosDireccion ;
      private string AV20UsuarioURL ;
      private string AV40Usuariosimagen_GXI ;
      private string AV17usuariosImagen ;
      private GxHttpResponse AV37HttpResponse ;
      private SdtSDTUser AV28SdtUser ;
      private string aP2_mensaje ;
      private bool aP3_LogInSuccessful ;
      private SdtSDTUser aP4_SdtUser ;
      private string aP5_Auth ;
   }

}
