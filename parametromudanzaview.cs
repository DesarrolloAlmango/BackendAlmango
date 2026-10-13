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
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class parametromudanzaview : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public parametromudanzaview( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public parametromudanzaview( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_ParametroMudanzaId ,
                           string aP1_TabCode )
      {
         this.AV10ParametroMudanzaId = aP0_ParametroMudanzaId;
         this.AV8TabCode = aP1_TabCode;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "ParametroMudanzaId");
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
               gxfirstwebparm = GetFirstPar( "ParametroMudanzaId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "ParametroMudanzaId");
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
         PAFR2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTFR2( ) ;
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
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true, false);
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "parametromudanzaview.aspx"+UrlEncode(StringUtil.LTrimStr(AV10ParametroMudanzaId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TabCode));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("parametromudanzaview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vRECORDDESCRIPTION", AV16RecordDescription);
         GxWebStd.gx_hidden_field( context, "gxhash_vRECORDDESCRIPTION", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV16RecordDescription, "")), context));
         GxWebStd.gx_hidden_field( context, "vPARAMETROMUDANZAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10ParametroMudanzaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPARAMETROMUDANZAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10ParametroMudanzaId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTABCODE", StringUtil.RTrim( AV8TabCode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "PARAMETROMUDANZAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A730ParametroMudanzaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vRECORDDESCRIPTION", AV16RecordDescription);
         GxWebStd.gx_hidden_field( context, "gxhash_vRECORDDESCRIPTION", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV16RecordDescription, "")), context));
         GxWebStd.gx_hidden_field( context, "vPARAMETROMUDANZAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10ParametroMudanzaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPARAMETROMUDANZAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10ParametroMudanzaId), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vLOADALLTABS", AV11LoadAllTabs);
         GxWebStd.gx_hidden_field( context, "vSELECTEDTABCODE", StringUtil.RTrim( AV12SelectedTabCode));
         GxWebStd.gx_hidden_field( context, "vTABCODE", StringUtil.RTrim( AV8TabCode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Icontype", StringUtil.RTrim( Ddc_subscriptions_Icontype));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Icon", StringUtil.RTrim( Ddc_subscriptions_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Tooltip", StringUtil.RTrim( Ddc_subscriptions_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Cls", StringUtil.RTrim( Ddc_subscriptions_Cls));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Visible", StringUtil.BoolToStr( Ddc_subscriptions_Visible));
         GxWebStd.gx_hidden_field( context, "DDC_DISCUSSIONS_Icontype", StringUtil.RTrim( Ddc_discussions_Icontype));
         GxWebStd.gx_hidden_field( context, "DDC_DISCUSSIONS_Icon", StringUtil.RTrim( Ddc_discussions_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_DISCUSSIONS_Tooltip", StringUtil.RTrim( Ddc_discussions_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDC_DISCUSSIONS_Cls", StringUtil.RTrim( Ddc_discussions_Cls));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Width", StringUtil.RTrim( Panel_general_Width));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Autowidth", StringUtil.BoolToStr( Panel_general_Autowidth));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Autoheight", StringUtil.BoolToStr( Panel_general_Autoheight));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Cls", StringUtil.RTrim( Panel_general_Cls));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Title", StringUtil.RTrim( Panel_general_Title));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Collapsible", StringUtil.BoolToStr( Panel_general_Collapsible));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Collapsed", StringUtil.BoolToStr( Panel_general_Collapsed));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Showcollapseicon", StringUtil.BoolToStr( Panel_general_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Iconposition", StringUtil.RTrim( Panel_general_Iconposition));
         GxWebStd.gx_hidden_field( context, "PANEL_GENERAL_Autoscroll", StringUtil.BoolToStr( Panel_general_Autoscroll));
         GxWebStd.gx_hidden_field( context, "TABS_Activepagecontrolname", StringUtil.RTrim( Tabs_Activepagecontrolname));
         GxWebStd.gx_hidden_field( context, "TABS_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Tabs_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TABS_Class", StringUtil.RTrim( Tabs_Class));
         GxWebStd.gx_hidden_field( context, "TABS_Historymanagement", StringUtil.BoolToStr( Tabs_Historymanagement));
         GxWebStd.gx_hidden_field( context, "TABS_Activepagecontrolname", StringUtil.RTrim( Tabs_Activepagecontrolname));
         GxWebStd.gx_hidden_field( context, "TABS_Activepagecontrolname", StringUtil.RTrim( Tabs_Activepagecontrolname));
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
         if ( ! ( WebComp_Webcomponent_general == null ) )
         {
            WebComp_Webcomponent_general.componentjscripts();
         }
         if ( ! ( WebComp_Mudanzawc == null ) )
         {
            WebComp_Mudanzawc.componentjscripts();
         }
         if ( ! ( WebComp_Mudanza1wc == null ) )
         {
            WebComp_Mudanza1wc.componentjscripts();
         }
         if ( ! ( WebComp_Mudanza2wc == null ) )
         {
            WebComp_Mudanza2wc.componentjscripts();
         }
         if ( ! ( WebComp_Mudanza3wc == null ) )
         {
            WebComp_Mudanza3wc.componentjscripts();
         }
         if ( ! ( WebComp_Cargamudanzawc == null ) )
         {
            WebComp_Cargamudanzawc.componentjscripts();
         }
         if ( ! ( WebComp_Adicionalmudanzawc == null ) )
         {
            WebComp_Adicionalmudanzawc.componentjscripts();
         }
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
            WEFR2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTFR2( ) ;
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "parametromudanzaview.aspx"+UrlEncode(StringUtil.LTrimStr(AV10ParametroMudanzaId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TabCode));
         return formatLink("parametromudanzaview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "ParametroMudanzaView" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Parametro Mudanza View", "") ;
      }

      protected void WBFR0( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellWWLinkPanel", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableviewrightitems_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "justify-content:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ViewCellRightItem", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblWorkwithlink_Internalname, context.GetMessage( "Ir a Parametro Mudanza", ""), lblWorkwithlink_Link, "", lblWorkwithlink_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockLink", 0, "", 1, 1, 0, 0, "HLP_ParametroMudanzaView.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ViewCellRightItem", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, "DDC_SUBSCRIPTIONSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ViewCellRightItem", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDdc_discussions.SetProperty("IconType", Ddc_discussions_Icontype);
            ucDdc_discussions.SetProperty("Icon", Ddc_discussions_Icon);
            ucDdc_discussions.SetProperty("Caption", Ddc_discussions_Caption);
            ucDdc_discussions.SetProperty("Tooltip", Ddc_discussions_Tooltip);
            ucDdc_discussions.SetProperty("Cls", Ddc_discussions_Cls);
            ucDdc_discussions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_discussions_Internalname, "DDC_DISCUSSIONSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divParametromudanzageneral_cell_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucPanel_general.SetProperty("Width", Panel_general_Width);
            ucPanel_general.SetProperty("AutoWidth", Panel_general_Autowidth);
            ucPanel_general.SetProperty("AutoHeight", Panel_general_Autoheight);
            ucPanel_general.SetProperty("Cls", Panel_general_Cls);
            ucPanel_general.SetProperty("Title", Panel_general_Title);
            ucPanel_general.SetProperty("Collapsible", Panel_general_Collapsible);
            ucPanel_general.SetProperty("Collapsed", Panel_general_Collapsed);
            ucPanel_general.SetProperty("ShowCollapseIcon", Panel_general_Showcollapseicon);
            ucPanel_general.SetProperty("IconPosition", Panel_general_Iconposition);
            ucPanel_general.SetProperty("AutoScroll", Panel_general_Autoscroll);
            ucPanel_general.Render(context, "dvelop.gxbootstrap.panel_al", Panel_general_Internalname, "PANEL_GENERALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"PANEL_GENERALContainer"+"TablePanel_General"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablepanel_general_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0023"+"", StringUtil.RTrim( WebComp_Webcomponent_general_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0023"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Webcomponent_general_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWebcomponent_general), StringUtil.Lower( WebComp_Webcomponent_general_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0023"+"");
                  }
                  WebComp_Webcomponent_general.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWebcomponent_general), StringUtil.Lower( WebComp_Webcomponent_general_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellViewTabsPosition CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableviewcontainer_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellViewTab", "start", "top", "", "", "div");
            /* User Defined Control */
            ucTabs.SetProperty("PageCount", Tabs_Pagecount);
            ucTabs.SetProperty("Class", Tabs_Class);
            ucTabs.SetProperty("HistoryManagement", Tabs_Historymanagement);
            ucTabs.Render(context, "tab", Tabs_Internalname, "TABSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMudanza_title_Internalname, context.GetMessage( "Tipo Inmueble Origen", ""), "", "", lblMudanza_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ParametroMudanzaView.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Mudanza") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablemudanza_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0037"+"", StringUtil.RTrim( WebComp_Mudanzawc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0037"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Mudanzawc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldMudanzawc), StringUtil.Lower( WebComp_Mudanzawc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0037"+"");
                  }
                  WebComp_Mudanzawc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldMudanzawc), StringUtil.Lower( WebComp_Mudanzawc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMudanza1_title_Internalname, context.GetMessage( "Tipo Inmueble Destino", ""), "", "", lblMudanza1_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ParametroMudanzaView.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Mudanza1") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablemudanza1_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0045"+"", StringUtil.RTrim( WebComp_Mudanza1wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0045"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Mudanza1wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldMudanza1wc), StringUtil.Lower( WebComp_Mudanza1wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0045"+"");
                  }
                  WebComp_Mudanza1wc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldMudanza1wc), StringUtil.Lower( WebComp_Mudanza1wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title3"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMudanza2_title_Internalname, context.GetMessage( "Tipo Estacionam Origen", ""), "", "", lblMudanza2_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ParametroMudanzaView.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Mudanza2") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablemudanza2_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0053"+"", StringUtil.RTrim( WebComp_Mudanza2wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0053"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Mudanza2wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldMudanza2wc), StringUtil.Lower( WebComp_Mudanza2wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0053"+"");
                  }
                  WebComp_Mudanza2wc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldMudanza2wc), StringUtil.Lower( WebComp_Mudanza2wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title4"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMudanza3_title_Internalname, context.GetMessage( "Tipo Estacionam Destino", ""), "", "", lblMudanza3_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ParametroMudanzaView.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Mudanza3") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel4"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablemudanza3_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0061"+"", StringUtil.RTrim( WebComp_Mudanza3wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0061"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Mudanza3wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldMudanza3wc), StringUtil.Lower( WebComp_Mudanza3wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0061"+"");
                  }
                  WebComp_Mudanza3wc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldMudanza3wc), StringUtil.Lower( WebComp_Mudanza3wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title5"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCargamudanza_title_Internalname, context.GetMessage( "Mudanza", ""), "", "", lblCargamudanza_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ParametroMudanzaView.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "CargaMudanza") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel5"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablecargamudanza_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0069"+"", StringUtil.RTrim( WebComp_Cargamudanzawc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0069"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Cargamudanzawc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldCargamudanzawc), StringUtil.Lower( WebComp_Cargamudanzawc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0069"+"");
                  }
                  WebComp_Cargamudanzawc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldCargamudanzawc), StringUtil.Lower( WebComp_Cargamudanzawc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title6"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblAdicionalmudanza_title_Internalname, context.GetMessage( "Mudanza", ""), "", "", lblAdicionalmudanza_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ParametroMudanzaView.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "AdicionalMudanza") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel6"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableadicionalmudanza_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0077"+"", StringUtil.RTrim( WebComp_Adicionalmudanzawc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0077"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Adicionalmudanzawc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldAdicionalmudanzawc), StringUtil.Lower( WebComp_Adicionalmudanzawc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0077"+"");
                  }
                  WebComp_Adicionalmudanzawc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldAdicionalmudanzawc), StringUtil.Lower( WebComp_Adicionalmudanzawc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0082"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0082"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0082"+"");
                  }
                  WebComp_Wwpaux_wc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
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
         wbLoad = true;
      }

      protected void STARTFR2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Parametro Mudanza View", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPFR0( ) ;
      }

      protected void WSFR2( )
      {
         STARTFR2( ) ;
         EVTFR2( ) ;
      }

      protected void EVTFR2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E11FR2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_DISCUSSIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_discussions.Onloadcomponent */
                              E12FR2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "TABS.TABCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Tabs.Tabchanged */
                              E13FR2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E14FR2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E15FR2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E16FR2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
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
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 23 )
                        {
                           OldWebcomponent_general = cgiGet( "W0023");
                           if ( ( StringUtil.Len( OldWebcomponent_general) == 0 ) || ( StringUtil.StrCmp(OldWebcomponent_general, WebComp_Webcomponent_general_Component) != 0 ) )
                           {
                              WebComp_Webcomponent_general = getWebComponent(GetType(), "GeneXus.Programs", OldWebcomponent_general, new Object[] {context} );
                              WebComp_Webcomponent_general.ComponentInit();
                              WebComp_Webcomponent_general.Name = "OldWebcomponent_general";
                              WebComp_Webcomponent_general_Component = OldWebcomponent_general;
                           }
                           if ( StringUtil.Len( WebComp_Webcomponent_general_Component) != 0 )
                           {
                              WebComp_Webcomponent_general.componentprocess("W0023", "", sEvt);
                           }
                           WebComp_Webcomponent_general_Component = OldWebcomponent_general;
                        }
                        else if ( nCmpId == 37 )
                        {
                           OldMudanzawc = cgiGet( "W0037");
                           if ( ( StringUtil.Len( OldMudanzawc) == 0 ) || ( StringUtil.StrCmp(OldMudanzawc, WebComp_Mudanzawc_Component) != 0 ) )
                           {
                              WebComp_Mudanzawc = getWebComponent(GetType(), "GeneXus.Programs", OldMudanzawc, new Object[] {context} );
                              WebComp_Mudanzawc.ComponentInit();
                              WebComp_Mudanzawc.Name = "OldMudanzawc";
                              WebComp_Mudanzawc_Component = OldMudanzawc;
                           }
                           if ( StringUtil.Len( WebComp_Mudanzawc_Component) != 0 )
                           {
                              WebComp_Mudanzawc.componentprocess("W0037", "", sEvt);
                           }
                           WebComp_Mudanzawc_Component = OldMudanzawc;
                        }
                        else if ( nCmpId == 45 )
                        {
                           OldMudanza1wc = cgiGet( "W0045");
                           if ( ( StringUtil.Len( OldMudanza1wc) == 0 ) || ( StringUtil.StrCmp(OldMudanza1wc, WebComp_Mudanza1wc_Component) != 0 ) )
                           {
                              WebComp_Mudanza1wc = getWebComponent(GetType(), "GeneXus.Programs", OldMudanza1wc, new Object[] {context} );
                              WebComp_Mudanza1wc.ComponentInit();
                              WebComp_Mudanza1wc.Name = "OldMudanza1wc";
                              WebComp_Mudanza1wc_Component = OldMudanza1wc;
                           }
                           if ( StringUtil.Len( WebComp_Mudanza1wc_Component) != 0 )
                           {
                              WebComp_Mudanza1wc.componentprocess("W0045", "", sEvt);
                           }
                           WebComp_Mudanza1wc_Component = OldMudanza1wc;
                        }
                        else if ( nCmpId == 53 )
                        {
                           OldMudanza2wc = cgiGet( "W0053");
                           if ( ( StringUtil.Len( OldMudanza2wc) == 0 ) || ( StringUtil.StrCmp(OldMudanza2wc, WebComp_Mudanza2wc_Component) != 0 ) )
                           {
                              WebComp_Mudanza2wc = getWebComponent(GetType(), "GeneXus.Programs", OldMudanza2wc, new Object[] {context} );
                              WebComp_Mudanza2wc.ComponentInit();
                              WebComp_Mudanza2wc.Name = "OldMudanza2wc";
                              WebComp_Mudanza2wc_Component = OldMudanza2wc;
                           }
                           if ( StringUtil.Len( WebComp_Mudanza2wc_Component) != 0 )
                           {
                              WebComp_Mudanza2wc.componentprocess("W0053", "", sEvt);
                           }
                           WebComp_Mudanza2wc_Component = OldMudanza2wc;
                        }
                        else if ( nCmpId == 61 )
                        {
                           OldMudanza3wc = cgiGet( "W0061");
                           if ( ( StringUtil.Len( OldMudanza3wc) == 0 ) || ( StringUtil.StrCmp(OldMudanza3wc, WebComp_Mudanza3wc_Component) != 0 ) )
                           {
                              WebComp_Mudanza3wc = getWebComponent(GetType(), "GeneXus.Programs", OldMudanza3wc, new Object[] {context} );
                              WebComp_Mudanza3wc.ComponentInit();
                              WebComp_Mudanza3wc.Name = "OldMudanza3wc";
                              WebComp_Mudanza3wc_Component = OldMudanza3wc;
                           }
                           if ( StringUtil.Len( WebComp_Mudanza3wc_Component) != 0 )
                           {
                              WebComp_Mudanza3wc.componentprocess("W0061", "", sEvt);
                           }
                           WebComp_Mudanza3wc_Component = OldMudanza3wc;
                        }
                        else if ( nCmpId == 69 )
                        {
                           OldCargamudanzawc = cgiGet( "W0069");
                           if ( ( StringUtil.Len( OldCargamudanzawc) == 0 ) || ( StringUtil.StrCmp(OldCargamudanzawc, WebComp_Cargamudanzawc_Component) != 0 ) )
                           {
                              WebComp_Cargamudanzawc = getWebComponent(GetType(), "GeneXus.Programs", OldCargamudanzawc, new Object[] {context} );
                              WebComp_Cargamudanzawc.ComponentInit();
                              WebComp_Cargamudanzawc.Name = "OldCargamudanzawc";
                              WebComp_Cargamudanzawc_Component = OldCargamudanzawc;
                           }
                           if ( StringUtil.Len( WebComp_Cargamudanzawc_Component) != 0 )
                           {
                              WebComp_Cargamudanzawc.componentprocess("W0069", "", sEvt);
                           }
                           WebComp_Cargamudanzawc_Component = OldCargamudanzawc;
                        }
                        else if ( nCmpId == 77 )
                        {
                           OldAdicionalmudanzawc = cgiGet( "W0077");
                           if ( ( StringUtil.Len( OldAdicionalmudanzawc) == 0 ) || ( StringUtil.StrCmp(OldAdicionalmudanzawc, WebComp_Adicionalmudanzawc_Component) != 0 ) )
                           {
                              WebComp_Adicionalmudanzawc = getWebComponent(GetType(), "GeneXus.Programs", OldAdicionalmudanzawc, new Object[] {context} );
                              WebComp_Adicionalmudanzawc.ComponentInit();
                              WebComp_Adicionalmudanzawc.Name = "OldAdicionalmudanzawc";
                              WebComp_Adicionalmudanzawc_Component = OldAdicionalmudanzawc;
                           }
                           if ( StringUtil.Len( WebComp_Adicionalmudanzawc_Component) != 0 )
                           {
                              WebComp_Adicionalmudanzawc.componentprocess("W0077", "", sEvt);
                           }
                           WebComp_Adicionalmudanzawc_Component = OldAdicionalmudanzawc;
                        }
                        else if ( nCmpId == 82 )
                        {
                           OldWwpaux_wc = cgiGet( "W0082");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0082", "", sEvt);
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

      protected void WEFR2( )
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

      protected void PAFR2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "parametromudanzaview.aspx")), "parametromudanzaview.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "parametromudanzaview.aspx")))) ;
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
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( nGotPars == 0 )
               {
                  entryPointCalled = false;
                  gxfirstwebparm = GetFirstPar( "ParametroMudanzaId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV10ParametroMudanzaId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV10ParametroMudanzaId", StringUtil.LTrimStr( (decimal)(AV10ParametroMudanzaId), 4, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vPARAMETROMUDANZAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10ParametroMudanzaId), "ZZZ9"), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV8TabCode = GetPar( "TabCode");
                        AssignAttri("", false, "AV8TabCode", AV8TabCode);
                        GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
                     }
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
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
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
         RFFR2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFFR2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E15FR2 ();
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Webcomponent_general_Component) != 0 )
               {
                  WebComp_Webcomponent_general.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Mudanzawc_Component) != 0 )
               {
                  WebComp_Mudanzawc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Mudanza1wc_Component) != 0 )
               {
                  WebComp_Mudanza1wc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Mudanza2wc_Component) != 0 )
               {
                  WebComp_Mudanza2wc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Mudanza3wc_Component) != 0 )
               {
                  WebComp_Mudanza3wc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Cargamudanzawc_Component) != 0 )
               {
                  WebComp_Cargamudanzawc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Adicionalmudanzawc_Component) != 0 )
               {
                  WebComp_Adicionalmudanzawc.componentstart();
               }
            }
         }
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
            /* Using cursor H00FR2 */
            pr_default.execute(0, new Object[] {AV10ParametroMudanzaId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A730ParametroMudanzaId = H00FR2_A730ParametroMudanzaId[0];
               /* Execute user event: Load */
               E16FR2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WBFR0( ) ;
         }
      }

      protected void send_integrity_lvl_hashesFR2( )
      {
         GxWebStd.gx_hidden_field( context, "vRECORDDESCRIPTION", AV16RecordDescription);
         GxWebStd.gx_hidden_field( context, "gxhash_vRECORDDESCRIPTION", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV16RecordDescription, "")), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUPFR0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E14FR2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Ddc_subscriptions_Icontype = cgiGet( "DDC_SUBSCRIPTIONS_Icontype");
            Ddc_subscriptions_Icon = cgiGet( "DDC_SUBSCRIPTIONS_Icon");
            Ddc_subscriptions_Tooltip = cgiGet( "DDC_SUBSCRIPTIONS_Tooltip");
            Ddc_subscriptions_Cls = cgiGet( "DDC_SUBSCRIPTIONS_Cls");
            Ddc_subscriptions_Visible = StringUtil.StrToBool( cgiGet( "DDC_SUBSCRIPTIONS_Visible"));
            Ddc_discussions_Icontype = cgiGet( "DDC_DISCUSSIONS_Icontype");
            Ddc_discussions_Icon = cgiGet( "DDC_DISCUSSIONS_Icon");
            Ddc_discussions_Tooltip = cgiGet( "DDC_DISCUSSIONS_Tooltip");
            Ddc_discussions_Cls = cgiGet( "DDC_DISCUSSIONS_Cls");
            Panel_general_Width = cgiGet( "PANEL_GENERAL_Width");
            Panel_general_Autowidth = StringUtil.StrToBool( cgiGet( "PANEL_GENERAL_Autowidth"));
            Panel_general_Autoheight = StringUtil.StrToBool( cgiGet( "PANEL_GENERAL_Autoheight"));
            Panel_general_Cls = cgiGet( "PANEL_GENERAL_Cls");
            Panel_general_Title = cgiGet( "PANEL_GENERAL_Title");
            Panel_general_Collapsible = StringUtil.StrToBool( cgiGet( "PANEL_GENERAL_Collapsible"));
            Panel_general_Collapsed = StringUtil.StrToBool( cgiGet( "PANEL_GENERAL_Collapsed"));
            Panel_general_Showcollapseicon = StringUtil.StrToBool( cgiGet( "PANEL_GENERAL_Showcollapseicon"));
            Panel_general_Iconposition = cgiGet( "PANEL_GENERAL_Iconposition");
            Panel_general_Autoscroll = StringUtil.StrToBool( cgiGet( "PANEL_GENERAL_Autoscroll"));
            Tabs_Activepagecontrolname = cgiGet( "TABS_Activepagecontrolname");
            Tabs_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "TABS_Pagecount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Tabs_Class = cgiGet( "TABS_Class");
            Tabs_Historymanagement = StringUtil.StrToBool( cgiGet( "TABS_Historymanagement"));
            Tabs_Activepagecontrolname = cgiGet( "TABS_Activepagecontrolname");
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E14FR2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E14FR2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         lblWorkwithlink_Link = formatLink("parametromudanzaww.aspx") ;
         AssignProp("", false, lblWorkwithlink_Internalname, "Link", lblWorkwithlink_Link, true);
         AV18GXLvl9 = 0;
         /* Using cursor H00FR3 */
         pr_default.execute(1, new Object[] {AV10ParametroMudanzaId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A730ParametroMudanzaId = H00FR3_A730ParametroMudanzaId[0];
            A731ParametroMudanzaTipo = H00FR3_A731ParametroMudanzaTipo[0];
            AV18GXLvl9 = 1;
            Form.Caption = A731ParametroMudanzaTipo;
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            AV9Exists = true;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         if ( AV18GXLvl9 == 0 )
         {
            Form.Caption = context.GetMessage( "WWP_RecordNotFound", "");
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            AV9Exists = false;
         }
         if ( AV9Exists )
         {
            AV12SelectedTabCode = AV8TabCode;
            AssignAttri("", false, "AV12SelectedTabCode", AV12SelectedTabCode);
            Tabs_Activepagecontrolname = AV12SelectedTabCode;
            ucTabs.SendProperty(context, "", false, Tabs_Internalname, "ActivePageControlName", Tabs_Activepagecontrolname);
            /* Execute user subroutine: 'LOADFIXEDTABS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'LOADTABS' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV16RecordDescription = Form.Caption;
         AssignAttri("", false, "AV16RecordDescription", AV16RecordDescription);
         GxWebStd.gx_hidden_field( context, "gxhash_vRECORDDESCRIPTION", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV16RecordDescription, "")), context));
         if ( StringUtil.StrCmp(AV17Session.Get("DiscussionThreadIdToOpen"), "") != 0 )
         {
            this.executeUsercontrolMethod("", false, "DDC_DISCUSSIONSContainer", "Open", "", new Object[] {});
         }
      }

      protected void E15FR2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.wwpbaseobjects.discussions.wwp_hasdiscussionmessages(context).executeUdp(  "ParametroMudanza",  StringUtil.Trim( StringUtil.Str( (decimal)(A730ParametroMudanzaId), 4, 0))) )
         {
            Ddc_discussions_Icon = context.GetMessage( "far fa-comment", "");
            ucDdc_discussions.SendProperty(context, "", false, Ddc_discussions_Internalname, "Icon", Ddc_discussions_Icon);
         }
         GXt_boolean1 = AV15TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "SubscriptionsPanel", out  GXt_boolean1) ;
         AV15TempBoolean = GXt_boolean1;
         if ( AV15TempBoolean && ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "ParametroMudanza",  2) ) )
         {
            Ddc_subscriptions_Visible = true;
            ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "Visible", StringUtil.BoolToStr( Ddc_subscriptions_Visible));
         }
         else
         {
            Ddc_subscriptions_Visible = false;
            ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "Visible", StringUtil.BoolToStr( Ddc_subscriptions_Visible));
         }
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E16FR2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void E11FR2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0082",(string)"",(string)"ParametroMudanza",(short)2,StringUtil.Trim( StringUtil.Str( (decimal)(A730ParametroMudanzaId), 4, 0)),(string)AV16RecordDescription});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)""+""+"",(string)"",(string)""+""+"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0082"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E12FR2( )
      {
         /* Ddc_discussions_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.Discussions.WWP_DiscussionsWC")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.discussions.wwp_discussionswc", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.Discussions.WWP_DiscussionsWC";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.Discussions.WWP_DiscussionsWC";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "parametromudanzaview.aspx"+UrlEncode(StringUtil.LTrimStr(A730ParametroMudanzaId,4,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0082",(string)"",(string)"ParametroMudanza",StringUtil.Trim( StringUtil.Str( (decimal)(A730ParametroMudanzaId), 4, 0)),(string)AV16RecordDescription,formatLink("parametromudanzaview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)""+""+"",(string)"",(string)""+""+"",(string)"",(string)""+"",(string)"",(string)""+""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0082"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E13FR2( )
      {
         /* Tabs_Tabchanged Routine */
         returnInSub = false;
         AV12SelectedTabCode = Tabs_Activepagecontrolname;
         AssignAttri("", false, "AV12SelectedTabCode", AV12SelectedTabCode);
         AV11LoadAllTabs = false;
         AssignAttri("", false, "AV11LoadAllTabs", AV11LoadAllTabs);
         /* Execute user subroutine: 'LOADTABS' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'LOADFIXEDTABS' Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Webcomponent_general = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Webcomponent_general_Component), StringUtil.Lower( "ParametroMudanzaGeneral")) != 0 )
         {
            WebComp_Webcomponent_general = getWebComponent(GetType(), "GeneXus.Programs", "parametromudanzageneral", new Object[] {context} );
            WebComp_Webcomponent_general.ComponentInit();
            WebComp_Webcomponent_general.Name = "ParametroMudanzaGeneral";
            WebComp_Webcomponent_general_Component = "ParametroMudanzaGeneral";
         }
         if ( StringUtil.Len( WebComp_Webcomponent_general_Component) != 0 )
         {
            WebComp_Webcomponent_general.setjustcreated();
            WebComp_Webcomponent_general.componentprepare(new Object[] {(string)"W0023",(string)"",(short)AV10ParametroMudanzaId});
            WebComp_Webcomponent_general.componentbind(new Object[] {(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Webcomponent_general )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0023"+"");
            WebComp_Webcomponent_general.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
      }

      protected void S122( )
      {
         /* 'LOADTABS' Routine */
         returnInSub = false;
         /* Using cursor H00FR4 */
         pr_default.execute(2, new Object[] {AV10ParametroMudanzaId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A730ParametroMudanzaId = H00FR4_A730ParametroMudanzaId[0];
            GXt_boolean1 = AV15TempBoolean;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMudanza", out  GXt_boolean1) ;
            AV15TempBoolean = GXt_boolean1;
            if ( AV15TempBoolean )
            {
               if ( AV11LoadAllTabs || ( StringUtil.StrCmp(AV12SelectedTabCode, "") == 0 ) || ( StringUtil.StrCmp(AV12SelectedTabCode, "Mudanza") == 0 ) )
               {
                  /* Object Property */
                  if ( true )
                  {
                     bDynCreated_Mudanzawc = true;
                  }
                  if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Mudanzawc_Component), StringUtil.Lower( "ParametroMudanzaMudanzaWC")) != 0 )
                  {
                     WebComp_Mudanzawc = getWebComponent(GetType(), "GeneXus.Programs", "parametromudanzamudanzawc", new Object[] {context} );
                     WebComp_Mudanzawc.ComponentInit();
                     WebComp_Mudanzawc.Name = "ParametroMudanzaMudanzaWC";
                     WebComp_Mudanzawc_Component = "ParametroMudanzaMudanzaWC";
                  }
                  if ( StringUtil.Len( WebComp_Mudanzawc_Component) != 0 )
                  {
                     WebComp_Mudanzawc.setjustcreated();
                     WebComp_Mudanzawc.componentprepare(new Object[] {(string)"W0037",(string)"",(short)AV10ParametroMudanzaId});
                     WebComp_Mudanzawc.componentbind(new Object[] {(string)""});
                  }
                  if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Mudanzawc )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0037"+"");
                     WebComp_Mudanzawc.componentdraw();
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
            }
            else
            {
               this.executeUsercontrolMethod("", false, "TABSContainer", "HideTab", "", new Object[] {(short)1});
            }
            GXt_boolean1 = AV15TempBoolean;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMudanza", out  GXt_boolean1) ;
            AV15TempBoolean = GXt_boolean1;
            if ( AV15TempBoolean )
            {
               if ( AV11LoadAllTabs || ( StringUtil.StrCmp(AV12SelectedTabCode, "Mudanza1") == 0 ) )
               {
                  /* Object Property */
                  if ( true )
                  {
                     bDynCreated_Mudanza1wc = true;
                  }
                  if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Mudanza1wc_Component), StringUtil.Lower( "ParametroMudanzaMudanza1WC")) != 0 )
                  {
                     WebComp_Mudanza1wc = getWebComponent(GetType(), "GeneXus.Programs", "parametromudanzamudanza1wc", new Object[] {context} );
                     WebComp_Mudanza1wc.ComponentInit();
                     WebComp_Mudanza1wc.Name = "ParametroMudanzaMudanza1WC";
                     WebComp_Mudanza1wc_Component = "ParametroMudanzaMudanza1WC";
                  }
                  if ( StringUtil.Len( WebComp_Mudanza1wc_Component) != 0 )
                  {
                     WebComp_Mudanza1wc.setjustcreated();
                     WebComp_Mudanza1wc.componentprepare(new Object[] {(string)"W0045",(string)"",(short)AV10ParametroMudanzaId});
                     WebComp_Mudanza1wc.componentbind(new Object[] {(string)""});
                  }
                  if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Mudanza1wc )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0045"+"");
                     WebComp_Mudanza1wc.componentdraw();
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
            }
            else
            {
               this.executeUsercontrolMethod("", false, "TABSContainer", "HideTab", "", new Object[] {(short)2});
            }
            GXt_boolean1 = AV15TempBoolean;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMudanza", out  GXt_boolean1) ;
            AV15TempBoolean = GXt_boolean1;
            if ( AV15TempBoolean )
            {
               if ( AV11LoadAllTabs || ( StringUtil.StrCmp(AV12SelectedTabCode, "Mudanza2") == 0 ) )
               {
                  /* Object Property */
                  if ( true )
                  {
                     bDynCreated_Mudanza2wc = true;
                  }
                  if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Mudanza2wc_Component), StringUtil.Lower( "ParametroMudanzaMudanza2WC")) != 0 )
                  {
                     WebComp_Mudanza2wc = getWebComponent(GetType(), "GeneXus.Programs", "parametromudanzamudanza2wc", new Object[] {context} );
                     WebComp_Mudanza2wc.ComponentInit();
                     WebComp_Mudanza2wc.Name = "ParametroMudanzaMudanza2WC";
                     WebComp_Mudanza2wc_Component = "ParametroMudanzaMudanza2WC";
                  }
                  if ( StringUtil.Len( WebComp_Mudanza2wc_Component) != 0 )
                  {
                     WebComp_Mudanza2wc.setjustcreated();
                     WebComp_Mudanza2wc.componentprepare(new Object[] {(string)"W0053",(string)"",(short)AV10ParametroMudanzaId});
                     WebComp_Mudanza2wc.componentbind(new Object[] {(string)""});
                  }
                  if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Mudanza2wc )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0053"+"");
                     WebComp_Mudanza2wc.componentdraw();
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
            }
            else
            {
               this.executeUsercontrolMethod("", false, "TABSContainer", "HideTab", "", new Object[] {(short)3});
            }
            GXt_boolean1 = AV15TempBoolean;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMudanza", out  GXt_boolean1) ;
            AV15TempBoolean = GXt_boolean1;
            if ( AV15TempBoolean )
            {
               if ( AV11LoadAllTabs || ( StringUtil.StrCmp(AV12SelectedTabCode, "Mudanza3") == 0 ) )
               {
                  /* Object Property */
                  if ( true )
                  {
                     bDynCreated_Mudanza3wc = true;
                  }
                  if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Mudanza3wc_Component), StringUtil.Lower( "ParametroMudanzaMudanza3WC")) != 0 )
                  {
                     WebComp_Mudanza3wc = getWebComponent(GetType(), "GeneXus.Programs", "parametromudanzamudanza3wc", new Object[] {context} );
                     WebComp_Mudanza3wc.ComponentInit();
                     WebComp_Mudanza3wc.Name = "ParametroMudanzaMudanza3WC";
                     WebComp_Mudanza3wc_Component = "ParametroMudanzaMudanza3WC";
                  }
                  if ( StringUtil.Len( WebComp_Mudanza3wc_Component) != 0 )
                  {
                     WebComp_Mudanza3wc.setjustcreated();
                     WebComp_Mudanza3wc.componentprepare(new Object[] {(string)"W0061",(string)"",(short)AV10ParametroMudanzaId});
                     WebComp_Mudanza3wc.componentbind(new Object[] {(string)""});
                  }
                  if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Mudanza3wc )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0061"+"");
                     WebComp_Mudanza3wc.componentdraw();
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
            }
            else
            {
               this.executeUsercontrolMethod("", false, "TABSContainer", "HideTab", "", new Object[] {(short)4});
            }
            GXt_boolean1 = AV15TempBoolean;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMudanza", out  GXt_boolean1) ;
            AV15TempBoolean = GXt_boolean1;
            if ( AV15TempBoolean )
            {
               if ( AV11LoadAllTabs || ( StringUtil.StrCmp(AV12SelectedTabCode, "CargaMudanza") == 0 ) )
               {
                  /* Object Property */
                  if ( true )
                  {
                     bDynCreated_Cargamudanzawc = true;
                  }
                  if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Cargamudanzawc_Component), StringUtil.Lower( "ParametroMudanzaCargaMudanzaWC")) != 0 )
                  {
                     WebComp_Cargamudanzawc = getWebComponent(GetType(), "GeneXus.Programs", "parametromudanzacargamudanzawc", new Object[] {context} );
                     WebComp_Cargamudanzawc.ComponentInit();
                     WebComp_Cargamudanzawc.Name = "ParametroMudanzaCargaMudanzaWC";
                     WebComp_Cargamudanzawc_Component = "ParametroMudanzaCargaMudanzaWC";
                  }
                  if ( StringUtil.Len( WebComp_Cargamudanzawc_Component) != 0 )
                  {
                     WebComp_Cargamudanzawc.setjustcreated();
                     WebComp_Cargamudanzawc.componentprepare(new Object[] {(string)"W0069",(string)"",(short)AV10ParametroMudanzaId});
                     WebComp_Cargamudanzawc.componentbind(new Object[] {(string)""});
                  }
                  if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Cargamudanzawc )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0069"+"");
                     WebComp_Cargamudanzawc.componentdraw();
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
            }
            else
            {
               this.executeUsercontrolMethod("", false, "TABSContainer", "HideTab", "", new Object[] {(short)5});
            }
            GXt_boolean1 = AV15TempBoolean;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMudanza", out  GXt_boolean1) ;
            AV15TempBoolean = GXt_boolean1;
            if ( AV15TempBoolean )
            {
               if ( AV11LoadAllTabs || ( StringUtil.StrCmp(AV12SelectedTabCode, "AdicionalMudanza") == 0 ) )
               {
                  /* Object Property */
                  if ( true )
                  {
                     bDynCreated_Adicionalmudanzawc = true;
                  }
                  if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Adicionalmudanzawc_Component), StringUtil.Lower( "ParametroMudanzaAdicionalMudanzaWC")) != 0 )
                  {
                     WebComp_Adicionalmudanzawc = getWebComponent(GetType(), "GeneXus.Programs", "parametromudanzaadicionalmudanzawc", new Object[] {context} );
                     WebComp_Adicionalmudanzawc.ComponentInit();
                     WebComp_Adicionalmudanzawc.Name = "ParametroMudanzaAdicionalMudanzaWC";
                     WebComp_Adicionalmudanzawc_Component = "ParametroMudanzaAdicionalMudanzaWC";
                  }
                  if ( StringUtil.Len( WebComp_Adicionalmudanzawc_Component) != 0 )
                  {
                     WebComp_Adicionalmudanzawc.setjustcreated();
                     WebComp_Adicionalmudanzawc.componentprepare(new Object[] {(string)"W0077",(string)"",(short)AV10ParametroMudanzaId});
                     WebComp_Adicionalmudanzawc.componentbind(new Object[] {(string)""});
                  }
                  if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Adicionalmudanzawc )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0077"+"");
                     WebComp_Adicionalmudanzawc.componentdraw();
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
            }
            else
            {
               this.executeUsercontrolMethod("", false, "TABSContainer", "HideTab", "", new Object[] {(short)6});
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV10ParametroMudanzaId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV10ParametroMudanzaId", StringUtil.LTrimStr( (decimal)(AV10ParametroMudanzaId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vPARAMETROMUDANZAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10ParametroMudanzaId), "ZZZ9"), context));
         AV8TabCode = (string)getParm(obj,1);
         AssignAttri("", false, "AV8TabCode", AV8TabCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
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
         PAFR2( ) ;
         WSFR2( ) ;
         WEFR2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Webcomponent_general == null ) )
         {
            if ( StringUtil.Len( WebComp_Webcomponent_general_Component) != 0 )
            {
               WebComp_Webcomponent_general.componentthemes();
            }
         }
         if ( ! ( WebComp_Mudanzawc == null ) )
         {
            if ( StringUtil.Len( WebComp_Mudanzawc_Component) != 0 )
            {
               WebComp_Mudanzawc.componentthemes();
            }
         }
         if ( ! ( WebComp_Mudanza1wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Mudanza1wc_Component) != 0 )
            {
               WebComp_Mudanza1wc.componentthemes();
            }
         }
         if ( ! ( WebComp_Mudanza2wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Mudanza2wc_Component) != 0 )
            {
               WebComp_Mudanza2wc.componentthemes();
            }
         }
         if ( ! ( WebComp_Mudanza3wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Mudanza3wc_Component) != 0 )
            {
               WebComp_Mudanza3wc.componentthemes();
            }
         }
         if ( ! ( WebComp_Cargamudanzawc == null ) )
         {
            if ( StringUtil.Len( WebComp_Cargamudanzawc_Component) != 0 )
            {
               WebComp_Cargamudanzawc.componentthemes();
            }
         }
         if ( ! ( WebComp_Adicionalmudanzawc == null ) )
         {
            if ( StringUtil.Len( WebComp_Adicionalmudanzawc_Component) != 0 )
            {
               WebComp_Adicionalmudanzawc.componentthemes();
            }
         }
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021232427", true, true, false);
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
         context.AddJavascriptSource("parametromudanzaview.js", "?202673021232427", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblWorkwithlink_Internalname = "WORKWITHLINK";
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
         Ddc_discussions_Internalname = "DDC_DISCUSSIONS";
         divTableviewrightitems_Internalname = "TABLEVIEWRIGHTITEMS";
         divTablepanel_general_Internalname = "TABLEPANEL_GENERAL";
         Panel_general_Internalname = "PANEL_GENERAL";
         divParametromudanzageneral_cell_Internalname = "PARAMETROMUDANZAGENERAL_CELL";
         lblMudanza_title_Internalname = "MUDANZA_TITLE";
         divUnnamedtablemudanza_Internalname = "UNNAMEDTABLEMUDANZA";
         lblMudanza1_title_Internalname = "MUDANZA1_TITLE";
         divUnnamedtablemudanza1_Internalname = "UNNAMEDTABLEMUDANZA1";
         lblMudanza2_title_Internalname = "MUDANZA2_TITLE";
         divUnnamedtablemudanza2_Internalname = "UNNAMEDTABLEMUDANZA2";
         lblMudanza3_title_Internalname = "MUDANZA3_TITLE";
         divUnnamedtablemudanza3_Internalname = "UNNAMEDTABLEMUDANZA3";
         lblCargamudanza_title_Internalname = "CARGAMUDANZA_TITLE";
         divUnnamedtablecargamudanza_Internalname = "UNNAMEDTABLECARGAMUDANZA";
         lblAdicionalmudanza_title_Internalname = "ADICIONALMUDANZA_TITLE";
         divUnnamedtableadicionalmudanza_Internalname = "UNNAMEDTABLEADICIONALMUDANZA";
         Tabs_Internalname = "TABS";
         divUnnamedtableviewcontainer_Internalname = "UNNAMEDTABLEVIEWCONTAINER";
         divTablemain_Internalname = "TABLEMAIN";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Ddc_discussions_Caption = "";
         Ddc_subscriptions_Caption = "";
         lblWorkwithlink_Link = "";
         Tabs_Historymanagement = Convert.ToBoolean( -1);
         Tabs_Class = "ViewTab Tab";
         Tabs_Pagecount = 6;
         Panel_general_Autoscroll = Convert.ToBoolean( 0);
         Panel_general_Iconposition = "Right";
         Panel_general_Showcollapseicon = Convert.ToBoolean( 0);
         Panel_general_Collapsed = Convert.ToBoolean( 0);
         Panel_general_Collapsible = Convert.ToBoolean( -1);
         Panel_general_Title = context.GetMessage( "WWP_TemplateDataPanelTitle", "");
         Panel_general_Cls = "PanelGrayBackgroundTitle";
         Panel_general_Autoheight = Convert.ToBoolean( -1);
         Panel_general_Autowidth = Convert.ToBoolean( 0);
         Panel_general_Width = "100%";
         Ddc_discussions_Cls = "DropDownComponent";
         Ddc_discussions_Tooltip = "WWP_Discussions_Tooltip";
         Ddc_discussions_Icon = "far fa-comment-dots";
         Ddc_discussions_Icontype = "FontIcon";
         Ddc_subscriptions_Visible = Convert.ToBoolean( -1);
         Ddc_subscriptions_Cls = "DropDownComponent";
         Ddc_subscriptions_Tooltip = "WWP_Subscriptions_Tooltip";
         Ddc_subscriptions_Icon = "fas fa-rss";
         Ddc_subscriptions_Icontype = "FontIcon";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Parametro Mudanza View", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A730ParametroMudanzaId',fld:'PARAMETROMUDANZAID',pic:'ZZZ9',type:'int'},{av:'AV16RecordDescription',fld:'vRECORDDESCRIPTION',pic:'',hsh:true,type:'svchar'},{av:'AV10ParametroMudanzaId',fld:'vPARAMETROMUDANZAID',pic:'ZZZ9',hsh:true,type:'int'},{av:'AV8TabCode',fld:'vTABCODE',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'Ddc_discussions_Icon',ctrl:'DDC_DISCUSSIONS',prop:'Icon'},{av:'Ddc_subscriptions_Visible',ctrl:'DDC_SUBSCRIPTIONS',prop:'Visible'}]}");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","{handler:'E11FR2',iparms:[{av:'A730ParametroMudanzaId',fld:'PARAMETROMUDANZAID',pic:'ZZZ9',type:'int'},{av:'AV16RecordDescription',fld:'vRECORDDESCRIPTION',pic:'',hsh:true,type:'svchar'}]");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("DDC_DISCUSSIONS.ONLOADCOMPONENT","{handler:'E12FR2',iparms:[{av:'AV16RecordDescription',fld:'vRECORDDESCRIPTION',pic:'',hsh:true,type:'svchar'},{av:'A730ParametroMudanzaId',fld:'PARAMETROMUDANZAID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("DDC_DISCUSSIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("TABS.TABCHANGED","{handler:'E13FR2',iparms:[{av:'Tabs_Activepagecontrolname',ctrl:'TABS',prop:'ActivePageControlName'},{av:'A730ParametroMudanzaId',fld:'PARAMETROMUDANZAID',pic:'ZZZ9',type:'int'},{av:'AV10ParametroMudanzaId',fld:'vPARAMETROMUDANZAID',pic:'ZZZ9',hsh:true,type:'int'},{av:'AV11LoadAllTabs',fld:'vLOADALLTABS',pic:'',type:'boolean'},{av:'AV12SelectedTabCode',fld:'vSELECTEDTABCODE',pic:'',type:'char'}]");
         setEventMetadata("TABS.TABCHANGED",",oparms:[{av:'AV12SelectedTabCode',fld:'vSELECTEDTABCODE',pic:'',type:'char'},{av:'AV11LoadAllTabs',fld:'vLOADALLTABS',pic:'',type:'boolean'},{ctrl:'MUDANZAWC'},{ctrl:'MUDANZA1WC'},{ctrl:'MUDANZA2WC'},{ctrl:'MUDANZA3WC'},{ctrl:'CARGAMUDANZAWC'},{ctrl:'ADICIONALMUDANZAWC'}]}");
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
         wcpOAV8TabCode = "";
         Tabs_Activepagecontrolname = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV16RecordDescription = "";
         AV12SelectedTabCode = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblWorkwithlink_Jsonclick = "";
         ucDdc_subscriptions = new GXUserControl();
         ucDdc_discussions = new GXUserControl();
         ucPanel_general = new GXUserControl();
         WebComp_Webcomponent_general_Component = "";
         OldWebcomponent_general = "";
         ucTabs = new GXUserControl();
         lblMudanza_title_Jsonclick = "";
         WebComp_Mudanzawc_Component = "";
         OldMudanzawc = "";
         lblMudanza1_title_Jsonclick = "";
         WebComp_Mudanza1wc_Component = "";
         OldMudanza1wc = "";
         lblMudanza2_title_Jsonclick = "";
         WebComp_Mudanza2wc_Component = "";
         OldMudanza2wc = "";
         lblMudanza3_title_Jsonclick = "";
         WebComp_Mudanza3wc_Component = "";
         OldMudanza3wc = "";
         lblCargamudanza_title_Jsonclick = "";
         WebComp_Cargamudanzawc_Component = "";
         OldCargamudanzawc = "";
         lblAdicionalmudanza_title_Jsonclick = "";
         WebComp_Adicionalmudanzawc_Component = "";
         OldAdicionalmudanzawc = "";
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H00FR2_A730ParametroMudanzaId = new short[1] ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         H00FR3_A730ParametroMudanzaId = new short[1] ;
         H00FR3_A731ParametroMudanzaTipo = new string[] {""} ;
         A731ParametroMudanzaTipo = "";
         AV17Session = context.GetSession();
         H00FR4_A730ParametroMudanzaId = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.parametromudanzaview__default(),
            new Object[][] {
                new Object[] {
               H00FR2_A730ParametroMudanzaId
               }
               , new Object[] {
               H00FR3_A730ParametroMudanzaId, H00FR3_A731ParametroMudanzaTipo
               }
               , new Object[] {
               H00FR4_A730ParametroMudanzaId
               }
            }
         );
         WebComp_Webcomponent_general = new GeneXus.Http.GXNullWebComponent();
         WebComp_Mudanzawc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Mudanza1wc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Mudanza2wc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Mudanza3wc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Cargamudanzawc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Adicionalmudanzawc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short AV10ParametroMudanzaId ;
      private short wcpOAV10ParametroMudanzaId ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short A730ParametroMudanzaId ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short AV18GXLvl9 ;
      private short nGXWrapped ;
      private int Tabs_Pagecount ;
      private int idxLst ;
      private string AV8TabCode ;
      private string wcpOAV8TabCode ;
      private string Tabs_Activepagecontrolname ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV12SelectedTabCode ;
      private string Ddc_subscriptions_Icontype ;
      private string Ddc_subscriptions_Icon ;
      private string Ddc_subscriptions_Tooltip ;
      private string Ddc_subscriptions_Cls ;
      private string Ddc_discussions_Icontype ;
      private string Ddc_discussions_Icon ;
      private string Ddc_discussions_Tooltip ;
      private string Ddc_discussions_Cls ;
      private string Panel_general_Width ;
      private string Panel_general_Cls ;
      private string Panel_general_Title ;
      private string Panel_general_Iconposition ;
      private string Tabs_Class ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableviewrightitems_Internalname ;
      private string lblWorkwithlink_Internalname ;
      private string lblWorkwithlink_Link ;
      private string lblWorkwithlink_Jsonclick ;
      private string Ddc_subscriptions_Caption ;
      private string Ddc_subscriptions_Internalname ;
      private string Ddc_discussions_Caption ;
      private string Ddc_discussions_Internalname ;
      private string divParametromudanzageneral_cell_Internalname ;
      private string Panel_general_Internalname ;
      private string divTablepanel_general_Internalname ;
      private string WebComp_Webcomponent_general_Component ;
      private string OldWebcomponent_general ;
      private string divUnnamedtableviewcontainer_Internalname ;
      private string Tabs_Internalname ;
      private string lblMudanza_title_Internalname ;
      private string lblMudanza_title_Jsonclick ;
      private string divUnnamedtablemudanza_Internalname ;
      private string WebComp_Mudanzawc_Component ;
      private string OldMudanzawc ;
      private string lblMudanza1_title_Internalname ;
      private string lblMudanza1_title_Jsonclick ;
      private string divUnnamedtablemudanza1_Internalname ;
      private string WebComp_Mudanza1wc_Component ;
      private string OldMudanza1wc ;
      private string lblMudanza2_title_Internalname ;
      private string lblMudanza2_title_Jsonclick ;
      private string divUnnamedtablemudanza2_Internalname ;
      private string WebComp_Mudanza2wc_Component ;
      private string OldMudanza2wc ;
      private string lblMudanza3_title_Internalname ;
      private string lblMudanza3_title_Jsonclick ;
      private string divUnnamedtablemudanza3_Internalname ;
      private string WebComp_Mudanza3wc_Component ;
      private string OldMudanza3wc ;
      private string lblCargamudanza_title_Internalname ;
      private string lblCargamudanza_title_Jsonclick ;
      private string divUnnamedtablecargamudanza_Internalname ;
      private string WebComp_Cargamudanzawc_Component ;
      private string OldCargamudanzawc ;
      private string lblAdicionalmudanza_title_Internalname ;
      private string lblAdicionalmudanza_title_Jsonclick ;
      private string divUnnamedtableadicionalmudanza_Internalname ;
      private string WebComp_Adicionalmudanzawc_Component ;
      private string OldAdicionalmudanzawc ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV11LoadAllTabs ;
      private bool Ddc_subscriptions_Visible ;
      private bool Panel_general_Autowidth ;
      private bool Panel_general_Autoheight ;
      private bool Panel_general_Collapsible ;
      private bool Panel_general_Collapsed ;
      private bool Panel_general_Showcollapseicon ;
      private bool Panel_general_Autoscroll ;
      private bool Tabs_Historymanagement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV9Exists ;
      private bool AV15TempBoolean ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool bDynCreated_Webcomponent_general ;
      private bool bDynCreated_Mudanzawc ;
      private bool bDynCreated_Mudanza1wc ;
      private bool bDynCreated_Mudanza2wc ;
      private bool bDynCreated_Mudanza3wc ;
      private bool bDynCreated_Cargamudanzawc ;
      private bool GXt_boolean1 ;
      private bool bDynCreated_Adicionalmudanzawc ;
      private string AV16RecordDescription ;
      private string A731ParametroMudanzaTipo ;
      private IGxSession AV17Session ;
      private GXWebComponent WebComp_Webcomponent_general ;
      private GXWebComponent WebComp_Mudanzawc ;
      private GXWebComponent WebComp_Mudanza1wc ;
      private GXWebComponent WebComp_Mudanza2wc ;
      private GXWebComponent WebComp_Mudanza3wc ;
      private GXWebComponent WebComp_Cargamudanzawc ;
      private GXWebComponent WebComp_Adicionalmudanzawc ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXUserControl ucDdc_subscriptions ;
      private GXUserControl ucDdc_discussions ;
      private GXUserControl ucPanel_general ;
      private GXUserControl ucTabs ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H00FR2_A730ParametroMudanzaId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private short[] H00FR3_A730ParametroMudanzaId ;
      private string[] H00FR3_A731ParametroMudanzaTipo ;
      private short[] H00FR4_A730ParametroMudanzaId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class parametromudanzaview__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmH00FR2;
          prmH00FR2 = new Object[] {
          new ParDef("@AV10ParametroMudanzaId",GXType.Int16,4,0)
          };
          Object[] prmH00FR3;
          prmH00FR3 = new Object[] {
          new ParDef("@AV10ParametroMudanzaId",GXType.Int16,4,0)
          };
          Object[] prmH00FR4;
          prmH00FR4 = new Object[] {
          new ParDef("@AV10ParametroMudanzaId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00FR2", "SELECT [ParametroMudanzaId] FROM [ParametroMudanza] WHERE [ParametroMudanzaId] = @AV10ParametroMudanzaId ORDER BY [ParametroMudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00FR2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H00FR3", "SELECT [ParametroMudanzaId], [ParametroMudanzaTipo] FROM [ParametroMudanza] WHERE [ParametroMudanzaId] = @AV10ParametroMudanzaId ORDER BY [ParametroMudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00FR3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H00FR4", "SELECT [ParametroMudanzaId] FROM [ParametroMudanza] WHERE [ParametroMudanzaId] = @AV10ParametroMudanzaId ORDER BY [ParametroMudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00FR4,1, GxCacheFrequency.OFF ,true,true )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
