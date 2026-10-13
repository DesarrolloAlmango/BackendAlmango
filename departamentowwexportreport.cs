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
   public class departamentowwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public departamentowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public departamentowwexportreport( IGxContext context )
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
         setOutputFileName("DepartamentoWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWDepartamento", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV62Pgmname));
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
               AV53Title = context.GetMessage( "Lista de Departamento", "");
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
            H410( true, 0) ;
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
            H410( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 184, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 184, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV27GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "DEPARTAMENTODEPARTAMENTO") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV27GridStateDynamicFilter.gxTpr_Operator;
               AV16DepartamentoDepartamento1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16DepartamentoDepartamento1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterDepartamentoDepartamentoDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Departamento", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterDepartamentoDepartamentoDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Departamento", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV18DepartamentoDepartamento = AV16DepartamentoDepartamento1;
                  H410( false, 19) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterDepartamentoDepartamentoDescription, "")), 25, Gx_line+0, 184, Gx_line+14, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18DepartamentoDepartamento, "")), 184, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
               }
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV19DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "DEPARTAMENTODEPARTAMENTO") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV27GridStateDynamicFilter.gxTpr_Operator;
                  AV22DepartamentoDepartamento2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22DepartamentoDepartamento2)) )
                  {
                     if ( AV21DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterDepartamentoDepartamentoDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Departamento", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV21DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterDepartamentoDepartamentoDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Departamento", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV18DepartamentoDepartamento = AV22DepartamentoDepartamento2;
                     H410( false, 19) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterDepartamentoDepartamentoDescription, "")), 25, Gx_line+0, 184, Gx_line+14, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18DepartamentoDepartamento, "")), 184, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                  }
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "DEPARTAMENTODEPARTAMENTO") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV27GridStateDynamicFilter.gxTpr_Operator;
                     AV26DepartamentoDepartamento3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26DepartamentoDepartamento3)) )
                     {
                        if ( AV25DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterDepartamentoDepartamentoDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Departamento", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV25DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterDepartamentoDepartamentoDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Departamento", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV18DepartamentoDepartamento = AV26DepartamentoDepartamento3;
                        H410( false, 19) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterDepartamentoDepartamentoDescription, "")), 25, Gx_line+0, 184, Gx_line+14, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18DepartamentoDepartamento, "")), 184, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV32TFDepartamentoId) && (0==AV33TFDepartamentoId_To) ) )
         {
            H410( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Departamento", ""), 25, Gx_line+0, 184, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV32TFDepartamentoId), "ZZZZZZZZZZZZZZZZZ9")), 184, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV40TFDepartamentoId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Departamento", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H410( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFDepartamentoId_To_Description, "")), 25, Gx_line+0, 184, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV33TFDepartamentoId_To), "ZZZZZZZZZZZZZZZZZ9")), 184, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFPaisID_Sel)) )
         {
            AV42TempBoolean = (bool)(((StringUtil.StrCmp(AV35TFPaisID_Sel, "<#Empty#>")==0)));
            AV35TFPaisID_Sel = (AV42TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV35TFPaisID_Sel);
            H410( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "PaisId", ""), 25, Gx_line+0, 184, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFPaisID_Sel, "")), 184, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV35TFPaisID_Sel = (AV42TempBoolean ? "<#Empty#>" : AV35TFPaisID_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFPaisID)) )
            {
               H410( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "PaisId", ""), 25, Gx_line+0, 184, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFPaisID, "")), 184, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFDepartamentoDepartamento_Sel)) )
         {
            AV42TempBoolean = (bool)(((StringUtil.StrCmp(AV37TFDepartamentoDepartamento_Sel, "<#Empty#>")==0)));
            AV37TFDepartamentoDepartamento_Sel = (AV42TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV37TFDepartamentoDepartamento_Sel);
            H410( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Departamento", ""), 25, Gx_line+0, 184, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFDepartamentoDepartamento_Sel, "")), 184, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV37TFDepartamentoDepartamento_Sel = (AV42TempBoolean ? "<#Empty#>" : AV37TFDepartamentoDepartamento_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFDepartamentoDepartamento)) )
            {
               H410( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Departamento", ""), 25, Gx_line+0, 184, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFDepartamentoDepartamento, "")), 184, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         AV59TFDepartamentoEstado_Sels.FromJSonString(AV56TFDepartamentoEstado_SelsJson, null);
         if ( ! ( AV59TFDepartamentoEstado_Sels.Count == 0 ) )
         {
            AV61i = 1;
            AV65GXV1 = 1;
            while ( AV65GXV1 <= AV59TFDepartamentoEstado_Sels.Count )
            {
               AV58TFDepartamentoEstado_Sel = AV59TFDepartamentoEstado_Sels.GetString(AV65GXV1);
               if ( AV61i == 1 )
               {
                  AV57TFDepartamentoEstado_SelDscs = "";
               }
               else
               {
                  AV57TFDepartamentoEstado_SelDscs += ", ";
               }
               AV60FilterTFDepartamentoEstado_SelValueDescription = "";
               if ( StringUtil.StrCmp(StringUtil.Trim( AV58TFDepartamentoEstado_Sel), "HAB") == 0 )
               {
                  AV60FilterTFDepartamentoEstado_SelValueDescription = context.GetMessage( "Habilitado", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV58TFDepartamentoEstado_Sel), "DES") == 0 )
               {
                  AV60FilterTFDepartamentoEstado_SelValueDescription = context.GetMessage( "Deshabilitado", "");
               }
               AV57TFDepartamentoEstado_SelDscs += AV60FilterTFDepartamentoEstado_SelValueDescription;
               AV61i = (long)(AV61i+1);
               AV65GXV1 = (int)(AV65GXV1+1);
            }
            H410( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 25, Gx_line+0, 184, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57TFDepartamentoEstado_SelDscs, "")), 184, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (0==AV38TFDepartamentoAutEnuMuni) && (0==AV39TFDepartamentoAutEnuMuni_To) ) )
         {
            H410( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Enu Muni", ""), 25, Gx_line+0, 184, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV38TFDepartamentoAutEnuMuni), "ZZZ9")), 184, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV41TFDepartamentoAutEnuMuni_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Enu Muni", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H410( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFDepartamentoAutEnuMuni_To_Description, "")), 25, Gx_line+0, 184, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV39TFDepartamentoAutEnuMuni_To), "ZZZ9")), 184, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H410( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H410( false, 36) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Departamento", ""), 30, Gx_line+10, 135, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "PaisId", ""), 139, Gx_line+10, 245, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Departamento", ""), 249, Gx_line+10, 461, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 465, Gx_line+10, 677, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Enu Muni", ""), 681, Gx_line+10, 787, Gx_line+26, 2, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV67Departamentowwds_1_filterfulltext = AV13FilterFullText;
         AV68Departamentowwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV69Departamentowwds_3_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV70Departamentowwds_4_departamentodepartamento1 = AV16DepartamentoDepartamento1;
         AV71Departamentowwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV72Departamentowwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV73Departamentowwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV74Departamentowwds_8_departamentodepartamento2 = AV22DepartamentoDepartamento2;
         AV75Departamentowwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV76Departamentowwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV77Departamentowwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV78Departamentowwds_12_departamentodepartamento3 = AV26DepartamentoDepartamento3;
         AV79Departamentowwds_13_tfdepartamentoid = AV32TFDepartamentoId;
         AV80Departamentowwds_14_tfdepartamentoid_to = AV33TFDepartamentoId_To;
         AV81Departamentowwds_15_tfpaisid = AV34TFPaisID;
         AV82Departamentowwds_16_tfpaisid_sel = AV35TFPaisID_Sel;
         AV83Departamentowwds_17_tfdepartamentodepartamento = AV36TFDepartamentoDepartamento;
         AV84Departamentowwds_18_tfdepartamentodepartamento_sel = AV37TFDepartamentoDepartamento_Sel;
         AV85Departamentowwds_19_tfdepartamentoestado_sels = AV59TFDepartamentoEstado_Sels;
         AV86Departamentowwds_20_tfdepartamentoautenumuni = AV38TFDepartamentoAutEnuMuni;
         AV87Departamentowwds_21_tfdepartamentoautenumuni_to = AV39TFDepartamentoAutEnuMuni_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A907DepartamentoEstado ,
                                              AV85Departamentowwds_19_tfdepartamentoestado_sels ,
                                              AV68Departamentowwds_2_dynamicfiltersselector1 ,
                                              AV69Departamentowwds_3_dynamicfiltersoperator1 ,
                                              AV70Departamentowwds_4_departamentodepartamento1 ,
                                              AV71Departamentowwds_5_dynamicfiltersenabled2 ,
                                              AV72Departamentowwds_6_dynamicfiltersselector2 ,
                                              AV73Departamentowwds_7_dynamicfiltersoperator2 ,
                                              AV74Departamentowwds_8_departamentodepartamento2 ,
                                              AV75Departamentowwds_9_dynamicfiltersenabled3 ,
                                              AV76Departamentowwds_10_dynamicfiltersselector3 ,
                                              AV77Departamentowwds_11_dynamicfiltersoperator3 ,
                                              AV78Departamentowwds_12_departamentodepartamento3 ,
                                              AV79Departamentowwds_13_tfdepartamentoid ,
                                              AV80Departamentowwds_14_tfdepartamentoid_to ,
                                              AV82Departamentowwds_16_tfpaisid_sel ,
                                              AV81Departamentowwds_15_tfpaisid ,
                                              AV84Departamentowwds_18_tfdepartamentodepartamento_sel ,
                                              AV83Departamentowwds_17_tfdepartamentodepartamento ,
                                              AV85Departamentowwds_19_tfdepartamentoestado_sels.Count ,
                                              AV86Departamentowwds_20_tfdepartamentoautenumuni ,
                                              AV87Departamentowwds_21_tfdepartamentoautenumuni_to ,
                                              A113DepartamentoDepartamento ,
                                              A112DepartamentoId ,
                                              A116PaisID ,
                                              A185DepartamentoAutEnuMuni ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              AV67Departamentowwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV70Departamentowwds_4_departamentodepartamento1 = StringUtil.PadR( StringUtil.RTrim( AV70Departamentowwds_4_departamentodepartamento1), 80, "%");
         lV70Departamentowwds_4_departamentodepartamento1 = StringUtil.PadR( StringUtil.RTrim( AV70Departamentowwds_4_departamentodepartamento1), 80, "%");
         lV74Departamentowwds_8_departamentodepartamento2 = StringUtil.PadR( StringUtil.RTrim( AV74Departamentowwds_8_departamentodepartamento2), 80, "%");
         lV74Departamentowwds_8_departamentodepartamento2 = StringUtil.PadR( StringUtil.RTrim( AV74Departamentowwds_8_departamentodepartamento2), 80, "%");
         lV78Departamentowwds_12_departamentodepartamento3 = StringUtil.PadR( StringUtil.RTrim( AV78Departamentowwds_12_departamentodepartamento3), 80, "%");
         lV78Departamentowwds_12_departamentodepartamento3 = StringUtil.PadR( StringUtil.RTrim( AV78Departamentowwds_12_departamentodepartamento3), 80, "%");
         lV81Departamentowwds_15_tfpaisid = StringUtil.PadR( StringUtil.RTrim( AV81Departamentowwds_15_tfpaisid), 2, "%");
         lV83Departamentowwds_17_tfdepartamentodepartamento = StringUtil.PadR( StringUtil.RTrim( AV83Departamentowwds_17_tfdepartamentodepartamento), 80, "%");
         /* Using cursor P00412 */
         pr_default.execute(0, new Object[] {lV70Departamentowwds_4_departamentodepartamento1, lV70Departamentowwds_4_departamentodepartamento1, lV74Departamentowwds_8_departamentodepartamento2, lV74Departamentowwds_8_departamentodepartamento2, lV78Departamentowwds_12_departamentodepartamento3, lV78Departamentowwds_12_departamentodepartamento3, AV79Departamentowwds_13_tfdepartamentoid, AV80Departamentowwds_14_tfdepartamentoid_to, lV81Departamentowwds_15_tfpaisid, AV82Departamentowwds_16_tfpaisid_sel, lV83Departamentowwds_17_tfdepartamentodepartamento, AV84Departamentowwds_18_tfdepartamentodepartamento_sel, AV86Departamentowwds_20_tfdepartamentoautenumuni, AV87Departamentowwds_21_tfdepartamentoautenumuni_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A185DepartamentoAutEnuMuni = P00412_A185DepartamentoAutEnuMuni[0];
            A113DepartamentoDepartamento = P00412_A113DepartamentoDepartamento[0];
            A116PaisID = P00412_A116PaisID[0];
            A112DepartamentoId = P00412_A112DepartamentoId[0];
            A907DepartamentoEstado = P00412_A907DepartamentoEstado[0];
            n907DepartamentoEstado = P00412_n907DepartamentoEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Departamentowwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0) , StringUtil.PadR( "%" + AV67Departamentowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A116PaisID) , StringUtil.PadR( "%" + StringUtil.Upper( AV67Departamentowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A113DepartamentoDepartamento) , StringUtil.PadR( "%" + StringUtil.Upper( AV67Departamentowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV67Departamentowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A907DepartamentoEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV67Departamentowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A907DepartamentoEstado, "DES") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A185DepartamentoAutEnuMuni), 4, 0) , StringUtil.PadR( "%" + AV67Departamentowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ) )
            {
               AV55DepartamentoEstadoDescription = "";
               if ( StringUtil.StrCmp(StringUtil.Trim( A907DepartamentoEstado), "HAB") == 0 )
               {
                  AV55DepartamentoEstadoDescription = context.GetMessage( "Habilitado", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( A907DepartamentoEstado), "DES") == 0 )
               {
                  AV55DepartamentoEstadoDescription = context.GetMessage( "Deshabilitado", "");
               }
               /* Execute user subroutine: 'BEFOREPRINTLINE' */
               S144 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               H410( false, 35) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A112DepartamentoId), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 135, Gx_line+24, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A116PaisID, "")), 139, Gx_line+10, 245, Gx_line+24, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A113DepartamentoDepartamento, "")), 249, Gx_line+10, 461, Gx_line+24, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55DepartamentoEstadoDescription, "")), 465, Gx_line+10, 677, Gx_line+24, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A185DepartamentoAutEnuMuni), "ZZZ9")), 681, Gx_line+10, 787, Gx_line+24, 2+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV28Session.Get("DepartamentoWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "DepartamentoWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("DepartamentoWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV30GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV30GridState.gxTpr_Ordereddsc;
         AV88GXV2 = 1;
         while ( AV88GXV2 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV88GXV2));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTOID") == 0 )
            {
               AV32TFDepartamentoId = (long)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV33TFDepartamentoId_To = (long)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPAISID") == 0 )
            {
               AV34TFPaisID = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPAISID_SEL") == 0 )
            {
               AV35TFPaisID_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTODEPARTAMENTO") == 0 )
            {
               AV36TFDepartamentoDepartamento = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTODEPARTAMENTO_SEL") == 0 )
            {
               AV37TFDepartamentoDepartamento_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTOESTADO_SEL") == 0 )
            {
               AV56TFDepartamentoEstado_SelsJson = AV31GridStateFilterValue.gxTpr_Value;
               AV59TFDepartamentoEstado_Sels.FromJSonString(AV56TFDepartamentoEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTOAUTENUMUNI") == 0 )
            {
               AV38TFDepartamentoAutEnuMuni = (short)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV39TFDepartamentoAutEnuMuni_To = (short)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            AV88GXV2 = (int)(AV88GXV2+1);
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

      protected void H410( bool bFoot ,
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
                  AV51PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV48DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+39, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51PageInfo, "")), 30, Gx_line+15, 409, Gx_line+29, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48DateInfo, "")), 409, Gx_line+15, 789, Gx_line+29, 2, 0, 0, 0) ;
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
               AV46AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV52Phone = "+1 550 8923";
               AV50Mail = "info@mail.com";
               AV54Website = "http://www.web.com";
               AV43AddressLine1 = "French Boulevard 2859";
               AV44AddressLine2 = "Downtown";
               AV45AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+107, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46AppName, "")), 30, Gx_line+30, 283, Gx_line+44, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53Title, "")), 30, Gx_line+44, 283, Gx_line+77, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52Phone, "")), 283, Gx_line+30, 536, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50Mail, "")), 283, Gx_line+45, 536, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54Website, "")), 283, Gx_line+60, 536, Gx_line+77, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44AddressLine2, "")), 536, Gx_line+45, 789, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45AddressLine3, "")), 536, Gx_line+60, 789, Gx_line+77, 2, 0, 0, 0) ;
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
         AV62Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV53Title = "";
         AV13FilterFullText = "";
         AV30GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV16DepartamentoDepartamento1 = "";
         AV17FilterDepartamentoDepartamentoDescription = "";
         AV18DepartamentoDepartamento = "";
         AV20DynamicFiltersSelector2 = "";
         AV22DepartamentoDepartamento2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV26DepartamentoDepartamento3 = "";
         AV40TFDepartamentoId_To_Description = "";
         AV35TFPaisID_Sel = "";
         AV34TFPaisID = "";
         AV37TFDepartamentoDepartamento_Sel = "";
         AV36TFDepartamentoDepartamento = "";
         AV59TFDepartamentoEstado_Sels = new GxSimpleCollection<string>();
         AV56TFDepartamentoEstado_SelsJson = "";
         AV58TFDepartamentoEstado_Sel = "";
         AV57TFDepartamentoEstado_SelDscs = "";
         AV60FilterTFDepartamentoEstado_SelValueDescription = "";
         AV41TFDepartamentoAutEnuMuni_To_Description = "";
         AV67Departamentowwds_1_filterfulltext = "";
         AV68Departamentowwds_2_dynamicfiltersselector1 = "";
         AV70Departamentowwds_4_departamentodepartamento1 = "";
         AV72Departamentowwds_6_dynamicfiltersselector2 = "";
         AV74Departamentowwds_8_departamentodepartamento2 = "";
         AV76Departamentowwds_10_dynamicfiltersselector3 = "";
         AV78Departamentowwds_12_departamentodepartamento3 = "";
         AV81Departamentowwds_15_tfpaisid = "";
         AV82Departamentowwds_16_tfpaisid_sel = "";
         AV83Departamentowwds_17_tfdepartamentodepartamento = "";
         AV84Departamentowwds_18_tfdepartamentodepartamento_sel = "";
         AV85Departamentowwds_19_tfdepartamentoestado_sels = new GxSimpleCollection<string>();
         lV67Departamentowwds_1_filterfulltext = "";
         lV70Departamentowwds_4_departamentodepartamento1 = "";
         lV74Departamentowwds_8_departamentodepartamento2 = "";
         lV78Departamentowwds_12_departamentodepartamento3 = "";
         lV81Departamentowwds_15_tfpaisid = "";
         lV83Departamentowwds_17_tfdepartamentodepartamento = "";
         A907DepartamentoEstado = "";
         A113DepartamentoDepartamento = "";
         A116PaisID = "";
         P00412_A185DepartamentoAutEnuMuni = new short[1] ;
         P00412_A113DepartamentoDepartamento = new string[] {""} ;
         P00412_A116PaisID = new string[] {""} ;
         P00412_A112DepartamentoId = new long[1] ;
         P00412_A907DepartamentoEstado = new string[] {""} ;
         P00412_n907DepartamentoEstado = new bool[] {false} ;
         AV55DepartamentoEstadoDescription = "";
         AV28Session = context.GetSession();
         AV31GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV51PageInfo = "";
         AV48DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV46AppName = "";
         AV52Phone = "";
         AV50Mail = "";
         AV54Website = "";
         AV43AddressLine1 = "";
         AV44AddressLine2 = "";
         AV45AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.departamentowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00412_A185DepartamentoAutEnuMuni, P00412_A113DepartamentoDepartamento, P00412_A116PaisID, P00412_A112DepartamentoId, P00412_A907DepartamentoEstado, P00412_n907DepartamentoEstado
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV62Pgmname = "DepartamentoWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV62Pgmname = "DepartamentoWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV15DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV25DynamicFiltersOperator3 ;
      private short AV38TFDepartamentoAutEnuMuni ;
      private short AV39TFDepartamentoAutEnuMuni_To ;
      private short AV69Departamentowwds_3_dynamicfiltersoperator1 ;
      private short AV73Departamentowwds_7_dynamicfiltersoperator2 ;
      private short AV77Departamentowwds_11_dynamicfiltersoperator3 ;
      private short AV86Departamentowwds_20_tfdepartamentoautenumuni ;
      private short AV87Departamentowwds_21_tfdepartamentoautenumuni_to ;
      private short A185DepartamentoAutEnuMuni ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV65GXV1 ;
      private int AV85Departamentowwds_19_tfdepartamentoestado_sels_Count ;
      private int AV88GXV2 ;
      private long AV32TFDepartamentoId ;
      private long AV33TFDepartamentoId_To ;
      private long AV61i ;
      private long AV79Departamentowwds_13_tfdepartamentoid ;
      private long AV80Departamentowwds_14_tfdepartamentoid_to ;
      private long A112DepartamentoId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV62Pgmname ;
      private string GXEncryptionTmp ;
      private string AV16DepartamentoDepartamento1 ;
      private string AV18DepartamentoDepartamento ;
      private string AV22DepartamentoDepartamento2 ;
      private string AV26DepartamentoDepartamento3 ;
      private string AV35TFPaisID_Sel ;
      private string AV34TFPaisID ;
      private string AV37TFDepartamentoDepartamento_Sel ;
      private string AV36TFDepartamentoDepartamento ;
      private string AV58TFDepartamentoEstado_Sel ;
      private string AV70Departamentowwds_4_departamentodepartamento1 ;
      private string AV74Departamentowwds_8_departamentodepartamento2 ;
      private string AV78Departamentowwds_12_departamentodepartamento3 ;
      private string AV81Departamentowwds_15_tfpaisid ;
      private string AV82Departamentowwds_16_tfpaisid_sel ;
      private string AV83Departamentowwds_17_tfdepartamentodepartamento ;
      private string AV84Departamentowwds_18_tfdepartamentodepartamento_sel ;
      private string lV70Departamentowwds_4_departamentodepartamento1 ;
      private string lV74Departamentowwds_8_departamentodepartamento2 ;
      private string lV78Departamentowwds_12_departamentodepartamento3 ;
      private string lV81Departamentowwds_15_tfpaisid ;
      private string lV83Departamentowwds_17_tfdepartamentodepartamento ;
      private string A907DepartamentoEstado ;
      private string A113DepartamentoDepartamento ;
      private string A116PaisID ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV42TempBoolean ;
      private bool AV71Departamentowwds_5_dynamicfiltersenabled2 ;
      private bool AV75Departamentowwds_9_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private bool n907DepartamentoEstado ;
      private string AV56TFDepartamentoEstado_SelsJson ;
      private string AV53Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV17FilterDepartamentoDepartamentoDescription ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV40TFDepartamentoId_To_Description ;
      private string AV57TFDepartamentoEstado_SelDscs ;
      private string AV60FilterTFDepartamentoEstado_SelValueDescription ;
      private string AV41TFDepartamentoAutEnuMuni_To_Description ;
      private string AV67Departamentowwds_1_filterfulltext ;
      private string AV68Departamentowwds_2_dynamicfiltersselector1 ;
      private string AV72Departamentowwds_6_dynamicfiltersselector2 ;
      private string AV76Departamentowwds_10_dynamicfiltersselector3 ;
      private string lV67Departamentowwds_1_filterfulltext ;
      private string AV55DepartamentoEstadoDescription ;
      private string AV51PageInfo ;
      private string AV48DateInfo ;
      private string AV46AppName ;
      private string AV52Phone ;
      private string AV50Mail ;
      private string AV54Website ;
      private string AV43AddressLine1 ;
      private string AV44AddressLine2 ;
      private string AV45AddressLine3 ;
      private IGxSession AV28Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV59TFDepartamentoEstado_Sels ;
      private GxSimpleCollection<string> AV85Departamentowwds_19_tfdepartamentoestado_sels ;
      private IDataStoreProvider pr_default ;
      private short[] P00412_A185DepartamentoAutEnuMuni ;
      private string[] P00412_A113DepartamentoDepartamento ;
      private string[] P00412_A116PaisID ;
      private long[] P00412_A112DepartamentoId ;
      private string[] P00412_A907DepartamentoEstado ;
      private bool[] P00412_n907DepartamentoEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
   }

   public class departamentowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00412( IGxContext context ,
                                             string A907DepartamentoEstado ,
                                             GxSimpleCollection<string> AV85Departamentowwds_19_tfdepartamentoestado_sels ,
                                             string AV68Departamentowwds_2_dynamicfiltersselector1 ,
                                             short AV69Departamentowwds_3_dynamicfiltersoperator1 ,
                                             string AV70Departamentowwds_4_departamentodepartamento1 ,
                                             bool AV71Departamentowwds_5_dynamicfiltersenabled2 ,
                                             string AV72Departamentowwds_6_dynamicfiltersselector2 ,
                                             short AV73Departamentowwds_7_dynamicfiltersoperator2 ,
                                             string AV74Departamentowwds_8_departamentodepartamento2 ,
                                             bool AV75Departamentowwds_9_dynamicfiltersenabled3 ,
                                             string AV76Departamentowwds_10_dynamicfiltersselector3 ,
                                             short AV77Departamentowwds_11_dynamicfiltersoperator3 ,
                                             string AV78Departamentowwds_12_departamentodepartamento3 ,
                                             long AV79Departamentowwds_13_tfdepartamentoid ,
                                             long AV80Departamentowwds_14_tfdepartamentoid_to ,
                                             string AV82Departamentowwds_16_tfpaisid_sel ,
                                             string AV81Departamentowwds_15_tfpaisid ,
                                             string AV84Departamentowwds_18_tfdepartamentodepartamento_sel ,
                                             string AV83Departamentowwds_17_tfdepartamentodepartamento ,
                                             int AV85Departamentowwds_19_tfdepartamentoestado_sels_Count ,
                                             short AV86Departamentowwds_20_tfdepartamentoautenumuni ,
                                             short AV87Departamentowwds_21_tfdepartamentoautenumuni_to ,
                                             string A113DepartamentoDepartamento ,
                                             long A112DepartamentoId ,
                                             string A116PaisID ,
                                             short A185DepartamentoAutEnuMuni ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             string AV67Departamentowwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[14];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [DepartamentoAutEnuMuni], [DepartamentoDepartamento], [PaisID], [DepartamentoId], [DepartamentoEstado] FROM [Departamento]";
         if ( ( StringUtil.StrCmp(AV68Departamentowwds_2_dynamicfiltersselector1, "DEPARTAMENTODEPARTAMENTO") == 0 ) && ( AV69Departamentowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Departamentowwds_4_departamentodepartamento1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DepartamentoDepartamento]) like UPPER(@lV70Departamentowwds_4_departamentodepartamento1))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV68Departamentowwds_2_dynamicfiltersselector1, "DEPARTAMENTODEPARTAMENTO") == 0 ) && ( AV69Departamentowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Departamentowwds_4_departamentodepartamento1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DepartamentoDepartamento]) like '%' + UPPER(@lV70Departamentowwds_4_departamentodepartamento1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV71Departamentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Departamentowwds_6_dynamicfiltersselector2, "DEPARTAMENTODEPARTAMENTO") == 0 ) && ( AV73Departamentowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Departamentowwds_8_departamentodepartamento2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DepartamentoDepartamento]) like UPPER(@lV74Departamentowwds_8_departamentodepartamento2))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV71Departamentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Departamentowwds_6_dynamicfiltersselector2, "DEPARTAMENTODEPARTAMENTO") == 0 ) && ( AV73Departamentowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Departamentowwds_8_departamentodepartamento2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DepartamentoDepartamento]) like '%' + UPPER(@lV74Departamentowwds_8_departamentodepartamento2))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV75Departamentowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Departamentowwds_10_dynamicfiltersselector3, "DEPARTAMENTODEPARTAMENTO") == 0 ) && ( AV77Departamentowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Departamentowwds_12_departamentodepartamento3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DepartamentoDepartamento]) like UPPER(@lV78Departamentowwds_12_departamentodepartamento3))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV75Departamentowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Departamentowwds_10_dynamicfiltersselector3, "DEPARTAMENTODEPARTAMENTO") == 0 ) && ( AV77Departamentowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Departamentowwds_12_departamentodepartamento3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DepartamentoDepartamento]) like '%' + UPPER(@lV78Departamentowwds_12_departamentodepartamento3))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV79Departamentowwds_13_tfdepartamentoid) )
         {
            AddWhere(sWhereString, "([DepartamentoId] >= @AV79Departamentowwds_13_tfdepartamentoid)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV80Departamentowwds_14_tfdepartamentoid_to) )
         {
            AddWhere(sWhereString, "([DepartamentoId] <= @AV80Departamentowwds_14_tfdepartamentoid_to)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Departamentowwds_16_tfpaisid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Departamentowwds_15_tfpaisid)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisID]) like UPPER(@lV81Departamentowwds_15_tfpaisid))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Departamentowwds_16_tfpaisid_sel)) && ! ( StringUtil.StrCmp(AV82Departamentowwds_16_tfpaisid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([PaisID] = @AV82Departamentowwds_16_tfpaisid_sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV82Departamentowwds_16_tfpaisid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([PaisID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Departamentowwds_18_tfdepartamentodepartamento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Departamentowwds_17_tfdepartamentodepartamento)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DepartamentoDepartamento]) like UPPER(@lV83Departamentowwds_17_tfdepartamentodepartamento))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Departamentowwds_18_tfdepartamentodepartamento_sel)) && ! ( StringUtil.StrCmp(AV84Departamentowwds_18_tfdepartamentodepartamento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([DepartamentoDepartamento] = @AV84Departamentowwds_18_tfdepartamentodepartamento_sel)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV84Departamentowwds_18_tfdepartamentodepartamento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([DepartamentoDepartamento] = ''))");
         }
         if ( AV85Departamentowwds_19_tfdepartamentoestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV85Departamentowwds_19_tfdepartamentoestado_sels, "[DepartamentoEstado] IN (", ")")+")");
         }
         if ( ! (0==AV86Departamentowwds_20_tfdepartamentoautenumuni) )
         {
            AddWhere(sWhereString, "([DepartamentoAutEnuMuni] >= @AV86Departamentowwds_20_tfdepartamentoautenumuni)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! (0==AV87Departamentowwds_21_tfdepartamentoautenumuni_to) )
         {
            AddWhere(sWhereString, "([DepartamentoAutEnuMuni] <= @AV87Departamentowwds_21_tfdepartamentoautenumuni_to)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [DepartamentoDepartamento]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [DepartamentoDepartamento] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [DepartamentoId]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [DepartamentoId] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [PaisID]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [PaisID] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [DepartamentoEstado]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [DepartamentoEstado] DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [DepartamentoAutEnuMuni]";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [DepartamentoAutEnuMuni] DESC";
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
                     return conditional_P00412(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (short)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] , (string)dynConstraints[28] );
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
          Object[] prmP00412;
          prmP00412 = new Object[] {
          new ParDef("@lV70Departamentowwds_4_departamentodepartamento1",GXType.Char,80,0) ,
          new ParDef("@lV70Departamentowwds_4_departamentodepartamento1",GXType.Char,80,0) ,
          new ParDef("@lV74Departamentowwds_8_departamentodepartamento2",GXType.Char,80,0) ,
          new ParDef("@lV74Departamentowwds_8_departamentodepartamento2",GXType.Char,80,0) ,
          new ParDef("@lV78Departamentowwds_12_departamentodepartamento3",GXType.Char,80,0) ,
          new ParDef("@lV78Departamentowwds_12_departamentodepartamento3",GXType.Char,80,0) ,
          new ParDef("@AV79Departamentowwds_13_tfdepartamentoid",GXType.Decimal,18,0) ,
          new ParDef("@AV80Departamentowwds_14_tfdepartamentoid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV81Departamentowwds_15_tfpaisid",GXType.Char,2,0) ,
          new ParDef("@AV82Departamentowwds_16_tfpaisid_sel",GXType.NChar,2,0) ,
          new ParDef("@lV83Departamentowwds_17_tfdepartamentodepartamento",GXType.Char,80,0) ,
          new ParDef("@AV84Departamentowwds_18_tfdepartamentodepartamento_sel",GXType.NChar,80,0) ,
          new ParDef("@AV86Departamentowwds_20_tfdepartamentoautenumuni",GXType.Int16,4,0) ,
          new ParDef("@AV87Departamentowwds_21_tfdepartamentoautenumuni_to",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00412", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00412,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((string[]) buf[2])[0] = rslt.getString(3, 2);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 3);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
