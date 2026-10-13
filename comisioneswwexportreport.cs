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
   public class comisioneswwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public comisioneswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public comisioneswwexportreport( IGxContext context )
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
         setOutputFileName("ComisionesWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComisiones", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV68Pgmname));
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
               AV66Title = context.GetMessage( "Lista de Comisiones", "");
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
            H6J0( true, 0) ;
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
            H6J0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 187, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 187, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV27GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "COMISIONESNOMBRE") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV27GridStateDynamicFilter.gxTpr_Operator;
               AV16ComisionesNombre1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16ComisionesNombre1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterComisionesNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterComisionesNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV18ComisionesNombre = AV16ComisionesNombre1;
                  H6J0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterComisionesNombreDescription, "")), 25, Gx_line+0, 187, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18ComisionesNombre, "")), 187, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV19DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "COMISIONESNOMBRE") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV27GridStateDynamicFilter.gxTpr_Operator;
                  AV22ComisionesNombre2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ComisionesNombre2)) )
                  {
                     if ( AV21DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterComisionesNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV21DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterComisionesNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV18ComisionesNombre = AV22ComisionesNombre2;
                     H6J0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterComisionesNombreDescription, "")), 25, Gx_line+0, 187, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18ComisionesNombre, "")), 187, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "COMISIONESNOMBRE") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV27GridStateDynamicFilter.gxTpr_Operator;
                     AV26ComisionesNombre3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ComisionesNombre3)) )
                     {
                        if ( AV25DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterComisionesNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV25DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterComisionesNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV18ComisionesNombre = AV26ComisionesNombre3;
                        H6J0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterComisionesNombreDescription, "")), 25, Gx_line+0, 187, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18ComisionesNombre, "")), 187, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV34TFComisionesID) && (0==AV35TFComisionesID_To) ) )
         {
            H6J0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Código de la Comisión", ""), 25, Gx_line+0, 187, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV34TFComisionesID), "ZZZZZZZZZZZZZZZZZ9")), 187, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV49TFComisionesID_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Código de la Comisión", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H6J0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49TFComisionesID_To_Description, "")), 25, Gx_line+0, 187, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV35TFComisionesID_To), "ZZZZZZZZZZZZZZZZZ9")), 187, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFComisionesNombre_Sel)) )
         {
            AV54TempBoolean = (bool)(((StringUtil.StrCmp(AV37TFComisionesNombre_Sel, "<#Empty#>")==0)));
            AV37TFComisionesNombre_Sel = (AV54TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV37TFComisionesNombre_Sel);
            H6J0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 187, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFComisionesNombre_Sel, "")), 187, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV37TFComisionesNombre_Sel = (AV54TempBoolean ? "<#Empty#>" : AV37TFComisionesNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFComisionesNombre)) )
            {
               H6J0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 187, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFComisionesNombre, "")), 187, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV40TFComisionesTipo_Sels.FromJSonString(AV38TFComisionesTipo_SelsJson, null);
         if ( ! ( AV40TFComisionesTipo_Sels.Count == 0 ) )
         {
            AV55i = 1;
            AV71GXV1 = 1;
            while ( AV71GXV1 <= AV40TFComisionesTipo_Sels.Count )
            {
               AV41TFComisionesTipo_Sel = AV40TFComisionesTipo_Sels.GetString(AV71GXV1);
               if ( AV55i == 1 )
               {
                  AV39TFComisionesTipo_SelDscs = "";
               }
               else
               {
                  AV39TFComisionesTipo_SelDscs += ", ";
               }
               AV50FilterTFComisionesTipo_SelValueDescription = context.GetMessage( gxdomaintipocomision.getDescription(context,AV41TFComisionesTipo_Sel), "");
               AV39TFComisionesTipo_SelDscs += AV50FilterTFComisionesTipo_SelValueDescription;
               AV55i = (long)(AV55i+1);
               AV71GXV1 = (int)(AV71GXV1+1);
            }
            H6J0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Tipo", ""), 25, Gx_line+0, 187, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFComisionesTipo_SelDscs, "")), 187, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV42TFComisionesDefault) && (Convert.ToDecimal(0)==AV43TFComisionesDefault_To) ) )
         {
            H6J0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Comisión por Defecto %", ""), 25, Gx_line+0, 187, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42TFComisionesDefault, "ZZ9.99")), 187, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV51TFComisionesDefault_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Comisión por Defecto %", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H6J0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51TFComisionesDefault_To_Description, "")), 25, Gx_line+0, 187, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV43TFComisionesDefault_To, "ZZ9.99")), 187, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         AV46TFComisionesEstado_Sels.FromJSonString(AV44TFComisionesEstado_SelsJson, null);
         if ( ! ( AV46TFComisionesEstado_Sels.Count == 0 ) )
         {
            AV55i = 1;
            AV72GXV2 = 1;
            while ( AV72GXV2 <= AV46TFComisionesEstado_Sels.Count )
            {
               AV47TFComisionesEstado_Sel = AV46TFComisionesEstado_Sels.GetString(AV72GXV2);
               if ( AV55i == 1 )
               {
                  AV45TFComisionesEstado_SelDscs = "";
               }
               else
               {
                  AV45TFComisionesEstado_SelDscs += ", ";
               }
               AV52FilterTFComisionesEstado_SelValueDescription = context.GetMessage( gxdomainestadoenum.getDescription(context,AV47TFComisionesEstado_Sel), "");
               AV45TFComisionesEstado_SelDscs += AV52FilterTFComisionesEstado_SelValueDescription;
               AV55i = (long)(AV55i+1);
               AV72GXV2 = (int)(AV72GXV2+1);
            }
            H6J0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 25, Gx_line+0, 187, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45TFComisionesEstado_SelDscs, "")), 187, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! (0==AV48TFComisionesGlobal_Sel) )
         {
            if ( AV48TFComisionesGlobal_Sel == 1 )
            {
               AV53FilterTFComisionesGlobal_SelValueDescription = context.GetMessage( "WWP_TSChecked", "");
            }
            else if ( AV48TFComisionesGlobal_Sel == 2 )
            {
               AV53FilterTFComisionesGlobal_SelValueDescription = context.GetMessage( "WWP_TSUnChecked", "");
            }
            H6J0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Comisión Global", ""), 25, Gx_line+0, 187, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53FilterTFComisionesGlobal_SelValueDescription, "")), 187, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H6J0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H6J0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Código de la Comisión", ""), 30, Gx_line+10, 103, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 107, Gx_line+10, 253, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Tipo", ""), 257, Gx_line+10, 403, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Imagen Promisional", ""), 407, Gx_line+10, 480, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Comisión por Defecto %", ""), 484, Gx_line+10, 557, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 561, Gx_line+10, 709, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Comisión Global", ""), 713, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV74Comisioneswwds_1_filterfulltext = AV13FilterFullText;
         AV75Comisioneswwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV76Comisioneswwds_3_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV77Comisioneswwds_4_comisionesnombre1 = AV16ComisionesNombre1;
         AV78Comisioneswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV79Comisioneswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV80Comisioneswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV81Comisioneswwds_8_comisionesnombre2 = AV22ComisionesNombre2;
         AV82Comisioneswwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV83Comisioneswwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV84Comisioneswwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV85Comisioneswwds_12_comisionesnombre3 = AV26ComisionesNombre3;
         AV86Comisioneswwds_13_tfcomisionesid = AV34TFComisionesID;
         AV87Comisioneswwds_14_tfcomisionesid_to = AV35TFComisionesID_To;
         AV88Comisioneswwds_15_tfcomisionesnombre = AV36TFComisionesNombre;
         AV89Comisioneswwds_16_tfcomisionesnombre_sel = AV37TFComisionesNombre_Sel;
         AV90Comisioneswwds_17_tfcomisionestipo_sels = AV40TFComisionesTipo_Sels;
         AV91Comisioneswwds_18_tfcomisionesdefault = AV42TFComisionesDefault;
         AV92Comisioneswwds_19_tfcomisionesdefault_to = AV43TFComisionesDefault_To;
         AV93Comisioneswwds_20_tfcomisionesestado_sels = AV46TFComisionesEstado_Sels;
         AV94Comisioneswwds_21_tfcomisionesglobal_sel = AV48TFComisionesGlobal_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A505ComisionesTipo ,
                                              AV90Comisioneswwds_17_tfcomisionestipo_sels ,
                                              A511ComisionesEstado ,
                                              AV93Comisioneswwds_20_tfcomisionesestado_sels ,
                                              AV75Comisioneswwds_2_dynamicfiltersselector1 ,
                                              AV76Comisioneswwds_3_dynamicfiltersoperator1 ,
                                              AV77Comisioneswwds_4_comisionesnombre1 ,
                                              AV78Comisioneswwds_5_dynamicfiltersenabled2 ,
                                              AV79Comisioneswwds_6_dynamicfiltersselector2 ,
                                              AV80Comisioneswwds_7_dynamicfiltersoperator2 ,
                                              AV81Comisioneswwds_8_comisionesnombre2 ,
                                              AV82Comisioneswwds_9_dynamicfiltersenabled3 ,
                                              AV83Comisioneswwds_10_dynamicfiltersselector3 ,
                                              AV84Comisioneswwds_11_dynamicfiltersoperator3 ,
                                              AV85Comisioneswwds_12_comisionesnombre3 ,
                                              AV86Comisioneswwds_13_tfcomisionesid ,
                                              AV87Comisioneswwds_14_tfcomisionesid_to ,
                                              AV89Comisioneswwds_16_tfcomisionesnombre_sel ,
                                              AV88Comisioneswwds_15_tfcomisionesnombre ,
                                              AV90Comisioneswwds_17_tfcomisionestipo_sels.Count ,
                                              AV91Comisioneswwds_18_tfcomisionesdefault ,
                                              AV92Comisioneswwds_19_tfcomisionesdefault_to ,
                                              AV93Comisioneswwds_20_tfcomisionesestado_sels.Count ,
                                              AV94Comisioneswwds_21_tfcomisionesglobal_sel ,
                                              A504ComisionesNombre ,
                                              A503ComisionesID ,
                                              A506ComisionesDefault ,
                                              A520ComisionesGlobal ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              AV74Comisioneswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV77Comisioneswwds_4_comisionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV77Comisioneswwds_4_comisionesnombre1), 80, "%");
         lV77Comisioneswwds_4_comisionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV77Comisioneswwds_4_comisionesnombre1), 80, "%");
         lV81Comisioneswwds_8_comisionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV81Comisioneswwds_8_comisionesnombre2), 80, "%");
         lV81Comisioneswwds_8_comisionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV81Comisioneswwds_8_comisionesnombre2), 80, "%");
         lV85Comisioneswwds_12_comisionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV85Comisioneswwds_12_comisionesnombre3), 80, "%");
         lV85Comisioneswwds_12_comisionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV85Comisioneswwds_12_comisionesnombre3), 80, "%");
         lV88Comisioneswwds_15_tfcomisionesnombre = StringUtil.PadR( StringUtil.RTrim( AV88Comisioneswwds_15_tfcomisionesnombre), 80, "%");
         /* Using cursor P006J2 */
         pr_default.execute(0, new Object[] {lV77Comisioneswwds_4_comisionesnombre1, lV77Comisioneswwds_4_comisionesnombre1, lV81Comisioneswwds_8_comisionesnombre2, lV81Comisioneswwds_8_comisionesnombre2, lV85Comisioneswwds_12_comisionesnombre3, lV85Comisioneswwds_12_comisionesnombre3, AV86Comisioneswwds_13_tfcomisionesid, AV87Comisioneswwds_14_tfcomisionesid_to, lV88Comisioneswwds_15_tfcomisionesnombre, AV89Comisioneswwds_16_tfcomisionesnombre_sel, AV91Comisioneswwds_18_tfcomisionesdefault, AV92Comisioneswwds_19_tfcomisionesdefault_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A520ComisionesGlobal = P006J2_A520ComisionesGlobal[0];
            n520ComisionesGlobal = P006J2_n520ComisionesGlobal[0];
            A506ComisionesDefault = P006J2_A506ComisionesDefault[0];
            n506ComisionesDefault = P006J2_n506ComisionesDefault[0];
            A504ComisionesNombre = P006J2_A504ComisionesNombre[0];
            A503ComisionesID = P006J2_A503ComisionesID[0];
            A511ComisionesEstado = P006J2_A511ComisionesEstado[0];
            n511ComisionesEstado = P006J2_n511ComisionesEstado[0];
            A505ComisionesTipo = P006J2_A505ComisionesTipo[0];
            A40000ComisionesImagen_GXI = P006J2_A40000ComisionesImagen_GXI[0];
            n40000ComisionesImagen_GXI = P006J2_n40000ComisionesImagen_GXI[0];
            A519ComisionesImagen = P006J2_A519ComisionesImagen[0];
            n519ComisionesImagen = P006J2_n519ComisionesImagen[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Comisioneswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A503ComisionesID), 18, 0) , StringUtil.PadR( "%" + AV74Comisioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A504ComisionesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV74Comisioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "profesional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV74Comisioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A505ComisionesTipo, "P") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV74Comisioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A505ComisionesTipo, "C") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "zona", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV74Comisioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A505ComisionesTipo, "Z") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( A506ComisionesDefault, 6, 2) , StringUtil.PadR( "%" + AV74Comisioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV74Comisioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A511ComisionesEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV74Comisioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A511ComisionesEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV74Comisioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A511ComisionesEstado, "PEN") == 0 ) ) ) )
            {
               AV28ComisionesTipoDescription = context.GetMessage( gxdomaintipocomision.getDescription(context,A505ComisionesTipo), "");
               AV29ComisionesEstadoDescription = context.GetMessage( gxdomainestadoenum.getDescription(context,A511ComisionesEstado), "");
               /* Execute user subroutine: 'BEFOREPRINTLINE' */
               S144 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               H6J0( false, 36) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A503ComisionesID), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 103, Gx_line+25, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A504ComisionesNombre, "")), 107, Gx_line+10, 253, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28ComisionesTipoDescription, "")), 257, Gx_line+10, 403, Gx_line+25, 0+16, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A519ComisionesImagen)) ? A40000ComisionesImagen_GXI : A519ComisionesImagen);
               getPrinter().GxDrawBitMap(sImgUrl, 407, Gx_line+10, 480, Gx_line+25) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A506ComisionesDefault, "ZZ9.99")), 484, Gx_line+10, 557, Gx_line+25, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29ComisionesEstadoDescription, "")), 561, Gx_line+10, 709, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.BoolToStr( A520ComisionesGlobal), 713, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV30Session.Get("ComisionesWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ComisionesWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("ComisionesWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV95GXV3 = 1;
         while ( AV95GXV3 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV95GXV3));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCOMISIONESID") == 0 )
            {
               AV34TFComisionesID = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV35TFComisionesID_To = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCOMISIONESNOMBRE") == 0 )
            {
               AV36TFComisionesNombre = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCOMISIONESNOMBRE_SEL") == 0 )
            {
               AV37TFComisionesNombre_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCOMISIONESTIPO_SEL") == 0 )
            {
               AV38TFComisionesTipo_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV40TFComisionesTipo_Sels.FromJSonString(AV38TFComisionesTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCOMISIONESDEFAULT") == 0 )
            {
               AV42TFComisionesDefault = NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, ".");
               AV43TFComisionesDefault_To = NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCOMISIONESESTADO_SEL") == 0 )
            {
               AV44TFComisionesEstado_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV46TFComisionesEstado_Sels.FromJSonString(AV44TFComisionesEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCOMISIONESGLOBAL_SEL") == 0 )
            {
               AV48TFComisionesGlobal_Sel = (short)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV95GXV3 = (int)(AV95GXV3+1);
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

      protected void H6J0( bool bFoot ,
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
                  AV64PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV61DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV59AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV65Phone = "+1 550 8923";
               AV63Mail = "info@mail.com";
               AV67Website = "http://www.web.com";
               AV56AddressLine1 = "French Boulevard 2859";
               AV57AddressLine2 = "Downtown";
               AV58AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV68Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV66Title = "";
         AV13FilterFullText = "";
         AV32GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV16ComisionesNombre1 = "";
         AV17FilterComisionesNombreDescription = "";
         AV18ComisionesNombre = "";
         AV20DynamicFiltersSelector2 = "";
         AV22ComisionesNombre2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV26ComisionesNombre3 = "";
         AV49TFComisionesID_To_Description = "";
         AV37TFComisionesNombre_Sel = "";
         AV36TFComisionesNombre = "";
         AV40TFComisionesTipo_Sels = new GxSimpleCollection<string>();
         AV38TFComisionesTipo_SelsJson = "";
         AV41TFComisionesTipo_Sel = "";
         AV39TFComisionesTipo_SelDscs = "";
         AV50FilterTFComisionesTipo_SelValueDescription = "";
         AV51TFComisionesDefault_To_Description = "";
         AV46TFComisionesEstado_Sels = new GxSimpleCollection<string>();
         AV44TFComisionesEstado_SelsJson = "";
         AV47TFComisionesEstado_Sel = "";
         AV45TFComisionesEstado_SelDscs = "";
         AV52FilterTFComisionesEstado_SelValueDescription = "";
         AV53FilterTFComisionesGlobal_SelValueDescription = "";
         AV74Comisioneswwds_1_filterfulltext = "";
         AV75Comisioneswwds_2_dynamicfiltersselector1 = "";
         AV77Comisioneswwds_4_comisionesnombre1 = "";
         AV79Comisioneswwds_6_dynamicfiltersselector2 = "";
         AV81Comisioneswwds_8_comisionesnombre2 = "";
         AV83Comisioneswwds_10_dynamicfiltersselector3 = "";
         AV85Comisioneswwds_12_comisionesnombre3 = "";
         AV88Comisioneswwds_15_tfcomisionesnombre = "";
         AV89Comisioneswwds_16_tfcomisionesnombre_sel = "";
         AV90Comisioneswwds_17_tfcomisionestipo_sels = new GxSimpleCollection<string>();
         AV93Comisioneswwds_20_tfcomisionesestado_sels = new GxSimpleCollection<string>();
         lV77Comisioneswwds_4_comisionesnombre1 = "";
         lV81Comisioneswwds_8_comisionesnombre2 = "";
         lV85Comisioneswwds_12_comisionesnombre3 = "";
         lV88Comisioneswwds_15_tfcomisionesnombre = "";
         A505ComisionesTipo = "";
         A511ComisionesEstado = "";
         A504ComisionesNombre = "";
         P006J2_A520ComisionesGlobal = new bool[] {false} ;
         P006J2_n520ComisionesGlobal = new bool[] {false} ;
         P006J2_A506ComisionesDefault = new decimal[1] ;
         P006J2_n506ComisionesDefault = new bool[] {false} ;
         P006J2_A504ComisionesNombre = new string[] {""} ;
         P006J2_A503ComisionesID = new long[1] ;
         P006J2_A511ComisionesEstado = new string[] {""} ;
         P006J2_n511ComisionesEstado = new bool[] {false} ;
         P006J2_A505ComisionesTipo = new string[] {""} ;
         P006J2_A40000ComisionesImagen_GXI = new string[] {""} ;
         P006J2_n40000ComisionesImagen_GXI = new bool[] {false} ;
         P006J2_A519ComisionesImagen = new string[] {""} ;
         P006J2_n519ComisionesImagen = new bool[] {false} ;
         A40000ComisionesImagen_GXI = "";
         A519ComisionesImagen = "";
         AV28ComisionesTipoDescription = "";
         AV29ComisionesEstadoDescription = "";
         sImgUrl = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV64PageInfo = "";
         AV61DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV59AppName = "";
         AV65Phone = "";
         AV63Mail = "";
         AV67Website = "";
         AV56AddressLine1 = "";
         AV57AddressLine2 = "";
         AV58AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comisioneswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P006J2_A520ComisionesGlobal, P006J2_n520ComisionesGlobal, P006J2_A506ComisionesDefault, P006J2_n506ComisionesDefault, P006J2_A504ComisionesNombre, P006J2_A503ComisionesID, P006J2_A511ComisionesEstado, P006J2_n511ComisionesEstado, P006J2_A505ComisionesTipo, P006J2_A40000ComisionesImagen_GXI,
               P006J2_n40000ComisionesImagen_GXI, P006J2_A519ComisionesImagen, P006J2_n519ComisionesImagen
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV68Pgmname = "ComisionesWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV68Pgmname = "ComisionesWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV15DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV25DynamicFiltersOperator3 ;
      private short AV48TFComisionesGlobal_Sel ;
      private short AV76Comisioneswwds_3_dynamicfiltersoperator1 ;
      private short AV80Comisioneswwds_7_dynamicfiltersoperator2 ;
      private short AV84Comisioneswwds_11_dynamicfiltersoperator3 ;
      private short AV94Comisioneswwds_21_tfcomisionesglobal_sel ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV71GXV1 ;
      private int AV72GXV2 ;
      private int AV90Comisioneswwds_17_tfcomisionestipo_sels_Count ;
      private int AV93Comisioneswwds_20_tfcomisionesestado_sels_Count ;
      private int AV95GXV3 ;
      private long AV34TFComisionesID ;
      private long AV35TFComisionesID_To ;
      private long AV55i ;
      private long AV86Comisioneswwds_13_tfcomisionesid ;
      private long AV87Comisioneswwds_14_tfcomisionesid_to ;
      private long A503ComisionesID ;
      private decimal AV42TFComisionesDefault ;
      private decimal AV43TFComisionesDefault_To ;
      private decimal AV91Comisioneswwds_18_tfcomisionesdefault ;
      private decimal AV92Comisioneswwds_19_tfcomisionesdefault_to ;
      private decimal A506ComisionesDefault ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV68Pgmname ;
      private string GXEncryptionTmp ;
      private string AV16ComisionesNombre1 ;
      private string AV18ComisionesNombre ;
      private string AV22ComisionesNombre2 ;
      private string AV26ComisionesNombre3 ;
      private string AV37TFComisionesNombre_Sel ;
      private string AV36TFComisionesNombre ;
      private string AV41TFComisionesTipo_Sel ;
      private string AV47TFComisionesEstado_Sel ;
      private string AV77Comisioneswwds_4_comisionesnombre1 ;
      private string AV81Comisioneswwds_8_comisionesnombre2 ;
      private string AV85Comisioneswwds_12_comisionesnombre3 ;
      private string AV88Comisioneswwds_15_tfcomisionesnombre ;
      private string AV89Comisioneswwds_16_tfcomisionesnombre_sel ;
      private string lV77Comisioneswwds_4_comisionesnombre1 ;
      private string lV81Comisioneswwds_8_comisionesnombre2 ;
      private string lV85Comisioneswwds_12_comisionesnombre3 ;
      private string lV88Comisioneswwds_15_tfcomisionesnombre ;
      private string A505ComisionesTipo ;
      private string A511ComisionesEstado ;
      private string A504ComisionesNombre ;
      private string sImgUrl ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV54TempBoolean ;
      private bool AV78Comisioneswwds_5_dynamicfiltersenabled2 ;
      private bool AV82Comisioneswwds_9_dynamicfiltersenabled3 ;
      private bool A520ComisionesGlobal ;
      private bool AV12OrderedDsc ;
      private bool n520ComisionesGlobal ;
      private bool n506ComisionesDefault ;
      private bool n511ComisionesEstado ;
      private bool n40000ComisionesImagen_GXI ;
      private bool n519ComisionesImagen ;
      private string AV38TFComisionesTipo_SelsJson ;
      private string AV44TFComisionesEstado_SelsJson ;
      private string AV66Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV17FilterComisionesNombreDescription ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV49TFComisionesID_To_Description ;
      private string AV39TFComisionesTipo_SelDscs ;
      private string AV50FilterTFComisionesTipo_SelValueDescription ;
      private string AV51TFComisionesDefault_To_Description ;
      private string AV45TFComisionesEstado_SelDscs ;
      private string AV52FilterTFComisionesEstado_SelValueDescription ;
      private string AV53FilterTFComisionesGlobal_SelValueDescription ;
      private string AV74Comisioneswwds_1_filterfulltext ;
      private string AV75Comisioneswwds_2_dynamicfiltersselector1 ;
      private string AV79Comisioneswwds_6_dynamicfiltersselector2 ;
      private string AV83Comisioneswwds_10_dynamicfiltersselector3 ;
      private string A40000ComisionesImagen_GXI ;
      private string AV28ComisionesTipoDescription ;
      private string AV29ComisionesEstadoDescription ;
      private string AV64PageInfo ;
      private string AV61DateInfo ;
      private string AV59AppName ;
      private string AV65Phone ;
      private string AV63Mail ;
      private string AV67Website ;
      private string AV56AddressLine1 ;
      private string AV57AddressLine2 ;
      private string AV58AddressLine3 ;
      private string A519ComisionesImagen ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV40TFComisionesTipo_Sels ;
      private GxSimpleCollection<string> AV46TFComisionesEstado_Sels ;
      private GxSimpleCollection<string> AV90Comisioneswwds_17_tfcomisionestipo_sels ;
      private GxSimpleCollection<string> AV93Comisioneswwds_20_tfcomisionesestado_sels ;
      private IDataStoreProvider pr_default ;
      private bool[] P006J2_A520ComisionesGlobal ;
      private bool[] P006J2_n520ComisionesGlobal ;
      private decimal[] P006J2_A506ComisionesDefault ;
      private bool[] P006J2_n506ComisionesDefault ;
      private string[] P006J2_A504ComisionesNombre ;
      private long[] P006J2_A503ComisionesID ;
      private string[] P006J2_A511ComisionesEstado ;
      private bool[] P006J2_n511ComisionesEstado ;
      private string[] P006J2_A505ComisionesTipo ;
      private string[] P006J2_A40000ComisionesImagen_GXI ;
      private bool[] P006J2_n40000ComisionesImagen_GXI ;
      private string[] P006J2_A519ComisionesImagen ;
      private bool[] P006J2_n519ComisionesImagen ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
   }

   public class comisioneswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006J2( IGxContext context ,
                                             string A505ComisionesTipo ,
                                             GxSimpleCollection<string> AV90Comisioneswwds_17_tfcomisionestipo_sels ,
                                             string A511ComisionesEstado ,
                                             GxSimpleCollection<string> AV93Comisioneswwds_20_tfcomisionesestado_sels ,
                                             string AV75Comisioneswwds_2_dynamicfiltersselector1 ,
                                             short AV76Comisioneswwds_3_dynamicfiltersoperator1 ,
                                             string AV77Comisioneswwds_4_comisionesnombre1 ,
                                             bool AV78Comisioneswwds_5_dynamicfiltersenabled2 ,
                                             string AV79Comisioneswwds_6_dynamicfiltersselector2 ,
                                             short AV80Comisioneswwds_7_dynamicfiltersoperator2 ,
                                             string AV81Comisioneswwds_8_comisionesnombre2 ,
                                             bool AV82Comisioneswwds_9_dynamicfiltersenabled3 ,
                                             string AV83Comisioneswwds_10_dynamicfiltersselector3 ,
                                             short AV84Comisioneswwds_11_dynamicfiltersoperator3 ,
                                             string AV85Comisioneswwds_12_comisionesnombre3 ,
                                             long AV86Comisioneswwds_13_tfcomisionesid ,
                                             long AV87Comisioneswwds_14_tfcomisionesid_to ,
                                             string AV89Comisioneswwds_16_tfcomisionesnombre_sel ,
                                             string AV88Comisioneswwds_15_tfcomisionesnombre ,
                                             int AV90Comisioneswwds_17_tfcomisionestipo_sels_Count ,
                                             decimal AV91Comisioneswwds_18_tfcomisionesdefault ,
                                             decimal AV92Comisioneswwds_19_tfcomisionesdefault_to ,
                                             int AV93Comisioneswwds_20_tfcomisionesestado_sels_Count ,
                                             short AV94Comisioneswwds_21_tfcomisionesglobal_sel ,
                                             string A504ComisionesNombre ,
                                             long A503ComisionesID ,
                                             decimal A506ComisionesDefault ,
                                             bool A520ComisionesGlobal ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             string AV74Comisioneswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[12];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [ComisionesGlobal], [ComisionesDefault], [ComisionesNombre], [ComisionesID], [ComisionesEstado], [ComisionesTipo], [ComisionesImagen_GXI], [ComisionesImagen] FROM [Comisiones]";
         if ( ( StringUtil.StrCmp(AV75Comisioneswwds_2_dynamicfiltersselector1, "COMISIONESNOMBRE") == 0 ) && ( AV76Comisioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Comisioneswwds_4_comisionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ComisionesNombre]) like UPPER(@lV77Comisioneswwds_4_comisionesnombre1))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Comisioneswwds_2_dynamicfiltersselector1, "COMISIONESNOMBRE") == 0 ) && ( AV76Comisioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Comisioneswwds_4_comisionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ComisionesNombre]) like '%' + UPPER(@lV77Comisioneswwds_4_comisionesnombre1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV78Comisioneswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Comisioneswwds_6_dynamicfiltersselector2, "COMISIONESNOMBRE") == 0 ) && ( AV80Comisioneswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Comisioneswwds_8_comisionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ComisionesNombre]) like UPPER(@lV81Comisioneswwds_8_comisionesnombre2))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV78Comisioneswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Comisioneswwds_6_dynamicfiltersselector2, "COMISIONESNOMBRE") == 0 ) && ( AV80Comisioneswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Comisioneswwds_8_comisionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ComisionesNombre]) like '%' + UPPER(@lV81Comisioneswwds_8_comisionesnombre2))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV82Comisioneswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Comisioneswwds_10_dynamicfiltersselector3, "COMISIONESNOMBRE") == 0 ) && ( AV84Comisioneswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Comisioneswwds_12_comisionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ComisionesNombre]) like UPPER(@lV85Comisioneswwds_12_comisionesnombre3))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV82Comisioneswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Comisioneswwds_10_dynamicfiltersselector3, "COMISIONESNOMBRE") == 0 ) && ( AV84Comisioneswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Comisioneswwds_12_comisionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ComisionesNombre]) like '%' + UPPER(@lV85Comisioneswwds_12_comisionesnombre3))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV86Comisioneswwds_13_tfcomisionesid) )
         {
            AddWhere(sWhereString, "([ComisionesID] >= @AV86Comisioneswwds_13_tfcomisionesid)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV87Comisioneswwds_14_tfcomisionesid_to) )
         {
            AddWhere(sWhereString, "([ComisionesID] <= @AV87Comisioneswwds_14_tfcomisionesid_to)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Comisioneswwds_16_tfcomisionesnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Comisioneswwds_15_tfcomisionesnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ComisionesNombre]) like UPPER(@lV88Comisioneswwds_15_tfcomisionesnombre))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Comisioneswwds_16_tfcomisionesnombre_sel)) && ! ( StringUtil.StrCmp(AV89Comisioneswwds_16_tfcomisionesnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ComisionesNombre] = @AV89Comisioneswwds_16_tfcomisionesnombre_sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV89Comisioneswwds_16_tfcomisionesnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ComisionesNombre] = ''))");
         }
         if ( AV90Comisioneswwds_17_tfcomisionestipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV90Comisioneswwds_17_tfcomisionestipo_sels, "[ComisionesTipo] IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV91Comisioneswwds_18_tfcomisionesdefault) )
         {
            AddWhere(sWhereString, "([ComisionesDefault] >= @AV91Comisioneswwds_18_tfcomisionesdefault)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV92Comisioneswwds_19_tfcomisionesdefault_to) )
         {
            AddWhere(sWhereString, "([ComisionesDefault] <= @AV92Comisioneswwds_19_tfcomisionesdefault_to)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( AV93Comisioneswwds_20_tfcomisionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV93Comisioneswwds_20_tfcomisionesestado_sels, "[ComisionesEstado] IN (", ")")+")");
         }
         if ( AV94Comisioneswwds_21_tfcomisionesglobal_sel == 1 )
         {
            AddWhere(sWhereString, "([ComisionesGlobal] = 1)");
         }
         if ( AV94Comisioneswwds_21_tfcomisionesglobal_sel == 2 )
         {
            AddWhere(sWhereString, "([ComisionesGlobal] = 0)");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ComisionesNombre]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ComisionesNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ComisionesID]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ComisionesID] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ComisionesTipo]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ComisionesTipo] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ComisionesDefault]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ComisionesDefault] DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ComisionesEstado]";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ComisionesEstado] DESC";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ComisionesGlobal]";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ComisionesGlobal] DESC";
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
                     return conditional_P006J2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (int)dynConstraints[22] , (short)dynConstraints[23] , (string)dynConstraints[24] , (long)dynConstraints[25] , (decimal)dynConstraints[26] , (bool)dynConstraints[27] , (short)dynConstraints[28] , (bool)dynConstraints[29] , (string)dynConstraints[30] );
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
          Object[] prmP006J2;
          prmP006J2 = new Object[] {
          new ParDef("@lV77Comisioneswwds_4_comisionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV77Comisioneswwds_4_comisionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV81Comisioneswwds_8_comisionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV81Comisioneswwds_8_comisionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV85Comisioneswwds_12_comisionesnombre3",GXType.Char,80,0) ,
          new ParDef("@lV85Comisioneswwds_12_comisionesnombre3",GXType.Char,80,0) ,
          new ParDef("@AV86Comisioneswwds_13_tfcomisionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV87Comisioneswwds_14_tfcomisionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV88Comisioneswwds_15_tfcomisionesnombre",GXType.Char,80,0) ,
          new ParDef("@AV89Comisioneswwds_16_tfcomisionesnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV91Comisioneswwds_18_tfcomisionesdefault",GXType.Decimal,6,2) ,
          new ParDef("@AV92Comisioneswwds_19_tfcomisionesdefault_to",GXType.Decimal,6,2)
          };
          def= new CursorDef[] {
              new CursorDef("P006J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006J2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 80);
                ((long[]) buf[5])[0] = rslt.getLong(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 3);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getString(6, 1);
                ((string[]) buf[9])[0] = rslt.getMultimediaUri(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((string[]) buf[11])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(7));
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                return;
       }
    }

 }

}
