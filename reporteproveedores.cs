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
   public class reporteproveedores : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public reporteproveedores( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reporteproveedores( IGxContext context )
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
         cmbavTipoproveedor = new GXCombobox();
         cmbavProveedorid = new GXCombobox();
         cmbavClasificaciones = new GXCombobox();
         cmbavSolicitudservicioorigenpago = new GXCombobox();
         chkavInctotal = new GXCheckbox();
         chkavXls = new GXCheckbox();
         chkavDspalmango = new GXCheckbox();
         chkavGral = new GXCheckbox();
         chkavDetallado = new GXCheckbox();
         chkavExcel = new GXCheckbox();
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
         PA7V2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START7V2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("reporteproveedores.aspx") +"\">") ;
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
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vPROVEEDORESTIPOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11ProveedoresTipoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORESTIPOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11ProveedoresTipoId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTIPOPROVEEDOROLD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13TipoProveedorOld), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PROVEEDORESTIPOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A151ProveedoresTipoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PROVEEDORNOMBRE", StringUtil.RTrim( A282ProveedorNombre));
         GxWebStd.gx_hidden_field( context, "PROVEEDORESTADO", StringUtil.RTrim( A344ProveedorEstado));
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
            WE7V2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT7V2( ) ;
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
         return formatLink("reporteproveedores.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ReporteProveedores" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Reporte de Proveedores", "") ;
      }

      protected void WB7V0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavTipoproveedor_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavTipoproveedor_Internalname, context.GetMessage( "Tipo Proveedor", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavTipoproveedor, cmbavTipoproveedor_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV12TipoProveedor), 18, 0)), 1, cmbavTipoproveedor_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavTipoproveedor.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "", true, 0, "HLP_ReporteProveedores.htm");
            cmbavTipoproveedor.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV12TipoProveedor), 18, 0));
            AssignProp("", false, cmbavTipoproveedor_Internalname, "Values", (string)(cmbavTipoproveedor.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavProveedorid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavProveedorid_Internalname, context.GetMessage( "Proveedores", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavProveedorid, cmbavProveedorid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV10proveedorid), 18, 0)), 1, cmbavProveedorid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavProveedorid.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "", true, 0, "HLP_ReporteProveedores.htm");
            cmbavProveedorid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10proveedorid), 18, 0));
            AssignProp("", false, cmbavProveedorid_Internalname, "Values", (string)(cmbavProveedorid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavClasificaciones_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavClasificaciones_Internalname, context.GetMessage( "Clasificaciones", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavClasificaciones, cmbavClasificaciones_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV8Clasificaciones), 4, 0)), 1, cmbavClasificaciones_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavClasificaciones.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "", true, 0, "HLP_ReporteProveedores.htm");
            cmbavClasificaciones.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8Clasificaciones), 4, 0));
            AssignProp("", false, cmbavClasificaciones_Internalname, "Values", (string)(cmbavClasificaciones.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-2 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavDesde_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDesde_Internalname, context.GetMessage( "Desde", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavDesde_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavDesde_Internalname, context.localUtil.Format(AV5Desde, "99/99/99"), context.localUtil.Format( AV5Desde, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDesde_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavDesde_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ReporteProveedores.htm");
            GxWebStd.gx_bitmap( context, edtavDesde_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavDesde_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_ReporteProveedores.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavHasta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavHasta_Internalname, context.localUtil.Format(AV6hasta, "99/99/99"), context.localUtil.Format( AV6hasta, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavHasta_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavHasta_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ReporteProveedores.htm");
            GxWebStd.gx_bitmap( context, edtavHasta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavHasta_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_ReporteProveedores.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavSolicitudservicioorigenpago_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavSolicitudservicioorigenpago_Internalname, context.GetMessage( "Origen de Pago", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSolicitudservicioorigenpago, cmbavSolicitudservicioorigenpago_Internalname, StringUtil.RTrim( AV20SolicitudServicioOrigenPago), 1, cmbavSolicitudservicioorigenpago_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavSolicitudservicioorigenpago.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "", true, 0, "HLP_ReporteProveedores.htm");
            cmbavSolicitudservicioorigenpago.CurrentValue = StringUtil.RTrim( AV20SolicitudServicioOrigenPago);
            AssignProp("", false, cmbavSolicitudservicioorigenpago_Internalname, "Values", (string)(cmbavSolicitudservicioorigenpago.ToJavascriptSource()), true);
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
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, context.GetMessage( "Reporte del Económico", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_ReporteProveedores.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 100, "%", 0, "px", "SpacingTable", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:50fr 50fr;grid-template-rows:auto;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", context.GetMessage( "Economico", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReporteProveedores.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavInctotal_Internalname, context.GetMessage( "Calcular Totales", ""), "gx-form-item CardDescriptionLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
            ClassString = "CardDescription";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavInctotal_Internalname, AV14IncTotal, "", context.GetMessage( "Calcular Totales", ""), 1, chkavInctotal.Enabled, "S", context.GetMessage( "Calcular Totales", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(46, this, 'S', 'N',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,46);\"");
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
            GxWebStd.gx_group_start( context, grpUnnamedgroup4_Internalname, context.GetMessage( "Reporte de Comisiones Generadas", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_ReporteProveedores.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 100, "%", 0, "px", "SpacingTable", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:33fr 33fr 34fr;grid-template-rows:auto;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncomisionesgeneradas_Internalname, "", context.GetMessage( "Comisiones Generadas", ""), bttBtncomisionesgeneradas_Jsonclick, 5, context.GetMessage( "Comisiones Generadas", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOCOMISIONESGENERADAS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReporteProveedores.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblockxls_Internalname, "", "", "", lblTextblockxls_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_ReporteProveedores.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavXls_Internalname, context.GetMessage( "XLS", ""), "col-sm-3 CardDescriptionLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
            ClassString = "CardDescription";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavXls_Internalname, StringUtil.BoolToStr( AV16XLS), "", context.GetMessage( "XLS", ""), 1, chkavXls.Enabled, "true", context.GetMessage( "Exportar a Excel", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(60, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,60);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DscTop", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtabledspalmango_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockdspalmango_Internalname, "", "", "", lblTextblockdspalmango_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_ReporteProveedores.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavDspalmango_Internalname, context.GetMessage( "Visualizar Comisiones de Almango", ""), "col-sm-3 CardDescriptionLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
            ClassString = "CardDescription";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDspalmango_Internalname, StringUtil.BoolToStr( AV15DSPALmango), "", context.GetMessage( "Visualizar Comisiones de Almango", ""), 1, chkavDspalmango.Enabled, "true", context.GetMessage( "Visualizar Comisiones de Almango", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(68, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,68);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_group_start( context, grpUnnamedgroup6_Internalname, context.GetMessage( "Reporte de Obras", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_ReporteProveedores.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable5_Internalname, 1, 100, "%", 0, "px", "SpacingTable", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:33fr 33fr 34fr;grid-template-rows:auto auto;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnreporteobra_Internalname, "", context.GetMessage( "Generar Reporte", ""), bttBtnreporteobra_Jsonclick, 5, context.GetMessage( "Generar Reporte", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOREPORTEOBRA\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReporteProveedores.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DscTop", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablegral_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockgral_Internalname, "", "", "", lblTextblockgral_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_ReporteProveedores.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavGral_Internalname, context.GetMessage( "Gral", ""), "col-sm-3 CardDescriptionLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            ClassString = "CardDescription";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavGral_Internalname, StringUtil.BoolToStr( AV21Gral), "", context.GetMessage( "Gral", ""), 1, chkavGral.Enabled, "true", context.GetMessage( "Reporte Gral", ""), StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,82);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DscTop", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtabledetallado_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockdetallado_Internalname, "", "", "", lblTextblockdetallado_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_ReporteProveedores.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavDetallado_Internalname, context.GetMessage( "Detallado", ""), "col-sm-3 CardDescriptionLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
            ClassString = "CardDescription";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDetallado_Internalname, StringUtil.BoolToStr( AV22Detallado), "", context.GetMessage( "Detallado", ""), 1, chkavDetallado.Enabled, "true", context.GetMessage( "Reporte Detallado", ""), StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,90);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DscTop", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableexcel_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockexcel_Internalname, "", "", "", lblTextblockexcel_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_ReporteProveedores.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavExcel_Internalname, context.GetMessage( "Excel", ""), "col-sm-3 CardDescriptionLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
            ClassString = "CardDescription";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavExcel_Internalname, StringUtil.BoolToStr( AV24Excel), "", context.GetMessage( "Excel", ""), 1, chkavExcel.Enabled, "true", context.GetMessage( "Reporte Excel", ""), StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,98);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavSolicitudesid_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtavSolicitudesid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSolicitudesid_Internalname, context.GetMessage( "Solicitud nro", ""), "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSolicitudesid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23SolicitudesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavSolicitudesid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV23SolicitudesId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV23SolicitudesId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,102);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSolicitudesid_Jsonclick, 0, "Attribute", "", "", "", "", edtavSolicitudesid_Visible, edtavSolicitudesid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ReporteProveedores.htm");
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

      protected void START7V2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Reporte de Proveedores", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP7V0( ) ;
      }

      protected void WS7V2( )
      {
         START7V2( ) ;
         EVT7V2( ) ;
      }

      protected void EVT7V2( )
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
                              E117V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOREPORTEOBRA'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoReporteObra' */
                              E127V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCOMISIONESGENERADAS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoComisionesGeneradas' */
                              E137V2 ();
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
                                    E147V2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VTIPOPROVEEDOR.ISVALID") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E157V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E167V2 ();
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

      protected void WE7V2( )
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

      protected void PA7V2( )
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
               GX_FocusControl = cmbavTipoproveedor_Internalname;
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
         if ( cmbavTipoproveedor.ItemCount > 0 )
         {
            AV12TipoProveedor = (long)(Math.Round(NumberUtil.Val( cmbavTipoproveedor.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV12TipoProveedor), 18, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV12TipoProveedor", StringUtil.LTrimStr( (decimal)(AV12TipoProveedor), 18, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavTipoproveedor.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV12TipoProveedor), 18, 0));
            AssignProp("", false, cmbavTipoproveedor_Internalname, "Values", cmbavTipoproveedor.ToJavascriptSource(), true);
         }
         if ( cmbavProveedorid.ItemCount > 0 )
         {
            AV10proveedorid = (long)(Math.Round(NumberUtil.Val( cmbavProveedorid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV10proveedorid), 18, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV10proveedorid", StringUtil.LTrimStr( (decimal)(AV10proveedorid), 18, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavProveedorid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10proveedorid), 18, 0));
            AssignProp("", false, cmbavProveedorid_Internalname, "Values", cmbavProveedorid.ToJavascriptSource(), true);
         }
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
         if ( cmbavSolicitudservicioorigenpago.ItemCount > 0 )
         {
            AV20SolicitudServicioOrigenPago = cmbavSolicitudservicioorigenpago.getValidValue(AV20SolicitudServicioOrigenPago);
            AssignAttri("", false, "AV20SolicitudServicioOrigenPago", AV20SolicitudServicioOrigenPago);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSolicitudservicioorigenpago.CurrentValue = StringUtil.RTrim( AV20SolicitudServicioOrigenPago);
            AssignProp("", false, cmbavSolicitudservicioorigenpago_Internalname, "Values", cmbavSolicitudservicioorigenpago.ToJavascriptSource(), true);
         }
         AV14IncTotal = ((StringUtil.StrCmp(StringUtil.RTrim( AV14IncTotal), "S")==0) ? "S" : "N");
         AssignAttri("", false, "AV14IncTotal", AV14IncTotal);
         AV16XLS = StringUtil.StrToBool( StringUtil.BoolToStr( AV16XLS));
         AssignAttri("", false, "AV16XLS", AV16XLS);
         AV15DSPALmango = StringUtil.StrToBool( StringUtil.BoolToStr( AV15DSPALmango));
         AssignAttri("", false, "AV15DSPALmango", AV15DSPALmango);
         AV21Gral = StringUtil.StrToBool( StringUtil.BoolToStr( AV21Gral));
         AssignAttri("", false, "AV21Gral", AV21Gral);
         AV22Detallado = StringUtil.StrToBool( StringUtil.BoolToStr( AV22Detallado));
         AssignAttri("", false, "AV22Detallado", AV22Detallado);
         AV24Excel = StringUtil.StrToBool( StringUtil.BoolToStr( AV24Excel));
         AssignAttri("", false, "AV24Excel", AV24Excel);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF7V2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF7V2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E167V2 ();
            WB7V0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes7V2( )
      {
         GxWebStd.gx_hidden_field( context, "vPROVEEDORESTIPOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11ProveedoresTipoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORESTIPOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11ProveedoresTipoId), "ZZZZZZZZZZZZZZZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7V0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E117V2 ();
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
            Innewwindow1_Target = cgiGet( "INNEWWINDOW1_Target");
            /* Read variables values. */
            cmbavTipoproveedor.CurrentValue = cgiGet( cmbavTipoproveedor_Internalname);
            AV12TipoProveedor = (long)(Math.Round(NumberUtil.Val( cgiGet( cmbavTipoproveedor_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV12TipoProveedor", StringUtil.LTrimStr( (decimal)(AV12TipoProveedor), 18, 0));
            cmbavProveedorid.CurrentValue = cgiGet( cmbavProveedorid_Internalname);
            AV10proveedorid = (long)(Math.Round(NumberUtil.Val( cgiGet( cmbavProveedorid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV10proveedorid", StringUtil.LTrimStr( (decimal)(AV10proveedorid), 18, 0));
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
            cmbavSolicitudservicioorigenpago.CurrentValue = cgiGet( cmbavSolicitudservicioorigenpago_Internalname);
            AV20SolicitudServicioOrigenPago = cgiGet( cmbavSolicitudservicioorigenpago_Internalname);
            AssignAttri("", false, "AV20SolicitudServicioOrigenPago", AV20SolicitudServicioOrigenPago);
            AV14IncTotal = ((StringUtil.StrCmp(cgiGet( chkavInctotal_Internalname), "S")==0) ? "S" : "N");
            AssignAttri("", false, "AV14IncTotal", AV14IncTotal);
            AV16XLS = StringUtil.StrToBool( cgiGet( chkavXls_Internalname));
            AssignAttri("", false, "AV16XLS", AV16XLS);
            AV15DSPALmango = StringUtil.StrToBool( cgiGet( chkavDspalmango_Internalname));
            AssignAttri("", false, "AV15DSPALmango", AV15DSPALmango);
            AV21Gral = StringUtil.StrToBool( cgiGet( chkavGral_Internalname));
            AssignAttri("", false, "AV21Gral", AV21Gral);
            AV22Detallado = StringUtil.StrToBool( cgiGet( chkavDetallado_Internalname));
            AssignAttri("", false, "AV22Detallado", AV22Detallado);
            AV24Excel = StringUtil.StrToBool( cgiGet( chkavExcel_Internalname));
            AssignAttri("", false, "AV24Excel", AV24Excel);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSolicitudesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSolicitudesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSOLICITUDESID");
               GX_FocusControl = edtavSolicitudesid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV23SolicitudesId = 0;
               AssignAttri("", false, "AV23SolicitudesId", StringUtil.LTrimStr( (decimal)(AV23SolicitudesId), 18, 0));
            }
            else
            {
               AV23SolicitudesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavSolicitudesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV23SolicitudesId", StringUtil.LTrimStr( (decimal)(AV23SolicitudesId), 18, 0));
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
         E117V2 ();
         if (returnInSub) return;
      }

      protected void E117V2( )
      {
         /* Start Routine */
         returnInSub = false;
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
         cmbavProveedorid.removeAllItems();
         cmbavProveedorid.addItem("0", context.GetMessage( "Seleccione un Proveedor", ""), 0);
         AV15DSPALmango = false;
         AssignAttri("", false, "AV15DSPALmango", AV15DSPALmango);
         AV20SolicitudServicioOrigenPago = "";
         AssignAttri("", false, "AV20SolicitudServicioOrigenPago", AV20SolicitudServicioOrigenPago);
         edtavSolicitudesid_Visible = 0;
         AssignProp("", false, edtavSolicitudesid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSolicitudesid_Visible), 5, 0), true);
      }

      protected void E127V2( )
      {
         /* 'DoReporteObra' Routine */
         returnInSub = false;
         if ( AV21Gral )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "areporteobras.aspx"+UrlEncode(StringUtil.LTrimStr(AV12TipoProveedor,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV10proveedorid,18,0)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV5Desde)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV6hasta)) + "," + UrlEncode(StringUtil.LTrimStr(AV8Clasificaciones,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV20SolicitudServicioOrigenPago)) + "," + UrlEncode(StringUtil.BoolToStr(AV21Gral)) + "," + UrlEncode(StringUtil.LTrimStr(AV23SolicitudesId,18,0));
            Innewwindow1_Target = formatLink("areporteobras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
            this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
         }
         else
         {
            if ( AV22Detallado )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "areporteobrasdetallado.aspx"+UrlEncode(StringUtil.LTrimStr(AV12TipoProveedor,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV10proveedorid,18,0)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV5Desde)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV6hasta)) + "," + UrlEncode(StringUtil.LTrimStr(AV8Clasificaciones,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV20SolicitudServicioOrigenPago)) + "," + UrlEncode(StringUtil.BoolToStr(AV21Gral)) + "," + UrlEncode(StringUtil.LTrimStr(AV23SolicitudesId,18,0));
               Innewwindow1_Target = formatLink("areporteobrasdetallado.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
               ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
               this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
            }
            else
            {
               if ( AV24Excel )
               {
                  new reporteobrasdetalladoxls(context ).execute(  AV11ProveedoresTipoId,  AV10proveedorid,  AV5Desde,  AV6hasta,  AV8Clasificaciones,  AV20SolicitudServicioOrigenPago,  AV15DSPALmango,  AV23SolicitudesId) ;
               }
               else
               {
                  GX_msglist.addItem(context.GetMessage( "Seleccione un Informe", ""));
               }
            }
         }
         /*  Sending Event outputs  */
      }

      protected void E137V2( )
      {
         /* 'DoComisionesGeneradas' Routine */
         returnInSub = false;
         if ( ( AV12TipoProveedor > 0 ) && ( AV10proveedorid > 0 ) )
         {
            if ( AV16XLS )
            {
               new reportecomisionesprovxls(context ).execute(  AV11ProveedoresTipoId,  AV10proveedorid,  AV5Desde,  AV6hasta,  AV8Clasificaciones,  AV20SolicitudServicioOrigenPago,  AV15DSPALmango) ;
            }
            else
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "areportecomisionesprov.aspx"+UrlEncode(StringUtil.LTrimStr(AV12TipoProveedor,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV10proveedorid,18,0)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV5Desde)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV6hasta)) + "," + UrlEncode(StringUtil.LTrimStr(AV8Clasificaciones,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV20SolicitudServicioOrigenPago)) + "," + UrlEncode(StringUtil.BoolToStr(AV15DSPALmango));
               Innewwindow1_Target = formatLink("areportecomisionesprov.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
               ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
               this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
            }
         }
         else
         {
            AV9Titulo = context.GetMessage( "Error: ", "");
            this.executeUsercontrolMethod("", false, "TOASTR1Container", "Msg", "", new Object[] {(string)"success",context.GetMessage( "Debe seleccionar un proveedor.", ""),(string)AV9Titulo});
         }
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E147V2 ();
         if (returnInSub) return;
      }

      protected void E147V2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( ( AV12TipoProveedor > 0 ) && ( AV10proveedorid > 0 ) )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "areporteeconomicoprov.aspx"+UrlEncode(StringUtil.LTrimStr(AV12TipoProveedor,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV10proveedorid,18,0)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV5Desde)) + "," + UrlEncode(DateTimeUtil.FormatDateParm(AV6hasta)) + "," + UrlEncode(StringUtil.LTrimStr(AV8Clasificaciones,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV14IncTotal)) + "," + UrlEncode(StringUtil.RTrim(AV20SolicitudServicioOrigenPago));
            Innewwindow1_Target = formatLink("areporteeconomicoprov.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
            this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
         }
         else
         {
            AV9Titulo = context.GetMessage( "Error: ", "");
            this.executeUsercontrolMethod("", false, "TOASTR1Container", "Msg", "", new Object[] {(string)"success",context.GetMessage( "Debe seleccionar un proveedor.", ""),(string)AV9Titulo});
         }
         /*  Sending Event outputs  */
      }

      protected void E157V2( )
      {
         /* Tipoproveedor_Isvalid Routine */
         returnInSub = false;
         if ( AV12TipoProveedor != AV13TipoProveedorOld )
         {
            AV13TipoProveedorOld = AV12TipoProveedor;
            AssignAttri("", false, "AV13TipoProveedorOld", StringUtil.LTrimStr( (decimal)(AV13TipoProveedorOld), 18, 0));
            cmbavProveedorid.removeAllItems();
            cmbavProveedorid.addItem("0", context.GetMessage( "Seleccione un Proveedor", ""), 0);
            /* Using cursor H007V2 */
            pr_default.execute(0, new Object[] {AV12TipoProveedor});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A344ProveedorEstado = H007V2_A344ProveedorEstado[0];
               A151ProveedoresTipoId = H007V2_A151ProveedoresTipoId[0];
               A133ProveedorID = H007V2_A133ProveedorID[0];
               A282ProveedorNombre = H007V2_A282ProveedorNombre[0];
               if ( StringUtil.StrCmp(A344ProveedorEstado, context.GetMessage( "HAB", "")) == 0 )
               {
                  GXt_boolean1 = AV19Cargar;
                  new oproveedorlistaasig(context ).execute(  A133ProveedorID, out  GXt_boolean1) ;
                  AV19Cargar = GXt_boolean1;
                  if ( AV19Cargar )
                  {
                     cmbavProveedorid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0)), A282ProveedorNombre, 0);
                  }
                  else
                  {
                     cmbavProveedorid.removeItem(StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
                  }
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         /*  Sending Event outputs  */
         cmbavProveedorid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10proveedorid), 18, 0));
         AssignProp("", false, cmbavProveedorid_Internalname, "Values", cmbavProveedorid.ToJavascriptSource(), true);
      }

      protected void S112( )
      {
         /* 'OBTENER TIPO PROVEEDOR' Routine */
         returnInSub = false;
         cmbavTipoproveedor.removeAllItems();
         cmbavTipoproveedor.addItem("0", context.GetMessage( "Seleccione un Tipo de Proveedor", ""), 0);
         /* Using cursor H007V3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A278ProveedoresTipoNombre = H007V3_A278ProveedoresTipoNombre[0];
            A151ProveedoresTipoId = H007V3_A151ProveedoresTipoId[0];
            cmbavTipoproveedor.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(A151ProveedoresTipoId), 18, 0)), A278ProveedoresTipoNombre, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void nextLoad( )
      {
      }

      protected void E167V2( )
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
         PA7V2( ) ;
         WS7V2( ) ;
         WE7V2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269320154167", true, true, false);
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
         context.AddJavascriptSource("reporteproveedores.js", "?20269320154167", false, true, false);
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
         cmbavTipoproveedor.Name = "vTIPOPROVEEDOR";
         cmbavTipoproveedor.WebTags = "";
         if ( cmbavTipoproveedor.ItemCount > 0 )
         {
            AV12TipoProveedor = (long)(Math.Round(NumberUtil.Val( cmbavTipoproveedor.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV12TipoProveedor), 18, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV12TipoProveedor", StringUtil.LTrimStr( (decimal)(AV12TipoProveedor), 18, 0));
         }
         cmbavProveedorid.Name = "vPROVEEDORID";
         cmbavProveedorid.WebTags = "";
         if ( cmbavProveedorid.ItemCount > 0 )
         {
            AV10proveedorid = (long)(Math.Round(NumberUtil.Val( cmbavProveedorid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV10proveedorid), 18, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV10proveedorid", StringUtil.LTrimStr( (decimal)(AV10proveedorid), 18, 0));
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
            AV8Clasificaciones = (short)(Math.Round(NumberUtil.Val( cmbavClasificaciones.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV8Clasificaciones), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV8Clasificaciones", StringUtil.LTrimStr( (decimal)(AV8Clasificaciones), 4, 0));
         }
         cmbavSolicitudservicioorigenpago.Name = "vSOLICITUDSERVICIOORIGENPAGO";
         cmbavSolicitudservicioorigenpago.WebTags = "";
         cmbavSolicitudservicioorigenpago.addItem("", context.GetMessage( "Todos", ""), 0);
         cmbavSolicitudservicioorigenpago.addItem("F", context.GetMessage( "Cobro Directo", ""), 0);
         cmbavSolicitudservicioorigenpago.addItem("T", context.GetMessage( "Cobro Prepago Comercio", ""), 0);
         cmbavSolicitudservicioorigenpago.addItem("O", context.GetMessage( "Cobro Prepago Almango", ""), 0);
         if ( cmbavSolicitudservicioorigenpago.ItemCount > 0 )
         {
            AV20SolicitudServicioOrigenPago = cmbavSolicitudservicioorigenpago.getValidValue(AV20SolicitudServicioOrigenPago);
            AssignAttri("", false, "AV20SolicitudServicioOrigenPago", AV20SolicitudServicioOrigenPago);
         }
         chkavInctotal.Name = "vINCTOTAL";
         chkavInctotal.WebTags = "";
         chkavInctotal.Caption = context.GetMessage( "Calcular Totales", "");
         AssignProp("", false, chkavInctotal_Internalname, "TitleCaption", chkavInctotal.Caption, true);
         chkavInctotal.CheckedValue = "N";
         AV14IncTotal = ((StringUtil.StrCmp(StringUtil.RTrim( AV14IncTotal), "S")==0) ? "S" : "N");
         AssignAttri("", false, "AV14IncTotal", AV14IncTotal);
         chkavXls.Name = "vXLS";
         chkavXls.WebTags = "";
         chkavXls.Caption = context.GetMessage( "XLS", "");
         AssignProp("", false, chkavXls_Internalname, "TitleCaption", chkavXls.Caption, true);
         chkavXls.CheckedValue = "false";
         AV16XLS = StringUtil.StrToBool( StringUtil.BoolToStr( AV16XLS));
         AssignAttri("", false, "AV16XLS", AV16XLS);
         chkavDspalmango.Name = "vDSPALMANGO";
         chkavDspalmango.WebTags = "";
         chkavDspalmango.Caption = context.GetMessage( "Visualizar Comisiones de Almango", "");
         AssignProp("", false, chkavDspalmango_Internalname, "TitleCaption", chkavDspalmango.Caption, true);
         chkavDspalmango.CheckedValue = "false";
         AV15DSPALmango = StringUtil.StrToBool( StringUtil.BoolToStr( AV15DSPALmango));
         AssignAttri("", false, "AV15DSPALmango", AV15DSPALmango);
         chkavGral.Name = "vGRAL";
         chkavGral.WebTags = "";
         chkavGral.Caption = context.GetMessage( "Gral", "");
         AssignProp("", false, chkavGral_Internalname, "TitleCaption", chkavGral.Caption, true);
         chkavGral.CheckedValue = "false";
         AV21Gral = StringUtil.StrToBool( StringUtil.BoolToStr( AV21Gral));
         AssignAttri("", false, "AV21Gral", AV21Gral);
         chkavDetallado.Name = "vDETALLADO";
         chkavDetallado.WebTags = "";
         chkavDetallado.Caption = context.GetMessage( "Detallado", "");
         AssignProp("", false, chkavDetallado_Internalname, "TitleCaption", chkavDetallado.Caption, true);
         chkavDetallado.CheckedValue = "false";
         AV22Detallado = StringUtil.StrToBool( StringUtil.BoolToStr( AV22Detallado));
         AssignAttri("", false, "AV22Detallado", AV22Detallado);
         chkavExcel.Name = "vEXCEL";
         chkavExcel.WebTags = "";
         chkavExcel.Caption = context.GetMessage( "Excel", "");
         AssignProp("", false, chkavExcel_Internalname, "TitleCaption", chkavExcel.Caption, true);
         chkavExcel.CheckedValue = "false";
         AV24Excel = StringUtil.StrToBool( StringUtil.BoolToStr( AV24Excel));
         AssignAttri("", false, "AV24Excel", AV24Excel);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         cmbavTipoproveedor_Internalname = "vTIPOPROVEEDOR";
         cmbavProveedorid_Internalname = "vPROVEEDORID";
         cmbavClasificaciones_Internalname = "vCLASIFICACIONES";
         edtavDesde_Internalname = "vDESDE";
         edtavHasta_Internalname = "vHASTA";
         cmbavSolicitudservicioorigenpago_Internalname = "vSOLICITUDSERVICIOORIGENPAGO";
         divReporeprofesional_Internalname = "REPOREPROFESIONAL";
         Dvpanel_reporeprofesional_Internalname = "DVPANEL_REPOREPROFESIONAL";
         bttBtnenter_Internalname = "BTNENTER";
         chkavInctotal_Internalname = "vINCTOTAL";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         grpUnnamedgroup2_Internalname = "UNNAMEDGROUP2";
         bttBtncomisionesgeneradas_Internalname = "BTNCOMISIONESGENERADAS";
         lblTextblockxls_Internalname = "TEXTBLOCKXLS";
         chkavXls_Internalname = "vXLS";
         divUnnamedtablexls_Internalname = "UNNAMEDTABLEXLS";
         lblTextblockdspalmango_Internalname = "TEXTBLOCKDSPALMANGO";
         chkavDspalmango_Internalname = "vDSPALMANGO";
         divUnnamedtabledspalmango_Internalname = "UNNAMEDTABLEDSPALMANGO";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         grpUnnamedgroup4_Internalname = "UNNAMEDGROUP4";
         bttBtnreporteobra_Internalname = "BTNREPORTEOBRA";
         lblTextblockgral_Internalname = "TEXTBLOCKGRAL";
         chkavGral_Internalname = "vGRAL";
         divUnnamedtablegral_Internalname = "UNNAMEDTABLEGRAL";
         lblTextblockdetallado_Internalname = "TEXTBLOCKDETALLADO";
         chkavDetallado_Internalname = "vDETALLADO";
         divUnnamedtabledetallado_Internalname = "UNNAMEDTABLEDETALLADO";
         lblTextblockexcel_Internalname = "TEXTBLOCKEXCEL";
         chkavExcel_Internalname = "vEXCEL";
         divUnnamedtableexcel_Internalname = "UNNAMEDTABLEEXCEL";
         edtavSolicitudesid_Internalname = "vSOLICITUDESID";
         divUnnamedtable5_Internalname = "UNNAMEDTABLE5";
         grpUnnamedgroup6_Internalname = "UNNAMEDGROUP6";
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
         chkavExcel.Caption = context.GetMessage( "Excel", "");
         chkavDetallado.Caption = context.GetMessage( "Detallado", "");
         chkavGral.Caption = context.GetMessage( "Gral", "");
         chkavDspalmango.Caption = context.GetMessage( "Visualizar Comisiones de Almango", "");
         chkavXls.Caption = context.GetMessage( "XLS", "");
         chkavInctotal.Caption = context.GetMessage( "Calcular Totales", "");
         edtavSolicitudesid_Jsonclick = "";
         edtavSolicitudesid_Enabled = 1;
         edtavSolicitudesid_Visible = 1;
         chkavExcel.Enabled = 1;
         chkavDetallado.Enabled = 1;
         chkavGral.Enabled = 1;
         chkavDspalmango.Enabled = 1;
         chkavXls.Enabled = 1;
         chkavInctotal.Enabled = 1;
         cmbavSolicitudservicioorigenpago_Jsonclick = "";
         cmbavSolicitudservicioorigenpago.Enabled = 1;
         edtavHasta_Jsonclick = "";
         edtavHasta_Enabled = 1;
         edtavDesde_Jsonclick = "";
         edtavDesde_Enabled = 1;
         cmbavClasificaciones_Jsonclick = "";
         cmbavClasificaciones.Enabled = 1;
         cmbavProveedorid_Jsonclick = "";
         cmbavProveedorid.Enabled = 1;
         cmbavTipoproveedor_Jsonclick = "";
         cmbavTipoproveedor.Enabled = 1;
         Innewwindow1_Target = "";
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
         Form.Caption = context.GetMessage( "Reporte de Proveedores", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV14IncTotal',fld:'vINCTOTAL',pic:'',type:'char'},{av:'AV16XLS',fld:'vXLS',pic:'',type:'boolean'},{av:'AV15DSPALmango',fld:'vDSPALMANGO',pic:'',type:'boolean'},{av:'AV21Gral',fld:'vGRAL',pic:'',type:'boolean'},{av:'AV22Detallado',fld:'vDETALLADO',pic:'',type:'boolean'},{av:'AV24Excel',fld:'vEXCEL',pic:'',type:'boolean'},{av:'AV11ProveedoresTipoId',fld:'vPROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOREPORTEOBRA'","{handler:'E127V2',iparms:[{av:'AV21Gral',fld:'vGRAL',pic:'',type:'boolean'},{av:'cmbavTipoproveedor'},{av:'AV12TipoProveedor',fld:'vTIPOPROVEEDOR',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'cmbavProveedorid'},{av:'AV10proveedorid',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV5Desde',fld:'vDESDE',pic:'',type:'date'},{av:'AV6hasta',fld:'vHASTA',pic:'',type:'date'},{av:'cmbavClasificaciones'},{av:'AV8Clasificaciones',fld:'vCLASIFICACIONES',pic:'ZZZ9',type:'int'},{av:'cmbavSolicitudservicioorigenpago'},{av:'AV20SolicitudServicioOrigenPago',fld:'vSOLICITUDSERVICIOORIGENPAGO',pic:'',type:'char'},{av:'AV23SolicitudesId',fld:'vSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22Detallado',fld:'vDETALLADO',pic:'',type:'boolean'},{av:'AV24Excel',fld:'vEXCEL',pic:'',type:'boolean'},{av:'AV11ProveedoresTipoId',fld:'vPROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV15DSPALmango',fld:'vDSPALMANGO',pic:'',type:'boolean'}]");
         setEventMetadata("'DOREPORTEOBRA'",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'}]}");
         setEventMetadata("'DOCOMISIONESGENERADAS'","{handler:'E137V2',iparms:[{av:'cmbavTipoproveedor'},{av:'AV12TipoProveedor',fld:'vTIPOPROVEEDOR',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'cmbavProveedorid'},{av:'AV10proveedorid',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV16XLS',fld:'vXLS',pic:'',type:'boolean'},{av:'AV11ProveedoresTipoId',fld:'vPROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV5Desde',fld:'vDESDE',pic:'',type:'date'},{av:'AV6hasta',fld:'vHASTA',pic:'',type:'date'},{av:'cmbavClasificaciones'},{av:'AV8Clasificaciones',fld:'vCLASIFICACIONES',pic:'ZZZ9',type:'int'},{av:'cmbavSolicitudservicioorigenpago'},{av:'AV20SolicitudServicioOrigenPago',fld:'vSOLICITUDSERVICIOORIGENPAGO',pic:'',type:'char'},{av:'AV15DSPALmango',fld:'vDSPALMANGO',pic:'',type:'boolean'}]");
         setEventMetadata("'DOCOMISIONESGENERADAS'",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'}]}");
         setEventMetadata("ENTER","{handler:'E147V2',iparms:[{av:'cmbavTipoproveedor'},{av:'AV12TipoProveedor',fld:'vTIPOPROVEEDOR',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'cmbavProveedorid'},{av:'AV10proveedorid',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV5Desde',fld:'vDESDE',pic:'',type:'date'},{av:'AV6hasta',fld:'vHASTA',pic:'',type:'date'},{av:'cmbavClasificaciones'},{av:'AV8Clasificaciones',fld:'vCLASIFICACIONES',pic:'ZZZ9',type:'int'},{av:'AV14IncTotal',fld:'vINCTOTAL',pic:'',type:'char'},{av:'cmbavSolicitudservicioorigenpago'},{av:'AV20SolicitudServicioOrigenPago',fld:'vSOLICITUDSERVICIOORIGENPAGO',pic:'',type:'char'}]");
         setEventMetadata("ENTER",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'}]}");
         setEventMetadata("VTIPOPROVEEDOR.ISVALID","{handler:'E157V2',iparms:[{av:'cmbavTipoproveedor'},{av:'AV12TipoProveedor',fld:'vTIPOPROVEEDOR',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV13TipoProveedorOld',fld:'vTIPOPROVEEDOROLD',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A344ProveedorEstado',fld:'PROVEEDORESTADO',pic:'',type:'char'},{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A282ProveedorNombre',fld:'PROVEEDORNOMBRE',pic:'',type:'char'}]");
         setEventMetadata("VTIPOPROVEEDOR.ISVALID",",oparms:[{av:'AV13TipoProveedorOld',fld:'vTIPOPROVEEDOROLD',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'cmbavProveedorid'},{av:'AV10proveedorid',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALIDV_TIPOPROVEEDOR","{handler:'Validv_Tipoproveedor',iparms:[]");
         setEventMetadata("VALIDV_TIPOPROVEEDOR",",oparms:[]}");
         setEventMetadata("VALIDV_DESDE","{handler:'Validv_Desde',iparms:[]");
         setEventMetadata("VALIDV_DESDE",",oparms:[]}");
         setEventMetadata("VALIDV_HASTA","{handler:'Validv_Hasta',iparms:[]");
         setEventMetadata("VALIDV_HASTA",",oparms:[]}");
         setEventMetadata("VALIDV_SOLICITUDSERVICIOORIGENPAGO","{handler:'Validv_Solicitudservicioorigenpago',iparms:[]");
         setEventMetadata("VALIDV_SOLICITUDSERVICIOORIGENPAGO",",oparms:[]}");
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
         A282ProveedorNombre = "";
         A344ProveedorEstado = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDvpanel_reporeprofesional = new GXUserControl();
         TempTags = "";
         AV5Desde = DateTime.MinValue;
         AV6hasta = DateTime.MinValue;
         AV20SolicitudServicioOrigenPago = "";
         ClassString = "";
         StyleString = "";
         bttBtnenter_Jsonclick = "";
         AV14IncTotal = "";
         bttBtncomisionesgeneradas_Jsonclick = "";
         lblTextblockxls_Jsonclick = "";
         lblTextblockdspalmango_Jsonclick = "";
         bttBtnreporteobra_Jsonclick = "";
         lblTextblockgral_Jsonclick = "";
         lblTextblockdetallado_Jsonclick = "";
         lblTextblockexcel_Jsonclick = "";
         ucInnewwindow1 = new GXUserControl();
         ucToastr1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXEncryptionTmp = "";
         AV9Titulo = "";
         H007V2_A344ProveedorEstado = new string[] {""} ;
         H007V2_A151ProveedoresTipoId = new long[1] ;
         H007V2_A133ProveedorID = new long[1] ;
         H007V2_A282ProveedorNombre = new string[] {""} ;
         H007V3_A278ProveedoresTipoNombre = new string[] {""} ;
         H007V3_A151ProveedoresTipoId = new long[1] ;
         A278ProveedoresTipoNombre = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reporteproveedores__default(),
            new Object[][] {
                new Object[] {
               H007V2_A344ProveedorEstado, H007V2_A151ProveedoresTipoId, H007V2_A133ProveedorID, H007V2_A282ProveedorNombre
               }
               , new Object[] {
               H007V3_A278ProveedoresTipoNombre, H007V3_A151ProveedoresTipoId
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
      private short AV8Clasificaciones ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int edtavDesde_Enabled ;
      private int edtavHasta_Enabled ;
      private int edtavSolicitudesid_Visible ;
      private int edtavSolicitudesid_Enabled ;
      private int idxLst ;
      private long AV11ProveedoresTipoId ;
      private long AV13TipoProveedorOld ;
      private long A151ProveedoresTipoId ;
      private long A133ProveedorID ;
      private long AV12TipoProveedor ;
      private long AV10proveedorid ;
      private long AV23SolicitudesId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string A282ProveedorNombre ;
      private string A344ProveedorEstado ;
      private string Dvpanel_reporeprofesional_Width ;
      private string Dvpanel_reporeprofesional_Cls ;
      private string Dvpanel_reporeprofesional_Title ;
      private string Dvpanel_reporeprofesional_Iconposition ;
      private string Innewwindow1_Target ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divMaintable_Internalname ;
      private string Dvpanel_reporeprofesional_Internalname ;
      private string divReporeprofesional_Internalname ;
      private string cmbavTipoproveedor_Internalname ;
      private string TempTags ;
      private string cmbavTipoproveedor_Jsonclick ;
      private string cmbavProveedorid_Internalname ;
      private string cmbavProveedorid_Jsonclick ;
      private string cmbavClasificaciones_Internalname ;
      private string cmbavClasificaciones_Jsonclick ;
      private string edtavDesde_Internalname ;
      private string edtavDesde_Jsonclick ;
      private string edtavHasta_Internalname ;
      private string edtavHasta_Jsonclick ;
      private string cmbavSolicitudservicioorigenpago_Internalname ;
      private string AV20SolicitudServicioOrigenPago ;
      private string cmbavSolicitudservicioorigenpago_Jsonclick ;
      private string grpUnnamedgroup2_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string chkavInctotal_Internalname ;
      private string AV14IncTotal ;
      private string grpUnnamedgroup4_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string bttBtncomisionesgeneradas_Internalname ;
      private string bttBtncomisionesgeneradas_Jsonclick ;
      private string divUnnamedtablexls_Internalname ;
      private string lblTextblockxls_Internalname ;
      private string lblTextblockxls_Jsonclick ;
      private string chkavXls_Internalname ;
      private string divUnnamedtabledspalmango_Internalname ;
      private string lblTextblockdspalmango_Internalname ;
      private string lblTextblockdspalmango_Jsonclick ;
      private string chkavDspalmango_Internalname ;
      private string grpUnnamedgroup6_Internalname ;
      private string divUnnamedtable5_Internalname ;
      private string bttBtnreporteobra_Internalname ;
      private string bttBtnreporteobra_Jsonclick ;
      private string divUnnamedtablegral_Internalname ;
      private string lblTextblockgral_Internalname ;
      private string lblTextblockgral_Jsonclick ;
      private string chkavGral_Internalname ;
      private string divUnnamedtabledetallado_Internalname ;
      private string lblTextblockdetallado_Internalname ;
      private string lblTextblockdetallado_Jsonclick ;
      private string chkavDetallado_Internalname ;
      private string divUnnamedtableexcel_Internalname ;
      private string lblTextblockexcel_Internalname ;
      private string lblTextblockexcel_Jsonclick ;
      private string chkavExcel_Internalname ;
      private string edtavSolicitudesid_Internalname ;
      private string edtavSolicitudesid_Jsonclick ;
      private string Innewwindow1_Internalname ;
      private string Toastr1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXEncryptionTmp ;
      private string AV9Titulo ;
      private string A278ProveedoresTipoNombre ;
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
      private bool AV16XLS ;
      private bool AV15DSPALmango ;
      private bool AV21Gral ;
      private bool AV22Detallado ;
      private bool AV24Excel ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV19Cargar ;
      private bool GXt_boolean1 ;
      private GXUserControl ucDvpanel_reporeprofesional ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucToastr1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavTipoproveedor ;
      private GXCombobox cmbavProveedorid ;
      private GXCombobox cmbavClasificaciones ;
      private GXCombobox cmbavSolicitudservicioorigenpago ;
      private GXCheckbox chkavInctotal ;
      private GXCheckbox chkavXls ;
      private GXCheckbox chkavDspalmango ;
      private GXCheckbox chkavGral ;
      private GXCheckbox chkavDetallado ;
      private GXCheckbox chkavExcel ;
      private IDataStoreProvider pr_default ;
      private string[] H007V2_A344ProveedorEstado ;
      private long[] H007V2_A151ProveedoresTipoId ;
      private long[] H007V2_A133ProveedorID ;
      private string[] H007V2_A282ProveedorNombre ;
      private string[] H007V3_A278ProveedoresTipoNombre ;
      private long[] H007V3_A151ProveedoresTipoId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class reporteproveedores__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH007V2;
          prmH007V2 = new Object[] {
          new ParDef("@AV12TipoProveedor",GXType.Decimal,18,0)
          };
          Object[] prmH007V3;
          prmH007V3 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H007V2", "SELECT [ProveedorEstado], [ProveedoresTipoId], [ProveedorID], [ProveedorNombre] FROM [Proveedor] WHERE [ProveedoresTipoId] = @AV12TipoProveedor ORDER BY [ProveedoresTipoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007V2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007V3", "SELECT [ProveedoresTipoNombre], [ProveedoresTipoId] FROM [ProveedoresTipo] ORDER BY [ProveedoresTipoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007V3,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 80);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 120);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
