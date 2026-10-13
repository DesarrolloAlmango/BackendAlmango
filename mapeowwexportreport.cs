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
   public class mapeowwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public mapeowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public mapeowwexportreport( IGxContext context )
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
         setOutputFileName("MapeoWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMapeo", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV91Pgmname));
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
               AV65Title = context.GetMessage( "Lista de Mapeo", "");
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
            HKM0( true, 0) ;
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
            HKM0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 215, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 215, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( AV19GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV90GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV19GridState.gxTpr_Dynamicfilters.Item(1));
            AV67DynamicFiltersSelector1 = AV90GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV67DynamicFiltersSelector1, "STCOMERCIOSNOMBRE") == 0 )
            {
               AV68DynamicFiltersOperator1 = AV90GridStateDynamicFilter.gxTpr_Operator;
               AV69STComerciosNombre1 = AV90GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69STComerciosNombre1)) )
               {
                  if ( AV68DynamicFiltersOperator1 == 0 )
                  {
                     AV70FilterSTComerciosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV68DynamicFiltersOperator1 == 1 )
                  {
                     AV70FilterSTComerciosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV71STComerciosNombre = AV69STComerciosNombre1;
                  HKM0( false, 19) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70FilterSTComerciosNombreDescription, "")), 25, Gx_line+0, 215, Gx_line+14, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71STComerciosNombre, "")), 215, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
               }
            }
            else if ( StringUtil.StrCmp(AV67DynamicFiltersSelector1, "PROVEEDORNOMBRE") == 0 )
            {
               AV68DynamicFiltersOperator1 = AV90GridStateDynamicFilter.gxTpr_Operator;
               AV72ProveedorNombre1 = AV90GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72ProveedorNombre1)) )
               {
                  if ( AV68DynamicFiltersOperator1 == 0 )
                  {
                     AV73FilterProveedorNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV68DynamicFiltersOperator1 == 1 )
                  {
                     AV73FilterProveedorNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV74ProveedorNombre = AV72ProveedorNombre1;
                  HKM0( false, 19) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73FilterProveedorNombreDescription, "")), 25, Gx_line+0, 215, Gx_line+14, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74ProveedorNombre, "")), 215, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
               }
            }
            else if ( StringUtil.StrCmp(AV67DynamicFiltersSelector1, "CONEXIONESNOMBRE") == 0 )
            {
               AV68DynamicFiltersOperator1 = AV90GridStateDynamicFilter.gxTpr_Operator;
               AV75ConexionesNombre1 = AV90GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75ConexionesNombre1)) )
               {
                  if ( AV68DynamicFiltersOperator1 == 0 )
                  {
                     AV76FilterConexionesNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Conexiones Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV68DynamicFiltersOperator1 == 1 )
                  {
                     AV76FilterConexionesNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Conexiones Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV77ConexionesNombre = AV75ConexionesNombre1;
                  HKM0( false, 19) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV76FilterConexionesNombreDescription, "")), 25, Gx_line+0, 215, Gx_line+14, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV77ConexionesNombre, "")), 215, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
               }
            }
            if ( AV19GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV78DynamicFiltersEnabled2 = true;
               AV90GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV19GridState.gxTpr_Dynamicfilters.Item(2));
               AV79DynamicFiltersSelector2 = AV90GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV79DynamicFiltersSelector2, "STCOMERCIOSNOMBRE") == 0 )
               {
                  AV80DynamicFiltersOperator2 = AV90GridStateDynamicFilter.gxTpr_Operator;
                  AV81STComerciosNombre2 = AV90GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81STComerciosNombre2)) )
                  {
                     if ( AV80DynamicFiltersOperator2 == 0 )
                     {
                        AV70FilterSTComerciosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV80DynamicFiltersOperator2 == 1 )
                     {
                        AV70FilterSTComerciosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV71STComerciosNombre = AV81STComerciosNombre2;
                     HKM0( false, 19) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70FilterSTComerciosNombreDescription, "")), 25, Gx_line+0, 215, Gx_line+14, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71STComerciosNombre, "")), 215, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                  }
               }
               else if ( StringUtil.StrCmp(AV79DynamicFiltersSelector2, "PROVEEDORNOMBRE") == 0 )
               {
                  AV80DynamicFiltersOperator2 = AV90GridStateDynamicFilter.gxTpr_Operator;
                  AV82ProveedorNombre2 = AV90GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82ProveedorNombre2)) )
                  {
                     if ( AV80DynamicFiltersOperator2 == 0 )
                     {
                        AV73FilterProveedorNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV80DynamicFiltersOperator2 == 1 )
                     {
                        AV73FilterProveedorNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV74ProveedorNombre = AV82ProveedorNombre2;
                     HKM0( false, 19) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73FilterProveedorNombreDescription, "")), 25, Gx_line+0, 215, Gx_line+14, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74ProveedorNombre, "")), 215, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                  }
               }
               else if ( StringUtil.StrCmp(AV79DynamicFiltersSelector2, "CONEXIONESNOMBRE") == 0 )
               {
                  AV80DynamicFiltersOperator2 = AV90GridStateDynamicFilter.gxTpr_Operator;
                  AV83ConexionesNombre2 = AV90GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83ConexionesNombre2)) )
                  {
                     if ( AV80DynamicFiltersOperator2 == 0 )
                     {
                        AV76FilterConexionesNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Conexiones Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV80DynamicFiltersOperator2 == 1 )
                     {
                        AV76FilterConexionesNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Conexiones Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV77ConexionesNombre = AV83ConexionesNombre2;
                     HKM0( false, 19) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV76FilterConexionesNombreDescription, "")), 25, Gx_line+0, 215, Gx_line+14, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV77ConexionesNombre, "")), 215, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                  }
               }
               if ( AV19GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV84DynamicFiltersEnabled3 = true;
                  AV90GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV19GridState.gxTpr_Dynamicfilters.Item(3));
                  AV85DynamicFiltersSelector3 = AV90GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV85DynamicFiltersSelector3, "STCOMERCIOSNOMBRE") == 0 )
                  {
                     AV86DynamicFiltersOperator3 = AV90GridStateDynamicFilter.gxTpr_Operator;
                     AV87STComerciosNombre3 = AV90GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87STComerciosNombre3)) )
                     {
                        if ( AV86DynamicFiltersOperator3 == 0 )
                        {
                           AV70FilterSTComerciosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV86DynamicFiltersOperator3 == 1 )
                        {
                           AV70FilterSTComerciosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV71STComerciosNombre = AV87STComerciosNombre3;
                        HKM0( false, 19) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70FilterSTComerciosNombreDescription, "")), 25, Gx_line+0, 215, Gx_line+14, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71STComerciosNombre, "")), 215, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV85DynamicFiltersSelector3, "PROVEEDORNOMBRE") == 0 )
                  {
                     AV86DynamicFiltersOperator3 = AV90GridStateDynamicFilter.gxTpr_Operator;
                     AV88ProveedorNombre3 = AV90GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88ProveedorNombre3)) )
                     {
                        if ( AV86DynamicFiltersOperator3 == 0 )
                        {
                           AV73FilterProveedorNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV86DynamicFiltersOperator3 == 1 )
                        {
                           AV73FilterProveedorNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Proveedor Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV74ProveedorNombre = AV88ProveedorNombre3;
                        HKM0( false, 19) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73FilterProveedorNombreDescription, "")), 25, Gx_line+0, 215, Gx_line+14, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74ProveedorNombre, "")), 215, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV85DynamicFiltersSelector3, "CONEXIONESNOMBRE") == 0 )
                  {
                     AV86DynamicFiltersOperator3 = AV90GridStateDynamicFilter.gxTpr_Operator;
                     AV89ConexionesNombre3 = AV90GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89ConexionesNombre3)) )
                     {
                        if ( AV86DynamicFiltersOperator3 == 0 )
                        {
                           AV76FilterConexionesNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Conexiones Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV86DynamicFiltersOperator3 == 1 )
                        {
                           AV76FilterConexionesNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Conexiones Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV77ConexionesNombre = AV89ConexionesNombre3;
                        HKM0( false, 19) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV76FilterConexionesNombreDescription, "")), 25, Gx_line+0, 215, Gx_line+14, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV77ConexionesNombre, "")), 215, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV21TFMapeoID) && (0==AV22TFMapeoID_To) ) )
         {
            HKM0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Mapeo ID", ""), 25, Gx_line+0, 215, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV21TFMapeoID), "ZZZZZZZZZZZZZZZZZ9")), 215, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV47TFMapeoID_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Mapeo ID", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HKM0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47TFMapeoID_To_Description, "")), 25, Gx_line+0, 215, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV22TFMapeoID_To), "ZZZZZZZZZZZZZZZZZ9")), 215, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (0==AV23TFProveedorID) && (0==AV24TFProveedorID_To) ) )
         {
            HKM0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Código del Proveedor", ""), 25, Gx_line+0, 215, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV23TFProveedorID), "ZZZZZZZZZZZZZZZZZ9")), 215, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV48TFProveedorID_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Código del Proveedor", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HKM0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48TFProveedorID_To_Description, "")), 25, Gx_line+0, 215, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV24TFProveedorID_To), "ZZZZZZZZZZZZZZZZZ9")), 215, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFProveedorNombre_Sel)) )
         {
            AV53TempBoolean = (bool)(((StringUtil.StrCmp(AV26TFProveedorNombre_Sel, "<#Empty#>")==0)));
            AV26TFProveedorNombre_Sel = (AV53TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV26TFProveedorNombre_Sel);
            HKM0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 215, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26TFProveedorNombre_Sel, "")), 215, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV26TFProveedorNombre_Sel = (AV53TempBoolean ? "<#Empty#>" : AV26TFProveedorNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFProveedorNombre)) )
            {
               HKM0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 215, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25TFProveedorNombre, "")), 215, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         AV30TFProveedorEstado_Sels.FromJSonString(AV27TFProveedorEstado_SelsJson, null);
         if ( ! ( AV30TFProveedorEstado_Sels.Count == 0 ) )
         {
            AV54i = 1;
            AV94GXV1 = 1;
            while ( AV94GXV1 <= AV30TFProveedorEstado_Sels.Count )
            {
               AV29TFProveedorEstado_Sel = AV30TFProveedorEstado_Sels.GetString(AV94GXV1);
               if ( AV54i == 1 )
               {
                  AV28TFProveedorEstado_SelDscs = "";
               }
               else
               {
                  AV28TFProveedorEstado_SelDscs += ", ";
               }
               AV49FilterTFProveedorEstado_SelValueDescription = context.GetMessage( gxdomainestadoenum.getDescription(context,AV29TFProveedorEstado_Sel), "");
               AV28TFProveedorEstado_SelDscs += AV49FilterTFProveedorEstado_SelValueDescription;
               AV54i = (long)(AV54i+1);
               AV94GXV1 = (int)(AV94GXV1+1);
            }
            HKM0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 25, Gx_line+0, 215, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28TFProveedorEstado_SelDscs, "")), 215, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (0==AV31TFSTComerciosID) && (0==AV32TFSTComerciosID_To) ) )
         {
            HKM0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Comercio", ""), 25, Gx_line+0, 215, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31TFSTComerciosID), "ZZZZZZZZZZZZZZZZZ9")), 215, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV50TFSTComerciosID_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Comercio", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HKM0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50TFSTComerciosID_To_Description, "")), 25, Gx_line+0, 215, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV32TFSTComerciosID_To), "ZZZZZZZZZZZZZZZZZ9")), 215, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFSTComerciosNombre_Sel)) )
         {
            AV53TempBoolean = (bool)(((StringUtil.StrCmp(AV34TFSTComerciosNombre_Sel, "<#Empty#>")==0)));
            AV34TFSTComerciosNombre_Sel = (AV53TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV34TFSTComerciosNombre_Sel);
            HKM0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 215, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFSTComerciosNombre_Sel, "")), 215, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV34TFSTComerciosNombre_Sel = (AV53TempBoolean ? "<#Empty#>" : AV34TFSTComerciosNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFSTComerciosNombre)) )
            {
               HKM0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 215, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFSTComerciosNombre, "")), 215, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFConexionesID_Sel)) )
         {
            AV53TempBoolean = (bool)(((StringUtil.StrCmp(AV40TFConexionesID_Sel, "<#Empty#>")==0)));
            AV40TFConexionesID_Sel = (AV53TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV40TFConexionesID_Sel);
            HKM0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Código de Conexión", ""), 25, Gx_line+0, 215, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFConexionesID_Sel, "")), 215, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV40TFConexionesID_Sel = (AV53TempBoolean ? "<#Empty#>" : AV40TFConexionesID_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFConexionesID)) )
            {
               HKM0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Código de Conexión", ""), 25, Gx_line+0, 215, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFConexionesID, "")), 215, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TFConexionesNombre_Sel)) )
         {
            AV53TempBoolean = (bool)(((StringUtil.StrCmp(AV42TFConexionesNombre_Sel, "<#Empty#>")==0)));
            AV42TFConexionesNombre_Sel = (AV53TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV42TFConexionesNombre_Sel);
            HKM0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 215, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFConexionesNombre_Sel, "")), 215, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV42TFConexionesNombre_Sel = (AV53TempBoolean ? "<#Empty#>" : AV42TFConexionesNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41TFConexionesNombre)) )
            {
               HKM0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 215, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFConexionesNombre, "")), 215, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HKM0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HKM0( false, 36) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Mapeo ID", ""), 30, Gx_line+10, 90, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Código del Proveedor", ""), 94, Gx_line+10, 154, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 158, Gx_line+10, 279, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 283, Gx_line+10, 405, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Comercio", ""), 409, Gx_line+10, 470, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 474, Gx_line+10, 596, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Código de Conexión", ""), 600, Gx_line+10, 661, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 665, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV96Mapeowwds_1_filterfulltext = AV13FilterFullText;
         AV97Mapeowwds_2_dynamicfiltersselector1 = AV67DynamicFiltersSelector1;
         AV98Mapeowwds_3_dynamicfiltersoperator1 = AV68DynamicFiltersOperator1;
         AV99Mapeowwds_4_stcomerciosnombre1 = AV69STComerciosNombre1;
         AV100Mapeowwds_5_proveedornombre1 = AV72ProveedorNombre1;
         AV101Mapeowwds_6_conexionesnombre1 = AV75ConexionesNombre1;
         AV102Mapeowwds_7_dynamicfiltersenabled2 = AV78DynamicFiltersEnabled2;
         AV103Mapeowwds_8_dynamicfiltersselector2 = AV79DynamicFiltersSelector2;
         AV104Mapeowwds_9_dynamicfiltersoperator2 = AV80DynamicFiltersOperator2;
         AV105Mapeowwds_10_stcomerciosnombre2 = AV81STComerciosNombre2;
         AV106Mapeowwds_11_proveedornombre2 = AV82ProveedorNombre2;
         AV107Mapeowwds_12_conexionesnombre2 = AV83ConexionesNombre2;
         AV108Mapeowwds_13_dynamicfiltersenabled3 = AV84DynamicFiltersEnabled3;
         AV109Mapeowwds_14_dynamicfiltersselector3 = AV85DynamicFiltersSelector3;
         AV110Mapeowwds_15_dynamicfiltersoperator3 = AV86DynamicFiltersOperator3;
         AV111Mapeowwds_16_stcomerciosnombre3 = AV87STComerciosNombre3;
         AV112Mapeowwds_17_proveedornombre3 = AV88ProveedorNombre3;
         AV113Mapeowwds_18_conexionesnombre3 = AV89ConexionesNombre3;
         AV114Mapeowwds_19_tfmapeoid = AV21TFMapeoID;
         AV115Mapeowwds_20_tfmapeoid_to = AV22TFMapeoID_To;
         AV116Mapeowwds_21_tfproveedorid = AV23TFProveedorID;
         AV117Mapeowwds_22_tfproveedorid_to = AV24TFProveedorID_To;
         AV118Mapeowwds_23_tfproveedornombre = AV25TFProveedorNombre;
         AV119Mapeowwds_24_tfproveedornombre_sel = AV26TFProveedorNombre_Sel;
         AV120Mapeowwds_25_tfproveedorestado_sels = AV30TFProveedorEstado_Sels;
         AV121Mapeowwds_26_tfstcomerciosid = AV31TFSTComerciosID;
         AV122Mapeowwds_27_tfstcomerciosid_to = AV32TFSTComerciosID_To;
         AV123Mapeowwds_28_tfstcomerciosnombre = AV33TFSTComerciosNombre;
         AV124Mapeowwds_29_tfstcomerciosnombre_sel = AV34TFSTComerciosNombre_Sel;
         AV125Mapeowwds_30_tfconexionesid = AV39TFConexionesID;
         AV126Mapeowwds_31_tfconexionesid_sel = AV40TFConexionesID_Sel;
         AV127Mapeowwds_32_tfconexionesnombre = AV41TFConexionesNombre;
         AV128Mapeowwds_33_tfconexionesnombre_sel = AV42TFConexionesNombre_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A344ProveedorEstado ,
                                              AV120Mapeowwds_25_tfproveedorestado_sels ,
                                              AV97Mapeowwds_2_dynamicfiltersselector1 ,
                                              AV98Mapeowwds_3_dynamicfiltersoperator1 ,
                                              AV99Mapeowwds_4_stcomerciosnombre1 ,
                                              AV100Mapeowwds_5_proveedornombre1 ,
                                              AV101Mapeowwds_6_conexionesnombre1 ,
                                              AV102Mapeowwds_7_dynamicfiltersenabled2 ,
                                              AV103Mapeowwds_8_dynamicfiltersselector2 ,
                                              AV104Mapeowwds_9_dynamicfiltersoperator2 ,
                                              AV105Mapeowwds_10_stcomerciosnombre2 ,
                                              AV106Mapeowwds_11_proveedornombre2 ,
                                              AV107Mapeowwds_12_conexionesnombre2 ,
                                              AV108Mapeowwds_13_dynamicfiltersenabled3 ,
                                              AV109Mapeowwds_14_dynamicfiltersselector3 ,
                                              AV110Mapeowwds_15_dynamicfiltersoperator3 ,
                                              AV111Mapeowwds_16_stcomerciosnombre3 ,
                                              AV112Mapeowwds_17_proveedornombre3 ,
                                              AV113Mapeowwds_18_conexionesnombre3 ,
                                              AV114Mapeowwds_19_tfmapeoid ,
                                              AV115Mapeowwds_20_tfmapeoid_to ,
                                              AV116Mapeowwds_21_tfproveedorid ,
                                              AV117Mapeowwds_22_tfproveedorid_to ,
                                              AV119Mapeowwds_24_tfproveedornombre_sel ,
                                              AV118Mapeowwds_23_tfproveedornombre ,
                                              AV120Mapeowwds_25_tfproveedorestado_sels.Count ,
                                              AV121Mapeowwds_26_tfstcomerciosid ,
                                              AV122Mapeowwds_27_tfstcomerciosid_to ,
                                              AV124Mapeowwds_29_tfstcomerciosnombre_sel ,
                                              AV123Mapeowwds_28_tfstcomerciosnombre ,
                                              AV126Mapeowwds_31_tfconexionesid_sel ,
                                              AV125Mapeowwds_30_tfconexionesid ,
                                              AV128Mapeowwds_33_tfconexionesnombre_sel ,
                                              AV127Mapeowwds_32_tfconexionesnombre ,
                                              A923STComerciosNombre ,
                                              A282ProveedorNombre ,
                                              A556ConexionesNombre ,
                                              A918MapeoID ,
                                              A133ProveedorID ,
                                              A919STComerciosID ,
                                              A552ConexionesID ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              AV96Mapeowwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV99Mapeowwds_4_stcomerciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV99Mapeowwds_4_stcomerciosnombre1), 80, "%");
         lV99Mapeowwds_4_stcomerciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV99Mapeowwds_4_stcomerciosnombre1), 80, "%");
         lV100Mapeowwds_5_proveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV100Mapeowwds_5_proveedornombre1), 80, "%");
         lV100Mapeowwds_5_proveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV100Mapeowwds_5_proveedornombre1), 80, "%");
         lV101Mapeowwds_6_conexionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV101Mapeowwds_6_conexionesnombre1), 80, "%");
         lV101Mapeowwds_6_conexionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV101Mapeowwds_6_conexionesnombre1), 80, "%");
         lV105Mapeowwds_10_stcomerciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV105Mapeowwds_10_stcomerciosnombre2), 80, "%");
         lV105Mapeowwds_10_stcomerciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV105Mapeowwds_10_stcomerciosnombre2), 80, "%");
         lV106Mapeowwds_11_proveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV106Mapeowwds_11_proveedornombre2), 80, "%");
         lV106Mapeowwds_11_proveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV106Mapeowwds_11_proveedornombre2), 80, "%");
         lV107Mapeowwds_12_conexionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV107Mapeowwds_12_conexionesnombre2), 80, "%");
         lV107Mapeowwds_12_conexionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV107Mapeowwds_12_conexionesnombre2), 80, "%");
         lV111Mapeowwds_16_stcomerciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV111Mapeowwds_16_stcomerciosnombre3), 80, "%");
         lV111Mapeowwds_16_stcomerciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV111Mapeowwds_16_stcomerciosnombre3), 80, "%");
         lV112Mapeowwds_17_proveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV112Mapeowwds_17_proveedornombre3), 80, "%");
         lV112Mapeowwds_17_proveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV112Mapeowwds_17_proveedornombre3), 80, "%");
         lV113Mapeowwds_18_conexionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV113Mapeowwds_18_conexionesnombre3), 80, "%");
         lV113Mapeowwds_18_conexionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV113Mapeowwds_18_conexionesnombre3), 80, "%");
         lV118Mapeowwds_23_tfproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV118Mapeowwds_23_tfproveedornombre), 80, "%");
         lV123Mapeowwds_28_tfstcomerciosnombre = StringUtil.PadR( StringUtil.RTrim( AV123Mapeowwds_28_tfstcomerciosnombre), 80, "%");
         lV125Mapeowwds_30_tfconexionesid = StringUtil.PadR( StringUtil.RTrim( AV125Mapeowwds_30_tfconexionesid), 9, "%");
         lV127Mapeowwds_32_tfconexionesnombre = StringUtil.PadR( StringUtil.RTrim( AV127Mapeowwds_32_tfconexionesnombre), 80, "%");
         /* Using cursor P00KM2 */
         pr_default.execute(0, new Object[] {lV99Mapeowwds_4_stcomerciosnombre1, lV99Mapeowwds_4_stcomerciosnombre1, lV100Mapeowwds_5_proveedornombre1, lV100Mapeowwds_5_proveedornombre1, lV101Mapeowwds_6_conexionesnombre1, lV101Mapeowwds_6_conexionesnombre1, lV105Mapeowwds_10_stcomerciosnombre2, lV105Mapeowwds_10_stcomerciosnombre2, lV106Mapeowwds_11_proveedornombre2, lV106Mapeowwds_11_proveedornombre2, lV107Mapeowwds_12_conexionesnombre2, lV107Mapeowwds_12_conexionesnombre2, lV111Mapeowwds_16_stcomerciosnombre3, lV111Mapeowwds_16_stcomerciosnombre3, lV112Mapeowwds_17_proveedornombre3, lV112Mapeowwds_17_proveedornombre3, lV113Mapeowwds_18_conexionesnombre3, lV113Mapeowwds_18_conexionesnombre3, AV114Mapeowwds_19_tfmapeoid, AV115Mapeowwds_20_tfmapeoid_to, AV116Mapeowwds_21_tfproveedorid, AV117Mapeowwds_22_tfproveedorid_to, lV118Mapeowwds_23_tfproveedornombre, AV119Mapeowwds_24_tfproveedornombre_sel, AV121Mapeowwds_26_tfstcomerciosid, AV122Mapeowwds_27_tfstcomerciosid_to, lV123Mapeowwds_28_tfstcomerciosnombre, AV124Mapeowwds_29_tfstcomerciosnombre_sel, lV125Mapeowwds_30_tfconexionesid, AV126Mapeowwds_31_tfconexionesid_sel, lV127Mapeowwds_32_tfconexionesnombre, AV128Mapeowwds_33_tfconexionesnombre_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A556ConexionesNombre = P00KM2_A556ConexionesNombre[0];
            n556ConexionesNombre = P00KM2_n556ConexionesNombre[0];
            A552ConexionesID = P00KM2_A552ConexionesID[0];
            n552ConexionesID = P00KM2_n552ConexionesID[0];
            A923STComerciosNombre = P00KM2_A923STComerciosNombre[0];
            A919STComerciosID = P00KM2_A919STComerciosID[0];
            n919STComerciosID = P00KM2_n919STComerciosID[0];
            A282ProveedorNombre = P00KM2_A282ProveedorNombre[0];
            A133ProveedorID = P00KM2_A133ProveedorID[0];
            A918MapeoID = P00KM2_A918MapeoID[0];
            A344ProveedorEstado = P00KM2_A344ProveedorEstado[0];
            A556ConexionesNombre = P00KM2_A556ConexionesNombre[0];
            n556ConexionesNombre = P00KM2_n556ConexionesNombre[0];
            A923STComerciosNombre = P00KM2_A923STComerciosNombre[0];
            A282ProveedorNombre = P00KM2_A282ProveedorNombre[0];
            A344ProveedorEstado = P00KM2_A344ProveedorEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Mapeowwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A918MapeoID), 18, 0) , StringUtil.PadR( "%" + AV96Mapeowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV96Mapeowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV96Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV96Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A919STComerciosID), 18, 0) , StringUtil.PadR( "%" + AV96Mapeowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A923STComerciosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV96Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A552ConexionesID) , StringUtil.PadR( "%" + StringUtil.Upper( AV96Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A556ConexionesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV96Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV14ProveedorEstadoDescription = context.GetMessage( gxdomainestadoenum.getDescription(context,A344ProveedorEstado), "");
               /* Execute user subroutine: 'BEFOREPRINTLINE' */
               S144 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               HKM0( false, 35) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A918MapeoID), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 90, Gx_line+24, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9")), 94, Gx_line+10, 154, Gx_line+24, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A282ProveedorNombre, "")), 158, Gx_line+10, 279, Gx_line+24, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14ProveedorEstadoDescription, "")), 283, Gx_line+10, 405, Gx_line+24, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A919STComerciosID), "ZZZZZZZZZZZZZZZZZ9")), 409, Gx_line+10, 470, Gx_line+24, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A923STComerciosNombre, "")), 474, Gx_line+10, 596, Gx_line+24, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A552ConexionesID, "")), 600, Gx_line+10, 661, Gx_line+24, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A556ConexionesNombre, "")), 665, Gx_line+10, 787, Gx_line+24, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV17Session.Get("MapeoWWGridState"), "") == 0 )
         {
            AV19GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "MapeoWWGridState"), null, "", "");
         }
         else
         {
            AV19GridState.FromXml(AV17Session.Get("MapeoWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV19GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV19GridState.gxTpr_Ordereddsc;
         AV129GXV2 = 1;
         while ( AV129GXV2 <= AV19GridState.gxTpr_Filtervalues.Count )
         {
            AV20GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV19GridState.gxTpr_Filtervalues.Item(AV129GXV2));
            if ( StringUtil.StrCmp(AV20GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV20GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV20GridStateFilterValue.gxTpr_Name, "TFMAPEOID") == 0 )
            {
               AV21TFMapeoID = (long)(Math.Round(NumberUtil.Val( AV20GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV22TFMapeoID_To = (long)(Math.Round(NumberUtil.Val( AV20GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV20GridStateFilterValue.gxTpr_Name, "TFPROVEEDORID") == 0 )
            {
               AV23TFProveedorID = (long)(Math.Round(NumberUtil.Val( AV20GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV24TFProveedorID_To = (long)(Math.Round(NumberUtil.Val( AV20GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV20GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE") == 0 )
            {
               AV25TFProveedorNombre = AV20GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV20GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE_SEL") == 0 )
            {
               AV26TFProveedorNombre_Sel = AV20GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV20GridStateFilterValue.gxTpr_Name, "TFPROVEEDORESTADO_SEL") == 0 )
            {
               AV27TFProveedorEstado_SelsJson = AV20GridStateFilterValue.gxTpr_Value;
               AV30TFProveedorEstado_Sels.FromJSonString(AV27TFProveedorEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV20GridStateFilterValue.gxTpr_Name, "TFSTCOMERCIOSID") == 0 )
            {
               AV31TFSTComerciosID = (long)(Math.Round(NumberUtil.Val( AV20GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV32TFSTComerciosID_To = (long)(Math.Round(NumberUtil.Val( AV20GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV20GridStateFilterValue.gxTpr_Name, "TFSTCOMERCIOSNOMBRE") == 0 )
            {
               AV33TFSTComerciosNombre = AV20GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV20GridStateFilterValue.gxTpr_Name, "TFSTCOMERCIOSNOMBRE_SEL") == 0 )
            {
               AV34TFSTComerciosNombre_Sel = AV20GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV20GridStateFilterValue.gxTpr_Name, "TFCONEXIONESID") == 0 )
            {
               AV39TFConexionesID = AV20GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV20GridStateFilterValue.gxTpr_Name, "TFCONEXIONESID_SEL") == 0 )
            {
               AV40TFConexionesID_Sel = AV20GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV20GridStateFilterValue.gxTpr_Name, "TFCONEXIONESNOMBRE") == 0 )
            {
               AV41TFConexionesNombre = AV20GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV20GridStateFilterValue.gxTpr_Name, "TFCONEXIONESNOMBRE_SEL") == 0 )
            {
               AV42TFConexionesNombre_Sel = AV20GridStateFilterValue.gxTpr_Value;
            }
            AV129GXV2 = (int)(AV129GXV2+1);
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

      protected void HKM0( bool bFoot ,
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
         AV91Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV65Title = "";
         AV13FilterFullText = "";
         AV19GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV90GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV67DynamicFiltersSelector1 = "";
         AV69STComerciosNombre1 = "";
         AV70FilterSTComerciosNombreDescription = "";
         AV71STComerciosNombre = "";
         AV72ProveedorNombre1 = "";
         AV73FilterProveedorNombreDescription = "";
         AV74ProveedorNombre = "";
         AV75ConexionesNombre1 = "";
         AV76FilterConexionesNombreDescription = "";
         AV77ConexionesNombre = "";
         AV79DynamicFiltersSelector2 = "";
         AV81STComerciosNombre2 = "";
         AV82ProveedorNombre2 = "";
         AV83ConexionesNombre2 = "";
         AV85DynamicFiltersSelector3 = "";
         AV87STComerciosNombre3 = "";
         AV88ProveedorNombre3 = "";
         AV89ConexionesNombre3 = "";
         AV47TFMapeoID_To_Description = "";
         AV48TFProveedorID_To_Description = "";
         AV26TFProveedorNombre_Sel = "";
         AV25TFProveedorNombre = "";
         AV30TFProveedorEstado_Sels = new GxSimpleCollection<string>();
         AV27TFProveedorEstado_SelsJson = "";
         AV29TFProveedorEstado_Sel = "";
         AV28TFProveedorEstado_SelDscs = "";
         AV49FilterTFProveedorEstado_SelValueDescription = "";
         AV50TFSTComerciosID_To_Description = "";
         AV34TFSTComerciosNombre_Sel = "";
         AV33TFSTComerciosNombre = "";
         AV40TFConexionesID_Sel = "";
         AV39TFConexionesID = "";
         AV42TFConexionesNombre_Sel = "";
         AV41TFConexionesNombre = "";
         AV96Mapeowwds_1_filterfulltext = "";
         AV97Mapeowwds_2_dynamicfiltersselector1 = "";
         AV99Mapeowwds_4_stcomerciosnombre1 = "";
         AV100Mapeowwds_5_proveedornombre1 = "";
         AV101Mapeowwds_6_conexionesnombre1 = "";
         AV103Mapeowwds_8_dynamicfiltersselector2 = "";
         AV105Mapeowwds_10_stcomerciosnombre2 = "";
         AV106Mapeowwds_11_proveedornombre2 = "";
         AV107Mapeowwds_12_conexionesnombre2 = "";
         AV109Mapeowwds_14_dynamicfiltersselector3 = "";
         AV111Mapeowwds_16_stcomerciosnombre3 = "";
         AV112Mapeowwds_17_proveedornombre3 = "";
         AV113Mapeowwds_18_conexionesnombre3 = "";
         AV118Mapeowwds_23_tfproveedornombre = "";
         AV119Mapeowwds_24_tfproveedornombre_sel = "";
         AV120Mapeowwds_25_tfproveedorestado_sels = new GxSimpleCollection<string>();
         AV123Mapeowwds_28_tfstcomerciosnombre = "";
         AV124Mapeowwds_29_tfstcomerciosnombre_sel = "";
         AV125Mapeowwds_30_tfconexionesid = "";
         AV126Mapeowwds_31_tfconexionesid_sel = "";
         AV127Mapeowwds_32_tfconexionesnombre = "";
         AV128Mapeowwds_33_tfconexionesnombre_sel = "";
         lV96Mapeowwds_1_filterfulltext = "";
         lV99Mapeowwds_4_stcomerciosnombre1 = "";
         lV100Mapeowwds_5_proveedornombre1 = "";
         lV101Mapeowwds_6_conexionesnombre1 = "";
         lV105Mapeowwds_10_stcomerciosnombre2 = "";
         lV106Mapeowwds_11_proveedornombre2 = "";
         lV107Mapeowwds_12_conexionesnombre2 = "";
         lV111Mapeowwds_16_stcomerciosnombre3 = "";
         lV112Mapeowwds_17_proveedornombre3 = "";
         lV113Mapeowwds_18_conexionesnombre3 = "";
         lV118Mapeowwds_23_tfproveedornombre = "";
         lV123Mapeowwds_28_tfstcomerciosnombre = "";
         lV125Mapeowwds_30_tfconexionesid = "";
         lV127Mapeowwds_32_tfconexionesnombre = "";
         A344ProveedorEstado = "";
         A923STComerciosNombre = "";
         A282ProveedorNombre = "";
         A556ConexionesNombre = "";
         A552ConexionesID = "";
         P00KM2_A556ConexionesNombre = new string[] {""} ;
         P00KM2_n556ConexionesNombre = new bool[] {false} ;
         P00KM2_A552ConexionesID = new string[] {""} ;
         P00KM2_n552ConexionesID = new bool[] {false} ;
         P00KM2_A923STComerciosNombre = new string[] {""} ;
         P00KM2_A919STComerciosID = new long[1] ;
         P00KM2_n919STComerciosID = new bool[] {false} ;
         P00KM2_A282ProveedorNombre = new string[] {""} ;
         P00KM2_A133ProveedorID = new long[1] ;
         P00KM2_A918MapeoID = new long[1] ;
         P00KM2_A344ProveedorEstado = new string[] {""} ;
         AV14ProveedorEstadoDescription = "";
         AV17Session = context.GetSession();
         AV20GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.mapeowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00KM2_A556ConexionesNombre, P00KM2_n556ConexionesNombre, P00KM2_A552ConexionesID, P00KM2_n552ConexionesID, P00KM2_A923STComerciosNombre, P00KM2_A919STComerciosID, P00KM2_n919STComerciosID, P00KM2_A282ProveedorNombre, P00KM2_A133ProveedorID, P00KM2_A918MapeoID,
               P00KM2_A344ProveedorEstado
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV91Pgmname = "MapeoWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV91Pgmname = "MapeoWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV68DynamicFiltersOperator1 ;
      private short AV80DynamicFiltersOperator2 ;
      private short AV86DynamicFiltersOperator3 ;
      private short AV98Mapeowwds_3_dynamicfiltersoperator1 ;
      private short AV104Mapeowwds_9_dynamicfiltersoperator2 ;
      private short AV110Mapeowwds_15_dynamicfiltersoperator3 ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV94GXV1 ;
      private int AV120Mapeowwds_25_tfproveedorestado_sels_Count ;
      private int AV129GXV2 ;
      private long AV21TFMapeoID ;
      private long AV22TFMapeoID_To ;
      private long AV23TFProveedorID ;
      private long AV24TFProveedorID_To ;
      private long AV54i ;
      private long AV31TFSTComerciosID ;
      private long AV32TFSTComerciosID_To ;
      private long AV114Mapeowwds_19_tfmapeoid ;
      private long AV115Mapeowwds_20_tfmapeoid_to ;
      private long AV116Mapeowwds_21_tfproveedorid ;
      private long AV117Mapeowwds_22_tfproveedorid_to ;
      private long AV121Mapeowwds_26_tfstcomerciosid ;
      private long AV122Mapeowwds_27_tfstcomerciosid_to ;
      private long A918MapeoID ;
      private long A133ProveedorID ;
      private long A919STComerciosID ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV91Pgmname ;
      private string GXEncryptionTmp ;
      private string AV69STComerciosNombre1 ;
      private string AV71STComerciosNombre ;
      private string AV72ProveedorNombre1 ;
      private string AV74ProveedorNombre ;
      private string AV75ConexionesNombre1 ;
      private string AV77ConexionesNombre ;
      private string AV81STComerciosNombre2 ;
      private string AV82ProveedorNombre2 ;
      private string AV83ConexionesNombre2 ;
      private string AV87STComerciosNombre3 ;
      private string AV88ProveedorNombre3 ;
      private string AV89ConexionesNombre3 ;
      private string AV26TFProveedorNombre_Sel ;
      private string AV25TFProveedorNombre ;
      private string AV29TFProveedorEstado_Sel ;
      private string AV34TFSTComerciosNombre_Sel ;
      private string AV33TFSTComerciosNombre ;
      private string AV40TFConexionesID_Sel ;
      private string AV39TFConexionesID ;
      private string AV42TFConexionesNombre_Sel ;
      private string AV41TFConexionesNombre ;
      private string AV99Mapeowwds_4_stcomerciosnombre1 ;
      private string AV100Mapeowwds_5_proveedornombre1 ;
      private string AV101Mapeowwds_6_conexionesnombre1 ;
      private string AV105Mapeowwds_10_stcomerciosnombre2 ;
      private string AV106Mapeowwds_11_proveedornombre2 ;
      private string AV107Mapeowwds_12_conexionesnombre2 ;
      private string AV111Mapeowwds_16_stcomerciosnombre3 ;
      private string AV112Mapeowwds_17_proveedornombre3 ;
      private string AV113Mapeowwds_18_conexionesnombre3 ;
      private string AV118Mapeowwds_23_tfproveedornombre ;
      private string AV119Mapeowwds_24_tfproveedornombre_sel ;
      private string AV123Mapeowwds_28_tfstcomerciosnombre ;
      private string AV124Mapeowwds_29_tfstcomerciosnombre_sel ;
      private string AV125Mapeowwds_30_tfconexionesid ;
      private string AV126Mapeowwds_31_tfconexionesid_sel ;
      private string AV127Mapeowwds_32_tfconexionesnombre ;
      private string AV128Mapeowwds_33_tfconexionesnombre_sel ;
      private string lV99Mapeowwds_4_stcomerciosnombre1 ;
      private string lV100Mapeowwds_5_proveedornombre1 ;
      private string lV101Mapeowwds_6_conexionesnombre1 ;
      private string lV105Mapeowwds_10_stcomerciosnombre2 ;
      private string lV106Mapeowwds_11_proveedornombre2 ;
      private string lV107Mapeowwds_12_conexionesnombre2 ;
      private string lV111Mapeowwds_16_stcomerciosnombre3 ;
      private string lV112Mapeowwds_17_proveedornombre3 ;
      private string lV113Mapeowwds_18_conexionesnombre3 ;
      private string lV118Mapeowwds_23_tfproveedornombre ;
      private string lV123Mapeowwds_28_tfstcomerciosnombre ;
      private string lV125Mapeowwds_30_tfconexionesid ;
      private string lV127Mapeowwds_32_tfconexionesnombre ;
      private string A344ProveedorEstado ;
      private string A923STComerciosNombre ;
      private string A282ProveedorNombre ;
      private string A556ConexionesNombre ;
      private string A552ConexionesID ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV78DynamicFiltersEnabled2 ;
      private bool AV84DynamicFiltersEnabled3 ;
      private bool AV53TempBoolean ;
      private bool AV102Mapeowwds_7_dynamicfiltersenabled2 ;
      private bool AV108Mapeowwds_13_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private bool n556ConexionesNombre ;
      private bool n552ConexionesID ;
      private bool n919STComerciosID ;
      private string AV27TFProveedorEstado_SelsJson ;
      private string AV65Title ;
      private string AV13FilterFullText ;
      private string AV67DynamicFiltersSelector1 ;
      private string AV70FilterSTComerciosNombreDescription ;
      private string AV73FilterProveedorNombreDescription ;
      private string AV76FilterConexionesNombreDescription ;
      private string AV79DynamicFiltersSelector2 ;
      private string AV85DynamicFiltersSelector3 ;
      private string AV47TFMapeoID_To_Description ;
      private string AV48TFProveedorID_To_Description ;
      private string AV28TFProveedorEstado_SelDscs ;
      private string AV49FilterTFProveedorEstado_SelValueDescription ;
      private string AV50TFSTComerciosID_To_Description ;
      private string AV96Mapeowwds_1_filterfulltext ;
      private string AV97Mapeowwds_2_dynamicfiltersselector1 ;
      private string AV103Mapeowwds_8_dynamicfiltersselector2 ;
      private string AV109Mapeowwds_14_dynamicfiltersselector3 ;
      private string lV96Mapeowwds_1_filterfulltext ;
      private string AV14ProveedorEstadoDescription ;
      private string AV63PageInfo ;
      private string AV60DateInfo ;
      private string AV58AppName ;
      private string AV64Phone ;
      private string AV62Mail ;
      private string AV66Website ;
      private string AV55AddressLine1 ;
      private string AV56AddressLine2 ;
      private string AV57AddressLine3 ;
      private IGxSession AV17Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV19GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV90GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV30TFProveedorEstado_Sels ;
      private GxSimpleCollection<string> AV120Mapeowwds_25_tfproveedorestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00KM2_A556ConexionesNombre ;
      private bool[] P00KM2_n556ConexionesNombre ;
      private string[] P00KM2_A552ConexionesID ;
      private bool[] P00KM2_n552ConexionesID ;
      private string[] P00KM2_A923STComerciosNombre ;
      private long[] P00KM2_A919STComerciosID ;
      private bool[] P00KM2_n919STComerciosID ;
      private string[] P00KM2_A282ProveedorNombre ;
      private long[] P00KM2_A133ProveedorID ;
      private long[] P00KM2_A918MapeoID ;
      private string[] P00KM2_A344ProveedorEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV20GridStateFilterValue ;
   }

   public class mapeowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00KM2( IGxContext context ,
                                             string A344ProveedorEstado ,
                                             GxSimpleCollection<string> AV120Mapeowwds_25_tfproveedorestado_sels ,
                                             string AV97Mapeowwds_2_dynamicfiltersselector1 ,
                                             short AV98Mapeowwds_3_dynamicfiltersoperator1 ,
                                             string AV99Mapeowwds_4_stcomerciosnombre1 ,
                                             string AV100Mapeowwds_5_proveedornombre1 ,
                                             string AV101Mapeowwds_6_conexionesnombre1 ,
                                             bool AV102Mapeowwds_7_dynamicfiltersenabled2 ,
                                             string AV103Mapeowwds_8_dynamicfiltersselector2 ,
                                             short AV104Mapeowwds_9_dynamicfiltersoperator2 ,
                                             string AV105Mapeowwds_10_stcomerciosnombre2 ,
                                             string AV106Mapeowwds_11_proveedornombre2 ,
                                             string AV107Mapeowwds_12_conexionesnombre2 ,
                                             bool AV108Mapeowwds_13_dynamicfiltersenabled3 ,
                                             string AV109Mapeowwds_14_dynamicfiltersselector3 ,
                                             short AV110Mapeowwds_15_dynamicfiltersoperator3 ,
                                             string AV111Mapeowwds_16_stcomerciosnombre3 ,
                                             string AV112Mapeowwds_17_proveedornombre3 ,
                                             string AV113Mapeowwds_18_conexionesnombre3 ,
                                             long AV114Mapeowwds_19_tfmapeoid ,
                                             long AV115Mapeowwds_20_tfmapeoid_to ,
                                             long AV116Mapeowwds_21_tfproveedorid ,
                                             long AV117Mapeowwds_22_tfproveedorid_to ,
                                             string AV119Mapeowwds_24_tfproveedornombre_sel ,
                                             string AV118Mapeowwds_23_tfproveedornombre ,
                                             int AV120Mapeowwds_25_tfproveedorestado_sels_Count ,
                                             long AV121Mapeowwds_26_tfstcomerciosid ,
                                             long AV122Mapeowwds_27_tfstcomerciosid_to ,
                                             string AV124Mapeowwds_29_tfstcomerciosnombre_sel ,
                                             string AV123Mapeowwds_28_tfstcomerciosnombre ,
                                             string AV126Mapeowwds_31_tfconexionesid_sel ,
                                             string AV125Mapeowwds_30_tfconexionesid ,
                                             string AV128Mapeowwds_33_tfconexionesnombre_sel ,
                                             string AV127Mapeowwds_32_tfconexionesnombre ,
                                             string A923STComerciosNombre ,
                                             string A282ProveedorNombre ,
                                             string A556ConexionesNombre ,
                                             long A918MapeoID ,
                                             long A133ProveedorID ,
                                             long A919STComerciosID ,
                                             string A552ConexionesID ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             string AV96Mapeowwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[32];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T2.[ConexionesNombre], T1.[ConexionesID], T3.[ProveedorNombre] AS STComerciosNombre, T1.[STComerciosID] AS STComerciosID, T4.[ProveedorNombre], T1.[ProveedorID], T1.[MapeoID], T4.[ProveedorEstado] FROM ((([ListaMapeo] T1 LEFT JOIN [Conexiones] T2 ON T2.[ConexionesID] = T1.[ConexionesID]) LEFT JOIN [Proveedor] T3 ON T3.[ProveedorID] = T1.[STComerciosID]) INNER JOIN [Proveedor] T4 ON T4.[ProveedorID] = T1.[ProveedorID])";
         if ( ( StringUtil.StrCmp(AV97Mapeowwds_2_dynamicfiltersselector1, "STCOMERCIOSNOMBRE") == 0 ) && ( AV98Mapeowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Mapeowwds_4_stcomerciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV99Mapeowwds_4_stcomerciosnombre1))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Mapeowwds_2_dynamicfiltersselector1, "STCOMERCIOSNOMBRE") == 0 ) && ( AV98Mapeowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Mapeowwds_4_stcomerciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV99Mapeowwds_4_stcomerciosnombre1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Mapeowwds_2_dynamicfiltersselector1, "PROVEEDORNOMBRE") == 0 ) && ( AV98Mapeowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Mapeowwds_5_proveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like UPPER(@lV100Mapeowwds_5_proveedornombre1))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Mapeowwds_2_dynamicfiltersselector1, "PROVEEDORNOMBRE") == 0 ) && ( AV98Mapeowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Mapeowwds_5_proveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like '%' + UPPER(@lV100Mapeowwds_5_proveedornombre1))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Mapeowwds_2_dynamicfiltersselector1, "CONEXIONESNOMBRE") == 0 ) && ( AV98Mapeowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Mapeowwds_6_conexionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like UPPER(@lV101Mapeowwds_6_conexionesnombre1))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV97Mapeowwds_2_dynamicfiltersselector1, "CONEXIONESNOMBRE") == 0 ) && ( AV98Mapeowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Mapeowwds_6_conexionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like '%' + UPPER(@lV101Mapeowwds_6_conexionesnombre1))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV102Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Mapeowwds_8_dynamicfiltersselector2, "STCOMERCIOSNOMBRE") == 0 ) && ( AV104Mapeowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Mapeowwds_10_stcomerciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV105Mapeowwds_10_stcomerciosnombre2))");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV102Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Mapeowwds_8_dynamicfiltersselector2, "STCOMERCIOSNOMBRE") == 0 ) && ( AV104Mapeowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Mapeowwds_10_stcomerciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV105Mapeowwds_10_stcomerciosnombre2))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( AV102Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Mapeowwds_8_dynamicfiltersselector2, "PROVEEDORNOMBRE") == 0 ) && ( AV104Mapeowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Mapeowwds_11_proveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like UPPER(@lV106Mapeowwds_11_proveedornombre2))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( AV102Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Mapeowwds_8_dynamicfiltersselector2, "PROVEEDORNOMBRE") == 0 ) && ( AV104Mapeowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Mapeowwds_11_proveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like '%' + UPPER(@lV106Mapeowwds_11_proveedornombre2))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( AV102Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Mapeowwds_8_dynamicfiltersselector2, "CONEXIONESNOMBRE") == 0 ) && ( AV104Mapeowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Mapeowwds_12_conexionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like UPPER(@lV107Mapeowwds_12_conexionesnombre2))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( AV102Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV103Mapeowwds_8_dynamicfiltersselector2, "CONEXIONESNOMBRE") == 0 ) && ( AV104Mapeowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Mapeowwds_12_conexionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like '%' + UPPER(@lV107Mapeowwds_12_conexionesnombre2))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( AV108Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV109Mapeowwds_14_dynamicfiltersselector3, "STCOMERCIOSNOMBRE") == 0 ) && ( AV110Mapeowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Mapeowwds_16_stcomerciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV111Mapeowwds_16_stcomerciosnombre3))");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( AV108Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV109Mapeowwds_14_dynamicfiltersselector3, "STCOMERCIOSNOMBRE") == 0 ) && ( AV110Mapeowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Mapeowwds_16_stcomerciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV111Mapeowwds_16_stcomerciosnombre3))");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( AV108Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV109Mapeowwds_14_dynamicfiltersselector3, "PROVEEDORNOMBRE") == 0 ) && ( AV110Mapeowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Mapeowwds_17_proveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like UPPER(@lV112Mapeowwds_17_proveedornombre3))");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( AV108Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV109Mapeowwds_14_dynamicfiltersselector3, "PROVEEDORNOMBRE") == 0 ) && ( AV110Mapeowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Mapeowwds_17_proveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like '%' + UPPER(@lV112Mapeowwds_17_proveedornombre3))");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( AV108Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV109Mapeowwds_14_dynamicfiltersselector3, "CONEXIONESNOMBRE") == 0 ) && ( AV110Mapeowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Mapeowwds_18_conexionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like UPPER(@lV113Mapeowwds_18_conexionesnombre3))");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( AV108Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV109Mapeowwds_14_dynamicfiltersselector3, "CONEXIONESNOMBRE") == 0 ) && ( AV110Mapeowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Mapeowwds_18_conexionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like '%' + UPPER(@lV113Mapeowwds_18_conexionesnombre3))");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( ! (0==AV114Mapeowwds_19_tfmapeoid) )
         {
            AddWhere(sWhereString, "(T1.[MapeoID] >= @AV114Mapeowwds_19_tfmapeoid)");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( ! (0==AV115Mapeowwds_20_tfmapeoid_to) )
         {
            AddWhere(sWhereString, "(T1.[MapeoID] <= @AV115Mapeowwds_20_tfmapeoid_to)");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( ! (0==AV116Mapeowwds_21_tfproveedorid) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV116Mapeowwds_21_tfproveedorid)");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( ! (0==AV117Mapeowwds_22_tfproveedorid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] <= @AV117Mapeowwds_22_tfproveedorid_to)");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV119Mapeowwds_24_tfproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Mapeowwds_23_tfproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like UPPER(@lV118Mapeowwds_23_tfproveedornombre))");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Mapeowwds_24_tfproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV119Mapeowwds_24_tfproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[ProveedorNombre] = @AV119Mapeowwds_24_tfproveedornombre_sel)");
         }
         else
         {
            GXv_int2[23] = 1;
         }
         if ( StringUtil.StrCmp(AV119Mapeowwds_24_tfproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T4.[ProveedorNombre] = ''))");
         }
         if ( AV120Mapeowwds_25_tfproveedorestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV120Mapeowwds_25_tfproveedorestado_sels, "T4.[ProveedorEstado] IN (", ")")+")");
         }
         if ( ! (0==AV121Mapeowwds_26_tfstcomerciosid) )
         {
            AddWhere(sWhereString, "(T1.[STComerciosID] >= @AV121Mapeowwds_26_tfstcomerciosid)");
         }
         else
         {
            GXv_int2[24] = 1;
         }
         if ( ! (0==AV122Mapeowwds_27_tfstcomerciosid_to) )
         {
            AddWhere(sWhereString, "(T1.[STComerciosID] <= @AV122Mapeowwds_27_tfstcomerciosid_to)");
         }
         else
         {
            GXv_int2[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV124Mapeowwds_29_tfstcomerciosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Mapeowwds_28_tfstcomerciosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV123Mapeowwds_28_tfstcomerciosnombre))");
         }
         else
         {
            GXv_int2[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Mapeowwds_29_tfstcomerciosnombre_sel)) && ! ( StringUtil.StrCmp(AV124Mapeowwds_29_tfstcomerciosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProveedorNombre] = @AV124Mapeowwds_29_tfstcomerciosnombre_sel)");
         }
         else
         {
            GXv_int2[27] = 1;
         }
         if ( StringUtil.StrCmp(AV124Mapeowwds_29_tfstcomerciosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.[ProveedorNombre] IS NULL or (T3.[ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV126Mapeowwds_31_tfconexionesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Mapeowwds_30_tfconexionesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ConexionesID]) like UPPER(@lV125Mapeowwds_30_tfconexionesid))");
         }
         else
         {
            GXv_int2[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Mapeowwds_31_tfconexionesid_sel)) && ! ( StringUtil.StrCmp(AV126Mapeowwds_31_tfconexionesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ConexionesID] = @AV126Mapeowwds_31_tfconexionesid_sel)");
         }
         else
         {
            GXv_int2[29] = 1;
         }
         if ( StringUtil.StrCmp(AV126Mapeowwds_31_tfconexionesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ConexionesID] IS NULL or (T1.[ConexionesID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV128Mapeowwds_33_tfconexionesnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Mapeowwds_32_tfconexionesnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like UPPER(@lV127Mapeowwds_32_tfconexionesnombre))");
         }
         else
         {
            GXv_int2[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Mapeowwds_33_tfconexionesnombre_sel)) && ! ( StringUtil.StrCmp(AV128Mapeowwds_33_tfconexionesnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ConexionesNombre] = @AV128Mapeowwds_33_tfconexionesnombre_sel)");
         }
         else
         {
            GXv_int2[31] = 1;
         }
         if ( StringUtil.StrCmp(AV128Mapeowwds_33_tfconexionesnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ConexionesNombre] IS NULL or (T2.[ConexionesNombre] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MapeoID]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MapeoID] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ProveedorID]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ProveedorID] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.[ProveedorNombre]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.[ProveedorNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.[ProveedorEstado]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.[ProveedorEstado] DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[STComerciosID]";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[STComerciosID] DESC";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[ProveedorNombre]";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[ProveedorNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 7 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ConexionesID]";
         }
         else if ( ( AV11OrderedBy == 7 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ConexionesID] DESC";
         }
         else if ( ( AV11OrderedBy == 8 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[ConexionesNombre]";
         }
         else if ( ( AV11OrderedBy == 8 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[ConexionesNombre] DESC";
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
                     return conditional_P00KM2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (long)dynConstraints[26] , (long)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (long)dynConstraints[37] , (long)dynConstraints[38] , (long)dynConstraints[39] , (string)dynConstraints[40] , (short)dynConstraints[41] , (bool)dynConstraints[42] , (string)dynConstraints[43] );
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
          Object[] prmP00KM2;
          prmP00KM2 = new Object[] {
          new ParDef("@lV99Mapeowwds_4_stcomerciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV99Mapeowwds_4_stcomerciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV100Mapeowwds_5_proveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV100Mapeowwds_5_proveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV101Mapeowwds_6_conexionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV101Mapeowwds_6_conexionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV105Mapeowwds_10_stcomerciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV105Mapeowwds_10_stcomerciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV106Mapeowwds_11_proveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV106Mapeowwds_11_proveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV107Mapeowwds_12_conexionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV107Mapeowwds_12_conexionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV111Mapeowwds_16_stcomerciosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV111Mapeowwds_16_stcomerciosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV112Mapeowwds_17_proveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV112Mapeowwds_17_proveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV113Mapeowwds_18_conexionesnombre3",GXType.Char,80,0) ,
          new ParDef("@lV113Mapeowwds_18_conexionesnombre3",GXType.Char,80,0) ,
          new ParDef("@AV114Mapeowwds_19_tfmapeoid",GXType.Decimal,18,0) ,
          new ParDef("@AV115Mapeowwds_20_tfmapeoid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV116Mapeowwds_21_tfproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV117Mapeowwds_22_tfproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV118Mapeowwds_23_tfproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV119Mapeowwds_24_tfproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV121Mapeowwds_26_tfstcomerciosid",GXType.Decimal,18,0) ,
          new ParDef("@AV122Mapeowwds_27_tfstcomerciosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV123Mapeowwds_28_tfstcomerciosnombre",GXType.Char,80,0) ,
          new ParDef("@AV124Mapeowwds_29_tfstcomerciosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV125Mapeowwds_30_tfconexionesid",GXType.Char,9,0) ,
          new ParDef("@AV126Mapeowwds_31_tfconexionesid_sel",GXType.NChar,9,0) ,
          new ParDef("@lV127Mapeowwds_32_tfconexionesnombre",GXType.Char,80,0) ,
          new ParDef("@AV128Mapeowwds_33_tfconexionesnombre_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00KM2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00KM2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 9);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 80);
                ((long[]) buf[5])[0] = rslt.getLong(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getString(5, 80);
                ((long[]) buf[8])[0] = rslt.getLong(6);
                ((long[]) buf[9])[0] = rslt.getLong(7);
                ((string[]) buf[10])[0] = rslt.getString(8, 3);
                return;
       }
    }

 }

}
