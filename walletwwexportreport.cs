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
   public class walletwwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public walletwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public walletwwexportreport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( )
      {
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
         setOutputFileName("WalletWWExportReport");
         setOutputType("PDF");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 1, 15840, 12240, 0, 1, 1, 0, 1, 1) )
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
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWWallet", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV98Pgmname));
               CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
               context.wjLocDisableFrm = 1;
            }
            if ( AV8IsAuthorized )
            {
               new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
               /* Execute user subroutine: 'LOADGRIDSTATE' */
               S151 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               AV92Title = context.GetMessage( "Lista de Saldos y Cuentas", "");
               /* Execute user subroutine: 'PRINTFILTERS' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'PRINTCOLUMNTITLES' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'PRINTDATA' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'PRINTFOOTER' */
               S171 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HBE0( true, 0) ;
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
         /* 'PRINTFILTERS' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterFullText)) )
         {
            HBE0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (0==AV43TFWalletId) && (0==AV44TFWalletId_To) ) )
         {
            HBE0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Id", ""), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV43TFWalletId), "ZZZZZZZZZZZZZZZZZ9")), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV71TFWalletId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Id", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HBE0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71TFWalletId_To_Description, "")), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV44TFWalletId_To), "ZZZZZZZZZZZZZZZZZ9")), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58TFWalletCodRefencia_Sel)) )
         {
            AV80TempBoolean = (bool)(((StringUtil.StrCmp(AV58TFWalletCodRefencia_Sel, "<#Empty#>")==0)));
            AV58TFWalletCodRefencia_Sel = (AV80TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV58TFWalletCodRefencia_Sel);
            HBE0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Código de Refencia", ""), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58TFWalletCodRefencia_Sel, "")), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV58TFWalletCodRefencia_Sel = (AV80TempBoolean ? "<#Empty#>" : AV58TFWalletCodRefencia_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57TFWalletCodRefencia)) )
            {
               HBE0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Código de Refencia", ""), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57TFWalletCodRefencia, "")), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95TFWalletNombre_Sel)) )
         {
            AV80TempBoolean = (bool)(((StringUtil.StrCmp(AV95TFWalletNombre_Sel, "<#Empty#>")==0)));
            AV95TFWalletNombre_Sel = (AV80TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV95TFWalletNombre_Sel);
            HBE0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV95TFWalletNombre_Sel, "")), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV95TFWalletNombre_Sel = (AV80TempBoolean ? "<#Empty#>" : AV95TFWalletNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94TFWalletNombre)) )
            {
               HBE0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV94TFWalletNombre, "")), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97TFMonedaISOSimbolo_Sel)) )
         {
            AV80TempBoolean = (bool)(((StringUtil.StrCmp(AV97TFMonedaISOSimbolo_Sel, "<#Empty#>")==0)));
            AV97TFMonedaISOSimbolo_Sel = (AV80TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV97TFMonedaISOSimbolo_Sel);
            HBE0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Moneda", ""), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV97TFMonedaISOSimbolo_Sel, "")), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV97TFMonedaISOSimbolo_Sel = (AV80TempBoolean ? "<#Empty#>" : AV97TFMonedaISOSimbolo_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96TFMonedaISOSimbolo)) )
            {
               HBE0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Moneda", ""), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV96TFMonedaISOSimbolo, "")), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV65TFWalletSaldo) && (Convert.ToDecimal(0)==AV66TFWalletSaldo_To) ) )
         {
            HBE0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Saldo", ""), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV65TFWalletSaldo, "ZZZZZZZZZZZZZZ9.99")), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV78TFWalletSaldo_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Saldo", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HBE0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV78TFWalletSaldo_To_Description, "")), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66TFWalletSaldo_To, "ZZZZZZZZZZZZZZ9.99")), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HBE0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HBE0( false, 36) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Id", ""), 30, Gx_line+10, 135, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Código de Refencia", ""), 139, Gx_line+10, 351, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 355, Gx_line+10, 567, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Moneda", ""), 571, Gx_line+10, 677, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Saldo", ""), 681, Gx_line+10, 787, Gx_line+26, 2, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV102Walletwwds_1_filterfulltext = AV13FilterFullText;
         AV103Walletwwds_2_tfwalletid = AV43TFWalletId;
         AV104Walletwwds_3_tfwalletid_to = AV44TFWalletId_To;
         AV105Walletwwds_4_tfwalletcodrefencia = AV57TFWalletCodRefencia;
         AV106Walletwwds_5_tfwalletcodrefencia_sel = AV58TFWalletCodRefencia_Sel;
         AV107Walletwwds_6_tfwalletnombre = AV94TFWalletNombre;
         AV108Walletwwds_7_tfwalletnombre_sel = AV95TFWalletNombre_Sel;
         AV109Walletwwds_8_tfmonedaisosimbolo = AV96TFMonedaISOSimbolo;
         AV110Walletwwds_9_tfmonedaisosimbolo_sel = AV97TFMonedaISOSimbolo_Sel;
         AV111Walletwwds_10_tfwalletsaldo = AV65TFWalletSaldo;
         AV112Walletwwds_11_tfwalletsaldo_to = AV66TFWalletSaldo_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV103Walletwwds_2_tfwalletid ,
                                              AV104Walletwwds_3_tfwalletid_to ,
                                              AV106Walletwwds_5_tfwalletcodrefencia_sel ,
                                              AV105Walletwwds_4_tfwalletcodrefencia ,
                                              AV110Walletwwds_9_tfmonedaisosimbolo_sel ,
                                              AV109Walletwwds_8_tfmonedaisosimbolo ,
                                              A637WalletId ,
                                              A639WalletCodRefencia ,
                                              A119MonedaISOSimbolo ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              AV102Walletwwds_1_filterfulltext ,
                                              A715WalletNombre ,
                                              A648WalletSaldo ,
                                              AV108Walletwwds_7_tfwalletnombre_sel ,
                                              AV107Walletwwds_6_tfwalletnombre ,
                                              AV111Walletwwds_10_tfwalletsaldo ,
                                              AV112Walletwwds_11_tfwalletsaldo_to } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                              }
         });
         lV105Walletwwds_4_tfwalletcodrefencia = StringUtil.PadR( StringUtil.RTrim( AV105Walletwwds_4_tfwalletcodrefencia), 25, "%");
         lV109Walletwwds_8_tfmonedaisosimbolo = StringUtil.PadR( StringUtil.RTrim( AV109Walletwwds_8_tfmonedaisosimbolo), 3, "%");
         /* Using cursor P00BE2 */
         pr_default.execute(0, new Object[] {AV103Walletwwds_2_tfwalletid, AV104Walletwwds_3_tfwalletid_to, lV105Walletwwds_4_tfwalletcodrefencia, AV106Walletwwds_5_tfwalletcodrefencia_sel, lV109Walletwwds_8_tfmonedaisosimbolo, AV110Walletwwds_9_tfmonedaisosimbolo_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A118MonedaId = P00BE2_A118MonedaId[0];
            n118MonedaId = P00BE2_n118MonedaId[0];
            A119MonedaISOSimbolo = P00BE2_A119MonedaISOSimbolo[0];
            A639WalletCodRefencia = P00BE2_A639WalletCodRefencia[0];
            A638WalletTipoEntidad = P00BE2_A638WalletTipoEntidad[0];
            A637WalletId = P00BE2_A637WalletId[0];
            A119MonedaISOSimbolo = P00BE2_A119MonedaISOSimbolo[0];
            GXt_decimal2 = A646WalletTotalDebito;
            new owallettotaldc(context ).execute(  A637WalletId,  "DEB", out  GXt_decimal2) ;
            A646WalletTotalDebito = GXt_decimal2;
            GXt_decimal2 = A647WalletTotalCredito;
            new owallettotaldc(context ).execute(  A637WalletId,  "CRE", out  GXt_decimal2) ;
            A647WalletTotalCredito = GXt_decimal2;
            A648WalletSaldo = (decimal)(A647WalletTotalCredito-A646WalletTotalDebito);
            if ( (Convert.ToDecimal(0)==AV111Walletwwds_10_tfwalletsaldo) || ( ( A648WalletSaldo >= AV111Walletwwds_10_tfwalletsaldo ) ) )
            {
               if ( (Convert.ToDecimal(0)==AV112Walletwwds_11_tfwalletsaldo_to) || ( ( A648WalletSaldo <= AV112Walletwwds_11_tfwalletsaldo_to ) ) )
               {
                  GXt_char3 = A715WalletNombre;
                  new onombrewallet(context ).execute(  A638WalletTipoEntidad,  A639WalletCodRefencia, out  GXt_char3) ;
                  A715WalletNombre = GXt_char3;
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Walletwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A637WalletId), 18, 0) , StringUtil.PadR( "%" + AV102Walletwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A639WalletCodRefencia) , StringUtil.PadR( "%" + StringUtil.Upper( AV102Walletwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A715WalletNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV102Walletwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A119MonedaISOSimbolo) , StringUtil.PadR( "%" + StringUtil.Upper( AV102Walletwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A648WalletSaldo, 18, 2) , StringUtil.PadR( "%" + AV102Walletwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ) )
                  {
                     if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Walletwwds_7_tfwalletnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Walletwwds_6_tfwalletnombre)) ) ) || ( StringUtil.Like( StringUtil.Upper( A715WalletNombre) , StringUtil.PadR( StringUtil.Upper( AV107Walletwwds_6_tfwalletnombre) , 254 , "%"),  ' ' ) ) )
                     {
                        if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Walletwwds_7_tfwalletnombre_sel)) && ! ( StringUtil.StrCmp(AV108Walletwwds_7_tfwalletnombre_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A715WalletNombre, AV108Walletwwds_7_tfwalletnombre_sel) == 0 ) ) )
                        {
                           if ( ( StringUtil.StrCmp(AV108Walletwwds_7_tfwalletnombre_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A715WalletNombre)) || String.IsNullOrEmpty(StringUtil.RTrim( A715WalletNombre)) ) )
                           {
                              /* Execute user subroutine: 'BEFOREPRINTLINE' */
                              S144 ();
                              if ( returnInSub )
                              {
                                 pr_default.close(0);
                                 returnInSub = true;
                                 if (true) return;
                              }
                              HBE0( false, 35) ;
                              getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A637WalletId), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 135, Gx_line+24, 2+16, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A639WalletCodRefencia, "")), 139, Gx_line+10, 351, Gx_line+24, 0+16, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A715WalletNombre, "")), 355, Gx_line+10, 567, Gx_line+24, 0+16, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A119MonedaISOSimbolo, "")), 571, Gx_line+10, 677, Gx_line+24, 0+16, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A648WalletSaldo, "ZZZZZZZZZZZZZZ9.99")), 681, Gx_line+10, 787, Gx_line+24, 2+16, 0, 0, 0) ;
                              getPrinter().GxDrawLine(28, Gx_line+34, 789, Gx_line+34, 1, 220, 220, 220, 0) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+35);
                              /* Execute user subroutine: 'AFTERPRINTLINE' */
                              S161 ();
                              if ( returnInSub )
                              {
                                 pr_default.close(0);
                                 returnInSub = true;
                                 if (true) return;
                              }
                           }
                        }
                     }
                  }
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S151( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV39Session.Get("WalletWWGridState"), "") == 0 )
         {
            AV41GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WalletWWGridState"), null, "", "");
         }
         else
         {
            AV41GridState.FromXml(AV39Session.Get("WalletWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV41GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV41GridState.gxTpr_Ordereddsc;
         AV113GXV1 = 1;
         while ( AV113GXV1 <= AV41GridState.gxTpr_Filtervalues.Count )
         {
            AV42GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV41GridState.gxTpr_Filtervalues.Item(AV113GXV1));
            if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFWALLETID") == 0 )
            {
               AV43TFWalletId = (long)(Math.Round(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV44TFWalletId_To = (long)(Math.Round(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFWALLETCODREFENCIA") == 0 )
            {
               AV57TFWalletCodRefencia = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFWALLETCODREFENCIA_SEL") == 0 )
            {
               AV58TFWalletCodRefencia_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFWALLETNOMBRE") == 0 )
            {
               AV94TFWalletNombre = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFWALLETNOMBRE_SEL") == 0 )
            {
               AV95TFWalletNombre_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFMONEDAISOSIMBOLO") == 0 )
            {
               AV96TFMonedaISOSimbolo = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFMONEDAISOSIMBOLO_SEL") == 0 )
            {
               AV97TFMonedaISOSimbolo_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFWALLETSALDO") == 0 )
            {
               AV65TFWalletSaldo = NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, ".");
               AV66TFWalletSaldo_To = NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Valueto, ".");
            }
            AV113GXV1 = (int)(AV113GXV1+1);
         }
      }

      protected void S144( )
      {
         /* 'BEFOREPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S161( )
      {
         /* 'AFTERPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S171( )
      {
         /* 'PRINTFOOTER' Routine */
         returnInSub = false;
      }

      protected void HBE0( bool bFoot ,
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
                  AV90PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV87DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+39, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV90PageInfo, "")), 30, Gx_line+15, 409, Gx_line+29, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV87DateInfo, "")), 409, Gx_line+15, 789, Gx_line+29, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+39);
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
               AV85AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV91Phone = "+1 550 8923";
               AV89Mail = "info@mail.com";
               AV93Website = "http://www.web.com";
               AV82AddressLine1 = "French Boulevard 2859";
               AV83AddressLine2 = "Downtown";
               AV84AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+107, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV85AppName, "")), 30, Gx_line+30, 283, Gx_line+44, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV92Title, "")), 30, Gx_line+44, 283, Gx_line+77, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV91Phone, "")), 283, Gx_line+30, 536, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV89Mail, "")), 283, Gx_line+45, 536, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV93Website, "")), 283, Gx_line+60, 536, Gx_line+77, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV83AddressLine2, "")), 536, Gx_line+45, 789, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV84AddressLine3, "")), 536, Gx_line+60, 789, Gx_line+77, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+127);
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
         AV98Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV92Title = "";
         AV13FilterFullText = "";
         AV43TFWalletId = 0;
         AV44TFWalletId_To = 0;
         AV71TFWalletId_To_Description = "";
         AV58TFWalletCodRefencia_Sel = "";
         AV57TFWalletCodRefencia = "";
         AV95TFWalletNombre_Sel = "";
         AV94TFWalletNombre = "";
         AV97TFMonedaISOSimbolo_Sel = "";
         AV96TFMonedaISOSimbolo = "";
         AV78TFWalletSaldo_To_Description = "";
         AV102Walletwwds_1_filterfulltext = "";
         AV105Walletwwds_4_tfwalletcodrefencia = "";
         AV106Walletwwds_5_tfwalletcodrefencia_sel = "";
         AV107Walletwwds_6_tfwalletnombre = "";
         AV108Walletwwds_7_tfwalletnombre_sel = "";
         AV109Walletwwds_8_tfmonedaisosimbolo = "";
         AV110Walletwwds_9_tfmonedaisosimbolo_sel = "";
         lV105Walletwwds_4_tfwalletcodrefencia = "";
         lV109Walletwwds_8_tfmonedaisosimbolo = "";
         A639WalletCodRefencia = "";
         A119MonedaISOSimbolo = "";
         A715WalletNombre = "";
         P00BE2_A118MonedaId = new short[1] ;
         P00BE2_n118MonedaId = new bool[] {false} ;
         P00BE2_A119MonedaISOSimbolo = new string[] {""} ;
         P00BE2_A639WalletCodRefencia = new string[] {""} ;
         P00BE2_A638WalletTipoEntidad = new string[] {""} ;
         P00BE2_A637WalletId = new long[1] ;
         A638WalletTipoEntidad = "";
         GXt_char3 = "";
         AV39Session = context.GetSession();
         AV41GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV42GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV90PageInfo = "";
         AV87DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV85AppName = "";
         AV91Phone = "";
         AV89Mail = "";
         AV93Website = "";
         AV82AddressLine1 = "";
         AV83AddressLine2 = "";
         AV84AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.walletwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00BE2_A118MonedaId, P00BE2_n118MonedaId, P00BE2_A119MonedaISOSimbolo, P00BE2_A639WalletCodRefencia, P00BE2_A638WalletTipoEntidad, P00BE2_A637WalletId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV98Pgmname = "WalletWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV98Pgmname = "WalletWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV11OrderedBy ;
      private short A118MonedaId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV113GXV1 ;
      private long AV43TFWalletId ;
      private long AV44TFWalletId_To ;
      private long AV103Walletwwds_2_tfwalletid ;
      private long AV104Walletwwds_3_tfwalletid_to ;
      private long A637WalletId ;
      private decimal AV65TFWalletSaldo ;
      private decimal AV66TFWalletSaldo_To ;
      private decimal AV111Walletwwds_10_tfwalletsaldo ;
      private decimal AV112Walletwwds_11_tfwalletsaldo_to ;
      private decimal A648WalletSaldo ;
      private decimal A646WalletTotalDebito ;
      private decimal A647WalletTotalCredito ;
      private decimal GXt_decimal2 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV98Pgmname ;
      private string GXEncryptionTmp ;
      private string AV58TFWalletCodRefencia_Sel ;
      private string AV57TFWalletCodRefencia ;
      private string AV95TFWalletNombre_Sel ;
      private string AV94TFWalletNombre ;
      private string AV97TFMonedaISOSimbolo_Sel ;
      private string AV96TFMonedaISOSimbolo ;
      private string AV105Walletwwds_4_tfwalletcodrefencia ;
      private string AV106Walletwwds_5_tfwalletcodrefencia_sel ;
      private string AV107Walletwwds_6_tfwalletnombre ;
      private string AV108Walletwwds_7_tfwalletnombre_sel ;
      private string AV109Walletwwds_8_tfmonedaisosimbolo ;
      private string AV110Walletwwds_9_tfmonedaisosimbolo_sel ;
      private string lV105Walletwwds_4_tfwalletcodrefencia ;
      private string lV109Walletwwds_8_tfmonedaisosimbolo ;
      private string A639WalletCodRefencia ;
      private string A119MonedaISOSimbolo ;
      private string A715WalletNombre ;
      private string A638WalletTipoEntidad ;
      private string GXt_char3 ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV80TempBoolean ;
      private bool AV12OrderedDsc ;
      private bool n118MonedaId ;
      private string AV92Title ;
      private string AV13FilterFullText ;
      private string AV71TFWalletId_To_Description ;
      private string AV78TFWalletSaldo_To_Description ;
      private string AV102Walletwwds_1_filterfulltext ;
      private string AV90PageInfo ;
      private string AV87DateInfo ;
      private string AV85AppName ;
      private string AV91Phone ;
      private string AV89Mail ;
      private string AV93Website ;
      private string AV82AddressLine1 ;
      private string AV83AddressLine2 ;
      private string AV84AddressLine3 ;
      private IGxSession AV39Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private short[] P00BE2_A118MonedaId ;
      private bool[] P00BE2_n118MonedaId ;
      private string[] P00BE2_A119MonedaISOSimbolo ;
      private string[] P00BE2_A639WalletCodRefencia ;
      private string[] P00BE2_A638WalletTipoEntidad ;
      private long[] P00BE2_A637WalletId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV41GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV42GridStateFilterValue ;
   }

   public class walletwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BE2( IGxContext context ,
                                             long AV103Walletwwds_2_tfwalletid ,
                                             long AV104Walletwwds_3_tfwalletid_to ,
                                             string AV106Walletwwds_5_tfwalletcodrefencia_sel ,
                                             string AV105Walletwwds_4_tfwalletcodrefencia ,
                                             string AV110Walletwwds_9_tfmonedaisosimbolo_sel ,
                                             string AV109Walletwwds_8_tfmonedaisosimbolo ,
                                             long A637WalletId ,
                                             string A639WalletCodRefencia ,
                                             string A119MonedaISOSimbolo ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             string AV102Walletwwds_1_filterfulltext ,
                                             string A715WalletNombre ,
                                             decimal A648WalletSaldo ,
                                             string AV108Walletwwds_7_tfwalletnombre_sel ,
                                             string AV107Walletwwds_6_tfwalletnombre ,
                                             decimal AV111Walletwwds_10_tfwalletsaldo ,
                                             decimal AV112Walletwwds_11_tfwalletsaldo_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[6];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[MonedaId], T2.[MonedaISOSimbolo], T1.[WalletCodRefencia], T1.[WalletTipoEntidad], T1.[WalletId] FROM ([Wallet] T1 LEFT JOIN [Moneda] T2 ON T2.[MonedaId] = T1.[MonedaId])";
         if ( ! (0==AV103Walletwwds_2_tfwalletid) )
         {
            AddWhere(sWhereString, "(T1.[WalletId] >= @AV103Walletwwds_2_tfwalletid)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! (0==AV104Walletwwds_3_tfwalletid_to) )
         {
            AddWhere(sWhereString, "(T1.[WalletId] <= @AV104Walletwwds_3_tfwalletid_to)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Walletwwds_5_tfwalletcodrefencia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Walletwwds_4_tfwalletcodrefencia)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[WalletCodRefencia]) like UPPER(@lV105Walletwwds_4_tfwalletcodrefencia))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Walletwwds_5_tfwalletcodrefencia_sel)) && ! ( StringUtil.StrCmp(AV106Walletwwds_5_tfwalletcodrefencia_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[WalletCodRefencia] = @AV106Walletwwds_5_tfwalletcodrefencia_sel)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( StringUtil.StrCmp(AV106Walletwwds_5_tfwalletcodrefencia_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[WalletCodRefencia] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Walletwwds_9_tfmonedaisosimbolo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Walletwwds_8_tfmonedaisosimbolo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MonedaISOSimbolo]) like UPPER(@lV109Walletwwds_8_tfmonedaisosimbolo))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Walletwwds_9_tfmonedaisosimbolo_sel)) && ! ( StringUtil.StrCmp(AV110Walletwwds_9_tfmonedaisosimbolo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[MonedaISOSimbolo] = @AV110Walletwwds_9_tfmonedaisosimbolo_sel)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( StringUtil.StrCmp(AV110Walletwwds_9_tfmonedaisosimbolo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[MonedaISOSimbolo] IS NULL or (T2.[MonedaISOSimbolo] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[WalletId]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[WalletId] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[WalletCodRefencia]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[WalletCodRefencia] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[MonedaISOSimbolo]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[MonedaISOSimbolo] DESC";
         }
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00BE2(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (decimal)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00BE2;
          prmP00BE2 = new Object[] {
          new ParDef("@AV103Walletwwds_2_tfwalletid",GXType.Decimal,18,0) ,
          new ParDef("@AV104Walletwwds_3_tfwalletid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV105Walletwwds_4_tfwalletcodrefencia",GXType.Char,25,0) ,
          new ParDef("@AV106Walletwwds_5_tfwalletcodrefencia_sel",GXType.NChar,25,0) ,
          new ParDef("@lV109Walletwwds_8_tfmonedaisosimbolo",GXType.Char,3,0) ,
          new ParDef("@AV110Walletwwds_9_tfmonedaisosimbolo_sel",GXType.NChar,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BE2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BE2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 3);
                ((string[]) buf[3])[0] = rslt.getString(3, 25);
                ((string[]) buf[4])[0] = rslt.getString(4, 3);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                return;
       }
    }

 }

}
