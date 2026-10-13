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
   public class centrocostoswwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public centrocostoswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public centrocostoswwexportreport( IGxContext context )
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
         setOutputFileName("CentroCostosWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCentroCostos", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV75Pgmname));
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
               AV73Title = context.GetMessage( "Lista de Centro de Costos", "");
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
            H5Z0( true, 0) ;
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
            H5Z0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 155, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 155, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV27GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "CENTROCOSTOSNOMBRE") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV27GridStateDynamicFilter.gxTpr_Operator;
               AV16CentroCostosNombre1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16CentroCostosNombre1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterCentroCostosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre:", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterCentroCostosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre:", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV18CentroCostosNombre = AV16CentroCostosNombre1;
                  H5Z0( false, 19) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterCentroCostosNombreDescription, "")), 25, Gx_line+0, 155, Gx_line+14, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18CentroCostosNombre, "")), 155, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV19DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CENTROCOSTOSNOMBRE") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV27GridStateDynamicFilter.gxTpr_Operator;
                  AV22CentroCostosNombre2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22CentroCostosNombre2)) )
                  {
                     if ( AV21DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterCentroCostosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre:", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV21DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterCentroCostosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre:", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV18CentroCostosNombre = AV22CentroCostosNombre2;
                     H5Z0( false, 19) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterCentroCostosNombreDescription, "")), 25, Gx_line+0, 155, Gx_line+14, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18CentroCostosNombre, "")), 155, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "CENTROCOSTOSNOMBRE") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV27GridStateDynamicFilter.gxTpr_Operator;
                     AV26CentroCostosNombre3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26CentroCostosNombre3)) )
                     {
                        if ( AV25DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterCentroCostosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre:", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV25DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterCentroCostosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre:", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV18CentroCostosNombre = AV26CentroCostosNombre3;
                        H5Z0( false, 19) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterCentroCostosNombreDescription, "")), 25, Gx_line+0, 155, Gx_line+14, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18CentroCostosNombre, "")), 155, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV34TFCentroCostosId) && (0==AV35TFCentroCostosId_To) ) )
         {
            H5Z0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Código CC:", ""), 25, Gx_line+0, 155, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV34TFCentroCostosId), "ZZZZZZZZZZZZZZZZZ9")), 155, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV54TFCentroCostosId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Código CC:", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H5Z0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54TFCentroCostosId_To_Description, "")), 25, Gx_line+0, 155, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV35TFCentroCostosId_To), "ZZZZZZZZZZZZZZZZZ9")), 155, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (0==AV36TFCentroCostosRef) && (0==AV37TFCentroCostosRef_To) ) )
         {
            H5Z0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Referencia Nro:", ""), 25, Gx_line+0, 155, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV36TFCentroCostosRef), "ZZZZZZZZZZZZZZZZZ9")), 155, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV55TFCentroCostosRef_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Referencia Nro:", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H5Z0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55TFCentroCostosRef_To_Description, "")), 25, Gx_line+0, 155, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV37TFCentroCostosRef_To), "ZZZZZZZZZZZZZZZZZ9")), 155, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFCentroCostosNombre_Sel)) )
         {
            AV61TempBoolean = (bool)(((StringUtil.StrCmp(AV39TFCentroCostosNombre_Sel, "<#Empty#>")==0)));
            AV39TFCentroCostosNombre_Sel = (AV61TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV39TFCentroCostosNombre_Sel);
            H5Z0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nombre:", ""), 25, Gx_line+0, 155, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFCentroCostosNombre_Sel, "")), 155, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV39TFCentroCostosNombre_Sel = (AV61TempBoolean ? "<#Empty#>" : AV39TFCentroCostosNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCentroCostosNombre)) )
            {
               H5Z0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Nombre:", ""), 25, Gx_line+0, 155, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFCentroCostosNombre, "")), 155, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV40TFCentroCostosPrecioFinal) && (Convert.ToDecimal(0)==AV41TFCentroCostosPrecioFinal_To) ) )
         {
            H5Z0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Precio Final:", ""), 25, Gx_line+0, 155, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40TFCentroCostosPrecioFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 155, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV56TFCentroCostosPrecioFinal_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Precio Final:", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H5Z0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56TFCentroCostosPrecioFinal_To_Description, "")), 25, Gx_line+0, 155, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV41TFCentroCostosPrecioFinal_To, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 155, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV42TFCentroCostosCosto) && (Convert.ToDecimal(0)==AV43TFCentroCostosCosto_To) ) )
         {
            H5Z0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Costo", ""), 25, Gx_line+0, 155, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42TFCentroCostosCosto, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 155, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV57TFCentroCostosCosto_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Costo", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H5Z0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57TFCentroCostosCosto_To_Description, "")), 25, Gx_line+0, 155, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV43TFCentroCostosCosto_To, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 155, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV44TFCentroCostosGam) && (Convert.ToDecimal(0)==AV45TFCentroCostosGam_To) ) )
         {
            H5Z0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Ganancia", ""), 25, Gx_line+0, 155, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV44TFCentroCostosGam, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 155, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV58TFCentroCostosGam_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Ganancia", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H5Z0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58TFCentroCostosGam_To_Description, "")), 25, Gx_line+0, 155, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45TFCentroCostosGam_To, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 155, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         AV48TFCentroCostosEstado_Sels.FromJSonString(AV46TFCentroCostosEstado_SelsJson, null);
         if ( ! ( AV48TFCentroCostosEstado_Sels.Count == 0 ) )
         {
            AV62i = 1;
            AV78GXV1 = 1;
            while ( AV78GXV1 <= AV48TFCentroCostosEstado_Sels.Count )
            {
               AV49TFCentroCostosEstado_Sel = AV48TFCentroCostosEstado_Sels.GetString(AV78GXV1);
               if ( AV62i == 1 )
               {
                  AV47TFCentroCostosEstado_SelDscs = "";
               }
               else
               {
                  AV47TFCentroCostosEstado_SelDscs += ", ";
               }
               AV59FilterTFCentroCostosEstado_SelValueDescription = "";
               if ( StringUtil.StrCmp(StringUtil.Trim( AV49TFCentroCostosEstado_Sel), "HAB") == 0 )
               {
                  AV59FilterTFCentroCostosEstado_SelValueDescription = context.GetMessage( "Aprobado", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV49TFCentroCostosEstado_Sel), "DES") == 0 )
               {
                  AV59FilterTFCentroCostosEstado_SelValueDescription = context.GetMessage( "Deshabilitado", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV49TFCentroCostosEstado_Sel), "PND") == 0 )
               {
                  AV59FilterTFCentroCostosEstado_SelValueDescription = context.GetMessage( "Pendiente de Aprobación", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV49TFCentroCostosEstado_Sel), "DES") == 0 )
               {
                  AV59FilterTFCentroCostosEstado_SelValueDescription = context.GetMessage( "Desaprobado", "");
               }
               AV47TFCentroCostosEstado_SelDscs += AV59FilterTFCentroCostosEstado_SelValueDescription;
               AV62i = (long)(AV62i+1);
               AV78GXV1 = (int)(AV78GXV1+1);
            }
            H5Z0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 25, Gx_line+0, 155, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47TFCentroCostosEstado_SelDscs, "")), 155, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         AV52TFCentroCostosTipoRef_Sels.FromJSonString(AV50TFCentroCostosTipoRef_SelsJson, null);
         if ( ! ( AV52TFCentroCostosTipoRef_Sels.Count == 0 ) )
         {
            AV62i = 1;
            AV79GXV2 = 1;
            while ( AV79GXV2 <= AV52TFCentroCostosTipoRef_Sels.Count )
            {
               AV53TFCentroCostosTipoRef_Sel = AV52TFCentroCostosTipoRef_Sels.GetString(AV79GXV2);
               if ( AV62i == 1 )
               {
                  AV51TFCentroCostosTipoRef_SelDscs = "";
               }
               else
               {
                  AV51TFCentroCostosTipoRef_SelDscs += ", ";
               }
               AV60FilterTFCentroCostosTipoRef_SelValueDescription = "";
               if ( StringUtil.StrCmp(StringUtil.Trim( AV53TFCentroCostosTipoRef_Sel), "S") == 0 )
               {
                  AV60FilterTFCentroCostosTipoRef_SelValueDescription = context.GetMessage( "Servicios", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV53TFCentroCostosTipoRef_Sel), "O") == 0 )
               {
                  AV60FilterTFCentroCostosTipoRef_SelValueDescription = context.GetMessage( "Otros", "");
               }
               AV51TFCentroCostosTipoRef_SelDscs += AV60FilterTFCentroCostosTipoRef_SelValueDescription;
               AV62i = (long)(AV62i+1);
               AV79GXV2 = (int)(AV79GXV2+1);
            }
            H5Z0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Tipo Referencia:", ""), 25, Gx_line+0, 155, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51TFCentroCostosTipoRef_SelDscs, "")), 155, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H5Z0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H5Z0( false, 36) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Código CC:", ""), 30, Gx_line+10, 96, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Referencia Nro:", ""), 100, Gx_line+10, 166, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Nombre:", ""), 170, Gx_line+10, 302, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Precio Final:", ""), 306, Gx_line+10, 372, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Costo", ""), 376, Gx_line+10, 442, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Ganancia", ""), 446, Gx_line+10, 512, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 516, Gx_line+10, 649, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Tipo Referencia:", ""), 653, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV81Centrocostoswwds_1_filterfulltext = AV13FilterFullText;
         AV82Centrocostoswwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV83Centrocostoswwds_3_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV84Centrocostoswwds_4_centrocostosnombre1 = AV16CentroCostosNombre1;
         AV85Centrocostoswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV86Centrocostoswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV87Centrocostoswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV88Centrocostoswwds_8_centrocostosnombre2 = AV22CentroCostosNombre2;
         AV89Centrocostoswwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV90Centrocostoswwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV91Centrocostoswwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV92Centrocostoswwds_12_centrocostosnombre3 = AV26CentroCostosNombre3;
         AV93Centrocostoswwds_13_tfcentrocostosid = AV34TFCentroCostosId;
         AV94Centrocostoswwds_14_tfcentrocostosid_to = AV35TFCentroCostosId_To;
         AV95Centrocostoswwds_15_tfcentrocostosref = AV36TFCentroCostosRef;
         AV96Centrocostoswwds_16_tfcentrocostosref_to = AV37TFCentroCostosRef_To;
         AV97Centrocostoswwds_17_tfcentrocostosnombre = AV38TFCentroCostosNombre;
         AV98Centrocostoswwds_18_tfcentrocostosnombre_sel = AV39TFCentroCostosNombre_Sel;
         AV99Centrocostoswwds_19_tfcentrocostospreciofinal = AV40TFCentroCostosPrecioFinal;
         AV100Centrocostoswwds_20_tfcentrocostospreciofinal_to = AV41TFCentroCostosPrecioFinal_To;
         AV101Centrocostoswwds_21_tfcentrocostoscosto = AV42TFCentroCostosCosto;
         AV102Centrocostoswwds_22_tfcentrocostoscosto_to = AV43TFCentroCostosCosto_To;
         AV103Centrocostoswwds_23_tfcentrocostosgam = AV44TFCentroCostosGam;
         AV104Centrocostoswwds_24_tfcentrocostosgam_to = AV45TFCentroCostosGam_To;
         AV105Centrocostoswwds_25_tfcentrocostosestado_sels = AV48TFCentroCostosEstado_Sels;
         AV106Centrocostoswwds_26_tfcentrocostostiporef_sels = AV52TFCentroCostosTipoRef_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A482CentroCostosEstado ,
                                              AV105Centrocostoswwds_25_tfcentrocostosestado_sels ,
                                              A487CentroCostosTipoRef ,
                                              AV106Centrocostoswwds_26_tfcentrocostostiporef_sels ,
                                              AV82Centrocostoswwds_2_dynamicfiltersselector1 ,
                                              AV83Centrocostoswwds_3_dynamicfiltersoperator1 ,
                                              AV84Centrocostoswwds_4_centrocostosnombre1 ,
                                              AV85Centrocostoswwds_5_dynamicfiltersenabled2 ,
                                              AV86Centrocostoswwds_6_dynamicfiltersselector2 ,
                                              AV87Centrocostoswwds_7_dynamicfiltersoperator2 ,
                                              AV88Centrocostoswwds_8_centrocostosnombre2 ,
                                              AV89Centrocostoswwds_9_dynamicfiltersenabled3 ,
                                              AV90Centrocostoswwds_10_dynamicfiltersselector3 ,
                                              AV91Centrocostoswwds_11_dynamicfiltersoperator3 ,
                                              AV92Centrocostoswwds_12_centrocostosnombre3 ,
                                              AV93Centrocostoswwds_13_tfcentrocostosid ,
                                              AV94Centrocostoswwds_14_tfcentrocostosid_to ,
                                              AV95Centrocostoswwds_15_tfcentrocostosref ,
                                              AV96Centrocostoswwds_16_tfcentrocostosref_to ,
                                              AV98Centrocostoswwds_18_tfcentrocostosnombre_sel ,
                                              AV97Centrocostoswwds_17_tfcentrocostosnombre ,
                                              AV99Centrocostoswwds_19_tfcentrocostospreciofinal ,
                                              AV100Centrocostoswwds_20_tfcentrocostospreciofinal_to ,
                                              AV101Centrocostoswwds_21_tfcentrocostoscosto ,
                                              AV102Centrocostoswwds_22_tfcentrocostoscosto_to ,
                                              AV103Centrocostoswwds_23_tfcentrocostosgam ,
                                              AV104Centrocostoswwds_24_tfcentrocostosgam_to ,
                                              AV105Centrocostoswwds_25_tfcentrocostosestado_sels.Count ,
                                              AV106Centrocostoswwds_26_tfcentrocostostiporef_sels.Count ,
                                              A463CentroCostosNombre ,
                                              A461CentroCostosId ,
                                              A462CentroCostosRef ,
                                              A464CentroCostosPrecioFinal ,
                                              A475CentroCostosCosto ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              AV81Centrocostoswwds_1_filterfulltext ,
                                              A474CentroCostosGam } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL
                                              }
         });
         lV84Centrocostoswwds_4_centrocostosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV84Centrocostoswwds_4_centrocostosnombre1), 80, "%");
         lV84Centrocostoswwds_4_centrocostosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV84Centrocostoswwds_4_centrocostosnombre1), 80, "%");
         lV88Centrocostoswwds_8_centrocostosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV88Centrocostoswwds_8_centrocostosnombre2), 80, "%");
         lV88Centrocostoswwds_8_centrocostosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV88Centrocostoswwds_8_centrocostosnombre2), 80, "%");
         lV92Centrocostoswwds_12_centrocostosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV92Centrocostoswwds_12_centrocostosnombre3), 80, "%");
         lV92Centrocostoswwds_12_centrocostosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV92Centrocostoswwds_12_centrocostosnombre3), 80, "%");
         lV97Centrocostoswwds_17_tfcentrocostosnombre = StringUtil.PadR( StringUtil.RTrim( AV97Centrocostoswwds_17_tfcentrocostosnombre), 80, "%");
         /* Using cursor P005Z2 */
         pr_default.execute(0, new Object[] {lV84Centrocostoswwds_4_centrocostosnombre1, lV84Centrocostoswwds_4_centrocostosnombre1, lV88Centrocostoswwds_8_centrocostosnombre2, lV88Centrocostoswwds_8_centrocostosnombre2, lV92Centrocostoswwds_12_centrocostosnombre3, lV92Centrocostoswwds_12_centrocostosnombre3, AV93Centrocostoswwds_13_tfcentrocostosid, AV94Centrocostoswwds_14_tfcentrocostosid_to, AV95Centrocostoswwds_15_tfcentrocostosref, AV96Centrocostoswwds_16_tfcentrocostosref_to, lV97Centrocostoswwds_17_tfcentrocostosnombre, AV98Centrocostoswwds_18_tfcentrocostosnombre_sel, AV99Centrocostoswwds_19_tfcentrocostospreciofinal, AV100Centrocostoswwds_20_tfcentrocostospreciofinal_to, AV101Centrocostoswwds_21_tfcentrocostoscosto, AV102Centrocostoswwds_22_tfcentrocostoscosto_to, AV103Centrocostoswwds_23_tfcentrocostosgam, AV104Centrocostoswwds_24_tfcentrocostosgam_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A474CentroCostosGam = P005Z2_A474CentroCostosGam[0];
            A463CentroCostosNombre = P005Z2_A463CentroCostosNombre[0];
            A462CentroCostosRef = P005Z2_A462CentroCostosRef[0];
            A461CentroCostosId = P005Z2_A461CentroCostosId[0];
            A487CentroCostosTipoRef = P005Z2_A487CentroCostosTipoRef[0];
            A482CentroCostosEstado = P005Z2_A482CentroCostosEstado[0];
            A464CentroCostosPrecioFinal = P005Z2_A464CentroCostosPrecioFinal[0];
            A475CentroCostosCosto = P005Z2_A475CentroCostosCosto[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Centrocostoswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A461CentroCostosId), 18, 0) , StringUtil.PadR( "%" + AV81Centrocostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A462CentroCostosRef), 18, 0) , StringUtil.PadR( "%" + AV81Centrocostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A463CentroCostosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV81Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A464CentroCostosPrecioFinal, 18, 2) , StringUtil.PadR( "%" + AV81Centrocostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A475CentroCostosCosto, 18, 2) , StringUtil.PadR( "%" + AV81Centrocostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A474CentroCostosGam, 18, 2) , StringUtil.PadR( "%" + AV81Centrocostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "aprobado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente de aprobación", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "PND") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "desaprobado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A482CentroCostosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "servicios", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A487CentroCostosTipoRef, "S") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A487CentroCostosTipoRef, "O") == 0 ) ) )
            )
            {
               AV28CentroCostosEstadoDescription = "";
               if ( StringUtil.StrCmp(StringUtil.Trim( A482CentroCostosEstado), "HAB") == 0 )
               {
                  AV28CentroCostosEstadoDescription = context.GetMessage( "Aprobado", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( A482CentroCostosEstado), "DES") == 0 )
               {
                  AV28CentroCostosEstadoDescription = context.GetMessage( "Deshabilitado", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( A482CentroCostosEstado), "PND") == 0 )
               {
                  AV28CentroCostosEstadoDescription = context.GetMessage( "Pendiente de Aprobación", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( A482CentroCostosEstado), "DES") == 0 )
               {
                  AV28CentroCostosEstadoDescription = context.GetMessage( "Desaprobado", "");
               }
               AV29CentroCostosTipoRefDescription = "";
               if ( StringUtil.StrCmp(StringUtil.Trim( A487CentroCostosTipoRef), "S") == 0 )
               {
                  AV29CentroCostosTipoRefDescription = context.GetMessage( "Servicios", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( A487CentroCostosTipoRef), "O") == 0 )
               {
                  AV29CentroCostosTipoRefDescription = context.GetMessage( "Otros", "");
               }
               /* Execute user subroutine: 'BEFOREPRINTLINE' */
               S144 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               H5Z0( false, 35) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A461CentroCostosId), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 96, Gx_line+24, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A462CentroCostosRef), "ZZZZZZZZZZZZZZZZZ9")), 100, Gx_line+10, 166, Gx_line+24, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A463CentroCostosNombre, "")), 170, Gx_line+10, 302, Gx_line+24, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A464CentroCostosPrecioFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 306, Gx_line+10, 372, Gx_line+24, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A475CentroCostosCosto, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 376, Gx_line+10, 442, Gx_line+24, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A474CentroCostosGam, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 446, Gx_line+10, 512, Gx_line+24, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28CentroCostosEstadoDescription, "")), 516, Gx_line+10, 649, Gx_line+24, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29CentroCostosTipoRefDescription, "")), 653, Gx_line+10, 787, Gx_line+24, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV30Session.Get("CentroCostosWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "CentroCostosWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("CentroCostosWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV107GXV3 = 1;
         while ( AV107GXV3 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV107GXV3));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSID") == 0 )
            {
               AV34TFCentroCostosId = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV35TFCentroCostosId_To = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSREF") == 0 )
            {
               AV36TFCentroCostosRef = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV37TFCentroCostosRef_To = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSNOMBRE") == 0 )
            {
               AV38TFCentroCostosNombre = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSNOMBRE_SEL") == 0 )
            {
               AV39TFCentroCostosNombre_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSPRECIOFINAL") == 0 )
            {
               AV40TFCentroCostosPrecioFinal = NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, ".");
               AV41TFCentroCostosPrecioFinal_To = NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSCOSTO") == 0 )
            {
               AV42TFCentroCostosCosto = NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, ".");
               AV43TFCentroCostosCosto_To = NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSGAM") == 0 )
            {
               AV44TFCentroCostosGam = NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, ".");
               AV45TFCentroCostosGam_To = NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSESTADO_SEL") == 0 )
            {
               AV46TFCentroCostosEstado_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV48TFCentroCostosEstado_Sels.FromJSonString(AV46TFCentroCostosEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSTIPOREF_SEL") == 0 )
            {
               AV50TFCentroCostosTipoRef_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV52TFCentroCostosTipoRef_Sels.FromJSonString(AV50TFCentroCostosTipoRef_SelsJson, null);
            }
            AV107GXV3 = (int)(AV107GXV3+1);
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

      protected void H5Z0( bool bFoot ,
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
                  AV71PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV68DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+39, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71PageInfo, "")), 30, Gx_line+15, 409, Gx_line+29, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68DateInfo, "")), 409, Gx_line+15, 789, Gx_line+29, 2, 0, 0, 0) ;
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
               AV66AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV72Phone = "+1 550 8923";
               AV70Mail = "info@mail.com";
               AV74Website = "http://www.web.com";
               AV63AddressLine1 = "French Boulevard 2859";
               AV64AddressLine2 = "Downtown";
               AV65AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+107, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66AppName, "")), 30, Gx_line+30, 283, Gx_line+44, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73Title, "")), 30, Gx_line+44, 283, Gx_line+77, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV72Phone, "")), 283, Gx_line+30, 536, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70Mail, "")), 283, Gx_line+45, 536, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74Website, "")), 283, Gx_line+60, 536, Gx_line+77, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64AddressLine2, "")), 536, Gx_line+45, 789, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65AddressLine3, "")), 536, Gx_line+60, 789, Gx_line+77, 2, 0, 0, 0) ;
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
         AV75Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV73Title = "";
         AV13FilterFullText = "";
         AV32GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV16CentroCostosNombre1 = "";
         AV17FilterCentroCostosNombreDescription = "";
         AV18CentroCostosNombre = "";
         AV20DynamicFiltersSelector2 = "";
         AV22CentroCostosNombre2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV26CentroCostosNombre3 = "";
         AV54TFCentroCostosId_To_Description = "";
         AV55TFCentroCostosRef_To_Description = "";
         AV39TFCentroCostosNombre_Sel = "";
         AV38TFCentroCostosNombre = "";
         AV56TFCentroCostosPrecioFinal_To_Description = "";
         AV57TFCentroCostosCosto_To_Description = "";
         AV58TFCentroCostosGam_To_Description = "";
         AV48TFCentroCostosEstado_Sels = new GxSimpleCollection<string>();
         AV46TFCentroCostosEstado_SelsJson = "";
         AV49TFCentroCostosEstado_Sel = "";
         AV47TFCentroCostosEstado_SelDscs = "";
         AV59FilterTFCentroCostosEstado_SelValueDescription = "";
         AV52TFCentroCostosTipoRef_Sels = new GxSimpleCollection<string>();
         AV50TFCentroCostosTipoRef_SelsJson = "";
         AV53TFCentroCostosTipoRef_Sel = "";
         AV51TFCentroCostosTipoRef_SelDscs = "";
         AV60FilterTFCentroCostosTipoRef_SelValueDescription = "";
         AV81Centrocostoswwds_1_filterfulltext = "";
         AV82Centrocostoswwds_2_dynamicfiltersselector1 = "";
         AV84Centrocostoswwds_4_centrocostosnombre1 = "";
         AV86Centrocostoswwds_6_dynamicfiltersselector2 = "";
         AV88Centrocostoswwds_8_centrocostosnombre2 = "";
         AV90Centrocostoswwds_10_dynamicfiltersselector3 = "";
         AV92Centrocostoswwds_12_centrocostosnombre3 = "";
         AV97Centrocostoswwds_17_tfcentrocostosnombre = "";
         AV98Centrocostoswwds_18_tfcentrocostosnombre_sel = "";
         AV105Centrocostoswwds_25_tfcentrocostosestado_sels = new GxSimpleCollection<string>();
         AV106Centrocostoswwds_26_tfcentrocostostiporef_sels = new GxSimpleCollection<string>();
         lV84Centrocostoswwds_4_centrocostosnombre1 = "";
         lV88Centrocostoswwds_8_centrocostosnombre2 = "";
         lV92Centrocostoswwds_12_centrocostosnombre3 = "";
         lV97Centrocostoswwds_17_tfcentrocostosnombre = "";
         A482CentroCostosEstado = "";
         A487CentroCostosTipoRef = "";
         A463CentroCostosNombre = "";
         P005Z2_A474CentroCostosGam = new decimal[1] ;
         P005Z2_A463CentroCostosNombre = new string[] {""} ;
         P005Z2_A462CentroCostosRef = new long[1] ;
         P005Z2_A461CentroCostosId = new long[1] ;
         P005Z2_A487CentroCostosTipoRef = new string[] {""} ;
         P005Z2_A482CentroCostosEstado = new string[] {""} ;
         P005Z2_A464CentroCostosPrecioFinal = new decimal[1] ;
         P005Z2_A475CentroCostosCosto = new decimal[1] ;
         AV28CentroCostosEstadoDescription = "";
         AV29CentroCostosTipoRefDescription = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV71PageInfo = "";
         AV68DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV66AppName = "";
         AV72Phone = "";
         AV70Mail = "";
         AV74Website = "";
         AV63AddressLine1 = "";
         AV64AddressLine2 = "";
         AV65AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.centrocostoswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P005Z2_A474CentroCostosGam, P005Z2_A463CentroCostosNombre, P005Z2_A462CentroCostosRef, P005Z2_A461CentroCostosId, P005Z2_A487CentroCostosTipoRef, P005Z2_A482CentroCostosEstado, P005Z2_A464CentroCostosPrecioFinal, P005Z2_A475CentroCostosCosto
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV75Pgmname = "CentroCostosWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV75Pgmname = "CentroCostosWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV15DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV25DynamicFiltersOperator3 ;
      private short AV83Centrocostoswwds_3_dynamicfiltersoperator1 ;
      private short AV87Centrocostoswwds_7_dynamicfiltersoperator2 ;
      private short AV91Centrocostoswwds_11_dynamicfiltersoperator3 ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV78GXV1 ;
      private int AV79GXV2 ;
      private int AV105Centrocostoswwds_25_tfcentrocostosestado_sels_Count ;
      private int AV106Centrocostoswwds_26_tfcentrocostostiporef_sels_Count ;
      private int AV107GXV3 ;
      private long AV34TFCentroCostosId ;
      private long AV35TFCentroCostosId_To ;
      private long AV36TFCentroCostosRef ;
      private long AV37TFCentroCostosRef_To ;
      private long AV62i ;
      private long AV93Centrocostoswwds_13_tfcentrocostosid ;
      private long AV94Centrocostoswwds_14_tfcentrocostosid_to ;
      private long AV95Centrocostoswwds_15_tfcentrocostosref ;
      private long AV96Centrocostoswwds_16_tfcentrocostosref_to ;
      private long A461CentroCostosId ;
      private long A462CentroCostosRef ;
      private decimal AV40TFCentroCostosPrecioFinal ;
      private decimal AV41TFCentroCostosPrecioFinal_To ;
      private decimal AV42TFCentroCostosCosto ;
      private decimal AV43TFCentroCostosCosto_To ;
      private decimal AV44TFCentroCostosGam ;
      private decimal AV45TFCentroCostosGam_To ;
      private decimal AV99Centrocostoswwds_19_tfcentrocostospreciofinal ;
      private decimal AV100Centrocostoswwds_20_tfcentrocostospreciofinal_to ;
      private decimal AV101Centrocostoswwds_21_tfcentrocostoscosto ;
      private decimal AV102Centrocostoswwds_22_tfcentrocostoscosto_to ;
      private decimal AV103Centrocostoswwds_23_tfcentrocostosgam ;
      private decimal AV104Centrocostoswwds_24_tfcentrocostosgam_to ;
      private decimal A464CentroCostosPrecioFinal ;
      private decimal A475CentroCostosCosto ;
      private decimal A474CentroCostosGam ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV75Pgmname ;
      private string GXEncryptionTmp ;
      private string AV16CentroCostosNombre1 ;
      private string AV18CentroCostosNombre ;
      private string AV22CentroCostosNombre2 ;
      private string AV26CentroCostosNombre3 ;
      private string AV39TFCentroCostosNombre_Sel ;
      private string AV38TFCentroCostosNombre ;
      private string AV49TFCentroCostosEstado_Sel ;
      private string AV53TFCentroCostosTipoRef_Sel ;
      private string AV84Centrocostoswwds_4_centrocostosnombre1 ;
      private string AV88Centrocostoswwds_8_centrocostosnombre2 ;
      private string AV92Centrocostoswwds_12_centrocostosnombre3 ;
      private string AV97Centrocostoswwds_17_tfcentrocostosnombre ;
      private string AV98Centrocostoswwds_18_tfcentrocostosnombre_sel ;
      private string lV84Centrocostoswwds_4_centrocostosnombre1 ;
      private string lV88Centrocostoswwds_8_centrocostosnombre2 ;
      private string lV92Centrocostoswwds_12_centrocostosnombre3 ;
      private string lV97Centrocostoswwds_17_tfcentrocostosnombre ;
      private string A482CentroCostosEstado ;
      private string A487CentroCostosTipoRef ;
      private string A463CentroCostosNombre ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV61TempBoolean ;
      private bool AV85Centrocostoswwds_5_dynamicfiltersenabled2 ;
      private bool AV89Centrocostoswwds_9_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private string AV46TFCentroCostosEstado_SelsJson ;
      private string AV50TFCentroCostosTipoRef_SelsJson ;
      private string AV73Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV17FilterCentroCostosNombreDescription ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV54TFCentroCostosId_To_Description ;
      private string AV55TFCentroCostosRef_To_Description ;
      private string AV56TFCentroCostosPrecioFinal_To_Description ;
      private string AV57TFCentroCostosCosto_To_Description ;
      private string AV58TFCentroCostosGam_To_Description ;
      private string AV47TFCentroCostosEstado_SelDscs ;
      private string AV59FilterTFCentroCostosEstado_SelValueDescription ;
      private string AV51TFCentroCostosTipoRef_SelDscs ;
      private string AV60FilterTFCentroCostosTipoRef_SelValueDescription ;
      private string AV81Centrocostoswwds_1_filterfulltext ;
      private string AV82Centrocostoswwds_2_dynamicfiltersselector1 ;
      private string AV86Centrocostoswwds_6_dynamicfiltersselector2 ;
      private string AV90Centrocostoswwds_10_dynamicfiltersselector3 ;
      private string AV28CentroCostosEstadoDescription ;
      private string AV29CentroCostosTipoRefDescription ;
      private string AV71PageInfo ;
      private string AV68DateInfo ;
      private string AV66AppName ;
      private string AV72Phone ;
      private string AV70Mail ;
      private string AV74Website ;
      private string AV63AddressLine1 ;
      private string AV64AddressLine2 ;
      private string AV65AddressLine3 ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV48TFCentroCostosEstado_Sels ;
      private GxSimpleCollection<string> AV52TFCentroCostosTipoRef_Sels ;
      private GxSimpleCollection<string> AV105Centrocostoswwds_25_tfcentrocostosestado_sels ;
      private GxSimpleCollection<string> AV106Centrocostoswwds_26_tfcentrocostostiporef_sels ;
      private IDataStoreProvider pr_default ;
      private decimal[] P005Z2_A474CentroCostosGam ;
      private string[] P005Z2_A463CentroCostosNombre ;
      private long[] P005Z2_A462CentroCostosRef ;
      private long[] P005Z2_A461CentroCostosId ;
      private string[] P005Z2_A487CentroCostosTipoRef ;
      private string[] P005Z2_A482CentroCostosEstado ;
      private decimal[] P005Z2_A464CentroCostosPrecioFinal ;
      private decimal[] P005Z2_A475CentroCostosCosto ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
   }

   public class centrocostoswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005Z2( IGxContext context ,
                                             string A482CentroCostosEstado ,
                                             GxSimpleCollection<string> AV105Centrocostoswwds_25_tfcentrocostosestado_sels ,
                                             string A487CentroCostosTipoRef ,
                                             GxSimpleCollection<string> AV106Centrocostoswwds_26_tfcentrocostostiporef_sels ,
                                             string AV82Centrocostoswwds_2_dynamicfiltersselector1 ,
                                             short AV83Centrocostoswwds_3_dynamicfiltersoperator1 ,
                                             string AV84Centrocostoswwds_4_centrocostosnombre1 ,
                                             bool AV85Centrocostoswwds_5_dynamicfiltersenabled2 ,
                                             string AV86Centrocostoswwds_6_dynamicfiltersselector2 ,
                                             short AV87Centrocostoswwds_7_dynamicfiltersoperator2 ,
                                             string AV88Centrocostoswwds_8_centrocostosnombre2 ,
                                             bool AV89Centrocostoswwds_9_dynamicfiltersenabled3 ,
                                             string AV90Centrocostoswwds_10_dynamicfiltersselector3 ,
                                             short AV91Centrocostoswwds_11_dynamicfiltersoperator3 ,
                                             string AV92Centrocostoswwds_12_centrocostosnombre3 ,
                                             long AV93Centrocostoswwds_13_tfcentrocostosid ,
                                             long AV94Centrocostoswwds_14_tfcentrocostosid_to ,
                                             long AV95Centrocostoswwds_15_tfcentrocostosref ,
                                             long AV96Centrocostoswwds_16_tfcentrocostosref_to ,
                                             string AV98Centrocostoswwds_18_tfcentrocostosnombre_sel ,
                                             string AV97Centrocostoswwds_17_tfcentrocostosnombre ,
                                             decimal AV99Centrocostoswwds_19_tfcentrocostospreciofinal ,
                                             decimal AV100Centrocostoswwds_20_tfcentrocostospreciofinal_to ,
                                             decimal AV101Centrocostoswwds_21_tfcentrocostoscosto ,
                                             decimal AV102Centrocostoswwds_22_tfcentrocostoscosto_to ,
                                             decimal AV103Centrocostoswwds_23_tfcentrocostosgam ,
                                             decimal AV104Centrocostoswwds_24_tfcentrocostosgam_to ,
                                             int AV105Centrocostoswwds_25_tfcentrocostosestado_sels_Count ,
                                             int AV106Centrocostoswwds_26_tfcentrocostostiporef_sels_Count ,
                                             string A463CentroCostosNombre ,
                                             long A461CentroCostosId ,
                                             long A462CentroCostosRef ,
                                             decimal A464CentroCostosPrecioFinal ,
                                             decimal A475CentroCostosCosto ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             string AV81Centrocostoswwds_1_filterfulltext ,
                                             decimal A474CentroCostosGam )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[18];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [CentroCostosPrecioFinal] - [CentroCostosCosto] AS CentroCostosGam, [CentroCostosNombre], [CentroCostosRef], [CentroCostosId], [CentroCostosTipoRef], [CentroCostosEstado], [CentroCostosPrecioFinal], [CentroCostosCosto] FROM [CentroCostos]";
         if ( ( StringUtil.StrCmp(AV82Centrocostoswwds_2_dynamicfiltersselector1, "CENTROCOSTOSNOMBRE") == 0 ) && ( AV83Centrocostoswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Centrocostoswwds_4_centrocostosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([CentroCostosNombre]) like UPPER(@lV84Centrocostoswwds_4_centrocostosnombre1))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV82Centrocostoswwds_2_dynamicfiltersselector1, "CENTROCOSTOSNOMBRE") == 0 ) && ( AV83Centrocostoswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Centrocostoswwds_4_centrocostosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([CentroCostosNombre]) like '%' + UPPER(@lV84Centrocostoswwds_4_centrocostosnombre1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV85Centrocostoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Centrocostoswwds_6_dynamicfiltersselector2, "CENTROCOSTOSNOMBRE") == 0 ) && ( AV87Centrocostoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Centrocostoswwds_8_centrocostosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([CentroCostosNombre]) like UPPER(@lV88Centrocostoswwds_8_centrocostosnombre2))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV85Centrocostoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV86Centrocostoswwds_6_dynamicfiltersselector2, "CENTROCOSTOSNOMBRE") == 0 ) && ( AV87Centrocostoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Centrocostoswwds_8_centrocostosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([CentroCostosNombre]) like '%' + UPPER(@lV88Centrocostoswwds_8_centrocostosnombre2))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV89Centrocostoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV90Centrocostoswwds_10_dynamicfiltersselector3, "CENTROCOSTOSNOMBRE") == 0 ) && ( AV91Centrocostoswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Centrocostoswwds_12_centrocostosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([CentroCostosNombre]) like UPPER(@lV92Centrocostoswwds_12_centrocostosnombre3))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV89Centrocostoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV90Centrocostoswwds_10_dynamicfiltersselector3, "CENTROCOSTOSNOMBRE") == 0 ) && ( AV91Centrocostoswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Centrocostoswwds_12_centrocostosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([CentroCostosNombre]) like '%' + UPPER(@lV92Centrocostoswwds_12_centrocostosnombre3))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV93Centrocostoswwds_13_tfcentrocostosid) )
         {
            AddWhere(sWhereString, "([CentroCostosId] >= @AV93Centrocostoswwds_13_tfcentrocostosid)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV94Centrocostoswwds_14_tfcentrocostosid_to) )
         {
            AddWhere(sWhereString, "([CentroCostosId] <= @AV94Centrocostoswwds_14_tfcentrocostosid_to)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! (0==AV95Centrocostoswwds_15_tfcentrocostosref) )
         {
            AddWhere(sWhereString, "([CentroCostosRef] >= @AV95Centrocostoswwds_15_tfcentrocostosref)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! (0==AV96Centrocostoswwds_16_tfcentrocostosref_to) )
         {
            AddWhere(sWhereString, "([CentroCostosRef] <= @AV96Centrocostoswwds_16_tfcentrocostosref_to)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Centrocostoswwds_18_tfcentrocostosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Centrocostoswwds_17_tfcentrocostosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([CentroCostosNombre]) like UPPER(@lV97Centrocostoswwds_17_tfcentrocostosnombre))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Centrocostoswwds_18_tfcentrocostosnombre_sel)) && ! ( StringUtil.StrCmp(AV98Centrocostoswwds_18_tfcentrocostosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([CentroCostosNombre] = @AV98Centrocostoswwds_18_tfcentrocostosnombre_sel)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV98Centrocostoswwds_18_tfcentrocostosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([CentroCostosNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV99Centrocostoswwds_19_tfcentrocostospreciofinal) )
         {
            AddWhere(sWhereString, "([CentroCostosPrecioFinal] >= @AV99Centrocostoswwds_19_tfcentrocostospreciofinal)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV100Centrocostoswwds_20_tfcentrocostospreciofinal_to) )
         {
            AddWhere(sWhereString, "([CentroCostosPrecioFinal] <= @AV100Centrocostoswwds_20_tfcentrocostospreciofinal_to)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV101Centrocostoswwds_21_tfcentrocostoscosto) )
         {
            AddWhere(sWhereString, "([CentroCostosCosto] >= @AV101Centrocostoswwds_21_tfcentrocostoscosto)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV102Centrocostoswwds_22_tfcentrocostoscosto_to) )
         {
            AddWhere(sWhereString, "([CentroCostosCosto] <= @AV102Centrocostoswwds_22_tfcentrocostoscosto_to)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV103Centrocostoswwds_23_tfcentrocostosgam) )
         {
            AddWhere(sWhereString, "(( [CentroCostosPrecioFinal] - [CentroCostosCosto]) >= @AV103Centrocostoswwds_23_tfcentrocostosgam)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV104Centrocostoswwds_24_tfcentrocostosgam_to) )
         {
            AddWhere(sWhereString, "(( [CentroCostosPrecioFinal] - [CentroCostosCosto]) <= @AV104Centrocostoswwds_24_tfcentrocostosgam_to)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( AV105Centrocostoswwds_25_tfcentrocostosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV105Centrocostoswwds_25_tfcentrocostosestado_sels, "[CentroCostosEstado] IN (", ")")+")");
         }
         if ( AV106Centrocostoswwds_26_tfcentrocostostiporef_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV106Centrocostoswwds_26_tfcentrocostostiporef_sels, "[CentroCostosTipoRef] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [CentroCostosNombre]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CentroCostosNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [CentroCostosId]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CentroCostosId] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [CentroCostosRef]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CentroCostosRef] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [CentroCostosPrecioFinal]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CentroCostosPrecioFinal] DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [CentroCostosCosto]";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CentroCostosCosto] DESC";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [CentroCostosEstado]";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CentroCostosEstado] DESC";
         }
         else if ( ( AV11OrderedBy == 7 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [CentroCostosTipoRef]";
         }
         else if ( ( AV11OrderedBy == 7 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CentroCostosTipoRef] DESC";
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
                     return conditional_P005Z2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] , (long)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (decimal)dynConstraints[25] , (decimal)dynConstraints[26] , (int)dynConstraints[27] , (int)dynConstraints[28] , (string)dynConstraints[29] , (long)dynConstraints[30] , (long)dynConstraints[31] , (decimal)dynConstraints[32] , (decimal)dynConstraints[33] , (short)dynConstraints[34] , (bool)dynConstraints[35] , (string)dynConstraints[36] , (decimal)dynConstraints[37] );
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
          Object[] prmP005Z2;
          prmP005Z2 = new Object[] {
          new ParDef("@lV84Centrocostoswwds_4_centrocostosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV84Centrocostoswwds_4_centrocostosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV88Centrocostoswwds_8_centrocostosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV88Centrocostoswwds_8_centrocostosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV92Centrocostoswwds_12_centrocostosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV92Centrocostoswwds_12_centrocostosnombre3",GXType.Char,80,0) ,
          new ParDef("@AV93Centrocostoswwds_13_tfcentrocostosid",GXType.Decimal,18,0) ,
          new ParDef("@AV94Centrocostoswwds_14_tfcentrocostosid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV95Centrocostoswwds_15_tfcentrocostosref",GXType.Decimal,18,0) ,
          new ParDef("@AV96Centrocostoswwds_16_tfcentrocostosref_to",GXType.Decimal,18,0) ,
          new ParDef("@lV97Centrocostoswwds_17_tfcentrocostosnombre",GXType.Char,80,0) ,
          new ParDef("@AV98Centrocostoswwds_18_tfcentrocostosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV99Centrocostoswwds_19_tfcentrocostospreciofinal",GXType.Decimal,18,2) ,
          new ParDef("@AV100Centrocostoswwds_20_tfcentrocostospreciofinal_to",GXType.Decimal,18,2) ,
          new ParDef("@AV101Centrocostoswwds_21_tfcentrocostoscosto",GXType.Decimal,18,2) ,
          new ParDef("@AV102Centrocostoswwds_22_tfcentrocostoscosto_to",GXType.Decimal,18,2) ,
          new ParDef("@AV103Centrocostoswwds_23_tfcentrocostosgam",GXType.Decimal,18,2) ,
          new ParDef("@AV104Centrocostoswwds_24_tfcentrocostosgam_to",GXType.Decimal,18,2)
          };
          def= new CursorDef[] {
              new CursorDef("P005Z2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Z2,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                return;
       }
    }

 }

}
