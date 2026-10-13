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
   public class areporteobrasdetallado : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "areporteobrasdetallado.aspx")), "areporteobrasdetallado.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "areporteobrasdetallado.aspx")))) ;
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

      public areporteobrasdetallado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public areporteobrasdetallado( IGxContext context )
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
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 17280, 0, 1, 1, 0, 1, 1) )
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
            AV73NuevaDesde = AV14Desde;
            AV74NuevaHasta = AV19Hasta;
            if ( (0==AV33SolicitudesID) )
            {
               /* Using cursor P00IV2 */
               pr_default.execute(0, new Object[] {AV14Desde, AV19Hasta});
               while ( (pr_default.getStatus(0) != 101) )
               {
                  A461CentroCostosId = P00IV2_A461CentroCostosId[0];
                  A892CentroCostosDetallesFecha = P00IV2_A892CentroCostosDetallesFecha[0];
                  A462CentroCostosRef = P00IV2_A462CentroCostosRef[0];
                  A466CentroCostosDetallesId = P00IV2_A466CentroCostosDetallesId[0];
                  A462CentroCostosRef = P00IV2_A462CentroCostosRef[0];
                  AV75CentroCostosRef = A462CentroCostosRef;
                  /* Execute user subroutine: 'ACTUALIZARFECHAS' */
                  S121 ();
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
            /* Using cursor P00IV3 */
            pr_default.execute(1, new Object[] {AV31ProveedorID});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A133ProveedorID = P00IV3_A133ProveedorID[0];
               A282ProveedorNombre = P00IV3_A282ProveedorNombre[0];
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
                                                 AV76SolicitudesIDCollection ,
                                                 AV33SolicitudesID ,
                                                 A130EstadosSolTipo ,
                                                 A131EstadosSolId ,
                                                 AV9Clasificaciones ,
                                                 A133ProveedorID ,
                                                 AV31ProveedorID ,
                                                 A438SolicitudServicioOrigenPago ,
                                                 AV52SolicitudServicioOrigenPago ,
                                                 A600SolicitudesSubTipo ,
                                                 AV74NuevaHasta ,
                                                 A184SolicitudesFechaInstalacion ,
                                                 AV73NuevaDesde } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE,
                                                 TypeConstants.DATE
                                                 }
            });
            /* Using cursor P00IV5 */
            pr_default.execute(2, new Object[] {AV33SolicitudesID, AV74NuevaHasta, AV9Clasificaciones, AV9Clasificaciones, AV31ProveedorID, AV31ProveedorID, AV52SolicitudServicioOrigenPago, AV52SolicitudServicioOrigenPago, AV73NuevaDesde, AV33SolicitudesID});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A600SolicitudesSubTipo = P00IV5_A600SolicitudesSubTipo[0];
               n600SolicitudesSubTipo = P00IV5_n600SolicitudesSubTipo[0];
               A127SolicitudesID = P00IV5_A127SolicitudesID[0];
               A438SolicitudServicioOrigenPago = P00IV5_A438SolicitudServicioOrigenPago[0];
               n438SolicitudServicioOrigenPago = P00IV5_n438SolicitudServicioOrigenPago[0];
               A184SolicitudesFechaInstalacion = P00IV5_A184SolicitudesFechaInstalacion[0];
               A133ProveedorID = P00IV5_A133ProveedorID[0];
               A131EstadosSolId = P00IV5_A131EstadosSolId[0];
               A130EstadosSolTipo = P00IV5_A130EstadosSolTipo[0];
               A282ProveedorNombre = P00IV5_A282ProveedorNombre[0];
               A171SolicitudesNombre = P00IV5_A171SolicitudesNombre[0];
               A527SolicitudServicioComProv = P00IV5_A527SolicitudServicioComProv[0];
               n527SolicitudServicioComProv = P00IV5_n527SolicitudServicioComProv[0];
               A865SolicitudesCostoXZComAlm = P00IV5_A865SolicitudesCostoXZComAlm[0];
               n865SolicitudesCostoXZComAlm = P00IV5_n865SolicitudesCostoXZComAlm[0];
               A530SolicitudServicioComALM = P00IV5_A530SolicitudServicioComALM[0];
               n530SolicitudServicioComALM = P00IV5_n530SolicitudServicioComALM[0];
               A132EstadosSolNombre = P00IV5_A132EstadosSolNombre[0];
               A40000RelacionesId = P00IV5_A40000RelacionesId[0];
               n40000RelacionesId = P00IV5_n40000RelacionesId[0];
               A796SolicitudesComisionMetodoPago = P00IV5_A796SolicitudesComisionMetodoPago[0];
               A212SolicitudesCotizacion = P00IV5_A212SolicitudesCotizacion[0];
               A1016SolicitudesDescuentoCupon = P00IV5_A1016SolicitudesDescuentoCupon[0];
               A897SolicitudesDescuento = P00IV5_A897SolicitudesDescuento[0];
               n897SolicitudesDescuento = P00IV5_n897SolicitudesDescuento[0];
               A864SolicitudesCostoXZona = P00IV5_A864SolicitudesCostoXZona[0];
               A282ProveedorNombre = P00IV5_A282ProveedorNombre[0];
               A132EstadosSolNombre = P00IV5_A132EstadosSolNombre[0];
               A40000RelacionesId = P00IV5_A40000RelacionesId[0];
               n40000RelacionesId = P00IV5_n40000RelacionesId[0];
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
                  AV72ObraConProfesionalAsociado = A40000RelacionesId;
                  if ( ( ( AV9Clasificaciones == 0 ) && ( A131EstadosSolId != 4 ) && ( A131EstadosSolId != 3 ) ) || ( AV9Clasificaciones > 0 ) )
                  {
                     AV33SolicitudesID = A127SolicitudesID;
                     AV43Fecha = A184SolicitudesFechaInstalacion;
                     AV65Obra = A282ProveedorNombre;
                     AV24NombreCliente = A171SolicitudesNombre;
                     AV20Importe = A211SolicitudServicioPFinal;
                     AV44Comision = A527SolicitudServicioComProv;
                     AV49ComisionALM = (decimal)(A530SolicitudServicioComALM+A865SolicitudesCostoXZComAlm);
                     AV16Estado = A132EstadosSolNombre;
                     AV46TotalComisiones = (decimal)(AV46TotalComisiones+AV44Comision);
                     AV47TotalComisionProveedor = (decimal)(AV47TotalComisionProveedor+AV20Importe);
                     AV51Cantidad = (long)(AV51Cantidad+1);
                     HIV0( false, 21) ;
                     getPrinter().GxDrawLine(7, Gx_line+1, 1127, Gx_line+1, 1, 220, 220, 220, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 255, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.localUtil.Format( AV43Fecha, "99/99/99"), 2, Gx_line+6, 51, Gx_line+21, 0+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV33SolicitudesID), "ZZZZZZZZZZZZZZZZZ9")), 67, Gx_line+6, 145, Gx_line+21, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24NombreCliente, "")), 302, Gx_line+6, 640, Gx_line+21, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV20Importe, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 748, Gx_line+6, 804, Gx_line+21, 0, 0, 0, 1) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16Estado, "")), 820, Gx_line+5, 884, Gx_line+20, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49ComisionALM, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 674, Gx_line+6, 737, Gx_line+21, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65Obra, "")), 158, Gx_line+6, 300, Gx_line+21, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+21);
                     /* Using cursor P00IV7 */
                     pr_default.execute(3, new Object[] {AV19Hasta, A127SolicitudesID, AV14Desde});
                     while ( (pr_default.getStatus(3) != 101) )
                     {
                        A461CentroCostosId = P00IV7_A461CentroCostosId[0];
                        A892CentroCostosDetallesFecha = P00IV7_A892CentroCostosDetallesFecha[0];
                        A462CentroCostosRef = P00IV7_A462CentroCostosRef[0];
                        A890CCDetallesProfId = P00IV7_A890CCDetallesProfId[0];
                        A459ListaCostosId = P00IV7_A459ListaCostosId[0];
                        n459ListaCostosId = P00IV7_n459ListaCostosId[0];
                        A468CentroCostosDetallesValor = P00IV7_A468CentroCostosDetallesValor[0];
                        A473CentroCostosDetallesNombre = P00IV7_A473CentroCostosDetallesNombre[0];
                        A893CentroCostosDetallesEstado = P00IV7_A893CentroCostosDetallesEstado[0];
                        A888CentroCostosDetallesSolId = P00IV7_A888CentroCostosDetallesSolId[0];
                        A40001ProfesionalesNombreCompleto = P00IV7_A40001ProfesionalesNombreCompleto[0];
                        n40001ProfesionalesNombreCompleto = P00IV7_n40001ProfesionalesNombreCompleto[0];
                        A466CentroCostosDetallesId = P00IV7_A466CentroCostosDetallesId[0];
                        A462CentroCostosRef = P00IV7_A462CentroCostosRef[0];
                        A40001ProfesionalesNombreCompleto = P00IV7_A40001ProfesionalesNombreCompleto[0];
                        n40001ProfesionalesNombreCompleto = P00IV7_n40001ProfesionalesNombreCompleto[0];
                        AV55CCDetallesProfId = A890CCDetallesProfId;
                        if ( ( A459ListaCostosId == 5 ) || ( A459ListaCostosId == 6 ) )
                        {
                           AV56CentroCostosDetallesValor = A468CentroCostosDetallesValor;
                        }
                        else
                        {
                           AV56CentroCostosDetallesValor = (decimal)(A468CentroCostosDetallesValor*(-1));
                        }
                        AV64CentroCostosDetallesValorP = A468CentroCostosDetallesValor;
                        AV57CentroCostosDetallesNombre = A473CentroCostosDetallesNombre;
                        AV58ProfesionalesNombre = A40001ProfesionalesNombreCompleto;
                        AV43Fecha = A892CentroCostosDetallesFecha;
                        AV70CentroCostosDetallesEstado = A893CentroCostosDetallesEstado;
                        /* Execute user subroutine: 'OBTENERESTADO' */
                        S111 ();
                        if ( returnInSub )
                        {
                           pr_default.close(3);
                           cleanup();
                           if (true) return;
                        }
                        AV16Estado = AV69EstadosGenericosNombre;
                        if ( StringUtil.Contains( AV58ProfesionalesNombre, context.GetMessage( "NULL", "")) )
                        {
                           AV58ProfesionalesNombre = "-";
                        }
                        if ( A459ListaCostosId == 1 )
                        {
                           AV62ComisionCostosOtros = (decimal)(AV62ComisionCostosOtros+A468CentroCostosDetallesValor);
                        }
                        if ( ( A459ListaCostosId == 2 ) || ( A459ListaCostosId == 4 ) )
                        {
                           AV61ComisionProfesionales = (decimal)(AV61ComisionProfesionales+A468CentroCostosDetallesValor);
                        }
                        if ( A459ListaCostosId == 5 )
                        {
                           AV66CobrosRecibidos = (decimal)(AV66CobrosRecibidos+A468CentroCostosDetallesValor);
                        }
                        if ( A459ListaCostosId == 6 )
                        {
                           AV68Adicionales = (decimal)(AV68Adicionales+A468CentroCostosDetallesValor);
                        }
                        if ( A459ListaCostosId == 7 )
                        {
                           AV62ComisionCostosOtros = (decimal)(AV62ComisionCostosOtros+A468CentroCostosDetallesValor);
                        }
                        AV59SubsolicitudId = A888CentroCostosDetallesSolId;
                        if ( AV59SubsolicitudId == 0 )
                        {
                           AV60SubsolicitudIdTexto = "-";
                        }
                        else
                        {
                           AV60SubsolicitudIdTexto = StringUtil.Trim( StringUtil.Str( (decimal)(AV59SubsolicitudId), 18, 0));
                        }
                        HIV0( false, 27) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57CentroCostosDetallesNombre, "")), 304, Gx_line+5, 640, Gx_line+20, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56CentroCostosDetallesValor, "ZZZZZZ9.99")), 675, Gx_line+4, 738, Gx_line+19, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58ProfesionalesNombre, "")), 899, Gx_line+4, 1103, Gx_line+19, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60SubsolicitudIdTexto, "")), 70, Gx_line+5, 147, Gx_line+20, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV64CentroCostosDetallesValorP, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 746, Gx_line+4, 810, Gx_line+19, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16Estado, "")), 822, Gx_line+4, 886, Gx_line+19, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV43Fecha, "99/99/99"), 4, Gx_line+4, 51, Gx_line+19, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+27);
                        pr_default.readNext(3);
                     }
                     pr_default.close(3);
                     AV63Total = (decimal)(AV63Total+AV20Importe);
                     if ( AV72ObraConProfesionalAsociado > 0 )
                     {
                        AV71TotalProfesionalDirecto = (decimal)(AV71TotalProfesionalDirecto+AV49ComisionALM);
                     }
                  }
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
            if ( AV51Cantidad < 10 )
            {
               HIV0( false, 109) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+109);
            }
            AV63Total = (decimal)(AV63Total+AV68Adicionales);
            if ( ( AV71TotalProfesionalDirecto > Convert.ToDecimal( 0 )) )
            {
               AV45TotalAlmango = AV71TotalProfesionalDirecto;
               AV61ComisionProfesionales = (decimal)(AV63Total-AV45TotalAlmango);
            }
            else
            {
               AV45TotalAlmango = (decimal)(AV66CobrosRecibidos-AV61ComisionProfesionales-AV62ComisionCostosOtros);
            }
            AV67PendienteCobro = (decimal)(AV63Total-AV66CobrosRecibidos);
            HIV0( false, 156) ;
            getPrinter().GxDrawLine(48, Gx_line+2, 1133, Gx_line+2, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Total ", ""), 926, Gx_line+17, 988, Gx_line+30, 0, 0, 0, 0) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "22922f7f-f2d4-4fde-abb1-d4ceefcb60c5", "", context.GetTheme( )), 595, Gx_line+101, 727, Gx_line+131) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 70, 130, 180, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Dirección: Eduardo Acevedo 1310 Montevideo, Uruguay  ", ""), 48, Gx_line+83, 395, Gx_line+101, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Teléfono: +598 92612655   ", ""), 48, Gx_line+101, 395, Gx_line+119, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Email: info@almango.com.uy   ", ""), 48, Gx_line+119, 395, Gx_line+137, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Website: www.almango.com.uy", ""), 48, Gx_line+137, 395, Gx_line+155, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(137, Gx_line+62, 1069, Gx_line+62, 1, 192, 192, 192, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "PagosProf", ""), 592, Gx_line+17, 699, Gx_line+30, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV63Total, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")), 926, Gx_line+38, 995, Gx_line+53, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "GananciaAMG", ""), 369, Gx_line+18, 476, Gx_line+31, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45TotalAlmango, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 369, Gx_line+37, 470, Gx_line+52, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV61ComisionProfesionales, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 593, Gx_line+38, 701, Gx_line+53, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "PagosObra", ""), 716, Gx_line+17, 789, Gx_line+30, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV62ComisionCostosOtros, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 716, Gx_line+38, 788, Gx_line+53, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Pend. de Cobro", ""), 802, Gx_line+18, 909, Gx_line+31, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV67PendienteCobro, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 810, Gx_line+38, 899, Gx_line+53, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Facturación", ""), 484, Gx_line+18, 576, Gx_line+31, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66CobrosRecibidos, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 486, Gx_line+39, 576, Gx_line+54, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV71TotalProfesionalDirecto, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 427, Gx_line+80, 559, Gx_line+95, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+156);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HIV0( true, 0) ;
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
         /* 'OBTENERESTADO' Routine */
         returnInSub = false;
         /* Using cursor P00IV8 */
         pr_default.execute(4, new Object[] {AV70CentroCostosDetallesEstado});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A107EstadosTipo = P00IV8_A107EstadosTipo[0];
            A108EstadosGenericosId = P00IV8_A108EstadosGenericosId[0];
            A109EstadosGenericosNombre = P00IV8_A109EstadosGenericosNombre[0];
            if ( StringUtil.StrCmp(A107EstadosTipo, context.GetMessage( "SOL", "")) == 0 )
            {
               AV69EstadosGenericosNombre = A109EstadosGenericosNombre;
            }
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void S121( )
      {
         /* 'ACTUALIZARFECHAS' Routine */
         returnInSub = false;
         /* Using cursor P00IV9 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            A461CentroCostosId = P00IV9_A461CentroCostosId[0];
            /* Using cursor P00IV10 */
            pr_default.execute(6, new Object[] {AV75CentroCostosRef});
            while ( (pr_default.getStatus(6) != 101) )
            {
               A127SolicitudesID = P00IV10_A127SolicitudesID[0];
               A184SolicitudesFechaInstalacion = P00IV10_A184SolicitudesFechaInstalacion[0];
               AV76SolicitudesIDCollection.Add(AV75CentroCostosRef, 0);
               if ( DateTimeUtil.ResetTime ( A184SolicitudesFechaInstalacion ) <= DateTimeUtil.ResetTime ( AV73NuevaDesde ) )
               {
                  AV73NuevaDesde = A184SolicitudesFechaInstalacion;
               }
               if ( DateTimeUtil.ResetTime ( A184SolicitudesFechaInstalacion ) >= DateTimeUtil.ResetTime ( AV74NuevaHasta ) )
               {
                  AV74NuevaHasta = A184SolicitudesFechaInstalacion;
               }
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(6);
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void HIV0( bool bFoot ,
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
               getPrinter().GxDrawText(context.GetMessage( "Reporte Detallado de Gastos", ""), 208, Gx_line+33, 650, Gx_line+60, 1, 0, 0, 0) ;
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
               getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 820, Gx_line+27, 882, Gx_line+40, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(7, Gx_line+22, 1134, Gx_line+22, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Concepto", ""), 301, Gx_line+27, 408, Gx_line+40, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Solicitud No.", ""), 62, Gx_line+27, 147, Gx_line+40, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32ProveedorNombre, "")), 48, Gx_line+5, 549, Gx_line+22, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Importe", ""), 747, Gx_line+27, 809, Gx_line+40, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Fecha", ""), 2, Gx_line+27, 64, Gx_line+40, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Almango", ""), 671, Gx_line+27, 733, Gx_line+40, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Comercio", ""), 154, Gx_line+27, 242, Gx_line+40, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Profesional", ""), 902, Gx_line+27, 975, Gx_line+40, 0, 0, 0, 0) ;
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
         /* Using cursor P00IV11 */
         pr_default.execute(7, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(7) != 101) && ( P00IV11_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P00IV11_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P00IV11_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P00IV11_A176SolicitudesItemsPrecioFinal[0]*P00IV11_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P00IV11_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00IV11_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P00IV11_A176SolicitudesItemsPrecioFinal[0]*P00IV11_A177SolicitudesItemsCantidad[0])-(P00IV11_A180SolicitudItemsComision[0]*P00IV11_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P00IV11_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00IV11_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P00IV11_A176SolicitudesItemsPrecioFinal[0]*P00IV11_A177SolicitudesItemsCantidad[0])+(P00IV11_A180SolicitudItemsComision[0]*P00IV11_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P00IV11_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00IV11_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P00IV11_A176SolicitudesItemsPrecioFinal[0]*P00IV11_A177SolicitudesItemsCantidad[0])-((P00IV11_A176SolicitudesItemsPrecioFinal[0]*P00IV11_A177SolicitudesItemsCantidad[0])*(P00IV11_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P00IV11_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00IV11_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P00IV11_A176SolicitudesItemsPrecioFinal[0]*P00IV11_A177SolicitudesItemsCantidad[0])+((P00IV11_A176SolicitudesItemsPrecioFinal[0]*P00IV11_A177SolicitudesItemsCantidad[0])*(P00IV11_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
            pr_default.readNext(7);
         }
         pr_default.close(7);
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
         AV73NuevaDesde = DateTime.MinValue;
         AV74NuevaHasta = DateTime.MinValue;
         P00IV2_A461CentroCostosId = new long[1] ;
         P00IV2_A892CentroCostosDetallesFecha = new DateTime[] {DateTime.MinValue} ;
         P00IV2_A462CentroCostosRef = new long[1] ;
         P00IV2_A466CentroCostosDetallesId = new long[1] ;
         A892CentroCostosDetallesFecha = DateTime.MinValue;
         AV22LabelRango = "";
         AV54OrigenPago = "";
         P00IV3_A133ProveedorID = new long[1] ;
         P00IV3_A282ProveedorNombre = new string[] {""} ;
         A282ProveedorNombre = "";
         AV32ProveedorNombre = "";
         AV76SolicitudesIDCollection = new GxSimpleCollection<long>();
         A130EstadosSolTipo = "";
         A438SolicitudServicioOrigenPago = "";
         A600SolicitudesSubTipo = "";
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         P00IV5_A600SolicitudesSubTipo = new string[] {""} ;
         P00IV5_n600SolicitudesSubTipo = new bool[] {false} ;
         P00IV5_A127SolicitudesID = new long[1] ;
         P00IV5_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P00IV5_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P00IV5_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00IV5_A133ProveedorID = new long[1] ;
         P00IV5_A131EstadosSolId = new int[1] ;
         P00IV5_A130EstadosSolTipo = new string[] {""} ;
         P00IV5_A282ProveedorNombre = new string[] {""} ;
         P00IV5_A171SolicitudesNombre = new string[] {""} ;
         P00IV5_A527SolicitudServicioComProv = new decimal[1] ;
         P00IV5_n527SolicitudServicioComProv = new bool[] {false} ;
         P00IV5_A865SolicitudesCostoXZComAlm = new decimal[1] ;
         P00IV5_n865SolicitudesCostoXZComAlm = new bool[] {false} ;
         P00IV5_A530SolicitudServicioComALM = new decimal[1] ;
         P00IV5_n530SolicitudServicioComALM = new bool[] {false} ;
         P00IV5_A132EstadosSolNombre = new string[] {""} ;
         P00IV5_A40000RelacionesId = new long[1] ;
         P00IV5_n40000RelacionesId = new bool[] {false} ;
         P00IV5_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P00IV5_A212SolicitudesCotizacion = new decimal[1] ;
         P00IV5_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P00IV5_A897SolicitudesDescuento = new decimal[1] ;
         P00IV5_n897SolicitudesDescuento = new bool[] {false} ;
         P00IV5_A864SolicitudesCostoXZona = new decimal[1] ;
         A171SolicitudesNombre = "";
         A132EstadosSolNombre = "";
         AV43Fecha = DateTime.MinValue;
         AV65Obra = "";
         AV24NombreCliente = "";
         AV16Estado = "";
         P00IV7_A461CentroCostosId = new long[1] ;
         P00IV7_A892CentroCostosDetallesFecha = new DateTime[] {DateTime.MinValue} ;
         P00IV7_A462CentroCostosRef = new long[1] ;
         P00IV7_A890CCDetallesProfId = new string[] {""} ;
         P00IV7_A459ListaCostosId = new long[1] ;
         P00IV7_n459ListaCostosId = new bool[] {false} ;
         P00IV7_A468CentroCostosDetallesValor = new decimal[1] ;
         P00IV7_A473CentroCostosDetallesNombre = new string[] {""} ;
         P00IV7_A893CentroCostosDetallesEstado = new long[1] ;
         P00IV7_A888CentroCostosDetallesSolId = new long[1] ;
         P00IV7_A40001ProfesionalesNombreCompleto = new string[] {""} ;
         P00IV7_n40001ProfesionalesNombreCompleto = new bool[] {false} ;
         P00IV7_A466CentroCostosDetallesId = new long[1] ;
         A890CCDetallesProfId = "";
         A473CentroCostosDetallesNombre = "";
         A40001ProfesionalesNombreCompleto = "";
         AV55CCDetallesProfId = "";
         AV57CentroCostosDetallesNombre = "";
         AV58ProfesionalesNombre = "";
         AV69EstadosGenericosNombre = "";
         AV60SubsolicitudIdTexto = "";
         P00IV8_A107EstadosTipo = new string[] {""} ;
         P00IV8_A108EstadosGenericosId = new int[1] ;
         P00IV8_A109EstadosGenericosNombre = new string[] {""} ;
         A107EstadosTipo = "";
         A109EstadosGenericosNombre = "";
         P00IV9_A461CentroCostosId = new long[1] ;
         P00IV10_A127SolicitudesID = new long[1] ;
         P00IV10_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         P00IV11_A127SolicitudesID = new long[1] ;
         P00IV11_A134SolicitudesItemsID = new short[1] ;
         P00IV11_A180SolicitudItemsComision = new decimal[1] ;
         P00IV11_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P00IV11_A178SolicitudItemsSR = new string[] {""} ;
         P00IV11_A177SolicitudesItemsCantidad = new short[1] ;
         P00IV11_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P00IV11_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.areporteobrasdetallado__default(),
            new Object[][] {
                new Object[] {
               P00IV2_A461CentroCostosId, P00IV2_A892CentroCostosDetallesFecha, P00IV2_A462CentroCostosRef, P00IV2_A466CentroCostosDetallesId
               }
               , new Object[] {
               P00IV3_A133ProveedorID, P00IV3_A282ProveedorNombre
               }
               , new Object[] {
               P00IV5_A600SolicitudesSubTipo, P00IV5_n600SolicitudesSubTipo, P00IV5_A127SolicitudesID, P00IV5_A438SolicitudServicioOrigenPago, P00IV5_n438SolicitudServicioOrigenPago, P00IV5_A184SolicitudesFechaInstalacion, P00IV5_A133ProveedorID, P00IV5_A131EstadosSolId, P00IV5_A130EstadosSolTipo, P00IV5_A282ProveedorNombre,
               P00IV5_A171SolicitudesNombre, P00IV5_A527SolicitudServicioComProv, P00IV5_n527SolicitudServicioComProv, P00IV5_A865SolicitudesCostoXZComAlm, P00IV5_n865SolicitudesCostoXZComAlm, P00IV5_A530SolicitudServicioComALM, P00IV5_n530SolicitudServicioComALM, P00IV5_A132EstadosSolNombre, P00IV5_A40000RelacionesId, P00IV5_n40000RelacionesId,
               P00IV5_A796SolicitudesComisionMetodoPago, P00IV5_A212SolicitudesCotizacion, P00IV5_A1016SolicitudesDescuentoCupon, P00IV5_A897SolicitudesDescuento, P00IV5_n897SolicitudesDescuento, P00IV5_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P00IV7_A461CentroCostosId, P00IV7_A892CentroCostosDetallesFecha, P00IV7_A462CentroCostosRef, P00IV7_A890CCDetallesProfId, P00IV7_A459ListaCostosId, P00IV7_n459ListaCostosId, P00IV7_A468CentroCostosDetallesValor, P00IV7_A473CentroCostosDetallesNombre, P00IV7_A893CentroCostosDetallesEstado, P00IV7_A888CentroCostosDetallesSolId,
               P00IV7_A40001ProfesionalesNombreCompleto, P00IV7_n40001ProfesionalesNombreCompleto, P00IV7_A466CentroCostosDetallesId
               }
               , new Object[] {
               P00IV8_A107EstadosTipo, P00IV8_A108EstadosGenericosId, P00IV8_A109EstadosGenericosNombre
               }
               , new Object[] {
               P00IV9_A461CentroCostosId
               }
               , new Object[] {
               P00IV10_A127SolicitudesID, P00IV10_A184SolicitudesFechaInstalacion
               }
               , new Object[] {
               P00IV11_A127SolicitudesID, P00IV11_A134SolicitudesItemsID, P00IV11_A180SolicitudItemsComision, P00IV11_A179SolicitudItemsComisionTipo, P00IV11_A178SolicitudItemsSR, P00IV11_A177SolicitudesItemsCantidad, P00IV11_A176SolicitudesItemsPrecioFinal, P00IV11_n176SolicitudesItemsPrecioFinal
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
      private int A108EstadosGenericosId ;
      private long AV30ProveedoresTipoId ;
      private long AV31ProveedorID ;
      private long AV33SolicitudesID ;
      private long A461CentroCostosId ;
      private long A462CentroCostosRef ;
      private long A466CentroCostosDetallesId ;
      private long AV75CentroCostosRef ;
      private long A133ProveedorID ;
      private long A127SolicitudesID ;
      private long A40000RelacionesId ;
      private long AV72ObraConProfesionalAsociado ;
      private long AV51Cantidad ;
      private long A459ListaCostosId ;
      private long A893CentroCostosDetallesEstado ;
      private long A888CentroCostosDetallesSolId ;
      private long AV70CentroCostosDetallesEstado ;
      private long AV59SubsolicitudId ;
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
      private decimal A468CentroCostosDetallesValor ;
      private decimal AV56CentroCostosDetallesValor ;
      private decimal AV64CentroCostosDetallesValorP ;
      private decimal AV62ComisionCostosOtros ;
      private decimal AV61ComisionProfesionales ;
      private decimal AV66CobrosRecibidos ;
      private decimal AV68Adicionales ;
      private decimal AV63Total ;
      private decimal AV71TotalProfesionalDirecto ;
      private decimal AV67PendienteCobro ;
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
      private string A890CCDetallesProfId ;
      private string A473CentroCostosDetallesNombre ;
      private string AV55CCDetallesProfId ;
      private string AV57CentroCostosDetallesNombre ;
      private string AV58ProfesionalesNombre ;
      private string AV69EstadosGenericosNombre ;
      private string A107EstadosTipo ;
      private string A109EstadosGenericosNombre ;
      private string Gx_time ;
      private DateTime AV14Desde ;
      private DateTime AV19Hasta ;
      private DateTime AV73NuevaDesde ;
      private DateTime AV74NuevaHasta ;
      private DateTime A892CentroCostosDetallesFecha ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private DateTime AV43Fecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV50Gral ;
      private bool returnInSub ;
      private bool n600SolicitudesSubTipo ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool n527SolicitudServicioComProv ;
      private bool n865SolicitudesCostoXZComAlm ;
      private bool n530SolicitudServicioComALM ;
      private bool n40000RelacionesId ;
      private bool n897SolicitudesDescuento ;
      private bool n459ListaCostosId ;
      private bool n40001ProfesionalesNombreCompleto ;
      private string AV65Obra ;
      private string AV16Estado ;
      private string A40001ProfesionalesNombreCompleto ;
      private string AV60SubsolicitudIdTexto ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00IV2_A461CentroCostosId ;
      private DateTime[] P00IV2_A892CentroCostosDetallesFecha ;
      private long[] P00IV2_A462CentroCostosRef ;
      private long[] P00IV2_A466CentroCostosDetallesId ;
      private long[] P00IV3_A133ProveedorID ;
      private string[] P00IV3_A282ProveedorNombre ;
      private GxSimpleCollection<long> AV76SolicitudesIDCollection ;
      private string[] P00IV5_A600SolicitudesSubTipo ;
      private bool[] P00IV5_n600SolicitudesSubTipo ;
      private long[] P00IV5_A127SolicitudesID ;
      private string[] P00IV5_A438SolicitudServicioOrigenPago ;
      private bool[] P00IV5_n438SolicitudServicioOrigenPago ;
      private DateTime[] P00IV5_A184SolicitudesFechaInstalacion ;
      private long[] P00IV5_A133ProveedorID ;
      private int[] P00IV5_A131EstadosSolId ;
      private string[] P00IV5_A130EstadosSolTipo ;
      private string[] P00IV5_A282ProveedorNombre ;
      private string[] P00IV5_A171SolicitudesNombre ;
      private decimal[] P00IV5_A527SolicitudServicioComProv ;
      private bool[] P00IV5_n527SolicitudServicioComProv ;
      private decimal[] P00IV5_A865SolicitudesCostoXZComAlm ;
      private bool[] P00IV5_n865SolicitudesCostoXZComAlm ;
      private decimal[] P00IV5_A530SolicitudServicioComALM ;
      private bool[] P00IV5_n530SolicitudServicioComALM ;
      private string[] P00IV5_A132EstadosSolNombre ;
      private long[] P00IV5_A40000RelacionesId ;
      private bool[] P00IV5_n40000RelacionesId ;
      private decimal[] P00IV5_A796SolicitudesComisionMetodoPago ;
      private decimal[] P00IV5_A212SolicitudesCotizacion ;
      private decimal[] P00IV5_A1016SolicitudesDescuentoCupon ;
      private decimal[] P00IV5_A897SolicitudesDescuento ;
      private bool[] P00IV5_n897SolicitudesDescuento ;
      private decimal[] P00IV5_A864SolicitudesCostoXZona ;
      private long[] P00IV7_A461CentroCostosId ;
      private DateTime[] P00IV7_A892CentroCostosDetallesFecha ;
      private long[] P00IV7_A462CentroCostosRef ;
      private string[] P00IV7_A890CCDetallesProfId ;
      private long[] P00IV7_A459ListaCostosId ;
      private bool[] P00IV7_n459ListaCostosId ;
      private decimal[] P00IV7_A468CentroCostosDetallesValor ;
      private string[] P00IV7_A473CentroCostosDetallesNombre ;
      private long[] P00IV7_A893CentroCostosDetallesEstado ;
      private long[] P00IV7_A888CentroCostosDetallesSolId ;
      private string[] P00IV7_A40001ProfesionalesNombreCompleto ;
      private bool[] P00IV7_n40001ProfesionalesNombreCompleto ;
      private long[] P00IV7_A466CentroCostosDetallesId ;
      private string[] P00IV8_A107EstadosTipo ;
      private int[] P00IV8_A108EstadosGenericosId ;
      private string[] P00IV8_A109EstadosGenericosNombre ;
      private long[] P00IV9_A461CentroCostosId ;
      private long[] P00IV10_A127SolicitudesID ;
      private DateTime[] P00IV10_A184SolicitudesFechaInstalacion ;
      private long[] P00IV11_A127SolicitudesID ;
      private short[] P00IV11_A134SolicitudesItemsID ;
      private decimal[] P00IV11_A180SolicitudItemsComision ;
      private string[] P00IV11_A179SolicitudItemsComisionTipo ;
      private string[] P00IV11_A178SolicitudItemsSR ;
      private short[] P00IV11_A177SolicitudesItemsCantidad ;
      private decimal[] P00IV11_A176SolicitudesItemsPrecioFinal ;
      private bool[] P00IV11_n176SolicitudesItemsPrecioFinal ;
   }

   public class areporteobrasdetallado__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00IV5( IGxContext context ,
                                             long A127SolicitudesID ,
                                             GxSimpleCollection<long> AV76SolicitudesIDCollection ,
                                             long AV33SolicitudesID ,
                                             string A130EstadosSolTipo ,
                                             int A131EstadosSolId ,
                                             int AV9Clasificaciones ,
                                             long A133ProveedorID ,
                                             long AV31ProveedorID ,
                                             string A438SolicitudServicioOrigenPago ,
                                             string AV52SolicitudServicioOrigenPago ,
                                             string A600SolicitudesSubTipo ,
                                             DateTime AV74NuevaHasta ,
                                             DateTime A184SolicitudesFechaInstalacion ,
                                             DateTime AV73NuevaDesde )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[SolicitudesSubTipo], T1.[SolicitudesID], T1.[SolicitudServicioOrigenPago], T1.[SolicitudesFechaInstalacion], T1.[ProveedorID], T1.[EstadosSolId] AS EstadosSolId, T1.[EstadosSolTipo] AS EstadosSolTipo, T2.[ProveedorNombre], T1.[SolicitudesNombre], T1.[SolicitudServicioComProv], T1.[SolicitudesCostoXZComAlm], T1.[SolicitudServicioComALM], T3.[EstadosGenericosNombre] AS EstadosSolNombre, COALESCE( T4.[RelacionesId], 0) AS RelacionesId, T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudesCostoXZona] FROM (([Solicitudes] T1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[ProveedorID]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T1.[EstadosSolTipo] AND T3.[EstadosGenericosId] = T1.[EstadosSolId]),  (SELECT MIN([RelacionesId]) AS RelacionesId FROM [Relaciones] WHERE [SolicitudesID] = @AV33SolicitudesID ) T4";
         AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] <= @AV74NuevaHasta)");
         AddWhere(sWhereString, "(T1.[EstadosSolId] = @AV9Clasificaciones or @AV9Clasificaciones = 0)");
         AddWhere(sWhereString, "(T1.[ProveedorID] = @AV31ProveedorID or @AV31ProveedorID = 0)");
         AddWhere(sWhereString, "(T1.[SolicitudServicioOrigenPago] = @AV52SolicitudServicioOrigenPago or @AV52SolicitudServicioOrigenPago = '')");
         AddWhere(sWhereString, "(T1.[SolicitudesSubTipo] = 'A')");
         AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] >= @AV73NuevaDesde)");
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
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV76SolicitudesIDCollection, "T1.[SolicitudesID] IN (", ")")+")");
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
                     return conditional_P00IV5(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] );
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
         ,new ForEachCursor(def[7])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00IV2;
          prmP00IV2 = new Object[] {
          new ParDef("@AV14Desde",GXType.Date,8,0) ,
          new ParDef("@AV19Hasta",GXType.Date,8,0)
          };
          Object[] prmP00IV3;
          prmP00IV3 = new Object[] {
          new ParDef("@AV31ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP00IV7;
          prmP00IV7 = new Object[] {
          new ParDef("@AV19Hasta",GXType.Date,8,0) ,
          new ParDef("@SolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV14Desde",GXType.Date,8,0)
          };
          Object[] prmP00IV8;
          prmP00IV8 = new Object[] {
          new ParDef("@AV70CentroCostosDetallesEstado",GXType.Decimal,18,0)
          };
          Object[] prmP00IV9;
          prmP00IV9 = new Object[] {
          };
          Object[] prmP00IV10;
          prmP00IV10 = new Object[] {
          new ParDef("@AV75CentroCostosRef",GXType.Decimal,18,0)
          };
          Object[] prmP00IV11;
          prmP00IV11 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP00IV5;
          prmP00IV5 = new Object[] {
          new ParDef("@AV33SolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV74NuevaHasta",GXType.Date,8,0) ,
          new ParDef("@AV9Clasificaciones",GXType.Int32,5,0) ,
          new ParDef("@AV9Clasificaciones",GXType.Int32,5,0) ,
          new ParDef("@AV31ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV31ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV52SolicitudServicioOrigenPago",GXType.NChar,1,0) ,
          new ParDef("@AV52SolicitudServicioOrigenPago",GXType.Char,1,0) ,
          new ParDef("@AV73NuevaDesde",GXType.Date,8,0) ,
          new ParDef("@AV33SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00IV2", "SELECT T1.[CentroCostosId], T1.[CentroCostosDetallesFecha], T2.[CentroCostosRef], T1.[CentroCostosDetallesId] FROM ([CentroCostosDetalles] T1 INNER JOIN [CentroCostos] T2 ON T2.[CentroCostosId] = T1.[CentroCostosId]) WHERE T1.[CentroCostosDetallesFecha] >= @AV14Desde and T1.[CentroCostosDetallesFecha] <= @AV19Hasta ORDER BY T1.[CentroCostosId], T1.[CentroCostosDetallesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IV2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00IV3", "SELECT TOP 1 [ProveedorID], [ProveedorNombre] FROM [Proveedor] WHERE [ProveedorID] = @AV31ProveedorID ORDER BY [ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IV3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00IV5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IV5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00IV7", "SELECT T1.[CentroCostosId], T1.[CentroCostosDetallesFecha], T2.[CentroCostosRef], T1.[CCDetallesProfId], T1.[ListaCostosId], T1.[CentroCostosDetallesValor], T1.[CentroCostosDetallesNombre], T1.[CentroCostosDetallesEstado], T1.[CentroCostosDetallesSolId], COALESCE( T3.[ProfesionalesNombreCompleto], '-') AS ProfesionalesNombreCompleto, T1.[CentroCostosDetallesId] FROM (([CentroCostosDetalles] T1 INNER JOIN [CentroCostos] T2 ON T2.[CentroCostosId] = T1.[CentroCostosId]) LEFT JOIN (SELECT ( RTRIM(LTRIM([ProfesionalesApellidoPrimero])) + ', ' + RTRIM(LTRIM([ProfesionalesPrimerNombre])) + ' ' + RTRIM(LTRIM([ProfesionalesSegundoNombre]))) AS ProfesionalesNombreCompleto, [ProfesionalesId] FROM [Profesionales] ) T3 ON T3.[ProfesionalesId] = T1.[CCDetallesProfId]) WHERE (T1.[CentroCostosDetallesFecha] <= @AV19Hasta) AND (T2.[CentroCostosRef] = @SolicitudesID) AND (T1.[CentroCostosDetallesFecha] >= @AV14Desde) ORDER BY T1.[CentroCostosDetallesFecha] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IV7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00IV8", "SELECT [EstadosTipo], [EstadosGenericosId], [EstadosGenericosNombre] FROM [EstadosGenericos] WHERE [EstadosGenericosId] = @AV70CentroCostosDetallesEstado ORDER BY [EstadosTipo], [EstadosGenericosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IV8,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00IV9", "SELECT [CentroCostosId] FROM [CentroCostos] ORDER BY [CentroCostosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IV9,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00IV10", "SELECT [SolicitudesID], [SolicitudesFechaInstalacion] FROM [Solicitudes] WHERE [SolicitudesID] = @AV75CentroCostosRef ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IV10,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00IV11", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IV11,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[9])[0] = rslt.getString(8, 80);
                ((string[]) buf[10])[0] = rslt.getString(9, 100);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(10);
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(11);
                ((bool[]) buf[14])[0] = rslt.wasNull(11);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(12);
                ((bool[]) buf[16])[0] = rslt.wasNull(12);
                ((string[]) buf[17])[0] = rslt.getString(13, 80);
                ((long[]) buf[18])[0] = rslt.getLong(14);
                ((bool[]) buf[19])[0] = rslt.wasNull(14);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(16);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(17);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(18);
                ((bool[]) buf[24])[0] = rslt.wasNull(18);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(19);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 80);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                ((long[]) buf[9])[0] = rslt.getLong(9);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((long[]) buf[12])[0] = rslt.getLong(11);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 6 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                return;
             case 7 :
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
