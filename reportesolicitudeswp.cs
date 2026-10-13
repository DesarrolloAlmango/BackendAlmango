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
   public class reportesolicitudeswp : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public reportesolicitudeswp( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reportesolicitudeswp( IGxContext context )
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
         cmbavEstadosgenericosid = new GXCombobox();
         radavFechafiltro = new GXRadio();
         chkavSino = new GXCheckbox();
         cmbavOrigendepago = new GXCombobox();
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
         PA7W2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START7W2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("Toastr/toastr.min.js", "", false, true, false);
         context.AddJavascriptSource("Toastr/ToastrRender.js", "", false, true, false);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("reportesolicitudeswp.aspx") +"\">") ;
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
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV22DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV22DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROVEEDORID_DATA", AV21ProveedorID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROVEEDORID_DATA", AV21ProveedorID_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSECUSERID_DATA", AV27SecUserId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSECUSERID_DATA", AV27SecUserId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROVEEDORID", AV10ProveedorID);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROVEEDORID", AV10ProveedorID);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSECUSERID", AV16SecUserId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSECUSERID", AV16SecUserId);
         }
         GxWebStd.gx_hidden_field( context, "vSECUSERIDJSON", AV28SecUserIdJson);
         GxWebStd.gx_hidden_field( context, "vSTRING", StringUtil.RTrim( AV24String));
         GxWebStd.gx_hidden_field( context, "COMBO_PROVEEDORID_Cls", StringUtil.RTrim( Combo_proveedorid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PROVEEDORID_Selectedvalue_set", StringUtil.RTrim( Combo_proveedorid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROVEEDORID_Allowmultipleselection", StringUtil.BoolToStr( Combo_proveedorid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "COMBO_PROVEEDORID_Includeonlyselectedoption", StringUtil.BoolToStr( Combo_proveedorid_Includeonlyselectedoption));
         GxWebStd.gx_hidden_field( context, "COMBO_PROVEEDORID_Htmltemplate", StringUtil.RTrim( Combo_proveedorid_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "COMBO_PROVEEDORID_Multiplevaluestype", StringUtil.RTrim( Combo_proveedorid_Multiplevaluestype));
         GxWebStd.gx_hidden_field( context, "COMBO_PROVEEDORID_Emptyitemtext", StringUtil.RTrim( Combo_proveedorid_Emptyitemtext));
         GxWebStd.gx_hidden_field( context, "COMBO_SECUSERID_Cls", StringUtil.RTrim( Combo_secuserid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_SECUSERID_Selectedvalue_set", StringUtil.RTrim( Combo_secuserid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_SECUSERID_Allowmultipleselection", StringUtil.BoolToStr( Combo_secuserid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "COMBO_SECUSERID_Includeonlyselectedoption", StringUtil.BoolToStr( Combo_secuserid_Includeonlyselectedoption));
         GxWebStd.gx_hidden_field( context, "COMBO_SECUSERID_Multiplevaluestype", StringUtil.RTrim( Combo_secuserid_Multiplevaluestype));
         GxWebStd.gx_hidden_field( context, "COMBO_SECUSERID_Emptyitemtext", StringUtil.RTrim( Combo_secuserid_Emptyitemtext));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Width", StringUtil.RTrim( Dvpanel_unnamedtable1_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Cls", StringUtil.RTrim( Dvpanel_unnamedtable1_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Title", StringUtil.RTrim( Dvpanel_unnamedtable1_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable1_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Autoscroll));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Target", StringUtil.RTrim( Innewwindow1_Target));
         GxWebStd.gx_hidden_field( context, "COMBO_SECUSERID_Selectedvalue_get", StringUtil.RTrim( Combo_secuserid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_PROVEEDORID_Selectedvalue_get", StringUtil.RTrim( Combo_proveedorid_Selectedvalue_get));
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
            WE7W2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT7W2( ) ;
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
         return formatLink("reportesolicitudeswp.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ReporteSolicitudesWP" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Reporte Solicitudes ", "") ;
      }

      protected void WB7W0( )
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
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_unnamedtable1.SetProperty("Width", Dvpanel_unnamedtable1_Width);
            ucDvpanel_unnamedtable1.SetProperty("AutoWidth", Dvpanel_unnamedtable1_Autowidth);
            ucDvpanel_unnamedtable1.SetProperty("AutoHeight", Dvpanel_unnamedtable1_Autoheight);
            ucDvpanel_unnamedtable1.SetProperty("Cls", Dvpanel_unnamedtable1_Cls);
            ucDvpanel_unnamedtable1.SetProperty("Title", Dvpanel_unnamedtable1_Title);
            ucDvpanel_unnamedtable1.SetProperty("Collapsible", Dvpanel_unnamedtable1_Collapsible);
            ucDvpanel_unnamedtable1.SetProperty("Collapsed", Dvpanel_unnamedtable1_Collapsed);
            ucDvpanel_unnamedtable1.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable1_Showcollapseicon);
            ucDvpanel_unnamedtable1.SetProperty("IconPosition", Dvpanel_unnamedtable1_Iconposition);
            ucDvpanel_unnamedtable1.SetProperty("AutoScroll", Dvpanel_unnamedtable1_Autoscroll);
            ucDvpanel_unnamedtable1.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable1_Internalname, "DVPANEL_UNNAMEDTABLE1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_UNNAMEDTABLE1Container"+"UnnamedTable1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable9_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedproveedorid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_proveedorid_Internalname, context.GetMessage( "Proveedor:", ""), "", "", lblTextblockcombo_proveedorid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_ReporteSolicitudesWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_proveedorid.SetProperty("Caption", Combo_proveedorid_Caption);
            ucCombo_proveedorid.SetProperty("Cls", Combo_proveedorid_Cls);
            ucCombo_proveedorid.SetProperty("AllowMultipleSelection", Combo_proveedorid_Allowmultipleselection);
            ucCombo_proveedorid.SetProperty("IncludeOnlySelectedOption", Combo_proveedorid_Includeonlyselectedoption);
            ucCombo_proveedorid.SetProperty("MultipleValuesType", Combo_proveedorid_Multiplevaluestype);
            ucCombo_proveedorid.SetProperty("EmptyItemText", Combo_proveedorid_Emptyitemtext);
            ucCombo_proveedorid.SetProperty("DropDownOptionsTitleSettingsIcons", AV22DDO_TitleSettingsIcons);
            ucCombo_proveedorid.SetProperty("DropDownOptionsData", AV21ProveedorID_Data);
            ucCombo_proveedorid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_proveedorid_Internalname, "COMBO_PROVEEDORIDContainer");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavEstadosgenericosid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavEstadosgenericosid_Internalname, context.GetMessage( "Clasificación:", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavEstadosgenericosid, cmbavEstadosgenericosid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV7EstadosGenericosID), 5, 0)), 1, cmbavEstadosgenericosid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavEstadosgenericosid.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 0, "HLP_ReporteSolicitudesWP.htm");
            cmbavEstadosgenericosid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7EstadosGenericosID), 5, 0));
            AssignProp("", false, cmbavEstadosgenericosid_Internalname, "Values", (string)(cmbavEstadosgenericosid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 col-sm-5", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+radavFechafiltro_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Radio button */
            ClassString = "AttributeFL";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavFechafiltro, radavFechafiltro_Internalname, StringUtil.RTrim( AV26FechaFiltro), "", 1, 1, 1, 1, StyleString, ClassString, "", "", 0, radavFechafiltro_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "HLP_ReporteSolicitudesWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFechaini_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFechaini_Internalname, context.GetMessage( "Fecha Inicio:", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFechaini_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFechaini_Internalname, context.localUtil.Format(AV9FechaIni, "99/99/99"), context.localUtil.Format( AV9FechaIni, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFechaini_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFechaini_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ReporteSolicitudesWP.htm");
            GxWebStd.gx_bitmap( context, edtavFechaini_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFechaini_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_ReporteSolicitudesWP.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFechafin_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFechafin_Internalname, context.GetMessage( "Fecha Fin:", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFechafin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFechafin_Internalname, context.localUtil.Format(AV8fechafin, "99/99/99"), context.localUtil.Format( AV8fechafin, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFechafin_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFechafin_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ReporteSolicitudesWP.htm");
            GxWebStd.gx_bitmap( context, edtavFechafin_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFechafin_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_ReporteSolicitudesWP.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavBusdireccion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBusdireccion_Internalname, context.GetMessage( "Dirección:", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBusdireccion_Internalname, StringUtil.RTrim( AV5BusDireccion), StringUtil.RTrim( context.localUtil.Format( AV5BusDireccion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBusdireccion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavBusdireccion_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Direccion", "start", true, "", "HLP_ReporteSolicitudesWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnxls_Internalname, "", context.GetMessage( "Exporta a Excel", ""), bttBtnxls_Jsonclick, 5, context.GetMessage( "Exporta a Excel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOXLS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReporteSolicitudesWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavSino_Internalname, context.GetMessage( "Si No", ""), "col-sm-3 CardDescriptionLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
            ClassString = "CardDescription";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavSino_Internalname, StringUtil.BoolToStr( AV11SiNo), "", context.GetMessage( "Si No", ""), 1, chkavSino.Enabled, "true", context.GetMessage( "Proveedor Auxiliar", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(50, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,50);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, context.GetMessage( "Comisiones", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_ReporteSolicitudesWP.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTbcomisiones_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavOrigendepago_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavOrigendepago_Internalname, context.GetMessage( "ORIGEN DE PAGO", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavOrigendepago, cmbavOrigendepago_Internalname, StringUtil.RTrim( AV15OrigenDePago), 1, cmbavOrigendepago_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavOrigendepago.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "", true, 0, "HLP_ReporteSolicitudesWP.htm");
            cmbavOrigendepago.CurrentValue = StringUtil.RTrim( AV15OrigenDePago);
            AssignProp("", false, cmbavOrigendepago_Internalname, "Values", (string)(cmbavOrigendepago.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedsecuserid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_secuserid_Internalname, context.GetMessage( "Usuario de Alta", ""), "", "", lblTextblockcombo_secuserid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_ReporteSolicitudesWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_secuserid.SetProperty("Caption", Combo_secuserid_Caption);
            ucCombo_secuserid.SetProperty("Cls", Combo_secuserid_Cls);
            ucCombo_secuserid.SetProperty("AllowMultipleSelection", Combo_secuserid_Allowmultipleselection);
            ucCombo_secuserid.SetProperty("IncludeOnlySelectedOption", Combo_secuserid_Includeonlyselectedoption);
            ucCombo_secuserid.SetProperty("MultipleValuesType", Combo_secuserid_Multiplevaluestype);
            ucCombo_secuserid.SetProperty("EmptyItemText", Combo_secuserid_Emptyitemtext);
            ucCombo_secuserid.SetProperty("DropDownOptionsTitleSettingsIcons", AV22DDO_TitleSettingsIcons);
            ucCombo_secuserid.SetProperty("DropDownOptionsData", AV27SecUserId_Data);
            ucCombo_secuserid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_secuserid_Internalname, "COMBO_SECUSERIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncomisionesexcel_Internalname, "", context.GetMessage( "Comisiones Excel", ""), bttBtncomisionesexcel_Jsonclick, 5, context.GetMessage( "Comisiones Excel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOCOMISIONESEXCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReporteSolicitudesWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncomisionespdf_Internalname, "", context.GetMessage( "Comisiones PDF", ""), bttBtncomisionespdf_Jsonclick, 7, context.GetMessage( "Comisiones PDF", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e117w1_client"+"'", TempTags, "", 2, "HLP_ReporteSolicitudesWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* User Defined Control */
            ucToastr1.Render(context, "toastr", Toastr1_Internalname, "TOASTR1Container");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, "INNEWWINDOW1Container");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucInnewwindow2.Render(context, "innewwindow", Innewwindow2_Internalname, "INNEWWINDOW2Container");
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

      protected void START7W2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Reporte Solicitudes ", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP7W0( ) ;
      }

      protected void WS7W2( )
      {
         START7W2( ) ;
         EVT7W2( ) ;
      }

      protected void EVT7W2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E127W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOXLS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoXLS' */
                              E137W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCOMISIONESEXCEL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoComisionesExcel' */
                              E147W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E157W2 ();
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE7W2( )
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

      protected void PA7W2( )
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
               GX_FocusControl = cmbavEstadosgenericosid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
         if ( cmbavEstadosgenericosid.ItemCount > 0 )
         {
            AV7EstadosGenericosID = (int)(Math.Round(NumberUtil.Val( cmbavEstadosgenericosid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7EstadosGenericosID), 5, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV7EstadosGenericosID", StringUtil.LTrimStr( (decimal)(AV7EstadosGenericosID), 5, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavEstadosgenericosid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7EstadosGenericosID), 5, 0));
            AssignProp("", false, cmbavEstadosgenericosid_Internalname, "Values", cmbavEstadosgenericosid.ToJavascriptSource(), true);
         }
         AssignAttri("", false, "AV26FechaFiltro", AV26FechaFiltro);
         AV11SiNo = StringUtil.StrToBool( StringUtil.BoolToStr( AV11SiNo));
         AssignAttri("", false, "AV11SiNo", AV11SiNo);
         if ( cmbavOrigendepago.ItemCount > 0 )
         {
            AV15OrigenDePago = cmbavOrigendepago.getValidValue(AV15OrigenDePago);
            AssignAttri("", false, "AV15OrigenDePago", AV15OrigenDePago);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavOrigendepago.CurrentValue = StringUtil.RTrim( AV15OrigenDePago);
            AssignProp("", false, cmbavOrigendepago_Internalname, "Values", cmbavOrigendepago.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF7W2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF7W2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E157W2 ();
            WB7W0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes7W2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7W0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E127W2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV22DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vPROVEEDORID_DATA"), AV21ProveedorID_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vSECUSERID_DATA"), AV27SecUserId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vPROVEEDORID"), AV10ProveedorID);
            ajax_req_read_hidden_sdt(cgiGet( "vSECUSERID"), AV16SecUserId);
            /* Read saved values. */
            AV28SecUserIdJson = cgiGet( "vSECUSERIDJSON");
            AV24String = cgiGet( "vSTRING");
            Combo_proveedorid_Cls = cgiGet( "COMBO_PROVEEDORID_Cls");
            Combo_proveedorid_Selectedvalue_set = cgiGet( "COMBO_PROVEEDORID_Selectedvalue_set");
            Combo_proveedorid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_PROVEEDORID_Allowmultipleselection"));
            Combo_proveedorid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_PROVEEDORID_Includeonlyselectedoption"));
            Combo_proveedorid_Htmltemplate = cgiGet( "COMBO_PROVEEDORID_Htmltemplate");
            Combo_proveedorid_Multiplevaluestype = cgiGet( "COMBO_PROVEEDORID_Multiplevaluestype");
            Combo_proveedorid_Emptyitemtext = cgiGet( "COMBO_PROVEEDORID_Emptyitemtext");
            Combo_secuserid_Cls = cgiGet( "COMBO_SECUSERID_Cls");
            Combo_secuserid_Selectedvalue_set = cgiGet( "COMBO_SECUSERID_Selectedvalue_set");
            Combo_secuserid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_SECUSERID_Allowmultipleselection"));
            Combo_secuserid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_SECUSERID_Includeonlyselectedoption"));
            Combo_secuserid_Multiplevaluestype = cgiGet( "COMBO_SECUSERID_Multiplevaluestype");
            Combo_secuserid_Emptyitemtext = cgiGet( "COMBO_SECUSERID_Emptyitemtext");
            Dvpanel_unnamedtable1_Width = cgiGet( "DVPANEL_UNNAMEDTABLE1_Width");
            Dvpanel_unnamedtable1_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Autowidth"));
            Dvpanel_unnamedtable1_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Autoheight"));
            Dvpanel_unnamedtable1_Cls = cgiGet( "DVPANEL_UNNAMEDTABLE1_Cls");
            Dvpanel_unnamedtable1_Title = cgiGet( "DVPANEL_UNNAMEDTABLE1_Title");
            Dvpanel_unnamedtable1_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Collapsible"));
            Dvpanel_unnamedtable1_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Collapsed"));
            Dvpanel_unnamedtable1_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Showcollapseicon"));
            Dvpanel_unnamedtable1_Iconposition = cgiGet( "DVPANEL_UNNAMEDTABLE1_Iconposition");
            Dvpanel_unnamedtable1_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Autoscroll"));
            Innewwindow1_Target = cgiGet( "INNEWWINDOW1_Target");
            /* Read variables values. */
            cmbavEstadosgenericosid.CurrentValue = cgiGet( cmbavEstadosgenericosid_Internalname);
            AV7EstadosGenericosID = (int)(Math.Round(NumberUtil.Val( cgiGet( cmbavEstadosgenericosid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV7EstadosGenericosID", StringUtil.LTrimStr( (decimal)(AV7EstadosGenericosID), 5, 0));
            AV26FechaFiltro = cgiGet( radavFechafiltro_Internalname);
            AssignAttri("", false, "AV26FechaFiltro", AV26FechaFiltro);
            if ( context.localUtil.VCDate( cgiGet( edtavFechaini_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Fecha Ini", "")}), 1, "vFECHAINI");
               GX_FocusControl = edtavFechaini_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9FechaIni = DateTime.MinValue;
               AssignAttri("", false, "AV9FechaIni", context.localUtil.Format(AV9FechaIni, "99/99/99"));
            }
            else
            {
               AV9FechaIni = context.localUtil.CToD( cgiGet( edtavFechaini_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV9FechaIni", context.localUtil.Format(AV9FechaIni, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavFechafin_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "fechafin", "")}), 1, "vFECHAFIN");
               GX_FocusControl = edtavFechafin_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8fechafin = DateTime.MinValue;
               AssignAttri("", false, "AV8fechafin", context.localUtil.Format(AV8fechafin, "99/99/99"));
            }
            else
            {
               AV8fechafin = context.localUtil.CToD( cgiGet( edtavFechafin_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV8fechafin", context.localUtil.Format(AV8fechafin, "99/99/99"));
            }
            AV5BusDireccion = cgiGet( edtavBusdireccion_Internalname);
            AssignAttri("", false, "AV5BusDireccion", AV5BusDireccion);
            AV11SiNo = StringUtil.StrToBool( cgiGet( chkavSino_Internalname));
            AssignAttri("", false, "AV11SiNo", AV11SiNo);
            cmbavOrigendepago.CurrentValue = cgiGet( cmbavOrigendepago_Internalname);
            AV15OrigenDePago = cgiGet( cmbavOrigendepago_Internalname);
            AssignAttri("", false, "AV15OrigenDePago", AV15OrigenDePago);
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
         E127W2 ();
         if (returnInSub) return;
      }

      protected void E127W2( )
      {
         /* Start Routine */
         returnInSub = false;
         new loadcontext(context ).execute( out  AV6Context) ;
         AV8fechafin = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         AssignAttri("", false, "AV8fechafin", context.localUtil.Format(AV8fechafin, "99/99/99"));
         AV9FechaIni = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         AssignAttri("", false, "AV9FechaIni", context.localUtil.Format(AV9FechaIni, "99/99/99"));
         AV8fechafin = DateTimeUtil.DAdd(AV8fechafin,+((int)(15)));
         AssignAttri("", false, "AV8fechafin", context.localUtil.Format(AV8fechafin, "99/99/99"));
         AV9FechaIni = DateTimeUtil.DAdd(AV9FechaIni,-((int)(120)));
         AssignAttri("", false, "AV9FechaIni", context.localUtil.Format(AV9FechaIni, "99/99/99"));
         AV12visualizar = 0;
         AV26FechaFiltro = context.GetMessage( "Alta", "");
         AssignAttri("", false, "AV26FechaFiltro", AV26FechaFiltro);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV22DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV22DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and subtitle", out  GXt_char2) ;
         Combo_proveedorid_Htmltemplate = GXt_char2;
         ucCombo_proveedorid.SendProperty(context, "", false, Combo_proveedorid_Internalname, "HTMLTemplate", Combo_proveedorid_Htmltemplate);
         /* Execute user subroutine: 'LOADCOMBOPROVEEDORID' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOSECUSERID' */
         S122 ();
         if (returnInSub) return;
      }

      protected void E137W2( )
      {
         /* 'DoXLS' Routine */
         returnInSub = false;
         new reportesolicitudes(context ).execute(  AV10ProveedorID,  AV7EstadosGenericosID,  AV9FechaIni,  AV8fechafin,  AV26FechaFiltro,  AV5BusDireccion,  AV11SiNo) ;
      }

      protected void E147W2( )
      {
         /* 'DoComisionesExcel' Routine */
         returnInSub = false;
         AV28SecUserIdJson = AV16SecUserId.ToJSonString(false);
         new reportecomisionesalmgxls(context ).execute(  AV10ProveedorID,  AV7EstadosGenericosID,  AV9FechaIni,  AV8fechafin,  AV26FechaFiltro,  AV15OrigenDePago, ref  AV28SecUserIdJson) ;
      }

      protected void S122( )
      {
         /* 'LOADCOMBOSECUSERID' Routine */
         returnInSub = false;
         /* Using cursor H007W2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A550SecUserEstado = H007W2_A550SecUserEstado[0];
            n550SecUserEstado = H007W2_n550SecUserEstado[0];
            A18SecUserId = H007W2_A18SecUserId[0];
            A26SecUserName = H007W2_A26SecUserName[0];
            AV23Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV23Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A18SecUserId), 10, 0));
            AV23Combo_DataItem.gxTpr_Title = A26SecUserName;
            AV27SecUserId_Data.Add(AV23Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         Combo_secuserid_Selectedvalue_set = AV16SecUserId.ToJSonString(false);
         ucCombo_secuserid.SendProperty(context, "", false, Combo_secuserid_Internalname, "SelectedValue_set", Combo_secuserid_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'LOADCOMBOPROVEEDORID' Routine */
         returnInSub = false;
         /* Using cursor H007W3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A133ProveedorID = H007W3_A133ProveedorID[0];
            A344ProveedorEstado = H007W3_A344ProveedorEstado[0];
            A282ProveedorNombre = H007W3_A282ProveedorNombre[0];
            AV23Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV23Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0));
            AV20ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV20ComboTitles.Add(A282ProveedorNombre, 0);
            AV20ComboTitles.Add(StringUtil.Trim( context.GetMessage( gxdomainestadoenum.getDescription(context,A344ProveedorEstado), "")), 0);
            AV23Combo_DataItem.gxTpr_Title = AV20ComboTitles.ToJSonString(false);
            AV21ProveedorID_Data.Add(AV23Combo_DataItem, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         Combo_proveedorid_Selectedvalue_set = AV10ProveedorID.ToJSonString(false);
         ucCombo_proveedorid.SendProperty(context, "", false, Combo_proveedorid_Internalname, "SelectedValue_set", Combo_proveedorid_Selectedvalue_set);
      }

      protected void nextLoad( )
      {
      }

      protected void E157W2( )
      {
         /* Load Routine */
         returnInSub = false;
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
         PA7W2( ) ;
         WS7W2( ) ;
         WE7W2( ) ;
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
         AddStyleSheetFile("Toastr/toastr.min.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269320154295", true, true, false);
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
         context.AddJavascriptSource("reportesolicitudeswp.js", "?20269320154295", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("Toastr/toastr.min.js", "", false, true, false);
         context.AddJavascriptSource("Toastr/ToastrRender.js", "", false, true, false);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavEstadosgenericosid.Name = "vESTADOSGENERICOSID";
         cmbavEstadosgenericosid.WebTags = "";
         cmbavEstadosgenericosid.addItem("0", context.GetMessage( "Todas las Clasificaciones", ""), 0);
         cmbavEstadosgenericosid.addItem("8", context.GetMessage( "Habilitada", ""), 0);
         cmbavEstadosgenericosid.addItem("2", context.GetMessage( "Delegada", ""), 0);
         cmbavEstadosgenericosid.addItem("5", context.GetMessage( "Aceptada", ""), 0);
         cmbavEstadosgenericosid.addItem("6", context.GetMessage( "Finalizada y Calificada", ""), 0);
         cmbavEstadosgenericosid.addItem("7", context.GetMessage( "Calificada", ""), 0);
         cmbavEstadosgenericosid.addItem("3", context.GetMessage( "Cancelada", ""), 0);
         if ( cmbavEstadosgenericosid.ItemCount > 0 )
         {
            AV7EstadosGenericosID = (int)(Math.Round(NumberUtil.Val( cmbavEstadosgenericosid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7EstadosGenericosID), 5, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV7EstadosGenericosID", StringUtil.LTrimStr( (decimal)(AV7EstadosGenericosID), 5, 0));
         }
         radavFechafiltro.Name = "vFECHAFILTRO";
         radavFechafiltro.WebTags = "";
         radavFechafiltro.addItem("Alta", context.GetMessage( "Fecha Alta", ""), 0);
         radavFechafiltro.addItem("Trabajo", context.GetMessage( "Fecha Trabajo", ""), 0);
         chkavSino.Name = "vSINO";
         chkavSino.WebTags = "";
         chkavSino.Caption = context.GetMessage( "Si No", "");
         AssignProp("", false, chkavSino_Internalname, "TitleCaption", chkavSino.Caption, true);
         chkavSino.CheckedValue = "false";
         AV11SiNo = StringUtil.StrToBool( StringUtil.BoolToStr( AV11SiNo));
         AssignAttri("", false, "AV11SiNo", AV11SiNo);
         cmbavOrigendepago.Name = "vORIGENDEPAGO";
         cmbavOrigendepago.WebTags = "";
         cmbavOrigendepago.addItem("", context.GetMessage( "Todos", ""), 0);
         cmbavOrigendepago.addItem("F", context.GetMessage( "Cobro Directo", ""), 0);
         cmbavOrigendepago.addItem("T", context.GetMessage( "Cobro Prepago Comercio", ""), 0);
         cmbavOrigendepago.addItem("O", context.GetMessage( "Cobro Prepago Almango", ""), 0);
         if ( cmbavOrigendepago.ItemCount > 0 )
         {
            AV15OrigenDePago = cmbavOrigendepago.getValidValue(AV15OrigenDePago);
            AssignAttri("", false, "AV15OrigenDePago", AV15OrigenDePago);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblockcombo_proveedorid_Internalname = "TEXTBLOCKCOMBO_PROVEEDORID";
         Combo_proveedorid_Internalname = "COMBO_PROVEEDORID";
         divTablesplittedproveedorid_Internalname = "TABLESPLITTEDPROVEEDORID";
         cmbavEstadosgenericosid_Internalname = "vESTADOSGENERICOSID";
         radavFechafiltro_Internalname = "vFECHAFILTRO";
         edtavFechaini_Internalname = "vFECHAINI";
         edtavFechafin_Internalname = "vFECHAFIN";
         edtavBusdireccion_Internalname = "vBUSDIRECCION";
         bttBtnxls_Internalname = "BTNXLS";
         chkavSino_Internalname = "vSINO";
         cmbavOrigendepago_Internalname = "vORIGENDEPAGO";
         lblTextblockcombo_secuserid_Internalname = "TEXTBLOCKCOMBO_SECUSERID";
         Combo_secuserid_Internalname = "COMBO_SECUSERID";
         divTablesplittedsecuserid_Internalname = "TABLESPLITTEDSECUSERID";
         bttBtncomisionesexcel_Internalname = "BTNCOMISIONESEXCEL";
         bttBtncomisionespdf_Internalname = "BTNCOMISIONESPDF";
         divTbcomisiones_Internalname = "TBCOMISIONES";
         grpUnnamedgroup2_Internalname = "UNNAMEDGROUP2";
         divTable9_Internalname = "TABLE9";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Dvpanel_unnamedtable1_Internalname = "DVPANEL_UNNAMEDTABLE1";
         Toastr1_Internalname = "TOASTR1";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Innewwindow2_Internalname = "INNEWWINDOW2";
         divMaintable_Internalname = "MAINTABLE";
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
         chkavSino.Caption = context.GetMessage( "Si No", "");
         Combo_secuserid_Caption = "";
         cmbavOrigendepago_Jsonclick = "";
         cmbavOrigendepago.Enabled = 1;
         chkavSino.Enabled = 1;
         edtavBusdireccion_Jsonclick = "";
         edtavBusdireccion_Enabled = 1;
         edtavFechafin_Jsonclick = "";
         edtavFechafin_Enabled = 1;
         edtavFechaini_Jsonclick = "";
         edtavFechaini_Enabled = 1;
         radavFechafiltro_Jsonclick = "";
         cmbavEstadosgenericosid_Jsonclick = "";
         cmbavEstadosgenericosid.Enabled = 1;
         Combo_proveedorid_Caption = "";
         Innewwindow1_Target = "";
         Dvpanel_unnamedtable1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Iconposition = "Right";
         Dvpanel_unnamedtable1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable1_Title = context.GetMessage( "Filtros - Exportación de Solicitudes", "");
         Dvpanel_unnamedtable1_Cls = "PanelGrayBackgroundTitle";
         Dvpanel_unnamedtable1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Width = "100%";
         Combo_secuserid_Emptyitemtext = "Todos";
         Combo_secuserid_Multiplevaluestype = "Tags";
         Combo_secuserid_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_secuserid_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_secuserid_Cls = "ExtendedCombo AttributeFL";
         Combo_proveedorid_Emptyitemtext = "Todos los Proveedores";
         Combo_proveedorid_Multiplevaluestype = "Tags";
         Combo_proveedorid_Htmltemplate = "";
         Combo_proveedorid_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_proveedorid_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_proveedorid_Cls = "ExtendedCombo AttributeFL ExtendedComboTitleAndSubtitle";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Reporte Solicitudes ", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'radavFechafiltro'},{av:'AV26FechaFiltro',fld:'vFECHAFILTRO',pic:'',type:'svchar'},{av:'AV11SiNo',fld:'vSINO',pic:'',type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOXLS'","{handler:'E137W2',iparms:[{av:'AV10ProveedorID',fld:'vPROVEEDORID',pic:''},{av:'cmbavEstadosgenericosid'},{av:'AV7EstadosGenericosID',fld:'vESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'AV9FechaIni',fld:'vFECHAINI',pic:'',type:'date'},{av:'AV8fechafin',fld:'vFECHAFIN',pic:'',type:'date'},{av:'radavFechafiltro'},{av:'AV26FechaFiltro',fld:'vFECHAFILTRO',pic:'',type:'svchar'},{av:'AV5BusDireccion',fld:'vBUSDIRECCION',pic:'',type:'char'},{av:'AV11SiNo',fld:'vSINO',pic:'',type:'boolean'}]");
         setEventMetadata("'DOXLS'",",oparms:[]}");
         setEventMetadata("'DOCOMISIONESEXCEL'","{handler:'E147W2',iparms:[{av:'AV16SecUserId',fld:'vSECUSERID',pic:''},{av:'AV10ProveedorID',fld:'vPROVEEDORID',pic:''},{av:'cmbavEstadosgenericosid'},{av:'AV7EstadosGenericosID',fld:'vESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'AV9FechaIni',fld:'vFECHAINI',pic:'',type:'date'},{av:'AV8fechafin',fld:'vFECHAFIN',pic:'',type:'date'},{av:'radavFechafiltro'},{av:'AV26FechaFiltro',fld:'vFECHAFILTRO',pic:'',type:'svchar'},{av:'cmbavOrigendepago'},{av:'AV15OrigenDePago',fld:'vORIGENDEPAGO',pic:'',type:'char'}]");
         setEventMetadata("'DOCOMISIONESEXCEL'",",oparms:[]}");
         setEventMetadata("'DOCOMISIONESPDF'","{handler:'E117W1',iparms:[{av:'AV10ProveedorID',fld:'vPROVEEDORID',pic:''},{av:'AV16SecUserId',fld:'vSECUSERID',pic:''},{av:'cmbavEstadosgenericosid'},{av:'AV7EstadosGenericosID',fld:'vESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'AV9FechaIni',fld:'vFECHAINI',pic:'',type:'date'},{av:'AV8fechafin',fld:'vFECHAFIN',pic:'',type:'date'},{av:'radavFechafiltro'},{av:'AV26FechaFiltro',fld:'vFECHAFILTRO',pic:'',type:'svchar'},{av:'cmbavOrigendepago'},{av:'AV15OrigenDePago',fld:'vORIGENDEPAGO',pic:'',type:'char'}]");
         setEventMetadata("'DOCOMISIONESPDF'",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'}]}");
         setEventMetadata("VALIDV_FECHAINI","{handler:'Validv_Fechaini',iparms:[]");
         setEventMetadata("VALIDV_FECHAINI",",oparms:[]}");
         setEventMetadata("VALIDV_FECHAFIN","{handler:'Validv_Fechafin',iparms:[]");
         setEventMetadata("VALIDV_FECHAFIN",",oparms:[]}");
         setEventMetadata("VALIDV_ORIGENDEPAGO","{handler:'Validv_Origendepago',iparms:[]");
         setEventMetadata("VALIDV_ORIGENDEPAGO",",oparms:[]}");
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
         Combo_secuserid_Selectedvalue_get = "";
         Combo_proveedorid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV22DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV21ProveedorID_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV27SecUserId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV10ProveedorID = new GxSimpleCollection<long>();
         AV16SecUserId = new GxSimpleCollection<long>();
         AV28SecUserIdJson = "";
         AV24String = "";
         Combo_proveedorid_Selectedvalue_set = "";
         Combo_secuserid_Selectedvalue_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDvpanel_unnamedtable1 = new GXUserControl();
         lblTextblockcombo_proveedorid_Jsonclick = "";
         ucCombo_proveedorid = new GXUserControl();
         TempTags = "";
         ClassString = "";
         StyleString = "";
         AV26FechaFiltro = "";
         AV9FechaIni = DateTime.MinValue;
         AV8fechafin = DateTime.MinValue;
         AV5BusDireccion = "";
         bttBtnxls_Jsonclick = "";
         AV15OrigenDePago = "";
         lblTextblockcombo_secuserid_Jsonclick = "";
         ucCombo_secuserid = new GXUserControl();
         bttBtncomisionesexcel_Jsonclick = "";
         bttBtncomisionespdf_Jsonclick = "";
         ucToastr1 = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucInnewwindow2 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV6Context = new SdtContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         GXt_char2 = "";
         H007W2_A550SecUserEstado = new string[] {""} ;
         H007W2_n550SecUserEstado = new bool[] {false} ;
         H007W2_A18SecUserId = new long[1] ;
         H007W2_A26SecUserName = new string[] {""} ;
         A550SecUserEstado = "";
         A26SecUserName = "";
         AV23Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         H007W3_A133ProveedorID = new long[1] ;
         H007W3_A344ProveedorEstado = new string[] {""} ;
         H007W3_A282ProveedorNombre = new string[] {""} ;
         A344ProveedorEstado = "";
         A282ProveedorNombre = "";
         AV20ComboTitles = new GxSimpleCollection<string>();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reportesolicitudeswp__default(),
            new Object[][] {
                new Object[] {
               H007W2_A550SecUserEstado, H007W2_n550SecUserEstado, H007W2_A18SecUserId, H007W2_A26SecUserName
               }
               , new Object[] {
               H007W3_A133ProveedorID, H007W3_A344ProveedorEstado, H007W3_A282ProveedorNombre
               }
            }
         );
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
      private short nDonePA ;
      private short AV12visualizar ;
      private short nGXWrapped ;
      private int AV7EstadosGenericosID ;
      private int edtavFechaini_Enabled ;
      private int edtavFechafin_Enabled ;
      private int edtavBusdireccion_Enabled ;
      private int idxLst ;
      private long A18SecUserId ;
      private long A133ProveedorID ;
      private string Combo_secuserid_Selectedvalue_get ;
      private string Combo_proveedorid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV24String ;
      private string Combo_proveedorid_Cls ;
      private string Combo_proveedorid_Selectedvalue_set ;
      private string Combo_proveedorid_Htmltemplate ;
      private string Combo_proveedorid_Multiplevaluestype ;
      private string Combo_proveedorid_Emptyitemtext ;
      private string Combo_secuserid_Cls ;
      private string Combo_secuserid_Selectedvalue_set ;
      private string Combo_secuserid_Multiplevaluestype ;
      private string Combo_secuserid_Emptyitemtext ;
      private string Dvpanel_unnamedtable1_Width ;
      private string Dvpanel_unnamedtable1_Cls ;
      private string Dvpanel_unnamedtable1_Title ;
      private string Dvpanel_unnamedtable1_Iconposition ;
      private string Innewwindow1_Target ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divMaintable_Internalname ;
      private string Dvpanel_unnamedtable1_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string divTable9_Internalname ;
      private string divTablesplittedproveedorid_Internalname ;
      private string lblTextblockcombo_proveedorid_Internalname ;
      private string lblTextblockcombo_proveedorid_Jsonclick ;
      private string Combo_proveedorid_Caption ;
      private string Combo_proveedorid_Internalname ;
      private string cmbavEstadosgenericosid_Internalname ;
      private string TempTags ;
      private string cmbavEstadosgenericosid_Jsonclick ;
      private string radavFechafiltro_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string radavFechafiltro_Jsonclick ;
      private string edtavFechaini_Internalname ;
      private string edtavFechaini_Jsonclick ;
      private string edtavFechafin_Internalname ;
      private string edtavFechafin_Jsonclick ;
      private string edtavBusdireccion_Internalname ;
      private string AV5BusDireccion ;
      private string edtavBusdireccion_Jsonclick ;
      private string bttBtnxls_Internalname ;
      private string bttBtnxls_Jsonclick ;
      private string chkavSino_Internalname ;
      private string grpUnnamedgroup2_Internalname ;
      private string divTbcomisiones_Internalname ;
      private string cmbavOrigendepago_Internalname ;
      private string AV15OrigenDePago ;
      private string cmbavOrigendepago_Jsonclick ;
      private string divTablesplittedsecuserid_Internalname ;
      private string lblTextblockcombo_secuserid_Internalname ;
      private string lblTextblockcombo_secuserid_Jsonclick ;
      private string Combo_secuserid_Caption ;
      private string Combo_secuserid_Internalname ;
      private string bttBtncomisionesexcel_Internalname ;
      private string bttBtncomisionesexcel_Jsonclick ;
      private string bttBtncomisionespdf_Internalname ;
      private string bttBtncomisionespdf_Jsonclick ;
      private string Toastr1_Internalname ;
      private string Innewwindow1_Internalname ;
      private string Innewwindow2_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXt_char2 ;
      private string A550SecUserEstado ;
      private string A344ProveedorEstado ;
      private string A282ProveedorNombre ;
      private DateTime AV9FechaIni ;
      private DateTime AV8fechafin ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Combo_proveedorid_Allowmultipleselection ;
      private bool Combo_proveedorid_Includeonlyselectedoption ;
      private bool Combo_secuserid_Allowmultipleselection ;
      private bool Combo_secuserid_Includeonlyselectedoption ;
      private bool Dvpanel_unnamedtable1_Autowidth ;
      private bool Dvpanel_unnamedtable1_Autoheight ;
      private bool Dvpanel_unnamedtable1_Collapsible ;
      private bool Dvpanel_unnamedtable1_Collapsed ;
      private bool Dvpanel_unnamedtable1_Showcollapseicon ;
      private bool Dvpanel_unnamedtable1_Autoscroll ;
      private bool wbLoad ;
      private bool AV11SiNo ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n550SecUserEstado ;
      private string AV28SecUserIdJson ;
      private string AV26FechaFiltro ;
      private string A26SecUserName ;
      private GXUserControl ucDvpanel_unnamedtable1 ;
      private GXUserControl ucCombo_proveedorid ;
      private GXUserControl ucCombo_secuserid ;
      private GXUserControl ucToastr1 ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucInnewwindow2 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavEstadosgenericosid ;
      private GXRadio radavFechafiltro ;
      private GXCheckbox chkavSino ;
      private GXCombobox cmbavOrigendepago ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV22DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV21ProveedorID_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV27SecUserId_Data ;
      private GxSimpleCollection<long> AV10ProveedorID ;
      private GxSimpleCollection<long> AV16SecUserId ;
      private SdtContext AV6Context ;
      private IDataStoreProvider pr_default ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private string[] H007W2_A550SecUserEstado ;
      private bool[] H007W2_n550SecUserEstado ;
      private long[] H007W2_A18SecUserId ;
      private string[] H007W2_A26SecUserName ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV23Combo_DataItem ;
      private long[] H007W3_A133ProveedorID ;
      private string[] H007W3_A344ProveedorEstado ;
      private string[] H007W3_A282ProveedorNombre ;
      private GxSimpleCollection<string> AV20ComboTitles ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class reportesolicitudeswp__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmH007W2;
          prmH007W2 = new Object[] {
          };
          Object[] prmH007W3;
          prmH007W3 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H007W2", "SELECT [SecUserEstado], [SecUserId], [SecUserName] FROM [SecUser] WHERE [SecUserEstado] = 'HAB' ORDER BY [SecUserName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007W2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H007W3", "SELECT [ProveedorID], [ProveedorEstado], [ProveedorNombre] FROM [Proveedor] ORDER BY [ProveedorNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007W3,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                return;
       }
    }

 }

}
