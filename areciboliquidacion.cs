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
   public class areciboliquidacion : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "areciboliquidacion.aspx")), "areciboliquidacion.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "areciboliquidacion.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "OperacionesId");
            if ( ! entryPointCalled )
            {
               AV13OperacionesId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public areciboliquidacion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public areciboliquidacion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_OperacionesId )
      {
         this.AV13OperacionesId = aP0_OperacionesId;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_OperacionesId )
      {
         this.AV13OperacionesId = aP0_OperacionesId;
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
         setOutputFileName(AV11NombreArchivo);
         setOutputType("PDF");
         try
         {
            Gx_out = "SCR" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 12067, 0, 1, 1, 0, 1, 1) )
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
            AV24TotalServicios = 0;
            AV23TotalComProv = 0;
            AV22TotalComProf = 0;
            AV21TotalComAlmango = 0;
            AV20TotalCobrosDirect = 0;
            AV19TotalAjustesBal = 0;
            /* Using cursor P00NG2 */
            pr_default.execute(0, new Object[] {AV13OperacionesId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A555OperacionesRef = P00NG2_A555OperacionesRef[0];
               n555OperacionesRef = P00NG2_n555OperacionesRef[0];
               A554OperacionesId = P00NG2_A554OperacionesId[0];
               A659OperacionesFechaHasta = P00NG2_A659OperacionesFechaHasta[0];
               n659OperacionesFechaHasta = P00NG2_n659OperacionesFechaHasta[0];
               A658OperacionesFechaDesde = P00NG2_A658OperacionesFechaDesde[0];
               n658OperacionesFechaDesde = P00NG2_n658OperacionesFechaDesde[0];
               A581OperacionesFechaAlta = P00NG2_A581OperacionesFechaAlta[0];
               n581OperacionesFechaAlta = P00NG2_n581OperacionesFechaAlta[0];
               A657OperacionesNombreRef = P00NG2_A657OperacionesNombreRef[0];
               n657OperacionesNombreRef = P00NG2_n657OperacionesNombreRef[0];
               A570OperacionesImporte = P00NG2_A570OperacionesImporte[0];
               n570OperacionesImporte = P00NG2_n570OperacionesImporte[0];
               if ( ! (DateTime.MinValue==A658OperacionesFechaDesde) && ! (DateTime.MinValue==A659OperacionesFechaHasta) )
               {
                  AV16PeriodoStr = context.localUtil.DToC( A658OperacionesFechaDesde, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/") + " | " + context.localUtil.DToC( A659OperacionesFechaHasta, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/");
               }
               else
               {
                  AV16PeriodoStr = context.localUtil.Format( A581OperacionesFechaAlta, "99/99/99");
               }
               AV15OperacionesNombreRef = A657OperacionesNombreRef;
               AV14OperacionesImporte = A570OperacionesImporte;
               /* Using cursor P00NG3 */
               pr_default.execute(1, new Object[] {n555OperacionesRef, A555OperacionesRef});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A639WalletCodRefencia = P00NG3_A639WalletCodRefencia[0];
                  A638WalletTipoEntidad = P00NG3_A638WalletTipoEntidad[0];
                  A637WalletId = P00NG3_A637WalletId[0];
                  GXt_decimal1 = A646WalletTotalDebito;
                  new owallettotaldc(context ).execute(  A637WalletId,  "DEB", out  GXt_decimal1) ;
                  A646WalletTotalDebito = GXt_decimal1;
                  GXt_decimal1 = A647WalletTotalCredito;
                  new owallettotaldc(context ).execute(  A637WalletId,  "CRE", out  GXt_decimal1) ;
                  A647WalletTotalCredito = GXt_decimal1;
                  A648WalletSaldo = (decimal)(A647WalletTotalCredito-A646WalletTotalDebito);
                  GXt_char2 = A715WalletNombre;
                  new onombrewallet(context ).execute(  A638WalletTipoEntidad,  A639WalletCodRefencia, out  GXt_char2) ;
                  A715WalletNombre = GXt_char2;
                  AV25WalletSaldo = A648WalletSaldo;
                  AV8WalletNombre = A715WalletNombre;
                  AV17ProfesionalId = A639WalletCodRefencia;
                  AV11NombreArchivo = context.GetMessage( "Liquidacion-", "") + StringUtil.Trim( AV8WalletNombre);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               AV18Titulo = "Liquidacion " + StringUtil.Trim( AV8WalletNombre) + " - " + StringUtil.Trim( AV17ProfesionalId) + " - Periodo " + AV16PeriodoStr;
               HNG0( false, 106) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 317, Gx_line+33, 393, Gx_line+47, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 267, Gx_line+33, 306, Gx_line+47, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Fecha", ""), 267, Gx_line+17, 416, Gx_line+31, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18Titulo, "")), 8, Gx_line+67, 808, Gx_line+89, 0, 0, 0, 1) ;
               getPrinter().GxDrawBitMap(context.GetImagePath( "e6acfd2e-013a-4b78-9d37-37f6dc906ba7", "", context.GetTheme( )), 2, Gx_line+-5, 190, Gx_line+58) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+106);
               AV10HaySolicitudes = false;
               /* Using cursor P00NG4 */
               pr_default.execute(2, new Object[] {AV13OperacionesId});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A554OperacionesId = P00NG4_A554OperacionesId[0];
                  A654OperacionesSolicitudesPFinal = P00NG4_A654OperacionesSolicitudesPFinal[0];
                  n654OperacionesSolicitudesPFinal = P00NG4_n654OperacionesSolicitudesPFinal[0];
                  A655OperacionesSolicitudesComProv = P00NG4_A655OperacionesSolicitudesComProv[0];
                  n655OperacionesSolicitudesComProv = P00NG4_n655OperacionesSolicitudesComProv[0];
                  A653OperacionesSolicitudesComPro = P00NG4_A653OperacionesSolicitudesComPro[0];
                  n653OperacionesSolicitudesComPro = P00NG4_n653OperacionesSolicitudesComPro[0];
                  A656OperacionesSolicitudesComALM = P00NG4_A656OperacionesSolicitudesComALM[0];
                  n656OperacionesSolicitudesComALM = P00NG4_n656OperacionesSolicitudesComALM[0];
                  A1027OperacionesSolicitudesXZComAlm = P00NG4_A1027OperacionesSolicitudesXZComAlm[0];
                  n1027OperacionesSolicitudesXZComAlm = P00NG4_n1027OperacionesSolicitudesXZComAlm[0];
                  A668OperacionesSolicitudesOrigenPa = P00NG4_A668OperacionesSolicitudesOrigenPa[0];
                  n668OperacionesSolicitudesOrigenPa = P00NG4_n668OperacionesSolicitudesOrigenPa[0];
                  A661OperacionesSolicitudesProvNomb = P00NG4_A661OperacionesSolicitudesProvNomb[0];
                  n661OperacionesSolicitudesProvNomb = P00NG4_n661OperacionesSolicitudesProvNomb[0];
                  A650OperacionesSolicitudesId = P00NG4_A650OperacionesSolicitudesId[0];
                  AV24TotalServicios = (decimal)(AV24TotalServicios+A654OperacionesSolicitudesPFinal);
                  AV23TotalComProv = (decimal)(AV23TotalComProv+A655OperacionesSolicitudesComProv);
                  AV22TotalComProf = (decimal)(AV22TotalComProf+A653OperacionesSolicitudesComPro);
                  AV21TotalComAlmango = (decimal)(AV21TotalComAlmango+A656OperacionesSolicitudesComALM);
                  AV21TotalComAlmango = (decimal)(AV21TotalComAlmango+A1027OperacionesSolicitudesXZComAlm);
                  if ( StringUtil.StrCmp(A668OperacionesSolicitudesOrigenPa, "F") == 0 )
                  {
                     AV20TotalCobrosDirect = (decimal)(AV20TotalCobrosDirect+A654OperacionesSolicitudesPFinal);
                  }
                  if ( ! AV10HaySolicitudes )
                  {
                     HNG0( false, 53) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.GetMessage( "Id", ""), 17, Gx_line+33, 27, Gx_line+47, 0+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Com.Prov", ""), 617, Gx_line+33, 684, Gx_line+47, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Cliente", ""), 92, Gx_line+33, 242, Gx_line+47, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Precio final", ""), 300, Gx_line+33, 375, Gx_line+47, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Com.Amg", ""), 508, Gx_line+33, 591, Gx_line+47, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Origen pago", ""), 708, Gx_line+33, 833, Gx_line+47, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Com. Prof", ""), 400, Gx_line+33, 483, Gx_line+47, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "SOLICITUDES", ""), 17, Gx_line+17, 104, Gx_line+31, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+53);
                     AV10HaySolicitudes = true;
                  }
                  if ( StringUtil.StrCmp(A668OperacionesSolicitudesOrigenPa, "F") == 0 )
                  {
                     HNG0( false, 45) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A656OperacionesSolicitudesComALM, "ZZZZZZZZZZZZZZ9.99")), 508, Gx_line+17, 591, Gx_line+32, 0, 0, 0, 1) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A653OperacionesSolicitudesComPro, "ZZZZZZZZZZZZZZ9.99")), 400, Gx_line+17, 492, Gx_line+32, 0, 0, 0, 1) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A655OperacionesSolicitudesComProv, "ZZZZZZZZZZZZZZ9.99")), 617, Gx_line+17, 700, Gx_line+32, 0, 0, 0, 1) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A650OperacionesSolicitudesId), "ZZZZZZZZZZZZZZZZZ9")), 17, Gx_line+17, 75, Gx_line+32, 0, 0, 0, 1) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A668OperacionesSolicitudesOrigenPa, "")), 708, Gx_line+17, 833, Gx_line+32, 0, 0, 0, 1) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A661OperacionesSolicitudesProvNomb, "")), 92, Gx_line+17, 292, Gx_line+32, 0, 0, 0, 1) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A654OperacionesSolicitudesPFinal, "ZZZZZZZZZZZZZZ9.99")), 300, Gx_line+17, 383, Gx_line+32, 0, 0, 0, 1) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+45);
                  }
                  else
                  {
                     HNG0( false, 44) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A661OperacionesSolicitudesProvNomb, "")), 92, Gx_line+17, 292, Gx_line+32, 0, 0, 0, 1) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A668OperacionesSolicitudesOrigenPa, "")), 708, Gx_line+17, 833, Gx_line+32, 0, 0, 0, 1) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A650OperacionesSolicitudesId), "ZZZZZZZZZZZZZZZZZ9")), 17, Gx_line+17, 75, Gx_line+32, 0, 0, 0, 1) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A653OperacionesSolicitudesComPro, "ZZZZZZZZZZZZZZ9.99")), 400, Gx_line+17, 492, Gx_line+32, 0, 0, 0, 1) ;
                     getPrinter().GxDrawText("-", 308, Gx_line+17, 341, Gx_line+31, 1, 0, 0, 1) ;
                     getPrinter().GxDrawText("-", 517, Gx_line+17, 550, Gx_line+31, 1, 0, 0, 1) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+44);
                  }
                  pr_default.readNext(2);
               }
               pr_default.close(2);
               AV9HayBalances = false;
               /* Using cursor P00NG5 */
               pr_default.execute(3, new Object[] {AV13OperacionesId});
               while ( (pr_default.getStatus(3) != 101) )
               {
                  A1012WalletBalanceLiquidacion = P00NG5_A1012WalletBalanceLiquidacion[0];
                  n1012WalletBalanceLiquidacion = P00NG5_n1012WalletBalanceLiquidacion[0];
                  A1010WalletBalancesConcepto = P00NG5_A1010WalletBalancesConcepto[0];
                  n1010WalletBalancesConcepto = P00NG5_n1010WalletBalancesConcepto[0];
                  A643WalletBalancesTipoMov = P00NG5_A643WalletBalancesTipoMov[0];
                  A644WalletBalancesImporte = P00NG5_A644WalletBalancesImporte[0];
                  A641WalletBalancesFechaAlta = P00NG5_A641WalletBalancesFechaAlta[0];
                  A637WalletId = P00NG5_A637WalletId[0];
                  A640WalletBalancesId = P00NG5_A640WalletBalancesId[0];
                  if ( StringUtil.StrCmp(A643WalletBalancesTipoMov, "CRE") == 0 )
                  {
                     AV19TotalAjustesBal = (decimal)(AV19TotalAjustesBal+A644WalletBalancesImporte);
                  }
                  else
                  {
                     AV19TotalAjustesBal = (decimal)(AV19TotalAjustesBal-A644WalletBalancesImporte);
                  }
                  if ( ! AV9HayBalances )
                  {
                     HNG0( false, 76) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.GetMessage( "BALANCES", ""), 17, Gx_line+17, 104, Gx_line+31, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Importe", ""), 550, Gx_line+50, 700, Gx_line+64, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Concepto", ""), 125, Gx_line+50, 175, Gx_line+64, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Fecha", ""), 17, Gx_line+50, 109, Gx_line+64, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Tipo ( D / C )", ""), 367, Gx_line+50, 517, Gx_line+64, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.GetMessage( "Descripción", ""), 217, Gx_line+50, 300, Gx_line+64, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+76);
                     AV9HayBalances = true;
                  }
                  AV26DscConcepto = context.GetMessage( gxdomainenumconceptobalances.getDescription(context,A1010WalletBalancesConcepto), "");
                  HNG0( false, 45) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A641WalletBalancesFechaAlta, "99/99/99 99:99"), 17, Gx_line+17, 97, Gx_line+32, 0+256, 0, 0, 1) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A1010WalletBalancesConcepto), "ZZZ9")), 125, Gx_line+17, 175, Gx_line+32, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A643WalletBalancesTipoMov, "")), 367, Gx_line+17, 509, Gx_line+32, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A644WalletBalancesImporte, "ZZZZZZZZZZZZZZ9.99")), 550, Gx_line+17, 700, Gx_line+32, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26DscConcepto, "")), 217, Gx_line+17, 334, Gx_line+32, 0, 0, 0, 1) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+45);
                  pr_default.readNext(3);
               }
               pr_default.close(3);
               if ( ( AV14OperacionesImporte >= Convert.ToDecimal( 0 )) )
               {
                  AV27VasACobrar = AV14OperacionesImporte;
                  AV28TenesQuePagar = 0;
               }
               else
               {
                  AV27VasACobrar = 0;
                  AV28TenesQuePagar = (decimal)(AV14OperacionesImporte*-1);
               }
               HNG0( false, 177) ;
               getPrinter().GxDrawLine(27, Gx_line+175, 377, Gx_line+175, 1, 220, 220, 220, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV27VasACobrar, "ZZZZZZZZZZZZZZ9.99")), 161, Gx_line+98, 275, Gx_line+113, 0+256, 0, 0, 1) ;
               getPrinter().GxDrawText(context.GetMessage( "Vas a Cobrar:", ""), 25, Gx_line+100, 132, Gx_line+113, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "SALDO DE LA CUENTA:", ""), 25, Gx_line+150, 151, Gx_line+163, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV25WalletSaldo, "ZZZZZZZZZZZZZZ9.99")), 161, Gx_line+149, 275, Gx_line+164, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(context.GetMessage( "Ganancia por servicios:", ""), 25, Gx_line+17, 132, Gx_line+30, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(context.GetMessage( "Total cobros Directos:", ""), 25, Gx_line+33, 132, Gx_line+46, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(context.GetMessage( "Total Ajustes:", ""), 25, Gx_line+67, 132, Gx_line+80, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV22TotalComProf, "ZZZ,ZZZ,ZZ9.99")), 150, Gx_line+17, 264, Gx_line+32, 0+256, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV19TotalAjustesBal, "ZZZ,ZZZ,ZZ9.99")), 150, Gx_line+67, 264, Gx_line+82, 0+256, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV20TotalCobrosDirect, "ZZZ,ZZZ,ZZ9.99")), 150, Gx_line+33, 264, Gx_line+48, 0+256, 0, 0, 1) ;
               getPrinter().GxDrawLine(25, Gx_line+0, 833, Gx_line+0, 1, 220, 220, 220, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Tenés que pagar:", ""), 25, Gx_line+117, 132, Gx_line+130, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV28TenesQuePagar, "ZZZZZZZZZZZZZZ9.99")), 158, Gx_line+117, 272, Gx_line+132, 0+256, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+177);
               HNG0( false, 178) ;
               getPrinter().GxDrawLine(28, Gx_line+12, 421, Gx_line+12, 1, 105, 105, 105, 0) ;
               getPrinter().GxDrawLine(25, Gx_line+133, 418, Gx_line+133, 1, 105, 105, 105, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 105, 105, 105, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Dirección: Paraguay 1470 Montevideo, Uruguay  ", ""), 28, Gx_line+18, 421, Gx_line+29, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Teléfono: +598 92612655   ", ""), 28, Gx_line+29, 421, Gx_line+40, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Email: info@almango.com.uy   ", ""), 28, Gx_line+40, 421, Gx_line+51, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "Website: www.almango.com.uy", ""), 28, Gx_line+51, 421, Gx_line+62, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawBitMap(context.GetImagePath( "22922f7f-f2d4-4fde-abb1-d4ceefcb60c5", "", context.GetTheme( )), 33, Gx_line+83, 165, Gx_line+113) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+178);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HNG0( true, 0) ;
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

      protected void HNG0( bool bFoot ,
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
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
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
         AV11NombreArchivo = "";
         P00NG2_A555OperacionesRef = new string[] {""} ;
         P00NG2_n555OperacionesRef = new bool[] {false} ;
         P00NG2_A554OperacionesId = new long[1] ;
         P00NG2_A659OperacionesFechaHasta = new DateTime[] {DateTime.MinValue} ;
         P00NG2_n659OperacionesFechaHasta = new bool[] {false} ;
         P00NG2_A658OperacionesFechaDesde = new DateTime[] {DateTime.MinValue} ;
         P00NG2_n658OperacionesFechaDesde = new bool[] {false} ;
         P00NG2_A581OperacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00NG2_n581OperacionesFechaAlta = new bool[] {false} ;
         P00NG2_A657OperacionesNombreRef = new string[] {""} ;
         P00NG2_n657OperacionesNombreRef = new bool[] {false} ;
         P00NG2_A570OperacionesImporte = new decimal[1] ;
         P00NG2_n570OperacionesImporte = new bool[] {false} ;
         A555OperacionesRef = "";
         A659OperacionesFechaHasta = DateTime.MinValue;
         A658OperacionesFechaDesde = DateTime.MinValue;
         A581OperacionesFechaAlta = DateTime.MinValue;
         A657OperacionesNombreRef = "";
         AV16PeriodoStr = "";
         AV15OperacionesNombreRef = "";
         P00NG3_A639WalletCodRefencia = new string[] {""} ;
         P00NG3_A638WalletTipoEntidad = new string[] {""} ;
         P00NG3_A637WalletId = new long[1] ;
         A639WalletCodRefencia = "";
         A638WalletTipoEntidad = "";
         A715WalletNombre = "";
         GXt_char2 = "";
         AV8WalletNombre = "";
         AV17ProfesionalId = "";
         AV18Titulo = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         P00NG4_A554OperacionesId = new long[1] ;
         P00NG4_A654OperacionesSolicitudesPFinal = new decimal[1] ;
         P00NG4_n654OperacionesSolicitudesPFinal = new bool[] {false} ;
         P00NG4_A655OperacionesSolicitudesComProv = new decimal[1] ;
         P00NG4_n655OperacionesSolicitudesComProv = new bool[] {false} ;
         P00NG4_A653OperacionesSolicitudesComPro = new decimal[1] ;
         P00NG4_n653OperacionesSolicitudesComPro = new bool[] {false} ;
         P00NG4_A656OperacionesSolicitudesComALM = new decimal[1] ;
         P00NG4_n656OperacionesSolicitudesComALM = new bool[] {false} ;
         P00NG4_A1027OperacionesSolicitudesXZComAlm = new decimal[1] ;
         P00NG4_n1027OperacionesSolicitudesXZComAlm = new bool[] {false} ;
         P00NG4_A668OperacionesSolicitudesOrigenPa = new string[] {""} ;
         P00NG4_n668OperacionesSolicitudesOrigenPa = new bool[] {false} ;
         P00NG4_A661OperacionesSolicitudesProvNomb = new string[] {""} ;
         P00NG4_n661OperacionesSolicitudesProvNomb = new bool[] {false} ;
         P00NG4_A650OperacionesSolicitudesId = new long[1] ;
         A668OperacionesSolicitudesOrigenPa = "";
         A661OperacionesSolicitudesProvNomb = "";
         P00NG5_A1012WalletBalanceLiquidacion = new long[1] ;
         P00NG5_n1012WalletBalanceLiquidacion = new bool[] {false} ;
         P00NG5_A1010WalletBalancesConcepto = new short[1] ;
         P00NG5_n1010WalletBalancesConcepto = new bool[] {false} ;
         P00NG5_A643WalletBalancesTipoMov = new string[] {""} ;
         P00NG5_A644WalletBalancesImporte = new decimal[1] ;
         P00NG5_A641WalletBalancesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00NG5_A637WalletId = new long[1] ;
         P00NG5_A640WalletBalancesId = new long[1] ;
         A643WalletBalancesTipoMov = "";
         A641WalletBalancesFechaAlta = (DateTime)(DateTime.MinValue);
         AV26DscConcepto = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.areciboliquidacion__default(),
            new Object[][] {
                new Object[] {
               P00NG2_A555OperacionesRef, P00NG2_n555OperacionesRef, P00NG2_A554OperacionesId, P00NG2_A659OperacionesFechaHasta, P00NG2_n659OperacionesFechaHasta, P00NG2_A658OperacionesFechaDesde, P00NG2_n658OperacionesFechaDesde, P00NG2_A581OperacionesFechaAlta, P00NG2_n581OperacionesFechaAlta, P00NG2_A657OperacionesNombreRef,
               P00NG2_n657OperacionesNombreRef, P00NG2_A570OperacionesImporte, P00NG2_n570OperacionesImporte
               }
               , new Object[] {
               P00NG3_A639WalletCodRefencia, P00NG3_A638WalletTipoEntidad, P00NG3_A637WalletId
               }
               , new Object[] {
               P00NG4_A554OperacionesId, P00NG4_A654OperacionesSolicitudesPFinal, P00NG4_n654OperacionesSolicitudesPFinal, P00NG4_A655OperacionesSolicitudesComProv, P00NG4_n655OperacionesSolicitudesComProv, P00NG4_A653OperacionesSolicitudesComPro, P00NG4_n653OperacionesSolicitudesComPro, P00NG4_A656OperacionesSolicitudesComALM, P00NG4_n656OperacionesSolicitudesComALM, P00NG4_A1027OperacionesSolicitudesXZComAlm,
               P00NG4_n1027OperacionesSolicitudesXZComAlm, P00NG4_A668OperacionesSolicitudesOrigenPa, P00NG4_n668OperacionesSolicitudesOrigenPa, P00NG4_A661OperacionesSolicitudesProvNomb, P00NG4_n661OperacionesSolicitudesProvNomb, P00NG4_A650OperacionesSolicitudesId
               }
               , new Object[] {
               P00NG5_A1012WalletBalanceLiquidacion, P00NG5_n1012WalletBalanceLiquidacion, P00NG5_A1010WalletBalancesConcepto, P00NG5_n1010WalletBalancesConcepto, P00NG5_A643WalletBalancesTipoMov, P00NG5_A644WalletBalancesImporte, P00NG5_A641WalletBalancesFechaAlta, P00NG5_A637WalletId, P00NG5_A640WalletBalancesId
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
      private short A1010WalletBalancesConcepto ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private long AV13OperacionesId ;
      private long A554OperacionesId ;
      private long A637WalletId ;
      private long A650OperacionesSolicitudesId ;
      private long A1012WalletBalanceLiquidacion ;
      private long A640WalletBalancesId ;
      private decimal AV24TotalServicios ;
      private decimal AV23TotalComProv ;
      private decimal AV22TotalComProf ;
      private decimal AV21TotalComAlmango ;
      private decimal AV20TotalCobrosDirect ;
      private decimal AV19TotalAjustesBal ;
      private decimal A570OperacionesImporte ;
      private decimal AV14OperacionesImporte ;
      private decimal A646WalletTotalDebito ;
      private decimal A647WalletTotalCredito ;
      private decimal GXt_decimal1 ;
      private decimal A648WalletSaldo ;
      private decimal AV25WalletSaldo ;
      private decimal A654OperacionesSolicitudesPFinal ;
      private decimal A655OperacionesSolicitudesComProv ;
      private decimal A653OperacionesSolicitudesComPro ;
      private decimal A656OperacionesSolicitudesComALM ;
      private decimal A1027OperacionesSolicitudesXZComAlm ;
      private decimal A644WalletBalancesImporte ;
      private decimal AV27VasACobrar ;
      private decimal AV28TenesQuePagar ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string A555OperacionesRef ;
      private string A657OperacionesNombreRef ;
      private string AV15OperacionesNombreRef ;
      private string A639WalletCodRefencia ;
      private string A638WalletTipoEntidad ;
      private string A715WalletNombre ;
      private string GXt_char2 ;
      private string AV8WalletNombre ;
      private string AV17ProfesionalId ;
      private string Gx_time ;
      private string A668OperacionesSolicitudesOrigenPa ;
      private string A661OperacionesSolicitudesProvNomb ;
      private string A643WalletBalancesTipoMov ;
      private DateTime A641WalletBalancesFechaAlta ;
      private DateTime A659OperacionesFechaHasta ;
      private DateTime A658OperacionesFechaDesde ;
      private DateTime A581OperacionesFechaAlta ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool n555OperacionesRef ;
      private bool n659OperacionesFechaHasta ;
      private bool n658OperacionesFechaDesde ;
      private bool n581OperacionesFechaAlta ;
      private bool n657OperacionesNombreRef ;
      private bool n570OperacionesImporte ;
      private bool AV10HaySolicitudes ;
      private bool n654OperacionesSolicitudesPFinal ;
      private bool n655OperacionesSolicitudesComProv ;
      private bool n653OperacionesSolicitudesComPro ;
      private bool n656OperacionesSolicitudesComALM ;
      private bool n1027OperacionesSolicitudesXZComAlm ;
      private bool n668OperacionesSolicitudesOrigenPa ;
      private bool n661OperacionesSolicitudesProvNomb ;
      private bool AV9HayBalances ;
      private bool n1012WalletBalanceLiquidacion ;
      private bool n1010WalletBalancesConcepto ;
      private string AV11NombreArchivo ;
      private string AV16PeriodoStr ;
      private string AV18Titulo ;
      private string AV26DscConcepto ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00NG2_A555OperacionesRef ;
      private bool[] P00NG2_n555OperacionesRef ;
      private long[] P00NG2_A554OperacionesId ;
      private DateTime[] P00NG2_A659OperacionesFechaHasta ;
      private bool[] P00NG2_n659OperacionesFechaHasta ;
      private DateTime[] P00NG2_A658OperacionesFechaDesde ;
      private bool[] P00NG2_n658OperacionesFechaDesde ;
      private DateTime[] P00NG2_A581OperacionesFechaAlta ;
      private bool[] P00NG2_n581OperacionesFechaAlta ;
      private string[] P00NG2_A657OperacionesNombreRef ;
      private bool[] P00NG2_n657OperacionesNombreRef ;
      private decimal[] P00NG2_A570OperacionesImporte ;
      private bool[] P00NG2_n570OperacionesImporte ;
      private string[] P00NG3_A639WalletCodRefencia ;
      private string[] P00NG3_A638WalletTipoEntidad ;
      private long[] P00NG3_A637WalletId ;
      private long[] P00NG4_A554OperacionesId ;
      private decimal[] P00NG4_A654OperacionesSolicitudesPFinal ;
      private bool[] P00NG4_n654OperacionesSolicitudesPFinal ;
      private decimal[] P00NG4_A655OperacionesSolicitudesComProv ;
      private bool[] P00NG4_n655OperacionesSolicitudesComProv ;
      private decimal[] P00NG4_A653OperacionesSolicitudesComPro ;
      private bool[] P00NG4_n653OperacionesSolicitudesComPro ;
      private decimal[] P00NG4_A656OperacionesSolicitudesComALM ;
      private bool[] P00NG4_n656OperacionesSolicitudesComALM ;
      private decimal[] P00NG4_A1027OperacionesSolicitudesXZComAlm ;
      private bool[] P00NG4_n1027OperacionesSolicitudesXZComAlm ;
      private string[] P00NG4_A668OperacionesSolicitudesOrigenPa ;
      private bool[] P00NG4_n668OperacionesSolicitudesOrigenPa ;
      private string[] P00NG4_A661OperacionesSolicitudesProvNomb ;
      private bool[] P00NG4_n661OperacionesSolicitudesProvNomb ;
      private long[] P00NG4_A650OperacionesSolicitudesId ;
      private long[] P00NG5_A1012WalletBalanceLiquidacion ;
      private bool[] P00NG5_n1012WalletBalanceLiquidacion ;
      private short[] P00NG5_A1010WalletBalancesConcepto ;
      private bool[] P00NG5_n1010WalletBalancesConcepto ;
      private string[] P00NG5_A643WalletBalancesTipoMov ;
      private decimal[] P00NG5_A644WalletBalancesImporte ;
      private DateTime[] P00NG5_A641WalletBalancesFechaAlta ;
      private long[] P00NG5_A637WalletId ;
      private long[] P00NG5_A640WalletBalancesId ;
   }

   public class areciboliquidacion__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00NG2;
          prmP00NG2 = new Object[] {
          new ParDef("@AV13OperacionesId",GXType.Decimal,18,0)
          };
          Object[] prmP00NG3;
          prmP00NG3 = new Object[] {
          new ParDef("@OperacionesRef",GXType.NChar,25,0){Nullable=true}
          };
          Object[] prmP00NG4;
          prmP00NG4 = new Object[] {
          new ParDef("@AV13OperacionesId",GXType.Decimal,18,0)
          };
          Object[] prmP00NG5;
          prmP00NG5 = new Object[] {
          new ParDef("@AV13OperacionesId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00NG2", "SELECT [OperacionesRef], [OperacionesId], [OperacionesFechaHasta], [OperacionesFechaDesde], [OperacionesFechaAlta], [OperacionesNombreRef], [OperacionesImporte] FROM [Operaciones] WHERE [OperacionesId] = @AV13OperacionesId ORDER BY [OperacionesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00NG2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00NG3", "SELECT [WalletCodRefencia], [WalletTipoEntidad], [WalletId] FROM [Wallet] WHERE (RTRIM(LTRIM([WalletCodRefencia])) = RTRIM(LTRIM(@OperacionesRef))) AND ([WalletTipoEntidad] = 'PRO') ORDER BY [WalletId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00NG3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00NG4", "SELECT [OperacionesId], [OperacionesSolicitudesPFinal], [OperacionesSolicitudesComProv], [OperacionesSolicitudesComPro], [OperacionesSolicitudesComALM], [OperacionesSolicitudesXZComAlm], [OperacionesSolicitudesOrigenPa], [OperacionesSolicitudesProvNomb], [OperacionesSolicitudesId] FROM [OperacionesSolicitudes] WHERE [OperacionesId] = @AV13OperacionesId ORDER BY [OperacionesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00NG4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00NG5", "SELECT [WalletBalanceLiquidacion], [WalletBalancesConcepto], [WalletBalancesTipoMov], [WalletBalancesImporte], [WalletBalancesFechaAlta], [WalletId], [WalletBalancesId] FROM [WalletBalances] WHERE ([WalletBalancesConcepto] <> 5) AND ([WalletBalanceLiquidacion] = @AV13OperacionesId) ORDER BY [WalletId], [WalletBalancesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00NG5,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 25);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getString(6, 120);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 25);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getString(7, 1);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getString(8, 120);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((long[]) buf[15])[0] = rslt.getLong(9);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(5);
                ((long[]) buf[7])[0] = rslt.getLong(6);
                ((long[]) buf[8])[0] = rslt.getLong(7);
                return;
       }
    }

 }

}
