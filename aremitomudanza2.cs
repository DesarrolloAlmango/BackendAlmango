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
using GeneXus.Printer;
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
   public class aremitomudanza2 : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "aremitomudanza2.aspx")), "aremitomudanza2.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "aremitomudanza2.aspx")))) ;
            }
            else
            {
               GxWebError = 1;
               context.HttpContext.Response.StatusDescription = 403.ToString();
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
            }
         }
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "SolicitudesID");
            if ( ! entryPointCalled )
            {
               AV32SolicitudesID = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aremitomudanza2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aremitomudanza2( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref long aP0_SolicitudesID )
      {
         this.AV32SolicitudesID = aP0_SolicitudesID;
         initialize();
         ExecutePrivate();
         aP0_SolicitudesID=this.AV32SolicitudesID;
      }

      public long executeUdp( )
      {
         execute(ref aP0_SolicitudesID);
         return AV32SolicitudesID ;
      }

      public void executeSubmit( ref long aP0_SolicitudesID )
      {
         this.AV32SolicitudesID = aP0_SolicitudesID;
         SubmitImpl();
         aP0_SolicitudesID=this.AV32SolicitudesID;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         setOutputFileName("ReporteEconomicoDetallado");
         setOutputType("PDF");
         try
         {
            Gx_out = "SCR" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11909, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            HGZ0( false, 125) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "22922f7f-f2d4-4fde-abb1-d4ceefcb60c5", "", context.GetTheme( )), 13, Gx_line+13, 186, Gx_line+53) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 14, true, false, true, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "REMITO DE MUDANZA", ""), 120, Gx_line+67, 696, Gx_line+94, 1, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 714, Gx_line+33, 790, Gx_line+47, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 660, Gx_line+33, 699, Gx_line+47, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Fecha del Reporte", ""), 661, Gx_line+13, 810, Gx_line+27, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+125);
            AV31Solicitudes.Load(AV32SolicitudesID);
            AV22MudanzaId = AV31Solicitudes.gxTpr_Mudanzaid;
            AV47MetodoPagosNombre = AV31Solicitudes.gxTpr_Metodopagosnombre;
            /* Using cursor P00GZ2 */
            pr_default.execute(0, new Object[] {AV22MudanzaId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A743TipoInmuebleOrigenId = P00GZ2_A743TipoInmuebleOrigenId[0];
               A745TipoInmuebleDestinoId = P00GZ2_A745TipoInmuebleDestinoId[0];
               A747TipoEstacionamOrigenId = P00GZ2_A747TipoEstacionamOrigenId[0];
               A749TipoEstacionamDestinoId = P00GZ2_A749TipoEstacionamDestinoId[0];
               A735MudanzaId = P00GZ2_A735MudanzaId[0];
               A765MudanzaCargaVolumenEstimado = P00GZ2_A765MudanzaCargaVolumenEstimado[0];
               A764MudanzaPrecioFinal = P00GZ2_A764MudanzaPrecioFinal[0];
               A739MudanzaHoraServicio = P00GZ2_A739MudanzaHoraServicio[0];
               n739MudanzaHoraServicio = P00GZ2_n739MudanzaHoraServicio[0];
               A776MudanzaRgoHoraservicio = P00GZ2_A776MudanzaRgoHoraservicio[0];
               n776MudanzaRgoHoraservicio = P00GZ2_n776MudanzaRgoHoraservicio[0];
               A784MudanzaApellidoNombre = P00GZ2_A784MudanzaApellidoNombre[0];
               A785MudanzaMail = P00GZ2_A785MudanzaMail[0];
               A786MudanzaPhone = P00GZ2_A786MudanzaPhone[0];
               A738MudanzaFechaServicio = P00GZ2_A738MudanzaFechaServicio[0];
               A740MudanzaDireccionOrigen = P00GZ2_A740MudanzaDireccionOrigen[0];
               A741MudanzaDireccionDestino = P00GZ2_A741MudanzaDireccionDestino[0];
               A777MudanzaPisoDptoOrigen = P00GZ2_A777MudanzaPisoDptoOrigen[0];
               A778MudanzaPisoDptoDestino = P00GZ2_A778MudanzaPisoDptoDestino[0];
               A794MudanzaOrigenMetodo = P00GZ2_A794MudanzaOrigenMetodo[0];
               A795MudanzaDestinoMetodo = P00GZ2_A795MudanzaDestinoMetodo[0];
               A755TipoInmuebleOrigenNombre = P00GZ2_A755TipoInmuebleOrigenNombre[0];
               A746TipoInmuebleDestinoNombre = P00GZ2_A746TipoInmuebleDestinoNombre[0];
               A748TipoEstacionamOrigenNombre = P00GZ2_A748TipoEstacionamOrigenNombre[0];
               A750TipoEstacionamDestinoNombre = P00GZ2_A750TipoEstacionamDestinoNombre[0];
               A783MudanzaComentario = P00GZ2_A783MudanzaComentario[0];
               A742MudanzaVehiculoSugerido = P00GZ2_A742MudanzaVehiculoSugerido[0];
               A755TipoInmuebleOrigenNombre = P00GZ2_A755TipoInmuebleOrigenNombre[0];
               A746TipoInmuebleDestinoNombre = P00GZ2_A746TipoInmuebleDestinoNombre[0];
               A748TipoEstacionamOrigenNombre = P00GZ2_A748TipoEstacionamOrigenNombre[0];
               A750TipoEstacionamDestinoNombre = P00GZ2_A750TipoEstacionamDestinoNombre[0];
               HGZ0( false, 84) ;
               getPrinter().GxAttris("Mongolian Baiti", 12, true, false, true, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "TOTAL:", ""), 20, Gx_line+13, 87, Gx_line+40, 0, 0, 0, 1) ;
               getPrinter().GxDrawRect(960, Gx_line+0, 1060, Gx_line+30, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A764MudanzaPrecioFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 88, Gx_line+16, 308, Gx_line+38, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 100, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47MetodoPagosNombre, "")), 87, Gx_line+40, 300, Gx_line+55, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV32SolicitudesID), "ZZZZZZZZZZZZZZZZZ9")), 713, Gx_line+15, 793, Gx_line+30, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Mongolian Baiti", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Solicitud N°:", ""), 620, Gx_line+15, 713, Gx_line+28, 0, 0, 0, 1) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Volúmen (m3):", ""), 55, Gx_line+62, 148, Gx_line+75, 1, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A765MudanzaCargaVolumenEstimado, "ZZZZZZZZZZZZZZ9.99")), 147, Gx_line+62, 227, Gx_line+77, 0, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+84);
               if ( String.IsNullOrEmpty(StringUtil.RTrim( A739MudanzaHoraServicio)) )
               {
                  AV18Hora = StringUtil.Trim( A776MudanzaRgoHoraservicio);
               }
               else
               {
                  AV18Hora = StringUtil.Trim( A739MudanzaHoraServicio);
               }
               HGZ0( false, 309) ;
               getPrinter().GxDrawLine(20, Gx_line+0, 800, Gx_line+0, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "NOTA:", ""), 67, Gx_line+267, 114, Gx_line+280, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A783MudanzaComentario, "")), 120, Gx_line+267, 787, Gx_line+297, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Inmueble.:", ""), 493, Gx_line+227, 563, Gx_line+240, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Inmueble.:", ""), 493, Gx_line+160, 563, Gx_line+173, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A750TipoEstacionamDestinoNombre, "")), 560, Gx_line+200, 660, Gx_line+215, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A748TipoEstacionamOrigenNombre, "")), 560, Gx_line+133, 660, Gx_line+148, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Estac.:", ""), 507, Gx_line+200, 557, Gx_line+213, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A746TipoInmuebleDestinoNombre, "")), 560, Gx_line+227, 660, Gx_line+242, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A755TipoInmuebleOrigenNombre, "")), 560, Gx_line+160, 660, Gx_line+175, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Estac.:", ""), 507, Gx_line+133, 557, Gx_line+146, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A795MudanzaDestinoMetodo, "")), 413, Gx_line+227, 486, Gx_line+242, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A794MudanzaOrigenMetodo, "")), 413, Gx_line+160, 488, Gx_line+175, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A778MudanzaPisoDptoDestino, "")), 707, Gx_line+227, 800, Gx_line+242, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A777MudanzaPisoDptoOrigen, "")), 693, Gx_line+160, 786, Gx_line+175, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Piso:", ""), 667, Gx_line+227, 727, Gx_line+240, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Piso:", ""), 667, Gx_line+160, 727, Gx_line+173, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A741MudanzaDireccionDestino, "")), 120, Gx_line+200, 487, Gx_line+225, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A740MudanzaDireccionOrigen, "")), 120, Gx_line+133, 487, Gx_line+160, 0+16, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "DESTINO", ""), 53, Gx_line+199, 113, Gx_line+212, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "ORIGEN", ""), 53, Gx_line+133, 113, Gx_line+146, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18Hora, "")), 427, Gx_line+53, 507, Gx_line+68, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A738MudanzaFechaServicio, "99/99/99"), 107, Gx_line+53, 200, Gx_line+68, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Mongolian Baiti", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Fecha:", ""), 53, Gx_line+53, 106, Gx_line+66, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(context.GetMessage( "Horario:", ""), 360, Gx_line+53, 427, Gx_line+66, 0, 0, 0, 1) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A786MudanzaPhone, "")), 693, Gx_line+80, 806, Gx_line+95, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A785MudanzaMail, "")), 400, Gx_line+80, 580, Gx_line+95, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A784MudanzaApellidoNombre, "")), 107, Gx_line+80, 320, Gx_line+95, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Mongolian Baiti", 9, true, false, true, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "DATOS", ""), 27, Gx_line+13, 260, Gx_line+26, 0, 0, 0, 1) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Teléfono:", ""), 640, Gx_line+80, 707, Gx_line+93, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Email:", ""), 360, Gx_line+80, 407, Gx_line+93, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Nombre:", ""), 53, Gx_line+80, 113, Gx_line+93, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+309);
               HGZ0( false, 86) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Carga", ""), 38, Gx_line+66, 98, Gx_line+79, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Mongolian Baiti", 9, true, false, true, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "VEHÍCULO:", ""), 20, Gx_line+31, 100, Gx_line+44, 0, 0, 0, 1) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A742MudanzaVehiculoSugerido, "")), 96, Gx_line+29, 236, Gx_line+46, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(20, Gx_line+84, 800, Gx_line+84, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(20, Gx_line+60, 800, Gx_line+60, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Cantidad", ""), 503, Gx_line+65, 563, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Embalaje", ""), 629, Gx_line+65, 689, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Elevación", ""), 729, Gx_line+65, 799, Gx_line+78, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+86);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00GZ3 */
            pr_default.execute(1, new Object[] {AV22MudanzaId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A751ItemCargaId = P00GZ3_A751ItemCargaId[0];
               A753ItemCargaCantidad = P00GZ3_A753ItemCargaCantidad[0];
               A735MudanzaId = P00GZ3_A735MudanzaId[0];
               A813ItemCargaEmbCant = P00GZ3_A813ItemCargaEmbCant[0];
               n813ItemCargaEmbCant = P00GZ3_n813ItemCargaEmbCant[0];
               A814ItemCargaElevCant = P00GZ3_A814ItemCargaElevCant[0];
               n814ItemCargaElevCant = P00GZ3_n814ItemCargaElevCant[0];
               A841ItemCargaDescripcion = P00GZ3_A841ItemCargaDescripcion[0];
               A752ItemCargaNombre = P00GZ3_A752ItemCargaNombre[0];
               A841ItemCargaDescripcion = P00GZ3_A841ItemCargaDescripcion[0];
               A752ItemCargaNombre = P00GZ3_A752ItemCargaNombre[0];
               AV45Embalaje = A813ItemCargaEmbCant;
               AV46Elevacion = A814ItemCargaElevCant;
               HGZ0( false, 32) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A752ItemCargaNombre, "")), 38, Gx_line+1, 185, Gx_line+28, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A753ItemCargaCantidad), "ZZZ9")), 521, Gx_line+0, 634, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(47, Gx_line+29, 787, Gx_line+29, 1, 220, 220, 220, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV45Embalaje), "ZZZ9")), 647, Gx_line+0, 734, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV46Elevacion), "ZZZ9")), 745, Gx_line+0, 835, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A841ItemCargaDescripcion, "")), 197, Gx_line+0, 487, Gx_line+27, 0+16, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+32);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV52Count = 0;
            /* Optimized group. */
            /* Using cursor P00GZ4 */
            pr_default.execute(2, new Object[] {AV22MudanzaId});
            cV52Count = P00GZ4_AV52Count[0];
            pr_default.close(2);
            AV52Count = (short)(AV52Count+cV52Count*1);
            /* End optimized group. */
            if ( AV52Count > 0 )
            {
               HGZ0( false, 110) ;
               getPrinter().GxDrawLine(20, Gx_line+107, 800, Gx_line+107, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Mongolian Baiti", 9, true, false, true, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "ADICIONALES", ""), 20, Gx_line+56, 140, Gx_line+69, 0, 0, 0, 1) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Item", ""), 43, Gx_line+89, 103, Gx_line+102, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Cantidad", ""), 357, Gx_line+89, 417, Gx_line+102, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(19, Gx_line+83, 799, Gx_line+83, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+110);
               /* Using cursor P00GZ5 */
               pr_default.execute(3, new Object[] {AV22MudanzaId});
               while ( (pr_default.getStatus(3) != 101) )
               {
                  BRKGZ5 = false;
                  A766ItemAdicionalId = P00GZ5_A766ItemAdicionalId[0];
                  A735MudanzaId = P00GZ5_A735MudanzaId[0];
                  A767ItemAdicionalNombre = P00GZ5_A767ItemAdicionalNombre[0];
                  A768ItemAdicionalCantidad = P00GZ5_A768ItemAdicionalCantidad[0];
                  A767ItemAdicionalNombre = P00GZ5_A767ItemAdicionalNombre[0];
                  while ( (pr_default.getStatus(3) != 101) && ( P00GZ5_A735MudanzaId[0] == A735MudanzaId ) && ( P00GZ5_A766ItemAdicionalId[0] == A766ItemAdicionalId ) )
                  {
                     BRKGZ5 = false;
                     A767ItemAdicionalNombre = P00GZ5_A767ItemAdicionalNombre[0];
                     A768ItemAdicionalCantidad = P00GZ5_A768ItemAdicionalCantidad[0];
                     A767ItemAdicionalNombre = P00GZ5_A767ItemAdicionalNombre[0];
                     HGZ0( false, 23) ;
                     getPrinter().GxDrawLine(40, Gx_line+19, 780, Gx_line+19, 1, 220, 220, 220, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A768ItemAdicionalCantidad), "ZZZ9")), 373, Gx_line+1, 486, Gx_line+16, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A767ItemAdicionalNombre, "")), 43, Gx_line+1, 340, Gx_line+16, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+23);
                     BRKGZ5 = true;
                     pr_default.readNext(3);
                  }
                  if ( ! BRKGZ5 )
                  {
                     BRKGZ5 = true;
                     pr_default.readNext(3);
                  }
               }
               pr_default.close(3);
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HGZ0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      protected void HGZ0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
         add_metrics1( ) ;
         add_metrics2( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics2( )
      {
         getPrinter().setMetrics("Mongolian Baiti", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if (IsMain)	waitPrinterEnd();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         GXKey = "";
         GXDecQS = "";
         gxfirstwebparm = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV31Solicitudes = new SdtSolicitudes(context);
         AV47MetodoPagosNombre = "";
         P00GZ2_A743TipoInmuebleOrigenId = new short[1] ;
         P00GZ2_A745TipoInmuebleDestinoId = new short[1] ;
         P00GZ2_A747TipoEstacionamOrigenId = new short[1] ;
         P00GZ2_A749TipoEstacionamDestinoId = new short[1] ;
         P00GZ2_A735MudanzaId = new long[1] ;
         P00GZ2_A765MudanzaCargaVolumenEstimado = new decimal[1] ;
         P00GZ2_A764MudanzaPrecioFinal = new decimal[1] ;
         P00GZ2_A739MudanzaHoraServicio = new string[] {""} ;
         P00GZ2_n739MudanzaHoraServicio = new bool[] {false} ;
         P00GZ2_A776MudanzaRgoHoraservicio = new string[] {""} ;
         P00GZ2_n776MudanzaRgoHoraservicio = new bool[] {false} ;
         P00GZ2_A784MudanzaApellidoNombre = new string[] {""} ;
         P00GZ2_A785MudanzaMail = new string[] {""} ;
         P00GZ2_A786MudanzaPhone = new string[] {""} ;
         P00GZ2_A738MudanzaFechaServicio = new DateTime[] {DateTime.MinValue} ;
         P00GZ2_A740MudanzaDireccionOrigen = new string[] {""} ;
         P00GZ2_A741MudanzaDireccionDestino = new string[] {""} ;
         P00GZ2_A777MudanzaPisoDptoOrigen = new string[] {""} ;
         P00GZ2_A778MudanzaPisoDptoDestino = new string[] {""} ;
         P00GZ2_A794MudanzaOrigenMetodo = new string[] {""} ;
         P00GZ2_A795MudanzaDestinoMetodo = new string[] {""} ;
         P00GZ2_A755TipoInmuebleOrigenNombre = new string[] {""} ;
         P00GZ2_A746TipoInmuebleDestinoNombre = new string[] {""} ;
         P00GZ2_A748TipoEstacionamOrigenNombre = new string[] {""} ;
         P00GZ2_A750TipoEstacionamDestinoNombre = new string[] {""} ;
         P00GZ2_A783MudanzaComentario = new string[] {""} ;
         P00GZ2_A742MudanzaVehiculoSugerido = new string[] {""} ;
         A739MudanzaHoraServicio = "";
         A776MudanzaRgoHoraservicio = "";
         A784MudanzaApellidoNombre = "";
         A785MudanzaMail = "";
         A786MudanzaPhone = "";
         A738MudanzaFechaServicio = DateTime.MinValue;
         A740MudanzaDireccionOrigen = "";
         A741MudanzaDireccionDestino = "";
         A777MudanzaPisoDptoOrigen = "";
         A778MudanzaPisoDptoDestino = "";
         A794MudanzaOrigenMetodo = "";
         A795MudanzaDestinoMetodo = "";
         A755TipoInmuebleOrigenNombre = "";
         A746TipoInmuebleDestinoNombre = "";
         A748TipoEstacionamOrigenNombre = "";
         A750TipoEstacionamDestinoNombre = "";
         A783MudanzaComentario = "";
         A742MudanzaVehiculoSugerido = "";
         AV18Hora = "";
         P00GZ3_A751ItemCargaId = new short[1] ;
         P00GZ3_A753ItemCargaCantidad = new short[1] ;
         P00GZ3_A735MudanzaId = new long[1] ;
         P00GZ3_A813ItemCargaEmbCant = new short[1] ;
         P00GZ3_n813ItemCargaEmbCant = new bool[] {false} ;
         P00GZ3_A814ItemCargaElevCant = new short[1] ;
         P00GZ3_n814ItemCargaElevCant = new bool[] {false} ;
         P00GZ3_A841ItemCargaDescripcion = new string[] {""} ;
         P00GZ3_A752ItemCargaNombre = new string[] {""} ;
         A841ItemCargaDescripcion = "";
         A752ItemCargaNombre = "";
         P00GZ4_AV52Count = new short[1] ;
         P00GZ5_A766ItemAdicionalId = new short[1] ;
         P00GZ5_A735MudanzaId = new long[1] ;
         P00GZ5_A767ItemAdicionalNombre = new string[] {""} ;
         P00GZ5_A768ItemAdicionalCantidad = new short[1] ;
         A767ItemAdicionalNombre = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aremitomudanza2__default(),
            new Object[][] {
                new Object[] {
               P00GZ2_A743TipoInmuebleOrigenId, P00GZ2_A745TipoInmuebleDestinoId, P00GZ2_A747TipoEstacionamOrigenId, P00GZ2_A749TipoEstacionamDestinoId, P00GZ2_A735MudanzaId, P00GZ2_A765MudanzaCargaVolumenEstimado, P00GZ2_A764MudanzaPrecioFinal, P00GZ2_A739MudanzaHoraServicio, P00GZ2_n739MudanzaHoraServicio, P00GZ2_A776MudanzaRgoHoraservicio,
               P00GZ2_n776MudanzaRgoHoraservicio, P00GZ2_A784MudanzaApellidoNombre, P00GZ2_A785MudanzaMail, P00GZ2_A786MudanzaPhone, P00GZ2_A738MudanzaFechaServicio, P00GZ2_A740MudanzaDireccionOrigen, P00GZ2_A741MudanzaDireccionDestino, P00GZ2_A777MudanzaPisoDptoOrigen, P00GZ2_A778MudanzaPisoDptoDestino, P00GZ2_A794MudanzaOrigenMetodo,
               P00GZ2_A795MudanzaDestinoMetodo, P00GZ2_A755TipoInmuebleOrigenNombre, P00GZ2_A746TipoInmuebleDestinoNombre, P00GZ2_A748TipoEstacionamOrigenNombre, P00GZ2_A750TipoEstacionamDestinoNombre, P00GZ2_A783MudanzaComentario, P00GZ2_A742MudanzaVehiculoSugerido
               }
               , new Object[] {
               P00GZ3_A751ItemCargaId, P00GZ3_A753ItemCargaCantidad, P00GZ3_A735MudanzaId, P00GZ3_A813ItemCargaEmbCant, P00GZ3_n813ItemCargaEmbCant, P00GZ3_A814ItemCargaElevCant, P00GZ3_n814ItemCargaElevCant, P00GZ3_A841ItemCargaDescripcion, P00GZ3_A752ItemCargaNombre
               }
               , new Object[] {
               P00GZ4_AV52Count
               }
               , new Object[] {
               P00GZ5_A766ItemAdicionalId, P00GZ5_A735MudanzaId, P00GZ5_A767ItemAdicionalNombre, P00GZ5_A768ItemAdicionalCantidad
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         Gx_time = context.localUtil.Time( );
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         Gx_time = context.localUtil.Time( );
      }

      private short GxWebError ;
      private short nGotPars ;
      private short A743TipoInmuebleOrigenId ;
      private short A745TipoInmuebleDestinoId ;
      private short A747TipoEstacionamOrigenId ;
      private short A749TipoEstacionamDestinoId ;
      private short A751ItemCargaId ;
      private short A753ItemCargaCantidad ;
      private short A813ItemCargaEmbCant ;
      private short A814ItemCargaElevCant ;
      private short AV45Embalaje ;
      private short AV46Elevacion ;
      private short AV52Count ;
      private short cV52Count ;
      private short A766ItemAdicionalId ;
      private short A768ItemAdicionalCantidad ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private long AV32SolicitudesID ;
      private long AV22MudanzaId ;
      private long A735MudanzaId ;
      private decimal A765MudanzaCargaVolumenEstimado ;
      private decimal A764MudanzaPrecioFinal ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string Gx_time ;
      private string AV47MetodoPagosNombre ;
      private string A739MudanzaHoraServicio ;
      private string A776MudanzaRgoHoraservicio ;
      private string A786MudanzaPhone ;
      private string A777MudanzaPisoDptoOrigen ;
      private string A778MudanzaPisoDptoDestino ;
      private DateTime Gx_date ;
      private DateTime A738MudanzaFechaServicio ;
      private bool entryPointCalled ;
      private bool n739MudanzaHoraServicio ;
      private bool n776MudanzaRgoHoraservicio ;
      private bool n813ItemCargaEmbCant ;
      private bool n814ItemCargaElevCant ;
      private bool BRKGZ5 ;
      private string A784MudanzaApellidoNombre ;
      private string A785MudanzaMail ;
      private string A740MudanzaDireccionOrigen ;
      private string A741MudanzaDireccionDestino ;
      private string A794MudanzaOrigenMetodo ;
      private string A795MudanzaDestinoMetodo ;
      private string A755TipoInmuebleOrigenNombre ;
      private string A746TipoInmuebleDestinoNombre ;
      private string A748TipoEstacionamOrigenNombre ;
      private string A750TipoEstacionamDestinoNombre ;
      private string A783MudanzaComentario ;
      private string A742MudanzaVehiculoSugerido ;
      private string AV18Hora ;
      private string A841ItemCargaDescripcion ;
      private string A752ItemCargaNombre ;
      private string A767ItemAdicionalNombre ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private long aP0_SolicitudesID ;
      private SdtSolicitudes AV31Solicitudes ;
      private IDataStoreProvider pr_default ;
      private short[] P00GZ2_A743TipoInmuebleOrigenId ;
      private short[] P00GZ2_A745TipoInmuebleDestinoId ;
      private short[] P00GZ2_A747TipoEstacionamOrigenId ;
      private short[] P00GZ2_A749TipoEstacionamDestinoId ;
      private long[] P00GZ2_A735MudanzaId ;
      private decimal[] P00GZ2_A765MudanzaCargaVolumenEstimado ;
      private decimal[] P00GZ2_A764MudanzaPrecioFinal ;
      private string[] P00GZ2_A739MudanzaHoraServicio ;
      private bool[] P00GZ2_n739MudanzaHoraServicio ;
      private string[] P00GZ2_A776MudanzaRgoHoraservicio ;
      private bool[] P00GZ2_n776MudanzaRgoHoraservicio ;
      private string[] P00GZ2_A784MudanzaApellidoNombre ;
      private string[] P00GZ2_A785MudanzaMail ;
      private string[] P00GZ2_A786MudanzaPhone ;
      private DateTime[] P00GZ2_A738MudanzaFechaServicio ;
      private string[] P00GZ2_A740MudanzaDireccionOrigen ;
      private string[] P00GZ2_A741MudanzaDireccionDestino ;
      private string[] P00GZ2_A777MudanzaPisoDptoOrigen ;
      private string[] P00GZ2_A778MudanzaPisoDptoDestino ;
      private string[] P00GZ2_A794MudanzaOrigenMetodo ;
      private string[] P00GZ2_A795MudanzaDestinoMetodo ;
      private string[] P00GZ2_A755TipoInmuebleOrigenNombre ;
      private string[] P00GZ2_A746TipoInmuebleDestinoNombre ;
      private string[] P00GZ2_A748TipoEstacionamOrigenNombre ;
      private string[] P00GZ2_A750TipoEstacionamDestinoNombre ;
      private string[] P00GZ2_A783MudanzaComentario ;
      private string[] P00GZ2_A742MudanzaVehiculoSugerido ;
      private short[] P00GZ3_A751ItemCargaId ;
      private short[] P00GZ3_A753ItemCargaCantidad ;
      private long[] P00GZ3_A735MudanzaId ;
      private short[] P00GZ3_A813ItemCargaEmbCant ;
      private bool[] P00GZ3_n813ItemCargaEmbCant ;
      private short[] P00GZ3_A814ItemCargaElevCant ;
      private bool[] P00GZ3_n814ItemCargaElevCant ;
      private string[] P00GZ3_A841ItemCargaDescripcion ;
      private string[] P00GZ3_A752ItemCargaNombre ;
      private short[] P00GZ4_AV52Count ;
      private short[] P00GZ5_A766ItemAdicionalId ;
      private long[] P00GZ5_A735MudanzaId ;
      private string[] P00GZ5_A767ItemAdicionalNombre ;
      private short[] P00GZ5_A768ItemAdicionalCantidad ;
   }

   public class aremitomudanza2__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00GZ2;
          prmP00GZ2 = new Object[] {
          new ParDef("@AV22MudanzaId",GXType.Decimal,18,0)
          };
          Object[] prmP00GZ3;
          prmP00GZ3 = new Object[] {
          new ParDef("@AV22MudanzaId",GXType.Decimal,18,0)
          };
          Object[] prmP00GZ4;
          prmP00GZ4 = new Object[] {
          new ParDef("@AV22MudanzaId",GXType.Decimal,18,0)
          };
          Object[] prmP00GZ5;
          prmP00GZ5 = new Object[] {
          new ParDef("@AV22MudanzaId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GZ2", "SELECT T1.[TipoInmuebleOrigenId] AS TipoInmuebleOrigenId, T1.[TipoInmuebleDestinoId] AS TipoInmuebleDestinoId, T1.[TipoEstacionamOrigenId] AS TipoEstacionamOrigenId, T1.[TipoEstacionamDestinoId] AS TipoEstacionamDestinoId, T1.[MudanzaId], T1.[MudanzaCargaVolumenEstimado], T1.[MudanzaPrecioFinal], T1.[MudanzaHoraServicio], T1.[MudanzaRgoHoraservicio], T1.[MudanzaApellidoNombre], T1.[MudanzaMail], T1.[MudanzaPhone], T1.[MudanzaFechaServicio], T1.[MudanzaDireccionOrigen], T1.[MudanzaDireccionDestino], T1.[MudanzaPisoDptoOrigen], T1.[MudanzaPisoDptoDestino], T1.[MudanzaOrigenMetodo], T1.[MudanzaDestinoMetodo], T2.[ParametroMudanzaNombre] AS TipoInmuebleOrigenNombre, T3.[ParametroMudanzaNombre] AS TipoInmuebleDestinoNombre, T4.[ParametroMudanzaNombre] AS TipoEstacionamOrigenNombre, T5.[ParametroMudanzaNombre] AS TipoEstacionamDestinoNombre, T1.[MudanzaComentario], T1.[MudanzaVehiculoSugerido] FROM (((([Mudanza] T1 INNER JOIN [ParametroMudanza] T2 ON T2.[ParametroMudanzaId] = T1.[TipoInmuebleOrigenId]) INNER JOIN [ParametroMudanza] T3 ON T3.[ParametroMudanzaId] = T1.[TipoInmuebleDestinoId]) INNER JOIN [ParametroMudanza] T4 ON T4.[ParametroMudanzaId] = T1.[TipoEstacionamOrigenId]) INNER JOIN [ParametroMudanza] T5 ON T5.[ParametroMudanzaId] = T1.[TipoEstacionamDestinoId]) WHERE T1.[MudanzaId] = @AV22MudanzaId ORDER BY T1.[MudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GZ2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00GZ3", "SELECT T1.[ItemCargaId] AS ItemCargaId, T1.[ItemCargaCantidad], T1.[MudanzaId], T1.[ItemCargaEmbCant], T1.[ItemCargaElevCant], T2.[ParametroMudanzaDescripcion] AS ItemCargaDescripcion, T2.[ParametroMudanzaNombre] AS ItemCargaNombre FROM ([MudanzaCarga] T1 INNER JOIN [ParametroMudanza] T2 ON T2.[ParametroMudanzaId] = T1.[ItemCargaId]) WHERE (T1.[MudanzaId] = @AV22MudanzaId) AND (T1.[ItemCargaCantidad] > 0) ORDER BY T1.[MudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GZ3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00GZ4", "SELECT COUNT(*) FROM [MudanzaAdicional] WHERE ([MudanzaId] = @AV22MudanzaId) AND ([ItemAdicionalCantidad] > 0) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GZ4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GZ5", "SELECT T1.[ItemAdicionalId] AS ItemAdicionalId, T1.[MudanzaId], T2.[ParametroMudanzaNombre] AS ItemAdicionalNombre, T1.[ItemAdicionalCantidad] FROM ([MudanzaAdicional] T1 INNER JOIN [ParametroMudanza] T2 ON T2.[ParametroMudanzaId] = T1.[ItemAdicionalId]) WHERE (T1.[MudanzaId] = @AV22MudanzaId) AND (T1.[ItemAdicionalCantidad] > 0) ORDER BY T1.[MudanzaId], T1.[ItemAdicionalId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GZ5,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 2);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 5);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((string[]) buf[12])[0] = rslt.getVarchar(11);
                ((string[]) buf[13])[0] = rslt.getString(12, 20);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(13);
                ((string[]) buf[15])[0] = rslt.getVarchar(14);
                ((string[]) buf[16])[0] = rslt.getVarchar(15);
                ((string[]) buf[17])[0] = rslt.getString(16, 30);
                ((string[]) buf[18])[0] = rslt.getString(17, 30);
                ((string[]) buf[19])[0] = rslt.getVarchar(18);
                ((string[]) buf[20])[0] = rslt.getVarchar(19);
                ((string[]) buf[21])[0] = rslt.getVarchar(20);
                ((string[]) buf[22])[0] = rslt.getVarchar(21);
                ((string[]) buf[23])[0] = rslt.getVarchar(22);
                ((string[]) buf[24])[0] = rslt.getVarchar(23);
                ((string[]) buf[25])[0] = rslt.getVarchar(24);
                ((string[]) buf[26])[0] = rslt.getVarchar(25);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
       }
    }

 }

}
