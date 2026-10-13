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
   public class conexioneswwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public conexioneswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public conexioneswwexportreport( IGxContext context )
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
         setOutputFileName("ConexionesWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWConexiones", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV60Pgmname));
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
               AV58Title = context.GetMessage( "Lista de Conexiones", "");
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
            H760( true, 0) ;
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
            H760( false, 19) ;
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
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "CONEXIONESNOMBRE") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV27GridStateDynamicFilter.gxTpr_Operator;
               AV16ConexionesNombre1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16ConexionesNombre1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterConexionesNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterConexionesNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV18ConexionesNombre = AV16ConexionesNombre1;
                  H760( false, 19) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterConexionesNombreDescription, "")), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18ConexionesNombre, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
               }
            }
            if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV19DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CONEXIONESNOMBRE") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV27GridStateDynamicFilter.gxTpr_Operator;
                  AV22ConexionesNombre2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ConexionesNombre2)) )
                  {
                     if ( AV21DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterConexionesNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV21DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterConexionesNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV18ConexionesNombre = AV22ConexionesNombre2;
                     H760( false, 19) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterConexionesNombreDescription, "")), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18ConexionesNombre, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                  }
               }
               if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "CONEXIONESNOMBRE") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV27GridStateDynamicFilter.gxTpr_Operator;
                     AV26ConexionesNombre3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ConexionesNombre3)) )
                     {
                        if ( AV25DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterConexionesNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV25DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterConexionesNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV18ConexionesNombre = AV26ConexionesNombre3;
                        H760( false, 19) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterConexionesNombreDescription, "")), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18ConexionesNombre, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFConexionesID_Sel)) )
         {
            AV46TempBoolean = (bool)(((StringUtil.StrCmp(AV34TFConexionesID_Sel, "<#Empty#>")==0)));
            AV34TFConexionesID_Sel = (AV46TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV34TFConexionesID_Sel);
            H760( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Código de Conexión", ""), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFConexionesID_Sel, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV34TFConexionesID_Sel = (AV46TempBoolean ? "<#Empty#>" : AV34TFConexionesID_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFConexionesID)) )
            {
               H760( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Código de Conexión", ""), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFConexionesID, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFConexionesNombre_Sel)) )
         {
            AV46TempBoolean = (bool)(((StringUtil.StrCmp(AV36TFConexionesNombre_Sel, "<#Empty#>")==0)));
            AV36TFConexionesNombre_Sel = (AV46TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV36TFConexionesNombre_Sel);
            H760( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFConexionesNombre_Sel, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV36TFConexionesNombre_Sel = (AV46TempBoolean ? "<#Empty#>" : AV36TFConexionesNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFConexionesNombre)) )
            {
               H760( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFConexionesNombre, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFConexionesHost_Sel)) )
         {
            AV46TempBoolean = (bool)(((StringUtil.StrCmp(AV38TFConexionesHost_Sel, "<#Empty#>")==0)));
            AV38TFConexionesHost_Sel = (AV46TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV38TFConexionesHost_Sel);
            H760( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Host", ""), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFConexionesHost_Sel, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV38TFConexionesHost_Sel = (AV46TempBoolean ? "<#Empty#>" : AV38TFConexionesHost_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFConexionesHost)) )
            {
               H760( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Host", ""), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFConexionesHost, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFConexionesBaseURL_Sel)) )
         {
            AV46TempBoolean = (bool)(((StringUtil.StrCmp(AV40TFConexionesBaseURL_Sel, "<#Empty#>")==0)));
            AV40TFConexionesBaseURL_Sel = (AV46TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV40TFConexionesBaseURL_Sel);
            H760( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "URL", ""), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFConexionesBaseURL_Sel, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV40TFConexionesBaseURL_Sel = (AV46TempBoolean ? "<#Empty#>" : AV40TFConexionesBaseURL_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFConexionesBaseURL)) )
            {
               H760( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "URL", ""), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFConexionesBaseURL, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         AV43TFConexionesEstado_Sels.FromJSonString(AV41TFConexionesEstado_SelsJson, null);
         if ( ! ( AV43TFConexionesEstado_Sels.Count == 0 ) )
         {
            AV47i = 1;
            AV63GXV1 = 1;
            while ( AV63GXV1 <= AV43TFConexionesEstado_Sels.Count )
            {
               AV44TFConexionesEstado_Sel = AV43TFConexionesEstado_Sels.GetString(AV63GXV1);
               if ( AV47i == 1 )
               {
                  AV42TFConexionesEstado_SelDscs = "";
               }
               else
               {
                  AV42TFConexionesEstado_SelDscs += ", ";
               }
               AV45FilterTFConexionesEstado_SelValueDescription = context.GetMessage( gxdomainestadoenum.getDescription(context,AV44TFConexionesEstado_Sel), "");
               AV42TFConexionesEstado_SelDscs += AV45FilterTFConexionesEstado_SelValueDescription;
               AV47i = (long)(AV47i+1);
               AV63GXV1 = (int)(AV63GXV1+1);
            }
            H760( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 25, Gx_line+0, 153, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFConexionesEstado_SelDscs, "")), 153, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H760( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H760( false, 36) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Código de Conexión", ""), 30, Gx_line+10, 112, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 116, Gx_line+10, 280, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Host", ""), 284, Gx_line+10, 448, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "URL", ""), 452, Gx_line+10, 617, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 621, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV65Conexioneswwds_1_filterfulltext = AV13FilterFullText;
         AV66Conexioneswwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV67Conexioneswwds_3_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV68Conexioneswwds_4_conexionesnombre1 = AV16ConexionesNombre1;
         AV69Conexioneswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV70Conexioneswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV71Conexioneswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV72Conexioneswwds_8_conexionesnombre2 = AV22ConexionesNombre2;
         AV73Conexioneswwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV74Conexioneswwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV75Conexioneswwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV76Conexioneswwds_12_conexionesnombre3 = AV26ConexionesNombre3;
         AV77Conexioneswwds_13_tfconexionesid = AV33TFConexionesID;
         AV78Conexioneswwds_14_tfconexionesid_sel = AV34TFConexionesID_Sel;
         AV79Conexioneswwds_15_tfconexionesnombre = AV35TFConexionesNombre;
         AV80Conexioneswwds_16_tfconexionesnombre_sel = AV36TFConexionesNombre_Sel;
         AV81Conexioneswwds_17_tfconexioneshost = AV37TFConexionesHost;
         AV82Conexioneswwds_18_tfconexioneshost_sel = AV38TFConexionesHost_Sel;
         AV83Conexioneswwds_19_tfconexionesbaseurl = AV39TFConexionesBaseURL;
         AV84Conexioneswwds_20_tfconexionesbaseurl_sel = AV40TFConexionesBaseURL_Sel;
         AV85Conexioneswwds_21_tfconexionesestado_sels = AV43TFConexionesEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A562ConexionesEstado ,
                                              AV85Conexioneswwds_21_tfconexionesestado_sels ,
                                              AV66Conexioneswwds_2_dynamicfiltersselector1 ,
                                              AV67Conexioneswwds_3_dynamicfiltersoperator1 ,
                                              AV68Conexioneswwds_4_conexionesnombre1 ,
                                              AV69Conexioneswwds_5_dynamicfiltersenabled2 ,
                                              AV70Conexioneswwds_6_dynamicfiltersselector2 ,
                                              AV71Conexioneswwds_7_dynamicfiltersoperator2 ,
                                              AV72Conexioneswwds_8_conexionesnombre2 ,
                                              AV73Conexioneswwds_9_dynamicfiltersenabled3 ,
                                              AV74Conexioneswwds_10_dynamicfiltersselector3 ,
                                              AV75Conexioneswwds_11_dynamicfiltersoperator3 ,
                                              AV76Conexioneswwds_12_conexionesnombre3 ,
                                              AV78Conexioneswwds_14_tfconexionesid_sel ,
                                              AV77Conexioneswwds_13_tfconexionesid ,
                                              AV80Conexioneswwds_16_tfconexionesnombre_sel ,
                                              AV79Conexioneswwds_15_tfconexionesnombre ,
                                              AV82Conexioneswwds_18_tfconexioneshost_sel ,
                                              AV81Conexioneswwds_17_tfconexioneshost ,
                                              AV84Conexioneswwds_20_tfconexionesbaseurl_sel ,
                                              AV83Conexioneswwds_19_tfconexionesbaseurl ,
                                              AV85Conexioneswwds_21_tfconexionesestado_sels.Count ,
                                              A556ConexionesNombre ,
                                              A552ConexionesID ,
                                              A557ConexionesHost ,
                                              A558ConexionesBaseURL ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              AV65Conexioneswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV68Conexioneswwds_4_conexionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV68Conexioneswwds_4_conexionesnombre1), 80, "%");
         lV68Conexioneswwds_4_conexionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV68Conexioneswwds_4_conexionesnombre1), 80, "%");
         lV72Conexioneswwds_8_conexionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV72Conexioneswwds_8_conexionesnombre2), 80, "%");
         lV72Conexioneswwds_8_conexionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV72Conexioneswwds_8_conexionesnombre2), 80, "%");
         lV76Conexioneswwds_12_conexionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV76Conexioneswwds_12_conexionesnombre3), 80, "%");
         lV76Conexioneswwds_12_conexionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV76Conexioneswwds_12_conexionesnombre3), 80, "%");
         lV77Conexioneswwds_13_tfconexionesid = StringUtil.PadR( StringUtil.RTrim( AV77Conexioneswwds_13_tfconexionesid), 9, "%");
         lV79Conexioneswwds_15_tfconexionesnombre = StringUtil.PadR( StringUtil.RTrim( AV79Conexioneswwds_15_tfconexionesnombre), 80, "%");
         lV81Conexioneswwds_17_tfconexioneshost = StringUtil.PadR( StringUtil.RTrim( AV81Conexioneswwds_17_tfconexioneshost), 128, "%");
         lV83Conexioneswwds_19_tfconexionesbaseurl = StringUtil.PadR( StringUtil.RTrim( AV83Conexioneswwds_19_tfconexionesbaseurl), 128, "%");
         /* Using cursor P00762 */
         pr_default.execute(0, new Object[] {lV68Conexioneswwds_4_conexionesnombre1, lV68Conexioneswwds_4_conexionesnombre1, lV72Conexioneswwds_8_conexionesnombre2, lV72Conexioneswwds_8_conexionesnombre2, lV76Conexioneswwds_12_conexionesnombre3, lV76Conexioneswwds_12_conexionesnombre3, lV77Conexioneswwds_13_tfconexionesid, AV78Conexioneswwds_14_tfconexionesid_sel, lV79Conexioneswwds_15_tfconexionesnombre, AV80Conexioneswwds_16_tfconexionesnombre_sel, lV81Conexioneswwds_17_tfconexioneshost, AV82Conexioneswwds_18_tfconexioneshost_sel, lV83Conexioneswwds_19_tfconexionesbaseurl, AV84Conexioneswwds_20_tfconexionesbaseurl_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A558ConexionesBaseURL = P00762_A558ConexionesBaseURL[0];
            n558ConexionesBaseURL = P00762_n558ConexionesBaseURL[0];
            A557ConexionesHost = P00762_A557ConexionesHost[0];
            n557ConexionesHost = P00762_n557ConexionesHost[0];
            A556ConexionesNombre = P00762_A556ConexionesNombre[0];
            n556ConexionesNombre = P00762_n556ConexionesNombre[0];
            A552ConexionesID = P00762_A552ConexionesID[0];
            A562ConexionesEstado = P00762_A562ConexionesEstado[0];
            n562ConexionesEstado = P00762_n562ConexionesEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Conexioneswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Upper( A552ConexionesID) , StringUtil.PadR( "%" + StringUtil.Upper( AV65Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A556ConexionesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV65Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A557ConexionesHost) , StringUtil.PadR( "%" + StringUtil.Upper( AV65Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A558ConexionesBaseURL) , StringUtil.PadR( "%" + StringUtil.Upper( AV65Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV65Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A562ConexionesEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV65Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A562ConexionesEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV65Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A562ConexionesEstado, "PEN") == 0 ) ) ) )
            {
               AV28ConexionesEstadoDescription = context.GetMessage( gxdomainestadoenum.getDescription(context,A562ConexionesEstado), "");
               /* Execute user subroutine: 'BEFOREPRINTLINE' */
               S144 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               H760( false, 35) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A552ConexionesID, "")), 30, Gx_line+10, 112, Gx_line+24, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A556ConexionesNombre, "")), 116, Gx_line+10, 280, Gx_line+24, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A557ConexionesHost, "")), 284, Gx_line+10, 448, Gx_line+24, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A558ConexionesBaseURL, "")), 452, Gx_line+10, 617, Gx_line+24, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28ConexionesEstadoDescription, "")), 621, Gx_line+10, 787, Gx_line+24, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV29Session.Get("ConexionesWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ConexionesWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("ConexionesWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV31GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV31GridState.gxTpr_Ordereddsc;
         AV86GXV2 = 1;
         while ( AV86GXV2 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV86GXV2));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCONEXIONESID") == 0 )
            {
               AV33TFConexionesID = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCONEXIONESID_SEL") == 0 )
            {
               AV34TFConexionesID_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCONEXIONESNOMBRE") == 0 )
            {
               AV35TFConexionesNombre = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCONEXIONESNOMBRE_SEL") == 0 )
            {
               AV36TFConexionesNombre_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCONEXIONESHOST") == 0 )
            {
               AV37TFConexionesHost = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCONEXIONESHOST_SEL") == 0 )
            {
               AV38TFConexionesHost_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCONEXIONESBASEURL") == 0 )
            {
               AV39TFConexionesBaseURL = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCONEXIONESBASEURL_SEL") == 0 )
            {
               AV40TFConexionesBaseURL_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCONEXIONESESTADO_SEL") == 0 )
            {
               AV41TFConexionesEstado_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV43TFConexionesEstado_Sels.FromJSonString(AV41TFConexionesEstado_SelsJson, null);
            }
            AV86GXV2 = (int)(AV86GXV2+1);
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

      protected void H760( bool bFoot ,
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
                  AV56PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV53DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+39, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56PageInfo, "")), 30, Gx_line+15, 409, Gx_line+29, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53DateInfo, "")), 409, Gx_line+15, 789, Gx_line+29, 2, 0, 0, 0) ;
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
               AV51AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV57Phone = "+1 550 8923";
               AV55Mail = "info@mail.com";
               AV59Website = "http://www.web.com";
               AV48AddressLine1 = "French Boulevard 2859";
               AV49AddressLine2 = "Downtown";
               AV50AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+107, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51AppName, "")), 30, Gx_line+30, 283, Gx_line+44, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58Title, "")), 30, Gx_line+44, 283, Gx_line+77, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57Phone, "")), 283, Gx_line+30, 536, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55Mail, "")), 283, Gx_line+45, 536, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59Website, "")), 283, Gx_line+60, 536, Gx_line+77, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49AddressLine2, "")), 536, Gx_line+45, 789, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50AddressLine3, "")), 536, Gx_line+60, 789, Gx_line+77, 2, 0, 0, 0) ;
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
         AV60Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV58Title = "";
         AV13FilterFullText = "";
         AV31GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV16ConexionesNombre1 = "";
         AV17FilterConexionesNombreDescription = "";
         AV18ConexionesNombre = "";
         AV20DynamicFiltersSelector2 = "";
         AV22ConexionesNombre2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV26ConexionesNombre3 = "";
         AV34TFConexionesID_Sel = "";
         AV33TFConexionesID = "";
         AV36TFConexionesNombre_Sel = "";
         AV35TFConexionesNombre = "";
         AV38TFConexionesHost_Sel = "";
         AV37TFConexionesHost = "";
         AV40TFConexionesBaseURL_Sel = "";
         AV39TFConexionesBaseURL = "";
         AV43TFConexionesEstado_Sels = new GxSimpleCollection<string>();
         AV41TFConexionesEstado_SelsJson = "";
         AV44TFConexionesEstado_Sel = "";
         AV42TFConexionesEstado_SelDscs = "";
         AV45FilterTFConexionesEstado_SelValueDescription = "";
         AV65Conexioneswwds_1_filterfulltext = "";
         AV66Conexioneswwds_2_dynamicfiltersselector1 = "";
         AV68Conexioneswwds_4_conexionesnombre1 = "";
         AV70Conexioneswwds_6_dynamicfiltersselector2 = "";
         AV72Conexioneswwds_8_conexionesnombre2 = "";
         AV74Conexioneswwds_10_dynamicfiltersselector3 = "";
         AV76Conexioneswwds_12_conexionesnombre3 = "";
         AV77Conexioneswwds_13_tfconexionesid = "";
         AV78Conexioneswwds_14_tfconexionesid_sel = "";
         AV79Conexioneswwds_15_tfconexionesnombre = "";
         AV80Conexioneswwds_16_tfconexionesnombre_sel = "";
         AV81Conexioneswwds_17_tfconexioneshost = "";
         AV82Conexioneswwds_18_tfconexioneshost_sel = "";
         AV83Conexioneswwds_19_tfconexionesbaseurl = "";
         AV84Conexioneswwds_20_tfconexionesbaseurl_sel = "";
         AV85Conexioneswwds_21_tfconexionesestado_sels = new GxSimpleCollection<string>();
         lV68Conexioneswwds_4_conexionesnombre1 = "";
         lV72Conexioneswwds_8_conexionesnombre2 = "";
         lV76Conexioneswwds_12_conexionesnombre3 = "";
         lV77Conexioneswwds_13_tfconexionesid = "";
         lV79Conexioneswwds_15_tfconexionesnombre = "";
         lV81Conexioneswwds_17_tfconexioneshost = "";
         lV83Conexioneswwds_19_tfconexionesbaseurl = "";
         A562ConexionesEstado = "";
         A556ConexionesNombre = "";
         A552ConexionesID = "";
         A557ConexionesHost = "";
         A558ConexionesBaseURL = "";
         P00762_A558ConexionesBaseURL = new string[] {""} ;
         P00762_n558ConexionesBaseURL = new bool[] {false} ;
         P00762_A557ConexionesHost = new string[] {""} ;
         P00762_n557ConexionesHost = new bool[] {false} ;
         P00762_A556ConexionesNombre = new string[] {""} ;
         P00762_n556ConexionesNombre = new bool[] {false} ;
         P00762_A552ConexionesID = new string[] {""} ;
         P00762_A562ConexionesEstado = new string[] {""} ;
         P00762_n562ConexionesEstado = new bool[] {false} ;
         AV28ConexionesEstadoDescription = "";
         AV29Session = context.GetSession();
         AV32GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV56PageInfo = "";
         AV53DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV51AppName = "";
         AV57Phone = "";
         AV55Mail = "";
         AV59Website = "";
         AV48AddressLine1 = "";
         AV49AddressLine2 = "";
         AV50AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.conexioneswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00762_A558ConexionesBaseURL, P00762_n558ConexionesBaseURL, P00762_A557ConexionesHost, P00762_n557ConexionesHost, P00762_A556ConexionesNombre, P00762_n556ConexionesNombre, P00762_A552ConexionesID, P00762_A562ConexionesEstado, P00762_n562ConexionesEstado
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV60Pgmname = "ConexionesWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV60Pgmname = "ConexionesWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV15DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV25DynamicFiltersOperator3 ;
      private short AV67Conexioneswwds_3_dynamicfiltersoperator1 ;
      private short AV71Conexioneswwds_7_dynamicfiltersoperator2 ;
      private short AV75Conexioneswwds_11_dynamicfiltersoperator3 ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV63GXV1 ;
      private int AV85Conexioneswwds_21_tfconexionesestado_sels_Count ;
      private int AV86GXV2 ;
      private long AV47i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV60Pgmname ;
      private string GXEncryptionTmp ;
      private string AV16ConexionesNombre1 ;
      private string AV18ConexionesNombre ;
      private string AV22ConexionesNombre2 ;
      private string AV26ConexionesNombre3 ;
      private string AV34TFConexionesID_Sel ;
      private string AV33TFConexionesID ;
      private string AV36TFConexionesNombre_Sel ;
      private string AV35TFConexionesNombre ;
      private string AV38TFConexionesHost_Sel ;
      private string AV37TFConexionesHost ;
      private string AV40TFConexionesBaseURL_Sel ;
      private string AV39TFConexionesBaseURL ;
      private string AV44TFConexionesEstado_Sel ;
      private string AV68Conexioneswwds_4_conexionesnombre1 ;
      private string AV72Conexioneswwds_8_conexionesnombre2 ;
      private string AV76Conexioneswwds_12_conexionesnombre3 ;
      private string AV77Conexioneswwds_13_tfconexionesid ;
      private string AV78Conexioneswwds_14_tfconexionesid_sel ;
      private string AV79Conexioneswwds_15_tfconexionesnombre ;
      private string AV80Conexioneswwds_16_tfconexionesnombre_sel ;
      private string AV81Conexioneswwds_17_tfconexioneshost ;
      private string AV82Conexioneswwds_18_tfconexioneshost_sel ;
      private string AV83Conexioneswwds_19_tfconexionesbaseurl ;
      private string AV84Conexioneswwds_20_tfconexionesbaseurl_sel ;
      private string lV68Conexioneswwds_4_conexionesnombre1 ;
      private string lV72Conexioneswwds_8_conexionesnombre2 ;
      private string lV76Conexioneswwds_12_conexionesnombre3 ;
      private string lV77Conexioneswwds_13_tfconexionesid ;
      private string lV79Conexioneswwds_15_tfconexionesnombre ;
      private string lV81Conexioneswwds_17_tfconexioneshost ;
      private string lV83Conexioneswwds_19_tfconexionesbaseurl ;
      private string A562ConexionesEstado ;
      private string A556ConexionesNombre ;
      private string A552ConexionesID ;
      private string A557ConexionesHost ;
      private string A558ConexionesBaseURL ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV46TempBoolean ;
      private bool AV69Conexioneswwds_5_dynamicfiltersenabled2 ;
      private bool AV73Conexioneswwds_9_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private bool n558ConexionesBaseURL ;
      private bool n557ConexionesHost ;
      private bool n556ConexionesNombre ;
      private bool n562ConexionesEstado ;
      private string AV41TFConexionesEstado_SelsJson ;
      private string AV58Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV17FilterConexionesNombreDescription ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV42TFConexionesEstado_SelDscs ;
      private string AV45FilterTFConexionesEstado_SelValueDescription ;
      private string AV65Conexioneswwds_1_filterfulltext ;
      private string AV66Conexioneswwds_2_dynamicfiltersselector1 ;
      private string AV70Conexioneswwds_6_dynamicfiltersselector2 ;
      private string AV74Conexioneswwds_10_dynamicfiltersselector3 ;
      private string AV28ConexionesEstadoDescription ;
      private string AV56PageInfo ;
      private string AV53DateInfo ;
      private string AV51AppName ;
      private string AV57Phone ;
      private string AV55Mail ;
      private string AV59Website ;
      private string AV48AddressLine1 ;
      private string AV49AddressLine2 ;
      private string AV50AddressLine3 ;
      private IGxSession AV29Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV31GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV43TFConexionesEstado_Sels ;
      private GxSimpleCollection<string> AV85Conexioneswwds_21_tfconexionesestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00762_A558ConexionesBaseURL ;
      private bool[] P00762_n558ConexionesBaseURL ;
      private string[] P00762_A557ConexionesHost ;
      private bool[] P00762_n557ConexionesHost ;
      private string[] P00762_A556ConexionesNombre ;
      private bool[] P00762_n556ConexionesNombre ;
      private string[] P00762_A552ConexionesID ;
      private string[] P00762_A562ConexionesEstado ;
      private bool[] P00762_n562ConexionesEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
   }

   public class conexioneswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00762( IGxContext context ,
                                             string A562ConexionesEstado ,
                                             GxSimpleCollection<string> AV85Conexioneswwds_21_tfconexionesestado_sels ,
                                             string AV66Conexioneswwds_2_dynamicfiltersselector1 ,
                                             short AV67Conexioneswwds_3_dynamicfiltersoperator1 ,
                                             string AV68Conexioneswwds_4_conexionesnombre1 ,
                                             bool AV69Conexioneswwds_5_dynamicfiltersenabled2 ,
                                             string AV70Conexioneswwds_6_dynamicfiltersselector2 ,
                                             short AV71Conexioneswwds_7_dynamicfiltersoperator2 ,
                                             string AV72Conexioneswwds_8_conexionesnombre2 ,
                                             bool AV73Conexioneswwds_9_dynamicfiltersenabled3 ,
                                             string AV74Conexioneswwds_10_dynamicfiltersselector3 ,
                                             short AV75Conexioneswwds_11_dynamicfiltersoperator3 ,
                                             string AV76Conexioneswwds_12_conexionesnombre3 ,
                                             string AV78Conexioneswwds_14_tfconexionesid_sel ,
                                             string AV77Conexioneswwds_13_tfconexionesid ,
                                             string AV80Conexioneswwds_16_tfconexionesnombre_sel ,
                                             string AV79Conexioneswwds_15_tfconexionesnombre ,
                                             string AV82Conexioneswwds_18_tfconexioneshost_sel ,
                                             string AV81Conexioneswwds_17_tfconexioneshost ,
                                             string AV84Conexioneswwds_20_tfconexionesbaseurl_sel ,
                                             string AV83Conexioneswwds_19_tfconexionesbaseurl ,
                                             int AV85Conexioneswwds_21_tfconexionesestado_sels_Count ,
                                             string A556ConexionesNombre ,
                                             string A552ConexionesID ,
                                             string A557ConexionesHost ,
                                             string A558ConexionesBaseURL ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             string AV65Conexioneswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[14];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [ConexionesBaseURL], [ConexionesHost], [ConexionesNombre], [ConexionesID], [ConexionesEstado] FROM [Conexiones]";
         if ( ( StringUtil.StrCmp(AV66Conexioneswwds_2_dynamicfiltersselector1, "CONEXIONESNOMBRE") == 0 ) && ( AV67Conexioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Conexioneswwds_4_conexionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like UPPER(@lV68Conexioneswwds_4_conexionesnombre1))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Conexioneswwds_2_dynamicfiltersselector1, "CONEXIONESNOMBRE") == 0 ) && ( AV67Conexioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Conexioneswwds_4_conexionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like '%' + UPPER(@lV68Conexioneswwds_4_conexionesnombre1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV69Conexioneswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Conexioneswwds_6_dynamicfiltersselector2, "CONEXIONESNOMBRE") == 0 ) && ( AV71Conexioneswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Conexioneswwds_8_conexionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like UPPER(@lV72Conexioneswwds_8_conexionesnombre2))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV69Conexioneswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Conexioneswwds_6_dynamicfiltersselector2, "CONEXIONESNOMBRE") == 0 ) && ( AV71Conexioneswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Conexioneswwds_8_conexionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like '%' + UPPER(@lV72Conexioneswwds_8_conexionesnombre2))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV73Conexioneswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Conexioneswwds_10_dynamicfiltersselector3, "CONEXIONESNOMBRE") == 0 ) && ( AV75Conexioneswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Conexioneswwds_12_conexionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like UPPER(@lV76Conexioneswwds_12_conexionesnombre3))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV73Conexioneswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Conexioneswwds_10_dynamicfiltersselector3, "CONEXIONESNOMBRE") == 0 ) && ( AV75Conexioneswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Conexioneswwds_12_conexionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like '%' + UPPER(@lV76Conexioneswwds_12_conexionesnombre3))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Conexioneswwds_14_tfconexionesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Conexioneswwds_13_tfconexionesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesID]) like UPPER(@lV77Conexioneswwds_13_tfconexionesid))");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Conexioneswwds_14_tfconexionesid_sel)) && ! ( StringUtil.StrCmp(AV78Conexioneswwds_14_tfconexionesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConexionesID] = @AV78Conexioneswwds_14_tfconexionesid_sel)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( StringUtil.StrCmp(AV78Conexioneswwds_14_tfconexionesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ConexionesID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Conexioneswwds_16_tfconexionesnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Conexioneswwds_15_tfconexionesnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like UPPER(@lV79Conexioneswwds_15_tfconexionesnombre))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Conexioneswwds_16_tfconexionesnombre_sel)) && ! ( StringUtil.StrCmp(AV80Conexioneswwds_16_tfconexionesnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConexionesNombre] = @AV80Conexioneswwds_16_tfconexionesnombre_sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV80Conexioneswwds_16_tfconexionesnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ConexionesNombre] IS NULL or ([ConexionesNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Conexioneswwds_18_tfconexioneshost_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Conexioneswwds_17_tfconexioneshost)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesHost]) like UPPER(@lV81Conexioneswwds_17_tfconexioneshost))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Conexioneswwds_18_tfconexioneshost_sel)) && ! ( StringUtil.StrCmp(AV82Conexioneswwds_18_tfconexioneshost_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConexionesHost] = @AV82Conexioneswwds_18_tfconexioneshost_sel)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV82Conexioneswwds_18_tfconexioneshost_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ConexionesHost] IS NULL or ([ConexionesHost] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Conexioneswwds_20_tfconexionesbaseurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Conexioneswwds_19_tfconexionesbaseurl)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesBaseURL]) like UPPER(@lV83Conexioneswwds_19_tfconexionesbaseurl))");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Conexioneswwds_20_tfconexionesbaseurl_sel)) && ! ( StringUtil.StrCmp(AV84Conexioneswwds_20_tfconexionesbaseurl_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConexionesBaseURL] = @AV84Conexioneswwds_20_tfconexionesbaseurl_sel)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( StringUtil.StrCmp(AV84Conexioneswwds_20_tfconexionesbaseurl_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ConexionesBaseURL] IS NULL or ([ConexionesBaseURL] = ''))");
         }
         if ( AV85Conexioneswwds_21_tfconexionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV85Conexioneswwds_21_tfconexionesestado_sels, "[ConexionesEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ConexionesNombre]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ConexionesNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ConexionesID]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ConexionesID] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ConexionesHost]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ConexionesHost] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ConexionesBaseURL]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ConexionesBaseURL] DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ConexionesEstado]";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ConexionesEstado] DESC";
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
                     return conditional_P00762(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] , (string)dynConstraints[28] );
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
          Object[] prmP00762;
          prmP00762 = new Object[] {
          new ParDef("@lV68Conexioneswwds_4_conexionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV68Conexioneswwds_4_conexionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV72Conexioneswwds_8_conexionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV72Conexioneswwds_8_conexionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV76Conexioneswwds_12_conexionesnombre3",GXType.Char,80,0) ,
          new ParDef("@lV76Conexioneswwds_12_conexionesnombre3",GXType.Char,80,0) ,
          new ParDef("@lV77Conexioneswwds_13_tfconexionesid",GXType.Char,9,0) ,
          new ParDef("@AV78Conexioneswwds_14_tfconexionesid_sel",GXType.NChar,9,0) ,
          new ParDef("@lV79Conexioneswwds_15_tfconexionesnombre",GXType.Char,80,0) ,
          new ParDef("@AV80Conexioneswwds_16_tfconexionesnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV81Conexioneswwds_17_tfconexioneshost",GXType.Char,128,0) ,
          new ParDef("@AV82Conexioneswwds_18_tfconexioneshost_sel",GXType.NChar,128,0) ,
          new ParDef("@lV83Conexioneswwds_19_tfconexionesbaseurl",GXType.Char,128,0) ,
          new ParDef("@AV84Conexioneswwds_20_tfconexionesbaseurl_sel",GXType.NChar,128,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00762", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00762,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 128);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 128);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 80);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 9);
                ((string[]) buf[7])[0] = rslt.getString(5, 3);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
