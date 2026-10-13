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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.apis {
   public class arelacionsolprof : GXProcedure
   {
      public arelacionsolprof( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public arelacionsolprof( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesId ,
                           string aP1_ProfesionalesId ,
                           string aP2_UsuariosId ,
                           out string aP3_RestMessage ,
                           out short aP4_RestCod )
      {
         this.AV18SolicitudesId = aP0_SolicitudesId;
         this.AV15ProfesionalesId = aP1_ProfesionalesId;
         this.AV30UsuariosId = aP2_UsuariosId;
         this.AV16RestMessage = "" ;
         this.AV27RestCod = 0 ;
         initialize();
         ExecutePrivate();
         aP3_RestMessage=this.AV16RestMessage;
         aP4_RestCod=this.AV27RestCod;
      }

      public short executeUdp( long aP0_SolicitudesId ,
                               string aP1_ProfesionalesId ,
                               string aP2_UsuariosId ,
                               out string aP3_RestMessage )
      {
         execute(aP0_SolicitudesId, aP1_ProfesionalesId, aP2_UsuariosId, out aP3_RestMessage, out aP4_RestCod);
         return AV27RestCod ;
      }

      public void executeSubmit( long aP0_SolicitudesId ,
                                 string aP1_ProfesionalesId ,
                                 string aP2_UsuariosId ,
                                 out string aP3_RestMessage ,
                                 out short aP4_RestCod )
      {
         this.AV18SolicitudesId = aP0_SolicitudesId;
         this.AV15ProfesionalesId = aP1_ProfesionalesId;
         this.AV30UsuariosId = aP2_UsuariosId;
         this.AV16RestMessage = "" ;
         this.AV27RestCod = 0 ;
         SubmitImpl();
         aP3_RestMessage=this.AV16RestMessage;
         aP4_RestCod=this.AV27RestCod;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( (0==AV18SolicitudesId) || String.IsNullOrEmpty(StringUtil.RTrim( AV15ProfesionalesId)) )
         {
            Gx_restcode = 400;
            AV16RestMessage = context.GetMessage( "Error de parámetros", "");
            cleanup();
            if (true) return;
         }
         AV28TokenId = "";
         AV29IsOkToken = true;
         Gx_restcode = 200;
         AV16RestMessage = "";
         new GeneXus.Programs.apis.checkauthorization(context ).execute(  AV31HttpRequest,  AV30UsuariosId,  AV15ProfesionalesId, out  AV28TokenId, out  AV29IsOkToken, out  Gx_restcode, out  AV16RestMessage) ;
         if ( ! AV29IsOkToken )
         {
            Gx_restcode = 401;
            cleanup();
            if (true) return;
         }
         AV36ListaDeudoresId = 3;
         new GeneXus.Programs.apis.verificartrabajosporestadodeuda(context ).execute(  AV15ProfesionalesId,  AV36ListaDeudoresId, out  AV34ProfesionalesTieneDeuda, out  AV35PuedeAceptar) ;
         new GeneXus.Programs.apis.oparametro(context ).execute(  context.GetMessage( "PREPAGO_REGLA_ACTIVA", ""), out  AV62ReglaPrepagoActivaStr) ;
         if ( StringUtil.StrCmp(StringUtil.Trim( AV62ReglaPrepagoActivaStr), "S") == 0 )
         {
            new GeneXus.Programs.apis.validaforzarprepago(context ).execute(  AV15ProfesionalesId, out  AV33DebeAceptarSolPrepago) ;
         }
         else
         {
            AV33DebeAceptarSolPrepago = false;
         }
         AV64GXLvl37 = 0;
         /* Using cursor P00JK2 */
         pr_default.execute(0, new Object[] {AV18SolicitudesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127SolicitudesID = P00JK2_A127SolicitudesID[0];
            A171SolicitudesNombre = P00JK2_A171SolicitudesNombre[0];
            A206SolicitudesMail = P00JK2_A206SolicitudesMail[0];
            n206SolicitudesMail = P00JK2_n206SolicitudesMail[0];
            A184SolicitudesFechaInstalacion = P00JK2_A184SolicitudesFechaInstalacion[0];
            A183SolicitudesHoraInstalacion = P00JK2_A183SolicitudesHoraInstalacion[0];
            A131EstadosSolId = P00JK2_A131EstadosSolId[0];
            A438SolicitudServicioOrigenPago = P00JK2_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = P00JK2_n438SolicitudServicioOrigenPago[0];
            AV64GXLvl37 = 1;
            AV52SolicitudesNombreAux = A171SolicitudesNombre;
            AV53SolicitudesMailAux = A206SolicitudesMail;
            AV51SolicitudesFechaAux = A184SolicitudesFechaInstalacion;
            AV50SolicitudesHoraAux = A183SolicitudesHoraInstalacion;
            if ( ( StringUtil.StrCmp(A438SolicitudServicioOrigenPago, "F") == 0 ) && ( A131EstadosSolId != 2 ) )
            {
               if ( AV34ProfesionalesTieneDeuda && ! AV35PuedeAceptar )
               {
                  Gx_restcode = 409;
                  AV16RestMessage = context.GetMessage( "Para procesar un nuevo servicio de Cobro Directo, primero debes completar 3 servicios bajo la modalidad Prepago.", "");
                  pr_default.close(0);
                  cleanup();
                  if (true) return;
               }
               if ( AV33DebeAceptarSolPrepago )
               {
                  AV57ExistenPrepagosDisponibles = false;
                  new GeneXus.Programs.apis.existetrabajoprepagodisponible(context ).execute( out  AV57ExistenPrepagosDisponibles) ;
                  if ( AV57ExistenPrepagosDisponibles )
                  {
                     Gx_restcode = 409;
                     AV16RestMessage = context.GetMessage( "Has alcanzado la cantidad máxima permitida de servicios consecutivos de cobro directo. Debés aceptar un trabajo prepago.", "");
                     pr_default.close(0);
                     cleanup();
                     if (true) return;
                  }
               }
            }
            new GeneXus.Programs.apis.olimitordensinfinalizar(context ).execute(  AV15ProfesionalesId, out  AV25ValorNum) ;
            if ( AV25ValorNum < 1 )
            {
               new GeneXus.Programs.apis.oparametro(context ).execute(  context.GetMessage( "LIMITESOLICITUD", ""), out  AV24Valor) ;
               AV25ValorNum = (short)(Math.Round(NumberUtil.Val( AV24Valor, "."), 18, MidpointRounding.ToEven));
            }
            if ( ( ( new ocantidadsolicitudes(context).executeUdp(  AV15ProfesionalesId) > AV25ValorNum ) ) && ( AV25ValorNum > 0 ) )
            {
               AV21Titulo = context.GetMessage( "Solicitud no.: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(A127SolicitudesID), 10, 0));
               AV16RestMessage = context.GetMessage( "No es posible Aceptar la solicitud, tiene ", "") + AV24Valor + context.GetMessage( " solicitudes sin finalizar.", "") + AV21Titulo;
               AV27RestCod = 403;
            }
            else
            {
               GXt_int1 = AV9EstadoActSolicitud;
               new oestadosol(context ).execute(  A127SolicitudesID, out  GXt_int1) ;
               AV9EstadoActSolicitud = GXt_int1;
               if ( AV9EstadoActSolicitud == 2 )
               {
                  /* Execute user subroutine: 'EVALUARSIFUEASIGNADAAOTRO' */
                  S131 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     cleanup();
                     if (true) return;
                  }
                  if ( StringUtil.StrCmp(StringUtil.Trim( AV15ProfesionalesId), StringUtil.Trim( AV32ProfesionalAsignado)) != 0 )
                  {
                     AV21Titulo = context.GetMessage( "Solicitud no.: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(A127SolicitudesID), 10, 0));
                     AV16RestMessage = context.GetMessage( "No es posible Aceptar la solicitud, fue asignada a otro profesional. Recargue la página para obtener datos actualizados.", "");
                     AV27RestCod = 403;
                     pr_default.close(0);
                     cleanup();
                     if (true) return;
                  }
               }
               if ( AV9EstadoActSolicitud != 5 )
               {
                  GXt_int1 = AV10EstadosSolId;
                  new oestadosol(context ).execute(  A127SolicitudesID, out  GXt_int1) ;
                  AV10EstadosSolId = GXt_int1;
                  if ( ( AV10EstadosSolId == 5 ) || ( AV10EstadosSolId == 6 ) || ( AV10EstadosSolId == 7 ) )
                  {
                     AV21Titulo = context.GetMessage( "Solicitud no.: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(A127SolicitudesID), 10, 0));
                     AV16RestMessage = context.GetMessage( "La solicitud ya fue tomada.", "") + AV21Titulo;
                     AV27RestCod = 403;
                  }
                  else
                  {
                     GXt_boolean2 = AV26Vinculo;
                     new ovinculosolprof(context ).execute(  A127SolicitudesID,  AV15ProfesionalesId, out  GXt_boolean2) ;
                     AV26Vinculo = GXt_boolean2;
                     if ( AV26Vinculo )
                     {
                        AV21Titulo = context.GetMessage( "Solicitud no.: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(A127SolicitudesID), 10, 0));
                        AV16RestMessage = context.GetMessage( "El trabajo ya fue tomado por otro usuario", "") + AV21Titulo;
                     }
                     else
                     {
                        if ( AV10EstadosSolId != 2 )
                        {
                           GXt_boolean2 = AV26Vinculo;
                           new vincularrelaciones(context ).execute(  A127SolicitudesID,  AV15ProfesionalesId, out  GXt_boolean2) ;
                           AV26Vinculo = GXt_boolean2;
                        }
                        AV13NuevoEstadoId = 5;
                        AV14NuevoEstadoNomb = context.GetMessage( "Aceptada", "");
                        AV20SolicitudesNombre = A171SolicitudesNombre;
                        AV19SolicitudesMail = A206SolicitudesMail;
                        /* Execute user subroutine: 'OBTENERDATOSUSUARIOS' */
                        S141 ();
                        if ( returnInSub )
                        {
                           pr_default.close(0);
                           cleanup();
                           if (true) return;
                        }
                        new cambstssolicitudes(context ).execute(  A127SolicitudesID,  5,  AV15ProfesionalesId,  AV17SDTCNotificaciones,  AV30UsuariosId, out  AV8CambioSTSOK) ;
                        if ( StringUtil.StrCmp(AV8CambioSTSOK, context.GetMessage( "S", "")) == 0 )
                        {
                           AV21Titulo = context.GetMessage( "Solicitud no.: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(A127SolicitudesID), 10, 0));
                           AV16RestMessage = context.GetMessage( "Aceptada con Éxito.", "") + AV21Titulo;
                           AV27RestCod = 200;
                           new GeneXus.Programs.apis.actualizarcentrocostos(context ).execute(  AV18SolicitudesId,  AV15ProfesionalesId,  AV13NuevoEstadoId) ;
                           new GeneXus.Programs.apis.oparametro(context ).execute(  context.GetMessage( "SIN_CORREO_LISTAID", ""), out  AV61RestriccionListaIdStr) ;
                           AV60RestriccionListaId = (long)(Math.Round(NumberUtil.Val( AV61RestriccionListaIdStr, "."), 18, MidpointRounding.ToEven));
                           GXt_boolean2 = AV59EsPerfilSilencioso;
                           new GeneXus.Programs.apis.validarprofesionalenlista(context ).execute(  AV15ProfesionalesId,  AV60RestriccionListaId, out  GXt_boolean2) ;
                           AV59EsPerfilSilencioso = GXt_boolean2;
                           if ( ! AV59EsPerfilSilencioso )
                           {
                              /* Execute user subroutine: 'ENVIARCORREOACEPTADA' */
                              S111 ();
                              if ( returnInSub )
                              {
                                 pr_default.close(0);
                                 cleanup();
                                 if (true) return;
                              }
                           }
                        }
                        else
                        {
                           AV21Titulo = context.GetMessage( "Solicitud no.: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(A127SolicitudesID), 10, 0));
                           AV16RestMessage = context.GetMessage( "La solicitud ya ha sido tomada por otro usuario", "") + AV21Titulo;
                           AV27RestCod = 403;
                        }
                     }
                  }
               }
               else
               {
                  AV21Titulo = context.GetMessage( "Solicitud no.: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(A127SolicitudesID), 10, 0));
                  AV16RestMessage = context.GetMessage( "No fue posible procesar la solicitud, ya fue tomada por otro usuario.", "") + AV21Titulo;
                  AV27RestCod = 403;
               }
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV64GXLvl37 == 0 )
         {
            AV16RestMessage = context.GetMessage( "No fue posible procesar la solicitud", "");
            AV27RestCod = 403;
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'ENVIARCORREOACEPTADA' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'EVALUAR EMAIL' */
         S121 ();
         if (returnInSub) return;
         if ( ! AV38EmailCorrecto )
         {
            returnInSub = true;
            if (true) return;
         }
         new GeneXus.Programs.apis.operfilprofesionalinterno(context ).execute(  AV15ProfesionalesId, out  AV54SDTPerfilProfesional) ;
         AV42HTMLText = context.GetMessage( "<div style=\"background-color:#ffffff; margin: 0 auto; max-width:600px; min-width:320px; font-family: Arial, sans-serif;\">", "");
         AV42HTMLText += context.GetMessage( "<div style=\"padding: 20px 40px; font-size: 16px; line-height: 1.6; text-align: left; color: #000000;\">", "");
         AV42HTMLText += context.GetMessage( "Hola <strong>", "") + StringUtil.Trim( AV52SolicitudesNombreAux) + context.GetMessage( "</strong>,<br><br>", "");
         AV42HTMLText += context.GetMessage( "Un profesional ya aceptó tu solicitud de servicio en la fecha que elegiste.<br><br>", "");
         if ( (DateTime.MinValue==AV51SolicitudesFechaAux) )
         {
            AV55FechaStr = context.GetMessage( "A definir", "");
         }
         else
         {
            AV55FechaStr = context.localUtil.DToC( AV51SolicitudesFechaAux, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/");
         }
         AV56HoraStr = StringUtil.Trim( AV50SolicitudesHoraAux);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56HoraStr)) )
         {
            AV58TextHora = context.GetMessage( "A definir", "");
         }
         else if ( StringUtil.StrCmp(AV56HoraStr, "1") == 0 )
         {
            AV58TextHora = context.GetMessage( "8-12 hs (Sabados 8-14 hs)", "");
         }
         else if ( StringUtil.StrCmp(AV56HoraStr, "2") == 0 )
         {
            AV58TextHora = context.GetMessage( "12-16 hs (Sabados 14-20 hs)", "");
         }
         else if ( StringUtil.StrCmp(AV56HoraStr, "3") == 0 )
         {
            AV58TextHora = context.GetMessage( "16-20 hs", "");
         }
         else
         {
            AV58TextHora = AV56HoraStr;
         }
         AV42HTMLText += context.GetMessage( "<div style=\"background-color: #f9f9f9; padding: 20px; border-left: 4px solid #008be1; margin: 20px 0;\">", "");
         AV42HTMLText += context.GetMessage( "<strong>Fecha solicitada:</strong> ", "") + AV55FechaStr + context.GetMessage( "<br>", "");
         AV42HTMLText += context.GetMessage( "<strong>Turno solicitado:</strong> ", "") + AV58TextHora;
         AV42HTMLText += context.GetMessage( "</div>", "");
         AV42HTMLText += context.GetMessage( "<div style=\"margin: 20px 0; border: 1px solid #eeeeee; border-radius: 8px; overflow: hidden; background-color: #ffffff;\">", "");
         AV42HTMLText += context.GetMessage( "<div style=\"padding: 20px;\">", "");
         AV42HTMLText += context.GetMessage( "<table role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">", "");
         AV42HTMLText += context.GetMessage( "<tr>", "");
         AV42HTMLText += context.GetMessage( "<td style=\"text-align: left;\">", "");
         AV42HTMLText += context.GetMessage( "<div style=\"vertical-align: top; margin-top: 5px;\">", "");
         AV42HTMLText += context.GetMessage( "<div style=\"color: #888888; font-size: 11px; text-transform: uppercase; letter-spacing: 1px; margin-bottom: 2px;\">Profesional asignado</div>", "");
         AV42HTMLText += context.GetMessage( "<div style=\"font-size: 18px; color: #008be1; font-weight: bold; line-height: 1.2;\">", "") + StringUtil.Trim( AV54SDTPerfilProfesional.gxTpr_Profesionalesprimernombre) + " " + StringUtil.Trim( AV54SDTPerfilProfesional.gxTpr_Profesionalesapellidoprimero) + context.GetMessage( "</div>", "");
         AV42HTMLText += context.GetMessage( "<div style=\"margin-top: 8px;\">", "");
         if ( AV54SDTPerfilProfesional.gxTpr_Trabajoscalificados > 0 )
         {
            AV42HTMLText += context.GetMessage( "<span style=\"font-size: 14px; color: #444444; vertical-align: middle;\">", "");
            AV42HTMLText += context.GetMessage( "<span style=\"color: #f1c40f;\">&#11088;</span> <strong>", "") + StringUtil.Trim( StringUtil.Str( AV54SDTPerfilProfesional.gxTpr_Calificacion, 4, 1)) + context.GetMessage( "</strong> ", "");
            AV42HTMLText += context.GetMessage( "<span style=\"color: #888888; font-size: 12px;\">(", "") + StringUtil.Trim( StringUtil.Str( (decimal)(AV54SDTPerfilProfesional.gxTpr_Trabajoscalificados), 18, 0)) + context.GetMessage( ")</span>", "");
            AV42HTMLText += context.GetMessage( "</span>", "");
         }
         if ( AV54SDTPerfilProfesional.gxTpr_Trabajosfinalizados > 0 )
         {
            AV42HTMLText += context.GetMessage( "<span style=\"margin-left: 8px; padding: 3px 8px; background-color: #e1f5fe; color: #039be5; border-radius: 4px; font-size: 10px; font-weight: bold; text-transform: uppercase; vertical-align: middle; display: inline-block;\">", "");
            AV42HTMLText += StringUtil.Trim( StringUtil.Str( (decimal)(AV54SDTPerfilProfesional.gxTpr_Trabajosfinalizados), 18, 0)) + context.GetMessage( " servicios realizados", "");
            AV42HTMLText += context.GetMessage( "</span>", "");
         }
         AV42HTMLText += context.GetMessage( "</div>", "");
         AV42HTMLText += context.GetMessage( "</div>", "");
         AV42HTMLText += context.GetMessage( "</td>", "");
         AV42HTMLText += context.GetMessage( "</tr>", "");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54SDTPerfilProfesional.gxTpr_Profesionalesexperiencia)) )
         {
            AV42HTMLText += context.GetMessage( "<tr>", "");
            AV42HTMLText += context.GetMessage( "<td style=\"padding-top: 15px; border-top: 1px solid #f2f2f2; margin-top: 15px;\">", "");
            AV42HTMLText += context.GetMessage( "<div style=\"color: #666666; font-size: 13px; line-height: 1.4; font-style: italic;\">", "");
            AV42HTMLText += context.GetMessage( "<span>&#8220;</span>", "") + StringUtil.Trim( AV54SDTPerfilProfesional.gxTpr_Profesionalesexperiencia) + context.GetMessage( "<span>&#8221;</span>", "");
            AV42HTMLText += context.GetMessage( "</div>", "");
            AV42HTMLText += context.GetMessage( "</td>", "");
            AV42HTMLText += context.GetMessage( "</tr>", "");
         }
         AV42HTMLText += context.GetMessage( "</table>", "");
         AV42HTMLText += context.GetMessage( "</div>", "");
         AV42HTMLText += context.GetMessage( "</div>", "");
         AV42HTMLText += context.GetMessage( "<div style=\"margin-top: 30px; border-top: 1px solid #eeeeee; padding-top: 20px;\">", "");
         AV42HTMLText += context.GetMessage( "<strong style=\"color: #e67e22;\"><span style=\"font-size: 18px;\">&#9888;</span> Importante</strong><br>", "");
         AV42HTMLText += context.GetMessage( "<p style=\"margin: 10px 0 0 0; color: #444444;\">", "");
         AV42HTMLText += context.GetMessage( "Si necesitás realizar una modificación en la agenda, contactate con nosotros por <strong>WhatsApp</strong>.", "");
         AV42HTMLText += context.GetMessage( "</p>", "");
         AV42HTMLText += context.GetMessage( "</div>", "");
         AV42HTMLText += context.GetMessage( "</div>", "");
         AV42HTMLText += context.GetMessage( "</div>", "");
         new organizarmail(context ).execute(  11,  context.GetMessage( "N", ""),  AV53SolicitudesMailAux, ref  AV52SolicitudesNombreAux,  "", ref  AV42HTMLText, out  AV43Ok, out  AV44ErrorDescription) ;
      }

      protected void S121( )
      {
         /* 'EVALUAR EMAIL' Routine */
         returnInSub = false;
         AV38EmailCorrecto = false;
         AV41validacion = context.GetMessage( "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", "");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53SolicitudesMailAux)) )
         {
            if ( GxRegex.IsMatch(AV53SolicitudesMailAux,AV41validacion) )
            {
               AV38EmailCorrecto = true;
            }
         }
      }

      protected void S131( )
      {
         /* 'EVALUARSIFUEASIGNADAAOTRO' Routine */
         returnInSub = false;
         /* Using cursor P00JK3 */
         pr_default.execute(1, new Object[] {AV18SolicitudesId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A142EstadoSGId = P00JK3_A142EstadoSGId[0];
            A141EstadoSGTipo = P00JK3_A141EstadoSGTipo[0];
            A127SolicitudesID = P00JK3_A127SolicitudesID[0];
            A120ProfesionalesId = P00JK3_A120ProfesionalesId[0];
            A140RelacionesId = P00JK3_A140RelacionesId[0];
            if ( StringUtil.StrCmp(A141EstadoSGTipo, context.GetMessage( "STS", "")) == 0 )
            {
               AV32ProfesionalAsignado = A120ProfesionalesId;
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'OBTENERDATOSUSUARIOS' Routine */
         returnInSub = false;
         /* Using cursor P00JK4 */
         pr_default.execute(2, new Object[] {AV15ProfesionalesId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A240usuariosNumeroIdentidad = P00JK4_A240usuariosNumeroIdentidad[0];
            A222usuariosNombre = P00JK4_A222usuariosNombre[0];
            A224usuariosCorreo = P00JK4_A224usuariosCorreo[0];
            A145usuariosId = P00JK4_A145usuariosId[0];
            AV23usuariosNombre = A222usuariosNombre;
            AV22usuariosCorreo = A224usuariosCorreo;
            pr_default.readNext(2);
         }
         pr_default.close(2);
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
         AV16RestMessage = "";
         AV28TokenId = "";
         AV31HttpRequest = new GxHttpRequest( context);
         AV62ReglaPrepagoActivaStr = "";
         P00JK2_A127SolicitudesID = new long[1] ;
         P00JK2_A171SolicitudesNombre = new string[] {""} ;
         P00JK2_A206SolicitudesMail = new string[] {""} ;
         P00JK2_n206SolicitudesMail = new bool[] {false} ;
         P00JK2_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00JK2_A183SolicitudesHoraInstalacion = new string[] {""} ;
         P00JK2_A131EstadosSolId = new int[1] ;
         P00JK2_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P00JK2_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         A171SolicitudesNombre = "";
         A206SolicitudesMail = "";
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A183SolicitudesHoraInstalacion = "";
         A438SolicitudServicioOrigenPago = "";
         AV52SolicitudesNombreAux = "";
         AV53SolicitudesMailAux = "";
         AV51SolicitudesFechaAux = DateTime.MinValue;
         AV50SolicitudesHoraAux = "";
         AV24Valor = "";
         AV21Titulo = "";
         AV32ProfesionalAsignado = "";
         AV14NuevoEstadoNomb = "";
         AV20SolicitudesNombre = "";
         AV19SolicitudesMail = "";
         AV17SDTCNotificaciones = new SdtSDTCNotificaciones(context);
         AV8CambioSTSOK = "";
         AV61RestriccionListaIdStr = "";
         AV54SDTPerfilProfesional = new GeneXus.Programs.apis.SdtSDTPerfilProfesional(context);
         AV42HTMLText = "";
         AV55FechaStr = "";
         AV56HoraStr = "";
         AV58TextHora = "";
         AV43Ok = "";
         AV44ErrorDescription = "";
         AV41validacion = "";
         P00JK3_A142EstadoSGId = new int[1] ;
         P00JK3_A141EstadoSGTipo = new string[] {""} ;
         P00JK3_A127SolicitudesID = new long[1] ;
         P00JK3_A120ProfesionalesId = new string[] {""} ;
         P00JK3_A140RelacionesId = new long[1] ;
         A141EstadoSGTipo = "";
         A120ProfesionalesId = "";
         P00JK4_A240usuariosNumeroIdentidad = new string[] {""} ;
         P00JK4_A222usuariosNombre = new string[] {""} ;
         P00JK4_A224usuariosCorreo = new string[] {""} ;
         P00JK4_A145usuariosId = new string[] {""} ;
         A240usuariosNumeroIdentidad = "";
         A222usuariosNombre = "";
         A224usuariosCorreo = "";
         A145usuariosId = "";
         AV23usuariosNombre = "";
         AV22usuariosCorreo = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.arelacionsolprof__default(),
            new Object[][] {
                new Object[] {
               P00JK2_A127SolicitudesID, P00JK2_A171SolicitudesNombre, P00JK2_A206SolicitudesMail, P00JK2_n206SolicitudesMail, P00JK2_A184SolicitudesFechaInstalacion, P00JK2_A183SolicitudesHoraInstalacion, P00JK2_A131EstadosSolId, P00JK2_A438SolicitudServicioOrigenPago, P00JK2_n438SolicitudServicioOrigenPago
               }
               , new Object[] {
               P00JK3_A142EstadoSGId, P00JK3_A141EstadoSGTipo, P00JK3_A127SolicitudesID, P00JK3_A120ProfesionalesId, P00JK3_A140RelacionesId
               }
               , new Object[] {
               P00JK4_A240usuariosNumeroIdentidad, P00JK4_A222usuariosNombre, P00JK4_A224usuariosCorreo, P00JK4_A145usuariosId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV27RestCod ;
      private short Gx_restcode ;
      private short AV64GXLvl37 ;
      private short AV25ValorNum ;
      private int A131EstadosSolId ;
      private int AV9EstadoActSolicitud ;
      private int AV10EstadosSolId ;
      private int GXt_int1 ;
      private int AV13NuevoEstadoId ;
      private int A142EstadoSGId ;
      private long AV18SolicitudesId ;
      private long AV36ListaDeudoresId ;
      private long A127SolicitudesID ;
      private long AV60RestriccionListaId ;
      private long A140RelacionesId ;
      private string AV15ProfesionalesId ;
      private string AV30UsuariosId ;
      private string AV28TokenId ;
      private string A171SolicitudesNombre ;
      private string A183SolicitudesHoraInstalacion ;
      private string A438SolicitudServicioOrigenPago ;
      private string AV52SolicitudesNombreAux ;
      private string AV50SolicitudesHoraAux ;
      private string AV32ProfesionalAsignado ;
      private string AV14NuevoEstadoNomb ;
      private string AV20SolicitudesNombre ;
      private string AV8CambioSTSOK ;
      private string AV42HTMLText ;
      private string AV56HoraStr ;
      private string AV58TextHora ;
      private string AV43Ok ;
      private string AV44ErrorDescription ;
      private string AV41validacion ;
      private string A141EstadoSGTipo ;
      private string A120ProfesionalesId ;
      private string A240usuariosNumeroIdentidad ;
      private string A222usuariosNombre ;
      private string A145usuariosId ;
      private string AV23usuariosNombre ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private DateTime AV51SolicitudesFechaAux ;
      private bool AV29IsOkToken ;
      private bool AV34ProfesionalesTieneDeuda ;
      private bool AV35PuedeAceptar ;
      private bool AV33DebeAceptarSolPrepago ;
      private bool n206SolicitudesMail ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool AV57ExistenPrepagosDisponibles ;
      private bool returnInSub ;
      private bool AV26Vinculo ;
      private bool AV59EsPerfilSilencioso ;
      private bool GXt_boolean2 ;
      private bool AV38EmailCorrecto ;
      private string AV16RestMessage ;
      private string AV62ReglaPrepagoActivaStr ;
      private string A206SolicitudesMail ;
      private string AV53SolicitudesMailAux ;
      private string AV24Valor ;
      private string AV21Titulo ;
      private string AV19SolicitudesMail ;
      private string AV61RestriccionListaIdStr ;
      private string AV55FechaStr ;
      private string A224usuariosCorreo ;
      private string AV22usuariosCorreo ;
      private GxHttpRequest AV31HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00JK2_A127SolicitudesID ;
      private string[] P00JK2_A171SolicitudesNombre ;
      private string[] P00JK2_A206SolicitudesMail ;
      private bool[] P00JK2_n206SolicitudesMail ;
      private DateTime[] P00JK2_A184SolicitudesFechaInstalacion ;
      private string[] P00JK2_A183SolicitudesHoraInstalacion ;
      private int[] P00JK2_A131EstadosSolId ;
      private string[] P00JK2_A438SolicitudServicioOrigenPago ;
      private bool[] P00JK2_n438SolicitudServicioOrigenPago ;
      private SdtSDTCNotificaciones AV17SDTCNotificaciones ;
      private GeneXus.Programs.apis.SdtSDTPerfilProfesional AV54SDTPerfilProfesional ;
      private int[] P00JK3_A142EstadoSGId ;
      private string[] P00JK3_A141EstadoSGTipo ;
      private long[] P00JK3_A127SolicitudesID ;
      private string[] P00JK3_A120ProfesionalesId ;
      private long[] P00JK3_A140RelacionesId ;
      private string[] P00JK4_A240usuariosNumeroIdentidad ;
      private string[] P00JK4_A222usuariosNombre ;
      private string[] P00JK4_A224usuariosCorreo ;
      private string[] P00JK4_A145usuariosId ;
      private string aP3_RestMessage ;
      private short aP4_RestCod ;
   }

   public class arelacionsolprof__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00JK2;
          prmP00JK2 = new Object[] {
          new ParDef("@AV18SolicitudesId",GXType.Decimal,18,0)
          };
          Object[] prmP00JK3;
          prmP00JK3 = new Object[] {
          new ParDef("@AV18SolicitudesId",GXType.Decimal,18,0)
          };
          Object[] prmP00JK4;
          prmP00JK4 = new Object[] {
          new ParDef("@AV15ProfesionalesId",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00JK2", "SELECT [SolicitudesID], [SolicitudesNombre], [SolicitudesMail], [SolicitudesFechaInstalacion], [SolicitudesHoraInstalacion], [EstadosSolId], [SolicitudServicioOrigenPago] FROM [Solicitudes] WHERE [SolicitudesID] = @AV18SolicitudesId ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JK2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00JK3", "SELECT [EstadoSGId], [EstadoSGTipo], [SolicitudesID], [ProfesionalesId], [RelacionesId] FROM [Relaciones] WHERE ([SolicitudesID] = @AV18SolicitudesId) AND ([EstadoSGId] = 1) ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JK3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00JK4", "SELECT [usuariosNumeroIdentidad], [usuariosNombre], [usuariosCorreo], [usuariosId] FROM [usuarios] WHERE [usuariosNumeroIdentidad] = @AV15ProfesionalesId ORDER BY [usuariosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JK4,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 1);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 1);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                return;
       }
    }

 }

}
