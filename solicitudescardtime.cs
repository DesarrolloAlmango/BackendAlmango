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
   public class solicitudescardtime : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public solicitudescardtime( )
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

      public solicitudescardtime( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_Fecha ,
                           long aP1_ProveedorID )
      {
         this.AV23Fecha = aP0_Fecha;
         this.AV28ProveedorID = aP1_ProveedorID;
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
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "Fecha");
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
                  AV23Fecha = context.localUtil.ParseDateParm( GetPar( "Fecha"));
                  AssignAttri(sPrefix, false, "AV23Fecha", context.localUtil.Format(AV23Fecha, "99/99/99"));
                  AV28ProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "ProveedorID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV28ProveedorID", StringUtil.LTrimStr( (decimal)(AV28ProveedorID), 18, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(DateTime)AV23Fecha,(long)AV28ProveedorID});
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
                  gxfirstwebparm = GetFirstPar( "Fecha");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "Fecha");
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
            PADW2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavKpi1_value_Enabled = 0;
               AssignProp(sPrefix, false, edtavKpi1_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi1_value_Enabled), 5, 0), true);
               edtavKpi1_percentagevalue_Enabled = 0;
               AssignProp(sPrefix, false, edtavKpi1_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi1_percentagevalue_Enabled), 5, 0), true);
               edtavKpi2_value_Enabled = 0;
               AssignProp(sPrefix, false, edtavKpi2_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi2_value_Enabled), 5, 0), true);
               edtavKpi2_percentagevalue_Enabled = 0;
               AssignProp(sPrefix, false, edtavKpi2_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi2_percentagevalue_Enabled), 5, 0), true);
               edtavKpi3_value_Enabled = 0;
               AssignProp(sPrefix, false, edtavKpi3_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi3_value_Enabled), 5, 0), true);
               edtavKpi3_percentagevalue_Enabled = 0;
               AssignProp(sPrefix, false, edtavKpi3_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi3_percentagevalue_Enabled), 5, 0), true);
               edtavKpi4_value_Enabled = 0;
               AssignProp(sPrefix, false, edtavKpi4_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi4_value_Enabled), 5, 0), true);
               edtavKpi4_percentagevalue_Enabled = 0;
               AssignProp(sPrefix, false, edtavKpi4_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi4_percentagevalue_Enabled), 5, 0), true);
               edtavKpi5_value_Enabled = 0;
               AssignProp(sPrefix, false, edtavKpi5_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi5_value_Enabled), 5, 0), true);
               edtavKpi5_percentagevalue_Enabled = 0;
               AssignProp(sPrefix, false, edtavKpi5_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi5_percentagevalue_Enabled), 5, 0), true);
               edtavKpi6_value_Enabled = 0;
               AssignProp(sPrefix, false, edtavKpi6_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi6_value_Enabled), 5, 0), true);
               edtavKpi6_percentagevalue_Enabled = 0;
               AssignProp(sPrefix, false, edtavKpi6_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi6_percentagevalue_Enabled), 5, 0), true);
               WSDW2( ) ;
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
            context.SendWebValue( context.GetMessage( "Solicitudes Card Time", "")) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
            if ( nGXWrapped != 1 )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "solicitudescardtime.aspx"+UrlEncode(DateTimeUtil.FormatDateParm(AV23Fecha)) + "," + UrlEncode(StringUtil.LTrimStr(AV28ProveedorID,18,0));
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("solicitudescardtime.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
               context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
               GxWebStd.gx_hidden_field( context, "_GxRefreshTimeout", "{\"Type\":\"always\",\"Time\":\"60\"}");
               AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
            }
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
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV23Fecha", context.localUtil.DToC( wcpOAV23Fecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV28ProveedorID", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV28ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vFECHA", context.localUtil.DToC( AV23Fecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLECARDS_Width", StringUtil.RTrim( Dvpanel_tablecards_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLECARDS_Autowidth", StringUtil.BoolToStr( Dvpanel_tablecards_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLECARDS_Autoheight", StringUtil.BoolToStr( Dvpanel_tablecards_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLECARDS_Cls", StringUtil.RTrim( Dvpanel_tablecards_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLECARDS_Title", StringUtil.RTrim( Dvpanel_tablecards_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLECARDS_Collapsible", StringUtil.BoolToStr( Dvpanel_tablecards_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLECARDS_Collapsed", StringUtil.BoolToStr( Dvpanel_tablecards_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLECARDS_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablecards_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLECARDS_Iconposition", StringUtil.RTrim( Dvpanel_tablecards_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLECARDS_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablecards_Autoscroll));
      }

      protected void RenderHtmlCloseFormDW2( )
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
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "</form>") ;
            }
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
         return "SolicitudesCardTime" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Solicitudes Card Time", "") ;
      }

      protected void WBDW0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "solicitudescardtime.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablecards.SetProperty("Width", Dvpanel_tablecards_Width);
            ucDvpanel_tablecards.SetProperty("AutoWidth", Dvpanel_tablecards_Autowidth);
            ucDvpanel_tablecards.SetProperty("AutoHeight", Dvpanel_tablecards_Autoheight);
            ucDvpanel_tablecards.SetProperty("Cls", Dvpanel_tablecards_Cls);
            ucDvpanel_tablecards.SetProperty("Title", Dvpanel_tablecards_Title);
            ucDvpanel_tablecards.SetProperty("Collapsible", Dvpanel_tablecards_Collapsible);
            ucDvpanel_tablecards.SetProperty("Collapsed", Dvpanel_tablecards_Collapsed);
            ucDvpanel_tablecards.SetProperty("ShowCollapseIcon", Dvpanel_tablecards_Showcollapseicon);
            ucDvpanel_tablecards.SetProperty("IconPosition", Dvpanel_tablecards_Iconposition);
            ucDvpanel_tablecards.SetProperty("AutoScroll", Dvpanel_tablecards_Autoscroll);
            ucDvpanel_tablecards.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablecards_Internalname, sPrefix+"DVPANEL_TABLECARDSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_TABLECARDSContainer"+"TableCards"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecards_Internalname, 1, 0, "px", 0, "px", "PanelCardContainer", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;justify-content:space-between;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellPadingTop TableCardNumber", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divKpi1_maintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table1_16_DW2( true) ;
         }
         else
         {
            wb_table1_16_DW2( false) ;
         }
         return  ;
      }

      protected void wb_table1_16_DW2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKpi1_value_Internalname, context.GetMessage( "KPI1_Value", ""), "col-sm-3 DashboardNumberCardNoBorderLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKpi1_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20KPI1_Value), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavKpi1_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV20KPI1_Value), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV20KPI1_Value), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,25);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKpi1_value_Jsonclick, 0, "DashboardNumberCardNoBorder", "", "", "", "", 1, edtavKpi1_value_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, false, "KPINumericValue", "end", false, "", "HLP_SolicitudesCardTime.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table2_28_DW2( true) ;
         }
         else
         {
            wb_table2_28_DW2( false) ;
         }
         return  ;
      }

      protected void wb_table2_28_DW2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellPadingTop TableCardNumber", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divKpi2_maintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table3_41_DW2( true) ;
         }
         else
         {
            wb_table3_41_DW2( false) ;
         }
         return  ;
      }

      protected void wb_table3_41_DW2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKpi2_value_Internalname, context.GetMessage( "KPI2_Value", ""), "col-sm-3 DashboardNumberCardNoBorderLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKpi2_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18KPI2_Value), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavKpi2_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV18KPI2_Value), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV18KPI2_Value), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,50);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKpi2_value_Jsonclick, 0, "DashboardNumberCardNoBorder", "", "", "", "", 1, edtavKpi2_value_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, false, "KPINumericValue", "end", false, "", "HLP_SolicitudesCardTime.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table4_53_DW2( true) ;
         }
         else
         {
            wb_table4_53_DW2( false) ;
         }
         return  ;
      }

      protected void wb_table4_53_DW2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellPadingTop TableCardNumber", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divKpi3_maintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table5_66_DW2( true) ;
         }
         else
         {
            wb_table5_66_DW2( false) ;
         }
         return  ;
      }

      protected void wb_table5_66_DW2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKpi3_value_Internalname, context.GetMessage( "KPI3_Value", ""), "col-sm-3 DashboardNumberCardNoBorderLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKpi3_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16KPI3_Value), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavKpi3_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV16KPI3_Value), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV16KPI3_Value), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,75);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKpi3_value_Jsonclick, 0, "DashboardNumberCardNoBorder", "", "", "", "", 1, edtavKpi3_value_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, false, "KPINumericValue", "end", false, "", "HLP_SolicitudesCardTime.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table6_78_DW2( true) ;
         }
         else
         {
            wb_table6_78_DW2( false) ;
         }
         return  ;
      }

      protected void wb_table6_78_DW2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellPadingTop TableCardNumber", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divKpi4_maintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table7_91_DW2( true) ;
         }
         else
         {
            wb_table7_91_DW2( false) ;
         }
         return  ;
      }

      protected void wb_table7_91_DW2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKpi4_value_Internalname, context.GetMessage( "KPI4_Value", ""), "col-sm-3 DashboardNumberCardNoBorderLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKpi4_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14KPI4_Value), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavKpi4_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV14KPI4_Value), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV14KPI4_Value), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,100);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKpi4_value_Jsonclick, 0, "DashboardNumberCardNoBorder", "", "", "", "", 1, edtavKpi4_value_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, false, "KPINumericValue", "end", false, "", "HLP_SolicitudesCardTime.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table8_103_DW2( true) ;
         }
         else
         {
            wb_table8_103_DW2( false) ;
         }
         return  ;
      }

      protected void wb_table8_103_DW2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellPadingTop", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divKpi5_maintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table9_116_DW2( true) ;
         }
         else
         {
            wb_table9_116_DW2( false) ;
         }
         return  ;
      }

      protected void wb_table9_116_DW2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKpi5_value_Internalname, context.GetMessage( "KPI5_Value", ""), "col-sm-3 DashboardNumberCardNoBorderLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKpi5_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12KPI5_Value), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavKpi5_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV12KPI5_Value), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV12KPI5_Value), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,125);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKpi5_value_Jsonclick, 0, "DashboardNumberCardNoBorder", "", "", "", "", 1, edtavKpi5_value_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, false, "KPINumericValue", "end", false, "", "HLP_SolicitudesCardTime.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table10_128_DW2( true) ;
         }
         else
         {
            wb_table10_128_DW2( false) ;
         }
         return  ;
      }

      protected void wb_table10_128_DW2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellPadingTop", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divKpi6_maintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table11_141_DW2( true) ;
         }
         else
         {
            wb_table11_141_DW2( false) ;
         }
         return  ;
      }

      protected void wb_table11_141_DW2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKpi6_value_Internalname, context.GetMessage( "KPI6_Value", ""), "col-sm-3 DashboardNumberCardNoBorderLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 150,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKpi6_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26KPI6_Value), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavKpi6_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV26KPI6_Value), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV26KPI6_Value), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,150);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKpi6_value_Jsonclick, 0, "DashboardNumberCardNoBorder", "", "", "", "", 1, edtavKpi6_value_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, false, "KPINumericValue", "end", false, "", "HLP_SolicitudesCardTime.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table12_153_DW2( true) ;
         }
         else
         {
            wb_table12_153_DW2( false) ;
         }
         return  ;
      }

      protected void wb_table12_153_DW2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
         wbLoad = true;
      }

      protected void STARTDW2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Solicitudes Card Time", ""), 0) ;
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
               STRUPDW0( ) ;
            }
         }
      }

      protected void WSDW2( )
      {
         STARTDW2( ) ;
         EVTDW2( ) ;
      }

      protected void EVTDW2( )
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
                                 STRUPDW0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPDW0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11DW2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPDW0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E12DW2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPDW0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E13DW2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPDW0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
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
                                 STRUPDW0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavKpi1_value_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
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

      protected void WEDW2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseFormDW2( ) ;
            }
         }
      }

      protected void PADW2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "solicitudescardtime.aspx")), "solicitudescardtime.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "solicitudescardtime.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "Fecha");
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
               GX_FocusControl = edtavKpi1_value_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
         RFDW2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavKpi1_value_Enabled = 0;
         AssignProp(sPrefix, false, edtavKpi1_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi1_value_Enabled), 5, 0), true);
         edtavKpi1_percentagevalue_Enabled = 0;
         AssignProp(sPrefix, false, edtavKpi1_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi1_percentagevalue_Enabled), 5, 0), true);
         edtavKpi2_value_Enabled = 0;
         AssignProp(sPrefix, false, edtavKpi2_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi2_value_Enabled), 5, 0), true);
         edtavKpi2_percentagevalue_Enabled = 0;
         AssignProp(sPrefix, false, edtavKpi2_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi2_percentagevalue_Enabled), 5, 0), true);
         edtavKpi3_value_Enabled = 0;
         AssignProp(sPrefix, false, edtavKpi3_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi3_value_Enabled), 5, 0), true);
         edtavKpi3_percentagevalue_Enabled = 0;
         AssignProp(sPrefix, false, edtavKpi3_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi3_percentagevalue_Enabled), 5, 0), true);
         edtavKpi4_value_Enabled = 0;
         AssignProp(sPrefix, false, edtavKpi4_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi4_value_Enabled), 5, 0), true);
         edtavKpi4_percentagevalue_Enabled = 0;
         AssignProp(sPrefix, false, edtavKpi4_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi4_percentagevalue_Enabled), 5, 0), true);
         edtavKpi5_value_Enabled = 0;
         AssignProp(sPrefix, false, edtavKpi5_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi5_value_Enabled), 5, 0), true);
         edtavKpi5_percentagevalue_Enabled = 0;
         AssignProp(sPrefix, false, edtavKpi5_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi5_percentagevalue_Enabled), 5, 0), true);
         edtavKpi6_value_Enabled = 0;
         AssignProp(sPrefix, false, edtavKpi6_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi6_value_Enabled), 5, 0), true);
         edtavKpi6_percentagevalue_Enabled = 0;
         AssignProp(sPrefix, false, edtavKpi6_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi6_percentagevalue_Enabled), 5, 0), true);
      }

      protected void RFDW2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E12DW2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E13DW2 ();
            WBDW0( ) ;
         }
      }

      protected void send_integrity_lvl_hashesDW2( )
      {
      }

      protected void before_start_formulas( )
      {
         edtavKpi1_value_Enabled = 0;
         AssignProp(sPrefix, false, edtavKpi1_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi1_value_Enabled), 5, 0), true);
         edtavKpi1_percentagevalue_Enabled = 0;
         AssignProp(sPrefix, false, edtavKpi1_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi1_percentagevalue_Enabled), 5, 0), true);
         edtavKpi2_value_Enabled = 0;
         AssignProp(sPrefix, false, edtavKpi2_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi2_value_Enabled), 5, 0), true);
         edtavKpi2_percentagevalue_Enabled = 0;
         AssignProp(sPrefix, false, edtavKpi2_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi2_percentagevalue_Enabled), 5, 0), true);
         edtavKpi3_value_Enabled = 0;
         AssignProp(sPrefix, false, edtavKpi3_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi3_value_Enabled), 5, 0), true);
         edtavKpi3_percentagevalue_Enabled = 0;
         AssignProp(sPrefix, false, edtavKpi3_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi3_percentagevalue_Enabled), 5, 0), true);
         edtavKpi4_value_Enabled = 0;
         AssignProp(sPrefix, false, edtavKpi4_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi4_value_Enabled), 5, 0), true);
         edtavKpi4_percentagevalue_Enabled = 0;
         AssignProp(sPrefix, false, edtavKpi4_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi4_percentagevalue_Enabled), 5, 0), true);
         edtavKpi5_value_Enabled = 0;
         AssignProp(sPrefix, false, edtavKpi5_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi5_value_Enabled), 5, 0), true);
         edtavKpi5_percentagevalue_Enabled = 0;
         AssignProp(sPrefix, false, edtavKpi5_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi5_percentagevalue_Enabled), 5, 0), true);
         edtavKpi6_value_Enabled = 0;
         AssignProp(sPrefix, false, edtavKpi6_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi6_value_Enabled), 5, 0), true);
         edtavKpi6_percentagevalue_Enabled = 0;
         AssignProp(sPrefix, false, edtavKpi6_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi6_percentagevalue_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUPDW0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11DW2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOAV23Fecha = context.localUtil.CToD( cgiGet( sPrefix+"wcpOAV23Fecha"), 0);
            wcpOAV28ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV28ProveedorID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Dvpanel_tablecards_Width = cgiGet( sPrefix+"DVPANEL_TABLECARDS_Width");
            Dvpanel_tablecards_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLECARDS_Autowidth"));
            Dvpanel_tablecards_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLECARDS_Autoheight"));
            Dvpanel_tablecards_Cls = cgiGet( sPrefix+"DVPANEL_TABLECARDS_Cls");
            Dvpanel_tablecards_Title = cgiGet( sPrefix+"DVPANEL_TABLECARDS_Title");
            Dvpanel_tablecards_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLECARDS_Collapsible"));
            Dvpanel_tablecards_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLECARDS_Collapsed"));
            Dvpanel_tablecards_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLECARDS_Showcollapseicon"));
            Dvpanel_tablecards_Iconposition = cgiGet( sPrefix+"DVPANEL_TABLECARDS_Iconposition");
            Dvpanel_tablecards_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLECARDS_Autoscroll"));
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
         E11DW2 ();
         if (returnInSub) return;
      }

      protected void E11DW2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( 1 == 2 )
         {
            if ( AV7KPI1_IsSuccessfulValue )
            {
               lblKpi1_moreinfoicon_Caption = StringUtil.Format( "<i class='%1 fas fa-caret-%2' style='font-size: 12px'></i>", "FontColorIconSuccess", "up", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, lblKpi1_moreinfoicon_Internalname, "Caption", lblKpi1_moreinfoicon_Caption, true);
               edtavKpi1_percentagevalue_Class = "DashboardPercentageSuccess";
               AssignProp(sPrefix, false, edtavKpi1_percentagevalue_Internalname, "Class", edtavKpi1_percentagevalue_Class, true);
            }
            else
            {
               lblKpi1_moreinfoicon_Caption = StringUtil.Format( "<i class='%1 fas fa-caret-%2' style='font-size: 12px'></i>", "FontColorIconDanger", "down", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, lblKpi1_moreinfoicon_Internalname, "Caption", lblKpi1_moreinfoicon_Caption, true);
               edtavKpi1_percentagevalue_Class = "DashboardPercentageDanger";
               AssignProp(sPrefix, false, edtavKpi1_percentagevalue_Internalname, "Class", edtavKpi1_percentagevalue_Class, true);
            }
            if ( AV8KPI2_IsSuccessfulValue )
            {
               lblKpi2_moreinfoicon_Caption = StringUtil.Format( "<i class='%1 fas fa-caret-%2' style='font-size: 12px'></i>", "FontColorIconSuccess", "up", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, lblKpi2_moreinfoicon_Internalname, "Caption", lblKpi2_moreinfoicon_Caption, true);
               edtavKpi2_percentagevalue_Class = "DashboardPercentageSuccess";
               AssignProp(sPrefix, false, edtavKpi2_percentagevalue_Internalname, "Class", edtavKpi2_percentagevalue_Class, true);
            }
            else
            {
               lblKpi2_moreinfoicon_Caption = StringUtil.Format( "<i class='%1 fas fa-caret-%2' style='font-size: 12px'></i>", "FontColorIconDanger", "down", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, lblKpi2_moreinfoicon_Internalname, "Caption", lblKpi2_moreinfoicon_Caption, true);
               edtavKpi2_percentagevalue_Class = "DashboardPercentageDanger";
               AssignProp(sPrefix, false, edtavKpi2_percentagevalue_Internalname, "Class", edtavKpi2_percentagevalue_Class, true);
            }
            if ( AV9KPI3_IsSuccessfulValue )
            {
               lblKpi3_moreinfoicon_Caption = StringUtil.Format( "<i class='%1 fas fa-caret-%2' style='font-size: 12px'></i>", "FontColorIconSuccess", "up", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, lblKpi3_moreinfoicon_Internalname, "Caption", lblKpi3_moreinfoicon_Caption, true);
               edtavKpi3_percentagevalue_Class = "DashboardPercentageSuccess";
               AssignProp(sPrefix, false, edtavKpi3_percentagevalue_Internalname, "Class", edtavKpi3_percentagevalue_Class, true);
            }
            else
            {
               lblKpi3_moreinfoicon_Caption = StringUtil.Format( "<i class='%1 fas fa-caret-%2' style='font-size: 12px'></i>", "FontColorIconDanger", "down", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, lblKpi3_moreinfoicon_Internalname, "Caption", lblKpi3_moreinfoicon_Caption, true);
               edtavKpi3_percentagevalue_Class = "DashboardPercentageDanger";
               AssignProp(sPrefix, false, edtavKpi3_percentagevalue_Internalname, "Class", edtavKpi3_percentagevalue_Class, true);
            }
            if ( AV10KPI4_IsSuccessfulValue )
            {
               lblKpi4_moreinfoicon_Caption = StringUtil.Format( "<i class='%1 fas fa-caret-%2' style='font-size: 12px'></i>", "FontColorIconSuccess", "up", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, lblKpi4_moreinfoicon_Internalname, "Caption", lblKpi4_moreinfoicon_Caption, true);
               edtavKpi4_percentagevalue_Class = "DashboardPercentageSuccess";
               AssignProp(sPrefix, false, edtavKpi4_percentagevalue_Internalname, "Class", edtavKpi4_percentagevalue_Class, true);
            }
            else
            {
               lblKpi4_moreinfoicon_Caption = StringUtil.Format( "<i class='%1 fas fa-caret-%2' style='font-size: 12px'></i>", "FontColorIconDanger", "down", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, lblKpi4_moreinfoicon_Internalname, "Caption", lblKpi4_moreinfoicon_Caption, true);
               edtavKpi4_percentagevalue_Class = "DashboardPercentageDanger";
               AssignProp(sPrefix, false, edtavKpi4_percentagevalue_Internalname, "Class", edtavKpi4_percentagevalue_Class, true);
            }
            if ( AV11KPI5_IsSuccessfulValue )
            {
               lblKpi5_moreinfoicon_Caption = StringUtil.Format( "<i class='%1 fas fa-caret-%2' style='font-size: 12px'></i>", "FontColorIconSuccess", "up", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, lblKpi5_moreinfoicon_Internalname, "Caption", lblKpi5_moreinfoicon_Caption, true);
               edtavKpi5_percentagevalue_Class = "DashboardPercentageSuccess";
               AssignProp(sPrefix, false, edtavKpi5_percentagevalue_Internalname, "Class", edtavKpi5_percentagevalue_Class, true);
            }
            else
            {
               lblKpi5_moreinfoicon_Caption = StringUtil.Format( "<i class='%1 fas fa-caret-%2' style='font-size: 12px'></i>", "FontColorIconDanger", "down", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, lblKpi5_moreinfoicon_Internalname, "Caption", lblKpi5_moreinfoicon_Caption, true);
               edtavKpi5_percentagevalue_Class = "DashboardPercentageDanger";
               AssignProp(sPrefix, false, edtavKpi5_percentagevalue_Internalname, "Class", edtavKpi5_percentagevalue_Class, true);
            }
            if ( AV25KPI6_IsSuccessfulValue )
            {
               lblKpi6_moreinfoicon_Caption = StringUtil.Format( "<i class='%1 fas fa-caret-%2' style='font-size: 12px'></i>", "FontColorIconSuccess", "up", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, lblKpi6_moreinfoicon_Internalname, "Caption", lblKpi6_moreinfoicon_Caption, true);
               edtavKpi6_percentagevalue_Class = "DashboardPercentageSuccess";
               AssignProp(sPrefix, false, edtavKpi6_percentagevalue_Internalname, "Class", edtavKpi6_percentagevalue_Class, true);
            }
            else
            {
               lblKpi6_moreinfoicon_Caption = StringUtil.Format( "<i class='%1 fas fa-caret-%2' style='font-size: 12px'></i>", "FontColorIconDanger", "down", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, lblKpi6_moreinfoicon_Internalname, "Caption", lblKpi6_moreinfoicon_Caption, true);
               edtavKpi6_percentagevalue_Class = "DashboardPercentageDanger";
               AssignProp(sPrefix, false, edtavKpi6_percentagevalue_Internalname, "Class", edtavKpi6_percentagevalue_Class, true);
            }
         }
         /* Execute user subroutine: 'CANTIDAD SOLICITUDES' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E12DW2( )
      {
         /* Refresh Routine */
         returnInSub = false;
      }

      protected void S112( )
      {
         /* 'CANTIDAD SOLICITUDES' Routine */
         returnInSub = false;
         edtavKpi1_percentagevalue_Visible = 0;
         AssignProp(sPrefix, false, edtavKpi1_percentagevalue_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavKpi1_percentagevalue_Visible), 5, 0), true);
         edtavKpi2_percentagevalue_Visible = 0;
         AssignProp(sPrefix, false, edtavKpi2_percentagevalue_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavKpi2_percentagevalue_Visible), 5, 0), true);
         edtavKpi3_percentagevalue_Visible = 0;
         AssignProp(sPrefix, false, edtavKpi3_percentagevalue_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavKpi3_percentagevalue_Visible), 5, 0), true);
         edtavKpi4_percentagevalue_Visible = 0;
         AssignProp(sPrefix, false, edtavKpi4_percentagevalue_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavKpi4_percentagevalue_Visible), 5, 0), true);
         edtavKpi5_percentagevalue_Visible = 0;
         AssignProp(sPrefix, false, edtavKpi5_percentagevalue_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavKpi5_percentagevalue_Visible), 5, 0), true);
         edtavKpi6_percentagevalue_Visible = 0;
         AssignProp(sPrefix, false, edtavKpi6_percentagevalue_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavKpi6_percentagevalue_Visible), 5, 0), true);
         new GeneXus.Programs.comercios.ocantsolicitudescardtime(context ).execute(  AV23Fecha,  AV28ProveedorID, out  AV29SdtCantSol) ;
         AV20KPI1_Value = (int)(AV29SdtCantSol.gxTpr_Ayer);
         AssignAttri(sPrefix, false, "AV20KPI1_Value", StringUtil.LTrimStr( (decimal)(AV20KPI1_Value), 8, 0));
         lblKpi1_moreinfoicon_Caption = StringUtil.Format( "%1 - %2", context.localUtil.DToC( (DateTime)(AV29SdtCantSol.gxTpr_Ayerfecha), 0, "-"), AV29SdtCantSol.gxTpr_Ayerturnos, "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, lblKpi1_moreinfoicon_Internalname, "Caption", lblKpi1_moreinfoicon_Caption, true);
         AV18KPI2_Value = (int)(AV29SdtCantSol.gxTpr_Hoy);
         AssignAttri(sPrefix, false, "AV18KPI2_Value", StringUtil.LTrimStr( (decimal)(AV18KPI2_Value), 8, 0));
         lblKpi2_moreinfoicon_Caption = StringUtil.Format( "%1 -%2", context.localUtil.DToC( (DateTime)(AV29SdtCantSol.gxTpr_Hoyfecha), 0, "-"), AV29SdtCantSol.gxTpr_Hoyturnos, "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, lblKpi2_moreinfoicon_Internalname, "Caption", lblKpi2_moreinfoicon_Caption, true);
         AV16KPI3_Value = (int)(AV29SdtCantSol.gxTpr_Manana);
         AssignAttri(sPrefix, false, "AV16KPI3_Value", StringUtil.LTrimStr( (decimal)(AV16KPI3_Value), 8, 0));
         lblKpi3_moreinfoicon_Caption = StringUtil.Format( "%1 -%2", context.localUtil.DToC( (DateTime)(AV29SdtCantSol.gxTpr_Mananafecha), 0, "-"), AV29SdtCantSol.gxTpr_Mananaturnos, "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, lblKpi3_moreinfoicon_Internalname, "Caption", lblKpi3_moreinfoicon_Caption, true);
         AV14KPI4_Value = (int)(AV29SdtCantSol.gxTpr_Pmanana);
         AssignAttri(sPrefix, false, "AV14KPI4_Value", StringUtil.LTrimStr( (decimal)(AV14KPI4_Value), 8, 0));
         lblKpi4_moreinfoicon_Caption = StringUtil.Format( "%1 -%2", context.localUtil.DToC( (DateTime)(AV29SdtCantSol.gxTpr_Pmananafecha), 0, "-"), AV29SdtCantSol.gxTpr_Pmananaturnos, "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, lblKpi4_moreinfoicon_Internalname, "Caption", lblKpi4_moreinfoicon_Caption, true);
         AV12KPI5_Value = (int)(AV29SdtCantSol.gxTpr_Dia1);
         AssignAttri(sPrefix, false, "AV12KPI5_Value", StringUtil.LTrimStr( (decimal)(AV12KPI5_Value), 8, 0));
         lblKpi5_moreinfoicon_Caption = StringUtil.Format( "%1 -%2", context.localUtil.DToC( (DateTime)(AV29SdtCantSol.gxTpr_Dia1fecha), 0, "-"), AV29SdtCantSol.gxTpr_Dia1turnos, "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, lblKpi5_moreinfoicon_Internalname, "Caption", lblKpi5_moreinfoicon_Caption, true);
         AV26KPI6_Value = (int)(AV29SdtCantSol.gxTpr_Dia2);
         AssignAttri(sPrefix, false, "AV26KPI6_Value", StringUtil.LTrimStr( (decimal)(AV26KPI6_Value), 8, 0));
         lblKpi6_moreinfoicon_Caption = StringUtil.Format( "%1 -%2", context.localUtil.DToC( (DateTime)(AV29SdtCantSol.gxTpr_Dia2fecha), 0, "-"), AV29SdtCantSol.gxTpr_Dia2turnos, "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, lblKpi6_moreinfoicon_Internalname, "Caption", lblKpi6_moreinfoicon_Caption, true);
      }

      protected void nextLoad( )
      {
      }

      protected void E13DW2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table12_153_DW2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedkpi6_moreinfoicon_Internalname, tblTablemergedkpi6_moreinfoicon_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi6_moreinfoicon_Internalname, lblKpi6_moreinfoicon_Caption, "", "", lblKpi6_moreinfoicon_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_SolicitudesCardTime.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"Center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Center;text-align:-moz-Center;text-align:-webkit-Center")+"\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKpi6_percentagevalue_Internalname, context.GetMessage( "KPI6_Percentage Value", ""), "gx-form-item DashboardPercentageSuccessLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 159,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKpi6_percentagevalue_Internalname, StringUtil.LTrim( StringUtil.NToC( AV27KPI6_PercentageValue, 5, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavKpi6_percentagevalue_Enabled!=0) ? context.localUtil.Format( AV27KPI6_PercentageValue, "Z9%") : context.localUtil.Format( AV27KPI6_PercentageValue, "Z9%"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,159);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKpi6_percentagevalue_Jsonclick, 0, edtavKpi6_percentagevalue_Class, "", "", "", "", edtavKpi6_percentagevalue_Visible, edtavKpi6_percentagevalue_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, false, "WWPBaseObjects\\WWPPercentage", "end", false, "", "HLP_SolicitudesCardTime.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi6_moreinfocaption_Internalname, "", "", "", lblKpi6_moreinfocaption_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlockMoreInfoCard", 0, "", 1, 1, 0, 0, "HLP_SolicitudesCardTime.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table12_153_DW2e( true) ;
         }
         else
         {
            wb_table12_153_DW2e( false) ;
         }
      }

      protected void wb_table11_141_DW2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedkpi6_icon_Internalname, tblTablemergedkpi6_icon_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi6_icon_Internalname, context.GetMessage( "<i class='ProgressCardIcon far fa-calendar'></i>", ""), "", "", lblKpi6_icon_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_SolicitudesCardTime.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi6_description_Internalname, context.GetMessage( "Siguiente dia", ""), "", "", lblKpi6_description_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_SolicitudesCardTime.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table11_141_DW2e( true) ;
         }
         else
         {
            wb_table11_141_DW2e( false) ;
         }
      }

      protected void wb_table10_128_DW2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedkpi5_moreinfoicon_Internalname, tblTablemergedkpi5_moreinfoicon_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi5_moreinfoicon_Internalname, lblKpi5_moreinfoicon_Caption, "", "", lblKpi5_moreinfoicon_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_SolicitudesCardTime.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"Center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Center;text-align:-moz-Center;text-align:-webkit-Center")+"\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKpi5_percentagevalue_Internalname, context.GetMessage( "KPI5_Percentage Value", ""), "gx-form-item DashboardPercentageSuccessLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKpi5_percentagevalue_Internalname, StringUtil.LTrim( StringUtil.NToC( AV13KPI5_PercentageValue, 5, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavKpi5_percentagevalue_Enabled!=0) ? context.localUtil.Format( AV13KPI5_PercentageValue, "Z9%") : context.localUtil.Format( AV13KPI5_PercentageValue, "Z9%"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,134);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKpi5_percentagevalue_Jsonclick, 0, edtavKpi5_percentagevalue_Class, "", "", "", "", edtavKpi5_percentagevalue_Visible, edtavKpi5_percentagevalue_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, false, "WWPBaseObjects\\WWPPercentage", "end", false, "", "HLP_SolicitudesCardTime.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi5_moreinfocaption_Internalname, "", "", "", lblKpi5_moreinfocaption_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlockMoreInfoCard", 0, "", 1, 1, 0, 0, "HLP_SolicitudesCardTime.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table10_128_DW2e( true) ;
         }
         else
         {
            wb_table10_128_DW2e( false) ;
         }
      }

      protected void wb_table9_116_DW2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedkpi5_icon_Internalname, tblTablemergedkpi5_icon_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi5_icon_Internalname, context.GetMessage( "<i class='ProgressCardIcon far fa-calendar'></i>", ""), "", "", lblKpi5_icon_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_SolicitudesCardTime.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi5_description_Internalname, context.GetMessage( "Siguiente dia", ""), "", "", lblKpi5_description_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_SolicitudesCardTime.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table9_116_DW2e( true) ;
         }
         else
         {
            wb_table9_116_DW2e( false) ;
         }
      }

      protected void wb_table8_103_DW2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedkpi4_moreinfoicon_Internalname, tblTablemergedkpi4_moreinfoicon_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi4_moreinfoicon_Internalname, lblKpi4_moreinfoicon_Caption, "", "", lblKpi4_moreinfoicon_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_SolicitudesCardTime.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"Center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Center;text-align:-moz-Center;text-align:-webkit-Center")+"\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKpi4_percentagevalue_Internalname, context.GetMessage( "KPI4_Percentage Value", ""), "gx-form-item DashboardPercentageSuccessLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKpi4_percentagevalue_Internalname, StringUtil.LTrim( StringUtil.NToC( AV15KPI4_PercentageValue, 5, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavKpi4_percentagevalue_Enabled!=0) ? context.localUtil.Format( AV15KPI4_PercentageValue, "Z9%") : context.localUtil.Format( AV15KPI4_PercentageValue, "Z9%"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,109);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKpi4_percentagevalue_Jsonclick, 0, edtavKpi4_percentagevalue_Class, "", "", "", "", edtavKpi4_percentagevalue_Visible, edtavKpi4_percentagevalue_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, false, "WWPBaseObjects\\WWPPercentage", "end", false, "", "HLP_SolicitudesCardTime.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi4_moreinfocaption_Internalname, "", "", "", lblKpi4_moreinfocaption_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlockMoreInfoCard", 0, "", 1, 1, 0, 0, "HLP_SolicitudesCardTime.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table8_103_DW2e( true) ;
         }
         else
         {
            wb_table8_103_DW2e( false) ;
         }
      }

      protected void wb_table7_91_DW2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedkpi4_icon_Internalname, tblTablemergedkpi4_icon_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi4_icon_Internalname, context.GetMessage( "<i class='ProgressCardIcon far fa-calendar'></i>", ""), "", "", lblKpi4_icon_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_SolicitudesCardTime.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi4_description_Internalname, context.GetMessage( "Pasado Mañana", ""), "", "", lblKpi4_description_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_SolicitudesCardTime.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table7_91_DW2e( true) ;
         }
         else
         {
            wb_table7_91_DW2e( false) ;
         }
      }

      protected void wb_table6_78_DW2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedkpi3_moreinfoicon_Internalname, tblTablemergedkpi3_moreinfoicon_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi3_moreinfoicon_Internalname, lblKpi3_moreinfoicon_Caption, "", "", lblKpi3_moreinfoicon_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_SolicitudesCardTime.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"Center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Center;text-align:-moz-Center;text-align:-webkit-Center")+"\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKpi3_percentagevalue_Internalname, context.GetMessage( "KPI3_Percentage Value", ""), "gx-form-item DashboardPercentageSuccessLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKpi3_percentagevalue_Internalname, StringUtil.LTrim( StringUtil.NToC( AV17KPI3_PercentageValue, 5, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavKpi3_percentagevalue_Enabled!=0) ? context.localUtil.Format( AV17KPI3_PercentageValue, "Z9%") : context.localUtil.Format( AV17KPI3_PercentageValue, "Z9%"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,84);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKpi3_percentagevalue_Jsonclick, 0, edtavKpi3_percentagevalue_Class, "", "", "", "", edtavKpi3_percentagevalue_Visible, edtavKpi3_percentagevalue_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, false, "WWPBaseObjects\\WWPPercentage", "end", false, "", "HLP_SolicitudesCardTime.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi3_moreinfocaption_Internalname, "", "", "", lblKpi3_moreinfocaption_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlockMoreInfoCard", 0, "", 1, 1, 0, 0, "HLP_SolicitudesCardTime.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table6_78_DW2e( true) ;
         }
         else
         {
            wb_table6_78_DW2e( false) ;
         }
      }

      protected void wb_table5_66_DW2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedkpi3_icon_Internalname, tblTablemergedkpi3_icon_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi3_icon_Internalname, context.GetMessage( "<i class='ProgressCardIcon fas fa-calendar'></i>", ""), "", "", lblKpi3_icon_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_SolicitudesCardTime.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi3_description_Internalname, context.GetMessage( "Mañana", ""), "", "", lblKpi3_description_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_SolicitudesCardTime.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_66_DW2e( true) ;
         }
         else
         {
            wb_table5_66_DW2e( false) ;
         }
      }

      protected void wb_table4_53_DW2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedkpi2_moreinfoicon_Internalname, tblTablemergedkpi2_moreinfoicon_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi2_moreinfoicon_Internalname, lblKpi2_moreinfoicon_Caption, "", "", lblKpi2_moreinfoicon_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_SolicitudesCardTime.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"Center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Center;text-align:-moz-Center;text-align:-webkit-Center")+"\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKpi2_percentagevalue_Internalname, context.GetMessage( "KPI2_Percentage Value", ""), "gx-form-item DashboardPercentageSuccessLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKpi2_percentagevalue_Internalname, StringUtil.LTrim( StringUtil.NToC( AV19KPI2_PercentageValue, 5, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavKpi2_percentagevalue_Enabled!=0) ? context.localUtil.Format( AV19KPI2_PercentageValue, "Z9%") : context.localUtil.Format( AV19KPI2_PercentageValue, "Z9%"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,59);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKpi2_percentagevalue_Jsonclick, 0, edtavKpi2_percentagevalue_Class, "", "", "", "", edtavKpi2_percentagevalue_Visible, edtavKpi2_percentagevalue_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, false, "WWPBaseObjects\\WWPPercentage", "end", false, "", "HLP_SolicitudesCardTime.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi2_moreinfocaption_Internalname, "", "", "", lblKpi2_moreinfocaption_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlockMoreInfoCard", 0, "", 1, 1, 0, 0, "HLP_SolicitudesCardTime.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_53_DW2e( true) ;
         }
         else
         {
            wb_table4_53_DW2e( false) ;
         }
      }

      protected void wb_table3_41_DW2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedkpi2_icon_Internalname, tblTablemergedkpi2_icon_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi2_icon_Internalname, context.GetMessage( "<i class='ProgressCardIcon fas fa-calendar-check'></i>", ""), "", "", lblKpi2_icon_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_SolicitudesCardTime.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi2_description_Internalname, context.GetMessage( "HOY", ""), "", "", lblKpi2_description_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_SolicitudesCardTime.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_41_DW2e( true) ;
         }
         else
         {
            wb_table3_41_DW2e( false) ;
         }
      }

      protected void wb_table2_28_DW2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedkpi1_moreinfoicon_Internalname, tblTablemergedkpi1_moreinfoicon_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi1_moreinfoicon_Internalname, lblKpi1_moreinfoicon_Caption, "", "", lblKpi1_moreinfoicon_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_SolicitudesCardTime.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"Center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Center;text-align:-moz-Center;text-align:-webkit-Center")+"\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKpi1_percentagevalue_Internalname, context.GetMessage( "KPI1_Percentage Value", ""), "gx-form-item DashboardPercentageSuccessLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKpi1_percentagevalue_Internalname, StringUtil.LTrim( StringUtil.NToC( AV21KPI1_PercentageValue, 5, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavKpi1_percentagevalue_Enabled!=0) ? context.localUtil.Format( AV21KPI1_PercentageValue, "Z9%") : context.localUtil.Format( AV21KPI1_PercentageValue, "Z9%"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,34);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKpi1_percentagevalue_Jsonclick, 0, edtavKpi1_percentagevalue_Class, "", "", "", "", edtavKpi1_percentagevalue_Visible, edtavKpi1_percentagevalue_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, false, "WWPBaseObjects\\WWPPercentage", "end", false, "", "HLP_SolicitudesCardTime.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi1_moreinfocaption_Internalname, "", "", "", lblKpi1_moreinfocaption_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlockMoreInfoCard", 0, "", 1, 1, 0, 0, "HLP_SolicitudesCardTime.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_28_DW2e( true) ;
         }
         else
         {
            wb_table2_28_DW2e( false) ;
         }
      }

      protected void wb_table1_16_DW2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedkpi1_icon_Internalname, tblTablemergedkpi1_icon_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi1_icon_Internalname, context.GetMessage( "<i class='ProgressCardIcon fas fa-layer-group'></i>", ""), "", "", lblKpi1_icon_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_SolicitudesCardTime.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi1_description_Internalname, context.GetMessage( "Ayer", ""), "", "", lblKpi1_description_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_SolicitudesCardTime.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_16_DW2e( true) ;
         }
         else
         {
            wb_table1_16_DW2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV23Fecha = (DateTime)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV23Fecha", context.localUtil.Format(AV23Fecha, "99/99/99"));
         AV28ProveedorID = Convert.ToInt64(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV28ProveedorID", StringUtil.LTrimStr( (decimal)(AV28ProveedorID), 18, 0));
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
         PADW2( ) ;
         WSDW2( ) ;
         WEDW2( ) ;
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
         sCtrlAV23Fecha = (string)((string)getParm(obj,0));
         sCtrlAV28ProveedorID = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PADW2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "solicitudescardtime", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PADW2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV23Fecha = (DateTime)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV23Fecha", context.localUtil.Format(AV23Fecha, "99/99/99"));
            AV28ProveedorID = Convert.ToInt64(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV28ProveedorID", StringUtil.LTrimStr( (decimal)(AV28ProveedorID), 18, 0));
         }
         wcpOAV23Fecha = context.localUtil.CToD( cgiGet( sPrefix+"wcpOAV23Fecha"), 0);
         wcpOAV28ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV28ProveedorID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( DateTimeUtil.ResetTime ( AV23Fecha ) != DateTimeUtil.ResetTime ( wcpOAV23Fecha ) ) || ( AV28ProveedorID != wcpOAV28ProveedorID ) ) )
         {
            setjustcreated();
         }
         wcpOAV23Fecha = AV23Fecha;
         wcpOAV28ProveedorID = AV28ProveedorID;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV23Fecha = cgiGet( sPrefix+"AV23Fecha_CTRL");
         if ( StringUtil.Len( sCtrlAV23Fecha) > 0 )
         {
            AV23Fecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( sCtrlAV23Fecha), 0));
            AssignAttri(sPrefix, false, "AV23Fecha", context.localUtil.Format(AV23Fecha, "99/99/99"));
         }
         else
         {
            AV23Fecha = context.localUtil.CToD( cgiGet( sPrefix+"AV23Fecha_PARM"), 0);
         }
         sCtrlAV28ProveedorID = cgiGet( sPrefix+"AV28ProveedorID_CTRL");
         if ( StringUtil.Len( sCtrlAV28ProveedorID) > 0 )
         {
            AV28ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV28ProveedorID), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV28ProveedorID", StringUtil.LTrimStr( (decimal)(AV28ProveedorID), 18, 0));
         }
         else
         {
            AV28ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV28ProveedorID_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         PADW2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WSDW2( ) ;
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
         WSDW2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV23Fecha_PARM", context.localUtil.DToC( AV23Fecha, 0, "/"));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV23Fecha)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV23Fecha_CTRL", StringUtil.RTrim( sCtrlAV23Fecha));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV28ProveedorID_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV28ProveedorID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV28ProveedorID_CTRL", StringUtil.RTrim( sCtrlAV28ProveedorID));
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
         WEDW2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20267302115970", true, true, false);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("solicitudescardtime.js", "?20267302115970", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         }
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblKpi1_icon_Internalname = sPrefix+"KPI1_ICON";
         lblKpi1_description_Internalname = sPrefix+"KPI1_DESCRIPTION";
         tblTablemergedkpi1_icon_Internalname = sPrefix+"TABLEMERGEDKPI1_ICON";
         edtavKpi1_value_Internalname = sPrefix+"vKPI1_VALUE";
         lblKpi1_moreinfoicon_Internalname = sPrefix+"KPI1_MOREINFOICON";
         edtavKpi1_percentagevalue_Internalname = sPrefix+"vKPI1_PERCENTAGEVALUE";
         lblKpi1_moreinfocaption_Internalname = sPrefix+"KPI1_MOREINFOCAPTION";
         tblTablemergedkpi1_moreinfoicon_Internalname = sPrefix+"TABLEMERGEDKPI1_MOREINFOICON";
         divKpi1_maintable_Internalname = sPrefix+"KPI1_MAINTABLE";
         lblKpi2_icon_Internalname = sPrefix+"KPI2_ICON";
         lblKpi2_description_Internalname = sPrefix+"KPI2_DESCRIPTION";
         tblTablemergedkpi2_icon_Internalname = sPrefix+"TABLEMERGEDKPI2_ICON";
         edtavKpi2_value_Internalname = sPrefix+"vKPI2_VALUE";
         lblKpi2_moreinfoicon_Internalname = sPrefix+"KPI2_MOREINFOICON";
         edtavKpi2_percentagevalue_Internalname = sPrefix+"vKPI2_PERCENTAGEVALUE";
         lblKpi2_moreinfocaption_Internalname = sPrefix+"KPI2_MOREINFOCAPTION";
         tblTablemergedkpi2_moreinfoicon_Internalname = sPrefix+"TABLEMERGEDKPI2_MOREINFOICON";
         divKpi2_maintable_Internalname = sPrefix+"KPI2_MAINTABLE";
         lblKpi3_icon_Internalname = sPrefix+"KPI3_ICON";
         lblKpi3_description_Internalname = sPrefix+"KPI3_DESCRIPTION";
         tblTablemergedkpi3_icon_Internalname = sPrefix+"TABLEMERGEDKPI3_ICON";
         edtavKpi3_value_Internalname = sPrefix+"vKPI3_VALUE";
         lblKpi3_moreinfoicon_Internalname = sPrefix+"KPI3_MOREINFOICON";
         edtavKpi3_percentagevalue_Internalname = sPrefix+"vKPI3_PERCENTAGEVALUE";
         lblKpi3_moreinfocaption_Internalname = sPrefix+"KPI3_MOREINFOCAPTION";
         tblTablemergedkpi3_moreinfoicon_Internalname = sPrefix+"TABLEMERGEDKPI3_MOREINFOICON";
         divKpi3_maintable_Internalname = sPrefix+"KPI3_MAINTABLE";
         lblKpi4_icon_Internalname = sPrefix+"KPI4_ICON";
         lblKpi4_description_Internalname = sPrefix+"KPI4_DESCRIPTION";
         tblTablemergedkpi4_icon_Internalname = sPrefix+"TABLEMERGEDKPI4_ICON";
         edtavKpi4_value_Internalname = sPrefix+"vKPI4_VALUE";
         lblKpi4_moreinfoicon_Internalname = sPrefix+"KPI4_MOREINFOICON";
         edtavKpi4_percentagevalue_Internalname = sPrefix+"vKPI4_PERCENTAGEVALUE";
         lblKpi4_moreinfocaption_Internalname = sPrefix+"KPI4_MOREINFOCAPTION";
         tblTablemergedkpi4_moreinfoicon_Internalname = sPrefix+"TABLEMERGEDKPI4_MOREINFOICON";
         divKpi4_maintable_Internalname = sPrefix+"KPI4_MAINTABLE";
         lblKpi5_icon_Internalname = sPrefix+"KPI5_ICON";
         lblKpi5_description_Internalname = sPrefix+"KPI5_DESCRIPTION";
         tblTablemergedkpi5_icon_Internalname = sPrefix+"TABLEMERGEDKPI5_ICON";
         edtavKpi5_value_Internalname = sPrefix+"vKPI5_VALUE";
         lblKpi5_moreinfoicon_Internalname = sPrefix+"KPI5_MOREINFOICON";
         edtavKpi5_percentagevalue_Internalname = sPrefix+"vKPI5_PERCENTAGEVALUE";
         lblKpi5_moreinfocaption_Internalname = sPrefix+"KPI5_MOREINFOCAPTION";
         tblTablemergedkpi5_moreinfoicon_Internalname = sPrefix+"TABLEMERGEDKPI5_MOREINFOICON";
         divKpi5_maintable_Internalname = sPrefix+"KPI5_MAINTABLE";
         lblKpi6_icon_Internalname = sPrefix+"KPI6_ICON";
         lblKpi6_description_Internalname = sPrefix+"KPI6_DESCRIPTION";
         tblTablemergedkpi6_icon_Internalname = sPrefix+"TABLEMERGEDKPI6_ICON";
         edtavKpi6_value_Internalname = sPrefix+"vKPI6_VALUE";
         lblKpi6_moreinfoicon_Internalname = sPrefix+"KPI6_MOREINFOICON";
         edtavKpi6_percentagevalue_Internalname = sPrefix+"vKPI6_PERCENTAGEVALUE";
         lblKpi6_moreinfocaption_Internalname = sPrefix+"KPI6_MOREINFOCAPTION";
         tblTablemergedkpi6_moreinfoicon_Internalname = sPrefix+"TABLEMERGEDKPI6_MOREINFOICON";
         divKpi6_maintable_Internalname = sPrefix+"KPI6_MAINTABLE";
         divTablecards_Internalname = sPrefix+"TABLECARDS";
         Dvpanel_tablecards_Internalname = sPrefix+"DVPANEL_TABLECARDS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
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
         edtavKpi1_percentagevalue_Jsonclick = "";
         edtavKpi1_percentagevalue_Enabled = 1;
         edtavKpi2_percentagevalue_Jsonclick = "";
         edtavKpi2_percentagevalue_Enabled = 1;
         edtavKpi3_percentagevalue_Jsonclick = "";
         edtavKpi3_percentagevalue_Enabled = 1;
         edtavKpi4_percentagevalue_Jsonclick = "";
         edtavKpi4_percentagevalue_Enabled = 1;
         edtavKpi5_percentagevalue_Jsonclick = "";
         edtavKpi5_percentagevalue_Enabled = 1;
         edtavKpi6_percentagevalue_Jsonclick = "";
         edtavKpi6_percentagevalue_Enabled = 1;
         edtavKpi6_percentagevalue_Visible = 1;
         edtavKpi5_percentagevalue_Visible = 1;
         edtavKpi4_percentagevalue_Visible = 1;
         edtavKpi3_percentagevalue_Visible = 1;
         edtavKpi2_percentagevalue_Visible = 1;
         edtavKpi1_percentagevalue_Visible = 1;
         edtavKpi6_percentagevalue_Class = "DashboardPercentageSuccess";
         lblKpi6_moreinfoicon_Caption = context.GetMessage( "<i class='FontColorIconSuccess fas fa-caret-up' style='font-size: 12px'></i>", "");
         edtavKpi5_percentagevalue_Class = "DashboardPercentageSuccess";
         lblKpi5_moreinfoicon_Caption = context.GetMessage( "<i class='FontColorIconSuccess fas fa-caret-up' style='font-size: 12px'></i>", "");
         edtavKpi4_percentagevalue_Class = "DashboardPercentageSuccess";
         lblKpi4_moreinfoicon_Caption = context.GetMessage( "<i class='FontColorIconSuccess fas fa-caret-up' style='font-size: 12px'></i>", "");
         edtavKpi3_percentagevalue_Class = "DashboardPercentageSuccess";
         lblKpi3_moreinfoicon_Caption = context.GetMessage( "<i class='FontColorIconSuccess fas fa-caret-up' style='font-size: 12px'></i>", "");
         edtavKpi2_percentagevalue_Class = "DashboardPercentageSuccess";
         lblKpi2_moreinfoicon_Caption = context.GetMessage( "<i class='FontColorIconSuccess fas fa-caret-up' style='font-size: 12px'></i>", "");
         edtavKpi1_percentagevalue_Class = "DashboardPercentageSuccess";
         lblKpi1_moreinfoicon_Caption = context.GetMessage( "<i class='FontColorIconSuccess fas fa-caret-up' style='font-size: 12px'></i>", "");
         edtavKpi6_value_Jsonclick = "";
         edtavKpi6_value_Enabled = 1;
         edtavKpi5_value_Jsonclick = "";
         edtavKpi5_value_Enabled = 1;
         edtavKpi4_value_Jsonclick = "";
         edtavKpi4_value_Enabled = 1;
         edtavKpi3_value_Jsonclick = "";
         edtavKpi3_value_Enabled = 1;
         edtavKpi2_value_Jsonclick = "";
         edtavKpi2_value_Enabled = 1;
         edtavKpi1_value_Jsonclick = "";
         edtavKpi1_value_Enabled = 1;
         Dvpanel_tablecards_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablecards_Iconposition = "Right";
         Dvpanel_tablecards_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablecards_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablecards_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tablecards_Title = "";
         Dvpanel_tablecards_Cls = "PanelNoHeader";
         Dvpanel_tablecards_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablecards_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablecards_Width = "100%";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
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
         wcpOAV23Fecha = DateTime.MinValue;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         ucDvpanel_tablecards = new GXUserControl();
         TempTags = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV29SdtCantSol = new SdtSDTCantSol(context);
         sStyleString = "";
         lblKpi6_moreinfoicon_Jsonclick = "";
         lblKpi6_moreinfocaption_Jsonclick = "";
         lblKpi6_icon_Jsonclick = "";
         lblKpi6_description_Jsonclick = "";
         lblKpi5_moreinfoicon_Jsonclick = "";
         lblKpi5_moreinfocaption_Jsonclick = "";
         lblKpi5_icon_Jsonclick = "";
         lblKpi5_description_Jsonclick = "";
         lblKpi4_moreinfoicon_Jsonclick = "";
         lblKpi4_moreinfocaption_Jsonclick = "";
         lblKpi4_icon_Jsonclick = "";
         lblKpi4_description_Jsonclick = "";
         lblKpi3_moreinfoicon_Jsonclick = "";
         lblKpi3_moreinfocaption_Jsonclick = "";
         lblKpi3_icon_Jsonclick = "";
         lblKpi3_description_Jsonclick = "";
         lblKpi2_moreinfoicon_Jsonclick = "";
         lblKpi2_moreinfocaption_Jsonclick = "";
         lblKpi2_icon_Jsonclick = "";
         lblKpi2_description_Jsonclick = "";
         lblKpi1_moreinfoicon_Jsonclick = "";
         lblKpi1_moreinfocaption_Jsonclick = "";
         lblKpi1_icon_Jsonclick = "";
         lblKpi1_description_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV23Fecha = "";
         sCtrlAV28ProveedorID = "";
         /* GeneXus formulas. */
         edtavKpi1_value_Enabled = 0;
         edtavKpi1_percentagevalue_Enabled = 0;
         edtavKpi2_value_Enabled = 0;
         edtavKpi2_percentagevalue_Enabled = 0;
         edtavKpi3_value_Enabled = 0;
         edtavKpi3_percentagevalue_Enabled = 0;
         edtavKpi4_value_Enabled = 0;
         edtavKpi4_percentagevalue_Enabled = 0;
         edtavKpi5_value_Enabled = 0;
         edtavKpi5_percentagevalue_Enabled = 0;
         edtavKpi6_value_Enabled = 0;
         edtavKpi6_percentagevalue_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private int edtavKpi1_value_Enabled ;
      private int edtavKpi1_percentagevalue_Enabled ;
      private int edtavKpi2_value_Enabled ;
      private int edtavKpi2_percentagevalue_Enabled ;
      private int edtavKpi3_value_Enabled ;
      private int edtavKpi3_percentagevalue_Enabled ;
      private int edtavKpi4_value_Enabled ;
      private int edtavKpi4_percentagevalue_Enabled ;
      private int edtavKpi5_value_Enabled ;
      private int edtavKpi5_percentagevalue_Enabled ;
      private int edtavKpi6_value_Enabled ;
      private int edtavKpi6_percentagevalue_Enabled ;
      private int AV20KPI1_Value ;
      private int AV18KPI2_Value ;
      private int AV16KPI3_Value ;
      private int AV14KPI4_Value ;
      private int AV12KPI5_Value ;
      private int AV26KPI6_Value ;
      private int edtavKpi1_percentagevalue_Visible ;
      private int edtavKpi2_percentagevalue_Visible ;
      private int edtavKpi3_percentagevalue_Visible ;
      private int edtavKpi4_percentagevalue_Visible ;
      private int edtavKpi5_percentagevalue_Visible ;
      private int edtavKpi6_percentagevalue_Visible ;
      private int idxLst ;
      private long AV28ProveedorID ;
      private long wcpOAV28ProveedorID ;
      private decimal AV27KPI6_PercentageValue ;
      private decimal AV13KPI5_PercentageValue ;
      private decimal AV15KPI4_PercentageValue ;
      private decimal AV17KPI3_PercentageValue ;
      private decimal AV19KPI2_PercentageValue ;
      private decimal AV21KPI1_PercentageValue ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string edtavKpi1_value_Internalname ;
      private string edtavKpi1_percentagevalue_Internalname ;
      private string edtavKpi2_value_Internalname ;
      private string edtavKpi2_percentagevalue_Internalname ;
      private string edtavKpi3_value_Internalname ;
      private string edtavKpi3_percentagevalue_Internalname ;
      private string edtavKpi4_value_Internalname ;
      private string edtavKpi4_percentagevalue_Internalname ;
      private string edtavKpi5_value_Internalname ;
      private string edtavKpi5_percentagevalue_Internalname ;
      private string edtavKpi6_value_Internalname ;
      private string edtavKpi6_percentagevalue_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Dvpanel_tablecards_Width ;
      private string Dvpanel_tablecards_Cls ;
      private string Dvpanel_tablecards_Title ;
      private string Dvpanel_tablecards_Iconposition ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string Dvpanel_tablecards_Internalname ;
      private string divTablecards_Internalname ;
      private string divKpi1_maintable_Internalname ;
      private string TempTags ;
      private string edtavKpi1_value_Jsonclick ;
      private string divKpi2_maintable_Internalname ;
      private string edtavKpi2_value_Jsonclick ;
      private string divKpi3_maintable_Internalname ;
      private string edtavKpi3_value_Jsonclick ;
      private string divKpi4_maintable_Internalname ;
      private string edtavKpi4_value_Jsonclick ;
      private string divKpi5_maintable_Internalname ;
      private string edtavKpi5_value_Jsonclick ;
      private string divKpi6_maintable_Internalname ;
      private string edtavKpi6_value_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string lblKpi1_moreinfoicon_Caption ;
      private string lblKpi1_moreinfoicon_Internalname ;
      private string edtavKpi1_percentagevalue_Class ;
      private string lblKpi2_moreinfoicon_Caption ;
      private string lblKpi2_moreinfoicon_Internalname ;
      private string edtavKpi2_percentagevalue_Class ;
      private string lblKpi3_moreinfoicon_Caption ;
      private string lblKpi3_moreinfoicon_Internalname ;
      private string edtavKpi3_percentagevalue_Class ;
      private string lblKpi4_moreinfoicon_Caption ;
      private string lblKpi4_moreinfoicon_Internalname ;
      private string edtavKpi4_percentagevalue_Class ;
      private string lblKpi5_moreinfoicon_Caption ;
      private string lblKpi5_moreinfoicon_Internalname ;
      private string edtavKpi5_percentagevalue_Class ;
      private string lblKpi6_moreinfoicon_Caption ;
      private string lblKpi6_moreinfoicon_Internalname ;
      private string edtavKpi6_percentagevalue_Class ;
      private string sStyleString ;
      private string tblTablemergedkpi6_moreinfoicon_Internalname ;
      private string lblKpi6_moreinfoicon_Jsonclick ;
      private string edtavKpi6_percentagevalue_Jsonclick ;
      private string lblKpi6_moreinfocaption_Internalname ;
      private string lblKpi6_moreinfocaption_Jsonclick ;
      private string tblTablemergedkpi6_icon_Internalname ;
      private string lblKpi6_icon_Internalname ;
      private string lblKpi6_icon_Jsonclick ;
      private string lblKpi6_description_Internalname ;
      private string lblKpi6_description_Jsonclick ;
      private string tblTablemergedkpi5_moreinfoicon_Internalname ;
      private string lblKpi5_moreinfoicon_Jsonclick ;
      private string edtavKpi5_percentagevalue_Jsonclick ;
      private string lblKpi5_moreinfocaption_Internalname ;
      private string lblKpi5_moreinfocaption_Jsonclick ;
      private string tblTablemergedkpi5_icon_Internalname ;
      private string lblKpi5_icon_Internalname ;
      private string lblKpi5_icon_Jsonclick ;
      private string lblKpi5_description_Internalname ;
      private string lblKpi5_description_Jsonclick ;
      private string tblTablemergedkpi4_moreinfoicon_Internalname ;
      private string lblKpi4_moreinfoicon_Jsonclick ;
      private string edtavKpi4_percentagevalue_Jsonclick ;
      private string lblKpi4_moreinfocaption_Internalname ;
      private string lblKpi4_moreinfocaption_Jsonclick ;
      private string tblTablemergedkpi4_icon_Internalname ;
      private string lblKpi4_icon_Internalname ;
      private string lblKpi4_icon_Jsonclick ;
      private string lblKpi4_description_Internalname ;
      private string lblKpi4_description_Jsonclick ;
      private string tblTablemergedkpi3_moreinfoicon_Internalname ;
      private string lblKpi3_moreinfoicon_Jsonclick ;
      private string edtavKpi3_percentagevalue_Jsonclick ;
      private string lblKpi3_moreinfocaption_Internalname ;
      private string lblKpi3_moreinfocaption_Jsonclick ;
      private string tblTablemergedkpi3_icon_Internalname ;
      private string lblKpi3_icon_Internalname ;
      private string lblKpi3_icon_Jsonclick ;
      private string lblKpi3_description_Internalname ;
      private string lblKpi3_description_Jsonclick ;
      private string tblTablemergedkpi2_moreinfoicon_Internalname ;
      private string lblKpi2_moreinfoicon_Jsonclick ;
      private string edtavKpi2_percentagevalue_Jsonclick ;
      private string lblKpi2_moreinfocaption_Internalname ;
      private string lblKpi2_moreinfocaption_Jsonclick ;
      private string tblTablemergedkpi2_icon_Internalname ;
      private string lblKpi2_icon_Internalname ;
      private string lblKpi2_icon_Jsonclick ;
      private string lblKpi2_description_Internalname ;
      private string lblKpi2_description_Jsonclick ;
      private string tblTablemergedkpi1_moreinfoicon_Internalname ;
      private string lblKpi1_moreinfoicon_Jsonclick ;
      private string edtavKpi1_percentagevalue_Jsonclick ;
      private string lblKpi1_moreinfocaption_Internalname ;
      private string lblKpi1_moreinfocaption_Jsonclick ;
      private string tblTablemergedkpi1_icon_Internalname ;
      private string lblKpi1_icon_Internalname ;
      private string lblKpi1_icon_Jsonclick ;
      private string lblKpi1_description_Internalname ;
      private string lblKpi1_description_Jsonclick ;
      private string sCtrlAV23Fecha ;
      private string sCtrlAV28ProveedorID ;
      private DateTime AV23Fecha ;
      private DateTime wcpOAV23Fecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_tablecards_Autowidth ;
      private bool Dvpanel_tablecards_Autoheight ;
      private bool Dvpanel_tablecards_Collapsible ;
      private bool Dvpanel_tablecards_Collapsed ;
      private bool Dvpanel_tablecards_Showcollapseicon ;
      private bool Dvpanel_tablecards_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV7KPI1_IsSuccessfulValue ;
      private bool AV8KPI2_IsSuccessfulValue ;
      private bool AV9KPI3_IsSuccessfulValue ;
      private bool AV10KPI4_IsSuccessfulValue ;
      private bool AV11KPI5_IsSuccessfulValue ;
      private bool AV25KPI6_IsSuccessfulValue ;
      private GXUserControl ucDvpanel_tablecards ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtSDTCantSol AV29SdtCantSol ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
