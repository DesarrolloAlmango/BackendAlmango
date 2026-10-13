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
   public class areporteobras : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "areporteobras.aspx")), "areporteobras.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "areporteobras.aspx")))) ;
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
                  AV50Gral = StringUtil.StrToBool( GetPar( "Gral"));
                  AV33SolicitudesID = (long)(Math.Round(NumberUtil.Val( GetPar( "SolicitudesID"), "."), 18, MidpointRounding.ToEven));
               }
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public areporteobras( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public areporteobras( IGxContext context )
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
                           bool aP6_Gral ,
                           long aP7_SolicitudesID )
      {
         this.AV30ProveedoresTipoId = aP0_ProveedoresTipoId;
         this.AV31ProveedorID = aP1_ProveedorID;
         this.AV14Desde = aP2_Desde;
         this.AV19Hasta = aP3_Hasta;
         this.AV9Clasificaciones = aP4_Clasificaciones;
         this.AV52SolicitudServicioOrigenPago = aP5_SolicitudServicioOrigenPago;
         this.AV50Gral = aP6_Gral;
         this.AV33SolicitudesID = aP7_SolicitudesID;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_ProveedoresTipoId ,
                                 long aP1_ProveedorID ,
                                 DateTime aP2_Desde ,
                                 DateTime aP3_Hasta ,
                                 int aP4_Clasificaciones ,
                                 string aP5_SolicitudServicioOrigenPago ,
                                 bool aP6_Gral ,
                                 long aP7_SolicitudesID )
      {
         this.AV30ProveedoresTipoId = aP0_ProveedoresTipoId;
         this.AV31ProveedorID = aP1_ProveedorID;
         this.AV14Desde = aP2_Desde;
         this.AV19Hasta = aP3_Hasta;
         this.AV9Clasificaciones = aP4_Clasificaciones;
         this.AV52SolicitudServicioOrigenPago = aP5_SolicitudServicioOrigenPago;
         this.AV50Gral = aP6_Gral;
         this.AV33SolicitudesID = aP7_SolicitudesID;
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
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 17021, 0, 1, 1, 0, 1, 1) )
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
            AV67NuevaDesde = AV14Desde;
            AV68NuevaHasta = AV19Hasta;
            if ( (0==AV33SolicitudesID) )
            {
               /* Using cursor P00IU2 */
               pr_default.execute(0, new Object[] {AV14Desde, AV19Hasta});
               while ( (pr_default.getStatus(0) != 101) )
               {
                  A461CentroCostosId = P00IU2_A461CentroCostosId[0];
                  A892CentroCostosDetallesFecha = P00IU2_A892CentroCostosDetallesFecha[0];
                  A462CentroCostosRef = P00IU2_A462CentroCostosRef[0];
                  A466CentroCostosDetallesId = P00IU2_A466CentroCostosDetallesId[0];
                  A462CentroCostosRef = P00IU2_A462CentroCostosRef[0];
                  AV69CentroCostosRef = A462CentroCostosRef;
                  /* Execute user subroutine: 'ACTUALIZARFECHAS' */
                  S111 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     cleanup();
                     if (true) return;
                  }
                  pr_default.readNext(0);
               }
               pr_default.close(0);
            }
            AV22LabelRango = context.GetMessage( "Rango de fecha: ", "") + StringUtil.Trim( context.localUtil.Format( AV14Desde, "99/99/9999")) + " - " + StringUtil.Trim( context.localUtil.Format( AV19Hasta, "99/99/9999")) + " " + StringUtil.Trim( AV54OrigenPago);
            /* Using cursor P00IU3 */
            pr_default.execute(1, new Object[] {AV31ProveedorID});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A133ProveedorID = P00IU3_A133ProveedorID[0];
               A282ProveedorNombre = P00IU3_A282ProveedorNombre[0];
               AV32ProveedorNombre = context.GetMessage( "Remitente de Solicitud de Servicios: ", "") + StringUtil.Trim( A282ProveedorNombre);
               AV32ProveedorNombre = StringUtil.Upper( StringUtil.Trim( AV32ProveedorNombre));
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            AV45TotalAlmango = 0;
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 A127SolicitudesID ,
                                                 AV70SolicitudesIDCollection ,
                                                 AV33SolicitudesID ,
                                                 A130EstadosSolTipo ,
                                                 A131EstadosSolId ,
                                                 AV9Clasificaciones ,
                                                 A133ProveedorID ,
                                                 AV31ProveedorID ,
                                                 A438SolicitudServicioOrigenPago ,
                                                 AV52SolicitudServicioOrigenPago ,
                                                 A600SolicitudesSubTipo ,
                                                 AV68NuevaHasta ,
                                                 A184SolicitudesFechaInstalacion ,
                                                 AV67NuevaDesde } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE,
                                                 TypeConstants.DATE
                                                 }
            });
            /* Using cursor P00IU5 */
            pr_default.execute(2, new Object[] {AV33SolicitudesID, AV68NuevaHasta, AV9Clasificaciones, AV9Clasificaciones, AV31ProveedorID, AV31ProveedorID, AV52SolicitudServicioOrigenPago, AV52SolicitudServicioOrigenPago, AV67NuevaDesde, AV33SolicitudesID});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A600SolicitudesSubTipo = P00IU5_A600SolicitudesSubTipo[0];
               n600SolicitudesSubTipo = P00IU5_n600SolicitudesSubTipo[0];
               A127SolicitudesID = P00IU5_A127SolicitudesID[0];
               A438SolicitudServicioOrigenPago = P00IU5_A438SolicitudServicioOrigenPago[0];
               n438SolicitudServicioOrigenPago = P00IU5_n438SolicitudServicioOrigenPago[0];
               A184SolicitudesFechaInstalacion = P00IU5_A184SolicitudesFechaInstalacion[0];
               A133ProveedorID = P00IU5_A133ProveedorID[0];
               A131EstadosSolId = P00IU5_A131EstadosSolId[0];
               A130EstadosSolTipo = P00IU5_A130EstadosSolTipo[0];
               A182SolicitudesFechaAlta = P00IU5_A182SolicitudesFechaAlta[0];
               n182SolicitudesFechaAlta = P00IU5_n182SolicitudesFechaAlta[0];
               A171SolicitudesNombre = P00IU5_A171SolicitudesNombre[0];
               A527SolicitudServicioComProv = P00IU5_A527SolicitudServicioComProv[0];
               n527SolicitudServicioComProv = P00IU5_n527SolicitudServicioComProv[0];
               A865SolicitudesCostoXZComAlm = P00IU5_A865SolicitudesCostoXZComAlm[0];
               n865SolicitudesCostoXZComAlm = P00IU5_n865SolicitudesCostoXZComAlm[0];
               A530SolicitudServicioComALM = P00IU5_A530SolicitudServicioComALM[0];
               n530SolicitudServicioComALM = P00IU5_n530SolicitudServicioComALM[0];
               A132EstadosSolNombre = P00IU5_A132EstadosSolNombre[0];
               A40000RelacionesId = P00IU5_A40000RelacionesId[0];
               n40000RelacionesId = P00IU5_n40000RelacionesId[0];
               A796SolicitudesComisionMetodoPago = P00IU5_A796SolicitudesComisionMetodoPago[0];
               A212SolicitudesCotizacion = P00IU5_A212SolicitudesCotizacion[0];
               A1016SolicitudesDescuentoCupon = P00IU5_A1016SolicitudesDescuentoCupon[0];
               A897SolicitudesDescuento = P00IU5_A897SolicitudesDescuento[0];
               n897SolicitudesDescuento = P00IU5_n897SolicitudesDescuento[0];
               A864SolicitudesCostoXZona = P00IU5_A864SolicitudesCostoXZona[0];
               A132EstadosSolNombre = P00IU5_A132EstadosSolNombre[0];
               A40000RelacionesId = P00IU5_A40000RelacionesId[0];
               n40000RelacionesId = P00IU5_n40000RelacionesId[0];
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
                  AV55ComisionCostos = 0;
                  AV62Facturacion = 0;
                  AV61Adicionales = 0;
                  AV76Obraconprofesionalasociado = A40000RelacionesId;
                  if ( ( ( AV9Clasificaciones == 0 ) && ( A131EstadosSolId != 4 ) && ( A131EstadosSolId != 3 ) ) || ( AV9Clasificaciones > 0 ) )
                  {
                     AV33SolicitudesID = A127SolicitudesID;
                     AV43Fecha = A182SolicitudesFechaAlta;
                     AV24NombreCliente = A171SolicitudesNombre;
                     AV20Importe = A211SolicitudServicioPFinal;
                     AV44Comision = A527SolicitudServicioComProv;
                     AV49ComisionALM = (decimal)(A530SolicitudServicioComALM+A865SolicitudesCostoXZComAlm);
                     AV16Estado = A132EstadosSolNombre;
                     AV47TotalComisionProveedor = (decimal)(AV47TotalComisionProveedor+AV20Importe);
                     AV51Cantidad = (long)(AV51Cantidad+1);
                     AV45TotalAlmango = (decimal)(AV45TotalAlmango+AV49ComisionALM);
                     /* Using cursor P00IU6 */
                     pr_default.execute(3, new Object[] {AV19Hasta, A127SolicitudesID, AV14Desde});
                     while ( (pr_default.getStatus(3) != 101) )
                     {
                        A461CentroCostosId = P00IU6_A461CentroCostosId[0];
                        A892CentroCostosDetallesFecha = P00IU6_A892CentroCostosDetallesFecha[0];
                        A462CentroCostosRef = P00IU6_A462CentroCostosRef[0];
                        A459ListaCostosId = P00IU6_A459ListaCostosId[0];
                        n459ListaCostosId = P00IU6_n459ListaCostosId[0];
                        A468CentroCostosDetallesValor = P00IU6_A468CentroCostosDetallesValor[0];
                        A466CentroCostosDetallesId = P00IU6_A466CentroCostosDetallesId[0];
                        A462CentroCostosRef = P00IU6_A462CentroCostosRef[0];
                        if ( ( A459ListaCostosId == 5 ) || ( A459ListaCostosId == 6 ) )
                        {
                           if ( A459ListaCostosId == 6 )
                           {
                              AV61Adicionales = (decimal)(AV61Adicionales+A468CentroCostosDetallesValor);
                           }
                           else
                           {
                              AV62Facturacion = (decimal)(AV62Facturacion+A468CentroCostosDetallesValor);
                           }
                        }
                        else
                        {
                           AV55ComisionCostos = (decimal)(AV55ComisionCostos+A468CentroCostosDetallesValor);
                        }
                        pr_default.readNext(3);
                     }
                     pr_default.close(3);
                     AV20Importe = (decimal)(AV20Importe+AV61Adicionales);
                     AV56Ganancia = (decimal)(AV62Facturacion-AV55ComisionCostos);
                     HIU0( false, 21) ;
                     getPrinter().GxDrawLine(117, Gx_line+0, 1006, Gx_line+0, 1, 220, 220, 220, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.localUtil.Format( AV43Fecha, "99/99/99"), 48, Gx_line+4, 97, Gx_line+19, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV33SolicitudesID), "ZZZZZZZZZZZZZZZZZ9")), 129, Gx_line+4, 243, Gx_line+19, 0+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24NombreCliente, "")), 238, Gx_line+4, 513, Gx_line+19, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV20Importe, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 847, Gx_line+4, 922, Gx_line+19, 0, 0, 0, 1) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16Estado, "")), 930, Gx_line+4, 1006, Gx_line+19, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV55ComisionCostos, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 745, Gx_line+4, 820, Gx_line+19, 0, 0, 0, 1) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56Ganancia, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 548, Gx_line+4, 623, Gx_line+19, 0, 0, 0, 1) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV62Facturacion, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 648, Gx_line+5, 723, Gx_line+20, 0, 0, 0, 1) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+21);
                     AV57Total = (decimal)(AV57Total+AV20Importe);
                     AV58TotalCostos = (decimal)(AV58TotalCostos+AV55ComisionCostos);
                     AV63TotalFacturacion = (decimal)(AV63TotalFacturacion+AV62Facturacion);
                     if ( AV76Obraconprofesionalasociado > 0 )
                     {
                        AV66TotalProfesionalDirecto = (decimal)(AV66TotalProfesionalDirecto+AV49ComisionALM);
                     }
                  }
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
            if ( AV51Cantidad < 10 )
            {
               HIU0( false, 109) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+109);
            }
            if ( ( AV66TotalProfesionalDirecto > Convert.ToDecimal( 0 )) )
            {
               AV59TotalGanancia = AV66TotalProfesionalDirecto;
            }
            else
            {
               AV59TotalGanancia = (decimal)(AV63TotalFacturacion-AV58TotalCostos);
            }
            AV64TotalPendCobro = (decimal)(AV57Total-AV63TotalFacturacion);
            HIU0( false, 156) ;
            getPrinter().GxDrawLine(33, Gx_line+2, 1040, Gx_line+2, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Total", ""), 939, Gx_line+13, 1046, Gx_line+26, 0, 0, 0, 0) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "22922f7f-f2d4-4fde-abb1-d4ceefcb60c5", "", context.GetTheme( )), 595, Gx_line+101, 727, Gx_line+131) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 70, 130, 180, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Dirección: Eduardo Acevedo 1310 Montevideo, Uruguay  ", ""), 48, Gx_line+83, 395, Gx_line+101, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Teléfono: +598 92612655   ", ""), 48, Gx_line+101, 395, Gx_line+119, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Email: info@almango.com.uy   ", ""), 48, Gx_line+119, 395, Gx_line+137, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Website: www.almango.com.uy", ""), 48, Gx_line+137, 395, Gx_line+155, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(33, Gx_line+60, 922, Gx_line+60, 1, 192, 192, 192, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Costos", ""), 712, Gx_line+15, 819, Gx_line+28, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV58TotalCostos, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 715, Gx_line+40, 822, Gx_line+55, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV57Total, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 939, Gx_line+40, 1052, Gx_line+55, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "GananciaAMG", ""), 481, Gx_line+15, 588, Gx_line+28, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV59TotalGanancia, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 484, Gx_line+39, 590, Gx_line+54, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV63TotalFacturacion, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 600, Gx_line+40, 706, Gx_line+55, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Facturación", ""), 600, Gx_line+15, 707, Gx_line+28, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV64TotalPendCobro, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 826, Gx_line+41, 933, Gx_line+56, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Pend. de Cobro", ""), 826, Gx_line+14, 933, Gx_line+27, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+156);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HIU0( true, 0) ;
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
         /* 'ACTUALIZARFECHAS' Routine */
         returnInSub = false;
         /* Using cursor P00IU7 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A461CentroCostosId = P00IU7_A461CentroCostosId[0];
            /* Using cursor P00IU8 */
            pr_default.execute(5, new Object[] {AV69CentroCostosRef});
            while ( (pr_default.getStatus(5) != 101) )
            {
               A127SolicitudesID = P00IU8_A127SolicitudesID[0];
               A184SolicitudesFechaInstalacion = P00IU8_A184SolicitudesFechaInstalacion[0];
               AV70SolicitudesIDCollection.Add(AV69CentroCostosRef, 0);
               if ( DateTimeUtil.ResetTime ( A184SolicitudesFechaInstalacion ) <= DateTimeUtil.ResetTime ( AV67NuevaDesde ) )
               {
                  AV67NuevaDesde = A184SolicitudesFechaInstalacion;
               }
               if ( DateTimeUtil.ResetTime ( A184SolicitudesFechaInstalacion ) >= DateTimeUtil.ResetTime ( AV68NuevaHasta ) )
               {
                  AV68NuevaHasta = A184SolicitudesFechaInstalacion;
               }
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(5);
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void HIU0( bool bFoot ,
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
               getPrinter().GxDrawText(context.GetMessage( "Reporte de Obras", ""), 208, Gx_line+33, 650, Gx_line+60, 1, 0, 0, 0) ;
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
               getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 936, Gx_line+27, 998, Gx_line+40, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(48, Gx_line+22, 1033, Gx_line+22, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Cliente", ""), 238, Gx_line+27, 345, Gx_line+40, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Solicitud No.", ""), 112, Gx_line+27, 219, Gx_line+40, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32ProveedorNombre, "")), 48, Gx_line+5, 549, Gx_line+22, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Ganancia", ""), 548, Gx_line+27, 610, Gx_line+40, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Fecha", ""), 48, Gx_line+27, 110, Gx_line+40, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Costos", ""), 745, Gx_line+27, 807, Gx_line+40, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Importe", ""), 841, Gx_line+27, 903, Gx_line+40, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Facturación", ""), 647, Gx_line+27, 727, Gx_line+40, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+42);
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
         /* Using cursor P00IU9 */
         pr_default.execute(6, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(6) != 101) && ( P00IU9_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P00IU9_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P00IU9_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P00IU9_A176SolicitudesItemsPrecioFinal[0]*P00IU9_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P00IU9_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00IU9_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P00IU9_A176SolicitudesItemsPrecioFinal[0]*P00IU9_A177SolicitudesItemsCantidad[0])-(P00IU9_A180SolicitudItemsComision[0]*P00IU9_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P00IU9_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00IU9_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P00IU9_A176SolicitudesItemsPrecioFinal[0]*P00IU9_A177SolicitudesItemsCantidad[0])+(P00IU9_A180SolicitudItemsComision[0]*P00IU9_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P00IU9_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00IU9_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P00IU9_A176SolicitudesItemsPrecioFinal[0]*P00IU9_A177SolicitudesItemsCantidad[0])-((P00IU9_A176SolicitudesItemsPrecioFinal[0]*P00IU9_A177SolicitudesItemsCantidad[0])*(P00IU9_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P00IU9_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00IU9_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P00IU9_A176SolicitudesItemsPrecioFinal[0]*P00IU9_A177SolicitudesItemsCantidad[0])+((P00IU9_A176SolicitudesItemsPrecioFinal[0]*P00IU9_A177SolicitudesItemsCantidad[0])*(P00IU9_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
            pr_default.readNext(6);
         }
         pr_default.close(6);
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
         AV67NuevaDesde = DateTime.MinValue;
         AV68NuevaHasta = DateTime.MinValue;
         P00IU2_A461CentroCostosId = new long[1] ;
         P00IU2_A892CentroCostosDetallesFecha = new DateTime[] {DateTime.MinValue} ;
         P00IU2_A462CentroCostosRef = new long[1] ;
         P00IU2_A466CentroCostosDetallesId = new long[1] ;
         A892CentroCostosDetallesFecha = DateTime.MinValue;
         AV22LabelRango = "";
         AV54OrigenPago = "";
         P00IU3_A133ProveedorID = new long[1] ;
         P00IU3_A282ProveedorNombre = new string[] {""} ;
         A282ProveedorNombre = "";
         AV32ProveedorNombre = "";
         AV70SolicitudesIDCollection = new GxSimpleCollection<long>();
         A130EstadosSolTipo = "";
         A438SolicitudServicioOrigenPago = "";
         A600SolicitudesSubTipo = "";
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         P00IU5_A600SolicitudesSubTipo = new string[] {""} ;
         P00IU5_n600SolicitudesSubTipo = new bool[] {false} ;
         P00IU5_A127SolicitudesID = new long[1] ;
         P00IU5_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P00IU5_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P00IU5_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00IU5_A133ProveedorID = new long[1] ;
         P00IU5_A131EstadosSolId = new int[1] ;
         P00IU5_A130EstadosSolTipo = new string[] {""} ;
         P00IU5_A182SolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00IU5_n182SolicitudesFechaAlta = new bool[] {false} ;
         P00IU5_A171SolicitudesNombre = new string[] {""} ;
         P00IU5_A527SolicitudServicioComProv = new decimal[1] ;
         P00IU5_n527SolicitudServicioComProv = new bool[] {false} ;
         P00IU5_A865SolicitudesCostoXZComAlm = new decimal[1] ;
         P00IU5_n865SolicitudesCostoXZComAlm = new bool[] {false} ;
         P00IU5_A530SolicitudServicioComALM = new decimal[1] ;
         P00IU5_n530SolicitudServicioComALM = new bool[] {false} ;
         P00IU5_A132EstadosSolNombre = new string[] {""} ;
         P00IU5_A40000RelacionesId = new long[1] ;
         P00IU5_n40000RelacionesId = new bool[] {false} ;
         P00IU5_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P00IU5_A212SolicitudesCotizacion = new decimal[1] ;
         P00IU5_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P00IU5_A897SolicitudesDescuento = new decimal[1] ;
         P00IU5_n897SolicitudesDescuento = new bool[] {false} ;
         P00IU5_A864SolicitudesCostoXZona = new decimal[1] ;
         A182SolicitudesFechaAlta = DateTime.MinValue;
         A171SolicitudesNombre = "";
         A132EstadosSolNombre = "";
         AV43Fecha = DateTime.MinValue;
         AV24NombreCliente = "";
         AV16Estado = "";
         P00IU6_A461CentroCostosId = new long[1] ;
         P00IU6_A892CentroCostosDetallesFecha = new DateTime[] {DateTime.MinValue} ;
         P00IU6_A462CentroCostosRef = new long[1] ;
         P00IU6_A459ListaCostosId = new long[1] ;
         P00IU6_n459ListaCostosId = new bool[] {false} ;
         P00IU6_A468CentroCostosDetallesValor = new decimal[1] ;
         P00IU6_A466CentroCostosDetallesId = new long[1] ;
         P00IU7_A461CentroCostosId = new long[1] ;
         P00IU8_A127SolicitudesID = new long[1] ;
         P00IU8_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         P00IU9_A127SolicitudesID = new long[1] ;
         P00IU9_A134SolicitudesItemsID = new short[1] ;
         P00IU9_A180SolicitudItemsComision = new decimal[1] ;
         P00IU9_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P00IU9_A178SolicitudItemsSR = new string[] {""} ;
         P00IU9_A177SolicitudesItemsCantidad = new short[1] ;
         P00IU9_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P00IU9_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.areporteobras__default(),
            new Object[][] {
                new Object[] {
               P00IU2_A461CentroCostosId, P00IU2_A892CentroCostosDetallesFecha, P00IU2_A462CentroCostosRef, P00IU2_A466CentroCostosDetallesId
               }
               , new Object[] {
               P00IU3_A133ProveedorID, P00IU3_A282ProveedorNombre
               }
               , new Object[] {
               P00IU5_A600SolicitudesSubTipo, P00IU5_n600SolicitudesSubTipo, P00IU5_A127SolicitudesID, P00IU5_A438SolicitudServicioOrigenPago, P00IU5_n438SolicitudServicioOrigenPago, P00IU5_A184SolicitudesFechaInstalacion, P00IU5_A133ProveedorID, P00IU5_A131EstadosSolId, P00IU5_A130EstadosSolTipo, P00IU5_A182SolicitudesFechaAlta,
               P00IU5_n182SolicitudesFechaAlta, P00IU5_A171SolicitudesNombre, P00IU5_A527SolicitudServicioComProv, P00IU5_n527SolicitudServicioComProv, P00IU5_A865SolicitudesCostoXZComAlm, P00IU5_n865SolicitudesCostoXZComAlm, P00IU5_A530SolicitudServicioComALM, P00IU5_n530SolicitudServicioComALM, P00IU5_A132EstadosSolNombre, P00IU5_A40000RelacionesId,
               P00IU5_n40000RelacionesId, P00IU5_A796SolicitudesComisionMetodoPago, P00IU5_A212SolicitudesCotizacion, P00IU5_A1016SolicitudesDescuentoCupon, P00IU5_A897SolicitudesDescuento, P00IU5_n897SolicitudesDescuento, P00IU5_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P00IU6_A461CentroCostosId, P00IU6_A892CentroCostosDetallesFecha, P00IU6_A462CentroCostosRef, P00IU6_A459ListaCostosId, P00IU6_n459ListaCostosId, P00IU6_A468CentroCostosDetallesValor, P00IU6_A466CentroCostosDetallesId
               }
               , new Object[] {
               P00IU7_A461CentroCostosId
               }
               , new Object[] {
               P00IU8_A127SolicitudesID, P00IU8_A184SolicitudesFechaInstalacion
               }
               , new Object[] {
               P00IU9_A127SolicitudesID, P00IU9_A134SolicitudesItemsID, P00IU9_A180SolicitudItemsComision, P00IU9_A179SolicitudItemsComisionTipo, P00IU9_A178SolicitudItemsSR, P00IU9_A177SolicitudesItemsCantidad, P00IU9_A176SolicitudesItemsPrecioFinal, P00IU9_n176SolicitudesItemsPrecioFinal
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
      private long AV33SolicitudesID ;
      private long A461CentroCostosId ;
      private long A462CentroCostosRef ;
      private long A466CentroCostosDetallesId ;
      private long AV69CentroCostosRef ;
      private long A133ProveedorID ;
      private long A127SolicitudesID ;
      private long A40000RelacionesId ;
      private long AV76Obraconprofesionalasociado ;
      private long AV51Cantidad ;
      private long A459ListaCostosId ;
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
      private decimal AV55ComisionCostos ;
      private decimal AV62Facturacion ;
      private decimal AV61Adicionales ;
      private decimal AV20Importe ;
      private decimal AV44Comision ;
      private decimal AV49ComisionALM ;
      private decimal AV47TotalComisionProveedor ;
      private decimal A468CentroCostosDetallesValor ;
      private decimal AV56Ganancia ;
      private decimal AV57Total ;
      private decimal AV58TotalCostos ;
      private decimal AV63TotalFacturacion ;
      private decimal AV66TotalProfesionalDirecto ;
      private decimal AV59TotalGanancia ;
      private decimal AV64TotalPendCobro ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV52SolicitudServicioOrigenPago ;
      private string AV22LabelRango ;
      private string AV54OrigenPago ;
      private string A282ProveedorNombre ;
      private string AV32ProveedorNombre ;
      private string A130EstadosSolTipo ;
      private string A438SolicitudServicioOrigenPago ;
      private string A600SolicitudesSubTipo ;
      private string A171SolicitudesNombre ;
      private string A132EstadosSolNombre ;
      private string AV24NombreCliente ;
      private string AV16Estado ;
      private string Gx_time ;
      private DateTime AV14Desde ;
      private DateTime AV19Hasta ;
      private DateTime AV67NuevaDesde ;
      private DateTime AV68NuevaHasta ;
      private DateTime A892CentroCostosDetallesFecha ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private DateTime A182SolicitudesFechaAlta ;
      private DateTime AV43Fecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV50Gral ;
      private bool returnInSub ;
      private bool n600SolicitudesSubTipo ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool n182SolicitudesFechaAlta ;
      private bool n527SolicitudServicioComProv ;
      private bool n865SolicitudesCostoXZComAlm ;
      private bool n530SolicitudServicioComALM ;
      private bool n40000RelacionesId ;
      private bool n897SolicitudesDescuento ;
      private bool n459ListaCostosId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00IU2_A461CentroCostosId ;
      private DateTime[] P00IU2_A892CentroCostosDetallesFecha ;
      private long[] P00IU2_A462CentroCostosRef ;
      private long[] P00IU2_A466CentroCostosDetallesId ;
      private long[] P00IU3_A133ProveedorID ;
      private string[] P00IU3_A282ProveedorNombre ;
      private GxSimpleCollection<long> AV70SolicitudesIDCollection ;
      private string[] P00IU5_A600SolicitudesSubTipo ;
      private bool[] P00IU5_n600SolicitudesSubTipo ;
      private long[] P00IU5_A127SolicitudesID ;
      private string[] P00IU5_A438SolicitudServicioOrigenPago ;
      private bool[] P00IU5_n438SolicitudServicioOrigenPago ;
      private DateTime[] P00IU5_A184SolicitudesFechaInstalacion ;
      private long[] P00IU5_A133ProveedorID ;
      private int[] P00IU5_A131EstadosSolId ;
      private string[] P00IU5_A130EstadosSolTipo ;
      private DateTime[] P00IU5_A182SolicitudesFechaAlta ;
      private bool[] P00IU5_n182SolicitudesFechaAlta ;
      private string[] P00IU5_A171SolicitudesNombre ;
      private decimal[] P00IU5_A527SolicitudServicioComProv ;
      private bool[] P00IU5_n527SolicitudServicioComProv ;
      private decimal[] P00IU5_A865SolicitudesCostoXZComAlm ;
      private bool[] P00IU5_n865SolicitudesCostoXZComAlm ;
      private decimal[] P00IU5_A530SolicitudServicioComALM ;
      private bool[] P00IU5_n530SolicitudServicioComALM ;
      private string[] P00IU5_A132EstadosSolNombre ;
      private long[] P00IU5_A40000RelacionesId ;
      private bool[] P00IU5_n40000RelacionesId ;
      private decimal[] P00IU5_A796SolicitudesComisionMetodoPago ;
      private decimal[] P00IU5_A212SolicitudesCotizacion ;
      private decimal[] P00IU5_A1016SolicitudesDescuentoCupon ;
      private decimal[] P00IU5_A897SolicitudesDescuento ;
      private bool[] P00IU5_n897SolicitudesDescuento ;
      private decimal[] P00IU5_A864SolicitudesCostoXZona ;
      private long[] P00IU6_A461CentroCostosId ;
      private DateTime[] P00IU6_A892CentroCostosDetallesFecha ;
      private long[] P00IU6_A462CentroCostosRef ;
      private long[] P00IU6_A459ListaCostosId ;
      private bool[] P00IU6_n459ListaCostosId ;
      private decimal[] P00IU6_A468CentroCostosDetallesValor ;
      private long[] P00IU6_A466CentroCostosDetallesId ;
      private long[] P00IU7_A461CentroCostosId ;
      private long[] P00IU8_A127SolicitudesID ;
      private DateTime[] P00IU8_A184SolicitudesFechaInstalacion ;
      private long[] P00IU9_A127SolicitudesID ;
      private short[] P00IU9_A134SolicitudesItemsID ;
      private decimal[] P00IU9_A180SolicitudItemsComision ;
      private string[] P00IU9_A179SolicitudItemsComisionTipo ;
      private string[] P00IU9_A178SolicitudItemsSR ;
      private short[] P00IU9_A177SolicitudesItemsCantidad ;
      private decimal[] P00IU9_A176SolicitudesItemsPrecioFinal ;
      private bool[] P00IU9_n176SolicitudesItemsPrecioFinal ;
   }

   public class areporteobras__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00IU5( IGxContext context ,
                                             long A127SolicitudesID ,
                                             GxSimpleCollection<long> AV70SolicitudesIDCollection ,
                                             long AV33SolicitudesID ,
                                             string A130EstadosSolTipo ,
                                             int A131EstadosSolId ,
                                             int AV9Clasificaciones ,
                                             long A133ProveedorID ,
                                             long AV31ProveedorID ,
                                             string A438SolicitudServicioOrigenPago ,
                                             string AV52SolicitudServicioOrigenPago ,
                                             string A600SolicitudesSubTipo ,
                                             DateTime AV68NuevaHasta ,
                                             DateTime A184SolicitudesFechaInstalacion ,
                                             DateTime AV67NuevaDesde )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[SolicitudesSubTipo], T1.[SolicitudesID], T1.[SolicitudServicioOrigenPago], T1.[SolicitudesFechaInstalacion], T1.[ProveedorID], T1.[EstadosSolId] AS EstadosSolId, T1.[EstadosSolTipo] AS EstadosSolTipo, T1.[SolicitudesFechaAlta], T1.[SolicitudesNombre], T1.[SolicitudServicioComProv], T1.[SolicitudesCostoXZComAlm], T1.[SolicitudServicioComALM], T2.[EstadosGenericosNombre] AS EstadosSolNombre, COALESCE( T3.[RelacionesId], 0) AS RelacionesId, T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudesCostoXZona] FROM ([Solicitudes] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosSolTipo] AND T2.[EstadosGenericosId] = T1.[EstadosSolId]),  (SELECT MIN([RelacionesId]) AS RelacionesId FROM [Relaciones] WHERE [SolicitudesID] = @AV33SolicitudesID ) T3";
         AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] <= @AV68NuevaHasta)");
         AddWhere(sWhereString, "(T1.[EstadosSolId] = @AV9Clasificaciones or @AV9Clasificaciones = 0)");
         AddWhere(sWhereString, "(T1.[ProveedorID] = @AV31ProveedorID or @AV31ProveedorID = 0)");
         AddWhere(sWhereString, "(T1.[SolicitudServicioOrigenPago] = @AV52SolicitudServicioOrigenPago or @AV52SolicitudServicioOrigenPago = '')");
         AddWhere(sWhereString, "(T1.[SolicitudesSubTipo] = 'A')");
         AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] >= @AV67NuevaDesde)");
         if ( ! (0==AV33SolicitudesID) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesID] = @AV33SolicitudesID)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( (0==AV33SolicitudesID) )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV70SolicitudesIDCollection, "T1.[SolicitudesID] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[SolicitudesFechaInstalacion] DESC, T1.[SolicitudesID] DESC";
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
               case 2 :
                     return conditional_P00IU5(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] );
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
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00IU2;
          prmP00IU2 = new Object[] {
          new ParDef("@AV14Desde",GXType.Date,8,0) ,
          new ParDef("@AV19Hasta",GXType.Date,8,0)
          };
          Object[] prmP00IU3;
          prmP00IU3 = new Object[] {
          new ParDef("@AV31ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP00IU6;
          prmP00IU6 = new Object[] {
          new ParDef("@AV19Hasta",GXType.Date,8,0) ,
          new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV14Desde",GXType.Date,8,0)
          };
          Object[] prmP00IU7;
          prmP00IU7 = new Object[] {
          };
          Object[] prmP00IU8;
          prmP00IU8 = new Object[] {
          new ParDef("@AV69CentroCostosRef",GXType.Decimal,18,0)
          };
          Object[] prmP00IU9;
          prmP00IU9 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP00IU5;
          prmP00IU5 = new Object[] {
          new ParDef("@AV33SolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV68NuevaHasta",GXType.Date,8,0) ,
          new ParDef("@AV9Clasificaciones",GXType.Int32,5,0) ,
          new ParDef("@AV9Clasificaciones",GXType.Int32,5,0) ,
          new ParDef("@AV31ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV31ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV52SolicitudServicioOrigenPago",GXType.NChar,1,0) ,
          new ParDef("@AV52SolicitudServicioOrigenPago",GXType.Char,1,0) ,
          new ParDef("@AV67NuevaDesde",GXType.Date,8,0) ,
          new ParDef("@AV33SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00IU2", "SELECT T1.[CentroCostosId], T1.[CentroCostosDetallesFecha], T2.[CentroCostosRef], T1.[CentroCostosDetallesId] FROM ([CentroCostosDetalles] T1 INNER JOIN [CentroCostos] T2 ON T2.[CentroCostosId] = T1.[CentroCostosId]) WHERE T1.[CentroCostosDetallesFecha] >= @AV14Desde and T1.[CentroCostosDetallesFecha] <= @AV19Hasta ORDER BY T1.[CentroCostosId], T1.[CentroCostosDetallesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IU2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00IU3", "SELECT TOP 1 [ProveedorID], [ProveedorNombre] FROM [Proveedor] WHERE [ProveedorID] = @AV31ProveedorID ORDER BY [ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IU3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00IU5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IU5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00IU6", "SELECT T1.[CentroCostosId], T1.[CentroCostosDetallesFecha], T2.[CentroCostosRef], T1.[ListaCostosId], T1.[CentroCostosDetallesValor], T1.[CentroCostosDetallesId] FROM ([CentroCostosDetalles] T1 INNER JOIN [CentroCostos] T2 ON T2.[CentroCostosId] = T1.[CentroCostosId]) WHERE (T1.[CentroCostosDetallesFecha] <= @AV19Hasta) AND (T2.[CentroCostosRef] = @SolicitudesID) AND (T1.[CentroCostosDetallesFecha] >= @AV14Desde) ORDER BY T1.[CentroCostosDetallesFecha] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IU6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00IU7", "SELECT [CentroCostosId] FROM [CentroCostos] ORDER BY [CentroCostosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IU7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00IU8", "SELECT [SolicitudesID], [SolicitudesFechaInstalacion] FROM [Solicitudes] WHERE [SolicitudesID] = @AV69CentroCostosRef ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IU8,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00IU9", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IU9,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 1);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
                ((long[]) buf[6])[0] = rslt.getLong(5);
                ((int[]) buf[7])[0] = rslt.getInt(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 3);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((string[]) buf[11])[0] = rslt.getString(9, 100);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(11);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(12);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((string[]) buf[18])[0] = rslt.getString(13, 80);
                ((long[]) buf[19])[0] = rslt.getLong(14);
                ((bool[]) buf[20])[0] = rslt.wasNull(14);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(16);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(17);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(18);
                ((bool[]) buf[25])[0] = rslt.wasNull(18);
                ((decimal[]) buf[26])[0] = rslt.getDecimal(19);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                return;
             case 6 :
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
