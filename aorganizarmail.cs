using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Mail;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class aorganizarmail : GXProcedure
   {
      public aorganizarmail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aorganizarmail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_MailDesignId ,
                           string aP1_MailDesignTipo ,
                           string aP2_Email ,
                           ref string aP3_Nombre ,
                           string aP4_UrlAdjunto ,
                           ref string aP5_HTMLText ,
                           out string aP6_Ok ,
                           out string aP7_ErrorDescription )
      {
         this.AV16MailDesignId = aP0_MailDesignId;
         this.AV17MailDesignTipo = aP1_MailDesignTipo;
         this.AV27Email = aP2_Email;
         this.AV28Nombre = aP3_Nombre;
         this.AV39UrlAdjunto = aP4_UrlAdjunto;
         this.AV30HTMLText = aP5_HTMLText;
         this.AV29Ok = "" ;
         this.AV11ErrorDescription = "" ;
         initialize();
         ExecutePrivate();
         aP3_Nombre=this.AV28Nombre;
         aP5_HTMLText=this.AV30HTMLText;
         aP6_Ok=this.AV29Ok;
         aP7_ErrorDescription=this.AV11ErrorDescription;
      }

      public string executeUdp( short aP0_MailDesignId ,
                                string aP1_MailDesignTipo ,
                                string aP2_Email ,
                                ref string aP3_Nombre ,
                                string aP4_UrlAdjunto ,
                                ref string aP5_HTMLText ,
                                out string aP6_Ok )
      {
         execute(aP0_MailDesignId, aP1_MailDesignTipo, aP2_Email, ref aP3_Nombre, aP4_UrlAdjunto, ref aP5_HTMLText, out aP6_Ok, out aP7_ErrorDescription);
         return AV11ErrorDescription ;
      }

      public void executeSubmit( short aP0_MailDesignId ,
                                 string aP1_MailDesignTipo ,
                                 string aP2_Email ,
                                 ref string aP3_Nombre ,
                                 string aP4_UrlAdjunto ,
                                 ref string aP5_HTMLText ,
                                 out string aP6_Ok ,
                                 out string aP7_ErrorDescription )
      {
         this.AV16MailDesignId = aP0_MailDesignId;
         this.AV17MailDesignTipo = aP1_MailDesignTipo;
         this.AV27Email = aP2_Email;
         this.AV28Nombre = aP3_Nombre;
         this.AV39UrlAdjunto = aP4_UrlAdjunto;
         this.AV30HTMLText = aP5_HTMLText;
         this.AV29Ok = "" ;
         this.AV11ErrorDescription = "" ;
         SubmitImpl();
         aP3_Nombre=this.AV28Nombre;
         aP5_HTMLText=this.AV30HTMLText;
         aP6_Ok=this.AV29Ok;
         aP7_ErrorDescription=this.AV11ErrorDescription;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         context.StatusMessage( context.GetMessage( "Configurando cuentas a las que se envía...", "") );
         AV29Ok = context.GetMessage( "N", "");
         context.StatusMessage( context.GetMessage( "Generando e-mail común...", "") );
         AV10ErrorCode = 99;
         AV32MensajeDesing = context.GetMessage( "S", "");
         /* Using cursor P00932 */
         pr_default.execute(0, new Object[] {AV16MailDesignId, AV17MailDesignTipo});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A245MailDesignEstado = P00932_A245MailDesignEstado[0];
            A244MailDesignTipo = P00932_A244MailDesignTipo[0];
            A148MailDesignId = P00932_A148MailDesignId[0];
            A246MailDesignAsunto = P00932_A246MailDesignAsunto[0];
            A251MailDesignCabezal = P00932_A251MailDesignCabezal[0];
            A250MailDesignMensaje = P00932_A250MailDesignMensaje[0];
            A252MailDesignFirma = P00932_A252MailDesignFirma[0];
            A149MailId = P00932_A149MailId[0];
            if ( StringUtil.StrCmp(A245MailDesignEstado, context.GetMessage( "HAB", "")) == 0 )
            {
               AV41Asunto = A246MailDesignAsunto;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27Email)) && ( StringUtil.StrCmp(AV17MailDesignTipo, context.GetMessage( "R", "")) == 0 ) )
               {
                  AV32MensajeDesing = context.GetMessage( "N", "");
                  /* Execute user subroutine: 'RECUPERA CUENTA' */
                  S121 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     cleanup();
                     if (true) return;
                  }
               }
               else if ( ( StringUtil.StrCmp(AV17MailDesignTipo, context.GetMessage( "N", "")) == 0 ) && ( AV16MailDesignId == 2 ) )
               {
                  AV29Ok = context.GetMessage( "S", "");
                  AV32MensajeDesing = context.GetMessage( "N", "");
                  AV19MailRecipient.Address = StringUtil.Trim( AV27Email);
                  AV19MailRecipient.Name = context.GetMessage( "Hola: ", "")+StringUtil.Trim( AV28Nombre);
                  AV18MailMessage.To.Add(AV19MailRecipient);
               }
               else if ( ( StringUtil.StrCmp(AV17MailDesignTipo, context.GetMessage( "N", "")) == 0 ) && ( AV16MailDesignId == 6 ) )
               {
                  AV29Ok = context.GetMessage( "S", "");
                  AV32MensajeDesing = context.GetMessage( "N", "");
                  AV19MailRecipient.Address = StringUtil.Trim( AV27Email);
                  AV19MailRecipient.Name = context.GetMessage( "Hola: ", "")+StringUtil.Trim( AV28Nombre);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39UrlAdjunto)) )
                  {
                     AV18MailMessage.Attachments.Add(StringUtil.Trim( AV39UrlAdjunto));
                  }
                  AV18MailMessage.To.Add(AV19MailRecipient);
               }
               else if ( ( StringUtil.StrCmp(AV17MailDesignTipo, context.GetMessage( "N", "")) == 0 ) && ( AV16MailDesignId == 7 ) )
               {
                  AV29Ok = context.GetMessage( "S", "");
                  AV32MensajeDesing = context.GetMessage( "N", "");
                  AV27Email = context.GetMessage( "info@almango.com.uy", "");
                  AV19MailRecipient.Address = StringUtil.Trim( AV27Email);
                  AV19MailRecipient.Name = context.GetMessage( "Cliente: ", "")+StringUtil.Trim( AV28Nombre);
                  AV18MailMessage.To.Add(AV19MailRecipient);
               }
               else if ( ( StringUtil.StrCmp(AV17MailDesignTipo, context.GetMessage( "N", "")) == 0 ) && ( AV16MailDesignId == 8 ) )
               {
                  AV29Ok = context.GetMessage( "S", "");
                  AV32MensajeDesing = context.GetMessage( "N", "");
                  AV19MailRecipient.Address = StringUtil.Trim( AV27Email);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28Nombre)) )
                  {
                     AV41Asunto += " | " + StringUtil.Trim( AV28Nombre);
                  }
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39UrlAdjunto)) )
                  {
                     AV43RutaBase = "C:\\Certificados\\CondicionesServicios\\";
                     AV44ListaArchivos = (GxSimpleCollection<string>)(GxRegex.Split(AV39UrlAdjunto,";"));
                     AV53GXV1 = 1;
                     while ( AV53GXV1 <= AV44ListaArchivos.Count )
                     {
                        AV45NombreArchivo = ((string)AV44ListaArchivos.Item(AV53GXV1));
                        AV45NombreArchivo = StringUtil.Trim( AV45NombreArchivo);
                        if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45NombreArchivo)) )
                        {
                           AV46FullPath = AV43RutaBase + AV45NombreArchivo;
                           AV47File.Source = AV46FullPath;
                           if ( AV47File.Exists() )
                           {
                              AV18MailMessage.Attachments.Add(AV47File.GetAbsoluteName());
                           }
                        }
                        AV53GXV1 = (int)(AV53GXV1+1);
                     }
                  }
                  AV18MailMessage.To.Add(AV19MailRecipient);
               }
               else if ( ( StringUtil.StrCmp(AV17MailDesignTipo, context.GetMessage( "N", "")) == 0 ) && ( AV16MailDesignId == 9 ) )
               {
                  AV29Ok = context.GetMessage( "S", "");
                  AV32MensajeDesing = context.GetMessage( "N", "");
                  AV19MailRecipient.Address = StringUtil.Trim( AV27Email);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39UrlAdjunto)) )
                  {
                     AV18MailMessage.Attachments.Add(StringUtil.Trim( AV39UrlAdjunto));
                  }
                  AV18MailMessage.To.Add(AV19MailRecipient);
               }
               else if ( ( StringUtil.StrCmp(AV17MailDesignTipo, context.GetMessage( "N", "")) == 0 ) && ( AV16MailDesignId == 10 ) )
               {
                  AV29Ok = context.GetMessage( "S", "");
                  AV32MensajeDesing = context.GetMessage( "N", "");
                  AV19MailRecipient.Address = StringUtil.Trim( AV27Email);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39UrlAdjunto)) )
                  {
                     AV18MailMessage.Attachments.Add(StringUtil.Trim( AV39UrlAdjunto));
                  }
                  AV18MailMessage.To.Add(AV19MailRecipient);
               }
               else if ( ( StringUtil.StrCmp(AV17MailDesignTipo, context.GetMessage( "N", "")) == 0 ) && ( AV16MailDesignId == 11 ) )
               {
                  AV29Ok = context.GetMessage( "S", "");
                  AV32MensajeDesing = context.GetMessage( "N", "");
                  AV19MailRecipient.Address = StringUtil.Trim( AV27Email);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39UrlAdjunto)) )
                  {
                     AV18MailMessage.Attachments.Add(StringUtil.Trim( AV39UrlAdjunto));
                  }
                  AV18MailMessage.To.Add(AV19MailRecipient);
               }
               else if ( ( StringUtil.StrCmp(AV17MailDesignTipo, context.GetMessage( "N", "")) == 0 ) && ( AV16MailDesignId == 12 ) )
               {
                  AV29Ok = context.GetMessage( "S", "");
                  AV32MensajeDesing = context.GetMessage( "N", "");
                  new GeneXus.Programs.apis.oparametro(context ).execute(  context.GetMessage( "ALERTA_FEEDBACK_CE", ""), out  AV49CorreosParaFeedbackInsuficiente) ;
                  AV48CorreosDestino = (GxSimpleCollection<string>)(GxRegex.Split(AV49CorreosParaFeedbackInsuficiente,";"));
                  AV54GXV2 = 1;
                  while ( AV54GXV2 <= AV48CorreosDestino.Count )
                  {
                     AV38Correo = ((string)AV48CorreosDestino.Item(AV54GXV2));
                     AV38Correo = StringUtil.Trim( AV38Correo);
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38Correo)) )
                     {
                        AV19MailRecipient = new GeneXus.Mail.GXMailRecipient();
                        AV19MailRecipient.Address = StringUtil.Trim( AV38Correo);
                        AV18MailMessage.To.Add(AV19MailRecipient);
                     }
                     AV54GXV2 = (int)(AV54GXV2+1);
                  }
               }
               else if ( ( StringUtil.StrCmp(AV17MailDesignTipo, context.GetMessage( "N", "")) == 0 ) && ( AV16MailDesignId == 13 ) )
               {
                  AV29Ok = context.GetMessage( "S", "");
                  AV32MensajeDesing = context.GetMessage( "N", "");
                  new GeneXus.Programs.apis.oparametro(context ).execute(  context.GetMessage( "CORREOS_NOTIF_ESPEC", ""), out  AV51CorreosNotificacion) ;
                  AV48CorreosDestino = (GxSimpleCollection<string>)(GxRegex.Split(AV51CorreosNotificacion,";"));
                  AV55GXV3 = 1;
                  while ( AV55GXV3 <= AV48CorreosDestino.Count )
                  {
                     AV38Correo = ((string)AV48CorreosDestino.Item(AV55GXV3));
                     AV38Correo = StringUtil.Trim( AV38Correo);
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38Correo)) )
                     {
                        AV19MailRecipient = new GeneXus.Mail.GXMailRecipient();
                        AV19MailRecipient.Address = StringUtil.Trim( AV38Correo);
                        AV19MailRecipient.Name = context.GetMessage( "Administración", "");
                        AV18MailMessage.To.Add(AV19MailRecipient);
                     }
                     AV55GXV3 = (int)(AV55GXV3+1);
                  }
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28Nombre)) )
                  {
                     AV41Asunto += " - " + StringUtil.Trim( AV28Nombre);
                  }
               }
               else
               {
                  AV29Ok = context.GetMessage( "S", "");
               }
               if ( StringUtil.StrCmp(AV29Ok, context.GetMessage( "S", "")) == 0 )
               {
                  AV18MailMessage.Subject = StringUtil.Trim( AV41Asunto);
                  AV50BodyHTML = context.GetMessage( "<!DOCTYPE html>", "") + StringUtil.NewLine( );
                  AV50BodyHTML += context.GetMessage( "<html lang=\"es\">", "") + StringUtil.NewLine( );
                  AV50BodyHTML += context.GetMessage( "<head>", "") + StringUtil.NewLine( );
                  AV50BodyHTML += context.GetMessage( "  <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />", "") + StringUtil.NewLine( );
                  AV50BodyHTML += context.GetMessage( "  <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />", "") + StringUtil.NewLine( );
                  AV50BodyHTML += context.GetMessage( "  <title>", "") + StringUtil.Trim( AV41Asunto) + context.GetMessage( "</title>", "") + StringUtil.NewLine( );
                  AV50BodyHTML += context.GetMessage( "</head>", "") + StringUtil.NewLine( );
                  AV50BodyHTML += context.GetMessage( "<body style=\"margin:0; padding:0; background-color:#f9f9f9; font-family:Arial, sans-serif;\">", "") + StringUtil.NewLine( );
                  AV50BodyHTML += StringUtil.Trim( A251MailDesignCabezal) + StringUtil.NewLine( );
                  AV50BodyHTML += context.GetMessage( "<br />", "") + StringUtil.NewLine( );
                  if ( StringUtil.StrCmp(AV32MensajeDesing, context.GetMessage( "S", "")) == 0 )
                  {
                     AV50BodyHTML += StringUtil.Trim( A250MailDesignMensaje) + StringUtil.NewLine( );
                  }
                  else
                  {
                     AV50BodyHTML += StringUtil.Trim( AV30HTMLText) + StringUtil.NewLine( );
                  }
                  AV50BodyHTML += context.GetMessage( "<br />", "") + StringUtil.NewLine( );
                  AV50BodyHTML += StringUtil.Trim( A252MailDesignFirma) + StringUtil.NewLine( );
                  AV50BodyHTML += context.GetMessage( "</body>", "") + StringUtil.NewLine( );
                  AV50BodyHTML += context.GetMessage( "</html>", "");
                  AV18MailMessage.HTMLText = AV50BodyHTML;
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV30HTMLText)) )
                  {
                     AV18MailMessage.Text = context.GetMessage( "Notificación de Almango. Por favor abra este correo en un cliente con soporte HTML.", "");
                  }
                  else
                  {
                     AV18MailMessage.Text = StringUtil.Trim( GxSearchUtils.HTMLClean( AV30HTMLText));
                  }
                  new posmtpsession(context ).execute( ref  A149MailId, ref  AV21SMTPSession) ;
               }
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Execute user subroutine: 'ENVIAR CORREO' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( AV10ErrorCode != 0 )
         {
            AV29Ok = context.GetMessage( "N", "");
         }
         else
         {
            AV29Ok = context.GetMessage( "S", "");
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'ENVIAR CORREO' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV29Ok, context.GetMessage( "S", "")) == 0 )
         {
            new enviarmail(context ).execute( ref  AV21SMTPSession, ref  AV18MailMessage, ref  AV10ErrorCode, ref  AV11ErrorDescription) ;
         }
      }

      protected void S121( )
      {
         /* 'RECUPERA CUENTA' Routine */
         returnInSub = false;
         AV29Ok = context.GetMessage( "N", "");
         /* Using cursor P00933 */
         pr_default.execute(1, new Object[] {AV27Email});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A224usuariosCorreo = P00933_A224usuariosCorreo[0];
            A223usuariosPasw = P00933_A223usuariosPasw[0];
            A145usuariosId = P00933_A145usuariosId[0];
            A222usuariosNombre = P00933_A222usuariosNombre[0];
            GXt_char1 = AV36usuariosPasw;
            new pdesencripta(context ).execute( ref  A223usuariosPasw, ref  GXt_char1) ;
            AV36usuariosPasw = GXt_char1;
            AV37usuariosId = StringUtil.Trim( A145usuariosId);
            AV28Nombre = A222usuariosNombre;
            AV29Ok = context.GetMessage( "S", "");
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(1);
         }
         pr_default.close(1);
         if ( StringUtil.StrCmp(AV29Ok, context.GetMessage( "S", "")) == 0 )
         {
            AV19MailRecipient.Name = context.GetMessage( "Hola: ", "")+StringUtil.Trim( AV28Nombre);
            AV19MailRecipient.Address = StringUtil.Trim( AV27Email);
            AV18MailMessage.To.Add(AV19MailRecipient);
            AV30HTMLText += context.GetMessage( "<style type=\"text/css\">.Estilo2 {font-family: \"Courier New\", Courier, monospace}</style>", "");
            AV30HTMLText += context.GetMessage( "<table width=\"487\" height=\"86\" border=\"0\" cellpadding=\"2\" cellspacing=\"0\" bordercolor=\"#CCCCCC\"><tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr><tr><td>&nbsp;</td><td>", "");
            AV30HTMLText += context.GetMessage( "<div align=\"center\">", "");
            AV30HTMLText += context.GetMessage( "<p class=\"Estilo1 Estilo2\">Su usuario registrado es: <span class=\"Estilo2\">", "") + StringUtil.Trim( AV37usuariosId) + context.GetMessage( "</span> <br> Contraseña: <span class=\"Estilo2\">", "") + StringUtil.Trim( AV36usuariosPasw) + context.GetMessage( "</span> </p>", "");
            AV30HTMLText += context.GetMessage( "</div></td><td>&nbsp;</td></tr><tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr><tr><td>&nbsp;</td><td bgcolor=\"#FFFFFF\">&nbsp;</td><td>&nbsp;</td></tr><tr><td>&nbsp;</td><td bgcolor=\"#FFFFFF\">&nbsp;</td><td>&nbsp;</td> </tr></table>", "");
         }
         else
         {
            AV11ErrorDescription = context.GetMessage( "Mail no encontrado", "");
         }
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
         AV29Ok = "";
         AV11ErrorDescription = "";
         AV32MensajeDesing = "";
         P00932_A245MailDesignEstado = new string[] {""} ;
         P00932_A244MailDesignTipo = new string[] {""} ;
         P00932_A148MailDesignId = new long[1] ;
         P00932_A246MailDesignAsunto = new string[] {""} ;
         P00932_A251MailDesignCabezal = new string[] {""} ;
         P00932_A250MailDesignMensaje = new string[] {""} ;
         P00932_A252MailDesignFirma = new string[] {""} ;
         P00932_A149MailId = new long[1] ;
         A245MailDesignEstado = "";
         A244MailDesignTipo = "";
         A246MailDesignAsunto = "";
         A251MailDesignCabezal = "";
         A250MailDesignMensaje = "";
         A252MailDesignFirma = "";
         AV41Asunto = "";
         AV19MailRecipient = new GeneXus.Mail.GXMailRecipient();
         AV18MailMessage = new GeneXus.Mail.GXMailMessage();
         AV43RutaBase = "";
         AV44ListaArchivos = new GxSimpleCollection<string>();
         AV45NombreArchivo = "";
         AV46FullPath = "";
         AV47File = new GxFile(context.GetPhysicalPath());
         AV49CorreosParaFeedbackInsuficiente = "";
         AV48CorreosDestino = new GxSimpleCollection<string>();
         AV38Correo = "";
         AV51CorreosNotificacion = "";
         AV50BodyHTML = "";
         AV21SMTPSession = new GeneXus.Mail.GXSMTPSession(context.GetPhysicalPath());
         P00933_A224usuariosCorreo = new string[] {""} ;
         P00933_A223usuariosPasw = new string[] {""} ;
         P00933_A145usuariosId = new string[] {""} ;
         P00933_A222usuariosNombre = new string[] {""} ;
         A224usuariosCorreo = "";
         A223usuariosPasw = "";
         A145usuariosId = "";
         A222usuariosNombre = "";
         AV36usuariosPasw = "";
         GXt_char1 = "";
         AV37usuariosId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aorganizarmail__default(),
            new Object[][] {
                new Object[] {
               P00932_A245MailDesignEstado, P00932_A244MailDesignTipo, P00932_A148MailDesignId, P00932_A246MailDesignAsunto, P00932_A251MailDesignCabezal, P00932_A250MailDesignMensaje, P00932_A252MailDesignFirma, P00932_A149MailId
               }
               , new Object[] {
               P00933_A224usuariosCorreo, P00933_A223usuariosPasw, P00933_A145usuariosId, P00933_A222usuariosNombre
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV16MailDesignId ;
      private short AV10ErrorCode ;
      private int AV53GXV1 ;
      private int AV54GXV2 ;
      private int AV55GXV3 ;
      private long A148MailDesignId ;
      private long A149MailId ;
      private string AV17MailDesignTipo ;
      private string AV28Nombre ;
      private string AV39UrlAdjunto ;
      private string AV30HTMLText ;
      private string AV29Ok ;
      private string AV11ErrorDescription ;
      private string AV32MensajeDesing ;
      private string A245MailDesignEstado ;
      private string A244MailDesignTipo ;
      private string A246MailDesignAsunto ;
      private string AV41Asunto ;
      private string A223usuariosPasw ;
      private string A145usuariosId ;
      private string A222usuariosNombre ;
      private string AV36usuariosPasw ;
      private string GXt_char1 ;
      private string AV37usuariosId ;
      private bool returnInSub ;
      private string A251MailDesignCabezal ;
      private string A250MailDesignMensaje ;
      private string A252MailDesignFirma ;
      private string AV50BodyHTML ;
      private string AV27Email ;
      private string AV43RutaBase ;
      private string AV45NombreArchivo ;
      private string AV46FullPath ;
      private string AV49CorreosParaFeedbackInsuficiente ;
      private string AV38Correo ;
      private string AV51CorreosNotificacion ;
      private string A224usuariosCorreo ;
      private GeneXus.Mail.GXMailMessage AV18MailMessage ;
      private GeneXus.Mail.GXMailRecipient AV19MailRecipient ;
      private GeneXus.Mail.GXSMTPSession AV21SMTPSession ;
      private GxFile AV47File ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private string aP3_Nombre ;
      private string aP5_HTMLText ;
      private IDataStoreProvider pr_default ;
      private string[] P00932_A245MailDesignEstado ;
      private string[] P00932_A244MailDesignTipo ;
      private long[] P00932_A148MailDesignId ;
      private string[] P00932_A246MailDesignAsunto ;
      private string[] P00932_A251MailDesignCabezal ;
      private string[] P00932_A250MailDesignMensaje ;
      private string[] P00932_A252MailDesignFirma ;
      private long[] P00932_A149MailId ;
      private GxSimpleCollection<string> AV44ListaArchivos ;
      private GxSimpleCollection<string> AV48CorreosDestino ;
      private string[] P00933_A224usuariosCorreo ;
      private string[] P00933_A223usuariosPasw ;
      private string[] P00933_A145usuariosId ;
      private string[] P00933_A222usuariosNombre ;
      private string aP6_Ok ;
      private string aP7_ErrorDescription ;
   }

   public class aorganizarmail__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00932;
          prmP00932 = new Object[] {
          new ParDef("@AV16MailDesignId",GXType.Int16,4,0) ,
          new ParDef("@AV17MailDesignTipo",GXType.NChar,1,0)
          };
          Object[] prmP00933;
          prmP00933 = new Object[] {
          new ParDef("@AV27Email",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00932", "SELECT [MailDesignEstado], [MailDesignTipo], [MailDesignId], [MailDesignAsunto], [MailDesignCabezal], [MailDesignMensaje], [MailDesignFirma], [MailId] FROM [MailDesign] WHERE ([MailDesignId] = @AV16MailDesignId) AND ([MailDesignTipo] = @AV17MailDesignTipo) ORDER BY [MailDesignId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00932,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00933", "SELECT TOP 1 [usuariosCorreo], [usuariosPasw], [usuariosId], [usuariosNombre] FROM [usuarios] WHERE RTRIM(LTRIM(UPPER([usuariosCorreo]))) = RTRIM(LTRIM(UPPER(@AV27Email))) ORDER BY [usuariosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00933,1, GxCacheFrequency.OFF ,true,true )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 80);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 80);
                return;
       }
    }

 }

}
