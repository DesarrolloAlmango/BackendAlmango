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
   public class areportecomisionesprov : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "areportecomisionesprov.aspx")), "areportecomisionesprov.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "areportecomisionesprov.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "ProveedoresTipoId");
            if ( ! entryPointCalled )
            {
               AV30ProveedoresTipoId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV31ProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "ProveedorID"), "."), 18, MidpointRounding.ToEven));
                  AV14Desde = context.localUtil.ParseDateParm( GetPar( "Desde"));
                  AV19Hasta = context.localUtil.ParseDateParm( GetPar( "Hasta"));
                  AV9Clasificaciones = (int)(Math.Round(NumberUtil.Val( GetPar( "Clasificaciones"), "."), 18, MidpointRounding.ToEven));
                  AV52SolicitudServicioOrigenPago = GetPar( "SolicitudServicioOrigenPago");
                  AV50DSPALmango = StringUtil.StrToBool( GetPar( "DSPALmango"));
               }
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public areportecomisionesprov( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public areportecomisionesprov( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ProveedoresTipoId ,
                           long aP1_ProveedorID ,
                           DateTime aP2_Desde ,
                           DateTime aP3_Hasta ,
                           int aP4_Clasificaciones ,
                           string aP5_SolicitudServicioOrigenPago ,
                           bool aP6_DSPALmango )
      {
         this.AV30ProveedoresTipoId = aP0_ProveedoresTipoId;
         this.AV31ProveedorID = aP1_ProveedorID;
         this.AV14Desde = aP2_Desde;
         this.AV19Hasta = aP3_Hasta;
         this.AV9Clasificaciones = aP4_Clasificaciones;
         this.AV52SolicitudServicioOrigenPago = aP5_SolicitudServicioOrigenPago;
         this.AV50DSPALmango = aP6_DSPALmango;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_ProveedoresTipoId ,
                                 long aP1_ProveedorID ,
                                 DateTime aP2_Desde ,
                                 DateTime aP3_Hasta ,
                                 int aP4_Clasificaciones ,
                                 string aP5_SolicitudServicioOrigenPago ,
                                 bool aP6_DSPALmango )
      {
         this.AV30ProveedoresTipoId = aP0_ProveedoresTipoId;
         this.AV31ProveedorID = aP1_ProveedorID;
         this.AV14Desde = aP2_Desde;
         this.AV19Hasta = aP3_Hasta;
         this.AV9Clasificaciones = aP4_Clasificaciones;
         this.AV52SolicitudServicioOrigenPago = aP5_SolicitudServicioOrigenPago;
         this.AV50DSPALmango = aP6_DSPALmango;
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
            if ( StringUtil.StrCmp(AV52SolicitudServicioOrigenPago, context.GetMessage( "F", "")) == 0 )
            {
               AV54OrigenPago = context.GetMessage( "Cobro Directo", "");
            }
            else if ( StringUtil.StrCmp(AV52SolicitudServicioOrigenPago, context.GetMessage( "T", "")) == 0 )
            {
               AV54OrigenPago = context.GetMessage( "Cobro Prepago Comercio", "");
            }
            else if ( StringUtil.StrCmp(AV52SolicitudServicioOrigenPago, context.GetMessage( "O", "")) == 0 )
            {
               AV54OrigenPago = context.GetMessage( "Cobro Prepago Almango", "");
            }
            else
            {
               AV54OrigenPago = context.GetMessage( "Todos los Cobros", "");
            }
            AV22LabelRango = context.GetMessage( "Rango de fecha: ", "") + StringUtil.Trim( context.localUtil.Format( AV14Desde, "99/99/9999")) + " - " + StringUtil.Trim( context.localUtil.Format( AV19Hasta, "99/99/9999")) + " " + StringUtil.Trim( AV54OrigenPago);
            /* Using cursor P008F2 */
            pr_default.execute(0, new Object[] {AV31ProveedorID});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A133ProveedorID = P008F2_A133ProveedorID[0];
               A282ProveedorNombre = P008F2_A282ProveedorNombre[0];
               AV32ProveedorNombre = context.GetMessage( "Remitente de Solicitud de Servicios: ", "") + StringUtil.Trim( A282ProveedorNombre);
               AV32ProveedorNombre = StringUtil.Upper( StringUtil.Trim( AV32ProveedorNombre));
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV45TotalAlmango = 0;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV31ProveedorID ,
                                                 A133ProveedorID ,
                                                 A919STComerciosID ,
                                                 A130EstadosSolTipo ,
                                                 A131EstadosSolId ,
                                                 AV9Clasificaciones ,
                                                 A184SolicitudesFechaInstalacion ,
                                                 AV14Desde ,
                                                 AV19Hasta ,
                                                 A127SolicitudesID ,
                                                 AV33SolicitudesID ,
                                                 A438SolicitudServicioOrigenPago ,
                                                 AV52SolicitudServicioOrigenPago } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG,
                                                 TypeConstants.LONG, TypeConstants.BOOLEAN
                                                 }
            });
            /* Using cursor P008F3 */
            pr_default.execute(1, new Object[] {AV9Clasificaciones, AV9Clasificaciones, AV14Desde, AV19Hasta, AV33SolicitudesID, AV33SolicitudesID, AV52SolicitudServicioOrigenPago, AV52SolicitudServicioOrigenPago, AV31ProveedorID, AV31ProveedorID});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A438SolicitudServicioOrigenPago = P008F3_A438SolicitudServicioOrigenPago[0];
               n438SolicitudServicioOrigenPago = P008F3_n438SolicitudServicioOrigenPago[0];
               A127SolicitudesID = P008F3_A127SolicitudesID[0];
               A184SolicitudesFechaInstalacion = P008F3_A184SolicitudesFechaInstalacion[0];
               A919STComerciosID = P008F3_A919STComerciosID[0];
               n919STComerciosID = P008F3_n919STComerciosID[0];
               A133ProveedorID = P008F3_A133ProveedorID[0];
               A131EstadosSolId = P008F3_A131EstadosSolId[0];
               A130EstadosSolTipo = P008F3_A130EstadosSolTipo[0];
               A171SolicitudesNombre = P008F3_A171SolicitudesNombre[0];
               A527SolicitudServicioComProv = P008F3_A527SolicitudServicioComProv[0];
               n527SolicitudServicioComProv = P008F3_n527SolicitudServicioComProv[0];
               A865SolicitudesCostoXZComAlm = P008F3_A865SolicitudesCostoXZComAlm[0];
               n865SolicitudesCostoXZComAlm = P008F3_n865SolicitudesCostoXZComAlm[0];
               A530SolicitudServicioComALM = P008F3_A530SolicitudServicioComALM[0];
               n530SolicitudServicioComALM = P008F3_n530SolicitudServicioComALM[0];
               A132EstadosSolNombre = P008F3_A132EstadosSolNombre[0];
               A182SolicitudesFechaAlta = P008F3_A182SolicitudesFechaAlta[0];
               n182SolicitudesFechaAlta = P008F3_n182SolicitudesFechaAlta[0];
               A796SolicitudesComisionMetodoPago = P008F3_A796SolicitudesComisionMetodoPago[0];
               A212SolicitudesCotizacion = P008F3_A212SolicitudesCotizacion[0];
               A1016SolicitudesDescuentoCupon = P008F3_A1016SolicitudesDescuentoCupon[0];
               A897SolicitudesDescuento = P008F3_A897SolicitudesDescuento[0];
               n897SolicitudesDescuento = P008F3_n897SolicitudesDescuento[0];
               A864SolicitudesCostoXZona = P008F3_A864SolicitudesCostoXZona[0];
               A132EstadosSolNombre = P008F3_A132EstadosSolNombre[0];
               if ( StringUtil.StrCmp(A130EstadosSolTipo, context.GetMessage( "SOL", "")) == 0 )
               {
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
                  if ( ( ( AV9Clasificaciones == 0 ) && ( A131EstadosSolId != 4 ) && ( A131EstadosSolId != 3 ) ) || ( AV9Clasificaciones > 0 ) )
                  {
                     AV33SolicitudesID = A127SolicitudesID;
                     AV43Fecha = A184SolicitudesFechaInstalacion;
                     AV24NombreCliente = A171SolicitudesNombre;
                     AV20Importe = A211SolicitudServicioPFinal;
                     AV44Comision = A527SolicitudServicioComProv;
                     AV49ComisionALM = (decimal)(A530SolicitudServicioComALM+A865SolicitudesCostoXZComAlm);
                     AV16Estado = A132EstadosSolNombre;
                     AV46TotalComisiones = (decimal)(AV46TotalComisiones+AV44Comision);
                     AV47TotalComisionProveedor = (decimal)(AV47TotalComisionProveedor+AV20Importe);
                     AV51Cantidad = (long)(AV51Cantidad+1);
                     if ( AV50DSPALmango )
                     {
                        AV45TotalAlmango = (decimal)(AV45TotalAlmango+AV49ComisionALM);
                        H8F0( false, 21) ;
                        getPrinter().GxDrawLine(48, Gx_line+0, 812, Gx_line+0, 1, 220, 220, 220, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV43Fecha, "99/99/99"), 48, Gx_line+4, 97, Gx_line+19, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV33SolicitudesID), "ZZZZZZZZZZZZZZZZZ9")), 112, Gx_line+4, 226, Gx_line+19, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24NombreCliente, "")), 238, Gx_line+4, 426, Gx_line+19, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV20Importe, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 600, Gx_line+4, 739, Gx_line+19, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV44Comision, "ZZZZZZZZZZZZZZ9.99")), 543, Gx_line+4, 657, Gx_line+19, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16Estado, "")), 751, Gx_line+4, 830, Gx_line+19, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49ComisionALM, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 434, Gx_line+4, 566, Gx_line+19, 2+256, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+21);
                     }
                     else
                     {
                        AV45TotalAlmango = 0;
                        H8F0( false, 24) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16Estado, "")), 751, Gx_line+5, 830, Gx_line+20, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV44Comision, "ZZZZZZZZZZZZZZ9.99")), 542, Gx_line+5, 656, Gx_line+20, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV20Importe, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 599, Gx_line+5, 738, Gx_line+20, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24NombreCliente, "")), 236, Gx_line+5, 424, Gx_line+20, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV33SolicitudesID), "ZZZZZZZZZZZZZZZZZ9")), 111, Gx_line+5, 225, Gx_line+20, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV43Fecha, "99/99/99"), 47, Gx_line+5, 96, Gx_line+20, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawLine(47, Gx_line+1, 811, Gx_line+1, 1, 220, 220, 220, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+24);
                     }
                  }
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            if ( AV51Cantidad < 10 )
            {
               H8F0( false, 109) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+109);
            }
            if ( AV50DSPALmango )
            {
               H8F0( false, 156) ;
               getPrinter().GxDrawLine(48, Gx_line+2, 812, Gx_line+2, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Total ", ""), 638, Gx_line+15, 745, Gx_line+28, 2, 0, 0, 0) ;
               getPrinter().GxDrawBitMap(context.GetImagePath( "22922f7f-f2d4-4fde-abb1-d4ceefcb60c5", "", context.GetTheme( )), 595, Gx_line+101, 727, Gx_line+131) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 70, 130, 180, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Dirección: Eduardo Acevedo 1310 Montevideo, Uruguay  ", ""), 48, Gx_line+83, 395, Gx_line+101, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Teléfono: +598 92612655   ", ""), 48, Gx_line+101, 395, Gx_line+119, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Email: info@almango.com.uy   ", ""), 48, Gx_line+119, 395, Gx_line+137, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Website: www.almango.com.uy", ""), 48, Gx_line+137, 395, Gx_line+155, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(48, Gx_line+60, 812, Gx_line+60, 1, 192, 192, 192, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Comisiones", ""), 550, Gx_line+15, 657, Gx_line+28, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV46TotalComisiones, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 525, Gx_line+36, 657, Gx_line+51, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47TotalComisionProveedor, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 612, Gx_line+36, 744, Gx_line+51, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "ComisionesALM", ""), 459, Gx_line+15, 566, Gx_line+28, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45TotalAlmango, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 434, Gx_line+36, 566, Gx_line+51, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+156);
            }
            else
            {
               H8F0( false, 154) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45TotalAlmango, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 430, Gx_line+34, 562, Gx_line+49, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "ComisionesALM", ""), 455, Gx_line+12, 562, Gx_line+25, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47TotalComisionProveedor, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 608, Gx_line+34, 740, Gx_line+49, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV46TotalComisiones, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 521, Gx_line+34, 653, Gx_line+49, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Comisiones", ""), 546, Gx_line+12, 653, Gx_line+25, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(44, Gx_line+58, 808, Gx_line+58, 1, 192, 192, 192, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 70, 130, 180, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Dirección: Eduardo Acevedo 1310 Montevideo, Uruguay  ", ""), 48, Gx_line+81, 395, Gx_line+99, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Teléfono: +598 92612655   ", ""), 48, Gx_line+99, 395, Gx_line+117, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Email: info@almango.com.uy   ", ""), 48, Gx_line+117, 395, Gx_line+135, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Website: www.almango.com.uy", ""), 48, Gx_line+135, 395, Gx_line+153, 0, 0, 0, 0) ;
               getPrinter().GxDrawBitMap(context.GetImagePath( "22922f7f-f2d4-4fde-abb1-d4ceefcb60c5", "", context.GetTheme( )), 591, Gx_line+99, 723, Gx_line+129) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Total ", ""), 633, Gx_line+12, 740, Gx_line+25, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(44, Gx_line+0, 808, Gx_line+0, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+154);
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H8F0( true, 0) ;
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

      protected void H8F0( bool bFoot ,
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
               if ( AV50DSPALmango )
               {
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 757, Gx_line+27, 819, Gx_line+40, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(48, Gx_line+22, 812, Gx_line+22, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Cliente", ""), 238, Gx_line+27, 345, Gx_line+40, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Solicitud No.", ""), 112, Gx_line+27, 219, Gx_line+40, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32ProveedorNombre, "")), 48, Gx_line+5, 549, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Importe", ""), 683, Gx_line+27, 745, Gx_line+40, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Comisión", ""), 595, Gx_line+27, 657, Gx_line+40, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Fecha", ""), 48, Gx_line+27, 110, Gx_line+40, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Almango", ""), 504, Gx_line+27, 566, Gx_line+40, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+42);
               }
               else
               {
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Fecha", ""), 48, Gx_line+17, 110, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Comisión", ""), 592, Gx_line+17, 654, Gx_line+30, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Importe", ""), 679, Gx_line+16, 741, Gx_line+29, 2, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32ProveedorNombre, "")), 48, Gx_line+0, 549, Gx_line+17, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Solicitud No.", ""), 117, Gx_line+17, 224, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Cliente", ""), 233, Gx_line+17, 340, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(50, Gx_line+17, 814, Gx_line+17, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 753, Gx_line+16, 815, Gx_line+29, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+36);
               }
               AV51Cantidad = 0;
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
         getPrinter().setMetrics("Arial Black", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics2( )
      {
         getPrinter().setMetrics("Arial", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics3( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
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
         /* Using cursor P008F4 */
         pr_default.execute(2, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(2) != 101) && ( P008F4_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P008F4_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P008F4_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P008F4_A176SolicitudesItemsPrecioFinal[0]*P008F4_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P008F4_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P008F4_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P008F4_A176SolicitudesItemsPrecioFinal[0]*P008F4_A177SolicitudesItemsCantidad[0])-(P008F4_A180SolicitudItemsComision[0]*P008F4_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P008F4_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P008F4_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P008F4_A176SolicitudesItemsPrecioFinal[0]*P008F4_A177SolicitudesItemsCantidad[0])+(P008F4_A180SolicitudItemsComision[0]*P008F4_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P008F4_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P008F4_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P008F4_A176SolicitudesItemsPrecioFinal[0]*P008F4_A177SolicitudesItemsCantidad[0])-((P008F4_A176SolicitudesItemsPrecioFinal[0]*P008F4_A177SolicitudesItemsCantidad[0])*(P008F4_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P008F4_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P008F4_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P008F4_A176SolicitudesItemsPrecioFinal[0]*P008F4_A177SolicitudesItemsCantidad[0])+((P008F4_A176SolicitudesItemsPrecioFinal[0]*P008F4_A177SolicitudesItemsCantidad[0])*(P008F4_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
         AV54OrigenPago = "";
         AV22LabelRango = "";
         P008F2_A133ProveedorID = new long[1] ;
         P008F2_A282ProveedorNombre = new string[] {""} ;
         A282ProveedorNombre = "";
         AV32ProveedorNombre = "";
         A130EstadosSolTipo = "";
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A438SolicitudServicioOrigenPago = "";
         P008F3_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P008F3_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P008F3_A127SolicitudesID = new long[1] ;
         P008F3_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P008F3_A919STComerciosID = new long[1] ;
         P008F3_n919STComerciosID = new bool[] {false} ;
         P008F3_A133ProveedorID = new long[1] ;
         P008F3_A131EstadosSolId = new int[1] ;
         P008F3_A130EstadosSolTipo = new string[] {""} ;
         P008F3_A171SolicitudesNombre = new string[] {""} ;
         P008F3_A527SolicitudServicioComProv = new decimal[1] ;
         P008F3_n527SolicitudServicioComProv = new bool[] {false} ;
         P008F3_A865SolicitudesCostoXZComAlm = new decimal[1] ;
         P008F3_n865SolicitudesCostoXZComAlm = new bool[] {false} ;
         P008F3_A530SolicitudServicioComALM = new decimal[1] ;
         P008F3_n530SolicitudServicioComALM = new bool[] {false} ;
         P008F3_A132EstadosSolNombre = new string[] {""} ;
         P008F3_A182SolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P008F3_n182SolicitudesFechaAlta = new bool[] {false} ;
         P008F3_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P008F3_A212SolicitudesCotizacion = new decimal[1] ;
         P008F3_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P008F3_A897SolicitudesDescuento = new decimal[1] ;
         P008F3_n897SolicitudesDescuento = new bool[] {false} ;
         P008F3_A864SolicitudesCostoXZona = new decimal[1] ;
         A171SolicitudesNombre = "";
         A132EstadosSolNombre = "";
         A182SolicitudesFechaAlta = DateTime.MinValue;
         AV43Fecha = DateTime.MinValue;
         AV24NombreCliente = "";
         AV16Estado = "";
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         P008F4_A127SolicitudesID = new long[1] ;
         P008F4_A134SolicitudesItemsID = new short[1] ;
         P008F4_A180SolicitudItemsComision = new decimal[1] ;
         P008F4_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P008F4_A178SolicitudItemsSR = new string[] {""} ;
         P008F4_A177SolicitudesItemsCantidad = new short[1] ;
         P008F4_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P008F4_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.areportecomisionesprov__default(),
            new Object[][] {
                new Object[] {
               P008F2_A133ProveedorID, P008F2_A282ProveedorNombre
               }
               , new Object[] {
               P008F3_A438SolicitudServicioOrigenPago, P008F3_n438SolicitudServicioOrigenPago, P008F3_A127SolicitudesID, P008F3_A184SolicitudesFechaInstalacion, P008F3_A919STComerciosID, P008F3_n919STComerciosID, P008F3_A133ProveedorID, P008F3_A131EstadosSolId, P008F3_A130EstadosSolTipo, P008F3_A171SolicitudesNombre,
               P008F3_A527SolicitudServicioComProv, P008F3_n527SolicitudServicioComProv, P008F3_A865SolicitudesCostoXZComAlm, P008F3_n865SolicitudesCostoXZComAlm, P008F3_A530SolicitudServicioComALM, P008F3_n530SolicitudServicioComALM, P008F3_A132EstadosSolNombre, P008F3_A182SolicitudesFechaAlta, P008F3_n182SolicitudesFechaAlta, P008F3_A796SolicitudesComisionMetodoPago,
               P008F3_A212SolicitudesCotizacion, P008F3_A1016SolicitudesDescuentoCupon, P008F3_A897SolicitudesDescuento, P008F3_n897SolicitudesDescuento, P008F3_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P008F4_A127SolicitudesID, P008F4_A134SolicitudesItemsID, P008F4_A180SolicitudItemsComision, P008F4_A179SolicitudItemsComisionTipo, P008F4_A178SolicitudItemsSR, P008F4_A177SolicitudesItemsCantidad, P008F4_A176SolicitudesItemsPrecioFinal, P008F4_n176SolicitudesItemsPrecioFinal
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

      private short GxWebError ;
      private short nGotPars ;
      private int AV9Clasificaciones ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A131EstadosSolId ;
      private int Gx_OldLine ;
      private long AV30ProveedoresTipoId ;
      private long AV31ProveedorID ;
      private long A133ProveedorID ;
      private long A919STComerciosID ;
      private long A127SolicitudesID ;
      private long AV33SolicitudesID ;
      private long AV51Cantidad ;
      private decimal AV45TotalAlmango ;
      private decimal A527SolicitudServicioComProv ;
      private decimal A865SolicitudesCostoXZComAlm ;
      private decimal A530SolicitudServicioComALM ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A897SolicitudesDescuento ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal A174SolicitudesTotal ;
      private decimal AV20Importe ;
      private decimal AV44Comision ;
      private decimal AV49ComisionALM ;
      private decimal AV46TotalComisiones ;
      private decimal AV47TotalComisionProveedor ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV52SolicitudServicioOrigenPago ;
      private string AV54OrigenPago ;
      private string AV22LabelRango ;
      private string A282ProveedorNombre ;
      private string AV32ProveedorNombre ;
      private string A130EstadosSolTipo ;
      private string A438SolicitudServicioOrigenPago ;
      private string A171SolicitudesNombre ;
      private string A132EstadosSolNombre ;
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
      private bool AV50DSPALmango ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool n919STComerciosID ;
      private bool n527SolicitudServicioComProv ;
      private bool n865SolicitudesCostoXZComAlm ;
      private bool n530SolicitudServicioComALM ;
      private bool n182SolicitudesFechaAlta ;
      private bool n897SolicitudesDescuento ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P008F2_A133ProveedorID ;
      private string[] P008F2_A282ProveedorNombre ;
      private string[] P008F3_A438SolicitudServicioOrigenPago ;
      private bool[] P008F3_n438SolicitudServicioOrigenPago ;
      private long[] P008F3_A127SolicitudesID ;
      private DateTime[] P008F3_A184SolicitudesFechaInstalacion ;
      private long[] P008F3_A919STComerciosID ;
      private bool[] P008F3_n919STComerciosID ;
      private long[] P008F3_A133ProveedorID ;
      private int[] P008F3_A131EstadosSolId ;
      private string[] P008F3_A130EstadosSolTipo ;
      private string[] P008F3_A171SolicitudesNombre ;
      private decimal[] P008F3_A527SolicitudServicioComProv ;
      private bool[] P008F3_n527SolicitudServicioComProv ;
      private decimal[] P008F3_A865SolicitudesCostoXZComAlm ;
      private bool[] P008F3_n865SolicitudesCostoXZComAlm ;
      private decimal[] P008F3_A530SolicitudServicioComALM ;
      private bool[] P008F3_n530SolicitudServicioComALM ;
      private string[] P008F3_A132EstadosSolNombre ;
      private DateTime[] P008F3_A182SolicitudesFechaAlta ;
      private bool[] P008F3_n182SolicitudesFechaAlta ;
      private decimal[] P008F3_A796SolicitudesComisionMetodoPago ;
      private decimal[] P008F3_A212SolicitudesCotizacion ;
      private decimal[] P008F3_A1016SolicitudesDescuentoCupon ;
      private decimal[] P008F3_A897SolicitudesDescuento ;
      private bool[] P008F3_n897SolicitudesDescuento ;
      private decimal[] P008F3_A864SolicitudesCostoXZona ;
      private long[] P008F4_A127SolicitudesID ;
      private short[] P008F4_A134SolicitudesItemsID ;
      private decimal[] P008F4_A180SolicitudItemsComision ;
      private string[] P008F4_A179SolicitudItemsComisionTipo ;
      private string[] P008F4_A178SolicitudItemsSR ;
      private short[] P008F4_A177SolicitudesItemsCantidad ;
      private decimal[] P008F4_A176SolicitudesItemsPrecioFinal ;
      private bool[] P008F4_n176SolicitudesItemsPrecioFinal ;
   }

   public class areportecomisionesprov__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008F3( IGxContext context ,
                                             long AV31ProveedorID ,
                                             long A133ProveedorID ,
                                             long A919STComerciosID ,
                                             string A130EstadosSolTipo ,
                                             int A131EstadosSolId ,
                                             int AV9Clasificaciones ,
                                             DateTime A184SolicitudesFechaInstalacion ,
                                             DateTime AV14Desde ,
                                             DateTime AV19Hasta ,
                                             long A127SolicitudesID ,
                                             long AV33SolicitudesID ,
                                             string A438SolicitudServicioOrigenPago ,
                                             string AV52SolicitudServicioOrigenPago )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[SolicitudServicioOrigenPago], T1.[SolicitudesID], T1.[SolicitudesFechaInstalacion], T1.[STComerciosID], T1.[ProveedorID], T1.[EstadosSolId] AS EstadosSolId, T1.[EstadosSolTipo] AS EstadosSolTipo, T1.[SolicitudesNombre], T1.[SolicitudServicioComProv], T1.[SolicitudesCostoXZComAlm], T1.[SolicitudServicioComALM], T2.[EstadosGenericosNombre] AS EstadosSolNombre, T1.[SolicitudesFechaAlta], T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudesCostoXZona] FROM ([Solicitudes] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosSolTipo] AND T2.[EstadosGenericosId] = T1.[EstadosSolId])";
         AddWhere(sWhereString, "(T1.[EstadosSolId] = @AV9Clasificaciones or @AV9Clasificaciones = 0)");
         AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] >= @AV14Desde and T1.[SolicitudesFechaInstalacion] <= @AV19Hasta)");
         AddWhere(sWhereString, "(T1.[SolicitudesID] = @AV33SolicitudesID or @AV33SolicitudesID = 0)");
         AddWhere(sWhereString, "(T1.[SolicitudServicioOrigenPago] = @AV52SolicitudServicioOrigenPago or @AV52SolicitudServicioOrigenPago = '')");
         if ( AV31ProveedorID != 0 )
         {
            AddWhere(sWhereString, "(( T1.[ProveedorID] = @AV31ProveedorID or T1.[STComerciosID] = @AV31ProveedorID))");
         }
         else
         {
            GXv_int1[8] = 1;
            GXv_int1[9] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[SolicitudesFechaAlta] DESC";
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
               case 1 :
                     return conditional_P008F3(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (long)dynConstraints[9] , (long)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
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
          Object[] prmP008F2;
          prmP008F2 = new Object[] {
          new ParDef("@AV31ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP008F4;
          prmP008F4 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP008F3;
          prmP008F3 = new Object[] {
          new ParDef("@AV9Clasificaciones",GXType.Int32,5,0) ,
          new ParDef("@AV9Clasificaciones",GXType.Int32,5,0) ,
          new ParDef("@AV14Desde",GXType.Date,8,0) ,
          new ParDef("@AV19Hasta",GXType.Date,8,0) ,
          new ParDef("@AV33SolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV33SolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV52SolicitudServicioOrigenPago",GXType.NChar,1,0) ,
          new ParDef("@AV52SolicitudServicioOrigenPago",GXType.Char,1,0) ,
          new ParDef("@AV31ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV31ProveedorID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008F2", "SELECT TOP 1 [ProveedorID], [ProveedorNombre] FROM [Proveedor] WHERE [ProveedorID] = @AV31ProveedorID ORDER BY [ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008F2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008F3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008F3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008F4", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008F4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((long[]) buf[6])[0] = rslt.getLong(5);
                ((int[]) buf[7])[0] = rslt.getInt(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 3);
                ((string[]) buf[9])[0] = rslt.getString(8, 100);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(9);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(11);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((string[]) buf[16])[0] = rslt.getString(12, 80);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(13);
                ((bool[]) buf[18])[0] = rslt.wasNull(13);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(16);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(17);
                ((bool[]) buf[23])[0] = rslt.wasNull(17);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(18);
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
