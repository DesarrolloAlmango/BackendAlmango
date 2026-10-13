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
   public class mudanza1wwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public mudanza1wwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public mudanza1wwexportreport( IGxContext context )
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
         setOutputFileName("MudanzaWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMudanza", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV168Pgmname));
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
               AV125Title = context.GetMessage( "Lista de Mudanza", "");
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
            HFH0( true, 0) ;
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
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV27GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "MUDANZAASESOR") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV27GridStateDynamicFilter.gxTpr_Operator;
               AV16MudanzaAsesor1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16MudanzaAsesor1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterMudanzaAsesorDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Asesor", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterMudanzaAsesorDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Asesor", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV18MudanzaAsesor = AV16MudanzaAsesor1;
                  HFH0( false, 19) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterMudanzaAsesorDescription, "")), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18MudanzaAsesor, "")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
               }
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV19DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "MUDANZAASESOR") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV27GridStateDynamicFilter.gxTpr_Operator;
                  AV22MudanzaAsesor2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22MudanzaAsesor2)) )
                  {
                     if ( AV21DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterMudanzaAsesorDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Asesor", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV21DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterMudanzaAsesorDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Asesor", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV18MudanzaAsesor = AV22MudanzaAsesor2;
                     HFH0( false, 19) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterMudanzaAsesorDescription, "")), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18MudanzaAsesor, "")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                  }
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "MUDANZAASESOR") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV27GridStateDynamicFilter.gxTpr_Operator;
                     AV26MudanzaAsesor3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26MudanzaAsesor3)) )
                     {
                        if ( AV25DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterMudanzaAsesorDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Asesor", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV25DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterMudanzaAsesorDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Asesor", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV18MudanzaAsesor = AV26MudanzaAsesor3;
                        HFH0( false, 19) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterMudanzaAsesorDescription, "")), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18MudanzaAsesor, "")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV37TFMudanzaId) && (0==AV38TFMudanzaId_To) ) )
         {
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Id", ""), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV37TFMudanzaId), "ZZZZZZZZZZZZZZZZZ9")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV93TFMudanzaId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Id", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV93TFMudanzaId_To_Description, "")), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV38TFMudanzaId_To), "ZZZZZZZZZZZZZZZZZ9")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFMudanzaAsesor_Sel)) )
         {
            AV113TempBoolean = (bool)(((StringUtil.StrCmp(AV40TFMudanzaAsesor_Sel, "<#Empty#>")==0)));
            AV40TFMudanzaAsesor_Sel = (AV113TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV40TFMudanzaAsesor_Sel);
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Asesor", ""), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFMudanzaAsesor_Sel, "")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV40TFMudanzaAsesor_Sel = (AV113TempBoolean ? "<#Empty#>" : AV40TFMudanzaAsesor_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFMudanzaAsesor)) )
            {
               HFH0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Asesor", ""), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFMudanzaAsesor, "")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! ( (DateTime.MinValue==AV41TFMudanzaFechaAlta) && (DateTime.MinValue==AV42TFMudanzaFechaAlta_To) ) )
         {
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Fecha Alta", ""), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV41TFMudanzaFechaAlta, "99/99/99"), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV94TFMudanzaFechaAlta_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Fecha Alta", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV94TFMudanzaFechaAlta_To_Description, "")), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV42TFMudanzaFechaAlta_To, "99/99/99"), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (DateTime.MinValue==AV43TFMudanzaFechaServicio) && (DateTime.MinValue==AV44TFMudanzaFechaServicio_To) ) )
         {
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Fecha Servicio", ""), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV43TFMudanzaFechaServicio, "99/99/99"), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV95TFMudanzaFechaServicio_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Fecha Servicio", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV95TFMudanzaFechaServicio_To_Description, "")), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV44TFMudanzaFechaServicio_To, "99/99/99"), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         AV146TFMudanzaHoraServicio_Sels.FromJSonString(AV143TFMudanzaHoraServicio_SelsJson, null);
         if ( ! ( AV146TFMudanzaHoraServicio_Sels.Count == 0 ) )
         {
            AV114i = 1;
            AV171GXV1 = 1;
            while ( AV171GXV1 <= AV146TFMudanzaHoraServicio_Sels.Count )
            {
               AV145TFMudanzaHoraServicio_Sel = AV146TFMudanzaHoraServicio_Sels.GetString(AV171GXV1);
               if ( AV114i == 1 )
               {
                  AV144TFMudanzaHoraServicio_SelDscs = "";
               }
               else
               {
                  AV144TFMudanzaHoraServicio_SelDscs += ", ";
               }
               AV147FilterTFMudanzaHoraServicio_SelValueDescription = "";
               if ( StringUtil.StrCmp(StringUtil.Trim( AV145TFMudanzaHoraServicio_Sel), "08") == 0 )
               {
                  AV147FilterTFMudanzaHoraServicio_SelValueDescription = "08:00";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV145TFMudanzaHoraServicio_Sel), "09") == 0 )
               {
                  AV147FilterTFMudanzaHoraServicio_SelValueDescription = "09:00";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV145TFMudanzaHoraServicio_Sel), "10") == 0 )
               {
                  AV147FilterTFMudanzaHoraServicio_SelValueDescription = "10:00";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV145TFMudanzaHoraServicio_Sel), "11") == 0 )
               {
                  AV147FilterTFMudanzaHoraServicio_SelValueDescription = "11:00";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV145TFMudanzaHoraServicio_Sel), "12") == 0 )
               {
                  AV147FilterTFMudanzaHoraServicio_SelValueDescription = "12:00";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV145TFMudanzaHoraServicio_Sel), "13") == 0 )
               {
                  AV147FilterTFMudanzaHoraServicio_SelValueDescription = "13:00";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV145TFMudanzaHoraServicio_Sel), "14") == 0 )
               {
                  AV147FilterTFMudanzaHoraServicio_SelValueDescription = "14:00";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV145TFMudanzaHoraServicio_Sel), "15") == 0 )
               {
                  AV147FilterTFMudanzaHoraServicio_SelValueDescription = "15:00";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV145TFMudanzaHoraServicio_Sel), "16") == 0 )
               {
                  AV147FilterTFMudanzaHoraServicio_SelValueDescription = "16:00";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV145TFMudanzaHoraServicio_Sel), "17") == 0 )
               {
                  AV147FilterTFMudanzaHoraServicio_SelValueDescription = "17:00";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV145TFMudanzaHoraServicio_Sel), "18") == 0 )
               {
                  AV147FilterTFMudanzaHoraServicio_SelValueDescription = "18:00";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV145TFMudanzaHoraServicio_Sel), "19") == 0 )
               {
                  AV147FilterTFMudanzaHoraServicio_SelValueDescription = "19:00";
               }
               AV144TFMudanzaHoraServicio_SelDscs += AV147FilterTFMudanzaHoraServicio_SelValueDescription;
               AV114i = (long)(AV114i+1);
               AV171GXV1 = (int)(AV171GXV1+1);
            }
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Hora Servicio", ""), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV144TFMudanzaHoraServicio_SelDscs, "")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         AV153TFMudanzaRgoHoraservicio_Sels.FromJSonString(AV150TFMudanzaRgoHoraservicio_SelsJson, null);
         if ( ! ( AV153TFMudanzaRgoHoraservicio_Sels.Count == 0 ) )
         {
            AV114i = 1;
            AV172GXV2 = 1;
            while ( AV172GXV2 <= AV153TFMudanzaRgoHoraservicio_Sels.Count )
            {
               AV152TFMudanzaRgoHoraservicio_Sel = AV153TFMudanzaRgoHoraservicio_Sels.GetString(AV172GXV2);
               if ( AV114i == 1 )
               {
                  AV151TFMudanzaRgoHoraservicio_SelDscs = "";
               }
               else
               {
                  AV151TFMudanzaRgoHoraservicio_SelDscs += ", ";
               }
               AV163FilterTFMudanzaRgoHoraservicio_SelValueDescription = "";
               if ( StringUtil.StrCmp(StringUtil.Trim( AV152TFMudanzaRgoHoraservicio_Sel), "08-11") == 0 )
               {
                  AV163FilterTFMudanzaRgoHoraservicio_SelValueDescription = "08:00 - 11:00";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV152TFMudanzaRgoHoraservicio_Sel), "11-14") == 0 )
               {
                  AV163FilterTFMudanzaRgoHoraservicio_SelValueDescription = "11:00 - 14:00";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV152TFMudanzaRgoHoraservicio_Sel), "14-19") == 0 )
               {
                  AV163FilterTFMudanzaRgoHoraservicio_SelValueDescription = "14:00 - 19:00";
               }
               AV151TFMudanzaRgoHoraservicio_SelDscs += AV163FilterTFMudanzaRgoHoraservicio_SelValueDescription;
               AV114i = (long)(AV114i+1);
               AV172GXV2 = (int)(AV172GXV2+1);
            }
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Rgo Horaservicio", ""), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV151TFMudanzaRgoHoraservicio_SelDscs, "")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48TFMudanzaDireccionOrigen_Sel)) )
         {
            AV113TempBoolean = (bool)(((StringUtil.StrCmp(AV48TFMudanzaDireccionOrigen_Sel, "<#Empty#>")==0)));
            AV48TFMudanzaDireccionOrigen_Sel = (AV113TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV48TFMudanzaDireccionOrigen_Sel);
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Direccion Origen", ""), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48TFMudanzaDireccionOrigen_Sel, "")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV48TFMudanzaDireccionOrigen_Sel = (AV113TempBoolean ? "<#Empty#>" : AV48TFMudanzaDireccionOrigen_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47TFMudanzaDireccionOrigen)) )
            {
               HFH0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Direccion Origen", ""), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47TFMudanzaDireccionOrigen, "")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         AV157TFMudanzaPisoDptoOrigen_Sels.FromJSonString(AV154TFMudanzaPisoDptoOrigen_SelsJson, null);
         if ( ! ( AV157TFMudanzaPisoDptoOrigen_Sels.Count == 0 ) )
         {
            AV114i = 1;
            AV173GXV3 = 1;
            while ( AV173GXV3 <= AV157TFMudanzaPisoDptoOrigen_Sels.Count )
            {
               AV156TFMudanzaPisoDptoOrigen_Sel = AV157TFMudanzaPisoDptoOrigen_Sels.GetString(AV173GXV3);
               if ( AV114i == 1 )
               {
                  AV155TFMudanzaPisoDptoOrigen_SelDscs = "";
               }
               else
               {
                  AV155TFMudanzaPisoDptoOrigen_SelDscs += ", ";
               }
               AV155TFMudanzaPisoDptoOrigen_SelDscs += AV164FilterTFMudanzaPisoDptoOrigen_SelValueDescription;
               AV114i = (long)(AV114i+1);
               AV173GXV3 = (int)(AV173GXV3+1);
            }
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Dpto Origen", ""), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV155TFMudanzaPisoDptoOrigen_SelDscs, "")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50TFMudanzaDireccionDestino_Sel)) )
         {
            AV113TempBoolean = (bool)(((StringUtil.StrCmp(AV50TFMudanzaDireccionDestino_Sel, "<#Empty#>")==0)));
            AV50TFMudanzaDireccionDestino_Sel = (AV113TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV50TFMudanzaDireccionDestino_Sel);
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Direccion Destino", ""), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50TFMudanzaDireccionDestino_Sel, "")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV50TFMudanzaDireccionDestino_Sel = (AV113TempBoolean ? "<#Empty#>" : AV50TFMudanzaDireccionDestino_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49TFMudanzaDireccionDestino)) )
            {
               HFH0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Direccion Destino", ""), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49TFMudanzaDireccionDestino, "")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV159TFMudanzaPisoDptoDestino_Sel)) )
         {
            AV113TempBoolean = (bool)(((StringUtil.StrCmp(AV159TFMudanzaPisoDptoDestino_Sel, "<#Empty#>")==0)));
            AV159TFMudanzaPisoDptoDestino_Sel = (AV113TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV159TFMudanzaPisoDptoDestino_Sel);
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Dpto Destino", ""), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV159TFMudanzaPisoDptoDestino_Sel, "")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV159TFMudanzaPisoDptoDestino_Sel = (AV113TempBoolean ? "<#Empty#>" : AV159TFMudanzaPisoDptoDestino_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV158TFMudanzaPisoDptoDestino)) )
            {
               HFH0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Dpto Destino", ""), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV158TFMudanzaPisoDptoDestino, "")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV51TFMudanzaDistancia) && (Convert.ToDecimal(0)==AV52TFMudanzaDistancia_To) ) )
         {
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Distancia", ""), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51TFMudanzaDistancia, "ZZZZZZ9.99")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV97TFMudanzaDistancia_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Distancia", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV97TFMudanzaDistancia_To_Description, "")), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52TFMudanzaDistancia_To, "ZZZZZZ9.99")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         AV131TFMudanzaVehiculoSugerido_Sels.FromJSonString(AV128TFMudanzaVehiculoSugerido_SelsJson, null);
         if ( ! ( AV131TFMudanzaVehiculoSugerido_Sels.Count == 0 ) )
         {
            AV114i = 1;
            AV174GXV4 = 1;
            while ( AV174GXV4 <= AV131TFMudanzaVehiculoSugerido_Sels.Count )
            {
               AV130TFMudanzaVehiculoSugerido_Sel = ((string)AV131TFMudanzaVehiculoSugerido_Sels.Item(AV174GXV4));
               if ( AV114i == 1 )
               {
                  AV129TFMudanzaVehiculoSugerido_SelDscs = "";
               }
               else
               {
                  AV129TFMudanzaVehiculoSugerido_SelDscs += ", ";
               }
               AV129TFMudanzaVehiculoSugerido_SelDscs += AV136FilterTFMudanzaVehiculoSugerido_SelValueDescription;
               AV114i = (long)(AV114i+1);
               AV174GXV4 = (int)(AV174GXV4+1);
            }
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Vehiculo Sugerido", ""), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV129TFMudanzaVehiculoSugerido_SelDscs, "")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV165TFMudanzaPrecioBasexHora) && (Convert.ToDecimal(0)==AV166TFMudanzaPrecioBasexHora_To) ) )
         {
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Basex Hora", ""), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV165TFMudanzaPrecioBasexHora, "ZZZZZZZZZZZZZZ9.99")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV167TFMudanzaPrecioBasexHora_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Basex Hora", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV167TFMudanzaPrecioBasexHora_To_Description, "")), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV166TFMudanzaPrecioBasexHora_To, "ZZZZZZZZZZZZZZ9.99")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (0==AV57TFMudanzaPeajeCantidad) && (0==AV58TFMudanzaPeajeCantidad_To) ) )
         {
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Peaje Cantidad", ""), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV57TFMudanzaPeajeCantidad), "9")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV99TFMudanzaPeajeCantidad_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Peaje Cantidad", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV99TFMudanzaPeajeCantidad_To_Description, "")), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV58TFMudanzaPeajeCantidad_To), "9")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV59TFMudanzaPeajevalor) && (Convert.ToDecimal(0)==AV60TFMudanzaPeajevalor_To) ) )
         {
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Peajevalor", ""), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV59TFMudanzaPeajevalor, "ZZZZZZZZZZZZZZ9.99")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV100TFMudanzaPeajevalor_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Peajevalor", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV100TFMudanzaPeajevalor_To_Description, "")), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV60TFMudanzaPeajevalor_To, "ZZZZZZZZZZZZZZ9.99")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (0==AV61TFTipoInmuebleOrigenId) && (0==AV62TFTipoInmuebleOrigenId_To) ) )
         {
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Origen Id", ""), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV61TFTipoInmuebleOrigenId), "ZZZ9")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV101TFTipoInmuebleOrigenId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Origen Id", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV101TFTipoInmuebleOrigenId_To_Description, "")), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV62TFTipoInmuebleOrigenId_To), "ZZZ9")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65TFTipoInmuebleOrigenNombre_Sel)) )
         {
            AV113TempBoolean = (bool)(((StringUtil.StrCmp(AV65TFTipoInmuebleOrigenNombre_Sel, "<#Empty#>")==0)));
            AV65TFTipoInmuebleOrigenNombre_Sel = (AV113TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV65TFTipoInmuebleOrigenNombre_Sel);
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Origen Nombre", ""), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65TFTipoInmuebleOrigenNombre_Sel, "")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV65TFTipoInmuebleOrigenNombre_Sel = (AV113TempBoolean ? "<#Empty#>" : AV65TFTipoInmuebleOrigenNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV160TFTipoInmuebleOrigenNombre)) )
            {
               HFH0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Origen Nombre", ""), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV160TFTipoInmuebleOrigenNombre, "")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV67TFTipoInmuebleOrigenValor) && (Convert.ToDecimal(0)==AV68TFTipoInmuebleOrigenValor_To) ) )
         {
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Origen Valor", ""), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV67TFTipoInmuebleOrigenValor, "ZZZZZZZZZZZZZZ9.99")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV103TFTipoInmuebleOrigenValor_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Origen Valor", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV103TFTipoInmuebleOrigenValor_To_Description, "")), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV68TFTipoInmuebleOrigenValor_To, "ZZZZZZZZZZZZZZ9.99")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (0==AV69TFTipoInmuebleDestinoId) && (0==AV70TFTipoInmuebleDestinoId_To) ) )
         {
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Destino Id", ""), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV69TFTipoInmuebleDestinoId), "ZZZ9")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV104TFTipoInmuebleDestinoId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Destino Id", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV104TFTipoInmuebleDestinoId_To_Description, "")), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV70TFTipoInmuebleDestinoId_To), "ZZZ9")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73TFTipoInmuebleDestinoNombre_Sel)) )
         {
            AV113TempBoolean = (bool)(((StringUtil.StrCmp(AV73TFTipoInmuebleDestinoNombre_Sel, "<#Empty#>")==0)));
            AV73TFTipoInmuebleDestinoNombre_Sel = (AV113TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV73TFTipoInmuebleDestinoNombre_Sel);
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Destino Nombre", ""), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73TFTipoInmuebleDestinoNombre_Sel, "")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV73TFTipoInmuebleDestinoNombre_Sel = (AV113TempBoolean ? "<#Empty#>" : AV73TFTipoInmuebleDestinoNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV161TFTipoInmuebleDestinoNombre)) )
            {
               HFH0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Destino Nombre", ""), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV161TFTipoInmuebleDestinoNombre, "")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV75TFTipoInmuebleDestinoValor) && (Convert.ToDecimal(0)==AV76TFTipoInmuebleDestinoValor_To) ) )
         {
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Destino Valor", ""), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV75TFTipoInmuebleDestinoValor, "ZZZZZZZZZZZZZZ9.99")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV106TFTipoInmuebleDestinoValor_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Destino Valor", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV106TFTipoInmuebleDestinoValor_To_Description, "")), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV76TFTipoInmuebleDestinoValor_To, "ZZZZZZZZZZZZZZ9.99")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (0==AV77TFTipoEstacionamOrigenId) && (0==AV78TFTipoEstacionamOrigenId_To) ) )
         {
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Origen Id", ""), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV77TFTipoEstacionamOrigenId), "ZZZ9")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV107TFTipoEstacionamOrigenId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Origen Id", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV107TFTipoEstacionamOrigenId_To_Description, "")), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV78TFTipoEstacionamOrigenId_To), "ZZZ9")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         AV82TFTipoEstacionamOrigenNombre_Sels.FromJSonString(AV79TFTipoEstacionamOrigenNombre_SelsJson, null);
         if ( ! ( AV82TFTipoEstacionamOrigenNombre_Sels.Count == 0 ) )
         {
            AV114i = 1;
            AV175GXV5 = 1;
            while ( AV175GXV5 <= AV82TFTipoEstacionamOrigenNombre_Sels.Count )
            {
               AV81TFTipoEstacionamOrigenNombre_Sel = ((string)AV82TFTipoEstacionamOrigenNombre_Sels.Item(AV175GXV5));
               if ( AV114i == 1 )
               {
                  AV80TFTipoEstacionamOrigenNombre_SelDscs = "";
               }
               else
               {
                  AV80TFTipoEstacionamOrigenNombre_SelDscs += ", ";
               }
               AV80TFTipoEstacionamOrigenNombre_SelDscs += AV108FilterTFTipoEstacionamOrigenNombre_SelValueDescription;
               AV114i = (long)(AV114i+1);
               AV175GXV5 = (int)(AV175GXV5+1);
            }
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Origen Nombre", ""), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV80TFTipoEstacionamOrigenNombre_SelDscs, "")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV83TFTipoEstacionamOrigenValor) && (Convert.ToDecimal(0)==AV84TFTipoEstacionamOrigenValor_To) ) )
         {
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Origen Valor", ""), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV83TFTipoEstacionamOrigenValor, "ZZZZZZZZZZZZZZ9.99")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV109TFTipoEstacionamOrigenValor_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Origen Valor", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV109TFTipoEstacionamOrigenValor_To_Description, "")), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV84TFTipoEstacionamOrigenValor_To, "ZZZZZZZZZZZZZZ9.99")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (0==AV85TFTipoEstacionamDestinoId) && (0==AV86TFTipoEstacionamDestinoId_To) ) )
         {
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Destino Id", ""), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV85TFTipoEstacionamDestinoId), "ZZZ9")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV110TFTipoEstacionamDestinoId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Destino Id", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HFH0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV110TFTipoEstacionamDestinoId_To_Description, "")), 25, Gx_line+0, 149, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV86TFTipoEstacionamDestinoId_To), "ZZZ9")), 149, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HFH0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HFH0( false, 36) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Id", ""), 30, Gx_line+10, 56, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Asesor", ""), 60, Gx_line+10, 86, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Fecha Alta", ""), 90, Gx_line+10, 116, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Fecha Servicio", ""), 120, Gx_line+10, 146, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Hora Servicio", ""), 150, Gx_line+10, 176, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Rgo Horaservicio", ""), 180, Gx_line+10, 206, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Direccion Origen", ""), 210, Gx_line+10, 236, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Dpto Origen", ""), 240, Gx_line+10, 266, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Direccion Destino", ""), 270, Gx_line+10, 296, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Dpto Destino", ""), 300, Gx_line+10, 326, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Distancia", ""), 330, Gx_line+10, 356, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Vehiculo Sugerido", ""), 360, Gx_line+10, 386, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Basex Hora", ""), 390, Gx_line+10, 416, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Peaje Cantidad", ""), 420, Gx_line+10, 446, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Peajevalor", ""), 450, Gx_line+10, 476, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Origen Id", ""), 480, Gx_line+10, 506, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Origen Nombre", ""), 510, Gx_line+10, 537, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Origen Valor", ""), 541, Gx_line+10, 568, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Destino Id", ""), 572, Gx_line+10, 599, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Destino Nombre", ""), 603, Gx_line+10, 631, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Destino Valor", ""), 635, Gx_line+10, 662, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Origen Id", ""), 666, Gx_line+10, 693, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Origen Nombre", ""), 697, Gx_line+10, 725, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Origen Valor", ""), 729, Gx_line+10, 756, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Destino Id", ""), 760, Gx_line+10, 787, Gx_line+26, 2, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV177Mudanzawwds_1_filterfulltext = AV13FilterFullText;
         AV178Mudanzawwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV179Mudanzawwds_3_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV180Mudanzawwds_4_mudanzaasesor1 = AV16MudanzaAsesor1;
         AV181Mudanzawwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV182Mudanzawwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV183Mudanzawwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV184Mudanzawwds_8_mudanzaasesor2 = AV22MudanzaAsesor2;
         AV185Mudanzawwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV186Mudanzawwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV187Mudanzawwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV188Mudanzawwds_12_mudanzaasesor3 = AV26MudanzaAsesor3;
         AV189Mudanzawwds_13_tfmudanzaid = AV37TFMudanzaId;
         AV190Mudanzawwds_14_tfmudanzaid_to = AV38TFMudanzaId_To;
         AV191Mudanzawwds_15_tfmudanzaasesor = AV39TFMudanzaAsesor;
         AV192Mudanzawwds_16_tfmudanzaasesor_sel = AV40TFMudanzaAsesor_Sel;
         AV193Mudanzawwds_17_tfmudanzafechaalta = AV41TFMudanzaFechaAlta;
         AV194Mudanzawwds_18_tfmudanzafechaalta_to = AV42TFMudanzaFechaAlta_To;
         AV195Mudanzawwds_19_tfmudanzafechaservicio = AV43TFMudanzaFechaServicio;
         AV196Mudanzawwds_20_tfmudanzafechaservicio_to = AV44TFMudanzaFechaServicio_To;
         AV197Mudanzawwds_21_tfmudanzahoraservicio_sels = AV146TFMudanzaHoraServicio_Sels;
         AV198Mudanzawwds_22_tfmudanzargohoraservicio_sels = AV153TFMudanzaRgoHoraservicio_Sels;
         AV199Mudanzawwds_23_tfmudanzadireccionorigen = AV47TFMudanzaDireccionOrigen;
         AV200Mudanzawwds_24_tfmudanzadireccionorigen_sel = AV48TFMudanzaDireccionOrigen_Sel;
         AV201Mudanzawwds_25_tfmudanzapisodptoorigen_sels = AV157TFMudanzaPisoDptoOrigen_Sels;
         AV202Mudanzawwds_26_tfmudanzadirecciondestino = AV49TFMudanzaDireccionDestino;
         AV203Mudanzawwds_27_tfmudanzadirecciondestino_sel = AV50TFMudanzaDireccionDestino_Sel;
         AV204Mudanzawwds_28_tfmudanzapisodptodestino = AV158TFMudanzaPisoDptoDestino;
         AV205Mudanzawwds_29_tfmudanzapisodptodestino_sel = AV159TFMudanzaPisoDptoDestino_Sel;
         AV206Mudanzawwds_30_tfmudanzadistancia = AV51TFMudanzaDistancia;
         AV207Mudanzawwds_31_tfmudanzadistancia_to = AV52TFMudanzaDistancia_To;
         AV208Mudanzawwds_32_tfmudanzavehiculosugerido_sels = AV131TFMudanzaVehiculoSugerido_Sels;
         AV209Mudanzawwds_33_tfmudanzapreciobasexhora = AV165TFMudanzaPrecioBasexHora;
         AV210Mudanzawwds_34_tfmudanzapreciobasexhora_to = AV166TFMudanzaPrecioBasexHora_To;
         AV211Mudanzawwds_35_tfmudanzapeajecantidad = AV57TFMudanzaPeajeCantidad;
         AV212Mudanzawwds_36_tfmudanzapeajecantidad_to = AV58TFMudanzaPeajeCantidad_To;
         AV213Mudanzawwds_37_tfmudanzapeajevalor = AV59TFMudanzaPeajevalor;
         AV214Mudanzawwds_38_tfmudanzapeajevalor_to = AV60TFMudanzaPeajevalor_To;
         AV215Mudanzawwds_39_tftipoinmuebleorigenid = AV61TFTipoInmuebleOrigenId;
         AV216Mudanzawwds_40_tftipoinmuebleorigenid_to = AV62TFTipoInmuebleOrigenId_To;
         AV217Mudanzawwds_41_tftipoinmuebleorigennombre = AV160TFTipoInmuebleOrigenNombre;
         AV218Mudanzawwds_42_tftipoinmuebleorigennombre_sel = AV65TFTipoInmuebleOrigenNombre_Sel;
         AV219Mudanzawwds_43_tftipoinmuebleorigenvalor = AV67TFTipoInmuebleOrigenValor;
         AV220Mudanzawwds_44_tftipoinmuebleorigenvalor_to = AV68TFTipoInmuebleOrigenValor_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A739MudanzaHoraServicio ,
                                              AV197Mudanzawwds_21_tfmudanzahoraservicio_sels ,
                                              A776MudanzaRgoHoraservicio ,
                                              AV198Mudanzawwds_22_tfmudanzargohoraservicio_sels ,
                                              A777MudanzaPisoDptoOrigen ,
                                              AV201Mudanzawwds_25_tfmudanzapisodptoorigen_sels ,
                                              A742MudanzaVehiculoSugerido ,
                                              AV208Mudanzawwds_32_tfmudanzavehiculosugerido_sels ,
                                              AV177Mudanzawwds_1_filterfulltext ,
                                              AV178Mudanzawwds_2_dynamicfiltersselector1 ,
                                              AV179Mudanzawwds_3_dynamicfiltersoperator1 ,
                                              AV180Mudanzawwds_4_mudanzaasesor1 ,
                                              AV181Mudanzawwds_5_dynamicfiltersenabled2 ,
                                              AV182Mudanzawwds_6_dynamicfiltersselector2 ,
                                              AV183Mudanzawwds_7_dynamicfiltersoperator2 ,
                                              AV184Mudanzawwds_8_mudanzaasesor2 ,
                                              AV185Mudanzawwds_9_dynamicfiltersenabled3 ,
                                              AV186Mudanzawwds_10_dynamicfiltersselector3 ,
                                              AV187Mudanzawwds_11_dynamicfiltersoperator3 ,
                                              AV188Mudanzawwds_12_mudanzaasesor3 ,
                                              AV189Mudanzawwds_13_tfmudanzaid ,
                                              AV190Mudanzawwds_14_tfmudanzaid_to ,
                                              AV192Mudanzawwds_16_tfmudanzaasesor_sel ,
                                              AV191Mudanzawwds_15_tfmudanzaasesor ,
                                              AV193Mudanzawwds_17_tfmudanzafechaalta ,
                                              AV194Mudanzawwds_18_tfmudanzafechaalta_to ,
                                              AV195Mudanzawwds_19_tfmudanzafechaservicio ,
                                              AV196Mudanzawwds_20_tfmudanzafechaservicio_to ,
                                              AV197Mudanzawwds_21_tfmudanzahoraservicio_sels.Count ,
                                              AV198Mudanzawwds_22_tfmudanzargohoraservicio_sels.Count ,
                                              AV200Mudanzawwds_24_tfmudanzadireccionorigen_sel ,
                                              AV199Mudanzawwds_23_tfmudanzadireccionorigen ,
                                              AV201Mudanzawwds_25_tfmudanzapisodptoorigen_sels.Count ,
                                              AV203Mudanzawwds_27_tfmudanzadirecciondestino_sel ,
                                              AV202Mudanzawwds_26_tfmudanzadirecciondestino ,
                                              AV205Mudanzawwds_29_tfmudanzapisodptodestino_sel ,
                                              AV204Mudanzawwds_28_tfmudanzapisodptodestino ,
                                              AV206Mudanzawwds_30_tfmudanzadistancia ,
                                              AV207Mudanzawwds_31_tfmudanzadistancia_to ,
                                              AV208Mudanzawwds_32_tfmudanzavehiculosugerido_sels.Count ,
                                              AV209Mudanzawwds_33_tfmudanzapreciobasexhora ,
                                              AV210Mudanzawwds_34_tfmudanzapreciobasexhora_to ,
                                              AV211Mudanzawwds_35_tfmudanzapeajecantidad ,
                                              AV212Mudanzawwds_36_tfmudanzapeajecantidad_to ,
                                              AV213Mudanzawwds_37_tfmudanzapeajevalor ,
                                              AV214Mudanzawwds_38_tfmudanzapeajevalor_to ,
                                              AV215Mudanzawwds_39_tftipoinmuebleorigenid ,
                                              AV216Mudanzawwds_40_tftipoinmuebleorigenid_to ,
                                              AV218Mudanzawwds_42_tftipoinmuebleorigennombre_sel ,
                                              AV217Mudanzawwds_41_tftipoinmuebleorigennombre ,
                                              AV219Mudanzawwds_43_tftipoinmuebleorigenvalor ,
                                              AV220Mudanzawwds_44_tftipoinmuebleorigenvalor_to ,
                                              A735MudanzaId ,
                                              A736MudanzaAsesor ,
                                              A740MudanzaDireccionOrigen ,
                                              A741MudanzaDireccionDestino ,
                                              A778MudanzaPisoDptoDestino ,
                                              A762MudanzaDistancia ,
                                              A780MudanzaPrecioBasexHora ,
                                              A761MudanzaPeajeCantidad ,
                                              A760MudanzaPeajevalor ,
                                              A743TipoInmuebleOrigenId ,
                                              A755TipoInmuebleOrigenNombre ,
                                              A756TipoInmuebleOrigenValor ,
                                              A737MudanzaFechaAlta ,
                                              A738MudanzaFechaServicio ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV177Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV177Mudanzawwds_1_filterfulltext), "%", "");
         lV177Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV177Mudanzawwds_1_filterfulltext), "%", "");
         lV177Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV177Mudanzawwds_1_filterfulltext), "%", "");
         lV177Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV177Mudanzawwds_1_filterfulltext), "%", "");
         lV177Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV177Mudanzawwds_1_filterfulltext), "%", "");
         lV177Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV177Mudanzawwds_1_filterfulltext), "%", "");
         lV177Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV177Mudanzawwds_1_filterfulltext), "%", "");
         lV177Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV177Mudanzawwds_1_filterfulltext), "%", "");
         lV177Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV177Mudanzawwds_1_filterfulltext), "%", "");
         lV177Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV177Mudanzawwds_1_filterfulltext), "%", "");
         lV177Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV177Mudanzawwds_1_filterfulltext), "%", "");
         lV177Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV177Mudanzawwds_1_filterfulltext), "%", "");
         lV177Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV177Mudanzawwds_1_filterfulltext), "%", "");
         lV177Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV177Mudanzawwds_1_filterfulltext), "%", "");
         lV177Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV177Mudanzawwds_1_filterfulltext), "%", "");
         lV177Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV177Mudanzawwds_1_filterfulltext), "%", "");
         lV177Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV177Mudanzawwds_1_filterfulltext), "%", "");
         lV177Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV177Mudanzawwds_1_filterfulltext), "%", "");
         lV177Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV177Mudanzawwds_1_filterfulltext), "%", "");
         lV177Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV177Mudanzawwds_1_filterfulltext), "%", "");
         lV177Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV177Mudanzawwds_1_filterfulltext), "%", "");
         lV177Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV177Mudanzawwds_1_filterfulltext), "%", "");
         lV177Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV177Mudanzawwds_1_filterfulltext), "%", "");
         lV177Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV177Mudanzawwds_1_filterfulltext), "%", "");
         lV177Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV177Mudanzawwds_1_filterfulltext), "%", "");
         lV177Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV177Mudanzawwds_1_filterfulltext), "%", "");
         lV177Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV177Mudanzawwds_1_filterfulltext), "%", "");
         lV177Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV177Mudanzawwds_1_filterfulltext), "%", "");
         lV177Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV177Mudanzawwds_1_filterfulltext), "%", "");
         lV180Mudanzawwds_4_mudanzaasesor1 = StringUtil.Concat( StringUtil.RTrim( AV180Mudanzawwds_4_mudanzaasesor1), "%", "");
         lV180Mudanzawwds_4_mudanzaasesor1 = StringUtil.Concat( StringUtil.RTrim( AV180Mudanzawwds_4_mudanzaasesor1), "%", "");
         lV184Mudanzawwds_8_mudanzaasesor2 = StringUtil.Concat( StringUtil.RTrim( AV184Mudanzawwds_8_mudanzaasesor2), "%", "");
         lV184Mudanzawwds_8_mudanzaasesor2 = StringUtil.Concat( StringUtil.RTrim( AV184Mudanzawwds_8_mudanzaasesor2), "%", "");
         lV188Mudanzawwds_12_mudanzaasesor3 = StringUtil.Concat( StringUtil.RTrim( AV188Mudanzawwds_12_mudanzaasesor3), "%", "");
         lV188Mudanzawwds_12_mudanzaasesor3 = StringUtil.Concat( StringUtil.RTrim( AV188Mudanzawwds_12_mudanzaasesor3), "%", "");
         lV191Mudanzawwds_15_tfmudanzaasesor = StringUtil.Concat( StringUtil.RTrim( AV191Mudanzawwds_15_tfmudanzaasesor), "%", "");
         lV199Mudanzawwds_23_tfmudanzadireccionorigen = StringUtil.Concat( StringUtil.RTrim( AV199Mudanzawwds_23_tfmudanzadireccionorigen), "%", "");
         lV202Mudanzawwds_26_tfmudanzadirecciondestino = StringUtil.Concat( StringUtil.RTrim( AV202Mudanzawwds_26_tfmudanzadirecciondestino), "%", "");
         lV204Mudanzawwds_28_tfmudanzapisodptodestino = StringUtil.PadR( StringUtil.RTrim( AV204Mudanzawwds_28_tfmudanzapisodptodestino), 30, "%");
         lV217Mudanzawwds_41_tftipoinmuebleorigennombre = StringUtil.Concat( StringUtil.RTrim( AV217Mudanzawwds_41_tftipoinmuebleorigennombre), "%", "");
         /* Using cursor P00FH2 */
         pr_default.execute(0, new Object[] {lV177Mudanzawwds_1_filterfulltext, lV177Mudanzawwds_1_filterfulltext, lV177Mudanzawwds_1_filterfulltext, lV177Mudanzawwds_1_filterfulltext, lV177Mudanzawwds_1_filterfulltext, lV177Mudanzawwds_1_filterfulltext, lV177Mudanzawwds_1_filterfulltext, lV177Mudanzawwds_1_filterfulltext, lV177Mudanzawwds_1_filterfulltext, lV177Mudanzawwds_1_filterfulltext, lV177Mudanzawwds_1_filterfulltext, lV177Mudanzawwds_1_filterfulltext, lV177Mudanzawwds_1_filterfulltext, lV177Mudanzawwds_1_filterfulltext, lV177Mudanzawwds_1_filterfulltext, lV177Mudanzawwds_1_filterfulltext, lV177Mudanzawwds_1_filterfulltext, lV177Mudanzawwds_1_filterfulltext, lV177Mudanzawwds_1_filterfulltext, lV177Mudanzawwds_1_filterfulltext, lV177Mudanzawwds_1_filterfulltext, lV177Mudanzawwds_1_filterfulltext, lV177Mudanzawwds_1_filterfulltext, lV177Mudanzawwds_1_filterfulltext, lV177Mudanzawwds_1_filterfulltext, lV177Mudanzawwds_1_filterfulltext, lV177Mudanzawwds_1_filterfulltext, lV177Mudanzawwds_1_filterfulltext, lV177Mudanzawwds_1_filterfulltext, lV180Mudanzawwds_4_mudanzaasesor1, lV180Mudanzawwds_4_mudanzaasesor1, lV184Mudanzawwds_8_mudanzaasesor2, lV184Mudanzawwds_8_mudanzaasesor2, lV188Mudanzawwds_12_mudanzaasesor3, lV188Mudanzawwds_12_mudanzaasesor3, AV189Mudanzawwds_13_tfmudanzaid, AV190Mudanzawwds_14_tfmudanzaid_to, lV191Mudanzawwds_15_tfmudanzaasesor, AV192Mudanzawwds_16_tfmudanzaasesor_sel, AV193Mudanzawwds_17_tfmudanzafechaalta, AV194Mudanzawwds_18_tfmudanzafechaalta_to, AV195Mudanzawwds_19_tfmudanzafechaservicio, AV196Mudanzawwds_20_tfmudanzafechaservicio_to, lV199Mudanzawwds_23_tfmudanzadireccionorigen, AV200Mudanzawwds_24_tfmudanzadireccionorigen_sel, lV202Mudanzawwds_26_tfmudanzadirecciondestino, AV203Mudanzawwds_27_tfmudanzadirecciondestino_sel, lV204Mudanzawwds_28_tfmudanzapisodptodestino, AV205Mudanzawwds_29_tfmudanzapisodptodestino_sel, AV206Mudanzawwds_30_tfmudanzadistancia, AV207Mudanzawwds_31_tfmudanzadistancia_to, AV209Mudanzawwds_33_tfmudanzapreciobasexhora, AV210Mudanzawwds_34_tfmudanzapreciobasexhora_to, AV211Mudanzawwds_35_tfmudanzapeajecantidad, AV212Mudanzawwds_36_tfmudanzapeajecantidad_to, AV213Mudanzawwds_37_tfmudanzapeajevalor, AV214Mudanzawwds_38_tfmudanzapeajevalor_to, AV215Mudanzawwds_39_tftipoinmuebleorigenid, AV216Mudanzawwds_40_tftipoinmuebleorigenid_to, lV217Mudanzawwds_41_tftipoinmuebleorigennombre, AV218Mudanzawwds_42_tftipoinmuebleorigennombre_sel, AV219Mudanzawwds_43_tftipoinmuebleorigenvalor, AV220Mudanzawwds_44_tftipoinmuebleorigenvalor_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A756TipoInmuebleOrigenValor = P00FH2_A756TipoInmuebleOrigenValor[0];
            A755TipoInmuebleOrigenNombre = P00FH2_A755TipoInmuebleOrigenNombre[0];
            A743TipoInmuebleOrigenId = P00FH2_A743TipoInmuebleOrigenId[0];
            A760MudanzaPeajevalor = P00FH2_A760MudanzaPeajevalor[0];
            A761MudanzaPeajeCantidad = P00FH2_A761MudanzaPeajeCantidad[0];
            A780MudanzaPrecioBasexHora = P00FH2_A780MudanzaPrecioBasexHora[0];
            A742MudanzaVehiculoSugerido = P00FH2_A742MudanzaVehiculoSugerido[0];
            A762MudanzaDistancia = P00FH2_A762MudanzaDistancia[0];
            A778MudanzaPisoDptoDestino = P00FH2_A778MudanzaPisoDptoDestino[0];
            A741MudanzaDireccionDestino = P00FH2_A741MudanzaDireccionDestino[0];
            A777MudanzaPisoDptoOrigen = P00FH2_A777MudanzaPisoDptoOrigen[0];
            A740MudanzaDireccionOrigen = P00FH2_A740MudanzaDireccionOrigen[0];
            A738MudanzaFechaServicio = P00FH2_A738MudanzaFechaServicio[0];
            A737MudanzaFechaAlta = P00FH2_A737MudanzaFechaAlta[0];
            A736MudanzaAsesor = P00FH2_A736MudanzaAsesor[0];
            A735MudanzaId = P00FH2_A735MudanzaId[0];
            A776MudanzaRgoHoraservicio = P00FH2_A776MudanzaRgoHoraservicio[0];
            n776MudanzaRgoHoraservicio = P00FH2_n776MudanzaRgoHoraservicio[0];
            A739MudanzaHoraServicio = P00FH2_A739MudanzaHoraServicio[0];
            n739MudanzaHoraServicio = P00FH2_n739MudanzaHoraServicio[0];
            A749TipoEstacionamDestinoId = P00FH2_A749TipoEstacionamDestinoId[0];
            A758TipoEstacionamOrigenValor = P00FH2_A758TipoEstacionamOrigenValor[0];
            A748TipoEstacionamOrigenNombre = P00FH2_A748TipoEstacionamOrigenNombre[0];
            A747TipoEstacionamOrigenId = P00FH2_A747TipoEstacionamOrigenId[0];
            A757TipoInmuebleDestinoValor = P00FH2_A757TipoInmuebleDestinoValor[0];
            A746TipoInmuebleDestinoNombre = P00FH2_A746TipoInmuebleDestinoNombre[0];
            A745TipoInmuebleDestinoId = P00FH2_A745TipoInmuebleDestinoId[0];
            A756TipoInmuebleOrigenValor = P00FH2_A756TipoInmuebleOrigenValor[0];
            A755TipoInmuebleOrigenNombre = P00FH2_A755TipoInmuebleOrigenNombre[0];
            A758TipoEstacionamOrigenValor = P00FH2_A758TipoEstacionamOrigenValor[0];
            A748TipoEstacionamOrigenNombre = P00FH2_A748TipoEstacionamOrigenNombre[0];
            A757TipoInmuebleDestinoValor = P00FH2_A757TipoInmuebleDestinoValor[0];
            A746TipoInmuebleDestinoNombre = P00FH2_A746TipoInmuebleDestinoNombre[0];
            AV142MudanzaHoraServicioDescription = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( A739MudanzaHoraServicio), "08") == 0 )
            {
               AV142MudanzaHoraServicioDescription = "08:00";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A739MudanzaHoraServicio), "09") == 0 )
            {
               AV142MudanzaHoraServicioDescription = "09:00";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A739MudanzaHoraServicio), "10") == 0 )
            {
               AV142MudanzaHoraServicioDescription = "10:00";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A739MudanzaHoraServicio), "11") == 0 )
            {
               AV142MudanzaHoraServicioDescription = "11:00";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A739MudanzaHoraServicio), "12") == 0 )
            {
               AV142MudanzaHoraServicioDescription = "12:00";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A739MudanzaHoraServicio), "13") == 0 )
            {
               AV142MudanzaHoraServicioDescription = "13:00";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A739MudanzaHoraServicio), "14") == 0 )
            {
               AV142MudanzaHoraServicioDescription = "14:00";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A739MudanzaHoraServicio), "15") == 0 )
            {
               AV142MudanzaHoraServicioDescription = "15:00";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A739MudanzaHoraServicio), "16") == 0 )
            {
               AV142MudanzaHoraServicioDescription = "16:00";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A739MudanzaHoraServicio), "17") == 0 )
            {
               AV142MudanzaHoraServicioDescription = "17:00";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A739MudanzaHoraServicio), "18") == 0 )
            {
               AV142MudanzaHoraServicioDescription = "18:00";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A739MudanzaHoraServicio), "19") == 0 )
            {
               AV142MudanzaHoraServicioDescription = "19:00";
            }
            AV148MudanzaRgoHoraservicioDescription = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( A776MudanzaRgoHoraservicio), "08-11") == 0 )
            {
               AV148MudanzaRgoHoraservicioDescription = "08:00 - 11:00";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A776MudanzaRgoHoraservicio), "11-14") == 0 )
            {
               AV148MudanzaRgoHoraservicioDescription = "11:00 - 14:00";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A776MudanzaRgoHoraservicio), "14-19") == 0 )
            {
               AV148MudanzaRgoHoraservicioDescription = "14:00 - 19:00";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            HFH0( false, 63) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A735MudanzaId), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 56, Gx_line+52, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A736MudanzaAsesor, "")), 60, Gx_line+10, 86, Gx_line+52, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A737MudanzaFechaAlta, "99/99/99"), 90, Gx_line+10, 116, Gx_line+52, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A738MudanzaFechaServicio, "99/99/99"), 120, Gx_line+10, 146, Gx_line+52, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV142MudanzaHoraServicioDescription, "")), 150, Gx_line+10, 176, Gx_line+52, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV148MudanzaRgoHoraservicioDescription, "")), 180, Gx_line+10, 206, Gx_line+52, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A740MudanzaDireccionOrigen, "")), 210, Gx_line+10, 236, Gx_line+52, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV149MudanzaPisoDptoOrigenDescription, "")), 240, Gx_line+10, 266, Gx_line+52, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A741MudanzaDireccionDestino, "")), 270, Gx_line+10, 296, Gx_line+52, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A778MudanzaPisoDptoDestino, "")), 300, Gx_line+10, 326, Gx_line+52, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A762MudanzaDistancia, "ZZZZZZ9.99")), 330, Gx_line+10, 356, Gx_line+52, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV127MudanzaVehiculoSugeridoDescription, "")), 360, Gx_line+10, 386, Gx_line+52, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A780MudanzaPrecioBasexHora, "ZZZZZZZZZZZZZZ9.99")), 390, Gx_line+10, 416, Gx_line+52, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A761MudanzaPeajeCantidad), "9")), 420, Gx_line+10, 446, Gx_line+52, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A760MudanzaPeajevalor, "ZZZZZZZZZZZZZZ9.99")), 450, Gx_line+10, 476, Gx_line+52, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A743TipoInmuebleOrigenId), "ZZZ9")), 480, Gx_line+10, 506, Gx_line+52, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A755TipoInmuebleOrigenNombre, "")), 510, Gx_line+10, 537, Gx_line+52, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A756TipoInmuebleOrigenValor, "ZZZZZZZZZZZZZZ9.99")), 541, Gx_line+10, 568, Gx_line+52, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A745TipoInmuebleDestinoId), "ZZZ9")), 572, Gx_line+10, 599, Gx_line+52, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A746TipoInmuebleDestinoNombre, "")), 603, Gx_line+10, 631, Gx_line+52, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A757TipoInmuebleDestinoValor, "ZZZZZZZZZZZZZZ9.99")), 635, Gx_line+10, 662, Gx_line+52, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A747TipoEstacionamOrigenId), "ZZZ9")), 666, Gx_line+10, 693, Gx_line+52, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31TipoEstacionamOrigenNombreDescription, "")), 697, Gx_line+10, 725, Gx_line+52, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A758TipoEstacionamOrigenValor, "ZZZZZZZZZZZZZZ9.99")), 729, Gx_line+10, 756, Gx_line+52, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A749TipoEstacionamDestinoId), "ZZZ9")), 760, Gx_line+10, 787, Gx_line+52, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawLine(28, Gx_line+62, 789, Gx_line+62, 1, 220, 220, 220, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+63);
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
         if ( StringUtil.StrCmp(AV33Session.Get("MudanzaWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "MudanzaWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("MudanzaWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV35GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV35GridState.gxTpr_Ordereddsc;
         AV221GXV6 = 1;
         while ( AV221GXV6 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV221GXV6));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMUDANZAID") == 0 )
            {
               AV37TFMudanzaId = (long)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV38TFMudanzaId_To = (long)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMUDANZAASESOR") == 0 )
            {
               AV39TFMudanzaAsesor = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMUDANZAASESOR_SEL") == 0 )
            {
               AV40TFMudanzaAsesor_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMUDANZAFECHAALTA") == 0 )
            {
               AV41TFMudanzaFechaAlta = context.localUtil.CToD( AV36GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV42TFMudanzaFechaAlta_To = context.localUtil.CToD( AV36GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMUDANZAFECHASERVICIO") == 0 )
            {
               AV43TFMudanzaFechaServicio = context.localUtil.CToD( AV36GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV44TFMudanzaFechaServicio_To = context.localUtil.CToD( AV36GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMUDANZAHORASERVICIO_SEL") == 0 )
            {
               AV143TFMudanzaHoraServicio_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV146TFMudanzaHoraServicio_Sels.FromJSonString(AV143TFMudanzaHoraServicio_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMUDANZARGOHORASERVICIO_SEL") == 0 )
            {
               AV150TFMudanzaRgoHoraservicio_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV153TFMudanzaRgoHoraservicio_Sels.FromJSonString(AV150TFMudanzaRgoHoraservicio_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMUDANZADIRECCIONORIGEN") == 0 )
            {
               AV47TFMudanzaDireccionOrigen = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMUDANZADIRECCIONORIGEN_SEL") == 0 )
            {
               AV48TFMudanzaDireccionOrigen_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMUDANZAPISODPTOORIGEN_SEL") == 0 )
            {
               AV154TFMudanzaPisoDptoOrigen_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV157TFMudanzaPisoDptoOrigen_Sels.FromJSonString(AV154TFMudanzaPisoDptoOrigen_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMUDANZADIRECCIONDESTINO") == 0 )
            {
               AV49TFMudanzaDireccionDestino = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMUDANZADIRECCIONDESTINO_SEL") == 0 )
            {
               AV50TFMudanzaDireccionDestino_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMUDANZAPISODPTODESTINO") == 0 )
            {
               AV158TFMudanzaPisoDptoDestino = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMUDANZAPISODPTODESTINO_SEL") == 0 )
            {
               AV159TFMudanzaPisoDptoDestino_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMUDANZADISTANCIA") == 0 )
            {
               AV51TFMudanzaDistancia = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, ".");
               AV52TFMudanzaDistancia_To = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMUDANZAVEHICULOSUGERIDO_SEL") == 0 )
            {
               AV128TFMudanzaVehiculoSugerido_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV131TFMudanzaVehiculoSugerido_Sels.FromJSonString(AV128TFMudanzaVehiculoSugerido_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMUDANZAPRECIOBASEXHORA") == 0 )
            {
               AV165TFMudanzaPrecioBasexHora = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, ".");
               AV166TFMudanzaPrecioBasexHora_To = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMUDANZAPEAJECANTIDAD") == 0 )
            {
               AV57TFMudanzaPeajeCantidad = (short)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV58TFMudanzaPeajeCantidad_To = (short)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMUDANZAPEAJEVALOR") == 0 )
            {
               AV59TFMudanzaPeajevalor = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, ".");
               AV60TFMudanzaPeajevalor_To = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTIPOINMUEBLEORIGENID") == 0 )
            {
               AV61TFTipoInmuebleOrigenId = (short)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV62TFTipoInmuebleOrigenId_To = (short)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTIPOINMUEBLEORIGENNOMBRE") == 0 )
            {
               AV160TFTipoInmuebleOrigenNombre = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTIPOINMUEBLEORIGENNOMBRE_SEL") == 0 )
            {
               AV65TFTipoInmuebleOrigenNombre_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTIPOINMUEBLEORIGENVALOR") == 0 )
            {
               AV67TFTipoInmuebleOrigenValor = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, ".");
               AV68TFTipoInmuebleOrigenValor_To = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTIPOINMUEBLEDESTINOID") == 0 )
            {
               AV69TFTipoInmuebleDestinoId = (short)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV70TFTipoInmuebleDestinoId_To = (short)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTIPOINMUEBLEDESTINONOMBRE") == 0 )
            {
               AV161TFTipoInmuebleDestinoNombre = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTIPOINMUEBLEDESTINONOMBRE_SEL") == 0 )
            {
               AV73TFTipoInmuebleDestinoNombre_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTIPOINMUEBLEDESTINOVALOR") == 0 )
            {
               AV75TFTipoInmuebleDestinoValor = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, ".");
               AV76TFTipoInmuebleDestinoValor_To = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTIPOESTACIONAMORIGENID") == 0 )
            {
               AV77TFTipoEstacionamOrigenId = (short)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV78TFTipoEstacionamOrigenId_To = (short)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTIPOESTACIONAMORIGENNOMBRE_SEL") == 0 )
            {
               AV79TFTipoEstacionamOrigenNombre_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV82TFTipoEstacionamOrigenNombre_Sels.FromJSonString(AV79TFTipoEstacionamOrigenNombre_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTIPOESTACIONAMORIGENVALOR") == 0 )
            {
               AV83TFTipoEstacionamOrigenValor = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, ".");
               AV84TFTipoEstacionamOrigenValor_To = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFTIPOESTACIONAMDESTINOID") == 0 )
            {
               AV85TFTipoEstacionamDestinoId = (short)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV86TFTipoEstacionamDestinoId_To = (short)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            AV221GXV6 = (int)(AV221GXV6+1);
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

      protected void HFH0( bool bFoot ,
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
                  AV123PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV120DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+39, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV123PageInfo, "")), 30, Gx_line+15, 409, Gx_line+29, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV120DateInfo, "")), 409, Gx_line+15, 789, Gx_line+29, 2, 0, 0, 0) ;
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
               AV118AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV124Phone = "+1 550 8923";
               AV122Mail = "info@mail.com";
               AV126Website = "http://www.web.com";
               AV115AddressLine1 = "French Boulevard 2859";
               AV116AddressLine2 = "Downtown";
               AV117AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+107, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV118AppName, "")), 30, Gx_line+30, 283, Gx_line+44, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV125Title, "")), 30, Gx_line+44, 283, Gx_line+77, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV124Phone, "")), 283, Gx_line+30, 536, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV122Mail, "")), 283, Gx_line+45, 536, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV126Website, "")), 283, Gx_line+60, 536, Gx_line+77, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV115AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV116AddressLine2, "")), 536, Gx_line+45, 789, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV117AddressLine3, "")), 536, Gx_line+60, 789, Gx_line+77, 2, 0, 0, 0) ;
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
         AV168Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV125Title = "";
         AV13FilterFullText = "";
         AV35GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV16MudanzaAsesor1 = "";
         AV17FilterMudanzaAsesorDescription = "";
         AV18MudanzaAsesor = "";
         AV20DynamicFiltersSelector2 = "";
         AV22MudanzaAsesor2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV26MudanzaAsesor3 = "";
         AV93TFMudanzaId_To_Description = "";
         AV40TFMudanzaAsesor_Sel = "";
         AV39TFMudanzaAsesor = "";
         AV41TFMudanzaFechaAlta = DateTime.MinValue;
         AV42TFMudanzaFechaAlta_To = DateTime.MinValue;
         AV94TFMudanzaFechaAlta_To_Description = "";
         AV43TFMudanzaFechaServicio = DateTime.MinValue;
         AV44TFMudanzaFechaServicio_To = DateTime.MinValue;
         AV95TFMudanzaFechaServicio_To_Description = "";
         AV146TFMudanzaHoraServicio_Sels = new GxSimpleCollection<string>();
         AV143TFMudanzaHoraServicio_SelsJson = "";
         AV145TFMudanzaHoraServicio_Sel = "";
         AV144TFMudanzaHoraServicio_SelDscs = "";
         AV147FilterTFMudanzaHoraServicio_SelValueDescription = "";
         AV153TFMudanzaRgoHoraservicio_Sels = new GxSimpleCollection<string>();
         AV150TFMudanzaRgoHoraservicio_SelsJson = "";
         AV152TFMudanzaRgoHoraservicio_Sel = "";
         AV151TFMudanzaRgoHoraservicio_SelDscs = "";
         AV163FilterTFMudanzaRgoHoraservicio_SelValueDescription = "";
         AV48TFMudanzaDireccionOrigen_Sel = "";
         AV47TFMudanzaDireccionOrigen = "";
         AV157TFMudanzaPisoDptoOrigen_Sels = new GxSimpleCollection<string>();
         AV154TFMudanzaPisoDptoOrigen_SelsJson = "";
         AV156TFMudanzaPisoDptoOrigen_Sel = "";
         AV155TFMudanzaPisoDptoOrigen_SelDscs = "";
         AV164FilterTFMudanzaPisoDptoOrigen_SelValueDescription = "";
         AV50TFMudanzaDireccionDestino_Sel = "";
         AV49TFMudanzaDireccionDestino = "";
         AV159TFMudanzaPisoDptoDestino_Sel = "";
         AV158TFMudanzaPisoDptoDestino = "";
         AV97TFMudanzaDistancia_To_Description = "";
         AV131TFMudanzaVehiculoSugerido_Sels = new GxSimpleCollection<string>();
         AV128TFMudanzaVehiculoSugerido_SelsJson = "";
         AV130TFMudanzaVehiculoSugerido_Sel = "";
         AV129TFMudanzaVehiculoSugerido_SelDscs = "";
         AV136FilterTFMudanzaVehiculoSugerido_SelValueDescription = "";
         AV167TFMudanzaPrecioBasexHora_To_Description = "";
         AV99TFMudanzaPeajeCantidad_To_Description = "";
         AV100TFMudanzaPeajevalor_To_Description = "";
         AV101TFTipoInmuebleOrigenId_To_Description = "";
         AV65TFTipoInmuebleOrigenNombre_Sel = "";
         AV160TFTipoInmuebleOrigenNombre = "";
         AV103TFTipoInmuebleOrigenValor_To_Description = "";
         AV104TFTipoInmuebleDestinoId_To_Description = "";
         AV73TFTipoInmuebleDestinoNombre_Sel = "";
         AV161TFTipoInmuebleDestinoNombre = "";
         AV106TFTipoInmuebleDestinoValor_To_Description = "";
         AV107TFTipoEstacionamOrigenId_To_Description = "";
         AV82TFTipoEstacionamOrigenNombre_Sels = new GxSimpleCollection<string>();
         AV79TFTipoEstacionamOrigenNombre_SelsJson = "";
         AV81TFTipoEstacionamOrigenNombre_Sel = "";
         AV80TFTipoEstacionamOrigenNombre_SelDscs = "";
         AV108FilterTFTipoEstacionamOrigenNombre_SelValueDescription = "";
         AV109TFTipoEstacionamOrigenValor_To_Description = "";
         AV110TFTipoEstacionamDestinoId_To_Description = "";
         AV177Mudanzawwds_1_filterfulltext = "";
         AV178Mudanzawwds_2_dynamicfiltersselector1 = "";
         AV180Mudanzawwds_4_mudanzaasesor1 = "";
         AV182Mudanzawwds_6_dynamicfiltersselector2 = "";
         AV184Mudanzawwds_8_mudanzaasesor2 = "";
         AV186Mudanzawwds_10_dynamicfiltersselector3 = "";
         AV188Mudanzawwds_12_mudanzaasesor3 = "";
         AV191Mudanzawwds_15_tfmudanzaasesor = "";
         AV192Mudanzawwds_16_tfmudanzaasesor_sel = "";
         AV193Mudanzawwds_17_tfmudanzafechaalta = DateTime.MinValue;
         AV194Mudanzawwds_18_tfmudanzafechaalta_to = DateTime.MinValue;
         AV195Mudanzawwds_19_tfmudanzafechaservicio = DateTime.MinValue;
         AV196Mudanzawwds_20_tfmudanzafechaservicio_to = DateTime.MinValue;
         AV197Mudanzawwds_21_tfmudanzahoraservicio_sels = new GxSimpleCollection<string>();
         AV198Mudanzawwds_22_tfmudanzargohoraservicio_sels = new GxSimpleCollection<string>();
         AV199Mudanzawwds_23_tfmudanzadireccionorigen = "";
         AV200Mudanzawwds_24_tfmudanzadireccionorigen_sel = "";
         AV201Mudanzawwds_25_tfmudanzapisodptoorigen_sels = new GxSimpleCollection<string>();
         AV202Mudanzawwds_26_tfmudanzadirecciondestino = "";
         AV203Mudanzawwds_27_tfmudanzadirecciondestino_sel = "";
         AV204Mudanzawwds_28_tfmudanzapisodptodestino = "";
         AV205Mudanzawwds_29_tfmudanzapisodptodestino_sel = "";
         AV208Mudanzawwds_32_tfmudanzavehiculosugerido_sels = new GxSimpleCollection<string>();
         AV217Mudanzawwds_41_tftipoinmuebleorigennombre = "";
         AV218Mudanzawwds_42_tftipoinmuebleorigennombre_sel = "";
         lV177Mudanzawwds_1_filterfulltext = "";
         lV180Mudanzawwds_4_mudanzaasesor1 = "";
         lV184Mudanzawwds_8_mudanzaasesor2 = "";
         lV188Mudanzawwds_12_mudanzaasesor3 = "";
         lV191Mudanzawwds_15_tfmudanzaasesor = "";
         lV199Mudanzawwds_23_tfmudanzadireccionorigen = "";
         lV202Mudanzawwds_26_tfmudanzadirecciondestino = "";
         lV204Mudanzawwds_28_tfmudanzapisodptodestino = "";
         lV217Mudanzawwds_41_tftipoinmuebleorigennombre = "";
         A739MudanzaHoraServicio = "";
         A776MudanzaRgoHoraservicio = "";
         A777MudanzaPisoDptoOrigen = "";
         A742MudanzaVehiculoSugerido = "";
         A736MudanzaAsesor = "";
         A740MudanzaDireccionOrigen = "";
         A741MudanzaDireccionDestino = "";
         A778MudanzaPisoDptoDestino = "";
         A755TipoInmuebleOrigenNombre = "";
         A737MudanzaFechaAlta = DateTime.MinValue;
         A738MudanzaFechaServicio = DateTime.MinValue;
         P00FH2_A756TipoInmuebleOrigenValor = new decimal[1] ;
         P00FH2_A755TipoInmuebleOrigenNombre = new string[] {""} ;
         P00FH2_A743TipoInmuebleOrigenId = new short[1] ;
         P00FH2_A760MudanzaPeajevalor = new decimal[1] ;
         P00FH2_A761MudanzaPeajeCantidad = new short[1] ;
         P00FH2_A780MudanzaPrecioBasexHora = new decimal[1] ;
         P00FH2_A742MudanzaVehiculoSugerido = new string[] {""} ;
         P00FH2_A762MudanzaDistancia = new decimal[1] ;
         P00FH2_A778MudanzaPisoDptoDestino = new string[] {""} ;
         P00FH2_A741MudanzaDireccionDestino = new string[] {""} ;
         P00FH2_A777MudanzaPisoDptoOrigen = new string[] {""} ;
         P00FH2_A740MudanzaDireccionOrigen = new string[] {""} ;
         P00FH2_A738MudanzaFechaServicio = new DateTime[] {DateTime.MinValue} ;
         P00FH2_A737MudanzaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00FH2_A736MudanzaAsesor = new string[] {""} ;
         P00FH2_A735MudanzaId = new long[1] ;
         P00FH2_A776MudanzaRgoHoraservicio = new string[] {""} ;
         P00FH2_n776MudanzaRgoHoraservicio = new bool[] {false} ;
         P00FH2_A739MudanzaHoraServicio = new string[] {""} ;
         P00FH2_n739MudanzaHoraServicio = new bool[] {false} ;
         P00FH2_A749TipoEstacionamDestinoId = new short[1] ;
         P00FH2_A758TipoEstacionamOrigenValor = new decimal[1] ;
         P00FH2_A748TipoEstacionamOrigenNombre = new string[] {""} ;
         P00FH2_A747TipoEstacionamOrigenId = new short[1] ;
         P00FH2_A757TipoInmuebleDestinoValor = new decimal[1] ;
         P00FH2_A746TipoInmuebleDestinoNombre = new string[] {""} ;
         P00FH2_A745TipoInmuebleDestinoId = new short[1] ;
         A748TipoEstacionamOrigenNombre = "";
         A746TipoInmuebleDestinoNombre = "";
         AV142MudanzaHoraServicioDescription = "";
         AV148MudanzaRgoHoraservicioDescription = "";
         AV149MudanzaPisoDptoOrigenDescription = "";
         AV127MudanzaVehiculoSugeridoDescription = "";
         AV31TipoEstacionamOrigenNombreDescription = "";
         AV33Session = context.GetSession();
         AV36GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV123PageInfo = "";
         AV120DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV118AppName = "";
         AV124Phone = "";
         AV122Mail = "";
         AV126Website = "";
         AV115AddressLine1 = "";
         AV116AddressLine2 = "";
         AV117AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.mudanza1wwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00FH2_A756TipoInmuebleOrigenValor, P00FH2_A755TipoInmuebleOrigenNombre, P00FH2_A743TipoInmuebleOrigenId, P00FH2_A760MudanzaPeajevalor, P00FH2_A761MudanzaPeajeCantidad, P00FH2_A780MudanzaPrecioBasexHora, P00FH2_A742MudanzaVehiculoSugerido, P00FH2_A762MudanzaDistancia, P00FH2_A778MudanzaPisoDptoDestino, P00FH2_A741MudanzaDireccionDestino,
               P00FH2_A777MudanzaPisoDptoOrigen, P00FH2_A740MudanzaDireccionOrigen, P00FH2_A738MudanzaFechaServicio, P00FH2_A737MudanzaFechaAlta, P00FH2_A736MudanzaAsesor, P00FH2_A735MudanzaId, P00FH2_A776MudanzaRgoHoraservicio, P00FH2_n776MudanzaRgoHoraservicio, P00FH2_A739MudanzaHoraServicio, P00FH2_n739MudanzaHoraServicio,
               P00FH2_A749TipoEstacionamDestinoId, P00FH2_A758TipoEstacionamOrigenValor, P00FH2_A748TipoEstacionamOrigenNombre, P00FH2_A747TipoEstacionamOrigenId, P00FH2_A757TipoInmuebleDestinoValor, P00FH2_A746TipoInmuebleDestinoNombre, P00FH2_A745TipoInmuebleDestinoId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV168Pgmname = "Mudanza1WWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV168Pgmname = "Mudanza1WWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV15DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV25DynamicFiltersOperator3 ;
      private short AV57TFMudanzaPeajeCantidad ;
      private short AV58TFMudanzaPeajeCantidad_To ;
      private short AV61TFTipoInmuebleOrigenId ;
      private short AV62TFTipoInmuebleOrigenId_To ;
      private short AV69TFTipoInmuebleDestinoId ;
      private short AV70TFTipoInmuebleDestinoId_To ;
      private short AV77TFTipoEstacionamOrigenId ;
      private short AV78TFTipoEstacionamOrigenId_To ;
      private short AV85TFTipoEstacionamDestinoId ;
      private short AV86TFTipoEstacionamDestinoId_To ;
      private short AV179Mudanzawwds_3_dynamicfiltersoperator1 ;
      private short AV183Mudanzawwds_7_dynamicfiltersoperator2 ;
      private short AV187Mudanzawwds_11_dynamicfiltersoperator3 ;
      private short AV211Mudanzawwds_35_tfmudanzapeajecantidad ;
      private short AV212Mudanzawwds_36_tfmudanzapeajecantidad_to ;
      private short AV215Mudanzawwds_39_tftipoinmuebleorigenid ;
      private short AV216Mudanzawwds_40_tftipoinmuebleorigenid_to ;
      private short A761MudanzaPeajeCantidad ;
      private short A743TipoInmuebleOrigenId ;
      private short AV11OrderedBy ;
      private short A749TipoEstacionamDestinoId ;
      private short A747TipoEstacionamOrigenId ;
      private short A745TipoInmuebleDestinoId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV171GXV1 ;
      private int AV172GXV2 ;
      private int AV173GXV3 ;
      private int AV174GXV4 ;
      private int AV175GXV5 ;
      private int AV197Mudanzawwds_21_tfmudanzahoraservicio_sels_Count ;
      private int AV198Mudanzawwds_22_tfmudanzargohoraservicio_sels_Count ;
      private int AV201Mudanzawwds_25_tfmudanzapisodptoorigen_sels_Count ;
      private int AV208Mudanzawwds_32_tfmudanzavehiculosugerido_sels_Count ;
      private int AV221GXV6 ;
      private long AV37TFMudanzaId ;
      private long AV38TFMudanzaId_To ;
      private long AV114i ;
      private long AV189Mudanzawwds_13_tfmudanzaid ;
      private long AV190Mudanzawwds_14_tfmudanzaid_to ;
      private long A735MudanzaId ;
      private decimal AV51TFMudanzaDistancia ;
      private decimal AV52TFMudanzaDistancia_To ;
      private decimal AV165TFMudanzaPrecioBasexHora ;
      private decimal AV166TFMudanzaPrecioBasexHora_To ;
      private decimal AV59TFMudanzaPeajevalor ;
      private decimal AV60TFMudanzaPeajevalor_To ;
      private decimal AV67TFTipoInmuebleOrigenValor ;
      private decimal AV68TFTipoInmuebleOrigenValor_To ;
      private decimal AV75TFTipoInmuebleDestinoValor ;
      private decimal AV76TFTipoInmuebleDestinoValor_To ;
      private decimal AV83TFTipoEstacionamOrigenValor ;
      private decimal AV84TFTipoEstacionamOrigenValor_To ;
      private decimal AV206Mudanzawwds_30_tfmudanzadistancia ;
      private decimal AV207Mudanzawwds_31_tfmudanzadistancia_to ;
      private decimal AV209Mudanzawwds_33_tfmudanzapreciobasexhora ;
      private decimal AV210Mudanzawwds_34_tfmudanzapreciobasexhora_to ;
      private decimal AV213Mudanzawwds_37_tfmudanzapeajevalor ;
      private decimal AV214Mudanzawwds_38_tfmudanzapeajevalor_to ;
      private decimal AV219Mudanzawwds_43_tftipoinmuebleorigenvalor ;
      private decimal AV220Mudanzawwds_44_tftipoinmuebleorigenvalor_to ;
      private decimal A762MudanzaDistancia ;
      private decimal A780MudanzaPrecioBasexHora ;
      private decimal A760MudanzaPeajevalor ;
      private decimal A756TipoInmuebleOrigenValor ;
      private decimal A758TipoEstacionamOrigenValor ;
      private decimal A757TipoInmuebleDestinoValor ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV168Pgmname ;
      private string GXEncryptionTmp ;
      private string AV145TFMudanzaHoraServicio_Sel ;
      private string AV152TFMudanzaRgoHoraservicio_Sel ;
      private string AV156TFMudanzaPisoDptoOrigen_Sel ;
      private string AV159TFMudanzaPisoDptoDestino_Sel ;
      private string AV158TFMudanzaPisoDptoDestino ;
      private string AV204Mudanzawwds_28_tfmudanzapisodptodestino ;
      private string AV205Mudanzawwds_29_tfmudanzapisodptodestino_sel ;
      private string lV204Mudanzawwds_28_tfmudanzapisodptodestino ;
      private string A739MudanzaHoraServicio ;
      private string A776MudanzaRgoHoraservicio ;
      private string A777MudanzaPisoDptoOrigen ;
      private string A778MudanzaPisoDptoDestino ;
      private DateTime AV41TFMudanzaFechaAlta ;
      private DateTime AV42TFMudanzaFechaAlta_To ;
      private DateTime AV43TFMudanzaFechaServicio ;
      private DateTime AV44TFMudanzaFechaServicio_To ;
      private DateTime AV193Mudanzawwds_17_tfmudanzafechaalta ;
      private DateTime AV194Mudanzawwds_18_tfmudanzafechaalta_to ;
      private DateTime AV195Mudanzawwds_19_tfmudanzafechaservicio ;
      private DateTime AV196Mudanzawwds_20_tfmudanzafechaservicio_to ;
      private DateTime A737MudanzaFechaAlta ;
      private DateTime A738MudanzaFechaServicio ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV113TempBoolean ;
      private bool AV181Mudanzawwds_5_dynamicfiltersenabled2 ;
      private bool AV185Mudanzawwds_9_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private bool n776MudanzaRgoHoraservicio ;
      private bool n739MudanzaHoraServicio ;
      private string AV143TFMudanzaHoraServicio_SelsJson ;
      private string AV150TFMudanzaRgoHoraservicio_SelsJson ;
      private string AV154TFMudanzaPisoDptoOrigen_SelsJson ;
      private string AV128TFMudanzaVehiculoSugerido_SelsJson ;
      private string AV79TFTipoEstacionamOrigenNombre_SelsJson ;
      private string AV125Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV16MudanzaAsesor1 ;
      private string AV17FilterMudanzaAsesorDescription ;
      private string AV18MudanzaAsesor ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV22MudanzaAsesor2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV26MudanzaAsesor3 ;
      private string AV93TFMudanzaId_To_Description ;
      private string AV40TFMudanzaAsesor_Sel ;
      private string AV39TFMudanzaAsesor ;
      private string AV94TFMudanzaFechaAlta_To_Description ;
      private string AV95TFMudanzaFechaServicio_To_Description ;
      private string AV144TFMudanzaHoraServicio_SelDscs ;
      private string AV147FilterTFMudanzaHoraServicio_SelValueDescription ;
      private string AV151TFMudanzaRgoHoraservicio_SelDscs ;
      private string AV163FilterTFMudanzaRgoHoraservicio_SelValueDescription ;
      private string AV48TFMudanzaDireccionOrigen_Sel ;
      private string AV47TFMudanzaDireccionOrigen ;
      private string AV155TFMudanzaPisoDptoOrigen_SelDscs ;
      private string AV164FilterTFMudanzaPisoDptoOrigen_SelValueDescription ;
      private string AV50TFMudanzaDireccionDestino_Sel ;
      private string AV49TFMudanzaDireccionDestino ;
      private string AV97TFMudanzaDistancia_To_Description ;
      private string AV130TFMudanzaVehiculoSugerido_Sel ;
      private string AV129TFMudanzaVehiculoSugerido_SelDscs ;
      private string AV136FilterTFMudanzaVehiculoSugerido_SelValueDescription ;
      private string AV167TFMudanzaPrecioBasexHora_To_Description ;
      private string AV99TFMudanzaPeajeCantidad_To_Description ;
      private string AV100TFMudanzaPeajevalor_To_Description ;
      private string AV101TFTipoInmuebleOrigenId_To_Description ;
      private string AV65TFTipoInmuebleOrigenNombre_Sel ;
      private string AV160TFTipoInmuebleOrigenNombre ;
      private string AV103TFTipoInmuebleOrigenValor_To_Description ;
      private string AV104TFTipoInmuebleDestinoId_To_Description ;
      private string AV73TFTipoInmuebleDestinoNombre_Sel ;
      private string AV161TFTipoInmuebleDestinoNombre ;
      private string AV106TFTipoInmuebleDestinoValor_To_Description ;
      private string AV107TFTipoEstacionamOrigenId_To_Description ;
      private string AV81TFTipoEstacionamOrigenNombre_Sel ;
      private string AV80TFTipoEstacionamOrigenNombre_SelDscs ;
      private string AV108FilterTFTipoEstacionamOrigenNombre_SelValueDescription ;
      private string AV109TFTipoEstacionamOrigenValor_To_Description ;
      private string AV110TFTipoEstacionamDestinoId_To_Description ;
      private string AV177Mudanzawwds_1_filterfulltext ;
      private string AV178Mudanzawwds_2_dynamicfiltersselector1 ;
      private string AV180Mudanzawwds_4_mudanzaasesor1 ;
      private string AV182Mudanzawwds_6_dynamicfiltersselector2 ;
      private string AV184Mudanzawwds_8_mudanzaasesor2 ;
      private string AV186Mudanzawwds_10_dynamicfiltersselector3 ;
      private string AV188Mudanzawwds_12_mudanzaasesor3 ;
      private string AV191Mudanzawwds_15_tfmudanzaasesor ;
      private string AV192Mudanzawwds_16_tfmudanzaasesor_sel ;
      private string AV199Mudanzawwds_23_tfmudanzadireccionorigen ;
      private string AV200Mudanzawwds_24_tfmudanzadireccionorigen_sel ;
      private string AV202Mudanzawwds_26_tfmudanzadirecciondestino ;
      private string AV203Mudanzawwds_27_tfmudanzadirecciondestino_sel ;
      private string AV217Mudanzawwds_41_tftipoinmuebleorigennombre ;
      private string AV218Mudanzawwds_42_tftipoinmuebleorigennombre_sel ;
      private string lV177Mudanzawwds_1_filterfulltext ;
      private string lV180Mudanzawwds_4_mudanzaasesor1 ;
      private string lV184Mudanzawwds_8_mudanzaasesor2 ;
      private string lV188Mudanzawwds_12_mudanzaasesor3 ;
      private string lV191Mudanzawwds_15_tfmudanzaasesor ;
      private string lV199Mudanzawwds_23_tfmudanzadireccionorigen ;
      private string lV202Mudanzawwds_26_tfmudanzadirecciondestino ;
      private string lV217Mudanzawwds_41_tftipoinmuebleorigennombre ;
      private string A742MudanzaVehiculoSugerido ;
      private string A736MudanzaAsesor ;
      private string A740MudanzaDireccionOrigen ;
      private string A741MudanzaDireccionDestino ;
      private string A755TipoInmuebleOrigenNombre ;
      private string A748TipoEstacionamOrigenNombre ;
      private string A746TipoInmuebleDestinoNombre ;
      private string AV142MudanzaHoraServicioDescription ;
      private string AV148MudanzaRgoHoraservicioDescription ;
      private string AV149MudanzaPisoDptoOrigenDescription ;
      private string AV127MudanzaVehiculoSugeridoDescription ;
      private string AV31TipoEstacionamOrigenNombreDescription ;
      private string AV123PageInfo ;
      private string AV120DateInfo ;
      private string AV118AppName ;
      private string AV124Phone ;
      private string AV122Mail ;
      private string AV126Website ;
      private string AV115AddressLine1 ;
      private string AV116AddressLine2 ;
      private string AV117AddressLine3 ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV146TFMudanzaHoraServicio_Sels ;
      private GxSimpleCollection<string> AV153TFMudanzaRgoHoraservicio_Sels ;
      private GxSimpleCollection<string> AV157TFMudanzaPisoDptoOrigen_Sels ;
      private GxSimpleCollection<string> AV131TFMudanzaVehiculoSugerido_Sels ;
      private GxSimpleCollection<string> AV82TFTipoEstacionamOrigenNombre_Sels ;
      private GxSimpleCollection<string> AV197Mudanzawwds_21_tfmudanzahoraservicio_sels ;
      private GxSimpleCollection<string> AV198Mudanzawwds_22_tfmudanzargohoraservicio_sels ;
      private GxSimpleCollection<string> AV201Mudanzawwds_25_tfmudanzapisodptoorigen_sels ;
      private GxSimpleCollection<string> AV208Mudanzawwds_32_tfmudanzavehiculosugerido_sels ;
      private IDataStoreProvider pr_default ;
      private decimal[] P00FH2_A756TipoInmuebleOrigenValor ;
      private string[] P00FH2_A755TipoInmuebleOrigenNombre ;
      private short[] P00FH2_A743TipoInmuebleOrigenId ;
      private decimal[] P00FH2_A760MudanzaPeajevalor ;
      private short[] P00FH2_A761MudanzaPeajeCantidad ;
      private decimal[] P00FH2_A780MudanzaPrecioBasexHora ;
      private string[] P00FH2_A742MudanzaVehiculoSugerido ;
      private decimal[] P00FH2_A762MudanzaDistancia ;
      private string[] P00FH2_A778MudanzaPisoDptoDestino ;
      private string[] P00FH2_A741MudanzaDireccionDestino ;
      private string[] P00FH2_A777MudanzaPisoDptoOrigen ;
      private string[] P00FH2_A740MudanzaDireccionOrigen ;
      private DateTime[] P00FH2_A738MudanzaFechaServicio ;
      private DateTime[] P00FH2_A737MudanzaFechaAlta ;
      private string[] P00FH2_A736MudanzaAsesor ;
      private long[] P00FH2_A735MudanzaId ;
      private string[] P00FH2_A776MudanzaRgoHoraservicio ;
      private bool[] P00FH2_n776MudanzaRgoHoraservicio ;
      private string[] P00FH2_A739MudanzaHoraServicio ;
      private bool[] P00FH2_n739MudanzaHoraServicio ;
      private short[] P00FH2_A749TipoEstacionamDestinoId ;
      private decimal[] P00FH2_A758TipoEstacionamOrigenValor ;
      private string[] P00FH2_A748TipoEstacionamOrigenNombre ;
      private short[] P00FH2_A747TipoEstacionamOrigenId ;
      private decimal[] P00FH2_A757TipoInmuebleDestinoValor ;
      private string[] P00FH2_A746TipoInmuebleDestinoNombre ;
      private short[] P00FH2_A745TipoInmuebleDestinoId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
   }

   public class mudanza1wwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00FH2( IGxContext context ,
                                             string A739MudanzaHoraServicio ,
                                             GxSimpleCollection<string> AV197Mudanzawwds_21_tfmudanzahoraservicio_sels ,
                                             string A776MudanzaRgoHoraservicio ,
                                             GxSimpleCollection<string> AV198Mudanzawwds_22_tfmudanzargohoraservicio_sels ,
                                             string A777MudanzaPisoDptoOrigen ,
                                             GxSimpleCollection<string> AV201Mudanzawwds_25_tfmudanzapisodptoorigen_sels ,
                                             string A742MudanzaVehiculoSugerido ,
                                             GxSimpleCollection<string> AV208Mudanzawwds_32_tfmudanzavehiculosugerido_sels ,
                                             string AV177Mudanzawwds_1_filterfulltext ,
                                             string AV178Mudanzawwds_2_dynamicfiltersselector1 ,
                                             short AV179Mudanzawwds_3_dynamicfiltersoperator1 ,
                                             string AV180Mudanzawwds_4_mudanzaasesor1 ,
                                             bool AV181Mudanzawwds_5_dynamicfiltersenabled2 ,
                                             string AV182Mudanzawwds_6_dynamicfiltersselector2 ,
                                             short AV183Mudanzawwds_7_dynamicfiltersoperator2 ,
                                             string AV184Mudanzawwds_8_mudanzaasesor2 ,
                                             bool AV185Mudanzawwds_9_dynamicfiltersenabled3 ,
                                             string AV186Mudanzawwds_10_dynamicfiltersselector3 ,
                                             short AV187Mudanzawwds_11_dynamicfiltersoperator3 ,
                                             string AV188Mudanzawwds_12_mudanzaasesor3 ,
                                             long AV189Mudanzawwds_13_tfmudanzaid ,
                                             long AV190Mudanzawwds_14_tfmudanzaid_to ,
                                             string AV192Mudanzawwds_16_tfmudanzaasesor_sel ,
                                             string AV191Mudanzawwds_15_tfmudanzaasesor ,
                                             DateTime AV193Mudanzawwds_17_tfmudanzafechaalta ,
                                             DateTime AV194Mudanzawwds_18_tfmudanzafechaalta_to ,
                                             DateTime AV195Mudanzawwds_19_tfmudanzafechaservicio ,
                                             DateTime AV196Mudanzawwds_20_tfmudanzafechaservicio_to ,
                                             int AV197Mudanzawwds_21_tfmudanzahoraservicio_sels_Count ,
                                             int AV198Mudanzawwds_22_tfmudanzargohoraservicio_sels_Count ,
                                             string AV200Mudanzawwds_24_tfmudanzadireccionorigen_sel ,
                                             string AV199Mudanzawwds_23_tfmudanzadireccionorigen ,
                                             int AV201Mudanzawwds_25_tfmudanzapisodptoorigen_sels_Count ,
                                             string AV203Mudanzawwds_27_tfmudanzadirecciondestino_sel ,
                                             string AV202Mudanzawwds_26_tfmudanzadirecciondestino ,
                                             string AV205Mudanzawwds_29_tfmudanzapisodptodestino_sel ,
                                             string AV204Mudanzawwds_28_tfmudanzapisodptodestino ,
                                             decimal AV206Mudanzawwds_30_tfmudanzadistancia ,
                                             decimal AV207Mudanzawwds_31_tfmudanzadistancia_to ,
                                             int AV208Mudanzawwds_32_tfmudanzavehiculosugerido_sels_Count ,
                                             decimal AV209Mudanzawwds_33_tfmudanzapreciobasexhora ,
                                             decimal AV210Mudanzawwds_34_tfmudanzapreciobasexhora_to ,
                                             short AV211Mudanzawwds_35_tfmudanzapeajecantidad ,
                                             short AV212Mudanzawwds_36_tfmudanzapeajecantidad_to ,
                                             decimal AV213Mudanzawwds_37_tfmudanzapeajevalor ,
                                             decimal AV214Mudanzawwds_38_tfmudanzapeajevalor_to ,
                                             short AV215Mudanzawwds_39_tftipoinmuebleorigenid ,
                                             short AV216Mudanzawwds_40_tftipoinmuebleorigenid_to ,
                                             string AV218Mudanzawwds_42_tftipoinmuebleorigennombre_sel ,
                                             string AV217Mudanzawwds_41_tftipoinmuebleorigennombre ,
                                             decimal AV219Mudanzawwds_43_tftipoinmuebleorigenvalor ,
                                             decimal AV220Mudanzawwds_44_tftipoinmuebleorigenvalor_to ,
                                             long A735MudanzaId ,
                                             string A736MudanzaAsesor ,
                                             string A740MudanzaDireccionOrigen ,
                                             string A741MudanzaDireccionDestino ,
                                             string A778MudanzaPisoDptoDestino ,
                                             decimal A762MudanzaDistancia ,
                                             decimal A780MudanzaPrecioBasexHora ,
                                             short A761MudanzaPeajeCantidad ,
                                             decimal A760MudanzaPeajevalor ,
                                             short A743TipoInmuebleOrigenId ,
                                             string A755TipoInmuebleOrigenNombre ,
                                             decimal A756TipoInmuebleOrigenValor ,
                                             DateTime A737MudanzaFechaAlta ,
                                             DateTime A738MudanzaFechaServicio ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[63];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T2.[ParametroMudanzaValor] AS TipoInmuebleOrigenValor, T2.[ParametroMudanzaNombre] AS TipoInmuebleOrigenNombre, T1.[TipoInmuebleOrigenId] AS TipoInmuebleOrigenId, T1.[MudanzaPeajevalor], T1.[MudanzaPeajeCantidad], T1.[MudanzaPrecioBasexHora], T1.[MudanzaVehiculoSugerido], T1.[MudanzaDistancia], T1.[MudanzaPisoDptoDestino], T1.[MudanzaDireccionDestino], T1.[MudanzaPisoDptoOrigen], T1.[MudanzaDireccionOrigen], T1.[MudanzaFechaServicio], T1.[MudanzaFechaAlta], T1.[MudanzaAsesor], T1.[MudanzaId], T1.[MudanzaRgoHoraservicio], T1.[MudanzaHoraServicio], T1.[TipoEstacionamDestinoId], T3.[ParametroMudanzaValor] AS TipoEstacionamOrigenValor, T3.[ParametroMudanzaNombre] AS TipoEstacionamOrigenNombre, T1.[TipoEstacionamOrigenId] AS TipoEstacionamOrigenId, T4.[ParametroMudanzaValor] AS TipoInmuebleDestinoValor, T4.[ParametroMudanzaNombre] AS TipoInmuebleDestinoNombre, T1.[TipoInmuebleDestinoId] AS TipoInmuebleDestinoId FROM ((([Mudanza] T1 INNER JOIN [ParametroMudanza] T2 ON T2.[ParametroMudanzaId] = T1.[TipoInmuebleOrigenId]) INNER JOIN [ParametroMudanza] T3 ON T3.[ParametroMudanzaId] = T1.[TipoEstacionamOrigenId]) INNER JOIN [ParametroMudanza] T4 ON T4.[ParametroMudanzaId] = T1.[TipoInmuebleDestinoId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV177Mudanzawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[MudanzaId] AS decimal(18,0))) like '%' + @lV177Mudanzawwds_1_filterfulltext) or ( UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV177Mudanzawwds_1_filterfulltext)) or ( '08:00' like '%' + LOWER(@lV177Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '08') or ( '09:00' like '%' + LOWER(@lV177Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '09') or ( '10:00' like '%' + LOWER(@lV177Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '10') or ( '11:00' like '%' + LOWER(@lV177Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '11') or ( '12:00' like '%' + LOWER(@lV177Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '12') or ( '13:00' like '%' + LOWER(@lV177Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '13') or ( '14:00' like '%' + LOWER(@lV177Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '14') or ( '15:00' like '%' + LOWER(@lV177Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '15') or ( '16:00' like '%' + LOWER(@lV177Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '16') or ( '17:00' like '%' + LOWER(@lV177Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '17') or ( '18:00' like '%' + LOWER(@lV177Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '18') or ( '19:00' like '%' + LOWER(@lV177Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '19') or ( '08:00 - 12:00' like '%' + LOWER(@lV177Mudanzawwds_1_filterfulltext) and T1.[MudanzaRgoHoraservicio] = '08-12') or ( '12:00 - 16:00' like '%' + LOWER(@lV177Mudanzawwds_1_filterfulltext) and T1.[MudanzaRgoHoraservicio] = '12-16') or ( '16:00 - 20:00' like '%' + LOWER(@lV177Mudanzawwds_1_filterfulltext) and T1.[MudanzaRgoHoraservicio] = '16-20') or ( UPPER(T1.[MudanzaDireccionOrigen]) like '%' + UPPER(@lV177Mudanzawwds_1_filterfulltext)) or ( UPPER(T1.[MudanzaPisoDptoOrigen]) like '%' + UPPER(@lV177Mudanzawwds_1_filterfulltext)) or ( UPPER(T1.[MudanzaDireccionDestino]) like '%' + UPPER(@lV177Mudanzawwds_1_filterfulltext)) or ( UPPER(T1.[MudanzaPisoDptoDestino]) like '%' + UPPER(@lV177Mudanzawwds_1_filterfulltext)) or ( CONVERT( char(10), CAST(T1.[MudanzaDistancia] AS decimal(10,2))) like '%' + @lV177Mudanzawwds_1_filterfulltext) or ( UPPER(T1.[MudanzaVehiculoSugerido]) like '%' + UPPER(@lV177Mudanzawwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T1.[MudanzaPrecioBasexHora] AS decimal(18,2))) like '%' + @lV177Mudanzawwds_1_filterfulltext) or ( CONVERT( char(1), CAST(T1.[MudanzaPeajeCantidad] AS decimal(1,0))) like '%' + @lV177Mudanzawwds_1_filterfulltext) or ( CONVERT( char(18), CAST(T1.[MudanzaPeajevalor] AS decimal(18,2))) like '%' + @lV177Mudanzawwds_1_filterfulltext) or ( CONVERT( char(4), CAST(T1.[TipoInmuebleOrigenId] AS decimal(4,0))) like '%' + @lV177Mudanzawwds_1_filterfulltext) or ( UPPER(T2.[ParametroMudanzaNombre]) like '%' + UPPER(@lV177Mudanzawwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T2.[ParametroMudanzaValor] AS decimal(18,2))) like '%' + @lV177Mudanzawwds_1_filterfulltext))");
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
            GXv_int2[7] = 1;
            GXv_int2[8] = 1;
            GXv_int2[9] = 1;
            GXv_int2[10] = 1;
            GXv_int2[11] = 1;
            GXv_int2[12] = 1;
            GXv_int2[13] = 1;
            GXv_int2[14] = 1;
            GXv_int2[15] = 1;
            GXv_int2[16] = 1;
            GXv_int2[17] = 1;
            GXv_int2[18] = 1;
            GXv_int2[19] = 1;
            GXv_int2[20] = 1;
            GXv_int2[21] = 1;
            GXv_int2[22] = 1;
            GXv_int2[23] = 1;
            GXv_int2[24] = 1;
            GXv_int2[25] = 1;
            GXv_int2[26] = 1;
            GXv_int2[27] = 1;
            GXv_int2[28] = 1;
         }
         if ( ( StringUtil.StrCmp(AV178Mudanzawwds_2_dynamicfiltersselector1, "MUDANZAASESOR") == 0 ) && ( AV179Mudanzawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV180Mudanzawwds_4_mudanzaasesor1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV180Mudanzawwds_4_mudanzaasesor1))");
         }
         else
         {
            GXv_int2[29] = 1;
         }
         if ( ( StringUtil.StrCmp(AV178Mudanzawwds_2_dynamicfiltersselector1, "MUDANZAASESOR") == 0 ) && ( AV179Mudanzawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV180Mudanzawwds_4_mudanzaasesor1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV180Mudanzawwds_4_mudanzaasesor1))");
         }
         else
         {
            GXv_int2[30] = 1;
         }
         if ( AV181Mudanzawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV182Mudanzawwds_6_dynamicfiltersselector2, "MUDANZAASESOR") == 0 ) && ( AV183Mudanzawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV184Mudanzawwds_8_mudanzaasesor2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV184Mudanzawwds_8_mudanzaasesor2))");
         }
         else
         {
            GXv_int2[31] = 1;
         }
         if ( AV181Mudanzawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV182Mudanzawwds_6_dynamicfiltersselector2, "MUDANZAASESOR") == 0 ) && ( AV183Mudanzawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV184Mudanzawwds_8_mudanzaasesor2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV184Mudanzawwds_8_mudanzaasesor2))");
         }
         else
         {
            GXv_int2[32] = 1;
         }
         if ( AV185Mudanzawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV186Mudanzawwds_10_dynamicfiltersselector3, "MUDANZAASESOR") == 0 ) && ( AV187Mudanzawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV188Mudanzawwds_12_mudanzaasesor3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV188Mudanzawwds_12_mudanzaasesor3))");
         }
         else
         {
            GXv_int2[33] = 1;
         }
         if ( AV185Mudanzawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV186Mudanzawwds_10_dynamicfiltersselector3, "MUDANZAASESOR") == 0 ) && ( AV187Mudanzawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV188Mudanzawwds_12_mudanzaasesor3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV188Mudanzawwds_12_mudanzaasesor3))");
         }
         else
         {
            GXv_int2[34] = 1;
         }
         if ( ! (0==AV189Mudanzawwds_13_tfmudanzaid) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] >= @AV189Mudanzawwds_13_tfmudanzaid)");
         }
         else
         {
            GXv_int2[35] = 1;
         }
         if ( ! (0==AV190Mudanzawwds_14_tfmudanzaid_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] <= @AV190Mudanzawwds_14_tfmudanzaid_to)");
         }
         else
         {
            GXv_int2[36] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV192Mudanzawwds_16_tfmudanzaasesor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV191Mudanzawwds_15_tfmudanzaasesor)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV191Mudanzawwds_15_tfmudanzaasesor))");
         }
         else
         {
            GXv_int2[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV192Mudanzawwds_16_tfmudanzaasesor_sel)) && ! ( StringUtil.StrCmp(AV192Mudanzawwds_16_tfmudanzaasesor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaAsesor] = @AV192Mudanzawwds_16_tfmudanzaasesor_sel)");
         }
         else
         {
            GXv_int2[38] = 1;
         }
         if ( StringUtil.StrCmp(AV192Mudanzawwds_16_tfmudanzaasesor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaAsesor] = ''))");
         }
         if ( ! (DateTime.MinValue==AV193Mudanzawwds_17_tfmudanzafechaalta) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaAlta] >= @AV193Mudanzawwds_17_tfmudanzafechaalta)");
         }
         else
         {
            GXv_int2[39] = 1;
         }
         if ( ! (DateTime.MinValue==AV194Mudanzawwds_18_tfmudanzafechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaAlta] <= @AV194Mudanzawwds_18_tfmudanzafechaalta_to)");
         }
         else
         {
            GXv_int2[40] = 1;
         }
         if ( ! (DateTime.MinValue==AV195Mudanzawwds_19_tfmudanzafechaservicio) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaServicio] >= @AV195Mudanzawwds_19_tfmudanzafechaservicio)");
         }
         else
         {
            GXv_int2[41] = 1;
         }
         if ( ! (DateTime.MinValue==AV196Mudanzawwds_20_tfmudanzafechaservicio_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaServicio] <= @AV196Mudanzawwds_20_tfmudanzafechaservicio_to)");
         }
         else
         {
            GXv_int2[42] = 1;
         }
         if ( AV197Mudanzawwds_21_tfmudanzahoraservicio_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV197Mudanzawwds_21_tfmudanzahoraservicio_sels, "T1.[MudanzaHoraServicio] IN (", ")")+")");
         }
         if ( AV198Mudanzawwds_22_tfmudanzargohoraservicio_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV198Mudanzawwds_22_tfmudanzargohoraservicio_sels, "T1.[MudanzaRgoHoraservicio] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV200Mudanzawwds_24_tfmudanzadireccionorigen_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV199Mudanzawwds_23_tfmudanzadireccionorigen)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaDireccionOrigen]) like UPPER(@lV199Mudanzawwds_23_tfmudanzadireccionorigen))");
         }
         else
         {
            GXv_int2[43] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV200Mudanzawwds_24_tfmudanzadireccionorigen_sel)) && ! ( StringUtil.StrCmp(AV200Mudanzawwds_24_tfmudanzadireccionorigen_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDireccionOrigen] = @AV200Mudanzawwds_24_tfmudanzadireccionorigen_sel)");
         }
         else
         {
            GXv_int2[44] = 1;
         }
         if ( StringUtil.StrCmp(AV200Mudanzawwds_24_tfmudanzadireccionorigen_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaDireccionOrigen] = ''))");
         }
         if ( AV201Mudanzawwds_25_tfmudanzapisodptoorigen_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV201Mudanzawwds_25_tfmudanzapisodptoorigen_sels, "T1.[MudanzaPisoDptoOrigen] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV203Mudanzawwds_27_tfmudanzadirecciondestino_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV202Mudanzawwds_26_tfmudanzadirecciondestino)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaDireccionDestino]) like UPPER(@lV202Mudanzawwds_26_tfmudanzadirecciondestino))");
         }
         else
         {
            GXv_int2[45] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV203Mudanzawwds_27_tfmudanzadirecciondestino_sel)) && ! ( StringUtil.StrCmp(AV203Mudanzawwds_27_tfmudanzadirecciondestino_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDireccionDestino] = @AV203Mudanzawwds_27_tfmudanzadirecciondestino_sel)");
         }
         else
         {
            GXv_int2[46] = 1;
         }
         if ( StringUtil.StrCmp(AV203Mudanzawwds_27_tfmudanzadirecciondestino_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaDireccionDestino] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV205Mudanzawwds_29_tfmudanzapisodptodestino_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV204Mudanzawwds_28_tfmudanzapisodptodestino)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaPisoDptoDestino]) like UPPER(@lV204Mudanzawwds_28_tfmudanzapisodptodestino))");
         }
         else
         {
            GXv_int2[47] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV205Mudanzawwds_29_tfmudanzapisodptodestino_sel)) && ! ( StringUtil.StrCmp(AV205Mudanzawwds_29_tfmudanzapisodptodestino_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPisoDptoDestino] = @AV205Mudanzawwds_29_tfmudanzapisodptodestino_sel)");
         }
         else
         {
            GXv_int2[48] = 1;
         }
         if ( StringUtil.StrCmp(AV205Mudanzawwds_29_tfmudanzapisodptodestino_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaPisoDptoDestino] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV206Mudanzawwds_30_tfmudanzadistancia) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDistancia] >= @AV206Mudanzawwds_30_tfmudanzadistancia)");
         }
         else
         {
            GXv_int2[49] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV207Mudanzawwds_31_tfmudanzadistancia_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDistancia] <= @AV207Mudanzawwds_31_tfmudanzadistancia_to)");
         }
         else
         {
            GXv_int2[50] = 1;
         }
         if ( AV208Mudanzawwds_32_tfmudanzavehiculosugerido_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV208Mudanzawwds_32_tfmudanzavehiculosugerido_sels, "T1.[MudanzaVehiculoSugerido] IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV209Mudanzawwds_33_tfmudanzapreciobasexhora) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPrecioBasexHora] >= @AV209Mudanzawwds_33_tfmudanzapreciobasexhora)");
         }
         else
         {
            GXv_int2[51] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV210Mudanzawwds_34_tfmudanzapreciobasexhora_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPrecioBasexHora] <= @AV210Mudanzawwds_34_tfmudanzapreciobasexhora_to)");
         }
         else
         {
            GXv_int2[52] = 1;
         }
         if ( ! (0==AV211Mudanzawwds_35_tfmudanzapeajecantidad) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajeCantidad] >= @AV211Mudanzawwds_35_tfmudanzapeajecantidad)");
         }
         else
         {
            GXv_int2[53] = 1;
         }
         if ( ! (0==AV212Mudanzawwds_36_tfmudanzapeajecantidad_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajeCantidad] <= @AV212Mudanzawwds_36_tfmudanzapeajecantidad_to)");
         }
         else
         {
            GXv_int2[54] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV213Mudanzawwds_37_tfmudanzapeajevalor) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajevalor] >= @AV213Mudanzawwds_37_tfmudanzapeajevalor)");
         }
         else
         {
            GXv_int2[55] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV214Mudanzawwds_38_tfmudanzapeajevalor_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajevalor] <= @AV214Mudanzawwds_38_tfmudanzapeajevalor_to)");
         }
         else
         {
            GXv_int2[56] = 1;
         }
         if ( ! (0==AV215Mudanzawwds_39_tftipoinmuebleorigenid) )
         {
            AddWhere(sWhereString, "(T1.[TipoInmuebleOrigenId] >= @AV215Mudanzawwds_39_tftipoinmuebleorigenid)");
         }
         else
         {
            GXv_int2[57] = 1;
         }
         if ( ! (0==AV216Mudanzawwds_40_tftipoinmuebleorigenid_to) )
         {
            AddWhere(sWhereString, "(T1.[TipoInmuebleOrigenId] <= @AV216Mudanzawwds_40_tftipoinmuebleorigenid_to)");
         }
         else
         {
            GXv_int2[58] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV218Mudanzawwds_42_tftipoinmuebleorigennombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV217Mudanzawwds_41_tftipoinmuebleorigennombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ParametroMudanzaNombre]) like UPPER(@lV217Mudanzawwds_41_tftipoinmuebleorigennombre))");
         }
         else
         {
            GXv_int2[59] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV218Mudanzawwds_42_tftipoinmuebleorigennombre_sel)) && ! ( StringUtil.StrCmp(AV218Mudanzawwds_42_tftipoinmuebleorigennombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ParametroMudanzaNombre] = @AV218Mudanzawwds_42_tftipoinmuebleorigennombre_sel)");
         }
         else
         {
            GXv_int2[60] = 1;
         }
         if ( StringUtil.StrCmp(AV218Mudanzawwds_42_tftipoinmuebleorigennombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ParametroMudanzaNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV219Mudanzawwds_43_tftipoinmuebleorigenvalor) )
         {
            AddWhere(sWhereString, "(T2.[ParametroMudanzaValor] >= @AV219Mudanzawwds_43_tftipoinmuebleorigenvalor)");
         }
         else
         {
            GXv_int2[61] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV220Mudanzawwds_44_tftipoinmuebleorigenvalor_to) )
         {
            AddWhere(sWhereString, "(T2.[ParametroMudanzaValor] <= @AV220Mudanzawwds_44_tftipoinmuebleorigenvalor_to)");
         }
         else
         {
            GXv_int2[62] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MudanzaAsesor]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MudanzaAsesor] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MudanzaId]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MudanzaId] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MudanzaFechaAlta]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MudanzaFechaAlta] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MudanzaFechaServicio]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MudanzaFechaServicio] DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MudanzaHoraServicio]";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MudanzaHoraServicio] DESC";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MudanzaRgoHoraservicio]";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MudanzaRgoHoraservicio] DESC";
         }
         else if ( ( AV11OrderedBy == 7 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MudanzaDireccionOrigen]";
         }
         else if ( ( AV11OrderedBy == 7 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MudanzaDireccionOrigen] DESC";
         }
         else if ( ( AV11OrderedBy == 8 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MudanzaPisoDptoOrigen]";
         }
         else if ( ( AV11OrderedBy == 8 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MudanzaPisoDptoOrigen] DESC";
         }
         else if ( ( AV11OrderedBy == 9 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MudanzaDireccionDestino]";
         }
         else if ( ( AV11OrderedBy == 9 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MudanzaDireccionDestino] DESC";
         }
         else if ( ( AV11OrderedBy == 10 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MudanzaPisoDptoDestino]";
         }
         else if ( ( AV11OrderedBy == 10 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MudanzaPisoDptoDestino] DESC";
         }
         else if ( ( AV11OrderedBy == 11 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MudanzaDistancia]";
         }
         else if ( ( AV11OrderedBy == 11 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MudanzaDistancia] DESC";
         }
         else if ( ( AV11OrderedBy == 12 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MudanzaVehiculoSugerido]";
         }
         else if ( ( AV11OrderedBy == 12 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MudanzaVehiculoSugerido] DESC";
         }
         else if ( ( AV11OrderedBy == 13 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MudanzaPrecioBasexHora]";
         }
         else if ( ( AV11OrderedBy == 13 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MudanzaPrecioBasexHora] DESC";
         }
         else if ( ( AV11OrderedBy == 14 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MudanzaPeajeCantidad]";
         }
         else if ( ( AV11OrderedBy == 14 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MudanzaPeajeCantidad] DESC";
         }
         else if ( ( AV11OrderedBy == 15 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[TipoInmuebleOrigenId]";
         }
         else if ( ( AV11OrderedBy == 15 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[TipoInmuebleOrigenId] DESC";
         }
         else if ( ( AV11OrderedBy == 16 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ParametroMudanzaNombre]";
         }
         else if ( ( AV11OrderedBy == 16 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ParametroMudanzaNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 17 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ParametroMudanzaValor]";
         }
         else if ( ( AV11OrderedBy == 17 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ParametroMudanzaValor] DESC";
         }
         else if ( ( AV11OrderedBy == 18 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[TipoInmuebleDestinoId]";
         }
         else if ( ( AV11OrderedBy == 18 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[TipoInmuebleDestinoId] DESC";
         }
         else if ( ( AV11OrderedBy == 19 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.[ParametroMudanzaNombre]";
         }
         else if ( ( AV11OrderedBy == 19 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.[ParametroMudanzaNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 20 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.[ParametroMudanzaValor]";
         }
         else if ( ( AV11OrderedBy == 20 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.[ParametroMudanzaValor] DESC";
         }
         else if ( ( AV11OrderedBy == 21 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[TipoEstacionamOrigenId]";
         }
         else if ( ( AV11OrderedBy == 21 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[TipoEstacionamOrigenId] DESC";
         }
         else if ( ( AV11OrderedBy == 22 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[ParametroMudanzaNombre]";
         }
         else if ( ( AV11OrderedBy == 22 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[ParametroMudanzaNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 23 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[ParametroMudanzaValor]";
         }
         else if ( ( AV11OrderedBy == 23 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[ParametroMudanzaValor] DESC";
         }
         else if ( ( AV11OrderedBy == 24 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[TipoEstacionamDestinoId]";
         }
         else if ( ( AV11OrderedBy == 24 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[TipoEstacionamDestinoId] DESC";
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
                     return conditional_P00FH2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (string)dynConstraints[6] , (GxSimpleCollection<string>)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] , (int)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (int)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (decimal)dynConstraints[37] , (decimal)dynConstraints[38] , (int)dynConstraints[39] , (decimal)dynConstraints[40] , (decimal)dynConstraints[41] , (short)dynConstraints[42] , (short)dynConstraints[43] , (decimal)dynConstraints[44] , (decimal)dynConstraints[45] , (short)dynConstraints[46] , (short)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (decimal)dynConstraints[50] , (decimal)dynConstraints[51] , (long)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (decimal)dynConstraints[57] , (decimal)dynConstraints[58] , (short)dynConstraints[59] , (decimal)dynConstraints[60] , (short)dynConstraints[61] , (string)dynConstraints[62] , (decimal)dynConstraints[63] , (DateTime)dynConstraints[64] , (DateTime)dynConstraints[65] , (short)dynConstraints[66] , (bool)dynConstraints[67] );
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
          Object[] prmP00FH2;
          prmP00FH2 = new Object[] {
          new ParDef("@lV177Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV177Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV177Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV177Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV177Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV177Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV177Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV177Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV177Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV177Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV177Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV177Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV177Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV177Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV177Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV177Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV177Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV177Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV177Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV177Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV177Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV177Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV177Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV177Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV177Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV177Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV177Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV177Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV177Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV180Mudanzawwds_4_mudanzaasesor1",GXType.VarChar,80,0) ,
          new ParDef("@lV180Mudanzawwds_4_mudanzaasesor1",GXType.VarChar,80,0) ,
          new ParDef("@lV184Mudanzawwds_8_mudanzaasesor2",GXType.VarChar,80,0) ,
          new ParDef("@lV184Mudanzawwds_8_mudanzaasesor2",GXType.VarChar,80,0) ,
          new ParDef("@lV188Mudanzawwds_12_mudanzaasesor3",GXType.VarChar,80,0) ,
          new ParDef("@lV188Mudanzawwds_12_mudanzaasesor3",GXType.VarChar,80,0) ,
          new ParDef("@AV189Mudanzawwds_13_tfmudanzaid",GXType.Decimal,18,0) ,
          new ParDef("@AV190Mudanzawwds_14_tfmudanzaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV191Mudanzawwds_15_tfmudanzaasesor",GXType.VarChar,80,0) ,
          new ParDef("@AV192Mudanzawwds_16_tfmudanzaasesor_sel",GXType.NVarChar,80,0) ,
          new ParDef("@AV193Mudanzawwds_17_tfmudanzafechaalta",GXType.Date,8,0) ,
          new ParDef("@AV194Mudanzawwds_18_tfmudanzafechaalta_to",GXType.Date,8,0) ,
          new ParDef("@AV195Mudanzawwds_19_tfmudanzafechaservicio",GXType.Date,8,0) ,
          new ParDef("@AV196Mudanzawwds_20_tfmudanzafechaservicio_to",GXType.Date,8,0) ,
          new ParDef("@lV199Mudanzawwds_23_tfmudanzadireccionorigen",GXType.VarChar,200,0) ,
          new ParDef("@AV200Mudanzawwds_24_tfmudanzadireccionorigen_sel",GXType.NVarChar,200,0) ,
          new ParDef("@lV202Mudanzawwds_26_tfmudanzadirecciondestino",GXType.VarChar,200,0) ,
          new ParDef("@AV203Mudanzawwds_27_tfmudanzadirecciondestino_sel",GXType.NVarChar,200,0) ,
          new ParDef("@lV204Mudanzawwds_28_tfmudanzapisodptodestino",GXType.Char,30,0) ,
          new ParDef("@AV205Mudanzawwds_29_tfmudanzapisodptodestino_sel",GXType.NChar,30,0) ,
          new ParDef("@AV206Mudanzawwds_30_tfmudanzadistancia",GXType.Decimal,10,2) ,
          new ParDef("@AV207Mudanzawwds_31_tfmudanzadistancia_to",GXType.Decimal,10,2) ,
          new ParDef("@AV209Mudanzawwds_33_tfmudanzapreciobasexhora",GXType.Decimal,18,2) ,
          new ParDef("@AV210Mudanzawwds_34_tfmudanzapreciobasexhora_to",GXType.Decimal,18,2) ,
          new ParDef("@AV211Mudanzawwds_35_tfmudanzapeajecantidad",GXType.Int16,1,0) ,
          new ParDef("@AV212Mudanzawwds_36_tfmudanzapeajecantidad_to",GXType.Int16,1,0) ,
          new ParDef("@AV213Mudanzawwds_37_tfmudanzapeajevalor",GXType.Decimal,18,2) ,
          new ParDef("@AV214Mudanzawwds_38_tfmudanzapeajevalor_to",GXType.Decimal,18,2) ,
          new ParDef("@AV215Mudanzawwds_39_tftipoinmuebleorigenid",GXType.Int16,4,0) ,
          new ParDef("@AV216Mudanzawwds_40_tftipoinmuebleorigenid_to",GXType.Int16,4,0) ,
          new ParDef("@lV217Mudanzawwds_41_tftipoinmuebleorigennombre",GXType.VarChar,100,0) ,
          new ParDef("@AV218Mudanzawwds_42_tftipoinmuebleorigennombre_sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV219Mudanzawwds_43_tftipoinmuebleorigenvalor",GXType.Decimal,18,2) ,
          new ParDef("@AV220Mudanzawwds_44_tftipoinmuebleorigenvalor_to",GXType.Decimal,18,2)
          };
          def= new CursorDef[] {
              new CursorDef("P00FH2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FH2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 30);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 30);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(13);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(14);
                ((string[]) buf[14])[0] = rslt.getVarchar(15);
                ((long[]) buf[15])[0] = rslt.getLong(16);
                ((string[]) buf[16])[0] = rslt.getString(17, 5);
                ((bool[]) buf[17])[0] = rslt.wasNull(17);
                ((string[]) buf[18])[0] = rslt.getString(18, 2);
                ((bool[]) buf[19])[0] = rslt.wasNull(18);
                ((short[]) buf[20])[0] = rslt.getShort(19);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(20);
                ((string[]) buf[22])[0] = rslt.getVarchar(21);
                ((short[]) buf[23])[0] = rslt.getShort(22);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(23);
                ((string[]) buf[25])[0] = rslt.getVarchar(24);
                ((short[]) buf[26])[0] = rslt.getShort(25);
                return;
       }
    }

 }

}
