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
   public class reportecomisionesalmg : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "EstadosGenericosID");
            if ( ! entryPointCalled )
            {
               AV65EstadosGenericosID = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV14Desde = context.localUtil.ParseDateParm( GetPar( "Desde"));
                  AV19Hasta = context.localUtil.ParseDateParm( GetPar( "Hasta"));
                  AV66FechaFiltro = GetPar( "FechaFiltro");
                  AV52SolicitudServicioOrigenPago = GetPar( "SolicitudServicioOrigenPago");
                  AV67SecUserIdJson = GetPar( "SecUserIdJson");
                  AV63String = GetPar( "String");
               }
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public reportecomisionesalmg( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reportecomisionesalmg( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_EstadosGenericosID ,
                           DateTime aP1_Desde ,
                           DateTime aP2_Hasta ,
                           string aP3_FechaFiltro ,
                           string aP4_SolicitudServicioOrigenPago ,
                           string aP5_SecUserIdJson ,
                           string aP6_String )
      {
         this.AV65EstadosGenericosID = aP0_EstadosGenericosID;
         this.AV14Desde = aP1_Desde;
         this.AV19Hasta = aP2_Hasta;
         this.AV66FechaFiltro = aP3_FechaFiltro;
         this.AV52SolicitudServicioOrigenPago = aP4_SolicitudServicioOrigenPago;
         this.AV67SecUserIdJson = aP5_SecUserIdJson;
         this.AV63String = aP6_String;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( int aP0_EstadosGenericosID ,
                                 DateTime aP1_Desde ,
                                 DateTime aP2_Hasta ,
                                 string aP3_FechaFiltro ,
                                 string aP4_SolicitudServicioOrigenPago ,
                                 string aP5_SecUserIdJson ,
                                 string aP6_String )
      {
         this.AV65EstadosGenericosID = aP0_EstadosGenericosID;
         this.AV14Desde = aP1_Desde;
         this.AV19Hasta = aP2_Hasta;
         this.AV66FechaFiltro = aP3_FechaFiltro;
         this.AV52SolicitudServicioOrigenPago = aP4_SolicitudServicioOrigenPago;
         this.AV67SecUserIdJson = aP5_SecUserIdJson;
         this.AV63String = aP6_String;
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
         setOutputFileName("ReporteComisiones");
         setOutputType("PDF");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 17179, 0, 1, 1, 0, 1, 1) )
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
            AV59SecUserID.FromJSonString(AV67SecUserIdJson, null);
            AV61cProveedorID.FromJSonString(AV63String, null);
            AV22LabelRango = StringUtil.Format( context.GetMessage( "Rango de fecha %1 al %2", ""), context.localUtil.DToC( AV14Desde, 0, "-"), context.localUtil.DToC( AV19Hasta, 0, "-"), "", "", "", "", "", "", "");
            if ( AV61cProveedorID.Count == 0 )
            {
               /* Execute user subroutine: 'LISTAR' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else
            {
               AV62i = 1;
               AV64contador = (short)(AV61cProveedorID.Count);
               while ( AV62i <= AV64contador )
               {
                  AV31ProveedorID = (long)(AV61cProveedorID.GetNumeric(AV62i));
                  if ( AV31ProveedorID == 0 )
                  {
                     if (true) break;
                  }
                  /* Execute user subroutine: 'LISTAR' */
                  S111 ();
                  if ( returnInSub )
                  {
                     cleanup();
                     if (true) return;
                  }
                  AV62i = (int)(AV62i+1);
               }
            }
            HFL0( false, 100) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 70, 130, 180, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Dirección: Eduardo Acevedo 1310 Montevideo, Uruguay  ", ""), 75, Gx_line+17, 422, Gx_line+35, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Teléfono: +598 92612655   ", ""), 75, Gx_line+35, 422, Gx_line+53, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Email: info@almango.com.uy   ", ""), 75, Gx_line+53, 422, Gx_line+71, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Website: www.almango.com.uy", ""), 75, Gx_line+71, 422, Gx_line+89, 0, 0, 0, 0) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "22922f7f-f2d4-4fde-abb1-d4ceefcb60c5", "", context.GetTheme( )), 617, Gx_line+33, 749, Gx_line+63) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+100);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HFL0( true, 0) ;
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

      protected void S111( )
      {
         /* 'LISTAR' Routine */
         returnInSub = false;
         AV45TotalAlmango = 0;
         AV51Cantidad = 0;
         AV56Total = 0;
         AV45TotalAlmango = 0;
         AV57OdProveedorID = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A597SolicitudesUsrAlta ,
                                              AV59SecUserID ,
                                              AV66FechaFiltro ,
                                              AV59SecUserID.Count ,
                                              A184SolicitudesFechaInstalacion ,
                                              AV14Desde ,
                                              AV19Hasta ,
                                              A182SolicitudesFechaAlta ,
                                              A133ProveedorID ,
                                              AV31ProveedorID ,
                                              A438SolicitudServicioOrigenPago ,
                                              AV52SolicitudServicioOrigenPago } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00FL2 */
         pr_default.execute(0, new Object[] {AV31ProveedorID, AV31ProveedorID, AV52SolicitudServicioOrigenPago, AV52SolicitudServicioOrigenPago, AV14Desde, AV19Hasta, AV14Desde, AV19Hasta});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A130EstadosSolTipo = P00FL2_A130EstadosSolTipo[0];
            A597SolicitudesUsrAlta = P00FL2_A597SolicitudesUsrAlta[0];
            n597SolicitudesUsrAlta = P00FL2_n597SolicitudesUsrAlta[0];
            A438SolicitudServicioOrigenPago = P00FL2_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = P00FL2_n438SolicitudServicioOrigenPago[0];
            A182SolicitudesFechaAlta = P00FL2_A182SolicitudesFechaAlta[0];
            n182SolicitudesFechaAlta = P00FL2_n182SolicitudesFechaAlta[0];
            A184SolicitudesFechaInstalacion = P00FL2_A184SolicitudesFechaInstalacion[0];
            A133ProveedorID = P00FL2_A133ProveedorID[0];
            A131EstadosSolId = P00FL2_A131EstadosSolId[0];
            A282ProveedorNombre = P00FL2_A282ProveedorNombre[0];
            A127SolicitudesID = P00FL2_A127SolicitudesID[0];
            A171SolicitudesNombre = P00FL2_A171SolicitudesNombre[0];
            A530SolicitudServicioComALM = P00FL2_A530SolicitudServicioComALM[0];
            n530SolicitudServicioComALM = P00FL2_n530SolicitudServicioComALM[0];
            A132EstadosSolNombre = P00FL2_A132EstadosSolNombre[0];
            A796SolicitudesComisionMetodoPago = P00FL2_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = P00FL2_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = P00FL2_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = P00FL2_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = P00FL2_n897SolicitudesDescuento[0];
            A864SolicitudesCostoXZona = P00FL2_A864SolicitudesCostoXZona[0];
            A282ProveedorNombre = P00FL2_A282ProveedorNombre[0];
            A132EstadosSolNombre = P00FL2_A132EstadosSolNombre[0];
            GetSolicitudesTotal( A127SolicitudesID) ;
            if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
            {
               A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
            }
            else
            {
               if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
               {
                  A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
               }
               else
               {
                  if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                  {
                     A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon-A796SolicitudesComisionMetodoPago);
                  }
                  else
                  {
                     if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                     {
                        A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A796SolicitudesComisionMetodoPago-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                     }
                     else
                     {
                        A211SolicitudServicioPFinal = 0;
                     }
                  }
               }
            }
            if ( ( ( AV65EstadosGenericosID == 6 ) && ( ( A131EstadosSolId == 6 ) || ( A131EstadosSolId == 7 ) ) ) || ( ( AV65EstadosGenericosID == 0 ) && ( ( A131EstadosSolId != 4 ) && ( A131EstadosSolId != 3 ) ) ) || ( AV65EstadosGenericosID == A131EstadosSolId ) )
            {
               AV32ProveedorNombre = A282ProveedorNombre;
               if ( AV57OdProveedorID != A133ProveedorID )
               {
                  AV57OdProveedorID = A133ProveedorID;
                  HFL0( false, 18) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32ProveedorNombre, "")), 125, Gx_line+0, 626, Gx_line+17, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "COMERCIO:", ""), 50, Gx_line+2, 133, Gx_line+14, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+18);
               }
               AV33SolicitudesID = A127SolicitudesID;
               AV43Fecha = A182SolicitudesFechaAlta;
               AV24NombreCliente = A171SolicitudesNombre;
               AV20Importe = A211SolicitudServicioPFinal;
               AV52SolicitudServicioOrigenPago = A438SolicitudServicioOrigenPago;
               AV49ComisionALM = A530SolicitudServicioComALM;
               AV16Estado = A132EstadosSolNombre;
               AV51Cantidad = (long)(AV51Cantidad+1);
               AV56Total = (decimal)(AV56Total+A211SolicitudServicioPFinal);
               AV45TotalAlmango = (decimal)(AV45TotalAlmango+A530SolicitudServicioComALM);
               AV58SolicitudesUsrAlta = A597SolicitudesUsrAlta;
               /* Execute user subroutine: 'BUSCAR NOMBRE' */
               S123 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               HFL0( false, 27) ;
               getPrinter().GxDrawLine(42, Gx_line+5, 806, Gx_line+5, 1, 220, 220, 220, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16Estado, "")), 750, Gx_line+6, 829, Gx_line+21, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV20Importe, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 598, Gx_line+6, 737, Gx_line+21, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49ComisionALM, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 530, Gx_line+6, 662, Gx_line+21, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60SecUserName, "")), 439, Gx_line+6, 526, Gx_line+21, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24NombreCliente, "")), 225, Gx_line+6, 413, Gx_line+21, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV33SolicitudesID), "ZZZZZZZZZZZZZZZZZ9")), 117, Gx_line+6, 231, Gx_line+21, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV43Fecha, "99/99/99"), 50, Gx_line+6, 90, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52SolicitudServicioOrigenPago, "")), 928, Gx_line+6, 995, Gx_line+21, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+27);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV51Cantidad > 0 )
         {
            HFL0( false, 79) ;
            getPrinter().GxDrawLine(48, Gx_line+2, 1148, Gx_line+2, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Total ", ""), 638, Gx_line+15, 745, Gx_line+28, 2, 0, 0, 0) ;
            getPrinter().GxDrawLine(48, Gx_line+60, 1148, Gx_line+60, 1, 192, 192, 192, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "ComisionesALM", ""), 497, Gx_line+14, 604, Gx_line+27, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45TotalAlmango, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 472, Gx_line+35, 604, Gx_line+50, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56Total, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 606, Gx_line+33, 745, Gx_line+48, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+79);
         }
      }

      protected void S123( )
      {
         /* 'BUSCAR NOMBRE' Routine */
         returnInSub = false;
         /* Using cursor P00FL3 */
         pr_default.execute(1, new Object[] {AV58SolicitudesUsrAlta});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A18SecUserId = P00FL3_A18SecUserId[0];
            A26SecUserName = P00FL3_A26SecUserName[0];
            AV60SecUserName = A26SecUserName;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
      }

      protected void HFL0( bool bFoot ,
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
               getPrinter().GxDrawBitMap(context.GetImagePath( "e6acfd2e-013a-4b78-9d37-37f6dc906ba7", "", context.GetTheme( )), 17, Gx_line+0, 205, Gx_line+63) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 105, 105, 105, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Control de Solicitudes de Servicios a Domicilio", ""), 25, Gx_line+66, 278, Gx_line+80, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Arial Black", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Reporte Comisiones del Comercio", ""), 208, Gx_line+33, 650, Gx_line+60, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Fecha del Reporte", ""), 650, Gx_line+33, 799, Gx_line+47, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 650, Gx_line+50, 689, Gx_line+64, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 700, Gx_line+50, 776, Gx_line+64, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Arial", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22LabelRango, "")), 219, Gx_line+61, 639, Gx_line+76, 1, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+100);
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 750, Gx_line+0, 812, Gx_line+13, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Cliente", ""), 225, Gx_line+0, 332, Gx_line+13, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Solicitud No.", ""), 117, Gx_line+0, 224, Gx_line+13, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Importe", ""), 675, Gx_line+0, 737, Gx_line+13, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Fecha", ""), 50, Gx_line+0, 112, Gx_line+13, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Almango", ""), 600, Gx_line+0, 662, Gx_line+13, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Usuario de Alta", ""), 439, Gx_line+0, 531, Gx_line+14, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Origen", ""), 916, Gx_line+0, 978, Gx_line+13, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Importe Prof", ""), 995, Gx_line+0, 1078, Gx_line+12, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Nombre Prof", ""), 1100, Gx_line+0, 1175, Gx_line+12, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+17);
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
         add_metrics3( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics2( )
      {
         getPrinter().setMetrics("Arial Black", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics3( )
      {
         getPrinter().setMetrics("Arial", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      protected void GetSolicitudesTotal( long A127SolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A174SolicitudesTotal = 0;
         /* Using cursor P00FL4 */
         pr_default.execute(2, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(2) != 101) && ( P00FL4_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P00FL4_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P00FL4_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P00FL4_A176SolicitudesItemsPrecioFinal[0]*P00FL4_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P00FL4_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00FL4_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P00FL4_A176SolicitudesItemsPrecioFinal[0]*P00FL4_A177SolicitudesItemsCantidad[0])-(P00FL4_A180SolicitudItemsComision[0]*P00FL4_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P00FL4_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00FL4_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P00FL4_A176SolicitudesItemsPrecioFinal[0]*P00FL4_A177SolicitudesItemsCantidad[0])+(P00FL4_A180SolicitudItemsComision[0]*P00FL4_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P00FL4_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00FL4_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P00FL4_A176SolicitudesItemsPrecioFinal[0]*P00FL4_A177SolicitudesItemsCantidad[0])-((P00FL4_A176SolicitudesItemsPrecioFinal[0]*P00FL4_A177SolicitudesItemsCantidad[0])*(P00FL4_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P00FL4_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00FL4_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P00FL4_A176SolicitudesItemsPrecioFinal[0]*P00FL4_A177SolicitudesItemsCantidad[0])+((P00FL4_A176SolicitudesItemsPrecioFinal[0]*P00FL4_A177SolicitudesItemsCantidad[0])*(P00FL4_A180SolicitudItemsComision[0]/ (decimal)(100))));
                        }
                        else
                        {
                           A175SolicitudesItemsPrecioInstalac = 0;
                        }
                     }
                  }
               }
            }
            A174SolicitudesTotal = (decimal)(A174SolicitudesTotal+A175SolicitudesItemsPrecioInstalac);
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      public override void cleanup( )
      {
         CloseCursors();
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
         gxfirstwebparm = "";
         AV59SecUserID = new GxSimpleCollection<long>();
         AV61cProveedorID = new GxSimpleCollection<long>();
         AV22LabelRango = "";
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A182SolicitudesFechaAlta = DateTime.MinValue;
         A438SolicitudServicioOrigenPago = "";
         P00FL2_A130EstadosSolTipo = new string[] {""} ;
         P00FL2_A597SolicitudesUsrAlta = new long[1] ;
         P00FL2_n597SolicitudesUsrAlta = new bool[] {false} ;
         P00FL2_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P00FL2_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P00FL2_A182SolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00FL2_n182SolicitudesFechaAlta = new bool[] {false} ;
         P00FL2_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00FL2_A133ProveedorID = new long[1] ;
         P00FL2_A131EstadosSolId = new int[1] ;
         P00FL2_A282ProveedorNombre = new string[] {""} ;
         P00FL2_A127SolicitudesID = new long[1] ;
         P00FL2_A171SolicitudesNombre = new string[] {""} ;
         P00FL2_A530SolicitudServicioComALM = new decimal[1] ;
         P00FL2_n530SolicitudServicioComALM = new bool[] {false} ;
         P00FL2_A132EstadosSolNombre = new string[] {""} ;
         P00FL2_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P00FL2_A212SolicitudesCotizacion = new decimal[1] ;
         P00FL2_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P00FL2_A897SolicitudesDescuento = new decimal[1] ;
         P00FL2_n897SolicitudesDescuento = new bool[] {false} ;
         P00FL2_A864SolicitudesCostoXZona = new decimal[1] ;
         A130EstadosSolTipo = "";
         A282ProveedorNombre = "";
         A171SolicitudesNombre = "";
         A132EstadosSolNombre = "";
         AV32ProveedorNombre = "";
         AV43Fecha = DateTime.MinValue;
         AV24NombreCliente = "";
         AV16Estado = "";
         AV60SecUserName = "";
         P00FL3_A18SecUserId = new long[1] ;
         P00FL3_A26SecUserName = new string[] {""} ;
         A26SecUserName = "";
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         P00FL4_A127SolicitudesID = new long[1] ;
         P00FL4_A134SolicitudesItemsID = new short[1] ;
         P00FL4_A180SolicitudItemsComision = new decimal[1] ;
         P00FL4_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P00FL4_A178SolicitudItemsSR = new string[] {""} ;
         P00FL4_A177SolicitudesItemsCantidad = new short[1] ;
         P00FL4_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P00FL4_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reportecomisionesalmg__default(),
            new Object[][] {
                new Object[] {
               P00FL2_A130EstadosSolTipo, P00FL2_A597SolicitudesUsrAlta, P00FL2_n597SolicitudesUsrAlta, P00FL2_A438SolicitudServicioOrigenPago, P00FL2_n438SolicitudServicioOrigenPago, P00FL2_A182SolicitudesFechaAlta, P00FL2_n182SolicitudesFechaAlta, P00FL2_A184SolicitudesFechaInstalacion, P00FL2_A133ProveedorID, P00FL2_A131EstadosSolId,
               P00FL2_A282ProveedorNombre, P00FL2_A127SolicitudesID, P00FL2_A171SolicitudesNombre, P00FL2_A530SolicitudServicioComALM, P00FL2_n530SolicitudServicioComALM, P00FL2_A132EstadosSolNombre, P00FL2_A796SolicitudesComisionMetodoPago, P00FL2_A212SolicitudesCotizacion, P00FL2_A1016SolicitudesDescuentoCupon, P00FL2_A897SolicitudesDescuento,
               P00FL2_n897SolicitudesDescuento, P00FL2_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P00FL3_A18SecUserId, P00FL3_A26SecUserName
               }
               , new Object[] {
               P00FL4_A127SolicitudesID, P00FL4_A134SolicitudesItemsID, P00FL4_A180SolicitudItemsComision, P00FL4_A179SolicitudItemsComisionTipo, P00FL4_A178SolicitudItemsSR, P00FL4_A177SolicitudesItemsCantidad, P00FL4_A176SolicitudesItemsPrecioFinal, P00FL4_n176SolicitudesItemsPrecioFinal
               }
            }
         );
         Gx_time = context.localUtil.Time( );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_time = context.localUtil.Time( );
         Gx_date = DateTimeUtil.Today( context);
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV64contador ;
      private int AV65EstadosGenericosID ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int AV62i ;
      private int Gx_OldLine ;
      private int AV59SecUserID_Count ;
      private int A131EstadosSolId ;
      private long AV31ProveedorID ;
      private long AV51Cantidad ;
      private long AV57OdProveedorID ;
      private long A597SolicitudesUsrAlta ;
      private long A133ProveedorID ;
      private long A127SolicitudesID ;
      private long AV33SolicitudesID ;
      private long AV58SolicitudesUsrAlta ;
      private long A18SecUserId ;
      private decimal AV45TotalAlmango ;
      private decimal AV56Total ;
      private decimal A530SolicitudServicioComALM ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A897SolicitudesDescuento ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal A174SolicitudesTotal ;
      private decimal AV20Importe ;
      private decimal AV49ComisionALM ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV52SolicitudServicioOrigenPago ;
      private string AV63String ;
      private string AV22LabelRango ;
      private string A438SolicitudServicioOrigenPago ;
      private string A130EstadosSolTipo ;
      private string A282ProveedorNombre ;
      private string A171SolicitudesNombre ;
      private string A132EstadosSolNombre ;
      private string AV32ProveedorNombre ;
      private string AV24NombreCliente ;
      private string AV16Estado ;
      private string Gx_time ;
      private DateTime AV14Desde ;
      private DateTime AV19Hasta ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private DateTime A182SolicitudesFechaAlta ;
      private DateTime AV43Fecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool n597SolicitudesUsrAlta ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool n182SolicitudesFechaAlta ;
      private bool n530SolicitudServicioComALM ;
      private bool n897SolicitudesDescuento ;
      private string AV67SecUserIdJson ;
      private string AV66FechaFiltro ;
      private string AV60SecUserName ;
      private string A26SecUserName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV59SecUserID ;
      private GxSimpleCollection<long> AV61cProveedorID ;
      private IDataStoreProvider pr_default ;
      private string[] P00FL2_A130EstadosSolTipo ;
      private long[] P00FL2_A597SolicitudesUsrAlta ;
      private bool[] P00FL2_n597SolicitudesUsrAlta ;
      private string[] P00FL2_A438SolicitudServicioOrigenPago ;
      private bool[] P00FL2_n438SolicitudServicioOrigenPago ;
      private DateTime[] P00FL2_A182SolicitudesFechaAlta ;
      private bool[] P00FL2_n182SolicitudesFechaAlta ;
      private DateTime[] P00FL2_A184SolicitudesFechaInstalacion ;
      private long[] P00FL2_A133ProveedorID ;
      private int[] P00FL2_A131EstadosSolId ;
      private string[] P00FL2_A282ProveedorNombre ;
      private long[] P00FL2_A127SolicitudesID ;
      private string[] P00FL2_A171SolicitudesNombre ;
      private decimal[] P00FL2_A530SolicitudServicioComALM ;
      private bool[] P00FL2_n530SolicitudServicioComALM ;
      private string[] P00FL2_A132EstadosSolNombre ;
      private decimal[] P00FL2_A796SolicitudesComisionMetodoPago ;
      private decimal[] P00FL2_A212SolicitudesCotizacion ;
      private decimal[] P00FL2_A1016SolicitudesDescuentoCupon ;
      private decimal[] P00FL2_A897SolicitudesDescuento ;
      private bool[] P00FL2_n897SolicitudesDescuento ;
      private decimal[] P00FL2_A864SolicitudesCostoXZona ;
      private long[] P00FL3_A18SecUserId ;
      private string[] P00FL3_A26SecUserName ;
      private long[] P00FL4_A127SolicitudesID ;
      private short[] P00FL4_A134SolicitudesItemsID ;
      private decimal[] P00FL4_A180SolicitudItemsComision ;
      private string[] P00FL4_A179SolicitudItemsComisionTipo ;
      private string[] P00FL4_A178SolicitudItemsSR ;
      private short[] P00FL4_A177SolicitudesItemsCantidad ;
      private decimal[] P00FL4_A176SolicitudesItemsPrecioFinal ;
      private bool[] P00FL4_n176SolicitudesItemsPrecioFinal ;
   }

   public class reportecomisionesalmg__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00FL2( IGxContext context ,
                                             long A597SolicitudesUsrAlta ,
                                             GxSimpleCollection<long> AV59SecUserID ,
                                             string AV66FechaFiltro ,
                                             int AV59SecUserID_Count ,
                                             DateTime A184SolicitudesFechaInstalacion ,
                                             DateTime AV14Desde ,
                                             DateTime AV19Hasta ,
                                             DateTime A182SolicitudesFechaAlta ,
                                             long A133ProveedorID ,
                                             long AV31ProveedorID ,
                                             string A438SolicitudServicioOrigenPago ,
                                             string AV52SolicitudServicioOrigenPago )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[8];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[EstadosSolTipo] AS EstadosSolTipo, T1.[SolicitudesUsrAlta], T1.[SolicitudServicioOrigenPago], T1.[SolicitudesFechaAlta], T1.[SolicitudesFechaInstalacion], T1.[ProveedorID], T1.[EstadosSolId] AS EstadosSolId, T2.[ProveedorNombre], T1.[SolicitudesID], T1.[SolicitudesNombre], T1.[SolicitudServicioComALM], T3.[EstadosGenericosNombre] AS EstadosSolNombre, T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudesCostoXZona] FROM (([Solicitudes] T1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[ProveedorID]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T1.[EstadosSolTipo] AND T3.[EstadosGenericosId] = T1.[EstadosSolId])";
         AddWhere(sWhereString, "(T1.[ProveedorID] = @AV31ProveedorID or @AV31ProveedorID = 0)");
         AddWhere(sWhereString, "(T1.[SolicitudServicioOrigenPago] = @AV52SolicitudServicioOrigenPago or @AV52SolicitudServicioOrigenPago = '')");
         if ( StringUtil.StrCmp(AV66FechaFiltro, context.GetMessage( "Trabajo", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] >= @AV14Desde and T1.[SolicitudesFechaInstalacion] <= @AV19Hasta)");
         }
         else
         {
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV66FechaFiltro, context.GetMessage( "Alta", "")) == 0 )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaAlta] >= @AV14Desde and T1.[SolicitudesFechaAlta] <= @AV19Hasta)");
         }
         else
         {
            GXv_int1[6] = 1;
            GXv_int1[7] = 1;
         }
         if ( ! ( AV59SecUserID_Count == 0 ) )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV59SecUserID, "T1.[SolicitudesUsrAlta] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProveedorID] DESC, T1.[SolicitudesFechaAlta] DESC";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00FL2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP00FL3;
          prmP00FL3 = new Object[] {
          new ParDef("@AV58SolicitudesUsrAlta",GXType.Decimal,10,0)
          };
          Object[] prmP00FL4;
          prmP00FL4 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP00FL2;
          prmP00FL2 = new Object[] {
          new ParDef("@AV31ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV31ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV52SolicitudServicioOrigenPago",GXType.NChar,1,0) ,
          new ParDef("@AV52SolicitudServicioOrigenPago",GXType.Char,1,0) ,
          new ParDef("@AV14Desde",GXType.Date,8,0) ,
          new ParDef("@AV19Hasta",GXType.Date,8,0) ,
          new ParDef("@AV14Desde",GXType.Date,8,0) ,
          new ParDef("@AV19Hasta",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FL2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FL2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FL3", "SELECT TOP 1 [SecUserId], [SecUserName] FROM [SecUser] WHERE [SecUserId] = @AV58SolicitudesUsrAlta ORDER BY [SecUserId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FL3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00FL4", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FL4,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 1);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
                ((long[]) buf[8])[0] = rslt.getLong(6);
                ((int[]) buf[9])[0] = rslt.getInt(7);
                ((string[]) buf[10])[0] = rslt.getString(8, 80);
                ((long[]) buf[11])[0] = rslt.getLong(9);
                ((string[]) buf[12])[0] = rslt.getString(10, 100);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(11);
                ((bool[]) buf[14])[0] = rslt.wasNull(11);
                ((string[]) buf[15])[0] = rslt.getString(12, 80);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(16);
                ((bool[]) buf[20])[0] = rslt.wasNull(16);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(17);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                return;
       }
    }

 }

}
