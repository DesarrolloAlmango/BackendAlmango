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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_visualizeallnotifications : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wwp_visualizeallnotifications( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_visualizeallnotifications( IGxContext context )
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
         nRC_GXsfl_36 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_36"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_36_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_36_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_36_idx = GetPar( "sGXsfl_36_idx");
         edtWWPNotificationId_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtWWPNotificationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPNotificationId_Visible), 5, 0), !bGXsfl_36_Refreshing);
         edtWWPNotificationLink_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtWWPNotificationLink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPNotificationLink_Visible), 5, 0), !bGXsfl_36_Refreshing);
         edtWWPNotificationMetadata_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtWWPNotificationMetadata_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPNotificationMetadata_Visible), 5, 0), !bGXsfl_36_Refreshing);
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
         AV21Pgmname = GetPar( "Pgmname");
         edtWWPNotificationId_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtWWPNotificationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPNotificationId_Visible), 5, 0), !bGXsfl_36_Refreshing);
         edtWWPNotificationLink_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtWWPNotificationLink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPNotificationLink_Visible), 5, 0), !bGXsfl_36_Refreshing);
         edtWWPNotificationMetadata_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtWWPNotificationMetadata_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPNotificationMetadata_Visible), 5, 0), !bGXsfl_36_Refreshing);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV21Pgmname) ;
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
         PA1F2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1F2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.notifications.common.wwp_visualizeallnotifications.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV21Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV21Pgmname, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_36", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_36), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV21Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV21Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "WWPNOTIFICATIONICON", A85WWPNotificationIcon);
         GxWebStd.gx_hidden_field( context, "WWPNOTIFICATIONCREATED", context.localUtil.TToC( A33WWPNotificationCreated, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_boolean_hidden_field( context, "WWPNOTIFICATIONISREAD", A91WWPNotificationIsRead);
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TB1_Width", StringUtil.RTrim( Dvpanel_tb1_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TB1_Autowidth", StringUtil.BoolToStr( Dvpanel_tb1_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TB1_Autoheight", StringUtil.BoolToStr( Dvpanel_tb1_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TB1_Cls", StringUtil.RTrim( Dvpanel_tb1_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TB1_Title", StringUtil.RTrim( Dvpanel_tb1_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TB1_Collapsible", StringUtil.BoolToStr( Dvpanel_tb1_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TB1_Collapsed", StringUtil.BoolToStr( Dvpanel_tb1_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TB1_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tb1_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TB1_Iconposition", StringUtil.RTrim( Dvpanel_tb1_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TB1_Autoscroll", StringUtil.BoolToStr( Dvpanel_tb1_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TB2_Width", StringUtil.RTrim( Dvpanel_tb2_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TB2_Autowidth", StringUtil.BoolToStr( Dvpanel_tb2_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TB2_Autoheight", StringUtil.BoolToStr( Dvpanel_tb2_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TB2_Cls", StringUtil.RTrim( Dvpanel_tb2_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TB2_Title", StringUtil.RTrim( Dvpanel_tb2_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TB2_Collapsible", StringUtil.BoolToStr( Dvpanel_tb2_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TB2_Collapsed", StringUtil.BoolToStr( Dvpanel_tb2_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TB2_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tb2_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TB2_Iconposition", StringUtil.RTrim( Dvpanel_tb2_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TB2_Autoscroll", StringUtil.BoolToStr( Dvpanel_tb2_Autoscroll));
         GxWebStd.gx_hidden_field( context, "WWPNOTIFICATIONID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPNotificationId_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "WWPNOTIFICATIONLINK_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPNotificationLink_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "WWPNOTIFICATIONMETADATA_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPNotificationMetadata_Visible), 5, 0, ".", "")));
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
         if ( ! ( WebComp_Wcnotificacionesold == null ) )
         {
            WebComp_Wcnotificacionesold.componentjscripts();
         }
         if ( ! ( WebComp_Webcomponent1 == null ) )
         {
            WebComp_Webcomponent1.componentjscripts();
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
            WE1F2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1F2( ) ;
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
         return formatLink("wwpbaseobjects.notifications.common.wwp_visualizeallnotifications.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Notifications.Common.WWP_VisualizeAllNotifications" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Visualize all notifications", "") ;
      }

      protected void WB1F0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tb1.SetProperty("Width", Dvpanel_tb1_Width);
            ucDvpanel_tb1.SetProperty("AutoWidth", Dvpanel_tb1_Autowidth);
            ucDvpanel_tb1.SetProperty("AutoHeight", Dvpanel_tb1_Autoheight);
            ucDvpanel_tb1.SetProperty("Cls", Dvpanel_tb1_Cls);
            ucDvpanel_tb1.SetProperty("Title", Dvpanel_tb1_Title);
            ucDvpanel_tb1.SetProperty("Collapsible", Dvpanel_tb1_Collapsible);
            ucDvpanel_tb1.SetProperty("Collapsed", Dvpanel_tb1_Collapsed);
            ucDvpanel_tb1.SetProperty("ShowCollapseIcon", Dvpanel_tb1_Showcollapseicon);
            ucDvpanel_tb1.SetProperty("IconPosition", Dvpanel_tb1_Iconposition);
            ucDvpanel_tb1.SetProperty("AutoScroll", Dvpanel_tb1_Autoscroll);
            ucDvpanel_tb1.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tb1_Internalname, "DVPANEL_TB1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TB1Container"+"TB1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTb1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0014"+"", StringUtil.RTrim( WebComp_Wcnotificacionesold_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0014"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_36_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wcnotificacionesold_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWcnotificacionesold), StringUtil.Lower( WebComp_Wcnotificacionesold_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0014"+"");
                     }
                     WebComp_Wcnotificacionesold.componentdraw();
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWcnotificacionesold), StringUtil.Lower( WebComp_Wcnotificacionesold_Component)) != 0 )
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
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tb2.SetProperty("Width", Dvpanel_tb2_Width);
            ucDvpanel_tb2.SetProperty("AutoWidth", Dvpanel_tb2_Autowidth);
            ucDvpanel_tb2.SetProperty("AutoHeight", Dvpanel_tb2_Autoheight);
            ucDvpanel_tb2.SetProperty("Cls", Dvpanel_tb2_Cls);
            ucDvpanel_tb2.SetProperty("Title", Dvpanel_tb2_Title);
            ucDvpanel_tb2.SetProperty("Collapsible", Dvpanel_tb2_Collapsible);
            ucDvpanel_tb2.SetProperty("Collapsed", Dvpanel_tb2_Collapsed);
            ucDvpanel_tb2.SetProperty("ShowCollapseIcon", Dvpanel_tb2_Showcollapseicon);
            ucDvpanel_tb2.SetProperty("IconPosition", Dvpanel_tb2_Iconposition);
            ucDvpanel_tb2.SetProperty("AutoScroll", Dvpanel_tb2_Autoscroll);
            ucDvpanel_tb2.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tb2_Internalname, "DVPANEL_TB2Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TB2Container"+"TB2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTb2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColoredActions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
            ClassString = "ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnmarkallasread_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(36), 2, 0)+","+"null"+");", context.GetMessage( "WWP_Notifications_MarkAllAsRead", ""), bttBtnmarkallasread_Jsonclick, 5, context.GetMessage( "WWP_Notifications_MarkAllAsRead", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOMARKALLASREAD\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_VisualizeAllNotifications.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
            ClassString = "ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnmanagesubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(36), 2, 0)+","+"null"+");", context.GetMessage( "WWP_Notifications_Manage", ""), bttBtnmanagesubscriptions_Jsonclick, 5, context.GetMessage( "WWP_Notifications_Manage", ""), "", StyleString, ClassString, bttBtnmanagesubscriptions_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOMANAGESUBSCRIPTIONS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_VisualizeAllNotifications.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNonotifications_Internalname, context.GetMessage( "WWP_Notifications_NoNotificationsReceived", ""), "", "", lblNonotifications_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockTitleWWP", 0, "", lblNonotifications_Visible, 1, 0, 0, "HLP_WWPBaseObjects/Notifications/Common/WWP_VisualizeAllNotifications.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetIsFreestyle(true);
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl36( ) ;
         }
         if ( wbEnd == 36 )
         {
            wbEnd = 0;
            nRC_GXsfl_36 = (int)(nGXsfl_36_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               if ( subGrid_Visible != 0 )
               {
                  sStyleString = "";
               }
               else
               {
                  sStyleString = " style=\"display:none;\"";
               }
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
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0080"+"", StringUtil.RTrim( WebComp_Webcomponent1_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0080"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_36_Refreshing )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWebcomponent1), StringUtil.Lower( WebComp_Webcomponent1_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0080"+"");
                  }
                  WebComp_Webcomponent1.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWebcomponent1), StringUtil.Lower( WebComp_Webcomponent1_Component)) != 0 )
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
         }
         if ( wbEnd == 36 )
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
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  if ( subGrid_Visible != 0 )
                  {
                     sStyleString = "";
                  }
                  else
                  {
                     sStyleString = " style=\"display:none;\"";
                  }
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

      protected void START1F2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Visualize all notifications", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1F0( ) ;
      }

      protected void WS1F2( )
      {
         START1F2( ) ;
         EVT1F2( ) ;
      }

      protected void EVT1F2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'DOMARKALLASREAD'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoMarkAllAsRead' */
                              E111F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOMANAGESUBSCRIPTIONS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoManageSubscriptions' */
                              E121F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "'DOVISUALIZE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "'DOMARKASREAD'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "'DOVISUALIZE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "'DOMARKASREAD'") == 0 ) )
                           {
                              nGXsfl_36_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_36_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_36_idx), 4, 0), 4, "0");
                              SubsflControlProps_362( ) ;
                              A86WWPNotificationTitle = cgiGet( edtWWPNotificationTitle_Internalname);
                              if ( context.localUtil.VCDateTime( cgiGet( edtavWwpnotificationcreated_Internalname), 0, 0) == 0 )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "WWPNotification Created", "")}), 1, "vWWPNOTIFICATIONCREATED");
                                 GX_FocusControl = edtavWwpnotificationcreated_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV18WWPNotificationCreated = (DateTime)(DateTime.MinValue);
                                 AssignAttri("", false, edtavWwpnotificationcreated_Internalname, context.localUtil.TToC( AV18WWPNotificationCreated, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
                              }
                              else
                              {
                                 AV18WWPNotificationCreated = context.localUtil.CToT( cgiGet( edtavWwpnotificationcreated_Internalname), 0);
                                 AssignAttri("", false, edtavWwpnotificationcreated_Internalname, context.localUtil.TToC( AV18WWPNotificationCreated, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
                              }
                              A87WWPNotificationShortDescriptio = cgiGet( edtWWPNotificationShortDescriptio_Internalname);
                              A31WWPNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPNotificationId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A88WWPNotificationLink = cgiGet( edtWWPNotificationLink_Internalname);
                              A69WWPNotificationMetadata = cgiGet( edtWWPNotificationMetadata_Internalname);
                              n69WWPNotificationMetadata = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E131F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E141F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E151F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOVISUALIZE'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoVisualize' */
                                    E161F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOMARKASREAD'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoMarkAsRead' */
                                    E171F2 ();
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
                        if ( nCmpId == 14 )
                        {
                           OldWcnotificacionesold = cgiGet( "W0014");
                           if ( ( StringUtil.Len( OldWcnotificacionesold) == 0 ) || ( StringUtil.StrCmp(OldWcnotificacionesold, WebComp_Wcnotificacionesold_Component) != 0 ) )
                           {
                              WebComp_Wcnotificacionesold = getWebComponent(GetType(), "GeneXus.Programs", OldWcnotificacionesold, new Object[] {context} );
                              WebComp_Wcnotificacionesold.ComponentInit();
                              WebComp_Wcnotificacionesold.Name = "OldWcnotificacionesold";
                              WebComp_Wcnotificacionesold_Component = OldWcnotificacionesold;
                           }
                           if ( StringUtil.Len( WebComp_Wcnotificacionesold_Component) != 0 )
                           {
                              WebComp_Wcnotificacionesold.componentprocess("W0014", "", sEvt);
                           }
                           WebComp_Wcnotificacionesold_Component = OldWcnotificacionesold;
                        }
                        else if ( nCmpId == 80 )
                        {
                           OldWebcomponent1 = cgiGet( "W0080");
                           if ( ( StringUtil.Len( OldWebcomponent1) == 0 ) || ( StringUtil.StrCmp(OldWebcomponent1, WebComp_Webcomponent1_Component) != 0 ) )
                           {
                              WebComp_Webcomponent1 = getWebComponent(GetType(), "GeneXus.Programs", OldWebcomponent1, new Object[] {context} );
                              WebComp_Webcomponent1.ComponentInit();
                              WebComp_Webcomponent1.Name = "OldWebcomponent1";
                              WebComp_Webcomponent1_Component = OldWebcomponent1;
                           }
                           WebComp_Webcomponent1.componentprocess("W0080", "", sEvt);
                           WebComp_Webcomponent1_Component = OldWebcomponent1;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE1F2( )
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

      protected void PA1F2( )
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
         SubsflControlProps_362( ) ;
         while ( nGXsfl_36_idx <= nRC_GXsfl_36 )
         {
            sendrow_362( ) ;
            nGXsfl_36_idx = ((subGrid_Islastpage==1)&&(nGXsfl_36_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_36_idx+1);
            sGXsfl_36_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_36_idx), 4, 0), 4, "0");
            SubsflControlProps_362( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV21Pgmname )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF1F2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
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
         GRID_nFirstRecordOnPage = 0;
         GRID_nCurrentRecord = 0;
         GXCCtl = "GRID_nFirstRecordOnPage_" + sGXsfl_36_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         send_integrity_hashes( ) ;
         RF1F2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV21Pgmname = "WWPBaseObjects.Notifications.Common.WWP_VisualizeAllNotifications";
         edtavWwpnotificationcreated_Enabled = 0;
      }

      protected void RF1F2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 36;
         /* Execute user event: Refresh */
         E141F2 ();
         nGXsfl_36_idx = (int)(1+GRID_nFirstRecordOnPage);
         sGXsfl_36_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_36_idx), 4, 0), 4, "0");
         SubsflControlProps_362( ) ;
         bGXsfl_36_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Visible), 5, 0, ".", "")));
         GridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         GridContainer.AddObjectProperty("Class", "FreeStyleGrid");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Visible), 5, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcnotificacionesold_Component) != 0 )
               {
                  WebComp_Wcnotificacionesold.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               WebComp_Webcomponent1.componentstart();
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_362( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            /* Using cursor H001F2 */
            pr_default.execute(0, new Object[] {AV20Udparg1, GXPagingFrom2, GXPagingTo2});
            nGXsfl_36_idx = (int)(1+GRID_nFirstRecordOnPage);
            sGXsfl_36_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_36_idx), 4, 0), 4, "0");
            SubsflControlProps_362( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A1WWPUserExtendedId = H001F2_A1WWPUserExtendedId[0];
               n1WWPUserExtendedId = H001F2_n1WWPUserExtendedId[0];
               A85WWPNotificationIcon = H001F2_A85WWPNotificationIcon[0];
               A91WWPNotificationIsRead = H001F2_A91WWPNotificationIsRead[0];
               A33WWPNotificationCreated = H001F2_A33WWPNotificationCreated[0];
               A69WWPNotificationMetadata = H001F2_A69WWPNotificationMetadata[0];
               n69WWPNotificationMetadata = H001F2_n69WWPNotificationMetadata[0];
               A88WWPNotificationLink = H001F2_A88WWPNotificationLink[0];
               A31WWPNotificationId = H001F2_A31WWPNotificationId[0];
               A87WWPNotificationShortDescriptio = H001F2_A87WWPNotificationShortDescriptio[0];
               A86WWPNotificationTitle = H001F2_A86WWPNotificationTitle[0];
               /* Execute user event: Grid.Load */
               E151F2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 36;
            WB1F0( ) ;
         }
         bGXsfl_36_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1F2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV21Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV21Pgmname, "")), context));
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
         AV20Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( );
         /* Using cursor H001F3 */
         pr_default.execute(1, new Object[] {AV20Udparg1});
         GRID_nRecordCount = H001F3_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV21Pgmname) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         if ( GRID_nEOF == 1 )
         {
            GRID_nFirstRecordOnPage = GRID_nCurrentRecord;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV21Pgmname) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV21Pgmname) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV21Pgmname) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV21Pgmname) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV21Pgmname = "WWPBaseObjects.Notifications.Common.WWP_VisualizeAllNotifications";
         edtavWwpnotificationcreated_Enabled = 0;
         edtWWPNotificationTitle_Enabled = 0;
         edtWWPNotificationShortDescriptio_Enabled = 0;
         edtWWPNotificationId_Enabled = 0;
         edtWWPNotificationLink_Enabled = 0;
         edtWWPNotificationMetadata_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1F0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E131F2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_36 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_36"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Dvpanel_tb1_Width = cgiGet( "DVPANEL_TB1_Width");
            Dvpanel_tb1_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TB1_Autowidth"));
            Dvpanel_tb1_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TB1_Autoheight"));
            Dvpanel_tb1_Cls = cgiGet( "DVPANEL_TB1_Cls");
            Dvpanel_tb1_Title = cgiGet( "DVPANEL_TB1_Title");
            Dvpanel_tb1_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TB1_Collapsible"));
            Dvpanel_tb1_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TB1_Collapsed"));
            Dvpanel_tb1_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TB1_Showcollapseicon"));
            Dvpanel_tb1_Iconposition = cgiGet( "DVPANEL_TB1_Iconposition");
            Dvpanel_tb1_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TB1_Autoscroll"));
            Dvpanel_tb2_Width = cgiGet( "DVPANEL_TB2_Width");
            Dvpanel_tb2_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TB2_Autowidth"));
            Dvpanel_tb2_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TB2_Autoheight"));
            Dvpanel_tb2_Cls = cgiGet( "DVPANEL_TB2_Cls");
            Dvpanel_tb2_Title = cgiGet( "DVPANEL_TB2_Title");
            Dvpanel_tb2_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TB2_Collapsible"));
            Dvpanel_tb2_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TB2_Collapsed"));
            Dvpanel_tb2_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TB2_Showcollapseicon"));
            Dvpanel_tb2_Iconposition = cgiGet( "DVPANEL_TB2_Iconposition");
            Dvpanel_tb2_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TB2_Autoscroll"));
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E131F2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E131F2( )
      {
         /* Start Routine */
         returnInSub = false;
         edtWWPNotificationId_Visible = 0;
         AssignProp("", false, edtWWPNotificationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPNotificationId_Visible), 5, 0), !bGXsfl_36_Refreshing);
         edtWWPNotificationLink_Visible = 0;
         AssignProp("", false, edtWWPNotificationLink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPNotificationLink_Visible), 5, 0), !bGXsfl_36_Refreshing);
         edtWWPNotificationMetadata_Visible = 0;
         AssignProp("", false, edtWWPNotificationMetadata_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPNotificationMetadata_Visible), 5, 0), !bGXsfl_36_Refreshing);
         subGrid_Rows = 50;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Form.Caption = context.GetMessage( "Visualize all notifications", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcnotificacionesold = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcnotificacionesold_Component), StringUtil.Lower( "NotificacionesOld")) != 0 )
         {
            WebComp_Wcnotificacionesold = getWebComponent(GetType(), "GeneXus.Programs", "notificacionesold", new Object[] {context} );
            WebComp_Wcnotificacionesold.ComponentInit();
            WebComp_Wcnotificacionesold.Name = "NotificacionesOld";
            WebComp_Wcnotificacionesold_Component = "NotificacionesOld";
         }
         if ( StringUtil.Len( WebComp_Wcnotificacionesold_Component) != 0 )
         {
            WebComp_Wcnotificacionesold.setjustcreated();
            WebComp_Wcnotificacionesold.componentprepare(new Object[] {(string)"W0014",(string)""});
            WebComp_Wcnotificacionesold.componentbind(new Object[] {});
         }
      }

      protected void E141F2( )
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
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         lblNonotifications_Visible = 1;
         AssignProp("", false, lblNonotifications_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblNonotifications_Visible), 5, 0), true);
         subGrid_Visible = 0;
         AssignProp("", false, "GridContainerDiv", "Visible", StringUtil.LTrimStr( (decimal)(subGrid_Visible), 5, 0), true);
         AV20Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( );
         /*  Sending Event outputs  */
      }

      private void E151F2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         lblNonotifications_Visible = 0;
         AssignProp("", false, lblNonotifications_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblNonotifications_Visible), 5, 0), true);
         subGrid_Visible = 1;
         AssignProp("", false, "GridContainerDiv", "Visible", StringUtil.LTrimStr( (decimal)(subGrid_Visible), 5, 0), true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A88WWPNotificationLink)) )
         {
            lblVisualize_Visible = 1;
         }
         else
         {
            lblVisualize_Visible = 0;
         }
         lblNotificationitemicon_Caption = StringUtil.Format( "<i class='%1 %2'></i>", "NotificationFontIcon", A85WWPNotificationIcon, "", "", "", "", "", "", "");
         AV18WWPNotificationCreated = A33WWPNotificationCreated;
         AssignAttri("", false, edtavWwpnotificationcreated_Internalname, context.localUtil.TToC( AV18WWPNotificationCreated, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         if ( A91WWPNotificationIsRead )
         {
            lblMarkasread_Caption = "<i class=\"fas fa-envelope DiscussionsSendIcon\"></i>";
            lblMarkasread_Tooltiptext = context.GetMessage( "Mark as unread", "");
            edtWWPNotificationTitle_Class = "SimpleCardAttributeTitleLight";
         }
         else
         {
            lblMarkasread_Caption = "<i class=\"fas fa-envelope-open DiscussionsSendIcon\"></i>";
            lblMarkasread_Tooltiptext = context.GetMessage( "Mark as read", "");
            edtWWPNotificationTitle_Class = "SimpleCardAttributeTitle";
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 36;
         }
         sendrow_362( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_36_Refreshing )
         {
            context.DoAjaxLoad(36, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E161F2( )
      {
         /* 'DoVisualize' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wwpbaseobjects.notifications.common.wwp_visualizenotification.aspx"+UrlEncode(StringUtil.LTrimStr(A31WWPNotificationId,10,0));
         CallWebObject(formatLink("wwpbaseobjects.notifications.common.wwp_visualizenotification.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
      }

      protected void E171F2( )
      {
         /* 'DoMarkAsRead' Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_changenotificationstatus(context ).gxep_setnotificationreadunreadbyid( ref  A31WWPNotificationId) ;
         this.executeExternalObjectMethod("", false, "GlobalEvents", "Master_RefreshHeader", new Object[] {}, true);
         GRID_nFirstRecordOnPage = 0;
         GRID_nCurrentRecord = 0;
         GXCCtl = "GRID_nFirstRecordOnPage_" + sGXsfl_36_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         gxgrGrid_refresh( subGrid_Rows, AV21Pgmname) ;
         /*  Sending Event outputs  */
      }

      protected void E111F2( )
      {
         /* 'DoMarkAllAsRead' Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_changenotificationstatus(context ).gxep_setallnotificationsofloggeduserread( ) ;
         this.executeExternalObjectMethod("", false, "GlobalEvents", "Master_RefreshHeader", new Object[] {}, true);
         GRID_nFirstRecordOnPage = 0;
         GRID_nCurrentRecord = 0;
         GXCCtl = "GRID_nFirstRecordOnPage_" + sGXsfl_36_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         gxgrGrid_refresh( subGrid_Rows, AV21Pgmname) ;
         /*  Sending Event outputs  */
      }

      protected void E121F2( )
      {
         /* 'DoManageSubscriptions' Routine */
         returnInSub = false;
         CallWebObject(formatLink("wwpbaseobjects.subscriptions.wwp_subscriptionssettings.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void S132( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV19TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyobjectname(context ).execute(  "WWP_SubscriptionsSettings", out  GXt_boolean1) ;
         AV19TempBoolean = GXt_boolean1;
         if ( ! ( AV19TempBoolean ) )
         {
            bttBtnmanagesubscriptions_Visible = 0;
            AssignProp("", false, bttBtnmanagesubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnmanagesubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV13Session.Get(AV21Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV21Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV13Session.Get(AV21Pgmname+"GridState"), null, "", "");
         }
      }

      protected void S142( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV13Session.Get(AV21Pgmname+"GridState"), null, "", "");
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV21Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV21Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "WWPBaseObjects.Notifications.Common.WWP_Notification";
         AV13Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
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
         PA1F2( ) ;
         WS1F2( ) ;
         WE1F2( ) ;
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
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wcnotificacionesold == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcnotificacionesold_Component) != 0 )
            {
               WebComp_Wcnotificacionesold.componentthemes();
            }
         }
         if ( ! ( WebComp_Webcomponent1 == null ) )
         {
            WebComp_Webcomponent1.componentthemes();
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026921224586", true, true, false);
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
         context.AddJavascriptSource("wwpbaseobjects/notifications/common/wwp_visualizeallnotifications.js", "?2026921224586", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_362( )
      {
         lblNotificationitemicon_Internalname = "NOTIFICATIONITEMICON_"+sGXsfl_36_idx;
         edtWWPNotificationTitle_Internalname = "WWPNOTIFICATIONTITLE_"+sGXsfl_36_idx;
         edtavWwpnotificationcreated_Internalname = "vWWPNOTIFICATIONCREATED_"+sGXsfl_36_idx;
         lblVisualize_Internalname = "VISUALIZE_"+sGXsfl_36_idx;
         lblMarkasread_Internalname = "MARKASREAD_"+sGXsfl_36_idx;
         edtWWPNotificationShortDescriptio_Internalname = "WWPNOTIFICATIONSHORTDESCRIPTIO_"+sGXsfl_36_idx;
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID_"+sGXsfl_36_idx;
         edtWWPNotificationLink_Internalname = "WWPNOTIFICATIONLINK_"+sGXsfl_36_idx;
         edtWWPNotificationMetadata_Internalname = "WWPNOTIFICATIONMETADATA_"+sGXsfl_36_idx;
      }

      protected void SubsflControlProps_fel_362( )
      {
         lblNotificationitemicon_Internalname = "NOTIFICATIONITEMICON_"+sGXsfl_36_fel_idx;
         edtWWPNotificationTitle_Internalname = "WWPNOTIFICATIONTITLE_"+sGXsfl_36_fel_idx;
         edtavWwpnotificationcreated_Internalname = "vWWPNOTIFICATIONCREATED_"+sGXsfl_36_fel_idx;
         lblVisualize_Internalname = "VISUALIZE_"+sGXsfl_36_fel_idx;
         lblMarkasread_Internalname = "MARKASREAD_"+sGXsfl_36_fel_idx;
         edtWWPNotificationShortDescriptio_Internalname = "WWPNOTIFICATIONSHORTDESCRIPTIO_"+sGXsfl_36_fel_idx;
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID_"+sGXsfl_36_fel_idx;
         edtWWPNotificationLink_Internalname = "WWPNOTIFICATIONLINK_"+sGXsfl_36_fel_idx;
         edtWWPNotificationMetadata_Internalname = "WWPNOTIFICATIONMETADATA_"+sGXsfl_36_fel_idx;
      }

      protected void sendrow_362( )
      {
         sGXsfl_36_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_36_idx), 4, 0), 4, "0");
         SubsflControlProps_362( ) ;
         WB1F0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_36_idx - GRID_nFirstRecordOnPage <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               subGrid_Backcolor = (int)(0xFFFFFF);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_36_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0xFFFFFF);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            /* Start of Columns property logic. */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr"+" class=\""+subGrid_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_36_idx+"\">") ;
            }
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtablefsgrid_Internalname+"_"+sGXsfl_36_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 CellMarginTop",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTablefscard_Internalname+"_"+sGXsfl_36_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"NotificationCardTable",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtable1_Internalname+"_"+sGXsfl_36_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"start",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"CellPaddingTop5",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Text block */
            GridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblNotificationitemicon_Internalname,(string)lblNotificationitemicon_Caption,(string)"",(string)"",(string)lblNotificationitemicon_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)2});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTablecontent_Internalname+"_"+sGXsfl_36_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtable2_Internalname+"_"+sGXsfl_36_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"start",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationTitle_Internalname,context.GetMessage( "Notification Title", ""),(string)"gx-form-item SimpleCardAttributeTitleLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Multiple line edit */
            ClassString = edtWWPNotificationTitle_Class;
            StyleString = "";
            ClassString = edtWWPNotificationTitle_Class;
            StyleString = "";
            GridRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationTitle_Internalname,(string)A86WWPNotificationTitle,(string)"",(string)"",(short)0,(short)1,(short)0,(short)0,(short)80,(string)"chr",(short)3,(string)"row",(short)0,(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"200",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)true,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(short)0,(string)""});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"CellMarginLeft CellPaddingTop5",(string)"start",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavWwpnotificationcreated_Internalname,context.GetMessage( "WWPNotification Created", ""),(string)"gx-form-item NotificationItemDatetimeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_36_idx + "',36)\"";
            ROClassString = "NotificationItemDatetime";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavWwpnotificationcreated_Internalname,context.localUtil.TToC( AV18WWPNotificationCreated, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( AV18WWPNotificationCreated, "99/99/99 99:99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,56);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavWwpnotificationcreated_Jsonclick,(short)0,(string)"NotificationItemDatetime",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavWwpnotificationcreated_Enabled,(short)0,(string)"text",(string)"",(short)14,(string)"chr",(short)1,(string)"row",(short)14,(short)0,(short)0,(short)36,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Text block */
            GridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblVisualize_Internalname,context.GetMessage( "<i class=\"fas fa-search DiscussionsSendIcon\"></i>", ""),(string)"",(string)"",(string)lblVisualize_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'DOVISUALIZE\\'."+sGXsfl_36_idx+"'",(string)"",(string)"TextBlock",(short)5,(string)"",(int)lblVisualize_Visible,(short)1,(short)0,(short)1});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"CellMarginLeft",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Text block */
            GridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblMarkasread_Internalname,(string)lblMarkasread_Caption,(string)"",(string)"",(string)lblMarkasread_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'DOMARKASREAD\\'."+sGXsfl_36_idx+"'",(string)"",(string)"TextBlock",(short)5,(string)lblMarkasread_Tooltiptext,(short)1,(short)1,(short)0,(short)1});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationShortDescriptio_Internalname,context.GetMessage( "Notification Short Description", ""),(string)"col-sm-3 CardNotificationAttributeDescriptionLabel",(short)0,(bool)true,(string)""});
            /* Multiple line edit */
            ClassString = "CardNotificationAttributeDescription";
            StyleString = "";
            ClassString = "CardNotificationAttributeDescription";
            StyleString = "";
            GridRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationShortDescriptio_Internalname,(string)A87WWPNotificationShortDescriptio,(string)"",(string)"",(short)0,(short)1,(short)0,(short)0,(short)80,(string)"chr",(short)3,(string)"row",(short)0,(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"200",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)true,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(short)0,(string)""});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 Invisible",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Table start */
            GridRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsgrid_Internalname+"_"+sGXsfl_36_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
            sendrow_36230( ) ;
         }
      }

      protected void sendrow_36230( )
      {
         GridRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationId_Internalname,context.GetMessage( "Notification Id", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         ROClassString = "Attribute";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A31WWPNotificationId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A31WWPNotificationId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPNotificationId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtWWPNotificationId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)36,(short)0,(short)-1,(short)0,(bool)true,(string)"WWPBaseObjects\\WWP_Id",(string)"end",(bool)false,(string)""});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         if ( GridContainer.GetWrapped() == 1 )
         {
            GridContainer.CloseTag("cell");
         }
         GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationLink_Internalname,context.GetMessage( "Notification Link", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         ROClassString = "Attribute";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationLink_Internalname,(string)A88WWPNotificationLink,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)A88WWPNotificationLink,(string)"_blank",(string)"",(string)"",(string)edtWWPNotificationLink_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtWWPNotificationLink_Visible,(short)0,(short)0,(string)"url",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)1000,(short)0,(short)0,(short)36,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Url",(string)"start",(bool)true,(string)""});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         if ( GridContainer.GetWrapped() == 1 )
         {
            GridContainer.CloseTag("cell");
         }
         GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationMetadata_Internalname,context.GetMessage( "WWPNotification Metadata", ""),(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Multiple line edit */
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GridRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPNotificationMetadata_Internalname,(string)A69WWPNotificationMetadata,(string)"",(string)"",(short)0,(int)edtWWPNotificationMetadata_Visible,(short)0,(short)0,(short)80,(string)"chr",(short)10,(string)"row",(short)0,(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"2097152",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)true,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(short)0,(string)""});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         if ( GridContainer.GetWrapped() == 1 )
         {
            GridContainer.CloseTag("cell");
         }
         if ( GridContainer.GetWrapped() == 1 )
         {
            GridContainer.CloseTag("row");
         }
         if ( GridContainer.GetWrapped() == 1 )
         {
            GridContainer.CloseTag("table");
         }
         /* End of table */
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         send_integrity_lvl_hashes1F2( ) ;
         /* End of Columns property logic. */
         GridContainer.AddRow(GridRow);
         nGXsfl_36_idx = ((subGrid_Islastpage==1)&&(nGXsfl_36_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_36_idx+1);
         sGXsfl_36_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_36_idx), 4, 0), 4, "0");
         SubsflControlProps_362( ) ;
         /* End function sendrow_362 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl36( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"36\">") ;
            sStyleString = "";
            if ( subGrid_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            GridContainer.SetIsFreestyle(true);
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Visible), 5, 0, ".", "")));
            GridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            GridContainer.AddObjectProperty("Class", "FreeStyleGrid");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Visible), 5, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", lblNotificationitemicon_Caption);
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A86WWPNotificationTitle));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtWWPNotificationTitle_Class));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( AV18WWPNotificationCreated, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavWwpnotificationcreated_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", lblVisualize_Caption);
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", lblMarkasread_Caption);
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A87WWPNotificationShortDescriptio));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A31WWPNotificationId), 10, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPNotificationId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A88WWPNotificationLink));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPNotificationLink_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A69WWPNotificationMetadata));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPNotificationMetadata_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
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
         divTb1_Internalname = "TB1";
         Dvpanel_tb1_Internalname = "DVPANEL_TB1";
         bttBtnmarkallasread_Internalname = "BTNMARKALLASREAD";
         bttBtnmanagesubscriptions_Internalname = "BTNMANAGESUBSCRIPTIONS";
         divTableheader_Internalname = "TABLEHEADER";
         lblNonotifications_Internalname = "NONOTIFICATIONS";
         lblNotificationitemicon_Internalname = "NOTIFICATIONITEMICON";
         edtWWPNotificationTitle_Internalname = "WWPNOTIFICATIONTITLE";
         edtavWwpnotificationcreated_Internalname = "vWWPNOTIFICATIONCREATED";
         lblVisualize_Internalname = "VISUALIZE";
         lblMarkasread_Internalname = "MARKASREAD";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         edtWWPNotificationShortDescriptio_Internalname = "WWPNOTIFICATIONSHORTDESCRIPTIO";
         divTablecontent_Internalname = "TABLECONTENT";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divTablefscard_Internalname = "TABLEFSCARD";
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID";
         edtWWPNotificationLink_Internalname = "WWPNOTIFICATIONLINK";
         edtWWPNotificationMetadata_Internalname = "WWPNOTIFICATIONMETADATA";
         tblUnnamedtablecontentfsgrid_Internalname = "UNNAMEDTABLECONTENTFSGRID";
         divUnnamedtablefsgrid_Internalname = "UNNAMEDTABLEFSGRID";
         divTb2_Internalname = "TB2";
         Dvpanel_tb2_Internalname = "DVPANEL_TB2";
         divTablemain_Internalname = "TABLEMAIN";
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
         lblMarkasread_Caption = context.GetMessage( "<i class=\"fas fa-envelope-open DiscussionsSendIcon\"></i>", "");
         lblVisualize_Caption = context.GetMessage( "<i class=\"fas fa-search DiscussionsSendIcon\"></i>", "");
         lblNotificationitemicon_Caption = context.GetMessage( "<i class='fas fa-pencil-alt NotificationFontIconSuccess'></i>", "");
         edtWWPNotificationLink_Jsonclick = "";
         edtWWPNotificationId_Jsonclick = "";
         lblMarkasread_Tooltiptext = "";
         lblMarkasread_Caption = context.GetMessage( "<i class=\"fas fa-envelope-open DiscussionsSendIcon\"></i>", "");
         lblVisualize_Visible = 1;
         edtavWwpnotificationcreated_Jsonclick = "";
         edtavWwpnotificationcreated_Enabled = 1;
         edtWWPNotificationTitle_Class = "SimpleCardAttributeTitle";
         lblNotificationitemicon_Caption = context.GetMessage( "<i class='fas fa-pencil-alt NotificationFontIconSuccess'></i>", "");
         subGrid_Class = "FreeStyleGrid";
         edtWWPNotificationMetadata_Enabled = 0;
         edtWWPNotificationLink_Enabled = 0;
         edtWWPNotificationId_Enabled = 0;
         edtWWPNotificationShortDescriptio_Enabled = 0;
         edtWWPNotificationTitle_Enabled = 0;
         subGrid_Backcolorstyle = 0;
         subGrid_Visible = 1;
         lblNonotifications_Visible = 1;
         bttBtnmanagesubscriptions_Visible = 1;
         Dvpanel_tb2_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tb2_Iconposition = "Right";
         Dvpanel_tb2_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tb2_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tb2_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tb2_Title = context.GetMessage( "Notificaciones del Backend", "");
         Dvpanel_tb2_Cls = "PanelGrayBackgroundTitle";
         Dvpanel_tb2_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tb2_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tb2_Width = "100%";
         Dvpanel_tb1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tb1_Iconposition = "Right";
         Dvpanel_tb1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tb1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tb1_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tb1_Title = context.GetMessage( "Notificaciones de Clientes", "");
         Dvpanel_tb1_Cls = "PanelGrayBackgroundTitle";
         Dvpanel_tb1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tb1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tb1_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Visualize all notifications", "");
         edtWWPNotificationMetadata_Visible = 1;
         edtWWPNotificationLink_Visible = 1;
         edtWWPNotificationId_Visible = 1;
         subGrid_Rows = 50;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'edtWWPNotificationId_Visible',ctrl:'WWPNOTIFICATIONID',prop:'Visible'},{av:'edtWWPNotificationLink_Visible',ctrl:'WWPNOTIFICATIONLINK',prop:'Visible'},{av:'edtWWPNotificationMetadata_Visible',ctrl:'WWPNOTIFICATIONMETADATA',prop:'Visible'},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'lblNonotifications_Visible',ctrl:'NONOTIFICATIONS',prop:'Visible'},{av:'subGrid_Visible',ctrl:'GRID',prop:'Visible'},{ctrl:'BTNMANAGESUBSCRIPTIONS',prop:'Visible'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E151F2',iparms:[{av:'A88WWPNotificationLink',fld:'WWPNOTIFICATIONLINK',pic:'',type:'svchar'},{av:'A85WWPNotificationIcon',fld:'WWPNOTIFICATIONICON',pic:'',type:'svchar'},{av:'A33WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999',type:'dtime'},{av:'A91WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:'',type:'boolean'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'lblNonotifications_Visible',ctrl:'NONOTIFICATIONS',prop:'Visible'},{av:'subGrid_Visible',ctrl:'GRID',prop:'Visible'},{av:'lblVisualize_Visible',ctrl:'VISUALIZE',prop:'Visible'},{av:'lblNotificationitemicon_Caption',ctrl:'NOTIFICATIONITEMICON',prop:'Caption'},{av:'AV18WWPNotificationCreated',fld:'vWWPNOTIFICATIONCREATED',pic:'99/99/99 99:99',type:'dtime'},{av:'lblMarkasread_Caption',ctrl:'MARKASREAD',prop:'Caption'},{av:'lblMarkasread_Tooltiptext',ctrl:'MARKASREAD',prop:'Tooltiptext'},{av:'edtWWPNotificationTitle_Class',ctrl:'WWPNOTIFICATIONTITLE',prop:'Class'}]}");
         setEventMetadata("'DOVISUALIZE'","{handler:'E161F2',iparms:[{av:'A31WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("'DOVISUALIZE'",",oparms:[{av:'A31WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("'DOMARKASREAD'","{handler:'E171F2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'edtWWPNotificationId_Visible',ctrl:'WWPNOTIFICATIONID',prop:'Visible'},{av:'edtWWPNotificationLink_Visible',ctrl:'WWPNOTIFICATIONLINK',prop:'Visible'},{av:'edtWWPNotificationMetadata_Visible',ctrl:'WWPNOTIFICATIONMETADATA',prop:'Visible'},{av:'A31WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("'DOMARKASREAD'",",oparms:[{av:'lblNonotifications_Visible',ctrl:'NONOTIFICATIONS',prop:'Visible'},{av:'subGrid_Visible',ctrl:'GRID',prop:'Visible'},{ctrl:'BTNMANAGESUBSCRIPTIONS',prop:'Visible'}]}");
         setEventMetadata("'DOMARKALLASREAD'","{handler:'E111F2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'edtWWPNotificationId_Visible',ctrl:'WWPNOTIFICATIONID',prop:'Visible'},{av:'edtWWPNotificationLink_Visible',ctrl:'WWPNOTIFICATIONLINK',prop:'Visible'},{av:'edtWWPNotificationMetadata_Visible',ctrl:'WWPNOTIFICATIONMETADATA',prop:'Visible'}]");
         setEventMetadata("'DOMARKALLASREAD'",",oparms:[{av:'lblNonotifications_Visible',ctrl:'NONOTIFICATIONS',prop:'Visible'},{av:'subGrid_Visible',ctrl:'GRID',prop:'Visible'},{ctrl:'BTNMANAGESUBSCRIPTIONS',prop:'Visible'}]}");
         setEventMetadata("'DOMANAGESUBSCRIPTIONS'","{handler:'E121F2',iparms:[]");
         setEventMetadata("'DOMANAGESUBSCRIPTIONS'",",oparms:[]}");
         setEventMetadata("GRID_FIRSTPAGE","{handler:'subgrid_firstpage',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'edtWWPNotificationId_Visible',ctrl:'WWPNOTIFICATIONID',prop:'Visible'},{av:'edtWWPNotificationLink_Visible',ctrl:'WWPNOTIFICATIONLINK',prop:'Visible'},{av:'edtWWPNotificationMetadata_Visible',ctrl:'WWPNOTIFICATIONMETADATA',prop:'Visible'},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("GRID_FIRSTPAGE",",oparms:[{av:'lblNonotifications_Visible',ctrl:'NONOTIFICATIONS',prop:'Visible'},{av:'subGrid_Visible',ctrl:'GRID',prop:'Visible'},{ctrl:'BTNMANAGESUBSCRIPTIONS',prop:'Visible'}]}");
         setEventMetadata("GRID_PREVPAGE","{handler:'subgrid_previouspage',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'edtWWPNotificationId_Visible',ctrl:'WWPNOTIFICATIONID',prop:'Visible'},{av:'edtWWPNotificationLink_Visible',ctrl:'WWPNOTIFICATIONLINK',prop:'Visible'},{av:'edtWWPNotificationMetadata_Visible',ctrl:'WWPNOTIFICATIONMETADATA',prop:'Visible'},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("GRID_PREVPAGE",",oparms:[{av:'lblNonotifications_Visible',ctrl:'NONOTIFICATIONS',prop:'Visible'},{av:'subGrid_Visible',ctrl:'GRID',prop:'Visible'},{ctrl:'BTNMANAGESUBSCRIPTIONS',prop:'Visible'}]}");
         setEventMetadata("GRID_NEXTPAGE","{handler:'subgrid_nextpage',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'edtWWPNotificationId_Visible',ctrl:'WWPNOTIFICATIONID',prop:'Visible'},{av:'edtWWPNotificationLink_Visible',ctrl:'WWPNOTIFICATIONLINK',prop:'Visible'},{av:'edtWWPNotificationMetadata_Visible',ctrl:'WWPNOTIFICATIONMETADATA',prop:'Visible'},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("GRID_NEXTPAGE",",oparms:[{av:'lblNonotifications_Visible',ctrl:'NONOTIFICATIONS',prop:'Visible'},{av:'subGrid_Visible',ctrl:'GRID',prop:'Visible'},{ctrl:'BTNMANAGESUBSCRIPTIONS',prop:'Visible'}]}");
         setEventMetadata("GRID_LASTPAGE","{handler:'subgrid_lastpage',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'edtWWPNotificationId_Visible',ctrl:'WWPNOTIFICATIONID',prop:'Visible'},{av:'edtWWPNotificationLink_Visible',ctrl:'WWPNOTIFICATIONLINK',prop:'Visible'},{av:'edtWWPNotificationMetadata_Visible',ctrl:'WWPNOTIFICATIONMETADATA',prop:'Visible'},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("GRID_LASTPAGE",",oparms:[{av:'lblNonotifications_Visible',ctrl:'NONOTIFICATIONS',prop:'Visible'},{av:'subGrid_Visible',ctrl:'GRID',prop:'Visible'},{ctrl:'BTNMANAGESUBSCRIPTIONS',prop:'Visible'}]}");
         setEventMetadata("VALIDV_WWPNOTIFICATIONCREATED","{handler:'Validv_Wwpnotificationcreated',iparms:[]");
         setEventMetadata("VALIDV_WWPNOTIFICATIONCREATED",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Wwpnotificationmetadata',iparms:[]");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV21Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         A85WWPNotificationIcon = "";
         A33WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDvpanel_tb1 = new GXUserControl();
         WebComp_Wcnotificacionesold_Component = "";
         OldWcnotificacionesold = "";
         ucDvpanel_tb2 = new GXUserControl();
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtnmarkallasread_Jsonclick = "";
         bttBtnmanagesubscriptions_Jsonclick = "";
         lblNonotifications_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         WebComp_Webcomponent1_Component = "";
         OldWebcomponent1 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A86WWPNotificationTitle = "";
         AV18WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A87WWPNotificationShortDescriptio = "";
         A88WWPNotificationLink = "";
         A69WWPNotificationMetadata = "";
         GXCCtl = "";
         AV20Udparg1 = "";
         H001F2_A1WWPUserExtendedId = new string[] {""} ;
         H001F2_n1WWPUserExtendedId = new bool[] {false} ;
         H001F2_A85WWPNotificationIcon = new string[] {""} ;
         H001F2_A91WWPNotificationIsRead = new bool[] {false} ;
         H001F2_A33WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         H001F2_A69WWPNotificationMetadata = new string[] {""} ;
         H001F2_n69WWPNotificationMetadata = new bool[] {false} ;
         H001F2_A88WWPNotificationLink = new string[] {""} ;
         H001F2_A31WWPNotificationId = new long[1] ;
         H001F2_A87WWPNotificationShortDescriptio = new string[] {""} ;
         H001F2_A86WWPNotificationTitle = new string[] {""} ;
         A1WWPUserExtendedId = "";
         H001F3_AGRID_nRecordCount = new long[1] ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         GXEncryptionTmp = "";
         AV13Session = context.GetSession();
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV8HTTPRequest = new GxHttpRequest( context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         lblNotificationitemicon_Jsonclick = "";
         ROClassString = "";
         lblVisualize_Jsonclick = "";
         lblMarkasread_Jsonclick = "";
         subGrid_Header = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_visualizeallnotifications__default(),
            new Object[][] {
                new Object[] {
               H001F2_A1WWPUserExtendedId, H001F2_n1WWPUserExtendedId, H001F2_A85WWPNotificationIcon, H001F2_A91WWPNotificationIsRead, H001F2_A33WWPNotificationCreated, H001F2_A69WWPNotificationMetadata, H001F2_n69WWPNotificationMetadata, H001F2_A88WWPNotificationLink, H001F2_A31WWPNotificationId, H001F2_A87WWPNotificationShortDescriptio,
               H001F2_A86WWPNotificationTitle
               }
               , new Object[] {
               H001F3_AGRID_nRecordCount
               }
            }
         );
         WebComp_Wcnotificacionesold = new GeneXus.Http.GXNullWebComponent();
         WebComp_Webcomponent1 = new GeneXus.Http.GXNullWebComponent();
         AV21Pgmname = "WWPBaseObjects.Notifications.Common.WWP_VisualizeAllNotifications";
         /* GeneXus formulas. */
         AV21Pgmname = "WWPBaseObjects.Notifications.Common.WWP_VisualizeAllNotifications";
         edtavWwpnotificationcreated_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int edtWWPNotificationId_Visible ;
      private int edtWWPNotificationLink_Visible ;
      private int edtWWPNotificationMetadata_Visible ;
      private int nRC_GXsfl_36 ;
      private int subGrid_Rows ;
      private int nGXsfl_36_idx=1 ;
      private int bttBtnmanagesubscriptions_Visible ;
      private int lblNonotifications_Visible ;
      private int subGrid_Visible ;
      private int subGrid_Islastpage ;
      private int edtavWwpnotificationcreated_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtWWPNotificationTitle_Enabled ;
      private int edtWWPNotificationShortDescriptio_Enabled ;
      private int edtWWPNotificationId_Enabled ;
      private int edtWWPNotificationLink_Enabled ;
      private int edtWWPNotificationMetadata_Enabled ;
      private int lblVisualize_Visible ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long A31WWPNotificationId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_36_idx="0001" ;
      private string edtWWPNotificationId_Internalname ;
      private string edtWWPNotificationLink_Internalname ;
      private string edtWWPNotificationMetadata_Internalname ;
      private string AV21Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Dvpanel_tb1_Width ;
      private string Dvpanel_tb1_Cls ;
      private string Dvpanel_tb1_Title ;
      private string Dvpanel_tb1_Iconposition ;
      private string Dvpanel_tb2_Width ;
      private string Dvpanel_tb2_Cls ;
      private string Dvpanel_tb2_Title ;
      private string Dvpanel_tb2_Iconposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string Dvpanel_tb1_Internalname ;
      private string divTb1_Internalname ;
      private string WebComp_Wcnotificacionesold_Component ;
      private string OldWcnotificacionesold ;
      private string Dvpanel_tb2_Internalname ;
      private string divTb2_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTableheader_Internalname ;
      private string TempTags ;
      private string bttBtnmarkallasread_Internalname ;
      private string bttBtnmarkallasread_Jsonclick ;
      private string bttBtnmanagesubscriptions_Internalname ;
      private string bttBtnmanagesubscriptions_Jsonclick ;
      private string lblNonotifications_Internalname ;
      private string lblNonotifications_Jsonclick ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string WebComp_Webcomponent1_Component ;
      private string OldWebcomponent1 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtWWPNotificationTitle_Internalname ;
      private string edtavWwpnotificationcreated_Internalname ;
      private string edtWWPNotificationShortDescriptio_Internalname ;
      private string GXCCtl ;
      private string AV20Udparg1 ;
      private string A1WWPUserExtendedId ;
      private string lblNotificationitemicon_Caption ;
      private string lblMarkasread_Caption ;
      private string lblMarkasread_Tooltiptext ;
      private string edtWWPNotificationTitle_Class ;
      private string GXEncryptionTmp ;
      private string lblNotificationitemicon_Internalname ;
      private string lblVisualize_Internalname ;
      private string lblMarkasread_Internalname ;
      private string sGXsfl_36_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string divUnnamedtablefsgrid_Internalname ;
      private string divTablefscard_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string lblNotificationitemicon_Jsonclick ;
      private string divTablecontent_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string ROClassString ;
      private string edtavWwpnotificationcreated_Jsonclick ;
      private string lblVisualize_Jsonclick ;
      private string lblMarkasread_Jsonclick ;
      private string tblUnnamedtablecontentfsgrid_Internalname ;
      private string edtWWPNotificationId_Jsonclick ;
      private string edtWWPNotificationLink_Jsonclick ;
      private string subGrid_Header ;
      private string lblVisualize_Caption ;
      private DateTime A33WWPNotificationCreated ;
      private DateTime AV18WWPNotificationCreated ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_36_Refreshing=false ;
      private bool A91WWPNotificationIsRead ;
      private bool Dvpanel_tb1_Autowidth ;
      private bool Dvpanel_tb1_Autoheight ;
      private bool Dvpanel_tb1_Collapsible ;
      private bool Dvpanel_tb1_Collapsed ;
      private bool Dvpanel_tb1_Showcollapseicon ;
      private bool Dvpanel_tb1_Autoscroll ;
      private bool Dvpanel_tb2_Autowidth ;
      private bool Dvpanel_tb2_Autoheight ;
      private bool Dvpanel_tb2_Collapsible ;
      private bool Dvpanel_tb2_Collapsed ;
      private bool Dvpanel_tb2_Showcollapseicon ;
      private bool Dvpanel_tb2_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n69WWPNotificationMetadata ;
      private bool gxdyncontrolsrefreshing ;
      private bool n1WWPUserExtendedId ;
      private bool returnInSub ;
      private bool bDynCreated_Wcnotificacionesold ;
      private bool gx_refresh_fired ;
      private bool AV19TempBoolean ;
      private bool GXt_boolean1 ;
      private string A69WWPNotificationMetadata ;
      private string A85WWPNotificationIcon ;
      private string A86WWPNotificationTitle ;
      private string A87WWPNotificationShortDescriptio ;
      private string A88WWPNotificationLink ;
      private IGxSession AV13Session ;
      private GXWebComponent WebComp_Wcnotificacionesold ;
      private GXWebComponent WebComp_Webcomponent1 ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tb1 ;
      private GXUserControl ucDvpanel_tb2 ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H001F2_A1WWPUserExtendedId ;
      private bool[] H001F2_n1WWPUserExtendedId ;
      private string[] H001F2_A85WWPNotificationIcon ;
      private bool[] H001F2_A91WWPNotificationIsRead ;
      private DateTime[] H001F2_A33WWPNotificationCreated ;
      private string[] H001F2_A69WWPNotificationMetadata ;
      private bool[] H001F2_n69WWPNotificationMetadata ;
      private string[] H001F2_A88WWPNotificationLink ;
      private long[] H001F2_A31WWPNotificationId ;
      private string[] H001F2_A87WWPNotificationShortDescriptio ;
      private string[] H001F2_A86WWPNotificationTitle ;
      private long[] H001F3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wwp_visualizeallnotifications__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH001F2;
          prmH001F2 = new Object[] {
          new ParDef("@AV20Udparg1",GXType.NChar,40,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH001F3;
          prmH001F3 = new Object[] {
          new ParDef("@AV20Udparg1",GXType.NChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H001F2", "SELECT [WWPUserExtendedId], [WWPNotificationIcon], [WWPNotificationIsRead], [WWPNotificationCreated], [WWPNotificationMetadata], [WWPNotificationLink], [WWPNotificationId], [WWPNotificationShortDescriptio], [WWPNotificationTitle] FROM [WWP_Notification] WHERE [WWPUserExtendedId] = @AV20Udparg1 ORDER BY [WWPNotificationCreated] DESC  OFFSET @GXPagingFrom2 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo2 > 0 THEN @GXPagingTo2 ELSE 1e9 END) AS INTEGER) ROWS ONLY",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001F2,51, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001F3", "SELECT COUNT(*) FROM [WWP_Notification] WHERE [WWPUserExtendedId] = @AV20Udparg1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001F3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 40);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(4, true);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((long[]) buf[8])[0] = rslt.getLong(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
