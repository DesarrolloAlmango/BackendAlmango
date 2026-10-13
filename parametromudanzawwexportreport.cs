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
   public class parametromudanzawwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public parametromudanzawwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public parametromudanzawwexportreport( IGxContext context )
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
         setOutputFileName("ParametroMudanzaWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWParametroMudanza", out  GXt_boolean1) ;
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
               AV64Title = context.GetMessage( "Lista de Parametro Mudanza", "");
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
            HEW0( true, 0) ;
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
            HEW0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 152, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 152, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV27GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "PARAMETROMUDANZATIPO") == 0 )
            {
               AV15ParametroMudanzaTipo1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15ParametroMudanzaTipo1)) )
               {
                  AV18FilterParametroMudanzaTipo1ValueDescription = context.GetMessage( gxdomaintipomudanza.getDescription(context,AV15ParametroMudanzaTipo1), "");
                  AV17FilterParametroMudanzaTipoValueDescription = AV18FilterParametroMudanzaTipo1ValueDescription;
                  HEW0( false, 19) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Mudanza Tipo", ""), 25, Gx_line+0, 152, Gx_line+14, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterParametroMudanzaTipoValueDescription, "")), 152, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV19DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "PARAMETROMUDANZATIPO") == 0 )
               {
                  AV21ParametroMudanzaTipo2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ParametroMudanzaTipo2)) )
                  {
                     AV22FilterParametroMudanzaTipo2ValueDescription = context.GetMessage( gxdomaintipomudanza.getDescription(context,AV21ParametroMudanzaTipo2), "");
                     AV17FilterParametroMudanzaTipoValueDescription = AV22FilterParametroMudanzaTipo2ValueDescription;
                     HEW0( false, 19) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.GetMessage( "Mudanza Tipo", ""), 25, Gx_line+0, 152, Gx_line+14, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterParametroMudanzaTipoValueDescription, "")), 152, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "PARAMETROMUDANZATIPO") == 0 )
                  {
                     AV25ParametroMudanzaTipo3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ParametroMudanzaTipo3)) )
                     {
                        AV26FilterParametroMudanzaTipo3ValueDescription = context.GetMessage( gxdomaintipomudanza.getDescription(context,AV25ParametroMudanzaTipo3), "");
                        AV17FilterParametroMudanzaTipoValueDescription = AV26FilterParametroMudanzaTipo3ValueDescription;
                        HEW0( false, 19) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.GetMessage( "Mudanza Tipo", ""), 25, Gx_line+0, 152, Gx_line+14, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterParametroMudanzaTipoValueDescription, "")), 152, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV34TFParametroMudanzaId) && (0==AV35TFParametroMudanzaId_To) ) )
         {
            HEW0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Mudanza Id", ""), 25, Gx_line+0, 152, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV34TFParametroMudanzaId), "ZZZ9")), 152, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV48TFParametroMudanzaId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Mudanza Id", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HEW0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48TFParametroMudanzaId_To_Description, "")), 25, Gx_line+0, 152, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV35TFParametroMudanzaId_To), "ZZZ9")), 152, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         AV39TFParametroMudanzaTipo_Sels.FromJSonString(AV36TFParametroMudanzaTipo_SelsJson, null);
         if ( ! ( AV39TFParametroMudanzaTipo_Sels.Count == 0 ) )
         {
            AV53i = 1;
            AV78GXV1 = 1;
            while ( AV78GXV1 <= AV39TFParametroMudanzaTipo_Sels.Count )
            {
               AV38TFParametroMudanzaTipo_Sel = ((string)AV39TFParametroMudanzaTipo_Sels.Item(AV78GXV1));
               if ( AV53i == 1 )
               {
                  AV37TFParametroMudanzaTipo_SelDscs = "";
               }
               else
               {
                  AV37TFParametroMudanzaTipo_SelDscs += ", ";
               }
               AV49FilterTFParametroMudanzaTipo_SelValueDescription = context.GetMessage( gxdomaintipomudanza.getDescription(context,AV38TFParametroMudanzaTipo_Sel), "");
               AV37TFParametroMudanzaTipo_SelDscs += AV49FilterTFParametroMudanzaTipo_SelValueDescription;
               AV53i = (long)(AV53i+1);
               AV78GXV1 = (int)(AV78GXV1+1);
            }
            HEW0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Tipo", ""), 25, Gx_line+0, 152, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFParametroMudanzaTipo_SelDscs, "")), 152, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72TFParametroMudanzaTitulo_Sel)) )
         {
            AV52TempBoolean = (bool)(((StringUtil.StrCmp(AV72TFParametroMudanzaTitulo_Sel, "<#Empty#>")==0)));
            AV72TFParametroMudanzaTitulo_Sel = (AV52TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV72TFParametroMudanzaTitulo_Sel);
            HEW0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Título", ""), 25, Gx_line+0, 152, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV72TFParametroMudanzaTitulo_Sel, "")), 152, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV72TFParametroMudanzaTitulo_Sel = (AV52TempBoolean ? "<#Empty#>" : AV72TFParametroMudanzaTitulo_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71TFParametroMudanzaTitulo)) )
            {
               HEW0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Título", ""), 25, Gx_line+0, 152, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71TFParametroMudanzaTitulo, "")), 152, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41TFParametroMudanzaNombre_Sel)) )
         {
            AV52TempBoolean = (bool)(((StringUtil.StrCmp(AV41TFParametroMudanzaNombre_Sel, "<#Empty#>")==0)));
            AV41TFParametroMudanzaNombre_Sel = (AV52TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV41TFParametroMudanzaNombre_Sel);
            HEW0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 152, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFParametroMudanzaNombre_Sel, "")), 152, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV41TFParametroMudanzaNombre_Sel = (AV52TempBoolean ? "<#Empty#>" : AV41TFParametroMudanzaNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFParametroMudanzaNombre)) )
            {
               HEW0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 152, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFParametroMudanzaNombre, "")), 152, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67TFParametroMudanzaDescripcion_Sel)) )
         {
            AV52TempBoolean = (bool)(((StringUtil.StrCmp(AV67TFParametroMudanzaDescripcion_Sel, "<#Empty#>")==0)));
            AV67TFParametroMudanzaDescripcion_Sel = (AV52TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV67TFParametroMudanzaDescripcion_Sel);
            HEW0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Información", ""), 25, Gx_line+0, 152, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67TFParametroMudanzaDescripcion_Sel, "")), 152, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV67TFParametroMudanzaDescripcion_Sel = (AV52TempBoolean ? "<#Empty#>" : AV67TFParametroMudanzaDescripcion_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66TFParametroMudanzaDescripcion)) )
            {
               HEW0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Información", ""), 25, Gx_line+0, 152, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66TFParametroMudanzaDescripcion, "")), 152, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV42TFParametroMudanzaValor) && (Convert.ToDecimal(0)==AV43TFParametroMudanzaValor_To) ) )
         {
            HEW0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Valor", ""), 25, Gx_line+0, 152, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42TFParametroMudanzaValor, "ZZZZZZZZZZZZZZ9.99")), 152, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV50TFParametroMudanzaValor_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Valor", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HEW0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50TFParametroMudanzaValor_To_Description, "")), 25, Gx_line+0, 152, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV43TFParametroMudanzaValor_To, "ZZZZZZZZZZZZZZ9.99")), 152, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         AV47TFParametroMudanzaUnidad_Sels.FromJSonString(AV44TFParametroMudanzaUnidad_SelsJson, null);
         if ( ! ( AV47TFParametroMudanzaUnidad_Sels.Count == 0 ) )
         {
            AV53i = 1;
            AV79GXV2 = 1;
            while ( AV79GXV2 <= AV47TFParametroMudanzaUnidad_Sels.Count )
            {
               AV46TFParametroMudanzaUnidad_Sel = AV47TFParametroMudanzaUnidad_Sels.GetString(AV79GXV2);
               if ( AV53i == 1 )
               {
                  AV45TFParametroMudanzaUnidad_SelDscs = "";
               }
               else
               {
                  AV45TFParametroMudanzaUnidad_SelDscs += ", ";
               }
               AV51FilterTFParametroMudanzaUnidad_SelValueDescription = context.GetMessage( gxdomainunidadmedida.getDescription(context,AV46TFParametroMudanzaUnidad_Sel), "");
               AV45TFParametroMudanzaUnidad_SelDscs += AV51FilterTFParametroMudanzaUnidad_SelValueDescription;
               AV53i = (long)(AV53i+1);
               AV79GXV2 = (int)(AV79GXV2+1);
            }
            HEW0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Unidad", ""), 25, Gx_line+0, 152, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45TFParametroMudanzaUnidad_SelDscs, "")), 152, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (0==AV68TFParametroMudanzaPisoElev) && (0==AV69TFParametroMudanzaPisoElev_To) ) )
         {
            HEW0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Piso (elevación)", ""), 25, Gx_line+0, 152, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV68TFParametroMudanzaPisoElev), "ZZZ9")), 152, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV70TFParametroMudanzaPisoElev_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Piso (elevación)", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HEW0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70TFParametroMudanzaPisoElev_To_Description, "")), 25, Gx_line+0, 152, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV69TFParametroMudanzaPisoElev_To), "ZZZ9")), 152, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! (0==AV73TFParametroMudanzaActivo_Sel) )
         {
            if ( AV73TFParametroMudanzaActivo_Sel == 1 )
            {
               AV74FilterTFParametroMudanzaActivo_SelValueDescription = context.GetMessage( "WWP_TSChecked", "");
            }
            else if ( AV73TFParametroMudanzaActivo_Sel == 2 )
            {
               AV74FilterTFParametroMudanzaActivo_SelValueDescription = context.GetMessage( "WWP_TSUnChecked", "");
            }
            HEW0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Mudanza Activo", ""), 25, Gx_line+0, 152, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74FilterTFParametroMudanzaActivo_SelValueDescription, "")), 152, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HEW0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HEW0( false, 36) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Mudanza Id", ""), 30, Gx_line+10, 102, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Tipo", ""), 106, Gx_line+10, 178, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Título", ""), 182, Gx_line+10, 254, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 258, Gx_line+10, 330, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Información", ""), 334, Gx_line+10, 406, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Valor", ""), 410, Gx_line+10, 482, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Unidad", ""), 486, Gx_line+10, 558, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Piso (elevación)", ""), 562, Gx_line+10, 634, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Mudanza Imagen", ""), 638, Gx_line+10, 710, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Mudanza Activo", ""), 714, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV81Parametromudanzawwds_1_filterfulltext = AV13FilterFullText;
         AV82Parametromudanzawwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV83Parametromudanzawwds_3_parametromudanzatipo1 = AV15ParametroMudanzaTipo1;
         AV84Parametromudanzawwds_4_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV85Parametromudanzawwds_5_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV86Parametromudanzawwds_6_parametromudanzatipo2 = AV21ParametroMudanzaTipo2;
         AV87Parametromudanzawwds_7_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV88Parametromudanzawwds_8_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV89Parametromudanzawwds_9_parametromudanzatipo3 = AV25ParametroMudanzaTipo3;
         AV90Parametromudanzawwds_10_tfparametromudanzaid = AV34TFParametroMudanzaId;
         AV91Parametromudanzawwds_11_tfparametromudanzaid_to = AV35TFParametroMudanzaId_To;
         AV92Parametromudanzawwds_12_tfparametromudanzatipo_sels = AV39TFParametroMudanzaTipo_Sels;
         AV93Parametromudanzawwds_13_tfparametromudanzatitulo = AV71TFParametroMudanzaTitulo;
         AV94Parametromudanzawwds_14_tfparametromudanzatitulo_sel = AV72TFParametroMudanzaTitulo_Sel;
         AV95Parametromudanzawwds_15_tfparametromudanzanombre = AV40TFParametroMudanzaNombre;
         AV96Parametromudanzawwds_16_tfparametromudanzanombre_sel = AV41TFParametroMudanzaNombre_Sel;
         AV97Parametromudanzawwds_17_tfparametromudanzadescripcion = AV66TFParametroMudanzaDescripcion;
         AV98Parametromudanzawwds_18_tfparametromudanzadescripcion_sel = AV67TFParametroMudanzaDescripcion_Sel;
         AV99Parametromudanzawwds_19_tfparametromudanzavalor = AV42TFParametroMudanzaValor;
         AV100Parametromudanzawwds_20_tfparametromudanzavalor_to = AV43TFParametroMudanzaValor_To;
         AV101Parametromudanzawwds_21_tfparametromudanzaunidad_sels = AV47TFParametroMudanzaUnidad_Sels;
         AV102Parametromudanzawwds_22_tfparametromudanzapisoelev = AV68TFParametroMudanzaPisoElev;
         AV103Parametromudanzawwds_23_tfparametromudanzapisoelev_to = AV69TFParametroMudanzaPisoElev_To;
         AV104Parametromudanzawwds_24_tfparametromudanzaactivo_sel = AV73TFParametroMudanzaActivo_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A731ParametroMudanzaTipo ,
                                              AV92Parametromudanzawwds_12_tfparametromudanzatipo_sels ,
                                              A734ParametroMudanzaUnidad ,
                                              AV101Parametromudanzawwds_21_tfparametromudanzaunidad_sels ,
                                              AV82Parametromudanzawwds_2_dynamicfiltersselector1 ,
                                              AV83Parametromudanzawwds_3_parametromudanzatipo1 ,
                                              AV84Parametromudanzawwds_4_dynamicfiltersenabled2 ,
                                              AV85Parametromudanzawwds_5_dynamicfiltersselector2 ,
                                              AV86Parametromudanzawwds_6_parametromudanzatipo2 ,
                                              AV87Parametromudanzawwds_7_dynamicfiltersenabled3 ,
                                              AV88Parametromudanzawwds_8_dynamicfiltersselector3 ,
                                              AV89Parametromudanzawwds_9_parametromudanzatipo3 ,
                                              AV90Parametromudanzawwds_10_tfparametromudanzaid ,
                                              AV91Parametromudanzawwds_11_tfparametromudanzaid_to ,
                                              AV92Parametromudanzawwds_12_tfparametromudanzatipo_sels.Count ,
                                              AV94Parametromudanzawwds_14_tfparametromudanzatitulo_sel ,
                                              AV93Parametromudanzawwds_13_tfparametromudanzatitulo ,
                                              AV96Parametromudanzawwds_16_tfparametromudanzanombre_sel ,
                                              AV95Parametromudanzawwds_15_tfparametromudanzanombre ,
                                              AV98Parametromudanzawwds_18_tfparametromudanzadescripcion_sel ,
                                              AV97Parametromudanzawwds_17_tfparametromudanzadescripcion ,
                                              AV99Parametromudanzawwds_19_tfparametromudanzavalor ,
                                              AV100Parametromudanzawwds_20_tfparametromudanzavalor_to ,
                                              AV101Parametromudanzawwds_21_tfparametromudanzaunidad_sels.Count ,
                                              AV102Parametromudanzawwds_22_tfparametromudanzapisoelev ,
                                              AV103Parametromudanzawwds_23_tfparametromudanzapisoelev_to ,
                                              AV104Parametromudanzawwds_24_tfparametromudanzaactivo_sel ,
                                              A730ParametroMudanzaId ,
                                              A869ParametroMudanzaTitulo ,
                                              A732ParametroMudanzaNombre ,
                                              A812ParametroMudanzaDescripcion ,
                                              A733ParametroMudanzaValor ,
                                              A818ParametroMudanzaPisoElev ,
                                              A877ParametroMudanzaActivo ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              AV81Parametromudanzawwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV93Parametromudanzawwds_13_tfparametromudanzatitulo = StringUtil.Concat( StringUtil.RTrim( AV93Parametromudanzawwds_13_tfparametromudanzatitulo), "%", "");
         lV95Parametromudanzawwds_15_tfparametromudanzanombre = StringUtil.Concat( StringUtil.RTrim( AV95Parametromudanzawwds_15_tfparametromudanzanombre), "%", "");
         lV97Parametromudanzawwds_17_tfparametromudanzadescripcion = StringUtil.Concat( StringUtil.RTrim( AV97Parametromudanzawwds_17_tfparametromudanzadescripcion), "%", "");
         /* Using cursor P00EW2 */
         pr_default.execute(0, new Object[] {AV83Parametromudanzawwds_3_parametromudanzatipo1, AV86Parametromudanzawwds_6_parametromudanzatipo2, AV89Parametromudanzawwds_9_parametromudanzatipo3, AV90Parametromudanzawwds_10_tfparametromudanzaid, AV91Parametromudanzawwds_11_tfparametromudanzaid_to, lV93Parametromudanzawwds_13_tfparametromudanzatitulo, AV94Parametromudanzawwds_14_tfparametromudanzatitulo_sel, lV95Parametromudanzawwds_15_tfparametromudanzanombre, AV96Parametromudanzawwds_16_tfparametromudanzanombre_sel, lV97Parametromudanzawwds_17_tfparametromudanzadescripcion, AV98Parametromudanzawwds_18_tfparametromudanzadescripcion_sel, AV99Parametromudanzawwds_19_tfparametromudanzavalor, AV100Parametromudanzawwds_20_tfparametromudanzavalor_to, AV102Parametromudanzawwds_22_tfparametromudanzapisoelev, AV103Parametromudanzawwds_23_tfparametromudanzapisoelev_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A877ParametroMudanzaActivo = P00EW2_A877ParametroMudanzaActivo[0];
            A818ParametroMudanzaPisoElev = P00EW2_A818ParametroMudanzaPisoElev[0];
            A733ParametroMudanzaValor = P00EW2_A733ParametroMudanzaValor[0];
            A812ParametroMudanzaDescripcion = P00EW2_A812ParametroMudanzaDescripcion[0];
            A732ParametroMudanzaNombre = P00EW2_A732ParametroMudanzaNombre[0];
            A869ParametroMudanzaTitulo = P00EW2_A869ParametroMudanzaTitulo[0];
            A730ParametroMudanzaId = P00EW2_A730ParametroMudanzaId[0];
            A734ParametroMudanzaUnidad = P00EW2_A734ParametroMudanzaUnidad[0];
            A731ParametroMudanzaTipo = P00EW2_A731ParametroMudanzaTipo[0];
            A40000ParametroMudanzaImagen_GXI = P00EW2_A40000ParametroMudanzaImagen_GXI[0];
            A870ParametroMudanzaImagen = P00EW2_A870ParametroMudanzaImagen[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Parametromudanzawwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A730ParametroMudanzaId), 4, 0) , StringUtil.PadR( "%" + AV81Parametromudanzawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "tipo inmueble casa", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoInmuebleCasa") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "tipo estacionamiento", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoEstacionamiento") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "tipo vehiculo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoVehiculo") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "electro hogar", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaHogar") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "item adicional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemAdicional") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "peaje", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "Peaje") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "tipo inmueble apto", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoInmuebleApto") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "mobiliario", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaMobiliario") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "exterior y jardín", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaExterior") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "decoración", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaDecoracion") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaOtros") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "escalera", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "Escalera") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "ascensor", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "Ascensor") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "esca+asce", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "EscaAsce") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "precio embalaje", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "PrecioEmbalaje") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "precio elevacion", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "PrecioElevacion") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "precio base", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "PrecioBase") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "tiempox km", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TiempoxKm") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "tiempox m3", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TiempoxM3") == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A869ParametroMudanzaTitulo) , StringUtil.PadR( "%" + StringUtil.Upper( AV81Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A732ParametroMudanzaNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV81Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A812ParametroMudanzaDescripcion) , StringUtil.PadR( "%" + StringUtil.Upper( AV81Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A733ParametroMudanzaValor, 18, 2) , StringUtil.PadR( "%" + AV81Parametromudanzawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "m3", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "m3") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pesos", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "$") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "unidades", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "u") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "minutos", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "mi") == 0 ) ) || ( StringUtil.Like( "%" , StringUtil.PadR( "%" + StringUtil.Lower( AV81Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "%") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "min/m3", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV81Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "mm") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A818ParametroMudanzaPisoElev), 4, 0) , StringUtil.PadR( "%" + AV81Parametromudanzawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) )
            )
            {
               AV28ParametroMudanzaTipoDescription = context.GetMessage( gxdomaintipomudanza.getDescription(context,A731ParametroMudanzaTipo), "");
               AV29ParametroMudanzaUnidadDescription = context.GetMessage( gxdomainunidadmedida.getDescription(context,A734ParametroMudanzaUnidad), "");
               /* Execute user subroutine: 'BEFOREPRINTLINE' */
               S144 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               HEW0( false, 35) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A730ParametroMudanzaId), "ZZZ9")), 30, Gx_line+10, 102, Gx_line+24, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28ParametroMudanzaTipoDescription, "")), 106, Gx_line+10, 178, Gx_line+24, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A869ParametroMudanzaTitulo, "")), 182, Gx_line+10, 254, Gx_line+24, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A732ParametroMudanzaNombre, "")), 258, Gx_line+10, 330, Gx_line+24, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A812ParametroMudanzaDescripcion, "")), 334, Gx_line+10, 406, Gx_line+24, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A733ParametroMudanzaValor, "ZZZZZZZZZZZZZZ9.99")), 410, Gx_line+10, 482, Gx_line+24, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29ParametroMudanzaUnidadDescription, "")), 486, Gx_line+10, 558, Gx_line+24, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A818ParametroMudanzaPisoElev), "ZZZ9")), 562, Gx_line+10, 634, Gx_line+24, 2+16, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A870ParametroMudanzaImagen)) ? A40000ParametroMudanzaImagen_GXI : A870ParametroMudanzaImagen);
               getPrinter().GxDrawBitMap(sImgUrl, 638, Gx_line+10, 710, Gx_line+24) ;
               getPrinter().GxDrawText(StringUtil.BoolToStr( A877ParametroMudanzaActivo), 714, Gx_line+10, 787, Gx_line+24, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV30Session.Get("ParametroMudanzaWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ParametroMudanzaWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("ParametroMudanzaWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV105GXV3 = 1;
         while ( AV105GXV3 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV105GXV3));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZAID") == 0 )
            {
               AV34TFParametroMudanzaId = (short)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV35TFParametroMudanzaId_To = (short)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZATIPO_SEL") == 0 )
            {
               AV36TFParametroMudanzaTipo_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV39TFParametroMudanzaTipo_Sels.FromJSonString(AV36TFParametroMudanzaTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZATITULO") == 0 )
            {
               AV71TFParametroMudanzaTitulo = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZATITULO_SEL") == 0 )
            {
               AV72TFParametroMudanzaTitulo_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZANOMBRE") == 0 )
            {
               AV40TFParametroMudanzaNombre = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZANOMBRE_SEL") == 0 )
            {
               AV41TFParametroMudanzaNombre_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZADESCRIPCION") == 0 )
            {
               AV66TFParametroMudanzaDescripcion = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZADESCRIPCION_SEL") == 0 )
            {
               AV67TFParametroMudanzaDescripcion_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZAVALOR") == 0 )
            {
               AV42TFParametroMudanzaValor = NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, ".");
               AV43TFParametroMudanzaValor_To = NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZAUNIDAD_SEL") == 0 )
            {
               AV44TFParametroMudanzaUnidad_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV47TFParametroMudanzaUnidad_Sels.FromJSonString(AV44TFParametroMudanzaUnidad_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZAPISOELEV") == 0 )
            {
               AV68TFParametroMudanzaPisoElev = (short)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV69TFParametroMudanzaPisoElev_To = (short)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZAACTIVO_SEL") == 0 )
            {
               AV73TFParametroMudanzaActivo_Sel = (short)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV105GXV3 = (int)(AV105GXV3+1);
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

      protected void HEW0( bool bFoot ,
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
                  AV62PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV59DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+39, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62PageInfo, "")), 30, Gx_line+15, 409, Gx_line+29, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59DateInfo, "")), 409, Gx_line+15, 789, Gx_line+29, 2, 0, 0, 0) ;
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
               AV57AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV63Phone = "+1 550 8923";
               AV61Mail = "info@mail.com";
               AV65Website = "http://www.web.com";
               AV54AddressLine1 = "French Boulevard 2859";
               AV55AddressLine2 = "Downtown";
               AV56AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+107, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57AppName, "")), 30, Gx_line+30, 283, Gx_line+44, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64Title, "")), 30, Gx_line+44, 283, Gx_line+77, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63Phone, "")), 283, Gx_line+30, 536, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61Mail, "")), 283, Gx_line+45, 536, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65Website, "")), 283, Gx_line+60, 536, Gx_line+77, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55AddressLine2, "")), 536, Gx_line+45, 789, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56AddressLine3, "")), 536, Gx_line+60, 789, Gx_line+77, 2, 0, 0, 0) ;
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
         AV64Title = "";
         AV13FilterFullText = "";
         AV32GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV15ParametroMudanzaTipo1 = "";
         AV18FilterParametroMudanzaTipo1ValueDescription = "";
         AV17FilterParametroMudanzaTipoValueDescription = "";
         AV20DynamicFiltersSelector2 = "";
         AV21ParametroMudanzaTipo2 = "";
         AV22FilterParametroMudanzaTipo2ValueDescription = "";
         AV24DynamicFiltersSelector3 = "";
         AV25ParametroMudanzaTipo3 = "";
         AV26FilterParametroMudanzaTipo3ValueDescription = "";
         AV48TFParametroMudanzaId_To_Description = "";
         AV39TFParametroMudanzaTipo_Sels = new GxSimpleCollection<string>();
         AV36TFParametroMudanzaTipo_SelsJson = "";
         AV38TFParametroMudanzaTipo_Sel = "";
         AV37TFParametroMudanzaTipo_SelDscs = "";
         AV49FilterTFParametroMudanzaTipo_SelValueDescription = "";
         AV72TFParametroMudanzaTitulo_Sel = "";
         AV71TFParametroMudanzaTitulo = "";
         AV41TFParametroMudanzaNombre_Sel = "";
         AV40TFParametroMudanzaNombre = "";
         AV67TFParametroMudanzaDescripcion_Sel = "";
         AV66TFParametroMudanzaDescripcion = "";
         AV50TFParametroMudanzaValor_To_Description = "";
         AV47TFParametroMudanzaUnidad_Sels = new GxSimpleCollection<string>();
         AV44TFParametroMudanzaUnidad_SelsJson = "";
         AV46TFParametroMudanzaUnidad_Sel = "";
         AV45TFParametroMudanzaUnidad_SelDscs = "";
         AV51FilterTFParametroMudanzaUnidad_SelValueDescription = "";
         AV70TFParametroMudanzaPisoElev_To_Description = "";
         AV74FilterTFParametroMudanzaActivo_SelValueDescription = "";
         AV81Parametromudanzawwds_1_filterfulltext = "";
         AV82Parametromudanzawwds_2_dynamicfiltersselector1 = "";
         AV83Parametromudanzawwds_3_parametromudanzatipo1 = "";
         AV85Parametromudanzawwds_5_dynamicfiltersselector2 = "";
         AV86Parametromudanzawwds_6_parametromudanzatipo2 = "";
         AV88Parametromudanzawwds_8_dynamicfiltersselector3 = "";
         AV89Parametromudanzawwds_9_parametromudanzatipo3 = "";
         AV92Parametromudanzawwds_12_tfparametromudanzatipo_sels = new GxSimpleCollection<string>();
         AV93Parametromudanzawwds_13_tfparametromudanzatitulo = "";
         AV94Parametromudanzawwds_14_tfparametromudanzatitulo_sel = "";
         AV95Parametromudanzawwds_15_tfparametromudanzanombre = "";
         AV96Parametromudanzawwds_16_tfparametromudanzanombre_sel = "";
         AV97Parametromudanzawwds_17_tfparametromudanzadescripcion = "";
         AV98Parametromudanzawwds_18_tfparametromudanzadescripcion_sel = "";
         AV101Parametromudanzawwds_21_tfparametromudanzaunidad_sels = new GxSimpleCollection<string>();
         lV81Parametromudanzawwds_1_filterfulltext = "";
         lV93Parametromudanzawwds_13_tfparametromudanzatitulo = "";
         lV95Parametromudanzawwds_15_tfparametromudanzanombre = "";
         lV97Parametromudanzawwds_17_tfparametromudanzadescripcion = "";
         A731ParametroMudanzaTipo = "";
         A734ParametroMudanzaUnidad = "";
         A869ParametroMudanzaTitulo = "";
         A732ParametroMudanzaNombre = "";
         A812ParametroMudanzaDescripcion = "";
         P00EW2_A877ParametroMudanzaActivo = new bool[] {false} ;
         P00EW2_A818ParametroMudanzaPisoElev = new short[1] ;
         P00EW2_A733ParametroMudanzaValor = new decimal[1] ;
         P00EW2_A812ParametroMudanzaDescripcion = new string[] {""} ;
         P00EW2_A732ParametroMudanzaNombre = new string[] {""} ;
         P00EW2_A869ParametroMudanzaTitulo = new string[] {""} ;
         P00EW2_A730ParametroMudanzaId = new short[1] ;
         P00EW2_A734ParametroMudanzaUnidad = new string[] {""} ;
         P00EW2_A731ParametroMudanzaTipo = new string[] {""} ;
         P00EW2_A40000ParametroMudanzaImagen_GXI = new string[] {""} ;
         P00EW2_A870ParametroMudanzaImagen = new string[] {""} ;
         A40000ParametroMudanzaImagen_GXI = "";
         A870ParametroMudanzaImagen = "";
         AV28ParametroMudanzaTipoDescription = "";
         AV29ParametroMudanzaUnidadDescription = "";
         sImgUrl = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV62PageInfo = "";
         AV59DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV57AppName = "";
         AV63Phone = "";
         AV61Mail = "";
         AV65Website = "";
         AV54AddressLine1 = "";
         AV55AddressLine2 = "";
         AV56AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.parametromudanzawwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00EW2_A877ParametroMudanzaActivo, P00EW2_A818ParametroMudanzaPisoElev, P00EW2_A733ParametroMudanzaValor, P00EW2_A812ParametroMudanzaDescripcion, P00EW2_A732ParametroMudanzaNombre, P00EW2_A869ParametroMudanzaTitulo, P00EW2_A730ParametroMudanzaId, P00EW2_A734ParametroMudanzaUnidad, P00EW2_A731ParametroMudanzaTipo, P00EW2_A40000ParametroMudanzaImagen_GXI,
               P00EW2_A870ParametroMudanzaImagen
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV75Pgmname = "ParametroMudanzaWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV75Pgmname = "ParametroMudanzaWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV34TFParametroMudanzaId ;
      private short AV35TFParametroMudanzaId_To ;
      private short AV68TFParametroMudanzaPisoElev ;
      private short AV69TFParametroMudanzaPisoElev_To ;
      private short AV73TFParametroMudanzaActivo_Sel ;
      private short AV90Parametromudanzawwds_10_tfparametromudanzaid ;
      private short AV91Parametromudanzawwds_11_tfparametromudanzaid_to ;
      private short AV102Parametromudanzawwds_22_tfparametromudanzapisoelev ;
      private short AV103Parametromudanzawwds_23_tfparametromudanzapisoelev_to ;
      private short AV104Parametromudanzawwds_24_tfparametromudanzaactivo_sel ;
      private short A730ParametroMudanzaId ;
      private short A818ParametroMudanzaPisoElev ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV78GXV1 ;
      private int AV79GXV2 ;
      private int AV92Parametromudanzawwds_12_tfparametromudanzatipo_sels_Count ;
      private int AV101Parametromudanzawwds_21_tfparametromudanzaunidad_sels_Count ;
      private int AV105GXV3 ;
      private long AV53i ;
      private decimal AV42TFParametroMudanzaValor ;
      private decimal AV43TFParametroMudanzaValor_To ;
      private decimal AV99Parametromudanzawwds_19_tfparametromudanzavalor ;
      private decimal AV100Parametromudanzawwds_20_tfparametromudanzavalor_to ;
      private decimal A733ParametroMudanzaValor ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV75Pgmname ;
      private string GXEncryptionTmp ;
      private string AV46TFParametroMudanzaUnidad_Sel ;
      private string A734ParametroMudanzaUnidad ;
      private string sImgUrl ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV52TempBoolean ;
      private bool AV84Parametromudanzawwds_4_dynamicfiltersenabled2 ;
      private bool AV87Parametromudanzawwds_7_dynamicfiltersenabled3 ;
      private bool A877ParametroMudanzaActivo ;
      private bool AV12OrderedDsc ;
      private string AV36TFParametroMudanzaTipo_SelsJson ;
      private string AV44TFParametroMudanzaUnidad_SelsJson ;
      private string AV64Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV15ParametroMudanzaTipo1 ;
      private string AV18FilterParametroMudanzaTipo1ValueDescription ;
      private string AV17FilterParametroMudanzaTipoValueDescription ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV21ParametroMudanzaTipo2 ;
      private string AV22FilterParametroMudanzaTipo2ValueDescription ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV25ParametroMudanzaTipo3 ;
      private string AV26FilterParametroMudanzaTipo3ValueDescription ;
      private string AV48TFParametroMudanzaId_To_Description ;
      private string AV38TFParametroMudanzaTipo_Sel ;
      private string AV37TFParametroMudanzaTipo_SelDscs ;
      private string AV49FilterTFParametroMudanzaTipo_SelValueDescription ;
      private string AV72TFParametroMudanzaTitulo_Sel ;
      private string AV71TFParametroMudanzaTitulo ;
      private string AV41TFParametroMudanzaNombre_Sel ;
      private string AV40TFParametroMudanzaNombre ;
      private string AV67TFParametroMudanzaDescripcion_Sel ;
      private string AV66TFParametroMudanzaDescripcion ;
      private string AV50TFParametroMudanzaValor_To_Description ;
      private string AV45TFParametroMudanzaUnidad_SelDscs ;
      private string AV51FilterTFParametroMudanzaUnidad_SelValueDescription ;
      private string AV70TFParametroMudanzaPisoElev_To_Description ;
      private string AV74FilterTFParametroMudanzaActivo_SelValueDescription ;
      private string AV81Parametromudanzawwds_1_filterfulltext ;
      private string AV82Parametromudanzawwds_2_dynamicfiltersselector1 ;
      private string AV83Parametromudanzawwds_3_parametromudanzatipo1 ;
      private string AV85Parametromudanzawwds_5_dynamicfiltersselector2 ;
      private string AV86Parametromudanzawwds_6_parametromudanzatipo2 ;
      private string AV88Parametromudanzawwds_8_dynamicfiltersselector3 ;
      private string AV89Parametromudanzawwds_9_parametromudanzatipo3 ;
      private string AV93Parametromudanzawwds_13_tfparametromudanzatitulo ;
      private string AV94Parametromudanzawwds_14_tfparametromudanzatitulo_sel ;
      private string AV95Parametromudanzawwds_15_tfparametromudanzanombre ;
      private string AV96Parametromudanzawwds_16_tfparametromudanzanombre_sel ;
      private string AV97Parametromudanzawwds_17_tfparametromudanzadescripcion ;
      private string AV98Parametromudanzawwds_18_tfparametromudanzadescripcion_sel ;
      private string lV81Parametromudanzawwds_1_filterfulltext ;
      private string lV93Parametromudanzawwds_13_tfparametromudanzatitulo ;
      private string lV95Parametromudanzawwds_15_tfparametromudanzanombre ;
      private string lV97Parametromudanzawwds_17_tfparametromudanzadescripcion ;
      private string A731ParametroMudanzaTipo ;
      private string A869ParametroMudanzaTitulo ;
      private string A732ParametroMudanzaNombre ;
      private string A812ParametroMudanzaDescripcion ;
      private string A40000ParametroMudanzaImagen_GXI ;
      private string AV28ParametroMudanzaTipoDescription ;
      private string AV29ParametroMudanzaUnidadDescription ;
      private string AV62PageInfo ;
      private string AV59DateInfo ;
      private string AV57AppName ;
      private string AV63Phone ;
      private string AV61Mail ;
      private string AV65Website ;
      private string AV54AddressLine1 ;
      private string AV55AddressLine2 ;
      private string AV56AddressLine3 ;
      private string A870ParametroMudanzaImagen ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV39TFParametroMudanzaTipo_Sels ;
      private GxSimpleCollection<string> AV47TFParametroMudanzaUnidad_Sels ;
      private GxSimpleCollection<string> AV92Parametromudanzawwds_12_tfparametromudanzatipo_sels ;
      private GxSimpleCollection<string> AV101Parametromudanzawwds_21_tfparametromudanzaunidad_sels ;
      private IDataStoreProvider pr_default ;
      private bool[] P00EW2_A877ParametroMudanzaActivo ;
      private short[] P00EW2_A818ParametroMudanzaPisoElev ;
      private decimal[] P00EW2_A733ParametroMudanzaValor ;
      private string[] P00EW2_A812ParametroMudanzaDescripcion ;
      private string[] P00EW2_A732ParametroMudanzaNombre ;
      private string[] P00EW2_A869ParametroMudanzaTitulo ;
      private short[] P00EW2_A730ParametroMudanzaId ;
      private string[] P00EW2_A734ParametroMudanzaUnidad ;
      private string[] P00EW2_A731ParametroMudanzaTipo ;
      private string[] P00EW2_A40000ParametroMudanzaImagen_GXI ;
      private string[] P00EW2_A870ParametroMudanzaImagen ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
   }

   public class parametromudanzawwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00EW2( IGxContext context ,
                                             string A731ParametroMudanzaTipo ,
                                             GxSimpleCollection<string> AV92Parametromudanzawwds_12_tfparametromudanzatipo_sels ,
                                             string A734ParametroMudanzaUnidad ,
                                             GxSimpleCollection<string> AV101Parametromudanzawwds_21_tfparametromudanzaunidad_sels ,
                                             string AV82Parametromudanzawwds_2_dynamicfiltersselector1 ,
                                             string AV83Parametromudanzawwds_3_parametromudanzatipo1 ,
                                             bool AV84Parametromudanzawwds_4_dynamicfiltersenabled2 ,
                                             string AV85Parametromudanzawwds_5_dynamicfiltersselector2 ,
                                             string AV86Parametromudanzawwds_6_parametromudanzatipo2 ,
                                             bool AV87Parametromudanzawwds_7_dynamicfiltersenabled3 ,
                                             string AV88Parametromudanzawwds_8_dynamicfiltersselector3 ,
                                             string AV89Parametromudanzawwds_9_parametromudanzatipo3 ,
                                             short AV90Parametromudanzawwds_10_tfparametromudanzaid ,
                                             short AV91Parametromudanzawwds_11_tfparametromudanzaid_to ,
                                             int AV92Parametromudanzawwds_12_tfparametromudanzatipo_sels_Count ,
                                             string AV94Parametromudanzawwds_14_tfparametromudanzatitulo_sel ,
                                             string AV93Parametromudanzawwds_13_tfparametromudanzatitulo ,
                                             string AV96Parametromudanzawwds_16_tfparametromudanzanombre_sel ,
                                             string AV95Parametromudanzawwds_15_tfparametromudanzanombre ,
                                             string AV98Parametromudanzawwds_18_tfparametromudanzadescripcion_sel ,
                                             string AV97Parametromudanzawwds_17_tfparametromudanzadescripcion ,
                                             decimal AV99Parametromudanzawwds_19_tfparametromudanzavalor ,
                                             decimal AV100Parametromudanzawwds_20_tfparametromudanzavalor_to ,
                                             int AV101Parametromudanzawwds_21_tfparametromudanzaunidad_sels_Count ,
                                             short AV102Parametromudanzawwds_22_tfparametromudanzapisoelev ,
                                             short AV103Parametromudanzawwds_23_tfparametromudanzapisoelev_to ,
                                             short AV104Parametromudanzawwds_24_tfparametromudanzaactivo_sel ,
                                             short A730ParametroMudanzaId ,
                                             string A869ParametroMudanzaTitulo ,
                                             string A732ParametroMudanzaNombre ,
                                             string A812ParametroMudanzaDescripcion ,
                                             decimal A733ParametroMudanzaValor ,
                                             short A818ParametroMudanzaPisoElev ,
                                             bool A877ParametroMudanzaActivo ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             string AV81Parametromudanzawwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[15];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [ParametroMudanzaActivo], [ParametroMudanzaPisoElev], [ParametroMudanzaValor], [ParametroMudanzaDescripcion], [ParametroMudanzaNombre], [ParametroMudanzaTitulo], [ParametroMudanzaId], [ParametroMudanzaUnidad], [ParametroMudanzaTipo], [ParametroMudanzaImagen_GXI], [ParametroMudanzaImagen] FROM [ParametroMudanza]";
         if ( ( StringUtil.StrCmp(AV82Parametromudanzawwds_2_dynamicfiltersselector1, "PARAMETROMUDANZATIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Parametromudanzawwds_3_parametromudanzatipo1)) ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaTipo] = @AV83Parametromudanzawwds_3_parametromudanzatipo1)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( AV84Parametromudanzawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV85Parametromudanzawwds_5_dynamicfiltersselector2, "PARAMETROMUDANZATIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Parametromudanzawwds_6_parametromudanzatipo2)) ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaTipo] = @AV86Parametromudanzawwds_6_parametromudanzatipo2)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV87Parametromudanzawwds_7_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Parametromudanzawwds_8_dynamicfiltersselector3, "PARAMETROMUDANZATIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Parametromudanzawwds_9_parametromudanzatipo3)) ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaTipo] = @AV89Parametromudanzawwds_9_parametromudanzatipo3)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV90Parametromudanzawwds_10_tfparametromudanzaid) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaId] >= @AV90Parametromudanzawwds_10_tfparametromudanzaid)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV91Parametromudanzawwds_11_tfparametromudanzaid_to) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaId] <= @AV91Parametromudanzawwds_11_tfparametromudanzaid_to)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV92Parametromudanzawwds_12_tfparametromudanzatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV92Parametromudanzawwds_12_tfparametromudanzatipo_sels, "[ParametroMudanzaTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Parametromudanzawwds_14_tfparametromudanzatitulo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Parametromudanzawwds_13_tfparametromudanzatitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ParametroMudanzaTitulo]) like UPPER(@lV93Parametromudanzawwds_13_tfparametromudanzatitulo))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Parametromudanzawwds_14_tfparametromudanzatitulo_sel)) && ! ( StringUtil.StrCmp(AV94Parametromudanzawwds_14_tfparametromudanzatitulo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaTitulo] = @AV94Parametromudanzawwds_14_tfparametromudanzatitulo_sel)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( StringUtil.StrCmp(AV94Parametromudanzawwds_14_tfparametromudanzatitulo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroMudanzaTitulo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Parametromudanzawwds_16_tfparametromudanzanombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Parametromudanzawwds_15_tfparametromudanzanombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ParametroMudanzaNombre]) like UPPER(@lV95Parametromudanzawwds_15_tfparametromudanzanombre))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Parametromudanzawwds_16_tfparametromudanzanombre_sel)) && ! ( StringUtil.StrCmp(AV96Parametromudanzawwds_16_tfparametromudanzanombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaNombre] = @AV96Parametromudanzawwds_16_tfparametromudanzanombre_sel)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( StringUtil.StrCmp(AV96Parametromudanzawwds_16_tfparametromudanzanombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroMudanzaNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Parametromudanzawwds_18_tfparametromudanzadescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Parametromudanzawwds_17_tfparametromudanzadescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ParametroMudanzaDescripcion]) like UPPER(@lV97Parametromudanzawwds_17_tfparametromudanzadescripcion))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Parametromudanzawwds_18_tfparametromudanzadescripcion_sel)) && ! ( StringUtil.StrCmp(AV98Parametromudanzawwds_18_tfparametromudanzadescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaDescripcion] = @AV98Parametromudanzawwds_18_tfparametromudanzadescripcion_sel)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( StringUtil.StrCmp(AV98Parametromudanzawwds_18_tfparametromudanzadescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroMudanzaDescripcion] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV99Parametromudanzawwds_19_tfparametromudanzavalor) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaValor] >= @AV99Parametromudanzawwds_19_tfparametromudanzavalor)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV100Parametromudanzawwds_20_tfparametromudanzavalor_to) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaValor] <= @AV100Parametromudanzawwds_20_tfparametromudanzavalor_to)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( AV101Parametromudanzawwds_21_tfparametromudanzaunidad_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV101Parametromudanzawwds_21_tfparametromudanzaunidad_sels, "[ParametroMudanzaUnidad] IN (", ")")+")");
         }
         if ( ! (0==AV102Parametromudanzawwds_22_tfparametromudanzapisoelev) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaPisoElev] >= @AV102Parametromudanzawwds_22_tfparametromudanzapisoelev)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( ! (0==AV103Parametromudanzawwds_23_tfparametromudanzapisoelev_to) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaPisoElev] <= @AV103Parametromudanzawwds_23_tfparametromudanzapisoelev_to)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( AV104Parametromudanzawwds_24_tfparametromudanzaactivo_sel == 1 )
         {
            AddWhere(sWhereString, "([ParametroMudanzaActivo] = 1)");
         }
         if ( AV104Parametromudanzawwds_24_tfparametromudanzaactivo_sel == 2 )
         {
            AddWhere(sWhereString, "([ParametroMudanzaActivo] = 0)");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaTipo]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaTipo] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaId]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaId] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaTitulo]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaTitulo] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaNombre]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaDescripcion]";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaDescripcion] DESC";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaValor]";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaValor] DESC";
         }
         else if ( ( AV11OrderedBy == 7 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaUnidad]";
         }
         else if ( ( AV11OrderedBy == 7 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaUnidad] DESC";
         }
         else if ( ( AV11OrderedBy == 8 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaPisoElev]";
         }
         else if ( ( AV11OrderedBy == 8 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaPisoElev] DESC";
         }
         else if ( ( AV11OrderedBy == 9 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaActivo]";
         }
         else if ( ( AV11OrderedBy == 9 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ParametroMudanzaActivo] DESC";
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
                     return conditional_P00EW2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (int)dynConstraints[23] , (short)dynConstraints[24] , (short)dynConstraints[25] , (short)dynConstraints[26] , (short)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (decimal)dynConstraints[31] , (short)dynConstraints[32] , (bool)dynConstraints[33] , (short)dynConstraints[34] , (bool)dynConstraints[35] , (string)dynConstraints[36] );
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
          Object[] prmP00EW2;
          prmP00EW2 = new Object[] {
          new ParDef("@AV83Parametromudanzawwds_3_parametromudanzatipo1",GXType.NVarChar,20,0) ,
          new ParDef("@AV86Parametromudanzawwds_6_parametromudanzatipo2",GXType.NVarChar,20,0) ,
          new ParDef("@AV89Parametromudanzawwds_9_parametromudanzatipo3",GXType.NVarChar,20,0) ,
          new ParDef("@AV90Parametromudanzawwds_10_tfparametromudanzaid",GXType.Int16,4,0) ,
          new ParDef("@AV91Parametromudanzawwds_11_tfparametromudanzaid_to",GXType.Int16,4,0) ,
          new ParDef("@lV93Parametromudanzawwds_13_tfparametromudanzatitulo",GXType.VarChar,80,0) ,
          new ParDef("@AV94Parametromudanzawwds_14_tfparametromudanzatitulo_sel",GXType.NVarChar,80,0) ,
          new ParDef("@lV95Parametromudanzawwds_15_tfparametromudanzanombre",GXType.VarChar,100,0) ,
          new ParDef("@AV96Parametromudanzawwds_16_tfparametromudanzanombre_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV97Parametromudanzawwds_17_tfparametromudanzadescripcion",GXType.VarChar,100,0) ,
          new ParDef("@AV98Parametromudanzawwds_18_tfparametromudanzadescripcion_sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV99Parametromudanzawwds_19_tfparametromudanzavalor",GXType.Decimal,18,2) ,
          new ParDef("@AV100Parametromudanzawwds_20_tfparametromudanzavalor_to",GXType.Decimal,18,2) ,
          new ParDef("@AV102Parametromudanzawwds_22_tfparametromudanzapisoelev",GXType.Int16,4,0) ,
          new ParDef("@AV103Parametromudanzawwds_23_tfparametromudanzapisoelev_to",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EW2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EW2,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 2);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getMultimediaUri(10);
                ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(10));
                return;
       }
    }

 }

}
