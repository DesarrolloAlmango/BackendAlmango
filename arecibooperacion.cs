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
   public class arecibooperacion : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "arecibooperacion.aspx")), "arecibooperacion.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "arecibooperacion.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "OperacionesIdNew");
            if ( ! entryPointCalled )
            {
               AV11OperacionesIdNew = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV10OperacionesId = (long)(Math.Round(NumberUtil.Val( GetPar( "OperacionesId"), "."), 18, MidpointRounding.ToEven));
                  AV15TipoEntidad = GetPar( "TipoEntidad");
                  AV33OperacionesRef = GetPar( "OperacionesRef");
                  AV32NombreRef = GetPar( "NombreRef");
                  AV16TipoOperacion = GetPar( "TipoOperacion");
                  AV12OperacionesImporte = NumberUtil.Val( GetPar( "OperacionesImporte"), ".");
               }
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public arecibooperacion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public arecibooperacion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_OperacionesIdNew ,
                           long aP1_OperacionesId ,
                           string aP2_TipoEntidad ,
                           string aP3_OperacionesRef ,
                           string aP4_NombreRef ,
                           string aP5_TipoOperacion ,
                           decimal aP6_OperacionesImporte )
      {
         this.AV11OperacionesIdNew = aP0_OperacionesIdNew;
         this.AV10OperacionesId = aP1_OperacionesId;
         this.AV15TipoEntidad = aP2_TipoEntidad;
         this.AV33OperacionesRef = aP3_OperacionesRef;
         this.AV32NombreRef = aP4_NombreRef;
         this.AV16TipoOperacion = aP5_TipoOperacion;
         this.AV12OperacionesImporte = aP6_OperacionesImporte;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_OperacionesIdNew ,
                                 long aP1_OperacionesId ,
                                 string aP2_TipoEntidad ,
                                 string aP3_OperacionesRef ,
                                 string aP4_NombreRef ,
                                 string aP5_TipoOperacion ,
                                 decimal aP6_OperacionesImporte )
      {
         this.AV11OperacionesIdNew = aP0_OperacionesIdNew;
         this.AV10OperacionesId = aP1_OperacionesId;
         this.AV15TipoEntidad = aP2_TipoEntidad;
         this.AV33OperacionesRef = aP3_OperacionesRef;
         this.AV32NombreRef = aP4_NombreRef;
         this.AV16TipoOperacion = aP5_TipoOperacion;
         this.AV12OperacionesImporte = aP6_OperacionesImporte;
         SubmitImpl();
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
         setOutputFileName("ReciboOperacion");
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
            if ( ( AV12OperacionesImporte < Convert.ToDecimal( 0 )) )
            {
               AV8Importe = (decimal)(AV12OperacionesImporte*-1);
            }
            else
            {
               AV8Importe = AV12OperacionesImporte;
            }
            AV9Operacion = context.GetMessage( gxdomaintipooperacionenum.getDescription(context,AV16TipoOperacion), "");
            AV31Titulo = StringUtil.Format( context.GetMessage( "Recibo Operación N° %1", ""), StringUtil.Trim( StringUtil.Str( (decimal)(AV11OperacionesIdNew), 18, 0)), "", "", "", "", "", "", "", "");
            AV13OperacionesNombreRef = StringUtil.Format( context.GetMessage( "IDENTIFICADOR: %1 - NOMBRE: %2", ""), AV33OperacionesRef, AV32NombreRef, "", "", "", "", "", "", "");
            HD30( false, 127) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 714, Gx_line+33, 790, Gx_line+47, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 660, Gx_line+33, 699, Gx_line+47, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Fecha", ""), 661, Gx_line+13, 810, Gx_line+27, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 14, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9Operacion, "")), 300, Gx_line+33, 581, Gx_line+59, 1, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31Titulo, "")), 225, Gx_line+67, 642, Gx_line+89, 1, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 105, 105, 105, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Control de Solicitudes de Servicios a Domicilio", ""), 16, Gx_line+75, 223, Gx_line+89, 0, 0, 0, 0) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "e6acfd2e-013a-4b78-9d37-37f6dc906ba7", "", context.GetTheme( )), 7, Gx_line+11, 195, Gx_line+74) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+127);
            HD30( false, 54) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Liquidación:", ""), 27, Gx_line+13, 100, Gx_line+26, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(27, Gx_line+27, 807, Gx_line+27, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(27, Gx_line+0, 807, Gx_line+0, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "IMPORTE", ""), 700, Gx_line+40, 807, Gx_line+53, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13OperacionesNombreRef, "")), 225, Gx_line+13, 658, Gx_line+28, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV10OperacionesId), "ZZZZZZZZZZZZZZZZZ9")), 97, Gx_line+13, 184, Gx_line+28, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "SOLICITUD", ""), 27, Gx_line+40, 114, Gx_line+54, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "PRECIO", ""), 287, Gx_line+40, 354, Gx_line+54, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "CLIENTE", ""), 113, Gx_line+40, 200, Gx_line+54, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "ALM", ""), 367, Gx_line+40, 427, Gx_line+54, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "COM", ""), 441, Gx_line+40, 508, Gx_line+54, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "PROF", ""), 524, Gx_line+40, 591, Gx_line+54, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "PAGADO", ""), 616, Gx_line+40, 689, Gx_line+54, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+54);
            /* Using cursor P00D32 */
            pr_default.execute(0, new Object[] {AV10OperacionesId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A554OperacionesId = P00D32_A554OperacionesId[0];
               /* Using cursor P00D33 */
               pr_default.execute(1, new Object[] {A554OperacionesId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A650OperacionesSolicitudesId = P00D33_A650OperacionesSolicitudesId[0];
                  A651OperacionesSolicitudesNombre = P00D33_A651OperacionesSolicitudesNombre[0];
                  n651OperacionesSolicitudesNombre = P00D33_n651OperacionesSolicitudesNombre[0];
                  A654OperacionesSolicitudesPFinal = P00D33_A654OperacionesSolicitudesPFinal[0];
                  n654OperacionesSolicitudesPFinal = P00D33_n654OperacionesSolicitudesPFinal[0];
                  A656OperacionesSolicitudesComALM = P00D33_A656OperacionesSolicitudesComALM[0];
                  n656OperacionesSolicitudesComALM = P00D33_n656OperacionesSolicitudesComALM[0];
                  A653OperacionesSolicitudesComPro = P00D33_A653OperacionesSolicitudesComPro[0];
                  n653OperacionesSolicitudesComPro = P00D33_n653OperacionesSolicitudesComPro[0];
                  A655OperacionesSolicitudesComProv = P00D33_A655OperacionesSolicitudesComProv[0];
                  n655OperacionesSolicitudesComProv = P00D33_n655OperacionesSolicitudesComProv[0];
                  A668OperacionesSolicitudesOrigenPa = P00D33_A668OperacionesSolicitudesOrigenPa[0];
                  n668OperacionesSolicitudesOrigenPa = P00D33_n668OperacionesSolicitudesOrigenPa[0];
                  AV28CobrosProf = 0;
                  AV25CobrosComercio = 0;
                  AV27TotalComisiones = 0;
                  AV18SolicitudId = A650OperacionesSolicitudesId;
                  AV24Nombre = A651OperacionesSolicitudesNombre;
                  AV19PrecioFinal = A654OperacionesSolicitudesPFinal;
                  AV21ComALM = A656OperacionesSolicitudesComALM;
                  AV23ComPro = A653OperacionesSolicitudesComPro;
                  AV20ComProv = A655OperacionesSolicitudesComProv;
                  AV22OrigenPago = context.GetMessage( gxdomainorigenpago.getDescription(context,A668OperacionesSolicitudesOrigenPa), "");
                  if ( StringUtil.StrCmp(A668OperacionesSolicitudesOrigenPa, "F") == 0 )
                  {
                     AV28CobrosProf = AV19PrecioFinal;
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(A668OperacionesSolicitudesOrigenPa, "T") == 0 )
                     {
                        AV25CobrosComercio = AV19PrecioFinal;
                     }
                  }
                  if ( StringUtil.StrCmp(AV15TipoEntidad, "COM") == 0 )
                  {
                     AV27TotalComisiones = (decimal)(AV26TotalComisionProveedor-AV25CobrosComercio);
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(AV15TipoEntidad, "PRO") == 0 )
                     {
                        AV27TotalComisiones = (decimal)(AV19PrecioFinal-AV23ComPro-AV21ComALM-AV28CobrosProf);
                     }
                  }
                  HD30( false, 30) ;
                  getPrinter().GxDrawLine(27, Gx_line+27, 807, Gx_line+27, 1, 220, 220, 220, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18SolicitudId), "ZZZZZZZZZZZZZZZZZ9")), 27, Gx_line+0, 107, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24Nombre, "")), 113, Gx_line+0, 273, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV19PrecioFinal, "ZZZZZZZZZZZZZZ9.99")), 287, Gx_line+0, 354, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV21ComALM, "ZZZZZZZZZZZZZZ9.99")), 367, Gx_line+0, 427, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV23ComPro, "ZZZZZZZZZZZZZZ9.99")), 524, Gx_line+0, 603, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV20ComProv, "ZZZZZZZZZZZZZZ9.99")), 441, Gx_line+0, 501, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22OrigenPago, "")), 616, Gx_line+0, 689, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV27TotalComisiones, "ZZZZZZZZZZZZZZ9.99")), 693, Gx_line+0, 807, Gx_line+15, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            HD30( false, 72) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 70, 130, 180, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Dirección: Eduardo Acevedo 1310 Montevideo, Uruguay  ", ""), 25, Gx_line+17, 550, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Teléfono: +598 92612655   ", ""), 25, Gx_line+25, 550, Gx_line+33, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Email: info@almango.com.uy   ", ""), 25, Gx_line+33, 550, Gx_line+41, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Website: www.almango.com.uy", ""), 25, Gx_line+41, 550, Gx_line+49, 0+16, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Total", ""), 657, Gx_line+27, 686, Gx_line+43, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(27, Gx_line+12, 807, Gx_line+12, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(27, Gx_line+63, 807, Gx_line+63, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV8Importe, "ZZZZZZZZZZZZZZ9.99")), 693, Gx_line+27, 825, Gx_line+44, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+72);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HD30( true, 0) ;
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

      protected void HD30( bool bFoot ,
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
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
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
         AV9Operacion = "";
         AV31Titulo = "";
         AV13OperacionesNombreRef = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         P00D32_A554OperacionesId = new long[1] ;
         P00D33_A554OperacionesId = new long[1] ;
         P00D33_A650OperacionesSolicitudesId = new long[1] ;
         P00D33_A651OperacionesSolicitudesNombre = new string[] {""} ;
         P00D33_n651OperacionesSolicitudesNombre = new bool[] {false} ;
         P00D33_A654OperacionesSolicitudesPFinal = new decimal[1] ;
         P00D33_n654OperacionesSolicitudesPFinal = new bool[] {false} ;
         P00D33_A656OperacionesSolicitudesComALM = new decimal[1] ;
         P00D33_n656OperacionesSolicitudesComALM = new bool[] {false} ;
         P00D33_A653OperacionesSolicitudesComPro = new decimal[1] ;
         P00D33_n653OperacionesSolicitudesComPro = new bool[] {false} ;
         P00D33_A655OperacionesSolicitudesComProv = new decimal[1] ;
         P00D33_n655OperacionesSolicitudesComProv = new bool[] {false} ;
         P00D33_A668OperacionesSolicitudesOrigenPa = new string[] {""} ;
         P00D33_n668OperacionesSolicitudesOrigenPa = new bool[] {false} ;
         A651OperacionesSolicitudesNombre = "";
         A668OperacionesSolicitudesOrigenPa = "";
         AV24Nombre = "";
         AV22OrigenPago = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.arecibooperacion__default(),
            new Object[][] {
                new Object[] {
               P00D32_A554OperacionesId
               }
               , new Object[] {
               P00D33_A554OperacionesId, P00D33_A650OperacionesSolicitudesId, P00D33_A651OperacionesSolicitudesNombre, P00D33_n651OperacionesSolicitudesNombre, P00D33_A654OperacionesSolicitudesPFinal, P00D33_n654OperacionesSolicitudesPFinal, P00D33_A656OperacionesSolicitudesComALM, P00D33_n656OperacionesSolicitudesComALM, P00D33_A653OperacionesSolicitudesComPro, P00D33_n653OperacionesSolicitudesComPro,
               P00D33_A655OperacionesSolicitudesComProv, P00D33_n655OperacionesSolicitudesComProv, P00D33_A668OperacionesSolicitudesOrigenPa, P00D33_n668OperacionesSolicitudesOrigenPa
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
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private long AV11OperacionesIdNew ;
      private long AV10OperacionesId ;
      private long A554OperacionesId ;
      private long A650OperacionesSolicitudesId ;
      private long AV18SolicitudId ;
      private decimal AV12OperacionesImporte ;
      private decimal AV8Importe ;
      private decimal A654OperacionesSolicitudesPFinal ;
      private decimal A656OperacionesSolicitudesComALM ;
      private decimal A653OperacionesSolicitudesComPro ;
      private decimal A655OperacionesSolicitudesComProv ;
      private decimal AV28CobrosProf ;
      private decimal AV25CobrosComercio ;
      private decimal AV27TotalComisiones ;
      private decimal AV19PrecioFinal ;
      private decimal AV21ComALM ;
      private decimal AV23ComPro ;
      private decimal AV20ComProv ;
      private decimal AV26TotalComisionProveedor ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV15TipoEntidad ;
      private string AV33OperacionesRef ;
      private string AV32NombreRef ;
      private string AV16TipoOperacion ;
      private string AV31Titulo ;
      private string AV13OperacionesNombreRef ;
      private string Gx_time ;
      private string A651OperacionesSolicitudesNombre ;
      private string A668OperacionesSolicitudesOrigenPa ;
      private string AV24Nombre ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool n651OperacionesSolicitudesNombre ;
      private bool n654OperacionesSolicitudesPFinal ;
      private bool n656OperacionesSolicitudesComALM ;
      private bool n653OperacionesSolicitudesComPro ;
      private bool n655OperacionesSolicitudesComProv ;
      private bool n668OperacionesSolicitudesOrigenPa ;
      private string AV9Operacion ;
      private string AV22OrigenPago ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00D32_A554OperacionesId ;
      private long[] P00D33_A554OperacionesId ;
      private long[] P00D33_A650OperacionesSolicitudesId ;
      private string[] P00D33_A651OperacionesSolicitudesNombre ;
      private bool[] P00D33_n651OperacionesSolicitudesNombre ;
      private decimal[] P00D33_A654OperacionesSolicitudesPFinal ;
      private bool[] P00D33_n654OperacionesSolicitudesPFinal ;
      private decimal[] P00D33_A656OperacionesSolicitudesComALM ;
      private bool[] P00D33_n656OperacionesSolicitudesComALM ;
      private decimal[] P00D33_A653OperacionesSolicitudesComPro ;
      private bool[] P00D33_n653OperacionesSolicitudesComPro ;
      private decimal[] P00D33_A655OperacionesSolicitudesComProv ;
      private bool[] P00D33_n655OperacionesSolicitudesComProv ;
      private string[] P00D33_A668OperacionesSolicitudesOrigenPa ;
      private bool[] P00D33_n668OperacionesSolicitudesOrigenPa ;
   }

   public class arecibooperacion__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00D32;
          prmP00D32 = new Object[] {
          new ParDef("@AV10OperacionesId",GXType.Decimal,18,0)
          };
          Object[] prmP00D33;
          prmP00D33 = new Object[] {
          new ParDef("@OperacionesId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00D32", "SELECT [OperacionesId] FROM [Operaciones] WHERE [OperacionesId] = @AV10OperacionesId ORDER BY [OperacionesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D32,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00D33", "SELECT [OperacionesId], [OperacionesSolicitudesId], [OperacionesSolicitudesNombre], [OperacionesSolicitudesPFinal], [OperacionesSolicitudesComALM], [OperacionesSolicitudesComPro], [OperacionesSolicitudesComProv], [OperacionesSolicitudesOrigenPa] FROM [OperacionesSolicitudes] WHERE [OperacionesId] = @OperacionesId ORDER BY [OperacionesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D33,100, GxCacheFrequency.OFF ,false,false )
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
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 120);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((string[]) buf[12])[0] = rslt.getString(8, 1);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                return;
       }
    }

 }

}
