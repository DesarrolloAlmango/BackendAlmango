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
   public class reportesprofesionales : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public reportesprofesionales( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reportesprofesionales( IGxContext context )
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
         cmbavProfesional = new GXCombobox();
         cmbavClasificaciones = new GXCombobox();
         cmbavSolicitudservicioorigenpago = new GXCombobox();
         chkavInctotal = new GXCheckbox();
         chkavXls = new GXCheckbox();
         chkavDetallado = new GXCheckbox();
         chkavInctotaleco = new GXCheckbox();
         chkavOpciones = new GXCheckbox();
         chkavVeridicar = new GXCheckbox();
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
         PA7U2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START7U2( ) ;
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
         context.AddJavascriptSource("Toastr/toastr.min.js", "", false, true, false);
         context.AddJavascriptSource("Toastr/ToastrRender.js", "", false, true, false);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("reportesprofesionales.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9SolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9SolicitudesId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9SolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9SolicitudesId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "DVPANEL_REPOREPROFESIONAL_Width", StringUtil.RTrim( Dvpanel_reporeprofesional_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_REPOREPROFESIONAL_Autowidth", StringUtil.BoolToStr( Dvpanel_reporeprofesional_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_REPOREPROFESIONAL_Autoheight", StringUtil.BoolToStr( Dvpanel_reporeprofesional_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_REPOREPROFESIONAL_Cls", StringUtil.RTrim( Dvpanel_reporeprofesional_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_REPOREPROFESIONAL_Title", StringUtil.RTrim( Dvpanel_reporeprofesional_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_REPOREPROFESIONAL_Collapsible", StringUtil.BoolToStr( Dvpanel_reporeprofesional_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_REPOREPROFESIONAL_Collapsed", StringUtil.BoolToStr( Dvpanel_reporeprofesional_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_REPOREPROFESIONAL_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_reporeprofesional_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_REPOREPROFESIONAL_Iconposition", StringUtil.RTrim( Dvpanel_reporeprofesional_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_REPOREPROFESIONAL_Autoscroll", StringUtil.BoolToStr( Dvpanel_reporeprofesional_Autoscroll));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Width", StringUtil.RTrim( Innewwindow1_Width));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Height", StringUtil.RTrim( Innewwindow1_Height));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Target", StringUtil.RTrim( Innewwindow1_Target));
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
            WE7U2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT7U2( ) ;
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
         return formatLink("reportesprofesionales.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ReportesProfesionales" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Reportes Profesionales", "") ;
      }

      protected void WB7U0( )
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
            ucDvpanel_reporeprofesional.SetProperty("Width", Dvpanel_reporeprofesional_Width);
            ucDvpanel_reporeprofesional.SetProperty("AutoWidth", Dvpanel_reporeprofesional_Autowidth);
            ucDvpanel_reporeprofesional.SetProperty("AutoHeight", Dvpanel_reporeprofesional_Autoheight);
            ucDvpanel_reporeprofesional.SetProperty("Cls", Dvpanel_reporeprofesional_Cls);
            ucDvpanel_reporeprofesional.SetProperty("Title", Dvpanel_reporeprofesional_Title);
            ucDvpanel_reporeprofesional.SetProperty("Collapsible", Dvpanel_reporeprofesional_Collapsible);
            ucDvpanel_reporeprofesional.SetProperty("Collapsed", Dvpanel_reporeprofesional_Collapsed);
            ucDvpanel_reporeprofesional.SetProperty("ShowCollapseIcon", Dvpanel_reporeprofesional_Showcollapseicon);
            ucDvpanel_reporeprofesional.SetProperty("IconPosition", Dvpanel_reporeprofesional_Iconposition);
            ucDvpanel_reporeprofesional.SetProperty("AutoScroll", Dvpanel_reporeprofesional_Autoscroll);
            ucDvpanel_reporeprofesional.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_reporeprofesional_Internalname, "DVPANEL_REPOREPROFESIONALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_REPOREPROFESIONALContainer"+"ReporeProfesional"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divReporeprofesional_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavProfesional_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavProfesional_Internalname, context.GetMessage( "Profesional", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavProfesional, cmbavProfesional_Internalname, StringUtil.RTrim( AV7Profesional), 1, cmbavProfesional_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavProfesional.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "", true, 0, "HLP_ReportesProfesionales.htm");
            cmbavProfesional.CurrentValue = StringUtil.RTrim( AV7Profesional);
            AssignProp("", false, cmbavProfesional_Internalname, "Values", (string)(cmbavProfesional.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavClasificaciones_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavClasificaciones_Internalname, context.GetMessage( "Clasificaciones", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavClasificaciones, cmbavClasificaciones_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV10Clasificaciones), 4, 0)), 1, cmbavClasificaciones_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavClasificaciones.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "", true, 0, "HLP_ReportesProfesionales.htm");
            cmbavClasificaciones.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10Clasificaciones), 4, 0));
            AssignProp("", false, cmbavClasificaciones_Internalname, "Values", (string)(cmbavClasificaciones.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-5", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavSolicitudservicioorigenpago_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavSolicitudservicioorigenpago_Internalname, context.GetMessage( "Origen de Pago", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSolicitudservicioorigenpago, cmbavSolicitudservicioorigenpago_Internalname, StringUtil.RTrim( AV12SolicitudServicioOrigenPago), 1, cmbavSolicitudservicioorigenpago_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavSolicitudservicioorigenpago.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "", true, 0, "HLP_ReportesProfesionales.htm");
            cmbavSolicitudservicioorigenpago.CurrentValue = StringUtil.RTrim( AV12SolicitudServicioOrigenPago);
            AssignProp("", false, cmbavSolicitudservicioorigenpago_Internalname, "Values", (string)(cmbavSolicitudservicioorigenpago.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavDesde_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDesde_Internalname, context.GetMessage( "Desde", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavDesde_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavDesde_Internalname, context.localUtil.Format(AV5Desde, "99/99/99"), context.localUtil.Format( AV5Desde, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDesde_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavDesde_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ReportesProfesionales.htm");
            GxWebStd.gx_bitmap( context, edtavDesde_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavDesde_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_ReportesProfesionales.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavHasta_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavHasta_Internalname, context.GetMessage( "Hasta", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavHasta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavHasta_Internalname, context.localUtil.Format(AV6hasta, "99/99/99"), context.localUtil.Format( AV6hasta, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavHasta_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavHasta_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ReportesProfesionales.htm");
            GxWebStd.gx_bitmap( context, edtavHasta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavHasta_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_ReportesProfesionales.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "Reporte del Profesional", ""), grpUnnamedgroup1_Visible, 0, "px", 0, "px", "Group", "", "HLP_ReportesProfesionales.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGrupo1_Internalname, 1, 100, "%", 0, "px", "SpacingTable", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:50fr 50fr;grid-template-rows:auto auto;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnreporteasignaciondecomisiones_Internalname, "", context.GetMessage( "Reporte Asignación de Comisiones", ""), bttBtnreporteasignaciondecomisiones_Jsonclick, 5, context.GetMessage( "Reporte Asignación de Comisiones", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOREPORTEASIGNACIONDECOMISIONES\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReportesProfesionales.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavInctotal_Internalname, context.GetMessage( "Inc Total", ""), "gx-form-item CardDescriptionLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
            ClassString = "CardDescription";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavInctotal_Internalname, StringUtil.BoolToStr( AV24IncTotal), "", context.GetMessage( "Inc Total", ""), chkavInctotal.Visible, chkavInctotal.Enabled, "true", context.GetMessage( "Incluir Totales", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(42, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,42);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DscTop", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablexls_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockxls_Internalname, "", "", "", lblTextblockxls_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_ReportesProfesionales.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavXls_Internalname, context.GetMessage( "XLS", ""), "col-sm-3 CardDescriptionLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
            ClassString = "CardDescription";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavXls_Internalname, StringUtil.BoolToStr( AV15XLS), "", context.GetMessage( "XLS", ""), 1, chkavXls.Enabled, "true", context.GetMessage( "Exportar a Excel", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(50, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,50);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, context.GetMessage( "Reporte Económico", ""), grpUnnamedgroup2_Visible, 0, "px", 0, "px", "Group", "", "HLP_ReportesProfesionales.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGrupo2_Internalname, 1, 100, "%", 0, "px", "SpacingTable", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:33fr 33fr 34fr;grid-template-rows:auto;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnreporteeconomico_Internalname, "", context.GetMessage( "Reporte Economico", ""), bttBtnreporteeconomico_Jsonclick, 5, context.GetMessage( "Reporte Economico", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOREPORTEECONOMICO\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReportesProfesionales.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavDetallado_Internalname, context.GetMessage( "Detallado", ""), "gx-form-item CardDescriptionLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
            ClassString = "CardDescription";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDetallado_Internalname, StringUtil.BoolToStr( AV25Detallado), "", context.GetMessage( "Detallado", ""), 1, chkavDetallado.Enabled, "true", context.GetMessage( "Detallado de Importes", ""), StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,60);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavInctotaleco_Internalname, context.GetMessage( "Inc Total Eco", ""), "gx-form-item CardDescriptionLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
            ClassString = "CardDescription";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavInctotaleco_Internalname, StringUtil.BoolToStr( AV26IncTotalEco), "", context.GetMessage( "Inc Total Eco", ""), chkavInctotaleco.Visible, chkavInctotaleco.Enabled, "true", context.GetMessage( "Incluir Totales", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(63, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,63);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup3_Internalname, context.GetMessage( "Reporte de Comisiones", ""), grpUnnamedgroup3_Visible, 0, "px", 0, "px", "Group", "", "HLP_ReportesProfesionales.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGrupo3_Internalname, 1, 100, "%", 0, "px", "SpacingTable", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:33fr 33fr 34fr;grid-template-rows:auto;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnreportecomisiones_Internalname, "", context.GetMessage( "Reporte de Comisiones", ""), bttBtnreportecomisiones_Jsonclick, 5, context.GetMessage( "Reporte de Comisiones", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOREPORTECOMISIONES\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReportesProfesionales.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavOpciones_Internalname, context.GetMessage( "Opciones", ""), "gx-form-item CardDescriptionLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
            ClassString = "CardDescription";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavOpciones_Internalname, AV13Opciones, "", context.GetMessage( "Opciones", ""), 1, chkavOpciones.Enabled, "S", context.GetMessage( "Verificar Comisiones", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(72, this, 'S', 'N',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,72);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavVeridicar_Internalname, context.GetMessage( "Veridicar", ""), "gx-form-item CardDescriptionLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
            ClassString = "CardDescription";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavVeridicar_Internalname, AV14Veridicar, "", context.GetMessage( "Veridicar", ""), 1, chkavVeridicar.Enabled, "S", context.GetMessage( "Verificar Porcentajes", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(75, this, 'S', 'N',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,75);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucToastr1.Render(context, "toastr", Toastr1_Internalname, "TOASTR1Container");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, "INNEWWINDOW1Container");
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

      protected void START7U2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Reportes Profesionales", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP7U0( ) ;
      }

      protected void WS7U2( )
      {
         START7U2( ) ;
         EVT7U2( ) ;
      }

      protected void EVT7U2( )
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
                              E117U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOREPORTECOMISIONES'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoReporteComisiones' */
                              E127U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOREPORTEECONOMICO'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoReporteEconomico' */
                              E137U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOREPORTEASIGNACIONDECOMISIONES'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoReporteAsignaciondeComisiones' */
                              E147U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E157U2 ();
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

      protected void WE7U2( )
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

      protected void PA7U2( )
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
               GX_FocusControl = cmbavProfesional_Internalname;
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
         if ( cmbavProfesional.ItemCount > 0 )
         {
            AV7Profesional = cmbavProfesional.getValidValue(AV7Profesional);
            AssignAttri("", false, "AV7Profesional", AV7Profesional);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavProfesional.CurrentValue = StringUtil.RTrim( AV7Profesional);
            AssignProp("", false, cmbavProfesional_Internalname, "Values", cmbavProfesional.ToJavascriptSource(), true);
         }
         if ( cmbavClasificaciones.ItemCount > 0 )
         {
            AV10Clasificaciones = (short)(Math.Round(NumberUtil.Val( cmbavClasificaciones.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV10Clasificaciones), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV10Clasificaciones", StringUtil.LTrimStr( (decimal)(AV10Clasificaciones), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavClasificaciones.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10Clasificaciones), 4, 0));
            AssignProp("", false, cmbavClasificaciones_Internalname, "Values", cmbavClasificaciones.ToJavascriptSource(), true);
         }
         if ( cmbavSolicitudservicioorigenpago.ItemCount > 0 )
         {
            AV12SolicitudServicioOrigenPago = cmbavSolicitudservicioorigenpago.getValidValue(AV12SolicitudServicioOrigenPago);
            AssignAttri("", false, "AV12SolicitudServicioOrigenPago", AV12SolicitudServicioOrigenPago);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSolicitudservicioorigenpago.CurrentValue = StringUtil.RTrim( AV12SolicitudServicioOrigenPago);
            AssignProp("", false, cmbavSolicitudservicioorigenpago_Internalname, "Values", cmbavSolicitudservicioorigenpago.ToJavascriptSource(), true);
         }
         AV24IncTotal = StringUtil.StrToBool( StringUtil.BoolToStr( AV24IncTotal));
         AssignAttri("", false, "AV24IncTotal", AV24IncTotal);
         AV15XLS = StringUtil.StrToBool( StringUtil.BoolToStr( AV15XLS));
         AssignAttri("", false, "AV15XLS", AV15XLS);
         AV25Detallado = StringUtil.StrToBool( StringUtil.BoolToStr( AV25Detallado));
         AssignAttri("", false, "AV25Detallado", AV25Detallado);
         AV26IncTotalEco = StringUtil.StrToBool( StringUtil.BoolToStr( AV26IncTotalEco));
         AssignAttri("", false, "AV26IncTotalEco", AV26IncTotalEco);
         AV13Opciones = ((StringUtil.StrCmp(StringUtil.RTrim( AV13Opciones), "S")==0) ? "S" : "N");
         AssignAttri("", false, "AV13Opciones", AV13Opciones);
         AV14Veridicar = ((StringUtil.StrCmp(StringUtil.RTrim( AV14Veridicar), "S")==0) ? "S" : "N");
         AssignAttri("", false, "AV14Veridicar", AV14Veridicar);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF7U2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF7U2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E157U2 ();
            WB7U0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes7U2( )
      {
         GxWebStd.gx_hidden_field( context, "vSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9SolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9SolicitudesId), "ZZZZZZZZZZZZZZZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7U0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E117U2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Dvpanel_reporeprofesional_Width = cgiGet( "DVPANEL_REPOREPROFESIONAL_Width");
            Dvpanel_reporeprofesional_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_REPOREPROFESIONAL_Autowidth"));
            Dvpanel_reporeprofesional_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_REPOREPROFESIONAL_Autoheight"));
            Dvpanel_reporeprofesional_Cls = cgiGet( "DVPANEL_REPOREPROFESIONAL_Cls");
            Dvpanel_reporeprofesional_Title = cgiGet( "DVPANEL_REPOREPROFESIONAL_Title");
            Dvpanel_reporeprofesional_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_REPOREPROFESIONAL_Collapsible"));
            Dvpanel_reporeprofesional_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_REPOREPROFESIONAL_Collapsed"));
            Dvpanel_reporeprofesional_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_REPOREPROFESIONAL_Showcollapseicon"));
            Dvpanel_reporeprofesional_Iconposition = cgiGet( "DVPANEL_REPOREPROFESIONAL_Iconposition");
            Dvpanel_reporeprofesional_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_REPOREPROFESIONAL_Autoscroll"));
            Innewwindow1_Width = cgiGet( "INNEWWINDOW1_Width");
            Innewwindow1_Height = cgiGet( "INNEWWINDOW1_Height");
            Innewwindow1_Target = cgiGet( "INNEWWINDOW1_Target");
            /* Read variables values. */
            cmbavProfesional.CurrentValue = cgiGet( cmbavProfesional_Internalname);
            AV7Profesional = cgiGet( cmbavProfesional_Internalname);
            AssignAttri("", false, "AV7Profesional", AV7Profesional);
            cmbavClasificaciones.CurrentValue = cgiGet( cmbavClasificaciones_Internalname);
            AV10Clasificaciones = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavClasificaciones_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV10Clasificaciones", StringUtil.LTrimStr( (decimal)(AV10Clasificaciones), 4, 0));
            cmbavSolicitudservicioorigenpago.CurrentValue = cgiGet( cmbavSolicitudservicioorigenpago_Internalname);
            AV12SolicitudServicioOrigenPago = cgiGet( cmbavSolicitudservicioorigenpago_Internalname);
            AssignAttri("", false, "AV12SolicitudServicioOrigenPago", AV12SolicitudServicioOrigenPago);
            if ( context.localUtil.VCDate( cgiGet( edtavDesde_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Desde", "")}), 1, "vDESDE");
               GX_FocusControl = edtavDesde_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Desde = DateTime.MinValue;
               AssignAttri("", false, "AV5Desde", context.localUtil.Format(AV5Desde, "99/99/99"));
            }
            else
            {
               AV5Desde = context.localUtil.CToD( cgiGet( edtavDesde_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV5Desde", context.localUtil.Format(AV5Desde, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavHasta_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "hasta", "")}), 1, "vHASTA");
               GX_FocusControl = edtavHasta_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6hasta = DateTime.MinValue;
               AssignAttri("", false, "AV6hasta", context.localUtil.Format(AV6hasta, "99/99/99"));
            }
            else
            {
               AV6hasta = context.localUtil.CToD( cgiGet( edtavHasta_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV6hasta", context.localUtil.Format(AV6hasta, "99/99/99"));
            }
            AV24IncTotal = StringUtil.StrToBool( cgiGet( chkavInctotal_Internalname));
            AssignAttri("", false, "AV24IncTotal", AV24IncTotal);
            AV15XLS = StringUtil.StrToBool( cgiGet( chkavXls_Internalname));
            AssignAttri("", false, "AV15XLS", AV15XLS);
            AV25Detallado = StringUtil.StrToBool( cgiGet( chkavDetallado_Internalname));
            AssignAttri("", false, "AV25Detallado", AV25Detallado);
            AV26IncTotalEco = StringUtil.StrToBool( cgiGet( chkavInctotaleco_Internalname));
            AssignAttri("", false, "AV26IncTotalEco", AV26IncTotalEco);
            AV13Opciones = ((StringUtil.StrCmp(cgiGet( chkavOpciones_Internalname), "S")==0) ? "S" : "N");
            AssignAttri("", false, "AV13Opciones", AV13Opciones);
            AV14Veridicar = ((StringUtil.StrCmp(cgiGet( chkavVeridicar_Internalname), "S")==0) ? "S" : "N");
            AssignAttri("", false, "AV14Veridicar", AV14Veridicar);
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
         E117U2 ();
         if (returnInSub) return;
      }

      protected void E117U2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV5Desde = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         AssignAttri("", false, "AV5Desde", context.localUtil.Format(AV5Desde, "99/99/99"));
         AV6hasta = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         AssignAttri("", false, "AV6hasta", context.localUtil.Format(AV6hasta, "99/99/99"));
         AV5Desde = DateTimeUtil.DAdd(AV5Desde,-((int)(120)));
         AssignAttri("", false, "AV5Desde", context.localUtil.Format(AV5Desde, "99/99/99"));
         AV10Clasificaciones = 0;
         AssignAttri("", false, "AV10Clasificaciones", StringUtil.LTrimStr( (decimal)(AV10Clasificaciones), 4, 0));
         /* Execute user subroutine: 'OBTENER PROFESIONALES' */
         S112 ();
         if (returnInSub) return;
         AV12SolicitudServicioOrigenPago = "";
         AssignAttri("", false, "AV12SolicitudServicioOrigenPago", AV12SolicitudServicioOrigenPago);
         AV13Opciones = context.GetMessage( "N", "");
         AssignAttri("", false, "AV13Opciones", AV13Opciones);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV19WWPContext) ;
         AV20Roles = AV19WWPContext.gxTpr_Roles;
         AV27GXV1 = 1;
         while ( AV27GXV1 <= AV20Roles.gxTpr_Roles.Count )
         {
            AV21RolesItem = ((SdtSDTRoles_Id)AV20Roles.gxTpr_Roles.Item(AV27GXV1));
            AV22SecRoleName = AV21RolesItem.gxTpr_Secrolename;
            AV27GXV1 = (int)(AV27GXV1+1);
         }
         if ( ( ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( AV22SecRoleName)), context.GetMessage( "ADMINISTRATOR", "")) == 0 ) ) || ( ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( AV22SecRoleName)), context.GetMessage( "ADM GENERAL", "")) == 0 ) ) || ( ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( AV22SecRoleName)), context.GetMessage( "ADM CONTABLE", "")) == 0 ) ) || ( ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( AV22SecRoleName)), context.GetMessage( "GERENTE GENERAL", "")) == 0 ) ) || ( ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( AV22SecRoleName)), context.GetMessage( "STELA RPA", "")) == 0 ) ) )
         {
            AV23HacerLoad = true;
         }
         else
         {
            AV23HacerLoad = false;
         }
         AV26IncTotalEco = false;
         AssignAttri("", false, "AV26IncTotalEco", AV26IncTotalEco);
         if ( ! AV23HacerLoad )
         {
            grpUnnamedgroup1_Visible = 0;
            AssignProp("", false, grpUnnamedgroup1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(grpUnnamedgroup1_Visible), 5, 0), true);
            grpUnnamedgroup2_Visible = 0;
            AssignProp("", false, grpUnnamedgroup2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(grpUnnamedgroup2_Visible), 5, 0), true);
            grpUnnamedgroup3_Visible = 0;
            AssignProp("", false, grpUnnamedgroup3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(grpUnnamedgroup3_Visible), 5, 0), true);
            chkavInctotal.Visible = 0;
            AssignProp("", false, chkavInctotal_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavInctotal.Visible), 5, 0), true);
            chkavInctotaleco.Visible = 0;
            AssignProp("", false, chkavInctotaleco_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavInctotaleco.Visible), 5, 0), true);
            if ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( AV22SecRoleName)), context.GetMessage( "ADM EJECUTIVO", "")) == 0 )
            {
               AV24IncTotal = false;
               AssignAttri("", false, "AV24IncTotal", AV24IncTotal);
               grpUnnamedgroup2_Visible = 1;
               AssignProp("", false, grpUnnamedgroup2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(grpUnnamedgroup2_Visible), 5, 0), true);
            }
         }
      }

      protected void E127U2( )
      {
         /* 'DoReporteComisiones' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7Profesional)) )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "areporteprofcomi.aspx"+UrlEncode(StringUtil.RTrim(AV7Profesional)) + "," + UrlEncode(StringUtil.LTrimStr(AV9SolicitudesId,18,0)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV5Desde)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV6hasta)) + "," + UrlEncode(StringUtil.LTrimStr(AV10Clasificaciones,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV12SolicitudServicioOrigenPago)) + "," + UrlEncode(StringUtil.RTrim(AV13Opciones)) + "," + UrlEncode(StringUtil.RTrim(AV14Veridicar));
            Innewwindow1_Target = formatLink("areporteprofcomi.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
            Innewwindow1_Height = "600";
            ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
            Innewwindow1_Width = "800";
            ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
            this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
         }
         else
         {
            AV11Titulo = context.GetMessage( "Error: ", "");
            this.executeUsercontrolMethod("", false, "TOASTR1Container", "Msg", "", new Object[] {(string)"success",context.GetMessage( "Debe seleccionar un profesional.", ""),(string)AV11Titulo});
         }
         /*  Sending Event outputs  */
      }

      protected void E137U2( )
      {
         /* 'DoReporteEconomico' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7Profesional)) )
         {
            if ( ! AV25Detallado )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "areporteeconomico.aspx"+UrlEncode(StringUtil.RTrim(AV7Profesional)) + "," + UrlEncode(StringUtil.LTrimStr(AV9SolicitudesId,18,0)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV5Desde)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV6hasta)) + "," + UrlEncode(StringUtil.LTrimStr(AV10Clasificaciones,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV12SolicitudServicioOrigenPago)) + "," + UrlEncode(StringUtil.BoolToStr(AV26IncTotalEco));
               Innewwindow1_Target = formatLink("areporteeconomico.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
               ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
               Innewwindow1_Height = "600";
               ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
               Innewwindow1_Width = "800";
               ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
               this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
            }
            else if ( AV25Detallado )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "areporteeconomicodetallado.aspx"+UrlEncode(StringUtil.RTrim(AV7Profesional)) + "," + UrlEncode(StringUtil.LTrimStr(AV9SolicitudesId,18,0)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV5Desde)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV6hasta)) + "," + UrlEncode(StringUtil.LTrimStr(AV10Clasificaciones,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV12SolicitudServicioOrigenPago));
               Innewwindow1_Target = formatLink("areporteeconomicodetallado.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
               ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
               Innewwindow1_Height = "600";
               ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
               Innewwindow1_Width = "800";
               ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
               this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
            }
         }
         else
         {
            AV11Titulo = context.GetMessage( "Error: ", "");
            this.executeUsercontrolMethod("", false, "TOASTR1Container", "Msg", "", new Object[] {(string)"success",context.GetMessage( "Debe seleccionar un profesional.", ""),(string)AV11Titulo});
         }
         /*  Sending Event outputs  */
      }

      protected void E147U2( )
      {
         /* 'DoReporteAsignaciondeComisiones' Routine */
         returnInSub = false;
         if ( AV15XLS )
         {
            new reportecomgeneralesxls(context ).execute(  AV7Profesional,  AV5Desde,  AV6hasta,  AV10Clasificaciones,  AV12SolicitudServicioOrigenPago) ;
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7Profesional)) )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "areportecomgenerales.aspx"+UrlEncode(StringUtil.RTrim(AV7Profesional)) + "," + UrlEncode(StringUtil.LTrimStr(AV9SolicitudesId,18,0)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV5Desde)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV6hasta)) + "," + UrlEncode(StringUtil.LTrimStr(AV10Clasificaciones,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV12SolicitudServicioOrigenPago));
               Innewwindow1_Target = formatLink("areportecomgenerales.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
               ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
               Innewwindow1_Height = "600";
               ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
               Innewwindow1_Width = "800";
               ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
               this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
            }
            else
            {
               AV11Titulo = context.GetMessage( "Error: ", "");
               this.executeUsercontrolMethod("", false, "TOASTR1Container", "Msg", "", new Object[] {(string)"success",context.GetMessage( "Debe seleccionar un profesional.", ""),(string)AV11Titulo});
            }
         }
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'OBTENER PROFESIONALES' Routine */
         returnInSub = false;
         /* Using cursor H007U2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A108EstadosGenericosId = H007U2_A108EstadosGenericosId[0];
            A107EstadosTipo = H007U2_A107EstadosTipo[0];
            A167ProfesionalesApellidoPrimero = H007U2_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = H007U2_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = H007U2_A120ProfesionalesId[0];
            if ( StringUtil.StrCmp(A107EstadosTipo, context.GetMessage( "STS", "")) == 0 )
            {
               AV8Nombre = StringUtil.Trim( A166ProfesionalesPrimerNombre) + ", " + StringUtil.Trim( A167ProfesionalesApellidoPrimero);
               cmbavProfesional.addItem(A120ProfesionalesId, AV8Nombre, 0);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void nextLoad( )
      {
      }

      protected void E157U2( )
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
         PA7U2( ) ;
         WS7U2( ) ;
         WE7U2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021212439", true, true, false);
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
         context.AddJavascriptSource("reportesprofesionales.js", "?202673021212439", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("Toastr/toastr.min.js", "", false, true, false);
         context.AddJavascriptSource("Toastr/ToastrRender.js", "", false, true, false);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavProfesional.Name = "vPROFESIONAL";
         cmbavProfesional.WebTags = "";
         cmbavProfesional.addItem("", context.GetMessage( "Todos", ""), 0);
         if ( cmbavProfesional.ItemCount > 0 )
         {
            AV7Profesional = cmbavProfesional.getValidValue(AV7Profesional);
            AssignAttri("", false, "AV7Profesional", AV7Profesional);
         }
         cmbavClasificaciones.Name = "vCLASIFICACIONES";
         cmbavClasificaciones.WebTags = "";
         cmbavClasificaciones.addItem("0", context.GetMessage( "Todas las Clasificaciones", ""), 0);
         cmbavClasificaciones.addItem("8", context.GetMessage( "Habilitado", ""), 0);
         cmbavClasificaciones.addItem("2", context.GetMessage( "Delegado", ""), 0);
         cmbavClasificaciones.addItem("5", context.GetMessage( "Aceptada", ""), 0);
         cmbavClasificaciones.addItem("6", context.GetMessage( "Finalizado", ""), 0);
         cmbavClasificaciones.addItem("7", context.GetMessage( "Calificado", ""), 0);
         if ( cmbavClasificaciones.ItemCount > 0 )
         {
            AV10Clasificaciones = (short)(Math.Round(NumberUtil.Val( cmbavClasificaciones.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV10Clasificaciones), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV10Clasificaciones", StringUtil.LTrimStr( (decimal)(AV10Clasificaciones), 4, 0));
         }
         cmbavSolicitudservicioorigenpago.Name = "vSOLICITUDSERVICIOORIGENPAGO";
         cmbavSolicitudservicioorigenpago.WebTags = "";
         cmbavSolicitudservicioorigenpago.addItem("", context.GetMessage( "Todos", ""), 0);
         cmbavSolicitudservicioorigenpago.addItem("F", context.GetMessage( "Cobro Directo", ""), 0);
         cmbavSolicitudservicioorigenpago.addItem("T", context.GetMessage( "Cobro Prepago Comercio", ""), 0);
         cmbavSolicitudservicioorigenpago.addItem("O", context.GetMessage( "Cobro Prepago Almango", ""), 0);
         if ( cmbavSolicitudservicioorigenpago.ItemCount > 0 )
         {
            AV12SolicitudServicioOrigenPago = cmbavSolicitudservicioorigenpago.getValidValue(AV12SolicitudServicioOrigenPago);
            AssignAttri("", false, "AV12SolicitudServicioOrigenPago", AV12SolicitudServicioOrigenPago);
         }
         chkavInctotal.Name = "vINCTOTAL";
         chkavInctotal.WebTags = "";
         chkavInctotal.Caption = context.GetMessage( "Inc Total", "");
         AssignProp("", false, chkavInctotal_Internalname, "TitleCaption", chkavInctotal.Caption, true);
         chkavInctotal.CheckedValue = "false";
         AV24IncTotal = StringUtil.StrToBool( StringUtil.BoolToStr( AV24IncTotal));
         AssignAttri("", false, "AV24IncTotal", AV24IncTotal);
         chkavXls.Name = "vXLS";
         chkavXls.WebTags = "";
         chkavXls.Caption = context.GetMessage( "XLS", "");
         AssignProp("", false, chkavXls_Internalname, "TitleCaption", chkavXls.Caption, true);
         chkavXls.CheckedValue = "false";
         AV15XLS = StringUtil.StrToBool( StringUtil.BoolToStr( AV15XLS));
         AssignAttri("", false, "AV15XLS", AV15XLS);
         chkavDetallado.Name = "vDETALLADO";
         chkavDetallado.WebTags = "";
         chkavDetallado.Caption = context.GetMessage( "Detallado", "");
         AssignProp("", false, chkavDetallado_Internalname, "TitleCaption", chkavDetallado.Caption, true);
         chkavDetallado.CheckedValue = "false";
         AV25Detallado = StringUtil.StrToBool( StringUtil.BoolToStr( AV25Detallado));
         AssignAttri("", false, "AV25Detallado", AV25Detallado);
         chkavInctotaleco.Name = "vINCTOTALECO";
         chkavInctotaleco.WebTags = "";
         chkavInctotaleco.Caption = context.GetMessage( "Inc Total Eco", "");
         AssignProp("", false, chkavInctotaleco_Internalname, "TitleCaption", chkavInctotaleco.Caption, true);
         chkavInctotaleco.CheckedValue = "false";
         AV26IncTotalEco = StringUtil.StrToBool( StringUtil.BoolToStr( AV26IncTotalEco));
         AssignAttri("", false, "AV26IncTotalEco", AV26IncTotalEco);
         chkavOpciones.Name = "vOPCIONES";
         chkavOpciones.WebTags = "";
         chkavOpciones.Caption = context.GetMessage( "Opciones", "");
         AssignProp("", false, chkavOpciones_Internalname, "TitleCaption", chkavOpciones.Caption, true);
         chkavOpciones.CheckedValue = "N";
         AV13Opciones = ((StringUtil.StrCmp(StringUtil.RTrim( AV13Opciones), "S")==0) ? "S" : "N");
         AssignAttri("", false, "AV13Opciones", AV13Opciones);
         chkavVeridicar.Name = "vVERIDICAR";
         chkavVeridicar.WebTags = "";
         chkavVeridicar.Caption = context.GetMessage( "Veridicar", "");
         AssignProp("", false, chkavVeridicar_Internalname, "TitleCaption", chkavVeridicar.Caption, true);
         chkavVeridicar.CheckedValue = "N";
         AV14Veridicar = ((StringUtil.StrCmp(StringUtil.RTrim( AV14Veridicar), "S")==0) ? "S" : "N");
         AssignAttri("", false, "AV14Veridicar", AV14Veridicar);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         cmbavProfesional_Internalname = "vPROFESIONAL";
         cmbavClasificaciones_Internalname = "vCLASIFICACIONES";
         cmbavSolicitudservicioorigenpago_Internalname = "vSOLICITUDSERVICIOORIGENPAGO";
         edtavDesde_Internalname = "vDESDE";
         edtavHasta_Internalname = "vHASTA";
         divReporeprofesional_Internalname = "REPOREPROFESIONAL";
         Dvpanel_reporeprofesional_Internalname = "DVPANEL_REPOREPROFESIONAL";
         bttBtnreporteasignaciondecomisiones_Internalname = "BTNREPORTEASIGNACIONDECOMISIONES";
         chkavInctotal_Internalname = "vINCTOTAL";
         lblTextblockxls_Internalname = "TEXTBLOCKXLS";
         chkavXls_Internalname = "vXLS";
         divUnnamedtablexls_Internalname = "UNNAMEDTABLEXLS";
         divGrupo1_Internalname = "GRUPO1";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         bttBtnreporteeconomico_Internalname = "BTNREPORTEECONOMICO";
         chkavDetallado_Internalname = "vDETALLADO";
         chkavInctotaleco_Internalname = "vINCTOTALECO";
         divGrupo2_Internalname = "GRUPO2";
         grpUnnamedgroup2_Internalname = "UNNAMEDGROUP2";
         bttBtnreportecomisiones_Internalname = "BTNREPORTECOMISIONES";
         chkavOpciones_Internalname = "vOPCIONES";
         chkavVeridicar_Internalname = "vVERIDICAR";
         divGrupo3_Internalname = "GRUPO3";
         grpUnnamedgroup3_Internalname = "UNNAMEDGROUP3";
         Toastr1_Internalname = "TOASTR1";
         Innewwindow1_Internalname = "INNEWWINDOW1";
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
         chkavVeridicar.Caption = context.GetMessage( "Veridicar", "");
         chkavOpciones.Caption = context.GetMessage( "Opciones", "");
         chkavInctotaleco.Caption = context.GetMessage( "Inc Total Eco", "");
         chkavDetallado.Caption = context.GetMessage( "Detallado", "");
         chkavXls.Caption = context.GetMessage( "XLS", "");
         chkavInctotal.Caption = context.GetMessage( "Inc Total", "");
         chkavVeridicar.Enabled = 1;
         chkavOpciones.Enabled = 1;
         grpUnnamedgroup3_Visible = 1;
         chkavInctotaleco.Enabled = 1;
         chkavInctotaleco.Visible = 1;
         chkavDetallado.Enabled = 1;
         grpUnnamedgroup2_Visible = 1;
         chkavXls.Enabled = 1;
         chkavInctotal.Enabled = 1;
         chkavInctotal.Visible = 1;
         grpUnnamedgroup1_Visible = 1;
         edtavHasta_Jsonclick = "";
         edtavHasta_Enabled = 1;
         edtavDesde_Jsonclick = "";
         edtavDesde_Enabled = 1;
         cmbavSolicitudservicioorigenpago_Jsonclick = "";
         cmbavSolicitudservicioorigenpago.Enabled = 1;
         cmbavClasificaciones_Jsonclick = "";
         cmbavClasificaciones.Enabled = 1;
         cmbavProfesional_Jsonclick = "";
         cmbavProfesional.Enabled = 1;
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Dvpanel_reporeprofesional_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_reporeprofesional_Iconposition = "Right";
         Dvpanel_reporeprofesional_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_reporeprofesional_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_reporeprofesional_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_reporeprofesional_Title = context.GetMessage( "Reporte de Profesionales", "");
         Dvpanel_reporeprofesional_Cls = "PanelGrayBackgroundTitle";
         Dvpanel_reporeprofesional_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_reporeprofesional_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_reporeprofesional_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Reportes Profesionales", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV24IncTotal',fld:'vINCTOTAL',pic:'',type:'boolean'},{av:'AV15XLS',fld:'vXLS',pic:'',type:'boolean'},{av:'AV25Detallado',fld:'vDETALLADO',pic:'',type:'boolean'},{av:'AV26IncTotalEco',fld:'vINCTOTALECO',pic:'',type:'boolean'},{av:'AV13Opciones',fld:'vOPCIONES',pic:'',type:'char'},{av:'AV14Veridicar',fld:'vVERIDICAR',pic:'',type:'char'},{av:'AV9SolicitudesId',fld:'vSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOREPORTECOMISIONES'","{handler:'E127U2',iparms:[{av:'cmbavProfesional'},{av:'AV7Profesional',fld:'vPROFESIONAL',pic:'',type:'char'},{av:'AV9SolicitudesId',fld:'vSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV5Desde',fld:'vDESDE',pic:'',type:'date'},{av:'AV6hasta',fld:'vHASTA',pic:'',type:'date'},{av:'cmbavClasificaciones'},{av:'AV10Clasificaciones',fld:'vCLASIFICACIONES',pic:'ZZZ9',type:'int'},{av:'cmbavSolicitudservicioorigenpago'},{av:'AV12SolicitudServicioOrigenPago',fld:'vSOLICITUDSERVICIOORIGENPAGO',pic:'',type:'char'},{av:'AV13Opciones',fld:'vOPCIONES',pic:'',type:'char'},{av:'AV14Veridicar',fld:'vVERIDICAR',pic:'',type:'char'}]");
         setEventMetadata("'DOREPORTECOMISIONES'",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'}]}");
         setEventMetadata("'DOREPORTEECONOMICO'","{handler:'E137U2',iparms:[{av:'cmbavProfesional'},{av:'AV7Profesional',fld:'vPROFESIONAL',pic:'',type:'char'},{av:'AV25Detallado',fld:'vDETALLADO',pic:'',type:'boolean'},{av:'AV9SolicitudesId',fld:'vSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV5Desde',fld:'vDESDE',pic:'',type:'date'},{av:'AV6hasta',fld:'vHASTA',pic:'',type:'date'},{av:'cmbavClasificaciones'},{av:'AV10Clasificaciones',fld:'vCLASIFICACIONES',pic:'ZZZ9',type:'int'},{av:'cmbavSolicitudservicioorigenpago'},{av:'AV12SolicitudServicioOrigenPago',fld:'vSOLICITUDSERVICIOORIGENPAGO',pic:'',type:'char'},{av:'AV26IncTotalEco',fld:'vINCTOTALECO',pic:'',type:'boolean'}]");
         setEventMetadata("'DOREPORTEECONOMICO'",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'}]}");
         setEventMetadata("'DOREPORTEASIGNACIONDECOMISIONES'","{handler:'E147U2',iparms:[{av:'AV15XLS',fld:'vXLS',pic:'',type:'boolean'},{av:'cmbavProfesional'},{av:'AV7Profesional',fld:'vPROFESIONAL',pic:'',type:'char'},{av:'AV5Desde',fld:'vDESDE',pic:'',type:'date'},{av:'AV6hasta',fld:'vHASTA',pic:'',type:'date'},{av:'cmbavClasificaciones'},{av:'AV10Clasificaciones',fld:'vCLASIFICACIONES',pic:'ZZZ9',type:'int'},{av:'cmbavSolicitudservicioorigenpago'},{av:'AV12SolicitudServicioOrigenPago',fld:'vSOLICITUDSERVICIOORIGENPAGO',pic:'',type:'char'},{av:'AV9SolicitudesId',fld:'vSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'DOREPORTEASIGNACIONDECOMISIONES'",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'}]}");
         setEventMetadata("VALIDV_SOLICITUDSERVICIOORIGENPAGO","{handler:'Validv_Solicitudservicioorigenpago',iparms:[]");
         setEventMetadata("VALIDV_SOLICITUDSERVICIOORIGENPAGO",",oparms:[]}");
         setEventMetadata("VALIDV_DESDE","{handler:'Validv_Desde',iparms:[]");
         setEventMetadata("VALIDV_DESDE",",oparms:[]}");
         setEventMetadata("VALIDV_HASTA","{handler:'Validv_Hasta',iparms:[]");
         setEventMetadata("VALIDV_HASTA",",oparms:[]}");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDvpanel_reporeprofesional = new GXUserControl();
         TempTags = "";
         AV7Profesional = "";
         AV12SolicitudServicioOrigenPago = "";
         AV5Desde = DateTime.MinValue;
         AV6hasta = DateTime.MinValue;
         ClassString = "";
         StyleString = "";
         bttBtnreporteasignaciondecomisiones_Jsonclick = "";
         lblTextblockxls_Jsonclick = "";
         bttBtnreporteeconomico_Jsonclick = "";
         bttBtnreportecomisiones_Jsonclick = "";
         AV13Opciones = "";
         AV14Veridicar = "";
         ucToastr1 = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV19WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV20Roles = new SdtSDTRoles(context);
         AV21RolesItem = new SdtSDTRoles_Id(context);
         AV22SecRoleName = "";
         GXEncryptionTmp = "";
         AV11Titulo = "";
         H007U2_A108EstadosGenericosId = new int[1] ;
         H007U2_A107EstadosTipo = new string[] {""} ;
         H007U2_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         H007U2_A166ProfesionalesPrimerNombre = new string[] {""} ;
         H007U2_A120ProfesionalesId = new string[] {""} ;
         A107EstadosTipo = "";
         A167ProfesionalesApellidoPrimero = "";
         A166ProfesionalesPrimerNombre = "";
         A120ProfesionalesId = "";
         AV8Nombre = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reportesprofesionales__default(),
            new Object[][] {
                new Object[] {
               H007U2_A108EstadosGenericosId, H007U2_A107EstadosTipo, H007U2_A167ProfesionalesApellidoPrimero, H007U2_A166ProfesionalesPrimerNombre, H007U2_A120ProfesionalesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV10Clasificaciones ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int edtavDesde_Enabled ;
      private int edtavHasta_Enabled ;
      private int grpUnnamedgroup1_Visible ;
      private int grpUnnamedgroup2_Visible ;
      private int grpUnnamedgroup3_Visible ;
      private int AV27GXV1 ;
      private int A108EstadosGenericosId ;
      private int idxLst ;
      private long AV9SolicitudesId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Dvpanel_reporeprofesional_Width ;
      private string Dvpanel_reporeprofesional_Cls ;
      private string Dvpanel_reporeprofesional_Title ;
      private string Dvpanel_reporeprofesional_Iconposition ;
      private string Innewwindow1_Width ;
      private string Innewwindow1_Height ;
      private string Innewwindow1_Target ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divMaintable_Internalname ;
      private string Dvpanel_reporeprofesional_Internalname ;
      private string divReporeprofesional_Internalname ;
      private string cmbavProfesional_Internalname ;
      private string TempTags ;
      private string AV7Profesional ;
      private string cmbavProfesional_Jsonclick ;
      private string cmbavClasificaciones_Internalname ;
      private string cmbavClasificaciones_Jsonclick ;
      private string cmbavSolicitudservicioorigenpago_Internalname ;
      private string AV12SolicitudServicioOrigenPago ;
      private string cmbavSolicitudservicioorigenpago_Jsonclick ;
      private string edtavDesde_Internalname ;
      private string edtavDesde_Jsonclick ;
      private string edtavHasta_Internalname ;
      private string edtavHasta_Jsonclick ;
      private string grpUnnamedgroup1_Internalname ;
      private string divGrupo1_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnreporteasignaciondecomisiones_Internalname ;
      private string bttBtnreporteasignaciondecomisiones_Jsonclick ;
      private string chkavInctotal_Internalname ;
      private string divUnnamedtablexls_Internalname ;
      private string lblTextblockxls_Internalname ;
      private string lblTextblockxls_Jsonclick ;
      private string chkavXls_Internalname ;
      private string grpUnnamedgroup2_Internalname ;
      private string divGrupo2_Internalname ;
      private string bttBtnreporteeconomico_Internalname ;
      private string bttBtnreporteeconomico_Jsonclick ;
      private string chkavDetallado_Internalname ;
      private string chkavInctotaleco_Internalname ;
      private string grpUnnamedgroup3_Internalname ;
      private string divGrupo3_Internalname ;
      private string bttBtnreportecomisiones_Internalname ;
      private string bttBtnreportecomisiones_Jsonclick ;
      private string chkavOpciones_Internalname ;
      private string AV13Opciones ;
      private string chkavVeridicar_Internalname ;
      private string AV14Veridicar ;
      private string Toastr1_Internalname ;
      private string Innewwindow1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXEncryptionTmp ;
      private string AV11Titulo ;
      private string A107EstadosTipo ;
      private string A167ProfesionalesApellidoPrimero ;
      private string A166ProfesionalesPrimerNombre ;
      private string A120ProfesionalesId ;
      private string AV8Nombre ;
      private DateTime AV5Desde ;
      private DateTime AV6hasta ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_reporeprofesional_Autowidth ;
      private bool Dvpanel_reporeprofesional_Autoheight ;
      private bool Dvpanel_reporeprofesional_Collapsible ;
      private bool Dvpanel_reporeprofesional_Collapsed ;
      private bool Dvpanel_reporeprofesional_Showcollapseicon ;
      private bool Dvpanel_reporeprofesional_Autoscroll ;
      private bool wbLoad ;
      private bool AV24IncTotal ;
      private bool AV15XLS ;
      private bool AV25Detallado ;
      private bool AV26IncTotalEco ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV23HacerLoad ;
      private string AV22SecRoleName ;
      private GXUserControl ucDvpanel_reporeprofesional ;
      private GXUserControl ucToastr1 ;
      private GXUserControl ucInnewwindow1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavProfesional ;
      private GXCombobox cmbavClasificaciones ;
      private GXCombobox cmbavSolicitudservicioorigenpago ;
      private GXCheckbox chkavInctotal ;
      private GXCheckbox chkavXls ;
      private GXCheckbox chkavDetallado ;
      private GXCheckbox chkavInctotaleco ;
      private GXCheckbox chkavOpciones ;
      private GXCheckbox chkavVeridicar ;
      private IDataStoreProvider pr_default ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV19WWPContext ;
      private SdtSDTRoles AV20Roles ;
      private SdtSDTRoles_Id AV21RolesItem ;
      private int[] H007U2_A108EstadosGenericosId ;
      private string[] H007U2_A107EstadosTipo ;
      private string[] H007U2_A167ProfesionalesApellidoPrimero ;
      private string[] H007U2_A166ProfesionalesPrimerNombre ;
      private string[] H007U2_A120ProfesionalesId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class reportesprofesionales__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH007U2;
          prmH007U2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H007U2", "SELECT [EstadosGenericosId], [EstadosTipo], [ProfesionalesApellidoPrimero], [ProfesionalesPrimerNombre], [ProfesionalesId] FROM [Profesionales] WHERE [EstadosGenericosId] = 1 ORDER BY [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007U2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 30);
                ((string[]) buf[3])[0] = rslt.getString(4, 30);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                return;
       }
    }

 }

}
