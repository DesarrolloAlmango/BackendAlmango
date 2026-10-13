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
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class cnotificaciones : GXProcedure
   {
      public cnotificaciones( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public cnotificaciones( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( SdtSDTCNotificaciones aP0_SDTCNotificaciones ,
                           out string aP1_Ok ,
                           out string aP2_ErrorDescription )
      {
         this.AV19SDTCNotificaciones = aP0_SDTCNotificaciones;
         this.AV13Ok = "" ;
         this.AV14ErrorDescription = "" ;
         initialize();
         ExecutePrivate();
         aP1_Ok=this.AV13Ok;
         aP2_ErrorDescription=this.AV14ErrorDescription;
      }

      public string executeUdp( SdtSDTCNotificaciones aP0_SDTCNotificaciones ,
                                out string aP1_Ok )
      {
         execute(aP0_SDTCNotificaciones, out aP1_Ok, out aP2_ErrorDescription);
         return AV14ErrorDescription ;
      }

      public void executeSubmit( SdtSDTCNotificaciones aP0_SDTCNotificaciones ,
                                 out string aP1_Ok ,
                                 out string aP2_ErrorDescription )
      {
         this.AV19SDTCNotificaciones = aP0_SDTCNotificaciones;
         this.AV13Ok = "" ;
         this.AV14ErrorDescription = "" ;
         SubmitImpl();
         aP1_Ok=this.AV13Ok;
         aP2_ErrorDescription=this.AV14ErrorDescription;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( AV19SDTCNotificaciones.gxTpr_Maildesignid == 6 )
         {
            AV30EstadosNotificacionComercio = context.GetMessage( "S", "");
            AV22EstadosNotificacionProfesional = context.GetMessage( "S", "");
            AV28Adjunto = AV19SDTCNotificaciones.gxTpr_Urladjunto2;
         }
         else
         {
            /* Using cursor P009T2 */
            pr_default.execute(0, new Object[] {AV19SDTCNotificaciones.gxTpr_Estadosgenericosid});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A108EstadosGenericosId = P009T2_A108EstadosGenericosId[0];
               A107EstadosTipo = P009T2_A107EstadosTipo[0];
               A263EstadosNotificacionCliente = P009T2_A263EstadosNotificacionCliente[0];
               A264EstadosNotificacionProfesional = P009T2_A264EstadosNotificacionProfesional[0];
               A265EstadosNotificacionOperador = P009T2_A265EstadosNotificacionOperador[0];
               if ( StringUtil.StrCmp(A107EstadosTipo, context.GetMessage( "SOL", "")) == 0 )
               {
                  AV20EstadosNotificacionCliente = A263EstadosNotificacionCliente;
                  AV22EstadosNotificacionProfesional = A264EstadosNotificacionProfesional;
                  AV21EstadosNotificacionOperador = A265EstadosNotificacionOperador;
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         if ( ( StringUtil.StrCmp(AV30EstadosNotificacionComercio, context.GetMessage( "S", "")) == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV19SDTCNotificaciones.gxTpr_Emailcomercio)) )
         {
            AV23Turno = context.GetMessage( "S", "");
            /* Execute user subroutine: 'ORGANIZAR DISENIO PRINCIPAL' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            GXt_char1 = AV19SDTCNotificaciones.gxTpr_Nombrecomercio;
            new organizarmail(context ).execute(  (short)(AV19SDTCNotificaciones.gxTpr_Maildesignid),  context.GetMessage( "N", ""),  AV19SDTCNotificaciones.gxTpr_Emailcomercio, ref  GXt_char1,  AV28Adjunto, ref  AV17HTMLText, out  AV13Ok, out  AV14ErrorDescription) ;
            AV19SDTCNotificaciones.gxTpr_Nombrecomercio = GXt_char1;
         }
         if ( ( StringUtil.StrCmp(AV20EstadosNotificacionCliente, context.GetMessage( "S", "")) == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV19SDTCNotificaciones.gxTpr_Emailcliente)) )
         {
            AV23Turno = context.GetMessage( "C", "");
            /* Execute user subroutine: 'ORGANIZAR DISENIO PRINCIPAL' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            GXt_char1 = AV19SDTCNotificaciones.gxTpr_Nombrecliente;
            new organizarmail(context ).execute(  (short)(AV19SDTCNotificaciones.gxTpr_Maildesignid),  context.GetMessage( "N", ""),  AV19SDTCNotificaciones.gxTpr_Emailcliente, ref  GXt_char1,  AV28Adjunto, ref  AV17HTMLText, out  AV13Ok, out  AV14ErrorDescription) ;
            AV19SDTCNotificaciones.gxTpr_Nombrecliente = GXt_char1;
         }
         if ( ( StringUtil.StrCmp(AV22EstadosNotificacionProfesional, context.GetMessage( "S", "")) == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV19SDTCNotificaciones.gxTpr_Emailprofesional)) )
         {
            AV23Turno = context.GetMessage( "P", "");
            /* Execute user subroutine: 'ORGANIZAR DISENIO PRINCIPAL' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            GXt_char1 = AV19SDTCNotificaciones.gxTpr_Nombreprofesional;
            new organizarmail(context ).execute(  (short)(AV19SDTCNotificaciones.gxTpr_Maildesignid),  context.GetMessage( "N", ""),  AV19SDTCNotificaciones.gxTpr_Emailprofesional, ref  GXt_char1,  AV28Adjunto, ref  AV17HTMLText, out  AV13Ok, out  AV14ErrorDescription) ;
            AV19SDTCNotificaciones.gxTpr_Nombreprofesional = GXt_char1;
         }
         if ( ( StringUtil.StrCmp(AV21EstadosNotificacionOperador, context.GetMessage( "S", "")) == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV19SDTCNotificaciones.gxTpr_Emailoperador)) )
         {
            AV23Turno = context.GetMessage( "O", "");
            /* Execute user subroutine: 'ORGANIZAR DISENIO PRINCIPAL' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            GXt_char1 = AV19SDTCNotificaciones.gxTpr_Nombreoperador;
            new organizarmail(context ).execute(  (short)(AV19SDTCNotificaciones.gxTpr_Maildesignid),  context.GetMessage( "N", ""),  AV19SDTCNotificaciones.gxTpr_Emailoperador, ref  GXt_char1,  AV28Adjunto, ref  AV17HTMLText, out  AV13Ok, out  AV14ErrorDescription) ;
            AV19SDTCNotificaciones.gxTpr_Nombreoperador = GXt_char1;
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'ORGANIZAR DISENIO PRINCIPAL' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'HEADER' */
         S121 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(AV23Turno, context.GetMessage( "S", "")) == 0 )
         {
            AV26mensaje = StringUtil.Trim( AV19SDTCNotificaciones.gxTpr_Mensajefijo);
         }
         else if ( StringUtil.StrCmp(AV23Turno, context.GetMessage( "C", "")) == 0 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19SDTCNotificaciones.gxTpr_Mensajefijo)) )
            {
               AV26mensaje = StringUtil.Trim( AV19SDTCNotificaciones.gxTpr_Mensajefijo);
            }
            else
            {
               AV26mensaje = context.GetMessage( "Solicitud No: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(AV19SDTCNotificaciones.gxTpr_Solicitudesid), 10, 0)) + context.GetMessage( " Nuevo Estado: ", "") + StringUtil.Trim( AV19SDTCNotificaciones.gxTpr_Nuevoestado);
            }
         }
         else if ( StringUtil.StrCmp(AV23Turno, context.GetMessage( "P", "")) == 0 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19SDTCNotificaciones.gxTpr_Mensajefijo)) )
            {
               AV26mensaje = StringUtil.Trim( AV19SDTCNotificaciones.gxTpr_Mensajefijo);
            }
            else
            {
               AV26mensaje = context.GetMessage( "Solicitud No: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(AV19SDTCNotificaciones.gxTpr_Solicitudesid), 10, 0)) + context.GetMessage( " del cliente: ", "") + StringUtil.Trim( AV19SDTCNotificaciones.gxTpr_Nombrecliente) + context.GetMessage( " fué ", "") + StringUtil.Trim( AV19SDTCNotificaciones.gxTpr_Nuevoestado);
            }
         }
         else if ( StringUtil.StrCmp(AV23Turno, context.GetMessage( "O", "")) == 0 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19SDTCNotificaciones.gxTpr_Mensajefijo)) )
            {
               AV26mensaje = StringUtil.Trim( AV19SDTCNotificaciones.gxTpr_Mensajefijo);
            }
            else
            {
               AV26mensaje = context.GetMessage( "Solicitud No: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(AV19SDTCNotificaciones.gxTpr_Solicitudesid), 10, 0)) + context.GetMessage( " del cliente: ", "") + StringUtil.Trim( AV19SDTCNotificaciones.gxTpr_Nombrecliente) + context.GetMessage( " fué ", "") + StringUtil.Trim( AV19SDTCNotificaciones.gxTpr_Nuevoestado) + context.GetMessage( " <br> <br>  Profesional: ", "") + AV19SDTCNotificaciones.gxTpr_Nombreprofesional;
            }
         }
         AV26mensaje = StringUtil.Upper( AV26mensaje);
         /* Execute user subroutine: 'LINEA' */
         S131 ();
         if (returnInSub) return;
         AV11TxtOrdCom += StringUtil.Trim( AV24Linea);
         /* Execute user subroutine: 'FOOTHER' */
         S141 ();
         if (returnInSub) return;
         AV11TxtOrdCom += StringUtil.Trim( AV25Foother);
         AV17HTMLText = AV11TxtOrdCom;
      }

      protected void S121( )
      {
         /* 'HEADER' Routine */
         returnInSub = false;
         AV11TxtOrdCom = context.GetMessage( "<style type=\"text/css\">  @media only screen and (min-width: 620px) { .u-row { width: 600px !important; } .u-row .u-col { vertical-align: top; } .u-row .u-col-100 { width: 600px !important; }}", "");
         AV11TxtOrdCom += context.GetMessage( "@media (max-width: 620px) { .u-row-container { max-width: 100% !important; padding-left: 0px !important; padding-right: 0px !important; } .u-row .u-col { min-width: 320px !important; max-width: 100% !important; display: block !important; }", "");
         AV11TxtOrdCom += context.GetMessage( ".u-row { width: 100% !important; } .u-col { width: 100% !important; } .u-col > div { margin: 0 auto; } }body { margin: 0;   padding: 0; } table, tr, td { vertical-align: top;  border-collapse: collapse; } p { margin: 0; } .ie-container table, .mso-container table {  table-layout: fixed; }", "");
         AV11TxtOrdCom += context.GetMessage( "{ line-height: inherit; } a[x-apple-data-detectors=\"true\"] { color: inherit !important; text-decoration: none !important; } table, td { color: #000000; } </style> ", "");
         AV11TxtOrdCom += context.GetMessage( "<link href=\"https://fonts.googleapis.com/css?family=Lato:400,700&display=swap\" rel=\"stylesheet\" type=\"text/css\"> </head>", "");
         AV11TxtOrdCom += context.GetMessage( "<body class=\"clean-body u_body\" style=\"margin: 0;padding: 0;-webkit-text-size-adjust: 100%;background-color: #f9f9f9;color: #000000\">", "");
         AV11TxtOrdCom += context.GetMessage( "<table style=\"border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;min-width: 320px;Margin: 0 auto;background-color: #f9f9f9;width:100%\" cellpadding=\"0\" cellspacing=\"0\">  <tbody>  <tr style=\"vertical-align: top\">", "");
         AV11TxtOrdCom += context.GetMessage( "<td style=\"word-break: break-word;border-collapse: collapse !important;vertical-align: top\">", "");
         AV11TxtOrdCom += context.GetMessage( "<div class=\"u-row-container\" style=\"padding: 0px;background-color: #f9f9f9\">", "");
         AV11TxtOrdCom += context.GetMessage( "<div class=\"u-row\" style=\"margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #f9f9f9;\">", "");
         AV11TxtOrdCom += context.GetMessage( "<div style=\"border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;\">", "");
         AV11TxtOrdCom += context.GetMessage( "<div class=\"u-col u-col-100\" style=\"max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;\">", "");
         AV11TxtOrdCom += context.GetMessage( "<div style=\"height: 100%;width: 100% !important;\">", "");
         AV11TxtOrdCom += context.GetMessage( "<div style=\"box-sizing: border-box; height: 100%; padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;\"> ", "");
         AV11TxtOrdCom += context.GetMessage( "<table style=\"font-family:\"Lato\",sans-serif;\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\"> <tbody>", "");
         AV11TxtOrdCom += context.GetMessage( "<tr><td style=\"overflow-wrap:break-word;word-break:break-word;padding:15px;font-family:\"Lato\",sans-serif;\" align=\"left\">", "");
         AV11TxtOrdCom += context.GetMessage( "<table height=\"0px\" align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;border-top: 1px solid #f9f9f9;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%\"> <tbody>", "");
         AV11TxtOrdCom += context.GetMessage( " <tr style=\"vertical-align: top\"> <td style=\"word-break: break-word;border-collapse: collapse !important;vertical-align: top;font-size: 0px;line-height: 0px;mso-line-height-rule: exactly;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%\">", "");
         AV11TxtOrdCom += context.GetMessage( "<span>&#160;</span> </td> </tr></tbody> </table></td> </tr></tbody></table> </div> </div> </div> </div>  </div> </div>", "");
         AV11TxtOrdCom += context.GetMessage( "<div class=\"u-row-container\" style=\"padding: 0px;background-color: transparent\">", "");
         AV11TxtOrdCom += context.GetMessage( "<div class=\"u-row\" style=\"margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ffffff;\">", "");
         AV11TxtOrdCom += context.GetMessage( "<div style=\"border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;\">", "");
         AV11TxtOrdCom += context.GetMessage( "<div class=\"u-col u-col-100\" style=\"max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;\">", "");
         AV11TxtOrdCom += context.GetMessage( "<div style=\"height: 100%;width: 100% !important;\">", "");
         AV11TxtOrdCom += context.GetMessage( "<div style=\"box-sizing: border-box; height: 100%; padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;\">", "");
         AV11TxtOrdCom += context.GetMessage( "<table style=\"font-family:\"Lato\",sans-serif;\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\"> <tbody>  <tr>  <td style=\"overflow-wrap:break-word;word-break:break-word;padding:40px 40px 30px;font-family:\"Lato\",sans-serif;\" align=\"left\">", "");
         AV11TxtOrdCom += context.GetMessage( "<div style=\"font-size: 14px; line-height: 140%; text-align: left; word-wrap: break-word;\">", "");
         AV11TxtOrdCom += context.GetMessage( "<p style=\"font-size: 14px; line-height: 140%; text-align: center;\"><span style=\"color: #202124; line-height: 19.6px;\"><strong><span style=\"line-height: 19.6px;\"><span style=\"line-height: 19.6px;\">NOTIFICACIÓN</span></span></strong></span></p>", "");
         AV11TxtOrdCom += context.GetMessage( "</div> </td> </tr></tbody> </table> ", "");
      }

      protected void S131( )
      {
         /* 'LINEA' Routine */
         returnInSub = false;
         AV24Linea = context.GetMessage( "<table style=\"font-family:\"Lato\",sans-serif;\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\">", "");
         AV24Linea += context.GetMessage( "<tbody> <tr> <td style=\"overflow-wrap:break-word;word-break:break-word;padding:40px 40px 30px;font-family:\"Lato\",sans-serif;\" align=\"left\">", "");
         AV24Linea += context.GetMessage( "<div style=\"font-size: 14px; line-height: 140%; text-align: left; word-wrap: break-word;\">", "");
         AV24Linea += context.GetMessage( "<p style=\"line-height: 140%; text-align: center;\"><span style=\"color: #202124; line-height: 19.6px;\"> ", "") + StringUtil.Trim( AV26mensaje) + context.GetMessage( "</span></p>", "");
         AV24Linea += context.GetMessage( "</div></td> </tr></tbody> </table>", "");
         /* Execute user subroutine: 'MENSAJE Y URL1' */
         S151 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'MENSAJE Y URL2' */
         S161 ();
         if (returnInSub) return;
      }

      protected void S151( )
      {
         /* 'MENSAJE Y URL1' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19SDTCNotificaciones.gxTpr_Urladjunto1)) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV19SDTCNotificaciones.gxTpr_Mensajeurl1)) )
         {
            AV27URLAdjunto = context.GetMessage( "<div style=\"font-size: 14px; line-height: 140%; text-align: left; word-wrap: break-word;\"><br>", "");
            AV27URLAdjunto += context.GetMessage( "<p style=\"line-height: 140%; text-align: center;\"><span style=\"color: #e03e2d; line-height: 19.6px;\"><a href=\"", "") + StringUtil.Trim( AV19SDTCNotificaciones.gxTpr_Urladjunto1) + context.GetMessage( "\" target=\"_blank\">", "") + StringUtil.Trim( AV19SDTCNotificaciones.gxTpr_Mensajeurl1) + context.GetMessage( "</a></span></p></div>", "");
            AV24Linea += StringUtil.Trim( AV27URLAdjunto);
         }
      }

      protected void S161( )
      {
         /* 'MENSAJE Y URL2' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19SDTCNotificaciones.gxTpr_Urladjunto2)) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV19SDTCNotificaciones.gxTpr_Mensajeurl2)) )
         {
            AV27URLAdjunto = context.GetMessage( "<div style=\"font-size: 14px; line-height: 140%; text-align: left; word-wrap: break-word;\"><b>", "");
            AV27URLAdjunto += context.GetMessage( "<p style=\"line-height: 140%; text-align: center;\"><span style=\"color: #e03e2d; line-height: 19.6px;\"><a href=\"", "") + StringUtil.Trim( AV19SDTCNotificaciones.gxTpr_Urladjunto2) + context.GetMessage( "\" target=\"_blank\">", "") + StringUtil.Trim( AV19SDTCNotificaciones.gxTpr_Mensajeurl2) + context.GetMessage( "</a></span></p></div>", "");
            AV24Linea += StringUtil.Trim( AV27URLAdjunto);
         }
      }

      protected void S141( )
      {
         /* 'FOOTHER' Routine */
         returnInSub = false;
         AV25Foother = context.GetMessage( "<div class=\"u-row-container\" style=\"padding: 0px;background-color: #f9f9f9\">", "");
         AV25Foother += context.GetMessage( "<div class=\"u-row\" style=\"margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: transparent;\">", "");
         AV25Foother += context.GetMessage( "<div style=\"border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;\">", "");
         AV25Foother += context.GetMessage( "<div class=\"u-col u-col-100\" style=\"max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;\">", "");
         AV25Foother += context.GetMessage( "<div style=\"height: 100%;width: 100% !important;\">", "");
         AV25Foother += context.GetMessage( "<div style=\"box-sizing: border-box; height: 100%; padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;\">", "");
         AV25Foother += context.GetMessage( "<table style=\"font-family:\"Lato\",sans-serif;\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\">", "");
         AV25Foother += context.GetMessage( "<tbody> <tr> <td style=\"overflow-wrap:break-word;word-break:break-word;padding:15px;font-family:\"Lato\",sans-serif;\" align=\"left\">", "");
         AV25Foother += context.GetMessage( "<table height=\"0px\" align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;border-top: 1px solid #202124;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%\">", "");
         AV25Foother += context.GetMessage( "<tbody> <tr style=\"vertical-align: top\"><td style=\"word-break: break-word;border-collapse: collapse !important;vertical-align: top;font-size: 0px;line-height: 0px;mso-line-height-rule: exactly;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%\"> <span>&#160;</span>", "");
         AV25Foother += context.GetMessage( "</td> </tr></tbody></table> </td></tr></tbody></table>", "");
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
         AV13Ok = "";
         AV14ErrorDescription = "";
         AV30EstadosNotificacionComercio = "";
         AV22EstadosNotificacionProfesional = "";
         AV28Adjunto = "";
         P009T2_A108EstadosGenericosId = new int[1] ;
         P009T2_A107EstadosTipo = new string[] {""} ;
         P009T2_A263EstadosNotificacionCliente = new string[] {""} ;
         P009T2_A264EstadosNotificacionProfesional = new string[] {""} ;
         P009T2_A265EstadosNotificacionOperador = new string[] {""} ;
         A107EstadosTipo = "";
         A263EstadosNotificacionCliente = "";
         A264EstadosNotificacionProfesional = "";
         A265EstadosNotificacionOperador = "";
         AV20EstadosNotificacionCliente = "";
         AV21EstadosNotificacionOperador = "";
         AV23Turno = "";
         AV17HTMLText = "";
         GXt_char1 = "";
         AV26mensaje = "";
         AV11TxtOrdCom = "";
         AV24Linea = "";
         AV25Foother = "";
         AV27URLAdjunto = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cnotificaciones__default(),
            new Object[][] {
                new Object[] {
               P009T2_A108EstadosGenericosId, P009T2_A107EstadosTipo, P009T2_A263EstadosNotificacionCliente, P009T2_A264EstadosNotificacionProfesional, P009T2_A265EstadosNotificacionOperador
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A108EstadosGenericosId ;
      private string AV13Ok ;
      private string AV14ErrorDescription ;
      private string AV30EstadosNotificacionComercio ;
      private string AV22EstadosNotificacionProfesional ;
      private string AV28Adjunto ;
      private string A107EstadosTipo ;
      private string A263EstadosNotificacionCliente ;
      private string A264EstadosNotificacionProfesional ;
      private string A265EstadosNotificacionOperador ;
      private string AV20EstadosNotificacionCliente ;
      private string AV21EstadosNotificacionOperador ;
      private string AV23Turno ;
      private string AV17HTMLText ;
      private string GXt_char1 ;
      private string AV26mensaje ;
      private string AV11TxtOrdCom ;
      private string AV24Linea ;
      private string AV25Foother ;
      private string AV27URLAdjunto ;
      private bool returnInSub ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtSDTCNotificaciones AV19SDTCNotificaciones ;
      private IDataStoreProvider pr_default ;
      private int[] P009T2_A108EstadosGenericosId ;
      private string[] P009T2_A107EstadosTipo ;
      private string[] P009T2_A263EstadosNotificacionCliente ;
      private string[] P009T2_A264EstadosNotificacionProfesional ;
      private string[] P009T2_A265EstadosNotificacionOperador ;
      private string aP1_Ok ;
      private string aP2_ErrorDescription ;
   }

   public class cnotificaciones__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP009T2;
          prmP009T2 = new Object[] {
          new ParDef("@AV19SDTC_1Estadosgenericosid",GXType.Int32,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009T2", "SELECT [EstadosGenericosId], [EstadosTipo], [EstadosNotificacionCliente], [EstadosNotificacionProfesional], [EstadosNotificacionOperador] FROM [EstadosGenericos] WHERE [EstadosGenericosId] = @AV19SDTC_1Estadosgenericosid ORDER BY [EstadosTipo], [EstadosGenericosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009T2,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                return;
       }
    }

 }

}
