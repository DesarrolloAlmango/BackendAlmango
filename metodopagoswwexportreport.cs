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
   public class metodopagoswwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public metodopagoswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public metodopagoswwexportreport( IGxContext context )
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
         setOutputFileName("MetodoPagosWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMetodoPagos", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV57Pgmname));
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
               AV55Title = context.GetMessage( "Lista de Metodo Pagos", "");
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
            H4M0( true, 0) ;
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
            H4M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 149, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 149, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV32GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "METODOPAGOSNOMBRE") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV16MetodoPagosNombre1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16MetodoPagosNombre1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterMetodoPagosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Metodo", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterMetodoPagosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Metodo", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV18MetodoPagosNombre = AV16MetodoPagosNombre1;
                  H4M0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterMetodoPagosNombreDescription, "")), 25, Gx_line+0, 149, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18MetodoPagosNombre, "")), 149, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "ESTADOSGENERICOSNOMBRE") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV19EstadosGenericosNombre1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19EstadosGenericosNombre1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV20FilterEstadosGenericosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Estado", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV20FilterEstadosGenericosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Estado", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV21EstadosGenericosNombre = AV19EstadosGenericosNombre1;
                  H4M0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterEstadosGenericosNombreDescription, "")), 25, Gx_line+0, 149, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21EstadosGenericosNombre, "")), 149, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "METODOPAGOSNOMBRE") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV25MetodoPagosNombre2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25MetodoPagosNombre2)) )
                  {
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterMetodoPagosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Metodo", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterMetodoPagosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Metodo", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV18MetodoPagosNombre = AV25MetodoPagosNombre2;
                     H4M0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterMetodoPagosNombreDescription, "")), 25, Gx_line+0, 149, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18MetodoPagosNombre, "")), 149, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "ESTADOSGENERICOSNOMBRE") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV26EstadosGenericosNombre2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26EstadosGenericosNombre2)) )
                  {
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV20FilterEstadosGenericosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Estado", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV20FilterEstadosGenericosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Estado", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV21EstadosGenericosNombre = AV26EstadosGenericosNombre2;
                     H4M0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterEstadosGenericosNombreDescription, "")), 25, Gx_line+0, 149, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21EstadosGenericosNombre, "")), 149, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "METODOPAGOSNOMBRE") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV30MetodoPagosNombre3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30MetodoPagosNombre3)) )
                     {
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterMetodoPagosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Metodo", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterMetodoPagosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Metodo", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV18MetodoPagosNombre = AV30MetodoPagosNombre3;
                        H4M0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterMetodoPagosNombreDescription, "")), 25, Gx_line+0, 149, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18MetodoPagosNombre, "")), 149, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "ESTADOSGENERICOSNOMBRE") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV31EstadosGenericosNombre3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31EstadosGenericosNombre3)) )
                     {
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV20FilterEstadosGenericosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Estado", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV20FilterEstadosGenericosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Estado", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV21EstadosGenericosNombre = AV31EstadosGenericosNombre3;
                        H4M0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterEstadosGenericosNombreDescription, "")), 25, Gx_line+0, 149, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21EstadosGenericosNombre, "")), 149, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV37TFMetodoPagosID) && (0==AV38TFMetodoPagosID_To) ) )
         {
            H4M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Id", ""), 25, Gx_line+0, 149, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV37TFMetodoPagosID), "ZZZZZZZZZZZZZZZZZ9")), 149, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV43TFMetodoPagosID_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Id", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H4M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFMetodoPagosID_To_Description, "")), 25, Gx_line+0, 149, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV38TFMetodoPagosID_To), "ZZZZZZZZZZZZZZZZZ9")), 149, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFMetodoPagosNombre_Sel)) )
         {
            AV44TempBoolean = (bool)(((StringUtil.StrCmp(AV40TFMetodoPagosNombre_Sel, "<#Empty#>")==0)));
            AV40TFMetodoPagosNombre_Sel = (AV44TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV40TFMetodoPagosNombre_Sel);
            H4M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Metodo", ""), 25, Gx_line+0, 149, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFMetodoPagosNombre_Sel, "")), 149, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV40TFMetodoPagosNombre_Sel = (AV44TempBoolean ? "<#Empty#>" : AV40TFMetodoPagosNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFMetodoPagosNombre)) )
            {
               H4M0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Metodo", ""), 25, Gx_line+0, 149, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFMetodoPagosNombre, "")), 149, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TFMetodoPagosCodigo_Sel)) )
         {
            AV44TempBoolean = (bool)(((StringUtil.StrCmp(AV42TFMetodoPagosCodigo_Sel, "<#Empty#>")==0)));
            AV42TFMetodoPagosCodigo_Sel = (AV44TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV42TFMetodoPagosCodigo_Sel);
            H4M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Codigo", ""), 25, Gx_line+0, 149, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFMetodoPagosCodigo_Sel, "")), 149, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV42TFMetodoPagosCodigo_Sel = (AV44TempBoolean ? "<#Empty#>" : AV42TFMetodoPagosCodigo_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41TFMetodoPagosCodigo)) )
            {
               H4M0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Codigo", ""), 25, Gx_line+0, 149, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFMetodoPagosCodigo, "")), 149, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H4M0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H4M0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Id", ""), 30, Gx_line+10, 154, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Metodo", ""), 158, Gx_line+10, 406, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Logo", ""), 410, Gx_line+10, 534, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Codigo", ""), 538, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV61Metodopagoswwds_1_filterfulltext = AV13FilterFullText;
         AV62Metodopagoswwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV63Metodopagoswwds_3_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV64Metodopagoswwds_4_metodopagosnombre1 = AV16MetodoPagosNombre1;
         AV65Metodopagoswwds_5_estadosgenericosnombre1 = AV19EstadosGenericosNombre1;
         AV66Metodopagoswwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV67Metodopagoswwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV68Metodopagoswwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV69Metodopagoswwds_9_metodopagosnombre2 = AV25MetodoPagosNombre2;
         AV70Metodopagoswwds_10_estadosgenericosnombre2 = AV26EstadosGenericosNombre2;
         AV71Metodopagoswwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV72Metodopagoswwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV73Metodopagoswwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV74Metodopagoswwds_14_metodopagosnombre3 = AV30MetodoPagosNombre3;
         AV75Metodopagoswwds_15_estadosgenericosnombre3 = AV31EstadosGenericosNombre3;
         AV76Metodopagoswwds_16_tfmetodopagosid = AV37TFMetodoPagosID;
         AV77Metodopagoswwds_17_tfmetodopagosid_to = AV38TFMetodoPagosID_To;
         AV78Metodopagoswwds_18_tfmetodopagosnombre = AV39TFMetodoPagosNombre;
         AV79Metodopagoswwds_19_tfmetodopagosnombre_sel = AV40TFMetodoPagosNombre_Sel;
         AV80Metodopagoswwds_20_tfmetodopagoscodigo = AV41TFMetodoPagosCodigo;
         AV81Metodopagoswwds_21_tfmetodopagoscodigo_sel = AV42TFMetodoPagosCodigo_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV61Metodopagoswwds_1_filterfulltext ,
                                              AV62Metodopagoswwds_2_dynamicfiltersselector1 ,
                                              AV63Metodopagoswwds_3_dynamicfiltersoperator1 ,
                                              AV64Metodopagoswwds_4_metodopagosnombre1 ,
                                              AV65Metodopagoswwds_5_estadosgenericosnombre1 ,
                                              AV66Metodopagoswwds_6_dynamicfiltersenabled2 ,
                                              AV67Metodopagoswwds_7_dynamicfiltersselector2 ,
                                              AV68Metodopagoswwds_8_dynamicfiltersoperator2 ,
                                              AV69Metodopagoswwds_9_metodopagosnombre2 ,
                                              AV70Metodopagoswwds_10_estadosgenericosnombre2 ,
                                              AV71Metodopagoswwds_11_dynamicfiltersenabled3 ,
                                              AV72Metodopagoswwds_12_dynamicfiltersselector3 ,
                                              AV73Metodopagoswwds_13_dynamicfiltersoperator3 ,
                                              AV74Metodopagoswwds_14_metodopagosnombre3 ,
                                              AV75Metodopagoswwds_15_estadosgenericosnombre3 ,
                                              AV76Metodopagoswwds_16_tfmetodopagosid ,
                                              AV77Metodopagoswwds_17_tfmetodopagosid_to ,
                                              AV79Metodopagoswwds_19_tfmetodopagosnombre_sel ,
                                              AV78Metodopagoswwds_18_tfmetodopagosnombre ,
                                              AV81Metodopagoswwds_21_tfmetodopagoscodigo_sel ,
                                              AV80Metodopagoswwds_20_tfmetodopagoscodigo ,
                                              A128MetodoPagosID ,
                                              A129MetodoPagosNombre ,
                                              A214MetodoPagosCodigo ,
                                              A109EstadosGenericosNombre ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV61Metodopagoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Metodopagoswwds_1_filterfulltext), "%", "");
         lV61Metodopagoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Metodopagoswwds_1_filterfulltext), "%", "");
         lV61Metodopagoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Metodopagoswwds_1_filterfulltext), "%", "");
         lV64Metodopagoswwds_4_metodopagosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV64Metodopagoswwds_4_metodopagosnombre1), 80, "%");
         lV64Metodopagoswwds_4_metodopagosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV64Metodopagoswwds_4_metodopagosnombre1), 80, "%");
         lV65Metodopagoswwds_5_estadosgenericosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV65Metodopagoswwds_5_estadosgenericosnombre1), 80, "%");
         lV65Metodopagoswwds_5_estadosgenericosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV65Metodopagoswwds_5_estadosgenericosnombre1), 80, "%");
         lV69Metodopagoswwds_9_metodopagosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV69Metodopagoswwds_9_metodopagosnombre2), 80, "%");
         lV69Metodopagoswwds_9_metodopagosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV69Metodopagoswwds_9_metodopagosnombre2), 80, "%");
         lV70Metodopagoswwds_10_estadosgenericosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV70Metodopagoswwds_10_estadosgenericosnombre2), 80, "%");
         lV70Metodopagoswwds_10_estadosgenericosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV70Metodopagoswwds_10_estadosgenericosnombre2), 80, "%");
         lV74Metodopagoswwds_14_metodopagosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV74Metodopagoswwds_14_metodopagosnombre3), 80, "%");
         lV74Metodopagoswwds_14_metodopagosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV74Metodopagoswwds_14_metodopagosnombre3), 80, "%");
         lV75Metodopagoswwds_15_estadosgenericosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV75Metodopagoswwds_15_estadosgenericosnombre3), 80, "%");
         lV75Metodopagoswwds_15_estadosgenericosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV75Metodopagoswwds_15_estadosgenericosnombre3), 80, "%");
         lV78Metodopagoswwds_18_tfmetodopagosnombre = StringUtil.PadR( StringUtil.RTrim( AV78Metodopagoswwds_18_tfmetodopagosnombre), 80, "%");
         lV80Metodopagoswwds_20_tfmetodopagoscodigo = StringUtil.Concat( StringUtil.RTrim( AV80Metodopagoswwds_20_tfmetodopagoscodigo), "%", "");
         /* Using cursor P004M2 */
         pr_default.execute(0, new Object[] {lV61Metodopagoswwds_1_filterfulltext, lV61Metodopagoswwds_1_filterfulltext, lV61Metodopagoswwds_1_filterfulltext, lV64Metodopagoswwds_4_metodopagosnombre1, lV64Metodopagoswwds_4_metodopagosnombre1, lV65Metodopagoswwds_5_estadosgenericosnombre1, lV65Metodopagoswwds_5_estadosgenericosnombre1, lV69Metodopagoswwds_9_metodopagosnombre2, lV69Metodopagoswwds_9_metodopagosnombre2, lV70Metodopagoswwds_10_estadosgenericosnombre2, lV70Metodopagoswwds_10_estadosgenericosnombre2, lV74Metodopagoswwds_14_metodopagosnombre3, lV74Metodopagoswwds_14_metodopagosnombre3, lV75Metodopagoswwds_15_estadosgenericosnombre3, lV75Metodopagoswwds_15_estadosgenericosnombre3, AV76Metodopagoswwds_16_tfmetodopagosid, AV77Metodopagoswwds_17_tfmetodopagosid_to, lV78Metodopagoswwds_18_tfmetodopagosnombre, AV79Metodopagoswwds_19_tfmetodopagosnombre_sel, lV80Metodopagoswwds_20_tfmetodopagoscodigo, AV81Metodopagoswwds_21_tfmetodopagoscodigo_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A107EstadosTipo = P004M2_A107EstadosTipo[0];
            A108EstadosGenericosId = P004M2_A108EstadosGenericosId[0];
            A109EstadosGenericosNombre = P004M2_A109EstadosGenericosNombre[0];
            A214MetodoPagosCodigo = P004M2_A214MetodoPagosCodigo[0];
            A129MetodoPagosNombre = P004M2_A129MetodoPagosNombre[0];
            A128MetodoPagosID = P004M2_A128MetodoPagosID[0];
            A40000MetodoPagosLogo_GXI = P004M2_A40000MetodoPagosLogo_GXI[0];
            A213MetodoPagosLogo = P004M2_A213MetodoPagosLogo[0];
            A109EstadosGenericosNombre = P004M2_A109EstadosGenericosNombre[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H4M0( false, 66) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A128MetodoPagosID), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 154, Gx_line+55, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A129MetodoPagosNombre, "")), 158, Gx_line+10, 406, Gx_line+55, 0+16, 0, 0, 0) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A213MetodoPagosLogo)) ? A40000MetodoPagosLogo_GXI : A213MetodoPagosLogo);
            getPrinter().GxDrawBitMap(sImgUrl, 410, Gx_line+10, 534, Gx_line+55) ;
            getPrinter().GxDrawText(A214MetodoPagosCodigo, 538, Gx_line+10, 787, Gx_line+55, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawLine(28, Gx_line+65, 789, Gx_line+65, 1, 220, 220, 220, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+66);
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
         if ( StringUtil.StrCmp(AV33Session.Get("MetodoPagosWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "MetodoPagosWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("MetodoPagosWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV35GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV35GridState.gxTpr_Ordereddsc;
         AV82GXV1 = 1;
         while ( AV82GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV82GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMETODOPAGOSID") == 0 )
            {
               AV37TFMetodoPagosID = (long)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV38TFMetodoPagosID_To = (long)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMETODOPAGOSNOMBRE") == 0 )
            {
               AV39TFMetodoPagosNombre = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMETODOPAGOSNOMBRE_SEL") == 0 )
            {
               AV40TFMetodoPagosNombre_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMETODOPAGOSCODIGO") == 0 )
            {
               AV41TFMetodoPagosCodigo = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMETODOPAGOSCODIGO_SEL") == 0 )
            {
               AV42TFMetodoPagosCodigo_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            AV82GXV1 = (int)(AV82GXV1+1);
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

      protected void H4M0( bool bFoot ,
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
                  AV53PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV50DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV48AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV54Phone = "+1 550 8923";
               AV52Mail = "info@mail.com";
               AV56Website = "http://www.web.com";
               AV45AddressLine1 = "French Boulevard 2859";
               AV46AddressLine2 = "Downtown";
               AV47AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV57Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV55Title = "";
         AV13FilterFullText = "";
         AV35GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV32GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV16MetodoPagosNombre1 = "";
         AV17FilterMetodoPagosNombreDescription = "";
         AV18MetodoPagosNombre = "";
         AV19EstadosGenericosNombre1 = "";
         AV20FilterEstadosGenericosNombreDescription = "";
         AV21EstadosGenericosNombre = "";
         AV23DynamicFiltersSelector2 = "";
         AV25MetodoPagosNombre2 = "";
         AV26EstadosGenericosNombre2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30MetodoPagosNombre3 = "";
         AV31EstadosGenericosNombre3 = "";
         AV43TFMetodoPagosID_To_Description = "";
         AV40TFMetodoPagosNombre_Sel = "";
         AV39TFMetodoPagosNombre = "";
         AV42TFMetodoPagosCodigo_Sel = "";
         AV41TFMetodoPagosCodigo = "";
         AV61Metodopagoswwds_1_filterfulltext = "";
         AV62Metodopagoswwds_2_dynamicfiltersselector1 = "";
         AV64Metodopagoswwds_4_metodopagosnombre1 = "";
         AV65Metodopagoswwds_5_estadosgenericosnombre1 = "";
         AV67Metodopagoswwds_7_dynamicfiltersselector2 = "";
         AV69Metodopagoswwds_9_metodopagosnombre2 = "";
         AV70Metodopagoswwds_10_estadosgenericosnombre2 = "";
         AV72Metodopagoswwds_12_dynamicfiltersselector3 = "";
         AV74Metodopagoswwds_14_metodopagosnombre3 = "";
         AV75Metodopagoswwds_15_estadosgenericosnombre3 = "";
         AV78Metodopagoswwds_18_tfmetodopagosnombre = "";
         AV79Metodopagoswwds_19_tfmetodopagosnombre_sel = "";
         AV80Metodopagoswwds_20_tfmetodopagoscodigo = "";
         AV81Metodopagoswwds_21_tfmetodopagoscodigo_sel = "";
         lV61Metodopagoswwds_1_filterfulltext = "";
         lV64Metodopagoswwds_4_metodopagosnombre1 = "";
         lV65Metodopagoswwds_5_estadosgenericosnombre1 = "";
         lV69Metodopagoswwds_9_metodopagosnombre2 = "";
         lV70Metodopagoswwds_10_estadosgenericosnombre2 = "";
         lV74Metodopagoswwds_14_metodopagosnombre3 = "";
         lV75Metodopagoswwds_15_estadosgenericosnombre3 = "";
         lV78Metodopagoswwds_18_tfmetodopagosnombre = "";
         lV80Metodopagoswwds_20_tfmetodopagoscodigo = "";
         A129MetodoPagosNombre = "";
         A214MetodoPagosCodigo = "";
         A109EstadosGenericosNombre = "";
         P004M2_A107EstadosTipo = new string[] {""} ;
         P004M2_A108EstadosGenericosId = new int[1] ;
         P004M2_A109EstadosGenericosNombre = new string[] {""} ;
         P004M2_A214MetodoPagosCodigo = new string[] {""} ;
         P004M2_A129MetodoPagosNombre = new string[] {""} ;
         P004M2_A128MetodoPagosID = new long[1] ;
         P004M2_A40000MetodoPagosLogo_GXI = new string[] {""} ;
         P004M2_A213MetodoPagosLogo = new string[] {""} ;
         A107EstadosTipo = "";
         A40000MetodoPagosLogo_GXI = "";
         A213MetodoPagosLogo = "";
         sImgUrl = "";
         AV33Session = context.GetSession();
         AV36GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV53PageInfo = "";
         AV50DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV48AppName = "";
         AV54Phone = "";
         AV52Mail = "";
         AV56Website = "";
         AV45AddressLine1 = "";
         AV46AddressLine2 = "";
         AV47AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.metodopagoswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P004M2_A107EstadosTipo, P004M2_A108EstadosGenericosId, P004M2_A109EstadosGenericosNombre, P004M2_A214MetodoPagosCodigo, P004M2_A129MetodoPagosNombre, P004M2_A128MetodoPagosID, P004M2_A40000MetodoPagosLogo_GXI, P004M2_A213MetodoPagosLogo
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV57Pgmname = "MetodoPagosWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV57Pgmname = "MetodoPagosWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV15DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short AV63Metodopagoswwds_3_dynamicfiltersoperator1 ;
      private short AV68Metodopagoswwds_8_dynamicfiltersoperator2 ;
      private short AV73Metodopagoswwds_13_dynamicfiltersoperator3 ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A108EstadosGenericosId ;
      private int AV82GXV1 ;
      private long AV37TFMetodoPagosID ;
      private long AV38TFMetodoPagosID_To ;
      private long AV76Metodopagoswwds_16_tfmetodopagosid ;
      private long AV77Metodopagoswwds_17_tfmetodopagosid_to ;
      private long A128MetodoPagosID ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV57Pgmname ;
      private string GXEncryptionTmp ;
      private string AV16MetodoPagosNombre1 ;
      private string AV18MetodoPagosNombre ;
      private string AV19EstadosGenericosNombre1 ;
      private string AV21EstadosGenericosNombre ;
      private string AV25MetodoPagosNombre2 ;
      private string AV26EstadosGenericosNombre2 ;
      private string AV30MetodoPagosNombre3 ;
      private string AV31EstadosGenericosNombre3 ;
      private string AV40TFMetodoPagosNombre_Sel ;
      private string AV39TFMetodoPagosNombre ;
      private string AV64Metodopagoswwds_4_metodopagosnombre1 ;
      private string AV65Metodopagoswwds_5_estadosgenericosnombre1 ;
      private string AV69Metodopagoswwds_9_metodopagosnombre2 ;
      private string AV70Metodopagoswwds_10_estadosgenericosnombre2 ;
      private string AV74Metodopagoswwds_14_metodopagosnombre3 ;
      private string AV75Metodopagoswwds_15_estadosgenericosnombre3 ;
      private string AV78Metodopagoswwds_18_tfmetodopagosnombre ;
      private string AV79Metodopagoswwds_19_tfmetodopagosnombre_sel ;
      private string lV64Metodopagoswwds_4_metodopagosnombre1 ;
      private string lV65Metodopagoswwds_5_estadosgenericosnombre1 ;
      private string lV69Metodopagoswwds_9_metodopagosnombre2 ;
      private string lV70Metodopagoswwds_10_estadosgenericosnombre2 ;
      private string lV74Metodopagoswwds_14_metodopagosnombre3 ;
      private string lV75Metodopagoswwds_15_estadosgenericosnombre3 ;
      private string lV78Metodopagoswwds_18_tfmetodopagosnombre ;
      private string A129MetodoPagosNombre ;
      private string A109EstadosGenericosNombre ;
      private string A107EstadosTipo ;
      private string sImgUrl ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV44TempBoolean ;
      private bool AV66Metodopagoswwds_6_dynamicfiltersenabled2 ;
      private bool AV71Metodopagoswwds_11_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private string A214MetodoPagosCodigo ;
      private string AV55Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV17FilterMetodoPagosNombreDescription ;
      private string AV20FilterEstadosGenericosNombreDescription ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV43TFMetodoPagosID_To_Description ;
      private string AV42TFMetodoPagosCodigo_Sel ;
      private string AV41TFMetodoPagosCodigo ;
      private string AV61Metodopagoswwds_1_filterfulltext ;
      private string AV62Metodopagoswwds_2_dynamicfiltersselector1 ;
      private string AV67Metodopagoswwds_7_dynamicfiltersselector2 ;
      private string AV72Metodopagoswwds_12_dynamicfiltersselector3 ;
      private string AV80Metodopagoswwds_20_tfmetodopagoscodigo ;
      private string AV81Metodopagoswwds_21_tfmetodopagoscodigo_sel ;
      private string lV61Metodopagoswwds_1_filterfulltext ;
      private string lV80Metodopagoswwds_20_tfmetodopagoscodigo ;
      private string A40000MetodoPagosLogo_GXI ;
      private string AV53PageInfo ;
      private string AV50DateInfo ;
      private string AV48AppName ;
      private string AV54Phone ;
      private string AV52Mail ;
      private string AV56Website ;
      private string AV45AddressLine1 ;
      private string AV46AddressLine2 ;
      private string AV47AddressLine3 ;
      private string A213MetodoPagosLogo ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV32GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private string[] P004M2_A107EstadosTipo ;
      private int[] P004M2_A108EstadosGenericosId ;
      private string[] P004M2_A109EstadosGenericosNombre ;
      private string[] P004M2_A214MetodoPagosCodigo ;
      private string[] P004M2_A129MetodoPagosNombre ;
      private long[] P004M2_A128MetodoPagosID ;
      private string[] P004M2_A40000MetodoPagosLogo_GXI ;
      private string[] P004M2_A213MetodoPagosLogo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
   }

   public class metodopagoswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004M2( IGxContext context ,
                                             string AV61Metodopagoswwds_1_filterfulltext ,
                                             string AV62Metodopagoswwds_2_dynamicfiltersselector1 ,
                                             short AV63Metodopagoswwds_3_dynamicfiltersoperator1 ,
                                             string AV64Metodopagoswwds_4_metodopagosnombre1 ,
                                             string AV65Metodopagoswwds_5_estadosgenericosnombre1 ,
                                             bool AV66Metodopagoswwds_6_dynamicfiltersenabled2 ,
                                             string AV67Metodopagoswwds_7_dynamicfiltersselector2 ,
                                             short AV68Metodopagoswwds_8_dynamicfiltersoperator2 ,
                                             string AV69Metodopagoswwds_9_metodopagosnombre2 ,
                                             string AV70Metodopagoswwds_10_estadosgenericosnombre2 ,
                                             bool AV71Metodopagoswwds_11_dynamicfiltersenabled3 ,
                                             string AV72Metodopagoswwds_12_dynamicfiltersselector3 ,
                                             short AV73Metodopagoswwds_13_dynamicfiltersoperator3 ,
                                             string AV74Metodopagoswwds_14_metodopagosnombre3 ,
                                             string AV75Metodopagoswwds_15_estadosgenericosnombre3 ,
                                             long AV76Metodopagoswwds_16_tfmetodopagosid ,
                                             long AV77Metodopagoswwds_17_tfmetodopagosid_to ,
                                             string AV79Metodopagoswwds_19_tfmetodopagosnombre_sel ,
                                             string AV78Metodopagoswwds_18_tfmetodopagosnombre ,
                                             string AV81Metodopagoswwds_21_tfmetodopagoscodigo_sel ,
                                             string AV80Metodopagoswwds_20_tfmetodopagoscodigo ,
                                             long A128MetodoPagosID ,
                                             string A129MetodoPagosNombre ,
                                             string A214MetodoPagosCodigo ,
                                             string A109EstadosGenericosNombre ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[21];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[EstadosTipo], T1.[EstadosGenericosId], T2.[EstadosGenericosNombre], T1.[MetodoPagosCodigo], T1.[MetodoPagosNombre], T1.[MetodoPagosID], T1.[MetodoPagosLogo_GXI], T1.[MetodoPagosLogo] FROM ([MetodoPagos] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosTipo] AND T2.[EstadosGenericosId] = T1.[EstadosGenericosId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Metodopagoswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[MetodoPagosID] AS decimal(18,0))) like '%' + @lV61Metodopagoswwds_1_filterfulltext) or ( UPPER(T1.[MetodoPagosNombre]) like '%' + UPPER(@lV61Metodopagoswwds_1_filterfulltext)) or ( UPPER(T1.[MetodoPagosCodigo]) like '%' + UPPER(@lV61Metodopagoswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Metodopagoswwds_2_dynamicfiltersselector1, "METODOPAGOSNOMBRE") == 0 ) && ( AV63Metodopagoswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Metodopagoswwds_4_metodopagosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MetodoPagosNombre]) like UPPER(@lV64Metodopagoswwds_4_metodopagosnombre1))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Metodopagoswwds_2_dynamicfiltersselector1, "METODOPAGOSNOMBRE") == 0 ) && ( AV63Metodopagoswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Metodopagoswwds_4_metodopagosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MetodoPagosNombre]) like '%' + UPPER(@lV64Metodopagoswwds_4_metodopagosnombre1))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Metodopagoswwds_2_dynamicfiltersselector1, "ESTADOSGENERICOSNOMBRE") == 0 ) && ( AV63Metodopagoswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Metodopagoswwds_5_estadosgenericosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like UPPER(@lV65Metodopagoswwds_5_estadosgenericosnombre1))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Metodopagoswwds_2_dynamicfiltersselector1, "ESTADOSGENERICOSNOMBRE") == 0 ) && ( AV63Metodopagoswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Metodopagoswwds_5_estadosgenericosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like '%' + UPPER(@lV65Metodopagoswwds_5_estadosgenericosnombre1))");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV66Metodopagoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Metodopagoswwds_7_dynamicfiltersselector2, "METODOPAGOSNOMBRE") == 0 ) && ( AV68Metodopagoswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Metodopagoswwds_9_metodopagosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MetodoPagosNombre]) like UPPER(@lV69Metodopagoswwds_9_metodopagosnombre2))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( AV66Metodopagoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Metodopagoswwds_7_dynamicfiltersselector2, "METODOPAGOSNOMBRE") == 0 ) && ( AV68Metodopagoswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Metodopagoswwds_9_metodopagosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MetodoPagosNombre]) like '%' + UPPER(@lV69Metodopagoswwds_9_metodopagosnombre2))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( AV66Metodopagoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Metodopagoswwds_7_dynamicfiltersselector2, "ESTADOSGENERICOSNOMBRE") == 0 ) && ( AV68Metodopagoswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Metodopagoswwds_10_estadosgenericosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like UPPER(@lV70Metodopagoswwds_10_estadosgenericosnombre2))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( AV66Metodopagoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Metodopagoswwds_7_dynamicfiltersselector2, "ESTADOSGENERICOSNOMBRE") == 0 ) && ( AV68Metodopagoswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Metodopagoswwds_10_estadosgenericosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like '%' + UPPER(@lV70Metodopagoswwds_10_estadosgenericosnombre2))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( AV71Metodopagoswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Metodopagoswwds_12_dynamicfiltersselector3, "METODOPAGOSNOMBRE") == 0 ) && ( AV73Metodopagoswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Metodopagoswwds_14_metodopagosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MetodoPagosNombre]) like UPPER(@lV74Metodopagoswwds_14_metodopagosnombre3))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( AV71Metodopagoswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Metodopagoswwds_12_dynamicfiltersselector3, "METODOPAGOSNOMBRE") == 0 ) && ( AV73Metodopagoswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Metodopagoswwds_14_metodopagosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MetodoPagosNombre]) like '%' + UPPER(@lV74Metodopagoswwds_14_metodopagosnombre3))");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( AV71Metodopagoswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Metodopagoswwds_12_dynamicfiltersselector3, "ESTADOSGENERICOSNOMBRE") == 0 ) && ( AV73Metodopagoswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Metodopagoswwds_15_estadosgenericosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like UPPER(@lV75Metodopagoswwds_15_estadosgenericosnombre3))");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( AV71Metodopagoswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Metodopagoswwds_12_dynamicfiltersselector3, "ESTADOSGENERICOSNOMBRE") == 0 ) && ( AV73Metodopagoswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Metodopagoswwds_15_estadosgenericosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like '%' + UPPER(@lV75Metodopagoswwds_15_estadosgenericosnombre3))");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( ! (0==AV76Metodopagoswwds_16_tfmetodopagosid) )
         {
            AddWhere(sWhereString, "(T1.[MetodoPagosID] >= @AV76Metodopagoswwds_16_tfmetodopagosid)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( ! (0==AV77Metodopagoswwds_17_tfmetodopagosid_to) )
         {
            AddWhere(sWhereString, "(T1.[MetodoPagosID] <= @AV77Metodopagoswwds_17_tfmetodopagosid_to)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Metodopagoswwds_19_tfmetodopagosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Metodopagoswwds_18_tfmetodopagosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MetodoPagosNombre]) like UPPER(@lV78Metodopagoswwds_18_tfmetodopagosnombre))");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Metodopagoswwds_19_tfmetodopagosnombre_sel)) && ! ( StringUtil.StrCmp(AV79Metodopagoswwds_19_tfmetodopagosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MetodoPagosNombre] = @AV79Metodopagoswwds_19_tfmetodopagosnombre_sel)");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( StringUtil.StrCmp(AV79Metodopagoswwds_19_tfmetodopagosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MetodoPagosNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Metodopagoswwds_21_tfmetodopagoscodigo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Metodopagoswwds_20_tfmetodopagoscodigo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MetodoPagosCodigo]) like UPPER(@lV80Metodopagoswwds_20_tfmetodopagoscodigo))");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Metodopagoswwds_21_tfmetodopagoscodigo_sel)) && ! ( StringUtil.StrCmp(AV81Metodopagoswwds_21_tfmetodopagoscodigo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MetodoPagosCodigo] = @AV81Metodopagoswwds_21_tfmetodopagoscodigo_sel)");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( StringUtil.StrCmp(AV81Metodopagoswwds_21_tfmetodopagoscodigo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[MetodoPagosCodigo])=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosNombre]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosCodigo]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosCodigo] DESC";
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
                     return conditional_P004M2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] , (bool)dynConstraints[26] );
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
          Object[] prmP004M2;
          prmP004M2 = new Object[] {
          new ParDef("@lV61Metodopagoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV61Metodopagoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV61Metodopagoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Metodopagoswwds_4_metodopagosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV64Metodopagoswwds_4_metodopagosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV65Metodopagoswwds_5_estadosgenericosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV65Metodopagoswwds_5_estadosgenericosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV69Metodopagoswwds_9_metodopagosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV69Metodopagoswwds_9_metodopagosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV70Metodopagoswwds_10_estadosgenericosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV70Metodopagoswwds_10_estadosgenericosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV74Metodopagoswwds_14_metodopagosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV74Metodopagoswwds_14_metodopagosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV75Metodopagoswwds_15_estadosgenericosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV75Metodopagoswwds_15_estadosgenericosnombre3",GXType.Char,80,0) ,
          new ParDef("@AV76Metodopagoswwds_16_tfmetodopagosid",GXType.Decimal,18,0) ,
          new ParDef("@AV77Metodopagoswwds_17_tfmetodopagosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV78Metodopagoswwds_18_tfmetodopagosnombre",GXType.Char,80,0) ,
          new ParDef("@AV79Metodopagoswwds_19_tfmetodopagosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV80Metodopagoswwds_20_tfmetodopagoscodigo",GXType.VarChar,200,0) ,
          new ParDef("@AV81Metodopagoswwds_21_tfmetodopagoscodigo_sel",GXType.NVarChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004M2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004M2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 80);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(7));
                return;
       }
    }

 }

}
