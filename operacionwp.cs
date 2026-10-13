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
   public class operacionwp : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public operacionwp( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public operacionwp( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_inOperacionesTipo ,
                           long aP1_inWalletId ,
                           string aP2_inOperacionesNombreRef ,
                           long aP3_inOperacion )
      {
         this.AV24inOperacionesTipo = aP0_inOperacionesTipo;
         this.AV25inWalletId = aP1_inWalletId;
         this.AV27inOperacionesNombreRef = aP2_inOperacionesNombreRef;
         this.AV28inOperacion = aP3_inOperacion;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavOperacionestipo = new GXCombobox();
         cmbavWalletbalancesconcepto = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "inOperacionesTipo");
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
               gxfirstwebparm = GetFirstPar( "inOperacionesTipo");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "inOperacionesTipo");
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
         PADO2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTDO2( ) ;
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
         context.AddJavascriptSource("Toastr/toastr.min.js", "", false, true, false);
         context.AddJavascriptSource("Toastr/ToastrRender.js", "", false, true, false);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
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
         GXEncryptionTmp = "operacionwp.aspx"+UrlEncode(StringUtil.RTrim(AV24inOperacionesTipo)) + "," + UrlEncode(StringUtil.LTrimStr(AV25inWalletId,18,0)) + "," + UrlEncode(StringUtil.RTrim(AV27inOperacionesNombreRef)) + "," + UrlEncode(StringUtil.LTrimStr(AV28inOperacion,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("operacionwp.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vTITULO", AV17Titulo);
         GxWebStd.gx_hidden_field( context, "gxhash_vTITULO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17Titulo, "")), context));
         GxWebStd.gx_hidden_field( context, "vMSG", StringUtil.RTrim( Gx_msg));
         GxWebStd.gx_hidden_field( context, "gxhash_vMSG", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_msg, "")), context));
         GxWebStd.gx_hidden_field( context, "vINOPERACIONESNOMBREREF", StringUtil.RTrim( AV27inOperacionesNombreRef));
         GxWebStd.gx_hidden_field( context, "gxhash_vINOPERACIONESNOMBREREF", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV27inOperacionesNombreRef, "")), context));
         GxWebStd.gx_hidden_field( context, "vINWALLETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25inWalletId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vINWALLETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV25inWalletId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINOPERACIONESTIPO", StringUtil.RTrim( AV24inOperacionesTipo));
         GxWebStd.gx_hidden_field( context, "gxhash_vINOPERACIONESTIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV24inOperacionesTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "vINOPERACION", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28inOperacion), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vINOPERACION", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV28inOperacion), "ZZZZZZZZZZZZZZZZZ9"), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vTIPOMOV", StringUtil.RTrim( AV21TipoMov));
         GxWebStd.gx_boolean_hidden_field( context, "vISOK", AV7isOk);
         GxWebStd.gx_hidden_field( context, "vTITULO", AV17Titulo);
         GxWebStd.gx_hidden_field( context, "gxhash_vTITULO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17Titulo, "")), context));
         GxWebStd.gx_hidden_field( context, "vMSG", StringUtil.RTrim( Gx_msg));
         GxWebStd.gx_hidden_field( context, "gxhash_vMSG", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_msg, "")), context));
         GxWebStd.gx_hidden_field( context, "vINOPERACIONESNOMBREREF", StringUtil.RTrim( AV27inOperacionesNombreRef));
         GxWebStd.gx_hidden_field( context, "gxhash_vINOPERACIONESNOMBREREF", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV27inOperacionesNombreRef, "")), context));
         GxWebStd.gx_hidden_field( context, "vINWALLETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25inWalletId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vINWALLETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV25inWalletId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINOPERACIONESTIPO", StringUtil.RTrim( AV24inOperacionesTipo));
         GxWebStd.gx_hidden_field( context, "gxhash_vINOPERACIONESTIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV24inOperacionesTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "vINOPERACION", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28inOperacion), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vINOPERACION", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV28inOperacion), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_GENERARTODOS_Title", StringUtil.RTrim( Dvelop_confirmpanel_generartodos_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_GENERARTODOS_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_generartodos_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_GENERARTODOS_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_generartodos_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_GENERARTODOS_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_generartodos_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_GENERARTODOS_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_generartodos_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_GENERARTODOS_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_generartodos_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_GENERARTODOS_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_generartodos_Confirmtype));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_GENERARTODOS_Result", StringUtil.RTrim( Dvelop_confirmpanel_generartodos_Result));
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
            WEDO2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTDO2( ) ;
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
         GXEncryptionTmp = "operacionwp.aspx"+UrlEncode(StringUtil.RTrim(AV24inOperacionesTipo)) + "," + UrlEncode(StringUtil.LTrimStr(AV25inWalletId,18,0)) + "," + UrlEncode(StringUtil.RTrim(AV27inOperacionesNombreRef)) + "," + UrlEncode(StringUtil.LTrimStr(AV28inOperacion,18,0));
         return formatLink("operacionwp.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "OperacionWP" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Movimientos", "") ;
      }

      protected void WBDO0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavOperacionestipo_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavOperacionestipo, cmbavOperacionestipo_Internalname, StringUtil.RTrim( AV13OperacionesTipo), 1, cmbavOperacionestipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavOperacionestipo.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,17);\"", "", true, 0, "HLP_OperacionWP.htm");
            cmbavOperacionestipo.CurrentValue = StringUtil.RTrim( AV13OperacionesTipo);
            AssignProp("", false, cmbavOperacionestipo_Internalname, "Values", (string)(cmbavOperacionestipo.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedprofesionalesid_Internalname, divTablesplittedprofesionalesid_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockprofesionalesid_Internalname, context.GetMessage( "Profesional", ""), "", "", lblTextblockprofesionalesid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_OperacionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table1_25_DO2( true) ;
         }
         else
         {
            wb_table1_25_DO2( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_DO2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedproveedorid_Internalname, divTablesplittedproveedorid_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockproveedorid_Internalname, context.GetMessage( "Comercio", ""), "", "", lblTextblockproveedorid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_OperacionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table2_39_DO2( true) ;
         }
         else
         {
            wb_table2_39_DO2( false) ;
         }
         return  ;
      }

      protected void wb_table2_39_DO2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedoperacionesid_Internalname, divTablesplittedoperacionesid_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockoperacionesid_Internalname, context.GetMessage( "Operaciones Id", ""), "", "", lblTextblockoperacionesid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_OperacionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table3_53_DO2( true) ;
         }
         else
         {
            wb_table3_53_DO2( false) ;
         }
         return  ;
      }

      protected void wb_table3_53_DO2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedoperacionid_Internalname, divTablesplittedoperacionid_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockoperacionid_Internalname, context.GetMessage( "Operaciones Id", ""), "", "", lblTextblockoperacionid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_OperacionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table4_67_DO2( true) ;
         }
         else
         {
            wb_table4_67_DO2( false) ;
         }
         return  ;
      }

      protected void wb_table4_67_DO2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedwalletid_Internalname, divTablesplittedwalletid_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockwalletid_Internalname, context.GetMessage( "Wallet Id", ""), "", "", lblTextblockwalletid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_OperacionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table5_81_DO2( true) ;
         }
         else
         {
            wb_table5_81_DO2( false) ;
         }
         return  ;
      }

      protected void wb_table5_81_DO2e( bool wbgen )
      {
         if ( wbgen )
         {
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
            GxWebStd.gx_div_start( context, divTb2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOperacionesnombreref_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOperacionesnombreref_Internalname, context.GetMessage( "Nombre de Referencia", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOperacionesnombreref_Internalname, StringUtil.RTrim( AV11OperacionesNombreRef), StringUtil.RTrim( context.localUtil.Format( AV11OperacionesNombreRef, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,95);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOperacionesnombreref_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavOperacionesnombreref_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_OperacionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavWalletbalancesconcepto.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavWalletbalancesconcepto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavWalletbalancesconcepto_Internalname, context.GetMessage( "Concepto", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavWalletbalancesconcepto, cmbavWalletbalancesconcepto_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV31WalletBalancesConcepto), 4, 0)), 1, cmbavWalletbalancesconcepto_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavWalletbalancesconcepto.Visible, cmbavWalletbalancesconcepto.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "", true, 0, "HLP_OperacionWP.htm");
            cmbavWalletbalancesconcepto.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31WalletBalancesConcepto), 4, 0));
            AssignProp("", false, cmbavWalletbalancesconcepto_Internalname, "Values", (string)(cmbavWalletbalancesconcepto.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavImporte_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavImporte_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavImporte_Internalname, context.GetMessage( "Importe", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavImporte_Internalname, StringUtil.LTrim( StringUtil.NToC( AV23Importe, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavImporte_Enabled!=0) ? context.localUtil.Format( AV23Importe, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV23Importe, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "Importe", ""), edtavImporte_Jsonclick, 0, "AttributeFL", "", "", "", "", edtavImporte_Visible, edtavImporte_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_OperacionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavWalletbalancesobs_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavWalletbalancesobs_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWalletbalancesobs_Internalname, context.GetMessage( "Observacion", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWalletbalancesobs_Internalname, AV32WalletBalancesObs, StringUtil.RTrim( context.localUtil.Format( AV32WalletBalancesObs, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWalletbalancesobs_Jsonclick, 0, "AttributeFL", "", "", "", "", edtavWalletbalancesobs_Visible, edtavWalletbalancesobs_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_OperacionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavWalletbalancesurl_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavWalletbalancesurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWalletbalancesurl_Internalname, context.GetMessage( "Url", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWalletbalancesurl_Internalname, AV33WalletBalancesUrl, StringUtil.RTrim( context.localUtil.Format( AV33WalletBalancesUrl, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,113);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWalletbalancesurl_Jsonclick, 0, "AttributeFL", "", "", "", "", edtavWalletbalancesurl_Visible, edtavWalletbalancesurl_Enabled, 0, "text", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_OperacionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavOperacionesfechadesde_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOperacionesfechadesde_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOperacionesfechadesde_Internalname, context.GetMessage( "Desde", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavOperacionesfechadesde_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavOperacionesfechadesde_Internalname, context.localUtil.Format(AV8OperacionesFechaDesde, "99/99/99"), context.localUtil.Format( AV8OperacionesFechaDesde, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,118);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOperacionesfechadesde_Jsonclick, 0, "AttributeFL", "", "", "", "", edtavOperacionesfechadesde_Visible, edtavOperacionesfechadesde_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_OperacionWP.htm");
            GxWebStd.gx_bitmap( context, edtavOperacionesfechadesde_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavOperacionesfechadesde_Visible==0)||(edtavOperacionesfechadesde_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_OperacionWP.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavOperacionesfechahasta_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOperacionesfechahasta_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOperacionesfechahasta_Internalname, context.GetMessage( "Hasta", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 122,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavOperacionesfechahasta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavOperacionesfechahasta_Internalname, context.localUtil.Format(AV9OperacionesFechaHasta, "99/99/99"), context.localUtil.Format( AV9OperacionesFechaHasta, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,122);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOperacionesfechahasta_Jsonclick, 0, "AttributeFL", "", "", "", "", edtavOperacionesfechahasta_Visible, edtavOperacionesfechahasta_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_OperacionWP.htm");
            GxWebStd.gx_bitmap( context, edtavOperacionesfechahasta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavOperacionesfechahasta_Visible==0)||(edtavOperacionesfechahasta_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_OperacionWP.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColoredActions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtngenerar_Internalname, "", context.GetMessage( "Generar", ""), bttBtngenerar_Jsonclick, 5, context.GetMessage( "Generar", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOGENERAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_OperacionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'',0)\"";
            ClassString = "ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", context.GetMessage( "Cancelar", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_OperacionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtngenerartodos_Internalname, "", context.GetMessage( "Generar Todos las Liquidaciones", ""), bttBtngenerartodos_Jsonclick, 7, context.GetMessage( "Generar Todos las Liquidaciones", ""), "", StyleString, ClassString, bttBtngenerartodos_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e11do1_client"+"'", TempTags, "", 2, "HLP_OperacionWP.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOperacionesref_Internalname, StringUtil.RTrim( AV12OperacionesRef), StringUtil.RTrim( context.localUtil.Format( AV12OperacionesRef, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,141);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOperacionesref_Jsonclick, 0, "Attribute", "", "", "", "", edtavOperacionesref_Visible, 1, 0, "text", "", 25, "chr", 1, "row", 25, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_OperacionWP.htm");
            wb_table6_142_DO2( true) ;
         }
         else
         {
            wb_table6_142_DO2( false) ;
         }
         return  ;
      }

      protected void wb_table6_142_DO2e( bool wbgen )
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

      protected void STARTDO2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Movimientos", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPDO0( ) ;
      }

      protected void WSDO2( )
      {
         STARTDO2( ) ;
         EVTDO2( ) ;
      }

      protected void EVTDO2( )
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
                              E12DO2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOGENERAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoGenerar' */
                              E13DO2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E14DO2 ();
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

      protected void WEDO2( )
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

      protected void PADO2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "operacionwp.aspx")), "operacionwp.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "operacionwp.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "inOperacionesTipo");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV24inOperacionesTipo = gxfirstwebparm;
                     AssignAttri("", false, "AV24inOperacionesTipo", AV24inOperacionesTipo);
                     GxWebStd.gx_hidden_field( context, "gxhash_vINOPERACIONESTIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV24inOperacionesTipo, "")), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV25inWalletId = (long)(Math.Round(NumberUtil.Val( GetPar( "inWalletId"), "."), 18, MidpointRounding.ToEven));
                        AssignAttri("", false, "AV25inWalletId", StringUtil.LTrimStr( (decimal)(AV25inWalletId), 18, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vINWALLETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV25inWalletId), "ZZZZZZZZZZZZZZZZZ9"), context));
                        AV27inOperacionesNombreRef = GetPar( "inOperacionesNombreRef");
                        AssignAttri("", false, "AV27inOperacionesNombreRef", AV27inOperacionesNombreRef);
                        GxWebStd.gx_hidden_field( context, "gxhash_vINOPERACIONESNOMBREREF", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV27inOperacionesNombreRef, "")), context));
                        AV28inOperacion = (long)(Math.Round(NumberUtil.Val( GetPar( "inOperacion"), "."), 18, MidpointRounding.ToEven));
                        AssignAttri("", false, "AV28inOperacion", StringUtil.LTrimStr( (decimal)(AV28inOperacion), 18, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vINOPERACION", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV28inOperacion), "ZZZZZZZZZZZZZZZZZ9"), context));
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
               GX_FocusControl = cmbavOperacionestipo_Internalname;
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
         if ( cmbavOperacionestipo.ItemCount > 0 )
         {
            AV13OperacionesTipo = cmbavOperacionestipo.getValidValue(AV13OperacionesTipo);
            AssignAttri("", false, "AV13OperacionesTipo", AV13OperacionesTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavOperacionestipo.CurrentValue = StringUtil.RTrim( AV13OperacionesTipo);
            AssignProp("", false, cmbavOperacionestipo_Internalname, "Values", cmbavOperacionestipo.ToJavascriptSource(), true);
         }
         if ( cmbavWalletbalancesconcepto.ItemCount > 0 )
         {
            AV31WalletBalancesConcepto = (short)(Math.Round(NumberUtil.Val( cmbavWalletbalancesconcepto.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV31WalletBalancesConcepto), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV31WalletBalancesConcepto", StringUtil.LTrimStr( (decimal)(AV31WalletBalancesConcepto), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavWalletbalancesconcepto.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31WalletBalancesConcepto), 4, 0));
            AssignProp("", false, cmbavWalletbalancesconcepto_Internalname, "Values", cmbavWalletbalancesconcepto.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFDO2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         imgPrompt_profesionalesid_Link = "javascript:"+"gx.popup.openPrompt('"+"profesionalesfullnameprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"vPROFESIONALESID"+"'), id:'"+"vPROFESIONALESID"+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"vOPERACIONESNOMBREREF"+"'), id:'"+"vOPERACIONESNOMBREREF"+"'"+",IOType:'inout'}"+"],"+"null"+","+"'', false"+","+"false"+");";
         AssignProp("", false, imgPrompt_profesionalesid_Internalname, "Link", imgPrompt_profesionalesid_Link, true);
         imgPrompt_proveedorid_Link = "javascript:"+"gx.popup.openPrompt('"+"comercioprompt1.aspx"+"',["+"{Ctrl:gx.dom.el('"+"vPROVEEDORID"+"'), id:'"+"vPROVEEDORID"+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"vOPERACIONESNOMBREREF"+"'), id:'"+"vOPERACIONESNOMBREREF"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");";
         AssignProp("", false, imgPrompt_proveedorid_Internalname, "Link", imgPrompt_proveedorid_Link, true);
         imgPrompt_operacionesid_Link = "javascript:"+"gx.popup.openPrompt('"+"operacionesidprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"vOPERACIONESID"+"'), id:'"+"vOPERACIONESID"+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"vOPERACIONESNOMBREREF"+"'), id:'"+"vOPERACIONESNOMBREREF"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");";
         AssignProp("", false, imgPrompt_operacionesid_Internalname, "Link", imgPrompt_operacionesid_Link, true);
         imgPrompt_operacionid_Link = "javascript:"+"gx.popup.openPrompt('"+"operacionesid2prompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"vOPERACIONID"+"'), id:'"+"vOPERACIONID"+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"vOPERACIONESNOMBREREF"+"'), id:'"+"vOPERACIONESNOMBREREF"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");";
         AssignProp("", false, imgPrompt_operacionid_Internalname, "Link", imgPrompt_operacionid_Link, true);
         imgPrompt_walletid_Link = "javascript:"+"gx.popup.openPrompt('"+"walletprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"vWALLETID"+"'), id:'"+"vWALLETID"+"'"+",IOType:'inout'}"+"],"+"null"+","+"'', false"+","+"false"+");";
         AssignProp("", false, imgPrompt_walletid_Internalname, "Link", imgPrompt_walletid_Link, true);
      }

      protected void RFDO2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E14DO2 ();
            WBDO0( ) ;
         }
      }

      protected void send_integrity_lvl_hashesDO2( )
      {
         GxWebStd.gx_hidden_field( context, "vTITULO", AV17Titulo);
         GxWebStd.gx_hidden_field( context, "gxhash_vTITULO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17Titulo, "")), context));
         GxWebStd.gx_hidden_field( context, "vMSG", StringUtil.RTrim( Gx_msg));
         GxWebStd.gx_hidden_field( context, "gxhash_vMSG", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_msg, "")), context));
      }

      protected void before_start_formulas( )
      {
         imgPrompt_profesionalesid_Link = "javascript:"+"gx.popup.openPrompt('"+"profesionalesfullnameprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"vPROFESIONALESID"+"'), id:'"+"vPROFESIONALESID"+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"vOPERACIONESNOMBREREF"+"'), id:'"+"vOPERACIONESNOMBREREF"+"'"+",IOType:'inout'}"+"],"+"null"+","+"'', false"+","+"false"+");";
         AssignProp("", false, imgPrompt_profesionalesid_Internalname, "Link", imgPrompt_profesionalesid_Link, true);
         imgPrompt_proveedorid_Link = "javascript:"+"gx.popup.openPrompt('"+"comercioprompt1.aspx"+"',["+"{Ctrl:gx.dom.el('"+"vPROVEEDORID"+"'), id:'"+"vPROVEEDORID"+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"vOPERACIONESNOMBREREF"+"'), id:'"+"vOPERACIONESNOMBREREF"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");";
         AssignProp("", false, imgPrompt_proveedorid_Internalname, "Link", imgPrompt_proveedorid_Link, true);
         imgPrompt_operacionesid_Link = "javascript:"+"gx.popup.openPrompt('"+"operacionesidprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"vOPERACIONESID"+"'), id:'"+"vOPERACIONESID"+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"vOPERACIONESNOMBREREF"+"'), id:'"+"vOPERACIONESNOMBREREF"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");";
         AssignProp("", false, imgPrompt_operacionesid_Internalname, "Link", imgPrompt_operacionesid_Link, true);
         imgPrompt_operacionid_Link = "javascript:"+"gx.popup.openPrompt('"+"operacionesid2prompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"vOPERACIONID"+"'), id:'"+"vOPERACIONID"+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"vOPERACIONESNOMBREREF"+"'), id:'"+"vOPERACIONESNOMBREREF"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");";
         AssignProp("", false, imgPrompt_operacionid_Internalname, "Link", imgPrompt_operacionid_Link, true);
         imgPrompt_walletid_Link = "javascript:"+"gx.popup.openPrompt('"+"walletprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"vWALLETID"+"'), id:'"+"vWALLETID"+"'"+",IOType:'inout'}"+"],"+"null"+","+"'', false"+","+"false"+");";
         AssignProp("", false, imgPrompt_walletid_Internalname, "Link", imgPrompt_walletid_Link, true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUPDO0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12DO2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( ( StringUtil.StrCmp(AV13OperacionesTipo, "NCR") == 0 ) || ( StringUtil.StrCmp(AV13OperacionesTipo, "NDE") == 0 ) )
         {
            edtavOperacionesnombreref_Enabled = 0;
            AssignProp("", false, edtavOperacionesnombreref_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOperacionesnombreref_Enabled), 5, 0), true);
         }
         else
         {
            edtavOperacionesnombreref_Enabled = 1;
            AssignProp("", false, edtavOperacionesnombreref_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOperacionesnombreref_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            AV21TipoMov = cgiGet( "vTIPOMOV");
            AssignAttri("", false, "AV21TipoMov", AV21TipoMov);
            AV27inOperacionesNombreRef = cgiGet( "vINOPERACIONESNOMBREREF");
            AV25inWalletId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINWALLETID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_msg = cgiGet( "vMSG");
            AV17Titulo = cgiGet( "vTITULO");
            AV7isOk = StringUtil.StrToBool( cgiGet( "vISOK"));
            Dvelop_confirmpanel_generartodos_Title = cgiGet( "DVELOP_CONFIRMPANEL_GENERARTODOS_Title");
            Dvelop_confirmpanel_generartodos_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_GENERARTODOS_Confirmationtext");
            Dvelop_confirmpanel_generartodos_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_GENERARTODOS_Yesbuttoncaption");
            Dvelop_confirmpanel_generartodos_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_GENERARTODOS_Nobuttoncaption");
            Dvelop_confirmpanel_generartodos_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_GENERARTODOS_Cancelbuttoncaption");
            Dvelop_confirmpanel_generartodos_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_GENERARTODOS_Yesbuttonposition");
            Dvelop_confirmpanel_generartodos_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_GENERARTODOS_Confirmtype");
            /* Read variables values. */
            cmbavOperacionestipo.CurrentValue = cgiGet( cmbavOperacionestipo_Internalname);
            AV13OperacionesTipo = cgiGet( cmbavOperacionestipo_Internalname);
            AssignAttri("", false, "AV13OperacionesTipo", AV13OperacionesTipo);
            AV14ProfesionalesId = cgiGet( edtavProfesionalesid_Internalname);
            AssignAttri("", false, "AV14ProfesionalesId", AV14ProfesionalesId);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavProveedorid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavProveedorid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROVEEDORID");
               GX_FocusControl = edtavProveedorid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15ProveedorID = 0;
               AssignAttri("", false, "AV15ProveedorID", StringUtil.LTrimStr( (decimal)(AV15ProveedorID), 18, 0));
            }
            else
            {
               AV15ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavProveedorid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV15ProveedorID", StringUtil.LTrimStr( (decimal)(AV15ProveedorID), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavOperacionesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavOperacionesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vOPERACIONESID");
               GX_FocusControl = edtavOperacionesid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10OperacionesId = 0;
               AssignAttri("", false, "AV10OperacionesId", StringUtil.LTrimStr( (decimal)(AV10OperacionesId), 18, 0));
            }
            else
            {
               AV10OperacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavOperacionesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV10OperacionesId", StringUtil.LTrimStr( (decimal)(AV10OperacionesId), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavOperacionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavOperacionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vOPERACIONID");
               GX_FocusControl = edtavOperacionid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV19OperacionId = 0;
               AssignAttri("", false, "AV19OperacionId", StringUtil.LTrimStr( (decimal)(AV19OperacionId), 18, 0));
            }
            else
            {
               AV19OperacionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavOperacionid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV19OperacionId", StringUtil.LTrimStr( (decimal)(AV19OperacionId), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavWalletid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavWalletid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vWALLETID");
               GX_FocusControl = edtavWalletid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV22WalletId = 0;
               AssignAttri("", false, "AV22WalletId", StringUtil.LTrimStr( (decimal)(AV22WalletId), 18, 0));
            }
            else
            {
               AV22WalletId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavWalletid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV22WalletId", StringUtil.LTrimStr( (decimal)(AV22WalletId), 18, 0));
            }
            AV11OperacionesNombreRef = cgiGet( edtavOperacionesnombreref_Internalname);
            AssignAttri("", false, "AV11OperacionesNombreRef", AV11OperacionesNombreRef);
            cmbavWalletbalancesconcepto.CurrentValue = cgiGet( cmbavWalletbalancesconcepto_Internalname);
            AV31WalletBalancesConcepto = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavWalletbalancesconcepto_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV31WalletBalancesConcepto", StringUtil.LTrimStr( (decimal)(AV31WalletBalancesConcepto), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavImporte_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavImporte_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vIMPORTE");
               GX_FocusControl = edtavImporte_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV23Importe = 0;
               AssignAttri("", false, "AV23Importe", StringUtil.LTrimStr( AV23Importe, 18, 2));
            }
            else
            {
               AV23Importe = context.localUtil.CToN( cgiGet( edtavImporte_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV23Importe", StringUtil.LTrimStr( AV23Importe, 18, 2));
            }
            AV32WalletBalancesObs = cgiGet( edtavWalletbalancesobs_Internalname);
            AssignAttri("", false, "AV32WalletBalancesObs", AV32WalletBalancesObs);
            AV33WalletBalancesUrl = cgiGet( edtavWalletbalancesurl_Internalname);
            AssignAttri("", false, "AV33WalletBalancesUrl", AV33WalletBalancesUrl);
            if ( context.localUtil.VCDate( cgiGet( edtavOperacionesfechadesde_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Operaciones Fecha Desde", "")}), 1, "vOPERACIONESFECHADESDE");
               GX_FocusControl = edtavOperacionesfechadesde_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8OperacionesFechaDesde = DateTime.MinValue;
               AssignAttri("", false, "AV8OperacionesFechaDesde", context.localUtil.Format(AV8OperacionesFechaDesde, "99/99/99"));
            }
            else
            {
               AV8OperacionesFechaDesde = context.localUtil.CToD( cgiGet( edtavOperacionesfechadesde_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV8OperacionesFechaDesde", context.localUtil.Format(AV8OperacionesFechaDesde, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavOperacionesfechahasta_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Operaciones Fecha Hasta", "")}), 1, "vOPERACIONESFECHAHASTA");
               GX_FocusControl = edtavOperacionesfechahasta_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9OperacionesFechaHasta = DateTime.MinValue;
               AssignAttri("", false, "AV9OperacionesFechaHasta", context.localUtil.Format(AV9OperacionesFechaHasta, "99/99/99"));
            }
            else
            {
               AV9OperacionesFechaHasta = context.localUtil.CToD( cgiGet( edtavOperacionesfechahasta_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV9OperacionesFechaHasta", context.localUtil.Format(AV9OperacionesFechaHasta, "99/99/99"));
            }
            AV12OperacionesRef = cgiGet( edtavOperacionesref_Internalname);
            AssignAttri("", false, "AV12OperacionesRef", AV12OperacionesRef);
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
         E12DO2 ();
         if (returnInSub) return;
      }

      protected void E12DO2( )
      {
         /* Start Routine */
         returnInSub = false;
         divTablesplittedproveedorid_Visible = 0;
         AssignProp("", false, divTablesplittedproveedorid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedproveedorid_Visible), 5, 0), true);
         divTablesplittedoperacionesid_Visible = 0;
         AssignProp("", false, divTablesplittedoperacionesid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedoperacionesid_Visible), 5, 0), true);
         divTablesplittedoperacionid_Visible = 0;
         AssignProp("", false, divTablesplittedoperacionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedoperacionid_Visible), 5, 0), true);
         divTablesplittedwalletid_Visible = 0;
         AssignProp("", false, divTablesplittedwalletid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedwalletid_Visible), 5, 0), true);
         edtavImporte_Visible = 0;
         AssignProp("", false, edtavImporte_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavImporte_Visible), 5, 0), true);
         cmbavWalletbalancesconcepto.Visible = 0;
         AssignProp("", false, cmbavWalletbalancesconcepto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavWalletbalancesconcepto.Visible), 5, 0), true);
         edtavWalletbalancesobs_Visible = 0;
         AssignProp("", false, edtavWalletbalancesobs_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWalletbalancesobs_Visible), 5, 0), true);
         edtavWalletbalancesurl_Visible = 0;
         AssignProp("", false, edtavWalletbalancesurl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWalletbalancesurl_Visible), 5, 0), true);
         bttBtngenerartodos_Visible = 0;
         AssignProp("", false, bttBtngenerartodos_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtngenerartodos_Visible), 5, 0), true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24inOperacionesTipo)) )
         {
            if ( ( AV25inWalletId > 0 ) && ( ( StringUtil.StrCmp(AV24inOperacionesTipo, "NCR") == 0 ) || ( StringUtil.StrCmp(AV24inOperacionesTipo, "NDE") == 0 ) ) )
            {
               AV22WalletId = AV25inWalletId;
               AssignAttri("", false, "AV22WalletId", StringUtil.LTrimStr( (decimal)(AV22WalletId), 18, 0));
               AV11OperacionesNombreRef = AV27inOperacionesNombreRef;
               AssignAttri("", false, "AV11OperacionesNombreRef", AV11OperacionesNombreRef);
               edtavWalletid_Enabled = 0;
               AssignProp("", false, edtavWalletid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWalletid_Enabled), 5, 0), true);
            }
            else if ( ( AV28inOperacion > 0 ) && ( StringUtil.StrCmp(AV24inOperacionesTipo, "COL") == 0 ) )
            {
               AV10OperacionesId = AV28inOperacion;
               AssignAttri("", false, "AV10OperacionesId", StringUtil.LTrimStr( (decimal)(AV10OperacionesId), 18, 0));
               AV11OperacionesNombreRef = AV27inOperacionesNombreRef;
               AssignAttri("", false, "AV11OperacionesNombreRef", AV11OperacionesNombreRef);
            }
            else if ( ( AV28inOperacion > 0 ) && ( StringUtil.StrCmp(AV24inOperacionesTipo, "POL") == 0 ) )
            {
               AV19OperacionId = AV28inOperacion;
               AssignAttri("", false, "AV19OperacionId", StringUtil.LTrimStr( (decimal)(AV19OperacionId), 18, 0));
               AV11OperacionesNombreRef = AV27inOperacionesNombreRef;
               AssignAttri("", false, "AV11OperacionesNombreRef", AV11OperacionesNombreRef);
            }
            AV13OperacionesTipo = AV24inOperacionesTipo;
            AssignAttri("", false, "AV13OperacionesTipo", AV13OperacionesTipo);
            cmbavOperacionestipo.Enabled = 0;
            AssignProp("", false, cmbavOperacionestipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavOperacionestipo.Enabled), 5, 0), true);
            /* Execute user subroutine: 'VALIDAR OPERACIONES TIPO' */
            S112 ();
            if (returnInSub) return;
         }
         else
         {
            AV9OperacionesFechaHasta = DateTimeUtil.ResetTime(DateTimeUtil.Now( context));
            AssignAttri("", false, "AV9OperacionesFechaHasta", context.localUtil.Format(AV9OperacionesFechaHasta, "99/99/99"));
            AV8OperacionesFechaDesde = DateTimeUtil.DAdd(AV9OperacionesFechaHasta,-((int)(15)));
            AssignAttri("", false, "AV8OperacionesFechaDesde", context.localUtil.Format(AV8OperacionesFechaDesde, "99/99/99"));
         }
         edtavOperacionesref_Visible = 0;
         AssignProp("", false, edtavOperacionesref_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOperacionesref_Visible), 5, 0), true);
         cmbavOperacionestipo.removeItem("CSO");
         cmbavOperacionestipo.removeItem("OTR");
         if ( StringUtil.StrCmp(AV13OperacionesTipo, "NCR") == 0 )
         {
            cmbavWalletbalancesconcepto.removeAllItems();
            cmbavWalletbalancesconcepto.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(4), 4, 0)), context.GetMessage( "Crédito", ""), 0);
            cmbavWalletbalancesconcepto.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(2), 4, 0)), context.GetMessage( "Pago Recibido", ""), 0);
            cmbavWalletbalancesconcepto.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(6), 4, 0)), context.GetMessage( "Saldo Inicial", ""), 0);
            AV31WalletBalancesConcepto = 4;
            AssignAttri("", false, "AV31WalletBalancesConcepto", StringUtil.LTrimStr( (decimal)(AV31WalletBalancesConcepto), 4, 0));
         }
         else
         {
            if ( StringUtil.StrCmp(AV13OperacionesTipo, "NDE") == 0 )
            {
               cmbavWalletbalancesconcepto.removeAllItems();
               cmbavWalletbalancesconcepto.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(3), 4, 0)), context.GetMessage( "Deuda", ""), 0);
               cmbavWalletbalancesconcepto.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(1), 4, 0)), context.GetMessage( "Pago Enviado", ""), 0);
               cmbavWalletbalancesconcepto.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(6), 4, 0)), context.GetMessage( "Saldo Inicial", ""), 0);
               AV31WalletBalancesConcepto = 3;
               AssignAttri("", false, "AV31WalletBalancesConcepto", StringUtil.LTrimStr( (decimal)(AV31WalletBalancesConcepto), 4, 0));
            }
         }
      }

      protected void E13DO2( )
      {
         /* 'DoGenerar' Routine */
         returnInSub = false;
         AV35isOkGenerar = true;
         if ( ( String.IsNullOrEmpty(StringUtil.RTrim( AV11OperacionesNombreRef)) || (DateTime.MinValue==AV8OperacionesFechaDesde) || (DateTime.MinValue==AV9OperacionesFechaHasta) ) && (0==AV10OperacionesId) && (0==AV19OperacionId) && (0==AV22WalletId) )
         {
            context.StatusMessage( context.GetMessage( "Debe seleccionar todos los campos", "") );
            AV35isOkGenerar = false;
         }
         if ( ( AV23Importe <= Convert.ToDecimal( 0 )) && ( ( StringUtil.StrCmp(AV13OperacionesTipo, "NCR") == 0 ) || ( StringUtil.StrCmp(AV13OperacionesTipo, "NDE") == 0 ) ) )
         {
            GX_msglist.addItem(context.GetMessage( "El importe debe ser mayor a 0.", ""));
            AV35isOkGenerar = false;
         }
         if ( AV35isOkGenerar )
         {
            if ( StringUtil.StrCmp(AV13OperacionesTipo, "LSF") == 0 )
            {
               AV12OperacionesRef = AV14ProfesionalesId;
               AssignAttri("", false, "AV12OperacionesRef", AV12OperacionesRef);
            }
            else if ( StringUtil.StrCmp(AV13OperacionesTipo, "LSC") == 0 )
            {
               AV12OperacionesRef = StringUtil.Str( (decimal)(AV15ProveedorID), 18, 0);
               AssignAttri("", false, "AV12OperacionesRef", AV12OperacionesRef);
            }
            else if ( StringUtil.StrCmp(AV13OperacionesTipo, "COL") == 0 )
            {
               new aoperacioncobro(context ).execute(  AV10OperacionesId,  AV21TipoMov,  AV13OperacionesTipo, out  AV7isOk) ;
               AssignAttri("", false, "AV7isOk", AV7isOk);
            }
            else if ( StringUtil.StrCmp(AV13OperacionesTipo, "POL") == 0 )
            {
               new aoperacioncobro(context ).execute(  AV19OperacionId,  AV21TipoMov,  AV13OperacionesTipo, out  AV7isOk) ;
               AssignAttri("", false, "AV7isOk", AV7isOk);
            }
            else if ( StringUtil.StrCmp(AV13OperacionesTipo, "NCR") == 0 )
            {
               AV21TipoMov = "CRE";
               AssignAttri("", false, "AV21TipoMov", AV21TipoMov);
               new aoperacionnotas(context ).execute(  AV22WalletId,  AV21TipoMov,  AV13OperacionesTipo,  AV23Importe,  AV31WalletBalancesConcepto,  AV32WalletBalancesObs,  AV33WalletBalancesUrl, out  AV7isOk, out  AV10OperacionesId) ;
               AssignAttri("", false, "AV7isOk", AV7isOk);
               AssignAttri("", false, "AV10OperacionesId", StringUtil.LTrimStr( (decimal)(AV10OperacionesId), 18, 0));
               /* Window Datatype Object Property */
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "areciboopenotacredeb.aspx"+UrlEncode(StringUtil.LTrimStr(AV10OperacionesId,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV22WalletId,18,0)) + "," + UrlEncode(StringUtil.RTrim(AV13OperacionesTipo)) + "," + UrlEncode(StringUtil.RTrim(AV11OperacionesNombreRef));
               AV29Windows.Url = formatLink("areciboopenotacredeb.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
               AV29Windows.SetReturnParms(new Object[] {});
               context.NewWindow(AV29Windows);
            }
            else if ( StringUtil.StrCmp(AV13OperacionesTipo, "NDE") == 0 )
            {
               AV21TipoMov = "DEB";
               AssignAttri("", false, "AV21TipoMov", AV21TipoMov);
               new aoperacionnotas(context ).execute(  AV22WalletId,  AV21TipoMov,  AV13OperacionesTipo,  AV23Importe,  AV31WalletBalancesConcepto,  AV32WalletBalancesObs,  AV33WalletBalancesUrl, out  AV7isOk, out  AV10OperacionesId) ;
               AssignAttri("", false, "AV7isOk", AV7isOk);
               AssignAttri("", false, "AV10OperacionesId", StringUtil.LTrimStr( (decimal)(AV10OperacionesId), 18, 0));
               /* Window Datatype Object Property */
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "areciboopenotacredeb.aspx"+UrlEncode(StringUtil.LTrimStr(AV10OperacionesId,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV22WalletId,18,0)) + "," + UrlEncode(StringUtil.RTrim(AV13OperacionesTipo)) + "," + UrlEncode(StringUtil.RTrim(AV11OperacionesNombreRef));
               AV29Windows.Url = formatLink("areciboopenotacredeb.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
               AV29Windows.SetReturnParms(new Object[] {});
               context.NewWindow(AV29Windows);
            }
            if ( AV7isOk )
            {
               AV30Mensaje = StringUtil.Format( context.GetMessage( "Operación %1 Finalizada.", ""), StringUtil.LTrimStr( (decimal)(AV10OperacionesId), 18, 0), "", "", "", "", "", "", "", "");
               this.executeUsercontrolMethod("", false, "TOASTR1Container", "Msg", "", new Object[] {(string)"success",context.GetMessage( "Operación Finalizada.", ""),(string)AV17Titulo});
               GX_msglist.addItem(Gx_msg);
               context.setWebReturnParms(new Object[] {});
               context.setWebReturnParmsMetadata(new Object[] {});
               context.wjLocDisableFrm = 1;
               context.nUserReturn = 1;
               returnInSub = true;
               if (true) return;
            }
            else
            {
               this.executeUsercontrolMethod("", false, "TOASTR1Container", "Msg", "", new Object[] {(string)"error",context.GetMessage( "Error no se generaron Operaciones.", ""),(string)AV17Titulo});
            }
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'DO ACTION GENERARTODOS' Routine */
         returnInSub = false;
      }

      protected void S112( )
      {
         /* 'VALIDAR OPERACIONES TIPO' Routine */
         returnInSub = false;
         bttBtngenerartodos_Visible = 0;
         AssignProp("", false, bttBtngenerartodos_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtngenerartodos_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV13OperacionesTipo, "LSF") == 0 )
         {
            divTablesplittedprofesionalesid_Visible = 1;
            AssignProp("", false, divTablesplittedprofesionalesid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedprofesionalesid_Visible), 5, 0), true);
            divTablesplittedproveedorid_Visible = 0;
            AssignProp("", false, divTablesplittedproveedorid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedproveedorid_Visible), 5, 0), true);
            divTablesplittedoperacionesid_Visible = 0;
            AssignProp("", false, divTablesplittedoperacionesid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedoperacionesid_Visible), 5, 0), true);
            divTablesplittedoperacionid_Visible = 0;
            AssignProp("", false, divTablesplittedoperacionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedoperacionid_Visible), 5, 0), true);
            divTablesplittedwalletid_Visible = 0;
            AssignProp("", false, divTablesplittedwalletid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedwalletid_Visible), 5, 0), true);
            edtavImporte_Visible = 0;
            AssignProp("", false, edtavImporte_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavImporte_Visible), 5, 0), true);
            AV11OperacionesNombreRef = "";
            AssignAttri("", false, "AV11OperacionesNombreRef", AV11OperacionesNombreRef);
         }
         else if ( StringUtil.StrCmp(AV13OperacionesTipo, "LSC") == 0 )
         {
            divTablesplittedprofesionalesid_Visible = 0;
            AssignProp("", false, divTablesplittedprofesionalesid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedprofesionalesid_Visible), 5, 0), true);
            divTablesplittedproveedorid_Visible = 1;
            AssignProp("", false, divTablesplittedproveedorid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedproveedorid_Visible), 5, 0), true);
            divTablesplittedoperacionesid_Visible = 0;
            AssignProp("", false, divTablesplittedoperacionesid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedoperacionesid_Visible), 5, 0), true);
            divTablesplittedoperacionid_Visible = 0;
            AssignProp("", false, divTablesplittedoperacionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedoperacionid_Visible), 5, 0), true);
            divTablesplittedwalletid_Visible = 0;
            AssignProp("", false, divTablesplittedwalletid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedwalletid_Visible), 5, 0), true);
            edtavImporte_Visible = 0;
            AssignProp("", false, edtavImporte_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavImporte_Visible), 5, 0), true);
            AV11OperacionesNombreRef = "";
            AssignAttri("", false, "AV11OperacionesNombreRef", AV11OperacionesNombreRef);
         }
         else if ( StringUtil.StrCmp(AV13OperacionesTipo, "COL") == 0 )
         {
            AV21TipoMov = "CRE";
            AssignAttri("", false, "AV21TipoMov", AV21TipoMov);
            divTablesplittedprofesionalesid_Visible = 0;
            AssignProp("", false, divTablesplittedprofesionalesid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedprofesionalesid_Visible), 5, 0), true);
            divTablesplittedproveedorid_Visible = 0;
            AssignProp("", false, divTablesplittedproveedorid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedproveedorid_Visible), 5, 0), true);
            divTablesplittedoperacionesid_Visible = 1;
            AssignProp("", false, divTablesplittedoperacionesid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedoperacionesid_Visible), 5, 0), true);
            divTablesplittedoperacionid_Visible = 0;
            AssignProp("", false, divTablesplittedoperacionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedoperacionid_Visible), 5, 0), true);
            divTablesplittedwalletid_Visible = 0;
            AssignProp("", false, divTablesplittedwalletid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedwalletid_Visible), 5, 0), true);
            edtavOperacionesfechadesde_Visible = 0;
            AssignProp("", false, edtavOperacionesfechadesde_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOperacionesfechadesde_Visible), 5, 0), true);
            edtavOperacionesfechahasta_Visible = 0;
            AssignProp("", false, edtavOperacionesfechahasta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOperacionesfechahasta_Visible), 5, 0), true);
            edtavImporte_Visible = 0;
            AssignProp("", false, edtavImporte_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavImporte_Visible), 5, 0), true);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV27inOperacionesNombreRef)) )
            {
               AV11OperacionesNombreRef = "";
               AssignAttri("", false, "AV11OperacionesNombreRef", AV11OperacionesNombreRef);
            }
         }
         else if ( StringUtil.StrCmp(AV13OperacionesTipo, "POL") == 0 )
         {
            AV21TipoMov = "DEB";
            AssignAttri("", false, "AV21TipoMov", AV21TipoMov);
            divTablesplittedprofesionalesid_Visible = 0;
            AssignProp("", false, divTablesplittedprofesionalesid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedprofesionalesid_Visible), 5, 0), true);
            divTablesplittedproveedorid_Visible = 0;
            AssignProp("", false, divTablesplittedproveedorid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedproveedorid_Visible), 5, 0), true);
            divTablesplittedoperacionesid_Visible = 0;
            AssignProp("", false, divTablesplittedoperacionesid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedoperacionesid_Visible), 5, 0), true);
            divTablesplittedoperacionid_Visible = 1;
            AssignProp("", false, divTablesplittedoperacionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedoperacionid_Visible), 5, 0), true);
            divTablesplittedwalletid_Visible = 0;
            AssignProp("", false, divTablesplittedwalletid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedwalletid_Visible), 5, 0), true);
            edtavOperacionesfechadesde_Visible = 0;
            AssignProp("", false, edtavOperacionesfechadesde_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOperacionesfechadesde_Visible), 5, 0), true);
            edtavOperacionesfechahasta_Visible = 0;
            AssignProp("", false, edtavOperacionesfechahasta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOperacionesfechahasta_Visible), 5, 0), true);
            edtavImporte_Visible = 0;
            AssignProp("", false, edtavImporte_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavImporte_Visible), 5, 0), true);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV27inOperacionesNombreRef)) )
            {
               AV11OperacionesNombreRef = "";
               AssignAttri("", false, "AV11OperacionesNombreRef", AV11OperacionesNombreRef);
            }
         }
         else if ( StringUtil.StrCmp(AV13OperacionesTipo, "NCR") == 0 )
         {
            AV21TipoMov = "CRE";
            AssignAttri("", false, "AV21TipoMov", AV21TipoMov);
            divTablesplittedprofesionalesid_Visible = 0;
            AssignProp("", false, divTablesplittedprofesionalesid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedprofesionalesid_Visible), 5, 0), true);
            divTablesplittedproveedorid_Visible = 0;
            AssignProp("", false, divTablesplittedproveedorid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedproveedorid_Visible), 5, 0), true);
            divTablesplittedoperacionesid_Visible = 0;
            AssignProp("", false, divTablesplittedoperacionesid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedoperacionesid_Visible), 5, 0), true);
            divTablesplittedoperacionid_Visible = 0;
            AssignProp("", false, divTablesplittedoperacionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedoperacionid_Visible), 5, 0), true);
            divTablesplittedwalletid_Visible = 1;
            AssignProp("", false, divTablesplittedwalletid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedwalletid_Visible), 5, 0), true);
            edtavOperacionesfechadesde_Visible = 0;
            AssignProp("", false, edtavOperacionesfechadesde_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOperacionesfechadesde_Visible), 5, 0), true);
            edtavOperacionesfechahasta_Visible = 0;
            AssignProp("", false, edtavOperacionesfechahasta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOperacionesfechahasta_Visible), 5, 0), true);
            edtavOperacionesnombreref_Enabled = 0;
            AssignProp("", false, edtavOperacionesnombreref_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOperacionesnombreref_Enabled), 5, 0), true);
            edtavWalletid_Enabled = 0;
            AssignProp("", false, edtavWalletid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWalletid_Enabled), 5, 0), true);
            edtavImporte_Visible = 1;
            AssignProp("", false, edtavImporte_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavImporte_Visible), 5, 0), true);
            cmbavWalletbalancesconcepto.Visible = 1;
            AssignProp("", false, cmbavWalletbalancesconcepto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavWalletbalancesconcepto.Visible), 5, 0), true);
            edtavWalletbalancesobs_Visible = 1;
            AssignProp("", false, edtavWalletbalancesobs_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWalletbalancesobs_Visible), 5, 0), true);
            edtavWalletbalancesurl_Visible = 1;
            AssignProp("", false, edtavWalletbalancesurl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWalletbalancesurl_Visible), 5, 0), true);
            if ( AV25inWalletId == 0 )
            {
               AV22WalletId = 0;
               AssignAttri("", false, "AV22WalletId", StringUtil.LTrimStr( (decimal)(AV22WalletId), 18, 0));
               AV11OperacionesNombreRef = "";
               AssignAttri("", false, "AV11OperacionesNombreRef", AV11OperacionesNombreRef);
            }
         }
         else if ( StringUtil.StrCmp(AV13OperacionesTipo, "NDE") == 0 )
         {
            AV21TipoMov = "DEB";
            AssignAttri("", false, "AV21TipoMov", AV21TipoMov);
            divTablesplittedprofesionalesid_Visible = 0;
            AssignProp("", false, divTablesplittedprofesionalesid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedprofesionalesid_Visible), 5, 0), true);
            divTablesplittedproveedorid_Visible = 0;
            AssignProp("", false, divTablesplittedproveedorid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedproveedorid_Visible), 5, 0), true);
            divTablesplittedoperacionesid_Visible = 0;
            AssignProp("", false, divTablesplittedoperacionesid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedoperacionesid_Visible), 5, 0), true);
            divTablesplittedoperacionid_Visible = 0;
            AssignProp("", false, divTablesplittedoperacionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedoperacionid_Visible), 5, 0), true);
            divTablesplittedwalletid_Visible = 1;
            AssignProp("", false, divTablesplittedwalletid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesplittedwalletid_Visible), 5, 0), true);
            edtavOperacionesfechadesde_Visible = 0;
            AssignProp("", false, edtavOperacionesfechadesde_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOperacionesfechadesde_Visible), 5, 0), true);
            edtavOperacionesfechahasta_Visible = 0;
            AssignProp("", false, edtavOperacionesfechahasta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOperacionesfechahasta_Visible), 5, 0), true);
            edtavOperacionesnombreref_Enabled = 1;
            AssignProp("", false, edtavOperacionesnombreref_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOperacionesnombreref_Enabled), 5, 0), true);
            edtavImporte_Visible = 1;
            AssignProp("", false, edtavImporte_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavImporte_Visible), 5, 0), true);
            cmbavWalletbalancesconcepto.Visible = 1;
            AssignProp("", false, cmbavWalletbalancesconcepto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavWalletbalancesconcepto.Visible), 5, 0), true);
            edtavWalletbalancesobs_Visible = 1;
            AssignProp("", false, edtavWalletbalancesobs_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWalletbalancesobs_Visible), 5, 0), true);
            edtavWalletbalancesurl_Visible = 1;
            AssignProp("", false, edtavWalletbalancesurl_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavWalletbalancesurl_Visible), 5, 0), true);
            edtavWalletid_Enabled = 0;
            AssignProp("", false, edtavWalletid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavWalletid_Enabled), 5, 0), true);
            if ( AV25inWalletId == 0 )
            {
               AV22WalletId = 0;
               AssignAttri("", false, "AV22WalletId", StringUtil.LTrimStr( (decimal)(AV22WalletId), 18, 0));
               AV11OperacionesNombreRef = "";
               AssignAttri("", false, "AV11OperacionesNombreRef", AV11OperacionesNombreRef);
            }
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E14DO2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table6_142_DO2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_generartodos_Internalname, tblTabledvelop_confirmpanel_generartodos_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_generartodos.SetProperty("Title", Dvelop_confirmpanel_generartodos_Title);
            ucDvelop_confirmpanel_generartodos.SetProperty("ConfirmationText", Dvelop_confirmpanel_generartodos_Confirmationtext);
            ucDvelop_confirmpanel_generartodos.SetProperty("YesButtonCaption", Dvelop_confirmpanel_generartodos_Yesbuttoncaption);
            ucDvelop_confirmpanel_generartodos.SetProperty("NoButtonCaption", Dvelop_confirmpanel_generartodos_Nobuttoncaption);
            ucDvelop_confirmpanel_generartodos.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_generartodos_Cancelbuttoncaption);
            ucDvelop_confirmpanel_generartodos.SetProperty("YesButtonPosition", Dvelop_confirmpanel_generartodos_Yesbuttonposition);
            ucDvelop_confirmpanel_generartodos.SetProperty("ConfirmType", Dvelop_confirmpanel_generartodos_Confirmtype);
            ucDvelop_confirmpanel_generartodos.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_generartodos_Internalname, "DVELOP_CONFIRMPANEL_GENERARTODOSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_GENERARTODOSContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table6_142_DO2e( true) ;
         }
         else
         {
            wb_table6_142_DO2e( false) ;
         }
      }

      protected void wb_table5_81_DO2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedwalletid_Internalname, tblTablemergedwalletid_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWalletid_Internalname, context.GetMessage( "Wallet Id", ""), "gx-form-item AttributeFLLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWalletid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22WalletId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV22WalletId), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,85);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWalletid_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavWalletid_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_OperacionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Static images/pictures */
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgPrompt_walletid_gximage, "")==0) ? "GX_Image_prompt_Class" : "GX_Image_"+imgPrompt_walletid_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgPrompt_walletid_Internalname, sImgUrl, imgPrompt_walletid_Link, "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_OperacionWP.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_81_DO2e( true) ;
         }
         else
         {
            wb_table5_81_DO2e( false) ;
         }
      }

      protected void wb_table4_67_DO2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedoperacionid_Internalname, tblTablemergedoperacionid_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOperacionid_Internalname, context.GetMessage( "Operacion Id", ""), "gx-form-item AttributeFLLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOperacionid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19OperacionId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavOperacionid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV19OperacionId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV19OperacionId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOperacionid_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavOperacionid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_OperacionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Static images/pictures */
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgPrompt_operacionid_gximage, "")==0) ? "GX_Image_prompt_Class" : "GX_Image_"+imgPrompt_operacionid_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgPrompt_operacionid_Internalname, sImgUrl, imgPrompt_operacionid_Link, "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_OperacionWP.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_67_DO2e( true) ;
         }
         else
         {
            wb_table4_67_DO2e( false) ;
         }
      }

      protected void wb_table3_53_DO2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedoperacionesid_Internalname, tblTablemergedoperacionesid_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOperacionesid_Internalname, context.GetMessage( "Operaciones Id", ""), "gx-form-item AttributeFLLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOperacionesid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10OperacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavOperacionesid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV10OperacionesId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV10OperacionesId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOperacionesid_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavOperacionesid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_OperacionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Static images/pictures */
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgPrompt_operacionesid_gximage, "")==0) ? "GX_Image_prompt_Class" : "GX_Image_"+imgPrompt_operacionesid_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgPrompt_operacionesid_Internalname, sImgUrl, imgPrompt_operacionesid_Link, "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_OperacionWP.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_53_DO2e( true) ;
         }
         else
         {
            wb_table3_53_DO2e( false) ;
         }
      }

      protected void wb_table2_39_DO2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedproveedorid_Internalname, tblTablemergedproveedorid_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProveedorid_Internalname, context.GetMessage( "Proveedor ID", ""), "gx-form-item AttributeFLLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProveedorid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavProveedorid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV15ProveedorID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV15ProveedorID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProveedorid_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavProveedorid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_OperacionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Static images/pictures */
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgPrompt_proveedorid_gximage, "")==0) ? "GX_Image_prompt_Class" : "GX_Image_"+imgPrompt_proveedorid_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgPrompt_proveedorid_Internalname, sImgUrl, imgPrompt_proveedorid_Link, "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_OperacionWP.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_39_DO2e( true) ;
         }
         else
         {
            wb_table2_39_DO2e( false) ;
         }
      }

      protected void wb_table1_25_DO2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedprofesionalesid_Internalname, tblTablemergedprofesionalesid_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProfesionalesid_Internalname, context.GetMessage( "Profesionales Id", ""), "gx-form-item AttributeFLLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProfesionalesid_Internalname, StringUtil.RTrim( AV14ProfesionalesId), StringUtil.RTrim( context.localUtil.Format( AV14ProfesionalesId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "123456789", edtavProfesionalesid_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavProfesionalesid_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_OperacionWP.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Static images/pictures */
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgPrompt_profesionalesid_gximage, "")==0) ? "GX_Image_prompt_Class" : "GX_Image_"+imgPrompt_profesionalesid_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgPrompt_profesionalesid_Internalname, sImgUrl, imgPrompt_profesionalesid_Link, "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_OperacionWP.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_25_DO2e( true) ;
         }
         else
         {
            wb_table1_25_DO2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV24inOperacionesTipo = (string)getParm(obj,0);
         AssignAttri("", false, "AV24inOperacionesTipo", AV24inOperacionesTipo);
         GxWebStd.gx_hidden_field( context, "gxhash_vINOPERACIONESTIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV24inOperacionesTipo, "")), context));
         AV25inWalletId = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV25inWalletId", StringUtil.LTrimStr( (decimal)(AV25inWalletId), 18, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vINWALLETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV25inWalletId), "ZZZZZZZZZZZZZZZZZ9"), context));
         AV27inOperacionesNombreRef = (string)getParm(obj,2);
         AssignAttri("", false, "AV27inOperacionesNombreRef", AV27inOperacionesNombreRef);
         GxWebStd.gx_hidden_field( context, "gxhash_vINOPERACIONESNOMBREREF", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV27inOperacionesNombreRef, "")), context));
         AV28inOperacion = Convert.ToInt64(getParm(obj,3));
         AssignAttri("", false, "AV28inOperacion", StringUtil.LTrimStr( (decimal)(AV28inOperacion), 18, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vINOPERACION", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV28inOperacion), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         PADO2( ) ;
         WSDO2( ) ;
         WEDO2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269282145279", true, true, false);
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
         context.AddJavascriptSource("operacionwp.js", "?20269282145279", false, true, false);
         context.AddJavascriptSource("Toastr/toastr.min.js", "", false, true, false);
         context.AddJavascriptSource("Toastr/ToastrRender.js", "", false, true, false);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavOperacionestipo.Name = "vOPERACIONESTIPO";
         cmbavOperacionestipo.WebTags = "";
         cmbavOperacionestipo.addItem("LSF", context.GetMessage( "Liquidación de Solicitudes del Profesional", ""), 0);
         cmbavOperacionestipo.addItem("LSC", context.GetMessage( "Liquidación de  Solicitudes Comercio", ""), 0);
         cmbavOperacionestipo.addItem("COL", context.GetMessage( "Cobro de Saldo Pendiente", ""), 0);
         cmbavOperacionestipo.addItem("POL", context.GetMessage( "Pago de Saldo", ""), 0);
         cmbavOperacionestipo.addItem("CSO", context.GetMessage( "Cobro de Solicitud", ""), 0);
         cmbavOperacionestipo.addItem("NCR", context.GetMessage( "Nota de Credito", ""), 0);
         cmbavOperacionestipo.addItem("NDE", context.GetMessage( "Nota de Debito", ""), 0);
         cmbavOperacionestipo.addItem("OTR", context.GetMessage( "Otros", ""), 0);
         cmbavOperacionestipo.addItem("FEN", context.GetMessage( "Solicitudes ingresadas desde Fenicio", ""), 0);
         cmbavOperacionestipo.addItem("FGO", context.GetMessage( "Respuesta de api fenicio", ""), 0);
         cmbavOperacionestipo.addItem("CEX", context.GetMessage( "COMERCIO_EXTERNO", ""), 0);
         if ( cmbavOperacionestipo.ItemCount > 0 )
         {
            AV13OperacionesTipo = cmbavOperacionestipo.getValidValue(AV13OperacionesTipo);
            AssignAttri("", false, "AV13OperacionesTipo", AV13OperacionesTipo);
         }
         cmbavWalletbalancesconcepto.Name = "vWALLETBALANCESCONCEPTO";
         cmbavWalletbalancesconcepto.WebTags = "";
         cmbavWalletbalancesconcepto.addItem("1", context.GetMessage( "Pago Enviado", ""), 0);
         cmbavWalletbalancesconcepto.addItem("2", context.GetMessage( "Pago Recibido", ""), 0);
         cmbavWalletbalancesconcepto.addItem("3", context.GetMessage( "Deuda", ""), 0);
         cmbavWalletbalancesconcepto.addItem("4", context.GetMessage( "Crédito", ""), 0);
         cmbavWalletbalancesconcepto.addItem("5", context.GetMessage( "Liquidación", ""), 0);
         cmbavWalletbalancesconcepto.addItem("6", context.GetMessage( "Saldo Inicial", ""), 0);
         if ( cmbavWalletbalancesconcepto.ItemCount > 0 )
         {
            AV31WalletBalancesConcepto = (short)(Math.Round(NumberUtil.Val( cmbavWalletbalancesconcepto.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV31WalletBalancesConcepto), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV31WalletBalancesConcepto", StringUtil.LTrimStr( (decimal)(AV31WalletBalancesConcepto), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         cmbavOperacionestipo_Internalname = "vOPERACIONESTIPO";
         lblTextblockprofesionalesid_Internalname = "TEXTBLOCKPROFESIONALESID";
         edtavProfesionalesid_Internalname = "vPROFESIONALESID";
         imgPrompt_profesionalesid_Internalname = "PROMPT_PROFESIONALESID";
         tblTablemergedprofesionalesid_Internalname = "TABLEMERGEDPROFESIONALESID";
         divTablesplittedprofesionalesid_Internalname = "TABLESPLITTEDPROFESIONALESID";
         lblTextblockproveedorid_Internalname = "TEXTBLOCKPROVEEDORID";
         edtavProveedorid_Internalname = "vPROVEEDORID";
         imgPrompt_proveedorid_Internalname = "PROMPT_PROVEEDORID";
         tblTablemergedproveedorid_Internalname = "TABLEMERGEDPROVEEDORID";
         divTablesplittedproveedorid_Internalname = "TABLESPLITTEDPROVEEDORID";
         lblTextblockoperacionesid_Internalname = "TEXTBLOCKOPERACIONESID";
         edtavOperacionesid_Internalname = "vOPERACIONESID";
         imgPrompt_operacionesid_Internalname = "PROMPT_OPERACIONESID";
         tblTablemergedoperacionesid_Internalname = "TABLEMERGEDOPERACIONESID";
         divTablesplittedoperacionesid_Internalname = "TABLESPLITTEDOPERACIONESID";
         lblTextblockoperacionid_Internalname = "TEXTBLOCKOPERACIONID";
         edtavOperacionid_Internalname = "vOPERACIONID";
         imgPrompt_operacionid_Internalname = "PROMPT_OPERACIONID";
         tblTablemergedoperacionid_Internalname = "TABLEMERGEDOPERACIONID";
         divTablesplittedoperacionid_Internalname = "TABLESPLITTEDOPERACIONID";
         lblTextblockwalletid_Internalname = "TEXTBLOCKWALLETID";
         edtavWalletid_Internalname = "vWALLETID";
         imgPrompt_walletid_Internalname = "PROMPT_WALLETID";
         tblTablemergedwalletid_Internalname = "TABLEMERGEDWALLETID";
         divTablesplittedwalletid_Internalname = "TABLESPLITTEDWALLETID";
         edtavOperacionesnombreref_Internalname = "vOPERACIONESNOMBREREF";
         cmbavWalletbalancesconcepto_Internalname = "vWALLETBALANCESCONCEPTO";
         edtavImporte_Internalname = "vIMPORTE";
         edtavWalletbalancesobs_Internalname = "vWALLETBALANCESOBS";
         edtavWalletbalancesurl_Internalname = "vWALLETBALANCESURL";
         edtavOperacionesfechadesde_Internalname = "vOPERACIONESFECHADESDE";
         edtavOperacionesfechahasta_Internalname = "vOPERACIONESFECHAHASTA";
         divTb2_Internalname = "TB2";
         bttBtngenerar_Internalname = "BTNGENERAR";
         bttBtncancel_Internalname = "BTNCANCEL";
         bttBtngenerartodos_Internalname = "BTNGENERARTODOS";
         divTablecontent_Internalname = "TABLECONTENT";
         Toastr1_Internalname = "TOASTR1";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         divTablemain_Internalname = "TABLEMAIN";
         edtavOperacionesref_Internalname = "vOPERACIONESREF";
         Dvelop_confirmpanel_generartodos_Internalname = "DVELOP_CONFIRMPANEL_GENERARTODOS";
         tblTabledvelop_confirmpanel_generartodos_Internalname = "TABLEDVELOP_CONFIRMPANEL_GENERARTODOS";
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
         imgPrompt_profesionalesid_Link = "";
         edtavProfesionalesid_Jsonclick = "";
         edtavProfesionalesid_Enabled = 1;
         imgPrompt_proveedorid_Link = "";
         edtavProveedorid_Jsonclick = "";
         edtavProveedorid_Enabled = 1;
         imgPrompt_operacionesid_Link = "";
         edtavOperacionesid_Jsonclick = "";
         edtavOperacionesid_Enabled = 1;
         imgPrompt_operacionid_Link = "";
         edtavOperacionid_Jsonclick = "";
         edtavOperacionid_Enabled = 1;
         imgPrompt_walletid_Link = "";
         edtavWalletid_Jsonclick = "";
         edtavWalletid_Enabled = 1;
         edtavOperacionesref_Jsonclick = "";
         edtavOperacionesref_Visible = 1;
         bttBtngenerartodos_Visible = 1;
         edtavOperacionesfechahasta_Jsonclick = "";
         edtavOperacionesfechahasta_Enabled = 1;
         edtavOperacionesfechahasta_Visible = 1;
         edtavOperacionesfechadesde_Jsonclick = "";
         edtavOperacionesfechadesde_Enabled = 1;
         edtavOperacionesfechadesde_Visible = 1;
         edtavWalletbalancesurl_Jsonclick = "";
         edtavWalletbalancesurl_Enabled = 1;
         edtavWalletbalancesurl_Visible = 1;
         edtavWalletbalancesobs_Jsonclick = "";
         edtavWalletbalancesobs_Enabled = 1;
         edtavWalletbalancesobs_Visible = 1;
         edtavImporte_Jsonclick = "";
         edtavImporte_Enabled = 1;
         edtavImporte_Visible = 1;
         cmbavWalletbalancesconcepto_Jsonclick = "";
         cmbavWalletbalancesconcepto.Enabled = 1;
         cmbavWalletbalancesconcepto.Visible = 1;
         edtavOperacionesnombreref_Jsonclick = "";
         edtavOperacionesnombreref_Enabled = 1;
         divTablesplittedwalletid_Visible = 1;
         divTablesplittedoperacionid_Visible = 1;
         divTablesplittedoperacionesid_Visible = 1;
         divTablesplittedproveedorid_Visible = 1;
         divTablesplittedprofesionalesid_Visible = 1;
         cmbavOperacionestipo_Jsonclick = "";
         cmbavOperacionestipo.Enabled = 1;
         Dvelop_confirmpanel_generartodos_Confirmtype = "1";
         Dvelop_confirmpanel_generartodos_Yesbuttonposition = "left";
         Dvelop_confirmpanel_generartodos_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_generartodos_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_generartodos_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_generartodos_Confirmationtext = "¿Desea generar automaticamente todas las liquidaciones?";
         Dvelop_confirmpanel_generartodos_Title = context.GetMessage( "ATENCIÓN", "");
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Movimientos", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV17Titulo',fld:'vTITULO',pic:'',hsh:true,type:'svchar'},{av:'Gx_msg',fld:'vMSG',pic:'',hsh:true,type:'char'},{av:'AV27inOperacionesNombreRef',fld:'vINOPERACIONESNOMBREREF',pic:'',hsh:true,type:'char'},{av:'AV25inWalletId',fld:'vINWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV24inOperacionesTipo',fld:'vINOPERACIONESTIPO',pic:'',hsh:true,type:'char'},{av:'AV28inOperacion',fld:'vINOPERACION',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOGENERAR'","{handler:'E13DO2',iparms:[{av:'AV11OperacionesNombreRef',fld:'vOPERACIONESNOMBREREF',pic:'',type:'char'},{av:'AV8OperacionesFechaDesde',fld:'vOPERACIONESFECHADESDE',pic:'',type:'date'},{av:'AV9OperacionesFechaHasta',fld:'vOPERACIONESFECHAHASTA',pic:'',type:'date'},{av:'AV10OperacionesId',fld:'vOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV19OperacionId',fld:'vOPERACIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22WalletId',fld:'vWALLETID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV23Importe',fld:'vIMPORTE',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'cmbavOperacionestipo'},{av:'AV13OperacionesTipo',fld:'vOPERACIONESTIPO',pic:'',type:'char'},{av:'AV14ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'AV15ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV21TipoMov',fld:'vTIPOMOV',pic:'',type:'char'},{av:'AV33WalletBalancesUrl',fld:'vWALLETBALANCESURL',pic:'',type:'svchar'},{av:'AV32WalletBalancesObs',fld:'vWALLETBALANCESOBS',pic:'',type:'svchar'},{av:'cmbavWalletbalancesconcepto'},{av:'AV31WalletBalancesConcepto',fld:'vWALLETBALANCESCONCEPTO',pic:'ZZZ9',type:'int'},{av:'AV7isOk',fld:'vISOK',pic:'',type:'boolean'},{av:'AV17Titulo',fld:'vTITULO',pic:'',hsh:true,type:'svchar'},{av:'Gx_msg',fld:'vMSG',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("'DOGENERAR'",",oparms:[{av:'AV21TipoMov',fld:'vTIPOMOV',pic:'',type:'char'},{av:'AV10OperacionesId',fld:'vOPERACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7isOk',fld:'vISOK',pic:'',type:'boolean'},{av:'AV12OperacionesRef',fld:'vOPERACIONESREF',pic:'',type:'char'}]}");
         setEventMetadata("'DOGENERARTODOS'","{handler:'E11DO1',iparms:[{av:'cmbavOperacionestipo'},{av:'AV13OperacionesTipo',fld:'vOPERACIONESTIPO',pic:'',type:'char'},{av:'AV7isOk',fld:'vISOK',pic:'',type:'boolean'},{av:'AV17Titulo',fld:'vTITULO',pic:'',hsh:true,type:'svchar'},{av:'Gx_msg',fld:'vMSG',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("'DOGENERARTODOS'",",oparms:[]}");
         setEventMetadata("VALIDV_OPERACIONESTIPO","{handler:'Validv_Operacionestipo',iparms:[]");
         setEventMetadata("VALIDV_OPERACIONESTIPO",",oparms:[]}");
         setEventMetadata("VALIDV_WALLETBALANCESCONCEPTO","{handler:'Validv_Walletbalancesconcepto',iparms:[]");
         setEventMetadata("VALIDV_WALLETBALANCESCONCEPTO",",oparms:[]}");
         setEventMetadata("VALIDV_WALLETBALANCESURL","{handler:'Validv_Walletbalancesurl',iparms:[]");
         setEventMetadata("VALIDV_WALLETBALANCESURL",",oparms:[]}");
         setEventMetadata("VALIDV_OPERACIONESFECHADESDE","{handler:'Validv_Operacionesfechadesde',iparms:[]");
         setEventMetadata("VALIDV_OPERACIONESFECHADESDE",",oparms:[]}");
         setEventMetadata("VALIDV_OPERACIONESFECHAHASTA","{handler:'Validv_Operacionesfechahasta',iparms:[]");
         setEventMetadata("VALIDV_OPERACIONESFECHAHASTA",",oparms:[]}");
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
         wcpOAV24inOperacionesTipo = "";
         wcpOAV27inOperacionesNombreRef = "";
         Dvelop_confirmpanel_generartodos_Result = "";
         NV11OperacionesNombreRef = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV17Titulo = "";
         Gx_msg = "";
         AV21TipoMov = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV13OperacionesTipo = "";
         lblTextblockprofesionalesid_Jsonclick = "";
         lblTextblockproveedorid_Jsonclick = "";
         lblTextblockoperacionesid_Jsonclick = "";
         lblTextblockoperacionid_Jsonclick = "";
         lblTextblockwalletid_Jsonclick = "";
         AV11OperacionesNombreRef = "";
         AV32WalletBalancesObs = "";
         AV33WalletBalancesUrl = "";
         AV8OperacionesFechaDesde = DateTime.MinValue;
         AV9OperacionesFechaHasta = DateTime.MinValue;
         bttBtngenerar_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         bttBtngenerartodos_Jsonclick = "";
         ucToastr1 = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         AV12OperacionesRef = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV14ProfesionalesId = "";
         AV29Windows = new GXWindow();
         AV30Mensaje = "";
         sStyleString = "";
         ucDvelop_confirmpanel_generartodos = new GXUserControl();
         imgPrompt_walletid_gximage = "";
         sImgUrl = "";
         imgPrompt_operacionid_gximage = "";
         imgPrompt_operacionesid_gximage = "";
         imgPrompt_proveedorid_gximage = "";
         imgPrompt_profesionalesid_gximage = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
         imgPrompt_profesionalesid_Link = "javascript:"+"gx.popup.openPrompt('"+"profesionalesfullnameprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"vPROFESIONALESID"+"'), id:'"+"vPROFESIONALESID"+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"vOPERACIONESNOMBREREF"+"'), id:'"+"vOPERACIONESNOMBREREF"+"'"+",IOType:'inout'}"+"],"+"null"+","+"'', false"+","+"false"+");";
         imgPrompt_proveedorid_Link = "javascript:"+"gx.popup.openPrompt('"+"comercioprompt1.aspx"+"',["+"{Ctrl:gx.dom.el('"+"vPROVEEDORID"+"'), id:'"+"vPROVEEDORID"+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"vOPERACIONESNOMBREREF"+"'), id:'"+"vOPERACIONESNOMBREREF"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");";
         imgPrompt_operacionesid_Link = "javascript:"+"gx.popup.openPrompt('"+"operacionesidprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"vOPERACIONESID"+"'), id:'"+"vOPERACIONESID"+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"vOPERACIONESNOMBREREF"+"'), id:'"+"vOPERACIONESNOMBREREF"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");";
         imgPrompt_operacionid_Link = "javascript:"+"gx.popup.openPrompt('"+"operacionesid2prompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"vOPERACIONID"+"'), id:'"+"vOPERACIONID"+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"vOPERACIONESNOMBREREF"+"'), id:'"+"vOPERACIONESNOMBREREF"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");";
         imgPrompt_walletid_Link = "javascript:"+"gx.popup.openPrompt('"+"walletprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"vWALLETID"+"'), id:'"+"vWALLETID"+"'"+",IOType:'inout'}"+"],"+"null"+","+"'', false"+","+"false"+");";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV31WalletBalancesConcepto ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int divTablesplittedprofesionalesid_Visible ;
      private int divTablesplittedproveedorid_Visible ;
      private int divTablesplittedoperacionesid_Visible ;
      private int divTablesplittedoperacionid_Visible ;
      private int divTablesplittedwalletid_Visible ;
      private int edtavOperacionesnombreref_Enabled ;
      private int edtavImporte_Visible ;
      private int edtavImporte_Enabled ;
      private int edtavWalletbalancesobs_Visible ;
      private int edtavWalletbalancesobs_Enabled ;
      private int edtavWalletbalancesurl_Visible ;
      private int edtavWalletbalancesurl_Enabled ;
      private int edtavOperacionesfechadesde_Visible ;
      private int edtavOperacionesfechadesde_Enabled ;
      private int edtavOperacionesfechahasta_Visible ;
      private int edtavOperacionesfechahasta_Enabled ;
      private int bttBtngenerartodos_Visible ;
      private int edtavOperacionesref_Visible ;
      private int edtavWalletid_Enabled ;
      private int edtavOperacionid_Enabled ;
      private int edtavOperacionesid_Enabled ;
      private int edtavProveedorid_Enabled ;
      private int edtavProfesionalesid_Enabled ;
      private int idxLst ;
      private long AV25inWalletId ;
      private long AV28inOperacion ;
      private long wcpOAV25inWalletId ;
      private long wcpOAV28inOperacion ;
      private long AV15ProveedorID ;
      private long AV10OperacionesId ;
      private long AV19OperacionId ;
      private long AV22WalletId ;
      private decimal AV23Importe ;
      private string AV24inOperacionesTipo ;
      private string AV27inOperacionesNombreRef ;
      private string wcpOAV24inOperacionesTipo ;
      private string wcpOAV27inOperacionesNombreRef ;
      private string Dvelop_confirmpanel_generartodos_Result ;
      private string NV11OperacionesNombreRef ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Gx_msg ;
      private string AV21TipoMov ;
      private string Dvelop_confirmpanel_generartodos_Title ;
      private string Dvelop_confirmpanel_generartodos_Confirmationtext ;
      private string Dvelop_confirmpanel_generartodos_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_generartodos_Nobuttoncaption ;
      private string Dvelop_confirmpanel_generartodos_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_generartodos_Yesbuttonposition ;
      private string Dvelop_confirmpanel_generartodos_Confirmtype ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string cmbavOperacionestipo_Internalname ;
      private string TempTags ;
      private string AV13OperacionesTipo ;
      private string cmbavOperacionestipo_Jsonclick ;
      private string divTablesplittedprofesionalesid_Internalname ;
      private string lblTextblockprofesionalesid_Internalname ;
      private string lblTextblockprofesionalesid_Jsonclick ;
      private string divTablesplittedproveedorid_Internalname ;
      private string lblTextblockproveedorid_Internalname ;
      private string lblTextblockproveedorid_Jsonclick ;
      private string divTablesplittedoperacionesid_Internalname ;
      private string lblTextblockoperacionesid_Internalname ;
      private string lblTextblockoperacionesid_Jsonclick ;
      private string divTablesplittedoperacionid_Internalname ;
      private string lblTextblockoperacionid_Internalname ;
      private string lblTextblockoperacionid_Jsonclick ;
      private string divTablesplittedwalletid_Internalname ;
      private string lblTextblockwalletid_Internalname ;
      private string lblTextblockwalletid_Jsonclick ;
      private string divTb2_Internalname ;
      private string edtavOperacionesnombreref_Internalname ;
      private string AV11OperacionesNombreRef ;
      private string edtavOperacionesnombreref_Jsonclick ;
      private string cmbavWalletbalancesconcepto_Internalname ;
      private string cmbavWalletbalancesconcepto_Jsonclick ;
      private string edtavImporte_Internalname ;
      private string edtavImporte_Jsonclick ;
      private string edtavWalletbalancesobs_Internalname ;
      private string edtavWalletbalancesobs_Jsonclick ;
      private string edtavWalletbalancesurl_Internalname ;
      private string edtavWalletbalancesurl_Jsonclick ;
      private string edtavOperacionesfechadesde_Internalname ;
      private string edtavOperacionesfechadesde_Jsonclick ;
      private string edtavOperacionesfechahasta_Internalname ;
      private string edtavOperacionesfechahasta_Jsonclick ;
      private string bttBtngenerar_Internalname ;
      private string bttBtngenerar_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string bttBtngenerartodos_Internalname ;
      private string bttBtngenerartodos_Jsonclick ;
      private string Toastr1_Internalname ;
      private string Innewwindow1_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavOperacionesref_Internalname ;
      private string AV12OperacionesRef ;
      private string edtavOperacionesref_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string imgPrompt_profesionalesid_Link ;
      private string imgPrompt_profesionalesid_Internalname ;
      private string imgPrompt_proveedorid_Link ;
      private string imgPrompt_proveedorid_Internalname ;
      private string imgPrompt_operacionesid_Link ;
      private string imgPrompt_operacionesid_Internalname ;
      private string imgPrompt_operacionid_Link ;
      private string imgPrompt_operacionid_Internalname ;
      private string imgPrompt_walletid_Link ;
      private string imgPrompt_walletid_Internalname ;
      private string AV14ProfesionalesId ;
      private string edtavProfesionalesid_Internalname ;
      private string edtavProveedorid_Internalname ;
      private string edtavOperacionesid_Internalname ;
      private string edtavOperacionid_Internalname ;
      private string edtavWalletid_Internalname ;
      private string AV30Mensaje ;
      private string sStyleString ;
      private string tblTabledvelop_confirmpanel_generartodos_Internalname ;
      private string Dvelop_confirmpanel_generartodos_Internalname ;
      private string tblTablemergedwalletid_Internalname ;
      private string edtavWalletid_Jsonclick ;
      private string imgPrompt_walletid_gximage ;
      private string sImgUrl ;
      private string tblTablemergedoperacionid_Internalname ;
      private string edtavOperacionid_Jsonclick ;
      private string imgPrompt_operacionid_gximage ;
      private string tblTablemergedoperacionesid_Internalname ;
      private string edtavOperacionesid_Jsonclick ;
      private string imgPrompt_operacionesid_gximage ;
      private string tblTablemergedproveedorid_Internalname ;
      private string edtavProveedorid_Jsonclick ;
      private string imgPrompt_proveedorid_gximage ;
      private string tblTablemergedprofesionalesid_Internalname ;
      private string edtavProfesionalesid_Jsonclick ;
      private string imgPrompt_profesionalesid_gximage ;
      private DateTime AV8OperacionesFechaDesde ;
      private DateTime AV9OperacionesFechaHasta ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV7isOk ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV35isOkGenerar ;
      private string AV17Titulo ;
      private string AV32WalletBalancesObs ;
      private string AV33WalletBalancesUrl ;
      private GXUserControl ucToastr1 ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucDvelop_confirmpanel_generartodos ;
      private GXWebForm Form ;
      private GXWindow AV29Windows ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavOperacionestipo ;
      private GXCombobox cmbavWalletbalancesconcepto ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
