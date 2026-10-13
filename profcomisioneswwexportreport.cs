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
   public class profcomisioneswwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public profcomisioneswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public profcomisioneswwexportreport( IGxContext context )
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
         setOutputFileName("ProfComisionesWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfComisiones", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV65Pgmname));
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
               AV63Title = context.GetMessage( "Lista de Comisiones para Profesionales", "");
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
            H5V0( true, 0) ;
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
            H5V0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV32GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "PROFCOMISIONESAUTOENUN") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV16ProfComisionesAutoEnun1 = (short)(Math.Round(NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               if ( ! (0==AV16ProfComisionesAutoEnun1) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterProfComisionesAutoEnunDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Auto Enun", ""), "<", "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterProfComisionesAutoEnunDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Auto Enun", ""), "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 2 )
                  {
                     AV17FilterProfComisionesAutoEnunDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Auto Enun", ""), ">", "", "", "", "", "", "", "");
                  }
                  AV18ProfComisionesAutoEnun = AV16ProfComisionesAutoEnun1;
                  H5V0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterProfComisionesAutoEnunDescription, "")), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18ProfComisionesAutoEnun), "ZZZ9")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "PROFESIONALESPRIMERNOMBRE") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV19ProfesionalesPrimerNombre1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19ProfesionalesPrimerNombre1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV20FilterProfesionalesPrimerNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Primer Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV20FilterProfesionalesPrimerNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Primer Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV21ProfesionalesPrimerNombre = AV19ProfesionalesPrimerNombre1;
                  H5V0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterProfesionalesPrimerNombreDescription, "")), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21ProfesionalesPrimerNombre, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROFCOMISIONESAUTOENUN") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV25ProfComisionesAutoEnun2 = (short)(Math.Round(NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  if ( ! (0==AV25ProfComisionesAutoEnun2) )
                  {
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterProfComisionesAutoEnunDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Auto Enun", ""), "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterProfComisionesAutoEnunDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Auto Enun", ""), "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 2 )
                     {
                        AV17FilterProfComisionesAutoEnunDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Auto Enun", ""), ">", "", "", "", "", "", "", "");
                     }
                     AV18ProfComisionesAutoEnun = AV25ProfComisionesAutoEnun2;
                     H5V0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterProfComisionesAutoEnunDescription, "")), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18ProfComisionesAutoEnun), "ZZZ9")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROFESIONALESPRIMERNOMBRE") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV26ProfesionalesPrimerNombre2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ProfesionalesPrimerNombre2)) )
                  {
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV20FilterProfesionalesPrimerNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Primer Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV20FilterProfesionalesPrimerNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Primer Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV21ProfesionalesPrimerNombre = AV26ProfesionalesPrimerNombre2;
                     H5V0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterProfesionalesPrimerNombreDescription, "")), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21ProfesionalesPrimerNombre, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROFCOMISIONESAUTOENUN") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV30ProfComisionesAutoEnun3 = (short)(Math.Round(NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     if ( ! (0==AV30ProfComisionesAutoEnun3) )
                     {
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterProfComisionesAutoEnunDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Auto Enun", ""), "<", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterProfComisionesAutoEnunDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Auto Enun", ""), "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 2 )
                        {
                           AV17FilterProfComisionesAutoEnunDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Auto Enun", ""), ">", "", "", "", "", "", "", "");
                        }
                        AV18ProfComisionesAutoEnun = AV30ProfComisionesAutoEnun3;
                        H5V0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterProfComisionesAutoEnunDescription, "")), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18ProfComisionesAutoEnun), "ZZZ9")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROFESIONALESPRIMERNOMBRE") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV31ProfesionalesPrimerNombre3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31ProfesionalesPrimerNombre3)) )
                     {
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV20FilterProfesionalesPrimerNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Primer Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV20FilterProfesionalesPrimerNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Primer Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV21ProfesionalesPrimerNombre = AV31ProfesionalesPrimerNombre3;
                        H5V0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterProfesionalesPrimerNombreDescription, "")), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21ProfesionalesPrimerNombre, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV37TFProfComisionesID) && (0==AV38TFProfComisionesID_To) ) )
         {
            H5V0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Comisiones ID", ""), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV37TFProfComisionesID), "ZZZZZZZZZZZZZZZZZ9")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV51TFProfComisionesID_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Comisiones ID", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H5V0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51TFProfComisionesID_To_Description, "")), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV38TFProfComisionesID_To), "ZZZZZZZZZZZZZZZZZ9")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFProfesionalesId_Sel)) )
         {
            AV52TempBoolean = (bool)(((StringUtil.StrCmp(AV40TFProfesionalesId_Sel, "<#Empty#>")==0)));
            AV40TFProfesionalesId_Sel = (AV52TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV40TFProfesionalesId_Sel);
            H5V0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Identidad", ""), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFProfesionalesId_Sel, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV40TFProfesionalesId_Sel = (AV52TempBoolean ? "<#Empty#>" : AV40TFProfesionalesId_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFProfesionalesId)) )
            {
               H5V0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Identidad", ""), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFProfesionalesId, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TFProfesionalesPrimerNombre_Sel)) )
         {
            AV52TempBoolean = (bool)(((StringUtil.StrCmp(AV42TFProfesionalesPrimerNombre_Sel, "<#Empty#>")==0)));
            AV42TFProfesionalesPrimerNombre_Sel = (AV52TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV42TFProfesionalesPrimerNombre_Sel);
            H5V0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Primer Nombre", ""), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFProfesionalesPrimerNombre_Sel, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV42TFProfesionalesPrimerNombre_Sel = (AV52TempBoolean ? "<#Empty#>" : AV42TFProfesionalesPrimerNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41TFProfesionalesPrimerNombre)) )
            {
               H5V0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Primer Nombre", ""), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFProfesionalesPrimerNombre, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44TFProfesionalesSegundoNombre_Sel)) )
         {
            AV52TempBoolean = (bool)(((StringUtil.StrCmp(AV44TFProfesionalesSegundoNombre_Sel, "<#Empty#>")==0)));
            AV44TFProfesionalesSegundoNombre_Sel = (AV52TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV44TFProfesionalesSegundoNombre_Sel);
            H5V0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Segundo Nombre", ""), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44TFProfesionalesSegundoNombre_Sel, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV44TFProfesionalesSegundoNombre_Sel = (AV52TempBoolean ? "<#Empty#>" : AV44TFProfesionalesSegundoNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TFProfesionalesSegundoNombre)) )
            {
               H5V0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Segundo Nombre", ""), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFProfesionalesSegundoNombre, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46TFProfesionalesApellidoPrimero_Sel)) )
         {
            AV52TempBoolean = (bool)(((StringUtil.StrCmp(AV46TFProfesionalesApellidoPrimero_Sel, "<#Empty#>")==0)));
            AV46TFProfesionalesApellidoPrimero_Sel = (AV52TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV46TFProfesionalesApellidoPrimero_Sel);
            H5V0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Primero Apellido ", ""), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46TFProfesionalesApellidoPrimero_Sel, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV46TFProfesionalesApellidoPrimero_Sel = (AV52TempBoolean ? "<#Empty#>" : AV46TFProfesionalesApellidoPrimero_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45TFProfesionalesApellidoPrimero)) )
            {
               H5V0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Primero Apellido ", ""), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45TFProfesionalesApellidoPrimero, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48TFProfesionalesApellidoSegundo_Sel)) )
         {
            AV52TempBoolean = (bool)(((StringUtil.StrCmp(AV48TFProfesionalesApellidoSegundo_Sel, "<#Empty#>")==0)));
            AV48TFProfesionalesApellidoSegundo_Sel = (AV52TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV48TFProfesionalesApellidoSegundo_Sel);
            H5V0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Segundo Apellido ", ""), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48TFProfesionalesApellidoSegundo_Sel, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV48TFProfesionalesApellidoSegundo_Sel = (AV52TempBoolean ? "<#Empty#>" : AV48TFProfesionalesApellidoSegundo_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47TFProfesionalesApellidoSegundo)) )
            {
               H5V0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Segundo Apellido ", ""), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47TFProfesionalesApellidoSegundo, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50TFProfesionalesTelefono_Sel)) )
         {
            AV52TempBoolean = (bool)(((StringUtil.StrCmp(AV50TFProfesionalesTelefono_Sel, "<#Empty#>")==0)));
            AV50TFProfesionalesTelefono_Sel = (AV52TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV50TFProfesionalesTelefono_Sel);
            H5V0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Teléfono", ""), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50TFProfesionalesTelefono_Sel, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV50TFProfesionalesTelefono_Sel = (AV52TempBoolean ? "<#Empty#>" : AV50TFProfesionalesTelefono_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49TFProfesionalesTelefono)) )
            {
               H5V0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Teléfono", ""), 25, Gx_line+0, 183, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49TFProfesionalesTelefono, "")), 183, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H5V0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H5V0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Comisiones ID", ""), 30, Gx_line+10, 86, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Identidad", ""), 90, Gx_line+10, 202, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Primer Nombre", ""), 206, Gx_line+10, 318, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Segundo Nombre", ""), 322, Gx_line+10, 434, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Primero Apellido ", ""), 438, Gx_line+10, 551, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Segundo Apellido ", ""), 555, Gx_line+10, 669, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Teléfono", ""), 673, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV69Profcomisioneswwds_1_filterfulltext = AV13FilterFullText;
         AV70Profcomisioneswwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV71Profcomisioneswwds_3_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV72Profcomisioneswwds_4_profcomisionesautoenun1 = AV16ProfComisionesAutoEnun1;
         AV73Profcomisioneswwds_5_profesionalesprimernombre1 = AV19ProfesionalesPrimerNombre1;
         AV74Profcomisioneswwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV75Profcomisioneswwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV76Profcomisioneswwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV77Profcomisioneswwds_9_profcomisionesautoenun2 = AV25ProfComisionesAutoEnun2;
         AV78Profcomisioneswwds_10_profesionalesprimernombre2 = AV26ProfesionalesPrimerNombre2;
         AV79Profcomisioneswwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV80Profcomisioneswwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV81Profcomisioneswwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV82Profcomisioneswwds_14_profcomisionesautoenun3 = AV30ProfComisionesAutoEnun3;
         AV83Profcomisioneswwds_15_profesionalesprimernombre3 = AV31ProfesionalesPrimerNombre3;
         AV84Profcomisioneswwds_16_tfprofcomisionesid = AV37TFProfComisionesID;
         AV85Profcomisioneswwds_17_tfprofcomisionesid_to = AV38TFProfComisionesID_To;
         AV86Profcomisioneswwds_18_tfprofesionalesid = AV39TFProfesionalesId;
         AV87Profcomisioneswwds_19_tfprofesionalesid_sel = AV40TFProfesionalesId_Sel;
         AV88Profcomisioneswwds_20_tfprofesionalesprimernombre = AV41TFProfesionalesPrimerNombre;
         AV89Profcomisioneswwds_21_tfprofesionalesprimernombre_sel = AV42TFProfesionalesPrimerNombre_Sel;
         AV90Profcomisioneswwds_22_tfprofesionalessegundonombre = AV43TFProfesionalesSegundoNombre;
         AV91Profcomisioneswwds_23_tfprofesionalessegundonombre_sel = AV44TFProfesionalesSegundoNombre_Sel;
         AV92Profcomisioneswwds_24_tfprofesionalesapellidoprimero = AV45TFProfesionalesApellidoPrimero;
         AV93Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel = AV46TFProfesionalesApellidoPrimero_Sel;
         AV94Profcomisioneswwds_26_tfprofesionalesapellidosegundo = AV47TFProfesionalesApellidoSegundo;
         AV95Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel = AV48TFProfesionalesApellidoSegundo_Sel;
         AV96Profcomisioneswwds_28_tfprofesionalestelefono = AV49TFProfesionalesTelefono;
         AV97Profcomisioneswwds_29_tfprofesionalestelefono_sel = AV50TFProfesionalesTelefono_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV69Profcomisioneswwds_1_filterfulltext ,
                                              AV70Profcomisioneswwds_2_dynamicfiltersselector1 ,
                                              AV71Profcomisioneswwds_3_dynamicfiltersoperator1 ,
                                              AV72Profcomisioneswwds_4_profcomisionesautoenun1 ,
                                              AV73Profcomisioneswwds_5_profesionalesprimernombre1 ,
                                              AV74Profcomisioneswwds_6_dynamicfiltersenabled2 ,
                                              AV75Profcomisioneswwds_7_dynamicfiltersselector2 ,
                                              AV76Profcomisioneswwds_8_dynamicfiltersoperator2 ,
                                              AV77Profcomisioneswwds_9_profcomisionesautoenun2 ,
                                              AV78Profcomisioneswwds_10_profesionalesprimernombre2 ,
                                              AV79Profcomisioneswwds_11_dynamicfiltersenabled3 ,
                                              AV80Profcomisioneswwds_12_dynamicfiltersselector3 ,
                                              AV81Profcomisioneswwds_13_dynamicfiltersoperator3 ,
                                              AV82Profcomisioneswwds_14_profcomisionesautoenun3 ,
                                              AV83Profcomisioneswwds_15_profesionalesprimernombre3 ,
                                              AV84Profcomisioneswwds_16_tfprofcomisionesid ,
                                              AV85Profcomisioneswwds_17_tfprofcomisionesid_to ,
                                              AV87Profcomisioneswwds_19_tfprofesionalesid_sel ,
                                              AV86Profcomisioneswwds_18_tfprofesionalesid ,
                                              AV89Profcomisioneswwds_21_tfprofesionalesprimernombre_sel ,
                                              AV88Profcomisioneswwds_20_tfprofesionalesprimernombre ,
                                              AV91Profcomisioneswwds_23_tfprofesionalessegundonombre_sel ,
                                              AV90Profcomisioneswwds_22_tfprofesionalessegundonombre ,
                                              AV93Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel ,
                                              AV92Profcomisioneswwds_24_tfprofesionalesapellidoprimero ,
                                              AV95Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel ,
                                              AV94Profcomisioneswwds_26_tfprofesionalesapellidosegundo ,
                                              AV97Profcomisioneswwds_29_tfprofesionalestelefono_sel ,
                                              AV96Profcomisioneswwds_28_tfprofesionalestelefono ,
                                              A450ProfComisionesID ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A451ProfComisionesAutoEnun ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV69Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV69Profcomisioneswwds_1_filterfulltext), "%", "");
         lV69Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV69Profcomisioneswwds_1_filterfulltext), "%", "");
         lV69Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV69Profcomisioneswwds_1_filterfulltext), "%", "");
         lV69Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV69Profcomisioneswwds_1_filterfulltext), "%", "");
         lV69Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV69Profcomisioneswwds_1_filterfulltext), "%", "");
         lV69Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV69Profcomisioneswwds_1_filterfulltext), "%", "");
         lV69Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV69Profcomisioneswwds_1_filterfulltext), "%", "");
         lV73Profcomisioneswwds_5_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV73Profcomisioneswwds_5_profesionalesprimernombre1), 30, "%");
         lV73Profcomisioneswwds_5_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV73Profcomisioneswwds_5_profesionalesprimernombre1), 30, "%");
         lV78Profcomisioneswwds_10_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV78Profcomisioneswwds_10_profesionalesprimernombre2), 30, "%");
         lV78Profcomisioneswwds_10_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV78Profcomisioneswwds_10_profesionalesprimernombre2), 30, "%");
         lV83Profcomisioneswwds_15_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV83Profcomisioneswwds_15_profesionalesprimernombre3), 30, "%");
         lV83Profcomisioneswwds_15_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV83Profcomisioneswwds_15_profesionalesprimernombre3), 30, "%");
         lV86Profcomisioneswwds_18_tfprofesionalesid = StringUtil.PadR( StringUtil.RTrim( AV86Profcomisioneswwds_18_tfprofesionalesid), 20, "%");
         lV88Profcomisioneswwds_20_tfprofesionalesprimernombre = StringUtil.PadR( StringUtil.RTrim( AV88Profcomisioneswwds_20_tfprofesionalesprimernombre), 30, "%");
         lV90Profcomisioneswwds_22_tfprofesionalessegundonombre = StringUtil.PadR( StringUtil.RTrim( AV90Profcomisioneswwds_22_tfprofesionalessegundonombre), 30, "%");
         lV92Profcomisioneswwds_24_tfprofesionalesapellidoprimero = StringUtil.PadR( StringUtil.RTrim( AV92Profcomisioneswwds_24_tfprofesionalesapellidoprimero), 30, "%");
         lV94Profcomisioneswwds_26_tfprofesionalesapellidosegundo = StringUtil.PadR( StringUtil.RTrim( AV94Profcomisioneswwds_26_tfprofesionalesapellidosegundo), 30, "%");
         lV96Profcomisioneswwds_28_tfprofesionalestelefono = StringUtil.PadR( StringUtil.RTrim( AV96Profcomisioneswwds_28_tfprofesionalestelefono), 20, "%");
         /* Using cursor P005V2 */
         pr_default.execute(0, new Object[] {lV69Profcomisioneswwds_1_filterfulltext, lV69Profcomisioneswwds_1_filterfulltext, lV69Profcomisioneswwds_1_filterfulltext, lV69Profcomisioneswwds_1_filterfulltext, lV69Profcomisioneswwds_1_filterfulltext, lV69Profcomisioneswwds_1_filterfulltext, lV69Profcomisioneswwds_1_filterfulltext, AV72Profcomisioneswwds_4_profcomisionesautoenun1, AV72Profcomisioneswwds_4_profcomisionesautoenun1, AV72Profcomisioneswwds_4_profcomisionesautoenun1, lV73Profcomisioneswwds_5_profesionalesprimernombre1, lV73Profcomisioneswwds_5_profesionalesprimernombre1, AV77Profcomisioneswwds_9_profcomisionesautoenun2, AV77Profcomisioneswwds_9_profcomisionesautoenun2, AV77Profcomisioneswwds_9_profcomisionesautoenun2, lV78Profcomisioneswwds_10_profesionalesprimernombre2, lV78Profcomisioneswwds_10_profesionalesprimernombre2, AV82Profcomisioneswwds_14_profcomisionesautoenun3, AV82Profcomisioneswwds_14_profcomisionesautoenun3, AV82Profcomisioneswwds_14_profcomisionesautoenun3, lV83Profcomisioneswwds_15_profesionalesprimernombre3, lV83Profcomisioneswwds_15_profesionalesprimernombre3, AV84Profcomisioneswwds_16_tfprofcomisionesid, AV85Profcomisioneswwds_17_tfprofcomisionesid_to, lV86Profcomisioneswwds_18_tfprofesionalesid, AV87Profcomisioneswwds_19_tfprofesionalesid_sel, lV88Profcomisioneswwds_20_tfprofesionalesprimernombre, AV89Profcomisioneswwds_21_tfprofesionalesprimernombre_sel, lV90Profcomisioneswwds_22_tfprofesionalessegundonombre, AV91Profcomisioneswwds_23_tfprofesionalessegundonombre_sel, lV92Profcomisioneswwds_24_tfprofesionalesapellidoprimero, AV93Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel, lV94Profcomisioneswwds_26_tfprofesionalesapellidosegundo, AV95Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel, lV96Profcomisioneswwds_28_tfprofesionalestelefono, AV97Profcomisioneswwds_29_tfprofesionalestelefono_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A170ProfesionalesTelefono = P005V2_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P005V2_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P005V2_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P005V2_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P005V2_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P005V2_A120ProfesionalesId[0];
            A450ProfComisionesID = P005V2_A450ProfComisionesID[0];
            A451ProfComisionesAutoEnun = P005V2_A451ProfComisionesAutoEnun[0];
            A170ProfesionalesTelefono = P005V2_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P005V2_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P005V2_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P005V2_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P005V2_A166ProfesionalesPrimerNombre[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H5V0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A450ProfComisionesID), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 86, Gx_line+25, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A120ProfesionalesId, "")), 90, Gx_line+10, 202, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A166ProfesionalesPrimerNombre, "")), 206, Gx_line+10, 318, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A191ProfesionalesSegundoNombre, "")), 322, Gx_line+10, 434, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A167ProfesionalesApellidoPrimero, "")), 438, Gx_line+10, 551, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A192ProfesionalesApellidoSegundo, "")), 555, Gx_line+10, 669, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A170ProfesionalesTelefono, "")), 673, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV33Session.Get("ProfComisionesWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ProfComisionesWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("ProfComisionesWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV35GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV35GridState.gxTpr_Ordereddsc;
         AV98GXV1 = 1;
         while ( AV98GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV98GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPROFCOMISIONESID") == 0 )
            {
               AV37TFProfComisionesID = (long)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV38TFProfComisionesID_To = (long)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID") == 0 )
            {
               AV39TFProfesionalesId = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID_SEL") == 0 )
            {
               AV40TFProfesionalesId_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE") == 0 )
            {
               AV41TFProfesionalesPrimerNombre = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE_SEL") == 0 )
            {
               AV42TFProfesionalesPrimerNombre_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESSEGUNDONOMBRE") == 0 )
            {
               AV43TFProfesionalesSegundoNombre = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESSEGUNDONOMBRE_SEL") == 0 )
            {
               AV44TFProfesionalesSegundoNombre_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO") == 0 )
            {
               AV45TFProfesionalesApellidoPrimero = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO_SEL") == 0 )
            {
               AV46TFProfesionalesApellidoPrimero_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOSEGUNDO") == 0 )
            {
               AV47TFProfesionalesApellidoSegundo = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOSEGUNDO_SEL") == 0 )
            {
               AV48TFProfesionalesApellidoSegundo_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESTELEFONO") == 0 )
            {
               AV49TFProfesionalesTelefono = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESTELEFONO_SEL") == 0 )
            {
               AV50TFProfesionalesTelefono_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            AV98GXV1 = (int)(AV98GXV1+1);
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

      protected void H5V0( bool bFoot ,
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
                  AV61PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV58DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV56AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV62Phone = "+1 550 8923";
               AV60Mail = "info@mail.com";
               AV64Website = "http://www.web.com";
               AV53AddressLine1 = "French Boulevard 2859";
               AV54AddressLine2 = "Downtown";
               AV55AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV65Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV63Title = "";
         AV13FilterFullText = "";
         AV35GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV32GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV17FilterProfComisionesAutoEnunDescription = "";
         AV19ProfesionalesPrimerNombre1 = "";
         AV20FilterProfesionalesPrimerNombreDescription = "";
         AV21ProfesionalesPrimerNombre = "";
         AV23DynamicFiltersSelector2 = "";
         AV26ProfesionalesPrimerNombre2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV31ProfesionalesPrimerNombre3 = "";
         AV51TFProfComisionesID_To_Description = "";
         AV40TFProfesionalesId_Sel = "";
         AV39TFProfesionalesId = "";
         AV42TFProfesionalesPrimerNombre_Sel = "";
         AV41TFProfesionalesPrimerNombre = "";
         AV44TFProfesionalesSegundoNombre_Sel = "";
         AV43TFProfesionalesSegundoNombre = "";
         AV46TFProfesionalesApellidoPrimero_Sel = "";
         AV45TFProfesionalesApellidoPrimero = "";
         AV48TFProfesionalesApellidoSegundo_Sel = "";
         AV47TFProfesionalesApellidoSegundo = "";
         AV50TFProfesionalesTelefono_Sel = "";
         AV49TFProfesionalesTelefono = "";
         AV69Profcomisioneswwds_1_filterfulltext = "";
         AV70Profcomisioneswwds_2_dynamicfiltersselector1 = "";
         AV73Profcomisioneswwds_5_profesionalesprimernombre1 = "";
         AV75Profcomisioneswwds_7_dynamicfiltersselector2 = "";
         AV78Profcomisioneswwds_10_profesionalesprimernombre2 = "";
         AV80Profcomisioneswwds_12_dynamicfiltersselector3 = "";
         AV83Profcomisioneswwds_15_profesionalesprimernombre3 = "";
         AV86Profcomisioneswwds_18_tfprofesionalesid = "";
         AV87Profcomisioneswwds_19_tfprofesionalesid_sel = "";
         AV88Profcomisioneswwds_20_tfprofesionalesprimernombre = "";
         AV89Profcomisioneswwds_21_tfprofesionalesprimernombre_sel = "";
         AV90Profcomisioneswwds_22_tfprofesionalessegundonombre = "";
         AV91Profcomisioneswwds_23_tfprofesionalessegundonombre_sel = "";
         AV92Profcomisioneswwds_24_tfprofesionalesapellidoprimero = "";
         AV93Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel = "";
         AV94Profcomisioneswwds_26_tfprofesionalesapellidosegundo = "";
         AV95Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel = "";
         AV96Profcomisioneswwds_28_tfprofesionalestelefono = "";
         AV97Profcomisioneswwds_29_tfprofesionalestelefono_sel = "";
         lV69Profcomisioneswwds_1_filterfulltext = "";
         lV73Profcomisioneswwds_5_profesionalesprimernombre1 = "";
         lV78Profcomisioneswwds_10_profesionalesprimernombre2 = "";
         lV83Profcomisioneswwds_15_profesionalesprimernombre3 = "";
         lV86Profcomisioneswwds_18_tfprofesionalesid = "";
         lV88Profcomisioneswwds_20_tfprofesionalesprimernombre = "";
         lV90Profcomisioneswwds_22_tfprofesionalessegundonombre = "";
         lV92Profcomisioneswwds_24_tfprofesionalesapellidoprimero = "";
         lV94Profcomisioneswwds_26_tfprofesionalesapellidosegundo = "";
         lV96Profcomisioneswwds_28_tfprofesionalestelefono = "";
         A120ProfesionalesId = "";
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A192ProfesionalesApellidoSegundo = "";
         A170ProfesionalesTelefono = "";
         P005V2_A170ProfesionalesTelefono = new string[] {""} ;
         P005V2_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P005V2_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P005V2_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P005V2_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P005V2_A120ProfesionalesId = new string[] {""} ;
         P005V2_A450ProfComisionesID = new long[1] ;
         P005V2_A451ProfComisionesAutoEnun = new short[1] ;
         AV33Session = context.GetSession();
         AV36GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV61PageInfo = "";
         AV58DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV56AppName = "";
         AV62Phone = "";
         AV60Mail = "";
         AV64Website = "";
         AV53AddressLine1 = "";
         AV54AddressLine2 = "";
         AV55AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.profcomisioneswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P005V2_A170ProfesionalesTelefono, P005V2_A192ProfesionalesApellidoSegundo, P005V2_A167ProfesionalesApellidoPrimero, P005V2_A191ProfesionalesSegundoNombre, P005V2_A166ProfesionalesPrimerNombre, P005V2_A120ProfesionalesId, P005V2_A450ProfComisionesID, P005V2_A451ProfComisionesAutoEnun
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV65Pgmname = "ProfComisionesWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV65Pgmname = "ProfComisionesWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV15DynamicFiltersOperator1 ;
      private short AV16ProfComisionesAutoEnun1 ;
      private short AV18ProfComisionesAutoEnun ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV25ProfComisionesAutoEnun2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short AV30ProfComisionesAutoEnun3 ;
      private short AV71Profcomisioneswwds_3_dynamicfiltersoperator1 ;
      private short AV72Profcomisioneswwds_4_profcomisionesautoenun1 ;
      private short AV76Profcomisioneswwds_8_dynamicfiltersoperator2 ;
      private short AV77Profcomisioneswwds_9_profcomisionesautoenun2 ;
      private short AV81Profcomisioneswwds_13_dynamicfiltersoperator3 ;
      private short AV82Profcomisioneswwds_14_profcomisionesautoenun3 ;
      private short A451ProfComisionesAutoEnun ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV98GXV1 ;
      private long AV37TFProfComisionesID ;
      private long AV38TFProfComisionesID_To ;
      private long AV84Profcomisioneswwds_16_tfprofcomisionesid ;
      private long AV85Profcomisioneswwds_17_tfprofcomisionesid_to ;
      private long A450ProfComisionesID ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV65Pgmname ;
      private string GXEncryptionTmp ;
      private string AV19ProfesionalesPrimerNombre1 ;
      private string AV21ProfesionalesPrimerNombre ;
      private string AV26ProfesionalesPrimerNombre2 ;
      private string AV31ProfesionalesPrimerNombre3 ;
      private string AV40TFProfesionalesId_Sel ;
      private string AV39TFProfesionalesId ;
      private string AV42TFProfesionalesPrimerNombre_Sel ;
      private string AV41TFProfesionalesPrimerNombre ;
      private string AV44TFProfesionalesSegundoNombre_Sel ;
      private string AV43TFProfesionalesSegundoNombre ;
      private string AV46TFProfesionalesApellidoPrimero_Sel ;
      private string AV45TFProfesionalesApellidoPrimero ;
      private string AV48TFProfesionalesApellidoSegundo_Sel ;
      private string AV47TFProfesionalesApellidoSegundo ;
      private string AV50TFProfesionalesTelefono_Sel ;
      private string AV49TFProfesionalesTelefono ;
      private string AV73Profcomisioneswwds_5_profesionalesprimernombre1 ;
      private string AV78Profcomisioneswwds_10_profesionalesprimernombre2 ;
      private string AV83Profcomisioneswwds_15_profesionalesprimernombre3 ;
      private string AV86Profcomisioneswwds_18_tfprofesionalesid ;
      private string AV87Profcomisioneswwds_19_tfprofesionalesid_sel ;
      private string AV88Profcomisioneswwds_20_tfprofesionalesprimernombre ;
      private string AV89Profcomisioneswwds_21_tfprofesionalesprimernombre_sel ;
      private string AV90Profcomisioneswwds_22_tfprofesionalessegundonombre ;
      private string AV91Profcomisioneswwds_23_tfprofesionalessegundonombre_sel ;
      private string AV92Profcomisioneswwds_24_tfprofesionalesapellidoprimero ;
      private string AV93Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel ;
      private string AV94Profcomisioneswwds_26_tfprofesionalesapellidosegundo ;
      private string AV95Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel ;
      private string AV96Profcomisioneswwds_28_tfprofesionalestelefono ;
      private string AV97Profcomisioneswwds_29_tfprofesionalestelefono_sel ;
      private string lV73Profcomisioneswwds_5_profesionalesprimernombre1 ;
      private string lV78Profcomisioneswwds_10_profesionalesprimernombre2 ;
      private string lV83Profcomisioneswwds_15_profesionalesprimernombre3 ;
      private string lV86Profcomisioneswwds_18_tfprofesionalesid ;
      private string lV88Profcomisioneswwds_20_tfprofesionalesprimernombre ;
      private string lV90Profcomisioneswwds_22_tfprofesionalessegundonombre ;
      private string lV92Profcomisioneswwds_24_tfprofesionalesapellidoprimero ;
      private string lV94Profcomisioneswwds_26_tfprofesionalesapellidosegundo ;
      private string lV96Profcomisioneswwds_28_tfprofesionalestelefono ;
      private string A120ProfesionalesId ;
      private string A166ProfesionalesPrimerNombre ;
      private string A191ProfesionalesSegundoNombre ;
      private string A167ProfesionalesApellidoPrimero ;
      private string A192ProfesionalesApellidoSegundo ;
      private string A170ProfesionalesTelefono ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV52TempBoolean ;
      private bool AV74Profcomisioneswwds_6_dynamicfiltersenabled2 ;
      private bool AV79Profcomisioneswwds_11_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private string AV63Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV17FilterProfComisionesAutoEnunDescription ;
      private string AV20FilterProfesionalesPrimerNombreDescription ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV51TFProfComisionesID_To_Description ;
      private string AV69Profcomisioneswwds_1_filterfulltext ;
      private string AV70Profcomisioneswwds_2_dynamicfiltersselector1 ;
      private string AV75Profcomisioneswwds_7_dynamicfiltersselector2 ;
      private string AV80Profcomisioneswwds_12_dynamicfiltersselector3 ;
      private string lV69Profcomisioneswwds_1_filterfulltext ;
      private string AV61PageInfo ;
      private string AV58DateInfo ;
      private string AV56AppName ;
      private string AV62Phone ;
      private string AV60Mail ;
      private string AV64Website ;
      private string AV53AddressLine1 ;
      private string AV54AddressLine2 ;
      private string AV55AddressLine3 ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV32GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private string[] P005V2_A170ProfesionalesTelefono ;
      private string[] P005V2_A192ProfesionalesApellidoSegundo ;
      private string[] P005V2_A167ProfesionalesApellidoPrimero ;
      private string[] P005V2_A191ProfesionalesSegundoNombre ;
      private string[] P005V2_A166ProfesionalesPrimerNombre ;
      private string[] P005V2_A120ProfesionalesId ;
      private long[] P005V2_A450ProfComisionesID ;
      private short[] P005V2_A451ProfComisionesAutoEnun ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
   }

   public class profcomisioneswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005V2( IGxContext context ,
                                             string AV69Profcomisioneswwds_1_filterfulltext ,
                                             string AV70Profcomisioneswwds_2_dynamicfiltersselector1 ,
                                             short AV71Profcomisioneswwds_3_dynamicfiltersoperator1 ,
                                             short AV72Profcomisioneswwds_4_profcomisionesautoenun1 ,
                                             string AV73Profcomisioneswwds_5_profesionalesprimernombre1 ,
                                             bool AV74Profcomisioneswwds_6_dynamicfiltersenabled2 ,
                                             string AV75Profcomisioneswwds_7_dynamicfiltersselector2 ,
                                             short AV76Profcomisioneswwds_8_dynamicfiltersoperator2 ,
                                             short AV77Profcomisioneswwds_9_profcomisionesautoenun2 ,
                                             string AV78Profcomisioneswwds_10_profesionalesprimernombre2 ,
                                             bool AV79Profcomisioneswwds_11_dynamicfiltersenabled3 ,
                                             string AV80Profcomisioneswwds_12_dynamicfiltersselector3 ,
                                             short AV81Profcomisioneswwds_13_dynamicfiltersoperator3 ,
                                             short AV82Profcomisioneswwds_14_profcomisionesautoenun3 ,
                                             string AV83Profcomisioneswwds_15_profesionalesprimernombre3 ,
                                             long AV84Profcomisioneswwds_16_tfprofcomisionesid ,
                                             long AV85Profcomisioneswwds_17_tfprofcomisionesid_to ,
                                             string AV87Profcomisioneswwds_19_tfprofesionalesid_sel ,
                                             string AV86Profcomisioneswwds_18_tfprofesionalesid ,
                                             string AV89Profcomisioneswwds_21_tfprofesionalesprimernombre_sel ,
                                             string AV88Profcomisioneswwds_20_tfprofesionalesprimernombre ,
                                             string AV91Profcomisioneswwds_23_tfprofesionalessegundonombre_sel ,
                                             string AV90Profcomisioneswwds_22_tfprofesionalessegundonombre ,
                                             string AV93Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel ,
                                             string AV92Profcomisioneswwds_24_tfprofesionalesapellidoprimero ,
                                             string AV95Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel ,
                                             string AV94Profcomisioneswwds_26_tfprofesionalesapellidosegundo ,
                                             string AV97Profcomisioneswwds_29_tfprofesionalestelefono_sel ,
                                             string AV96Profcomisioneswwds_28_tfprofesionalestelefono ,
                                             long A450ProfComisionesID ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             short A451ProfComisionesAutoEnun ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[36];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T2.[ProfesionalesTelefono], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T1.[ProfComisionesID], T1.[ProfComisionesAutoEnun] FROM ([ProfComisiones] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Profcomisioneswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[ProfComisionesID] AS decimal(18,0))) like '%' + @lV69Profcomisioneswwds_1_filterfulltext) or ( UPPER(T1.[ProfesionalesId]) like '%' + UPPER(@lV69Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV69Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesSegundoNombre]) like '%' + UPPER(@lV69Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesApellidoPrimero]) like '%' + UPPER(@lV69Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesApellidoSegundo]) like '%' + UPPER(@lV69Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesTelefono]) like '%' + UPPER(@lV69Profcomisioneswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
            GXv_int2[4] = 1;
            GXv_int2[5] = 1;
            GXv_int2[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV70Profcomisioneswwds_2_dynamicfiltersselector1, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV71Profcomisioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV72Profcomisioneswwds_4_profcomisionesautoenun1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] < @AV72Profcomisioneswwds_4_profcomisionesautoenun1)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV70Profcomisioneswwds_2_dynamicfiltersselector1, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV71Profcomisioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV72Profcomisioneswwds_4_profcomisionesautoenun1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] = @AV72Profcomisioneswwds_4_profcomisionesautoenun1)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV70Profcomisioneswwds_2_dynamicfiltersselector1, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV71Profcomisioneswwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV72Profcomisioneswwds_4_profcomisionesautoenun1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] > @AV72Profcomisioneswwds_4_profcomisionesautoenun1)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV70Profcomisioneswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV71Profcomisioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Profcomisioneswwds_5_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV73Profcomisioneswwds_5_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV70Profcomisioneswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV71Profcomisioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Profcomisioneswwds_5_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV73Profcomisioneswwds_5_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( AV74Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_7_dynamicfiltersselector2, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV76Profcomisioneswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV77Profcomisioneswwds_9_profcomisionesautoenun2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] < @AV77Profcomisioneswwds_9_profcomisionesautoenun2)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( AV74Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_7_dynamicfiltersselector2, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV76Profcomisioneswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV77Profcomisioneswwds_9_profcomisionesautoenun2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] = @AV77Profcomisioneswwds_9_profcomisionesautoenun2)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( AV74Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_7_dynamicfiltersselector2, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV76Profcomisioneswwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV77Profcomisioneswwds_9_profcomisionesautoenun2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] > @AV77Profcomisioneswwds_9_profcomisionesautoenun2)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( AV74Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_7_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV76Profcomisioneswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Profcomisioneswwds_10_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV78Profcomisioneswwds_10_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( AV74Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_7_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV76Profcomisioneswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Profcomisioneswwds_10_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV78Profcomisioneswwds_10_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( AV79Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV80Profcomisioneswwds_12_dynamicfiltersselector3, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV81Profcomisioneswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV82Profcomisioneswwds_14_profcomisionesautoenun3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] < @AV82Profcomisioneswwds_14_profcomisionesautoenun3)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( AV79Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV80Profcomisioneswwds_12_dynamicfiltersselector3, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV81Profcomisioneswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV82Profcomisioneswwds_14_profcomisionesautoenun3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] = @AV82Profcomisioneswwds_14_profcomisionesautoenun3)");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( AV79Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV80Profcomisioneswwds_12_dynamicfiltersselector3, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV81Profcomisioneswwds_13_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV82Profcomisioneswwds_14_profcomisionesautoenun3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] > @AV82Profcomisioneswwds_14_profcomisionesautoenun3)");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( AV79Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV80Profcomisioneswwds_12_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV81Profcomisioneswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Profcomisioneswwds_15_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV83Profcomisioneswwds_15_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( AV79Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV80Profcomisioneswwds_12_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV81Profcomisioneswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Profcomisioneswwds_15_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV83Profcomisioneswwds_15_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( ! (0==AV84Profcomisioneswwds_16_tfprofcomisionesid) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesID] >= @AV84Profcomisioneswwds_16_tfprofcomisionesid)");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( ! (0==AV85Profcomisioneswwds_17_tfprofcomisionesid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesID] <= @AV85Profcomisioneswwds_17_tfprofcomisionesid_to)");
         }
         else
         {
            GXv_int2[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Profcomisioneswwds_19_tfprofesionalesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profcomisioneswwds_18_tfprofesionalesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV86Profcomisioneswwds_18_tfprofesionalesid))");
         }
         else
         {
            GXv_int2[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Profcomisioneswwds_19_tfprofesionalesid_sel)) && ! ( StringUtil.StrCmp(AV87Profcomisioneswwds_19_tfprofesionalesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV87Profcomisioneswwds_19_tfprofesionalesid_sel)");
         }
         else
         {
            GXv_int2[25] = 1;
         }
         if ( StringUtil.StrCmp(AV87Profcomisioneswwds_19_tfprofesionalesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Profcomisioneswwds_21_tfprofesionalesprimernombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Profcomisioneswwds_20_tfprofesionalesprimernombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV88Profcomisioneswwds_20_tfprofesionalesprimernombre))");
         }
         else
         {
            GXv_int2[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Profcomisioneswwds_21_tfprofesionalesprimernombre_sel)) && ! ( StringUtil.StrCmp(AV89Profcomisioneswwds_21_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesPrimerNombre] = @AV89Profcomisioneswwds_21_tfprofesionalesprimernombre_sel)");
         }
         else
         {
            GXv_int2[27] = 1;
         }
         if ( StringUtil.StrCmp(AV89Profcomisioneswwds_21_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV91Profcomisioneswwds_23_tfprofesionalessegundonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Profcomisioneswwds_22_tfprofesionalessegundonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesSegundoNombre]) like UPPER(@lV90Profcomisioneswwds_22_tfprofesionalessegundonombre))");
         }
         else
         {
            GXv_int2[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Profcomisioneswwds_23_tfprofesionalessegundonombre_sel)) && ! ( StringUtil.StrCmp(AV91Profcomisioneswwds_23_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesSegundoNombre] = @AV91Profcomisioneswwds_23_tfprofesionalessegundonombre_sel)");
         }
         else
         {
            GXv_int2[29] = 1;
         }
         if ( StringUtil.StrCmp(AV91Profcomisioneswwds_23_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV93Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profcomisioneswwds_24_tfprofesionalesapellidoprimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoPrimero]) like UPPER(@lV92Profcomisioneswwds_24_tfprofesionalesapellidoprimero))");
         }
         else
         {
            GXv_int2[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel)) && ! ( StringUtil.StrCmp(AV93Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoPrimero] = @AV93Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel)");
         }
         else
         {
            GXv_int2[31] = 1;
         }
         if ( StringUtil.StrCmp(AV93Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV95Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Profcomisioneswwds_26_tfprofesionalesapellidosegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoSegundo]) like UPPER(@lV94Profcomisioneswwds_26_tfprofesionalesapellidosegundo))");
         }
         else
         {
            GXv_int2[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel)) && ! ( StringUtil.StrCmp(AV95Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoSegundo] = @AV95Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel)");
         }
         else
         {
            GXv_int2[33] = 1;
         }
         if ( StringUtil.StrCmp(AV95Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV97Profcomisioneswwds_29_tfprofesionalestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Profcomisioneswwds_28_tfprofesionalestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesTelefono]) like UPPER(@lV96Profcomisioneswwds_28_tfprofesionalestelefono))");
         }
         else
         {
            GXv_int2[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Profcomisioneswwds_29_tfprofesionalestelefono_sel)) && ! ( StringUtil.StrCmp(AV97Profcomisioneswwds_29_tfprofesionalestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesTelefono] = @AV97Profcomisioneswwds_29_tfprofesionalestelefono_sel)");
         }
         else
         {
            GXv_int2[35] = 1;
         }
         if ( StringUtil.StrCmp(AV97Profcomisioneswwds_29_tfprofesionalestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesTelefono] = ''))");
         }
         scmdbuf += sWhereString;
         if ( AV11OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesAutoEnun]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProfComisionesID] DESC";
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
            scmdbuf += " ORDER BY T2.[ProfesionalesPrimerNombre]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ProfesionalesPrimerNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ProfesionalesSegundoNombre]";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ProfesionalesSegundoNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ProfesionalesApellidoPrimero]";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ProfesionalesApellidoPrimero] DESC";
         }
         else if ( ( AV11OrderedBy == 7 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ProfesionalesApellidoSegundo]";
         }
         else if ( ( AV11OrderedBy == 7 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ProfesionalesApellidoSegundo] DESC";
         }
         else if ( ( AV11OrderedBy == 8 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ProfesionalesTelefono]";
         }
         else if ( ( AV11OrderedBy == 8 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ProfesionalesTelefono] DESC";
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
                     return conditional_P005V2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (long)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (short)dynConstraints[36] , (short)dynConstraints[37] , (bool)dynConstraints[38] );
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
          Object[] prmP005V2;
          prmP005V2 = new Object[] {
          new ParDef("@lV69Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV69Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV69Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV69Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV69Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV69Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV69Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV72Profcomisioneswwds_4_profcomisionesautoenun1",GXType.Int16,4,0) ,
          new ParDef("@AV72Profcomisioneswwds_4_profcomisionesautoenun1",GXType.Int16,4,0) ,
          new ParDef("@AV72Profcomisioneswwds_4_profcomisionesautoenun1",GXType.Int16,4,0) ,
          new ParDef("@lV73Profcomisioneswwds_5_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@lV73Profcomisioneswwds_5_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@AV77Profcomisioneswwds_9_profcomisionesautoenun2",GXType.Int16,4,0) ,
          new ParDef("@AV77Profcomisioneswwds_9_profcomisionesautoenun2",GXType.Int16,4,0) ,
          new ParDef("@AV77Profcomisioneswwds_9_profcomisionesautoenun2",GXType.Int16,4,0) ,
          new ParDef("@lV78Profcomisioneswwds_10_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@lV78Profcomisioneswwds_10_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@AV82Profcomisioneswwds_14_profcomisionesautoenun3",GXType.Int16,4,0) ,
          new ParDef("@AV82Profcomisioneswwds_14_profcomisionesautoenun3",GXType.Int16,4,0) ,
          new ParDef("@AV82Profcomisioneswwds_14_profcomisionesautoenun3",GXType.Int16,4,0) ,
          new ParDef("@lV83Profcomisioneswwds_15_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV83Profcomisioneswwds_15_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@AV84Profcomisioneswwds_16_tfprofcomisionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV85Profcomisioneswwds_17_tfprofcomisionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV86Profcomisioneswwds_18_tfprofesionalesid",GXType.Char,20,0) ,
          new ParDef("@AV87Profcomisioneswwds_19_tfprofesionalesid_sel",GXType.Char,20,0) ,
          new ParDef("@lV88Profcomisioneswwds_20_tfprofesionalesprimernombre",GXType.Char,30,0) ,
          new ParDef("@AV89Profcomisioneswwds_21_tfprofesionalesprimernombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV90Profcomisioneswwds_22_tfprofesionalessegundonombre",GXType.Char,30,0) ,
          new ParDef("@AV91Profcomisioneswwds_23_tfprofesionalessegundonombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV92Profcomisioneswwds_24_tfprofesionalesapellidoprimero",GXType.Char,30,0) ,
          new ParDef("@AV93Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel",GXType.NChar,30,0) ,
          new ParDef("@lV94Profcomisioneswwds_26_tfprofesionalesapellidosegundo",GXType.Char,30,0) ,
          new ParDef("@AV95Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel",GXType.NChar,30,0) ,
          new ParDef("@lV96Profcomisioneswwds_28_tfprofesionalestelefono",GXType.Char,20,0) ,
          new ParDef("@AV97Profcomisioneswwds_29_tfprofesionalestelefono_sel",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005V2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005V2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 30);
                ((string[]) buf[2])[0] = rslt.getString(3, 30);
                ((string[]) buf[3])[0] = rslt.getString(4, 30);
                ((string[]) buf[4])[0] = rslt.getString(5, 30);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                return;
       }
    }

 }

}
