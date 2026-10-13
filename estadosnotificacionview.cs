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
   public class estadosnotificacionview : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public estadosnotificacionview( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public estadosnotificacionview( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_EstadosTipo ,
                           int aP1_EstadosGenericosId ,
                           string aP2_TabCode )
      {
         this.AV10EstadosTipo = aP0_EstadosTipo;
         this.AV11EstadosGenericosId = aP1_EstadosGenericosId;
         this.AV8TabCode = aP2_TabCode;
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
            gxfirstwebparm = GetFirstPar( "EstadosTipo");
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
               gxfirstwebparm = GetFirstPar( "EstadosTipo");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "EstadosTipo");
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
         PACJ2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTCJ2( ) ;
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
         GXEncryptionTmp = "estadosnotificacionview.aspx"+UrlEncode(StringUtil.RTrim(AV10EstadosTipo)) + "," + UrlEncode(StringUtil.LTrimStr(AV11EstadosGenericosId,5,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TabCode));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("estadosnotificacionview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vRECORDDESCRIPTION", AV17RecordDescription);
         GxWebStd.gx_hidden_field( context, "gxhash_vRECORDDESCRIPTION", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17RecordDescription, "")), context));
         GxWebStd.gx_hidden_field( context, "vESTADOSTIPO", StringUtil.RTrim( AV10EstadosTipo));
         GxWebStd.gx_hidden_field( context, "gxhash_vESTADOSTIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10EstadosTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "vESTADOSGENERICOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vESTADOSGENERICOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11EstadosGenericosId), "ZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTABCODE", StringUtil.RTrim( AV8TabCode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "ESTADOSTIPO", StringUtil.RTrim( A107EstadosTipo));
         GxWebStd.gx_hidden_field( context, "ESTADOSGENERICOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vRECORDDESCRIPTION", AV17RecordDescription);
         GxWebStd.gx_hidden_field( context, "gxhash_vRECORDDESCRIPTION", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17RecordDescription, "")), context));
         GxWebStd.gx_hidden_field( context, "vESTADOSTIPO", StringUtil.RTrim( AV10EstadosTipo));
         GxWebStd.gx_hidden_field( context, "gxhash_vESTADOSTIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10EstadosTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "vESTADOSGENERICOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vESTADOSGENERICOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11EstadosGenericosId), "ZZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vLOADALLTABS", AV12LoadAllTabs);
         GxWebStd.gx_hidden_field( context, "vSELECTEDTABCODE", StringUtil.RTrim( AV13SelectedTabCode));
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
         if ( ! ( WebComp_Estadoswc == null ) )
         {
            WebComp_Estadoswc.componentjscripts();
         }
         if ( ! ( WebComp_Listainventariowc == null ) )
         {
            WebComp_Listainventariowc.componentjscripts();
         }
         if ( ! ( WebComp_Profesionaleswc == null ) )
         {
            WebComp_Profesionaleswc.componentjscripts();
         }
         if ( ! ( WebComp_Profesionalrubroswc == null ) )
         {
            WebComp_Profesionalrubroswc.componentjscripts();
         }
         if ( ! ( WebComp_Profesionaleszonaswc == null ) )
         {
            WebComp_Profesionaleszonaswc.componentjscripts();
         }
         if ( ! ( WebComp_Profesionalesdatoswc == null ) )
         {
            WebComp_Profesionalesdatoswc.componentjscripts();
         }
         if ( ! ( WebComp_Metodopagoswc == null ) )
         {
            WebComp_Metodopagoswc.componentjscripts();
         }
         if ( ! ( WebComp_Rubrosprofesionaleswc == null ) )
         {
            WebComp_Rubrosprofesionaleswc.componentjscripts();
         }
         if ( ! ( WebComp_Rubrosprofesionalrubroswc == null ) )
         {
            WebComp_Rubrosprofesionalrubroswc.componentjscripts();
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
            WECJ2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTCJ2( ) ;
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
         GXEncryptionTmp = "estadosnotificacionview.aspx"+UrlEncode(StringUtil.RTrim(AV10EstadosTipo)) + "," + UrlEncode(StringUtil.LTrimStr(AV11EstadosGenericosId,5,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TabCode));
         return formatLink("estadosnotificacionview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "EstadosNotificacionView" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Estados Notificacion View", "") ;
      }

      protected void WBCJ0( )
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
            GxWebStd.gx_label_ctrl( context, lblWorkwithlink_Internalname, context.GetMessage( "Ir a Estados Notificacion", ""), lblWorkwithlink_Link, "", lblWorkwithlink_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockLink", 0, "", 1, 1, 0, 0, "HLP_EstadosNotificacionView.htm");
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
            GxWebStd.gx_div_start( context, divEstadosnotificaciongeneral_cell_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
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
            GxWebStd.gx_label_ctrl( context, lblEstados_title_Internalname, context.GetMessage( "Estados", ""), "", "", lblEstados_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_EstadosNotificacionView.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Estados") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableestados_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0037"+"", StringUtil.RTrim( WebComp_Estadoswc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0037"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Estadoswc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldEstadoswc), StringUtil.Lower( WebComp_Estadoswc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0037"+"");
                  }
                  WebComp_Estadoswc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldEstadoswc), StringUtil.Lower( WebComp_Estadoswc_Component)) != 0 )
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
            GxWebStd.gx_label_ctrl( context, lblListainventario_title_Internalname, context.GetMessage( "Inventario", ""), "", "", lblListainventario_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_EstadosNotificacionView.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "listaInventario") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablelistainventario_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0045"+"", StringUtil.RTrim( WebComp_Listainventariowc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0045"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Listainventariowc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldListainventariowc), StringUtil.Lower( WebComp_Listainventariowc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0045"+"");
                  }
                  WebComp_Listainventariowc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldListainventariowc), StringUtil.Lower( WebComp_Listainventariowc_Component)) != 0 )
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
            GxWebStd.gx_label_ctrl( context, lblProfesionales_title_Internalname, context.GetMessage( "Profesionales", ""), "", "", lblProfesionales_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_EstadosNotificacionView.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Profesionales") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableprofesionales_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0053"+"", StringUtil.RTrim( WebComp_Profesionaleswc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0053"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Profesionaleswc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldProfesionaleswc), StringUtil.Lower( WebComp_Profesionaleswc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0053"+"");
                  }
                  WebComp_Profesionaleswc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldProfesionaleswc), StringUtil.Lower( WebComp_Profesionaleswc_Component)) != 0 )
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
            GxWebStd.gx_label_ctrl( context, lblProfesionalrubros_title_Internalname, context.GetMessage( "Profesional Rubros", ""), "", "", lblProfesionalrubros_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_EstadosNotificacionView.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "ProfesionalRubros") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel4"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableprofesionalrubros_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0061"+"", StringUtil.RTrim( WebComp_Profesionalrubroswc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0061"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Profesionalrubroswc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldProfesionalrubroswc), StringUtil.Lower( WebComp_Profesionalrubroswc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0061"+"");
                  }
                  WebComp_Profesionalrubroswc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldProfesionalrubroswc), StringUtil.Lower( WebComp_Profesionalrubroswc_Component)) != 0 )
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
            GxWebStd.gx_label_ctrl( context, lblProfesionaleszonas_title_Internalname, context.GetMessage( "Profesionales Zonas", ""), "", "", lblProfesionaleszonas_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_EstadosNotificacionView.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "ProfesionalesZonas") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel5"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableprofesionaleszonas_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0069"+"", StringUtil.RTrim( WebComp_Profesionaleszonaswc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0069"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Profesionaleszonaswc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldProfesionaleszonaswc), StringUtil.Lower( WebComp_Profesionaleszonaswc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0069"+"");
                  }
                  WebComp_Profesionaleszonaswc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldProfesionaleszonaswc), StringUtil.Lower( WebComp_Profesionaleszonaswc_Component)) != 0 )
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
            GxWebStd.gx_label_ctrl( context, lblProfesionalesdatos_title_Internalname, context.GetMessage( "Datos del Profesional", ""), "", "", lblProfesionalesdatos_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_EstadosNotificacionView.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "ProfesionalesDatos") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel6"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableprofesionalesdatos_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0077"+"", StringUtil.RTrim( WebComp_Profesionalesdatoswc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0077"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Profesionalesdatoswc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldProfesionalesdatoswc), StringUtil.Lower( WebComp_Profesionalesdatoswc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0077"+"");
                  }
                  WebComp_Profesionalesdatoswc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldProfesionalesdatoswc), StringUtil.Lower( WebComp_Profesionalesdatoswc_Component)) != 0 )
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
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title7"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMetodopagos_title_Internalname, context.GetMessage( "Metodo Pagos", ""), "", "", lblMetodopagos_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_EstadosNotificacionView.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "MetodoPagos") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel7"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablemetodopagos_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0085"+"", StringUtil.RTrim( WebComp_Metodopagoswc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0085"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Metodopagoswc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldMetodopagoswc), StringUtil.Lower( WebComp_Metodopagoswc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0085"+"");
                  }
                  WebComp_Metodopagoswc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldMetodopagoswc), StringUtil.Lower( WebComp_Metodopagoswc_Component)) != 0 )
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
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title8"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblRubrosprofesionales_title_Internalname, context.GetMessage( "Estados Prof Rub", ""), "", "", lblRubrosprofesionales_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_EstadosNotificacionView.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "RubrosProfesionales") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel8"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablerubrosprofesionales_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0093"+"", StringUtil.RTrim( WebComp_Rubrosprofesionaleswc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0093"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Rubrosprofesionaleswc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldRubrosprofesionaleswc), StringUtil.Lower( WebComp_Rubrosprofesionaleswc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0093"+"");
                  }
                  WebComp_Rubrosprofesionaleswc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldRubrosprofesionaleswc), StringUtil.Lower( WebComp_Rubrosprofesionaleswc_Component)) != 0 )
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
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title9"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblRubrosprofesionalrubros_title_Internalname, context.GetMessage( "Estados Prof Rub", ""), "", "", lblRubrosprofesionalrubros_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_EstadosNotificacionView.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "RubrosProfesionalRubros") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel9"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablerubrosprofesionalrubros_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0101"+"", StringUtil.RTrim( WebComp_Rubrosprofesionalrubroswc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0101"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Rubrosprofesionalrubroswc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldRubrosprofesionalrubroswc), StringUtil.Lower( WebComp_Rubrosprofesionalrubroswc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0101"+"");
                  }
                  WebComp_Rubrosprofesionalrubroswc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldRubrosprofesionalrubroswc), StringUtil.Lower( WebComp_Rubrosprofesionalrubroswc_Component)) != 0 )
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
               GxWebStd.gx_hidden_field( context, "W0106"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0106"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0106"+"");
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

      protected void STARTCJ2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Estados Notificacion View", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPCJ0( ) ;
      }

      protected void WSCJ2( )
      {
         STARTCJ2( ) ;
         EVTCJ2( ) ;
      }

      protected void EVTCJ2( )
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
                              E11CJ2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_DISCUSSIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_discussions.Onloadcomponent */
                              E12CJ2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "TABS.TABCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Tabs.Tabchanged */
                              E13CJ2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E14CJ2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E15CJ2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E16CJ2 ();
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
                           OldEstadoswc = cgiGet( "W0037");
                           if ( ( StringUtil.Len( OldEstadoswc) == 0 ) || ( StringUtil.StrCmp(OldEstadoswc, WebComp_Estadoswc_Component) != 0 ) )
                           {
                              WebComp_Estadoswc = getWebComponent(GetType(), "GeneXus.Programs", OldEstadoswc, new Object[] {context} );
                              WebComp_Estadoswc.ComponentInit();
                              WebComp_Estadoswc.Name = "OldEstadoswc";
                              WebComp_Estadoswc_Component = OldEstadoswc;
                           }
                           if ( StringUtil.Len( WebComp_Estadoswc_Component) != 0 )
                           {
                              WebComp_Estadoswc.componentprocess("W0037", "", sEvt);
                           }
                           WebComp_Estadoswc_Component = OldEstadoswc;
                        }
                        else if ( nCmpId == 45 )
                        {
                           OldListainventariowc = cgiGet( "W0045");
                           if ( ( StringUtil.Len( OldListainventariowc) == 0 ) || ( StringUtil.StrCmp(OldListainventariowc, WebComp_Listainventariowc_Component) != 0 ) )
                           {
                              WebComp_Listainventariowc = getWebComponent(GetType(), "GeneXus.Programs", OldListainventariowc, new Object[] {context} );
                              WebComp_Listainventariowc.ComponentInit();
                              WebComp_Listainventariowc.Name = "OldListainventariowc";
                              WebComp_Listainventariowc_Component = OldListainventariowc;
                           }
                           if ( StringUtil.Len( WebComp_Listainventariowc_Component) != 0 )
                           {
                              WebComp_Listainventariowc.componentprocess("W0045", "", sEvt);
                           }
                           WebComp_Listainventariowc_Component = OldListainventariowc;
                        }
                        else if ( nCmpId == 53 )
                        {
                           OldProfesionaleswc = cgiGet( "W0053");
                           if ( ( StringUtil.Len( OldProfesionaleswc) == 0 ) || ( StringUtil.StrCmp(OldProfesionaleswc, WebComp_Profesionaleswc_Component) != 0 ) )
                           {
                              WebComp_Profesionaleswc = getWebComponent(GetType(), "GeneXus.Programs", OldProfesionaleswc, new Object[] {context} );
                              WebComp_Profesionaleswc.ComponentInit();
                              WebComp_Profesionaleswc.Name = "OldProfesionaleswc";
                              WebComp_Profesionaleswc_Component = OldProfesionaleswc;
                           }
                           if ( StringUtil.Len( WebComp_Profesionaleswc_Component) != 0 )
                           {
                              WebComp_Profesionaleswc.componentprocess("W0053", "", sEvt);
                           }
                           WebComp_Profesionaleswc_Component = OldProfesionaleswc;
                        }
                        else if ( nCmpId == 61 )
                        {
                           OldProfesionalrubroswc = cgiGet( "W0061");
                           if ( ( StringUtil.Len( OldProfesionalrubroswc) == 0 ) || ( StringUtil.StrCmp(OldProfesionalrubroswc, WebComp_Profesionalrubroswc_Component) != 0 ) )
                           {
                              WebComp_Profesionalrubroswc = getWebComponent(GetType(), "GeneXus.Programs", OldProfesionalrubroswc, new Object[] {context} );
                              WebComp_Profesionalrubroswc.ComponentInit();
                              WebComp_Profesionalrubroswc.Name = "OldProfesionalrubroswc";
                              WebComp_Profesionalrubroswc_Component = OldProfesionalrubroswc;
                           }
                           if ( StringUtil.Len( WebComp_Profesionalrubroswc_Component) != 0 )
                           {
                              WebComp_Profesionalrubroswc.componentprocess("W0061", "", sEvt);
                           }
                           WebComp_Profesionalrubroswc_Component = OldProfesionalrubroswc;
                        }
                        else if ( nCmpId == 69 )
                        {
                           OldProfesionaleszonaswc = cgiGet( "W0069");
                           if ( ( StringUtil.Len( OldProfesionaleszonaswc) == 0 ) || ( StringUtil.StrCmp(OldProfesionaleszonaswc, WebComp_Profesionaleszonaswc_Component) != 0 ) )
                           {
                              WebComp_Profesionaleszonaswc = getWebComponent(GetType(), "GeneXus.Programs", OldProfesionaleszonaswc, new Object[] {context} );
                              WebComp_Profesionaleszonaswc.ComponentInit();
                              WebComp_Profesionaleszonaswc.Name = "OldProfesionaleszonaswc";
                              WebComp_Profesionaleszonaswc_Component = OldProfesionaleszonaswc;
                           }
                           if ( StringUtil.Len( WebComp_Profesionaleszonaswc_Component) != 0 )
                           {
                              WebComp_Profesionaleszonaswc.componentprocess("W0069", "", sEvt);
                           }
                           WebComp_Profesionaleszonaswc_Component = OldProfesionaleszonaswc;
                        }
                        else if ( nCmpId == 77 )
                        {
                           OldProfesionalesdatoswc = cgiGet( "W0077");
                           if ( ( StringUtil.Len( OldProfesionalesdatoswc) == 0 ) || ( StringUtil.StrCmp(OldProfesionalesdatoswc, WebComp_Profesionalesdatoswc_Component) != 0 ) )
                           {
                              WebComp_Profesionalesdatoswc = getWebComponent(GetType(), "GeneXus.Programs", OldProfesionalesdatoswc, new Object[] {context} );
                              WebComp_Profesionalesdatoswc.ComponentInit();
                              WebComp_Profesionalesdatoswc.Name = "OldProfesionalesdatoswc";
                              WebComp_Profesionalesdatoswc_Component = OldProfesionalesdatoswc;
                           }
                           if ( StringUtil.Len( WebComp_Profesionalesdatoswc_Component) != 0 )
                           {
                              WebComp_Profesionalesdatoswc.componentprocess("W0077", "", sEvt);
                           }
                           WebComp_Profesionalesdatoswc_Component = OldProfesionalesdatoswc;
                        }
                        else if ( nCmpId == 85 )
                        {
                           OldMetodopagoswc = cgiGet( "W0085");
                           if ( ( StringUtil.Len( OldMetodopagoswc) == 0 ) || ( StringUtil.StrCmp(OldMetodopagoswc, WebComp_Metodopagoswc_Component) != 0 ) )
                           {
                              WebComp_Metodopagoswc = getWebComponent(GetType(), "GeneXus.Programs", OldMetodopagoswc, new Object[] {context} );
                              WebComp_Metodopagoswc.ComponentInit();
                              WebComp_Metodopagoswc.Name = "OldMetodopagoswc";
                              WebComp_Metodopagoswc_Component = OldMetodopagoswc;
                           }
                           if ( StringUtil.Len( WebComp_Metodopagoswc_Component) != 0 )
                           {
                              WebComp_Metodopagoswc.componentprocess("W0085", "", sEvt);
                           }
                           WebComp_Metodopagoswc_Component = OldMetodopagoswc;
                        }
                        else if ( nCmpId == 93 )
                        {
                           OldRubrosprofesionaleswc = cgiGet( "W0093");
                           if ( ( StringUtil.Len( OldRubrosprofesionaleswc) == 0 ) || ( StringUtil.StrCmp(OldRubrosprofesionaleswc, WebComp_Rubrosprofesionaleswc_Component) != 0 ) )
                           {
                              WebComp_Rubrosprofesionaleswc = getWebComponent(GetType(), "GeneXus.Programs", OldRubrosprofesionaleswc, new Object[] {context} );
                              WebComp_Rubrosprofesionaleswc.ComponentInit();
                              WebComp_Rubrosprofesionaleswc.Name = "OldRubrosprofesionaleswc";
                              WebComp_Rubrosprofesionaleswc_Component = OldRubrosprofesionaleswc;
                           }
                           if ( StringUtil.Len( WebComp_Rubrosprofesionaleswc_Component) != 0 )
                           {
                              WebComp_Rubrosprofesionaleswc.componentprocess("W0093", "", sEvt);
                           }
                           WebComp_Rubrosprofesionaleswc_Component = OldRubrosprofesionaleswc;
                        }
                        else if ( nCmpId == 101 )
                        {
                           OldRubrosprofesionalrubroswc = cgiGet( "W0101");
                           if ( ( StringUtil.Len( OldRubrosprofesionalrubroswc) == 0 ) || ( StringUtil.StrCmp(OldRubrosprofesionalrubroswc, WebComp_Rubrosprofesionalrubroswc_Component) != 0 ) )
                           {
                              WebComp_Rubrosprofesionalrubroswc = getWebComponent(GetType(), "GeneXus.Programs", OldRubrosprofesionalrubroswc, new Object[] {context} );
                              WebComp_Rubrosprofesionalrubroswc.ComponentInit();
                              WebComp_Rubrosprofesionalrubroswc.Name = "OldRubrosprofesionalrubroswc";
                              WebComp_Rubrosprofesionalrubroswc_Component = OldRubrosprofesionalrubroswc;
                           }
                           if ( StringUtil.Len( WebComp_Rubrosprofesionalrubroswc_Component) != 0 )
                           {
                              WebComp_Rubrosprofesionalrubroswc.componentprocess("W0101", "", sEvt);
                           }
                           WebComp_Rubrosprofesionalrubroswc_Component = OldRubrosprofesionalrubroswc;
                        }
                        else if ( nCmpId == 106 )
                        {
                           OldWwpaux_wc = cgiGet( "W0106");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0106", "", sEvt);
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

      protected void WECJ2( )
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

      protected void PACJ2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "estadosnotificacionview.aspx")), "estadosnotificacionview.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "estadosnotificacionview.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "EstadosTipo");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV10EstadosTipo = gxfirstwebparm;
                     AssignAttri("", false, "AV10EstadosTipo", AV10EstadosTipo);
                     GxWebStd.gx_hidden_field( context, "gxhash_vESTADOSTIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10EstadosTipo, "")), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV11EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( GetPar( "EstadosGenericosId"), "."), 18, MidpointRounding.ToEven));
                        AssignAttri("", false, "AV11EstadosGenericosId", StringUtil.LTrimStr( (decimal)(AV11EstadosGenericosId), 5, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vESTADOSGENERICOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11EstadosGenericosId), "ZZZZ9"), context));
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
         RFCJ2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFCJ2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E15CJ2 ();
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
               if ( StringUtil.Len( WebComp_Estadoswc_Component) != 0 )
               {
                  WebComp_Estadoswc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Listainventariowc_Component) != 0 )
               {
                  WebComp_Listainventariowc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Profesionaleswc_Component) != 0 )
               {
                  WebComp_Profesionaleswc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Profesionalrubroswc_Component) != 0 )
               {
                  WebComp_Profesionalrubroswc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Profesionaleszonaswc_Component) != 0 )
               {
                  WebComp_Profesionaleszonaswc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Profesionalesdatoswc_Component) != 0 )
               {
                  WebComp_Profesionalesdatoswc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Metodopagoswc_Component) != 0 )
               {
                  WebComp_Metodopagoswc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Rubrosprofesionaleswc_Component) != 0 )
               {
                  WebComp_Rubrosprofesionaleswc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Rubrosprofesionalrubroswc_Component) != 0 )
               {
                  WebComp_Rubrosprofesionalrubroswc.componentstart();
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
            /* Using cursor H00CJ2 */
            pr_default.execute(0, new Object[] {AV10EstadosTipo, AV11EstadosGenericosId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A108EstadosGenericosId = H00CJ2_A108EstadosGenericosId[0];
               A107EstadosTipo = H00CJ2_A107EstadosTipo[0];
               /* Execute user event: Load */
               E16CJ2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WBCJ0( ) ;
         }
      }

      protected void send_integrity_lvl_hashesCJ2( )
      {
         GxWebStd.gx_hidden_field( context, "vRECORDDESCRIPTION", AV17RecordDescription);
         GxWebStd.gx_hidden_field( context, "gxhash_vRECORDDESCRIPTION", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17RecordDescription, "")), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUPCJ0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E14CJ2 ();
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
         E14CJ2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E14CJ2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         lblWorkwithlink_Link = formatLink("estadosnotificacionww.aspx") ;
         AssignProp("", false, lblWorkwithlink_Internalname, "Link", lblWorkwithlink_Link, true);
         AV19GXLvl9 = 0;
         /* Using cursor H00CJ3 */
         pr_default.execute(1, new Object[] {AV10EstadosTipo, AV11EstadosGenericosId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A108EstadosGenericosId = H00CJ3_A108EstadosGenericosId[0];
            A107EstadosTipo = H00CJ3_A107EstadosTipo[0];
            A109EstadosGenericosNombre = H00CJ3_A109EstadosGenericosNombre[0];
            AV19GXLvl9 = 1;
            Form.Caption = A109EstadosGenericosNombre;
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            AV9Exists = true;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         if ( AV19GXLvl9 == 0 )
         {
            Form.Caption = context.GetMessage( "WWP_RecordNotFound", "");
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            AV9Exists = false;
         }
         if ( AV9Exists )
         {
            AV13SelectedTabCode = AV8TabCode;
            AssignAttri("", false, "AV13SelectedTabCode", AV13SelectedTabCode);
            Tabs_Activepagecontrolname = AV13SelectedTabCode;
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
         AV17RecordDescription = Form.Caption;
         AssignAttri("", false, "AV17RecordDescription", AV17RecordDescription);
         GxWebStd.gx_hidden_field( context, "gxhash_vRECORDDESCRIPTION", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17RecordDescription, "")), context));
         if ( StringUtil.StrCmp(AV18Session.Get("DiscussionThreadIdToOpen"), "") != 0 )
         {
            this.executeUsercontrolMethod("", false, "DDC_DISCUSSIONSContainer", "Open", "", new Object[] {});
         }
      }

      protected void E15CJ2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.wwpbaseobjects.discussions.wwp_hasdiscussionmessages(context).executeUdp(  "EstadosNotificacion",  A107EstadosTipo+";"+StringUtil.Trim( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0))) )
         {
            Ddc_discussions_Icon = context.GetMessage( "far fa-comment", "");
            ucDdc_discussions.SendProperty(context, "", false, Ddc_discussions_Internalname, "Icon", Ddc_discussions_Icon);
         }
         GXt_boolean1 = AV16TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "SubscriptionsPanel", out  GXt_boolean1) ;
         AV16TempBoolean = GXt_boolean1;
         if ( AV16TempBoolean && ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "EstadosNotificacion",  2) ) )
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

      protected void E16CJ2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void E11CJ2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0106",(string)"",(string)"EstadosNotificacion",(short)2,A107EstadosTipo+";"+StringUtil.Trim( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0)),(string)AV17RecordDescription});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)""+""+""+""+""+""+"",(string)"",(string)""+""+"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0106"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E12CJ2( )
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
            GXEncryptionTmp = "estadosnotificacionview.aspx"+UrlEncode(StringUtil.RTrim(A107EstadosTipo)) + "," + UrlEncode(StringUtil.LTrimStr(A108EstadosGenericosId,5,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0106",(string)"",(string)"EstadosNotificacion",A107EstadosTipo+";"+StringUtil.Trim( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0)),(string)AV17RecordDescription,formatLink("estadosnotificacionview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)""+""+""+""+""+""+"",(string)"",(string)""+""+"",(string)"",(string)""+"",(string)"",(string)"",(string)""+""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0106"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E13CJ2( )
      {
         /* Tabs_Tabchanged Routine */
         returnInSub = false;
         AV13SelectedTabCode = Tabs_Activepagecontrolname;
         AssignAttri("", false, "AV13SelectedTabCode", AV13SelectedTabCode);
         AV12LoadAllTabs = false;
         AssignAttri("", false, "AV12LoadAllTabs", AV12LoadAllTabs);
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
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Webcomponent_general_Component), StringUtil.Lower( "EstadosNotificacionGeneral")) != 0 )
         {
            WebComp_Webcomponent_general = getWebComponent(GetType(), "GeneXus.Programs", "estadosnotificaciongeneral", new Object[] {context} );
            WebComp_Webcomponent_general.ComponentInit();
            WebComp_Webcomponent_general.Name = "EstadosNotificacionGeneral";
            WebComp_Webcomponent_general_Component = "EstadosNotificacionGeneral";
         }
         if ( StringUtil.Len( WebComp_Webcomponent_general_Component) != 0 )
         {
            WebComp_Webcomponent_general.setjustcreated();
            WebComp_Webcomponent_general.componentprepare(new Object[] {(string)"W0023",(string)"",(string)AV10EstadosTipo,(int)AV11EstadosGenericosId});
            WebComp_Webcomponent_general.componentbind(new Object[] {(string)"",(string)""});
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
         /* Using cursor H00CJ4 */
         pr_default.execute(2, new Object[] {AV10EstadosTipo, AV11EstadosGenericosId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A108EstadosGenericosId = H00CJ4_A108EstadosGenericosId[0];
            A107EstadosTipo = H00CJ4_A107EstadosTipo[0];
            GXt_boolean1 = AV16TempBoolean;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWEstados", out  GXt_boolean1) ;
            AV16TempBoolean = GXt_boolean1;
            if ( AV16TempBoolean )
            {
               if ( AV12LoadAllTabs || ( StringUtil.StrCmp(AV13SelectedTabCode, "") == 0 ) || ( StringUtil.StrCmp(AV13SelectedTabCode, "Estados") == 0 ) )
               {
                  /* Object Property */
                  if ( true )
                  {
                     bDynCreated_Estadoswc = true;
                  }
                  if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Estadoswc_Component), StringUtil.Lower( "EstadosNotificacionEstados")) != 0 )
                  {
                     WebComp_Estadoswc = getWebComponent(GetType(), "GeneXus.Programs", "estadosnotificacionestados", new Object[] {context} );
                     WebComp_Estadoswc.ComponentInit();
                     WebComp_Estadoswc.Name = "EstadosNotificacionEstados";
                     WebComp_Estadoswc_Component = "EstadosNotificacionEstados";
                  }
                  if ( StringUtil.Len( WebComp_Estadoswc_Component) != 0 )
                  {
                     WebComp_Estadoswc.setjustcreated();
                     WebComp_Estadoswc.componentprepare(new Object[] {(string)"W0037",(string)"",(string)AV10EstadosTipo,(int)AV11EstadosGenericosId});
                     WebComp_Estadoswc.componentbind(new Object[] {(string)"",(string)""});
                  }
                  if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Estadoswc )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0037"+"");
                     WebComp_Estadoswc.componentdraw();
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
            }
            else
            {
               this.executeUsercontrolMethod("", false, "TABSContainer", "HideTab", "", new Object[] {(short)1});
            }
            GXt_boolean1 = AV16TempBoolean;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWInventario", out  GXt_boolean1) ;
            AV16TempBoolean = GXt_boolean1;
            if ( AV16TempBoolean )
            {
               if ( AV12LoadAllTabs || ( StringUtil.StrCmp(AV13SelectedTabCode, "listaInventario") == 0 ) )
               {
                  /* Object Property */
                  if ( true )
                  {
                     bDynCreated_Listainventariowc = true;
                  }
                  if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Listainventariowc_Component), StringUtil.Lower( "EstadosNotificacionlistaInventarioWC")) != 0 )
                  {
                     WebComp_Listainventariowc = getWebComponent(GetType(), "GeneXus.Programs", "estadosnotificacionlistainventariowc", new Object[] {context} );
                     WebComp_Listainventariowc.ComponentInit();
                     WebComp_Listainventariowc.Name = "EstadosNotificacionlistaInventarioWC";
                     WebComp_Listainventariowc_Component = "EstadosNotificacionlistaInventarioWC";
                  }
                  if ( StringUtil.Len( WebComp_Listainventariowc_Component) != 0 )
                  {
                     WebComp_Listainventariowc.setjustcreated();
                     WebComp_Listainventariowc.componentprepare(new Object[] {(string)"W0045",(string)"",(string)AV10EstadosTipo,(int)AV11EstadosGenericosId});
                     WebComp_Listainventariowc.componentbind(new Object[] {(string)"",(string)""});
                  }
                  if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Listainventariowc )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0045"+"");
                     WebComp_Listainventariowc.componentdraw();
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
            }
            else
            {
               this.executeUsercontrolMethod("", false, "TABSContainer", "HideTab", "", new Object[] {(short)2});
            }
            GXt_boolean1 = AV16TempBoolean;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionales", out  GXt_boolean1) ;
            AV16TempBoolean = GXt_boolean1;
            if ( AV16TempBoolean )
            {
               if ( AV12LoadAllTabs || ( StringUtil.StrCmp(AV13SelectedTabCode, "Profesionales") == 0 ) )
               {
                  /* Object Property */
                  if ( true )
                  {
                     bDynCreated_Profesionaleswc = true;
                  }
                  if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Profesionaleswc_Component), StringUtil.Lower( "EstadosNotificacionProfesionalesWC")) != 0 )
                  {
                     WebComp_Profesionaleswc = getWebComponent(GetType(), "GeneXus.Programs", "estadosnotificacionprofesionaleswc", new Object[] {context} );
                     WebComp_Profesionaleswc.ComponentInit();
                     WebComp_Profesionaleswc.Name = "EstadosNotificacionProfesionalesWC";
                     WebComp_Profesionaleswc_Component = "EstadosNotificacionProfesionalesWC";
                  }
                  if ( StringUtil.Len( WebComp_Profesionaleswc_Component) != 0 )
                  {
                     WebComp_Profesionaleswc.setjustcreated();
                     WebComp_Profesionaleswc.componentprepare(new Object[] {(string)"W0053",(string)"",(string)AV10EstadosTipo,(int)AV11EstadosGenericosId});
                     WebComp_Profesionaleswc.componentbind(new Object[] {(string)"",(string)""});
                  }
                  if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Profesionaleswc )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0053"+"");
                     WebComp_Profesionaleswc.componentdraw();
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
            }
            else
            {
               this.executeUsercontrolMethod("", false, "TABSContainer", "HideTab", "", new Object[] {(short)3});
            }
            if ( AV12LoadAllTabs || ( StringUtil.StrCmp(AV13SelectedTabCode, "ProfesionalRubros") == 0 ) )
            {
               /* Object Property */
               if ( true )
               {
                  bDynCreated_Profesionalrubroswc = true;
               }
               if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Profesionalrubroswc_Component), StringUtil.Lower( "EstadosNotificacionProfesionalRubrosWC")) != 0 )
               {
                  WebComp_Profesionalrubroswc = getWebComponent(GetType(), "GeneXus.Programs", "estadosnotificacionprofesionalrubroswc", new Object[] {context} );
                  WebComp_Profesionalrubroswc.ComponentInit();
                  WebComp_Profesionalrubroswc.Name = "EstadosNotificacionProfesionalRubrosWC";
                  WebComp_Profesionalrubroswc_Component = "EstadosNotificacionProfesionalRubrosWC";
               }
               if ( StringUtil.Len( WebComp_Profesionalrubroswc_Component) != 0 )
               {
                  WebComp_Profesionalrubroswc.setjustcreated();
                  WebComp_Profesionalrubroswc.componentprepare(new Object[] {(string)"W0061",(string)"",(string)AV10EstadosTipo,(int)AV11EstadosGenericosId});
                  WebComp_Profesionalrubroswc.componentbind(new Object[] {(string)"",(string)""});
               }
               if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Profesionalrubroswc )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0061"+"");
                  WebComp_Profesionalrubroswc.componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
            if ( AV12LoadAllTabs || ( StringUtil.StrCmp(AV13SelectedTabCode, "ProfesionalesZonas") == 0 ) )
            {
               /* Object Property */
               if ( true )
               {
                  bDynCreated_Profesionaleszonaswc = true;
               }
               if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Profesionaleszonaswc_Component), StringUtil.Lower( "EstadosNotificacionProfesionalesZonasWC")) != 0 )
               {
                  WebComp_Profesionaleszonaswc = getWebComponent(GetType(), "GeneXus.Programs", "estadosnotificacionprofesionaleszonaswc", new Object[] {context} );
                  WebComp_Profesionaleszonaswc.ComponentInit();
                  WebComp_Profesionaleszonaswc.Name = "EstadosNotificacionProfesionalesZonasWC";
                  WebComp_Profesionaleszonaswc_Component = "EstadosNotificacionProfesionalesZonasWC";
               }
               if ( StringUtil.Len( WebComp_Profesionaleszonaswc_Component) != 0 )
               {
                  WebComp_Profesionaleszonaswc.setjustcreated();
                  WebComp_Profesionaleszonaswc.componentprepare(new Object[] {(string)"W0069",(string)"",(string)AV10EstadosTipo,(int)AV11EstadosGenericosId});
                  WebComp_Profesionaleszonaswc.componentbind(new Object[] {(string)"",(string)""});
               }
               if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Profesionaleszonaswc )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0069"+"");
                  WebComp_Profesionaleszonaswc.componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
            if ( AV12LoadAllTabs || ( StringUtil.StrCmp(AV13SelectedTabCode, "ProfesionalesDatos") == 0 ) )
            {
               /* Object Property */
               if ( true )
               {
                  bDynCreated_Profesionalesdatoswc = true;
               }
               if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Profesionalesdatoswc_Component), StringUtil.Lower( "EstadosNotificacionProfesionalesDatosWC")) != 0 )
               {
                  WebComp_Profesionalesdatoswc = getWebComponent(GetType(), "GeneXus.Programs", "estadosnotificacionprofesionalesdatoswc", new Object[] {context} );
                  WebComp_Profesionalesdatoswc.ComponentInit();
                  WebComp_Profesionalesdatoswc.Name = "EstadosNotificacionProfesionalesDatosWC";
                  WebComp_Profesionalesdatoswc_Component = "EstadosNotificacionProfesionalesDatosWC";
               }
               if ( StringUtil.Len( WebComp_Profesionalesdatoswc_Component) != 0 )
               {
                  WebComp_Profesionalesdatoswc.setjustcreated();
                  WebComp_Profesionalesdatoswc.componentprepare(new Object[] {(string)"W0077",(string)"",(string)AV10EstadosTipo,(int)AV11EstadosGenericosId});
                  WebComp_Profesionalesdatoswc.componentbind(new Object[] {(string)"",(string)""});
               }
               if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Profesionalesdatoswc )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0077"+"");
                  WebComp_Profesionalesdatoswc.componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
            GXt_boolean1 = AV16TempBoolean;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMetodoPagos", out  GXt_boolean1) ;
            AV16TempBoolean = GXt_boolean1;
            if ( AV16TempBoolean )
            {
               if ( AV12LoadAllTabs || ( StringUtil.StrCmp(AV13SelectedTabCode, "MetodoPagos") == 0 ) )
               {
                  /* Object Property */
                  if ( true )
                  {
                     bDynCreated_Metodopagoswc = true;
                  }
                  if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Metodopagoswc_Component), StringUtil.Lower( "EstadosNotificacionMetodoPagosWC")) != 0 )
                  {
                     WebComp_Metodopagoswc = getWebComponent(GetType(), "GeneXus.Programs", "estadosnotificacionmetodopagoswc", new Object[] {context} );
                     WebComp_Metodopagoswc.ComponentInit();
                     WebComp_Metodopagoswc.Name = "EstadosNotificacionMetodoPagosWC";
                     WebComp_Metodopagoswc_Component = "EstadosNotificacionMetodoPagosWC";
                  }
                  if ( StringUtil.Len( WebComp_Metodopagoswc_Component) != 0 )
                  {
                     WebComp_Metodopagoswc.setjustcreated();
                     WebComp_Metodopagoswc.componentprepare(new Object[] {(string)"W0085",(string)"",(string)AV10EstadosTipo,(int)AV11EstadosGenericosId});
                     WebComp_Metodopagoswc.componentbind(new Object[] {(string)"",(string)""});
                  }
                  if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Metodopagoswc )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0085"+"");
                     WebComp_Metodopagoswc.componentdraw();
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
            }
            else
            {
               this.executeUsercontrolMethod("", false, "TABSContainer", "HideTab", "", new Object[] {(short)7});
            }
            GXt_boolean1 = AV16TempBoolean;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionales", out  GXt_boolean1) ;
            AV16TempBoolean = GXt_boolean1;
            if ( AV16TempBoolean )
            {
               if ( AV12LoadAllTabs || ( StringUtil.StrCmp(AV13SelectedTabCode, "RubrosProfesionales") == 0 ) )
               {
                  /* Object Property */
                  if ( true )
                  {
                     bDynCreated_Rubrosprofesionaleswc = true;
                  }
                  if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Rubrosprofesionaleswc_Component), StringUtil.Lower( "EstadosNotificacionRubrosProfesionalesWC")) != 0 )
                  {
                     WebComp_Rubrosprofesionaleswc = getWebComponent(GetType(), "GeneXus.Programs", "estadosnotificacionrubrosprofesionaleswc", new Object[] {context} );
                     WebComp_Rubrosprofesionaleswc.ComponentInit();
                     WebComp_Rubrosprofesionaleswc.Name = "EstadosNotificacionRubrosProfesionalesWC";
                     WebComp_Rubrosprofesionaleswc_Component = "EstadosNotificacionRubrosProfesionalesWC";
                  }
                  if ( StringUtil.Len( WebComp_Rubrosprofesionaleswc_Component) != 0 )
                  {
                     WebComp_Rubrosprofesionaleswc.setjustcreated();
                     WebComp_Rubrosprofesionaleswc.componentprepare(new Object[] {(string)"W0093",(string)"",(string)AV10EstadosTipo,(int)AV11EstadosGenericosId});
                     WebComp_Rubrosprofesionaleswc.componentbind(new Object[] {(string)"",(string)""});
                  }
                  if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Rubrosprofesionaleswc )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0093"+"");
                     WebComp_Rubrosprofesionaleswc.componentdraw();
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
            }
            else
            {
               this.executeUsercontrolMethod("", false, "TABSContainer", "HideTab", "", new Object[] {(short)8});
            }
            if ( AV12LoadAllTabs || ( StringUtil.StrCmp(AV13SelectedTabCode, "RubrosProfesionalRubros") == 0 ) )
            {
               /* Object Property */
               if ( true )
               {
                  bDynCreated_Rubrosprofesionalrubroswc = true;
               }
               if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Rubrosprofesionalrubroswc_Component), StringUtil.Lower( "EstadosNotificacionRubrosProfesionalRubrosWC")) != 0 )
               {
                  WebComp_Rubrosprofesionalrubroswc = getWebComponent(GetType(), "GeneXus.Programs", "estadosnotificacionrubrosprofesionalrubroswc", new Object[] {context} );
                  WebComp_Rubrosprofesionalrubroswc.ComponentInit();
                  WebComp_Rubrosprofesionalrubroswc.Name = "EstadosNotificacionRubrosProfesionalRubrosWC";
                  WebComp_Rubrosprofesionalrubroswc_Component = "EstadosNotificacionRubrosProfesionalRubrosWC";
               }
               if ( StringUtil.Len( WebComp_Rubrosprofesionalrubroswc_Component) != 0 )
               {
                  WebComp_Rubrosprofesionalrubroswc.setjustcreated();
                  WebComp_Rubrosprofesionalrubroswc.componentprepare(new Object[] {(string)"W0101",(string)"",(string)AV10EstadosTipo,(int)AV11EstadosGenericosId});
                  WebComp_Rubrosprofesionalrubroswc.componentbind(new Object[] {(string)"",(string)""});
               }
               if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Rubrosprofesionalrubroswc )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0101"+"");
                  WebComp_Rubrosprofesionalrubroswc.componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
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
         AV10EstadosTipo = (string)getParm(obj,0);
         AssignAttri("", false, "AV10EstadosTipo", AV10EstadosTipo);
         GxWebStd.gx_hidden_field( context, "gxhash_vESTADOSTIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10EstadosTipo, "")), context));
         AV11EstadosGenericosId = Convert.ToInt32(getParm(obj,1));
         AssignAttri("", false, "AV11EstadosGenericosId", StringUtil.LTrimStr( (decimal)(AV11EstadosGenericosId), 5, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vESTADOSGENERICOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11EstadosGenericosId), "ZZZZ9"), context));
         AV8TabCode = (string)getParm(obj,2);
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
         PACJ2( ) ;
         WSCJ2( ) ;
         WECJ2( ) ;
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
         if ( ! ( WebComp_Estadoswc == null ) )
         {
            if ( StringUtil.Len( WebComp_Estadoswc_Component) != 0 )
            {
               WebComp_Estadoswc.componentthemes();
            }
         }
         if ( ! ( WebComp_Listainventariowc == null ) )
         {
            if ( StringUtil.Len( WebComp_Listainventariowc_Component) != 0 )
            {
               WebComp_Listainventariowc.componentthemes();
            }
         }
         if ( ! ( WebComp_Profesionaleswc == null ) )
         {
            if ( StringUtil.Len( WebComp_Profesionaleswc_Component) != 0 )
            {
               WebComp_Profesionaleswc.componentthemes();
            }
         }
         if ( ! ( WebComp_Profesionalrubroswc == null ) )
         {
            if ( StringUtil.Len( WebComp_Profesionalrubroswc_Component) != 0 )
            {
               WebComp_Profesionalrubroswc.componentthemes();
            }
         }
         if ( ! ( WebComp_Profesionaleszonaswc == null ) )
         {
            if ( StringUtil.Len( WebComp_Profesionaleszonaswc_Component) != 0 )
            {
               WebComp_Profesionaleszonaswc.componentthemes();
            }
         }
         if ( ! ( WebComp_Profesionalesdatoswc == null ) )
         {
            if ( StringUtil.Len( WebComp_Profesionalesdatoswc_Component) != 0 )
            {
               WebComp_Profesionalesdatoswc.componentthemes();
            }
         }
         if ( ! ( WebComp_Metodopagoswc == null ) )
         {
            if ( StringUtil.Len( WebComp_Metodopagoswc_Component) != 0 )
            {
               WebComp_Metodopagoswc.componentthemes();
            }
         }
         if ( ! ( WebComp_Rubrosprofesionaleswc == null ) )
         {
            if ( StringUtil.Len( WebComp_Rubrosprofesionaleswc_Component) != 0 )
            {
               WebComp_Rubrosprofesionaleswc.componentthemes();
            }
         }
         if ( ! ( WebComp_Rubrosprofesionalrubroswc == null ) )
         {
            if ( StringUtil.Len( WebComp_Rubrosprofesionalrubroswc_Component) != 0 )
            {
               WebComp_Rubrosprofesionalrubroswc.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021224592", true, true, false);
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
         context.AddJavascriptSource("estadosnotificacionview.js", "?202673021224592", false, true, false);
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
         divEstadosnotificaciongeneral_cell_Internalname = "ESTADOSNOTIFICACIONGENERAL_CELL";
         lblEstados_title_Internalname = "ESTADOS_TITLE";
         divUnnamedtableestados_Internalname = "UNNAMEDTABLEESTADOS";
         lblListainventario_title_Internalname = "LISTAINVENTARIO_TITLE";
         divUnnamedtablelistainventario_Internalname = "UNNAMEDTABLELISTAINVENTARIO";
         lblProfesionales_title_Internalname = "PROFESIONALES_TITLE";
         divUnnamedtableprofesionales_Internalname = "UNNAMEDTABLEPROFESIONALES";
         lblProfesionalrubros_title_Internalname = "PROFESIONALRUBROS_TITLE";
         divUnnamedtableprofesionalrubros_Internalname = "UNNAMEDTABLEPROFESIONALRUBROS";
         lblProfesionaleszonas_title_Internalname = "PROFESIONALESZONAS_TITLE";
         divUnnamedtableprofesionaleszonas_Internalname = "UNNAMEDTABLEPROFESIONALESZONAS";
         lblProfesionalesdatos_title_Internalname = "PROFESIONALESDATOS_TITLE";
         divUnnamedtableprofesionalesdatos_Internalname = "UNNAMEDTABLEPROFESIONALESDATOS";
         lblMetodopagos_title_Internalname = "METODOPAGOS_TITLE";
         divUnnamedtablemetodopagos_Internalname = "UNNAMEDTABLEMETODOPAGOS";
         lblRubrosprofesionales_title_Internalname = "RUBROSPROFESIONALES_TITLE";
         divUnnamedtablerubrosprofesionales_Internalname = "UNNAMEDTABLERUBROSPROFESIONALES";
         lblRubrosprofesionalrubros_title_Internalname = "RUBROSPROFESIONALRUBROS_TITLE";
         divUnnamedtablerubrosprofesionalrubros_Internalname = "UNNAMEDTABLERUBROSPROFESIONALRUBROS";
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
         Tabs_Pagecount = 9;
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
         Form.Caption = context.GetMessage( "Estados Notificacion View", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'AV17RecordDescription',fld:'vRECORDDESCRIPTION',pic:'',hsh:true,type:'svchar'},{av:'AV10EstadosTipo',fld:'vESTADOSTIPO',pic:'',hsh:true,type:'char'},{av:'AV11EstadosGenericosId',fld:'vESTADOSGENERICOSID',pic:'ZZZZ9',hsh:true,type:'int'},{av:'AV8TabCode',fld:'vTABCODE',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'Ddc_discussions_Icon',ctrl:'DDC_DISCUSSIONS',prop:'Icon'},{av:'Ddc_subscriptions_Visible',ctrl:'DDC_SUBSCRIPTIONS',prop:'Visible'}]}");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","{handler:'E11CJ2',iparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'AV17RecordDescription',fld:'vRECORDDESCRIPTION',pic:'',hsh:true,type:'svchar'}]");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("DDC_DISCUSSIONS.ONLOADCOMPONENT","{handler:'E12CJ2',iparms:[{av:'AV17RecordDescription',fld:'vRECORDDESCRIPTION',pic:'',hsh:true,type:'svchar'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("DDC_DISCUSSIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("TABS.TABCHANGED","{handler:'E13CJ2',iparms:[{av:'Tabs_Activepagecontrolname',ctrl:'TABS',prop:'ActivePageControlName'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'AV10EstadosTipo',fld:'vESTADOSTIPO',pic:'',hsh:true,type:'char'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'AV11EstadosGenericosId',fld:'vESTADOSGENERICOSID',pic:'ZZZZ9',hsh:true,type:'int'},{av:'AV12LoadAllTabs',fld:'vLOADALLTABS',pic:'',type:'boolean'},{av:'AV13SelectedTabCode',fld:'vSELECTEDTABCODE',pic:'',type:'char'}]");
         setEventMetadata("TABS.TABCHANGED",",oparms:[{av:'AV13SelectedTabCode',fld:'vSELECTEDTABCODE',pic:'',type:'char'},{av:'AV12LoadAllTabs',fld:'vLOADALLTABS',pic:'',type:'boolean'},{ctrl:'ESTADOSWC'},{ctrl:'LISTAINVENTARIOWC'},{ctrl:'PROFESIONALESWC'},{ctrl:'PROFESIONALRUBROSWC'},{ctrl:'PROFESIONALESZONASWC'},{ctrl:'PROFESIONALESDATOSWC'},{ctrl:'METODOPAGOSWC'},{ctrl:'RUBROSPROFESIONALESWC'},{ctrl:'RUBROSPROFESIONALRUBROSWC'}]}");
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
         wcpOAV10EstadosTipo = "";
         wcpOAV8TabCode = "";
         Tabs_Activepagecontrolname = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV17RecordDescription = "";
         A107EstadosTipo = "";
         AV13SelectedTabCode = "";
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
         lblEstados_title_Jsonclick = "";
         WebComp_Estadoswc_Component = "";
         OldEstadoswc = "";
         lblListainventario_title_Jsonclick = "";
         WebComp_Listainventariowc_Component = "";
         OldListainventariowc = "";
         lblProfesionales_title_Jsonclick = "";
         WebComp_Profesionaleswc_Component = "";
         OldProfesionaleswc = "";
         lblProfesionalrubros_title_Jsonclick = "";
         WebComp_Profesionalrubroswc_Component = "";
         OldProfesionalrubroswc = "";
         lblProfesionaleszonas_title_Jsonclick = "";
         WebComp_Profesionaleszonaswc_Component = "";
         OldProfesionaleszonaswc = "";
         lblProfesionalesdatos_title_Jsonclick = "";
         WebComp_Profesionalesdatoswc_Component = "";
         OldProfesionalesdatoswc = "";
         lblMetodopagos_title_Jsonclick = "";
         WebComp_Metodopagoswc_Component = "";
         OldMetodopagoswc = "";
         lblRubrosprofesionales_title_Jsonclick = "";
         WebComp_Rubrosprofesionaleswc_Component = "";
         OldRubrosprofesionaleswc = "";
         lblRubrosprofesionalrubros_title_Jsonclick = "";
         WebComp_Rubrosprofesionalrubroswc_Component = "";
         OldRubrosprofesionalrubroswc = "";
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H00CJ2_A108EstadosGenericosId = new int[1] ;
         H00CJ2_A107EstadosTipo = new string[] {""} ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         H00CJ3_A108EstadosGenericosId = new int[1] ;
         H00CJ3_A107EstadosTipo = new string[] {""} ;
         H00CJ3_A109EstadosGenericosNombre = new string[] {""} ;
         A109EstadosGenericosNombre = "";
         AV18Session = context.GetSession();
         H00CJ4_A108EstadosGenericosId = new int[1] ;
         H00CJ4_A107EstadosTipo = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.estadosnotificacionview__default(),
            new Object[][] {
                new Object[] {
               H00CJ2_A108EstadosGenericosId, H00CJ2_A107EstadosTipo
               }
               , new Object[] {
               H00CJ3_A108EstadosGenericosId, H00CJ3_A107EstadosTipo, H00CJ3_A109EstadosGenericosNombre
               }
               , new Object[] {
               H00CJ4_A108EstadosGenericosId, H00CJ4_A107EstadosTipo
               }
            }
         );
         WebComp_Webcomponent_general = new GeneXus.Http.GXNullWebComponent();
         WebComp_Estadoswc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Listainventariowc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Profesionaleswc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Profesionalrubroswc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Profesionaleszonaswc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Profesionalesdatoswc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Metodopagoswc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Rubrosprofesionaleswc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Rubrosprofesionalrubroswc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short AV19GXLvl9 ;
      private short nGXWrapped ;
      private int AV11EstadosGenericosId ;
      private int wcpOAV11EstadosGenericosId ;
      private int A108EstadosGenericosId ;
      private int Tabs_Pagecount ;
      private int idxLst ;
      private string AV10EstadosTipo ;
      private string AV8TabCode ;
      private string wcpOAV10EstadosTipo ;
      private string wcpOAV8TabCode ;
      private string Tabs_Activepagecontrolname ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string A107EstadosTipo ;
      private string AV13SelectedTabCode ;
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
      private string divEstadosnotificaciongeneral_cell_Internalname ;
      private string Panel_general_Internalname ;
      private string divTablepanel_general_Internalname ;
      private string WebComp_Webcomponent_general_Component ;
      private string OldWebcomponent_general ;
      private string divUnnamedtableviewcontainer_Internalname ;
      private string Tabs_Internalname ;
      private string lblEstados_title_Internalname ;
      private string lblEstados_title_Jsonclick ;
      private string divUnnamedtableestados_Internalname ;
      private string WebComp_Estadoswc_Component ;
      private string OldEstadoswc ;
      private string lblListainventario_title_Internalname ;
      private string lblListainventario_title_Jsonclick ;
      private string divUnnamedtablelistainventario_Internalname ;
      private string WebComp_Listainventariowc_Component ;
      private string OldListainventariowc ;
      private string lblProfesionales_title_Internalname ;
      private string lblProfesionales_title_Jsonclick ;
      private string divUnnamedtableprofesionales_Internalname ;
      private string WebComp_Profesionaleswc_Component ;
      private string OldProfesionaleswc ;
      private string lblProfesionalrubros_title_Internalname ;
      private string lblProfesionalrubros_title_Jsonclick ;
      private string divUnnamedtableprofesionalrubros_Internalname ;
      private string WebComp_Profesionalrubroswc_Component ;
      private string OldProfesionalrubroswc ;
      private string lblProfesionaleszonas_title_Internalname ;
      private string lblProfesionaleszonas_title_Jsonclick ;
      private string divUnnamedtableprofesionaleszonas_Internalname ;
      private string WebComp_Profesionaleszonaswc_Component ;
      private string OldProfesionaleszonaswc ;
      private string lblProfesionalesdatos_title_Internalname ;
      private string lblProfesionalesdatos_title_Jsonclick ;
      private string divUnnamedtableprofesionalesdatos_Internalname ;
      private string WebComp_Profesionalesdatoswc_Component ;
      private string OldProfesionalesdatoswc ;
      private string lblMetodopagos_title_Internalname ;
      private string lblMetodopagos_title_Jsonclick ;
      private string divUnnamedtablemetodopagos_Internalname ;
      private string WebComp_Metodopagoswc_Component ;
      private string OldMetodopagoswc ;
      private string lblRubrosprofesionales_title_Internalname ;
      private string lblRubrosprofesionales_title_Jsonclick ;
      private string divUnnamedtablerubrosprofesionales_Internalname ;
      private string WebComp_Rubrosprofesionaleswc_Component ;
      private string OldRubrosprofesionaleswc ;
      private string lblRubrosprofesionalrubros_title_Internalname ;
      private string lblRubrosprofesionalrubros_title_Jsonclick ;
      private string divUnnamedtablerubrosprofesionalrubros_Internalname ;
      private string WebComp_Rubrosprofesionalrubroswc_Component ;
      private string OldRubrosprofesionalrubroswc ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string A109EstadosGenericosNombre ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV12LoadAllTabs ;
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
      private bool AV16TempBoolean ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool bDynCreated_Webcomponent_general ;
      private bool bDynCreated_Estadoswc ;
      private bool bDynCreated_Listainventariowc ;
      private bool bDynCreated_Profesionaleswc ;
      private bool bDynCreated_Profesionalrubroswc ;
      private bool bDynCreated_Profesionaleszonaswc ;
      private bool bDynCreated_Profesionalesdatoswc ;
      private bool bDynCreated_Metodopagoswc ;
      private bool GXt_boolean1 ;
      private bool bDynCreated_Rubrosprofesionaleswc ;
      private bool bDynCreated_Rubrosprofesionalrubroswc ;
      private string AV17RecordDescription ;
      private IGxSession AV18Session ;
      private GXWebComponent WebComp_Webcomponent_general ;
      private GXWebComponent WebComp_Estadoswc ;
      private GXWebComponent WebComp_Listainventariowc ;
      private GXWebComponent WebComp_Profesionaleswc ;
      private GXWebComponent WebComp_Profesionalrubroswc ;
      private GXWebComponent WebComp_Profesionaleszonaswc ;
      private GXWebComponent WebComp_Profesionalesdatoswc ;
      private GXWebComponent WebComp_Metodopagoswc ;
      private GXWebComponent WebComp_Rubrosprofesionaleswc ;
      private GXWebComponent WebComp_Rubrosprofesionalrubroswc ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXUserControl ucDdc_subscriptions ;
      private GXUserControl ucDdc_discussions ;
      private GXUserControl ucPanel_general ;
      private GXUserControl ucTabs ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] H00CJ2_A108EstadosGenericosId ;
      private string[] H00CJ2_A107EstadosTipo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private int[] H00CJ3_A108EstadosGenericosId ;
      private string[] H00CJ3_A107EstadosTipo ;
      private string[] H00CJ3_A109EstadosGenericosNombre ;
      private int[] H00CJ4_A108EstadosGenericosId ;
      private string[] H00CJ4_A107EstadosTipo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class estadosnotificacionview__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00CJ2;
          prmH00CJ2 = new Object[] {
          new ParDef("@AV10EstadosTipo",GXType.NChar,3,0) ,
          new ParDef("@AV11EstadosGenericosId",GXType.Int32,5,0)
          };
          Object[] prmH00CJ3;
          prmH00CJ3 = new Object[] {
          new ParDef("@AV10EstadosTipo",GXType.NChar,3,0) ,
          new ParDef("@AV11EstadosGenericosId",GXType.Int32,5,0)
          };
          Object[] prmH00CJ4;
          prmH00CJ4 = new Object[] {
          new ParDef("@AV10EstadosTipo",GXType.NChar,3,0) ,
          new ParDef("@AV11EstadosGenericosId",GXType.Int32,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00CJ2", "SELECT [EstadosGenericosId], [EstadosTipo] FROM [EstadosGenericos] WHERE [EstadosTipo] = @AV10EstadosTipo and [EstadosGenericosId] = @AV11EstadosGenericosId ORDER BY [EstadosTipo], [EstadosGenericosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00CJ2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H00CJ3", "SELECT [EstadosGenericosId], [EstadosTipo], [EstadosGenericosNombre] FROM [EstadosGenericos] WHERE ([EstadosTipo] = @AV10EstadosTipo and [EstadosGenericosId] = @AV11EstadosGenericosId) AND ([EstadosTipo] = @AV10EstadosTipo and [EstadosGenericosId] = @AV11EstadosGenericosId) ORDER BY [EstadosTipo], [EstadosGenericosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00CJ3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H00CJ4", "SELECT [EstadosGenericosId], [EstadosTipo] FROM [EstadosGenericos] WHERE ([EstadosTipo] = @AV10EstadosTipo and [EstadosGenericosId] = @AV11EstadosGenericosId) AND ([EstadosTipo] = @AV10EstadosTipo and [EstadosGenericosId] = @AV11EstadosGenericosId) ORDER BY [EstadosTipo], [EstadosGenericosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00CJ4,1, GxCacheFrequency.OFF ,true,true )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                return;
       }
    }

 }

}
