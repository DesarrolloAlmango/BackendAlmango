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
   public class profesionalesrestriccionwwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public profesionalesrestriccionwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public profesionalesrestriccionwwexportreport( IGxContext context )
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
         setOutputFileName("ProfesionalesRestriccionWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionalesRestriccion", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV93Pgmname));
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
               AV91Title = context.GetMessage( "Lista de Lista Profesionales Restriccion", "");
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
            HM90( true, 0) ;
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
            HM90( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( AV43GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV43GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV37GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "RESTRICCIONESFECHAALTA") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV18RestriccionesFechaAlta1 = context.localUtil.CToT( AV37GridStateDynamicFilter.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV19RestriccionesFechaAlta_To1 = context.localUtil.CToT( AV37GridStateDynamicFilter.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               if ( ! (DateTime.MinValue==AV18RestriccionesFechaAlta1) || ! (DateTime.MinValue==AV19RestriccionesFechaAlta_To1) )
               {
                  AV16FixedValueOperatorDsc = context.GetMessage( "Fecha Alta", "");
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FixedValueOperatorValue = context.GetMessage( "WWP_FilterPast", "");
                     HM90( false, 19) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FixedValueOperatorDsc, "")), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FixedValueOperatorValue, "")), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FixedValueOperatorValue = context.GetMessage( "WWP_FilterToday", "");
                     HM90( false, 19) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FixedValueOperatorDsc, "")), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FixedValueOperatorValue, "")), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                  }
                  else if ( AV15DynamicFiltersOperator1 == 2 )
                  {
                     AV17FixedValueOperatorValue = context.GetMessage( "WWP_FilterInTheFuture", "");
                     HM90( false, 19) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FixedValueOperatorDsc, "")), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FixedValueOperatorValue, "")), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                  }
                  else if ( AV15DynamicFiltersOperator1 == 3 )
                  {
                     AV20FilterRestriccionesFechaAltaDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Fecha Alta", ""), context.GetMessage( "WWP_FilterRange", ""), "", "", "", "", "", "", "");
                     AV21RestriccionesFechaAlta = AV18RestriccionesFechaAlta1;
                     HM90( false, 19) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterRestriccionesFechaAltaDescription, "")), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.localUtil.Format( AV21RestriccionesFechaAlta, "99/99/99 99:99"), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                     AV20FilterRestriccionesFechaAltaDescription = StringUtil.Format( "%1 (%2) %3", context.GetMessage( "Fecha Alta", ""), context.GetMessage( "WWP_FilterRange", ""), context.GetMessage( "WWP_MiddleText", ""), "", "", "", "", "", "");
                     AV21RestriccionesFechaAlta = AV19RestriccionesFechaAlta_To1;
                     HM90( false, 19) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterRestriccionesFechaAltaDescription, "")), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.localUtil.Format( AV21RestriccionesFechaAlta, "99/99/99 99:99"), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                  }
               }
            }
            else if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "LISTANOMBRE") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV22ListaNombre1 = AV37GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ListaNombre1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV23FilterListaNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Lista Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV23FilterListaNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Lista Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV24ListaNombre = AV22ListaNombre1;
                  HM90( false, 19) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23FilterListaNombreDescription, "")), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24ListaNombre, "")), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
               }
            }
            if ( AV43GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV25DynamicFiltersEnabled2 = true;
               AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV43GridState.gxTpr_Dynamicfilters.Item(2));
               AV26DynamicFiltersSelector2 = AV37GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV26DynamicFiltersSelector2, "RESTRICCIONESFECHAALTA") == 0 )
               {
                  AV27DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV28RestriccionesFechaAlta2 = context.localUtil.CToT( AV37GridStateDynamicFilter.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  AV29RestriccionesFechaAlta_To2 = context.localUtil.CToT( AV37GridStateDynamicFilter.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  if ( ! (DateTime.MinValue==AV28RestriccionesFechaAlta2) || ! (DateTime.MinValue==AV29RestriccionesFechaAlta_To2) )
                  {
                     AV16FixedValueOperatorDsc = context.GetMessage( "Fecha Alta", "");
                     if ( AV27DynamicFiltersOperator2 == 0 )
                     {
                        AV17FixedValueOperatorValue = context.GetMessage( "WWP_FilterPast", "");
                        HM90( false, 19) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FixedValueOperatorDsc, "")), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FixedValueOperatorValue, "")), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                     }
                     else if ( AV27DynamicFiltersOperator2 == 1 )
                     {
                        AV17FixedValueOperatorValue = context.GetMessage( "WWP_FilterToday", "");
                        HM90( false, 19) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FixedValueOperatorDsc, "")), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FixedValueOperatorValue, "")), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                     }
                     else if ( AV27DynamicFiltersOperator2 == 2 )
                     {
                        AV17FixedValueOperatorValue = context.GetMessage( "WWP_FilterInTheFuture", "");
                        HM90( false, 19) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FixedValueOperatorDsc, "")), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FixedValueOperatorValue, "")), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                     }
                     else if ( AV27DynamicFiltersOperator2 == 3 )
                     {
                        AV20FilterRestriccionesFechaAltaDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Fecha Alta", ""), context.GetMessage( "WWP_FilterRange", ""), "", "", "", "", "", "", "");
                        AV21RestriccionesFechaAlta = AV28RestriccionesFechaAlta2;
                        HM90( false, 19) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterRestriccionesFechaAltaDescription, "")), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV21RestriccionesFechaAlta, "99/99/99 99:99"), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                        AV20FilterRestriccionesFechaAltaDescription = StringUtil.Format( "%1 (%2) %3", context.GetMessage( "Fecha Alta", ""), context.GetMessage( "WWP_FilterRange", ""), context.GetMessage( "WWP_MiddleText", ""), "", "", "", "", "", "");
                        AV21RestriccionesFechaAlta = AV29RestriccionesFechaAlta_To2;
                        HM90( false, 19) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterRestriccionesFechaAltaDescription, "")), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV21RestriccionesFechaAlta, "99/99/99 99:99"), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                     }
                  }
               }
               else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector2, "LISTANOMBRE") == 0 )
               {
                  AV27DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV30ListaNombre2 = AV37GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30ListaNombre2)) )
                  {
                     if ( AV27DynamicFiltersOperator2 == 0 )
                     {
                        AV23FilterListaNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Lista Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV27DynamicFiltersOperator2 == 1 )
                     {
                        AV23FilterListaNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Lista Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV24ListaNombre = AV30ListaNombre2;
                     HM90( false, 19) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23FilterListaNombreDescription, "")), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24ListaNombre, "")), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                  }
               }
               if ( AV43GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV31DynamicFiltersEnabled3 = true;
                  AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV43GridState.gxTpr_Dynamicfilters.Item(3));
                  AV32DynamicFiltersSelector3 = AV37GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV32DynamicFiltersSelector3, "RESTRICCIONESFECHAALTA") == 0 )
                  {
                     AV33DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV34RestriccionesFechaAlta3 = context.localUtil.CToT( AV37GridStateDynamicFilter.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                     AV35RestriccionesFechaAlta_To3 = context.localUtil.CToT( AV37GridStateDynamicFilter.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                     if ( ! (DateTime.MinValue==AV34RestriccionesFechaAlta3) || ! (DateTime.MinValue==AV35RestriccionesFechaAlta_To3) )
                     {
                        AV16FixedValueOperatorDsc = context.GetMessage( "Fecha Alta", "");
                        if ( AV33DynamicFiltersOperator3 == 0 )
                        {
                           AV17FixedValueOperatorValue = context.GetMessage( "WWP_FilterPast", "");
                           HM90( false, 19) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FixedValueOperatorDsc, "")), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FixedValueOperatorValue, "")), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+19);
                        }
                        else if ( AV33DynamicFiltersOperator3 == 1 )
                        {
                           AV17FixedValueOperatorValue = context.GetMessage( "WWP_FilterToday", "");
                           HM90( false, 19) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FixedValueOperatorDsc, "")), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FixedValueOperatorValue, "")), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+19);
                        }
                        else if ( AV33DynamicFiltersOperator3 == 2 )
                        {
                           AV17FixedValueOperatorValue = context.GetMessage( "WWP_FilterInTheFuture", "");
                           HM90( false, 19) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FixedValueOperatorDsc, "")), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FixedValueOperatorValue, "")), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+19);
                        }
                        else if ( AV33DynamicFiltersOperator3 == 3 )
                        {
                           AV20FilterRestriccionesFechaAltaDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Fecha Alta", ""), context.GetMessage( "WWP_FilterRange", ""), "", "", "", "", "", "", "");
                           AV21RestriccionesFechaAlta = AV34RestriccionesFechaAlta3;
                           HM90( false, 19) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterRestriccionesFechaAltaDescription, "")), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(context.localUtil.Format( AV21RestriccionesFechaAlta, "99/99/99 99:99"), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+19);
                           AV20FilterRestriccionesFechaAltaDescription = StringUtil.Format( "%1 (%2) %3", context.GetMessage( "Fecha Alta", ""), context.GetMessage( "WWP_FilterRange", ""), context.GetMessage( "WWP_MiddleText", ""), "", "", "", "", "", "");
                           AV21RestriccionesFechaAlta = AV35RestriccionesFechaAlta_To3;
                           HM90( false, 19) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterRestriccionesFechaAltaDescription, "")), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(context.localUtil.Format( AV21RestriccionesFechaAlta, "99/99/99 99:99"), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+19);
                        }
                     }
                  }
                  else if ( StringUtil.StrCmp(AV32DynamicFiltersSelector3, "LISTANOMBRE") == 0 )
                  {
                     AV33DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV36ListaNombre3 = AV37GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36ListaNombre3)) )
                     {
                        if ( AV33DynamicFiltersOperator3 == 0 )
                        {
                           AV23FilterListaNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Lista Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV33DynamicFiltersOperator3 == 1 )
                        {
                           AV23FilterListaNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Lista Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV24ListaNombre = AV36ListaNombre3;
                        HM90( false, 19) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23FilterListaNombreDescription, "")), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24ListaNombre, "")), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV45TFProfesionalesRestriccionId) && (0==AV46TFProfesionalesRestriccionId_To) ) )
         {
            HM90( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Restriccion Id", ""), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV45TFProfesionalesRestriccionId), "ZZZZZZZZZZZZZZZZZ9")), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV73TFProfesionalesRestriccionId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Restriccion Id", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HM90( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73TFProfesionalesRestriccionId_To_Description, "")), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV46TFProfesionalesRestriccionId_To), "ZZZZZZZZZZZZZZZZZ9")), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48TFProfesionalesId_Sel)) )
         {
            AV79TempBoolean = (bool)(((StringUtil.StrCmp(AV48TFProfesionalesId_Sel, "<#Empty#>")==0)));
            AV48TFProfesionalesId_Sel = (AV79TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV48TFProfesionalesId_Sel);
            HM90( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Identidad", ""), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48TFProfesionalesId_Sel, "")), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV48TFProfesionalesId_Sel = (AV79TempBoolean ? "<#Empty#>" : AV48TFProfesionalesId_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47TFProfesionalesId)) )
            {
               HM90( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Identidad", ""), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47TFProfesionalesId, "")), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50TFProfesionalesPrimerNombre_Sel)) )
         {
            AV79TempBoolean = (bool)(((StringUtil.StrCmp(AV50TFProfesionalesPrimerNombre_Sel, "<#Empty#>")==0)));
            AV50TFProfesionalesPrimerNombre_Sel = (AV79TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV50TFProfesionalesPrimerNombre_Sel);
            HM90( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Primer Nombre", ""), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50TFProfesionalesPrimerNombre_Sel, "")), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV50TFProfesionalesPrimerNombre_Sel = (AV79TempBoolean ? "<#Empty#>" : AV50TFProfesionalesPrimerNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49TFProfesionalesPrimerNombre)) )
            {
               HM90( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Primer Nombre", ""), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49TFProfesionalesPrimerNombre, "")), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52TFProfesionalesApellidoPrimero_Sel)) )
         {
            AV79TempBoolean = (bool)(((StringUtil.StrCmp(AV52TFProfesionalesApellidoPrimero_Sel, "<#Empty#>")==0)));
            AV52TFProfesionalesApellidoPrimero_Sel = (AV79TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV52TFProfesionalesApellidoPrimero_Sel);
            HM90( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Primer Apellido ", ""), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52TFProfesionalesApellidoPrimero_Sel, "")), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV52TFProfesionalesApellidoPrimero_Sel = (AV79TempBoolean ? "<#Empty#>" : AV52TFProfesionalesApellidoPrimero_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51TFProfesionalesApellidoPrimero)) )
            {
               HM90( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Primer Apellido ", ""), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51TFProfesionalesApellidoPrimero, "")), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! ( (0==AV53TFListaid) && (0==AV54TFListaid_To) ) )
         {
            HM90( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Listaid", ""), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV53TFListaid), "ZZZZZZZZZZZZZZZZZ9")), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV74TFListaid_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Listaid", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HM90( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74TFListaid_To_Description, "")), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV54TFListaid_To), "ZZZZZZZZZZZZZZZZZ9")), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56TFListaNombre_Sel)) )
         {
            AV79TempBoolean = (bool)(((StringUtil.StrCmp(AV56TFListaNombre_Sel, "<#Empty#>")==0)));
            AV56TFListaNombre_Sel = (AV79TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV56TFListaNombre_Sel);
            HM90( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56TFListaNombre_Sel, "")), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV56TFListaNombre_Sel = (AV79TempBoolean ? "<#Empty#>" : AV56TFListaNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55TFListaNombre)) )
            {
               HM90( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55TFListaNombre, "")), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         AV60TFListaEstado_Sels.FromJSonString(AV57TFListaEstado_SelsJson, null);
         if ( ! ( AV60TFListaEstado_Sels.Count == 0 ) )
         {
            AV80i = 1;
            AV96GXV1 = 1;
            while ( AV96GXV1 <= AV60TFListaEstado_Sels.Count )
            {
               AV59TFListaEstado_Sel = AV60TFListaEstado_Sels.GetString(AV96GXV1);
               if ( AV80i == 1 )
               {
                  AV58TFListaEstado_SelDscs = "";
               }
               else
               {
                  AV58TFListaEstado_SelDscs += ", ";
               }
               AV75FilterTFListaEstado_SelValueDescription = context.GetMessage( gxdomainestadoenum.getDescription(context,AV59TFListaEstado_Sel), "");
               AV58TFListaEstado_SelDscs += AV75FilterTFListaEstado_SelValueDescription;
               AV80i = (long)(AV80i+1);
               AV96GXV1 = (int)(AV96GXV1+1);
            }
            HM90( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58TFListaEstado_SelDscs, "")), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         AV64TFListaTipo_Sels.FromJSonString(AV61TFListaTipo_SelsJson, null);
         if ( ! ( AV64TFListaTipo_Sels.Count == 0 ) )
         {
            AV80i = 1;
            AV97GXV2 = 1;
            while ( AV97GXV2 <= AV64TFListaTipo_Sels.Count )
            {
               AV63TFListaTipo_Sel = AV64TFListaTipo_Sels.GetString(AV97GXV2);
               if ( AV80i == 1 )
               {
                  AV62TFListaTipo_SelDscs = "";
               }
               else
               {
                  AV62TFListaTipo_SelDscs += ", ";
               }
               AV76FilterTFListaTipo_SelValueDescription = context.GetMessage( gxdomainlistatipoenum.getDescription(context,AV63TFListaTipo_Sel), "");
               AV62TFListaTipo_SelDscs += AV76FilterTFListaTipo_SelValueDescription;
               AV80i = (long)(AV80i+1);
               AV97GXV2 = (int)(AV97GXV2+1);
            }
            HM90( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Tipo", ""), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62TFListaTipo_SelDscs, "")), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (DateTime.MinValue==AV65TFRestriccionesFechaAlta) && (DateTime.MinValue==AV66TFRestriccionesFechaAlta_To) ) )
         {
            HM90( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Fecha Alta", ""), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV65TFRestriccionesFechaAlta, "99/99/99 99:99"), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV77TFRestriccionesFechaAlta_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Fecha Alta", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HM90( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV77TFRestriccionesFechaAlta_To_Description, "")), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV66TFRestriccionesFechaAlta_To, "99/99/99 99:99"), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         AV70TFRestriccionesEstado_Sels.FromJSonString(AV67TFRestriccionesEstado_SelsJson, null);
         if ( ! ( AV70TFRestriccionesEstado_Sels.Count == 0 ) )
         {
            AV80i = 1;
            AV98GXV3 = 1;
            while ( AV98GXV3 <= AV70TFRestriccionesEstado_Sels.Count )
            {
               AV69TFRestriccionesEstado_Sel = AV70TFRestriccionesEstado_Sels.GetString(AV98GXV3);
               if ( AV80i == 1 )
               {
                  AV68TFRestriccionesEstado_SelDscs = "";
               }
               else
               {
                  AV68TFRestriccionesEstado_SelDscs += ", ";
               }
               AV78FilterTFRestriccionesEstado_SelValueDescription = context.GetMessage( gxdomainestadoenum.getDescription(context,AV69TFRestriccionesEstado_Sel), "");
               AV68TFRestriccionesEstado_SelDscs += AV78FilterTFRestriccionesEstado_SelValueDescription;
               AV80i = (long)(AV80i+1);
               AV98GXV3 = (int)(AV98GXV3+1);
            }
            HM90( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68TFRestriccionesEstado_SelDscs, "")), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72TFRestriccionesObservacion_Sel)) )
         {
            AV79TempBoolean = (bool)(((StringUtil.StrCmp(AV72TFRestriccionesObservacion_Sel, "<#Empty#>")==0)));
            AV72TFRestriccionesObservacion_Sel = (AV79TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV72TFRestriccionesObservacion_Sel);
            HM90( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Observacion", ""), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV72TFRestriccionesObservacion_Sel, "")), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV72TFRestriccionesObservacion_Sel = (AV79TempBoolean ? "<#Empty#>" : AV72TFRestriccionesObservacion_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71TFRestriccionesObservacion)) )
            {
               HM90( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Observacion", ""), 25, Gx_line+0, 179, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71TFRestriccionesObservacion, "")), 179, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HM90( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HM90( false, 36) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Restriccion Id", ""), 30, Gx_line+10, 95, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Identidad", ""), 99, Gx_line+10, 164, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Primer Nombre", ""), 168, Gx_line+10, 233, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Primer Apellido ", ""), 237, Gx_line+10, 302, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Listaid", ""), 306, Gx_line+10, 371, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 375, Gx_line+10, 440, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 444, Gx_line+10, 509, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Tipo", ""), 513, Gx_line+10, 578, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Fecha Alta", ""), 582, Gx_line+10, 647, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 651, Gx_line+10, 716, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Observacion", ""), 720, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV100Profesionalesrestriccionwwds_1_filterfulltext = AV13FilterFullText;
         AV101Profesionalesrestriccionwwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV102Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV103Profesionalesrestriccionwwds_4_restriccionesfechaalta1 = AV18RestriccionesFechaAlta1;
         AV104Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 = AV19RestriccionesFechaAlta_To1;
         AV105Profesionalesrestriccionwwds_6_listanombre1 = AV22ListaNombre1;
         AV106Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 = AV25DynamicFiltersEnabled2;
         AV107Profesionalesrestriccionwwds_8_dynamicfiltersselector2 = AV26DynamicFiltersSelector2;
         AV108Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 = AV27DynamicFiltersOperator2;
         AV109Profesionalesrestriccionwwds_10_restriccionesfechaalta2 = AV28RestriccionesFechaAlta2;
         AV110Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 = AV29RestriccionesFechaAlta_To2;
         AV111Profesionalesrestriccionwwds_12_listanombre2 = AV30ListaNombre2;
         AV112Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 = AV31DynamicFiltersEnabled3;
         AV113Profesionalesrestriccionwwds_14_dynamicfiltersselector3 = AV32DynamicFiltersSelector3;
         AV114Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 = AV33DynamicFiltersOperator3;
         AV115Profesionalesrestriccionwwds_16_restriccionesfechaalta3 = AV34RestriccionesFechaAlta3;
         AV116Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 = AV35RestriccionesFechaAlta_To3;
         AV117Profesionalesrestriccionwwds_18_listanombre3 = AV36ListaNombre3;
         AV118Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid = AV45TFProfesionalesRestriccionId;
         AV119Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to = AV46TFProfesionalesRestriccionId_To;
         AV120Profesionalesrestriccionwwds_21_tfprofesionalesid = AV47TFProfesionalesId;
         AV121Profesionalesrestriccionwwds_22_tfprofesionalesid_sel = AV48TFProfesionalesId_Sel;
         AV122Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre = AV49TFProfesionalesPrimerNombre;
         AV123Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel = AV50TFProfesionalesPrimerNombre_Sel;
         AV124Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero = AV51TFProfesionalesApellidoPrimero;
         AV125Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel = AV52TFProfesionalesApellidoPrimero_Sel;
         AV126Profesionalesrestriccionwwds_27_tflistaid = AV53TFListaid;
         AV127Profesionalesrestriccionwwds_28_tflistaid_to = AV54TFListaid_To;
         AV128Profesionalesrestriccionwwds_29_tflistanombre = AV55TFListaNombre;
         AV129Profesionalesrestriccionwwds_30_tflistanombre_sel = AV56TFListaNombre_Sel;
         AV130Profesionalesrestriccionwwds_31_tflistaestado_sels = AV60TFListaEstado_Sels;
         AV131Profesionalesrestriccionwwds_32_tflistatipo_sels = AV64TFListaTipo_Sels;
         AV132Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta = AV65TFRestriccionesFechaAlta;
         AV133Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to = AV66TFRestriccionesFechaAlta_To;
         AV134Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels = AV70TFRestriccionesEstado_Sels;
         AV135Profesionalesrestriccionwwds_36_tfrestriccionesobservacion = AV71TFRestriccionesObservacion;
         AV136Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel = AV72TFRestriccionesObservacion_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A593ListaEstado ,
                                              AV130Profesionalesrestriccionwwds_31_tflistaestado_sels ,
                                              A591ListaTipo ,
                                              AV131Profesionalesrestriccionwwds_32_tflistatipo_sels ,
                                              A974RestriccionesEstado ,
                                              AV134Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels ,
                                              AV101Profesionalesrestriccionwwds_2_dynamicfiltersselector1 ,
                                              AV102Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 ,
                                              AV103Profesionalesrestriccionwwds_4_restriccionesfechaalta1 ,
                                              AV104Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 ,
                                              AV105Profesionalesrestriccionwwds_6_listanombre1 ,
                                              AV106Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 ,
                                              AV107Profesionalesrestriccionwwds_8_dynamicfiltersselector2 ,
                                              AV108Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 ,
                                              AV109Profesionalesrestriccionwwds_10_restriccionesfechaalta2 ,
                                              AV110Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 ,
                                              AV111Profesionalesrestriccionwwds_12_listanombre2 ,
                                              AV112Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 ,
                                              AV113Profesionalesrestriccionwwds_14_dynamicfiltersselector3 ,
                                              AV114Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 ,
                                              AV115Profesionalesrestriccionwwds_16_restriccionesfechaalta3 ,
                                              AV116Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 ,
                                              AV117Profesionalesrestriccionwwds_18_listanombre3 ,
                                              AV118Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid ,
                                              AV119Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to ,
                                              AV121Profesionalesrestriccionwwds_22_tfprofesionalesid_sel ,
                                              AV120Profesionalesrestriccionwwds_21_tfprofesionalesid ,
                                              AV123Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel ,
                                              AV122Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre ,
                                              AV125Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel ,
                                              AV124Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero ,
                                              AV126Profesionalesrestriccionwwds_27_tflistaid ,
                                              AV127Profesionalesrestriccionwwds_28_tflistaid_to ,
                                              AV129Profesionalesrestriccionwwds_30_tflistanombre_sel ,
                                              AV128Profesionalesrestriccionwwds_29_tflistanombre ,
                                              AV130Profesionalesrestriccionwwds_31_tflistaestado_sels.Count ,
                                              AV131Profesionalesrestriccionwwds_32_tflistatipo_sels.Count ,
                                              AV132Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta ,
                                              AV133Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to ,
                                              AV134Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels.Count ,
                                              AV136Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel ,
                                              AV135Profesionalesrestriccionwwds_36_tfrestriccionesobservacion ,
                                              A973RestriccionesFechaAlta ,
                                              A592ListaNombre ,
                                              A976ProfesionalesRestriccionId ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A590Listaid ,
                                              A975RestriccionesObservacion ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              AV100Profesionalesrestriccionwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV105Profesionalesrestriccionwwds_6_listanombre1 = StringUtil.PadR( StringUtil.RTrim( AV105Profesionalesrestriccionwwds_6_listanombre1), 80, "%");
         lV105Profesionalesrestriccionwwds_6_listanombre1 = StringUtil.PadR( StringUtil.RTrim( AV105Profesionalesrestriccionwwds_6_listanombre1), 80, "%");
         lV111Profesionalesrestriccionwwds_12_listanombre2 = StringUtil.PadR( StringUtil.RTrim( AV111Profesionalesrestriccionwwds_12_listanombre2), 80, "%");
         lV111Profesionalesrestriccionwwds_12_listanombre2 = StringUtil.PadR( StringUtil.RTrim( AV111Profesionalesrestriccionwwds_12_listanombre2), 80, "%");
         lV117Profesionalesrestriccionwwds_18_listanombre3 = StringUtil.PadR( StringUtil.RTrim( AV117Profesionalesrestriccionwwds_18_listanombre3), 80, "%");
         lV117Profesionalesrestriccionwwds_18_listanombre3 = StringUtil.PadR( StringUtil.RTrim( AV117Profesionalesrestriccionwwds_18_listanombre3), 80, "%");
         lV120Profesionalesrestriccionwwds_21_tfprofesionalesid = StringUtil.PadR( StringUtil.RTrim( AV120Profesionalesrestriccionwwds_21_tfprofesionalesid), 20, "%");
         lV122Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre = StringUtil.PadR( StringUtil.RTrim( AV122Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre), 30, "%");
         lV124Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero = StringUtil.PadR( StringUtil.RTrim( AV124Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero), 30, "%");
         lV128Profesionalesrestriccionwwds_29_tflistanombre = StringUtil.PadR( StringUtil.RTrim( AV128Profesionalesrestriccionwwds_29_tflistanombre), 80, "%");
         lV135Profesionalesrestriccionwwds_36_tfrestriccionesobservacion = StringUtil.Concat( StringUtil.RTrim( AV135Profesionalesrestriccionwwds_36_tfrestriccionesobservacion), "%", "");
         /* Using cursor P00M92 */
         pr_default.execute(0, new Object[] {AV103Profesionalesrestriccionwwds_4_restriccionesfechaalta1, AV103Profesionalesrestriccionwwds_4_restriccionesfechaalta1, AV104Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1, AV104Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1, lV105Profesionalesrestriccionwwds_6_listanombre1, lV105Profesionalesrestriccionwwds_6_listanombre1, AV109Profesionalesrestriccionwwds_10_restriccionesfechaalta2, AV109Profesionalesrestriccionwwds_10_restriccionesfechaalta2, AV110Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2, AV110Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2, lV111Profesionalesrestriccionwwds_12_listanombre2, lV111Profesionalesrestriccionwwds_12_listanombre2, AV115Profesionalesrestriccionwwds_16_restriccionesfechaalta3, AV115Profesionalesrestriccionwwds_16_restriccionesfechaalta3, AV116Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3, AV116Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3, lV117Profesionalesrestriccionwwds_18_listanombre3, lV117Profesionalesrestriccionwwds_18_listanombre3, AV118Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid, AV119Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to, lV120Profesionalesrestriccionwwds_21_tfprofesionalesid, AV121Profesionalesrestriccionwwds_22_tfprofesionalesid_sel, lV122Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre, AV123Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel, lV124Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero, AV125Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel, AV126Profesionalesrestriccionwwds_27_tflistaid, AV127Profesionalesrestriccionwwds_28_tflistaid_to, lV128Profesionalesrestriccionwwds_29_tflistanombre, AV129Profesionalesrestriccionwwds_30_tflistanombre_sel, AV132Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta, AV133Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to, lV135Profesionalesrestriccionwwds_36_tfrestriccionesobservacion, AV136Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A975RestriccionesObservacion = P00M92_A975RestriccionesObservacion[0];
            n975RestriccionesObservacion = P00M92_n975RestriccionesObservacion[0];
            A592ListaNombre = P00M92_A592ListaNombre[0];
            A590Listaid = P00M92_A590Listaid[0];
            A167ProfesionalesApellidoPrimero = P00M92_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = P00M92_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P00M92_A120ProfesionalesId[0];
            A976ProfesionalesRestriccionId = P00M92_A976ProfesionalesRestriccionId[0];
            A973RestriccionesFechaAlta = P00M92_A973RestriccionesFechaAlta[0];
            n973RestriccionesFechaAlta = P00M92_n973RestriccionesFechaAlta[0];
            A974RestriccionesEstado = P00M92_A974RestriccionesEstado[0];
            n974RestriccionesEstado = P00M92_n974RestriccionesEstado[0];
            A591ListaTipo = P00M92_A591ListaTipo[0];
            A593ListaEstado = P00M92_A593ListaEstado[0];
            n593ListaEstado = P00M92_n593ListaEstado[0];
            A592ListaNombre = P00M92_A592ListaNombre[0];
            A591ListaTipo = P00M92_A591ListaTipo[0];
            A593ListaEstado = P00M92_A593ListaEstado[0];
            n593ListaEstado = P00M92_n593ListaEstado[0];
            A167ProfesionalesApellidoPrimero = P00M92_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = P00M92_A166ProfesionalesPrimerNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionalesrestriccionwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A976ProfesionalesRestriccionId), 18, 0) , StringUtil.PadR( "%" + AV100Profesionalesrestriccionwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A120ProfesionalesId) , StringUtil.PadR( "%" + StringUtil.Upper( AV100Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A166ProfesionalesPrimerNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV100Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A167ProfesionalesApellidoPrimero) , StringUtil.PadR( "%" + StringUtil.Upper( AV100Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A590Listaid), 18, 0) , StringUtil.PadR( "%" + AV100Profesionalesrestriccionwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A592ListaNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV100Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV100Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "HAB") ==
            0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV100Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV100Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "PEN") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "proveedor", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV100Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "PROV") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "profesional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV100Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "PROF") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "administrativa", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV100Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "ADM") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "restriccion", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV100Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "RST") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV100Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A974RestriccionesEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV100Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A974RestriccionesEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV100Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A974RestriccionesEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A975RestriccionesObservacion) , StringUtil.PadR( "%" + StringUtil.Upper( AV100Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
            )
            {
               AV38ListaEstadoDescription = context.GetMessage( gxdomainestadoenum.getDescription(context,A593ListaEstado), "");
               AV39ListaTipoDescription = context.GetMessage( gxdomainlistatipoenum.getDescription(context,A591ListaTipo), "");
               AV40RestriccionesEstadoDescription = context.GetMessage( gxdomainestadoenum.getDescription(context,A974RestriccionesEstado), "");
               /* Execute user subroutine: 'BEFOREPRINTLINE' */
               S144 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               HM90( false, 35) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A976ProfesionalesRestriccionId), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 95, Gx_line+24, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A120ProfesionalesId, "")), 99, Gx_line+10, 164, Gx_line+24, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A166ProfesionalesPrimerNombre, "")), 168, Gx_line+10, 233, Gx_line+24, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A167ProfesionalesApellidoPrimero, "")), 237, Gx_line+10, 302, Gx_line+24, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A590Listaid), "ZZZZZZZZZZZZZZZZZ9")), 306, Gx_line+10, 371, Gx_line+24, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A592ListaNombre, "")), 375, Gx_line+10, 440, Gx_line+24, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38ListaEstadoDescription, "")), 444, Gx_line+10, 509, Gx_line+24, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39ListaTipoDescription, "")), 513, Gx_line+10, 578, Gx_line+24, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A973RestriccionesFechaAlta, "99/99/99 99:99"), 582, Gx_line+10, 647, Gx_line+24, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40RestriccionesEstadoDescription, "")), 651, Gx_line+10, 716, Gx_line+24, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A975RestriccionesObservacion, "")), 720, Gx_line+10, 787, Gx_line+24, 0+16, 0, 0, 0) ;
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
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S151( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV41Session.Get("ProfesionalesRestriccionWWGridState"), "") == 0 )
         {
            AV43GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ProfesionalesRestriccionWWGridState"), null, "", "");
         }
         else
         {
            AV43GridState.FromXml(AV41Session.Get("ProfesionalesRestriccionWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV43GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV43GridState.gxTpr_Ordereddsc;
         AV137GXV4 = 1;
         while ( AV137GXV4 <= AV43GridState.gxTpr_Filtervalues.Count )
         {
            AV44GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV43GridState.gxTpr_Filtervalues.Item(AV137GXV4));
            if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESRESTRICCIONID") == 0 )
            {
               AV45TFProfesionalesRestriccionId = (long)(Math.Round(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV46TFProfesionalesRestriccionId_To = (long)(Math.Round(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID") == 0 )
            {
               AV47TFProfesionalesId = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID_SEL") == 0 )
            {
               AV48TFProfesionalesId_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE") == 0 )
            {
               AV49TFProfesionalesPrimerNombre = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE_SEL") == 0 )
            {
               AV50TFProfesionalesPrimerNombre_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO") == 0 )
            {
               AV51TFProfesionalesApellidoPrimero = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO_SEL") == 0 )
            {
               AV52TFProfesionalesApellidoPrimero_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFLISTAID") == 0 )
            {
               AV53TFListaid = (long)(Math.Round(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV54TFListaid_To = (long)(Math.Round(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFLISTANOMBRE") == 0 )
            {
               AV55TFListaNombre = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFLISTANOMBRE_SEL") == 0 )
            {
               AV56TFListaNombre_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFLISTAESTADO_SEL") == 0 )
            {
               AV57TFListaEstado_SelsJson = AV44GridStateFilterValue.gxTpr_Value;
               AV60TFListaEstado_Sels.FromJSonString(AV57TFListaEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFLISTATIPO_SEL") == 0 )
            {
               AV61TFListaTipo_SelsJson = AV44GridStateFilterValue.gxTpr_Value;
               AV64TFListaTipo_Sels.FromJSonString(AV61TFListaTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFRESTRICCIONESFECHAALTA") == 0 )
            {
               AV65TFRestriccionesFechaAlta = context.localUtil.CToT( AV44GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV66TFRestriccionesFechaAlta_To = context.localUtil.CToT( AV44GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFRESTRICCIONESESTADO_SEL") == 0 )
            {
               AV67TFRestriccionesEstado_SelsJson = AV44GridStateFilterValue.gxTpr_Value;
               AV70TFRestriccionesEstado_Sels.FromJSonString(AV67TFRestriccionesEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFRESTRICCIONESOBSERVACION") == 0 )
            {
               AV71TFRestriccionesObservacion = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFRESTRICCIONESOBSERVACION_SEL") == 0 )
            {
               AV72TFRestriccionesObservacion_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            AV137GXV4 = (int)(AV137GXV4+1);
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

      protected void HM90( bool bFoot ,
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
                  AV89PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV86DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+39, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV89PageInfo, "")), 30, Gx_line+15, 409, Gx_line+29, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV86DateInfo, "")), 409, Gx_line+15, 789, Gx_line+29, 2, 0, 0, 0) ;
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
               AV84AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV90Phone = "+1 550 8923";
               AV88Mail = "info@mail.com";
               AV92Website = "http://www.web.com";
               AV81AddressLine1 = "French Boulevard 2859";
               AV82AddressLine2 = "Downtown";
               AV83AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+107, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV84AppName, "")), 30, Gx_line+30, 283, Gx_line+44, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV91Title, "")), 30, Gx_line+44, 283, Gx_line+77, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV90Phone, "")), 283, Gx_line+30, 536, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV88Mail, "")), 283, Gx_line+45, 536, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV92Website, "")), 283, Gx_line+60, 536, Gx_line+77, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV81AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82AddressLine2, "")), 536, Gx_line+45, 789, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV83AddressLine3, "")), 536, Gx_line+60, 789, Gx_line+77, 2, 0, 0, 0) ;
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
         AV93Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV91Title = "";
         AV13FilterFullText = "";
         AV43GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV37GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV18RestriccionesFechaAlta1 = (DateTime)(DateTime.MinValue);
         AV19RestriccionesFechaAlta_To1 = (DateTime)(DateTime.MinValue);
         AV16FixedValueOperatorDsc = "";
         AV17FixedValueOperatorValue = "";
         AV20FilterRestriccionesFechaAltaDescription = "";
         AV21RestriccionesFechaAlta = (DateTime)(DateTime.MinValue);
         AV22ListaNombre1 = "";
         AV23FilterListaNombreDescription = "";
         AV24ListaNombre = "";
         AV26DynamicFiltersSelector2 = "";
         AV28RestriccionesFechaAlta2 = (DateTime)(DateTime.MinValue);
         AV29RestriccionesFechaAlta_To2 = (DateTime)(DateTime.MinValue);
         AV30ListaNombre2 = "";
         AV32DynamicFiltersSelector3 = "";
         AV34RestriccionesFechaAlta3 = (DateTime)(DateTime.MinValue);
         AV35RestriccionesFechaAlta_To3 = (DateTime)(DateTime.MinValue);
         AV36ListaNombre3 = "";
         AV73TFProfesionalesRestriccionId_To_Description = "";
         AV48TFProfesionalesId_Sel = "";
         AV47TFProfesionalesId = "";
         AV50TFProfesionalesPrimerNombre_Sel = "";
         AV49TFProfesionalesPrimerNombre = "";
         AV52TFProfesionalesApellidoPrimero_Sel = "";
         AV51TFProfesionalesApellidoPrimero = "";
         AV74TFListaid_To_Description = "";
         AV56TFListaNombre_Sel = "";
         AV55TFListaNombre = "";
         AV60TFListaEstado_Sels = new GxSimpleCollection<string>();
         AV57TFListaEstado_SelsJson = "";
         AV59TFListaEstado_Sel = "";
         AV58TFListaEstado_SelDscs = "";
         AV75FilterTFListaEstado_SelValueDescription = "";
         AV64TFListaTipo_Sels = new GxSimpleCollection<string>();
         AV61TFListaTipo_SelsJson = "";
         AV63TFListaTipo_Sel = "";
         AV62TFListaTipo_SelDscs = "";
         AV76FilterTFListaTipo_SelValueDescription = "";
         AV65TFRestriccionesFechaAlta = (DateTime)(DateTime.MinValue);
         AV66TFRestriccionesFechaAlta_To = (DateTime)(DateTime.MinValue);
         AV77TFRestriccionesFechaAlta_To_Description = "";
         AV70TFRestriccionesEstado_Sels = new GxSimpleCollection<string>();
         AV67TFRestriccionesEstado_SelsJson = "";
         AV69TFRestriccionesEstado_Sel = "";
         AV68TFRestriccionesEstado_SelDscs = "";
         AV78FilterTFRestriccionesEstado_SelValueDescription = "";
         AV72TFRestriccionesObservacion_Sel = "";
         AV71TFRestriccionesObservacion = "";
         AV100Profesionalesrestriccionwwds_1_filterfulltext = "";
         AV101Profesionalesrestriccionwwds_2_dynamicfiltersselector1 = "";
         AV103Profesionalesrestriccionwwds_4_restriccionesfechaalta1 = (DateTime)(DateTime.MinValue);
         AV104Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 = (DateTime)(DateTime.MinValue);
         AV105Profesionalesrestriccionwwds_6_listanombre1 = "";
         AV107Profesionalesrestriccionwwds_8_dynamicfiltersselector2 = "";
         AV109Profesionalesrestriccionwwds_10_restriccionesfechaalta2 = (DateTime)(DateTime.MinValue);
         AV110Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 = (DateTime)(DateTime.MinValue);
         AV111Profesionalesrestriccionwwds_12_listanombre2 = "";
         AV113Profesionalesrestriccionwwds_14_dynamicfiltersselector3 = "";
         AV115Profesionalesrestriccionwwds_16_restriccionesfechaalta3 = (DateTime)(DateTime.MinValue);
         AV116Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 = (DateTime)(DateTime.MinValue);
         AV117Profesionalesrestriccionwwds_18_listanombre3 = "";
         AV120Profesionalesrestriccionwwds_21_tfprofesionalesid = "";
         AV121Profesionalesrestriccionwwds_22_tfprofesionalesid_sel = "";
         AV122Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre = "";
         AV123Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel = "";
         AV124Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero = "";
         AV125Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel = "";
         AV128Profesionalesrestriccionwwds_29_tflistanombre = "";
         AV129Profesionalesrestriccionwwds_30_tflistanombre_sel = "";
         AV130Profesionalesrestriccionwwds_31_tflistaestado_sels = new GxSimpleCollection<string>();
         AV131Profesionalesrestriccionwwds_32_tflistatipo_sels = new GxSimpleCollection<string>();
         AV132Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta = (DateTime)(DateTime.MinValue);
         AV133Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to = (DateTime)(DateTime.MinValue);
         AV134Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels = new GxSimpleCollection<string>();
         AV135Profesionalesrestriccionwwds_36_tfrestriccionesobservacion = "";
         AV136Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel = "";
         lV100Profesionalesrestriccionwwds_1_filterfulltext = "";
         lV105Profesionalesrestriccionwwds_6_listanombre1 = "";
         lV111Profesionalesrestriccionwwds_12_listanombre2 = "";
         lV117Profesionalesrestriccionwwds_18_listanombre3 = "";
         lV120Profesionalesrestriccionwwds_21_tfprofesionalesid = "";
         lV122Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre = "";
         lV124Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero = "";
         lV128Profesionalesrestriccionwwds_29_tflistanombre = "";
         lV135Profesionalesrestriccionwwds_36_tfrestriccionesobservacion = "";
         A593ListaEstado = "";
         A591ListaTipo = "";
         A974RestriccionesEstado = "";
         A973RestriccionesFechaAlta = (DateTime)(DateTime.MinValue);
         A592ListaNombre = "";
         A120ProfesionalesId = "";
         A166ProfesionalesPrimerNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A975RestriccionesObservacion = "";
         P00M92_A975RestriccionesObservacion = new string[] {""} ;
         P00M92_n975RestriccionesObservacion = new bool[] {false} ;
         P00M92_A592ListaNombre = new string[] {""} ;
         P00M92_A590Listaid = new long[1] ;
         P00M92_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00M92_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00M92_A120ProfesionalesId = new string[] {""} ;
         P00M92_A976ProfesionalesRestriccionId = new long[1] ;
         P00M92_A973RestriccionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00M92_n973RestriccionesFechaAlta = new bool[] {false} ;
         P00M92_A974RestriccionesEstado = new string[] {""} ;
         P00M92_n974RestriccionesEstado = new bool[] {false} ;
         P00M92_A591ListaTipo = new string[] {""} ;
         P00M92_A593ListaEstado = new string[] {""} ;
         P00M92_n593ListaEstado = new bool[] {false} ;
         AV38ListaEstadoDescription = "";
         AV39ListaTipoDescription = "";
         AV40RestriccionesEstadoDescription = "";
         AV41Session = context.GetSession();
         AV44GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV89PageInfo = "";
         AV86DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV84AppName = "";
         AV90Phone = "";
         AV88Mail = "";
         AV92Website = "";
         AV81AddressLine1 = "";
         AV82AddressLine2 = "";
         AV83AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.profesionalesrestriccionwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00M92_A975RestriccionesObservacion, P00M92_n975RestriccionesObservacion, P00M92_A592ListaNombre, P00M92_A590Listaid, P00M92_A167ProfesionalesApellidoPrimero, P00M92_A166ProfesionalesPrimerNombre, P00M92_A120ProfesionalesId, P00M92_A976ProfesionalesRestriccionId, P00M92_A973RestriccionesFechaAlta, P00M92_n973RestriccionesFechaAlta,
               P00M92_A974RestriccionesEstado, P00M92_n974RestriccionesEstado, P00M92_A591ListaTipo, P00M92_A593ListaEstado, P00M92_n593ListaEstado
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV93Pgmname = "ProfesionalesRestriccionWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV93Pgmname = "ProfesionalesRestriccionWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV15DynamicFiltersOperator1 ;
      private short AV27DynamicFiltersOperator2 ;
      private short AV33DynamicFiltersOperator3 ;
      private short AV102Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 ;
      private short AV108Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 ;
      private short AV114Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV96GXV1 ;
      private int AV97GXV2 ;
      private int AV98GXV3 ;
      private int AV130Profesionalesrestriccionwwds_31_tflistaestado_sels_Count ;
      private int AV131Profesionalesrestriccionwwds_32_tflistatipo_sels_Count ;
      private int AV134Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels_Count ;
      private int AV137GXV4 ;
      private long AV45TFProfesionalesRestriccionId ;
      private long AV46TFProfesionalesRestriccionId_To ;
      private long AV53TFListaid ;
      private long AV54TFListaid_To ;
      private long AV80i ;
      private long AV118Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid ;
      private long AV119Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to ;
      private long AV126Profesionalesrestriccionwwds_27_tflistaid ;
      private long AV127Profesionalesrestriccionwwds_28_tflistaid_to ;
      private long A976ProfesionalesRestriccionId ;
      private long A590Listaid ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV93Pgmname ;
      private string GXEncryptionTmp ;
      private string AV22ListaNombre1 ;
      private string AV24ListaNombre ;
      private string AV30ListaNombre2 ;
      private string AV36ListaNombre3 ;
      private string AV48TFProfesionalesId_Sel ;
      private string AV47TFProfesionalesId ;
      private string AV50TFProfesionalesPrimerNombre_Sel ;
      private string AV49TFProfesionalesPrimerNombre ;
      private string AV52TFProfesionalesApellidoPrimero_Sel ;
      private string AV51TFProfesionalesApellidoPrimero ;
      private string AV56TFListaNombre_Sel ;
      private string AV55TFListaNombre ;
      private string AV59TFListaEstado_Sel ;
      private string AV63TFListaTipo_Sel ;
      private string AV69TFRestriccionesEstado_Sel ;
      private string AV105Profesionalesrestriccionwwds_6_listanombre1 ;
      private string AV111Profesionalesrestriccionwwds_12_listanombre2 ;
      private string AV117Profesionalesrestriccionwwds_18_listanombre3 ;
      private string AV120Profesionalesrestriccionwwds_21_tfprofesionalesid ;
      private string AV121Profesionalesrestriccionwwds_22_tfprofesionalesid_sel ;
      private string AV122Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre ;
      private string AV123Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel ;
      private string AV124Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero ;
      private string AV125Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel ;
      private string AV128Profesionalesrestriccionwwds_29_tflistanombre ;
      private string AV129Profesionalesrestriccionwwds_30_tflistanombre_sel ;
      private string lV105Profesionalesrestriccionwwds_6_listanombre1 ;
      private string lV111Profesionalesrestriccionwwds_12_listanombre2 ;
      private string lV117Profesionalesrestriccionwwds_18_listanombre3 ;
      private string lV120Profesionalesrestriccionwwds_21_tfprofesionalesid ;
      private string lV122Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre ;
      private string lV124Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero ;
      private string lV128Profesionalesrestriccionwwds_29_tflistanombre ;
      private string A593ListaEstado ;
      private string A591ListaTipo ;
      private string A974RestriccionesEstado ;
      private string A592ListaNombre ;
      private string A120ProfesionalesId ;
      private string A166ProfesionalesPrimerNombre ;
      private string A167ProfesionalesApellidoPrimero ;
      private DateTime AV18RestriccionesFechaAlta1 ;
      private DateTime AV19RestriccionesFechaAlta_To1 ;
      private DateTime AV21RestriccionesFechaAlta ;
      private DateTime AV28RestriccionesFechaAlta2 ;
      private DateTime AV29RestriccionesFechaAlta_To2 ;
      private DateTime AV34RestriccionesFechaAlta3 ;
      private DateTime AV35RestriccionesFechaAlta_To3 ;
      private DateTime AV65TFRestriccionesFechaAlta ;
      private DateTime AV66TFRestriccionesFechaAlta_To ;
      private DateTime AV103Profesionalesrestriccionwwds_4_restriccionesfechaalta1 ;
      private DateTime AV104Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 ;
      private DateTime AV109Profesionalesrestriccionwwds_10_restriccionesfechaalta2 ;
      private DateTime AV110Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 ;
      private DateTime AV115Profesionalesrestriccionwwds_16_restriccionesfechaalta3 ;
      private DateTime AV116Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 ;
      private DateTime AV132Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta ;
      private DateTime AV133Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to ;
      private DateTime A973RestriccionesFechaAlta ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV25DynamicFiltersEnabled2 ;
      private bool AV31DynamicFiltersEnabled3 ;
      private bool AV79TempBoolean ;
      private bool AV106Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 ;
      private bool AV112Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private bool n975RestriccionesObservacion ;
      private bool n973RestriccionesFechaAlta ;
      private bool n974RestriccionesEstado ;
      private bool n593ListaEstado ;
      private string AV57TFListaEstado_SelsJson ;
      private string AV61TFListaTipo_SelsJson ;
      private string AV67TFRestriccionesEstado_SelsJson ;
      private string AV91Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV16FixedValueOperatorDsc ;
      private string AV17FixedValueOperatorValue ;
      private string AV20FilterRestriccionesFechaAltaDescription ;
      private string AV23FilterListaNombreDescription ;
      private string AV26DynamicFiltersSelector2 ;
      private string AV32DynamicFiltersSelector3 ;
      private string AV73TFProfesionalesRestriccionId_To_Description ;
      private string AV74TFListaid_To_Description ;
      private string AV58TFListaEstado_SelDscs ;
      private string AV75FilterTFListaEstado_SelValueDescription ;
      private string AV62TFListaTipo_SelDscs ;
      private string AV76FilterTFListaTipo_SelValueDescription ;
      private string AV77TFRestriccionesFechaAlta_To_Description ;
      private string AV68TFRestriccionesEstado_SelDscs ;
      private string AV78FilterTFRestriccionesEstado_SelValueDescription ;
      private string AV72TFRestriccionesObservacion_Sel ;
      private string AV71TFRestriccionesObservacion ;
      private string AV100Profesionalesrestriccionwwds_1_filterfulltext ;
      private string AV101Profesionalesrestriccionwwds_2_dynamicfiltersselector1 ;
      private string AV107Profesionalesrestriccionwwds_8_dynamicfiltersselector2 ;
      private string AV113Profesionalesrestriccionwwds_14_dynamicfiltersselector3 ;
      private string AV135Profesionalesrestriccionwwds_36_tfrestriccionesobservacion ;
      private string AV136Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel ;
      private string lV100Profesionalesrestriccionwwds_1_filterfulltext ;
      private string lV135Profesionalesrestriccionwwds_36_tfrestriccionesobservacion ;
      private string A975RestriccionesObservacion ;
      private string AV38ListaEstadoDescription ;
      private string AV39ListaTipoDescription ;
      private string AV40RestriccionesEstadoDescription ;
      private string AV89PageInfo ;
      private string AV86DateInfo ;
      private string AV84AppName ;
      private string AV90Phone ;
      private string AV88Mail ;
      private string AV92Website ;
      private string AV81AddressLine1 ;
      private string AV82AddressLine2 ;
      private string AV83AddressLine3 ;
      private IGxSession AV41Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV43GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV37GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV60TFListaEstado_Sels ;
      private GxSimpleCollection<string> AV64TFListaTipo_Sels ;
      private GxSimpleCollection<string> AV70TFRestriccionesEstado_Sels ;
      private GxSimpleCollection<string> AV130Profesionalesrestriccionwwds_31_tflistaestado_sels ;
      private GxSimpleCollection<string> AV131Profesionalesrestriccionwwds_32_tflistatipo_sels ;
      private GxSimpleCollection<string> AV134Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00M92_A975RestriccionesObservacion ;
      private bool[] P00M92_n975RestriccionesObservacion ;
      private string[] P00M92_A592ListaNombre ;
      private long[] P00M92_A590Listaid ;
      private string[] P00M92_A167ProfesionalesApellidoPrimero ;
      private string[] P00M92_A166ProfesionalesPrimerNombre ;
      private string[] P00M92_A120ProfesionalesId ;
      private long[] P00M92_A976ProfesionalesRestriccionId ;
      private DateTime[] P00M92_A973RestriccionesFechaAlta ;
      private bool[] P00M92_n973RestriccionesFechaAlta ;
      private string[] P00M92_A974RestriccionesEstado ;
      private bool[] P00M92_n974RestriccionesEstado ;
      private string[] P00M92_A591ListaTipo ;
      private string[] P00M92_A593ListaEstado ;
      private bool[] P00M92_n593ListaEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV44GridStateFilterValue ;
   }

   public class profesionalesrestriccionwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00M92( IGxContext context ,
                                             string A593ListaEstado ,
                                             GxSimpleCollection<string> AV130Profesionalesrestriccionwwds_31_tflistaestado_sels ,
                                             string A591ListaTipo ,
                                             GxSimpleCollection<string> AV131Profesionalesrestriccionwwds_32_tflistatipo_sels ,
                                             string A974RestriccionesEstado ,
                                             GxSimpleCollection<string> AV134Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels ,
                                             string AV101Profesionalesrestriccionwwds_2_dynamicfiltersselector1 ,
                                             short AV102Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 ,
                                             DateTime AV103Profesionalesrestriccionwwds_4_restriccionesfechaalta1 ,
                                             DateTime AV104Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 ,
                                             string AV105Profesionalesrestriccionwwds_6_listanombre1 ,
                                             bool AV106Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 ,
                                             string AV107Profesionalesrestriccionwwds_8_dynamicfiltersselector2 ,
                                             short AV108Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 ,
                                             DateTime AV109Profesionalesrestriccionwwds_10_restriccionesfechaalta2 ,
                                             DateTime AV110Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 ,
                                             string AV111Profesionalesrestriccionwwds_12_listanombre2 ,
                                             bool AV112Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 ,
                                             string AV113Profesionalesrestriccionwwds_14_dynamicfiltersselector3 ,
                                             short AV114Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 ,
                                             DateTime AV115Profesionalesrestriccionwwds_16_restriccionesfechaalta3 ,
                                             DateTime AV116Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 ,
                                             string AV117Profesionalesrestriccionwwds_18_listanombre3 ,
                                             long AV118Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid ,
                                             long AV119Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to ,
                                             string AV121Profesionalesrestriccionwwds_22_tfprofesionalesid_sel ,
                                             string AV120Profesionalesrestriccionwwds_21_tfprofesionalesid ,
                                             string AV123Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel ,
                                             string AV122Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre ,
                                             string AV125Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel ,
                                             string AV124Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero ,
                                             long AV126Profesionalesrestriccionwwds_27_tflistaid ,
                                             long AV127Profesionalesrestriccionwwds_28_tflistaid_to ,
                                             string AV129Profesionalesrestriccionwwds_30_tflistanombre_sel ,
                                             string AV128Profesionalesrestriccionwwds_29_tflistanombre ,
                                             int AV130Profesionalesrestriccionwwds_31_tflistaestado_sels_Count ,
                                             int AV131Profesionalesrestriccionwwds_32_tflistatipo_sels_Count ,
                                             DateTime AV132Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta ,
                                             DateTime AV133Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to ,
                                             int AV134Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels_Count ,
                                             string AV136Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel ,
                                             string AV135Profesionalesrestriccionwwds_36_tfrestriccionesobservacion ,
                                             DateTime A973RestriccionesFechaAlta ,
                                             string A592ListaNombre ,
                                             long A976ProfesionalesRestriccionId ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             long A590Listaid ,
                                             string A975RestriccionesObservacion ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             string AV100Profesionalesrestriccionwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[34];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[RestriccionesObservacion], T2.[ListaNombre], T1.[Listaid], T3.[ProfesionalesApellidoPrimero], T3.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T1.[ProfesionalesRestriccionId], T1.[RestriccionesFechaAlta], T1.[RestriccionesEstado], T2.[ListaTipo], T2.[ListaEstado] FROM (([ProfesionalesRestriccion] T1 INNER JOIN [Lista] T2 ON T2.[Listaid] = T1.[Listaid]) INNER JOIN [Profesionales] T3 ON T3.[ProfesionalesId] = T1.[ProfesionalesId])";
         if ( ( StringUtil.StrCmp(AV101Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV102Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV103Profesionalesrestriccionwwds_4_restriccionesfechaalta1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV103Profesionalesrestriccionwwds_4_restriccionesfechaalta1)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV101Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( ( AV102Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 1 ) || ( AV102Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 2 ) || ( AV102Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 3 ) ) && ( ! (DateTime.MinValue==AV103Profesionalesrestriccionwwds_4_restriccionesfechaalta1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV103Profesionalesrestriccionwwds_4_restriccionesfechaalta1)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV101Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV102Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV104Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV104Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV101Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV102Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV104Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV104Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV101Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "LISTANOMBRE") == 0 ) && ( AV102Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Profesionalesrestriccionwwds_6_listanombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like UPPER(@lV105Profesionalesrestriccionwwds_6_listanombre1))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV101Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "LISTANOMBRE") == 0 ) && ( AV102Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Profesionalesrestriccionwwds_6_listanombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like '%' + UPPER(@lV105Profesionalesrestriccionwwds_6_listanombre1))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV106Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV108Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV109Profesionalesrestriccionwwds_10_restriccionesfechaalta2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV109Profesionalesrestriccionwwds_10_restriccionesfechaalta2)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV106Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( ( AV108Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 1 ) || ( AV108Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 2 ) || ( AV108Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 3 ) ) && ( ! (DateTime.MinValue==AV109Profesionalesrestriccionwwds_10_restriccionesfechaalta2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV109Profesionalesrestriccionwwds_10_restriccionesfechaalta2)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( AV106Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV108Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV110Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV110Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( AV106Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV108Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV110Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV110Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( AV106Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "LISTANOMBRE") == 0 ) && ( AV108Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Profesionalesrestriccionwwds_12_listanombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like UPPER(@lV111Profesionalesrestriccionwwds_12_listanombre2))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( AV106Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV107Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "LISTANOMBRE") == 0 ) && ( AV108Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Profesionalesrestriccionwwds_12_listanombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like '%' + UPPER(@lV111Profesionalesrestriccionwwds_12_listanombre2))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( AV112Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV113Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV114Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV115Profesionalesrestriccionwwds_16_restriccionesfechaalta3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV115Profesionalesrestriccionwwds_16_restriccionesfechaalta3)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( AV112Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV113Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( ( AV114Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 1 ) || ( AV114Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 2 ) || ( AV114Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 3 ) ) && ( ! (DateTime.MinValue==AV115Profesionalesrestriccionwwds_16_restriccionesfechaalta3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV115Profesionalesrestriccionwwds_16_restriccionesfechaalta3)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( AV112Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV113Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV114Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV116Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV116Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( AV112Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV113Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV114Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV116Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV116Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( AV112Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV113Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "LISTANOMBRE") == 0 ) && ( AV114Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Profesionalesrestriccionwwds_18_listanombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like UPPER(@lV117Profesionalesrestriccionwwds_18_listanombre3))");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( AV112Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV113Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "LISTANOMBRE") == 0 ) && ( AV114Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Profesionalesrestriccionwwds_18_listanombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like '%' + UPPER(@lV117Profesionalesrestriccionwwds_18_listanombre3))");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( ! (0==AV118Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesRestriccionId] >= @AV118Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid)");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( ! (0==AV119Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesRestriccionId] <= @AV119Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to)");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV121Profesionalesrestriccionwwds_22_tfprofesionalesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Profesionalesrestriccionwwds_21_tfprofesionalesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV120Profesionalesrestriccionwwds_21_tfprofesionalesid))");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Profesionalesrestriccionwwds_22_tfprofesionalesid_sel)) && ! ( StringUtil.StrCmp(AV121Profesionalesrestriccionwwds_22_tfprofesionalesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV121Profesionalesrestriccionwwds_22_tfprofesionalesid_sel)");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( StringUtil.StrCmp(AV121Profesionalesrestriccionwwds_22_tfprofesionalesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV123Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProfesionalesPrimerNombre]) like UPPER(@lV122Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre))");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel)) && ! ( StringUtil.StrCmp(AV123Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProfesionalesPrimerNombre] = @AV123Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel)");
         }
         else
         {
            GXv_int2[23] = 1;
         }
         if ( StringUtil.StrCmp(AV123Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV125Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProfesionalesApellidoPrimero]) like UPPER(@lV124Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero))");
         }
         else
         {
            GXv_int2[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel)) && ! ( StringUtil.StrCmp(AV125Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProfesionalesApellidoPrimero] = @AV125Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel)");
         }
         else
         {
            GXv_int2[25] = 1;
         }
         if ( StringUtil.StrCmp(AV125Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( ! (0==AV126Profesionalesrestriccionwwds_27_tflistaid) )
         {
            AddWhere(sWhereString, "(T1.[Listaid] >= @AV126Profesionalesrestriccionwwds_27_tflistaid)");
         }
         else
         {
            GXv_int2[26] = 1;
         }
         if ( ! (0==AV127Profesionalesrestriccionwwds_28_tflistaid_to) )
         {
            AddWhere(sWhereString, "(T1.[Listaid] <= @AV127Profesionalesrestriccionwwds_28_tflistaid_to)");
         }
         else
         {
            GXv_int2[27] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV129Profesionalesrestriccionwwds_30_tflistanombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Profesionalesrestriccionwwds_29_tflistanombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like UPPER(@lV128Profesionalesrestriccionwwds_29_tflistanombre))");
         }
         else
         {
            GXv_int2[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Profesionalesrestriccionwwds_30_tflistanombre_sel)) && ! ( StringUtil.StrCmp(AV129Profesionalesrestriccionwwds_30_tflistanombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ListaNombre] = @AV129Profesionalesrestriccionwwds_30_tflistanombre_sel)");
         }
         else
         {
            GXv_int2[29] = 1;
         }
         if ( StringUtil.StrCmp(AV129Profesionalesrestriccionwwds_30_tflistanombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ListaNombre] = ''))");
         }
         if ( AV130Profesionalesrestriccionwwds_31_tflistaestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV130Profesionalesrestriccionwwds_31_tflistaestado_sels, "T2.[ListaEstado] IN (", ")")+")");
         }
         if ( AV131Profesionalesrestriccionwwds_32_tflistatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV131Profesionalesrestriccionwwds_32_tflistatipo_sels, "T2.[ListaTipo] IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV132Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV132Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta)");
         }
         else
         {
            GXv_int2[30] = 1;
         }
         if ( ! (DateTime.MinValue==AV133Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV133Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to)");
         }
         else
         {
            GXv_int2[31] = 1;
         }
         if ( AV134Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV134Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels, "T1.[RestriccionesEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV136Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Profesionalesrestriccionwwds_36_tfrestriccionesobservacion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[RestriccionesObservacion]) like UPPER(@lV135Profesionalesrestriccionwwds_36_tfrestriccionesobservacion))");
         }
         else
         {
            GXv_int2[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel)) && ! ( StringUtil.StrCmp(AV136Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesObservacion] = @AV136Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel)");
         }
         else
         {
            GXv_int2[33] = 1;
         }
         if ( StringUtil.StrCmp(AV136Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesObservacion] IS NULL or (T1.[RestriccionesObservacion] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RestriccionesFechaAlta]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RestriccionesFechaAlta] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesRestriccionId]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesRestriccionId] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesId]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesId] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[ProfesionalesPrimerNombre]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[ProfesionalesPrimerNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[ProfesionalesApellidoPrimero]";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[ProfesionalesApellidoPrimero] DESC";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[Listaid]";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[Listaid] DESC";
         }
         else if ( ( AV11OrderedBy == 7 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ListaNombre]";
         }
         else if ( ( AV11OrderedBy == 7 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ListaNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 8 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ListaEstado]";
         }
         else if ( ( AV11OrderedBy == 8 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ListaEstado] DESC";
         }
         else if ( ( AV11OrderedBy == 9 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ListaTipo]";
         }
         else if ( ( AV11OrderedBy == 9 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ListaTipo] DESC";
         }
         else if ( ( AV11OrderedBy == 10 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RestriccionesEstado]";
         }
         else if ( ( AV11OrderedBy == 10 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RestriccionesEstado] DESC";
         }
         else if ( ( AV11OrderedBy == 11 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[RestriccionesObservacion]";
         }
         else if ( ( AV11OrderedBy == 11 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[RestriccionesObservacion] DESC";
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
                     return conditional_P00M92(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (string)dynConstraints[16] , (bool)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (long)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (long)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (int)dynConstraints[35] , (int)dynConstraints[36] , (DateTime)dynConstraints[37] , (DateTime)dynConstraints[38] , (int)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (DateTime)dynConstraints[42] , (string)dynConstraints[43] , (long)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (long)dynConstraints[48] , (string)dynConstraints[49] , (short)dynConstraints[50] , (bool)dynConstraints[51] , (string)dynConstraints[52] );
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
          Object[] prmP00M92;
          prmP00M92 = new Object[] {
          new ParDef("@AV103Profesionalesrestriccionwwds_4_restriccionesfechaalta1",GXType.DateTime,8,5) ,
          new ParDef("@AV103Profesionalesrestriccionwwds_4_restriccionesfechaalta1",GXType.DateTime,8,5) ,
          new ParDef("@AV104Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1",GXType.DateTime,8,5) ,
          new ParDef("@AV104Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1",GXType.DateTime,8,5) ,
          new ParDef("@lV105Profesionalesrestriccionwwds_6_listanombre1",GXType.Char,80,0) ,
          new ParDef("@lV105Profesionalesrestriccionwwds_6_listanombre1",GXType.Char,80,0) ,
          new ParDef("@AV109Profesionalesrestriccionwwds_10_restriccionesfechaalta2",GXType.DateTime,8,5) ,
          new ParDef("@AV109Profesionalesrestriccionwwds_10_restriccionesfechaalta2",GXType.DateTime,8,5) ,
          new ParDef("@AV110Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2",GXType.DateTime,8,5) ,
          new ParDef("@AV110Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2",GXType.DateTime,8,5) ,
          new ParDef("@lV111Profesionalesrestriccionwwds_12_listanombre2",GXType.Char,80,0) ,
          new ParDef("@lV111Profesionalesrestriccionwwds_12_listanombre2",GXType.Char,80,0) ,
          new ParDef("@AV115Profesionalesrestriccionwwds_16_restriccionesfechaalta3",GXType.DateTime,8,5) ,
          new ParDef("@AV115Profesionalesrestriccionwwds_16_restriccionesfechaalta3",GXType.DateTime,8,5) ,
          new ParDef("@AV116Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3",GXType.DateTime,8,5) ,
          new ParDef("@AV116Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3",GXType.DateTime,8,5) ,
          new ParDef("@lV117Profesionalesrestriccionwwds_18_listanombre3",GXType.Char,80,0) ,
          new ParDef("@lV117Profesionalesrestriccionwwds_18_listanombre3",GXType.Char,80,0) ,
          new ParDef("@AV118Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid",GXType.Decimal,18,0) ,
          new ParDef("@AV119Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV120Profesionalesrestriccionwwds_21_tfprofesionalesid",GXType.Char,20,0) ,
          new ParDef("@AV121Profesionalesrestriccionwwds_22_tfprofesionalesid_sel",GXType.Char,20,0) ,
          new ParDef("@lV122Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre",GXType.Char,30,0) ,
          new ParDef("@AV123Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV124Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero",GXType.Char,30,0) ,
          new ParDef("@AV125Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel",GXType.NChar,30,0) ,
          new ParDef("@AV126Profesionalesrestriccionwwds_27_tflistaid",GXType.Decimal,18,0) ,
          new ParDef("@AV127Profesionalesrestriccionwwds_28_tflistaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV128Profesionalesrestriccionwwds_29_tflistanombre",GXType.Char,80,0) ,
          new ParDef("@AV129Profesionalesrestriccionwwds_30_tflistanombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV132Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta",GXType.DateTime,8,5) ,
          new ParDef("@AV133Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to",GXType.DateTime,8,5) ,
          new ParDef("@lV135Profesionalesrestriccionwwds_36_tfrestriccionesobservacion",GXType.VarChar,120,0) ,
          new ParDef("@AV136Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel",GXType.NVarChar,120,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00M92", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00M92,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 80);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 30);
                ((string[]) buf[5])[0] = rslt.getString(5, 30);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((long[]) buf[7])[0] = rslt.getLong(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 3);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((string[]) buf[12])[0] = rslt.getString(10, 4);
                ((string[]) buf[13])[0] = rslt.getString(11, 3);
                ((bool[]) buf[14])[0] = rslt.wasNull(11);
                return;
       }
    }

 }

}
