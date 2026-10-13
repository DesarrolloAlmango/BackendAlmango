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
   public class vinculartrnwwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public vinculartrnwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public vinculartrnwwexportreport( IGxContext context )
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
         setOutputFileName("VincularTrnWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWVincularTrn", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV73Pgmname));
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
               AV71Title = context.GetMessage( "Lista de Vincular Trn", "");
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
            H6D0( true, 0) ;
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
            H6D0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV32GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "VINCULARTRNSOLIDICUTD") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV16VincularTrnSolidicutd1 = (long)(Math.Round(NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               if ( ! (0==AV16VincularTrnSolidicutd1) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterVincularTrnSolidicutdDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Solicitud", ""), "<", "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterVincularTrnSolidicutdDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Solicitud", ""), "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 2 )
                  {
                     AV17FilterVincularTrnSolidicutdDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Solicitud", ""), ">", "", "", "", "", "", "", "");
                  }
                  AV18VincularTrnSolidicutd = AV16VincularTrnSolidicutd1;
                  H6D0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterVincularTrnSolidicutdDescription, "")), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18VincularTrnSolidicutd), "ZZZZZZZZZZZZZZZZZ9")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "PROVEEDORNOMBRE") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV19ProveedorNombre1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19ProveedorNombre1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV20FilterProveedorNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV20FilterProveedorNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV21ProveedorNombre = AV19ProveedorNombre1;
                  H6D0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterProveedorNombreDescription, "")), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21ProveedorNombre, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "VINCULARTRNSOLIDICUTD") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV25VincularTrnSolidicutd2 = (long)(Math.Round(NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  if ( ! (0==AV25VincularTrnSolidicutd2) )
                  {
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterVincularTrnSolidicutdDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Solicitud", ""), "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterVincularTrnSolidicutdDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Solicitud", ""), "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 2 )
                     {
                        AV17FilterVincularTrnSolidicutdDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Solicitud", ""), ">", "", "", "", "", "", "", "");
                     }
                     AV18VincularTrnSolidicutd = AV25VincularTrnSolidicutd2;
                     H6D0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterVincularTrnSolidicutdDescription, "")), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18VincularTrnSolidicutd), "ZZZZZZZZZZZZZZZZZ9")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PROVEEDORNOMBRE") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV26ProveedorNombre2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ProveedorNombre2)) )
                  {
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV20FilterProveedorNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV20FilterProveedorNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV21ProveedorNombre = AV26ProveedorNombre2;
                     H6D0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterProveedorNombreDescription, "")), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21ProveedorNombre, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "VINCULARTRNSOLIDICUTD") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV30VincularTrnSolidicutd3 = (long)(Math.Round(NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     if ( ! (0==AV30VincularTrnSolidicutd3) )
                     {
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterVincularTrnSolidicutdDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Solicitud", ""), "<", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterVincularTrnSolidicutdDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Solicitud", ""), "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 2 )
                        {
                           AV17FilterVincularTrnSolidicutdDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Solicitud", ""), ">", "", "", "", "", "", "", "");
                        }
                        AV18VincularTrnSolidicutd = AV30VincularTrnSolidicutd3;
                        H6D0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterVincularTrnSolidicutdDescription, "")), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18VincularTrnSolidicutd), "ZZZZZZZZZZZZZZZZZ9")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PROVEEDORNOMBRE") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV31ProveedorNombre3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31ProveedorNombre3)) )
                     {
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV20FilterProveedorNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV20FilterProveedorNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV21ProveedorNombre = AV31ProveedorNombre3;
                        H6D0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterProveedorNombreDescription, "")), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21ProveedorNombre, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV37TFVincularTrnId) && (0==AV38TFVincularTrnId_To) ) )
         {
            H6D0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nro", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV37TFVincularTrnId), "ZZZZZZZZZZZZZZZZZ9")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV55TFVincularTrnId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nro", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H6D0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55TFVincularTrnId_To_Description, "")), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV38TFVincularTrnId_To), "ZZZZZZZZZZZZZZZZZ9")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (0==AV39TFProveedorID) && (0==AV40TFProveedorID_To) ) )
         {
            H6D0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Código del Proveedor", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV39TFProveedorID), "ZZZZZZZZZZZZZZZZZ9")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV56TFProveedorID_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Código del Proveedor", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H6D0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56TFProveedorID_To_Description, "")), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV40TFProveedorID_To), "ZZZZZZZZZZZZZZZZZ9")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TFProveedorNombre_Sel)) )
         {
            AV60TempBoolean = (bool)(((StringUtil.StrCmp(AV42TFProveedorNombre_Sel, "<#Empty#>")==0)));
            AV42TFProveedorNombre_Sel = (AV60TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV42TFProveedorNombre_Sel);
            H6D0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Proveedor Nombre", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFProveedorNombre_Sel, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV42TFProveedorNombre_Sel = (AV60TempBoolean ? "<#Empty#>" : AV42TFProveedorNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41TFProveedorNombre)) )
            {
               H6D0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Proveedor Nombre", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFProveedorNombre, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (0==AV43TFVincularTrnSolidicutd) && (0==AV44TFVincularTrnSolidicutd_To) ) )
         {
            H6D0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Solicitud", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV43TFVincularTrnSolidicutd), "ZZZZZZZZZZZZZZZZZ9")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV57TFVincularTrnSolidicutd_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Solicitud", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H6D0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57TFVincularTrnSolidicutd_To_Description, "")), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV44TFVincularTrnSolidicutd_To), "ZZZZZZZZZZZZZZZZZ9")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46TFVincularTrnNombreSol_Sel)) )
         {
            AV60TempBoolean = (bool)(((StringUtil.StrCmp(AV46TFVincularTrnNombreSol_Sel, "<#Empty#>")==0)));
            AV46TFVincularTrnNombreSol_Sel = (AV60TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV46TFVincularTrnNombreSol_Sel);
            H6D0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nombre del Cliente", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46TFVincularTrnNombreSol_Sel, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV46TFVincularTrnNombreSol_Sel = (AV60TempBoolean ? "<#Empty#>" : AV46TFVincularTrnNombreSol_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45TFVincularTrnNombreSol)) )
            {
               H6D0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Nombre del Cliente", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45TFVincularTrnNombreSol, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48TFVincularTrnTelefonoSol_Sel)) )
         {
            AV60TempBoolean = (bool)(((StringUtil.StrCmp(AV48TFVincularTrnTelefonoSol_Sel, "<#Empty#>")==0)));
            AV48TFVincularTrnTelefonoSol_Sel = (AV60TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV48TFVincularTrnTelefonoSol_Sel);
            H6D0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Teléfono del Cliente", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48TFVincularTrnTelefonoSol_Sel, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV48TFVincularTrnTelefonoSol_Sel = (AV60TempBoolean ? "<#Empty#>" : AV48TFVincularTrnTelefonoSol_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47TFVincularTrnTelefonoSol)) )
            {
               H6D0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Teléfono del Cliente", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47TFVincularTrnTelefonoSol, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (0==AV49TFDocumentacionId) && (0==AV50TFDocumentacionId_To) ) )
         {
            H6D0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Documentación", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV49TFDocumentacionId), "ZZZZZZZZZZZZZZZZZ9")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV58TFDocumentacionId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Documentación", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H6D0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58TFDocumentacionId_To_Description, "")), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV50TFDocumentacionId_To), "ZZZZZZZZZZZZZZZZZ9")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52TFVincularTrnComentario_Sel)) )
         {
            AV60TempBoolean = (bool)(((StringUtil.StrCmp(AV52TFVincularTrnComentario_Sel, "<#Empty#>")==0)));
            AV52TFVincularTrnComentario_Sel = (AV60TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV52TFVincularTrnComentario_Sel);
            H6D0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Comentario", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52TFVincularTrnComentario_Sel, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV52TFVincularTrnComentario_Sel = (AV60TempBoolean ? "<#Empty#>" : AV52TFVincularTrnComentario_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51TFVincularTrnComentario)) )
            {
               H6D0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Comentario", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51TFVincularTrnComentario, "")), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (DateTime.MinValue==AV53TFVincularTrnFecha) && (DateTime.MinValue==AV54TFVincularTrnFecha_To) ) )
         {
            H6D0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Fecha", ""), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV53TFVincularTrnFecha, "99/99/99"), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV59TFVincularTrnFecha_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Fecha", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H6D0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59TFVincularTrnFecha_To_Description, "")), 25, Gx_line+0, 204, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV54TFVincularTrnFecha_To, "99/99/99"), 204, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H6D0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H6D0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Nro", ""), 30, Gx_line+10, 95, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Código del Proveedor", ""), 99, Gx_line+10, 164, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Proveedor Nombre", ""), 168, Gx_line+10, 233, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Solicitud", ""), 237, Gx_line+10, 302, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Nombre del Cliente", ""), 306, Gx_line+10, 371, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Teléfono del Cliente", ""), 375, Gx_line+10, 440, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Documentación", ""), 444, Gx_line+10, 509, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Fotografia", ""), 513, Gx_line+10, 578, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Comentario", ""), 582, Gx_line+10, 647, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Fecha", ""), 651, Gx_line+10, 717, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Icono", ""), 721, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV77Vinculartrnwwds_1_filterfulltext = AV13FilterFullText;
         AV78Vinculartrnwwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV79Vinculartrnwwds_3_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV80Vinculartrnwwds_4_vinculartrnsolidicutd1 = AV16VincularTrnSolidicutd1;
         AV81Vinculartrnwwds_5_proveedornombre1 = AV19ProveedorNombre1;
         AV82Vinculartrnwwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV83Vinculartrnwwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV84Vinculartrnwwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV85Vinculartrnwwds_9_vinculartrnsolidicutd2 = AV25VincularTrnSolidicutd2;
         AV86Vinculartrnwwds_10_proveedornombre2 = AV26ProveedorNombre2;
         AV87Vinculartrnwwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV88Vinculartrnwwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV89Vinculartrnwwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV90Vinculartrnwwds_14_vinculartrnsolidicutd3 = AV30VincularTrnSolidicutd3;
         AV91Vinculartrnwwds_15_proveedornombre3 = AV31ProveedorNombre3;
         AV92Vinculartrnwwds_16_tfvinculartrnid = AV37TFVincularTrnId;
         AV93Vinculartrnwwds_17_tfvinculartrnid_to = AV38TFVincularTrnId_To;
         AV94Vinculartrnwwds_18_tfproveedorid = AV39TFProveedorID;
         AV95Vinculartrnwwds_19_tfproveedorid_to = AV40TFProveedorID_To;
         AV96Vinculartrnwwds_20_tfproveedornombre = AV41TFProveedorNombre;
         AV97Vinculartrnwwds_21_tfproveedornombre_sel = AV42TFProveedorNombre_Sel;
         AV98Vinculartrnwwds_22_tfvinculartrnsolidicutd = AV43TFVincularTrnSolidicutd;
         AV99Vinculartrnwwds_23_tfvinculartrnsolidicutd_to = AV44TFVincularTrnSolidicutd_To;
         AV100Vinculartrnwwds_24_tfvinculartrnnombresol = AV45TFVincularTrnNombreSol;
         AV101Vinculartrnwwds_25_tfvinculartrnnombresol_sel = AV46TFVincularTrnNombreSol_Sel;
         AV102Vinculartrnwwds_26_tfvinculartrntelefonosol = AV47TFVincularTrnTelefonoSol;
         AV103Vinculartrnwwds_27_tfvinculartrntelefonosol_sel = AV48TFVincularTrnTelefonoSol_Sel;
         AV104Vinculartrnwwds_28_tfdocumentacionid = AV49TFDocumentacionId;
         AV105Vinculartrnwwds_29_tfdocumentacionid_to = AV50TFDocumentacionId_To;
         AV106Vinculartrnwwds_30_tfvinculartrncomentario = AV51TFVincularTrnComentario;
         AV107Vinculartrnwwds_31_tfvinculartrncomentario_sel = AV52TFVincularTrnComentario_Sel;
         AV108Vinculartrnwwds_32_tfvinculartrnfecha = AV53TFVincularTrnFecha;
         AV109Vinculartrnwwds_33_tfvinculartrnfecha_to = AV54TFVincularTrnFecha_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV77Vinculartrnwwds_1_filterfulltext ,
                                              AV78Vinculartrnwwds_2_dynamicfiltersselector1 ,
                                              AV79Vinculartrnwwds_3_dynamicfiltersoperator1 ,
                                              AV80Vinculartrnwwds_4_vinculartrnsolidicutd1 ,
                                              AV81Vinculartrnwwds_5_proveedornombre1 ,
                                              AV82Vinculartrnwwds_6_dynamicfiltersenabled2 ,
                                              AV83Vinculartrnwwds_7_dynamicfiltersselector2 ,
                                              AV84Vinculartrnwwds_8_dynamicfiltersoperator2 ,
                                              AV85Vinculartrnwwds_9_vinculartrnsolidicutd2 ,
                                              AV86Vinculartrnwwds_10_proveedornombre2 ,
                                              AV87Vinculartrnwwds_11_dynamicfiltersenabled3 ,
                                              AV88Vinculartrnwwds_12_dynamicfiltersselector3 ,
                                              AV89Vinculartrnwwds_13_dynamicfiltersoperator3 ,
                                              AV90Vinculartrnwwds_14_vinculartrnsolidicutd3 ,
                                              AV91Vinculartrnwwds_15_proveedornombre3 ,
                                              AV92Vinculartrnwwds_16_tfvinculartrnid ,
                                              AV93Vinculartrnwwds_17_tfvinculartrnid_to ,
                                              AV94Vinculartrnwwds_18_tfproveedorid ,
                                              AV95Vinculartrnwwds_19_tfproveedorid_to ,
                                              AV97Vinculartrnwwds_21_tfproveedornombre_sel ,
                                              AV96Vinculartrnwwds_20_tfproveedornombre ,
                                              AV98Vinculartrnwwds_22_tfvinculartrnsolidicutd ,
                                              AV99Vinculartrnwwds_23_tfvinculartrnsolidicutd_to ,
                                              AV101Vinculartrnwwds_25_tfvinculartrnnombresol_sel ,
                                              AV100Vinculartrnwwds_24_tfvinculartrnnombresol ,
                                              AV103Vinculartrnwwds_27_tfvinculartrntelefonosol_sel ,
                                              AV102Vinculartrnwwds_26_tfvinculartrntelefonosol ,
                                              AV104Vinculartrnwwds_28_tfdocumentacionid ,
                                              AV105Vinculartrnwwds_29_tfdocumentacionid_to ,
                                              AV107Vinculartrnwwds_31_tfvinculartrncomentario_sel ,
                                              AV106Vinculartrnwwds_30_tfvinculartrncomentario ,
                                              AV108Vinculartrnwwds_32_tfvinculartrnfecha ,
                                              AV109Vinculartrnwwds_33_tfvinculartrnfecha_to ,
                                              A491VincularTrnId ,
                                              A133ProveedorID ,
                                              A282ProveedorNombre ,
                                              A492VincularTrnSolidicutd ,
                                              A493VincularTrnNombreSol ,
                                              A494VincularTrnTelefonoSol ,
                                              A488DocumentacionId ,
                                              A497VincularTrnComentario ,
                                              A496VincularTrnFecha ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV77Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Vinculartrnwwds_1_filterfulltext), "%", "");
         lV77Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Vinculartrnwwds_1_filterfulltext), "%", "");
         lV77Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Vinculartrnwwds_1_filterfulltext), "%", "");
         lV77Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Vinculartrnwwds_1_filterfulltext), "%", "");
         lV77Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Vinculartrnwwds_1_filterfulltext), "%", "");
         lV77Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Vinculartrnwwds_1_filterfulltext), "%", "");
         lV77Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Vinculartrnwwds_1_filterfulltext), "%", "");
         lV77Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Vinculartrnwwds_1_filterfulltext), "%", "");
         lV81Vinculartrnwwds_5_proveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV81Vinculartrnwwds_5_proveedornombre1), 80, "%");
         lV81Vinculartrnwwds_5_proveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV81Vinculartrnwwds_5_proveedornombre1), 80, "%");
         lV86Vinculartrnwwds_10_proveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV86Vinculartrnwwds_10_proveedornombre2), 80, "%");
         lV86Vinculartrnwwds_10_proveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV86Vinculartrnwwds_10_proveedornombre2), 80, "%");
         lV91Vinculartrnwwds_15_proveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV91Vinculartrnwwds_15_proveedornombre3), 80, "%");
         lV91Vinculartrnwwds_15_proveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV91Vinculartrnwwds_15_proveedornombre3), 80, "%");
         lV96Vinculartrnwwds_20_tfproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV96Vinculartrnwwds_20_tfproveedornombre), 80, "%");
         lV100Vinculartrnwwds_24_tfvinculartrnnombresol = StringUtil.PadR( StringUtil.RTrim( AV100Vinculartrnwwds_24_tfvinculartrnnombresol), 80, "%");
         lV102Vinculartrnwwds_26_tfvinculartrntelefonosol = StringUtil.PadR( StringUtil.RTrim( AV102Vinculartrnwwds_26_tfvinculartrntelefonosol), 20, "%");
         lV106Vinculartrnwwds_30_tfvinculartrncomentario = StringUtil.Concat( StringUtil.RTrim( AV106Vinculartrnwwds_30_tfvinculartrncomentario), "%", "");
         /* Using cursor P006D2 */
         pr_default.execute(0, new Object[] {lV77Vinculartrnwwds_1_filterfulltext, lV77Vinculartrnwwds_1_filterfulltext, lV77Vinculartrnwwds_1_filterfulltext, lV77Vinculartrnwwds_1_filterfulltext, lV77Vinculartrnwwds_1_filterfulltext, lV77Vinculartrnwwds_1_filterfulltext, lV77Vinculartrnwwds_1_filterfulltext, lV77Vinculartrnwwds_1_filterfulltext, AV80Vinculartrnwwds_4_vinculartrnsolidicutd1, AV80Vinculartrnwwds_4_vinculartrnsolidicutd1, AV80Vinculartrnwwds_4_vinculartrnsolidicutd1, lV81Vinculartrnwwds_5_proveedornombre1, lV81Vinculartrnwwds_5_proveedornombre1, AV85Vinculartrnwwds_9_vinculartrnsolidicutd2, AV85Vinculartrnwwds_9_vinculartrnsolidicutd2, AV85Vinculartrnwwds_9_vinculartrnsolidicutd2, lV86Vinculartrnwwds_10_proveedornombre2, lV86Vinculartrnwwds_10_proveedornombre2, AV90Vinculartrnwwds_14_vinculartrnsolidicutd3, AV90Vinculartrnwwds_14_vinculartrnsolidicutd3, AV90Vinculartrnwwds_14_vinculartrnsolidicutd3, lV91Vinculartrnwwds_15_proveedornombre3, lV91Vinculartrnwwds_15_proveedornombre3, AV92Vinculartrnwwds_16_tfvinculartrnid, AV93Vinculartrnwwds_17_tfvinculartrnid_to, AV94Vinculartrnwwds_18_tfproveedorid, AV95Vinculartrnwwds_19_tfproveedorid_to, lV96Vinculartrnwwds_20_tfproveedornombre, AV97Vinculartrnwwds_21_tfproveedornombre_sel, AV98Vinculartrnwwds_22_tfvinculartrnsolidicutd, AV99Vinculartrnwwds_23_tfvinculartrnsolidicutd_to, lV100Vinculartrnwwds_24_tfvinculartrnnombresol, AV101Vinculartrnwwds_25_tfvinculartrnnombresol_sel, lV102Vinculartrnwwds_26_tfvinculartrntelefonosol, AV103Vinculartrnwwds_27_tfvinculartrntelefonosol_sel, AV104Vinculartrnwwds_28_tfdocumentacionid, AV105Vinculartrnwwds_29_tfdocumentacionid_to, lV106Vinculartrnwwds_30_tfvinculartrncomentario, AV107Vinculartrnwwds_31_tfvinculartrncomentario_sel, AV108Vinculartrnwwds_32_tfvinculartrnfecha, AV109Vinculartrnwwds_33_tfvinculartrnfecha_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A496VincularTrnFecha = P006D2_A496VincularTrnFecha[0];
            A497VincularTrnComentario = P006D2_A497VincularTrnComentario[0];
            A488DocumentacionId = P006D2_A488DocumentacionId[0];
            n488DocumentacionId = P006D2_n488DocumentacionId[0];
            A494VincularTrnTelefonoSol = P006D2_A494VincularTrnTelefonoSol[0];
            A493VincularTrnNombreSol = P006D2_A493VincularTrnNombreSol[0];
            A282ProveedorNombre = P006D2_A282ProveedorNombre[0];
            A133ProveedorID = P006D2_A133ProveedorID[0];
            A491VincularTrnId = P006D2_A491VincularTrnId[0];
            A492VincularTrnSolidicutd = P006D2_A492VincularTrnSolidicutd[0];
            A40001DocumentacionIcono_GXI = P006D2_A40001DocumentacionIcono_GXI[0];
            A40000VincularTrnImagen_GXI = P006D2_A40000VincularTrnImagen_GXI[0];
            A498DocumentacionIcono = P006D2_A498DocumentacionIcono[0];
            A495VincularTrnImagen = P006D2_A495VincularTrnImagen[0];
            A488DocumentacionId = P006D2_A488DocumentacionId[0];
            n488DocumentacionId = P006D2_n488DocumentacionId[0];
            A282ProveedorNombre = P006D2_A282ProveedorNombre[0];
            A40001DocumentacionIcono_GXI = P006D2_A40001DocumentacionIcono_GXI[0];
            A498DocumentacionIcono = P006D2_A498DocumentacionIcono[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H6D0( false, 66) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A491VincularTrnId), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 95, Gx_line+55, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9")), 99, Gx_line+10, 164, Gx_line+55, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A282ProveedorNombre, "")), 168, Gx_line+10, 233, Gx_line+55, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A492VincularTrnSolidicutd), "ZZZZZZZZZZZZZZZZZ9")), 237, Gx_line+10, 302, Gx_line+55, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A493VincularTrnNombreSol, "")), 306, Gx_line+10, 371, Gx_line+55, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A494VincularTrnTelefonoSol, "")), 375, Gx_line+10, 440, Gx_line+55, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A488DocumentacionId), "ZZZZZZZZZZZZZZZZZ9")), 444, Gx_line+10, 509, Gx_line+55, 2+16, 0, 0, 0) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen)) ? A40000VincularTrnImagen_GXI : A495VincularTrnImagen);
            getPrinter().GxDrawBitMap(sImgUrl, 513, Gx_line+10, 578, Gx_line+55) ;
            getPrinter().GxDrawText(A497VincularTrnComentario, 582, Gx_line+10, 647, Gx_line+55, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A496VincularTrnFecha, "99/99/99"), 651, Gx_line+10, 717, Gx_line+55, 0+16, 0, 0, 0) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : A498DocumentacionIcono);
            getPrinter().GxDrawBitMap(sImgUrl, 721, Gx_line+10, 787, Gx_line+55) ;
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
         if ( StringUtil.StrCmp(AV33Session.Get("VincularTrnWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "VincularTrnWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("VincularTrnWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV35GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV35GridState.gxTpr_Ordereddsc;
         AV110GXV1 = 1;
         while ( AV110GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV110GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNID") == 0 )
            {
               AV37TFVincularTrnId = (long)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV38TFVincularTrnId_To = (long)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPROVEEDORID") == 0 )
            {
               AV39TFProveedorID = (long)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV40TFProveedorID_To = (long)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE") == 0 )
            {
               AV41TFProveedorNombre = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE_SEL") == 0 )
            {
               AV42TFProveedorNombre_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNSOLIDICUTD") == 0 )
            {
               AV43TFVincularTrnSolidicutd = (long)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV44TFVincularTrnSolidicutd_To = (long)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNNOMBRESOL") == 0 )
            {
               AV45TFVincularTrnNombreSol = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNNOMBRESOL_SEL") == 0 )
            {
               AV46TFVincularTrnNombreSol_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNTELEFONOSOL") == 0 )
            {
               AV47TFVincularTrnTelefonoSol = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNTELEFONOSOL_SEL") == 0 )
            {
               AV48TFVincularTrnTelefonoSol_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFDOCUMENTACIONID") == 0 )
            {
               AV49TFDocumentacionId = (long)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV50TFDocumentacionId_To = (long)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNCOMENTARIO") == 0 )
            {
               AV51TFVincularTrnComentario = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNCOMENTARIO_SEL") == 0 )
            {
               AV52TFVincularTrnComentario_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNFECHA") == 0 )
            {
               AV53TFVincularTrnFecha = context.localUtil.CToD( AV36GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV54TFVincularTrnFecha_To = context.localUtil.CToD( AV36GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            AV110GXV1 = (int)(AV110GXV1+1);
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

      protected void H6D0( bool bFoot ,
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
                  AV69PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV66DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV69PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV64AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV70Phone = "+1 550 8923";
               AV68Mail = "info@mail.com";
               AV72Website = "http://www.web.com";
               AV61AddressLine1 = "French Boulevard 2859";
               AV62AddressLine2 = "Downtown";
               AV63AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV72Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV73Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV71Title = "";
         AV13FilterFullText = "";
         AV35GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV32GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV17FilterVincularTrnSolidicutdDescription = "";
         AV19ProveedorNombre1 = "";
         AV20FilterProveedorNombreDescription = "";
         AV21ProveedorNombre = "";
         AV23DynamicFiltersSelector2 = "";
         AV26ProveedorNombre2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV31ProveedorNombre3 = "";
         AV55TFVincularTrnId_To_Description = "";
         AV56TFProveedorID_To_Description = "";
         AV42TFProveedorNombre_Sel = "";
         AV41TFProveedorNombre = "";
         AV57TFVincularTrnSolidicutd_To_Description = "";
         AV46TFVincularTrnNombreSol_Sel = "";
         AV45TFVincularTrnNombreSol = "";
         AV48TFVincularTrnTelefonoSol_Sel = "";
         AV47TFVincularTrnTelefonoSol = "";
         AV58TFDocumentacionId_To_Description = "";
         AV52TFVincularTrnComentario_Sel = "";
         AV51TFVincularTrnComentario = "";
         AV53TFVincularTrnFecha = DateTime.MinValue;
         AV54TFVincularTrnFecha_To = DateTime.MinValue;
         AV59TFVincularTrnFecha_To_Description = "";
         AV77Vinculartrnwwds_1_filterfulltext = "";
         AV78Vinculartrnwwds_2_dynamicfiltersselector1 = "";
         AV81Vinculartrnwwds_5_proveedornombre1 = "";
         AV83Vinculartrnwwds_7_dynamicfiltersselector2 = "";
         AV86Vinculartrnwwds_10_proveedornombre2 = "";
         AV88Vinculartrnwwds_12_dynamicfiltersselector3 = "";
         AV91Vinculartrnwwds_15_proveedornombre3 = "";
         AV96Vinculartrnwwds_20_tfproveedornombre = "";
         AV97Vinculartrnwwds_21_tfproveedornombre_sel = "";
         AV100Vinculartrnwwds_24_tfvinculartrnnombresol = "";
         AV101Vinculartrnwwds_25_tfvinculartrnnombresol_sel = "";
         AV102Vinculartrnwwds_26_tfvinculartrntelefonosol = "";
         AV103Vinculartrnwwds_27_tfvinculartrntelefonosol_sel = "";
         AV106Vinculartrnwwds_30_tfvinculartrncomentario = "";
         AV107Vinculartrnwwds_31_tfvinculartrncomentario_sel = "";
         AV108Vinculartrnwwds_32_tfvinculartrnfecha = DateTime.MinValue;
         AV109Vinculartrnwwds_33_tfvinculartrnfecha_to = DateTime.MinValue;
         lV77Vinculartrnwwds_1_filterfulltext = "";
         lV81Vinculartrnwwds_5_proveedornombre1 = "";
         lV86Vinculartrnwwds_10_proveedornombre2 = "";
         lV91Vinculartrnwwds_15_proveedornombre3 = "";
         lV96Vinculartrnwwds_20_tfproveedornombre = "";
         lV100Vinculartrnwwds_24_tfvinculartrnnombresol = "";
         lV102Vinculartrnwwds_26_tfvinculartrntelefonosol = "";
         lV106Vinculartrnwwds_30_tfvinculartrncomentario = "";
         A282ProveedorNombre = "";
         A493VincularTrnNombreSol = "";
         A494VincularTrnTelefonoSol = "";
         A497VincularTrnComentario = "";
         A496VincularTrnFecha = DateTime.MinValue;
         P006D2_A496VincularTrnFecha = new DateTime[] {DateTime.MinValue} ;
         P006D2_A497VincularTrnComentario = new string[] {""} ;
         P006D2_A488DocumentacionId = new long[1] ;
         P006D2_n488DocumentacionId = new bool[] {false} ;
         P006D2_A494VincularTrnTelefonoSol = new string[] {""} ;
         P006D2_A493VincularTrnNombreSol = new string[] {""} ;
         P006D2_A282ProveedorNombre = new string[] {""} ;
         P006D2_A133ProveedorID = new long[1] ;
         P006D2_A491VincularTrnId = new long[1] ;
         P006D2_A492VincularTrnSolidicutd = new long[1] ;
         P006D2_A40001DocumentacionIcono_GXI = new string[] {""} ;
         P006D2_A40000VincularTrnImagen_GXI = new string[] {""} ;
         P006D2_A498DocumentacionIcono = new string[] {""} ;
         P006D2_A495VincularTrnImagen = new string[] {""} ;
         A40001DocumentacionIcono_GXI = "";
         A40000VincularTrnImagen_GXI = "";
         A498DocumentacionIcono = "";
         A495VincularTrnImagen = "";
         sImgUrl = "";
         AV33Session = context.GetSession();
         AV36GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV69PageInfo = "";
         AV66DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV64AppName = "";
         AV70Phone = "";
         AV68Mail = "";
         AV72Website = "";
         AV61AddressLine1 = "";
         AV62AddressLine2 = "";
         AV63AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.vinculartrnwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P006D2_A496VincularTrnFecha, P006D2_A497VincularTrnComentario, P006D2_A488DocumentacionId, P006D2_n488DocumentacionId, P006D2_A494VincularTrnTelefonoSol, P006D2_A493VincularTrnNombreSol, P006D2_A282ProveedorNombre, P006D2_A133ProveedorID, P006D2_A491VincularTrnId, P006D2_A492VincularTrnSolidicutd,
               P006D2_A40001DocumentacionIcono_GXI, P006D2_A40000VincularTrnImagen_GXI, P006D2_A498DocumentacionIcono, P006D2_A495VincularTrnImagen
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV73Pgmname = "VincularTrnWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV73Pgmname = "VincularTrnWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV15DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short AV79Vinculartrnwwds_3_dynamicfiltersoperator1 ;
      private short AV84Vinculartrnwwds_8_dynamicfiltersoperator2 ;
      private short AV89Vinculartrnwwds_13_dynamicfiltersoperator3 ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV110GXV1 ;
      private long AV16VincularTrnSolidicutd1 ;
      private long AV18VincularTrnSolidicutd ;
      private long AV25VincularTrnSolidicutd2 ;
      private long AV30VincularTrnSolidicutd3 ;
      private long AV37TFVincularTrnId ;
      private long AV38TFVincularTrnId_To ;
      private long AV39TFProveedorID ;
      private long AV40TFProveedorID_To ;
      private long AV43TFVincularTrnSolidicutd ;
      private long AV44TFVincularTrnSolidicutd_To ;
      private long AV49TFDocumentacionId ;
      private long AV50TFDocumentacionId_To ;
      private long AV80Vinculartrnwwds_4_vinculartrnsolidicutd1 ;
      private long AV85Vinculartrnwwds_9_vinculartrnsolidicutd2 ;
      private long AV90Vinculartrnwwds_14_vinculartrnsolidicutd3 ;
      private long AV92Vinculartrnwwds_16_tfvinculartrnid ;
      private long AV93Vinculartrnwwds_17_tfvinculartrnid_to ;
      private long AV94Vinculartrnwwds_18_tfproveedorid ;
      private long AV95Vinculartrnwwds_19_tfproveedorid_to ;
      private long AV98Vinculartrnwwds_22_tfvinculartrnsolidicutd ;
      private long AV99Vinculartrnwwds_23_tfvinculartrnsolidicutd_to ;
      private long AV104Vinculartrnwwds_28_tfdocumentacionid ;
      private long AV105Vinculartrnwwds_29_tfdocumentacionid_to ;
      private long A491VincularTrnId ;
      private long A133ProveedorID ;
      private long A492VincularTrnSolidicutd ;
      private long A488DocumentacionId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV73Pgmname ;
      private string GXEncryptionTmp ;
      private string AV19ProveedorNombre1 ;
      private string AV21ProveedorNombre ;
      private string AV26ProveedorNombre2 ;
      private string AV31ProveedorNombre3 ;
      private string AV42TFProveedorNombre_Sel ;
      private string AV41TFProveedorNombre ;
      private string AV46TFVincularTrnNombreSol_Sel ;
      private string AV45TFVincularTrnNombreSol ;
      private string AV48TFVincularTrnTelefonoSol_Sel ;
      private string AV47TFVincularTrnTelefonoSol ;
      private string AV81Vinculartrnwwds_5_proveedornombre1 ;
      private string AV86Vinculartrnwwds_10_proveedornombre2 ;
      private string AV91Vinculartrnwwds_15_proveedornombre3 ;
      private string AV96Vinculartrnwwds_20_tfproveedornombre ;
      private string AV97Vinculartrnwwds_21_tfproveedornombre_sel ;
      private string AV100Vinculartrnwwds_24_tfvinculartrnnombresol ;
      private string AV101Vinculartrnwwds_25_tfvinculartrnnombresol_sel ;
      private string AV102Vinculartrnwwds_26_tfvinculartrntelefonosol ;
      private string AV103Vinculartrnwwds_27_tfvinculartrntelefonosol_sel ;
      private string lV81Vinculartrnwwds_5_proveedornombre1 ;
      private string lV86Vinculartrnwwds_10_proveedornombre2 ;
      private string lV91Vinculartrnwwds_15_proveedornombre3 ;
      private string lV96Vinculartrnwwds_20_tfproveedornombre ;
      private string lV100Vinculartrnwwds_24_tfvinculartrnnombresol ;
      private string lV102Vinculartrnwwds_26_tfvinculartrntelefonosol ;
      private string A282ProveedorNombre ;
      private string A493VincularTrnNombreSol ;
      private string A494VincularTrnTelefonoSol ;
      private string sImgUrl ;
      private DateTime AV53TFVincularTrnFecha ;
      private DateTime AV54TFVincularTrnFecha_To ;
      private DateTime AV108Vinculartrnwwds_32_tfvinculartrnfecha ;
      private DateTime AV109Vinculartrnwwds_33_tfvinculartrnfecha_to ;
      private DateTime A496VincularTrnFecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV60TempBoolean ;
      private bool AV82Vinculartrnwwds_6_dynamicfiltersenabled2 ;
      private bool AV87Vinculartrnwwds_11_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private bool n488DocumentacionId ;
      private string A497VincularTrnComentario ;
      private string AV71Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV17FilterVincularTrnSolidicutdDescription ;
      private string AV20FilterProveedorNombreDescription ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV55TFVincularTrnId_To_Description ;
      private string AV56TFProveedorID_To_Description ;
      private string AV57TFVincularTrnSolidicutd_To_Description ;
      private string AV58TFDocumentacionId_To_Description ;
      private string AV52TFVincularTrnComentario_Sel ;
      private string AV51TFVincularTrnComentario ;
      private string AV59TFVincularTrnFecha_To_Description ;
      private string AV77Vinculartrnwwds_1_filterfulltext ;
      private string AV78Vinculartrnwwds_2_dynamicfiltersselector1 ;
      private string AV83Vinculartrnwwds_7_dynamicfiltersselector2 ;
      private string AV88Vinculartrnwwds_12_dynamicfiltersselector3 ;
      private string AV106Vinculartrnwwds_30_tfvinculartrncomentario ;
      private string AV107Vinculartrnwwds_31_tfvinculartrncomentario_sel ;
      private string lV77Vinculartrnwwds_1_filterfulltext ;
      private string lV106Vinculartrnwwds_30_tfvinculartrncomentario ;
      private string A40001DocumentacionIcono_GXI ;
      private string A40000VincularTrnImagen_GXI ;
      private string AV69PageInfo ;
      private string AV66DateInfo ;
      private string AV64AppName ;
      private string AV70Phone ;
      private string AV68Mail ;
      private string AV72Website ;
      private string AV61AddressLine1 ;
      private string AV62AddressLine2 ;
      private string AV63AddressLine3 ;
      private string A498DocumentacionIcono ;
      private string A495VincularTrnImagen ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV32GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P006D2_A496VincularTrnFecha ;
      private string[] P006D2_A497VincularTrnComentario ;
      private long[] P006D2_A488DocumentacionId ;
      private bool[] P006D2_n488DocumentacionId ;
      private string[] P006D2_A494VincularTrnTelefonoSol ;
      private string[] P006D2_A493VincularTrnNombreSol ;
      private string[] P006D2_A282ProveedorNombre ;
      private long[] P006D2_A133ProveedorID ;
      private long[] P006D2_A491VincularTrnId ;
      private long[] P006D2_A492VincularTrnSolidicutd ;
      private string[] P006D2_A40001DocumentacionIcono_GXI ;
      private string[] P006D2_A40000VincularTrnImagen_GXI ;
      private string[] P006D2_A498DocumentacionIcono ;
      private string[] P006D2_A495VincularTrnImagen ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
   }

   public class vinculartrnwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006D2( IGxContext context ,
                                             string AV77Vinculartrnwwds_1_filterfulltext ,
                                             string AV78Vinculartrnwwds_2_dynamicfiltersselector1 ,
                                             short AV79Vinculartrnwwds_3_dynamicfiltersoperator1 ,
                                             long AV80Vinculartrnwwds_4_vinculartrnsolidicutd1 ,
                                             string AV81Vinculartrnwwds_5_proveedornombre1 ,
                                             bool AV82Vinculartrnwwds_6_dynamicfiltersenabled2 ,
                                             string AV83Vinculartrnwwds_7_dynamicfiltersselector2 ,
                                             short AV84Vinculartrnwwds_8_dynamicfiltersoperator2 ,
                                             long AV85Vinculartrnwwds_9_vinculartrnsolidicutd2 ,
                                             string AV86Vinculartrnwwds_10_proveedornombre2 ,
                                             bool AV87Vinculartrnwwds_11_dynamicfiltersenabled3 ,
                                             string AV88Vinculartrnwwds_12_dynamicfiltersselector3 ,
                                             short AV89Vinculartrnwwds_13_dynamicfiltersoperator3 ,
                                             long AV90Vinculartrnwwds_14_vinculartrnsolidicutd3 ,
                                             string AV91Vinculartrnwwds_15_proveedornombre3 ,
                                             long AV92Vinculartrnwwds_16_tfvinculartrnid ,
                                             long AV93Vinculartrnwwds_17_tfvinculartrnid_to ,
                                             long AV94Vinculartrnwwds_18_tfproveedorid ,
                                             long AV95Vinculartrnwwds_19_tfproveedorid_to ,
                                             string AV97Vinculartrnwwds_21_tfproveedornombre_sel ,
                                             string AV96Vinculartrnwwds_20_tfproveedornombre ,
                                             long AV98Vinculartrnwwds_22_tfvinculartrnsolidicutd ,
                                             long AV99Vinculartrnwwds_23_tfvinculartrnsolidicutd_to ,
                                             string AV101Vinculartrnwwds_25_tfvinculartrnnombresol_sel ,
                                             string AV100Vinculartrnwwds_24_tfvinculartrnnombresol ,
                                             string AV103Vinculartrnwwds_27_tfvinculartrntelefonosol_sel ,
                                             string AV102Vinculartrnwwds_26_tfvinculartrntelefonosol ,
                                             long AV104Vinculartrnwwds_28_tfdocumentacionid ,
                                             long AV105Vinculartrnwwds_29_tfdocumentacionid_to ,
                                             string AV107Vinculartrnwwds_31_tfvinculartrncomentario_sel ,
                                             string AV106Vinculartrnwwds_30_tfvinculartrncomentario ,
                                             DateTime AV108Vinculartrnwwds_32_tfvinculartrnfecha ,
                                             DateTime AV109Vinculartrnwwds_33_tfvinculartrnfecha_to ,
                                             long A491VincularTrnId ,
                                             long A133ProveedorID ,
                                             string A282ProveedorNombre ,
                                             long A492VincularTrnSolidicutd ,
                                             string A493VincularTrnNombreSol ,
                                             string A494VincularTrnTelefonoSol ,
                                             long A488DocumentacionId ,
                                             string A497VincularTrnComentario ,
                                             DateTime A496VincularTrnFecha ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[41];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[VincularTrnFecha], T1.[VincularTrnComentario], T2.[DocumentacionId], T1.[VincularTrnTelefonoSol], T1.[VincularTrnNombreSol], T2.[ProveedorNombre], T1.[ProveedorID], T1.[VincularTrnId], T1.[VincularTrnSolidicutd], T3.[DocumentacionIcono_GXI], T1.[VincularTrnImagen_GXI], T3.[DocumentacionIcono], T1.[VincularTrnImagen] FROM (([VincularTrn] T1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[ProveedorID]) LEFT JOIN [Documentacion] T3 ON T3.[DocumentacionId] = T2.[DocumentacionId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Vinculartrnwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[VincularTrnId] AS decimal(18,0))) like '%' + @lV77Vinculartrnwwds_1_filterfulltext) or ( CONVERT( char(18), CAST(T1.[ProveedorID] AS decimal(18,0))) like '%' + @lV77Vinculartrnwwds_1_filterfulltext) or ( UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV77Vinculartrnwwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T1.[VincularTrnSolidicutd] AS decimal(18,0))) like '%' + @lV77Vinculartrnwwds_1_filterfulltext) or ( UPPER(T1.[VincularTrnNombreSol]) like '%' + UPPER(@lV77Vinculartrnwwds_1_filterfulltext)) or ( UPPER(T1.[VincularTrnTelefonoSol]) like '%' + UPPER(@lV77Vinculartrnwwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T2.[DocumentacionId] AS decimal(18,0))) like '%' + @lV77Vinculartrnwwds_1_filterfulltext) or ( UPPER(T1.[VincularTrnComentario]) like '%' + UPPER(@lV77Vinculartrnwwds_1_filterfulltext)))");
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
         }
         if ( ( StringUtil.StrCmp(AV78Vinculartrnwwds_2_dynamicfiltersselector1, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV79Vinculartrnwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV80Vinculartrnwwds_4_vinculartrnsolidicutd1) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] < @AV80Vinculartrnwwds_4_vinculartrnsolidicutd1)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Vinculartrnwwds_2_dynamicfiltersselector1, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV79Vinculartrnwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV80Vinculartrnwwds_4_vinculartrnsolidicutd1) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] = @AV80Vinculartrnwwds_4_vinculartrnsolidicutd1)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Vinculartrnwwds_2_dynamicfiltersselector1, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV79Vinculartrnwwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV80Vinculartrnwwds_4_vinculartrnsolidicutd1) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] > @AV80Vinculartrnwwds_4_vinculartrnsolidicutd1)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Vinculartrnwwds_2_dynamicfiltersselector1, "PROVEEDORNOMBRE") == 0 ) && ( AV79Vinculartrnwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Vinculartrnwwds_5_proveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV81Vinculartrnwwds_5_proveedornombre1))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Vinculartrnwwds_2_dynamicfiltersselector1, "PROVEEDORNOMBRE") == 0 ) && ( AV79Vinculartrnwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Vinculartrnwwds_5_proveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV81Vinculartrnwwds_5_proveedornombre1))");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( AV82Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV83Vinculartrnwwds_7_dynamicfiltersselector2, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV84Vinculartrnwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV85Vinculartrnwwds_9_vinculartrnsolidicutd2) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] < @AV85Vinculartrnwwds_9_vinculartrnsolidicutd2)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( AV82Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV83Vinculartrnwwds_7_dynamicfiltersselector2, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV84Vinculartrnwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV85Vinculartrnwwds_9_vinculartrnsolidicutd2) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] = @AV85Vinculartrnwwds_9_vinculartrnsolidicutd2)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( AV82Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV83Vinculartrnwwds_7_dynamicfiltersselector2, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV84Vinculartrnwwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV85Vinculartrnwwds_9_vinculartrnsolidicutd2) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] > @AV85Vinculartrnwwds_9_vinculartrnsolidicutd2)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( AV82Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV83Vinculartrnwwds_7_dynamicfiltersselector2, "PROVEEDORNOMBRE") == 0 ) && ( AV84Vinculartrnwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Vinculartrnwwds_10_proveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV86Vinculartrnwwds_10_proveedornombre2))");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( AV82Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV83Vinculartrnwwds_7_dynamicfiltersselector2, "PROVEEDORNOMBRE") == 0 ) && ( AV84Vinculartrnwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Vinculartrnwwds_10_proveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV86Vinculartrnwwds_10_proveedornombre2))");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( AV87Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Vinculartrnwwds_12_dynamicfiltersselector3, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV89Vinculartrnwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV90Vinculartrnwwds_14_vinculartrnsolidicutd3) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] < @AV90Vinculartrnwwds_14_vinculartrnsolidicutd3)");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( AV87Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Vinculartrnwwds_12_dynamicfiltersselector3, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV89Vinculartrnwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV90Vinculartrnwwds_14_vinculartrnsolidicutd3) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] = @AV90Vinculartrnwwds_14_vinculartrnsolidicutd3)");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( AV87Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Vinculartrnwwds_12_dynamicfiltersselector3, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV89Vinculartrnwwds_13_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV90Vinculartrnwwds_14_vinculartrnsolidicutd3) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] > @AV90Vinculartrnwwds_14_vinculartrnsolidicutd3)");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( AV87Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Vinculartrnwwds_12_dynamicfiltersselector3, "PROVEEDORNOMBRE") == 0 ) && ( AV89Vinculartrnwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Vinculartrnwwds_15_proveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV91Vinculartrnwwds_15_proveedornombre3))");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( AV87Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Vinculartrnwwds_12_dynamicfiltersselector3, "PROVEEDORNOMBRE") == 0 ) && ( AV89Vinculartrnwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Vinculartrnwwds_15_proveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV91Vinculartrnwwds_15_proveedornombre3))");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( ! (0==AV92Vinculartrnwwds_16_tfvinculartrnid) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnId] >= @AV92Vinculartrnwwds_16_tfvinculartrnid)");
         }
         else
         {
            GXv_int2[23] = 1;
         }
         if ( ! (0==AV93Vinculartrnwwds_17_tfvinculartrnid_to) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnId] <= @AV93Vinculartrnwwds_17_tfvinculartrnid_to)");
         }
         else
         {
            GXv_int2[24] = 1;
         }
         if ( ! (0==AV94Vinculartrnwwds_18_tfproveedorid) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV94Vinculartrnwwds_18_tfproveedorid)");
         }
         else
         {
            GXv_int2[25] = 1;
         }
         if ( ! (0==AV95Vinculartrnwwds_19_tfproveedorid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] <= @AV95Vinculartrnwwds_19_tfproveedorid_to)");
         }
         else
         {
            GXv_int2[26] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV97Vinculartrnwwds_21_tfproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Vinculartrnwwds_20_tfproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV96Vinculartrnwwds_20_tfproveedornombre))");
         }
         else
         {
            GXv_int2[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Vinculartrnwwds_21_tfproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV97Vinculartrnwwds_21_tfproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedorNombre] = @AV97Vinculartrnwwds_21_tfproveedornombre_sel)");
         }
         else
         {
            GXv_int2[28] = 1;
         }
         if ( StringUtil.StrCmp(AV97Vinculartrnwwds_21_tfproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProveedorNombre] = ''))");
         }
         if ( ! (0==AV98Vinculartrnwwds_22_tfvinculartrnsolidicutd) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] >= @AV98Vinculartrnwwds_22_tfvinculartrnsolidicutd)");
         }
         else
         {
            GXv_int2[29] = 1;
         }
         if ( ! (0==AV99Vinculartrnwwds_23_tfvinculartrnsolidicutd_to) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] <= @AV99Vinculartrnwwds_23_tfvinculartrnsolidicutd_to)");
         }
         else
         {
            GXv_int2[30] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Vinculartrnwwds_25_tfvinculartrnnombresol_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Vinculartrnwwds_24_tfvinculartrnnombresol)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[VincularTrnNombreSol]) like UPPER(@lV100Vinculartrnwwds_24_tfvinculartrnnombresol))");
         }
         else
         {
            GXv_int2[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Vinculartrnwwds_25_tfvinculartrnnombresol_sel)) && ! ( StringUtil.StrCmp(AV101Vinculartrnwwds_25_tfvinculartrnnombresol_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnNombreSol] = @AV101Vinculartrnwwds_25_tfvinculartrnnombresol_sel)");
         }
         else
         {
            GXv_int2[32] = 1;
         }
         if ( StringUtil.StrCmp(AV101Vinculartrnwwds_25_tfvinculartrnnombresol_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[VincularTrnNombreSol] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV103Vinculartrnwwds_27_tfvinculartrntelefonosol_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Vinculartrnwwds_26_tfvinculartrntelefonosol)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[VincularTrnTelefonoSol]) like UPPER(@lV102Vinculartrnwwds_26_tfvinculartrntelefonosol))");
         }
         else
         {
            GXv_int2[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Vinculartrnwwds_27_tfvinculartrntelefonosol_sel)) && ! ( StringUtil.StrCmp(AV103Vinculartrnwwds_27_tfvinculartrntelefonosol_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnTelefonoSol] = @AV103Vinculartrnwwds_27_tfvinculartrntelefonosol_sel)");
         }
         else
         {
            GXv_int2[34] = 1;
         }
         if ( StringUtil.StrCmp(AV103Vinculartrnwwds_27_tfvinculartrntelefonosol_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[VincularTrnTelefonoSol] = ''))");
         }
         if ( ! (0==AV104Vinculartrnwwds_28_tfdocumentacionid) )
         {
            AddWhere(sWhereString, "(T2.[DocumentacionId] >= @AV104Vinculartrnwwds_28_tfdocumentacionid)");
         }
         else
         {
            GXv_int2[35] = 1;
         }
         if ( ! (0==AV105Vinculartrnwwds_29_tfdocumentacionid_to) )
         {
            AddWhere(sWhereString, "(T2.[DocumentacionId] <= @AV105Vinculartrnwwds_29_tfdocumentacionid_to)");
         }
         else
         {
            GXv_int2[36] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV107Vinculartrnwwds_31_tfvinculartrncomentario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Vinculartrnwwds_30_tfvinculartrncomentario)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[VincularTrnComentario]) like UPPER(@lV106Vinculartrnwwds_30_tfvinculartrncomentario))");
         }
         else
         {
            GXv_int2[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Vinculartrnwwds_31_tfvinculartrncomentario_sel)) && ! ( StringUtil.StrCmp(AV107Vinculartrnwwds_31_tfvinculartrncomentario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnComentario] = @AV107Vinculartrnwwds_31_tfvinculartrncomentario_sel)");
         }
         else
         {
            GXv_int2[38] = 1;
         }
         if ( StringUtil.StrCmp(AV107Vinculartrnwwds_31_tfvinculartrncomentario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[VincularTrnComentario])=0))");
         }
         if ( ! (DateTime.MinValue==AV108Vinculartrnwwds_32_tfvinculartrnfecha) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnFecha] >= @AV108Vinculartrnwwds_32_tfvinculartrnfecha)");
         }
         else
         {
            GXv_int2[39] = 1;
         }
         if ( ! (DateTime.MinValue==AV109Vinculartrnwwds_33_tfvinculartrnfecha_to) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnFecha] <= @AV109Vinculartrnwwds_33_tfvinculartrnfecha_to)");
         }
         else
         {
            GXv_int2[40] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[VincularTrnSolidicutd]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[VincularTrnSolidicutd] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[VincularTrnId]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[VincularTrnId] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProveedorID]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProveedorID] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ProveedorNombre]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ProveedorNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[VincularTrnNombreSol]";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[VincularTrnNombreSol] DESC";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[VincularTrnTelefonoSol]";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[VincularTrnTelefonoSol] DESC";
         }
         else if ( ( AV11OrderedBy == 7 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[DocumentacionId]";
         }
         else if ( ( AV11OrderedBy == 7 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[DocumentacionId] DESC";
         }
         else if ( ( AV11OrderedBy == 8 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[VincularTrnComentario]";
         }
         else if ( ( AV11OrderedBy == 8 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[VincularTrnComentario] DESC";
         }
         else if ( ( AV11OrderedBy == 9 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[VincularTrnFecha]";
         }
         else if ( ( AV11OrderedBy == 9 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[VincularTrnFecha] DESC";
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
                     return conditional_P006D2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (long)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] , (long)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (long)dynConstraints[33] , (long)dynConstraints[34] , (string)dynConstraints[35] , (long)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (long)dynConstraints[39] , (string)dynConstraints[40] , (DateTime)dynConstraints[41] , (short)dynConstraints[42] , (bool)dynConstraints[43] );
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
          Object[] prmP006D2;
          prmP006D2 = new Object[] {
          new ParDef("@lV77Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV77Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV77Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV77Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV77Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV77Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV77Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV77Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV80Vinculartrnwwds_4_vinculartrnsolidicutd1",GXType.Decimal,18,0) ,
          new ParDef("@AV80Vinculartrnwwds_4_vinculartrnsolidicutd1",GXType.Decimal,18,0) ,
          new ParDef("@AV80Vinculartrnwwds_4_vinculartrnsolidicutd1",GXType.Decimal,18,0) ,
          new ParDef("@lV81Vinculartrnwwds_5_proveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV81Vinculartrnwwds_5_proveedornombre1",GXType.Char,80,0) ,
          new ParDef("@AV85Vinculartrnwwds_9_vinculartrnsolidicutd2",GXType.Decimal,18,0) ,
          new ParDef("@AV85Vinculartrnwwds_9_vinculartrnsolidicutd2",GXType.Decimal,18,0) ,
          new ParDef("@AV85Vinculartrnwwds_9_vinculartrnsolidicutd2",GXType.Decimal,18,0) ,
          new ParDef("@lV86Vinculartrnwwds_10_proveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV86Vinculartrnwwds_10_proveedornombre2",GXType.Char,80,0) ,
          new ParDef("@AV90Vinculartrnwwds_14_vinculartrnsolidicutd3",GXType.Decimal,18,0) ,
          new ParDef("@AV90Vinculartrnwwds_14_vinculartrnsolidicutd3",GXType.Decimal,18,0) ,
          new ParDef("@AV90Vinculartrnwwds_14_vinculartrnsolidicutd3",GXType.Decimal,18,0) ,
          new ParDef("@lV91Vinculartrnwwds_15_proveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV91Vinculartrnwwds_15_proveedornombre3",GXType.Char,80,0) ,
          new ParDef("@AV92Vinculartrnwwds_16_tfvinculartrnid",GXType.Decimal,18,0) ,
          new ParDef("@AV93Vinculartrnwwds_17_tfvinculartrnid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV94Vinculartrnwwds_18_tfproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV95Vinculartrnwwds_19_tfproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV96Vinculartrnwwds_20_tfproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV97Vinculartrnwwds_21_tfproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV98Vinculartrnwwds_22_tfvinculartrnsolidicutd",GXType.Decimal,18,0) ,
          new ParDef("@AV99Vinculartrnwwds_23_tfvinculartrnsolidicutd_to",GXType.Decimal,18,0) ,
          new ParDef("@lV100Vinculartrnwwds_24_tfvinculartrnnombresol",GXType.Char,80,0) ,
          new ParDef("@AV101Vinculartrnwwds_25_tfvinculartrnnombresol_sel",GXType.NChar,80,0) ,
          new ParDef("@lV102Vinculartrnwwds_26_tfvinculartrntelefonosol",GXType.Char,20,0) ,
          new ParDef("@AV103Vinculartrnwwds_27_tfvinculartrntelefonosol_sel",GXType.NChar,20,0) ,
          new ParDef("@AV104Vinculartrnwwds_28_tfdocumentacionid",GXType.Decimal,18,0) ,
          new ParDef("@AV105Vinculartrnwwds_29_tfdocumentacionid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV106Vinculartrnwwds_30_tfvinculartrncomentario",GXType.VarChar,200,0) ,
          new ParDef("@AV107Vinculartrnwwds_31_tfvinculartrncomentario_sel",GXType.NVarChar,200,0) ,
          new ParDef("@AV108Vinculartrnwwds_32_tfvinculartrnfecha",GXType.Date,8,0) ,
          new ParDef("@AV109Vinculartrnwwds_33_tfvinculartrnfecha_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006D2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006D2,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((string[]) buf[5])[0] = rslt.getString(5, 80);
                ((string[]) buf[6])[0] = rslt.getString(6, 80);
                ((long[]) buf[7])[0] = rslt.getLong(7);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                ((long[]) buf[9])[0] = rslt.getLong(9);
                ((string[]) buf[10])[0] = rslt.getMultimediaUri(10);
                ((string[]) buf[11])[0] = rslt.getMultimediaUri(11);
                ((string[]) buf[12])[0] = rslt.getMultimediaFile(12, rslt.getVarchar(10));
                ((string[]) buf[13])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(11));
                return;
       }
    }

 }

}
