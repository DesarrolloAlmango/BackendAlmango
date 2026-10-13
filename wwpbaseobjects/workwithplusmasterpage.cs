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
namespace GeneXus.Programs.wwpbaseobjects {
   public class workwithplusmasterpage : GXMasterPage, System.Web.SessionState.IRequiresSessionState
   {
      public workwithplusmasterpage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public workwithplusmasterpage( IGxContext context )
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
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            PA1K2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS1K2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE1K2( ) ;
               }
            }
         }
         cleanup();
      }

      protected void RenderHtmlHeaders( )
      {
         if ( ! isFullAjaxMode( ) )
         {
            GXWebForm.AddResponsiveMetaHeaders((getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Meta);
            getDataAreaObject().RenderHtmlHeaders();
         }
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( ! isFullAjaxMode( ) )
         {
            getDataAreaObject().RenderHtmlOpenForm();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vBREADCRUMB_MPAGE", AV34Breadcrumb);
         GxWebStd.gx_hidden_field( context, "gxhash_vBREADCRUMB_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV34Breadcrumb, "")), context));
         GxWebStd.gx_hidden_field( context, "vINDEXTOADDITEMS_MPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15IndexToAddItems), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vINDEXTOADDITEMS_MPAGE", GetSecureSignedToken( "gxmpage_", context.localUtil.Format( (decimal)(AV15IndexToAddItems), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPROGRAMDESCRIPTION_MPAGE", AV16ProgramDescription);
         GxWebStd.gx_hidden_field( context, "gxhash_vPROGRAMDESCRIPTION_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV16ProgramDescription, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "vLANGUAGESICONSDATA_MPAGE", AV36LanguagesIconsData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLANGUAGESICONSDATA_MPAGE", AV36LanguagesIconsData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "vBOOKMARKSDATA_MPAGE", AV10BookmarksData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vBOOKMARKSDATA_MPAGE", AV10BookmarksData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "vDVELOP_MENU_MPAGE", AV30DVelop_Menu);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDVELOP_MENU_MPAGE", AV30DVelop_Menu);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "vDVELOP_MENU_USERDATA_MPAGE", AV6DVelop_Menu_UserData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDVELOP_MENU_USERDATA_MPAGE", AV6DVelop_Menu_UserData);
         }
         GxWebStd.gx_hidden_field( context, "vBREADCRUMB_MPAGE", AV34Breadcrumb);
         GxWebStd.gx_hidden_field( context, "gxhash_vBREADCRUMB_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV34Breadcrumb, "")), context));
         GxWebStd.gx_hidden_field( context, "vINDEXTOADDITEMS_MPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15IndexToAddItems), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vINDEXTOADDITEMS_MPAGE", GetSecureSignedToken( "gxmpage_", context.localUtil.Format( (decimal)(AV15IndexToAddItems), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPROGRAMDESCRIPTION_MPAGE", AV16ProgramDescription);
         GxWebStd.gx_hidden_field( context, "gxhash_vPROGRAMDESCRIPTION_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV16ProgramDescription, "")), context));
         GxWebStd.gx_hidden_field( context, "vSEARCHAUX_MPAGE", AV22SearchAux);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "vNOTIFICATIONINFO_MPAGE", AV18NotificationInfo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNOTIFICATIONINFO_MPAGE", AV18NotificationInfo);
         }
         GxWebStd.gx_hidden_field( context, "WWPUSEREXTENDEDID_MPAGE", StringUtil.RTrim( A1WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "vUDPARG1_MPAGE", StringUtil.RTrim( AV47Udparg1));
         GxWebStd.gx_boolean_hidden_field( context, "WWPNOTIFICATIONISREAD_MPAGE", A91WWPNotificationIsRead);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "vWWPCONTEXT_MPAGE", AV5WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT_MPAGE", AV5WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "DDC_MODULES_MPAGE_Icontype", StringUtil.RTrim( Ddc_modules_Icontype));
         GxWebStd.gx_hidden_field( context, "DDC_MODULES_MPAGE_Icon", StringUtil.RTrim( Ddc_modules_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_MODULES_MPAGE_Caption", StringUtil.RTrim( Ddc_modules_Caption));
         GxWebStd.gx_hidden_field( context, "DDC_MODULES_MPAGE_Cls", StringUtil.RTrim( Ddc_modules_Cls));
         GxWebStd.gx_hidden_field( context, "DDC_MODULES_MPAGE_Componentwidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ddc_modules_Componentwidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDC_MODULES_MPAGE_Visible", StringUtil.BoolToStr( Ddc_modules_Visible));
         GxWebStd.gx_hidden_field( context, "DDC_MODULES_MPAGE_Trigger", StringUtil.RTrim( Ddc_modules_Trigger));
         GxWebStd.gx_hidden_field( context, "DDO_LANGUAGESICONS_MPAGE_Caption", StringUtil.RTrim( Ddo_languagesicons_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_LANGUAGESICONS_MPAGE_Cls", StringUtil.RTrim( Ddo_languagesicons_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_LANGUAGESICONS_MPAGE_Titlecontrolalign", StringUtil.RTrim( Ddo_languagesicons_Titlecontrolalign));
         GxWebStd.gx_hidden_field( context, "DDO_BOOKMARKS_MPAGE_Icontype", StringUtil.RTrim( Ddo_bookmarks_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_BOOKMARKS_MPAGE_Icon", StringUtil.RTrim( Ddo_bookmarks_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_BOOKMARKS_MPAGE_Tooltip", StringUtil.RTrim( Ddo_bookmarks_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_BOOKMARKS_MPAGE_Cls", StringUtil.RTrim( Ddo_bookmarks_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_BOOKMARKS_MPAGE_Titlecontrolalign", StringUtil.RTrim( Ddo_bookmarks_Titlecontrolalign));
         GxWebStd.gx_hidden_field( context, "DDC_NOTIFICATIONSWC_MPAGE_Icontype", StringUtil.RTrim( Ddc_notificationswc_Icontype));
         GxWebStd.gx_hidden_field( context, "DDC_NOTIFICATIONSWC_MPAGE_Icon", StringUtil.RTrim( Ddc_notificationswc_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_NOTIFICATIONSWC_MPAGE_Caption", StringUtil.RTrim( Ddc_notificationswc_Caption));
         GxWebStd.gx_hidden_field( context, "DDC_NOTIFICATIONSWC_MPAGE_Cls", StringUtil.RTrim( Ddc_notificationswc_Cls));
         GxWebStd.gx_hidden_field( context, "DDC_NOTIFICATIONSWC_MPAGE_Visible", StringUtil.BoolToStr( Ddc_notificationswc_Visible));
         GxWebStd.gx_hidden_field( context, "DDC_ADMINAG_MPAGE_Caption", StringUtil.RTrim( Ddc_adminag_Caption));
         GxWebStd.gx_hidden_field( context, "DDC_ADMINAG_MPAGE_Cls", StringUtil.RTrim( Ddc_adminag_Cls));
         GxWebStd.gx_hidden_field( context, "DDC_ADMINAG_MPAGE_Componentwidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ddc_adminag_Componentwidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDC_ADMINAG_MPAGE_Visible", StringUtil.BoolToStr( Ddc_adminag_Visible));
         GxWebStd.gx_hidden_field( context, "DDC_RUNTIMEDESIGNSETTINGS_MPAGE_Icontype", StringUtil.RTrim( Ddc_runtimedesignsettings_Icontype));
         GxWebStd.gx_hidden_field( context, "DDC_RUNTIMEDESIGNSETTINGS_MPAGE_Icon", StringUtil.RTrim( Ddc_runtimedesignsettings_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_RUNTIMEDESIGNSETTINGS_MPAGE_Tooltip", StringUtil.RTrim( Ddc_runtimedesignsettings_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDC_RUNTIMEDESIGNSETTINGS_MPAGE_Cls", StringUtil.RTrim( Ddc_runtimedesignsettings_Cls));
         GxWebStd.gx_hidden_field( context, "DDC_RUNTIMEDESIGNSETTINGS_MPAGE_Componentwidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ddc_runtimedesignsettings_Componentwidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDC_RUNTIMEDESIGNSETTINGS_MPAGE_Visible", StringUtil.BoolToStr( Ddc_runtimedesignsettings_Visible));
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Searchserviceurl", StringUtil.RTrim( Ucmenu_Searchserviceurl));
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Searchminchars", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ucmenu_Searchminchars), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Searchhelperdescription", StringUtil.RTrim( Ucmenu_Searchhelperdescription));
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Includetogglebutton", StringUtil.BoolToStr( Ucmenu_Includetogglebutton));
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Sidebarmainclass", StringUtil.RTrim( Ucmenu_Sidebarmainclass));
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Scrollwidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ucmenu_Scrollwidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Scrollalwaysvisible", StringUtil.BoolToStr( Ucmenu_Scrollalwaysvisible));
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Hidescrollincompactmenu", StringUtil.BoolToStr( Ucmenu_Hidescrollincompactmenu));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_MPAGE_Stoponerror", StringUtil.BoolToStr( Ucmessage_Stoponerror));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Enablefixobjectfitcover", StringUtil.BoolToStr( Wwputilities_Enablefixobjectfitcover));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Enablefloatinglabels", StringUtil.BoolToStr( Wwputilities_Enablefloatinglabels));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Empowertabs", StringUtil.BoolToStr( Wwputilities_Empowertabs));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Enableupdaterowselectionstatus", StringUtil.BoolToStr( Wwputilities_Enableupdaterowselectionstatus));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Enableconvertcombotobootstrapselect", StringUtil.BoolToStr( Wwputilities_Enableconvertcombotobootstrapselect));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Allowcolumnresizing", StringUtil.BoolToStr( Wwputilities_Allowcolumnresizing));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Allowcolumnreordering", StringUtil.BoolToStr( Wwputilities_Allowcolumnreordering));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Allowcolumndragging", StringUtil.BoolToStr( Wwputilities_Allowcolumndragging));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Allowcolumnsrestore", StringUtil.BoolToStr( Wwputilities_Allowcolumnsrestore));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Pagbarincludegoto", StringUtil.BoolToStr( Wwputilities_Pagbarincludegoto));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Comboloadtype", StringUtil.RTrim( Wwputilities_Comboloadtype));
         GxWebStd.gx_hidden_field( context, "POPOVER_SEARCH_MPAGE_Iteminternalname", StringUtil.RTrim( Popover_search_Iteminternalname));
         GxWebStd.gx_hidden_field( context, "POPOVER_SEARCH_MPAGE_Trigger", StringUtil.RTrim( Popover_search_Trigger));
         GxWebStd.gx_hidden_field( context, "POPOVER_SEARCH_MPAGE_Triggerelement", StringUtil.RTrim( Popover_search_Triggerelement));
         GxWebStd.gx_hidden_field( context, "POPOVER_SEARCH_MPAGE_Popoverwidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Popover_search_Popoverwidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "POPOVER_SEARCH_MPAGE_Position", StringUtil.RTrim( Popover_search_Position));
         GxWebStd.gx_hidden_field( context, "POPOVER_SEARCH_MPAGE_Keepopened", StringUtil.BoolToStr( Popover_search_Keepopened));
         GxWebStd.gx_hidden_field( context, "POPOVER_SEARCH_MPAGE_Reloadonkeychange", StringUtil.BoolToStr( Popover_search_Reloadonkeychange));
         GxWebStd.gx_hidden_field( context, "POPOVER_SEARCH_MPAGE_Minimumcharacters", StringUtil.LTrim( StringUtil.NToC( (decimal)(Popover_search_Minimumcharacters), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "BOOKMARK_MODAL_MPAGE_Width", StringUtil.RTrim( Bookmark_modal_Width));
         GxWebStd.gx_hidden_field( context, "BOOKMARK_MODAL_MPAGE_Title", StringUtil.RTrim( Bookmark_modal_Title));
         GxWebStd.gx_hidden_field( context, "BOOKMARK_MODAL_MPAGE_Confirmtype", StringUtil.RTrim( Bookmark_modal_Confirmtype));
         GxWebStd.gx_hidden_field( context, "BOOKMARK_MODAL_MPAGE_Bodytype", StringUtil.RTrim( Bookmark_modal_Bodytype));
         GxWebStd.gx_hidden_field( context, "FORM_MPAGE_Caption", StringUtil.RTrim( (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Caption));
         GxWebStd.gx_hidden_field( context, "vHTTPREQUEST_MPAGE_Baseurl", StringUtil.RTrim( AV38Httprequest.BaseURL));
         GxWebStd.gx_hidden_field( context, "DDO_LANGUAGESICONS_MPAGE_Activeeventkey", StringUtil.RTrim( Ddo_languagesicons_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_BOOKMARKS_MPAGE_Activeeventkey", StringUtil.RTrim( Ddo_bookmarks_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "vNOTIFICATIONINFO_MPAGE_Message", AV18NotificationInfo.gxTpr_Message);
         GxWebStd.gx_hidden_field( context, "DDC_NOTIFICATIONSWC_MPAGE_Icon", StringUtil.RTrim( Ddc_notificationswc_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_NOTIFICATIONSWC_MPAGE_Icon", StringUtil.RTrim( Ddc_notificationswc_Icon));
         GxWebStd.gx_hidden_field( context, "FORM_MPAGE_Caption", StringUtil.RTrim( (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Caption));
         GxWebStd.gx_hidden_field( context, "DDO_LANGUAGESICONS_MPAGE_Activeeventkey", StringUtil.RTrim( Ddo_languagesicons_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_BOOKMARKS_MPAGE_Activeeventkey", StringUtil.RTrim( Ddo_bookmarks_Activeeventkey));
      }

      protected void RenderHtmlCloseForm1K2( )
      {
         SendCloseFormHiddens( ) ;
         SendSecurityToken((string)(sPrefix));
         if ( ! isFullAjaxMode( ) )
         {
            getDataAreaObject().RenderHtmlCloseForm();
         }
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 74760), false, true, false);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 74760), false, true, false);
         context.AddJavascriptSource("calendar-"+StringUtil.Substring( context.GetLanguageProperty( "culture"), 1, 2)+".js", "?"+context.GetBuildNumber( 74760), false, true, false);
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/slimscroll/jquery.slimscroll.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/SidebarMenu/BootstrapSidebarMenuRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVMessage/pnotify.custom.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVMessage/DVMessageRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Tooltip/BootstrapTooltipRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Mask/jquery.mask.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/BootstrapSelect.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/WorkWithPlusUtilitiesRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DatePicker/DatePickerRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Popover/WWPPopoverRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("wwpbaseobjects/workwithplusmasterpage.js", "?20269212244022", false, true, false);
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.WorkWithPlusMasterPage" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Master Page", "") ;
      }

      protected void WB1K0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            if ( ! ShowMPWhenPopUp( ) && context.isPopUpObject( ) )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableOutput();
               }
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
               /* Content placeholder */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gx-content-placeholder");
               context.WriteHtmlText( ">") ;
               if ( ! isFullAjaxMode( ) )
               {
                  getDataAreaObject().RenderHtmlContent();
               }
               context.WriteHtmlText( "</div>") ;
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
               wbLoad = true;
               return  ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MasterHeaderCell navbar-fixed-top", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "TableHeader", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "HeaderImageCell", "start", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "ImageTop" + " " + ((StringUtil.StrCmp(imgHeader_gximage, "")==0) ? "GX_Image_logoBlanco_Class" : "GX_Image_"+imgHeader_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "6d6ce347-47c5-435c-997c-4658165957fb", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgHeader_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_WWPBaseObjects/WorkWithPlusMasterPage.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "hidden-lg hidden-md hidden-sm", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblShowmenu_Internalname, context.GetMessage( "<i class=\"fa fa-bars ImageMenuIcon\"></i>", ""), "", "", lblShowmenu_Jsonclick, "'"+""+"'"+",true,"+"'"+"e111k1_client"+"'", "", "TextBlock", 7, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/WorkWithPlusMasterPage.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "hidden-xs", "start", "top", "", "align-self:center;", "div");
            /* User Defined Control */
            ucDdc_modules.SetProperty("IconType", Ddc_modules_Icontype);
            ucDdc_modules.SetProperty("Icon", Ddc_modules_Icon);
            ucDdc_modules.SetProperty("Caption", Ddc_modules_Caption);
            ucDdc_modules.SetProperty("Cls", Ddc_modules_Cls);
            ucDdc_modules.SetProperty("ComponentWidth", Ddc_modules_Componentwidth);
            ucDdc_modules.SetProperty("Trigger", Ddc_modules_Trigger);
            ucDdc_modules.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_modules_Internalname, "DDC_MODULES_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableuserrole_Internalname, 1, 0, "px", 0, "px", "CellHeaderBar hidden-xs", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellAttributeSearch", "start", "top", "", "align-self:center;", "div");
            wb_table1_21_1K2( true) ;
         }
         else
         {
            wb_table1_21_1K2( false) ;
         }
         return  ;
      }

      protected void wb_table1_21_1K2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDdo_languagesicons.SetProperty("Caption", Ddo_languagesicons_Caption);
            ucDdo_languagesicons.SetProperty("Cls", Ddo_languagesicons_Cls);
            ucDdo_languagesicons.SetProperty("DropDownOptionsData", AV36LanguagesIconsData);
            ucDdo_languagesicons.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_languagesicons_Internalname, "DDO_LANGUAGESICONS_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDdo_bookmarks.SetProperty("IconType", Ddo_bookmarks_Icontype);
            ucDdo_bookmarks.SetProperty("Icon", Ddo_bookmarks_Icon);
            ucDdo_bookmarks.SetProperty("Caption", Ddo_bookmarks_Caption);
            ucDdo_bookmarks.SetProperty("Cls", Ddo_bookmarks_Cls);
            ucDdo_bookmarks.SetProperty("DropDownOptionsData", AV10BookmarksData);
            ucDdo_bookmarks.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_bookmarks_Internalname, "DDO_BOOKMARKS_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDdc_notificationswc.SetProperty("IconType", Ddc_notificationswc_Icontype);
            ucDdc_notificationswc.SetProperty("Icon", Ddc_notificationswc_Icon);
            ucDdc_notificationswc.SetProperty("Caption", Ddc_notificationswc_Caption);
            ucDdc_notificationswc.SetProperty("Cls", Ddc_notificationswc_Cls);
            ucDdc_notificationswc.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_notificationswc_Internalname, "DDC_NOTIFICATIONSWC_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "MasterTopIconsCell", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDdc_adminag.SetProperty("Caption", Ddc_adminag_Caption);
            ucDdc_adminag.SetProperty("Cls", Ddc_adminag_Cls);
            ucDdc_adminag.SetProperty("ComponentWidth", Ddc_adminag_Componentwidth);
            ucDdc_adminag.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_adminag_Internalname, "DDC_ADMINAG_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "MasterTopIconsCell", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucDdc_runtimedesignsettings.SetProperty("IconType", Ddc_runtimedesignsettings_Icontype);
            ucDdc_runtimedesignsettings.SetProperty("Icon", Ddc_runtimedesignsettings_Icon);
            ucDdc_runtimedesignsettings.SetProperty("Caption", Ddc_runtimedesignsettings_Caption);
            ucDdc_runtimedesignsettings.SetProperty("Tooltip", Ddc_runtimedesignsettings_Tooltip);
            ucDdc_runtimedesignsettings.SetProperty("Cls", Ddc_runtimedesignsettings_Cls);
            ucDdc_runtimedesignsettings.SetProperty("ComponentWidth", Ddc_runtimedesignsettings_Componentwidth);
            ucDdc_runtimedesignsettings.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_runtimedesignsettings_Internalname, "DDC_RUNTIMEDESIGNSETTINGS_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellTableContentMaster CellTableContentWithFooter", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "page-content MaterialStyle", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellTitleMaster", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletitle_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocktitle_Internalname, lblTextblocktitle_Caption, "", "", lblTextblocktitle_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "TextBlockTitleMaster", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/WorkWithPlusMasterPage.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSubtitle_Internalname, lblSubtitle_Caption, "", "", lblSubtitle_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/WorkWithPlusMasterPage.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellContentHolder", "start", "top", "", "", "div");
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            /* Content placeholder */
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-content-placeholder");
            context.WriteHtmlText( ">") ;
            if ( ! isFullAjaxMode( ) )
            {
               getDataAreaObject().RenderHtmlContent();
            }
            context.WriteHtmlText( "</div>") ;
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUcmenu.SetProperty("SearchServiceUrl", Ucmenu_Searchserviceurl);
            ucUcmenu.SetProperty("SearchMinChars", Ucmenu_Searchminchars);
            ucUcmenu.SetProperty("SearchHelperDescription", Ucmenu_Searchhelperdescription);
            ucUcmenu.SetProperty("IncludeToggleButton", Ucmenu_Includetogglebutton);
            ucUcmenu.SetProperty("SidebarMainClass", Ucmenu_Sidebarmainclass);
            ucUcmenu.SetProperty("ScrollWidth", Ucmenu_Scrollwidth);
            ucUcmenu.SetProperty("ScrollAlwaysVisible", Ucmenu_Scrollalwaysvisible);
            ucUcmenu.SetProperty("HideScrollInCompactMenu", Ucmenu_Hidescrollincompactmenu);
            ucUcmenu.SetProperty("SidebarMenuOptionsData", AV30DVelop_Menu);
            ucUcmenu.SetProperty("SidebarMenuUserData", AV6DVelop_Menu_UserData);
            ucUcmenu.Render(context, "dvelop.gxbootstrap.sidebarmenu", Ucmenu_Internalname, "UCMENU_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MasterFooterCellVM page-content", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablefooter_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "justify-content:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockfooter_Internalname, context.GetMessage( "Almango Systems | Desing by Azmita", ""), "", "", lblTextblockfooter_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "FooterText", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/WorkWithPlusMasterPage.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUcmessage.SetProperty("StopOnError", Ucmessage_Stoponerror);
            ucUcmessage.Render(context, "dvelop.dvmessage", Ucmessage_Internalname, "UCMESSAGE_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUctooltip.Render(context, "dvelop.gxbootstrap.tooltip", Uctooltip_Internalname, "UCTOOLTIP_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucWwputilities.SetProperty("EnableFixObjectFitCover", Wwputilities_Enablefixobjectfitcover);
            ucWwputilities.SetProperty("EnableFloatingLabels", Wwputilities_Enablefloatinglabels);
            ucWwputilities.SetProperty("EmpowerTabs", Wwputilities_Empowertabs);
            ucWwputilities.SetProperty("EnableUpdateRowSelectionStatus", Wwputilities_Enableupdaterowselectionstatus);
            ucWwputilities.SetProperty("EnableConvertComboToBootstrapSelect", Wwputilities_Enableconvertcombotobootstrapselect);
            ucWwputilities.SetProperty("AllowColumnResizing", Wwputilities_Allowcolumnresizing);
            ucWwputilities.SetProperty("AllowColumnReordering", Wwputilities_Allowcolumnreordering);
            ucWwputilities.SetProperty("AllowColumnDragging", Wwputilities_Allowcolumndragging);
            ucWwputilities.SetProperty("AllowColumnsRestore", Wwputilities_Allowcolumnsrestore);
            ucWwputilities.SetProperty("PagBarIncludeGoTo", Wwputilities_Pagbarincludegoto);
            ucWwputilities.SetProperty("ComboLoadType", Wwputilities_Comboloadtype);
            ucWwputilities.Render(context, "wwp.workwithplusutilities_fal", Wwputilities_Internalname, "WWPUTILITIES_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucWwpdatepicker.Render(context, "wwp.datepicker", Wwpdatepicker_Internalname, "WWPDATEPICKER_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblHtml_Internalname, lblHtml_Caption, "", "", lblHtml_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "TextBlock", 0, "", lblHtml_Visible, 1, 0, 1, "HLP_WWPBaseObjects/WorkWithPlusMasterPage.htm");
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
            ucPopover_search.SetProperty("Trigger", Popover_search_Trigger);
            ucPopover_search.SetProperty("TriggerElement", Popover_search_Triggerelement);
            ucPopover_search.SetProperty("PopoverWidth", Popover_search_Popoverwidth);
            ucPopover_search.SetProperty("Position", Popover_search_Position);
            ucPopover_search.SetProperty("KeepOpened", Popover_search_Keepopened);
            ucPopover_search.SetProperty("ReloadOnKeyChange", Popover_search_Reloadonkeychange);
            ucPopover_search.SetProperty("MinimumCharacters", Popover_search_Minimumcharacters);
            ucPopover_search.Render(context, "dvelop.wwppopover", Popover_search_Internalname, "POPOVER_SEARCH_MPAGEContainer");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',true,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavPickerdummyvariable_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavPickerdummyvariable_Internalname, context.localUtil.Format(AV42PickerDummyVariable, "99/99/99"), context.localUtil.Format( AV42PickerDummyVariable, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,80);\"", "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "", "", "", edtavPickerdummyvariable_Jsonclick, 0, "Invisible", "", "", "", "", 1, 1, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/WorkWithPlusMasterPage.htm");
            GxWebStd.gx_bitmap( context, edtavPickerdummyvariable_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(1==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_WWPBaseObjects/WorkWithPlusMasterPage.htm");
            context.WriteHtmlTextNl( "</div>") ;
            wb_table2_81_1K2( true) ;
         }
         else
         {
            wb_table2_81_1K2( false) ;
         }
         return  ;
      }

      protected void wb_table2_81_1K2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "MPW0087"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpMPW0087"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0087"+"");
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

      protected void START1K2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1K0( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( getDataAreaObject().ExecuteStartEvent() != 0 )
            {
               setAjaxCallMode();
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      protected void WS1K2( )
      {
         START1K2( ) ;
         EVT1K2( ) ;
      }

      protected void EVT1K2( )
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
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "RFR_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DDC_MODULES_MPAGE.ONLOADCOMPONENT_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Ddc_modules.Onloadcomponent */
                           E121K2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DDO_LANGUAGESICONS_MPAGE.ONOPTIONCLICKED_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Ddo_languagesicons.Onoptionclicked */
                           E131K2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DDO_BOOKMARKS_MPAGE.ONOPTIONCLICKED_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Ddo_bookmarks.Onoptionclicked */
                           E141K2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DDC_NOTIFICATIONSWC_MPAGE.ONLOADCOMPONENT_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Ddc_notificationswc.Onloadcomponent */
                           E151K2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DDC_ADMINAG_MPAGE.ONLOADCOMPONENT_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Ddc_adminag.Onloadcomponent */
                           E161K2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DDC_RUNTIMEDESIGNSETTINGS_MPAGE.ONLOADCOMPONENT_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Ddc_runtimedesignsettings.Onloadcomponent */
                           E171K2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "POPOVER_SEARCH_MPAGE.ONLOADCOMPONENT_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Popover_search.Onloadcomponent */
                           E181K2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "BOOKMARK_MODAL_MPAGE.CLOSE_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Bookmark_modal.Close */
                           E191K2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "BOOKMARK_MODAL_MPAGE.ONLOADCOMPONENT_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Bookmark_modal.Onloadcomponent */
                           E201K2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E211K2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "REFRESH_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Refresh */
                           E221K2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DOACTIONSEARCH_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: 'DoActionSearch' */
                           E231K2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Onmessage_gx1 */
                           E241K2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS_MPAGE.MASTER_REFRESHHEADER_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E251K2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E261K2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER_MPAGE") == 0 )
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
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Onmessage_gx1 */
                           E241K2 ();
                           dynload_actions( ) ;
                        }
                     }
                     else
                     {
                     }
                  }
                  else if ( StringUtil.StrCmp(sEvtType, "M") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-2));
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-6));
                     nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                     if ( nCmpId == 87 )
                     {
                        OldWwpaux_wc = cgiGet( "MPW0087");
                        if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                        {
                           WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                           WebComp_Wwpaux_wc.ComponentInit();
                           WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                        if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                        {
                           WebComp_Wwpaux_wc.componentprocess("MPW0087", "", sEvt);
                        }
                        WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                     }
                  }
                  if ( context.wbHandled == 0 )
                  {
                     getDataAreaObject().DispatchEvents();
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void WE1K2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm1K2( ) ;
            }
         }
      }

      protected void PA1K2( )
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
               GX_FocusControl = edtavSearch_Internalname;
               AssignAttri("", true, "GX_FocusControl", GX_FocusControl);
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
         RF1K2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF1K2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ShowMPWhenPopUp( ) || ! context.isPopUpObject( ) )
         {
            /* Execute user event: Refresh */
            E221K2 ();
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
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E261K2 ();
            WB1K0( ) ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
      }

      protected void send_integrity_lvl_hashes1K2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1K0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E211K2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vLANGUAGESICONSDATA_MPAGE"), AV36LanguagesIconsData);
            ajax_req_read_hidden_sdt(cgiGet( "vBOOKMARKSDATA_MPAGE"), AV10BookmarksData);
            ajax_req_read_hidden_sdt(cgiGet( "vDVELOP_MENU_MPAGE"), AV30DVelop_Menu);
            ajax_req_read_hidden_sdt(cgiGet( "vDVELOP_MENU_USERDATA_MPAGE"), AV6DVelop_Menu_UserData);
            ajax_req_read_hidden_sdt(cgiGet( "vNOTIFICATIONINFO_MPAGE"), AV18NotificationInfo);
            /* Read saved values. */
            AV22SearchAux = cgiGet( "vSEARCHAUX_MPAGE");
            Ddc_modules_Icontype = cgiGet( "DDC_MODULES_MPAGE_Icontype");
            Ddc_modules_Icon = cgiGet( "DDC_MODULES_MPAGE_Icon");
            Ddc_modules_Caption = cgiGet( "DDC_MODULES_MPAGE_Caption");
            Ddc_modules_Cls = cgiGet( "DDC_MODULES_MPAGE_Cls");
            Ddc_modules_Componentwidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DDC_MODULES_MPAGE_Componentwidth"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddc_modules_Visible = StringUtil.StrToBool( cgiGet( "DDC_MODULES_MPAGE_Visible"));
            Ddc_modules_Trigger = cgiGet( "DDC_MODULES_MPAGE_Trigger");
            Ddo_languagesicons_Caption = cgiGet( "DDO_LANGUAGESICONS_MPAGE_Caption");
            Ddo_languagesicons_Cls = cgiGet( "DDO_LANGUAGESICONS_MPAGE_Cls");
            Ddo_languagesicons_Titlecontrolalign = cgiGet( "DDO_LANGUAGESICONS_MPAGE_Titlecontrolalign");
            Ddo_bookmarks_Icontype = cgiGet( "DDO_BOOKMARKS_MPAGE_Icontype");
            Ddo_bookmarks_Icon = cgiGet( "DDO_BOOKMARKS_MPAGE_Icon");
            Ddo_bookmarks_Tooltip = cgiGet( "DDO_BOOKMARKS_MPAGE_Tooltip");
            Ddo_bookmarks_Cls = cgiGet( "DDO_BOOKMARKS_MPAGE_Cls");
            Ddo_bookmarks_Titlecontrolalign = cgiGet( "DDO_BOOKMARKS_MPAGE_Titlecontrolalign");
            Ddc_notificationswc_Icontype = cgiGet( "DDC_NOTIFICATIONSWC_MPAGE_Icontype");
            Ddc_notificationswc_Icon = cgiGet( "DDC_NOTIFICATIONSWC_MPAGE_Icon");
            Ddc_notificationswc_Caption = cgiGet( "DDC_NOTIFICATIONSWC_MPAGE_Caption");
            Ddc_notificationswc_Cls = cgiGet( "DDC_NOTIFICATIONSWC_MPAGE_Cls");
            Ddc_notificationswc_Visible = StringUtil.StrToBool( cgiGet( "DDC_NOTIFICATIONSWC_MPAGE_Visible"));
            Ddc_adminag_Caption = cgiGet( "DDC_ADMINAG_MPAGE_Caption");
            Ddc_adminag_Cls = cgiGet( "DDC_ADMINAG_MPAGE_Cls");
            Ddc_adminag_Componentwidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DDC_ADMINAG_MPAGE_Componentwidth"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddc_adminag_Visible = StringUtil.StrToBool( cgiGet( "DDC_ADMINAG_MPAGE_Visible"));
            Ddc_runtimedesignsettings_Icontype = cgiGet( "DDC_RUNTIMEDESIGNSETTINGS_MPAGE_Icontype");
            Ddc_runtimedesignsettings_Icon = cgiGet( "DDC_RUNTIMEDESIGNSETTINGS_MPAGE_Icon");
            Ddc_runtimedesignsettings_Tooltip = cgiGet( "DDC_RUNTIMEDESIGNSETTINGS_MPAGE_Tooltip");
            Ddc_runtimedesignsettings_Cls = cgiGet( "DDC_RUNTIMEDESIGNSETTINGS_MPAGE_Cls");
            Ddc_runtimedesignsettings_Componentwidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DDC_RUNTIMEDESIGNSETTINGS_MPAGE_Componentwidth"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddc_runtimedesignsettings_Visible = StringUtil.StrToBool( cgiGet( "DDC_RUNTIMEDESIGNSETTINGS_MPAGE_Visible"));
            Ucmenu_Searchserviceurl = cgiGet( "UCMENU_MPAGE_Searchserviceurl");
            Ucmenu_Searchminchars = (int)(Math.Round(context.localUtil.CToN( cgiGet( "UCMENU_MPAGE_Searchminchars"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ucmenu_Searchhelperdescription = cgiGet( "UCMENU_MPAGE_Searchhelperdescription");
            Ucmenu_Includetogglebutton = StringUtil.StrToBool( cgiGet( "UCMENU_MPAGE_Includetogglebutton"));
            Ucmenu_Sidebarmainclass = cgiGet( "UCMENU_MPAGE_Sidebarmainclass");
            Ucmenu_Scrollwidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "UCMENU_MPAGE_Scrollwidth"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ucmenu_Scrollalwaysvisible = StringUtil.StrToBool( cgiGet( "UCMENU_MPAGE_Scrollalwaysvisible"));
            Ucmenu_Hidescrollincompactmenu = StringUtil.StrToBool( cgiGet( "UCMENU_MPAGE_Hidescrollincompactmenu"));
            Ucmessage_Stoponerror = StringUtil.StrToBool( cgiGet( "UCMESSAGE_MPAGE_Stoponerror"));
            Wwputilities_Enablefixobjectfitcover = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Enablefixobjectfitcover"));
            Wwputilities_Enablefloatinglabels = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Enablefloatinglabels"));
            Wwputilities_Empowertabs = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Empowertabs"));
            Wwputilities_Enableupdaterowselectionstatus = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Enableupdaterowselectionstatus"));
            Wwputilities_Enableconvertcombotobootstrapselect = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Enableconvertcombotobootstrapselect"));
            Wwputilities_Allowcolumnresizing = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Allowcolumnresizing"));
            Wwputilities_Allowcolumnreordering = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Allowcolumnreordering"));
            Wwputilities_Allowcolumndragging = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Allowcolumndragging"));
            Wwputilities_Allowcolumnsrestore = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Allowcolumnsrestore"));
            Wwputilities_Pagbarincludegoto = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Pagbarincludegoto"));
            Wwputilities_Comboloadtype = cgiGet( "WWPUTILITIES_MPAGE_Comboloadtype");
            Popover_search_Iteminternalname = cgiGet( "POPOVER_SEARCH_MPAGE_Iteminternalname");
            Popover_search_Trigger = cgiGet( "POPOVER_SEARCH_MPAGE_Trigger");
            Popover_search_Triggerelement = cgiGet( "POPOVER_SEARCH_MPAGE_Triggerelement");
            Popover_search_Popoverwidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POPOVER_SEARCH_MPAGE_Popoverwidth"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Popover_search_Position = cgiGet( "POPOVER_SEARCH_MPAGE_Position");
            Popover_search_Keepopened = StringUtil.StrToBool( cgiGet( "POPOVER_SEARCH_MPAGE_Keepopened"));
            Popover_search_Reloadonkeychange = StringUtil.StrToBool( cgiGet( "POPOVER_SEARCH_MPAGE_Reloadonkeychange"));
            Popover_search_Minimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "POPOVER_SEARCH_MPAGE_Minimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Bookmark_modal_Width = cgiGet( "BOOKMARK_MODAL_MPAGE_Width");
            Bookmark_modal_Title = cgiGet( "BOOKMARK_MODAL_MPAGE_Title");
            Bookmark_modal_Confirmtype = cgiGet( "BOOKMARK_MODAL_MPAGE_Confirmtype");
            Bookmark_modal_Bodytype = cgiGet( "BOOKMARK_MODAL_MPAGE_Bodytype");
            Ddc_notificationswc_Icon = cgiGet( "DDC_NOTIFICATIONSWC_MPAGE_Icon");
            (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Caption = cgiGet( "FORM_MPAGE_Caption");
            Ddo_languagesicons_Activeeventkey = cgiGet( "DDO_LANGUAGESICONS_MPAGE_Activeeventkey");
            Ddo_bookmarks_Activeeventkey = cgiGet( "DDO_BOOKMARKS_MPAGE_Activeeventkey");
            /* Read variables values. */
            AV26Search = cgiGet( edtavSearch_Internalname);
            AssignAttri("", true, "AV26Search", AV26Search);
            if ( context.localUtil.VCDate( cgiGet( edtavPickerdummyvariable_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Picker Dummy Variable", "")}), 1, "vPICKERDUMMYVARIABLE_MPAGE");
               GX_FocusControl = edtavPickerdummyvariable_Internalname;
               AssignAttri("", true, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV42PickerDummyVariable = DateTime.MinValue;
               AssignAttri("", true, "AV42PickerDummyVariable", context.localUtil.Format(AV42PickerDummyVariable, "99/99/99"));
            }
            else
            {
               AV42PickerDummyVariable = context.localUtil.CToD( cgiGet( edtavPickerdummyvariable_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", true, "AV42PickerDummyVariable", context.localUtil.Format(AV42PickerDummyVariable, "99/99/99"));
            }
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
         E211K2 ();
         if (returnInSub) return;
      }

      protected void E211K2( )
      {
         /* Start Routine */
         returnInSub = false;
         lblHtml_Visible = 0;
         AssignProp("", true, lblHtml_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblHtml_Visible), 5, 0), true);
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Headerrawhtml = "<link rel=\"shortcut icon\" type=\"image/x-icon\" href=\""+context.convertURL( (string)(context.GetImagePath( "068ed6aa-27b2-425c-8e58-76bddef87f12", "", context.GetTheme( ))))+"\">";
         divLayoutmaintable_Class = "MainContainerWithFooter";
         AssignProp("", true, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         Popover_search_Iteminternalname = edtavSearch_Internalname;
         ucPopover_search.SendProperty(context, "", true, Popover_search_Internalname, "ItemInternalName", Popover_search_Iteminternalname);
         AV36LanguagesIconsData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV37LanguagesIconsDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV37LanguagesIconsDataItem.gxTpr_Title = context.GetMessage( "English", "");
         AV37LanguagesIconsDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "d17b971e-903f-42c1-8eac-c1f10bd50994", "", context.GetTheme( ))));
         AV37LanguagesIconsDataItem.gxTpr_Eventkey = "EnglishOption";
         AV37LanguagesIconsDataItem.gxTpr_Isdivider = false;
         AV36LanguagesIconsData.Add(AV37LanguagesIconsDataItem, 0);
         AV37LanguagesIconsDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV37LanguagesIconsDataItem.gxTpr_Title = context.GetMessage( "Spanish", "");
         AV37LanguagesIconsDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "673a1d61-33cb-4f10-916b-7c9fb6391c49", "", context.GetTheme( ))));
         AV37LanguagesIconsDataItem.gxTpr_Eventkey = "SpanishOption";
         AV37LanguagesIconsDataItem.gxTpr_Isdivider = false;
         AV36LanguagesIconsData.Add(AV37LanguagesIconsDataItem, 0);
         AV37LanguagesIconsDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV37LanguagesIconsDataItem.gxTpr_Title = context.GetMessage( "Portuguese", "");
         AV37LanguagesIconsDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "ea475188-30f1-4e72-9fb4-b7a59929106a", "", context.GetTheme( ))));
         AV37LanguagesIconsDataItem.gxTpr_Eventkey = "PortugueseOption";
         AV37LanguagesIconsDataItem.gxTpr_Isdivider = false;
         AV36LanguagesIconsData.Add(AV37LanguagesIconsDataItem, 0);
         AV10BookmarksData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV11BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV11BookmarksDataItem.gxTpr_Title = context.GetMessage( "Bookmark Page", "");
         AV11BookmarksDataItem.gxTpr_Fonticon = "fas fa-star FontIconTopRightActions";
         AV11BookmarksDataItem.gxTpr_Eventkey = "Bookmark";
         AV11BookmarksDataItem.gxTpr_Isdivider = false;
         AV10BookmarksData.Add(AV11BookmarksDataItem, 0);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV5WWPContext) ;
         AV31UserName = AV5WWPContext.gxTpr_Username;
         AV32RolesDescriptions = "";
         GXt_objcol_int1 = AV7SecRoleIdCollection;
         new GeneXus.Programs.wwpbaseobjects.secgetrolesfromloggeduser(context ).execute( out  GXt_objcol_int1) ;
         AV7SecRoleIdCollection = GXt_objcol_int1;
         AV44GXV1 = 1;
         while ( AV44GXV1 <= AV7SecRoleIdCollection.Count )
         {
            AV8SecRoleId = (short)(AV7SecRoleIdCollection.GetNumeric(AV44GXV1));
            AssignAttri("", true, "AV8SecRoleId", StringUtil.LTrimStr( (decimal)(AV8SecRoleId), 4, 0));
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32RolesDescriptions)) )
            {
               AV32RolesDescriptions += ", ";
            }
            /* Using cursor H001K2 */
            pr_default.execute(0, new Object[] {AV8SecRoleId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A16SecRoleId = H001K2_A16SecRoleId[0];
               A25SecRoleName = H001K2_A25SecRoleName[0];
               AV32RolesDescriptions += A25SecRoleName;
               if ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( A25SecRoleName)), context.GetMessage( "ADMINISTRATOR", "")) == 0 )
               {
                  GXt_objcol_SdtDVelop_Menu_Item2 = AV30DVelop_Menu;
                  new GeneXus.Programs.wwpbaseobjects.menuoptionsdata(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item2) ;
                  AV30DVelop_Menu = GXt_objcol_SdtDVelop_Menu_Item2;
               }
               else if ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( A25SecRoleName)), context.GetMessage( "ADM GENERAL", "")) == 0 )
               {
                  GXt_objcol_SdtDVelop_Menu_Item2 = AV30DVelop_Menu;
                  new GeneXus.Programs.wwpbaseobjects.menuoptionsadmin(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item2) ;
                  AV30DVelop_Menu = GXt_objcol_SdtDVelop_Menu_Item2;
               }
               else if ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( A25SecRoleName)), context.GetMessage( "ADM EJECUTIVO", "")) == 0 )
               {
                  GXt_objcol_SdtDVelop_Menu_Item2 = AV30DVelop_Menu;
                  new GeneXus.Programs.wwpbaseobjects.menuoptionsadmin(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item2) ;
                  AV30DVelop_Menu = GXt_objcol_SdtDVelop_Menu_Item2;
               }
               else if ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( A25SecRoleName)), context.GetMessage( "AGE VENDEDOR", "")) == 0 )
               {
                  GXt_objcol_SdtDVelop_Menu_Item2 = AV30DVelop_Menu;
                  new GeneXus.Programs.wwpbaseobjects.menuoptionsvendedor(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item2) ;
                  AV30DVelop_Menu = GXt_objcol_SdtDVelop_Menu_Item2;
               }
               else if ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( A25SecRoleName)), context.GetMessage( "ADM COMERCIO", "")) == 0 )
               {
                  GXt_objcol_SdtDVelop_Menu_Item2 = AV30DVelop_Menu;
                  new GeneXus.Programs.wwpbaseobjects.menuoptionscomercio(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item2) ;
                  AV30DVelop_Menu = GXt_objcol_SdtDVelop_Menu_Item2;
                  /* Execute user subroutine: 'HTML CONTACTAR' */
                  S113 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     returnInSub = true;
                     if (true) return;
                  }
               }
               else if ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( A25SecRoleName)), context.GetMessage( "AGE COMERCIO", "")) == 0 )
               {
                  GXt_objcol_SdtDVelop_Menu_Item2 = AV30DVelop_Menu;
                  new GeneXus.Programs.wwpbaseobjects.menuoptionscomercio(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item2) ;
                  AV30DVelop_Menu = GXt_objcol_SdtDVelop_Menu_Item2;
                  /* Execute user subroutine: 'HTML CONTACTAR' */
                  S113 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     returnInSub = true;
                     if (true) return;
                  }
               }
               else
               {
                  GXt_objcol_SdtDVelop_Menu_Item2 = AV30DVelop_Menu;
                  new GeneXus.Programs.wwpbaseobjects.menuoptionsvendedor(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item2) ;
                  AV30DVelop_Menu = GXt_objcol_SdtDVelop_Menu_Item2;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV44GXV1 = (int)(AV44GXV1+1);
         }
         new GeneXus.Programs.wwpbaseobjects.getmenuauthorizedoptions(context ).execute( ref  AV30DVelop_Menu) ;
         if ( new GeneXus.Programs.wwpbaseobjects.wwp_loadlanguageandtheme(context).executeUdp( out  AV33Language) )
         {
            context.DoAjaxRefresh();
         }
         Ddo_languagesicons_Titlecontrolalign = "Left";
         ucDdo_languagesicons.SendProperty(context, "", true, Ddo_languagesicons_Internalname, "TitleControlAlign", Ddo_languagesicons_Titlecontrolalign);
         if ( StringUtil.StrCmp(AV33Language, "English") == 0 )
         {
            Ddo_languagesicons_Caption = context.GetMessage( "EN", "");
            ucDdo_languagesicons.SendProperty(context, "", true, Ddo_languagesicons_Internalname, "Caption", Ddo_languagesicons_Caption);
         }
         else if ( StringUtil.StrCmp(AV33Language, "Spanish") == 0 )
         {
            Ddo_languagesicons_Caption = context.GetMessage( "ES", "");
            ucDdo_languagesicons.SendProperty(context, "", true, Ddo_languagesicons_Internalname, "Caption", Ddo_languagesicons_Caption);
         }
         else if ( StringUtil.StrCmp(AV33Language, "Portuguese") == 0 )
         {
            Ddo_languagesicons_Caption = context.GetMessage( "PT", "");
            ucDdo_languagesicons.SendProperty(context, "", true, Ddo_languagesicons_Internalname, "Caption", Ddo_languagesicons_Caption);
         }
         Ddo_bookmarks_Tooltip = context.GetMessage( "WWP_Bookmark_Tooltip", "");
         ucDdo_bookmarks.SendProperty(context, "", true, Ddo_bookmarks_Internalname, "Tooltip", Ddo_bookmarks_Tooltip);
         Ddo_bookmarks_Titlecontrolalign = "Left";
         ucDdo_bookmarks.SendProperty(context, "", true, Ddo_bookmarks_Internalname, "TitleControlAlign", Ddo_bookmarks_Titlecontrolalign);
         if ( StringUtil.StrCmp(AV35WebSession.Get(context.GetMessage( "ClientInformationSaved", "")), context.GetMessage( "Y", "")) != 0 )
         {
            new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_registerwebclient(context ).execute(  new GeneXus.Core.genexus.client.SdtClientInformation(context).gxTpr_Id,  (short)(context.GetBrowserType( )),  context.GetBrowserVersion( ),  new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( )) ;
            AV35WebSession.Set(context.GetMessage( "ClientInformationSaved", ""), context.GetMessage( "Y", ""));
         }
         /* Execute user subroutine: 'LOADNOTIFICATIONS' */
         S122 ();
         if (returnInSub) return;
         lblActionsearch_Enabled = 0;
         AssignProp("", true, lblActionsearch_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(lblActionsearch_Enabled), 5, 0), true);
         if ( StringUtil.StrCmp(AV38Httprequest.Method, "GET") == 0 )
         {
            GXt_SdtWWP_DesignSystemSettings3 = AV23WWP_DesignSystemSettings;
            new GeneXus.Programs.wwpbaseobjects.wwp_getdesignsystemsettings(context ).execute( out  GXt_SdtWWP_DesignSystemSettings3) ;
            AV23WWP_DesignSystemSettings = GXt_SdtWWP_DesignSystemSettings3;
            this.executeExternalObjectMethod("", true, "gx.core.ds", "setOption", new Object[] {(string)"base-color",AV23WWP_DesignSystemSettings.gxTpr_Basecolor}, false);
            this.executeExternalObjectMethod("", true, "gx.core.ds", "setOption", new Object[] {(string)"background-color",AV23WWP_DesignSystemSettings.gxTpr_Backgroundstyle}, false);
            this.executeExternalObjectMethod("", true, "gx.core.ds", "setOption", new Object[] {(string)"menu-color",AV23WWP_DesignSystemSettings.gxTpr_Menucolor}, false);
            this.executeExternalObjectMethod("", true, "gx.core.ds", "setOption", new Object[] {(string)"font-size",AV23WWP_DesignSystemSettings.gxTpr_Fontsize}, false);
            this.executeExternalObjectMethod("", true, "WWPActions", "EmpoweredGrids_Refresh", new Object[] {}, false);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5WWPContext.gxTpr_Username)) || ( AV5WWPContext.gxTpr_Userid == 0 ) )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(Contentholder.Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( Contentholder.Pgmname), "wwpbaseobjects.notauthorized") != 0 )
         {
            new GeneXus.Programs.wwpbaseobjects.secisauthbyobjectname(context ).execute(  Contentholder.Pgmname, out  AV39IsAuthorized) ;
            if ( ! AV39IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(Contentholder.Pgmname));
               CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
               context.wjLocDisableFrm = 1;
            }
         }
      }

      protected void E221K2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         lblTextblocktitle_Caption = (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Caption;
         AssignProp("", true, lblTextblocktitle_Internalname, "Caption", lblTextblocktitle_Caption, true);
         GXt_boolean4 = false;
         new GeneXus.Programs.wwpbaseobjects.loadbreadcrumb(context ).execute(  AV30DVelop_Menu,  AV38Httprequest.ScriptName, ref  AV34Breadcrumb, ref  GXt_boolean4) ;
         AssignAttri("", true, "AV34Breadcrumb", AV34Breadcrumb);
         GxWebStd.gx_hidden_field( context, "gxhash_vBREADCRUMB_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV34Breadcrumb, "")), context));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV34Breadcrumb))) )
         {
            AV34Breadcrumb = AV35WebSession.Get("LastBreadcrumb");
            AssignAttri("", true, "AV34Breadcrumb", AV34Breadcrumb);
            GxWebStd.gx_hidden_field( context, "gxhash_vBREADCRUMB_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV34Breadcrumb, "")), context));
         }
         else
         {
            AV35WebSession.Set("LastBreadcrumb", AV34Breadcrumb);
         }
         lblSubtitle_Caption = (String.IsNullOrEmpty(StringUtil.RTrim( AV34Breadcrumb)) ? StringUtil.Format( "<span class=\"%2\">%1</span>", Contentholder.Pgmdesc, "BreadCrumb", "", "", "", "", "", "", "") : AV34Breadcrumb);
         AssignProp("", true, lblSubtitle_Internalname, "Caption", lblSubtitle_Caption, true);
         /* Execute user subroutine: 'LOADBOOKMARKS' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "AV10BookmarksData", AV10BookmarksData);
      }

      protected void E131K2( )
      {
         /* Ddo_languagesicons_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_languagesicons_Activeeventkey, "EnglishOption") == 0 )
         {
            /* Execute user subroutine: 'DO ENGLISHOPTION' */
            S152 ();
            if (returnInSub) return;
         }
         else if ( StringUtil.StrCmp(Ddo_languagesicons_Activeeventkey, "SpanishOption") == 0 )
         {
            /* Execute user subroutine: 'DO SPANISHOPTION' */
            S162 ();
            if (returnInSub) return;
         }
         else if ( StringUtil.StrCmp(Ddo_languagesicons_Activeeventkey, "PortugueseOption") == 0 )
         {
            /* Execute user subroutine: 'DO PORTUGUESEOPTION' */
            S172 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E141K2( )
      {
         /* Ddo_bookmarks_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_bookmarks_Activeeventkey, "Bookmark") == 0 )
         {
            /* Execute user subroutine: 'DO BOOKMARK' */
            S182 ();
            if (returnInSub) return;
         }
         if ( StringUtil.StrCmp(Ddo_bookmarks_Activeeventkey, "AddBookmark") == 0 )
         {
            this.executeUsercontrolMethod("", true, "BOOKMARK_MODAL_MPAGEContainer", "Confirm", "", new Object[] {});
         }
         else if ( StringUtil.StrCmp(Ddo_bookmarks_Activeeventkey, "ManageBookmarks") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("AppBookmarks"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         }
      }

      protected void E201K2( )
      {
         /* Bookmark_modal_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.EditBookmark")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.editbookmark", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.EditBookmark";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.EditBookmark";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"MPW0087",(string)"",AV38Httprequest.BaseURL+AV38Httprequest.ScriptName+(String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV38Httprequest.QueryString))) ? "" : "?"+AV38Httprequest.QueryString),(string)AV16ProgramDescription});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)""+""+""+""+""+""+""+""+""+"",(string)"",(string)""+""+""+"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0087"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E191K2( )
      {
         /* Bookmark_modal_Close Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
      }

      protected void E151K2( )
      {
         /* Ddc_notificationswc_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.Notifications.Common.WWP_MasterPageNotificationsWC")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.notifications.common.wwp_masterpagenotificationswc", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.Notifications.Common.WWP_MasterPageNotificationsWC";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.Notifications.Common.WWP_MasterPageNotificationsWC";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"MPW0087",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0087"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E161K2( )
      {
         /* Ddc_adminag_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.WWP_MasterPageTopActionsWC")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.wwp_masterpagetopactionswc", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.WWP_MasterPageTopActionsWC";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.WWP_MasterPageTopActionsWC";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"MPW0087",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0087"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E171K2( )
      {
         /* Ddc_runtimedesignsettings_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.WWP_MasterPageRuntimeSettings")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.wwp_masterpageruntimesettings", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.WWP_MasterPageRuntimeSettings";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.WWP_MasterPageRuntimeSettings";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"MPW0087",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0087"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E231K2( )
      {
         /* 'DoActionSearch' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wwpbaseobjects.wwp_search.aspx"+UrlEncode(StringUtil.RTrim(AV22SearchAux)) + "," + UrlEncode(StringUtil.BoolToStr(false)) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("wwpbaseobjects.wwp_search.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E121K2( )
      {
         /* Ddc_modules_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.WWP_WCModules")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.wwp_wcmodules", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.WWP_WCModules";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.WWP_WCModules";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"MPW0087",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0087"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E181K2( )
      {
         /* Popover_search_Onloadcomponent Routine */
         returnInSub = false;
         lblActionsearch_Enabled = 1;
         AssignProp("", true, lblActionsearch_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(lblActionsearch_Enabled), 5, 0), true);
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.WWP_SearchWC")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.wwp_searchwc", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.WWP_SearchWC";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.WWP_SearchWC";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"MPW0087",(string)"",(string)AV26Search});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"vSEARCH_MPAGE"});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0087"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean4 = AV41TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "MasterPageNotificationsWC", out  GXt_boolean4) ;
         AV41TempBoolean = GXt_boolean4;
         if ( AV41TempBoolean )
         {
            Ddc_notificationswc_Visible = true;
            ucDdc_notificationswc.SendProperty(context, "", true, Ddc_notificationswc_Internalname, "Visible", StringUtil.BoolToStr( Ddc_notificationswc_Visible));
         }
         else
         {
            Ddc_notificationswc_Visible = false;
            ucDdc_notificationswc.SendProperty(context, "", true, Ddc_notificationswc_Internalname, "Visible", StringUtil.BoolToStr( Ddc_notificationswc_Visible));
         }
         GXt_boolean4 = AV41TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWP_MasterPageTopActionsWC", out  GXt_boolean4) ;
         AV41TempBoolean = GXt_boolean4;
         if ( AV41TempBoolean )
         {
            Ddc_adminag_Visible = true;
            ucDdc_adminag.SendProperty(context, "", true, Ddc_adminag_Internalname, "Visible", StringUtil.BoolToStr( Ddc_adminag_Visible));
         }
         else
         {
            Ddc_adminag_Visible = false;
            ucDdc_adminag.SendProperty(context, "", true, Ddc_adminag_Internalname, "Visible", StringUtil.BoolToStr( Ddc_adminag_Visible));
         }
         GXt_boolean4 = AV41TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWP_MasterPageTopActionsWC", out  GXt_boolean4) ;
         AV41TempBoolean = GXt_boolean4;
         if ( AV41TempBoolean )
         {
            Ddc_runtimedesignsettings_Visible = true;
            ucDdc_runtimedesignsettings.SendProperty(context, "", true, Ddc_runtimedesignsettings_Internalname, "Visible", StringUtil.BoolToStr( Ddc_runtimedesignsettings_Visible));
         }
         else
         {
            Ddc_runtimedesignsettings_Visible = false;
            ucDdc_runtimedesignsettings.SendProperty(context, "", true, Ddc_runtimedesignsettings_Internalname, "Visible", StringUtil.BoolToStr( Ddc_runtimedesignsettings_Visible));
         }
         GXt_boolean4 = AV41TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWP_WCModules", out  GXt_boolean4) ;
         AV41TempBoolean = GXt_boolean4;
         if ( AV41TempBoolean )
         {
            Ddc_modules_Visible = true;
            ucDdc_modules.SendProperty(context, "", true, Ddc_modules_Internalname, "Visible", StringUtil.BoolToStr( Ddc_modules_Visible));
         }
         else
         {
            Ddc_modules_Visible = false;
            ucDdc_modules.SendProperty(context, "", true, Ddc_modules_Internalname, "Visible", StringUtil.BoolToStr( Ddc_modules_Visible));
         }
      }

      protected void S152( )
      {
         /* 'DO ENGLISHOPTION' Routine */
         returnInSub = false;
         if ( context.SetLanguage( "English") == 0 )
         {
            AV35WebSession.Set("isLangLoaded", "true");
            context.DoAjaxRefresh();
         }
      }

      protected void S162( )
      {
         /* 'DO SPANISHOPTION' Routine */
         returnInSub = false;
         if ( context.SetLanguage( "Spanish") == 0 )
         {
            AV35WebSession.Set("isLangLoaded", "true");
            context.DoAjaxRefresh();
         }
      }

      protected void S172( )
      {
         /* 'DO PORTUGUESEOPTION' Routine */
         returnInSub = false;
         if ( context.SetLanguage( "Portuguese") == 0 )
         {
            AV35WebSession.Set("isLangLoaded", "true");
            context.DoAjaxRefresh();
         }
      }

      protected void S182( )
      {
         /* 'DO BOOKMARK' Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", true, "BOOKMARK_MODAL_MPAGEContainer", "Confirm", "", new Object[] {});
      }

      protected void E241K2( )
      {
         /* Onmessage_gx1 Routine */
         returnInSub = false;
         if ( StringUtil.StartsWith( AV18NotificationInfo.gxTpr_Id, "WebNotification#") )
         {
            AV19WWP_WebNotification.FromJSonString(AV18NotificationInfo.gxTpr_Message, null);
            if ( ! new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_isreceivedwebnotification(context).executeUdp(  AV19WWP_WebNotification.gxTpr_Wwpwebnotificationid) )
            {
               new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_setwebnotificationreceived(context ).execute(  AV19WWP_WebNotification.gxTpr_Wwpwebnotificationid) ;
               AV20WWP_UserExtended.Load(new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( ));
               if ( AV20WWP_UserExtended.gxTpr_Wwpuserextendeddesktopnotif )
               {
                  GXKey = Crypto.GetSiteKey( );
                  GXEncryptionTmp = "wwpbaseobjects.notifications.common.wwp_visualizenotification.aspx"+UrlEncode(StringUtil.LTrimStr(AV19WWP_WebNotification.gxTpr_Wwpnotificationid,10,0));
                  GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetdesktopnotificationmsg(context).executeUdp(  AV19WWP_WebNotification.gxTpr_Wwpwebnotificationtitle,  AV19WWP_WebNotification.gxTpr_Wwpwebnotificationtext,  AV19WWP_WebNotification.gxTpr_Wwpwebnotificationicon,  formatLink("wwpbaseobjects.notifications.common.wwp_visualizenotification.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)));
               }
            }
         }
         /* Execute user subroutine: 'LOADNOTIFICATIONS' */
         S122 ();
         if (returnInSub) return;
      }

      protected void E251K2( )
      {
         /* General\GlobalEvents_Master_refreshheader Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
      }

      protected void S122( )
      {
         /* 'LOADNOTIFICATIONS' Routine */
         returnInSub = false;
         AV21NotificationsCount = 0;
         AV47Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( );
         /* Optimized group. */
         /* Using cursor H001K3 */
         pr_default.execute(1, new Object[] {AV47Udparg1});
         cV21NotificationsCount = H001K3_AV21NotificationsCount[0];
         pr_default.close(1);
         AV21NotificationsCount = (short)(AV21NotificationsCount+cV21NotificationsCount*1);
         /* End optimized group. */
         GXt_objcol_SdtNotificacionesSDT_NotificacionesSDTItem5 = AV43Notificaciones;
         new onotificaciones(context ).execute(  AV5WWPContext.gxTpr_Usuariosid,  context.GetMessage( "N", ""),  context.GetMessage( "N", ""),  true, out  GXt_objcol_SdtNotificacionesSDT_NotificacionesSDTItem5) ;
         AV43Notificaciones = GXt_objcol_SdtNotificacionesSDT_NotificacionesSDTItem5;
         AV21NotificationsCount = (short)(AV43Notificaciones.Count+AV21NotificationsCount);
         this.executeUsercontrolMethod("", true, "DDC_NOTIFICATIONSWC_MPAGEContainer", "Update", "", new Object[] {((AV21NotificationsCount>0) ? StringUtil.Trim( StringUtil.Str( (decimal)(AV21NotificationsCount), 4, 0)) : ""),(string)Ddc_notificationswc_Icon});
      }

      protected void S132( )
      {
         /* 'LOADBOOKMARKS' Routine */
         returnInSub = false;
         AV10BookmarksData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV11BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV11BookmarksDataItem.gxTpr_Eventkey = "AddBookmark";
         AV11BookmarksDataItem.gxTpr_Isdivider = false;
         AV10BookmarksData.Add(AV11BookmarksDataItem, 0);
         AV16ProgramDescription = Contentholder.Pgmdesc;
         AssignAttri("", true, "AV16ProgramDescription", AV16ProgramDescription);
         GxWebStd.gx_hidden_field( context, "gxhash_vPROGRAMDESCRIPTION_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV16ProgramDescription, "")), context));
         AV12CurrentURL = AV38Httprequest.BaseURL + AV38Httprequest.ScriptName + (String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV38Httprequest.QueryString))) ? "" : "?"+AV38Httprequest.QueryString);
         AV13GridStateCollection.FromXml(new GeneXus.Programs.wwpbaseobjects.loadmanagefiltersstate(context).executeUdp(  "AppBookmarks"), null, "Items", "");
         AV9BookmarkFound = false;
         AV48GXV2 = 1;
         while ( AV48GXV2 <= AV13GridStateCollection.Count )
         {
            AV14GridStateCollectionItem = ((GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item)AV13GridStateCollection.Item(AV48GXV2));
            if ( StringUtil.StrCmp(AV14GridStateCollectionItem.gxTpr_Gridstatexml, AV12CurrentURL) == 0 )
            {
               AV16ProgramDescription = AV14GridStateCollectionItem.gxTpr_Title;
               AssignAttri("", true, "AV16ProgramDescription", AV16ProgramDescription);
               GxWebStd.gx_hidden_field( context, "gxhash_vPROGRAMDESCRIPTION_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV16ProgramDescription, "")), context));
               AV9BookmarkFound = true;
               if (true) break;
            }
            AV48GXV2 = (int)(AV48GXV2+1);
         }
         if ( AV9BookmarkFound )
         {
            this.executeUsercontrolMethod("", true, "DDO_BOOKMARKS_MPAGEContainer", "Update", "", new Object[] {(string)"",(string)"fas fa-star "+"FontColorIconBookmarkTitleAdded"});
            AV11BookmarksDataItem.gxTpr_Title = context.GetMessage( "WWP_Bookmark_Edit", "");
            AV11BookmarksDataItem.gxTpr_Fonticon = "fas fa-star "+"FontColorIconBookmarkAdded";
         }
         else
         {
            this.executeUsercontrolMethod("", true, "DDO_BOOKMARKS_MPAGEContainer", "Update", "", new Object[] {(string)"",(string)"far fa-star "+"FontColorIconBookmarkTitle"});
            AV11BookmarksDataItem.gxTpr_Title = context.GetMessage( "WWP_Bookmark_Add", "");
            AV11BookmarksDataItem.gxTpr_Fonticon = "far fa-star "+"FontColorIconBookmark";
         }
         if ( AV13GridStateCollection.Count > 0 )
         {
            AV11BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
            AV11BookmarksDataItem.gxTpr_Isdivider = true;
            AV10BookmarksData.Add(AV11BookmarksDataItem, 0);
            AV49GXV3 = 1;
            while ( AV49GXV3 <= AV13GridStateCollection.Count )
            {
               AV14GridStateCollectionItem = ((GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item)AV13GridStateCollection.Item(AV49GXV3));
               AV11BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
               AV11BookmarksDataItem.gxTpr_Title = AV14GridStateCollectionItem.gxTpr_Title;
               AV11BookmarksDataItem.gxTpr_Link = AV14GridStateCollectionItem.gxTpr_Gridstatexml;
               GXt_char6 = AV17FontIcon;
               new GeneXus.Programs.wwpbaseobjects.getbookmarkfonticon(context ).execute(  StringUtil.StringReplace( AV14GridStateCollectionItem.gxTpr_Gridstatexml, AV38Httprequest.BaseURL, ""),  AV30DVelop_Menu, out  GXt_char6) ;
               AV17FontIcon = GXt_char6;
               AV11BookmarksDataItem.gxTpr_Fonticon = ((StringUtil.StrCmp(AV17FontIcon, "")==0) ? "FontColorIconBookmark fas fa-link" : "FontColorIconBookmark"+" "+AV17FontIcon);
               AV11BookmarksDataItem.gxTpr_Isdivider = false;
               AV10BookmarksData.Add(AV11BookmarksDataItem, 0);
               AV15IndexToAddItems = (short)(AV15IndexToAddItems+1);
               AssignAttri("", true, "AV15IndexToAddItems", StringUtil.LTrimStr( (decimal)(AV15IndexToAddItems), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vINDEXTOADDITEMS_MPAGE", GetSecureSignedToken( "gxmpage_", context.localUtil.Format( (decimal)(AV15IndexToAddItems), "ZZZ9"), context));
               AV49GXV3 = (int)(AV49GXV3+1);
            }
            AV11BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
            AV11BookmarksDataItem.gxTpr_Isdivider = true;
            AV10BookmarksData.Add(AV11BookmarksDataItem, 0);
            AV11BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
            AV11BookmarksDataItem.gxTpr_Title = context.GetMessage( "Bookmark manager", "");
            AV11BookmarksDataItem.gxTpr_Fonticon = "fas fa-cog "+"FontColorIconBookmark";
            AV11BookmarksDataItem.gxTpr_Eventkey = "ManageBookmarks";
            AV11BookmarksDataItem.gxTpr_Isdivider = false;
            AV10BookmarksData.Add(AV11BookmarksDataItem, 0);
         }
      }

      protected void S113( )
      {
         /* 'HTML CONTACTAR' Routine */
         returnInSub = false;
         lblHtml_Visible = 1;
         AssignProp("", true, lblHtml_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblHtml_Visible), 5, 0), true);
         lblHtml_Caption = context.GetMessage( "<a target=\"_blank\" href=\"https://api.whatsapp.com/send?phone=+59892761676&text=Hola soy\" id=\"whatsapp-button\" style=\"position: fixed; width: 50px; z-index: 999; bottom: 50px; right: 21px;\"><img style=\"width:100%;\" src=\"data:image/svg+xml;utf8;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iaXNvLTg4NTktMSI/Pgo8IS0tIEdlbmVyYXRvcjogQWRvYmUgSWxsdXN0cmF0b3IgMTkuMC4wLCBTVkcgRXhwb3J0IFBsdWctSW4gLiBTVkcgVmVyc2lvbjogNi4wMCBCdWlsZCAwKSAgLS0+CjxzdmcgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiB4bWxuczp4bGluaz0iaHR0cDovL3d3dy53My5vcmcvMTk5OS94bGluayIgdmVyc2lvbj0iMS4xIiBpZD0iTGF5ZXJfMSIgeD0iMHB4IiB5PSIwcHgiIHZpZXdCb3g9IjAgMCA1MTIgNTEyIiBzdHlsZT0iZW5hYmxlLWJhY2tncm91bmQ6bmV3IDAgMCA1MTIgNTEyOyIgeG1sOnNwYWNlPSJwcmVzZXJ2ZSIgd2lkdGg9IjUxMnB4IiBoZWlnaHQ9IjUxMnB4Ij4KPHBhdGggc3R5bGU9ImZpbGw6I0VERURFRDsiIGQ9Ik0wLDUxMmwzNS4zMS0xMjhDMTIuMzU5LDM0NC4yNzYsMCwzMDAuMTM4LDAsMjU0LjIzNEMwLDExNC43NTksMTE0Ljc1OSwwLDI1NS4xMTcsMCAgUzUxMiwxMTQuNzU5LDUxMiwyNTQuMjM0UzM5NS40NzYsNTEyLDI1NS4xMTcsNTEyYy00NC4xMzgsMC04Ni41MS0xNC4xMjQtMTI0LjQ2OS0zNS4zMUwwLDUxMnoiLz4KPHBhdGggc3R5bGU9ImZpbGw6IzU1Q0Q2QzsiIGQ9Ik0xMzcuNzEsNDMwLjc4Nmw3Ljk0NSw0LjQxNGMzMi42NjIsMjAuMzAzLDcwLjYyMSwzMi42NjIsMTEwLjM0NSwzMi42NjIgIGMxMTUuNjQxLDAsMjExLjg2Mi05Ni4yMjEsMjExLjg2Mi0yMTMuNjI4UzM3MS42NDEsNDQuMTM4LDI1NS4xMTcsNDQuMTM4UzQ0LjEzOCwxMzcuNzEsNDQuMTM4LDI1NC4yMzQgIGMwLDQwLjYwNywxMS40NzYsODAuMzMxLDMyLjY2MiwxMTMuODc2bDUuMjk3LDcuOTQ1bC0yMC4zMDMsNzQuMTUyTDEzNy43MSw0MzAuNzg2eiIvPgo8cGF0aCBzdHlsZT0iZmlsbDojRkVGRUZFOyIgZD0iTTE4Ny4xNDUsMTM1Ljk0NWwtMTYuNzcyLTAuODgzYy01LjI5NywwLTEwLjU5MywxLjc2Ni0xNC4xMjQsNS4yOTcgIGMtNy45NDUsNy4wNjItMjEuMTg2LDIwLjMwMy0yNC43MTcsMzcuOTU5Yy02LjE3OSwyNi40ODMsMy41MzEsNTguMjYyLDI2LjQ4Myw5MC4wNDFzNjcuMDksODIuOTc5LDE0NC43NzIsMTA1LjA0OCAgYzI0LjcxNyw3LjA2Miw0NC4xMzgsMi42NDgsNjAuMDI4LTcuMDYyYzEyLjM1OS03Ljk0NSwyMC4zMDMtMjAuMzAzLDIyLjk1Mi0zMy41NDVsMi42NDgtMTIuMzU5ICBjMC44ODMtMy41MzEtMC44ODMtNy45NDUtNC40MTQtOS43MWwtNTUuNjE0LTI1LjZjLTMuNTMxLTEuNzY2LTcuOTQ1LTAuODgzLTEwLjU5MywyLjY0OGwtMjIuMDY5LDI4LjI0OCAgYy0xLjc2NiwxLjc2Ni00LjQxNCwyLjY0OC03LjA2MiwxLjc2NmMtMTUuMDA3LTUuMjk3LTY1LjMyNC0yNi40ODMtOTIuNjktNzkuNDQ4Yy0wLjg4My0yLjY0OC0wLjg4My01LjI5NywwLjg4My03LjA2MiAgbDIxLjE4Ni0yMy44MzRjMS43NjYtMi42NDgsMi42NDgtNi4xNzksMS43NjYtOC44MjhsLTI1LjYtNTcuMzc5QzE5My4zMjQsMTM4LjU5MywxOTAuNjc2LDEzNS45NDUsMTg3LjE0NSwxMzUuOTQ1Ii8+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+Cjwvc3ZnPgo=\">", "");
         AssignProp("", true, lblHtml_Internalname, "Caption", lblHtml_Caption, true);
      }

      protected void nextLoad( )
      {
      }

      protected void E261K2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table2_81_1K2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablebookmark_modal_Internalname, tblTablebookmark_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucBookmark_modal.SetProperty("Width", Bookmark_modal_Width);
            ucBookmark_modal.SetProperty("Title", Bookmark_modal_Title);
            ucBookmark_modal.SetProperty("ConfirmType", Bookmark_modal_Confirmtype);
            ucBookmark_modal.SetProperty("BodyType", Bookmark_modal_Bodytype);
            ucBookmark_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Bookmark_modal_Internalname, "BOOKMARK_MODAL_MPAGEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"BOOKMARK_MODAL_MPAGEContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_81_1K2e( true) ;
         }
         else
         {
            wb_table2_81_1K2e( false) ;
         }
      }

      protected void wb_table1_21_1K2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUnnamedtable2_Internalname, tblUnnamedtable2_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSearch_Internalname, context.GetMessage( "Search", ""), "gx-form-item AttributeSearchLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',true,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSearch_Internalname, AV26Search, StringUtil.RTrim( context.localUtil.Format( AV26Search, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "", "", context.GetMessage( "WWP_MasterPage_Search", ""), edtavSearch_Jsonclick, 0, "AttributeSearch", "", "", "", "", 1, edtavSearch_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/WorkWithPlusMasterPage.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblActionsearch_Internalname, context.GetMessage( "<i class=\"fas fa-search ImageSearchIcon\"></i>", ""), "", "", lblActionsearch_Jsonclick, "'"+""+"'"+",true,"+"'"+"EDOACTIONSEARCH_MPAGE."+"'", "", "TextBlock", 5, "", 1, lblActionsearch_Enabled, 1, 1, "HLP_WWPBaseObjects/WorkWithPlusMasterPage.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_21_1K2e( true) ;
         }
         else
         {
            wb_table1_21_1K2e( false) ;
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
         PA1K2( ) ;
         WS1K2( ) ;
         WE1K2( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void master_styles( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/DVMessage/DVMessage.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/fontawesome_vlatest/css/all.min.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
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
         while ( idxLst <= (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)(getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Item(idxLst))), "?20269212244655", true, true, false);
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
         context.AddJavascriptSource("wwpbaseobjects/workwithplusmasterpage.js", "?20269212244656", false, true, false);
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/slimscroll/jquery.slimscroll.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/SidebarMenu/BootstrapSidebarMenuRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVMessage/pnotify.custom.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVMessage/DVMessageRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Tooltip/BootstrapTooltipRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Mask/jquery.mask.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/BootstrapSelect.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/WorkWithPlusUtilitiesRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DatePicker/DatePickerRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Popover/WWPPopoverRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         imgHeader_Internalname = "HEADER_MPAGE";
         lblShowmenu_Internalname = "SHOWMENU_MPAGE";
         Ddc_modules_Internalname = "DDC_MODULES_MPAGE";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1_MPAGE";
         edtavSearch_Internalname = "vSEARCH_MPAGE";
         lblActionsearch_Internalname = "ACTIONSEARCH_MPAGE";
         tblUnnamedtable2_Internalname = "UNNAMEDTABLE2_MPAGE";
         Ddo_languagesicons_Internalname = "DDO_LANGUAGESICONS_MPAGE";
         Ddo_bookmarks_Internalname = "DDO_BOOKMARKS_MPAGE";
         Ddc_notificationswc_Internalname = "DDC_NOTIFICATIONSWC_MPAGE";
         Ddc_adminag_Internalname = "DDC_ADMINAG_MPAGE";
         Ddc_runtimedesignsettings_Internalname = "DDC_RUNTIMEDESIGNSETTINGS_MPAGE";
         divTableuserrole_Internalname = "TABLEUSERROLE_MPAGE";
         divTableheader_Internalname = "TABLEHEADER_MPAGE";
         lblTextblocktitle_Internalname = "TEXTBLOCKTITLE_MPAGE";
         lblSubtitle_Internalname = "SUBTITLE_MPAGE";
         divTabletitle_Internalname = "TABLETITLE_MPAGE";
         divTablecontent_Internalname = "TABLECONTENT_MPAGE";
         Ucmenu_Internalname = "UCMENU_MPAGE";
         lblTextblockfooter_Internalname = "TEXTBLOCKFOOTER_MPAGE";
         divTablefooter_Internalname = "TABLEFOOTER_MPAGE";
         Ucmessage_Internalname = "UCMESSAGE_MPAGE";
         Uctooltip_Internalname = "UCTOOLTIP_MPAGE";
         Wwputilities_Internalname = "WWPUTILITIES_MPAGE";
         Wwpdatepicker_Internalname = "WWPDATEPICKER_MPAGE";
         lblHtml_Internalname = "HTML_MPAGE";
         divTablemain_Internalname = "TABLEMAIN_MPAGE";
         Popover_search_Internalname = "POPOVER_SEARCH_MPAGE";
         edtavPickerdummyvariable_Internalname = "vPICKERDUMMYVARIABLE_MPAGE";
         Bookmark_modal_Internalname = "BOOKMARK_MODAL_MPAGE";
         tblTablebookmark_modal_Internalname = "TABLEBOOKMARK_MODAL_MPAGE";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC_MPAGE";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS_MPAGE";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE_MPAGE";
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Internalname = "FORM_MPAGE";
      }

      public override void initialize_properties( )
      {
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         lblActionsearch_Enabled = 1;
         edtavSearch_Jsonclick = "";
         edtavSearch_Enabled = 1;
         edtavPickerdummyvariable_Jsonclick = "";
         lblHtml_Caption = context.GetMessage( "HTML", "");
         lblHtml_Visible = 1;
         lblSubtitle_Caption = context.GetMessage( "Developer Menu > Person", "");
         lblTextblocktitle_Caption = context.GetMessage( " Title", "");
         Ddc_runtimedesignsettings_Caption = "";
         divLayoutmaintable_Class = "Table";
         Bookmark_modal_Bodytype = "WebComponent";
         Bookmark_modal_Confirmtype = "";
         Bookmark_modal_Title = context.GetMessage( "Add/Edit Bookmark", "");
         Bookmark_modal_Width = "735";
         Popover_search_Minimumcharacters = 2;
         Popover_search_Reloadonkeychange = Convert.ToBoolean( -1);
         Popover_search_Keepopened = Convert.ToBoolean( 0);
         Popover_search_Position = "Bottom";
         Popover_search_Popoverwidth = 400;
         Popover_search_Triggerelement = "Value";
         Popover_search_Trigger = "Click";
         Popover_search_Iteminternalname = "";
         Wwputilities_Comboloadtype = "InfiniteScrolling";
         Wwputilities_Pagbarincludegoto = Convert.ToBoolean( -1);
         Wwputilities_Allowcolumnsrestore = Convert.ToBoolean( -1);
         Wwputilities_Allowcolumndragging = Convert.ToBoolean( -1);
         Wwputilities_Allowcolumnreordering = Convert.ToBoolean( -1);
         Wwputilities_Allowcolumnresizing = Convert.ToBoolean( -1);
         Wwputilities_Enableconvertcombotobootstrapselect = Convert.ToBoolean( -1);
         Wwputilities_Enableupdaterowselectionstatus = Convert.ToBoolean( -1);
         Wwputilities_Empowertabs = Convert.ToBoolean( -1);
         Wwputilities_Enablefloatinglabels = Convert.ToBoolean( -1);
         Wwputilities_Enablefixobjectfitcover = Convert.ToBoolean( -1);
         Ucmessage_Stoponerror = Convert.ToBoolean( -1);
         Ucmenu_Hidescrollincompactmenu = Convert.ToBoolean( 0);
         Ucmenu_Scrollalwaysvisible = Convert.ToBoolean( -1);
         Ucmenu_Scrollwidth = 5;
         Ucmenu_Sidebarmainclass = "page-sidebar sidebar-fixed MaterialStyle";
         Ucmenu_Includetogglebutton = Convert.ToBoolean( -1);
         Ucmenu_Searchhelperdescription = "WWP_SearchMenuOption";
         Ucmenu_Searchminchars = 0;
         Ucmenu_Searchserviceurl = "xxx";
         Ddc_runtimedesignsettings_Visible = Convert.ToBoolean( -1);
         Ddc_runtimedesignsettings_Componentwidth = 240;
         Ddc_runtimedesignsettings_Cls = "DropDownOptionsNoBackHover";
         Ddc_runtimedesignsettings_Tooltip = "WWP_StyleCustomizations";
         Ddc_runtimedesignsettings_Icon = "fa fa-cog RuntimeSettingsIcon";
         Ddc_runtimedesignsettings_Icontype = "FontIcon";
         Ddc_adminag_Visible = Convert.ToBoolean( -1);
         Ddc_adminag_Componentwidth = 260;
         Ddc_adminag_Cls = "DropDownOptionsNoBackHover";
         Ddc_adminag_Caption = context.GetMessage( "WWP_AccountCaption", "");
         Ddc_notificationswc_Visible = Convert.ToBoolean( -1);
         Ddc_notificationswc_Cls = "DropDownNotification";
         Ddc_notificationswc_Caption = "999";
         Ddc_notificationswc_Icon = "far fa-bell";
         Ddc_notificationswc_Icontype = "FontIcon";
         Ddo_bookmarks_Titlecontrolalign = "Automatic";
         Ddo_bookmarks_Cls = "DropDownOptionsNoBackHover";
         Ddo_bookmarks_Tooltip = "";
         Ddo_bookmarks_Icon = "far fa-star";
         Ddo_bookmarks_Icontype = "FontIcon";
         Ddo_languagesicons_Titlecontrolalign = "Automatic";
         Ddo_languagesicons_Cls = "DropDownOptionsHeader";
         Ddc_modules_Trigger = "Hover";
         Ddc_modules_Visible = Convert.ToBoolean( -1);
         Ddc_modules_Componentwidth = 742;
         Ddc_modules_Cls = "ModulesMenuButton";
         Ddc_modules_Caption = context.GetMessage( "Opciones", "");
         Ddc_modules_Icon = "fas fa-th ImageMenuIcon";
         Ddc_modules_Icontype = "FontIcon";
         Contentholder.setDataArea(getDataAreaObject());
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
         setEventMetadata("REFRESH_MPAGE","{handler:'Refresh',iparms:[{ctrl:'FORM_MPAGE',prop:'Caption'},{av:'AV30DVelop_Menu',fld:'vDVELOP_MENU_MPAGE',pic:''},{av:'AV38Httprequest.BaseURL',ctrl:'vHTTPREQUEST_MPAGE',prop:'Baseurl'},{av:'AV34Breadcrumb',fld:'vBREADCRUMB_MPAGE',pic:'',hsh:true,type:'svchar'},{av:'AV15IndexToAddItems',fld:'vINDEXTOADDITEMS_MPAGE',pic:'ZZZ9',hsh:true,type:'int'},{av:'AV16ProgramDescription',fld:'vPROGRAMDESCRIPTION_MPAGE',pic:'',hsh:true,type:'svchar'}]");
         setEventMetadata("REFRESH_MPAGE",",oparms:[{av:'lblTextblocktitle_Caption',ctrl:'TEXTBLOCKTITLE_MPAGE',prop:'Caption'},{av:'AV34Breadcrumb',fld:'vBREADCRUMB_MPAGE',pic:'',hsh:true,type:'svchar'},{av:'lblSubtitle_Caption',ctrl:'SUBTITLE_MPAGE',prop:'Caption'},{av:'AV10BookmarksData',fld:'vBOOKMARKSDATA_MPAGE',pic:''},{av:'AV16ProgramDescription',fld:'vPROGRAMDESCRIPTION_MPAGE',pic:'',hsh:true,type:'svchar'},{av:'AV15IndexToAddItems',fld:'vINDEXTOADDITEMS_MPAGE',pic:'ZZZ9',hsh:true,type:'int'},{av:'Ddc_notificationswc_Visible',ctrl:'DDC_NOTIFICATIONSWC_MPAGE',prop:'Visible'},{av:'Ddc_adminag_Visible',ctrl:'DDC_ADMINAG_MPAGE',prop:'Visible'},{av:'Ddc_runtimedesignsettings_Visible',ctrl:'DDC_RUNTIMEDESIGNSETTINGS_MPAGE',prop:'Visible'},{av:'Ddc_modules_Visible',ctrl:'DDC_MODULES_MPAGE',prop:'Visible'}]}");
         setEventMetadata("DDO_LANGUAGESICONS_MPAGE.ONOPTIONCLICKED_MPAGE","{handler:'E131K2',iparms:[{av:'Ddo_languagesicons_Activeeventkey',ctrl:'DDO_LANGUAGESICONS_MPAGE',prop:'ActiveEventKey'}]");
         setEventMetadata("DDO_LANGUAGESICONS_MPAGE.ONOPTIONCLICKED_MPAGE",",oparms:[]}");
         setEventMetadata("DDO_BOOKMARKS_MPAGE.ONOPTIONCLICKED_MPAGE","{handler:'E141K2',iparms:[{av:'Ddo_bookmarks_Activeeventkey',ctrl:'DDO_BOOKMARKS_MPAGE',prop:'ActiveEventKey'}]");
         setEventMetadata("DDO_BOOKMARKS_MPAGE.ONOPTIONCLICKED_MPAGE",",oparms:[]}");
         setEventMetadata("BOOKMARK_MODAL_MPAGE.ONLOADCOMPONENT_MPAGE","{handler:'E201K2',iparms:[{av:'AV38Httprequest.BaseURL',ctrl:'vHTTPREQUEST_MPAGE',prop:'Baseurl'},{av:'AV16ProgramDescription',fld:'vPROGRAMDESCRIPTION_MPAGE',pic:'',hsh:true,type:'svchar'}]");
         setEventMetadata("BOOKMARK_MODAL_MPAGE.ONLOADCOMPONENT_MPAGE",",oparms:[{ctrl:'WWPAUX_WC_MPAGE'}]}");
         setEventMetadata("BOOKMARK_MODAL_MPAGE.CLOSE_MPAGE","{handler:'E191K2',iparms:[]");
         setEventMetadata("BOOKMARK_MODAL_MPAGE.CLOSE_MPAGE",",oparms:[]}");
         setEventMetadata("DDC_NOTIFICATIONSWC_MPAGE.ONLOADCOMPONENT_MPAGE","{handler:'E151K2',iparms:[]");
         setEventMetadata("DDC_NOTIFICATIONSWC_MPAGE.ONLOADCOMPONENT_MPAGE",",oparms:[{ctrl:'WWPAUX_WC_MPAGE'}]}");
         setEventMetadata("DDC_ADMINAG_MPAGE.ONLOADCOMPONENT_MPAGE","{handler:'E161K2',iparms:[]");
         setEventMetadata("DDC_ADMINAG_MPAGE.ONLOADCOMPONENT_MPAGE",",oparms:[{ctrl:'WWPAUX_WC_MPAGE'}]}");
         setEventMetadata("DDC_RUNTIMEDESIGNSETTINGS_MPAGE.ONLOADCOMPONENT_MPAGE","{handler:'E171K2',iparms:[]");
         setEventMetadata("DDC_RUNTIMEDESIGNSETTINGS_MPAGE.ONLOADCOMPONENT_MPAGE",",oparms:[{ctrl:'WWPAUX_WC_MPAGE'}]}");
         setEventMetadata("DOACTIONSEARCH_MPAGE","{handler:'E231K2',iparms:[{av:'AV22SearchAux',fld:'vSEARCHAUX_MPAGE',pic:'',type:'svchar'}]");
         setEventMetadata("DOACTIONSEARCH_MPAGE",",oparms:[]}");
         setEventMetadata("DOSHOWMENU_MPAGE","{handler:'E111K1',iparms:[]");
         setEventMetadata("DOSHOWMENU_MPAGE",",oparms:[]}");
         setEventMetadata("DDC_MODULES_MPAGE.ONLOADCOMPONENT_MPAGE","{handler:'E121K2',iparms:[]");
         setEventMetadata("DDC_MODULES_MPAGE.ONLOADCOMPONENT_MPAGE",",oparms:[{ctrl:'WWPAUX_WC_MPAGE'}]}");
         setEventMetadata("POPOVER_SEARCH_MPAGE.ONLOADCOMPONENT_MPAGE","{handler:'E181K2',iparms:[{av:'AV26Search',fld:'vSEARCH_MPAGE',pic:'',type:'svchar'}]");
         setEventMetadata("POPOVER_SEARCH_MPAGE.ONLOADCOMPONENT_MPAGE",",oparms:[{av:'lblActionsearch_Enabled',ctrl:'ACTIONSEARCH_MPAGE',prop:'Enabled'},{ctrl:'WWPAUX_WC_MPAGE'}]}");
         setEventMetadata("GLOBALEVENTS_MPAGE.MASTER_REFRESHHEADER_MPAGE","{handler:'E251K2',iparms:[]");
         setEventMetadata("GLOBALEVENTS_MPAGE.MASTER_REFRESHHEADER_MPAGE",",oparms:[]}");
         setEventMetadata("ONMESSAGE_GX1_MPAGE","{handler:'E241K2',iparms:[{av:'AV18NotificationInfo',fld:'vNOTIFICATIONINFO_MPAGE',pic:''},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID_MPAGE',pic:'',type:'char'},{av:'AV47Udparg1',fld:'vUDPARG1_MPAGE',pic:'',type:'char'},{av:'A91WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD_MPAGE',pic:'',type:'boolean'},{av:'AV5WWPContext',fld:'vWWPCONTEXT_MPAGE',pic:''},{av:'Ddc_notificationswc_Icon',ctrl:'DDC_NOTIFICATIONSWC_MPAGE',prop:'Icon'}]");
         setEventMetadata("ONMESSAGE_GX1_MPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_PICKERDUMMYVARIABLE","{handler:'Validv_Pickerdummyvariable',iparms:[]");
         setEventMetadata("VALIDV_PICKERDUMMYVARIABLE",",oparms:[]}");
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
         Contentholder = new GXDataAreaControl();
         AV38Httprequest = new GxHttpRequest( context);
         Ddo_languagesicons_Activeeventkey = "";
         Ddo_bookmarks_Activeeventkey = "";
         AV18NotificationInfo = new GeneXus.Core.genexus.server.SdtNotificationInfo(context);
         AV34Breadcrumb = "";
         AV16ProgramDescription = "";
         GXKey = "";
         AV36LanguagesIconsData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV10BookmarksData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV30DVelop_Menu = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "AlmangoX");
         AV6DVelop_Menu_UserData = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_UserData(context);
         AV22SearchAux = "";
         A1WWPUserExtendedId = "";
         AV47Udparg1 = "";
         AV5WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         Ddo_languagesicons_Caption = "";
         sPrefix = "";
         ClassString = "";
         imgHeader_gximage = "";
         StyleString = "";
         sImgUrl = "";
         lblShowmenu_Jsonclick = "";
         ucDdc_modules = new GXUserControl();
         ucDdo_languagesicons = new GXUserControl();
         ucDdo_bookmarks = new GXUserControl();
         Ddo_bookmarks_Caption = "";
         ucDdc_notificationswc = new GXUserControl();
         ucDdc_adminag = new GXUserControl();
         ucDdc_runtimedesignsettings = new GXUserControl();
         lblTextblocktitle_Jsonclick = "";
         lblSubtitle_Jsonclick = "";
         ucUcmenu = new GXUserControl();
         lblTextblockfooter_Jsonclick = "";
         ucUcmessage = new GXUserControl();
         ucUctooltip = new GXUserControl();
         ucWwputilities = new GXUserControl();
         ucWwpdatepicker = new GXUserControl();
         lblHtml_Jsonclick = "";
         ucPopover_search = new GXUserControl();
         TempTags = "";
         AV42PickerDummyVariable = DateTime.MinValue;
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GX_FocusControl = "";
         AV26Search = "";
         AV37LanguagesIconsDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV11BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV31UserName = "";
         AV32RolesDescriptions = "";
         AV7SecRoleIdCollection = new GxSimpleCollection<short>();
         GXt_objcol_int1 = new GxSimpleCollection<short>();
         H001K2_A16SecRoleId = new short[1] ;
         H001K2_A25SecRoleName = new string[] {""} ;
         A25SecRoleName = "";
         GXt_objcol_SdtDVelop_Menu_Item2 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "AlmangoX");
         AV33Language = "";
         AV35WebSession = context.GetSession();
         AV23WWP_DesignSystemSettings = new GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings(context);
         GXt_SdtWWP_DesignSystemSettings3 = new GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings(context);
         GXEncryptionTmp = "";
         AV19WWP_WebNotification = new GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification(context);
         AV20WWP_UserExtended = new GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended(context);
         H001K3_AV21NotificationsCount = new short[1] ;
         AV43Notificaciones = new GXBaseCollection<SdtNotificacionesSDT_NotificacionesSDTItem>( context, "NotificacionesSDTItem", "AlmangoX");
         GXt_objcol_SdtNotificacionesSDT_NotificacionesSDTItem5 = new GXBaseCollection<SdtNotificacionesSDT_NotificacionesSDTItem>( context, "NotificacionesSDTItem", "AlmangoX");
         AV12CurrentURL = "";
         AV13GridStateCollection = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item>( context, "Item", "");
         AV14GridStateCollectionItem = new GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item(context);
         AV17FontIcon = "";
         GXt_char6 = "";
         sStyleString = "";
         ucBookmark_modal = new GXUserControl();
         lblActionsearch_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sDynURL = "";
         Form = new GXWebForm();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage__default(),
            new Object[][] {
                new Object[] {
               H001K2_A16SecRoleId, H001K2_A25SecRoleName
               }
               , new Object[] {
               H001K3_AV21NotificationsCount
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short GxWebError ;
      private short AV15IndexToAddItems ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short AV8SecRoleId ;
      private short A16SecRoleId ;
      private short AV21NotificationsCount ;
      private short cV21NotificationsCount ;
      private short nGotPars ;
      private short nGXWrapped ;
      private int Ddc_modules_Componentwidth ;
      private int Ddc_adminag_Componentwidth ;
      private int Ddc_runtimedesignsettings_Componentwidth ;
      private int Ucmenu_Searchminchars ;
      private int Ucmenu_Scrollwidth ;
      private int Popover_search_Popoverwidth ;
      private int Popover_search_Minimumcharacters ;
      private int lblHtml_Visible ;
      private int AV44GXV1 ;
      private int lblActionsearch_Enabled ;
      private int AV48GXV2 ;
      private int AV49GXV3 ;
      private int edtavSearch_Enabled ;
      private int idxLst ;
      private string Ddo_languagesicons_Activeeventkey ;
      private string Ddo_bookmarks_Activeeventkey ;
      private string Ddc_notificationswc_Icon ;
      private string GXKey ;
      private string A1WWPUserExtendedId ;
      private string AV47Udparg1 ;
      private string Ddc_modules_Icontype ;
      private string Ddc_modules_Icon ;
      private string Ddc_modules_Caption ;
      private string Ddc_modules_Cls ;
      private string Ddc_modules_Trigger ;
      private string Ddo_languagesicons_Caption ;
      private string Ddo_languagesicons_Cls ;
      private string Ddo_languagesicons_Titlecontrolalign ;
      private string Ddo_bookmarks_Icontype ;
      private string Ddo_bookmarks_Icon ;
      private string Ddo_bookmarks_Tooltip ;
      private string Ddo_bookmarks_Cls ;
      private string Ddo_bookmarks_Titlecontrolalign ;
      private string Ddc_notificationswc_Icontype ;
      private string Ddc_notificationswc_Caption ;
      private string Ddc_notificationswc_Cls ;
      private string Ddc_adminag_Caption ;
      private string Ddc_adminag_Cls ;
      private string Ddc_runtimedesignsettings_Icontype ;
      private string Ddc_runtimedesignsettings_Icon ;
      private string Ddc_runtimedesignsettings_Tooltip ;
      private string Ddc_runtimedesignsettings_Cls ;
      private string Ucmenu_Searchserviceurl ;
      private string Ucmenu_Searchhelperdescription ;
      private string Ucmenu_Sidebarmainclass ;
      private string Wwputilities_Comboloadtype ;
      private string Popover_search_Iteminternalname ;
      private string Popover_search_Trigger ;
      private string Popover_search_Triggerelement ;
      private string Popover_search_Position ;
      private string Bookmark_modal_Width ;
      private string Bookmark_modal_Title ;
      private string Bookmark_modal_Confirmtype ;
      private string Bookmark_modal_Bodytype ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string ClassString ;
      private string imgHeader_gximage ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgHeader_Internalname ;
      private string lblShowmenu_Internalname ;
      private string lblShowmenu_Jsonclick ;
      private string Ddc_modules_Internalname ;
      private string divTableuserrole_Internalname ;
      private string Ddo_languagesicons_Internalname ;
      private string Ddo_bookmarks_Caption ;
      private string Ddo_bookmarks_Internalname ;
      private string Ddc_notificationswc_Internalname ;
      private string Ddc_adminag_Internalname ;
      private string Ddc_runtimedesignsettings_Caption ;
      private string Ddc_runtimedesignsettings_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTabletitle_Internalname ;
      private string lblTextblocktitle_Internalname ;
      private string lblTextblocktitle_Caption ;
      private string lblTextblocktitle_Jsonclick ;
      private string lblSubtitle_Internalname ;
      private string lblSubtitle_Caption ;
      private string lblSubtitle_Jsonclick ;
      private string Ucmenu_Internalname ;
      private string divTablefooter_Internalname ;
      private string lblTextblockfooter_Internalname ;
      private string lblTextblockfooter_Jsonclick ;
      private string Ucmessage_Internalname ;
      private string Uctooltip_Internalname ;
      private string Wwputilities_Internalname ;
      private string Wwpdatepicker_Internalname ;
      private string lblHtml_Internalname ;
      private string lblHtml_Caption ;
      private string lblHtml_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Popover_search_Internalname ;
      private string TempTags ;
      private string edtavPickerdummyvariable_Internalname ;
      private string edtavPickerdummyvariable_Jsonclick ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GX_FocusControl ;
      private string edtavSearch_Internalname ;
      private string lblActionsearch_Internalname ;
      private string GXEncryptionTmp ;
      private string GXt_char6 ;
      private string sStyleString ;
      private string tblTablebookmark_modal_Internalname ;
      private string Bookmark_modal_Internalname ;
      private string tblUnnamedtable2_Internalname ;
      private string edtavSearch_Jsonclick ;
      private string lblActionsearch_Jsonclick ;
      private string sDynURL ;
      private DateTime AV42PickerDummyVariable ;
      private bool A91WWPNotificationIsRead ;
      private bool Ddc_modules_Visible ;
      private bool Ddc_notificationswc_Visible ;
      private bool Ddc_adminag_Visible ;
      private bool Ddc_runtimedesignsettings_Visible ;
      private bool Ucmenu_Includetogglebutton ;
      private bool Ucmenu_Scrollalwaysvisible ;
      private bool Ucmenu_Hidescrollincompactmenu ;
      private bool Ucmessage_Stoponerror ;
      private bool Wwputilities_Enablefixobjectfitcover ;
      private bool Wwputilities_Enablefloatinglabels ;
      private bool Wwputilities_Empowertabs ;
      private bool Wwputilities_Enableupdaterowselectionstatus ;
      private bool Wwputilities_Enableconvertcombotobootstrapselect ;
      private bool Wwputilities_Allowcolumnresizing ;
      private bool Wwputilities_Allowcolumnreordering ;
      private bool Wwputilities_Allowcolumndragging ;
      private bool Wwputilities_Allowcolumnsrestore ;
      private bool Wwputilities_Pagbarincludegoto ;
      private bool Popover_search_Keepopened ;
      private bool Popover_search_Reloadonkeychange ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool toggleJsOutput ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV39IsAuthorized ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool AV41TempBoolean ;
      private bool GXt_boolean4 ;
      private bool AV9BookmarkFound ;
      private string AV34Breadcrumb ;
      private string AV16ProgramDescription ;
      private string AV22SearchAux ;
      private string AV26Search ;
      private string AV31UserName ;
      private string AV32RolesDescriptions ;
      private string A25SecRoleName ;
      private string AV33Language ;
      private string AV12CurrentURL ;
      private string AV17FontIcon ;
      private IGxSession AV35WebSession ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXUserControl ucDdc_modules ;
      private GXUserControl ucDdo_languagesicons ;
      private GXUserControl ucDdo_bookmarks ;
      private GXUserControl ucDdc_notificationswc ;
      private GXUserControl ucDdc_adminag ;
      private GXUserControl ucDdc_runtimedesignsettings ;
      private GXUserControl ucUcmenu ;
      private GXUserControl ucUcmessage ;
      private GXUserControl ucUctooltip ;
      private GXUserControl ucWwputilities ;
      private GXUserControl ucWwpdatepicker ;
      private GXUserControl ucPopover_search ;
      private GXUserControl ucBookmark_modal ;
      private GxHttpRequest AV38Httprequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXDataAreaControl Contentholder ;
      private GeneXus.Core.genexus.server.SdtNotificationInfo AV18NotificationInfo ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV36LanguagesIconsData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV10BookmarksData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> AV30DVelop_Menu ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_UserData AV6DVelop_Menu_UserData ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV5WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV37LanguagesIconsDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV11BookmarksDataItem ;
      private GxSimpleCollection<short> AV7SecRoleIdCollection ;
      private GxSimpleCollection<short> GXt_objcol_int1 ;
      private IDataStoreProvider pr_default ;
      private short[] H001K2_A16SecRoleId ;
      private string[] H001K2_A25SecRoleName ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> GXt_objcol_SdtDVelop_Menu_Item2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings AV23WWP_DesignSystemSettings ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings GXt_SdtWWP_DesignSystemSettings3 ;
      private GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification AV19WWP_WebNotification ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended AV20WWP_UserExtended ;
      private short[] H001K3_AV21NotificationsCount ;
      private GXBaseCollection<SdtNotificacionesSDT_NotificacionesSDTItem> AV43Notificaciones ;
      private GXBaseCollection<SdtNotificacionesSDT_NotificacionesSDTItem> GXt_objcol_SdtNotificacionesSDT_NotificacionesSDTItem5 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item> AV13GridStateCollection ;
      private GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item AV14GridStateCollectionItem ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class workwithplusmasterpage__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH001K2;
          prmH001K2 = new Object[] {
          new ParDef("@AV8SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmH001K3;
          prmH001K3 = new Object[] {
          new ParDef("@AV47Udparg1",GXType.NChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H001K2", "SELECT TOP 1 [SecRoleId], [SecRoleName] FROM [SecRole] WHERE [SecRoleId] = @AV8SecRoleId ORDER BY [SecRoleId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001K2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H001K3", "SELECT COUNT(*) FROM [WWP_Notification] WHERE ([WWPUserExtendedId] = @AV47Udparg1) AND (Not [WWPNotificationIsRead] = 1) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001K3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
