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
   public class aliquidacionsolicitudes : GXProcedure
   {
      public aliquidacionsolicitudes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aliquidacionsolicitudes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_OperacionesTipo ,
                           string aP1_OperacionesRef ,
                           string aP2_OperacionesNombreRef ,
                           DateTime aP3_OperacionesFechaDesde ,
                           DateTime aP4_OperacionesFechaHasta ,
                           GxSimpleCollection<long> aP5_BalancesSeleccionados ,
                           string aP6_OperacionesPeriodoCod ,
                           out string aP7_Gx_msg ,
                           out bool aP8_IsOk )
      {
         this.AV21OperacionesTipo = aP0_OperacionesTipo;
         this.AV20OperacionesRef = aP1_OperacionesRef;
         this.AV19OperacionesNombreRef = aP2_OperacionesNombreRef;
         this.AV16OperacionesFechaDesde = aP3_OperacionesFechaDesde;
         this.AV17OperacionesFechaHasta = aP4_OperacionesFechaHasta;
         this.AV44BalancesSeleccionados = aP5_BalancesSeleccionados;
         this.AV55OperacionesPeriodoCod = aP6_OperacionesPeriodoCod;
         this.Gx_msg = "" ;
         this.AV36IsOk = false ;
         initialize();
         ExecutePrivate();
         aP7_Gx_msg=this.Gx_msg;
         aP8_IsOk=this.AV36IsOk;
      }

      public bool executeUdp( string aP0_OperacionesTipo ,
                              string aP1_OperacionesRef ,
                              string aP2_OperacionesNombreRef ,
                              DateTime aP3_OperacionesFechaDesde ,
                              DateTime aP4_OperacionesFechaHasta ,
                              GxSimpleCollection<long> aP5_BalancesSeleccionados ,
                              string aP6_OperacionesPeriodoCod ,
                              out string aP7_Gx_msg )
      {
         execute(aP0_OperacionesTipo, aP1_OperacionesRef, aP2_OperacionesNombreRef, aP3_OperacionesFechaDesde, aP4_OperacionesFechaHasta, aP5_BalancesSeleccionados, aP6_OperacionesPeriodoCod, out aP7_Gx_msg, out aP8_IsOk);
         return AV36IsOk ;
      }

      public void executeSubmit( string aP0_OperacionesTipo ,
                                 string aP1_OperacionesRef ,
                                 string aP2_OperacionesNombreRef ,
                                 DateTime aP3_OperacionesFechaDesde ,
                                 DateTime aP4_OperacionesFechaHasta ,
                                 GxSimpleCollection<long> aP5_BalancesSeleccionados ,
                                 string aP6_OperacionesPeriodoCod ,
                                 out string aP7_Gx_msg ,
                                 out bool aP8_IsOk )
      {
         this.AV21OperacionesTipo = aP0_OperacionesTipo;
         this.AV20OperacionesRef = aP1_OperacionesRef;
         this.AV19OperacionesNombreRef = aP2_OperacionesNombreRef;
         this.AV16OperacionesFechaDesde = aP3_OperacionesFechaDesde;
         this.AV17OperacionesFechaHasta = aP4_OperacionesFechaHasta;
         this.AV44BalancesSeleccionados = aP5_BalancesSeleccionados;
         this.AV55OperacionesPeriodoCod = aP6_OperacionesPeriodoCod;
         this.Gx_msg = "" ;
         this.AV36IsOk = false ;
         SubmitImpl();
         aP7_Gx_msg=this.Gx_msg;
         aP8_IsOk=this.AV36IsOk;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55OperacionesPeriodoCod)) )
         {
            AV36IsOk = false;
            Gx_msg = context.GetMessage( "El código de período es obligatorio para procesar la liquidación.", "");
            cleanup();
            if (true) return;
         }
         AV56OperacionPreviaId = 0;
         /* Using cursor P00D82 */
         pr_default.execute(0, new Object[] {AV21OperacionesTipo, AV55OperacionesPeriodoCod, AV20OperacionesRef});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A577OperacionesEstado = P00D82_A577OperacionesEstado[0];
            n577OperacionesEstado = P00D82_n577OperacionesEstado[0];
            A1028OperacionesPeriodoCod = P00D82_A1028OperacionesPeriodoCod[0];
            n1028OperacionesPeriodoCod = P00D82_n1028OperacionesPeriodoCod[0];
            A649OperacionesTipo = P00D82_A649OperacionesTipo[0];
            n649OperacionesTipo = P00D82_n649OperacionesTipo[0];
            A555OperacionesRef = P00D82_A555OperacionesRef[0];
            n555OperacionesRef = P00D82_n555OperacionesRef[0];
            A554OperacionesId = P00D82_A554OperacionesId[0];
            AV56OperacionPreviaId = A554OperacionesId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV56OperacionPreviaId > 0 )
         {
            new anularliquidacion(context ).execute(  AV56OperacionPreviaId, out  AV57Ok, out  Gx_msg) ;
            if ( ! AV57Ok )
            {
               AV36IsOk = false;
               cleanup();
               if (true) return;
            }
         }
         AV36IsOk = false;
         GXt_SdtWWPContext1 = AV14contextww;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
         AV14contextww = GXt_SdtWWPContext1;
         AV38UserId = AV14contextww.gxTpr_Userid;
         AV18OperacionesId = 0;
         AV32CobrosProf = 0;
         AV33CobrosComercio = 0;
         AV45TotalBalances = 0;
         AV35monedaId = 1;
         AV37MonedaISO = "UYU";
         AV27TotalOrden = 0;
         AV28TotalComisionProveedor = 0;
         AV29TotalAlmango = 0;
         if ( StringUtil.StrCmp(AV21OperacionesTipo, "LSF") == 0 )
         {
            /* Execute user subroutine: 'PROCESARSOLICITUDESPROFESIONAL' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(AV21OperacionesTipo, "LSC") == 0 )
            {
               /* Execute user subroutine: 'PROCESARSOLICITUDESCOMERCIO' */
               S141 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         if ( ( AV18OperacionesId == 0 ) && ( AV44BalancesSeleccionados.Count > 0 ) )
         {
            /* Execute user subroutine: 'NUEVA OPERACION' */
            S125 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         if ( ( AV18OperacionesId > 0 ) && ( AV44BalancesSeleccionados.Count > 0 ) )
         {
            AV61GXV1 = 1;
            while ( AV61GXV1 <= AV44BalancesSeleccionados.Count )
            {
               AV46BalId = (long)(AV44BalancesSeleccionados.GetNumeric(AV61GXV1));
               /* Using cursor P00D83 */
               pr_default.execute(1, new Object[] {AV46BalId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A645WalletBalancesEstadoOPE = P00D83_A645WalletBalancesEstadoOPE[0];
                  A1012WalletBalanceLiquidacion = P00D83_A1012WalletBalanceLiquidacion[0];
                  n1012WalletBalanceLiquidacion = P00D83_n1012WalletBalanceLiquidacion[0];
                  A640WalletBalancesId = P00D83_A640WalletBalancesId[0];
                  A643WalletBalancesTipoMov = P00D83_A643WalletBalancesTipoMov[0];
                  A644WalletBalancesImporte = P00D83_A644WalletBalancesImporte[0];
                  A637WalletId = P00D83_A637WalletId[0];
                  if ( StringUtil.StrCmp(A643WalletBalancesTipoMov, "CRE") == 0 )
                  {
                     AV45TotalBalances = (decimal)(AV45TotalBalances+A644WalletBalancesImporte);
                  }
                  else
                  {
                     AV45TotalBalances = (decimal)(AV45TotalBalances-A644WalletBalancesImporte);
                  }
                  A1012WalletBalanceLiquidacion = AV18OperacionesId;
                  n1012WalletBalanceLiquidacion = false;
                  A645WalletBalancesEstadoOPE = "PRO";
                  /* Using cursor P00D84 */
                  pr_default.execute(2, new Object[] {A645WalletBalancesEstadoOPE, n1012WalletBalanceLiquidacion, A1012WalletBalanceLiquidacion, A637WalletId, A640WalletBalancesId});
                  pr_default.close(2);
                  pr_default.SmartCacheProvider.SetUpdated("WalletBalances");
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               AV61GXV1 = (int)(AV61GXV1+1);
            }
         }
         if ( StringUtil.StrCmp(AV21OperacionesTipo, "LSF") == 0 )
         {
            AV47NetoSolicitudes = (decimal)((AV27TotalOrden-AV28TotalComisionProveedor-AV29TotalAlmango-AV32CobrosProf));
            AV48TotalLiquidacion = (decimal)(AV47NetoSolicitudes+AV45TotalBalances);
            AV31TipoEntidad = "PRO";
         }
         else
         {
            if ( StringUtil.StrCmp(AV21OperacionesTipo, "LSC") == 0 )
            {
               AV47NetoSolicitudes = (decimal)(AV28TotalComisionProveedor-AV33CobrosComercio);
               AV48TotalLiquidacion = AV47NetoSolicitudes;
               AV31TipoEntidad = "COM";
            }
         }
         /* Using cursor P00D85 */
         pr_default.execute(3, new Object[] {AV18OperacionesId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            GXTD84 = 0;
            A554OperacionesId = P00D85_A554OperacionesId[0];
            A570OperacionesImporte = P00D85_A570OperacionesImporte[0];
            n570OperacionesImporte = P00D85_n570OperacionesImporte[0];
            A577OperacionesEstado = P00D85_A577OperacionesEstado[0];
            n577OperacionesEstado = P00D85_n577OperacionesEstado[0];
            A582OperacionesFechaPago = P00D85_A582OperacionesFechaPago[0];
            n582OperacionesFechaPago = P00D85_n582OperacionesFechaPago[0];
            A580OperacionesComprobantePago = P00D85_A580OperacionesComprobantePago[0];
            n580OperacionesComprobantePago = P00D85_n580OperacionesComprobantePago[0];
            A570OperacionesImporte = AV48TotalLiquidacion;
            n570OperacionesImporte = false;
            if ( ( AV47NetoSolicitudes < Convert.ToDecimal( 0 )) )
            {
               AV39TipoMov = "DEB";
            }
            else
            {
               AV39TipoMov = "CRE";
            }
            AV43WalletBalancesConcepto = 5;
            AV42WalletBalancesObs = "Período: " + context.localUtil.DToC( AV16OperacionesFechaDesde, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/") + " al " + context.localUtil.DToC( AV17OperacionesFechaHasta, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/");
            new amovimientowallet(context ).execute(  AV18OperacionesId,  AV31TipoEntidad,  AV39TipoMov,  AV20OperacionesRef,  AV35monedaId,  AV37MonedaISO,  AV38UserId,  AV47NetoSolicitudes,  AV43WalletBalancesConcepto,  AV42WalletBalancesObs,  AV41WalletBalancesUrl, out  AV36IsOk) ;
            if ( AV36IsOk )
            {
               A577OperacionesEstado = "PRO";
               n577OperacionesEstado = false;
               A582OperacionesFechaPago = DateTimeUtil.ResetTime( DateTimeUtil.ServerDate( context, pr_default) ) ;
               n582OperacionesFechaPago = false;
               A580OperacionesComprobantePago = StringUtil.Str( (decimal)(AV18OperacionesId), 18, 0);
               n580OperacionesComprobantePago = false;
               GXTD84 = 1;
            }
            else
            {
               GXTD84 = 2;
            }
            /* Using cursor P00D86 */
            pr_default.execute(4, new Object[] {n570OperacionesImporte, A570OperacionesImporte, n577OperacionesEstado, A577OperacionesEstado, n582OperacionesFechaPago, A582OperacionesFechaPago, n580OperacionesComprobantePago, A580OperacionesComprobantePago, A554OperacionesId});
            pr_default.close(4);
            pr_default.SmartCacheProvider.SetUpdated("Operaciones");
            if ( GXTD84 == 1 )
            {
               context.CommitDataStores("liquidacionsolicitudes",pr_default);
            }
            if ( GXTD84 == 2 )
            {
               context.RollbackDataStores("liquidacionsolicitudes",pr_default);
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
         cleanup();
      }

      protected void S111( )
      {
         /* 'PROCESARSOLICITUDESPROFESIONAL' Routine */
         returnInSub = false;
         /* Using cursor P00D87 */
         pr_default.execute(5, new Object[] {AV20OperacionesRef, AV16OperacionesFechaDesde, AV17OperacionesFechaHasta});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A184SolicitudesFechaInstalacion = P00D87_A184SolicitudesFechaInstalacion[0];
            A131EstadosSolId = P00D87_A131EstadosSolId[0];
            A130EstadosSolTipo = P00D87_A130EstadosSolTipo[0];
            A688SolicitudesLiqProf = P00D87_A688SolicitudesLiqProf[0];
            n688SolicitudesLiqProf = P00D87_n688SolicitudesLiqProf[0];
            A142EstadoSGId = P00D87_A142EstadoSGId[0];
            A141EstadoSGTipo = P00D87_A141EstadoSGTipo[0];
            A120ProfesionalesId = P00D87_A120ProfesionalesId[0];
            A127SolicitudesID = P00D87_A127SolicitudesID[0];
            A171SolicitudesNombre = P00D87_A171SolicitudesNombre[0];
            A132EstadosSolNombre = P00D87_A132EstadosSolNombre[0];
            A438SolicitudServicioOrigenPago = P00D87_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = P00D87_n438SolicitudServicioOrigenPago[0];
            A128MetodoPagosID = P00D87_A128MetodoPagosID[0];
            A669STMonedasId = P00D87_A669STMonedasId[0];
            n669STMonedasId = P00D87_n669STMonedasId[0];
            A671STMonedasISO = P00D87_A671STMonedasISO[0];
            A133ProveedorID = P00D87_A133ProveedorID[0];
            A282ProveedorNombre = P00D87_A282ProveedorNombre[0];
            A796SolicitudesComisionMetodoPago = P00D87_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = P00D87_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = P00D87_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = P00D87_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = P00D87_n897SolicitudesDescuento[0];
            A527SolicitudServicioComProv = P00D87_A527SolicitudServicioComProv[0];
            n527SolicitudServicioComProv = P00D87_n527SolicitudServicioComProv[0];
            A530SolicitudServicioComALM = P00D87_A530SolicitudServicioComALM[0];
            n530SolicitudServicioComALM = P00D87_n530SolicitudServicioComALM[0];
            A865SolicitudesCostoXZComAlm = P00D87_A865SolicitudesCostoXZComAlm[0];
            n865SolicitudesCostoXZComAlm = P00D87_n865SolicitudesCostoXZComAlm[0];
            A864SolicitudesCostoXZona = P00D87_A864SolicitudesCostoXZona[0];
            A140RelacionesId = P00D87_A140RelacionesId[0];
            A184SolicitudesFechaInstalacion = P00D87_A184SolicitudesFechaInstalacion[0];
            A131EstadosSolId = P00D87_A131EstadosSolId[0];
            A130EstadosSolTipo = P00D87_A130EstadosSolTipo[0];
            A688SolicitudesLiqProf = P00D87_A688SolicitudesLiqProf[0];
            n688SolicitudesLiqProf = P00D87_n688SolicitudesLiqProf[0];
            A171SolicitudesNombre = P00D87_A171SolicitudesNombre[0];
            A438SolicitudServicioOrigenPago = P00D87_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = P00D87_n438SolicitudServicioOrigenPago[0];
            A128MetodoPagosID = P00D87_A128MetodoPagosID[0];
            A669STMonedasId = P00D87_A669STMonedasId[0];
            n669STMonedasId = P00D87_n669STMonedasId[0];
            A133ProveedorID = P00D87_A133ProveedorID[0];
            A796SolicitudesComisionMetodoPago = P00D87_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = P00D87_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = P00D87_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = P00D87_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = P00D87_n897SolicitudesDescuento[0];
            A527SolicitudServicioComProv = P00D87_A527SolicitudServicioComProv[0];
            n527SolicitudServicioComProv = P00D87_n527SolicitudServicioComProv[0];
            A530SolicitudServicioComALM = P00D87_A530SolicitudServicioComALM[0];
            n530SolicitudServicioComALM = P00D87_n530SolicitudServicioComALM[0];
            A865SolicitudesCostoXZComAlm = P00D87_A865SolicitudesCostoXZComAlm[0];
            n865SolicitudesCostoXZComAlm = P00D87_n865SolicitudesCostoXZComAlm[0];
            A864SolicitudesCostoXZona = P00D87_A864SolicitudesCostoXZona[0];
            A132EstadosSolNombre = P00D87_A132EstadosSolNombre[0];
            A671STMonedasISO = P00D87_A671STMonedasISO[0];
            A282ProveedorNombre = P00D87_A282ProveedorNombre[0];
            if ( StringUtil.StrCmp(A141EstadoSGTipo, context.GetMessage( "STS", "")) == 0 )
            {
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
                  if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv >= Convert.ToDecimal( 0 )) )
                  {
                     A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+(A530SolicitudServicioComALM*-1)-A527SolicitudServicioComProv);
                  }
                  else
                  {
                     if ( ( A530SolicitudServicioComALM < Convert.ToDecimal( 0 )) && ( A527SolicitudServicioComProv < Convert.ToDecimal( 0 )) )
                     {
                        A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona+((A530SolicitudServicioComALM+A527SolicitudServicioComProv)*-1));
                     }
                     else
                     {
                        if ( ( A530SolicitudServicioComALM >= Convert.ToDecimal( 0 )) )
                        {
                           A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
                        }
                        else
                        {
                           A529SolicitudServicioComPro = (decimal)(A211SolicitudServicioPFinal-A864SolicitudesCostoXZona-(A527SolicitudServicioComProv+A530SolicitudServicioComALM));
                        }
                     }
                  }
                  if ( ( A865SolicitudesCostoXZComAlm < Convert.ToDecimal( 0 )) )
                  {
                     A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona+(A865SolicitudesCostoXZComAlm*-1));
                  }
                  else
                  {
                     A867SolicitudesCostoXZComProf = (decimal)(A864SolicitudesCostoXZona-(A865SolicitudesCostoXZComAlm));
                  }
                  AV12SolicitudesID = A127SolicitudesID;
                  AV23NombreCliente = A171SolicitudesNombre;
                  AV52ComisionZonaALM = A865SolicitudesCostoXZComAlm;
                  AV53ComisionZonaProf = A867SolicitudesCostoXZComProf;
                  AV49ComisionProf = (decimal)(A529SolicitudServicioComPro+AV53ComisionZonaProf);
                  AV25ComisionALM = (decimal)(A530SolicitudServicioComALM+AV52ComisionZonaALM);
                  AV24ComisionProv = A527SolicitudServicioComProv;
                  AV9Importe = A211SolicitudServicioPFinal;
                  AV8Estado = A132EstadosSolNombre;
                  AV26Fecha = A184SolicitudesFechaInstalacion;
                  AV10OrigenPago = A438SolicitudServicioOrigenPago;
                  AV40MetodoPago = A128MetodoPagosID;
                  AV35monedaId = A669STMonedasId;
                  AV37MonedaISO = A671STMonedasISO;
                  AV50ProveedorId = A133ProveedorID;
                  AV51ProveedorNombre = A282ProveedorNombre;
                  if ( AV18OperacionesId == 0 )
                  {
                     /* Execute user subroutine: 'NUEVA OPERACION' */
                     S125 ();
                     if ( returnInSub )
                     {
                        pr_default.close(5);
                        returnInSub = true;
                        if (true) return;
                     }
                  }
                  /* Execute user subroutine: 'LINEA OPERACION' */
                  S135 ();
                  if ( returnInSub )
                  {
                     pr_default.close(5);
                     returnInSub = true;
                     if (true) return;
                  }
               }
            }
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void S141( )
      {
         /* 'PROCESARSOLICITUDESCOMERCIO' Routine */
         returnInSub = false;
         /* Using cursor P00D88 */
         pr_default.execute(6, new Object[] {AV16OperacionesFechaDesde, AV17OperacionesFechaHasta, AV20OperacionesRef});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A133ProveedorID = P00D88_A133ProveedorID[0];
            A184SolicitudesFechaInstalacion = P00D88_A184SolicitudesFechaInstalacion[0];
            A131EstadosSolId = P00D88_A131EstadosSolId[0];
            A130EstadosSolTipo = P00D88_A130EstadosSolTipo[0];
            A689SolicitudesLiqProv = P00D88_A689SolicitudesLiqProv[0];
            n689SolicitudesLiqProv = P00D88_n689SolicitudesLiqProv[0];
            A127SolicitudesID = P00D88_A127SolicitudesID[0];
            A171SolicitudesNombre = P00D88_A171SolicitudesNombre[0];
            A527SolicitudServicioComProv = P00D88_A527SolicitudServicioComProv[0];
            n527SolicitudServicioComProv = P00D88_n527SolicitudServicioComProv[0];
            A530SolicitudServicioComALM = P00D88_A530SolicitudServicioComALM[0];
            n530SolicitudServicioComALM = P00D88_n530SolicitudServicioComALM[0];
            A132EstadosSolNombre = P00D88_A132EstadosSolNombre[0];
            A438SolicitudServicioOrigenPago = P00D88_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = P00D88_n438SolicitudServicioOrigenPago[0];
            A128MetodoPagosID = P00D88_A128MetodoPagosID[0];
            A669STMonedasId = P00D88_A669STMonedasId[0];
            n669STMonedasId = P00D88_n669STMonedasId[0];
            A671STMonedasISO = P00D88_A671STMonedasISO[0];
            A796SolicitudesComisionMetodoPago = P00D88_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = P00D88_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = P00D88_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = P00D88_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = P00D88_n897SolicitudesDescuento[0];
            A864SolicitudesCostoXZona = P00D88_A864SolicitudesCostoXZona[0];
            A132EstadosSolNombre = P00D88_A132EstadosSolNombre[0];
            A671STMonedasISO = P00D88_A671STMonedasISO[0];
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
               AV12SolicitudesID = A127SolicitudesID;
               AV23NombreCliente = A171SolicitudesNombre;
               AV24ComisionProv = A527SolicitudServicioComProv;
               AV25ComisionALM = A530SolicitudServicioComALM;
               AV9Importe = A211SolicitudServicioPFinal;
               AV8Estado = A132EstadosSolNombre;
               AV26Fecha = A184SolicitudesFechaInstalacion;
               AV10OrigenPago = A438SolicitudServicioOrigenPago;
               AV40MetodoPago = A128MetodoPagosID;
               AV35monedaId = A669STMonedasId;
               AV37MonedaISO = A671STMonedasISO;
               if ( AV18OperacionesId == 0 )
               {
                  /* Execute user subroutine: 'NUEVA OPERACION' */
                  S125 ();
                  if ( returnInSub )
                  {
                     pr_default.close(6);
                     returnInSub = true;
                     if (true) return;
                  }
               }
               /* Execute user subroutine: 'LINEA OPERACION' */
               S135 ();
               if ( returnInSub )
               {
                  pr_default.close(6);
                  returnInSub = true;
                  if (true) return;
               }
            }
            pr_default.readNext(6);
         }
         pr_default.close(6);
      }

      protected void S125( )
      {
         /* 'NUEVA OPERACION' Routine */
         returnInSub = false;
         GXt_int2 = AV18OperacionesId;
         new enumoperaciones(context ).execute( out  GXt_int2) ;
         AV18OperacionesId = GXt_int2;
         /*
            INSERT RECORD ON TABLE Operaciones

         */
         A554OperacionesId = AV18OperacionesId;
         A649OperacionesTipo = AV21OperacionesTipo;
         n649OperacionesTipo = false;
         A555OperacionesRef = AV20OperacionesRef;
         n555OperacionesRef = false;
         A657OperacionesNombreRef = AV19OperacionesNombreRef;
         n657OperacionesNombreRef = false;
         A662OperacionesMonId = AV35monedaId;
         n662OperacionesMonId = false;
         A571OperacionesMoneda = AV37MonedaISO;
         n571OperacionesMoneda = false;
         A581OperacionesFechaAlta = DateTimeUtil.ServerDate( context, pr_default);
         n581OperacionesFechaAlta = false;
         A658OperacionesFechaDesde = AV16OperacionesFechaDesde;
         n658OperacionesFechaDesde = false;
         A659OperacionesFechaHasta = AV17OperacionesFechaHasta;
         n659OperacionesFechaHasta = false;
         A577OperacionesEstado = "PND";
         n577OperacionesEstado = false;
         A666OperacionesUsrAlta = AV14contextww.gxTpr_Userid;
         n666OperacionesUsrAlta = false;
         A667OperacionesUsrActualizacion = AV14contextww.gxTpr_Userid;
         n667OperacionesUsrActualizacion = false;
         A1028OperacionesPeriodoCod = AV55OperacionesPeriodoCod;
         n1028OperacionesPeriodoCod = false;
         /* Using cursor P00D89 */
         pr_default.execute(7, new Object[] {A554OperacionesId, n555OperacionesRef, A555OperacionesRef, n571OperacionesMoneda, A571OperacionesMoneda, n581OperacionesFechaAlta, A581OperacionesFechaAlta, n577OperacionesEstado, A577OperacionesEstado, n649OperacionesTipo, A649OperacionesTipo, n657OperacionesNombreRef, A657OperacionesNombreRef, n658OperacionesFechaDesde, A658OperacionesFechaDesde, n659OperacionesFechaHasta, A659OperacionesFechaHasta, n662OperacionesMonId, A662OperacionesMonId, n666OperacionesUsrAlta, A666OperacionesUsrAlta, n667OperacionesUsrActualizacion, A667OperacionesUsrActualizacion, n1028OperacionesPeriodoCod, A1028OperacionesPeriodoCod});
         pr_default.close(7);
         pr_default.SmartCacheProvider.SetUpdated("Operaciones");
         if ( (pr_default.getStatus(7) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
      }

      protected void S135( )
      {
         /* 'LINEA OPERACION' Routine */
         returnInSub = false;
         new asolicitudliquidacion(context ).execute(  AV12SolicitudesID,  AV21OperacionesTipo,  AV18OperacionesId, out  AV36IsOk) ;
         if ( AV36IsOk )
         {
            /*
               INSERT RECORD ON TABLE OperacionesSolicitudes

            */
            A650OperacionesSolicitudesId = AV12SolicitudesID;
            A651OperacionesSolicitudesNombre = AV23NombreCliente;
            n651OperacionesSolicitudesNombre = false;
            A668OperacionesSolicitudesOrigenPa = AV10OrigenPago;
            n668OperacionesSolicitudesOrigenPa = false;
            A654OperacionesSolicitudesPFinal = AV9Importe;
            n654OperacionesSolicitudesPFinal = false;
            A655OperacionesSolicitudesComProv = AV24ComisionProv;
            n655OperacionesSolicitudesComProv = false;
            A656OperacionesSolicitudesComALM = AV25ComisionALM;
            n656OperacionesSolicitudesComALM = false;
            A1027OperacionesSolicitudesXZComAlm = AV52ComisionZonaALM;
            n1027OperacionesSolicitudesXZComAlm = false;
            A1029OperacionesSolicitudesXZComPro = AV53ComisionZonaProf;
            n1029OperacionesSolicitudesXZComPro = false;
            A653OperacionesSolicitudesComPro = AV49ComisionProf;
            n653OperacionesSolicitudesComPro = false;
            A660OperacionesSolicitudesProvID = AV50ProveedorId;
            n660OperacionesSolicitudesProvID = false;
            A661OperacionesSolicitudesProvNomb = AV51ProveedorNombre;
            n661OperacionesSolicitudesProvNomb = false;
            /* Using cursor P00D810 */
            pr_default.execute(8, new Object[] {A554OperacionesId, A650OperacionesSolicitudesId, n653OperacionesSolicitudesComPro, A653OperacionesSolicitudesComPro, n654OperacionesSolicitudesPFinal, A654OperacionesSolicitudesPFinal, n651OperacionesSolicitudesNombre, A651OperacionesSolicitudesNombre, n655OperacionesSolicitudesComProv, A655OperacionesSolicitudesComProv, n656OperacionesSolicitudesComALM, A656OperacionesSolicitudesComALM, n660OperacionesSolicitudesProvID, A660OperacionesSolicitudesProvID, n661OperacionesSolicitudesProvNomb, A661OperacionesSolicitudesProvNomb, n668OperacionesSolicitudesOrigenPa, A668OperacionesSolicitudesOrigenPa, n1029OperacionesSolicitudesXZComPro, A1029OperacionesSolicitudesXZComPro, n1027OperacionesSolicitudesXZComAlm, A1027OperacionesSolicitudesXZComAlm});
            pr_default.close(8);
            pr_default.SmartCacheProvider.SetUpdated("OperacionesSolicitudes");
            if ( (pr_default.getStatus(8) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
            AV27TotalOrden = (decimal)(AV27TotalOrden+AV9Importe);
            AV28TotalComisionProveedor = (decimal)(AV28TotalComisionProveedor+AV24ComisionProv);
            AV29TotalAlmango = (decimal)(AV29TotalAlmango+AV25ComisionALM);
            if ( StringUtil.StrCmp(AV10OrigenPago, context.GetMessage( "F", "")) == 0 )
            {
               AV32CobrosProf = (decimal)(AV32CobrosProf+AV9Importe);
            }
            else
            {
               if ( StringUtil.StrCmp(AV10OrigenPago, context.GetMessage( "F", "")) != 0 )
               {
                  AV33CobrosComercio = (decimal)(AV33CobrosComercio+AV9Importe);
               }
            }
         }
         else
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void GetSolicitudesTotal( long A127SolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A174SolicitudesTotal = 0;
         /* Using cursor P00D811 */
         pr_default.execute(9, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(9) != 101) && ( P00D811_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P00D811_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P00D811_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P00D811_A176SolicitudesItemsPrecioFinal[0]*P00D811_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P00D811_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00D811_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P00D811_A176SolicitudesItemsPrecioFinal[0]*P00D811_A177SolicitudesItemsCantidad[0])-(P00D811_A180SolicitudItemsComision[0]*P00D811_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P00D811_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00D811_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P00D811_A176SolicitudesItemsPrecioFinal[0]*P00D811_A177SolicitudesItemsCantidad[0])+(P00D811_A180SolicitudItemsComision[0]*P00D811_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P00D811_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00D811_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P00D811_A176SolicitudesItemsPrecioFinal[0]*P00D811_A177SolicitudesItemsCantidad[0])-((P00D811_A176SolicitudesItemsPrecioFinal[0]*P00D811_A177SolicitudesItemsCantidad[0])*(P00D811_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P00D811_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00D811_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P00D811_A176SolicitudesItemsPrecioFinal[0]*P00D811_A177SolicitudesItemsCantidad[0])+((P00D811_A176SolicitudesItemsPrecioFinal[0]*P00D811_A177SolicitudesItemsCantidad[0])*(P00D811_A180SolicitudItemsComision[0]/ (decimal)(100))));
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
            pr_default.readNext(9);
         }
         pr_default.close(9);
      }

      public override void cleanup( )
      {
         context.CommitDataStores("liquidacionsolicitudes",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         Gx_msg = "";
         P00D82_A577OperacionesEstado = new string[] {""} ;
         P00D82_n577OperacionesEstado = new bool[] {false} ;
         P00D82_A1028OperacionesPeriodoCod = new string[] {""} ;
         P00D82_n1028OperacionesPeriodoCod = new bool[] {false} ;
         P00D82_A649OperacionesTipo = new string[] {""} ;
         P00D82_n649OperacionesTipo = new bool[] {false} ;
         P00D82_A555OperacionesRef = new string[] {""} ;
         P00D82_n555OperacionesRef = new bool[] {false} ;
         P00D82_A554OperacionesId = new long[1] ;
         A577OperacionesEstado = "";
         A1028OperacionesPeriodoCod = "";
         A649OperacionesTipo = "";
         A555OperacionesRef = "";
         AV14contextww = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV37MonedaISO = "";
         P00D83_A645WalletBalancesEstadoOPE = new string[] {""} ;
         P00D83_A1012WalletBalanceLiquidacion = new long[1] ;
         P00D83_n1012WalletBalanceLiquidacion = new bool[] {false} ;
         P00D83_A640WalletBalancesId = new long[1] ;
         P00D83_A643WalletBalancesTipoMov = new string[] {""} ;
         P00D83_A644WalletBalancesImporte = new decimal[1] ;
         P00D83_A637WalletId = new long[1] ;
         A645WalletBalancesEstadoOPE = "";
         A643WalletBalancesTipoMov = "";
         AV31TipoEntidad = "";
         P00D85_A554OperacionesId = new long[1] ;
         P00D85_A570OperacionesImporte = new decimal[1] ;
         P00D85_n570OperacionesImporte = new bool[] {false} ;
         P00D85_A577OperacionesEstado = new string[] {""} ;
         P00D85_n577OperacionesEstado = new bool[] {false} ;
         P00D85_A582OperacionesFechaPago = new DateTime[] {DateTime.MinValue} ;
         P00D85_n582OperacionesFechaPago = new bool[] {false} ;
         P00D85_A580OperacionesComprobantePago = new string[] {""} ;
         P00D85_n580OperacionesComprobantePago = new bool[] {false} ;
         A582OperacionesFechaPago = (DateTime)(DateTime.MinValue);
         A580OperacionesComprobantePago = "";
         AV39TipoMov = "";
         AV42WalletBalancesObs = "";
         AV41WalletBalancesUrl = "";
         P00D87_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00D87_A131EstadosSolId = new int[1] ;
         P00D87_A130EstadosSolTipo = new string[] {""} ;
         P00D87_A688SolicitudesLiqProf = new long[1] ;
         P00D87_n688SolicitudesLiqProf = new bool[] {false} ;
         P00D87_A142EstadoSGId = new int[1] ;
         P00D87_A141EstadoSGTipo = new string[] {""} ;
         P00D87_A120ProfesionalesId = new string[] {""} ;
         P00D87_A127SolicitudesID = new long[1] ;
         P00D87_A171SolicitudesNombre = new string[] {""} ;
         P00D87_A132EstadosSolNombre = new string[] {""} ;
         P00D87_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P00D87_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P00D87_A128MetodoPagosID = new long[1] ;
         P00D87_A669STMonedasId = new short[1] ;
         P00D87_n669STMonedasId = new bool[] {false} ;
         P00D87_A671STMonedasISO = new string[] {""} ;
         P00D87_A133ProveedorID = new long[1] ;
         P00D87_A282ProveedorNombre = new string[] {""} ;
         P00D87_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P00D87_A212SolicitudesCotizacion = new decimal[1] ;
         P00D87_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P00D87_A897SolicitudesDescuento = new decimal[1] ;
         P00D87_n897SolicitudesDescuento = new bool[] {false} ;
         P00D87_A527SolicitudServicioComProv = new decimal[1] ;
         P00D87_n527SolicitudServicioComProv = new bool[] {false} ;
         P00D87_A530SolicitudServicioComALM = new decimal[1] ;
         P00D87_n530SolicitudServicioComALM = new bool[] {false} ;
         P00D87_A865SolicitudesCostoXZComAlm = new decimal[1] ;
         P00D87_n865SolicitudesCostoXZComAlm = new bool[] {false} ;
         P00D87_A864SolicitudesCostoXZona = new decimal[1] ;
         P00D87_A140RelacionesId = new long[1] ;
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A130EstadosSolTipo = "";
         A141EstadoSGTipo = "";
         A120ProfesionalesId = "";
         A171SolicitudesNombre = "";
         A132EstadosSolNombre = "";
         A438SolicitudServicioOrigenPago = "";
         A671STMonedasISO = "";
         A282ProveedorNombre = "";
         AV23NombreCliente = "";
         AV8Estado = "";
         AV26Fecha = DateTime.MinValue;
         AV10OrigenPago = "";
         AV51ProveedorNombre = "";
         P00D88_A133ProveedorID = new long[1] ;
         P00D88_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00D88_A131EstadosSolId = new int[1] ;
         P00D88_A130EstadosSolTipo = new string[] {""} ;
         P00D88_A689SolicitudesLiqProv = new long[1] ;
         P00D88_n689SolicitudesLiqProv = new bool[] {false} ;
         P00D88_A127SolicitudesID = new long[1] ;
         P00D88_A171SolicitudesNombre = new string[] {""} ;
         P00D88_A527SolicitudServicioComProv = new decimal[1] ;
         P00D88_n527SolicitudServicioComProv = new bool[] {false} ;
         P00D88_A530SolicitudServicioComALM = new decimal[1] ;
         P00D88_n530SolicitudServicioComALM = new bool[] {false} ;
         P00D88_A132EstadosSolNombre = new string[] {""} ;
         P00D88_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P00D88_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P00D88_A128MetodoPagosID = new long[1] ;
         P00D88_A669STMonedasId = new short[1] ;
         P00D88_n669STMonedasId = new bool[] {false} ;
         P00D88_A671STMonedasISO = new string[] {""} ;
         P00D88_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P00D88_A212SolicitudesCotizacion = new decimal[1] ;
         P00D88_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P00D88_A897SolicitudesDescuento = new decimal[1] ;
         P00D88_n897SolicitudesDescuento = new bool[] {false} ;
         P00D88_A864SolicitudesCostoXZona = new decimal[1] ;
         A657OperacionesNombreRef = "";
         A571OperacionesMoneda = "";
         A581OperacionesFechaAlta = DateTime.MinValue;
         A658OperacionesFechaDesde = DateTime.MinValue;
         A659OperacionesFechaHasta = DateTime.MinValue;
         Gx_emsg = "";
         A651OperacionesSolicitudesNombre = "";
         A668OperacionesSolicitudesOrigenPa = "";
         A661OperacionesSolicitudesProvNomb = "";
         P00D811_A127SolicitudesID = new long[1] ;
         P00D811_A134SolicitudesItemsID = new short[1] ;
         P00D811_A180SolicitudItemsComision = new decimal[1] ;
         P00D811_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P00D811_A178SolicitudItemsSR = new string[] {""} ;
         P00D811_A177SolicitudesItemsCantidad = new short[1] ;
         P00D811_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P00D811_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.aliquidacionsolicitudes__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aliquidacionsolicitudes__default(),
            new Object[][] {
                new Object[] {
               P00D82_A577OperacionesEstado, P00D82_n577OperacionesEstado, P00D82_A1028OperacionesPeriodoCod, P00D82_n1028OperacionesPeriodoCod, P00D82_A649OperacionesTipo, P00D82_n649OperacionesTipo, P00D82_A555OperacionesRef, P00D82_n555OperacionesRef, P00D82_A554OperacionesId
               }
               , new Object[] {
               P00D83_A645WalletBalancesEstadoOPE, P00D83_A1012WalletBalanceLiquidacion, P00D83_n1012WalletBalanceLiquidacion, P00D83_A640WalletBalancesId, P00D83_A643WalletBalancesTipoMov, P00D83_A644WalletBalancesImporte, P00D83_A637WalletId
               }
               , new Object[] {
               }
               , new Object[] {
               P00D85_A554OperacionesId, P00D85_A570OperacionesImporte, P00D85_n570OperacionesImporte, P00D85_A577OperacionesEstado, P00D85_n577OperacionesEstado, P00D85_A582OperacionesFechaPago, P00D85_n582OperacionesFechaPago, P00D85_A580OperacionesComprobantePago, P00D85_n580OperacionesComprobantePago
               }
               , new Object[] {
               }
               , new Object[] {
               P00D87_A184SolicitudesFechaInstalacion, P00D87_A131EstadosSolId, P00D87_A130EstadosSolTipo, P00D87_A688SolicitudesLiqProf, P00D87_n688SolicitudesLiqProf, P00D87_A142EstadoSGId, P00D87_A141EstadoSGTipo, P00D87_A120ProfesionalesId, P00D87_A127SolicitudesID, P00D87_A171SolicitudesNombre,
               P00D87_A132EstadosSolNombre, P00D87_A438SolicitudServicioOrigenPago, P00D87_n438SolicitudServicioOrigenPago, P00D87_A128MetodoPagosID, P00D87_A669STMonedasId, P00D87_n669STMonedasId, P00D87_A671STMonedasISO, P00D87_A133ProveedorID, P00D87_A282ProveedorNombre, P00D87_A796SolicitudesComisionMetodoPago,
               P00D87_A212SolicitudesCotizacion, P00D87_A1016SolicitudesDescuentoCupon, P00D87_A897SolicitudesDescuento, P00D87_n897SolicitudesDescuento, P00D87_A527SolicitudServicioComProv, P00D87_n527SolicitudServicioComProv, P00D87_A530SolicitudServicioComALM, P00D87_n530SolicitudServicioComALM, P00D87_A865SolicitudesCostoXZComAlm, P00D87_n865SolicitudesCostoXZComAlm,
               P00D87_A864SolicitudesCostoXZona, P00D87_A140RelacionesId
               }
               , new Object[] {
               P00D88_A133ProveedorID, P00D88_A184SolicitudesFechaInstalacion, P00D88_A131EstadosSolId, P00D88_A130EstadosSolTipo, P00D88_A689SolicitudesLiqProv, P00D88_n689SolicitudesLiqProv, P00D88_A127SolicitudesID, P00D88_A171SolicitudesNombre, P00D88_A527SolicitudServicioComProv, P00D88_n527SolicitudServicioComProv,
               P00D88_A530SolicitudServicioComALM, P00D88_n530SolicitudServicioComALM, P00D88_A132EstadosSolNombre, P00D88_A438SolicitudServicioOrigenPago, P00D88_n438SolicitudServicioOrigenPago, P00D88_A128MetodoPagosID, P00D88_A669STMonedasId, P00D88_n669STMonedasId, P00D88_A671STMonedasISO, P00D88_A796SolicitudesComisionMetodoPago,
               P00D88_A212SolicitudesCotizacion, P00D88_A1016SolicitudesDescuentoCupon, P00D88_A897SolicitudesDescuento, P00D88_n897SolicitudesDescuento, P00D88_A864SolicitudesCostoXZona
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P00D811_A127SolicitudesID, P00D811_A134SolicitudesItemsID, P00D811_A180SolicitudItemsComision, P00D811_A179SolicitudItemsComisionTipo, P00D811_A178SolicitudItemsSR, P00D811_A177SolicitudesItemsCantidad, P00D811_A176SolicitudesItemsPrecioFinal, P00D811_n176SolicitudesItemsPrecioFinal
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV35monedaId ;
      private short GXTD84 ;
      private short AV43WalletBalancesConcepto ;
      private short A669STMonedasId ;
      private int AV61GXV1 ;
      private int A131EstadosSolId ;
      private int A142EstadoSGId ;
      private int GX_INS82 ;
      private int GX_INS94 ;
      private long AV56OperacionPreviaId ;
      private long A554OperacionesId ;
      private long AV38UserId ;
      private long AV18OperacionesId ;
      private long AV46BalId ;
      private long A1012WalletBalanceLiquidacion ;
      private long A640WalletBalancesId ;
      private long A637WalletId ;
      private long A688SolicitudesLiqProf ;
      private long A127SolicitudesID ;
      private long A128MetodoPagosID ;
      private long A133ProveedorID ;
      private long A140RelacionesId ;
      private long AV12SolicitudesID ;
      private long AV40MetodoPago ;
      private long AV50ProveedorId ;
      private long A689SolicitudesLiqProv ;
      private long GXt_int2 ;
      private long A662OperacionesMonId ;
      private long A666OperacionesUsrAlta ;
      private long A667OperacionesUsrActualizacion ;
      private long A650OperacionesSolicitudesId ;
      private long A660OperacionesSolicitudesProvID ;
      private decimal AV32CobrosProf ;
      private decimal AV33CobrosComercio ;
      private decimal AV45TotalBalances ;
      private decimal AV27TotalOrden ;
      private decimal AV28TotalComisionProveedor ;
      private decimal AV29TotalAlmango ;
      private decimal A644WalletBalancesImporte ;
      private decimal AV47NetoSolicitudes ;
      private decimal AV48TotalLiquidacion ;
      private decimal A570OperacionesImporte ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A897SolicitudesDescuento ;
      private decimal A527SolicitudServicioComProv ;
      private decimal A530SolicitudServicioComALM ;
      private decimal A865SolicitudesCostoXZComAlm ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal A174SolicitudesTotal ;
      private decimal A529SolicitudServicioComPro ;
      private decimal A867SolicitudesCostoXZComProf ;
      private decimal AV52ComisionZonaALM ;
      private decimal AV53ComisionZonaProf ;
      private decimal AV49ComisionProf ;
      private decimal AV25ComisionALM ;
      private decimal AV24ComisionProv ;
      private decimal AV9Importe ;
      private decimal A654OperacionesSolicitudesPFinal ;
      private decimal A655OperacionesSolicitudesComProv ;
      private decimal A656OperacionesSolicitudesComALM ;
      private decimal A1027OperacionesSolicitudesXZComAlm ;
      private decimal A1029OperacionesSolicitudesXZComPro ;
      private decimal A653OperacionesSolicitudesComPro ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private string AV21OperacionesTipo ;
      private string AV20OperacionesRef ;
      private string AV19OperacionesNombreRef ;
      private string Gx_msg ;
      private string A577OperacionesEstado ;
      private string A649OperacionesTipo ;
      private string A555OperacionesRef ;
      private string AV37MonedaISO ;
      private string A645WalletBalancesEstadoOPE ;
      private string A643WalletBalancesTipoMov ;
      private string AV31TipoEntidad ;
      private string A580OperacionesComprobantePago ;
      private string AV39TipoMov ;
      private string A130EstadosSolTipo ;
      private string A141EstadoSGTipo ;
      private string A120ProfesionalesId ;
      private string A171SolicitudesNombre ;
      private string A132EstadosSolNombre ;
      private string A438SolicitudServicioOrigenPago ;
      private string A671STMonedasISO ;
      private string A282ProveedorNombre ;
      private string AV23NombreCliente ;
      private string AV8Estado ;
      private string AV10OrigenPago ;
      private string AV51ProveedorNombre ;
      private string A657OperacionesNombreRef ;
      private string A571OperacionesMoneda ;
      private string Gx_emsg ;
      private string A651OperacionesSolicitudesNombre ;
      private string A668OperacionesSolicitudesOrigenPa ;
      private string A661OperacionesSolicitudesProvNomb ;
      private DateTime A582OperacionesFechaPago ;
      private DateTime AV16OperacionesFechaDesde ;
      private DateTime AV17OperacionesFechaHasta ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private DateTime AV26Fecha ;
      private DateTime A581OperacionesFechaAlta ;
      private DateTime A658OperacionesFechaDesde ;
      private DateTime A659OperacionesFechaHasta ;
      private bool AV36IsOk ;
      private bool n577OperacionesEstado ;
      private bool n1028OperacionesPeriodoCod ;
      private bool n649OperacionesTipo ;
      private bool n555OperacionesRef ;
      private bool AV57Ok ;
      private bool returnInSub ;
      private bool n1012WalletBalanceLiquidacion ;
      private bool n570OperacionesImporte ;
      private bool n582OperacionesFechaPago ;
      private bool n580OperacionesComprobantePago ;
      private bool n688SolicitudesLiqProf ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool n669STMonedasId ;
      private bool n897SolicitudesDescuento ;
      private bool n527SolicitudServicioComProv ;
      private bool n530SolicitudServicioComALM ;
      private bool n865SolicitudesCostoXZComAlm ;
      private bool n689SolicitudesLiqProv ;
      private bool n657OperacionesNombreRef ;
      private bool n662OperacionesMonId ;
      private bool n571OperacionesMoneda ;
      private bool n581OperacionesFechaAlta ;
      private bool n658OperacionesFechaDesde ;
      private bool n659OperacionesFechaHasta ;
      private bool n666OperacionesUsrAlta ;
      private bool n667OperacionesUsrActualizacion ;
      private bool n651OperacionesSolicitudesNombre ;
      private bool n668OperacionesSolicitudesOrigenPa ;
      private bool n654OperacionesSolicitudesPFinal ;
      private bool n655OperacionesSolicitudesComProv ;
      private bool n656OperacionesSolicitudesComALM ;
      private bool n1027OperacionesSolicitudesXZComAlm ;
      private bool n1029OperacionesSolicitudesXZComPro ;
      private bool n653OperacionesSolicitudesComPro ;
      private bool n660OperacionesSolicitudesProvID ;
      private bool n661OperacionesSolicitudesProvNomb ;
      private string AV55OperacionesPeriodoCod ;
      private string A1028OperacionesPeriodoCod ;
      private string AV42WalletBalancesObs ;
      private string AV41WalletBalancesUrl ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV44BalancesSeleccionados ;
      private IDataStoreProvider pr_default ;
      private string[] P00D82_A577OperacionesEstado ;
      private bool[] P00D82_n577OperacionesEstado ;
      private string[] P00D82_A1028OperacionesPeriodoCod ;
      private bool[] P00D82_n1028OperacionesPeriodoCod ;
      private string[] P00D82_A649OperacionesTipo ;
      private bool[] P00D82_n649OperacionesTipo ;
      private string[] P00D82_A555OperacionesRef ;
      private bool[] P00D82_n555OperacionesRef ;
      private long[] P00D82_A554OperacionesId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV14contextww ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private string[] P00D83_A645WalletBalancesEstadoOPE ;
      private long[] P00D83_A1012WalletBalanceLiquidacion ;
      private bool[] P00D83_n1012WalletBalanceLiquidacion ;
      private long[] P00D83_A640WalletBalancesId ;
      private string[] P00D83_A643WalletBalancesTipoMov ;
      private decimal[] P00D83_A644WalletBalancesImporte ;
      private long[] P00D83_A637WalletId ;
      private long[] P00D85_A554OperacionesId ;
      private decimal[] P00D85_A570OperacionesImporte ;
      private bool[] P00D85_n570OperacionesImporte ;
      private string[] P00D85_A577OperacionesEstado ;
      private bool[] P00D85_n577OperacionesEstado ;
      private DateTime[] P00D85_A582OperacionesFechaPago ;
      private bool[] P00D85_n582OperacionesFechaPago ;
      private string[] P00D85_A580OperacionesComprobantePago ;
      private bool[] P00D85_n580OperacionesComprobantePago ;
      private DateTime[] P00D87_A184SolicitudesFechaInstalacion ;
      private int[] P00D87_A131EstadosSolId ;
      private string[] P00D87_A130EstadosSolTipo ;
      private long[] P00D87_A688SolicitudesLiqProf ;
      private bool[] P00D87_n688SolicitudesLiqProf ;
      private int[] P00D87_A142EstadoSGId ;
      private string[] P00D87_A141EstadoSGTipo ;
      private string[] P00D87_A120ProfesionalesId ;
      private long[] P00D87_A127SolicitudesID ;
      private string[] P00D87_A171SolicitudesNombre ;
      private string[] P00D87_A132EstadosSolNombre ;
      private string[] P00D87_A438SolicitudServicioOrigenPago ;
      private bool[] P00D87_n438SolicitudServicioOrigenPago ;
      private long[] P00D87_A128MetodoPagosID ;
      private short[] P00D87_A669STMonedasId ;
      private bool[] P00D87_n669STMonedasId ;
      private string[] P00D87_A671STMonedasISO ;
      private long[] P00D87_A133ProveedorID ;
      private string[] P00D87_A282ProveedorNombre ;
      private decimal[] P00D87_A796SolicitudesComisionMetodoPago ;
      private decimal[] P00D87_A212SolicitudesCotizacion ;
      private decimal[] P00D87_A1016SolicitudesDescuentoCupon ;
      private decimal[] P00D87_A897SolicitudesDescuento ;
      private bool[] P00D87_n897SolicitudesDescuento ;
      private decimal[] P00D87_A527SolicitudServicioComProv ;
      private bool[] P00D87_n527SolicitudServicioComProv ;
      private decimal[] P00D87_A530SolicitudServicioComALM ;
      private bool[] P00D87_n530SolicitudServicioComALM ;
      private decimal[] P00D87_A865SolicitudesCostoXZComAlm ;
      private bool[] P00D87_n865SolicitudesCostoXZComAlm ;
      private decimal[] P00D87_A864SolicitudesCostoXZona ;
      private long[] P00D87_A140RelacionesId ;
      private long[] P00D88_A133ProveedorID ;
      private DateTime[] P00D88_A184SolicitudesFechaInstalacion ;
      private int[] P00D88_A131EstadosSolId ;
      private string[] P00D88_A130EstadosSolTipo ;
      private long[] P00D88_A689SolicitudesLiqProv ;
      private bool[] P00D88_n689SolicitudesLiqProv ;
      private long[] P00D88_A127SolicitudesID ;
      private string[] P00D88_A171SolicitudesNombre ;
      private decimal[] P00D88_A527SolicitudServicioComProv ;
      private bool[] P00D88_n527SolicitudServicioComProv ;
      private decimal[] P00D88_A530SolicitudServicioComALM ;
      private bool[] P00D88_n530SolicitudServicioComALM ;
      private string[] P00D88_A132EstadosSolNombre ;
      private string[] P00D88_A438SolicitudServicioOrigenPago ;
      private bool[] P00D88_n438SolicitudServicioOrigenPago ;
      private long[] P00D88_A128MetodoPagosID ;
      private short[] P00D88_A669STMonedasId ;
      private bool[] P00D88_n669STMonedasId ;
      private string[] P00D88_A671STMonedasISO ;
      private decimal[] P00D88_A796SolicitudesComisionMetodoPago ;
      private decimal[] P00D88_A212SolicitudesCotizacion ;
      private decimal[] P00D88_A1016SolicitudesDescuentoCupon ;
      private decimal[] P00D88_A897SolicitudesDescuento ;
      private bool[] P00D88_n897SolicitudesDescuento ;
      private decimal[] P00D88_A864SolicitudesCostoXZona ;
      private long[] P00D811_A127SolicitudesID ;
      private short[] P00D811_A134SolicitudesItemsID ;
      private decimal[] P00D811_A180SolicitudItemsComision ;
      private string[] P00D811_A179SolicitudItemsComisionTipo ;
      private string[] P00D811_A178SolicitudItemsSR ;
      private short[] P00D811_A177SolicitudesItemsCantidad ;
      private decimal[] P00D811_A176SolicitudesItemsPrecioFinal ;
      private bool[] P00D811_n176SolicitudesItemsPrecioFinal ;
      private string aP7_Gx_msg ;
      private bool aP8_IsOk ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class aliquidacionsolicitudes__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class aliquidacionsolicitudes__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new UpdateCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new UpdateCursor(def[4])
       ,new ForEachCursor(def[5])
       ,new ForEachCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00D82;
        prmP00D82 = new Object[] {
        new ParDef("@AV21OperacionesTipo",GXType.NChar,3,0) ,
        new ParDef("@AV55OperacionesPeriodoCod",GXType.NVarChar,10,0) ,
        new ParDef("@AV20OperacionesRef",GXType.NChar,25,0)
        };
        Object[] prmP00D83;
        prmP00D83 = new Object[] {
        new ParDef("@AV46BalId",GXType.Decimal,18,0)
        };
        Object[] prmP00D84;
        prmP00D84 = new Object[] {
        new ParDef("@WalletBalancesEstadoOPE",GXType.NChar,3,0) ,
        new ParDef("@WalletBalanceLiquidacion",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@WalletId",GXType.Decimal,18,0) ,
        new ParDef("@WalletBalancesId",GXType.Decimal,18,0)
        };
        Object[] prmP00D85;
        prmP00D85 = new Object[] {
        new ParDef("@AV18OperacionesId",GXType.Decimal,18,0)
        };
        Object[] prmP00D86;
        prmP00D86 = new Object[] {
        new ParDef("@OperacionesImporte",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@OperacionesEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@OperacionesFechaPago",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@OperacionesComprobantePago",GXType.NChar,256,0){Nullable=true} ,
        new ParDef("@OperacionesId",GXType.Decimal,18,0)
        };
        Object[] prmP00D87;
        prmP00D87 = new Object[] {
        new ParDef("@AV20OperacionesRef",GXType.Char,25,0) ,
        new ParDef("@AV16OperacionesFechaDesde",GXType.Date,8,0) ,
        new ParDef("@AV17OperacionesFechaHasta",GXType.Date,8,0)
        };
        Object[] prmP00D88;
        prmP00D88 = new Object[] {
        new ParDef("@AV16OperacionesFechaDesde",GXType.Date,8,0) ,
        new ParDef("@AV17OperacionesFechaHasta",GXType.Date,8,0) ,
        new ParDef("@AV20OperacionesRef",GXType.Char,25,0)
        };
        Object[] prmP00D89;
        prmP00D89 = new Object[] {
        new ParDef("@OperacionesId",GXType.Decimal,18,0) ,
        new ParDef("@OperacionesRef",GXType.NChar,25,0){Nullable=true} ,
        new ParDef("@OperacionesMoneda",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@OperacionesFechaAlta",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@OperacionesEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@OperacionesTipo",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@OperacionesNombreRef",GXType.NChar,120,0){Nullable=true} ,
        new ParDef("@OperacionesFechaDesde",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@OperacionesFechaHasta",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@OperacionesMonId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@OperacionesUsrAlta",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@OperacionesUsrActualizacion",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@OperacionesPeriodoCod",GXType.NVarChar,10,0){Nullable=true}
        };
        Object[] prmP00D810;
        prmP00D810 = new Object[] {
        new ParDef("@OperacionesId",GXType.Decimal,18,0) ,
        new ParDef("@OperacionesSolicitudesId",GXType.Decimal,18,0) ,
        new ParDef("@OperacionesSolicitudesComPro",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@OperacionesSolicitudesPFinal",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@OperacionesSolicitudesNombre",GXType.NChar,120,0){Nullable=true} ,
        new ParDef("@OperacionesSolicitudesComProv",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@OperacionesSolicitudesComALM",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@OperacionesSolicitudesProvID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@OperacionesSolicitudesProvNomb",GXType.NChar,120,0){Nullable=true} ,
        new ParDef("@OperacionesSolicitudesOrigenPa",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@OperacionesSolicitudesXZComPro",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@OperacionesSolicitudesXZComAlm",GXType.Decimal,18,2){Nullable=true}
        };
        Object[] prmP00D811;
        prmP00D811 = new Object[] {
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00D82", "SELECT TOP 1 [OperacionesEstado], [OperacionesPeriodoCod], [OperacionesTipo], [OperacionesRef], [OperacionesId] FROM [Operaciones] WHERE ([OperacionesEstado] <> 'ANU') AND ([OperacionesTipo] = @AV21OperacionesTipo) AND ([OperacionesPeriodoCod] = @AV55OperacionesPeriodoCod) AND ([OperacionesRef] = @AV20OperacionesRef) ORDER BY [OperacionesRef] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D82,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("P00D83", "SELECT [WalletBalancesEstadoOPE], [WalletBalanceLiquidacion], [WalletBalancesId], [WalletBalancesTipoMov], [WalletBalancesImporte], [WalletId] FROM [WalletBalances] WITH (UPDLOCK) WHERE ([WalletBalanceLiquidacion] IS NULL or ([WalletBalanceLiquidacion] = convert(int, 0)) or [WalletBalanceLiquidacion] = 0) AND ([WalletBalancesId] = @AV46BalId) AND ([WalletBalancesEstadoOPE] = 'PND') ORDER BY [WalletId], [WalletBalancesId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D83,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00D84", "UPDATE [WalletBalances] SET [WalletBalancesEstadoOPE]=@WalletBalancesEstadoOPE, [WalletBalanceLiquidacion]=@WalletBalanceLiquidacion  WHERE [WalletId] = @WalletId AND [WalletBalancesId] = @WalletBalancesId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00D84)
           ,new CursorDef("P00D85", "SELECT [OperacionesId], [OperacionesImporte], [OperacionesEstado], [OperacionesFechaPago], [OperacionesComprobantePago] FROM [Operaciones] WITH (UPDLOCK) WHERE [OperacionesId] = @AV18OperacionesId ORDER BY [OperacionesId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D85,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P00D86", "UPDATE [Operaciones] SET [OperacionesImporte]=@OperacionesImporte, [OperacionesEstado]=@OperacionesEstado, [OperacionesFechaPago]=@OperacionesFechaPago, [OperacionesComprobantePago]=@OperacionesComprobantePago  WHERE [OperacionesId] = @OperacionesId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00D86)
           ,new CursorDef("P00D87", "SELECT T2.[SolicitudesFechaInstalacion], T2.[EstadosSolId] AS EstadosSolId, T2.[EstadosSolTipo] AS EstadosSolTipo, T2.[SolicitudesLiqProf], T1.[EstadoSGId], T1.[EstadoSGTipo], T1.[ProfesionalesId], T1.[SolicitudesID], T2.[SolicitudesNombre], T3.[EstadosGenericosNombre] AS EstadosSolNombre, T2.[SolicitudServicioOrigenPago], T2.[MetodoPagosID], T2.[STMonedasId] AS STMonedasId, T4.[MonedaISOSimbolo] AS STMonedasISO, T2.[ProveedorID], T5.[ProveedorNombre], T2.[SolicitudesComisionMetodoPago], T2.[SolicitudesCotizacion], T2.[SolicitudesDescuentoCupon], T2.[SolicitudesDescuento], T2.[SolicitudServicioComProv], T2.[SolicitudServicioComALM], T2.[SolicitudesCostoXZComAlm], T2.[SolicitudesCostoXZona], T1.[RelacionesId] FROM (((([Relaciones] T1 INNER JOIN [Solicitudes] T2 ON T2.[SolicitudesID] = T1.[SolicitudesID]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T2.[EstadosSolTipo] AND T3.[EstadosGenericosId] = T2.[EstadosSolId]) LEFT JOIN [Moneda] T4 ON T4.[MonedaId] = T2.[STMonedasId]) INNER JOIN [Proveedor] T5 ON T5.[ProveedorID] = T2.[ProveedorID]) WHERE (T1.[ProfesionalesId] = @AV20OperacionesRef) AND (T2.[SolicitudesLiqProf] IS NULL or (T2.[SolicitudesLiqProf] = convert(int, 0)) or T2.[SolicitudesLiqProf] = 0) AND (T2.[EstadosSolId] = 6 or T2.[EstadosSolId] = 7 or T2.[EstadosSolId] = 5 or T2.[EstadosSolId] = 2) AND (T2.[SolicitudesFechaInstalacion] >= @AV16OperacionesFechaDesde) AND (T2.[SolicitudesFechaInstalacion] <= @AV17OperacionesFechaHasta) AND (T1.[EstadoSGId] = 1) ORDER BY T1.[ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D87,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00D88", "SELECT T1.[ProveedorID], T1.[SolicitudesFechaInstalacion], T1.[EstadosSolId] AS EstadosSolId, T1.[EstadosSolTipo] AS EstadosSolTipo, T1.[SolicitudesLiqProv], T1.[SolicitudesID], T1.[SolicitudesNombre], T1.[SolicitudServicioComProv], T1.[SolicitudServicioComALM], T2.[EstadosGenericosNombre] AS EstadosSolNombre, T1.[SolicitudServicioOrigenPago], T1.[MetodoPagosID], T1.[STMonedasId] AS STMonedasId, T3.[MonedaISOSimbolo] AS STMonedasISO, T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudesCostoXZona] FROM (([Solicitudes] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosSolTipo] AND T2.[EstadosGenericosId] = T1.[EstadosSolId]) LEFT JOIN [Moneda] T3 ON T3.[MonedaId] = T1.[STMonedasId]) WHERE (T1.[SolicitudesLiqProv] IS NULL) AND (T1.[EstadosSolId] = 6 or T1.[EstadosSolId] = 7) AND (T1.[SolicitudesFechaInstalacion] >= @AV16OperacionesFechaDesde) AND (T1.[SolicitudesFechaInstalacion] <= @AV17OperacionesFechaHasta) AND (T1.[ProveedorID] = CONVERT( DECIMAL(28,14), @AV20OperacionesRef)) ORDER BY T1.[SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D88,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00D89", "INSERT INTO [Operaciones]([OperacionesId], [OperacionesRef], [OperacionesMoneda], [OperacionesFechaAlta], [OperacionesEstado], [OperacionesTipo], [OperacionesNombreRef], [OperacionesFechaDesde], [OperacionesFechaHasta], [OperacionesMonId], [OperacionesUsrAlta], [OperacionesUsrActualizacion], [OperacionesPeriodoCod], [OperacionesOrdinal], [OperacionesIDORD], [OperacionesTipoES], [OperacionesImporte], [OperacionesFacturaCod], [OperacionesIva], [OperacionesComision], [OperacionesImporteGrabado], [OperacionesRequest], [OperacionesResponse], [OperacionesComprobantePago], [OperacionesFechaPago], [OperacionesAux1], [OperacionesAux2], [OperacionesAux3], [OperacionesBlob1], [OperacionesBlob2], [OperacionesComercioId1], [OperacionesComercioId2]) VALUES(@OperacionesId, @OperacionesRef, @OperacionesMoneda, @OperacionesFechaAlta, @OperacionesEstado, @OperacionesTipo, @OperacionesNombreRef, @OperacionesFechaDesde, @OperacionesFechaHasta, @OperacionesMonId, @OperacionesUsrAlta, @OperacionesUsrActualizacion, @OperacionesPeriodoCod, convert(int, 0), '', '', convert(int, 0), '', convert(int, 0), convert(int, 0), convert(int, 0), '', '', '', convert( DATETIME, '17530101', 112 ), '', '', '', CONVERT(varbinary(1), ''), CONVERT(varbinary(1), ''), convert(int, 0), convert(int, 0))", GxErrorMask.GX_NOMASK,prmP00D89)
           ,new CursorDef("P00D810", "INSERT INTO [OperacionesSolicitudes]([OperacionesId], [OperacionesSolicitudesId], [OperacionesSolicitudesComPro], [OperacionesSolicitudesPFinal], [OperacionesSolicitudesNombre], [OperacionesSolicitudesComProv], [OperacionesSolicitudesComALM], [OperacionesSolicitudesProvID], [OperacionesSolicitudesProvNomb], [OperacionesSolicitudesOrigenPa], [OperacionesSolicitudesXZComPro], [OperacionesSolicitudesXZComAlm]) VALUES(@OperacionesId, @OperacionesSolicitudesId, @OperacionesSolicitudesComPro, @OperacionesSolicitudesPFinal, @OperacionesSolicitudesNombre, @OperacionesSolicitudesComProv, @OperacionesSolicitudesComALM, @OperacionesSolicitudesProvID, @OperacionesSolicitudesProvNomb, @OperacionesSolicitudesOrigenPa, @OperacionesSolicitudesXZComPro, @OperacionesSolicitudesXZComAlm)", GxErrorMask.GX_NOMASK,prmP00D810)
           ,new CursorDef("P00D811", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D811,100, GxCacheFrequency.OFF ,true,false )
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
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getVarchar(2);
              ((bool[]) buf[3])[0] = rslt.wasNull(2);
              ((string[]) buf[4])[0] = rslt.getString(3, 3);
              ((bool[]) buf[5])[0] = rslt.wasNull(3);
              ((string[]) buf[6])[0] = rslt.getString(4, 25);
              ((bool[]) buf[7])[0] = rslt.wasNull(4);
              ((long[]) buf[8])[0] = rslt.getLong(5);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((long[]) buf[3])[0] = rslt.getLong(3);
              ((string[]) buf[4])[0] = rslt.getString(4, 3);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getString(3, 3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getString(5, 256);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              return;
           case 5 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((int[]) buf[5])[0] = rslt.getInt(5);
              ((string[]) buf[6])[0] = rslt.getString(6, 3);
              ((string[]) buf[7])[0] = rslt.getString(7, 20);
              ((long[]) buf[8])[0] = rslt.getLong(8);
              ((string[]) buf[9])[0] = rslt.getString(9, 100);
              ((string[]) buf[10])[0] = rslt.getString(10, 80);
              ((string[]) buf[11])[0] = rslt.getString(11, 1);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              ((long[]) buf[13])[0] = rslt.getLong(12);
              ((short[]) buf[14])[0] = rslt.getShort(13);
              ((bool[]) buf[15])[0] = rslt.wasNull(13);
              ((string[]) buf[16])[0] = rslt.getString(14, 3);
              ((long[]) buf[17])[0] = rslt.getLong(15);
              ((string[]) buf[18])[0] = rslt.getString(16, 80);
              ((decimal[]) buf[19])[0] = rslt.getDecimal(17);
              ((decimal[]) buf[20])[0] = rslt.getDecimal(18);
              ((decimal[]) buf[21])[0] = rslt.getDecimal(19);
              ((decimal[]) buf[22])[0] = rslt.getDecimal(20);
              ((bool[]) buf[23])[0] = rslt.wasNull(20);
              ((decimal[]) buf[24])[0] = rslt.getDecimal(21);
              ((bool[]) buf[25])[0] = rslt.wasNull(21);
              ((decimal[]) buf[26])[0] = rslt.getDecimal(22);
              ((bool[]) buf[27])[0] = rslt.wasNull(22);
              ((decimal[]) buf[28])[0] = rslt.getDecimal(23);
              ((bool[]) buf[29])[0] = rslt.wasNull(23);
              ((decimal[]) buf[30])[0] = rslt.getDecimal(24);
              ((long[]) buf[31])[0] = rslt.getLong(25);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 100);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((string[]) buf[12])[0] = rslt.getString(10, 80);
              ((string[]) buf[13])[0] = rslt.getString(11, 1);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              ((long[]) buf[15])[0] = rslt.getLong(12);
              ((short[]) buf[16])[0] = rslt.getShort(13);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
              ((string[]) buf[18])[0] = rslt.getString(14, 3);
              ((decimal[]) buf[19])[0] = rslt.getDecimal(15);
              ((decimal[]) buf[20])[0] = rslt.getDecimal(16);
              ((decimal[]) buf[21])[0] = rslt.getDecimal(17);
              ((decimal[]) buf[22])[0] = rslt.getDecimal(18);
              ((bool[]) buf[23])[0] = rslt.wasNull(18);
              ((decimal[]) buf[24])[0] = rslt.getDecimal(19);
              return;
           case 9 :
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
