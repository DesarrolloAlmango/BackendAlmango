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
   public class ciudadwwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public ciudadwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ciudadwwexportreport( IGxContext context )
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
         setOutputFileName("CiudadWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCiudad", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV59Pgmname));
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
               AV57Title = context.GetMessage( "Lista de Ciudad", "");
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
            HAN0( true, 0) ;
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
            HAN0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 132, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 132, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV32GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "CIUDADNOMBRE") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV16CiudadNombre1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16CiudadNombre1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterCiudadNombreDescription = StringUtil.Format( "%1 (%2)", "", context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterCiudadNombreDescription = StringUtil.Format( "%1 (%2)", "", context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV18CiudadNombre = AV16CiudadNombre1;
                  HAN0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterCiudadNombreDescription, "")), 25, Gx_line+0, 132, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18CiudadNombre, "")), 132, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "PAISNOMBRE") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV19PaisNombre1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19PaisNombre1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV20FilterPaisNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Pais", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV20FilterPaisNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Pais", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV21PaisNombre = AV19PaisNombre1;
                  HAN0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterPaisNombreDescription, "")), 25, Gx_line+0, 132, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21PaisNombre, "")), 132, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CIUDADNOMBRE") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV25CiudadNombre2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25CiudadNombre2)) )
                  {
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterCiudadNombreDescription = StringUtil.Format( "%1 (%2)", "", context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterCiudadNombreDescription = StringUtil.Format( "%1 (%2)", "", context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV18CiudadNombre = AV25CiudadNombre2;
                     HAN0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterCiudadNombreDescription, "")), 25, Gx_line+0, 132, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18CiudadNombre, "")), 132, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PAISNOMBRE") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV26PaisNombre2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26PaisNombre2)) )
                  {
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV20FilterPaisNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Pais", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV20FilterPaisNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Pais", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV21PaisNombre = AV26PaisNombre2;
                     HAN0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterPaisNombreDescription, "")), 25, Gx_line+0, 132, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21PaisNombre, "")), 132, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CIUDADNOMBRE") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV30CiudadNombre3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30CiudadNombre3)) )
                     {
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterCiudadNombreDescription = StringUtil.Format( "%1 (%2)", "", context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterCiudadNombreDescription = StringUtil.Format( "%1 (%2)", "", context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV18CiudadNombre = AV30CiudadNombre3;
                        HAN0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterCiudadNombreDescription, "")), 25, Gx_line+0, 132, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18CiudadNombre, "")), 132, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PAISNOMBRE") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV31PaisNombre3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31PaisNombre3)) )
                     {
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV20FilterPaisNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Pais", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV20FilterPaisNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Pais", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV21PaisNombre = AV31PaisNombre3;
                        HAN0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterPaisNombreDescription, "")), 25, Gx_line+0, 132, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21PaisNombre, "")), 132, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV37TFCiudadId) && (0==AV38TFCiudadId_To) ) )
         {
            HAN0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Ciudad", ""), 25, Gx_line+0, 132, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV37TFCiudadId), "ZZZZZZZZZZZZZZZZZ9")), 132, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV45TFCiudadId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Ciudad", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HAN0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45TFCiudadId_To_Description, "")), 25, Gx_line+0, 132, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV38TFCiudadId_To), "ZZZZZZZZZZZZZZZZZ9")), 132, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFPaisID_Sel)) )
         {
            AV46TempBoolean = (bool)(((StringUtil.StrCmp(AV40TFPaisID_Sel, "<#Empty#>")==0)));
            AV40TFPaisID_Sel = (AV46TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV40TFPaisID_Sel);
            HAN0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Pais", ""), 25, Gx_line+0, 132, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFPaisID_Sel, "")), 132, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV40TFPaisID_Sel = (AV46TempBoolean ? "<#Empty#>" : AV40TFPaisID_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFPaisID)) )
            {
               HAN0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Pais", ""), 25, Gx_line+0, 132, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFPaisID, "")), 132, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TFPaisNombre_Sel)) )
         {
            AV46TempBoolean = (bool)(((StringUtil.StrCmp(AV42TFPaisNombre_Sel, "<#Empty#>")==0)));
            AV42TFPaisNombre_Sel = (AV46TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV42TFPaisNombre_Sel);
            HAN0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("", 25, Gx_line+0, 132, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFPaisNombre_Sel, "")), 132, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV42TFPaisNombre_Sel = (AV46TempBoolean ? "<#Empty#>" : AV42TFPaisNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41TFPaisNombre)) )
            {
               HAN0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("", 25, Gx_line+0, 132, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFPaisNombre, "")), 132, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44TFCiudadNombre_Sel)) )
         {
            AV46TempBoolean = (bool)(((StringUtil.StrCmp(AV44TFCiudadNombre_Sel, "<#Empty#>")==0)));
            AV44TFCiudadNombre_Sel = (AV46TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV44TFCiudadNombre_Sel);
            HAN0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("", 25, Gx_line+0, 132, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44TFCiudadNombre_Sel, "")), 132, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV44TFCiudadNombre_Sel = (AV46TempBoolean ? "<#Empty#>" : AV44TFCiudadNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TFCiudadNombre)) )
            {
               HAN0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("", 25, Gx_line+0, 132, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFCiudadNombre, "")), 132, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HAN0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HAN0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Ciudad", ""), 30, Gx_line+10, 122, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Pais", ""), 126, Gx_line+10, 218, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("", 222, Gx_line+10, 406, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("", 410, Gx_line+10, 502, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("", 506, Gx_line+10, 690, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("", 694, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV63Ciudadwwds_1_filterfulltext = AV13FilterFullText;
         AV64Ciudadwwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV65Ciudadwwds_3_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV66Ciudadwwds_4_ciudadnombre1 = AV16CiudadNombre1;
         AV67Ciudadwwds_5_paisnombre1 = AV19PaisNombre1;
         AV68Ciudadwwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV69Ciudadwwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV70Ciudadwwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV71Ciudadwwds_9_ciudadnombre2 = AV25CiudadNombre2;
         AV72Ciudadwwds_10_paisnombre2 = AV26PaisNombre2;
         AV73Ciudadwwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV74Ciudadwwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV75Ciudadwwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV76Ciudadwwds_14_ciudadnombre3 = AV30CiudadNombre3;
         AV77Ciudadwwds_15_paisnombre3 = AV31PaisNombre3;
         AV78Ciudadwwds_16_tfciudadid = AV37TFCiudadId;
         AV79Ciudadwwds_17_tfciudadid_to = AV38TFCiudadId_To;
         AV80Ciudadwwds_18_tfpaisid = AV39TFPaisID;
         AV81Ciudadwwds_19_tfpaisid_sel = AV40TFPaisID_Sel;
         AV82Ciudadwwds_20_tfpaisnombre = AV41TFPaisNombre;
         AV83Ciudadwwds_21_tfpaisnombre_sel = AV42TFPaisNombre_Sel;
         AV84Ciudadwwds_22_tfciudadnombre = AV43TFCiudadNombre;
         AV85Ciudadwwds_23_tfciudadnombre_sel = AV44TFCiudadNombre_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV63Ciudadwwds_1_filterfulltext ,
                                              AV64Ciudadwwds_2_dynamicfiltersselector1 ,
                                              AV65Ciudadwwds_3_dynamicfiltersoperator1 ,
                                              AV66Ciudadwwds_4_ciudadnombre1 ,
                                              AV67Ciudadwwds_5_paisnombre1 ,
                                              AV68Ciudadwwds_6_dynamicfiltersenabled2 ,
                                              AV69Ciudadwwds_7_dynamicfiltersselector2 ,
                                              AV70Ciudadwwds_8_dynamicfiltersoperator2 ,
                                              AV71Ciudadwwds_9_ciudadnombre2 ,
                                              AV72Ciudadwwds_10_paisnombre2 ,
                                              AV73Ciudadwwds_11_dynamicfiltersenabled3 ,
                                              AV74Ciudadwwds_12_dynamicfiltersselector3 ,
                                              AV75Ciudadwwds_13_dynamicfiltersoperator3 ,
                                              AV76Ciudadwwds_14_ciudadnombre3 ,
                                              AV77Ciudadwwds_15_paisnombre3 ,
                                              AV78Ciudadwwds_16_tfciudadid ,
                                              AV79Ciudadwwds_17_tfciudadid_to ,
                                              AV81Ciudadwwds_19_tfpaisid_sel ,
                                              AV80Ciudadwwds_18_tfpaisid ,
                                              AV83Ciudadwwds_21_tfpaisnombre_sel ,
                                              AV82Ciudadwwds_20_tfpaisnombre ,
                                              AV85Ciudadwwds_23_tfciudadnombre_sel ,
                                              AV84Ciudadwwds_22_tfciudadnombre ,
                                              A144CiudadId ,
                                              A116PaisID ,
                                              A165PaisNombre ,
                                              A208CiudadNombre ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV63Ciudadwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Ciudadwwds_1_filterfulltext), "%", "");
         lV63Ciudadwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Ciudadwwds_1_filterfulltext), "%", "");
         lV63Ciudadwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Ciudadwwds_1_filterfulltext), "%", "");
         lV63Ciudadwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Ciudadwwds_1_filterfulltext), "%", "");
         lV66Ciudadwwds_4_ciudadnombre1 = StringUtil.PadR( StringUtil.RTrim( AV66Ciudadwwds_4_ciudadnombre1), 80, "%");
         lV66Ciudadwwds_4_ciudadnombre1 = StringUtil.PadR( StringUtil.RTrim( AV66Ciudadwwds_4_ciudadnombre1), 80, "%");
         lV67Ciudadwwds_5_paisnombre1 = StringUtil.PadR( StringUtil.RTrim( AV67Ciudadwwds_5_paisnombre1), 80, "%");
         lV67Ciudadwwds_5_paisnombre1 = StringUtil.PadR( StringUtil.RTrim( AV67Ciudadwwds_5_paisnombre1), 80, "%");
         lV71Ciudadwwds_9_ciudadnombre2 = StringUtil.PadR( StringUtil.RTrim( AV71Ciudadwwds_9_ciudadnombre2), 80, "%");
         lV71Ciudadwwds_9_ciudadnombre2 = StringUtil.PadR( StringUtil.RTrim( AV71Ciudadwwds_9_ciudadnombre2), 80, "%");
         lV72Ciudadwwds_10_paisnombre2 = StringUtil.PadR( StringUtil.RTrim( AV72Ciudadwwds_10_paisnombre2), 80, "%");
         lV72Ciudadwwds_10_paisnombre2 = StringUtil.PadR( StringUtil.RTrim( AV72Ciudadwwds_10_paisnombre2), 80, "%");
         lV76Ciudadwwds_14_ciudadnombre3 = StringUtil.PadR( StringUtil.RTrim( AV76Ciudadwwds_14_ciudadnombre3), 80, "%");
         lV76Ciudadwwds_14_ciudadnombre3 = StringUtil.PadR( StringUtil.RTrim( AV76Ciudadwwds_14_ciudadnombre3), 80, "%");
         lV77Ciudadwwds_15_paisnombre3 = StringUtil.PadR( StringUtil.RTrim( AV77Ciudadwwds_15_paisnombre3), 80, "%");
         lV77Ciudadwwds_15_paisnombre3 = StringUtil.PadR( StringUtil.RTrim( AV77Ciudadwwds_15_paisnombre3), 80, "%");
         lV80Ciudadwwds_18_tfpaisid = StringUtil.PadR( StringUtil.RTrim( AV80Ciudadwwds_18_tfpaisid), 2, "%");
         lV82Ciudadwwds_20_tfpaisnombre = StringUtil.PadR( StringUtil.RTrim( AV82Ciudadwwds_20_tfpaisnombre), 80, "%");
         lV84Ciudadwwds_22_tfciudadnombre = StringUtil.PadR( StringUtil.RTrim( AV84Ciudadwwds_22_tfciudadnombre), 80, "%");
         /* Using cursor P00AN2 */
         pr_default.execute(0, new Object[] {lV63Ciudadwwds_1_filterfulltext, lV63Ciudadwwds_1_filterfulltext, lV63Ciudadwwds_1_filterfulltext, lV63Ciudadwwds_1_filterfulltext, lV66Ciudadwwds_4_ciudadnombre1, lV66Ciudadwwds_4_ciudadnombre1, lV67Ciudadwwds_5_paisnombre1, lV67Ciudadwwds_5_paisnombre1, lV71Ciudadwwds_9_ciudadnombre2, lV71Ciudadwwds_9_ciudadnombre2, lV72Ciudadwwds_10_paisnombre2, lV72Ciudadwwds_10_paisnombre2, lV76Ciudadwwds_14_ciudadnombre3, lV76Ciudadwwds_14_ciudadnombre3, lV77Ciudadwwds_15_paisnombre3, lV77Ciudadwwds_15_paisnombre3, AV78Ciudadwwds_16_tfciudadid, AV79Ciudadwwds_17_tfciudadid_to, lV80Ciudadwwds_18_tfpaisid, AV81Ciudadwwds_19_tfpaisid_sel, lV82Ciudadwwds_20_tfpaisnombre, AV83Ciudadwwds_21_tfpaisnombre_sel, lV84Ciudadwwds_22_tfciudadnombre, AV85Ciudadwwds_23_tfciudadnombre_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A208CiudadNombre = P00AN2_A208CiudadNombre[0];
            A165PaisNombre = P00AN2_A165PaisNombre[0];
            A116PaisID = P00AN2_A116PaisID[0];
            A144CiudadId = P00AN2_A144CiudadId[0];
            A40001CiudadImagen1_GXI = P00AN2_A40001CiudadImagen1_GXI[0];
            A40000PaisBandera_GXI = P00AN2_A40000PaisBandera_GXI[0];
            A209CiudadImagen1 = P00AN2_A209CiudadImagen1[0];
            A207PaisBandera = P00AN2_A207PaisBandera[0];
            A165PaisNombre = P00AN2_A165PaisNombre[0];
            A40000PaisBandera_GXI = P00AN2_A40000PaisBandera_GXI[0];
            A207PaisBandera = P00AN2_A207PaisBandera[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            HAN0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A144CiudadId), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 122, Gx_line+25, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A116PaisID, "")), 126, Gx_line+10, 218, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A165PaisNombre, "")), 222, Gx_line+10, 406, Gx_line+25, 0+16, 0, 0, 0) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A207PaisBandera)) ? A40000PaisBandera_GXI : A207PaisBandera);
            getPrinter().GxDrawBitMap(sImgUrl, 410, Gx_line+10, 502, Gx_line+25) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A208CiudadNombre, "")), 506, Gx_line+10, 690, Gx_line+25, 0+16, 0, 0, 0) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A209CiudadImagen1)) ? A40001CiudadImagen1_GXI : A209CiudadImagen1);
            getPrinter().GxDrawBitMap(sImgUrl, 694, Gx_line+10, 787, Gx_line+25) ;
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
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S151( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV33Session.Get("CiudadWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "CiudadWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("CiudadWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV35GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV35GridState.gxTpr_Ordereddsc;
         AV86GXV1 = 1;
         while ( AV86GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV86GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCIUDADID") == 0 )
            {
               AV37TFCiudadId = (long)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV38TFCiudadId_To = (long)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPAISID") == 0 )
            {
               AV39TFPaisID = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPAISID_SEL") == 0 )
            {
               AV40TFPaisID_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPAISNOMBRE") == 0 )
            {
               AV41TFPaisNombre = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPAISNOMBRE_SEL") == 0 )
            {
               AV42TFPaisNombre_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCIUDADNOMBRE") == 0 )
            {
               AV43TFCiudadNombre = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCIUDADNOMBRE_SEL") == 0 )
            {
               AV44TFCiudadNombre_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            AV86GXV1 = (int)(AV86GXV1+1);
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

      protected void HAN0( bool bFoot ,
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
         AV59Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV57Title = "";
         AV13FilterFullText = "";
         AV35GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV32GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV16CiudadNombre1 = "";
         AV17FilterCiudadNombreDescription = "";
         AV18CiudadNombre = "";
         AV19PaisNombre1 = "";
         AV20FilterPaisNombreDescription = "";
         AV21PaisNombre = "";
         AV23DynamicFiltersSelector2 = "";
         AV25CiudadNombre2 = "";
         AV26PaisNombre2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30CiudadNombre3 = "";
         AV31PaisNombre3 = "";
         AV45TFCiudadId_To_Description = "";
         AV40TFPaisID_Sel = "";
         AV39TFPaisID = "";
         AV42TFPaisNombre_Sel = "";
         AV41TFPaisNombre = "";
         AV44TFCiudadNombre_Sel = "";
         AV43TFCiudadNombre = "";
         AV63Ciudadwwds_1_filterfulltext = "";
         AV64Ciudadwwds_2_dynamicfiltersselector1 = "";
         AV66Ciudadwwds_4_ciudadnombre1 = "";
         AV67Ciudadwwds_5_paisnombre1 = "";
         AV69Ciudadwwds_7_dynamicfiltersselector2 = "";
         AV71Ciudadwwds_9_ciudadnombre2 = "";
         AV72Ciudadwwds_10_paisnombre2 = "";
         AV74Ciudadwwds_12_dynamicfiltersselector3 = "";
         AV76Ciudadwwds_14_ciudadnombre3 = "";
         AV77Ciudadwwds_15_paisnombre3 = "";
         AV80Ciudadwwds_18_tfpaisid = "";
         AV81Ciudadwwds_19_tfpaisid_sel = "";
         AV82Ciudadwwds_20_tfpaisnombre = "";
         AV83Ciudadwwds_21_tfpaisnombre_sel = "";
         AV84Ciudadwwds_22_tfciudadnombre = "";
         AV85Ciudadwwds_23_tfciudadnombre_sel = "";
         lV63Ciudadwwds_1_filterfulltext = "";
         lV66Ciudadwwds_4_ciudadnombre1 = "";
         lV67Ciudadwwds_5_paisnombre1 = "";
         lV71Ciudadwwds_9_ciudadnombre2 = "";
         lV72Ciudadwwds_10_paisnombre2 = "";
         lV76Ciudadwwds_14_ciudadnombre3 = "";
         lV77Ciudadwwds_15_paisnombre3 = "";
         lV80Ciudadwwds_18_tfpaisid = "";
         lV82Ciudadwwds_20_tfpaisnombre = "";
         lV84Ciudadwwds_22_tfciudadnombre = "";
         A116PaisID = "";
         A165PaisNombre = "";
         A208CiudadNombre = "";
         P00AN2_A208CiudadNombre = new string[] {""} ;
         P00AN2_A165PaisNombre = new string[] {""} ;
         P00AN2_A116PaisID = new string[] {""} ;
         P00AN2_A144CiudadId = new long[1] ;
         P00AN2_A40001CiudadImagen1_GXI = new string[] {""} ;
         P00AN2_A40000PaisBandera_GXI = new string[] {""} ;
         P00AN2_A209CiudadImagen1 = new string[] {""} ;
         P00AN2_A207PaisBandera = new string[] {""} ;
         A40001CiudadImagen1_GXI = "";
         A40000PaisBandera_GXI = "";
         A209CiudadImagen1 = "";
         A207PaisBandera = "";
         sImgUrl = "";
         AV33Session = context.GetSession();
         AV36GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ciudadwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00AN2_A208CiudadNombre, P00AN2_A165PaisNombre, P00AN2_A116PaisID, P00AN2_A144CiudadId, P00AN2_A40001CiudadImagen1_GXI, P00AN2_A40000PaisBandera_GXI, P00AN2_A209CiudadImagen1, P00AN2_A207PaisBandera
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV59Pgmname = "CiudadWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV59Pgmname = "CiudadWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV15DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short AV65Ciudadwwds_3_dynamicfiltersoperator1 ;
      private short AV70Ciudadwwds_8_dynamicfiltersoperator2 ;
      private short AV75Ciudadwwds_13_dynamicfiltersoperator3 ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV86GXV1 ;
      private long AV37TFCiudadId ;
      private long AV38TFCiudadId_To ;
      private long AV78Ciudadwwds_16_tfciudadid ;
      private long AV79Ciudadwwds_17_tfciudadid_to ;
      private long A144CiudadId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV59Pgmname ;
      private string GXEncryptionTmp ;
      private string AV16CiudadNombre1 ;
      private string AV18CiudadNombre ;
      private string AV19PaisNombre1 ;
      private string AV21PaisNombre ;
      private string AV25CiudadNombre2 ;
      private string AV26PaisNombre2 ;
      private string AV30CiudadNombre3 ;
      private string AV31PaisNombre3 ;
      private string AV40TFPaisID_Sel ;
      private string AV39TFPaisID ;
      private string AV42TFPaisNombre_Sel ;
      private string AV41TFPaisNombre ;
      private string AV44TFCiudadNombre_Sel ;
      private string AV43TFCiudadNombre ;
      private string AV66Ciudadwwds_4_ciudadnombre1 ;
      private string AV67Ciudadwwds_5_paisnombre1 ;
      private string AV71Ciudadwwds_9_ciudadnombre2 ;
      private string AV72Ciudadwwds_10_paisnombre2 ;
      private string AV76Ciudadwwds_14_ciudadnombre3 ;
      private string AV77Ciudadwwds_15_paisnombre3 ;
      private string AV80Ciudadwwds_18_tfpaisid ;
      private string AV81Ciudadwwds_19_tfpaisid_sel ;
      private string AV82Ciudadwwds_20_tfpaisnombre ;
      private string AV83Ciudadwwds_21_tfpaisnombre_sel ;
      private string AV84Ciudadwwds_22_tfciudadnombre ;
      private string AV85Ciudadwwds_23_tfciudadnombre_sel ;
      private string lV66Ciudadwwds_4_ciudadnombre1 ;
      private string lV67Ciudadwwds_5_paisnombre1 ;
      private string lV71Ciudadwwds_9_ciudadnombre2 ;
      private string lV72Ciudadwwds_10_paisnombre2 ;
      private string lV76Ciudadwwds_14_ciudadnombre3 ;
      private string lV77Ciudadwwds_15_paisnombre3 ;
      private string lV80Ciudadwwds_18_tfpaisid ;
      private string lV82Ciudadwwds_20_tfpaisnombre ;
      private string lV84Ciudadwwds_22_tfciudadnombre ;
      private string A116PaisID ;
      private string A165PaisNombre ;
      private string A208CiudadNombre ;
      private string sImgUrl ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV46TempBoolean ;
      private bool AV68Ciudadwwds_6_dynamicfiltersenabled2 ;
      private bool AV73Ciudadwwds_11_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private string AV57Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV17FilterCiudadNombreDescription ;
      private string AV20FilterPaisNombreDescription ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV45TFCiudadId_To_Description ;
      private string AV63Ciudadwwds_1_filterfulltext ;
      private string AV64Ciudadwwds_2_dynamicfiltersselector1 ;
      private string AV69Ciudadwwds_7_dynamicfiltersselector2 ;
      private string AV74Ciudadwwds_12_dynamicfiltersselector3 ;
      private string lV63Ciudadwwds_1_filterfulltext ;
      private string A40001CiudadImagen1_GXI ;
      private string A40000PaisBandera_GXI ;
      private string AV55PageInfo ;
      private string AV52DateInfo ;
      private string AV50AppName ;
      private string AV56Phone ;
      private string AV54Mail ;
      private string AV58Website ;
      private string AV47AddressLine1 ;
      private string AV48AddressLine2 ;
      private string AV49AddressLine3 ;
      private string A209CiudadImagen1 ;
      private string A207PaisBandera ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV32GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private string[] P00AN2_A208CiudadNombre ;
      private string[] P00AN2_A165PaisNombre ;
      private string[] P00AN2_A116PaisID ;
      private long[] P00AN2_A144CiudadId ;
      private string[] P00AN2_A40001CiudadImagen1_GXI ;
      private string[] P00AN2_A40000PaisBandera_GXI ;
      private string[] P00AN2_A209CiudadImagen1 ;
      private string[] P00AN2_A207PaisBandera ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
   }

   public class ciudadwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AN2( IGxContext context ,
                                             string AV63Ciudadwwds_1_filterfulltext ,
                                             string AV64Ciudadwwds_2_dynamicfiltersselector1 ,
                                             short AV65Ciudadwwds_3_dynamicfiltersoperator1 ,
                                             string AV66Ciudadwwds_4_ciudadnombre1 ,
                                             string AV67Ciudadwwds_5_paisnombre1 ,
                                             bool AV68Ciudadwwds_6_dynamicfiltersenabled2 ,
                                             string AV69Ciudadwwds_7_dynamicfiltersselector2 ,
                                             short AV70Ciudadwwds_8_dynamicfiltersoperator2 ,
                                             string AV71Ciudadwwds_9_ciudadnombre2 ,
                                             string AV72Ciudadwwds_10_paisnombre2 ,
                                             bool AV73Ciudadwwds_11_dynamicfiltersenabled3 ,
                                             string AV74Ciudadwwds_12_dynamicfiltersselector3 ,
                                             short AV75Ciudadwwds_13_dynamicfiltersoperator3 ,
                                             string AV76Ciudadwwds_14_ciudadnombre3 ,
                                             string AV77Ciudadwwds_15_paisnombre3 ,
                                             long AV78Ciudadwwds_16_tfciudadid ,
                                             long AV79Ciudadwwds_17_tfciudadid_to ,
                                             string AV81Ciudadwwds_19_tfpaisid_sel ,
                                             string AV80Ciudadwwds_18_tfpaisid ,
                                             string AV83Ciudadwwds_21_tfpaisnombre_sel ,
                                             string AV82Ciudadwwds_20_tfpaisnombre ,
                                             string AV85Ciudadwwds_23_tfciudadnombre_sel ,
                                             string AV84Ciudadwwds_22_tfciudadnombre ,
                                             long A144CiudadId ,
                                             string A116PaisID ,
                                             string A165PaisNombre ,
                                             string A208CiudadNombre ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[24];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[CiudadNombre], T2.[PaisNombre], T1.[PaisID], T1.[CiudadId], T1.[CiudadImagen1_GXI], T2.[PaisBandera_GXI], T1.[CiudadImagen1], T2.[PaisBandera] FROM ([Ciudad] T1 INNER JOIN [Pais] T2 ON T2.[PaisID] = T1.[PaisID])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Ciudadwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[CiudadId] AS decimal(18,0))) like '%' + @lV63Ciudadwwds_1_filterfulltext) or ( UPPER(T1.[PaisID]) like '%' + UPPER(@lV63Ciudadwwds_1_filterfulltext)) or ( UPPER(T2.[PaisNombre]) like '%' + UPPER(@lV63Ciudadwwds_1_filterfulltext)) or ( UPPER(T1.[CiudadNombre]) like '%' + UPPER(@lV63Ciudadwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Ciudadwwds_2_dynamicfiltersselector1, "CIUDADNOMBRE") == 0 ) && ( AV65Ciudadwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Ciudadwwds_4_ciudadnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like UPPER(@lV66Ciudadwwds_4_ciudadnombre1))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Ciudadwwds_2_dynamicfiltersselector1, "CIUDADNOMBRE") == 0 ) && ( AV65Ciudadwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Ciudadwwds_4_ciudadnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like '%' + UPPER(@lV66Ciudadwwds_4_ciudadnombre1))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Ciudadwwds_2_dynamicfiltersselector1, "PAISNOMBRE") == 0 ) && ( AV65Ciudadwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Ciudadwwds_5_paisnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like UPPER(@lV67Ciudadwwds_5_paisnombre1))");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Ciudadwwds_2_dynamicfiltersselector1, "PAISNOMBRE") == 0 ) && ( AV65Ciudadwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Ciudadwwds_5_paisnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like '%' + UPPER(@lV67Ciudadwwds_5_paisnombre1))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( AV68Ciudadwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Ciudadwwds_7_dynamicfiltersselector2, "CIUDADNOMBRE") == 0 ) && ( AV70Ciudadwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Ciudadwwds_9_ciudadnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like UPPER(@lV71Ciudadwwds_9_ciudadnombre2))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( AV68Ciudadwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Ciudadwwds_7_dynamicfiltersselector2, "CIUDADNOMBRE") == 0 ) && ( AV70Ciudadwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Ciudadwwds_9_ciudadnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like '%' + UPPER(@lV71Ciudadwwds_9_ciudadnombre2))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( AV68Ciudadwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Ciudadwwds_7_dynamicfiltersselector2, "PAISNOMBRE") == 0 ) && ( AV70Ciudadwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Ciudadwwds_10_paisnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like UPPER(@lV72Ciudadwwds_10_paisnombre2))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( AV68Ciudadwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Ciudadwwds_7_dynamicfiltersselector2, "PAISNOMBRE") == 0 ) && ( AV70Ciudadwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Ciudadwwds_10_paisnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like '%' + UPPER(@lV72Ciudadwwds_10_paisnombre2))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( AV73Ciudadwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Ciudadwwds_12_dynamicfiltersselector3, "CIUDADNOMBRE") == 0 ) && ( AV75Ciudadwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Ciudadwwds_14_ciudadnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like UPPER(@lV76Ciudadwwds_14_ciudadnombre3))");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( AV73Ciudadwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Ciudadwwds_12_dynamicfiltersselector3, "CIUDADNOMBRE") == 0 ) && ( AV75Ciudadwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Ciudadwwds_14_ciudadnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like '%' + UPPER(@lV76Ciudadwwds_14_ciudadnombre3))");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( AV73Ciudadwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Ciudadwwds_12_dynamicfiltersselector3, "PAISNOMBRE") == 0 ) && ( AV75Ciudadwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Ciudadwwds_15_paisnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like UPPER(@lV77Ciudadwwds_15_paisnombre3))");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( AV73Ciudadwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Ciudadwwds_12_dynamicfiltersselector3, "PAISNOMBRE") == 0 ) && ( AV75Ciudadwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Ciudadwwds_15_paisnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like '%' + UPPER(@lV77Ciudadwwds_15_paisnombre3))");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( ! (0==AV78Ciudadwwds_16_tfciudadid) )
         {
            AddWhere(sWhereString, "(T1.[CiudadId] >= @AV78Ciudadwwds_16_tfciudadid)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( ! (0==AV79Ciudadwwds_17_tfciudadid_to) )
         {
            AddWhere(sWhereString, "(T1.[CiudadId] <= @AV79Ciudadwwds_17_tfciudadid_to)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Ciudadwwds_19_tfpaisid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Ciudadwwds_18_tfpaisid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PaisID]) like UPPER(@lV80Ciudadwwds_18_tfpaisid))");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Ciudadwwds_19_tfpaisid_sel)) && ! ( StringUtil.StrCmp(AV81Ciudadwwds_19_tfpaisid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PaisID] = @AV81Ciudadwwds_19_tfpaisid_sel)");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( StringUtil.StrCmp(AV81Ciudadwwds_19_tfpaisid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PaisID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Ciudadwwds_21_tfpaisnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Ciudadwwds_20_tfpaisnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like UPPER(@lV82Ciudadwwds_20_tfpaisnombre))");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Ciudadwwds_21_tfpaisnombre_sel)) && ! ( StringUtil.StrCmp(AV83Ciudadwwds_21_tfpaisnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[PaisNombre] = @AV83Ciudadwwds_21_tfpaisnombre_sel)");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( StringUtil.StrCmp(AV83Ciudadwwds_21_tfpaisnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[PaisNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Ciudadwwds_23_tfciudadnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Ciudadwwds_22_tfciudadnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like UPPER(@lV84Ciudadwwds_22_tfciudadnombre))");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Ciudadwwds_23_tfciudadnombre_sel)) && ! ( StringUtil.StrCmp(AV85Ciudadwwds_23_tfciudadnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[CiudadNombre] = @AV85Ciudadwwds_23_tfciudadnombre_sel)");
         }
         else
         {
            GXv_int2[23] = 1;
         }
         if ( StringUtil.StrCmp(AV85Ciudadwwds_23_tfciudadnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[CiudadNombre] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CiudadNombre]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CiudadNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CiudadId]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CiudadId] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[PaisID]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[PaisID] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[PaisNombre]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[PaisNombre] DESC";
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
                     return conditional_P00AN2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] );
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
          Object[] prmP00AN2;
          prmP00AN2 = new Object[] {
          new ParDef("@lV63Ciudadwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV63Ciudadwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV63Ciudadwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV63Ciudadwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV66Ciudadwwds_4_ciudadnombre1",GXType.Char,80,0) ,
          new ParDef("@lV66Ciudadwwds_4_ciudadnombre1",GXType.Char,80,0) ,
          new ParDef("@lV67Ciudadwwds_5_paisnombre1",GXType.Char,80,0) ,
          new ParDef("@lV67Ciudadwwds_5_paisnombre1",GXType.Char,80,0) ,
          new ParDef("@lV71Ciudadwwds_9_ciudadnombre2",GXType.Char,80,0) ,
          new ParDef("@lV71Ciudadwwds_9_ciudadnombre2",GXType.Char,80,0) ,
          new ParDef("@lV72Ciudadwwds_10_paisnombre2",GXType.Char,80,0) ,
          new ParDef("@lV72Ciudadwwds_10_paisnombre2",GXType.Char,80,0) ,
          new ParDef("@lV76Ciudadwwds_14_ciudadnombre3",GXType.Char,80,0) ,
          new ParDef("@lV76Ciudadwwds_14_ciudadnombre3",GXType.Char,80,0) ,
          new ParDef("@lV77Ciudadwwds_15_paisnombre3",GXType.Char,80,0) ,
          new ParDef("@lV77Ciudadwwds_15_paisnombre3",GXType.Char,80,0) ,
          new ParDef("@AV78Ciudadwwds_16_tfciudadid",GXType.Decimal,18,0) ,
          new ParDef("@AV79Ciudadwwds_17_tfciudadid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV80Ciudadwwds_18_tfpaisid",GXType.Char,2,0) ,
          new ParDef("@AV81Ciudadwwds_19_tfpaisid_sel",GXType.NChar,2,0) ,
          new ParDef("@lV82Ciudadwwds_20_tfpaisnombre",GXType.Char,80,0) ,
          new ParDef("@AV83Ciudadwwds_21_tfpaisnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV84Ciudadwwds_22_tfciudadnombre",GXType.Char,80,0) ,
          new ParDef("@AV85Ciudadwwds_23_tfciudadnombre_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AN2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AN2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((string[]) buf[2])[0] = rslt.getString(3, 2);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
                ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(5));
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(6));
                return;
       }
    }

 }

}
