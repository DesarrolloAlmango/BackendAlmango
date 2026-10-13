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
   public class incidenciawwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public incidenciawwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public incidenciawwexportreport( IGxContext context )
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
         setOutputFileName("IncidenciaWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWIncidencia", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV83Pgmname));
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
               AV81Title = context.GetMessage( "Lista de Incidencia", "");
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
            HB30( true, 0) ;
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
            HB30( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV40GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV40GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV35GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "INCIDENCIAORIGEN") == 0 )
            {
               AV16IncidenciaOrigen1 = AV35GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16IncidenciaOrigen1)) )
               {
                  AV19FilterIncidenciaOrigen1ValueDescription = context.GetMessage( gxdomainorigen.getDescription(context,AV16IncidenciaOrigen1), "");
                  AV18FilterIncidenciaOrigenValueDescription = AV19FilterIncidenciaOrigen1ValueDescription;
                  HB30( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Origen", ""), 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18FilterIncidenciaOrigenValueDescription, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "MOTIVONOMBRE") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV20MotivoNombre1 = AV35GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20MotivoNombre1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV21FilterMotivoNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Motivo Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV21FilterMotivoNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Motivo Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV22MotivoNombre = AV20MotivoNombre1;
                  HB30( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21FilterMotivoNombreDescription, "")), 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22MotivoNombre, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV40GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV40GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV35GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "INCIDENCIAORIGEN") == 0 )
               {
                  AV26IncidenciaOrigen2 = AV35GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26IncidenciaOrigen2)) )
                  {
                     AV27FilterIncidenciaOrigen2ValueDescription = context.GetMessage( gxdomainorigen.getDescription(context,AV26IncidenciaOrigen2), "");
                     AV18FilterIncidenciaOrigenValueDescription = AV27FilterIncidenciaOrigen2ValueDescription;
                     HB30( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.GetMessage( "Origen", ""), 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18FilterIncidenciaOrigenValueDescription, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "MOTIVONOMBRE") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV28MotivoNombre2 = AV35GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28MotivoNombre2)) )
                  {
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV21FilterMotivoNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Motivo Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV21FilterMotivoNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Motivo Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV22MotivoNombre = AV28MotivoNombre2;
                     HB30( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21FilterMotivoNombreDescription, "")), 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22MotivoNombre, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV40GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV29DynamicFiltersEnabled3 = true;
                  AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV40GridState.gxTpr_Dynamicfilters.Item(3));
                  AV30DynamicFiltersSelector3 = AV35GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "INCIDENCIAORIGEN") == 0 )
                  {
                     AV32IncidenciaOrigen3 = AV35GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32IncidenciaOrigen3)) )
                     {
                        AV33FilterIncidenciaOrigen3ValueDescription = context.GetMessage( gxdomainorigen.getDescription(context,AV32IncidenciaOrigen3), "");
                        AV18FilterIncidenciaOrigenValueDescription = AV33FilterIncidenciaOrigen3ValueDescription;
                        HB30( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.GetMessage( "Origen", ""), 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18FilterIncidenciaOrigenValueDescription, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "MOTIVONOMBRE") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV34MotivoNombre3 = AV35GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34MotivoNombre3)) )
                     {
                        if ( AV31DynamicFiltersOperator3 == 0 )
                        {
                           AV21FilterMotivoNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Motivo Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 1 )
                        {
                           AV21FilterMotivoNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Motivo Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV22MotivoNombre = AV34MotivoNombre3;
                        HB30( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21FilterMotivoNombreDescription, "")), 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22MotivoNombre, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV42TFIncidenciaId) && (0==AV43TFIncidenciaId_To) ) )
         {
            HB30( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Id", ""), 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV42TFIncidenciaId), "ZZZZZZZZZZZZZZZZZ9")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV64TFIncidenciaId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Id", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HB30( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64TFIncidenciaId_To_Description, "")), 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV43TFIncidenciaId_To), "ZZZZZZZZZZZZZZZZZ9")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         AV46TFIncidenciaOrigen_Sels.FromJSonString(AV44TFIncidenciaOrigen_SelsJson, null);
         if ( ! ( AV46TFIncidenciaOrigen_Sels.Count == 0 ) )
         {
            AV70i = 1;
            AV86GXV1 = 1;
            while ( AV86GXV1 <= AV46TFIncidenciaOrigen_Sels.Count )
            {
               AV47TFIncidenciaOrigen_Sel = AV46TFIncidenciaOrigen_Sels.GetString(AV86GXV1);
               if ( AV70i == 1 )
               {
                  AV45TFIncidenciaOrigen_SelDscs = "";
               }
               else
               {
                  AV45TFIncidenciaOrigen_SelDscs += ", ";
               }
               AV65FilterTFIncidenciaOrigen_SelValueDescription = context.GetMessage( gxdomainorigen.getDescription(context,AV47TFIncidenciaOrigen_Sel), "");
               AV45TFIncidenciaOrigen_SelDscs += AV65FilterTFIncidenciaOrigen_SelValueDescription;
               AV70i = (long)(AV70i+1);
               AV86GXV1 = (int)(AV86GXV1+1);
            }
            HB30( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Origen", ""), 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45TFIncidenciaOrigen_SelDscs, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49TFIncidenciaCodRef_Sel)) )
         {
            AV69TempBoolean = (bool)(((StringUtil.StrCmp(AV49TFIncidenciaCodRef_Sel, "<#Empty#>")==0)));
            AV49TFIncidenciaCodRef_Sel = (AV69TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV49TFIncidenciaCodRef_Sel);
            HB30( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Referencia", ""), 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49TFIncidenciaCodRef_Sel, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV49TFIncidenciaCodRef_Sel = (AV69TempBoolean ? "<#Empty#>" : AV49TFIncidenciaCodRef_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48TFIncidenciaCodRef)) )
            {
               HB30( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Referencia", ""), 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48TFIncidenciaCodRef, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51TFMotivoNombre_Sel)) )
         {
            AV69TempBoolean = (bool)(((StringUtil.StrCmp(AV51TFMotivoNombre_Sel, "<#Empty#>")==0)));
            AV51TFMotivoNombre_Sel = (AV69TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV51TFMotivoNombre_Sel);
            HB30( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51TFMotivoNombre_Sel, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV51TFMotivoNombre_Sel = (AV69TempBoolean ? "<#Empty#>" : AV51TFMotivoNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50TFMotivoNombre)) )
            {
               HB30( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50TFMotivoNombre, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV54TFIncidenciaEstado_Sels.FromJSonString(AV52TFIncidenciaEstado_SelsJson, null);
         if ( ! ( AV54TFIncidenciaEstado_Sels.Count == 0 ) )
         {
            AV70i = 1;
            AV87GXV2 = 1;
            while ( AV87GXV2 <= AV54TFIncidenciaEstado_Sels.Count )
            {
               AV55TFIncidenciaEstado_Sel = AV54TFIncidenciaEstado_Sels.GetString(AV87GXV2);
               if ( AV70i == 1 )
               {
                  AV53TFIncidenciaEstado_SelDscs = "";
               }
               else
               {
                  AV53TFIncidenciaEstado_SelDscs += ", ";
               }
               AV66FilterTFIncidenciaEstado_SelValueDescription = context.GetMessage( gxdomainestadoope.getDescription(context,AV55TFIncidenciaEstado_Sel), "");
               AV53TFIncidenciaEstado_SelDscs += AV66FilterTFIncidenciaEstado_SelValueDescription;
               AV70i = (long)(AV70i+1);
               AV87GXV2 = (int)(AV87GXV2+1);
            }
            HB30( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53TFIncidenciaEstado_SelDscs, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57TFIncidenciaUsrAlta_Sel)) )
         {
            AV69TempBoolean = (bool)(((StringUtil.StrCmp(AV57TFIncidenciaUsrAlta_Sel, "<#Empty#>")==0)));
            AV57TFIncidenciaUsrAlta_Sel = (AV69TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV57TFIncidenciaUsrAlta_Sel);
            HB30( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Alta", ""), 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57TFIncidenciaUsrAlta_Sel, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV57TFIncidenciaUsrAlta_Sel = (AV69TempBoolean ? "<#Empty#>" : AV57TFIncidenciaUsrAlta_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56TFIncidenciaUsrAlta)) )
            {
               HB30( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Alta", ""), 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56TFIncidenciaUsrAlta, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (DateTime.MinValue==AV58TFIncidenciaFechaAlta) && (DateTime.MinValue==AV59TFIncidenciaFechaAlta_To) ) )
         {
            HB30( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Alta", ""), 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV58TFIncidenciaFechaAlta, "99/99/99"), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV67TFIncidenciaFechaAlta_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Alta", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HB30( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67TFIncidenciaFechaAlta_To_Description, "")), 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV59TFIncidenciaFechaAlta_To, "99/99/99"), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61TFIncidenciaUsrActualizacion_Sel)) )
         {
            AV69TempBoolean = (bool)(((StringUtil.StrCmp(AV61TFIncidenciaUsrActualizacion_Sel, "<#Empty#>")==0)));
            AV61TFIncidenciaUsrActualizacion_Sel = (AV69TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV61TFIncidenciaUsrActualizacion_Sel);
            HB30( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Actualiza", ""), 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61TFIncidenciaUsrActualizacion_Sel, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV61TFIncidenciaUsrActualizacion_Sel = (AV69TempBoolean ? "<#Empty#>" : AV61TFIncidenciaUsrActualizacion_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60TFIncidenciaUsrActualizacion)) )
            {
               HB30( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Actualiza", ""), 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60TFIncidenciaUsrActualizacion, "")), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (DateTime.MinValue==AV62TFIncidenciaFechaActualizacion) && (DateTime.MinValue==AV63TFIncidenciaFechaActualizacion_To) ) )
         {
            HB30( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Actualiza", ""), 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV62TFIncidenciaFechaActualizacion, "99/99/99"), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV68TFIncidenciaFechaActualizacion_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Actualiza", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HB30( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68TFIncidenciaFechaActualizacion_To_Description, "")), 25, Gx_line+0, 186, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV63TFIncidenciaFechaActualizacion_To, "99/99/99"), 186, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HB30( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HB30( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Id", ""), 30, Gx_line+10, 110, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Origen", ""), 114, Gx_line+10, 194, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Referencia", ""), 198, Gx_line+10, 278, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 282, Gx_line+10, 362, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 366, Gx_line+10, 446, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Alta", ""), 450, Gx_line+10, 531, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Alta", ""), 535, Gx_line+10, 616, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Actualiza", ""), 620, Gx_line+10, 702, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Actualiza", ""), 706, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV89Incidenciawwds_1_filterfulltext = AV13FilterFullText;
         AV90Incidenciawwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV91Incidenciawwds_3_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV92Incidenciawwds_4_incidenciaorigen1 = AV16IncidenciaOrigen1;
         AV93Incidenciawwds_5_motivonombre1 = AV20MotivoNombre1;
         AV94Incidenciawwds_6_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV95Incidenciawwds_7_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV96Incidenciawwds_8_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV97Incidenciawwds_9_incidenciaorigen2 = AV26IncidenciaOrigen2;
         AV98Incidenciawwds_10_motivonombre2 = AV28MotivoNombre2;
         AV99Incidenciawwds_11_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV100Incidenciawwds_12_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV101Incidenciawwds_13_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV102Incidenciawwds_14_incidenciaorigen3 = AV32IncidenciaOrigen3;
         AV103Incidenciawwds_15_motivonombre3 = AV34MotivoNombre3;
         AV104Incidenciawwds_16_tfincidenciaid = AV42TFIncidenciaId;
         AV105Incidenciawwds_17_tfincidenciaid_to = AV43TFIncidenciaId_To;
         AV106Incidenciawwds_18_tfincidenciaorigen_sels = AV46TFIncidenciaOrigen_Sels;
         AV107Incidenciawwds_19_tfincidenciacodref = AV48TFIncidenciaCodRef;
         AV108Incidenciawwds_20_tfincidenciacodref_sel = AV49TFIncidenciaCodRef_Sel;
         AV109Incidenciawwds_21_tfmotivonombre = AV50TFMotivoNombre;
         AV110Incidenciawwds_22_tfmotivonombre_sel = AV51TFMotivoNombre_Sel;
         AV111Incidenciawwds_23_tfincidenciaestado_sels = AV54TFIncidenciaEstado_Sels;
         AV112Incidenciawwds_24_tfincidenciausralta = AV56TFIncidenciaUsrAlta;
         AV113Incidenciawwds_25_tfincidenciausralta_sel = AV57TFIncidenciaUsrAlta_Sel;
         AV114Incidenciawwds_26_tfincidenciafechaalta = AV58TFIncidenciaFechaAlta;
         AV115Incidenciawwds_27_tfincidenciafechaalta_to = AV59TFIncidenciaFechaAlta_To;
         AV116Incidenciawwds_28_tfincidenciausractualizacion = AV60TFIncidenciaUsrActualizacion;
         AV117Incidenciawwds_29_tfincidenciausractualizacion_sel = AV61TFIncidenciaUsrActualizacion_Sel;
         AV118Incidenciawwds_30_tfincidenciafechaactualizacion = AV62TFIncidenciaFechaActualizacion;
         AV119Incidenciawwds_31_tfincidenciafechaactualizacion_to = AV63TFIncidenciaFechaActualizacion_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A611IncidenciaOrigen ,
                                              AV106Incidenciawwds_18_tfincidenciaorigen_sels ,
                                              A608IncidenciaEstado ,
                                              AV111Incidenciawwds_23_tfincidenciaestado_sels ,
                                              AV90Incidenciawwds_2_dynamicfiltersselector1 ,
                                              AV92Incidenciawwds_4_incidenciaorigen1 ,
                                              AV91Incidenciawwds_3_dynamicfiltersoperator1 ,
                                              AV93Incidenciawwds_5_motivonombre1 ,
                                              AV94Incidenciawwds_6_dynamicfiltersenabled2 ,
                                              AV95Incidenciawwds_7_dynamicfiltersselector2 ,
                                              AV97Incidenciawwds_9_incidenciaorigen2 ,
                                              AV96Incidenciawwds_8_dynamicfiltersoperator2 ,
                                              AV98Incidenciawwds_10_motivonombre2 ,
                                              AV99Incidenciawwds_11_dynamicfiltersenabled3 ,
                                              AV100Incidenciawwds_12_dynamicfiltersselector3 ,
                                              AV102Incidenciawwds_14_incidenciaorigen3 ,
                                              AV101Incidenciawwds_13_dynamicfiltersoperator3 ,
                                              AV103Incidenciawwds_15_motivonombre3 ,
                                              AV104Incidenciawwds_16_tfincidenciaid ,
                                              AV105Incidenciawwds_17_tfincidenciaid_to ,
                                              AV106Incidenciawwds_18_tfincidenciaorigen_sels.Count ,
                                              AV108Incidenciawwds_20_tfincidenciacodref_sel ,
                                              AV107Incidenciawwds_19_tfincidenciacodref ,
                                              AV110Incidenciawwds_22_tfmotivonombre_sel ,
                                              AV109Incidenciawwds_21_tfmotivonombre ,
                                              AV111Incidenciawwds_23_tfincidenciaestado_sels.Count ,
                                              AV113Incidenciawwds_25_tfincidenciausralta_sel ,
                                              AV112Incidenciawwds_24_tfincidenciausralta ,
                                              AV114Incidenciawwds_26_tfincidenciafechaalta ,
                                              AV115Incidenciawwds_27_tfincidenciafechaalta_to ,
                                              AV117Incidenciawwds_29_tfincidenciausractualizacion_sel ,
                                              AV116Incidenciawwds_28_tfincidenciausractualizacion ,
                                              AV118Incidenciawwds_30_tfincidenciafechaactualizacion ,
                                              AV119Incidenciawwds_31_tfincidenciafechaactualizacion_to ,
                                              A616MotivoNombre ,
                                              A603IncidenciaId ,
                                              A606IncidenciaCodRef ,
                                              A615IncidenciaUsrAlta ,
                                              A610IncidenciaFechaAlta ,
                                              A614IncidenciaUsrActualizacion ,
                                              A609IncidenciaFechaActualizacion ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              AV89Incidenciawwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV93Incidenciawwds_5_motivonombre1 = StringUtil.PadR( StringUtil.RTrim( AV93Incidenciawwds_5_motivonombre1), 80, "%");
         lV93Incidenciawwds_5_motivonombre1 = StringUtil.PadR( StringUtil.RTrim( AV93Incidenciawwds_5_motivonombre1), 80, "%");
         lV98Incidenciawwds_10_motivonombre2 = StringUtil.PadR( StringUtil.RTrim( AV98Incidenciawwds_10_motivonombre2), 80, "%");
         lV98Incidenciawwds_10_motivonombre2 = StringUtil.PadR( StringUtil.RTrim( AV98Incidenciawwds_10_motivonombre2), 80, "%");
         lV103Incidenciawwds_15_motivonombre3 = StringUtil.PadR( StringUtil.RTrim( AV103Incidenciawwds_15_motivonombre3), 80, "%");
         lV103Incidenciawwds_15_motivonombre3 = StringUtil.PadR( StringUtil.RTrim( AV103Incidenciawwds_15_motivonombre3), 80, "%");
         lV107Incidenciawwds_19_tfincidenciacodref = StringUtil.Concat( StringUtil.RTrim( AV107Incidenciawwds_19_tfincidenciacodref), "%", "");
         lV109Incidenciawwds_21_tfmotivonombre = StringUtil.PadR( StringUtil.RTrim( AV109Incidenciawwds_21_tfmotivonombre), 80, "%");
         lV112Incidenciawwds_24_tfincidenciausralta = StringUtil.PadR( StringUtil.RTrim( AV112Incidenciawwds_24_tfincidenciausralta), 20, "%");
         lV116Incidenciawwds_28_tfincidenciausractualizacion = StringUtil.PadR( StringUtil.RTrim( AV116Incidenciawwds_28_tfincidenciausractualizacion), 20, "%");
         /* Using cursor P00B32 */
         pr_default.execute(0, new Object[] {AV92Incidenciawwds_4_incidenciaorigen1, lV93Incidenciawwds_5_motivonombre1, lV93Incidenciawwds_5_motivonombre1, AV97Incidenciawwds_9_incidenciaorigen2, lV98Incidenciawwds_10_motivonombre2, lV98Incidenciawwds_10_motivonombre2, AV102Incidenciawwds_14_incidenciaorigen3, lV103Incidenciawwds_15_motivonombre3, lV103Incidenciawwds_15_motivonombre3, AV104Incidenciawwds_16_tfincidenciaid, AV105Incidenciawwds_17_tfincidenciaid_to, lV107Incidenciawwds_19_tfincidenciacodref, AV108Incidenciawwds_20_tfincidenciacodref_sel, lV109Incidenciawwds_21_tfmotivonombre, AV110Incidenciawwds_22_tfmotivonombre_sel, lV112Incidenciawwds_24_tfincidenciausralta, AV113Incidenciawwds_25_tfincidenciausralta_sel, AV114Incidenciawwds_26_tfincidenciafechaalta, AV115Incidenciawwds_27_tfincidenciafechaalta_to, lV116Incidenciawwds_28_tfincidenciausractualizacion, AV117Incidenciawwds_29_tfincidenciausractualizacion_sel, AV118Incidenciawwds_30_tfincidenciafechaactualizacion, AV119Incidenciawwds_31_tfincidenciafechaactualizacion_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A604MotivoId = P00B32_A604MotivoId[0];
            A609IncidenciaFechaActualizacion = P00B32_A609IncidenciaFechaActualizacion[0];
            A614IncidenciaUsrActualizacion = P00B32_A614IncidenciaUsrActualizacion[0];
            A610IncidenciaFechaAlta = P00B32_A610IncidenciaFechaAlta[0];
            A615IncidenciaUsrAlta = P00B32_A615IncidenciaUsrAlta[0];
            A616MotivoNombre = P00B32_A616MotivoNombre[0];
            A606IncidenciaCodRef = P00B32_A606IncidenciaCodRef[0];
            A603IncidenciaId = P00B32_A603IncidenciaId[0];
            A608IncidenciaEstado = P00B32_A608IncidenciaEstado[0];
            A611IncidenciaOrigen = P00B32_A611IncidenciaOrigen[0];
            A616MotivoNombre = P00B32_A616MotivoNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Incidenciawwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A603IncidenciaId), 18, 0) , StringUtil.PadR( "%" + AV89Incidenciawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "solicitudes", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV89Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A611IncidenciaOrigen, "SOL") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "proveedores", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV89Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A611IncidenciaOrigen, "PRV") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "profesionales", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV89Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A611IncidenciaOrigen, "PRF") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A606IncidenciaCodRef) , StringUtil.PadR( "%" + StringUtil.Upper( AV89Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A616MotivoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV89Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "procesado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV89Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A608IncidenciaEstado, "PRO") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV89Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A608IncidenciaEstado, "PND") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "anulado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV89Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A608IncidenciaEstado, "ANU") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A615IncidenciaUsrAlta) , StringUtil.PadR( "%" + StringUtil.Upper( AV89Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A614IncidenciaUsrActualizacion) , StringUtil.PadR( "%" + StringUtil.Upper( AV89Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
            )
            {
               AV36IncidenciaOrigenDescription = context.GetMessage( gxdomainorigen.getDescription(context,A611IncidenciaOrigen), "");
               AV37IncidenciaEstadoDescription = context.GetMessage( gxdomainestadoope.getDescription(context,A608IncidenciaEstado), "");
               /* Execute user subroutine: 'BEFOREPRINTLINE' */
               S144 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               HB30( false, 36) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A603IncidenciaId), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 110, Gx_line+25, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36IncidenciaOrigenDescription, "")), 114, Gx_line+10, 194, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A606IncidenciaCodRef, "")), 198, Gx_line+10, 278, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A616MotivoNombre, "")), 282, Gx_line+10, 362, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37IncidenciaEstadoDescription, "")), 366, Gx_line+10, 446, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A615IncidenciaUsrAlta, "")), 450, Gx_line+10, 531, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A610IncidenciaFechaAlta, "99/99/99"), 535, Gx_line+10, 616, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A614IncidenciaUsrActualizacion, "")), 620, Gx_line+10, 702, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A609IncidenciaFechaActualizacion, "99/99/99"), 706, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV38Session.Get("IncidenciaWWGridState"), "") == 0 )
         {
            AV40GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "IncidenciaWWGridState"), null, "", "");
         }
         else
         {
            AV40GridState.FromXml(AV38Session.Get("IncidenciaWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV40GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV40GridState.gxTpr_Ordereddsc;
         AV120GXV3 = 1;
         while ( AV120GXV3 <= AV40GridState.gxTpr_Filtervalues.Count )
         {
            AV41GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV40GridState.gxTpr_Filtervalues.Item(AV120GXV3));
            if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAID") == 0 )
            {
               AV42TFIncidenciaId = (long)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV43TFIncidenciaId_To = (long)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAORIGEN_SEL") == 0 )
            {
               AV44TFIncidenciaOrigen_SelsJson = AV41GridStateFilterValue.gxTpr_Value;
               AV46TFIncidenciaOrigen_Sels.FromJSonString(AV44TFIncidenciaOrigen_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFINCIDENCIACODREF") == 0 )
            {
               AV48TFIncidenciaCodRef = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFINCIDENCIACODREF_SEL") == 0 )
            {
               AV49TFIncidenciaCodRef_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFMOTIVONOMBRE") == 0 )
            {
               AV50TFMotivoNombre = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFMOTIVONOMBRE_SEL") == 0 )
            {
               AV51TFMotivoNombre_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAESTADO_SEL") == 0 )
            {
               AV52TFIncidenciaEstado_SelsJson = AV41GridStateFilterValue.gxTpr_Value;
               AV54TFIncidenciaEstado_Sels.FromJSonString(AV52TFIncidenciaEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAUSRALTA") == 0 )
            {
               AV56TFIncidenciaUsrAlta = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAUSRALTA_SEL") == 0 )
            {
               AV57TFIncidenciaUsrAlta_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAFECHAALTA") == 0 )
            {
               AV58TFIncidenciaFechaAlta = context.localUtil.CToD( AV41GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV59TFIncidenciaFechaAlta_To = context.localUtil.CToD( AV41GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAUSRACTUALIZACION") == 0 )
            {
               AV60TFIncidenciaUsrActualizacion = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAUSRACTUALIZACION_SEL") == 0 )
            {
               AV61TFIncidenciaUsrActualizacion_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAFECHAACTUALIZACION") == 0 )
            {
               AV62TFIncidenciaFechaActualizacion = context.localUtil.CToD( AV41GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV63TFIncidenciaFechaActualizacion_To = context.localUtil.CToD( AV41GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            AV120GXV3 = (int)(AV120GXV3+1);
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

      protected void HB30( bool bFoot ,
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
                  AV79PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV76DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV79PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV76DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV74AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV80Phone = "+1 550 8923";
               AV78Mail = "info@mail.com";
               AV82Website = "http://www.web.com";
               AV71AddressLine1 = "French Boulevard 2859";
               AV72AddressLine2 = "Downtown";
               AV73AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV81Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV80Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV78Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV72AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV83Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV81Title = "";
         AV13FilterFullText = "";
         AV40GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV35GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV16IncidenciaOrigen1 = "";
         AV19FilterIncidenciaOrigen1ValueDescription = "";
         AV18FilterIncidenciaOrigenValueDescription = "";
         AV20MotivoNombre1 = "";
         AV21FilterMotivoNombreDescription = "";
         AV22MotivoNombre = "";
         AV24DynamicFiltersSelector2 = "";
         AV26IncidenciaOrigen2 = "";
         AV27FilterIncidenciaOrigen2ValueDescription = "";
         AV28MotivoNombre2 = "";
         AV30DynamicFiltersSelector3 = "";
         AV32IncidenciaOrigen3 = "";
         AV33FilterIncidenciaOrigen3ValueDescription = "";
         AV34MotivoNombre3 = "";
         AV64TFIncidenciaId_To_Description = "";
         AV46TFIncidenciaOrigen_Sels = new GxSimpleCollection<string>();
         AV44TFIncidenciaOrigen_SelsJson = "";
         AV47TFIncidenciaOrigen_Sel = "";
         AV45TFIncidenciaOrigen_SelDscs = "";
         AV65FilterTFIncidenciaOrigen_SelValueDescription = "";
         AV49TFIncidenciaCodRef_Sel = "";
         AV48TFIncidenciaCodRef = "";
         AV51TFMotivoNombre_Sel = "";
         AV50TFMotivoNombre = "";
         AV54TFIncidenciaEstado_Sels = new GxSimpleCollection<string>();
         AV52TFIncidenciaEstado_SelsJson = "";
         AV55TFIncidenciaEstado_Sel = "";
         AV53TFIncidenciaEstado_SelDscs = "";
         AV66FilterTFIncidenciaEstado_SelValueDescription = "";
         AV57TFIncidenciaUsrAlta_Sel = "";
         AV56TFIncidenciaUsrAlta = "";
         AV58TFIncidenciaFechaAlta = DateTime.MinValue;
         AV59TFIncidenciaFechaAlta_To = DateTime.MinValue;
         AV67TFIncidenciaFechaAlta_To_Description = "";
         AV61TFIncidenciaUsrActualizacion_Sel = "";
         AV60TFIncidenciaUsrActualizacion = "";
         AV62TFIncidenciaFechaActualizacion = DateTime.MinValue;
         AV63TFIncidenciaFechaActualizacion_To = DateTime.MinValue;
         AV68TFIncidenciaFechaActualizacion_To_Description = "";
         AV89Incidenciawwds_1_filterfulltext = "";
         AV90Incidenciawwds_2_dynamicfiltersselector1 = "";
         AV92Incidenciawwds_4_incidenciaorigen1 = "";
         AV93Incidenciawwds_5_motivonombre1 = "";
         AV95Incidenciawwds_7_dynamicfiltersselector2 = "";
         AV97Incidenciawwds_9_incidenciaorigen2 = "";
         AV98Incidenciawwds_10_motivonombre2 = "";
         AV100Incidenciawwds_12_dynamicfiltersselector3 = "";
         AV102Incidenciawwds_14_incidenciaorigen3 = "";
         AV103Incidenciawwds_15_motivonombre3 = "";
         AV106Incidenciawwds_18_tfincidenciaorigen_sels = new GxSimpleCollection<string>();
         AV107Incidenciawwds_19_tfincidenciacodref = "";
         AV108Incidenciawwds_20_tfincidenciacodref_sel = "";
         AV109Incidenciawwds_21_tfmotivonombre = "";
         AV110Incidenciawwds_22_tfmotivonombre_sel = "";
         AV111Incidenciawwds_23_tfincidenciaestado_sels = new GxSimpleCollection<string>();
         AV112Incidenciawwds_24_tfincidenciausralta = "";
         AV113Incidenciawwds_25_tfincidenciausralta_sel = "";
         AV114Incidenciawwds_26_tfincidenciafechaalta = DateTime.MinValue;
         AV115Incidenciawwds_27_tfincidenciafechaalta_to = DateTime.MinValue;
         AV116Incidenciawwds_28_tfincidenciausractualizacion = "";
         AV117Incidenciawwds_29_tfincidenciausractualizacion_sel = "";
         AV118Incidenciawwds_30_tfincidenciafechaactualizacion = DateTime.MinValue;
         AV119Incidenciawwds_31_tfincidenciafechaactualizacion_to = DateTime.MinValue;
         lV89Incidenciawwds_1_filterfulltext = "";
         lV93Incidenciawwds_5_motivonombre1 = "";
         lV98Incidenciawwds_10_motivonombre2 = "";
         lV103Incidenciawwds_15_motivonombre3 = "";
         lV107Incidenciawwds_19_tfincidenciacodref = "";
         lV109Incidenciawwds_21_tfmotivonombre = "";
         lV112Incidenciawwds_24_tfincidenciausralta = "";
         lV116Incidenciawwds_28_tfincidenciausractualizacion = "";
         A611IncidenciaOrigen = "";
         A608IncidenciaEstado = "";
         A616MotivoNombre = "";
         A606IncidenciaCodRef = "";
         A615IncidenciaUsrAlta = "";
         A610IncidenciaFechaAlta = DateTime.MinValue;
         A614IncidenciaUsrActualizacion = "";
         A609IncidenciaFechaActualizacion = DateTime.MinValue;
         P00B32_A604MotivoId = new long[1] ;
         P00B32_A609IncidenciaFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         P00B32_A614IncidenciaUsrActualizacion = new string[] {""} ;
         P00B32_A610IncidenciaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00B32_A615IncidenciaUsrAlta = new string[] {""} ;
         P00B32_A616MotivoNombre = new string[] {""} ;
         P00B32_A606IncidenciaCodRef = new string[] {""} ;
         P00B32_A603IncidenciaId = new long[1] ;
         P00B32_A608IncidenciaEstado = new string[] {""} ;
         P00B32_A611IncidenciaOrigen = new string[] {""} ;
         AV36IncidenciaOrigenDescription = "";
         AV37IncidenciaEstadoDescription = "";
         AV38Session = context.GetSession();
         AV41GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV79PageInfo = "";
         AV76DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV74AppName = "";
         AV80Phone = "";
         AV78Mail = "";
         AV82Website = "";
         AV71AddressLine1 = "";
         AV72AddressLine2 = "";
         AV73AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.incidenciawwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00B32_A604MotivoId, P00B32_A609IncidenciaFechaActualizacion, P00B32_A614IncidenciaUsrActualizacion, P00B32_A610IncidenciaFechaAlta, P00B32_A615IncidenciaUsrAlta, P00B32_A616MotivoNombre, P00B32_A606IncidenciaCodRef, P00B32_A603IncidenciaId, P00B32_A608IncidenciaEstado, P00B32_A611IncidenciaOrigen
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV83Pgmname = "IncidenciaWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV83Pgmname = "IncidenciaWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV15DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV31DynamicFiltersOperator3 ;
      private short AV91Incidenciawwds_3_dynamicfiltersoperator1 ;
      private short AV96Incidenciawwds_8_dynamicfiltersoperator2 ;
      private short AV101Incidenciawwds_13_dynamicfiltersoperator3 ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV86GXV1 ;
      private int AV87GXV2 ;
      private int AV106Incidenciawwds_18_tfincidenciaorigen_sels_Count ;
      private int AV111Incidenciawwds_23_tfincidenciaestado_sels_Count ;
      private int AV120GXV3 ;
      private long AV42TFIncidenciaId ;
      private long AV43TFIncidenciaId_To ;
      private long AV70i ;
      private long AV104Incidenciawwds_16_tfincidenciaid ;
      private long AV105Incidenciawwds_17_tfincidenciaid_to ;
      private long A603IncidenciaId ;
      private long A604MotivoId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV83Pgmname ;
      private string GXEncryptionTmp ;
      private string AV16IncidenciaOrigen1 ;
      private string AV20MotivoNombre1 ;
      private string AV22MotivoNombre ;
      private string AV26IncidenciaOrigen2 ;
      private string AV28MotivoNombre2 ;
      private string AV32IncidenciaOrigen3 ;
      private string AV34MotivoNombre3 ;
      private string AV47TFIncidenciaOrigen_Sel ;
      private string AV51TFMotivoNombre_Sel ;
      private string AV50TFMotivoNombre ;
      private string AV55TFIncidenciaEstado_Sel ;
      private string AV57TFIncidenciaUsrAlta_Sel ;
      private string AV56TFIncidenciaUsrAlta ;
      private string AV61TFIncidenciaUsrActualizacion_Sel ;
      private string AV60TFIncidenciaUsrActualizacion ;
      private string AV92Incidenciawwds_4_incidenciaorigen1 ;
      private string AV93Incidenciawwds_5_motivonombre1 ;
      private string AV97Incidenciawwds_9_incidenciaorigen2 ;
      private string AV98Incidenciawwds_10_motivonombre2 ;
      private string AV102Incidenciawwds_14_incidenciaorigen3 ;
      private string AV103Incidenciawwds_15_motivonombre3 ;
      private string AV109Incidenciawwds_21_tfmotivonombre ;
      private string AV110Incidenciawwds_22_tfmotivonombre_sel ;
      private string AV112Incidenciawwds_24_tfincidenciausralta ;
      private string AV113Incidenciawwds_25_tfincidenciausralta_sel ;
      private string AV116Incidenciawwds_28_tfincidenciausractualizacion ;
      private string AV117Incidenciawwds_29_tfincidenciausractualizacion_sel ;
      private string lV93Incidenciawwds_5_motivonombre1 ;
      private string lV98Incidenciawwds_10_motivonombre2 ;
      private string lV103Incidenciawwds_15_motivonombre3 ;
      private string lV109Incidenciawwds_21_tfmotivonombre ;
      private string lV112Incidenciawwds_24_tfincidenciausralta ;
      private string lV116Incidenciawwds_28_tfincidenciausractualizacion ;
      private string A611IncidenciaOrigen ;
      private string A608IncidenciaEstado ;
      private string A616MotivoNombre ;
      private string A615IncidenciaUsrAlta ;
      private string A614IncidenciaUsrActualizacion ;
      private DateTime AV58TFIncidenciaFechaAlta ;
      private DateTime AV59TFIncidenciaFechaAlta_To ;
      private DateTime AV62TFIncidenciaFechaActualizacion ;
      private DateTime AV63TFIncidenciaFechaActualizacion_To ;
      private DateTime AV114Incidenciawwds_26_tfincidenciafechaalta ;
      private DateTime AV115Incidenciawwds_27_tfincidenciafechaalta_to ;
      private DateTime AV118Incidenciawwds_30_tfincidenciafechaactualizacion ;
      private DateTime AV119Incidenciawwds_31_tfincidenciafechaactualizacion_to ;
      private DateTime A610IncidenciaFechaAlta ;
      private DateTime A609IncidenciaFechaActualizacion ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV29DynamicFiltersEnabled3 ;
      private bool AV69TempBoolean ;
      private bool AV94Incidenciawwds_6_dynamicfiltersenabled2 ;
      private bool AV99Incidenciawwds_11_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private string AV44TFIncidenciaOrigen_SelsJson ;
      private string AV52TFIncidenciaEstado_SelsJson ;
      private string AV81Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV19FilterIncidenciaOrigen1ValueDescription ;
      private string AV18FilterIncidenciaOrigenValueDescription ;
      private string AV21FilterMotivoNombreDescription ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV27FilterIncidenciaOrigen2ValueDescription ;
      private string AV30DynamicFiltersSelector3 ;
      private string AV33FilterIncidenciaOrigen3ValueDescription ;
      private string AV64TFIncidenciaId_To_Description ;
      private string AV45TFIncidenciaOrigen_SelDscs ;
      private string AV65FilterTFIncidenciaOrigen_SelValueDescription ;
      private string AV49TFIncidenciaCodRef_Sel ;
      private string AV48TFIncidenciaCodRef ;
      private string AV53TFIncidenciaEstado_SelDscs ;
      private string AV66FilterTFIncidenciaEstado_SelValueDescription ;
      private string AV67TFIncidenciaFechaAlta_To_Description ;
      private string AV68TFIncidenciaFechaActualizacion_To_Description ;
      private string AV89Incidenciawwds_1_filterfulltext ;
      private string AV90Incidenciawwds_2_dynamicfiltersselector1 ;
      private string AV95Incidenciawwds_7_dynamicfiltersselector2 ;
      private string AV100Incidenciawwds_12_dynamicfiltersselector3 ;
      private string AV107Incidenciawwds_19_tfincidenciacodref ;
      private string AV108Incidenciawwds_20_tfincidenciacodref_sel ;
      private string lV89Incidenciawwds_1_filterfulltext ;
      private string lV107Incidenciawwds_19_tfincidenciacodref ;
      private string A606IncidenciaCodRef ;
      private string AV36IncidenciaOrigenDescription ;
      private string AV37IncidenciaEstadoDescription ;
      private string AV79PageInfo ;
      private string AV76DateInfo ;
      private string AV74AppName ;
      private string AV80Phone ;
      private string AV78Mail ;
      private string AV82Website ;
      private string AV71AddressLine1 ;
      private string AV72AddressLine2 ;
      private string AV73AddressLine3 ;
      private IGxSession AV38Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV40GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV35GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV46TFIncidenciaOrigen_Sels ;
      private GxSimpleCollection<string> AV54TFIncidenciaEstado_Sels ;
      private GxSimpleCollection<string> AV106Incidenciawwds_18_tfincidenciaorigen_sels ;
      private GxSimpleCollection<string> AV111Incidenciawwds_23_tfincidenciaestado_sels ;
      private IDataStoreProvider pr_default ;
      private long[] P00B32_A604MotivoId ;
      private DateTime[] P00B32_A609IncidenciaFechaActualizacion ;
      private string[] P00B32_A614IncidenciaUsrActualizacion ;
      private DateTime[] P00B32_A610IncidenciaFechaAlta ;
      private string[] P00B32_A615IncidenciaUsrAlta ;
      private string[] P00B32_A616MotivoNombre ;
      private string[] P00B32_A606IncidenciaCodRef ;
      private long[] P00B32_A603IncidenciaId ;
      private string[] P00B32_A608IncidenciaEstado ;
      private string[] P00B32_A611IncidenciaOrigen ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV41GridStateFilterValue ;
   }

   public class incidenciawwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00B32( IGxContext context ,
                                             string A611IncidenciaOrigen ,
                                             GxSimpleCollection<string> AV106Incidenciawwds_18_tfincidenciaorigen_sels ,
                                             string A608IncidenciaEstado ,
                                             GxSimpleCollection<string> AV111Incidenciawwds_23_tfincidenciaestado_sels ,
                                             string AV90Incidenciawwds_2_dynamicfiltersselector1 ,
                                             string AV92Incidenciawwds_4_incidenciaorigen1 ,
                                             short AV91Incidenciawwds_3_dynamicfiltersoperator1 ,
                                             string AV93Incidenciawwds_5_motivonombre1 ,
                                             bool AV94Incidenciawwds_6_dynamicfiltersenabled2 ,
                                             string AV95Incidenciawwds_7_dynamicfiltersselector2 ,
                                             string AV97Incidenciawwds_9_incidenciaorigen2 ,
                                             short AV96Incidenciawwds_8_dynamicfiltersoperator2 ,
                                             string AV98Incidenciawwds_10_motivonombre2 ,
                                             bool AV99Incidenciawwds_11_dynamicfiltersenabled3 ,
                                             string AV100Incidenciawwds_12_dynamicfiltersselector3 ,
                                             string AV102Incidenciawwds_14_incidenciaorigen3 ,
                                             short AV101Incidenciawwds_13_dynamicfiltersoperator3 ,
                                             string AV103Incidenciawwds_15_motivonombre3 ,
                                             long AV104Incidenciawwds_16_tfincidenciaid ,
                                             long AV105Incidenciawwds_17_tfincidenciaid_to ,
                                             int AV106Incidenciawwds_18_tfincidenciaorigen_sels_Count ,
                                             string AV108Incidenciawwds_20_tfincidenciacodref_sel ,
                                             string AV107Incidenciawwds_19_tfincidenciacodref ,
                                             string AV110Incidenciawwds_22_tfmotivonombre_sel ,
                                             string AV109Incidenciawwds_21_tfmotivonombre ,
                                             int AV111Incidenciawwds_23_tfincidenciaestado_sels_Count ,
                                             string AV113Incidenciawwds_25_tfincidenciausralta_sel ,
                                             string AV112Incidenciawwds_24_tfincidenciausralta ,
                                             DateTime AV114Incidenciawwds_26_tfincidenciafechaalta ,
                                             DateTime AV115Incidenciawwds_27_tfincidenciafechaalta_to ,
                                             string AV117Incidenciawwds_29_tfincidenciausractualizacion_sel ,
                                             string AV116Incidenciawwds_28_tfincidenciausractualizacion ,
                                             DateTime AV118Incidenciawwds_30_tfincidenciafechaactualizacion ,
                                             DateTime AV119Incidenciawwds_31_tfincidenciafechaactualizacion_to ,
                                             string A616MotivoNombre ,
                                             long A603IncidenciaId ,
                                             string A606IncidenciaCodRef ,
                                             string A615IncidenciaUsrAlta ,
                                             DateTime A610IncidenciaFechaAlta ,
                                             string A614IncidenciaUsrActualizacion ,
                                             DateTime A609IncidenciaFechaActualizacion ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             string AV89Incidenciawwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[23];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[MotivoId], T1.[IncidenciaFechaActualizacion], T1.[IncidenciaUsrActualizacion], T1.[IncidenciaFechaAlta], T1.[IncidenciaUsrAlta], T2.[MotivoNombre], T1.[IncidenciaCodRef], T1.[IncidenciaId], T1.[IncidenciaEstado], T1.[IncidenciaOrigen] FROM ([Incidencia] T1 INNER JOIN [Motivo] T2 ON T2.[MotivoId] = T1.[MotivoId])";
         if ( ( StringUtil.StrCmp(AV90Incidenciawwds_2_dynamicfiltersselector1, "INCIDENCIAORIGEN") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Incidenciawwds_4_incidenciaorigen1)) ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaOrigen] = @AV92Incidenciawwds_4_incidenciaorigen1)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Incidenciawwds_2_dynamicfiltersselector1, "MOTIVONOMBRE") == 0 ) && ( AV91Incidenciawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Incidenciawwds_5_motivonombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like UPPER(@lV93Incidenciawwds_5_motivonombre1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV90Incidenciawwds_2_dynamicfiltersselector1, "MOTIVONOMBRE") == 0 ) && ( AV91Incidenciawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Incidenciawwds_5_motivonombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like '%' + UPPER(@lV93Incidenciawwds_5_motivonombre1))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV94Incidenciawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Incidenciawwds_7_dynamicfiltersselector2, "INCIDENCIAORIGEN") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Incidenciawwds_9_incidenciaorigen2)) ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaOrigen] = @AV97Incidenciawwds_9_incidenciaorigen2)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV94Incidenciawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Incidenciawwds_7_dynamicfiltersselector2, "MOTIVONOMBRE") == 0 ) && ( AV96Incidenciawwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Incidenciawwds_10_motivonombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like UPPER(@lV98Incidenciawwds_10_motivonombre2))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV94Incidenciawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV95Incidenciawwds_7_dynamicfiltersselector2, "MOTIVONOMBRE") == 0 ) && ( AV96Incidenciawwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Incidenciawwds_10_motivonombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like '%' + UPPER(@lV98Incidenciawwds_10_motivonombre2))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV99Incidenciawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV100Incidenciawwds_12_dynamicfiltersselector3, "INCIDENCIAORIGEN") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Incidenciawwds_14_incidenciaorigen3)) ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaOrigen] = @AV102Incidenciawwds_14_incidenciaorigen3)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV99Incidenciawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV100Incidenciawwds_12_dynamicfiltersselector3, "MOTIVONOMBRE") == 0 ) && ( AV101Incidenciawwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Incidenciawwds_15_motivonombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like UPPER(@lV103Incidenciawwds_15_motivonombre3))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( AV99Incidenciawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV100Incidenciawwds_12_dynamicfiltersselector3, "MOTIVONOMBRE") == 0 ) && ( AV101Incidenciawwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Incidenciawwds_15_motivonombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like '%' + UPPER(@lV103Incidenciawwds_15_motivonombre3))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! (0==AV104Incidenciawwds_16_tfincidenciaid) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaId] >= @AV104Incidenciawwds_16_tfincidenciaid)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! (0==AV105Incidenciawwds_17_tfincidenciaid_to) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaId] <= @AV105Incidenciawwds_17_tfincidenciaid_to)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( AV106Incidenciawwds_18_tfincidenciaorigen_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV106Incidenciawwds_18_tfincidenciaorigen_sels, "T1.[IncidenciaOrigen] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Incidenciawwds_20_tfincidenciacodref_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Incidenciawwds_19_tfincidenciacodref)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[IncidenciaCodRef]) like UPPER(@lV107Incidenciawwds_19_tfincidenciacodref))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Incidenciawwds_20_tfincidenciacodref_sel)) && ! ( StringUtil.StrCmp(AV108Incidenciawwds_20_tfincidenciacodref_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaCodRef] = @AV108Incidenciawwds_20_tfincidenciacodref_sel)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( StringUtil.StrCmp(AV108Incidenciawwds_20_tfincidenciacodref_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[IncidenciaCodRef] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Incidenciawwds_22_tfmotivonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Incidenciawwds_21_tfmotivonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like UPPER(@lV109Incidenciawwds_21_tfmotivonombre))");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Incidenciawwds_22_tfmotivonombre_sel)) && ! ( StringUtil.StrCmp(AV110Incidenciawwds_22_tfmotivonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[MotivoNombre] = @AV110Incidenciawwds_22_tfmotivonombre_sel)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( StringUtil.StrCmp(AV110Incidenciawwds_22_tfmotivonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[MotivoNombre] = ''))");
         }
         if ( AV111Incidenciawwds_23_tfincidenciaestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV111Incidenciawwds_23_tfincidenciaestado_sels, "T1.[IncidenciaEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Incidenciawwds_25_tfincidenciausralta_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Incidenciawwds_24_tfincidenciausralta)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[IncidenciaUsrAlta]) like UPPER(@lV112Incidenciawwds_24_tfincidenciausralta))");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Incidenciawwds_25_tfincidenciausralta_sel)) && ! ( StringUtil.StrCmp(AV113Incidenciawwds_25_tfincidenciausralta_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaUsrAlta] = @AV113Incidenciawwds_25_tfincidenciausralta_sel)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( StringUtil.StrCmp(AV113Incidenciawwds_25_tfincidenciausralta_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[IncidenciaUsrAlta] = ''))");
         }
         if ( ! (DateTime.MinValue==AV114Incidenciawwds_26_tfincidenciafechaalta) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaFechaAlta] >= @AV114Incidenciawwds_26_tfincidenciafechaalta)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV115Incidenciawwds_27_tfincidenciafechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaFechaAlta] <= @AV115Incidenciawwds_27_tfincidenciafechaalta_to)");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV117Incidenciawwds_29_tfincidenciausractualizacion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Incidenciawwds_28_tfincidenciausractualizacion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[IncidenciaUsrActualizacion]) like UPPER(@lV116Incidenciawwds_28_tfincidenciausractualizacion))");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Incidenciawwds_29_tfincidenciausractualizacion_sel)) && ! ( StringUtil.StrCmp(AV117Incidenciawwds_29_tfincidenciausractualizacion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaUsrActualizacion] = @AV117Incidenciawwds_29_tfincidenciausractualizacion_sel)");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( StringUtil.StrCmp(AV117Incidenciawwds_29_tfincidenciausractualizacion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[IncidenciaUsrActualizacion] = ''))");
         }
         if ( ! (DateTime.MinValue==AV118Incidenciawwds_30_tfincidenciafechaactualizacion) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaFechaActualizacion] >= @AV118Incidenciawwds_30_tfincidenciafechaactualizacion)");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV119Incidenciawwds_31_tfincidenciafechaactualizacion_to) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaFechaActualizacion] <= @AV119Incidenciawwds_31_tfincidenciafechaactualizacion_to)");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaOrigen]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaOrigen] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaId]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaId] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaCodRef]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaCodRef] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[MotivoNombre]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[MotivoNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaEstado]";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaEstado] DESC";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaUsrAlta]";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaUsrAlta] DESC";
         }
         else if ( ( AV11OrderedBy == 7 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaFechaAlta]";
         }
         else if ( ( AV11OrderedBy == 7 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaFechaAlta] DESC";
         }
         else if ( ( AV11OrderedBy == 8 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaUsrActualizacion]";
         }
         else if ( ( AV11OrderedBy == 8 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaUsrActualizacion] DESC";
         }
         else if ( ( AV11OrderedBy == 9 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaFechaActualizacion]";
         }
         else if ( ( AV11OrderedBy == 9 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[IncidenciaFechaActualizacion] DESC";
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
                     return conditional_P00B32(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (long)dynConstraints[18] , (long)dynConstraints[19] , (int)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (DateTime)dynConstraints[32] , (DateTime)dynConstraints[33] , (string)dynConstraints[34] , (long)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (DateTime)dynConstraints[38] , (string)dynConstraints[39] , (DateTime)dynConstraints[40] , (short)dynConstraints[41] , (bool)dynConstraints[42] , (string)dynConstraints[43] );
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
          Object[] prmP00B32;
          prmP00B32 = new Object[] {
          new ParDef("@AV92Incidenciawwds_4_incidenciaorigen1",GXType.NChar,3,0) ,
          new ParDef("@lV93Incidenciawwds_5_motivonombre1",GXType.Char,80,0) ,
          new ParDef("@lV93Incidenciawwds_5_motivonombre1",GXType.Char,80,0) ,
          new ParDef("@AV97Incidenciawwds_9_incidenciaorigen2",GXType.NChar,3,0) ,
          new ParDef("@lV98Incidenciawwds_10_motivonombre2",GXType.Char,80,0) ,
          new ParDef("@lV98Incidenciawwds_10_motivonombre2",GXType.Char,80,0) ,
          new ParDef("@AV102Incidenciawwds_14_incidenciaorigen3",GXType.NChar,3,0) ,
          new ParDef("@lV103Incidenciawwds_15_motivonombre3",GXType.Char,80,0) ,
          new ParDef("@lV103Incidenciawwds_15_motivonombre3",GXType.Char,80,0) ,
          new ParDef("@AV104Incidenciawwds_16_tfincidenciaid",GXType.Decimal,18,0) ,
          new ParDef("@AV105Incidenciawwds_17_tfincidenciaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV107Incidenciawwds_19_tfincidenciacodref",GXType.VarChar,40,0) ,
          new ParDef("@AV108Incidenciawwds_20_tfincidenciacodref_sel",GXType.NVarChar,40,0) ,
          new ParDef("@lV109Incidenciawwds_21_tfmotivonombre",GXType.Char,80,0) ,
          new ParDef("@AV110Incidenciawwds_22_tfmotivonombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV112Incidenciawwds_24_tfincidenciausralta",GXType.Char,20,0) ,
          new ParDef("@AV113Incidenciawwds_25_tfincidenciausralta_sel",GXType.NChar,20,0) ,
          new ParDef("@AV114Incidenciawwds_26_tfincidenciafechaalta",GXType.Date,8,0) ,
          new ParDef("@AV115Incidenciawwds_27_tfincidenciafechaalta_to",GXType.Date,8,0) ,
          new ParDef("@lV116Incidenciawwds_28_tfincidenciausractualizacion",GXType.Char,20,0) ,
          new ParDef("@AV117Incidenciawwds_29_tfincidenciausractualizacion_sel",GXType.NChar,20,0) ,
          new ParDef("@AV118Incidenciawwds_30_tfincidenciafechaactualizacion",GXType.Date,8,0) ,
          new ParDef("@AV119Incidenciawwds_31_tfincidenciafechaactualizacion_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00B32", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B32,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 80);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 3);
                ((string[]) buf[9])[0] = rslt.getString(10, 3);
                return;
       }
    }

 }

}
