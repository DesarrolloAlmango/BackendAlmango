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
   public class operacionesww : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public operacionesww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public operacionesww( IGxContext context )
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
         cmbavGridactions = new GXCombobox();
         cmbOperacionesTipo = new GXCombobox();
         cmbOperacionesTipoES = new GXCombobox();
         cmbOperacionesEstado = new GXCombobox();
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
         nRC_GXsfl_45 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_45"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_45_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_45_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_45_idx = GetPar( "sGXsfl_45_idx");
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
         AV40ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV35ColumnsSelector);
         AV120Pgmname = GetPar( "Pgmname");
         AV17FilterFullText = GetPar( "FilterFullText");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV102TFOperacionesTipo_Sels);
         AV117TFOperacionesComprobantePago = GetPar( "TFOperacionesComprobantePago");
         AV118TFOperacionesComprobantePago_Sel = GetPar( "TFOperacionesComprobantePago_Sel");
         AV63TFOperacionesFechaAlta = context.localUtil.ParseDateParm( GetPar( "TFOperacionesFechaAlta"));
         AV64TFOperacionesFechaAlta_To = context.localUtil.ParseDateParm( GetPar( "TFOperacionesFechaAlta_To"));
         AV91TFOperacionesFechaDesde = context.localUtil.ParseDateParm( GetPar( "TFOperacionesFechaDesde"));
         AV92TFOperacionesFechaDesde_To = context.localUtil.ParseDateParm( GetPar( "TFOperacionesFechaDesde_To"));
         AV96TFOperacionesFechaHasta = context.localUtil.ParseDateParm( GetPar( "TFOperacionesFechaHasta"));
         AV97TFOperacionesFechaHasta_To = context.localUtil.ParseDateParm( GetPar( "TFOperacionesFechaHasta_To"));
         AV68TFOperacionesFechaPago = context.localUtil.ParseDTimeParm( GetPar( "TFOperacionesFechaPago"));
         AV69TFOperacionesFechaPago_To = context.localUtil.ParseDTimeParm( GetPar( "TFOperacionesFechaPago_To"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV74TFOperacionesEstado_Sels);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV108GridCollapsedRecords);
         AV82IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV115IsAuthorized_PagoSaldo = StringUtil.StrToBool( GetPar( "IsAuthorized_PagoSaldo"));
         AV116IsAuthorized_CobroSaldo = StringUtil.StrToBool( GetPar( "IsAuthorized_CobroSaldo"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV107GridCollapsedRecordsChildren);
         AV114WalletId = (long)(Math.Round(NumberUtil.Val( GetPar( "WalletId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV120Pgmname, AV17FilterFullText, AV102TFOperacionesTipo_Sels, AV117TFOperacionesComprobantePago, AV118TFOperacionesComprobantePago_Sel, AV63TFOperacionesFechaAlta, AV64TFOperacionesFechaAlta_To, AV91TFOperacionesFechaDesde, AV92TFOperacionesFechaDesde_To, AV96TFOperacionesFechaHasta, AV97TFOperacionesFechaHasta_To, AV68TFOperacionesFechaPago, AV69TFOperacionesFechaPago_To, AV74TFOperacionesEstado_Sels, AV108GridCollapsedRecords, AV82IsAuthorized_Update, AV115IsAuthorized_PagoSaldo, AV116IsAuthorized_CobroSaldo, AV107GridCollapsedRecordsChildren, AV114WalletId) ;
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
         PA5E2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5E2( ) ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 74760), false, true, false);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 74760), false, true, false);
         context.AddJavascriptSource("calendar-"+StringUtil.Substring( context.GetLanguageProperty( "culture"), 1, 2)+".js", "?"+context.GetBuildNumber( 74760), false, true, false);
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridTitlesCategories/GridTitlesCategoriesRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVGroupBy/DVGroupByRender.js", "", false, true, false);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("operacionesww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV120Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV120Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV82IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV82IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_PAGOSALDO", AV115IsAuthorized_PagoSaldo);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PAGOSALDO", GetSecureSignedToken( "", AV115IsAuthorized_PagoSaldo, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_COBROSALDO", AV116IsAuthorized_CobroSaldo);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_COBROSALDO", GetSecureSignedToken( "", AV116IsAuthorized_CobroSaldo, context));
         GxWebStd.gx_hidden_field( context, "vWALLETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV114WalletId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWALLETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV114WalletId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV15OrderedDsc));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_45", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_45), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV38ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV38ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV77GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV78GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV79GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLIQUIDACIONESDATA", AV103LiquidacionesData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLIQUIDACIONESDATA", AV103LiquidacionesData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV84AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV84AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV75DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV75DDO_TitleSettingsIcons);
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV120Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV120Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFOPERACIONESTIPO_SELS", AV102TFOperacionesTipo_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFOPERACIONESTIPO_SELS", AV102TFOperacionesTipo_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFOPERACIONESCOMPROBANTEPAGO", StringUtil.RTrim( AV117TFOperacionesComprobantePago));
         GxWebStd.gx_hidden_field( context, "vTFOPERACIONESCOMPROBANTEPAGO_SEL", StringUtil.RTrim( AV118TFOperacionesComprobantePago_Sel));
         GxWebStd.gx_hidden_field( context, "vTFOPERACIONESFECHAALTA", context.localUtil.DToC( AV63TFOperacionesFechaAlta, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFOPERACIONESFECHAALTA_TO", context.localUtil.DToC( AV64TFOperacionesFechaAlta_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFOPERACIONESFECHADESDE", context.localUtil.DToC( AV91TFOperacionesFechaDesde, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFOPERACIONESFECHADESDE_TO", context.localUtil.DToC( AV92TFOperacionesFechaDesde_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFOPERACIONESFECHAHASTA", context.localUtil.DToC( AV96TFOperacionesFechaHasta, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFOPERACIONESFECHAHASTA_TO", context.localUtil.DToC( AV97TFOperacionesFechaHasta_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFOPERACIONESFECHAPAGO", context.localUtil.TToC( AV68TFOperacionesFechaPago, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFOPERACIONESFECHAPAGO_TO", context.localUtil.TToC( AV69TFOperacionesFechaPago_To, 10, 8, 0, 0, "/", ":", " "));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFOPERACIONESESTADO_SELS", AV74TFOperacionesEstado_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFOPERACIONESESTADO_SELS", AV74TFOperacionesEstado_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV15OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDCOLLAPSEDRECORDS", AV108GridCollapsedRecords);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDCOLLAPSEDRECORDS", AV108GridCollapsedRecords);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV82IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV82IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_PAGOSALDO", AV115IsAuthorized_PagoSaldo);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PAGOSALDO", GetSecureSignedToken( "", AV115IsAuthorized_PagoSaldo, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_COBROSALDO", AV116IsAuthorized_CobroSaldo);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_COBROSALDO", GetSecureSignedToken( "", AV116IsAuthorized_CobroSaldo, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDCOLLAPSEDRECORDSCHILDREN", AV107GridCollapsedRecordsChildren);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDCOLLAPSEDRECORDSCHILDREN", AV107GridCollapsedRecordsChildren);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_hidden_field( context, "vTFOPERACIONESTIPO_SELSJSON", AV101TFOperacionesTipo_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFOPERACIONESESTADO_SELSJSON", AV73TFOperacionesEstado_SelsJson);
         GxWebStd.gx_hidden_field( context, "vGROUPOPERACIONESTIPO", StringUtil.RTrim( AV106GroupOperacionesTipo));
         GxWebStd.gx_boolean_hidden_field( context, "vADDCHILDREN", AV112AddChildren);
         GxWebStd.gx_hidden_field( context, "vWALLETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV114WalletId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWALLETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV114WalletId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         GxWebStd.gx_hidden_field( context, "DDO_LIQUIDACIONES_Icontype", StringUtil.RTrim( Ddo_liquidaciones_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_LIQUIDACIONES_Icon", StringUtil.RTrim( Ddo_liquidaciones_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_LIQUIDACIONES_Caption", StringUtil.RTrim( Ddo_liquidaciones_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_LIQUIDACIONES_Cls", StringUtil.RTrim( Ddo_liquidaciones_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_LIQUIDACIONES_Visible", StringUtil.BoolToStr( Ddo_liquidaciones_Visible));
         GxWebStd.gx_hidden_field( context, "DDO_LIQUIDACIONES_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_liquidaciones_Titlecontrolidtoreplace));
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
         GxWebStd.gx_hidden_field( context, "GRID_TITLESCATEGORIES_Gridinternalname", StringUtil.RTrim( Grid_titlescategories_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_TITLESCATEGORIES_Gridtitlescategories", StringUtil.RTrim( Grid_titlescategories_Gridtitlescategories));
         GxWebStd.gx_hidden_field( context, "GRID_GROUP_Gridinternalname", StringUtil.RTrim( Grid_group_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_GROUP_Columnindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(Grid_group_Columnindex), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascategories", StringUtil.BoolToStr( Grid_empowerer_Hascategories));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hasrowgroups", StringUtil.BoolToStr( Grid_empowerer_Hasrowgroups));
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
            WE5E2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5E2( ) ;
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
         return formatLink("operacionesww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "OperacionesWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Operaciones", "") ;
      }

      protected void WB5E0( )
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
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnliquidaciones_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(45), 2, 0)+","+"null"+");", context.GetMessage( "Liquidaciones", ""), bttBtnliquidaciones_Jsonclick, 0, context.GetMessage( "Liquidaciones", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_OperacionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(45), 2, 0)+","+"null"+");", context.GetMessage( "WWP_ExportData", ""), bttBtnagexport_Jsonclick, 0, context.GetMessage( "WWP_ExportData", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_OperacionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(45), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_OperacionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(45), 2, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, context.GetMessage( "WWP_Subscriptions_Tooltip", ""), "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_OperacionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagregar_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(45), 2, 0)+","+"null"+");", context.GetMessage( "Generar Operaciones", ""), bttBtnagregar_Jsonclick, 5, context.GetMessage( "Generar Operaciones", ""), "", StyleString, ClassString, bttBtnagregar_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOAGREGAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_OperacionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_27_5E2( true) ;
         }
         else
         {
            wb_table1_27_5E2( false) ;
         }
         return  ;
      }

      protected void wb_table1_27_5E2e( bool wbgen )
      {
         if ( wbgen )
         {
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders GridFixedTitles HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl45( ) ;
         }
         if ( wbEnd == 45 )
         {
            wbEnd = 0;
            nRC_GXsfl_45 = (int)(nGXsfl_45_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV77GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV78GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV79GridAppliedFilters);
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
            ucDdo_liquidaciones.SetProperty("IconType", Ddo_liquidaciones_Icontype);
            ucDdo_liquidaciones.SetProperty("Icon", Ddo_liquidaciones_Icon);
            ucDdo_liquidaciones.SetProperty("Caption", Ddo_liquidaciones_Caption);
            ucDdo_liquidaciones.SetProperty("Cls", Ddo_liquidaciones_Cls);
            ucDdo_liquidaciones.SetProperty("DropDownOptionsData", AV103LiquidacionesData);
            ucDdo_liquidaciones.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_liquidaciones_Internalname, "DDO_LIQUIDACIONESContainer");
            /* User Defined Control */
            ucDdo_agexport.SetProperty("IconType", Ddo_agexport_Icontype);
            ucDdo_agexport.SetProperty("Icon", Ddo_agexport_Icon);
            ucDdo_agexport.SetProperty("Caption", Ddo_agexport_Caption);
            ucDdo_agexport.SetProperty("Cls", Ddo_agexport_Cls);
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV84AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, "DDC_SUBSCRIPTIONSContainer");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV75DDO_TitleSettingsIcons);
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
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV75DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV35ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_titlescategories.Render(context, "dvelop.gridtitlescategories", Grid_titlescategories_Internalname, "GRID_TITLESCATEGORIESContainer");
            /* User Defined Control */
            ucGrid_group.SetProperty("ColumnIndex", Grid_group_Columnindex);
            ucGrid_group.Render(context, "dvelop.dvgroupby", Grid_group_Internalname, "GRID_GROUPContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasCategories", Grid_empowerer_Hascategories);
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.SetProperty("HasRowGroups", Grid_empowerer_Hasrowgroups);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0078"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0078"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_45_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0078"+"");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_operacionesfechaaltaauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'" + sGXsfl_45_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavDdo_operacionesfechaaltaauxdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavDdo_operacionesfechaaltaauxdate_Internalname, context.localUtil.Format(AV65DDO_OperacionesFechaAltaAuxDate, "99/99/99"), context.localUtil.Format( AV65DDO_OperacionesFechaAltaAuxDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,80);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_operacionesfechaaltaauxdate_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_OperacionesWW.htm");
            GxWebStd.gx_bitmap( context, edtavDdo_operacionesfechaaltaauxdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(1==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_OperacionesWW.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'" + sGXsfl_45_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavDdo_operacionesfechaaltaauxdateto_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavDdo_operacionesfechaaltaauxdateto_Internalname, context.localUtil.Format(AV66DDO_OperacionesFechaAltaAuxDateTo, "99/99/99"), context.localUtil.Format( AV66DDO_OperacionesFechaAltaAuxDateTo, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_operacionesfechaaltaauxdateto_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_OperacionesWW.htm");
            GxWebStd.gx_bitmap( context, edtavDdo_operacionesfechaaltaauxdateto_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(1==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_OperacionesWW.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_operacionesfechadesdeauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'" + sGXsfl_45_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavDdo_operacionesfechadesdeauxdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavDdo_operacionesfechadesdeauxdate_Internalname, context.localUtil.Format(AV93DDO_OperacionesFechaDesdeAuxDate, "99/99/99"), context.localUtil.Format( AV93DDO_OperacionesFechaDesdeAuxDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_operacionesfechadesdeauxdate_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_OperacionesWW.htm");
            GxWebStd.gx_bitmap( context, edtavDdo_operacionesfechadesdeauxdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(1==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_OperacionesWW.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'" + sGXsfl_45_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavDdo_operacionesfechadesdeauxdateto_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavDdo_operacionesfechadesdeauxdateto_Internalname, context.localUtil.Format(AV94DDO_OperacionesFechaDesdeAuxDateTo, "99/99/99"), context.localUtil.Format( AV94DDO_OperacionesFechaDesdeAuxDateTo, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_operacionesfechadesdeauxdateto_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_OperacionesWW.htm");
            GxWebStd.gx_bitmap( context, edtavDdo_operacionesfechadesdeauxdateto_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(1==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_OperacionesWW.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_operacionesfechahastaauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'" + sGXsfl_45_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavDdo_operacionesfechahastaauxdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavDdo_operacionesfechahastaauxdate_Internalname, context.localUtil.Format(AV98DDO_OperacionesFechaHastaAuxDate, "99/99/99"), context.localUtil.Format( AV98DDO_OperacionesFechaHastaAuxDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_operacionesfechahastaauxdate_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_OperacionesWW.htm");
            GxWebStd.gx_bitmap( context, edtavDdo_operacionesfechahastaauxdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(1==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_OperacionesWW.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'" + sGXsfl_45_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavDdo_operacionesfechahastaauxdateto_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavDdo_operacionesfechahastaauxdateto_Internalname, context.localUtil.Format(AV99DDO_OperacionesFechaHastaAuxDateTo, "99/99/99"), context.localUtil.Format( AV99DDO_OperacionesFechaHastaAuxDateTo, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,87);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_operacionesfechahastaauxdateto_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_OperacionesWW.htm");
            GxWebStd.gx_bitmap( context, edtavDdo_operacionesfechahastaauxdateto_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(1==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_OperacionesWW.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_operacionesfechapagoauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'" + sGXsfl_45_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavDdo_operacionesfechapagoauxdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavDdo_operacionesfechapagoauxdate_Internalname, context.localUtil.Format(AV70DDO_OperacionesFechaPagoAuxDate, "99/99/99"), context.localUtil.Format( AV70DDO_OperacionesFechaPagoAuxDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_operacionesfechapagoauxdate_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_OperacionesWW.htm");
            GxWebStd.gx_bitmap( context, edtavDdo_operacionesfechapagoauxdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(1==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_OperacionesWW.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'" + sGXsfl_45_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavDdo_operacionesfechapagoauxdateto_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavDdo_operacionesfechapagoauxdateto_Internalname, context.localUtil.Format(AV71DDO_OperacionesFechaPagoAuxDateTo, "99/99/99"), context.localUtil.Format( AV71DDO_OperacionesFechaPagoAuxDateTo, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,90);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_operacionesfechapagoauxdateto_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_OperacionesWW.htm");
            GxWebStd.gx_bitmap( context, edtavDdo_operacionesfechapagoauxdateto_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(1==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_OperacionesWW.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 45 )
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

      protected void START5E2( )
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
         Form.Meta.addItem("description", context.GetMessage( " Operaciones", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5E0( ) ;
      }

      protected void WS5E2( )
      {
         START5E2( ) ;
         EVT5E2( ) ;
      }

      protected void EVT5E2( )
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
                              E115E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E125E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E135E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_agexport.Onoptionclicked */
                              E145E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E155E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E165E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E175E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOAGREGAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoAgregar' */
                              E185E2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VEXPAND.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VEXPAND.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) )
                           {
                              nGXsfl_45_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
                              SubsflControlProps_452( ) ;
                              AV113Expand = cgiGet( edtavExpand_Internalname);
                              AssignAttri("", false, edtavExpand_Internalname, AV113Expand);
                              AV105Grid_GroupCaption = cgiGet( edtavGrid_groupcaption_Internalname);
                              AssignAttri("", false, edtavGrid_groupcaption_Internalname, AV105Grid_GroupCaption);
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV80GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV80GridActions), 4, 0));
                              A554OperacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtOperacionesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A555OperacionesRef = cgiGet( edtOperacionesRef_Internalname);
                              n555OperacionesRef = false;
                              A657OperacionesNombreRef = cgiGet( edtOperacionesNombreRef_Internalname);
                              n657OperacionesNombreRef = false;
                              cmbOperacionesTipo.Name = cmbOperacionesTipo_Internalname;
                              cmbOperacionesTipo.CurrentValue = cgiGet( cmbOperacionesTipo_Internalname);
                              A649OperacionesTipo = cgiGet( cmbOperacionesTipo_Internalname);
                              n649OperacionesTipo = false;
                              cmbOperacionesTipoES.Name = cmbOperacionesTipoES_Internalname;
                              cmbOperacionesTipoES.CurrentValue = cgiGet( cmbOperacionesTipoES_Internalname);
                              A569OperacionesTipoES = cgiGet( cmbOperacionesTipoES_Internalname);
                              n569OperacionesTipoES = false;
                              A570OperacionesImporte = context.localUtil.CToN( cgiGet( edtOperacionesImporte_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              n570OperacionesImporte = false;
                              A572OperacionesFacturaCod = cgiGet( edtOperacionesFacturaCod_Internalname);
                              n572OperacionesFacturaCod = false;
                              A580OperacionesComprobantePago = cgiGet( edtOperacionesComprobantePago_Internalname);
                              n580OperacionesComprobantePago = false;
                              A581OperacionesFechaAlta = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtOperacionesFechaAlta_Internalname), 0));
                              n581OperacionesFechaAlta = false;
                              A658OperacionesFechaDesde = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtOperacionesFechaDesde_Internalname), 0));
                              n658OperacionesFechaDesde = false;
                              A659OperacionesFechaHasta = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtOperacionesFechaHasta_Internalname), 0));
                              n659OperacionesFechaHasta = false;
                              A582OperacionesFechaPago = context.localUtil.CToT( cgiGet( edtOperacionesFechaPago_Internalname), 0);
                              n582OperacionesFechaPago = false;
                              cmbOperacionesEstado.Name = cmbOperacionesEstado_Internalname;
                              cmbOperacionesEstado.CurrentValue = cgiGet( cmbOperacionesEstado_Internalname);
                              A577OperacionesEstado = cgiGet( cmbOperacionesEstado_Internalname);
                              n577OperacionesEstado = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E195E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E205E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E215E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E225E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VEXPAND.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E235E2 ();
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
                        if ( nCmpId == 78 )
                        {
                           OldWwpaux_wc = cgiGet( "W0078");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0078", "", sEvt);
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

      protected void WE5E2( )
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

      protected void PA5E2( )
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
         SubsflControlProps_452( ) ;
         while ( nGXsfl_45_idx <= nRC_GXsfl_45 )
         {
            sendrow_452( ) ;
            nGXsfl_45_idx = ((subGrid_Islastpage==1)&&(nGXsfl_45_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_45_idx+1);
            sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
            SubsflControlProps_452( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       short AV40ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV35ColumnsSelector ,
                                       string AV120Pgmname ,
                                       string AV17FilterFullText ,
                                       GxSimpleCollection<string> AV102TFOperacionesTipo_Sels ,
                                       string AV117TFOperacionesComprobantePago ,
                                       string AV118TFOperacionesComprobantePago_Sel ,
                                       DateTime AV63TFOperacionesFechaAlta ,
                                       DateTime AV64TFOperacionesFechaAlta_To ,
                                       DateTime AV91TFOperacionesFechaDesde ,
                                       DateTime AV92TFOperacionesFechaDesde_To ,
                                       DateTime AV96TFOperacionesFechaHasta ,
                                       DateTime AV97TFOperacionesFechaHasta_To ,
                                       DateTime AV68TFOperacionesFechaPago ,
                                       DateTime AV69TFOperacionesFechaPago_To ,
                                       GxSimpleCollection<string> AV74TFOperacionesEstado_Sels ,
                                       GxSimpleCollection<string> AV108GridCollapsedRecords ,
                                       bool AV82IsAuthorized_Update ,
                                       bool AV115IsAuthorized_PagoSaldo ,
                                       bool AV116IsAuthorized_CobroSaldo ,
                                       GxSimpleCollection<long> AV107GridCollapsedRecordsChildren ,
                                       long AV114WalletId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF5E2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_OPERACIONESTIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A649OperacionesTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "OPERACIONESTIPO", StringUtil.RTrim( A649OperacionesTipo));
         GxWebStd.gx_hidden_field( context, "gxhash_OPERACIONESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A554OperacionesId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "OPERACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A554OperacionesId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_OPERACIONESNOMBREREF", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A657OperacionesNombreRef, "")), context));
         GxWebStd.gx_hidden_field( context, "OPERACIONESNOMBREREF", StringUtil.RTrim( A657OperacionesNombreRef));
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5E2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV120Pgmname = "OperacionesWW";
         edtavExpand_Enabled = 0;
         edtavGrid_groupcaption_Enabled = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV121Operacioneswwds_1_filterfulltext = AV17FilterFullText;
         AV122Operacioneswwds_2_tfoperacionestipo_sels = AV102TFOperacionesTipo_Sels;
         AV123Operacioneswwds_3_tfoperacionescomprobantepago = AV117TFOperacionesComprobantePago;
         AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel = AV118TFOperacionesComprobantePago_Sel;
         AV125Operacioneswwds_5_tfoperacionesfechaalta = AV63TFOperacionesFechaAlta;
         AV126Operacioneswwds_6_tfoperacionesfechaalta_to = AV64TFOperacionesFechaAlta_To;
         AV127Operacioneswwds_7_tfoperacionesfechadesde = AV91TFOperacionesFechaDesde;
         AV128Operacioneswwds_8_tfoperacionesfechadesde_to = AV92TFOperacionesFechaDesde_To;
         AV129Operacioneswwds_9_tfoperacionesfechahasta = AV96TFOperacionesFechaHasta;
         AV130Operacioneswwds_10_tfoperacionesfechahasta_to = AV97TFOperacionesFechaHasta_To;
         AV131Operacioneswwds_11_tfoperacionesfechapago = AV68TFOperacionesFechaPago;
         AV132Operacioneswwds_12_tfoperacionesfechapago_to = AV69TFOperacionesFechaPago_To;
         AV133Operacioneswwds_13_tfoperacionesestado_sels = AV74TFOperacionesEstado_Sels;
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A649OperacionesTipo ,
                                              AV122Operacioneswwds_2_tfoperacionestipo_sels ,
                                              A577OperacionesEstado ,
                                              AV133Operacioneswwds_13_tfoperacionesestado_sels ,
                                              A554OperacionesId ,
                                              AV107GridCollapsedRecordsChildren ,
                                              AV122Operacioneswwds_2_tfoperacionestipo_sels.Count ,
                                              AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel ,
                                              AV123Operacioneswwds_3_tfoperacionescomprobantepago ,
                                              AV127Operacioneswwds_7_tfoperacionesfechadesde ,
                                              AV128Operacioneswwds_8_tfoperacionesfechadesde_to ,
                                              AV129Operacioneswwds_9_tfoperacionesfechahasta ,
                                              AV130Operacioneswwds_10_tfoperacionesfechahasta_to ,
                                              AV133Operacioneswwds_13_tfoperacionesestado_sels.Count ,
                                              AV107GridCollapsedRecordsChildren.Count ,
                                              A580OperacionesComprobantePago ,
                                              A658OperacionesFechaDesde ,
                                              A659OperacionesFechaHasta ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              AV121Operacioneswwds_1_filterfulltext ,
                                              A555OperacionesRef ,
                                              A657OperacionesNombreRef ,
                                              A569OperacionesTipoES ,
                                              A570OperacionesImporte ,
                                              A572OperacionesFacturaCod } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV123Operacioneswwds_3_tfoperacionescomprobantepago = StringUtil.PadR( StringUtil.RTrim( AV123Operacioneswwds_3_tfoperacionescomprobantepago), 256, "%");
         /* Using cursor H005E2 */
         pr_default.execute(0, new Object[] {lV123Operacioneswwds_3_tfoperacionescomprobantepago, AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel, AV127Operacioneswwds_7_tfoperacionesfechadesde, AV128Operacioneswwds_8_tfoperacionesfechadesde_to, AV129Operacioneswwds_9_tfoperacionesfechahasta, AV130Operacioneswwds_10_tfoperacionesfechahasta_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A577OperacionesEstado = H005E2_A577OperacionesEstado[0];
            n577OperacionesEstado = H005E2_n577OperacionesEstado[0];
            A582OperacionesFechaPago = H005E2_A582OperacionesFechaPago[0];
            n582OperacionesFechaPago = H005E2_n582OperacionesFechaPago[0];
            A659OperacionesFechaHasta = H005E2_A659OperacionesFechaHasta[0];
            n659OperacionesFechaHasta = H005E2_n659OperacionesFechaHasta[0];
            A658OperacionesFechaDesde = H005E2_A658OperacionesFechaDesde[0];
            n658OperacionesFechaDesde = H005E2_n658OperacionesFechaDesde[0];
            A581OperacionesFechaAlta = H005E2_A581OperacionesFechaAlta[0];
            n581OperacionesFechaAlta = H005E2_n581OperacionesFechaAlta[0];
            A580OperacionesComprobantePago = H005E2_A580OperacionesComprobantePago[0];
            n580OperacionesComprobantePago = H005E2_n580OperacionesComprobantePago[0];
            A572OperacionesFacturaCod = H005E2_A572OperacionesFacturaCod[0];
            n572OperacionesFacturaCod = H005E2_n572OperacionesFacturaCod[0];
            A570OperacionesImporte = H005E2_A570OperacionesImporte[0];
            n570OperacionesImporte = H005E2_n570OperacionesImporte[0];
            A569OperacionesTipoES = H005E2_A569OperacionesTipoES[0];
            n569OperacionesTipoES = H005E2_n569OperacionesTipoES[0];
            A649OperacionesTipo = H005E2_A649OperacionesTipo[0];
            n649OperacionesTipo = H005E2_n649OperacionesTipo[0];
            A657OperacionesNombreRef = H005E2_A657OperacionesNombreRef[0];
            n657OperacionesNombreRef = H005E2_n657OperacionesNombreRef[0];
            A555OperacionesRef = H005E2_A555OperacionesRef[0];
            n555OperacionesRef = H005E2_n555OperacionesRef[0];
            A554OperacionesId = H005E2_A554OperacionesId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV121Operacioneswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A554OperacionesId), 18, 0) , StringUtil.PadR( "%" + AV121Operacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A555OperacionesRef) , StringUtil.PadR( "%" + StringUtil.Upper( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A657OperacionesNombreRef) , StringUtil.PadR( "%" + StringUtil.Upper( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "liquidación de solicitudes del profesional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "LSF") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "liquidación de  solicitudes comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "LSC") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "cobro de saldo pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "COL") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pago de saldo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A649OperacionesTipo, "POL") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro de solicitud", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "CSO") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "nota de credito", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "NCR") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "nota de debito", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A649OperacionesTipo, "NDE") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "OTR") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "solicitudes ingresadas desde fenicio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "FEN") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "respuesta de api fenicio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "FGO") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "comercio_externo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "CEX") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "entrada", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A569OperacionesTipoES, "E") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "salida", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A569OperacionesTipoES, "S") == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Str( A570OperacionesImporte, 18, 2) , StringUtil.PadR( "%" + AV121Operacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A572OperacionesFacturaCod) , StringUtil.PadR( "%" + StringUtil.Upper( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A580OperacionesComprobantePago) , StringUtil.PadR( "%" + StringUtil.Upper( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "procesado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A577OperacionesEstado, "PRO") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A577OperacionesEstado, "PND") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "anulado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A577OperacionesEstado, "ANU") == 0 ) ) )
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

      protected void RF5E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 45;
         /* Execute user event: Refresh */
         E205E2 ();
         nGXsfl_45_idx = 1;
         sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
         SubsflControlProps_452( ) ;
         bGXsfl_45_Refreshing = true;
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
            SubsflControlProps_452( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A649OperacionesTipo ,
                                                 AV122Operacioneswwds_2_tfoperacionestipo_sels ,
                                                 A577OperacionesEstado ,
                                                 AV133Operacioneswwds_13_tfoperacionesestado_sels ,
                                                 A554OperacionesId ,
                                                 AV107GridCollapsedRecordsChildren ,
                                                 AV122Operacioneswwds_2_tfoperacionestipo_sels.Count ,
                                                 AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel ,
                                                 AV123Operacioneswwds_3_tfoperacionescomprobantepago ,
                                                 AV127Operacioneswwds_7_tfoperacionesfechadesde ,
                                                 AV128Operacioneswwds_8_tfoperacionesfechadesde_to ,
                                                 AV129Operacioneswwds_9_tfoperacionesfechahasta ,
                                                 AV130Operacioneswwds_10_tfoperacionesfechahasta_to ,
                                                 AV133Operacioneswwds_13_tfoperacionesestado_sels.Count ,
                                                 AV107GridCollapsedRecordsChildren.Count ,
                                                 A580OperacionesComprobantePago ,
                                                 A658OperacionesFechaDesde ,
                                                 A659OperacionesFechaHasta ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 AV121Operacioneswwds_1_filterfulltext ,
                                                 A555OperacionesRef ,
                                                 A657OperacionesNombreRef ,
                                                 A569OperacionesTipoES ,
                                                 A570OperacionesImporte ,
                                                 A572OperacionesFacturaCod } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT,
                                                 TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                                 }
            });
            lV123Operacioneswwds_3_tfoperacionescomprobantepago = StringUtil.PadR( StringUtil.RTrim( AV123Operacioneswwds_3_tfoperacionescomprobantepago), 256, "%");
            /* Using cursor H005E3 */
            pr_default.execute(1, new Object[] {lV123Operacioneswwds_3_tfoperacionescomprobantepago, AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel, AV127Operacioneswwds_7_tfoperacionesfechadesde, AV128Operacioneswwds_8_tfoperacionesfechadesde_to, AV129Operacioneswwds_9_tfoperacionesfechahasta, AV130Operacioneswwds_10_tfoperacionesfechahasta_to});
            nGXsfl_45_idx = 1;
            sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
            SubsflControlProps_452( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A577OperacionesEstado = H005E3_A577OperacionesEstado[0];
               n577OperacionesEstado = H005E3_n577OperacionesEstado[0];
               A582OperacionesFechaPago = H005E3_A582OperacionesFechaPago[0];
               n582OperacionesFechaPago = H005E3_n582OperacionesFechaPago[0];
               A659OperacionesFechaHasta = H005E3_A659OperacionesFechaHasta[0];
               n659OperacionesFechaHasta = H005E3_n659OperacionesFechaHasta[0];
               A658OperacionesFechaDesde = H005E3_A658OperacionesFechaDesde[0];
               n658OperacionesFechaDesde = H005E3_n658OperacionesFechaDesde[0];
               A581OperacionesFechaAlta = H005E3_A581OperacionesFechaAlta[0];
               n581OperacionesFechaAlta = H005E3_n581OperacionesFechaAlta[0];
               A580OperacionesComprobantePago = H005E3_A580OperacionesComprobantePago[0];
               n580OperacionesComprobantePago = H005E3_n580OperacionesComprobantePago[0];
               A572OperacionesFacturaCod = H005E3_A572OperacionesFacturaCod[0];
               n572OperacionesFacturaCod = H005E3_n572OperacionesFacturaCod[0];
               A570OperacionesImporte = H005E3_A570OperacionesImporte[0];
               n570OperacionesImporte = H005E3_n570OperacionesImporte[0];
               A569OperacionesTipoES = H005E3_A569OperacionesTipoES[0];
               n569OperacionesTipoES = H005E3_n569OperacionesTipoES[0];
               A649OperacionesTipo = H005E3_A649OperacionesTipo[0];
               n649OperacionesTipo = H005E3_n649OperacionesTipo[0];
               A657OperacionesNombreRef = H005E3_A657OperacionesNombreRef[0];
               n657OperacionesNombreRef = H005E3_n657OperacionesNombreRef[0];
               A555OperacionesRef = H005E3_A555OperacionesRef[0];
               n555OperacionesRef = H005E3_n555OperacionesRef[0];
               A554OperacionesId = H005E3_A554OperacionesId[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV121Operacioneswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A554OperacionesId), 18, 0) , StringUtil.PadR( "%" + AV121Operacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A555OperacionesRef) , StringUtil.PadR( "%" + StringUtil.Upper( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A657OperacionesNombreRef) , StringUtil.PadR( "%" + StringUtil.Upper( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( context.GetMessage( "liquidación de solicitudes del profesional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "LSF") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "liquidación de  solicitudes comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "LSC") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "cobro de saldo pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "COL") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pago de saldo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A649OperacionesTipo, "POL") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro de solicitud", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "CSO") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "nota de credito", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "NCR") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "nota de debito", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A649OperacionesTipo, "NDE") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "OTR") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "solicitudes ingresadas desde fenicio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "FEN") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "respuesta de api fenicio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "FGO") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "comercio_externo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "CEX") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "entrada", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A569OperacionesTipoES, "E") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "salida", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A569OperacionesTipoES, "S") == 0 ) ) ||
               ( StringUtil.Like( StringUtil.Str( A570OperacionesImporte, 18, 2) , StringUtil.PadR( "%" + AV121Operacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A572OperacionesFacturaCod) , StringUtil.PadR( "%" + StringUtil.Upper( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A580OperacionesComprobantePago) , StringUtil.PadR( "%" + StringUtil.Upper( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "procesado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A577OperacionesEstado, "PRO") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A577OperacionesEstado, "PND") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "anulado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A577OperacionesEstado, "ANU") == 0 ) ) )
               )
               {
                  /* Execute user event: Grid.Load */
                  E215E2 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 45;
            WB5E0( ) ;
         }
         bGXsfl_45_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5E2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV120Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV120Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV82IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV82IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_PAGOSALDO", AV115IsAuthorized_PagoSaldo);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PAGOSALDO", GetSecureSignedToken( "", AV115IsAuthorized_PagoSaldo, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_COBROSALDO", AV116IsAuthorized_CobroSaldo);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_COBROSALDO", GetSecureSignedToken( "", AV116IsAuthorized_CobroSaldo, context));
         GxWebStd.gx_hidden_field( context, "gxhash_OPERACIONESTIPO"+"_"+sGXsfl_45_idx, GetSecureSignedToken( sGXsfl_45_idx, StringUtil.RTrim( context.localUtil.Format( A649OperacionesTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_OPERACIONESID"+"_"+sGXsfl_45_idx, GetSecureSignedToken( sGXsfl_45_idx, context.localUtil.Format( (decimal)(A554OperacionesId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vWALLETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV114WalletId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWALLETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV114WalletId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_OPERACIONESNOMBREREF"+"_"+sGXsfl_45_idx, GetSecureSignedToken( sGXsfl_45_idx, StringUtil.RTrim( context.localUtil.Format( A657OperacionesNombreRef, "")), context));
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
         AV121Operacioneswwds_1_filterfulltext = AV17FilterFullText;
         AV122Operacioneswwds_2_tfoperacionestipo_sels = AV102TFOperacionesTipo_Sels;
         AV123Operacioneswwds_3_tfoperacionescomprobantepago = AV117TFOperacionesComprobantePago;
         AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel = AV118TFOperacionesComprobantePago_Sel;
         AV125Operacioneswwds_5_tfoperacionesfechaalta = AV63TFOperacionesFechaAlta;
         AV126Operacioneswwds_6_tfoperacionesfechaalta_to = AV64TFOperacionesFechaAlta_To;
         AV127Operacioneswwds_7_tfoperacionesfechadesde = AV91TFOperacionesFechaDesde;
         AV128Operacioneswwds_8_tfoperacionesfechadesde_to = AV92TFOperacionesFechaDesde_To;
         AV129Operacioneswwds_9_tfoperacionesfechahasta = AV96TFOperacionesFechaHasta;
         AV130Operacioneswwds_10_tfoperacionesfechahasta_to = AV97TFOperacionesFechaHasta_To;
         AV131Operacioneswwds_11_tfoperacionesfechapago = AV68TFOperacionesFechaPago;
         AV132Operacioneswwds_12_tfoperacionesfechapago_to = AV69TFOperacionesFechaPago_To;
         AV133Operacioneswwds_13_tfoperacionesestado_sels = AV74TFOperacionesEstado_Sels;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV120Pgmname, AV17FilterFullText, AV102TFOperacionesTipo_Sels, AV117TFOperacionesComprobantePago, AV118TFOperacionesComprobantePago_Sel, AV63TFOperacionesFechaAlta, AV64TFOperacionesFechaAlta_To, AV91TFOperacionesFechaDesde, AV92TFOperacionesFechaDesde_To, AV96TFOperacionesFechaHasta, AV97TFOperacionesFechaHasta_To, AV68TFOperacionesFechaPago, AV69TFOperacionesFechaPago_To, AV74TFOperacionesEstado_Sels, AV108GridCollapsedRecords, AV82IsAuthorized_Update, AV115IsAuthorized_PagoSaldo, AV116IsAuthorized_CobroSaldo, AV107GridCollapsedRecordsChildren, AV114WalletId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV121Operacioneswwds_1_filterfulltext = AV17FilterFullText;
         AV122Operacioneswwds_2_tfoperacionestipo_sels = AV102TFOperacionesTipo_Sels;
         AV123Operacioneswwds_3_tfoperacionescomprobantepago = AV117TFOperacionesComprobantePago;
         AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel = AV118TFOperacionesComprobantePago_Sel;
         AV125Operacioneswwds_5_tfoperacionesfechaalta = AV63TFOperacionesFechaAlta;
         AV126Operacioneswwds_6_tfoperacionesfechaalta_to = AV64TFOperacionesFechaAlta_To;
         AV127Operacioneswwds_7_tfoperacionesfechadesde = AV91TFOperacionesFechaDesde;
         AV128Operacioneswwds_8_tfoperacionesfechadesde_to = AV92TFOperacionesFechaDesde_To;
         AV129Operacioneswwds_9_tfoperacionesfechahasta = AV96TFOperacionesFechaHasta;
         AV130Operacioneswwds_10_tfoperacionesfechahasta_to = AV97TFOperacionesFechaHasta_To;
         AV131Operacioneswwds_11_tfoperacionesfechapago = AV68TFOperacionesFechaPago;
         AV132Operacioneswwds_12_tfoperacionesfechapago_to = AV69TFOperacionesFechaPago_To;
         AV133Operacioneswwds_13_tfoperacionesestado_sels = AV74TFOperacionesEstado_Sels;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV120Pgmname, AV17FilterFullText, AV102TFOperacionesTipo_Sels, AV117TFOperacionesComprobantePago, AV118TFOperacionesComprobantePago_Sel, AV63TFOperacionesFechaAlta, AV64TFOperacionesFechaAlta_To, AV91TFOperacionesFechaDesde, AV92TFOperacionesFechaDesde_To, AV96TFOperacionesFechaHasta, AV97TFOperacionesFechaHasta_To, AV68TFOperacionesFechaPago, AV69TFOperacionesFechaPago_To, AV74TFOperacionesEstado_Sels, AV108GridCollapsedRecords, AV82IsAuthorized_Update, AV115IsAuthorized_PagoSaldo, AV116IsAuthorized_CobroSaldo, AV107GridCollapsedRecordsChildren, AV114WalletId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV121Operacioneswwds_1_filterfulltext = AV17FilterFullText;
         AV122Operacioneswwds_2_tfoperacionestipo_sels = AV102TFOperacionesTipo_Sels;
         AV123Operacioneswwds_3_tfoperacionescomprobantepago = AV117TFOperacionesComprobantePago;
         AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel = AV118TFOperacionesComprobantePago_Sel;
         AV125Operacioneswwds_5_tfoperacionesfechaalta = AV63TFOperacionesFechaAlta;
         AV126Operacioneswwds_6_tfoperacionesfechaalta_to = AV64TFOperacionesFechaAlta_To;
         AV127Operacioneswwds_7_tfoperacionesfechadesde = AV91TFOperacionesFechaDesde;
         AV128Operacioneswwds_8_tfoperacionesfechadesde_to = AV92TFOperacionesFechaDesde_To;
         AV129Operacioneswwds_9_tfoperacionesfechahasta = AV96TFOperacionesFechaHasta;
         AV130Operacioneswwds_10_tfoperacionesfechahasta_to = AV97TFOperacionesFechaHasta_To;
         AV131Operacioneswwds_11_tfoperacionesfechapago = AV68TFOperacionesFechaPago;
         AV132Operacioneswwds_12_tfoperacionesfechapago_to = AV69TFOperacionesFechaPago_To;
         AV133Operacioneswwds_13_tfoperacionesestado_sels = AV74TFOperacionesEstado_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV120Pgmname, AV17FilterFullText, AV102TFOperacionesTipo_Sels, AV117TFOperacionesComprobantePago, AV118TFOperacionesComprobantePago_Sel, AV63TFOperacionesFechaAlta, AV64TFOperacionesFechaAlta_To, AV91TFOperacionesFechaDesde, AV92TFOperacionesFechaDesde_To, AV96TFOperacionesFechaHasta, AV97TFOperacionesFechaHasta_To, AV68TFOperacionesFechaPago, AV69TFOperacionesFechaPago_To, AV74TFOperacionesEstado_Sels, AV108GridCollapsedRecords, AV82IsAuthorized_Update, AV115IsAuthorized_PagoSaldo, AV116IsAuthorized_CobroSaldo, AV107GridCollapsedRecordsChildren, AV114WalletId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV121Operacioneswwds_1_filterfulltext = AV17FilterFullText;
         AV122Operacioneswwds_2_tfoperacionestipo_sels = AV102TFOperacionesTipo_Sels;
         AV123Operacioneswwds_3_tfoperacionescomprobantepago = AV117TFOperacionesComprobantePago;
         AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel = AV118TFOperacionesComprobantePago_Sel;
         AV125Operacioneswwds_5_tfoperacionesfechaalta = AV63TFOperacionesFechaAlta;
         AV126Operacioneswwds_6_tfoperacionesfechaalta_to = AV64TFOperacionesFechaAlta_To;
         AV127Operacioneswwds_7_tfoperacionesfechadesde = AV91TFOperacionesFechaDesde;
         AV128Operacioneswwds_8_tfoperacionesfechadesde_to = AV92TFOperacionesFechaDesde_To;
         AV129Operacioneswwds_9_tfoperacionesfechahasta = AV96TFOperacionesFechaHasta;
         AV130Operacioneswwds_10_tfoperacionesfechahasta_to = AV97TFOperacionesFechaHasta_To;
         AV131Operacioneswwds_11_tfoperacionesfechapago = AV68TFOperacionesFechaPago;
         AV132Operacioneswwds_12_tfoperacionesfechapago_to = AV69TFOperacionesFechaPago_To;
         AV133Operacioneswwds_13_tfoperacionesestado_sels = AV74TFOperacionesEstado_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV120Pgmname, AV17FilterFullText, AV102TFOperacionesTipo_Sels, AV117TFOperacionesComprobantePago, AV118TFOperacionesComprobantePago_Sel, AV63TFOperacionesFechaAlta, AV64TFOperacionesFechaAlta_To, AV91TFOperacionesFechaDesde, AV92TFOperacionesFechaDesde_To, AV96TFOperacionesFechaHasta, AV97TFOperacionesFechaHasta_To, AV68TFOperacionesFechaPago, AV69TFOperacionesFechaPago_To, AV74TFOperacionesEstado_Sels, AV108GridCollapsedRecords, AV82IsAuthorized_Update, AV115IsAuthorized_PagoSaldo, AV116IsAuthorized_CobroSaldo, AV107GridCollapsedRecordsChildren, AV114WalletId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV121Operacioneswwds_1_filterfulltext = AV17FilterFullText;
         AV122Operacioneswwds_2_tfoperacionestipo_sels = AV102TFOperacionesTipo_Sels;
         AV123Operacioneswwds_3_tfoperacionescomprobantepago = AV117TFOperacionesComprobantePago;
         AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel = AV118TFOperacionesComprobantePago_Sel;
         AV125Operacioneswwds_5_tfoperacionesfechaalta = AV63TFOperacionesFechaAlta;
         AV126Operacioneswwds_6_tfoperacionesfechaalta_to = AV64TFOperacionesFechaAlta_To;
         AV127Operacioneswwds_7_tfoperacionesfechadesde = AV91TFOperacionesFechaDesde;
         AV128Operacioneswwds_8_tfoperacionesfechadesde_to = AV92TFOperacionesFechaDesde_To;
         AV129Operacioneswwds_9_tfoperacionesfechahasta = AV96TFOperacionesFechaHasta;
         AV130Operacioneswwds_10_tfoperacionesfechahasta_to = AV97TFOperacionesFechaHasta_To;
         AV131Operacioneswwds_11_tfoperacionesfechapago = AV68TFOperacionesFechaPago;
         AV132Operacioneswwds_12_tfoperacionesfechapago_to = AV69TFOperacionesFechaPago_To;
         AV133Operacioneswwds_13_tfoperacionesestado_sels = AV74TFOperacionesEstado_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV120Pgmname, AV17FilterFullText, AV102TFOperacionesTipo_Sels, AV117TFOperacionesComprobantePago, AV118TFOperacionesComprobantePago_Sel, AV63TFOperacionesFechaAlta, AV64TFOperacionesFechaAlta_To, AV91TFOperacionesFechaDesde, AV92TFOperacionesFechaDesde_To, AV96TFOperacionesFechaHasta, AV97TFOperacionesFechaHasta_To, AV68TFOperacionesFechaPago, AV69TFOperacionesFechaPago_To, AV74TFOperacionesEstado_Sels, AV108GridCollapsedRecords, AV82IsAuthorized_Update, AV115IsAuthorized_PagoSaldo, AV116IsAuthorized_CobroSaldo, AV107GridCollapsedRecordsChildren, AV114WalletId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV120Pgmname = "OperacionesWW";
         edtavExpand_Enabled = 0;
         edtavGrid_groupcaption_Enabled = 0;
         edtOperacionesId_Enabled = 0;
         edtOperacionesRef_Enabled = 0;
         edtOperacionesNombreRef_Enabled = 0;
         cmbOperacionesTipo.Enabled = 0;
         cmbOperacionesTipoES.Enabled = 0;
         edtOperacionesImporte_Enabled = 0;
         edtOperacionesFacturaCod_Enabled = 0;
         edtOperacionesComprobantePago_Enabled = 0;
         edtOperacionesFechaAlta_Enabled = 0;
         edtOperacionesFechaDesde_Enabled = 0;
         edtOperacionesFechaHasta_Enabled = 0;
         edtOperacionesFechaPago_Enabled = 0;
         cmbOperacionesEstado.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E195E2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV38ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vLIQUIDACIONESDATA"), AV103LiquidacionesData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV84AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV75DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV35ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_45 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_45"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV77GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV78GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV79GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddo_liquidaciones_Icontype = cgiGet( "DDO_LIQUIDACIONES_Icontype");
            Ddo_liquidaciones_Icon = cgiGet( "DDO_LIQUIDACIONES_Icon");
            Ddo_liquidaciones_Caption = cgiGet( "DDO_LIQUIDACIONES_Caption");
            Ddo_liquidaciones_Cls = cgiGet( "DDO_LIQUIDACIONES_Cls");
            Ddo_liquidaciones_Visible = StringUtil.StrToBool( cgiGet( "DDO_LIQUIDACIONES_Visible"));
            Ddo_liquidaciones_Titlecontrolidtoreplace = cgiGet( "DDO_LIQUIDACIONES_Titlecontrolidtoreplace");
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
            Grid_titlescategories_Gridinternalname = cgiGet( "GRID_TITLESCATEGORIES_Gridinternalname");
            Grid_titlescategories_Gridtitlescategories = cgiGet( "GRID_TITLESCATEGORIES_Gridtitlescategories");
            Grid_group_Gridinternalname = cgiGet( "GRID_GROUP_Gridinternalname");
            Grid_group_Columnindex = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_GROUP_Columnindex"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hascategories = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascategories"));
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascolumnsselector"));
            Grid_empowerer_Hasrowgroups = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hasrowgroups"));
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
            if ( context.localUtil.VCDate( cgiGet( edtavDdo_operacionesfechaaltaauxdate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "DDO_Operaciones Fecha Alta Aux Date", "")}), 1, "vDDO_OPERACIONESFECHAALTAAUXDATE");
               GX_FocusControl = edtavDdo_operacionesfechaaltaauxdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV65DDO_OperacionesFechaAltaAuxDate = DateTime.MinValue;
               AssignAttri("", false, "AV65DDO_OperacionesFechaAltaAuxDate", context.localUtil.Format(AV65DDO_OperacionesFechaAltaAuxDate, "99/99/99"));
            }
            else
            {
               AV65DDO_OperacionesFechaAltaAuxDate = context.localUtil.CToD( cgiGet( edtavDdo_operacionesfechaaltaauxdate_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV65DDO_OperacionesFechaAltaAuxDate", context.localUtil.Format(AV65DDO_OperacionesFechaAltaAuxDate, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavDdo_operacionesfechaaltaauxdateto_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "DDO_Operaciones Fecha Alta Aux Date To", "")}), 1, "vDDO_OPERACIONESFECHAALTAAUXDATETO");
               GX_FocusControl = edtavDdo_operacionesfechaaltaauxdateto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV66DDO_OperacionesFechaAltaAuxDateTo = DateTime.MinValue;
               AssignAttri("", false, "AV66DDO_OperacionesFechaAltaAuxDateTo", context.localUtil.Format(AV66DDO_OperacionesFechaAltaAuxDateTo, "99/99/99"));
            }
            else
            {
               AV66DDO_OperacionesFechaAltaAuxDateTo = context.localUtil.CToD( cgiGet( edtavDdo_operacionesfechaaltaauxdateto_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV66DDO_OperacionesFechaAltaAuxDateTo", context.localUtil.Format(AV66DDO_OperacionesFechaAltaAuxDateTo, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavDdo_operacionesfechadesdeauxdate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "DDO_Operaciones Fecha Desde Aux Date", "")}), 1, "vDDO_OPERACIONESFECHADESDEAUXDATE");
               GX_FocusControl = edtavDdo_operacionesfechadesdeauxdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV93DDO_OperacionesFechaDesdeAuxDate = DateTime.MinValue;
               AssignAttri("", false, "AV93DDO_OperacionesFechaDesdeAuxDate", context.localUtil.Format(AV93DDO_OperacionesFechaDesdeAuxDate, "99/99/99"));
            }
            else
            {
               AV93DDO_OperacionesFechaDesdeAuxDate = context.localUtil.CToD( cgiGet( edtavDdo_operacionesfechadesdeauxdate_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV93DDO_OperacionesFechaDesdeAuxDate", context.localUtil.Format(AV93DDO_OperacionesFechaDesdeAuxDate, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavDdo_operacionesfechadesdeauxdateto_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "DDO_Operaciones Fecha Desde Aux Date To", "")}), 1, "vDDO_OPERACIONESFECHADESDEAUXDATETO");
               GX_FocusControl = edtavDdo_operacionesfechadesdeauxdateto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV94DDO_OperacionesFechaDesdeAuxDateTo = DateTime.MinValue;
               AssignAttri("", false, "AV94DDO_OperacionesFechaDesdeAuxDateTo", context.localUtil.Format(AV94DDO_OperacionesFechaDesdeAuxDateTo, "99/99/99"));
            }
            else
            {
               AV94DDO_OperacionesFechaDesdeAuxDateTo = context.localUtil.CToD( cgiGet( edtavDdo_operacionesfechadesdeauxdateto_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV94DDO_OperacionesFechaDesdeAuxDateTo", context.localUtil.Format(AV94DDO_OperacionesFechaDesdeAuxDateTo, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavDdo_operacionesfechahastaauxdate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "DDO_Operaciones Fecha Hasta Aux Date", "")}), 1, "vDDO_OPERACIONESFECHAHASTAAUXDATE");
               GX_FocusControl = edtavDdo_operacionesfechahastaauxdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV98DDO_OperacionesFechaHastaAuxDate = DateTime.MinValue;
               AssignAttri("", false, "AV98DDO_OperacionesFechaHastaAuxDate", context.localUtil.Format(AV98DDO_OperacionesFechaHastaAuxDate, "99/99/99"));
            }
            else
            {
               AV98DDO_OperacionesFechaHastaAuxDate = context.localUtil.CToD( cgiGet( edtavDdo_operacionesfechahastaauxdate_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV98DDO_OperacionesFechaHastaAuxDate", context.localUtil.Format(AV98DDO_OperacionesFechaHastaAuxDate, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavDdo_operacionesfechahastaauxdateto_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "DDO_Operaciones Fecha Hasta Aux Date To", "")}), 1, "vDDO_OPERACIONESFECHAHASTAAUXDATETO");
               GX_FocusControl = edtavDdo_operacionesfechahastaauxdateto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV99DDO_OperacionesFechaHastaAuxDateTo = DateTime.MinValue;
               AssignAttri("", false, "AV99DDO_OperacionesFechaHastaAuxDateTo", context.localUtil.Format(AV99DDO_OperacionesFechaHastaAuxDateTo, "99/99/99"));
            }
            else
            {
               AV99DDO_OperacionesFechaHastaAuxDateTo = context.localUtil.CToD( cgiGet( edtavDdo_operacionesfechahastaauxdateto_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV99DDO_OperacionesFechaHastaAuxDateTo", context.localUtil.Format(AV99DDO_OperacionesFechaHastaAuxDateTo, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavDdo_operacionesfechapagoauxdate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "DDO_Operaciones Fecha Pago Aux Date", "")}), 1, "vDDO_OPERACIONESFECHAPAGOAUXDATE");
               GX_FocusControl = edtavDdo_operacionesfechapagoauxdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV70DDO_OperacionesFechaPagoAuxDate = DateTime.MinValue;
               AssignAttri("", false, "AV70DDO_OperacionesFechaPagoAuxDate", context.localUtil.Format(AV70DDO_OperacionesFechaPagoAuxDate, "99/99/99"));
            }
            else
            {
               AV70DDO_OperacionesFechaPagoAuxDate = context.localUtil.CToD( cgiGet( edtavDdo_operacionesfechapagoauxdate_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV70DDO_OperacionesFechaPagoAuxDate", context.localUtil.Format(AV70DDO_OperacionesFechaPagoAuxDate, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavDdo_operacionesfechapagoauxdateto_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "DDO_Operaciones Fecha Pago Aux Date To", "")}), 1, "vDDO_OPERACIONESFECHAPAGOAUXDATETO");
               GX_FocusControl = edtavDdo_operacionesfechapagoauxdateto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV71DDO_OperacionesFechaPagoAuxDateTo = DateTime.MinValue;
               AssignAttri("", false, "AV71DDO_OperacionesFechaPagoAuxDateTo", context.localUtil.Format(AV71DDO_OperacionesFechaPagoAuxDateTo, "99/99/99"));
            }
            else
            {
               AV71DDO_OperacionesFechaPagoAuxDateTo = context.localUtil.CToD( cgiGet( edtavDdo_operacionesfechapagoauxdateto_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV71DDO_OperacionesFechaPagoAuxDateTo", context.localUtil.Format(AV71DDO_OperacionesFechaPagoAuxDateTo, "99/99/99"));
            }
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
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E195E2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E195E2( )
      {
         /* Start Routine */
         returnInSub = false;
         Grid_group_Gridinternalname = subGrid_Internalname;
         ucGrid_group.SendProperty(context, "", false, Grid_group_Internalname, "GridInternalName", Grid_group_Gridinternalname);
         subGrid_Rows = 50;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         Grid_titlescategories_Gridinternalname = subGrid_Internalname;
         ucGrid_titlescategories.SendProperty(context, "", false, Grid_titlescategories_Internalname, "GridInternalName", Grid_titlescategories_Gridinternalname);
         Grid_titlescategories_Gridtitlescategories = StringUtil.Format( ";;;%1;%1;%1;%1;%1;%1;%1;%1;%2;%2;%2;%2;", context.GetMessage( "Operación", ""), context.GetMessage( "Fechas", ""), "", "", "", "", "", "", "");
         ucGrid_titlescategories.SendProperty(context, "", false, Grid_titlescategories_Internalname, "GridTitlesCategories", Grid_titlescategories_Gridtitlescategories);
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
         Ddo_liquidaciones_Titlecontrolidtoreplace = bttBtnliquidaciones_Internalname;
         ucDdo_liquidaciones.SendProperty(context, "", false, Ddo_liquidaciones_Internalname, "TitleControlIdToReplace", Ddo_liquidaciones_Titlecontrolidtoreplace);
         AV103LiquidacionesData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         GXt_boolean1 = AV86TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "OperacionWP", out  GXt_boolean1) ;
         AV86TempBoolean = GXt_boolean1;
         if ( AV86TempBoolean )
         {
            AV104LiquidacionesDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
            AV104LiquidacionesDataItem.gxTpr_Title = context.GetMessage( "Comercios", "");
            AV104LiquidacionesDataItem.gxTpr_Fonticon = "fas fa-building-user";
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "operacionwp.aspx"+UrlEncode(StringUtil.RTrim("LSC")) + "," + UrlEncode(StringUtil.LTrimStr(AV119Nullvalue,10,2)) + "," + UrlEncode(StringUtil.RTrim(""));
            AV104LiquidacionesDataItem.gxTpr_Link = formatLink("operacionwp.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AV104LiquidacionesDataItem.gxTpr_Isdivider = false;
            AV103LiquidacionesData.Add(AV104LiquidacionesDataItem, 0);
         }
         GXt_boolean1 = AV86TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "OperacionWP", out  GXt_boolean1) ;
         AV86TempBoolean = GXt_boolean1;
         if ( AV86TempBoolean )
         {
            AV104LiquidacionesDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
            AV104LiquidacionesDataItem.gxTpr_Title = context.GetMessage( "Profesionales", "");
            AV104LiquidacionesDataItem.gxTpr_Fonticon = "fas fa-clipboard-user";
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "operacionwp.aspx"+UrlEncode(StringUtil.RTrim("LSF")) + "," + UrlEncode(StringUtil.LTrimStr(AV119Nullvalue,10,2)) + "," + UrlEncode(StringUtil.RTrim(""));
            AV104LiquidacionesDataItem.gxTpr_Link = formatLink("operacionwp.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AV104LiquidacionesDataItem.gxTpr_Isdivider = false;
            AV103LiquidacionesData.Add(AV104LiquidacionesDataItem, 0);
         }
         if ( AV103LiquidacionesData.Count == 0 )
         {
            Ddo_liquidaciones_Visible = false;
            ucDdo_liquidaciones.SendProperty(context, "", false, Ddo_liquidaciones_Internalname, "Visible", StringUtil.BoolToStr( Ddo_liquidaciones_Visible));
         }
         Ddo_agexport_Titlecontrolidtoreplace = bttBtnagexport_Internalname;
         ucDdo_agexport.SendProperty(context, "", false, Ddo_agexport_Internalname, "TitleControlIdToReplace", Ddo_agexport_Titlecontrolidtoreplace);
         AV84AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV85AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV85AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportCaption", "");
         AV85AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV85AGExportDataItem.gxTpr_Eventkey = "Export";
         AV85AGExportDataItem.gxTpr_Isdivider = false;
         AV84AGExportData.Add(AV85AGExportDataItem, 0);
         AV85AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV85AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportReportCaption", "");
         AV85AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV85AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV85AGExportDataItem.gxTpr_Isdivider = false;
         AV84AGExportData.Add(AV85AGExportDataItem, 0);
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         AV103LiquidacionesData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         GXt_boolean1 = AV86TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "OperacionWP", out  GXt_boolean1) ;
         AV86TempBoolean = GXt_boolean1;
         if ( AV86TempBoolean )
         {
            AV104LiquidacionesDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
            AV104LiquidacionesDataItem.gxTpr_Title = context.GetMessage( "Comercios", "");
            AV104LiquidacionesDataItem.gxTpr_Fonticon = "fas fa-building-user";
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "operacionwp.aspx"+UrlEncode(StringUtil.RTrim("LSC")) + "," + UrlEncode(StringUtil.LTrimStr(AV119Nullvalue,10,2)) + "," + UrlEncode(StringUtil.RTrim(""));
            AV104LiquidacionesDataItem.gxTpr_Link = formatLink("operacionwp.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AV104LiquidacionesDataItem.gxTpr_Isdivider = false;
            AV103LiquidacionesData.Add(AV104LiquidacionesDataItem, 0);
         }
         GXt_boolean1 = AV86TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "OperacionWP", out  GXt_boolean1) ;
         AV86TempBoolean = GXt_boolean1;
         if ( AV86TempBoolean )
         {
            AV104LiquidacionesDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
            AV104LiquidacionesDataItem.gxTpr_Title = context.GetMessage( "Profesionales", "");
            AV104LiquidacionesDataItem.gxTpr_Fonticon = "fas fa-clipboard-user";
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "operacionwp.aspx"+UrlEncode(StringUtil.RTrim("LSF")) + "," + UrlEncode(StringUtil.LTrimStr(AV119Nullvalue,10,2)) + "," + UrlEncode(StringUtil.RTrim(""));
            AV104LiquidacionesDataItem.gxTpr_Link = formatLink("operacionwp.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AV104LiquidacionesDataItem.gxTpr_Isdivider = false;
            AV103LiquidacionesData.Add(AV104LiquidacionesDataItem, 0);
         }
         if ( AV103LiquidacionesData.Count == 0 )
         {
            Ddo_liquidaciones_Visible = false;
            ucDdo_liquidaciones.SendProperty(context, "", false, Ddo_liquidaciones_Internalname, "Visible", StringUtil.BoolToStr( Ddo_liquidaciones_Visible));
         }
         AV84AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV85AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV85AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportCaption", "");
         AV85AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV85AGExportDataItem.gxTpr_Eventkey = "Export";
         AV85AGExportDataItem.gxTpr_Isdivider = false;
         AV84AGExportData.Add(AV85AGExportDataItem, 0);
         AV85AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV85AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportReportCaption", "");
         AV85AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV85AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV85AGExportDataItem.gxTpr_Isdivider = false;
         AV84AGExportData.Add(AV85AGExportDataItem, 0);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( " Operaciones", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
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
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV75DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV75DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E205E2( )
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
         S152 ();
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
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV37Session.Get("OperacionesWWColumnsSelector"), "") != 0 )
         {
            AV33ColumnsSelectorXML = AV37Session.Get("OperacionesWWColumnsSelector");
            AV35ColumnsSelector.FromXml(AV33ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtOperacionesId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtOperacionesId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOperacionesId_Visible), 5, 0), !bGXsfl_45_Refreshing);
         edtOperacionesRef_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtOperacionesRef_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOperacionesRef_Visible), 5, 0), !bGXsfl_45_Refreshing);
         edtOperacionesNombreRef_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtOperacionesNombreRef_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOperacionesNombreRef_Visible), 5, 0), !bGXsfl_45_Refreshing);
         cmbOperacionesTipo.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbOperacionesTipo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbOperacionesTipo.Visible), 5, 0), !bGXsfl_45_Refreshing);
         cmbOperacionesTipoES.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbOperacionesTipoES_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbOperacionesTipoES.Visible), 5, 0), !bGXsfl_45_Refreshing);
         edtOperacionesImporte_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtOperacionesImporte_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOperacionesImporte_Visible), 5, 0), !bGXsfl_45_Refreshing);
         edtOperacionesFacturaCod_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtOperacionesFacturaCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOperacionesFacturaCod_Visible), 5, 0), !bGXsfl_45_Refreshing);
         edtOperacionesComprobantePago_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtOperacionesComprobantePago_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOperacionesComprobantePago_Visible), 5, 0), !bGXsfl_45_Refreshing);
         edtOperacionesFechaAlta_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(9)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtOperacionesFechaAlta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOperacionesFechaAlta_Visible), 5, 0), !bGXsfl_45_Refreshing);
         edtOperacionesFechaDesde_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(10)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtOperacionesFechaDesde_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOperacionesFechaDesde_Visible), 5, 0), !bGXsfl_45_Refreshing);
         edtOperacionesFechaHasta_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(11)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtOperacionesFechaHasta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOperacionesFechaHasta_Visible), 5, 0), !bGXsfl_45_Refreshing);
         edtOperacionesFechaPago_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(12)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtOperacionesFechaPago_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOperacionesFechaPago_Visible), 5, 0), !bGXsfl_45_Refreshing);
         cmbOperacionesEstado.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(13)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbOperacionesEstado_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbOperacionesEstado.Visible), 5, 0), !bGXsfl_45_Refreshing);
         AV77GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV77GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV77GridCurrentPage), 10, 0));
         AV78GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV78GridPageCount", StringUtil.LTrimStr( (decimal)(AV78GridPageCount), 10, 0));
         GXt_char3 = AV79GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV120Pgmname, out  GXt_char3) ;
         AV79GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV79GridAppliedFilters", AV79GridAppliedFilters);
         edtavExpand_Columnheaderclass = "WWIconActionColumn";
         AssignProp("", false, edtavExpand_Internalname, "Columnheaderclass", edtavExpand_Columnheaderclass, !bGXsfl_45_Refreshing);
         cmbavGridactions_Columnheaderclass = "WWActionGroupColumn";
         AssignProp("", false, cmbavGridactions_Internalname, "Columnheaderclass", cmbavGridactions_Columnheaderclass, !bGXsfl_45_Refreshing);
         edtOperacionesId_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtOperacionesId_Internalname, "Columnheaderclass", edtOperacionesId_Columnheaderclass, !bGXsfl_45_Refreshing);
         edtOperacionesRef_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtOperacionesRef_Internalname, "Columnheaderclass", edtOperacionesRef_Columnheaderclass, !bGXsfl_45_Refreshing);
         edtOperacionesNombreRef_Columnheaderclass = "WWColumn hidden-xs";
         AssignProp("", false, edtOperacionesNombreRef_Internalname, "Columnheaderclass", edtOperacionesNombreRef_Columnheaderclass, !bGXsfl_45_Refreshing);
         cmbOperacionesTipo_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbOperacionesTipo_Internalname, "Columnheaderclass", cmbOperacionesTipo_Columnheaderclass, !bGXsfl_45_Refreshing);
         cmbOperacionesTipoES_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbOperacionesTipoES_Internalname, "Columnheaderclass", cmbOperacionesTipoES_Columnheaderclass, !bGXsfl_45_Refreshing);
         edtOperacionesImporte_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtOperacionesImporte_Internalname, "Columnheaderclass", edtOperacionesImporte_Columnheaderclass, !bGXsfl_45_Refreshing);
         edtOperacionesFacturaCod_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtOperacionesFacturaCod_Internalname, "Columnheaderclass", edtOperacionesFacturaCod_Columnheaderclass, !bGXsfl_45_Refreshing);
         edtOperacionesComprobantePago_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtOperacionesComprobantePago_Internalname, "Columnheaderclass", edtOperacionesComprobantePago_Columnheaderclass, !bGXsfl_45_Refreshing);
         edtOperacionesFechaAlta_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtOperacionesFechaAlta_Internalname, "Columnheaderclass", edtOperacionesFechaAlta_Columnheaderclass, !bGXsfl_45_Refreshing);
         edtOperacionesFechaDesde_Columnheaderclass = "WWColumn hidden-xs";
         AssignProp("", false, edtOperacionesFechaDesde_Internalname, "Columnheaderclass", edtOperacionesFechaDesde_Columnheaderclass, !bGXsfl_45_Refreshing);
         edtOperacionesFechaHasta_Columnheaderclass = "WWColumn hidden-xs";
         AssignProp("", false, edtOperacionesFechaHasta_Internalname, "Columnheaderclass", edtOperacionesFechaHasta_Columnheaderclass, !bGXsfl_45_Refreshing);
         edtOperacionesFechaPago_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtOperacionesFechaPago_Internalname, "Columnheaderclass", edtOperacionesFechaPago_Columnheaderclass, !bGXsfl_45_Refreshing);
         cmbOperacionesEstado_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbOperacionesEstado_Internalname, "Columnheaderclass", cmbOperacionesEstado_Columnheaderclass, !bGXsfl_45_Refreshing);
         AV105Grid_GroupCaption = "";
         AssignAttri("", false, edtavGrid_groupcaption_Internalname, AV105Grid_GroupCaption);
         AV121Operacioneswwds_1_filterfulltext = AV17FilterFullText;
         AV122Operacioneswwds_2_tfoperacionestipo_sels = AV102TFOperacionesTipo_Sels;
         AV123Operacioneswwds_3_tfoperacionescomprobantepago = AV117TFOperacionesComprobantePago;
         AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel = AV118TFOperacionesComprobantePago_Sel;
         AV125Operacioneswwds_5_tfoperacionesfechaalta = AV63TFOperacionesFechaAlta;
         AV126Operacioneswwds_6_tfoperacionesfechaalta_to = AV64TFOperacionesFechaAlta_To;
         AV127Operacioneswwds_7_tfoperacionesfechadesde = AV91TFOperacionesFechaDesde;
         AV128Operacioneswwds_8_tfoperacionesfechadesde_to = AV92TFOperacionesFechaDesde_To;
         AV129Operacioneswwds_9_tfoperacionesfechahasta = AV96TFOperacionesFechaHasta;
         AV130Operacioneswwds_10_tfoperacionesfechahasta_to = AV97TFOperacionesFechaHasta_To;
         AV131Operacioneswwds_11_tfoperacionesfechapago = AV68TFOperacionesFechaPago;
         AV132Operacioneswwds_12_tfoperacionesfechapago_to = AV69TFOperacionesFechaPago_To;
         AV133Operacioneswwds_13_tfoperacionesestado_sels = AV74TFOperacionesEstado_Sels;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV108GridCollapsedRecords", AV108GridCollapsedRecords);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV107GridCollapsedRecordsChildren", AV107GridCollapsedRecordsChildren);
      }

      protected void E125E2( )
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
            AV76PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV76PageToGo) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV108GridCollapsedRecords", AV108GridCollapsedRecords);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV107GridCollapsedRecordsChildren", AV107GridCollapsedRecordsChildren);
      }

      protected void E135E2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E165E2( )
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
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacionesTipo") == 0 )
            {
               AV101TFOperacionesTipo_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV101TFOperacionesTipo_SelsJson", AV101TFOperacionesTipo_SelsJson);
               AV102TFOperacionesTipo_Sels.FromJSonString(AV101TFOperacionesTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacionesComprobantePago") == 0 )
            {
               AV117TFOperacionesComprobantePago = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV117TFOperacionesComprobantePago", AV117TFOperacionesComprobantePago);
               AV118TFOperacionesComprobantePago_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV118TFOperacionesComprobantePago_Sel", AV118TFOperacionesComprobantePago_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacionesFechaAlta") == 0 )
            {
               AV63TFOperacionesFechaAlta = context.localUtil.CToD( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV63TFOperacionesFechaAlta", context.localUtil.Format(AV63TFOperacionesFechaAlta, "99/99/99"));
               AV64TFOperacionesFechaAlta_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV64TFOperacionesFechaAlta_To", context.localUtil.Format(AV64TFOperacionesFechaAlta_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacionesFechaDesde") == 0 )
            {
               AV91TFOperacionesFechaDesde = context.localUtil.CToD( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV91TFOperacionesFechaDesde", context.localUtil.Format(AV91TFOperacionesFechaDesde, "99/99/99"));
               AV92TFOperacionesFechaDesde_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV92TFOperacionesFechaDesde_To", context.localUtil.Format(AV92TFOperacionesFechaDesde_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacionesFechaHasta") == 0 )
            {
               AV96TFOperacionesFechaHasta = context.localUtil.CToD( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV96TFOperacionesFechaHasta", context.localUtil.Format(AV96TFOperacionesFechaHasta, "99/99/99"));
               AV97TFOperacionesFechaHasta_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV97TFOperacionesFechaHasta_To", context.localUtil.Format(AV97TFOperacionesFechaHasta_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacionesFechaPago") == 0 )
            {
               AV68TFOperacionesFechaPago = context.localUtil.CToT( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV68TFOperacionesFechaPago", context.localUtil.TToC( AV68TFOperacionesFechaPago, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV69TFOperacionesFechaPago_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV69TFOperacionesFechaPago_To", context.localUtil.TToC( AV69TFOperacionesFechaPago_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               if ( ! (DateTime.MinValue==AV69TFOperacionesFechaPago_To) )
               {
                  AV69TFOperacionesFechaPago_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV69TFOperacionesFechaPago_To)), (short)(DateTimeUtil.Month( AV69TFOperacionesFechaPago_To)), (short)(DateTimeUtil.Day( AV69TFOperacionesFechaPago_To)), 23, 59, 59);
                  AssignAttri("", false, "AV69TFOperacionesFechaPago_To", context.localUtil.TToC( AV69TFOperacionesFechaPago_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OperacionesEstado") == 0 )
            {
               AV73TFOperacionesEstado_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV73TFOperacionesEstado_SelsJson", AV73TFOperacionesEstado_SelsJson);
               AV74TFOperacionesEstado_Sels.FromJSonString(AV73TFOperacionesEstado_SelsJson, null);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV74TFOperacionesEstado_Sels", AV74TFOperacionesEstado_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV102TFOperacionesTipo_Sels", AV102TFOperacionesTipo_Sels);
      }

      private void E215E2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            AV105Grid_GroupCaption = StringUtil.Trim( context.GetMessage( gxdomaintipooperacionenum.getDescription(context,A649OperacionesTipo), ""));
            AssignAttri("", false, edtavGrid_groupcaption_Internalname, AV105Grid_GroupCaption);
            AV105Grid_GroupCaption = StringUtil.Format( "%1: %2", context.GetMessage( "Concepto", ""), (String.IsNullOrEmpty(StringUtil.RTrim( A649OperacionesTipo)) ? context.GetMessage( "WWP_FilterEmpty", "") : AV105Grid_GroupCaption), "", "", "", "", "", "", "");
            AssignAttri("", false, edtavGrid_groupcaption_Internalname, AV105Grid_GroupCaption);
            AV109Index = AV108GridCollapsedRecords.IndexOf(StringUtil.Trim( A649OperacionesTipo));
            AV113Expand = ((AV109Index>0) ? "<i class=\"fas fa-angle-right\"></i>" : "<i class=\"fas fa-angle-down\"></i>");
            AssignAttri("", false, edtavExpand_Internalname, AV113Expand);
            edtavExpand_Columnclass = ((AV109Index>0) ? "WWPExpand" : "WWPCollapse");
            cmbavGridactions.removeAllItems();
            cmbavGridactions.addItem("0", ";fa fa-bars", 0);
            cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
            if ( AV82IsAuthorized_Update )
            {
               cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_update", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
            }
            if ( AV115IsAuthorized_PagoSaldo )
            {
               cmbavGridactions.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "Pago de Liquidación", ""), "fas fa-coins", "", "", "", "", "", "", ""), 0);
            }
            if ( AV116IsAuthorized_CobroSaldo )
            {
               cmbavGridactions.addItem("4", StringUtil.Format( "%1;%2", context.GetMessage( "Cobro de Liquidación", ""), "far fa-money-bill-1", "", "", "", "", "", "", ""), 0);
            }
            if ( StringUtil.StrCmp(A577OperacionesEstado, "PND") == 0 )
            {
               cmbavGridactions_Columnclass = "WWActionGroupColumn WWColumnInfo WWColumnInfoFirstColumn";
               edtOperacionesId_Columnclass = "WWColumn WWColumnInfo";
               edtOperacionesRef_Columnclass = "WWColumn WWColumnInfo";
               edtOperacionesNombreRef_Columnclass = "WWColumn WWColumnInfo hidden-xs";
               cmbOperacionesTipo_Columnclass = "WWColumn WWColumnInfo";
               cmbOperacionesTipoES_Columnclass = "WWColumn WWColumnInfo";
               edtOperacionesImporte_Columnclass = "WWColumn WWColumnInfo";
               edtOperacionesFacturaCod_Columnclass = "WWColumn WWColumnInfo";
               edtOperacionesComprobantePago_Columnclass = "WWColumn WWColumnInfo";
               edtOperacionesFechaAlta_Columnclass = "WWColumn WWColumnInfo";
               edtOperacionesFechaDesde_Columnclass = "WWColumn WWColumnInfo hidden-xs";
               edtOperacionesFechaHasta_Columnclass = "WWColumn WWColumnInfo hidden-xs";
               edtOperacionesFechaPago_Columnclass = "WWColumn WWColumnInfo";
               cmbOperacionesEstado_Columnclass = "WWColumn WWColumnInfo";
            }
            else if ( StringUtil.StrCmp(A577OperacionesEstado, "ANU") == 0 )
            {
               cmbavGridactions_Columnclass = "WWActionGroupColumn WWColumnDanger WWColumnDangerFirstColumn";
               edtOperacionesId_Columnclass = "WWColumn WWColumnDanger";
               edtOperacionesRef_Columnclass = "WWColumn WWColumnDanger";
               edtOperacionesNombreRef_Columnclass = "WWColumn WWColumnDanger hidden-xs";
               cmbOperacionesTipo_Columnclass = "WWColumn WWColumnDanger";
               cmbOperacionesTipoES_Columnclass = "WWColumn WWColumnDanger";
               edtOperacionesImporte_Columnclass = "WWColumn WWColumnDanger";
               edtOperacionesFacturaCod_Columnclass = "WWColumn WWColumnDanger";
               edtOperacionesComprobantePago_Columnclass = "WWColumn WWColumnDanger";
               edtOperacionesFechaAlta_Columnclass = "WWColumn WWColumnDanger";
               edtOperacionesFechaDesde_Columnclass = "WWColumn WWColumnDanger hidden-xs";
               edtOperacionesFechaHasta_Columnclass = "WWColumn WWColumnDanger hidden-xs";
               edtOperacionesFechaPago_Columnclass = "WWColumn WWColumnDanger";
               cmbOperacionesEstado_Columnclass = "WWColumn WWColumnDanger";
            }
            else
            {
               cmbavGridactions_Columnclass = "WWActionGroupColumn";
               edtOperacionesId_Columnclass = ((StringUtil.StrCmp(A577OperacionesEstado, "PRO")==0) ? "WWColumn WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell" : "WWColumn");
               edtOperacionesRef_Columnclass = "WWColumn";
               edtOperacionesNombreRef_Columnclass = "WWColumn hidden-xs";
               cmbOperacionesTipo_Columnclass = "WWColumn";
               cmbOperacionesTipoES_Columnclass = "WWColumn";
               edtOperacionesImporte_Columnclass = "WWColumn";
               edtOperacionesFacturaCod_Columnclass = "WWColumn";
               edtOperacionesComprobantePago_Columnclass = "WWColumn";
               edtOperacionesFechaAlta_Columnclass = "WWColumn";
               edtOperacionesFechaDesde_Columnclass = "WWColumn hidden-xs";
               edtOperacionesFechaHasta_Columnclass = "WWColumn hidden-xs";
               edtOperacionesFechaPago_Columnclass = "WWColumn";
               cmbOperacionesEstado_Columnclass = "WWColumn";
            }
            if ( AV107GridCollapsedRecordsChildren.Count == 0 )
            {
            }
            if ( ( ( StringUtil.StrCmp(A649OperacionesTipo, "LSC") != 0 ) && ( StringUtil.StrCmp(A649OperacionesTipo, "LSF") != 0 ) ) || String.IsNullOrEmpty(StringUtil.RTrim( A649OperacionesTipo)) || String.IsNullOrEmpty(StringUtil.RTrim( A555OperacionesRef)) || ( A570OperacionesImporte == Convert.ToDecimal( 0 )) || ( StringUtil.StrCmp(A649OperacionesTipo, "CSO") == 0 ) || ( StringUtil.StrCmp(A577OperacionesEstado, "PND") != 0 ) )
            {
               cmbavGridactions.removeItem(StringUtil.Str( (decimal)(3), 1, 0));
               cmbavGridactions.removeItem(StringUtil.Str( (decimal)(4), 1, 0));
            }
            else
            {
               if ( ( A570OperacionesImporte <= Convert.ToDecimal( -1 )) )
               {
                  cmbavGridactions.removeItem(StringUtil.Str( (decimal)(3), 1, 0));
               }
               if ( ( A570OperacionesImporte > Convert.ToDecimal( 0 )) )
               {
                  cmbavGridactions.removeItem(StringUtil.Str( (decimal)(4), 1, 0));
               }
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 45;
            }
            sendrow_452( ) ;
         }
         GRID_nEOF = (short)(((subGrid_Rows==0)||(GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_45_Refreshing )
         {
            context.DoAjaxLoad(45, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV80GridActions), 4, 0));
      }

      protected void E175E2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV33ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV35ColumnsSelector.FromJSonString(AV33ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "OperacionesWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV33ColumnsSelectorXML)) ? "" : AV35ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV108GridCollapsedRecords", AV108GridCollapsedRecords);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV107GridCollapsedRecordsChildren", AV107GridCollapsedRecordsChildren);
      }

      protected void E115E2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S182 ();
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
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("OperacionesWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV120Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("OperacionesWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV39ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "OperacionesWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV39ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV39ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S182 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV120Pgmname+"GridState",  AV39ManageFiltersXml) ;
               AV11GridState.FromXml(AV39ManageFiltersXml, null, "", "");
               AV14OrderedBy = AV11GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
               AV15OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S142 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S192 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               AV108GridCollapsedRecords.FromJSonString(AV11GridState.gxTpr_Collapsedrecords, null);
               if ( AV108GridCollapsedRecords.Count > 0 )
               {
                  AV112AddChildren = true;
                  AssignAttri("", false, "AV112AddChildren", AV112AddChildren);
                  AV134GXV1 = 1;
                  while ( AV134GXV1 <= AV108GridCollapsedRecords.Count )
                  {
                     AV106GroupOperacionesTipo = AV108GridCollapsedRecords.GetString(AV134GXV1);
                     AssignAttri("", false, "AV106GroupOperacionesTipo", AV106GroupOperacionesTipo);
                     /* Execute user subroutine: 'ADDREMOVECHILDREN' */
                     S262 ();
                     if ( returnInSub )
                     {
                        returnInSub = true;
                        if (true) return;
                     }
                     AV134GXV1 = (int)(AV134GXV1+1);
                  }
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV108GridCollapsedRecords", AV108GridCollapsedRecords);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV102TFOperacionesTipo_Sels", AV102TFOperacionesTipo_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV74TFOperacionesEstado_Sels", AV74TFOperacionesEstado_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV107GridCollapsedRecordsChildren", AV107GridCollapsedRecordsChildren);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E225E2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV80GridActions == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV80GridActions == 2 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV80GridActions == 3 )
         {
            /* Execute user subroutine: 'DO PAGOSALDO' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV80GridActions == 4 )
         {
            /* Execute user subroutine: 'DO COBROSALDO' */
            S232 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV80GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV80GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV80GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E145E2( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "ExportReport") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORTREPORT' */
            S252 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV108GridCollapsedRecords", AV108GridCollapsedRecords);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV74TFOperacionesEstado_Sels", AV74TFOperacionesEstado_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV102TFOperacionesTipo_Sels", AV102TFOperacionesTipo_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV107GridCollapsedRecordsChildren", AV107GridCollapsedRecordsChildren);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E155E2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0078",(string)"",(string)"Operaciones",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0078"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E185E2( )
      {
         /* 'DoAgregar' Routine */
         returnInSub = false;
         CallWebObject(formatLink("operacionwp.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void E235E2( )
      {
         /* Expand_Click Routine */
         returnInSub = false;
         AV106GroupOperacionesTipo = A649OperacionesTipo;
         AssignAttri("", false, "AV106GroupOperacionesTipo", AV106GroupOperacionesTipo);
         AV109Index = AV108GridCollapsedRecords.IndexOf(StringUtil.Trim( A649OperacionesTipo));
         if ( AV109Index > 0 )
         {
            AV108GridCollapsedRecords.RemoveItem((int)(AV109Index));
         }
         else
         {
            AV108GridCollapsedRecords.Add(StringUtil.Trim( A649OperacionesTipo), 0);
         }
         AV112AddChildren = (0==AV109Index);
         AssignAttri("", false, "AV112AddChildren", AV112AddChildren);
         /* Execute user subroutine: 'ADDREMOVECHILDREN' */
         S262 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV108GridCollapsedRecords", AV108GridCollapsedRecords);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV107GridCollapsedRecordsChildren", AV107GridCollapsedRecordsChildren);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV14OrderedBy), 4, 0))+":"+(AV15OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S172( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV35ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "OperacionesId",  "Operación",  "Id",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "OperacionesRef",  "Operación",  "Referencia",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "OperacionesNombreRef",  "Operación",  "Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "OperacionesTipo",  "Operación",  "Concepto",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "OperacionesTipoES",  "Operación",  "Tipo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "OperacionesImporte",  "Operación",  "Importe",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "OperacionesFacturaCod",  "Operación",  "Factura",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "OperacionesComprobantePago",  "Operación",  "Comprobante",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "OperacionesFechaAlta",  "Fechas",  "Alta",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "OperacionesFechaDesde",  "Fechas",  "Desde",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "OperacionesFechaHasta",  "Fechas",  "Hasta",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "OperacionesFechaPago",  "Fechas",  "Pago",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "OperacionesEstado",  "",  "Estado",  true,  "") ;
         GXt_char3 = AV34UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "OperacionesWWColumnsSelector", out  GXt_char3) ;
         AV34UserCustomValue = GXt_char3;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV34UserCustomValue)) ) )
         {
            AV36ColumnsSelectorAux.FromXml(AV34UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV36ColumnsSelectorAux, ref  AV35ColumnsSelector) ;
         }
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV82IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWOperaciones_Update", out  GXt_boolean1) ;
         AV82IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV82IsAuthorized_Update", AV82IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV82IsAuthorized_Update, context));
         GXt_boolean1 = AV115IsAuthorized_PagoSaldo;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "OperacionWP", out  GXt_boolean1) ;
         AV115IsAuthorized_PagoSaldo = GXt_boolean1;
         AssignAttri("", false, "AV115IsAuthorized_PagoSaldo", AV115IsAuthorized_PagoSaldo);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_PAGOSALDO", GetSecureSignedToken( "", AV115IsAuthorized_PagoSaldo, context));
         GXt_boolean1 = AV116IsAuthorized_CobroSaldo;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "OperacionWP", out  GXt_boolean1) ;
         AV116IsAuthorized_CobroSaldo = GXt_boolean1;
         AssignAttri("", false, "AV116IsAuthorized_CobroSaldo", AV116IsAuthorized_CobroSaldo);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_COBROSALDO", GetSecureSignedToken( "", AV116IsAuthorized_CobroSaldo, context));
         GXt_boolean1 = AV86TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "SubscriptionsPanel", out  GXt_boolean1) ;
         AV86TempBoolean = GXt_boolean1;
         if ( ! ( AV86TempBoolean && ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "Operaciones",  1) ) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV86TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "OperacionWP", out  GXt_boolean1) ;
         AV86TempBoolean = GXt_boolean1;
         if ( ! ( AV86TempBoolean ) )
         {
            bttBtnagregar_Visible = 0;
            AssignProp("", false, bttBtnagregar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnagregar_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV38ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "OperacionesWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV38ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S182( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV17FilterFullText = "";
         AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
         AV102TFOperacionesTipo_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV117TFOperacionesComprobantePago = "";
         AssignAttri("", false, "AV117TFOperacionesComprobantePago", AV117TFOperacionesComprobantePago);
         AV118TFOperacionesComprobantePago_Sel = "";
         AssignAttri("", false, "AV118TFOperacionesComprobantePago_Sel", AV118TFOperacionesComprobantePago_Sel);
         AV63TFOperacionesFechaAlta = DateTime.MinValue;
         AssignAttri("", false, "AV63TFOperacionesFechaAlta", context.localUtil.Format(AV63TFOperacionesFechaAlta, "99/99/99"));
         AV64TFOperacionesFechaAlta_To = DateTime.MinValue;
         AssignAttri("", false, "AV64TFOperacionesFechaAlta_To", context.localUtil.Format(AV64TFOperacionesFechaAlta_To, "99/99/99"));
         AV91TFOperacionesFechaDesde = DateTime.MinValue;
         AssignAttri("", false, "AV91TFOperacionesFechaDesde", context.localUtil.Format(AV91TFOperacionesFechaDesde, "99/99/99"));
         AV92TFOperacionesFechaDesde_To = DateTime.MinValue;
         AssignAttri("", false, "AV92TFOperacionesFechaDesde_To", context.localUtil.Format(AV92TFOperacionesFechaDesde_To, "99/99/99"));
         AV96TFOperacionesFechaHasta = DateTime.MinValue;
         AssignAttri("", false, "AV96TFOperacionesFechaHasta", context.localUtil.Format(AV96TFOperacionesFechaHasta, "99/99/99"));
         AV97TFOperacionesFechaHasta_To = DateTime.MinValue;
         AssignAttri("", false, "AV97TFOperacionesFechaHasta_To", context.localUtil.Format(AV97TFOperacionesFechaHasta_To, "99/99/99"));
         AV68TFOperacionesFechaPago = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV68TFOperacionesFechaPago", context.localUtil.TToC( AV68TFOperacionesFechaPago, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AV69TFOperacionesFechaPago_To = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV69TFOperacionesFechaPago_To", context.localUtil.TToC( AV69TFOperacionesFechaPago_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AV74TFOperacionesEstado_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV108GridCollapsedRecords = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV107GridCollapsedRecordsChildren = (GxSimpleCollection<long>)(new GxSimpleCollection<long>());
      }

      protected void S202( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "operaciones.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A554OperacionesId,18,0));
         CallWebObject(formatLink("operaciones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S212( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "operaciones.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A554OperacionesId,18,0));
         CallWebObject(formatLink("operaciones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S222( )
      {
         /* 'DO PAGOSALDO' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "operacionwp.aspx"+UrlEncode(StringUtil.RTrim("POL")) + "," + UrlEncode(StringUtil.LTrimStr(AV114WalletId,18,0)) + "," + UrlEncode(StringUtil.RTrim(A657OperacionesNombreRef)) + "," + UrlEncode(StringUtil.LTrimStr(A554OperacionesId,18,0));
         CallWebObject(formatLink("operacionwp.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S232( )
      {
         /* 'DO COBROSALDO' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "operacionwp.aspx"+UrlEncode(StringUtil.RTrim("COL")) + "," + UrlEncode(StringUtil.LTrimStr(AV114WalletId,18,0)) + "," + UrlEncode(StringUtil.RTrim(A657OperacionesNombreRef)) + "," + UrlEncode(StringUtil.LTrimStr(A554OperacionesId,18,0));
         CallWebObject(formatLink("operacionwp.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV37Session.Get(AV120Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV120Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV37Session.Get(AV120Pgmname+"GridState"), null, "", "");
         }
         AV14OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
         AV15OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S192 ();
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
         AV108GridCollapsedRecords.FromJSonString(AV11GridState.gxTpr_Collapsedrecords, null);
         if ( AV108GridCollapsedRecords.Count > 0 )
         {
            AV112AddChildren = true;
            AssignAttri("", false, "AV112AddChildren", AV112AddChildren);
            AV135GXV2 = 1;
            while ( AV135GXV2 <= AV108GridCollapsedRecords.Count )
            {
               AV106GroupOperacionesTipo = AV108GridCollapsedRecords.GetString(AV135GXV2);
               AssignAttri("", false, "AV106GroupOperacionesTipo", AV106GroupOperacionesTipo);
               /* Execute user subroutine: 'ADDREMOVECHILDREN' */
               S262 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               AV135GXV2 = (int)(AV135GXV2+1);
            }
         }
      }

      protected void S192( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV136GXV3 = 1;
         while ( AV136GXV3 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV136GXV3));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV17FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFOPERACIONESTIPO_SEL") == 0 )
            {
               AV101TFOperacionesTipo_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV101TFOperacionesTipo_SelsJson", AV101TFOperacionesTipo_SelsJson);
               AV102TFOperacionesTipo_Sels.FromJSonString(AV101TFOperacionesTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFOPERACIONESCOMPROBANTEPAGO") == 0 )
            {
               AV117TFOperacionesComprobantePago = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV117TFOperacionesComprobantePago", AV117TFOperacionesComprobantePago);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFOPERACIONESCOMPROBANTEPAGO_SEL") == 0 )
            {
               AV118TFOperacionesComprobantePago_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV118TFOperacionesComprobantePago_Sel", AV118TFOperacionesComprobantePago_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFOPERACIONESFECHAALTA") == 0 )
            {
               AV63TFOperacionesFechaAlta = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV63TFOperacionesFechaAlta", context.localUtil.Format(AV63TFOperacionesFechaAlta, "99/99/99"));
               AV64TFOperacionesFechaAlta_To = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV64TFOperacionesFechaAlta_To", context.localUtil.Format(AV64TFOperacionesFechaAlta_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFOPERACIONESFECHADESDE") == 0 )
            {
               AV91TFOperacionesFechaDesde = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV91TFOperacionesFechaDesde", context.localUtil.Format(AV91TFOperacionesFechaDesde, "99/99/99"));
               AV92TFOperacionesFechaDesde_To = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV92TFOperacionesFechaDesde_To", context.localUtil.Format(AV92TFOperacionesFechaDesde_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFOPERACIONESFECHAHASTA") == 0 )
            {
               AV96TFOperacionesFechaHasta = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV96TFOperacionesFechaHasta", context.localUtil.Format(AV96TFOperacionesFechaHasta, "99/99/99"));
               AV97TFOperacionesFechaHasta_To = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV97TFOperacionesFechaHasta_To", context.localUtil.Format(AV97TFOperacionesFechaHasta_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFOPERACIONESFECHAPAGO") == 0 )
            {
               AV68TFOperacionesFechaPago = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV68TFOperacionesFechaPago", context.localUtil.TToC( AV68TFOperacionesFechaPago, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV69TFOperacionesFechaPago_To = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV69TFOperacionesFechaPago_To", context.localUtil.TToC( AV69TFOperacionesFechaPago_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV70DDO_OperacionesFechaPagoAuxDate = DateTimeUtil.ResetTime(AV68TFOperacionesFechaPago);
               AssignAttri("", false, "AV70DDO_OperacionesFechaPagoAuxDate", context.localUtil.Format(AV70DDO_OperacionesFechaPagoAuxDate, "99/99/99"));
               AV71DDO_OperacionesFechaPagoAuxDateTo = DateTimeUtil.ResetTime(AV69TFOperacionesFechaPago_To);
               AssignAttri("", false, "AV71DDO_OperacionesFechaPagoAuxDateTo", context.localUtil.Format(AV71DDO_OperacionesFechaPagoAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFOPERACIONESESTADO_SEL") == 0 )
            {
               AV73TFOperacionesEstado_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV73TFOperacionesEstado_SelsJson", AV73TFOperacionesEstado_SelsJson);
               AV74TFOperacionesEstado_Sels.FromJSonString(AV73TFOperacionesEstado_SelsJson, null);
            }
            AV136GXV3 = (int)(AV136GXV3+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV102TFOperacionesTipo_Sels.Count==0),  AV101TFOperacionesTipo_SelsJson, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV118TFOperacionesComprobantePago_Sel)),  AV118TFOperacionesComprobantePago_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV74TFOperacionesEstado_Sels.Count==0),  AV73TFOperacionesEstado_SelsJson, out  GXt_char6) ;
         Ddo_grid_Selectedvalue_set = "|||"+GXt_char3+"||||"+GXt_char5+"|||||"+GXt_char6;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV117TFOperacionesComprobantePago)),  AV117TFOperacionesComprobantePago, out  GXt_char6) ;
         Ddo_grid_Filteredtext_set = "|||||||"+GXt_char6+"|"+((DateTime.MinValue==AV63TFOperacionesFechaAlta) ? "" : context.localUtil.DToC( AV63TFOperacionesFechaAlta, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+((DateTime.MinValue==AV91TFOperacionesFechaDesde) ? "" : context.localUtil.DToC( AV91TFOperacionesFechaDesde, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+((DateTime.MinValue==AV96TFOperacionesFechaHasta) ? "" : context.localUtil.DToC( AV96TFOperacionesFechaHasta, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+((DateTime.MinValue==AV68TFOperacionesFechaPago) ? "" : context.localUtil.DToC( AV70DDO_OperacionesFechaPagoAuxDate, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||||||||"+((DateTime.MinValue==AV64TFOperacionesFechaAlta_To) ? "" : context.localUtil.DToC( AV64TFOperacionesFechaAlta_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+((DateTime.MinValue==AV92TFOperacionesFechaDesde_To) ? "" : context.localUtil.DToC( AV92TFOperacionesFechaDesde_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+((DateTime.MinValue==AV97TFOperacionesFechaHasta_To) ? "" : context.localUtil.DToC( AV97TFOperacionesFechaHasta_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+((DateTime.MinValue==AV69TFOperacionesFechaPago_To) ? "" : context.localUtil.DToC( AV71DDO_OperacionesFechaPagoAuxDateTo, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV37Session.Get(AV120Pgmname+"GridState"), null, "", "");
         AV110OldGridState.FromXml(AV11GridState.ToXml(false, true, "", ""), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)),  0,  AV17FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFOPERACIONESTIPO_SEL",  context.GetMessage( "Concepto", ""),  !(AV102TFOperacionesTipo_Sels.Count==0),  0,  AV102TFOperacionesTipo_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFOPERACIONESCOMPROBANTEPAGO",  context.GetMessage( "Comprobante", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV117TFOperacionesComprobantePago)),  0,  AV117TFOperacionesComprobantePago,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV118TFOperacionesComprobantePago_Sel)),  AV118TFOperacionesComprobantePago_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFOPERACIONESFECHAALTA",  context.GetMessage( "Alta", ""),  !((DateTime.MinValue==AV63TFOperacionesFechaAlta)&&(DateTime.MinValue==AV64TFOperacionesFechaAlta_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV63TFOperacionesFechaAlta, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  StringUtil.Trim( context.localUtil.DToC( AV64TFOperacionesFechaAlta_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFOPERACIONESFECHADESDE",  context.GetMessage( "Desde", ""),  !((DateTime.MinValue==AV91TFOperacionesFechaDesde)&&(DateTime.MinValue==AV92TFOperacionesFechaDesde_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV91TFOperacionesFechaDesde, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  StringUtil.Trim( context.localUtil.DToC( AV92TFOperacionesFechaDesde_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFOPERACIONESFECHAHASTA",  context.GetMessage( "Hasta", ""),  !((DateTime.MinValue==AV96TFOperacionesFechaHasta)&&(DateTime.MinValue==AV97TFOperacionesFechaHasta_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV96TFOperacionesFechaHasta, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  StringUtil.Trim( context.localUtil.DToC( AV97TFOperacionesFechaHasta_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFOPERACIONESFECHAPAGO",  context.GetMessage( "Pago", ""),  !((DateTime.MinValue==AV68TFOperacionesFechaPago)&&(DateTime.MinValue==AV69TFOperacionesFechaPago_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV68TFOperacionesFechaPago, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")),  StringUtil.Trim( context.localUtil.TToC( AV69TFOperacionesFechaPago_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFOPERACIONESESTADO_SEL",  context.GetMessage( "Estado", ""),  !(AV74TFOperacionesEstado_Sels.Count==0),  0,  AV74TFOperacionesEstado_Sels.ToJSonString(false),  "") ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         if ( new GeneXus.Programs.wwpbaseobjects.wwp_resetcollapsedrecords(context).executeUdp(  AV110OldGridState,  AV11GridState) )
         {
            AV108GridCollapsedRecords = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV107GridCollapsedRecordsChildren = (GxSimpleCollection<long>)(new GxSimpleCollection<long>());
         }
         AV11GridState.gxTpr_Collapsedrecords = AV108GridCollapsedRecords.ToJSonString(false);
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV120Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV120Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Operaciones";
         AV37Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S242( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new operacioneswwexport(context ).execute( out  AV31ExcelFilename, out  AV32ErrorMessage) ;
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

      protected void S252( )
      {
         /* 'DOEXPORTREPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Innewwindow1_Target = formatLink("operacioneswwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void S262( )
      {
         /* 'ADDREMOVECHILDREN' Routine */
         returnInSub = false;
         AV111DiscardFirst = true;
         AV121Operacioneswwds_1_filterfulltext = AV17FilterFullText;
         AV122Operacioneswwds_2_tfoperacionestipo_sels = AV102TFOperacionesTipo_Sels;
         AV123Operacioneswwds_3_tfoperacionescomprobantepago = AV117TFOperacionesComprobantePago;
         AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel = AV118TFOperacionesComprobantePago_Sel;
         AV125Operacioneswwds_5_tfoperacionesfechaalta = AV63TFOperacionesFechaAlta;
         AV126Operacioneswwds_6_tfoperacionesfechaalta_to = AV64TFOperacionesFechaAlta_To;
         AV127Operacioneswwds_7_tfoperacionesfechadesde = AV91TFOperacionesFechaDesde;
         AV128Operacioneswwds_8_tfoperacionesfechadesde_to = AV92TFOperacionesFechaDesde_To;
         AV129Operacioneswwds_9_tfoperacionesfechahasta = AV96TFOperacionesFechaHasta;
         AV130Operacioneswwds_10_tfoperacionesfechahasta_to = AV97TFOperacionesFechaHasta_To;
         AV131Operacioneswwds_11_tfoperacionesfechapago = AV68TFOperacionesFechaPago;
         AV132Operacioneswwds_12_tfoperacionesfechapago_to = AV69TFOperacionesFechaPago_To;
         AV133Operacioneswwds_13_tfoperacionesestado_sels = AV74TFOperacionesEstado_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A649OperacionesTipo ,
                                              AV122Operacioneswwds_2_tfoperacionestipo_sels ,
                                              A577OperacionesEstado ,
                                              AV133Operacioneswwds_13_tfoperacionesestado_sels ,
                                              AV122Operacioneswwds_2_tfoperacionestipo_sels.Count ,
                                              AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel ,
                                              AV123Operacioneswwds_3_tfoperacionescomprobantepago ,
                                              AV127Operacioneswwds_7_tfoperacionesfechadesde ,
                                              AV128Operacioneswwds_8_tfoperacionesfechadesde_to ,
                                              AV129Operacioneswwds_9_tfoperacionesfechahasta ,
                                              AV130Operacioneswwds_10_tfoperacionesfechahasta_to ,
                                              AV133Operacioneswwds_13_tfoperacionesestado_sels.Count ,
                                              AV106GroupOperacionesTipo ,
                                              A580OperacionesComprobantePago ,
                                              A658OperacionesFechaDesde ,
                                              A659OperacionesFechaHasta ,
                                              AV121Operacioneswwds_1_filterfulltext ,
                                              A554OperacionesId ,
                                              A555OperacionesRef ,
                                              A657OperacionesNombreRef ,
                                              A569OperacionesTipoES ,
                                              A570OperacionesImporte ,
                                              A572OperacionesFacturaCod } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV123Operacioneswwds_3_tfoperacionescomprobantepago = StringUtil.PadR( StringUtil.RTrim( AV123Operacioneswwds_3_tfoperacionescomprobantepago), 256, "%");
         /* Using cursor H005E4 */
         pr_default.execute(2, new Object[] {lV123Operacioneswwds_3_tfoperacionescomprobantepago, AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel, AV127Operacioneswwds_7_tfoperacionesfechadesde, AV128Operacioneswwds_8_tfoperacionesfechadesde_to, AV129Operacioneswwds_9_tfoperacionesfechahasta, AV130Operacioneswwds_10_tfoperacionesfechahasta_to, AV106GroupOperacionesTipo});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A572OperacionesFacturaCod = H005E4_A572OperacionesFacturaCod[0];
            n572OperacionesFacturaCod = H005E4_n572OperacionesFacturaCod[0];
            A570OperacionesImporte = H005E4_A570OperacionesImporte[0];
            n570OperacionesImporte = H005E4_n570OperacionesImporte[0];
            A657OperacionesNombreRef = H005E4_A657OperacionesNombreRef[0];
            n657OperacionesNombreRef = H005E4_n657OperacionesNombreRef[0];
            A555OperacionesRef = H005E4_A555OperacionesRef[0];
            n555OperacionesRef = H005E4_n555OperacionesRef[0];
            A554OperacionesId = H005E4_A554OperacionesId[0];
            A659OperacionesFechaHasta = H005E4_A659OperacionesFechaHasta[0];
            n659OperacionesFechaHasta = H005E4_n659OperacionesFechaHasta[0];
            A658OperacionesFechaDesde = H005E4_A658OperacionesFechaDesde[0];
            n658OperacionesFechaDesde = H005E4_n658OperacionesFechaDesde[0];
            A580OperacionesComprobantePago = H005E4_A580OperacionesComprobantePago[0];
            n580OperacionesComprobantePago = H005E4_n580OperacionesComprobantePago[0];
            A577OperacionesEstado = H005E4_A577OperacionesEstado[0];
            n577OperacionesEstado = H005E4_n577OperacionesEstado[0];
            A569OperacionesTipoES = H005E4_A569OperacionesTipoES[0];
            n569OperacionesTipoES = H005E4_n569OperacionesTipoES[0];
            A649OperacionesTipo = H005E4_A649OperacionesTipo[0];
            n649OperacionesTipo = H005E4_n649OperacionesTipo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV121Operacioneswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A554OperacionesId), 18, 0) , StringUtil.PadR( "%" + AV121Operacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A555OperacionesRef) , StringUtil.PadR( "%" + StringUtil.Upper( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A657OperacionesNombreRef) , StringUtil.PadR( "%" + StringUtil.Upper( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "liquidación de solicitudes del profesional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "LSF") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "liquidación de  solicitudes comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "LSC") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "cobro de saldo pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "COL") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pago de saldo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A649OperacionesTipo, "POL") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro de solicitud", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "CSO") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "nota de credito", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "NCR") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "nota de debito", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A649OperacionesTipo, "NDE") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "OTR") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "solicitudes ingresadas desde fenicio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "FEN") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "respuesta de api fenicio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "FGO") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "comercio_externo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "CEX") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "entrada", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A569OperacionesTipoES, "E") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "salida", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A569OperacionesTipoES, "S") == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Str( A570OperacionesImporte, 18, 2) , StringUtil.PadR( "%" + AV121Operacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A572OperacionesFacturaCod) , StringUtil.PadR( "%" + StringUtil.Upper( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A580OperacionesComprobantePago) , StringUtil.PadR( "%" + StringUtil.Upper( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "procesado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A577OperacionesEstado, "PRO") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A577OperacionesEstado, "PND") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "anulado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV121Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A577OperacionesEstado, "ANU") == 0 ) ) )
            )
            {
               AV109Index = AV107GridCollapsedRecordsChildren.IndexOf(A554OperacionesId);
               if ( AV112AddChildren && ( AV109Index == 0 ) )
               {
                  if ( ! AV111DiscardFirst )
                  {
                     AV107GridCollapsedRecordsChildren.Add(A554OperacionesId, 0);
                  }
                  else
                  {
                     AV111DiscardFirst = false;
                  }
               }
               else
               {
                  if ( ( ! AV112AddChildren ) && ( AV109Index > 0 ) )
                  {
                     AV107GridCollapsedRecordsChildren.RemoveItem((int)(AV109Index));
                  }
               }
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void wb_table1_27_5E2( bool wbgen )
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
            wb_table2_32_5E2( true) ;
         }
         else
         {
            wb_table2_32_5E2( false) ;
         }
         return  ;
      }

      protected void wb_table2_32_5E2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_27_5E2e( true) ;
         }
         else
         {
            wb_table1_27_5E2e( false) ;
         }
      }

      protected void wb_table2_32_5E2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_45_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV17FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV17FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_OperacionesWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_32_5E2e( true) ;
         }
         else
         {
            wb_table2_32_5E2e( false) ;
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
         PA5E2( ) ;
         WS5E2( ) ;
         WE5E2( ) ;
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
         AddStyleSheetFile("calendar-system.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202692821434637", true, true, false);
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
         context.AddJavascriptSource("operacionesww.js", "?202692821434638", false, true, false);
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridTitlesCategories/GridTitlesCategoriesRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVGroupBy/DVGroupByRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_452( )
      {
         edtavExpand_Internalname = "vEXPAND_"+sGXsfl_45_idx;
         edtavGrid_groupcaption_Internalname = "vGRID_GROUPCAPTION_"+sGXsfl_45_idx;
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_45_idx;
         edtOperacionesId_Internalname = "OPERACIONESID_"+sGXsfl_45_idx;
         edtOperacionesRef_Internalname = "OPERACIONESREF_"+sGXsfl_45_idx;
         edtOperacionesNombreRef_Internalname = "OPERACIONESNOMBREREF_"+sGXsfl_45_idx;
         cmbOperacionesTipo_Internalname = "OPERACIONESTIPO_"+sGXsfl_45_idx;
         cmbOperacionesTipoES_Internalname = "OPERACIONESTIPOES_"+sGXsfl_45_idx;
         edtOperacionesImporte_Internalname = "OPERACIONESIMPORTE_"+sGXsfl_45_idx;
         edtOperacionesFacturaCod_Internalname = "OPERACIONESFACTURACOD_"+sGXsfl_45_idx;
         edtOperacionesComprobantePago_Internalname = "OPERACIONESCOMPROBANTEPAGO_"+sGXsfl_45_idx;
         edtOperacionesFechaAlta_Internalname = "OPERACIONESFECHAALTA_"+sGXsfl_45_idx;
         edtOperacionesFechaDesde_Internalname = "OPERACIONESFECHADESDE_"+sGXsfl_45_idx;
         edtOperacionesFechaHasta_Internalname = "OPERACIONESFECHAHASTA_"+sGXsfl_45_idx;
         edtOperacionesFechaPago_Internalname = "OPERACIONESFECHAPAGO_"+sGXsfl_45_idx;
         cmbOperacionesEstado_Internalname = "OPERACIONESESTADO_"+sGXsfl_45_idx;
      }

      protected void SubsflControlProps_fel_452( )
      {
         edtavExpand_Internalname = "vEXPAND_"+sGXsfl_45_fel_idx;
         edtavGrid_groupcaption_Internalname = "vGRID_GROUPCAPTION_"+sGXsfl_45_fel_idx;
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_45_fel_idx;
         edtOperacionesId_Internalname = "OPERACIONESID_"+sGXsfl_45_fel_idx;
         edtOperacionesRef_Internalname = "OPERACIONESREF_"+sGXsfl_45_fel_idx;
         edtOperacionesNombreRef_Internalname = "OPERACIONESNOMBREREF_"+sGXsfl_45_fel_idx;
         cmbOperacionesTipo_Internalname = "OPERACIONESTIPO_"+sGXsfl_45_fel_idx;
         cmbOperacionesTipoES_Internalname = "OPERACIONESTIPOES_"+sGXsfl_45_fel_idx;
         edtOperacionesImporte_Internalname = "OPERACIONESIMPORTE_"+sGXsfl_45_fel_idx;
         edtOperacionesFacturaCod_Internalname = "OPERACIONESFACTURACOD_"+sGXsfl_45_fel_idx;
         edtOperacionesComprobantePago_Internalname = "OPERACIONESCOMPROBANTEPAGO_"+sGXsfl_45_fel_idx;
         edtOperacionesFechaAlta_Internalname = "OPERACIONESFECHAALTA_"+sGXsfl_45_fel_idx;
         edtOperacionesFechaDesde_Internalname = "OPERACIONESFECHADESDE_"+sGXsfl_45_fel_idx;
         edtOperacionesFechaHasta_Internalname = "OPERACIONESFECHAHASTA_"+sGXsfl_45_fel_idx;
         edtOperacionesFechaPago_Internalname = "OPERACIONESFECHAPAGO_"+sGXsfl_45_fel_idx;
         cmbOperacionesEstado_Internalname = "OPERACIONESESTADO_"+sGXsfl_45_fel_idx;
      }

      protected void sendrow_452( )
      {
         sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
         SubsflControlProps_452( ) ;
         WB5E0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_45_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_45_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_45_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavExpand_Internalname,StringUtil.RTrim( AV113Expand),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ","'"+""+"'"+",false,"+"'"+"EVEXPAND.CLICK."+sGXsfl_45_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavExpand_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavExpand_Columnclass,(string)edtavExpand_Columnheaderclass,(short)0,(int)edtavExpand_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)45,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavGrid_groupcaption_Internalname,(string)AV105Grid_GroupCaption,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavGrid_groupcaption_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavGrid_groupcaption_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)45,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'" + sGXsfl_45_idx + "',45)\"";
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_45_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV80GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV80GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV80GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV80GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_45_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)cmbavGridactions_Columnclass,(string)cmbavGridactions_Columnheaderclass,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"",(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV80GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_45_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtOperacionesId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A554OperacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A554OperacionesId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtOperacionesId_Columnclass,(string)edtOperacionesId_Columnheaderclass,(int)edtOperacionesId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)45,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtOperacionesRef_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesRef_Internalname,StringUtil.RTrim( A555OperacionesRef),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesRef_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtOperacionesRef_Columnclass,(string)edtOperacionesRef_Columnheaderclass,(int)edtOperacionesRef_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)25,(short)0,(short)0,(short)45,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtOperacionesNombreRef_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesNombreRef_Internalname,StringUtil.RTrim( A657OperacionesNombreRef),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesNombreRef_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtOperacionesNombreRef_Columnclass,(string)edtOperacionesNombreRef_Columnheaderclass,(int)edtOperacionesNombreRef_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)45,(short)0,(short)-1,(short)-1,(bool)true,(string)"NombreLargo",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbOperacionesTipo.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbOperacionesTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "OPERACIONESTIPO_" + sGXsfl_45_idx;
               cmbOperacionesTipo.Name = GXCCtl;
               cmbOperacionesTipo.WebTags = "";
               cmbOperacionesTipo.addItem("LSF", context.GetMessage( "Liquidación de Solicitudes del Profesional", ""), 0);
               cmbOperacionesTipo.addItem("LSC", context.GetMessage( "Liquidación de  Solicitudes Comercio", ""), 0);
               cmbOperacionesTipo.addItem("COL", context.GetMessage( "Cobro de Saldo Pendiente", ""), 0);
               cmbOperacionesTipo.addItem("POL", context.GetMessage( "Pago de Saldo", ""), 0);
               cmbOperacionesTipo.addItem("CSO", context.GetMessage( "Cobro de Solicitud", ""), 0);
               cmbOperacionesTipo.addItem("NCR", context.GetMessage( "Nota de Credito", ""), 0);
               cmbOperacionesTipo.addItem("NDE", context.GetMessage( "Nota de Debito", ""), 0);
               cmbOperacionesTipo.addItem("OTR", context.GetMessage( "Otros", ""), 0);
               cmbOperacionesTipo.addItem("FEN", context.GetMessage( "Solicitudes ingresadas desde Fenicio", ""), 0);
               cmbOperacionesTipo.addItem("FGO", context.GetMessage( "Respuesta de api fenicio", ""), 0);
               cmbOperacionesTipo.addItem("CEX", context.GetMessage( "COMERCIO_EXTERNO", ""), 0);
               if ( cmbOperacionesTipo.ItemCount > 0 )
               {
                  A649OperacionesTipo = cmbOperacionesTipo.getValidValue(A649OperacionesTipo);
                  n649OperacionesTipo = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbOperacionesTipo,(string)cmbOperacionesTipo_Internalname,StringUtil.RTrim( A649OperacionesTipo),(short)1,(string)cmbOperacionesTipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbOperacionesTipo.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbOperacionesTipo_Columnclass,(string)cmbOperacionesTipo_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbOperacionesTipo.CurrentValue = StringUtil.RTrim( A649OperacionesTipo);
            AssignProp("", false, cmbOperacionesTipo_Internalname, "Values", (string)(cmbOperacionesTipo.ToJavascriptSource()), !bGXsfl_45_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbOperacionesTipoES.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbOperacionesTipoES.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "OPERACIONESTIPOES_" + sGXsfl_45_idx;
               cmbOperacionesTipoES.Name = GXCCtl;
               cmbOperacionesTipoES.WebTags = "";
               cmbOperacionesTipoES.addItem("E", context.GetMessage( "Entrada", ""), 0);
               cmbOperacionesTipoES.addItem("S", context.GetMessage( "Salida", ""), 0);
               if ( cmbOperacionesTipoES.ItemCount > 0 )
               {
                  A569OperacionesTipoES = cmbOperacionesTipoES.getValidValue(A569OperacionesTipoES);
                  n569OperacionesTipoES = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbOperacionesTipoES,(string)cmbOperacionesTipoES_Internalname,StringUtil.RTrim( A569OperacionesTipoES),(short)1,(string)cmbOperacionesTipoES_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbOperacionesTipoES.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbOperacionesTipoES_Columnclass,(string)cmbOperacionesTipoES_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbOperacionesTipoES.CurrentValue = StringUtil.RTrim( A569OperacionesTipoES);
            AssignProp("", false, cmbOperacionesTipoES_Internalname, "Values", (string)(cmbOperacionesTipoES.ToJavascriptSource()), !bGXsfl_45_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtOperacionesImporte_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesImporte_Internalname,StringUtil.LTrim( StringUtil.NToC( A570OperacionesImporte, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A570OperacionesImporte, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesImporte_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtOperacionesImporte_Columnclass,(string)edtOperacionesImporte_Columnheaderclass,(int)edtOperacionesImporte_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)45,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtOperacionesFacturaCod_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesFacturaCod_Internalname,StringUtil.RTrim( A572OperacionesFacturaCod),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesFacturaCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtOperacionesFacturaCod_Columnclass,(string)edtOperacionesFacturaCod_Columnheaderclass,(int)edtOperacionesFacturaCod_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)25,(short)0,(short)0,(short)45,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtOperacionesComprobantePago_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesComprobantePago_Internalname,StringUtil.RTrim( A580OperacionesComprobantePago),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesComprobantePago_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtOperacionesComprobantePago_Columnclass,(string)edtOperacionesComprobantePago_Columnheaderclass,(int)edtOperacionesComprobantePago_Visible,(short)0,(short)0,(string)"text",(string)"",(short)50,(string)"px",(short)17,(string)"px",(short)256,(short)0,(short)0,(short)45,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtOperacionesFechaAlta_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesFechaAlta_Internalname,context.localUtil.Format(A581OperacionesFechaAlta, "99/99/99"),context.localUtil.Format( A581OperacionesFechaAlta, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesFechaAlta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtOperacionesFechaAlta_Columnclass,(string)edtOperacionesFechaAlta_Columnheaderclass,(int)edtOperacionesFechaAlta_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)45,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtOperacionesFechaDesde_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesFechaDesde_Internalname,context.localUtil.Format(A658OperacionesFechaDesde, "99/99/99"),context.localUtil.Format( A658OperacionesFechaDesde, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesFechaDesde_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtOperacionesFechaDesde_Columnclass,(string)edtOperacionesFechaDesde_Columnheaderclass,(int)edtOperacionesFechaDesde_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)45,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtOperacionesFechaHasta_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesFechaHasta_Internalname,context.localUtil.Format(A659OperacionesFechaHasta, "99/99/99"),context.localUtil.Format( A659OperacionesFechaHasta, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesFechaHasta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtOperacionesFechaHasta_Columnclass,(string)edtOperacionesFechaHasta_Columnheaderclass,(int)edtOperacionesFechaHasta_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)45,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtOperacionesFechaPago_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOperacionesFechaPago_Internalname,context.localUtil.TToC( A582OperacionesFechaPago, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A582OperacionesFechaPago, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOperacionesFechaPago_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtOperacionesFechaPago_Columnclass,(string)edtOperacionesFechaPago_Columnheaderclass,(int)edtOperacionesFechaPago_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)45,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbOperacionesEstado.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbOperacionesEstado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "OPERACIONESESTADO_" + sGXsfl_45_idx;
               cmbOperacionesEstado.Name = GXCCtl;
               cmbOperacionesEstado.WebTags = "";
               cmbOperacionesEstado.addItem("PRO", context.GetMessage( "Procesado", ""), 0);
               cmbOperacionesEstado.addItem("PND", context.GetMessage( "Pendiente", ""), 0);
               cmbOperacionesEstado.addItem("ANU", context.GetMessage( "Anulado", ""), 0);
               if ( cmbOperacionesEstado.ItemCount > 0 )
               {
                  A577OperacionesEstado = cmbOperacionesEstado.getValidValue(A577OperacionesEstado);
                  n577OperacionesEstado = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbOperacionesEstado,(string)cmbOperacionesEstado_Internalname,StringUtil.RTrim( A577OperacionesEstado),(short)1,(string)cmbOperacionesEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbOperacionesEstado.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbOperacionesEstado_Columnclass,(string)cmbOperacionesEstado_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbOperacionesEstado.CurrentValue = StringUtil.RTrim( A577OperacionesEstado);
            AssignProp("", false, cmbOperacionesEstado_Internalname, "Values", (string)(cmbOperacionesEstado.ToJavascriptSource()), !bGXsfl_45_Refreshing);
            send_integrity_lvl_hashes5E2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_45_idx = ((subGrid_Islastpage==1)&&(nGXsfl_45_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_45_idx+1);
            sGXsfl_45_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_45_idx), 4, 0), 4, "0");
            SubsflControlProps_452( ) ;
         }
         /* End function sendrow_452 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_45_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV80GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV80GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV80GridActions), 4, 0));
         }
         GXCCtl = "OPERACIONESTIPO_" + sGXsfl_45_idx;
         cmbOperacionesTipo.Name = GXCCtl;
         cmbOperacionesTipo.WebTags = "";
         cmbOperacionesTipo.addItem("LSF", context.GetMessage( "Liquidación de Solicitudes del Profesional", ""), 0);
         cmbOperacionesTipo.addItem("LSC", context.GetMessage( "Liquidación de  Solicitudes Comercio", ""), 0);
         cmbOperacionesTipo.addItem("COL", context.GetMessage( "Cobro de Saldo Pendiente", ""), 0);
         cmbOperacionesTipo.addItem("POL", context.GetMessage( "Pago de Saldo", ""), 0);
         cmbOperacionesTipo.addItem("CSO", context.GetMessage( "Cobro de Solicitud", ""), 0);
         cmbOperacionesTipo.addItem("NCR", context.GetMessage( "Nota de Credito", ""), 0);
         cmbOperacionesTipo.addItem("NDE", context.GetMessage( "Nota de Debito", ""), 0);
         cmbOperacionesTipo.addItem("OTR", context.GetMessage( "Otros", ""), 0);
         cmbOperacionesTipo.addItem("FEN", context.GetMessage( "Solicitudes ingresadas desde Fenicio", ""), 0);
         cmbOperacionesTipo.addItem("FGO", context.GetMessage( "Respuesta de api fenicio", ""), 0);
         cmbOperacionesTipo.addItem("CEX", context.GetMessage( "COMERCIO_EXTERNO", ""), 0);
         if ( cmbOperacionesTipo.ItemCount > 0 )
         {
            A649OperacionesTipo = cmbOperacionesTipo.getValidValue(A649OperacionesTipo);
            n649OperacionesTipo = false;
         }
         GXCCtl = "OPERACIONESTIPOES_" + sGXsfl_45_idx;
         cmbOperacionesTipoES.Name = GXCCtl;
         cmbOperacionesTipoES.WebTags = "";
         cmbOperacionesTipoES.addItem("E", context.GetMessage( "Entrada", ""), 0);
         cmbOperacionesTipoES.addItem("S", context.GetMessage( "Salida", ""), 0);
         if ( cmbOperacionesTipoES.ItemCount > 0 )
         {
            A569OperacionesTipoES = cmbOperacionesTipoES.getValidValue(A569OperacionesTipoES);
            n569OperacionesTipoES = false;
         }
         GXCCtl = "OPERACIONESESTADO_" + sGXsfl_45_idx;
         cmbOperacionesEstado.Name = GXCCtl;
         cmbOperacionesEstado.WebTags = "";
         cmbOperacionesEstado.addItem("PRO", context.GetMessage( "Procesado", ""), 0);
         cmbOperacionesEstado.addItem("PND", context.GetMessage( "Pendiente", ""), 0);
         cmbOperacionesEstado.addItem("ANU", context.GetMessage( "Anulado", ""), 0);
         if ( cmbOperacionesEstado.ItemCount > 0 )
         {
            A577OperacionesEstado = cmbOperacionesEstado.getValidValue(A577OperacionesEstado);
            n577OperacionesEstado = false;
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl45( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"45\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtOperacionesId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtOperacionesRef_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Referencia", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtOperacionesNombreRef_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbOperacionesTipo.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Concepto", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbOperacionesTipoES.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Tipo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtOperacionesImporte_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Importe", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtOperacionesFacturaCod_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Factura", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(50), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+((edtOperacionesComprobantePago_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Comprobante", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtOperacionesFechaAlta_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Alta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtOperacionesFechaDesde_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Desde", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtOperacionesFechaHasta_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Hasta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtOperacionesFechaPago_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Pago", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbOperacionesEstado.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV113Expand)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavExpand_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavExpand_Columnheaderclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavExpand_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV105Grid_GroupCaption));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavGrid_groupcaption_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV80GridActions), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbavGridactions_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbavGridactions_Columnheaderclass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A554OperacionesId), 18, 0, ".", ""))));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtOperacionesId_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtOperacionesId_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A555OperacionesRef)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtOperacionesRef_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtOperacionesRef_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesRef_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A657OperacionesNombreRef)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtOperacionesNombreRef_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtOperacionesNombreRef_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesNombreRef_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A649OperacionesTipo)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbOperacionesTipo_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbOperacionesTipo_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbOperacionesTipo.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A569OperacionesTipoES)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbOperacionesTipoES_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbOperacionesTipoES_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbOperacionesTipoES.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A570OperacionesImporte, 21, 2, ".", ""))));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtOperacionesImporte_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtOperacionesImporte_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesImporte_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A572OperacionesFacturaCod)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtOperacionesFacturaCod_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtOperacionesFacturaCod_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesFacturaCod_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A580OperacionesComprobantePago)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtOperacionesComprobantePago_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtOperacionesComprobantePago_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesComprobantePago_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A581OperacionesFechaAlta, "99/99/99")));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtOperacionesFechaAlta_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtOperacionesFechaAlta_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesFechaAlta_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A658OperacionesFechaDesde, "99/99/99")));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtOperacionesFechaDesde_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtOperacionesFechaDesde_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesFechaDesde_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A659OperacionesFechaHasta, "99/99/99")));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtOperacionesFechaHasta_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtOperacionesFechaHasta_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesFechaHasta_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A582OperacionesFechaPago, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtOperacionesFechaPago_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtOperacionesFechaPago_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOperacionesFechaPago_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A577OperacionesEstado)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbOperacionesEstado_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbOperacionesEstado_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbOperacionesEstado.Visible), 5, 0, ".", "")));
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
         bttBtnliquidaciones_Internalname = "BTNLIQUIDACIONES";
         bttBtnagexport_Internalname = "BTNAGEXPORT";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         bttBtnsubscriptions_Internalname = "BTNSUBSCRIPTIONS";
         bttBtnagregar_Internalname = "BTNAGREGAR";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         tblTablefilters_Internalname = "TABLEFILTERS";
         tblTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtavExpand_Internalname = "vEXPAND";
         edtavGrid_groupcaption_Internalname = "vGRID_GROUPCAPTION";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtOperacionesId_Internalname = "OPERACIONESID";
         edtOperacionesRef_Internalname = "OPERACIONESREF";
         edtOperacionesNombreRef_Internalname = "OPERACIONESNOMBREREF";
         cmbOperacionesTipo_Internalname = "OPERACIONESTIPO";
         cmbOperacionesTipoES_Internalname = "OPERACIONESTIPOES";
         edtOperacionesImporte_Internalname = "OPERACIONESIMPORTE";
         edtOperacionesFacturaCod_Internalname = "OPERACIONESFACTURACOD";
         edtOperacionesComprobantePago_Internalname = "OPERACIONESCOMPROBANTEPAGO";
         edtOperacionesFechaAlta_Internalname = "OPERACIONESFECHAALTA";
         edtOperacionesFechaDesde_Internalname = "OPERACIONESFECHADESDE";
         edtOperacionesFechaHasta_Internalname = "OPERACIONESFECHAHASTA";
         edtOperacionesFechaPago_Internalname = "OPERACIONESFECHAPAGO";
         cmbOperacionesEstado_Internalname = "OPERACIONESESTADO";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_liquidaciones_Internalname = "DDO_LIQUIDACIONES";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Grid_titlescategories_Internalname = "GRID_TITLESCATEGORIES";
         Grid_group_Internalname = "GRID_GROUP";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
         edtavDdo_operacionesfechaaltaauxdate_Internalname = "vDDO_OPERACIONESFECHAALTAAUXDATE";
         edtavDdo_operacionesfechaaltaauxdateto_Internalname = "vDDO_OPERACIONESFECHAALTAAUXDATETO";
         divDdo_operacionesfechaaltaauxdates_Internalname = "DDO_OPERACIONESFECHAALTAAUXDATES";
         edtavDdo_operacionesfechadesdeauxdate_Internalname = "vDDO_OPERACIONESFECHADESDEAUXDATE";
         edtavDdo_operacionesfechadesdeauxdateto_Internalname = "vDDO_OPERACIONESFECHADESDEAUXDATETO";
         divDdo_operacionesfechadesdeauxdates_Internalname = "DDO_OPERACIONESFECHADESDEAUXDATES";
         edtavDdo_operacionesfechahastaauxdate_Internalname = "vDDO_OPERACIONESFECHAHASTAAUXDATE";
         edtavDdo_operacionesfechahastaauxdateto_Internalname = "vDDO_OPERACIONESFECHAHASTAAUXDATETO";
         divDdo_operacionesfechahastaauxdates_Internalname = "DDO_OPERACIONESFECHAHASTAAUXDATES";
         edtavDdo_operacionesfechapagoauxdate_Internalname = "vDDO_OPERACIONESFECHAPAGOAUXDATE";
         edtavDdo_operacionesfechapagoauxdateto_Internalname = "vDDO_OPERACIONESFECHAPAGOAUXDATETO";
         divDdo_operacionesfechapagoauxdates_Internalname = "DDO_OPERACIONESFECHAPAGOAUXDATES";
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
         cmbOperacionesEstado_Jsonclick = "";
         cmbOperacionesEstado_Columnclass = "WWColumn";
         edtOperacionesFechaPago_Jsonclick = "";
         edtOperacionesFechaPago_Columnclass = "WWColumn";
         edtOperacionesFechaHasta_Jsonclick = "";
         edtOperacionesFechaHasta_Columnclass = "WWColumn hidden-xs";
         edtOperacionesFechaDesde_Jsonclick = "";
         edtOperacionesFechaDesde_Columnclass = "WWColumn hidden-xs";
         edtOperacionesFechaAlta_Jsonclick = "";
         edtOperacionesFechaAlta_Columnclass = "WWColumn";
         edtOperacionesComprobantePago_Jsonclick = "";
         edtOperacionesComprobantePago_Columnclass = "WWColumn";
         edtOperacionesFacturaCod_Jsonclick = "";
         edtOperacionesFacturaCod_Columnclass = "WWColumn";
         edtOperacionesImporte_Jsonclick = "";
         edtOperacionesImporte_Columnclass = "WWColumn";
         cmbOperacionesTipoES_Jsonclick = "";
         cmbOperacionesTipoES_Columnclass = "WWColumn";
         cmbOperacionesTipo_Jsonclick = "";
         cmbOperacionesTipo_Columnclass = "WWColumn";
         edtOperacionesNombreRef_Jsonclick = "";
         edtOperacionesNombreRef_Columnclass = "WWColumn hidden-xs";
         edtOperacionesRef_Jsonclick = "";
         edtOperacionesRef_Columnclass = "WWColumn";
         edtOperacionesId_Jsonclick = "";
         edtOperacionesId_Columnclass = "WWColumn";
         cmbavGridactions_Jsonclick = "";
         cmbavGridactions_Columnclass = "WWActionGroupColumn";
         edtavGrid_groupcaption_Jsonclick = "";
         edtavGrid_groupcaption_Enabled = 1;
         edtavExpand_Jsonclick = "";
         edtavExpand_Columnclass = "WWIconActionColumn";
         edtavExpand_Enabled = 1;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         cmbOperacionesEstado_Columnheaderclass = "";
         edtOperacionesFechaPago_Columnheaderclass = "";
         edtOperacionesFechaHasta_Columnheaderclass = "";
         edtOperacionesFechaDesde_Columnheaderclass = "";
         edtOperacionesFechaAlta_Columnheaderclass = "";
         edtOperacionesComprobantePago_Columnheaderclass = "";
         edtOperacionesFacturaCod_Columnheaderclass = "";
         edtOperacionesImporte_Columnheaderclass = "";
         cmbOperacionesTipoES_Columnheaderclass = "";
         cmbOperacionesTipo_Columnheaderclass = "";
         edtOperacionesNombreRef_Columnheaderclass = "";
         edtOperacionesRef_Columnheaderclass = "";
         edtOperacionesId_Columnheaderclass = "";
         cmbavGridactions_Columnheaderclass = "";
         edtavExpand_Columnheaderclass = "";
         cmbOperacionesEstado.Visible = -1;
         edtOperacionesFechaPago_Visible = -1;
         edtOperacionesFechaHasta_Visible = -1;
         edtOperacionesFechaDesde_Visible = -1;
         edtOperacionesFechaAlta_Visible = -1;
         edtOperacionesComprobantePago_Visible = -1;
         edtOperacionesFacturaCod_Visible = -1;
         edtOperacionesImporte_Visible = -1;
         cmbOperacionesTipoES.Visible = -1;
         cmbOperacionesTipo.Visible = -1;
         edtOperacionesNombreRef_Visible = -1;
         edtOperacionesRef_Visible = -1;
         edtOperacionesId_Visible = -1;
         cmbOperacionesEstado.Enabled = 0;
         edtOperacionesFechaPago_Enabled = 0;
         edtOperacionesFechaHasta_Enabled = 0;
         edtOperacionesFechaDesde_Enabled = 0;
         edtOperacionesFechaAlta_Enabled = 0;
         edtOperacionesComprobantePago_Enabled = 0;
         edtOperacionesFacturaCod_Enabled = 0;
         edtOperacionesImporte_Enabled = 0;
         cmbOperacionesTipoES.Enabled = 0;
         cmbOperacionesTipo.Enabled = 0;
         edtOperacionesNombreRef_Enabled = 0;
         edtOperacionesRef_Enabled = 0;
         edtOperacionesId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_operacionesfechapagoauxdateto_Jsonclick = "";
         edtavDdo_operacionesfechapagoauxdate_Jsonclick = "";
         edtavDdo_operacionesfechahastaauxdateto_Jsonclick = "";
         edtavDdo_operacionesfechahastaauxdate_Jsonclick = "";
         edtavDdo_operacionesfechadesdeauxdateto_Jsonclick = "";
         edtavDdo_operacionesfechadesdeauxdate_Jsonclick = "";
         edtavDdo_operacionesfechaaltaauxdateto_Jsonclick = "";
         edtavDdo_operacionesfechaaltaauxdate_Jsonclick = "";
         bttBtnagregar_Visible = 1;
         bttBtnsubscriptions_Visible = 1;
         Grid_empowerer_Fixedcolumns = ";;L;;;;;;;;;;;;;";
         Grid_empowerer_Hasrowgroups = Convert.ToBoolean( -1);
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Grid_empowerer_Hascategories = Convert.ToBoolean( -1);
         Grid_group_Columnindex = 1;
         Grid_titlescategories_Gridtitlescategories = "";
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
         Ddo_grid_Datalistproc = "OperacionesWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||LSF:Liquidación de Solicitudes del Profesional,LSC:Liquidación de  Solicitudes Comercio,COL:Cobro de Saldo Pendiente,POL:Pago de Saldo,CSO:Cobro de Solicitud,NCR:Nota de Credito,NDE:Nota de Debito,OTR:Otros,FEN:Solicitudes ingresadas desde Fenicio,FGO:Respuesta de api fenicio,CEX:COMERCIO_EXTERNO|||||||||PRO:Procesado,PND:Pendiente,ANU:Anulado";
         Ddo_grid_Allowmultipleselection = "|||T|||||||||T";
         Ddo_grid_Datalisttype = "|||FixedValues||||Dynamic|||||FixedValues";
         Ddo_grid_Includedatalist = "|||T||||T|||||T";
         Ddo_grid_Filterisrange = "||||||||T|T|T|T|";
         Ddo_grid_Filtertype = "|||||||Character|Date|Date|Date|Date|";
         Ddo_grid_Includefilter = "|||||||T|T|T|T|T|";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|6|7|8|9|10|11|12|13";
         Ddo_grid_Columnids = "3:OperacionesId|4:OperacionesRef|5:OperacionesNombreRef|6:OperacionesTipo|7:OperacionesTipoES|8:OperacionesImporte|9:OperacionesFacturaCod|10:OperacionesComprobantePago|11:OperacionesFechaAlta|12:OperacionesFechaDesde|13:OperacionesFechaHasta|14:OperacionesFechaPago|15:OperacionesEstado";
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
         Ddo_liquidaciones_Titlecontrolidtoreplace = "";
         Ddo_liquidaciones_Visible = Convert.ToBoolean( -1);
         Ddo_liquidaciones_Cls = "ColumnsSelector";
         Ddo_liquidaciones_Icon = "fas fa-briefcase";
         Ddo_liquidaciones_Icontype = "FontIcon";
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
         Form.Caption = context.GetMessage( " Operaciones", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV107GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV120Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV102TFOperacionesTipo_Sels',fld:'vTFOPERACIONESTIPO_SELS',pic:''},{av:'AV117TFOperacionesComprobantePago',fld:'vTFOPERACIONESCOMPROBANTEPAGO',pic:'',type:'char'},{av:'AV118TFOperacionesComprobantePago_Sel',fld:'vTFOPERACIONESCOMPROBANTEPAGO_SEL',pic:'',type:'char'},{av:'AV63TFOperacionesFechaAlta',fld:'vTFOPERACIONESFECHAALTA',pic:'',type:'date'},{av:'AV64TFOperacionesFechaAlta_To',fld:'vTFOPERACIONESFECHAALTA_TO',pic:'',type:'date'},{av:'AV91TFOperacionesFechaDesde',fld:'vTFOPERACIONESFECHADESDE',pic:'',type:'date'},{av:'AV92TFOperacionesFechaDesde_To',fld:'vTFOPERACIONESFECHADESDE_TO',pic:'',type:'date'},{av:'AV96TFOperacionesFechaHasta',fld:'vTFOPERACIONESFECHAHASTA',pic:'',type:'date'},{av:'AV97TFOperacionesFechaHasta_To',fld:'vTFOPERACIONESFECHAHASTA_TO',pic:'',type:'date'},{av:'AV68TFOperacionesFechaPago',fld:'vTFOPERACIONESFECHAPAGO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV69TFOperacionesFechaPago_To',fld:'vTFOPERACIONESFECHAPAGO_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV74TFOperacionesEstado_Sels',fld:'vTFOPERACIONESESTADO_SELS',pic:''},{av:'AV108GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV82IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV115IsAuthorized_PagoSaldo',fld:'vISAUTHORIZED_PAGOSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV116IsAuthorized_CobroSaldo',fld:'vISAUTHORIZED_COBROSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV114WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtOperacionesId_Visible',ctrl:'OPERACIONESID',prop:'Visible'},{av:'edtOperacionesRef_Visible',ctrl:'OPERACIONESREF',prop:'Visible'},{av:'edtOperacionesNombreRef_Visible',ctrl:'OPERACIONESNOMBREREF',prop:'Visible'},{av:'cmbOperacionesTipo'},{av:'cmbOperacionesTipoES'},{av:'edtOperacionesImporte_Visible',ctrl:'OPERACIONESIMPORTE',prop:'Visible'},{av:'edtOperacionesFacturaCod_Visible',ctrl:'OPERACIONESFACTURACOD',prop:'Visible'},{av:'edtOperacionesComprobantePago_Visible',ctrl:'OPERACIONESCOMPROBANTEPAGO',prop:'Visible'},{av:'edtOperacionesFechaAlta_Visible',ctrl:'OPERACIONESFECHAALTA',prop:'Visible'},{av:'edtOperacionesFechaDesde_Visible',ctrl:'OPERACIONESFECHADESDE',prop:'Visible'},{av:'edtOperacionesFechaHasta_Visible',ctrl:'OPERACIONESFECHAHASTA',prop:'Visible'},{av:'edtOperacionesFechaPago_Visible',ctrl:'OPERACIONESFECHAPAGO',prop:'Visible'},{av:'cmbOperacionesEstado'},{av:'AV77GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV78GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV79GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'edtavExpand_Columnheaderclass',ctrl:'vEXPAND',prop:'Columnheaderclass'},{av:'cmbavGridactions'},{av:'edtOperacionesId_Columnheaderclass',ctrl:'OPERACIONESID',prop:'Columnheaderclass'},{av:'edtOperacionesRef_Columnheaderclass',ctrl:'OPERACIONESREF',prop:'Columnheaderclass'},{av:'edtOperacionesNombreRef_Columnheaderclass',ctrl:'OPERACIONESNOMBREREF',prop:'Columnheaderclass'},{av:'edtOperacionesImporte_Columnheaderclass',ctrl:'OPERACIONESIMPORTE',prop:'Columnheaderclass'},{av:'edtOperacionesFacturaCod_Columnheaderclass',ctrl:'OPERACIONESFACTURACOD',prop:'Columnheaderclass'},{av:'edtOperacionesComprobantePago_Columnheaderclass',ctrl:'OPERACIONESCOMPROBANTEPAGO',prop:'Columnheaderclass'},{av:'edtOperacionesFechaAlta_Columnheaderclass',ctrl:'OPERACIONESFECHAALTA',prop:'Columnheaderclass'},{av:'edtOperacionesFechaDesde_Columnheaderclass',ctrl:'OPERACIONESFECHADESDE',prop:'Columnheaderclass'},{av:'edtOperacionesFechaHasta_Columnheaderclass',ctrl:'OPERACIONESFECHAHASTA',prop:'Columnheaderclass'},{av:'edtOperacionesFechaPago_Columnheaderclass',ctrl:'OPERACIONESFECHAPAGO',prop:'Columnheaderclass'},{av:'AV105Grid_GroupCaption',fld:'vGRID_GROUPCAPTION',pic:'',type:'svchar'},{av:'AV82IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV115IsAuthorized_PagoSaldo',fld:'vISAUTHORIZED_PAGOSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV116IsAuthorized_CobroSaldo',fld:'vISAUTHORIZED_COBROSALDO',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{ctrl:'BTNAGREGAR',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV108GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV107GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E125E2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV120Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV102TFOperacionesTipo_Sels',fld:'vTFOPERACIONESTIPO_SELS',pic:''},{av:'AV117TFOperacionesComprobantePago',fld:'vTFOPERACIONESCOMPROBANTEPAGO',pic:'',type:'char'},{av:'AV118TFOperacionesComprobantePago_Sel',fld:'vTFOPERACIONESCOMPROBANTEPAGO_SEL',pic:'',type:'char'},{av:'AV63TFOperacionesFechaAlta',fld:'vTFOPERACIONESFECHAALTA',pic:'',type:'date'},{av:'AV64TFOperacionesFechaAlta_To',fld:'vTFOPERACIONESFECHAALTA_TO',pic:'',type:'date'},{av:'AV91TFOperacionesFechaDesde',fld:'vTFOPERACIONESFECHADESDE',pic:'',type:'date'},{av:'AV92TFOperacionesFechaDesde_To',fld:'vTFOPERACIONESFECHADESDE_TO',pic:'',type:'date'},{av:'AV96TFOperacionesFechaHasta',fld:'vTFOPERACIONESFECHAHASTA',pic:'',type:'date'},{av:'AV97TFOperacionesFechaHasta_To',fld:'vTFOPERACIONESFECHAHASTA_TO',pic:'',type:'date'},{av:'AV68TFOperacionesFechaPago',fld:'vTFOPERACIONESFECHAPAGO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV69TFOperacionesFechaPago_To',fld:'vTFOPERACIONESFECHAPAGO_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV74TFOperacionesEstado_Sels',fld:'vTFOPERACIONESESTADO_SELS',pic:''},{av:'AV108GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV82IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV115IsAuthorized_PagoSaldo',fld:'vISAUTHORIZED_PAGOSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV116IsAuthorized_CobroSaldo',fld:'vISAUTHORIZED_COBROSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV107GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''},{av:'AV114WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtOperacionesId_Visible',ctrl:'OPERACIONESID',prop:'Visible'},{av:'edtOperacionesRef_Visible',ctrl:'OPERACIONESREF',prop:'Visible'},{av:'edtOperacionesNombreRef_Visible',ctrl:'OPERACIONESNOMBREREF',prop:'Visible'},{av:'cmbOperacionesTipo'},{av:'cmbOperacionesTipoES'},{av:'edtOperacionesImporte_Visible',ctrl:'OPERACIONESIMPORTE',prop:'Visible'},{av:'edtOperacionesFacturaCod_Visible',ctrl:'OPERACIONESFACTURACOD',prop:'Visible'},{av:'edtOperacionesComprobantePago_Visible',ctrl:'OPERACIONESCOMPROBANTEPAGO',prop:'Visible'},{av:'edtOperacionesFechaAlta_Visible',ctrl:'OPERACIONESFECHAALTA',prop:'Visible'},{av:'edtOperacionesFechaDesde_Visible',ctrl:'OPERACIONESFECHADESDE',prop:'Visible'},{av:'edtOperacionesFechaHasta_Visible',ctrl:'OPERACIONESFECHAHASTA',prop:'Visible'},{av:'edtOperacionesFechaPago_Visible',ctrl:'OPERACIONESFECHAPAGO',prop:'Visible'},{av:'cmbOperacionesEstado'},{av:'AV77GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV78GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV79GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'edtavExpand_Columnheaderclass',ctrl:'vEXPAND',prop:'Columnheaderclass'},{av:'cmbavGridactions'},{av:'edtOperacionesId_Columnheaderclass',ctrl:'OPERACIONESID',prop:'Columnheaderclass'},{av:'edtOperacionesRef_Columnheaderclass',ctrl:'OPERACIONESREF',prop:'Columnheaderclass'},{av:'edtOperacionesNombreRef_Columnheaderclass',ctrl:'OPERACIONESNOMBREREF',prop:'Columnheaderclass'},{av:'edtOperacionesImporte_Columnheaderclass',ctrl:'OPERACIONESIMPORTE',prop:'Columnheaderclass'},{av:'edtOperacionesFacturaCod_Columnheaderclass',ctrl:'OPERACIONESFACTURACOD',prop:'Columnheaderclass'},{av:'edtOperacionesComprobantePago_Columnheaderclass',ctrl:'OPERACIONESCOMPROBANTEPAGO',prop:'Columnheaderclass'},{av:'edtOperacionesFechaAlta_Columnheaderclass',ctrl:'OPERACIONESFECHAALTA',prop:'Columnheaderclass'},{av:'edtOperacionesFechaDesde_Columnheaderclass',ctrl:'OPERACIONESFECHADESDE',prop:'Columnheaderclass'},{av:'edtOperacionesFechaHasta_Columnheaderclass',ctrl:'OPERACIONESFECHAHASTA',prop:'Columnheaderclass'},{av:'edtOperacionesFechaPago_Columnheaderclass',ctrl:'OPERACIONESFECHAPAGO',prop:'Columnheaderclass'},{av:'AV105Grid_GroupCaption',fld:'vGRID_GROUPCAPTION',pic:'',type:'svchar'},{av:'AV82IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV115IsAuthorized_PagoSaldo',fld:'vISAUTHORIZED_PAGOSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV116IsAuthorized_CobroSaldo',fld:'vISAUTHORIZED_COBROSALDO',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{ctrl:'BTNAGREGAR',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV108GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV107GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E135E2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV120Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV102TFOperacionesTipo_Sels',fld:'vTFOPERACIONESTIPO_SELS',pic:''},{av:'AV117TFOperacionesComprobantePago',fld:'vTFOPERACIONESCOMPROBANTEPAGO',pic:'',type:'char'},{av:'AV118TFOperacionesComprobantePago_Sel',fld:'vTFOPERACIONESCOMPROBANTEPAGO_SEL',pic:'',type:'char'},{av:'AV63TFOperacionesFechaAlta',fld:'vTFOPERACIONESFECHAALTA',pic:'',type:'date'},{av:'AV64TFOperacionesFechaAlta_To',fld:'vTFOPERACIONESFECHAALTA_TO',pic:'',type:'date'},{av:'AV91TFOperacionesFechaDesde',fld:'vTFOPERACIONESFECHADESDE',pic:'',type:'date'},{av:'AV92TFOperacionesFechaDesde_To',fld:'vTFOPERACIONESFECHADESDE_TO',pic:'',type:'date'},{av:'AV96TFOperacionesFechaHasta',fld:'vTFOPERACIONESFECHAHASTA',pic:'',type:'date'},{av:'AV97TFOperacionesFechaHasta_To',fld:'vTFOPERACIONESFECHAHASTA_TO',pic:'',type:'date'},{av:'AV68TFOperacionesFechaPago',fld:'vTFOPERACIONESFECHAPAGO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV69TFOperacionesFechaPago_To',fld:'vTFOPERACIONESFECHAPAGO_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV74TFOperacionesEstado_Sels',fld:'vTFOPERACIONESESTADO_SELS',pic:''},{av:'AV108GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV82IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV115IsAuthorized_PagoSaldo',fld:'vISAUTHORIZED_PAGOSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV116IsAuthorized_CobroSaldo',fld:'vISAUTHORIZED_COBROSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV107GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''},{av:'AV114WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E165E2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV120Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV102TFOperacionesTipo_Sels',fld:'vTFOPERACIONESTIPO_SELS',pic:''},{av:'AV117TFOperacionesComprobantePago',fld:'vTFOPERACIONESCOMPROBANTEPAGO',pic:'',type:'char'},{av:'AV118TFOperacionesComprobantePago_Sel',fld:'vTFOPERACIONESCOMPROBANTEPAGO_SEL',pic:'',type:'char'},{av:'AV63TFOperacionesFechaAlta',fld:'vTFOPERACIONESFECHAALTA',pic:'',type:'date'},{av:'AV64TFOperacionesFechaAlta_To',fld:'vTFOPERACIONESFECHAALTA_TO',pic:'',type:'date'},{av:'AV91TFOperacionesFechaDesde',fld:'vTFOPERACIONESFECHADESDE',pic:'',type:'date'},{av:'AV92TFOperacionesFechaDesde_To',fld:'vTFOPERACIONESFECHADESDE_TO',pic:'',type:'date'},{av:'AV96TFOperacionesFechaHasta',fld:'vTFOPERACIONESFECHAHASTA',pic:'',type:'date'},{av:'AV97TFOperacionesFechaHasta_To',fld:'vTFOPERACIONESFECHAHASTA_TO',pic:'',type:'date'},{av:'AV68TFOperacionesFechaPago',fld:'vTFOPERACIONESFECHAPAGO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV69TFOperacionesFechaPago_To',fld:'vTFOPERACIONESFECHAPAGO_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV74TFOperacionesEstado_Sels',fld:'vTFOPERACIONESESTADO_SELS',pic:''},{av:'AV108GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV82IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV115IsAuthorized_PagoSaldo',fld:'vISAUTHORIZED_PAGOSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV116IsAuthorized_CobroSaldo',fld:'vISAUTHORIZED_COBROSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV107GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''},{av:'AV114WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV73TFOperacionesEstado_SelsJson',fld:'vTFOPERACIONESESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV74TFOperacionesEstado_Sels',fld:'vTFOPERACIONESESTADO_SELS',pic:''},{av:'AV68TFOperacionesFechaPago',fld:'vTFOPERACIONESFECHAPAGO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV69TFOperacionesFechaPago_To',fld:'vTFOPERACIONESFECHAPAGO_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV96TFOperacionesFechaHasta',fld:'vTFOPERACIONESFECHAHASTA',pic:'',type:'date'},{av:'AV97TFOperacionesFechaHasta_To',fld:'vTFOPERACIONESFECHAHASTA_TO',pic:'',type:'date'},{av:'AV91TFOperacionesFechaDesde',fld:'vTFOPERACIONESFECHADESDE',pic:'',type:'date'},{av:'AV92TFOperacionesFechaDesde_To',fld:'vTFOPERACIONESFECHADESDE_TO',pic:'',type:'date'},{av:'AV63TFOperacionesFechaAlta',fld:'vTFOPERACIONESFECHAALTA',pic:'',type:'date'},{av:'AV64TFOperacionesFechaAlta_To',fld:'vTFOPERACIONESFECHAALTA_TO',pic:'',type:'date'},{av:'AV117TFOperacionesComprobantePago',fld:'vTFOPERACIONESCOMPROBANTEPAGO',pic:'',type:'char'},{av:'AV118TFOperacionesComprobantePago_Sel',fld:'vTFOPERACIONESCOMPROBANTEPAGO_SEL',pic:'',type:'char'},{av:'AV101TFOperacionesTipo_SelsJson',fld:'vTFOPERACIONESTIPO_SELSJSON',pic:'',type:'vchar'},{av:'AV102TFOperacionesTipo_Sels',fld:'vTFOPERACIONESTIPO_SELS',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E215E2',iparms:[{av:'cmbOperacionesTipo'},{av:'A649OperacionesTipo',fld:'OPERACIONESTIPO',pic:'',hsh:true,type:'char'},{av:'AV108GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV82IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV115IsAuthorized_PagoSaldo',fld:'vISAUTHORIZED_PAGOSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV116IsAuthorized_CobroSaldo',fld:'vISAUTHORIZED_COBROSALDO',pic:'',hsh:true,type:'boolean'},{av:'cmbOperacionesEstado'},{av:'A577OperacionesEstado',fld:'OPERACIONESESTADO',pic:'',type:'char'},{av:'AV107GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''},{av:'A555OperacionesRef',fld:'OPERACIONESREF',pic:'',type:'char'},{av:'A570OperacionesImporte',fld:'OPERACIONESIMPORTE',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV105Grid_GroupCaption',fld:'vGRID_GROUPCAPTION',pic:'',type:'svchar'},{av:'AV113Expand',fld:'vEXPAND',pic:'',type:'char'},{av:'edtavExpand_Columnclass',ctrl:'vEXPAND',prop:'Columnclass'},{av:'cmbavGridactions'},{av:'AV80GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'edtOperacionesId_Columnclass',ctrl:'OPERACIONESID',prop:'Columnclass'},{av:'edtOperacionesRef_Columnclass',ctrl:'OPERACIONESREF',prop:'Columnclass'},{av:'edtOperacionesNombreRef_Columnclass',ctrl:'OPERACIONESNOMBREREF',prop:'Columnclass'},{av:'cmbOperacionesTipo'},{av:'cmbOperacionesTipoES'},{av:'edtOperacionesImporte_Columnclass',ctrl:'OPERACIONESIMPORTE',prop:'Columnclass'},{av:'edtOperacionesFacturaCod_Columnclass',ctrl:'OPERACIONESFACTURACOD',prop:'Columnclass'},{av:'edtOperacionesComprobantePago_Columnclass',ctrl:'OPERACIONESCOMPROBANTEPAGO',prop:'Columnclass'},{av:'edtOperacionesFechaAlta_Columnclass',ctrl:'OPERACIONESFECHAALTA',prop:'Columnclass'},{av:'edtOperacionesFechaDesde_Columnclass',ctrl:'OPERACIONESFECHADESDE',prop:'Columnclass'},{av:'edtOperacionesFechaHasta_Columnclass',ctrl:'OPERACIONESFECHAHASTA',prop:'Columnclass'},{av:'edtOperacionesFechaPago_Columnclass',ctrl:'OPERACIONESFECHAPAGO',prop:'Columnclass'},{av:'cmbOperacionesEstado'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E175E2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV120Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV102TFOperacionesTipo_Sels',fld:'vTFOPERACIONESTIPO_SELS',pic:''},{av:'AV117TFOperacionesComprobantePago',fld:'vTFOPERACIONESCOMPROBANTEPAGO',pic:'',type:'char'},{av:'AV118TFOperacionesComprobantePago_Sel',fld:'vTFOPERACIONESCOMPROBANTEPAGO_SEL',pic:'',type:'char'},{av:'AV63TFOperacionesFechaAlta',fld:'vTFOPERACIONESFECHAALTA',pic:'',type:'date'},{av:'AV64TFOperacionesFechaAlta_To',fld:'vTFOPERACIONESFECHAALTA_TO',pic:'',type:'date'},{av:'AV91TFOperacionesFechaDesde',fld:'vTFOPERACIONESFECHADESDE',pic:'',type:'date'},{av:'AV92TFOperacionesFechaDesde_To',fld:'vTFOPERACIONESFECHADESDE_TO',pic:'',type:'date'},{av:'AV96TFOperacionesFechaHasta',fld:'vTFOPERACIONESFECHAHASTA',pic:'',type:'date'},{av:'AV97TFOperacionesFechaHasta_To',fld:'vTFOPERACIONESFECHAHASTA_TO',pic:'',type:'date'},{av:'AV68TFOperacionesFechaPago',fld:'vTFOPERACIONESFECHAPAGO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV69TFOperacionesFechaPago_To',fld:'vTFOPERACIONESFECHAPAGO_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV74TFOperacionesEstado_Sels',fld:'vTFOPERACIONESESTADO_SELS',pic:''},{av:'AV108GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV82IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV115IsAuthorized_PagoSaldo',fld:'vISAUTHORIZED_PAGOSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV116IsAuthorized_CobroSaldo',fld:'vISAUTHORIZED_COBROSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV107GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''},{av:'AV114WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'edtOperacionesId_Visible',ctrl:'OPERACIONESID',prop:'Visible'},{av:'edtOperacionesRef_Visible',ctrl:'OPERACIONESREF',prop:'Visible'},{av:'edtOperacionesNombreRef_Visible',ctrl:'OPERACIONESNOMBREREF',prop:'Visible'},{av:'cmbOperacionesTipo'},{av:'cmbOperacionesTipoES'},{av:'edtOperacionesImporte_Visible',ctrl:'OPERACIONESIMPORTE',prop:'Visible'},{av:'edtOperacionesFacturaCod_Visible',ctrl:'OPERACIONESFACTURACOD',prop:'Visible'},{av:'edtOperacionesComprobantePago_Visible',ctrl:'OPERACIONESCOMPROBANTEPAGO',prop:'Visible'},{av:'edtOperacionesFechaAlta_Visible',ctrl:'OPERACIONESFECHAALTA',prop:'Visible'},{av:'edtOperacionesFechaDesde_Visible',ctrl:'OPERACIONESFECHADESDE',prop:'Visible'},{av:'edtOperacionesFechaHasta_Visible',ctrl:'OPERACIONESFECHAHASTA',prop:'Visible'},{av:'edtOperacionesFechaPago_Visible',ctrl:'OPERACIONESFECHAPAGO',prop:'Visible'},{av:'cmbOperacionesEstado'},{av:'AV77GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV78GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV79GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'edtavExpand_Columnheaderclass',ctrl:'vEXPAND',prop:'Columnheaderclass'},{av:'cmbavGridactions'},{av:'edtOperacionesId_Columnheaderclass',ctrl:'OPERACIONESID',prop:'Columnheaderclass'},{av:'edtOperacionesRef_Columnheaderclass',ctrl:'OPERACIONESREF',prop:'Columnheaderclass'},{av:'edtOperacionesNombreRef_Columnheaderclass',ctrl:'OPERACIONESNOMBREREF',prop:'Columnheaderclass'},{av:'edtOperacionesImporte_Columnheaderclass',ctrl:'OPERACIONESIMPORTE',prop:'Columnheaderclass'},{av:'edtOperacionesFacturaCod_Columnheaderclass',ctrl:'OPERACIONESFACTURACOD',prop:'Columnheaderclass'},{av:'edtOperacionesComprobantePago_Columnheaderclass',ctrl:'OPERACIONESCOMPROBANTEPAGO',prop:'Columnheaderclass'},{av:'edtOperacionesFechaAlta_Columnheaderclass',ctrl:'OPERACIONESFECHAALTA',prop:'Columnheaderclass'},{av:'edtOperacionesFechaDesde_Columnheaderclass',ctrl:'OPERACIONESFECHADESDE',prop:'Columnheaderclass'},{av:'edtOperacionesFechaHasta_Columnheaderclass',ctrl:'OPERACIONESFECHAHASTA',prop:'Columnheaderclass'},{av:'edtOperacionesFechaPago_Columnheaderclass',ctrl:'OPERACIONESFECHAPAGO',prop:'Columnheaderclass'},{av:'AV105Grid_GroupCaption',fld:'vGRID_GROUPCAPTION',pic:'',type:'svchar'},{av:'AV82IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV115IsAuthorized_PagoSaldo',fld:'vISAUTHORIZED_PAGOSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV116IsAuthorized_CobroSaldo',fld:'vISAUTHORIZED_COBROSALDO',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{ctrl:'BTNAGREGAR',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV108GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV107GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E115E2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV120Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV102TFOperacionesTipo_Sels',fld:'vTFOPERACIONESTIPO_SELS',pic:''},{av:'AV117TFOperacionesComprobantePago',fld:'vTFOPERACIONESCOMPROBANTEPAGO',pic:'',type:'char'},{av:'AV118TFOperacionesComprobantePago_Sel',fld:'vTFOPERACIONESCOMPROBANTEPAGO_SEL',pic:'',type:'char'},{av:'AV63TFOperacionesFechaAlta',fld:'vTFOPERACIONESFECHAALTA',pic:'',type:'date'},{av:'AV64TFOperacionesFechaAlta_To',fld:'vTFOPERACIONESFECHAALTA_TO',pic:'',type:'date'},{av:'AV91TFOperacionesFechaDesde',fld:'vTFOPERACIONESFECHADESDE',pic:'',type:'date'},{av:'AV92TFOperacionesFechaDesde_To',fld:'vTFOPERACIONESFECHADESDE_TO',pic:'',type:'date'},{av:'AV96TFOperacionesFechaHasta',fld:'vTFOPERACIONESFECHAHASTA',pic:'',type:'date'},{av:'AV97TFOperacionesFechaHasta_To',fld:'vTFOPERACIONESFECHAHASTA_TO',pic:'',type:'date'},{av:'AV68TFOperacionesFechaPago',fld:'vTFOPERACIONESFECHAPAGO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV69TFOperacionesFechaPago_To',fld:'vTFOPERACIONESFECHAPAGO_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV74TFOperacionesEstado_Sels',fld:'vTFOPERACIONESESTADO_SELS',pic:''},{av:'AV108GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV82IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV115IsAuthorized_PagoSaldo',fld:'vISAUTHORIZED_PAGOSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV116IsAuthorized_CobroSaldo',fld:'vISAUTHORIZED_COBROSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV107GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''},{av:'AV114WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV101TFOperacionesTipo_SelsJson',fld:'vTFOPERACIONESTIPO_SELSJSON',pic:'',type:'vchar'},{av:'AV73TFOperacionesEstado_SelsJson',fld:'vTFOPERACIONESESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV70DDO_OperacionesFechaPagoAuxDate',fld:'vDDO_OPERACIONESFECHAPAGOAUXDATE',pic:'',type:'date'},{av:'AV71DDO_OperacionesFechaPagoAuxDateTo',fld:'vDDO_OPERACIONESFECHAPAGOAUXDATETO',pic:'',type:'date'},{av:'AV106GroupOperacionesTipo',fld:'vGROUPOPERACIONESTIPO',pic:'',type:'char'},{av:'cmbOperacionesTipo'},{av:'A649OperacionesTipo',fld:'OPERACIONESTIPO',pic:'',hsh:true,type:'char'},{av:'A554OperacionesId',fld:'OPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV112AddChildren',fld:'vADDCHILDREN',pic:'',type:'boolean'}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV108GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV112AddChildren',fld:'vADDCHILDREN',pic:'',type:'boolean'},{av:'AV106GroupOperacionesTipo',fld:'vGROUPOPERACIONESTIPO',pic:'',type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV102TFOperacionesTipo_Sels',fld:'vTFOPERACIONESTIPO_SELS',pic:''},{av:'AV117TFOperacionesComprobantePago',fld:'vTFOPERACIONESCOMPROBANTEPAGO',pic:'',type:'char'},{av:'AV118TFOperacionesComprobantePago_Sel',fld:'vTFOPERACIONESCOMPROBANTEPAGO_SEL',pic:'',type:'char'},{av:'AV63TFOperacionesFechaAlta',fld:'vTFOPERACIONESFECHAALTA',pic:'',type:'date'},{av:'AV64TFOperacionesFechaAlta_To',fld:'vTFOPERACIONESFECHAALTA_TO',pic:'',type:'date'},{av:'AV91TFOperacionesFechaDesde',fld:'vTFOPERACIONESFECHADESDE',pic:'',type:'date'},{av:'AV92TFOperacionesFechaDesde_To',fld:'vTFOPERACIONESFECHADESDE_TO',pic:'',type:'date'},{av:'AV96TFOperacionesFechaHasta',fld:'vTFOPERACIONESFECHAHASTA',pic:'',type:'date'},{av:'AV97TFOperacionesFechaHasta_To',fld:'vTFOPERACIONESFECHAHASTA_TO',pic:'',type:'date'},{av:'AV68TFOperacionesFechaPago',fld:'vTFOPERACIONESFECHAPAGO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV69TFOperacionesFechaPago_To',fld:'vTFOPERACIONESFECHAPAGO_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV74TFOperacionesEstado_Sels',fld:'vTFOPERACIONESESTADO_SELS',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'AV107GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV73TFOperacionesEstado_SelsJson',fld:'vTFOPERACIONESESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV70DDO_OperacionesFechaPagoAuxDate',fld:'vDDO_OPERACIONESFECHAPAGOAUXDATE',pic:'',type:'date'},{av:'AV71DDO_OperacionesFechaPagoAuxDateTo',fld:'vDDO_OPERACIONESFECHAPAGOAUXDATETO',pic:'',type:'date'},{av:'AV101TFOperacionesTipo_SelsJson',fld:'vTFOPERACIONESTIPO_SELSJSON',pic:'',type:'vchar'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtOperacionesId_Visible',ctrl:'OPERACIONESID',prop:'Visible'},{av:'edtOperacionesRef_Visible',ctrl:'OPERACIONESREF',prop:'Visible'},{av:'edtOperacionesNombreRef_Visible',ctrl:'OPERACIONESNOMBREREF',prop:'Visible'},{av:'cmbOperacionesTipo'},{av:'cmbOperacionesTipoES'},{av:'edtOperacionesImporte_Visible',ctrl:'OPERACIONESIMPORTE',prop:'Visible'},{av:'edtOperacionesFacturaCod_Visible',ctrl:'OPERACIONESFACTURACOD',prop:'Visible'},{av:'edtOperacionesComprobantePago_Visible',ctrl:'OPERACIONESCOMPROBANTEPAGO',prop:'Visible'},{av:'edtOperacionesFechaAlta_Visible',ctrl:'OPERACIONESFECHAALTA',prop:'Visible'},{av:'edtOperacionesFechaDesde_Visible',ctrl:'OPERACIONESFECHADESDE',prop:'Visible'},{av:'edtOperacionesFechaHasta_Visible',ctrl:'OPERACIONESFECHAHASTA',prop:'Visible'},{av:'edtOperacionesFechaPago_Visible',ctrl:'OPERACIONESFECHAPAGO',prop:'Visible'},{av:'cmbOperacionesEstado'},{av:'AV77GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV78GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV79GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'edtavExpand_Columnheaderclass',ctrl:'vEXPAND',prop:'Columnheaderclass'},{av:'cmbavGridactions'},{av:'edtOperacionesId_Columnheaderclass',ctrl:'OPERACIONESID',prop:'Columnheaderclass'},{av:'edtOperacionesRef_Columnheaderclass',ctrl:'OPERACIONESREF',prop:'Columnheaderclass'},{av:'edtOperacionesNombreRef_Columnheaderclass',ctrl:'OPERACIONESNOMBREREF',prop:'Columnheaderclass'},{av:'edtOperacionesImporte_Columnheaderclass',ctrl:'OPERACIONESIMPORTE',prop:'Columnheaderclass'},{av:'edtOperacionesFacturaCod_Columnheaderclass',ctrl:'OPERACIONESFACTURACOD',prop:'Columnheaderclass'},{av:'edtOperacionesComprobantePago_Columnheaderclass',ctrl:'OPERACIONESCOMPROBANTEPAGO',prop:'Columnheaderclass'},{av:'edtOperacionesFechaAlta_Columnheaderclass',ctrl:'OPERACIONESFECHAALTA',prop:'Columnheaderclass'},{av:'edtOperacionesFechaDesde_Columnheaderclass',ctrl:'OPERACIONESFECHADESDE',prop:'Columnheaderclass'},{av:'edtOperacionesFechaHasta_Columnheaderclass',ctrl:'OPERACIONESFECHAHASTA',prop:'Columnheaderclass'},{av:'edtOperacionesFechaPago_Columnheaderclass',ctrl:'OPERACIONESFECHAPAGO',prop:'Columnheaderclass'},{av:'AV105Grid_GroupCaption',fld:'vGRID_GROUPCAPTION',pic:'',type:'svchar'},{av:'AV82IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV115IsAuthorized_PagoSaldo',fld:'vISAUTHORIZED_PAGOSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV116IsAuthorized_CobroSaldo',fld:'vISAUTHORIZED_COBROSALDO',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{ctrl:'BTNAGREGAR',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E225E2',iparms:[{av:'cmbavGridactions'},{av:'AV80GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'A554OperacionesId',fld:'OPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV114WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A657OperacionesNombreRef',fld:'OPERACIONESNOMBREREF',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV80GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E145E2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV120Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV102TFOperacionesTipo_Sels',fld:'vTFOPERACIONESTIPO_SELS',pic:''},{av:'AV101TFOperacionesTipo_SelsJson',fld:'vTFOPERACIONESTIPO_SELSJSON',pic:'',type:'vchar'},{av:'AV118TFOperacionesComprobantePago_Sel',fld:'vTFOPERACIONESCOMPROBANTEPAGO_SEL',pic:'',type:'char'},{av:'AV74TFOperacionesEstado_Sels',fld:'vTFOPERACIONESESTADO_SELS',pic:''},{av:'AV73TFOperacionesEstado_SelsJson',fld:'vTFOPERACIONESESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV117TFOperacionesComprobantePago',fld:'vTFOPERACIONESCOMPROBANTEPAGO',pic:'',type:'char'},{av:'AV63TFOperacionesFechaAlta',fld:'vTFOPERACIONESFECHAALTA',pic:'',type:'date'},{av:'AV91TFOperacionesFechaDesde',fld:'vTFOPERACIONESFECHADESDE',pic:'',type:'date'},{av:'AV96TFOperacionesFechaHasta',fld:'vTFOPERACIONESFECHAHASTA',pic:'',type:'date'},{av:'AV68TFOperacionesFechaPago',fld:'vTFOPERACIONESFECHAPAGO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV70DDO_OperacionesFechaPagoAuxDate',fld:'vDDO_OPERACIONESFECHAPAGOAUXDATE',pic:'',type:'date'},{av:'AV64TFOperacionesFechaAlta_To',fld:'vTFOPERACIONESFECHAALTA_TO',pic:'',type:'date'},{av:'AV92TFOperacionesFechaDesde_To',fld:'vTFOPERACIONESFECHADESDE_TO',pic:'',type:'date'},{av:'AV97TFOperacionesFechaHasta_To',fld:'vTFOPERACIONESFECHAHASTA_TO',pic:'',type:'date'},{av:'AV69TFOperacionesFechaPago_To',fld:'vTFOPERACIONESFECHAPAGO_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV71DDO_OperacionesFechaPagoAuxDateTo',fld:'vDDO_OPERACIONESFECHAPAGOAUXDATETO',pic:'',type:'date'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV106GroupOperacionesTipo',fld:'vGROUPOPERACIONESTIPO',pic:'',type:'char'},{av:'cmbOperacionesTipo'},{av:'A649OperacionesTipo',fld:'OPERACIONESTIPO',pic:'',hsh:true,type:'char'},{av:'AV107GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''},{av:'A554OperacionesId',fld:'OPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV112AddChildren',fld:'vADDCHILDREN',pic:'',type:'boolean'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV108GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV82IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV115IsAuthorized_PagoSaldo',fld:'vISAUTHORIZED_PAGOSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV116IsAuthorized_CobroSaldo',fld:'vISAUTHORIZED_COBROSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV114WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV120Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV102TFOperacionesTipo_Sels',fld:'vTFOPERACIONESTIPO_SELS',pic:''},{av:'AV117TFOperacionesComprobantePago',fld:'vTFOPERACIONESCOMPROBANTEPAGO',pic:'',type:'char'},{av:'AV118TFOperacionesComprobantePago_Sel',fld:'vTFOPERACIONESCOMPROBANTEPAGO_SEL',pic:'',type:'char'},{av:'AV63TFOperacionesFechaAlta',fld:'vTFOPERACIONESFECHAALTA',pic:'',type:'date'},{av:'AV64TFOperacionesFechaAlta_To',fld:'vTFOPERACIONESFECHAALTA_TO',pic:'',type:'date'},{av:'AV91TFOperacionesFechaDesde',fld:'vTFOPERACIONESFECHADESDE',pic:'',type:'date'},{av:'AV92TFOperacionesFechaDesde_To',fld:'vTFOPERACIONESFECHADESDE_TO',pic:'',type:'date'},{av:'AV96TFOperacionesFechaHasta',fld:'vTFOPERACIONESFECHAHASTA',pic:'',type:'date'},{av:'AV97TFOperacionesFechaHasta_To',fld:'vTFOPERACIONESFECHAHASTA_TO',pic:'',type:'date'},{av:'AV68TFOperacionesFechaPago',fld:'vTFOPERACIONESFECHAPAGO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV69TFOperacionesFechaPago_To',fld:'vTFOPERACIONESFECHAPAGO_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV74TFOperacionesEstado_Sels',fld:'vTFOPERACIONESESTADO_SELS',pic:''},{av:'AV108GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV82IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV115IsAuthorized_PagoSaldo',fld:'vISAUTHORIZED_PAGOSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV116IsAuthorized_CobroSaldo',fld:'vISAUTHORIZED_COBROSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV107GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''},{av:'AV114WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV112AddChildren',fld:'vADDCHILDREN',pic:'',type:'boolean'},{av:'AV106GroupOperacionesTipo',fld:'vGROUPOPERACIONESTIPO',pic:'',type:'char'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV73TFOperacionesEstado_SelsJson',fld:'vTFOPERACIONESESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV70DDO_OperacionesFechaPagoAuxDate',fld:'vDDO_OPERACIONESFECHAPAGOAUXDATE',pic:'',type:'date'},{av:'AV71DDO_OperacionesFechaPagoAuxDateTo',fld:'vDDO_OPERACIONESFECHAPAGOAUXDATETO',pic:'',type:'date'},{av:'AV101TFOperacionesTipo_SelsJson',fld:'vTFOPERACIONESTIPO_SELSJSON',pic:'',type:'vchar'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'edtOperacionesId_Visible',ctrl:'OPERACIONESID',prop:'Visible'},{av:'edtOperacionesRef_Visible',ctrl:'OPERACIONESREF',prop:'Visible'},{av:'edtOperacionesNombreRef_Visible',ctrl:'OPERACIONESNOMBREREF',prop:'Visible'},{av:'cmbOperacionesTipo'},{av:'cmbOperacionesTipoES'},{av:'edtOperacionesImporte_Visible',ctrl:'OPERACIONESIMPORTE',prop:'Visible'},{av:'edtOperacionesFacturaCod_Visible',ctrl:'OPERACIONESFACTURACOD',prop:'Visible'},{av:'edtOperacionesComprobantePago_Visible',ctrl:'OPERACIONESCOMPROBANTEPAGO',prop:'Visible'},{av:'edtOperacionesFechaAlta_Visible',ctrl:'OPERACIONESFECHAALTA',prop:'Visible'},{av:'edtOperacionesFechaDesde_Visible',ctrl:'OPERACIONESFECHADESDE',prop:'Visible'},{av:'edtOperacionesFechaHasta_Visible',ctrl:'OPERACIONESFECHAHASTA',prop:'Visible'},{av:'edtOperacionesFechaPago_Visible',ctrl:'OPERACIONESFECHAPAGO',prop:'Visible'},{av:'cmbOperacionesEstado'},{av:'AV77GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV78GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV79GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'edtavExpand_Columnheaderclass',ctrl:'vEXPAND',prop:'Columnheaderclass'},{av:'cmbavGridactions'},{av:'edtOperacionesId_Columnheaderclass',ctrl:'OPERACIONESID',prop:'Columnheaderclass'},{av:'edtOperacionesRef_Columnheaderclass',ctrl:'OPERACIONESREF',prop:'Columnheaderclass'},{av:'edtOperacionesNombreRef_Columnheaderclass',ctrl:'OPERACIONESNOMBREREF',prop:'Columnheaderclass'},{av:'edtOperacionesImporte_Columnheaderclass',ctrl:'OPERACIONESIMPORTE',prop:'Columnheaderclass'},{av:'edtOperacionesFacturaCod_Columnheaderclass',ctrl:'OPERACIONESFACTURACOD',prop:'Columnheaderclass'},{av:'edtOperacionesComprobantePago_Columnheaderclass',ctrl:'OPERACIONESCOMPROBANTEPAGO',prop:'Columnheaderclass'},{av:'edtOperacionesFechaAlta_Columnheaderclass',ctrl:'OPERACIONESFECHAALTA',prop:'Columnheaderclass'},{av:'edtOperacionesFechaDesde_Columnheaderclass',ctrl:'OPERACIONESFECHADESDE',prop:'Columnheaderclass'},{av:'edtOperacionesFechaHasta_Columnheaderclass',ctrl:'OPERACIONESFECHAHASTA',prop:'Columnheaderclass'},{av:'edtOperacionesFechaPago_Columnheaderclass',ctrl:'OPERACIONESFECHAPAGO',prop:'Columnheaderclass'},{av:'AV105Grid_GroupCaption',fld:'vGRID_GROUPCAPTION',pic:'',type:'svchar'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{ctrl:'BTNAGREGAR',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","{handler:'E155E2',iparms:[]");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("'DOAGREGAR'","{handler:'E185E2',iparms:[]");
         setEventMetadata("'DOAGREGAR'",",oparms:[]}");
         setEventMetadata("VEXPAND.CLICK","{handler:'E235E2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV120Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV102TFOperacionesTipo_Sels',fld:'vTFOPERACIONESTIPO_SELS',pic:''},{av:'AV117TFOperacionesComprobantePago',fld:'vTFOPERACIONESCOMPROBANTEPAGO',pic:'',type:'char'},{av:'AV118TFOperacionesComprobantePago_Sel',fld:'vTFOPERACIONESCOMPROBANTEPAGO_SEL',pic:'',type:'char'},{av:'AV63TFOperacionesFechaAlta',fld:'vTFOPERACIONESFECHAALTA',pic:'',type:'date'},{av:'AV64TFOperacionesFechaAlta_To',fld:'vTFOPERACIONESFECHAALTA_TO',pic:'',type:'date'},{av:'AV91TFOperacionesFechaDesde',fld:'vTFOPERACIONESFECHADESDE',pic:'',type:'date'},{av:'AV92TFOperacionesFechaDesde_To',fld:'vTFOPERACIONESFECHADESDE_TO',pic:'',type:'date'},{av:'AV96TFOperacionesFechaHasta',fld:'vTFOPERACIONESFECHAHASTA',pic:'',type:'date'},{av:'AV97TFOperacionesFechaHasta_To',fld:'vTFOPERACIONESFECHAHASTA_TO',pic:'',type:'date'},{av:'AV68TFOperacionesFechaPago',fld:'vTFOPERACIONESFECHAPAGO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV69TFOperacionesFechaPago_To',fld:'vTFOPERACIONESFECHAPAGO_TO',pic:'99/99/99 99:99',type:'dtime'},{av:'AV74TFOperacionesEstado_Sels',fld:'vTFOPERACIONESESTADO_SELS',pic:''},{av:'AV108GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV82IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV115IsAuthorized_PagoSaldo',fld:'vISAUTHORIZED_PAGOSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV116IsAuthorized_CobroSaldo',fld:'vISAUTHORIZED_COBROSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV107GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''},{av:'AV114WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'cmbOperacionesTipo'},{av:'A649OperacionesTipo',fld:'OPERACIONESTIPO',pic:'',hsh:true,type:'char'},{av:'AV106GroupOperacionesTipo',fld:'vGROUPOPERACIONESTIPO',pic:'',type:'char'},{av:'A554OperacionesId',fld:'OPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV112AddChildren',fld:'vADDCHILDREN',pic:'',type:'boolean'}]");
         setEventMetadata("VEXPAND.CLICK",",oparms:[{av:'AV106GroupOperacionesTipo',fld:'vGROUPOPERACIONESTIPO',pic:'',type:'char'},{av:'AV108GridCollapsedRecords',fld:'vGRIDCOLLAPSEDRECORDS',pic:''},{av:'AV112AddChildren',fld:'vADDCHILDREN',pic:'',type:'boolean'},{av:'AV107GridCollapsedRecordsChildren',fld:'vGRIDCOLLAPSEDRECORDSCHILDREN',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtOperacionesId_Visible',ctrl:'OPERACIONESID',prop:'Visible'},{av:'edtOperacionesRef_Visible',ctrl:'OPERACIONESREF',prop:'Visible'},{av:'edtOperacionesNombreRef_Visible',ctrl:'OPERACIONESNOMBREREF',prop:'Visible'},{av:'cmbOperacionesTipo'},{av:'cmbOperacionesTipoES'},{av:'edtOperacionesImporte_Visible',ctrl:'OPERACIONESIMPORTE',prop:'Visible'},{av:'edtOperacionesFacturaCod_Visible',ctrl:'OPERACIONESFACTURACOD',prop:'Visible'},{av:'edtOperacionesComprobantePago_Visible',ctrl:'OPERACIONESCOMPROBANTEPAGO',prop:'Visible'},{av:'edtOperacionesFechaAlta_Visible',ctrl:'OPERACIONESFECHAALTA',prop:'Visible'},{av:'edtOperacionesFechaDesde_Visible',ctrl:'OPERACIONESFECHADESDE',prop:'Visible'},{av:'edtOperacionesFechaHasta_Visible',ctrl:'OPERACIONESFECHAHASTA',prop:'Visible'},{av:'edtOperacionesFechaPago_Visible',ctrl:'OPERACIONESFECHAPAGO',prop:'Visible'},{av:'cmbOperacionesEstado'},{av:'AV77GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV78GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV79GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'edtavExpand_Columnheaderclass',ctrl:'vEXPAND',prop:'Columnheaderclass'},{av:'cmbavGridactions'},{av:'edtOperacionesId_Columnheaderclass',ctrl:'OPERACIONESID',prop:'Columnheaderclass'},{av:'edtOperacionesRef_Columnheaderclass',ctrl:'OPERACIONESREF',prop:'Columnheaderclass'},{av:'edtOperacionesNombreRef_Columnheaderclass',ctrl:'OPERACIONESNOMBREREF',prop:'Columnheaderclass'},{av:'edtOperacionesImporte_Columnheaderclass',ctrl:'OPERACIONESIMPORTE',prop:'Columnheaderclass'},{av:'edtOperacionesFacturaCod_Columnheaderclass',ctrl:'OPERACIONESFACTURACOD',prop:'Columnheaderclass'},{av:'edtOperacionesComprobantePago_Columnheaderclass',ctrl:'OPERACIONESCOMPROBANTEPAGO',prop:'Columnheaderclass'},{av:'edtOperacionesFechaAlta_Columnheaderclass',ctrl:'OPERACIONESFECHAALTA',prop:'Columnheaderclass'},{av:'edtOperacionesFechaDesde_Columnheaderclass',ctrl:'OPERACIONESFECHADESDE',prop:'Columnheaderclass'},{av:'edtOperacionesFechaHasta_Columnheaderclass',ctrl:'OPERACIONESFECHAHASTA',prop:'Columnheaderclass'},{av:'edtOperacionesFechaPago_Columnheaderclass',ctrl:'OPERACIONESFECHAPAGO',prop:'Columnheaderclass'},{av:'AV105Grid_GroupCaption',fld:'vGRID_GROUPCAPTION',pic:'',type:'svchar'},{av:'AV82IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV115IsAuthorized_PagoSaldo',fld:'vISAUTHORIZED_PAGOSALDO',pic:'',hsh:true,type:'boolean'},{av:'AV116IsAuthorized_CobroSaldo',fld:'vISAUTHORIZED_COBROSALDO',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{ctrl:'BTNAGREGAR',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("VALIDV_DDO_OPERACIONESFECHAALTAAUXDATE","{handler:'Validv_Ddo_operacionesfechaaltaauxdate',iparms:[]");
         setEventMetadata("VALIDV_DDO_OPERACIONESFECHAALTAAUXDATE",",oparms:[]}");
         setEventMetadata("VALIDV_DDO_OPERACIONESFECHAALTAAUXDATETO","{handler:'Validv_Ddo_operacionesfechaaltaauxdateto',iparms:[]");
         setEventMetadata("VALIDV_DDO_OPERACIONESFECHAALTAAUXDATETO",",oparms:[]}");
         setEventMetadata("VALIDV_DDO_OPERACIONESFECHADESDEAUXDATE","{handler:'Validv_Ddo_operacionesfechadesdeauxdate',iparms:[]");
         setEventMetadata("VALIDV_DDO_OPERACIONESFECHADESDEAUXDATE",",oparms:[]}");
         setEventMetadata("VALIDV_DDO_OPERACIONESFECHADESDEAUXDATETO","{handler:'Validv_Ddo_operacionesfechadesdeauxdateto',iparms:[]");
         setEventMetadata("VALIDV_DDO_OPERACIONESFECHADESDEAUXDATETO",",oparms:[]}");
         setEventMetadata("VALIDV_DDO_OPERACIONESFECHAHASTAAUXDATE","{handler:'Validv_Ddo_operacionesfechahastaauxdate',iparms:[]");
         setEventMetadata("VALIDV_DDO_OPERACIONESFECHAHASTAAUXDATE",",oparms:[]}");
         setEventMetadata("VALIDV_DDO_OPERACIONESFECHAHASTAAUXDATETO","{handler:'Validv_Ddo_operacionesfechahastaauxdateto',iparms:[]");
         setEventMetadata("VALIDV_DDO_OPERACIONESFECHAHASTAAUXDATETO",",oparms:[]}");
         setEventMetadata("VALIDV_DDO_OPERACIONESFECHAPAGOAUXDATE","{handler:'Validv_Ddo_operacionesfechapagoauxdate',iparms:[]");
         setEventMetadata("VALIDV_DDO_OPERACIONESFECHAPAGOAUXDATE",",oparms:[]}");
         setEventMetadata("VALIDV_DDO_OPERACIONESFECHAPAGOAUXDATETO","{handler:'Validv_Ddo_operacionesfechapagoauxdateto',iparms:[]");
         setEventMetadata("VALIDV_DDO_OPERACIONESFECHAPAGOAUXDATETO",",oparms:[]}");
         setEventMetadata("VALID_OPERACIONESID","{handler:'Valid_Operacionesid',iparms:[]");
         setEventMetadata("VALID_OPERACIONESID",",oparms:[]}");
         setEventMetadata("VALID_OPERACIONESREF","{handler:'Valid_Operacionesref',iparms:[]");
         setEventMetadata("VALID_OPERACIONESREF",",oparms:[]}");
         setEventMetadata("VALID_OPERACIONESNOMBREREF","{handler:'Valid_Operacionesnombreref',iparms:[]");
         setEventMetadata("VALID_OPERACIONESNOMBREREF",",oparms:[]}");
         setEventMetadata("VALID_OPERACIONESTIPO","{handler:'Valid_Operacionestipo',iparms:[]");
         setEventMetadata("VALID_OPERACIONESTIPO",",oparms:[]}");
         setEventMetadata("VALID_OPERACIONESTIPOES","{handler:'Valid_Operacionestipoes',iparms:[]");
         setEventMetadata("VALID_OPERACIONESTIPOES",",oparms:[]}");
         setEventMetadata("VALID_OPERACIONESIMPORTE","{handler:'Valid_Operacionesimporte',iparms:[]");
         setEventMetadata("VALID_OPERACIONESIMPORTE",",oparms:[]}");
         setEventMetadata("VALID_OPERACIONESFACTURACOD","{handler:'Valid_Operacionesfacturacod',iparms:[]");
         setEventMetadata("VALID_OPERACIONESFACTURACOD",",oparms:[]}");
         setEventMetadata("VALID_OPERACIONESCOMPROBANTEPAGO","{handler:'Valid_Operacionescomprobantepago',iparms:[]");
         setEventMetadata("VALID_OPERACIONESCOMPROBANTEPAGO",",oparms:[]}");
         setEventMetadata("VALID_OPERACIONESESTADO","{handler:'Valid_Operacionesestado',iparms:[]");
         setEventMetadata("VALID_OPERACIONESESTADO",",oparms:[]}");
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
         AV35ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV120Pgmname = "";
         AV17FilterFullText = "";
         AV102TFOperacionesTipo_Sels = new GxSimpleCollection<string>();
         AV117TFOperacionesComprobantePago = "";
         AV118TFOperacionesComprobantePago_Sel = "";
         AV63TFOperacionesFechaAlta = DateTime.MinValue;
         AV64TFOperacionesFechaAlta_To = DateTime.MinValue;
         AV91TFOperacionesFechaDesde = DateTime.MinValue;
         AV92TFOperacionesFechaDesde_To = DateTime.MinValue;
         AV96TFOperacionesFechaHasta = DateTime.MinValue;
         AV97TFOperacionesFechaHasta_To = DateTime.MinValue;
         AV68TFOperacionesFechaPago = (DateTime)(DateTime.MinValue);
         AV69TFOperacionesFechaPago_To = (DateTime)(DateTime.MinValue);
         AV74TFOperacionesEstado_Sels = new GxSimpleCollection<string>();
         AV108GridCollapsedRecords = new GxSimpleCollection<string>();
         AV107GridCollapsedRecordsChildren = new GxSimpleCollection<long>();
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV38ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV79GridAppliedFilters = "";
         AV103LiquidacionesData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV84AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV75DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV101TFOperacionesTipo_SelsJson = "";
         AV73TFOperacionesEstado_SelsJson = "";
         AV106GroupOperacionesTipo = "";
         Ddo_liquidaciones_Caption = "";
         Ddo_agexport_Caption = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_titlescategories_Gridinternalname = "";
         Grid_group_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnliquidaciones_Jsonclick = "";
         bttBtnagexport_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         bttBtnsubscriptions_Jsonclick = "";
         bttBtnagregar_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_liquidaciones = new GXUserControl();
         ucDdo_agexport = new GXUserControl();
         ucDdc_subscriptions = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_titlescategories = new GXUserControl();
         ucGrid_group = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         AV65DDO_OperacionesFechaAltaAuxDate = DateTime.MinValue;
         AV66DDO_OperacionesFechaAltaAuxDateTo = DateTime.MinValue;
         AV93DDO_OperacionesFechaDesdeAuxDate = DateTime.MinValue;
         AV94DDO_OperacionesFechaDesdeAuxDateTo = DateTime.MinValue;
         AV98DDO_OperacionesFechaHastaAuxDate = DateTime.MinValue;
         AV99DDO_OperacionesFechaHastaAuxDateTo = DateTime.MinValue;
         AV70DDO_OperacionesFechaPagoAuxDate = DateTime.MinValue;
         AV71DDO_OperacionesFechaPagoAuxDateTo = DateTime.MinValue;
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV113Expand = "";
         AV105Grid_GroupCaption = "";
         A555OperacionesRef = "";
         A657OperacionesNombreRef = "";
         A649OperacionesTipo = "";
         A569OperacionesTipoES = "";
         A572OperacionesFacturaCod = "";
         A580OperacionesComprobantePago = "";
         A581OperacionesFechaAlta = DateTime.MinValue;
         A658OperacionesFechaDesde = DateTime.MinValue;
         A659OperacionesFechaHasta = DateTime.MinValue;
         A582OperacionesFechaPago = (DateTime)(DateTime.MinValue);
         A577OperacionesEstado = "";
         AV121Operacioneswwds_1_filterfulltext = "";
         AV122Operacioneswwds_2_tfoperacionestipo_sels = new GxSimpleCollection<string>();
         AV123Operacioneswwds_3_tfoperacionescomprobantepago = "";
         AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel = "";
         AV125Operacioneswwds_5_tfoperacionesfechaalta = DateTime.MinValue;
         AV126Operacioneswwds_6_tfoperacionesfechaalta_to = DateTime.MinValue;
         AV127Operacioneswwds_7_tfoperacionesfechadesde = DateTime.MinValue;
         AV128Operacioneswwds_8_tfoperacionesfechadesde_to = DateTime.MinValue;
         AV129Operacioneswwds_9_tfoperacionesfechahasta = DateTime.MinValue;
         AV130Operacioneswwds_10_tfoperacionesfechahasta_to = DateTime.MinValue;
         AV131Operacioneswwds_11_tfoperacionesfechapago = (DateTime)(DateTime.MinValue);
         AV132Operacioneswwds_12_tfoperacionesfechapago_to = (DateTime)(DateTime.MinValue);
         AV133Operacioneswwds_13_tfoperacionesestado_sels = new GxSimpleCollection<string>();
         lV123Operacioneswwds_3_tfoperacionescomprobantepago = "";
         H005E2_A577OperacionesEstado = new string[] {""} ;
         H005E2_n577OperacionesEstado = new bool[] {false} ;
         H005E2_A582OperacionesFechaPago = new DateTime[] {DateTime.MinValue} ;
         H005E2_n582OperacionesFechaPago = new bool[] {false} ;
         H005E2_A659OperacionesFechaHasta = new DateTime[] {DateTime.MinValue} ;
         H005E2_n659OperacionesFechaHasta = new bool[] {false} ;
         H005E2_A658OperacionesFechaDesde = new DateTime[] {DateTime.MinValue} ;
         H005E2_n658OperacionesFechaDesde = new bool[] {false} ;
         H005E2_A581OperacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H005E2_n581OperacionesFechaAlta = new bool[] {false} ;
         H005E2_A580OperacionesComprobantePago = new string[] {""} ;
         H005E2_n580OperacionesComprobantePago = new bool[] {false} ;
         H005E2_A572OperacionesFacturaCod = new string[] {""} ;
         H005E2_n572OperacionesFacturaCod = new bool[] {false} ;
         H005E2_A570OperacionesImporte = new decimal[1] ;
         H005E2_n570OperacionesImporte = new bool[] {false} ;
         H005E2_A569OperacionesTipoES = new string[] {""} ;
         H005E2_n569OperacionesTipoES = new bool[] {false} ;
         H005E2_A649OperacionesTipo = new string[] {""} ;
         H005E2_n649OperacionesTipo = new bool[] {false} ;
         H005E2_A657OperacionesNombreRef = new string[] {""} ;
         H005E2_n657OperacionesNombreRef = new bool[] {false} ;
         H005E2_A555OperacionesRef = new string[] {""} ;
         H005E2_n555OperacionesRef = new bool[] {false} ;
         H005E2_A554OperacionesId = new long[1] ;
         H005E3_A577OperacionesEstado = new string[] {""} ;
         H005E3_n577OperacionesEstado = new bool[] {false} ;
         H005E3_A582OperacionesFechaPago = new DateTime[] {DateTime.MinValue} ;
         H005E3_n582OperacionesFechaPago = new bool[] {false} ;
         H005E3_A659OperacionesFechaHasta = new DateTime[] {DateTime.MinValue} ;
         H005E3_n659OperacionesFechaHasta = new bool[] {false} ;
         H005E3_A658OperacionesFechaDesde = new DateTime[] {DateTime.MinValue} ;
         H005E3_n658OperacionesFechaDesde = new bool[] {false} ;
         H005E3_A581OperacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H005E3_n581OperacionesFechaAlta = new bool[] {false} ;
         H005E3_A580OperacionesComprobantePago = new string[] {""} ;
         H005E3_n580OperacionesComprobantePago = new bool[] {false} ;
         H005E3_A572OperacionesFacturaCod = new string[] {""} ;
         H005E3_n572OperacionesFacturaCod = new bool[] {false} ;
         H005E3_A570OperacionesImporte = new decimal[1] ;
         H005E3_n570OperacionesImporte = new bool[] {false} ;
         H005E3_A569OperacionesTipoES = new string[] {""} ;
         H005E3_n569OperacionesTipoES = new bool[] {false} ;
         H005E3_A649OperacionesTipo = new string[] {""} ;
         H005E3_n649OperacionesTipo = new bool[] {false} ;
         H005E3_A657OperacionesNombreRef = new string[] {""} ;
         H005E3_n657OperacionesNombreRef = new bool[] {false} ;
         H005E3_A555OperacionesRef = new string[] {""} ;
         H005E3_n555OperacionesRef = new bool[] {false} ;
         H005E3_A554OperacionesId = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         AV104LiquidacionesDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXEncryptionTmp = "";
         AV85AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV37Session = context.GetSession();
         AV33ColumnsSelectorXML = "";
         GridRow = new GXWebRow();
         AV39ManageFiltersXml = "";
         AV34UserCustomValue = "";
         AV36ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char3 = "";
         GXt_char5 = "";
         GXt_char6 = "";
         AV110OldGridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV31ExcelFilename = "";
         AV32ErrorMessage = "";
         H005E4_A572OperacionesFacturaCod = new string[] {""} ;
         H005E4_n572OperacionesFacturaCod = new bool[] {false} ;
         H005E4_A570OperacionesImporte = new decimal[1] ;
         H005E4_n570OperacionesImporte = new bool[] {false} ;
         H005E4_A657OperacionesNombreRef = new string[] {""} ;
         H005E4_n657OperacionesNombreRef = new bool[] {false} ;
         H005E4_A555OperacionesRef = new string[] {""} ;
         H005E4_n555OperacionesRef = new bool[] {false} ;
         H005E4_A554OperacionesId = new long[1] ;
         H005E4_A659OperacionesFechaHasta = new DateTime[] {DateTime.MinValue} ;
         H005E4_n659OperacionesFechaHasta = new bool[] {false} ;
         H005E4_A658OperacionesFechaDesde = new DateTime[] {DateTime.MinValue} ;
         H005E4_n658OperacionesFechaDesde = new bool[] {false} ;
         H005E4_A580OperacionesComprobantePago = new string[] {""} ;
         H005E4_n580OperacionesComprobantePago = new bool[] {false} ;
         H005E4_A577OperacionesEstado = new string[] {""} ;
         H005E4_n577OperacionesEstado = new bool[] {false} ;
         H005E4_A569OperacionesTipoES = new string[] {""} ;
         H005E4_n569OperacionesTipoES = new bool[] {false} ;
         H005E4_A649OperacionesTipo = new string[] {""} ;
         H005E4_n649OperacionesTipo = new bool[] {false} ;
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.operacionesww__default(),
            new Object[][] {
                new Object[] {
               H005E2_A577OperacionesEstado, H005E2_n577OperacionesEstado, H005E2_A582OperacionesFechaPago, H005E2_n582OperacionesFechaPago, H005E2_A659OperacionesFechaHasta, H005E2_n659OperacionesFechaHasta, H005E2_A658OperacionesFechaDesde, H005E2_n658OperacionesFechaDesde, H005E2_A581OperacionesFechaAlta, H005E2_n581OperacionesFechaAlta,
               H005E2_A580OperacionesComprobantePago, H005E2_n580OperacionesComprobantePago, H005E2_A572OperacionesFacturaCod, H005E2_n572OperacionesFacturaCod, H005E2_A570OperacionesImporte, H005E2_n570OperacionesImporte, H005E2_A569OperacionesTipoES, H005E2_n569OperacionesTipoES, H005E2_A649OperacionesTipo, H005E2_n649OperacionesTipo,
               H005E2_A657OperacionesNombreRef, H005E2_n657OperacionesNombreRef, H005E2_A555OperacionesRef, H005E2_n555OperacionesRef, H005E2_A554OperacionesId
               }
               , new Object[] {
               H005E3_A577OperacionesEstado, H005E3_n577OperacionesEstado, H005E3_A582OperacionesFechaPago, H005E3_n582OperacionesFechaPago, H005E3_A659OperacionesFechaHasta, H005E3_n659OperacionesFechaHasta, H005E3_A658OperacionesFechaDesde, H005E3_n658OperacionesFechaDesde, H005E3_A581OperacionesFechaAlta, H005E3_n581OperacionesFechaAlta,
               H005E3_A580OperacionesComprobantePago, H005E3_n580OperacionesComprobantePago, H005E3_A572OperacionesFacturaCod, H005E3_n572OperacionesFacturaCod, H005E3_A570OperacionesImporte, H005E3_n570OperacionesImporte, H005E3_A569OperacionesTipoES, H005E3_n569OperacionesTipoES, H005E3_A649OperacionesTipo, H005E3_n649OperacionesTipo,
               H005E3_A657OperacionesNombreRef, H005E3_n657OperacionesNombreRef, H005E3_A555OperacionesRef, H005E3_n555OperacionesRef, H005E3_A554OperacionesId
               }
               , new Object[] {
               H005E4_A572OperacionesFacturaCod, H005E4_n572OperacionesFacturaCod, H005E4_A570OperacionesImporte, H005E4_n570OperacionesImporte, H005E4_A657OperacionesNombreRef, H005E4_n657OperacionesNombreRef, H005E4_A555OperacionesRef, H005E4_n555OperacionesRef, H005E4_A554OperacionesId, H005E4_A659OperacionesFechaHasta,
               H005E4_n659OperacionesFechaHasta, H005E4_A658OperacionesFechaDesde, H005E4_n658OperacionesFechaDesde, H005E4_A580OperacionesComprobantePago, H005E4_n580OperacionesComprobantePago, H005E4_A577OperacionesEstado, H005E4_n577OperacionesEstado, H005E4_A569OperacionesTipoES, H005E4_n569OperacionesTipoES, H005E4_A649OperacionesTipo,
               H005E4_n649OperacionesTipo
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV120Pgmname = "OperacionesWW";
         /* GeneXus formulas. */
         AV120Pgmname = "OperacionesWW";
         edtavExpand_Enabled = 0;
         edtavGrid_groupcaption_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV14OrderedBy ;
      private short AV40ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV80GridActions ;
      private short nCmpId ;
      private short nDonePA ;
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
      private int nRC_GXsfl_45 ;
      private int nGXsfl_45_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int Grid_group_Columnindex ;
      private int bttBtnsubscriptions_Visible ;
      private int bttBtnagregar_Visible ;
      private int subGrid_Islastpage ;
      private int edtavExpand_Enabled ;
      private int edtavGrid_groupcaption_Enabled ;
      private int AV122Operacioneswwds_2_tfoperacionestipo_sels_Count ;
      private int AV133Operacioneswwds_13_tfoperacionesestado_sels_Count ;
      private int AV107GridCollapsedRecordsChildren_Count ;
      private int edtOperacionesId_Enabled ;
      private int edtOperacionesRef_Enabled ;
      private int edtOperacionesNombreRef_Enabled ;
      private int edtOperacionesImporte_Enabled ;
      private int edtOperacionesFacturaCod_Enabled ;
      private int edtOperacionesComprobantePago_Enabled ;
      private int edtOperacionesFechaAlta_Enabled ;
      private int edtOperacionesFechaDesde_Enabled ;
      private int edtOperacionesFechaHasta_Enabled ;
      private int edtOperacionesFechaPago_Enabled ;
      private int edtOperacionesId_Visible ;
      private int edtOperacionesRef_Visible ;
      private int edtOperacionesNombreRef_Visible ;
      private int edtOperacionesImporte_Visible ;
      private int edtOperacionesFacturaCod_Visible ;
      private int edtOperacionesComprobantePago_Visible ;
      private int edtOperacionesFechaAlta_Visible ;
      private int edtOperacionesFechaDesde_Visible ;
      private int edtOperacionesFechaHasta_Visible ;
      private int edtOperacionesFechaPago_Visible ;
      private int AV76PageToGo ;
      private int AV134GXV1 ;
      private int AV135GXV2 ;
      private int AV136GXV3 ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV114WalletId ;
      private long AV77GridCurrentPage ;
      private long AV78GridPageCount ;
      private long A554OperacionesId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private long AV109Index ;
      private decimal A570OperacionesImporte ;
      private decimal AV119Nullvalue ;
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
      private string sGXsfl_45_idx="0001" ;
      private string AV120Pgmname ;
      private string AV117TFOperacionesComprobantePago ;
      private string AV118TFOperacionesComprobantePago_Sel ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV106GroupOperacionesTipo ;
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
      private string Ddo_liquidaciones_Icontype ;
      private string Ddo_liquidaciones_Icon ;
      private string Ddo_liquidaciones_Caption ;
      private string Ddo_liquidaciones_Cls ;
      private string Ddo_liquidaciones_Titlecontrolidtoreplace ;
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
      private string Grid_titlescategories_Gridinternalname ;
      private string Grid_titlescategories_Gridtitlescategories ;
      private string Grid_group_Gridinternalname ;
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
      private string bttBtnliquidaciones_Internalname ;
      private string bttBtnliquidaciones_Jsonclick ;
      private string bttBtnagexport_Internalname ;
      private string bttBtnagexport_Jsonclick ;
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
      private string bttBtnsubscriptions_Internalname ;
      private string bttBtnsubscriptions_Jsonclick ;
      private string bttBtnagregar_Internalname ;
      private string bttBtnagregar_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_liquidaciones_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string Ddc_subscriptions_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Innewwindow1_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_titlescategories_Internalname ;
      private string Grid_group_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string divDdo_operacionesfechaaltaauxdates_Internalname ;
      private string edtavDdo_operacionesfechaaltaauxdate_Internalname ;
      private string edtavDdo_operacionesfechaaltaauxdate_Jsonclick ;
      private string edtavDdo_operacionesfechaaltaauxdateto_Internalname ;
      private string edtavDdo_operacionesfechaaltaauxdateto_Jsonclick ;
      private string divDdo_operacionesfechadesdeauxdates_Internalname ;
      private string edtavDdo_operacionesfechadesdeauxdate_Internalname ;
      private string edtavDdo_operacionesfechadesdeauxdate_Jsonclick ;
      private string edtavDdo_operacionesfechadesdeauxdateto_Internalname ;
      private string edtavDdo_operacionesfechadesdeauxdateto_Jsonclick ;
      private string divDdo_operacionesfechahastaauxdates_Internalname ;
      private string edtavDdo_operacionesfechahastaauxdate_Internalname ;
      private string edtavDdo_operacionesfechahastaauxdate_Jsonclick ;
      private string edtavDdo_operacionesfechahastaauxdateto_Internalname ;
      private string edtavDdo_operacionesfechahastaauxdateto_Jsonclick ;
      private string divDdo_operacionesfechapagoauxdates_Internalname ;
      private string edtavDdo_operacionesfechapagoauxdate_Internalname ;
      private string edtavDdo_operacionesfechapagoauxdate_Jsonclick ;
      private string edtavDdo_operacionesfechapagoauxdateto_Internalname ;
      private string edtavDdo_operacionesfechapagoauxdateto_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV113Expand ;
      private string edtavExpand_Internalname ;
      private string edtavGrid_groupcaption_Internalname ;
      private string cmbavGridactions_Internalname ;
      private string edtOperacionesId_Internalname ;
      private string A555OperacionesRef ;
      private string edtOperacionesRef_Internalname ;
      private string A657OperacionesNombreRef ;
      private string edtOperacionesNombreRef_Internalname ;
      private string cmbOperacionesTipo_Internalname ;
      private string A649OperacionesTipo ;
      private string cmbOperacionesTipoES_Internalname ;
      private string A569OperacionesTipoES ;
      private string edtOperacionesImporte_Internalname ;
      private string A572OperacionesFacturaCod ;
      private string edtOperacionesFacturaCod_Internalname ;
      private string A580OperacionesComprobantePago ;
      private string edtOperacionesComprobantePago_Internalname ;
      private string edtOperacionesFechaAlta_Internalname ;
      private string edtOperacionesFechaDesde_Internalname ;
      private string edtOperacionesFechaHasta_Internalname ;
      private string edtOperacionesFechaPago_Internalname ;
      private string cmbOperacionesEstado_Internalname ;
      private string A577OperacionesEstado ;
      private string edtavFilterfulltext_Internalname ;
      private string AV123Operacioneswwds_3_tfoperacionescomprobantepago ;
      private string AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel ;
      private string lV123Operacioneswwds_3_tfoperacionescomprobantepago ;
      private string GXEncryptionTmp ;
      private string edtavExpand_Columnheaderclass ;
      private string cmbavGridactions_Columnheaderclass ;
      private string edtOperacionesId_Columnheaderclass ;
      private string edtOperacionesRef_Columnheaderclass ;
      private string edtOperacionesNombreRef_Columnheaderclass ;
      private string cmbOperacionesTipo_Columnheaderclass ;
      private string cmbOperacionesTipoES_Columnheaderclass ;
      private string edtOperacionesImporte_Columnheaderclass ;
      private string edtOperacionesFacturaCod_Columnheaderclass ;
      private string edtOperacionesComprobantePago_Columnheaderclass ;
      private string edtOperacionesFechaAlta_Columnheaderclass ;
      private string edtOperacionesFechaDesde_Columnheaderclass ;
      private string edtOperacionesFechaHasta_Columnheaderclass ;
      private string edtOperacionesFechaPago_Columnheaderclass ;
      private string cmbOperacionesEstado_Columnheaderclass ;
      private string edtavExpand_Columnclass ;
      private string cmbavGridactions_Columnclass ;
      private string edtOperacionesId_Columnclass ;
      private string edtOperacionesRef_Columnclass ;
      private string edtOperacionesNombreRef_Columnclass ;
      private string cmbOperacionesTipo_Columnclass ;
      private string cmbOperacionesTipoES_Columnclass ;
      private string edtOperacionesImporte_Columnclass ;
      private string edtOperacionesFacturaCod_Columnclass ;
      private string edtOperacionesComprobantePago_Columnclass ;
      private string edtOperacionesFechaAlta_Columnclass ;
      private string edtOperacionesFechaDesde_Columnclass ;
      private string edtOperacionesFechaHasta_Columnclass ;
      private string edtOperacionesFechaPago_Columnclass ;
      private string cmbOperacionesEstado_Columnclass ;
      private string GXt_char3 ;
      private string GXt_char5 ;
      private string GXt_char6 ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_45_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavExpand_Jsonclick ;
      private string edtavGrid_groupcaption_Jsonclick ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string edtOperacionesId_Jsonclick ;
      private string edtOperacionesRef_Jsonclick ;
      private string edtOperacionesNombreRef_Jsonclick ;
      private string cmbOperacionesTipo_Jsonclick ;
      private string cmbOperacionesTipoES_Jsonclick ;
      private string edtOperacionesImporte_Jsonclick ;
      private string edtOperacionesFacturaCod_Jsonclick ;
      private string edtOperacionesComprobantePago_Jsonclick ;
      private string edtOperacionesFechaAlta_Jsonclick ;
      private string edtOperacionesFechaDesde_Jsonclick ;
      private string edtOperacionesFechaHasta_Jsonclick ;
      private string edtOperacionesFechaPago_Jsonclick ;
      private string cmbOperacionesEstado_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV68TFOperacionesFechaPago ;
      private DateTime AV69TFOperacionesFechaPago_To ;
      private DateTime A582OperacionesFechaPago ;
      private DateTime AV131Operacioneswwds_11_tfoperacionesfechapago ;
      private DateTime AV132Operacioneswwds_12_tfoperacionesfechapago_to ;
      private DateTime AV63TFOperacionesFechaAlta ;
      private DateTime AV64TFOperacionesFechaAlta_To ;
      private DateTime AV91TFOperacionesFechaDesde ;
      private DateTime AV92TFOperacionesFechaDesde_To ;
      private DateTime AV96TFOperacionesFechaHasta ;
      private DateTime AV97TFOperacionesFechaHasta_To ;
      private DateTime AV65DDO_OperacionesFechaAltaAuxDate ;
      private DateTime AV66DDO_OperacionesFechaAltaAuxDateTo ;
      private DateTime AV93DDO_OperacionesFechaDesdeAuxDate ;
      private DateTime AV94DDO_OperacionesFechaDesdeAuxDateTo ;
      private DateTime AV98DDO_OperacionesFechaHastaAuxDate ;
      private DateTime AV99DDO_OperacionesFechaHastaAuxDateTo ;
      private DateTime AV70DDO_OperacionesFechaPagoAuxDate ;
      private DateTime AV71DDO_OperacionesFechaPagoAuxDateTo ;
      private DateTime A581OperacionesFechaAlta ;
      private DateTime A658OperacionesFechaDesde ;
      private DateTime A659OperacionesFechaHasta ;
      private DateTime AV125Operacioneswwds_5_tfoperacionesfechaalta ;
      private DateTime AV126Operacioneswwds_6_tfoperacionesfechaalta_to ;
      private DateTime AV127Operacioneswwds_7_tfoperacionesfechadesde ;
      private DateTime AV128Operacioneswwds_8_tfoperacionesfechadesde_to ;
      private DateTime AV129Operacioneswwds_9_tfoperacionesfechahasta ;
      private DateTime AV130Operacioneswwds_10_tfoperacionesfechahasta_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV82IsAuthorized_Update ;
      private bool AV115IsAuthorized_PagoSaldo ;
      private bool AV116IsAuthorized_CobroSaldo ;
      private bool AV112AddChildren ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Ddo_liquidaciones_Visible ;
      private bool Grid_empowerer_Hascategories ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool Grid_empowerer_Hasrowgroups ;
      private bool wbLoad ;
      private bool bGXsfl_45_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n555OperacionesRef ;
      private bool n657OperacionesNombreRef ;
      private bool n649OperacionesTipo ;
      private bool n569OperacionesTipoES ;
      private bool n570OperacionesImporte ;
      private bool n572OperacionesFacturaCod ;
      private bool n580OperacionesComprobantePago ;
      private bool n581OperacionesFechaAlta ;
      private bool n658OperacionesFechaDesde ;
      private bool n659OperacionesFechaHasta ;
      private bool n582OperacionesFechaPago ;
      private bool n577OperacionesEstado ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV86TempBoolean ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool GXt_boolean1 ;
      private bool AV111DiscardFirst ;
      private string AV101TFOperacionesTipo_SelsJson ;
      private string AV73TFOperacionesEstado_SelsJson ;
      private string AV33ColumnsSelectorXML ;
      private string AV39ManageFiltersXml ;
      private string AV34UserCustomValue ;
      private string AV17FilterFullText ;
      private string AV79GridAppliedFilters ;
      private string AV105Grid_GroupCaption ;
      private string AV121Operacioneswwds_1_filterfulltext ;
      private string AV31ExcelFilename ;
      private string AV32ErrorMessage ;
      private IGxSession AV37Session ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_liquidaciones ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucDdc_subscriptions ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_titlescategories ;
      private GXUserControl ucGrid_group ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDdo_managefilters ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavGridactions ;
      private GXCombobox cmbOperacionesTipo ;
      private GXCombobox cmbOperacionesTipoES ;
      private GXCombobox cmbOperacionesEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV35ColumnsSelector ;
      private GxSimpleCollection<string> AV102TFOperacionesTipo_Sels ;
      private GxSimpleCollection<string> AV74TFOperacionesEstado_Sels ;
      private GxSimpleCollection<string> AV108GridCollapsedRecords ;
      private GxSimpleCollection<long> AV107GridCollapsedRecordsChildren ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV38ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV103LiquidacionesData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV84AGExportData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV75DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GxSimpleCollection<string> AV122Operacioneswwds_2_tfoperacionestipo_sels ;
      private GxSimpleCollection<string> AV133Operacioneswwds_13_tfoperacionesestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] H005E2_A577OperacionesEstado ;
      private bool[] H005E2_n577OperacionesEstado ;
      private DateTime[] H005E2_A582OperacionesFechaPago ;
      private bool[] H005E2_n582OperacionesFechaPago ;
      private DateTime[] H005E2_A659OperacionesFechaHasta ;
      private bool[] H005E2_n659OperacionesFechaHasta ;
      private DateTime[] H005E2_A658OperacionesFechaDesde ;
      private bool[] H005E2_n658OperacionesFechaDesde ;
      private DateTime[] H005E2_A581OperacionesFechaAlta ;
      private bool[] H005E2_n581OperacionesFechaAlta ;
      private string[] H005E2_A580OperacionesComprobantePago ;
      private bool[] H005E2_n580OperacionesComprobantePago ;
      private string[] H005E2_A572OperacionesFacturaCod ;
      private bool[] H005E2_n572OperacionesFacturaCod ;
      private decimal[] H005E2_A570OperacionesImporte ;
      private bool[] H005E2_n570OperacionesImporte ;
      private string[] H005E2_A569OperacionesTipoES ;
      private bool[] H005E2_n569OperacionesTipoES ;
      private string[] H005E2_A649OperacionesTipo ;
      private bool[] H005E2_n649OperacionesTipo ;
      private string[] H005E2_A657OperacionesNombreRef ;
      private bool[] H005E2_n657OperacionesNombreRef ;
      private string[] H005E2_A555OperacionesRef ;
      private bool[] H005E2_n555OperacionesRef ;
      private long[] H005E2_A554OperacionesId ;
      private string[] H005E3_A577OperacionesEstado ;
      private bool[] H005E3_n577OperacionesEstado ;
      private DateTime[] H005E3_A582OperacionesFechaPago ;
      private bool[] H005E3_n582OperacionesFechaPago ;
      private DateTime[] H005E3_A659OperacionesFechaHasta ;
      private bool[] H005E3_n659OperacionesFechaHasta ;
      private DateTime[] H005E3_A658OperacionesFechaDesde ;
      private bool[] H005E3_n658OperacionesFechaDesde ;
      private DateTime[] H005E3_A581OperacionesFechaAlta ;
      private bool[] H005E3_n581OperacionesFechaAlta ;
      private string[] H005E3_A580OperacionesComprobantePago ;
      private bool[] H005E3_n580OperacionesComprobantePago ;
      private string[] H005E3_A572OperacionesFacturaCod ;
      private bool[] H005E3_n572OperacionesFacturaCod ;
      private decimal[] H005E3_A570OperacionesImporte ;
      private bool[] H005E3_n570OperacionesImporte ;
      private string[] H005E3_A569OperacionesTipoES ;
      private bool[] H005E3_n569OperacionesTipoES ;
      private string[] H005E3_A649OperacionesTipo ;
      private bool[] H005E3_n649OperacionesTipo ;
      private string[] H005E3_A657OperacionesNombreRef ;
      private bool[] H005E3_n657OperacionesNombreRef ;
      private string[] H005E3_A555OperacionesRef ;
      private bool[] H005E3_n555OperacionesRef ;
      private long[] H005E3_A554OperacionesId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV104LiquidacionesDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV85AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV36ColumnsSelectorAux ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV110OldGridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private string[] H005E4_A572OperacionesFacturaCod ;
      private bool[] H005E4_n572OperacionesFacturaCod ;
      private decimal[] H005E4_A570OperacionesImporte ;
      private bool[] H005E4_n570OperacionesImporte ;
      private string[] H005E4_A657OperacionesNombreRef ;
      private bool[] H005E4_n657OperacionesNombreRef ;
      private string[] H005E4_A555OperacionesRef ;
      private bool[] H005E4_n555OperacionesRef ;
      private long[] H005E4_A554OperacionesId ;
      private DateTime[] H005E4_A659OperacionesFechaHasta ;
      private bool[] H005E4_n659OperacionesFechaHasta ;
      private DateTime[] H005E4_A658OperacionesFechaDesde ;
      private bool[] H005E4_n658OperacionesFechaDesde ;
      private string[] H005E4_A580OperacionesComprobantePago ;
      private bool[] H005E4_n580OperacionesComprobantePago ;
      private string[] H005E4_A577OperacionesEstado ;
      private bool[] H005E4_n577OperacionesEstado ;
      private string[] H005E4_A569OperacionesTipoES ;
      private bool[] H005E4_n569OperacionesTipoES ;
      private string[] H005E4_A649OperacionesTipo ;
      private bool[] H005E4_n649OperacionesTipo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class operacionesww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H005E2( IGxContext context ,
                                             string A649OperacionesTipo ,
                                             GxSimpleCollection<string> AV122Operacioneswwds_2_tfoperacionestipo_sels ,
                                             string A577OperacionesEstado ,
                                             GxSimpleCollection<string> AV133Operacioneswwds_13_tfoperacionesestado_sels ,
                                             long A554OperacionesId ,
                                             GxSimpleCollection<long> AV107GridCollapsedRecordsChildren ,
                                             int AV122Operacioneswwds_2_tfoperacionestipo_sels_Count ,
                                             string AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel ,
                                             string AV123Operacioneswwds_3_tfoperacionescomprobantepago ,
                                             DateTime AV127Operacioneswwds_7_tfoperacionesfechadesde ,
                                             DateTime AV128Operacioneswwds_8_tfoperacionesfechadesde_to ,
                                             DateTime AV129Operacioneswwds_9_tfoperacionesfechahasta ,
                                             DateTime AV130Operacioneswwds_10_tfoperacionesfechahasta_to ,
                                             int AV133Operacioneswwds_13_tfoperacionesestado_sels_Count ,
                                             int AV107GridCollapsedRecordsChildren_Count ,
                                             string A580OperacionesComprobantePago ,
                                             DateTime A658OperacionesFechaDesde ,
                                             DateTime A659OperacionesFechaHasta ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV121Operacioneswwds_1_filterfulltext ,
                                             string A555OperacionesRef ,
                                             string A657OperacionesNombreRef ,
                                             string A569OperacionesTipoES ,
                                             decimal A570OperacionesImporte ,
                                             string A572OperacionesFacturaCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[6];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT [OperacionesEstado], [OperacionesFechaPago], [OperacionesFechaHasta], [OperacionesFechaDesde], [OperacionesFechaAlta], [OperacionesComprobantePago], [OperacionesFacturaCod], [OperacionesImporte], [OperacionesTipoES], [OperacionesTipo], [OperacionesNombreRef], [OperacionesRef], [OperacionesId] FROM [Operaciones]";
         if ( AV122Operacioneswwds_2_tfoperacionestipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV122Operacioneswwds_2_tfoperacionestipo_sels, "[OperacionesTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Operacioneswwds_3_tfoperacionescomprobantepago)) ) )
         {
            AddWhere(sWhereString, "(UPPER([OperacionesComprobantePago]) like UPPER(@lV123Operacioneswwds_3_tfoperacionescomprobantepago))");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel)) && ! ( StringUtil.StrCmp(AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([OperacionesComprobantePago] = @AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( StringUtil.StrCmp(AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([OperacionesComprobantePago] IS NULL or ([OperacionesComprobantePago] = ''))");
         }
         if ( ! (DateTime.MinValue==AV127Operacioneswwds_7_tfoperacionesfechadesde) )
         {
            AddWhere(sWhereString, "([OperacionesFechaDesde] >= @AV127Operacioneswwds_7_tfoperacionesfechadesde)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV128Operacioneswwds_8_tfoperacionesfechadesde_to) )
         {
            AddWhere(sWhereString, "([OperacionesFechaDesde] <= @AV128Operacioneswwds_8_tfoperacionesfechadesde_to)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV129Operacioneswwds_9_tfoperacionesfechahasta) )
         {
            AddWhere(sWhereString, "([OperacionesFechaHasta] >= @AV129Operacioneswwds_9_tfoperacionesfechahasta)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV130Operacioneswwds_10_tfoperacionesfechahasta_to) )
         {
            AddWhere(sWhereString, "([OperacionesFechaHasta] <= @AV130Operacioneswwds_10_tfoperacionesfechahasta_to)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( AV133Operacioneswwds_13_tfoperacionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV133Operacioneswwds_13_tfoperacionesestado_sels, "[OperacionesEstado] IN (", ")")+")");
         }
         if ( AV107GridCollapsedRecordsChildren_Count > 0 )
         {
            AddWhere(sWhereString, "(Not ( "+new GxDbmsUtils( new GxSqlServer()).ValueList(AV107GridCollapsedRecordsChildren, "[OperacionesId] IN (", ")")+"))");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesId]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesId] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesRef]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesRef] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesNombreRef]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesNombreRef] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesTipoES]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesTipoES] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesImporte]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesImporte] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesFacturaCod]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesFacturaCod] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesComprobantePago]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesComprobantePago] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesFechaAlta]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesFechaAlta] DESC";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesFechaDesde]";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesFechaDesde] DESC";
         }
         else if ( ( AV14OrderedBy == 11 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesFechaHasta]";
         }
         else if ( ( AV14OrderedBy == 11 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesFechaHasta] DESC";
         }
         else if ( ( AV14OrderedBy == 12 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesFechaPago]";
         }
         else if ( ( AV14OrderedBy == 12 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesFechaPago] DESC";
         }
         else if ( ( AV14OrderedBy == 13 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesEstado]";
         }
         else if ( ( AV14OrderedBy == 13 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesEstado] DESC";
         }
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_H005E3( IGxContext context ,
                                             string A649OperacionesTipo ,
                                             GxSimpleCollection<string> AV122Operacioneswwds_2_tfoperacionestipo_sels ,
                                             string A577OperacionesEstado ,
                                             GxSimpleCollection<string> AV133Operacioneswwds_13_tfoperacionesestado_sels ,
                                             long A554OperacionesId ,
                                             GxSimpleCollection<long> AV107GridCollapsedRecordsChildren ,
                                             int AV122Operacioneswwds_2_tfoperacionestipo_sels_Count ,
                                             string AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel ,
                                             string AV123Operacioneswwds_3_tfoperacionescomprobantepago ,
                                             DateTime AV127Operacioneswwds_7_tfoperacionesfechadesde ,
                                             DateTime AV128Operacioneswwds_8_tfoperacionesfechadesde_to ,
                                             DateTime AV129Operacioneswwds_9_tfoperacionesfechahasta ,
                                             DateTime AV130Operacioneswwds_10_tfoperacionesfechahasta_to ,
                                             int AV133Operacioneswwds_13_tfoperacionesestado_sels_Count ,
                                             int AV107GridCollapsedRecordsChildren_Count ,
                                             string A580OperacionesComprobantePago ,
                                             DateTime A658OperacionesFechaDesde ,
                                             DateTime A659OperacionesFechaHasta ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV121Operacioneswwds_1_filterfulltext ,
                                             string A555OperacionesRef ,
                                             string A657OperacionesNombreRef ,
                                             string A569OperacionesTipoES ,
                                             decimal A570OperacionesImporte ,
                                             string A572OperacionesFacturaCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[6];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT [OperacionesEstado], [OperacionesFechaPago], [OperacionesFechaHasta], [OperacionesFechaDesde], [OperacionesFechaAlta], [OperacionesComprobantePago], [OperacionesFacturaCod], [OperacionesImporte], [OperacionesTipoES], [OperacionesTipo], [OperacionesNombreRef], [OperacionesRef], [OperacionesId] FROM [Operaciones]";
         if ( AV122Operacioneswwds_2_tfoperacionestipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV122Operacioneswwds_2_tfoperacionestipo_sels, "[OperacionesTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Operacioneswwds_3_tfoperacionescomprobantepago)) ) )
         {
            AddWhere(sWhereString, "(UPPER([OperacionesComprobantePago]) like UPPER(@lV123Operacioneswwds_3_tfoperacionescomprobantepago))");
         }
         else
         {
            GXv_int9[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel)) && ! ( StringUtil.StrCmp(AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([OperacionesComprobantePago] = @AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel)");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( StringUtil.StrCmp(AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([OperacionesComprobantePago] IS NULL or ([OperacionesComprobantePago] = ''))");
         }
         if ( ! (DateTime.MinValue==AV127Operacioneswwds_7_tfoperacionesfechadesde) )
         {
            AddWhere(sWhereString, "([OperacionesFechaDesde] >= @AV127Operacioneswwds_7_tfoperacionesfechadesde)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV128Operacioneswwds_8_tfoperacionesfechadesde_to) )
         {
            AddWhere(sWhereString, "([OperacionesFechaDesde] <= @AV128Operacioneswwds_8_tfoperacionesfechadesde_to)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV129Operacioneswwds_9_tfoperacionesfechahasta) )
         {
            AddWhere(sWhereString, "([OperacionesFechaHasta] >= @AV129Operacioneswwds_9_tfoperacionesfechahasta)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV130Operacioneswwds_10_tfoperacionesfechahasta_to) )
         {
            AddWhere(sWhereString, "([OperacionesFechaHasta] <= @AV130Operacioneswwds_10_tfoperacionesfechahasta_to)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( AV133Operacioneswwds_13_tfoperacionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV133Operacioneswwds_13_tfoperacionesestado_sels, "[OperacionesEstado] IN (", ")")+")");
         }
         if ( AV107GridCollapsedRecordsChildren_Count > 0 )
         {
            AddWhere(sWhereString, "(Not ( "+new GxDbmsUtils( new GxSqlServer()).ValueList(AV107GridCollapsedRecordsChildren, "[OperacionesId] IN (", ")")+"))");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesId]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesId] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesRef]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesRef] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesNombreRef]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesNombreRef] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesTipoES]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesTipoES] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesImporte]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesImporte] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesFacturaCod]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesFacturaCod] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesComprobantePago]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesComprobantePago] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesFechaAlta]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesFechaAlta] DESC";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesFechaDesde]";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesFechaDesde] DESC";
         }
         else if ( ( AV14OrderedBy == 11 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesFechaHasta]";
         }
         else if ( ( AV14OrderedBy == 11 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesFechaHasta] DESC";
         }
         else if ( ( AV14OrderedBy == 12 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesFechaPago]";
         }
         else if ( ( AV14OrderedBy == 12 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesFechaPago] DESC";
         }
         else if ( ( AV14OrderedBy == 13 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesEstado]";
         }
         else if ( ( AV14OrderedBy == 13 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesEstado] DESC";
         }
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_H005E4( IGxContext context ,
                                             string A649OperacionesTipo ,
                                             GxSimpleCollection<string> AV122Operacioneswwds_2_tfoperacionestipo_sels ,
                                             string A577OperacionesEstado ,
                                             GxSimpleCollection<string> AV133Operacioneswwds_13_tfoperacionesestado_sels ,
                                             int AV122Operacioneswwds_2_tfoperacionestipo_sels_Count ,
                                             string AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel ,
                                             string AV123Operacioneswwds_3_tfoperacionescomprobantepago ,
                                             DateTime AV127Operacioneswwds_7_tfoperacionesfechadesde ,
                                             DateTime AV128Operacioneswwds_8_tfoperacionesfechadesde_to ,
                                             DateTime AV129Operacioneswwds_9_tfoperacionesfechahasta ,
                                             DateTime AV130Operacioneswwds_10_tfoperacionesfechahasta_to ,
                                             int AV133Operacioneswwds_13_tfoperacionesestado_sels_Count ,
                                             string AV106GroupOperacionesTipo ,
                                             string A580OperacionesComprobantePago ,
                                             DateTime A658OperacionesFechaDesde ,
                                             DateTime A659OperacionesFechaHasta ,
                                             string AV121Operacioneswwds_1_filterfulltext ,
                                             long A554OperacionesId ,
                                             string A555OperacionesRef ,
                                             string A657OperacionesNombreRef ,
                                             string A569OperacionesTipoES ,
                                             decimal A570OperacionesImporte ,
                                             string A572OperacionesFacturaCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[7];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT [OperacionesFacturaCod], [OperacionesImporte], [OperacionesNombreRef], [OperacionesRef], [OperacionesId], [OperacionesFechaHasta], [OperacionesFechaDesde], [OperacionesComprobantePago], [OperacionesEstado], [OperacionesTipoES], [OperacionesTipo] FROM [Operaciones]";
         if ( AV122Operacioneswwds_2_tfoperacionestipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV122Operacioneswwds_2_tfoperacionestipo_sels, "[OperacionesTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Operacioneswwds_3_tfoperacionescomprobantepago)) ) )
         {
            AddWhere(sWhereString, "(UPPER([OperacionesComprobantePago]) like UPPER(@lV123Operacioneswwds_3_tfoperacionescomprobantepago))");
         }
         else
         {
            GXv_int11[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel)) && ! ( StringUtil.StrCmp(AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([OperacionesComprobantePago] = @AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel)");
         }
         else
         {
            GXv_int11[1] = 1;
         }
         if ( StringUtil.StrCmp(AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([OperacionesComprobantePago] IS NULL or ([OperacionesComprobantePago] = ''))");
         }
         if ( ! (DateTime.MinValue==AV127Operacioneswwds_7_tfoperacionesfechadesde) )
         {
            AddWhere(sWhereString, "([OperacionesFechaDesde] >= @AV127Operacioneswwds_7_tfoperacionesfechadesde)");
         }
         else
         {
            GXv_int11[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV128Operacioneswwds_8_tfoperacionesfechadesde_to) )
         {
            AddWhere(sWhereString, "([OperacionesFechaDesde] <= @AV128Operacioneswwds_8_tfoperacionesfechadesde_to)");
         }
         else
         {
            GXv_int11[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV129Operacioneswwds_9_tfoperacionesfechahasta) )
         {
            AddWhere(sWhereString, "([OperacionesFechaHasta] >= @AV129Operacioneswwds_9_tfoperacionesfechahasta)");
         }
         else
         {
            GXv_int11[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV130Operacioneswwds_10_tfoperacionesfechahasta_to) )
         {
            AddWhere(sWhereString, "([OperacionesFechaHasta] <= @AV130Operacioneswwds_10_tfoperacionesfechahasta_to)");
         }
         else
         {
            GXv_int11[5] = 1;
         }
         if ( AV133Operacioneswwds_13_tfoperacionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV133Operacioneswwds_13_tfoperacionesestado_sels, "[OperacionesEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106GroupOperacionesTipo)) )
         {
            AddWhere(sWhereString, "([OperacionesTipo] IS NULL)");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106GroupOperacionesTipo)) )
         {
            AddWhere(sWhereString, "([OperacionesTipo] = @AV106GroupOperacionesTipo)");
         }
         else
         {
            GXv_int11[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [OperacionesId]";
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H005E2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (long)dynConstraints[4] , (GxSimpleCollection<long>)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (decimal)dynConstraints[24] , (string)dynConstraints[25] );
               case 1 :
                     return conditional_H005E3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (long)dynConstraints[4] , (GxSimpleCollection<long>)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (decimal)dynConstraints[24] , (string)dynConstraints[25] );
               case 2 :
                     return conditional_H005E4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (string)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (decimal)dynConstraints[21] , (string)dynConstraints[22] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH005E2;
          prmH005E2 = new Object[] {
          new ParDef("@lV123Operacioneswwds_3_tfoperacionescomprobantepago",GXType.Char,256,0) ,
          new ParDef("@AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel",GXType.NChar,256,0) ,
          new ParDef("@AV127Operacioneswwds_7_tfoperacionesfechadesde",GXType.Date,8,0) ,
          new ParDef("@AV128Operacioneswwds_8_tfoperacionesfechadesde_to",GXType.Date,8,0) ,
          new ParDef("@AV129Operacioneswwds_9_tfoperacionesfechahasta",GXType.Date,8,0) ,
          new ParDef("@AV130Operacioneswwds_10_tfoperacionesfechahasta_to",GXType.Date,8,0)
          };
          Object[] prmH005E3;
          prmH005E3 = new Object[] {
          new ParDef("@lV123Operacioneswwds_3_tfoperacionescomprobantepago",GXType.Char,256,0) ,
          new ParDef("@AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel",GXType.NChar,256,0) ,
          new ParDef("@AV127Operacioneswwds_7_tfoperacionesfechadesde",GXType.Date,8,0) ,
          new ParDef("@AV128Operacioneswwds_8_tfoperacionesfechadesde_to",GXType.Date,8,0) ,
          new ParDef("@AV129Operacioneswwds_9_tfoperacionesfechahasta",GXType.Date,8,0) ,
          new ParDef("@AV130Operacioneswwds_10_tfoperacionesfechahasta_to",GXType.Date,8,0)
          };
          Object[] prmH005E4;
          prmH005E4 = new Object[] {
          new ParDef("@lV123Operacioneswwds_3_tfoperacionescomprobantepago",GXType.Char,256,0) ,
          new ParDef("@AV124Operacioneswwds_4_tfoperacionescomprobantepago_sel",GXType.NChar,256,0) ,
          new ParDef("@AV127Operacioneswwds_7_tfoperacionesfechadesde",GXType.Date,8,0) ,
          new ParDef("@AV128Operacioneswwds_8_tfoperacionesfechadesde_to",GXType.Date,8,0) ,
          new ParDef("@AV129Operacioneswwds_9_tfoperacionesfechahasta",GXType.Date,8,0) ,
          new ParDef("@AV130Operacioneswwds_10_tfoperacionesfechahasta_to",GXType.Date,8,0) ,
          new ParDef("@AV106GroupOperacionesTipo",GXType.NChar,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005E2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005E3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005E3,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005E4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005E4,11, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getString(6, 256);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getString(7, 25);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getString(9, 1);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getString(10, 3);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getString(11, 120);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getString(12, 25);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((long[]) buf[24])[0] = rslt.getLong(13);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getString(6, 256);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getString(7, 25);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getString(9, 1);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getString(10, 3);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getString(11, 120);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getString(12, 25);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((long[]) buf[24])[0] = rslt.getLong(13);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 25);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 120);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 25);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((long[]) buf[8])[0] = rslt.getLong(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getString(8, 256);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getString(9, 3);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getString(10, 1);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getString(11, 3);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
       }
    }

 }

}
