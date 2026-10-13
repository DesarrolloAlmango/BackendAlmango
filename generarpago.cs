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
   public class generarpago : GXHttpHandler, System.Web.SessionState.IRequiresSessionState
   {
      public generarpago( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public generarpago( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_TipoOpe ,
                           long aP1_Identificador )
      {
         this.AV38TipoOpe = aP0_TipoOpe;
         this.AV5Identificador = aP1_Identificador;
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
            gxfirstwebparm = GetFirstPar( "TipoOpe");
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
               gxfirstwebparm = GetFirstPar( "TipoOpe");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "TipoOpe");
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
               AV38TipoOpe = gxfirstwebparm;
               AssignAttri("", false, "AV38TipoOpe", AV38TipoOpe);
               GxWebStd.gx_hidden_field( context, "gxhash_vTIPOOPE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV38TipoOpe, "")), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV5Identificador = (long)(Math.Round(NumberUtil.Val( GetPar( "Identificador"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV5Identificador", StringUtil.LTrimStr( (decimal)(AV5Identificador), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vIDENTIFICADOR", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5Identificador), "ZZZZZZZZZZZZZZZZZ9"), context));
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
            ValidateSpaRequest();
            PA7S2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavTitulo_Enabled = 0;
               AssignProp("", false, edtavTitulo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTitulo_Enabled), 5, 0), true);
               edtavUrl_Enabled = 0;
               AssignProp("", false, edtavUrl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUrl_Enabled), 5, 0), true);
               WS7S2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE7S2( ) ;
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
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( "") ;
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
         context.AddJavascriptSource("Toastr/toastr.min.js", "", false, true, false);
         context.AddJavascriptSource("Toastr/ToastrRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true, false);
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
         bodyStyle = "";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal FormNoBackgroundColor\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormNoBackgroundColor\" data-gx-class=\"form-horizontal FormNoBackgroundColor\" novalidate action=\""+formatLink("generarpago.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV38TipoOpe)),UrlEncode(StringUtil.LTrimStr(AV5Identificador,18,0))}, new string[] {"TipoOpe","Identificador"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vTIPOOPE", StringUtil.RTrim( AV38TipoOpe));
         GxWebStd.gx_hidden_field( context, "gxhash_vTIPOOPE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV38TipoOpe, "")), context));
         GxWebStd.gx_hidden_field( context, "vIDENTIFICADOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Identificador), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vIDENTIFICADOR", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5Identificador), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPARAMETROSVALOR", AV34ParametrosValor);
         GxWebStd.gx_hidden_field( context, "gxhash_vPARAMETROSVALOR", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV34ParametrosValor, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vTIPOOPE", StringUtil.RTrim( AV38TipoOpe));
         GxWebStd.gx_hidden_field( context, "gxhash_vTIPOOPE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV38TipoOpe, "")), context));
         GxWebStd.gx_hidden_field( context, "vIDENTIFICADOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Identificador), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vIDENTIFICADOR", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5Identificador), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPARAMETROSVALOR", AV34ParametrosValor);
         GxWebStd.gx_hidden_field( context, "gxhash_vPARAMETROSVALOR", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV34ParametrosValor, "")), context));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNGENERAR_Title", StringUtil.RTrim( Dvelop_confirmpanel_btngenerar_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNGENERAR_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_btngenerar_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNGENERAR_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_btngenerar_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNGENERAR_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_btngenerar_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNGENERAR_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_btngenerar_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNGENERAR_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_btngenerar_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNGENERAR_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_btngenerar_Confirmtype));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNGENERAR_Result", StringUtil.RTrim( Dvelop_confirmpanel_btngenerar_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNGENERAR_Result", StringUtil.RTrim( Dvelop_confirmpanel_btngenerar_Result));
      }

      protected void RenderHtmlCloseForm7S2( )
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
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "GenerarPago" ;
      }

      public override string GetPgmdesc( )
      {
         return "" ;
      }

      protected void WB7S0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
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
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "TableMainPrompt", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingLeft30", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CardProfileTitle", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTitulo_Internalname, context.GetMessage( "Titulo", ""), "col-sm-3 AttributeTitleWWPLabel AttributeColorWarningLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 13,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTitulo_Internalname, AV42Titulo, StringUtil.RTrim( context.localUtil.Format( AV42Titulo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,13);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTitulo_Jsonclick, 0, "AttributeTitleWWP AttributeColorWarning", "", "", "", "", 1, edtavTitulo_Enabled, 0, "text", "", 80, "chr", 1, "row", 128, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_GenerarPago.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTbfact_Internalname, divTbfact_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCfserie_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCfserie_Internalname, context.GetMessage( "Serie", ""), " AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCfserie_Internalname, StringUtil.RTrim( AV44CFSerie), StringUtil.RTrim( context.localUtil.Format( AV44CFSerie, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCfserie_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCfserie_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_GenerarPago.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCfnumero_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCfnumero_Internalname, context.GetMessage( "Número", ""), " AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCfnumero_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45CFNumero), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCfnumero_Enabled!=0) ? context.localUtil.Format( (decimal)(AV45CFNumero), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV45CFNumero), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCfnumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCfnumero_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_GenerarPago.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtngenerar_Internalname, "", context.GetMessage( "Generar QR", ""), bttBtngenerar_Jsonclick, 7, context.GetMessage( "Generar QR", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e117s1_client"+"'", TempTags, "", 2, "HLP_GenerarPago.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", context.GetMessage( "QRCode", ""), "col-sm-3 IconButtonLinkLabel", 0, true, "");
            /* Static Bitmap Variable */
            ClassString = "IconButtonLink" + " " + ((StringUtil.StrCmp(imgavQrcode_gximage, "")==0) ? "" : "GX_Image_"+imgavQrcode_gximage+"_Class");
            StyleString = "";
            AV21QRCode_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV21QRCode))&&String.IsNullOrEmpty(StringUtil.RTrim( AV47Qrcode_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV21QRCode)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV21QRCode)) ? AV47Qrcode_GXI : context.PathToRelativeUrl( AV21QRCode));
            GxWebStd.gx_bitmap( context, imgavQrcode_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV21QRCode_IsBlob, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_GenerarPago.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, " ", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GenerarPago.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, " ", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GenerarPago.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "AttributeSizeSmall" + " " + ((StringUtil.StrCmp(imgImage1_gximage, "")==0) ? "GX_Image_LogoColor_Class" : "GX_Image_"+imgImage1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "ea785962-609b-4594-8134-1af1ec04fae4", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_GenerarPago.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, " ", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GenerarPago.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUrl_Internalname, context.GetMessage( "URL", ""), "col-sm-3 AssociationTitleLabel AttributeColorInfoLabel", 0, true, "");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
            ClassString = "AssociationTitle AttributeColorInfo";
            StyleString = "";
            ClassString = "AssociationTitle AttributeColorInfo";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavUrl_Internalname, AV22URL, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", 0, 1, edtavUrl_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_GenerarPago.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucToastr.Render(context, "toastr", Toastr_Internalname, "TOASTRContainer");
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
            wb_table1_55_7S2( true) ;
         }
         else
         {
            wb_table1_55_7S2( false) ;
         }
         return  ;
      }

      protected void wb_table1_55_7S2e( bool wbgen )
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

      protected void START7S2( )
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
         STRUP7S0( ) ;
      }

      protected void WS7S2( )
      {
         START7S2( ) ;
         EVT7S2( ) ;
      }

      protected void EVT7S2( )
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
                        if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_BTNGENERAR.CLOSE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Dvelop_confirmpanel_btngenerar.Close */
                           E127S2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E137S2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E147S2 ();
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

      protected void WE7S2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm7S2( ) ;
            }
         }
      }

      protected void PA7S2( )
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
               GX_FocusControl = edtavTitulo_Internalname;
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF7S2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavTitulo_Enabled = 0;
         AssignProp("", false, edtavTitulo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTitulo_Enabled), 5, 0), true);
         edtavUrl_Enabled = 0;
         AssignProp("", false, edtavUrl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUrl_Enabled), 5, 0), true);
      }

      protected void RF7S2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E147S2 ();
            WB7S0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes7S2( )
      {
         GxWebStd.gx_hidden_field( context, "vPARAMETROSVALOR", AV34ParametrosValor);
         GxWebStd.gx_hidden_field( context, "gxhash_vPARAMETROSVALOR", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV34ParametrosValor, "")), context));
      }

      protected void before_start_formulas( )
      {
         edtavTitulo_Enabled = 0;
         AssignProp("", false, edtavTitulo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTitulo_Enabled), 5, 0), true);
         edtavUrl_Enabled = 0;
         AssignProp("", false, edtavUrl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUrl_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7S0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E137S2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Dvelop_confirmpanel_btngenerar_Title = cgiGet( "DVELOP_CONFIRMPANEL_BTNGENERAR_Title");
            Dvelop_confirmpanel_btngenerar_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_BTNGENERAR_Confirmationtext");
            Dvelop_confirmpanel_btngenerar_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_BTNGENERAR_Yesbuttoncaption");
            Dvelop_confirmpanel_btngenerar_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_BTNGENERAR_Nobuttoncaption");
            Dvelop_confirmpanel_btngenerar_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_BTNGENERAR_Cancelbuttoncaption");
            Dvelop_confirmpanel_btngenerar_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_BTNGENERAR_Yesbuttonposition");
            Dvelop_confirmpanel_btngenerar_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_BTNGENERAR_Confirmtype");
            Dvelop_confirmpanel_btngenerar_Result = cgiGet( "DVELOP_CONFIRMPANEL_BTNGENERAR_Result");
            /* Read variables values. */
            AV42Titulo = cgiGet( edtavTitulo_Internalname);
            AssignAttri("", false, "AV42Titulo", AV42Titulo);
            AV44CFSerie = StringUtil.Upper( cgiGet( edtavCfserie_Internalname));
            AssignAttri("", false, "AV44CFSerie", AV44CFSerie);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCfnumero_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCfnumero_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCFNUMERO");
               GX_FocusControl = edtavCfnumero_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV45CFNumero = 0;
               AssignAttri("", false, "AV45CFNumero", StringUtil.LTrimStr( (decimal)(AV45CFNumero), 18, 0));
            }
            else
            {
               AV45CFNumero = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCfnumero_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV45CFNumero", StringUtil.LTrimStr( (decimal)(AV45CFNumero), 18, 0));
            }
            AV21QRCode = cgiGet( imgavQrcode_Internalname);
            AV22URL = cgiGet( edtavUrl_Internalname);
            AssignAttri("", false, "AV22URL", AV22URL);
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
         E137S2 ();
         if (returnInSub) return;
      }

      protected void E137S2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV42Titulo = StringUtil.Format( context.GetMessage( "QR DE PAGO PARA LA OPERACIÓN: %1", ""), StringUtil.LTrimStr( (decimal)(AV5Identificador), 18, 0), "", "", "", "", "", "", "", "");
         AssignAttri("", false, "AV42Titulo", AV42Titulo);
         new oparametros(context ).execute(  context.GetMessage( "URLPAGOBAMBOO", ""), out  AV34ParametrosValor, out  AV35ParametrosNumerico, out  AV36ParametrosEstado) ;
         AssignAttri("", false, "AV34ParametrosValor", AV34ParametrosValor);
         GxWebStd.gx_hidden_field( context, "gxhash_vPARAMETROSVALOR", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV34ParametrosValor, "")), context));
      }

      protected void E127S2( )
      {
         /* Dvelop_confirmpanel_btngenerar_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_btngenerar_Result, "Yes") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44CFSerie)) || ( AV45CFNumero == 0 ) || ( StringUtil.Len( context.localUtil.Format( (decimal)(AV45CFNumero), "ZZZZZZZZZZZZZZZZZ9")) < 3 ) )
            {
               this.executeUsercontrolMethod("", false, "TOASTRContainer", "Msg", "", new Object[] {(string)"warning",context.GetMessage( "Debe ingresar un número de factura, Una letra y mayor de 3 dígitos.", ""),(string)""});
            }
            else
            {
               divTbfact_Visible = 0;
               AssignProp("", false, divTbfact_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTbfact_Visible), 5, 0), true);
               AV46OperacionesFacturaCod = StringUtil.Format( "%1%2", StringUtil.Trim( AV44CFSerie), StringUtil.Trim( context.localUtil.Format( (decimal)(AV45CFNumero), "ZZZZZZZZZZZZZZZZZ9")), "", "", "", "", "", "", "");
               new generarcobrosolicitud(context ).execute(  AV38TipoOpe,  context.localUtil.Format( (decimal)(AV5Identificador), "ZZZZZZZZZZZZZZZZZ9"),  AV46OperacionesFacturaCod) ;
               AV39stringBase64 = StringUtil.Format( context.GetMessage( "TipoOpe=%1&Identificador=%2", ""), AV38TipoOpe, StringUtil.LTrimStr( (decimal)(AV5Identificador), 18, 0), "", "", "", "", "", "", "");
               AV39stringBase64 = StringUtil.ToBase64( StringUtil.Trim( AV39stringBase64));
               AV22URL = StringUtil.Trim( AV34ParametrosValor) + StringUtil.Trim( AV39stringBase64);
               AssignAttri("", false, "AV22URL", AV22URL);
               AV19linkURL = context.GetMessage( "https://sdx.genexus.com/agetqrcode.aspx?", "") + AV22URL;
               AV21QRCode = AV19linkURL;
               AssignProp("", false, imgavQrcode_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV21QRCode)) ? AV47Qrcode_GXI : context.convertURL( context.PathToRelativeUrl( AV21QRCode))), true);
               AssignProp("", false, imgavQrcode_Internalname, "SrcSet", context.GetImageSrcSet( AV21QRCode), true);
               AV47Qrcode_GXI = GXDbFile.PathToUrl( AV19linkURL, context);
               AssignProp("", false, imgavQrcode_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV21QRCode)) ? AV47Qrcode_GXI : context.convertURL( context.PathToRelativeUrl( AV21QRCode))), true);
               AssignProp("", false, imgavQrcode_Internalname, "SrcSet", context.GetImageSrcSet( AV21QRCode), true);
            }
         }
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E147S2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_55_7S2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_btngenerar_Internalname, tblTabledvelop_confirmpanel_btngenerar_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_btngenerar.SetProperty("Title", Dvelop_confirmpanel_btngenerar_Title);
            ucDvelop_confirmpanel_btngenerar.SetProperty("ConfirmationText", Dvelop_confirmpanel_btngenerar_Confirmationtext);
            ucDvelop_confirmpanel_btngenerar.SetProperty("YesButtonCaption", Dvelop_confirmpanel_btngenerar_Yesbuttoncaption);
            ucDvelop_confirmpanel_btngenerar.SetProperty("NoButtonCaption", Dvelop_confirmpanel_btngenerar_Nobuttoncaption);
            ucDvelop_confirmpanel_btngenerar.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_btngenerar_Cancelbuttoncaption);
            ucDvelop_confirmpanel_btngenerar.SetProperty("YesButtonPosition", Dvelop_confirmpanel_btngenerar_Yesbuttonposition);
            ucDvelop_confirmpanel_btngenerar.SetProperty("ConfirmType", Dvelop_confirmpanel_btngenerar_Confirmtype);
            ucDvelop_confirmpanel_btngenerar.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_btngenerar_Internalname, "DVELOP_CONFIRMPANEL_BTNGENERARContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_BTNGENERARContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_55_7S2e( true) ;
         }
         else
         {
            wb_table1_55_7S2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV38TipoOpe = (string)getParm(obj,0);
         AssignAttri("", false, "AV38TipoOpe", AV38TipoOpe);
         GxWebStd.gx_hidden_field( context, "gxhash_vTIPOOPE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV38TipoOpe, "")), context));
         AV5Identificador = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV5Identificador", StringUtil.LTrimStr( (decimal)(AV5Identificador), 18, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vIDENTIFICADOR", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5Identificador), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         PA7S2( ) ;
         WS7S2( ) ;
         WE7S2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269282144673", true, true, false);
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
         context.AddJavascriptSource("generarpago.js", "?20269282144673", false, true, false);
         context.AddJavascriptSource("Toastr/toastr.min.js", "", false, true, false);
         context.AddJavascriptSource("Toastr/ToastrRender.js", "", false, true, false);
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
         edtavTitulo_Internalname = "vTITULO";
         edtavCfserie_Internalname = "vCFSERIE";
         edtavCfnumero_Internalname = "vCFNUMERO";
         bttBtngenerar_Internalname = "BTNGENERAR";
         divTbfact_Internalname = "TBFACT";
         imgavQrcode_Internalname = "vQRCODE";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         imgImage1_Internalname = "IMAGE1";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtavUrl_Internalname = "vURL";
         divTable2_Internalname = "TABLE2";
         Toastr_Internalname = "TOASTR";
         divMaintable_Internalname = "MAINTABLE";
         Dvelop_confirmpanel_btngenerar_Internalname = "DVELOP_CONFIRMPANEL_BTNGENERAR";
         tblTabledvelop_confirmpanel_btngenerar_Internalname = "TABLEDVELOP_CONFIRMPANEL_BTNGENERAR";
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
         edtavUrl_Enabled = 1;
         imgavQrcode_gximage = "";
         edtavCfnumero_Jsonclick = "";
         edtavCfnumero_Enabled = 1;
         edtavCfserie_Jsonclick = "";
         edtavCfserie_Enabled = 1;
         divTbfact_Visible = 1;
         edtavTitulo_Jsonclick = "";
         edtavTitulo_Enabled = 1;
         Dvelop_confirmpanel_btngenerar_Confirmtype = "1";
         Dvelop_confirmpanel_btngenerar_Yesbuttonposition = "left";
         Dvelop_confirmpanel_btngenerar_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_btngenerar_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_btngenerar_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_btngenerar_Confirmationtext = "Confirma  el Número de Factura Ingresado";
         Dvelop_confirmpanel_btngenerar_Title = context.GetMessage( "Atención", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV38TipoOpe',fld:'vTIPOOPE',pic:'',hsh:true,type:'char'},{av:'AV5Identificador',fld:'vIDENTIFICADOR',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV34ParametrosValor',fld:'vPARAMETROSVALOR',pic:'',hsh:true,type:'svchar'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOGENERAR'","{handler:'E117S1',iparms:[]");
         setEventMetadata("'DOGENERAR'",",oparms:[]}");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNGENERAR.CLOSE","{handler:'E127S2',iparms:[{av:'Dvelop_confirmpanel_btngenerar_Result',ctrl:'DVELOP_CONFIRMPANEL_BTNGENERAR',prop:'Result'},{av:'AV44CFSerie',fld:'vCFSERIE',pic:'@!',type:'char'},{av:'AV45CFNumero',fld:'vCFNUMERO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV38TipoOpe',fld:'vTIPOOPE',pic:'',hsh:true,type:'char'},{av:'AV5Identificador',fld:'vIDENTIFICADOR',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV34ParametrosValor',fld:'vPARAMETROSVALOR',pic:'',hsh:true,type:'svchar'}]");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNGENERAR.CLOSE",",oparms:[{av:'divTbfact_Visible',ctrl:'TBFACT',prop:'Visible'},{av:'AV22URL',fld:'vURL',pic:'',type:'svchar'},{av:'AV21QRCode',fld:'vQRCODE',pic:'',type:'bits'}]}");
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
         wcpOAV38TipoOpe = "";
         Dvelop_confirmpanel_btngenerar_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         AV34ParametrosValor = "";
         GXKey = "";
         GX_FocusControl = "";
         sPrefix = "";
         TempTags = "";
         AV42Titulo = "";
         AV44CFSerie = "";
         ClassString = "";
         StyleString = "";
         bttBtngenerar_Jsonclick = "";
         AV21QRCode = "";
         AV47Qrcode_GXI = "";
         sImgUrl = "";
         lblTextblock1_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         imgImage1_gximage = "";
         lblTextblock3_Jsonclick = "";
         AV22URL = "";
         ucToastr = new GXUserControl();
         Form = new GXWebForm();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV36ParametrosEstado = "";
         AV46OperacionesFacturaCod = "";
         AV39stringBase64 = "";
         AV19linkURL = "";
         sStyleString = "";
         ucDvelop_confirmpanel_btngenerar = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
         edtavTitulo_Enabled = 0;
         edtavUrl_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavTitulo_Enabled ;
      private int edtavUrl_Enabled ;
      private int divTbfact_Visible ;
      private int edtavCfserie_Enabled ;
      private int edtavCfnumero_Enabled ;
      private int AV35ParametrosNumerico ;
      private int idxLst ;
      private long AV5Identificador ;
      private long wcpOAV5Identificador ;
      private long AV45CFNumero ;
      private string AV38TipoOpe ;
      private string wcpOAV38TipoOpe ;
      private string Dvelop_confirmpanel_btngenerar_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string edtavTitulo_Internalname ;
      private string edtavUrl_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Dvelop_confirmpanel_btngenerar_Title ;
      private string Dvelop_confirmpanel_btngenerar_Confirmationtext ;
      private string Dvelop_confirmpanel_btngenerar_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_btngenerar_Nobuttoncaption ;
      private string Dvelop_confirmpanel_btngenerar_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_btngenerar_Yesbuttonposition ;
      private string Dvelop_confirmpanel_btngenerar_Confirmtype ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divMaintable_Internalname ;
      private string divTable2_Internalname ;
      private string TempTags ;
      private string edtavTitulo_Jsonclick ;
      private string divTbfact_Internalname ;
      private string edtavCfserie_Internalname ;
      private string AV44CFSerie ;
      private string edtavCfserie_Jsonclick ;
      private string edtavCfnumero_Internalname ;
      private string edtavCfnumero_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtngenerar_Internalname ;
      private string bttBtngenerar_Jsonclick ;
      private string imgavQrcode_gximage ;
      private string sImgUrl ;
      private string imgavQrcode_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string imgImage1_gximage ;
      private string imgImage1_Internalname ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string Toastr_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV36ParametrosEstado ;
      private string AV46OperacionesFacturaCod ;
      private string sStyleString ;
      private string tblTabledvelop_confirmpanel_btngenerar_Internalname ;
      private string Dvelop_confirmpanel_btngenerar_Internalname ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool AV21QRCode_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV39stringBase64 ;
      private string AV34ParametrosValor ;
      private string AV42Titulo ;
      private string AV47Qrcode_GXI ;
      private string AV22URL ;
      private string AV19linkURL ;
      private string AV21QRCode ;
      private GXUserControl ucToastr ;
      private GXUserControl ucDvelop_confirmpanel_btngenerar ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
