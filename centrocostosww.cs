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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class centrocostosww : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public centrocostosww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public centrocostosww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavDynamicfiltersselector1 = new GXCombobox();
         cmbavDynamicfiltersoperator1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavDynamicfiltersoperator2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavDynamicfiltersoperator3 = new GXCombobox();
         cmbavGridactions = new GXCombobox();
         cmbCentroCostosEstado = new GXCombobox();
         cmbCentroCostosTipoRef = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               gxnrGrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               gxgrGrid_refresh_invoke( ) ;
               return  ;
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_111 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_111"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_111_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_111_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_111_idx = GetPar( "sGXsfl_111_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV15OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV18DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV20CentroCostosNombre1 = GetPar( "CentroCostosNombre1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV22DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV24CentroCostosNombre2 = GetPar( "CentroCostosNombre2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV26DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV28CentroCostosNombre3 = GetPar( "CentroCostosNombre3");
         AV40ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV35ColumnsSelector);
         AV71Pgmname = GetPar( "Pgmname");
         AV17FilterFullText = GetPar( "FilterFullText");
         AV21DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV25DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV41TFCentroCostosId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFCentroCostosId"), "."), 18, MidpointRounding.ToEven));
         AV42TFCentroCostosId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFCentroCostosId_To"), "."), 18, MidpointRounding.ToEven));
         AV43TFCentroCostosRef = (long)(Math.Round(NumberUtil.Val( GetPar( "TFCentroCostosRef"), "."), 18, MidpointRounding.ToEven));
         AV44TFCentroCostosRef_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFCentroCostosRef_To"), "."), 18, MidpointRounding.ToEven));
         AV45TFCentroCostosNombre = GetPar( "TFCentroCostosNombre");
         AV46TFCentroCostosNombre_Sel = GetPar( "TFCentroCostosNombre_Sel");
         AV47TFCentroCostosPrecioFinal = NumberUtil.Val( GetPar( "TFCentroCostosPrecioFinal"), ".");
         AV48TFCentroCostosPrecioFinal_To = NumberUtil.Val( GetPar( "TFCentroCostosPrecioFinal_To"), ".");
         AV49TFCentroCostosCosto = NumberUtil.Val( GetPar( "TFCentroCostosCosto"), ".");
         AV50TFCentroCostosCosto_To = NumberUtil.Val( GetPar( "TFCentroCostosCosto_To"), ".");
         AV51TFCentroCostosGam = NumberUtil.Val( GetPar( "TFCentroCostosGam"), ".");
         AV52TFCentroCostosGam_To = NumberUtil.Val( GetPar( "TFCentroCostosGam_To"), ".");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV54TFCentroCostosEstado_Sels);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV56TFCentroCostosTipoRef_Sels);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridState);
         AV30DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV29DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         AV64IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV65IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20CentroCostosNombre1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24CentroCostosNombre2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28CentroCostosNombre3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV71Pgmname, AV17FilterFullText, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFCentroCostosId, AV42TFCentroCostosId_To, AV43TFCentroCostosRef, AV44TFCentroCostosRef_To, AV45TFCentroCostosNombre, AV46TFCentroCostosNombre_Sel, AV47TFCentroCostosPrecioFinal, AV48TFCentroCostosPrecioFinal_To, AV49TFCentroCostosCosto, AV50TFCentroCostosCosto_To, AV51TFCentroCostosGam, AV52TFCentroCostosGam_To, AV54TFCentroCostosEstado_Sels, AV56TFCentroCostosTipoRef_Sels, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV64IsAuthorized_Update, AV65IsAuthorized_Delete) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         cleanup();
      }

      public override short ExecuteStartEvent( )
      {
         PA3S2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3S2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 74760), false, true, false);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 74760), false, true, false);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 74760), false, true, false);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true, false);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("centrocostosww.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV71Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV71Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV64IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV64IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV65IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV65IsAuthorized_Delete, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV15OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV18DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19DynamicFiltersOperator1), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCENTROCOSTOSNOMBRE1", StringUtil.RTrim( AV20CentroCostosNombre1));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV22DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23DynamicFiltersOperator2), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCENTROCOSTOSNOMBRE2", StringUtil.RTrim( AV24CentroCostosNombre2));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV26DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27DynamicFiltersOperator3), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCENTROCOSTOSNOMBRE3", StringUtil.RTrim( AV28CentroCostosNombre3));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_111", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_111), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV38ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV38ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV59GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV60GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV61GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV66AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV66AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV57DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV57DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV35ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV35ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV71Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV71Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV21DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV25DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vTFCENTROCOSTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41TFCentroCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFCENTROCOSTOSID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42TFCentroCostosId_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFCENTROCOSTOSREF", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43TFCentroCostosRef), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFCENTROCOSTOSREF_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44TFCentroCostosRef_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFCENTROCOSTOSNOMBRE", StringUtil.RTrim( AV45TFCentroCostosNombre));
         GxWebStd.gx_hidden_field( context, "vTFCENTROCOSTOSNOMBRE_SEL", StringUtil.RTrim( AV46TFCentroCostosNombre_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCENTROCOSTOSPRECIOFINAL", StringUtil.LTrim( StringUtil.NToC( AV47TFCentroCostosPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFCENTROCOSTOSPRECIOFINAL_TO", StringUtil.LTrim( StringUtil.NToC( AV48TFCentroCostosPrecioFinal_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFCENTROCOSTOSCOSTO", StringUtil.LTrim( StringUtil.NToC( AV49TFCentroCostosCosto, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFCENTROCOSTOSCOSTO_TO", StringUtil.LTrim( StringUtil.NToC( AV50TFCentroCostosCosto_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFCENTROCOSTOSGAM", StringUtil.LTrim( StringUtil.NToC( AV51TFCentroCostosGam, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFCENTROCOSTOSGAM_TO", StringUtil.LTrim( StringUtil.NToC( AV52TFCentroCostosGam_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFCENTROCOSTOSESTADO_SELS", AV54TFCentroCostosEstado_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFCENTROCOSTOSESTADO_SELS", AV54TFCentroCostosEstado_Sels);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFCENTROCOSTOSTIPOREF_SELS", AV56TFCentroCostosTipoRef_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFCENTROCOSTOSTIPOREF_SELS", AV56TFCentroCostosTipoRef_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV15OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV30DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV29DynamicFiltersRemoving);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV64IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV64IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV65IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV65IsAuthorized_Delete, context));
         GxWebStd.gx_hidden_field( context, "vTFCENTROCOSTOSESTADO_SELSJSON", AV53TFCentroCostosEstado_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFCENTROCOSTOSTIPOREF_SELSJSON", AV55TFCentroCostosTipoRef_SelsJson);
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Icontype", StringUtil.RTrim( Ddo_agexport_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Icon", StringUtil.RTrim( Ddo_agexport_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Caption", StringUtil.RTrim( Ddo_agexport_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Cls", StringUtil.RTrim( Ddo_agexport_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_agexport_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Icontype", StringUtil.RTrim( Ddc_subscriptions_Icontype));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Icon", StringUtil.RTrim( Ddc_subscriptions_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Caption", StringUtil.RTrim( Ddc_subscriptions_Caption));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Tooltip", StringUtil.RTrim( Ddc_subscriptions_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Cls", StringUtil.RTrim( Ddc_subscriptions_Cls));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Titlecontrolidtoreplace", StringUtil.RTrim( Ddc_subscriptions_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Fixable", StringUtil.RTrim( Ddo_grid_Fixable));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Width", StringUtil.RTrim( Innewwindow1_Width));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Height", StringUtil.RTrim( Innewwindow1_Height));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Target", StringUtil.RTrim( Innewwindow1_Target));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icontype", StringUtil.RTrim( Ddo_gridcolumnsselector_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icon", StringUtil.RTrim( Ddo_gridcolumnsselector_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Caption", StringUtil.RTrim( Ddo_gridcolumnsselector_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Tooltip", StringUtil.RTrim( Ddo_gridcolumnsselector_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Cls", StringUtil.RTrim( Ddo_gridcolumnsselector_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype", StringUtil.RTrim( Ddo_gridcolumnsselector_Dropdownoptionstype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname", StringUtil.RTrim( Ddo_gridcolumnsselector_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_gridcolumnsselector_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
         }
         context.WriteHtmlText( "<script type=\"text/javascript\">") ;
         context.WriteHtmlText( "gx.setLanguageCode(\""+context.GetLanguageProperty( "code")+"\");") ;
         if ( ! context.isSpaRequest( ) )
         {
            context.WriteHtmlText( "gx.setDateFormat(\""+context.GetLanguageProperty( "date_fmt")+"\");") ;
            context.WriteHtmlText( "gx.setTimeFormat("+context.GetLanguageProperty( "time_fmt")+");") ;
            context.WriteHtmlText( "gx.setCenturyFirstYear("+40+");") ;
            context.WriteHtmlText( "gx.setDecimalPoint(\""+context.GetLanguageProperty( "decimal_point")+"\");") ;
            context.WriteHtmlText( "gx.setThousandSeparator(\""+context.GetLanguageProperty( "thousand_sep")+"\");") ;
            context.WriteHtmlText( "gx.StorageTimeZone = "+2+";") ;
         }
         context.WriteHtmlText( "</script>") ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE3S2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3S2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("centrocostosww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CentroCostosWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Centro de Costoss", "") ;
      }

      protected void WB3S0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheadercontent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColoredActions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            ClassString = "Button ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(111), 3, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CentroCostosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(111), 3, 0)+","+"null"+");", context.GetMessage( "WWP_ExportData", ""), bttBtnagexport_Jsonclick, 0, context.GetMessage( "WWP_ExportData", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_CentroCostosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(111), 3, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_CentroCostosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(111), 3, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, context.GetMessage( "WWP_Subscriptions_Tooltip", ""), "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_CentroCostosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_25_3S2( true) ;
         }
         else
         {
            wb_table1_25_3S2( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_3S2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellAdvancedFiltersHidden", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedfilterscontainer_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;justify-content:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfilters_Internalname, 1, 0, "px", 0, "px", "TableDynamicFiltersFlex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DynRowVisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow1_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_CentroCostosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, context.GetMessage( "Dynamic Filters Selector1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_111_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV18DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "", true, 0, "HLP_CentroCostosWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_CentroCostosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_49_3S2( true) ;
         }
         else
         {
            wb_table2_49_3S2( false) ;
         }
         return  ;
      }

      protected void wb_table2_49_3S2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow2_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_CentroCostosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, context.GetMessage( "Dynamic Filters Selector2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'" + sGXsfl_111_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV22DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "", true, 0, "HLP_CentroCostosWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_CentroCostosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_71_3S2( true) ;
         }
         else
         {
            wb_table3_71_3S2( false) ;
         }
         return  ;
      }

      protected void wb_table3_71_3S2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow3_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_CentroCostosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, context.GetMessage( "Dynamic Filters Selector3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'" + sGXsfl_111_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV26DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "", true, 0, "HLP_CentroCostosWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_CentroCostosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table4_93_3S2( true) ;
         }
         else
         {
            wb_table4_93_3S2( false) ;
         }
         return  ;
      }

      protected void wb_table4_93_3S2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl111( ) ;
         }
         if ( wbEnd == 111 )
         {
            wbEnd = 0;
            nRC_GXsfl_111 = (int)(nGXsfl_111_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGridpaginationbar.SetProperty("Class", Gridpaginationbar_Class);
            ucGridpaginationbar.SetProperty("ShowFirst", Gridpaginationbar_Showfirst);
            ucGridpaginationbar.SetProperty("ShowPrevious", Gridpaginationbar_Showprevious);
            ucGridpaginationbar.SetProperty("ShowNext", Gridpaginationbar_Shownext);
            ucGridpaginationbar.SetProperty("ShowLast", Gridpaginationbar_Showlast);
            ucGridpaginationbar.SetProperty("PagesToShow", Gridpaginationbar_Pagestoshow);
            ucGridpaginationbar.SetProperty("PagingButtonsPosition", Gridpaginationbar_Pagingbuttonsposition);
            ucGridpaginationbar.SetProperty("PagingCaptionPosition", Gridpaginationbar_Pagingcaptionposition);
            ucGridpaginationbar.SetProperty("EmptyGridClass", Gridpaginationbar_Emptygridclass);
            ucGridpaginationbar.SetProperty("RowsPerPageSelector", Gridpaginationbar_Rowsperpageselector);
            ucGridpaginationbar.SetProperty("RowsPerPageOptions", Gridpaginationbar_Rowsperpageoptions);
            ucGridpaginationbar.SetProperty("Previous", Gridpaginationbar_Previous);
            ucGridpaginationbar.SetProperty("Next", Gridpaginationbar_Next);
            ucGridpaginationbar.SetProperty("Caption", Gridpaginationbar_Caption);
            ucGridpaginationbar.SetProperty("EmptyGridCaption", Gridpaginationbar_Emptygridcaption);
            ucGridpaginationbar.SetProperty("RowsPerPageCaption", Gridpaginationbar_Rowsperpagecaption);
            ucGridpaginationbar.SetProperty("CurrentPage", AV59GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV60GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV61GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDdo_agexport.SetProperty("IconType", Ddo_agexport_Icontype);
            ucDdo_agexport.SetProperty("Icon", Ddo_agexport_Icon);
            ucDdo_agexport.SetProperty("Caption", Ddo_agexport_Caption);
            ucDdo_agexport.SetProperty("Cls", Ddo_agexport_Cls);
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV66AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, "DDC_SUBSCRIPTIONSContainer");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_CentroCostosWW.htm");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("Fixable", Ddo_grid_Fixable);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("AllowMultipleSelection", Ddo_grid_Allowmultipleselection);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV57DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, "INNEWWINDOW1Container");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV57DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV35ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0136"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0136"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_111_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0136"+"");
                     }
                     WebComp_Wwpaux_wc.componentdraw();
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspEndCmp();
                     }
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 111 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START3S2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 18_0_15-188745", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( "Centro de Costoss", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3S0( ) ;
      }

      protected void WS3S2( )
      {
         START3S2( ) ;
         EVT3S2( ) ;
      }

      protected void EVT3S2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_managefilters.Onoptionclicked */
                              E113S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E123S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E133S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_agexport.Onoptionclicked */
                              E143S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E153S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E163S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E173S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E183S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E193S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E203S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E213S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E223S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E233S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E243S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E253S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E263S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) )
                           {
                              nGXsfl_111_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_111_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_111_idx), 4, 0), 4, "0");
                              SubsflControlProps_1112( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV62GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV62GridActions), 4, 0));
                              A461CentroCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCentroCostosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A462CentroCostosRef = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCentroCostosRef_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A463CentroCostosNombre = cgiGet( edtCentroCostosNombre_Internalname);
                              A464CentroCostosPrecioFinal = context.localUtil.CToN( cgiGet( edtCentroCostosPrecioFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A469CentroCostosSubTotal = context.localUtil.CToN( cgiGet( edtCentroCostosSubTotal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              n469CentroCostosSubTotal = false;
                              A475CentroCostosCosto = context.localUtil.CToN( cgiGet( edtCentroCostosCosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A474CentroCostosGam = context.localUtil.CToN( cgiGet( edtCentroCostosGam_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              cmbCentroCostosEstado.Name = cmbCentroCostosEstado_Internalname;
                              cmbCentroCostosEstado.CurrentValue = cgiGet( cmbCentroCostosEstado_Internalname);
                              A482CentroCostosEstado = cgiGet( cmbCentroCostosEstado_Internalname);
                              cmbCentroCostosTipoRef.Name = cmbCentroCostosTipoRef_Internalname;
                              cmbCentroCostosTipoRef.CurrentValue = cgiGet( cmbCentroCostosTipoRef_Internalname);
                              A487CentroCostosTipoRef = cgiGet( cmbCentroCostosTipoRef_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E273S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E283S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E293S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E303S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV14OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV15OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV18DynamicFiltersSelector1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV19DynamicFiltersOperator1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Centrocostosnombre1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCENTROCOSTOSNOMBRE1"), AV20CentroCostosNombre1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV22DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV23DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Centrocostosnombre2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCENTROCOSTOSNOMBRE2"), AV24CentroCostosNombre2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV26DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV27DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Centrocostosnombre3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCENTROCOSTOSNOMBRE3"), AV28CentroCostosNombre3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 136 )
                        {
                           OldWwpaux_wc = cgiGet( "W0136");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0136", "", sEvt);
                           }
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE3S2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA3S2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavFilterfulltext_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1112( ) ;
         while ( nGXsfl_111_idx <= nRC_GXsfl_111 )
         {
            sendrow_1112( ) ;
            nGXsfl_111_idx = ((subGrid_Islastpage==1)&&(nGXsfl_111_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_111_idx+1);
            sGXsfl_111_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_111_idx), 4, 0), 4, "0");
            SubsflControlProps_1112( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       string AV18DynamicFiltersSelector1 ,
                                       short AV19DynamicFiltersOperator1 ,
                                       string AV20CentroCostosNombre1 ,
                                       string AV22DynamicFiltersSelector2 ,
                                       short AV23DynamicFiltersOperator2 ,
                                       string AV24CentroCostosNombre2 ,
                                       string AV26DynamicFiltersSelector3 ,
                                       short AV27DynamicFiltersOperator3 ,
                                       string AV28CentroCostosNombre3 ,
                                       short AV40ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV35ColumnsSelector ,
                                       string AV71Pgmname ,
                                       string AV17FilterFullText ,
                                       bool AV21DynamicFiltersEnabled2 ,
                                       bool AV25DynamicFiltersEnabled3 ,
                                       long AV41TFCentroCostosId ,
                                       long AV42TFCentroCostosId_To ,
                                       long AV43TFCentroCostosRef ,
                                       long AV44TFCentroCostosRef_To ,
                                       string AV45TFCentroCostosNombre ,
                                       string AV46TFCentroCostosNombre_Sel ,
                                       decimal AV47TFCentroCostosPrecioFinal ,
                                       decimal AV48TFCentroCostosPrecioFinal_To ,
                                       decimal AV49TFCentroCostosCosto ,
                                       decimal AV50TFCentroCostosCosto_To ,
                                       decimal AV51TFCentroCostosGam ,
                                       decimal AV52TFCentroCostosGam_To ,
                                       GxSimpleCollection<string> AV54TFCentroCostosEstado_Sels ,
                                       GxSimpleCollection<string> AV56TFCentroCostosTipoRef_Sels ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ,
                                       bool AV30DynamicFiltersIgnoreFirst ,
                                       bool AV29DynamicFiltersRemoving ,
                                       bool AV64IsAuthorized_Update ,
                                       bool AV65IsAuthorized_Delete )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF3S2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CENTROCOSTOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A461CentroCostosId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A461CentroCostosId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_CENTROCOSTOSREF", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A462CentroCostosRef), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSREF", StringUtil.LTrim( StringUtil.NToC( (decimal)(A462CentroCostosRef), 18, 0, ".", "")));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV18DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV18DynamicFiltersSelector1);
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV22DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV22DynamicFiltersSelector2);
            AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV26DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV26DynamicFiltersSelector3);
            AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3S2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV71Pgmname = "CentroCostosWW";
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV72Centrocostoswwds_1_filterfulltext = AV17FilterFullText;
         AV73Centrocostoswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV74Centrocostoswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV75Centrocostoswwds_4_centrocostosnombre1 = AV20CentroCostosNombre1;
         AV76Centrocostoswwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV77Centrocostoswwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV78Centrocostoswwds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV79Centrocostoswwds_8_centrocostosnombre2 = AV24CentroCostosNombre2;
         AV80Centrocostoswwds_9_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV81Centrocostoswwds_10_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV82Centrocostoswwds_11_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV83Centrocostoswwds_12_centrocostosnombre3 = AV28CentroCostosNombre3;
         AV84Centrocostoswwds_13_tfcentrocostosid = AV41TFCentroCostosId;
         AV85Centrocostoswwds_14_tfcentrocostosid_to = AV42TFCentroCostosId_To;
         AV86Centrocostoswwds_15_tfcentrocostosref = AV43TFCentroCostosRef;
         AV87Centrocostoswwds_16_tfcentrocostosref_to = AV44TFCentroCostosRef_To;
         AV88Centrocostoswwds_17_tfcentrocostosnombre = AV45TFCentroCostosNombre;
         AV89Centrocostoswwds_18_tfcentrocostosnombre_sel = AV46TFCentroCostosNombre_Sel;
         AV90Centrocostoswwds_19_tfcentrocostospreciofinal = AV47TFCentroCostosPrecioFinal;
         AV91Centrocostoswwds_20_tfcentrocostospreciofinal_to = AV48TFCentroCostosPrecioFinal_To;
         AV92Centrocostoswwds_21_tfcentrocostoscosto = AV49TFCentroCostosCosto;
         AV93Centrocostoswwds_22_tfcentrocostoscosto_to = AV50TFCentroCostosCosto_To;
         AV94Centrocostoswwds_23_tfcentrocostosgam = AV51TFCentroCostosGam;
         AV95Centrocostoswwds_24_tfcentrocostosgam_to = AV52TFCentroCostosGam_To;
         AV96Centrocostoswwds_25_tfcentrocostosestado_sels = AV54TFCentroCostosEstado_Sels;
         AV97Centrocostoswwds_26_tfcentrocostostiporef_sels = AV56TFCentroCostosTipoRef_Sels;
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A482CentroCostosEstado ,
                                              AV96Centrocostoswwds_25_tfcentrocostosestado_sels ,
                                              A487CentroCostosTipoRef ,
                                              AV97Centrocostoswwds_26_tfcentrocostostiporef_sels ,
                                              AV73Centrocostoswwds_2_dynamicfiltersselector1 ,
                                              AV74Centrocostoswwds_3_dynamicfiltersoperator1 ,
                                              AV75Centrocostoswwds_4_centrocostosnombre1 ,
                                              AV76Centrocostoswwds_5_dynamicfiltersenabled2 ,
                                              AV77Centrocostoswwds_6_dynamicfiltersselector2 ,
                                              AV78Centrocostoswwds_7_dynamicfiltersoperator2 ,
                                              AV79Centrocostoswwds_8_centrocostosnombre2 ,
                                              AV80Centrocostoswwds_9_dynamicfiltersenabled3 ,
                                              AV81Centrocostoswwds_10_dynamicfiltersselector3 ,
                                              AV82Centrocostoswwds_11_dynamicfiltersoperator3 ,
                                              AV83Centrocostoswwds_12_centrocostosnombre3 ,
                                              AV84Centrocostoswwds_13_tfcentrocostosid ,
                                              AV85Centrocostoswwds_14_tfcentrocostosid_to ,
                                              AV86Centrocostoswwds_15_tfcentrocostosref ,
                                              AV87Centrocostoswwds_16_tfcentrocostosref_to ,
                                              AV89Centrocostoswwds_18_tfcentrocostosnombre_sel ,
                                              AV88Centrocostoswwds_17_tfcentrocostosnombre ,
                                              AV90Centrocostoswwds_19_tfcentrocostospreciofinal ,
                                              AV91Centrocostoswwds_20_tfcentrocostospreciofinal_to ,
                                              AV92Centrocostoswwds_21_tfcentrocostoscosto ,
                                              AV93Centrocostoswwds_22_tfcentrocostoscosto_to ,
                                              AV94Centrocostoswwds_23_tfcentrocostosgam ,
                                              AV95Centrocostoswwds_24_tfcentrocostosgam_to ,
                                              AV96Centrocostoswwds_25_tfcentrocostosestado_sels.Count ,
                                              AV97Centrocostoswwds_26_tfcentrocostostiporef_sels.Count ,
                                              A463CentroCostosNombre ,
                                              A461CentroCostosId ,
                                              A462CentroCostosRef ,
                                              A464CentroCostosPrecioFinal ,
                                              A475CentroCostosCosto ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              AV72Centrocostoswwds_1_filterfulltext ,
                                              A474CentroCostosGam } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL
                                              }
         });
         lV75Centrocostoswwds_4_centrocostosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV75Centrocostoswwds_4_centrocostosnombre1), 80, "%");
         lV75Centrocostoswwds_4_centrocostosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV75Centrocostoswwds_4_centrocostosnombre1), 80, "%");
         lV79Centrocostoswwds_8_centrocostosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV79Centrocostoswwds_8_centrocostosnombre2), 80, "%");
         lV79Centrocostoswwds_8_centrocostosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV79Centrocostoswwds_8_centrocostosnombre2), 80, "%");
         lV83Centrocostoswwds_12_centrocostosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV83Centrocostoswwds_12_centrocostosnombre3), 80, "%");
         lV83Centrocostoswwds_12_centrocostosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV83Centrocostoswwds_12_centrocostosnombre3), 80, "%");
         lV88Centrocostoswwds_17_tfcentrocostosnombre = StringUtil.PadR( StringUtil.RTrim( AV88Centrocostoswwds_17_tfcentrocostosnombre), 80, "%");
         /* Using cursor H003S3 */
         pr_default.execute(0, new Object[] {lV75Centrocostoswwds_4_centrocostosnombre1, lV75Centrocostoswwds_4_centrocostosnombre1, lV79Centrocostoswwds_8_centrocostosnombre2, lV79Centrocostoswwds_8_centrocostosnombre2, lV83Centrocostoswwds_12_centrocostosnombre3, lV83Centrocostoswwds_12_centrocostosnombre3, AV84Centrocostoswwds_13_tfcentrocostosid, AV85Centrocostoswwds_14_tfcentrocostosid_to, AV86Centrocostoswwds_15_tfcentrocostosref, AV87Centrocostoswwds_16_tfcentrocostosref_to, lV88Centrocostoswwds_17_tfcentrocostosnombre, AV89Centrocostoswwds_18_tfcentrocostosnombre_sel, AV90Centrocostoswwds_19_tfcentrocostospreciofinal, AV91Centrocostoswwds_20_tfcentrocostospreciofinal_to, AV92Centrocostoswwds_21_tfcentrocostoscosto, AV93Centrocostoswwds_22_tfcentrocostoscosto_to, AV94Centrocostoswwds_23_tfcentrocostosgam, AV95Centrocostoswwds_24_tfcentrocostosgam_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A487CentroCostosTipoRef = H003S3_A487CentroCostosTipoRef[0];
            A482CentroCostosEstado = H003S3_A482CentroCostosEstado[0];
            A474CentroCostosGam = H003S3_A474CentroCostosGam[0];
            A463CentroCostosNombre = H003S3_A463CentroCostosNombre[0];
            A462CentroCostosRef = H003S3_A462CentroCostosRef[0];
            A461CentroCostosId = H003S3_A461CentroCostosId[0];
            A464CentroCostosPrecioFinal = H003S3_A464CentroCostosPrecioFinal[0];
            A475CentroCostosCosto = H003S3_A475CentroCostosCosto[0];
            A469CentroCostosSubTotal = H003S3_A469CentroCostosSubTotal[0];
            n469CentroCostosSubTotal = H003S3_n469CentroCostosSubTotal[0];
            A469CentroCostosSubTotal = H003S3_A469CentroCostosSubTotal[0];
            n469CentroCostosSubTotal = H003S3_n469CentroCostosSubTotal[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Centrocostoswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A461CentroCostosId), 18, 0) , StringUtil.PadR( "%" + AV72Centrocostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A462CentroCostosRef), 18, 0) , StringUtil.PadR( "%" + AV72Centrocostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A463CentroCostosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV72Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A464CentroCostosPrecioFinal, 18, 2) , StringUtil.PadR( "%" + AV72Centrocostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A475CentroCostosCosto, 18, 2) , StringUtil.PadR( "%" + AV72Centrocostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A474CentroCostosGam, 18, 2) , StringUtil.PadR( "%" + AV72Centrocostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "aprobado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente de aprobación", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "PND") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "desaprobado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A482CentroCostosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "servicios", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A487CentroCostosTipoRef, "S") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A487CentroCostosTipoRef, "O") == 0 ) ) )
            )
            {
               GRID_nRecordCount = (long)(GRID_nRecordCount+1);
            }
            pr_default.readNext(0);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(0);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RF3S2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 111;
         /* Execute user event: Refresh */
         E283S2 ();
         nGXsfl_111_idx = 1;
         sGXsfl_111_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_111_idx), 4, 0), 4, "0");
         SubsflControlProps_1112( ) ;
         bGXsfl_111_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  WebComp_Wwpaux_wc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1112( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A482CentroCostosEstado ,
                                                 AV96Centrocostoswwds_25_tfcentrocostosestado_sels ,
                                                 A487CentroCostosTipoRef ,
                                                 AV97Centrocostoswwds_26_tfcentrocostostiporef_sels ,
                                                 AV73Centrocostoswwds_2_dynamicfiltersselector1 ,
                                                 AV74Centrocostoswwds_3_dynamicfiltersoperator1 ,
                                                 AV75Centrocostoswwds_4_centrocostosnombre1 ,
                                                 AV76Centrocostoswwds_5_dynamicfiltersenabled2 ,
                                                 AV77Centrocostoswwds_6_dynamicfiltersselector2 ,
                                                 AV78Centrocostoswwds_7_dynamicfiltersoperator2 ,
                                                 AV79Centrocostoswwds_8_centrocostosnombre2 ,
                                                 AV80Centrocostoswwds_9_dynamicfiltersenabled3 ,
                                                 AV81Centrocostoswwds_10_dynamicfiltersselector3 ,
                                                 AV82Centrocostoswwds_11_dynamicfiltersoperator3 ,
                                                 AV83Centrocostoswwds_12_centrocostosnombre3 ,
                                                 AV84Centrocostoswwds_13_tfcentrocostosid ,
                                                 AV85Centrocostoswwds_14_tfcentrocostosid_to ,
                                                 AV86Centrocostoswwds_15_tfcentrocostosref ,
                                                 AV87Centrocostoswwds_16_tfcentrocostosref_to ,
                                                 AV89Centrocostoswwds_18_tfcentrocostosnombre_sel ,
                                                 AV88Centrocostoswwds_17_tfcentrocostosnombre ,
                                                 AV90Centrocostoswwds_19_tfcentrocostospreciofinal ,
                                                 AV91Centrocostoswwds_20_tfcentrocostospreciofinal_to ,
                                                 AV92Centrocostoswwds_21_tfcentrocostoscosto ,
                                                 AV93Centrocostoswwds_22_tfcentrocostoscosto_to ,
                                                 AV94Centrocostoswwds_23_tfcentrocostosgam ,
                                                 AV95Centrocostoswwds_24_tfcentrocostosgam_to ,
                                                 AV96Centrocostoswwds_25_tfcentrocostosestado_sels.Count ,
                                                 AV97Centrocostoswwds_26_tfcentrocostostiporef_sels.Count ,
                                                 A463CentroCostosNombre ,
                                                 A461CentroCostosId ,
                                                 A462CentroCostosRef ,
                                                 A464CentroCostosPrecioFinal ,
                                                 A475CentroCostosCosto ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 AV72Centrocostoswwds_1_filterfulltext ,
                                                 A474CentroCostosGam } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL,
                                                 TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL,
                                                 TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL
                                                 }
            });
            lV75Centrocostoswwds_4_centrocostosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV75Centrocostoswwds_4_centrocostosnombre1), 80, "%");
            lV75Centrocostoswwds_4_centrocostosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV75Centrocostoswwds_4_centrocostosnombre1), 80, "%");
            lV79Centrocostoswwds_8_centrocostosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV79Centrocostoswwds_8_centrocostosnombre2), 80, "%");
            lV79Centrocostoswwds_8_centrocostosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV79Centrocostoswwds_8_centrocostosnombre2), 80, "%");
            lV83Centrocostoswwds_12_centrocostosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV83Centrocostoswwds_12_centrocostosnombre3), 80, "%");
            lV83Centrocostoswwds_12_centrocostosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV83Centrocostoswwds_12_centrocostosnombre3), 80, "%");
            lV88Centrocostoswwds_17_tfcentrocostosnombre = StringUtil.PadR( StringUtil.RTrim( AV88Centrocostoswwds_17_tfcentrocostosnombre), 80, "%");
            /* Using cursor H003S5 */
            pr_default.execute(1, new Object[] {lV75Centrocostoswwds_4_centrocostosnombre1, lV75Centrocostoswwds_4_centrocostosnombre1, lV79Centrocostoswwds_8_centrocostosnombre2, lV79Centrocostoswwds_8_centrocostosnombre2, lV83Centrocostoswwds_12_centrocostosnombre3, lV83Centrocostoswwds_12_centrocostosnombre3, AV84Centrocostoswwds_13_tfcentrocostosid, AV85Centrocostoswwds_14_tfcentrocostosid_to, AV86Centrocostoswwds_15_tfcentrocostosref, AV87Centrocostoswwds_16_tfcentrocostosref_to, lV88Centrocostoswwds_17_tfcentrocostosnombre, AV89Centrocostoswwds_18_tfcentrocostosnombre_sel, AV90Centrocostoswwds_19_tfcentrocostospreciofinal, AV91Centrocostoswwds_20_tfcentrocostospreciofinal_to, AV92Centrocostoswwds_21_tfcentrocostoscosto, AV93Centrocostoswwds_22_tfcentrocostoscosto_to, AV94Centrocostoswwds_23_tfcentrocostosgam, AV95Centrocostoswwds_24_tfcentrocostosgam_to});
            nGXsfl_111_idx = 1;
            sGXsfl_111_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_111_idx), 4, 0), 4, "0");
            SubsflControlProps_1112( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A487CentroCostosTipoRef = H003S5_A487CentroCostosTipoRef[0];
               A482CentroCostosEstado = H003S5_A482CentroCostosEstado[0];
               A474CentroCostosGam = H003S5_A474CentroCostosGam[0];
               A463CentroCostosNombre = H003S5_A463CentroCostosNombre[0];
               A462CentroCostosRef = H003S5_A462CentroCostosRef[0];
               A461CentroCostosId = H003S5_A461CentroCostosId[0];
               A464CentroCostosPrecioFinal = H003S5_A464CentroCostosPrecioFinal[0];
               A475CentroCostosCosto = H003S5_A475CentroCostosCosto[0];
               A469CentroCostosSubTotal = H003S5_A469CentroCostosSubTotal[0];
               n469CentroCostosSubTotal = H003S5_n469CentroCostosSubTotal[0];
               A469CentroCostosSubTotal = H003S5_A469CentroCostosSubTotal[0];
               n469CentroCostosSubTotal = H003S5_n469CentroCostosSubTotal[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Centrocostoswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A461CentroCostosId), 18, 0) , StringUtil.PadR( "%" + AV72Centrocostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Str( (decimal)(A462CentroCostosRef), 18, 0) , StringUtil.PadR( "%" + AV72Centrocostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A463CentroCostosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV72Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Str( A464CentroCostosPrecioFinal, 18, 2) , StringUtil.PadR( "%" + AV72Centrocostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A475CentroCostosCosto, 18, 2) , StringUtil.PadR( "%" + AV72Centrocostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Str( A474CentroCostosGam, 18, 2) , StringUtil.PadR( "%" + AV72Centrocostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "aprobado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "HAB") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "DES") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "pendiente de aprobación", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "PND") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "desaprobado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A482CentroCostosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "servicios", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A487CentroCostosTipoRef, "S") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV72Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A487CentroCostosTipoRef, "O") == 0 ) ) )
               )
               {
                  /* Execute user event: Grid.Load */
                  E293S2 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 111;
            WB3S0( ) ;
         }
         bGXsfl_111_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3S2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV71Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV71Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV64IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV64IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV65IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV65IsAuthorized_Delete, context));
         GxWebStd.gx_hidden_field( context, "gxhash_CENTROCOSTOSID"+"_"+sGXsfl_111_idx, GetSecureSignedToken( sGXsfl_111_idx, context.localUtil.Format( (decimal)(A461CentroCostosId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_CENTROCOSTOSREF"+"_"+sGXsfl_111_idx, GetSecureSignedToken( sGXsfl_111_idx, context.localUtil.Format( (decimal)(A462CentroCostosRef), "ZZZZZZZZZZZZZZZZZ9"), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((long)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return (int)(subGridclient_rec_count_fnc()) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         AV72Centrocostoswwds_1_filterfulltext = AV17FilterFullText;
         AV73Centrocostoswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV74Centrocostoswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV75Centrocostoswwds_4_centrocostosnombre1 = AV20CentroCostosNombre1;
         AV76Centrocostoswwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV77Centrocostoswwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV78Centrocostoswwds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV79Centrocostoswwds_8_centrocostosnombre2 = AV24CentroCostosNombre2;
         AV80Centrocostoswwds_9_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV81Centrocostoswwds_10_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV82Centrocostoswwds_11_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV83Centrocostoswwds_12_centrocostosnombre3 = AV28CentroCostosNombre3;
         AV84Centrocostoswwds_13_tfcentrocostosid = AV41TFCentroCostosId;
         AV85Centrocostoswwds_14_tfcentrocostosid_to = AV42TFCentroCostosId_To;
         AV86Centrocostoswwds_15_tfcentrocostosref = AV43TFCentroCostosRef;
         AV87Centrocostoswwds_16_tfcentrocostosref_to = AV44TFCentroCostosRef_To;
         AV88Centrocostoswwds_17_tfcentrocostosnombre = AV45TFCentroCostosNombre;
         AV89Centrocostoswwds_18_tfcentrocostosnombre_sel = AV46TFCentroCostosNombre_Sel;
         AV90Centrocostoswwds_19_tfcentrocostospreciofinal = AV47TFCentroCostosPrecioFinal;
         AV91Centrocostoswwds_20_tfcentrocostospreciofinal_to = AV48TFCentroCostosPrecioFinal_To;
         AV92Centrocostoswwds_21_tfcentrocostoscosto = AV49TFCentroCostosCosto;
         AV93Centrocostoswwds_22_tfcentrocostoscosto_to = AV50TFCentroCostosCosto_To;
         AV94Centrocostoswwds_23_tfcentrocostosgam = AV51TFCentroCostosGam;
         AV95Centrocostoswwds_24_tfcentrocostosgam_to = AV52TFCentroCostosGam_To;
         AV96Centrocostoswwds_25_tfcentrocostosestado_sels = AV54TFCentroCostosEstado_Sels;
         AV97Centrocostoswwds_26_tfcentrocostostiporef_sels = AV56TFCentroCostosTipoRef_Sels;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20CentroCostosNombre1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24CentroCostosNombre2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28CentroCostosNombre3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV71Pgmname, AV17FilterFullText, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFCentroCostosId, AV42TFCentroCostosId_To, AV43TFCentroCostosRef, AV44TFCentroCostosRef_To, AV45TFCentroCostosNombre, AV46TFCentroCostosNombre_Sel, AV47TFCentroCostosPrecioFinal, AV48TFCentroCostosPrecioFinal_To, AV49TFCentroCostosCosto, AV50TFCentroCostosCosto_To, AV51TFCentroCostosGam, AV52TFCentroCostosGam_To, AV54TFCentroCostosEstado_Sels, AV56TFCentroCostosTipoRef_Sels, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV64IsAuthorized_Update, AV65IsAuthorized_Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV72Centrocostoswwds_1_filterfulltext = AV17FilterFullText;
         AV73Centrocostoswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV74Centrocostoswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV75Centrocostoswwds_4_centrocostosnombre1 = AV20CentroCostosNombre1;
         AV76Centrocostoswwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV77Centrocostoswwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV78Centrocostoswwds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV79Centrocostoswwds_8_centrocostosnombre2 = AV24CentroCostosNombre2;
         AV80Centrocostoswwds_9_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV81Centrocostoswwds_10_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV82Centrocostoswwds_11_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV83Centrocostoswwds_12_centrocostosnombre3 = AV28CentroCostosNombre3;
         AV84Centrocostoswwds_13_tfcentrocostosid = AV41TFCentroCostosId;
         AV85Centrocostoswwds_14_tfcentrocostosid_to = AV42TFCentroCostosId_To;
         AV86Centrocostoswwds_15_tfcentrocostosref = AV43TFCentroCostosRef;
         AV87Centrocostoswwds_16_tfcentrocostosref_to = AV44TFCentroCostosRef_To;
         AV88Centrocostoswwds_17_tfcentrocostosnombre = AV45TFCentroCostosNombre;
         AV89Centrocostoswwds_18_tfcentrocostosnombre_sel = AV46TFCentroCostosNombre_Sel;
         AV90Centrocostoswwds_19_tfcentrocostospreciofinal = AV47TFCentroCostosPrecioFinal;
         AV91Centrocostoswwds_20_tfcentrocostospreciofinal_to = AV48TFCentroCostosPrecioFinal_To;
         AV92Centrocostoswwds_21_tfcentrocostoscosto = AV49TFCentroCostosCosto;
         AV93Centrocostoswwds_22_tfcentrocostoscosto_to = AV50TFCentroCostosCosto_To;
         AV94Centrocostoswwds_23_tfcentrocostosgam = AV51TFCentroCostosGam;
         AV95Centrocostoswwds_24_tfcentrocostosgam_to = AV52TFCentroCostosGam_To;
         AV96Centrocostoswwds_25_tfcentrocostosestado_sels = AV54TFCentroCostosEstado_Sels;
         AV97Centrocostoswwds_26_tfcentrocostostiporef_sels = AV56TFCentroCostosTipoRef_Sels;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20CentroCostosNombre1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24CentroCostosNombre2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28CentroCostosNombre3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV71Pgmname, AV17FilterFullText, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFCentroCostosId, AV42TFCentroCostosId_To, AV43TFCentroCostosRef, AV44TFCentroCostosRef_To, AV45TFCentroCostosNombre, AV46TFCentroCostosNombre_Sel, AV47TFCentroCostosPrecioFinal, AV48TFCentroCostosPrecioFinal_To, AV49TFCentroCostosCosto, AV50TFCentroCostosCosto_To, AV51TFCentroCostosGam, AV52TFCentroCostosGam_To, AV54TFCentroCostosEstado_Sels, AV56TFCentroCostosTipoRef_Sels, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV64IsAuthorized_Update, AV65IsAuthorized_Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV72Centrocostoswwds_1_filterfulltext = AV17FilterFullText;
         AV73Centrocostoswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV74Centrocostoswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV75Centrocostoswwds_4_centrocostosnombre1 = AV20CentroCostosNombre1;
         AV76Centrocostoswwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV77Centrocostoswwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV78Centrocostoswwds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV79Centrocostoswwds_8_centrocostosnombre2 = AV24CentroCostosNombre2;
         AV80Centrocostoswwds_9_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV81Centrocostoswwds_10_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV82Centrocostoswwds_11_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV83Centrocostoswwds_12_centrocostosnombre3 = AV28CentroCostosNombre3;
         AV84Centrocostoswwds_13_tfcentrocostosid = AV41TFCentroCostosId;
         AV85Centrocostoswwds_14_tfcentrocostosid_to = AV42TFCentroCostosId_To;
         AV86Centrocostoswwds_15_tfcentrocostosref = AV43TFCentroCostosRef;
         AV87Centrocostoswwds_16_tfcentrocostosref_to = AV44TFCentroCostosRef_To;
         AV88Centrocostoswwds_17_tfcentrocostosnombre = AV45TFCentroCostosNombre;
         AV89Centrocostoswwds_18_tfcentrocostosnombre_sel = AV46TFCentroCostosNombre_Sel;
         AV90Centrocostoswwds_19_tfcentrocostospreciofinal = AV47TFCentroCostosPrecioFinal;
         AV91Centrocostoswwds_20_tfcentrocostospreciofinal_to = AV48TFCentroCostosPrecioFinal_To;
         AV92Centrocostoswwds_21_tfcentrocostoscosto = AV49TFCentroCostosCosto;
         AV93Centrocostoswwds_22_tfcentrocostoscosto_to = AV50TFCentroCostosCosto_To;
         AV94Centrocostoswwds_23_tfcentrocostosgam = AV51TFCentroCostosGam;
         AV95Centrocostoswwds_24_tfcentrocostosgam_to = AV52TFCentroCostosGam_To;
         AV96Centrocostoswwds_25_tfcentrocostosestado_sels = AV54TFCentroCostosEstado_Sels;
         AV97Centrocostoswwds_26_tfcentrocostostiporef_sels = AV56TFCentroCostosTipoRef_Sels;
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20CentroCostosNombre1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24CentroCostosNombre2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28CentroCostosNombre3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV71Pgmname, AV17FilterFullText, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFCentroCostosId, AV42TFCentroCostosId_To, AV43TFCentroCostosRef, AV44TFCentroCostosRef_To, AV45TFCentroCostosNombre, AV46TFCentroCostosNombre_Sel, AV47TFCentroCostosPrecioFinal, AV48TFCentroCostosPrecioFinal_To, AV49TFCentroCostosCosto, AV50TFCentroCostosCosto_To, AV51TFCentroCostosGam, AV52TFCentroCostosGam_To, AV54TFCentroCostosEstado_Sels, AV56TFCentroCostosTipoRef_Sels, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV64IsAuthorized_Update, AV65IsAuthorized_Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV72Centrocostoswwds_1_filterfulltext = AV17FilterFullText;
         AV73Centrocostoswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV74Centrocostoswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV75Centrocostoswwds_4_centrocostosnombre1 = AV20CentroCostosNombre1;
         AV76Centrocostoswwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV77Centrocostoswwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV78Centrocostoswwds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV79Centrocostoswwds_8_centrocostosnombre2 = AV24CentroCostosNombre2;
         AV80Centrocostoswwds_9_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV81Centrocostoswwds_10_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV82Centrocostoswwds_11_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV83Centrocostoswwds_12_centrocostosnombre3 = AV28CentroCostosNombre3;
         AV84Centrocostoswwds_13_tfcentrocostosid = AV41TFCentroCostosId;
         AV85Centrocostoswwds_14_tfcentrocostosid_to = AV42TFCentroCostosId_To;
         AV86Centrocostoswwds_15_tfcentrocostosref = AV43TFCentroCostosRef;
         AV87Centrocostoswwds_16_tfcentrocostosref_to = AV44TFCentroCostosRef_To;
         AV88Centrocostoswwds_17_tfcentrocostosnombre = AV45TFCentroCostosNombre;
         AV89Centrocostoswwds_18_tfcentrocostosnombre_sel = AV46TFCentroCostosNombre_Sel;
         AV90Centrocostoswwds_19_tfcentrocostospreciofinal = AV47TFCentroCostosPrecioFinal;
         AV91Centrocostoswwds_20_tfcentrocostospreciofinal_to = AV48TFCentroCostosPrecioFinal_To;
         AV92Centrocostoswwds_21_tfcentrocostoscosto = AV49TFCentroCostosCosto;
         AV93Centrocostoswwds_22_tfcentrocostoscosto_to = AV50TFCentroCostosCosto_To;
         AV94Centrocostoswwds_23_tfcentrocostosgam = AV51TFCentroCostosGam;
         AV95Centrocostoswwds_24_tfcentrocostosgam_to = AV52TFCentroCostosGam_To;
         AV96Centrocostoswwds_25_tfcentrocostosestado_sels = AV54TFCentroCostosEstado_Sels;
         AV97Centrocostoswwds_26_tfcentrocostostiporef_sels = AV56TFCentroCostosTipoRef_Sels;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((long)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((long)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20CentroCostosNombre1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24CentroCostosNombre2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28CentroCostosNombre3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV71Pgmname, AV17FilterFullText, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFCentroCostosId, AV42TFCentroCostosId_To, AV43TFCentroCostosRef, AV44TFCentroCostosRef_To, AV45TFCentroCostosNombre, AV46TFCentroCostosNombre_Sel, AV47TFCentroCostosPrecioFinal, AV48TFCentroCostosPrecioFinal_To, AV49TFCentroCostosCosto, AV50TFCentroCostosCosto_To, AV51TFCentroCostosGam, AV52TFCentroCostosGam_To, AV54TFCentroCostosEstado_Sels, AV56TFCentroCostosTipoRef_Sels, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV64IsAuthorized_Update, AV65IsAuthorized_Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV72Centrocostoswwds_1_filterfulltext = AV17FilterFullText;
         AV73Centrocostoswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV74Centrocostoswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV75Centrocostoswwds_4_centrocostosnombre1 = AV20CentroCostosNombre1;
         AV76Centrocostoswwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV77Centrocostoswwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV78Centrocostoswwds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV79Centrocostoswwds_8_centrocostosnombre2 = AV24CentroCostosNombre2;
         AV80Centrocostoswwds_9_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV81Centrocostoswwds_10_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV82Centrocostoswwds_11_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV83Centrocostoswwds_12_centrocostosnombre3 = AV28CentroCostosNombre3;
         AV84Centrocostoswwds_13_tfcentrocostosid = AV41TFCentroCostosId;
         AV85Centrocostoswwds_14_tfcentrocostosid_to = AV42TFCentroCostosId_To;
         AV86Centrocostoswwds_15_tfcentrocostosref = AV43TFCentroCostosRef;
         AV87Centrocostoswwds_16_tfcentrocostosref_to = AV44TFCentroCostosRef_To;
         AV88Centrocostoswwds_17_tfcentrocostosnombre = AV45TFCentroCostosNombre;
         AV89Centrocostoswwds_18_tfcentrocostosnombre_sel = AV46TFCentroCostosNombre_Sel;
         AV90Centrocostoswwds_19_tfcentrocostospreciofinal = AV47TFCentroCostosPrecioFinal;
         AV91Centrocostoswwds_20_tfcentrocostospreciofinal_to = AV48TFCentroCostosPrecioFinal_To;
         AV92Centrocostoswwds_21_tfcentrocostoscosto = AV49TFCentroCostosCosto;
         AV93Centrocostoswwds_22_tfcentrocostoscosto_to = AV50TFCentroCostosCosto_To;
         AV94Centrocostoswwds_23_tfcentrocostosgam = AV51TFCentroCostosGam;
         AV95Centrocostoswwds_24_tfcentrocostosgam_to = AV52TFCentroCostosGam_To;
         AV96Centrocostoswwds_25_tfcentrocostosestado_sels = AV54TFCentroCostosEstado_Sels;
         AV97Centrocostoswwds_26_tfcentrocostostiporef_sels = AV56TFCentroCostosTipoRef_Sels;
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20CentroCostosNombre1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24CentroCostosNombre2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28CentroCostosNombre3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV71Pgmname, AV17FilterFullText, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFCentroCostosId, AV42TFCentroCostosId_To, AV43TFCentroCostosRef, AV44TFCentroCostosRef_To, AV45TFCentroCostosNombre, AV46TFCentroCostosNombre_Sel, AV47TFCentroCostosPrecioFinal, AV48TFCentroCostosPrecioFinal_To, AV49TFCentroCostosCosto, AV50TFCentroCostosCosto_To, AV51TFCentroCostosGam, AV52TFCentroCostosGam_To, AV54TFCentroCostosEstado_Sels, AV56TFCentroCostosTipoRef_Sels, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV64IsAuthorized_Update, AV65IsAuthorized_Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV71Pgmname = "CentroCostosWW";
         edtCentroCostosId_Enabled = 0;
         edtCentroCostosRef_Enabled = 0;
         edtCentroCostosNombre_Enabled = 0;
         edtCentroCostosPrecioFinal_Enabled = 0;
         edtCentroCostosSubTotal_Enabled = 0;
         edtCentroCostosCosto_Enabled = 0;
         edtCentroCostosGam_Enabled = 0;
         cmbCentroCostosEstado.Enabled = 0;
         cmbCentroCostosTipoRef.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3S0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E273S2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV38ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV66AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV57DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV35ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_111 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_111"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV59GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV60GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV61GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( "DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( "DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( "DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( "DDO_MANAGEFILTERS_Cls");
            Gridpaginationbar_Class = cgiGet( "GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Pagestoshow"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( "GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( "GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( "GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( "GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( "GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( "GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( "GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( "GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( "GRIDPAGINATIONBAR_Rowsperpagecaption");
            Ddo_agexport_Icontype = cgiGet( "DDO_AGEXPORT_Icontype");
            Ddo_agexport_Icon = cgiGet( "DDO_AGEXPORT_Icon");
            Ddo_agexport_Caption = cgiGet( "DDO_AGEXPORT_Caption");
            Ddo_agexport_Cls = cgiGet( "DDO_AGEXPORT_Cls");
            Ddo_agexport_Titlecontrolidtoreplace = cgiGet( "DDO_AGEXPORT_Titlecontrolidtoreplace");
            Ddc_subscriptions_Icontype = cgiGet( "DDC_SUBSCRIPTIONS_Icontype");
            Ddc_subscriptions_Icon = cgiGet( "DDC_SUBSCRIPTIONS_Icon");
            Ddc_subscriptions_Caption = cgiGet( "DDC_SUBSCRIPTIONS_Caption");
            Ddc_subscriptions_Tooltip = cgiGet( "DDC_SUBSCRIPTIONS_Tooltip");
            Ddc_subscriptions_Cls = cgiGet( "DDC_SUBSCRIPTIONS_Cls");
            Ddc_subscriptions_Titlecontrolidtoreplace = cgiGet( "DDC_SUBSCRIPTIONS_Titlecontrolidtoreplace");
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( "DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( "DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Fixable = cgiGet( "DDO_GRID_Fixable");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( "DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Allowmultipleselection = cgiGet( "DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
            Innewwindow1_Width = cgiGet( "INNEWWINDOW1_Width");
            Innewwindow1_Height = cgiGet( "INNEWWINDOW1_Height");
            Innewwindow1_Target = cgiGet( "INNEWWINDOW1_Target");
            Ddo_gridcolumnsselector_Icontype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icontype");
            Ddo_gridcolumnsselector_Icon = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icon");
            Ddo_gridcolumnsselector_Caption = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Caption");
            Ddo_gridcolumnsselector_Tooltip = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Tooltip");
            Ddo_gridcolumnsselector_Cls = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Cls");
            Ddo_gridcolumnsselector_Dropdownoptionstype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype");
            Ddo_gridcolumnsselector_Gridinternalname = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname");
            Ddo_gridcolumnsselector_Titlecontrolidtoreplace = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascolumnsselector"));
            Grid_empowerer_Fixedcolumns = cgiGet( "GRID_EMPOWERER_Fixedcolumns");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            AV17FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV18DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
            AV20CentroCostosNombre1 = cgiGet( edtavCentrocostosnombre1_Internalname);
            AssignAttri("", false, "AV20CentroCostosNombre1", AV20CentroCostosNombre1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV22DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
            AV24CentroCostosNombre2 = cgiGet( edtavCentrocostosnombre2_Internalname);
            AssignAttri("", false, "AV24CentroCostosNombre2", AV24CentroCostosNombre2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV26DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AV28CentroCostosNombre3 = cgiGet( edtavCentrocostosnombre3_Internalname);
            AssignAttri("", false, "AV28CentroCostosNombre3", AV28CentroCostosNombre3);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV14OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV15OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV18DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV19DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCENTROCOSTOSNOMBRE1"), AV20CentroCostosNombre1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV22DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV23DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCENTROCOSTOSNOMBRE2"), AV24CentroCostosNombre2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV26DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV27DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCENTROCOSTOSNOMBRE3"), AV28CentroCostosNombre3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E273S2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E273S2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 50;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         lblJsdynamicfilters_Caption = "";
         AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV18DynamicFiltersSelector1 = "CENTROCOSTOSNOMBRE";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV22DynamicFiltersSelector2 = "CENTROCOSTOSNOMBRE";
         AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV26DynamicFiltersSelector3 = "CENTROCOSTOSNOMBRE";
         AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         imgAdddynamicfilters1_Jsonclick = StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Jsonclick", imgAdddynamicfilters1_Jsonclick, true);
         imgRemovedynamicfilters1_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Jsonclick", imgRemovedynamicfilters1_Jsonclick, true);
         imgAdddynamicfilters2_Jsonclick = StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Jsonclick", imgAdddynamicfilters2_Jsonclick, true);
         imgRemovedynamicfilters2_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Jsonclick", imgRemovedynamicfilters2_Jsonclick, true);
         imgRemovedynamicfilters3_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters3_Internalname, "Jsonclick", imgRemovedynamicfilters3_Jsonclick, true);
         Ddo_agexport_Titlecontrolidtoreplace = bttBtnagexport_Internalname;
         ucDdo_agexport.SendProperty(context, "", false, Ddo_agexport_Internalname, "TitleControlIdToReplace", Ddo_agexport_Titlecontrolidtoreplace);
         AV66AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV67AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV67AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportCaption", "");
         AV67AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV67AGExportDataItem.gxTpr_Eventkey = "Export";
         AV67AGExportDataItem.gxTpr_Isdivider = false;
         AV66AGExportData.Add(AV67AGExportDataItem, 0);
         AV67AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV67AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportReportCaption", "");
         AV67AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV67AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV67AGExportDataItem.gxTpr_Isdivider = false;
         AV66AGExportData.Add(AV67AGExportDataItem, 0);
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( "Centro de Costoss", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV14OrderedBy < 1 )
         {
            AV14OrderedBy = 1;
            AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV57DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV57DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E283S2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV40ManageFiltersExecutionStep == 1 )
         {
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV40ManageFiltersExecutionStep == 2 )
         {
            AV40ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV37Session.Get("CentroCostosWWColumnsSelector"), "") != 0 )
         {
            AV33ColumnsSelectorXML = AV37Session.Get("CentroCostosWWColumnsSelector");
            AV35ColumnsSelector.FromXml(AV33ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtCentroCostosId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCentroCostosId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCentroCostosId_Visible), 5, 0), !bGXsfl_111_Refreshing);
         edtCentroCostosRef_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCentroCostosRef_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCentroCostosRef_Visible), 5, 0), !bGXsfl_111_Refreshing);
         edtCentroCostosNombre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCentroCostosNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCentroCostosNombre_Visible), 5, 0), !bGXsfl_111_Refreshing);
         edtCentroCostosPrecioFinal_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCentroCostosPrecioFinal_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCentroCostosPrecioFinal_Visible), 5, 0), !bGXsfl_111_Refreshing);
         edtCentroCostosCosto_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCentroCostosCosto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCentroCostosCosto_Visible), 5, 0), !bGXsfl_111_Refreshing);
         edtCentroCostosGam_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCentroCostosGam_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCentroCostosGam_Visible), 5, 0), !bGXsfl_111_Refreshing);
         cmbCentroCostosEstado.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbCentroCostosEstado_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbCentroCostosEstado.Visible), 5, 0), !bGXsfl_111_Refreshing);
         cmbCentroCostosTipoRef.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbCentroCostosTipoRef_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbCentroCostosTipoRef.Visible), 5, 0), !bGXsfl_111_Refreshing);
         AV59GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV59GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV59GridCurrentPage), 10, 0));
         AV60GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV60GridPageCount", StringUtil.LTrimStr( (decimal)(AV60GridPageCount), 10, 0));
         GXt_char2 = AV61GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV71Pgmname, out  GXt_char2) ;
         AV61GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV61GridAppliedFilters", AV61GridAppliedFilters);
         AV72Centrocostoswwds_1_filterfulltext = AV17FilterFullText;
         AV73Centrocostoswwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV74Centrocostoswwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV75Centrocostoswwds_4_centrocostosnombre1 = AV20CentroCostosNombre1;
         AV76Centrocostoswwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV77Centrocostoswwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV78Centrocostoswwds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV79Centrocostoswwds_8_centrocostosnombre2 = AV24CentroCostosNombre2;
         AV80Centrocostoswwds_9_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV81Centrocostoswwds_10_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV82Centrocostoswwds_11_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV83Centrocostoswwds_12_centrocostosnombre3 = AV28CentroCostosNombre3;
         AV84Centrocostoswwds_13_tfcentrocostosid = AV41TFCentroCostosId;
         AV85Centrocostoswwds_14_tfcentrocostosid_to = AV42TFCentroCostosId_To;
         AV86Centrocostoswwds_15_tfcentrocostosref = AV43TFCentroCostosRef;
         AV87Centrocostoswwds_16_tfcentrocostosref_to = AV44TFCentroCostosRef_To;
         AV88Centrocostoswwds_17_tfcentrocostosnombre = AV45TFCentroCostosNombre;
         AV89Centrocostoswwds_18_tfcentrocostosnombre_sel = AV46TFCentroCostosNombre_Sel;
         AV90Centrocostoswwds_19_tfcentrocostospreciofinal = AV47TFCentroCostosPrecioFinal;
         AV91Centrocostoswwds_20_tfcentrocostospreciofinal_to = AV48TFCentroCostosPrecioFinal_To;
         AV92Centrocostoswwds_21_tfcentrocostoscosto = AV49TFCentroCostosCosto;
         AV93Centrocostoswwds_22_tfcentrocostoscosto_to = AV50TFCentroCostosCosto_To;
         AV94Centrocostoswwds_23_tfcentrocostosgam = AV51TFCentroCostosGam;
         AV95Centrocostoswwds_24_tfcentrocostosgam_to = AV52TFCentroCostosGam_To;
         AV96Centrocostoswwds_25_tfcentrocostosestado_sels = AV54TFCentroCostosEstado_Sels;
         AV97Centrocostoswwds_26_tfcentrocostostiporef_sels = AV56TFCentroCostosTipoRef_Sels;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E123S2( )
      {
         /* Gridpaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgrid_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Next") == 0 )
         {
            subgrid_nextpage( ) ;
         }
         else
         {
            AV58PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV58PageToGo) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E133S2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E163S2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
            AV15OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CentroCostosId") == 0 )
            {
               AV41TFCentroCostosId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV41TFCentroCostosId", StringUtil.LTrimStr( (decimal)(AV41TFCentroCostosId), 18, 0));
               AV42TFCentroCostosId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV42TFCentroCostosId_To", StringUtil.LTrimStr( (decimal)(AV42TFCentroCostosId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CentroCostosRef") == 0 )
            {
               AV43TFCentroCostosRef = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV43TFCentroCostosRef", StringUtil.LTrimStr( (decimal)(AV43TFCentroCostosRef), 18, 0));
               AV44TFCentroCostosRef_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV44TFCentroCostosRef_To", StringUtil.LTrimStr( (decimal)(AV44TFCentroCostosRef_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CentroCostosNombre") == 0 )
            {
               AV45TFCentroCostosNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV45TFCentroCostosNombre", AV45TFCentroCostosNombre);
               AV46TFCentroCostosNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV46TFCentroCostosNombre_Sel", AV46TFCentroCostosNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CentroCostosPrecioFinal") == 0 )
            {
               AV47TFCentroCostosPrecioFinal = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV47TFCentroCostosPrecioFinal", StringUtil.LTrimStr( AV47TFCentroCostosPrecioFinal, 18, 2));
               AV48TFCentroCostosPrecioFinal_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV48TFCentroCostosPrecioFinal_To", StringUtil.LTrimStr( AV48TFCentroCostosPrecioFinal_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CentroCostosCosto") == 0 )
            {
               AV49TFCentroCostosCosto = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV49TFCentroCostosCosto", StringUtil.LTrimStr( AV49TFCentroCostosCosto, 18, 2));
               AV50TFCentroCostosCosto_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV50TFCentroCostosCosto_To", StringUtil.LTrimStr( AV50TFCentroCostosCosto_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CentroCostosGam") == 0 )
            {
               AV51TFCentroCostosGam = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV51TFCentroCostosGam", StringUtil.LTrimStr( AV51TFCentroCostosGam, 18, 2));
               AV52TFCentroCostosGam_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV52TFCentroCostosGam_To", StringUtil.LTrimStr( AV52TFCentroCostosGam_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CentroCostosEstado") == 0 )
            {
               AV53TFCentroCostosEstado_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV53TFCentroCostosEstado_SelsJson", AV53TFCentroCostosEstado_SelsJson);
               AV54TFCentroCostosEstado_Sels.FromJSonString(AV53TFCentroCostosEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CentroCostosTipoRef") == 0 )
            {
               AV55TFCentroCostosTipoRef_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV55TFCentroCostosTipoRef_SelsJson", AV55TFCentroCostosTipoRef_SelsJson);
               AV56TFCentroCostosTipoRef_Sels.FromJSonString(AV55TFCentroCostosTipoRef_SelsJson, null);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV56TFCentroCostosTipoRef_Sels", AV56TFCentroCostosTipoRef_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV54TFCentroCostosEstado_Sels", AV54TFCentroCostosEstado_Sels);
      }

      private void E293S2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            cmbavGridactions.removeAllItems();
            cmbavGridactions.addItem("0", ";fa fa-bars", 0);
            cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
            if ( AV64IsAuthorized_Update )
            {
               cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_update", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
            }
            if ( AV65IsAuthorized_Delete )
            {
               cmbavGridactions.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "fa fa-times", "", "", "", "", "", "", ""), 0);
            }
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "centrocostosview.aspx"+UrlEncode(StringUtil.LTrimStr(A461CentroCostosId,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(A462CentroCostosRef,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtCentroCostosNombre_Link = formatLink("centrocostosview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 111;
            }
            sendrow_1112( ) ;
         }
         GRID_nEOF = (short)(((subGrid_Rows==0)||(GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_111_Refreshing )
         {
            context.DoAjaxLoad(111, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV62GridActions), 4, 0));
      }

      protected void E173S2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV33ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV35ColumnsSelector.FromJSonString(AV33ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "CentroCostosWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV33ColumnsSelectorXML)) ? "" : AV35ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E223S2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV21DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E183S2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV29DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         AV30DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV30DynamicFiltersIgnoreFirst", AV30DynamicFiltersIgnoreFirst);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV29DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         AV30DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV30DynamicFiltersIgnoreFirst", AV30DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20CentroCostosNombre1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24CentroCostosNombre2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28CentroCostosNombre3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV71Pgmname, AV17FilterFullText, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFCentroCostosId, AV42TFCentroCostosId_To, AV43TFCentroCostosRef, AV44TFCentroCostosRef_To, AV45TFCentroCostosNombre, AV46TFCentroCostosNombre_Sel, AV47TFCentroCostosPrecioFinal, AV48TFCentroCostosPrecioFinal_To, AV49TFCentroCostosCosto, AV50TFCentroCostosCosto_To, AV51TFCentroCostosGam, AV52TFCentroCostosGam_To, AV54TFCentroCostosEstado_Sels, AV56TFCentroCostosTipoRef_Sels, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV64IsAuthorized_Update, AV65IsAuthorized_Delete) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E233S2( )
      {
         /* Dynamicfiltersselector1_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E243S2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV25DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E193S2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV29DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         AV21DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV29DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20CentroCostosNombre1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24CentroCostosNombre2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28CentroCostosNombre3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV71Pgmname, AV17FilterFullText, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFCentroCostosId, AV42TFCentroCostosId_To, AV43TFCentroCostosRef, AV44TFCentroCostosRef_To, AV45TFCentroCostosNombre, AV46TFCentroCostosNombre_Sel, AV47TFCentroCostosPrecioFinal, AV48TFCentroCostosPrecioFinal_To, AV49TFCentroCostosCosto, AV50TFCentroCostosCosto_To, AV51TFCentroCostosGam, AV52TFCentroCostosGam_To, AV54TFCentroCostosEstado_Sels, AV56TFCentroCostosTipoRef_Sels, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV64IsAuthorized_Update, AV65IsAuthorized_Delete) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E253S2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E203S2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV29DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         AV25DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV29DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20CentroCostosNombre1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24CentroCostosNombre2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28CentroCostosNombre3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV71Pgmname, AV17FilterFullText, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFCentroCostosId, AV42TFCentroCostosId_To, AV43TFCentroCostosRef, AV44TFCentroCostosRef_To, AV45TFCentroCostosNombre, AV46TFCentroCostosNombre_Sel, AV47TFCentroCostosPrecioFinal, AV48TFCentroCostosPrecioFinal_To, AV49TFCentroCostosCosto, AV50TFCentroCostosCosto_To, AV51TFCentroCostosGam, AV52TFCentroCostosGam_To, AV54TFCentroCostosEstado_Sels, AV56TFCentroCostosTipoRef_Sels, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV64IsAuthorized_Update, AV65IsAuthorized_Delete) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E263S2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E113S2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S192 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("CentroCostosWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV71Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("CentroCostosWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV39ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "CentroCostosWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV39ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV39ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S242 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV71Pgmname+"GridState",  AV39ManageFiltersXml) ;
               AV11GridState.FromXml(AV39ManageFiltersXml, null, "", "");
               AV14OrderedBy = AV11GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
               AV15OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S172 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S252 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
               S232 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV54TFCentroCostosEstado_Sels", AV54TFCentroCostosEstado_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV56TFCentroCostosTipoRef_Sels", AV56TFCentroCostosTipoRef_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E303S2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV62GridActions == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV62GridActions == 2 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S272 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV62GridActions == 3 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S282 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV62GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV62GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV62GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E213S2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "centrocostos.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("centrocostos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E143S2( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S292 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "ExportReport") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORTREPORT' */
            S302 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV56TFCentroCostosTipoRef_Sels", AV56TFCentroCostosTipoRef_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV54TFCentroCostosEstado_Sels", AV54TFCentroCostosEstado_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E153S2( )
      {
         /* Ddc_subscriptions_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.subscriptions.wwp_subscriptionspanel", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0136",(string)"",(string)"CentroCostos",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0136"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S172( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV14OrderedBy), 4, 0))+":"+(AV15OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S202( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV35ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "CentroCostosId",  "",  "Código CC:",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "CentroCostosRef",  "",  "Referencia Nro:",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "CentroCostosNombre",  "",  "Nombre:",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "CentroCostosPrecioFinal",  "",  "Precio Final:",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "CentroCostosCosto",  "",  "Costo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "CentroCostosGam",  "",  "Ganancia",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "CentroCostosEstado",  "",  "Estado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "CentroCostosTipoRef",  "",  "Tipo Referencia:",  true,  "") ;
         GXt_char2 = AV34UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "CentroCostosWWColumnsSelector", out  GXt_char2) ;
         AV34UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV34UserCustomValue)) ) )
         {
            AV36ColumnsSelectorAux.FromXml(AV34UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV36ColumnsSelectorAux, ref  AV35ColumnsSelector) ;
         }
      }

      protected void S182( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean3 = AV64IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCentroCostos_Update", out  GXt_boolean3) ;
         AV64IsAuthorized_Update = GXt_boolean3;
         AssignAttri("", false, "AV64IsAuthorized_Update", AV64IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV64IsAuthorized_Update, context));
         GXt_boolean3 = AV65IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCentroCostos_Delete", out  GXt_boolean3) ;
         AV65IsAuthorized_Delete = GXt_boolean3;
         AssignAttri("", false, "AV65IsAuthorized_Delete", AV65IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV65IsAuthorized_Delete, context));
         GXt_boolean3 = AV68TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCentroCostos_Insert", out  GXt_boolean3) ;
         AV68TempBoolean = GXt_boolean3;
         if ( ! ( AV68TempBoolean ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         GXt_boolean3 = AV68TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "SubscriptionsPanel", out  GXt_boolean3) ;
         AV68TempBoolean = GXt_boolean3;
         if ( ! ( AV68TempBoolean && ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "CentroCostos",  1) ) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavCentrocostosnombre1_Visible = 0;
         AssignProp("", false, edtavCentrocostosnombre1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCentrocostosnombre1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CENTROCOSTOSNOMBRE") == 0 )
         {
            edtavCentrocostosnombre1_Visible = 1;
            AssignProp("", false, edtavCentrocostosnombre1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCentrocostosnombre1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavCentrocostosnombre2_Visible = 0;
         AssignProp("", false, edtavCentrocostosnombre2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCentrocostosnombre2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CENTROCOSTOSNOMBRE") == 0 )
         {
            edtavCentrocostosnombre2_Visible = 1;
            AssignProp("", false, edtavCentrocostosnombre2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCentrocostosnombre2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavCentrocostosnombre3_Visible = 0;
         AssignProp("", false, edtavCentrocostosnombre3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCentrocostosnombre3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CENTROCOSTOSNOMBRE") == 0 )
         {
            edtavCentrocostosnombre3_Visible = 1;
            AssignProp("", false, edtavCentrocostosnombre3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCentrocostosnombre3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S222( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV21DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
         AV22DynamicFiltersSelector2 = "CENTROCOSTOSNOMBRE";
         AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         AV23DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AV24CentroCostosNombre2 = "";
         AssignAttri("", false, "AV24CentroCostosNombre2", AV24CentroCostosNombre2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV25DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         AV26DynamicFiltersSelector3 = "CENTROCOSTOSNOMBRE";
         AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         AV27DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AV28CentroCostosNombre3 = "";
         AssignAttri("", false, "AV28CentroCostosNombre3", AV28CentroCostosNombre3);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV38ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "CentroCostosWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV38ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S242( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV17FilterFullText = "";
         AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
         AV41TFCentroCostosId = 0;
         AssignAttri("", false, "AV41TFCentroCostosId", StringUtil.LTrimStr( (decimal)(AV41TFCentroCostosId), 18, 0));
         AV42TFCentroCostosId_To = 0;
         AssignAttri("", false, "AV42TFCentroCostosId_To", StringUtil.LTrimStr( (decimal)(AV42TFCentroCostosId_To), 18, 0));
         AV43TFCentroCostosRef = 0;
         AssignAttri("", false, "AV43TFCentroCostosRef", StringUtil.LTrimStr( (decimal)(AV43TFCentroCostosRef), 18, 0));
         AV44TFCentroCostosRef_To = 0;
         AssignAttri("", false, "AV44TFCentroCostosRef_To", StringUtil.LTrimStr( (decimal)(AV44TFCentroCostosRef_To), 18, 0));
         AV45TFCentroCostosNombre = "";
         AssignAttri("", false, "AV45TFCentroCostosNombre", AV45TFCentroCostosNombre);
         AV46TFCentroCostosNombre_Sel = "";
         AssignAttri("", false, "AV46TFCentroCostosNombre_Sel", AV46TFCentroCostosNombre_Sel);
         AV47TFCentroCostosPrecioFinal = 0;
         AssignAttri("", false, "AV47TFCentroCostosPrecioFinal", StringUtil.LTrimStr( AV47TFCentroCostosPrecioFinal, 18, 2));
         AV48TFCentroCostosPrecioFinal_To = 0;
         AssignAttri("", false, "AV48TFCentroCostosPrecioFinal_To", StringUtil.LTrimStr( AV48TFCentroCostosPrecioFinal_To, 18, 2));
         AV49TFCentroCostosCosto = 0;
         AssignAttri("", false, "AV49TFCentroCostosCosto", StringUtil.LTrimStr( AV49TFCentroCostosCosto, 18, 2));
         AV50TFCentroCostosCosto_To = 0;
         AssignAttri("", false, "AV50TFCentroCostosCosto_To", StringUtil.LTrimStr( AV50TFCentroCostosCosto_To, 18, 2));
         AV51TFCentroCostosGam = 0;
         AssignAttri("", false, "AV51TFCentroCostosGam", StringUtil.LTrimStr( AV51TFCentroCostosGam, 18, 2));
         AV52TFCentroCostosGam_To = 0;
         AssignAttri("", false, "AV52TFCentroCostosGam_To", StringUtil.LTrimStr( AV52TFCentroCostosGam_To, 18, 2));
         AV54TFCentroCostosEstado_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV56TFCentroCostosTipoRef_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV18DynamicFiltersSelector1 = "CENTROCOSTOSNOMBRE";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         AV19DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AV20CentroCostosNombre1 = "";
         AssignAttri("", false, "AV20CentroCostosNombre1", AV20CentroCostosNombre1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S262( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "centrocostosview.aspx"+UrlEncode(StringUtil.LTrimStr(A461CentroCostosId,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(A462CentroCostosRef,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("centrocostosview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S272( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "centrocostos.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A461CentroCostosId,18,0));
         CallWebObject(formatLink("centrocostos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S282( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "centrocostos.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A461CentroCostosId,18,0));
         CallWebObject(formatLink("centrocostos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV37Session.Get(AV71Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV71Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV37Session.Get(AV71Pgmname+"GridState"), null, "", "");
         }
         AV14OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
         AV15OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S252 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV11GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV11GridState.gxTpr_Currentpage) ;
      }

      protected void S252( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV98GXV1 = 1;
         while ( AV98GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV98GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV17FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSID") == 0 )
            {
               AV41TFCentroCostosId = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV41TFCentroCostosId", StringUtil.LTrimStr( (decimal)(AV41TFCentroCostosId), 18, 0));
               AV42TFCentroCostosId_To = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV42TFCentroCostosId_To", StringUtil.LTrimStr( (decimal)(AV42TFCentroCostosId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSREF") == 0 )
            {
               AV43TFCentroCostosRef = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV43TFCentroCostosRef", StringUtil.LTrimStr( (decimal)(AV43TFCentroCostosRef), 18, 0));
               AV44TFCentroCostosRef_To = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV44TFCentroCostosRef_To", StringUtil.LTrimStr( (decimal)(AV44TFCentroCostosRef_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSNOMBRE") == 0 )
            {
               AV45TFCentroCostosNombre = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV45TFCentroCostosNombre", AV45TFCentroCostosNombre);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSNOMBRE_SEL") == 0 )
            {
               AV46TFCentroCostosNombre_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV46TFCentroCostosNombre_Sel", AV46TFCentroCostosNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSPRECIOFINAL") == 0 )
            {
               AV47TFCentroCostosPrecioFinal = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV47TFCentroCostosPrecioFinal", StringUtil.LTrimStr( AV47TFCentroCostosPrecioFinal, 18, 2));
               AV48TFCentroCostosPrecioFinal_To = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV48TFCentroCostosPrecioFinal_To", StringUtil.LTrimStr( AV48TFCentroCostosPrecioFinal_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSCOSTO") == 0 )
            {
               AV49TFCentroCostosCosto = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV49TFCentroCostosCosto", StringUtil.LTrimStr( AV49TFCentroCostosCosto, 18, 2));
               AV50TFCentroCostosCosto_To = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV50TFCentroCostosCosto_To", StringUtil.LTrimStr( AV50TFCentroCostosCosto_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSGAM") == 0 )
            {
               AV51TFCentroCostosGam = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV51TFCentroCostosGam", StringUtil.LTrimStr( AV51TFCentroCostosGam, 18, 2));
               AV52TFCentroCostosGam_To = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV52TFCentroCostosGam_To", StringUtil.LTrimStr( AV52TFCentroCostosGam_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSESTADO_SEL") == 0 )
            {
               AV53TFCentroCostosEstado_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV53TFCentroCostosEstado_SelsJson", AV53TFCentroCostosEstado_SelsJson);
               AV54TFCentroCostosEstado_Sels.FromJSonString(AV53TFCentroCostosEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSTIPOREF_SEL") == 0 )
            {
               AV55TFCentroCostosTipoRef_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV55TFCentroCostosTipoRef_SelsJson", AV55TFCentroCostosTipoRef_SelsJson);
               AV56TFCentroCostosTipoRef_Sels.FromJSonString(AV55TFCentroCostosTipoRef_SelsJson, null);
            }
            AV98GXV1 = (int)(AV98GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV46TFCentroCostosNombre_Sel)),  AV46TFCentroCostosNombre_Sel, out  GXt_char2) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV54TFCentroCostosEstado_Sels.Count==0),  AV53TFCentroCostosEstado_SelsJson, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV56TFCentroCostosTipoRef_Sels.Count==0),  AV55TFCentroCostosTipoRef_SelsJson, out  GXt_char6) ;
         Ddo_grid_Selectedvalue_set = "||"+GXt_char2+"||||"+GXt_char5+"|"+GXt_char6;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV45TFCentroCostosNombre)),  AV45TFCentroCostosNombre, out  GXt_char6) ;
         Ddo_grid_Filteredtext_set = ((0==AV41TFCentroCostosId) ? "" : StringUtil.Str( (decimal)(AV41TFCentroCostosId), 18, 0))+"|"+((0==AV43TFCentroCostosRef) ? "" : StringUtil.Str( (decimal)(AV43TFCentroCostosRef), 18, 0))+"|"+GXt_char6+"|"+((Convert.ToDecimal(0)==AV47TFCentroCostosPrecioFinal) ? "" : StringUtil.Str( AV47TFCentroCostosPrecioFinal, 18, 2))+"|"+((Convert.ToDecimal(0)==AV49TFCentroCostosCosto) ? "" : StringUtil.Str( AV49TFCentroCostosCosto, 18, 2))+"|"+((Convert.ToDecimal(0)==AV51TFCentroCostosGam) ? "" : StringUtil.Str( AV51TFCentroCostosGam, 18, 2))+"||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV42TFCentroCostosId_To) ? "" : StringUtil.Str( (decimal)(AV42TFCentroCostosId_To), 18, 0))+"|"+((0==AV44TFCentroCostosRef_To) ? "" : StringUtil.Str( (decimal)(AV44TFCentroCostosRef_To), 18, 0))+"||"+((Convert.ToDecimal(0)==AV48TFCentroCostosPrecioFinal_To) ? "" : StringUtil.Str( AV48TFCentroCostosPrecioFinal_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV50TFCentroCostosCosto_To) ? "" : StringUtil.Str( AV50TFCentroCostosCosto_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV52TFCentroCostosGam_To) ? "" : StringUtil.Str( AV52TFCentroCostosGam_To, 18, 2))+"||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S232( )
      {
         /* 'LOADDYNFILTERSSTATE' Routine */
         returnInSub = false;
         imgAdddynamicfilters1_Visible = 1;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 0;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         imgAdddynamicfilters2_Visible = 1;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 0;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(1));
            AV18DynamicFiltersSelector1 = AV13GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CENTROCOSTOSNOMBRE") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV20CentroCostosNombre1 = AV13GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV20CentroCostosNombre1", AV20CentroCostosNombre1);
            }
            /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               lblJsdynamicfilters_Caption = "<script type=\"text/javascript\">$(document).ready(function() {";
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               imgAdddynamicfilters1_Visible = 0;
               AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
               imgRemovedynamicfilters1_Visible = 1;
               AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
               AV21DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
               AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV13GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CENTROCOSTOSNOMBRE") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV24CentroCostosNombre2 = AV13GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV24CentroCostosNombre2", AV24CentroCostosNombre2);
               }
               /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
               S132 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
                  AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
                  imgAdddynamicfilters2_Visible = 0;
                  AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
                  imgRemovedynamicfilters2_Visible = 1;
                  AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
                  AV25DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
                  AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV13GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CENTROCOSTOSNOMBRE") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV28CentroCostosNombre3 = AV13GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV28CentroCostosNombre3", AV28CentroCostosNombre3);
                  }
                  /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
                  S142 ();
                  if ( returnInSub )
                  {
                     returnInSub = true;
                     if (true) return;
                  }
               }
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+"});</script>";
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
            }
         }
         if ( AV29DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S192( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV37Session.Get(AV71Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)),  0,  AV17FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFCENTROCOSTOSID",  context.GetMessage( "Código CC:", ""),  !((0==AV41TFCentroCostosId)&&(0==AV42TFCentroCostosId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV41TFCentroCostosId), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV42TFCentroCostosId_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFCENTROCOSTOSREF",  context.GetMessage( "Referencia Nro:", ""),  !((0==AV43TFCentroCostosRef)&&(0==AV44TFCentroCostosRef_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV43TFCentroCostosRef), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV44TFCentroCostosRef_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCENTROCOSTOSNOMBRE",  context.GetMessage( "Nombre:", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV45TFCentroCostosNombre)),  0,  AV45TFCentroCostosNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV46TFCentroCostosNombre_Sel)),  AV46TFCentroCostosNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFCENTROCOSTOSPRECIOFINAL",  context.GetMessage( "Precio Final:", ""),  !((Convert.ToDecimal(0)==AV47TFCentroCostosPrecioFinal)&&(Convert.ToDecimal(0)==AV48TFCentroCostosPrecioFinal_To)),  0,  StringUtil.Trim( StringUtil.Str( AV47TFCentroCostosPrecioFinal, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV48TFCentroCostosPrecioFinal_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFCENTROCOSTOSCOSTO",  context.GetMessage( "Costo", ""),  !((Convert.ToDecimal(0)==AV49TFCentroCostosCosto)&&(Convert.ToDecimal(0)==AV50TFCentroCostosCosto_To)),  0,  StringUtil.Trim( StringUtil.Str( AV49TFCentroCostosCosto, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV50TFCentroCostosCosto_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFCENTROCOSTOSGAM",  context.GetMessage( "Ganancia", ""),  !((Convert.ToDecimal(0)==AV51TFCentroCostosGam)&&(Convert.ToDecimal(0)==AV52TFCentroCostosGam_To)),  0,  StringUtil.Trim( StringUtil.Str( AV51TFCentroCostosGam, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV52TFCentroCostosGam_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFCENTROCOSTOSESTADO_SEL",  context.GetMessage( "Estado", ""),  !(AV54TFCentroCostosEstado_Sels.Count==0),  0,  AV54TFCentroCostosEstado_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFCENTROCOSTOSTIPOREF_SEL",  context.GetMessage( "Tipo Referencia:", ""),  !(AV56TFCentroCostosTipoRef_Sels.Count==0),  0,  AV56TFCentroCostosTipoRef_Sels.ToJSonString(false),  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV71Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S212( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV30DynamicFiltersIgnoreFirst )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV18DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CENTROCOSTOSNOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV20CentroCostosNombre1)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Nombre:", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV20CentroCostosNombre1;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV19DynamicFiltersOperator1;
            }
            if ( AV29DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV21DynamicFiltersEnabled2 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV22DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CENTROCOSTOSNOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV24CentroCostosNombre2)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Nombre:", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV24CentroCostosNombre2;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV23DynamicFiltersOperator2;
            }
            if ( AV29DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV25DynamicFiltersEnabled3 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV26DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CENTROCOSTOSNOMBRE") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV28CentroCostosNombre3)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "Nombre:", "");
               AV13GridStateDynamicFilter.gxTpr_Value = AV28CentroCostosNombre3;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV27DynamicFiltersOperator3;
            }
            if ( AV29DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
      }

      protected void S152( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV71Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "CentroCostos";
         AV37Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S292( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new centrocostoswwexport(context ).execute( out  AV31ExcelFilename, out  AV32ErrorMessage) ;
         if ( StringUtil.StrCmp(AV31ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV31ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV32ErrorMessage);
         }
      }

      protected void S302( )
      {
         /* 'DOEXPORTREPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Innewwindow1_Target = formatLink("centrocostoswwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table4_93_3S2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters3_Internalname, tblTablemergeddynamicfilters3_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator3_Internalname, context.GetMessage( "Dynamic Filters Operator3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'" + sGXsfl_111_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,97);\"", "", true, 0, "HLP_CentroCostosWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_centrocostosnombre3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCentrocostosnombre3_Internalname, context.GetMessage( "Centro Costos Nombre3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'" + sGXsfl_111_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCentrocostosnombre3_Internalname, StringUtil.RTrim( AV28CentroCostosNombre3), StringUtil.RTrim( context.localUtil.Format( AV28CentroCostosNombre3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,100);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCentrocostosnombre3_Jsonclick, 0, "Attribute", "", "", "", "", edtavCentrocostosnombre3_Visible, edtavCentrocostosnombre3_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CentroCostosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_CentroCostosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_93_3S2e( true) ;
         }
         else
         {
            wb_table4_93_3S2e( false) ;
         }
      }

      protected void wb_table3_71_3S2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters2_Internalname, tblTablemergeddynamicfilters2_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator2_Internalname, context.GetMessage( "Dynamic Filters Operator2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'" + sGXsfl_111_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"", "", true, 0, "HLP_CentroCostosWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_centrocostosnombre2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCentrocostosnombre2_Internalname, context.GetMessage( "Centro Costos Nombre2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'" + sGXsfl_111_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCentrocostosnombre2_Internalname, StringUtil.RTrim( AV24CentroCostosNombre2), StringUtil.RTrim( context.localUtil.Format( AV24CentroCostosNombre2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCentrocostosnombre2_Jsonclick, 0, "Attribute", "", "", "", "", edtavCentrocostosnombre2_Visible, edtavCentrocostosnombre2_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CentroCostosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", context.GetMessage( "WWP_DynFilterAddTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_CentroCostosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_CentroCostosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_71_3S2e( true) ;
         }
         else
         {
            wb_table3_71_3S2e( false) ;
         }
      }

      protected void wb_table2_49_3S2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters1_Internalname, tblTablemergeddynamicfilters1_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator1_Internalname, context.GetMessage( "Dynamic Filters Operator1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_111_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "", true, 0, "HLP_CentroCostosWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_centrocostosnombre1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCentrocostosnombre1_Internalname, context.GetMessage( "Centro Costos Nombre1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_111_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCentrocostosnombre1_Internalname, StringUtil.RTrim( AV20CentroCostosNombre1), StringUtil.RTrim( context.localUtil.Format( AV20CentroCostosNombre1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCentrocostosnombre1_Jsonclick, 0, "Attribute", "", "", "", "", edtavCentrocostosnombre1_Visible, edtavCentrocostosnombre1_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CentroCostosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", context.GetMessage( "WWP_DynFilterAddTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_CentroCostosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_CentroCostosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_49_3S2e( true) ;
         }
         else
         {
            wb_table2_49_3S2e( false) ;
         }
      }

      protected void wb_table1_25_3S2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablerightheader_Internalname, tblTablerightheader_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucDdo_managefilters.SetProperty("IconType", Ddo_managefilters_Icontype);
            ucDdo_managefilters.SetProperty("Icon", Ddo_managefilters_Icon);
            ucDdo_managefilters.SetProperty("Caption", Ddo_managefilters_Caption);
            ucDdo_managefilters.SetProperty("Tooltip", Ddo_managefilters_Tooltip);
            ucDdo_managefilters.SetProperty("Cls", Ddo_managefilters_Cls);
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV38ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table5_30_3S2( true) ;
         }
         else
         {
            wb_table5_30_3S2( false) ;
         }
         return  ;
      }

      protected void wb_table5_30_3S2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_25_3S2e( true) ;
         }
         else
         {
            wb_table1_25_3S2e( false) ;
         }
      }

      protected void wb_table5_30_3S2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablefilters_Internalname, tblTablefilters_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, context.GetMessage( "Filter Full Text", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_111_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV17FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV17FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_CentroCostosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_30_3S2e( true) ;
         }
         else
         {
            wb_table5_30_3S2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA3S2( ) ;
         WS3S2( ) ;
         WE3S2( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
            {
               WebComp_Wwpaux_wc.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021191841", true, true, false);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages."+StringUtil.Lower( context.GetLanguageProperty( "code"))+".js", "?"+GetCacheInvalidationToken( ), false, true, false);
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 74760), false, true, false);
         context.AddJavascriptSource("centrocostosww.js", "?202673021191841", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1112( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_111_idx;
         edtCentroCostosId_Internalname = "CENTROCOSTOSID_"+sGXsfl_111_idx;
         edtCentroCostosRef_Internalname = "CENTROCOSTOSREF_"+sGXsfl_111_idx;
         edtCentroCostosNombre_Internalname = "CENTROCOSTOSNOMBRE_"+sGXsfl_111_idx;
         edtCentroCostosPrecioFinal_Internalname = "CENTROCOSTOSPRECIOFINAL_"+sGXsfl_111_idx;
         edtCentroCostosSubTotal_Internalname = "CENTROCOSTOSSUBTOTAL_"+sGXsfl_111_idx;
         edtCentroCostosCosto_Internalname = "CENTROCOSTOSCOSTO_"+sGXsfl_111_idx;
         edtCentroCostosGam_Internalname = "CENTROCOSTOSGAM_"+sGXsfl_111_idx;
         cmbCentroCostosEstado_Internalname = "CENTROCOSTOSESTADO_"+sGXsfl_111_idx;
         cmbCentroCostosTipoRef_Internalname = "CENTROCOSTOSTIPOREF_"+sGXsfl_111_idx;
      }

      protected void SubsflControlProps_fel_1112( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_111_fel_idx;
         edtCentroCostosId_Internalname = "CENTROCOSTOSID_"+sGXsfl_111_fel_idx;
         edtCentroCostosRef_Internalname = "CENTROCOSTOSREF_"+sGXsfl_111_fel_idx;
         edtCentroCostosNombre_Internalname = "CENTROCOSTOSNOMBRE_"+sGXsfl_111_fel_idx;
         edtCentroCostosPrecioFinal_Internalname = "CENTROCOSTOSPRECIOFINAL_"+sGXsfl_111_fel_idx;
         edtCentroCostosSubTotal_Internalname = "CENTROCOSTOSSUBTOTAL_"+sGXsfl_111_fel_idx;
         edtCentroCostosCosto_Internalname = "CENTROCOSTOSCOSTO_"+sGXsfl_111_fel_idx;
         edtCentroCostosGam_Internalname = "CENTROCOSTOSGAM_"+sGXsfl_111_fel_idx;
         cmbCentroCostosEstado_Internalname = "CENTROCOSTOSESTADO_"+sGXsfl_111_fel_idx;
         cmbCentroCostosTipoRef_Internalname = "CENTROCOSTOSTIPOREF_"+sGXsfl_111_fel_idx;
      }

      protected void sendrow_1112( )
      {
         sGXsfl_111_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_111_idx), 4, 0), 4, "0");
         SubsflControlProps_1112( ) ;
         WB3S0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_111_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_111_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_111_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'" + sGXsfl_111_idx + "',111)\"";
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_111_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV62GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV62GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV62GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV62GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_111_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,112);\"",(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV62GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_111_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtCentroCostosId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A461CentroCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A461CentroCostosId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCentroCostosId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtCentroCostosRef_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosRef_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A462CentroCostosRef), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A462CentroCostosRef), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosRef_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCentroCostosRef_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCentroCostosNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosNombre_Internalname,StringUtil.RTrim( A463CentroCostosNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtCentroCostosNombre_Link,(string)"",(string)"",(string)"",(string)edtCentroCostosNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCentroCostosNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtCentroCostosPrecioFinal_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosPrecioFinal_Internalname,StringUtil.LTrim( StringUtil.NToC( A464CentroCostosPrecioFinal, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A464CentroCostosPrecioFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosPrecioFinal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCentroCostosPrecioFinal_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosSubTotal_Internalname,StringUtil.LTrim( StringUtil.NToC( A469CentroCostosSubTotal, 22, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A469CentroCostosSubTotal, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosSubTotal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)22,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)0,(bool)true,(string)"Total",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtCentroCostosCosto_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosCosto_Internalname,StringUtil.LTrim( StringUtil.NToC( A475CentroCostosCosto, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A475CentroCostosCosto, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosCosto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCentroCostosCosto_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtCentroCostosGam_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosGam_Internalname,StringUtil.LTrim( StringUtil.NToC( A474CentroCostosGam, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A474CentroCostosGam, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosGam_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCentroCostosGam_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbCentroCostosEstado.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbCentroCostosEstado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CENTROCOSTOSESTADO_" + sGXsfl_111_idx;
               cmbCentroCostosEstado.Name = GXCCtl;
               cmbCentroCostosEstado.WebTags = "";
               cmbCentroCostosEstado.addItem("HAB", context.GetMessage( "Aprobado", ""), 0);
               cmbCentroCostosEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
               cmbCentroCostosEstado.addItem("PND", context.GetMessage( "Pendiente de Aprobación", ""), 0);
               cmbCentroCostosEstado.addItem("DES", context.GetMessage( "Desaprobado", ""), 0);
               if ( cmbCentroCostosEstado.ItemCount > 0 )
               {
                  A482CentroCostosEstado = cmbCentroCostosEstado.getValidValue(A482CentroCostosEstado);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbCentroCostosEstado,(string)cmbCentroCostosEstado_Internalname,StringUtil.RTrim( A482CentroCostosEstado),(short)1,(string)cmbCentroCostosEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbCentroCostosEstado.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbCentroCostosEstado.CurrentValue = StringUtil.RTrim( A482CentroCostosEstado);
            AssignProp("", false, cmbCentroCostosEstado_Internalname, "Values", (string)(cmbCentroCostosEstado.ToJavascriptSource()), !bGXsfl_111_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbCentroCostosTipoRef.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbCentroCostosTipoRef.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CENTROCOSTOSTIPOREF_" + sGXsfl_111_idx;
               cmbCentroCostosTipoRef.Name = GXCCtl;
               cmbCentroCostosTipoRef.WebTags = "";
               cmbCentroCostosTipoRef.addItem("S", context.GetMessage( "Servicios", ""), 0);
               cmbCentroCostosTipoRef.addItem("O", context.GetMessage( "Otros", ""), 0);
               if ( cmbCentroCostosTipoRef.ItemCount > 0 )
               {
                  A487CentroCostosTipoRef = cmbCentroCostosTipoRef.getValidValue(A487CentroCostosTipoRef);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbCentroCostosTipoRef,(string)cmbCentroCostosTipoRef_Internalname,StringUtil.RTrim( A487CentroCostosTipoRef),(short)1,(string)cmbCentroCostosTipoRef_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbCentroCostosTipoRef.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbCentroCostosTipoRef.CurrentValue = StringUtil.RTrim( A487CentroCostosTipoRef);
            AssignProp("", false, cmbCentroCostosTipoRef_Internalname, "Values", (string)(cmbCentroCostosTipoRef.ToJavascriptSource()), !bGXsfl_111_Refreshing);
            send_integrity_lvl_hashes3S2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_111_idx = ((subGrid_Islastpage==1)&&(nGXsfl_111_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_111_idx+1);
            sGXsfl_111_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_111_idx), 4, 0), 4, "0");
            SubsflControlProps_1112( ) ;
         }
         /* End function sendrow_1112 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("CENTROCOSTOSNOMBRE", context.GetMessage( "Nombre:", ""), 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV18DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV18DynamicFiltersSelector1);
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
         cmbavDynamicfiltersoperator1.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("CENTROCOSTOSNOMBRE", context.GetMessage( "Nombre:", ""), 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV22DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV22DynamicFiltersSelector2);
            AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
         cmbavDynamicfiltersoperator2.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("CENTROCOSTOSNOMBRE", context.GetMessage( "Nombre:", ""), 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV26DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV26DynamicFiltersSelector3);
            AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
         cmbavDynamicfiltersoperator3.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_111_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV62GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV62GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV62GridActions), 4, 0));
         }
         GXCCtl = "CENTROCOSTOSESTADO_" + sGXsfl_111_idx;
         cmbCentroCostosEstado.Name = GXCCtl;
         cmbCentroCostosEstado.WebTags = "";
         cmbCentroCostosEstado.addItem("HAB", context.GetMessage( "Aprobado", ""), 0);
         cmbCentroCostosEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbCentroCostosEstado.addItem("PND", context.GetMessage( "Pendiente de Aprobación", ""), 0);
         cmbCentroCostosEstado.addItem("DES", context.GetMessage( "Desaprobado", ""), 0);
         if ( cmbCentroCostosEstado.ItemCount > 0 )
         {
            A482CentroCostosEstado = cmbCentroCostosEstado.getValidValue(A482CentroCostosEstado);
         }
         GXCCtl = "CENTROCOSTOSTIPOREF_" + sGXsfl_111_idx;
         cmbCentroCostosTipoRef.Name = GXCCtl;
         cmbCentroCostosTipoRef.WebTags = "";
         cmbCentroCostosTipoRef.addItem("S", context.GetMessage( "Servicios", ""), 0);
         cmbCentroCostosTipoRef.addItem("O", context.GetMessage( "Otros", ""), 0);
         if ( cmbCentroCostosTipoRef.ItemCount > 0 )
         {
            A487CentroCostosTipoRef = cmbCentroCostosTipoRef.getValidValue(A487CentroCostosTipoRef);
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl111( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"111\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCentroCostosId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Código CC:", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCentroCostosRef_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Referencia Nro:", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCentroCostosNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre:", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCentroCostosPrecioFinal_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Precio Final:", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCentroCostosCosto_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Costo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCentroCostosGam_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Ganancia", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbCentroCostosEstado.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbCentroCostosTipoRef.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Tipo Referencia:", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV62GridActions), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A461CentroCostosId), 18, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A462CentroCostosRef), 18, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosRef_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A463CentroCostosNombre)));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtCentroCostosNombre_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosNombre_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A464CentroCostosPrecioFinal, 21, 2, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosPrecioFinal_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A469CentroCostosSubTotal, 22, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A475CentroCostosCosto, 21, 2, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosCosto_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A474CentroCostosGam, 21, 2, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosGam_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A482CentroCostosEstado)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbCentroCostosEstado.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A487CentroCostosTipoRef)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbCentroCostosTipoRef.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         bttBtninsert_Internalname = "BTNINSERT";
         bttBtnagexport_Internalname = "BTNAGEXPORT";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         bttBtnsubscriptions_Internalname = "BTNSUBSCRIPTIONS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         tblTablefilters_Internalname = "TABLEFILTERS";
         tblTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         lblDynamicfiltersprefix1_Internalname = "DYNAMICFILTERSPREFIX1";
         cmbavDynamicfiltersselector1_Internalname = "vDYNAMICFILTERSSELECTOR1";
         lblDynamicfiltersmiddle1_Internalname = "DYNAMICFILTERSMIDDLE1";
         cmbavDynamicfiltersoperator1_Internalname = "vDYNAMICFILTERSOPERATOR1";
         edtavCentrocostosnombre1_Internalname = "vCENTROCOSTOSNOMBRE1";
         cellFilter_centrocostosnombre1_cell_Internalname = "FILTER_CENTROCOSTOSNOMBRE1_CELL";
         imgAdddynamicfilters1_Internalname = "ADDDYNAMICFILTERS1";
         cellDynamicfilters_addfilter1_cell_Internalname = "DYNAMICFILTERS_ADDFILTER1_CELL";
         imgRemovedynamicfilters1_Internalname = "REMOVEDYNAMICFILTERS1";
         cellDynamicfilters_removefilter1_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER1_CELL";
         tblTablemergeddynamicfilters1_Internalname = "TABLEMERGEDDYNAMICFILTERS1";
         divTabledynamicfiltersrow1_Internalname = "TABLEDYNAMICFILTERSROW1";
         lblDynamicfiltersprefix2_Internalname = "DYNAMICFILTERSPREFIX2";
         cmbavDynamicfiltersselector2_Internalname = "vDYNAMICFILTERSSELECTOR2";
         lblDynamicfiltersmiddle2_Internalname = "DYNAMICFILTERSMIDDLE2";
         cmbavDynamicfiltersoperator2_Internalname = "vDYNAMICFILTERSOPERATOR2";
         edtavCentrocostosnombre2_Internalname = "vCENTROCOSTOSNOMBRE2";
         cellFilter_centrocostosnombre2_cell_Internalname = "FILTER_CENTROCOSTOSNOMBRE2_CELL";
         imgAdddynamicfilters2_Internalname = "ADDDYNAMICFILTERS2";
         cellDynamicfilters_addfilter2_cell_Internalname = "DYNAMICFILTERS_ADDFILTER2_CELL";
         imgRemovedynamicfilters2_Internalname = "REMOVEDYNAMICFILTERS2";
         cellDynamicfilters_removefilter2_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER2_CELL";
         tblTablemergeddynamicfilters2_Internalname = "TABLEMERGEDDYNAMICFILTERS2";
         divTabledynamicfiltersrow2_Internalname = "TABLEDYNAMICFILTERSROW2";
         lblDynamicfiltersprefix3_Internalname = "DYNAMICFILTERSPREFIX3";
         cmbavDynamicfiltersselector3_Internalname = "vDYNAMICFILTERSSELECTOR3";
         lblDynamicfiltersmiddle3_Internalname = "DYNAMICFILTERSMIDDLE3";
         cmbavDynamicfiltersoperator3_Internalname = "vDYNAMICFILTERSOPERATOR3";
         edtavCentrocostosnombre3_Internalname = "vCENTROCOSTOSNOMBRE3";
         cellFilter_centrocostosnombre3_cell_Internalname = "FILTER_CENTROCOSTOSNOMBRE3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtCentroCostosId_Internalname = "CENTROCOSTOSID";
         edtCentroCostosRef_Internalname = "CENTROCOSTOSREF";
         edtCentroCostosNombre_Internalname = "CENTROCOSTOSNOMBRE";
         edtCentroCostosPrecioFinal_Internalname = "CENTROCOSTOSPRECIOFINAL";
         edtCentroCostosSubTotal_Internalname = "CENTROCOSTOSSUBTOTAL";
         edtCentroCostosCosto_Internalname = "CENTROCOSTOSCOSTO";
         edtCentroCostosGam_Internalname = "CENTROCOSTOSGAM";
         cmbCentroCostosEstado_Internalname = "CENTROCOSTOSESTADO";
         cmbCentroCostosTipoRef_Internalname = "CENTROCOSTOSTIPOREF";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         cmbCentroCostosTipoRef_Jsonclick = "";
         cmbCentroCostosEstado_Jsonclick = "";
         edtCentroCostosGam_Jsonclick = "";
         edtCentroCostosCosto_Jsonclick = "";
         edtCentroCostosSubTotal_Jsonclick = "";
         edtCentroCostosPrecioFinal_Jsonclick = "";
         edtCentroCostosNombre_Jsonclick = "";
         edtCentroCostosNombre_Link = "";
         edtCentroCostosRef_Jsonclick = "";
         edtCentroCostosId_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavCentrocostosnombre1_Jsonclick = "";
         edtavCentrocostosnombre1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavCentrocostosnombre2_Jsonclick = "";
         edtavCentrocostosnombre2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavCentrocostosnombre3_Jsonclick = "";
         edtavCentrocostosnombre3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavCentrocostosnombre3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavCentrocostosnombre2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavCentrocostosnombre1_Visible = 1;
         cmbCentroCostosTipoRef.Visible = -1;
         cmbCentroCostosEstado.Visible = -1;
         edtCentroCostosGam_Visible = -1;
         edtCentroCostosCosto_Visible = -1;
         edtCentroCostosPrecioFinal_Visible = -1;
         edtCentroCostosNombre_Visible = -1;
         edtCentroCostosRef_Visible = -1;
         edtCentroCostosId_Visible = -1;
         cmbCentroCostosTipoRef.Enabled = 0;
         cmbCentroCostosEstado.Enabled = 0;
         edtCentroCostosGam_Enabled = 0;
         edtCentroCostosCosto_Enabled = 0;
         edtCentroCostosSubTotal_Enabled = 0;
         edtCentroCostosPrecioFinal_Enabled = 0;
         edtCentroCostosNombre_Enabled = 0;
         edtCentroCostosRef_Enabled = 0;
         edtCentroCostosId_Enabled = 0;
         subGrid_Sortable = 0;
         lblJsdynamicfilters_Caption = context.GetMessage( "JSDynamicFilters", "");
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         bttBtnsubscriptions_Visible = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Fixedcolumns = "L;;;;;;;;;";
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = context.GetMessage( "WWP_EditColumnsCaption", "");
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Format = "18.0|18.0||-18.2|-18.2|-18.2||";
         Ddo_grid_Datalistproc = "CentroCostosWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||||||HAB:Aprobado,DES:Deshabilitado,PND:Pendiente de Aprobación,DES:Desaprobado|S:Servicios,O:Otros";
         Ddo_grid_Allowmultipleselection = "||||||T|T";
         Ddo_grid_Datalisttype = "||Dynamic||||FixedValues|FixedValues";
         Ddo_grid_Includedatalist = "||T||||T|T";
         Ddo_grid_Filterisrange = "T|T||T|T|T||";
         Ddo_grid_Filtertype = "Numeric|Numeric|Character|Numeric|Numeric|Numeric||";
         Ddo_grid_Includefilter = "T|T|T|T|T|T||";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T|T|T|T|T||T|T";
         Ddo_grid_Columnssortvalues = "2|3|1|4|5||6|7";
         Ddo_grid_Columnids = "1:CentroCostosId|2:CentroCostosRef|3:CentroCostosNombre|4:CentroCostosPrecioFinal|6:CentroCostosCosto|7:CentroCostosGam|8:CentroCostosEstado|9:CentroCostosTipoRef";
         Ddo_grid_Gridinternalname = "";
         Ddc_subscriptions_Titlecontrolidtoreplace = "";
         Ddc_subscriptions_Cls = "ColumnsSelector";
         Ddc_subscriptions_Tooltip = "WWP_Subscriptions_Tooltip";
         Ddc_subscriptions_Caption = "";
         Ddc_subscriptions_Icon = "fas fa-rss";
         Ddc_subscriptions_Icontype = "FontIcon";
         Ddo_agexport_Titlecontrolidtoreplace = "";
         Ddo_agexport_Cls = "ColumnsSelector";
         Ddo_agexport_Icon = "fas fa-download";
         Ddo_agexport_Icontype = "FontIcon";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = context.GetMessage( "WWP_PagingCaption", "");
         Gridpaginationbar_Next = "WWP_PagingNextCaption";
         Gridpaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridpaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridpaginationbar_Rowsperpageselectedvalue = 10;
         Gridpaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridpaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridpaginationbar_Pagingcaptionposition = "Left";
         Gridpaginationbar_Pagingbuttonsposition = "Right";
         Gridpaginationbar_Pagestoshow = 5;
         Gridpaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridpaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridpaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridpaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridpaginationbar_Class = "PaginationBar";
         Ddo_managefilters_Cls = "ManageFilters";
         Ddo_managefilters_Tooltip = "WWP_ManageFiltersTooltip";
         Ddo_managefilters_Icon = "fas fa-filter";
         Ddo_managefilters_Icontype = "FontIcon";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Centro de Costoss", "");
         subGrid_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20CentroCostosNombre1',fld:'vCENTROCOSTOSNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV24CentroCostosNombre2',fld:'vCENTROCOSTOSNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV28CentroCostosNombre3',fld:'vCENTROCOSTOSNOMBRE3',pic:'',type:'char'},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41TFCentroCostosId',fld:'vTFCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV42TFCentroCostosId_To',fld:'vTFCENTROCOSTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV43TFCentroCostosRef',fld:'vTFCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV44TFCentroCostosRef_To',fld:'vTFCENTROCOSTOSREF_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFCentroCostosNombre',fld:'vTFCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV46TFCentroCostosNombre_Sel',fld:'vTFCENTROCOSTOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV47TFCentroCostosPrecioFinal',fld:'vTFCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV48TFCentroCostosPrecioFinal_To',fld:'vTFCENTROCOSTOSPRECIOFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV49TFCentroCostosCosto',fld:'vTFCENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV50TFCentroCostosCosto_To',fld:'vTFCENTROCOSTOSCOSTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV51TFCentroCostosGam',fld:'vTFCENTROCOSTOSGAM',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV52TFCentroCostosGam_To',fld:'vTFCENTROCOSTOSGAM_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV54TFCentroCostosEstado_Sels',fld:'vTFCENTROCOSTOSESTADO_SELS',pic:''},{av:'AV56TFCentroCostosTipoRef_Sels',fld:'vTFCENTROCOSTOSTIPOREF_SELS',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV64IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV65IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCentroCostosId_Visible',ctrl:'CENTROCOSTOSID',prop:'Visible'},{av:'edtCentroCostosRef_Visible',ctrl:'CENTROCOSTOSREF',prop:'Visible'},{av:'edtCentroCostosNombre_Visible',ctrl:'CENTROCOSTOSNOMBRE',prop:'Visible'},{av:'edtCentroCostosPrecioFinal_Visible',ctrl:'CENTROCOSTOSPRECIOFINAL',prop:'Visible'},{av:'edtCentroCostosCosto_Visible',ctrl:'CENTROCOSTOSCOSTO',prop:'Visible'},{av:'edtCentroCostosGam_Visible',ctrl:'CENTROCOSTOSGAM',prop:'Visible'},{av:'cmbCentroCostosEstado'},{av:'cmbCentroCostosTipoRef'},{av:'AV59GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV60GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV61GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV64IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV65IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E123S2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20CentroCostosNombre1',fld:'vCENTROCOSTOSNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV24CentroCostosNombre2',fld:'vCENTROCOSTOSNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV28CentroCostosNombre3',fld:'vCENTROCOSTOSNOMBRE3',pic:'',type:'char'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41TFCentroCostosId',fld:'vTFCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV42TFCentroCostosId_To',fld:'vTFCENTROCOSTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV43TFCentroCostosRef',fld:'vTFCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV44TFCentroCostosRef_To',fld:'vTFCENTROCOSTOSREF_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFCentroCostosNombre',fld:'vTFCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV46TFCentroCostosNombre_Sel',fld:'vTFCENTROCOSTOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV47TFCentroCostosPrecioFinal',fld:'vTFCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV48TFCentroCostosPrecioFinal_To',fld:'vTFCENTROCOSTOSPRECIOFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV49TFCentroCostosCosto',fld:'vTFCENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV50TFCentroCostosCosto_To',fld:'vTFCENTROCOSTOSCOSTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV51TFCentroCostosGam',fld:'vTFCENTROCOSTOSGAM',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV52TFCentroCostosGam_To',fld:'vTFCENTROCOSTOSGAM_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV54TFCentroCostosEstado_Sels',fld:'vTFCENTROCOSTOSESTADO_SELS',pic:''},{av:'AV56TFCentroCostosTipoRef_Sels',fld:'vTFCENTROCOSTOSTIPOREF_SELS',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV64IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV65IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCentroCostosId_Visible',ctrl:'CENTROCOSTOSID',prop:'Visible'},{av:'edtCentroCostosRef_Visible',ctrl:'CENTROCOSTOSREF',prop:'Visible'},{av:'edtCentroCostosNombre_Visible',ctrl:'CENTROCOSTOSNOMBRE',prop:'Visible'},{av:'edtCentroCostosPrecioFinal_Visible',ctrl:'CENTROCOSTOSPRECIOFINAL',prop:'Visible'},{av:'edtCentroCostosCosto_Visible',ctrl:'CENTROCOSTOSCOSTO',prop:'Visible'},{av:'edtCentroCostosGam_Visible',ctrl:'CENTROCOSTOSGAM',prop:'Visible'},{av:'cmbCentroCostosEstado'},{av:'cmbCentroCostosTipoRef'},{av:'AV59GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV60GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV61GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV64IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV65IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E133S2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20CentroCostosNombre1',fld:'vCENTROCOSTOSNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV24CentroCostosNombre2',fld:'vCENTROCOSTOSNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV28CentroCostosNombre3',fld:'vCENTROCOSTOSNOMBRE3',pic:'',type:'char'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41TFCentroCostosId',fld:'vTFCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV42TFCentroCostosId_To',fld:'vTFCENTROCOSTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV43TFCentroCostosRef',fld:'vTFCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV44TFCentroCostosRef_To',fld:'vTFCENTROCOSTOSREF_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFCentroCostosNombre',fld:'vTFCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV46TFCentroCostosNombre_Sel',fld:'vTFCENTROCOSTOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV47TFCentroCostosPrecioFinal',fld:'vTFCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV48TFCentroCostosPrecioFinal_To',fld:'vTFCENTROCOSTOSPRECIOFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV49TFCentroCostosCosto',fld:'vTFCENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV50TFCentroCostosCosto_To',fld:'vTFCENTROCOSTOSCOSTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV51TFCentroCostosGam',fld:'vTFCENTROCOSTOSGAM',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV52TFCentroCostosGam_To',fld:'vTFCENTROCOSTOSGAM_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV54TFCentroCostosEstado_Sels',fld:'vTFCENTROCOSTOSESTADO_SELS',pic:''},{av:'AV56TFCentroCostosTipoRef_Sels',fld:'vTFCENTROCOSTOSTIPOREF_SELS',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV64IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV65IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E163S2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20CentroCostosNombre1',fld:'vCENTROCOSTOSNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV24CentroCostosNombre2',fld:'vCENTROCOSTOSNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV28CentroCostosNombre3',fld:'vCENTROCOSTOSNOMBRE3',pic:'',type:'char'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41TFCentroCostosId',fld:'vTFCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV42TFCentroCostosId_To',fld:'vTFCENTROCOSTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV43TFCentroCostosRef',fld:'vTFCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV44TFCentroCostosRef_To',fld:'vTFCENTROCOSTOSREF_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFCentroCostosNombre',fld:'vTFCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV46TFCentroCostosNombre_Sel',fld:'vTFCENTROCOSTOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV47TFCentroCostosPrecioFinal',fld:'vTFCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV48TFCentroCostosPrecioFinal_To',fld:'vTFCENTROCOSTOSPRECIOFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV49TFCentroCostosCosto',fld:'vTFCENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV50TFCentroCostosCosto_To',fld:'vTFCENTROCOSTOSCOSTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV51TFCentroCostosGam',fld:'vTFCENTROCOSTOSGAM',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV52TFCentroCostosGam_To',fld:'vTFCENTROCOSTOSGAM_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV54TFCentroCostosEstado_Sels',fld:'vTFCENTROCOSTOSESTADO_SELS',pic:''},{av:'AV56TFCentroCostosTipoRef_Sels',fld:'vTFCENTROCOSTOSTIPOREF_SELS',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV64IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV65IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV55TFCentroCostosTipoRef_SelsJson',fld:'vTFCENTROCOSTOSTIPOREF_SELSJSON',pic:'',type:'vchar'},{av:'AV56TFCentroCostosTipoRef_Sels',fld:'vTFCENTROCOSTOSTIPOREF_SELS',pic:''},{av:'AV53TFCentroCostosEstado_SelsJson',fld:'vTFCENTROCOSTOSESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV54TFCentroCostosEstado_Sels',fld:'vTFCENTROCOSTOSESTADO_SELS',pic:''},{av:'AV51TFCentroCostosGam',fld:'vTFCENTROCOSTOSGAM',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV52TFCentroCostosGam_To',fld:'vTFCENTROCOSTOSGAM_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV49TFCentroCostosCosto',fld:'vTFCENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV50TFCentroCostosCosto_To',fld:'vTFCENTROCOSTOSCOSTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV47TFCentroCostosPrecioFinal',fld:'vTFCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV48TFCentroCostosPrecioFinal_To',fld:'vTFCENTROCOSTOSPRECIOFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV45TFCentroCostosNombre',fld:'vTFCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV46TFCentroCostosNombre_Sel',fld:'vTFCENTROCOSTOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV43TFCentroCostosRef',fld:'vTFCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV44TFCentroCostosRef_To',fld:'vTFCENTROCOSTOSREF_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV41TFCentroCostosId',fld:'vTFCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV42TFCentroCostosId_To',fld:'vTFCENTROCOSTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E293S2',iparms:[{av:'AV64IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV65IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'A461CentroCostosId',fld:'CENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A462CentroCostosRef',fld:'CENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV62GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'edtCentroCostosNombre_Link',ctrl:'CENTROCOSTOSNOMBRE',prop:'Link'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E173S2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20CentroCostosNombre1',fld:'vCENTROCOSTOSNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV24CentroCostosNombre2',fld:'vCENTROCOSTOSNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV28CentroCostosNombre3',fld:'vCENTROCOSTOSNOMBRE3',pic:'',type:'char'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41TFCentroCostosId',fld:'vTFCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV42TFCentroCostosId_To',fld:'vTFCENTROCOSTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV43TFCentroCostosRef',fld:'vTFCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV44TFCentroCostosRef_To',fld:'vTFCENTROCOSTOSREF_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFCentroCostosNombre',fld:'vTFCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV46TFCentroCostosNombre_Sel',fld:'vTFCENTROCOSTOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV47TFCentroCostosPrecioFinal',fld:'vTFCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV48TFCentroCostosPrecioFinal_To',fld:'vTFCENTROCOSTOSPRECIOFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV49TFCentroCostosCosto',fld:'vTFCENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV50TFCentroCostosCosto_To',fld:'vTFCENTROCOSTOSCOSTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV51TFCentroCostosGam',fld:'vTFCENTROCOSTOSGAM',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV52TFCentroCostosGam_To',fld:'vTFCENTROCOSTOSGAM_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV54TFCentroCostosEstado_Sels',fld:'vTFCENTROCOSTOSESTADO_SELS',pic:''},{av:'AV56TFCentroCostosTipoRef_Sels',fld:'vTFCENTROCOSTOSTIPOREF_SELS',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV64IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV65IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'edtCentroCostosId_Visible',ctrl:'CENTROCOSTOSID',prop:'Visible'},{av:'edtCentroCostosRef_Visible',ctrl:'CENTROCOSTOSREF',prop:'Visible'},{av:'edtCentroCostosNombre_Visible',ctrl:'CENTROCOSTOSNOMBRE',prop:'Visible'},{av:'edtCentroCostosPrecioFinal_Visible',ctrl:'CENTROCOSTOSPRECIOFINAL',prop:'Visible'},{av:'edtCentroCostosCosto_Visible',ctrl:'CENTROCOSTOSCOSTO',prop:'Visible'},{av:'edtCentroCostosGam_Visible',ctrl:'CENTROCOSTOSGAM',prop:'Visible'},{av:'cmbCentroCostosEstado'},{av:'cmbCentroCostosTipoRef'},{av:'AV59GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV60GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV61GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV64IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV65IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E223S2',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E183S2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20CentroCostosNombre1',fld:'vCENTROCOSTOSNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV24CentroCostosNombre2',fld:'vCENTROCOSTOSNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV28CentroCostosNombre3',fld:'vCENTROCOSTOSNOMBRE3',pic:'',type:'char'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41TFCentroCostosId',fld:'vTFCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV42TFCentroCostosId_To',fld:'vTFCENTROCOSTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV43TFCentroCostosRef',fld:'vTFCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV44TFCentroCostosRef_To',fld:'vTFCENTROCOSTOSREF_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFCentroCostosNombre',fld:'vTFCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV46TFCentroCostosNombre_Sel',fld:'vTFCENTROCOSTOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV47TFCentroCostosPrecioFinal',fld:'vTFCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV48TFCentroCostosPrecioFinal_To',fld:'vTFCENTROCOSTOSPRECIOFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV49TFCentroCostosCosto',fld:'vTFCENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV50TFCentroCostosCosto_To',fld:'vTFCENTROCOSTOSCOSTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV51TFCentroCostosGam',fld:'vTFCENTROCOSTOSGAM',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV52TFCentroCostosGam_To',fld:'vTFCENTROCOSTOSGAM_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV54TFCentroCostosEstado_Sels',fld:'vTFCENTROCOSTOSESTADO_SELS',pic:''},{av:'AV56TFCentroCostosTipoRef_Sels',fld:'vTFCENTROCOSTOSTIPOREF_SELS',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV64IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV65IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV24CentroCostosNombre2',fld:'vCENTROCOSTOSNOMBRE2',pic:'',type:'char'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV28CentroCostosNombre3',fld:'vCENTROCOSTOSNOMBRE3',pic:'',type:'char'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20CentroCostosNombre1',fld:'vCENTROCOSTOSNOMBRE1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavCentrocostosnombre2_Visible',ctrl:'vCENTROCOSTOSNOMBRE2',prop:'Visible'},{av:'edtavCentrocostosnombre3_Visible',ctrl:'vCENTROCOSTOSNOMBRE3',prop:'Visible'},{av:'edtavCentrocostosnombre1_Visible',ctrl:'vCENTROCOSTOSNOMBRE1',prop:'Visible'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCentroCostosId_Visible',ctrl:'CENTROCOSTOSID',prop:'Visible'},{av:'edtCentroCostosRef_Visible',ctrl:'CENTROCOSTOSREF',prop:'Visible'},{av:'edtCentroCostosNombre_Visible',ctrl:'CENTROCOSTOSNOMBRE',prop:'Visible'},{av:'edtCentroCostosPrecioFinal_Visible',ctrl:'CENTROCOSTOSPRECIOFINAL',prop:'Visible'},{av:'edtCentroCostosCosto_Visible',ctrl:'CENTROCOSTOSCOSTO',prop:'Visible'},{av:'edtCentroCostosGam_Visible',ctrl:'CENTROCOSTOSGAM',prop:'Visible'},{av:'cmbCentroCostosEstado'},{av:'cmbCentroCostosTipoRef'},{av:'AV59GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV60GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV61GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV64IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV65IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E233S2',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'edtavCentrocostosnombre1_Visible',ctrl:'vCENTROCOSTOSNOMBRE1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E243S2',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E193S2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20CentroCostosNombre1',fld:'vCENTROCOSTOSNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV24CentroCostosNombre2',fld:'vCENTROCOSTOSNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV28CentroCostosNombre3',fld:'vCENTROCOSTOSNOMBRE3',pic:'',type:'char'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41TFCentroCostosId',fld:'vTFCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV42TFCentroCostosId_To',fld:'vTFCENTROCOSTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV43TFCentroCostosRef',fld:'vTFCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV44TFCentroCostosRef_To',fld:'vTFCENTROCOSTOSREF_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFCentroCostosNombre',fld:'vTFCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV46TFCentroCostosNombre_Sel',fld:'vTFCENTROCOSTOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV47TFCentroCostosPrecioFinal',fld:'vTFCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV48TFCentroCostosPrecioFinal_To',fld:'vTFCENTROCOSTOSPRECIOFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV49TFCentroCostosCosto',fld:'vTFCENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV50TFCentroCostosCosto_To',fld:'vTFCENTROCOSTOSCOSTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV51TFCentroCostosGam',fld:'vTFCENTROCOSTOSGAM',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV52TFCentroCostosGam_To',fld:'vTFCENTROCOSTOSGAM_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV54TFCentroCostosEstado_Sels',fld:'vTFCENTROCOSTOSESTADO_SELS',pic:''},{av:'AV56TFCentroCostosTipoRef_Sels',fld:'vTFCENTROCOSTOSTIPOREF_SELS',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV64IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV65IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV24CentroCostosNombre2',fld:'vCENTROCOSTOSNOMBRE2',pic:'',type:'char'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV28CentroCostosNombre3',fld:'vCENTROCOSTOSNOMBRE3',pic:'',type:'char'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20CentroCostosNombre1',fld:'vCENTROCOSTOSNOMBRE1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavCentrocostosnombre2_Visible',ctrl:'vCENTROCOSTOSNOMBRE2',prop:'Visible'},{av:'edtavCentrocostosnombre3_Visible',ctrl:'vCENTROCOSTOSNOMBRE3',prop:'Visible'},{av:'edtavCentrocostosnombre1_Visible',ctrl:'vCENTROCOSTOSNOMBRE1',prop:'Visible'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCentroCostosId_Visible',ctrl:'CENTROCOSTOSID',prop:'Visible'},{av:'edtCentroCostosRef_Visible',ctrl:'CENTROCOSTOSREF',prop:'Visible'},{av:'edtCentroCostosNombre_Visible',ctrl:'CENTROCOSTOSNOMBRE',prop:'Visible'},{av:'edtCentroCostosPrecioFinal_Visible',ctrl:'CENTROCOSTOSPRECIOFINAL',prop:'Visible'},{av:'edtCentroCostosCosto_Visible',ctrl:'CENTROCOSTOSCOSTO',prop:'Visible'},{av:'edtCentroCostosGam_Visible',ctrl:'CENTROCOSTOSGAM',prop:'Visible'},{av:'cmbCentroCostosEstado'},{av:'cmbCentroCostosTipoRef'},{av:'AV59GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV60GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV61GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV64IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV65IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E253S2',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'edtavCentrocostosnombre2_Visible',ctrl:'vCENTROCOSTOSNOMBRE2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator2'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E203S2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20CentroCostosNombre1',fld:'vCENTROCOSTOSNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV24CentroCostosNombre2',fld:'vCENTROCOSTOSNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV28CentroCostosNombre3',fld:'vCENTROCOSTOSNOMBRE3',pic:'',type:'char'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41TFCentroCostosId',fld:'vTFCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV42TFCentroCostosId_To',fld:'vTFCENTROCOSTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV43TFCentroCostosRef',fld:'vTFCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV44TFCentroCostosRef_To',fld:'vTFCENTROCOSTOSREF_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFCentroCostosNombre',fld:'vTFCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV46TFCentroCostosNombre_Sel',fld:'vTFCENTROCOSTOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV47TFCentroCostosPrecioFinal',fld:'vTFCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV48TFCentroCostosPrecioFinal_To',fld:'vTFCENTROCOSTOSPRECIOFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV49TFCentroCostosCosto',fld:'vTFCENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV50TFCentroCostosCosto_To',fld:'vTFCENTROCOSTOSCOSTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV51TFCentroCostosGam',fld:'vTFCENTROCOSTOSGAM',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV52TFCentroCostosGam_To',fld:'vTFCENTROCOSTOSGAM_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV54TFCentroCostosEstado_Sels',fld:'vTFCENTROCOSTOSESTADO_SELS',pic:''},{av:'AV56TFCentroCostosTipoRef_Sels',fld:'vTFCENTROCOSTOSTIPOREF_SELS',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV64IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV65IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV24CentroCostosNombre2',fld:'vCENTROCOSTOSNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV28CentroCostosNombre3',fld:'vCENTROCOSTOSNOMBRE3',pic:'',type:'char'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20CentroCostosNombre1',fld:'vCENTROCOSTOSNOMBRE1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavCentrocostosnombre2_Visible',ctrl:'vCENTROCOSTOSNOMBRE2',prop:'Visible'},{av:'edtavCentrocostosnombre3_Visible',ctrl:'vCENTROCOSTOSNOMBRE3',prop:'Visible'},{av:'edtavCentrocostosnombre1_Visible',ctrl:'vCENTROCOSTOSNOMBRE1',prop:'Visible'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCentroCostosId_Visible',ctrl:'CENTROCOSTOSID',prop:'Visible'},{av:'edtCentroCostosRef_Visible',ctrl:'CENTROCOSTOSREF',prop:'Visible'},{av:'edtCentroCostosNombre_Visible',ctrl:'CENTROCOSTOSNOMBRE',prop:'Visible'},{av:'edtCentroCostosPrecioFinal_Visible',ctrl:'CENTROCOSTOSPRECIOFINAL',prop:'Visible'},{av:'edtCentroCostosCosto_Visible',ctrl:'CENTROCOSTOSCOSTO',prop:'Visible'},{av:'edtCentroCostosGam_Visible',ctrl:'CENTROCOSTOSGAM',prop:'Visible'},{av:'cmbCentroCostosEstado'},{av:'cmbCentroCostosTipoRef'},{av:'AV59GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV60GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV61GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV64IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV65IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E263S2',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'edtavCentrocostosnombre3_Visible',ctrl:'vCENTROCOSTOSNOMBRE3',prop:'Visible'},{av:'cmbavDynamicfiltersoperator3'}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E113S2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20CentroCostosNombre1',fld:'vCENTROCOSTOSNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV24CentroCostosNombre2',fld:'vCENTROCOSTOSNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV28CentroCostosNombre3',fld:'vCENTROCOSTOSNOMBRE3',pic:'',type:'char'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41TFCentroCostosId',fld:'vTFCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV42TFCentroCostosId_To',fld:'vTFCENTROCOSTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV43TFCentroCostosRef',fld:'vTFCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV44TFCentroCostosRef_To',fld:'vTFCENTROCOSTOSREF_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFCentroCostosNombre',fld:'vTFCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV46TFCentroCostosNombre_Sel',fld:'vTFCENTROCOSTOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV47TFCentroCostosPrecioFinal',fld:'vTFCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV48TFCentroCostosPrecioFinal_To',fld:'vTFCENTROCOSTOSPRECIOFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV49TFCentroCostosCosto',fld:'vTFCENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV50TFCentroCostosCosto_To',fld:'vTFCENTROCOSTOSCOSTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV51TFCentroCostosGam',fld:'vTFCENTROCOSTOSGAM',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV52TFCentroCostosGam_To',fld:'vTFCENTROCOSTOSGAM_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV54TFCentroCostosEstado_Sels',fld:'vTFCENTROCOSTOSESTADO_SELS',pic:''},{av:'AV56TFCentroCostosTipoRef_Sels',fld:'vTFCENTROCOSTOSTIPOREF_SELS',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV64IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV65IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV53TFCentroCostosEstado_SelsJson',fld:'vTFCENTROCOSTOSESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV55TFCentroCostosTipoRef_SelsJson',fld:'vTFCENTROCOSTOSTIPOREF_SELSJSON',pic:'',type:'vchar'}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV41TFCentroCostosId',fld:'vTFCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV42TFCentroCostosId_To',fld:'vTFCENTROCOSTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV43TFCentroCostosRef',fld:'vTFCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV44TFCentroCostosRef_To',fld:'vTFCENTROCOSTOSREF_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFCentroCostosNombre',fld:'vTFCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV46TFCentroCostosNombre_Sel',fld:'vTFCENTROCOSTOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV47TFCentroCostosPrecioFinal',fld:'vTFCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV48TFCentroCostosPrecioFinal_To',fld:'vTFCENTROCOSTOSPRECIOFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV49TFCentroCostosCosto',fld:'vTFCENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV50TFCentroCostosCosto_To',fld:'vTFCENTROCOSTOSCOSTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV51TFCentroCostosGam',fld:'vTFCENTROCOSTOSGAM',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV52TFCentroCostosGam_To',fld:'vTFCENTROCOSTOSGAM_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV54TFCentroCostosEstado_Sels',fld:'vTFCENTROCOSTOSESTADO_SELS',pic:''},{av:'AV56TFCentroCostosTipoRef_Sels',fld:'vTFCENTROCOSTOSTIPOREF_SELS',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20CentroCostosNombre1',fld:'vCENTROCOSTOSNOMBRE1',pic:'',type:'char'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV55TFCentroCostosTipoRef_SelsJson',fld:'vTFCENTROCOSTOSTIPOREF_SELSJSON',pic:'',type:'vchar'},{av:'AV53TFCentroCostosEstado_SelsJson',fld:'vTFCENTROCOSTOSESTADO_SELSJSON',pic:'',type:'vchar'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV24CentroCostosNombre2',fld:'vCENTROCOSTOSNOMBRE2',pic:'',type:'char'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV28CentroCostosNombre3',fld:'vCENTROCOSTOSNOMBRE3',pic:'',type:'char'},{av:'edtavCentrocostosnombre1_Visible',ctrl:'vCENTROCOSTOSNOMBRE1',prop:'Visible'},{av:'edtavCentrocostosnombre2_Visible',ctrl:'vCENTROCOSTOSNOMBRE2',prop:'Visible'},{av:'edtavCentrocostosnombre3_Visible',ctrl:'vCENTROCOSTOSNOMBRE3',prop:'Visible'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCentroCostosId_Visible',ctrl:'CENTROCOSTOSID',prop:'Visible'},{av:'edtCentroCostosRef_Visible',ctrl:'CENTROCOSTOSREF',prop:'Visible'},{av:'edtCentroCostosNombre_Visible',ctrl:'CENTROCOSTOSNOMBRE',prop:'Visible'},{av:'edtCentroCostosPrecioFinal_Visible',ctrl:'CENTROCOSTOSPRECIOFINAL',prop:'Visible'},{av:'edtCentroCostosCosto_Visible',ctrl:'CENTROCOSTOSCOSTO',prop:'Visible'},{av:'edtCentroCostosGam_Visible',ctrl:'CENTROCOSTOSGAM',prop:'Visible'},{av:'cmbCentroCostosEstado'},{av:'cmbCentroCostosTipoRef'},{av:'AV59GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV60GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV61GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV64IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV65IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E303S2',iparms:[{av:'cmbavGridactions'},{av:'AV62GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'A461CentroCostosId',fld:'CENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A462CentroCostosRef',fld:'CENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV62GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E213S2',iparms:[{av:'A461CentroCostosId',fld:'CENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E143S2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV46TFCentroCostosNombre_Sel',fld:'vTFCENTROCOSTOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV54TFCentroCostosEstado_Sels',fld:'vTFCENTROCOSTOSESTADO_SELS',pic:''},{av:'AV53TFCentroCostosEstado_SelsJson',fld:'vTFCENTROCOSTOSESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV56TFCentroCostosTipoRef_Sels',fld:'vTFCENTROCOSTOSTIPOREF_SELS',pic:''},{av:'AV55TFCentroCostosTipoRef_SelsJson',fld:'vTFCENTROCOSTOSTIPOREF_SELSJSON',pic:'',type:'vchar'},{av:'AV41TFCentroCostosId',fld:'vTFCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV43TFCentroCostosRef',fld:'vTFCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFCentroCostosNombre',fld:'vTFCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV47TFCentroCostosPrecioFinal',fld:'vTFCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV49TFCentroCostosCosto',fld:'vTFCENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV51TFCentroCostosGam',fld:'vTFCENTROCOSTOSGAM',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV42TFCentroCostosId_To',fld:'vTFCENTROCOSTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV44TFCentroCostosRef_To',fld:'vTFCENTROCOSTOSREF_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV48TFCentroCostosPrecioFinal_To',fld:'vTFCENTROCOSTOSPRECIOFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV50TFCentroCostosCosto_To',fld:'vTFCENTROCOSTOSCOSTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV52TFCentroCostosGam_To',fld:'vTFCENTROCOSTOSGAM_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20CentroCostosNombre1',fld:'vCENTROCOSTOSNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV24CentroCostosNombre2',fld:'vCENTROCOSTOSNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV28CentroCostosNombre3',fld:'vCENTROCOSTOSNOMBRE3',pic:'',type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV64IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV65IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV20CentroCostosNombre1',fld:'vCENTROCOSTOSNOMBRE1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV24CentroCostosNombre2',fld:'vCENTROCOSTOSNOMBRE2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV28CentroCostosNombre3',fld:'vCENTROCOSTOSNOMBRE3',pic:'',type:'char'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV41TFCentroCostosId',fld:'vTFCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV42TFCentroCostosId_To',fld:'vTFCENTROCOSTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV43TFCentroCostosRef',fld:'vTFCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV44TFCentroCostosRef_To',fld:'vTFCENTROCOSTOSREF_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV45TFCentroCostosNombre',fld:'vTFCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV46TFCentroCostosNombre_Sel',fld:'vTFCENTROCOSTOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV47TFCentroCostosPrecioFinal',fld:'vTFCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV48TFCentroCostosPrecioFinal_To',fld:'vTFCENTROCOSTOSPRECIOFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV49TFCentroCostosCosto',fld:'vTFCENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV50TFCentroCostosCosto_To',fld:'vTFCENTROCOSTOSCOSTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV51TFCentroCostosGam',fld:'vTFCENTROCOSTOSGAM',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV52TFCentroCostosGam_To',fld:'vTFCENTROCOSTOSGAM_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV54TFCentroCostosEstado_Sels',fld:'vTFCENTROCOSTOSESTADO_SELS',pic:''},{av:'AV56TFCentroCostosTipoRef_Sels',fld:'vTFCENTROCOSTOSTIPOREF_SELS',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV64IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV65IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV55TFCentroCostosTipoRef_SelsJson',fld:'vTFCENTROCOSTOSTIPOREF_SELSJSON',pic:'',type:'vchar'},{av:'AV53TFCentroCostosEstado_SelsJson',fld:'vTFCENTROCOSTOSESTADO_SELSJSON',pic:'',type:'vchar'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavCentrocostosnombre1_Visible',ctrl:'vCENTROCOSTOSNOMBRE1',prop:'Visible'},{av:'edtavCentrocostosnombre2_Visible',ctrl:'vCENTROCOSTOSNOMBRE2',prop:'Visible'},{av:'edtavCentrocostosnombre3_Visible',ctrl:'vCENTROCOSTOSNOMBRE3',prop:'Visible'},{av:'edtCentroCostosId_Visible',ctrl:'CENTROCOSTOSID',prop:'Visible'},{av:'edtCentroCostosRef_Visible',ctrl:'CENTROCOSTOSREF',prop:'Visible'},{av:'edtCentroCostosNombre_Visible',ctrl:'CENTROCOSTOSNOMBRE',prop:'Visible'},{av:'edtCentroCostosPrecioFinal_Visible',ctrl:'CENTROCOSTOSPRECIOFINAL',prop:'Visible'},{av:'edtCentroCostosCosto_Visible',ctrl:'CENTROCOSTOSCOSTO',prop:'Visible'},{av:'edtCentroCostosGam_Visible',ctrl:'CENTROCOSTOSGAM',prop:'Visible'},{av:'cmbCentroCostosEstado'},{av:'cmbCentroCostosTipoRef'},{av:'AV59GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV60GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV61GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","{handler:'E153S2',iparms:[]");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("VALID_CENTROCOSTOSID","{handler:'Valid_Centrocostosid',iparms:[]");
         setEventMetadata("VALID_CENTROCOSTOSID",",oparms:[]}");
         setEventMetadata("VALID_CENTROCOSTOSREF","{handler:'Valid_Centrocostosref',iparms:[]");
         setEventMetadata("VALID_CENTROCOSTOSREF",",oparms:[]}");
         setEventMetadata("VALID_CENTROCOSTOSNOMBRE","{handler:'Valid_Centrocostosnombre',iparms:[]");
         setEventMetadata("VALID_CENTROCOSTOSNOMBRE",",oparms:[]}");
         setEventMetadata("VALID_CENTROCOSTOSPRECIOFINAL","{handler:'Valid_Centrocostospreciofinal',iparms:[]");
         setEventMetadata("VALID_CENTROCOSTOSPRECIOFINAL",",oparms:[]}");
         setEventMetadata("VALID_CENTROCOSTOSCOSTO","{handler:'Valid_Centrocostoscosto',iparms:[]");
         setEventMetadata("VALID_CENTROCOSTOSCOSTO",",oparms:[]}");
         setEventMetadata("VALID_CENTROCOSTOSGAM","{handler:'Valid_Centrocostosgam',iparms:[]");
         setEventMetadata("VALID_CENTROCOSTOSGAM",",oparms:[]}");
         setEventMetadata("VALID_CENTROCOSTOSESTADO","{handler:'Valid_Centrocostosestado',iparms:[]");
         setEventMetadata("VALID_CENTROCOSTOSESTADO",",oparms:[]}");
         setEventMetadata("VALID_CENTROCOSTOSTIPOREF","{handler:'Valid_Centrocostostiporef',iparms:[]");
         setEventMetadata("VALID_CENTROCOSTOSTIPOREF",",oparms:[]}");
         return  ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      public override void initialize( )
      {
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV18DynamicFiltersSelector1 = "";
         AV20CentroCostosNombre1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24CentroCostosNombre2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28CentroCostosNombre3 = "";
         AV35ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV71Pgmname = "";
         AV17FilterFullText = "";
         AV45TFCentroCostosNombre = "";
         AV46TFCentroCostosNombre_Sel = "";
         AV54TFCentroCostosEstado_Sels = new GxSimpleCollection<string>();
         AV56TFCentroCostosTipoRef_Sels = new GxSimpleCollection<string>();
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV38ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV61GridAppliedFilters = "";
         AV66AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV57DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV53TFCentroCostosEstado_SelsJson = "";
         AV55TFCentroCostosTipoRef_SelsJson = "";
         Ddo_agexport_Caption = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsert_Jsonclick = "";
         bttBtnagexport_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         bttBtnsubscriptions_Jsonclick = "";
         lblDynamicfiltersprefix1_Jsonclick = "";
         lblDynamicfiltersmiddle1_Jsonclick = "";
         lblDynamicfiltersprefix2_Jsonclick = "";
         lblDynamicfiltersmiddle2_Jsonclick = "";
         lblDynamicfiltersprefix3_Jsonclick = "";
         lblDynamicfiltersmiddle3_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_agexport = new GXUserControl();
         ucDdc_subscriptions = new GXUserControl();
         lblJsdynamicfilters_Jsonclick = "";
         ucDdo_grid = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A463CentroCostosNombre = "";
         A482CentroCostosEstado = "";
         A487CentroCostosTipoRef = "";
         AV72Centrocostoswwds_1_filterfulltext = "";
         AV73Centrocostoswwds_2_dynamicfiltersselector1 = "";
         AV75Centrocostoswwds_4_centrocostosnombre1 = "";
         AV77Centrocostoswwds_6_dynamicfiltersselector2 = "";
         AV79Centrocostoswwds_8_centrocostosnombre2 = "";
         AV81Centrocostoswwds_10_dynamicfiltersselector3 = "";
         AV83Centrocostoswwds_12_centrocostosnombre3 = "";
         AV88Centrocostoswwds_17_tfcentrocostosnombre = "";
         AV89Centrocostoswwds_18_tfcentrocostosnombre_sel = "";
         AV96Centrocostoswwds_25_tfcentrocostosestado_sels = new GxSimpleCollection<string>();
         AV97Centrocostoswwds_26_tfcentrocostostiporef_sels = new GxSimpleCollection<string>();
         lV75Centrocostoswwds_4_centrocostosnombre1 = "";
         lV79Centrocostoswwds_8_centrocostosnombre2 = "";
         lV83Centrocostoswwds_12_centrocostosnombre3 = "";
         lV88Centrocostoswwds_17_tfcentrocostosnombre = "";
         H003S3_A487CentroCostosTipoRef = new string[] {""} ;
         H003S3_A482CentroCostosEstado = new string[] {""} ;
         H003S3_A474CentroCostosGam = new decimal[1] ;
         H003S3_A463CentroCostosNombre = new string[] {""} ;
         H003S3_A462CentroCostosRef = new long[1] ;
         H003S3_A461CentroCostosId = new long[1] ;
         H003S3_A464CentroCostosPrecioFinal = new decimal[1] ;
         H003S3_A475CentroCostosCosto = new decimal[1] ;
         H003S3_A469CentroCostosSubTotal = new decimal[1] ;
         H003S3_n469CentroCostosSubTotal = new bool[] {false} ;
         H003S5_A487CentroCostosTipoRef = new string[] {""} ;
         H003S5_A482CentroCostosEstado = new string[] {""} ;
         H003S5_A474CentroCostosGam = new decimal[1] ;
         H003S5_A463CentroCostosNombre = new string[] {""} ;
         H003S5_A462CentroCostosRef = new long[1] ;
         H003S5_A461CentroCostosId = new long[1] ;
         H003S5_A464CentroCostosPrecioFinal = new decimal[1] ;
         H003S5_A475CentroCostosCosto = new decimal[1] ;
         H003S5_A469CentroCostosSubTotal = new decimal[1] ;
         H003S5_n469CentroCostosSubTotal = new bool[] {false} ;
         AV8HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV67AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV37Session = context.GetSession();
         AV33ColumnsSelectorXML = "";
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV39ManageFiltersXml = "";
         AV34UserCustomValue = "";
         AV36ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char5 = "";
         GXt_char6 = "";
         AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV31ExcelFilename = "";
         AV32ErrorMessage = "";
         imgRemovedynamicfilters3_gximage = "";
         sImgUrl = "";
         imgAdddynamicfilters2_gximage = "";
         imgRemovedynamicfilters2_gximage = "";
         imgAdddynamicfilters1_gximage = "";
         imgRemovedynamicfilters1_gximage = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.centrocostosww__default(),
            new Object[][] {
                new Object[] {
               H003S3_A487CentroCostosTipoRef, H003S3_A482CentroCostosEstado, H003S3_A474CentroCostosGam, H003S3_A463CentroCostosNombre, H003S3_A462CentroCostosRef, H003S3_A461CentroCostosId, H003S3_A464CentroCostosPrecioFinal, H003S3_A475CentroCostosCosto, H003S3_A469CentroCostosSubTotal, H003S3_n469CentroCostosSubTotal
               }
               , new Object[] {
               H003S5_A487CentroCostosTipoRef, H003S5_A482CentroCostosEstado, H003S5_A474CentroCostosGam, H003S5_A463CentroCostosNombre, H003S5_A462CentroCostosRef, H003S5_A461CentroCostosId, H003S5_A464CentroCostosPrecioFinal, H003S5_A475CentroCostosCosto, H003S5_A469CentroCostosSubTotal, H003S5_n469CentroCostosSubTotal
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV71Pgmname = "CentroCostosWW";
         /* GeneXus formulas. */
         AV71Pgmname = "CentroCostosWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV14OrderedBy ;
      private short AV19DynamicFiltersOperator1 ;
      private short AV23DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short AV40ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV62GridActions ;
      private short nCmpId ;
      private short nDonePA ;
      private short AV74Centrocostoswwds_3_dynamicfiltersoperator1 ;
      private short AV78Centrocostoswwds_7_dynamicfiltersoperator2 ;
      private short AV82Centrocostoswwds_11_dynamicfiltersoperator3 ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_111 ;
      private int nGXsfl_111_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int bttBtnsubscriptions_Visible ;
      private int subGrid_Islastpage ;
      private int AV96Centrocostoswwds_25_tfcentrocostosestado_sels_Count ;
      private int AV97Centrocostoswwds_26_tfcentrocostostiporef_sels_Count ;
      private int edtCentroCostosId_Enabled ;
      private int edtCentroCostosRef_Enabled ;
      private int edtCentroCostosNombre_Enabled ;
      private int edtCentroCostosPrecioFinal_Enabled ;
      private int edtCentroCostosSubTotal_Enabled ;
      private int edtCentroCostosCosto_Enabled ;
      private int edtCentroCostosGam_Enabled ;
      private int edtCentroCostosId_Visible ;
      private int edtCentroCostosRef_Visible ;
      private int edtCentroCostosNombre_Visible ;
      private int edtCentroCostosPrecioFinal_Visible ;
      private int edtCentroCostosCosto_Visible ;
      private int edtCentroCostosGam_Visible ;
      private int AV58PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavCentrocostosnombre1_Visible ;
      private int edtavCentrocostosnombre2_Visible ;
      private int edtavCentrocostosnombre3_Visible ;
      private int AV98GXV1 ;
      private int edtavCentrocostosnombre3_Enabled ;
      private int edtavCentrocostosnombre2_Enabled ;
      private int edtavCentrocostosnombre1_Enabled ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV41TFCentroCostosId ;
      private long AV42TFCentroCostosId_To ;
      private long AV43TFCentroCostosRef ;
      private long AV44TFCentroCostosRef_To ;
      private long AV59GridCurrentPage ;
      private long AV60GridPageCount ;
      private long A461CentroCostosId ;
      private long A462CentroCostosRef ;
      private long GRID_nCurrentRecord ;
      private long AV84Centrocostoswwds_13_tfcentrocostosid ;
      private long AV85Centrocostoswwds_14_tfcentrocostosid_to ;
      private long AV86Centrocostoswwds_15_tfcentrocostosref ;
      private long AV87Centrocostoswwds_16_tfcentrocostosref_to ;
      private long GRID_nRecordCount ;
      private decimal AV47TFCentroCostosPrecioFinal ;
      private decimal AV48TFCentroCostosPrecioFinal_To ;
      private decimal AV49TFCentroCostosCosto ;
      private decimal AV50TFCentroCostosCosto_To ;
      private decimal AV51TFCentroCostosGam ;
      private decimal AV52TFCentroCostosGam_To ;
      private decimal A464CentroCostosPrecioFinal ;
      private decimal A469CentroCostosSubTotal ;
      private decimal A475CentroCostosCosto ;
      private decimal A474CentroCostosGam ;
      private decimal AV90Centrocostoswwds_19_tfcentrocostospreciofinal ;
      private decimal AV91Centrocostoswwds_20_tfcentrocostospreciofinal_to ;
      private decimal AV92Centrocostoswwds_21_tfcentrocostoscosto ;
      private decimal AV93Centrocostoswwds_22_tfcentrocostoscosto_to ;
      private decimal AV94Centrocostoswwds_23_tfcentrocostosgam ;
      private decimal AV95Centrocostoswwds_24_tfcentrocostosgam_to ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_111_idx="0001" ;
      private string AV20CentroCostosNombre1 ;
      private string AV24CentroCostosNombre2 ;
      private string AV28CentroCostosNombre3 ;
      private string AV71Pgmname ;
      private string AV45TFCentroCostosNombre ;
      private string AV46TFCentroCostosNombre_Sel ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Ddo_managefilters_Icontype ;
      private string Ddo_managefilters_Icon ;
      private string Ddo_managefilters_Tooltip ;
      private string Ddo_managefilters_Cls ;
      private string Gridpaginationbar_Class ;
      private string Gridpaginationbar_Pagingbuttonsposition ;
      private string Gridpaginationbar_Pagingcaptionposition ;
      private string Gridpaginationbar_Emptygridclass ;
      private string Gridpaginationbar_Rowsperpageoptions ;
      private string Gridpaginationbar_Previous ;
      private string Gridpaginationbar_Next ;
      private string Gridpaginationbar_Caption ;
      private string Gridpaginationbar_Emptygridcaption ;
      private string Gridpaginationbar_Rowsperpagecaption ;
      private string Ddo_agexport_Icontype ;
      private string Ddo_agexport_Icon ;
      private string Ddo_agexport_Caption ;
      private string Ddo_agexport_Cls ;
      private string Ddo_agexport_Titlecontrolidtoreplace ;
      private string Ddc_subscriptions_Icontype ;
      private string Ddc_subscriptions_Icon ;
      private string Ddc_subscriptions_Caption ;
      private string Ddc_subscriptions_Tooltip ;
      private string Ddc_subscriptions_Cls ;
      private string Ddc_subscriptions_Titlecontrolidtoreplace ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Filteredtextto_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Fixable ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Filterisrange ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Allowmultipleselection ;
      private string Ddo_grid_Datalistfixedvalues ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_grid_Format ;
      private string Innewwindow1_Width ;
      private string Innewwindow1_Height ;
      private string Innewwindow1_Target ;
      private string Ddo_gridcolumnsselector_Icontype ;
      private string Ddo_gridcolumnsselector_Icon ;
      private string Ddo_gridcolumnsselector_Caption ;
      private string Ddo_gridcolumnsselector_Tooltip ;
      private string Ddo_gridcolumnsselector_Cls ;
      private string Ddo_gridcolumnsselector_Dropdownoptionstype ;
      private string Ddo_gridcolumnsselector_Gridinternalname ;
      private string Ddo_gridcolumnsselector_Titlecontrolidtoreplace ;
      private string Grid_empowerer_Gridinternalname ;
      private string Grid_empowerer_Fixedcolumns ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string bttBtnagexport_Internalname ;
      private string bttBtnagexport_Jsonclick ;
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
      private string bttBtnsubscriptions_Internalname ;
      private string bttBtnsubscriptions_Jsonclick ;
      private string divAdvancedfilterscontainer_Internalname ;
      private string divTabledynamicfilters_Internalname ;
      private string divTabledynamicfiltersrow1_Internalname ;
      private string lblDynamicfiltersprefix1_Internalname ;
      private string lblDynamicfiltersprefix1_Jsonclick ;
      private string cmbavDynamicfiltersselector1_Internalname ;
      private string cmbavDynamicfiltersselector1_Jsonclick ;
      private string lblDynamicfiltersmiddle1_Internalname ;
      private string lblDynamicfiltersmiddle1_Jsonclick ;
      private string divTabledynamicfiltersrow2_Internalname ;
      private string lblDynamicfiltersprefix2_Internalname ;
      private string lblDynamicfiltersprefix2_Jsonclick ;
      private string cmbavDynamicfiltersselector2_Internalname ;
      private string cmbavDynamicfiltersselector2_Jsonclick ;
      private string lblDynamicfiltersmiddle2_Internalname ;
      private string lblDynamicfiltersmiddle2_Jsonclick ;
      private string divTabledynamicfiltersrow3_Internalname ;
      private string lblDynamicfiltersprefix3_Internalname ;
      private string lblDynamicfiltersprefix3_Jsonclick ;
      private string cmbavDynamicfiltersselector3_Internalname ;
      private string cmbavDynamicfiltersselector3_Jsonclick ;
      private string lblDynamicfiltersmiddle3_Internalname ;
      private string lblDynamicfiltersmiddle3_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string Ddc_subscriptions_Internalname ;
      private string lblJsdynamicfilters_Internalname ;
      private string lblJsdynamicfilters_Caption ;
      private string lblJsdynamicfilters_Jsonclick ;
      private string Ddo_grid_Internalname ;
      private string Innewwindow1_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string edtCentroCostosId_Internalname ;
      private string edtCentroCostosRef_Internalname ;
      private string A463CentroCostosNombre ;
      private string edtCentroCostosNombre_Internalname ;
      private string edtCentroCostosPrecioFinal_Internalname ;
      private string edtCentroCostosSubTotal_Internalname ;
      private string edtCentroCostosCosto_Internalname ;
      private string edtCentroCostosGam_Internalname ;
      private string cmbCentroCostosEstado_Internalname ;
      private string A482CentroCostosEstado ;
      private string cmbCentroCostosTipoRef_Internalname ;
      private string A487CentroCostosTipoRef ;
      private string edtavFilterfulltext_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string AV75Centrocostoswwds_4_centrocostosnombre1 ;
      private string AV79Centrocostoswwds_8_centrocostosnombre2 ;
      private string AV83Centrocostoswwds_12_centrocostosnombre3 ;
      private string AV88Centrocostoswwds_17_tfcentrocostosnombre ;
      private string AV89Centrocostoswwds_18_tfcentrocostosnombre_sel ;
      private string lV75Centrocostoswwds_4_centrocostosnombre1 ;
      private string lV79Centrocostoswwds_8_centrocostosnombre2 ;
      private string lV83Centrocostoswwds_12_centrocostosnombre3 ;
      private string lV88Centrocostoswwds_17_tfcentrocostosnombre ;
      private string edtavCentrocostosnombre1_Internalname ;
      private string edtavCentrocostosnombre2_Internalname ;
      private string edtavCentrocostosnombre3_Internalname ;
      private string imgAdddynamicfilters1_Jsonclick ;
      private string imgAdddynamicfilters1_Internalname ;
      private string imgRemovedynamicfilters1_Jsonclick ;
      private string imgRemovedynamicfilters1_Internalname ;
      private string imgAdddynamicfilters2_Jsonclick ;
      private string imgAdddynamicfilters2_Internalname ;
      private string imgRemovedynamicfilters2_Jsonclick ;
      private string imgRemovedynamicfilters2_Internalname ;
      private string imgRemovedynamicfilters3_Jsonclick ;
      private string imgRemovedynamicfilters3_Internalname ;
      private string edtCentroCostosNombre_Link ;
      private string GXEncryptionTmp ;
      private string GXt_char2 ;
      private string GXt_char5 ;
      private string GXt_char6 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_centrocostosnombre3_cell_Internalname ;
      private string edtavCentrocostosnombre3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_centrocostosnombre2_cell_Internalname ;
      private string edtavCentrocostosnombre2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_centrocostosnombre1_cell_Internalname ;
      private string edtavCentrocostosnombre1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_111_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtCentroCostosId_Jsonclick ;
      private string edtCentroCostosRef_Jsonclick ;
      private string edtCentroCostosNombre_Jsonclick ;
      private string edtCentroCostosPrecioFinal_Jsonclick ;
      private string edtCentroCostosSubTotal_Jsonclick ;
      private string edtCentroCostosCosto_Jsonclick ;
      private string edtCentroCostosGam_Jsonclick ;
      private string cmbCentroCostosEstado_Jsonclick ;
      private string cmbCentroCostosTipoRef_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV30DynamicFiltersIgnoreFirst ;
      private bool AV29DynamicFiltersRemoving ;
      private bool AV64IsAuthorized_Update ;
      private bool AV65IsAuthorized_Delete ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool bGXsfl_111_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n469CentroCostosSubTotal ;
      private bool AV76Centrocostoswwds_5_dynamicfiltersenabled2 ;
      private bool AV80Centrocostoswwds_9_dynamicfiltersenabled3 ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool AV68TempBoolean ;
      private bool GXt_boolean3 ;
      private string AV53TFCentroCostosEstado_SelsJson ;
      private string AV55TFCentroCostosTipoRef_SelsJson ;
      private string AV33ColumnsSelectorXML ;
      private string AV39ManageFiltersXml ;
      private string AV34UserCustomValue ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV17FilterFullText ;
      private string AV61GridAppliedFilters ;
      private string AV72Centrocostoswwds_1_filterfulltext ;
      private string AV73Centrocostoswwds_2_dynamicfiltersselector1 ;
      private string AV77Centrocostoswwds_6_dynamicfiltersselector2 ;
      private string AV81Centrocostoswwds_10_dynamicfiltersselector3 ;
      private string AV31ExcelFilename ;
      private string AV32ErrorMessage ;
      private IGxSession AV37Session ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucDdc_subscriptions ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDdo_managefilters ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbavGridactions ;
      private GXCombobox cmbCentroCostosEstado ;
      private GXCombobox cmbCentroCostosTipoRef ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV35ColumnsSelector ;
      private GxSimpleCollection<string> AV54TFCentroCostosEstado_Sels ;
      private GxSimpleCollection<string> AV56TFCentroCostosTipoRef_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV38ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV66AGExportData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV57DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV96Centrocostoswwds_25_tfcentrocostosestado_sels ;
      private GxSimpleCollection<string> AV97Centrocostoswwds_26_tfcentrocostostiporef_sels ;
      private IDataStoreProvider pr_default ;
      private string[] H003S3_A487CentroCostosTipoRef ;
      private string[] H003S3_A482CentroCostosEstado ;
      private decimal[] H003S3_A474CentroCostosGam ;
      private string[] H003S3_A463CentroCostosNombre ;
      private long[] H003S3_A462CentroCostosRef ;
      private long[] H003S3_A461CentroCostosId ;
      private decimal[] H003S3_A464CentroCostosPrecioFinal ;
      private decimal[] H003S3_A475CentroCostosCosto ;
      private decimal[] H003S3_A469CentroCostosSubTotal ;
      private bool[] H003S3_n469CentroCostosSubTotal ;
      private string[] H003S5_A487CentroCostosTipoRef ;
      private string[] H003S5_A482CentroCostosEstado ;
      private decimal[] H003S5_A474CentroCostosGam ;
      private string[] H003S5_A463CentroCostosNombre ;
      private long[] H003S5_A462CentroCostosRef ;
      private long[] H003S5_A461CentroCostosId ;
      private decimal[] H003S5_A464CentroCostosPrecioFinal ;
      private decimal[] H003S5_A475CentroCostosCosto ;
      private decimal[] H003S5_A469CentroCostosSubTotal ;
      private bool[] H003S5_n469CentroCostosSubTotal ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV67AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV36ColumnsSelectorAux ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV13GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class centrocostosww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H003S3( IGxContext context ,
                                             string A482CentroCostosEstado ,
                                             GxSimpleCollection<string> AV96Centrocostoswwds_25_tfcentrocostosestado_sels ,
                                             string A487CentroCostosTipoRef ,
                                             GxSimpleCollection<string> AV97Centrocostoswwds_26_tfcentrocostostiporef_sels ,
                                             string AV73Centrocostoswwds_2_dynamicfiltersselector1 ,
                                             short AV74Centrocostoswwds_3_dynamicfiltersoperator1 ,
                                             string AV75Centrocostoswwds_4_centrocostosnombre1 ,
                                             bool AV76Centrocostoswwds_5_dynamicfiltersenabled2 ,
                                             string AV77Centrocostoswwds_6_dynamicfiltersselector2 ,
                                             short AV78Centrocostoswwds_7_dynamicfiltersoperator2 ,
                                             string AV79Centrocostoswwds_8_centrocostosnombre2 ,
                                             bool AV80Centrocostoswwds_9_dynamicfiltersenabled3 ,
                                             string AV81Centrocostoswwds_10_dynamicfiltersselector3 ,
                                             short AV82Centrocostoswwds_11_dynamicfiltersoperator3 ,
                                             string AV83Centrocostoswwds_12_centrocostosnombre3 ,
                                             long AV84Centrocostoswwds_13_tfcentrocostosid ,
                                             long AV85Centrocostoswwds_14_tfcentrocostosid_to ,
                                             long AV86Centrocostoswwds_15_tfcentrocostosref ,
                                             long AV87Centrocostoswwds_16_tfcentrocostosref_to ,
                                             string AV89Centrocostoswwds_18_tfcentrocostosnombre_sel ,
                                             string AV88Centrocostoswwds_17_tfcentrocostosnombre ,
                                             decimal AV90Centrocostoswwds_19_tfcentrocostospreciofinal ,
                                             decimal AV91Centrocostoswwds_20_tfcentrocostospreciofinal_to ,
                                             decimal AV92Centrocostoswwds_21_tfcentrocostoscosto ,
                                             decimal AV93Centrocostoswwds_22_tfcentrocostoscosto_to ,
                                             decimal AV94Centrocostoswwds_23_tfcentrocostosgam ,
                                             decimal AV95Centrocostoswwds_24_tfcentrocostosgam_to ,
                                             int AV96Centrocostoswwds_25_tfcentrocostosestado_sels_Count ,
                                             int AV97Centrocostoswwds_26_tfcentrocostostiporef_sels_Count ,
                                             string A463CentroCostosNombre ,
                                             long A461CentroCostosId ,
                                             long A462CentroCostosRef ,
                                             decimal A464CentroCostosPrecioFinal ,
                                             decimal A475CentroCostosCosto ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV72Centrocostoswwds_1_filterfulltext ,
                                             decimal A474CentroCostosGam )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[18];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.[CentroCostosTipoRef], T1.[CentroCostosEstado], T1.[CentroCostosPrecioFinal] - T1.[CentroCostosCosto] AS CentroCostosGam, T1.[CentroCostosNombre], T1.[CentroCostosRef], T1.[CentroCostosId], T1.[CentroCostosPrecioFinal], T1.[CentroCostosCosto], COALESCE( T2.[CentroCostosSubTotal], 0) AS CentroCostosSubTotal FROM ([CentroCostos] T1 LEFT JOIN (SELECT SUM([CentroCostosDetallesValor]) AS CentroCostosSubTotal, [CentroCostosId] FROM [CentroCostosDetalles] GROUP BY [CentroCostosId] ) T2 ON T2.[CentroCostosId] = T1.[CentroCostosId])";
         if ( ( StringUtil.StrCmp(AV73Centrocostoswwds_2_dynamicfiltersselector1, "CENTROCOSTOSNOMBRE") == 0 ) && ( AV74Centrocostoswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Centrocostoswwds_4_centrocostosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CentroCostosNombre]) like UPPER(@lV75Centrocostoswwds_4_centrocostosnombre1))");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Centrocostoswwds_2_dynamicfiltersselector1, "CENTROCOSTOSNOMBRE") == 0 ) && ( AV74Centrocostoswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Centrocostoswwds_4_centrocostosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CentroCostosNombre]) like '%' + UPPER(@lV75Centrocostoswwds_4_centrocostosnombre1))");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( AV76Centrocostoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Centrocostoswwds_6_dynamicfiltersselector2, "CENTROCOSTOSNOMBRE") == 0 ) && ( AV78Centrocostoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Centrocostoswwds_8_centrocostosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CentroCostosNombre]) like UPPER(@lV79Centrocostoswwds_8_centrocostosnombre2))");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( AV76Centrocostoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Centrocostoswwds_6_dynamicfiltersselector2, "CENTROCOSTOSNOMBRE") == 0 ) && ( AV78Centrocostoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Centrocostoswwds_8_centrocostosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CentroCostosNombre]) like '%' + UPPER(@lV79Centrocostoswwds_8_centrocostosnombre2))");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( AV80Centrocostoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Centrocostoswwds_10_dynamicfiltersselector3, "CENTROCOSTOSNOMBRE") == 0 ) && ( AV82Centrocostoswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Centrocostoswwds_12_centrocostosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CentroCostosNombre]) like UPPER(@lV83Centrocostoswwds_12_centrocostosnombre3))");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( AV80Centrocostoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Centrocostoswwds_10_dynamicfiltersselector3, "CENTROCOSTOSNOMBRE") == 0 ) && ( AV82Centrocostoswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Centrocostoswwds_12_centrocostosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CentroCostosNombre]) like '%' + UPPER(@lV83Centrocostoswwds_12_centrocostosnombre3))");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! (0==AV84Centrocostoswwds_13_tfcentrocostosid) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosId] >= @AV84Centrocostoswwds_13_tfcentrocostosid)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! (0==AV85Centrocostoswwds_14_tfcentrocostosid_to) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosId] <= @AV85Centrocostoswwds_14_tfcentrocostosid_to)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ! (0==AV86Centrocostoswwds_15_tfcentrocostosref) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosRef] >= @AV86Centrocostoswwds_15_tfcentrocostosref)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! (0==AV87Centrocostoswwds_16_tfcentrocostosref_to) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosRef] <= @AV87Centrocostoswwds_16_tfcentrocostosref_to)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Centrocostoswwds_18_tfcentrocostosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Centrocostoswwds_17_tfcentrocostosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CentroCostosNombre]) like UPPER(@lV88Centrocostoswwds_17_tfcentrocostosnombre))");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Centrocostoswwds_18_tfcentrocostosnombre_sel)) && ! ( StringUtil.StrCmp(AV89Centrocostoswwds_18_tfcentrocostosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosNombre] = @AV89Centrocostoswwds_18_tfcentrocostosnombre_sel)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( StringUtil.StrCmp(AV89Centrocostoswwds_18_tfcentrocostosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[CentroCostosNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV90Centrocostoswwds_19_tfcentrocostospreciofinal) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosPrecioFinal] >= @AV90Centrocostoswwds_19_tfcentrocostospreciofinal)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV91Centrocostoswwds_20_tfcentrocostospreciofinal_to) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosPrecioFinal] <= @AV91Centrocostoswwds_20_tfcentrocostospreciofinal_to)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV92Centrocostoswwds_21_tfcentrocostoscosto) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosCosto] >= @AV92Centrocostoswwds_21_tfcentrocostoscosto)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV93Centrocostoswwds_22_tfcentrocostoscosto_to) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosCosto] <= @AV93Centrocostoswwds_22_tfcentrocostoscosto_to)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV94Centrocostoswwds_23_tfcentrocostosgam) )
         {
            AddWhere(sWhereString, "(( T1.[CentroCostosPrecioFinal] - T1.[CentroCostosCosto]) >= @AV94Centrocostoswwds_23_tfcentrocostosgam)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV95Centrocostoswwds_24_tfcentrocostosgam_to) )
         {
            AddWhere(sWhereString, "(( T1.[CentroCostosPrecioFinal] - T1.[CentroCostosCosto]) <= @AV95Centrocostoswwds_24_tfcentrocostosgam_to)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( AV96Centrocostoswwds_25_tfcentrocostosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV96Centrocostoswwds_25_tfcentrocostosestado_sels, "T1.[CentroCostosEstado] IN (", ")")+")");
         }
         if ( AV97Centrocostoswwds_26_tfcentrocostostiporef_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV97Centrocostoswwds_26_tfcentrocostostiporef_sels, "T1.[CentroCostosTipoRef] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CentroCostosNombre]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CentroCostosNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CentroCostosId]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CentroCostosId] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CentroCostosRef]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CentroCostosRef] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CentroCostosPrecioFinal]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CentroCostosPrecioFinal] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CentroCostosCosto]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CentroCostosCosto] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CentroCostosEstado]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CentroCostosEstado] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CentroCostosTipoRef]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CentroCostosTipoRef] DESC";
         }
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_H003S5( IGxContext context ,
                                             string A482CentroCostosEstado ,
                                             GxSimpleCollection<string> AV96Centrocostoswwds_25_tfcentrocostosestado_sels ,
                                             string A487CentroCostosTipoRef ,
                                             GxSimpleCollection<string> AV97Centrocostoswwds_26_tfcentrocostostiporef_sels ,
                                             string AV73Centrocostoswwds_2_dynamicfiltersselector1 ,
                                             short AV74Centrocostoswwds_3_dynamicfiltersoperator1 ,
                                             string AV75Centrocostoswwds_4_centrocostosnombre1 ,
                                             bool AV76Centrocostoswwds_5_dynamicfiltersenabled2 ,
                                             string AV77Centrocostoswwds_6_dynamicfiltersselector2 ,
                                             short AV78Centrocostoswwds_7_dynamicfiltersoperator2 ,
                                             string AV79Centrocostoswwds_8_centrocostosnombre2 ,
                                             bool AV80Centrocostoswwds_9_dynamicfiltersenabled3 ,
                                             string AV81Centrocostoswwds_10_dynamicfiltersselector3 ,
                                             short AV82Centrocostoswwds_11_dynamicfiltersoperator3 ,
                                             string AV83Centrocostoswwds_12_centrocostosnombre3 ,
                                             long AV84Centrocostoswwds_13_tfcentrocostosid ,
                                             long AV85Centrocostoswwds_14_tfcentrocostosid_to ,
                                             long AV86Centrocostoswwds_15_tfcentrocostosref ,
                                             long AV87Centrocostoswwds_16_tfcentrocostosref_to ,
                                             string AV89Centrocostoswwds_18_tfcentrocostosnombre_sel ,
                                             string AV88Centrocostoswwds_17_tfcentrocostosnombre ,
                                             decimal AV90Centrocostoswwds_19_tfcentrocostospreciofinal ,
                                             decimal AV91Centrocostoswwds_20_tfcentrocostospreciofinal_to ,
                                             decimal AV92Centrocostoswwds_21_tfcentrocostoscosto ,
                                             decimal AV93Centrocostoswwds_22_tfcentrocostoscosto_to ,
                                             decimal AV94Centrocostoswwds_23_tfcentrocostosgam ,
                                             decimal AV95Centrocostoswwds_24_tfcentrocostosgam_to ,
                                             int AV96Centrocostoswwds_25_tfcentrocostosestado_sels_Count ,
                                             int AV97Centrocostoswwds_26_tfcentrocostostiporef_sels_Count ,
                                             string A463CentroCostosNombre ,
                                             long A461CentroCostosId ,
                                             long A462CentroCostosRef ,
                                             decimal A464CentroCostosPrecioFinal ,
                                             decimal A475CentroCostosCosto ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV72Centrocostoswwds_1_filterfulltext ,
                                             decimal A474CentroCostosGam )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[18];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.[CentroCostosTipoRef], T1.[CentroCostosEstado], T1.[CentroCostosPrecioFinal] - T1.[CentroCostosCosto] AS CentroCostosGam, T1.[CentroCostosNombre], T1.[CentroCostosRef], T1.[CentroCostosId], T1.[CentroCostosPrecioFinal], T1.[CentroCostosCosto], COALESCE( T2.[CentroCostosSubTotal], 0) AS CentroCostosSubTotal FROM ([CentroCostos] T1 LEFT JOIN (SELECT SUM([CentroCostosDetallesValor]) AS CentroCostosSubTotal, [CentroCostosId] FROM [CentroCostosDetalles] GROUP BY [CentroCostosId] ) T2 ON T2.[CentroCostosId] = T1.[CentroCostosId])";
         if ( ( StringUtil.StrCmp(AV73Centrocostoswwds_2_dynamicfiltersselector1, "CENTROCOSTOSNOMBRE") == 0 ) && ( AV74Centrocostoswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Centrocostoswwds_4_centrocostosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CentroCostosNombre]) like UPPER(@lV75Centrocostoswwds_4_centrocostosnombre1))");
         }
         else
         {
            GXv_int9[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Centrocostoswwds_2_dynamicfiltersselector1, "CENTROCOSTOSNOMBRE") == 0 ) && ( AV74Centrocostoswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Centrocostoswwds_4_centrocostosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CentroCostosNombre]) like '%' + UPPER(@lV75Centrocostoswwds_4_centrocostosnombre1))");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( AV76Centrocostoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Centrocostoswwds_6_dynamicfiltersselector2, "CENTROCOSTOSNOMBRE") == 0 ) && ( AV78Centrocostoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Centrocostoswwds_8_centrocostosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CentroCostosNombre]) like UPPER(@lV79Centrocostoswwds_8_centrocostosnombre2))");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( AV76Centrocostoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV77Centrocostoswwds_6_dynamicfiltersselector2, "CENTROCOSTOSNOMBRE") == 0 ) && ( AV78Centrocostoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Centrocostoswwds_8_centrocostosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CentroCostosNombre]) like '%' + UPPER(@lV79Centrocostoswwds_8_centrocostosnombre2))");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( AV80Centrocostoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Centrocostoswwds_10_dynamicfiltersselector3, "CENTROCOSTOSNOMBRE") == 0 ) && ( AV82Centrocostoswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Centrocostoswwds_12_centrocostosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CentroCostosNombre]) like UPPER(@lV83Centrocostoswwds_12_centrocostosnombre3))");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( AV80Centrocostoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Centrocostoswwds_10_dynamicfiltersselector3, "CENTROCOSTOSNOMBRE") == 0 ) && ( AV82Centrocostoswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Centrocostoswwds_12_centrocostosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CentroCostosNombre]) like '%' + UPPER(@lV83Centrocostoswwds_12_centrocostosnombre3))");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( ! (0==AV84Centrocostoswwds_13_tfcentrocostosid) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosId] >= @AV84Centrocostoswwds_13_tfcentrocostosid)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( ! (0==AV85Centrocostoswwds_14_tfcentrocostosid_to) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosId] <= @AV85Centrocostoswwds_14_tfcentrocostosid_to)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( ! (0==AV86Centrocostoswwds_15_tfcentrocostosref) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosRef] >= @AV86Centrocostoswwds_15_tfcentrocostosref)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ! (0==AV87Centrocostoswwds_16_tfcentrocostosref_to) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosRef] <= @AV87Centrocostoswwds_16_tfcentrocostosref_to)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Centrocostoswwds_18_tfcentrocostosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Centrocostoswwds_17_tfcentrocostosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CentroCostosNombre]) like UPPER(@lV88Centrocostoswwds_17_tfcentrocostosnombre))");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Centrocostoswwds_18_tfcentrocostosnombre_sel)) && ! ( StringUtil.StrCmp(AV89Centrocostoswwds_18_tfcentrocostosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosNombre] = @AV89Centrocostoswwds_18_tfcentrocostosnombre_sel)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( StringUtil.StrCmp(AV89Centrocostoswwds_18_tfcentrocostosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[CentroCostosNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV90Centrocostoswwds_19_tfcentrocostospreciofinal) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosPrecioFinal] >= @AV90Centrocostoswwds_19_tfcentrocostospreciofinal)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV91Centrocostoswwds_20_tfcentrocostospreciofinal_to) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosPrecioFinal] <= @AV91Centrocostoswwds_20_tfcentrocostospreciofinal_to)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV92Centrocostoswwds_21_tfcentrocostoscosto) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosCosto] >= @AV92Centrocostoswwds_21_tfcentrocostoscosto)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV93Centrocostoswwds_22_tfcentrocostoscosto_to) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosCosto] <= @AV93Centrocostoswwds_22_tfcentrocostoscosto_to)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV94Centrocostoswwds_23_tfcentrocostosgam) )
         {
            AddWhere(sWhereString, "(( T1.[CentroCostosPrecioFinal] - T1.[CentroCostosCosto]) >= @AV94Centrocostoswwds_23_tfcentrocostosgam)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV95Centrocostoswwds_24_tfcentrocostosgam_to) )
         {
            AddWhere(sWhereString, "(( T1.[CentroCostosPrecioFinal] - T1.[CentroCostosCosto]) <= @AV95Centrocostoswwds_24_tfcentrocostosgam_to)");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( AV96Centrocostoswwds_25_tfcentrocostosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV96Centrocostoswwds_25_tfcentrocostosestado_sels, "T1.[CentroCostosEstado] IN (", ")")+")");
         }
         if ( AV97Centrocostoswwds_26_tfcentrocostostiporef_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV97Centrocostoswwds_26_tfcentrocostostiporef_sels, "T1.[CentroCostosTipoRef] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CentroCostosNombre]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CentroCostosNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CentroCostosId]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CentroCostosId] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CentroCostosRef]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CentroCostosRef] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CentroCostosPrecioFinal]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CentroCostosPrecioFinal] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CentroCostosCosto]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CentroCostosCosto] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CentroCostosEstado]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CentroCostosEstado] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CentroCostosTipoRef]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CentroCostosTipoRef] DESC";
         }
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H003S3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] , (long)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (decimal)dynConstraints[25] , (decimal)dynConstraints[26] , (int)dynConstraints[27] , (int)dynConstraints[28] , (string)dynConstraints[29] , (long)dynConstraints[30] , (long)dynConstraints[31] , (decimal)dynConstraints[32] , (decimal)dynConstraints[33] , (short)dynConstraints[34] , (bool)dynConstraints[35] , (string)dynConstraints[36] , (decimal)dynConstraints[37] );
               case 1 :
                     return conditional_H003S5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] , (long)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (decimal)dynConstraints[25] , (decimal)dynConstraints[26] , (int)dynConstraints[27] , (int)dynConstraints[28] , (string)dynConstraints[29] , (long)dynConstraints[30] , (long)dynConstraints[31] , (decimal)dynConstraints[32] , (decimal)dynConstraints[33] , (short)dynConstraints[34] , (bool)dynConstraints[35] , (string)dynConstraints[36] , (decimal)dynConstraints[37] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH003S3;
          prmH003S3 = new Object[] {
          new ParDef("@lV75Centrocostoswwds_4_centrocostosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV75Centrocostoswwds_4_centrocostosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV79Centrocostoswwds_8_centrocostosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV79Centrocostoswwds_8_centrocostosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV83Centrocostoswwds_12_centrocostosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV83Centrocostoswwds_12_centrocostosnombre3",GXType.Char,80,0) ,
          new ParDef("@AV84Centrocostoswwds_13_tfcentrocostosid",GXType.Decimal,18,0) ,
          new ParDef("@AV85Centrocostoswwds_14_tfcentrocostosid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV86Centrocostoswwds_15_tfcentrocostosref",GXType.Decimal,18,0) ,
          new ParDef("@AV87Centrocostoswwds_16_tfcentrocostosref_to",GXType.Decimal,18,0) ,
          new ParDef("@lV88Centrocostoswwds_17_tfcentrocostosnombre",GXType.Char,80,0) ,
          new ParDef("@AV89Centrocostoswwds_18_tfcentrocostosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV90Centrocostoswwds_19_tfcentrocostospreciofinal",GXType.Decimal,18,2) ,
          new ParDef("@AV91Centrocostoswwds_20_tfcentrocostospreciofinal_to",GXType.Decimal,18,2) ,
          new ParDef("@AV92Centrocostoswwds_21_tfcentrocostoscosto",GXType.Decimal,18,2) ,
          new ParDef("@AV93Centrocostoswwds_22_tfcentrocostoscosto_to",GXType.Decimal,18,2) ,
          new ParDef("@AV94Centrocostoswwds_23_tfcentrocostosgam",GXType.Decimal,18,2) ,
          new ParDef("@AV95Centrocostoswwds_24_tfcentrocostosgam_to",GXType.Decimal,18,2)
          };
          Object[] prmH003S5;
          prmH003S5 = new Object[] {
          new ParDef("@lV75Centrocostoswwds_4_centrocostosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV75Centrocostoswwds_4_centrocostosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV79Centrocostoswwds_8_centrocostosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV79Centrocostoswwds_8_centrocostosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV83Centrocostoswwds_12_centrocostosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV83Centrocostoswwds_12_centrocostosnombre3",GXType.Char,80,0) ,
          new ParDef("@AV84Centrocostoswwds_13_tfcentrocostosid",GXType.Decimal,18,0) ,
          new ParDef("@AV85Centrocostoswwds_14_tfcentrocostosid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV86Centrocostoswwds_15_tfcentrocostosref",GXType.Decimal,18,0) ,
          new ParDef("@AV87Centrocostoswwds_16_tfcentrocostosref_to",GXType.Decimal,18,0) ,
          new ParDef("@lV88Centrocostoswwds_17_tfcentrocostosnombre",GXType.Char,80,0) ,
          new ParDef("@AV89Centrocostoswwds_18_tfcentrocostosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV90Centrocostoswwds_19_tfcentrocostospreciofinal",GXType.Decimal,18,2) ,
          new ParDef("@AV91Centrocostoswwds_20_tfcentrocostospreciofinal_to",GXType.Decimal,18,2) ,
          new ParDef("@AV92Centrocostoswwds_21_tfcentrocostoscosto",GXType.Decimal,18,2) ,
          new ParDef("@AV93Centrocostoswwds_22_tfcentrocostoscosto_to",GXType.Decimal,18,2) ,
          new ParDef("@AV94Centrocostoswwds_23_tfcentrocostosgam",GXType.Decimal,18,2) ,
          new ParDef("@AV95Centrocostoswwds_24_tfcentrocostosgam_to",GXType.Decimal,18,2)
          };
          def= new CursorDef[] {
              new CursorDef("H003S3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003S3,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003S5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003S5,11, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 80);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 80);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                return;
       }
    }

 }

}
