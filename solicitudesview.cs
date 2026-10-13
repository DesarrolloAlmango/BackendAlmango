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
   public class solicitudesview : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public solicitudesview( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public solicitudesview( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesID ,
                           string aP1_TabCode )
      {
         this.AV10SolicitudesID = aP0_SolicitudesID;
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
            gxfirstwebparm = GetFirstPar( "SolicitudesID");
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
               gxfirstwebparm = GetFirstPar( "SolicitudesID");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "SolicitudesID");
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
         PA8A2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START8A2( ) ;
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
         context.WriteHtmlText( " "+"class=\"form-horizontal FormSplitScreen\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "solicitudesview.aspx"+UrlEncode(StringUtil.LTrimStr(AV10SolicitudesID,18,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TabCode));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormSplitScreen\" data-gx-class=\"form-horizontal FormSplitScreen\" novalidate action=\""+formatLink("solicitudesview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal FormSplitScreen", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10SolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTABCODE", StringUtil.RTrim( AV8TabCode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
         GXKey = Crypto.GetSiteKey( );
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"SolicitudesView");
         forbiddenHiddens.Add("SolicitudesNombre", StringUtil.RTrim( context.localUtil.Format( A171SolicitudesNombre, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("solicitudesview:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "SOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A127SolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10SolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vLOADALLTABS", AV11LoadAllTabs);
         GxWebStd.gx_hidden_field( context, "vSELECTEDTABCODE", StringUtil.RTrim( AV12SelectedTabCode));
         GxWebStd.gx_hidden_field( context, "vTABCODE", StringUtil.RTrim( AV8TabCode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
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
         if ( ! ( WebComp_Generalwc == null ) )
         {
            WebComp_Generalwc.componentjscripts();
         }
         if ( ! ( WebComp_Solicitudesrelacionwc == null ) )
         {
            WebComp_Solicitudesrelacionwc.componentjscripts();
         }
         if ( ! ( WebComp_Itemswc == null ) )
         {
            WebComp_Itemswc.componentjscripts();
         }
         if ( ! ( WebComp_Relacionessolicitudesrelacionwc == null ) )
         {
            WebComp_Relacionessolicitudesrelacionwc.componentjscripts();
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
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal FormSplitScreen" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE8A2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT8A2( ) ;
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
         GXEncryptionTmp = "solicitudesview.aspx"+UrlEncode(StringUtil.LTrimStr(AV10SolicitudesID,18,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TabCode));
         return formatLink("solicitudesview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "SolicitudesView" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Solicitudes View", "") ;
      }

      protected void WB8A0( )
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableSplitScreen", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellTitleViewSplitScreen", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSolicitudesNombre_Internalname, context.GetMessage( "Solicitudes Nombre", ""), "col-sm-3 AttributeTitleWWPLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtSolicitudesNombre_Internalname, StringUtil.RTrim( A171SolicitudesNombre), StringUtil.RTrim( context.localUtil.Format( A171SolicitudesNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,10);\"", "'"+""+"'"+",false,"+"'"+""+"'", edtSolicitudesNombre_Link, "", "", "", edtSolicitudesNombre_Jsonclick, 0, "AttributeTitleWWP", "", "", "", "", 1, edtSolicitudesNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SolicitudesView.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellViewTabsPosition", "start", "top", "", "", "div");
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
            GxWebStd.gx_label_ctrl( context, lblGeneral_title_Internalname, context.GetMessage( "General", ""), "", "", lblGeneral_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_SolicitudesView.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "General") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablegeneral_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0024"+"", StringUtil.RTrim( WebComp_Generalwc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0024"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Generalwc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldGeneralwc), StringUtil.Lower( WebComp_Generalwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0024"+"");
                  }
                  WebComp_Generalwc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldGeneralwc), StringUtil.Lower( WebComp_Generalwc_Component)) != 0 )
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
            GxWebStd.gx_label_ctrl( context, lblSolicitudesrelacion_title_Internalname, context.GetMessage( "Solicitudes Relacion", ""), "", "", lblSolicitudesrelacion_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_SolicitudesView.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "SolicitudesRelacion") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablesolicitudesrelacion_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0032"+"", StringUtil.RTrim( WebComp_Solicitudesrelacionwc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0032"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Solicitudesrelacionwc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldSolicitudesrelacionwc), StringUtil.Lower( WebComp_Solicitudesrelacionwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0032"+"");
                  }
                  WebComp_Solicitudesrelacionwc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldSolicitudesrelacionwc), StringUtil.Lower( WebComp_Solicitudesrelacionwc_Component)) != 0 )
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
            GxWebStd.gx_label_ctrl( context, lblItems_title_Internalname, context.GetMessage( "Trabajo Solicitado", ""), "", "", lblItems_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_SolicitudesView.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Items") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableitems_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0040"+"", StringUtil.RTrim( WebComp_Itemswc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0040"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Itemswc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldItemswc), StringUtil.Lower( WebComp_Itemswc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0040"+"");
                  }
                  WebComp_Itemswc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldItemswc), StringUtil.Lower( WebComp_Itemswc_Component)) != 0 )
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
            GxWebStd.gx_label_ctrl( context, lblRelacionessolicitudesrelacion_title_Internalname, context.GetMessage( "Profesional", ""), "", "", lblRelacionessolicitudesrelacion_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_SolicitudesView.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "RelacionesSolicitudesRelacion") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel4"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablerelacionessolicitudesrelacion_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0048"+"", StringUtil.RTrim( WebComp_Relacionessolicitudesrelacionwc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0048"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Relacionessolicitudesrelacionwc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldRelacionessolicitudesrelacionwc), StringUtil.Lower( WebComp_Relacionessolicitudesrelacionwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0048"+"");
                  }
                  WebComp_Relacionessolicitudesrelacionwc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldRelacionessolicitudesrelacionwc), StringUtil.Lower( WebComp_Relacionessolicitudesrelacionwc_Component)) != 0 )
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START8A2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Solicitudes View", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP8A0( ) ;
      }

      protected void WS8A2( )
      {
         START8A2( ) ;
         EVT8A2( ) ;
      }

      protected void EVT8A2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "TABS.TABCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Tabs.Tabchanged */
                              E118A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E128A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E138A2 ();
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
                        if ( nCmpId == 24 )
                        {
                           OldGeneralwc = cgiGet( "W0024");
                           if ( ( StringUtil.Len( OldGeneralwc) == 0 ) || ( StringUtil.StrCmp(OldGeneralwc, WebComp_Generalwc_Component) != 0 ) )
                           {
                              WebComp_Generalwc = getWebComponent(GetType(), "GeneXus.Programs", OldGeneralwc, new Object[] {context} );
                              WebComp_Generalwc.ComponentInit();
                              WebComp_Generalwc.Name = "OldGeneralwc";
                              WebComp_Generalwc_Component = OldGeneralwc;
                           }
                           if ( StringUtil.Len( WebComp_Generalwc_Component) != 0 )
                           {
                              WebComp_Generalwc.componentprocess("W0024", "", sEvt);
                           }
                           WebComp_Generalwc_Component = OldGeneralwc;
                        }
                        else if ( nCmpId == 32 )
                        {
                           OldSolicitudesrelacionwc = cgiGet( "W0032");
                           if ( ( StringUtil.Len( OldSolicitudesrelacionwc) == 0 ) || ( StringUtil.StrCmp(OldSolicitudesrelacionwc, WebComp_Solicitudesrelacionwc_Component) != 0 ) )
                           {
                              WebComp_Solicitudesrelacionwc = getWebComponent(GetType(), "GeneXus.Programs", OldSolicitudesrelacionwc, new Object[] {context} );
                              WebComp_Solicitudesrelacionwc.ComponentInit();
                              WebComp_Solicitudesrelacionwc.Name = "OldSolicitudesrelacionwc";
                              WebComp_Solicitudesrelacionwc_Component = OldSolicitudesrelacionwc;
                           }
                           if ( StringUtil.Len( WebComp_Solicitudesrelacionwc_Component) != 0 )
                           {
                              WebComp_Solicitudesrelacionwc.componentprocess("W0032", "", sEvt);
                           }
                           WebComp_Solicitudesrelacionwc_Component = OldSolicitudesrelacionwc;
                        }
                        else if ( nCmpId == 40 )
                        {
                           OldItemswc = cgiGet( "W0040");
                           if ( ( StringUtil.Len( OldItemswc) == 0 ) || ( StringUtil.StrCmp(OldItemswc, WebComp_Itemswc_Component) != 0 ) )
                           {
                              WebComp_Itemswc = getWebComponent(GetType(), "GeneXus.Programs", OldItemswc, new Object[] {context} );
                              WebComp_Itemswc.ComponentInit();
                              WebComp_Itemswc.Name = "OldItemswc";
                              WebComp_Itemswc_Component = OldItemswc;
                           }
                           if ( StringUtil.Len( WebComp_Itemswc_Component) != 0 )
                           {
                              WebComp_Itemswc.componentprocess("W0040", "", sEvt);
                           }
                           WebComp_Itemswc_Component = OldItemswc;
                        }
                        else if ( nCmpId == 48 )
                        {
                           OldRelacionessolicitudesrelacionwc = cgiGet( "W0048");
                           if ( ( StringUtil.Len( OldRelacionessolicitudesrelacionwc) == 0 ) || ( StringUtil.StrCmp(OldRelacionessolicitudesrelacionwc, WebComp_Relacionessolicitudesrelacionwc_Component) != 0 ) )
                           {
                              WebComp_Relacionessolicitudesrelacionwc = getWebComponent(GetType(), "GeneXus.Programs", OldRelacionessolicitudesrelacionwc, new Object[] {context} );
                              WebComp_Relacionessolicitudesrelacionwc.ComponentInit();
                              WebComp_Relacionessolicitudesrelacionwc.Name = "OldRelacionessolicitudesrelacionwc";
                              WebComp_Relacionessolicitudesrelacionwc_Component = OldRelacionessolicitudesrelacionwc;
                           }
                           if ( StringUtil.Len( WebComp_Relacionessolicitudesrelacionwc_Component) != 0 )
                           {
                              WebComp_Relacionessolicitudesrelacionwc.componentprocess("W0048", "", sEvt);
                           }
                           WebComp_Relacionessolicitudesrelacionwc_Component = OldRelacionessolicitudesrelacionwc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE8A2( )
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

      protected void PA8A2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "solicitudesview.aspx")), "solicitudesview.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "solicitudesview.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "SolicitudesID");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV10SolicitudesID = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV10SolicitudesID", StringUtil.LTrimStr( (decimal)(AV10SolicitudesID), 18, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         RF8A2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF8A2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Generalwc_Component) != 0 )
               {
                  WebComp_Generalwc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Solicitudesrelacionwc_Component) != 0 )
               {
                  WebComp_Solicitudesrelacionwc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Itemswc_Component) != 0 )
               {
                  WebComp_Itemswc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Relacionessolicitudesrelacionwc_Component) != 0 )
               {
                  WebComp_Relacionessolicitudesrelacionwc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H008A2 */
            pr_default.execute(0, new Object[] {AV10SolicitudesID});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A127SolicitudesID = H008A2_A127SolicitudesID[0];
               A171SolicitudesNombre = H008A2_A171SolicitudesNombre[0];
               AssignAttri("", false, "A171SolicitudesNombre", A171SolicitudesNombre);
               /* Execute user event: Load */
               E138A2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB8A0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes8A2( )
      {
      }

      protected void before_start_formulas( )
      {
         edtSolicitudesNombre_Enabled = 0;
         AssignProp("", false, edtSolicitudesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesNombre_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP8A0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E128A2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Tabs_Activepagecontrolname = cgiGet( "TABS_Activepagecontrolname");
            Tabs_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "TABS_Pagecount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Tabs_Class = cgiGet( "TABS_Class");
            Tabs_Historymanagement = StringUtil.StrToBool( cgiGet( "TABS_Historymanagement"));
            Tabs_Activepagecontrolname = cgiGet( "TABS_Activepagecontrolname");
            /* Read variables values. */
            A171SolicitudesNombre = cgiGet( edtSolicitudesNombre_Internalname);
            AssignAttri("", false, "A171SolicitudesNombre", A171SolicitudesNombre);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"SolicitudesView");
            A171SolicitudesNombre = cgiGet( edtSolicitudesNombre_Internalname);
            AssignAttri("", false, "A171SolicitudesNombre", A171SolicitudesNombre);
            forbiddenHiddens.Add("SolicitudesNombre", StringUtil.RTrim( context.localUtil.Format( A171SolicitudesNombre, "")));
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("solicitudesview:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusDescription = 403.ToString();
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
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
         E128A2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E128A2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         AV16GXLvl8 = 0;
         /* Using cursor H008A3 */
         pr_default.execute(1, new Object[] {AV10SolicitudesID});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A127SolicitudesID = H008A3_A127SolicitudesID[0];
            A171SolicitudesNombre = H008A3_A171SolicitudesNombre[0];
            AssignAttri("", false, "A171SolicitudesNombre", A171SolicitudesNombre);
            AV16GXLvl8 = 1;
            Form.Caption = A171SolicitudesNombre;
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            AV9Exists = true;
            GXt_boolean1 = AV15TempBoolean;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSolicitudesRelacion", out  GXt_boolean1) ;
            AV15TempBoolean = GXt_boolean1;
            if ( AV15TempBoolean )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "solicitudesrelacionview.aspx"+UrlEncode(StringUtil.LTrimStr(A127SolicitudesID,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
               edtSolicitudesNombre_Link = formatLink("solicitudesrelacionview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
               AssignProp("", false, edtSolicitudesNombre_Internalname, "Link", edtSolicitudesNombre_Link, true);
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         if ( AV16GXLvl8 == 0 )
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
            /* Execute user subroutine: 'LOADTABS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E138A2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void E118A2( )
      {
         /* Tabs_Tabchanged Routine */
         returnInSub = false;
         AV12SelectedTabCode = Tabs_Activepagecontrolname;
         AssignAttri("", false, "AV12SelectedTabCode", AV12SelectedTabCode);
         AV11LoadAllTabs = false;
         AssignAttri("", false, "AV11LoadAllTabs", AV11LoadAllTabs);
         /* Execute user subroutine: 'LOADTABS' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'LOADTABS' Routine */
         returnInSub = false;
         /* Using cursor H008A4 */
         pr_default.execute(2, new Object[] {AV10SolicitudesID});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A127SolicitudesID = H008A4_A127SolicitudesID[0];
            if ( AV11LoadAllTabs || ( StringUtil.StrCmp(AV12SelectedTabCode, "") == 0 ) || ( StringUtil.StrCmp(AV12SelectedTabCode, "General") == 0 ) )
            {
               /* Object Property */
               if ( true )
               {
                  bDynCreated_Generalwc = true;
               }
               if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Generalwc_Component), StringUtil.Lower( "SolicitudesGeneral")) != 0 )
               {
                  WebComp_Generalwc = getWebComponent(GetType(), "GeneXus.Programs", "solicitudesgeneral", new Object[] {context} );
                  WebComp_Generalwc.ComponentInit();
                  WebComp_Generalwc.Name = "SolicitudesGeneral";
                  WebComp_Generalwc_Component = "SolicitudesGeneral";
               }
               if ( StringUtil.Len( WebComp_Generalwc_Component) != 0 )
               {
                  WebComp_Generalwc.setjustcreated();
                  WebComp_Generalwc.componentprepare(new Object[] {(string)"W0024",(string)"",(long)AV10SolicitudesID});
                  WebComp_Generalwc.componentbind(new Object[] {(string)""});
               }
               if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Generalwc )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0024"+"");
                  WebComp_Generalwc.componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
            GXt_boolean1 = AV15TempBoolean;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSolicitudesRelacion", out  GXt_boolean1) ;
            AV15TempBoolean = GXt_boolean1;
            if ( AV15TempBoolean )
            {
               if ( AV11LoadAllTabs || ( StringUtil.StrCmp(AV12SelectedTabCode, "SolicitudesRelacion") == 0 ) )
               {
                  /* Object Property */
                  if ( true )
                  {
                     bDynCreated_Solicitudesrelacionwc = true;
                  }
                  if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Solicitudesrelacionwc_Component), StringUtil.Lower( "SolicitudesSolicitudesRelacion")) != 0 )
                  {
                     WebComp_Solicitudesrelacionwc = getWebComponent(GetType(), "GeneXus.Programs", "solicitudessolicitudesrelacion", new Object[] {context} );
                     WebComp_Solicitudesrelacionwc.ComponentInit();
                     WebComp_Solicitudesrelacionwc.Name = "SolicitudesSolicitudesRelacion";
                     WebComp_Solicitudesrelacionwc_Component = "SolicitudesSolicitudesRelacion";
                  }
                  if ( StringUtil.Len( WebComp_Solicitudesrelacionwc_Component) != 0 )
                  {
                     WebComp_Solicitudesrelacionwc.setjustcreated();
                     WebComp_Solicitudesrelacionwc.componentprepare(new Object[] {(string)"W0032",(string)"",(long)AV10SolicitudesID});
                     WebComp_Solicitudesrelacionwc.componentbind(new Object[] {(string)""});
                  }
                  if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Solicitudesrelacionwc )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0032"+"");
                     WebComp_Solicitudesrelacionwc.componentdraw();
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
            }
            else
            {
               this.executeUsercontrolMethod("", false, "TABSContainer", "HideTab", "", new Object[] {(short)2});
            }
            if ( AV11LoadAllTabs || ( StringUtil.StrCmp(AV12SelectedTabCode, "Items") == 0 ) )
            {
               /* Object Property */
               if ( true )
               {
                  bDynCreated_Itemswc = true;
               }
               if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Itemswc_Component), StringUtil.Lower( "SolicitudesItemsWC")) != 0 )
               {
                  WebComp_Itemswc = getWebComponent(GetType(), "GeneXus.Programs", "solicitudesitemswc", new Object[] {context} );
                  WebComp_Itemswc.ComponentInit();
                  WebComp_Itemswc.Name = "SolicitudesItemsWC";
                  WebComp_Itemswc_Component = "SolicitudesItemsWC";
               }
               if ( StringUtil.Len( WebComp_Itemswc_Component) != 0 )
               {
                  WebComp_Itemswc.setjustcreated();
                  WebComp_Itemswc.componentprepare(new Object[] {(string)"W0040",(string)"",(long)AV10SolicitudesID});
                  WebComp_Itemswc.componentbind(new Object[] {(string)""});
               }
               if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Itemswc )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0040"+"");
                  WebComp_Itemswc.componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
            GXt_boolean1 = AV15TempBoolean;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSolicitudesRelacion", out  GXt_boolean1) ;
            AV15TempBoolean = GXt_boolean1;
            if ( AV15TempBoolean )
            {
               if ( AV11LoadAllTabs || ( StringUtil.StrCmp(AV12SelectedTabCode, "RelacionesSolicitudesRelacion") == 0 ) )
               {
                  /* Object Property */
                  if ( true )
                  {
                     bDynCreated_Relacionessolicitudesrelacionwc = true;
                  }
                  if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Relacionessolicitudesrelacionwc_Component), StringUtil.Lower( "SolicitudesRelacionesSolicitudesRelacionWC")) != 0 )
                  {
                     WebComp_Relacionessolicitudesrelacionwc = getWebComponent(GetType(), "GeneXus.Programs", "solicitudesrelacionessolicitudesrelacionwc", new Object[] {context} );
                     WebComp_Relacionessolicitudesrelacionwc.ComponentInit();
                     WebComp_Relacionessolicitudesrelacionwc.Name = "SolicitudesRelacionesSolicitudesRelacionWC";
                     WebComp_Relacionessolicitudesrelacionwc_Component = "SolicitudesRelacionesSolicitudesRelacionWC";
                  }
                  if ( StringUtil.Len( WebComp_Relacionessolicitudesrelacionwc_Component) != 0 )
                  {
                     WebComp_Relacionessolicitudesrelacionwc.setjustcreated();
                     WebComp_Relacionessolicitudesrelacionwc.componentprepare(new Object[] {(string)"W0048",(string)"",(long)AV10SolicitudesID});
                     WebComp_Relacionessolicitudesrelacionwc.componentbind(new Object[] {(string)""});
                  }
                  if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Relacionessolicitudesrelacionwc )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0048"+"");
                     WebComp_Relacionessolicitudesrelacionwc.componentdraw();
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
            }
            else
            {
               this.executeUsercontrolMethod("", false, "TABSContainer", "HideTab", "", new Object[] {(short)4});
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
         AV10SolicitudesID = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV10SolicitudesID", StringUtil.LTrimStr( (decimal)(AV10SolicitudesID), 18, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         PA8A2( ) ;
         WS8A2( ) ;
         WE8A2( ) ;
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
         if ( ! ( WebComp_Generalwc == null ) )
         {
            if ( StringUtil.Len( WebComp_Generalwc_Component) != 0 )
            {
               WebComp_Generalwc.componentthemes();
            }
         }
         if ( ! ( WebComp_Solicitudesrelacionwc == null ) )
         {
            if ( StringUtil.Len( WebComp_Solicitudesrelacionwc_Component) != 0 )
            {
               WebComp_Solicitudesrelacionwc.componentthemes();
            }
         }
         if ( ! ( WebComp_Itemswc == null ) )
         {
            if ( StringUtil.Len( WebComp_Itemswc_Component) != 0 )
            {
               WebComp_Itemswc.componentthemes();
            }
         }
         if ( ! ( WebComp_Relacionessolicitudesrelacionwc == null ) )
         {
            if ( StringUtil.Len( WebComp_Relacionessolicitudesrelacionwc_Component) != 0 )
            {
               WebComp_Relacionessolicitudesrelacionwc.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021214053", true, true, false);
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
         context.AddJavascriptSource("solicitudesview.js", "?202673021214054", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true, false);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtSolicitudesNombre_Internalname = "SOLICITUDESNOMBRE";
         lblGeneral_title_Internalname = "GENERAL_TITLE";
         divUnnamedtablegeneral_Internalname = "UNNAMEDTABLEGENERAL";
         lblSolicitudesrelacion_title_Internalname = "SOLICITUDESRELACION_TITLE";
         divUnnamedtablesolicitudesrelacion_Internalname = "UNNAMEDTABLESOLICITUDESRELACION";
         lblItems_title_Internalname = "ITEMS_TITLE";
         divUnnamedtableitems_Internalname = "UNNAMEDTABLEITEMS";
         lblRelacionessolicitudesrelacion_title_Internalname = "RELACIONESSOLICITUDESRELACION_TITLE";
         divUnnamedtablerelacionessolicitudesrelacion_Internalname = "UNNAMEDTABLERELACIONESSOLICITUDESRELACION";
         Tabs_Internalname = "TABS";
         divUnnamedtableviewcontainer_Internalname = "UNNAMEDTABLEVIEWCONTAINER";
         divTablemain_Internalname = "TABLEMAIN";
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
         edtSolicitudesNombre_Jsonclick = "";
         edtSolicitudesNombre_Link = "";
         edtSolicitudesNombre_Enabled = 0;
         Tabs_Historymanagement = Convert.ToBoolean( -1);
         Tabs_Class = "ViewTab Tab";
         Tabs_Pagecount = 4;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Solicitudes View", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV10SolicitudesID',fld:'vSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV8TabCode',fld:'vTABCODE',pic:'',hsh:true,type:'char'},{av:'A171SolicitudesNombre',fld:'SOLICITUDESNOMBRE',pic:'',type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("TABS.TABCHANGED","{handler:'E118A2',iparms:[{av:'Tabs_Activepagecontrolname',ctrl:'TABS',prop:'ActivePageControlName'},{av:'A127SolicitudesID',fld:'SOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV10SolicitudesID',fld:'vSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV11LoadAllTabs',fld:'vLOADALLTABS',pic:'',type:'boolean'},{av:'AV12SelectedTabCode',fld:'vSELECTEDTABCODE',pic:'',type:'char'}]");
         setEventMetadata("TABS.TABCHANGED",",oparms:[{av:'AV12SelectedTabCode',fld:'vSELECTEDTABCODE',pic:'',type:'char'},{av:'AV11LoadAllTabs',fld:'vLOADALLTABS',pic:'',type:'boolean'},{ctrl:'GENERALWC'},{ctrl:'SOLICITUDESRELACIONWC'},{ctrl:'ITEMSWC'},{ctrl:'RELACIONESSOLICITUDESRELACIONWC'}]}");
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
         forbiddenHiddens = new GXProperties();
         A171SolicitudesNombre = "";
         AV12SelectedTabCode = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ucTabs = new GXUserControl();
         lblGeneral_title_Jsonclick = "";
         WebComp_Generalwc_Component = "";
         OldGeneralwc = "";
         lblSolicitudesrelacion_title_Jsonclick = "";
         WebComp_Solicitudesrelacionwc_Component = "";
         OldSolicitudesrelacionwc = "";
         lblItems_title_Jsonclick = "";
         WebComp_Itemswc_Component = "";
         OldItemswc = "";
         lblRelacionessolicitudesrelacion_title_Jsonclick = "";
         WebComp_Relacionessolicitudesrelacionwc_Component = "";
         OldRelacionessolicitudesrelacionwc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H008A2_A127SolicitudesID = new long[1] ;
         H008A2_A171SolicitudesNombre = new string[] {""} ;
         hsh = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         H008A3_A127SolicitudesID = new long[1] ;
         H008A3_A171SolicitudesNombre = new string[] {""} ;
         H008A4_A127SolicitudesID = new long[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.solicitudesview__default(),
            new Object[][] {
                new Object[] {
               H008A2_A127SolicitudesID, H008A2_A171SolicitudesNombre
               }
               , new Object[] {
               H008A3_A127SolicitudesID, H008A3_A171SolicitudesNombre
               }
               , new Object[] {
               H008A4_A127SolicitudesID
               }
            }
         );
         WebComp_Generalwc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Solicitudesrelacionwc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Itemswc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Relacionessolicitudesrelacionwc = new GeneXus.Http.GXNullWebComponent();
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
      private short AV16GXLvl8 ;
      private short nGXWrapped ;
      private int Tabs_Pagecount ;
      private int edtSolicitudesNombre_Enabled ;
      private int idxLst ;
      private long AV10SolicitudesID ;
      private long wcpOAV10SolicitudesID ;
      private long A127SolicitudesID ;
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
      private string A171SolicitudesNombre ;
      private string AV12SelectedTabCode ;
      private string Tabs_Class ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string edtSolicitudesNombre_Internalname ;
      private string TempTags ;
      private string edtSolicitudesNombre_Link ;
      private string edtSolicitudesNombre_Jsonclick ;
      private string divUnnamedtableviewcontainer_Internalname ;
      private string Tabs_Internalname ;
      private string lblGeneral_title_Internalname ;
      private string lblGeneral_title_Jsonclick ;
      private string divUnnamedtablegeneral_Internalname ;
      private string WebComp_Generalwc_Component ;
      private string OldGeneralwc ;
      private string lblSolicitudesrelacion_title_Internalname ;
      private string lblSolicitudesrelacion_title_Jsonclick ;
      private string divUnnamedtablesolicitudesrelacion_Internalname ;
      private string WebComp_Solicitudesrelacionwc_Component ;
      private string OldSolicitudesrelacionwc ;
      private string lblItems_title_Internalname ;
      private string lblItems_title_Jsonclick ;
      private string divUnnamedtableitems_Internalname ;
      private string WebComp_Itemswc_Component ;
      private string OldItemswc ;
      private string lblRelacionessolicitudesrelacion_title_Internalname ;
      private string lblRelacionessolicitudesrelacion_title_Jsonclick ;
      private string divUnnamedtablerelacionessolicitudesrelacion_Internalname ;
      private string WebComp_Relacionessolicitudesrelacionwc_Component ;
      private string OldRelacionessolicitudesrelacionwc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string hsh ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV11LoadAllTabs ;
      private bool Tabs_Historymanagement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV9Exists ;
      private bool AV15TempBoolean ;
      private bool bDynCreated_Generalwc ;
      private bool bDynCreated_Solicitudesrelacionwc ;
      private bool bDynCreated_Itemswc ;
      private bool GXt_boolean1 ;
      private bool bDynCreated_Relacionessolicitudesrelacionwc ;
      private GXWebComponent WebComp_Generalwc ;
      private GXWebComponent WebComp_Solicitudesrelacionwc ;
      private GXWebComponent WebComp_Itemswc ;
      private GXWebComponent WebComp_Relacionessolicitudesrelacionwc ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucTabs ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] H008A2_A127SolicitudesID ;
      private string[] H008A2_A171SolicitudesNombre ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private long[] H008A3_A127SolicitudesID ;
      private string[] H008A3_A171SolicitudesNombre ;
      private long[] H008A4_A127SolicitudesID ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class solicitudesview__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH008A2;
          prmH008A2 = new Object[] {
          new ParDef("@AV10SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmH008A3;
          prmH008A3 = new Object[] {
          new ParDef("@AV10SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmH008A4;
          prmH008A4 = new Object[] {
          new ParDef("@AV10SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("H008A2", "SELECT [SolicitudesID], [SolicitudesNombre] FROM [Solicitudes] WHERE [SolicitudesID] = @AV10SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008A2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H008A3", "SELECT [SolicitudesID], [SolicitudesNombre] FROM [Solicitudes] WHERE [SolicitudesID] = @AV10SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008A3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H008A4", "SELECT [SolicitudesID] FROM [Solicitudes] WHERE [SolicitudesID] = @AV10SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008A4,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
