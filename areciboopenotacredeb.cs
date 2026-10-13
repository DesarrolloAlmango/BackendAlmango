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
   public class areciboopenotacredeb : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "areciboopenotacredeb.aspx")), "areciboopenotacredeb.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "areciboopenotacredeb.aspx")))) ;
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
               AV10OperacionesId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV33WalletId = (long)(Math.Round(NumberUtil.Val( GetPar( "WalletId"), "."), 18, MidpointRounding.ToEven));
                  AV16TipoOperacion = GetPar( "TipoOperacion");
                  AV32NombreRef = GetPar( "NombreRef");
               }
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public areciboopenotacredeb( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public areciboopenotacredeb( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_OperacionesId ,
                           long aP1_WalletId ,
                           string aP2_TipoOperacion ,
                           string aP3_NombreRef )
      {
         this.AV10OperacionesId = aP0_OperacionesId;
         this.AV33WalletId = aP1_WalletId;
         this.AV16TipoOperacion = aP2_TipoOperacion;
         this.AV32NombreRef = aP3_NombreRef;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_OperacionesId ,
                                 long aP1_WalletId ,
                                 string aP2_TipoOperacion ,
                                 string aP3_NombreRef )
      {
         this.AV10OperacionesId = aP0_OperacionesId;
         this.AV33WalletId = aP1_WalletId;
         this.AV16TipoOperacion = aP2_TipoOperacion;
         this.AV32NombreRef = aP3_NombreRef;
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
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 6206, 0, 1, 1, 0, 1, 1) )
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
            /* Using cursor P00DI2 */
            pr_default.execute(0, new Object[] {AV33WalletId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A639WalletCodRefencia = P00DI2_A639WalletCodRefencia[0];
               A638WalletTipoEntidad = P00DI2_A638WalletTipoEntidad[0];
               A637WalletId = P00DI2_A637WalletId[0];
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
               AV34WalletSaldo = A648WalletSaldo;
               AV35WalletNombre = A715WalletNombre;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV9Operacion = context.GetMessage( gxdomaintipooperacionenum.getDescription(context,AV16TipoOperacion), "");
            AV31Titulo = StringUtil.Format( context.GetMessage( "Recibo Operación N° %1", ""), StringUtil.Trim( StringUtil.Str( (decimal)(AV10OperacionesId), 18, 0)), "", "", "", "", "", "", "", "");
            AV13OperacionesNombreRef = context.GetMessage( "NOMBRE: ", "") + StringUtil.Trim( AV35WalletNombre);
            HDI0( false, 175) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 317, Gx_line+33, 393, Gx_line+47, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 267, Gx_line+33, 306, Gx_line+47, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Fecha", ""), 267, Gx_line+17, 416, Gx_line+31, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 14, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9Operacion, "")), 76, Gx_line+100, 357, Gx_line+126, 1, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31Titulo, "")), 8, Gx_line+133, 425, Gx_line+155, 1, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 105, 105, 105, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Control de Solicitudes de Servicios a Domicilio", ""), 0, Gx_line+67, 207, Gx_line+81, 0, 0, 0, 0) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "e6acfd2e-013a-4b78-9d37-37f6dc906ba7", "", context.GetTheme( )), 2, Gx_line+-5, 190, Gx_line+58) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+175);
            HDI0( false, 71) ;
            getPrinter().GxDrawLine(27, Gx_line+0, 377, Gx_line+0, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13OperacionesNombreRef, "")), 17, Gx_line+33, 450, Gx_line+48, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "CLIENTE", ""), 17, Gx_line+17, 104, Gx_line+31, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+71);
            /* Using cursor P00DI3 */
            pr_default.execute(1, new Object[] {AV10OperacionesId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A554OperacionesId = P00DI3_A554OperacionesId[0];
               A570OperacionesImporte = P00DI3_A570OperacionesImporte[0];
               n570OperacionesImporte = P00DI3_n570OperacionesImporte[0];
               AV8Importe = A570OperacionesImporte;
               HDI0( false, 72) ;
               getPrinter().GxDrawLine(27, Gx_line+63, 377, Gx_line+63, 1, 220, 220, 220, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV8Importe, "ZZZZZZZZZZZZZZ9.99")), 161, Gx_line+6, 275, Gx_line+21, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "IMPORTE:", ""), 25, Gx_line+8, 132, Gx_line+21, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.GetMessage( "SALDO DE LA CUENTA:", ""), 25, Gx_line+38, 151, Gx_line+51, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV34WalletSaldo, "ZZZZZZZZZZZZZZ9.99")), 161, Gx_line+36, 275, Gx_line+51, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+72);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            HDI0( false, 178) ;
            getPrinter().GxDrawLine(28, Gx_line+12, 421, Gx_line+12, 1, 105, 105, 105, 0) ;
            getPrinter().GxDrawLine(25, Gx_line+133, 418, Gx_line+133, 1, 105, 105, 105, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 105, 105, 105, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Dirección: Eduardo Acevedo 1310 Montevideo, Uruguay  ", ""), 28, Gx_line+18, 421, Gx_line+29, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Teléfono: +598 92612655   ", ""), 28, Gx_line+29, 421, Gx_line+40, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Email: info@almango.com.uy   ", ""), 28, Gx_line+40, 421, Gx_line+51, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(context.GetMessage( "Website: www.almango.com.uy", ""), 28, Gx_line+51, 421, Gx_line+62, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "22922f7f-f2d4-4fde-abb1-d4ceefcb60c5", "", context.GetTheme( )), 33, Gx_line+83, 165, Gx_line+113) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+178);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HDI0( true, 0) ;
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

      protected void HDI0( bool bFoot ,
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
         P00DI2_A639WalletCodRefencia = new string[] {""} ;
         P00DI2_A638WalletTipoEntidad = new string[] {""} ;
         P00DI2_A637WalletId = new long[1] ;
         A639WalletCodRefencia = "";
         A638WalletTipoEntidad = "";
         A715WalletNombre = "";
         GXt_char2 = "";
         AV35WalletNombre = "";
         AV9Operacion = "";
         AV31Titulo = "";
         AV13OperacionesNombreRef = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         P00DI3_A554OperacionesId = new long[1] ;
         P00DI3_A570OperacionesImporte = new decimal[1] ;
         P00DI3_n570OperacionesImporte = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.areciboopenotacredeb__default(),
            new Object[][] {
                new Object[] {
               P00DI2_A639WalletCodRefencia, P00DI2_A638WalletTipoEntidad, P00DI2_A637WalletId
               }
               , new Object[] {
               P00DI3_A554OperacionesId, P00DI3_A570OperacionesImporte, P00DI3_n570OperacionesImporte
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
      private long AV10OperacionesId ;
      private long AV33WalletId ;
      private long A637WalletId ;
      private long A554OperacionesId ;
      private decimal A646WalletTotalDebito ;
      private decimal A647WalletTotalCredito ;
      private decimal GXt_decimal1 ;
      private decimal A648WalletSaldo ;
      private decimal AV34WalletSaldo ;
      private decimal A570OperacionesImporte ;
      private decimal AV8Importe ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV16TipoOperacion ;
      private string AV32NombreRef ;
      private string A639WalletCodRefencia ;
      private string A638WalletTipoEntidad ;
      private string A715WalletNombre ;
      private string GXt_char2 ;
      private string AV35WalletNombre ;
      private string AV31Titulo ;
      private string AV13OperacionesNombreRef ;
      private string Gx_time ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool n570OperacionesImporte ;
      private string AV9Operacion ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00DI2_A639WalletCodRefencia ;
      private string[] P00DI2_A638WalletTipoEntidad ;
      private long[] P00DI2_A637WalletId ;
      private long[] P00DI3_A554OperacionesId ;
      private decimal[] P00DI3_A570OperacionesImporte ;
      private bool[] P00DI3_n570OperacionesImporte ;
   }

   public class areciboopenotacredeb__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00DI2;
          prmP00DI2 = new Object[] {
          new ParDef("@AV33WalletId",GXType.Decimal,18,0)
          };
          Object[] prmP00DI3;
          prmP00DI3 = new Object[] {
          new ParDef("@AV10OperacionesId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DI2", "SELECT [WalletCodRefencia], [WalletTipoEntidad], [WalletId] FROM [Wallet] WHERE [WalletId] = @AV33WalletId ORDER BY [WalletId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DI2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00DI3", "SELECT [OperacionesId], [OperacionesImporte] FROM [Operaciones] WHERE [OperacionesId] = @AV10OperacionesId ORDER BY [OperacionesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DI3,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
