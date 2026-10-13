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
   public class calcularcomisionwp : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public calcularcomisionwp( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public calcularcomisionwp( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesID ,
                           bool aP1_CambioPrecio )
      {
         this.AV7SolicitudesID = aP0_SolicitudesID;
         this.AV26CambioPrecio = aP1_CambioPrecio;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavSolicitudescalcomi = new GXCheckbox();
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
         PAB72( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTB72( ) ;
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "calcularcomisionwp.aspx"+UrlEncode(StringUtil.LTrimStr(AV7SolicitudesID,18,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV26CambioPrecio));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("calcularcomisionwp.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPROFESIONALESID", StringUtil.RTrim( AV18ProFesionalesID));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROFESIONALESID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18ProFesionalesID, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDSERVICIOPFINAL", GetSecureSignedToken( "", context.localUtil.Format( AV17SolicitudServicioPFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vCAMBIOPRECIO", AV26CambioPrecio);
         GxWebStd.gx_hidden_field( context, "gxhash_vCAMBIOPRECIO", GetSecureSignedToken( "", AV26CambioPrecio, context));
         GXKey = Crypto.GetSiteKey( );
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"CalcularComisionWP");
         forbiddenHiddens.Add("SolicitudServicioPFinal", context.localUtil.Format( AV17SolicitudServicioPFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("calcularcomisionwp:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vPROFESIONALESID", StringUtil.RTrim( AV18ProFesionalesID));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROFESIONALESID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18ProFesionalesID, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSOLICITUDES", AV16Solicitudes);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSOLICITUDES", AV16Solicitudes);
         }
         GxWebStd.gx_hidden_field( context, "vOLDSOLICITUDSERVICIOCOMPROV", StringUtil.LTrim( StringUtil.NToC( AV21OldSolicitudServicioComProv, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vOLDSOLICITUDSERVICIOCOMPROVP", StringUtil.LTrim( StringUtil.NToC( AV22OldSolicitudServicioComProvP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vOLDSOLICITUDSERVICIOCOMALMP", StringUtil.LTrim( StringUtil.NToC( AV24OldSolicitudServicioComALMP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vOLDSOLICITUDSERVICIOCOMALM", StringUtil.LTrim( StringUtil.NToC( AV23OldSolicitudServicioComALM, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vOLDSOLICITUDSERVICIOXZCOMALMP", StringUtil.LTrim( StringUtil.NToC( AV45Oldsolicitudservicioxzcomalmp, 6, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vOLDSOLICITUDSERVICIOXZCOMALM", StringUtil.LTrim( StringUtil.NToC( AV38OldSolicitudServicioXZComAlm, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vCAMBIOPRECIO", AV26CambioPrecio);
         GxWebStd.gx_hidden_field( context, "gxhash_vCAMBIOPRECIO", GetSecureSignedToken( "", AV26CambioPrecio, context));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CALCOM_Width", StringUtil.RTrim( Dvpanel_calcom_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CALCOM_Autowidth", StringUtil.BoolToStr( Dvpanel_calcom_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CALCOM_Autoheight", StringUtil.BoolToStr( Dvpanel_calcom_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CALCOM_Cls", StringUtil.RTrim( Dvpanel_calcom_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CALCOM_Title", StringUtil.RTrim( Dvpanel_calcom_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CALCOM_Collapsible", StringUtil.BoolToStr( Dvpanel_calcom_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CALCOM_Collapsed", StringUtil.BoolToStr( Dvpanel_calcom_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CALCOM_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_calcom_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CALCOM_Iconposition", StringUtil.RTrim( Dvpanel_calcom_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CALCOM_Autoscroll", StringUtil.BoolToStr( Dvpanel_calcom_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELCOSTOXZONA_Width", StringUtil.RTrim( Dvpanel_panelcostoxzona_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELCOSTOXZONA_Autowidth", StringUtil.BoolToStr( Dvpanel_panelcostoxzona_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELCOSTOXZONA_Autoheight", StringUtil.BoolToStr( Dvpanel_panelcostoxzona_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELCOSTOXZONA_Cls", StringUtil.RTrim( Dvpanel_panelcostoxzona_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELCOSTOXZONA_Title", StringUtil.RTrim( Dvpanel_panelcostoxzona_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELCOSTOXZONA_Collapsible", StringUtil.BoolToStr( Dvpanel_panelcostoxzona_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELCOSTOXZONA_Collapsed", StringUtil.BoolToStr( Dvpanel_panelcostoxzona_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELCOSTOXZONA_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_panelcostoxzona_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELCOSTOXZONA_Iconposition", StringUtil.RTrim( Dvpanel_panelcostoxzona_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PANELCOSTOXZONA_Autoscroll", StringUtil.BoolToStr( Dvpanel_panelcostoxzona_Autoscroll));
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
            WEB72( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTB72( ) ;
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
         GXEncryptionTmp = "calcularcomisionwp.aspx"+UrlEncode(StringUtil.LTrimStr(AV7SolicitudesID,18,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV26CambioPrecio));
         return formatLink("calcularcomisionwp.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "CalcularComisionWP" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Calcular Comision WP", "") ;
      }

      protected void WBB70( )
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSolicitudesid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSolicitudesid_Internalname, context.GetMessage( "Solicitud No:", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSolicitudesid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7SolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavSolicitudesid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7SolicitudesID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV7SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,17);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSolicitudesid_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSolicitudesid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CalcularComisionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSolicitudesnombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSolicitudesnombre_Internalname, context.GetMessage( "Nombre de la persona", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSolicitudesnombre_Internalname, StringUtil.RTrim( AV8SolicitudesNombre), StringUtil.RTrim( context.localUtil.Format( AV8SolicitudesNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSolicitudesnombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSolicitudesnombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CalcularComisionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSolicitudserviciopfinal_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSolicitudserviciopfinal_Internalname, context.GetMessage( "Precio", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSolicitudserviciopfinal_Internalname, StringUtil.LTrim( StringUtil.NToC( AV17SolicitudServicioPFinal, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavSolicitudserviciopfinal_Enabled!=0) ? context.localUtil.Format( AV17SolicitudServicioPFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV17SolicitudServicioPFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSolicitudserviciopfinal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSolicitudserviciopfinal_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CalcularComisionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCostoxzona_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCostoxzona_Internalname, context.GetMessage( "Comision Costo x Zona", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCostoxzona_Internalname, StringUtil.LTrim( StringUtil.NToC( AV35CostoXZona, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCostoxzona_Enabled!=0) ? context.localUtil.Format( AV35CostoXZona, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV35CostoXZona, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCostoxzona_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCostoxzona_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_CalcularComisionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTotal_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTotal_Internalname, context.GetMessage( "Total", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( AV34Total, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavTotal_Enabled!=0) ? context.localUtil.Format( AV34Total, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV34Total, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTotal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavTotal_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CalcularComisionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavSolicitudescalcomi_Internalname, context.GetMessage( "Calcular Comisión", ""), "col-sm-3 cardLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            ClassString = "Card";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavSolicitudescalcomi_Internalname, StringUtil.BoolToStr( AV20SolicitudesCalComi), "", context.GetMessage( "Calcular Comisión", ""), 1, chkavSolicitudescalcomi.Enabled, "true", context.GetMessage( "Calcular Comisión", ""), StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,39);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-10", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtncalcular_Internalname, "", context.GetMessage( "Calcular Comisiones", ""), bttBtnbtncalcular_Jsonclick, 5, context.GetMessage( "Calcular Comisiones", ""), "", StyleString, ClassString, bttBtnbtncalcular_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNCALCULAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CalcularComisionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_calcom.SetProperty("Width", Dvpanel_calcom_Width);
            ucDvpanel_calcom.SetProperty("AutoWidth", Dvpanel_calcom_Autowidth);
            ucDvpanel_calcom.SetProperty("AutoHeight", Dvpanel_calcom_Autoheight);
            ucDvpanel_calcom.SetProperty("Cls", Dvpanel_calcom_Cls);
            ucDvpanel_calcom.SetProperty("Title", Dvpanel_calcom_Title);
            ucDvpanel_calcom.SetProperty("Collapsible", Dvpanel_calcom_Collapsible);
            ucDvpanel_calcom.SetProperty("Collapsed", Dvpanel_calcom_Collapsed);
            ucDvpanel_calcom.SetProperty("ShowCollapseIcon", Dvpanel_calcom_Showcollapseicon);
            ucDvpanel_calcom.SetProperty("IconPosition", Dvpanel_calcom_Iconposition);
            ucDvpanel_calcom.SetProperty("AutoScroll", Dvpanel_calcom_Autoscroll);
            ucDvpanel_calcom.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_calcom_Internalname, "DVPANEL_CALCOMContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_CALCOMContainer"+"CalCom"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divCalcom_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSolicitudserviciocomprov_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSolicitudserviciocomprov_Internalname, context.GetMessage( "Comisión Comercio ", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSolicitudserviciocomprov_Internalname, StringUtil.LTrim( StringUtil.NToC( AV10SolicitudServicioComProv, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( AV10SolicitudServicioComProv, "ZZZZZZZZZZZZZZ9.99")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSolicitudserviciocomprov_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSolicitudserviciocomprov_Enabled, 1, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CalcularComisionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSolicitudserviciocomprovp_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSolicitudserviciocomprovp_Internalname, context.GetMessage( "Porcentaje", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSolicitudserviciocomprovp_Internalname, StringUtil.LTrim( StringUtil.NToC( AV11SolicitudServicioComProvP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( AV11SolicitudServicioComProvP, "ZZ9.99")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSolicitudserviciocomprovp_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSolicitudserviciocomprovp_Enabled, 1, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CalcularComisionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSolicitudserviciocomalm_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSolicitudserviciocomalm_Internalname, context.GetMessage( "Comisión Almango", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSolicitudserviciocomalm_Internalname, StringUtil.LTrim( StringUtil.NToC( AV12SolicitudServicioComALM, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( AV12SolicitudServicioComALM, "ZZZZZZZZZZZZZZ9.99")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSolicitudserviciocomalm_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSolicitudserviciocomalm_Enabled, 1, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CalcularComisionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSolicitudserviciocomalmp_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSolicitudserviciocomalmp_Internalname, context.GetMessage( "Porcentaje ", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSolicitudserviciocomalmp_Internalname, StringUtil.LTrim( StringUtil.NToC( AV13SolicitudServicioComALMP, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( AV13SolicitudServicioComALMP, "ZZZZZZZZZZZZZZ9.99")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSolicitudserviciocomalmp_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSolicitudserviciocomalmp_Enabled, 1, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CalcularComisionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSolicitudserviciocompro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSolicitudserviciocompro_Internalname, context.GetMessage( "Comisión Profesional", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSolicitudserviciocompro_Internalname, StringUtil.LTrim( StringUtil.NToC( AV14SolicitudServicioComPro, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavSolicitudserviciocompro_Enabled!=0) ? context.localUtil.Format( AV14SolicitudServicioComPro, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV14SolicitudServicioComPro, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSolicitudserviciocompro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSolicitudserviciocompro_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CalcularComisionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSolicitudserviciocomprop_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSolicitudserviciocomprop_Internalname, context.GetMessage( "Porcentaje", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSolicitudserviciocomprop_Internalname, StringUtil.LTrim( StringUtil.NToC( AV15SolicitudServicioComProP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavSolicitudserviciocomprop_Enabled!=0) ? context.localUtil.Format( AV15SolicitudServicioComProP, "ZZ9.99") : context.localUtil.Format( AV15SolicitudServicioComProP, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSolicitudserviciocomprop_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSolicitudserviciocomprop_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CalcularComisionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_panelcostoxzona.SetProperty("Width", Dvpanel_panelcostoxzona_Width);
            ucDvpanel_panelcostoxzona.SetProperty("AutoWidth", Dvpanel_panelcostoxzona_Autowidth);
            ucDvpanel_panelcostoxzona.SetProperty("AutoHeight", Dvpanel_panelcostoxzona_Autoheight);
            ucDvpanel_panelcostoxzona.SetProperty("Cls", Dvpanel_panelcostoxzona_Cls);
            ucDvpanel_panelcostoxzona.SetProperty("Title", Dvpanel_panelcostoxzona_Title);
            ucDvpanel_panelcostoxzona.SetProperty("Collapsible", Dvpanel_panelcostoxzona_Collapsible);
            ucDvpanel_panelcostoxzona.SetProperty("Collapsed", Dvpanel_panelcostoxzona_Collapsed);
            ucDvpanel_panelcostoxzona.SetProperty("ShowCollapseIcon", Dvpanel_panelcostoxzona_Showcollapseicon);
            ucDvpanel_panelcostoxzona.SetProperty("IconPosition", Dvpanel_panelcostoxzona_Iconposition);
            ucDvpanel_panelcostoxzona.SetProperty("AutoScroll", Dvpanel_panelcostoxzona_Autoscroll);
            ucDvpanel_panelcostoxzona.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_panelcostoxzona_Internalname, "DVPANEL_PANELCOSTOXZONAContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_PANELCOSTOXZONAContainer"+"PanelCostoxZona"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divPanelcostoxzona_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSolicitudservicioxzona_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSolicitudservicioxzona_Internalname, context.GetMessage( "Costo x Zona", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSolicitudservicioxzona_Internalname, StringUtil.LTrim( StringUtil.NToC( AV39SolicitudServicioXZona, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavSolicitudservicioxzona_Enabled!=0) ? context.localUtil.Format( AV39SolicitudServicioXZona, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV39SolicitudServicioXZona, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSolicitudservicioxzona_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSolicitudservicioxzona_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CalcularComisionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSolicitudservicioxzcomalm_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSolicitudservicioxzcomalm_Internalname, context.GetMessage( "Comisión Costo Almango", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSolicitudservicioxzcomalm_Internalname, StringUtil.LTrim( StringUtil.NToC( AV29SolicitudServicioXZComALM, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( AV29SolicitudServicioXZComALM, "ZZZZZZZZZZZZZZ9.99")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,87);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSolicitudservicioxzcomalm_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSolicitudservicioxzcomalm_Enabled, 1, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CalcularComisionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSolicitudservicioxzcomalmp_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSolicitudservicioxzcomalmp_Internalname, context.GetMessage( "Porcentaje", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSolicitudservicioxzcomalmp_Internalname, StringUtil.LTrim( StringUtil.NToC( AV30SolicitudServicioXZComAlmP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( AV30SolicitudServicioXZComAlmP, "ZZ9.99")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSolicitudservicioxzcomalmp_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSolicitudservicioxzcomalmp_Enabled, 1, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CalcularComisionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSolicitudservicioxzcomprof_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSolicitudservicioxzcomprof_Internalname, context.GetMessage( "Comision Costo Profesional", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSolicitudservicioxzcomprof_Internalname, StringUtil.LTrim( StringUtil.NToC( AV31SolicitudServicioXZComProf, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavSolicitudservicioxzcomprof_Enabled!=0) ? context.localUtil.Format( AV31SolicitudServicioXZComProf, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV31SolicitudServicioXZComProf, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSolicitudservicioxzcomprof_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSolicitudservicioxzcomprof_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CalcularComisionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSolicitudservicioxzcomprofp_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSolicitudservicioxzcomprofp_Internalname, context.GetMessage( "Porcentaje", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSolicitudservicioxzcomprofp_Internalname, StringUtil.LTrim( StringUtil.NToC( AV32SolicitudServicioXZComProfP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavSolicitudservicioxzcomprofp_Enabled!=0) ? context.localUtil.Format( AV32SolicitudServicioXZComProfP, "ZZ9.99") : context.localUtil.Format( AV32SolicitudServicioXZComProfP, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,100);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSolicitudservicioxzcomprofp_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavSolicitudservicioxzcomprofp_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CalcularComisionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncalcularcomxzona_Internalname, "", context.GetMessage( "Calcular Costo", ""), bttBtncalcularcomxzona_Jsonclick, 5, context.GetMessage( "Calcular Costo", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOCALCULARCOMXZONA\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CalcularComisionWP.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnguardar_Internalname, "", context.GetMessage( "Guardar", ""), bttBtnguardar_Jsonclick, 5, context.GetMessage( "Guardar", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOGUARDAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CalcularComisionWP.htm");
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
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSolicitudservicioxzonap_Internalname, StringUtil.LTrim( StringUtil.NToC( AV40SolicitudServicioXZonaP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( AV40SolicitudServicioXZonaP, "ZZ9.99")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,110);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSolicitudservicioxzonap_Jsonclick, 0, "Attribute", "", "", "", "", edtavSolicitudservicioxzonap_Visible, 1, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CalcularComisionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void STARTB72( )
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
         Form.Meta.addItem("description", context.GetMessage( "Calcular Comision WP", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPB70( ) ;
      }

      protected void WSB72( )
      {
         STARTB72( ) ;
         EVTB72( ) ;
      }

      protected void EVTB72( )
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
                              E11B72 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNCALCULAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBTNCalcular' */
                              E12B72 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOGUARDAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoGuardar' */
                              E13B72 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCALCULARCOMXZONA'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoCalcularComXZona' */
                              E14B72 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E15B72 ();
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

      protected void WEB72( )
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

      protected void PAB72( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "calcularcomisionwp.aspx")), "calcularcomisionwp.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "calcularcomisionwp.aspx")))) ;
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
                     AV7SolicitudesID = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV7SolicitudesID", StringUtil.LTrimStr( (decimal)(AV7SolicitudesID), 18, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV26CambioPrecio = StringUtil.StrToBool( GetPar( "CambioPrecio"));
                        AssignAttri("", false, "AV26CambioPrecio", AV26CambioPrecio);
                        GxWebStd.gx_hidden_field( context, "gxhash_vCAMBIOPRECIO", GetSecureSignedToken( "", AV26CambioPrecio, context));
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
               GX_FocusControl = edtavSolicitudesnombre_Internalname;
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
         AV20SolicitudesCalComi = StringUtil.StrToBool( StringUtil.BoolToStr( AV20SolicitudesCalComi));
         AssignAttri("", false, "AV20SolicitudesCalComi", AV20SolicitudesCalComi);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFB72( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavSolicitudesid_Enabled = 0;
         AssignProp("", false, edtavSolicitudesid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSolicitudesid_Enabled), 5, 0), true);
         edtavSolicitudesnombre_Enabled = 0;
         AssignProp("", false, edtavSolicitudesnombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSolicitudesnombre_Enabled), 5, 0), true);
         edtavSolicitudserviciopfinal_Enabled = 0;
         AssignProp("", false, edtavSolicitudserviciopfinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSolicitudserviciopfinal_Enabled), 5, 0), true);
         edtavCostoxzona_Enabled = 0;
         AssignProp("", false, edtavCostoxzona_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCostoxzona_Enabled), 5, 0), true);
         edtavTotal_Enabled = 0;
         AssignProp("", false, edtavTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotal_Enabled), 5, 0), true);
         edtavSolicitudserviciocomprov_Enabled = 0;
         AssignProp("", false, edtavSolicitudserviciocomprov_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSolicitudserviciocomprov_Enabled), 5, 0), true);
         edtavSolicitudserviciocompro_Enabled = 0;
         AssignProp("", false, edtavSolicitudserviciocompro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSolicitudserviciocompro_Enabled), 5, 0), true);
         edtavSolicitudserviciocomprop_Enabled = 0;
         AssignProp("", false, edtavSolicitudserviciocomprop_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSolicitudserviciocomprop_Enabled), 5, 0), true);
         edtavSolicitudservicioxzona_Enabled = 0;
         AssignProp("", false, edtavSolicitudservicioxzona_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSolicitudservicioxzona_Enabled), 5, 0), true);
         edtavSolicitudservicioxzcomprof_Enabled = 0;
         AssignProp("", false, edtavSolicitudservicioxzcomprof_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSolicitudservicioxzcomprof_Enabled), 5, 0), true);
         edtavSolicitudservicioxzcomprofp_Enabled = 0;
         AssignProp("", false, edtavSolicitudservicioxzcomprofp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSolicitudservicioxzcomprofp_Enabled), 5, 0), true);
      }

      protected void RFB72( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E15B72 ();
            WBB70( ) ;
         }
      }

      protected void send_integrity_lvl_hashesB72( )
      {
         GxWebStd.gx_hidden_field( context, "vPROFESIONALESID", StringUtil.RTrim( AV18ProFesionalesID));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROFESIONALESID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18ProFesionalesID, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDSERVICIOPFINAL", GetSecureSignedToken( "", context.localUtil.Format( AV17SolicitudServicioPFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"), context));
      }

      protected void before_start_formulas( )
      {
         edtavSolicitudesid_Enabled = 0;
         AssignProp("", false, edtavSolicitudesid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSolicitudesid_Enabled), 5, 0), true);
         edtavSolicitudesnombre_Enabled = 0;
         AssignProp("", false, edtavSolicitudesnombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSolicitudesnombre_Enabled), 5, 0), true);
         edtavSolicitudserviciopfinal_Enabled = 0;
         AssignProp("", false, edtavSolicitudserviciopfinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSolicitudserviciopfinal_Enabled), 5, 0), true);
         edtavCostoxzona_Enabled = 0;
         AssignProp("", false, edtavCostoxzona_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCostoxzona_Enabled), 5, 0), true);
         edtavTotal_Enabled = 0;
         AssignProp("", false, edtavTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotal_Enabled), 5, 0), true);
         edtavSolicitudserviciocomprov_Enabled = 0;
         AssignProp("", false, edtavSolicitudserviciocomprov_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSolicitudserviciocomprov_Enabled), 5, 0), true);
         edtavSolicitudserviciocompro_Enabled = 0;
         AssignProp("", false, edtavSolicitudserviciocompro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSolicitudserviciocompro_Enabled), 5, 0), true);
         edtavSolicitudserviciocomprop_Enabled = 0;
         AssignProp("", false, edtavSolicitudserviciocomprop_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSolicitudserviciocomprop_Enabled), 5, 0), true);
         edtavSolicitudservicioxzona_Enabled = 0;
         AssignProp("", false, edtavSolicitudservicioxzona_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSolicitudservicioxzona_Enabled), 5, 0), true);
         edtavSolicitudservicioxzcomprof_Enabled = 0;
         AssignProp("", false, edtavSolicitudservicioxzcomprof_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSolicitudservicioxzcomprof_Enabled), 5, 0), true);
         edtavSolicitudservicioxzcomprofp_Enabled = 0;
         AssignProp("", false, edtavSolicitudservicioxzcomprofp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSolicitudservicioxzcomprofp_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUPB70( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11B72 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            AV38OldSolicitudServicioXZComAlm = context.localUtil.CToN( cgiGet( "vOLDSOLICITUDSERVICIOXZCOMALM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AV45Oldsolicitudservicioxzcomalmp = context.localUtil.CToN( cgiGet( "vOLDSOLICITUDSERVICIOXZCOMALMP"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AV23OldSolicitudServicioComALM = context.localUtil.CToN( cgiGet( "vOLDSOLICITUDSERVICIOCOMALM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AV24OldSolicitudServicioComALMP = context.localUtil.CToN( cgiGet( "vOLDSOLICITUDSERVICIOCOMALMP"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AV21OldSolicitudServicioComProv = context.localUtil.CToN( cgiGet( "vOLDSOLICITUDSERVICIOCOMPROV"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AV22OldSolicitudServicioComProvP = context.localUtil.CToN( cgiGet( "vOLDSOLICITUDSERVICIOCOMPROVP"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            Dvpanel_calcom_Width = cgiGet( "DVPANEL_CALCOM_Width");
            Dvpanel_calcom_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_CALCOM_Autowidth"));
            Dvpanel_calcom_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_CALCOM_Autoheight"));
            Dvpanel_calcom_Cls = cgiGet( "DVPANEL_CALCOM_Cls");
            Dvpanel_calcom_Title = cgiGet( "DVPANEL_CALCOM_Title");
            Dvpanel_calcom_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_CALCOM_Collapsible"));
            Dvpanel_calcom_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_CALCOM_Collapsed"));
            Dvpanel_calcom_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_CALCOM_Showcollapseicon"));
            Dvpanel_calcom_Iconposition = cgiGet( "DVPANEL_CALCOM_Iconposition");
            Dvpanel_calcom_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_CALCOM_Autoscroll"));
            Dvpanel_panelcostoxzona_Width = cgiGet( "DVPANEL_PANELCOSTOXZONA_Width");
            Dvpanel_panelcostoxzona_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_PANELCOSTOXZONA_Autowidth"));
            Dvpanel_panelcostoxzona_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_PANELCOSTOXZONA_Autoheight"));
            Dvpanel_panelcostoxzona_Cls = cgiGet( "DVPANEL_PANELCOSTOXZONA_Cls");
            Dvpanel_panelcostoxzona_Title = cgiGet( "DVPANEL_PANELCOSTOXZONA_Title");
            Dvpanel_panelcostoxzona_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_PANELCOSTOXZONA_Collapsible"));
            Dvpanel_panelcostoxzona_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_PANELCOSTOXZONA_Collapsed"));
            Dvpanel_panelcostoxzona_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_PANELCOSTOXZONA_Showcollapseicon"));
            Dvpanel_panelcostoxzona_Iconposition = cgiGet( "DVPANEL_PANELCOSTOXZONA_Iconposition");
            Dvpanel_panelcostoxzona_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_PANELCOSTOXZONA_Autoscroll"));
            /* Read variables values. */
            AV8SolicitudesNombre = cgiGet( edtavSolicitudesnombre_Internalname);
            AssignAttri("", false, "AV8SolicitudesNombre", AV8SolicitudesNombre);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSolicitudserviciopfinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavSolicitudserviciopfinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSOLICITUDSERVICIOPFINAL");
               GX_FocusControl = edtavSolicitudserviciopfinal_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV17SolicitudServicioPFinal = 0;
               AssignAttri("", false, "AV17SolicitudServicioPFinal", StringUtil.LTrimStr( AV17SolicitudServicioPFinal, 18, 2));
               GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDSERVICIOPFINAL", GetSecureSignedToken( "", context.localUtil.Format( AV17SolicitudServicioPFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"), context));
            }
            else
            {
               AV17SolicitudServicioPFinal = context.localUtil.CToN( cgiGet( edtavSolicitudserviciopfinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV17SolicitudServicioPFinal", StringUtil.LTrimStr( AV17SolicitudServicioPFinal, 18, 2));
               GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDSERVICIOPFINAL", GetSecureSignedToken( "", context.localUtil.Format( AV17SolicitudServicioPFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"), context));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCostoxzona_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavCostoxzona_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCOSTOXZONA");
               GX_FocusControl = edtavCostoxzona_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV35CostoXZona = 0;
               AssignAttri("", false, "AV35CostoXZona", StringUtil.LTrimStr( AV35CostoXZona, 18, 2));
            }
            else
            {
               AV35CostoXZona = context.localUtil.CToN( cgiGet( edtavCostoxzona_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV35CostoXZona", StringUtil.LTrimStr( AV35CostoXZona, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTotal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTotal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTOTAL");
               GX_FocusControl = edtavTotal_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV34Total = 0;
               AssignAttri("", false, "AV34Total", StringUtil.LTrimStr( AV34Total, 18, 2));
            }
            else
            {
               AV34Total = context.localUtil.CToN( cgiGet( edtavTotal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV34Total", StringUtil.LTrimStr( AV34Total, 18, 2));
            }
            AV20SolicitudesCalComi = StringUtil.StrToBool( cgiGet( chkavSolicitudescalcomi_Internalname));
            AssignAttri("", false, "AV20SolicitudesCalComi", AV20SolicitudesCalComi);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSolicitudserviciocomprov_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSolicitudserviciocomprov_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSOLICITUDSERVICIOCOMPROV");
               GX_FocusControl = edtavSolicitudserviciocomprov_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10SolicitudServicioComProv = 0;
               AssignAttri("", false, "AV10SolicitudServicioComProv", StringUtil.LTrimStr( AV10SolicitudServicioComProv, 18, 2));
            }
            else
            {
               AV10SolicitudServicioComProv = context.localUtil.CToN( cgiGet( edtavSolicitudserviciocomprov_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV10SolicitudServicioComProv", StringUtil.LTrimStr( AV10SolicitudServicioComProv, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSolicitudserviciocomprovp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSolicitudserviciocomprovp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSOLICITUDSERVICIOCOMPROVP");
               GX_FocusControl = edtavSolicitudserviciocomprovp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11SolicitudServicioComProvP = 0;
               AssignAttri("", false, "AV11SolicitudServicioComProvP", StringUtil.LTrimStr( AV11SolicitudServicioComProvP, 6, 2));
            }
            else
            {
               AV11SolicitudServicioComProvP = context.localUtil.CToN( cgiGet( edtavSolicitudserviciocomprovp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV11SolicitudServicioComProvP", StringUtil.LTrimStr( AV11SolicitudServicioComProvP, 6, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSolicitudserviciocomalm_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavSolicitudserviciocomalm_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSOLICITUDSERVICIOCOMALM");
               GX_FocusControl = edtavSolicitudserviciocomalm_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12SolicitudServicioComALM = 0;
               AssignAttri("", false, "AV12SolicitudServicioComALM", StringUtil.LTrimStr( AV12SolicitudServicioComALM, 18, 2));
            }
            else
            {
               AV12SolicitudServicioComALM = context.localUtil.CToN( cgiGet( edtavSolicitudserviciocomalm_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV12SolicitudServicioComALM", StringUtil.LTrimStr( AV12SolicitudServicioComALM, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSolicitudserviciocomalmp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavSolicitudserviciocomalmp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSOLICITUDSERVICIOCOMALMP");
               GX_FocusControl = edtavSolicitudserviciocomalmp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV13SolicitudServicioComALMP = 0;
               AssignAttri("", false, "AV13SolicitudServicioComALMP", StringUtil.LTrimStr( AV13SolicitudServicioComALMP, 18, 2));
            }
            else
            {
               AV13SolicitudServicioComALMP = context.localUtil.CToN( cgiGet( edtavSolicitudserviciocomalmp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV13SolicitudServicioComALMP", StringUtil.LTrimStr( AV13SolicitudServicioComALMP, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSolicitudserviciocompro_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavSolicitudserviciocompro_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSOLICITUDSERVICIOCOMPRO");
               GX_FocusControl = edtavSolicitudserviciocompro_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV14SolicitudServicioComPro = 0;
               AssignAttri("", false, "AV14SolicitudServicioComPro", StringUtil.LTrimStr( AV14SolicitudServicioComPro, 18, 2));
            }
            else
            {
               AV14SolicitudServicioComPro = context.localUtil.CToN( cgiGet( edtavSolicitudserviciocompro_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV14SolicitudServicioComPro", StringUtil.LTrimStr( AV14SolicitudServicioComPro, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSolicitudserviciocomprop_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSolicitudserviciocomprop_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSOLICITUDSERVICIOCOMPROP");
               GX_FocusControl = edtavSolicitudserviciocomprop_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15SolicitudServicioComProP = 0;
               AssignAttri("", false, "AV15SolicitudServicioComProP", StringUtil.LTrimStr( AV15SolicitudServicioComProP, 6, 2));
            }
            else
            {
               AV15SolicitudServicioComProP = context.localUtil.CToN( cgiGet( edtavSolicitudserviciocomprop_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV15SolicitudServicioComProP", StringUtil.LTrimStr( AV15SolicitudServicioComProP, 6, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSolicitudservicioxzona_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavSolicitudservicioxzona_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSOLICITUDSERVICIOXZONA");
               GX_FocusControl = edtavSolicitudservicioxzona_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV39SolicitudServicioXZona = 0;
               AssignAttri("", false, "AV39SolicitudServicioXZona", StringUtil.LTrimStr( AV39SolicitudServicioXZona, 18, 2));
            }
            else
            {
               AV39SolicitudServicioXZona = context.localUtil.CToN( cgiGet( edtavSolicitudservicioxzona_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV39SolicitudServicioXZona", StringUtil.LTrimStr( AV39SolicitudServicioXZona, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSolicitudservicioxzcomalm_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavSolicitudservicioxzcomalm_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSOLICITUDSERVICIOXZCOMALM");
               GX_FocusControl = edtavSolicitudservicioxzcomalm_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV29SolicitudServicioXZComALM = 0;
               AssignAttri("", false, "AV29SolicitudServicioXZComALM", StringUtil.LTrimStr( AV29SolicitudServicioXZComALM, 18, 2));
            }
            else
            {
               AV29SolicitudServicioXZComALM = context.localUtil.CToN( cgiGet( edtavSolicitudservicioxzcomalm_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV29SolicitudServicioXZComALM", StringUtil.LTrimStr( AV29SolicitudServicioXZComALM, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSolicitudservicioxzcomalmp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSolicitudservicioxzcomalmp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSOLICITUDSERVICIOXZCOMALMP");
               GX_FocusControl = edtavSolicitudservicioxzcomalmp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV30SolicitudServicioXZComAlmP = 0;
               AssignAttri("", false, "AV30SolicitudServicioXZComAlmP", StringUtil.LTrimStr( AV30SolicitudServicioXZComAlmP, 6, 2));
            }
            else
            {
               AV30SolicitudServicioXZComAlmP = context.localUtil.CToN( cgiGet( edtavSolicitudservicioxzcomalmp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV30SolicitudServicioXZComAlmP", StringUtil.LTrimStr( AV30SolicitudServicioXZComAlmP, 6, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSolicitudservicioxzcomprof_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavSolicitudservicioxzcomprof_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSOLICITUDSERVICIOXZCOMPROF");
               GX_FocusControl = edtavSolicitudservicioxzcomprof_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV31SolicitudServicioXZComProf = 0;
               AssignAttri("", false, "AV31SolicitudServicioXZComProf", StringUtil.LTrimStr( AV31SolicitudServicioXZComProf, 18, 2));
            }
            else
            {
               AV31SolicitudServicioXZComProf = context.localUtil.CToN( cgiGet( edtavSolicitudservicioxzcomprof_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV31SolicitudServicioXZComProf", StringUtil.LTrimStr( AV31SolicitudServicioXZComProf, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSolicitudservicioxzcomprofp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSolicitudservicioxzcomprofp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSOLICITUDSERVICIOXZCOMPROFP");
               GX_FocusControl = edtavSolicitudservicioxzcomprofp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV32SolicitudServicioXZComProfP = 0;
               AssignAttri("", false, "AV32SolicitudServicioXZComProfP", StringUtil.LTrimStr( AV32SolicitudServicioXZComProfP, 6, 2));
            }
            else
            {
               AV32SolicitudServicioXZComProfP = context.localUtil.CToN( cgiGet( edtavSolicitudservicioxzcomprofp_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV32SolicitudServicioXZComProfP", StringUtil.LTrimStr( AV32SolicitudServicioXZComProfP, 6, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSolicitudservicioxzonap_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSolicitudservicioxzonap_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSOLICITUDSERVICIOXZONAP");
               GX_FocusControl = edtavSolicitudservicioxzonap_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV40SolicitudServicioXZonaP = 0;
               AssignAttri("", false, "AV40SolicitudServicioXZonaP", StringUtil.LTrimStr( AV40SolicitudServicioXZonaP, 6, 2));
            }
            else
            {
               AV40SolicitudServicioXZonaP = context.localUtil.CToN( cgiGet( edtavSolicitudservicioxzonap_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV40SolicitudServicioXZonaP", StringUtil.LTrimStr( AV40SolicitudServicioXZonaP, 6, 2));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"CalcularComisionWP");
            AV17SolicitudServicioPFinal = context.localUtil.CToN( cgiGet( edtavSolicitudserviciopfinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AssignAttri("", false, "AV17SolicitudServicioPFinal", StringUtil.LTrimStr( AV17SolicitudServicioPFinal, 18, 2));
            GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDSERVICIOPFINAL", GetSecureSignedToken( "", context.localUtil.Format( AV17SolicitudServicioPFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"), context));
            forbiddenHiddens.Add("SolicitudServicioPFinal", context.localUtil.Format( AV17SolicitudServicioPFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"));
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("calcularcomisionwp:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
         E11B72 ();
         if (returnInSub) return;
      }

      protected void E11B72( )
      {
         /* Start Routine */
         returnInSub = false;
         AV16Solicitudes.Load(AV7SolicitudesID);
         AV8SolicitudesNombre = AV16Solicitudes.gxTpr_Solicitudesnombre;
         AssignAttri("", false, "AV8SolicitudesNombre", AV8SolicitudesNombre);
         AV17SolicitudServicioPFinal = (decimal)(AV16Solicitudes.gxTpr_Solicitudserviciopfinal-AV16Solicitudes.gxTpr_Solicitudescostoxzona);
         AssignAttri("", false, "AV17SolicitudServicioPFinal", StringUtil.LTrimStr( AV17SolicitudServicioPFinal, 18, 2));
         GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDSERVICIOPFINAL", GetSecureSignedToken( "", context.localUtil.Format( AV17SolicitudServicioPFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"), context));
         AV35CostoXZona = AV16Solicitudes.gxTpr_Solicitudescostoxzona;
         AssignAttri("", false, "AV35CostoXZona", StringUtil.LTrimStr( AV35CostoXZona, 18, 2));
         AV39SolicitudServicioXZona = AV16Solicitudes.gxTpr_Solicitudescostoxzona;
         AssignAttri("", false, "AV39SolicitudServicioXZona", StringUtil.LTrimStr( AV39SolicitudServicioXZona, 18, 2));
         AV34Total = AV16Solicitudes.gxTpr_Solicitudserviciopfinal;
         AssignAttri("", false, "AV34Total", StringUtil.LTrimStr( AV34Total, 18, 2));
         GX_msglist.addItem(context.GetMessage( "Favor guardar los cambios.", ""));
         if ( ! AV26CambioPrecio )
         {
            /* Execute user subroutine: 'CALCULAR COMISIONPROFESIONAL' */
            S112 ();
            if (returnInSub) return;
            AV20SolicitudesCalComi = AV16Solicitudes.gxTpr_Solicitudescalcomi;
            AssignAttri("", false, "AV20SolicitudesCalComi", AV20SolicitudesCalComi);
            if ( StringUtil.StrCmp(AV16Solicitudes.gxTpr_Solicitudessubtipo, "A") == 0 )
            {
               AV14SolicitudServicioComPro = 0;
               AssignAttri("", false, "AV14SolicitudServicioComPro", StringUtil.LTrimStr( AV14SolicitudServicioComPro, 18, 2));
               AV15SolicitudServicioComProP = 0;
               AssignAttri("", false, "AV15SolicitudServicioComProP", StringUtil.LTrimStr( AV15SolicitudServicioComProP, 6, 2));
               AV12SolicitudServicioComALM = AV16Solicitudes.gxTpr_Solicitudserviciopfinal;
               AssignAttri("", false, "AV12SolicitudServicioComALM", StringUtil.LTrimStr( AV12SolicitudServicioComALM, 18, 2));
               AV13SolicitudServicioComALMP = (decimal)(100);
               AssignAttri("", false, "AV13SolicitudServicioComALMP", StringUtil.LTrimStr( AV13SolicitudServicioComALMP, 18, 2));
            }
            else
            {
               AV14SolicitudServicioComPro = AV16Solicitudes.gxTpr_Solicitudserviciocompro;
               AssignAttri("", false, "AV14SolicitudServicioComPro", StringUtil.LTrimStr( AV14SolicitudServicioComPro, 18, 2));
               AV15SolicitudServicioComProP = AV16Solicitudes.gxTpr_Solicitudserviciocomprop;
               AssignAttri("", false, "AV15SolicitudServicioComProP", StringUtil.LTrimStr( AV15SolicitudServicioComProP, 6, 2));
               AV12SolicitudServicioComALM = AV16Solicitudes.gxTpr_Solicitudserviciocomalm;
               AssignAttri("", false, "AV12SolicitudServicioComALM", StringUtil.LTrimStr( AV12SolicitudServicioComALM, 18, 2));
               AV13SolicitudServicioComALMP = AV16Solicitudes.gxTpr_Solicitudserviciocomalmp;
               AssignAttri("", false, "AV13SolicitudServicioComALMP", StringUtil.LTrimStr( AV13SolicitudServicioComALMP, 18, 2));
            }
            AV29SolicitudServicioXZComALM = AV16Solicitudes.gxTpr_Solicitudescostoxzcomalm;
            AssignAttri("", false, "AV29SolicitudServicioXZComALM", StringUtil.LTrimStr( AV29SolicitudServicioXZComALM, 18, 2));
            AV30SolicitudServicioXZComAlmP = AV16Solicitudes.gxTpr_Solicitudescostoxzcomalmp;
            AssignAttri("", false, "AV30SolicitudServicioXZComAlmP", StringUtil.LTrimStr( AV30SolicitudServicioXZComAlmP, 6, 2));
            /* Execute user subroutine: 'CALCULAR COMISIONCOSTO' */
            S122 ();
            if (returnInSub) return;
            if ( new productosvarios(context).executeUdp(  AV16Solicitudes.gxTpr_Solicitudesid) > 1 )
            {
               new obtenercomiprodvarios(context ).execute(  AV16Solicitudes.gxTpr_Solicitudesid, out  AV12SolicitudServicioComALM, out  AV10SolicitudServicioComProv, out  AV14SolicitudServicioComPro) ;
               AssignAttri("", false, "AV12SolicitudServicioComALM", StringUtil.LTrimStr( AV12SolicitudServicioComALM, 18, 2));
               AssignAttri("", false, "AV10SolicitudServicioComProv", StringUtil.LTrimStr( AV10SolicitudServicioComProv, 18, 2));
               AssignAttri("", false, "AV14SolicitudServicioComPro", StringUtil.LTrimStr( AV14SolicitudServicioComPro, 18, 2));
               AV13SolicitudServicioComALMP = (decimal)((AV12SolicitudServicioComALM/ (decimal)(AV16Solicitudes.gxTpr_Solicitudserviciopfinal))*100);
               AssignAttri("", false, "AV13SolicitudServicioComALMP", StringUtil.LTrimStr( AV13SolicitudServicioComALMP, 18, 2));
               AV11SolicitudServicioComProvP = (decimal)((AV10SolicitudServicioComProv/ (decimal)(AV16Solicitudes.gxTpr_Solicitudserviciopfinal))*100);
               AssignAttri("", false, "AV11SolicitudServicioComProvP", StringUtil.LTrimStr( AV11SolicitudServicioComProvP, 6, 2));
               AV15SolicitudServicioComProP = (decimal)(100-(AV11SolicitudServicioComProvP+AV13SolicitudServicioComALMP));
               AssignAttri("", false, "AV15SolicitudServicioComProP", StringUtil.LTrimStr( AV15SolicitudServicioComProP, 6, 2));
            }
            bttBtnbtncalcular_Visible = 0;
            AssignProp("", false, bttBtnbtncalcular_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnbtncalcular_Visible), 5, 0), true);
            if ( AV20SolicitudesCalComi )
            {
               bttBtnbtncalcular_Visible = 1;
               AssignProp("", false, bttBtnbtncalcular_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnbtncalcular_Visible), 5, 0), true);
            }
         }
         if ( AV20SolicitudesCalComi )
         {
            bttBtnbtncalcular_Visible = 1;
            AssignProp("", false, bttBtnbtncalcular_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnbtncalcular_Visible), 5, 0), true);
            edtavSolicitudserviciocomprov_Enabled = 0;
            AssignProp("", false, edtavSolicitudserviciocomprov_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSolicitudserviciocomprov_Enabled), 5, 0), true);
            edtavSolicitudserviciocomprovp_Enabled = 0;
            AssignProp("", false, edtavSolicitudserviciocomprovp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSolicitudserviciocomprovp_Enabled), 5, 0), true);
            edtavSolicitudserviciocomalm_Enabled = 0;
            AssignProp("", false, edtavSolicitudserviciocomalm_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSolicitudserviciocomalm_Enabled), 5, 0), true);
            edtavSolicitudserviciocomalmp_Enabled = 0;
            AssignProp("", false, edtavSolicitudserviciocomalmp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSolicitudserviciocomalmp_Enabled), 5, 0), true);
            edtavSolicitudservicioxzcomalm_Enabled = 0;
            AssignProp("", false, edtavSolicitudservicioxzcomalm_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSolicitudservicioxzcomalm_Enabled), 5, 0), true);
            edtavSolicitudservicioxzcomalmp_Enabled = 0;
            AssignProp("", false, edtavSolicitudservicioxzcomalmp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSolicitudservicioxzcomalmp_Enabled), 5, 0), true);
         }
         else
         {
            bttBtnbtncalcular_Visible = 0;
            AssignProp("", false, bttBtnbtncalcular_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnbtncalcular_Visible), 5, 0), true);
            edtavSolicitudserviciocomprov_Enabled = 1;
            AssignProp("", false, edtavSolicitudserviciocomprov_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSolicitudserviciocomprov_Enabled), 5, 0), true);
            edtavSolicitudserviciocomprovp_Enabled = 1;
            AssignProp("", false, edtavSolicitudserviciocomprovp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSolicitudserviciocomprovp_Enabled), 5, 0), true);
            edtavSolicitudserviciocomalm_Enabled = 1;
            AssignProp("", false, edtavSolicitudserviciocomalm_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSolicitudserviciocomalm_Enabled), 5, 0), true);
            edtavSolicitudserviciocomalmp_Enabled = 1;
            AssignProp("", false, edtavSolicitudserviciocomalmp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSolicitudserviciocomalmp_Enabled), 5, 0), true);
            edtavSolicitudservicioxzcomalm_Enabled = 1;
            AssignProp("", false, edtavSolicitudservicioxzcomalm_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSolicitudservicioxzcomalm_Enabled), 5, 0), true);
            edtavSolicitudservicioxzcomalmp_Enabled = 1;
            AssignProp("", false, edtavSolicitudservicioxzcomalmp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSolicitudservicioxzcomalmp_Enabled), 5, 0), true);
         }
         edtavSolicitudservicioxzonap_Visible = 0;
         AssignProp("", false, edtavSolicitudservicioxzonap_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSolicitudservicioxzonap_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV42WebSession.Get(context.GetMessage( "CerrarComision", "")), context.GetMessage( "si", "")) == 0 )
         {
            /* Execute user subroutine: 'SUBGUARDAR' */
            S132 ();
            if (returnInSub) return;
         }
         else
         {
            AV42WebSession.Set(context.GetMessage( "CerrarComision", ""), context.GetMessage( "no", ""));
         }
      }

      protected void E12B72( )
      {
         /* 'DoBTNCalcular' Routine */
         returnInSub = false;
         new ocomisionsolicitud(context ).execute(  AV7SolicitudesID,  AV18ProFesionalesID,  true, out  AV10SolicitudServicioComProv, out  AV11SolicitudServicioComProvP, out  AV12SolicitudServicioComALM, out  AV13SolicitudServicioComALMP, out  AV14SolicitudServicioComPro, out  AV15SolicitudServicioComProP) ;
         AssignAttri("", false, "AV10SolicitudServicioComProv", StringUtil.LTrimStr( AV10SolicitudServicioComProv, 18, 2));
         AssignAttri("", false, "AV11SolicitudServicioComProvP", StringUtil.LTrimStr( AV11SolicitudServicioComProvP, 6, 2));
         AssignAttri("", false, "AV12SolicitudServicioComALM", StringUtil.LTrimStr( AV12SolicitudServicioComALM, 18, 2));
         AssignAttri("", false, "AV13SolicitudServicioComALMP", StringUtil.LTrimStr( AV13SolicitudServicioComALMP, 18, 2));
         AssignAttri("", false, "AV14SolicitudServicioComPro", StringUtil.LTrimStr( AV14SolicitudServicioComPro, 18, 2));
         AssignAttri("", false, "AV15SolicitudServicioComProP", StringUtil.LTrimStr( AV15SolicitudServicioComProP, 6, 2));
         if ( new productosvarios(context).executeUdp(  AV16Solicitudes.gxTpr_Solicitudesid) > 1 )
         {
            new obtenercomiprodvarios(context ).execute(  AV16Solicitudes.gxTpr_Solicitudesid, out  AV12SolicitudServicioComALM, out  AV10SolicitudServicioComProv, out  AV14SolicitudServicioComPro) ;
            AssignAttri("", false, "AV12SolicitudServicioComALM", StringUtil.LTrimStr( AV12SolicitudServicioComALM, 18, 2));
            AssignAttri("", false, "AV10SolicitudServicioComProv", StringUtil.LTrimStr( AV10SolicitudServicioComProv, 18, 2));
            AssignAttri("", false, "AV14SolicitudServicioComPro", StringUtil.LTrimStr( AV14SolicitudServicioComPro, 18, 2));
            AV13SolicitudServicioComALMP = (decimal)((AV12SolicitudServicioComALM/ (decimal)(AV16Solicitudes.gxTpr_Solicitudserviciopfinal))*100);
            AssignAttri("", false, "AV13SolicitudServicioComALMP", StringUtil.LTrimStr( AV13SolicitudServicioComALMP, 18, 2));
            AV11SolicitudServicioComProvP = (decimal)((AV10SolicitudServicioComProv/ (decimal)(AV16Solicitudes.gxTpr_Solicitudserviciopfinal))*100);
            AssignAttri("", false, "AV11SolicitudServicioComProvP", StringUtil.LTrimStr( AV11SolicitudServicioComProvP, 6, 2));
            AV15SolicitudServicioComProP = (decimal)(100-(AV11SolicitudServicioComProvP+AV13SolicitudServicioComALMP));
            AssignAttri("", false, "AV15SolicitudServicioComProP", StringUtil.LTrimStr( AV15SolicitudServicioComProP, 6, 2));
         }
         /*  Sending Event outputs  */
      }

      protected void E13B72( )
      {
         /* 'DoGuardar' Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV44WWPContext) ;
         AV16Solicitudes.gxTpr_Solicitudesusractualizacion = AV44WWPContext.gxTpr_Userid;
         if ( AV12SolicitudServicioComALM > ( AV16Solicitudes.gxTpr_Solicitudserviciopfinal - AV16Solicitudes.gxTpr_Solicitudescostoxzona ) )
         {
            GX_msglist.addItem(context.GetMessage( "Atención: La comisión de almango no puede ser superior al precio final del la solicitud.", ""));
         }
         else
         {
            AV16Solicitudes.gxTpr_Solicitudserviciocomprov = AV10SolicitudServicioComProv;
            AV16Solicitudes.gxTpr_Solicitudserviciocomprovp = AV11SolicitudServicioComProvP;
            AV16Solicitudes.gxTpr_Solicitudserviciocomalm = AV12SolicitudServicioComALM;
            AV16Solicitudes.gxTpr_Solicitudserviciocomalmp = AV13SolicitudServicioComALMP;
            AV16Solicitudes.gxTpr_Solicitudescostoxzcomalm = AV29SolicitudServicioXZComALM;
            AV16Solicitudes.gxTpr_Solicitudescostoxzcomalmp = AV30SolicitudServicioXZComAlmP;
            AV16Solicitudes.Save();
            context.CommitDataStores("calcularcomisionwp",pr_default);
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "solicitudes.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(AV7SolicitudesID,18,0));
            CallWebObject(formatLink("solicitudes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV16Solicitudes", AV16Solicitudes);
      }

      protected void E14B72( )
      {
         /* 'DoCalcularComXZona' Routine */
         returnInSub = false;
         AV39SolicitudServicioXZona = AV16Solicitudes.gxTpr_Solicitudescostoxzona;
         AssignAttri("", false, "AV39SolicitudServicioXZona", StringUtil.LTrimStr( AV39SolicitudServicioXZona, 18, 2));
         GXt_decimal1 = AV30SolicitudServicioXZComAlmP;
         new ocomisionglobal(context ).execute( out  GXt_decimal1) ;
         AV30SolicitudServicioXZComAlmP = GXt_decimal1;
         AssignAttri("", false, "AV30SolicitudServicioXZComAlmP", StringUtil.LTrimStr( AV30SolicitudServicioXZComAlmP, 6, 2));
         AV29SolicitudServicioXZComALM = (decimal)(AV39SolicitudServicioXZona*(AV30SolicitudServicioXZComAlmP/ (decimal)(100)));
         AssignAttri("", false, "AV29SolicitudServicioXZComALM", StringUtil.LTrimStr( AV29SolicitudServicioXZComALM, 18, 2));
         /* Execute user subroutine: 'CALCULAR COMISIONCOSTO' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'CALCULAR COMISIONPROFESIONAL' Routine */
         returnInSub = false;
         if ( ( AV12SolicitudServicioComALM > Convert.ToDecimal( 0 )) )
         {
            AV14SolicitudServicioComPro = (decimal)((AV17SolicitudServicioPFinal-(AV10SolicitudServicioComProv+AV12SolicitudServicioComALM)));
            AssignAttri("", false, "AV14SolicitudServicioComPro", StringUtil.LTrimStr( AV14SolicitudServicioComPro, 18, 2));
            AV15SolicitudServicioComProP = (decimal)(100-(AV11SolicitudServicioComProvP+AV13SolicitudServicioComALMP));
            AssignAttri("", false, "AV15SolicitudServicioComProP", StringUtil.LTrimStr( AV15SolicitudServicioComProP, 6, 2));
         }
         else
         {
            AV14SolicitudServicioComPro = (decimal)((AV17SolicitudServicioPFinal+(AV10SolicitudServicioComProv+(AV12SolicitudServicioComALM*-1))));
            AssignAttri("", false, "AV14SolicitudServicioComPro", StringUtil.LTrimStr( AV14SolicitudServicioComPro, 18, 2));
            if ( ( AV13SolicitudServicioComALMP > Convert.ToDecimal( 0 )) )
            {
               AV15SolicitudServicioComProP = (decimal)(100+(AV11SolicitudServicioComProvP+AV13SolicitudServicioComALMP));
               AssignAttri("", false, "AV15SolicitudServicioComProP", StringUtil.LTrimStr( AV15SolicitudServicioComProP, 6, 2));
            }
            else
            {
               AV15SolicitudServicioComProP = (decimal)(100+(AV11SolicitudServicioComProvP+(AV13SolicitudServicioComALMP*-1)));
               AssignAttri("", false, "AV15SolicitudServicioComProP", StringUtil.LTrimStr( AV15SolicitudServicioComProP, 6, 2));
            }
         }
      }

      protected void S122( )
      {
         /* 'CALCULAR COMISIONCOSTO' Routine */
         returnInSub = false;
         AV31SolicitudServicioXZComProf = (decimal)((AV39SolicitudServicioXZona-AV29SolicitudServicioXZComALM));
         AssignAttri("", false, "AV31SolicitudServicioXZComProf", StringUtil.LTrimStr( AV31SolicitudServicioXZComProf, 18, 2));
         AV32SolicitudServicioXZComProfP = (decimal)(100-(AV30SolicitudServicioXZComAlmP));
         AssignAttri("", false, "AV32SolicitudServicioXZComProfP", StringUtil.LTrimStr( AV32SolicitudServicioXZComProfP, 6, 2));
      }

      protected void S142( )
      {
         /* 'CALCULAR SOLICITUDSERVICIOCOMPROV' Routine */
         returnInSub = false;
         if ( ( AV10SolicitudServicioComProv != AV21OldSolicitudServicioComProv ) && ! AV20SolicitudesCalComi )
         {
            AV21OldSolicitudServicioComProv = AV10SolicitudServicioComProv;
            AssignAttri("", false, "AV21OldSolicitudServicioComProv", StringUtil.LTrimStr( AV21OldSolicitudServicioComProv, 18, 2));
            if ( ( AV10SolicitudServicioComProv == Convert.ToDecimal( 0 )) )
            {
               AV11SolicitudServicioComProvP = 0;
               AssignAttri("", false, "AV11SolicitudServicioComProvP", StringUtil.LTrimStr( AV11SolicitudServicioComProvP, 6, 2));
            }
            else
            {
               if ( ( AV17SolicitudServicioPFinal > Convert.ToDecimal( 0 )) )
               {
                  AV11SolicitudServicioComProvP = (decimal)((AV10SolicitudServicioComProv/ (decimal)(AV17SolicitudServicioPFinal))*100);
                  AssignAttri("", false, "AV11SolicitudServicioComProvP", StringUtil.LTrimStr( AV11SolicitudServicioComProvP, 6, 2));
               }
               else
               {
                  AV11SolicitudServicioComProvP = 0;
                  AssignAttri("", false, "AV11SolicitudServicioComProvP", StringUtil.LTrimStr( AV11SolicitudServicioComProvP, 6, 2));
               }
            }
            AV22OldSolicitudServicioComProvP = AV11SolicitudServicioComProvP;
            AssignAttri("", false, "AV22OldSolicitudServicioComProvP", StringUtil.LTrimStr( AV22OldSolicitudServicioComProvP, 6, 2));
         }
         /* Execute user subroutine: 'CALCULAR COMISIONPROFESIONAL' */
         S112 ();
         if (returnInSub) return;
      }

      protected void S152( )
      {
         /* 'CALCULAR SOLICITUDSERVICIOCOMPROVP' Routine */
         returnInSub = false;
         if ( ( AV11SolicitudServicioComProvP != AV22OldSolicitudServicioComProvP ) && ! AV20SolicitudesCalComi )
         {
            AV22OldSolicitudServicioComProvP = AV11SolicitudServicioComProvP;
            AssignAttri("", false, "AV22OldSolicitudServicioComProvP", StringUtil.LTrimStr( AV22OldSolicitudServicioComProvP, 6, 2));
            if ( ( AV11SolicitudServicioComProvP > Convert.ToDecimal( 0 )) )
            {
               AV10SolicitudServicioComProv = (decimal)(AV17SolicitudServicioPFinal*(AV11SolicitudServicioComProvP/ (decimal)(100)));
               AssignAttri("", false, "AV10SolicitudServicioComProv", StringUtil.LTrimStr( AV10SolicitudServicioComProv, 18, 2));
            }
            else
            {
               AV10SolicitudServicioComProv = 0;
               AssignAttri("", false, "AV10SolicitudServicioComProv", StringUtil.LTrimStr( AV10SolicitudServicioComProv, 18, 2));
            }
            AV21OldSolicitudServicioComProv = AV10SolicitudServicioComProv;
            AssignAttri("", false, "AV21OldSolicitudServicioComProv", StringUtil.LTrimStr( AV21OldSolicitudServicioComProv, 18, 2));
         }
         /* Execute user subroutine: 'CALCULAR COMISIONPROFESIONAL' */
         S112 ();
         if (returnInSub) return;
      }

      protected void S162( )
      {
         /* 'CALCULAR SOLICITUDSERVICIOCOMALMP' Routine */
         returnInSub = false;
         if ( ( AV13SolicitudServicioComALMP != AV24OldSolicitudServicioComALMP ) && ! AV20SolicitudesCalComi )
         {
            AV24OldSolicitudServicioComALMP = AV13SolicitudServicioComALMP;
            AssignAttri("", false, "AV24OldSolicitudServicioComALMP", StringUtil.LTrimStr( AV24OldSolicitudServicioComALMP, 6, 2));
            if ( ( AV13SolicitudServicioComALMP > Convert.ToDecimal( 0 )) )
            {
               AV12SolicitudServicioComALM = (decimal)(AV17SolicitudServicioPFinal*(AV13SolicitudServicioComALMP/ (decimal)(100)));
               AssignAttri("", false, "AV12SolicitudServicioComALM", StringUtil.LTrimStr( AV12SolicitudServicioComALM, 18, 2));
            }
            else
            {
               AV12SolicitudServicioComALM = 0;
               AssignAttri("", false, "AV12SolicitudServicioComALM", StringUtil.LTrimStr( AV12SolicitudServicioComALM, 18, 2));
            }
            AV23OldSolicitudServicioComALM = AV12SolicitudServicioComALM;
            AssignAttri("", false, "AV23OldSolicitudServicioComALM", StringUtil.LTrimStr( AV23OldSolicitudServicioComALM, 18, 2));
         }
         /* Execute user subroutine: 'CALCULAR COMISIONPROFESIONAL' */
         S112 ();
         if (returnInSub) return;
      }

      protected void S182( )
      {
         /* 'CALCULAR SOLICITUDSERVICIOXZCOMALMP' Routine */
         returnInSub = false;
         if ( ( AV30SolicitudServicioXZComAlmP != AV45Oldsolicitudservicioxzcomalmp ) && ! AV20SolicitudesCalComi )
         {
            AV45Oldsolicitudservicioxzcomalmp = AV30SolicitudServicioXZComAlmP;
            AssignAttri("", false, "AV45Oldsolicitudservicioxzcomalmp", StringUtil.LTrimStr( AV45Oldsolicitudservicioxzcomalmp, 6, 2));
            if ( ( AV30SolicitudServicioXZComAlmP > Convert.ToDecimal( 0 )) )
            {
               AV29SolicitudServicioXZComALM = (decimal)(AV39SolicitudServicioXZona*(AV30SolicitudServicioXZComAlmP/ (decimal)(100)));
               AssignAttri("", false, "AV29SolicitudServicioXZComALM", StringUtil.LTrimStr( AV29SolicitudServicioXZComALM, 18, 2));
            }
            else
            {
               AV29SolicitudServicioXZComALM = 0;
               AssignAttri("", false, "AV29SolicitudServicioXZComALM", StringUtil.LTrimStr( AV29SolicitudServicioXZComALM, 18, 2));
            }
            AV38OldSolicitudServicioXZComAlm = AV29SolicitudServicioXZComALM;
            AssignAttri("", false, "AV38OldSolicitudServicioXZComAlm", StringUtil.LTrimStr( AV38OldSolicitudServicioXZComAlm, 18, 2));
         }
         AV31SolicitudServicioXZComProf = (decimal)((AV39SolicitudServicioXZona-AV29SolicitudServicioXZComALM));
         AssignAttri("", false, "AV31SolicitudServicioXZComProf", StringUtil.LTrimStr( AV31SolicitudServicioXZComProf, 18, 2));
         AV32SolicitudServicioXZComProfP = (decimal)(100-(AV30SolicitudServicioXZComAlmP));
         AssignAttri("", false, "AV32SolicitudServicioXZComProfP", StringUtil.LTrimStr( AV32SolicitudServicioXZComProfP, 6, 2));
      }

      protected void S192( )
      {
         /* 'CALCULAR SOLICITUDSERVICIOXZCOMALM' Routine */
         returnInSub = false;
         if ( ( AV29SolicitudServicioXZComALM != AV38OldSolicitudServicioXZComAlm ) && ! AV20SolicitudesCalComi )
         {
            AV38OldSolicitudServicioXZComAlm = AV29SolicitudServicioXZComALM;
            AssignAttri("", false, "AV38OldSolicitudServicioXZComAlm", StringUtil.LTrimStr( AV38OldSolicitudServicioXZComAlm, 18, 2));
            if ( ( AV29SolicitudServicioXZComALM > Convert.ToDecimal( 0 )) )
            {
               AV30SolicitudServicioXZComAlmP = (decimal)((AV29SolicitudServicioXZComALM/ (decimal)(AV39SolicitudServicioXZona))*100);
               AssignAttri("", false, "AV30SolicitudServicioXZComAlmP", StringUtil.LTrimStr( AV30SolicitudServicioXZComAlmP, 6, 2));
            }
            else
            {
               if ( ( AV29SolicitudServicioXZComALM == Convert.ToDecimal( 0 )) )
               {
                  AV30SolicitudServicioXZComAlmP = 0;
                  AssignAttri("", false, "AV30SolicitudServicioXZComAlmP", StringUtil.LTrimStr( AV30SolicitudServicioXZComAlmP, 6, 2));
               }
               else
               {
                  GX_msglist.addItem(context.GetMessage( "Atención: Su comisión es negativa, no se calculara el % de la perdida.", ""));
                  if ( ( AV39SolicitudServicioXZona > Convert.ToDecimal( 0 )) )
                  {
                     AV30SolicitudServicioXZComAlmP = 0;
                     AssignAttri("", false, "AV30SolicitudServicioXZComAlmP", StringUtil.LTrimStr( AV30SolicitudServicioXZComAlmP, 6, 2));
                  }
                  else
                  {
                  }
               }
            }
            AV45Oldsolicitudservicioxzcomalmp = AV30SolicitudServicioXZComAlmP;
            AssignAttri("", false, "AV45Oldsolicitudservicioxzcomalmp", StringUtil.LTrimStr( AV45Oldsolicitudservicioxzcomalmp, 6, 2));
         }
         AV31SolicitudServicioXZComProf = (decimal)((AV39SolicitudServicioXZona-AV29SolicitudServicioXZComALM));
         AssignAttri("", false, "AV31SolicitudServicioXZComProf", StringUtil.LTrimStr( AV31SolicitudServicioXZComProf, 18, 2));
         AV32SolicitudServicioXZComProfP = (decimal)(100-(AV30SolicitudServicioXZComAlmP));
         AssignAttri("", false, "AV32SolicitudServicioXZComProfP", StringUtil.LTrimStr( AV32SolicitudServicioXZComProfP, 6, 2));
      }

      protected void S172( )
      {
         /* 'CALCULAR SOLICITUDSERVICIOCOMALM' Routine */
         returnInSub = false;
         if ( ( AV12SolicitudServicioComALM != AV23OldSolicitudServicioComALM ) && ! AV20SolicitudesCalComi )
         {
            AV23OldSolicitudServicioComALM = AV12SolicitudServicioComALM;
            AssignAttri("", false, "AV23OldSolicitudServicioComALM", StringUtil.LTrimStr( AV23OldSolicitudServicioComALM, 18, 2));
            if ( ( AV12SolicitudServicioComALM > Convert.ToDecimal( 0 )) )
            {
               AV13SolicitudServicioComALMP = (decimal)((AV12SolicitudServicioComALM/ (decimal)(AV17SolicitudServicioPFinal))*100);
               AssignAttri("", false, "AV13SolicitudServicioComALMP", StringUtil.LTrimStr( AV13SolicitudServicioComALMP, 18, 2));
            }
            else
            {
               if ( ( AV12SolicitudServicioComALM == Convert.ToDecimal( 0 )) )
               {
                  AV13SolicitudServicioComALMP = 0;
                  AssignAttri("", false, "AV13SolicitudServicioComALMP", StringUtil.LTrimStr( AV13SolicitudServicioComALMP, 18, 2));
               }
               else
               {
                  GX_msglist.addItem(context.GetMessage( "Atención: Su comisión es negativa, no se calculara el % de la perdida.", ""));
                  if ( ( AV17SolicitudServicioPFinal > Convert.ToDecimal( 0 )) )
                  {
                     AV13SolicitudServicioComALMP = 0;
                     AssignAttri("", false, "AV13SolicitudServicioComALMP", StringUtil.LTrimStr( AV13SolicitudServicioComALMP, 18, 2));
                  }
                  else
                  {
                     AV13SolicitudServicioComALMP = 0;
                     AssignAttri("", false, "AV13SolicitudServicioComALMP", StringUtil.LTrimStr( AV13SolicitudServicioComALMP, 18, 2));
                  }
               }
            }
            AV24OldSolicitudServicioComALMP = AV13SolicitudServicioComALMP;
            AssignAttri("", false, "AV24OldSolicitudServicioComALMP", StringUtil.LTrimStr( AV24OldSolicitudServicioComALMP, 6, 2));
         }
         /* Execute user subroutine: 'CALCULAR COMISIONPROFESIONAL' */
         S112 ();
         if (returnInSub) return;
      }

      protected void S132( )
      {
         /* 'SUBGUARDAR' Routine */
         returnInSub = false;
         if ( AV12SolicitudServicioComALM > ( AV16Solicitudes.gxTpr_Solicitudserviciopfinal - AV16Solicitudes.gxTpr_Solicitudescostoxzona ) )
         {
            GX_msglist.addItem(context.GetMessage( "Atención: La comisión de almango no puede ser superior al precio final del la solicitud.", ""));
         }
         else
         {
            AV16Solicitudes.gxTpr_Solicitudserviciocomprov = AV10SolicitudServicioComProv;
            AV16Solicitudes.gxTpr_Solicitudserviciocomprovp = AV11SolicitudServicioComProvP;
            AV16Solicitudes.gxTpr_Solicitudserviciocomalm = AV12SolicitudServicioComALM;
            AV16Solicitudes.gxTpr_Solicitudserviciocomalmp = AV13SolicitudServicioComALMP;
            AV16Solicitudes.gxTpr_Solicitudescostoxzcomalm = AV29SolicitudServicioXZComALM;
            AV16Solicitudes.gxTpr_Solicitudescostoxzcomalmp = AV30SolicitudServicioXZComAlmP;
            AV16Solicitudes.Save();
            context.CommitDataStores("calcularcomisionwp",pr_default);
            CallWebObject(formatLink("solicitudesww.aspx") );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E15B72( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV7SolicitudesID = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV7SolicitudesID", StringUtil.LTrimStr( (decimal)(AV7SolicitudesID), 18, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"), context));
         AV26CambioPrecio = (bool)getParm(obj,1);
         AssignAttri("", false, "AV26CambioPrecio", AV26CambioPrecio);
         GxWebStd.gx_hidden_field( context, "gxhash_vCAMBIOPRECIO", GetSecureSignedToken( "", AV26CambioPrecio, context));
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
         PAB72( ) ;
         WSB72( ) ;
         WEB72( ) ;
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
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20261061563515", true, true, false);
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
         context.AddJavascriptSource("calcularcomisionwp.js", "?20261061563515", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         chkavSolicitudescalcomi.Name = "vSOLICITUDESCALCOMI";
         chkavSolicitudescalcomi.WebTags = "";
         chkavSolicitudescalcomi.Caption = context.GetMessage( "Calcular Comisión", "");
         AssignProp("", false, chkavSolicitudescalcomi_Internalname, "TitleCaption", chkavSolicitudescalcomi.Caption, true);
         chkavSolicitudescalcomi.CheckedValue = "false";
         AV20SolicitudesCalComi = StringUtil.StrToBool( StringUtil.BoolToStr( AV20SolicitudesCalComi));
         AssignAttri("", false, "AV20SolicitudesCalComi", AV20SolicitudesCalComi);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavSolicitudesid_Internalname = "vSOLICITUDESID";
         edtavSolicitudesnombre_Internalname = "vSOLICITUDESNOMBRE";
         edtavSolicitudserviciopfinal_Internalname = "vSOLICITUDSERVICIOPFINAL";
         edtavCostoxzona_Internalname = "vCOSTOXZONA";
         edtavTotal_Internalname = "vTOTAL";
         chkavSolicitudescalcomi_Internalname = "vSOLICITUDESCALCOMI";
         bttBtnbtncalcular_Internalname = "BTNBTNCALCULAR";
         edtavSolicitudserviciocomprov_Internalname = "vSOLICITUDSERVICIOCOMPROV";
         edtavSolicitudserviciocomprovp_Internalname = "vSOLICITUDSERVICIOCOMPROVP";
         edtavSolicitudserviciocomalm_Internalname = "vSOLICITUDSERVICIOCOMALM";
         edtavSolicitudserviciocomalmp_Internalname = "vSOLICITUDSERVICIOCOMALMP";
         edtavSolicitudserviciocompro_Internalname = "vSOLICITUDSERVICIOCOMPRO";
         edtavSolicitudserviciocomprop_Internalname = "vSOLICITUDSERVICIOCOMPROP";
         divCalcom_Internalname = "CALCOM";
         Dvpanel_calcom_Internalname = "DVPANEL_CALCOM";
         edtavSolicitudservicioxzona_Internalname = "vSOLICITUDSERVICIOXZONA";
         edtavSolicitudservicioxzcomalm_Internalname = "vSOLICITUDSERVICIOXZCOMALM";
         edtavSolicitudservicioxzcomalmp_Internalname = "vSOLICITUDSERVICIOXZCOMALMP";
         edtavSolicitudservicioxzcomprof_Internalname = "vSOLICITUDSERVICIOXZCOMPROF";
         edtavSolicitudservicioxzcomprofp_Internalname = "vSOLICITUDSERVICIOXZCOMPROFP";
         bttBtncalcularcomxzona_Internalname = "BTNCALCULARCOMXZONA";
         divPanelcostoxzona_Internalname = "PANELCOSTOXZONA";
         Dvpanel_panelcostoxzona_Internalname = "DVPANEL_PANELCOSTOXZONA";
         bttBtnguardar_Internalname = "BTNGUARDAR";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtavSolicitudservicioxzonap_Internalname = "vSOLICITUDSERVICIOXZONAP";
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
         chkavSolicitudescalcomi.Caption = context.GetMessage( "Calcular Comisión", "");
         edtavSolicitudservicioxzonap_Jsonclick = "";
         edtavSolicitudservicioxzonap_Visible = 1;
         edtavSolicitudservicioxzcomprofp_Jsonclick = "";
         edtavSolicitudservicioxzcomprofp_Enabled = 1;
         edtavSolicitudservicioxzcomprof_Jsonclick = "";
         edtavSolicitudservicioxzcomprof_Enabled = 1;
         edtavSolicitudservicioxzcomalmp_Jsonclick = "";
         edtavSolicitudservicioxzcomalmp_Enabled = 1;
         edtavSolicitudservicioxzcomalm_Jsonclick = "";
         edtavSolicitudservicioxzcomalm_Enabled = 1;
         edtavSolicitudservicioxzona_Jsonclick = "";
         edtavSolicitudservicioxzona_Enabled = 1;
         edtavSolicitudserviciocomprop_Jsonclick = "";
         edtavSolicitudserviciocomprop_Enabled = 1;
         edtavSolicitudserviciocompro_Jsonclick = "";
         edtavSolicitudserviciocompro_Enabled = 1;
         edtavSolicitudserviciocomalmp_Jsonclick = "";
         edtavSolicitudserviciocomalmp_Enabled = 1;
         edtavSolicitudserviciocomalm_Jsonclick = "";
         edtavSolicitudserviciocomalm_Enabled = 1;
         edtavSolicitudserviciocomprovp_Jsonclick = "";
         edtavSolicitudserviciocomprovp_Enabled = 1;
         edtavSolicitudserviciocomprov_Jsonclick = "";
         edtavSolicitudserviciocomprov_Enabled = 1;
         bttBtnbtncalcular_Visible = 1;
         chkavSolicitudescalcomi.Enabled = 1;
         edtavTotal_Jsonclick = "";
         edtavTotal_Enabled = 1;
         edtavCostoxzona_Jsonclick = "";
         edtavCostoxzona_Enabled = 1;
         edtavSolicitudserviciopfinal_Jsonclick = "";
         edtavSolicitudserviciopfinal_Enabled = 1;
         edtavSolicitudesnombre_Jsonclick = "";
         edtavSolicitudesnombre_Enabled = 1;
         edtavSolicitudesid_Jsonclick = "";
         edtavSolicitudesid_Enabled = 0;
         Dvpanel_panelcostoxzona_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_panelcostoxzona_Iconposition = "Right";
         Dvpanel_panelcostoxzona_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_panelcostoxzona_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_panelcostoxzona_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_panelcostoxzona_Title = context.GetMessage( "Comisión Costo por Zona", "");
         Dvpanel_panelcostoxzona_Cls = "PanelGrayBackgroundTitle";
         Dvpanel_panelcostoxzona_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_panelcostoxzona_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_panelcostoxzona_Width = "100%";
         Dvpanel_calcom_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_calcom_Iconposition = "Right";
         Dvpanel_calcom_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_calcom_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_calcom_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_calcom_Title = context.GetMessage( "Calculo de Comisiones", "");
         Dvpanel_calcom_Cls = "PanelGrayBackgroundTitle";
         Dvpanel_calcom_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_calcom_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_calcom_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Calcular Comision WP", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV20SolicitudesCalComi',fld:'vSOLICITUDESCALCOMI',pic:'',type:'boolean'},{av:'AV18ProFesionalesID',fld:'vPROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'AV26CambioPrecio',fld:'vCAMBIOPRECIO',pic:'',hsh:true,type:'boolean'},{av:'AV7SolicitudesID',fld:'vSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV17SolicitudServicioPFinal',fld:'vSOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',hsh:true,type:'decimal'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOBTNCALCULAR'","{handler:'E12B72',iparms:[{av:'AV7SolicitudesID',fld:'vSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV18ProFesionalesID',fld:'vPROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'AV16Solicitudes',fld:'vSOLICITUDES',pic:''}]");
         setEventMetadata("'DOBTNCALCULAR'",",oparms:[{av:'AV15SolicitudServicioComProP',fld:'vSOLICITUDSERVICIOCOMPROP',pic:'ZZ9.99',type:'decimal'},{av:'AV14SolicitudServicioComPro',fld:'vSOLICITUDSERVICIOCOMPRO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV13SolicitudServicioComALMP',fld:'vSOLICITUDSERVICIOCOMALMP',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV12SolicitudServicioComALM',fld:'vSOLICITUDSERVICIOCOMALM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV11SolicitudServicioComProvP',fld:'vSOLICITUDSERVICIOCOMPROVP',pic:'ZZ9.99',type:'decimal'},{av:'AV10SolicitudServicioComProv',fld:'vSOLICITUDSERVICIOCOMPROV',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'}]}");
         setEventMetadata("'DOGUARDAR'","{handler:'E13B72',iparms:[{av:'AV16Solicitudes',fld:'vSOLICITUDES',pic:''},{av:'AV12SolicitudServicioComALM',fld:'vSOLICITUDSERVICIOCOMALM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV10SolicitudServicioComProv',fld:'vSOLICITUDSERVICIOCOMPROV',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV11SolicitudServicioComProvP',fld:'vSOLICITUDSERVICIOCOMPROVP',pic:'ZZ9.99',type:'decimal'},{av:'AV13SolicitudServicioComALMP',fld:'vSOLICITUDSERVICIOCOMALMP',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV29SolicitudServicioXZComALM',fld:'vSOLICITUDSERVICIOXZCOMALM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV30SolicitudServicioXZComAlmP',fld:'vSOLICITUDSERVICIOXZCOMALMP',pic:'ZZ9.99',type:'decimal'},{av:'AV7SolicitudesID',fld:'vSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'DOGUARDAR'",",oparms:[{av:'AV16Solicitudes',fld:'vSOLICITUDES',pic:''}]}");
         setEventMetadata("'DOCALCULARCOMXZONA'","{handler:'E14B72',iparms:[{av:'AV16Solicitudes',fld:'vSOLICITUDES',pic:''},{av:'AV39SolicitudServicioXZona',fld:'vSOLICITUDSERVICIOXZONA',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV29SolicitudServicioXZComALM',fld:'vSOLICITUDSERVICIOXZCOMALM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV30SolicitudServicioXZComAlmP',fld:'vSOLICITUDSERVICIOXZCOMALMP',pic:'ZZ9.99',type:'decimal'}]");
         setEventMetadata("'DOCALCULARCOMXZONA'",",oparms:[{av:'AV39SolicitudServicioXZona',fld:'vSOLICITUDSERVICIOXZONA',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV30SolicitudServicioXZComAlmP',fld:'vSOLICITUDSERVICIOXZCOMALMP',pic:'ZZ9.99',type:'decimal'},{av:'AV29SolicitudServicioXZComALM',fld:'vSOLICITUDSERVICIOXZCOMALM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV31SolicitudServicioXZComProf',fld:'vSOLICITUDSERVICIOXZCOMPROF',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV32SolicitudServicioXZComProfP',fld:'vSOLICITUDSERVICIOXZCOMPROFP',pic:'ZZ9.99',type:'decimal'}]}");
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
         GXEncryptionTmp = "";
         AV18ProFesionalesID = "";
         forbiddenHiddens = new GXProperties();
         AV16Solicitudes = new SdtSolicitudes(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV8SolicitudesNombre = "";
         bttBtnbtncalcular_Jsonclick = "";
         ucDvpanel_calcom = new GXUserControl();
         ucDvpanel_panelcostoxzona = new GXUserControl();
         bttBtncalcularcomxzona_Jsonclick = "";
         bttBtnguardar_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         hsh = "";
         AV42WebSession = context.GetSession();
         AV44WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.calcularcomisionwp__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.calcularcomisionwp__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         edtavSolicitudesid_Enabled = 0;
         edtavSolicitudesnombre_Enabled = 0;
         edtavSolicitudserviciopfinal_Enabled = 0;
         edtavCostoxzona_Enabled = 0;
         edtavTotal_Enabled = 0;
         edtavSolicitudserviciocomprov_Enabled = 0;
         edtavSolicitudserviciocompro_Enabled = 0;
         edtavSolicitudserviciocomprop_Enabled = 0;
         edtavSolicitudservicioxzona_Enabled = 0;
         edtavSolicitudservicioxzcomprof_Enabled = 0;
         edtavSolicitudservicioxzcomprofp_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int edtavSolicitudesid_Enabled ;
      private int edtavSolicitudesnombre_Enabled ;
      private int edtavSolicitudserviciopfinal_Enabled ;
      private int edtavCostoxzona_Enabled ;
      private int edtavTotal_Enabled ;
      private int bttBtnbtncalcular_Visible ;
      private int edtavSolicitudserviciocomprov_Enabled ;
      private int edtavSolicitudserviciocomprovp_Enabled ;
      private int edtavSolicitudserviciocomalm_Enabled ;
      private int edtavSolicitudserviciocomalmp_Enabled ;
      private int edtavSolicitudserviciocompro_Enabled ;
      private int edtavSolicitudserviciocomprop_Enabled ;
      private int edtavSolicitudservicioxzona_Enabled ;
      private int edtavSolicitudservicioxzcomalm_Enabled ;
      private int edtavSolicitudservicioxzcomalmp_Enabled ;
      private int edtavSolicitudservicioxzcomprof_Enabled ;
      private int edtavSolicitudservicioxzcomprofp_Enabled ;
      private int edtavSolicitudservicioxzonap_Visible ;
      private int idxLst ;
      private long AV7SolicitudesID ;
      private long wcpOAV7SolicitudesID ;
      private decimal AV17SolicitudServicioPFinal ;
      private decimal AV21OldSolicitudServicioComProv ;
      private decimal AV22OldSolicitudServicioComProvP ;
      private decimal AV24OldSolicitudServicioComALMP ;
      private decimal AV23OldSolicitudServicioComALM ;
      private decimal AV45Oldsolicitudservicioxzcomalmp ;
      private decimal AV38OldSolicitudServicioXZComAlm ;
      private decimal AV35CostoXZona ;
      private decimal AV34Total ;
      private decimal AV10SolicitudServicioComProv ;
      private decimal AV11SolicitudServicioComProvP ;
      private decimal AV12SolicitudServicioComALM ;
      private decimal AV13SolicitudServicioComALMP ;
      private decimal AV14SolicitudServicioComPro ;
      private decimal AV15SolicitudServicioComProP ;
      private decimal AV39SolicitudServicioXZona ;
      private decimal AV29SolicitudServicioXZComALM ;
      private decimal AV30SolicitudServicioXZComAlmP ;
      private decimal AV31SolicitudServicioXZComProf ;
      private decimal AV32SolicitudServicioXZComProfP ;
      private decimal AV40SolicitudServicioXZonaP ;
      private decimal GXt_decimal1 ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV18ProFesionalesID ;
      private string Dvpanel_calcom_Width ;
      private string Dvpanel_calcom_Cls ;
      private string Dvpanel_calcom_Title ;
      private string Dvpanel_calcom_Iconposition ;
      private string Dvpanel_panelcostoxzona_Width ;
      private string Dvpanel_panelcostoxzona_Cls ;
      private string Dvpanel_panelcostoxzona_Title ;
      private string Dvpanel_panelcostoxzona_Iconposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string edtavSolicitudesid_Internalname ;
      private string TempTags ;
      private string edtavSolicitudesid_Jsonclick ;
      private string edtavSolicitudesnombre_Internalname ;
      private string AV8SolicitudesNombre ;
      private string edtavSolicitudesnombre_Jsonclick ;
      private string edtavSolicitudserviciopfinal_Internalname ;
      private string edtavSolicitudserviciopfinal_Jsonclick ;
      private string edtavCostoxzona_Internalname ;
      private string edtavCostoxzona_Jsonclick ;
      private string edtavTotal_Internalname ;
      private string edtavTotal_Jsonclick ;
      private string chkavSolicitudescalcomi_Internalname ;
      private string bttBtnbtncalcular_Internalname ;
      private string bttBtnbtncalcular_Jsonclick ;
      private string Dvpanel_calcom_Internalname ;
      private string divCalcom_Internalname ;
      private string edtavSolicitudserviciocomprov_Internalname ;
      private string edtavSolicitudserviciocomprov_Jsonclick ;
      private string edtavSolicitudserviciocomprovp_Internalname ;
      private string edtavSolicitudserviciocomprovp_Jsonclick ;
      private string edtavSolicitudserviciocomalm_Internalname ;
      private string edtavSolicitudserviciocomalm_Jsonclick ;
      private string edtavSolicitudserviciocomalmp_Internalname ;
      private string edtavSolicitudserviciocomalmp_Jsonclick ;
      private string edtavSolicitudserviciocompro_Internalname ;
      private string edtavSolicitudserviciocompro_Jsonclick ;
      private string edtavSolicitudserviciocomprop_Internalname ;
      private string edtavSolicitudserviciocomprop_Jsonclick ;
      private string Dvpanel_panelcostoxzona_Internalname ;
      private string divPanelcostoxzona_Internalname ;
      private string edtavSolicitudservicioxzona_Internalname ;
      private string edtavSolicitudservicioxzona_Jsonclick ;
      private string edtavSolicitudservicioxzcomalm_Internalname ;
      private string edtavSolicitudservicioxzcomalm_Jsonclick ;
      private string edtavSolicitudservicioxzcomalmp_Internalname ;
      private string edtavSolicitudservicioxzcomalmp_Jsonclick ;
      private string edtavSolicitudservicioxzcomprof_Internalname ;
      private string edtavSolicitudservicioxzcomprof_Jsonclick ;
      private string edtavSolicitudservicioxzcomprofp_Internalname ;
      private string edtavSolicitudservicioxzcomprofp_Jsonclick ;
      private string bttBtncalcularcomxzona_Internalname ;
      private string bttBtncalcularcomxzona_Jsonclick ;
      private string bttBtnguardar_Internalname ;
      private string bttBtnguardar_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavSolicitudservicioxzonap_Internalname ;
      private string edtavSolicitudservicioxzonap_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string hsh ;
      private bool AV26CambioPrecio ;
      private bool wcpOAV26CambioPrecio ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_calcom_Autowidth ;
      private bool Dvpanel_calcom_Autoheight ;
      private bool Dvpanel_calcom_Collapsible ;
      private bool Dvpanel_calcom_Collapsed ;
      private bool Dvpanel_calcom_Showcollapseicon ;
      private bool Dvpanel_calcom_Autoscroll ;
      private bool Dvpanel_panelcostoxzona_Autowidth ;
      private bool Dvpanel_panelcostoxzona_Autoheight ;
      private bool Dvpanel_panelcostoxzona_Collapsible ;
      private bool Dvpanel_panelcostoxzona_Collapsed ;
      private bool Dvpanel_panelcostoxzona_Showcollapseicon ;
      private bool Dvpanel_panelcostoxzona_Autoscroll ;
      private bool wbLoad ;
      private bool AV20SolicitudesCalComi ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private IGxSession AV42WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_calcom ;
      private GXUserControl ucDvpanel_panelcostoxzona ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavSolicitudescalcomi ;
      private SdtSolicitudes AV16Solicitudes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV44WWPContext ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class calcularcomisionwp__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class calcularcomisionwp__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
