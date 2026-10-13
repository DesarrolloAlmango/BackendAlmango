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
   public class listacostosdetalleswc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public listacostosdetalleswc( )
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

      public listacostosdetalleswc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ListaCostosId )
      {
         this.AV8ListaCostosId = aP0_ListaCostosId;
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
         cmbavGridactions = new GXCombobox();
         cmbCentroCostosEstado = new GXCombobox();
         cmbCentroCostosTipoRef = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "ListaCostosId");
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
                  AV8ListaCostosId = (long)(Math.Round(NumberUtil.Val( GetPar( "ListaCostosId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV8ListaCostosId", StringUtil.LTrimStr( (decimal)(AV8ListaCostosId), 18, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)AV8ListaCostosId});
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
                  gxfirstwebparm = GetFirstPar( "ListaCostosId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ListaCostosId");
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
         AV8ListaCostosId = (long)(Math.Round(NumberUtil.Val( GetPar( "ListaCostosId"), "."), 18, MidpointRounding.ToEven));
         AV20ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV52Pgmname = GetPar( "Pgmname");
         AV21TFCentroCostosId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFCentroCostosId"), "."), 18, MidpointRounding.ToEven));
         AV22TFCentroCostosId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFCentroCostosId_To"), "."), 18, MidpointRounding.ToEven));
         AV23TFCentroCostosRef = (long)(Math.Round(NumberUtil.Val( GetPar( "TFCentroCostosRef"), "."), 18, MidpointRounding.ToEven));
         AV24TFCentroCostosRef_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFCentroCostosRef_To"), "."), 18, MidpointRounding.ToEven));
         AV25TFCentroCostosNombre = GetPar( "TFCentroCostosNombre");
         AV26TFCentroCostosNombre_Sel = GetPar( "TFCentroCostosNombre_Sel");
         AV27TFCentroCostosPrecioFinal = NumberUtil.Val( GetPar( "TFCentroCostosPrecioFinal"), ".");
         AV28TFCentroCostosPrecioFinal_To = NumberUtil.Val( GetPar( "TFCentroCostosPrecioFinal_To"), ".");
         AV29TFCentroCostosCosto = NumberUtil.Val( GetPar( "TFCentroCostosCosto"), ".");
         AV30TFCentroCostosCosto_To = NumberUtil.Val( GetPar( "TFCentroCostosCosto_To"), ".");
         AV31TFCentroCostosUsrAlta = GetPar( "TFCentroCostosUsrAlta");
         AV32TFCentroCostosUsrAlta_Sel = GetPar( "TFCentroCostosUsrAlta_Sel");
         AV33TFCentroCostosHoraAlt = context.localUtil.ParseDateParm( GetPar( "TFCentroCostosHoraAlt"));
         AV34TFCentroCostosHoraAlt_To = context.localUtil.ParseDateParm( GetPar( "TFCentroCostosHoraAlt_To"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV39TFCentroCostosEstado_Sels);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV41TFCentroCostosTipoRef_Sels);
         AV49IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV50IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8ListaCostosId, AV20ManageFiltersExecutionStep, AV52Pgmname, AV21TFCentroCostosId, AV22TFCentroCostosId_To, AV23TFCentroCostosRef, AV24TFCentroCostosRef_To, AV25TFCentroCostosNombre, AV26TFCentroCostosNombre_Sel, AV27TFCentroCostosPrecioFinal, AV28TFCentroCostosPrecioFinal_To, AV29TFCentroCostosCosto, AV30TFCentroCostosCosto_To, AV31TFCentroCostosUsrAlta, AV32TFCentroCostosUsrAlta_Sel, AV33TFCentroCostosHoraAlt, AV34TFCentroCostosHoraAlt_To, AV39TFCentroCostosEstado_Sels, AV41TFCentroCostosTipoRef_Sels, AV49IsAuthorized_Update, AV50IsAuthorized_Delete, sPrefix) ;
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
            PA3Y2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV52Pgmname = "ListaCostosDetallesWC";
               WS3Y2( ) ;
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
            context.SendWebValue( context.GetMessage( "Lista Costos Detalles WC", "")) ;
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
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
            GXEncryptionTmp = "listacostosdetalleswc.aspx"+UrlEncode(StringUtil.LTrimStr(AV8ListaCostosId,18,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("listacostosdetalleswc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV52Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV52Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV49IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV49IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV50IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV50IsAuthorized_Delete, context));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDAPPLIEDFILTERS", AV47GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV42DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV42DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_CENTROCOSTOSHORAALTAUXDATETO", context.localUtil.DToC( AV36DDO_CentroCostosHoraAltAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8ListaCostosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV8ListaCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV52Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV52Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV15OrderedDsc);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21TFCentroCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22TFCentroCostosId_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSREF", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23TFCentroCostosRef), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSREF_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24TFCentroCostosRef_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSNOMBRE", StringUtil.RTrim( AV25TFCentroCostosNombre));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSNOMBRE_SEL", StringUtil.RTrim( AV26TFCentroCostosNombre_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSPRECIOFINAL", StringUtil.LTrim( StringUtil.NToC( AV27TFCentroCostosPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSPRECIOFINAL_TO", StringUtil.LTrim( StringUtil.NToC( AV28TFCentroCostosPrecioFinal_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSCOSTO", StringUtil.LTrim( StringUtil.NToC( AV29TFCentroCostosCosto, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSCOSTO_TO", StringUtil.LTrim( StringUtil.NToC( AV30TFCentroCostosCosto_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSUSRALTA", StringUtil.RTrim( AV31TFCentroCostosUsrAlta));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSUSRALTA_SEL", StringUtil.RTrim( AV32TFCentroCostosUsrAlta_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSHORAALT", context.localUtil.DToC( AV33TFCentroCostosHoraAlt, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSHORAALT_TO", context.localUtil.DToC( AV34TFCentroCostosHoraAlt_To, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTFCENTROCOSTOSESTADO_SELS", AV39TFCentroCostosEstado_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTFCENTROCOSTOSESTADO_SELS", AV39TFCentroCostosEstado_Sels);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTFCENTROCOSTOSTIPOREF_SELS", AV41TFCentroCostosTipoRef_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTFCENTROCOSTOSTIPOREF_SELS", AV41TFCentroCostosTipoRef_Sels);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vLISTACOSTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8ListaCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV49IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV49IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV50IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV50IsAuthorized_Delete, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDSTATE", AV12GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDSTATE", AV12GridState);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSESTADO_SELSJSON", AV38TFCentroCostosEstado_SelsJson);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFCENTROCOSTOSTIPOREF_SELSJSON", AV40TFCentroCostosTipoRef_SelsJson);
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_CENTROCOSTOSHORAALTAUXDATE", context.localUtil.DToC( AV35DDO_CentroCostosHoraAltAuxDate, 0, "/"));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm3Y2( )
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
         return "ListaCostosDetallesWC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Lista Costos Detalles WC", "") ;
      }

      protected void WB3Y0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "listacostosdetalleswc.aspx");
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
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ListaCostosDetallesWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_22_3Y2( true) ;
         }
         else
         {
            wb_table1_22_3Y2( false) ;
         }
         return  ;
      }

      protected void wb_table1_22_3Y2e( bool wbgen )
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV45GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV46GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV47GridAppliedFilters);
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
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("AllowMultipleSelection", Ddo_grid_Allowmultipleselection);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV42DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtListaCostosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A459ListaCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A459ListaCostosId), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtListaCostosId_Jsonclick, 0, "Attribute", "", "", "", "", edtListaCostosId_Visible, 0, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ListaCostosDetallesWC.htm");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_centrocostoshoraaltauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'" + sPrefix + "',false,'" + sGXsfl_37_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_centrocostoshoraaltauxdatetext_Internalname, AV37DDO_CentroCostosHoraAltAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV37DDO_CentroCostosHoraAltAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_centrocostoshoraaltauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ListaCostosDetallesWC.htm");
            /* User Defined Control */
            ucTfcentrocostoshoraalt_rangepicker.SetProperty("Start Date", AV35DDO_CentroCostosHoraAltAuxDate);
            ucTfcentrocostoshoraalt_rangepicker.SetProperty("End Date", AV36DDO_CentroCostosHoraAltAuxDateTo);
            ucTfcentrocostoshoraalt_rangepicker.Render(context, "wwp.daterangepicker", Tfcentrocostoshoraalt_rangepicker_Internalname, sPrefix+"TFCENTROCOSTOSHORAALT_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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

      protected void START3Y2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Lista Costos Detalles WC", ""), 0) ;
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
               STRUP3Y0( ) ;
            }
         }
      }

      protected void WS3Y2( )
      {
         START3Y2( ) ;
         EVT3Y2( ) ;
      }

      protected void EVT3Y2( )
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
                                 STRUP3Y0( ) ;
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
                                 STRUP3Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_managefilters.Onoptionclicked */
                                    E113Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E123Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E133Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E143Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoInsert' */
                                    E153Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = cmbavGridactions_Internalname;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
                              }
                              nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
                              SubsflControlProps_372( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV48GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri(sPrefix, false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV48GridActions), 4, 0));
                              A461CentroCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCentroCostosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A462CentroCostosRef = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCentroCostosRef_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A463CentroCostosNombre = cgiGet( edtCentroCostosNombre_Internalname);
                              A464CentroCostosPrecioFinal = context.localUtil.CToN( cgiGet( edtCentroCostosPrecioFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A465CentroCostosSerial = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCentroCostosSerial_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A475CentroCostosCosto = context.localUtil.CToN( cgiGet( edtCentroCostosCosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A478CentroCostosUsrAlta = cgiGet( edtCentroCostosUsrAlta_Internalname);
                              A480CentroCostosHoraAlt = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtCentroCostosHoraAlt_Internalname), 0));
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
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavGridactions_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E163Y2 ();
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
                                          GX_FocusControl = cmbavGridactions_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E173Y2 ();
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
                                          GX_FocusControl = cmbavGridactions_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E183Y2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavGridactions_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E193Y2 ();
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
                                       STRUP3Y0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavGridactions_Internalname;
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

      protected void WE3Y2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm3Y2( ) ;
            }
         }
      }

      protected void PA3Y2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "listacostosdetalleswc.aspx")), "listacostosdetalleswc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "listacostosdetalleswc.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "ListaCostosId");
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
                                       long AV8ListaCostosId ,
                                       short AV20ManageFiltersExecutionStep ,
                                       string AV52Pgmname ,
                                       long AV21TFCentroCostosId ,
                                       long AV22TFCentroCostosId_To ,
                                       long AV23TFCentroCostosRef ,
                                       long AV24TFCentroCostosRef_To ,
                                       string AV25TFCentroCostosNombre ,
                                       string AV26TFCentroCostosNombre_Sel ,
                                       decimal AV27TFCentroCostosPrecioFinal ,
                                       decimal AV28TFCentroCostosPrecioFinal_To ,
                                       decimal AV29TFCentroCostosCosto ,
                                       decimal AV30TFCentroCostosCosto_To ,
                                       string AV31TFCentroCostosUsrAlta ,
                                       string AV32TFCentroCostosUsrAlta_Sel ,
                                       DateTime AV33TFCentroCostosHoraAlt ,
                                       DateTime AV34TFCentroCostosHoraAlt_To ,
                                       GxSimpleCollection<string> AV39TFCentroCostosEstado_Sels ,
                                       GxSimpleCollection<string> AV41TFCentroCostosTipoRef_Sels ,
                                       bool AV49IsAuthorized_Update ,
                                       bool AV50IsAuthorized_Delete ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF3Y2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_CENTROCOSTOSID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A461CentroCostosId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"CENTROCOSTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A461CentroCostosId), 18, 0, ".", "")));
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
         RF3Y2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV52Pgmname = "ListaCostosDetallesWC";
      }

      protected int subGridclient_rec_count_fnc( )
      {
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A482CentroCostosEstado ,
                                              AV39TFCentroCostosEstado_Sels ,
                                              A487CentroCostosTipoRef ,
                                              AV41TFCentroCostosTipoRef_Sels ,
                                              AV21TFCentroCostosId ,
                                              AV22TFCentroCostosId_To ,
                                              AV23TFCentroCostosRef ,
                                              AV24TFCentroCostosRef_To ,
                                              AV26TFCentroCostosNombre_Sel ,
                                              AV25TFCentroCostosNombre ,
                                              AV27TFCentroCostosPrecioFinal ,
                                              AV28TFCentroCostosPrecioFinal_To ,
                                              AV29TFCentroCostosCosto ,
                                              AV30TFCentroCostosCosto_To ,
                                              AV32TFCentroCostosUsrAlta_Sel ,
                                              AV31TFCentroCostosUsrAlta ,
                                              AV33TFCentroCostosHoraAlt ,
                                              AV34TFCentroCostosHoraAlt_To ,
                                              AV39TFCentroCostosEstado_Sels.Count ,
                                              AV41TFCentroCostosTipoRef_Sels.Count ,
                                              A461CentroCostosId ,
                                              A462CentroCostosRef ,
                                              A463CentroCostosNombre ,
                                              A464CentroCostosPrecioFinal ,
                                              A475CentroCostosCosto ,
                                              A478CentroCostosUsrAlta ,
                                              A480CentroCostosHoraAlt ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              AV16FilterFullText ,
                                              AV8ListaCostosId ,
                                              A459ListaCostosId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV25TFCentroCostosNombre = StringUtil.PadR( StringUtil.RTrim( AV25TFCentroCostosNombre), 80, "%");
         lV31TFCentroCostosUsrAlta = StringUtil.PadR( StringUtil.RTrim( AV31TFCentroCostosUsrAlta), 30, "%");
         /* Using cursor H003Y2 */
         pr_default.execute(0, new Object[] {AV8ListaCostosId, AV21TFCentroCostosId, AV22TFCentroCostosId_To, AV23TFCentroCostosRef, AV24TFCentroCostosRef_To, lV25TFCentroCostosNombre, AV26TFCentroCostosNombre_Sel, AV27TFCentroCostosPrecioFinal, AV28TFCentroCostosPrecioFinal_To, AV29TFCentroCostosCosto, AV30TFCentroCostosCosto_To, lV31TFCentroCostosUsrAlta, AV32TFCentroCostosUsrAlta_Sel, AV33TFCentroCostosHoraAlt, AV34TFCentroCostosHoraAlt_To});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A459ListaCostosId = H003Y2_A459ListaCostosId[0];
            n459ListaCostosId = H003Y2_n459ListaCostosId[0];
            AssignAttri(sPrefix, false, "A459ListaCostosId", StringUtil.LTrimStr( (decimal)(A459ListaCostosId), 18, 0));
            A487CentroCostosTipoRef = H003Y2_A487CentroCostosTipoRef[0];
            A482CentroCostosEstado = H003Y2_A482CentroCostosEstado[0];
            A480CentroCostosHoraAlt = H003Y2_A480CentroCostosHoraAlt[0];
            A478CentroCostosUsrAlta = H003Y2_A478CentroCostosUsrAlta[0];
            A475CentroCostosCosto = H003Y2_A475CentroCostosCosto[0];
            A465CentroCostosSerial = H003Y2_A465CentroCostosSerial[0];
            A464CentroCostosPrecioFinal = H003Y2_A464CentroCostosPrecioFinal[0];
            A463CentroCostosNombre = H003Y2_A463CentroCostosNombre[0];
            A462CentroCostosRef = H003Y2_A462CentroCostosRef[0];
            A461CentroCostosId = H003Y2_A461CentroCostosId[0];
            A487CentroCostosTipoRef = H003Y2_A487CentroCostosTipoRef[0];
            A482CentroCostosEstado = H003Y2_A482CentroCostosEstado[0];
            A480CentroCostosHoraAlt = H003Y2_A480CentroCostosHoraAlt[0];
            A478CentroCostosUsrAlta = H003Y2_A478CentroCostosUsrAlta[0];
            A475CentroCostosCosto = H003Y2_A475CentroCostosCosto[0];
            A465CentroCostosSerial = H003Y2_A465CentroCostosSerial[0];
            A464CentroCostosPrecioFinal = H003Y2_A464CentroCostosPrecioFinal[0];
            A463CentroCostosNombre = H003Y2_A463CentroCostosNombre[0];
            A462CentroCostosRef = H003Y2_A462CentroCostosRef[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A461CentroCostosId), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A462CentroCostosRef), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A463CentroCostosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A464CentroCostosPrecioFinal, 18, 2) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A475CentroCostosCosto, 18, 2) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A478CentroCostosUsrAlta) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "aprobado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A482CentroCostosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente de aprobación", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "PND") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "desaprobado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "servicios", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A487CentroCostosTipoRef, "S") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A487CentroCostosTipoRef, "O") == 0 ) ) )
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

      protected void RF3Y2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 37;
         /* Execute user event: Refresh */
         E173Y2 ();
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
                                                 A482CentroCostosEstado ,
                                                 AV39TFCentroCostosEstado_Sels ,
                                                 A487CentroCostosTipoRef ,
                                                 AV41TFCentroCostosTipoRef_Sels ,
                                                 AV21TFCentroCostosId ,
                                                 AV22TFCentroCostosId_To ,
                                                 AV23TFCentroCostosRef ,
                                                 AV24TFCentroCostosRef_To ,
                                                 AV26TFCentroCostosNombre_Sel ,
                                                 AV25TFCentroCostosNombre ,
                                                 AV27TFCentroCostosPrecioFinal ,
                                                 AV28TFCentroCostosPrecioFinal_To ,
                                                 AV29TFCentroCostosCosto ,
                                                 AV30TFCentroCostosCosto_To ,
                                                 AV32TFCentroCostosUsrAlta_Sel ,
                                                 AV31TFCentroCostosUsrAlta ,
                                                 AV33TFCentroCostosHoraAlt ,
                                                 AV34TFCentroCostosHoraAlt_To ,
                                                 AV39TFCentroCostosEstado_Sels.Count ,
                                                 AV41TFCentroCostosTipoRef_Sels.Count ,
                                                 A461CentroCostosId ,
                                                 A462CentroCostosRef ,
                                                 A463CentroCostosNombre ,
                                                 A464CentroCostosPrecioFinal ,
                                                 A475CentroCostosCosto ,
                                                 A478CentroCostosUsrAlta ,
                                                 A480CentroCostosHoraAlt ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 AV16FilterFullText ,
                                                 AV8ListaCostosId ,
                                                 A459ListaCostosId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE,
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG,
                                                 TypeConstants.LONG, TypeConstants.BOOLEAN
                                                 }
            });
            lV25TFCentroCostosNombre = StringUtil.PadR( StringUtil.RTrim( AV25TFCentroCostosNombre), 80, "%");
            lV31TFCentroCostosUsrAlta = StringUtil.PadR( StringUtil.RTrim( AV31TFCentroCostosUsrAlta), 30, "%");
            /* Using cursor H003Y3 */
            pr_default.execute(1, new Object[] {AV8ListaCostosId, AV21TFCentroCostosId, AV22TFCentroCostosId_To, AV23TFCentroCostosRef, AV24TFCentroCostosRef_To, lV25TFCentroCostosNombre, AV26TFCentroCostosNombre_Sel, AV27TFCentroCostosPrecioFinal, AV28TFCentroCostosPrecioFinal_To, AV29TFCentroCostosCosto, AV30TFCentroCostosCosto_To, lV31TFCentroCostosUsrAlta, AV32TFCentroCostosUsrAlta_Sel, AV33TFCentroCostosHoraAlt, AV34TFCentroCostosHoraAlt_To});
            nGXsfl_37_idx = 1;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A459ListaCostosId = H003Y3_A459ListaCostosId[0];
               n459ListaCostosId = H003Y3_n459ListaCostosId[0];
               AssignAttri(sPrefix, false, "A459ListaCostosId", StringUtil.LTrimStr( (decimal)(A459ListaCostosId), 18, 0));
               A487CentroCostosTipoRef = H003Y3_A487CentroCostosTipoRef[0];
               A482CentroCostosEstado = H003Y3_A482CentroCostosEstado[0];
               A480CentroCostosHoraAlt = H003Y3_A480CentroCostosHoraAlt[0];
               A478CentroCostosUsrAlta = H003Y3_A478CentroCostosUsrAlta[0];
               A475CentroCostosCosto = H003Y3_A475CentroCostosCosto[0];
               A465CentroCostosSerial = H003Y3_A465CentroCostosSerial[0];
               A464CentroCostosPrecioFinal = H003Y3_A464CentroCostosPrecioFinal[0];
               A463CentroCostosNombre = H003Y3_A463CentroCostosNombre[0];
               A462CentroCostosRef = H003Y3_A462CentroCostosRef[0];
               A461CentroCostosId = H003Y3_A461CentroCostosId[0];
               A487CentroCostosTipoRef = H003Y3_A487CentroCostosTipoRef[0];
               A482CentroCostosEstado = H003Y3_A482CentroCostosEstado[0];
               A480CentroCostosHoraAlt = H003Y3_A480CentroCostosHoraAlt[0];
               A478CentroCostosUsrAlta = H003Y3_A478CentroCostosUsrAlta[0];
               A475CentroCostosCosto = H003Y3_A475CentroCostosCosto[0];
               A465CentroCostosSerial = H003Y3_A465CentroCostosSerial[0];
               A464CentroCostosPrecioFinal = H003Y3_A464CentroCostosPrecioFinal[0];
               A463CentroCostosNombre = H003Y3_A463CentroCostosNombre[0];
               A462CentroCostosRef = H003Y3_A462CentroCostosRef[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A461CentroCostosId), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A462CentroCostosRef), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A463CentroCostosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A464CentroCostosPrecioFinal, 18, 2) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Str( A475CentroCostosCosto, 18, 2) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A478CentroCostosUsrAlta) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( context.GetMessage( "aprobado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A482CentroCostosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente de aprobación", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "PND") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "desaprobado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "servicios", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) &&
               ( StringUtil.StrCmp(A487CentroCostosTipoRef, "S") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV16FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A487CentroCostosTipoRef, "O") == 0 ) ) )
               )
               {
                  /* Execute user event: Grid.Load */
                  E183Y2 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 37;
            WB3Y0( ) ;
         }
         bGXsfl_37_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3Y2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV52Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV52Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV49IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV49IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV50IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV50IsAuthorized_Delete, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_CENTROCOSTOSID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sPrefix+sGXsfl_37_idx, context.localUtil.Format( (decimal)(A461CentroCostosId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8ListaCostosId, AV20ManageFiltersExecutionStep, AV52Pgmname, AV21TFCentroCostosId, AV22TFCentroCostosId_To, AV23TFCentroCostosRef, AV24TFCentroCostosRef_To, AV25TFCentroCostosNombre, AV26TFCentroCostosNombre_Sel, AV27TFCentroCostosPrecioFinal, AV28TFCentroCostosPrecioFinal_To, AV29TFCentroCostosCosto, AV30TFCentroCostosCosto_To, AV31TFCentroCostosUsrAlta, AV32TFCentroCostosUsrAlta_Sel, AV33TFCentroCostosHoraAlt, AV34TFCentroCostosHoraAlt_To, AV39TFCentroCostosEstado_Sels, AV41TFCentroCostosTipoRef_Sels, AV49IsAuthorized_Update, AV50IsAuthorized_Delete, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8ListaCostosId, AV20ManageFiltersExecutionStep, AV52Pgmname, AV21TFCentroCostosId, AV22TFCentroCostosId_To, AV23TFCentroCostosRef, AV24TFCentroCostosRef_To, AV25TFCentroCostosNombre, AV26TFCentroCostosNombre_Sel, AV27TFCentroCostosPrecioFinal, AV28TFCentroCostosPrecioFinal_To, AV29TFCentroCostosCosto, AV30TFCentroCostosCosto_To, AV31TFCentroCostosUsrAlta, AV32TFCentroCostosUsrAlta_Sel, AV33TFCentroCostosHoraAlt, AV34TFCentroCostosHoraAlt_To, AV39TFCentroCostosEstado_Sels, AV41TFCentroCostosTipoRef_Sels, AV49IsAuthorized_Update, AV50IsAuthorized_Delete, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8ListaCostosId, AV20ManageFiltersExecutionStep, AV52Pgmname, AV21TFCentroCostosId, AV22TFCentroCostosId_To, AV23TFCentroCostosRef, AV24TFCentroCostosRef_To, AV25TFCentroCostosNombre, AV26TFCentroCostosNombre_Sel, AV27TFCentroCostosPrecioFinal, AV28TFCentroCostosPrecioFinal_To, AV29TFCentroCostosCosto, AV30TFCentroCostosCosto_To, AV31TFCentroCostosUsrAlta, AV32TFCentroCostosUsrAlta_Sel, AV33TFCentroCostosHoraAlt, AV34TFCentroCostosHoraAlt_To, AV39TFCentroCostosEstado_Sels, AV41TFCentroCostosTipoRef_Sels, AV49IsAuthorized_Update, AV50IsAuthorized_Delete, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8ListaCostosId, AV20ManageFiltersExecutionStep, AV52Pgmname, AV21TFCentroCostosId, AV22TFCentroCostosId_To, AV23TFCentroCostosRef, AV24TFCentroCostosRef_To, AV25TFCentroCostosNombre, AV26TFCentroCostosNombre_Sel, AV27TFCentroCostosPrecioFinal, AV28TFCentroCostosPrecioFinal_To, AV29TFCentroCostosCosto, AV30TFCentroCostosCosto_To, AV31TFCentroCostosUsrAlta, AV32TFCentroCostosUsrAlta_Sel, AV33TFCentroCostosHoraAlt, AV34TFCentroCostosHoraAlt_To, AV39TFCentroCostosEstado_Sels, AV41TFCentroCostosTipoRef_Sels, AV49IsAuthorized_Update, AV50IsAuthorized_Delete, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8ListaCostosId, AV20ManageFiltersExecutionStep, AV52Pgmname, AV21TFCentroCostosId, AV22TFCentroCostosId_To, AV23TFCentroCostosRef, AV24TFCentroCostosRef_To, AV25TFCentroCostosNombre, AV26TFCentroCostosNombre_Sel, AV27TFCentroCostosPrecioFinal, AV28TFCentroCostosPrecioFinal_To, AV29TFCentroCostosCosto, AV30TFCentroCostosCosto_To, AV31TFCentroCostosUsrAlta, AV32TFCentroCostosUsrAlta_Sel, AV33TFCentroCostosHoraAlt, AV34TFCentroCostosHoraAlt_To, AV39TFCentroCostosEstado_Sels, AV41TFCentroCostosTipoRef_Sels, AV49IsAuthorized_Update, AV50IsAuthorized_Delete, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV52Pgmname = "ListaCostosDetallesWC";
         edtCentroCostosId_Enabled = 0;
         edtCentroCostosRef_Enabled = 0;
         edtCentroCostosNombre_Enabled = 0;
         edtCentroCostosPrecioFinal_Enabled = 0;
         edtCentroCostosSerial_Enabled = 0;
         edtCentroCostosCosto_Enabled = 0;
         edtCentroCostosUsrAlta_Enabled = 0;
         edtCentroCostosHoraAlt_Enabled = 0;
         cmbCentroCostosEstado.Enabled = 0;
         cmbCentroCostosTipoRef.Enabled = 0;
         edtListaCostosId_Enabled = 0;
         AssignProp(sPrefix, false, edtListaCostosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaCostosId_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3Y0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E163Y2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMANAGEFILTERSDATA"), AV18ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV42DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_37"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV45GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV46GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV47GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
            AV35DDO_CentroCostosHoraAltAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_CENTROCOSTOSHORAALTAUXDATE"), 0);
            AV36DDO_CentroCostosHoraAltAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_CENTROCOSTOSHORAALTAUXDATETO"), 0);
            wcpOAV8ListaCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8ListaCostosId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
            Ddo_grid_Filteredtext_set = cgiGet( sPrefix+"DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( sPrefix+"DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( sPrefix+"DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( sPrefix+"DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( sPrefix+"DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( sPrefix+"DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( sPrefix+"DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( sPrefix+"DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( sPrefix+"DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( sPrefix+"DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( sPrefix+"DDO_GRID_Datalisttype");
            Ddo_grid_Allowmultipleselection = cgiGet( sPrefix+"DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( sPrefix+"DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( sPrefix+"DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( sPrefix+"DDO_GRID_Format");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Fixedcolumns = cgiGet( sPrefix+"GRID_EMPOWERER_Fixedcolumns");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( sPrefix+"DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( sPrefix+"DDO_GRID_Selectedcolumn");
            Ddo_managefilters_Activeeventkey = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV16FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri(sPrefix, false, "AV16FilterFullText", AV16FilterFullText);
            A459ListaCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtListaCostosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n459ListaCostosId = false;
            AssignAttri(sPrefix, false, "A459ListaCostosId", StringUtil.LTrimStr( (decimal)(A459ListaCostosId), 18, 0));
            AV37DDO_CentroCostosHoraAltAuxDateText = cgiGet( edtavDdo_centrocostoshoraaltauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV37DDO_CentroCostosHoraAltAuxDateText", AV37DDO_CentroCostosHoraAltAuxDateText);
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
         E163Y2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E163Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod(sPrefix, false, "TFCENTROCOSTOSHORAALT_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_centrocostoshoraaltauxdatetext_Internalname});
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
         edtListaCostosId_Visible = 0;
         AssignProp(sPrefix, false, edtListaCostosId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtListaCostosId_Visible), 5, 0), true);
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV42DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV42DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E173Y2( )
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
         AV45GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV45GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV45GridCurrentPage), 10, 0));
         AV46GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV46GridPageCount", StringUtil.LTrimStr( (decimal)(AV46GridPageCount), 10, 0));
         GXt_char2 = AV47GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV52Pgmname, out  GXt_char2) ;
         AV47GridAppliedFilters = GXt_char2;
         AssignAttri(sPrefix, false, "AV47GridAppliedFilters", AV47GridAppliedFilters);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ManageFiltersData", AV18ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridState", AV12GridState);
      }

      protected void E123Y2( )
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
            AV44PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV44PageToGo) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ManageFiltersData", AV18ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridState", AV12GridState);
      }

      protected void E133Y2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E143Y2( )
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
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CentroCostosId") == 0 )
            {
               AV21TFCentroCostosId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV21TFCentroCostosId", StringUtil.LTrimStr( (decimal)(AV21TFCentroCostosId), 18, 0));
               AV22TFCentroCostosId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV22TFCentroCostosId_To", StringUtil.LTrimStr( (decimal)(AV22TFCentroCostosId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CentroCostosRef") == 0 )
            {
               AV23TFCentroCostosRef = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV23TFCentroCostosRef", StringUtil.LTrimStr( (decimal)(AV23TFCentroCostosRef), 18, 0));
               AV24TFCentroCostosRef_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV24TFCentroCostosRef_To", StringUtil.LTrimStr( (decimal)(AV24TFCentroCostosRef_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CentroCostosNombre") == 0 )
            {
               AV25TFCentroCostosNombre = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV25TFCentroCostosNombre", AV25TFCentroCostosNombre);
               AV26TFCentroCostosNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV26TFCentroCostosNombre_Sel", AV26TFCentroCostosNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CentroCostosPrecioFinal") == 0 )
            {
               AV27TFCentroCostosPrecioFinal = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV27TFCentroCostosPrecioFinal", StringUtil.LTrimStr( AV27TFCentroCostosPrecioFinal, 18, 2));
               AV28TFCentroCostosPrecioFinal_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV28TFCentroCostosPrecioFinal_To", StringUtil.LTrimStr( AV28TFCentroCostosPrecioFinal_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CentroCostosCosto") == 0 )
            {
               AV29TFCentroCostosCosto = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV29TFCentroCostosCosto", StringUtil.LTrimStr( AV29TFCentroCostosCosto, 18, 2));
               AV30TFCentroCostosCosto_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV30TFCentroCostosCosto_To", StringUtil.LTrimStr( AV30TFCentroCostosCosto_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CentroCostosUsrAlta") == 0 )
            {
               AV31TFCentroCostosUsrAlta = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV31TFCentroCostosUsrAlta", AV31TFCentroCostosUsrAlta);
               AV32TFCentroCostosUsrAlta_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV32TFCentroCostosUsrAlta_Sel", AV32TFCentroCostosUsrAlta_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CentroCostosHoraAlt") == 0 )
            {
               AV33TFCentroCostosHoraAlt = context.localUtil.CToD( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV33TFCentroCostosHoraAlt", context.localUtil.Format(AV33TFCentroCostosHoraAlt, "99/99/99"));
               AV34TFCentroCostosHoraAlt_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV34TFCentroCostosHoraAlt_To", context.localUtil.Format(AV34TFCentroCostosHoraAlt_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CentroCostosEstado") == 0 )
            {
               AV38TFCentroCostosEstado_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV38TFCentroCostosEstado_SelsJson", AV38TFCentroCostosEstado_SelsJson);
               AV39TFCentroCostosEstado_Sels.FromJSonString(AV38TFCentroCostosEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CentroCostosTipoRef") == 0 )
            {
               AV40TFCentroCostosTipoRef_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV40TFCentroCostosTipoRef_SelsJson", AV40TFCentroCostosTipoRef_SelsJson);
               AV41TFCentroCostosTipoRef_Sels.FromJSonString(AV40TFCentroCostosTipoRef_SelsJson, null);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV41TFCentroCostosTipoRef_Sels", AV41TFCentroCostosTipoRef_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV39TFCentroCostosEstado_Sels", AV39TFCentroCostosEstado_Sels);
      }

      private void E183Y2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            cmbavGridactions.removeAllItems();
            cmbavGridactions.addItem("0", ";fa fa-bars", 0);
            cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
            if ( AV49IsAuthorized_Update )
            {
               cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_update", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
            }
            if ( AV50IsAuthorized_Delete )
            {
               cmbavGridactions.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "fa fa-times", "", "", "", "", "", "", ""), 0);
            }
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "centrocostosview.aspx"+UrlEncode(StringUtil.LTrimStr(A461CentroCostosId,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(A462CentroCostosRef,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtCentroCostosNombre_Link = formatLink("centrocostosview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV48GridActions), 4, 0));
      }

      protected void E113Y2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("ListaCostosDetallesWCFilters")) + "," + UrlEncode(StringUtil.RTrim(AV52Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV20ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("ListaCostosDetallesWCFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV20ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            GXt_char2 = AV19ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "ListaCostosDetallesWCFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV52Pgmname+"GridState",  AV19ManageFiltersXml) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV39TFCentroCostosEstado_Sels", AV39TFCentroCostosEstado_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV41TFCentroCostosTipoRef_Sels", AV41TFCentroCostosTipoRef_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ManageFiltersData", AV18ManageFiltersData);
      }

      protected void E193Y2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV48GridActions == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S192 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV48GridActions == 2 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV48GridActions == 3 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV48GridActions = 0;
         AssignAttri(sPrefix, false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV48GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV48GridActions), 4, 0));
         AssignProp(sPrefix, false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E153Y2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "centrocostos.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("centrocostos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
         GXt_boolean3 = AV49IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCentroCostos_Update", out  GXt_boolean3) ;
         AV49IsAuthorized_Update = GXt_boolean3;
         AssignAttri(sPrefix, false, "AV49IsAuthorized_Update", AV49IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV49IsAuthorized_Update, context));
         GXt_boolean3 = AV50IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCentroCostos_Delete", out  GXt_boolean3) ;
         AV50IsAuthorized_Delete = GXt_boolean3;
         AssignAttri(sPrefix, false, "AV50IsAuthorized_Delete", AV50IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV50IsAuthorized_Delete, context));
         GXt_boolean3 = AV51TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCentroCostos_Insert", out  GXt_boolean3) ;
         AV51TempBoolean = GXt_boolean3;
         if ( ! ( AV51TempBoolean ) )
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
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "ListaCostosDetallesWCFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV18ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S172( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV16FilterFullText = "";
         AssignAttri(sPrefix, false, "AV16FilterFullText", AV16FilterFullText);
         AV21TFCentroCostosId = 0;
         AssignAttri(sPrefix, false, "AV21TFCentroCostosId", StringUtil.LTrimStr( (decimal)(AV21TFCentroCostosId), 18, 0));
         AV22TFCentroCostosId_To = 0;
         AssignAttri(sPrefix, false, "AV22TFCentroCostosId_To", StringUtil.LTrimStr( (decimal)(AV22TFCentroCostosId_To), 18, 0));
         AV23TFCentroCostosRef = 0;
         AssignAttri(sPrefix, false, "AV23TFCentroCostosRef", StringUtil.LTrimStr( (decimal)(AV23TFCentroCostosRef), 18, 0));
         AV24TFCentroCostosRef_To = 0;
         AssignAttri(sPrefix, false, "AV24TFCentroCostosRef_To", StringUtil.LTrimStr( (decimal)(AV24TFCentroCostosRef_To), 18, 0));
         AV25TFCentroCostosNombre = "";
         AssignAttri(sPrefix, false, "AV25TFCentroCostosNombre", AV25TFCentroCostosNombre);
         AV26TFCentroCostosNombre_Sel = "";
         AssignAttri(sPrefix, false, "AV26TFCentroCostosNombre_Sel", AV26TFCentroCostosNombre_Sel);
         AV27TFCentroCostosPrecioFinal = 0;
         AssignAttri(sPrefix, false, "AV27TFCentroCostosPrecioFinal", StringUtil.LTrimStr( AV27TFCentroCostosPrecioFinal, 18, 2));
         AV28TFCentroCostosPrecioFinal_To = 0;
         AssignAttri(sPrefix, false, "AV28TFCentroCostosPrecioFinal_To", StringUtil.LTrimStr( AV28TFCentroCostosPrecioFinal_To, 18, 2));
         AV29TFCentroCostosCosto = 0;
         AssignAttri(sPrefix, false, "AV29TFCentroCostosCosto", StringUtil.LTrimStr( AV29TFCentroCostosCosto, 18, 2));
         AV30TFCentroCostosCosto_To = 0;
         AssignAttri(sPrefix, false, "AV30TFCentroCostosCosto_To", StringUtil.LTrimStr( AV30TFCentroCostosCosto_To, 18, 2));
         AV31TFCentroCostosUsrAlta = "";
         AssignAttri(sPrefix, false, "AV31TFCentroCostosUsrAlta", AV31TFCentroCostosUsrAlta);
         AV32TFCentroCostosUsrAlta_Sel = "";
         AssignAttri(sPrefix, false, "AV32TFCentroCostosUsrAlta_Sel", AV32TFCentroCostosUsrAlta_Sel);
         AV33TFCentroCostosHoraAlt = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV33TFCentroCostosHoraAlt", context.localUtil.Format(AV33TFCentroCostosHoraAlt, "99/99/99"));
         AV34TFCentroCostosHoraAlt_To = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV34TFCentroCostosHoraAlt_To", context.localUtil.Format(AV34TFCentroCostosHoraAlt_To, "99/99/99"));
         AV39TFCentroCostosEstado_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV41TFCentroCostosTipoRef_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S192( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "centrocostosview.aspx"+UrlEncode(StringUtil.LTrimStr(A461CentroCostosId,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(A462CentroCostosRef,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("centrocostosview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S202( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "centrocostos.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A461CentroCostosId,18,0));
         CallWebObject(formatLink("centrocostos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S212( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "centrocostos.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A461CentroCostosId,18,0));
         CallWebObject(formatLink("centrocostos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV17Session.Get(AV52Pgmname+"GridState"), "") == 0 )
         {
            AV12GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV52Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV12GridState.FromXml(AV17Session.Get(AV52Pgmname+"GridState"), null, "", "");
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
         AV53GXV1 = 1;
         while ( AV53GXV1 <= AV12GridState.gxTpr_Filtervalues.Count )
         {
            AV13GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV12GridState.gxTpr_Filtervalues.Item(AV53GXV1));
            if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV16FilterFullText = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV16FilterFullText", AV16FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSID") == 0 )
            {
               AV21TFCentroCostosId = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV21TFCentroCostosId", StringUtil.LTrimStr( (decimal)(AV21TFCentroCostosId), 18, 0));
               AV22TFCentroCostosId_To = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV22TFCentroCostosId_To", StringUtil.LTrimStr( (decimal)(AV22TFCentroCostosId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSREF") == 0 )
            {
               AV23TFCentroCostosRef = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV23TFCentroCostosRef", StringUtil.LTrimStr( (decimal)(AV23TFCentroCostosRef), 18, 0));
               AV24TFCentroCostosRef_To = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV24TFCentroCostosRef_To", StringUtil.LTrimStr( (decimal)(AV24TFCentroCostosRef_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSNOMBRE") == 0 )
            {
               AV25TFCentroCostosNombre = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV25TFCentroCostosNombre", AV25TFCentroCostosNombre);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSNOMBRE_SEL") == 0 )
            {
               AV26TFCentroCostosNombre_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV26TFCentroCostosNombre_Sel", AV26TFCentroCostosNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSPRECIOFINAL") == 0 )
            {
               AV27TFCentroCostosPrecioFinal = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV27TFCentroCostosPrecioFinal", StringUtil.LTrimStr( AV27TFCentroCostosPrecioFinal, 18, 2));
               AV28TFCentroCostosPrecioFinal_To = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV28TFCentroCostosPrecioFinal_To", StringUtil.LTrimStr( AV28TFCentroCostosPrecioFinal_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSCOSTO") == 0 )
            {
               AV29TFCentroCostosCosto = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV29TFCentroCostosCosto", StringUtil.LTrimStr( AV29TFCentroCostosCosto, 18, 2));
               AV30TFCentroCostosCosto_To = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV30TFCentroCostosCosto_To", StringUtil.LTrimStr( AV30TFCentroCostosCosto_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSUSRALTA") == 0 )
            {
               AV31TFCentroCostosUsrAlta = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV31TFCentroCostosUsrAlta", AV31TFCentroCostosUsrAlta);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSUSRALTA_SEL") == 0 )
            {
               AV32TFCentroCostosUsrAlta_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV32TFCentroCostosUsrAlta_Sel", AV32TFCentroCostosUsrAlta_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSHORAALT") == 0 )
            {
               AV33TFCentroCostosHoraAlt = context.localUtil.CToD( AV13GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV33TFCentroCostosHoraAlt", context.localUtil.Format(AV33TFCentroCostosHoraAlt, "99/99/99"));
               AV34TFCentroCostosHoraAlt_To = context.localUtil.CToD( AV13GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV34TFCentroCostosHoraAlt_To", context.localUtil.Format(AV34TFCentroCostosHoraAlt_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSESTADO_SEL") == 0 )
            {
               AV38TFCentroCostosEstado_SelsJson = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV38TFCentroCostosEstado_SelsJson", AV38TFCentroCostosEstado_SelsJson);
               AV39TFCentroCostosEstado_Sels.FromJSonString(AV38TFCentroCostosEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSTIPOREF_SEL") == 0 )
            {
               AV40TFCentroCostosTipoRef_SelsJson = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV40TFCentroCostosTipoRef_SelsJson", AV40TFCentroCostosTipoRef_SelsJson);
               AV41TFCentroCostosTipoRef_Sels.FromJSonString(AV40TFCentroCostosTipoRef_SelsJson, null);
            }
            AV53GXV1 = (int)(AV53GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV26TFCentroCostosNombre_Sel)),  AV26TFCentroCostosNombre_Sel, out  GXt_char2) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV32TFCentroCostosUsrAlta_Sel)),  AV32TFCentroCostosUsrAlta_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV39TFCentroCostosEstado_Sels.Count==0),  AV38TFCentroCostosEstado_SelsJson, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV41TFCentroCostosTipoRef_Sels.Count==0),  AV40TFCentroCostosTipoRef_SelsJson, out  GXt_char7) ;
         Ddo_grid_Selectedvalue_set = "||"+GXt_char2+"|||"+GXt_char5+"||"+GXt_char6+"|"+GXt_char7;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV25TFCentroCostosNombre)),  AV25TFCentroCostosNombre, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV31TFCentroCostosUsrAlta)),  AV31TFCentroCostosUsrAlta, out  GXt_char6) ;
         Ddo_grid_Filteredtext_set = ((0==AV21TFCentroCostosId) ? "" : StringUtil.Str( (decimal)(AV21TFCentroCostosId), 18, 0))+"|"+((0==AV23TFCentroCostosRef) ? "" : StringUtil.Str( (decimal)(AV23TFCentroCostosRef), 18, 0))+"|"+GXt_char7+"|"+((Convert.ToDecimal(0)==AV27TFCentroCostosPrecioFinal) ? "" : StringUtil.Str( AV27TFCentroCostosPrecioFinal, 18, 2))+"|"+((Convert.ToDecimal(0)==AV29TFCentroCostosCosto) ? "" : StringUtil.Str( AV29TFCentroCostosCosto, 18, 2))+"|"+GXt_char6+"|"+((DateTime.MinValue==AV33TFCentroCostosHoraAlt) ? "" : context.localUtil.DToC( AV33TFCentroCostosHoraAlt, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"||";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV22TFCentroCostosId_To) ? "" : StringUtil.Str( (decimal)(AV22TFCentroCostosId_To), 18, 0))+"|"+((0==AV24TFCentroCostosRef_To) ? "" : StringUtil.Str( (decimal)(AV24TFCentroCostosRef_To), 18, 0))+"||"+((Convert.ToDecimal(0)==AV28TFCentroCostosPrecioFinal_To) ? "" : StringUtil.Str( AV28TFCentroCostosPrecioFinal_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV30TFCentroCostosCosto_To) ? "" : StringUtil.Str( AV30TFCentroCostosCosto_To, 18, 2))+"||"+((DateTime.MinValue==AV34TFCentroCostosHoraAlt_To) ? "" : context.localUtil.DToC( AV34TFCentroCostosHoraAlt_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"||";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV12GridState.FromXml(AV17Session.Get(AV52Pgmname+"GridState"), null, "", "");
         AV12GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV12GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV12GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)),  0,  AV16FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFCENTROCOSTOSID",  context.GetMessage( "Código CC:", ""),  !((0==AV21TFCentroCostosId)&&(0==AV22TFCentroCostosId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV21TFCentroCostosId), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV22TFCentroCostosId_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFCENTROCOSTOSREF",  context.GetMessage( "Referencia Nro:", ""),  !((0==AV23TFCentroCostosRef)&&(0==AV24TFCentroCostosRef_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV23TFCentroCostosRef), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV24TFCentroCostosRef_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFCENTROCOSTOSNOMBRE",  context.GetMessage( "Nombre:", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV25TFCentroCostosNombre)),  0,  AV25TFCentroCostosNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV26TFCentroCostosNombre_Sel)),  AV26TFCentroCostosNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFCENTROCOSTOSPRECIOFINAL",  context.GetMessage( "Precio Final:", ""),  !((Convert.ToDecimal(0)==AV27TFCentroCostosPrecioFinal)&&(Convert.ToDecimal(0)==AV28TFCentroCostosPrecioFinal_To)),  0,  StringUtil.Trim( StringUtil.Str( AV27TFCentroCostosPrecioFinal, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV28TFCentroCostosPrecioFinal_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFCENTROCOSTOSCOSTO",  context.GetMessage( "Costo", ""),  !((Convert.ToDecimal(0)==AV29TFCentroCostosCosto)&&(Convert.ToDecimal(0)==AV30TFCentroCostosCosto_To)),  0,  StringUtil.Trim( StringUtil.Str( AV29TFCentroCostosCosto, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV30TFCentroCostosCosto_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFCENTROCOSTOSUSRALTA",  context.GetMessage( "Usuario de Alta", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV31TFCentroCostosUsrAlta)),  0,  AV31TFCentroCostosUsrAlta,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV32TFCentroCostosUsrAlta_Sel)),  AV32TFCentroCostosUsrAlta_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFCENTROCOSTOSHORAALT",  context.GetMessage( "Hora de Alta", ""),  !((DateTime.MinValue==AV33TFCentroCostosHoraAlt)&&(DateTime.MinValue==AV34TFCentroCostosHoraAlt_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV33TFCentroCostosHoraAlt, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")),  StringUtil.Trim( context.localUtil.DToC( AV34TFCentroCostosHoraAlt_To, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFCENTROCOSTOSESTADO_SEL",  context.GetMessage( "Estado", ""),  !(AV39TFCentroCostosEstado_Sels.Count==0),  0,  AV39TFCentroCostosEstado_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFCENTROCOSTOSTIPOREF_SEL",  context.GetMessage( "Tipo Referencia:", ""),  !(AV41TFCentroCostosTipoRef_Sels.Count==0),  0,  AV41TFCentroCostosTipoRef_Sels.ToJSonString(false),  "") ;
         if ( ! (0==AV8ListaCostosId) )
         {
            AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV13GridStateFilterValue.gxTpr_Name = "PARM_&LISTACOSTOSID";
            AV13GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV8ListaCostosId), 18, 0);
            AV12GridState.gxTpr_Filtervalues.Add(AV13GridStateFilterValue, 0);
         }
         AV12GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV52Pgmname+"GridState",  AV12GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10TrnContext.gxTpr_Callerobject = AV52Pgmname;
         AV10TrnContext.gxTpr_Callerondelete = true;
         AV10TrnContext.gxTpr_Callerurl = AV9HTTPRequest.ScriptName+"?"+AV9HTTPRequest.QueryString;
         AV10TrnContext.gxTpr_Transactionname = "CentroCostos";
         AV11TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV11TrnContextAtt.gxTpr_Attributename = "ListaCostosId";
         AV11TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV8ListaCostosId), 18, 0);
         AV10TrnContext.gxTpr_Attributes.Add(AV11TrnContextAtt, 0);
         AV17Session.Set("TrnContext", AV10TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table1_22_3Y2( bool wbgen )
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
            wb_table2_27_3Y2( true) ;
         }
         else
         {
            wb_table2_27_3Y2( false) ;
         }
         return  ;
      }

      protected void wb_table2_27_3Y2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_22_3Y2e( true) ;
         }
         else
         {
            wb_table1_22_3Y2e( false) ;
         }
      }

      protected void wb_table2_27_3Y2( bool wbgen )
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV16FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV16FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_ListaCostosDetallesWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_27_3Y2e( true) ;
         }
         else
         {
            wb_table2_27_3Y2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8ListaCostosId = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV8ListaCostosId", StringUtil.LTrimStr( (decimal)(AV8ListaCostosId), 18, 0));
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
         PA3Y2( ) ;
         WS3Y2( ) ;
         WE3Y2( ) ;
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
         sCtrlAV8ListaCostosId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA3Y2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "listacostosdetalleswc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA3Y2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV8ListaCostosId = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV8ListaCostosId", StringUtil.LTrimStr( (decimal)(AV8ListaCostosId), 18, 0));
         }
         wcpOAV8ListaCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8ListaCostosId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV8ListaCostosId != wcpOAV8ListaCostosId ) ) )
         {
            setjustcreated();
         }
         wcpOAV8ListaCostosId = AV8ListaCostosId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV8ListaCostosId = cgiGet( sPrefix+"AV8ListaCostosId_CTRL");
         if ( StringUtil.Len( sCtrlAV8ListaCostosId) > 0 )
         {
            AV8ListaCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV8ListaCostosId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV8ListaCostosId", StringUtil.LTrimStr( (decimal)(AV8ListaCostosId), 18, 0));
         }
         else
         {
            AV8ListaCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV8ListaCostosId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         PA3Y2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS3Y2( ) ;
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
         WS3Y2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8ListaCostosId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8ListaCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8ListaCostosId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8ListaCostosId_CTRL", StringUtil.RTrim( sCtrlAV8ListaCostosId));
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
         WE3Y2( ) ;
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
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021141071", true, true, false);
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
         context.AddJavascriptSource("listacostosdetalleswc.js", "?202673021141071", false, true, false);
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_372( )
      {
         cmbavGridactions_Internalname = sPrefix+"vGRIDACTIONS_"+sGXsfl_37_idx;
         edtCentroCostosId_Internalname = sPrefix+"CENTROCOSTOSID_"+sGXsfl_37_idx;
         edtCentroCostosRef_Internalname = sPrefix+"CENTROCOSTOSREF_"+sGXsfl_37_idx;
         edtCentroCostosNombre_Internalname = sPrefix+"CENTROCOSTOSNOMBRE_"+sGXsfl_37_idx;
         edtCentroCostosPrecioFinal_Internalname = sPrefix+"CENTROCOSTOSPRECIOFINAL_"+sGXsfl_37_idx;
         edtCentroCostosSerial_Internalname = sPrefix+"CENTROCOSTOSSERIAL_"+sGXsfl_37_idx;
         edtCentroCostosCosto_Internalname = sPrefix+"CENTROCOSTOSCOSTO_"+sGXsfl_37_idx;
         edtCentroCostosUsrAlta_Internalname = sPrefix+"CENTROCOSTOSUSRALTA_"+sGXsfl_37_idx;
         edtCentroCostosHoraAlt_Internalname = sPrefix+"CENTROCOSTOSHORAALT_"+sGXsfl_37_idx;
         cmbCentroCostosEstado_Internalname = sPrefix+"CENTROCOSTOSESTADO_"+sGXsfl_37_idx;
         cmbCentroCostosTipoRef_Internalname = sPrefix+"CENTROCOSTOSTIPOREF_"+sGXsfl_37_idx;
      }

      protected void SubsflControlProps_fel_372( )
      {
         cmbavGridactions_Internalname = sPrefix+"vGRIDACTIONS_"+sGXsfl_37_fel_idx;
         edtCentroCostosId_Internalname = sPrefix+"CENTROCOSTOSID_"+sGXsfl_37_fel_idx;
         edtCentroCostosRef_Internalname = sPrefix+"CENTROCOSTOSREF_"+sGXsfl_37_fel_idx;
         edtCentroCostosNombre_Internalname = sPrefix+"CENTROCOSTOSNOMBRE_"+sGXsfl_37_fel_idx;
         edtCentroCostosPrecioFinal_Internalname = sPrefix+"CENTROCOSTOSPRECIOFINAL_"+sGXsfl_37_fel_idx;
         edtCentroCostosSerial_Internalname = sPrefix+"CENTROCOSTOSSERIAL_"+sGXsfl_37_fel_idx;
         edtCentroCostosCosto_Internalname = sPrefix+"CENTROCOSTOSCOSTO_"+sGXsfl_37_fel_idx;
         edtCentroCostosUsrAlta_Internalname = sPrefix+"CENTROCOSTOSUSRALTA_"+sGXsfl_37_fel_idx;
         edtCentroCostosHoraAlt_Internalname = sPrefix+"CENTROCOSTOSHORAALT_"+sGXsfl_37_fel_idx;
         cmbCentroCostosEstado_Internalname = sPrefix+"CENTROCOSTOSESTADO_"+sGXsfl_37_fel_idx;
         cmbCentroCostosTipoRef_Internalname = sPrefix+"CENTROCOSTOSTIPOREF_"+sGXsfl_37_fel_idx;
      }

      protected void sendrow_372( )
      {
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         WB3Y0( ) ;
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'" + sGXsfl_37_idx + "',37)\"";
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_37_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV48GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV48GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV48GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV48GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVGRIDACTIONS.CLICK."+sGXsfl_37_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"",(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV48GridActions), 4, 0));
            AssignProp(sPrefix, false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A461CentroCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A461CentroCostosId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosRef_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A462CentroCostosRef), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A462CentroCostosRef), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosRef_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosNombre_Internalname,StringUtil.RTrim( A463CentroCostosNombre),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtCentroCostosNombre_Link,(string)"",(string)"",(string)"",(string)edtCentroCostosNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosPrecioFinal_Internalname,StringUtil.LTrim( StringUtil.NToC( A464CentroCostosPrecioFinal, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A464CentroCostosPrecioFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosPrecioFinal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosSerial_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A465CentroCostosSerial), 10, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A465CentroCostosSerial), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosSerial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosCosto_Internalname,StringUtil.LTrim( StringUtil.NToC( A475CentroCostosCosto, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A475CentroCostosCosto, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosCosto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosUsrAlta_Internalname,StringUtil.RTrim( A478CentroCostosUsrAlta),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosUsrAlta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Usuario",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosHoraAlt_Internalname,context.localUtil.Format(A480CentroCostosHoraAlt, "99/99/99"),context.localUtil.Format( A480CentroCostosHoraAlt, "99/99/99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosHoraAlt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            GXCCtl = "CENTROCOSTOSESTADO_" + sGXsfl_37_idx;
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
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbCentroCostosEstado,(string)cmbCentroCostosEstado_Internalname,StringUtil.RTrim( A482CentroCostosEstado),(short)1,(string)cmbCentroCostosEstado_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbCentroCostosEstado.CurrentValue = StringUtil.RTrim( A482CentroCostosEstado);
            AssignProp(sPrefix, false, cmbCentroCostosEstado_Internalname, "Values", (string)(cmbCentroCostosEstado.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            GXCCtl = "CENTROCOSTOSTIPOREF_" + sGXsfl_37_idx;
            cmbCentroCostosTipoRef.Name = GXCCtl;
            cmbCentroCostosTipoRef.WebTags = "";
            cmbCentroCostosTipoRef.addItem("S", context.GetMessage( "Servicios", ""), 0);
            cmbCentroCostosTipoRef.addItem("O", context.GetMessage( "Otros", ""), 0);
            if ( cmbCentroCostosTipoRef.ItemCount > 0 )
            {
               A487CentroCostosTipoRef = cmbCentroCostosTipoRef.getValidValue(A487CentroCostosTipoRef);
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbCentroCostosTipoRef,(string)cmbCentroCostosTipoRef_Internalname,StringUtil.RTrim( A487CentroCostosTipoRef),(short)1,(string)cmbCentroCostosTipoRef_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbCentroCostosTipoRef.CurrentValue = StringUtil.RTrim( A487CentroCostosTipoRef);
            AssignProp(sPrefix, false, cmbCentroCostosTipoRef_Internalname, "Values", (string)(cmbCentroCostosTipoRef.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            send_integrity_lvl_hashes3Y2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         /* End function sendrow_372 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_37_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
         }
         GXCCtl = "CENTROCOSTOSESTADO_" + sGXsfl_37_idx;
         cmbCentroCostosEstado.Name = GXCCtl;
         cmbCentroCostosEstado.WebTags = "";
         cmbCentroCostosEstado.addItem("HAB", context.GetMessage( "Aprobado", ""), 0);
         cmbCentroCostosEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbCentroCostosEstado.addItem("PND", context.GetMessage( "Pendiente de Aprobación", ""), 0);
         cmbCentroCostosEstado.addItem("DES", context.GetMessage( "Desaprobado", ""), 0);
         if ( cmbCentroCostosEstado.ItemCount > 0 )
         {
         }
         GXCCtl = "CENTROCOSTOSTIPOREF_" + sGXsfl_37_idx;
         cmbCentroCostosTipoRef.Name = GXCCtl;
         cmbCentroCostosTipoRef.WebTags = "";
         cmbCentroCostosTipoRef.addItem("S", context.GetMessage( "Servicios", ""), 0);
         cmbCentroCostosTipoRef.addItem("O", context.GetMessage( "Otros", ""), 0);
         if ( cmbCentroCostosTipoRef.ItemCount > 0 )
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Código CC:", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Referencia Nro:", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre:", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Precio Final:", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Costos Serial", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Costo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Usuario de Alta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Hora de Alta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
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
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48GridActions), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A461CentroCostosId), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A462CentroCostosRef), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A463CentroCostosNombre)));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtCentroCostosNombre_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A464CentroCostosPrecioFinal, 21, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A465CentroCostosSerial), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A475CentroCostosCosto, 21, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A478CentroCostosUsrAlta)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A480CentroCostosHoraAlt, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A482CentroCostosEstado)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A487CentroCostosTipoRef)));
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
         cmbavGridactions_Internalname = sPrefix+"vGRIDACTIONS";
         edtCentroCostosId_Internalname = sPrefix+"CENTROCOSTOSID";
         edtCentroCostosRef_Internalname = sPrefix+"CENTROCOSTOSREF";
         edtCentroCostosNombre_Internalname = sPrefix+"CENTROCOSTOSNOMBRE";
         edtCentroCostosPrecioFinal_Internalname = sPrefix+"CENTROCOSTOSPRECIOFINAL";
         edtCentroCostosSerial_Internalname = sPrefix+"CENTROCOSTOSSERIAL";
         edtCentroCostosCosto_Internalname = sPrefix+"CENTROCOSTOSCOSTO";
         edtCentroCostosUsrAlta_Internalname = sPrefix+"CENTROCOSTOSUSRALTA";
         edtCentroCostosHoraAlt_Internalname = sPrefix+"CENTROCOSTOSHORAALT";
         cmbCentroCostosEstado_Internalname = sPrefix+"CENTROCOSTOSESTADO";
         cmbCentroCostosTipoRef_Internalname = sPrefix+"CENTROCOSTOSTIPOREF";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         divTablegridheader_Internalname = sPrefix+"TABLEGRIDHEADER";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         edtListaCostosId_Internalname = sPrefix+"LISTACOSTOSID";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         edtavDdo_centrocostoshoraaltauxdatetext_Internalname = sPrefix+"vDDO_CENTROCOSTOSHORAALTAUXDATETEXT";
         Tfcentrocostoshoraalt_rangepicker_Internalname = sPrefix+"TFCENTROCOSTOSHORAALT_RANGEPICKER";
         divDdo_centrocostoshoraaltauxdates_Internalname = sPrefix+"DDO_CENTROCOSTOSHORAALTAUXDATES";
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
         cmbCentroCostosTipoRef_Jsonclick = "";
         cmbCentroCostosEstado_Jsonclick = "";
         edtCentroCostosHoraAlt_Jsonclick = "";
         edtCentroCostosUsrAlta_Jsonclick = "";
         edtCentroCostosCosto_Jsonclick = "";
         edtCentroCostosSerial_Jsonclick = "";
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
         edtListaCostosId_Enabled = 0;
         cmbCentroCostosTipoRef.Enabled = 0;
         cmbCentroCostosEstado.Enabled = 0;
         edtCentroCostosHoraAlt_Enabled = 0;
         edtCentroCostosUsrAlta_Enabled = 0;
         edtCentroCostosCosto_Enabled = 0;
         edtCentroCostosSerial_Enabled = 0;
         edtCentroCostosPrecioFinal_Enabled = 0;
         edtCentroCostosNombre_Enabled = 0;
         edtCentroCostosRef_Enabled = 0;
         edtCentroCostosId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_centrocostoshoraaltauxdatetext_Jsonclick = "";
         edtListaCostosId_Jsonclick = "";
         edtListaCostosId_Visible = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Fixedcolumns = "L;;;;;;;;;;";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "18.0|18.0||-18.2|-18.2||||";
         Ddo_grid_Datalistproc = "ListaCostosDetallesWCGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||||||HAB:Aprobado,DES:Deshabilitado,PND:Pendiente de Aprobación,DES:Desaprobado|S:Servicios,O:Otros";
         Ddo_grid_Allowmultipleselection = "|||||||T|T";
         Ddo_grid_Datalisttype = "||Dynamic|||Dynamic||FixedValues|FixedValues";
         Ddo_grid_Includedatalist = "||T|||T||T|T";
         Ddo_grid_Filterisrange = "T|T||T|T||P||";
         Ddo_grid_Filtertype = "Numeric|Numeric|Character|Numeric|Numeric|Character|Date||";
         Ddo_grid_Includefilter = "T|T|T|T|T|T|T||";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|6|7|8|9";
         Ddo_grid_Columnids = "1:CentroCostosId|2:CentroCostosRef|3:CentroCostosNombre|4:CentroCostosPrecioFinal|6:CentroCostosCosto|7:CentroCostosUsrAlta|8:CentroCostosHoraAlt|9:CentroCostosEstado|10:CentroCostosTipoRef";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'sPrefix',type:'char'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8ListaCostosId',fld:'vLISTACOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV52Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21TFCentroCostosId',fld:'vTFCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22TFCentroCostosId_To',fld:'vTFCENTROCOSTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV23TFCentroCostosRef',fld:'vTFCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV24TFCentroCostosRef_To',fld:'vTFCENTROCOSTOSREF_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV25TFCentroCostosNombre',fld:'vTFCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV26TFCentroCostosNombre_Sel',fld:'vTFCENTROCOSTOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV27TFCentroCostosPrecioFinal',fld:'vTFCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV28TFCentroCostosPrecioFinal_To',fld:'vTFCENTROCOSTOSPRECIOFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV29TFCentroCostosCosto',fld:'vTFCENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV30TFCentroCostosCosto_To',fld:'vTFCENTROCOSTOSCOSTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV31TFCentroCostosUsrAlta',fld:'vTFCENTROCOSTOSUSRALTA',pic:'',type:'char'},{av:'AV32TFCentroCostosUsrAlta_Sel',fld:'vTFCENTROCOSTOSUSRALTA_SEL',pic:'',type:'char'},{av:'AV33TFCentroCostosHoraAlt',fld:'vTFCENTROCOSTOSHORAALT',pic:'',type:'date'},{av:'AV34TFCentroCostosHoraAlt_To',fld:'vTFCENTROCOSTOSHORAALT_TO',pic:'',type:'date'},{av:'AV39TFCentroCostosEstado_Sels',fld:'vTFCENTROCOSTOSESTADO_SELS',pic:''},{av:'AV41TFCentroCostosTipoRef_Sels',fld:'vTFCENTROCOSTOSTIPOREF_SELS',pic:''},{av:'AV49IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV50IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV45GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV46GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV47GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV49IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV50IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV18ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E123Y2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8ListaCostosId',fld:'vLISTACOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV52Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21TFCentroCostosId',fld:'vTFCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22TFCentroCostosId_To',fld:'vTFCENTROCOSTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV23TFCentroCostosRef',fld:'vTFCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV24TFCentroCostosRef_To',fld:'vTFCENTROCOSTOSREF_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV25TFCentroCostosNombre',fld:'vTFCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV26TFCentroCostosNombre_Sel',fld:'vTFCENTROCOSTOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV27TFCentroCostosPrecioFinal',fld:'vTFCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV28TFCentroCostosPrecioFinal_To',fld:'vTFCENTROCOSTOSPRECIOFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV29TFCentroCostosCosto',fld:'vTFCENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV30TFCentroCostosCosto_To',fld:'vTFCENTROCOSTOSCOSTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV31TFCentroCostosUsrAlta',fld:'vTFCENTROCOSTOSUSRALTA',pic:'',type:'char'},{av:'AV32TFCentroCostosUsrAlta_Sel',fld:'vTFCENTROCOSTOSUSRALTA_SEL',pic:'',type:'char'},{av:'AV33TFCentroCostosHoraAlt',fld:'vTFCENTROCOSTOSHORAALT',pic:'',type:'date'},{av:'AV34TFCentroCostosHoraAlt_To',fld:'vTFCENTROCOSTOSHORAALT_TO',pic:'',type:'date'},{av:'AV39TFCentroCostosEstado_Sels',fld:'vTFCENTROCOSTOSESTADO_SELS',pic:''},{av:'AV41TFCentroCostosTipoRef_Sels',fld:'vTFCENTROCOSTOSTIPOREF_SELS',pic:''},{av:'AV49IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV50IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV45GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV46GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV47GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV49IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV50IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV18ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E133Y2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8ListaCostosId',fld:'vLISTACOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV52Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21TFCentroCostosId',fld:'vTFCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22TFCentroCostosId_To',fld:'vTFCENTROCOSTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV23TFCentroCostosRef',fld:'vTFCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV24TFCentroCostosRef_To',fld:'vTFCENTROCOSTOSREF_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV25TFCentroCostosNombre',fld:'vTFCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV26TFCentroCostosNombre_Sel',fld:'vTFCENTROCOSTOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV27TFCentroCostosPrecioFinal',fld:'vTFCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV28TFCentroCostosPrecioFinal_To',fld:'vTFCENTROCOSTOSPRECIOFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV29TFCentroCostosCosto',fld:'vTFCENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV30TFCentroCostosCosto_To',fld:'vTFCENTROCOSTOSCOSTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV31TFCentroCostosUsrAlta',fld:'vTFCENTROCOSTOSUSRALTA',pic:'',type:'char'},{av:'AV32TFCentroCostosUsrAlta_Sel',fld:'vTFCENTROCOSTOSUSRALTA_SEL',pic:'',type:'char'},{av:'AV33TFCentroCostosHoraAlt',fld:'vTFCENTROCOSTOSHORAALT',pic:'',type:'date'},{av:'AV34TFCentroCostosHoraAlt_To',fld:'vTFCENTROCOSTOSHORAALT_TO',pic:'',type:'date'},{av:'AV39TFCentroCostosEstado_Sels',fld:'vTFCENTROCOSTOSESTADO_SELS',pic:''},{av:'AV41TFCentroCostosTipoRef_Sels',fld:'vTFCENTROCOSTOSTIPOREF_SELS',pic:''},{av:'AV49IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV50IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E143Y2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8ListaCostosId',fld:'vLISTACOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV52Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21TFCentroCostosId',fld:'vTFCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22TFCentroCostosId_To',fld:'vTFCENTROCOSTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV23TFCentroCostosRef',fld:'vTFCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV24TFCentroCostosRef_To',fld:'vTFCENTROCOSTOSREF_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV25TFCentroCostosNombre',fld:'vTFCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV26TFCentroCostosNombre_Sel',fld:'vTFCENTROCOSTOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV27TFCentroCostosPrecioFinal',fld:'vTFCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV28TFCentroCostosPrecioFinal_To',fld:'vTFCENTROCOSTOSPRECIOFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV29TFCentroCostosCosto',fld:'vTFCENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV30TFCentroCostosCosto_To',fld:'vTFCENTROCOSTOSCOSTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV31TFCentroCostosUsrAlta',fld:'vTFCENTROCOSTOSUSRALTA',pic:'',type:'char'},{av:'AV32TFCentroCostosUsrAlta_Sel',fld:'vTFCENTROCOSTOSUSRALTA_SEL',pic:'',type:'char'},{av:'AV33TFCentroCostosHoraAlt',fld:'vTFCENTROCOSTOSHORAALT',pic:'',type:'date'},{av:'AV34TFCentroCostosHoraAlt_To',fld:'vTFCENTROCOSTOSHORAALT_TO',pic:'',type:'date'},{av:'AV39TFCentroCostosEstado_Sels',fld:'vTFCENTROCOSTOSESTADO_SELS',pic:''},{av:'AV41TFCentroCostosTipoRef_Sels',fld:'vTFCENTROCOSTOSTIPOREF_SELS',pic:''},{av:'AV49IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV50IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV40TFCentroCostosTipoRef_SelsJson',fld:'vTFCENTROCOSTOSTIPOREF_SELSJSON',pic:'',type:'vchar'},{av:'AV41TFCentroCostosTipoRef_Sels',fld:'vTFCENTROCOSTOSTIPOREF_SELS',pic:''},{av:'AV38TFCentroCostosEstado_SelsJson',fld:'vTFCENTROCOSTOSESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV39TFCentroCostosEstado_Sels',fld:'vTFCENTROCOSTOSESTADO_SELS',pic:''},{av:'AV33TFCentroCostosHoraAlt',fld:'vTFCENTROCOSTOSHORAALT',pic:'',type:'date'},{av:'AV34TFCentroCostosHoraAlt_To',fld:'vTFCENTROCOSTOSHORAALT_TO',pic:'',type:'date'},{av:'AV31TFCentroCostosUsrAlta',fld:'vTFCENTROCOSTOSUSRALTA',pic:'',type:'char'},{av:'AV32TFCentroCostosUsrAlta_Sel',fld:'vTFCENTROCOSTOSUSRALTA_SEL',pic:'',type:'char'},{av:'AV29TFCentroCostosCosto',fld:'vTFCENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV30TFCentroCostosCosto_To',fld:'vTFCENTROCOSTOSCOSTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV27TFCentroCostosPrecioFinal',fld:'vTFCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV28TFCentroCostosPrecioFinal_To',fld:'vTFCENTROCOSTOSPRECIOFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV25TFCentroCostosNombre',fld:'vTFCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV26TFCentroCostosNombre_Sel',fld:'vTFCENTROCOSTOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV23TFCentroCostosRef',fld:'vTFCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV24TFCentroCostosRef_To',fld:'vTFCENTROCOSTOSREF_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21TFCentroCostosId',fld:'vTFCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22TFCentroCostosId_To',fld:'vTFCENTROCOSTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E183Y2',iparms:[{av:'AV49IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV50IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'A461CentroCostosId',fld:'CENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A462CentroCostosRef',fld:'CENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV48GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'edtCentroCostosNombre_Link',ctrl:'CENTROCOSTOSNOMBRE',prop:'Link'}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E113Y2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8ListaCostosId',fld:'vLISTACOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV52Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21TFCentroCostosId',fld:'vTFCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22TFCentroCostosId_To',fld:'vTFCENTROCOSTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV23TFCentroCostosRef',fld:'vTFCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV24TFCentroCostosRef_To',fld:'vTFCENTROCOSTOSREF_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV25TFCentroCostosNombre',fld:'vTFCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV26TFCentroCostosNombre_Sel',fld:'vTFCENTROCOSTOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV27TFCentroCostosPrecioFinal',fld:'vTFCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV28TFCentroCostosPrecioFinal_To',fld:'vTFCENTROCOSTOSPRECIOFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV29TFCentroCostosCosto',fld:'vTFCENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV30TFCentroCostosCosto_To',fld:'vTFCENTROCOSTOSCOSTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV31TFCentroCostosUsrAlta',fld:'vTFCENTROCOSTOSUSRALTA',pic:'',type:'char'},{av:'AV32TFCentroCostosUsrAlta_Sel',fld:'vTFCENTROCOSTOSUSRALTA_SEL',pic:'',type:'char'},{av:'AV33TFCentroCostosHoraAlt',fld:'vTFCENTROCOSTOSHORAALT',pic:'',type:'date'},{av:'AV34TFCentroCostosHoraAlt_To',fld:'vTFCENTROCOSTOSHORAALT_TO',pic:'',type:'date'},{av:'AV39TFCentroCostosEstado_Sels',fld:'vTFCENTROCOSTOSESTADO_SELS',pic:''},{av:'AV41TFCentroCostosTipoRef_Sels',fld:'vTFCENTROCOSTOSTIPOREF_SELS',pic:''},{av:'AV49IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV50IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''},{av:'AV38TFCentroCostosEstado_SelsJson',fld:'vTFCENTROCOSTOSESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV40TFCentroCostosTipoRef_SelsJson',fld:'vTFCENTROCOSTOSTIPOREF_SELSJSON',pic:'',type:'vchar'}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21TFCentroCostosId',fld:'vTFCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22TFCentroCostosId_To',fld:'vTFCENTROCOSTOSID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV23TFCentroCostosRef',fld:'vTFCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV24TFCentroCostosRef_To',fld:'vTFCENTROCOSTOSREF_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV25TFCentroCostosNombre',fld:'vTFCENTROCOSTOSNOMBRE',pic:'',type:'char'},{av:'AV26TFCentroCostosNombre_Sel',fld:'vTFCENTROCOSTOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV27TFCentroCostosPrecioFinal',fld:'vTFCENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV28TFCentroCostosPrecioFinal_To',fld:'vTFCENTROCOSTOSPRECIOFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV29TFCentroCostosCosto',fld:'vTFCENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV30TFCentroCostosCosto_To',fld:'vTFCENTROCOSTOSCOSTO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV31TFCentroCostosUsrAlta',fld:'vTFCENTROCOSTOSUSRALTA',pic:'',type:'char'},{av:'AV32TFCentroCostosUsrAlta_Sel',fld:'vTFCENTROCOSTOSUSRALTA_SEL',pic:'',type:'char'},{av:'AV33TFCentroCostosHoraAlt',fld:'vTFCENTROCOSTOSHORAALT',pic:'',type:'date'},{av:'AV34TFCentroCostosHoraAlt_To',fld:'vTFCENTROCOSTOSHORAALT_TO',pic:'',type:'date'},{av:'AV39TFCentroCostosEstado_Sels',fld:'vTFCENTROCOSTOSESTADO_SELS',pic:''},{av:'AV41TFCentroCostosTipoRef_Sels',fld:'vTFCENTROCOSTOSTIPOREF_SELS',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV40TFCentroCostosTipoRef_SelsJson',fld:'vTFCENTROCOSTOSTIPOREF_SELSJSON',pic:'',type:'vchar'},{av:'AV38TFCentroCostosEstado_SelsJson',fld:'vTFCENTROCOSTOSESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV45GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV46GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV47GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV49IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV50IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV18ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E193Y2',iparms:[{av:'cmbavGridactions'},{av:'AV48GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'A461CentroCostosId',fld:'CENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A462CentroCostosRef',fld:'CENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV48GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E153Y2',iparms:[{av:'A461CentroCostosId',fld:'CENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
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
         setEventMetadata("VALID_CENTROCOSTOSUSRALTA","{handler:'Valid_Centrocostosusralta',iparms:[]");
         setEventMetadata("VALID_CENTROCOSTOSUSRALTA",",oparms:[]}");
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
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV16FilterFullText = "";
         AV52Pgmname = "";
         AV25TFCentroCostosNombre = "";
         AV26TFCentroCostosNombre_Sel = "";
         AV31TFCentroCostosUsrAlta = "";
         AV32TFCentroCostosUsrAlta_Sel = "";
         AV33TFCentroCostosHoraAlt = DateTime.MinValue;
         AV34TFCentroCostosHoraAlt_To = DateTime.MinValue;
         AV39TFCentroCostosEstado_Sels = new GxSimpleCollection<string>();
         AV41TFCentroCostosTipoRef_Sels = new GxSimpleCollection<string>();
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV18ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV47GridAppliedFilters = "";
         AV42DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV36DDO_CentroCostosHoraAltAuxDateTo = DateTime.MinValue;
         AV12GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV38TFCentroCostosEstado_SelsJson = "";
         AV40TFCentroCostosTipoRef_SelsJson = "";
         AV35DDO_CentroCostosHoraAltAuxDate = DateTime.MinValue;
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
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
         AV37DDO_CentroCostosHoraAltAuxDateText = "";
         ucTfcentrocostoshoraalt_rangepicker = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A463CentroCostosNombre = "";
         A478CentroCostosUsrAlta = "";
         A480CentroCostosHoraAlt = DateTime.MinValue;
         A482CentroCostosEstado = "";
         A487CentroCostosTipoRef = "";
         GXDecQS = "";
         lV25TFCentroCostosNombre = "";
         lV31TFCentroCostosUsrAlta = "";
         H003Y2_A466CentroCostosDetallesId = new long[1] ;
         H003Y2_A459ListaCostosId = new long[1] ;
         H003Y2_n459ListaCostosId = new bool[] {false} ;
         H003Y2_A487CentroCostosTipoRef = new string[] {""} ;
         H003Y2_A482CentroCostosEstado = new string[] {""} ;
         H003Y2_A480CentroCostosHoraAlt = new DateTime[] {DateTime.MinValue} ;
         H003Y2_A478CentroCostosUsrAlta = new string[] {""} ;
         H003Y2_A475CentroCostosCosto = new decimal[1] ;
         H003Y2_A465CentroCostosSerial = new long[1] ;
         H003Y2_A464CentroCostosPrecioFinal = new decimal[1] ;
         H003Y2_A463CentroCostosNombre = new string[] {""} ;
         H003Y2_A462CentroCostosRef = new long[1] ;
         H003Y2_A461CentroCostosId = new long[1] ;
         H003Y3_A466CentroCostosDetallesId = new long[1] ;
         H003Y3_A459ListaCostosId = new long[1] ;
         H003Y3_n459ListaCostosId = new bool[] {false} ;
         H003Y3_A487CentroCostosTipoRef = new string[] {""} ;
         H003Y3_A482CentroCostosEstado = new string[] {""} ;
         H003Y3_A480CentroCostosHoraAlt = new DateTime[] {DateTime.MinValue} ;
         H003Y3_A478CentroCostosUsrAlta = new string[] {""} ;
         H003Y3_A475CentroCostosCosto = new decimal[1] ;
         H003Y3_A465CentroCostosSerial = new long[1] ;
         H003Y3_A464CentroCostosPrecioFinal = new decimal[1] ;
         H003Y3_A463CentroCostosNombre = new string[] {""} ;
         H003Y3_A462CentroCostosRef = new long[1] ;
         H003Y3_A461CentroCostosId = new long[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV19ManageFiltersXml = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV17Session = context.GetSession();
         AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char5 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9HTTPRequest = new GxHttpRequest( context);
         AV11TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV8ListaCostosId = "";
         subGrid_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.listacostosdetalleswc__default(),
            new Object[][] {
                new Object[] {
               H003Y2_A466CentroCostosDetallesId, H003Y2_A459ListaCostosId, H003Y2_n459ListaCostosId, H003Y2_A487CentroCostosTipoRef, H003Y2_A482CentroCostosEstado, H003Y2_A480CentroCostosHoraAlt, H003Y2_A478CentroCostosUsrAlta, H003Y2_A475CentroCostosCosto, H003Y2_A465CentroCostosSerial, H003Y2_A464CentroCostosPrecioFinal,
               H003Y2_A463CentroCostosNombre, H003Y2_A462CentroCostosRef, H003Y2_A461CentroCostosId
               }
               , new Object[] {
               H003Y3_A466CentroCostosDetallesId, H003Y3_A459ListaCostosId, H003Y3_n459ListaCostosId, H003Y3_A487CentroCostosTipoRef, H003Y3_A482CentroCostosEstado, H003Y3_A480CentroCostosHoraAlt, H003Y3_A478CentroCostosUsrAlta, H003Y3_A475CentroCostosCosto, H003Y3_A465CentroCostosSerial, H003Y3_A464CentroCostosPrecioFinal,
               H003Y3_A463CentroCostosNombre, H003Y3_A462CentroCostosRef, H003Y3_A461CentroCostosId
               }
            }
         );
         AV52Pgmname = "ListaCostosDetallesWC";
         /* GeneXus formulas. */
         AV52Pgmname = "ListaCostosDetallesWC";
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
      private short AV48GridActions ;
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
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int edtListaCostosId_Visible ;
      private int subGrid_Islastpage ;
      private int AV39TFCentroCostosEstado_Sels_Count ;
      private int AV41TFCentroCostosTipoRef_Sels_Count ;
      private int edtCentroCostosId_Enabled ;
      private int edtCentroCostosRef_Enabled ;
      private int edtCentroCostosNombre_Enabled ;
      private int edtCentroCostosPrecioFinal_Enabled ;
      private int edtCentroCostosSerial_Enabled ;
      private int edtCentroCostosCosto_Enabled ;
      private int edtCentroCostosUsrAlta_Enabled ;
      private int edtCentroCostosHoraAlt_Enabled ;
      private int edtListaCostosId_Enabled ;
      private int AV44PageToGo ;
      private int AV53GXV1 ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV8ListaCostosId ;
      private long wcpOAV8ListaCostosId ;
      private long GRID_nFirstRecordOnPage ;
      private long AV21TFCentroCostosId ;
      private long AV22TFCentroCostosId_To ;
      private long AV23TFCentroCostosRef ;
      private long AV24TFCentroCostosRef_To ;
      private long AV45GridCurrentPage ;
      private long AV46GridPageCount ;
      private long A459ListaCostosId ;
      private long A461CentroCostosId ;
      private long A462CentroCostosRef ;
      private long A465CentroCostosSerial ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV27TFCentroCostosPrecioFinal ;
      private decimal AV28TFCentroCostosPrecioFinal_To ;
      private decimal AV29TFCentroCostosCosto ;
      private decimal AV30TFCentroCostosCosto_To ;
      private decimal A464CentroCostosPrecioFinal ;
      private decimal A475CentroCostosCosto ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_37_idx="0001" ;
      private string AV52Pgmname ;
      private string AV25TFCentroCostosNombre ;
      private string AV26TFCentroCostosNombre_Sel ;
      private string AV31TFCentroCostosUsrAlta ;
      private string AV32TFCentroCostosUsrAlta_Sel ;
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
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Filteredtextto_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
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
      private string edtListaCostosId_Internalname ;
      private string edtListaCostosId_Jsonclick ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_centrocostoshoraaltauxdates_Internalname ;
      private string edtavDdo_centrocostoshoraaltauxdatetext_Internalname ;
      private string edtavDdo_centrocostoshoraaltauxdatetext_Jsonclick ;
      private string Tfcentrocostoshoraalt_rangepicker_Internalname ;
      private string sXEvt ;
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
      private string edtCentroCostosSerial_Internalname ;
      private string edtCentroCostosCosto_Internalname ;
      private string A478CentroCostosUsrAlta ;
      private string edtCentroCostosUsrAlta_Internalname ;
      private string edtCentroCostosHoraAlt_Internalname ;
      private string cmbCentroCostosEstado_Internalname ;
      private string A482CentroCostosEstado ;
      private string cmbCentroCostosTipoRef_Internalname ;
      private string A487CentroCostosTipoRef ;
      private string GXDecQS ;
      private string edtavFilterfulltext_Internalname ;
      private string lV25TFCentroCostosNombre ;
      private string lV31TFCentroCostosUsrAlta ;
      private string edtCentroCostosNombre_Link ;
      private string GXt_char2 ;
      private string GXt_char5 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sCtrlAV8ListaCostosId ;
      private string sGXsfl_37_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtCentroCostosId_Jsonclick ;
      private string edtCentroCostosRef_Jsonclick ;
      private string edtCentroCostosNombre_Jsonclick ;
      private string edtCentroCostosPrecioFinal_Jsonclick ;
      private string edtCentroCostosSerial_Jsonclick ;
      private string edtCentroCostosCosto_Jsonclick ;
      private string edtCentroCostosUsrAlta_Jsonclick ;
      private string edtCentroCostosHoraAlt_Jsonclick ;
      private string cmbCentroCostosEstado_Jsonclick ;
      private string cmbCentroCostosTipoRef_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV33TFCentroCostosHoraAlt ;
      private DateTime AV34TFCentroCostosHoraAlt_To ;
      private DateTime AV36DDO_CentroCostosHoraAltAuxDateTo ;
      private DateTime AV35DDO_CentroCostosHoraAltAuxDate ;
      private DateTime A480CentroCostosHoraAlt ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV49IsAuthorized_Update ;
      private bool AV50IsAuthorized_Delete ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n459ListaCostosId ;
      private bool bGXsfl_37_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV51TempBoolean ;
      private bool GXt_boolean3 ;
      private string AV38TFCentroCostosEstado_SelsJson ;
      private string AV40TFCentroCostosTipoRef_SelsJson ;
      private string AV19ManageFiltersXml ;
      private string AV16FilterFullText ;
      private string AV47GridAppliedFilters ;
      private string AV37DDO_CentroCostosHoraAltAuxDateText ;
      private IGxSession AV17Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfcentrocostoshoraalt_rangepicker ;
      private GXUserControl ucDdo_managefilters ;
      private GXWebForm Form ;
      private GxHttpRequest AV9HTTPRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavGridactions ;
      private GXCombobox cmbCentroCostosEstado ;
      private GXCombobox cmbCentroCostosTipoRef ;
      private GxSimpleCollection<string> AV39TFCentroCostosEstado_Sels ;
      private GxSimpleCollection<string> AV41TFCentroCostosTipoRef_Sels ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV18ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV42DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV12GridState ;
      private IDataStoreProvider pr_default ;
      private long[] H003Y2_A466CentroCostosDetallesId ;
      private long[] H003Y2_A459ListaCostosId ;
      private bool[] H003Y2_n459ListaCostosId ;
      private string[] H003Y2_A487CentroCostosTipoRef ;
      private string[] H003Y2_A482CentroCostosEstado ;
      private DateTime[] H003Y2_A480CentroCostosHoraAlt ;
      private string[] H003Y2_A478CentroCostosUsrAlta ;
      private decimal[] H003Y2_A475CentroCostosCosto ;
      private long[] H003Y2_A465CentroCostosSerial ;
      private decimal[] H003Y2_A464CentroCostosPrecioFinal ;
      private string[] H003Y2_A463CentroCostosNombre ;
      private long[] H003Y2_A462CentroCostosRef ;
      private long[] H003Y2_A461CentroCostosId ;
      private long[] H003Y3_A466CentroCostosDetallesId ;
      private long[] H003Y3_A459ListaCostosId ;
      private bool[] H003Y3_n459ListaCostosId ;
      private string[] H003Y3_A487CentroCostosTipoRef ;
      private string[] H003Y3_A482CentroCostosEstado ;
      private DateTime[] H003Y3_A480CentroCostosHoraAlt ;
      private string[] H003Y3_A478CentroCostosUsrAlta ;
      private decimal[] H003Y3_A475CentroCostosCosto ;
      private long[] H003Y3_A465CentroCostosSerial ;
      private decimal[] H003Y3_A464CentroCostosPrecioFinal ;
      private string[] H003Y3_A463CentroCostosNombre ;
      private long[] H003Y3_A462CentroCostosRef ;
      private long[] H003Y3_A461CentroCostosId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV13GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV10TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV11TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class listacostosdetalleswc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H003Y2( IGxContext context ,
                                             string A482CentroCostosEstado ,
                                             GxSimpleCollection<string> AV39TFCentroCostosEstado_Sels ,
                                             string A487CentroCostosTipoRef ,
                                             GxSimpleCollection<string> AV41TFCentroCostosTipoRef_Sels ,
                                             long AV21TFCentroCostosId ,
                                             long AV22TFCentroCostosId_To ,
                                             long AV23TFCentroCostosRef ,
                                             long AV24TFCentroCostosRef_To ,
                                             string AV26TFCentroCostosNombre_Sel ,
                                             string AV25TFCentroCostosNombre ,
                                             decimal AV27TFCentroCostosPrecioFinal ,
                                             decimal AV28TFCentroCostosPrecioFinal_To ,
                                             decimal AV29TFCentroCostosCosto ,
                                             decimal AV30TFCentroCostosCosto_To ,
                                             string AV32TFCentroCostosUsrAlta_Sel ,
                                             string AV31TFCentroCostosUsrAlta ,
                                             DateTime AV33TFCentroCostosHoraAlt ,
                                             DateTime AV34TFCentroCostosHoraAlt_To ,
                                             int AV39TFCentroCostosEstado_Sels_Count ,
                                             int AV41TFCentroCostosTipoRef_Sels_Count ,
                                             long A461CentroCostosId ,
                                             long A462CentroCostosRef ,
                                             string A463CentroCostosNombre ,
                                             decimal A464CentroCostosPrecioFinal ,
                                             decimal A475CentroCostosCosto ,
                                             string A478CentroCostosUsrAlta ,
                                             DateTime A480CentroCostosHoraAlt ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV16FilterFullText ,
                                             long AV8ListaCostosId ,
                                             long A459ListaCostosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[15];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T1.[CentroCostosDetallesId], T1.[ListaCostosId], T2.[CentroCostosTipoRef], T2.[CentroCostosEstado], T2.[CentroCostosHoraAlt], T2.[CentroCostosUsrAlta], T2.[CentroCostosCosto], T2.[CentroCostosSerial], T2.[CentroCostosPrecioFinal], T2.[CentroCostosNombre], T2.[CentroCostosRef], T1.[CentroCostosId] FROM ([CentroCostosDetalles] T1 INNER JOIN [CentroCostos] T2 ON T2.[CentroCostosId] = T1.[CentroCostosId])";
         AddWhere(sWhereString, "(T1.[ListaCostosId] = @AV8ListaCostosId)");
         if ( ! (0==AV21TFCentroCostosId) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosId] >= @AV21TFCentroCostosId)");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( ! (0==AV22TFCentroCostosId_To) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosId] <= @AV22TFCentroCostosId_To)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( ! (0==AV23TFCentroCostosRef) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosRef] >= @AV23TFCentroCostosRef)");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( ! (0==AV24TFCentroCostosRef_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosRef] <= @AV24TFCentroCostosRef_To)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFCentroCostosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFCentroCostosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[CentroCostosNombre]) like UPPER(@lV25TFCentroCostosNombre))");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFCentroCostosNombre_Sel)) && ! ( StringUtil.StrCmp(AV26TFCentroCostosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosNombre] = @AV26TFCentroCostosNombre_Sel)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFCentroCostosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[CentroCostosNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV27TFCentroCostosPrecioFinal) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosPrecioFinal] >= @AV27TFCentroCostosPrecioFinal)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV28TFCentroCostosPrecioFinal_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosPrecioFinal] <= @AV28TFCentroCostosPrecioFinal_To)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV29TFCentroCostosCosto) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosCosto] >= @AV29TFCentroCostosCosto)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV30TFCentroCostosCosto_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosCosto] <= @AV30TFCentroCostosCosto_To)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV32TFCentroCostosUsrAlta_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31TFCentroCostosUsrAlta)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[CentroCostosUsrAlta]) like UPPER(@lV31TFCentroCostosUsrAlta))");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFCentroCostosUsrAlta_Sel)) && ! ( StringUtil.StrCmp(AV32TFCentroCostosUsrAlta_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosUsrAlta] = @AV32TFCentroCostosUsrAlta_Sel)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( StringUtil.StrCmp(AV32TFCentroCostosUsrAlta_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[CentroCostosUsrAlta] = ''))");
         }
         if ( ! (DateTime.MinValue==AV33TFCentroCostosHoraAlt) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosHoraAlt] >= @AV33TFCentroCostosHoraAlt)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV34TFCentroCostosHoraAlt_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosHoraAlt] <= @AV34TFCentroCostosHoraAlt_To)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( AV39TFCentroCostosEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV39TFCentroCostosEstado_Sels, "T2.[CentroCostosEstado] IN (", ")")+")");
         }
         if ( AV41TFCentroCostosTipoRef_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV41TFCentroCostosTipoRef_Sels, "T2.[CentroCostosTipoRef] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T1.[CentroCostosId]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T1.[CentroCostosId] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosRef]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosRef] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosNombre]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosPrecioFinal]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosPrecioFinal] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosCosto]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosCosto] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosUsrAlta]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosUsrAlta] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosHoraAlt]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosHoraAlt] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosEstado]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosEstado] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosTipoRef]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosTipoRef] DESC";
         }
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_H003Y3( IGxContext context ,
                                             string A482CentroCostosEstado ,
                                             GxSimpleCollection<string> AV39TFCentroCostosEstado_Sels ,
                                             string A487CentroCostosTipoRef ,
                                             GxSimpleCollection<string> AV41TFCentroCostosTipoRef_Sels ,
                                             long AV21TFCentroCostosId ,
                                             long AV22TFCentroCostosId_To ,
                                             long AV23TFCentroCostosRef ,
                                             long AV24TFCentroCostosRef_To ,
                                             string AV26TFCentroCostosNombre_Sel ,
                                             string AV25TFCentroCostosNombre ,
                                             decimal AV27TFCentroCostosPrecioFinal ,
                                             decimal AV28TFCentroCostosPrecioFinal_To ,
                                             decimal AV29TFCentroCostosCosto ,
                                             decimal AV30TFCentroCostosCosto_To ,
                                             string AV32TFCentroCostosUsrAlta_Sel ,
                                             string AV31TFCentroCostosUsrAlta ,
                                             DateTime AV33TFCentroCostosHoraAlt ,
                                             DateTime AV34TFCentroCostosHoraAlt_To ,
                                             int AV39TFCentroCostosEstado_Sels_Count ,
                                             int AV41TFCentroCostosTipoRef_Sels_Count ,
                                             long A461CentroCostosId ,
                                             long A462CentroCostosRef ,
                                             string A463CentroCostosNombre ,
                                             decimal A464CentroCostosPrecioFinal ,
                                             decimal A475CentroCostosCosto ,
                                             string A478CentroCostosUsrAlta ,
                                             DateTime A480CentroCostosHoraAlt ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV16FilterFullText ,
                                             long AV8ListaCostosId ,
                                             long A459ListaCostosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[15];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT T1.[CentroCostosDetallesId], T1.[ListaCostosId], T2.[CentroCostosTipoRef], T2.[CentroCostosEstado], T2.[CentroCostosHoraAlt], T2.[CentroCostosUsrAlta], T2.[CentroCostosCosto], T2.[CentroCostosSerial], T2.[CentroCostosPrecioFinal], T2.[CentroCostosNombre], T2.[CentroCostosRef], T1.[CentroCostosId] FROM ([CentroCostosDetalles] T1 INNER JOIN [CentroCostos] T2 ON T2.[CentroCostosId] = T1.[CentroCostosId])";
         AddWhere(sWhereString, "(T1.[ListaCostosId] = @AV8ListaCostosId)");
         if ( ! (0==AV21TFCentroCostosId) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosId] >= @AV21TFCentroCostosId)");
         }
         else
         {
            GXv_int10[1] = 1;
         }
         if ( ! (0==AV22TFCentroCostosId_To) )
         {
            AddWhere(sWhereString, "(T1.[CentroCostosId] <= @AV22TFCentroCostosId_To)");
         }
         else
         {
            GXv_int10[2] = 1;
         }
         if ( ! (0==AV23TFCentroCostosRef) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosRef] >= @AV23TFCentroCostosRef)");
         }
         else
         {
            GXv_int10[3] = 1;
         }
         if ( ! (0==AV24TFCentroCostosRef_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosRef] <= @AV24TFCentroCostosRef_To)");
         }
         else
         {
            GXv_int10[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFCentroCostosNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFCentroCostosNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[CentroCostosNombre]) like UPPER(@lV25TFCentroCostosNombre))");
         }
         else
         {
            GXv_int10[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFCentroCostosNombre_Sel)) && ! ( StringUtil.StrCmp(AV26TFCentroCostosNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosNombre] = @AV26TFCentroCostosNombre_Sel)");
         }
         else
         {
            GXv_int10[6] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFCentroCostosNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[CentroCostosNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV27TFCentroCostosPrecioFinal) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosPrecioFinal] >= @AV27TFCentroCostosPrecioFinal)");
         }
         else
         {
            GXv_int10[7] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV28TFCentroCostosPrecioFinal_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosPrecioFinal] <= @AV28TFCentroCostosPrecioFinal_To)");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV29TFCentroCostosCosto) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosCosto] >= @AV29TFCentroCostosCosto)");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV30TFCentroCostosCosto_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosCosto] <= @AV30TFCentroCostosCosto_To)");
         }
         else
         {
            GXv_int10[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV32TFCentroCostosUsrAlta_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31TFCentroCostosUsrAlta)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[CentroCostosUsrAlta]) like UPPER(@lV31TFCentroCostosUsrAlta))");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFCentroCostosUsrAlta_Sel)) && ! ( StringUtil.StrCmp(AV32TFCentroCostosUsrAlta_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosUsrAlta] = @AV32TFCentroCostosUsrAlta_Sel)");
         }
         else
         {
            GXv_int10[12] = 1;
         }
         if ( StringUtil.StrCmp(AV32TFCentroCostosUsrAlta_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[CentroCostosUsrAlta] = ''))");
         }
         if ( ! (DateTime.MinValue==AV33TFCentroCostosHoraAlt) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosHoraAlt] >= @AV33TFCentroCostosHoraAlt)");
         }
         else
         {
            GXv_int10[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV34TFCentroCostosHoraAlt_To) )
         {
            AddWhere(sWhereString, "(T2.[CentroCostosHoraAlt] <= @AV34TFCentroCostosHoraAlt_To)");
         }
         else
         {
            GXv_int10[14] = 1;
         }
         if ( AV39TFCentroCostosEstado_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV39TFCentroCostosEstado_Sels, "T2.[CentroCostosEstado] IN (", ")")+")");
         }
         if ( AV41TFCentroCostosTipoRef_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV41TFCentroCostosTipoRef_Sels, "T2.[CentroCostosTipoRef] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T1.[CentroCostosId]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T1.[CentroCostosId] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosRef]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosRef] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosNombre]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosPrecioFinal]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosPrecioFinal] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosCosto]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosCosto] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosUsrAlta]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosUsrAlta] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosHoraAlt]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosHoraAlt] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosEstado]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosEstado] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId], T2.[CentroCostosTipoRef]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ListaCostosId] DESC, T2.[CentroCostosTipoRef] DESC";
         }
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H003Y2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (decimal)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (decimal)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (string)dynConstraints[25] , (DateTime)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] , (string)dynConstraints[29] , (long)dynConstraints[30] , (long)dynConstraints[31] );
               case 1 :
                     return conditional_H003Y3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (decimal)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (decimal)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (string)dynConstraints[25] , (DateTime)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] , (string)dynConstraints[29] , (long)dynConstraints[30] , (long)dynConstraints[31] );
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
          Object[] prmH003Y2;
          prmH003Y2 = new Object[] {
          new ParDef("@AV8ListaCostosId",GXType.Decimal,18,0) ,
          new ParDef("@AV21TFCentroCostosId",GXType.Decimal,18,0) ,
          new ParDef("@AV22TFCentroCostosId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV23TFCentroCostosRef",GXType.Decimal,18,0) ,
          new ParDef("@AV24TFCentroCostosRef_To",GXType.Decimal,18,0) ,
          new ParDef("@lV25TFCentroCostosNombre",GXType.Char,80,0) ,
          new ParDef("@AV26TFCentroCostosNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@AV27TFCentroCostosPrecioFinal",GXType.Decimal,18,2) ,
          new ParDef("@AV28TFCentroCostosPrecioFinal_To",GXType.Decimal,18,2) ,
          new ParDef("@AV29TFCentroCostosCosto",GXType.Decimal,18,2) ,
          new ParDef("@AV30TFCentroCostosCosto_To",GXType.Decimal,18,2) ,
          new ParDef("@lV31TFCentroCostosUsrAlta",GXType.Char,30,0) ,
          new ParDef("@AV32TFCentroCostosUsrAlta_Sel",GXType.NChar,30,0) ,
          new ParDef("@AV33TFCentroCostosHoraAlt",GXType.Date,8,0) ,
          new ParDef("@AV34TFCentroCostosHoraAlt_To",GXType.Date,8,0)
          };
          Object[] prmH003Y3;
          prmH003Y3 = new Object[] {
          new ParDef("@AV8ListaCostosId",GXType.Decimal,18,0) ,
          new ParDef("@AV21TFCentroCostosId",GXType.Decimal,18,0) ,
          new ParDef("@AV22TFCentroCostosId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV23TFCentroCostosRef",GXType.Decimal,18,0) ,
          new ParDef("@AV24TFCentroCostosRef_To",GXType.Decimal,18,0) ,
          new ParDef("@lV25TFCentroCostosNombre",GXType.Char,80,0) ,
          new ParDef("@AV26TFCentroCostosNombre_Sel",GXType.NChar,80,0) ,
          new ParDef("@AV27TFCentroCostosPrecioFinal",GXType.Decimal,18,2) ,
          new ParDef("@AV28TFCentroCostosPrecioFinal_To",GXType.Decimal,18,2) ,
          new ParDef("@AV29TFCentroCostosCosto",GXType.Decimal,18,2) ,
          new ParDef("@AV30TFCentroCostosCosto_To",GXType.Decimal,18,2) ,
          new ParDef("@lV31TFCentroCostosUsrAlta",GXType.Char,30,0) ,
          new ParDef("@AV32TFCentroCostosUsrAlta_Sel",GXType.NChar,30,0) ,
          new ParDef("@AV33TFCentroCostosHoraAlt",GXType.Date,8,0) ,
          new ParDef("@AV34TFCentroCostosHoraAlt_To",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003Y2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003Y2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003Y3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003Y3,11, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 1);
                ((string[]) buf[4])[0] = rslt.getString(4, 3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 30);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 80);
                ((long[]) buf[11])[0] = rslt.getLong(11);
                ((long[]) buf[12])[0] = rslt.getLong(12);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 1);
                ((string[]) buf[4])[0] = rslt.getString(4, 3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 30);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 80);
                ((long[]) buf[11])[0] = rslt.getLong(11);
                ((long[]) buf[12])[0] = rslt.getLong(12);
                return;
       }
    }

 }

}
