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
namespace GeneXus.Programs.apis.comerciosapi.v1 {
   public class penviarcorreogenerico : GXProcedure
   {
      public penviarcorreogenerico( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public penviarcorreogenerico( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( long aP0_SolicitudId ,
                           string aP1_NombreCliente ,
                           string aP2_EmailCliente ,
                           string aP3_StringRutasCondiciones ,
                           out string aP4_Ok ,
                           out string aP5_ErrorDescription )
      {
         this.AV12SolicitudId = aP0_SolicitudId;
         this.AV10NombreCliente = aP1_NombreCliente;
         this.AV8EmailCliente = aP2_EmailCliente;
         this.AV13StringRutasCondiciones = aP3_StringRutasCondiciones;
         this.AV11Ok = "" ;
         this.AV9ErrorDescription = "" ;
         initialize();
         ExecutePrivate();
         aP4_Ok=this.AV11Ok;
         aP5_ErrorDescription=this.AV9ErrorDescription;
      }

      public string executeUdp( long aP0_SolicitudId ,
                                string aP1_NombreCliente ,
                                string aP2_EmailCliente ,
                                string aP3_StringRutasCondiciones ,
                                out string aP4_Ok )
      {
         execute(aP0_SolicitudId, aP1_NombreCliente, aP2_EmailCliente, aP3_StringRutasCondiciones, out aP4_Ok, out aP5_ErrorDescription);
         return AV9ErrorDescription ;
      }

      public void executeSubmit( long aP0_SolicitudId ,
                                 string aP1_NombreCliente ,
                                 string aP2_EmailCliente ,
                                 string aP3_StringRutasCondiciones ,
                                 out string aP4_Ok ,
                                 out string aP5_ErrorDescription )
      {
         this.AV12SolicitudId = aP0_SolicitudId;
         this.AV10NombreCliente = aP1_NombreCliente;
         this.AV8EmailCliente = aP2_EmailCliente;
         this.AV13StringRutasCondiciones = aP3_StringRutasCondiciones;
         this.AV11Ok = "" ;
         this.AV9ErrorDescription = "" ;
         SubmitImpl();
         aP4_Ok=this.AV11Ok;
         aP5_ErrorDescription=this.AV9ErrorDescription;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV21SolicitudBC.Load(AV12SolicitudId);
         AV15Codigo = context.GetMessage( "URLFORMECOMMERCE", "");
         new GeneXus.Programs.apis.oparametro(context ).execute(  AV15Codigo, out  AV23Valor) ;
         AV18LinkFormulario = StringUtil.Trim( AV23Valor) + StringUtil.Trim( StringUtil.Str( (decimal)(AV21SolicitudBC.gxTpr_Solicitudesid), 18, 0));
         AV16CodigoCondiciones = context.GetMessage( "URL_CONDICIONES_SERV", "");
         new GeneXus.Programs.apis.oparametro(context ).execute(  AV16CodigoCondiciones, out  AV24ValorCondiciones) ;
         AV14BaseUrlCondiciones = StringUtil.Trim( AV24ValorCondiciones);
         AV17HTMLText = "";
         AV17HTMLText += context.GetMessage( "<div class=\"u-row-container\" style=\"background-color:transparent; padding:0px\">", "");
         AV17HTMLText += context.GetMessage( "<div class=\"u-row\" style=\"background-color:#ffffff; margin: 0 auto; max-width:600px; min-width:320px; overflow-wrap:break-word;\">", "");
         AV17HTMLText += context.GetMessage( "<div style=\"padding: 30px 40px; font-family: Arial, sans-serif; font-size: 16px; line-height: 150%; text-align: left; color: #333333;\">", "");
         AV17HTMLText += context.GetMessage( "Hola <strong>", "") + StringUtil.Trim( AV10NombreCliente) + context.GetMessage( "</strong>,<br><br>", "");
         AV17HTMLText += context.GetMessage( "Tu solicitud de servicio fue registrada correctamente.<br>", "");
         AV17HTMLText += context.GetMessage( "Para avanzar con la coordinación, necesitamos que confirmes algunos datos para que podamos conectarte con profesionales disponibles en tu zona.<br><br>", "");
         AV17HTMLText += context.GetMessage( "<strong>¿Qué debés hacer?</strong><br><br>", "");
         AV17HTMLText += context.GetMessage( "<div style=\"margin-left: 20px;\">", "");
         AV17HTMLText += context.GetMessage( "<strong>1.</strong> Ingresá al formulario a través del link o botón abajo<br>", "");
         AV17HTMLText += context.GetMessage( "<strong>2.</strong> Confirmá la dirección del trabajo<br>", "");
         AV17HTMLText += context.GetMessage( "<strong>3.</strong> Indicanos la fecha en la que recibís el producto<br>", "");
         AV17HTMLText += context.GetMessage( "<strong>4.</strong> Elegí la fecha y turno que prefieras<br>", "");
         AV17HTMLText += context.GetMessage( "</div><br>", "");
         AV17HTMLText += context.GetMessage( "<em>El proceso demora menos de 1 minuto.</em>", "");
         AV17HTMLText += context.GetMessage( "<div style=\"margin-top: 25px; text-align: center;\">", "");
         AV17HTMLText += context.GetMessage( "<a href=\"", "") + StringUtil.Trim( AV18LinkFormulario) + context.GetMessage( "\" style=\"background-color: #008be1; color: #ffffff; padding: 15px 30px; text-decoration: none; border-radius: 4px; display: inline-block; font-weight: bold; font-size: 16px;\">", "");
         AV17HTMLText += context.GetMessage( "COMPLETAR DATOS AQUÍ", "");
         AV17HTMLText += context.GetMessage( "</a>", "");
         AV17HTMLText += context.GetMessage( "</div>", "");
         AV17HTMLText += context.GetMessage( "<p style=\"font-size: 12px; color: #7f8c8d; margin-top: 20px; text-align: center;\">O copia este link: ", "") + StringUtil.Trim( AV18LinkFormulario) + context.GetMessage( "</p>", "");
         AV17HTMLText += context.GetMessage( "<br><strong>&#9888; Importante</strong><br>", "");
         AV17HTMLText += context.GetMessage( "Una vez completes el formulario, te notificaremos cuando haya profesionales interesados en realizar el servicio.<br><br>", "");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13StringRutasCondiciones)) )
         {
            AV17HTMLText += context.GetMessage( "<div style=\"border-top: 1px solid #eeeeee; margin-top: 20px; padding-top: 15px;\">", "");
            AV17HTMLText += context.GetMessage( "<p style=\"font-size: 13px; color: #555555; line-height: 1.5;\">", "");
            AV17HTMLText += context.GetMessage( "&#128204; <strong>CONDICIONES DEL SERVICIO:</strong>", "");
            AV17HTMLText += context.GetMessage( "</p>", "");
            AV19ListaPdfs = (GxSimpleCollection<string>)(GxRegex.Split(AV13StringRutasCondiciones,";"));
            AV25GXV1 = 1;
            while ( AV25GXV1 <= AV19ListaPdfs.Count )
            {
               AV20PdfNombre = ((string)AV19ListaPdfs.Item(AV25GXV1));
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20PdfNombre)) )
               {
                  AV22UrlCompletaPdf = AV14BaseUrlCondiciones + StringUtil.Trim( AV20PdfNombre);
                  AV17HTMLText += context.GetMessage( "<a href=\"", "") + StringUtil.Trim( AV22UrlCompletaPdf) + context.GetMessage( "\" target=\"_blank\" style=\"color: #008be1; text-decoration: underline; display: block; margin-top: 8px; font-size: 13px;\">", "");
                  AV17HTMLText += context.GetMessage( "&#128196; Ver documento: ", "") + StringUtil.Trim( AV20PdfNombre);
                  AV17HTMLText += context.GetMessage( "</a>", "");
               }
               AV25GXV1 = (int)(AV25GXV1+1);
            }
            AV17HTMLText += context.GetMessage( "</div>", "");
         }
         AV17HTMLText += context.GetMessage( "</div>", "");
         AV17HTMLText += context.GetMessage( "</div>", "");
         AV17HTMLText += context.GetMessage( "</div>", "");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8EmailCliente)) )
         {
            GXt_char1 = AV21SolicitudBC.gxTpr_Proveedornombre;
            new organizarmail(context ).execute(  8,  context.GetMessage( "N", ""),  AV8EmailCliente, ref  GXt_char1,  "", ref  AV17HTMLText, out  AV11Ok, out  AV9ErrorDescription) ;
            AV21SolicitudBC.gxTpr_Proveedornombre = GXt_char1;
         }
         else
         {
            AV11Ok = context.GetMessage( "N", "");
            AV9ErrorDescription = context.GetMessage( "No se envió el correo porque el cliente no proporcionó una dirección válida.", "");
         }
         if ( StringUtil.StrCmp(AV11Ok, context.GetMessage( "S", "")) == 0 )
         {
            AV21SolicitudBC.gxTpr_Solicitudesnotificacion = context.GetMessage( "S", "");
            AV21SolicitudBC.gxTpr_Solicitudesotros3 = context.GetMessage( "Correo enviado con éxito.", "");
         }
         else
         {
            AV21SolicitudBC.gxTpr_Solicitudesnotificacion = context.GetMessage( "N", "");
            AV21SolicitudBC.gxTpr_Solicitudesotros3 = AV9ErrorDescription;
         }
         AV21SolicitudBC.Save();
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
         AV11Ok = "";
         AV9ErrorDescription = "";
         AV21SolicitudBC = new SdtSolicitudes(context);
         AV15Codigo = "";
         AV23Valor = "";
         AV18LinkFormulario = "";
         AV16CodigoCondiciones = "";
         AV24ValorCondiciones = "";
         AV14BaseUrlCondiciones = "";
         AV17HTMLText = "";
         AV19ListaPdfs = new GxSimpleCollection<string>();
         AV20PdfNombre = "";
         AV22UrlCompletaPdf = "";
         GXt_char1 = "";
         /* GeneXus formulas. */
      }

      private int AV25GXV1 ;
      private long AV12SolicitudId ;
      private string AV10NombreCliente ;
      private string AV11Ok ;
      private string AV15Codigo ;
      private string AV18LinkFormulario ;
      private string AV16CodigoCondiciones ;
      private string GXt_char1 ;
      private string AV8EmailCliente ;
      private string AV13StringRutasCondiciones ;
      private string AV9ErrorDescription ;
      private string AV23Valor ;
      private string AV24ValorCondiciones ;
      private string AV14BaseUrlCondiciones ;
      private string AV17HTMLText ;
      private string AV20PdfNombre ;
      private string AV22UrlCompletaPdf ;
      private SdtSolicitudes AV21SolicitudBC ;
      private GxSimpleCollection<string> AV19ListaPdfs ;
      private string aP4_Ok ;
      private string aP5_ErrorDescription ;
   }

}
