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
   public class bancoproveedorwc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public bancoproveedorwc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
      }

      public bancoproveedorwc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_BancoId )
      {
         this.AV8BancoId = aP0_BancoId;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         cmbProveedorPerAltShop = new GXCombobox();
         cmbProveedorEstado = new GXCombobox();
         cmbProveedorPagoDefault = new GXCombobox();
         cmbProveedorPideDoc = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "BancoId");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  AV8BancoId = (long)(Math.Round(NumberUtil.Val( GetPar( "BancoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV8BancoId", StringUtil.LTrimStr( (decimal)(AV8BancoId), 18, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)AV8BancoId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetFirstPar( "BancoId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "BancoId");
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_37 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_37"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_37_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_37_idx = GetPar( "sGXsfl_37_idx");
         sPrefix = GetPar( "sPrefix");
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
         AV16FilterFullText = GetPar( "FilterFullText");
         AV8BancoId = (long)(Math.Round(NumberUtil.Val( GetPar( "BancoId"), "."), 18, MidpointRounding.ToEven));
         AV20ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV32Pgmname = GetPar( "Pgmname");
         AV28IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV30IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8BancoId, AV20ManageFiltersExecutionStep, AV32Pgmname, AV28IsAuthorized_Update, AV30IsAuthorized_Delete, sPrefix) ;
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PABH2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV32Pgmname = "BancoProveedorWC";
               edtavUpdate_Enabled = 0;
               AssignProp(sPrefix, false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_37_Refreshing);
               edtavDelete_Enabled = 0;
               AssignProp(sPrefix, false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_37_Refreshing);
               WSBH2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( context.GetMessage( "Banco Proveedor WC", "")) ;
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
         }
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
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "bancoproveedorwc.aspx"+UrlEncode(StringUtil.LTrimStr(AV8BancoId,18,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("bancoproveedorwc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV32Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV32Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV28IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV28IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV30IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV30IsAuthorized_Delete, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDDSC", StringUtil.BoolToStr( AV15OrderedDsc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vFILTERFULLTEXT", AV16FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_37", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_37), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMANAGEFILTERSDATA", AV18ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMANAGEFILTERSDATA", AV18ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDAPPLIEDFILTERS", AV26GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV21DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV21DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8BancoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV8BancoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV32Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV32Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV15OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV28IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV28IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV30IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV30IsAuthorized_Delete, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDSTATE", AV12GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDSTATE", AV12GridState);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vBANCOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8BancoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseFormBH2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "BancoProveedorWC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Banco Proveedor WC", "") ;
      }

      protected void WBBH0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "bancoproveedorwc.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
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
            GxWebStd.gx_div_start( context, divTablegridheader_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_BancoProveedorWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_22_BH2( true) ;
         }
         else
         {
            wb_table1_22_BH2( false) ;
         }
         return  ;
      }

      protected void wb_table1_22_BH2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl37( ) ;
         }
         if ( wbEnd == 37 )
         {
            wbEnd = 0;
            nRC_GXsfl_37 = (int)(nGXsfl_37_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV24GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV25GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV26GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, sPrefix+"GRIDPAGINATIONBARContainer");
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
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV21DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtBancoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A673BancoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A673BancoId), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBancoId_Jsonclick, 0, "Attribute", "", "", "", "", edtBancoId_Visible, 0, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_BancoProveedorWC.htm");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 37 )
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
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void STARTBH2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GXKey = Crypto.GetSiteKey( );
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET Framework 18_0_15-188745", 0) ;
               }
            }
            Form.Meta.addItem("description", context.GetMessage( "Banco Proveedor WC", ""), 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUPBH0( ) ;
            }
         }
      }

      protected void WSBH2( )
      {
         STARTBH2( ) ;
         EVTBH2( ) ;
      }

      protected void EVTBH2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBH0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBH0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_managefilters.Onoptionclicked */
                                    E11BH2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBH0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E12BH2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBH0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E13BH2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBH0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E14BH2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBH0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoInsert' */
                                    E15BH2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBH0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavFilterfulltext_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPBH0( ) ;
                              }
                              nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
                              SubsflControlProps_372( ) ;
                              AV27Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri(sPrefix, false, edtavUpdate_Internalname, AV27Update);
                              AV29Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri(sPrefix, false, edtavDelete_Internalname, AV29Delete);
                              A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A151ProveedoresTipoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedoresTipoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A278ProveedoresTipoNombre = cgiGet( edtProveedoresTipoNombre_Internalname);
                              A282ProveedorNombre = cgiGet( edtProveedorNombre_Internalname);
                              A682ProveedorRazonSocial = cgiGet( edtProveedorRazonSocial_Internalname);
                              n682ProveedorRazonSocial = false;
                              A683ProveedorContacto = cgiGet( edtProveedorContacto_Internalname);
                              n683ProveedorContacto = false;
                              A684ProveedorContactoCell = cgiGet( edtProveedorContactoCell_Internalname);
                              n684ProveedorContactoCell = false;
                              A432ProveedorImagen = cgiGet( edtProveedorImagen_Internalname);
                              n432ProveedorImagen = false;
                              AssignProp(sPrefix, false, edtProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), !bGXsfl_37_Refreshing);
                              AssignProp(sPrefix, false, edtProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
                              A338ProveedorDocIdentidad = cgiGet( edtProveedorDocIdentidad_Internalname);
                              A345ProveedorSerialComi = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorSerialComi_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A430ProveedorTelefono = cgiGet( edtProveedorTelefono_Internalname);
                              n430ProveedorTelefono = false;
                              A431ProveedorDireccion = cgiGet( edtProveedorDireccion_Internalname);
                              n431ProveedorDireccion = false;
                              A433ProveedorEmail = cgiGet( edtProveedorEmail_Internalname);
                              n433ProveedorEmail = false;
                              A685ProveedorSitioWeb = cgiGet( edtProveedorSitioWeb_Internalname);
                              n685ProveedorSitioWeb = false;
                              A686ProveedorAceptoTerminos = context.localUtil.CToT( cgiGet( edtProveedorAceptoTerminos_Internalname), 0);
                              n686ProveedorAceptoTerminos = false;
                              cmbProveedorPerAltShop.Name = cmbProveedorPerAltShop_Internalname;
                              cmbProveedorPerAltShop.CurrentValue = cgiGet( cmbProveedorPerAltShop_Internalname);
                              A437ProveedorPerAltShop = cgiGet( cmbProveedorPerAltShop_Internalname);
                              n437ProveedorPerAltShop = false;
                              cmbProveedorEstado.Name = cmbProveedorEstado_Internalname;
                              cmbProveedorEstado.CurrentValue = cgiGet( cmbProveedorEstado_Internalname);
                              A344ProveedorEstado = cgiGet( cmbProveedorEstado_Internalname);
                              cmbProveedorPagoDefault.Name = cmbProveedorPagoDefault_Internalname;
                              cmbProveedorPagoDefault.CurrentValue = cgiGet( cmbProveedorPagoDefault_Internalname);
                              A440ProveedorPagoDefault = cgiGet( cmbProveedorPagoDefault_Internalname);
                              cmbProveedorPideDoc.Name = cmbProveedorPideDoc_Internalname;
                              cmbProveedorPideDoc.CurrentValue = cgiGet( cmbProveedorPideDoc_Internalname);
                              A490ProveedorPideDoc = cgiGet( cmbProveedorPideDoc_Internalname);
                              n490ProveedorPideDoc = false;
                              A488DocumentacionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDocumentacionId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n488DocumentacionId = false;
                              A498DocumentacionIcono = cgiGet( edtDocumentacionIcono_Internalname);
                              AssignProp(sPrefix, false, edtDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), !bGXsfl_37_Refreshing);
                              AssignProp(sPrefix, false, edtDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
                              A546ProveedorUsrAlta = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorUsrAlta_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n546ProveedorUsrAlta = false;
                              A547ProveedorUsrActualizacion = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorUsrActualizacion_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n547ProveedorUsrActualizacion = false;
                              A548ProveedorFechaAlta = context.localUtil.CToT( cgiGet( edtProveedorFechaAlta_Internalname), 0);
                              n548ProveedorFechaAlta = false;
                              A549ProveedorFechaActualizacion = context.localUtil.CToT( cgiGet( edtProveedorFechaActualizacion_Internalname), 0);
                              n549ProveedorFechaActualizacion = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E16BH2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E17BH2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E18BH2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          if ( ! wbErr )
                                          {
                                             Rfr0gs = false;
                                             /* Set Refresh If Orderedby Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV14OrderedBy )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Ordereddsc Changed */
                                             if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV15OrderedDsc )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Filterfulltext Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV16FilterFullText) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             if ( ! Rfr0gs )
                                             {
                                             }
                                             dynload_actions( ) ;
                                          }
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUPBH0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WEBH2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseFormBH2( ) ;
            }
         }
      }

      protected void PABH2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Crypto.GetSiteKey( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
               {
                  GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "bancoproveedorwc.aspx")), "bancoproveedorwc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "bancoproveedorwc.aspx")))) ;
                  }
                  else
                  {
                     GxWebError = 1;
                     context.HttpContext.Response.StatusDescription = 403.ToString();
                     context.HttpContext.Response.StatusCode = 403;
                     context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                     context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                     context.WriteHtmlText( "<p /><hr />") ;
                     GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  }
               }
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  if ( nGotPars == 0 )
                  {
                     entryPointCalled = false;
                     gxfirstwebparm = GetFirstPar( "BancoId");
                     toggleJsOutput = isJsOutputEnabled( );
                     if ( context.isSpaRequest( ) )
                     {
                        disableJsOutput();
                     }
                     if ( toggleJsOutput )
                     {
                        if ( context.isSpaRequest( ) )
                        {
                           enableJsOutput();
                        }
                     }
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavFilterfulltext_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
         SubsflControlProps_372( ) ;
         while ( nGXsfl_37_idx <= nRC_GXsfl_37 )
         {
            sendrow_372( ) ;
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       string AV16FilterFullText ,
                                       long AV8BancoId ,
                                       short AV20ManageFiltersExecutionStep ,
                                       string AV32Pgmname ,
                                       bool AV28IsAuthorized_Update ,
                                       bool AV30IsAuthorized_Delete ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFBH2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_PROVEEDORID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"PROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, ".", "")));
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
         RFBH2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV32Pgmname = "BancoProveedorWC";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              AV16FilterFullText ,
                                              A133ProveedorID ,
                                              A151ProveedoresTipoId ,
                                              A278ProveedoresTipoNombre ,
                                              A282ProveedorNombre ,
                                              A682ProveedorRazonSocial ,
                                              A683ProveedorContacto ,
                                              A684ProveedorContactoCell ,
                                              A338ProveedorDocIdentidad ,
                                              A430ProveedorTelefono ,
                                              A431ProveedorDireccion ,
                                              A433ProveedorEmail ,
                                              A685ProveedorSitioWeb ,
                                              A344ProveedorEstado ,
                                              A440ProveedorPagoDefault ,
                                              A546ProveedorUsrAlta ,
                                              A547ProveedorUsrActualizacion ,
                                              AV8BancoId ,
                                              A673BancoId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor H00BH2 */
         pr_default.execute(0, new Object[] {AV8BancoId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A673BancoId = H00BH2_A673BancoId[0];
            n673BancoId = H00BH2_n673BancoId[0];
            AssignAttri(sPrefix, false, "A673BancoId", StringUtil.LTrimStr( (decimal)(A673BancoId), 18, 0));
            A549ProveedorFechaActualizacion = H00BH2_A549ProveedorFechaActualizacion[0];
            n549ProveedorFechaActualizacion = H00BH2_n549ProveedorFechaActualizacion[0];
            A548ProveedorFechaAlta = H00BH2_A548ProveedorFechaAlta[0];
            n548ProveedorFechaAlta = H00BH2_n548ProveedorFechaAlta[0];
            A547ProveedorUsrActualizacion = H00BH2_A547ProveedorUsrActualizacion[0];
            n547ProveedorUsrActualizacion = H00BH2_n547ProveedorUsrActualizacion[0];
            A546ProveedorUsrAlta = H00BH2_A546ProveedorUsrAlta[0];
            n546ProveedorUsrAlta = H00BH2_n546ProveedorUsrAlta[0];
            A40001DocumentacionIcono_GXI = H00BH2_A40001DocumentacionIcono_GXI[0];
            AssignProp(sPrefix, false, edtDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), !bGXsfl_37_Refreshing);
            AssignProp(sPrefix, false, edtDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
            A488DocumentacionId = H00BH2_A488DocumentacionId[0];
            n488DocumentacionId = H00BH2_n488DocumentacionId[0];
            A490ProveedorPideDoc = H00BH2_A490ProveedorPideDoc[0];
            n490ProveedorPideDoc = H00BH2_n490ProveedorPideDoc[0];
            A440ProveedorPagoDefault = H00BH2_A440ProveedorPagoDefault[0];
            A344ProveedorEstado = H00BH2_A344ProveedorEstado[0];
            A437ProveedorPerAltShop = H00BH2_A437ProveedorPerAltShop[0];
            n437ProveedorPerAltShop = H00BH2_n437ProveedorPerAltShop[0];
            A686ProveedorAceptoTerminos = H00BH2_A686ProveedorAceptoTerminos[0];
            n686ProveedorAceptoTerminos = H00BH2_n686ProveedorAceptoTerminos[0];
            A685ProveedorSitioWeb = H00BH2_A685ProveedorSitioWeb[0];
            n685ProveedorSitioWeb = H00BH2_n685ProveedorSitioWeb[0];
            A433ProveedorEmail = H00BH2_A433ProveedorEmail[0];
            n433ProveedorEmail = H00BH2_n433ProveedorEmail[0];
            A431ProveedorDireccion = H00BH2_A431ProveedorDireccion[0];
            n431ProveedorDireccion = H00BH2_n431ProveedorDireccion[0];
            A430ProveedorTelefono = H00BH2_A430ProveedorTelefono[0];
            n430ProveedorTelefono = H00BH2_n430ProveedorTelefono[0];
            A345ProveedorSerialComi = H00BH2_A345ProveedorSerialComi[0];
            A338ProveedorDocIdentidad = H00BH2_A338ProveedorDocIdentidad[0];
            A40000ProveedorImagen_GXI = H00BH2_A40000ProveedorImagen_GXI[0];
            n40000ProveedorImagen_GXI = H00BH2_n40000ProveedorImagen_GXI[0];
            AssignProp(sPrefix, false, edtProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), !bGXsfl_37_Refreshing);
            AssignProp(sPrefix, false, edtProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
            A684ProveedorContactoCell = H00BH2_A684ProveedorContactoCell[0];
            n684ProveedorContactoCell = H00BH2_n684ProveedorContactoCell[0];
            A683ProveedorContacto = H00BH2_A683ProveedorContacto[0];
            n683ProveedorContacto = H00BH2_n683ProveedorContacto[0];
            A682ProveedorRazonSocial = H00BH2_A682ProveedorRazonSocial[0];
            n682ProveedorRazonSocial = H00BH2_n682ProveedorRazonSocial[0];
            A282ProveedorNombre = H00BH2_A282ProveedorNombre[0];
            A278ProveedoresTipoNombre = H00BH2_A278ProveedoresTipoNombre[0];
            A151ProveedoresTipoId = H00BH2_A151ProveedoresTipoId[0];
            A133ProveedorID = H00BH2_A133ProveedorID[0];
            A498DocumentacionIcono = H00BH2_A498DocumentacionIcono[0];
            AssignProp(sPrefix, false, edtDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), !bGXsfl_37_Refreshing);
            AssignProp(sPrefix, false, edtDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
            A432ProveedorImagen = H00BH2_A432ProveedorImagen[0];
            n432ProveedorImagen = H00BH2_n432ProveedorImagen[0];
            AssignProp(sPrefix, false, edtProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), !bGXsfl_37_Refreshing);
            AssignProp(sPrefix, false, edtProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
            A40001DocumentacionIcono_GXI = H00BH2_A40001DocumentacionIcono_GXI[0];
            AssignProp(sPrefix, false, edtDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), !bGXsfl_37_Refreshing);
            AssignProp(sPrefix, false, edtDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
            A498DocumentacionIcono = H00BH2_A498DocumentacionIcono[0];
            AssignProp(sPrefix, false, edtDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), !bGXsfl_37_Refreshing);
            AssignProp(sPrefix, false, edtDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
            A278ProveedoresTipoNombre = H00BH2_A278ProveedoresTipoNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A151ProveedoresTipoId), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A278ProveedoresTipoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A682ProveedorRazonSocial) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A683ProveedorContacto) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A684ProveedorContactoCell) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A338ProveedorDocIdentidad) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A430ProveedorTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A431ProveedorDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A433ProveedorEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A685ProveedorSitioWeb) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "DES") ==
            0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro directo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A440ProveedorPagoDefault, "F") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro prepago comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "T") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "cobro prepago almango", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "O") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A546ProveedorUsrAlta), 10, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A547ProveedorUsrActualizacion), 10, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) )
            )
            {
               GRID_nRecordCount = (long)(GRID_nRecordCount+1);
            }
            pr_default.readNext(0);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(0);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RFBH2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 37;
         /* Execute user event: Refresh */
         E17BH2 ();
         nGXsfl_37_idx = 1;
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         bGXsfl_37_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_372( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 AV16FilterFullText ,
                                                 A133ProveedorID ,
                                                 A151ProveedoresTipoId ,
                                                 A278ProveedoresTipoNombre ,
                                                 A282ProveedorNombre ,
                                                 A682ProveedorRazonSocial ,
                                                 A683ProveedorContacto ,
                                                 A684ProveedorContactoCell ,
                                                 A338ProveedorDocIdentidad ,
                                                 A430ProveedorTelefono ,
                                                 A431ProveedorDireccion ,
                                                 A433ProveedorEmail ,
                                                 A685ProveedorSitioWeb ,
                                                 A344ProveedorEstado ,
                                                 A440ProveedorPagoDefault ,
                                                 A546ProveedorUsrAlta ,
                                                 A547ProveedorUsrActualizacion ,
                                                 AV8BancoId ,
                                                 A673BancoId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                                 }
            });
            /* Using cursor H00BH3 */
            pr_default.execute(1, new Object[] {AV8BancoId});
            nGXsfl_37_idx = 1;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A673BancoId = H00BH3_A673BancoId[0];
               n673BancoId = H00BH3_n673BancoId[0];
               AssignAttri(sPrefix, false, "A673BancoId", StringUtil.LTrimStr( (decimal)(A673BancoId), 18, 0));
               A549ProveedorFechaActualizacion = H00BH3_A549ProveedorFechaActualizacion[0];
               n549ProveedorFechaActualizacion = H00BH3_n549ProveedorFechaActualizacion[0];
               A548ProveedorFechaAlta = H00BH3_A548ProveedorFechaAlta[0];
               n548ProveedorFechaAlta = H00BH3_n548ProveedorFechaAlta[0];
               A547ProveedorUsrActualizacion = H00BH3_A547ProveedorUsrActualizacion[0];
               n547ProveedorUsrActualizacion = H00BH3_n547ProveedorUsrActualizacion[0];
               A546ProveedorUsrAlta = H00BH3_A546ProveedorUsrAlta[0];
               n546ProveedorUsrAlta = H00BH3_n546ProveedorUsrAlta[0];
               A40001DocumentacionIcono_GXI = H00BH3_A40001DocumentacionIcono_GXI[0];
               AssignProp(sPrefix, false, edtDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), !bGXsfl_37_Refreshing);
               AssignProp(sPrefix, false, edtDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
               A488DocumentacionId = H00BH3_A488DocumentacionId[0];
               n488DocumentacionId = H00BH3_n488DocumentacionId[0];
               A490ProveedorPideDoc = H00BH3_A490ProveedorPideDoc[0];
               n490ProveedorPideDoc = H00BH3_n490ProveedorPideDoc[0];
               A440ProveedorPagoDefault = H00BH3_A440ProveedorPagoDefault[0];
               A344ProveedorEstado = H00BH3_A344ProveedorEstado[0];
               A437ProveedorPerAltShop = H00BH3_A437ProveedorPerAltShop[0];
               n437ProveedorPerAltShop = H00BH3_n437ProveedorPerAltShop[0];
               A686ProveedorAceptoTerminos = H00BH3_A686ProveedorAceptoTerminos[0];
               n686ProveedorAceptoTerminos = H00BH3_n686ProveedorAceptoTerminos[0];
               A685ProveedorSitioWeb = H00BH3_A685ProveedorSitioWeb[0];
               n685ProveedorSitioWeb = H00BH3_n685ProveedorSitioWeb[0];
               A433ProveedorEmail = H00BH3_A433ProveedorEmail[0];
               n433ProveedorEmail = H00BH3_n433ProveedorEmail[0];
               A431ProveedorDireccion = H00BH3_A431ProveedorDireccion[0];
               n431ProveedorDireccion = H00BH3_n431ProveedorDireccion[0];
               A430ProveedorTelefono = H00BH3_A430ProveedorTelefono[0];
               n430ProveedorTelefono = H00BH3_n430ProveedorTelefono[0];
               A345ProveedorSerialComi = H00BH3_A345ProveedorSerialComi[0];
               A338ProveedorDocIdentidad = H00BH3_A338ProveedorDocIdentidad[0];
               A40000ProveedorImagen_GXI = H00BH3_A40000ProveedorImagen_GXI[0];
               n40000ProveedorImagen_GXI = H00BH3_n40000ProveedorImagen_GXI[0];
               AssignProp(sPrefix, false, edtProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), !bGXsfl_37_Refreshing);
               AssignProp(sPrefix, false, edtProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
               A684ProveedorContactoCell = H00BH3_A684ProveedorContactoCell[0];
               n684ProveedorContactoCell = H00BH3_n684ProveedorContactoCell[0];
               A683ProveedorContacto = H00BH3_A683ProveedorContacto[0];
               n683ProveedorContacto = H00BH3_n683ProveedorContacto[0];
               A682ProveedorRazonSocial = H00BH3_A682ProveedorRazonSocial[0];
               n682ProveedorRazonSocial = H00BH3_n682ProveedorRazonSocial[0];
               A282ProveedorNombre = H00BH3_A282ProveedorNombre[0];
               A278ProveedoresTipoNombre = H00BH3_A278ProveedoresTipoNombre[0];
               A151ProveedoresTipoId = H00BH3_A151ProveedoresTipoId[0];
               A133ProveedorID = H00BH3_A133ProveedorID[0];
               A498DocumentacionIcono = H00BH3_A498DocumentacionIcono[0];
               AssignProp(sPrefix, false, edtDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), !bGXsfl_37_Refreshing);
               AssignProp(sPrefix, false, edtDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
               A432ProveedorImagen = H00BH3_A432ProveedorImagen[0];
               n432ProveedorImagen = H00BH3_n432ProveedorImagen[0];
               AssignProp(sPrefix, false, edtProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), !bGXsfl_37_Refreshing);
               AssignProp(sPrefix, false, edtProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
               A40001DocumentacionIcono_GXI = H00BH3_A40001DocumentacionIcono_GXI[0];
               AssignProp(sPrefix, false, edtDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), !bGXsfl_37_Refreshing);
               AssignProp(sPrefix, false, edtDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
               A498DocumentacionIcono = H00BH3_A498DocumentacionIcono[0];
               AssignProp(sPrefix, false, edtDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), !bGXsfl_37_Refreshing);
               AssignProp(sPrefix, false, edtDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
               A278ProveedoresTipoNombre = H00BH3_A278ProveedoresTipoNombre[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A151ProveedoresTipoId), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A278ProveedoresTipoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A682ProveedorRazonSocial) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A683ProveedorContacto) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A684ProveedorContactoCell) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A338ProveedorDocIdentidad) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A430ProveedorTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A431ProveedorDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A433ProveedorEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A685ProveedorSitioWeb) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "DES") ==
               0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro directo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A440ProveedorPagoDefault, "F") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro prepago comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "T") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "cobro prepago almango", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "O") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A546ProveedorUsrAlta), 10, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A547ProveedorUsrActualizacion), 10, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) )
               )
               {
                  /* Execute user event: Grid.Load */
                  E18BH2 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 37;
            WBBH0( ) ;
         }
         bGXsfl_37_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesBH2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV32Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV32Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV28IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV28IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV30IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV30IsAuthorized_Delete, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_PROVEEDORID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sPrefix+sGXsfl_37_idx, context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8BancoId, AV20ManageFiltersExecutionStep, AV32Pgmname, AV28IsAuthorized_Update, AV30IsAuthorized_Delete, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8BancoId, AV20ManageFiltersExecutionStep, AV32Pgmname, AV28IsAuthorized_Update, AV30IsAuthorized_Delete, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8BancoId, AV20ManageFiltersExecutionStep, AV32Pgmname, AV28IsAuthorized_Update, AV30IsAuthorized_Delete, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8BancoId, AV20ManageFiltersExecutionStep, AV32Pgmname, AV28IsAuthorized_Update, AV30IsAuthorized_Delete, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8BancoId, AV20ManageFiltersExecutionStep, AV32Pgmname, AV28IsAuthorized_Update, AV30IsAuthorized_Delete, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV32Pgmname = "BancoProveedorWC";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtProveedorID_Enabled = 0;
         edtProveedoresTipoId_Enabled = 0;
         edtProveedoresTipoNombre_Enabled = 0;
         edtProveedorNombre_Enabled = 0;
         edtProveedorRazonSocial_Enabled = 0;
         edtProveedorContacto_Enabled = 0;
         edtProveedorContactoCell_Enabled = 0;
         edtProveedorImagen_Enabled = 0;
         edtProveedorDocIdentidad_Enabled = 0;
         edtProveedorSerialComi_Enabled = 0;
         edtProveedorTelefono_Enabled = 0;
         edtProveedorDireccion_Enabled = 0;
         edtProveedorEmail_Enabled = 0;
         edtProveedorSitioWeb_Enabled = 0;
         edtProveedorAceptoTerminos_Enabled = 0;
         cmbProveedorPerAltShop.Enabled = 0;
         cmbProveedorEstado.Enabled = 0;
         cmbProveedorPagoDefault.Enabled = 0;
         cmbProveedorPideDoc.Enabled = 0;
         edtDocumentacionId_Enabled = 0;
         edtDocumentacionIcono_Enabled = 0;
         edtProveedorUsrAlta_Enabled = 0;
         edtProveedorUsrActualizacion_Enabled = 0;
         edtProveedorFechaAlta_Enabled = 0;
         edtProveedorFechaActualizacion_Enabled = 0;
         edtBancoId_Enabled = 0;
         AssignProp(sPrefix, false, edtBancoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBancoId_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUPBH0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E16BH2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMANAGEFILTERSDATA"), AV18ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV21DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_37"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV24GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV25GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV26GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
            wcpOAV8BancoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8BancoId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Cls");
            Gridpaginationbar_Class = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagestoshow"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpagecaption");
            Ddo_grid_Caption = cgiGet( sPrefix+"DDO_GRID_Caption");
            Ddo_grid_Gridinternalname = cgiGet( sPrefix+"DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( sPrefix+"DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( sPrefix+"DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( sPrefix+"DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( sPrefix+"DDO_GRID_Sortedstatus");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Fixedcolumns = cgiGet( sPrefix+"GRID_EMPOWERER_Fixedcolumns");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            Ddo_managefilters_Activeeventkey = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV16FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri(sPrefix, false, "AV16FilterFullText", AV16FilterFullText);
            A673BancoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtBancoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n673BancoId = false;
            AssignAttri(sPrefix, false, "A673BancoId", StringUtil.LTrimStr( (decimal)(A673BancoId), 18, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV14OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV15OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV16FilterFullText) != 0 )
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
         E16BH2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E16BH2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 50;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         /* Execute user subroutine: 'LOADSAVEDFILTERS' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         edtBancoId_Visible = 0;
         AssignProp(sPrefix, false, edtBancoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtBancoId_Visible), 5, 0), true);
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
            AssignAttri(sPrefix, false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV21DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV21DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E17BH2( )
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
         if ( AV20ManageFiltersExecutionStep == 1 )
         {
            AV20ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV20ManageFiltersExecutionStep == 2 )
         {
            AV20ManageFiltersExecutionStep = 0;
            AssignAttri(sPrefix, false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
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
         AV24GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV24GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV24GridCurrentPage), 10, 0));
         AV25GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV25GridPageCount", StringUtil.LTrimStr( (decimal)(AV25GridPageCount), 10, 0));
         GXt_char2 = AV26GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV32Pgmname, out  GXt_char2) ;
         AV26GridAppliedFilters = GXt_char2;
         AssignAttri(sPrefix, false, "AV26GridAppliedFilters", AV26GridAppliedFilters);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ManageFiltersData", AV18ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridState", AV12GridState);
      }

      protected void E12BH2( )
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
            AV23PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV23PageToGo) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ManageFiltersData", AV18ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridState", AV12GridState);
      }

      protected void E13BH2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E14BH2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
            AV15OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri(sPrefix, false, "AV15OrderedDsc", AV15OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E18BH2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            AV27Update = "<i class=\"fa fa-pen\"></i>";
            AssignAttri(sPrefix, false, edtavUpdate_Internalname, AV27Update);
            if ( AV28IsAuthorized_Update )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "proveedor.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A133ProveedorID,18,0));
               edtavUpdate_Link = formatLink("proveedor.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            AV29Delete = "<i class=\"fa fa-times\"></i>";
            AssignAttri(sPrefix, false, edtavDelete_Internalname, AV29Delete);
            if ( AV30IsAuthorized_Delete )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "proveedor.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A133ProveedorID,18,0));
               edtavDelete_Link = formatLink("proveedor.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "proveedorview.aspx"+UrlEncode(StringUtil.LTrimStr(A133ProveedorID,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtProveedorNombre_Link = formatLink("proveedorview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 37;
            }
            sendrow_372( ) ;
         }
         GRID_nEOF = (short)(((subGrid_Rows==0)||(GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_37_Refreshing )
         {
            context.DoAjaxLoad(37, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E11BH2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S172 ();
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("BancoProveedorWCFilters")) + "," + UrlEncode(StringUtil.RTrim(AV32Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV20ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("BancoProveedorWCFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV20ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            GXt_char2 = AV19ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "BancoProveedorWCFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV19ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV19ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S172 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV32Pgmname+"GridState",  AV19ManageFiltersXml) ;
               AV12GridState.FromXml(AV19ManageFiltersXml, null, "", "");
               AV14OrderedBy = AV12GridState.gxTpr_Orderedby;
               AssignAttri(sPrefix, false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
               AV15OrderedDsc = AV12GridState.gxTpr_Ordereddsc;
               AssignAttri(sPrefix, false, "AV15OrderedDsc", AV15OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S142 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S182 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridState", AV12GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ManageFiltersData", AV18ManageFiltersData);
      }

      protected void E15BH2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "proveedor.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("proveedor.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV14OrderedBy), 4, 0))+":"+(AV15OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean3 = AV28IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProveedor_Update", out  GXt_boolean3) ;
         AV28IsAuthorized_Update = GXt_boolean3;
         AssignAttri(sPrefix, false, "AV28IsAuthorized_Update", AV28IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV28IsAuthorized_Update, context));
         if ( ! ( AV28IsAuthorized_Update ) )
         {
            edtavUpdate_Visible = 0;
            AssignProp(sPrefix, false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_37_Refreshing);
         }
         GXt_boolean3 = AV30IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProveedor_Delete", out  GXt_boolean3) ;
         AV30IsAuthorized_Delete = GXt_boolean3;
         AssignAttri(sPrefix, false, "AV30IsAuthorized_Delete", AV30IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV30IsAuthorized_Delete, context));
         if ( ! ( AV30IsAuthorized_Delete ) )
         {
            edtavDelete_Visible = 0;
            AssignProp(sPrefix, false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_37_Refreshing);
         }
         GXt_boolean3 = AV31TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProveedor_Insert", out  GXt_boolean3) ;
         AV31TempBoolean = GXt_boolean3;
         if ( ! ( AV31TempBoolean ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp(sPrefix, false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV18ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "BancoProveedorWCFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV18ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S172( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV16FilterFullText = "";
         AssignAttri(sPrefix, false, "AV16FilterFullText", AV16FilterFullText);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV17Session.Get(AV32Pgmname+"GridState"), "") == 0 )
         {
            AV12GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV32Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV12GridState.FromXml(AV17Session.Get(AV32Pgmname+"GridState"), null, "", "");
         }
         AV14OrderedBy = AV12GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
         AV15OrderedDsc = AV12GridState.gxTpr_Ordereddsc;
         AssignAttri(sPrefix, false, "AV15OrderedDsc", AV15OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV12GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV12GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
      }

      protected void S182( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV33GXV1 = 1;
         while ( AV33GXV1 <= AV12GridState.gxTpr_Filtervalues.Count )
         {
            AV13GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV12GridState.gxTpr_Filtervalues.Item(AV33GXV1));
            if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV16FilterFullText = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV16FilterFullText", AV16FilterFullText);
            }
            AV33GXV1 = (int)(AV33GXV1+1);
         }
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV12GridState.FromXml(AV17Session.Get(AV32Pgmname+"GridState"), null, "", "");
         AV12GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV12GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV12GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)),  0,  AV16FilterFullText,  "") ;
         AV12GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV32Pgmname+"GridState",  AV12GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10TrnContext.gxTpr_Callerobject = AV32Pgmname;
         AV10TrnContext.gxTpr_Callerondelete = true;
         AV10TrnContext.gxTpr_Callerurl = AV9HTTPRequest.ScriptName+"?"+AV9HTTPRequest.QueryString;
         AV10TrnContext.gxTpr_Transactionname = "Proveedor";
         AV11TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV11TrnContextAtt.gxTpr_Attributename = "BancoId";
         AV11TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV8BancoId), 18, 0);
         AV10TrnContext.gxTpr_Attributes.Add(AV11TrnContextAtt, 0);
         AV17Session.Set("TrnContext", AV10TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table1_22_BH2( bool wbgen )
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV18ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, sPrefix+"DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_27_BH2( true) ;
         }
         else
         {
            wb_table2_27_BH2( false) ;
         }
         return  ;
      }

      protected void wb_table2_27_BH2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_22_BH2e( true) ;
         }
         else
         {
            wb_table1_22_BH2e( false) ;
         }
      }

      protected void wb_table2_27_BH2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'" + sPrefix + "',false,'" + sGXsfl_37_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV16FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV16FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_BancoProveedorWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_27_BH2e( true) ;
         }
         else
         {
            wb_table2_27_BH2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8BancoId = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV8BancoId", StringUtil.LTrimStr( (decimal)(AV8BancoId), 18, 0));
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
         PABH2( ) ;
         WSBH2( ) ;
         WEBH2( ) ;
         cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected override EncryptionType GetEncryptionType( )
      {
         return EncryptionType.SITE ;
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlAV8BancoId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PABH2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "bancoproveedorwc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PABH2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV8BancoId = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV8BancoId", StringUtil.LTrimStr( (decimal)(AV8BancoId), 18, 0));
         }
         wcpOAV8BancoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8BancoId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV8BancoId != wcpOAV8BancoId ) ) )
         {
            setjustcreated();
         }
         wcpOAV8BancoId = AV8BancoId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV8BancoId = cgiGet( sPrefix+"AV8BancoId_CTRL");
         if ( StringUtil.Len( sCtrlAV8BancoId) > 0 )
         {
            AV8BancoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV8BancoId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV8BancoId", StringUtil.LTrimStr( (decimal)(AV8BancoId), 18, 0));
         }
         else
         {
            AV8BancoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV8BancoId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PABH2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WSBH2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WSBH2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8BancoId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8BancoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8BancoId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8BancoId_CTRL", StringUtil.RTrim( sCtrlAV8BancoId));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WEBH2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269319592864", true, true, false);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("bancoproveedorwc.js", "?20269319592864", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_372( )
      {
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_37_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_37_idx;
         edtProveedorID_Internalname = sPrefix+"PROVEEDORID_"+sGXsfl_37_idx;
         edtProveedoresTipoId_Internalname = sPrefix+"PROVEEDORESTIPOID_"+sGXsfl_37_idx;
         edtProveedoresTipoNombre_Internalname = sPrefix+"PROVEEDORESTIPONOMBRE_"+sGXsfl_37_idx;
         edtProveedorNombre_Internalname = sPrefix+"PROVEEDORNOMBRE_"+sGXsfl_37_idx;
         edtProveedorRazonSocial_Internalname = sPrefix+"PROVEEDORRAZONSOCIAL_"+sGXsfl_37_idx;
         edtProveedorContacto_Internalname = sPrefix+"PROVEEDORCONTACTO_"+sGXsfl_37_idx;
         edtProveedorContactoCell_Internalname = sPrefix+"PROVEEDORCONTACTOCELL_"+sGXsfl_37_idx;
         edtProveedorImagen_Internalname = sPrefix+"PROVEEDORIMAGEN_"+sGXsfl_37_idx;
         edtProveedorDocIdentidad_Internalname = sPrefix+"PROVEEDORDOCIDENTIDAD_"+sGXsfl_37_idx;
         edtProveedorSerialComi_Internalname = sPrefix+"PROVEEDORSERIALCOMI_"+sGXsfl_37_idx;
         edtProveedorTelefono_Internalname = sPrefix+"PROVEEDORTELEFONO_"+sGXsfl_37_idx;
         edtProveedorDireccion_Internalname = sPrefix+"PROVEEDORDIRECCION_"+sGXsfl_37_idx;
         edtProveedorEmail_Internalname = sPrefix+"PROVEEDOREMAIL_"+sGXsfl_37_idx;
         edtProveedorSitioWeb_Internalname = sPrefix+"PROVEEDORSITIOWEB_"+sGXsfl_37_idx;
         edtProveedorAceptoTerminos_Internalname = sPrefix+"PROVEEDORACEPTOTERMINOS_"+sGXsfl_37_idx;
         cmbProveedorPerAltShop_Internalname = sPrefix+"PROVEEDORPERALTSHOP_"+sGXsfl_37_idx;
         cmbProveedorEstado_Internalname = sPrefix+"PROVEEDORESTADO_"+sGXsfl_37_idx;
         cmbProveedorPagoDefault_Internalname = sPrefix+"PROVEEDORPAGODEFAULT_"+sGXsfl_37_idx;
         cmbProveedorPideDoc_Internalname = sPrefix+"PROVEEDORPIDEDOC_"+sGXsfl_37_idx;
         edtDocumentacionId_Internalname = sPrefix+"DOCUMENTACIONID_"+sGXsfl_37_idx;
         edtDocumentacionIcono_Internalname = sPrefix+"DOCUMENTACIONICONO_"+sGXsfl_37_idx;
         edtProveedorUsrAlta_Internalname = sPrefix+"PROVEEDORUSRALTA_"+sGXsfl_37_idx;
         edtProveedorUsrActualizacion_Internalname = sPrefix+"PROVEEDORUSRACTUALIZACION_"+sGXsfl_37_idx;
         edtProveedorFechaAlta_Internalname = sPrefix+"PROVEEDORFECHAALTA_"+sGXsfl_37_idx;
         edtProveedorFechaActualizacion_Internalname = sPrefix+"PROVEEDORFECHAACTUALIZACION_"+sGXsfl_37_idx;
      }

      protected void SubsflControlProps_fel_372( )
      {
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_37_fel_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_37_fel_idx;
         edtProveedorID_Internalname = sPrefix+"PROVEEDORID_"+sGXsfl_37_fel_idx;
         edtProveedoresTipoId_Internalname = sPrefix+"PROVEEDORESTIPOID_"+sGXsfl_37_fel_idx;
         edtProveedoresTipoNombre_Internalname = sPrefix+"PROVEEDORESTIPONOMBRE_"+sGXsfl_37_fel_idx;
         edtProveedorNombre_Internalname = sPrefix+"PROVEEDORNOMBRE_"+sGXsfl_37_fel_idx;
         edtProveedorRazonSocial_Internalname = sPrefix+"PROVEEDORRAZONSOCIAL_"+sGXsfl_37_fel_idx;
         edtProveedorContacto_Internalname = sPrefix+"PROVEEDORCONTACTO_"+sGXsfl_37_fel_idx;
         edtProveedorContactoCell_Internalname = sPrefix+"PROVEEDORCONTACTOCELL_"+sGXsfl_37_fel_idx;
         edtProveedorImagen_Internalname = sPrefix+"PROVEEDORIMAGEN_"+sGXsfl_37_fel_idx;
         edtProveedorDocIdentidad_Internalname = sPrefix+"PROVEEDORDOCIDENTIDAD_"+sGXsfl_37_fel_idx;
         edtProveedorSerialComi_Internalname = sPrefix+"PROVEEDORSERIALCOMI_"+sGXsfl_37_fel_idx;
         edtProveedorTelefono_Internalname = sPrefix+"PROVEEDORTELEFONO_"+sGXsfl_37_fel_idx;
         edtProveedorDireccion_Internalname = sPrefix+"PROVEEDORDIRECCION_"+sGXsfl_37_fel_idx;
         edtProveedorEmail_Internalname = sPrefix+"PROVEEDOREMAIL_"+sGXsfl_37_fel_idx;
         edtProveedorSitioWeb_Internalname = sPrefix+"PROVEEDORSITIOWEB_"+sGXsfl_37_fel_idx;
         edtProveedorAceptoTerminos_Internalname = sPrefix+"PROVEEDORACEPTOTERMINOS_"+sGXsfl_37_fel_idx;
         cmbProveedorPerAltShop_Internalname = sPrefix+"PROVEEDORPERALTSHOP_"+sGXsfl_37_fel_idx;
         cmbProveedorEstado_Internalname = sPrefix+"PROVEEDORESTADO_"+sGXsfl_37_fel_idx;
         cmbProveedorPagoDefault_Internalname = sPrefix+"PROVEEDORPAGODEFAULT_"+sGXsfl_37_fel_idx;
         cmbProveedorPideDoc_Internalname = sPrefix+"PROVEEDORPIDEDOC_"+sGXsfl_37_fel_idx;
         edtDocumentacionId_Internalname = sPrefix+"DOCUMENTACIONID_"+sGXsfl_37_fel_idx;
         edtDocumentacionIcono_Internalname = sPrefix+"DOCUMENTACIONICONO_"+sGXsfl_37_fel_idx;
         edtProveedorUsrAlta_Internalname = sPrefix+"PROVEEDORUSRALTA_"+sGXsfl_37_fel_idx;
         edtProveedorUsrActualizacion_Internalname = sPrefix+"PROVEEDORUSRACTUALIZACION_"+sGXsfl_37_fel_idx;
         edtProveedorFechaAlta_Internalname = sPrefix+"PROVEEDORFECHAALTA_"+sGXsfl_37_fel_idx;
         edtProveedorFechaActualizacion_Internalname = sPrefix+"PROVEEDORFECHAACTUALIZACION_"+sGXsfl_37_fel_idx;
      }

      protected void sendrow_372( )
      {
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         WBBH0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_37_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_37_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_37_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV27Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",context.GetMessage( "GXM_update", ""),(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV29Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",context.GetMessage( "GX_BtnDelete", ""),(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedoresTipoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A151ProveedoresTipoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A151ProveedoresTipoId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedoresTipoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedoresTipoNombre_Internalname,StringUtil.RTrim( A278ProveedoresTipoNombre),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedoresTipoNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorNombre_Internalname,StringUtil.RTrim( A282ProveedorNombre),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtProveedorNombre_Link,(string)"",(string)"",(string)"",(string)edtProveedorNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorRazonSocial_Internalname,StringUtil.RTrim( A682ProveedorRazonSocial),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorRazonSocial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)25,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorContacto_Internalname,StringUtil.RTrim( A683ProveedorContacto),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorContacto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)128,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            gxphoneLink = "tel:" + StringUtil.RTrim( A684ProveedorContactoCell);
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorContactoCell_Internalname,StringUtil.RTrim( A684ProveedorContactoCell),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtProveedorContactoCell_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Attribute";
            StyleString = "";
            A432ProveedorImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProveedorImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.PathToRelativeUrl( A432ProveedorImagen));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorImagen_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A432ProveedorImagen_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorDocIdentidad_Internalname,StringUtil.RTrim( A338ProveedorDocIdentidad),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorDocIdentidad_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)25,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorSerialComi_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A345ProveedorSerialComi), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A345ProveedorSerialComi), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorSerialComi_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            gxphoneLink = "tel:" + StringUtil.RTrim( A430ProveedorTelefono);
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorTelefono_Internalname,StringUtil.RTrim( A430ProveedorTelefono),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtProveedorTelefono_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorDireccion_Internalname,(string)A431ProveedorDireccion,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'","http://maps.google.com/maps?q="+GXUtil.UrlEncode( A431ProveedorDireccion),(string)"_blank",(string)"",(string)"",(string)edtProveedorDireccion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Address",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorEmail_Internalname,(string)A433ProveedorEmail,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A433ProveedorEmail,(string)"",(string)"",(string)"",(string)edtProveedorEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorSitioWeb_Internalname,StringUtil.RTrim( A685ProveedorSitioWeb),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorSitioWeb_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)128,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorAceptoTerminos_Internalname,context.localUtil.TToC( A686ProveedorAceptoTerminos, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A686ProveedorAceptoTerminos, "99/99/99 99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorAceptoTerminos_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbProveedorPerAltShop.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "PROVEEDORPERALTSHOP_" + sGXsfl_37_idx;
               cmbProveedorPerAltShop.Name = GXCCtl;
               cmbProveedorPerAltShop.WebTags = "";
               cmbProveedorPerAltShop.addItem("N", context.GetMessage( "No permitir", ""), 0);
               cmbProveedorPerAltShop.addItem("S", context.GetMessage( "Permitir", ""), 0);
               if ( cmbProveedorPerAltShop.ItemCount > 0 )
               {
                  A437ProveedorPerAltShop = cmbProveedorPerAltShop.getValidValue(A437ProveedorPerAltShop);
                  n437ProveedorPerAltShop = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbProveedorPerAltShop,(string)cmbProveedorPerAltShop_Internalname,StringUtil.RTrim( A437ProveedorPerAltShop),(short)1,(string)cmbProveedorPerAltShop_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbProveedorPerAltShop.CurrentValue = StringUtil.RTrim( A437ProveedorPerAltShop);
            AssignProp(sPrefix, false, cmbProveedorPerAltShop_Internalname, "Values", (string)(cmbProveedorPerAltShop.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbProveedorEstado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "PROVEEDORESTADO_" + sGXsfl_37_idx;
               cmbProveedorEstado.Name = GXCCtl;
               cmbProveedorEstado.WebTags = "";
               cmbProveedorEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
               cmbProveedorEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
               cmbProveedorEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
               cmbProveedorEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
               if ( cmbProveedorEstado.ItemCount > 0 )
               {
                  A344ProveedorEstado = cmbProveedorEstado.getValidValue(A344ProveedorEstado);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbProveedorEstado,(string)cmbProveedorEstado_Internalname,StringUtil.RTrim( A344ProveedorEstado),(short)1,(string)cmbProveedorEstado_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbProveedorEstado.CurrentValue = StringUtil.RTrim( A344ProveedorEstado);
            AssignProp(sPrefix, false, cmbProveedorEstado_Internalname, "Values", (string)(cmbProveedorEstado.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbProveedorPagoDefault.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "PROVEEDORPAGODEFAULT_" + sGXsfl_37_idx;
               cmbProveedorPagoDefault.Name = GXCCtl;
               cmbProveedorPagoDefault.WebTags = "";
               cmbProveedorPagoDefault.addItem("F", context.GetMessage( "Cobro Directo", ""), 0);
               cmbProveedorPagoDefault.addItem("T", context.GetMessage( "Cobro Prepago Comercio", ""), 0);
               cmbProveedorPagoDefault.addItem("O", context.GetMessage( "Cobro Prepago Almango", ""), 0);
               if ( cmbProveedorPagoDefault.ItemCount > 0 )
               {
                  A440ProveedorPagoDefault = cmbProveedorPagoDefault.getValidValue(A440ProveedorPagoDefault);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbProveedorPagoDefault,(string)cmbProveedorPagoDefault_Internalname,StringUtil.RTrim( A440ProveedorPagoDefault),(short)1,(string)cmbProveedorPagoDefault_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbProveedorPagoDefault.CurrentValue = StringUtil.RTrim( A440ProveedorPagoDefault);
            AssignProp(sPrefix, false, cmbProveedorPagoDefault_Internalname, "Values", (string)(cmbProveedorPagoDefault.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbProveedorPideDoc.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "PROVEEDORPIDEDOC_" + sGXsfl_37_idx;
               cmbProveedorPideDoc.Name = GXCCtl;
               cmbProveedorPideDoc.WebTags = "";
               cmbProveedorPideDoc.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
               cmbProveedorPideDoc.addItem("S", context.GetMessage( "Si", ""), 0);
               cmbProveedorPideDoc.addItem("N", context.GetMessage( "No", ""), 0);
               if ( cmbProveedorPideDoc.ItemCount > 0 )
               {
                  A490ProveedorPideDoc = cmbProveedorPideDoc.getValidValue(A490ProveedorPideDoc);
                  n490ProveedorPideDoc = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbProveedorPideDoc,(string)cmbProveedorPideDoc_Internalname,StringUtil.RTrim( A490ProveedorPideDoc),(short)1,(string)cmbProveedorPideDoc_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbProveedorPideDoc.CurrentValue = StringUtil.RTrim( A490ProveedorPideDoc);
            AssignProp(sPrefix, false, cmbProveedorPideDoc_Internalname, "Values", (string)(cmbProveedorPideDoc.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocumentacionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A488DocumentacionId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A488DocumentacionId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocumentacionId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Attribute";
            StyleString = "";
            A498DocumentacionIcono_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono))&&String.IsNullOrEmpty(StringUtil.RTrim( A40001DocumentacionIcono_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.PathToRelativeUrl( A498DocumentacionIcono));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtDocumentacionIcono_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)0,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A498DocumentacionIcono_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorUsrAlta_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A546ProveedorUsrAlta), 10, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A546ProveedorUsrAlta), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorUsrAlta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"UserID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorUsrActualizacion_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A547ProveedorUsrActualizacion), 10, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A547ProveedorUsrActualizacion), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorUsrActualizacion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"UserID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorFechaAlta_Internalname,context.localUtil.TToC( A548ProveedorFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A548ProveedorFechaAlta, "99/99/99 99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorFechaAlta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorFechaActualizacion_Internalname,context.localUtil.TToC( A549ProveedorFechaActualizacion, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A549ProveedorFechaActualizacion, "99/99/99 99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorFechaActualizacion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesBH2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         /* End function sendrow_372 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "PROVEEDORPERALTSHOP_" + sGXsfl_37_idx;
         cmbProveedorPerAltShop.Name = GXCCtl;
         cmbProveedorPerAltShop.WebTags = "";
         cmbProveedorPerAltShop.addItem("N", context.GetMessage( "No permitir", ""), 0);
         cmbProveedorPerAltShop.addItem("S", context.GetMessage( "Permitir", ""), 0);
         if ( cmbProveedorPerAltShop.ItemCount > 0 )
         {
         }
         GXCCtl = "PROVEEDORESTADO_" + sGXsfl_37_idx;
         cmbProveedorEstado.Name = GXCCtl;
         cmbProveedorEstado.WebTags = "";
         cmbProveedorEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbProveedorEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbProveedorEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbProveedorEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbProveedorEstado.ItemCount > 0 )
         {
         }
         GXCCtl = "PROVEEDORPAGODEFAULT_" + sGXsfl_37_idx;
         cmbProveedorPagoDefault.Name = GXCCtl;
         cmbProveedorPagoDefault.WebTags = "";
         cmbProveedorPagoDefault.addItem("F", context.GetMessage( "Cobro Directo", ""), 0);
         cmbProveedorPagoDefault.addItem("T", context.GetMessage( "Cobro Prepago Comercio", ""), 0);
         cmbProveedorPagoDefault.addItem("O", context.GetMessage( "Cobro Prepago Almango", ""), 0);
         if ( cmbProveedorPagoDefault.ItemCount > 0 )
         {
         }
         GXCCtl = "PROVEEDORPIDEDOC_" + sGXsfl_37_idx;
         cmbProveedorPideDoc.Name = GXCCtl;
         cmbProveedorPideDoc.WebTags = "";
         cmbProveedorPideDoc.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbProveedorPideDoc.addItem("S", context.GetMessage( "Si", ""), 0);
         cmbProveedorPideDoc.addItem("N", context.GetMessage( "No", ""), 0);
         if ( cmbProveedorPideDoc.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl37( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"37\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Código del Proveedor", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "TipoId", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Razón Social", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre del Contacto", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Número del Contacto", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Imagen", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Documento de Identidad", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Comision", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Teléfono", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Dirección", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Email", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Web", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "y Condiciones", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "crear Subastas", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "por Default", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "¿Solicita documentación requerida?", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Documentación", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Icono", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Alta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Actualizacion", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Alta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Actualizacion", "")) ;
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
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV27Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV29Delete)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A151ProveedoresTipoId), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A278ProveedoresTipoNombre)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A282ProveedorNombre)));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtProveedorNombre_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A682ProveedorRazonSocial)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A683ProveedorContacto)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A684ProveedorContactoCell)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( A432ProveedorImagen));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A338ProveedorDocIdentidad)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A345ProveedorSerialComi), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A430ProveedorTelefono)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A431ProveedorDireccion));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A433ProveedorEmail));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A685ProveedorSitioWeb)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A686ProveedorAceptoTerminos, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A437ProveedorPerAltShop)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A344ProveedorEstado)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A440ProveedorPagoDefault)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A490ProveedorPideDoc)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A488DocumentacionId), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( A498DocumentacionIcono));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A546ProveedorUsrAlta), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A547ProveedorUsrActualizacion), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A548ProveedorFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A549ProveedorFechaActualizacion, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
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
         bttBtninsert_Internalname = sPrefix+"BTNINSERT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         Ddo_managefilters_Internalname = sPrefix+"DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = sPrefix+"vFILTERFULLTEXT";
         tblTablefilters_Internalname = sPrefix+"TABLEFILTERS";
         tblTablerightheader_Internalname = sPrefix+"TABLERIGHTHEADER";
         divTableheadercontent_Internalname = sPrefix+"TABLEHEADERCONTENT";
         divTableheader_Internalname = sPrefix+"TABLEHEADER";
         edtavUpdate_Internalname = sPrefix+"vUPDATE";
         edtavDelete_Internalname = sPrefix+"vDELETE";
         edtProveedorID_Internalname = sPrefix+"PROVEEDORID";
         edtProveedoresTipoId_Internalname = sPrefix+"PROVEEDORESTIPOID";
         edtProveedoresTipoNombre_Internalname = sPrefix+"PROVEEDORESTIPONOMBRE";
         edtProveedorNombre_Internalname = sPrefix+"PROVEEDORNOMBRE";
         edtProveedorRazonSocial_Internalname = sPrefix+"PROVEEDORRAZONSOCIAL";
         edtProveedorContacto_Internalname = sPrefix+"PROVEEDORCONTACTO";
         edtProveedorContactoCell_Internalname = sPrefix+"PROVEEDORCONTACTOCELL";
         edtProveedorImagen_Internalname = sPrefix+"PROVEEDORIMAGEN";
         edtProveedorDocIdentidad_Internalname = sPrefix+"PROVEEDORDOCIDENTIDAD";
         edtProveedorSerialComi_Internalname = sPrefix+"PROVEEDORSERIALCOMI";
         edtProveedorTelefono_Internalname = sPrefix+"PROVEEDORTELEFONO";
         edtProveedorDireccion_Internalname = sPrefix+"PROVEEDORDIRECCION";
         edtProveedorEmail_Internalname = sPrefix+"PROVEEDOREMAIL";
         edtProveedorSitioWeb_Internalname = sPrefix+"PROVEEDORSITIOWEB";
         edtProveedorAceptoTerminos_Internalname = sPrefix+"PROVEEDORACEPTOTERMINOS";
         cmbProveedorPerAltShop_Internalname = sPrefix+"PROVEEDORPERALTSHOP";
         cmbProveedorEstado_Internalname = sPrefix+"PROVEEDORESTADO";
         cmbProveedorPagoDefault_Internalname = sPrefix+"PROVEEDORPAGODEFAULT";
         cmbProveedorPideDoc_Internalname = sPrefix+"PROVEEDORPIDEDOC";
         edtDocumentacionId_Internalname = sPrefix+"DOCUMENTACIONID";
         edtDocumentacionIcono_Internalname = sPrefix+"DOCUMENTACIONICONO";
         edtProveedorUsrAlta_Internalname = sPrefix+"PROVEEDORUSRALTA";
         edtProveedorUsrActualizacion_Internalname = sPrefix+"PROVEEDORUSRACTUALIZACION";
         edtProveedorFechaAlta_Internalname = sPrefix+"PROVEEDORFECHAALTA";
         edtProveedorFechaActualizacion_Internalname = sPrefix+"PROVEEDORFECHAACTUALIZACION";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         divTablegridheader_Internalname = sPrefix+"TABLEGRIDHEADER";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         edtBancoId_Internalname = sPrefix+"BANCOID";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtProveedorFechaActualizacion_Jsonclick = "";
         edtProveedorFechaAlta_Jsonclick = "";
         edtProveedorUsrActualizacion_Jsonclick = "";
         edtProveedorUsrAlta_Jsonclick = "";
         edtDocumentacionId_Jsonclick = "";
         cmbProveedorPideDoc_Jsonclick = "";
         cmbProveedorPagoDefault_Jsonclick = "";
         cmbProveedorEstado_Jsonclick = "";
         cmbProveedorPerAltShop_Jsonclick = "";
         edtProveedorAceptoTerminos_Jsonclick = "";
         edtProveedorSitioWeb_Jsonclick = "";
         edtProveedorEmail_Jsonclick = "";
         edtProveedorDireccion_Jsonclick = "";
         edtProveedorTelefono_Jsonclick = "";
         edtProveedorSerialComi_Jsonclick = "";
         edtProveedorDocIdentidad_Jsonclick = "";
         edtProveedorContactoCell_Jsonclick = "";
         edtProveedorContacto_Jsonclick = "";
         edtProveedorRazonSocial_Jsonclick = "";
         edtProveedorNombre_Jsonclick = "";
         edtProveedorNombre_Link = "";
         edtProveedoresTipoNombre_Jsonclick = "";
         edtProveedoresTipoId_Jsonclick = "";
         edtProveedorID_Jsonclick = "";
         edtavDelete_Jsonclick = "";
         edtavDelete_Link = "";
         edtavDelete_Enabled = 0;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtBancoId_Enabled = 0;
         edtProveedorFechaActualizacion_Enabled = 0;
         edtProveedorFechaAlta_Enabled = 0;
         edtProveedorUsrActualizacion_Enabled = 0;
         edtProveedorUsrAlta_Enabled = 0;
         edtDocumentacionIcono_Enabled = 0;
         edtDocumentacionId_Enabled = 0;
         cmbProveedorPideDoc.Enabled = 0;
         cmbProveedorPagoDefault.Enabled = 0;
         cmbProveedorEstado.Enabled = 0;
         cmbProveedorPerAltShop.Enabled = 0;
         edtProveedorAceptoTerminos_Enabled = 0;
         edtProveedorSitioWeb_Enabled = 0;
         edtProveedorEmail_Enabled = 0;
         edtProveedorDireccion_Enabled = 0;
         edtProveedorTelefono_Enabled = 0;
         edtProveedorSerialComi_Enabled = 0;
         edtProveedorDocIdentidad_Enabled = 0;
         edtProveedorImagen_Enabled = 0;
         edtProveedorContactoCell_Enabled = 0;
         edtProveedorContacto_Enabled = 0;
         edtProveedorRazonSocial_Enabled = 0;
         edtProveedorNombre_Enabled = 0;
         edtProveedoresTipoNombre_Enabled = 0;
         edtProveedoresTipoId_Enabled = 0;
         edtProveedorID_Enabled = 0;
         subGrid_Sortable = 0;
         edtBancoId_Jsonclick = "";
         edtBancoId_Visible = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Fixedcolumns = "L;L;;;;;;;;;;;;;;;;;;;;;;;;;";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|4|1|5|6|7|8|9|10|11|12|13|14|15|16|17|18|19";
         Ddo_grid_Columnids = "2:ProveedorID|3:ProveedoresTipoId|4:ProveedoresTipoNombre|5:ProveedorNombre|6:ProveedorRazonSocial|7:ProveedorContacto|8:ProveedorContactoCell|10:ProveedorDocIdentidad|12:ProveedorTelefono|13:ProveedorDireccion|14:ProveedorEmail|15:ProveedorSitioWeb|16:ProveedorAceptoTerminos|18:ProveedorEstado|19:ProveedorPagoDefault|23:ProveedorUsrAlta|24:ProveedorUsrActualizacion|25:ProveedorFechaAlta|26:ProveedorFechaActualizacion";
         Ddo_grid_Gridinternalname = "";
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
         subGrid_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV8BancoId',fld:'vBANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'sPrefix',type:'char'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV32Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV28IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV30IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV24GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV25GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV26GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV28IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV30IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV18ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E12BH2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8BancoId',fld:'vBANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV28IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV30IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV24GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV25GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV26GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV28IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV30IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV18ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E13BH2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8BancoId',fld:'vBANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV28IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV30IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E14BH2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8BancoId',fld:'vBANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV28IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV30IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E18BH2',iparms:[{av:'AV28IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV30IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV27Update',fld:'vUPDATE',pic:'',type:'char'},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'AV29Delete',fld:'vDELETE',pic:'',type:'char'},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtProveedorNombre_Link',ctrl:'PROVEEDORNOMBRE',prop:'Link'}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E11BH2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8BancoId',fld:'vBANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV32Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV28IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV30IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV24GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV25GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV26GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV28IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV30IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV18ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E15BH2',iparms:[{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORID","{handler:'Valid_Proveedorid',iparms:[]");
         setEventMetadata("VALID_PROVEEDORID",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORESTIPOID","{handler:'Valid_Proveedorestipoid',iparms:[]");
         setEventMetadata("VALID_PROVEEDORESTIPOID",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORESTIPONOMBRE","{handler:'Valid_Proveedorestiponombre',iparms:[]");
         setEventMetadata("VALID_PROVEEDORESTIPONOMBRE",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORNOMBRE","{handler:'Valid_Proveedornombre',iparms:[]");
         setEventMetadata("VALID_PROVEEDORNOMBRE",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORRAZONSOCIAL","{handler:'Valid_Proveedorrazonsocial',iparms:[]");
         setEventMetadata("VALID_PROVEEDORRAZONSOCIAL",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORCONTACTO","{handler:'Valid_Proveedorcontacto',iparms:[]");
         setEventMetadata("VALID_PROVEEDORCONTACTO",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORCONTACTOCELL","{handler:'Valid_Proveedorcontactocell',iparms:[]");
         setEventMetadata("VALID_PROVEEDORCONTACTOCELL",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORDOCIDENTIDAD","{handler:'Valid_Proveedordocidentidad',iparms:[]");
         setEventMetadata("VALID_PROVEEDORDOCIDENTIDAD",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORTELEFONO","{handler:'Valid_Proveedortelefono',iparms:[]");
         setEventMetadata("VALID_PROVEEDORTELEFONO",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORDIRECCION","{handler:'Valid_Proveedordireccion',iparms:[]");
         setEventMetadata("VALID_PROVEEDORDIRECCION",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDOREMAIL","{handler:'Valid_Proveedoremail',iparms:[]");
         setEventMetadata("VALID_PROVEEDOREMAIL",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORSITIOWEB","{handler:'Valid_Proveedorsitioweb',iparms:[]");
         setEventMetadata("VALID_PROVEEDORSITIOWEB",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORESTADO","{handler:'Valid_Proveedorestado',iparms:[]");
         setEventMetadata("VALID_PROVEEDORESTADO",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORPAGODEFAULT","{handler:'Valid_Proveedorpagodefault',iparms:[]");
         setEventMetadata("VALID_PROVEEDORPAGODEFAULT",",oparms:[]}");
         setEventMetadata("VALID_DOCUMENTACIONID","{handler:'Valid_Documentacionid',iparms:[]");
         setEventMetadata("VALID_DOCUMENTACIONID",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORUSRALTA","{handler:'Valid_Proveedorusralta',iparms:[]");
         setEventMetadata("VALID_PROVEEDORUSRALTA",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORUSRACTUALIZACION","{handler:'Valid_Proveedorusractualizacion',iparms:[]");
         setEventMetadata("VALID_PROVEEDORUSRACTUALIZACION",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Proveedorfechaactualizacion',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV16FilterFullText = "";
         AV32Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV18ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV26GridAppliedFilters = "";
         AV21DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV12GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         Ddo_grid_Caption = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtninsert_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV27Update = "";
         AV29Delete = "";
         A278ProveedoresTipoNombre = "";
         A282ProveedorNombre = "";
         A682ProveedorRazonSocial = "";
         A683ProveedorContacto = "";
         A684ProveedorContactoCell = "";
         A432ProveedorImagen = "";
         A40000ProveedorImagen_GXI = "";
         A338ProveedorDocIdentidad = "";
         A430ProveedorTelefono = "";
         A431ProveedorDireccion = "";
         A433ProveedorEmail = "";
         A685ProveedorSitioWeb = "";
         A686ProveedorAceptoTerminos = (DateTime)(DateTime.MinValue);
         A437ProveedorPerAltShop = "";
         A344ProveedorEstado = "";
         A440ProveedorPagoDefault = "";
         A490ProveedorPideDoc = "";
         A498DocumentacionIcono = "";
         A40001DocumentacionIcono_GXI = "";
         A548ProveedorFechaAlta = (DateTime)(DateTime.MinValue);
         A549ProveedorFechaActualizacion = (DateTime)(DateTime.MinValue);
         GXDecQS = "";
         lV16FilterFullText = "";
         H00BH2_A673BancoId = new long[1] ;
         H00BH2_n673BancoId = new bool[] {false} ;
         H00BH2_A549ProveedorFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         H00BH2_n549ProveedorFechaActualizacion = new bool[] {false} ;
         H00BH2_A548ProveedorFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H00BH2_n548ProveedorFechaAlta = new bool[] {false} ;
         H00BH2_A547ProveedorUsrActualizacion = new long[1] ;
         H00BH2_n547ProveedorUsrActualizacion = new bool[] {false} ;
         H00BH2_A546ProveedorUsrAlta = new long[1] ;
         H00BH2_n546ProveedorUsrAlta = new bool[] {false} ;
         H00BH2_A40001DocumentacionIcono_GXI = new string[] {""} ;
         H00BH2_A488DocumentacionId = new long[1] ;
         H00BH2_n488DocumentacionId = new bool[] {false} ;
         H00BH2_A490ProveedorPideDoc = new string[] {""} ;
         H00BH2_n490ProveedorPideDoc = new bool[] {false} ;
         H00BH2_A440ProveedorPagoDefault = new string[] {""} ;
         H00BH2_A344ProveedorEstado = new string[] {""} ;
         H00BH2_A437ProveedorPerAltShop = new string[] {""} ;
         H00BH2_n437ProveedorPerAltShop = new bool[] {false} ;
         H00BH2_A686ProveedorAceptoTerminos = new DateTime[] {DateTime.MinValue} ;
         H00BH2_n686ProveedorAceptoTerminos = new bool[] {false} ;
         H00BH2_A685ProveedorSitioWeb = new string[] {""} ;
         H00BH2_n685ProveedorSitioWeb = new bool[] {false} ;
         H00BH2_A433ProveedorEmail = new string[] {""} ;
         H00BH2_n433ProveedorEmail = new bool[] {false} ;
         H00BH2_A431ProveedorDireccion = new string[] {""} ;
         H00BH2_n431ProveedorDireccion = new bool[] {false} ;
         H00BH2_A430ProveedorTelefono = new string[] {""} ;
         H00BH2_n430ProveedorTelefono = new bool[] {false} ;
         H00BH2_A345ProveedorSerialComi = new short[1] ;
         H00BH2_A338ProveedorDocIdentidad = new string[] {""} ;
         H00BH2_A40000ProveedorImagen_GXI = new string[] {""} ;
         H00BH2_n40000ProveedorImagen_GXI = new bool[] {false} ;
         H00BH2_A684ProveedorContactoCell = new string[] {""} ;
         H00BH2_n684ProveedorContactoCell = new bool[] {false} ;
         H00BH2_A683ProveedorContacto = new string[] {""} ;
         H00BH2_n683ProveedorContacto = new bool[] {false} ;
         H00BH2_A682ProveedorRazonSocial = new string[] {""} ;
         H00BH2_n682ProveedorRazonSocial = new bool[] {false} ;
         H00BH2_A282ProveedorNombre = new string[] {""} ;
         H00BH2_A278ProveedoresTipoNombre = new string[] {""} ;
         H00BH2_A151ProveedoresTipoId = new long[1] ;
         H00BH2_A133ProveedorID = new long[1] ;
         H00BH2_A498DocumentacionIcono = new string[] {""} ;
         H00BH2_A432ProveedorImagen = new string[] {""} ;
         H00BH2_n432ProveedorImagen = new bool[] {false} ;
         H00BH3_A673BancoId = new long[1] ;
         H00BH3_n673BancoId = new bool[] {false} ;
         H00BH3_A549ProveedorFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         H00BH3_n549ProveedorFechaActualizacion = new bool[] {false} ;
         H00BH3_A548ProveedorFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H00BH3_n548ProveedorFechaAlta = new bool[] {false} ;
         H00BH3_A547ProveedorUsrActualizacion = new long[1] ;
         H00BH3_n547ProveedorUsrActualizacion = new bool[] {false} ;
         H00BH3_A546ProveedorUsrAlta = new long[1] ;
         H00BH3_n546ProveedorUsrAlta = new bool[] {false} ;
         H00BH3_A40001DocumentacionIcono_GXI = new string[] {""} ;
         H00BH3_A488DocumentacionId = new long[1] ;
         H00BH3_n488DocumentacionId = new bool[] {false} ;
         H00BH3_A490ProveedorPideDoc = new string[] {""} ;
         H00BH3_n490ProveedorPideDoc = new bool[] {false} ;
         H00BH3_A440ProveedorPagoDefault = new string[] {""} ;
         H00BH3_A344ProveedorEstado = new string[] {""} ;
         H00BH3_A437ProveedorPerAltShop = new string[] {""} ;
         H00BH3_n437ProveedorPerAltShop = new bool[] {false} ;
         H00BH3_A686ProveedorAceptoTerminos = new DateTime[] {DateTime.MinValue} ;
         H00BH3_n686ProveedorAceptoTerminos = new bool[] {false} ;
         H00BH3_A685ProveedorSitioWeb = new string[] {""} ;
         H00BH3_n685ProveedorSitioWeb = new bool[] {false} ;
         H00BH3_A433ProveedorEmail = new string[] {""} ;
         H00BH3_n433ProveedorEmail = new bool[] {false} ;
         H00BH3_A431ProveedorDireccion = new string[] {""} ;
         H00BH3_n431ProveedorDireccion = new bool[] {false} ;
         H00BH3_A430ProveedorTelefono = new string[] {""} ;
         H00BH3_n430ProveedorTelefono = new bool[] {false} ;
         H00BH3_A345ProveedorSerialComi = new short[1] ;
         H00BH3_A338ProveedorDocIdentidad = new string[] {""} ;
         H00BH3_A40000ProveedorImagen_GXI = new string[] {""} ;
         H00BH3_n40000ProveedorImagen_GXI = new bool[] {false} ;
         H00BH3_A684ProveedorContactoCell = new string[] {""} ;
         H00BH3_n684ProveedorContactoCell = new bool[] {false} ;
         H00BH3_A683ProveedorContacto = new string[] {""} ;
         H00BH3_n683ProveedorContacto = new bool[] {false} ;
         H00BH3_A682ProveedorRazonSocial = new string[] {""} ;
         H00BH3_n682ProveedorRazonSocial = new bool[] {false} ;
         H00BH3_A282ProveedorNombre = new string[] {""} ;
         H00BH3_A278ProveedoresTipoNombre = new string[] {""} ;
         H00BH3_A151ProveedoresTipoId = new long[1] ;
         H00BH3_A133ProveedorID = new long[1] ;
         H00BH3_A498DocumentacionIcono = new string[] {""} ;
         H00BH3_A432ProveedorImagen = new string[] {""} ;
         H00BH3_n432ProveedorImagen = new bool[] {false} ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV19ManageFiltersXml = "";
         GXt_char2 = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV17Session = context.GetSession();
         AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9HTTPRequest = new GxHttpRequest( context);
         AV11TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV8BancoId = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         gxphoneLink = "";
         sImgUrl = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancoproveedorwc__default(),
            new Object[][] {
                new Object[] {
               H00BH2_A673BancoId, H00BH2_n673BancoId, H00BH2_A549ProveedorFechaActualizacion, H00BH2_n549ProveedorFechaActualizacion, H00BH2_A548ProveedorFechaAlta, H00BH2_n548ProveedorFechaAlta, H00BH2_A547ProveedorUsrActualizacion, H00BH2_n547ProveedorUsrActualizacion, H00BH2_A546ProveedorUsrAlta, H00BH2_n546ProveedorUsrAlta,
               H00BH2_A40001DocumentacionIcono_GXI, H00BH2_A488DocumentacionId, H00BH2_n488DocumentacionId, H00BH2_A490ProveedorPideDoc, H00BH2_n490ProveedorPideDoc, H00BH2_A440ProveedorPagoDefault, H00BH2_A344ProveedorEstado, H00BH2_A437ProveedorPerAltShop, H00BH2_n437ProveedorPerAltShop, H00BH2_A686ProveedorAceptoTerminos,
               H00BH2_n686ProveedorAceptoTerminos, H00BH2_A685ProveedorSitioWeb, H00BH2_n685ProveedorSitioWeb, H00BH2_A433ProveedorEmail, H00BH2_n433ProveedorEmail, H00BH2_A431ProveedorDireccion, H00BH2_n431ProveedorDireccion, H00BH2_A430ProveedorTelefono, H00BH2_n430ProveedorTelefono, H00BH2_A345ProveedorSerialComi,
               H00BH2_A338ProveedorDocIdentidad, H00BH2_A40000ProveedorImagen_GXI, H00BH2_n40000ProveedorImagen_GXI, H00BH2_A684ProveedorContactoCell, H00BH2_n684ProveedorContactoCell, H00BH2_A683ProveedorContacto, H00BH2_n683ProveedorContacto, H00BH2_A682ProveedorRazonSocial, H00BH2_n682ProveedorRazonSocial, H00BH2_A282ProveedorNombre,
               H00BH2_A278ProveedoresTipoNombre, H00BH2_A151ProveedoresTipoId, H00BH2_A133ProveedorID, H00BH2_A498DocumentacionIcono, H00BH2_A432ProveedorImagen, H00BH2_n432ProveedorImagen
               }
               , new Object[] {
               H00BH3_A673BancoId, H00BH3_n673BancoId, H00BH3_A549ProveedorFechaActualizacion, H00BH3_n549ProveedorFechaActualizacion, H00BH3_A548ProveedorFechaAlta, H00BH3_n548ProveedorFechaAlta, H00BH3_A547ProveedorUsrActualizacion, H00BH3_n547ProveedorUsrActualizacion, H00BH3_A546ProveedorUsrAlta, H00BH3_n546ProveedorUsrAlta,
               H00BH3_A40001DocumentacionIcono_GXI, H00BH3_A488DocumentacionId, H00BH3_n488DocumentacionId, H00BH3_A490ProveedorPideDoc, H00BH3_n490ProveedorPideDoc, H00BH3_A440ProveedorPagoDefault, H00BH3_A344ProveedorEstado, H00BH3_A437ProveedorPerAltShop, H00BH3_n437ProveedorPerAltShop, H00BH3_A686ProveedorAceptoTerminos,
               H00BH3_n686ProveedorAceptoTerminos, H00BH3_A685ProveedorSitioWeb, H00BH3_n685ProveedorSitioWeb, H00BH3_A433ProveedorEmail, H00BH3_n433ProveedorEmail, H00BH3_A431ProveedorDireccion, H00BH3_n431ProveedorDireccion, H00BH3_A430ProveedorTelefono, H00BH3_n430ProveedorTelefono, H00BH3_A345ProveedorSerialComi,
               H00BH3_A338ProveedorDocIdentidad, H00BH3_A40000ProveedorImagen_GXI, H00BH3_n40000ProveedorImagen_GXI, H00BH3_A684ProveedorContactoCell, H00BH3_n684ProveedorContactoCell, H00BH3_A683ProveedorContacto, H00BH3_n683ProveedorContacto, H00BH3_A682ProveedorRazonSocial, H00BH3_n682ProveedorRazonSocial, H00BH3_A282ProveedorNombre,
               H00BH3_A278ProveedoresTipoNombre, H00BH3_A151ProveedoresTipoId, H00BH3_A133ProveedorID, H00BH3_A498DocumentacionIcono, H00BH3_A432ProveedorImagen, H00BH3_n432ProveedorImagen
               }
            }
         );
         AV32Pgmname = "BancoProveedorWC";
         /* GeneXus formulas. */
         AV32Pgmname = "BancoProveedorWC";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV14OrderedBy ;
      private short AV20ManageFiltersExecutionStep ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short A345ProveedorSerialComi ;
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
      private int nRC_GXsfl_37 ;
      private int nGXsfl_37_idx=1 ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int edtBancoId_Visible ;
      private int subGrid_Islastpage ;
      private int edtProveedorID_Enabled ;
      private int edtProveedoresTipoId_Enabled ;
      private int edtProveedoresTipoNombre_Enabled ;
      private int edtProveedorNombre_Enabled ;
      private int edtProveedorRazonSocial_Enabled ;
      private int edtProveedorContacto_Enabled ;
      private int edtProveedorContactoCell_Enabled ;
      private int edtProveedorImagen_Enabled ;
      private int edtProveedorDocIdentidad_Enabled ;
      private int edtProveedorSerialComi_Enabled ;
      private int edtProveedorTelefono_Enabled ;
      private int edtProveedorDireccion_Enabled ;
      private int edtProveedorEmail_Enabled ;
      private int edtProveedorSitioWeb_Enabled ;
      private int edtProveedorAceptoTerminos_Enabled ;
      private int edtDocumentacionId_Enabled ;
      private int edtDocumentacionIcono_Enabled ;
      private int edtProveedorUsrAlta_Enabled ;
      private int edtProveedorUsrActualizacion_Enabled ;
      private int edtProveedorFechaAlta_Enabled ;
      private int edtProveedorFechaActualizacion_Enabled ;
      private int edtBancoId_Enabled ;
      private int AV23PageToGo ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int AV33GXV1 ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV8BancoId ;
      private long wcpOAV8BancoId ;
      private long GRID_nFirstRecordOnPage ;
      private long AV24GridCurrentPage ;
      private long AV25GridPageCount ;
      private long A673BancoId ;
      private long A133ProveedorID ;
      private long A151ProveedoresTipoId ;
      private long A488DocumentacionId ;
      private long A546ProveedorUsrAlta ;
      private long A547ProveedorUsrActualizacion ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_37_idx="0001" ;
      private string AV32Pgmname ;
      private string edtavUpdate_Internalname ;
      private string edtavDelete_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
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
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
      private string Grid_empowerer_Gridinternalname ;
      private string Grid_empowerer_Fixedcolumns ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablegridheader_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string edtBancoId_Internalname ;
      private string edtBancoId_Jsonclick ;
      private string Grid_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavFilterfulltext_Internalname ;
      private string AV27Update ;
      private string AV29Delete ;
      private string edtProveedorID_Internalname ;
      private string edtProveedoresTipoId_Internalname ;
      private string A278ProveedoresTipoNombre ;
      private string edtProveedoresTipoNombre_Internalname ;
      private string A282ProveedorNombre ;
      private string edtProveedorNombre_Internalname ;
      private string A682ProveedorRazonSocial ;
      private string edtProveedorRazonSocial_Internalname ;
      private string A683ProveedorContacto ;
      private string edtProveedorContacto_Internalname ;
      private string A684ProveedorContactoCell ;
      private string edtProveedorContactoCell_Internalname ;
      private string edtProveedorImagen_Internalname ;
      private string A338ProveedorDocIdentidad ;
      private string edtProveedorDocIdentidad_Internalname ;
      private string edtProveedorSerialComi_Internalname ;
      private string A430ProveedorTelefono ;
      private string edtProveedorTelefono_Internalname ;
      private string edtProveedorDireccion_Internalname ;
      private string edtProveedorEmail_Internalname ;
      private string A685ProveedorSitioWeb ;
      private string edtProveedorSitioWeb_Internalname ;
      private string edtProveedorAceptoTerminos_Internalname ;
      private string cmbProveedorPerAltShop_Internalname ;
      private string A437ProveedorPerAltShop ;
      private string cmbProveedorEstado_Internalname ;
      private string A344ProveedorEstado ;
      private string cmbProveedorPagoDefault_Internalname ;
      private string A440ProveedorPagoDefault ;
      private string cmbProveedorPideDoc_Internalname ;
      private string A490ProveedorPideDoc ;
      private string edtDocumentacionId_Internalname ;
      private string edtDocumentacionIcono_Internalname ;
      private string edtProveedorUsrAlta_Internalname ;
      private string edtProveedorUsrActualizacion_Internalname ;
      private string edtProveedorFechaAlta_Internalname ;
      private string edtProveedorFechaActualizacion_Internalname ;
      private string GXDecQS ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string edtProveedorNombre_Link ;
      private string GXt_char2 ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sCtrlAV8BancoId ;
      private string sGXsfl_37_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string edtProveedorID_Jsonclick ;
      private string edtProveedoresTipoId_Jsonclick ;
      private string edtProveedoresTipoNombre_Jsonclick ;
      private string edtProveedorNombre_Jsonclick ;
      private string edtProveedorRazonSocial_Jsonclick ;
      private string edtProveedorContacto_Jsonclick ;
      private string gxphoneLink ;
      private string edtProveedorContactoCell_Jsonclick ;
      private string sImgUrl ;
      private string edtProveedorDocIdentidad_Jsonclick ;
      private string edtProveedorSerialComi_Jsonclick ;
      private string edtProveedorTelefono_Jsonclick ;
      private string edtProveedorDireccion_Jsonclick ;
      private string edtProveedorEmail_Jsonclick ;
      private string edtProveedorSitioWeb_Jsonclick ;
      private string edtProveedorAceptoTerminos_Jsonclick ;
      private string GXCCtl ;
      private string cmbProveedorPerAltShop_Jsonclick ;
      private string cmbProveedorEstado_Jsonclick ;
      private string cmbProveedorPagoDefault_Jsonclick ;
      private string cmbProveedorPideDoc_Jsonclick ;
      private string edtDocumentacionId_Jsonclick ;
      private string edtProveedorUsrAlta_Jsonclick ;
      private string edtProveedorUsrActualizacion_Jsonclick ;
      private string edtProveedorFechaAlta_Jsonclick ;
      private string edtProveedorFechaActualizacion_Jsonclick ;
      private string subGrid_Header ;
      private DateTime A686ProveedorAceptoTerminos ;
      private DateTime A548ProveedorFechaAlta ;
      private DateTime A549ProveedorFechaActualizacion ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV28IsAuthorized_Update ;
      private bool AV30IsAuthorized_Delete ;
      private bool bGXsfl_37_Refreshing=false ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n682ProveedorRazonSocial ;
      private bool n683ProveedorContacto ;
      private bool n684ProveedorContactoCell ;
      private bool n432ProveedorImagen ;
      private bool n430ProveedorTelefono ;
      private bool n431ProveedorDireccion ;
      private bool n433ProveedorEmail ;
      private bool n685ProveedorSitioWeb ;
      private bool n686ProveedorAceptoTerminos ;
      private bool n437ProveedorPerAltShop ;
      private bool n490ProveedorPideDoc ;
      private bool n488DocumentacionId ;
      private bool n546ProveedorUsrAlta ;
      private bool n547ProveedorUsrActualizacion ;
      private bool n548ProveedorFechaAlta ;
      private bool n549ProveedorFechaActualizacion ;
      private bool n673BancoId ;
      private bool n40000ProveedorImagen_GXI ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV31TempBoolean ;
      private bool GXt_boolean3 ;
      private bool A432ProveedorImagen_IsBlob ;
      private bool A498DocumentacionIcono_IsBlob ;
      private string AV19ManageFiltersXml ;
      private string AV16FilterFullText ;
      private string AV26GridAppliedFilters ;
      private string A40000ProveedorImagen_GXI ;
      private string A431ProveedorDireccion ;
      private string A433ProveedorEmail ;
      private string A40001DocumentacionIcono_GXI ;
      private string lV16FilterFullText ;
      private string A432ProveedorImagen ;
      private string A498DocumentacionIcono ;
      private IGxSession AV17Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDdo_managefilters ;
      private GXWebForm Form ;
      private GxHttpRequest AV9HTTPRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbProveedorPerAltShop ;
      private GXCombobox cmbProveedorEstado ;
      private GXCombobox cmbProveedorPagoDefault ;
      private GXCombobox cmbProveedorPideDoc ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV18ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV21DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV12GridState ;
      private IDataStoreProvider pr_default ;
      private long[] H00BH2_A673BancoId ;
      private bool[] H00BH2_n673BancoId ;
      private DateTime[] H00BH2_A549ProveedorFechaActualizacion ;
      private bool[] H00BH2_n549ProveedorFechaActualizacion ;
      private DateTime[] H00BH2_A548ProveedorFechaAlta ;
      private bool[] H00BH2_n548ProveedorFechaAlta ;
      private long[] H00BH2_A547ProveedorUsrActualizacion ;
      private bool[] H00BH2_n547ProveedorUsrActualizacion ;
      private long[] H00BH2_A546ProveedorUsrAlta ;
      private bool[] H00BH2_n546ProveedorUsrAlta ;
      private string[] H00BH2_A40001DocumentacionIcono_GXI ;
      private long[] H00BH2_A488DocumentacionId ;
      private bool[] H00BH2_n488DocumentacionId ;
      private string[] H00BH2_A490ProveedorPideDoc ;
      private bool[] H00BH2_n490ProveedorPideDoc ;
      private string[] H00BH2_A440ProveedorPagoDefault ;
      private string[] H00BH2_A344ProveedorEstado ;
      private string[] H00BH2_A437ProveedorPerAltShop ;
      private bool[] H00BH2_n437ProveedorPerAltShop ;
      private DateTime[] H00BH2_A686ProveedorAceptoTerminos ;
      private bool[] H00BH2_n686ProveedorAceptoTerminos ;
      private string[] H00BH2_A685ProveedorSitioWeb ;
      private bool[] H00BH2_n685ProveedorSitioWeb ;
      private string[] H00BH2_A433ProveedorEmail ;
      private bool[] H00BH2_n433ProveedorEmail ;
      private string[] H00BH2_A431ProveedorDireccion ;
      private bool[] H00BH2_n431ProveedorDireccion ;
      private string[] H00BH2_A430ProveedorTelefono ;
      private bool[] H00BH2_n430ProveedorTelefono ;
      private short[] H00BH2_A345ProveedorSerialComi ;
      private string[] H00BH2_A338ProveedorDocIdentidad ;
      private string[] H00BH2_A40000ProveedorImagen_GXI ;
      private bool[] H00BH2_n40000ProveedorImagen_GXI ;
      private string[] H00BH2_A684ProveedorContactoCell ;
      private bool[] H00BH2_n684ProveedorContactoCell ;
      private string[] H00BH2_A683ProveedorContacto ;
      private bool[] H00BH2_n683ProveedorContacto ;
      private string[] H00BH2_A682ProveedorRazonSocial ;
      private bool[] H00BH2_n682ProveedorRazonSocial ;
      private string[] H00BH2_A282ProveedorNombre ;
      private string[] H00BH2_A278ProveedoresTipoNombre ;
      private long[] H00BH2_A151ProveedoresTipoId ;
      private long[] H00BH2_A133ProveedorID ;
      private string[] H00BH2_A498DocumentacionIcono ;
      private string[] H00BH2_A432ProveedorImagen ;
      private bool[] H00BH2_n432ProveedorImagen ;
      private long[] H00BH3_A673BancoId ;
      private bool[] H00BH3_n673BancoId ;
      private DateTime[] H00BH3_A549ProveedorFechaActualizacion ;
      private bool[] H00BH3_n549ProveedorFechaActualizacion ;
      private DateTime[] H00BH3_A548ProveedorFechaAlta ;
      private bool[] H00BH3_n548ProveedorFechaAlta ;
      private long[] H00BH3_A547ProveedorUsrActualizacion ;
      private bool[] H00BH3_n547ProveedorUsrActualizacion ;
      private long[] H00BH3_A546ProveedorUsrAlta ;
      private bool[] H00BH3_n546ProveedorUsrAlta ;
      private string[] H00BH3_A40001DocumentacionIcono_GXI ;
      private long[] H00BH3_A488DocumentacionId ;
      private bool[] H00BH3_n488DocumentacionId ;
      private string[] H00BH3_A490ProveedorPideDoc ;
      private bool[] H00BH3_n490ProveedorPideDoc ;
      private string[] H00BH3_A440ProveedorPagoDefault ;
      private string[] H00BH3_A344ProveedorEstado ;
      private string[] H00BH3_A437ProveedorPerAltShop ;
      private bool[] H00BH3_n437ProveedorPerAltShop ;
      private DateTime[] H00BH3_A686ProveedorAceptoTerminos ;
      private bool[] H00BH3_n686ProveedorAceptoTerminos ;
      private string[] H00BH3_A685ProveedorSitioWeb ;
      private bool[] H00BH3_n685ProveedorSitioWeb ;
      private string[] H00BH3_A433ProveedorEmail ;
      private bool[] H00BH3_n433ProveedorEmail ;
      private string[] H00BH3_A431ProveedorDireccion ;
      private bool[] H00BH3_n431ProveedorDireccion ;
      private string[] H00BH3_A430ProveedorTelefono ;
      private bool[] H00BH3_n430ProveedorTelefono ;
      private short[] H00BH3_A345ProveedorSerialComi ;
      private string[] H00BH3_A338ProveedorDocIdentidad ;
      private string[] H00BH3_A40000ProveedorImagen_GXI ;
      private bool[] H00BH3_n40000ProveedorImagen_GXI ;
      private string[] H00BH3_A684ProveedorContactoCell ;
      private bool[] H00BH3_n684ProveedorContactoCell ;
      private string[] H00BH3_A683ProveedorContacto ;
      private bool[] H00BH3_n683ProveedorContacto ;
      private string[] H00BH3_A682ProveedorRazonSocial ;
      private bool[] H00BH3_n682ProveedorRazonSocial ;
      private string[] H00BH3_A282ProveedorNombre ;
      private string[] H00BH3_A278ProveedoresTipoNombre ;
      private long[] H00BH3_A151ProveedoresTipoId ;
      private long[] H00BH3_A133ProveedorID ;
      private string[] H00BH3_A498DocumentacionIcono ;
      private string[] H00BH3_A432ProveedorImagen ;
      private bool[] H00BH3_n432ProveedorImagen ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV13GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV10TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV11TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class bancoproveedorwc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00BH2( IGxContext context ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV16FilterFullText ,
                                             long A133ProveedorID ,
                                             long A151ProveedoresTipoId ,
                                             string A278ProveedoresTipoNombre ,
                                             string A282ProveedorNombre ,
                                             string A682ProveedorRazonSocial ,
                                             string A683ProveedorContacto ,
                                             string A684ProveedorContactoCell ,
                                             string A338ProveedorDocIdentidad ,
                                             string A430ProveedorTelefono ,
                                             string A431ProveedorDireccion ,
                                             string A433ProveedorEmail ,
                                             string A685ProveedorSitioWeb ,
                                             string A344ProveedorEstado ,
                                             string A440ProveedorPagoDefault ,
                                             long A546ProveedorUsrAlta ,
                                             long A547ProveedorUsrActualizacion ,
                                             long AV8BancoId ,
                                             long A673BancoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[1];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[BancoId], T1.[ProveedorFechaActualizacion], T1.[ProveedorFechaAlta], T1.[ProveedorUsrActualizacion], T1.[ProveedorUsrAlta], T2.[DocumentacionIcono_GXI], T1.[DocumentacionId], T1.[ProveedorPideDoc], T1.[ProveedorPagoDefault], T1.[ProveedorEstado], T1.[ProveedorPerAltShop], T1.[ProveedorAceptoTerminos], T1.[ProveedorSitioWeb], T1.[ProveedorEmail], T1.[ProveedorDireccion], T1.[ProveedorTelefono], T1.[ProveedorSerialComi], T1.[ProveedorDocIdentidad], T1.[ProveedorImagen_GXI], T1.[ProveedorContactoCell], T1.[ProveedorContacto], T1.[ProveedorRazonSocial], T1.[ProveedorNombre], T3.[ProveedoresTipoNombre], T1.[ProveedoresTipoId], T1.[ProveedorID], T2.[DocumentacionIcono], T1.[ProveedorImagen] FROM (([Proveedor] T1 LEFT JOIN [Documentacion] T2 ON T2.[DocumentacionId] = T1.[DocumentacionId]) INNER JOIN [ProveedoresTipo] T3 ON T3.[ProveedoresTipoId] = T1.[ProveedoresTipoId])";
         AddWhere(sWhereString, "(T1.[BancoId] = @AV8BancoId)");
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorNombre]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorID]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorID] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedoresTipoId]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedoresTipoId] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T3.[ProveedoresTipoNombre]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T3.[ProveedoresTipoNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorRazonSocial]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorRazonSocial] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorContacto]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorContacto] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorContactoCell]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorContactoCell] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorDocIdentidad]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorDocIdentidad] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorTelefono]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorTelefono] DESC";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorDireccion]";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorDireccion] DESC";
         }
         else if ( ( AV14OrderedBy == 11 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorEmail]";
         }
         else if ( ( AV14OrderedBy == 11 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorEmail] DESC";
         }
         else if ( ( AV14OrderedBy == 12 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorSitioWeb]";
         }
         else if ( ( AV14OrderedBy == 12 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorSitioWeb] DESC";
         }
         else if ( ( AV14OrderedBy == 13 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorAceptoTerminos]";
         }
         else if ( ( AV14OrderedBy == 13 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorAceptoTerminos] DESC";
         }
         else if ( ( AV14OrderedBy == 14 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorEstado]";
         }
         else if ( ( AV14OrderedBy == 14 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorEstado] DESC";
         }
         else if ( ( AV14OrderedBy == 15 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorPagoDefault]";
         }
         else if ( ( AV14OrderedBy == 15 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorPagoDefault] DESC";
         }
         else if ( ( AV14OrderedBy == 16 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorUsrAlta]";
         }
         else if ( ( AV14OrderedBy == 16 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorUsrAlta] DESC";
         }
         else if ( ( AV14OrderedBy == 17 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorUsrActualizacion]";
         }
         else if ( ( AV14OrderedBy == 17 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorUsrActualizacion] DESC";
         }
         else if ( ( AV14OrderedBy == 18 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorFechaAlta]";
         }
         else if ( ( AV14OrderedBy == 18 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorFechaAlta] DESC";
         }
         else if ( ( AV14OrderedBy == 19 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorFechaActualizacion]";
         }
         else if ( ( AV14OrderedBy == 19 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorFechaActualizacion] DESC";
         }
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H00BH3( IGxContext context ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV16FilterFullText ,
                                             long A133ProveedorID ,
                                             long A151ProveedoresTipoId ,
                                             string A278ProveedoresTipoNombre ,
                                             string A282ProveedorNombre ,
                                             string A682ProveedorRazonSocial ,
                                             string A683ProveedorContacto ,
                                             string A684ProveedorContactoCell ,
                                             string A338ProveedorDocIdentidad ,
                                             string A430ProveedorTelefono ,
                                             string A431ProveedorDireccion ,
                                             string A433ProveedorEmail ,
                                             string A685ProveedorSitioWeb ,
                                             string A344ProveedorEstado ,
                                             string A440ProveedorPagoDefault ,
                                             long A546ProveedorUsrAlta ,
                                             long A547ProveedorUsrActualizacion ,
                                             long AV8BancoId ,
                                             long A673BancoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[1];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.[BancoId], T1.[ProveedorFechaActualizacion], T1.[ProveedorFechaAlta], T1.[ProveedorUsrActualizacion], T1.[ProveedorUsrAlta], T2.[DocumentacionIcono_GXI], T1.[DocumentacionId], T1.[ProveedorPideDoc], T1.[ProveedorPagoDefault], T1.[ProveedorEstado], T1.[ProveedorPerAltShop], T1.[ProveedorAceptoTerminos], T1.[ProveedorSitioWeb], T1.[ProveedorEmail], T1.[ProveedorDireccion], T1.[ProveedorTelefono], T1.[ProveedorSerialComi], T1.[ProveedorDocIdentidad], T1.[ProveedorImagen_GXI], T1.[ProveedorContactoCell], T1.[ProveedorContacto], T1.[ProveedorRazonSocial], T1.[ProveedorNombre], T3.[ProveedoresTipoNombre], T1.[ProveedoresTipoId], T1.[ProveedorID], T2.[DocumentacionIcono], T1.[ProveedorImagen] FROM (([Proveedor] T1 LEFT JOIN [Documentacion] T2 ON T2.[DocumentacionId] = T1.[DocumentacionId]) INNER JOIN [ProveedoresTipo] T3 ON T3.[ProveedoresTipoId] = T1.[ProveedoresTipoId])";
         AddWhere(sWhereString, "(T1.[BancoId] = @AV8BancoId)");
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorNombre]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorID]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorID] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedoresTipoId]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedoresTipoId] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T3.[ProveedoresTipoNombre]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T3.[ProveedoresTipoNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorRazonSocial]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorRazonSocial] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorContacto]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorContacto] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorContactoCell]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorContactoCell] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorDocIdentidad]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorDocIdentidad] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorTelefono]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorTelefono] DESC";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorDireccion]";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorDireccion] DESC";
         }
         else if ( ( AV14OrderedBy == 11 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorEmail]";
         }
         else if ( ( AV14OrderedBy == 11 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorEmail] DESC";
         }
         else if ( ( AV14OrderedBy == 12 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorSitioWeb]";
         }
         else if ( ( AV14OrderedBy == 12 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorSitioWeb] DESC";
         }
         else if ( ( AV14OrderedBy == 13 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorAceptoTerminos]";
         }
         else if ( ( AV14OrderedBy == 13 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorAceptoTerminos] DESC";
         }
         else if ( ( AV14OrderedBy == 14 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorEstado]";
         }
         else if ( ( AV14OrderedBy == 14 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorEstado] DESC";
         }
         else if ( ( AV14OrderedBy == 15 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorPagoDefault]";
         }
         else if ( ( AV14OrderedBy == 15 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorPagoDefault] DESC";
         }
         else if ( ( AV14OrderedBy == 16 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorUsrAlta]";
         }
         else if ( ( AV14OrderedBy == 16 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorUsrAlta] DESC";
         }
         else if ( ( AV14OrderedBy == 17 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorUsrActualizacion]";
         }
         else if ( ( AV14OrderedBy == 17 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorUsrActualizacion] DESC";
         }
         else if ( ( AV14OrderedBy == 18 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorFechaAlta]";
         }
         else if ( ( AV14OrderedBy == 18 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorFechaAlta] DESC";
         }
         else if ( ( AV14OrderedBy == 19 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[BancoId], T1.[ProveedorFechaActualizacion]";
         }
         else if ( ( AV14OrderedBy == 19 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[BancoId] DESC, T1.[ProveedorFechaActualizacion] DESC";
         }
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00BH2(context, (short)dynConstraints[0] , (bool)dynConstraints[1] , (string)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (long)dynConstraints[17] , (long)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] );
               case 1 :
                     return conditional_H00BH3(context, (short)dynConstraints[0] , (bool)dynConstraints[1] , (string)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (long)dynConstraints[17] , (long)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] );
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
          Object[] prmH00BH2;
          prmH00BH2 = new Object[] {
          new ParDef("@AV8BancoId",GXType.Decimal,18,0)
          };
          Object[] prmH00BH3;
          prmH00BH3 = new Object[] {
          new ParDef("@AV8BancoId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00BH2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BH2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00BH3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BH3,11, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((long[]) buf[6])[0] = rslt.getLong(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((long[]) buf[8])[0] = rslt.getLong(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getMultimediaUri(6);
                ((long[]) buf[11])[0] = rslt.getLong(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getString(8, 1);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getString(9, 1);
                ((string[]) buf[16])[0] = rslt.getString(10, 3);
                ((string[]) buf[17])[0] = rslt.getString(11, 1);
                ((bool[]) buf[18])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[19])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[20])[0] = rslt.wasNull(12);
                ((string[]) buf[21])[0] = rslt.getString(13, 128);
                ((bool[]) buf[22])[0] = rslt.wasNull(13);
                ((string[]) buf[23])[0] = rslt.getVarchar(14);
                ((bool[]) buf[24])[0] = rslt.wasNull(14);
                ((string[]) buf[25])[0] = rslt.getVarchar(15);
                ((bool[]) buf[26])[0] = rslt.wasNull(15);
                ((string[]) buf[27])[0] = rslt.getString(16, 20);
                ((bool[]) buf[28])[0] = rslt.wasNull(16);
                ((short[]) buf[29])[0] = rslt.getShort(17);
                ((string[]) buf[30])[0] = rslt.getString(18, 25);
                ((string[]) buf[31])[0] = rslt.getMultimediaUri(19);
                ((bool[]) buf[32])[0] = rslt.wasNull(19);
                ((string[]) buf[33])[0] = rslt.getString(20, 20);
                ((bool[]) buf[34])[0] = rslt.wasNull(20);
                ((string[]) buf[35])[0] = rslt.getString(21, 128);
                ((bool[]) buf[36])[0] = rslt.wasNull(21);
                ((string[]) buf[37])[0] = rslt.getString(22, 25);
                ((bool[]) buf[38])[0] = rslt.wasNull(22);
                ((string[]) buf[39])[0] = rslt.getString(23, 80);
                ((string[]) buf[40])[0] = rslt.getString(24, 120);
                ((long[]) buf[41])[0] = rslt.getLong(25);
                ((long[]) buf[42])[0] = rslt.getLong(26);
                ((string[]) buf[43])[0] = rslt.getMultimediaFile(27, rslt.getVarchar(6));
                ((string[]) buf[44])[0] = rslt.getMultimediaFile(28, rslt.getVarchar(19));
                ((bool[]) buf[45])[0] = rslt.wasNull(28);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((long[]) buf[6])[0] = rslt.getLong(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((long[]) buf[8])[0] = rslt.getLong(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getMultimediaUri(6);
                ((long[]) buf[11])[0] = rslt.getLong(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getString(8, 1);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getString(9, 1);
                ((string[]) buf[16])[0] = rslt.getString(10, 3);
                ((string[]) buf[17])[0] = rslt.getString(11, 1);
                ((bool[]) buf[18])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[19])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[20])[0] = rslt.wasNull(12);
                ((string[]) buf[21])[0] = rslt.getString(13, 128);
                ((bool[]) buf[22])[0] = rslt.wasNull(13);
                ((string[]) buf[23])[0] = rslt.getVarchar(14);
                ((bool[]) buf[24])[0] = rslt.wasNull(14);
                ((string[]) buf[25])[0] = rslt.getVarchar(15);
                ((bool[]) buf[26])[0] = rslt.wasNull(15);
                ((string[]) buf[27])[0] = rslt.getString(16, 20);
                ((bool[]) buf[28])[0] = rslt.wasNull(16);
                ((short[]) buf[29])[0] = rslt.getShort(17);
                ((string[]) buf[30])[0] = rslt.getString(18, 25);
                ((string[]) buf[31])[0] = rslt.getMultimediaUri(19);
                ((bool[]) buf[32])[0] = rslt.wasNull(19);
                ((string[]) buf[33])[0] = rslt.getString(20, 20);
                ((bool[]) buf[34])[0] = rslt.wasNull(20);
                ((string[]) buf[35])[0] = rslt.getString(21, 128);
                ((bool[]) buf[36])[0] = rslt.wasNull(21);
                ((string[]) buf[37])[0] = rslt.getString(22, 25);
                ((bool[]) buf[38])[0] = rslt.wasNull(22);
                ((string[]) buf[39])[0] = rslt.getString(23, 80);
                ((string[]) buf[40])[0] = rslt.getString(24, 120);
                ((long[]) buf[41])[0] = rslt.getLong(25);
                ((long[]) buf[42])[0] = rslt.getLong(26);
                ((string[]) buf[43])[0] = rslt.getMultimediaFile(27, rslt.getVarchar(6));
                ((string[]) buf[44])[0] = rslt.getMultimediaFile(28, rslt.getVarchar(19));
                ((bool[]) buf[45])[0] = rslt.wasNull(28);
                return;
       }
    }

 }

}
