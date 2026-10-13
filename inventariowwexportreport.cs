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
   public class inventariowwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public inventariowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public inventariowwexportreport( IGxContext context )
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
         setOutputFileName("InventarioWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWInventario", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV89Pgmname));
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
               AV70Title = context.GetMessage( "Lista de Inventario", "");
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
            H440( true, 0) ;
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
            H440( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( AV36GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV36GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV32GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "RUBROSCOSTO") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV16RubrosCosto1 = NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, ".");
               if ( ! (Convert.ToDecimal(0)==AV16RubrosCosto1) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterRubrosCostoDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Costo Base", ""), "<", "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterRubrosCostoDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Costo Base", ""), "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 2 )
                  {
                     AV17FilterRubrosCostoDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Costo Base", ""), ">", "", "", "", "", "", "", "");
                  }
                  AV18RubrosCosto = AV16RubrosCosto1;
                  H440( false, 19) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterRubrosCostoDescription, "")), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV18RubrosCosto, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
               }
            }
            else if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "RUBROSNOMBRE") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV19RubrosNombre1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19RubrosNombre1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV20FilterRubrosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV20FilterRubrosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV21RubrosNombre = AV19RubrosNombre1;
                  H440( false, 19) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterRubrosNombreDescription, "")), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21RubrosNombre, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
               }
            }
            else if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "TEXTOSTIPO") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV72TextosTipo1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72TextosTipo1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV73FilterTextosTipoDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Tipo", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV73FilterTextosTipoDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Tipo", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV74TextosTipo = AV72TextosTipo1;
                  H440( false, 19) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73FilterTextosTipoDescription, "")), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74TextosTipo, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
               }
            }
            if ( AV36GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV36GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "RUBROSCOSTO") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV25RubrosCosto2 = NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, ".");
                  if ( ! (Convert.ToDecimal(0)==AV25RubrosCosto2) )
                  {
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterRubrosCostoDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Costo Base", ""), "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterRubrosCostoDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Costo Base", ""), "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 2 )
                     {
                        AV17FilterRubrosCostoDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Costo Base", ""), ">", "", "", "", "", "", "", "");
                     }
                     AV18RubrosCosto = AV25RubrosCosto2;
                     H440( false, 19) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterRubrosCostoDescription, "")), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV18RubrosCosto, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                  }
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "RUBROSNOMBRE") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV26RubrosNombre2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26RubrosNombre2)) )
                  {
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV20FilterRubrosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV20FilterRubrosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV21RubrosNombre = AV26RubrosNombre2;
                     H440( false, 19) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterRubrosNombreDescription, "")), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21RubrosNombre, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                  }
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "TEXTOSTIPO") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV75TextosTipo2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75TextosTipo2)) )
                  {
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV73FilterTextosTipoDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Tipo", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV73FilterTextosTipoDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Tipo", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV74TextosTipo = AV75TextosTipo2;
                     H440( false, 19) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73FilterTextosTipoDescription, "")), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74TextosTipo, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                  }
               }
               if ( AV36GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV36GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "RUBROSCOSTO") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV30RubrosCosto3 = NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, ".");
                     if ( ! (Convert.ToDecimal(0)==AV30RubrosCosto3) )
                     {
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterRubrosCostoDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Costo Base", ""), "<", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterRubrosCostoDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Costo Base", ""), "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 2 )
                        {
                           AV17FilterRubrosCostoDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Costo Base", ""), ">", "", "", "", "", "", "", "");
                        }
                        AV18RubrosCosto = AV30RubrosCosto3;
                        H440( false, 19) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterRubrosCostoDescription, "")), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV18RubrosCosto, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "RUBROSNOMBRE") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV31RubrosNombre3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31RubrosNombre3)) )
                     {
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV20FilterRubrosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV20FilterRubrosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV21RubrosNombre = AV31RubrosNombre3;
                        H440( false, 19) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterRubrosNombreDescription, "")), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21RubrosNombre, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "TEXTOSTIPO") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV76TextosTipo3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76TextosTipo3)) )
                     {
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV73FilterTextosTipoDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Tipo", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV73FilterTextosTipoDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Tipo", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV74TextosTipo = AV76TextosTipo3;
                        H440( false, 19) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73FilterTextosTipoDescription, "")), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74TextosTipo, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV38TFRubrosId) && (0==AV39TFRubrosId_To) ) )
         {
            H440( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Rubro", ""), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV38TFRubrosId), "ZZZ9")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV54TFRubrosId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H440( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54TFRubrosId_To_Description, "")), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV39TFRubrosId_To), "ZZZ9")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41TFRubrosNombre_Sel)) )
         {
            AV58TempBoolean = (bool)(((StringUtil.StrCmp(AV41TFRubrosNombre_Sel, "<#Empty#>")==0)));
            AV41TFRubrosNombre_Sel = (AV58TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV41TFRubrosNombre_Sel);
            H440( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("", 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFRubrosNombre_Sel, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV41TFRubrosNombre_Sel = (AV58TempBoolean ? "<#Empty#>" : AV41TFRubrosNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFRubrosNombre)) )
            {
               H440( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("", 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFRubrosNombre, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45TFMedidasNombre_Sel)) )
         {
            AV58TempBoolean = (bool)(((StringUtil.StrCmp(AV45TFMedidasNombre_Sel, "<#Empty#>")==0)));
            AV45TFMedidasNombre_Sel = (AV58TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV45TFMedidasNombre_Sel);
            H440( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("", 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45TFMedidasNombre_Sel, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV45TFMedidasNombre_Sel = (AV58TempBoolean ? "<#Empty#>" : AV45TFMedidasNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44TFMedidasNombre)) )
            {
               H440( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("", 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44TFMedidasNombre, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! ( (0==AV46TFTextosId) && (0==AV47TFTextosId_To) ) )
         {
            H440( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("#", 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV46TFTextosId), "ZZZZZZZZZZZZZZZZZ9")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV56TFTextosId_To_Description = StringUtil.Format( "%1 (%2)", "#", context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H440( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56TFTextosId_To_Description, "")), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV47TFTextosId_To), "ZZZZZZZZZZZZZZZZZ9")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49TFTextosTitulo_Sel)) )
         {
            AV58TempBoolean = (bool)(((StringUtil.StrCmp(AV49TFTextosTitulo_Sel, "<#Empty#>")==0)));
            AV49TFTextosTitulo_Sel = (AV58TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV49TFTextosTitulo_Sel);
            H440( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Terminos y Condiciones", ""), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49TFTextosTitulo_Sel, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV49TFTextosTitulo_Sel = (AV58TempBoolean ? "<#Empty#>" : AV49TFTextosTitulo_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48TFTextosTitulo)) )
            {
               H440( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Terminos y Condiciones", ""), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48TFTextosTitulo, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         AV52TFMedidasEstado_Sels.FromJSonString(AV50TFMedidasEstado_SelsJson, null);
         if ( ! ( AV52TFMedidasEstado_Sels.Count == 0 ) )
         {
            AV59i = 1;
            AV92GXV1 = 1;
            while ( AV92GXV1 <= AV52TFMedidasEstado_Sels.Count )
            {
               AV53TFMedidasEstado_Sel = AV52TFMedidasEstado_Sels.GetString(AV92GXV1);
               if ( AV59i == 1 )
               {
                  AV51TFMedidasEstado_SelDscs = "";
               }
               else
               {
                  AV51TFMedidasEstado_SelDscs += ", ";
               }
               AV57FilterTFMedidasEstado_SelValueDescription = context.GetMessage( gxdomainestadoenum.getDescription(context,AV53TFMedidasEstado_Sel), "");
               AV51TFMedidasEstado_SelDscs += AV57FilterTFMedidasEstado_SelValueDescription;
               AV59i = (long)(AV59i+1);
               AV92GXV1 = (int)(AV92GXV1+1);
            }
            H440( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("", 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51TFMedidasEstado_SelDscs, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H440( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H440( false, 36) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Rubro", ""), 30, Gx_line+10, 96, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("", 100, Gx_line+10, 166, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("", 170, Gx_line+10, 302, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("", 306, Gx_line+10, 440, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("#", 444, Gx_line+10, 511, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Terminos y Condiciones", ""), 515, Gx_line+10, 649, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("", 653, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV94Inventariowwds_1_filterfulltext = AV13FilterFullText;
         AV95Inventariowwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV96Inventariowwds_3_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV97Inventariowwds_4_rubroscosto1 = AV16RubrosCosto1;
         AV98Inventariowwds_5_rubrosnombre1 = AV19RubrosNombre1;
         AV99Inventariowwds_6_textostipo1 = AV72TextosTipo1;
         AV100Inventariowwds_7_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV101Inventariowwds_8_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV102Inventariowwds_9_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV103Inventariowwds_10_rubroscosto2 = AV25RubrosCosto2;
         AV104Inventariowwds_11_rubrosnombre2 = AV26RubrosNombre2;
         AV105Inventariowwds_12_textostipo2 = AV75TextosTipo2;
         AV106Inventariowwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV107Inventariowwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV108Inventariowwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV109Inventariowwds_16_rubroscosto3 = AV30RubrosCosto3;
         AV110Inventariowwds_17_rubrosnombre3 = AV31RubrosNombre3;
         AV111Inventariowwds_18_textostipo3 = AV76TextosTipo3;
         AV112Inventariowwds_19_tfrubrosid = AV38TFRubrosId;
         AV113Inventariowwds_20_tfrubrosid_to = AV39TFRubrosId_To;
         AV114Inventariowwds_21_tfrubrosnombre = AV40TFRubrosNombre;
         AV115Inventariowwds_22_tfrubrosnombre_sel = AV41TFRubrosNombre_Sel;
         AV116Inventariowwds_23_tfmedidasnombre = AV44TFMedidasNombre;
         AV117Inventariowwds_24_tfmedidasnombre_sel = AV45TFMedidasNombre_Sel;
         AV118Inventariowwds_25_tftextosid = AV46TFTextosId;
         AV119Inventariowwds_26_tftextosid_to = AV47TFTextosId_To;
         AV120Inventariowwds_27_tftextostitulo = AV48TFTextosTitulo;
         AV121Inventariowwds_28_tftextostitulo_sel = AV49TFTextosTitulo_Sel;
         AV122Inventariowwds_29_tfmedidasestado_sels = AV52TFMedidasEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A139MedidasEstado ,
                                              AV122Inventariowwds_29_tfmedidasestado_sels ,
                                              AV95Inventariowwds_2_dynamicfiltersselector1 ,
                                              AV96Inventariowwds_3_dynamicfiltersoperator1 ,
                                              AV97Inventariowwds_4_rubroscosto1 ,
                                              AV98Inventariowwds_5_rubrosnombre1 ,
                                              AV99Inventariowwds_6_textostipo1 ,
                                              AV100Inventariowwds_7_dynamicfiltersenabled2 ,
                                              AV101Inventariowwds_8_dynamicfiltersselector2 ,
                                              AV102Inventariowwds_9_dynamicfiltersoperator2 ,
                                              AV103Inventariowwds_10_rubroscosto2 ,
                                              AV104Inventariowwds_11_rubrosnombre2 ,
                                              AV105Inventariowwds_12_textostipo2 ,
                                              AV106Inventariowwds_13_dynamicfiltersenabled3 ,
                                              AV107Inventariowwds_14_dynamicfiltersselector3 ,
                                              AV108Inventariowwds_15_dynamicfiltersoperator3 ,
                                              AV109Inventariowwds_16_rubroscosto3 ,
                                              AV110Inventariowwds_17_rubrosnombre3 ,
                                              AV111Inventariowwds_18_textostipo3 ,
                                              AV112Inventariowwds_19_tfrubrosid ,
                                              AV113Inventariowwds_20_tfrubrosid_to ,
                                              AV115Inventariowwds_22_tfrubrosnombre_sel ,
                                              AV114Inventariowwds_21_tfrubrosnombre ,
                                              AV117Inventariowwds_24_tfmedidasnombre_sel ,
                                              AV116Inventariowwds_23_tfmedidasnombre ,
                                              AV118Inventariowwds_25_tftextosid ,
                                              AV119Inventariowwds_26_tftextosid_to ,
                                              AV121Inventariowwds_28_tftextostitulo_sel ,
                                              AV120Inventariowwds_27_tftextostitulo ,
                                              AV122Inventariowwds_29_tfmedidasestado_sels.Count ,
                                              A215RubrosCosto ,
                                              A122RubrosNombre ,
                                              A258TextosTipo ,
                                              A121RubrosId ,
                                              A138MedidasNombre ,
                                              A150TextosId ,
                                              A259TextosTitulo ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              AV94Inventariowwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV98Inventariowwds_5_rubrosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV98Inventariowwds_5_rubrosnombre1), 100, "%");
         lV98Inventariowwds_5_rubrosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV98Inventariowwds_5_rubrosnombre1), 100, "%");
         lV99Inventariowwds_6_textostipo1 = StringUtil.PadR( StringUtil.RTrim( AV99Inventariowwds_6_textostipo1), 20, "%");
         lV99Inventariowwds_6_textostipo1 = StringUtil.PadR( StringUtil.RTrim( AV99Inventariowwds_6_textostipo1), 20, "%");
         lV104Inventariowwds_11_rubrosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV104Inventariowwds_11_rubrosnombre2), 100, "%");
         lV104Inventariowwds_11_rubrosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV104Inventariowwds_11_rubrosnombre2), 100, "%");
         lV105Inventariowwds_12_textostipo2 = StringUtil.PadR( StringUtil.RTrim( AV105Inventariowwds_12_textostipo2), 20, "%");
         lV105Inventariowwds_12_textostipo2 = StringUtil.PadR( StringUtil.RTrim( AV105Inventariowwds_12_textostipo2), 20, "%");
         lV110Inventariowwds_17_rubrosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV110Inventariowwds_17_rubrosnombre3), 100, "%");
         lV110Inventariowwds_17_rubrosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV110Inventariowwds_17_rubrosnombre3), 100, "%");
         lV111Inventariowwds_18_textostipo3 = StringUtil.PadR( StringUtil.RTrim( AV111Inventariowwds_18_textostipo3), 20, "%");
         lV111Inventariowwds_18_textostipo3 = StringUtil.PadR( StringUtil.RTrim( AV111Inventariowwds_18_textostipo3), 20, "%");
         lV114Inventariowwds_21_tfrubrosnombre = StringUtil.PadR( StringUtil.RTrim( AV114Inventariowwds_21_tfrubrosnombre), 100, "%");
         lV116Inventariowwds_23_tfmedidasnombre = StringUtil.PadR( StringUtil.RTrim( AV116Inventariowwds_23_tfmedidasnombre), 50, "%");
         lV120Inventariowwds_27_tftextostitulo = StringUtil.PadR( StringUtil.RTrim( AV120Inventariowwds_27_tftextostitulo), 80, "%");
         /* Using cursor P00442 */
         pr_default.execute(0, new Object[] {AV97Inventariowwds_4_rubroscosto1, AV97Inventariowwds_4_rubroscosto1, AV97Inventariowwds_4_rubroscosto1, lV98Inventariowwds_5_rubrosnombre1, lV98Inventariowwds_5_rubrosnombre1, lV99Inventariowwds_6_textostipo1, lV99Inventariowwds_6_textostipo1, AV103Inventariowwds_10_rubroscosto2, AV103Inventariowwds_10_rubroscosto2, AV103Inventariowwds_10_rubroscosto2, lV104Inventariowwds_11_rubrosnombre2, lV104Inventariowwds_11_rubrosnombre2, lV105Inventariowwds_12_textostipo2, lV105Inventariowwds_12_textostipo2, AV109Inventariowwds_16_rubroscosto3, AV109Inventariowwds_16_rubroscosto3, AV109Inventariowwds_16_rubroscosto3, lV110Inventariowwds_17_rubrosnombre3, lV110Inventariowwds_17_rubrosnombre3, lV111Inventariowwds_18_textostipo3, lV111Inventariowwds_18_textostipo3, AV112Inventariowwds_19_tfrubrosid, AV113Inventariowwds_20_tfrubrosid_to, lV114Inventariowwds_21_tfrubrosnombre, AV115Inventariowwds_22_tfrubrosnombre_sel, lV116Inventariowwds_23_tfmedidasnombre, AV117Inventariowwds_24_tfmedidasnombre_sel, AV118Inventariowwds_25_tftextosid, AV119Inventariowwds_26_tftextosid_to, lV120Inventariowwds_27_tftextostitulo, AV121Inventariowwds_28_tftextostitulo_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A258TextosTipo = P00442_A258TextosTipo[0];
            A259TextosTitulo = P00442_A259TextosTitulo[0];
            A150TextosId = P00442_A150TextosId[0];
            n150TextosId = P00442_n150TextosId[0];
            A138MedidasNombre = P00442_A138MedidasNombre[0];
            A122RubrosNombre = P00442_A122RubrosNombre[0];
            A121RubrosId = P00442_A121RubrosId[0];
            A215RubrosCosto = P00442_A215RubrosCosto[0];
            A139MedidasEstado = P00442_A139MedidasEstado[0];
            n139MedidasEstado = P00442_n139MedidasEstado[0];
            A40000RubrosImagen_GXI = P00442_A40000RubrosImagen_GXI[0];
            A137MedidasID = P00442_A137MedidasID[0];
            A168RubrosImagen = P00442_A168RubrosImagen[0];
            A258TextosTipo = P00442_A258TextosTipo[0];
            A259TextosTitulo = P00442_A259TextosTitulo[0];
            A122RubrosNombre = P00442_A122RubrosNombre[0];
            A40000RubrosImagen_GXI = P00442_A40000RubrosImagen_GXI[0];
            A168RubrosImagen = P00442_A168RubrosImagen[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Inventariowwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A121RubrosId), 4, 0) , StringUtil.PadR( "%" + AV94Inventariowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A122RubrosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV94Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A138MedidasNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV94Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A150TextosId), 18, 0) , StringUtil.PadR( "%" + AV94Inventariowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A259TextosTitulo) , StringUtil.PadR( "%" + StringUtil.Upper( AV94Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV94Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV94Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV94Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "PEN") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "bloqueado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV94Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "BLO") == 0 ) ) ) )
            {
               AV33MedidasEstadoDescription = context.GetMessage( gxdomainestadoenum.getDescription(context,A139MedidasEstado), "");
               /* Execute user subroutine: 'BEFOREPRINTLINE' */
               S144 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               H440( false, 35) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A121RubrosId), "ZZZ9")), 30, Gx_line+10, 96, Gx_line+24, 2+16, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : A168RubrosImagen);
               getPrinter().GxDrawBitMap(sImgUrl, 100, Gx_line+10, 166, Gx_line+24) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A122RubrosNombre, "")), 170, Gx_line+10, 302, Gx_line+24, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A138MedidasNombre, "")), 306, Gx_line+10, 440, Gx_line+24, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A150TextosId), "ZZZZZZZZZZZZZZZZZ9")), 444, Gx_line+10, 511, Gx_line+24, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A259TextosTitulo, "")), 515, Gx_line+10, 649, Gx_line+24, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33MedidasEstadoDescription, "")), 653, Gx_line+10, 787, Gx_line+24, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV34Session.Get("InventarioWWGridState"), "") == 0 )
         {
            AV36GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "InventarioWWGridState"), null, "", "");
         }
         else
         {
            AV36GridState.FromXml(AV34Session.Get("InventarioWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV36GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV36GridState.gxTpr_Ordereddsc;
         AV123GXV2 = 1;
         while ( AV123GXV2 <= AV36GridState.gxTpr_Filtervalues.Count )
         {
            AV37GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV36GridState.gxTpr_Filtervalues.Item(AV123GXV2));
            if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFRUBROSID") == 0 )
            {
               AV38TFRubrosId = (short)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV39TFRubrosId_To = (short)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFRUBROSNOMBRE") == 0 )
            {
               AV40TFRubrosNombre = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFRUBROSNOMBRE_SEL") == 0 )
            {
               AV41TFRubrosNombre_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFMEDIDASNOMBRE") == 0 )
            {
               AV44TFMedidasNombre = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFMEDIDASNOMBRE_SEL") == 0 )
            {
               AV45TFMedidasNombre_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFTEXTOSID") == 0 )
            {
               AV46TFTextosId = (long)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV47TFTextosId_To = (long)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFTEXTOSTITULO") == 0 )
            {
               AV48TFTextosTitulo = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFTEXTOSTITULO_SEL") == 0 )
            {
               AV49TFTextosTitulo_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFMEDIDASESTADO_SEL") == 0 )
            {
               AV50TFMedidasEstado_SelsJson = AV37GridStateFilterValue.gxTpr_Value;
               AV52TFMedidasEstado_Sels.FromJSonString(AV50TFMedidasEstado_SelsJson, null);
            }
            AV123GXV2 = (int)(AV123GXV2+1);
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

      protected void H440( bool bFoot ,
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
                  AV68PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV65DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+39, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68PageInfo, "")), 30, Gx_line+15, 409, Gx_line+29, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65DateInfo, "")), 409, Gx_line+15, 789, Gx_line+29, 2, 0, 0, 0) ;
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
               AV63AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV69Phone = "+1 550 8923";
               AV67Mail = "info@mail.com";
               AV71Website = "http://www.web.com";
               AV60AddressLine1 = "French Boulevard 2859";
               AV61AddressLine2 = "Downtown";
               AV62AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+107, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63AppName, "")), 30, Gx_line+30, 283, Gx_line+44, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70Title, "")), 30, Gx_line+44, 283, Gx_line+77, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV69Phone, "")), 283, Gx_line+30, 536, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67Mail, "")), 283, Gx_line+45, 536, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71Website, "")), 283, Gx_line+60, 536, Gx_line+77, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61AddressLine2, "")), 536, Gx_line+45, 789, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62AddressLine3, "")), 536, Gx_line+60, 789, Gx_line+77, 2, 0, 0, 0) ;
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
         AV89Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV70Title = "";
         AV13FilterFullText = "";
         AV36GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV32GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV17FilterRubrosCostoDescription = "";
         AV19RubrosNombre1 = "";
         AV20FilterRubrosNombreDescription = "";
         AV21RubrosNombre = "";
         AV72TextosTipo1 = "";
         AV73FilterTextosTipoDescription = "";
         AV74TextosTipo = "";
         AV23DynamicFiltersSelector2 = "";
         AV26RubrosNombre2 = "";
         AV75TextosTipo2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV31RubrosNombre3 = "";
         AV76TextosTipo3 = "";
         AV54TFRubrosId_To_Description = "";
         AV41TFRubrosNombre_Sel = "";
         AV40TFRubrosNombre = "";
         AV45TFMedidasNombre_Sel = "";
         AV44TFMedidasNombre = "";
         AV56TFTextosId_To_Description = "";
         AV49TFTextosTitulo_Sel = "";
         AV48TFTextosTitulo = "";
         AV52TFMedidasEstado_Sels = new GxSimpleCollection<string>();
         AV50TFMedidasEstado_SelsJson = "";
         AV53TFMedidasEstado_Sel = "";
         AV51TFMedidasEstado_SelDscs = "";
         AV57FilterTFMedidasEstado_SelValueDescription = "";
         AV94Inventariowwds_1_filterfulltext = "";
         AV95Inventariowwds_2_dynamicfiltersselector1 = "";
         AV98Inventariowwds_5_rubrosnombre1 = "";
         AV99Inventariowwds_6_textostipo1 = "";
         AV101Inventariowwds_8_dynamicfiltersselector2 = "";
         AV104Inventariowwds_11_rubrosnombre2 = "";
         AV105Inventariowwds_12_textostipo2 = "";
         AV107Inventariowwds_14_dynamicfiltersselector3 = "";
         AV110Inventariowwds_17_rubrosnombre3 = "";
         AV111Inventariowwds_18_textostipo3 = "";
         AV114Inventariowwds_21_tfrubrosnombre = "";
         AV115Inventariowwds_22_tfrubrosnombre_sel = "";
         AV116Inventariowwds_23_tfmedidasnombre = "";
         AV117Inventariowwds_24_tfmedidasnombre_sel = "";
         AV120Inventariowwds_27_tftextostitulo = "";
         AV121Inventariowwds_28_tftextostitulo_sel = "";
         AV122Inventariowwds_29_tfmedidasestado_sels = new GxSimpleCollection<string>();
         lV98Inventariowwds_5_rubrosnombre1 = "";
         lV99Inventariowwds_6_textostipo1 = "";
         lV104Inventariowwds_11_rubrosnombre2 = "";
         lV105Inventariowwds_12_textostipo2 = "";
         lV110Inventariowwds_17_rubrosnombre3 = "";
         lV111Inventariowwds_18_textostipo3 = "";
         lV114Inventariowwds_21_tfrubrosnombre = "";
         lV116Inventariowwds_23_tfmedidasnombre = "";
         lV120Inventariowwds_27_tftextostitulo = "";
         A139MedidasEstado = "";
         A122RubrosNombre = "";
         A258TextosTipo = "";
         A138MedidasNombre = "";
         A259TextosTitulo = "";
         P00442_A258TextosTipo = new string[] {""} ;
         P00442_A259TextosTitulo = new string[] {""} ;
         P00442_A150TextosId = new long[1] ;
         P00442_n150TextosId = new bool[] {false} ;
         P00442_A138MedidasNombre = new string[] {""} ;
         P00442_A122RubrosNombre = new string[] {""} ;
         P00442_A121RubrosId = new short[1] ;
         P00442_A215RubrosCosto = new decimal[1] ;
         P00442_A139MedidasEstado = new string[] {""} ;
         P00442_n139MedidasEstado = new bool[] {false} ;
         P00442_A40000RubrosImagen_GXI = new string[] {""} ;
         P00442_A137MedidasID = new long[1] ;
         P00442_A168RubrosImagen = new string[] {""} ;
         A40000RubrosImagen_GXI = "";
         A168RubrosImagen = "";
         AV33MedidasEstadoDescription = "";
         sImgUrl = "";
         AV34Session = context.GetSession();
         AV37GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV68PageInfo = "";
         AV65DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV63AppName = "";
         AV69Phone = "";
         AV67Mail = "";
         AV71Website = "";
         AV60AddressLine1 = "";
         AV61AddressLine2 = "";
         AV62AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.inventariowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00442_A258TextosTipo, P00442_A259TextosTitulo, P00442_A150TextosId, P00442_n150TextosId, P00442_A138MedidasNombre, P00442_A122RubrosNombre, P00442_A121RubrosId, P00442_A215RubrosCosto, P00442_A139MedidasEstado, P00442_n139MedidasEstado,
               P00442_A40000RubrosImagen_GXI, P00442_A137MedidasID, P00442_A168RubrosImagen
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV89Pgmname = "InventarioWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV89Pgmname = "InventarioWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV15DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short AV38TFRubrosId ;
      private short AV39TFRubrosId_To ;
      private short AV96Inventariowwds_3_dynamicfiltersoperator1 ;
      private short AV102Inventariowwds_9_dynamicfiltersoperator2 ;
      private short AV108Inventariowwds_15_dynamicfiltersoperator3 ;
      private short AV112Inventariowwds_19_tfrubrosid ;
      private short AV113Inventariowwds_20_tfrubrosid_to ;
      private short A121RubrosId ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV92GXV1 ;
      private int AV122Inventariowwds_29_tfmedidasestado_sels_Count ;
      private int AV123GXV2 ;
      private long AV46TFTextosId ;
      private long AV47TFTextosId_To ;
      private long AV59i ;
      private long AV118Inventariowwds_25_tftextosid ;
      private long AV119Inventariowwds_26_tftextosid_to ;
      private long A150TextosId ;
      private long A137MedidasID ;
      private decimal AV16RubrosCosto1 ;
      private decimal AV18RubrosCosto ;
      private decimal AV25RubrosCosto2 ;
      private decimal AV30RubrosCosto3 ;
      private decimal AV97Inventariowwds_4_rubroscosto1 ;
      private decimal AV103Inventariowwds_10_rubroscosto2 ;
      private decimal AV109Inventariowwds_16_rubroscosto3 ;
      private decimal A215RubrosCosto ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV89Pgmname ;
      private string GXEncryptionTmp ;
      private string AV19RubrosNombre1 ;
      private string AV21RubrosNombre ;
      private string AV72TextosTipo1 ;
      private string AV74TextosTipo ;
      private string AV26RubrosNombre2 ;
      private string AV75TextosTipo2 ;
      private string AV31RubrosNombre3 ;
      private string AV76TextosTipo3 ;
      private string AV41TFRubrosNombre_Sel ;
      private string AV40TFRubrosNombre ;
      private string AV45TFMedidasNombre_Sel ;
      private string AV44TFMedidasNombre ;
      private string AV49TFTextosTitulo_Sel ;
      private string AV48TFTextosTitulo ;
      private string AV53TFMedidasEstado_Sel ;
      private string AV98Inventariowwds_5_rubrosnombre1 ;
      private string AV99Inventariowwds_6_textostipo1 ;
      private string AV104Inventariowwds_11_rubrosnombre2 ;
      private string AV105Inventariowwds_12_textostipo2 ;
      private string AV110Inventariowwds_17_rubrosnombre3 ;
      private string AV111Inventariowwds_18_textostipo3 ;
      private string AV114Inventariowwds_21_tfrubrosnombre ;
      private string AV115Inventariowwds_22_tfrubrosnombre_sel ;
      private string AV116Inventariowwds_23_tfmedidasnombre ;
      private string AV117Inventariowwds_24_tfmedidasnombre_sel ;
      private string AV120Inventariowwds_27_tftextostitulo ;
      private string AV121Inventariowwds_28_tftextostitulo_sel ;
      private string lV98Inventariowwds_5_rubrosnombre1 ;
      private string lV99Inventariowwds_6_textostipo1 ;
      private string lV104Inventariowwds_11_rubrosnombre2 ;
      private string lV105Inventariowwds_12_textostipo2 ;
      private string lV110Inventariowwds_17_rubrosnombre3 ;
      private string lV111Inventariowwds_18_textostipo3 ;
      private string lV114Inventariowwds_21_tfrubrosnombre ;
      private string lV116Inventariowwds_23_tfmedidasnombre ;
      private string lV120Inventariowwds_27_tftextostitulo ;
      private string A139MedidasEstado ;
      private string A122RubrosNombre ;
      private string A258TextosTipo ;
      private string A138MedidasNombre ;
      private string A259TextosTitulo ;
      private string sImgUrl ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV58TempBoolean ;
      private bool AV100Inventariowwds_7_dynamicfiltersenabled2 ;
      private bool AV106Inventariowwds_13_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private bool n150TextosId ;
      private bool n139MedidasEstado ;
      private string AV50TFMedidasEstado_SelsJson ;
      private string AV70Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV17FilterRubrosCostoDescription ;
      private string AV20FilterRubrosNombreDescription ;
      private string AV73FilterTextosTipoDescription ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV54TFRubrosId_To_Description ;
      private string AV56TFTextosId_To_Description ;
      private string AV51TFMedidasEstado_SelDscs ;
      private string AV57FilterTFMedidasEstado_SelValueDescription ;
      private string AV94Inventariowwds_1_filterfulltext ;
      private string AV95Inventariowwds_2_dynamicfiltersselector1 ;
      private string AV101Inventariowwds_8_dynamicfiltersselector2 ;
      private string AV107Inventariowwds_14_dynamicfiltersselector3 ;
      private string A40000RubrosImagen_GXI ;
      private string AV33MedidasEstadoDescription ;
      private string AV68PageInfo ;
      private string AV65DateInfo ;
      private string AV63AppName ;
      private string AV69Phone ;
      private string AV67Mail ;
      private string AV71Website ;
      private string AV60AddressLine1 ;
      private string AV61AddressLine2 ;
      private string AV62AddressLine3 ;
      private string A168RubrosImagen ;
      private IGxSession AV34Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV36GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV32GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV52TFMedidasEstado_Sels ;
      private GxSimpleCollection<string> AV122Inventariowwds_29_tfmedidasestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00442_A258TextosTipo ;
      private string[] P00442_A259TextosTitulo ;
      private long[] P00442_A150TextosId ;
      private bool[] P00442_n150TextosId ;
      private string[] P00442_A138MedidasNombre ;
      private string[] P00442_A122RubrosNombre ;
      private short[] P00442_A121RubrosId ;
      private decimal[] P00442_A215RubrosCosto ;
      private string[] P00442_A139MedidasEstado ;
      private bool[] P00442_n139MedidasEstado ;
      private string[] P00442_A40000RubrosImagen_GXI ;
      private long[] P00442_A137MedidasID ;
      private string[] P00442_A168RubrosImagen ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV37GridStateFilterValue ;
   }

   public class inventariowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00442( IGxContext context ,
                                             string A139MedidasEstado ,
                                             GxSimpleCollection<string> AV122Inventariowwds_29_tfmedidasestado_sels ,
                                             string AV95Inventariowwds_2_dynamicfiltersselector1 ,
                                             short AV96Inventariowwds_3_dynamicfiltersoperator1 ,
                                             decimal AV97Inventariowwds_4_rubroscosto1 ,
                                             string AV98Inventariowwds_5_rubrosnombre1 ,
                                             string AV99Inventariowwds_6_textostipo1 ,
                                             bool AV100Inventariowwds_7_dynamicfiltersenabled2 ,
                                             string AV101Inventariowwds_8_dynamicfiltersselector2 ,
                                             short AV102Inventariowwds_9_dynamicfiltersoperator2 ,
                                             decimal AV103Inventariowwds_10_rubroscosto2 ,
                                             string AV104Inventariowwds_11_rubrosnombre2 ,
                                             string AV105Inventariowwds_12_textostipo2 ,
                                             bool AV106Inventariowwds_13_dynamicfiltersenabled3 ,
                                             string AV107Inventariowwds_14_dynamicfiltersselector3 ,
                                             short AV108Inventariowwds_15_dynamicfiltersoperator3 ,
                                             decimal AV109Inventariowwds_16_rubroscosto3 ,
                                             string AV110Inventariowwds_17_rubrosnombre3 ,
                                             string AV111Inventariowwds_18_textostipo3 ,
                                             short AV112Inventariowwds_19_tfrubrosid ,
                                             short AV113Inventariowwds_20_tfrubrosid_to ,
                                             string AV115Inventariowwds_22_tfrubrosnombre_sel ,
                                             string AV114Inventariowwds_21_tfrubrosnombre ,
                                             string AV117Inventariowwds_24_tfmedidasnombre_sel ,
                                             string AV116Inventariowwds_23_tfmedidasnombre ,
                                             long AV118Inventariowwds_25_tftextosid ,
                                             long AV119Inventariowwds_26_tftextosid_to ,
                                             string AV121Inventariowwds_28_tftextostitulo_sel ,
                                             string AV120Inventariowwds_27_tftextostitulo ,
                                             int AV122Inventariowwds_29_tfmedidasestado_sels_Count ,
                                             decimal A215RubrosCosto ,
                                             string A122RubrosNombre ,
                                             string A258TextosTipo ,
                                             short A121RubrosId ,
                                             string A138MedidasNombre ,
                                             long A150TextosId ,
                                             string A259TextosTitulo ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             string AV94Inventariowwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[31];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T2.[TextosTipo], T2.[TextosTitulo], T1.[TextosId], T1.[MedidasNombre], T3.[RubrosNombre], T1.[RubrosId], T1.[RubrosCosto], T1.[MedidasEstado], T3.[RubrosImagen_GXI], T1.[MedidasID], T3.[RubrosImagen] FROM (([RubrosMedidas] T1 LEFT JOIN [Textos] T2 ON T2.[TextosId] = T1.[TextosId]) INNER JOIN [Rubros] T3 ON T3.[RubrosId] = T1.[RubrosId])";
         if ( ( StringUtil.StrCmp(AV95Inventariowwds_2_dynamicfiltersselector1, "RUBROSCOSTO") == 0 ) && ( AV96Inventariowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV97Inventariowwds_4_rubroscosto1) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] < @AV97Inventariowwds_4_rubroscosto1)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV95Inventariowwds_2_dynamicfiltersselector1, "RUBROSCOSTO") == 0 ) && ( AV96Inventariowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV97Inventariowwds_4_rubroscosto1) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] = @AV97Inventariowwds_4_rubroscosto1)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV95Inventariowwds_2_dynamicfiltersselector1, "RUBROSCOSTO") == 0 ) && ( AV96Inventariowwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV97Inventariowwds_4_rubroscosto1) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] > @AV97Inventariowwds_4_rubroscosto1)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV95Inventariowwds_2_dynamicfiltersselector1, "RUBROSNOMBRE") == 0 ) && ( AV96Inventariowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Inventariowwds_5_rubrosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like UPPER(@lV98Inventariowwds_5_rubrosnombre1))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV95Inventariowwds_2_dynamicfiltersselector1, "RUBROSNOMBRE") == 0 ) && ( AV96Inventariowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Inventariowwds_5_rubrosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like '%' + UPPER(@lV98Inventariowwds_5_rubrosnombre1))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV95Inventariowwds_2_dynamicfiltersselector1, "TEXTOSTIPO") == 0 ) && ( AV96Inventariowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Inventariowwds_6_textostipo1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like UPPER(@lV99Inventariowwds_6_textostipo1))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV95Inventariowwds_2_dynamicfiltersselector1, "TEXTOSTIPO") == 0 ) && ( AV96Inventariowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Inventariowwds_6_textostipo1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like '%' + UPPER(@lV99Inventariowwds_6_textostipo1))");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV100Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV101Inventariowwds_8_dynamicfiltersselector2, "RUBROSCOSTO") == 0 ) && ( AV102Inventariowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV103Inventariowwds_10_rubroscosto2) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] < @AV103Inventariowwds_10_rubroscosto2)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( AV100Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV101Inventariowwds_8_dynamicfiltersselector2, "RUBROSCOSTO") == 0 ) && ( AV102Inventariowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV103Inventariowwds_10_rubroscosto2) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] = @AV103Inventariowwds_10_rubroscosto2)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( AV100Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV101Inventariowwds_8_dynamicfiltersselector2, "RUBROSCOSTO") == 0 ) && ( AV102Inventariowwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV103Inventariowwds_10_rubroscosto2) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] > @AV103Inventariowwds_10_rubroscosto2)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( AV100Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV101Inventariowwds_8_dynamicfiltersselector2, "RUBROSNOMBRE") == 0 ) && ( AV102Inventariowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Inventariowwds_11_rubrosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like UPPER(@lV104Inventariowwds_11_rubrosnombre2))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( AV100Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV101Inventariowwds_8_dynamicfiltersselector2, "RUBROSNOMBRE") == 0 ) && ( AV102Inventariowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Inventariowwds_11_rubrosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like '%' + UPPER(@lV104Inventariowwds_11_rubrosnombre2))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( AV100Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV101Inventariowwds_8_dynamicfiltersselector2, "TEXTOSTIPO") == 0 ) && ( AV102Inventariowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Inventariowwds_12_textostipo2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like UPPER(@lV105Inventariowwds_12_textostipo2))");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( AV100Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV101Inventariowwds_8_dynamicfiltersselector2, "TEXTOSTIPO") == 0 ) && ( AV102Inventariowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Inventariowwds_12_textostipo2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like '%' + UPPER(@lV105Inventariowwds_12_textostipo2))");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( AV106Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV107Inventariowwds_14_dynamicfiltersselector3, "RUBROSCOSTO") == 0 ) && ( AV108Inventariowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV109Inventariowwds_16_rubroscosto3) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] < @AV109Inventariowwds_16_rubroscosto3)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( AV106Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV107Inventariowwds_14_dynamicfiltersselector3, "RUBROSCOSTO") == 0 ) && ( AV108Inventariowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV109Inventariowwds_16_rubroscosto3) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] = @AV109Inventariowwds_16_rubroscosto3)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( AV106Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV107Inventariowwds_14_dynamicfiltersselector3, "RUBROSCOSTO") == 0 ) && ( AV108Inventariowwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV109Inventariowwds_16_rubroscosto3) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] > @AV109Inventariowwds_16_rubroscosto3)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( AV106Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV107Inventariowwds_14_dynamicfiltersselector3, "RUBROSNOMBRE") == 0 ) && ( AV108Inventariowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Inventariowwds_17_rubrosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like UPPER(@lV110Inventariowwds_17_rubrosnombre3))");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( AV106Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV107Inventariowwds_14_dynamicfiltersselector3, "RUBROSNOMBRE") == 0 ) && ( AV108Inventariowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Inventariowwds_17_rubrosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like '%' + UPPER(@lV110Inventariowwds_17_rubrosnombre3))");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( AV106Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV107Inventariowwds_14_dynamicfiltersselector3, "TEXTOSTIPO") == 0 ) && ( AV108Inventariowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Inventariowwds_18_textostipo3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like UPPER(@lV111Inventariowwds_18_textostipo3))");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( AV106Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV107Inventariowwds_14_dynamicfiltersselector3, "TEXTOSTIPO") == 0 ) && ( AV108Inventariowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Inventariowwds_18_textostipo3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like '%' + UPPER(@lV111Inventariowwds_18_textostipo3))");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( ! (0==AV112Inventariowwds_19_tfrubrosid) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] >= @AV112Inventariowwds_19_tfrubrosid)");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( ! (0==AV113Inventariowwds_20_tfrubrosid_to) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] <= @AV113Inventariowwds_20_tfrubrosid_to)");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV115Inventariowwds_22_tfrubrosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Inventariowwds_21_tfrubrosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like UPPER(@lV114Inventariowwds_21_tfrubrosnombre))");
         }
         else
         {
            GXv_int2[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Inventariowwds_22_tfrubrosnombre_sel)) && ! ( StringUtil.StrCmp(AV115Inventariowwds_22_tfrubrosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[RubrosNombre] = @AV115Inventariowwds_22_tfrubrosnombre_sel)");
         }
         else
         {
            GXv_int2[24] = 1;
         }
         if ( StringUtil.StrCmp(AV115Inventariowwds_22_tfrubrosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[RubrosNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV117Inventariowwds_24_tfmedidasnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Inventariowwds_23_tfmedidasnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MedidasNombre]) like UPPER(@lV116Inventariowwds_23_tfmedidasnombre))");
         }
         else
         {
            GXv_int2[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Inventariowwds_24_tfmedidasnombre_sel)) && ! ( StringUtil.StrCmp(AV117Inventariowwds_24_tfmedidasnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MedidasNombre] = @AV117Inventariowwds_24_tfmedidasnombre_sel)");
         }
         else
         {
            GXv_int2[26] = 1;
         }
         if ( StringUtil.StrCmp(AV117Inventariowwds_24_tfmedidasnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MedidasNombre] = ''))");
         }
         if ( ! (0==AV118Inventariowwds_25_tftextosid) )
         {
            AddWhere(sWhereString, "(T1.[TextosId] >= @AV118Inventariowwds_25_tftextosid)");
         }
         else
         {
            GXv_int2[27] = 1;
         }
         if ( ! (0==AV119Inventariowwds_26_tftextosid_to) )
         {
            AddWhere(sWhereString, "(T1.[TextosId] <= @AV119Inventariowwds_26_tftextosid_to)");
         }
         else
         {
            GXv_int2[28] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV121Inventariowwds_28_tftextostitulo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Inventariowwds_27_tftextostitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTitulo]) like UPPER(@lV120Inventariowwds_27_tftextostitulo))");
         }
         else
         {
            GXv_int2[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Inventariowwds_28_tftextostitulo_sel)) && ! ( StringUtil.StrCmp(AV121Inventariowwds_28_tftextostitulo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[TextosTitulo] = @AV121Inventariowwds_28_tftextostitulo_sel)");
         }
         else
         {
            GXv_int2[30] = 1;
         }
         if ( StringUtil.StrCmp(AV121Inventariowwds_28_tftextostitulo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[TextosTitulo] IS NULL or (T2.[TextosTitulo] = ''))");
         }
         if ( AV122Inventariowwds_29_tfmedidasestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV122Inventariowwds_29_tfmedidasestado_sels, "T1.[MedidasEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV11OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[RubrosCosto]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre], T1.[RubrosId]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre] DESC, T1.[RubrosId] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre], T1.[MedidasNombre]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre] DESC, T1.[MedidasNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre], T1.[TextosId]";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre] DESC, T1.[TextosId] DESC";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre], T2.[TextosTitulo]";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre] DESC, T2.[TextosTitulo] DESC";
         }
         else if ( ( AV11OrderedBy == 7 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre], T1.[MedidasEstado]";
         }
         else if ( ( AV11OrderedBy == 7 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[RubrosNombre] DESC, T1.[MedidasEstado] DESC";
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
                     return conditional_P00442(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (decimal)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (decimal)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (decimal)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (int)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (short)dynConstraints[33] , (string)dynConstraints[34] , (long)dynConstraints[35] , (string)dynConstraints[36] , (short)dynConstraints[37] , (bool)dynConstraints[38] , (string)dynConstraints[39] );
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
          Object[] prmP00442;
          prmP00442 = new Object[] {
          new ParDef("@AV97Inventariowwds_4_rubroscosto1",GXType.Decimal,18,2) ,
          new ParDef("@AV97Inventariowwds_4_rubroscosto1",GXType.Decimal,18,2) ,
          new ParDef("@AV97Inventariowwds_4_rubroscosto1",GXType.Decimal,18,2) ,
          new ParDef("@lV98Inventariowwds_5_rubrosnombre1",GXType.Char,100,0) ,
          new ParDef("@lV98Inventariowwds_5_rubrosnombre1",GXType.Char,100,0) ,
          new ParDef("@lV99Inventariowwds_6_textostipo1",GXType.Char,20,0) ,
          new ParDef("@lV99Inventariowwds_6_textostipo1",GXType.Char,20,0) ,
          new ParDef("@AV103Inventariowwds_10_rubroscosto2",GXType.Decimal,18,2) ,
          new ParDef("@AV103Inventariowwds_10_rubroscosto2",GXType.Decimal,18,2) ,
          new ParDef("@AV103Inventariowwds_10_rubroscosto2",GXType.Decimal,18,2) ,
          new ParDef("@lV104Inventariowwds_11_rubrosnombre2",GXType.Char,100,0) ,
          new ParDef("@lV104Inventariowwds_11_rubrosnombre2",GXType.Char,100,0) ,
          new ParDef("@lV105Inventariowwds_12_textostipo2",GXType.Char,20,0) ,
          new ParDef("@lV105Inventariowwds_12_textostipo2",GXType.Char,20,0) ,
          new ParDef("@AV109Inventariowwds_16_rubroscosto3",GXType.Decimal,18,2) ,
          new ParDef("@AV109Inventariowwds_16_rubroscosto3",GXType.Decimal,18,2) ,
          new ParDef("@AV109Inventariowwds_16_rubroscosto3",GXType.Decimal,18,2) ,
          new ParDef("@lV110Inventariowwds_17_rubrosnombre3",GXType.Char,100,0) ,
          new ParDef("@lV110Inventariowwds_17_rubrosnombre3",GXType.Char,100,0) ,
          new ParDef("@lV111Inventariowwds_18_textostipo3",GXType.Char,20,0) ,
          new ParDef("@lV111Inventariowwds_18_textostipo3",GXType.Char,20,0) ,
          new ParDef("@AV112Inventariowwds_19_tfrubrosid",GXType.Int16,4,0) ,
          new ParDef("@AV113Inventariowwds_20_tfrubrosid_to",GXType.Int16,4,0) ,
          new ParDef("@lV114Inventariowwds_21_tfrubrosnombre",GXType.Char,100,0) ,
          new ParDef("@AV115Inventariowwds_22_tfrubrosnombre_sel",GXType.NChar,100,0) ,
          new ParDef("@lV116Inventariowwds_23_tfmedidasnombre",GXType.Char,50,0) ,
          new ParDef("@AV117Inventariowwds_24_tfmedidasnombre_sel",GXType.NChar,50,0) ,
          new ParDef("@AV118Inventariowwds_25_tftextosid",GXType.Decimal,18,0) ,
          new ParDef("@AV119Inventariowwds_26_tftextosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV120Inventariowwds_27_tftextostitulo",GXType.Char,80,0) ,
          new ParDef("@AV121Inventariowwds_28_tftextostitulo_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00442", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00442,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 50);
                ((string[]) buf[5])[0] = rslt.getString(5, 100);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 3);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getMultimediaUri(9);
                ((long[]) buf[11])[0] = rslt.getLong(10);
                ((string[]) buf[12])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(9));
                return;
       }
    }

 }

}
