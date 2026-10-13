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
   public class profesionaleswwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public profesionaleswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public profesionaleswwexportreport( IGxContext context )
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
         setOutputFileName("ProfesionalesWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionales", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV78Pgmname));
               CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
               context.wjLocDisableFrm = 1;
            }
            if ( AV8IsAuthorized )
            {
               new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
               /* Execute user subroutine: 'LOADGRIDSTATE' */
               S161 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               AV65Title = context.GetMessage( "Lista de Profesionales", "");
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
            HAW0( true, 0) ;
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
            HAW0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV27GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "PROFESIONALESESRUT") == 0 )
            {
               AV69ProfesionalesEsRUT1 = BooleanUtil.Val( AV27GridStateDynamicFilter.gxTpr_Value);
               if ( ! (false==AV69ProfesionalesEsRUT1) )
               {
                  AV70ProfesionalesEsRUT = AV69ProfesionalesEsRUT1;
                  HAW0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "El Documento es RUT", ""), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.BoolToStr( AV70ProfesionalesEsRUT), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "BANCONOMBRE") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV27GridStateDynamicFilter.gxTpr_Operator;
               AV71BancoNombre1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71BancoNombre1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV72FilterBancoNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre del Banco", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV72FilterBancoNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre del Banco", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV73BancoNombre = AV71BancoNombre1;
                  HAW0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV72FilterBancoNombreDescription, "")), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73BancoNombre, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "PROFESIONALESPRIMERNOMBRE") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV27GridStateDynamicFilter.gxTpr_Operator;
               AV16ProfesionalesPrimerNombre1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16ProfesionalesPrimerNombre1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterProfesionalesPrimerNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Primer Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterProfesionalesPrimerNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Primer Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV18ProfesionalesPrimerNombre = AV16ProfesionalesPrimerNombre1;
                  HAW0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterProfesionalesPrimerNombreDescription, "")), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18ProfesionalesPrimerNombre, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV19DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "PROFESIONALESESRUT") == 0 )
               {
                  AV74ProfesionalesEsRUT2 = BooleanUtil.Val( AV27GridStateDynamicFilter.gxTpr_Value);
                  if ( ! (false==AV74ProfesionalesEsRUT2) )
                  {
                     AV70ProfesionalesEsRUT = AV74ProfesionalesEsRUT2;
                     HAW0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.GetMessage( "El Documento es RUT", ""), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.BoolToStr( AV70ProfesionalesEsRUT), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "BANCONOMBRE") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV27GridStateDynamicFilter.gxTpr_Operator;
                  AV75BancoNombre2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75BancoNombre2)) )
                  {
                     if ( AV21DynamicFiltersOperator2 == 0 )
                     {
                        AV72FilterBancoNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre del Banco", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV21DynamicFiltersOperator2 == 1 )
                     {
                        AV72FilterBancoNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre del Banco", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV73BancoNombre = AV75BancoNombre2;
                     HAW0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV72FilterBancoNombreDescription, "")), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73BancoNombre, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "PROFESIONALESPRIMERNOMBRE") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV27GridStateDynamicFilter.gxTpr_Operator;
                  AV22ProfesionalesPrimerNombre2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ProfesionalesPrimerNombre2)) )
                  {
                     if ( AV21DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterProfesionalesPrimerNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Primer Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV21DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterProfesionalesPrimerNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Primer Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV18ProfesionalesPrimerNombre = AV22ProfesionalesPrimerNombre2;
                     HAW0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterProfesionalesPrimerNombreDescription, "")), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18ProfesionalesPrimerNombre, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "PROFESIONALESESRUT") == 0 )
                  {
                     AV76ProfesionalesEsRUT3 = BooleanUtil.Val( AV27GridStateDynamicFilter.gxTpr_Value);
                     if ( ! (false==AV76ProfesionalesEsRUT3) )
                     {
                        AV70ProfesionalesEsRUT = AV76ProfesionalesEsRUT3;
                        HAW0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.GetMessage( "El Documento es RUT", ""), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.BoolToStr( AV70ProfesionalesEsRUT), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "BANCONOMBRE") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV27GridStateDynamicFilter.gxTpr_Operator;
                     AV77BancoNombre3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77BancoNombre3)) )
                     {
                        if ( AV25DynamicFiltersOperator3 == 0 )
                        {
                           AV72FilterBancoNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre del Banco", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV25DynamicFiltersOperator3 == 1 )
                        {
                           AV72FilterBancoNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre del Banco", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV73BancoNombre = AV77BancoNombre3;
                        HAW0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV72FilterBancoNombreDescription, "")), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73BancoNombre, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "PROFESIONALESPRIMERNOMBRE") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV27GridStateDynamicFilter.gxTpr_Operator;
                     AV26ProfesionalesPrimerNombre3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ProfesionalesPrimerNombre3)) )
                     {
                        if ( AV25DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterProfesionalesPrimerNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Primer Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV25DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterProfesionalesPrimerNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Primer Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV18ProfesionalesPrimerNombre = AV26ProfesionalesPrimerNombre3;
                        HAW0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterProfesionalesPrimerNombreDescription, "")), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18ProfesionalesPrimerNombre, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFProfesionalesId_Sel)) )
         {
            AV54TempBoolean = (bool)(((StringUtil.StrCmp(AV33TFProfesionalesId_Sel, "<#Empty#>")==0)));
            AV33TFProfesionalesId_Sel = (AV54TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV33TFProfesionalesId_Sel);
            HAW0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Identidad", ""), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFProfesionalesId_Sel, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV33TFProfesionalesId_Sel = (AV54TempBoolean ? "<#Empty#>" : AV33TFProfesionalesId_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFProfesionalesId)) )
            {
               HAW0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Identidad", ""), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFProfesionalesId, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFProfesionalesPrimerNombre_Sel)) )
         {
            AV54TempBoolean = (bool)(((StringUtil.StrCmp(AV35TFProfesionalesPrimerNombre_Sel, "<#Empty#>")==0)));
            AV35TFProfesionalesPrimerNombre_Sel = (AV54TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV35TFProfesionalesPrimerNombre_Sel);
            HAW0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Primer Nombre", ""), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFProfesionalesPrimerNombre_Sel, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV35TFProfesionalesPrimerNombre_Sel = (AV54TempBoolean ? "<#Empty#>" : AV35TFProfesionalesPrimerNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFProfesionalesPrimerNombre)) )
            {
               HAW0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Primer Nombre", ""), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFProfesionalesPrimerNombre, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFProfesionalesSegundoNombre_Sel)) )
         {
            AV54TempBoolean = (bool)(((StringUtil.StrCmp(AV37TFProfesionalesSegundoNombre_Sel, "<#Empty#>")==0)));
            AV37TFProfesionalesSegundoNombre_Sel = (AV54TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV37TFProfesionalesSegundoNombre_Sel);
            HAW0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Segundo Nombre", ""), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFProfesionalesSegundoNombre_Sel, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV37TFProfesionalesSegundoNombre_Sel = (AV54TempBoolean ? "<#Empty#>" : AV37TFProfesionalesSegundoNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFProfesionalesSegundoNombre)) )
            {
               HAW0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Segundo Nombre", ""), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFProfesionalesSegundoNombre, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFProfesionalesApellidoPrimero_Sel)) )
         {
            AV54TempBoolean = (bool)(((StringUtil.StrCmp(AV39TFProfesionalesApellidoPrimero_Sel, "<#Empty#>")==0)));
            AV39TFProfesionalesApellidoPrimero_Sel = (AV54TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV39TFProfesionalesApellidoPrimero_Sel);
            HAW0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Primer Apellido ", ""), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFProfesionalesApellidoPrimero_Sel, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV39TFProfesionalesApellidoPrimero_Sel = (AV54TempBoolean ? "<#Empty#>" : AV39TFProfesionalesApellidoPrimero_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFProfesionalesApellidoPrimero)) )
            {
               HAW0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Primer Apellido ", ""), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFProfesionalesApellidoPrimero, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41TFProfesionalesApellidoSegundo_Sel)) )
         {
            AV54TempBoolean = (bool)(((StringUtil.StrCmp(AV41TFProfesionalesApellidoSegundo_Sel, "<#Empty#>")==0)));
            AV41TFProfesionalesApellidoSegundo_Sel = (AV54TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV41TFProfesionalesApellidoSegundo_Sel);
            HAW0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Segundo Apellido ", ""), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFProfesionalesApellidoSegundo_Sel, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV41TFProfesionalesApellidoSegundo_Sel = (AV54TempBoolean ? "<#Empty#>" : AV41TFProfesionalesApellidoSegundo_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFProfesionalesApellidoSegundo)) )
            {
               HAW0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Segundo Apellido ", ""), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFProfesionalesApellidoSegundo, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TFProfesionalesTelefono_Sel)) )
         {
            AV54TempBoolean = (bool)(((StringUtil.StrCmp(AV43TFProfesionalesTelefono_Sel, "<#Empty#>")==0)));
            AV43TFProfesionalesTelefono_Sel = (AV54TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV43TFProfesionalesTelefono_Sel);
            HAW0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Teléfono", ""), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFProfesionalesTelefono_Sel, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV43TFProfesionalesTelefono_Sel = (AV54TempBoolean ? "<#Empty#>" : AV43TFProfesionalesTelefono_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TFProfesionalesTelefono)) )
            {
               HAW0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Teléfono", ""), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFProfesionalesTelefono, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45TFProfesionalesEmail_Sel)) )
         {
            AV54TempBoolean = (bool)(((StringUtil.StrCmp(AV45TFProfesionalesEmail_Sel, "<#Empty#>")==0)));
            AV45TFProfesionalesEmail_Sel = (AV54TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV45TFProfesionalesEmail_Sel);
            HAW0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Email", ""), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45TFProfesionalesEmail_Sel, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV45TFProfesionalesEmail_Sel = (AV54TempBoolean ? "<#Empty#>" : AV45TFProfesionalesEmail_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44TFProfesionalesEmail)) )
            {
               HAW0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Email", ""), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44TFProfesionalesEmail, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47TFProfesionalesDireccion_Sel)) )
         {
            AV54TempBoolean = (bool)(((StringUtil.StrCmp(AV47TFProfesionalesDireccion_Sel, "<#Empty#>")==0)));
            AV47TFProfesionalesDireccion_Sel = (AV54TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV47TFProfesionalesDireccion_Sel);
            HAW0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Dirección", ""), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47TFProfesionalesDireccion_Sel, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV47TFProfesionalesDireccion_Sel = (AV54TempBoolean ? "<#Empty#>" : AV47TFProfesionalesDireccion_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46TFProfesionalesDireccion)) )
            {
               HAW0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Dirección", ""), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46TFProfesionalesDireccion, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TFEstadosGenericosNombre_Sel)) )
         {
            AV54TempBoolean = (bool)(((StringUtil.StrCmp(AV68TFEstadosGenericosNombre_Sel, "<#Empty#>")==0)));
            AV68TFEstadosGenericosNombre_Sel = (AV54TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV68TFEstadosGenericosNombre_Sel);
            HAW0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68TFEstadosGenericosNombre_Sel, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV68TFEstadosGenericosNombre_Sel = (AV54TempBoolean ? "<#Empty#>" : AV68TFEstadosGenericosNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67TFEstadosGenericosNombre)) )
            {
               HAW0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67TFEstadosGenericosNombre, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HAW0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HAW0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Identidad", ""), 30, Gx_line+10, 110, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Primer Nombre", ""), 114, Gx_line+10, 194, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Segundo Nombre", ""), 198, Gx_line+10, 278, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Primer Apellido ", ""), 282, Gx_line+10, 362, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Segundo Apellido ", ""), 366, Gx_line+10, 446, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Teléfono", ""), 450, Gx_line+10, 530, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Email", ""), 534, Gx_line+10, 615, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Dirección", ""), 619, Gx_line+10, 701, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 705, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV82Profesionaleswwds_1_filterfulltext = AV13FilterFullText;
         AV83Profesionaleswwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV84Profesionaleswwds_3_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV85Profesionaleswwds_4_profesionalesesrut1 = AV69ProfesionalesEsRUT1;
         AV86Profesionaleswwds_5_banconombre1 = AV71BancoNombre1;
         AV87Profesionaleswwds_6_profesionalesprimernombre1 = AV16ProfesionalesPrimerNombre1;
         AV88Profesionaleswwds_7_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV89Profesionaleswwds_8_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV90Profesionaleswwds_9_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV91Profesionaleswwds_10_profesionalesesrut2 = AV74ProfesionalesEsRUT2;
         AV92Profesionaleswwds_11_banconombre2 = AV75BancoNombre2;
         AV93Profesionaleswwds_12_profesionalesprimernombre2 = AV22ProfesionalesPrimerNombre2;
         AV94Profesionaleswwds_13_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV95Profesionaleswwds_14_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV96Profesionaleswwds_15_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV97Profesionaleswwds_16_profesionalesesrut3 = AV76ProfesionalesEsRUT3;
         AV98Profesionaleswwds_17_banconombre3 = AV77BancoNombre3;
         AV99Profesionaleswwds_18_profesionalesprimernombre3 = AV26ProfesionalesPrimerNombre3;
         AV100Profesionaleswwds_19_tfprofesionalesid = AV32TFProfesionalesId;
         AV101Profesionaleswwds_20_tfprofesionalesid_sel = AV33TFProfesionalesId_Sel;
         AV102Profesionaleswwds_21_tfprofesionalesprimernombre = AV34TFProfesionalesPrimerNombre;
         AV103Profesionaleswwds_22_tfprofesionalesprimernombre_sel = AV35TFProfesionalesPrimerNombre_Sel;
         AV104Profesionaleswwds_23_tfprofesionalessegundonombre = AV36TFProfesionalesSegundoNombre;
         AV105Profesionaleswwds_24_tfprofesionalessegundonombre_sel = AV37TFProfesionalesSegundoNombre_Sel;
         AV106Profesionaleswwds_25_tfprofesionalesapellidoprimero = AV38TFProfesionalesApellidoPrimero;
         AV107Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel = AV39TFProfesionalesApellidoPrimero_Sel;
         AV108Profesionaleswwds_27_tfprofesionalesapellidosegundo = AV40TFProfesionalesApellidoSegundo;
         AV109Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel = AV41TFProfesionalesApellidoSegundo_Sel;
         AV110Profesionaleswwds_29_tfprofesionalestelefono = AV42TFProfesionalesTelefono;
         AV111Profesionaleswwds_30_tfprofesionalestelefono_sel = AV43TFProfesionalesTelefono_Sel;
         AV112Profesionaleswwds_31_tfprofesionalesemail = AV44TFProfesionalesEmail;
         AV113Profesionaleswwds_32_tfprofesionalesemail_sel = AV45TFProfesionalesEmail_Sel;
         AV114Profesionaleswwds_33_tfprofesionalesdireccion = AV46TFProfesionalesDireccion;
         AV115Profesionaleswwds_34_tfprofesionalesdireccion_sel = AV47TFProfesionalesDireccion_Sel;
         AV116Profesionaleswwds_35_tfestadosgenericosnombre = AV67TFEstadosGenericosNombre;
         AV117Profesionaleswwds_36_tfestadosgenericosnombre_sel = AV68TFEstadosGenericosNombre_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV82Profesionaleswwds_1_filterfulltext ,
                                              AV83Profesionaleswwds_2_dynamicfiltersselector1 ,
                                              AV85Profesionaleswwds_4_profesionalesesrut1 ,
                                              AV84Profesionaleswwds_3_dynamicfiltersoperator1 ,
                                              AV86Profesionaleswwds_5_banconombre1 ,
                                              AV87Profesionaleswwds_6_profesionalesprimernombre1 ,
                                              AV88Profesionaleswwds_7_dynamicfiltersenabled2 ,
                                              AV89Profesionaleswwds_8_dynamicfiltersselector2 ,
                                              AV91Profesionaleswwds_10_profesionalesesrut2 ,
                                              AV90Profesionaleswwds_9_dynamicfiltersoperator2 ,
                                              AV92Profesionaleswwds_11_banconombre2 ,
                                              AV93Profesionaleswwds_12_profesionalesprimernombre2 ,
                                              AV94Profesionaleswwds_13_dynamicfiltersenabled3 ,
                                              AV95Profesionaleswwds_14_dynamicfiltersselector3 ,
                                              AV97Profesionaleswwds_16_profesionalesesrut3 ,
                                              AV96Profesionaleswwds_15_dynamicfiltersoperator3 ,
                                              AV98Profesionaleswwds_17_banconombre3 ,
                                              AV99Profesionaleswwds_18_profesionalesprimernombre3 ,
                                              AV101Profesionaleswwds_20_tfprofesionalesid_sel ,
                                              AV100Profesionaleswwds_19_tfprofesionalesid ,
                                              AV103Profesionaleswwds_22_tfprofesionalesprimernombre_sel ,
                                              AV102Profesionaleswwds_21_tfprofesionalesprimernombre ,
                                              AV105Profesionaleswwds_24_tfprofesionalessegundonombre_sel ,
                                              AV104Profesionaleswwds_23_tfprofesionalessegundonombre ,
                                              AV107Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel ,
                                              AV106Profesionaleswwds_25_tfprofesionalesapellidoprimero ,
                                              AV109Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel ,
                                              AV108Profesionaleswwds_27_tfprofesionalesapellidosegundo ,
                                              AV111Profesionaleswwds_30_tfprofesionalestelefono_sel ,
                                              AV110Profesionaleswwds_29_tfprofesionalestelefono ,
                                              AV113Profesionaleswwds_32_tfprofesionalesemail_sel ,
                                              AV112Profesionaleswwds_31_tfprofesionalesemail ,
                                              AV115Profesionaleswwds_34_tfprofesionalesdireccion_sel ,
                                              AV114Profesionaleswwds_33_tfprofesionalesdireccion ,
                                              AV117Profesionaleswwds_36_tfestadosgenericosnombre_sel ,
                                              AV116Profesionaleswwds_35_tfestadosgenericosnombre ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A676ProfesionalesEsRUT ,
                                              A674BancoNombre ,
                                              A193ProfesionalesEmail ,
                                              A198ProfesionalesDireccion ,
                                              A109EstadosGenericosNombre ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV82Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Profesionaleswwds_1_filterfulltext), "%", "");
         lV82Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Profesionaleswwds_1_filterfulltext), "%", "");
         lV82Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Profesionaleswwds_1_filterfulltext), "%", "");
         lV82Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Profesionaleswwds_1_filterfulltext), "%", "");
         lV82Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Profesionaleswwds_1_filterfulltext), "%", "");
         lV82Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV82Profesionaleswwds_1_filterfulltext), "%", "");
         lV86Profesionaleswwds_5_banconombre1 = StringUtil.PadR( StringUtil.RTrim( AV86Profesionaleswwds_5_banconombre1), 80, "%");
         lV86Profesionaleswwds_5_banconombre1 = StringUtil.PadR( StringUtil.RTrim( AV86Profesionaleswwds_5_banconombre1), 80, "%");
         lV87Profesionaleswwds_6_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV87Profesionaleswwds_6_profesionalesprimernombre1), 30, "%");
         lV87Profesionaleswwds_6_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV87Profesionaleswwds_6_profesionalesprimernombre1), 30, "%");
         lV92Profesionaleswwds_11_banconombre2 = StringUtil.PadR( StringUtil.RTrim( AV92Profesionaleswwds_11_banconombre2), 80, "%");
         lV92Profesionaleswwds_11_banconombre2 = StringUtil.PadR( StringUtil.RTrim( AV92Profesionaleswwds_11_banconombre2), 80, "%");
         lV93Profesionaleswwds_12_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV93Profesionaleswwds_12_profesionalesprimernombre2), 30, "%");
         lV93Profesionaleswwds_12_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV93Profesionaleswwds_12_profesionalesprimernombre2), 30, "%");
         lV98Profesionaleswwds_17_banconombre3 = StringUtil.PadR( StringUtil.RTrim( AV98Profesionaleswwds_17_banconombre3), 80, "%");
         lV98Profesionaleswwds_17_banconombre3 = StringUtil.PadR( StringUtil.RTrim( AV98Profesionaleswwds_17_banconombre3), 80, "%");
         lV99Profesionaleswwds_18_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV99Profesionaleswwds_18_profesionalesprimernombre3), 30, "%");
         lV99Profesionaleswwds_18_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV99Profesionaleswwds_18_profesionalesprimernombre3), 30, "%");
         lV100Profesionaleswwds_19_tfprofesionalesid = StringUtil.PadR( StringUtil.RTrim( AV100Profesionaleswwds_19_tfprofesionalesid), 20, "%");
         lV102Profesionaleswwds_21_tfprofesionalesprimernombre = StringUtil.PadR( StringUtil.RTrim( AV102Profesionaleswwds_21_tfprofesionalesprimernombre), 30, "%");
         lV104Profesionaleswwds_23_tfprofesionalessegundonombre = StringUtil.PadR( StringUtil.RTrim( AV104Profesionaleswwds_23_tfprofesionalessegundonombre), 30, "%");
         lV106Profesionaleswwds_25_tfprofesionalesapellidoprimero = StringUtil.PadR( StringUtil.RTrim( AV106Profesionaleswwds_25_tfprofesionalesapellidoprimero), 30, "%");
         lV108Profesionaleswwds_27_tfprofesionalesapellidosegundo = StringUtil.PadR( StringUtil.RTrim( AV108Profesionaleswwds_27_tfprofesionalesapellidosegundo), 30, "%");
         lV110Profesionaleswwds_29_tfprofesionalestelefono = StringUtil.PadR( StringUtil.RTrim( AV110Profesionaleswwds_29_tfprofesionalestelefono), 20, "%");
         lV112Profesionaleswwds_31_tfprofesionalesemail = StringUtil.Concat( StringUtil.RTrim( AV112Profesionaleswwds_31_tfprofesionalesemail), "%", "");
         lV114Profesionaleswwds_33_tfprofesionalesdireccion = StringUtil.Concat( StringUtil.RTrim( AV114Profesionaleswwds_33_tfprofesionalesdireccion), "%", "");
         lV116Profesionaleswwds_35_tfestadosgenericosnombre = StringUtil.PadR( StringUtil.RTrim( AV116Profesionaleswwds_35_tfestadosgenericosnombre), 80, "%");
         /* Using cursor P00AW2 */
         pr_default.execute(0, new Object[] {lV82Profesionaleswwds_1_filterfulltext, lV82Profesionaleswwds_1_filterfulltext, lV82Profesionaleswwds_1_filterfulltext, lV82Profesionaleswwds_1_filterfulltext, lV82Profesionaleswwds_1_filterfulltext, lV82Profesionaleswwds_1_filterfulltext, AV85Profesionaleswwds_4_profesionalesesrut1, lV86Profesionaleswwds_5_banconombre1, lV86Profesionaleswwds_5_banconombre1, lV87Profesionaleswwds_6_profesionalesprimernombre1, lV87Profesionaleswwds_6_profesionalesprimernombre1, AV91Profesionaleswwds_10_profesionalesesrut2, lV92Profesionaleswwds_11_banconombre2, lV92Profesionaleswwds_11_banconombre2, lV93Profesionaleswwds_12_profesionalesprimernombre2, lV93Profesionaleswwds_12_profesionalesprimernombre2, AV97Profesionaleswwds_16_profesionalesesrut3, lV98Profesionaleswwds_17_banconombre3, lV98Profesionaleswwds_17_banconombre3, lV99Profesionaleswwds_18_profesionalesprimernombre3, lV99Profesionaleswwds_18_profesionalesprimernombre3, lV100Profesionaleswwds_19_tfprofesionalesid, AV101Profesionaleswwds_20_tfprofesionalesid_sel, lV102Profesionaleswwds_21_tfprofesionalesprimernombre, AV103Profesionaleswwds_22_tfprofesionalesprimernombre_sel, lV104Profesionaleswwds_23_tfprofesionalessegundonombre, AV105Profesionaleswwds_24_tfprofesionalessegundonombre_sel, lV106Profesionaleswwds_25_tfprofesionalesapellidoprimero, AV107Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, lV108Profesionaleswwds_27_tfprofesionalesapellidosegundo, AV109Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, lV110Profesionaleswwds_29_tfprofesionalestelefono, AV111Profesionaleswwds_30_tfprofesionalestelefono_sel, lV112Profesionaleswwds_31_tfprofesionalesemail, AV113Profesionaleswwds_32_tfprofesionalesemail_sel, lV114Profesionaleswwds_33_tfprofesionalesdireccion, AV115Profesionaleswwds_34_tfprofesionalesdireccion_sel, lV116Profesionaleswwds_35_tfestadosgenericosnombre, AV117Profesionaleswwds_36_tfestadosgenericosnombre_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A107EstadosTipo = P00AW2_A107EstadosTipo[0];
            A673BancoId = P00AW2_A673BancoId[0];
            n673BancoId = P00AW2_n673BancoId[0];
            A674BancoNombre = P00AW2_A674BancoNombre[0];
            A109EstadosGenericosNombre = P00AW2_A109EstadosGenericosNombre[0];
            A198ProfesionalesDireccion = P00AW2_A198ProfesionalesDireccion[0];
            A193ProfesionalesEmail = P00AW2_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P00AW2_n193ProfesionalesEmail[0];
            A170ProfesionalesTelefono = P00AW2_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P00AW2_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P00AW2_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P00AW2_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P00AW2_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P00AW2_A120ProfesionalesId[0];
            A676ProfesionalesEsRUT = P00AW2_A676ProfesionalesEsRUT[0];
            n676ProfesionalesEsRUT = P00AW2_n676ProfesionalesEsRUT[0];
            A108EstadosGenericosId = P00AW2_A108EstadosGenericosId[0];
            A674BancoNombre = P00AW2_A674BancoNombre[0];
            A109EstadosGenericosNombre = P00AW2_A109EstadosGenericosNombre[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            if ( A108EstadosGenericosId == 2 )
            {
               HAW0( false, 66) ;
               getPrinter().GxDrawRect(28, Gx_line+0, 789, Gx_line+65, 1, 0, 0, 0, 1, 242, 222, 222, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 221, 75, 57, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A120ProfesionalesId, "")), 30, Gx_line+10, 110, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A166ProfesionalesPrimerNombre, "")), 114, Gx_line+10, 194, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A191ProfesionalesSegundoNombre, "")), 198, Gx_line+10, 278, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A167ProfesionalesApellidoPrimero, "")), 282, Gx_line+10, 362, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A192ProfesionalesApellidoSegundo, "")), 366, Gx_line+10, 446, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A170ProfesionalesTelefono, "")), 450, Gx_line+10, 530, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A193ProfesionalesEmail, "")), 534, Gx_line+10, 615, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A198ProfesionalesDireccion, "")), 619, Gx_line+10, 701, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A109EstadosGenericosNombre, "")), 705, Gx_line+10, 787, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawLine(28, Gx_line+65, 789, Gx_line+65, 1, 220, 220, 220, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+66);
            }
            else if ( A108EstadosGenericosId == 3 )
            {
               HAW0( false, 66) ;
               getPrinter().GxDrawRect(28, Gx_line+0, 789, Gx_line+65, 1, 0, 0, 0, 1, 250, 242, 204, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 251, 110, 82, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A120ProfesionalesId, "")), 30, Gx_line+10, 110, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A166ProfesionalesPrimerNombre, "")), 114, Gx_line+10, 194, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A191ProfesionalesSegundoNombre, "")), 198, Gx_line+10, 278, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A167ProfesionalesApellidoPrimero, "")), 282, Gx_line+10, 362, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A192ProfesionalesApellidoSegundo, "")), 366, Gx_line+10, 446, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A170ProfesionalesTelefono, "")), 450, Gx_line+10, 530, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A193ProfesionalesEmail, "")), 534, Gx_line+10, 615, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A198ProfesionalesDireccion, "")), 619, Gx_line+10, 701, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A109EstadosGenericosNombre, "")), 705, Gx_line+10, 787, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawLine(28, Gx_line+65, 789, Gx_line+65, 1, 220, 220, 220, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+66);
            }
            else
            {
               HAW0( false, 66) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A120ProfesionalesId, "")), 30, Gx_line+10, 110, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A166ProfesionalesPrimerNombre, "")), 114, Gx_line+10, 194, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A191ProfesionalesSegundoNombre, "")), 198, Gx_line+10, 278, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A167ProfesionalesApellidoPrimero, "")), 282, Gx_line+10, 362, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A192ProfesionalesApellidoSegundo, "")), 366, Gx_line+10, 446, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A170ProfesionalesTelefono, "")), 450, Gx_line+10, 530, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A193ProfesionalesEmail, "")), 534, Gx_line+10, 615, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A198ProfesionalesDireccion, "")), 619, Gx_line+10, 701, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A109EstadosGenericosNombre, "")), 705, Gx_line+10, 787, Gx_line+55, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawLine(28, Gx_line+65, 789, Gx_line+65, 1, 220, 220, 220, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+66);
            }
            /* Execute user subroutine: 'AFTERPRINTLINE' */
            S154 ();
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

      protected void S161( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV28Session.Get("ProfesionalesWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ProfesionalesWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("ProfesionalesWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV30GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV30GridState.gxTpr_Ordereddsc;
         AV118GXV1 = 1;
         while ( AV118GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV118GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID") == 0 )
            {
               AV32TFProfesionalesId = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID_SEL") == 0 )
            {
               AV33TFProfesionalesId_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE") == 0 )
            {
               AV34TFProfesionalesPrimerNombre = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE_SEL") == 0 )
            {
               AV35TFProfesionalesPrimerNombre_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESSEGUNDONOMBRE") == 0 )
            {
               AV36TFProfesionalesSegundoNombre = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESSEGUNDONOMBRE_SEL") == 0 )
            {
               AV37TFProfesionalesSegundoNombre_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO") == 0 )
            {
               AV38TFProfesionalesApellidoPrimero = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO_SEL") == 0 )
            {
               AV39TFProfesionalesApellidoPrimero_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOSEGUNDO") == 0 )
            {
               AV40TFProfesionalesApellidoSegundo = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOSEGUNDO_SEL") == 0 )
            {
               AV41TFProfesionalesApellidoSegundo_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESTELEFONO") == 0 )
            {
               AV42TFProfesionalesTelefono = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESTELEFONO_SEL") == 0 )
            {
               AV43TFProfesionalesTelefono_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESEMAIL") == 0 )
            {
               AV44TFProfesionalesEmail = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESEMAIL_SEL") == 0 )
            {
               AV45TFProfesionalesEmail_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESDIRECCION") == 0 )
            {
               AV46TFProfesionalesDireccion = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESDIRECCION_SEL") == 0 )
            {
               AV47TFProfesionalesDireccion_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFESTADOSGENERICOSNOMBRE") == 0 )
            {
               AV67TFEstadosGenericosNombre = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFESTADOSGENERICOSNOMBRE_SEL") == 0 )
            {
               AV68TFEstadosGenericosNombre_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            AV118GXV1 = (int)(AV118GXV1+1);
         }
      }

      protected void S144( )
      {
         /* 'BEFOREPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S154( )
      {
         /* 'AFTERPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S171( )
      {
         /* 'PRINTFOOTER' Routine */
         returnInSub = false;
      }

      protected void HAW0( bool bFoot ,
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
                  AV63PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV60DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+40);
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
               AV58AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV64Phone = "+1 550 8923";
               AV62Mail = "info@mail.com";
               AV66Website = "http://www.web.com";
               AV55AddressLine1 = "French Boulevard 2859";
               AV56AddressLine2 = "Downtown";
               AV57AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+128);
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
         AV78Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV65Title = "";
         AV13FilterFullText = "";
         AV30GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV71BancoNombre1 = "";
         AV72FilterBancoNombreDescription = "";
         AV73BancoNombre = "";
         AV16ProfesionalesPrimerNombre1 = "";
         AV17FilterProfesionalesPrimerNombreDescription = "";
         AV18ProfesionalesPrimerNombre = "";
         AV20DynamicFiltersSelector2 = "";
         AV75BancoNombre2 = "";
         AV22ProfesionalesPrimerNombre2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV77BancoNombre3 = "";
         AV26ProfesionalesPrimerNombre3 = "";
         AV33TFProfesionalesId_Sel = "";
         AV32TFProfesionalesId = "";
         AV35TFProfesionalesPrimerNombre_Sel = "";
         AV34TFProfesionalesPrimerNombre = "";
         AV37TFProfesionalesSegundoNombre_Sel = "";
         AV36TFProfesionalesSegundoNombre = "";
         AV39TFProfesionalesApellidoPrimero_Sel = "";
         AV38TFProfesionalesApellidoPrimero = "";
         AV41TFProfesionalesApellidoSegundo_Sel = "";
         AV40TFProfesionalesApellidoSegundo = "";
         AV43TFProfesionalesTelefono_Sel = "";
         AV42TFProfesionalesTelefono = "";
         AV45TFProfesionalesEmail_Sel = "";
         AV44TFProfesionalesEmail = "";
         AV47TFProfesionalesDireccion_Sel = "";
         AV46TFProfesionalesDireccion = "";
         AV68TFEstadosGenericosNombre_Sel = "";
         AV67TFEstadosGenericosNombre = "";
         AV82Profesionaleswwds_1_filterfulltext = "";
         AV83Profesionaleswwds_2_dynamicfiltersselector1 = "";
         AV86Profesionaleswwds_5_banconombre1 = "";
         AV87Profesionaleswwds_6_profesionalesprimernombre1 = "";
         AV89Profesionaleswwds_8_dynamicfiltersselector2 = "";
         AV92Profesionaleswwds_11_banconombre2 = "";
         AV93Profesionaleswwds_12_profesionalesprimernombre2 = "";
         AV95Profesionaleswwds_14_dynamicfiltersselector3 = "";
         AV98Profesionaleswwds_17_banconombre3 = "";
         AV99Profesionaleswwds_18_profesionalesprimernombre3 = "";
         AV100Profesionaleswwds_19_tfprofesionalesid = "";
         AV101Profesionaleswwds_20_tfprofesionalesid_sel = "";
         AV102Profesionaleswwds_21_tfprofesionalesprimernombre = "";
         AV103Profesionaleswwds_22_tfprofesionalesprimernombre_sel = "";
         AV104Profesionaleswwds_23_tfprofesionalessegundonombre = "";
         AV105Profesionaleswwds_24_tfprofesionalessegundonombre_sel = "";
         AV106Profesionaleswwds_25_tfprofesionalesapellidoprimero = "";
         AV107Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel = "";
         AV108Profesionaleswwds_27_tfprofesionalesapellidosegundo = "";
         AV109Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel = "";
         AV110Profesionaleswwds_29_tfprofesionalestelefono = "";
         AV111Profesionaleswwds_30_tfprofesionalestelefono_sel = "";
         AV112Profesionaleswwds_31_tfprofesionalesemail = "";
         AV113Profesionaleswwds_32_tfprofesionalesemail_sel = "";
         AV114Profesionaleswwds_33_tfprofesionalesdireccion = "";
         AV115Profesionaleswwds_34_tfprofesionalesdireccion_sel = "";
         AV116Profesionaleswwds_35_tfestadosgenericosnombre = "";
         AV117Profesionaleswwds_36_tfestadosgenericosnombre_sel = "";
         lV82Profesionaleswwds_1_filterfulltext = "";
         lV86Profesionaleswwds_5_banconombre1 = "";
         lV87Profesionaleswwds_6_profesionalesprimernombre1 = "";
         lV92Profesionaleswwds_11_banconombre2 = "";
         lV93Profesionaleswwds_12_profesionalesprimernombre2 = "";
         lV98Profesionaleswwds_17_banconombre3 = "";
         lV99Profesionaleswwds_18_profesionalesprimernombre3 = "";
         lV100Profesionaleswwds_19_tfprofesionalesid = "";
         lV102Profesionaleswwds_21_tfprofesionalesprimernombre = "";
         lV104Profesionaleswwds_23_tfprofesionalessegundonombre = "";
         lV106Profesionaleswwds_25_tfprofesionalesapellidoprimero = "";
         lV108Profesionaleswwds_27_tfprofesionalesapellidosegundo = "";
         lV110Profesionaleswwds_29_tfprofesionalestelefono = "";
         lV112Profesionaleswwds_31_tfprofesionalesemail = "";
         lV114Profesionaleswwds_33_tfprofesionalesdireccion = "";
         lV116Profesionaleswwds_35_tfestadosgenericosnombre = "";
         A120ProfesionalesId = "";
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A192ProfesionalesApellidoSegundo = "";
         A170ProfesionalesTelefono = "";
         A674BancoNombre = "";
         A193ProfesionalesEmail = "";
         A198ProfesionalesDireccion = "";
         A109EstadosGenericosNombre = "";
         P00AW2_A107EstadosTipo = new string[] {""} ;
         P00AW2_A673BancoId = new long[1] ;
         P00AW2_n673BancoId = new bool[] {false} ;
         P00AW2_A674BancoNombre = new string[] {""} ;
         P00AW2_A109EstadosGenericosNombre = new string[] {""} ;
         P00AW2_A198ProfesionalesDireccion = new string[] {""} ;
         P00AW2_A193ProfesionalesEmail = new string[] {""} ;
         P00AW2_n193ProfesionalesEmail = new bool[] {false} ;
         P00AW2_A170ProfesionalesTelefono = new string[] {""} ;
         P00AW2_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P00AW2_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00AW2_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P00AW2_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00AW2_A120ProfesionalesId = new string[] {""} ;
         P00AW2_A676ProfesionalesEsRUT = new bool[] {false} ;
         P00AW2_n676ProfesionalesEsRUT = new bool[] {false} ;
         P00AW2_A108EstadosGenericosId = new int[1] ;
         A107EstadosTipo = "";
         AV28Session = context.GetSession();
         AV31GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV63PageInfo = "";
         AV60DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV58AppName = "";
         AV64Phone = "";
         AV62Mail = "";
         AV66Website = "";
         AV55AddressLine1 = "";
         AV56AddressLine2 = "";
         AV57AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.profesionaleswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00AW2_A107EstadosTipo, P00AW2_A673BancoId, P00AW2_n673BancoId, P00AW2_A674BancoNombre, P00AW2_A109EstadosGenericosNombre, P00AW2_A198ProfesionalesDireccion, P00AW2_A193ProfesionalesEmail, P00AW2_n193ProfesionalesEmail, P00AW2_A170ProfesionalesTelefono, P00AW2_A192ProfesionalesApellidoSegundo,
               P00AW2_A167ProfesionalesApellidoPrimero, P00AW2_A191ProfesionalesSegundoNombre, P00AW2_A166ProfesionalesPrimerNombre, P00AW2_A120ProfesionalesId, P00AW2_A676ProfesionalesEsRUT, P00AW2_n676ProfesionalesEsRUT, P00AW2_A108EstadosGenericosId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV78Pgmname = "ProfesionalesWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV78Pgmname = "ProfesionalesWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV15DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV25DynamicFiltersOperator3 ;
      private short AV84Profesionaleswwds_3_dynamicfiltersoperator1 ;
      private short AV90Profesionaleswwds_9_dynamicfiltersoperator2 ;
      private short AV96Profesionaleswwds_15_dynamicfiltersoperator3 ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A108EstadosGenericosId ;
      private int AV118GXV1 ;
      private long A673BancoId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV78Pgmname ;
      private string GXEncryptionTmp ;
      private string AV71BancoNombre1 ;
      private string AV73BancoNombre ;
      private string AV16ProfesionalesPrimerNombre1 ;
      private string AV18ProfesionalesPrimerNombre ;
      private string AV75BancoNombre2 ;
      private string AV22ProfesionalesPrimerNombre2 ;
      private string AV77BancoNombre3 ;
      private string AV26ProfesionalesPrimerNombre3 ;
      private string AV33TFProfesionalesId_Sel ;
      private string AV32TFProfesionalesId ;
      private string AV35TFProfesionalesPrimerNombre_Sel ;
      private string AV34TFProfesionalesPrimerNombre ;
      private string AV37TFProfesionalesSegundoNombre_Sel ;
      private string AV36TFProfesionalesSegundoNombre ;
      private string AV39TFProfesionalesApellidoPrimero_Sel ;
      private string AV38TFProfesionalesApellidoPrimero ;
      private string AV41TFProfesionalesApellidoSegundo_Sel ;
      private string AV40TFProfesionalesApellidoSegundo ;
      private string AV43TFProfesionalesTelefono_Sel ;
      private string AV42TFProfesionalesTelefono ;
      private string AV68TFEstadosGenericosNombre_Sel ;
      private string AV67TFEstadosGenericosNombre ;
      private string AV86Profesionaleswwds_5_banconombre1 ;
      private string AV87Profesionaleswwds_6_profesionalesprimernombre1 ;
      private string AV92Profesionaleswwds_11_banconombre2 ;
      private string AV93Profesionaleswwds_12_profesionalesprimernombre2 ;
      private string AV98Profesionaleswwds_17_banconombre3 ;
      private string AV99Profesionaleswwds_18_profesionalesprimernombre3 ;
      private string AV100Profesionaleswwds_19_tfprofesionalesid ;
      private string AV101Profesionaleswwds_20_tfprofesionalesid_sel ;
      private string AV102Profesionaleswwds_21_tfprofesionalesprimernombre ;
      private string AV103Profesionaleswwds_22_tfprofesionalesprimernombre_sel ;
      private string AV104Profesionaleswwds_23_tfprofesionalessegundonombre ;
      private string AV105Profesionaleswwds_24_tfprofesionalessegundonombre_sel ;
      private string AV106Profesionaleswwds_25_tfprofesionalesapellidoprimero ;
      private string AV107Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel ;
      private string AV108Profesionaleswwds_27_tfprofesionalesapellidosegundo ;
      private string AV109Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel ;
      private string AV110Profesionaleswwds_29_tfprofesionalestelefono ;
      private string AV111Profesionaleswwds_30_tfprofesionalestelefono_sel ;
      private string AV116Profesionaleswwds_35_tfestadosgenericosnombre ;
      private string AV117Profesionaleswwds_36_tfestadosgenericosnombre_sel ;
      private string lV86Profesionaleswwds_5_banconombre1 ;
      private string lV87Profesionaleswwds_6_profesionalesprimernombre1 ;
      private string lV92Profesionaleswwds_11_banconombre2 ;
      private string lV93Profesionaleswwds_12_profesionalesprimernombre2 ;
      private string lV98Profesionaleswwds_17_banconombre3 ;
      private string lV99Profesionaleswwds_18_profesionalesprimernombre3 ;
      private string lV100Profesionaleswwds_19_tfprofesionalesid ;
      private string lV102Profesionaleswwds_21_tfprofesionalesprimernombre ;
      private string lV104Profesionaleswwds_23_tfprofesionalessegundonombre ;
      private string lV106Profesionaleswwds_25_tfprofesionalesapellidoprimero ;
      private string lV108Profesionaleswwds_27_tfprofesionalesapellidosegundo ;
      private string lV110Profesionaleswwds_29_tfprofesionalestelefono ;
      private string lV116Profesionaleswwds_35_tfestadosgenericosnombre ;
      private string A120ProfesionalesId ;
      private string A166ProfesionalesPrimerNombre ;
      private string A191ProfesionalesSegundoNombre ;
      private string A167ProfesionalesApellidoPrimero ;
      private string A192ProfesionalesApellidoSegundo ;
      private string A170ProfesionalesTelefono ;
      private string A674BancoNombre ;
      private string A109EstadosGenericosNombre ;
      private string A107EstadosTipo ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV69ProfesionalesEsRUT1 ;
      private bool AV70ProfesionalesEsRUT ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV74ProfesionalesEsRUT2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV76ProfesionalesEsRUT3 ;
      private bool AV54TempBoolean ;
      private bool AV85Profesionaleswwds_4_profesionalesesrut1 ;
      private bool AV88Profesionaleswwds_7_dynamicfiltersenabled2 ;
      private bool AV91Profesionaleswwds_10_profesionalesesrut2 ;
      private bool AV94Profesionaleswwds_13_dynamicfiltersenabled3 ;
      private bool AV97Profesionaleswwds_16_profesionalesesrut3 ;
      private bool A676ProfesionalesEsRUT ;
      private bool AV12OrderedDsc ;
      private bool n673BancoId ;
      private bool n193ProfesionalesEmail ;
      private bool n676ProfesionalesEsRUT ;
      private string AV65Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV72FilterBancoNombreDescription ;
      private string AV17FilterProfesionalesPrimerNombreDescription ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV45TFProfesionalesEmail_Sel ;
      private string AV44TFProfesionalesEmail ;
      private string AV47TFProfesionalesDireccion_Sel ;
      private string AV46TFProfesionalesDireccion ;
      private string AV82Profesionaleswwds_1_filterfulltext ;
      private string AV83Profesionaleswwds_2_dynamicfiltersselector1 ;
      private string AV89Profesionaleswwds_8_dynamicfiltersselector2 ;
      private string AV95Profesionaleswwds_14_dynamicfiltersselector3 ;
      private string AV112Profesionaleswwds_31_tfprofesionalesemail ;
      private string AV113Profesionaleswwds_32_tfprofesionalesemail_sel ;
      private string AV114Profesionaleswwds_33_tfprofesionalesdireccion ;
      private string AV115Profesionaleswwds_34_tfprofesionalesdireccion_sel ;
      private string lV82Profesionaleswwds_1_filterfulltext ;
      private string lV112Profesionaleswwds_31_tfprofesionalesemail ;
      private string lV114Profesionaleswwds_33_tfprofesionalesdireccion ;
      private string A193ProfesionalesEmail ;
      private string A198ProfesionalesDireccion ;
      private string AV63PageInfo ;
      private string AV60DateInfo ;
      private string AV58AppName ;
      private string AV64Phone ;
      private string AV62Mail ;
      private string AV66Website ;
      private string AV55AddressLine1 ;
      private string AV56AddressLine2 ;
      private string AV57AddressLine3 ;
      private IGxSession AV28Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private string[] P00AW2_A107EstadosTipo ;
      private long[] P00AW2_A673BancoId ;
      private bool[] P00AW2_n673BancoId ;
      private string[] P00AW2_A674BancoNombre ;
      private string[] P00AW2_A109EstadosGenericosNombre ;
      private string[] P00AW2_A198ProfesionalesDireccion ;
      private string[] P00AW2_A193ProfesionalesEmail ;
      private bool[] P00AW2_n193ProfesionalesEmail ;
      private string[] P00AW2_A170ProfesionalesTelefono ;
      private string[] P00AW2_A192ProfesionalesApellidoSegundo ;
      private string[] P00AW2_A167ProfesionalesApellidoPrimero ;
      private string[] P00AW2_A191ProfesionalesSegundoNombre ;
      private string[] P00AW2_A166ProfesionalesPrimerNombre ;
      private string[] P00AW2_A120ProfesionalesId ;
      private bool[] P00AW2_A676ProfesionalesEsRUT ;
      private bool[] P00AW2_n676ProfesionalesEsRUT ;
      private int[] P00AW2_A108EstadosGenericosId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
   }

   public class profesionaleswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AW2( IGxContext context ,
                                             string AV82Profesionaleswwds_1_filterfulltext ,
                                             string AV83Profesionaleswwds_2_dynamicfiltersselector1 ,
                                             bool AV85Profesionaleswwds_4_profesionalesesrut1 ,
                                             short AV84Profesionaleswwds_3_dynamicfiltersoperator1 ,
                                             string AV86Profesionaleswwds_5_banconombre1 ,
                                             string AV87Profesionaleswwds_6_profesionalesprimernombre1 ,
                                             bool AV88Profesionaleswwds_7_dynamicfiltersenabled2 ,
                                             string AV89Profesionaleswwds_8_dynamicfiltersselector2 ,
                                             bool AV91Profesionaleswwds_10_profesionalesesrut2 ,
                                             short AV90Profesionaleswwds_9_dynamicfiltersoperator2 ,
                                             string AV92Profesionaleswwds_11_banconombre2 ,
                                             string AV93Profesionaleswwds_12_profesionalesprimernombre2 ,
                                             bool AV94Profesionaleswwds_13_dynamicfiltersenabled3 ,
                                             string AV95Profesionaleswwds_14_dynamicfiltersselector3 ,
                                             bool AV97Profesionaleswwds_16_profesionalesesrut3 ,
                                             short AV96Profesionaleswwds_15_dynamicfiltersoperator3 ,
                                             string AV98Profesionaleswwds_17_banconombre3 ,
                                             string AV99Profesionaleswwds_18_profesionalesprimernombre3 ,
                                             string AV101Profesionaleswwds_20_tfprofesionalesid_sel ,
                                             string AV100Profesionaleswwds_19_tfprofesionalesid ,
                                             string AV103Profesionaleswwds_22_tfprofesionalesprimernombre_sel ,
                                             string AV102Profesionaleswwds_21_tfprofesionalesprimernombre ,
                                             string AV105Profesionaleswwds_24_tfprofesionalessegundonombre_sel ,
                                             string AV104Profesionaleswwds_23_tfprofesionalessegundonombre ,
                                             string AV107Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel ,
                                             string AV106Profesionaleswwds_25_tfprofesionalesapellidoprimero ,
                                             string AV109Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel ,
                                             string AV108Profesionaleswwds_27_tfprofesionalesapellidosegundo ,
                                             string AV111Profesionaleswwds_30_tfprofesionalestelefono_sel ,
                                             string AV110Profesionaleswwds_29_tfprofesionalestelefono ,
                                             string AV113Profesionaleswwds_32_tfprofesionalesemail_sel ,
                                             string AV112Profesionaleswwds_31_tfprofesionalesemail ,
                                             string AV115Profesionaleswwds_34_tfprofesionalesdireccion_sel ,
                                             string AV114Profesionaleswwds_33_tfprofesionalesdireccion ,
                                             string AV117Profesionaleswwds_36_tfestadosgenericosnombre_sel ,
                                             string AV116Profesionaleswwds_35_tfestadosgenericosnombre ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             bool A676ProfesionalesEsRUT ,
                                             string A674BancoNombre ,
                                             string A193ProfesionalesEmail ,
                                             string A198ProfesionalesDireccion ,
                                             string A109EstadosGenericosNombre ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[39];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[EstadosTipo], T1.[BancoId], T2.[BancoNombre], T3.[EstadosGenericosNombre], T1.[ProfesionalesDireccion], T1.[ProfesionalesEmail], T1.[ProfesionalesTelefono], T1.[ProfesionalesApellidoSegundo], T1.[ProfesionalesApellidoPrimero], T1.[ProfesionalesSegundoNombre], T1.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T1.[ProfesionalesEsRUT], T1.[EstadosGenericosId] FROM (([Profesionales] T1 LEFT JOIN [Banco] T2 ON T2.[BancoId] = T1.[BancoId]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T1.[EstadosTipo] AND T3.[EstadosGenericosId] = T1.[EstadosGenericosId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Profesionaleswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( UPPER(T1.[ProfesionalesId]) like '%' + UPPER(@lV82Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV82Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesSegundoNombre]) like '%' + UPPER(@lV82Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesApellidoPrimero]) like '%' + UPPER(@lV82Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesApellidoSegundo]) like '%' + UPPER(@lV82Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesTelefono]) like '%' + UPPER(@lV82Profesionaleswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
            GXv_int2[4] = 1;
            GXv_int2[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV83Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV85Profesionaleswwds_4_profesionalesesrut1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV85Profesionaleswwds_4_profesionalesesrut1)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV83Profesionaleswwds_2_dynamicfiltersselector1, "BANCONOMBRE") == 0 ) && ( AV84Profesionaleswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profesionaleswwds_5_banconombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[BancoNombre]) like UPPER(@lV86Profesionaleswwds_5_banconombre1))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV83Profesionaleswwds_2_dynamicfiltersselector1, "BANCONOMBRE") == 0 ) && ( AV84Profesionaleswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profesionaleswwds_5_banconombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[BancoNombre]) like '%' + UPPER(@lV86Profesionaleswwds_5_banconombre1))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV83Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV84Profesionaleswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Profesionaleswwds_6_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV87Profesionaleswwds_6_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV83Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV84Profesionaleswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Profesionaleswwds_6_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV87Profesionaleswwds_6_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( AV88Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV91Profesionaleswwds_10_profesionalesesrut2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV91Profesionaleswwds_10_profesionalesesrut2)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( AV88Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Profesionaleswwds_8_dynamicfiltersselector2, "BANCONOMBRE") == 0 ) && ( AV90Profesionaleswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profesionaleswwds_11_banconombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[BancoNombre]) like UPPER(@lV92Profesionaleswwds_11_banconombre2))");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( AV88Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Profesionaleswwds_8_dynamicfiltersselector2, "BANCONOMBRE") == 0 ) && ( AV90Profesionaleswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profesionaleswwds_11_banconombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[BancoNombre]) like '%' + UPPER(@lV92Profesionaleswwds_11_banconombre2))");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( AV88Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV90Profesionaleswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Profesionaleswwds_12_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV93Profesionaleswwds_12_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( AV88Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV90Profesionaleswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Profesionaleswwds_12_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV93Profesionaleswwds_12_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( AV94Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV95Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV97Profesionaleswwds_16_profesionalesesrut3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV97Profesionaleswwds_16_profesionalesesrut3)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( AV94Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV95Profesionaleswwds_14_dynamicfiltersselector3, "BANCONOMBRE") == 0 ) && ( AV96Profesionaleswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Profesionaleswwds_17_banconombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[BancoNombre]) like UPPER(@lV98Profesionaleswwds_17_banconombre3))");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( AV94Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV95Profesionaleswwds_14_dynamicfiltersselector3, "BANCONOMBRE") == 0 ) && ( AV96Profesionaleswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Profesionaleswwds_17_banconombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[BancoNombre]) like '%' + UPPER(@lV98Profesionaleswwds_17_banconombre3))");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( AV94Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV95Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV96Profesionaleswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Profesionaleswwds_18_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV99Profesionaleswwds_18_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( AV94Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV95Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV96Profesionaleswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Profesionaleswwds_18_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV99Profesionaleswwds_18_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Profesionaleswwds_20_tfprofesionalesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionaleswwds_19_tfprofesionalesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV100Profesionaleswwds_19_tfprofesionalesid))");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Profesionaleswwds_20_tfprofesionalesid_sel)) && ! ( StringUtil.StrCmp(AV101Profesionaleswwds_20_tfprofesionalesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV101Profesionaleswwds_20_tfprofesionalesid_sel)");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( StringUtil.StrCmp(AV101Profesionaleswwds_20_tfprofesionalesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV103Profesionaleswwds_22_tfprofesionalesprimernombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Profesionaleswwds_21_tfprofesionalesprimernombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV102Profesionaleswwds_21_tfprofesionalesprimernombre))");
         }
         else
         {
            GXv_int2[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Profesionaleswwds_22_tfprofesionalesprimernombre_sel)) && ! ( StringUtil.StrCmp(AV103Profesionaleswwds_22_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesPrimerNombre] = @AV103Profesionaleswwds_22_tfprofesionalesprimernombre_sel)");
         }
         else
         {
            GXv_int2[24] = 1;
         }
         if ( StringUtil.StrCmp(AV103Profesionaleswwds_22_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV105Profesionaleswwds_24_tfprofesionalessegundonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionaleswwds_23_tfprofesionalessegundonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesSegundoNombre]) like UPPER(@lV104Profesionaleswwds_23_tfprofesionalessegundonombre))");
         }
         else
         {
            GXv_int2[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Profesionaleswwds_24_tfprofesionalessegundonombre_sel)) && ! ( StringUtil.StrCmp(AV105Profesionaleswwds_24_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesSegundoNombre] = @AV105Profesionaleswwds_24_tfprofesionalessegundonombre_sel)");
         }
         else
         {
            GXv_int2[26] = 1;
         }
         if ( StringUtil.StrCmp(AV105Profesionaleswwds_24_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV107Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Profesionaleswwds_25_tfprofesionalesapellidoprimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesApellidoPrimero]) like UPPER(@lV106Profesionaleswwds_25_tfprofesionalesapellidoprimero))");
         }
         else
         {
            GXv_int2[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)) && ! ( StringUtil.StrCmp(AV107Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesApellidoPrimero] = @AV107Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)");
         }
         else
         {
            GXv_int2[28] = 1;
         }
         if ( StringUtil.StrCmp(AV107Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV109Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Profesionaleswwds_27_tfprofesionalesapellidosegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesApellidoSegundo]) like UPPER(@lV108Profesionaleswwds_27_tfprofesionalesapellidosegundo))");
         }
         else
         {
            GXv_int2[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)) && ! ( StringUtil.StrCmp(AV109Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesApellidoSegundo] = @AV109Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)");
         }
         else
         {
            GXv_int2[30] = 1;
         }
         if ( StringUtil.StrCmp(AV109Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV111Profesionaleswwds_30_tfprofesionalestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionaleswwds_29_tfprofesionalestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesTelefono]) like UPPER(@lV110Profesionaleswwds_29_tfprofesionalestelefono))");
         }
         else
         {
            GXv_int2[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Profesionaleswwds_30_tfprofesionalestelefono_sel)) && ! ( StringUtil.StrCmp(AV111Profesionaleswwds_30_tfprofesionalestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesTelefono] = @AV111Profesionaleswwds_30_tfprofesionalestelefono_sel)");
         }
         else
         {
            GXv_int2[32] = 1;
         }
         if ( StringUtil.StrCmp(AV111Profesionaleswwds_30_tfprofesionalestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Profesionaleswwds_32_tfprofesionalesemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Profesionaleswwds_31_tfprofesionalesemail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesEmail]) like UPPER(@lV112Profesionaleswwds_31_tfprofesionalesemail))");
         }
         else
         {
            GXv_int2[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Profesionaleswwds_32_tfprofesionalesemail_sel)) && ! ( StringUtil.StrCmp(AV113Profesionaleswwds_32_tfprofesionalesemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEmail] = @AV113Profesionaleswwds_32_tfprofesionalesemail_sel)");
         }
         else
         {
            GXv_int2[34] = 1;
         }
         if ( StringUtil.StrCmp(AV113Profesionaleswwds_32_tfprofesionalesemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEmail] IS NULL or (T1.[ProfesionalesEmail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV115Profesionaleswwds_34_tfprofesionalesdireccion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Profesionaleswwds_33_tfprofesionalesdireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesDireccion]) like UPPER(@lV114Profesionaleswwds_33_tfprofesionalesdireccion))");
         }
         else
         {
            GXv_int2[35] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Profesionaleswwds_34_tfprofesionalesdireccion_sel)) && ! ( StringUtil.StrCmp(AV115Profesionaleswwds_34_tfprofesionalesdireccion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesDireccion] = @AV115Profesionaleswwds_34_tfprofesionalesdireccion_sel)");
         }
         else
         {
            GXv_int2[36] = 1;
         }
         if ( StringUtil.StrCmp(AV115Profesionaleswwds_34_tfprofesionalesdireccion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesDireccion] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV117Profesionaleswwds_36_tfestadosgenericosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Profesionaleswwds_35_tfestadosgenericosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[EstadosGenericosNombre]) like UPPER(@lV116Profesionaleswwds_35_tfestadosgenericosnombre))");
         }
         else
         {
            GXv_int2[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Profesionaleswwds_36_tfestadosgenericosnombre_sel)) && ! ( StringUtil.StrCmp(AV117Profesionaleswwds_36_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[EstadosGenericosNombre] = @AV117Profesionaleswwds_36_tfestadosgenericosnombre_sel)");
         }
         else
         {
            GXv_int2[38] = 1;
         }
         if ( StringUtil.StrCmp(AV117Profesionaleswwds_36_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[EstadosGenericosNombre] = ''))");
         }
         scmdbuf += sWhereString;
         if ( AV11OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesEsRUT]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesPrimerNombre]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesPrimerNombre] DESC";
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
            scmdbuf += " ORDER BY T1.[ProfesionalesSegundoNombre]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesSegundoNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesApellidoPrimero]";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesApellidoPrimero] DESC";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesApellidoSegundo]";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesApellidoSegundo] DESC";
         }
         else if ( ( AV11OrderedBy == 7 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesTelefono]";
         }
         else if ( ( AV11OrderedBy == 7 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesTelefono] DESC";
         }
         else if ( ( AV11OrderedBy == 8 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesEmail]";
         }
         else if ( ( AV11OrderedBy == 8 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesEmail] DESC";
         }
         else if ( ( AV11OrderedBy == 9 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesDireccion]";
         }
         else if ( ( AV11OrderedBy == 9 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfesionalesDireccion] DESC";
         }
         else if ( ( AV11OrderedBy == 10 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[EstadosGenericosNombre]";
         }
         else if ( ( AV11OrderedBy == 10 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[EstadosGenericosNombre] DESC";
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
                     return conditional_P00AW2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (bool)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (short)dynConstraints[47] , (bool)dynConstraints[48] );
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
          Object[] prmP00AW2;
          prmP00AW2 = new Object[] {
          new ParDef("@lV82Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV82Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV82Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV82Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV82Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV82Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV85Profesionaleswwds_4_profesionalesesrut1",GXType.Boolean,4,0) ,
          new ParDef("@lV86Profesionaleswwds_5_banconombre1",GXType.Char,80,0) ,
          new ParDef("@lV86Profesionaleswwds_5_banconombre1",GXType.Char,80,0) ,
          new ParDef("@lV87Profesionaleswwds_6_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@lV87Profesionaleswwds_6_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@AV91Profesionaleswwds_10_profesionalesesrut2",GXType.Boolean,4,0) ,
          new ParDef("@lV92Profesionaleswwds_11_banconombre2",GXType.Char,80,0) ,
          new ParDef("@lV92Profesionaleswwds_11_banconombre2",GXType.Char,80,0) ,
          new ParDef("@lV93Profesionaleswwds_12_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@lV93Profesionaleswwds_12_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@AV97Profesionaleswwds_16_profesionalesesrut3",GXType.Boolean,4,0) ,
          new ParDef("@lV98Profesionaleswwds_17_banconombre3",GXType.Char,80,0) ,
          new ParDef("@lV98Profesionaleswwds_17_banconombre3",GXType.Char,80,0) ,
          new ParDef("@lV99Profesionaleswwds_18_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV99Profesionaleswwds_18_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV100Profesionaleswwds_19_tfprofesionalesid",GXType.Char,20,0) ,
          new ParDef("@AV101Profesionaleswwds_20_tfprofesionalesid_sel",GXType.Char,20,0) ,
          new ParDef("@lV102Profesionaleswwds_21_tfprofesionalesprimernombre",GXType.Char,30,0) ,
          new ParDef("@AV103Profesionaleswwds_22_tfprofesionalesprimernombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV104Profesionaleswwds_23_tfprofesionalessegundonombre",GXType.Char,30,0) ,
          new ParDef("@AV105Profesionaleswwds_24_tfprofesionalessegundonombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV106Profesionaleswwds_25_tfprofesionalesapellidoprimero",GXType.Char,30,0) ,
          new ParDef("@AV107Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel",GXType.NChar,30,0) ,
          new ParDef("@lV108Profesionaleswwds_27_tfprofesionalesapellidosegundo",GXType.Char,30,0) ,
          new ParDef("@AV109Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel",GXType.NChar,30,0) ,
          new ParDef("@lV110Profesionaleswwds_29_tfprofesionalestelefono",GXType.Char,20,0) ,
          new ParDef("@AV111Profesionaleswwds_30_tfprofesionalestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV112Profesionaleswwds_31_tfprofesionalesemail",GXType.VarChar,100,0) ,
          new ParDef("@AV113Profesionaleswwds_32_tfprofesionalesemail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV114Profesionaleswwds_33_tfprofesionalesdireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV115Profesionaleswwds_34_tfprofesionalesdireccion_sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV116Profesionaleswwds_35_tfestadosgenericosnombre",GXType.Char,80,0) ,
          new ParDef("@AV117Profesionaleswwds_36_tfestadosgenericosnombre_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AW2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AW2,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 80);
                ((string[]) buf[4])[0] = rslt.getString(4, 80);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 20);
                ((string[]) buf[9])[0] = rslt.getString(8, 30);
                ((string[]) buf[10])[0] = rslt.getString(9, 30);
                ((string[]) buf[11])[0] = rslt.getString(10, 30);
                ((string[]) buf[12])[0] = rslt.getString(11, 30);
                ((string[]) buf[13])[0] = rslt.getString(12, 20);
                ((bool[]) buf[14])[0] = rslt.getBool(13);
                ((bool[]) buf[15])[0] = rslt.wasNull(13);
                ((int[]) buf[16])[0] = rslt.getInt(14);
                return;
       }
    }

 }

}
