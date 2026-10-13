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
   public class textoswwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public textoswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public textoswwexportreport( IGxContext context )
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
         setOutputFileName("TextosWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWTextos", out  GXt_boolean1) ;
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
               S151 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               AV57Title = context.GetMessage( "Lista de Textos", "");
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
            H520( true, 0) ;
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
            H520( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 133, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 133, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV27GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "TEXTOSTIPO") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV27GridStateDynamicFilter.gxTpr_Operator;
               AV16TextosTipo1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TextosTipo1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterTextosTipoDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Tipo", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterTextosTipoDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Tipo", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV18TextosTipo = AV16TextosTipo1;
                  H520( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterTextosTipoDescription, "")), 25, Gx_line+0, 133, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18TextosTipo, "")), 133, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV19DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "TEXTOSTIPO") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV27GridStateDynamicFilter.gxTpr_Operator;
                  AV22TextosTipo2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TextosTipo2)) )
                  {
                     if ( AV21DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterTextosTipoDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Tipo", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV21DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterTextosTipoDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Tipo", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV18TextosTipo = AV22TextosTipo2;
                     H520( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterTextosTipoDescription, "")), 25, Gx_line+0, 133, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18TextosTipo, "")), 133, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "TEXTOSTIPO") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV27GridStateDynamicFilter.gxTpr_Operator;
                     AV26TextosTipo3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TextosTipo3)) )
                     {
                        if ( AV25DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterTextosTipoDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Tipo", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV25DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterTextosTipoDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Tipo", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV18TextosTipo = AV26TextosTipo3;
                        H520( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterTextosTipoDescription, "")), 25, Gx_line+0, 133, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18TextosTipo, "")), 133, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV33TFTextosId) && (0==AV34TFTextosId_To) ) )
         {
            H520( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Id", ""), 25, Gx_line+0, 133, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV33TFTextosId), "ZZZZZZZZZZZZZZZZZ9")), 133, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV43TFTextosId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Id", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H520( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFTextosId_To_Description, "")), 25, Gx_line+0, 133, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV34TFTextosId_To), "ZZZZZZZZZZZZZZZZZ9")), 133, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFTextosTipo_Sel)) )
         {
            AV45TempBoolean = (bool)(((StringUtil.StrCmp(AV36TFTextosTipo_Sel, "<#Empty#>")==0)));
            AV36TFTextosTipo_Sel = (AV45TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV36TFTextosTipo_Sel);
            H520( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Tipo", ""), 25, Gx_line+0, 133, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFTextosTipo_Sel, "")), 133, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV36TFTextosTipo_Sel = (AV45TempBoolean ? "<#Empty#>" : AV36TFTextosTipo_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFTextosTipo)) )
            {
               H520( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Tipo", ""), 25, Gx_line+0, 133, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFTextosTipo, "")), 133, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFTextosTitulo_Sel)) )
         {
            AV45TempBoolean = (bool)(((StringUtil.StrCmp(AV38TFTextosTitulo_Sel, "<#Empty#>")==0)));
            AV38TFTextosTitulo_Sel = (AV45TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV38TFTextosTitulo_Sel);
            H520( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Titulo", ""), 25, Gx_line+0, 133, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFTextosTitulo_Sel, "")), 133, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV38TFTextosTitulo_Sel = (AV45TempBoolean ? "<#Empty#>" : AV38TFTextosTitulo_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFTextosTitulo)) )
            {
               H520( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Titulo", ""), 25, Gx_line+0, 133, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFTextosTitulo, "")), 133, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV41TFTextosEstado_Sels.FromJSonString(AV39TFTextosEstado_SelsJson, null);
         if ( ! ( AV41TFTextosEstado_Sels.Count == 0 ) )
         {
            AV46i = 1;
            AV64GXV1 = 1;
            while ( AV64GXV1 <= AV41TFTextosEstado_Sels.Count )
            {
               AV42TFTextosEstado_Sel = AV41TFTextosEstado_Sels.GetString(AV64GXV1);
               if ( AV46i == 1 )
               {
                  AV40TFTextosEstado_SelDscs = "";
               }
               else
               {
                  AV40TFTextosEstado_SelDscs += ", ";
               }
               AV44FilterTFTextosEstado_SelValueDescription = context.GetMessage( gxdomainestadoenum.getDescription(context,AV42TFTextosEstado_Sel), "");
               AV40TFTextosEstado_SelDscs += AV44FilterTFTextosEstado_SelValueDescription;
               AV46i = (long)(AV46i+1);
               AV64GXV1 = (int)(AV64GXV1+1);
            }
            H520( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 25, Gx_line+0, 133, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFTextosEstado_SelDscs, "")), 133, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60TFTextosRutaPDF_Sel)) )
         {
            AV45TempBoolean = (bool)(((StringUtil.StrCmp(AV60TFTextosRutaPDF_Sel, "<#Empty#>")==0)));
            AV60TFTextosRutaPDF_Sel = (AV45TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV60TFTextosRutaPDF_Sel);
            H520( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Ruta PDF", ""), 25, Gx_line+0, 133, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60TFTextosRutaPDF_Sel, "")), 133, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV60TFTextosRutaPDF_Sel = (AV45TempBoolean ? "<#Empty#>" : AV60TFTextosRutaPDF_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59TFTextosRutaPDF)) )
            {
               H520( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Ruta PDF", ""), 25, Gx_line+0, 133, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59TFTextosRutaPDF, "")), 133, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H520( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H520( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Id", ""), 30, Gx_line+10, 112, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Tipo", ""), 116, Gx_line+10, 280, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Titulo", ""), 284, Gx_line+10, 448, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 452, Gx_line+10, 617, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Ruta PDF", ""), 621, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV66Textoswwds_1_filterfulltext = AV13FilterFullText;
         AV67Textoswwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV68Textoswwds_3_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV69Textoswwds_4_textostipo1 = AV16TextosTipo1;
         AV70Textoswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV71Textoswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV72Textoswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV73Textoswwds_8_textostipo2 = AV22TextosTipo2;
         AV74Textoswwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV75Textoswwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV76Textoswwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV77Textoswwds_12_textostipo3 = AV26TextosTipo3;
         AV78Textoswwds_13_tftextosid = AV33TFTextosId;
         AV79Textoswwds_14_tftextosid_to = AV34TFTextosId_To;
         AV80Textoswwds_15_tftextostipo = AV35TFTextosTipo;
         AV81Textoswwds_16_tftextostipo_sel = AV36TFTextosTipo_Sel;
         AV82Textoswwds_17_tftextostitulo = AV37TFTextosTitulo;
         AV83Textoswwds_18_tftextostitulo_sel = AV38TFTextosTitulo_Sel;
         AV84Textoswwds_19_tftextosestado_sels = AV41TFTextosEstado_Sels;
         AV85Textoswwds_20_tftextosrutapdf = AV59TFTextosRutaPDF;
         AV86Textoswwds_21_tftextosrutapdf_sel = AV60TFTextosRutaPDF_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A534TextosEstado ,
                                              AV84Textoswwds_19_tftextosestado_sels ,
                                              AV67Textoswwds_2_dynamicfiltersselector1 ,
                                              AV68Textoswwds_3_dynamicfiltersoperator1 ,
                                              AV69Textoswwds_4_textostipo1 ,
                                              AV70Textoswwds_5_dynamicfiltersenabled2 ,
                                              AV71Textoswwds_6_dynamicfiltersselector2 ,
                                              AV72Textoswwds_7_dynamicfiltersoperator2 ,
                                              AV73Textoswwds_8_textostipo2 ,
                                              AV74Textoswwds_9_dynamicfiltersenabled3 ,
                                              AV75Textoswwds_10_dynamicfiltersselector3 ,
                                              AV76Textoswwds_11_dynamicfiltersoperator3 ,
                                              AV77Textoswwds_12_textostipo3 ,
                                              AV78Textoswwds_13_tftextosid ,
                                              AV79Textoswwds_14_tftextosid_to ,
                                              AV81Textoswwds_16_tftextostipo_sel ,
                                              AV80Textoswwds_15_tftextostipo ,
                                              AV83Textoswwds_18_tftextostitulo_sel ,
                                              AV82Textoswwds_17_tftextostitulo ,
                                              AV84Textoswwds_19_tftextosestado_sels.Count ,
                                              AV86Textoswwds_21_tftextosrutapdf_sel ,
                                              AV85Textoswwds_20_tftextosrutapdf ,
                                              A258TextosTipo ,
                                              A150TextosId ,
                                              A259TextosTitulo ,
                                              A977TextosRutaPDF ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              AV66Textoswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV69Textoswwds_4_textostipo1 = StringUtil.PadR( StringUtil.RTrim( AV69Textoswwds_4_textostipo1), 20, "%");
         lV69Textoswwds_4_textostipo1 = StringUtil.PadR( StringUtil.RTrim( AV69Textoswwds_4_textostipo1), 20, "%");
         lV73Textoswwds_8_textostipo2 = StringUtil.PadR( StringUtil.RTrim( AV73Textoswwds_8_textostipo2), 20, "%");
         lV73Textoswwds_8_textostipo2 = StringUtil.PadR( StringUtil.RTrim( AV73Textoswwds_8_textostipo2), 20, "%");
         lV77Textoswwds_12_textostipo3 = StringUtil.PadR( StringUtil.RTrim( AV77Textoswwds_12_textostipo3), 20, "%");
         lV77Textoswwds_12_textostipo3 = StringUtil.PadR( StringUtil.RTrim( AV77Textoswwds_12_textostipo3), 20, "%");
         lV80Textoswwds_15_tftextostipo = StringUtil.PadR( StringUtil.RTrim( AV80Textoswwds_15_tftextostipo), 20, "%");
         lV82Textoswwds_17_tftextostitulo = StringUtil.PadR( StringUtil.RTrim( AV82Textoswwds_17_tftextostitulo), 80, "%");
         lV85Textoswwds_20_tftextosrutapdf = StringUtil.Concat( StringUtil.RTrim( AV85Textoswwds_20_tftextosrutapdf), "%", "");
         /* Using cursor P00522 */
         pr_default.execute(0, new Object[] {lV69Textoswwds_4_textostipo1, lV69Textoswwds_4_textostipo1, lV73Textoswwds_8_textostipo2, lV73Textoswwds_8_textostipo2, lV77Textoswwds_12_textostipo3, lV77Textoswwds_12_textostipo3, AV78Textoswwds_13_tftextosid, AV79Textoswwds_14_tftextosid_to, lV80Textoswwds_15_tftextostipo, AV81Textoswwds_16_tftextostipo_sel, lV82Textoswwds_17_tftextostitulo, AV83Textoswwds_18_tftextostitulo_sel, lV85Textoswwds_20_tftextosrutapdf, AV86Textoswwds_21_tftextosrutapdf_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A977TextosRutaPDF = P00522_A977TextosRutaPDF[0];
            n977TextosRutaPDF = P00522_n977TextosRutaPDF[0];
            A259TextosTitulo = P00522_A259TextosTitulo[0];
            A258TextosTipo = P00522_A258TextosTipo[0];
            A150TextosId = P00522_A150TextosId[0];
            A534TextosEstado = P00522_A534TextosEstado[0];
            n534TextosEstado = P00522_n534TextosEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Textoswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A150TextosId), 18, 0) , StringUtil.PadR( "%" + AV66Textoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A258TextosTipo) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Textoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A259TextosTitulo) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Textoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Textoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A534TextosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Textoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A534TextosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Textoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A534TextosEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A977TextosRutaPDF) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Textoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV28TextosEstadoDescription = context.GetMessage( gxdomainestadoenum.getDescription(context,A534TextosEstado), "");
               /* Execute user subroutine: 'BEFOREPRINTLINE' */
               S144 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               H520( false, 36) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A150TextosId), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 112, Gx_line+25, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A258TextosTipo, "")), 116, Gx_line+10, 280, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A259TextosTitulo, "")), 284, Gx_line+10, 448, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28TextosEstadoDescription, "")), 452, Gx_line+10, 617, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A977TextosRutaPDF, "")), 621, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawLine(28, Gx_line+35, 789, Gx_line+35, 1, 220, 220, 220, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+36);
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
         if ( StringUtil.StrCmp(AV29Session.Get("TextosWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "TextosWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("TextosWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV31GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV31GridState.gxTpr_Ordereddsc;
         AV87GXV2 = 1;
         while ( AV87GXV2 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV87GXV2));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFTEXTOSID") == 0 )
            {
               AV33TFTextosId = (long)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV34TFTextosId_To = (long)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFTEXTOSTIPO") == 0 )
            {
               AV35TFTextosTipo = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFTEXTOSTIPO_SEL") == 0 )
            {
               AV36TFTextosTipo_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFTEXTOSTITULO") == 0 )
            {
               AV37TFTextosTitulo = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFTEXTOSTITULO_SEL") == 0 )
            {
               AV38TFTextosTitulo_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFTEXTOSESTADO_SEL") == 0 )
            {
               AV39TFTextosEstado_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV41TFTextosEstado_Sels.FromJSonString(AV39TFTextosEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFTEXTOSRUTAPDF") == 0 )
            {
               AV59TFTextosRutaPDF = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFTEXTOSRUTAPDF_SEL") == 0 )
            {
               AV60TFTextosRutaPDF_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            AV87GXV2 = (int)(AV87GXV2+1);
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

      protected void H520( bool bFoot ,
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
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV50AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV56Phone = "+1 550 8923";
               AV54Mail = "info@mail.com";
               AV58Website = "http://www.web.com";
               AV47AddressLine1 = "French Boulevard 2859";
               AV48AddressLine2 = "Downtown";
               AV49AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV61Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV57Title = "";
         AV13FilterFullText = "";
         AV31GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV16TextosTipo1 = "";
         AV17FilterTextosTipoDescription = "";
         AV18TextosTipo = "";
         AV20DynamicFiltersSelector2 = "";
         AV22TextosTipo2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV26TextosTipo3 = "";
         AV43TFTextosId_To_Description = "";
         AV36TFTextosTipo_Sel = "";
         AV35TFTextosTipo = "";
         AV38TFTextosTitulo_Sel = "";
         AV37TFTextosTitulo = "";
         AV41TFTextosEstado_Sels = new GxSimpleCollection<string>();
         AV39TFTextosEstado_SelsJson = "";
         AV42TFTextosEstado_Sel = "";
         AV40TFTextosEstado_SelDscs = "";
         AV44FilterTFTextosEstado_SelValueDescription = "";
         AV60TFTextosRutaPDF_Sel = "";
         AV59TFTextosRutaPDF = "";
         AV66Textoswwds_1_filterfulltext = "";
         AV67Textoswwds_2_dynamicfiltersselector1 = "";
         AV69Textoswwds_4_textostipo1 = "";
         AV71Textoswwds_6_dynamicfiltersselector2 = "";
         AV73Textoswwds_8_textostipo2 = "";
         AV75Textoswwds_10_dynamicfiltersselector3 = "";
         AV77Textoswwds_12_textostipo3 = "";
         AV80Textoswwds_15_tftextostipo = "";
         AV81Textoswwds_16_tftextostipo_sel = "";
         AV82Textoswwds_17_tftextostitulo = "";
         AV83Textoswwds_18_tftextostitulo_sel = "";
         AV84Textoswwds_19_tftextosestado_sels = new GxSimpleCollection<string>();
         AV85Textoswwds_20_tftextosrutapdf = "";
         AV86Textoswwds_21_tftextosrutapdf_sel = "";
         lV66Textoswwds_1_filterfulltext = "";
         lV69Textoswwds_4_textostipo1 = "";
         lV73Textoswwds_8_textostipo2 = "";
         lV77Textoswwds_12_textostipo3 = "";
         lV80Textoswwds_15_tftextostipo = "";
         lV82Textoswwds_17_tftextostitulo = "";
         lV85Textoswwds_20_tftextosrutapdf = "";
         A534TextosEstado = "";
         A258TextosTipo = "";
         A259TextosTitulo = "";
         A977TextosRutaPDF = "";
         P00522_A977TextosRutaPDF = new string[] {""} ;
         P00522_n977TextosRutaPDF = new bool[] {false} ;
         P00522_A259TextosTitulo = new string[] {""} ;
         P00522_A258TextosTipo = new string[] {""} ;
         P00522_A150TextosId = new long[1] ;
         P00522_A534TextosEstado = new string[] {""} ;
         P00522_n534TextosEstado = new bool[] {false} ;
         AV28TextosEstadoDescription = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.textoswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00522_A977TextosRutaPDF, P00522_n977TextosRutaPDF, P00522_A259TextosTitulo, P00522_A258TextosTipo, P00522_A150TextosId, P00522_A534TextosEstado, P00522_n534TextosEstado
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV61Pgmname = "TextosWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV61Pgmname = "TextosWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV15DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV25DynamicFiltersOperator3 ;
      private short AV68Textoswwds_3_dynamicfiltersoperator1 ;
      private short AV72Textoswwds_7_dynamicfiltersoperator2 ;
      private short AV76Textoswwds_11_dynamicfiltersoperator3 ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV64GXV1 ;
      private int AV84Textoswwds_19_tftextosestado_sels_Count ;
      private int AV87GXV2 ;
      private long AV33TFTextosId ;
      private long AV34TFTextosId_To ;
      private long AV46i ;
      private long AV78Textoswwds_13_tftextosid ;
      private long AV79Textoswwds_14_tftextosid_to ;
      private long A150TextosId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV61Pgmname ;
      private string GXEncryptionTmp ;
      private string AV16TextosTipo1 ;
      private string AV18TextosTipo ;
      private string AV22TextosTipo2 ;
      private string AV26TextosTipo3 ;
      private string AV36TFTextosTipo_Sel ;
      private string AV35TFTextosTipo ;
      private string AV38TFTextosTitulo_Sel ;
      private string AV37TFTextosTitulo ;
      private string AV42TFTextosEstado_Sel ;
      private string AV69Textoswwds_4_textostipo1 ;
      private string AV73Textoswwds_8_textostipo2 ;
      private string AV77Textoswwds_12_textostipo3 ;
      private string AV80Textoswwds_15_tftextostipo ;
      private string AV81Textoswwds_16_tftextostipo_sel ;
      private string AV82Textoswwds_17_tftextostitulo ;
      private string AV83Textoswwds_18_tftextostitulo_sel ;
      private string lV69Textoswwds_4_textostipo1 ;
      private string lV73Textoswwds_8_textostipo2 ;
      private string lV77Textoswwds_12_textostipo3 ;
      private string lV80Textoswwds_15_tftextostipo ;
      private string lV82Textoswwds_17_tftextostitulo ;
      private string A534TextosEstado ;
      private string A258TextosTipo ;
      private string A259TextosTitulo ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV45TempBoolean ;
      private bool AV70Textoswwds_5_dynamicfiltersenabled2 ;
      private bool AV74Textoswwds_9_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private bool n977TextosRutaPDF ;
      private bool n534TextosEstado ;
      private string AV39TFTextosEstado_SelsJson ;
      private string AV57Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV17FilterTextosTipoDescription ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV43TFTextosId_To_Description ;
      private string AV40TFTextosEstado_SelDscs ;
      private string AV44FilterTFTextosEstado_SelValueDescription ;
      private string AV60TFTextosRutaPDF_Sel ;
      private string AV59TFTextosRutaPDF ;
      private string AV66Textoswwds_1_filterfulltext ;
      private string AV67Textoswwds_2_dynamicfiltersselector1 ;
      private string AV71Textoswwds_6_dynamicfiltersselector2 ;
      private string AV75Textoswwds_10_dynamicfiltersselector3 ;
      private string AV85Textoswwds_20_tftextosrutapdf ;
      private string AV86Textoswwds_21_tftextosrutapdf_sel ;
      private string lV66Textoswwds_1_filterfulltext ;
      private string lV85Textoswwds_20_tftextosrutapdf ;
      private string A977TextosRutaPDF ;
      private string AV28TextosEstadoDescription ;
      private string AV55PageInfo ;
      private string AV52DateInfo ;
      private string AV50AppName ;
      private string AV56Phone ;
      private string AV54Mail ;
      private string AV58Website ;
      private string AV47AddressLine1 ;
      private string AV48AddressLine2 ;
      private string AV49AddressLine3 ;
      private IGxSession AV29Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV31GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV41TFTextosEstado_Sels ;
      private GxSimpleCollection<string> AV84Textoswwds_19_tftextosestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00522_A977TextosRutaPDF ;
      private bool[] P00522_n977TextosRutaPDF ;
      private string[] P00522_A259TextosTitulo ;
      private string[] P00522_A258TextosTipo ;
      private long[] P00522_A150TextosId ;
      private string[] P00522_A534TextosEstado ;
      private bool[] P00522_n534TextosEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
   }

   public class textoswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00522( IGxContext context ,
                                             string A534TextosEstado ,
                                             GxSimpleCollection<string> AV84Textoswwds_19_tftextosestado_sels ,
                                             string AV67Textoswwds_2_dynamicfiltersselector1 ,
                                             short AV68Textoswwds_3_dynamicfiltersoperator1 ,
                                             string AV69Textoswwds_4_textostipo1 ,
                                             bool AV70Textoswwds_5_dynamicfiltersenabled2 ,
                                             string AV71Textoswwds_6_dynamicfiltersselector2 ,
                                             short AV72Textoswwds_7_dynamicfiltersoperator2 ,
                                             string AV73Textoswwds_8_textostipo2 ,
                                             bool AV74Textoswwds_9_dynamicfiltersenabled3 ,
                                             string AV75Textoswwds_10_dynamicfiltersselector3 ,
                                             short AV76Textoswwds_11_dynamicfiltersoperator3 ,
                                             string AV77Textoswwds_12_textostipo3 ,
                                             long AV78Textoswwds_13_tftextosid ,
                                             long AV79Textoswwds_14_tftextosid_to ,
                                             string AV81Textoswwds_16_tftextostipo_sel ,
                                             string AV80Textoswwds_15_tftextostipo ,
                                             string AV83Textoswwds_18_tftextostitulo_sel ,
                                             string AV82Textoswwds_17_tftextostitulo ,
                                             int AV84Textoswwds_19_tftextosestado_sels_Count ,
                                             string AV86Textoswwds_21_tftextosrutapdf_sel ,
                                             string AV85Textoswwds_20_tftextosrutapdf ,
                                             string A258TextosTipo ,
                                             long A150TextosId ,
                                             string A259TextosTitulo ,
                                             string A977TextosRutaPDF ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             string AV66Textoswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[14];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [TextosRutaPDF], [TextosTitulo], [TextosTipo], [TextosId], [TextosEstado] FROM [Textos]";
         if ( ( StringUtil.StrCmp(AV67Textoswwds_2_dynamicfiltersselector1, "TEXTOSTIPO") == 0 ) && ( AV68Textoswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Textoswwds_4_textostipo1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like UPPER(@lV69Textoswwds_4_textostipo1))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Textoswwds_2_dynamicfiltersselector1, "TEXTOSTIPO") == 0 ) && ( AV68Textoswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Textoswwds_4_textostipo1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like '%' + UPPER(@lV69Textoswwds_4_textostipo1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV70Textoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Textoswwds_6_dynamicfiltersselector2, "TEXTOSTIPO") == 0 ) && ( AV72Textoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Textoswwds_8_textostipo2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like UPPER(@lV73Textoswwds_8_textostipo2))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV70Textoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Textoswwds_6_dynamicfiltersselector2, "TEXTOSTIPO") == 0 ) && ( AV72Textoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Textoswwds_8_textostipo2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like '%' + UPPER(@lV73Textoswwds_8_textostipo2))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV74Textoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Textoswwds_10_dynamicfiltersselector3, "TEXTOSTIPO") == 0 ) && ( AV76Textoswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Textoswwds_12_textostipo3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like UPPER(@lV77Textoswwds_12_textostipo3))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV74Textoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Textoswwds_10_dynamicfiltersselector3, "TEXTOSTIPO") == 0 ) && ( AV76Textoswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Textoswwds_12_textostipo3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like '%' + UPPER(@lV77Textoswwds_12_textostipo3))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV78Textoswwds_13_tftextosid) )
         {
            AddWhere(sWhereString, "([TextosId] >= @AV78Textoswwds_13_tftextosid)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV79Textoswwds_14_tftextosid_to) )
         {
            AddWhere(sWhereString, "([TextosId] <= @AV79Textoswwds_14_tftextosid_to)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Textoswwds_16_tftextostipo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Textoswwds_15_tftextostipo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like UPPER(@lV80Textoswwds_15_tftextostipo))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Textoswwds_16_tftextostipo_sel)) && ! ( StringUtil.StrCmp(AV81Textoswwds_16_tftextostipo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([TextosTipo] = @AV81Textoswwds_16_tftextostipo_sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV81Textoswwds_16_tftextostipo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([TextosTipo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Textoswwds_18_tftextostitulo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Textoswwds_17_tftextostitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTitulo]) like UPPER(@lV82Textoswwds_17_tftextostitulo))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Textoswwds_18_tftextostitulo_sel)) && ! ( StringUtil.StrCmp(AV83Textoswwds_18_tftextostitulo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([TextosTitulo] = @AV83Textoswwds_18_tftextostitulo_sel)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV83Textoswwds_18_tftextostitulo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([TextosTitulo] = ''))");
         }
         if ( AV84Textoswwds_19_tftextosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV84Textoswwds_19_tftextosestado_sels, "[TextosEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Textoswwds_21_tftextosrutapdf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Textoswwds_20_tftextosrutapdf)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosRutaPDF]) like UPPER(@lV85Textoswwds_20_tftextosrutapdf))");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Textoswwds_21_tftextosrutapdf_sel)) && ! ( StringUtil.StrCmp(AV86Textoswwds_21_tftextosrutapdf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([TextosRutaPDF] = @AV86Textoswwds_21_tftextosrutapdf_sel)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( StringUtil.StrCmp(AV86Textoswwds_21_tftextosrutapdf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([TextosRutaPDF] IS NULL or ([TextosRutaPDF] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [TextosTipo]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TextosTipo] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [TextosId]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TextosId] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [TextosTitulo]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TextosTitulo] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [TextosEstado]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TextosEstado] DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [TextosRutaPDF]";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TextosRutaPDF] DESC";
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
                     return conditional_P00522(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] , (string)dynConstraints[28] );
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
          Object[] prmP00522;
          prmP00522 = new Object[] {
          new ParDef("@lV69Textoswwds_4_textostipo1",GXType.Char,20,0) ,
          new ParDef("@lV69Textoswwds_4_textostipo1",GXType.Char,20,0) ,
          new ParDef("@lV73Textoswwds_8_textostipo2",GXType.Char,20,0) ,
          new ParDef("@lV73Textoswwds_8_textostipo2",GXType.Char,20,0) ,
          new ParDef("@lV77Textoswwds_12_textostipo3",GXType.Char,20,0) ,
          new ParDef("@lV77Textoswwds_12_textostipo3",GXType.Char,20,0) ,
          new ParDef("@AV78Textoswwds_13_tftextosid",GXType.Decimal,18,0) ,
          new ParDef("@AV79Textoswwds_14_tftextosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV80Textoswwds_15_tftextostipo",GXType.Char,20,0) ,
          new ParDef("@AV81Textoswwds_16_tftextostipo_sel",GXType.NChar,20,0) ,
          new ParDef("@lV82Textoswwds_17_tftextostitulo",GXType.Char,80,0) ,
          new ParDef("@AV83Textoswwds_18_tftextostitulo_sel",GXType.NChar,80,0) ,
          new ParDef("@lV85Textoswwds_20_tftextosrutapdf",GXType.VarChar,100,0) ,
          new ParDef("@AV86Textoswwds_21_tftextosrutapdf_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00522", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00522,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 3);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
