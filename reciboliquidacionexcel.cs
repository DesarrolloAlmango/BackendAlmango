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
using GeneXus.Office;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class reciboliquidacionexcel : GXProcedure
   {
      public reciboliquidacionexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reciboliquidacionexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_OperacionesId ,
                           out string aP1_Filename )
      {
         this.AV12OperacionesId = aP0_OperacionesId;
         this.AV11Filename = "" ;
         initialize();
         ExecutePrivate();
         aP1_Filename=this.AV11Filename;
      }

      public string executeUdp( long aP0_OperacionesId )
      {
         execute(aP0_OperacionesId, out aP1_Filename);
         return AV11Filename ;
      }

      public void executeSubmit( long aP0_OperacionesId ,
                                 out string aP1_Filename )
      {
         this.AV12OperacionesId = aP0_OperacionesId;
         this.AV11Filename = "" ;
         SubmitImpl();
         aP1_Filename=this.AV11Filename;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11Filename = "Liquidacion_" + StringUtil.Trim( StringUtil.Str( (decimal)(AV12OperacionesId), 18, 0)) + ".xlsx";
         AV10ExcelDocument.Open(AV11Filename);
         AV10ExcelDocument.Clear();
         AV22TotalServicios = 0;
         AV21TotalComProv = 0;
         AV20TotalComProf = 0;
         AV19TotalComAlmango = 0;
         AV18TotalCobrosDirect = 0;
         AV17TotalAjustesBal = 0;
         /* Using cursor P00NH2 */
         pr_default.execute(0, new Object[] {AV12OperacionesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A555OperacionesRef = P00NH2_A555OperacionesRef[0];
            n555OperacionesRef = P00NH2_n555OperacionesRef[0];
            A554OperacionesId = P00NH2_A554OperacionesId[0];
            A659OperacionesFechaHasta = P00NH2_A659OperacionesFechaHasta[0];
            n659OperacionesFechaHasta = P00NH2_n659OperacionesFechaHasta[0];
            A658OperacionesFechaDesde = P00NH2_A658OperacionesFechaDesde[0];
            n658OperacionesFechaDesde = P00NH2_n658OperacionesFechaDesde[0];
            A581OperacionesFechaAlta = P00NH2_A581OperacionesFechaAlta[0];
            n581OperacionesFechaAlta = P00NH2_n581OperacionesFechaAlta[0];
            A570OperacionesImporte = P00NH2_A570OperacionesImporte[0];
            n570OperacionesImporte = P00NH2_n570OperacionesImporte[0];
            if ( ! (DateTime.MinValue==A658OperacionesFechaDesde) && ! (DateTime.MinValue==A659OperacionesFechaHasta) )
            {
               AV13PeriodoStr = context.localUtil.DToC( A658OperacionesFechaDesde, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/") + " | " + context.localUtil.DToC( A659OperacionesFechaHasta, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/");
            }
            else
            {
               AV13PeriodoStr = context.localUtil.Format( A581OperacionesFechaAlta, "99/99/99");
            }
            /* Using cursor P00NH3 */
            pr_default.execute(1, new Object[] {n555OperacionesRef, A555OperacionesRef});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A639WalletCodRefencia = P00NH3_A639WalletCodRefencia[0];
               A638WalletTipoEntidad = P00NH3_A638WalletTipoEntidad[0];
               A637WalletId = P00NH3_A637WalletId[0];
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
               AV24WalletSaldo = A648WalletSaldo;
               AV23WalletNombre = A715WalletNombre;
               AV14ProfesionalId = A639WalletCodRefencia;
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV16Titulo = "LIQUIDACION " + StringUtil.Trim( AV23WalletNombre) + " - " + StringUtil.Trim( AV14ProfesionalId) + " - Período: " + AV13PeriodoStr;
            AV10ExcelDocument.get_Cells(1, 1, 1, 1).Text = AV16Titulo;
            AV10ExcelDocument.get_Cells(1, 1, 1, 1).Bold = 1;
            AV10ExcelDocument.get_Cells(1, 1, 1, 1).Size = 14;
            AV10ExcelDocument.get_Cells(3, 1, 1, 1).Text = "Fecha Emisión:";
            AV10ExcelDocument.get_Cells(3, 1, 1, 1).Bold = 1;
            AV25Datenow = DateTimeUtil.ServerNow( context, pr_default);
            AV10ExcelDocument.get_Cells(3, 2, 1, 1).Text = context.localUtil.TToC( AV25Datenow, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ");
            AV15Row = 5;
            AV10ExcelDocument.get_Cells(AV15Row, 1, 1, 1).Text = "SOLICITUDES";
            AV10ExcelDocument.get_Cells(AV15Row, 1, 1, 1).Bold = 1;
            AV10ExcelDocument.get_Cells(AV15Row, 1, 1, 1).Size = 11;
            AV15Row = (int)(AV15Row+1);
            AV10ExcelDocument.get_Cells(AV15Row, 1, 1, 1).Text = "ID";
            AV10ExcelDocument.get_Cells(AV15Row, 2, 1, 1).Text = "Cliente / Detalle";
            AV10ExcelDocument.get_Cells(AV15Row, 3, 1, 1).Text = "Precio Final";
            AV10ExcelDocument.get_Cells(AV15Row, 4, 1, 1).Text = "Com. Prof";
            AV10ExcelDocument.get_Cells(AV15Row, 5, 1, 1).Text = "Com. Almango";
            AV10ExcelDocument.get_Cells(AV15Row, 6, 1, 1).Text = "Com. Prov";
            AV10ExcelDocument.get_Cells(AV15Row, 7, 1, 1).Text = "Origen Pago";
            AV8Col = 1;
            while ( AV8Col <= 7 )
            {
               AV10ExcelDocument.get_Cells(AV15Row, AV8Col, 1, 1).Bold = 1;
               AV8Col = (int)(AV8Col+1);
            }
            /* Using cursor P00NH4 */
            pr_default.execute(2, new Object[] {AV12OperacionesId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A554OperacionesId = P00NH4_A554OperacionesId[0];
               A654OperacionesSolicitudesPFinal = P00NH4_A654OperacionesSolicitudesPFinal[0];
               n654OperacionesSolicitudesPFinal = P00NH4_n654OperacionesSolicitudesPFinal[0];
               A655OperacionesSolicitudesComProv = P00NH4_A655OperacionesSolicitudesComProv[0];
               n655OperacionesSolicitudesComProv = P00NH4_n655OperacionesSolicitudesComProv[0];
               A653OperacionesSolicitudesComPro = P00NH4_A653OperacionesSolicitudesComPro[0];
               n653OperacionesSolicitudesComPro = P00NH4_n653OperacionesSolicitudesComPro[0];
               A1027OperacionesSolicitudesXZComAlm = P00NH4_A1027OperacionesSolicitudesXZComAlm[0];
               n1027OperacionesSolicitudesXZComAlm = P00NH4_n1027OperacionesSolicitudesXZComAlm[0];
               A656OperacionesSolicitudesComALM = P00NH4_A656OperacionesSolicitudesComALM[0];
               n656OperacionesSolicitudesComALM = P00NH4_n656OperacionesSolicitudesComALM[0];
               A668OperacionesSolicitudesOrigenPa = P00NH4_A668OperacionesSolicitudesOrigenPa[0];
               n668OperacionesSolicitudesOrigenPa = P00NH4_n668OperacionesSolicitudesOrigenPa[0];
               A650OperacionesSolicitudesId = P00NH4_A650OperacionesSolicitudesId[0];
               A661OperacionesSolicitudesProvNomb = P00NH4_A661OperacionesSolicitudesProvNomb[0];
               n661OperacionesSolicitudesProvNomb = P00NH4_n661OperacionesSolicitudesProvNomb[0];
               AV22TotalServicios = (decimal)(AV22TotalServicios+A654OperacionesSolicitudesPFinal);
               AV21TotalComProv = (decimal)(AV21TotalComProv+A655OperacionesSolicitudesComProv);
               AV20TotalComProf = (decimal)(AV20TotalComProf+A653OperacionesSolicitudesComPro);
               AV19TotalComAlmango = (decimal)(AV19TotalComAlmango+((A656OperacionesSolicitudesComALM+A1027OperacionesSolicitudesXZComAlm)));
               if ( StringUtil.StrCmp(A668OperacionesSolicitudesOrigenPa, "F") == 0 )
               {
                  AV18TotalCobrosDirect = (decimal)(AV18TotalCobrosDirect+A654OperacionesSolicitudesPFinal);
               }
               AV15Row = (int)(AV15Row+1);
               AV10ExcelDocument.get_Cells(AV15Row, 1, 1, 1).Number = A650OperacionesSolicitudesId;
               AV10ExcelDocument.get_Cells(AV15Row, 2, 1, 1).Text = StringUtil.Trim( A661OperacionesSolicitudesProvNomb);
               AV10ExcelDocument.get_Cells(AV15Row, 3, 1, 1).Number = (double)(A654OperacionesSolicitudesPFinal);
               AV10ExcelDocument.get_Cells(AV15Row, 4, 1, 1).Number = (double)(A653OperacionesSolicitudesComPro);
               AV10ExcelDocument.get_Cells(AV15Row, 5, 1, 1).Number = (double)((A656OperacionesSolicitudesComALM+A1027OperacionesSolicitudesXZComAlm));
               AV10ExcelDocument.get_Cells(AV15Row, 6, 1, 1).Number = (double)(A655OperacionesSolicitudesComProv);
               AV10ExcelDocument.get_Cells(AV15Row, 7, 1, 1).Text = context.GetMessage( gxdomainorigenpago.getDescription(context,A668OperacionesSolicitudesOrigenPa), "");
               pr_default.readNext(2);
            }
            pr_default.close(2);
            AV15Row = (int)(AV15Row+1);
            AV10ExcelDocument.get_Cells(AV15Row, 2, 1, 1).Text = "Subtotal Solicitudes:";
            AV10ExcelDocument.get_Cells(AV15Row, 2, 1, 1).Bold = 1;
            AV10ExcelDocument.get_Cells(AV15Row, 3, 1, 1).Number = (double)(AV22TotalServicios);
            AV10ExcelDocument.get_Cells(AV15Row, 3, 1, 1).Bold = 1;
            AV10ExcelDocument.get_Cells(AV15Row, 4, 1, 1).Number = (double)(AV20TotalComProf);
            AV10ExcelDocument.get_Cells(AV15Row, 4, 1, 1).Bold = 1;
            AV10ExcelDocument.get_Cells(AV15Row, 5, 1, 1).Number = (double)(AV19TotalComAlmango);
            AV10ExcelDocument.get_Cells(AV15Row, 5, 1, 1).Bold = 1;
            AV10ExcelDocument.get_Cells(AV15Row, 6, 1, 1).Number = (double)(AV21TotalComProv);
            AV10ExcelDocument.get_Cells(AV15Row, 6, 1, 1).Bold = 1;
            AV15Row = (int)(AV15Row+2);
            AV10ExcelDocument.get_Cells(AV15Row, 1, 1, 1).Text = "BALANCES Y AJUSTES";
            AV10ExcelDocument.get_Cells(AV15Row, 1, 1, 1).Bold = 1;
            AV10ExcelDocument.get_Cells(AV15Row, 1, 1, 1).Size = 11;
            AV15Row = (int)(AV15Row+1);
            AV10ExcelDocument.get_Cells(AV15Row, 1, 1, 1).Text = "Fecha";
            AV10ExcelDocument.get_Cells(AV15Row, 2, 1, 1).Text = "Concepto";
            AV10ExcelDocument.get_Cells(AV15Row, 3, 1, 1).Text = "Descripción";
            AV10ExcelDocument.get_Cells(AV15Row, 4, 1, 1).Text = "Tipo (D/C)";
            AV10ExcelDocument.get_Cells(AV15Row, 5, 1, 1).Text = "Importe";
            AV8Col = 1;
            while ( AV8Col <= 5 )
            {
               AV10ExcelDocument.get_Cells(AV15Row, AV8Col, 1, 1).Bold = 1;
               AV8Col = (int)(AV8Col+1);
            }
            /* Using cursor P00NH5 */
            pr_default.execute(3, new Object[] {AV12OperacionesId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A1012WalletBalanceLiquidacion = P00NH5_A1012WalletBalanceLiquidacion[0];
               n1012WalletBalanceLiquidacion = P00NH5_n1012WalletBalanceLiquidacion[0];
               A1010WalletBalancesConcepto = P00NH5_A1010WalletBalancesConcepto[0];
               n1010WalletBalancesConcepto = P00NH5_n1010WalletBalancesConcepto[0];
               A643WalletBalancesTipoMov = P00NH5_A643WalletBalancesTipoMov[0];
               A644WalletBalancesImporte = P00NH5_A644WalletBalancesImporte[0];
               A641WalletBalancesFechaAlta = P00NH5_A641WalletBalancesFechaAlta[0];
               A1009WalletBalancesObs = P00NH5_A1009WalletBalancesObs[0];
               n1009WalletBalancesObs = P00NH5_n1009WalletBalancesObs[0];
               A637WalletId = P00NH5_A637WalletId[0];
               A640WalletBalancesId = P00NH5_A640WalletBalancesId[0];
               if ( StringUtil.StrCmp(A643WalletBalancesTipoMov, "CRE") == 0 )
               {
                  AV17TotalAjustesBal = (decimal)(AV17TotalAjustesBal+A644WalletBalancesImporte);
               }
               else
               {
                  AV17TotalAjustesBal = (decimal)(AV17TotalAjustesBal-A644WalletBalancesImporte);
               }
               AV9DscConcepto = context.GetMessage( gxdomainenumconceptobalances.getDescription(context,A1010WalletBalancesConcepto), "");
               AV15Row = (int)(AV15Row+1);
               AV10ExcelDocument.get_Cells(AV15Row, 1, 1, 1).Text = context.localUtil.TToC( A641WalletBalancesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ");
               AV10ExcelDocument.get_Cells(AV15Row, 2, 1, 1).Text = AV9DscConcepto;
               AV10ExcelDocument.get_Cells(AV15Row, 3, 1, 1).Text = StringUtil.Trim( A1009WalletBalancesObs);
               AV10ExcelDocument.get_Cells(AV15Row, 4, 1, 1).Text = A643WalletBalancesTipoMov;
               AV10ExcelDocument.get_Cells(AV15Row, 5, 1, 1).Number = (double)(A644WalletBalancesImporte);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            AV15Row = (int)(AV15Row+1);
            AV10ExcelDocument.get_Cells(AV15Row, 4, 1, 1).Text = "Total Ajustes:";
            AV10ExcelDocument.get_Cells(AV15Row, 4, 1, 1).Bold = 1;
            AV10ExcelDocument.get_Cells(AV15Row, 5, 1, 1).Number = (double)(AV17TotalAjustesBal);
            AV10ExcelDocument.get_Cells(AV15Row, 5, 1, 1).Bold = 1;
            AV15Row = (int)(AV15Row+2);
            AV10ExcelDocument.get_Cells(AV15Row, 1, 1, 1).Text = "RESUMEN DE LIQUIDACIÓN";
            AV10ExcelDocument.get_Cells(AV15Row, 1, 1, 1).Bold = 1;
            AV10ExcelDocument.get_Cells(AV15Row, 1, 1, 1).Size = 11;
            AV15Row = (int)(AV15Row+1);
            AV10ExcelDocument.get_Cells(AV15Row, 1, 1, 1).Text = "Total de Servicios:";
            AV10ExcelDocument.get_Cells(AV15Row, 2, 1, 1).Number = (double)(AV22TotalServicios);
            AV15Row = (int)(AV15Row+1);
            AV10ExcelDocument.get_Cells(AV15Row, 1, 1, 1).Text = "Total Comisión Almango:";
            AV10ExcelDocument.get_Cells(AV15Row, 2, 1, 1).Number = (double)(AV19TotalComAlmango);
            AV15Row = (int)(AV15Row+1);
            AV10ExcelDocument.get_Cells(AV15Row, 1, 1, 1).Text = "Total Cobros Directos:";
            AV10ExcelDocument.get_Cells(AV15Row, 2, 1, 1).Number = (double)(AV18TotalCobrosDirect);
            AV15Row = (int)(AV15Row+1);
            AV10ExcelDocument.get_Cells(AV15Row, 1, 1, 1).Text = "Total Ajustes:";
            AV10ExcelDocument.get_Cells(AV15Row, 2, 1, 1).Number = (double)(AV17TotalAjustesBal);
            AV15Row = (int)(AV15Row+1);
            AV10ExcelDocument.get_Cells(AV15Row, 1, 1, 1).Text = "IMPORTE LIQUIDADO:";
            AV10ExcelDocument.get_Cells(AV15Row, 1, 1, 1).Bold = 1;
            AV10ExcelDocument.get_Cells(AV15Row, 2, 1, 1).Number = (double)(A570OperacionesImporte);
            AV10ExcelDocument.get_Cells(AV15Row, 2, 1, 1).Bold = 1;
            AV15Row = (int)(AV15Row+1);
            AV10ExcelDocument.get_Cells(AV15Row, 1, 1, 1).Text = "SALDO DE LA CUENTA (WALLET):";
            AV10ExcelDocument.get_Cells(AV15Row, 1, 1, 1).Bold = 1;
            AV10ExcelDocument.get_Cells(AV15Row, 2, 1, 1).Number = (double)(AV24WalletSaldo);
            AV10ExcelDocument.get_Cells(AV15Row, 2, 1, 1).Bold = 1;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         AV10ExcelDocument.Save();
         AV10ExcelDocument.Close();
         cleanup();
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
         AV11Filename = "";
         AV10ExcelDocument = new ExcelDocumentI();
         P00NH2_A555OperacionesRef = new string[] {""} ;
         P00NH2_n555OperacionesRef = new bool[] {false} ;
         P00NH2_A554OperacionesId = new long[1] ;
         P00NH2_A659OperacionesFechaHasta = new DateTime[] {DateTime.MinValue} ;
         P00NH2_n659OperacionesFechaHasta = new bool[] {false} ;
         P00NH2_A658OperacionesFechaDesde = new DateTime[] {DateTime.MinValue} ;
         P00NH2_n658OperacionesFechaDesde = new bool[] {false} ;
         P00NH2_A581OperacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00NH2_n581OperacionesFechaAlta = new bool[] {false} ;
         P00NH2_A570OperacionesImporte = new decimal[1] ;
         P00NH2_n570OperacionesImporte = new bool[] {false} ;
         A555OperacionesRef = "";
         A659OperacionesFechaHasta = DateTime.MinValue;
         A658OperacionesFechaDesde = DateTime.MinValue;
         A581OperacionesFechaAlta = DateTime.MinValue;
         AV13PeriodoStr = "";
         P00NH3_A639WalletCodRefencia = new string[] {""} ;
         P00NH3_A638WalletTipoEntidad = new string[] {""} ;
         P00NH3_A637WalletId = new long[1] ;
         A639WalletCodRefencia = "";
         A638WalletTipoEntidad = "";
         A715WalletNombre = "";
         GXt_char2 = "";
         AV23WalletNombre = "";
         AV14ProfesionalId = "";
         AV16Titulo = "";
         AV25Datenow = (DateTime)(DateTime.MinValue);
         P00NH4_A554OperacionesId = new long[1] ;
         P00NH4_A654OperacionesSolicitudesPFinal = new decimal[1] ;
         P00NH4_n654OperacionesSolicitudesPFinal = new bool[] {false} ;
         P00NH4_A655OperacionesSolicitudesComProv = new decimal[1] ;
         P00NH4_n655OperacionesSolicitudesComProv = new bool[] {false} ;
         P00NH4_A653OperacionesSolicitudesComPro = new decimal[1] ;
         P00NH4_n653OperacionesSolicitudesComPro = new bool[] {false} ;
         P00NH4_A1027OperacionesSolicitudesXZComAlm = new decimal[1] ;
         P00NH4_n1027OperacionesSolicitudesXZComAlm = new bool[] {false} ;
         P00NH4_A656OperacionesSolicitudesComALM = new decimal[1] ;
         P00NH4_n656OperacionesSolicitudesComALM = new bool[] {false} ;
         P00NH4_A668OperacionesSolicitudesOrigenPa = new string[] {""} ;
         P00NH4_n668OperacionesSolicitudesOrigenPa = new bool[] {false} ;
         P00NH4_A650OperacionesSolicitudesId = new long[1] ;
         P00NH4_A661OperacionesSolicitudesProvNomb = new string[] {""} ;
         P00NH4_n661OperacionesSolicitudesProvNomb = new bool[] {false} ;
         A668OperacionesSolicitudesOrigenPa = "";
         A661OperacionesSolicitudesProvNomb = "";
         P00NH5_A1012WalletBalanceLiquidacion = new long[1] ;
         P00NH5_n1012WalletBalanceLiquidacion = new bool[] {false} ;
         P00NH5_A1010WalletBalancesConcepto = new short[1] ;
         P00NH5_n1010WalletBalancesConcepto = new bool[] {false} ;
         P00NH5_A643WalletBalancesTipoMov = new string[] {""} ;
         P00NH5_A644WalletBalancesImporte = new decimal[1] ;
         P00NH5_A641WalletBalancesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00NH5_A1009WalletBalancesObs = new string[] {""} ;
         P00NH5_n1009WalletBalancesObs = new bool[] {false} ;
         P00NH5_A637WalletId = new long[1] ;
         P00NH5_A640WalletBalancesId = new long[1] ;
         A643WalletBalancesTipoMov = "";
         A641WalletBalancesFechaAlta = (DateTime)(DateTime.MinValue);
         A1009WalletBalancesObs = "";
         AV9DscConcepto = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reciboliquidacionexcel__default(),
            new Object[][] {
                new Object[] {
               P00NH2_A555OperacionesRef, P00NH2_n555OperacionesRef, P00NH2_A554OperacionesId, P00NH2_A659OperacionesFechaHasta, P00NH2_n659OperacionesFechaHasta, P00NH2_A658OperacionesFechaDesde, P00NH2_n658OperacionesFechaDesde, P00NH2_A581OperacionesFechaAlta, P00NH2_n581OperacionesFechaAlta, P00NH2_A570OperacionesImporte,
               P00NH2_n570OperacionesImporte
               }
               , new Object[] {
               P00NH3_A639WalletCodRefencia, P00NH3_A638WalletTipoEntidad, P00NH3_A637WalletId
               }
               , new Object[] {
               P00NH4_A554OperacionesId, P00NH4_A654OperacionesSolicitudesPFinal, P00NH4_n654OperacionesSolicitudesPFinal, P00NH4_A655OperacionesSolicitudesComProv, P00NH4_n655OperacionesSolicitudesComProv, P00NH4_A653OperacionesSolicitudesComPro, P00NH4_n653OperacionesSolicitudesComPro, P00NH4_A1027OperacionesSolicitudesXZComAlm, P00NH4_n1027OperacionesSolicitudesXZComAlm, P00NH4_A656OperacionesSolicitudesComALM,
               P00NH4_n656OperacionesSolicitudesComALM, P00NH4_A668OperacionesSolicitudesOrigenPa, P00NH4_n668OperacionesSolicitudesOrigenPa, P00NH4_A650OperacionesSolicitudesId, P00NH4_A661OperacionesSolicitudesProvNomb, P00NH4_n661OperacionesSolicitudesProvNomb
               }
               , new Object[] {
               P00NH5_A1012WalletBalanceLiquidacion, P00NH5_n1012WalletBalanceLiquidacion, P00NH5_A1010WalletBalancesConcepto, P00NH5_n1010WalletBalancesConcepto, P00NH5_A643WalletBalancesTipoMov, P00NH5_A644WalletBalancesImporte, P00NH5_A641WalletBalancesFechaAlta, P00NH5_A1009WalletBalancesObs, P00NH5_n1009WalletBalancesObs, P00NH5_A637WalletId,
               P00NH5_A640WalletBalancesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A1010WalletBalancesConcepto ;
      private int AV15Row ;
      private int AV8Col ;
      private long AV12OperacionesId ;
      private long A554OperacionesId ;
      private long A637WalletId ;
      private long A650OperacionesSolicitudesId ;
      private long A1012WalletBalanceLiquidacion ;
      private long A640WalletBalancesId ;
      private decimal AV22TotalServicios ;
      private decimal AV21TotalComProv ;
      private decimal AV20TotalComProf ;
      private decimal AV19TotalComAlmango ;
      private decimal AV18TotalCobrosDirect ;
      private decimal AV17TotalAjustesBal ;
      private decimal A570OperacionesImporte ;
      private decimal A646WalletTotalDebito ;
      private decimal A647WalletTotalCredito ;
      private decimal GXt_decimal1 ;
      private decimal A648WalletSaldo ;
      private decimal AV24WalletSaldo ;
      private decimal A654OperacionesSolicitudesPFinal ;
      private decimal A655OperacionesSolicitudesComProv ;
      private decimal A653OperacionesSolicitudesComPro ;
      private decimal A1027OperacionesSolicitudesXZComAlm ;
      private decimal A656OperacionesSolicitudesComALM ;
      private decimal A644WalletBalancesImporte ;
      private string A555OperacionesRef ;
      private string A639WalletCodRefencia ;
      private string A638WalletTipoEntidad ;
      private string A715WalletNombre ;
      private string GXt_char2 ;
      private string AV23WalletNombre ;
      private string AV14ProfesionalId ;
      private string A668OperacionesSolicitudesOrigenPa ;
      private string A661OperacionesSolicitudesProvNomb ;
      private string A643WalletBalancesTipoMov ;
      private DateTime AV25Datenow ;
      private DateTime A641WalletBalancesFechaAlta ;
      private DateTime A659OperacionesFechaHasta ;
      private DateTime A658OperacionesFechaDesde ;
      private DateTime A581OperacionesFechaAlta ;
      private bool n555OperacionesRef ;
      private bool n659OperacionesFechaHasta ;
      private bool n658OperacionesFechaDesde ;
      private bool n581OperacionesFechaAlta ;
      private bool n570OperacionesImporte ;
      private bool n654OperacionesSolicitudesPFinal ;
      private bool n655OperacionesSolicitudesComProv ;
      private bool n653OperacionesSolicitudesComPro ;
      private bool n1027OperacionesSolicitudesXZComAlm ;
      private bool n656OperacionesSolicitudesComALM ;
      private bool n668OperacionesSolicitudesOrigenPa ;
      private bool n661OperacionesSolicitudesProvNomb ;
      private bool n1012WalletBalanceLiquidacion ;
      private bool n1010WalletBalancesConcepto ;
      private bool n1009WalletBalancesObs ;
      private string AV11Filename ;
      private string AV13PeriodoStr ;
      private string AV16Titulo ;
      private string A1009WalletBalancesObs ;
      private string AV9DscConcepto ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00NH2_A555OperacionesRef ;
      private bool[] P00NH2_n555OperacionesRef ;
      private long[] P00NH2_A554OperacionesId ;
      private DateTime[] P00NH2_A659OperacionesFechaHasta ;
      private bool[] P00NH2_n659OperacionesFechaHasta ;
      private DateTime[] P00NH2_A658OperacionesFechaDesde ;
      private bool[] P00NH2_n658OperacionesFechaDesde ;
      private DateTime[] P00NH2_A581OperacionesFechaAlta ;
      private bool[] P00NH2_n581OperacionesFechaAlta ;
      private decimal[] P00NH2_A570OperacionesImporte ;
      private bool[] P00NH2_n570OperacionesImporte ;
      private string[] P00NH3_A639WalletCodRefencia ;
      private string[] P00NH3_A638WalletTipoEntidad ;
      private long[] P00NH3_A637WalletId ;
      private long[] P00NH4_A554OperacionesId ;
      private decimal[] P00NH4_A654OperacionesSolicitudesPFinal ;
      private bool[] P00NH4_n654OperacionesSolicitudesPFinal ;
      private decimal[] P00NH4_A655OperacionesSolicitudesComProv ;
      private bool[] P00NH4_n655OperacionesSolicitudesComProv ;
      private decimal[] P00NH4_A653OperacionesSolicitudesComPro ;
      private bool[] P00NH4_n653OperacionesSolicitudesComPro ;
      private decimal[] P00NH4_A1027OperacionesSolicitudesXZComAlm ;
      private bool[] P00NH4_n1027OperacionesSolicitudesXZComAlm ;
      private decimal[] P00NH4_A656OperacionesSolicitudesComALM ;
      private bool[] P00NH4_n656OperacionesSolicitudesComALM ;
      private string[] P00NH4_A668OperacionesSolicitudesOrigenPa ;
      private bool[] P00NH4_n668OperacionesSolicitudesOrigenPa ;
      private long[] P00NH4_A650OperacionesSolicitudesId ;
      private string[] P00NH4_A661OperacionesSolicitudesProvNomb ;
      private bool[] P00NH4_n661OperacionesSolicitudesProvNomb ;
      private long[] P00NH5_A1012WalletBalanceLiquidacion ;
      private bool[] P00NH5_n1012WalletBalanceLiquidacion ;
      private short[] P00NH5_A1010WalletBalancesConcepto ;
      private bool[] P00NH5_n1010WalletBalancesConcepto ;
      private string[] P00NH5_A643WalletBalancesTipoMov ;
      private decimal[] P00NH5_A644WalletBalancesImporte ;
      private DateTime[] P00NH5_A641WalletBalancesFechaAlta ;
      private string[] P00NH5_A1009WalletBalancesObs ;
      private bool[] P00NH5_n1009WalletBalancesObs ;
      private long[] P00NH5_A637WalletId ;
      private long[] P00NH5_A640WalletBalancesId ;
      private string aP1_Filename ;
   }

   public class reciboliquidacionexcel__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00NH2;
          prmP00NH2 = new Object[] {
          new ParDef("@AV12OperacionesId",GXType.Decimal,18,0)
          };
          Object[] prmP00NH3;
          prmP00NH3 = new Object[] {
          new ParDef("@OperacionesRef",GXType.NChar,25,0){Nullable=true}
          };
          Object[] prmP00NH4;
          prmP00NH4 = new Object[] {
          new ParDef("@AV12OperacionesId",GXType.Decimal,18,0)
          };
          Object[] prmP00NH5;
          prmP00NH5 = new Object[] {
          new ParDef("@AV12OperacionesId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00NH2", "SELECT [OperacionesRef], [OperacionesId], [OperacionesFechaHasta], [OperacionesFechaDesde], [OperacionesFechaAlta], [OperacionesImporte] FROM [Operaciones] WHERE [OperacionesId] = @AV12OperacionesId ORDER BY [OperacionesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00NH2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00NH3", "SELECT [WalletCodRefencia], [WalletTipoEntidad], [WalletId] FROM [Wallet] WHERE (RTRIM(LTRIM([WalletCodRefencia])) = RTRIM(LTRIM(@OperacionesRef))) AND ([WalletTipoEntidad] = 'PRO') ORDER BY [WalletId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00NH3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00NH4", "SELECT [OperacionesId], [OperacionesSolicitudesPFinal], [OperacionesSolicitudesComProv], [OperacionesSolicitudesComPro], [OperacionesSolicitudesXZComAlm], [OperacionesSolicitudesComALM], [OperacionesSolicitudesOrigenPa], [OperacionesSolicitudesId], [OperacionesSolicitudesProvNomb] FROM [OperacionesSolicitudes] WHERE [OperacionesId] = @AV12OperacionesId ORDER BY [OperacionesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00NH4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00NH5", "SELECT [WalletBalanceLiquidacion], [WalletBalancesConcepto], [WalletBalancesTipoMov], [WalletBalancesImporte], [WalletBalancesFechaAlta], [WalletBalancesObs], [WalletId], [WalletBalancesId] FROM [WalletBalances] WHERE ([WalletBalancesConcepto] <> 5) AND ([WalletBalanceLiquidacion] = @AV12OperacionesId) ORDER BY [WalletId], [WalletBalancesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00NH5,100, GxCacheFrequency.OFF ,false,false )
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
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
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
                ((long[]) buf[13])[0] = rslt.getLong(8);
                ((string[]) buf[14])[0] = rslt.getString(9, 120);
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((long[]) buf[9])[0] = rslt.getLong(7);
                ((long[]) buf[10])[0] = rslt.getLong(8);
                return;
       }
    }

 }

}
