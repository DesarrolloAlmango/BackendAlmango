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
   public class listaagrupacionwp : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public listaagrupacionwp( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public listaagrupacionwp( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref long aP0_ListaId ,
                           ref long aP1_ProveedorID ,
                           ref string aP2_ProfesionalesId ,
                           ref string aP3_AgrupacionEstadoAux )
      {
         this.AV7ListaId = aP0_ListaId;
         this.AV6ProveedorID = aP1_ProveedorID;
         this.AV5ProfesionalesId = aP2_ProfesionalesId;
         this.AV10AgrupacionEstadoAux = aP3_AgrupacionEstadoAux;
         ExecutePrivate();
         aP0_ListaId=this.AV7ListaId;
         aP1_ProveedorID=this.AV6ProveedorID;
         aP2_ProfesionalesId=this.AV5ProfesionalesId;
         aP3_AgrupacionEstadoAux=this.AV10AgrupacionEstadoAux;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavAgrupacionestado = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "ListaId");
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
               gxfirstwebparm = GetFirstPar( "ListaId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "ListaId");
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
         PABS2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTBS2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true, false);
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
         GXEncryptionTmp = "listaagrupacionwp.aspx"+UrlEncode(StringUtil.LTrimStr(AV7ListaId,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV6ProveedorID,18,0)) + "," + UrlEncode(StringUtil.RTrim(AV5ProfesionalesId)) + "," + UrlEncode(StringUtil.RTrim(AV10AgrupacionEstadoAux));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("listaagrupacionwp.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vAGRUPACIONESTADOAUX", StringUtil.RTrim( AV10AgrupacionEstadoAux));
         GxWebStd.gx_hidden_field( context, "gxhash_vAGRUPACIONESTADOAUX", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10AgrupacionEstadoAux, "")), context));
         GxWebStd.gx_hidden_field( context, "vPROFESIONALESID", StringUtil.RTrim( AV5ProfesionalesId));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROFESIONALESID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5ProfesionalesId, "")), context));
         GxWebStd.gx_hidden_field( context, "vPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6ProveedorID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vLISTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ListaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLISTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ListaId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vAGRUPACIONESTADOAUX", StringUtil.RTrim( AV10AgrupacionEstadoAux));
         GxWebStd.gx_hidden_field( context, "gxhash_vAGRUPACIONESTADOAUX", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10AgrupacionEstadoAux, "")), context));
         GxWebStd.gx_hidden_field( context, "vPROFESIONALESID", StringUtil.RTrim( AV5ProfesionalesId));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROFESIONALESID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5ProfesionalesId, "")), context));
         GxWebStd.gx_hidden_field( context, "vPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6ProveedorID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vLISTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ListaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLISTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ListaId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "DVPANEL_MAINTABLE_Width", StringUtil.RTrim( Dvpanel_maintable_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_MAINTABLE_Autowidth", StringUtil.BoolToStr( Dvpanel_maintable_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_MAINTABLE_Autoheight", StringUtil.BoolToStr( Dvpanel_maintable_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_MAINTABLE_Cls", StringUtil.RTrim( Dvpanel_maintable_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_MAINTABLE_Title", StringUtil.RTrim( Dvpanel_maintable_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_MAINTABLE_Collapsible", StringUtil.BoolToStr( Dvpanel_maintable_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_MAINTABLE_Collapsed", StringUtil.BoolToStr( Dvpanel_maintable_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_MAINTABLE_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_maintable_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_MAINTABLE_Iconposition", StringUtil.RTrim( Dvpanel_maintable_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_MAINTABLE_Autoscroll", StringUtil.BoolToStr( Dvpanel_maintable_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNCONFIRMAR_Title", StringUtil.RTrim( Dvelop_confirmpanel_btnconfirmar_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNCONFIRMAR_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_btnconfirmar_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNCONFIRMAR_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_btnconfirmar_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNCONFIRMAR_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_btnconfirmar_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNCONFIRMAR_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_btnconfirmar_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNCONFIRMAR_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_btnconfirmar_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNCONFIRMAR_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_btnconfirmar_Confirmtype));
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
            WEBS2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTBS2( ) ;
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
         GXEncryptionTmp = "listaagrupacionwp.aspx"+UrlEncode(StringUtil.LTrimStr(AV7ListaId,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV6ProveedorID,18,0)) + "," + UrlEncode(StringUtil.RTrim(AV5ProfesionalesId)) + "," + UrlEncode(StringUtil.RTrim(AV10AgrupacionEstadoAux));
         return formatLink("listaagrupacionwp.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "ListaAgrupacionWP" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Lista", "") ;
      }

      protected void WBBS0( )
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
            /* User Defined Control */
            ucDvpanel_maintable.SetProperty("Width", Dvpanel_maintable_Width);
            ucDvpanel_maintable.SetProperty("AutoWidth", Dvpanel_maintable_Autowidth);
            ucDvpanel_maintable.SetProperty("AutoHeight", Dvpanel_maintable_Autoheight);
            ucDvpanel_maintable.SetProperty("Cls", Dvpanel_maintable_Cls);
            ucDvpanel_maintable.SetProperty("Title", Dvpanel_maintable_Title);
            ucDvpanel_maintable.SetProperty("Collapsible", Dvpanel_maintable_Collapsible);
            ucDvpanel_maintable.SetProperty("Collapsed", Dvpanel_maintable_Collapsed);
            ucDvpanel_maintable.SetProperty("ShowCollapseIcon", Dvpanel_maintable_Showcollapseicon);
            ucDvpanel_maintable.SetProperty("IconPosition", Dvpanel_maintable_Iconposition);
            ucDvpanel_maintable.SetProperty("AutoScroll", Dvpanel_maintable_Autoscroll);
            ucDvpanel_maintable.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_maintable_Internalname, "DVPANEL_MAINTABLEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_MAINTABLEContainer"+"MainTable"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 11,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancelar_Internalname, "", context.GetMessage( "Cancelar", ""), bttBtncancelar_Jsonclick, 5, context.GetMessage( "Cancelar", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOCANCELAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ListaAgrupacionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavAgrupacionestado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavAgrupacionestado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavAgrupacionestado, cmbavAgrupacionestado_Internalname, StringUtil.RTrim( AV9AgrupacionEstado), 1, cmbavAgrupacionestado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavAgrupacionestado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,15);\"", "", true, 0, "HLP_ListaAgrupacionWP.htm");
            cmbavAgrupacionestado.CurrentValue = StringUtil.RTrim( AV9AgrupacionEstado);
            AssignProp("", false, cmbavAgrupacionestado_Internalname, "Values", (string)(cmbavAgrupacionestado.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnconfirmar_Internalname, "", context.GetMessage( "Confirmar", ""), bttBtnconfirmar_Jsonclick, 7, context.GetMessage( "Confirmar", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e11bs1_client"+"'", TempTags, "", 2, "HLP_ListaAgrupacionWP.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            wb_table1_21_BS2( true) ;
         }
         else
         {
            wb_table1_21_BS2( false) ;
         }
         return  ;
      }

      protected void wb_table1_21_BS2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void STARTBS2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Lista", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPBS0( ) ;
      }

      protected void WSBS2( )
      {
         STARTBS2( ) ;
         EVTBS2( ) ;
      }

      protected void EVTBS2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_BTNCONFIRMAR.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_btnconfirmar.Close */
                              E12BS2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E13BS2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCANCELAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoCancelar' */
                              E14BS2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E15BS2 ();
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

      protected void WEBS2( )
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

      protected void PABS2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "listaagrupacionwp.aspx")), "listaagrupacionwp.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "listaagrupacionwp.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "ListaId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV7ListaId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV7ListaId", StringUtil.LTrimStr( (decimal)(AV7ListaId), 18, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vLISTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ListaId), "ZZZZZZZZZZZZZZZZZ9"), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV6ProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "ProveedorID"), "."), 18, MidpointRounding.ToEven));
                        AssignAttri("", false, "AV6ProveedorID", StringUtil.LTrimStr( (decimal)(AV6ProveedorID), 18, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6ProveedorID), "ZZZZZZZZZZZZZZZZZ9"), context));
                        AV5ProfesionalesId = GetPar( "ProfesionalesId");
                        AssignAttri("", false, "AV5ProfesionalesId", AV5ProfesionalesId);
                        GxWebStd.gx_hidden_field( context, "gxhash_vPROFESIONALESID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5ProfesionalesId, "")), context));
                        AV10AgrupacionEstadoAux = GetPar( "AgrupacionEstadoAux");
                        AssignAttri("", false, "AV10AgrupacionEstadoAux", AV10AgrupacionEstadoAux);
                        GxWebStd.gx_hidden_field( context, "gxhash_vAGRUPACIONESTADOAUX", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10AgrupacionEstadoAux, "")), context));
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
               GX_FocusControl = cmbavAgrupacionestado_Internalname;
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
         if ( cmbavAgrupacionestado.ItemCount > 0 )
         {
            AV9AgrupacionEstado = cmbavAgrupacionestado.getValidValue(AV9AgrupacionEstado);
            AssignAttri("", false, "AV9AgrupacionEstado", AV9AgrupacionEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavAgrupacionestado.CurrentValue = StringUtil.RTrim( AV9AgrupacionEstado);
            AssignProp("", false, cmbavAgrupacionestado_Internalname, "Values", cmbavAgrupacionestado.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFBS2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFBS2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E15BS2 ();
            WBBS0( ) ;
         }
      }

      protected void send_integrity_lvl_hashesBS2( )
      {
         GxWebStd.gx_hidden_field( context, "vAGRUPACIONESTADOAUX", StringUtil.RTrim( AV10AgrupacionEstadoAux));
         GxWebStd.gx_hidden_field( context, "gxhash_vAGRUPACIONESTADOAUX", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10AgrupacionEstadoAux, "")), context));
         GxWebStd.gx_hidden_field( context, "vPROFESIONALESID", StringUtil.RTrim( AV5ProfesionalesId));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROFESIONALESID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5ProfesionalesId, "")), context));
         GxWebStd.gx_hidden_field( context, "vPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6ProveedorID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vLISTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ListaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLISTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ListaId), "ZZZZZZZZZZZZZZZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUPBS0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E13BS2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Dvpanel_maintable_Width = cgiGet( "DVPANEL_MAINTABLE_Width");
            Dvpanel_maintable_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_MAINTABLE_Autowidth"));
            Dvpanel_maintable_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_MAINTABLE_Autoheight"));
            Dvpanel_maintable_Cls = cgiGet( "DVPANEL_MAINTABLE_Cls");
            Dvpanel_maintable_Title = cgiGet( "DVPANEL_MAINTABLE_Title");
            Dvpanel_maintable_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_MAINTABLE_Collapsible"));
            Dvpanel_maintable_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_MAINTABLE_Collapsed"));
            Dvpanel_maintable_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_MAINTABLE_Showcollapseicon"));
            Dvpanel_maintable_Iconposition = cgiGet( "DVPANEL_MAINTABLE_Iconposition");
            Dvpanel_maintable_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_MAINTABLE_Autoscroll"));
            Dvelop_confirmpanel_btnconfirmar_Title = cgiGet( "DVELOP_CONFIRMPANEL_BTNCONFIRMAR_Title");
            Dvelop_confirmpanel_btnconfirmar_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_BTNCONFIRMAR_Confirmationtext");
            Dvelop_confirmpanel_btnconfirmar_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_BTNCONFIRMAR_Yesbuttoncaption");
            Dvelop_confirmpanel_btnconfirmar_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_BTNCONFIRMAR_Nobuttoncaption");
            Dvelop_confirmpanel_btnconfirmar_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_BTNCONFIRMAR_Cancelbuttoncaption");
            Dvelop_confirmpanel_btnconfirmar_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_BTNCONFIRMAR_Yesbuttonposition");
            Dvelop_confirmpanel_btnconfirmar_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_BTNCONFIRMAR_Confirmtype");
            /* Read variables values. */
            cmbavAgrupacionestado.CurrentValue = cgiGet( cmbavAgrupacionestado_Internalname);
            AV9AgrupacionEstado = cgiGet( cmbavAgrupacionestado_Internalname);
            AssignAttri("", false, "AV9AgrupacionEstado", AV9AgrupacionEstado);
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
         E13BS2 ();
         if (returnInSub) return;
      }

      protected void E13BS2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV9AgrupacionEstado = AV10AgrupacionEstadoAux;
         AssignAttri("", false, "AV9AgrupacionEstado", AV9AgrupacionEstado);
      }

      protected void E14BS2( )
      {
         /* 'DoCancelar' Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {(long)AV7ListaId,(long)AV6ProveedorID,(string)AV5ProfesionalesId,(string)AV10AgrupacionEstadoAux});
         context.setWebReturnParmsMetadata(new Object[] {"AV7ListaId","AV6ProveedorID","AV5ProfesionalesId","AV10AgrupacionEstadoAux"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E12BS2( )
      {
         /* Dvelop_confirmpanel_btnconfirmar_Close Routine */
         returnInSub = false;
         new aestadoprofesional(context ).execute(  AV7ListaId,  AV6ProveedorID,  AV5ProfesionalesId,  AV9AgrupacionEstado) ;
         GX_msglist.addItem(context.GetMessage( "Proceso Completado, desea procesar otro cambio?", ""));
         context.setWebReturnParms(new Object[] {(long)AV7ListaId,(long)AV6ProveedorID,(string)AV5ProfesionalesId,(string)AV10AgrupacionEstadoAux});
         context.setWebReturnParmsMetadata(new Object[] {"AV7ListaId","AV6ProveedorID","AV5ProfesionalesId","AV10AgrupacionEstadoAux"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void nextLoad( )
      {
      }

      protected void E15BS2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_21_BS2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_btnconfirmar_Internalname, tblTabledvelop_confirmpanel_btnconfirmar_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_btnconfirmar.SetProperty("Title", Dvelop_confirmpanel_btnconfirmar_Title);
            ucDvelop_confirmpanel_btnconfirmar.SetProperty("ConfirmationText", Dvelop_confirmpanel_btnconfirmar_Confirmationtext);
            ucDvelop_confirmpanel_btnconfirmar.SetProperty("YesButtonCaption", Dvelop_confirmpanel_btnconfirmar_Yesbuttoncaption);
            ucDvelop_confirmpanel_btnconfirmar.SetProperty("NoButtonCaption", Dvelop_confirmpanel_btnconfirmar_Nobuttoncaption);
            ucDvelop_confirmpanel_btnconfirmar.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_btnconfirmar_Cancelbuttoncaption);
            ucDvelop_confirmpanel_btnconfirmar.SetProperty("YesButtonPosition", Dvelop_confirmpanel_btnconfirmar_Yesbuttonposition);
            ucDvelop_confirmpanel_btnconfirmar.SetProperty("ConfirmType", Dvelop_confirmpanel_btnconfirmar_Confirmtype);
            ucDvelop_confirmpanel_btnconfirmar.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_btnconfirmar_Internalname, "DVELOP_CONFIRMPANEL_BTNCONFIRMARContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_BTNCONFIRMARContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_21_BS2e( true) ;
         }
         else
         {
            wb_table1_21_BS2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV7ListaId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV7ListaId", StringUtil.LTrimStr( (decimal)(AV7ListaId), 18, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vLISTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ListaId), "ZZZZZZZZZZZZZZZZZ9"), context));
         AV6ProveedorID = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV6ProveedorID", StringUtil.LTrimStr( (decimal)(AV6ProveedorID), 18, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6ProveedorID), "ZZZZZZZZZZZZZZZZZ9"), context));
         AV5ProfesionalesId = (string)getParm(obj,2);
         AssignAttri("", false, "AV5ProfesionalesId", AV5ProfesionalesId);
         GxWebStd.gx_hidden_field( context, "gxhash_vPROFESIONALESID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5ProfesionalesId, "")), context));
         AV10AgrupacionEstadoAux = (string)getParm(obj,3);
         AssignAttri("", false, "AV10AgrupacionEstadoAux", AV10AgrupacionEstadoAux);
         GxWebStd.gx_hidden_field( context, "gxhash_vAGRUPACIONESTADOAUX", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10AgrupacionEstadoAux, "")), context));
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
         PABS2( ) ;
         WSBS2( ) ;
         WEBS2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021222486", true, true, false);
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
         context.AddJavascriptSource("listaagrupacionwp.js", "?202673021222487", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavAgrupacionestado.Name = "vAGRUPACIONESTADO";
         cmbavAgrupacionestado.WebTags = "";
         cmbavAgrupacionestado.addItem("PEN", context.GetMessage( "PENDIENTE", ""), 0);
         cmbavAgrupacionestado.addItem("VIN", context.GetMessage( "VINCULADO", ""), 0);
         cmbavAgrupacionestado.addItem("DES", context.GetMessage( "DESVINCULADO", ""), 0);
         if ( cmbavAgrupacionestado.ItemCount > 0 )
         {
            AV9AgrupacionEstado = cmbavAgrupacionestado.getValidValue(AV9AgrupacionEstado);
            AssignAttri("", false, "AV9AgrupacionEstado", AV9AgrupacionEstado);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtncancelar_Internalname = "BTNCANCELAR";
         cmbavAgrupacionestado_Internalname = "vAGRUPACIONESTADO";
         bttBtnconfirmar_Internalname = "BTNCONFIRMAR";
         divMaintable_Internalname = "MAINTABLE";
         Dvpanel_maintable_Internalname = "DVPANEL_MAINTABLE";
         Dvelop_confirmpanel_btnconfirmar_Internalname = "DVELOP_CONFIRMPANEL_BTNCONFIRMAR";
         tblTabledvelop_confirmpanel_btnconfirmar_Internalname = "TABLEDVELOP_CONFIRMPANEL_BTNCONFIRMAR";
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
         cmbavAgrupacionestado_Jsonclick = "";
         cmbavAgrupacionestado.Enabled = 1;
         Dvelop_confirmpanel_btnconfirmar_Confirmtype = "1";
         Dvelop_confirmpanel_btnconfirmar_Yesbuttonposition = "left";
         Dvelop_confirmpanel_btnconfirmar_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_btnconfirmar_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_btnconfirmar_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_btnconfirmar_Confirmationtext = "¿Confirmar estado seleccionado?";
         Dvelop_confirmpanel_btnconfirmar_Title = context.GetMessage( "Atención", "");
         Dvpanel_maintable_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_maintable_Iconposition = "Right";
         Dvpanel_maintable_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_maintable_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_maintable_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_maintable_Title = context.GetMessage( "Procesar Cambio de Estado", "");
         Dvpanel_maintable_Cls = "PanelGrayBackgroundTitle";
         Dvpanel_maintable_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_maintable_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_maintable_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Lista", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV10AgrupacionEstadoAux',fld:'vAGRUPACIONESTADOAUX',pic:'',hsh:true,type:'char'},{av:'AV5ProfesionalesId',fld:'vPROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'AV6ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV7ListaId',fld:'vLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOCANCELAR'","{handler:'E14BS2',iparms:[{av:'AV10AgrupacionEstadoAux',fld:'vAGRUPACIONESTADOAUX',pic:'',hsh:true,type:'char'},{av:'AV5ProfesionalesId',fld:'vPROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'AV6ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV7ListaId',fld:'vLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'DOCANCELAR'",",oparms:[]}");
         setEventMetadata("'DOCONFIRMAR'","{handler:'E11BS1',iparms:[]");
         setEventMetadata("'DOCONFIRMAR'",",oparms:[]}");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNCONFIRMAR.CLOSE","{handler:'E12BS2',iparms:[{av:'AV7ListaId',fld:'vLISTAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV6ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV5ProfesionalesId',fld:'vPROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'cmbavAgrupacionestado'},{av:'AV9AgrupacionEstado',fld:'vAGRUPACIONESTADO',pic:'',type:'char'},{av:'AV10AgrupacionEstadoAux',fld:'vAGRUPACIONESTADOAUX',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNCONFIRMAR.CLOSE",",oparms:[]}");
         setEventMetadata("VALIDV_AGRUPACIONESTADO","{handler:'Validv_Agrupacionestado',iparms:[]");
         setEventMetadata("VALIDV_AGRUPACIONESTADO",",oparms:[]}");
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
         wcpOAV5ProfesionalesId = "";
         wcpOAV10AgrupacionEstadoAux = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDvpanel_maintable = new GXUserControl();
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtncancelar_Jsonclick = "";
         AV9AgrupacionEstado = "";
         bttBtnconfirmar_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         sStyleString = "";
         ucDvelop_confirmpanel_btnconfirmar = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int idxLst ;
      private long AV7ListaId ;
      private long AV6ProveedorID ;
      private long wcpOAV7ListaId ;
      private long wcpOAV6ProveedorID ;
      private string AV5ProfesionalesId ;
      private string AV10AgrupacionEstadoAux ;
      private string wcpOAV5ProfesionalesId ;
      private string wcpOAV10AgrupacionEstadoAux ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Dvpanel_maintable_Width ;
      private string Dvpanel_maintable_Cls ;
      private string Dvpanel_maintable_Title ;
      private string Dvpanel_maintable_Iconposition ;
      private string Dvelop_confirmpanel_btnconfirmar_Title ;
      private string Dvelop_confirmpanel_btnconfirmar_Confirmationtext ;
      private string Dvelop_confirmpanel_btnconfirmar_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_btnconfirmar_Nobuttoncaption ;
      private string Dvelop_confirmpanel_btnconfirmar_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_btnconfirmar_Yesbuttonposition ;
      private string Dvelop_confirmpanel_btnconfirmar_Confirmtype ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string Dvpanel_maintable_Internalname ;
      private string divMaintable_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtncancelar_Internalname ;
      private string bttBtncancelar_Jsonclick ;
      private string cmbavAgrupacionestado_Internalname ;
      private string AV9AgrupacionEstado ;
      private string cmbavAgrupacionestado_Jsonclick ;
      private string bttBtnconfirmar_Internalname ;
      private string bttBtnconfirmar_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string sStyleString ;
      private string tblTabledvelop_confirmpanel_btnconfirmar_Internalname ;
      private string Dvelop_confirmpanel_btnconfirmar_Internalname ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_maintable_Autowidth ;
      private bool Dvpanel_maintable_Autoheight ;
      private bool Dvpanel_maintable_Collapsible ;
      private bool Dvpanel_maintable_Collapsed ;
      private bool Dvpanel_maintable_Showcollapseicon ;
      private bool Dvpanel_maintable_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private GXUserControl ucDvpanel_maintable ;
      private GXUserControl ucDvelop_confirmpanel_btnconfirmar ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private long aP0_ListaId ;
      private long aP1_ProveedorID ;
      private string aP2_ProfesionalesId ;
      private string aP3_AgrupacionEstadoAux ;
      private GXCombobox cmbavAgrupacionestado ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
