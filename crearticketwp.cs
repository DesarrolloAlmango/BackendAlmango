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
   public class crearticketwp : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public crearticketwp( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public crearticketwp( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesId )
      {
         this.AV15SolicitudesId = aP0_SolicitudesId;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavTipo = new GXCombobox();
         dynavTicketmotivoid = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "SolicitudesId");
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
               gxfirstwebparm = GetFirstPar( "SolicitudesId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "SolicitudesId");
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV15SolicitudesId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV15SolicitudesId", StringUtil.LTrimStr( (decimal)(AV15SolicitudesId), 18, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15SolicitudesId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpageprompt", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpageprompt", new Object[] {context});
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
         PALH2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTLH2( ) ;
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
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlText( " "+"class=\"form-horizontal FormNoBackgroundColor\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormNoBackgroundColor\" data-gx-class=\"form-horizontal FormNoBackgroundColor\" novalidate action=\""+formatLink("crearticketwp.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV15SolicitudesId,18,0))}, new string[] {"SolicitudesId"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal FormNoBackgroundColor", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15SolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15SolicitudesId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15SolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15SolicitudesId), "ZZZZZZZZZZZZZZZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTICKET", AV22Ticket);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTICKET", AV22Ticket);
         }
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECONTENT_Width", StringUtil.RTrim( Dvpanel_tablecontent_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECONTENT_Autowidth", StringUtil.BoolToStr( Dvpanel_tablecontent_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECONTENT_Autoheight", StringUtil.BoolToStr( Dvpanel_tablecontent_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECONTENT_Cls", StringUtil.RTrim( Dvpanel_tablecontent_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECONTENT_Title", StringUtil.RTrim( Dvpanel_tablecontent_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECONTENT_Collapsible", StringUtil.BoolToStr( Dvpanel_tablecontent_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECONTENT_Collapsed", StringUtil.BoolToStr( Dvpanel_tablecontent_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECONTENT_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablecontent_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECONTENT_Iconposition", StringUtil.RTrim( Dvpanel_tablecontent_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECONTENT_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablecontent_Autoscroll));
         GxWebStd.gx_hidden_field( context, "vTICKET_Ticketid", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22Ticket.gxTpr_Ticketid), 18, 0, ".", "")));
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
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal FormNoBackgroundColor" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WELH2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTLH2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("crearticketwp.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV15SolicitudesId,18,0))}, new string[] {"SolicitudesId"})  ;
      }

      public override string GetPgmname( )
      {
         return "CrearTicketWP" ;
      }

      public override string GetPgmdesc( )
      {
         return "" ;
      }

      protected void WBLH0( )
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
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "TableMainPrompt", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-9 col-sm-6", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablecontent.SetProperty("Width", Dvpanel_tablecontent_Width);
            ucDvpanel_tablecontent.SetProperty("AutoWidth", Dvpanel_tablecontent_Autowidth);
            ucDvpanel_tablecontent.SetProperty("AutoHeight", Dvpanel_tablecontent_Autoheight);
            ucDvpanel_tablecontent.SetProperty("Cls", Dvpanel_tablecontent_Cls);
            ucDvpanel_tablecontent.SetProperty("Title", Dvpanel_tablecontent_Title);
            ucDvpanel_tablecontent.SetProperty("Collapsible", Dvpanel_tablecontent_Collapsible);
            ucDvpanel_tablecontent.SetProperty("Collapsed", Dvpanel_tablecontent_Collapsed);
            ucDvpanel_tablecontent.SetProperty("ShowCollapseIcon", Dvpanel_tablecontent_Showcollapseicon);
            ucDvpanel_tablecontent.SetProperty("IconPosition", Dvpanel_tablecontent_Iconposition);
            ucDvpanel_tablecontent.SetProperty("AutoScroll", Dvpanel_tablecontent_Autoscroll);
            ucDvpanel_tablecontent.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablecontent_Internalname, "DVPANEL_TABLECONTENTContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLECONTENTContainer"+"TableContent"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFecha_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFecha_Internalname, context.GetMessage( "Instalación", ""), " AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFecha_Internalname, context.localUtil.Format(AV5Fecha, "99/99/99"), context.localUtil.Format( AV5Fecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,19);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFecha_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CrearTicketWP.htm");
            GxWebStd.gx_bitmap( context, edtavFecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_CrearTicketWP.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavTipo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavTipo_Internalname, context.GetMessage( "Tipo", ""), " AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavTipo, cmbavTipo_Internalname, StringUtil.RTrim( AV9Tipo), 1, cmbavTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavTipo.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "", true, 0, "HLP_CrearTicketWP.htm");
            cmbavTipo.CurrentValue = StringUtil.RTrim( AV9Tipo);
            AssignProp("", false, cmbavTipo_Internalname, "Values", (string)(cmbavTipo.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynavTicketmotivoid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavTicketmotivoid_Internalname, context.GetMessage( "Motivo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavTicketmotivoid, dynavTicketmotivoid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV18TicketMotivoId), 18, 0)), 1, dynavTicketmotivoid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavTicketmotivoid.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "", true, 0, "HLP_CrearTicketWP.htm");
            dynavTicketmotivoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18TicketMotivoId), 18, 0));
            AssignProp("", false, dynavTicketmotivoid_Internalname, "Values", (string)(dynavTicketmotivoid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTicketcomentario_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTicketcomentario_Internalname, context.GetMessage( "Ticket Comentario", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavTicketcomentario_Internalname, StringUtil.RTrim( AV19TicketComentario), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", 0, 1, edtavTicketcomentario_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "250", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_CrearTicketWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTicketadjunto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTicketadjunto_Internalname, context.GetMessage( "Ticket Adjunto", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavTicketadjunto_Internalname, StringUtil.RTrim( AV20TicketAdjunto), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", 0, 1, edtavTicketadjunto_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "250", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_CrearTicketWP.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CrearTicketWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, " ", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CrearTicketWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, " ", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CrearTicketWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, " ", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CrearTicketWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, " ", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CrearTicketWP.htm");
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

      protected void STARTLH2( )
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
         Form.Meta.addItem("description", "", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPLH0( ) ;
      }

      protected void WSLH2( )
      {
         STARTLH2( ) ;
         EVTLH2( ) ;
      }

      protected void EVTLH2( )
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
                              E11LH2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E12LH2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E13LH2 ();
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

      protected void WELH2( )
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

      protected void PALH2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
               GX_FocusControl = edtavFecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvTICKETMOTIVOIDLH1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvTICKETMOTIVOID_dataLH1( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvTICKETMOTIVOID_htmlLH1( )
      {
         long gxdynajaxvalue;
         GXDLVvTICKETMOTIVOID_dataLH1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavTicketmotivoid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavTicketmotivoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 18, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavTicketmotivoid.ItemCount > 0 )
         {
            AV18TicketMotivoId = (long)(Math.Round(NumberUtil.Val( dynavTicketmotivoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18TicketMotivoId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV18TicketMotivoId", StringUtil.LTrimStr( (decimal)(AV18TicketMotivoId), 18, 0));
         }
      }

      protected void GXDLVvTICKETMOTIVOID_dataLH1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00LH2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00LH2_A1021TicketMotivoId[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H00LH2_A1022TicketMotivoDescripcion[0]));
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynavTicketmotivoid.Name = "vTICKETMOTIVOID";
            dynavTicketmotivoid.WebTags = "";
            dynavTicketmotivoid.removeAllItems();
            /* Using cursor H00LH3 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               dynavTicketmotivoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00LH3_A1021TicketMotivoId[0]), 18, 0)), H00LH3_A1022TicketMotivoDescripcion[0], 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            if ( dynavTicketmotivoid.ItemCount > 0 )
            {
               AV18TicketMotivoId = (long)(Math.Round(NumberUtil.Val( dynavTicketmotivoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18TicketMotivoId), 18, 0))), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV18TicketMotivoId", StringUtil.LTrimStr( (decimal)(AV18TicketMotivoId), 18, 0));
            }
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbavTipo.ItemCount > 0 )
         {
            AV9Tipo = cmbavTipo.getValidValue(AV9Tipo);
            AssignAttri("", false, "AV9Tipo", AV9Tipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavTipo.CurrentValue = StringUtil.RTrim( AV9Tipo);
            AssignProp("", false, cmbavTipo_Internalname, "Values", cmbavTipo.ToJavascriptSource(), true);
         }
         if ( dynavTicketmotivoid.ItemCount > 0 )
         {
            AV18TicketMotivoId = (long)(Math.Round(NumberUtil.Val( dynavTicketmotivoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18TicketMotivoId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV18TicketMotivoId", StringUtil.LTrimStr( (decimal)(AV18TicketMotivoId), 18, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavTicketmotivoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18TicketMotivoId), 18, 0));
            AssignProp("", false, dynavTicketmotivoid_Internalname, "Values", dynavTicketmotivoid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFLH2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      protected void RFLH2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E13LH2 ();
            WBLH0( ) ;
         }
      }

      protected void send_integrity_lvl_hashesLH2( )
      {
      }

      protected void before_start_formulas( )
      {
         Gx_date = DateTimeUtil.Today( context);
         fix_multi_value_controls( ) ;
      }

      protected void STRUPLH0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11LH2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Dvpanel_tablecontent_Width = cgiGet( "DVPANEL_TABLECONTENT_Width");
            Dvpanel_tablecontent_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECONTENT_Autowidth"));
            Dvpanel_tablecontent_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECONTENT_Autoheight"));
            Dvpanel_tablecontent_Cls = cgiGet( "DVPANEL_TABLECONTENT_Cls");
            Dvpanel_tablecontent_Title = cgiGet( "DVPANEL_TABLECONTENT_Title");
            Dvpanel_tablecontent_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECONTENT_Collapsible"));
            Dvpanel_tablecontent_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECONTENT_Collapsed"));
            Dvpanel_tablecontent_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECONTENT_Showcollapseicon"));
            Dvpanel_tablecontent_Iconposition = cgiGet( "DVPANEL_TABLECONTENT_Iconposition");
            Dvpanel_tablecontent_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECONTENT_Autoscroll"));
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtavFecha_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Fecha", "")}), 1, "vFECHA");
               GX_FocusControl = edtavFecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Fecha = DateTime.MinValue;
               AssignAttri("", false, "AV5Fecha", context.localUtil.Format(AV5Fecha, "99/99/99"));
            }
            else
            {
               AV5Fecha = context.localUtil.CToD( cgiGet( edtavFecha_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV5Fecha", context.localUtil.Format(AV5Fecha, "99/99/99"));
            }
            cmbavTipo.CurrentValue = cgiGet( cmbavTipo_Internalname);
            AV9Tipo = cgiGet( cmbavTipo_Internalname);
            AssignAttri("", false, "AV9Tipo", AV9Tipo);
            dynavTicketmotivoid.CurrentValue = cgiGet( dynavTicketmotivoid_Internalname);
            AV18TicketMotivoId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynavTicketmotivoid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV18TicketMotivoId", StringUtil.LTrimStr( (decimal)(AV18TicketMotivoId), 18, 0));
            AV19TicketComentario = cgiGet( edtavTicketcomentario_Internalname);
            AssignAttri("", false, "AV19TicketComentario", AV19TicketComentario);
            AV20TicketAdjunto = cgiGet( edtavTicketadjunto_Internalname);
            AssignAttri("", false, "AV20TicketAdjunto", AV20TicketAdjunto);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E11LH2 ();
         if (returnInSub) return;
      }

      protected void E11LH2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV5Fecha = Gx_date;
         AssignAttri("", false, "AV5Fecha", context.localUtil.Format(AV5Fecha, "99/99/99"));
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E12LH2 ();
         if (returnInSub) return;
      }

      protected void E12LH2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV17WebSession.Set(context.GetMessage( "FechaInstalación", ""), StringUtil.Trim( context.localUtil.DToC( AV5Fecha, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")));
         /* Execute user subroutine: 'CREARTICKET' */
         S112 ();
         if (returnInSub) return;
         this.executeExternalObjectMethod("", false, "GlobalEvents", "CrearTicket", new Object[] {(long)AV15SolicitudesId,(DateTime)AV5Fecha,(string)AV9Tipo,AV22Ticket.gxTpr_Ticketid}, true);
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22Ticket", AV22Ticket);
      }

      protected void S112( )
      {
         /* 'CREARTICKET' Routine */
         returnInSub = false;
         AV22Ticket = new SdtTicket(context);
         AV22Ticket.gxTpr_Ticketmotivoid = AV18TicketMotivoId;
         AV22Ticket.gxTpr_Ticketsolicitudid = AV15SolicitudesId;
         AV22Ticket.gxTpr_Ticketcomentario = AV19TicketComentario;
         AV22Ticket.gxTpr_Ticketestado = true;
         AV22Ticket.Insert();
         context.CommitDataStores("crearticketwp",pr_default);
      }

      protected void nextLoad( )
      {
      }

      protected void E13LH2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV15SolicitudesId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV15SolicitudesId", StringUtil.LTrimStr( (decimal)(AV15SolicitudesId), 18, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15SolicitudesId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         PALH2( ) ;
         WSLH2( ) ;
         WELH2( ) ;
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
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202610223171498", true, true, false);
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
         context.AddJavascriptSource("crearticketwp.js", "?202610223171498", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavTipo.Name = "vTIPO";
         cmbavTipo.WebTags = "";
         cmbavTipo.addItem("T", context.GetMessage( "Trabajo Registrado", ""), 0);
         cmbavTipo.addItem("E", context.GetMessage( "Ecommerce", ""), 0);
         cmbavTipo.addItem("G", context.GetMessage( "Garantia", ""), 0);
         cmbavTipo.addItem("M", context.GetMessage( "Mudanza", ""), 0);
         cmbavTipo.addItem("A", context.GetMessage( "Obra", ""), 0);
         cmbavTipo.addItem("O", context.GetMessage( "Otros", ""), 0);
         cmbavTipo.addItem("Z", context.GetMessage( "Postulacion", ""), 0);
         cmbavTipo.addItem("S", context.GetMessage( "Subasta Web", ""), 0);
         cmbavTipo.addItem("P", context.GetMessage( "Postulacion Web", ""), 0);
         if ( cmbavTipo.ItemCount > 0 )
         {
            AV9Tipo = cmbavTipo.getValidValue(AV9Tipo);
            AssignAttri("", false, "AV9Tipo", AV9Tipo);
         }
         dynavTicketmotivoid.Name = "vTICKETMOTIVOID";
         dynavTicketmotivoid.WebTags = "";
         dynavTicketmotivoid.removeAllItems();
         /* Using cursor H00LH4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            dynavTicketmotivoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00LH4_A1021TicketMotivoId[0]), 18, 0)), H00LH4_A1022TicketMotivoDescripcion[0], 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         if ( dynavTicketmotivoid.ItemCount > 0 )
         {
            AV18TicketMotivoId = (long)(Math.Round(NumberUtil.Val( dynavTicketmotivoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18TicketMotivoId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV18TicketMotivoId", StringUtil.LTrimStr( (decimal)(AV18TicketMotivoId), 18, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavFecha_Internalname = "vFECHA";
         cmbavTipo_Internalname = "vTIPO";
         dynavTicketmotivoid_Internalname = "vTICKETMOTIVOID";
         edtavTicketcomentario_Internalname = "vTICKETCOMENTARIO";
         edtavTicketadjunto_Internalname = "vTICKETADJUNTO";
         divTablecontent_Internalname = "TABLECONTENT";
         Dvpanel_tablecontent_Internalname = "DVPANEL_TABLECONTENT";
         bttBtnenter_Internalname = "BTNENTER";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         lblTextblock5_Internalname = "TEXTBLOCK5";
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
         edtavTicketadjunto_Enabled = 1;
         edtavTicketcomentario_Enabled = 1;
         dynavTicketmotivoid_Jsonclick = "";
         dynavTicketmotivoid.Enabled = 1;
         cmbavTipo_Jsonclick = "";
         cmbavTipo.Enabled = 1;
         edtavFecha_Jsonclick = "";
         edtavFecha_Enabled = 1;
         Dvpanel_tablecontent_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablecontent_Iconposition = "Right";
         Dvpanel_tablecontent_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablecontent_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablecontent_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tablecontent_Title = context.GetMessage( "Ticket", "");
         Dvpanel_tablecontent_Cls = "PanelGrayBackgroundTitle";
         Dvpanel_tablecontent_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablecontent_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablecontent_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'dynavTicketmotivoid'},{av:'AV18TicketMotivoId',fld:'vTICKETMOTIVOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV15SolicitudesId',fld:'vSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("ENTER","{handler:'E12LH2',iparms:[{av:'AV5Fecha',fld:'vFECHA',pic:'',type:'date'},{av:'AV15SolicitudesId',fld:'vSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'cmbavTipo'},{av:'AV9Tipo',fld:'vTIPO',pic:'',type:'char'},{av:'AV22Ticket',fld:'vTICKET',pic:''},{av:'dynavTicketmotivoid'},{av:'AV18TicketMotivoId',fld:'vTICKETMOTIVOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV19TicketComentario',fld:'vTICKETCOMENTARIO',pic:'',type:'char'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV22Ticket',fld:'vTICKET',pic:''}]}");
         setEventMetadata("VALIDV_FECHA","{handler:'Validv_Fecha',iparms:[]");
         setEventMetadata("VALIDV_FECHA",",oparms:[]}");
         setEventMetadata("VALIDV_TIPO","{handler:'Validv_Tipo',iparms:[]");
         setEventMetadata("VALIDV_TIPO",",oparms:[]}");
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
         AV22Ticket = new SdtTicket(context);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tablecontent = new GXUserControl();
         TempTags = "";
         AV5Fecha = DateTime.MinValue;
         AV9Tipo = "";
         AV19TicketComentario = "";
         AV20TicketAdjunto = "";
         bttBtnenter_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H00LH2_A1021TicketMotivoId = new long[1] ;
         H00LH2_A1022TicketMotivoDescripcion = new string[] {""} ;
         H00LH3_A1021TicketMotivoId = new long[1] ;
         H00LH3_A1022TicketMotivoDescripcion = new string[] {""} ;
         Gx_date = DateTime.MinValue;
         AV17WebSession = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         H00LH4_A1021TicketMotivoId = new long[1] ;
         H00LH4_A1022TicketMotivoDescripcion = new string[] {""} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.crearticketwp__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.crearticketwp__default(),
            new Object[][] {
                new Object[] {
               H00LH2_A1021TicketMotivoId, H00LH2_A1022TicketMotivoDescripcion
               }
               , new Object[] {
               H00LH3_A1021TicketMotivoId, H00LH3_A1022TicketMotivoDescripcion
               }
               , new Object[] {
               H00LH4_A1021TicketMotivoId, H00LH4_A1022TicketMotivoDescripcion
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavFecha_Enabled ;
      private int edtavTicketcomentario_Enabled ;
      private int edtavTicketadjunto_Enabled ;
      private int gxdynajaxindex ;
      private int idxLst ;
      private long AV15SolicitudesId ;
      private long wcpOAV15SolicitudesId ;
      private long AV18TicketMotivoId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Dvpanel_tablecontent_Width ;
      private string Dvpanel_tablecontent_Cls ;
      private string Dvpanel_tablecontent_Title ;
      private string Dvpanel_tablecontent_Iconposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string Dvpanel_tablecontent_Internalname ;
      private string divTablecontent_Internalname ;
      private string edtavFecha_Internalname ;
      private string TempTags ;
      private string edtavFecha_Jsonclick ;
      private string cmbavTipo_Internalname ;
      private string AV9Tipo ;
      private string cmbavTipo_Jsonclick ;
      private string dynavTicketmotivoid_Internalname ;
      private string dynavTicketmotivoid_Jsonclick ;
      private string edtavTicketcomentario_Internalname ;
      private string AV19TicketComentario ;
      private string edtavTicketadjunto_Internalname ;
      private string AV20TicketAdjunto ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string gxwrpcisep ;
      private DateTime AV5Fecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_tablecontent_Autowidth ;
      private bool Dvpanel_tablecontent_Autoheight ;
      private bool Dvpanel_tablecontent_Collapsible ;
      private bool Dvpanel_tablecontent_Collapsed ;
      private bool Dvpanel_tablecontent_Showcollapseicon ;
      private bool Dvpanel_tablecontent_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXUserControl ucDvpanel_tablecontent ;
      private IGxSession AV17WebSession ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavTipo ;
      private GXCombobox dynavTicketmotivoid ;
      private SdtTicket AV22Ticket ;
      private IDataStoreProvider pr_default ;
      private long[] H00LH2_A1021TicketMotivoId ;
      private string[] H00LH2_A1022TicketMotivoDescripcion ;
      private long[] H00LH3_A1021TicketMotivoId ;
      private string[] H00LH3_A1022TicketMotivoDescripcion ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long[] H00LH4_A1021TicketMotivoId ;
      private string[] H00LH4_A1022TicketMotivoDescripcion ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class crearticketwp__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class crearticketwp__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmH00LH2;
        prmH00LH2 = new Object[] {
        };
        Object[] prmH00LH3;
        prmH00LH3 = new Object[] {
        };
        Object[] prmH00LH4;
        prmH00LH4 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("H00LH2", "SELECT [TicketMotivoId], [TicketMotivoDescripcion] FROM [TicketMotivo] ORDER BY [TicketMotivoDescripcion] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00LH2,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H00LH3", "SELECT [TicketMotivoId], [TicketMotivoDescripcion] FROM [TicketMotivo] ORDER BY [TicketMotivoDescripcion] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00LH3,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H00LH4", "SELECT [TicketMotivoId], [TicketMotivoDescripcion] FROM [TicketMotivo] ORDER BY [TicketMotivoDescripcion] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00LH4,0, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 250);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 250);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 250);
              return;
     }
  }

}

}
