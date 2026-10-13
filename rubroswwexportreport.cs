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
   public class rubroswwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public rubroswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public rubroswwexportreport( IGxContext context )
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
         setOutputFileName("RubrosWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWRubros", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV61Pgmname));
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
               AV57Title = context.GetMessage( "Lista de Rubros", "");
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
            H4B0( true, 0) ;
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
            H4B0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 143, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 143, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV27GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "RUBROSNOMBRE") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV27GridStateDynamicFilter.gxTpr_Operator;
               AV16RubrosNombre1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16RubrosNombre1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterRubrosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterRubrosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV18RubrosNombre = AV16RubrosNombre1;
                  H4B0( false, 19) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterRubrosNombreDescription, "")), 25, Gx_line+0, 143, Gx_line+14, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18RubrosNombre, "")), 143, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
               }
            }
            if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV19DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "RUBROSNOMBRE") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV27GridStateDynamicFilter.gxTpr_Operator;
                  AV22RubrosNombre2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22RubrosNombre2)) )
                  {
                     if ( AV21DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterRubrosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV21DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterRubrosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV18RubrosNombre = AV22RubrosNombre2;
                     H4B0( false, 19) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterRubrosNombreDescription, "")), 25, Gx_line+0, 143, Gx_line+14, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18RubrosNombre, "")), 143, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                  }
               }
               if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "RUBROSNOMBRE") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV27GridStateDynamicFilter.gxTpr_Operator;
                     AV26RubrosNombre3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26RubrosNombre3)) )
                     {
                        if ( AV25DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterRubrosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV25DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterRubrosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV18RubrosNombre = AV26RubrosNombre3;
                        H4B0( false, 19) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterRubrosNombreDescription, "")), 25, Gx_line+0, 143, Gx_line+14, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18RubrosNombre, "")), 143, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV33TFRubrosId) && (0==AV34TFRubrosId_To) ) )
         {
            H4B0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Rubro", ""), 25, Gx_line+0, 143, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV33TFRubrosId), "ZZZ9")), 143, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV42TFRubrosId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H4B0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFRubrosId_To_Description, "")), 25, Gx_line+0, 143, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV34TFRubrosId_To), "ZZZ9")), 143, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFRubrosNombre_Sel)) )
         {
            AV45TempBoolean = (bool)(((StringUtil.StrCmp(AV36TFRubrosNombre_Sel, "<#Empty#>")==0)));
            AV36TFRubrosNombre_Sel = (AV45TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV36TFRubrosNombre_Sel);
            H4B0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Rubro", ""), 25, Gx_line+0, 143, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFRubrosNombre_Sel, "")), 143, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV36TFRubrosNombre_Sel = (AV45TempBoolean ? "<#Empty#>" : AV36TFRubrosNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFRubrosNombre)) )
            {
               H4B0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Rubro", ""), 25, Gx_line+0, 143, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFRubrosNombre, "")), 143, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! (0==AV41TFRubrosDefault_Sel) )
         {
            if ( AV41TFRubrosDefault_Sel == 1 )
            {
               AV44FilterTFRubrosDefault_SelValueDescription = context.GetMessage( "WWP_TSChecked", "");
            }
            else if ( AV41TFRubrosDefault_Sel == 2 )
            {
               AV44FilterTFRubrosDefault_SelValueDescription = context.GetMessage( "WWP_TSUnChecked", "");
            }
            H4B0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Default", ""), 25, Gx_line+0, 143, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44FilterTFRubrosDefault_SelValueDescription, "")), 143, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         AV39TFRubrosEstado_Sels.FromJSonString(AV37TFRubrosEstado_SelsJson, null);
         if ( ! ( AV39TFRubrosEstado_Sels.Count == 0 ) )
         {
            AV46i = 1;
            AV64GXV1 = 1;
            while ( AV64GXV1 <= AV39TFRubrosEstado_Sels.Count )
            {
               AV40TFRubrosEstado_Sel = AV39TFRubrosEstado_Sels.GetString(AV64GXV1);
               if ( AV46i == 1 )
               {
                  AV38TFRubrosEstado_SelDscs = "";
               }
               else
               {
                  AV38TFRubrosEstado_SelDscs += ", ";
               }
               AV43FilterTFRubrosEstado_SelValueDescription = context.GetMessage( gxdomainestadoenum.getDescription(context,AV40TFRubrosEstado_Sel), "");
               AV38TFRubrosEstado_SelDscs += AV43FilterTFRubrosEstado_SelValueDescription;
               AV46i = (long)(AV46i+1);
               AV64GXV1 = (int)(AV64GXV1+1);
            }
            H4B0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 25, Gx_line+0, 143, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFRubrosEstado_SelDscs, "")), 143, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60TFRubrosImagenURL_Sel)) )
         {
            AV45TempBoolean = (bool)(((StringUtil.StrCmp(AV60TFRubrosImagenURL_Sel, "<#Empty#>")==0)));
            AV60TFRubrosImagenURL_Sel = (AV45TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV60TFRubrosImagenURL_Sel);
            H4B0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Imagen URL", ""), 25, Gx_line+0, 143, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60TFRubrosImagenURL_Sel, "")), 143, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV60TFRubrosImagenURL_Sel = (AV45TempBoolean ? "<#Empty#>" : AV60TFRubrosImagenURL_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59TFRubrosImagenURL)) )
            {
               H4B0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Imagen URL", ""), 25, Gx_line+0, 143, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59TFRubrosImagenURL, "")), 143, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H4B0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H4B0( false, 36) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Rubro", ""), 30, Gx_line+10, 111, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Rubro", ""), 115, Gx_line+10, 279, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Imagen", ""), 283, Gx_line+10, 365, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Default", ""), 369, Gx_line+10, 451, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 455, Gx_line+10, 619, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Imagen URL", ""), 623, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV66Rubroswwds_1_filterfulltext = AV13FilterFullText;
         AV67Rubroswwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV68Rubroswwds_3_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV69Rubroswwds_4_rubrosnombre1 = AV16RubrosNombre1;
         AV70Rubroswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV71Rubroswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV72Rubroswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV73Rubroswwds_8_rubrosnombre2 = AV22RubrosNombre2;
         AV74Rubroswwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV75Rubroswwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV76Rubroswwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV77Rubroswwds_12_rubrosnombre3 = AV26RubrosNombre3;
         AV78Rubroswwds_13_tfrubrosid = AV33TFRubrosId;
         AV79Rubroswwds_14_tfrubrosid_to = AV34TFRubrosId_To;
         AV80Rubroswwds_15_tfrubrosnombre = AV35TFRubrosNombre;
         AV81Rubroswwds_16_tfrubrosnombre_sel = AV36TFRubrosNombre_Sel;
         AV82Rubroswwds_17_tfrubrosdefault_sel = AV41TFRubrosDefault_Sel;
         AV83Rubroswwds_18_tfrubrosestado_sels = AV39TFRubrosEstado_Sels;
         AV84Rubroswwds_19_tfrubrosimagenurl = AV59TFRubrosImagenURL;
         AV85Rubroswwds_20_tfrubrosimagenurl_sel = AV60TFRubrosImagenURL_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A123RubrosEstado ,
                                              AV83Rubroswwds_18_tfrubrosestado_sels ,
                                              AV67Rubroswwds_2_dynamicfiltersselector1 ,
                                              AV68Rubroswwds_3_dynamicfiltersoperator1 ,
                                              AV69Rubroswwds_4_rubrosnombre1 ,
                                              AV70Rubroswwds_5_dynamicfiltersenabled2 ,
                                              AV71Rubroswwds_6_dynamicfiltersselector2 ,
                                              AV72Rubroswwds_7_dynamicfiltersoperator2 ,
                                              AV73Rubroswwds_8_rubrosnombre2 ,
                                              AV74Rubroswwds_9_dynamicfiltersenabled3 ,
                                              AV75Rubroswwds_10_dynamicfiltersselector3 ,
                                              AV76Rubroswwds_11_dynamicfiltersoperator3 ,
                                              AV77Rubroswwds_12_rubrosnombre3 ,
                                              AV78Rubroswwds_13_tfrubrosid ,
                                              AV79Rubroswwds_14_tfrubrosid_to ,
                                              AV81Rubroswwds_16_tfrubrosnombre_sel ,
                                              AV80Rubroswwds_15_tfrubrosnombre ,
                                              AV82Rubroswwds_17_tfrubrosdefault_sel ,
                                              AV83Rubroswwds_18_tfrubrosestado_sels.Count ,
                                              AV85Rubroswwds_20_tfrubrosimagenurl_sel ,
                                              AV84Rubroswwds_19_tfrubrosimagenurl ,
                                              A122RubrosNombre ,
                                              A121RubrosId ,
                                              A501RubrosDefault ,
                                              A896RubrosImagenURL ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              AV66Rubroswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV69Rubroswwds_4_rubrosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV69Rubroswwds_4_rubrosnombre1), 100, "%");
         lV69Rubroswwds_4_rubrosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV69Rubroswwds_4_rubrosnombre1), 100, "%");
         lV73Rubroswwds_8_rubrosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV73Rubroswwds_8_rubrosnombre2), 100, "%");
         lV73Rubroswwds_8_rubrosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV73Rubroswwds_8_rubrosnombre2), 100, "%");
         lV77Rubroswwds_12_rubrosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV77Rubroswwds_12_rubrosnombre3), 100, "%");
         lV77Rubroswwds_12_rubrosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV77Rubroswwds_12_rubrosnombre3), 100, "%");
         lV80Rubroswwds_15_tfrubrosnombre = StringUtil.PadR( StringUtil.RTrim( AV80Rubroswwds_15_tfrubrosnombre), 100, "%");
         lV84Rubroswwds_19_tfrubrosimagenurl = StringUtil.Concat( StringUtil.RTrim( AV84Rubroswwds_19_tfrubrosimagenurl), "%", "");
         /* Using cursor P004B2 */
         pr_default.execute(0, new Object[] {lV69Rubroswwds_4_rubrosnombre1, lV69Rubroswwds_4_rubrosnombre1, lV73Rubroswwds_8_rubrosnombre2, lV73Rubroswwds_8_rubrosnombre2, lV77Rubroswwds_12_rubrosnombre3, lV77Rubroswwds_12_rubrosnombre3, AV78Rubroswwds_13_tfrubrosid, AV79Rubroswwds_14_tfrubrosid_to, lV80Rubroswwds_15_tfrubrosnombre, AV81Rubroswwds_16_tfrubrosnombre_sel, lV84Rubroswwds_19_tfrubrosimagenurl, AV85Rubroswwds_20_tfrubrosimagenurl_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A896RubrosImagenURL = P004B2_A896RubrosImagenURL[0];
            A501RubrosDefault = P004B2_A501RubrosDefault[0];
            n501RubrosDefault = P004B2_n501RubrosDefault[0];
            A122RubrosNombre = P004B2_A122RubrosNombre[0];
            A121RubrosId = P004B2_A121RubrosId[0];
            A123RubrosEstado = P004B2_A123RubrosEstado[0];
            n123RubrosEstado = P004B2_n123RubrosEstado[0];
            A40000RubrosImagen_GXI = P004B2_A40000RubrosImagen_GXI[0];
            A168RubrosImagen = P004B2_A168RubrosImagen[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Rubroswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A121RubrosId), 4, 0) , StringUtil.PadR( "%" + AV66Rubroswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A122RubrosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Rubroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Rubroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A123RubrosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Rubroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A123RubrosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Rubroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A123RubrosEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A896RubrosImagenURL) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Rubroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV28RubrosEstadoDescription = context.GetMessage( gxdomainestadoenum.getDescription(context,A123RubrosEstado), "");
               /* Execute user subroutine: 'BEFOREPRINTLINE' */
               S144 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               if ( StringUtil.StrCmp(A123RubrosEstado, "HAB") != 0 )
               {
                  H4B0( false, 35) ;
                  getPrinter().GxDrawRect(28, Gx_line+0, 789, Gx_line+34, 1, 0, 0, 0, 1, 242, 222, 222, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 221, 75, 57, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A121RubrosId), "ZZZ9")), 30, Gx_line+10, 111, Gx_line+24, 2+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A122RubrosNombre, "")), 115, Gx_line+10, 279, Gx_line+24, 0+16, 0, 0, 0) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : A168RubrosImagen);
                  getPrinter().GxDrawBitMap(sImgUrl, 283, Gx_line+10, 365, Gx_line+24) ;
                  getPrinter().GxDrawText(StringUtil.BoolToStr( A501RubrosDefault), 369, Gx_line+10, 451, Gx_line+24, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28RubrosEstadoDescription, "")), 455, Gx_line+10, 619, Gx_line+24, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A896RubrosImagenURL, "")), 623, Gx_line+10, 787, Gx_line+24, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawLine(28, Gx_line+34, 789, Gx_line+34, 1, 220, 220, 220, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+35);
               }
               else
               {
                  H4B0( false, 35) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A121RubrosId), "ZZZ9")), 30, Gx_line+10, 111, Gx_line+24, 2+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A122RubrosNombre, "")), 115, Gx_line+10, 279, Gx_line+24, 0+16, 0, 0, 0) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : A168RubrosImagen);
                  getPrinter().GxDrawBitMap(sImgUrl, 283, Gx_line+10, 365, Gx_line+24) ;
                  getPrinter().GxDrawText(StringUtil.BoolToStr( A501RubrosDefault), 369, Gx_line+10, 451, Gx_line+24, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28RubrosEstadoDescription, "")), 455, Gx_line+10, 619, Gx_line+24, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A896RubrosImagenURL, "")), 623, Gx_line+10, 787, Gx_line+24, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawLine(28, Gx_line+34, 789, Gx_line+34, 1, 220, 220, 220, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+35);
               }
               /* Execute user subroutine: 'AFTERPRINTLINE' */
               S154 ();
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

      protected void S161( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV29Session.Get("RubrosWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "RubrosWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("RubrosWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV31GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV31GridState.gxTpr_Ordereddsc;
         AV86GXV2 = 1;
         while ( AV86GXV2 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV86GXV2));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFRUBROSID") == 0 )
            {
               AV33TFRubrosId = (short)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV34TFRubrosId_To = (short)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFRUBROSNOMBRE") == 0 )
            {
               AV35TFRubrosNombre = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFRUBROSNOMBRE_SEL") == 0 )
            {
               AV36TFRubrosNombre_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFRUBROSDEFAULT_SEL") == 0 )
            {
               AV41TFRubrosDefault_Sel = (short)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFRUBROSESTADO_SEL") == 0 )
            {
               AV37TFRubrosEstado_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV39TFRubrosEstado_Sels.FromJSonString(AV37TFRubrosEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFRUBROSIMAGENURL") == 0 )
            {
               AV59TFRubrosImagenURL = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFRUBROSIMAGENURL_SEL") == 0 )
            {
               AV60TFRubrosImagenURL_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            AV86GXV2 = (int)(AV86GXV2+1);
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

      protected void H4B0( bool bFoot ,
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
                  AV55PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV52DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+39, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55PageInfo, "")), 30, Gx_line+15, 409, Gx_line+29, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52DateInfo, "")), 409, Gx_line+15, 789, Gx_line+29, 2, 0, 0, 0) ;
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
               AV50AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV56Phone = "+1 550 8923";
               AV54Mail = "info@mail.com";
               AV58Website = "http://www.web.com";
               AV47AddressLine1 = "French Boulevard 2859";
               AV48AddressLine2 = "Downtown";
               AV49AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+107, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50AppName, "")), 30, Gx_line+30, 283, Gx_line+44, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57Title, "")), 30, Gx_line+44, 283, Gx_line+77, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56Phone, "")), 283, Gx_line+30, 536, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54Mail, "")), 283, Gx_line+45, 536, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58Website, "")), 283, Gx_line+60, 536, Gx_line+77, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48AddressLine2, "")), 536, Gx_line+45, 789, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49AddressLine3, "")), 536, Gx_line+60, 789, Gx_line+77, 2, 0, 0, 0) ;
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
         AV61Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV57Title = "";
         AV13FilterFullText = "";
         AV31GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV16RubrosNombre1 = "";
         AV17FilterRubrosNombreDescription = "";
         AV18RubrosNombre = "";
         AV20DynamicFiltersSelector2 = "";
         AV22RubrosNombre2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV26RubrosNombre3 = "";
         AV42TFRubrosId_To_Description = "";
         AV36TFRubrosNombre_Sel = "";
         AV35TFRubrosNombre = "";
         AV44FilterTFRubrosDefault_SelValueDescription = "";
         AV39TFRubrosEstado_Sels = new GxSimpleCollection<string>();
         AV37TFRubrosEstado_SelsJson = "";
         AV40TFRubrosEstado_Sel = "";
         AV38TFRubrosEstado_SelDscs = "";
         AV43FilterTFRubrosEstado_SelValueDescription = "";
         AV60TFRubrosImagenURL_Sel = "";
         AV59TFRubrosImagenURL = "";
         AV66Rubroswwds_1_filterfulltext = "";
         AV67Rubroswwds_2_dynamicfiltersselector1 = "";
         AV69Rubroswwds_4_rubrosnombre1 = "";
         AV71Rubroswwds_6_dynamicfiltersselector2 = "";
         AV73Rubroswwds_8_rubrosnombre2 = "";
         AV75Rubroswwds_10_dynamicfiltersselector3 = "";
         AV77Rubroswwds_12_rubrosnombre3 = "";
         AV80Rubroswwds_15_tfrubrosnombre = "";
         AV81Rubroswwds_16_tfrubrosnombre_sel = "";
         AV83Rubroswwds_18_tfrubrosestado_sels = new GxSimpleCollection<string>();
         AV84Rubroswwds_19_tfrubrosimagenurl = "";
         AV85Rubroswwds_20_tfrubrosimagenurl_sel = "";
         lV66Rubroswwds_1_filterfulltext = "";
         lV69Rubroswwds_4_rubrosnombre1 = "";
         lV73Rubroswwds_8_rubrosnombre2 = "";
         lV77Rubroswwds_12_rubrosnombre3 = "";
         lV80Rubroswwds_15_tfrubrosnombre = "";
         lV84Rubroswwds_19_tfrubrosimagenurl = "";
         A123RubrosEstado = "";
         A122RubrosNombre = "";
         A896RubrosImagenURL = "";
         P004B2_A896RubrosImagenURL = new string[] {""} ;
         P004B2_A501RubrosDefault = new bool[] {false} ;
         P004B2_n501RubrosDefault = new bool[] {false} ;
         P004B2_A122RubrosNombre = new string[] {""} ;
         P004B2_A121RubrosId = new short[1] ;
         P004B2_A123RubrosEstado = new string[] {""} ;
         P004B2_n123RubrosEstado = new bool[] {false} ;
         P004B2_A40000RubrosImagen_GXI = new string[] {""} ;
         P004B2_A168RubrosImagen = new string[] {""} ;
         A40000RubrosImagen_GXI = "";
         A168RubrosImagen = "";
         AV28RubrosEstadoDescription = "";
         sImgUrl = "";
         AV29Session = context.GetSession();
         AV32GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV55PageInfo = "";
         AV52DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV50AppName = "";
         AV56Phone = "";
         AV54Mail = "";
         AV58Website = "";
         AV47AddressLine1 = "";
         AV48AddressLine2 = "";
         AV49AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rubroswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P004B2_A896RubrosImagenURL, P004B2_A501RubrosDefault, P004B2_n501RubrosDefault, P004B2_A122RubrosNombre, P004B2_A121RubrosId, P004B2_A123RubrosEstado, P004B2_n123RubrosEstado, P004B2_A40000RubrosImagen_GXI, P004B2_A168RubrosImagen
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV61Pgmname = "RubrosWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV61Pgmname = "RubrosWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV15DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV25DynamicFiltersOperator3 ;
      private short AV33TFRubrosId ;
      private short AV34TFRubrosId_To ;
      private short AV41TFRubrosDefault_Sel ;
      private short AV68Rubroswwds_3_dynamicfiltersoperator1 ;
      private short AV72Rubroswwds_7_dynamicfiltersoperator2 ;
      private short AV76Rubroswwds_11_dynamicfiltersoperator3 ;
      private short AV78Rubroswwds_13_tfrubrosid ;
      private short AV79Rubroswwds_14_tfrubrosid_to ;
      private short AV82Rubroswwds_17_tfrubrosdefault_sel ;
      private short A121RubrosId ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV64GXV1 ;
      private int AV83Rubroswwds_18_tfrubrosestado_sels_Count ;
      private int AV86GXV2 ;
      private long AV46i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV61Pgmname ;
      private string GXEncryptionTmp ;
      private string AV16RubrosNombre1 ;
      private string AV18RubrosNombre ;
      private string AV22RubrosNombre2 ;
      private string AV26RubrosNombre3 ;
      private string AV36TFRubrosNombre_Sel ;
      private string AV35TFRubrosNombre ;
      private string AV40TFRubrosEstado_Sel ;
      private string AV69Rubroswwds_4_rubrosnombre1 ;
      private string AV73Rubroswwds_8_rubrosnombre2 ;
      private string AV77Rubroswwds_12_rubrosnombre3 ;
      private string AV80Rubroswwds_15_tfrubrosnombre ;
      private string AV81Rubroswwds_16_tfrubrosnombre_sel ;
      private string lV69Rubroswwds_4_rubrosnombre1 ;
      private string lV73Rubroswwds_8_rubrosnombre2 ;
      private string lV77Rubroswwds_12_rubrosnombre3 ;
      private string lV80Rubroswwds_15_tfrubrosnombre ;
      private string A123RubrosEstado ;
      private string A122RubrosNombre ;
      private string sImgUrl ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV45TempBoolean ;
      private bool AV70Rubroswwds_5_dynamicfiltersenabled2 ;
      private bool AV74Rubroswwds_9_dynamicfiltersenabled3 ;
      private bool A501RubrosDefault ;
      private bool AV12OrderedDsc ;
      private bool n501RubrosDefault ;
      private bool n123RubrosEstado ;
      private string AV37TFRubrosEstado_SelsJson ;
      private string AV57Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV17FilterRubrosNombreDescription ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV42TFRubrosId_To_Description ;
      private string AV44FilterTFRubrosDefault_SelValueDescription ;
      private string AV38TFRubrosEstado_SelDscs ;
      private string AV43FilterTFRubrosEstado_SelValueDescription ;
      private string AV60TFRubrosImagenURL_Sel ;
      private string AV59TFRubrosImagenURL ;
      private string AV66Rubroswwds_1_filterfulltext ;
      private string AV67Rubroswwds_2_dynamicfiltersselector1 ;
      private string AV71Rubroswwds_6_dynamicfiltersselector2 ;
      private string AV75Rubroswwds_10_dynamicfiltersselector3 ;
      private string AV84Rubroswwds_19_tfrubrosimagenurl ;
      private string AV85Rubroswwds_20_tfrubrosimagenurl_sel ;
      private string lV66Rubroswwds_1_filterfulltext ;
      private string lV84Rubroswwds_19_tfrubrosimagenurl ;
      private string A896RubrosImagenURL ;
      private string A40000RubrosImagen_GXI ;
      private string AV28RubrosEstadoDescription ;
      private string AV55PageInfo ;
      private string AV52DateInfo ;
      private string AV50AppName ;
      private string AV56Phone ;
      private string AV54Mail ;
      private string AV58Website ;
      private string AV47AddressLine1 ;
      private string AV48AddressLine2 ;
      private string AV49AddressLine3 ;
      private string A168RubrosImagen ;
      private IGxSession AV29Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV31GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV39TFRubrosEstado_Sels ;
      private GxSimpleCollection<string> AV83Rubroswwds_18_tfrubrosestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P004B2_A896RubrosImagenURL ;
      private bool[] P004B2_A501RubrosDefault ;
      private bool[] P004B2_n501RubrosDefault ;
      private string[] P004B2_A122RubrosNombre ;
      private short[] P004B2_A121RubrosId ;
      private string[] P004B2_A123RubrosEstado ;
      private bool[] P004B2_n123RubrosEstado ;
      private string[] P004B2_A40000RubrosImagen_GXI ;
      private string[] P004B2_A168RubrosImagen ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
   }

   public class rubroswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004B2( IGxContext context ,
                                             string A123RubrosEstado ,
                                             GxSimpleCollection<string> AV83Rubroswwds_18_tfrubrosestado_sels ,
                                             string AV67Rubroswwds_2_dynamicfiltersselector1 ,
                                             short AV68Rubroswwds_3_dynamicfiltersoperator1 ,
                                             string AV69Rubroswwds_4_rubrosnombre1 ,
                                             bool AV70Rubroswwds_5_dynamicfiltersenabled2 ,
                                             string AV71Rubroswwds_6_dynamicfiltersselector2 ,
                                             short AV72Rubroswwds_7_dynamicfiltersoperator2 ,
                                             string AV73Rubroswwds_8_rubrosnombre2 ,
                                             bool AV74Rubroswwds_9_dynamicfiltersenabled3 ,
                                             string AV75Rubroswwds_10_dynamicfiltersselector3 ,
                                             short AV76Rubroswwds_11_dynamicfiltersoperator3 ,
                                             string AV77Rubroswwds_12_rubrosnombre3 ,
                                             short AV78Rubroswwds_13_tfrubrosid ,
                                             short AV79Rubroswwds_14_tfrubrosid_to ,
                                             string AV81Rubroswwds_16_tfrubrosnombre_sel ,
                                             string AV80Rubroswwds_15_tfrubrosnombre ,
                                             short AV82Rubroswwds_17_tfrubrosdefault_sel ,
                                             int AV83Rubroswwds_18_tfrubrosestado_sels_Count ,
                                             string AV85Rubroswwds_20_tfrubrosimagenurl_sel ,
                                             string AV84Rubroswwds_19_tfrubrosimagenurl ,
                                             string A122RubrosNombre ,
                                             short A121RubrosId ,
                                             bool A501RubrosDefault ,
                                             string A896RubrosImagenURL ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             string AV66Rubroswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[12];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [RubrosImagenURL], [RubrosDefault], [RubrosNombre], [RubrosId], [RubrosEstado], [RubrosImagen_GXI], [RubrosImagen] FROM [Rubros]";
         if ( ( StringUtil.StrCmp(AV67Rubroswwds_2_dynamicfiltersselector1, "RUBROSNOMBRE") == 0 ) && ( AV68Rubroswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Rubroswwds_4_rubrosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like UPPER(@lV69Rubroswwds_4_rubrosnombre1))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Rubroswwds_2_dynamicfiltersselector1, "RUBROSNOMBRE") == 0 ) && ( AV68Rubroswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Rubroswwds_4_rubrosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like '%' + UPPER(@lV69Rubroswwds_4_rubrosnombre1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV70Rubroswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Rubroswwds_6_dynamicfiltersselector2, "RUBROSNOMBRE") == 0 ) && ( AV72Rubroswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Rubroswwds_8_rubrosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like UPPER(@lV73Rubroswwds_8_rubrosnombre2))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV70Rubroswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Rubroswwds_6_dynamicfiltersselector2, "RUBROSNOMBRE") == 0 ) && ( AV72Rubroswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Rubroswwds_8_rubrosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like '%' + UPPER(@lV73Rubroswwds_8_rubrosnombre2))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV74Rubroswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Rubroswwds_10_dynamicfiltersselector3, "RUBROSNOMBRE") == 0 ) && ( AV76Rubroswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Rubroswwds_12_rubrosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like UPPER(@lV77Rubroswwds_12_rubrosnombre3))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV74Rubroswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Rubroswwds_10_dynamicfiltersselector3, "RUBROSNOMBRE") == 0 ) && ( AV76Rubroswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Rubroswwds_12_rubrosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like '%' + UPPER(@lV77Rubroswwds_12_rubrosnombre3))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV78Rubroswwds_13_tfrubrosid) )
         {
            AddWhere(sWhereString, "([RubrosId] >= @AV78Rubroswwds_13_tfrubrosid)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV79Rubroswwds_14_tfrubrosid_to) )
         {
            AddWhere(sWhereString, "([RubrosId] <= @AV79Rubroswwds_14_tfrubrosid_to)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Rubroswwds_16_tfrubrosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Rubroswwds_15_tfrubrosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like UPPER(@lV80Rubroswwds_15_tfrubrosnombre))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Rubroswwds_16_tfrubrosnombre_sel)) && ! ( StringUtil.StrCmp(AV81Rubroswwds_16_tfrubrosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([RubrosNombre] = @AV81Rubroswwds_16_tfrubrosnombre_sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV81Rubroswwds_16_tfrubrosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([RubrosNombre] = ''))");
         }
         if ( AV82Rubroswwds_17_tfrubrosdefault_sel == 1 )
         {
            AddWhere(sWhereString, "([RubrosDefault] = 1)");
         }
         if ( AV82Rubroswwds_17_tfrubrosdefault_sel == 2 )
         {
            AddWhere(sWhereString, "([RubrosDefault] = 0)");
         }
         if ( AV83Rubroswwds_18_tfrubrosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV83Rubroswwds_18_tfrubrosestado_sels, "[RubrosEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Rubroswwds_20_tfrubrosimagenurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Rubroswwds_19_tfrubrosimagenurl)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosImagenURL]) like UPPER(@lV84Rubroswwds_19_tfrubrosimagenurl))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Rubroswwds_20_tfrubrosimagenurl_sel)) && ! ( StringUtil.StrCmp(AV85Rubroswwds_20_tfrubrosimagenurl_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([RubrosImagenURL] = @AV85Rubroswwds_20_tfrubrosimagenurl_sel)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV85Rubroswwds_20_tfrubrosimagenurl_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([RubrosImagenURL] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [RubrosNombre]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RubrosNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [RubrosId]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RubrosId] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [RubrosDefault]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RubrosDefault] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [RubrosEstado]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RubrosEstado] DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [RubrosImagenURL]";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RubrosImagenURL] DESC";
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
                     return conditional_P004B2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (int)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (short)dynConstraints[22] , (bool)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] , (bool)dynConstraints[26] , (string)dynConstraints[27] );
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
          Object[] prmP004B2;
          prmP004B2 = new Object[] {
          new ParDef("@lV69Rubroswwds_4_rubrosnombre1",GXType.Char,100,0) ,
          new ParDef("@lV69Rubroswwds_4_rubrosnombre1",GXType.Char,100,0) ,
          new ParDef("@lV73Rubroswwds_8_rubrosnombre2",GXType.Char,100,0) ,
          new ParDef("@lV73Rubroswwds_8_rubrosnombre2",GXType.Char,100,0) ,
          new ParDef("@lV77Rubroswwds_12_rubrosnombre3",GXType.Char,100,0) ,
          new ParDef("@lV77Rubroswwds_12_rubrosnombre3",GXType.Char,100,0) ,
          new ParDef("@AV78Rubroswwds_13_tfrubrosid",GXType.Int16,4,0) ,
          new ParDef("@AV79Rubroswwds_14_tfrubrosid_to",GXType.Int16,4,0) ,
          new ParDef("@lV80Rubroswwds_15_tfrubrosnombre",GXType.Char,100,0) ,
          new ParDef("@AV81Rubroswwds_16_tfrubrosnombre_sel",GXType.NChar,100,0) ,
          new ParDef("@lV84Rubroswwds_19_tfrubrosimagenurl",GXType.VarChar,1000,0) ,
          new ParDef("@AV85Rubroswwds_20_tfrubrosimagenurl_sel",GXType.NVarChar,1000,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004B2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004B2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 100);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 3);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getMultimediaUri(6);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(6));
                return;
       }
    }

 }

}
