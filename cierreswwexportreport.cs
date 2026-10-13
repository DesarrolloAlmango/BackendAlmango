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
   public class cierreswwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public cierreswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public cierreswwexportreport( IGxContext context )
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
         setOutputFileName("CierresWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCierres", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV58Pgmname));
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
               AV56Title = context.GetMessage( "Lista de Cierres", "");
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
            HJ10( true, 0) ;
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
            HJ10( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV32GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "CIERRESULTIMAFECHA") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV18CierresUltimaFecha1 = context.localUtil.CToD( AV32GridStateDynamicFilter.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV19CierresUltimaFecha_To1 = context.localUtil.CToD( AV32GridStateDynamicFilter.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               if ( ! (DateTime.MinValue==AV18CierresUltimaFecha1) || ! (DateTime.MinValue==AV19CierresUltimaFecha_To1) )
               {
                  AV16FixedValueOperatorDsc = context.GetMessage( "del Cierre", "");
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FixedValueOperatorValue = context.GetMessage( "WWP_FilterPast", "");
                     HJ10( false, 19) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FixedValueOperatorDsc, "")), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FixedValueOperatorValue, "")), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FixedValueOperatorValue = context.GetMessage( "WWP_FilterToday", "");
                     HJ10( false, 19) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FixedValueOperatorDsc, "")), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FixedValueOperatorValue, "")), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                  }
                  else if ( AV15DynamicFiltersOperator1 == 2 )
                  {
                     AV17FixedValueOperatorValue = context.GetMessage( "WWP_FilterInTheFuture", "");
                     HJ10( false, 19) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FixedValueOperatorDsc, "")), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FixedValueOperatorValue, "")), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                  }
                  else if ( AV15DynamicFiltersOperator1 == 3 )
                  {
                     AV20FilterCierresUltimaFechaDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "del Cierre", ""), context.GetMessage( "WWP_FilterRange", ""), "", "", "", "", "", "", "");
                     AV21CierresUltimaFecha = AV18CierresUltimaFecha1;
                     HJ10( false, 19) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterCierresUltimaFechaDescription, "")), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.localUtil.Format( AV21CierresUltimaFecha, "99/99/99"), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                     AV20FilterCierresUltimaFechaDescription = StringUtil.Format( "%1 (%2) %3", context.GetMessage( "del Cierre", ""), context.GetMessage( "WWP_FilterRange", ""), "", "", "", "", "", "", "");
                     AV21CierresUltimaFecha = AV19CierresUltimaFecha_To1;
                     HJ10( false, 19) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterCierresUltimaFechaDescription, "")), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.localUtil.Format( AV21CierresUltimaFecha, "99/99/99"), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                  }
               }
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CIERRESULTIMAFECHA") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV25CierresUltimaFecha2 = context.localUtil.CToD( AV32GridStateDynamicFilter.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  AV26CierresUltimaFecha_To2 = context.localUtil.CToD( AV32GridStateDynamicFilter.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  if ( ! (DateTime.MinValue==AV25CierresUltimaFecha2) || ! (DateTime.MinValue==AV26CierresUltimaFecha_To2) )
                  {
                     AV16FixedValueOperatorDsc = context.GetMessage( "del Cierre", "");
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV17FixedValueOperatorValue = context.GetMessage( "WWP_FilterPast", "");
                        HJ10( false, 19) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FixedValueOperatorDsc, "")), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FixedValueOperatorValue, "")), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV17FixedValueOperatorValue = context.GetMessage( "WWP_FilterToday", "");
                        HJ10( false, 19) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FixedValueOperatorDsc, "")), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FixedValueOperatorValue, "")), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                     }
                     else if ( AV24DynamicFiltersOperator2 == 2 )
                     {
                        AV17FixedValueOperatorValue = context.GetMessage( "WWP_FilterInTheFuture", "");
                        HJ10( false, 19) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FixedValueOperatorDsc, "")), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FixedValueOperatorValue, "")), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                     }
                     else if ( AV24DynamicFiltersOperator2 == 3 )
                     {
                        AV20FilterCierresUltimaFechaDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "del Cierre", ""), context.GetMessage( "WWP_FilterRange", ""), "", "", "", "", "", "", "");
                        AV21CierresUltimaFecha = AV25CierresUltimaFecha2;
                        HJ10( false, 19) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterCierresUltimaFechaDescription, "")), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV21CierresUltimaFecha, "99/99/99"), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                        AV20FilterCierresUltimaFechaDescription = StringUtil.Format( "%1 (%2) %3", context.GetMessage( "del Cierre", ""), context.GetMessage( "WWP_FilterRange", ""), "", "", "", "", "", "", "");
                        AV21CierresUltimaFecha = AV26CierresUltimaFecha_To2;
                        HJ10( false, 19) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterCierresUltimaFechaDescription, "")), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV21CierresUltimaFecha, "99/99/99"), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                     }
                  }
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CIERRESULTIMAFECHA") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV30CierresUltimaFecha3 = context.localUtil.CToD( AV32GridStateDynamicFilter.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                     AV31CierresUltimaFecha_To3 = context.localUtil.CToD( AV32GridStateDynamicFilter.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                     if ( ! (DateTime.MinValue==AV30CierresUltimaFecha3) || ! (DateTime.MinValue==AV31CierresUltimaFecha_To3) )
                     {
                        AV16FixedValueOperatorDsc = context.GetMessage( "del Cierre", "");
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV17FixedValueOperatorValue = context.GetMessage( "WWP_FilterPast", "");
                           HJ10( false, 19) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FixedValueOperatorDsc, "")), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FixedValueOperatorValue, "")), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+19);
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV17FixedValueOperatorValue = context.GetMessage( "WWP_FilterToday", "");
                           HJ10( false, 19) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FixedValueOperatorDsc, "")), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FixedValueOperatorValue, "")), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+19);
                        }
                        else if ( AV29DynamicFiltersOperator3 == 2 )
                        {
                           AV17FixedValueOperatorValue = context.GetMessage( "WWP_FilterInTheFuture", "");
                           HJ10( false, 19) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FixedValueOperatorDsc, "")), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FixedValueOperatorValue, "")), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+19);
                        }
                        else if ( AV29DynamicFiltersOperator3 == 3 )
                        {
                           AV20FilterCierresUltimaFechaDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "del Cierre", ""), context.GetMessage( "WWP_FilterRange", ""), "", "", "", "", "", "", "");
                           AV21CierresUltimaFecha = AV30CierresUltimaFecha3;
                           HJ10( false, 19) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterCierresUltimaFechaDescription, "")), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(context.localUtil.Format( AV21CierresUltimaFecha, "99/99/99"), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+19);
                           AV20FilterCierresUltimaFechaDescription = StringUtil.Format( "%1 (%2) %3", context.GetMessage( "del Cierre", ""), context.GetMessage( "WWP_FilterRange", ""), "", "", "", "", "", "", "");
                           AV21CierresUltimaFecha = AV31CierresUltimaFecha_To3;
                           HJ10( false, 19) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterCierresUltimaFechaDescription, "")), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(context.localUtil.Format( AV21CierresUltimaFecha, "99/99/99"), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+19);
                        }
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV37TFCierresId) && (0==AV38TFCierresId_To) ) )
         {
            HJ10( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Id", ""), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV37TFCierresId), "ZZZZZZZZZZZZZZZZZ9")), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV43TFCierresId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Id", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HJ10( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFCierresId_To_Description, "")), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV38TFCierresId_To), "ZZZZZZZZZZZZZZZZZ9")), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (DateTime.MinValue==AV39TFCierresUltimaFecha) && (DateTime.MinValue==AV40TFCierresUltimaFecha_To) ) )
         {
            HJ10( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "del Cierre", ""), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV39TFCierresUltimaFecha, "99/99/99"), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV44TFCierresUltimaFecha_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "del Cierre", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HJ10( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44TFCierresUltimaFecha_To_Description, "")), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV40TFCierresUltimaFecha_To, "99/99/99"), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TFCierresUsuario_Sel)) )
         {
            AV45TempBoolean = (bool)(((StringUtil.StrCmp(AV42TFCierresUsuario_Sel, "<#Empty#>")==0)));
            AV42TFCierresUsuario_Sel = (AV45TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV42TFCierresUsuario_Sel);
            HJ10( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "de Cierre", ""), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFCierresUsuario_Sel, "")), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV42TFCierresUsuario_Sel = (AV45TempBoolean ? "<#Empty#>" : AV42TFCierresUsuario_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41TFCierresUsuario)) )
            {
               HJ10( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "de Cierre", ""), 25, Gx_line+0, 132, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFCierresUsuario, "")), 132, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HJ10( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HJ10( false, 36) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Id", ""), 30, Gx_line+10, 217, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "del Cierre", ""), 221, Gx_line+10, 408, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "de Cierre", ""), 412, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV62Cierreswwds_1_filterfulltext = AV13FilterFullText;
         AV63Cierreswwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV64Cierreswwds_3_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV65Cierreswwds_4_cierresultimafecha1 = AV18CierresUltimaFecha1;
         AV66Cierreswwds_5_cierresultimafecha_to1 = AV19CierresUltimaFecha_To1;
         AV67Cierreswwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV68Cierreswwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV69Cierreswwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV70Cierreswwds_9_cierresultimafecha2 = AV25CierresUltimaFecha2;
         AV71Cierreswwds_10_cierresultimafecha_to2 = AV26CierresUltimaFecha_To2;
         AV72Cierreswwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV73Cierreswwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV74Cierreswwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV75Cierreswwds_14_cierresultimafecha3 = AV30CierresUltimaFecha3;
         AV76Cierreswwds_15_cierresultimafecha_to3 = AV31CierresUltimaFecha_To3;
         AV77Cierreswwds_16_tfcierresid = AV37TFCierresId;
         AV78Cierreswwds_17_tfcierresid_to = AV38TFCierresId_To;
         AV79Cierreswwds_18_tfcierresultimafecha = AV39TFCierresUltimaFecha;
         AV80Cierreswwds_19_tfcierresultimafecha_to = AV40TFCierresUltimaFecha_To;
         AV81Cierreswwds_20_tfcierresusuario = AV41TFCierresUsuario;
         AV82Cierreswwds_21_tfcierresusuario_sel = AV42TFCierresUsuario_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV62Cierreswwds_1_filterfulltext ,
                                              AV63Cierreswwds_2_dynamicfiltersselector1 ,
                                              AV64Cierreswwds_3_dynamicfiltersoperator1 ,
                                              AV65Cierreswwds_4_cierresultimafecha1 ,
                                              AV66Cierreswwds_5_cierresultimafecha_to1 ,
                                              AV67Cierreswwds_6_dynamicfiltersenabled2 ,
                                              AV68Cierreswwds_7_dynamicfiltersselector2 ,
                                              AV69Cierreswwds_8_dynamicfiltersoperator2 ,
                                              AV70Cierreswwds_9_cierresultimafecha2 ,
                                              AV71Cierreswwds_10_cierresultimafecha_to2 ,
                                              AV72Cierreswwds_11_dynamicfiltersenabled3 ,
                                              AV73Cierreswwds_12_dynamicfiltersselector3 ,
                                              AV74Cierreswwds_13_dynamicfiltersoperator3 ,
                                              AV75Cierreswwds_14_cierresultimafecha3 ,
                                              AV76Cierreswwds_15_cierresultimafecha_to3 ,
                                              AV77Cierreswwds_16_tfcierresid ,
                                              AV78Cierreswwds_17_tfcierresid_to ,
                                              AV79Cierreswwds_18_tfcierresultimafecha ,
                                              AV80Cierreswwds_19_tfcierresultimafecha_to ,
                                              AV82Cierreswwds_21_tfcierresusuario_sel ,
                                              AV81Cierreswwds_20_tfcierresusuario ,
                                              A155CierresId ,
                                              A314CierresUsuario ,
                                              A313CierresUltimaFecha ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV62Cierreswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Cierreswwds_1_filterfulltext), "%", "");
         lV62Cierreswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Cierreswwds_1_filterfulltext), "%", "");
         lV81Cierreswwds_20_tfcierresusuario = StringUtil.PadR( StringUtil.RTrim( AV81Cierreswwds_20_tfcierresusuario), 30, "%");
         /* Using cursor P00J12 */
         pr_default.execute(0, new Object[] {lV62Cierreswwds_1_filterfulltext, lV62Cierreswwds_1_filterfulltext, AV65Cierreswwds_4_cierresultimafecha1, AV65Cierreswwds_4_cierresultimafecha1, AV65Cierreswwds_4_cierresultimafecha1, AV65Cierreswwds_4_cierresultimafecha1, AV66Cierreswwds_5_cierresultimafecha_to1, AV70Cierreswwds_9_cierresultimafecha2, AV70Cierreswwds_9_cierresultimafecha2, AV70Cierreswwds_9_cierresultimafecha2, AV70Cierreswwds_9_cierresultimafecha2, AV71Cierreswwds_10_cierresultimafecha_to2, AV75Cierreswwds_14_cierresultimafecha3, AV75Cierreswwds_14_cierresultimafecha3, AV75Cierreswwds_14_cierresultimafecha3, AV75Cierreswwds_14_cierresultimafecha3, AV76Cierreswwds_15_cierresultimafecha_to3, AV77Cierreswwds_16_tfcierresid, AV78Cierreswwds_17_tfcierresid_to, AV79Cierreswwds_18_tfcierresultimafecha, AV80Cierreswwds_19_tfcierresultimafecha_to, lV81Cierreswwds_20_tfcierresusuario, AV82Cierreswwds_21_tfcierresusuario_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A314CierresUsuario = P00J12_A314CierresUsuario[0];
            A155CierresId = P00J12_A155CierresId[0];
            A313CierresUltimaFecha = P00J12_A313CierresUltimaFecha[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            HJ10( false, 35) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A155CierresId), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 217, Gx_line+24, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A313CierresUltimaFecha, "99/99/99"), 221, Gx_line+10, 408, Gx_line+24, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A314CierresUsuario, "")), 412, Gx_line+10, 787, Gx_line+24, 0+16, 0, 0, 0) ;
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
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S151( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV33Session.Get("CierresWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "CierresWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("CierresWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV35GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV35GridState.gxTpr_Ordereddsc;
         AV83GXV1 = 1;
         while ( AV83GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV83GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCIERRESID") == 0 )
            {
               AV37TFCierresId = (long)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV38TFCierresId_To = (long)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCIERRESULTIMAFECHA") == 0 )
            {
               AV39TFCierresUltimaFecha = context.localUtil.CToD( AV36GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV40TFCierresUltimaFecha_To = context.localUtil.CToD( AV36GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCIERRESUSUARIO") == 0 )
            {
               AV41TFCierresUsuario = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCIERRESUSUARIO_SEL") == 0 )
            {
               AV42TFCierresUsuario_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            AV83GXV1 = (int)(AV83GXV1+1);
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

      protected void HJ10( bool bFoot ,
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
                  AV54PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV51DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+39, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54PageInfo, "")), 30, Gx_line+15, 409, Gx_line+29, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51DateInfo, "")), 409, Gx_line+15, 789, Gx_line+29, 2, 0, 0, 0) ;
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
               AV49AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV55Phone = "+1 550 8923";
               AV53Mail = "info@mail.com";
               AV57Website = "http://www.web.com";
               AV46AddressLine1 = "French Boulevard 2859";
               AV47AddressLine2 = "Downtown";
               AV48AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+107, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49AppName, "")), 30, Gx_line+30, 283, Gx_line+44, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56Title, "")), 30, Gx_line+44, 283, Gx_line+77, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55Phone, "")), 283, Gx_line+30, 536, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53Mail, "")), 283, Gx_line+45, 536, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57Website, "")), 283, Gx_line+60, 536, Gx_line+77, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47AddressLine2, "")), 536, Gx_line+45, 789, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48AddressLine3, "")), 536, Gx_line+60, 789, Gx_line+77, 2, 0, 0, 0) ;
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
         AV58Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV56Title = "";
         AV13FilterFullText = "";
         AV35GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV32GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV18CierresUltimaFecha1 = DateTime.MinValue;
         AV19CierresUltimaFecha_To1 = DateTime.MinValue;
         AV16FixedValueOperatorDsc = "";
         AV17FixedValueOperatorValue = "";
         AV20FilterCierresUltimaFechaDescription = "";
         AV21CierresUltimaFecha = DateTime.MinValue;
         AV23DynamicFiltersSelector2 = "";
         AV25CierresUltimaFecha2 = DateTime.MinValue;
         AV26CierresUltimaFecha_To2 = DateTime.MinValue;
         AV28DynamicFiltersSelector3 = "";
         AV30CierresUltimaFecha3 = DateTime.MinValue;
         AV31CierresUltimaFecha_To3 = DateTime.MinValue;
         AV43TFCierresId_To_Description = "";
         AV39TFCierresUltimaFecha = DateTime.MinValue;
         AV40TFCierresUltimaFecha_To = DateTime.MinValue;
         AV44TFCierresUltimaFecha_To_Description = "";
         AV42TFCierresUsuario_Sel = "";
         AV41TFCierresUsuario = "";
         AV62Cierreswwds_1_filterfulltext = "";
         AV63Cierreswwds_2_dynamicfiltersselector1 = "";
         AV65Cierreswwds_4_cierresultimafecha1 = DateTime.MinValue;
         AV66Cierreswwds_5_cierresultimafecha_to1 = DateTime.MinValue;
         AV68Cierreswwds_7_dynamicfiltersselector2 = "";
         AV70Cierreswwds_9_cierresultimafecha2 = DateTime.MinValue;
         AV71Cierreswwds_10_cierresultimafecha_to2 = DateTime.MinValue;
         AV73Cierreswwds_12_dynamicfiltersselector3 = "";
         AV75Cierreswwds_14_cierresultimafecha3 = DateTime.MinValue;
         AV76Cierreswwds_15_cierresultimafecha_to3 = DateTime.MinValue;
         AV79Cierreswwds_18_tfcierresultimafecha = DateTime.MinValue;
         AV80Cierreswwds_19_tfcierresultimafecha_to = DateTime.MinValue;
         AV81Cierreswwds_20_tfcierresusuario = "";
         AV82Cierreswwds_21_tfcierresusuario_sel = "";
         lV62Cierreswwds_1_filterfulltext = "";
         lV81Cierreswwds_20_tfcierresusuario = "";
         A314CierresUsuario = "";
         A313CierresUltimaFecha = DateTime.MinValue;
         P00J12_A314CierresUsuario = new string[] {""} ;
         P00J12_A155CierresId = new long[1] ;
         P00J12_A313CierresUltimaFecha = new DateTime[] {DateTime.MinValue} ;
         AV33Session = context.GetSession();
         AV36GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV54PageInfo = "";
         AV51DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV49AppName = "";
         AV55Phone = "";
         AV53Mail = "";
         AV57Website = "";
         AV46AddressLine1 = "";
         AV47AddressLine2 = "";
         AV48AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cierreswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00J12_A314CierresUsuario, P00J12_A155CierresId, P00J12_A313CierresUltimaFecha
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV58Pgmname = "CierresWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV58Pgmname = "CierresWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV15DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short AV64Cierreswwds_3_dynamicfiltersoperator1 ;
      private short AV69Cierreswwds_8_dynamicfiltersoperator2 ;
      private short AV74Cierreswwds_13_dynamicfiltersoperator3 ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV83GXV1 ;
      private long AV37TFCierresId ;
      private long AV38TFCierresId_To ;
      private long AV77Cierreswwds_16_tfcierresid ;
      private long AV78Cierreswwds_17_tfcierresid_to ;
      private long A155CierresId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV58Pgmname ;
      private string GXEncryptionTmp ;
      private string AV42TFCierresUsuario_Sel ;
      private string AV41TFCierresUsuario ;
      private string AV81Cierreswwds_20_tfcierresusuario ;
      private string AV82Cierreswwds_21_tfcierresusuario_sel ;
      private string lV81Cierreswwds_20_tfcierresusuario ;
      private string A314CierresUsuario ;
      private DateTime AV18CierresUltimaFecha1 ;
      private DateTime AV19CierresUltimaFecha_To1 ;
      private DateTime AV21CierresUltimaFecha ;
      private DateTime AV25CierresUltimaFecha2 ;
      private DateTime AV26CierresUltimaFecha_To2 ;
      private DateTime AV30CierresUltimaFecha3 ;
      private DateTime AV31CierresUltimaFecha_To3 ;
      private DateTime AV39TFCierresUltimaFecha ;
      private DateTime AV40TFCierresUltimaFecha_To ;
      private DateTime AV65Cierreswwds_4_cierresultimafecha1 ;
      private DateTime AV66Cierreswwds_5_cierresultimafecha_to1 ;
      private DateTime AV70Cierreswwds_9_cierresultimafecha2 ;
      private DateTime AV71Cierreswwds_10_cierresultimafecha_to2 ;
      private DateTime AV75Cierreswwds_14_cierresultimafecha3 ;
      private DateTime AV76Cierreswwds_15_cierresultimafecha_to3 ;
      private DateTime AV79Cierreswwds_18_tfcierresultimafecha ;
      private DateTime AV80Cierreswwds_19_tfcierresultimafecha_to ;
      private DateTime A313CierresUltimaFecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV45TempBoolean ;
      private bool AV67Cierreswwds_6_dynamicfiltersenabled2 ;
      private bool AV72Cierreswwds_11_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private string AV56Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV16FixedValueOperatorDsc ;
      private string AV17FixedValueOperatorValue ;
      private string AV20FilterCierresUltimaFechaDescription ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV43TFCierresId_To_Description ;
      private string AV44TFCierresUltimaFecha_To_Description ;
      private string AV62Cierreswwds_1_filterfulltext ;
      private string AV63Cierreswwds_2_dynamicfiltersselector1 ;
      private string AV68Cierreswwds_7_dynamicfiltersselector2 ;
      private string AV73Cierreswwds_12_dynamicfiltersselector3 ;
      private string lV62Cierreswwds_1_filterfulltext ;
      private string AV54PageInfo ;
      private string AV51DateInfo ;
      private string AV49AppName ;
      private string AV55Phone ;
      private string AV53Mail ;
      private string AV57Website ;
      private string AV46AddressLine1 ;
      private string AV47AddressLine2 ;
      private string AV48AddressLine3 ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV32GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private string[] P00J12_A314CierresUsuario ;
      private long[] P00J12_A155CierresId ;
      private DateTime[] P00J12_A313CierresUltimaFecha ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
   }

   public class cierreswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00J12( IGxContext context ,
                                             string AV62Cierreswwds_1_filterfulltext ,
                                             string AV63Cierreswwds_2_dynamicfiltersselector1 ,
                                             short AV64Cierreswwds_3_dynamicfiltersoperator1 ,
                                             DateTime AV65Cierreswwds_4_cierresultimafecha1 ,
                                             DateTime AV66Cierreswwds_5_cierresultimafecha_to1 ,
                                             bool AV67Cierreswwds_6_dynamicfiltersenabled2 ,
                                             string AV68Cierreswwds_7_dynamicfiltersselector2 ,
                                             short AV69Cierreswwds_8_dynamicfiltersoperator2 ,
                                             DateTime AV70Cierreswwds_9_cierresultimafecha2 ,
                                             DateTime AV71Cierreswwds_10_cierresultimafecha_to2 ,
                                             bool AV72Cierreswwds_11_dynamicfiltersenabled3 ,
                                             string AV73Cierreswwds_12_dynamicfiltersselector3 ,
                                             short AV74Cierreswwds_13_dynamicfiltersoperator3 ,
                                             DateTime AV75Cierreswwds_14_cierresultimafecha3 ,
                                             DateTime AV76Cierreswwds_15_cierresultimafecha_to3 ,
                                             long AV77Cierreswwds_16_tfcierresid ,
                                             long AV78Cierreswwds_17_tfcierresid_to ,
                                             DateTime AV79Cierreswwds_18_tfcierresultimafecha ,
                                             DateTime AV80Cierreswwds_19_tfcierresultimafecha_to ,
                                             string AV82Cierreswwds_21_tfcierresusuario_sel ,
                                             string AV81Cierreswwds_20_tfcierresusuario ,
                                             long A155CierresId ,
                                             string A314CierresUsuario ,
                                             DateTime A313CierresUltimaFecha ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[23];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [CierresUsuario], [CierresId], [CierresUltimaFecha] FROM [Cierres]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Cierreswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST([CierresId] AS decimal(18,0))) like '%' + @lV62Cierreswwds_1_filterfulltext) or ( UPPER([CierresUsuario]) like '%' + UPPER(@lV62Cierreswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Cierreswwds_2_dynamicfiltersselector1, "CIERRESULTIMAFECHA") == 0 ) && ( AV64Cierreswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV65Cierreswwds_4_cierresultimafecha1) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] < @AV65Cierreswwds_4_cierresultimafecha1)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Cierreswwds_2_dynamicfiltersselector1, "CIERRESULTIMAFECHA") == 0 ) && ( AV64Cierreswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV65Cierreswwds_4_cierresultimafecha1) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] = @AV65Cierreswwds_4_cierresultimafecha1)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Cierreswwds_2_dynamicfiltersselector1, "CIERRESULTIMAFECHA") == 0 ) && ( AV64Cierreswwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (DateTime.MinValue==AV65Cierreswwds_4_cierresultimafecha1) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] > @AV65Cierreswwds_4_cierresultimafecha1)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Cierreswwds_2_dynamicfiltersselector1, "CIERRESULTIMAFECHA") == 0 ) && ( AV64Cierreswwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV65Cierreswwds_4_cierresultimafecha1) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] >= @AV65Cierreswwds_4_cierresultimafecha1)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Cierreswwds_2_dynamicfiltersselector1, "CIERRESULTIMAFECHA") == 0 ) && ( AV64Cierreswwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV66Cierreswwds_5_cierresultimafecha_to1) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] <= @AV66Cierreswwds_5_cierresultimafecha_to1)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV67Cierreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Cierreswwds_7_dynamicfiltersselector2, "CIERRESULTIMAFECHA") == 0 ) && ( AV69Cierreswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV70Cierreswwds_9_cierresultimafecha2) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] < @AV70Cierreswwds_9_cierresultimafecha2)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( AV67Cierreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Cierreswwds_7_dynamicfiltersselector2, "CIERRESULTIMAFECHA") == 0 ) && ( AV69Cierreswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV70Cierreswwds_9_cierresultimafecha2) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] = @AV70Cierreswwds_9_cierresultimafecha2)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( AV67Cierreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Cierreswwds_7_dynamicfiltersselector2, "CIERRESULTIMAFECHA") == 0 ) && ( AV69Cierreswwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (DateTime.MinValue==AV70Cierreswwds_9_cierresultimafecha2) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] > @AV70Cierreswwds_9_cierresultimafecha2)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( AV67Cierreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Cierreswwds_7_dynamicfiltersselector2, "CIERRESULTIMAFECHA") == 0 ) && ( AV69Cierreswwds_8_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV70Cierreswwds_9_cierresultimafecha2) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] >= @AV70Cierreswwds_9_cierresultimafecha2)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( AV67Cierreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Cierreswwds_7_dynamicfiltersselector2, "CIERRESULTIMAFECHA") == 0 ) && ( AV69Cierreswwds_8_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV71Cierreswwds_10_cierresultimafecha_to2) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] <= @AV71Cierreswwds_10_cierresultimafecha_to2)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( AV72Cierreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Cierreswwds_12_dynamicfiltersselector3, "CIERRESULTIMAFECHA") == 0 ) && ( AV74Cierreswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV75Cierreswwds_14_cierresultimafecha3) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] < @AV75Cierreswwds_14_cierresultimafecha3)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( AV72Cierreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Cierreswwds_12_dynamicfiltersselector3, "CIERRESULTIMAFECHA") == 0 ) && ( AV74Cierreswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV75Cierreswwds_14_cierresultimafecha3) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] = @AV75Cierreswwds_14_cierresultimafecha3)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( AV72Cierreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Cierreswwds_12_dynamicfiltersselector3, "CIERRESULTIMAFECHA") == 0 ) && ( AV74Cierreswwds_13_dynamicfiltersoperator3 == 2 ) && ( ! (DateTime.MinValue==AV75Cierreswwds_14_cierresultimafecha3) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] > @AV75Cierreswwds_14_cierresultimafecha3)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( AV72Cierreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Cierreswwds_12_dynamicfiltersselector3, "CIERRESULTIMAFECHA") == 0 ) && ( AV74Cierreswwds_13_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV75Cierreswwds_14_cierresultimafecha3) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] >= @AV75Cierreswwds_14_cierresultimafecha3)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( AV72Cierreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Cierreswwds_12_dynamicfiltersselector3, "CIERRESULTIMAFECHA") == 0 ) && ( AV74Cierreswwds_13_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV76Cierreswwds_15_cierresultimafecha_to3) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] <= @AV76Cierreswwds_15_cierresultimafecha_to3)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( ! (0==AV77Cierreswwds_16_tfcierresid) )
         {
            AddWhere(sWhereString, "([CierresId] >= @AV77Cierreswwds_16_tfcierresid)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( ! (0==AV78Cierreswwds_17_tfcierresid_to) )
         {
            AddWhere(sWhereString, "([CierresId] <= @AV78Cierreswwds_17_tfcierresid_to)");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( ! (DateTime.MinValue==AV79Cierreswwds_18_tfcierresultimafecha) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] >= @AV79Cierreswwds_18_tfcierresultimafecha)");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( ! (DateTime.MinValue==AV80Cierreswwds_19_tfcierresultimafecha_to) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] <= @AV80Cierreswwds_19_tfcierresultimafecha_to)");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Cierreswwds_21_tfcierresusuario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Cierreswwds_20_tfcierresusuario)) ) )
         {
            AddWhere(sWhereString, "(UPPER([CierresUsuario]) like UPPER(@lV81Cierreswwds_20_tfcierresusuario))");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Cierreswwds_21_tfcierresusuario_sel)) && ! ( StringUtil.StrCmp(AV82Cierreswwds_21_tfcierresusuario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([CierresUsuario] = @AV82Cierreswwds_21_tfcierresusuario_sel)");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( StringUtil.StrCmp(AV82Cierreswwds_21_tfcierresusuario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([CierresUsuario] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [CierresUltimaFecha]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CierresUltimaFecha] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [CierresId]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CierresId] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [CierresUsuario]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CierresUsuario] DESC";
         }
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00J12(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (DateTime)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] );
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
          Object[] prmP00J12;
          prmP00J12 = new Object[] {
          new ParDef("@lV62Cierreswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV62Cierreswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV65Cierreswwds_4_cierresultimafecha1",GXType.Date,8,0) ,
          new ParDef("@AV65Cierreswwds_4_cierresultimafecha1",GXType.Date,8,0) ,
          new ParDef("@AV65Cierreswwds_4_cierresultimafecha1",GXType.Date,8,0) ,
          new ParDef("@AV65Cierreswwds_4_cierresultimafecha1",GXType.Date,8,0) ,
          new ParDef("@AV66Cierreswwds_5_cierresultimafecha_to1",GXType.Date,8,0) ,
          new ParDef("@AV70Cierreswwds_9_cierresultimafecha2",GXType.Date,8,0) ,
          new ParDef("@AV70Cierreswwds_9_cierresultimafecha2",GXType.Date,8,0) ,
          new ParDef("@AV70Cierreswwds_9_cierresultimafecha2",GXType.Date,8,0) ,
          new ParDef("@AV70Cierreswwds_9_cierresultimafecha2",GXType.Date,8,0) ,
          new ParDef("@AV71Cierreswwds_10_cierresultimafecha_to2",GXType.Date,8,0) ,
          new ParDef("@AV75Cierreswwds_14_cierresultimafecha3",GXType.Date,8,0) ,
          new ParDef("@AV75Cierreswwds_14_cierresultimafecha3",GXType.Date,8,0) ,
          new ParDef("@AV75Cierreswwds_14_cierresultimafecha3",GXType.Date,8,0) ,
          new ParDef("@AV75Cierreswwds_14_cierresultimafecha3",GXType.Date,8,0) ,
          new ParDef("@AV76Cierreswwds_15_cierresultimafecha_to3",GXType.Date,8,0) ,
          new ParDef("@AV77Cierreswwds_16_tfcierresid",GXType.Decimal,18,0) ,
          new ParDef("@AV78Cierreswwds_17_tfcierresid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV79Cierreswwds_18_tfcierresultimafecha",GXType.Date,8,0) ,
          new ParDef("@AV80Cierreswwds_19_tfcierresultimafecha_to",GXType.Date,8,0) ,
          new ParDef("@lV81Cierreswwds_20_tfcierresusuario",GXType.Char,30,0) ,
          new ParDef("@AV82Cierreswwds_21_tfcierresusuario_sel",GXType.NChar,30,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00J12", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00J12,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 30);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                return;
       }
    }

 }

}
