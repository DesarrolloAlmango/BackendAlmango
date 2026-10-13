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
   public class listawwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public listawwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public listawwexportreport( IGxContext context )
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
         setOutputFileName("ListaWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWLista", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV63Pgmname));
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
               AV61Title = context.GetMessage( "Lista de Lista", "");
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
            H7C0( true, 0) ;
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
            H7C0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 150, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 150, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV27GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "LISTANOMBRE") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV27GridStateDynamicFilter.gxTpr_Operator;
               AV16ListaNombre1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16ListaNombre1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterListaNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterListaNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV18ListaNombre = AV16ListaNombre1;
                  H7C0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterListaNombreDescription, "")), 25, Gx_line+0, 150, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18ListaNombre, "")), 150, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV19DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "LISTANOMBRE") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV27GridStateDynamicFilter.gxTpr_Operator;
                  AV22ListaNombre2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ListaNombre2)) )
                  {
                     if ( AV21DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterListaNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV21DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterListaNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV18ListaNombre = AV22ListaNombre2;
                     H7C0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterListaNombreDescription, "")), 25, Gx_line+0, 150, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18ListaNombre, "")), 150, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "LISTANOMBRE") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV27GridStateDynamicFilter.gxTpr_Operator;
                     AV26ListaNombre3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ListaNombre3)) )
                     {
                        if ( AV25DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterListaNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV25DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterListaNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV18ListaNombre = AV26ListaNombre3;
                        H7C0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterListaNombreDescription, "")), 25, Gx_line+0, 150, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18ListaNombre, "")), 150, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV34TFListaid) && (0==AV35TFListaid_To) ) )
         {
            H7C0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Listaid", ""), 25, Gx_line+0, 150, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV34TFListaid), "ZZZZZZZZZZZZZZZZZ9")), 150, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV46TFListaid_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Listaid", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H7C0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46TFListaid_To_Description, "")), 25, Gx_line+0, 150, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV35TFListaid_To), "ZZZZZZZZZZZZZZZZZ9")), 150, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFListaNombre_Sel)) )
         {
            AV49TempBoolean = (bool)(((StringUtil.StrCmp(AV37TFListaNombre_Sel, "<#Empty#>")==0)));
            AV37TFListaNombre_Sel = (AV49TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV37TFListaNombre_Sel);
            H7C0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 150, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFListaNombre_Sel, "")), 150, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV37TFListaNombre_Sel = (AV49TempBoolean ? "<#Empty#>" : AV37TFListaNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFListaNombre)) )
            {
               H7C0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 150, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFListaNombre, "")), 150, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV40TFListaTipo_Sels.FromJSonString(AV38TFListaTipo_SelsJson, null);
         if ( ! ( AV40TFListaTipo_Sels.Count == 0 ) )
         {
            AV50i = 1;
            AV66GXV1 = 1;
            while ( AV66GXV1 <= AV40TFListaTipo_Sels.Count )
            {
               AV41TFListaTipo_Sel = AV40TFListaTipo_Sels.GetString(AV66GXV1);
               if ( AV50i == 1 )
               {
                  AV39TFListaTipo_SelDscs = "";
               }
               else
               {
                  AV39TFListaTipo_SelDscs += ", ";
               }
               AV47FilterTFListaTipo_SelValueDescription = context.GetMessage( gxdomainlistatipoenum.getDescription(context,AV41TFListaTipo_Sel), "");
               AV39TFListaTipo_SelDscs += AV47FilterTFListaTipo_SelValueDescription;
               AV50i = (long)(AV50i+1);
               AV66GXV1 = (int)(AV66GXV1+1);
            }
            H7C0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Tipo", ""), 25, Gx_line+0, 150, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFListaTipo_SelDscs, "")), 150, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         AV44TFListaEstado_Sels.FromJSonString(AV42TFListaEstado_SelsJson, null);
         if ( ! ( AV44TFListaEstado_Sels.Count == 0 ) )
         {
            AV50i = 1;
            AV67GXV2 = 1;
            while ( AV67GXV2 <= AV44TFListaEstado_Sels.Count )
            {
               AV45TFListaEstado_Sel = AV44TFListaEstado_Sels.GetString(AV67GXV2);
               if ( AV50i == 1 )
               {
                  AV43TFListaEstado_SelDscs = "";
               }
               else
               {
                  AV43TFListaEstado_SelDscs += ", ";
               }
               AV48FilterTFListaEstado_SelValueDescription = context.GetMessage( gxdomainestadoenum.getDescription(context,AV45TFListaEstado_Sel), "");
               AV43TFListaEstado_SelDscs += AV48FilterTFListaEstado_SelValueDescription;
               AV50i = (long)(AV50i+1);
               AV67GXV2 = (int)(AV67GXV2+1);
            }
            H7C0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 25, Gx_line+0, 150, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFListaEstado_SelDscs, "")), 150, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H7C0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H7C0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Listaid", ""), 30, Gx_line+10, 136, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 140, Gx_line+10, 352, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Tipo", ""), 356, Gx_line+10, 569, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 573, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV69Listawwds_1_filterfulltext = AV13FilterFullText;
         AV70Listawwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV71Listawwds_3_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV72Listawwds_4_listanombre1 = AV16ListaNombre1;
         AV73Listawwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV74Listawwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV75Listawwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV76Listawwds_8_listanombre2 = AV22ListaNombre2;
         AV77Listawwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV78Listawwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV79Listawwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV80Listawwds_12_listanombre3 = AV26ListaNombre3;
         AV81Listawwds_13_tflistaid = AV34TFListaid;
         AV82Listawwds_14_tflistaid_to = AV35TFListaid_To;
         AV83Listawwds_15_tflistanombre = AV36TFListaNombre;
         AV84Listawwds_16_tflistanombre_sel = AV37TFListaNombre_Sel;
         AV85Listawwds_17_tflistatipo_sels = AV40TFListaTipo_Sels;
         AV86Listawwds_18_tflistaestado_sels = AV44TFListaEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A591ListaTipo ,
                                              AV85Listawwds_17_tflistatipo_sels ,
                                              A593ListaEstado ,
                                              AV86Listawwds_18_tflistaestado_sels ,
                                              AV70Listawwds_2_dynamicfiltersselector1 ,
                                              AV71Listawwds_3_dynamicfiltersoperator1 ,
                                              AV72Listawwds_4_listanombre1 ,
                                              AV73Listawwds_5_dynamicfiltersenabled2 ,
                                              AV74Listawwds_6_dynamicfiltersselector2 ,
                                              AV75Listawwds_7_dynamicfiltersoperator2 ,
                                              AV76Listawwds_8_listanombre2 ,
                                              AV77Listawwds_9_dynamicfiltersenabled3 ,
                                              AV78Listawwds_10_dynamicfiltersselector3 ,
                                              AV79Listawwds_11_dynamicfiltersoperator3 ,
                                              AV80Listawwds_12_listanombre3 ,
                                              AV81Listawwds_13_tflistaid ,
                                              AV82Listawwds_14_tflistaid_to ,
                                              AV84Listawwds_16_tflistanombre_sel ,
                                              AV83Listawwds_15_tflistanombre ,
                                              AV85Listawwds_17_tflistatipo_sels.Count ,
                                              AV86Listawwds_18_tflistaestado_sels.Count ,
                                              A592ListaNombre ,
                                              A590Listaid ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              AV69Listawwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV72Listawwds_4_listanombre1 = StringUtil.PadR( StringUtil.RTrim( AV72Listawwds_4_listanombre1), 80, "%");
         lV72Listawwds_4_listanombre1 = StringUtil.PadR( StringUtil.RTrim( AV72Listawwds_4_listanombre1), 80, "%");
         lV76Listawwds_8_listanombre2 = StringUtil.PadR( StringUtil.RTrim( AV76Listawwds_8_listanombre2), 80, "%");
         lV76Listawwds_8_listanombre2 = StringUtil.PadR( StringUtil.RTrim( AV76Listawwds_8_listanombre2), 80, "%");
         lV80Listawwds_12_listanombre3 = StringUtil.PadR( StringUtil.RTrim( AV80Listawwds_12_listanombre3), 80, "%");
         lV80Listawwds_12_listanombre3 = StringUtil.PadR( StringUtil.RTrim( AV80Listawwds_12_listanombre3), 80, "%");
         lV83Listawwds_15_tflistanombre = StringUtil.PadR( StringUtil.RTrim( AV83Listawwds_15_tflistanombre), 80, "%");
         /* Using cursor P007C2 */
         pr_default.execute(0, new Object[] {lV72Listawwds_4_listanombre1, lV72Listawwds_4_listanombre1, lV76Listawwds_8_listanombre2, lV76Listawwds_8_listanombre2, lV80Listawwds_12_listanombre3, lV80Listawwds_12_listanombre3, AV81Listawwds_13_tflistaid, AV82Listawwds_14_tflistaid_to, lV83Listawwds_15_tflistanombre, AV84Listawwds_16_tflistanombre_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A592ListaNombre = P007C2_A592ListaNombre[0];
            A590Listaid = P007C2_A590Listaid[0];
            A593ListaEstado = P007C2_A593ListaEstado[0];
            n593ListaEstado = P007C2_n593ListaEstado[0];
            A591ListaTipo = P007C2_A591ListaTipo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Listawwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A590Listaid), 18, 0) , StringUtil.PadR( "%" + AV69Listawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A592ListaNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV69Listawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "proveedor", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Listawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "PROV") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "profesional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Listawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "PROF") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "administrativa", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Listawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "ADM") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Listawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Listawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV69Listawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "PEN") == 0 ) ) ) )
            {
               AV28ListaTipoDescription = context.GetMessage( gxdomainlistatipoenum.getDescription(context,A591ListaTipo), "");
               AV29ListaEstadoDescription = context.GetMessage( gxdomainestadoenum.getDescription(context,A593ListaEstado), "");
               /* Execute user subroutine: 'BEFOREPRINTLINE' */
               S144 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               H7C0( false, 36) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A590Listaid), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 136, Gx_line+25, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A592ListaNombre, "")), 140, Gx_line+10, 352, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28ListaTipoDescription, "")), 356, Gx_line+10, 569, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29ListaEstadoDescription, "")), 573, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV30Session.Get("ListaWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ListaWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("ListaWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV87GXV3 = 1;
         while ( AV87GXV3 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV87GXV3));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFLISTAID") == 0 )
            {
               AV34TFListaid = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV35TFListaid_To = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFLISTANOMBRE") == 0 )
            {
               AV36TFListaNombre = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFLISTANOMBRE_SEL") == 0 )
            {
               AV37TFListaNombre_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFLISTATIPO_SEL") == 0 )
            {
               AV38TFListaTipo_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV40TFListaTipo_Sels.FromJSonString(AV38TFListaTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFLISTAESTADO_SEL") == 0 )
            {
               AV42TFListaEstado_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV44TFListaEstado_Sels.FromJSonString(AV42TFListaEstado_SelsJson, null);
            }
            AV87GXV3 = (int)(AV87GXV3+1);
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

      protected void H7C0( bool bFoot ,
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
                  AV59PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV56DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV54AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV60Phone = "+1 550 8923";
               AV58Mail = "info@mail.com";
               AV62Website = "http://www.web.com";
               AV51AddressLine1 = "French Boulevard 2859";
               AV52AddressLine2 = "Downtown";
               AV53AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV63Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV61Title = "";
         AV13FilterFullText = "";
         AV32GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV16ListaNombre1 = "";
         AV17FilterListaNombreDescription = "";
         AV18ListaNombre = "";
         AV20DynamicFiltersSelector2 = "";
         AV22ListaNombre2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV26ListaNombre3 = "";
         AV46TFListaid_To_Description = "";
         AV37TFListaNombre_Sel = "";
         AV36TFListaNombre = "";
         AV40TFListaTipo_Sels = new GxSimpleCollection<string>();
         AV38TFListaTipo_SelsJson = "";
         AV41TFListaTipo_Sel = "";
         AV39TFListaTipo_SelDscs = "";
         AV47FilterTFListaTipo_SelValueDescription = "";
         AV44TFListaEstado_Sels = new GxSimpleCollection<string>();
         AV42TFListaEstado_SelsJson = "";
         AV45TFListaEstado_Sel = "";
         AV43TFListaEstado_SelDscs = "";
         AV48FilterTFListaEstado_SelValueDescription = "";
         AV69Listawwds_1_filterfulltext = "";
         AV70Listawwds_2_dynamicfiltersselector1 = "";
         AV72Listawwds_4_listanombre1 = "";
         AV74Listawwds_6_dynamicfiltersselector2 = "";
         AV76Listawwds_8_listanombre2 = "";
         AV78Listawwds_10_dynamicfiltersselector3 = "";
         AV80Listawwds_12_listanombre3 = "";
         AV83Listawwds_15_tflistanombre = "";
         AV84Listawwds_16_tflistanombre_sel = "";
         AV85Listawwds_17_tflistatipo_sels = new GxSimpleCollection<string>();
         AV86Listawwds_18_tflistaestado_sels = new GxSimpleCollection<string>();
         lV72Listawwds_4_listanombre1 = "";
         lV76Listawwds_8_listanombre2 = "";
         lV80Listawwds_12_listanombre3 = "";
         lV83Listawwds_15_tflistanombre = "";
         A591ListaTipo = "";
         A593ListaEstado = "";
         A592ListaNombre = "";
         P007C2_A592ListaNombre = new string[] {""} ;
         P007C2_A590Listaid = new long[1] ;
         P007C2_A593ListaEstado = new string[] {""} ;
         P007C2_n593ListaEstado = new bool[] {false} ;
         P007C2_A591ListaTipo = new string[] {""} ;
         AV28ListaTipoDescription = "";
         AV29ListaEstadoDescription = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV59PageInfo = "";
         AV56DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV54AppName = "";
         AV60Phone = "";
         AV58Mail = "";
         AV62Website = "";
         AV51AddressLine1 = "";
         AV52AddressLine2 = "";
         AV53AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.listawwexportreport__default(),
            new Object[][] {
                new Object[] {
               P007C2_A592ListaNombre, P007C2_A590Listaid, P007C2_A593ListaEstado, P007C2_n593ListaEstado, P007C2_A591ListaTipo
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV63Pgmname = "ListaWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV63Pgmname = "ListaWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV15DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV25DynamicFiltersOperator3 ;
      private short AV71Listawwds_3_dynamicfiltersoperator1 ;
      private short AV75Listawwds_7_dynamicfiltersoperator2 ;
      private short AV79Listawwds_11_dynamicfiltersoperator3 ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV66GXV1 ;
      private int AV67GXV2 ;
      private int AV85Listawwds_17_tflistatipo_sels_Count ;
      private int AV86Listawwds_18_tflistaestado_sels_Count ;
      private int AV87GXV3 ;
      private long AV34TFListaid ;
      private long AV35TFListaid_To ;
      private long AV50i ;
      private long AV81Listawwds_13_tflistaid ;
      private long AV82Listawwds_14_tflistaid_to ;
      private long A590Listaid ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV63Pgmname ;
      private string GXEncryptionTmp ;
      private string AV16ListaNombre1 ;
      private string AV18ListaNombre ;
      private string AV22ListaNombre2 ;
      private string AV26ListaNombre3 ;
      private string AV37TFListaNombre_Sel ;
      private string AV36TFListaNombre ;
      private string AV41TFListaTipo_Sel ;
      private string AV45TFListaEstado_Sel ;
      private string AV72Listawwds_4_listanombre1 ;
      private string AV76Listawwds_8_listanombre2 ;
      private string AV80Listawwds_12_listanombre3 ;
      private string AV83Listawwds_15_tflistanombre ;
      private string AV84Listawwds_16_tflistanombre_sel ;
      private string lV72Listawwds_4_listanombre1 ;
      private string lV76Listawwds_8_listanombre2 ;
      private string lV80Listawwds_12_listanombre3 ;
      private string lV83Listawwds_15_tflistanombre ;
      private string A591ListaTipo ;
      private string A593ListaEstado ;
      private string A592ListaNombre ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV49TempBoolean ;
      private bool AV73Listawwds_5_dynamicfiltersenabled2 ;
      private bool AV77Listawwds_9_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private bool n593ListaEstado ;
      private string AV38TFListaTipo_SelsJson ;
      private string AV42TFListaEstado_SelsJson ;
      private string AV61Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV17FilterListaNombreDescription ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV46TFListaid_To_Description ;
      private string AV39TFListaTipo_SelDscs ;
      private string AV47FilterTFListaTipo_SelValueDescription ;
      private string AV43TFListaEstado_SelDscs ;
      private string AV48FilterTFListaEstado_SelValueDescription ;
      private string AV69Listawwds_1_filterfulltext ;
      private string AV70Listawwds_2_dynamicfiltersselector1 ;
      private string AV74Listawwds_6_dynamicfiltersselector2 ;
      private string AV78Listawwds_10_dynamicfiltersselector3 ;
      private string AV28ListaTipoDescription ;
      private string AV29ListaEstadoDescription ;
      private string AV59PageInfo ;
      private string AV56DateInfo ;
      private string AV54AppName ;
      private string AV60Phone ;
      private string AV58Mail ;
      private string AV62Website ;
      private string AV51AddressLine1 ;
      private string AV52AddressLine2 ;
      private string AV53AddressLine3 ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV40TFListaTipo_Sels ;
      private GxSimpleCollection<string> AV44TFListaEstado_Sels ;
      private GxSimpleCollection<string> AV85Listawwds_17_tflistatipo_sels ;
      private GxSimpleCollection<string> AV86Listawwds_18_tflistaestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P007C2_A592ListaNombre ;
      private long[] P007C2_A590Listaid ;
      private string[] P007C2_A593ListaEstado ;
      private bool[] P007C2_n593ListaEstado ;
      private string[] P007C2_A591ListaTipo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
   }

   public class listawwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007C2( IGxContext context ,
                                             string A591ListaTipo ,
                                             GxSimpleCollection<string> AV85Listawwds_17_tflistatipo_sels ,
                                             string A593ListaEstado ,
                                             GxSimpleCollection<string> AV86Listawwds_18_tflistaestado_sels ,
                                             string AV70Listawwds_2_dynamicfiltersselector1 ,
                                             short AV71Listawwds_3_dynamicfiltersoperator1 ,
                                             string AV72Listawwds_4_listanombre1 ,
                                             bool AV73Listawwds_5_dynamicfiltersenabled2 ,
                                             string AV74Listawwds_6_dynamicfiltersselector2 ,
                                             short AV75Listawwds_7_dynamicfiltersoperator2 ,
                                             string AV76Listawwds_8_listanombre2 ,
                                             bool AV77Listawwds_9_dynamicfiltersenabled3 ,
                                             string AV78Listawwds_10_dynamicfiltersselector3 ,
                                             short AV79Listawwds_11_dynamicfiltersoperator3 ,
                                             string AV80Listawwds_12_listanombre3 ,
                                             long AV81Listawwds_13_tflistaid ,
                                             long AV82Listawwds_14_tflistaid_to ,
                                             string AV84Listawwds_16_tflistanombre_sel ,
                                             string AV83Listawwds_15_tflistanombre ,
                                             int AV85Listawwds_17_tflistatipo_sels_Count ,
                                             int AV86Listawwds_18_tflistaestado_sels_Count ,
                                             string A592ListaNombre ,
                                             long A590Listaid ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             string AV69Listawwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[10];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [ListaNombre], [Listaid], [ListaEstado], [ListaTipo] FROM [Lista]";
         if ( ( StringUtil.StrCmp(AV70Listawwds_2_dynamicfiltersselector1, "LISTANOMBRE") == 0 ) && ( AV71Listawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Listawwds_4_listanombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ListaNombre]) like UPPER(@lV72Listawwds_4_listanombre1))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV70Listawwds_2_dynamicfiltersselector1, "LISTANOMBRE") == 0 ) && ( AV71Listawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Listawwds_4_listanombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ListaNombre]) like '%' + UPPER(@lV72Listawwds_4_listanombre1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV73Listawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Listawwds_6_dynamicfiltersselector2, "LISTANOMBRE") == 0 ) && ( AV75Listawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Listawwds_8_listanombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ListaNombre]) like UPPER(@lV76Listawwds_8_listanombre2))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV73Listawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Listawwds_6_dynamicfiltersselector2, "LISTANOMBRE") == 0 ) && ( AV75Listawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Listawwds_8_listanombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ListaNombre]) like '%' + UPPER(@lV76Listawwds_8_listanombre2))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV77Listawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV78Listawwds_10_dynamicfiltersselector3, "LISTANOMBRE") == 0 ) && ( AV79Listawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Listawwds_12_listanombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ListaNombre]) like UPPER(@lV80Listawwds_12_listanombre3))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV77Listawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV78Listawwds_10_dynamicfiltersselector3, "LISTANOMBRE") == 0 ) && ( AV79Listawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Listawwds_12_listanombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ListaNombre]) like '%' + UPPER(@lV80Listawwds_12_listanombre3))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV81Listawwds_13_tflistaid) )
         {
            AddWhere(sWhereString, "([Listaid] >= @AV81Listawwds_13_tflistaid)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV82Listawwds_14_tflistaid_to) )
         {
            AddWhere(sWhereString, "([Listaid] <= @AV82Listawwds_14_tflistaid_to)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Listawwds_16_tflistanombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Listawwds_15_tflistanombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ListaNombre]) like UPPER(@lV83Listawwds_15_tflistanombre))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Listawwds_16_tflistanombre_sel)) && ! ( StringUtil.StrCmp(AV84Listawwds_16_tflistanombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ListaNombre] = @AV84Listawwds_16_tflistanombre_sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV84Listawwds_16_tflistanombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ListaNombre] = ''))");
         }
         if ( AV85Listawwds_17_tflistatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV85Listawwds_17_tflistatipo_sels, "[ListaTipo] IN (", ")")+")");
         }
         if ( AV86Listawwds_18_tflistaestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV86Listawwds_18_tflistaestado_sels, "[ListaEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ListaNombre]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ListaNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [Listaid]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [Listaid] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ListaTipo]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ListaTipo] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ListaEstado]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ListaEstado] DESC";
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
                     return conditional_P007C2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (int)dynConstraints[20] , (string)dynConstraints[21] , (long)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] , (string)dynConstraints[25] );
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
          Object[] prmP007C2;
          prmP007C2 = new Object[] {
          new ParDef("@lV72Listawwds_4_listanombre1",GXType.Char,80,0) ,
          new ParDef("@lV72Listawwds_4_listanombre1",GXType.Char,80,0) ,
          new ParDef("@lV76Listawwds_8_listanombre2",GXType.Char,80,0) ,
          new ParDef("@lV76Listawwds_8_listanombre2",GXType.Char,80,0) ,
          new ParDef("@lV80Listawwds_12_listanombre3",GXType.Char,80,0) ,
          new ParDef("@lV80Listawwds_12_listanombre3",GXType.Char,80,0) ,
          new ParDef("@AV81Listawwds_13_tflistaid",GXType.Decimal,18,0) ,
          new ParDef("@AV82Listawwds_14_tflistaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV83Listawwds_15_tflistanombre",GXType.Char,80,0) ,
          new ParDef("@AV84Listawwds_16_tflistanombre_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007C2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007C2,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 4);
                return;
       }
    }

 }

}
