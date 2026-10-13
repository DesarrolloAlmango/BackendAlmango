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
namespace GeneXus.Programs.comercios {
   public class reportecom : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public reportecom( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reportecom( IGxContext context )
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
         cmbavClasificaciones = new GXCombobox();
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
         PAC42( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTC42( ) ;
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
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
         context.AddJavascriptSource("Toastr/toastr.min.js", "", false, true, false);
         context.AddJavascriptSource("Toastr/ToastrRender.js", "", false, true, false);
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
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("comercios.reportecom.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPROVEEDORESTIPOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11ProveedoresTipoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORESTIPOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11ProveedoresTipoId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10proveedorid), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10proveedorid), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINCTOTAL", StringUtil.RTrim( AV14IncTotal));
         GxWebStd.gx_hidden_field( context, "gxhash_vINCTOTAL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14IncTotal, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vPROVEEDORESTIPOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11ProveedoresTipoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORESTIPOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11ProveedoresTipoId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10proveedorid), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10proveedorid), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINCTOTAL", StringUtil.RTrim( AV14IncTotal));
         GxWebStd.gx_hidden_field( context, "gxhash_vINCTOTAL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14IncTotal, "")), context));
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
            WEC42( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTC42( ) ;
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
         return formatLink("comercios.reportecom.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Comercios.ReporteCOM" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Reporte del comercio", "") ;
      }

      protected void WBC40( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavClasificaciones_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavClasificaciones_Internalname, context.GetMessage( "Clasificaciones", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavClasificaciones, cmbavClasificaciones_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV8Clasificaciones), 4, 0)), 1, cmbavClasificaciones_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavClasificaciones.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "", true, 0, "HLP_Comercios/ReporteCOM.htm");
            cmbavClasificaciones.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8Clasificaciones), 4, 0));
            AssignProp("", false, cmbavClasificaciones_Internalname, "Values", (string)(cmbavClasificaciones.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-2 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavDesde_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDesde_Internalname, context.GetMessage( "Desde", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavDesde_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavDesde_Internalname, context.localUtil.Format(AV5Desde, "99/99/99"), context.localUtil.Format( AV5Desde, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDesde_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavDesde_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Comercios/ReporteCOM.htm");
            GxWebStd.gx_bitmap( context, edtavDesde_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavDesde_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Comercios/ReporteCOM.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-2 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavHasta_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavHasta_Internalname, context.GetMessage( "Hasta", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavHasta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavHasta_Internalname, context.localUtil.Format(AV6hasta, "99/99/99"), context.localUtil.Format( AV6hasta, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,24);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavHasta_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavHasta_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Comercios/ReporteCOM.htm");
            GxWebStd.gx_bitmap( context, edtavHasta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavHasta_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Comercios/ReporteCOM.htm");
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
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, context.GetMessage( "Reporte del Económico", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Comercios/ReporteCOM.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 100, "%", 0, "px", "SpacingTable", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:100fr;grid-template-rows:auto;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", context.GetMessage( "PDF", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Comercios/ReporteCOM.htm");
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
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, "INNEWWINDOW1Container");
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void STARTC42( )
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
         Form.Meta.addItem("description", context.GetMessage( "Reporte del comercio", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPC40( ) ;
      }

      protected void WSC42( )
      {
         STARTC42( ) ;
         EVTC42( ) ;
      }

      protected void EVTC42( )
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
                              E11C42 ();
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
                                    E12C42 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E13C42 ();
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

      protected void WEC42( )
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

      protected void PAC42( )
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
               GX_FocusControl = cmbavClasificaciones_Internalname;
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
         if ( cmbavClasificaciones.ItemCount > 0 )
         {
            AV8Clasificaciones = (short)(Math.Round(NumberUtil.Val( cmbavClasificaciones.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV8Clasificaciones), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV8Clasificaciones", StringUtil.LTrimStr( (decimal)(AV8Clasificaciones), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavClasificaciones.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8Clasificaciones), 4, 0));
            AssignProp("", false, cmbavClasificaciones_Internalname, "Values", cmbavClasificaciones.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFC42( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFC42( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E13C42 ();
            WBC40( ) ;
         }
      }

      protected void send_integrity_lvl_hashesC42( )
      {
         GxWebStd.gx_hidden_field( context, "vPROVEEDORESTIPOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11ProveedoresTipoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORESTIPOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11ProveedoresTipoId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10proveedorid), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10proveedorid), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINCTOTAL", StringUtil.RTrim( AV14IncTotal));
         GxWebStd.gx_hidden_field( context, "gxhash_vINCTOTAL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14IncTotal, "")), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUPC40( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11C42 ();
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
            cmbavClasificaciones.CurrentValue = cgiGet( cmbavClasificaciones_Internalname);
            AV8Clasificaciones = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavClasificaciones_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV8Clasificaciones", StringUtil.LTrimStr( (decimal)(AV8Clasificaciones), 4, 0));
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
         E11C42 ();
         if (returnInSub) return;
      }

      protected void E11C42( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV20WWPContext) ;
         AV5Desde = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         AssignAttri("", false, "AV5Desde", context.localUtil.Format(AV5Desde, "99/99/99"));
         AV6hasta = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         AssignAttri("", false, "AV6hasta", context.localUtil.Format(AV6hasta, "99/99/99"));
         AV5Desde = DateTimeUtil.DAdd(AV5Desde,-((int)(120)));
         AssignAttri("", false, "AV5Desde", context.localUtil.Format(AV5Desde, "99/99/99"));
         AV8Clasificaciones = 0;
         AssignAttri("", false, "AV8Clasificaciones", StringUtil.LTrimStr( (decimal)(AV8Clasificaciones), 4, 0));
         /* Execute user subroutine: 'OBTENER TIPO PROVEEDOR' */
         S112 ();
         if (returnInSub) return;
         AV10proveedorid = AV20WWPContext.gxTpr_Proveedorid;
         AssignAttri("", false, "AV10proveedorid", StringUtil.LTrimStr( (decimal)(AV10proveedorid), 18, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10proveedorid), "ZZZZZZZZZZZZZZZZZ9"), context));
         AV14IncTotal = context.GetMessage( "S", "");
         AssignAttri("", false, "AV14IncTotal", AV14IncTotal);
         GxWebStd.gx_hidden_field( context, "gxhash_vINCTOTAL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14IncTotal, "")), context));
         AV15DSPALmango = false;
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E12C42 ();
         if (returnInSub) return;
      }

      protected void E12C42( )
      {
         /* Enter Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "areporteeconomicoprov.aspx"+UrlEncode(StringUtil.LTrimStr(AV11ProveedoresTipoId,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV10proveedorid,18,0)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV5Desde)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV6hasta)) + "," + UrlEncode(StringUtil.LTrimStr(AV8Clasificaciones,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV14IncTotal));
         Innewwindow1_Target = formatLink("areporteeconomicoprov.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'OBTENER TIPO PROVEEDOR' Routine */
         returnInSub = false;
         /* Using cursor H00C42 */
         pr_default.execute(0, new Object[] {AV10proveedorid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A133ProveedorID = H00C42_A133ProveedorID[0];
            A151ProveedoresTipoId = H00C42_A151ProveedoresTipoId[0];
            AV11ProveedoresTipoId = A151ProveedoresTipoId;
            AssignAttri("", false, "AV11ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(AV11ProveedoresTipoId), 18, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORESTIPOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11ProveedoresTipoId), "ZZZZZZZZZZZZZZZZZ9"), context));
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
      }

      protected void nextLoad( )
      {
      }

      protected void E13C42( )
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
         PAC42( ) ;
         WSC42( ) ;
         WEC42( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269320164332", true, true, false);
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
         context.AddJavascriptSource("comercios/reportecom.js", "?20269320164333", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
         context.AddJavascriptSource("Toastr/toastr.min.js", "", false, true, false);
         context.AddJavascriptSource("Toastr/ToastrRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
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
            AV8Clasificaciones = (short)(Math.Round(NumberUtil.Val( cmbavClasificaciones.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV8Clasificaciones), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV8Clasificaciones", StringUtil.LTrimStr( (decimal)(AV8Clasificaciones), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         cmbavClasificaciones_Internalname = "vCLASIFICACIONES";
         edtavDesde_Internalname = "vDESDE";
         edtavHasta_Internalname = "vHASTA";
         divReporeprofesional_Internalname = "REPOREPROFESIONAL";
         Dvpanel_reporeprofesional_Internalname = "DVPANEL_REPOREPROFESIONAL";
         bttBtnenter_Internalname = "BTNENTER";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         grpUnnamedgroup2_Internalname = "UNNAMEDGROUP2";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Toastr1_Internalname = "TOASTR1";
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
         edtavHasta_Jsonclick = "";
         edtavHasta_Enabled = 1;
         edtavDesde_Jsonclick = "";
         edtavDesde_Enabled = 1;
         cmbavClasificaciones_Jsonclick = "";
         cmbavClasificaciones.Enabled = 1;
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Dvpanel_reporeprofesional_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_reporeprofesional_Iconposition = "Right";
         Dvpanel_reporeprofesional_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_reporeprofesional_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_reporeprofesional_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_reporeprofesional_Title = context.GetMessage( "Reporte de Comercios | Proveedor", "");
         Dvpanel_reporeprofesional_Cls = "PanelGrayBackgroundTitle";
         Dvpanel_reporeprofesional_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_reporeprofesional_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_reporeprofesional_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Reporte del comercio", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV11ProveedoresTipoId',fld:'vPROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV10proveedorid',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV14IncTotal',fld:'vINCTOTAL',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("ENTER","{handler:'E12C42',iparms:[{av:'AV11ProveedoresTipoId',fld:'vPROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV10proveedorid',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV5Desde',fld:'vDESDE',pic:'',type:'date'},{av:'AV6hasta',fld:'vHASTA',pic:'',type:'date'},{av:'cmbavClasificaciones'},{av:'AV8Clasificaciones',fld:'vCLASIFICACIONES',pic:'ZZZ9',type:'int'},{av:'AV14IncTotal',fld:'vINCTOTAL',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("ENTER",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'}]}");
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
         AV14IncTotal = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDvpanel_reporeprofesional = new GXUserControl();
         TempTags = "";
         AV5Desde = DateTime.MinValue;
         AV6hasta = DateTime.MinValue;
         ClassString = "";
         StyleString = "";
         bttBtnenter_Jsonclick = "";
         ucInnewwindow1 = new GXUserControl();
         ucToastr1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV20WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         H00C42_A133ProveedorID = new long[1] ;
         H00C42_A151ProveedoresTipoId = new long[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comercios.reportecom__default(),
            new Object[][] {
                new Object[] {
               H00C42_A133ProveedorID, H00C42_A151ProveedoresTipoId
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
      private short AV8Clasificaciones ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int edtavDesde_Enabled ;
      private int edtavHasta_Enabled ;
      private int idxLst ;
      private long AV11ProveedoresTipoId ;
      private long AV10proveedorid ;
      private long A133ProveedorID ;
      private long A151ProveedoresTipoId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string AV14IncTotal ;
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
      private string cmbavClasificaciones_Internalname ;
      private string TempTags ;
      private string cmbavClasificaciones_Jsonclick ;
      private string edtavDesde_Internalname ;
      private string edtavDesde_Jsonclick ;
      private string edtavHasta_Internalname ;
      private string edtavHasta_Jsonclick ;
      private string grpUnnamedgroup2_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string Innewwindow1_Internalname ;
      private string Toastr1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXEncryptionTmp ;
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
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV15DSPALmango ;
      private GXUserControl ucDvpanel_reporeprofesional ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucToastr1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavClasificaciones ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV20WWPContext ;
      private IDataStoreProvider pr_default ;
      private long[] H00C42_A133ProveedorID ;
      private long[] H00C42_A151ProveedoresTipoId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class reportecom__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00C42;
          prmH00C42 = new Object[] {
          new ParDef("@AV10proveedorid",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00C42", "SELECT [ProveedorID], [ProveedoresTipoId] FROM [Proveedor] WHERE [ProveedorID] = @AV10proveedorid ORDER BY [ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00C42,1, GxCacheFrequency.OFF ,false,true )
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
                return;
       }
    }

 }

}
