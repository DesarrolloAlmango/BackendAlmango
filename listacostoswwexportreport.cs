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
   public class listacostoswwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public listacostoswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public listacostoswwexportreport( IGxContext context )
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
         setOutputFileName("ListaCostosWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWListaCostos", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV67Pgmname));
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
               AV65Title = context.GetMessage( "Lista de Lista de Costos", "");
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
            H640( true, 0) ;
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
            H640( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV27GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "LISTACOSTOSNOMBRE") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV27GridStateDynamicFilter.gxTpr_Operator;
               AV16ListaCostosNombre1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16ListaCostosNombre1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterListaCostosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterListaCostosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV18ListaCostosNombre = AV16ListaCostosNombre1;
                  H640( false, 19) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterListaCostosNombreDescription, "")), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18ListaCostosNombre, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
               }
            }
            if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV19DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "LISTACOSTOSNOMBRE") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV27GridStateDynamicFilter.gxTpr_Operator;
                  AV22ListaCostosNombre2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ListaCostosNombre2)) )
                  {
                     if ( AV21DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterListaCostosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV21DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterListaCostosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV18ListaCostosNombre = AV22ListaCostosNombre2;
                     H640( false, 19) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterListaCostosNombreDescription, "")), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18ListaCostosNombre, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                  }
               }
               if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "LISTACOSTOSNOMBRE") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV27GridStateDynamicFilter.gxTpr_Operator;
                     AV26ListaCostosNombre3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ListaCostosNombre3)) )
                     {
                        if ( AV25DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterListaCostosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV25DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterListaCostosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV18ListaCostosNombre = AV26ListaCostosNombre3;
                        H640( false, 19) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterListaCostosNombreDescription, "")), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18ListaCostosNombre, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV33TFListaCostosId) && (0==AV34TFListaCostosId_To) ) )
         {
            H640( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Idc", ""), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV33TFListaCostosId), "ZZZZZZZZZZZZZZZZZ9")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV49TFListaCostosId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Idc", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H640( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49TFListaCostosId_To_Description, "")), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV34TFListaCostosId_To), "ZZZZZZZZZZZZZZZZZ9")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (0==AV35TFTipoCuentaId) && (0==AV36TFTipoCuentaId_To) ) )
         {
            H640( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Clasificación", ""), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV35TFTipoCuentaId), "ZZZZZZZZZZZZZZZZZ9")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV50TFTipoCuentaId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Clasificación", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H640( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50TFTipoCuentaId_To_Description, "")), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV36TFTipoCuentaId_To), "ZZZZZZZZZZZZZZZZZ9")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFTipoCuentaNombre_Sel)) )
         {
            AV53TempBoolean = (bool)(((StringUtil.StrCmp(AV38TFTipoCuentaNombre_Sel, "<#Empty#>")==0)));
            AV38TFTipoCuentaNombre_Sel = (AV53TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV38TFTipoCuentaNombre_Sel);
            H640( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFTipoCuentaNombre_Sel, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV38TFTipoCuentaNombre_Sel = (AV53TempBoolean ? "<#Empty#>" : AV38TFTipoCuentaNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFTipoCuentaNombre)) )
            {
               H640( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFTipoCuentaNombre, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFListaCostosNombre_Sel)) )
         {
            AV53TempBoolean = (bool)(((StringUtil.StrCmp(AV40TFListaCostosNombre_Sel, "<#Empty#>")==0)));
            AV40TFListaCostosNombre_Sel = (AV53TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV40TFListaCostosNombre_Sel);
            H640( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFListaCostosNombre_Sel, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV40TFListaCostosNombre_Sel = (AV53TempBoolean ? "<#Empty#>" : AV40TFListaCostosNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFListaCostosNombre)) )
            {
               H640( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFListaCostosNombre, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV41TFListaCostosValor) && (Convert.ToDecimal(0)==AV42TFListaCostosValor_To) ) )
         {
            H640( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Costo", ""), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV41TFListaCostosValor, "ZZZZZZZZZZZZZZ9.99")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV51TFListaCostosValor_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Costo", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H640( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51TFListaCostosValor_To_Description, "")), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42TFListaCostosValor_To, "ZZZZZZZZZZZZZZ9.99")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44TFListaCostosCC_Sel)) )
         {
            AV53TempBoolean = (bool)(((StringUtil.StrCmp(AV44TFListaCostosCC_Sel, "<#Empty#>")==0)));
            AV44TFListaCostosCC_Sel = (AV53TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV44TFListaCostosCC_Sel);
            H640( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Código Contable ", ""), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44TFListaCostosCC_Sel, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV44TFListaCostosCC_Sel = (AV53TempBoolean ? "<#Empty#>" : AV44TFListaCostosCC_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TFListaCostosCC)) )
            {
               H640( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Código Contable ", ""), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFListaCostosCC, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         AV47TFListaCostosEstado_Sels.FromJSonString(AV45TFListaCostosEstado_SelsJson, null);
         if ( ! ( AV47TFListaCostosEstado_Sels.Count == 0 ) )
         {
            AV54i = 1;
            AV70GXV1 = 1;
            while ( AV70GXV1 <= AV47TFListaCostosEstado_Sels.Count )
            {
               AV48TFListaCostosEstado_Sel = AV47TFListaCostosEstado_Sels.GetString(AV70GXV1);
               if ( AV54i == 1 )
               {
                  AV46TFListaCostosEstado_SelDscs = "";
               }
               else
               {
                  AV46TFListaCostosEstado_SelDscs += ", ";
               }
               AV52FilterTFListaCostosEstado_SelValueDescription = "";
               if ( StringUtil.StrCmp(StringUtil.Trim( AV48TFListaCostosEstado_Sel), "HAB") == 0 )
               {
                  AV52FilterTFListaCostosEstado_SelValueDescription = context.GetMessage( "Habilitado", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV48TFListaCostosEstado_Sel), "DES") == 0 )
               {
                  AV52FilterTFListaCostosEstado_SelValueDescription = context.GetMessage( "Deshabilitado", "");
               }
               AV46TFListaCostosEstado_SelDscs += AV52FilterTFListaCostosEstado_SelValueDescription;
               AV54i = (long)(AV54i+1);
               AV70GXV1 = (int)(AV70GXV1+1);
            }
            H640( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46TFListaCostosEstado_SelDscs, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H640( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H640( false, 36) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Idc", ""), 30, Gx_line+10, 96, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Clasificación", ""), 100, Gx_line+10, 166, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 170, Gx_line+10, 302, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 306, Gx_line+10, 440, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Costo", ""), 444, Gx_line+10, 511, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Código Contable ", ""), 515, Gx_line+10, 649, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 653, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV72Listacostoswwds_1_filterfulltext = AV13FilterFullText;
         AV73Listacostoswwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV74Listacostoswwds_3_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV75Listacostoswwds_4_listacostosnombre1 = AV16ListaCostosNombre1;
         AV76Listacostoswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV77Listacostoswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV78Listacostoswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV79Listacostoswwds_8_listacostosnombre2 = AV22ListaCostosNombre2;
         AV80Listacostoswwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV81Listacostoswwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV82Listacostoswwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV83Listacostoswwds_12_listacostosnombre3 = AV26ListaCostosNombre3;
         AV84Listacostoswwds_13_tflistacostosid = AV33TFListaCostosId;
         AV85Listacostoswwds_14_tflistacostosid_to = AV34TFListaCostosId_To;
         AV86Listacostoswwds_15_tftipocuentaid = AV35TFTipoCuentaId;
         AV87Listacostoswwds_16_tftipocuentaid_to = AV36TFTipoCuentaId_To;
         AV88Listacostoswwds_17_tftipocuentanombre = AV37TFTipoCuentaNombre;
         AV89Listacostoswwds_18_tftipocuentanombre_sel = AV38TFTipoCuentaNombre_Sel;
         AV90Listacostoswwds_19_tflistacostosnombre = AV39TFListaCostosNombre;
         AV91Listacostoswwds_20_tflistacostosnombre_sel = AV40TFListaCostosNombre_Sel;
         AV92Listacostoswwds_21_tflistacostosvalor = AV41TFListaCostosValor;
         AV93Listacostoswwds_22_tflistacostosvalor_to = AV42TFListaCostosValor_To;
         AV94Listacostoswwds_23_tflistacostoscc = AV43TFListaCostosCC;
         AV95Listacostoswwds_24_tflistacostoscc_sel = AV44TFListaCostosCC_Sel;
         AV96Listacostoswwds_25_tflistacostosestado_sels = AV47TFListaCostosEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A486ListaCostosEstado ,
                                              AV96Listacostoswwds_25_tflistacostosestado_sels ,
                                              AV73Listacostoswwds_2_dynamicfiltersselector1 ,
                                              AV74Listacostoswwds_3_dynamicfiltersoperator1 ,
                                              AV75Listacostoswwds_4_listacostosnombre1 ,
                                              AV76Listacostoswwds_5_dynamicfiltersenabled2 ,
                                              AV77Listacostoswwds_6_dynamicfiltersselector2 ,
                                              AV78Listacostoswwds_7_dynamicfiltersoperator2 ,
                                              AV79Listacostoswwds_8_listacostosnombre2 ,
                                              AV80Listacostoswwds_9_dynamicfiltersenabled3 ,
                                              AV81Listacostoswwds_10_dynamicfiltersselector3 ,
                                              AV82Listacostoswwds_11_dynamicfiltersoperator3 ,
                                              AV83Listacostoswwds_12_listacostosnombre3 ,
                                              AV84Listacostoswwds_13_tflistacostosid ,
                                              AV85Listacostoswwds_14_tflistacostosid_to ,
                                              AV86Listacostoswwds_15_tftipocuentaid ,
                                              AV87Listacostoswwds_16_tftipocuentaid_to ,
                                              AV89Listacostoswwds_18_tftipocuentanombre_sel ,
                                              AV88Listacostoswwds_17_tftipocuentanombre ,
                                              AV91Listacostoswwds_20_tflistacostosnombre_sel ,
                                              AV90Listacostoswwds_19_tflistacostosnombre ,
                                              AV92Listacostoswwds_21_tflistacostosvalor ,
                                              AV93Listacostoswwds_22_tflistacostosvalor_to ,
                                              AV95Listacostoswwds_24_tflistacostoscc_sel ,
                                              AV94Listacostoswwds_23_tflistacostoscc ,
                                              AV96Listacostoswwds_25_tflistacostosestado_sels.Count ,
                                              A460ListaCostosNombre ,
                                              A459ListaCostosId ,
                                              A483TipoCuentaId ,
                                              A484TipoCuentaNombre ,
                                              A471ListaCostosValor ,
                                              A485ListaCostosCC ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              AV72Listacostoswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV75Listacostoswwds_4_listacostosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV75Listacostoswwds_4_listacostosnombre1), 80, "%");
         lV75Listacostoswwds_4_listacostosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV75Listacostoswwds_4_listacostosnombre1), 80, "%");
         lV79Listacostoswwds_8_listacostosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV79Listacostoswwds_8_listacostosnombre2), 80, "%");
         lV79Listacostoswwds_8_listacostosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV79Listacostoswwds_8_listacostosnombre2), 80, "%");
         lV83Listacostoswwds_12_listacostosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV83Listacostoswwds_12_listacostosnombre3), 80, "%");
         lV83Listacostoswwds_12_listacostosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV83Listacostoswwds_12_listacostosnombre3), 80, "%");
         lV88Listacostoswwds_17_tftipocuentanombre = StringUtil.PadR( StringUtil.RTrim( AV88Listacostoswwds_17_tftipocuentanombre), 120, "%");
         lV90Listacostoswwds_19_tflistacostosnombre = StringUtil.PadR( StringUtil.RTrim( AV90Listacostoswwds_19_tflistacostosnombre), 80, "%");
         lV94Listacostoswwds_23_tflistacostoscc = StringUtil.PadR( StringUtil.RTrim( AV94Listacostoswwds_23_tflistacostoscc), 35, "%");
         /* Using cursor P00642 */
         pr_default.execute(0, new Object[] {lV75Listacostoswwds_4_listacostosnombre1, lV75Listacostoswwds_4_listacostosnombre1, lV79Listacostoswwds_8_listacostosnombre2, lV79Listacostoswwds_8_listacostosnombre2, lV83Listacostoswwds_12_listacostosnombre3, lV83Listacostoswwds_12_listacostosnombre3, AV84Listacostoswwds_13_tflistacostosid, AV85Listacostoswwds_14_tflistacostosid_to, AV86Listacostoswwds_15_tftipocuentaid, AV87Listacostoswwds_16_tftipocuentaid_to, lV88Listacostoswwds_17_tftipocuentanombre, AV89Listacostoswwds_18_tftipocuentanombre_sel, lV90Listacostoswwds_19_tflistacostosnombre, AV91Listacostoswwds_20_tflistacostosnombre_sel, AV92Listacostoswwds_21_tflistacostosvalor, AV93Listacostoswwds_22_tflistacostosvalor_to, lV94Listacostoswwds_23_tflistacostoscc, AV95Listacostoswwds_24_tflistacostoscc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A485ListaCostosCC = P00642_A485ListaCostosCC[0];
            n485ListaCostosCC = P00642_n485ListaCostosCC[0];
            A471ListaCostosValor = P00642_A471ListaCostosValor[0];
            A460ListaCostosNombre = P00642_A460ListaCostosNombre[0];
            A484TipoCuentaNombre = P00642_A484TipoCuentaNombre[0];
            A483TipoCuentaId = P00642_A483TipoCuentaId[0];
            n483TipoCuentaId = P00642_n483TipoCuentaId[0];
            A459ListaCostosId = P00642_A459ListaCostosId[0];
            A486ListaCostosEstado = P00642_A486ListaCostosEstado[0];
            A484TipoCuentaNombre = P00642_A484TipoCuentaNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Listacostoswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A459ListaCostosId), 18, 0) , StringUtil.PadR( "%" + AV72Listacostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A483TipoCuentaId), 18, 0) , StringUtil.PadR( "%" + AV72Listacostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A484TipoCuentaNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV72Listacostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A460ListaCostosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV72Listacostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A471ListaCostosValor, 18, 2) , StringUtil.PadR( "%" + AV72Listacostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A485ListaCostosCC) , StringUtil.PadR( "%" + StringUtil.Upper( AV72Listacostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Listacostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A486ListaCostosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Listacostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A486ListaCostosEstado, "DES") == 0 ) ) ) )
            {
               AV28ListaCostosEstadoDescription = "";
               if ( StringUtil.StrCmp(StringUtil.Trim( A486ListaCostosEstado), "HAB") == 0 )
               {
                  AV28ListaCostosEstadoDescription = context.GetMessage( "Habilitado", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( A486ListaCostosEstado), "DES") == 0 )
               {
                  AV28ListaCostosEstadoDescription = context.GetMessage( "Deshabilitado", "");
               }
               /* Execute user subroutine: 'BEFOREPRINTLINE' */
               S144 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               H640( false, 35) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A459ListaCostosId), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 96, Gx_line+24, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A483TipoCuentaId), "ZZZZZZZZZZZZZZZZZ9")), 100, Gx_line+10, 166, Gx_line+24, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A484TipoCuentaNombre, "")), 170, Gx_line+10, 302, Gx_line+24, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A460ListaCostosNombre, "")), 306, Gx_line+10, 440, Gx_line+24, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A471ListaCostosValor, "ZZZZZZZZZZZZZZ9.99")), 444, Gx_line+10, 511, Gx_line+24, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A485ListaCostosCC, "")), 515, Gx_line+10, 649, Gx_line+24, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28ListaCostosEstadoDescription, "")), 653, Gx_line+10, 787, Gx_line+24, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV29Session.Get("ListaCostosWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ListaCostosWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("ListaCostosWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV31GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV31GridState.gxTpr_Ordereddsc;
         AV97GXV2 = 1;
         while ( AV97GXV2 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV97GXV2));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFLISTACOSTOSID") == 0 )
            {
               AV33TFListaCostosId = (long)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV34TFListaCostosId_To = (long)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFTIPOCUENTAID") == 0 )
            {
               AV35TFTipoCuentaId = (long)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV36TFTipoCuentaId_To = (long)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFTIPOCUENTANOMBRE") == 0 )
            {
               AV37TFTipoCuentaNombre = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFTIPOCUENTANOMBRE_SEL") == 0 )
            {
               AV38TFTipoCuentaNombre_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFLISTACOSTOSNOMBRE") == 0 )
            {
               AV39TFListaCostosNombre = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFLISTACOSTOSNOMBRE_SEL") == 0 )
            {
               AV40TFListaCostosNombre_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFLISTACOSTOSVALOR") == 0 )
            {
               AV41TFListaCostosValor = NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, ".");
               AV42TFListaCostosValor_To = NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFLISTACOSTOSCC") == 0 )
            {
               AV43TFListaCostosCC = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFLISTACOSTOSCC_SEL") == 0 )
            {
               AV44TFListaCostosCC_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFLISTACOSTOSESTADO_SEL") == 0 )
            {
               AV45TFListaCostosEstado_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV47TFListaCostosEstado_Sels.FromJSonString(AV45TFListaCostosEstado_SelsJson, null);
            }
            AV97GXV2 = (int)(AV97GXV2+1);
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

      protected void H640( bool bFoot ,
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
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+39, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63PageInfo, "")), 30, Gx_line+15, 409, Gx_line+29, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60DateInfo, "")), 409, Gx_line+15, 789, Gx_line+29, 2, 0, 0, 0) ;
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
               AV58AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV64Phone = "+1 550 8923";
               AV62Mail = "info@mail.com";
               AV66Website = "http://www.web.com";
               AV55AddressLine1 = "French Boulevard 2859";
               AV56AddressLine2 = "Downtown";
               AV57AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+107, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58AppName, "")), 30, Gx_line+30, 283, Gx_line+44, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65Title, "")), 30, Gx_line+44, 283, Gx_line+77, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64Phone, "")), 283, Gx_line+30, 536, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62Mail, "")), 283, Gx_line+45, 536, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66Website, "")), 283, Gx_line+60, 536, Gx_line+77, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56AddressLine2, "")), 536, Gx_line+45, 789, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57AddressLine3, "")), 536, Gx_line+60, 789, Gx_line+77, 2, 0, 0, 0) ;
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
         AV67Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV65Title = "";
         AV13FilterFullText = "";
         AV31GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV16ListaCostosNombre1 = "";
         AV17FilterListaCostosNombreDescription = "";
         AV18ListaCostosNombre = "";
         AV20DynamicFiltersSelector2 = "";
         AV22ListaCostosNombre2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV26ListaCostosNombre3 = "";
         AV49TFListaCostosId_To_Description = "";
         AV50TFTipoCuentaId_To_Description = "";
         AV38TFTipoCuentaNombre_Sel = "";
         AV37TFTipoCuentaNombre = "";
         AV40TFListaCostosNombre_Sel = "";
         AV39TFListaCostosNombre = "";
         AV51TFListaCostosValor_To_Description = "";
         AV44TFListaCostosCC_Sel = "";
         AV43TFListaCostosCC = "";
         AV47TFListaCostosEstado_Sels = new GxSimpleCollection<string>();
         AV45TFListaCostosEstado_SelsJson = "";
         AV48TFListaCostosEstado_Sel = "";
         AV46TFListaCostosEstado_SelDscs = "";
         AV52FilterTFListaCostosEstado_SelValueDescription = "";
         AV72Listacostoswwds_1_filterfulltext = "";
         AV73Listacostoswwds_2_dynamicfiltersselector1 = "";
         AV75Listacostoswwds_4_listacostosnombre1 = "";
         AV77Listacostoswwds_6_dynamicfiltersselector2 = "";
         AV79Listacostoswwds_8_listacostosnombre2 = "";
         AV81Listacostoswwds_10_dynamicfiltersselector3 = "";
         AV83Listacostoswwds_12_listacostosnombre3 = "";
         AV88Listacostoswwds_17_tftipocuentanombre = "";
         AV89Listacostoswwds_18_tftipocuentanombre_sel = "";
         AV90Listacostoswwds_19_tflistacostosnombre = "";
         AV91Listacostoswwds_20_tflistacostosnombre_sel = "";
         AV94Listacostoswwds_23_tflistacostoscc = "";
         AV95Listacostoswwds_24_tflistacostoscc_sel = "";
         AV96Listacostoswwds_25_tflistacostosestado_sels = new GxSimpleCollection<string>();
         lV75Listacostoswwds_4_listacostosnombre1 = "";
         lV79Listacostoswwds_8_listacostosnombre2 = "";
         lV83Listacostoswwds_12_listacostosnombre3 = "";
         lV88Listacostoswwds_17_tftipocuentanombre = "";
         lV90Listacostoswwds_19_tflistacostosnombre = "";
         lV94Listacostoswwds_23_tflistacostoscc = "";
         A486ListaCostosEstado = "";
         A460ListaCostosNombre = "";
         A484TipoCuentaNombre = "";
         A485ListaCostosCC = "";
         P00642_A485ListaCostosCC = new string[] {""} ;
         P00642_n485ListaCostosCC = new bool[] {false} ;
         P00642_A471ListaCostosValor = new decimal[1] ;
         P00642_A460ListaCostosNombre = new string[] {""} ;
         P00642_A484TipoCuentaNombre = new string[] {""} ;
         P00642_A483TipoCuentaId = new long[1] ;
         P00642_n483TipoCuentaId = new bool[] {false} ;
         P00642_A459ListaCostosId = new long[1] ;
         P00642_A486ListaCostosEstado = new string[] {""} ;
         AV28ListaCostosEstadoDescription = "";
         AV29Session = context.GetSession();
         AV32GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.listacostoswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00642_A485ListaCostosCC, P00642_n485ListaCostosCC, P00642_A471ListaCostosValor, P00642_A460ListaCostosNombre, P00642_A484TipoCuentaNombre, P00642_A483TipoCuentaId, P00642_n483TipoCuentaId, P00642_A459ListaCostosId, P00642_A486ListaCostosEstado
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV67Pgmname = "ListaCostosWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV67Pgmname = "ListaCostosWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV15DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV25DynamicFiltersOperator3 ;
      private short AV74Listacostoswwds_3_dynamicfiltersoperator1 ;
      private short AV78Listacostoswwds_7_dynamicfiltersoperator2 ;
      private short AV82Listacostoswwds_11_dynamicfiltersoperator3 ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV70GXV1 ;
      private int AV96Listacostoswwds_25_tflistacostosestado_sels_Count ;
      private int AV97GXV2 ;
      private long AV33TFListaCostosId ;
      private long AV34TFListaCostosId_To ;
      private long AV35TFTipoCuentaId ;
      private long AV36TFTipoCuentaId_To ;
      private long AV54i ;
      private long AV84Listacostoswwds_13_tflistacostosid ;
      private long AV85Listacostoswwds_14_tflistacostosid_to ;
      private long AV86Listacostoswwds_15_tftipocuentaid ;
      private long AV87Listacostoswwds_16_tftipocuentaid_to ;
      private long A459ListaCostosId ;
      private long A483TipoCuentaId ;
      private decimal AV41TFListaCostosValor ;
      private decimal AV42TFListaCostosValor_To ;
      private decimal AV92Listacostoswwds_21_tflistacostosvalor ;
      private decimal AV93Listacostoswwds_22_tflistacostosvalor_to ;
      private decimal A471ListaCostosValor ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV67Pgmname ;
      private string GXEncryptionTmp ;
      private string AV16ListaCostosNombre1 ;
      private string AV18ListaCostosNombre ;
      private string AV22ListaCostosNombre2 ;
      private string AV26ListaCostosNombre3 ;
      private string AV38TFTipoCuentaNombre_Sel ;
      private string AV37TFTipoCuentaNombre ;
      private string AV40TFListaCostosNombre_Sel ;
      private string AV39TFListaCostosNombre ;
      private string AV44TFListaCostosCC_Sel ;
      private string AV43TFListaCostosCC ;
      private string AV48TFListaCostosEstado_Sel ;
      private string AV75Listacostoswwds_4_listacostosnombre1 ;
      private string AV79Listacostoswwds_8_listacostosnombre2 ;
      private string AV83Listacostoswwds_12_listacostosnombre3 ;
      private string AV88Listacostoswwds_17_tftipocuentanombre ;
      private string AV89Listacostoswwds_18_tftipocuentanombre_sel ;
      private string AV90Listacostoswwds_19_tflistacostosnombre ;
      private string AV91Listacostoswwds_20_tflistacostosnombre_sel ;
      private string AV94Listacostoswwds_23_tflistacostoscc ;
      private string AV95Listacostoswwds_24_tflistacostoscc_sel ;
      private string lV75Listacostoswwds_4_listacostosnombre1 ;
      private string lV79Listacostoswwds_8_listacostosnombre2 ;
      private string lV83Listacostoswwds_12_listacostosnombre3 ;
      private string lV88Listacostoswwds_17_tftipocuentanombre ;
      private string lV90Listacostoswwds_19_tflistacostosnombre ;
      private string lV94Listacostoswwds_23_tflistacostoscc ;
      private string A486ListaCostosEstado ;
      private string A460ListaCostosNombre ;
      private string A484TipoCuentaNombre ;
      private string A485ListaCostosCC ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV53TempBoolean ;
      private bool AV76Listacostoswwds_5_dynamicfiltersenabled2 ;
      private bool AV80Listacostoswwds_9_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private bool n485ListaCostosCC ;
      private bool n483TipoCuentaId ;
      private string AV45TFListaCostosEstado_SelsJson ;
      private string AV65Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV17FilterListaCostosNombreDescription ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV49TFListaCostosId_To_Description ;
      private string AV50TFTipoCuentaId_To_Description ;
      private string AV51TFListaCostosValor_To_Description ;
      private string AV46TFListaCostosEstado_SelDscs ;
      private string AV52FilterTFListaCostosEstado_SelValueDescription ;
      private string AV72Listacostoswwds_1_filterfulltext ;
      private string AV73Listacostoswwds_2_dynamicfiltersselector1 ;
      private string AV77Listacostoswwds_6_dynamicfiltersselector2 ;
      private string AV81Listacostoswwds_10_dynamicfiltersselector3 ;
      private string AV28ListaCostosEstadoDescription ;
      private string AV63PageInfo ;
      private string AV60DateInfo ;
      private string AV58AppName ;
      private string AV64Phone ;
      private string AV62Mail ;
      private string AV66Website ;
      private string AV55AddressLine1 ;
      private string AV56AddressLine2 ;
      private string AV57AddressLine3 ;
      private IGxSession AV29Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV31GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV47TFListaCostosEstado_Sels ;
      private GxSimpleCollection<string> AV96Listacostoswwds_25_tflistacostosestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00642_A485ListaCostosCC ;
      private bool[] P00642_n485ListaCostosCC ;
      private decimal[] P00642_A471ListaCostosValor ;
      private string[] P00642_A460ListaCostosNombre ;
      private string[] P00642_A484TipoCuentaNombre ;
      private long[] P00642_A483TipoCuentaId ;
      private bool[] P00642_n483TipoCuentaId ;
      private long[] P00642_A459ListaCostosId ;
      private string[] P00642_A486ListaCostosEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
   }

   public class listacostoswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00642( IGxContext context ,
                                             string A486ListaCostosEstado ,
                                             GxSimpleCollection<string> AV96Listacostoswwds_25_tflistacostosestado_sels ,
                                             string AV73Listacostoswwds_2_dynamicfiltersselector1 ,
                                             short AV74Listacostoswwds_3_dynamicfiltersoperator1 ,
                                             string AV75Listacostoswwds_4_listacostosnombre1 ,
                                             bool AV76Listacostoswwds_5_dynamicfiltersenabled2 ,
                                             string AV77Listacostoswwds_6_dynamicfiltersselector2 ,
                                             short AV78Listacostoswwds_7_dynamicfiltersoperator2 ,
                                             string AV79Listacostoswwds_8_listacostosnombre2 ,
                                             bool AV80Listacostoswwds_9_dynamicfiltersenabled3 ,
                                             string AV81Listacostoswwds_10_dynamicfiltersselector3 ,
                                             short AV82Listacostoswwds_11_dynamicfiltersoperator3 ,
                                             string AV83Listacostoswwds_12_listacostosnombre3 ,
                                             long AV84Listacostoswwds_13_tflistacostosid ,
                                             long AV85Listacostoswwds_14_tflistacostosid_to ,
                                             long AV86Listacostoswwds_15_tftipocuentaid ,
                                             long AV87Listacostoswwds_16_tftipocuentaid_to ,
                                             string AV89Listacostoswwds_18_tftipocuentanombre_sel ,
                                             string AV88Listacostoswwds_17_tftipocuentanombre ,
                                             string AV91Listacostoswwds_20_tflistacostosnombre_sel ,
                                             string AV90Listacostoswwds_19_tflistacostosnombre ,
                                             decimal AV92Listacostoswwds_21_tflistacostosvalor ,
                                             decimal AV93Listacostoswwds_22_tflistacostosvalor_to ,
                                             string AV95Listacostoswwds_24_tflistacostoscc_sel ,
                                             string AV94Listacostoswwds_23_tflistacostoscc ,
                                             int AV96Listacostoswwds_25_tflistacostosestado_sels_Count ,
                                             string A460ListaCostosNombre ,
                                             long A459ListaCostosId ,
                                             long A483TipoCuentaId ,
                                             string A484TipoCuentaNombre ,
                                             decimal A471ListaCostosValor ,
                                             string A485ListaCostosCC ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             string AV72Listacostoswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[18];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[ListaCostosCC], T1.[ListaCostosValor], T1.[ListaCostosNombre], T2.[TipoCuentaNombre], T1.[TipoCuentaId], T1.[ListaCostosId], T1.[ListaCostosEstado] FROM ([ListaCostos] T1 LEFT JOIN [TipoCuenta] T2 ON T2.[TipoCuentaId] = T1.[TipoCuentaId])";
         if ( ( StringUtil.StrCmp(AV73Listacostoswwds_2_dynamicfiltersselector1, "LISTACOSTOSNOMBRE") == 0 ) && ( AV74Listacostoswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Listacostoswwds_4_listacostosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like UPPER(@lV75Listacostoswwds_4_listacostosnombre1))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Listacostoswwds_2_dynamicfiltersselector1, "LISTACOSTOSNOMBRE") == 0 ) && ( AV74Listacostoswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Listacostoswwds_4_listacostosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like '%' + UPPER(@lV75Listacostoswwds_4_listacostosnombre1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV76Listacostoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Listacostoswwds_6_dynamicfiltersselector2, "LISTACOSTOSNOMBRE") == 0 ) && ( AV78Listacostoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Listacostoswwds_8_listacostosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like UPPER(@lV79Listacostoswwds_8_listacostosnombre2))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV76Listacostoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Listacostoswwds_6_dynamicfiltersselector2, "LISTACOSTOSNOMBRE") == 0 ) && ( AV78Listacostoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Listacostoswwds_8_listacostosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like '%' + UPPER(@lV79Listacostoswwds_8_listacostosnombre2))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV80Listacostoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Listacostoswwds_10_dynamicfiltersselector3, "LISTACOSTOSNOMBRE") == 0 ) && ( AV82Listacostoswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Listacostoswwds_12_listacostosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like UPPER(@lV83Listacostoswwds_12_listacostosnombre3))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV80Listacostoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Listacostoswwds_10_dynamicfiltersselector3, "LISTACOSTOSNOMBRE") == 0 ) && ( AV82Listacostoswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Listacostoswwds_12_listacostosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like '%' + UPPER(@lV83Listacostoswwds_12_listacostosnombre3))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV84Listacostoswwds_13_tflistacostosid) )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosId] >= @AV84Listacostoswwds_13_tflistacostosid)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV85Listacostoswwds_14_tflistacostosid_to) )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosId] <= @AV85Listacostoswwds_14_tflistacostosid_to)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! (0==AV86Listacostoswwds_15_tftipocuentaid) )
         {
            AddWhere(sWhereString, "(T1.[TipoCuentaId] >= @AV86Listacostoswwds_15_tftipocuentaid)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! (0==AV87Listacostoswwds_16_tftipocuentaid_to) )
         {
            AddWhere(sWhereString, "(T1.[TipoCuentaId] <= @AV87Listacostoswwds_16_tftipocuentaid_to)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Listacostoswwds_18_tftipocuentanombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Listacostoswwds_17_tftipocuentanombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TipoCuentaNombre]) like UPPER(@lV88Listacostoswwds_17_tftipocuentanombre))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Listacostoswwds_18_tftipocuentanombre_sel)) && ! ( StringUtil.StrCmp(AV89Listacostoswwds_18_tftipocuentanombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[TipoCuentaNombre] = @AV89Listacostoswwds_18_tftipocuentanombre_sel)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV89Listacostoswwds_18_tftipocuentanombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[TipoCuentaNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV91Listacostoswwds_20_tflistacostosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Listacostoswwds_19_tflistacostosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like UPPER(@lV90Listacostoswwds_19_tflistacostosnombre))");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Listacostoswwds_20_tflistacostosnombre_sel)) && ! ( StringUtil.StrCmp(AV91Listacostoswwds_20_tflistacostosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosNombre] = @AV91Listacostoswwds_20_tflistacostosnombre_sel)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( StringUtil.StrCmp(AV91Listacostoswwds_20_tflistacostosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ListaCostosNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV92Listacostoswwds_21_tflistacostosvalor) )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosValor] >= @AV92Listacostoswwds_21_tflistacostosvalor)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV93Listacostoswwds_22_tflistacostosvalor_to) )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosValor] <= @AV93Listacostoswwds_22_tflistacostosvalor_to)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV95Listacostoswwds_24_tflistacostoscc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Listacostoswwds_23_tflistacostoscc)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosCC]) like UPPER(@lV94Listacostoswwds_23_tflistacostoscc))");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Listacostoswwds_24_tflistacostoscc_sel)) && ! ( StringUtil.StrCmp(AV95Listacostoswwds_24_tflistacostoscc_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosCC] = @AV95Listacostoswwds_24_tflistacostoscc_sel)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( StringUtil.StrCmp(AV95Listacostoswwds_24_tflistacostoscc_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosCC] IS NULL or (T1.[ListaCostosCC] = ''))");
         }
         if ( AV96Listacostoswwds_25_tflistacostosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV96Listacostoswwds_25_tflistacostosestado_sels, "T1.[ListaCostosEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosNombre]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[TipoCuentaId]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[TipoCuentaId] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[TipoCuentaNombre]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[TipoCuentaNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosValor]";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosValor] DESC";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosCC]";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosCC] DESC";
         }
         else if ( ( AV11OrderedBy == 7 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosEstado]";
         }
         else if ( ( AV11OrderedBy == 7 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosEstado] DESC";
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
                     return conditional_P00642(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (short)dynConstraints[32] , (bool)dynConstraints[33] , (string)dynConstraints[34] );
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
          Object[] prmP00642;
          prmP00642 = new Object[] {
          new ParDef("@lV75Listacostoswwds_4_listacostosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV75Listacostoswwds_4_listacostosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV79Listacostoswwds_8_listacostosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV79Listacostoswwds_8_listacostosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV83Listacostoswwds_12_listacostosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV83Listacostoswwds_12_listacostosnombre3",GXType.Char,80,0) ,
          new ParDef("@AV84Listacostoswwds_13_tflistacostosid",GXType.Decimal,18,0) ,
          new ParDef("@AV85Listacostoswwds_14_tflistacostosid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV86Listacostoswwds_15_tftipocuentaid",GXType.Decimal,18,0) ,
          new ParDef("@AV87Listacostoswwds_16_tftipocuentaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV88Listacostoswwds_17_tftipocuentanombre",GXType.Char,120,0) ,
          new ParDef("@AV89Listacostoswwds_18_tftipocuentanombre_sel",GXType.NChar,120,0) ,
          new ParDef("@lV90Listacostoswwds_19_tflistacostosnombre",GXType.Char,80,0) ,
          new ParDef("@AV91Listacostoswwds_20_tflistacostosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV92Listacostoswwds_21_tflistacostosvalor",GXType.Decimal,18,2) ,
          new ParDef("@AV93Listacostoswwds_22_tflistacostosvalor_to",GXType.Decimal,18,2) ,
          new ParDef("@lV94Listacostoswwds_23_tflistacostoscc",GXType.Char,35,0) ,
          new ParDef("@AV95Listacostoswwds_24_tflistacostoscc_sel",GXType.NChar,35,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00642", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00642,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 35);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 80);
                ((string[]) buf[4])[0] = rslt.getString(4, 120);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((long[]) buf[7])[0] = rslt.getLong(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 3);
                return;
       }
    }

 }

}
